---
title: PHP を使用したプレゼンテーションでの 3D エフェクト作成
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
description: "Aspose.Slides を使用して PHP で PowerPoint の図形とテキストに 3D エフェクトを適用し、レンダリングします。カメラ、照明、素材、押し出し、塗りつぶし、3D テキストを設定します。"
---
## **概要**

Aspose.Slides for PHP via Java は、図形やテキストに対して PowerPoint スタイルの 3D 書式設定を作成、編集、保持、描画できます。この記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像の塗りつぶし、3D テキストなどの 3D 効果について説明します。

{{% alert color="info" title="Note" %}}
この記事は PowerPoint の図形とテキストに対する 3D 書式設定効果について説明しています。単体の 3D モデルファイルの挿入や編集については対象外です。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

形状に 3D 書式設定を適用するには、[Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) メソッドを使用します。このメソッドは [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) を返し、その形状の 3D シーンを制御します。

テキストの場合は、[TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) メソッドを使用します。これにより、形状本体ではなくテキスト フレームに 3D 書式設定が適用されます。

最も重要な API メンバーは次のとおりです:

| API メンバー | 制御内容 | 使用タイミング |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | 視点、プリセット カメラタイプ、回転、ズーム、および遠近感。 | オブジェクトを 3D 空間で回転させる、または PowerPoint の 3D 回転プリセットに合わせる。 |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | 光のプリセット、方向、光の回転。 | ハイライトと影が 3D 表面上でどのように表示されるかを変更します。 |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | 平面、マット、プラスチック、金属などの表面素材。 | 同じ形状をより平坦に、柔らかく、光沢のある、または金属的に見せる。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | 形状が正面からどれだけ後方に延びるか。 | 平面の形状を目に見える厚みのある 3D オブジェクトに変える。 |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | 押し出された側面の色。 | 奥行きを見せる、または側面の色を正面の塗りつぶしと合わせる。 |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | PowerPoint の 3D 書式設定で使用される追加の 3D 奥行き。 | 特にベベルや素材設定と組み合わせて、形状やテキストの奥行きを微調整する。 |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | 前面と背面のエッジを隆起または丸めたもの。 | 鋭い平面の代わりに、柔らかく成形されたエッジを追加する。 |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | 3D オブジェクトの輪郭線。 | レンダリング出力でオブジェクトの境界を強調する。 |

## **3D 形状の作成**

形状が説得力のある 3D に見えるためには、通常、4 種類の設定が必要です:
- カメラ設定：デフォルトの正面ビューでは押し出しが隠れる可能性があるため。
- 光設定：照明により表面と側面が見やすくなるため。
- 素材設定：表面が光の描画に影響するため。
- 押し出しまたは奥行き設定：平面の形状に厚みが必要なため。

次の例は、長方形を作成し、正面にテキストを追加し、3D 書式設定を適用します。カメラの回転値は度単位で、押し出し高さは 100 ポイントです。この例は、スライドをデフォルトサイズの 2 倍の PNG 画像にレンダリングし、プレゼンテーションを PPTX として保存します。

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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

レンダリングされたスライド画像は、長方形が太い 3D ブロックとして表示されます:
![正面に白い 3D テキストがある青い 3D 長方形のレンダリング画像](img_01_01.png)

## **カメラで形状を回転する**

PowerPoint では、3D 回転は「3-D 回転」ペインで設定します。X、Y、Z の回転値はカメラ API で設定した回転に対応します。

![X、Y、Z の回転値がハイライトされた PowerPoint の 3-D 回転ペイン](img_02_01.png)

Aspose.Slides では、[ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) を介してカメラにアクセスします。この例は長方形を作成し、正投影の正面ビューを選択し、X、Y、Z の回転をそれぞれ 20、30、40 度に設定します。ファイルを保存せずにメモリ上で形状を構成します:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

カメラは、ビューアがオブジェクトを見る角度を変更する必要がある場合に使用します。スライド上の 2D 形状ジオメトリは変更されません。PowerPoint および Aspose.Slides がレンダリング時に使用する 3D ビューポイントが変更されます。

### **テンプレート形状からカメラの向きをコピーする**

テンプレート形状の向きを合わせるには、[Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) でカメラのプリセットを取得し、[Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation) で回転角度を取得します。この例は `template.pptx` を開き、最初のスライドの最初の形状から 2 番目の形状へカメラの向きをコピーします。両方の形状はすでに 3D 照明を持ち、2 番目の形状には明示的なカメラ回転がありません。

角度は度単位です。インデックス `0` が緯度、`1` が経度、`2` が回転を表します。この順序で [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) に渡します。ソースが `null` を返す場合は明示的な回転がないため、2 番目の形状の角度は設定しません。`(0, 0, 0)` の明示的な回転は 3 つのゼロを返すのでコピーします。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`camera-copy.pptx` を PowerPoint で再度開くと、右側の矢印は左側の長方形と同じカメラプリセットと回転を持ちます。両方の形状は同じ照明と押し出し深さを使用しています。

![上方および右側から見た、カメラの向きが一致した青い 3D 長方形と右向き矢印](camera-orientation.png)

## **押し出しと奥行きの追加**

押し出しは、形状の正面の後ろへ拡張することで厚みを持たせます。PowerPoint では、奥行きコントロールがこの可視的な厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の奥行きコントロールが押し出しカラーと押し出し高さプロパティに対応しています](img_02_02.png)

[ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) を使用して厚さを設定し、[ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) で側面の色を取得します。この例は、長方形に 100 ポイントの押し出しと紫色の側面を付け、カメラを回転させて厚みを示します。ファイルを保存せずにメモリ上で形状を構成します:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

[ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) メソッドは 3D 形状の奥行きを設定します。[setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) メソッドは押し出し効果の高さを制御します。この例のように。

## **グラデーションまたは画像塗りつぶしを 3D 効果と併用する**

3D 書式設定は形状の塗りつぶしとは独立しています。正面に単色、グラデーション、パターン、画像塗りつぶしのいずれかを適用しながら、同じカメラ、光、素材、押し出し設定を使用できます。

この例は、正面に青からオレンジへのグラデーションを適用し、150 ポイントの押し出しに濃いオレンジ色を設定します。グラデーションの開始と終了はそれぞれ 0 と 100 で示されます。カメラの回転値は度単位です。スライドはデフォルトサイズの 2 倍の PNG 画像にレンダリングされます:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

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

レンダリングされた出力は、正面のグラデーションを保持し、押し出しを別個に描画します:
![青からオレンジへのグラデーション塗りとオレンジ押し出しを持つ 3D 長方形のレンダリング画像](img_02_03.png)

画像塗りつぶしを使用するには、画像をプレゼンテーションに追加し、形状の塗りつぶしに割り当てます。この例は作業ディレクトリに "image.jpg" という名前の既存ファイルが必要です。画像を伸縮して長方形を満たし、150 ポイントの押し出しを適用し、カメラ回転を度単位で設定します。ファイルを保存またはレンダリングせずにメモリ上で形状を構成します:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

![正面に写真塗りつぶし、オレンジ押し出しを持つ 3D 長方形のレンダリング画像](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

形状の 3D 書式設定は形状本体に影響し、テキストの 3D 書式設定はテキスト フレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例は、オレンジと白の格子パターンのテキストを作成し、上向きのアーチを適用し、[TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) を使用して 3D 設定を構成します。押し出し高さと奥行きはポイント単位、光の回転は度単位です。形状の塗りつぶしと輪郭は非表示にし、テキストのみが表示されます。この例はデフォルトスライドサイズの 2 倍の PNG 画像をレンダリングし、プレゼンテーションを PPTX として保存します:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

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
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
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

![アーチ状の WordArt 変形、オレンジのパターン塗り、暗い押し出しを持つ 3D テキストのレンダリング画像](img_02_05.png)

## **3D 形状上でテキストを平面のまま保つ**

形状の 3D 外観を維持しつつテキストを読みやすく保つには、[TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat) を介して [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) を呼び出します。値が `true` の場合、テキストは 3D シーンから除外されます。`false` の場合、テキストはシーンに参加し、3D の向きに従います。

この設定は形状の 3D 書式設定（カメラ、照明、素材、押し出し）を削除しません。これらは [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) を介して構成されたままです。また、通常の回転とは異なります。[Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) はスライド平面上で形状を回転させ、[TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) はテキストのバウンディング ボックス内でのカスタム回転を制御します。テキストを 3D シーンから除外しても、これらの角度はリセットされません。

以下の単体例は、テキスト付きの青い長方形を作成し、元の横にクローンを作ります。両方の形状は同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左は `false`、右は `true`。カメラ角度は度単位、押し出し高さは 40 ポイントです。この例はプレゼンテーションを PPTX として保存し、比較スライドをデフォルトサイズの 2 倍の PNG にレンダリングします。

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

左側ではテキストが 3D の向きに従います。右側ではテキストが平面のままで読みやすくなります。両方の長方形は同じ可視的な押し出しと 3D 向きを保持しています。

![左右に並んだ 3D 長方形：左はテキストが 3D 向きに従い、右は平面のまま](keep_text_flat.png)

## **エクスポートとレンダリングの挙動**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスター化または 2D 結果として出力に描画されます。これは、スライドを [PNG](/slides/ja/php-java/convert-powerpoint-to-png/) にレンダリングする、[PDF](/slides/ja/php-java/convert-powerpoint-to-pdf/) にエクスポートする、[HTML](/slides/ja/php-java/convert-powerpoint-to-html/) にエクスポートする、または [video conversion](/slides/ja/php-java/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

- エクスポートされた画像や PDF はインタラクティブではありません。オブジェクトはエクスポート後にビューアによって回転できません。
- 最終的な外観はカメラ、光源、素材、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承されたまたはテーマベースの書式設定値を確認する必要がある場合は、[形状の有効プロパティ](/slides/ja/php-java/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint の 3D 書式設定を保存できません。そのような形式では、視覚的結果はレンダリングされたものであり、編集可能な 3D 設定として保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides は形状とテキストの PowerPoint 3D 効果を作成およびレンダリングします。エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはありません。PPTX では、形式がサポートしている場合、3D 書式設定は PowerPoint 内で編集可能なまま保持されます。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は、回転、押し出し、ベベル、照明、素材など、通常の PowerPoint の形状やテキストに適用される書式設定です。この記事では 3D 効果について解説します。

**見える 3D 形状に必要な設定は何ですか？**

最低限、カメラの回転と押し出しまたは奥行きを設定します。実際には、レンダリングされた面に明確なハイライトと影を付けるために、光源と素材も設定します。

**形状とテキストの両方に 3D 効果を適用できますか？**

はい。形状本体には [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) を、テキストには [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) を使用します。

**画像、PDF、HTML、またはビデオフレームにエクスポートしたときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用のフレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を読み取れますか？**

はい。[形状の有効プロパティ](/slides/ja/php-java/shape-effective-properties/) に記載された有効な書式設定 API を使用して、最終的なカメラ、光源、ベベル、関連する 3D 値を取得できます。