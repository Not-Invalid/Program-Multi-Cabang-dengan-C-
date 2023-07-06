using System;
using System.Collections.Generic;

namespace appMultiCabang
{
    // Class untuk menyimpan informasi barang
    class Barang
    {
        public string Nama { get; set; }
        public double Stok { get; set; }
    }

    // Class untuk menyimpan informasi cabang
    class Cabang
    {
        public string Nama { get; set; }
        public List<Barang> DaftarBarang { get; set; }

        public Cabang()
        {
            DaftarBarang = new List<Barang>();
        }
    }

    class Program
    {
        static List<Cabang> DaftarCabang = new List<Cabang>();

        static void Main(string[] args)
        {
            // Inisialisasi aplikasi
            InisialisasiAplikasi();

            // Memulai Aplikasi
            MemulaiAplikasi();
        }

        static void InisialisasiAplikasi()
        {
            // Inisialisasi Cabang
            Cabang cabang1 = new Cabang { Nama = "Jakarta" };
            cabang1.DaftarBarang.Add(new Barang { Nama = "Beras", Stok = 20 });

            Cabang cabang2 = new Cabang { Nama = "Bandung" };
            cabang2.DaftarBarang.Add(new Barang { Nama = "Minyak", Stok = 40 });

            // Tambah cabang ke daftar cabang
            DaftarCabang.Add(cabang1);
            DaftarCabang.Add(cabang2);
        }

        static void MemulaiAplikasi()
        {
            bool selesai = false;

            while (!selesai)
            {
                Console.Clear();
                Console.WriteLine("==== Selamat Datang di Aplikasi Multi Cabang ====");
                Console.WriteLine("\n 1. Lihat Stok Barang");
                Console.WriteLine("\n 2. Menambah Jenis Barang");
                Console.WriteLine("\n 3. Hapus Barang");
                Console.WriteLine("\n 4. Daftar Cabang");
                Console.WriteLine("\n 5. Menambah Cabang");

                Console.Write("\n Masukan Pilihan Anda: ");
                int pilihan;
                bool isValidInput = int.TryParse(Console.ReadLine(), out pilihan);

                if (!isValidInput)
                {
                    Console.WriteLine("Pilihan tidak valid. Masukkan angka.");
                    Console.ReadLine();
                    continue;
                }

                switch (pilihan)
                {
                    case 1:
                        LihatStokBarang();
                        break;
                    case 2:
                        MenambahJenisBarang();
                        break;
                    case 3:
                        HapusBarang();
                        break;
                    case 4:
                        LihatDaftarCabang();
                        break;
                    case 5:
                        MenambahkanCabang();
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

                Console.WriteLine("\nTekan ENTER untuk kembali ke Menu Utama...");
                Console.ReadLine();
            }
        }

        static void LihatStokBarang()
        {
            Console.Clear();
            Console.WriteLine("==== Stok Barang ====");

            foreach (Cabang cabang in DaftarCabang)
            {
                Console.WriteLine("Cabang: " + cabang.Nama);

                foreach (Barang barang in cabang.DaftarBarang)
                {
                    Console.WriteLine("Nama Barang  : " + barang.Nama);
                    Console.WriteLine("Stok         : " + barang.Stok + "kg");
                    Console.WriteLine("-----------------------------------");
                }
            }
        }

        static void MenambahJenisBarang()
        {
            Console.Clear();
            Console.WriteLine("==== Menambahkan Jenis Barang ====");

            Console.Write("Masukkan Nama Cabang         : ");
            string namaCabang = Console.ReadLine() ?? "";

            // Cari cabang dengan nama yang sesuai
            Cabang cabang = DaftarCabang.Find(c => c.Nama == namaCabang);
            if (cabang == null)
            {
                Console.WriteLine("Cabang tidak ditemukan");
                return;
            }

            Console.Write("Masukkan nama barang         : ");
            string namaBarang = Console.ReadLine() ?? "";

            Console.Write("Masukkan jumlah stok barang  : ");
            double jumlahStok;
            bool isValidInput = double.TryParse(Console.ReadLine(), out jumlahStok);

            if (!isValidInput)
            {
                Console.WriteLine("Jumlah stok tidak valid. Masukkan angka.");
                return;
            }

            // Tambahkan barang ke cabang
            cabang.DaftarBarang.Add(new Barang { Nama = namaBarang, Stok = jumlahStok });

            Console.WriteLine("Barang berhasil ditambahkan ke cabang " + cabang.Nama);
        }

        static void HapusBarang()
        {
            Console.Clear();
            Console.WriteLine("===== Hapus Barang =====");

            Console.Write("Masukkan nama cabang                         : ");
            string namaCabang = Console.ReadLine() ?? "";

            // Cari cabang dengan nama yang sesuai
            Cabang cabang = DaftarCabang.Find(c => c.Nama == namaCabang);

            if (cabang == null)
            {
                Console.WriteLine("Cabang tidak ditemukan");
                return;
            }

            Console.Write("Masukkan nama barang yang ingin dihapus      : ");
            string namaBarang = Console.ReadLine() ?? "";

            // Cari barang dengan nama yang sesuai
            Barang barang = cabang.DaftarBarang.Find(b => b.Nama == namaBarang);

            if (barang == null)
            {
                Console.WriteLine("Barang tidak ditemukan");
                return;
            }

            // Hapus barang dari cabang
            cabang.DaftarBarang.Remove(barang);

            Console.WriteLine("Barang berhasil dihapus dari cabang " + cabang.Nama);
        }

        static void LihatDaftarCabang()
        {
            Console.Clear();
            Console.WriteLine("==== Daftar Cabang ====");

            for (int i = 0; i < DaftarCabang.Count; i++)
            {
                Console.WriteLine((i + 1) + ". Nama Cabang: " + DaftarCabang[i].Nama);
            }
        }
        
        static void MenambahkanCabang()
        {
            Console.Clear();
            Console.WriteLine("==== Menambah Cabang ====");

            Console.Write("Masukkan Nama Cabang baru: ");
            string namaCabang = Console.ReadLine() ?? "";

            // Jika nama cabang yang diinput sudah ada
            if (DaftarCabang.Exists(c => c.Nama == namaCabang))
            {
                Console.WriteLine($"Nama {namaCabang} telah terdaftar");
                return;
            }

            // Tambahkan cabang baru ke daftar cabang
            Cabang cabang = new Cabang { Nama = namaCabang };
            DaftarCabang.Add(cabang);

            Console.WriteLine("Cabang baru berhasil ditambahkan");
        }
    }
}
