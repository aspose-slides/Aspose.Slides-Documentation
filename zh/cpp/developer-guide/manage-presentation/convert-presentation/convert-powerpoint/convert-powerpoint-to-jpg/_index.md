---
title: 在 C++ 中将 PPT 和 PPTX 转换为 JPG
linktitle: PowerPoint 转 JPG
type: docs
weight: 60
url: /zh/cpp/convert-powerpoint-to-jpg/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 JPG
- 演示文稿 转 JPG
- 幻灯片 转 JPG
- PPT 转 JPG
- PPTX 转 JPG
- 将 PowerPoint 保存为 JPG
- 将 演示文稿 保存为 JPG
- 将 幻灯片 保存为 JPG
- 将 PPT 保存为 JPG
- 将 PPTX 保存为 JPG
- 导出 PPT 为 JPG
- 导出 PPTX 为 JPG
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中将 PowerPoint（PPT、PPTX）幻灯片转换为高质量 JPG 图像，提供快速可靠的代码示例。"
---

## **概述**

将PowerPoint和OpenDocument演示文稿转换为JPG图像有助于共享幻灯片、优化性能以及将内容嵌入网站或应用程序。Aspose.Slides for C++ 允许您将 PPTX、PPT 和 ODP 文件转换为高质量的 JPEG 图像。本指南解释了不同的转换方法。

有了这些功能，您可以轻松实现自己的演示文稿查看器，并为每张幻灯片创建缩略图。如果您希望保护幻灯片免于复制或以只读模式演示演示文稿，这将非常有用。Aspose.Slides 允许您将整个演示文稿或特定幻灯片转换为图像格式。

## **将演示文稿幻灯片转换为 JPG 图像**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
2. 从演示文稿的幻灯片集合中获取 [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) 类型的幻灯片对象。  
3. 使用 [ISlide.GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 方法创建幻灯片的图像。  
4. 在图像对象上调用 [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) 方法。将输出文件名和图像格式作为参数传入。

{{% alert color="primary" %}} 
**注意：** PPT、PPTX 或 ODP 转换为 JPG 与 Aspose.Slides for C++ API 中转换为其他格式有所不同。对于其他格式，通常使用 [IPresentation.Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/) 方法。但是，对于 JPG 转换，需要使用 [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) 方法。  
{{% /alert %}} 
```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // 创建指定比例的幻灯片图像。
    auto image = slide->GetImage(scaleX, scaleY);

    // 以 JPEG 格式将图像保存到磁盘。
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **使用自定义尺寸转换幻灯片为 JPG**

要更改生成的 JPG 图像的尺寸，您可以在调用 [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) 方法时传入图像大小。这样可以生成具有特定宽度和高度值的图像，确保输出满足分辨率和宽高比的要求。当为 Web 应用程序、报告或文档生成图像且需要精确的图像尺寸时，此灵活性尤为有用。  
```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // 创建指定尺寸的幻灯片图像。
    auto image = slide->GetImage(imageSize);

    // 将图像以 JPEG 格式保存到磁盘。
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **在将幻灯片保存为图像时渲染批注**

Aspose.Slides for C++ 提供了一项功能，允许在将演示文稿的幻灯片转换为 JPG 图像时渲染批注。此功能对于保留协作者在 PowerPoint 演示文稿中添加的注释、反馈或讨论尤为有用。启用此选项后，批注将在生成的图像中可见，便于在无需打开原始演示文稿文件的情况下审阅和共享反馈。

假设我们有一个名为 "sample.pptx" 的演示文稿文件，其中包含批注的幻灯片：

![带批注的幻灯片](slide_with_comments.png)

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // 设置幻灯片批注的选项。
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // 将第一张幻灯片转换为图像。
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```


结果：

![带批注的 JPG 图像](image_with_comments.png)

## **另见**

- [将 PowerPoint 转换为 GIF](/slides/zh/cpp/convert-powerpoint-to-animated-gif/)  
- [将 PowerPoint 转换为 PNG](/slides/zh/cpp/convert-powerpoint-to-png/)  
- [将 PowerPoint 转换为 TIFF](/slides/zh/cpp/convert-powerpoint-to-tiff/)  
- [将 PowerPoint 转换为 SVG](/slides/zh/cpp/render-a-slide-as-an-svg-image/)  

{{% alert color="primary" %}} 
要了解 Aspose.Slides 如何将 PowerPoint 转换为 JPG 图像，请尝试以下免费在线转换器：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) 和 [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。  
{{% /alert %}}

![免费在线 PPTX 转 JPG 转换器](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose 提供了一个 [FREE Collage web app](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG to JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 图像，创建 [photo grids](https://products.aspose.app/slides/collage/photo-grid) 等。

使用本文中描述的相同原理，您可以将图像从一种格式转换为另一种格式。有关更多信息，请参阅以下页面：convert [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/)；convert [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/)；convert [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)，convert [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/)；convert [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)，convert [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/)。  

{{% /alert %}}

## **常见问题**

**此方法是否支持批量转换？**  
是的，Aspose.Slides 允许在一次操作中批量将多张幻灯片转换为 JPG。

**转换是否支持 SmartArt、图表和其他复杂对象？**  
是的，Aspose.Slides 能渲染所有内容，包括 SmartArt、图表、表格、形状等。但与 PowerPoint 相比，渲染精度可能略有差异，尤其是在使用自定义或缺失字体时。

**处理的幻灯片数量是否有限制？**  
Aspose.Slides 本身对可处理的幻灯片数量没有严格限制。但在处理大型演示文稿或高分辨率图像时，可能会遇到内存不足错误。