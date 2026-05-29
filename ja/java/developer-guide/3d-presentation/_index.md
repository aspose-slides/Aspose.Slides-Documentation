---
title: Java を使用したプレゼンテーションで 3D 効果を作成する
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で PowerPoint の図形とテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、マテリアル、押し出し、塗り、および 3D テキストを構成します。"
---
## **概要**

Aspose.Slides for Java は、図形やテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、マテリアル、グラデーションまたは画像塗り、3D テキストなどの 3D 効果について説明します。

{{% alert color="primary" %}}
本記事は PowerPoint の図形とテキストに対する 3D 書式設定効果についてです。単独の 3D モデル ファイルの挿入や編集については扱いません。スライドを画像、PDF、HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

[IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/).`getThreeDFormat()` を使用して、図形に 3D 書式設定を適用します。返される書式オブジェクトは、その図形の 3D シーンを制御します。

テキストの場合は、[ITextFrameFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` を使用します。これは図形本体ではなくテキスト フレームに 3D 書式設定を適用します。

主な API メンバーは次のとおりです。

| API メンバー | 制御対象 | 使用シーン |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getCamera--) | 視点、プリセット カメラ タイプ、回転、ズーム、遠近感 | 3D 空間でオブジェクトを回転させる、または PowerPoint の 3D 回転プリセットに合わせる |
| [getLightRig](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getLightRig--) | ライト プリセット、方向、ライト回転 | 3D 表面上のハイライトと影の見え方を変更する |
| [getMaterial](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getMaterial--) と [setMaterial](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | フラット、マット、プラスチック、メタルなどの表面材質 | 同じ形状をフラット、柔らかい、光沢あり、金属的に見せる |
| [getExtrusionHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) と [setExtrusionHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 前面から後方へどれだけ伸ばすか | 平面の図形を目に見える厚みのある 3D オブジェクトに変える |
| [getExtrusionColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 押し出し側面の色 | 奥行きを見せる、または前面の塗りと側面の色を揃える |
| [getDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getDepth--) と [setDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 書式設定で使用される追加の奥行き | 図形やテキストの奥行きを微調整する（ベベルやマテリアル設定と組み合わせることが多い） |
| [getBevelTop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getBevelTop--) と [getBevelBottom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 前面と背面のエッジの隆起または丸み | 鋭い平面の代わりに、柔らかく成形されたエッジを追加する |
| [getContourColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getContourWidth--), と [setContourWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D オブジェクトの輪郭線 | レンダリング結果でオブジェクトの境界を強調する |

## **3D シェイプの作成**

シェイプが説得力のある 3D に見えるようにするには、通常次の 4 種類の設定が必要です。

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れることがあるため  
- ライト設定：照明により面と側面が見えやすくなるため  
- マテリアル設定：表面が光の当たり方に影響するため  
- 押し出しまたは奥行き設定：平面のシェイプに厚みを与えるため  

次の例は矩形を作成し、前面にテキストを追加し、3D 書式設定を適用してプレゼンテーションを PPTX として保存し、スライドを PNG 画像としてレンダリングします。

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

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

レンダリングされたスライド画像は、矩形が厚みのある 3D ブロックとして表示されます。

![レンダリングされた青い 3D 矩形（前面に白い 3D テキスト）](img_01_01.png)

## **カメラでシェイプを回転させる**

PowerPoint では、3-D 回転ペインで回転が設定されます。X、Y、Z の回転値はカメラ API で設定する回転に対応します。

![PowerPoint の 3-D 回転ペイン（X、Y、Z の回転値がハイライト）](img_02_01.png)

Aspose.Slides では、`shape.getThreeDFormat()` が返す 3D 書式オブジェクトを通じてカメラ タイプと回転を設定します。

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

カメラは、ビューアがオブジェクトを見る角度を変更したいときに使用します。スライド上の 2D 図形ジオメトリは変更せず、PowerPoint および Aspose.Slides がレンダリング時に使用する 3D 視点を変更します。

## **押し出しと奥行きを追加する**

押し出しは、前面から後方へシェイプを伸ばすことで厚みを与えます。PowerPoint では、深さコントロールがこの可視厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の奥行きコントロールが押し出しの色と高さプロパティに対応](img_02_02.png)

厚さには「押し出し高さ」を、側面の色には「押し出し色」を設定します。

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

深さ設定は、PowerPoint の深さ値を直接操作したいときや、ベベル、マテリアル、テキスト効果と組み合わせるときに使用します。多くのシェイプシナリオでは、押し出し高さの方が可視的な押し出しを直接表現できるため分かりやすいです。

## **3D 効果と共にグラデーションまたは画像塗りを使用する**

3D 書式設定はシェイプの塗りとは独立しています。前面に単色、グラデーション、パターン、画像塗りを適用しながら、同じカメラ、ライト、マテリアル、押し出し設定を使用できます。

この例はシェイプにグラデーション塗りを適用し、側面に暗い押し出し色を設定します。

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

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

レンダリング結果は前面のグラデーションを保持し、押し出しは別に描画されます。

![青からオレンジへのグラデーション塗りとオレンジの押し出しを持つ 3D 矩形のレンダリング結果](img_02_03.png)

画像塗りを使用する場合は、画像をプレゼンテーションに追加し、シェイプの塗りに割り当てます。

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

画像は前面にレンダリングされ、押し出しは 3D 側面として描画されます。

![前面に写真塗り、側面にオレンジの押し出しを持つ 3D 矩形のレンダリング結果](img_02_04.png)

## **テキストに 3D 書式設定を適用する**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキスト フレームに影響します。これは、文字自体に押し出し、マテリアル、照明、カメラ設定が必要な WordArt のような効果に便利です。

次の例はパターン塗りのテキストを作成し、WordArt 変換を適用し、[ITextFrameFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/) に 3D 設定を構成します。

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
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
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

テキストは曲線状に押し出された 3D 文字としてレンダリングされます。

![アーチ状の WordArt 変換、オレンジのパターン塗り、暗い押し出しを持つ 3D テキストのレンダリング結果](img_02_05.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint フォーマットに保存する際に 3D 書式設定を保持します。固定レイアウト形式にレンダリングまたはエクスポートする場合、3D シーンはラスタライズされ、2D 結果として出力に描画されます。これはスライドを [PNG](/slides/ja/java/convert-powerpoint-to-png/)、[PDF](/slides/ja/java/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/java/convert-powerpoint-to-html/) にレンダリングする、または [ビデオ変換](/slides/ja/java/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

留意点は以下の通りです。

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。  
- 最終的な外観はカメラ、光源リグ、マテリアル、押し出し、塗り、スライドのスケーリングの組み合わせに依存します。  
- 継承されたまたはテーマベースの書式設定値を確認したい場合は、[効果的なシェイプ プロパティ](/slides/ja/java/shape-effective-properties/) を参照してください。  
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保存できません。その場合、視覚的な結果はレンダリングされ、編集可能な 3D 設定としては保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはできません。PPTX では、フォーマットがサポートしている限り 3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は、回転、押し出し、ベベル、照明、マテリアルなど、通常の PowerPoint 図形やテキストに適用される書式設定です。本記事は 3D 効果について扱います。

**視覚的に見える 3D シェイプに必要な設定はどれですか？**

最低でもカメラの回転と、押し出しまたは奥行きのいずれかを設定する必要があります。実務では、光源リグとマテリアルも設定して、レンダリングされた面に明確なハイライトと影を付けることが推奨されます。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/).`getThreeDFormat()` を、テキストには [ITextFrameFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` を使用します。

**画像、PDF、HTML、またはビデオフレームにエクスポートしたときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれますが、編集可能な 3D オブジェクトは含まれません。

**継承およびテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。最終的なカメラ、光源リグ、ベベル、関連する 3D 値を取得するには、[シェイプ 効果的プロパティ](/slides/ja/java/shape-effective-properties/) で説明されている効果的な書式設定 API を使用してください。