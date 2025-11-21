---
title: "使用 Open XML SDK 在 .NET 中提取 PPT、PPTX 和 ODP 文件文本的方法"
linktitle: Open XML SDK
type: docs
weight: 20
url: /zh/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- 云平台
- 云集成
- Open XML SDK
- PPTX 文本提取
- .NET 幻灯片处理
- 演示文稿文本提取
- 母版幻灯片
- 讲稿备注
- 从幻灯片提取文本
- C#
description: "了解如何在 .NET 中使用 Open XML SDK 提取 PPT、PPTX 和 ODP 文本，包含基于 XML 的访问、性能技巧以及针对云应用的转换解决方案。"
---

# 使用 Open XML SDK 从 PPT、PPTX、ODP 提取文本

## Open XML SDK

**Open XML SDK** 提供了一种高度结构化且高效的方法来从演示文件中提取文本——尤其是遵循 Open XML 标准的 **PPTX**。通过直接访问底层 XML，此 SDK 相比传统方法能够更快且更灵活地处理幻灯片内容。

## 直接 XML 访问

- **直接分析文本**：Open XML SDK 允许您在不渲染幻灯片的情况下从 XML 部分提取文本。
- **结构化元素**：由于文本存储在明确的 XML 标签中，检索和处理更加简便。

### 示例：直接从幻灯片 XML 内容提取文本
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```


## 性能优势

- **更快的提取**：绕过打开 PowerPoint 或其他高级 API 的开销。
- **更低的内存使用**：仅访问相关的 XML 部分，降低资源消耗。
- **无需 Microsoft PowerPoint**：免除额外的安装需求。

### 示例：在不加载完整演示文稿的情况下高效提取文本
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```


## 识别文本元素

### 从演示文稿中提取文本的细节

在从演示文稿中提取文本时，请考虑以下因素：

- **文本可能位于不同部分**：普通幻灯片、母版幻灯片、布局或讲稿备注。
- **默认占位符**：母版幻灯片和布局可能包含占位符（例如 “Click to edit Master title style”），这些并非实际的演示内容。
- **过滤空白或隐藏文本**：某些元素可能为空或不打算显示。

### 包含文本的标签

在 **PPTX** 文件中，文本通常存储于：

- `<a:t>` 元素位于 `<a:p>`（段落）中
- `<a:r>` 元素（段落内的文本片段）

### 示例：从幻灯片提取所有文本元素
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## ODP 与 PPT

### 直接提取文本的限制

- 与 **PPTX** 不同，Open XML SDK **不支持** **PPT**（二进制格式）和 **ODP**（OpenDocument 演示文稿）。
- **PPT** 将内容存储为封闭的二进制格式，使文本提取变得复杂。
- **ODP** 基于 **OpenDocument XML**，其结构与 PPTX 不同。

### 解决方法：转换为 PPTX

要从 **PPT** 或 **ODP** 提取文本，推荐的做法是：

1. 使用 PowerPoint 或第三方工具 **将 PPT 转换为 PPTX**。
2. 通过 LibreOffice 或 PowerPoint **将 ODP 转换为 PPTX**。
3. 使用 Open XML SDK 从新的 PPTX 中 **提取文本**。

### 示例：通过 LibreOffice 命令行将 ODP 转换为 PPTX
```sh
soffice --headless --convert-to pptx presentation.odp
```


## 支持的平台和框架

- **Windows**：.NET Framework 4.6.1 及以上，.NET Core 2.1+，.NET 5/6/7。
- **Linux/macOS**：.NET Core 2.1+，.NET 5/6/7。
- **云环境**：Microsoft Azure Functions、AWS Lambda（.NET Core）、Docker 容器。
- **与 Office 应用的兼容性**：无需安装 Microsoft Office。
- **支持的编程语言**：Open XML SDK 可与 **C#**、**VB.NET**、**F#** 以及其他 .NET 支持的语言一起使用。

## 结论

利用 **Open XML SDK** 进行 **PPTX 文本提取** 能够兼顾效率与清晰度，而 **PPT 和 ODP** 则需要先进行转换步骤以实现顺畅处理。采用此方法可确保 **高性能**、**灵活性** 和 **广泛兼容性**，适用于现代 .NET 应用程序。