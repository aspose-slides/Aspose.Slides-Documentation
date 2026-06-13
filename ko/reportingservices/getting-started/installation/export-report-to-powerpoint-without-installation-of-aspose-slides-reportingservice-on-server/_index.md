---
title: Aspose.Slides.ReportingService를 서버에 설치하지 않고 보고서를 PowerPoint로 내보내기
type: docs
weight: 120
url: /ko/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}} 
Aspose.Slides for Reporting Service는 서버에 설치하지 않고도 사용할 수 있습니다. 이 방법은 애플리케이션에 PowerPoint 내보내기를 통합해야 하지만 서비스에 대한 접근이 제한된 경우에 적합합니다.
{{% /alert %}} {{% alert color="primary" %}} 
이 접근 방식을 설명하는 Visual Studio 솔루션은 [여기](attachments/10289165/10453062.zip)에서 찾을 수 있습니다.
{{% /alert %}} 
렌더링 프로세스는 두 부분으로 구성됩니다:

1. Reporting Service 웹 서비스를 사용하여 보고서를 RPL로 렌더링합니다. Reporting Service 웹 서비스에 대한 자세한 내용은 [여기](http://technet.microsoft.com/en-us/library/ms152787.aspx)에서 확인하십시오.
2. Aspose.Slides for Reporting 서비스(ReportViewer용)를 사용하여 RPL을 PowerPoint로 렌더링합니다. 어셈블리는 {Aspose.Slides for Reporting Services home directory}\bin\RV2010에 위치합니다.

## **PowerPoint 내보내기 구현 방법:**
1) 웹 서비스 프록시를 생성합니다(자세한 내용은 [여기](http://technet.microsoft.com/en-us/library/ms155134.aspx)에서 확인하십시오) 그리고 솔루션에 추가합니다.

2) ReportViewer 2010용 Aspose.Slides.ReportingServices.dll에 대한 참조를 추가합니다.

3) 이 클래스를 사용하여 웹 서비스 프록시와 Aspose.Slides for Reporting Service를 통합합니다.

``` xml
 class PowerpointRenderer
{
/// <summary>
/// 클라이언트가 요청하는 XML 웹 서비스의 기본 URL을 가져오거나 설정합니다.
/// </summary>
/// <value>
/// 클라이언트가 요청하는 XML 웹 서비스의 기본 URL입니다. 기본값은 System.String.Empty입니다.
/// </value>
public string ReportingServiceUrl { get; set; }

/// <summary>
/// Reporting Service에 대한 사용자 이름을 가져오거나 설정합니다.
/// </summary>
/// <value>
/// 사용자 이름입니다.
/// </value>
public string Username { get; set; }

/// <summary>
/// Reporting Service에 대한 비밀번호를 가져오거나 설정합니다.
/// </summary>
/// <value>
/// 비밀번호입니다.
/// </value>
public string Password { get; set; }

/// <summary>
/// 지정된 보고서를 파일로 렌더링합니다.
/// </summary>
/// <param name="outputFileName">출력 파일의 이름.</param>
/// <param name="reportPath">보고서 경로.</param>
/// <param name="format">출력 프레젠테이션 형식.</param>
public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)
{
using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))
{
Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
//start rendering process
//here we are choosing to export in PPT format and providing outputStream
renderer.StartRendering(format, false);
int page = 1;
//this cycle iterates through all pages of report
while (true)
{
using (MemoryStream rplStream = CreateRplStream(page, reportPath))
{
 //if rplStream is empty then we reached end of report
 if (rplStream.Length == 0)
 break;
 //add report page as slide to the document
 renderer.RenderPage(rplStream);
}
page++;
}
//call finish method to flush our newly created presentation to output stream
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

4) 이제 다음 코드를 사용하여 보고서를 내보낼 수 있습니다:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 
여기서 내보내기 프로세스는 Word 또는 Excel과 유사한 부드러운 페이지 구분을 사용하므로, 표준 방법으로 내보낸 프레젠테이션과 결과가 다를 수 있습니다.
{{% /alert %}}