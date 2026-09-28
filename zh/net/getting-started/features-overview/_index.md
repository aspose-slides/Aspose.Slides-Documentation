---
title: 功能概览
type: docs
weight: 94
url: /zh/net/features-overview/
keywords:
- 功能
- 受支持的平台
- 文件格式
- 转换
- 渲染
- 演示文稿内容
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在评估 Aspose.Slides for .NET 之前，先了解它涵盖的内容：受支持的平台、文件格式、幻灯片渲染，以及您可以创建和编辑的内容。"
---
## **概述**

Aspose.Slides for .NET 是一个类库，用于创建、读取、编辑、转换和渲染 PowerPoint 和 OpenDocument 演示文稿。它没有自己的用户界面，也不需要 Microsoft PowerPoint 或 Office，因此您可以在控制台应用程序、Windows Forms 桌面应用程序、Web 应用程序和 Web 服务中使用它。本文概述了库的功能范围，并链接到描述各个领域的文章。

## **支持的平台**

Aspose.Slides for .NET 以两个具有相同 API 的 NuGet 包发布：

|**包**|**包中包含的构建**|**操作系统**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2、.NET Standard 2.0 和 .NET 6。可在 .NET Framework 4.6.2 或更高版本，或 .NET 6 或更高版本上使用。|Windows。Linux 和 macOS 需要 `libgdiplus` 库以及 `System.Drawing.EnableUnixSupport` 开关。|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6。可在 .NET 6 或更高版本上使用。|Windows（x86、x64）、Linux（使用 glibc 2.23 或更高的 x64，使用 glibc 2.39 或更高的 ARM64）以及 macOS（x64、ARM64）。|

[安装](/slides/zh/net/installation/) 解释了选择哪个包以及每个包在 Linux 上的需求。[系统要求](/slides/zh/net/system-requirements/) 列出了支持的平台的详细信息。

## **文件格式和转换**

Aspose.Slides 打开并保存 PPT、PPTX、PPS、POT、PPSX、POTX、PPTM、PPSM、POTM、ODP、OTP、FODP 和 PowerPoint XML 演示文稿。它可以将 PDF 和 HTML 内容导入到幻灯片中，并将演示文稿保存为 PDF、XPS、HTML、HTML5、TIFF、动画 GIF、SWF、Markdown 和 XAML。[Supported File Formats](/slides/zh/net/supported-file-formats/) 列出了每种格式以及读取或写入它的 API。

|**功能**|**描述**|
| :- | :- |
|[PPT 和 PPTX](/slides/zh/net/ppt-vs-pptx/)|读取和写入二进制 PowerPoint 97-2003 格式以及 Office Open XML 格式。|
|[PPT 到 PPTX 转换](/slides/zh/net/convert-ppt-to-pptx/)|将旧版 PPT 演示文稿转换为 PPTX。|
|[便携文档格式 (PDF)](/slides/zh/net/convert-powerpoint-to-pdf/)|将演示文稿导出为 PDF，包括 PDF/A 和 PDF/UA 文档。|
|[XML 纸张规范 (XPS)](/slides/zh/net/convert-powerpoint-to-xps/)|将演示文稿导出为 XPS 文档。|
|[标记图像文件格式 (TIFF)](/slides/zh/net/convert-powerpoint-to-tiff/)|将演示文稿导出为 TIFF 图像。|
|[HTML](/slides/zh/net/convert-powerpoint-to-html/)|将演示文稿导出为 HTML 和 HTML5。|
|[PDF 和 HTML 导入](/slides/zh/net/import-presentation/)|从 PDF 页面和 HTML 内容创建幻灯片。|

## **演示文稿渲染**

Aspose.Slides 将幻灯片和单个形状渲染为 PNG、JPEG、BMP、GIF、TIFF 和 SVG 图像，并将幻灯片渲染为 EMF 元文件。请参阅[Convert Presentation Slides to Images](/slides/zh/net/convert-slide/)、[Render a Slide as an SVG Image](/slides/zh/net/render-a-slide-as-an-svg-image/)和[Create Shape Thumbnails](/slides/zh/net/create-shape-thumbnails/)。

