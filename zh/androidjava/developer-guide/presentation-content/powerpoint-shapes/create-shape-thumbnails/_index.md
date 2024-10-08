---
title: 创建形状缩略图
type: docs
weight: 70
url: /androidjava/create-shape-thumbnails/
---


## **概述**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java可以用于创建演示文稿文件，其中每一页对应一个幻灯片。可以通过使用Microsoft PowerPoint打开演示文稿文件来查看幻灯片。然而，开发人员有时需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for Android via Java帮助他们生成幻灯片形状的缩略图。

{{% /alert %}} 

在本主题中，我们将展示如何在不同情况下生成幻灯片缩略图：

- 在幻灯片内部生成形状缩略图。
- 为具有用户定义的尺寸的幻灯片形状生成形状缩略图。
- 在形状外观的范围内生成形状缩略图。

## **从幻灯片生成形状缩略图**
要使用Aspose.Slides for Android via Java从任何幻灯片生成形状缩略图，请执行以下操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例。
1. 使用其ID或索引获取任何幻灯片的引用。
1. [获取引用幻灯片的形状缩略图图像](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--)，缩放为默认值。
1. 将缩略图图像保存为您喜欢的图像格式。

以下示例代码向您展示了如何从幻灯片生成形状缩略图：

```java
// 实例化一个表示演示文稿文件的Presentation类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建一个全尺度图像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // 将图像以PNG格式保存到磁盘
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用用户定义的缩放因子生成形状缩略图**
要使用Aspose.Slides for Android via Java生成幻灯片的形状缩略图，请执行以下操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例。
1. 使用其ID或索引获取任何幻灯片的引用。
1. [获取引用幻灯片的形状缩略图图像](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-)，使用用户定义的尺寸。
1. 将缩略图图像保存为您喜欢的图像格式。

以下示例代码向您展示了如何根据定义的缩放因子生成形状缩略图：

```java
// 实例化一个表示演示文稿文件的Presentation类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建一个全尺度图像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // 将图像以PNG格式保存到磁盘
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **生成形状的外观缩略图**
这种创建形状缩略图的方法允许开发人员在形状外观的范围内生成缩略图。它考虑到了所有的形状效果。生成的形状缩略图受幻灯片范围的限制。要在其外观的范围内生成幻灯片形状的缩略图，请执行以下操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)类的实例。
1. 使用其ID或索引获取任何幻灯片的引用。
1. 获取参考幻灯片的缩略图图像，形状范围作为外观。
1. 将缩略图图像保存为您喜欢的图像格式。

以下示例代码基于上述步骤：

```java
// 实例化一个表示演示文稿文件的Presentation类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建一个全尺度图像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // 将图像以PNG格式保存到磁盘
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```