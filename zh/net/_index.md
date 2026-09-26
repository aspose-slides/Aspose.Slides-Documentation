---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /zh/net/
keywords:
- 文档
- 演示文稿处理
- 演示文稿转换
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "从这里开始：安装 Aspose.Slides for .NET，创建第一个演示文稿，查找常见任务指南、API 参考和支持。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET 是一个类库，用于在 .NET 应用程序中创建、读取、编辑和转换 PowerPoint 和 OpenDocument 演示文稿，无需 Microsoft PowerPoint 或 Office 自动化。

它支持加载和保存 PPT、PPTX、PPS、POT 和 ODP，包括宏启用和模板变体，并可导出为 PDF、XPS、HTML、SVG、TIFF、Markdown 和图像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>入门</b></p>
<hr>
<p>快速开始</p>
<ul>
<li><a href="/slides/zh/net/installation/">安装</a></li>
<li><a href="/slides/zh/net/create-presentation/">创建您的第一个演示文稿</a></li>
<li><a href="/slides/zh/net/getting-started/">快速入门指南</a></li>
</ul>
<p>评估</p>
<ul>
<li><a href="/slides/zh/net/supported-file-formats/">支持的文件格式</a></li>
<li><a href="/slides/zh/net/evaluate-aspose-slides/">试用限制</a></li>
<li><a href="/slides/zh/net/licensing/">授权</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 构建</b></p>
<hr>
<p>常见任务</p>
<ul>
<li><a href="/slides/zh/net/open-presentation/">打开演示文稿</a></li>
<li><a href="/slides/zh/net/save-presentation/">保存演示文稿</a></li>
<li><a href="/slides/zh/net/convert-powerpoint-to-pdf/">转换为 PDF</a></li>
<li><a href="/slides/zh/net/convert-slide/">将幻灯片渲染为图像</a></li>
<li><a href="/slides/zh/net/manage-text/">编辑文字和形状</a></li>
</ul>
<p>Slides 工作流</p>
<ul>
<li><a href="/slides/zh/net/powerpoint-charts/">图表</a></li>
<li><a href="/slides/zh/net/powerpoint-animation/">动画</a></li>
<li><a href="/slides/zh/net/manage-media-files/">音频和视频</a></li>
<li><a href="/slides/zh/net/presentation-design/">幻灯片设计</a></li>
<li><a href="/slides/zh/net/merge-presentation/">合并演示文稿</a></li>
</ul>
<p>示例</p>
<ul>
<li><a href="/slides/zh/net/examples/">按幻灯片元素划分的示例</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">GitHub 示例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>参考与支持</b></p>
<hr>
<p>参考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/zh/net/">API 参考</a></li>
<li><a href="https://releases.aspose.com/slides/zh/net/release-notes/">发行说明</a></li>
<li><a href="/slides/zh/net/known-issues/">已知问题</a></li>
<li><a href="https://releases.aspose.com/slides/zh/net/">下载</a></li>
</ul>
<p>支持</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/zh/11">免费支持论坛</a></li>
<li><a href="https://helpdesk.aspose.com/">付费支持帮助台</a></li>
</ul>
</div>
</div>

------

## **您的第一个演示文稿**

使用 .NET SDK 6 或更高版本创建一个控制台应用程序：

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

然后为您的平台添加相应的包：

- 在 Windows 上：`dotnet add package Aspose.Slides.NET`
- 在 Linux 和 macOS 上：`dotnet add package Aspose.Slides.NET6.CrossPlatform` — 请参阅 [安装](/slides/zh/net/installation/) 了解 Linux 前置条件以及需要 Aspose.Slides.NET 的系统。

将 *Program.cs* 的内容替换为以下代码并运行 `dotnet run`：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

该程序将 *hello.pptx* 保存为包含一个文本框的单张幻灯片。未授权时，保存的文件会带有评估水印 — 请参阅 [授权](/slides/zh/net/licensing/)。欲了解更多创建和填充演示文稿的方法，请参阅 [创建演示文稿](/slides/zh/net/create-presentation/)。