---
title: 将演示文稿幻灯片转换为 C++ 图像
linktitle: 幻灯片转图像
type: docs
weight: 41
url: /zh/cpp/convert-slide/
keywords:
- 转换幻灯片
- 导出幻灯片
- 幻灯片转图像
- 将幻灯片保存为图像
- 幻灯片转 PNG
- 幻灯片转 JPEG
- 幻灯片转位图
- 幻灯片转 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 将 PPT、PPTX 和 ODP 幻灯片转换为 C++ 图像——快速、高质量渲染，配有清晰的代码示例。"
---

## **概述**

Aspose.Slides for C++ 使您能够轻松地将 PowerPoint 和 OpenDocument 演示文稿幻灯片转换为多种图像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等。

要将幻灯片转换为图像，请按以下步骤操作：

1. 使用以下方式定义所需的转换设置并选择要导出的幻灯片：
    - 使用 [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) 接口，或
    - 使用 [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/) 接口。
2. 通过调用 [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 方法生成幻灯片图像。

[Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/) 是一个对象，可让您处理像素数据定义的图像。您可以使用此类的实例将图像保存为多种格式（BMP、JPG、PNG 等）。

## **将幻灯片转换为位图并以 PNG 保存图像**

您可以将幻灯片转换为位图对象并直接在应用程序中使用。或者，您可以先将幻灯片转换为位图，然后将图像保存为 JPEG 或其他您喜欢的格式。

此 C++ 代码演示如何将演示文稿的第一张幻灯片转换为位图对象并以 PNG 格式保存图像：
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 将演示文稿的第一张幻灯片转换为位图。
auto image = presentation->get_Slide(0)->GetImage();

// 以 PNG 格式保存图像。
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```


## **将幻灯片转换为自定义大小的图像**

您可能需要获取特定尺寸的图像。使用 [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 的重载，您可以将幻灯片转换为具有特定宽度和高度的图像。

此示例代码演示如何实现：
```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 将演示文稿的第一张幻灯片转换为具有指定尺寸的位图。
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// 以 JPEG 格式保存图像。
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```


## **将带备注和批注的幻灯片转换为图像**

某些幻灯片可能包含备注和批注。

Aspose.Slides 提供两个接口——[ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) 和 [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/)——用于控制将演示文稿幻灯片渲染为图像的方式。这两个接口都包含 `set_SlidesLayoutOptions` 方法，可在将幻灯片转换为图像时配置备注和批注的渲染。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) 类，您可以为生成的图像指定备注和批注的首选位置。

此 C++ 代码演示如何转换带有备注和批注的幻灯片：
```cpp 
float scaleX = 2;
float scaleY = scaleX;

// 加载演示文稿文件。
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // 设置备注的位置。
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // 设置批注的位置。
notesCommentsOptions->set_CommentsAreaWidth(500);                          // 设置批注区域的宽度。
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // 设置批注区域的颜色。

// 创建渲染选项。
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// 将演示文稿的第一张幻灯片转换为图像。
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// 以 GIF 格式保存图像。
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```


{{% alert title="Note" color="warning" %}} 
在任何幻灯片转图像的转换过程中，[set_NotesPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) 方法无法使用 `BottomFull`（指定备注位置），因为备注文本可能过大，导致无法适应指定的图像尺寸。
{{% /alert %}} 

## **使用 TIFF 选项将幻灯片转换为图像**

[ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) 接口通过允许您指定大小、分辨率、调色板等参数，为生成的 TIFF 图像提供更大的控制。

此 C++ 代码演示了使用 TIFF 选项输出分辨率为 300 DPI、尺寸为 2160 × 2800 的黑白图像的转换过程：
```cpp 
// 加载演示文稿文件。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 获取演示文稿的第一张幻灯片。
auto slide = presentation->get_Slide(0);

// 配置输出 TIFF 图像的设置。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // 设置图像尺寸。
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // 设置像素格式（黑白）。
tiffOptions->set_DpiX(300);                                         // 设置水平分辨率。
tiffOptions->set_DpiY(300);                                         // 设置垂直分辨率。

// 将幻灯片转换为带有指定选项的图像。
auto image = slide->GetImage(tiffOptions);

// 以 TIFF 格式保存图像。
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```


## **将所有幻灯片转换为图像**

Aspose.Slides 允许您将演示文稿中的所有幻灯片转换为图像，从而将整个演示文稿转换为一系列图像。

此示例代码演示如何在 C++ 中将演示文稿的所有幻灯片转换为图像：
```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 逐张幻灯片将演示文稿渲染为图像。
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // 控制隐藏幻灯片（不渲染隐藏的幻灯片）。
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // 将幻灯片转换为图像。
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // 以 JPEG 格式保存图像。
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **常见问题**

**Aspose.Slides 是否支持渲染带动画的幻灯片？**

不，`GetImage` 方法仅保存幻灯片的静态图像，不包含动画。

**是否可以导出隐藏的幻灯片为图像？**

可以，隐藏的幻灯片可以像普通幻灯片一样进行处理。只需确保它们包含在处理循环中。

**图像是否可以保存带阴影和效果的版本？**

可以，Aspose.Slides 在将幻灯片保存为图像时支持渲染阴影、透明度和其他图形效果。