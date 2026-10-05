//Họ và Tên: Trần Thùy Linh
//MSSV: 202418935
using System;

namespace LabW04
{
internal class Program
{
static void Main(string[] args)
{
Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("==============================================");
        Console.WriteLine("   HỆ THỐNG TÍNH LƯƠNG VÀ THƯỞNG NHÂN SỰ");
        Console.WriteLine("==============================================");

        // =========================================================
        // DANH SÁCH ĐỐI TƯỢNG THEO ĐỀ BÀI
        // =========================================================
        Console.WriteLine("\n========== CÁC ĐỐI TƯỢNG YÊU CẦU ==========");

        Console.WriteLine("E001 - Nguyễn Minh An - Phòng Đào tạo");
        Console.WriteLine("Lương tháng: 15.000.000");
        Console.WriteLine("Phụ cấp: 2.000.000");
        Console.WriteLine("Thưởng cố định: 1.000.000");
        Console.WriteLine("Thu nhập mong đợi: 18.000.000");
        Console.WriteLine("\nE002 - Trần Thu Bình - Phòng Hỗ trợ");
        Console.WriteLine("Đơn giá giờ: 100.000");
        Console.WriteLine("Số giờ: 150");
        Console.WriteLine("Thưởng: 500.000");
        Console.WriteLine("Thu nhập mong đợi: 15.500.000");

        Console.WriteLine("\nE003 - Lê Hoàng Chi - Phòng Hỗ trợ");
        Console.WriteLine("Đơn giá giờ: 100.000");
        Console.WriteLine("Số giờ: 170");
        Console.WriteLine("Không có thưởng");
        Console.WriteLine("160 × 100.000 + 10 × 100.000 × 1,5 = 17.500.000");
        Console.WriteLine("Thu nhập mong đợi: 17.500.000");

        Console.WriteLine("\nE004 - Phạm Quốc Dũng - Phòng Kinh doanh");
        Console.WriteLine("Lương cơ bản: 8.000.000");
        Console.WriteLine("Doanh số: 200.000.000");
        Console.WriteLine("Hoa hồng: 5%");
        Console.WriteLine("Thưởng theo tỷ lệ: 2% của 50.000.000");
        Console.WriteLine("8.000.000 + 200.000.000 × 5% + 50.000.000 × 2% = 19.000.000");
        Console.WriteLine("Thu nhập mong đợi: 19.000.000");

        Console.WriteLine("\nTổng bảng lương mong đợi: 70.000.000 VND");
        Console.WriteLine("Tổng phòng Hỗ trợ: 33.000.000 VND");

        // =========================================================
        // TEST 1: SalariedEmployee - Nhân viên hưởng lương tháng
        // =========================================================
        Console.WriteLine("\n========== TEST 1: SALARIED EMPLOYEE ==========");

        // E001 - Nhân viên lương cố định
        // Họ tên: Nguyễn Minh An
        // Phòng: Đào tạo
        // Lương tháng = 15.000.000
        // Phụ cấp = 2.000.000
        // Thưởng cố định = 1.000.000
        // Thu nhập mong đợi = 18.000.000
        SalariedEmployee e1 = new SalariedEmployee(
            "E001",
            "Nguyễn Minh An",
            "Đào tạo",
            15_000_000,
            2_000_000
        );

        e1.AddBonus(1_000_000);

        Console.WriteLine($"Gross pay E001 = {e1.CalculateGrossPay():N0} VND");
        Console.WriteLine("Kết quả mong đợi: 18.000.000 VND");


        // =========================================================
        // TEST 2: HourlyEmployee - 150 giờ, chưa có OT
        // =========================================================
        Console.WriteLine("\n========== TEST 2: HOURLY 150 HOURS ==========");

        // E002 - Nhân viên theo giờ, không có giờ vượt ngưỡng
        // Họ tên: Trần Thu Bình
        // Phòng: Hỗ trợ
        // Đơn giá giờ = 100.000
        // Số giờ = 150
        // Thưởng = 500.000
        // Thu nhập mong đợi = 15.500.000
        HourlyEmployee e2 = new HourlyEmployee(
            "E002",
            "Trần Thu Bình",
            "Hỗ trợ",
            100_000,
            150
        );

        e2.AddBonus(500_000);

        Console.WriteLine($"Gross pay E002 = {e2.CalculateGrossPay():N0} VND");
        Console.WriteLine("Kết quả mong đợi: 15.500.000 VND");


        // =========================================================
        // TEST 3: HourlyEmployee - 170 giờ, có OT
        // =========================================================
        Console.WriteLine("\n========== TEST 3: HOURLY 170 HOURS ==========");

        // E003 - Nhân viên theo giờ, có giờ vượt ngưỡng
        // Họ tên: Lê Hoàng Chi
        // Phòng: Hỗ trợ
        // Đơn giá giờ = 100.000
        // Số giờ = 170
        // Không có thưởng
        // 160 × 100.000 + 10 × 100.000 × 1,5 = 17.500.000
        HourlyEmployee e3 = new HourlyEmployee(
            "E003",
            "Lê Hoàng Chi",
            "Hỗ trợ",
            100_000,
            170
        );

        Console.WriteLine($"Gross pay E003 = {e3.CalculateGrossPay():N0} VND");
        Console.WriteLine("Kết quả mong đợi: 17.500.000 VND");


        // =========================================================
        // TEST 4: SalesEmployee - Nhân viên kinh doanh
        // =========================================================
        Console.WriteLine("\n========== TEST 4: SALES EMPLOYEE ==========");

        // E004 - Nhân viên kinh doanh
        // Họ tên: Phạm Quốc Dũng
        // Phòng: Kinh doanh
        // Lương cơ bản = 8.000.000
        // Doanh số = 200.000.000
        // Hoa hồng = 5%
        // Thưởng theo tỷ lệ = 2% của 50.000.000
        // 8.000.000 + 200.000.000 × 5% + 50.000.000 × 2%
        // = 19.000.000
        SalesEmployee e4 = new SalesEmployee(
            "E004",
            "Phạm Quốc Dũng",
            "Kinh doanh",
            8_000_000,
            200_000_000,
            0.05
        );

        e4.AddBonus(0.02, 50_000_000, "Thuong doanh so");

        Console.WriteLine($"Gross pay E004 = {e4.CalculateGrossPay():N0} VND");
        Console.WriteLine("Kết quả mong đợi: 19.000.000 VND");


        // =========================================================
        // TEST 5: Tính tổng payroll
        // =========================================================
        Console.WriteLine("\n========== TEST 5: TOTAL PAYROLL ==========");

        Payroll payroll = new Payroll("09/2026");

        payroll.AddEmployee(e1);
        payroll.AddEmployee(e2);
        payroll.AddEmployee(e3);
        payroll.AddEmployee(e4);

        double totalPayroll = payroll.CalculateTotalPayroll();

        Console.WriteLine($"Total payroll = {totalPayroll:N0} VND");
        Console.WriteLine("Kết quả mong đợi: 70.000.000 VND");


        // =========================================================
        // TEST 6: Tính payroll theo phòng ban
        // =========================================================
        Console.WriteLine("\n========== TEST 6: PAYROLL BY DEPARTMENT ==========");

        double supportPayroll =
            payroll.CalculatePayrollByDepartment("Hỗ trợ");

        Console.WriteLine(
            $"Payroll phòng Hỗ trợ = {supportPayroll:N0} VND"
        );

        // E002 = 15.5 triệu
        // E003 = 17.5 triệu
        // Tổng = 33 triệu
        Console.WriteLine("Kết quả mong đợi: 33.000.000 VND");


        // =========================================================
        // TEST 7: AddBonus(amount)
        // =========================================================
        Console.WriteLine("\n========== TEST 7: ADD BONUS (AMOUNT) ==========");

        SalariedEmployee e5 = new SalariedEmployee(
            "E005",
            "Hoang Van E",
            "IT",
            12_000_000,
            1_000_000
        );

        e5.AddBonus(500_000);

        Console.WriteLine(
            $"Gross pay E005 = {e5.CalculateGrossPay():N0} VND"
        );

        // 12 + 1 + 0.5 = 13.5 triệu
        Console.WriteLine("Kết quả mong đợi: 13.500.000 VND");


        // =========================================================
        // TEST 8: AddBonus(amount, reason)
        // =========================================================
        Console.WriteLine("\n========== TEST 8: ADD BONUS (AMOUNT + REASON) ==========");

        SalariedEmployee e6 = new SalariedEmployee(
            "E006",
            "Doan Thi F",
            "Nhan su",
            10_000_000,
            1_000_000
        );

        e6.AddBonus(1_000_000, "Thuong hoan thanh cong viec");

        Console.WriteLine(
            $"Gross pay E006 = {e6.CalculateGrossPay():N0} VND"
        );

        // 10 + 1 + 1 = 12 triệu
        Console.WriteLine("Kết quả mong đợi: 12.000.000 VND");


        // =========================================================
        // TEST 9: AddBonus(rate, referenceAmount, reason)
        // =========================================================
        Console.WriteLine("\n========== TEST 9: ADD BONUS (RATE) ==========");

        SalariedEmployee e7 = new SalariedEmployee(
            "E007",
            "Vu Van G",
            "IT",
            10_000_000,
            1_000_000
        );

        // Bonus = 10% × 5.000.000 = 500.000
        e7.AddBonus(
            0.10,
            5_000_000,
            "Thuong hieu qua"
        );

        Console.WriteLine(
            $"Gross pay E007 = {e7.CalculateGrossPay():N0} VND"
        );

        Console.WriteLine("Kết quả mong đợi: 11.500.000 VND");


        // =========================================================
        // TEST 10: Kiểm tra AddBonus(amount) không hợp lệ
        // =========================================================
        Console.WriteLine("\n========== TEST 10: INVALID BONUS ==========");

        try
        {
            SalariedEmployee e8 = new SalariedEmployee(
                "E008",
                "Test Invalid",
                "IT",
                10_000_000,
                1_000_000
            );

            // amount = 0 -> không hợp lệ
            e8.AddBonus(0);

            Console.WriteLine("LỖI: Chương trình phải từ chối bonus = 0.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Đã bắt được lỗi đúng:");
            Console.WriteLine(ex.Message);
            Console.WriteLine("Kết quả mong đợi: Bonus <= 0 bị từ chối.");
        }


        // =========================================================
        // TEST 11: CommissionRate > 30%
        // =========================================================
        Console.WriteLine("\n========== TEST 11: INVALID COMMISSION RATE ==========");

        try
        {
            SalesEmployee e9 = new SalesEmployee(
                "E009",
                "Test Commission",
                "Kinh doanh",
                10_000_000,
                100_000_000,
                0.40
            );

            Console.WriteLine(
                $"Gross pay = {e9.CalculateGrossPay():N0}"
            );

            Console.WriteLine("LỖI: CommissionRate = 40% phải bị từ chối.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Đã bắt được lỗi đúng:");
            Console.WriteLine(ex.Message);
            Console.WriteLine(
                "Kết quả mong đợi: CommissionRate > 30% bị từ chối."
            );
        }


        // =========================================================
        // TEST 12: WorkedHours > 250
        // =========================================================
        Console.WriteLine("\n========== TEST 12: INVALID WORKED HOURS ==========");

        try
        {
            HourlyEmployee e10 = new HourlyEmployee(
                "E010",
                "Test Hours",
                "Hỗ trợ",
                100_000,
                251
            );

            Console.WriteLine(
                $"Gross pay = {e10.CalculateGrossPay():N0}"
            );

            Console.WriteLine(
                "LỖI: WorkedHours = 251 phải bị từ chối."
            );
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Đã bắt được lỗi đúng:");
            Console.WriteLine(ex.Message);
            Console.WriteLine(
                "Kết quả mong đợi: WorkedHours > 250 bị từ chối."
            );
        }


        // =========================================================
        // TEST 13: Thêm nhân viên có ID trùng
        // =========================================================
        Console.WriteLine("\n========== TEST 13: DUPLICATE EMPLOYEE ID ==========");

        try
        {
            // E001 đã tồn tại trong payroll
            SalariedEmployee duplicateEmployee =
                new SalariedEmployee(
                    "E001",
                    "Nhan Vien Trung ID",
                    "IT",
                    10_000_000,
                    1_000_000
                );

            payroll.AddEmployee(duplicateEmployee);

            Console.WriteLine(
                "LỖI: Không được phép thêm Employee có ID trùng."
            );
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Đã bắt được lỗi đúng:");
            Console.WriteLine(ex.Message);
            Console.WriteLine(
                "Kết quả mong đợi: Không cho phép ID trùng."
            );
        }


        // =========================================================
        // TEST 14: Tìm nhân viên theo ID
        // =========================================================
        Console.WriteLine("\n========== TEST 14: FIND EMPLOYEE ==========");

        Employee? foundEmployee = payroll.FindEmployee("E003");

        if (foundEmployee != null)
        {
            Console.WriteLine(
                $"Đã tìm thấy: {foundEmployee.EmployeeId}"
            );

            Console.WriteLine(
                $"Tên: {foundEmployee.FullName}"
            );

            Console.WriteLine(
                $"Loại: {foundEmployee.GetEmployeeType()}"
            );

            Console.WriteLine(
                "Kết quả mong đợi: Tìm thấy E003."
            );
        }
        else
        {
            Console.WriteLine("LỖI: Không tìm thấy E003.");
        }


        // =========================================================
        // TEST 15: Tìm nhân viên không tồn tại
        // =========================================================
        Console.WriteLine("\n========== TEST 15: FIND NON-EXISTENT EMPLOYEE ==========");

        Employee? notFound = payroll.FindEmployee("E999");

        if (notFound == null)
        {
            Console.WriteLine(
                "Không tìm thấy E999 - đúng."
            );

            Console.WriteLine(
                "Kết quả mong đợi: Không tìm thấy nhân viên."
            );
        }
        else
        {
            Console.WriteLine(
                "LỖI: E999 không tồn tại nhưng lại được tìm thấy."
            );
        }


        // =========================================================
        // TEST 16: Tìm nhân viên có lương cao nhất
        // =========================================================
        Console.WriteLine("\n========== TEST 16: HIGHEST PAID EMPLOYEE ==========");

        Employee? highestPaid =
            payroll.FindHighestPaidEmployee();

        if (highestPaid != null)
        {
            Console.WriteLine(
                $"Nhân viên lương cao nhất: {highestPaid.EmployeeId}"
            );

            Console.WriteLine(
                $"Tên: {highestPaid.FullName}"
            );

            Console.WriteLine(
                $"Gross pay: {highestPaid.CalculateGrossPay():N0} VND"
            );

            Console.WriteLine(
                "Kết quả mong đợi: E004 - 19.000.000 VND."
            );
        }


        // =========================================================
        // TEST 17: Hiển thị toàn bộ bảng lương
        // =========================================================
        Console.WriteLine("\n========== TEST 17: DISPLAY PAYROLL ==========");

        payroll.DisplayPayroll();

        Console.WriteLine("\n==============================================");
        Console.WriteLine("           KẾT THÚC KIỂM THỬ");
        Console.WriteLine("==============================================");

        Console.WriteLine("\nNhấn Enter để kết thúc...");
        Console.ReadLine();
    }
}

}
