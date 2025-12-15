---
title: 在 Android 上创建演示文稿形状的缩略图
linktitle: 形状缩略图
type: docs
weight: 70
url: /zh/androidjava/create-shape-thumbnails/
keywords:
- 形状缩略图
- 形状图像
- 渲染形状
- 形状渲染
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 从 PowerPoint 幻灯片生成高质量的形状缩略图 — 轻松创建和导出演示文稿缩略图。"
---

## **Overview**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 可用于创建演示文稿文件，每页对应一张幻灯片。可以使用 Microsoft PowerPoint 打开演示文稿文件进行查看。但开发者有时需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for Android via Java 可帮助他们生成幻灯片形状的缩略图。

{{% /alert %}} 

在本主题中，我们将展示如何在不同情形下生成幻灯片缩略图：

- 在幻灯片内生成形状缩略图。
- 为幻灯片形状生成具有用户定义尺寸的形状缩略图。
- 在形状外观的边界内生成形状缩略图。

## **Generate a Shape Thumbnail from a Slide**
要使用 Aspose.Slides for Android via Java 从任意幻灯片生成形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
2. 使用其 ID 或索引获取任意幻灯片的引用。
3. 在默认比例下获取引用幻灯片的形状缩略图。
4. 将缩略图保存为您首选的图像格式。

下面的示例代码演示如何从幻灯片生成形状缩略图：
```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建一个全比例图像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // 将图像保存为 PNG 格式到磁盘
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Generate a User-Defined Scaling Factor Thumbnail**
要使用 Aspose.Slides for Android via Java 为幻灯片生成形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
2. 使用其 ID 或索引获取任意幻灯片的引用。
3. 使用用户定义的尺寸获取引用幻灯片的形状缩略图。
4. 将缩略图保存为您首选的图像格式。

下面的示例代码演示如何基于定义的缩放因子生成形状缩略图：
```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建一个全比例图像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // 将图像以 PNG 格式保存到磁盘
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Create a Bounds-Based Shape Appearance Thumbnail**
此方法创建形状缩略图，使开发者能够在形状外观的边界内生成缩略图。它会考虑所有形状效果。生成的形状缩略图受到幻灯片边界的限制。要在外观边界内生成幻灯片形状的缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
2. 使用其 ID 或索引获取任意幻灯片的引用。
3. 使用形状边界作为外观获取引用幻灯片的缩略图。
4. 将缩略图保存为您首选的图像格式。

下面的示例代码基于上述步骤：
```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建一个全比例图像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // 将图像保存到磁盘的 PNG 格式
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**What image formats can be used when saving shape thumbnails?**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/)，以及其他格式。形状还可以通过将形状内容保存为 SVG 来[导出为矢量 SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。

**What is the difference between Shape and Appearance bounds when rendering a thumbnail?**

`Shape` 使用形状的几何信息；`Appearance` 会考虑[视觉效果](/slides/zh/androidjava/shape-effect/)（阴影、发光等）。

**What happens if a shape is marked as hidden? Will it still render as a thumbnail?**

隐藏的形状仍然是模型的一部分，可以被渲染；隐藏标志仅影响幻灯片放映的显示，但不会阻止生成该形状的图像。

**Are group shapes, charts, SmartArt, and other complex objects supported?**

是的。任何以[Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/) 表示的对象（包括[GroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/)和[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/)）都可以保存为缩略图或 SVG。

**Do system-installed fonts affect the quality of thumbnails for text shapes?**

会。您应当[提供所需字体](/slides/zh/androidjava/custom-font/)（或[配置字体替代](/slides/zh/androidjava/font-substitution/)），以避免不必要的回退和文本换行。