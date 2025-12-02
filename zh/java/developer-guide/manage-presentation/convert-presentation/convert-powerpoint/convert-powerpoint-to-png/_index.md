---
title: 在 Java 中将 PowerPoint 幻灯片转换为 PNG
linktitle: PowerPoint 转 PNG
type: docs
weight: 30
url: /zh/java/convert-powerpoint-to-png/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 PNG
- 演示文稿转 PNG
- 幻灯片转 PNG
- PPT 转 PNG
- PPTX 转 PNG
- 将 PPT 保存为 PNG
- 将 PPTX 保存为 PNG
- 导出 PPT 为 PNG
- 导出 PPTX 为 PNG
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 快速将 PowerPoint 演示文稿转换为高质量 PNG 图像，确保精确且自动化的结果。"
---

## **关于 PowerPoint 转 PNG 转换**

PNG（可移植网络图形）格式不像 JPEG（联合图像专家组）那样流行，但它仍然非常受欢迎。

**用例：** 当您拥有复杂图像且大小不是问题时，PNG 是比 JPEG 更好的图像格式。

{{% alert title="Tip" color="primary" %}} 您可能想查看 Aspose 免费的 **PowerPoint 转 PNG 转换器**：[PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png)和[PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。它们是本页描述的过程的实时实现。 {{% /alert %}}

## **将 PowerPoint 转换为 PNG**

按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类。
2. 从位于 [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) 接口下的 [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) 集合中获取幻灯片对象。 
3. 使用 [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) 方法获取每个幻灯片的缩略图。 
4. 使用 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 方法将幻灯片缩略图保存为 PNG 格式。

以下 Java 代码演示了如何将 PowerPoint 演示文稿转换为 PNG：
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

如果您希望获取特定比例的 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，这决定了生成的缩略图的尺寸。

下面的 Java 代码演示了上述操作：
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

如果您希望获取特定大小的 PNG 文件，可以为 `ImageSize` 传入您偏好的 `width` 和 `height` 参数。

以下代码展示了在指定图像尺寸的情况下将 PowerPoint 转换为 PNG 的方法：
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
