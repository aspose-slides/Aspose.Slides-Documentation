---
title: 在 C++ 中创建演示文稿查看器
linktitle: 演示文稿查看器
type: docs
weight: 50
url: /zh/cpp/presentation-viewer/
keywords:
- 查看演示文稿
- 演示文稿查看器
- 创建演示文稿查看器
- 查看 PPT
- 查看 PPTX
- 查看 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中创建自定义演示文稿查看器。轻松显示 PowerPoint 和 OpenDocument 文件，而无需 Microsoft PowerPoint。"
---

Aspose.Slides for C++ 用于创建包含幻灯片的演示文稿文件。可以通过在 Microsoft PowerPoint 等程序中打开演示文稿来查看这些幻灯片。不过，有时开发人员可能需要在首选的图像查看器中将幻灯片作为图片查看，或创建自己的演示文稿查看器。在这些情况下，Aspose.Slides 允许您将单个幻灯片导出为图像。本文介绍了具体操作方法。

## **从幻灯片生成 SVG 图像**

使用 Aspose.Slides 从演示文稿幻灯片生成 SVG 图像，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片引用。  
3. 打开文件流。  
4. 将幻灯片保存为 SVG 图像到文件流中。  
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```


## **使用自定义形状 ID 生成 SVG**

Aspose.Slides 可用于从具有自定义形状 ID 的幻灯片生成 [SVG](https://docs.fileformat.com/page-description-language/svg/)。为此，请使用来自 [ISvgShape](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/) 的 `set_Id` 方法。可以使用 `CustomSvgShapeFormattingController` 来设置形状 ID。  
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
  
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```


## **创建幻灯片缩略图图像**

Aspose.Slides 帮助您生成幻灯片的缩略图。要使用 Aspose.Slides 生成幻灯片的缩略图，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片引用。  
3. 以定义的比例获取引用幻灯片的缩略图图像。  
4. 以任意所需的图像格式保存缩略图。  
```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **使用用户自定义尺寸创建幻灯片缩略图**

要使用用户自定义尺寸创建幻灯片缩略图，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片引用。  
3. 使用定义的尺寸获取引用幻灯片的缩略图图像。  
4. 以任意所需的图像格式保存缩略图。  
```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **创建带演讲者备注的幻灯片缩略图**

要使用 Aspose.Slides 生成带演讲者备注的幻灯片缩略图，请按照以下步骤操作：

1. 创建 [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) 类的实例。  
2. 使用 `RenderingOptions.set_SlidesLayoutOptions` 方法设置演讲者备注的位置。  
3. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
4. 通过索引获取幻灯片引用。  
5. 使用渲染选项获取引用幻灯片的缩略图图像。  
6. 以任意所需的图像格式保存缩略图。  
```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **实时示例**

您可以试用 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) 免费应用，了解使用 Aspose.Slides API 可以实现的功能：

![在线 PowerPoint 查看器](online-PowerPoint-viewer.png)

## **常见问题**

**我可以在 Web 应用程序中嵌入演示文稿查看器吗？**

可以。您可以在服务器端使用 Aspose.Slides 将幻灯片渲染为图像或 HTML，并在浏览器中显示。导航和缩放功能可以使用 JavaScript 实现，从而提供交互式体验。

**在自定义查看器中显示幻灯片的最佳方式是什么？**

推荐的做法是使用 Aspose.Slides 将每张幻灯片渲染为图像（例如 PNG 或 SVG）或转换为 HTML，然后将输出显示在图片框（桌面）或 HTML 容器（Web）中。

**如何处理包含大量幻灯片的大型演示文稿？**

对于大型演示文稿，考虑使用懒加载或按需渲染幻灯片。这意味着仅在用户导航到幻灯片时生成其内容，从而降低内存占用和加载时间。