## **内容功能**

Aspose.Slides 让您几乎可以创建、读取和修改演示文稿的所有内容：

|**区域**|**您可以执行的操作**|
| :- | :- |
|[幻灯片](/slides/zh/net/presentation-slide/)|添加、克隆、重新排序和删除幻灯片；应用布局和母版；将幻灯片组织到章节中；更改幻灯片尺寸。|
|[设计](/slides/zh/net/presentation-design/)|设置背景、主题颜色、页眉页脚和字体。|
|[文本](/slides/zh/net/manage-text/)|创建和编辑文本框、段落和文本段；设置字体、颜色、项目符号和对齐方式；查找和替换文本。|
|[形状](/slides/zh/net/powerpoint-shapes/)|创建自动形状、线条、连接器、组合形状和图片框；设置位置、大小、线条以及实色、渐变或图案填充；通过备用文本查找形状。|
|[表格](/slides/zh/net/powerpoint-table/), [图表](/slides/zh/net/powerpoint-charts/), and [SmartArt](/slides/zh/net/powerpoint-smartart/)|创建和编辑表格、Microsoft Office 图表以及 SmartArt 图形。|
|[媒体](/slides/zh/net/manage-media-files/), [OLE 对象](/slides/zh/net/manage-ole/), and [ActiveX 控件](/slides/zh/net/activex/)|添加嵌入或链接的音频和视频框，嵌入 OLE 对象，并添加、修改或删除 ActiveX 控件。|
|[备注](/slides/zh/net/presentation-notes/) and [批注](/slides/zh/net/presentation-comments/)|添加、读取和编辑演讲者备注以及审阅批注。|
|[动画](/slides/zh/net/powerpoint-animation/) and [切换](/slides/zh/net/slide-transition/)|对形状应用动画效果，设置幻灯片切换，并配置幻灯片放映设置。|
|[安全](/slides/zh/net/presentation-security/)|使用密码加密演示文稿，设置写保护，并处理数字签名。|
|[VBA 宏](/slides/zh/net/presentation-via-vba/)|在启用宏的演示文稿中添加、提取和移除 VBA 模块。|
|[属性](/slides/zh/net/presentation-properties/)|读取和编辑文档属性。

## **常见问题**

**我是否需要在服务器或电脑上安装 Microsoft PowerPoint 才能使用该库？**

不需要。PowerPoint 并非必需；Aspose.Slides 是一个独立的引擎，用于创建、编辑、转换和渲染演示文稿。

**多线程是如何工作的？可以并行处理吗？**

在不同线程中处理不同文档是安全的；同一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 对象不能同时被 [多个线程](/slides/zh/net/multithreading/) 使用。

**是否支持文件密码和加密？**

是的。[您可以](/slides/zh/net/password-protected-presentation/) 打开受加密的演示文稿，设置或移除打开和写入密码，并检查保护状态。

**在 Linux 容器中需要关注字体吗？**

是的。演示文稿中使用的字体或合适的替代字体必须安装在系统上，才能正确渲染文本。您也可以在应用程序中[指定字体目录](/slides/zh/net/custom-font/)。[安装](/slides/zh/net/installation/) 列出了每个包的 Linux 前置条件。

**评估版是否有限制？**

是的。没有[许可证](/slides/zh/net/licensing/)，Aspose.Slides 会在每个保存的幻灯片上添加评估水印，并截断从演示文稿读取的文本。可使用[30 天临时许可证](https://purchase.aspose.com/temporary-license/)进行完整功能测试。

**是否支持将外部格式导入演示文稿（PDF 或 HTML 转换为 PPTX）？**

是的。您可以将[PDF 页面和 HTML 内容](/slides/zh/net/import-presentation/)添加到演示文稿中，转换为幻灯片。