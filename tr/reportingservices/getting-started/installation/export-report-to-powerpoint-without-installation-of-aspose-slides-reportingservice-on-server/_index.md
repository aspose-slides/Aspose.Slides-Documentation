---
title: Aspose.Slides.ReportingService'i sunucuda kurmadan raporu PowerPoint'e dışa aktar
type: docs
weight: 120
url: /tr/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Service, bir sunucuda kurulum gerektirmeden kullanılabilir. Bu yaklaşım, uygulamanıza PowerPoint dışa aktarma işlevi entegre etmeniz gerektiğinde ancak hizmete erişimin sınırlı olduğu durumlarda uygundur.

{{% /alert %}} {{% alert color="primary" %}} 

Yaklaşımı gösteren Visual Studio çözümü [burada](attachments/10289165/10453062.zip) bulunabilir.

{{% /alert %}} 

Render süreci iki bölümden oluşur:  

1. Raporu, Reporting Service Web Service kullanarak RPL formatına render edin. Reporting Service Web Service hakkında daha fazla bilgiye [buradan](http://technet.microsoft.com/en-us/library/ms152787.aspx) ulaşabilirsiniz.  
1. RPL'yi PowerPoint'e, ReportViewer için Aspose.Slides for Reporting Service kullanarak render edin. Assemblies, {Aspose.Slides for Reporting Services home directory}\bin\RV2010 içinde bulunur.  

## **PowerPoint'e Dışa Aktarma Nasıl Uygulanır:**
 1) Web servis vekilini oluşturun (detaylar için [buraya](http://technet.microsoft.com/en-us/library/ms155134.aspx) bakın) ve çözümünüze ekleyin.  

 2) ReportViewer 2010 için Aspose.Slides.ReportingServices.dll referansını ekleyin.  

 3) Bu sınıfı kullanarak web servis vekilini ve Aspose.Slides for Reporting Service'ı entegre edin  

``` xml
 class PowerpointRenderer
{
/// <summary>
/// İstemcinin talep ettiği XML Web hizmetinin temel URL'sini alır veya ayarlar.
/// </summary>
/// <value>
/// İstemcinin talep ettiği XML Web hizmetinin temel URL'si. Varsayılan değer System.String.Empty'dir.
/// </value>
public string ReportingServiceUrl { get; set; }

/// <summary>
/// Reporting Service için kullanıcı adını alır veya ayarlar.
/// </summary>
/// <value>
/// Kullanıcı adı.
/// </value>
public string Username { get; set; }

/// <summary>
/// Reporting Service için şifreyi alır veya ayarlar.
/// </summary>
/// <value>
/// Şifre.
/// </value>
public string Password { get; set; }

/// <summary>
/// Belirtilen raporu dosyaya render eder.
/// </summary>
/// <param name="outputFileName">Çıktı dosyasının adı.</param>
/// <param name="reportPath">Rapor yolu.</param>
/// <param name="format">Çıktı sunum formatı.</param>
public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)
{
using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))
{
Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
//renderleme sürecini başlat
//burada PPT formatında dışa aktarmayı seçiyor ve çıktı akışını sağlıyoruz
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

 4) Artık raporu aşağıdaki kodla dışa aktarabilirsiniz:  

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 

Buradaki dışa aktarma süreci, Word veya Excel'e benzer şekilde yumuşak sayfa sonları kullanır; bu nedenle, standart yaklaşım ile dışa aktarılan sunumdan farklı sonuçlar elde edilebilir.

{{% /alert %}}