---
title: 转换幻灯片
type: docs
weight: 41
url: /cpp/convert-slide/
keywords: 
- 将幻灯片转换为图像
- 将幻灯片导出为图像
- 将幻灯片保存为图像
- 幻灯片转图像
- 幻灯片转PNG
- 幻灯片转JPEG
- 幻灯片转位图
- C++
- Aspose.Slides for C++
description: "在 C++ 中将 PowerPoint 幻灯片转换为图像（位图、PNG 或 JPG）"
---

Aspose.Slides for C++ 允许您将幻灯片（在演示文稿中）转换为图像。支持的图像格式包括：BMP、PNG、JPG（JPEG）、GIF 等。

要将幻灯片转换为图像，请执行以下操作：

1. 首先，使用以下方法设置转换参数和要转换的幻灯片对象：
   * [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) 接口或
   * [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options) 接口。

2. 其次，通过使用 [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 方法将幻灯片转换为图像。

## **关于位图和其他图像格式**

[位图](https://reference.aspose.com/slides/cpp/class/system.drawing.bitmap) 是允许您处理由像素数据定义的图像的对象。您可以使用此类的实例以多种格式（BMP、JPG、PNG 等）保存图像。

{{% alert title="信息" color="info" %}}

Aspose 最近开发了一个在线 [文本到 GIF](https://products.aspose.app/slides/text-to-gif) 转换器。

{{% /alert %}}

## **将幻灯片转换为位图并以 PNG 格式保存图像**

以下 C++ 代码演示了如何将演示文稿的第一张幻灯片转换为位图对象，然后以 PNG 格式保存图像：

``` cpp 
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// 将演示文稿的第一张幻灯片转换为位图对象
System::SharedPtr<IImage> image = pres->get_Slide(0)->GetImage();
                 
// 以 PNG 格式保存图像
image->Save(u"Slide_0.png", ImageFormat::Png);
```

{{% alert title="提示" color="primary" %}} 

您可以将幻灯片转换为位图对象，然后在某处直接使用该对象。或者，您可以将幻灯片转换为位图，然后以 JPEG 或您喜欢的任何其他格式保存图像。

{{% /alert %}}  

## **使用自定义尺寸将幻灯片转换为图像**

您可能需要获取某种尺寸的图像。使用 [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 的重载，您可以将幻灯片转换为具有特定尺寸（长度和宽度）的图像。

以下示例代码演示了使用 [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 方法在 C++ 中进行的转换：

``` cpp 
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");
// 将演示文稿中的第一张幻灯片转换为指定大小的位图
auto image = pres->get_Slide(0)->GetImage(Size(1820, 1040));
// 以 JPEG 格式保存图像
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);
```

## **将带备注和评论的幻灯片转换为图像**

某些幻灯片包含备注和评论。

Aspose.Slides 提供了两个接口——[ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) 和 [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options)——可以控制演示文稿幻灯片的渲染为图像。两个接口都包含 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) 接口，允许您在将幻灯片转换为图像时在幻灯片上添加备注和评论。

{{% alert title="信息" color="info" %}} 

使用 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) 接口，您可以指定在生成的图像中备注和评论的首选位置。

{{% /alert %}} 

以下 C++ 代码演示了具有备注和评论的幻灯片的转换过程：

``` cpp 
auto pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");
// 创建渲染选项
auto options = System::MakeObject<RenderingOptions>();
auto notesCommentsLayouting = options->get_NotesCommentsLayouting();
// 设置页面上备注的位置
notesCommentsLayouting->set_NotesPosition(NotesPositions::BottomTruncated);
// 设置页面上评论的位置 
notesCommentsLayouting->set_CommentsPosition(CommentsPositions::Right);
// 设置评论输出区域的宽度
notesCommentsLayouting->set_CommentsAreaWidth(500);
// 设置评论区域的颜色
notesCommentsLayouting->set_CommentsAreaColor(Color::get_AntiqueWhite());

// 将演示文稿的第一张幻灯片转换为位图对象
auto image = pres->get_Slide(0)->GetImage(options, 2.f, 2.f);

// 以 GIF 格式保存图像
image->Save(u"Slide_Notes_Comments_0.gif", ImageFormat::Gif);
```

{{% alert title="注意" color="warning" %}} 

在任何幻灯片到图像的转换过程中，您无法将 BottomFull 值（用于指定备注位置）传递给 [set_NotesPositions()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) 方法，因为备注的文本可能很大，这意味着它可能无法适合指定的图像大小。

{{% /alert %}} 

## **使用 ITiffOptions 将幻灯片转换为图像**

[ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) 接口为结果图像提供了更多的控制（在参数方面）。使用此接口，您可以指定输出图像的大小、分辨率、调色板和其他参数。

以下 C++ 代码演示了一种使用 ITiffOptions 的转换过程，以输出一幅 300dpi 分辨率和 2160 × 2800 大小的黑白图像：

``` cpp 
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");

// 按索引获取幻灯片
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// 创建 TiffOptions 对象
System::SharedPtr<TiffOptions> options = System::MakeObject<TiffOptions>();
options->set_ImageSize(Size(2160, 2880));

// 如果找不到源字体，则设置使用的字体
options->set_DefaultRegularFont(u"Arial Black");

// 设置页面上备注的位置 
options->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomTruncated);

// 设置像素格式（黑白）
options->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);

// 设置分辨率
options->set_DpiX(300);
options->set_DpiY(300);

// 将幻灯片转换为位图对象
System::SharedPtr<Bitmap> image = slide->GetImage(options);

// 以 BMP 格式保存图像
image->Save(u"PresentationNotesComments.bmp", ImageFormat::Tiff);
```

## **将所有幻灯片转换为图像**

Aspose.Slides 允许您将单个演示文稿中的所有幻灯片转换为图像。基本上，您可以将整个演示文稿转换为图像。

以下示例代码演示了如何在 C++ 中将演示文稿中的所有幻灯片转换为图像：

``` cpp 
// 输出目录的路径
System::String outputDir = u"D:\\PresentationImages";

auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// 按幻灯片逐个渲染演示文稿到图像数组
for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
{
    // 控制隐藏幻灯片（不渲染隐藏幻灯片）
    if (pres->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // 将幻灯片转换为位图对象
    auto image = pres->get_Slide(i)->GetImage(2.f, 2.f);

    // 为图像创建文件名
    auto outputFilePath = Path::Combine(outputDir, String(u"Slide_") + i + u".jpg");

    // 以 PNG 格式保存图像
    image->Save(outputFilePath, ImageFormat::Png);
}
```