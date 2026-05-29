---
title: Android でプレゼンテーションの 3D 効果を作成する
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Android 上の PowerPoint 図形とテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、マテリアル、押し出し、塗りつぶし、そして 3D テキストを設定します。"
---
## **概要**

Aspose.Slides for Android via Java は、図形やテキストに対して PowerPoint スタイルの 3D 書式設定を作成、編集、保持、レンダリングできます。本稿では、回転、押し出し、ベベル、照明、マテリアル、グラデーションまたは画像塗りつぶし、3D テキストなどの 3D 効果について説明します。

{{% alert color="primary" %}}
この記事は、PowerPoint の図形とテキストに対する 3D 書式設定効果についてです。単独の 3D モデルファイルの挿入や編集については取り扱いません。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

図形に 3D 書式設定を適用するには、[IShape.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) メソッドを使用します。このメソッドは [IThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/) を返し、その図形の 3D シーンを制御します。

テキストの場合は、[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) メソッドを使用します。これにより、図形本体ではなくテキストフレームに 3D 書式設定が適用されます。

最も重要な API メンバーは次のとおりです：

| API メンバー | 制御対象 | 使用タイミング |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 視点、プリセットカメラタイプ、回転、ズーム、遠近感。 | 3D 空間でオブジェクトを回転させるか、PowerPoint の 3D 回転プリセットと一致させるとき。 |
| [getLightRig](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | ライトのプリセット、方向、回転。 | 3D 表面のハイライトと影の表示方法を変更するとき。 |
| [getMaterial](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) と [setMaterial](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | フラット、マット、プラスチック、金属などの表面素材。 | 同じ形状をより平坦、柔らか、光沢、金属的に見せるとき。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) と [setExtrusionHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 形状が前面からどれだけ後方に伸びるか。 | 平面の形状を目に見える厚みのある 3D オブジェクトに変えるとき。 |
| [getExtrusionColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 押し出された側面の色。 | 奥行きを可視化したり、側面の色を前面の塗りつぶしと合わせるとき。 |
| [getDepth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getDepth--) と [setDepth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint の 3D 書式設定で使用される追加の奥行き。 | ベベルやマテリアル設定と組み合わせて、図形やテキストの奥行きを微調整するとき。 |
| [getBevelTop](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) と [getBevelBottom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 前面と背面のエッジが上がったり丸められた形状。 | 尖った平坦な面ではなく、柔らかいまたは成形されたエッジを追加するとき。 |
| [getContourColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getContourColor--)、[getContourWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--)、[setContourWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D オブジェクトの輪郭。 | レンダリング出力でオブジェクトの境界を強調するとき。 |

## **3D 図形の作成**

図形が説得力のある 3D に見えるように、通常は 4 種類の設定が必要です：

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れる可能性があるため。  
- ライト設定：照明により面と側面が読み取れるようになるため。  
- マテリアル設定：表面が光の描写に影響するため。  
- 押し出しまたは奥行き設定：平面の形状に厚みが必要なため。

次の例は、長方形を作成し、前面にテキストを追加し、3D 書式設定を適用し、プレゼンテーションを PPTX として保存し、スライドを PNG 画像にレンダリングします。

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

レンダリングされたスライド画像は、長方形が厚みのある 3D ブロックとして表示されます：

![前面に白い 3D テキストがある青い 3D 長方形のレンダリング画像](img_01_01.png)

## **カメラで図形を回転する**

PowerPoint では、3D 回転は「3-D 回転」ペインで設定します。X、Y、Z の回転値は、カメラ API を通じて設定する回転に対応しています。

![X、Y、Z 回転値が強調表示された PowerPoint の 3-D 回転ペイン](img_02_01.png)

Aspose.Slides では、[IThreeDFormat.getCamera](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getCamera--) を使用してカメラの種類と回転を設定します：

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

ビューアがオブジェクトを見る視点を変更する必要がある場合にカメラを使用します。これによりスライド上の 2D 図形のジオメトリは変更されません。PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点が変更されます。

## **押し出しと奥行きの追加**

押し出しは、形状を前面の背後に拡張することで厚みを持たせます。PowerPoint では、奥行きコントロールがこの可視的な厚さを設定し、カラーコントロールが側面の色を設定します。

![押し出しカラーと押し出し高さプロパティに対応する PowerPoint の奥行きコントロール](img_02_02.png)

厚さには [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) を、側面の色には [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) を使用します：

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

PowerPoint の奥行き値を直接操作する必要がある場合や、奥行きをベベル、マテリアル、テキスト効果と組み合わせる場合は、[IThreeDFormat.setDepth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) を使用します。多くの図形シナリオでは、可視的な押し出しを直接示すため、`setExtrusionHeight` の方が分かりやすい設定です。

## **3D 効果と一緒にグラデーションまたは画像塗りつぶしを使用する**

3D 書式設定は図形の塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、または画像塗りつぶしを適用しながら、同じカメラ、ライト、マテリアル、押し出し設定を使用できます。

この例は、図形にグラデーション塗りつぶしを適用し、側面に暗めの押し出し色を設定します：

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

レンダリングされた出力は、前面のグラデーションを保持し、押し出しを別々にレンダリングします：

![青からオレンジへのグラデーション塗りつぶしとオレンジの押し出しを持つ 3D 長方形のレンダリング画像](img_02_03.png)

代わりに画像塗りつぶしを使用するには、画像をプレゼンテーションに追加し、図形の塗りつぶしに割り当てます：

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

前面に写真塗りつぶし、側面にオレンジの押し出しを持つ 3D 長方形のレンダリング画像：

![前面に写真塗りつぶし、側面にオレンジの押し出しを持つ 3D 長方形のレンダリング画像](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

図形の 3D 書式設定は図形本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、マテリアル、照明、カメラ設定が必要な WordArt のような効果に便利です。

次の例は、パターン塗りつぶしのテキストを作成し、WordArt 変換を適用し、[ITextFrameFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/) に 3D 設定を構成します：

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![アーチ状の WordArt 変換、オレンジのパターン塗りつぶし、暗い押し出しを持つ 3D テキストのレンダリング画像](img_02_05.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズされ、2D 結果として出力に描画されます。これは、スライドを [PNG](/slides/ja/androidjava/convert-powerpoint-to-png/) にレンダリングする、[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/) にエクスポートする、[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/) にエクスポートする、または [動画変換](/slides/ja/androidjava/convert-powerpoint-to-video/) 用のフレームを生成するときにも適用されます。

以下の点に留意してください：

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。  
- 最終的な外観は、カメラ、ライトリグ、マテリアル、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。  
- 継承された、またはテーマベースの書式設定値を確認する必要がある場合は、[形状の有効プロパティ](/slides/ja/androidjava/shape-effective-properties/) を参照してください。  
- 一部の出力形式は、編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的な結果がレンダリングされ、編集可能な 3D 設定として保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides は図形とテキストに対する PowerPoint の 3D 効果を作成およびレンダリングします。エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはありません。PPTX では、形式がサポートしている限り、3D 書式設定は PowerPoint で編集可能なままです。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は、回転、押し出し、ベベル、照明、マテリアルなど、通常の PowerPoint 図形やテキストに適用される書式設定です。本稿は 3D 効果について説明しています。

**見える 3D 図形に必要な設定はどれですか？**

最低でもカメラの回転と押し出しまたは奥行きを設定します。実際には、レンダリングされた面に明確なハイライトと影を持たせるために、ライトリグとマテリアルも設定します。

**図形とテキストの両方に 3D 効果を適用できますか？**

はい。図形本体には [IShape.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) を、テキストには [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) を使用します。

**画像、PDF、HTML、またはビデオフレームにエクスポートするときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換に使用されるフレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力はレンダリングされた外観を含み、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。[形状の有効プロパティ](/slides/ja/androidjava/shape-effective-properties/) で説明されている有効書式設定 API を使用して、最終的なカメラ、ライトリグ、ベベル、および関連する 3D 値を取得できます。