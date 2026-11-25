---
title: PHP を使用したプレゼンテーションでの図形効果の適用
linktitle: 図形効果
type: docs
weight: 30
url: /ja/php-java/shape-effect/
keywords:
- 図形効果
- 影効果
- 反射効果
- 光彩効果
- ソフトエッジ効果
- エフェクトフォーマット
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PPT および PPTX ファイルに高度な図形効果を適用し、数秒で印象的でプロフェッショナルなスライドを作成します。"
---
## **導入**

PowerPoint の効果は図形を際立たせるために使用できますが、[塗りつぶし](/slides/ja/php-java/shape-formatting/#gradient-fill)や枠線とは異なります。PowerPoint の効果を使用すると、図形にリアルな反射を作成したり、図形の光彩を広げたりすることができます。

![図形効果](shape-effect.png)

PowerPoint には図形に適用できる 6 つの効果が用意されています。1 つまたは複数の効果を図形に適用できます。

効果の組み合わせの中には、他より見栄えが良いものがあります。そのため、PowerPoint では **プリセット** のオプションを提供しています。プリセットオプションは、見栄えが良いとされる 2 つ以上の効果の組み合わせです。プリセットを選択すれば、さまざまな効果を試したり組み合わせたりして最適な組み合わせを探す手間が省けます。

Aspose.Slides は、PowerPoint プレゼンテーションの図形に同じ効果を適用できるよう、[EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) クラスのプロパティとメソッドを提供します。

## **影効果の適用**

Aspose.Slides for PHP via Java は、図形に対し外側と内側の影をサポートします。色、方向、距離、ぼかし半径をカスタマイズしてプレゼンテーションのデザインに合わせることができます。

### **外側の影を適用**

外側の影を使用すると、カードやパネルがスライドの背景に対して際立ちます。影は図形のエッジの外側に広がり、図形がスライド上に浮き上がっているように見えます。色、方向、距離、ぼかし半径を調整して、テンプレートの照明やスタイルに合わせます。

この PHP コードは、矩形に[外側の影効果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect)を適用する方法を示しています。

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

### **内側の影を適用**

テンプレートのビジュアルスタイルを再現する際は、内側の影を使用してカードやパネルにくぼんだ外観を付けます。外側の影は図形の外側に広がり、浮き上がって見えるのに対し、内側の影はエッジの内部を影付けし、くぼんだ印象を与えます。

[enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) を呼び出し、次に [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) が返す影を設定します。ぼかし半径の値を大きくすると、エッジがより柔らかくなります。

この PHP の例は、ライトブルーのカードにダークグレーの内側の影を付け、PPTX ファイルとして保存します。影の方向は 225 度、距離は 7 ポイント、ぼかし半径は 6 ポイントです。

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

![内側の影が付いたライトブルーの矩形](inner_shadow_effect.png)

内側の影を削除するには、図形の effect format で [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) を呼び出します。

### **プリセット影の適用、変更、削除**

[enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) を呼び出してプリセット影を有効にします。[setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) を使用して [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) を選択するか、同じ図形上で別のスタイルに切り替えます。[disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) を呼び出すと、塗りつぶしと枠線は保持したまま影を削除できます。

この PHP の例は、最初の 3 段階のそれぞれの後に矩形を複製し、4 段階すべてを 1 つのスライドで横並びで比較できるようにしています。両方の影は 10 ポイントオフセットされています。方向が 225° の場合、最初の影は矩形の左上に、45° の場合、2 番目の影は右下に配置されます。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| オリジナル | 最初のプリセット | 2番目のプリセット | 削除後 |
| :---: | :---: | :---: | :---: |
| ![影なし](preset_shadow_original.png) | ![左上ドロップシャドウ](preset_shadow_top_left.png) | ![右下ドロップシャドウ](preset_shadow_bottom_right.png) | ![削除後の影なし](preset_shadow_removed.png) |

## **反射効果の適用**

Aspose.Slides for PHP via Java で反射効果を適用するには、形状に鏡のような反射を追加し、距離、透明度、サイズなどのパラメータを調整します。この効果は、形状に洗練された外観を与えることでプレゼンテーションの美しさを高めます。シンプルなコードで簡単に実装でき、複数の要素に迅速に適用してデザインの一貫性を保てます。

この PHP コードは、形状に[反射効果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) を適用する方法を示しています。

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

## **光彩効果の適用**

Aspose.Slides for PHP via Java で形状に光彩効果を適用するには、形状の周囲に柔らかく輝くオーラを追加し、色やサイズなどのプロパティを調整します。この効果は形状を目立たせ、プレゼンテーションに魅力的で目を引くビジュアル要素を加えます。最小限のコードで簡単に実装でき、スライド全体の外観を向上させます。

この PHP コードは、形状に[光彩効果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) を適用する方法を示しています。

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

![光彩効果](glow_effect.png)

## **ソフトエッジ効果の適用**

Aspose.Slides for PHP via Java でソフトエッジ効果を適用すると、形状のエッジ周辺に滑らかでぼやけた転換を作り出せます。この効果は、より微妙で洗練された外観を加え、柔らかい印象が必要なデザインに最適です。半径などのパラメータを簡単に調整して、プレゼンテーション内のさまざまな形状に目的の効果を適用できます。

この PHP コードは、形状に[ソフトエッジ効果](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) を適用する方法を示しています。

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

## **ぼかし効果の適用**

形状ぼかしを使用すると、形状を編集可能なまま塗りつぶしと枠線を柔らかくできます。形状の effect format で [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) を呼び出します。半径はポイント (1/72 インチ) で測定され、非負の値を使用し、値が大きいほど強いぼかしになります。半径が 0 の場合、外観は変わりません。

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) 設定は効果の可視領域を制御します。`false` の場合、ぼかしは元の描画領域（枠線を含む）にクリップされます。`true` の場合、ぼかしはその領域を超えて広がります。どちらの設定も形状の位置やサイズは変更しません。

以下の比較では、塗りつぶし、枠線、形状のサイズはすべて同じです。上段は `grow = false`、下段は `grow = true` を使用しています。

![ぼかし半径 5 と 15 ポイント、grow 無効・有効 の比較](shape_blur_comparison.png)

この PHP の例は、オレンジの矩形にダークブルーの枠線を付け、5 ポイントのぼかしを適用し、次に [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) を再度呼び出して 15 ポイントのぼかしに更新します。両方のぼかし状態を保存し、その後 [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) を呼び出してぼかしのない形状を保存します。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

形状ぼかしは塗りつぶしと枠線の両方に影響します。ソフトエッジ効果は形状のエッジをフェードさせ、影ぼかしは影だけを柔らかくします。画像変換効果は画像コンテンツに対して動作しますが、この例は形状を画像に変換せず、直接 shape の effect format にぼかしを適用しています。

## **よくある質問**

**同じ図形に複数の効果を適用できますか？**

はい、影、反射、光彩などの異なる効果を組み合わせて、単一の図形に適用し、よりダイナミックな外観を作り出すことができます。

**どのような図形に効果を適用できますか？**

自動図形、グラフ、表、画像、SmartArt オブジェクト、OLE オブジェクトなど、さまざまな図形に効果を適用できます。

**グループ化した図形に効果を適用できますか？**

はい、グループ化した図形にも効果を適用できます。その効果はグループ全体に適用されます。