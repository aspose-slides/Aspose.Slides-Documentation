---
title: Java を使用してプレゼンテーションに 3D 効果を作成する
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D プレゼンテーション
- 3D 回転
- 3D 深度
- 3D 押し出し
- 3D グラデーション
- 3D テキスト
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で PowerPoint のシェイプとテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、マテリアル、押し出し、塗りつぶし、3D テキストを構成します。"
---
## **概要**

Aspose.Slides for Java は、シェイプやテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、マテリアル、グラデーションまたは画像の塗りつぶし、そして 3D テキストといった 3D 効果を取り上げます。

{{% alert color="info" title="Note" %}}

This article is about 3D formatting effects on PowerPoint shapes and text. It is not about inserting or editing standalone 3D model files. When you export a slide to an image, PDF, or HTML, Aspose.Slides renders those 3D effects into the exported 2D output.

{{% /alert %}}

## **3D 書式設定の概念**

[ IShape.getThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getThreeDFormat--) メソッドを使用して、シェイプに 3D 書式設定を適用します。このメソッドは [IThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/) を返し、シェイプの 3D シーンを制御します。

テキストの場合は、[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) メソッドを使用します。これにより、シェイプ本体ではなくテキストフレームに 3D 書式設定が適用されます。

主な API メンバーは次のとおりです。

