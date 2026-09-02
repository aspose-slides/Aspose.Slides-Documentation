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
- 可视边界
- 形状边界
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 从 PowerPoint 幻灯片生成高质量的形状缩略图——轻松创建并导出演示文稿缩略图。"
---
## **介绍**

Aspose.Slides for Android via Java 可用于创建演示文稿文件，每页对应一张幻灯片。可以通过 Microsoft PowerPoint 打开演示文稿文件来查看幻灯片。然而，开发人员有时需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for Android via Java 可帮助他们生成幻灯片形状的缩略图图像。

在本主题中，我们将展示如何在不同情况下生成幻灯片缩略图：

- 在幻灯片内部生成形状缩略图。
- 为幻灯片形状生成具有用户定义尺寸的形状缩略图。
- 在形状外观的范围内生成形状缩略图。

## **从幻灯片生成形状缩略图**

使用 Aspose.Slides for Android via Java 从任意幻灯片生成形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例。
1. 使用幻灯片的 ID 或索引获取任意幻灯片的引用。
1. [获取形状缩略图图像](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShape#getImage--) 的引用幻灯片的默认比例。
1. 将缩略图图像保存为您喜欢的图像格式。

```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建全比例图像
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

## **生成用户定义缩放因子的缩略图**

使用 Aspose.Slides for Android via Java 生成幻灯片的形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例。
1. 使用幻灯片的 ID 或索引获取任意幻灯片的引用。
1. [获取具有用户定义尺寸的形状缩略图图像](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) 的引用幻灯片。
1. 将缩略图图像保存为您喜欢的图像格式。

```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建全比例图像
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

此方法用于创建形状缩略图，允许开发人员在形状外观的边界内生成缩略图。它会考虑所有形状效果。生成的形状缩略图受到幻灯片边界的限制。要在形状外观的边界内生成幻灯片形状的缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 类的实例。
1. 使用幻灯片的 ID 或索引获取任意幻灯片的引用。
1. 获取引用幻灯片的缩略图图像，使用形状边界作为外观。
1. 将缩略图图像保存为您喜欢的图像格式。

```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 创建全比例图像
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

## **获取形状的实际可视边界**

[IShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/) 的框架属性——其 `getX()`、`getY()`、`getWidth()` 和 `getHeight()` 方法——描述了存储在演示模型中的矩形。实际渲染的内容可能超出该框架或占用不同的轴对齐矩形。旋转、轮廓、箭头、文本布局和溢出、生成的 SmartArt 几何形状以及其他渲染效果都可能改变占用的区域。

使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#getVisualBounds--) 可在不创建图像的情况下计算该占用区域。该方法返回以幻灯片坐标表示的 [RectF](https://developer.android.com/reference/android/graphics/RectF)。返回的矩形不会被裁剪到幻灯片上，因此当内容超出幻灯片原点时，其坐标可能为负。

[Shape.getVisualBounds](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#getVisualBounds--) 目前未在 [IShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/) 接口中声明。因此，请将从幻灯片形状集合获取的形状保持为接口类型的值，并仅在调用该方法时进行强制转换。

以下示例获取并比较框架和可视边界：

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

相同的 [RectF](https://developer.android.com/reference/android/graphics/RectF) 可用于将相邻形状对齐到其左、右、上或下边缘；在生成的布局中预留足够的空间；或检测内容是否超出允许的区域。对于 SmartArt、文本框、箭头、图片、旋转形状和组合形状等，存储的框架可能未能完整表示渲染结果，视觉边界尤其有用。

当您需要布局或验证的坐标且不需要位图时，请使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#getVisualBounds--)。当您需要渲染形状时，请使用 [IShape.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getImage--)。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shapethumbnailbounds/) 时，`ShapeThumbnailBounds.Shape` 根据形状边界（包括轮廓设置）确定图像大小，而 `ShapeThumbnailBounds.Appearance` 根据形状的外观确定大小并将结果限制在幻灯片边界内。相反，[Shape.getVisualBounds](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#getVisualBounds--) 只返回计算得到的矩形且不裁剪到幻灯片。

## **常见问题**

**保存形状缩略图时可以使用哪些图像格式？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imageformat/)，以及其他格式。形状还可以通过将其内容保存为 SVG 来[导出为矢量 SVG](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。

**在渲染缩略图时，Shape 边界和 Appearance 边界有什么区别？**

`Shape` 使用形状的几何信息；`Appearance` 会考虑[视觉效果](/slides/zh/androidjava/shape-effect/)(阴影、发光等)。

**如果形状被标记为隐藏，会怎样？它仍会生成缩略图吗？**

隐藏的形状仍然是模型的一部分且可以渲染；隐藏标志只影响幻灯片放映的显示，而不会阻止生成形状的图像。

**是否支持组合形状、图表、SmartArt 和其他复杂对象？**

是的。任何表示为[Shape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/)的对象（包括[GroupShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/chart/)、以及[SmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/smartart/)）都可以保存为缩略图或 SVG。

**系统安装的字体会影响文本形状缩略图的质量吗？**

是的。您应[提供所需字体](/slides/zh/androidjava/custom-font/)（或[配置字体替代](/slides/zh/androidjava/font-substitution/)），以避免不必要的回退和文本重排。