using System;
using System.Collections.Generic;

public class CongViec
{
    public string Ten { get; set; }
    public bool HoanThanh { get; set; }

    public CongViec(string ten)
    {
        Ten = ten;
        HoanThanh = false;
    }

    public void ToggleHoanThanh()
    {
        HoanThanh = !HoanThanh;
        OnHoanThanhChanged?.Invoke(this);
    }

    public delegate void HoanThanhChangedHandler(CongViec congViec);
    public event HoanThanhChangedHandler OnHoanThanhChanged;
}

public class Program
{
    static List<CongViec> danhSachCongViec = new List<CongViec>();

    static void Main(string[] args)
    {
        while (true)
        {
            HienThiMenu();
            int luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    ThemCongViec();
                    break;
                case 2:
                    HienThiDanhSachCongViec();
                    break;
                case 3:
                    DanhDauCongViecHoanThanh();
                    break;
                case 4:
                    Thoat();
                    break;
            }
        }
    }

    static void ThemCongViec()
    {
        Console.WriteLine("Nhập tên công việc:");
        string tenCongViec = Console.ReadLine();

        CongViec congViec = new CongViec(tenCongViec);
        congViec.OnHoanThanhChanged += CongViec_OnHoanThanhChanged;
        danhSachCongViec.Add(congViec);

        Console.WriteLine("Công việc đã được thêm!");
    }

    static void HienThiDanhSachCongViec()
    {
        Console.WriteLine("Danh sách công việc:");
        foreach (CongViec congViec in danhSachCongViec)
        {
            Console.WriteLine($"{congViec.Ten} - {(congViec.HoanThanh ? "Hoàn thành" : "Chưa hoàn thành")}");
        }
    }

    static void DanhDauCongViecHoanThanh()
    {
        Console.WriteLine("Nhập số thứ tự công việc cần đánh dấu hoàn thành:");
        int soThuTu = int.Parse(Console.ReadLine());

        if (soThuTu <= 0 || soThuTu > danhSachCongViec.Count)
        {
            Console.WriteLine("Số thứ tự không hợp lệ!");
            return;
        }

        CongViec congViec = danhSachCongViec[soThuTu - 1];
        congViec.ToggleHoanThanh();
    }

    static void CongViec_OnHoanThanhChanged(CongViec congViec)
    {
        Console.WriteLine($"{congViec.Ten} đã được {(congViec.HoanThanh ? "hoàn thành" : "chưa hoàn thành")}");
    }

    static void Thoat()
    {
        Console.WriteLine("Cảm ơn bạn đã sử dụng ứng dụng!");
        Environment.Exit(0);
    }

    static void HienThiMenu()
    {
        Console.WriteLine("-------------------");
        Console.WriteLine("1. Thêm công việc mới");
        Console.WriteLine("2. Hiển thị danh sách công việc");
        Console.WriteLine("3. Đánh dấu công việc hoàn thành");
        Console.WriteLine("4. Thoát");
        Console.WriteLine("-------------------");
        Console.WriteLine("Lựa chọn của bạn:");
    }
}