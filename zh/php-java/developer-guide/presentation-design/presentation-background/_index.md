---
title: 在 PHP 中管理演示文稿背景
linktitle: 幻灯片背景
type: docs
weight: 20
url: /zh/php-java/presentation-background/
keywords:
- 演示文稿背景
- 幻灯片背景
- 纯色
- 渐变色
- 图像背景
- 背景透明度
- 背景属性
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 文件中设置动态背景，并提供代码技巧以提升您的演示效果。"
---

## **概述**

纯色、渐变和图像通常用作幻灯片背景。您可以为**普通幻灯片**（单张幻灯片）或**母版幻灯片**（一次应用于多张幻灯片）设置背景。

![PowerPoint background](powerpoint-background.png)

## **为普通幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿中的特定幻灯片设置纯色背景，即使该演示文稿使用了母版幻灯片。更改仅适用于所选幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 设置为 `Solid`。
4. 在 [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) 上使用 [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) 方法指定纯色背景颜色。
5. 保存修改后的演示文稿。

以下 PHP 示例演示如何将蓝色纯色设置为普通幻灯片的背景：
```php
// 创建 Presentation 类的实例。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 将幻灯片的背景颜色设置为蓝色。
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // 将演示文稿保存到磁盘。
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **为母版幻灯片设置纯色背景**

Aspose.Slides 允许您为演示文稿的母版幻灯片设置纯色背景。母版幻灯片充当模板，控制所有幻灯片的格式，因此为母版幻灯片的背景选择纯色后，会应用到每张幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过 `getMasters` 将母版幻灯片的 [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 设置为 `Solid`。
4. 使用 [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) 方法指定纯色背景颜色。
5. 保存修改后的演示文稿。

以下 PHP 示例演示如何将绿色纯色设置为母版幻灯片的背景：
```php
// 创建 Presentation 类的实例。
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // 将母版幻灯片的背景颜色设置为森林绿。
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // 将演示文稿保存到磁盘。
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **为幻灯片设置渐变背景**

渐变是通过颜色逐渐变化创建的图形效果。将渐变用作幻灯片背景可以使演示文稿看起来更具艺术感和专业性。Aspose.Slides 允许您为幻灯片设置渐变颜色背景。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 设置为 `Gradient`。
4. 在 [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) 上使用 [getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) 方法配置所需的渐变设置。
5. 保存修改后的演示文稿。

以下 PHP 示例演示如何将渐变颜色设置为幻灯片的背景：
```php
// 创建 Presentation 类的实例。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 对背景应用渐变效果。
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // 将演示文稿保存到磁盘。
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **将图像设置为幻灯片背景**

除了纯色和渐变填充，Aspose.Slides 还支持使用图像作为幻灯片背景。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) 设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 设置为 `Picture`。
4. 加载要用作幻灯片背景的图像。
5. 将图像添加到演示文稿的 ImageCollection 中。
6. 在 [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) 上使用 [getPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat) 方法将图像指定为背景。
7. 保存修改后的演示文稿。

以下 PHP 示例演示如何将图像设置为幻灯片的背景：
```php
// 创建 Presentation 类的实例。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 设置背景图像属性。
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // 加载图像。
    $image = Images::fromFile("Tulips.jpg");
    // 将图像添加到演示文稿的图像集合。
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // 将演示文稿保存到磁盘。
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


以下代码示例演示如何将背景填充类型设置为平铺图片并修改平铺属性：
```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // 设置用于背景填充的图像。
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // 将图片填充模式设置为平铺并调整平铺属性。
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert color="primary" %}}
了解更多: [**将图片平铺为纹理**](/slides/zh/php-java/shape-formatting/#tile-picture-as-texture)。
{{% /alert %}}

### **更改背景图像透明度**

您可能希望调整幻灯片背景图像的透明度，以突出幻灯片内容。以下 PHP 代码演示如何更改幻灯片背景图像的透明度：
```php
$transparencyValue = 30; // 例如。

// 获取图片变换操作的集合。
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// 查找已存在的固定百分比透明度效果。
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// 设置新的透明度值。
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```


## **获取幻灯片背景值**

Aspose.Slides 提供 `BackgroundEffectiveData` 类用于检索幻灯片的有效背景值。该类公开有效的 [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) 和 [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/)。

使用 [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/) 类的 `getBackground` 方法，您可以获取幻灯片的有效背景。

以下 PHP 示例演示如何获取幻灯片的有效背景值：
```php
// 创建 Presentation 类的实例。
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 检索有效背景，考虑母版、版式和主题。
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```


## **常见问题**

**我可以重置自定义背景并恢复主题/版式背景吗？**

可以。移除幻灯片的自定义填充后，背景将再次从相应的 [layout](/slides/zh/php-java/slide-layout/)/[master](/slides/zh/php-java/slide-master/) 幻灯片（即 [theme background](/slides/zh/php-java/presentation-theme/)）继承。

**如果我 later 更改演示文稿的主题，背景会怎样？**

如果幻灯片拥有自己的填充，则保持不变。如果背景是从 [layout](/slides/zh/php-java/slide-layout/)/[master](/slides/zh/php-java/slide-master/) 继承的，则会随新主题更新。