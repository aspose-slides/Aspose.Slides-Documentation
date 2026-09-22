---
title: 确定 .NET 中原始演示文稿格式
linktitle: 源格式
type: docs
weight: 35
url: /zh/net/detect-presentation-source-format/
keywords:
- 源格式
- 检测演示文稿格式
- PowerPoint
- OpenDocument
- 演示文稿
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 C# 中读取已加载演示文稿的原始格式，比较检测 API，并处理文件、流和旧版格式。"
---
## **概述**

加载演示文稿后，读取只读的 [Presentation.SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/sourceformat/) 属性以确定其原始格式。该属性也可通过 [IPresentation.SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/sourceformat/) 访问。当后续处理依赖于当前实例加载时的格式时，请使用它。

源格式不同于为输出文件选择的 [SaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/) 。将文件保存为其他格式不会更改现有实例的源格式。

## **读取文件的源格式**

此示例需要一个现有的 `sample.pptx` 文件。它加载该文件，并使用 [Presentation.SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/sourceformat/) 而不是文件名来选择应用程序的处理策略。更改输入路径以尝试其他格式。示例会打印所选的策略；请将这些消息替换为您的应用程序逻辑。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **识别支持的值**

[SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/sourceformat/) 枚举列出了以下演示文稿格式。下面的扩展名是约定的扩展名，并非对原始文件名的还原。

| SourceFormat 值 | 扩展名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 演示文稿 |
| `Pptx` | `.pptx` | Office Open XML 演示文稿 |
| `Pptm` | `.pptm` | 启用宏的 Office Open XML 演示文稿 |
| `Pps` | `.pps` | PowerPoint 97–2003 幻灯片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 幻灯片放映 |
| `Ppsm` | `.ppsm` | 启用宏的 Office Open XML 幻灯片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 模板 |
| `Potx` | `.potx` | Office Open XML 模板 |
| `Potm` | `.potm` | 启用宏的 Office Open XML 模板 |
| `Odp` | `.odp` | OpenDocument 演示文稿 |
| `Otp` | `.otp` | OpenDocument 演示文稿模板 |
| `Fodp` | `.fodp` | Flat XML ODF 演示文稿 |
| `Xml` | `.xml` | PowerPoint XML 演示文稿 |

## **读取流的源格式**

此示例需要一个现有的 `sample.pps` 文件。将其字节读取到内存流中，模拟没有文件名的输入，例如数据库值或上传的字节数组。[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 构造函数仅接收流。

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT、PPS 和 POT 使用相同的底层二进制格式。通过文件路径加载时，扩展名可帮助区分幻灯片放映或模板。没有文件名时，旧版 PPS 和 POT 内容可能会报告为 `SourceFormat.Ppt`；上面的 PPS 示例报告为 `Ppt`。

如果您的应用程序必须保留此区分，请单独保留原始文件名或子类型元数据。扩展名对这些旧版子类型是有用的提示，但不应作为识别任意演示文稿内容的唯一依据。

## **加载前后比较检测**

在需要在加载完整演示文稿对象模型之前检查文件时，请使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/getpresentationinfo/) 和 [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/loadformat/)。当实例已存在时，请使用 [Presentation.SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/sourceformat/)。

此示例需要 `sample.pptx` 并在两次检查中均打印 `Pptx`。在生产环境中，请根据处理阶段选择适当的 API；已经加载的演示文稿无需再次检查仅为了获取其源格式。

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

结果具有不同的枚举类型：[LoadFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/loadformat/) 和 [SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/sourceformat/)。不要通过转换其数值来比较它们，也不要假设每种格式都有相同的检测结果。在下面描述的保存‑重新打开检查中，PowerPoint XML 在加载前报告为 `LoadFormat.Unknown`，加载后报告为 `SourceFormat.Xml`。

## **保持源格式和输出格式分离**

此示例需要 `sample.pptx` 并写入 `converted.odp`。它在保存原始实例前后都打印 `Pptx`。只有从 ODP 输出加载的新实例报告 `Odp`。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

使用 `new Presentation()` 从头创建的演示文稿报告 `SourceFormat.Pptx`。它没有输入文件：这是新创建实例的默认值，并不表示加载了 PPTX 文件。如果区分创建或加载实例对您的应用程序很重要，请单独跟踪此信息。

## **将源格式映射到扩展名**

以下示例需要 `sample.pptx`。它将每个当前支持的 [SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/sourceformat/) 值映射到约定的扩展名，而无需解析输入文件名。回退机制防止对未识别的值静默分配扩展名。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

此映射不会转换文件或恢复在流加载期间丢失的旧版 PPS/POT 子类型。实际保存时，请显式选择 [SaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/) ，或使用 [/slides/zh/net/save-presentation/#save-presentations-in-their-original-format](/slides/zh/net/save-presentation/#save-presentations-in-their-original-format) 中展示的转换。

## **通过保存和重新打开验证格式**

此独立示例在工作目录中创建一个演示文稿并写入三个文件，使用相同名称的文件会被覆盖。它分别通过路径和内存流重新打开每个输出。对于 PPTX 和 ODP，两种方式都报告已保存的格式。对于 PPS，通过路径加载报告 `Pps`，而在没有文件名的情况下加载相同字节则报告 `Ppt`。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

对上述所有列出的格式进行相同检查，对生成的对应扩展名的演示文稿得到以下结果：

| 保存的格式 | 从文件路径获取的 SourceFormat | 从无名称流获取的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` 分别 | 同文件路径 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` 分别 | 同文件路径 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` 分别 | 同文件路径 |
| ODP, OTP | `Odp`, `Otp` 分别 | 同文件路径 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

在这些检查中，唯一的源格式归一化是对无名称流的 PPS/POT 归为 `Ppt`。此表描述的是格式识别，而非在转换过程中保留每个演示文稿特性的情况。

## **常见问题**

**保存为 ODP 是否会更改从 PPTX 加载的演示文稿的源格式？**

不会。现有实例仍报告 `Pptx`。从已保存的 ODP 文件加载的实例报告 `Odp`。

**流能否始终区分传统演示文稿、幻灯片放映和模板？**

不能。PPT、PPS 和 POT 共享二进制格式。当需要此区分时，请单独保留文件名或子类型元数据。

**如果演示文稿已加载，应该使用哪个 API？**

读取 [Presentation.SourceFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/sourceformat/)。在加载前进行检查时使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/presentationfactory/getpresentationinfo/)。