---
title: Node.js を使用したプレゼンテーションでの 3D 効果の作成
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
description: "Node.js と Aspose.Slides を使用して PowerPoint のシェイプとテキストに 3D 効果を適用およびレンダリングします。カメラ、ライティング、素材、押し出し、塗り、3D テキストを設定します。"
---
## **概要**

Node.js 用 Aspose.Slides（Java 経由）は、シェイプやテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、ライティング、素材、グラデーションまたは画像塗り、3D テキストなどの 3D 効果について説明します。

{{% alert color="primary" %}}

この記事は PowerPoint のシェイプとテキストに対する 3D 書式設定効果についてです。スタンドアロンの 3D モデルファイルの挿入や編集に関するものではありません。スライドを画像、PDF、または HTML にエクスポートする際、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。

{{% /alert %}}

## **3D 書式設定の概念**

[Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` を使用してシェイプに 3D 書式設定を適用します。返される [ThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/) オブジェクトはそのシェイプの 3D シーンを制御します。

テキストの場合は、[TextFrameFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` を使用します。これはシェイプ本体ではなくテキストフレームに 3D 書式設定を適用します。

最も重要な API メンバーは次のとおりです：

| API メンバー | 制御内容 | 使用する場面 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getCamera) | 視点、プリセットカメラタイプ、回転、ズーム、および遠近法。 | オブジェクトを 3D 空間で回転させる、または PowerPoint の 3D 回転プリセットに合わせるとき。 |
| [getLightRig](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getLightRig) | ライトのプリセット、方向、ライトの回転。 | 3D 表面上のハイライトと影の表示方法を変更するとき。 |
| [getMaterial](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getMaterial) と [setMaterial](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#setMaterial) | 平坦、マット、プラスチック、金属などの表面素材。 | 同じ形状をより平坦、柔らかい、光沢のある、または金属的に見せるとき。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) と [setExtrusionHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | 形状が前面からどれだけ後方へ伸びるか。 | 平坦な形状を厚みのある 3D オブジェクトに変えるとき。 |
| [getExtrusionColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | 押し出された側面の色。 | 奥行きを見せる、または側面の色を前面の塗りと合わせるとき。 |
| [getDepth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getDepth) と [setDepth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint の 3D 書式設定で使用される追加の 3D 奥行き。 | 形状やテキストの奥行きを微調整する、特にベベルや素材設定と組み合わせるとき。 |
| [getBevelTop](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getBevelTop) と [getBevelBottom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | 前面と背面のエッジの上げまたは丸み。 | 鋭い平坦面の代わりに柔らかいまたは成形されたエッジを追加するとき。 |
| [getContourColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getContourColor)、[getContourWidth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getContourWidth) と [setContourWidth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D オブジェクトの周囲のアウトライン。 | レンダリング出力でオブジェクトの境界を強調するとき。 |

## **3D シェイプの作成**

シェイプが納得のいく 3D に見えるまでには、通常、4 種類の設定が必要です：

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れる可能性があるため。
- ライト設定：照明により面や側面が見やすくなるため。
- 素材設定：表面が光の描画方法に影響するため。
- 押し出しまたは奥行き設定：平坦な形状に厚みが必要なため。

次の例は長方形を作成し、前面にテキストを追加し、3D 書式設定を適用してプレゼンテーションを PPTX として保存し、スライドを PNG 画像にレンダリングします。

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

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

レンダリングされたスライド画像は、長方形が厚みのある 3D ブロックとして表示されます：

![前面に白い 3D テキストがある青い 3D 長方形のレンダリング画像](img_01_01.png)

## **カメラでシェイプを回転させる**

PowerPoint では、3D 回転は「3-D 回転」ペインで設定します。X、Y、Z の回転値はカメラ API を通じて設定する回転に対応しています。

![X、Y、Z の回転値がハイライトされた PowerPoint の 3-D 回転ペイン](img_02_01.png)

Aspose.Slides では、`shape.getThreeDFormat()` が返す 3D フォーマットを通じてカメラタイプと回転を設定します：

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

ビューアがオブジェクトを見る視点を変更したいときにカメラを使用します。これはスライド上の 2D シェイプのジオメトリを変更するものではなく、PowerPoint および Aspose.Slides がレンダリング時に使用する 3D 視点を変更します。

## **押し出しと奥行きの追加**

押し出しは前面の背後に形状を伸ばすことで、シェイプを厚く見せます。PowerPoint では、奥行きコントロールがこの可視的な厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の奥行きコントロールが押し出しの色と押し出し高さプロパティに対応している様子](img_02_02.png)

厚さには押し出し高さを、側面の色には押し出し色を設定します：

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

PowerPoint の奥行き値を直接操作したい場合や、奥行きをベベル、素材、テキスト効果と組み合わせたい場合は depth 設定を使用します。多くのシェイプシナリオでは、押し出し高さの方が可視的な押し出しを直接示すため、より分かりやすい設定です。

## **3D 効果とともにグラデーションまたは画像塗りを使用する**

3D 書式設定はシェイプの塗りから独立しています。前面に単色、グラデーション、パターン、または画像塗りを適用しても、同じカメラ、ライト、素材、押し出し設定を使用できます。

この例ではシェイプにグラデーション塗りを適用し、側面に濃い押し出し色を設定します：

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

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

レンダリング結果は前面のグラデーションを保持し、押し出しは別個にレンダリングされます：

![青からオレンジへのグラデーション塗りとオレンジ色の押し出しを持つ 3D 長方形のレンダリング画像](img_02_03.png)

画像塗りを使用する場合は、画像をプレゼンテーションに追加し、シェイプの塗りに割り当てます：

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

前面に写真塗り、側面にオレンジ色の押し出しがある 3D 長方形のレンダリング画像：

![前面に写真塗り、側面にオレンジ色の押し出しがある 3D 長方形のレンダリング画像](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、素材、ライティング、カメラ設定が必要な WordArt のような効果に便利です。

次の例はテキストを作成し、パターン塗りを適用し、WordArt 変形を設定し、[TextFrameFormat] の 3D 設定を構成します：

```javascript
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
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
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

アーチ状の WordArt 変形、オレンジのパターン塗り、濃い押し出しを持つ 3D テキストのレンダリング画像：

![アーチ状の WordArt 変形、オレンジのパターン塗り、濃い押し出しを持つ 3D テキストのレンダリング画像](img_02_05.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式にレンダリングまたはエクスポートする場合、3D シーンはラスター化され、出力は 2D 結果として描画されます。これはスライドを [PNG](/slides/ja/nodejs-java/convert-powerpoint-to-png/) にレンダリングする、[PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) にエクスポートする、[HTML](/slides/ja/nodejs-java/convert-powerpoint-to-html/) にエクスポートする、または [video conversion](/slides/ja/nodejs-java/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

以下の点に留意してください：

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、ライトリグ、素材、押し出し、塗り、スライドのスケーリングの組み合わせに依存します。
- 継承されたまたはテーマベースの書式設定値を確認する必要がある場合は、[effective shape properties](/slides/ja/nodejs-java/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、ビジュアル結果はレンダリングされ、編集可能な 3D 設定として保持されません。

## **よくある質問**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキスト向けの PowerPoint 3D 効果を作成・レンダリングします。エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはできません。PPTX では、形式がサポートする場合に 3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は通常の PowerPoint シェイプやテキストに適用される書式設定で、回転、押し出し、ベベル、ライティング、素材などがあります。本記事は 3D 効果について取り上げています。

**可視的な 3D シェイプに必要な設定はどれですか？**

最低限、カメラの回転と押し出しまたは奥行きを設定します。実際には、ライトリグと素材も設定して、レンダリングされた面に明確なハイライトと影が出るようにします。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` を、テキストには [TextFrameFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` を使用します。

**画像、PDF、HTML、またはビデオフレームにエクスポートしたときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF、HTML、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。[Shape Effective Properties](/slides/ja/nodejs-java/shape-effective-properties/) で説明されている有効な書式設定 API を使用して、最終的なカメラ、ライトリグ、ベベル、その他の 3D 値を取得できます。