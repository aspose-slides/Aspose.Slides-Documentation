---
title: 在 JavaScript 中创建演示文稿形状的缩略图
linktitle: 形状缩略图
type: docs
weight: 70
url: /zh/nodejs-java/create-shape-thumbnails/
keywords:
- 形状缩略图
- 形状图像
- 渲染形状
- 形状渲染
- 可视边界
- 形状边界
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 和 Aspose.Slides for Node.js 从 PowerPoint 幻灯片生成高质量的形状缩略图——轻松创建和导出演示文稿缩略图。"
---
## **介绍**

Aspose.Slides 用于创建每页为幻灯片的演示文稿文件。可以使用 Microsoft PowerPoint 打开这些演示文稿文件进行查看。但有时，开发人员可能需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides 可帮助您生成幻灯片形状的缩略图。本文阐述了如何使用此功能。

本文说明了以不同方式生成幻灯片缩略图的方法：

- 在幻灯片内部生成形状缩略图。
- 为幻灯片形状使用用户自定义尺寸生成形状缩略图。
- 在形状外观的边界内生成形状缩略图。

## **从幻灯片生成形状缩略图**
要使用 Aspose.Slides for Node.js via Java 从任意幻灯片生成形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation) 类的实例。
1. 使用幻灯片的 ID 或索引获取任意幻灯片的引用。
1. [获取形状缩略图图像](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Shape#getImage--)（使用默认比例）对应于引用的幻灯片。
1. 将缩略图图像保存为您喜欢的图像格式。

下面的示例代码展示了如何从幻灯片生成形状缩略图：

```javascript
// 实例化一个表示演示文件的 Presentation 类
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 创建完整比例的图像
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // 将图像以 PNG 格式保存到磁盘
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **使用用户定义的缩放因子生成形状缩略图**
要使用 Aspose.Slides for Node.js via Java 为幻灯片生成形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation) 类的实例。
1. 使用幻灯片的 ID 或索引获取任意幻灯片的引用。
1. [获取形状缩略图图像](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Shape#getImage-int-float-float-)（使用用户定义的尺寸）对应于引用的幻灯片。
1. 将缩略图图像保存为您喜欢的图像格式。

下面的示例代码展示了如何基于定义的缩放因子生成形状缩略图：

```javascript
// 实例化一个表示演示文件的 Presentation 类
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 创建完整比例的图像
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // 将图像以 PNG 格式保存到磁盘
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **生成具有边界的形状缩略图**
此方法允许开发人员在形状外观的边界内生成缩略图，考虑了所有形状效果。生成的形状缩略图受幻灯片边界限制。要在形状外观的边界内生成幻灯片形状的缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation) 类的实例。
1. 使用幻灯片的 ID 或索引获取任意幻灯片的引用。
1. 使用形状外观边界获取引用幻灯片的缩略图图像。
1. 将缩略图图像保存为您喜欢的图像格式。

下面的示例代码基于上述步骤：

```javascript
// 实例化一个表示演示文件的 Presentation 类
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 创建完整比例的图像
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // 将图像以 PNG 格式保存到磁盘
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **获取形状的实际可视边界**

[Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/) 的框架属性——`getX()`、`getY()`、`getWidth()` 和 `getHeight()` 方法——描述了存储在演示模型中的矩形。实际渲染的内容可能会超出该框架或占据不同的轴对齐矩形。旋转、轮廓、箭头、文本布局和溢出、生成的 SmartArt 几何以及其他渲染效果都可能改变占用区域。

使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getVisualBounds--) 可在不创建图像的情况下计算该占用区域。该方法返回一个以幻灯片坐标表示的 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 对象。返回的矩形未被裁剪到幻灯片范围，因此当内容超出幻灯片原点时，其坐标可能为负。

下面的示例获取并比较框架边界和可视边界：

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

相同的矩形可用于将相邻形状对齐到其左侧、右侧、顶部或底部边缘；在生成的布局中预留足够空间；或检测内容是否超出允许的区域。可视边界在 SmartArt、文本框、箭头、图片、旋转形状和组合形状中特别有用，因为存储的框架可能并不代表完整的渲染结果。

当您需要布局或验证的坐标且不需要位图时，请使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getVisualBounds--)。当您需要渲染形状时，请使用 [Shape.getImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getImage--)。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapethumbnailbounds/)，`ShapeThumbnailBounds.Shape` 根据形状边界（包括轮廓设置）确定图像大小，而 `ShapeThumbnailBounds.Appearance` 根据形状的外观确定大小并将结果限制在幻灯片边界内。相比之下，[Shape.getVisualBounds](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getVisualBounds--) 只返回计算得到的矩形且不裁剪到幻灯片。

## **常见问题**

**保存形状缩略图时可以使用哪些图像格式？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/imageformat/)，以及其他格式。形状还可以通过将其内容保存为 SVG 来[导出为矢量 SVG](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/writeassvg/)。

**在渲染缩略图时，Shape 边界和 Appearance 边界有什么区别？**

`Shape` 使用形状的几何信息；`Appearance` 会考虑[视觉效果](/slides/zh/nodejs-java/shape-effect/)（阴影、光晕等）。

**如果形状被标记为隐藏会怎样？它仍会生成缩略图吗？**

隐藏的形状仍是模型的一部分，可以渲染；隐藏标记仅影响幻灯片放映的显示，不会阻止生成形状图像。

**是否支持组合形状、图表、SmartArt 和其他复杂对象？**

支持。任何以 [Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/) 形式表示的对象（包括 [GroupShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/) 和 [SmartArt](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartart/)）均可保存为缩略图或 SVG。

**系统已安装的字体会影响文本形状缩略图的质量吗？**

会。您应[提供所需字体](/slides/zh/nodejs-java/custom-font/)（或[配置字体替换](/slides/zh/nodejs-java/font-substitution/)），以避免不必要的回退和文本重排。