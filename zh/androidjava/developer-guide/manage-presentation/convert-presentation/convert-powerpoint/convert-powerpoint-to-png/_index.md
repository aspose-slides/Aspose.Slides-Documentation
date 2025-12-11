---
title: 在 Android 上将 PowerPoint 幻灯片转换为 PNG
linktitle: PowerPoint 转 PNG
type: docs
weight: 30
url: /zh/androidjava/convert-powerpoint-to-png/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 PNG
- 演示文稿 转 PNG
- 幻灯片 转 PNG
- PPT 转 PNG
- PPTX 转 PNG
- 将 PPT 保存为 PNG
- 将 PPTX 保存为 PNG
- 导出 PPT 为 PNG
- 导出 PPTX 为 PNG
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 通过 Java 快速将 PowerPoint 演示文稿转换为高质量 PNG 图像，确保精确且自动化的结果。"
---

## **关于 PowerPoint 转 PNG 转换**

PNG（Portable Network Graphics）格式虽然没有 JPEG（Joint Photographic Experts Group）那么流行，但仍然非常受欢迎。

**使用场景：** 当您有复杂的图像且大小不是问题时，PNG 比 JPEG 更适合作为图像格式。

{{% alert title="Tip" color="primary" %}} 您可能想查看 Aspose 免费的 **PowerPoint 转 PNG 转换器**： [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。它们是本页所述过程的实时实现。 {{% /alert %}}

## **将 PowerPoint 转换为 PNG**

按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类。
2. 从 [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) 集合中获取位于 [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) 接口下的幻灯片对象。
3. 使用 [ISlide.getImage()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) 方法获取每个幻灯片的缩略图。
4. 使用  [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String%20formatName,%20int%20imageFormat)) 方法将幻灯片缩略图保存为 PNG 格式。

下面的 Java 代码演示如何将 PowerPoint 演示文稿转换为 PNG：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **使用自定义尺寸将 PowerPoint 转换为 PNG**

如果您想获取特定比例的 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，这些值决定生成的缩略图的尺寸。

下面的 Java 代码演示上述操作：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **使用自定义大小将 PowerPoint 转换为 PNG**

如果您想获取特定大小的 PNG 文件，可以为 `ImageSize` 传入您偏好的 `width` 和 `height` 参数。

下面的代码演示如何在指定图像大小的情况下将 PowerPoint 转换为 PNG：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**如何仅导出特定形状（例如图表或图片）而不是整张幻灯片？**

Aspose.Slides 支持[为单个形状生成缩略图](/slides/zh/androidjava/create-shape-thumbnails/)；您可以将形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**

是的，但请[不要在多个线程之间共享](/slides/zh/androidjava/multithreading/)同一个 Presentation 实例。每个线程或进程使用单独的实例。

**导出为 PNG 时试用版有限制有哪些？**

评估模式会在输出图像上添加水印，并在授权之前强制执行[其他限制](/slides/zh/androidjava/licensing/)。