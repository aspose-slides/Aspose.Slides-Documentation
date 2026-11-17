---
title: 在 Android 上管理演示文稿中的图像变换效果
linktitle: 图像变换效果
type: docs
weight: 11
url: /zh/androidjava/image-transform-effects/
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
- Android
- Java
- Aspose.Slides
description: "通过 Java 使用 Aspose.Slides for Android 对图片框的图像变换效果进行应用、链式处理、检查、移除和验证。"
---
## **概览**

Aspose.Slides 将图片调整表示为有序的图像变换操作集合。对于图片框，首先获取框的 [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) 并访问 [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--)。返回的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) 允许您追加、枚举、检查、移除和清除效果，而无需重写原始图像字节。

本文演示了亮度和对比度、颜色转换、模糊、透明度、有序效果链、有效值、移除以及 PPTX 循环验证的完整工作流。

## **了解效果所有权和图像复用**

图像资源和显示它的图片是不同的对象：

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) 存储或引用演示文稿拥有的源图像数据。
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) 属于图片填充并引用图像资源，同时存储图像变换集合。
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) 是拥有相关图片填充、几何形状、裁剪设置以及其他帧级格式的幻灯片形状。

因此，图像变换操作不会修改 [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) 中的字节。当相同的 `IPPImage` 多次传递给 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 时，每个新图片框都会获得其自己的 `ISlidesPicture` 和其自己的变换集合。对一个框应用灰度并不会使其他框也变为灰度，即使它们都复用了相同的嵌入图像资源。

相同的 `ISlidesPicture.getImageTransform` 模型也被其他图片填充使用，例如形状或幻灯片背景。下面的示例侧重于图片框。

## **使用有效的参数范围和单位**

演示的方法使用以下语义范围和单位。即使特定库版本未立即拒绝每个超出范围的值，也请保持在这些范围内；目标演示文稿格式可能在保存时或 PowerPoint 打开文件时对无效数据进行规范化、忽略或拒绝。

