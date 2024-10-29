---
title: 将 Powerpoint 转换为 JPG
type: docs
weight: 60
url: /zh/java/convert-powerpoint-to-jpg/
keywords: "将 PowerPoint 转换为 JPG, PPTX 转 JPEG, PPT 转 JPEG"
description: "将 PowerPoint 转换为 JPG: PPT 转 JPG, PPTX 转 JPG 在 Java 中"
---

## **关于 PowerPoint 转 JPG 转换**
使用 [**Aspose.Slides API**](https://products.aspose.com/slides/java/)，您可以将 PowerPoint PPT 或 PPTX 演示文稿转换为 JPG 图像。也可以将 PPT/PPTX 转换为 JPEG、PNG 或 SVG。借助此功能，可以轻松实现自己的演示查看器，为每个幻灯片创建缩略图。这可能对保护演示幻灯片的版权以及以只读模式展示演示文稿非常有用。Aspose.Slides 允许将整个演示文稿或特定幻灯片转换为图像格式。

{{% alert color="primary" %}} 

要查看 Aspose.Slides 如何将 PowerPoint 转换为 JPG 图像，您可以尝试这些免费的在线转换器：PowerPoint [PPTX 转 JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) 和 [PPT 转 JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **将 PowerPoint PPT/PPTX 转换为 JPG**
以下是将 PPT/PPTX 转换为 JPG 的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类型的实例。
2. 从 [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 集合中获取 [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) 类型的幻灯片对象。
3. 创建每个幻灯片的缩略图，然后将其转换为 JPG。 [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) 方法用于获取幻灯片的缩略图，返回的结果是 [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images) 对象。必须从所需的 [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) 类型的幻灯片调用 [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) 方法，缩略图的比例传递给该方法。
4. 在获取到幻灯片的缩略图后，从缩略图对象调用 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 方法。将生成的文件名称和图像格式传递给它。

{{% alert color="primary" %}}

**注意**：PPT/PPTX 转 JPG 转换与 Aspose.Slides API 中对其他类型的转换不同。对于其他类型，您通常使用 [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法，但在这里您需要 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 方法。

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // 创建全尺度图像
        IImage slideImage = sld.getImage(1f, 1f);

        // 将图像以 JPEG 格式保存到磁盘
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用自定义尺寸转换 PowerPoint PPT/PPTX 为 JPG**
要更改生成的缩略图和 JPG 图像的尺寸，可以通过将 *ScaleX* 和 *ScaleY* 值传递给 [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) 方法来设置它们：

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // 定义尺寸
    int desiredX = 1200;
    int desiredY = 800;
    // 获取 X 和 Y 的缩放值
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // 创建全尺度图像
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // 将图像以 JPEG 格式保存到磁盘
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **在将演示文稿保存为图像时渲染注释**
Aspose.Slides for Java 提供了一种功能，允许您在将演示文稿的幻灯片转换为图像时渲染幻灯片中的注释。以下 Java 代码演示了这一操作：

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="技巧" color="primary" %}}

Aspose 提供了一个 [免费拼贴网页应用](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid) 等。 

使用本文中描述的相同原理，您可以将图像从一种格式转换为另一种格式。有关更多信息，请查看以下页面：转换 [图像为 JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); 转换 [JPG 为图像](https://products.aspose.com/slides/java/conversion/jpg-to-image/); 转换 [JPG 为 PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/); 转换 [PNG 为 JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); 转换 [PNG 为 SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/); 转换 [SVG 为 PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/)。

{{% /alert %}}

## **另请参见**

查看将 PPT/PPTX 转换为图像的其他选项，例如：

- [PPT/PPTX 转 SVG 转换](/slides/zh/java/render-a-slide-as-an-svg-image/)。