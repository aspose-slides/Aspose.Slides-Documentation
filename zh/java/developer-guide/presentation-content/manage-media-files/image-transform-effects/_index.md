---
title: 使用 Java 管理演示文稿中的图像变换效果
linktitle: 图像变换效果
type: docs
weight: 11
url: /zh/java/image-transform-effects/
keywords:
- 图像变换
- 图片效果
- 亮度
- 对比度
- 灰度
- 双音
- 色调
- HSL
- 颜色替换
- 模糊
- 透明度
- Alpha 效果
- 效果链
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 对图片框的图像变换效果进行应用、链式、检查、删除和验证。"
---
## **概览**

Aspose.Slides 将图片调整表示为有序的图像变换操作集合。对于图片框，首先获取框的 [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) 并访问 [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--)。返回的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) 允许在不重新写入原始图像字节的情况下追加、枚举、检查、删除和清除效果。

本文演示了亮度和对比度、颜色变换、模糊、透明度、有序效果链、有效值、删除以及 PPTX 循环验证的完整工作流。

## **了解效果归属和图像复用**

图像资源和显示它的图片是不同的对象：

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) 存储或引用演示文稿拥有的源图像数据。
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) 属于图片填充，指向图像资源并保存图像变换集合。
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) 是拥有相关图片填充、几何形状、裁剪设置和其他框级格式的幻灯片形状。

因此，图像变换操作并不修改 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) 中的字节。当同一个 `IPPImage` 多次传递给 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 时，每个新图片框都会获得自己的 `ISlidesPicture` 和自己的变换集合。对一个框应用灰度并不会使其他框变灰，即使它们复用了同一嵌入图像资源。

相同的 `ISlidesPicture.getImageTransform` 模型也用于其他图片填充，例如形状或幻灯片背景。下面的示例聚焦于图片框。

## **使用有效的参数范围和单位**

演示的方法使用下列语义范围和单位。即使特定库版本未立即拒绝所有超出范围的值，也请保持在这些范围内；目标演示文稿格式可能会在保存或 PowerPoint 打开文件时规范化、忽略或拒绝无效数据。

