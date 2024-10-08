---
title: 演示文稿背景
type: docs
weight: 20
url: /zh/php-java/presentation-background/
keywords: "PowerPoint 背景, 设置背景"
description: "在 PowerPoint 演示文稿中设置背景"
---

实色、渐变颜色和图片通常用作幻灯片的背景图像。您可以为**普通幻灯片**（单个幻灯片）或**母版幻灯片**（一次多个幻灯片）设置背景。

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **为普通幻灯片设置实色背景**

Aspose.Slides 允许您为演示文稿的特定幻灯片设置实色背景（即使该演示文稿包含母版幻灯片）。背景的更改仅影响所选幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将幻灯片背景的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 枚举设置为 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) 属性来指定背景的实色。
5. 保存修改后的演示文稿。

以下 PHP 代码演示如何为普通幻灯片设置实色背景（蓝色）：

```php
  # 创建 Presentation 类的实例
  $pres = new Presentation("MasterBG.pptx");
  try {
    # 将第一张 ISlide 的背景颜色设置为蓝色
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # 将演示文稿写入磁盘
    $pres->save("ContentBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **为母版幻灯片设置实色背景**

Aspose.Slides 允许您为演示文稿中的母版幻灯片设置实色背景。母版幻灯片作为模板，包含和控制所有幻灯片的格式设置。因此，当您选择实色作为母版幻灯片的背景时，该新背景将用于所有幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 将母版幻灯片（`Masters`）的 [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 枚举设置为 `Solid`。
4. 使用 [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) 属性来指定背景的实色。
5. 保存修改后的演示文稿。

以下 PHP 代码演示如何为演示文稿中的母版幻灯片设置实色背景（森林绿）：

```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 将母版 ISlide 的背景颜色设置为森林绿
    $pres->getMasters()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # 将演示文稿写入磁盘
    $pres->save("MasterBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **为幻灯片设置渐变颜色背景**

渐变是一种基于颜色逐渐变化的图形效果。渐变颜色用作幻灯片的背景，可以使演示文稿看起来艺术而专业。Aspose.Slides 允许您为演示文稿中的幻灯片设置渐变颜色背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 枚举设置为 `Gradient`。
4. 使用 [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat--) 属性来指定您所需的渐变设置。
5. 保存修改后的演示文稿。

以下 PHP 代码演示如何为幻灯片设置渐变颜色背景：

```php
  # 创建 Presentation 类的实例
  $pres = new Presentation("MasterBG.pptx");
  try {
    # 将渐变效果应用于背景
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip->FlipBoth);
    # 将演示文稿写入磁盘
    $pres->save("ContentBG_Grad.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **为幻灯片设置图片背景**

除了实色和渐变颜色，Aspose.Slides 还允许您为演示文稿中的幻灯片设置图片背景。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 将幻灯片的 [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) 枚举设置为 `OwnBackground`。
3. 将母版幻灯片背景的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) 枚举设置为 `Picture`。
4. 加载您要用作幻灯片背景的图片。
5. 将图片添加到演示文稿的图片集合中。
6. 使用 [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat--) 属性来设置图片为背景。
7. 保存修改后的演示文稿。

以下 PHP 代码演示如何为幻灯片设置图片背景：

```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 设置背景图片的条件
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # 加载图片
    $imgx;
    $image = Images->fromFile("Desert.jpg");
    try {
      $imgx = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 将图片添加到演示文稿的图片集合中
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($imgx);
    # 将演示文稿写入磁盘
    $pres->save("ContentBG_Img.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **更改背景图片的透明度**

您可能想要调整幻灯片背景图片的透明度，以使幻灯片的内容更加突出。以下 PHP 代码演示如何更改幻灯片背景图片的透明度：

```php
  $transparencyValue = 30;// 例如

  # 获取图片变换操作的集合
  $imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  # 查找具有固定百分比的透明度效果。
  $transparencyOperation = null;
  foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $transparencyOperation = $operation;
      break;
    }
  }
  # 设置新的透明度值。
  if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
  } else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
  }
```

## **获取幻灯片背景的值**

Aspose.Slides 提供 [IBackgroundEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/) 接口，以便您获取幻灯片背景的有效值。该接口包含有关有效 [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getFillFormat--) 和有效 [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) 的信息。

通过 [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/) 类的 [Background](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getBackground--) 属性，您可以获取幻灯片背景的有效值。

以下 PHP 代码演示如何获取幻灯片的有效背景值：

```php
  # 创建 Presentation 类的实例
  $pres = new Presentation("SamplePresentation.pptx");
  try {
    $effBackground = $pres->getSlides()->get_Item(0)->getBackground()->getEffective();
    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid) {
      echo("填充颜色: " . $effBackground->getFillFormat()->getSolidFillColor());
    } else {
      echo("填充类型: " . $effBackground->getFillFormat()->getFillType());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```