| 操作 | 参数 | 有效范围和单位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 保持组件不变。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | 无 | 无数值参数。Alpha 保持不变。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | 用于暗像素和亮像素的两种颜色。`android.graphics.Color` 使用的 RGB 和 alpha 通道值范围为 `0` 到 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | 色相 `hue` 为 `0`（含）至 `360`（不含）度；`amount` 为 `-100` 到 `100`，百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | 色相 `hue` 为 `0`（含）至 `360`（不含）度；饱和度和亮度为 `-100` 到 `100`，百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | 替换颜色的通道值范围为 `0` 到 `255`。现有的 alpha 值保持不变。 |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | 半径为非负值，单位为点（points）；`grow` 为布尔值，控制模糊内容是否可以延伸超出原始边界。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | 非负百分比。使用 `0` 到 `100` 进行普通的不透明度缩放：`0` 完全透明，`100` 保留现有的 alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` 到 `100`，百分比 alpha 阈值。低于该值的像素变为透明，等于或高于该值的像素变为不透明。 |

对于固定的 alpha 调制，透明度和不透明度是互补的。例如，35% 的透明度对应 65% 的 alpha 调制量。

## **应用亮度和对比度**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) 返回一个 [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) 操作。其标量设置在创建操作时提供。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) 返回计算后的只读值，可供检查或记录。

下面的示例将亮度提高 15%，对比度提高 20%，然后在不修改嵌入图像的情况下渲染预览：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) 是 Office 2010 的图片效果扩展，便携性不如标准的 DrawingML 亮度效果。当亮度和对比度在 PPTX 循环后仍需保持可编辑时，请使用 [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) 并在重新打开文件后验证结果。格式限制章节对该区别作了更详细的说明。

## **应用颜色转换**

颜色效果可以独立地应用于复用同一图像资源的不同图片框。下面的示例创建了五个框，并应用灰度、双调、色调、HSL 调整以及颜色替换。

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) 包含两个可独立编辑的颜色参数：`color1` 对应暗像素，`color2` 对应亮像素。这使它成为一个示例，展示了设置比单一标量值更复杂的效果。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) 将每个像素的颜色替换为固定颜色，同时保留 alpha。它不同于 [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--)，后者将一种源颜色映射到另一种颜色，并公开源颜色和目标颜色的格式。

### **应用亮度阈值**

亮度阈值可以使扫描页面上微弱的痕迹更加容易与背景区分。[addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) 保留中间的灰色阶调。[addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) 将亮度映射为黑或白，而 [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) 对不透明度应用阈值。

亮度阈值范围为 0% 到 100%，包括两端。低于阈值的像素变为黑色。等于或高于阈值的像素变为白色。提高阈值会使更多的色调变为黑色，因为它们更多落在阈值以下。

将 [grayscale-swatches.png](grayscale-swatches.png) 下载到工作目录。每个标签给出原始灰度级别，范围为 0 到 255。示例将原始图像放在两个副本旁边，并在演示文稿中保存每个副本的阈值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中打开输出的演示文稿，以比较这三个框。标记为 96 的色板约有 38% 的亮度（96/255）。在 20% 阈值时变为白色，在 60% 阈值时变为黑色。

![原始灰度色板旁边是亮度阈值 20% 和 60% 时的黑白结果](luminance-threshold.png)

## **添加模糊、透明度和 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) 对所有颜色通道（包括 alpha）均有效。当模糊边缘可能超出原始图片边界时，将 `grow` 设置为 `true`。

要实现统一透明度，请使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-)。它会乘以每个现有的 alpha 值，从而使部分透明像素保持比例差异。[addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) 则为所有像素分配相同的 alpha 值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) 根据阈值将 alpha 转换为两个层级。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

其他无参数的 alpha 操作包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)，将所有非零 alpha 完全设为不透明；[addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)，将所有低于 100% 的 alpha 完全设为透明；以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--)，将 alpha 改为 `100% - alpha`。

## **构建有序效果链**

每个 `add...Effect` 方法都会在集合末尾追加一个新操作。渲染器将集合视为有序管道：操作 0 的输出成为操作 1 的输入，依此类推。因此，相同的操作若顺序不同会产生不同的图像。

例如，先灰度后色调会先去除色彩信息，再对亮度结果重新上色。先色调后灰度则会再次去除色调。类似地，alpha 替换可以覆盖早前操作计算的 alpha 值，而 alpha 调制则保留它们的相对差异。

下面的示例构建了一个四操作链，将其保存为 PPTX，重新打开演示文稿，检查操作类型及其顺序，并渲染重新打开的结果：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

集合并未强制兼容性矩阵将颜色、alpha 和模糊操作限制为独立链。它们可以组合，但并非所有组合都有用。固定的颜色替换会移除早期颜色效果产生的 RGB 变化；双调后再做灰度会移除两种选定颜色；alpha ceiling、floor、replacement 或 bi-level 操作会丢弃早期创建的 alpha 细节。请根据所需的像素处理顺序构建链，而不是把这些项目当作无序的格式标志。

<!-- visual-explanation:image-transform-effects:start -->
[![相同的图像先经过灰度再色调，和先色调再灰度。最终的两个灰度图像色调不同。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*在此示例的 Aspose.Slides for .NET 26.11 渲染中，220°、25% 的色调对灰度图像不起作用。先应用相同的色调再进行灰度会产生不同的色调。*
<!-- visual-explanation:image-transform-effects:end -->

## **检查可编辑和有效值**

可编辑的操作是存储在 `ISlidesPicture.getImageTransform` 中的对象。根据效果的不同，它可能直接公开可写成员。例如，[IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) 公开可写的 `radius` 和 `grow` 值，[IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) 公开可写的 `amount`，以及 [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) 公开可写的 `threshold`。像 [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) 这样的颜色效果会公开可变的 [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) 对象。

包括 [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/)、[ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/) 和 [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/) 在内的某些操作接口并未将其创建时的标量公开为可写属性。若需更改这些设置，请删除该操作并在所需位置添加替代操作。

`getEffective()` 返回的有效数据是计算后的只读值。它对于解析主题相关颜色以及读取渲染器使用的归一化值很有帮助，但并不是另外的编辑界面。下面的示例枚举链并在相应 API 提供的情况下检查有效值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

像灰度、alpha ceiling 和 alpha inverse 这样的无参数效果仍然有有效数据对象，只是没有可打印的标量设置。它们在集合中的存在和位置才是重要信息。

## **移除或清除图像变换**

使用 [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) 按索引移除单个操作。由于移除后索引会移动，先搜索目标再在枚举后移除。使用 [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) 可清除整个链。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

移除或清除变换仅更改图片的格式设置。它不会删除、重新压缩或以其他方式修改复用的 [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) 资源。

## **考虑演示文稿格式和导出目标**

图像变换源自 DrawingML，因此 PPTX 是效果链的首选可编辑格式。即使使用 PPTX，也并非每个操作具有相同的可移植性：

- 标准 DrawingML 操作，如亮度、灰度、双调、色调、HSL、模糊以及常见的 alpha 操作，在 PPTX 循环中存活的可能性最高。当需要保持可编辑性时，请始终重新打开生成的文件并检查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) 是 Office 2010 的扩展，而非标准 DrawingML 亮度操作。它可用于内存渲染，但在保存并重新打开 PPTX 后不保证仍保持为可编辑的 [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/)。请优先使用 [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) 以实现持久的亮度和对比度调整。
- 二进制 PPT 格式早于完整的 DrawingML 效果模型。保存为 PPT 可能会省略不受支持的操作，将链缩减为受支持的子集，或近似外观。不要将 PPT 用作复杂可编辑链的验证格式。
- 渲染为 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他可视输出时，会将受支持的链应用于渲染后的外观。这些输出不包含可编辑的 `IImageTransformOperationCollection`；栅格格式会将结果展平成像素，文档/矢量导出会存储其自己的渲染表示。
- 效果并不会使链接的图像变成自包含。渲染链接图片仍依赖于加载演示文稿时链接资源的可用性。

不同的演示文稿读取器在渲染边缘情况时可能表现不同，尤其是当组合了多个 alpha 或颜色量化操作时。对于关键输出，请使用生产环境中相同的 Aspose.Slides 版本同时测试可编辑的循环和最终导出格式。

## **FAQ**

**图像变换效果会修改嵌入的图像数据吗？**

No. The operations belong to the `ISlidesPicture` used by the picture fill. The underlying `IPPImage` bytes remain unchanged.

**两个复用相同图像的图片框会共享它们的效果吗？**

No. Reusing an `IPPImage` avoids duplicate image data, but each picture frame normally has a separate `ISlidesPicture` and image transform collection.

**可以组合颜色、模糊和 alpha 效果吗？**

Yes. The collection accepts them in one ordered chain. Consider what each operation does to the output of the previous one because replacement and threshold operations may discard earlier color or alpha detail.

**为何有效值是只读的？**

Effective data represents calculated values used for rendering, including resolved colors. Edit the operation stored in the transform collection where writable members exist; otherwise remove it and add a replacement with new creation parameters.

**应使用哪种格式来保留变换链？**

Use PPTX and verify the file by reopening it. Legacy PPT cannot represent the full DrawingML effect model, and rendered export formats preserve appearance rather than editable transform operations.