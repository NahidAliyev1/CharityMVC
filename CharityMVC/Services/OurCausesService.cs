using CharityMVC.Contexts;
using CharityMVC.Exceptions;
using CharityMVC.Models;
using CharityMVC.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CharityMVC.Services;

public class OurCausesService
{
    private readonly AppDbContext _context;
    public OurCausesService()
    {
        _context = new AppDbContext();
    }
    #region Read
    public List<OurCauses> GetAllOurcauses()
    {
        List<OurCauses> ourCauses = _context.OurCauses.ToList();
        return ourCauses;

    }
    public OurCauses GetOurCausesById(int id)
    {
        OurCauses? ourCauses = _context.OurCauses.Find(id);
        if (ourCauses is null)
        {
            throw new OurCausesException($"databasada {id} tapilmadi");
        }
        return ourCauses;
    }
    #endregion
    #region Create
    public void CreateOurCauses(OurcausesVM ourCausesVM) 
    {
        OurCauses newOurcauses = new OurCauses();

        newOurcauses.Name = ourCausesVM.Name;
        newOurcauses.ShortDescription = ourCausesVM.ShortDescription;
        newOurcauses.RaisedPrice = ourCausesVM.RaisedPrice;
        newOurcauses.GoalPrice = ourCausesVM.GoalPrice;

        string fileName = Path.GetFileNameWithoutExtension(ourCausesVM.ImgFile.FileName);
        string extension = Path.GetExtension(ourCausesVM.ImgFile.FileName);
        string resultName = fileName + Guid.NewGuid().ToString() + extension;


        string uploadedPath = $"C:\\Users\\II Novbe\\source\\repos\\CharityMVC\\CharityMVC\\wwwroot\\assets\\uploadedImages\\";
        if (!Directory.Exists(uploadedPath))
        {
            Directory.CreateDirectory(uploadedPath);
        }
        uploadedPath = Path.Combine(uploadedPath, resultName);
       
        using FileStream fileStream = new FileStream(uploadedPath,FileMode.Create);


        ourCausesVM.ImgFile.CopyTo(fileStream);



        
       
        newOurcauses.ImgPath = resultName;

        _context.OurCauses.Add(newOurcauses);
        _context.SaveChanges();
    }
    #endregion

    #region Update
    public void UpdateOurCause(int id, OurCauses ourCauses) 
    {
        if (id!=ourCauses.Id)
        {
            throw new OurCausesException("Id ler ust uste dusmur");
        }
        OurCauses? ourCauses1 = _context.OurCauses.AsNoTracking().SingleOrDefault(ou => ou.Id == id);
        if (ourCauses1 is not null)
        {
            _context.Update(ourCauses1);
            _context.SaveChanges();

        }
        else
        {
            throw new OurCausesException($"databasada {id} tapilmadi");
        }
    }
    #endregion
    #region Delete
    public void DeleteOurCauses(int id) 
    {
        OurCauses? ourCauses = _context.OurCauses.Find(id);
        if (ourCauses is not null)
        {
            _context.Remove(ourCauses);
            _context.SaveChanges();
        }
        else
        {
            throw new OurCausesException($"Databasada {id} tapilmadi");
        }
    }
    #endregion
}
