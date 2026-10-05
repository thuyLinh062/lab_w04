using System;

namespace LabW04
{
    // Nhân viên hưởng lương cố định
    public class SalariedEmployee : Employee
    {
        // ==============================
        // THUỘC TÍNH RIÊNG
        // ==============================

        private double monthlySalary;

        private double responsibilityAllowance;


        // ==============================
        // PROPERTY
        // ==============================

        public double MonthlySalary
        {
            get { return monthlySalary; }
        }

        public double ResponsibilityAllowance
        {
            get { return responsibilityAllowance; }
        }


        // ==============================
        // CONSTRUCTOR RÚT GỌN
        // ==============================

        public SalariedEmployee(
            string employeeId,
            string fullName)
            : this(
                employeeId,
                fullName,
                "Unassigned",
                0,
                0)
        {
        }


        // ==============================
        // CONSTRUCTOR ĐẦY ĐỦ
        // ==============================

        public SalariedEmployee(
            string employeeId,
            string fullName,
            string department,
            double monthlySalary,
            double responsibilityAllowance)
            : base(employeeId, fullName, department)
        {
            if (monthlySalary < 0)
            {
                throw new ArgumentException(
                    "Lương tháng không được âm.");
            }

            if (responsibilityAllowance < 0)
            {
                throw new ArgumentException(
                    "Phụ cấp trách nhiệm không được âm.");
            }

            this.monthlySalary = monthlySalary;
            this.responsibilityAllowance =
                responsibilityAllowance;
        }


        // ==============================
        // OVERRIDE TÍNH THU NHẬP
        // ==============================

        public override double CalculateGrossPay()
        {
            return monthlySalary
                   + responsibilityAllowance
                   + MonthlyBonus;
        }


        // ==============================
        // OVERRIDE LẤY LOẠI NHÂN VIÊN
        // ==============================

        public override string GetEmployeeType()
        {
            return "Salaried Employee";
        }


        // ==============================
        // OVERRIDE HIỂN THỊ
        // ==============================

        public override void DisplayPayrollInfo()
        {
            base.DisplayPayrollInfo();

            Console.WriteLine(
                $"Lương tháng  : {MonthlySalary:N0} VNĐ");

            Console.WriteLine(
                $"Phụ cấp      : {ResponsibilityAllowance:N0} VNĐ");

            Console.WriteLine(
                $"Thu nhập     : {CalculateGrossPay():N0} VNĐ");
        }
    }
}