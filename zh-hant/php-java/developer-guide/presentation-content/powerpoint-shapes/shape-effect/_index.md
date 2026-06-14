---
title: 在簡報中使用 PHP 套用形狀效果
linktitle: 形狀效果
type: docs
weight: 30
url: /zh-hant/php-java/shape-effect/
keywords:
- 形狀效果
- 陰影效果
- 反射效果
- 發光效果
- 柔化邊緣效果
- 效果格式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，為您的 PPT 和 PPTX 檔案套用進階形狀效果——在數秒內打造引人注目、專業的投影片。"
---
## **簡介**

在 PowerPoint 中，效果可以讓形狀突顯，但它們不同於 [fills](/slides/zh-hant/php-java/shape-formatting/#gradient-fill) 或輪廓。使用 PowerPoint 效果，您可以在形狀上建立逼真的反射、擴散形狀的發光等。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint 提供六種可套用於形狀的效果。您可以對同一個形狀套用一個或多個效果。 

* 某些效果組合比其他組合更佳。因此，PowerPoint 在 **Preset** 下提供選項。Preset 選項實際上是一組已知好看的兩個或多個效果的組合。這樣，只要選擇預設，就不必浪費時間測試或組合不同的效果以尋找合適的組合。

Aspose.Slides 在 [EffectFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/EffectFormat) 類別中提供屬性與方法，讓您在 PowerPoint 簡報中對形狀套用相同的效果。

## **套用陰影效果**

以下 PHP 程式碼示範如何將外部陰影效果 ([OuterShadowEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) 套用到矩形：

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->DARK_GRAY);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **套用反射效果**

以下 PHP 程式碼示範如何將反射效果套用到形狀：

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(55);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(4);
    $pres->save("reflection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **套用發光效果**

以下 PHP 程式碼示範如何將發光效果套用到形狀：

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);
    $pres->save("glow.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **套用柔化邊緣效果**

以下 PHP 程式碼示範如何將柔化邊緣套用到形狀：

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(15);
    $pres->save("softEdges.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**我可以對同一個形狀套用多個效果嗎？**

可以，您可以在單一形狀上組合不同的效果，例如陰影、反射和發光，以建立更具動態的外觀。

**哪些形狀可以套用效果？**

您可以對各種形狀套用效果，包括自動圖案、圖表、表格、圖片、SmartArt 物件、OLE 物件等。

**我可以對群組形狀套用效果嗎？**

可以，您可以對群組形狀套用效果，效果會套用到整個群組。