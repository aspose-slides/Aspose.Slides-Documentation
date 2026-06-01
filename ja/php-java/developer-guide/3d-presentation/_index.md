---
title: PHP を使用したプレゼンテーションでの 3D エフェクトの作成
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D プレゼンテーション
- 3D 回転
- 3D 奥行き
- 3D 押し出し
- 3D グラデーション
- 3D テキスト
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で PowerPoint のシェイプとテキストに 3D エフェクトを適用およびレンダリングします。カメラ、照明、材質、押し出し、塗りつぶし、3D テキストを設定できます。"
---
## **概要**

Aspose.Slides for PHP via Java は、シェイプやテキストに対して PowerPoint スタイルの 3D 書式設定を作成、編集、保持、レンダリングできます。この記事では、回転、押し出し、ベベル、照明、材質、グラデーションまたは画像塗りつぶし、3D テキストなどの 3D 効果について説明します。

{{% alert color="primary" %}}
この記事は PowerPoint のシェイプとテキストに対する 3D 書式設定効果についてです。スタンドアロンの 3D モデルファイルの挿入や編集に関するものではありません。スライドを画像、PDF、HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

[Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) クラスとその [Shape::getThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getThreeDFormat--) メソッドを使用してシェイプに 3D 書式設定を適用します。このメソッドは [ThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/) を返し、シェイプの 3D シーンを制御します。

テキストの場合は、[TextFrameFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/) クラスとその [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#getThreeDFormat--) メソッドを使用します。これによりシェイプ本体ではなくテキストフレームに 3D 書式設定が適用されます。

最も重要な設定は次のとおりです。

| メソッドまたは設定 | 制御対象 | 使用シーン |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#getCamera--) | ビューポイント、プリセットカメラタイプ、回転、ズーム、遠近法 | 3D 空間でオブジェクトを回転させる、または PowerPoint の 3D 回転プリセットに合わせる |
| [getLightRig](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#getLightRig--) | ライトプリセット、方向、ライトの回転 | 3D 表面のハイライトや影の見え方を変更 |
| [setMaterial](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#setMaterial-byte-) | フラット、マット、プラスチック、メタルなどの表面材質 | 同じ形状を平坦、柔らかい、光沢のある、金属的に見せる |
| [setExtrusionHeight](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | 前面から後方にどれだけ延長するか | 平面シェイプを目に見える厚さのある 3D オブジェクトに変換 |
| [getExtrusionColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#getExtrusionColor--) | 押し出し側面の色 | 奥行きを見せる、または前面の塗りつぶしと側面の色を合わせる |
| [setDepth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#setDepth-double-) | PowerPoint の 3D 書式設定で使用される追加奥行き | ベベルや材質設定と組み合わせてシェイプやテキストの奥行きを微調整 |
| [getBevelTop](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#getBevelTop--) と [getBevelBottom](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#getBevelBottom--) | 前面と背面のエッジの盛り上がりや丸み | 鋭利な平面ではなく、柔らかく成形されたエッジを追加 |
| [getContourColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#getContourColor--) と [setContourWidth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#setContourWidth-double-) | 3D オブジェクトの輪郭ライン | レンダリング結果でオブジェクトの境界を強調 |

## **3D シェイプの作成**

シェイプが納得できる 3D に見えるためには、通常次の 4 種類の設定が必要です。

- カメラ設定 – デフォルトの正面ビューでは押し出しが隠れることがあるため  
- ライト設定 – 照明により面や側面が見やすくなるため  
- 材質設定 – 表面が光の当たり方に影響するため  
- 押し出しまたは奥行き設定 – 平面シェイプに厚さを与えるため  

以下の例は矩形を作成し、前面にテキストを追加し、3D 書式設定を適用してプレゼンテーションを PPTX として保存し、スライドを PNG 画像にレンダリングします。

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

レンダリングされたスライド画像は、矩形が厚みのある 3D ブロックとして表示されます。

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **カメラでシェイプを回転する**

PowerPoint では 3-D 回転ペインで 3D 回転を設定します。X、Y、Z の回転値はカメラ API で設定する回転に対応します。

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides では [ThreeDFormat::getCamera](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#getCamera--) を使用してカメラタイプと回転を設定します。

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

ビューアがオブジェクトを見る角度を変更したいときにカメラを使用します。スライド上の 2D シェイプジオメトリは変更されず、PowerPoint と Aspose.Slides がレンダリング時に使用する 3D ビューポイントが変わります。

## **押し出しと奥行きを追加する**

押し出しは前面から背面へシェイプを延長し、厚みを持たせます。PowerPoint では深さコントロールが見える厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

厚さには [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) を、側面の色には [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#getExtrusionColor--) を使用します。

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

PowerPoint の深さ値を直接操作したい、または深さをベベル、材質、テキスト効果と組み合わせたい場合は [ThreeDFormat::setDepth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/#setDepth-double-) を使用します。多くのシェイプシナリオでは、`setExtrusionHeight` の方が可視的な押し出しを直接示すため分かりやすいです。

## **3D 効果とともにグラデーションまたは画像塗りつぶしを使用する**

3D 書式設定はシェイプの塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、画像塗りつぶしを適用しながら、同じカメラ、ライト、材質、押し出し設定を使用できます。

以下の例はシェイプにグラデーション塗りつぶしを適用し、側面に暗めの押し出し色を設定します。

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

レンダリング結果は前面のグラデーションを保持し、押し出しは別個に描画されます。

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

画像塗りつぶしを使用する場合は、画像をプレゼンテーションに追加し、シェイプの塗りつぶしに割り当てます。

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

画像は前面に描画され、押し出しは 3D 側面として描画されます。

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、材質、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例はパターン塗りつぶしのテキストを作成し、WordArt 変形を適用し、[TextFrameFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/) の 3D 設定を構成します。

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

テキストは曲線状で押し出された 3D 文字としてレンダリングされます。

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **エクスポートとレンダリングの挙動**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンは 2D 結果としてラスタライズまたは描画されます。これらはスライドを [PNG](/slides/ja/php-java/convert-powerpoint-to-png/) にレンダリングする場合、[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/) にエクスポートする場合、[HTML](/slides/ja/php-java/convert-powerpoint-to-html/) にエクスポートする場合、または [video conversion](/slides/ja/php-java/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

留意点:

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、ライトリグ、材質、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承されたまたはテーマベースの書式設定値を確認したい場合は、[effective shape properties](/slides/ja/php-java/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的な結果がレンダリングされ、編集可能な 3D 設定としては保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成・レンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはできません。PPTX 形式では、フォーマットがサポートしている限り 3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は通常の PowerPoint シェイプやテキストに適用される書式設定で、回転、押し出し、ベベル、照明、材質などを指します。本記事は 3D 効果について扱っています。

**視覚的に 3D なシェイプに必要な設定は何ですか？**

最低限、カメラ回転と押し出しまたは奥行きを設定します。実務では、ハイライトと影をはっきりさせるためにライトリグと材質も設定することが一般的です。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [Shape::getThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getThreeDFormat--) を、テキストには [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#getThreeDFormat--) を使用します。

**画像、PDF、HTML、またはビデオフレームにエクスポートすると 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリング結果が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。最終的なカメラ、ライトリグ、ベベル、その他 3D 値を取得するには、[Shape Effective Properties](/slides/ja/php-java/shape-effective-properties/) に記載されている有効書式設定 API を使用してください。