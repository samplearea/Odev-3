using System;

// 1) Çalışan (Employee) Sınıfı ve Kalıtım
class Employee
{
    public int Id { get; set; }
    public string Isim { get; set; }
    public double Maas { get; set; }
    public string Departman { get; set; }

    public Employee(int id, string isim, double maas, string departman)
    {
        Id = id;
        Isim = isim;
        Maas = maas;
        Departman = departman;
    }

    public virtual double PrimHesapla()
    {
        return 0;
    }
}

class Manager : Employee
{
    public int TakimBoyutu { get; set; }

    public Manager(int id, string isim, double maas, string departman, int takimBoyutu)
        : base(id, isim, maas, departman)
    {
        TakimBoyutu = takimBoyutu;
    }

    public override double PrimHesapla()
    {
        return Maas * 0.2;
    }
}

class Developer : Employee
{
    public string Hakkinda { get; set; }

    public Developer(int id, string isim, double maas, string departman, string hakkinda)
        : base(id, isim, maas, departman)
    {
        Hakkinda = hakkinda;
    }

    public override double PrimHesapla()
    {
        return Maas * 0.1;
    }
}

// 2) Banka Hesabı (BankAccount) ve Türetilen Sınıflar
class BankaHesabi
{
    public string HesapSahibi { get; set; }
    public double Bakiye { get; set; }

    public BankaHesabi(string hesapSahibi, double bakiye)
    {
        HesapSahibi = hesapSahibi;
        Bakiye = bakiye;
    }

    public virtual void FaizHesapla()
    {
    }
}

class VadeliHesap : BankaHesabi
{
    public VadeliHesap(string hesapSahibi, double bakiye) : base(hesapSahibi, bakiye)
    {
    }

    public override void FaizHesapla()
    {
        double faiz = Bakiye * 0.05;
        Console.WriteLine($"Kazanılan faiz: {faiz}");
    }
}

class VadesizHesap : BankaHesabi
{
    public VadesizHesap(string hesapSahibi, double bakiye) : base(hesapSahibi, bakiye)
    {
    }

    public override void FaizHesapla()
    {
        Console.WriteLine("Vadesiz hesaplar faiz kazandırmaz.");
    }
}

// 3) Soyut (Abstract) Sınıf Örneği
abstract class Sekil
{
    public abstract double AlanHesapla();
}

class Daire : Sekil
{
    public double Yaricap { get; set; }
    public Daire(double yaricap)
    {
        Yaricap = yaricap;
    }
    public override double AlanHesapla()
    {
        return Math.PI * Yaricap * Yaricap;
    }
}

class Dikdortgen : Sekil
{
    public double Genislik { get; set; }
    public double Yukseklik { get; set; }
    public Dikdortgen(double genislik, double yukseklik)
    {
        Genislik = genislik;
        Yukseklik = yukseklik;
    }
    public override double AlanHesapla()
    {
        return Genislik * Yukseklik;
    }
}

// 4) Arayüz (Interface) Örneği
interface IArac
{
    void Calistir();
    void Durdur();
}

class Araba : IArac
{
    public void Calistir()
    {
        Console.WriteLine("Araba çalışıyor.");
    }
    public void Durdur()
    {
        Console.WriteLine("Araba duruyor.");
    }
}

class Bisiklet : IArac
{
    public void Calistir()
    {
        Console.WriteLine("Bisiklet hareket ediyor.");
    }
    public void Durdur()
    {
        Console.WriteLine("Bisiklet duruyor.");
    }
}

class Program
{
    static void Main()
    {
        Manager yonetici = new Manager(1, "Ali", 10000, "IT", 5);
        Developer gelistirici = new Developer(2, "Veli", 8000, "Yazılım", "Backend Geliştirici");

        Console.WriteLine($"Yönetici Primi: {yonetici.PrimHesapla()}");
        Console.WriteLine($"Geliştirici Primi: {gelistirici.PrimHesapla()}");

        VadeliHesap vadeli = new VadeliHesap("Ahmet", 5000);
        VadesizHesap vadesiz = new VadesizHesap("Mehmet", 3000);

        vadeli.FaizHesapla();
        vadesiz.FaizHesapla();

        Sekil daire = new Daire(5);
        Sekil dikdortgen = new Dikdortgen(4, 6);
        Console.WriteLine($"Daire Alanı: {daire.AlanHesapla()}");
        Console.WriteLine($"Dikdörtgen Alanı: {dikdortgen.AlanHesapla()}");

        IArac araba = new Araba();
        IArac bisiklet = new Bisiklet();
        araba.Calistir();
        araba.Durdur();
        bisiklet.Calistir();
        bisiklet.Durdur();
    }
}
