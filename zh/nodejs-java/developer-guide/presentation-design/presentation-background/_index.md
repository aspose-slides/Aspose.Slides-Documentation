---
title: 管理 JavaScript 中的演示文稿背景
linktitle: 幻灯片背景
type: docs
weight: 20
url: /zh/nodejs-java/presentation-background/
keywords:
- 演示文稿背景
- 幻灯片背景
- 纯色
- 渐变颜色
- 图像背景
- 背景透明度
- 背景属性
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js 在 PowerPoint 和 OpenDocument 文件中设置动态背景，并通过代码技巧提升您的演示文稿。"
---

## **概述**

纯色、渐变和图像通常用于幻灯片背景。您可以为 **普通幻灯片**（单个幻灯片）或 **母版幻灯片**（一次应用于多个幻灯片）设置背景。

![PowerPoint 背景](powerpoint-background.png)

## **为普通幻灯片设置纯色背景**

Aspose.Slides 允许您在演示文稿中为特定幻灯片设置纯色背景——即使演示文稿使用了母版幻灯片。此更改仅适用于所选幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) 设置为 `Solid`。
4. 在 [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) 上使用 [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) 方法来指定纯色背景颜色。
5. 保存修改后的演示文稿。

以下 JavaScript 示例展示如何将蓝色纯色设置为普通幻灯片的背景：
```js
// 创建 Presentation 类的实例。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 将幻灯片的背景颜色设置为蓝色。
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // 将演示文稿保存到磁盘。
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **为母版幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿的母版幻灯片设置纯色背景。母版幻灯片充当控制所有幻灯片格式的模板，因此当您为母版幻灯片的背景选择纯色时，它会应用于每一张幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 将母版幻灯片的 [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/)（通过 `getMasters`）设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) 设置为 `Solid`。
4. 使用 [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) 方法来指定纯色背景颜色。
5. 保存修改后的演示文稿。

以下 JavaScript 示例展示如何将绿色纯色设置为母版幻灯片的背景：
```js
// 创建 Presentation 类的实例。
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // 将母版幻灯片的背景颜色设置为森林绿。
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // 将演示文稿保存到磁盘。
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **为幻灯片设置渐变背景**

渐变是一种通过颜色逐渐变化实现的图形效果。将其用作幻灯片背景时，渐变可以使演示文稿看起来更具艺术性和专业性。Aspose.Slides 允许您为幻灯片设置渐变颜色作为背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) 设置为 `Gradient`。
4. 在 [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) 上使用 [getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) 方法来配置所需的渐变设置。
5. 保存修改后的演示文稿。

以下 JavaScript 示例展示如何将渐变颜色设置为幻灯片的背景：
```js
// 创建 Presentation 类的实例。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 将渐变效果应用于背景。
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // 将演示文稿保存到磁盘。
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **将图像设为幻灯片背景**

除了纯色和渐变填充外，Aspose.Slides 还允许您使用图像作为幻灯片背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) 设置为 `Picture`。
4. 加载要用作幻灯片背景的图像。
5. 将图像添加到演示文稿的图像集合中。
6. 在 [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) 上使用 [getPictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) 方法将图像指定为背景。
7. 保存修改后的演示文稿。

以下 JavaScript 示例展示如何将图像设置为幻灯片的背景：
```js
// 创建 Presentation 类的实例。
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 设置背景图像属性。
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // 加载图像。
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // 将图像添加到演示文稿的图像集合中。
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // 将演示文稿保存到磁盘。
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


以下代码示例展示如何将背景填充类型设置为平铺图片并修改平铺属性：
```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // 设置用于背景填充的图像。
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // 设置图片填充模式为平铺并调整平铺属性。
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}}
阅读更多: [**将图片平铺为纹理**](/slides/zh/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **更改背景图像透明度**

您可能希望调整幻灯片背景图像的透明度，以使幻灯片内容更突出。以下 JavaScript 代码展示如何更改幻灯片背景图像的透明度：
```js
var transparencyValue = 30; // 例如。

// 获取图片变换操作的集合。
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// 查找现有的固定百分比透明度效果。
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// 设置新的透明度值。
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **获取幻灯片背景值**

Aspose.Slides 提供 `BackgroundEffectiveData` 类用于检索幻灯片的有效背景值。该类公开有效的 [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) 和 [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/)。

使用 [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/) 类的 `getBackground` 方法，您可以获取幻灯片的有效背景。

以下 JavaScript 示例展示如何获取幻灯片的有效背景值：
```js
// 创建 Presentation 类的实例。
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // 检索有效背景，考虑母版、布局和主题。
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```


## **常见问题**

**我可以重置自定义背景并恢复主题/布局背景吗？**

是的。移除幻灯片的自定义填充，背景将再次从相应的 [layout](/slides/zh/nodejs-java/slide-layout/)/[master](/slides/zh/nodejs-java/slide-master/) 幻灯片（即 [theme background](/slides/zh/nodejs-java/presentation-theme/)）继承。

**如果我稍后更改演示文稿的主题，背景会怎样？**

如果幻灯片有自己的填充，它将保持不变。如果背景是从 [layout](/slides/zh/nodejs-java/slide-layout/)/[master](/slides/zh/nodejs-java/slide-master/) 继承的，则会更新以匹配 [new theme](/slides/zh/nodejs-java/presentation-theme/)。