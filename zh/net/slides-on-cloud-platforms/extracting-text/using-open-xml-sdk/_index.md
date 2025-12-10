---
title: "如何使用 .NET 中的 Open XML SDK 从 PPT、PPTX 和 ODP 文件中提取文本"
linktitle: "Open XML SDK"
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
- 讲者备注
- 从幻灯片中提取文本
- C#
description: "了解如何使用 Open XML SDK 在 .NET 中从 PPT、PPTX 和 ODP 提取文本，包含基于 XML 的访问、性能技巧以及针对云应用的转换解决方案。"
---

## **Open XML SDK**

**Open XML SDK** 提供了一种高度结构化且高效的方法来从演示文件中提取文本——尤其是符合 Open XML 标准的 **PPTX**。通过直接访问底层 XML，该 SDK 能够比传统方法更快、更灵活地处理幻灯片内容。

## **Direct XML Access**

- **直接分析文本**：Open XML SDK 允许您从 XML 部分中提取文本，而无需渲染幻灯片。
- **结构化元素**：由于文本存储在定义明确的 XML 标记中，检索和处理更为简便。

### **Example: Extracting Text Directly from Slide XML Content**
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


## **Performance Advantages**

- **更快的提取**：绕过打开 PowerPoint 或其他高级 API 的开销。
- **更低的内存使用**：仅访问相关的 XML 部分，减少资源消耗。
- **无需 Microsoft PowerPoint**：免除额外的安装需求。

### **Example: Efficiently Extracting Text Without Loading the Entire Presentation**
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


## **Identifying Text Elements**

### **Specifics of Extracting Text from Presentations**

在从演示文稿中提取文本时，需要考虑以下因素：

- **文本可能位于不同的部分**：普通幻灯片、母版幻灯片、布局或演讲者备注。
- **默认占位符**：母版幻灯片和布局可能包含占位符（例如 “Click to edit Master title style”），这些并非实际的演示内容。
- **过滤空白或隐藏的文本**：某些元素可能为空或不打算显示。

### **Tags Containing Text**

在 **PPTX** 文件中，文本通常存储在：
- `<a:t>` 元素位于 `<a:p>`（段落）内部
- `<a:r>` 元素（段落内的文本片段）

### **Example: Extracting All Text Elements from a Slide**
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## **ODP and PPT**

### **Inability to Extract Text Directly**

- 与 **PPTX** 不同，**PPT**（二进制格式）和 **ODP**（OpenDocument 演示文稿） **不受 Open XML SDK 支持**。
- **PPT** 将内容存储在封闭的二进制格式中，增加了文本提取的难度。
- **ODP** 使用 **OpenDocument XML**，其结构与 PPTX 不同。

### **Workaround: Converting to PPTX**

要从 **PPT** 或 **ODP** 中提取文本，推荐的做法是：

1. 使用 PowerPoint 或第三方工具 **将 PPT → PPTX** 转换。  
2. 通过 LibreOffice 或 PowerPoint **将 ODP → PPTX** 转换。  
3. 使用 Open XML SDK 从新生成的 PPTX 中 **提取文本**。

### **Example: Converting ODP to PPTX via LibreOffice Command Line**
```sh
soffice --headless --convert-to pptx presentation.odp
```


## **Supported Platforms and Frameworks**

- **Windows**：.NET Framework 4.6.1 及以上，.NET Core 2.1+，.NET 5/6/7。
- **Linux/macOS**：.NET Core 2.1+，.NET 5/6/7。
- **云环境**：Microsoft Azure Functions、AWS Lambda（.NET Core）、Docker 容器。
- **与 Office 应用的兼容性**：无需安装 Microsoft Office。
- **支持的编程语言**：Open XML SDK 可与 **C#**、**VB.NET**、**F#** 以及其他 .NET 支持的语言一起使用。

## **Conclusion**

利用 **Open XML SDK** 进行 **PPTX 文本提取** 能够实现高效且清晰的处理，而 **PPT 和 ODP** 则需要先进行转换步骤才能顺利操作。采用此方法可确保 **高性能**、**灵活性**以及与现代 .NET 应用的 **广泛兼容性**。