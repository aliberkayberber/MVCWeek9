namespace MVCWeek9.Entities;

public class UserEntity
{

    public UserEntity() // when user creat date time creat
    {
        JoinDate = DateTime.Now;
    }
    public int Id {get;set;}
    public string FullName {get;set;}
    public string Email {get;set;}
    public string Password {get;set;}
    public string PhoneNumber {get;set;}
    public DateTime JoinDate {get;set;}
}