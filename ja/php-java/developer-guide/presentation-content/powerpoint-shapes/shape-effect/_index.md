---
title: PHP を使用したプレゼンテーションでシェイプ効果を適用
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
description: "Aspose.Slides for PHP via Java を使用して、PPT および PPTX ファイルに高度なシェイプ効果を適用し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **概要**

PowerPoint の効果は図形を際立たせるために使用できますが、[塗りつぶし](/slides/ja/php-java/shape-formatting/#gradient-fill)や輪郭とは異なります。PowerPoint の効果を使用すると、図形にリアルな反射を作成したり、図形のグローを拡げたりすることができます。

![シェイプ効果](shape-effect.png)

PowerPoint には図形に適用できる 6 つの効果が用意されています。図形に 1 つまたは複数の効果を適用できます。

効果の組み合わせによっては見栄えが異なります。そのため、PowerPoint では **Preset** の下にオプションが用意されています。Preset オプションは、見た目が良いとされる 2 つ以上の効果の組み合わせです。プリセットを選択すれば、さまざまな効果を試したり組み合わせて最適な組み合わせを見つける手間が省けます。

Aspose.Slides は [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供し、PowerPoint プレゼンテーションの図形に同じ効果を適用できます。

## **影効果を適用**

Aspose.Slides for PHP via Java は図形に対して外部および内部の影をサポートします。色、方向、距離、ぼかし半径をカスタマイズしてプレゼンテーションのデザインに合わせることができます。

### **外部影を適用**

外部影を使用すると、カードやパネルがスライドの背景から際立ちます。影は図形の端を超えて広がり、図形がスライド上に浮き上がっているように見えます。テンプレートのライティングやスタイルに合わせて色、方向、距離、ぼかし半径を調整してください。

この PHP コードは矩形に [外部シャドウ効果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) を適用する方法を示しています:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![影効果](shadow_effect.png)

### **内部影を適用**

テンプレートのビジュアルスタイルを再現する場合、内部影を使用してカードやパネルにへこみ感を与えます。外部影は図形の外側に広がり浮き上がって見えますが、内部影はエッジの内側を陰影付けします。

[enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) を呼び出し、[getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) が返す影を構成します。ぼかし半径の値を大きくするとエッジが柔らかくなります。

この PHP の例は、淡いブルーのカードに濃いグレーの内部影を付けて PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![内部影付きの淡いブルー矩形](inner_shadow_effect.png)

内部影を削除するには、図形の effect format に対して [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) を呼び出します。

## **反射効果を適用**

Aspose.Slides for PHP via Java で反射効果を適用するには、図形に鏡面のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。この効果は図形に洗練された外観を与え、プレゼンテーションの美的感覚を高めます。シンプルなコードで簡単に実装でき、複数の要素に一貫したデザインを迅速に適用できます。

この PHP コードは図形に [反射効果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) を適用する方法を示しています:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![反射効果](reflection_effect.png)

## **グロー効果を適用**

Aspose.Slides for PHP via Java で図形にグロー効果を適用すると、図形の周囲に柔らかな光のオーラを追加でき、色やサイズなどのプロパティを調整できます。この効果は図形を目立たせ、プレゼンテーションに魅力的で目を引く視覚要素を加えます。最小限のコードで簡単に実装でき、スライド全体の外観を向上させます。

この PHP コードは図形に [グロー効果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) を適用する方法を示しています:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![グロー効果](glow_effect.png)

## **ソフトエッジ効果を適用**

Aspose.Slides for PHP via Java でソフトエッジ効果を適用すると、図形のエッジ周辺に滑らかでぼやけた遷移を作成できます。この効果は、やさしく柔らかな外観が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな図形に目的の効果を実現できます。

この PHP コードは図形に [ソフトエッジ効果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) を適用する方法を示しています:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![ソフトエッジ効果](soft_edges_effect.png)

## **FAQ**

**同じ図形に複数の効果を適用できますか？**

はい、影、反射、グローなどの異なる効果を組み合わせて、図形によりダイナミックな外観を付与できます。

**どの図形に効果を適用できますか？**

オートシェイプ、チャート、テーブル、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形に効果を適用できます。

**グループ化した図形に効果を適用できますか？**

はい、グループ化した図形全体に効果が適用されます。