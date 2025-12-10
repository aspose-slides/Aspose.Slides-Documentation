---
title: "如何使用 Aspose.Slides 从 PPT、PPTX 和 ODP 提取文本"
linktitle: "幻灯片"
type: docs
weight: 30
url: /zh/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- "云平台"
- "云集成"
- "文本提取"
- "提取文本"
- "PPT"
- "PPTX"
- "ODP"
- "演示文稿文件"
- "跨平台"
- "独立于 Office"
- "备注和批注"
- "企业索引"
- "数据增益"
- ".NET"
- "Aspose.Slides"
description: "使用 Aspose.Slides API 在流行的云平台上提取演示文稿文本，实现 PPT、PPTX 和 ODP 的搜索、分析和导出自动化。"
---

## **介绍**

Aspose.Slides 提供了一个 **powerful, high-level API**，用于从演示文稿文件中提取文本，支持 **PPT, PPTX, and ODP**。与仅支持 PPTX 并且需要复杂 XML 解析的 Open XML SDK 不同，Aspose.Slides 简化了文本提取，让您可以专注于将提取的内容集成到工作流中。

## **使用 PresentationFactory.Instance.GetPresentationText 快速提取文本**

要从演示文稿中提取文本，**Aspose.Slides API** 提供了静态方法 `PresentationFactory.Instance.GetPresentationText`。该方法包括多个重载，可用于处理演示文稿文件或数据流，并捕获来自 **slides, master slides, layouts, notes, and comments** 的文本。提取的文本可通过 `IPresentationText` 接口访问。

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


## **GetPresentationText 的操作模式**

`PresentationFactory` 中的 `GetPresentationText` 方法允许您使用 `TextExtractionArrangingMode` 参数微调文本提取，以控制输出中文本的组织方式。

### **可用模式**

- **TextExtractionArrangingMode.Unarranged** – 以自由形式提取文本，忽略原始幻灯片布局。  
- **TextExtractionArrangingMode.Arranged** – 按每张幻灯片上的位置保留文本顺序。

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


## **PresentationFactory 方法的关键优势**

- **No Need to Load Entire Presentations**: 减少内存消耗并提升处理速度。  
- **Optimized for Large Files**: 高效处理大型演示文稿，快速提取文本。  
- **Retrieves Notes and Comments**: 包含用户注释，实现内容的完整覆盖。  
- **Ideal for Indexing and Content Analysis**: 适合需要自动化处理和数据增益的企业系统进行索引和内容分析。  
- **Office-Independent**: 无需安装 Microsoft PowerPoint，即可独立运行。  
- **Multi-Format Support**: 与 **PPT, PPTX, and ODP** 无缝协作。  
- **Flexible, Powerful API**: 提供多样化方法，以结构化方式提取文本。  
- **Complete Slide Coverage**: 从 **layouts, master slides, standard slides, backgrounds, speaker notes, and comments** 中提取文本。  
- **Cross-Platform Compatibility**: 在 **Windows, Linux, macOS** 以及云环境中运行。  
- **High Performance and Scalability**: 适用于 **SaaS applications** 与大规模企业部署。

## **支持的操作系统**

Aspose.Slides 可在多种操作系统上运行：

- **Windows**（例如 Windows 7、8、10、11 以及 Server 版）  
- **Linux**（各种发行版，包括 Ubuntu、Debian、Fedora、CentOS 等）  
- **macOS**（包括现代版本如 10.15 Catalina 及更高）  

## **支持的编程语言**

Aspose.Slides 与多个平台和语言集成：

- **C#** – 主要通过 Aspose.Slides for .NET 提供支持。  
- **Java** – 使用 Aspose.Slides for Java 可获得完整功能的 API。  
- **C++** – 在对性能要求高的 C++ 应用中利用 Aspose.Slides。  
- **Python via .NET** – 通过 .NET 互操作性将 Aspose.Slides 功能集成到 Python 中。  
- **Other .NET-Compatible Languages** – 在任何 .NET 支持的环境中使用此库。  

## **结论**

Aspose.Slides 为 PowerPoint 和 OpenDocument 演示文稿提供 **comprehensive text extraction**，相较于 Open XML SDK，支持 **varied file formats, intuitive text structuring, and straightforward implementation**。无论是 **slides and notes to template content**，**Aspose.Slides** 都是一个高效、功能丰富的文本提取和管理解决方案。