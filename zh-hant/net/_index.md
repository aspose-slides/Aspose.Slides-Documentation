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
description: "從此開始：安裝 Aspose.Slides for .NET，建立第一個簡報，並找到常見任務的指南、API 參考與支援。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET 是一個類別庫，用於在 .NET 應用程式中建立、讀取、編輯和轉換 PowerPoint 以及 OpenDocument 簡報，無需 Microsoft PowerPoint 或 Office 自動化。

它可載入並儲存 PPT、PPTX、PPS、POT 與 ODP，包括支援巨集和範本的變體，並可匯出為 PDF、XPS、HTML、SVG、TIFF、Markdown 以及影像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始使用</b></p>
<hr>
<p>入門指南</p>
<ul>
<li><a href="/slides/zh-hant/net/installation/">安裝</a></li>
<li><a href="/slides/zh-hant/net/create-presentation/">建立您的第一個簡報</a></li>
<li><a href="/slides/zh-hant/net/getting-started/">入門指南</a></li>
</ul>
<p>評估</p>
<ul>
<li><a href="/slides/zh-hant/net/supported-file-formats/">支援的檔案格式</a></li>
<li><a href="/slides/zh-hant/net/evaluate-aspose-slides/">試用版限制</a></li>
<li><a href="/slides/zh-hant/net/licensing/">授權</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 構建</b></p>
<hr>
<p>常見任務</p>
<ul>
<li><a href="/slides/zh-hant/net/open-presentation/">開啟簡報</a></li>
<li><a href="/slides/zh-hant/net/save-presentation/">儲存簡報</a></li>
<li><a href="/slides/zh-hant/net/convert-powerpoint-to-pdf/">轉換為 PDF</a></li>
<li><a href="/slides/zh-hant/net/convert-slide/">將投影片渲染為影像</a></li>
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
<p><b>參考與支援</b></p>
<hr>
<p>參考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/zh-hant/net/">API 參考</a></li>
<li><a href="https://releases.aspose.com/slides/zh-hant/net/release-notes/">發行說明</a></li>
<li><a href="/slides/zh-hant/net/known-issues/">已知問題</a></li>
<li><a href="https://releases.aspose.com/slides/zh-hant/net/">下載</a></li>
</ul>
<p>支援</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/zh-hant/11">免費支援論壇</a></li>
<li><a href="https://helpdesk.aspose.com/">付費支援服務台</a></li>
</ul>
</div>
</div>

------

## **您的第一個簡報**

使用 .NET SDK 6 或更新版本建立一個主控台應用程式：

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

然後為您的平台新增一個套件：

- 在 Windows 上：`dotnet add package Aspose.Slides.NET`
- 在 Linux 與 macOS 上：`dotnet add package Aspose.Slides.NET6.CrossPlatform` — 請參閱[Installation](/slides/zh-hant/net/installation/)了解 Linux 的先決條件以及需要改為使用 Aspose.Slides.NET 的系統。

將 *Program.cs* 的內容替換為以下程式碼，然後執行 `dotnet run`：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

此程式會將 *hello.pptx* 儲存為包含一個文字方塊的投影片。若未取得授權，儲存的檔案會帶有評估水印 — 請參閱[Licensing](/slides/zh-hant/net/licensing/)。欲了解更多建立與填充簡報的方式，請參閱[Create Presentations](/slides/zh-hant/net/create-presentation/)。