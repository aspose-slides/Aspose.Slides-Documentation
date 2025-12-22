---
title: 在 Android 上创建演示文稿查看器
linktitle: 演示文稿查看器
type: docs
weight: 50
url: /zh/androidjava/presentation-viewer/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中创建自定义演示文稿查看器。轻松显示 PowerPoint 和 OpenDocument 文件，无需 Microsoft PowerPoint。"
---

Aspose.Slides for Android via Java 用于创建包含幻灯片的演示文稿文件。这些幻灯片可以通过在 Microsoft PowerPoint 等程序中打开演示文稿来查看。但是，有时开发人员可能需要在首选的图像查看器中将幻灯片显示为图像，或创建自己的演示文稿查看器。在这种情况下，Aspose.Slides 允许将单个幻灯片导出为图像。本文介绍了具体操作方法。

## **从幻灯片生成 SVG 图像**

要使用 Aspose.Slides 从演示文稿幻灯片生成 SVG 图像，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片引用。
1. 打开文件流。
1. 将幻灯片保存为 SVG 图像到文件流。
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **生成具有自定义形状 ID 的 SVG**

Aspose.Slides 可用于从幻灯片生成具有自定义形状 ID 的 [SVG](https://docs.fileformat.com/page-description-language/svg/)。为此，请使用来自 [ISvgShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/) 的 `setId` 方法。`CustomSvgShapeFormattingController` 可用于设置形状 ID。
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```


## **创建幻灯片缩略图图像**

Aspose.Slides 帮助您生成幻灯片的缩略图图像。要使用 Aspose.Slides 生成幻灯片缩略图，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片引用。
1. 按定义的比例获取所引用幻灯片的缩略图图像。
1. 将缩略图图像保存为任意所需的图像格式。
```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **创建具有自定义尺寸的幻灯片缩略图**

要创建具有用户自定义尺寸的幻灯片缩略图图像，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片引用。
1. 使用定义的尺寸获取所引用幻灯片的缩略图图像。
1. 将缩略图图像保存为任意所需的图像格式。
```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **创建带有演讲者备注的幻灯片缩略图**

要使用 Aspose.Slides 生成带有演讲者备注的幻灯片缩略图，请按照以下步骤操作：

1. 创建一个 [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) 类的实例。
1. 使用 `RenderingOptions.setSlidesLayoutOptions` 方法设置演讲者备注的位置。
1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片引用。
1. 使用渲染选项获取所引用幻灯片的缩略图图像。
1. 将缩略图图像保存为任意所需的图像格式。
```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **实时示例**

您可以尝试使用免费应用 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) 来查看使用 Aspose.Slides API 可以实现的功能：

![在线 PowerPoint 查看器](online-PowerPoint-viewer.png)

## **常见问题解答**

**我可以在 Web 应用程序中嵌入演示文稿查看器吗？**

可以。您可以在服务器端使用 Aspose.Slides 将幻灯片渲染为图像或 HTML，然后在浏览器中显示。可以使用 JavaScript 实现导航和缩放功能，以提供交互式体验。

**在自定义查看器中显示幻灯片的最佳方式是什么？**

推荐的做法是将每张幻灯片渲染为图像（例如 PNG 或 SVG）或使用 Aspose.Slides 将其转换为 HTML，然后在图片框（桌面）或 HTML 容器（网页）中显示输出。

**如何处理包含大量幻灯片的演示文稿？**

对于大型演示文稿，建议采用惰性加载或按需渲染的方式。这意味着仅在用户导航到特定幻灯片时才生成该幻灯片的内容，从而降低内存占用和加载时间。