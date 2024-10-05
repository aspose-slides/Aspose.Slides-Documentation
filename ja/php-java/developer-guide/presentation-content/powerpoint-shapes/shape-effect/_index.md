---
title: シェイプ効果
type: docs
weight: 30
url: /php-java/shape-effect
keywords: "シェイプ効果, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointシェイプに効果を適用する"
---

PowerPointの効果はシェイプを際立たせるために使用できますが、[塗りつぶし](/slides/php-java/shape-formatting/#gradient-fill)や輪郭とは異なります。PowerPointの効果を使用すると、シェイプに説得力のある反射を作成したり、シェイプの光彩を広げたりできます。

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPointでは、シェイプに適用できる6つの効果を提供しています。シェイプに1つ以上の効果を適用できます。

* 効果の組み合わせによっては、他の組み合わせよりも見栄えが良くなるものがあります。このため、PowerPointには**プリセット**のオプションがあります。プリセットオプションは、本質的に2つ以上の効果の良い見栄えの組み合わせとして知られています。このように、プリセットを選択することで、さまざまな効果をテストしたり組み合わせたりして、良い組み合わせを見つけるために時間を無駄にする必要がありません。

Aspose.Slidesは、PowerPointプレゼンテーション内のシェイプに同じ効果を適用するための[EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat)クラスのプロパティとメソッドを提供しています。

## **影効果を適用する**

このPHPコードは、長方形に外側の影効果([OuterShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--))を適用する方法を示しています。

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

## **反射効果を適用する**

このPHPコードは、シェイプに反射効果を適用する方法を示しています。

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

## **光彩効果を適用する**

このPHPコードは、シェイプに光彩効果を適用する方法を示しています。

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

## **ソフトエッジ効果を適用する**

このPHPコードは、シェイプにソフトエッジ効果を適用する方法を示しています。

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