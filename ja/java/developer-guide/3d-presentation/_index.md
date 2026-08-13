---
title: Java を使用したプレゼンテーションで 3D エフェクトを作成する
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
description: "Aspose.Slides を使用して、Java で PowerPoint のシェイプとテキストに 3D エフェクトを適用およびレンダリングします。カメラ、ライティング、マテリアル、押し出し、塗り、および 3D テキストを設定します。"
---
## **概要**

Aspose.Slides for Java は、シェイプやテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、ライティング、マテリアル、グラデーションまたは画像塗り、そして 3D テキストといった 3D 効果を扱います。

{{% alert color="info" %}}
本記事は PowerPoint のシェイプとテキストに対する 3D 書式設定効果について説明します。単体の 3D モデル ファイルの挿入や編集については対象外です。スライドを画像、PDF、HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果を 2D の出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/).`getThreeDFormat()` を使用します。返される書式オブジェクトがそのシェイプの 3D シーンを制御します。

テキストの場合は、[ITextFrameFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` を使用します。これによりシェイプ本体ではなくテキスト フレームに 3D 書式が適用されます。

主な API メンバーは次のとおりです。

| API メンバー | 制御内容 | 使用タイミング |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getCamera--) | 視点、プリセットカメラタイプ、回転、ズーム、遠近感。 | 3D 空間でオブジェクトを回転させる、または PowerPoint の 3D 回転プリセットに合わせる。 |
| [getLightRig](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getLightRig--) | ライトのプリセット、方向、回転。 | 3D 表面上のハイライトや影の見え方を変更する。 |
| [getMaterial](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getMaterial--) と [setMaterial](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | フラット、マット、プラスチック、金属などの表面素材。 | 同じジオメトリをより平坦、柔らか、光沢、金属的に見せる。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) と [setExtrusionHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 前面からどれだけ奥へ伸びるか。 | 平面シェイプを目に見える厚みのある 3D オブジェクトに変える。 |
| [getExtrusionColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 押し出し側面の色。 | 奥行きを強調する、または前面の塗りと側面色を合わせる。 |
| [getDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getDepth--) と [setDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint の 3D 書式が使用する追加の奥行き。 | シェイプやテキストの奥行きを微調整する。ベベルやマテリアル設定と組み合わせることが多い。 |
| [getBevelTop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getBevelTop--) と [getBevelBottom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 前面と背面のエッジの丸みや立ち上がり。 | 鋭利な平面の代わりに、柔らかく成形されたエッジを追加する。 |
| [getContourColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getContourWidth--), と [setContourWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D オブジェクトの輪郭線。 | レンダリング結果でオブジェクトの境界を強調する。 |

## **3D シェイプの作成**

シェイプを納得のいく 3D に見せるには、通常次の 4 種類の設定が必要です。

- カメラ設定：デフォルトの正面ビューでは押し出しが見えにくいため。  
- ライト設定：ライティングにより面と側面が判別しやすくなるため。  
- マテリアル設定：表面素材が光の当たり方に影響するため。  
- 押し出しまたは奥行き設定：平面シェイプに厚みを付けるため。

以下の例は長方形を作成し、前面にテキストを追加し、3D 書式を適用して PPTX として保存し、スライドを PNG 画像としてレンダリングします。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

レンダリングされたスライド画像は、長方形が厚みのある 3D ブロックとして表示されます。

![前面に白い 3D テキストがあるレンダリング済み青い 3D 長方形](img_01_01.png)

## **カメラでシェイプを回転する**

PowerPoint では、3-D 回転ペインから 3D 回転を設定します。X、Y、Z の回転値はカメラ API を通して設定する回転に対応します。

![X、Y、Z の回転値がハイライトされた PowerPoint の 3-D 回転ペイン](img_02_01.png)

Aspose.Slides では、`shape.getThreeDFormat()` が返す 3D 書式を介してカメラタイプと回転を設定します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

ビューアがオブジェクトを見る視点を変更したいときにカメラを使用します。スライド上の 2D シェイプジオメトリは変わらず、PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点が変わります。

## **押し出しと奥行きを追加する**

押し出しは前面から背面へシェイプを伸ばすことで厚みを付けます。PowerPoint では、奥行きコントロールがこの可視厚みを決定し、色コントロールが側面の色を決めます。

![押し出し色と押し出し高さプロパティにマッピングされた PowerPoint の奥行きコントロール](img_02_02.png)

厚みには押し出し高さを、側面の色には押し出し色を設定します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

PowerPoint の奥行き値を直接操作したい、または奥行きをベベル、マテリアル、テキスト効果と組み合わせたい場合に奥行き設定を使用します。多くのシェイプシナリオでは、押し出し高さの方が可視的な押し出しを直接表すため分かりやすいです。

## **3D 効果とともにグラデーションまたは画像塗りを使用する**

3D 書式設定はシェイプの塗りとは独立しています。前面に単色、グラデーション、パターン、または画像塗りを適用しつつ、同じカメラ、ライト、マテリアル、押し出し設定を使用できます。

以下の例はシェイプにグラデーション塗りを適用し、側面に暗めの押し出し色を設定します。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

レンダリング結果は前面のグラデーションを保持し、押し出しは別個に描画されます。

![青からオレンジへのグラデーション塗りとオレンジの押し出しを持つ 3D 長方形のレンダリング結果](img_02_03.png)

画像塗りを使用する場合は、プレゼンテーションに画像を追加し、シェイプの塗りに割り当てます。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

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
} finally {
    presentation.dispose();
}
```

画像は前面に描画され、押し出しは 3D 側面としてレンダリングされます。

![前面に写真塗り、側面にオレンジの押し出しを持つ 3D 長方形のレンダリング結果](img_02_04.png)

## **テキストに 3D 書式を適用する**

シェイプの 3D 書式はシェイプ本体に影響し、テキストの 3D 書式はテキスト フレームに影響します。文字自体に押し出し、マテリアル、ライティング、カメラ設定が必要な WordArt のような効果に便利です。

以下の例はパターン塗りのテキストを作成し、WordArt 変形を適用し、[ITextFrameFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` で 3D 設定を構成します。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![アーチ状の WordArt 変形とオレンジのパターン塗り、暗い押し出しを持つ 3D テキストのレンダリング結果](img_02_05.png)

## **エクスポートとレンダリングの挙動**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へのレンダリングまたはエクスポート時には、3D シーンがラスター化または 2D 結果として描画されます。これはスライドを [PNG](/slides/ja/java/convert-powerpoint-to-png/) にレンダリングする場合、[PDF](/slides/ja/java/convert-powerpoint-to-pdf/) にエクスポートする場合、[HTML](/slides/ja/java/convert-powerpoint-to-html/) にエクスポートする場合、または [動画変換](/slides/ja/java/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

覚えておくべきポイント：

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。  
- 最終的な外観はカメラ、ライト リグ、マテリアル、押し出し、塗り、スライドの拡大縮小の組み合わせに依存します。  
- 継承された属性やテーマベースの書式値を確認したい場合は、[効果的なシェイプ プロパティ](/slides/ja/java/shape-effective-properties/) を参照してください。  
- 一部の出力形式は編集可能な PowerPoint 3D 書式を保存できません。そのような形式では、視覚結果が 3D 設定としてではなくレンダリングされた画像として保存されます。

## **FAQ**

### Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成・レンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブ 3D シーンにすることはできません。PPTX 形式では、対応する場合に 3D 書式が PowerPoint で編集可能なまま残ります。

### 3D モデルと 3D 効果の違いは何ですか？

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は通常の PowerPoint シェイプやテキストに対して適用される書式で、回転、押し出し、ベベル、ライティング、マテリアルなどを含みます。本記事は 3D 効果について解説しています。

### 視覚的に 3D なシェイプに必要な設定は何ですか？

最低でもカメラの回転と押し出しまたは奥行きを設定します。実務では、ハイライトと影をはっきりさせるためにライト リグとマテリアルも設定することが一般的です。

### シェイプとテキストの両方に 3D 効果を適用できますか？

はい。シェイプ本体には [IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/).`getThreeDFormat()`、テキストには [ITextFrameFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` を使用します。

### 画像、PDF、HTML、動画フレームにエクスポートするときに 3D 効果は表示されますか？

はい。Aspose.Slides はスライド画像、PDF、HTML、動画変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリング結果が含まれ、編集可能な 3D オブジェクトは含まれません。

### 継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？

はい。最終的なカメラ、ライト リグ、ベベル、その他 3D 値を取得するには、[シェイプ 効果的なプロパティ](/slides/ja/java/shape-effective-properties/) で説明されている効果的な書式 API を使用してください。