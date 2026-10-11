---
title: 更改 .NET 中的备注页尺寸和方向
linktitle: 备注页尺寸
type: docs
weight: 10
url: /zh/net/notes-size/
keywords:
- 备注页尺寸
- 备注方向
- 横向备注
- 纵向备注
- 讲义尺寸
- PowerPoint
- 演示文稿
- PPT
- PPTX
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中读取和更改备注页尺寸，切换方向，验证保存的尺寸，并将备注或讲义导出为 PDF 和图像。"
---
## **概述**

使用 [Presentation.NotesSize](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/notessize/) 来访问演示文稿的备注页设置。它返回一个 [INotesSize](https://reference.aspose.com/slides/zh/net/aspose.slides/inotessize/) 对象，其 [Size](https://reference.aspose.com/slides/zh/net/aspose.slides/inotessize/size/) 属性是可写的。虽然设置对象本身是只读的，但您可以为其 size 属性分配新的尺寸。

宽度和高度使用 **点** 为单位，1 英寸等于 72 点。例如，900 × 600 点等于 12.5 × 8⅓ 英寸。这些设置适用于整个演示文稿，而不是单个幻灯片的备注。

| 设置 | 用途 |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/notessize/) | 控制备注页的尺寸以及用于讲义导出的页面尺寸。 |
| [Presentation.SlideSize](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/slidesize/) | 通过 [ISlideSize](https://reference.aspose.com/slides/zh/net/aspose.slides/islidesize/) 控制常规演示文稿幻灯片的尺寸。 |

更改任意一个设置不会自动更改另一个。更改备注页方向也不会旋转常规幻灯片。请参阅 [Slide Size](/slides/zh/net/slide-size/) 以调整常规幻灯片的大小。

下面的示例使用现有的 `sample.pptx`。对于导出示例，请使用至少包含一张带有演讲者备注的幻灯片的演示文稿。每个示例都可以独立运行。

## **读取备注页尺寸和方向**

读取宽度和高度并进行比较以确定方向：宽的页面为横向，高的页面为纵向，尺寸相等则为方形页面。此示例以点为单位打印实际尺寸，而不假设标准纸张大小。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **在不更改纸张尺寸的情况下切换为横向**

若仅更改方向，只需交换现有的宽度和高度。这会保留两侧的长度，包括自定义纸张尺寸的长度。下面的条件可防止已为横向的页面被切换回纵向，并且保持方形页面不变。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

对于纵向方向，当 `size.Width > size.Height` 时使用相同的赋值。除非您也想更改纸张尺寸，否则不要替换为 A4 或 Letter 尺寸。

## **设置并验证自定义备注页尺寸**

同时分配两个维度，然后使用 [Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/) 将演示文稿写入。此示例将页面设置为 900 × 600 点的横向页面，保存为 PPTX，并再次打开已保存的文件以检查持久化的值。比较时对浮点值允许 0.01 点的容差；这并不保证每种文件格式的精度。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

预期结果是 `900 x 600 points` 和 `Size preserved: True`。检查新打开的演示文稿可验证已保存的文件，而不仅仅是内存中的设置。

## **导出备注和讲义**

页面尺寸定义了备注或讲义布局的可用区域。它们本身并不会启用这些布局：还需配置导出选项。常规幻灯片导出仍使用幻灯片尺寸。

### **导出备注为 PDF 和 PNG**

将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/notescommentslayoutingoptions/) 分配给 [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) 以在 PDF 中包含备注。此示例还使用 [Slide.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage/) 和 [RenderingOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/renderingoptions/) 将带备注的第一张幻灯片渲染为 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh/net/aspose.slides.export/notespositions/) 模式将备注保持在一页上；不适合的备注会被截断。PDF 使用 900 × 600 点的页面。以下使用的 1 × 1 图像比例下，PNG 为 900 × 600 像素。点描述页面几何；像素描述光栅输出，其尺寸还取决于渲染比例。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

对于包含长备注的 PDF 导出，[BottomFull](https://reference.aspose.com/slides/zh/net/aspose.slides.export/notespositions/) 可根据需要添加额外页面。不要在上述单幻灯片图像调用中使用该模式，因为它不支持。调整大小后，检查输出是否有被裁剪的备注以及现有 notes-master 对象的放置；仅更改页面尺寸并不能保证所有内容都能适配。请参阅 [Convert PowerPoint to PDF with Notes](/slides/zh/net/convert-powerpoint-to-pdf-with-notes/) 了解更多有关备注导出的信息。

### **导出讲义为 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/handoutlayoutingoptions/) 在一页上放置多个幻灯片缩略图。以下示例将页面设置为 900 × 600 点，并使用 [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/zh/net/aspose.slides.export/handouttype/) 将每页安排最多四张幻灯片。水平预设控制幻灯片顺序；页面方向取决于其宽度和高度。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

更改页面尺寸会改变讲义网格的可用区域，而不会更改源幻灯片的尺寸。对于讲义图像，请使用带有讲义布局的 [Presentation.GetImages](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/getimages/)，而不是单个幻灯片的图像方法。在 Aspose.Slides 中，演示文稿级别的讲义渲染使用备注页尺寸，而单个幻灯片的图像调用不会生成讲义页面。请参阅 [Handout Mode](/slides/zh/net/convert-powerpoint-in-handout-mode/) 了解布局选项。

## **查看器、导出和打印中的页面尺寸**

保持存储的演示文稿尺寸、导出页面尺寸和打印纸张尺寸的区别：

- **Presentation viewers:** 查看器可以使用其自己的布局规则显示或打印备注。如果其他应用程序保存了文件，请重新打开并再次检查尺寸；该应用程序的格式转换可能会对其进行标准化。
- **Export formats:** 上述备注和讲义 PDF 示例使用配置的页面尺寸。光栅图像使用整数像素尺寸和渲染比例，因此在图像输出中可能会对小数点值进行四舍五入。导出常规幻灯片时不使用备注页尺寸。
- **Printer drivers:** 纸张选择、自动旋转和适合页面设置可以更改实际输出，而不更改演示文稿或 PDF 中存储的尺寸。针对特定纸张尺寸，请匹配打印机设置并检查打印预览。

## **常见问题**

**我可以仅为单个幻灯片设置备注尺寸吗？**

备注页尺寸是演示文稿级别的设置。各幻灯片可以拥有不同的备注内容，但此属性不为每张幻灯片提供独立的页面尺寸。

**为什么更改备注方向没有影响我的幻灯片？**

备注页和常规幻灯片的尺寸是相互独立的。当您想调整幻灯片本身的大小时，请使用常规幻灯片尺寸设置。

**为什么我的保存或打印结果尺寸不同？**

首先重新打开已保存的演示文稿并比较其备注尺寸。如果这些尺寸已改变，请检查在其他应用程序中保存或转换文件时是否修改了页面设置。如果没有，请检查导出布局、图像比例、查看器设置以及打印机纸张选择。