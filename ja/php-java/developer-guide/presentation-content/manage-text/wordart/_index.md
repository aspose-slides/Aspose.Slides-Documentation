---
title: PHPでWordArtエフェクトを作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/php-java/wordart/
keywords:
- WordArt
- WordArtの作成
- WordArtテンプレート
- WordArtエフェクト
- 影エフェクト
- 反射エフェクト
- グローエフェクト
- WordArt変形
- 3Dエフェクト
- 外側影エフェクト
- 内側影エフェクト
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via JavaでWordArtエフェクトを作成およびカスタマイズします。このステップバイステップガイドは、開発者がPHPでプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---
## **概要**

WordArt エフェクトを使用すると、テキストに塗りつぶし、アウトライン、影、反射、グロー、変形、3D 書式設定を加えてスタイルを設定できます。本記事では、Microsoft Office をインストールせずに、Aspose.Slides for PHP via Java を使用して PowerPoint プレゼンテーションでこれらのエフェクトを作成およびカスタマイズする方法を説明します。

## **シンプルな WordArt テンプレートを作成し、テキストに適用する**

以下の例は、テキスト、フォント、パターン塗りつぶし、およびアウトラインを設定してシンプルな WordArt スタイルを作成します。

各例は新しいプレゼンテーションを作成し、最初のスライドに矩形を追加します。入力ファイルは必要ありません。最初の例ではテキストを "Aspose.Slides" に設定します。形状の位置とサイズはポイント単位で測定されます。

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

フォーマットを目立たせるために、フォントを Arial Black、サイズ 36 ポイントに設定します。

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

