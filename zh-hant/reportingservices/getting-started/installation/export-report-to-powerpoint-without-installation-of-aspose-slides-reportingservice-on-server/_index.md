---
title: 在伺服器上未安裝 Aspose.Slides.ReportingService 時匯出報表至 PowerPoint
type: docs
weight: 120
url: /zh-hant/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}} 
Aspose.Slides for Reporting Service 可在伺服器上無需安裝即可使用。當您需要在應用程式中整合匯出至 PowerPoint，但對服務的存取受限時，此方法相當適合。
{{% /alert %}} {{% alert color="primary" %}} 
說明此方法的 Visual Studio 解決方案可在[此處](attachments/10289165/10453062.zip)取得。
{{% /alert %}} 
渲染過程包含兩個部分：

1. 使用 Reporting Service Web Service 將報表渲染為 RPL。可於[此處](http://technet.microsoft.com/en-us/library/ms152787.aspx)取得 Reporting Service Web Service 的更多資訊。
1. 使用 Aspose.Slides for Reporting service for ReportViewer 將 RPL 渲染為 PowerPoint。組件位於 {Aspose.Slides for Reporting Services home directory}\bin\RV2010 
## **如何實作匯出至 PowerPoint:** 
 1) 建立 Web 服務代理 (請參閱[此處](http://technet.microsoft.com/en-us/library/ms155134.aspx)的詳細資訊)，並將其加入您的解決方案。
 2) 加入對 Aspose.Slides.ReportingServices.dll 的參考，以支援 ReportViewer 2010。
 3) 使用此類別將 Web 服務代理與 Apose.Slides for Reporting Service 整合
``` xml

 class PowerpointRenderer

{

/// <summary>

/// 取得或設定用戶端請求的 XML Web 服務的基礎 URL。

/// </summary>

/// <value>

/// 用戶端請求的 XML Web 服務的基礎 URL。預設值為 System.String.Empty。

/// </value>

public string ReportingServiceUrl { get; set; }


/// <summary>

/// 取得或設定 Reporting Service 的使用者名稱。

/// </summary>

/// <value>

/// 使用者名稱。

/// </value>

public string Username { get; set; }

/// <summary>

/// 取得或設定 Reporting Service 的密碼。

/// </summary>

/// <value>

/// 密碼。

/// </value>

public string Password { get; set; }

/// <summary>

/// 將指定的報表渲染至檔案。

/// </summary>

/// <param name="outputFileName">輸出檔案的名稱。</param>

/// <param name="reportPath">報表路徑。</param>

/// <param name="format">輸出的簡報格式。</param>

public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

//開始渲染程序

//此處選擇以 PPT 格式匯出並提供 outputStream

renderer.StartRendering(format, false);

int page = 1;

//這個迴圈遍歷報表的所有頁面

while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//如果 rplStream 為空表示已到達報表結尾

if (rplStream.Length == 0)

break;

//將報表頁面加入為投影片到文件中

renderer.RenderPage(rplStream);

}

page++;

}

//呼叫 finish 方法將新建立的簡報寫入輸出串流

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

```
 4) 現在您可以透過以下程式碼匯出報表：
``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```
{{% alert color="primary" %}} 
此處的匯出過程使用類似 Word 或 Excel 的軟分頁換行，因而其結果可能與使用標準方法匯出的簡報不同。
{{% /alert %}}