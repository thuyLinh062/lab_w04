using System;
using System.Collections.Generic;

namespace LabW04
{
    // Payroll quản lý danh sách nhân viên
    // trong một kỳ lương
    public class Payroll
    {
        // ==============================
        // THUỘC TÍNH
        // ==============================

        private string period;

        // Danh sách dùng kiểu Employee
        // để có thể chứa tất cả lớp con
        private List<Employee> employees;


        // ==============================
        // CONSTRUCTOR
        // ==============================

        public Payroll(string period)
        {
            if (string.IsNullOrWhiteSpace(period))
            {
                throw new ArgumentException(
                    "Kỳ lương không được rỗng.");
            }

            this.period = period;

            employees = new List<Employee>();
        }


        // ==============================
        // THÊM NHÂN VIÊN
        // ==============================

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(
                    nameof(employee));
            }

            // Kiểm tra trùng mã
            if (FindEmployee(employee.EmployeeId) != null)
            {
                Console.WriteLine(
                    $"Không thể thêm {employee.EmployeeId}: " +
                    "mã nhân viên đã tồn tại.");

                return;
            }

            employees.Add(employee);

            Console.WriteLine(
                $"Đã thêm nhân viên {employee.EmployeeId}.");
        }


        // ==============================
        // TÌM NHÂN VIÊN
        // ==============================

        public Employee? FindEmployee(string employeeId)
        {
            foreach (Employee employee in employees)
            {
                if (employee.EmployeeId == employeeId)
                {
                    return employee;
                }
            }

            return null;
        }


        // ==============================
        // TÍNH TỔNG BẢNG LƯƠNG
        // ==============================

        public double CalculateTotalPayroll()
        {
            double total = 0;

            foreach (Employee employee in employees)
            {
                // Gọi thông qua kiểu Employee
                // nhưng lúc chạy sẽ thực hiện
                // CalculateGrossPay() của lớp con
                total += employee.CalculateGrossPay();
            }

            return total;
        }


        // ==============================
        // TÍNH TỔNG THEO PHÒNG BAN
        // ==============================

        public double CalculatePayrollByDepartment(
            string department)
        {
            double total = 0;

            foreach (Employee employee in employees)
            {
                if (employee.Department == department)
                {
                    total += employee.CalculateGrossPay();
                }
            }

            return total;
        }


        // ==============================
        // TÌM NGƯỜI CÓ THU NHẬP CAO NHẤT
        // ==============================

        public Employee? FindHighestPaidEmployee()
        {
            if (employees.Count == 0)
            {
                return null;
            }

            Employee highestPaid = employees[0];

            foreach (Employee employee in employees)
            {
                if (employee.CalculateGrossPay()
                    > highestPaid.CalculateGrossPay())
                {
                    highestPaid = employee;
                }
            }

            return highestPaid;
        }


        // ==============================
        // HIỂN THỊ BẢNG LƯƠNG
        // ==============================

        public void DisplayPayroll()
        {
            Console.WriteLine();
            Console.WriteLine(
                "==========================================");

            Console.WriteLine(
                $"           BẢNG LƯƠNG - {period}");

            Console.WriteLine(
                "==========================================");

            if (employees.Count == 0)
            {
                Console.WriteLine(
                    "Danh sách nhân viên đang rỗng.");

                return;
            }

            foreach (Employee employee in employees)
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"Loại nhân viên: {employee.GetEmployeeType()}");

                Console.WriteLine(
                    "------------------------------------------");

                employee.DisplayPayrollInfo();
            }

            Console.WriteLine();
            Console.WriteLine(
                "==========================================");

            Console.WriteLine(
                $"TỔNG BẢNG LƯƠNG: " +
                $"{CalculateTotalPayroll():N0} VNĐ");

            Console.WriteLine(
                "==========================================");
        }
    }
}