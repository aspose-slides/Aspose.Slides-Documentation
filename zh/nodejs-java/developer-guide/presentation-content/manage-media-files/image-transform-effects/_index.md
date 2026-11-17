---
title: 使用 JavaScript 在演示文稿中管理图像变换效果
linktitle: 图像变换效果
type: docs
weight: 11
url: /zh/nodejs-java/image-transform-effects/
keywords:
- 图像变换
- 图片效果
- 亮度
- 对比度
- 灰度
- 双调
- 色调
- HSL
- 颜色替换
- 模糊
- 透明度
- Alpha 效果
- 效果链
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 通过 Java 对图片框的图像变换效果进行应用、链式组合、检查、删除和验证。"
---
## **概述**

Aspose.Slides 将图片调整表示为有序的图像变换操作集合。对于图片框，首先获取框的 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 并访问 [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)。返回的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 允许您追加、枚举、检查、删除和清除效果，而无需重写原始图像字节。

本文演示了亮度和对比度、颜色变换、模糊、透明度、有序效果链、有效值、删除以及 PPTX 循环验证的完整工作流。

## **了解效果所有权和图像复用**

图像资源和显示它的图片是不同的对象：

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 存储或引用演示文稿拥有的源图像数据。
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 属于图片填充，引用图像资源并存储图像变换集合。
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) 是拥有相应图片填充、几何、裁剪设置以及其他框级格式的幻灯片形状。

因此，图像变换操作不会修改 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 中的字节。当同一 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 多次传递给 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) 时，每个新图片框都会获得其自己的 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 和其自己的变换集合。对一个框应用灰度并不会使其他框也变为灰度，即使它们复用了相同的嵌入图像资源。

