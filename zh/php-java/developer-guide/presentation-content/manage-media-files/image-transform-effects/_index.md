---
title: 使用 PHP 在演示文稿中管理图像变换效果
linktitle: 图像变换效果
type: docs
weight: 11
url: /zh/php-java/image-transform-effects/
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
- PHP
- Aspose.Slides
description: "通过 Java 的 Aspose.Slides for PHP 为图片框应用、链式、检查、删除和验证图像变换效果。"
---
## **概述**

Aspose.Slides 将图片调整表示为有序的图像变换操作集合。对于图片框，首先获取框的 [Picture](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picture/) 并访问 [Picture::getImageTransform](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picture/getimagetransform/)。返回的 [ImageTransformOperationCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/) 允许在不重写原始图像字节的情况下追加、枚举、检查、删除和清除效果。

本文演示了完整的工作流，涵盖亮度与对比度、颜色变换、模糊、透明度、有序效果链、有效值、删除以及 PPTX 循环验证。

## **了解效果所有权和图像重用**

图像资源与显示它的图片是不同的对象：

- [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 存储或引用演示文稿拥有的源图像数据。
- [Picture](https://reference.aspose.com/slides/zh/php-java/aspose.slides/picture/) 属于图片填充，引用图像资源并保存图像变换集合。
- [PictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pictureframe/) 是幻灯片形状，拥有相应的图片填充、几何、裁剪设置以及其他框级格式。

因此，图像变换操作不会修改 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 中的字节。当同一个 `PPImage` 多次传递给 [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/addpictureframe/) 时，每个新图片框都会拥有各自的 `Picture` 和变换集合。对一个框应用灰度不会使其他框也变为灰度，即使它们复用了同一个嵌入图像资源。

相同的 `Picture::getImageTransform` 模型也被其他图片填充使用，例如形状或幻灯片背景。下面的示例聚焦于图片框。

## **使用有效的参数范围和单位**

演示的方法使用如下语义范围和单位。即使某些库版本不会立即拒绝所有超出范围的值，也请保持在这些范围内；目标演示文稿格式可能在保存或 PowerPoint 打开文件时规范化、删除或拒绝无效数据。

| 操作 | 参数 | 有效范围和单位 |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 保持组件不变。 |
| [addGrayScaleEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | 无 | 无数值参数。Alpha保持不变。 |
| [addDuotoneEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | 暗像素和亮像素各两个颜色。`java.awt.Color` 中的RGB和Alpha通道使用 `0` 到 `255`。 |
| [addTintEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 色相 为 `0`（含）到 `360`（不含）度；量度 为 `-100` 到 `100`，百分比。 |
| [addHSLEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 色相 为 `0`（含）到 `360`（不含）度；饱和度和亮度 为 `-100` 到 `100`，百分比。 |
| [addColorReplaceEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | 替换颜色使用 `0` 到 `255` 的通道值。现有的Alpha值保持不变。 |
| [addBlurEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 半径为非负数，单位为磅；`grow` 为布尔值，决定模糊内容是否可以超出原始边界。 |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非负百分比。使用 `0` 到 `100` 表示普通的不透明度缩放：`0` 完全透明，`100` 保留现有Alpha。 |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` 到 `100`，百分比Alpha阈值。低于该值的像素变为透明；等于或高于该值的像素变为不透明。 |

对于固定的 Alpha 调制，透明度与不透明度是互补的。例如，35% 透明度对应的 Alpha 调制量为 65%。

## **应用亮度和对比度**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) 返回一个 [Luminance](https://reference.aspose.com/slides/zh/php-java/aspose.slides/luminance/) 操作。其标量设置在创建操作时提供。[Luminance::getEffective](https://reference.aspose.com/slides/zh/php-java/aspose.slides/luminance/geteffective/) 返回可读的计算后只读值，可用于检查或记录。

以下示例将亮度提升 15%，对比度提升 20%，随后渲染预览而不修改嵌入图像：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` 是标准 DrawingML 的亮度和对比度效果。当这些设置需要在 PPTX 循环后仍可编辑时，重新打开保存的演示文稿并验证操作类型及其有效值。

## **应用颜色转换**

颜色效果可以独立地应用于复用同一图像资源的不同图片框。下面的示例创建五个框并分别应用灰度、双调、色调、HSL 调整和颜色替换。

[Duotone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/duotone/) 包含两个可独立编辑的颜色参数：`color1` 用于暗像素，`color2` 用于亮像素。这使它成为一个比单一标量更复杂的示例。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) 将每个像素的颜色替换为固定颜色，同时保留 Alpha。它不同于 [addColorChangeEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/)，后者将一种源颜色映射到另一种，并暴露源颜色和目标颜色的格式。

## **添加模糊、透明度和 Alpha 效果**

[addBlurEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) 影响所有颜色通道，包括 Alpha。当模糊边缘可能超出原始图片边界时，将 `grow` 设置为 `true`。

若需统一透明度，使用 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/)。它会乘以每个现有的 Alpha 值，使部分透明像素保持相对差异。[addAlphaReplaceEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) 则为所有像素分配统一的 Alpha。[addAlphaBiLevelEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) 根据阈值将 Alpha 转为两个级别。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

其他无参数的 Alpha 操作包括 [addAlphaCeilingEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/)，将所有非零 Alpha 设为完全不透明；[addAlphaFloorEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/)，将所有低于 100% 的 Alpha 设为完全透明；以及 [addAlphaInverseEffect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/)，将 Alpha 改为 `100% - alpha`。

## **构建有序效果链**

每个 `add...Effect` 方法都会将新操作追加到集合末尾。渲染器将集合视为有序管线：操作 0 的输出成为操作 1 的输入，依此类推。因此，顺序不同的相同操作可能产生不同的图像。

例如，先灰度后色调会先去除色彩信息再重新着色，而先色调后灰度会再次去除色调。类似地，Alpha 替换可以覆盖早期操作计算的 Alpha，而 Alpha 调制则保留它们的相对差异。

以下示例构建四步链，保存为 PPTX，重新打开演示文稿，检查操作类型及其顺序，并渲染重新打开的结果：

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

集合并未强制兼容性矩阵将颜色、Alpha 和模糊操作限制在不同链中。它们可以组合使用，但组合并不总是有意义。固定颜色替换会抹掉前面颜色效果产生的 RGB 变化；灰度在双调之后会移除两种选定颜色；Alpha 天花板、底层、替换或双层操作会丢弃之前创建的 Alpha 细节。应依据期望的像素处理顺序构建链，而不是把其项目视为无序的格式标记。

## **检查可编辑和有效值**

可编辑操作是存储在 `Picture::getImageTransform` 中的对象。根据具体效果，它可能直接暴露可写成员。例如，[Blur](https://reference.aspose.com/slides/zh/php-java/aspose.slides/blur/) 暴露可写的 `radius` 和 `grow`，[AlphaModulateFixed](https://reference.aspose.com/slides/zh/php-java/aspose.slides/alphamodulatefixed/) 暴露可写的 `amount`，以及 [AlphaBiLevel](https://reference.aspose.com/slides/zh/php-java/aspose.slides/alphabilevel/) 暴露可写的 `threshold`。[Duotone](https://reference.aspose.com/slides/zh/php-java/aspose.slides/duotone/) 等颜色效果暴露可变的 [ColorFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/colorformat/) 对象。

一些操作，如 [Luminance](https://reference.aspose.com/slides/zh/php-java/aspose.slides/luminance/)、[HSL](https://reference.aspose.com/slides/zh/php-java/aspose.slides/hsl/)、[Tint](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tint/) 和 [AlphaReplace](https://reference.aspose.com/slides/zh/php-java/aspose.slides/alphareplace/)，不会将创建时的标量暴露为可写属性。若需更改这些设置，请删除该操作并在所需位置添加替代操作。

`getEffective()` 返回的有效数据是计算后的只读值。它对于解析主题相关颜色和读取渲染器使用的规范化值很有帮助，但不是另一个编辑界面。下面的示例枚举链并在对应 API 提供的情况下检查有效值：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

像灰度、Alpha 天花板和 Alpha 反转等无参数效果仍拥有有效数据对象，只是没有可打印的标量设置。它们在集合中的存在与位置即为重要信息。

## **移除或清除图像变换**

使用 [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/removeat/) 按索引删除单个操作。由于删除后索引会移动，请先搜索目标，然后在枚举后删除。使用 [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imagetransformoperationcollection/clear/) 可删除整条链。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

移除或清除变换仅改变图片格式。它不会删除、重新压缩或以其他方式修改复用的 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 资源。

## **考虑演示文稿格式和导出目标**

图像变换来源于 DrawingML，因此 PPTX 是效果链的首选可编辑格式。即使在 PPTX 中，也并非所有操作都有完全相同的可移植性：

- 标准 DrawingML 操作如 luminance、grayscale、duotone、tint、HSL、blur 以及常见的 alpha 操作最有可能在 PPTX 循环后存活。需要保留时，请始终重新打开生成的文件并检查集合。
- 二进制 PPT 格式早于完整的 DrawingML 效果模型。保存为 PPT 可能会省略不受支持的操作、将链缩减为受支持的子集，或对外观进行近似。不要将 PPT 用作复杂可编辑链的验证格式。
- 渲染为 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他可视输出时，会将支持的链应用到渲染结果。这些输出不包含可编辑的 `ImageTransformOperationCollection`；光栅格式会把结果展平为像素，文档或矢量导出则存储自己的渲染表示。
- 效果不会使链接图像成为自包含的。渲染链接图片仍然依赖于加载演示文稿时能够访问到链接资源。

不同的演示文稿消费者在渲染边缘案例时可能表现不同，尤其是当多个 alpha 或颜色量化操作组合使用时。对于关键输出，请使用生产环境中相同的 Aspose.Slides 版本同时测试可编辑循环和最终导出格式。

## **常见问题**

**图像变换效果会修改嵌入的图像数据吗？**

不会。操作属于图片填充使用的 `Picture`。底层 `PPImage` 的字节保持不变。

**复用同一图像的两个图片框会共享它们的效果吗？**

不会。复用 `PPImage` 可以避免重复的图像数据，但每个图片框通常拥有各自的 `Picture` 和图像变换集合。

**颜色、模糊和 Alpha 效果可以组合使用吗？**

可以。集合接受它们在同一有序链中。请考虑每个操作对前一个输出的影响，因为替换和阈值操作可能会丢弃之前的颜色或 Alpha 细节。

**为什么有效值是只读的？**

有效数据表示用于渲染的计算值，包括已解析的颜色。请在变换集合中编辑可写成员的操作；如果没有可写属性，则删除该操作并用新的创建参数添加替代。

**应该使用哪种格式来保留变换链？**

使用 PPTX 并通过重新打开文件进行验证。旧版 PPT 无法完整表示 DrawingML 效果模型，导出的可视格式只保留外观而不保留可编辑的变换操作。