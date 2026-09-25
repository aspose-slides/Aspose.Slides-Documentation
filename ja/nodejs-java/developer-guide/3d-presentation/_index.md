---
title: Node.js を使用してプレゼンテーションに 3D エフェクトを作成する
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用して Node.js で PowerPoint のシェイプとテキストに 3D エフェクトを適用およびレンダリングします。カメラ、照明、マテリアル、押し出し、塗りつぶし、3D テキストを構成します。"
---
## **Overview**

Aspose.Slides for Node.js via Java は、シェイプやテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、マテリアル、グラデーションまたは画像塗りつぶし、3D テキストといった 3D エフェクトについて説明します。

{{% alert color="info" title="Note" %}}
記事では、PowerPoint のシェイプとテキストに対する 3D 書式効果について説明します。単独の 3D モデルファイルの挿入や編集については扱いません。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[Shape.getThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getThreeDFormat) メソッドを使用します。このメソッドは、シェイプの 3D シーンを制御する [ThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/) を返します。

テキストの場合は、[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) メソッドを使用します。これにより、シェイプ本体ではなくテキストフレームに 3D 書式設定が適用されます。

| API メンバー | 制御対象 | 使用するタイミング |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getCamera) | 視点、プリセットカメラタイプ、回転、ズーム、遠近法。 | 3D 空間でオブジェクトを回転させる、または PowerPoint の 3D 回転プリセットと合わせる場合。 |
| [getLightRig](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getLightRig) | ライトのプリセット、方向、ライトの回転。 | 3D 表面のハイライトや影の表示方法を変更する場合。 |
| [getMaterial](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#setMaterial) | フラット、マット、プラスチック、金属などの表面素材。 | 同じ形状をより平坦に、柔らかく、光沢あり、金属的に見せる場合。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | シェイプが正面からどれだけ後方に伸びるか。 | 平面のシェイプを目に見える厚みのある 3D オブジェクトに変える場合。 |
| [getExtrusionColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | 押し出された側面の色。 | 奥行きを見えるようにしたり、側面の色を前面の塗りと合わせる場合。 |
| [getDepth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint の 3D 書式設定で使用される追加の 3D 奥行き。 | ベベルや素材設定と組み合わせて、シェイプやテキストの奥行きを微調整したい場合。 |
| [getBevelTop](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | 正面と背面のエッジを上げたり丸くしたりする。 | 鋭い平面の代わりに、柔らかく成形されたエッジを追加したい場合。 |
| [getContourColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D オブジェクトの輪郭線。 | レンダリングされた出力でオブジェクトの境界を強調したい場合。 |

## **3D シェイプの作成**

シェイプが説得力のある 3D に見えるまでに、通常は以下の 4 種類の設定が必要です。

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れる可能性があるため。
- ライト設定：照明により面や側面が見やすくなるため。
- 素材設定：表面が光の描画に影響するため。
- 押し出しまたは奥行き設定：平面のシェイプに厚みを持たせるため。

以下の例は、矩形を作成し、正面にテキストを追加して 3D 書式設定を適用します。カメラの回転値は度単位で、押し出し高さは 100 ポイントです。例はスライドをデフォルトの 2 倍サイズの PNG 画像にレンダリングし、プレゼンテーションを PPTX として保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

レンダリングされたスライド画像は、矩形が厚みのある 3D ブロックとして表示されます。

![正面に白色 3D テキストがある青い 3D 矩形のレンダー画像](img_01_01.png)

## **カメラでシェイプを回転する**

PowerPoint では、3D 回転は「3‑D 回転」ペインで設定します。X、Y、Z の回転値は、カメラ API で設定する回転に対応しています。

![X、Y、Z 回転値がハイライトされた PowerPoint の 3‑D 回転ペイン](img_02_01.png)

Aspose.Slides では、[ThreeDFormat.getCamera](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getCamera) を介してカメラにアクセスします。この例は矩形を作成し、正射投影の正面ビューを選択し、X、Y、Z の回転をそれぞれ 20°, 30°, 40° に設定します。ファイルを保存せずにメモリ上でシェイプを構成します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

ビューアがオブジェクトを見る視点を変更したいときにカメラを使用します。スライド上の 2D シェイプジオメトリは変更されません。PowerPoint および Aspose.Slides がレンダリング時に使用する 3D 視点が変更されます。

## **押し出しと奥行きの追加**

押し出しは、シェイプの正面の背後に拡張することで厚みを持たせます。PowerPoint では、奥行きコントロールがこの可視的な厚さを設定し、色コントロールが側面の色を設定します。

![押し出しカラーと押し出し高さプロパティに対応する PowerPoint の奥行きコントロール](img_02_02.png)

[ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) で厚さを設定し、[ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) で側面の色を取得します。この例は矩形に 100 ポイントの押し出しを付け、側面を紫色にし、カメラを回転させて厚みを表示します。ファイルを保存せずにメモリ上でシェイプを構成します:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#setDepth) メソッドは 3D シェイプの奥行きを設定します。[setExtrusionHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) メソッドは、押し出し効果の高さを制御します（この例を参照）。

## **3D エフェクトとグラデーションまたは画像塗りつぶしの使用**

3D 書式設定はシェイプの塗りつぶしとは独立しています。正面に単色、グラデーション、パターン、画像塗りつぶしを適用しても、同じカメラ、ライト、素材、押し出し設定を使用できます。

この例では、正面に青からオレンジへのグラデーションを適用し、150 ポイントの押し出しに濃いオレンジ色を設定しています。グラデーションは 0 と 100 の位置で開始と終了を示します。カメラの回転値は度単位です。スライドはデフォルトの 2 倍サイズの PNG 画像にレンダリングされます:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

レンダリングされた出力では、正面のグラデーションが保持され、押し出しは別にレンダリングされます。

![青からオレンジへのグラデーション塗りつぶしとオレンジの押し出しを持つ 3D 矩形のレンダー画像](img_02_03.png)

画像塗りつぶしを使用するには、画像をプレゼンテーションに追加し、シェイプの塗りつぶしに割り当てます。この例は作業ディレクトリに "image.jpg" という名前の既存ファイルがあることを前提としています。画像を矩形全体に伸ばし、150 ポイントの押し出しを適用し、カメラの回転を度単位で設定します。ファイルを保存したりレンダリングしたりせずに、メモリ上でシェイプを構成します:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![正面に写真塗りつぶし、橙色の押し出しを持つ 3D 矩形のレンダー画像](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。これは、文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に有用です。

以下の例は、オレンジと白の格子パターンのテキストを作成し、上向きのアーチを適用し、[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) を介して 3D 設定を構成します。押し出し高さと奥行きはポイント単位、ライトの回転は度単位です。シェイプの塗りつぶしと輪郭は非表示にし、テキストのみが見えるようにします。例はデフォルトスライドサイズの 2 倍の PNG 画像にレンダリングし、プレゼンテーションを PPTX として保存します：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![アーチ形に変形した WordArt、オレンジのパターン塗りつぶし、暗い押し出しを持つ 3D テキストのレンダー画像](img_02_05.png)

## **3D シェイプ上でテキストを平面に保つ**

シェイプの 3D 外観を保ちつつテキストを読みやすくするには、[TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) を介して [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) を呼び出します。値が `true` の場合、テキストは 3D シーンから除外されます。`false` の場合、テキストはシーンに参加し、3D 向きに従います。

この設定はシェイプの 3D 書式設定（カメラ、照明、素材、押し出し）を削除しません。これらは [Shape.getThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getThreeDFormat) を通じて構成されたままです。また、通常の回転とは異なります。[Shape.setRotation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#setRotation) はスライド平面上でシェイプを回転させ、[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) はテキストのバウンディングボックス内でのカスタム回転を制御します。テキストを 3D シーンから除外しても、これらの角度はリセットされません。

以下の単体例は、テキスト付きの青い矩形を作成し、元の横にクローンを作ります。両方のシェイプは同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左側は `false`、右側は `true`。カメラ角度は度単位、押し出し高さは 40 ポイントです。例はプレゼンテーションを PPTX として保存し、比較スライドをデフォルトの 2 倍サイズの PNG にレンダリングします。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

左側ではテキストが 3D の向きに従い、右側では平面のままで読みやすくなります。両方の矩形は同じ可視的な押し出しと 3D 向きを保持しています。

![左側はテキストが 3D 向きに従い、右側は平面のままの 3D 矩形を並べた比較画像](keep_text_flat.png)

## **エクスポートとレンダリングの挙動**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズされ、2D の結果として出力に描画されます。これは、スライドを [PNG](/slides/ja/nodejs-java/convert-powerpoint-to-png/)、[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/) にエクスポートする、あるいは [video conversion](/slides/ja/nodejs-java/convert-powerpoint-to-video/) 用のフレームを生成する際にも適用されます。

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にオブジェクトを回転させることはできません。
- 最終的な外観は、カメラ、ライトリグ、素材、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承された値やテーマベースの書式設定値を確認する必要がある場合は、[effective shape properties](/slides/ja/nodejs-java/shape-effective-properties/) を参照してください。
- 一部の出力形式は、編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的な結果がレンダリングされ、編集可能な 3D 設定としては保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはできません。PPTX では、形式がサポートしている限り、3D 書式設定は PowerPoint で編集可能です。

**3D モデルと 3D エフェクトの違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D エフェクトは、回転、押し出し、ベベル、照明、素材など、通常の PowerPoint シェイプやテキストに適用される書式設定です。本稿は 3D エフェクトについて取り上げています。

**可視的な 3D シェイプに必要な設定は何ですか？**

最低でもカメラ回転と押し出しまたは奥行きを設定します。実際には、ライトリグと素材も設定して、レンダリングされた面に明瞭なハイライトと影が出るようにします。

**シェイプとテキストの両方に 3D エフェクトを適用できますか？**

はい。シェイプ本体には [Shape.getThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getThreeDFormat) を、テキストには [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) を使用します。

**画像、PDF、HTML、またはビデオフレームにエクスポートした場合、3D エフェクトは表示されますか？**

はい。Aspose.Slides はスライド画像、PDF、HTML、ビデオ変換用フレームを生成する際に 3D エフェクトをレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。最終的なカメラ、ライトリグ、ベベル、関連する 3D 値を取得するには、[Shape Effective Properties](/slides/ja/nodejs-java/shape-effective-properties/) で説明されている有効な書式設定 API を使用します。