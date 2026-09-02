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
- 可视边界
- 形状边界
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 从 PowerPoint 幻灯片生成高质量的形状缩略图——轻松创建并导出演示文稿缩略图。"
---
## **简介**

Aspose.Slides for Java 可用于创建演示文稿文件，每页对应一张幻灯片。可以使用 Microsoft PowerPoint 打开演示文稿文件来查看幻灯片。然而，开发人员有时需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for Java 可帮助生成幻灯片形状的缩略图。

本文说明了如何以不同方式生成幻灯片缩略图：

- 在幻灯片内部生成形状缩略图。
- 为幻灯片形状生成具有用户自定义尺寸的形状缩略图。
- 在形状外观的边界内生成形状缩略图。

## **从幻灯片生成形状缩略图**
使用 Aspose.Slides for Java 从任意幻灯片生成形状缩略图，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. 在默认比例下，获取引用幻灯片的 [获取形状缩略图](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getImage--)。
1. 按需要的图像格式保存缩略图。

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

## **生成用户自定义缩放因子的缩略图**
使用 Aspose.Slides for Java 生成幻灯片形状的缩略图，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. 获取具有用户自定义尺寸的形状缩略图 [获取形状缩略图](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getImage-int-float-float-)。
1. 按需要的图像格式保存缩略图。

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
此方法可让开发人员在形状外观的边界内生成缩略图。它会考虑所有形状效果。生成的形状缩略图受幻灯片边界限制。要在形状外观的边界内生成幻灯片形状的缩略图，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. 获取引用幻灯片的缩略图，并使用形状边界作为外观。
1. 按需要的图像格式保存缩略图。

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

[IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/) 的框架属性——其 `getX()、getY()、getWidth()、getHeight()` 方法——描述了存储在演示模型中的矩形。实际渲染的内容可能超出该框架或占用不同的轴对齐矩形。旋转、轮廓、箭头、文本布局和溢出、生成的 SmartArt 几何形状以及其他渲染效果都可能改变占用的区域。

使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#getVisualBounds--) 在不创建图像的情况下计算该占用区域。该方法返回以幻灯片坐标表示的 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html)。返回的矩形未被裁剪到幻灯片上，因此当内容超出幻灯片原点时，其坐标可能为负值。

当前 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/) 接口未声明 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#getVisualBounds--)。因此，请将从幻灯片形状集合获取的形状保持为接口类型，仅在调用该方法时进行强制转换。

以下示例获取并比较框架和可视边界：

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

相同的 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 可用于将相邻形状对齐到其左、右、上或下边缘；在生成的布局中预留足够空间；或检测超出允许区域的内容。可视边界对于 SmartArt、文本框、箭头、图片、旋转形状和组形状尤为有用，因为存储的框架可能并未表示完整的渲染结果。

当需要布局或验证坐标且不需要位图时，请使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#getVisualBounds--)。当需要渲染形状时，请使用 [IShape.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getImage--)。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shapethumbnailbounds/)，`ShapeThumbnailBounds.Shape` 按形状边界（包括轮廓设置）调整图像大小，而 `ShapeThumbnailBounds.Appearance` 按形状外观调整并将结果限制在幻灯片边界内。相比之下，[Shape.getVisualBounds](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#getVisualBounds--) 仅返回计算出的矩形，并且不会将其裁剪到幻灯片上。

## **常见问题**

**保存形状缩略图时可以使用哪些图像格式？**

支持的格式包括 [PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imageformat/)，以及其他格式。形状也可以通过将形状内容保存为 SVG 来 [导出为矢量 SVG](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。

**在渲染缩略图时，Shape 边界与 Appearance 边界有什么区别？**

`Shape` 使用形状的几何；`Appearance` 会考虑 [视觉效果](/slides/zh/java/shape-effect/)（阴影、发光等）。

**如果形状标记为隐藏会怎样？它仍会生成缩略图吗？**

隐藏的形状仍然是模型的一部分，并且可以渲染；隐藏标记仅影响幻灯片放映的显示，不会阻止生成形状图像。

**是否支持组形状、图表、SmartArt 和其他复杂对象？**

是的。任何以 [Shape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/) 表示的对象（包括 [GroupShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh/java/com.aspose.slides/chart/) 和 [SmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/smartart/)）都可以保存为缩略图或 SVG。

**系统安装的字体会影响文本形状缩略图的质量吗？**

会的。您应当 [提供所需字体](/slides/zh/java/custom-font/)（或 [配置字体替换](/slides/zh/java/font-substitution/)），以避免不必要的回退和文本换行。