暗いオレンジ色の前景と白い背景を持つ [SmallGrid](https://reference.aspose.com/slides/ja/php-java/aspose.slides/patternstyle/#SmallGrid) パターンを適用し、幅 1 ポイントの黒いテキストアウトラインを追加します。

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

結果のテキスト：

![シンプルな WordArt テンプレート](WordArt_template.png)

## **他の WordArt エフェクトを適用する**

以下の例では、テキストに影、反射、グロー、変形、3D エフェクトを適用する方法を示します。

### **外側の影エフェクトを適用する**

外側の影はテキストの背後に影を配置することで奥行きを与えます。色、方向、距離、ぼかし半径、スケール、傾斜をカスタマイズできます。

この例では [enableOuterShadowEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) を呼び出し、ぼかし半径 4 ポイント、方向 230 度、距離 30 ポイントの黒い影を設定します。スケール値 100 は影のサイズを維持し、水平傾斜は 20 度で傾けます。アルファ変換で不透明度を 32% に設定します。

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

結果のテキスト：

![外側の影エフェクト](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 外側の影とプリセットの影を同時に使用すると、外側の影のみが適用されます。
- 外側の影と内側の影を同時に使用すると、結果のエフェクトは PowerPoint のバージョンに依存します。たとえば、PowerPoint 2013 ではエフェクトが2倍になり、PowerPoint 2007 では外側の影のみが適用されます。
{{% /alert %}}

### **反射エフェクトを適用する**

反射はテキストの鏡像コピーを作成します。位置、スケール、ぼかし、透明度を調整して外観を制御します。

この例では [enableReflectionEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effectformat/#enableReflectionEffect--) を呼び出し、スケール -100% で反射を垂直方向に反転させます。ぼかし半径 0.5 ポイント、距離 4.72 ポイントを使用します。透明度は反射の位置 0% から 60% の間で 60% から 0.9% に減少します。

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

結果のテキスト：

![反射エフェクト](reflection_effect.png)

### **グローエフェクトを適用する**

グローはテキストの周囲に柔らかい色のアウトラインを追加します。色、透明度、半径を調整してエフェクトを制御します。

この例では [enableGlowEffect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/effectformat/#enableGlowEffect--) を呼び出し、透明度 54% の赤いグローを半径 7 ポイントで適用します。

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

結果のテキスト：

![グローエフェクト](glow_effect.png)

### **WordArt 変形を適用する**

WordArt 変形はテキストブロックを曲げたり、伸ばしたり、ねじったりします。

setTransform を [ArchUpPour](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textshapetype/#ArchUpPour) に設定してテキストフレーム全体を上向きに曲げます。

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

結果のテキスト：

![WordArt 変形](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java は、事前定義された [変形タイプ](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textshapetype/) のセットを提供します。
{{% /alert %}}

### **シェイプとテキストに 3D エフェクトを適用する**

シェイプまたはテキストに 3D エフェクトを適用できます。ベベル、押し出し、照明、カメラ設定が結果の外観を制御します。

以下の例では [ThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/) を使用して、矩形に円形ベベル、オレンジ色の押し出し、濃い赤の輪郭を追加します。ベベルの寸法、押し出し高さ、輪郭幅、深さはポイント単位で測定されます。プラスチック素材、Z 軸周りに 40 度回転したバランス照明、遠近カメラが外観を定義します。

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

結果のシェイプ：

![シェイプの 3D エフェクト](shape_3D_effect.png)

この例では [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#getThreeDFormat--) を使用して、テキストにも同様の 3D 書式設定を適用します。小さなベベルが文字のエッジを形成し、押し出しと照明がテキストに奥行きを与えます。

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

結果のテキスト：

![テキストの 3D エフェクト](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
テキストやシェイプへの 3D エフェクトの適用、およびこれらのエフェクト間の相互作用は、特定のルールで管理されます。テキストとそれを含むシェイプの両方が関与するシーンを考えてみてください。3D エフェクトはオブジェクトの 3D 表現と配置されたシーンを含みます。

- シェイプとテキストの両方にシーンが設定されている場合、シェイプのシーンが優先され、テキストのシーンは無視されます。
- シェイプに独自のシーンがなく 3D 表現がある場合、テキストのシーンが使用されます。
- シェイプに 3D エフェクトが全くない場合、平面とみなされ、3D エフェクトはテキストのみへ適用されます。

これらの動作は [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#getLightRig--) および [ThreeDFormat::getCamera](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#getCamera--) メソッドに関連しています。
{{% /alert %}}

3D 書式設定の詳細な例については、[PHP を使用したプレゼンテーションでの 3D エフェクトの作成](/slides/ja/php-java/3d-presentation/) を参照してください。

## **よくある質問**

**異なるフォントやスクリプト（例: アラビア語、中国語）で WordArt エフェクトを使用できますか？**

はい、Aspose.Slides for PHP via Java は Unicode をサポートしており、主要なフォントとスクリプトすべてで動作します。影、塗りつぶし、アウトラインなどの WordArt エフェクトは言語に関係なく適用できますが、フォントの利用可能性や描画はシステムフォントに依存する場合があります。

**スライドマスタ要素に WordArt エフェクトを適用できますか？**

はい、タイトル プレースホルダー、フッター、背景テキストなど、マスタースライド上のシェイプに WordArt エフェクトを適用できます。マスター レイアウトに加えた変更は、関連するすべてのスライドに反映されます。

**WordArt エフェクトはプレゼンテーションのファイルサイズに影響しますか？**

わずかに影響します。影、グロー、グラデーション塗りつぶしなどの WordArt エフェクトは、追加の書式メタデータによりファイルサイズが若干増加することがありますが、差は通常は無視できる程度です。

**プレゼンテーションを保存せずに WordArt エフェクトの結果をプレビューできますか？**

はい、[Slide::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getImage--) を使用して WordArt を含むスライドを画像（例: PNG、JPEG）としてレンダリングしたり、[Shape::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getImage--) を使用して個々のシェイプをレンダリングしたりできます。これにより、プレゼンテーション全体を保存またはエクスポートする前に、メモリ上または画面上で結果をプレビューできます。