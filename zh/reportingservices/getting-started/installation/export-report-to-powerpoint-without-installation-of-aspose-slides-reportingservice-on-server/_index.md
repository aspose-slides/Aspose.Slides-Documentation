```
---
title: 在服务器上无须安装 Aspose.Slides.ReportingService 导出报告为 Powerpoint
type: docs
weight: 120
url: /reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---

{{% alert color="primary" %}} 

Aspose.Slides for Reporting Service 可以在服务器上无须安装而使用。当您需要将导出 Powerpoint 集成到应用程序中，但访问服务受到限制时，这种方法是合适的。

{{% /alert %}} {{% alert color="primary" %}} 

说明该方法的 Visual Studio 解决方案可以在 [这里](attachments/10289165/10453062.zip) 找到。

{{% /alert %}} 

渲染过程包括两个部分：

1. 使用 Reporting Service Web Service 将报告渲染为 RPL。有关 Reporting Service Web Service 的更多信息，请参见 [这里](http://technet.microsoft.com/en-us/library/ms152787.aspx)。
2. 使用 Aspose.Slides for Reporting service for ReportViewer 将 RPL 渲染为 Powerpoint。该程序集位于 ﻿﻿﻿﻿﻿{Aspose.Slides for Reporting Services home directory}\bin\RV2010  
## **如何实现导出到 PowerPoint：**
1) 创建 Web 服务代理（详细信息请见 [这里](http://technet.microsoft.com/en-us/library/ms155134.aspx)）并将其添加到您的解决方案中。

2) 为 ReportViewer 2010 添加对 Aspose.Slides.ReportingServices.dll 的引用。

3) 使用此类将 Web 服务代理与 Aspose.Slides for Reporting Service 集成。

``` xml

 class PowerpointRenderer

{

/// <summary>

/// 获取或设置客户端请求的 XML Web 服务的基本 URL。

/// </summary>

/// <value>

/// 客户端请求的 XML Web 服务的基本 URL。默认值为 System.String.Empty。

/// </value>

public string ReportingServiceUrl { get; set; }


/// <summary>

/// 获取或设置 Reporting Service 的用户名。

/// </summary>

/// <value>

/// 用户名。

/// </value>

public string Username { get; set; }

/// <summary>

/// 获取或设置 Reporting Service 的密码。

/// </summary>

/// <value>

/// 密码。

/// </value>

public string Password { get; set; }

/// <summary>

/// 将指定报告渲染为文件。

/// </summary>

/// <param name="outputFileName">输出文件的名称。</param>

/// <param name="reportPath">报告路径。</param>

/// <param name="format">输出演示文稿格式。</param>

public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

//开始渲染过程

//在这里我们选择以 PPT 格式导出并提供输出流

renderer.StartRendering(format, false);

int page = 1;

//此循环遍历报告的所有页面

while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//如果 rplStream 为空，则我们已达到报告的末尾

if (rplStream.Length == 0)

break;

//将报告页面作为幻灯片添加到文档中

renderer.RenderPage(rplStream);

}

page++;

}

//调用 finish 方法将我们新创建的演示文稿刷新到输出流

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

4) 现在您可以通过以下代码导出报告：

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "用户名";

powerpointRenderer.Password = "密码";

powerpointRenderer.Render("test.ppt", "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 

此处的导出过程使用类似于 Word 或 Excel 的软分页，因此其结果可能与使用标准方法导出的演示文稿不同。

{{% /alert %}}
```