| 操作 | 参数 | 有效范围和单位 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 保持组件不变。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | 无 | 无数值参数。Alpha 不变。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | 两种颜色分别用于暗像素和亮像素。`java.awt.Color` 的 RGB 和 Alpha 通道取值范围为 `0` 到 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | hue 为 `0`（包含）到 `360`（不包含）度；amount 为 `-100` 到 `100`，百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | hue 为 `0`（包含）到 `360`（不包含）度；饱和度和亮度为 `-100` 到 `100`，百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | 替换颜色的通道值在 `0` 到 `255` 之间。现有的 Alpha 值保持不变。 |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | radius 为非负值，单位为磅；`grow` 为布尔值，控制模糊内容是否可以超出原始边界。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | 非负百分比。使用 `0` 到 `100` 实现普通不透明度缩放：`0` 完全透明，`100` 保持原有 Alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` 到 `100`，百分比 Alpha 阈值。低于阈值的像素变为透明，等于或高于阈值的像素变为不透明。 |

对于固定的 Alpha 调制，透明度和不透明度是互补的。例如，35% 透明度对应 65% 的 Alpha 调制量。

## **应用亮度和对比度**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) 返回一个 [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) 操作。其标量设置在创建操作时提供。[BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) 返回计算后的只读值，可供检查或记录。

下面的示例将亮度提高 15%，对比度提高 20%，随后在不修改嵌入图像的情况下渲染预览：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) 是 Office 2010 的图片效果扩展，便携性低于标准 DrawingML 亮度效果。当亮度和对比度在 PPTX 循环后仍需保持可编辑时，请使用 [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) 并在重新打开文件后验证结果。格式限制章节对该区别作了更详细的说明。

## **应用颜色变换**

颜色效果可以独立地应用于复用同一图像资源的不同图片框。下面的示例创建五个框并分别应用灰度、双音、色调、HSL 调整和颜色替换。

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) 包含两个可独立编辑的颜色参数：`color1` 对应暗像素，`color2` 对应亮像素。这是一个比单一标量值更复杂的示例。

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) 将每个像素的颜色替换为固定颜色，同时保留 Alpha。它不同于 [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--)，后者将一种源颜色映射到另一种并暴露源色和目标色的格式。

### **应用亮度阈值**

亮度阈值可以使扫描页面上淡淡的痕迹更易于与背景区分。[addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) 保留中间灰度。[addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) 将亮度映射为黑或白，而 [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) 对不透明度应用阈值。

亮度阈值范围为 0% 到 100%，包含两端。低于阈值的像素变为黑色，达到或超过阈值的像素变为白色。提升阈值会使更多灰度被判为黑色，因为更多像素落在阈值以下。

下载 [grayscale-swatches.png](grayscale-swatches.png) 到工作目录。每个标签给出原始灰度水平（0~255）。示例将原始图像放在两份副本旁边，并在演示文稿中保存每份副本的阈值。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

在 PowerPoint 中打开输出的演示文稿以比较三个框。标记为 96 的色板大约有 38% 的亮度（96 / 255）。在 20% 阈值下它变白，在 60% 阈值下它变黑。

![原始灰度色板旁边的黑白结果，亮度阈值分别为 20% 和 60%](luminance-threshold.png)

## **添加模糊、透明度和 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) 会影响所有颜色通道，包括 Alpha。模糊边缘可能超出原始图片边界时，将 `grow` 设为 `true`。

若需统一透明度，请使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-)。它会乘以每个现有的 Alpha 值，使部分透明像素保持比例差异。[addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) 则为所有像素分配同一 Alpha 值。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) 根据阈值将 Alpha 转换为两级。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

其他无参数的 Alpha 操作包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)（将所有非零 Alpha 设为完全不透明），[addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)（将所有低于 100% 的 Alpha 设为完全透明），以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--)（将 Alpha 变为 `100% - alpha`）。

## **构建有序的效果链**

每个 `add...Effect` 方法都会在集合末尾追加一个新操作。渲染器按顺序使用该集合：操作 0 的输出成为操作 1 的输入，依此类推。因此，顺序不同的相同操作可能产生不同的图像。

例如，先灰度后色调会先去除色彩信息再给亮度结果上色；先色调后灰度会再次去除色调。类似地，Alpha 替换可以覆盖之前操作计算的 Alpha，而 Alpha 调制则保留它们的相对差异。

下面的示例构建四步链，保存为 PPTX，重新打开演示文稿，检查操作类型及其顺序，并渲染重新打开后的结果：

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

该集合并未强制兼容矩阵把颜色、Alpha 和模糊操作限制在不同链中。它们可以组合，但组合未必都有意义。固定颜色替换会去除前面颜色效果产生的 RGB 变化；灰度在双音之后会去除两种选定颜色；Alpha 天花板、底板、替换或双级操作会丢弃之前创建的 Alpha 细节。请根据所需的像素处理顺序构建链，而不是把链项视为无序的格式标记。

<!-- visual-explanation:image-transform-effects:start -->
[![相同图像先经过灰度后再色调，和先色调后再灰度。两幅最终的灰度图像色调不同。](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*在此 Aspose.Slides for .NET 26.11 渲染示例中，220° 色调在 25% 透明度下对灰度图像无影响。先应用相同的色调再灰度会产生不同的色调。*
<!-- visual-explanation:image-transform-effects:end -->

## **检查可编辑和有效值**

可编辑的操作是存放在 `ISlidesPicture.getImageTransform` 中的对象。根据效果的不同，它可能直接暴露可写成员。例如，[IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) 暴露可写的 `radius` 和 `grow`，[IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) 暴露可写的 `amount`，[IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) 暴露可写的 `threshold`。像 [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) 这样的颜色效果暴露可变的 [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) 对象。

某些操作接口，如 [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/)、[ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/) 和 [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/)，不暴露其创建标量为可写属性。若要更改这些设置，需要删除该操作并在所需位置添加替代操作。

`getEffective()` 返回的有效数据是计算后的只读值。它对解析主题相关颜色和读取渲染器使用的归一化值很有用，但不是可编辑的表面。下面的示例遍历链并在对应 API 提供的情况下检查有效值：

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

没有参数的效果（如灰度、Alpha 天花板、Alpha 反转）仍然拥有有效数据对象，但没有可打印的标量设置。它们在集合中的存在与位置即为重要信息。

## **删除或清除图像变换**

使用 [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) 按索引删除单个操作。由于删除后索引会发生偏移，建议先搜索目标再在枚举后删除。使用 [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) 可一次性删除整条链。

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

删除或清除变换仅改变图片格式。它不会删除、重新压缩或以其他方式修改复用的 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) 资源。

## **考虑演示文稿格式和导出目标**

图像变换源自 DrawingML，因此 PPTX 是效果链的首选可编辑格式。即使使用 PPTX，也并非每个操作的可移植性完全相同：

- 标准 DrawingML 操作（如亮度、灰度、双音、色调、HSL、模糊和常见 Alpha 操作）最有可能在 PPTX 循环后存活。若需保留，请始终重新打开生成的文件并检查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) 是 Office 2010 的扩展，而非标准 DrawingML 亮度操作。它可用于内存渲染，但保存并重新打开 PPTX 后不保证仍保持可编辑的 [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/)。请优先使用 [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) 实现持久的亮度和对比度调节。
- 旧的二进制 PPT 格式早于完整的 DrawingML 效果模型。保存为 PPT 可能会省略不支持的操作，将链缩减为受支持的子集，或近似外观。不要将 PPT 用作复杂可编辑链的验证格式。
- 渲染为 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他可视输出时，会将支持的链应用到渲染结果。这些输出不包含可编辑的 `IImageTransformOperationCollection`；光栅格式会将结果展平成像素，文档/矢量导出会存储自己的渲染表示。
- 效果不会使链接的图像自包含。渲染链接图片仍然依赖于加载演示文稿时链接资源的可用性。

不同的演示文稿使用者在边缘案例上的渲染可能不同，特别是当多种 Alpha 或颜色量化操作组合时。对于关键输出，请使用生产环境中相同的 Aspose.Slides 版本同时测试可编辑的循环和最终导出格式。

## **常见问题**

**图像变换效果会修改嵌入的图像数据吗？**

不会。操作属于图片填充使用的 `ISlidesPicture`。底层 `IPPImage` 的字节保持不变。

**复用同一图像的两个图片框会共享它们的效果吗？**

不会。复用 `IPPImage` 可以避免重复的图像数据，但每个图片框通常拥有独立的 `ISlidesPicture` 和图像变换集合。

**可以同时组合颜色、模糊和 Alpha 效果吗？**

可以。集合接受它们在同一有序链中。请考虑每个操作对前一步输出的影响，因为替换和阈值操作可能会丢弃之前的颜色或 Alpha 细节。

**为什么有效值是只读的？**

有效数据代表用于渲染的计算值，包括已解析的颜色。请在变换集合中编辑有可写成员的操作；否则请删除该操作并添加具有新创建参数的替代操作。

**应该使用哪种格式来保留变换链？**

使用 PPTX 并通过重新打开文件进行验证。传统 PPT 无法完整表示 DrawingML 效果模型，且渲染的导出格式只保留外观而不保留可编辑的变换操作。