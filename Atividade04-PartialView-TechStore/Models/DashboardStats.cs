namespace AulaPartialView.Models;

public class DashboardStats
{
    public int TotalUsers { get; set; }
    public int ActiveSessions { get; set; }
    public decimal MonthlyRevenue { get; set; }
    public string LastUpdated { get; set; } = string.Empty;
}