相同的 [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 模型也用于其他图片填充，例如形状或幻灯片背景。以下示例重点关注图片框。

## **使用有效的参数范围和单位**

所示方法使用以下语义范围和单位。即使特定库版本未立即拒绝所有超范围值，也请保持在这些范围内；目标演示文稿格式可能会在保存或 PowerPoint 打开文件时规范化、省略或拒绝无效数据。

| 操作 | 参数 | 有效范围和单位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 保持组件不变。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | 无数值参数。Alpha 保持不变。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | 两个颜色分别用于暗像素和亮像素。`java.awt.Color` 中的 RGB 和 alpha 通道使用 `0` 到 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | 色相范围为 `0`（含）到 `360`（不含），单位为度；amount 为 `-100` 到 `100`，百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | 色相范围为 `0`（含）到 `360`（不含），单位为度；饱和度和亮度为 `-100` 到 `100`，百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | 替换颜色的通道值使用 `0` 到 `255`。现有的 alpha 值保持不变。 |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | 半径为非负值，单位为点；`grow` 为布尔值，决定模糊内容是否可以超出原始边界。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | 非负百分比。使用 `0` 到 `100` 进行普通不透明度缩放：`0` 表示完全透明，`100` 保留现有 alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` 到 `100`，百分比 alpha 阈值。低于阈值的像素变为透明，等于或高于阈值的像素变为不透明。 |

对于固定的 alpha 调制，透明度和不透明度是互补的。例如，35% 透明度对应 65% 的 alpha 调制量。

## **应用亮度和对比度**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 返回一个 [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 操作。其标量设置在创建操作时提供。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 返回计算后的只读值，您可以检查或记录。

以下示例将亮度提高 15%，对比度提高 20%，随后在不修改嵌入图像的情况下渲染预览：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 是 Office 2010 图片效果扩展，便携性不如标准 DrawingML 亮度效果。当亮度和对比度在 PPTX 循环后必须保持可编辑时，请使用 [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 并在重新打开文件后验证结果。格式限制章节对该区别有更详细的说明。

## **应用颜色变换**

颜色效果可以独立地应用于重用同一图像资源的不同图片框。以下示例创建五个框并分别应用灰度、双调、色调、HSL 调整以及颜色替换。

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) 包含两个可独立编辑的颜色参数：`color1` 映射暗像素，`color2` 映射亮像素。这使其成为一个示例，展示设置比单一标量值更复杂的效果。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 将每个像素的颜色替换为固定颜色，同时保留 alpha。它不同于 [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)，后者将一种源颜色映射到另一种颜色，并暴露源和目标颜色格式。

### **应用亮度阈值**

亮度阈值可以使扫描页面上的淡淡痕迹更易于从背景中区分。[addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 保留中间的灰度。[addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 将亮度映射为黑色或白色，而 [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 对不透明度应用阈值。

亮度阈值范围为 0% 到 100%，含。低于阈值的像素变为黑色，等于或高于阈值的像素变为白色。提升阈值会使更多色调变为黑色，因为更多像素落在阈值以下。

下载 [grayscale-swatches.png](grayscale-swatches.png) 到工作目录。每个标签给出原始灰度级别，范围 0 到 255。示例将原始图像放在两个副本旁边，并在演示文稿中保存每个副本的阈值。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中打开输出的演示文稿以比较三个框。标记为 96 的色板约有 38% 亮度（96/255）。在 20% 阈值时转为白色，在 60% 阈值时转为黑色。

![原始灰度色板旁边是亮度阈值为 20% 和 60% 时的黑白结果](luminance-threshold.png)

## **添加模糊、透明度和 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 影响所有颜色通道，包括 alpha。当模糊边缘可能超出原始图片边界时，将 `grow` 设置为 `true`。

对于均匀透明度，请使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)。它将每个现有的 alpha 值相乘，因此部分透明像素仍保持比例差异。[addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 则为所有像素分配相同的 alpha 值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 根据阈值将 alpha 转换为两级。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

其他无参数的 alpha 操作包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)，它将每个非零 alpha 设为完全不透明；[addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)，它将每个低于 100% 的 alpha 设为完全透明；以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)，它将 alpha 改为 `100% - alpha`。

## **构建有序效果链**

每个 `add...Effect` 方法将新操作追加到集合末尾。渲染器将集合视为有序管线：操作 0 的输出成为操作 1 的输入，依此类推。因此，以不同顺序排列相同操作会产生不同图像。

例如，先灰度后色调会先去除色彩信息再重新着色亮度结果；先色调后灰度会再次去除色调。类似地，alpha 替换可以覆盖先前操作计算的 alpha 值，而 alpha 调制会保留它们的相对差异。

以下示例构建四操作链，保存为 PPTX，重新打开演示文稿，检查操作类型及顺序，并渲染重新打开的结果：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

集合并未强制兼容矩阵将颜色、alpha 和模糊操作限制在不同链中。它们可以组合，但组合并非总是有用。固定颜色替换会移除早先颜色效果产生的 RGB 变化；灰度在双调后会移除两种选定颜色；alpha ceiling、floor、replacement 或 bi-level 操作可能丢弃早先创建的 alpha 细节。应根据所需的像素处理顺序构建链，而不是将其项视为无序的格式标志。

<!-- visual-explanation:image-transform-effects:start -->
[![相同的图像先经过灰度再加色调，和先加色调再经过灰度。两个最终的灰度图像具有不同的色调。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*在此示例的 Aspose.Slides for .NET 26.11 渲染中，220°、25% 的色调对灰度图像没有影响。先应用相同的色调再进行灰度处理会产生不同的色调。*
<!-- visual-explanation:image-transform-effects:end -->

## **检查可编辑和有效值**

可编辑的操作是存储在 [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 中的对象。根据效果的不同，它可能直接公开可写成员。例如， [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) 公开可写的 `radius` 和 `grow` 值，[AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) 公开可写的 `amount`，[AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) 公开可写的 `threshold`。诸如 [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) 的颜色效果则公开可变的 [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) 对象。

某些操作，包括 [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)、[HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/)、[Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/) 和 [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/)，不将创建时的标量作为可写属性暴露。要更改这些设置，需要删除该操作并在所需位置添加替代操作。

`getEffective()` 返回的有效数据是计算后的只读值。它对解析主题相关颜色和读取渲染器使用的归一化值很有用，但并不是另一种编辑界面。以下示例枚举链并检查有效值（如果相应 API 提供）：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

无参数的效果如灰度、alpha ceiling 和 alpha inverse 仍然拥有有效数据对象，但没有可打印的标量设置。它们在集合中的存在及位置即为重要信息。

## **删除或清除图像变换**

使用 [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 按索引删除单个操作。由于删除后索引会移动，建议先搜索目标，然后在枚举后删除。使用 [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 删除整个链。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

删除或清除变换仅更改图片格式。它不会删除、重新压缩或以其他方式修改复用的 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 资源。

## **考虑演示文稿格式和导出目标**

图像变换起源于 DrawingML，因此 PPTX 是效果链的首选可编辑格式。即使使用 PPTX，也不是每个操作都有相同的便携性：

- 标准 DrawingML 操作如亮度、灰度、双调、色调、HSL、模糊以及常见的 alpha 操作在 PPTX 循环中最有可能保存。若需要保持，可在生成文件后重新打开并检查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 是 Office 2010 扩展，而非标准 DrawingML 亮度操作。它可用于内存渲染，但保存并重新打开 PPTX 后不能保证仍保持为可编辑的 [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 操作。请使用 [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) 进行持久的亮度和对比度调整。
- PPT 二进制格式早于完整的 DrawingML 效果模型。保存为 PPT 可能省略不支持的操作，将链缩减为支持的子集，或近似外观。不要使用 PPT 作为复杂可编辑链的验证格式。
- 渲染为 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他可视输出时，会将支持的链应用于渲染外观。这些输出不包含可编辑的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)；光栅格式会将结果展平成像素，文档/矢量导出则存储自己的渲染表示。
- 效果不会使链接图像自包含。渲染链接图片仍然依赖于加载演示文稿时链接资源的可用性。

不同的演示文稿使用者在渲染边缘情况时可能表现不同，尤其是组合了多个 alpha 或颜色量化操作时。对于关键输出，请使用生产环境中相同的 Aspose.Slides 版本同时测试可编辑循环和最终导出格式。

## **常见问题**

**图像变换效果会修改嵌入的图像数据吗？**

不会。操作属于用于图片填充的 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)，底层的 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 字节保持不变。

**重复使用同一图像的两个图片框会共享它们的效果吗？**

不会。复用 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 可以避免重复的图像数据，但每个图片框通常拥有各自的 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 和图像变换集合。

**可以将颜色、模糊和 alpha 效果组合使用吗？**

可以。集合接受它们在同一有序链中。请考虑每个操作对前一个操作输出的影响，因为替换和阈值操作可能会丢弃之前的颜色或 alpha 细节。

**为什么有效值是只读的？**

有效数据代表渲染使用的计算值，包括已解析的颜色。若操作中存在可写成员，请在变换集合中编辑该操作；否则请删除并使用新的创建参数添加替代操作。

**应该使用哪种格式来保留变换链？**

使用 PPTX 并通过重新打开文件进行验证。传统 PPT 无法完整表示 DrawingML 效果模型，渲染导出格式仅保存外观而不包含可编辑的变换操作。