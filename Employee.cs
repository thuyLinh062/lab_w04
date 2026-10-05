//Họ và Tên: Trần Thùy Linh
//MSSV: 202418935
using System;

namespace LabW04
{
    // Lớp Employee là lớp cơ sở cho tất cả các loại nhân viên
    public abstract class Employee
    {
        // ==============================
        // 1. CÁC THUỘC TÍNH CHUNG
        // ==============================

        // Mã nhân viên
        private string employeeId;

        // Họ tên nhân viên
        private string fullName;

        // Phòng ban
        private string department;

        // Tổng tiền thưởng trong tháng
        private double monthlyBonus;


        // ==============================
        // 2. PROPERTY
        // ==============================

        public string EmployeeId
        {
            get { return employeeId; }
        }

        public string FullName
        {
            get { return fullName; }
        }

        public string Department
        {
            get { return department; }
        }

        public double MonthlyBonus
        {
            get { return monthlyBonus; }
        }


        // ==============================
        // 3. CONSTRUCTOR THỨ NHẤT
        // Employee(employeeId, fullName)
        // ==============================

        public Employee(string employeeId, string fullName)
            : this(employeeId, fullName, "Unassigned")
        {
        }


        // ==============================
        // 4. CONSTRUCTOR THỨ HAI
        // Employee(employeeId, fullName, department)
        // ==============================

        public Employee(
            string employeeId,
            string fullName,
            string department)
        {
            // Kiểm tra mã nhân viên
            if (string.IsNullOrWhiteSpace(employeeId))
            {
                throw new ArgumentException(
                    "Mã nhân viên không được rỗng.");
            }

            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException(
                    "Họ tên không được rỗng.");
            }

            // Kiểm tra phòng ban
            if (string.IsNullOrWhiteSpace(department))
            {
                throw new ArgumentException(
                    "Phòng ban không được rỗng.");
            }

            this.employeeId = employeeId;
            this.fullName = fullName;
            this.department = department;

            // Mặc định tiền thưởng = 0
            this.monthlyBonus = 0;
        }


        // ==============================
        // 5. ADD BONUS - OVERLOADING
        // ==============================

        // Cách 1:
        // Thêm một khoản thưởng cố định
        public void AddBonus(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "Khoản thưởng phải lớn hơn 0.");
            }

            monthlyBonus += amount;
        }


        // Cách 2:
        // Thêm thưởng cố định + lý do
        public void AddBonus(double amount, string reason)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "Khoản thưởng phải lớn hơn 0.");
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                throw new ArgumentException(
                    "Lý do thưởng không được rỗng.");
            }

            monthlyBonus += amount;

            Console.WriteLine(
                $"Thưởng {amount:N0} VNĐ - Lý do: {reason}");
        }


        // Cách 3:
        // Thưởng theo tỷ lệ của một giá trị tham chiếu
        public void AddBonus(
            double rate,
            double referenceAmount,
            string reason)
        {
            if (rate <= 0 || rate > 0.5)
            {
                throw new ArgumentException(
                    "Tỷ lệ thưởng phải > 0 và <= 50%.");
            }

            if (referenceAmount <= 0)
            {
                throw new ArgumentException(
                    "Giá trị tham chiếu phải lớn hơn 0.");
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                throw new ArgumentException(
                    "Lý do thưởng không được rỗng.");
            }

            // Tính tiền thưởng
            double bonus = rate * referenceAmount;

            monthlyBonus += bonus;

            Console.WriteLine(
                $"Thưởng {bonus:N0} VNĐ - Lý do: {reason}");
        }


        // ==============================
        // 6. HÀM TÍNH THU NHẬP
        // ==============================

        // abstract:
        // Mỗi lớp con phải tự viết công thức riêng
        public abstract double CalculateGrossPay();


        // ==============================
        // 7. LẤY LOẠI NHÂN VIÊN
        // ==============================

        public abstract string GetEmployeeType();


        // ==============================
        // 8. HIỂN THỊ THÔNG TIN
        // ==============================

        public virtual void DisplayPayrollInfo()
        {
            Console.WriteLine($"Mã nhân viên : {EmployeeId}");
            Console.WriteLine($"Họ tên       : {FullName}");
            Console.WriteLine($"Phòng ban    : {Department}");
            Console.WriteLine($"Tiền thưởng  : {MonthlyBonus:N0} VNĐ");
        }
    }
}