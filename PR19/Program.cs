/*Процесс регистрации пользователя
Создайте UserRegistrationTemplate, StandardUserRegistration, AdminUserRegistration, GuestUserRegistration, чтобы управлять процессом регистрации разных типов пользователей.*/

using System;

abstract class UserRegistrationTemplate
{
    public void Auth()
    {
        Login();
        Password();
        TwoAuth();
        CodeWord();
    }

    private void Login()
    {
        Console.WriteLine("Введен логин");
    }

    //private void Password()
    //{
    //    Console.WriteLine("Введен пароль");
    //}

    //private void TwoAuth()
    //{
    //    Console.WriteLine("Введен код авторизации");
    //}

    protected abstract void Password();
    protected abstract void TwoAuth();
    protected abstract void CodeWord();
}

class StandardUserRegistration : UserRegistrationTemplate
{
    protected override void CodeWord()
    {
    }

    protected override void Password()
    {
        Console.WriteLine("Введен пароль");
    }

    protected override void TwoAuth()
    {
        Console.WriteLine("Введен код авторизации");
    }
}

class AdminUserRegistration : UserRegistrationTemplate
{
    protected override void CodeWord()
    {
        Console.WriteLine("Введено кодовое слово");
    }

    protected override void Password()
    {
        Console.WriteLine("Введен пароль");
    }

    protected override void TwoAuth()
    {
        Console.WriteLine("Введен код авторизации");
    }
}

class GuestUserRegistration : UserRegistrationTemplate
{
    protected override void CodeWord()
    {
    }

    protected override void Password()
    {
    }

    protected override void TwoAuth()
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Вход пользователя");
        UserRegistrationTemplate user = new StandardUserRegistration();
        user.Auth();

        Console.WriteLine("Вход админа");
        UserRegistrationTemplate admin = new AdminUserRegistration();
        admin.Auth();

        Console.WriteLine("Вход гостя");
        UserRegistrationTemplate guest = new GuestUserRegistration();
        guest.Auth();
    }
}