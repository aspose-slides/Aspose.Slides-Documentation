---
title: 将 Powerpoint 转换为 JPG
type: docs
weight: 60
url: /androidjava/convert-powerpoint-to-jpg/
keywords:
- 转换 PowerPoint 演示文稿
- JPG
- JPEG
- PowerPoint 转 JPG
- PowerPoint 转 JPEG
- PPT 转 JPG
- PPTX 转 JPG
- PPT 转 JPEG
- PPTX 转 JPEG
- 安卓
- Aspose.Slides
description: "将 PowerPoint 转换为 JPG：PPT 转 JPG，PPTX 转 JPG 的 Java 代码"
---

## **关于 PowerPoint 到 JPG 转换**
使用 [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/)，您可以将 PowerPoint 的 PPT 或 PPTX 演示文稿转换为 JPG 图像。还可以将 PPT/PPTX 转换为 JPEG、PNG 或 SVG。利用这个功能，您可以轻松实现自己的演示文稿查看器，为每一张幻灯片创建缩略图。这在您想要保护演示文稿幻灯片不被复制，或以只读模式展示演示文稿时非常有用。Aspose.Slides 允许将整个演示文稿或某一特定幻灯片转换为图像格式。

{{% alert color="primary" %}} 

要查看 Aspose.Slides 如何将 PowerPoint 转换为 JPG 图像，您可以尝试这些免费的在线转换器：PowerPoint [PPTX 转 JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) 和 [PPT 转 JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **将 PowerPoint PPT/PPTX 转换为 JPG**
以下是将 PPT/PPTX 转换为 JPG 的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类型的实例。
2. 从 [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 集合中获取 [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) 类型的幻灯片对象。
3. 创建每一张幻灯片的缩略图，然后将其转换为 JPG。使用 [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-) 方法获取幻灯片的缩略图，该方法返回 [Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Images) 对象作为结果。必须从所需的 [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) 类型幻灯片调用 [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) 方法，缩略图的缩放比例作为参数传入方法中。
4. 在获取到幻灯片缩略图后，调用缩略图对象中的 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 方法。将生成的文件名和图像格式传入该方法。

{{% alert color="primary" %}}

**注意**：PPT/PPTX 到 JPG 的转换与 Aspose.Slides API 中转换为其他类型的不同。对于其他类型，通常使用 [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法，但在这里你需要使用 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 方法。

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // 创建全尺寸图像
        IImage slideImage = sld.getImage(1f, 1f);

        // 以 JPEG 格式将图像保存到磁盘
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

## **使用自定义尺寸将 PowerPoint PPT/PPTX 转换为 JPG**
要更改 resulting 缩略图和 JPG 图像的尺寸，您可以通过将 *ScaleX* 和 *ScaleY* 值传入 [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-) 方法来设置它们：

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
        // 创建全尺寸图像
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // 以 JPEG 格式将图像保存到磁盘
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

## **保存演示文稿为图像时渲染评论**
Aspose.Slides for Android 通过 Java 提供了一种功能，允许您在将演示文稿幻灯片转换为图像时渲染评论。以下 Java 代码演示了该操作：

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

{{% alert title="提示" color="primary" %}}

Aspose 提供了一个 [免费的拼贴网页应用](https://products.aspose.app/slides/collage)。使用该在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid)，等等。 

使用本文所述的相同原理，您可以将图像从一种格式转换为另一种格式。有关更多信息，请参见以下页面：将 [图像转换为 JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/)；将 [JPG 转换为图像](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/)；将 [JPG 转换为 PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/)；将 [PNG 转换为 JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/)；将 [PNG 转换为 SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/)；将 [SVG 转换为 PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/)。

{{% /alert %}}

## **另见**

请参见其他将 PPT/PPTX 转换为图像的选项，例如：

- [PPT/PPTX 转 SVG 转换](/slides/androidjava/render-a-slide-as-an-svg-image/)。