| API メンバー | 制御内容 | 使用するタイミング |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getCamera--) | 視点、プリセットカメラタイプ、回転、ズーム、遠近法。 | 3D 空間でオブジェクトを回転させるか、PowerPoint の 3D 回転プリセットと合わせるとき。 |
| [getLightRig](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getLightRig--) | ライトのプリセット、方向、回転。 | 3D 表面のハイライトや陰影の見え方を変更するとき。 |
| [getMaterial](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getMaterial--) と [setMaterial](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | フラット、マット、プラスチック、メタルなどの表面素材。 | 同じジオメトリをより平坦、柔らか、光沢、金属的に見せたいとき。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) と [setExtrusionHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | シェイプが正面からどれだけ後方に伸びるか。 | 平面シェイプを目に見える厚みのある 3D オブジェクトに変えるとき。 |
| [getExtrusionColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 押し出し側面の色。 | 奥行きを可視化したり、正面の塗りと側面の色を合わせたいとき。 |
| [getDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getDepth--) と [setDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint の 3D 書式設定で使用される追加の奥行き。 | ベベルやマテリアル設定と組み合わせて、シェイプやテキストの奥行きを微調整するとき。 |
| [getBevelTop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getBevelTop--) と [getBevelBottom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 正面と背面のエッジを上げたり丸めたりする。 | 鋭利な平坦面の代わりに、柔らかく成形されたエッジを追加するとき。 |
| [getContourColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getContourColor--) と [getContourWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getContourWidth--) と [setContourWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D オブジェクトの輪郭線。 | レンダリング結果でオブジェクトの境界を強調したいとき。 |

## **3D シェイプの作成**

シェイプが納得できる 3D に見えるためには、通常次の 4 種類の設定が必要です。

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れることがあります。
- ライト設定：照明により面や側面が見やすくなります。
- マテリアル設定：表面素材が光の当たり方に影響します。
- 押し出しまたは奥行き設定：平面シェイプに厚みを与えるために必要です。

以下の例は矩形を作成し、正面にテキストを追加し、3D 書式設定を適用します。カメラ回転値は度単位で、押し出し高さは 100 ポイントです。この例はスライドを PNG 画像としてデフォルトサイズの 2 倍でレンダリングし、プレゼンテーションを PPTX として保存します。

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
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

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

レンダリングされたスライド画像は、矩形が厚みのある 3D ブロックとして表示されます：

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **カメラでシェイプを回転させる**

PowerPoint では、3‑D 回転パネルから 3D 回転を設定します。X、Y、Z の回転値はカメラ API を通して設定する回転に対応します。

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides では、[IThreeDFormat.getCamera](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getCamera--) を介してカメラにアクセスします。この例は矩形を作成し、正面の正投影ビューを選択し、X、Y、Z の回転をそれぞれ 20、30、40 度に設定します。ファイルに保存せずメモリ内でシェイプを構成します：

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

カメラはビューアがオブジェクトを見る角度を変更したいときに使用します。スライド上の 2D シェイプジオメトリ自体は変わりません。PowerPoint と Aspose.Slides がレンダリング時に使用する 3D ビューポイントが変わります。

## **押し出しと奥行きの追加**

押し出しはシェイプの正面から後方へ伸ばすことで厚みを表現します。PowerPoint では深さコントロールがこの見える厚みを決定し、色コントロールが側面の色を決めます。

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

[IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) で厚みを設定し、[IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) で側面の色を取得します。この例は矩形に 100 ポイントの押し出しと紫色の側面を与え、カメラを回転させて厚みを確認します。ファイルに保存せずメモリ内で構成します：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setDepth-double-) メソッドは 3D シェイプの奥行きを設定します。[setExtrusionHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) メソッドは押し出し効果の高さを制御します（例を参照）。

## **3D 効果と併用できるグラデーションまたは画像塗りつぶしの使用**

3D 書式設定はシェイプの塗りつぶしから独立しています。正面に単色、グラデーション、パターン、または画像塗りつぶしを適用しながら、同じカメラ、ライト、マテリアル、押し出し設定を使用できます。

この例は正面に青からオレンジへのグラデーションを、150 ポイントの押し出しには濃いオレンジ色を適用します。グラデーションの開始と終了はそれぞれ 0 と 100 の位置で設定されています。カメラ回転値は度単位です。スライドはデフォルトサイズの 2 倍で PNG 画像としてレンダリングされます：

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

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

レンダリング結果は正面のグラデーションを保持し、押し出しは別個に描画されます：

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

画像塗りつぶしを使用する場合は、プレゼンテーションに画像を追加し、シェイプの塗りつぶしに割り当てます。この例は作業ディレクトリに "image.jpg" というファイルが存在することを前提とし、画像を矩形全体に伸ばし、150 ポイントの押し出しを適用し、カメラ回転を度単位で設定します。ファイルに保存またはレンダリングは行いません：

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

画像は正面に描画され、押し出しは 3D 側面として描画されます：

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、マテリアル、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例はオレンジと白の格子パターンでテキストを作成し、上向きのアーチを適用し、[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) を通して 3D 設定を構成します。押し出し高さと奥行きはポイント、ライト回転は度で指定します。シェイプの塗りつぶしとアウトラインは非表示にし、テキストのみが見えるようにします。例はデフォルトスライドサイズの 2 倍で PNG 画像をレンダリングし、プレゼンテーションを PPTX として保存します：

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

テキストは曲線状に押し出された 3D 文字としてレンダリングされます：

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **3D シェイプ上でテキストを平面的に保つ**

テキストを読みやすく保ちつつシェイプの 3D 表示を維持するには、[ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getTextFrameFormat--) を介して [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) を呼び出します。値が `true` の場合、テキストは 3D シーンから除外されます。`false` の場合、テキストはシーンに参加し、3D の向きに従います。

この設定はシェイプの 3D 書式設定（カメラ、照明、マテリアル、押し出し）を削除しません。また、通常の回転とは異なります。[IShape.setRotation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#setRotation-float-) はスライド平面上でシェイプを回転させ、[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) はテキストのバウンディングボックス内でのカスタム回転を制御します。テキストを 3D シーンから除外しても、これらの角度はリセットされません。

以下の自己完結型例は、テキスト付きの青い矩形を作成し、元の横にクローンを配置します。両方のシェイプは同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左側は `false`、右側は `true`。カメラ角度は度単位、押し出し高さは 40 ポイントです。例はプレゼンテーションを PPTX として保存し、比較スライドをデフォルトサイズの 2 倍の PNG としてレンダリングします。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

左側ではテキストが 3D 向きに従い、右側ではテキストが平面のままで読みやすくなります。両方の矩形は同じ見える押し出しと 3D 向きを保持しています。

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズまたは 2D 結果として出力に描画されます。これはスライドを [PNG](/slides/ja/java/convert-powerpoint-to-png/) にレンダリングする場合、[PDF](/slides/ja/java/convert-powerpoint-to-pdf/) にエクスポートする場合、[HTML](/slides/ja/java/convert-powerpoint-to-html/) にエクスポートする場合、または [ビデオ変換](/slides/ja/java/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

留意すべき点：

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、ライトリグ、マテリアル、押し出し、塗りつぶし、スライドの拡大縮小の組み合わせに依存します。
- 継承された値やテーマベースの書式設定値を確認したい場合は、[effective shape properties](/slides/ja/java/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的結果が 3D 設定として保持されるのではなく、レンダリングされた画像として出力されます。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプやテキストの PowerPoint 3D 効果を作成・レンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはできません。PPTX 形式では、対応する PowerPoint の機能がある限り、3D 書式設定は編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は通常の PowerPoint シェイプやテキストに適用される書式設定で、回転、押し出し、ベベル、照明、マテリアルなどを含みます。本記事は 3D 効果について説明しています。

**目に見える 3D シェイプを作るために必要な設定は何ですか？**

最低限、カメラの回転と押し出しまたは奥行きを設定します。実務では、ハイライトと影を明確にするためにライトリグとマテリアルも設定することが推奨されます。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [IShape.getThreeDFormat]、テキストには [ITextFrameFormat.getThreeDFormat] を使用して 3D 効果を適用します。

**画像、PDF、HTML、ビデオフレームへのエクスポート時に 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF、HTML、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。最終的なカメラ、ライトリグ、ベベル、その他の 3D 値を取得するには、[Shape Effective Properties](/slides/ja/java/shape-effective-properties/) に記載された効果的な書式設定 API を使用してください。