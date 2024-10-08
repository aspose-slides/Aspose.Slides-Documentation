---
title: 创建形状缩略图
type: docs
weight: 70
url: /java/create-shape-thumbnails/
---


## **概述**
{{% alert color="primary" %}} 

Aspose.Slides for Java 可用于创建演示文件，文件中的每一页对应一个幻灯片。可以通过使用 Microsoft PowerPoint 打开演示文件来查看幻灯片。然而，开发人员有时需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for Java 有助于生成幻灯片形状的缩略图像。

{{% /alert %}} 

在本主题中，我们将展示如何在不同情况下生成幻灯片缩略图：

- 在幻灯片内部生成形状缩略图。
- 为具有用户定义尺寸的幻灯片形状生成形状缩略图。
- 在形状外观的边界内生成形状缩略图。

## **从幻灯片生成形状缩略图**
要使用 Aspose.Slides for Java 从任何幻灯片生成形状缩略图，请执行以下操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任何幻灯片的引用。
1. [获取引用幻灯片的形状缩略图像](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--)，默认为比例。
1. 将缩略图像以您选择的图像格式保存。

以下示例代码向您展示了如何从幻灯片生成形状缩略图：

```java
// 实例化表示演示文件的 Presentation 类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建全规模图像
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

## **使用用户定义缩放因子生成形状缩略图**
要使用 Aspose.Slides for Java 生成幻灯片的形状缩略图，请执行以下操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任何幻灯片的引用。
1. [获取具有用户定义尺寸的引用幻灯片的形状缩略图像](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-)。
1. 将缩略图像以您选择的图像格式保存。

以下示例代码向您展示了如何基于定义的缩放因子生成形状缩略图：

```java
// 实例化表示演示文件的 Presentation 类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建全规模图像
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

## **生成形状外观的边界缩略图**
这种创建形状缩略图的方法允许开发人员在形状外观的边界内生成缩略图。它考虑了所有形状效果。生成的形状缩略图受幻灯片边界限制。要在形状外观的边界内生成幻灯片形状的缩略图，请执行以下操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任何幻灯片的引用。
1. 获取引用幻灯片的缩略图像，形状的边界作为外观。
1. 将缩略图像以您选择的图像格式保存。

以下示例代码基于上述步骤：

```java
// 实例化表示演示文件的 Presentation 类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建全规模图像
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