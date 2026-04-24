using System;
using System.Collections.Generic;

// Kelas Induk
class Karyawan
{
    public string Nama { get; set; }
    public double Gaji { get; set; }

    public Karyawan(string nama, double gaji)
    {
        Nama = nama;
        Gaji = gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine(Nama + " sedang bekerja.");
    }

    public virtual void InfoKaryawan()
    {
        Console.WriteLine("Nama: " + Nama);
        Console.WriteLine("Gaji: " + Gaji);
    }
}

// Turunan dari Karyawan
class Tetap : Karyawan
{
    public double Tunjangan { get; set; }

    public Tetap(string nama, double gaji, double tunjangan)
        : base(nama, gaji)
    {
        Tunjangan = tunjangan;
    }

    public double HitungGajiTotal()
    {
        return Gaji + Tunjangan;
    }

    public override void Kerja()
    {
        Console.WriteLine(Nama + " bekerja sebagai karyawan tetap.");
    }

    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine("Tunjangan: " + Tunjangan);
        Console.WriteLine("Total Gaji: " + HitungGajiTotal());
    }
}

// Turunan dari Karyawan
class Kontrak : Karyawan
{
    public int Durasi { get; set; }

    public Kontrak(string nama, double gaji, int durasi)
        : base(nama, gaji)
    {
        Durasi = durasi;
    }

    public void CekKontrak()
    {
        Console.WriteLine("Durasi kontrak: " + Durasi + " bulan");
    }

    public override void Kerja()
    {
        Console.WriteLine(Nama + " bekerja sebagai karyawan kontrak.");
    }
}

// Manager & Staff
class Manager : Tetap
{
    public Manager(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }

    public void Memimpin()
    {
        Console.WriteLine(Nama + " sedang memimpin tim.");
    }

    public override void Kerja()
    {
        Console.WriteLine(Nama + " bekerja sebagai manager.");
    }
}

class Staff : Tetap
{
    public Staff(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }

    public void KerjakanTugas()
    {
        Console.WriteLine(Nama + " sedang mengerjakan tugas.");
    }

    public override void Kerja()
    {
        Console.WriteLine(Nama + " bekerja sebagai staff.");
    }
}

// Magang & Freelancer
class Magang : Kontrak
{
    public Magang(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }

    public void Belajar()
    {
        Console.WriteLine(Nama + " sedang belajar.");
    }

    public override void Kerja()
    {
        Console.WriteLine(Nama + " bekerja sebagai magang.");
    }
}

class Freelancer : Kontrak
{
    public Freelancer(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }

    public void AmbilProyek()
    {
        Console.WriteLine(Nama + " sedang mengambil proyek.");
    }

    public override void Kerja()
    {
        Console.WriteLine(Nama + " bekerja sebagai freelancer.");
    }
}

// Kelas Perusahaan
class Perusahaan
{
    private List<Karyawan> daftarKaryawan = new List<Karyawan>();

    public void TambahKaryawan(Karyawan karyawan)
    {
        daftarKaryawan.Add(karyawan);
    }

    public void DaftarKaryawan()
    {
        foreach (var k in daftarKaryawan)
        {
            Console.WriteLine("-------------------");
            k.InfoKaryawan();
            k.Kerja();
        }
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        Perusahaan perusahaan = new Perusahaan();

        Manager m = new Manager("Frandy", 5000000, 2000000);
        Staff s = new Staff("Jeki", 3000000, 1000000);
        Magang mg = new Magang("Abil", 1000000, 6);
        Freelancer f = new Freelancer("Deka", 2000000, 3);

        perusahaan.TambahKaryawan(m);
        perusahaan.TambahKaryawan(s);
        perusahaan.TambahKaryawan(mg);
        perusahaan.TambahKaryawan(f);

        // Tampilkan semua data
        perusahaan.DaftarKaryawan();

        Console.WriteLine("\n=== Polymorphism ==");
        Karyawan k = new Staff("Fater", 2500000, 800000);
        k.Kerja(); // polymorphism

        Console.WriteLine("\n=== Method Khusus ===");
        m.Memimpin();
        s.KerjakanTugas();
        mg.Belajar();
        f.AmbilProyek();

        Console.WriteLine("\n=== Soal Demonstrasi ===");

        // Soal 1
        m.Kerja();
        f.Kerja();

        // Soal 2
        m.Memimpin();

        // Soal 3
        m.InfoKaryawan();

        // Soal 4
        mg.Belajar();

        // Soal 5
        Karyawan k2 = new Staff("Wildan", 2800000, 900000);
        k2.Kerja();

        Console.ReadLine();
    }
}