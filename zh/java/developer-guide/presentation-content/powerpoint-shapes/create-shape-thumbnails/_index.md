---
title: 在 Java 中创建演示文稿形状的缩略图
linktitle: 形状缩略图
type: docs
weight: 70
url: /zh/java/create-shape-thumbnails/
keywords:
  - 形状缩略图
  - 形状图像
  - 渲染形状
  - 形状渲染
  - PowerPoint
  - 演示文稿
  - Java
  - Aspose.Slides
description: "使用 Aspose.Slides for Java 从 PowerPoint 幻灯片生成高质量的形状缩略图——轻松创建和导出演示文稿缩略图。"
---

## **概述**
{{% alert color="primary" %}} 

Aspose.Slides for Java 可用于创建演示文稿文件，每页对应一张幻灯片。可以使用 Microsoft PowerPoint 打开演示文稿文件来查看幻灯片。然而，开发人员有时需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for Java 可帮助生成幻灯片形状的缩略图。

{{% /alert %}} 

在本主题中，我们将展示在不同情形下生成幻灯片缩略图的方法：

- 在幻灯片内生成形状缩略图。
- 为具有用户自定义尺寸的幻灯片形状生成缩略图。
- 在形状外观的边界内生成缩略图。

## **从幻灯片生成形状缩略图**
要使用 Aspose.Slides for Java 从任意幻灯片生成形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
2. 使用幻灯片的 ID 或索引获取任意幻灯片的引用。
3. 在默认比例下[获取形状缩略图图像](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--)。
4. 将缩略图图像保存为您偏好的图像格式。

以下示例代码演示如何从幻灯片生成形状缩略图：
```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建一个全比例图像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
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


## **生成用户自定义缩放比例的缩略图**
要使用 Aspose.Slides for Java 生成幻灯片形状的缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
2. 使用幻灯片的 ID 或索引获取任意幻灯片的引用。
3. 使用用户自定义尺寸[获取形状缩略图图像](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-)。
4. 将缩略图图像保存为您偏好的图像格式。

以下示例代码演示如何基于定义的缩放比例生成形状缩略图：
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


## **创建基于边界的形状外观缩略图**
此方法允许开发人员在形状外观的边界内生成缩略图，考虑所有形状效果。生成的形状缩略图受幻灯片边界限制。要在形状外观的边界内生成幻灯片形状的缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
2. 使用幻灯片的 ID 或索引获取任意幻灯片的引用。
3. 获取以形状外观为边界的幻灯片缩略图图像。
4. 将缩略图图像保存为您偏好的图像格式。

以下示例代码基于上述步骤：
```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建一个全比例图像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

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


## **常见问题**

**保存形状缩略图时可以使用哪些图像格式？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/)，以及其他格式。形状还可以通过将其内容保存为 SVG 来[导出为矢量 SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。

**在渲染缩略图时，Shape 边界和 Appearance 边界有什么区别？**

`Shape` 使用形状的几何形状；`Appearance` 会考虑[视觉效果](/slides/zh/java/shape-effect/)(阴影、发光等)。

**如果形状被标记为隐藏会怎样？它仍会渲染为缩略图吗？**

隐藏的形状仍然是模型的一部分，可以渲染；隐藏标志影响幻灯片放映显示，但不会阻止生成形状图像。

**是否支持组形状、图表、SmartArt 和其他复杂对象？**

支持。任何以[Shape](https://reference.aspose.com/slides/java/com.aspose.slides/shape/) 表示的对象（包括[GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/java/com.aspose.slides/chart/)和[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/)）均可保存为缩略图或 SVG。

**系统安装的字体会影响文本形状缩略图的质量吗？**

会。应[提供所需字体](/slides/zh/java/custom-font/)（或[配置字体替代](/slides/zh/java/font-substitution/)），以避免不必要的回退和文本换行。