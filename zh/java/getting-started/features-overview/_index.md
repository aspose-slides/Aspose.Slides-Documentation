---
title: 功能概述
type: docs
weight: 104
url: /zh/java/features-overview/
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
- Java
- Aspose.Slides
description: "在评估 Aspose.Slides for Java 之前，请先了解其覆盖的内容：受支持的平台、文件格式、幻灯片渲染以及您可以创建和编辑的内容。"
---
## **概述**

Aspose.Slides for Java 是一个用于创建、读取、编辑、转换和渲染 PowerPoint 与 OpenDocument 演示文稿的类库。它没有自己的用户界面，也不需要 Microsoft PowerPoint 或 Microsoft Office。本文概述了该库的功能范围，并链接到描述各个领域的文章。

## **支持的平台**

Aspose.Slides for Java 是一个单独的 JAR 文件，发布在 Aspose 的 Maven 仓库中，使用 `jdk16` 分类器。它纯粹使用 Java 编写：JAR 中不包含本地库，也不依赖其他包。

- **Java:** Java 8 或更高版本。Aspose.Slides for Java 26.9 及更早版本也可在 Java 6 和 7 上运行，但 26.10 版本不再支持；请参阅[26.9 发布说明](https://releases.aspose.com/slides/zh/java/release-notes/2026/aspose-slides-for-java-26-9-release-notes/)。
- **Operating systems:** 任何带有 Java 运行时的操作系统，如 Windows、Linux 和 macOS。Linux 上必须安装 fontconfig 库以及至少一种字体。

[Installation](/slides/zh/java/installation/) 展示了如何将库添加到项目并列出了 Linux 的先决条件。[System Requirements](/slides/zh/java/system-requirements/) 详细列出了受支持的平台。

## **文件格式和转换**

Aspose.Slides 打开并保存 PPT、PPTX、PPS、POT、PPSX、POTX、PPTM、PPSM、POTM、ODP、OTP、FODP 和 PowerPoint XML 演示文稿。它可以将 PDF 和 HTML 内容导入到幻灯片中，并将演示文稿保存为 PDF、XPS、HTML、HTML5、TIFF、动画 GIF、SWF、Markdown 和 XAML。[Supported File Formats](/slides/zh/java/supported-file-formats/) 列出了每种格式以及对应的读取或写入 API。

|**功能**|**描述**|
| :- | :- |
|[PPT 和 PPTX](/slides/zh/java/ppt-vs-pptx/)|读取和写入二进制 PowerPoint 97-2003 格式以及 Office Open XML 格式。|
|[PPT 转 PPTX 转换](/slides/zh/java/convert-ppt-to-pptx/)|将旧版 PPT 演示文稿转换为 PPTX。|
|[ODP 转 PPTX 转换](/slides/zh/java/convert-odp-to-pptx/)|打开并保存 ODP、OTP 和 FODP 演示文稿，并将 ODP 演示文稿转换为 PPTX。|
|[可移植文档格式 (PDF)](/slides/zh/java/convert-powerpoint-to-pdf/)|导出演示文稿为 PDF，包括 PDF/A 和 PDF/UA 文档。|
|[XML 纸张规范 (XPS)](/slides/zh/java/convert-powerpoint-to-xps/)|导出演示文稿为 XPS 文档。|
|[标记图像文件格式 (TIFF)](/slides/zh/java/convert-powerpoint-to-tiff/)|导出演示文稿为多页 TIFF 图像，每页对应一张幻灯片。|
|[HTML](/slides/zh/java/convert-powerpoint-to-html/)|导出演示文稿为 HTML 和 HTML5。|
|[PDF 和 HTML 导入](/slides/zh/java/import-presentation/)|从 PDF 页面和 HTML 内容创建幻灯片。|

## **演示文稿渲染**

Aspose.Slides 将幻灯片和单个形状渲染为 PNG、JPEG、BMP、GIF、TIFF 和 SVG 图像，并将幻灯片渲染为 EMF 元文件。请参见[Convert Presentation Slides to Images](/slides/zh/java/convert-slide/)、[Render Presentation Slides as SVG Images](/slides/zh/java/render-a-slide-as-an-svg-image/)和[Create Thumbnails of Presentation Shapes](/slides/zh/java/create-shape-thumbnails/)。

## **内容特性**

Aspose.Slides 让您几乎可以创建、读取和修改演示文稿的所有内容：

|**区域**|**您可以执行的操作**|
| :- | :- |
|[幻灯片](/slides/zh/java/presentation-slide/)|添加、克隆、重新排序和删除幻灯片；应用布局和母版；将幻灯片组织到章节中；更改幻灯片大小。|
|[设计](/slides/zh/java/presentation-design/)|设置背景、主题颜色、页眉页脚和字体。|
|[文本](/slides/zh/java/manage-text/)|创建和编辑文本框、段落和文字段落；设置字体、颜色、项目符号和对齐方式；查找和替换文本。|
|[形状](/slides/zh/java/powerpoint-shapes/)|创建自动形状、线条、连接器、组合形状和图片框；设置位置、大小、线条以及实色、渐变或图案填充；通过替代文字查找形状。|
|[表格](/slides/zh/java/powerpoint-table/)，[图表](/slides/zh/java/powerpoint-charts/)，和[SmartArt](/slides/zh/java/powerpoint-smartart/)|创建和编辑表格、Microsoft Office 图表以及 SmartArt 图示。|
|[媒体](/slides/zh/java/manage-media-files/)，[OLE 对象](/slides/zh/java/manage-ole/)，和[ActiveX 控件](/slides/zh/java/activex/)|添加嵌入或链接的音频和视频框，嵌入 OLE 对象，添加、修改或删除 ActiveX 控件。|
|[备注](/slides/zh/java/presentation-notes/)和[评论](/slides/zh/java/presentation-comments/)|添加、读取和编辑演讲者备注和审阅评论。|
|[动画](/slides/zh/java/powerpoint-animation/)和[切换](/slides/zh/java/slide-transition/)|对形状应用动画效果，设置幻灯片切换，并配置放映设置。|
|[安全](/slides/zh/java/presentation-security/)|使用密码加密演示文稿，设置写保护，并使用[数字签名](/slides/zh/java/digital-signature-in-powerpoint/)。|
|[VBA 宏](/slides/zh/java/presentation-via-vba/)|在启用宏的演示文稿中添加、提取和移除 VBA 模块。|
|[属性](/slides/zh/java/presentation-properties/)|读取和编辑文档属性。|

## **常见问题**

**我是否需要在服务器或电脑上安装 Microsoft PowerPoint 才能使用该库？**

不需要。PowerPoint 并非必需；Aspose.Slides 是一个独立的引擎，用于创建、编辑、转换和渲染演示文稿。

**多线程是如何工作的？可以并行处理吗？**

在不同线程中处理不同文档是安全的；同一个 [Presentation](/reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 对象不能同时被[多个线程](/slides/zh/java/multithreading/)使用。

**是否支持文件密码和加密？**

是的。[您可以](/slides/zh/java/password-protected-presentation/) 打开加密的演示文稿，设置或移除打开和写入密码，并检查保护状态。

**在 Linux 容器中我需要关注字体吗？**

是的。Linux 上必须安装 fontconfig 库以及至少一种字体，并且演示文稿中使用的字体或合适的替代字体必须安装，以确保文本正确渲染。您还可以在应用程序中[指定字体目录](/slides/zh/java/custom-font/)。请参阅[Installation](/slides/zh/java/installation/#linux)。

**评估版是否有限制？**

是的。没有[许可证](/slides/zh/java/licensing/) 时，Aspose.Slides 会在其保存的每张幻灯片上添加评估水印，并截断 API 读取的文本。可使用[30 天临时许可证](https://purchase.aspose.com/temporary-license/)进行完整功能测试。

**是否支持将外部格式导入演示文稿（PDF 或 HTML 转 PPTX）？**

是的。您可以将[PDF 页面和 HTML 内容](/slides/zh/java/import-presentation/)添加到演示文稿中，转换为幻灯片。