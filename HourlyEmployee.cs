using System;

namespace LabW04
{
    // Nhân viên hưởng lương theo giờ
    public class HourlyEmployee : Employee
    {
        private double hourlyRate;
        private double workedHours;


        // ==============================
        // PROPERTY
        // ==============================

        public double HourlyRate
        {
            get { return hourlyRate; }
        }

        public double WorkedHours
        {
            get { return workedHours; }
        }


        // ==============================
        // CONSTRUCTOR RÚT GỌN
        // ==============================

        public HourlyEmployee(
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

        public HourlyEmployee(
            string employeeId,
            string fullName,
            string department,
            double hourlyRate,
            double workedHours)
            : base(employeeId, fullName, department)
        {
            // Đơn giá giờ không được âm
            if (hourlyRate < 0)
            {
                throw new ArgumentException(
                    "Đơn giá giờ không được âm.");
            }

            // Số giờ làm phải từ 0 đến 250
            if (workedHours < 0 || workedHours > 250)
            {
                throw new ArgumentException(
                    "Số giờ làm phải từ 0 đến 250.");
            }

            this.hourlyRate = hourlyRate;
            this.workedHours = workedHours;
        }


        // ==============================
        // TÍNH THU NHẬP
        // ==============================

        public override double CalculateGrossPay()
        {
            double basePay;

            // Nếu làm không quá 160 giờ
            if (workedHours <= 160)
            {
                basePay =
                    workedHours * hourlyRate;
            }
            else
            {
                // Tiền của 160 giờ bình thường
                double normalPay =
                    160 * hourlyRate;

                // Số giờ vượt quá 160
                double overtimeHours =
                    workedHours - 160;

                // Tiền làm thêm:
                // hệ số 1.5
                double overtimePay =
                    overtimeHours * hourlyRate * 1.5;

                basePay =
                    normalPay + overtimePay;
            }

            // Cộng thêm tiền thưởng
            return basePay + MonthlyBonus;
        }


        // ==============================
        // LOẠI NHÂN VIÊN
        // ==============================

        public override string GetEmployeeType()
        {
            return "Hourly Employee";
        }


        // ==============================
        // HIỂN THỊ
        // ==============================

        public override void DisplayPayrollInfo()
        {
            base.DisplayPayrollInfo();

            Console.WriteLine(
                $"Đơn giá giờ  : {HourlyRate:N0} VNĐ");

            Console.WriteLine(
                $"Số giờ làm   : {WorkedHours}");

            Console.WriteLine(
                $"Thu nhập     : {CalculateGrossPay():N0} VNĐ");
        }
    }
}