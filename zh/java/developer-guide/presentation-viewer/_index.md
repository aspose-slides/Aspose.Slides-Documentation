---
title: 在 Java 中创建演示文稿查看器
linktitle: 演示文稿查看器
type: docs
weight: 50
url: /zh/java/presentation-viewer/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中创建自定义演示文稿查看器。轻松显示 PowerPoint 和 OpenDocument 文件，无需 Microsoft PowerPoint。"
---

Aspose.Slides for Java 用于创建包含幻灯片的演示文稿文件。这些幻灯片可以通过在 Microsoft PowerPoint 等软件中打开演示文稿来查看。但是，有时开发人员可能需要在自己喜欢的图像查看器中将幻灯片查看为图像，或创建自己的演示文稿查看器。在这种情况下，Aspose.Slides 允许您将单个幻灯片导出为图像。本文介绍了具体做法。

## **从幻灯片生成 SVG 图像**

要使用 Aspose.Slides 从演示文稿幻灯片生成 SVG 图像，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片引用。  
1. 打开文件流。  
1. 将幻灯片保存为 SVG 图像到文件流中。  
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **使用自定义形状 ID 生成 SVG**

Aspose.Slides 可用于从带有自定义形状 ID 的幻灯片生成 [SVG](https://docs.fileformat.com/page-description-language/svg/)。为此，请使用来自 [ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/) 的 `setId` 方法。可以使用 `CustomSvgShapeFormattingController` 来设置形状 ID。  
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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```


## **创建幻灯片缩略图**

Aspose.Slides 帮助您生成幻灯片的缩略图。要使用 Aspose.Slides 生成幻灯片的缩略图，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片引用。  
1. 按定义的比例获取引用幻灯片的缩略图。  
1. 以任意所需的图像格式保存缩略图。  
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


## **使用用户定义尺寸创建幻灯片缩略图**

要使用用户定义的尺寸创建幻灯片缩略图，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片引用。  
1. 使用定义的尺寸获取引用幻灯片的缩略图。  
1. 以任意所需的图像格式保存缩略图。  
```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **使用演讲者备注创建幻灯片缩略图**

要使用 Aspose.Slides 生成带有演讲者备注的幻灯片缩略图，请按照以下步骤操作：

1. 创建 [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) 类的实例。  
1. 使用 `RenderingOptions.setSlidesLayoutOptions` 方法设置演讲者备注的位置。  
1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片引用。  
1. 使用渲染选项获取引用幻灯片的缩略图。  
1. 以任意所需的图像格式保存缩略图。  
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

您可以尝试免费应用 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) 来了解使用 Aspose.Slides API 可以实现的功能：

![在线 PowerPoint 查看器](online-PowerPoint-viewer.png)

## **常见问题**

**我可以在 Web 应用程序中嵌入演示文稿查看器吗？**

可以。您可以在服务器端使用 Aspose.Slides 将幻灯片渲染为图像或 HTML，并在浏览器中显示。可以使用 JavaScript 实现导航和缩放功能，以获得交互式体验。

**在自定义查看器中显示幻灯片的最佳方法是什么？**

推荐的做法是将每张幻灯片渲染为图像（例如 PNG 或 SVG）或使用 Aspose.Slides 转换为 HTML，然后在桌面应用中放入图片框或在 Web 中放入 HTML 容器进行显示。

**如何处理包含大量幻灯片的大型演示文稿？**

对于大型文稿，建议采用懒加载或按需渲染的方式。即仅在用户导航到某张幻灯片时生成该幻灯片的内容，从而降低内存占用和加载时间。