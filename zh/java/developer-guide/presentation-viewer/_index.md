---
title: 演示文稿查看器
type: docs
weight: 50
url: /zh/java/presentation-viewer/
keywords: "PowerPoint PPT 查看器"
description: "Java 中的 PowerPoint PPT 查看器"
---

{{% alert color="primary" %}} 

Aspose.Slides for Java 用于创建包含幻灯片的演示文稿文件。这些幻灯片可以通过使用 Microsoft PowerPoint 打开演示文稿来查看。但是，有时，开发人员也可能需要在他们最喜欢的图像查看器中将幻灯片视为图像，或创建他们自己的演示文稿查看器。在这种情况下，Aspose.Slides for Java 允许您将单个幻灯片导出为图像。本文描述了如何实现这一点。

{{% /alert %}} 

## **实时示例**
您可以尝试 [**Aspose.Slides 查看器**](https://products.aspose.app/slides/viewer/) 免费应用，以了解您可以使用 Aspose.Slides API 实现的功能：

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **从幻灯片生成 SVG 图像**
要使用 Aspose.Slides for Java 从任何所需的幻灯片生成 SVG 图像，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
- 通过使用其 ID 或索引获取所需幻灯片的引用。
- 在内存流中获取 SVG 图像。
- 将内存流保存到文件。

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("CreateSlidesSVGImage.pptx");
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 创建内存流对象
    FileOutputStream svgStream = new FileOutputStream("Aspose_out.svg");

    // 生成幻灯片的 SVG 图像并保存到内存流中
    sld.writeAsSvg(svgStream);

    svgStream.close();
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **使用自定义形状 IDS 生成 SVG**
Aspose.Slides for Java 可用于从幻灯片生成 [SVG](https://docs.fileformat.com/page-description-language/svg/) ，使用自定义形状 ID。为此，请使用来自 [ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISvgShape) 的 ID 属性，该属性表示在生成的 SVG 中形状的自定义 ID。可以使用 CustomSvgShapeFormattingController 设置形状 ID。

```java
Presentation pres = new Presentation("pptxFileName.pptx");
try {
    FileOutputStream stream = new FileOutputStream("Aspose_out.svg");
    try {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

        pres.getSlides().get_Item(0).writeAsSvg(stream, svgOptions);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    pres.dispose();
}
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
Aspose.Slides for Java 可帮助您生成幻灯片的缩略图图像。要使用 Aspose.Slides for Java 生成任何所需幻灯片的缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过使用其 ID 或索引获取所需幻灯片的引用。
1. 在指定的比例下获取引用幻灯片的缩略图图像。
1. 将缩略图图像保存为任何所需的图像格式。

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("ThumbnailFromSlide.pptx");
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 创建全尺寸图像
    IImage slideImage = sld.getImage(1f, 1f);

    // 以 JPEG 格式将图像保存到磁盘
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **使用用户定义的尺寸创建缩略图**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过使用其 ID 或索引获取所需幻灯片的引用。
1. 在指定的比例下获取引用幻灯片的缩略图图像。
1. 将缩略图图像保存为任何所需的图像格式。

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 用户定义尺寸
    int desiredX = 1200;
    int desiredY = 800;

    // 获取 X 和 Y 的缩放值
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;
    
    // 创建全尺寸图像
    IImage slideImage = sld.getImage(ScaleX, ScaleY);

    // 以 JPEG 格式将图像保存到磁盘
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **在备注幻灯片视图中从幻灯片创建缩略图**
要生成任何所需幻灯片在备注幻灯片视图中的缩略图，请使用 Aspose.Slides for Java：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过使用其 ID 或索引获取所需幻灯片的引用。
1. 在备注幻灯片视图中，以指定的比例获取引用幻灯片的缩略图图像。
1. 将缩略图图像保存为任何所需的图像格式。

下面的代码片段生成演示文稿中第一张幻灯片在备注幻灯片视图中的缩略图。

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // 访问第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);

    // 用户定义尺寸
    int desiredX = 1200;
    int desiredY = 800;

    // 获取 X 和 Y 的缩放值
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    RenderingOptions opts = new RenderingOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);
    
    // 创建全尺寸图像
    IImage slideImage = sld.getImage(opts, ScaleX, ScaleY);

    // 以 JPEG 格式将图像保存到磁盘
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```