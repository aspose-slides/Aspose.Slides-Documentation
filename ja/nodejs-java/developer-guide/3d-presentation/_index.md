---
title: Node.js を使用してプレゼンテーションに 3D 効果を作成
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
description: "Node.js で Aspose.Slides を使用して PowerPoint のシェイプとテキストに 3D 効果を適用し、レンダリングします。カメラ、照明、素材、押し出し、塗りつぶし、および 3D テキストを構成します。"
---
## **概要**

Aspose.Slides for Node.js via Java は、シェイプとテキストの PowerPoint スタイルの 3D 書式設定を作成、編集、保持、レンダリングできます。この記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像塗りつぶし、3D テキストなどの 3D 効果について説明します。

{{% alert color="info" title="Note" %}}
この記事は、PowerPoint のシェイプとテキストに対する 3D 書式設定効果についてです。単体の 3D モデル ファイルの挿入や編集については扱いません。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) メソッドを使用します。このメソッドは、シェイプの 3D シーンを制御する [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) を返します。

テキストの場合は、[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) メソッドを使用します。これにより、シェイプ本体ではなくテキストフレームに 3D 書式設定が適用されます。

最も重要な API メンバーは次のとおりです:

| API メンバー | 制御内容 | 使用するタイミング |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | 視点、プリセットカメラタイプ、回転、ズーム、および遠近感。 | オブジェクトを 3D 空間で回転させるか、PowerPoint の 3D 回転プリセットと一致させるために使用します。 |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | ライトのプリセット、方向、光の回転。 | 3D 表面上のハイライトと影の表示方法を変更します。 |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) と [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | 平坦、マット、プラスチック、金属などの表面素材。 | 同じ形状をより平坦に、柔らかく、光沢のある、または金属感のある外観にします。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) と [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | シェイプが前面からどれだけ後方に伸びるか。 | 平面のシェイプを視覚的に厚みのある 3D オブジェクトに変換します。 |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | 押し出された側面の色。 | 奥行きを可視化するか、側面の色を前面の塗りつぶしと調整します。 |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) と [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint の 3D 書式設定で使用される追加の 3D 奥行き。 | シェイプやテキストの奥行きを微調整します。特にベベルや素材設定と組み合わせる場合に有効です。 |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) と [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | 前面と背面のエッジが上がったり丸められた形状。 | 鋭い平面の代わりに、柔らかいまたは成形されたエッジを追加します。 |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor)、[getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth) と [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D オブジェクトの輪郭。 | レンダリングされた出力でオブジェクトの境界を強調します。 |

## **3D シェイプの作成**

シェイプが説得力のある 3D に見えるまでに、通常は次の 4 種類の設定が必要です:

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れる可能性があるため。
- 照明設定：光が面と側面を見やすくするため。
- 素材設定：表面が光のレンダリングに影響するため。
- 押し出しまたは奥行き設定：平面のシェイプに厚みが必要なため。

以下の例では、長方形を作成し、前面にテキストを追加し、3D 書式設定を適用します。カメラの回転値は度単位で、押し出し高さは 100 ポイントです。この例は、スライドをデフォルトサイズの 2 倍の PNG 画像としてレンダリングし、プレゼンテーションを PPTX として保存します。

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

レンダリングされたスライド画像は、長方形が厚みのある 3D ブロックとして表示されます:

![前面に白い 3D テキストがある青い 3D 長方形がレンダリングされた画像](img_01_01.png)

## **カメラでシェイプを回転させる**

PowerPoint では、3D 回転は「3-D 回転」ペインから設定します。X、Y、Z の回転値は、カメラ API を介して設定した回転に対応します。

![X、Y、Z の回転値がハイライトされた PowerPoint の 3-D 回転ペイン](img_02_01.png)

Aspose.Slides では、[ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) を通じてカメラにアクセスします。この例では、長方形を作成し、正投影の正面ビューを選択し、X、Y、Z の回転をそれぞれ 20、30、40 度に設定します。ファイルを保存せずにメモリ内でシェイプを構成します:

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

カメラは、ビューアがオブジェクトを見る視点を変更したいときに使用します。スライド上の 2D シェイプのジオメトリは変更されません。PowerPoint と Aspose.Slides がレンダリング時に使用する 3D ビューポイントが変更されます。

### **テンプレートシェイプからカメラの向きをコピーする**

テンプレートシェイプの向きを合わせるには、[getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) でカメラのプリセットを取得し、[getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation) で回転角度を取得します。この例では `template.pptx` を開き、最初のスライドの最初のシェイプからカメラの向きを取得し、2 番目のシェイプにコピーします。両方のシェイプはすでに 3D 照明が設定されており、2 番目のシェイプには明示的なカメラ回転がありません。

角度は度単位です。インデックス `0` が緯度、インデックス `1` が経度、インデックス `2` が回転を表します。この順序で [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) に渡します。ソースが `null` を返す場合、明示的な回転が設定されていないので、2 番目のシェイプの角度は未設定のままにします。`(0, 0, 0)` の明示的な回転は 0 が 3 つ返され、コピーすべきです。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint で `camera-copy.pptx` を再度開くと、右側の矢印は左側の長方形と同じカメラのプリセットと回転を持っています。両方のシェイプは同じ照明と押し出しの深さを使用しています。

![上方右側から見た、カメラの向きが一致した青い 3D 長方形と右矢印](camera-orientation.png)

## **押し出しと奥行きの追加**

押し出しは、シェイプの前面の背後に拡張することで厚みを付与します。PowerPoint では、奥行きコントロールがこの可視的な厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の奥行きコントロールが押し出しの色と高さプロパティに対応付けられた図](img_02_02.png)

[ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) を使用して厚さを設定し、[ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) で側面の色を取得します。この例では、長方形に 100 ポイントの押し出しと紫色の側面を設定し、カメラを回転させて厚みを明らかにしています。ファイルを保存せずにメモリ内でシェイプを構成します:

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

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) メソッドは 3D シェイプの奥行きを設定します。[setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) メソッドは押し出し効果の高さを制御します。この例で示されています。

## **3D 効果とグラデーションまたは画像塗りつぶしの使用**

3D 書式設定はシェイプの塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、または画像塗りつぶしを適用しながら、同じカメラ、光、素材、押し出し設定を使用できます。

この例では、前面に青からオレンジへのグラデーションを適用し、150 ポイントの押し出しに濃いオレンジ色を設定します。グラデーションの停止点は 0 と 100で、グラデーションの開始と終了を示します。カメラの回転値は度単位です。スライドはデフォルトサイズの 2 倍の PNG 画像としてレンダリングされます:

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

レンダリングされた出力は、前面のグラデーションを保持し、押し出しを別々にレンダリングします:

![青からオレンジへのグラデーション塗りとオレンジ色の押し出しを持つ 3D 長方形がレンダリングされた画像](img_02_03.png)

画像塗りつぶしを使用するには、画像をプレゼンテーションに追加し、シェイプの塗りつぶしに割り当てます。この例では、作業ディレクトリに "image.jpg" という既存のファイルが必要です。画像を長方形に伸ばし、150 ポイントの押し出しを適用し、カメラの回転を度単位で設定します。ファイルを保存またはレンダリングせずにメモリ内でシェイプを構成します:

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

画像は前面にレンダリングされ、押し出しは 3D の側面としてレンダリングされます:

![前面に写真塗り、オレンジ色の押し出しを持つ 3D 長方形がレンダリングされた画像](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響します。テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例では、オレンジと白の格子パターンのテキストを作成し、上向きのアーチを適用し、[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) を通じて 3D 設定を構成します。押し出し高さと奥行きはポイント単位、光の回転は度単位です。シェイプの塗りつぶしと輪郭は非表示にし、テキストのみが見えるようにします。この例は、スライドのデフォルトサイズの 2 倍の PNG 画像としてレンダリングし、プレゼンテーションを PPTX として保存します:

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

テキストは曲線状で押し出された 3D 文字としてレンダリングされます:

![アーチ形の WordArt 変換、オレンジのパターン塗り、暗い押し出しを持つ 3D テキストがレンダリングされた画像](img_02_05.png)

## **3D シェイプ上でテキストを平坦に保つ**

シェイプの 3D 見た目を維持しつつテキストを読みやすくするには、[TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) を介して [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) を呼び出します。値が `true` の場合、テキストは 3D シーンから除外されます。`false` の場合、テキストはシーンに参加し、3D の向きに従います。

この設定はシェイプの 3D 書式設定を削除するものではありません：カメラ、照明、素材、押し出しは [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) を通じて引き続き構成されています。また、通常の回転とは異なります。[Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) はスライド平面上でシェイプを回転させ、[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) はバウンディングボックス内でテキストのカスタム回転を制御します。テキストを 3D シーンから除外しても、これらの角度はリセットされません。

以下の完全な例では、テキスト付きの青い長方形を作成し、元の横にクローンを作ります。両方のシェイプは同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左側は `false`、右側は `true`。カメラの角度は度単位で、押し出し高さは 40 ポイントです。この例はプレゼンテーションを PPTX として保存し、比較スライドをデフォルトサイズの 2 倍の PNG としてレンダリングします。

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

左側ではテキストが 3D の向きに従います。右側ではテキストが平坦に保たれ、読みやすくなります。両方の長方形は同じ可視的な押し出しと 3D の向きを保持しています。

![並べて表示された 3D 長方形：左側はテキストが 3D の向きに従い、右側は平坦に保たれる](keep_text_flat.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスター化され、2D 結果として出力に描画されます。これは、スライドを [PNG](/slides/ja/nodejs-java/convert-powerpoint-to-png/) にレンダリングしたり、[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) にエクスポートしたり、[HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/) にエクスポートしたり、[video conversion](/slides/ja/nodejs-java/convert-powerpoint-to-video/) 用のフレームを生成する場合にも適用されます。

- エクスポートされた画像や PDF はインタラクティブではありません。オブジェクトはエクスポート後にビューアで回転できません。
- 最終的な外観は、カメラ、光源、素材、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承された値やテーマベースの書式設定値を確認する必要がある場合は、[effective shape properties](/slides/ja/nodejs-java/shape-effective-properties/) を参照してください。
- 一部の出力形式では、編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的な結果はレンダリングされ、編集可能な 3D 設定として保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成およびレンダリングします。エクスポートされた画像、PDF、HTML ページをビューアが回転させられるインタラクティブな 3D シーンにすることはありません。PPTX では、フォーマットがサポートしている場合、3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果はシェイプやテキストに適用される書式設定で、回転、押し出し、ベベル、照明、素材などがあります。本記事は 3D 効果について解説しています。

**可視的な 3D シェイプに必要な設定は何ですか？**

最低限、カメラの回転と押し出しまたは奥行きを設定します。実務では、レンダリングされた面に明確なハイライトと影が付くように、光源と素材も設定します。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) を、テキストには [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) を使用してください。

**画像、PDF、HTML、またはビデオフレームにエクスポートするときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承とテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。[Shape Effective Properties](/slides/ja/nodejs-java/shape-effective-properties/) で説明されている有効な書式設定 API を使用して、最終的なカメラ、光源、ベベル、および関連する 3D 値を取得してください。