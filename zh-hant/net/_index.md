---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /zh-hant/net/
keywords:
- 文件說明
- 簡報處理
- 簡報轉換
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "從這裡開始：安裝 Aspose.Slides for .NET，建立第一個簡報，並找尋常見任務、部署以及 API 參考的指南。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET 是一個類別庫，用於在 .NET 應用程式中建立、讀取、編輯和轉換 PowerPoint 與 OpenDocument 簡報，無需 Microsoft PowerPoint 或 Office 自動化。

它可載入與保存 PPT、PPTX、PPS、POT 以及 ODP，包含巨集啟用和範本變體，並匯出為 PDF、XPS、HTML、SVG、TIFF、Markdown 與圖像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始使用</b></p>
<hr>
<p>開始上手</p>
<ul>
<li><a href="/slides/zh-hant/net/installation/">安裝</a></li>
<li><a href="/slides/zh-hant/net/create-presentation/">建立您的第一個簡報</a></li>
<li><a href="/slides/zh-hant/net/system-requirements/">系統需求</a></li>
<li><a href="/slides/zh-hant/net/getting-started/">入門指南</a></li>
</ul>
<p>評估</p>
<ul>
<li><a href="/slides/zh-hant/net/supported-file-formats/">支援的檔案格式</a></li>
<li><a href="/slides/zh-hant/net/features-overview/">功能概覽</a></li>
<li><a href="/slides/zh-hant/net/evaluate-aspose-slides/">試用限制</a></li>
<li><a href="/slides/zh-hant/net/licensing/">授權方式</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 建置</b></p>
<hr>
<p>常見任務</p>
<ul>
<li><a href="/slides/zh-hant/net/open-presentation/">開啟簡報</a></li>
<li><a href="/slides/zh-hant/net/save-presentation/">儲存簡報</a></li>
<li><a href="/slides/zh-hant/net/convert-powerpoint-to-pdf/">轉換為 PDF</a></li>
<li><a href="/slides/zh-hant/net/convert-slide/">將投影片渲染為圖像</a></li>
<li><a href="/slides/zh-hant/net/manage-text/">編輯文字與圖形</a></li>
</ul>
<p>Slides 工作流程</p>
<ul>
<li><a href="/slides/zh-hant/net/powerpoint-charts/">圖表</a></li>
<li><a href="/slides/zh-hant/net/powerpoint-animation/">動畫</a></li>
<li><a href="/slides/zh-hant/net/manage-media-files/">音訊與影片</a></li>
<li><a href="/slides/zh-hant/net/presentation-design/">投影片設計</a></li>
<li><a href="/slides/zh-hant/net/merge-presentation/">合併簡報</a></li>
</ul>
<p>範例</p>
<ul>
<li><a href="/slides/zh-hant/net/examples/">依投影片元素的範例</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">GitHub 上的範例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>部署與支援</b></p>
<hr>
<p>部署</p>
<ul>
<li><a href="/slides/zh-hant/net/net6/">跨平台 (.NET 6+)</a></li>
<li><a href="/slides/zh-hant/net/how-to-run-aspose-slides-in-docker/">在 Docker 中執行</a></li>
<li><a href="/slides/zh-hant/net/deploy-fonts/">字型</a></li>
<li><a href="/slides/zh-hant/net/security/">安全性</a></li>
</ul>
<p>參考文件</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">API 參考</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">版本說明</a></li>
<li><a href="/slides/zh-hant/net/known-issues/">已知問題</a></li>
<li><a href="/slides/zh-hant/net/api-limitations/">輸出中繼資料限制</a></li>
<li><a href="https://releases.aspose.com/slides/net/">下載</a></li>
</ul>
<p>支援</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免費支援論壇</a></li>
<li><a href="https://helpdesk.aspose.com/">付費支援服務台</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **您的第一個投影片**

使用 .NET SDK 6 或更高版本建立一個主控台應用程式：

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

然後為您的平台加入一個套件：

- 在 Windows 上: `dotnet add package Aspose.Slides.NET`
- 在 Linux 和 macOS 上: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — 請參閱[安裝](/slides/zh-hant/net/installation/) 了解 Linux 的先決條件，以及哪些系統需要使用 Aspose.Slides.NET。

將 *Program.cs* 的內容取代為以下程式碼，然後執行 `dotnet run`：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

此程式會儲存一個包含文字方塊的單一投影片至 *hello.pptx*。若未取得授權，儲存的檔案會帶有評估水印 — 請參閱[授權方式](/slides/zh-hant/net/licensing/)。欲了解更多建立與填充簡報的方法，請參閱[建立簡報](/slides/zh-hant/net/create-presentation/)。