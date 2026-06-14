---
title: Xuất báo cáo sang Powerpoint mà không cài đặt Aspose.Slides.ReportingService trên máy chủ
type: docs
weight: 120
url: /vi/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}} 
Aspose.Slides for Reporting Service có thể được sử dụng mà không cần cài đặt trên máy chủ. Cách tiếp cận này phù hợp khi bạn cần tích hợp xuất sang Powerpoint trong ứng dụng của mình nhưng quyền truy cập vào dịch vụ bị hạn chế.
{{% /alert %}} {{% alert color="primary" %}} 
Bộ giải pháp Visual Studio minh họa cách tiếp cận có thể được tìm thấy [ở đây](attachments/10289165/10453062.zip).
{{% /alert %}} 
Quá trình render bao gồm hai phần:
1. Render báo cáo sang RPL bằng Reporting Service Web Service. Xem thêm thông tin về Reporting Service Web Service [ở đây](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. Render RPL sang Powerpoint bằng Aspose.Slides for Reporting service cho ReportViewer. Tập tin assembly nằm trong {Aspose.Slides for Reporting Services home directory}\bin\RV2010  
## **Cách triển khai xuất sang PowerPoint:**
 1) Tạo proxy dịch vụ web (xem chi tiết [ở đây](http://technet.microsoft.com/en-us/library/ms155134.aspx)) và thêm nó vào giải pháp của bạn.
 2) Thêm tham chiếu đến Aspose.Slides.ReportingServices.dll cho ReportViewer 2010.
 3) Sử dụng lớp này để tích hợp proxy dịch vụ web và Aspose.Slides for Reporting Service
``` xml
 class PowerpointRenderer
{
/// <summary>
/// Lấy hoặc đặt URL cơ sở của dịch vụ Web XML mà client đang yêu cầu.
/// </summary>
/// <value>
/// URL cơ sở của dịch vụ Web XML mà client đang yêu cầu. Mặc định là System.String.Empty.
/// </value>
public string ReportingServiceUrl { get; set; }

/// <summary>
/// Lấy hoặc đặt tên người dùng cho Reporting Service.
/// </summary>
/// <value>
/// Tên người dùng.
/// </value>
public string Username { get; set; }

/// <summary>
/// Lấy hoặc đặt mật khẩu cho Reporting Service.
/// </summary>
/// <value>
/// Mật khẩu.
/// </value>
public string Password { get; set; }

/// <summary>
/// Render báo cáo đã chỉ định ra tệp.
/// </summary>
/// <param name="outputFileName">Tên của tệp đầu ra.</param>
/// <param name="reportPath">Đường dẫn báo cáo.</param>
/// <param name="format">Định dạng trình chiếu đầu ra.</param>
public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)
{
using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))
{
Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
//bắt đầu quá trình render
//ở đây chúng tôi chọn xuất ở định dạng PPT và cung cấp outputStream
renderer.StartRendering(format, false);
int page = 1;
//vòng lặp này duyệt qua tất cả các trang của báo cáo
while (true)
{
using (MemoryStream rplStream = CreateRplStream(page, reportPath))
{
if (rplStream.Length == 0)
break;
//thêm trang báo cáo làm slide vào tài liệu
renderer.RenderPage(rplStream);
}
page++;
}
//gọi phương thức finish để đẩy bản trình chiếu mới tạo của chúng tôi tới output stream
renderer.FinishRendering(pptSteam);
}
}
private MemoryStream CreateRplStream(int page, string reportPath)
{
ReportExecutionService _executionService = new ReportExecutionService();
_executionService.Url = ReportingServiceUrl + "/ReportExecution2005.asmx";
_executionService.Credentials = new System.Net.NetworkCredential(Username, Password, string.Empty);
string extension;
Warning[] warnings;
string[] streamIds;
string mimeType;
string encoding;
var executionInfo = _executionService.LoadReport(reportPath, null);
string deviceInfo = String.Format(
@"<DeviceInfo>
<StartPage>{0}</StartPage>
<EndPage>{0}</EndPage>
<SecondaryStreams>Embedded</SecondaryStreams>
</DeviceInfo>", page);
byte[] result = _executionService.Render("RPL", deviceInfo, out extension, out mimeType, out encoding, out warnings, out streamIds);
return new MemoryStream(result);
}
}
```
 4) Bây giờ bạn có thể xuất báo cáo bằng đoạn mã sau:
``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```
{{% alert color="primary" %}} 
Quá trình xuất ở đây sử dụng ngắt trang mềm tương tự như Word hoặc Excel, vì vậy kết quả có thể khác so với bản trình chiếu được xuất bằng cách tiếp cận tiêu chuẩn.
{{% /alert %}}