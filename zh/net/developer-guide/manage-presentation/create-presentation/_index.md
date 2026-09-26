---
title: 在 .NET 中创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/net/create-presentation/
keywords:
- 创建演示文稿
- 新建演示文稿
- 创建 PPT
- 新建 PPT
- 创建 PPTX
- 新建 PPTX
- 创建 ODP
- 新建 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中创建演示文稿——生成 PPT、PPTX 和 ODP 文件，受益于 OpenDocument 支持，并以编程方式保存以获得可靠的结果。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中创建演示文稿、在其第一张幻灯片上添加文本框，并将结果另存为文件。它还展示了如何创建并保存空白演示文稿，以及如何打开已支持格式的现有演示文稿并将其另存为其他格式。文末的简短 FAQ 涵盖了有关格式、模板、幻灯片尺寸、单位、内存使用、线程、授权、数字签名和 VBA 支持的常见问题。

在开始之前，请从 NuGet 将 Aspose.Slides 添加到项目中。有关在 Windows、Linux 和 macOS 上使用的包，请参阅[Installation](/slides/zh/net/installation/)。

## **创建 PowerPoint 演示文稿**

要创建演示文稿并在其第一张幻灯片上放置文本框，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。新演示文稿已经包含一张空幻灯片。
1. 通过索引 0 从 [Slides](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/slides/zh/) 集合中获取该幻灯片。
1. 使用 [AddAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addautoshape/) 方法添加矩形并设置其 [text](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/text/)。
1. 使用 [Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/) 方法将演示文稿保存为 PPTX 文件。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

矩形的左上角距幻灯片左边缘 50 点，距顶部 50 点，矩形宽 400 点，高 100 点。保存的文件包含一张包含该矩形及其文本的幻灯片。若未授权，Aspose.Slides 还会在每个保存的幻灯片上添加评估水印；请参阅[Licensing](/slides/zh/net/licensing/)。

## **创建并保存演示文稿**

<a name="csharp-create-save-presentation"></a>

要创建空白演示文稿并保存它，请创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例，并使用 [SaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/) 枚举的任意格式进行保存。结果是一个包含一张空幻灯片的演示文稿。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **打开并保存演示文稿**

<a name="csharp-open-save-presentation"></a>

要将演示文稿从一种格式转换为另一种格式，可通过将其路径传递给 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/presentation/) 构造函数来打开它，然后保存为目标格式。Aspose.Slides 会根据文件本身检测输入格式，例如 PPT、PPTX 或 ODP。

下面的示例假设工作目录中有名为 *Sample.odp* 的 OpenDocument 演示文稿，并将其保存为 PPTX。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **常见问题**

### 可以将新演示文稿保存为何种格式？

您可以保存为 [PPTX、PPT 和 ODP](/slides/zh/net/save-presentation/)，并导出为 [PDF](/slides/zh/net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/net/convert-powerpoint-to-xps/)、[HTML](/slides/zh/net/convert-powerpoint-to-html/)、[SVG](/slides/zh/net/render-a-slide-as-an-svg-image/) 和 [images](/slides/zh/net/convert-powerpoint-to-png/)，等等。

### 我可以从模板 (POTX/POTM) 开始并保存为普通 PPTX 吗？

是的。加载模板后保存为所需格式；POTX/POTM/PPTM 等类似格式 [受支持](/slides/zh/net/supported-file-formats/)。

### 创建演示文稿时，如何控制幻灯片尺寸/纵横比？

设置 [slide size](/slides/zh/net/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

### 尺寸和坐标以何种单位测量？

以点为单位：1 英寸等于 72 点。

### 如何处理包含大量媒体文件的超大型演示文稿以降低内存使用？

使用 [BLOB management strategies](/slides/zh/net/manage-blob/)，通过临时文件限制内存存储，并优先使用基于文件的工作流而非纯内存流。

### 我可以并行创建/保存演示文稿吗？

不能在 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例上从 [multiple threads](/slides/zh/net/multithreading/) 进行操作。请为每个线程或进程运行独立的实例。

### 如何去除试用水印和限制？

在每个进程中 [Apply a license](/slides/zh/net/licensing/) 一次。许可证 XML 必须保持未修改，并且若有多个线程，应同步许可证设置。

### 我可以对创建的 PPTX 进行数字签名吗？

可以。[Digital signatures](/slides/zh/net/digital-signature-in-powerpoint/)（添加和验证）在演示文稿中受支持。

### 在创建的演示文稿中是否支持宏 (VBA)？

是的。您可以 [create/edit VBA projects](/slides/zh/net/presentation-via-vba/) 并保存为支持宏的文件，如 PPTM/PPSM。