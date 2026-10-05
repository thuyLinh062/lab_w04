//Họ và Tên: Trần Thùy Linh
//MSSV: 202418935
using System;

namespace LabW04
{
    // Nhân viên kinh doanh
    public class SalesEmployee : Employee
    {
        private double baseSalary;
        private double salesRevenue;
        private double commissionRate;


        // ==============================
        // PROPERTY
        // ==============================

        public double BaseSalary
        {
            get { return baseSalary; }
        }

        public double SalesRevenue
        {
            get { return salesRevenue; }
        }

        public double CommissionRate
        {
            get { return commissionRate; }
        }


        // ==============================
        // CONSTRUCTOR RÚT GỌN
        // ==============================

        public SalesEmployee(
            string employeeId,
            string fullName)
            : this(
                employeeId,
                fullName,
                "Unassigned",
                0,
                0,
                0)
        {
        }


        // ==============================
        // CONSTRUCTOR ĐẦY ĐỦ
        // ==============================

        public SalesEmployee(
            string employeeId,
            string fullName,
            string department,
            double baseSalary,
            double salesRevenue,
            double commissionRate)
            : base(employeeId, fullName, department)
        {
            if (baseSalary < 0)
            {
                throw new ArgumentException(
                    "Lương cơ bản không được âm.");
            }

            if (salesRevenue < 0)
            {
                throw new ArgumentException(
                    "Doanh số không được âm.");
            }

            // commissionRate từ 0 đến 30%
            if (commissionRate < 0 ||
                commissionRate > 0.3)
            {
                throw new ArgumentException(
                    "Tỷ lệ hoa hồng phải từ 0 đến 30%.");
            }

            this.baseSalary = baseSalary;
            this.salesRevenue = salesRevenue;
            this.commissionRate = commissionRate;
        }


        // ==============================
        // CẬP NHẬT DOANH SỐ
        // ==============================

        public void UpdateSalesRevenue(double newRevenue)
        {
            if (newRevenue < 0)
            {
                throw new ArgumentException(
                    "Doanh số không được âm.");
            }

            salesRevenue = newRevenue;
        }


        // ==============================
        // OVERRIDE TÍNH THU NHẬP
        // ==============================

        public override double CalculateGrossPay()
        {
            double commission =
                salesRevenue * commissionRate;

            return baseSalary
                   + commission
                   + MonthlyBonus;
        }


        // ==============================
        // LOẠI NHÂN VIÊN
        // ==============================

        public override string GetEmployeeType()
        {
            return "Sales Employee";
        }


        // ==============================
        // HIỂN THỊ
        // ==============================

        public override void DisplayPayrollInfo()
        {
            base.DisplayPayrollInfo();

            Console.WriteLine(
                $"Lương cơ bản : {BaseSalary:N0} VNĐ");

            Console.WriteLine(
                $"Doanh số     : {SalesRevenue:N0} VNĐ");

            Console.WriteLine(
                $"Hoa hồng     : {CommissionRate:P0}");

            Console.WriteLine(
                $"Thu nhập     : {CalculateGrossPay():N0} VNĐ");
        }
    }
}