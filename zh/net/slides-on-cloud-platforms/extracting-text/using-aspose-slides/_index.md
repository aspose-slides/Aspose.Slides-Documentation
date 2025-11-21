---
title: "如何使用 Aspose.Slides 从 PPT、PPTX 和 ODP 中提取文本"
linktitle: 幻灯片
type: docs
weight: 30
url: /zh/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- 云平台
- 云集成
- 文本提取
- 提取文本
- PPT
- PPTX
- ODP
- 演示文稿文件
- 跨平台
- 独立于 Office
- 备注和批注
- 企业索引
- 数据丰富
- .NET
- Aspose.Slides
description: "使用 Aspose.Slides API 从流行的云平台上的演示文稿中提取文本，实现 PPT、PPTX 和 ODP 的搜索、分析和导出自动化。"
---

# 从 PPT、PPTX 和 ODP 中提取文本 – Slides

Aspose.Slides 提供了 **功能强大的高级 API**，用于从演示文稿文件中提取文本，支持 **PPT、PPTX 和 ODP**。不同于仅支持 PPTX 并且需要复杂 XML 解析的 Open XML SDK，Aspose.Slides 简化了文本提取过程，让您可以专注于将提取的内容集成到工作流中。

## 使用 PresentationFactory.Instance.GetPresentationText 快速提取文本

要从演示文稿中提取文本，**Aspose.Slides API** 提供了静态方法 `PresentationFactory.Instance.GetPresentationText`。该方法有多个重载，可处理演示文稿文件或数据流，捕获来自 **幻灯片、母版幻灯片、布局、备注和批注** 的文本。提取的文本通过 `IPresentationText` 接口访问。

示例用法：
```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```


## GetPresentationText 的操作模式

`PresentationFactory` 中的 `GetPresentationText` 方法允许使用 `TextExtractionArrangingMode` 参数微调文本提取方式，控制输出中文本的组织方式。

### 可用模式：

- **TextExtractionArrangingMode.Unarranged** – 以自由形式提取文本，忽略原始幻灯片布局。  
- **TextExtractionArrangingMode.Arranged** – 按每张幻灯片上的布局顺序保留文本顺序。

使用示例：
```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```


## PresentationFactory 方法的主要优势

- **无需加载整个演示文稿**：降低内存消耗并提升处理速度。  
- **针对大文件进行优化**：高效处理大型演示文稿，快速提取文本。  
- **检索备注和批注**：包含用户注释，实现内容的完整覆盖。  
- **适用于索引和内容分析**：完美满足企业系统的自动化处理和数据丰富需求。  
- **无需 Office 环境**：无需安装 Microsoft PowerPoint，即可独立运行。  
- **多格式支持**：无缝兼容 **PPT、PPTX 和 ODP**。  
- **灵活且强大的 API**：提供多种方法，实现结构化文本提取。  
- **完整的幻灯片覆盖**：提取 **布局、母版幻灯片、标准幻灯片、背景、演讲者备注和批注** 中的文本。  
- **跨平台兼容性**：可在 **Windows、Linux、macOS** 以及云环境中运行。  
- **高性能和可伸缩性**：适用于 **SaaS 应用** 和大规模企业部署。

## 支持的操作系统

Aspose.Slides 可在多种操作系统上运行：

- **Windows**（如 Windows 7、8、10、11 以及 Server 版）  
- **Linux**（各种发行版，包括 Ubuntu、Debian、Fedora、CentOS 等）  
- **macOS**（包括现代版本如 10.15 Catalina 及更高版本）  

## 支持的编程语言

Aspose.Slides 可与多平台和语言集成：

- **C#** – 主要通过 Aspose.Slides for .NET 提供支持。  
- **Java** – Aspose.Slides for Java 提供完整功能 API。  
- **C++** – 在性能关键的 C++ 应用中使用 Aspose.Slides。  
- **Python via .NET** – 通过 .NET 互操作性将 Aspose.Slides 功能集成到 Python 中。  
- **其他 .NET 兼容语言** – 在任何受 .NET 支持的环境中使用该库。

## 结论

Aspose.Slides 为 PowerPoint 和 OpenDocument 演示文稿提供 **全面的文本提取**，支持 **多种文件格式、直观的文本结构化以及相较于 Open XML SDK 更简便的实现**。无论是 **幻灯片、备注还是模板内容**，**Aspose.Slides** 都是高效、功能丰富的演示文稿文本提取与管理解决方案。