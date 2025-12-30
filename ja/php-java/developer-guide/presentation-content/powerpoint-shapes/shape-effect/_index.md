---
title: PHP を使用してプレゼンテーションにシェイプ効果を適用する
linktitle: シェイプ効果
type: docs
weight: 30
url: /ja/php-java/shape-effect/
keywords:
- シェイプ効果
- 影効果
- 反射効果
- グロー効果
- ソフトエッジ効果
- エフェクト形式
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して高度なシェイプ効果で PPT および PPTX ファイルを変換し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---

PowerPoint のエフェクトは図形を際立たせるために使用できますが、[fills](/slides/ja/php-java/shape-formatting/#gradient-fill) やアウトラインとは異なります。PowerPoint エフェクトを使用すると、図形にリアルな反射を作成したり、図形のグローを広げたりすることができます。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint は図形に適用できる 6 つのエフェクトを提供します。1 つまたは複数のエフェクトを図形に適用できます。

* エフェクトの組み合わせの中には他より見栄えが良いものがあります。そのため、PowerPoint の **Preset** オプションがあります。Preset オプションは、実質的に 2 つ以上のエフェクトの見栄えが良い組み合わせです。これにより、プリセットを選択するだけで、さまざまなエフェクトをテストしたり組み合わせたりして良い組み合わせを見つける手間が省けます。

Aspose.Slides は、PowerPoint プレゼンテーションの図形に同じエフェクトを適用できるように、[EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat) クラスのプロパティとメソッドを提供します。

## **影効果の適用**

この PHP コードは、外部影効果 ([OuterShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) を矩形に適用する方法を示しています:
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


## **反射効果の適用**

この PHP コードは、図形に反射効果を適用する方法を示しています:
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


## **グロー効果の適用**

この PHP コードは、図形にグロー効果を適用する方法を示しています:
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


## **ソフトエッジ効果の適用**

この PHP コードは、図形にソフトエッジを適用する方法を示しています:
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

**同じ図形に複数のエフェクトを適用できますか？**

はい、影、反射、グローなどの異なるエフェクトを単一の図形に組み合わせて、よりダイナミックな外観にすることができます。

**どのような図形にエフェクトを適用できますか？**

自動図形、グラフ、表、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形にエフェクトを適用できます。

**グループ化された図形にエフェクトを適用できますか？**

はい、グループ化された図形にもエフェクトを適用できます。エフェクトはグループ全体に適用されます。