---
title: Android でプレゼンテーションに 3D 効果を作成する
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
description: "Aspose.Slides を使用して Android 上の PowerPoint の図形とテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、素材、押し出し、塗りつぶし、そして 3D テキストを構成します。"
---
## **概要**

Aspose.Slides for Android via Java は、図形やテキストに対して PowerPoint スタイルの 3D 書式設定を作成、編集、保持、レンダリングできます。この記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像塗りつぶし、そして 3D テキストなどの 3D 効果について説明します。

{{% alert color="info" title="Note" %}}
この記事は PowerPoint の図形とテキストに対する 3D 書式設定効果についてです。単体の 3D モデル ファイルの挿入や編集については扱いません。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

図形に 3D 書式設定を適用するには、[IShape.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) メソッドを使用します。このメソッドは、その図形の 3D シーンを制御する [IThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/) を返します。

テキストの場合は、[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) メソッドを使用します。これにより、図形本体ではなくテキスト フレームに 3D 書式設定が適用されます。

最も重要な API メンバーは次のとおりです。

| API メンバー | 制御対象 | 使用するタイミング |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 視点、プリセット カメラタイプ、回転、ズーム、遠近感。 | オブジェクトを 3D 空間で回転させるか、PowerPoint の 3D 回転プリセットに合わせます。 |
| [getLightRig](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | 光のプリセット、方向、および光の回転。 | 3D 表面のハイライトと影の表示方法を変更します。 |
| [getMaterial](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) と [setMaterial](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | 平坦、マット、プラスチック、金属などの表面素材。 | 同じ形状をより平らに、柔らかく、光沢のある、または金属のように見せます。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) と [setExtrusionHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 形状が正面からどれだけ後方に伸びるか。 | 平坦な形状を目に見える厚みのある 3D オブジェクトに変えます。 |
| [getExtrusionColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 押し出された側面の色。 | 奥行きを可視化するか、側面の色を正面の塗りつぶしと合わせます。 |
| [getDepth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getDepth--) と [setDepth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint の 3D 書式設定で使用される追加の 3D 奥行き。 | 形状やテキストの奥行きを微調整します。特にベベルや素材設定と組み合わせる場合に有効です。 |
| [getBevelTop](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) と [getBevelBottom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 正面と背面のエッジを突出または丸めたもの。 | 鋭利な平面の代わりに、柔らかいまたは成形されたエッジを追加します。 |
| [getContourColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) と [getContourWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) と [setContourWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D オブジェクトの輪郭。 | レンダリングされた出力でオブジェクトの境界を強調します。 |

## **3D 図形の作成**

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れる可能性があるため。
- 光設定：照明により面と側面が見やすくなるため。
- 素材設定：表面が光の描画に影響するため。
- 押し出しまたは奥行き設定：平坦な形状に厚みが必要なため。

以下の例は長方形を作成し、正面にテキストを追加し、3D 書式設定を適用します。カメラ回転値は度単位で、押し出し高さは 100 ポイントです。この例はスライドを PNG 画像に 2 倍のサイズでレンダリングし、プレゼンテーションを PPTX として保存します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

レンダリングされたスライド画像は、長方形が厚い 3D ブロックとして表示されます：

![正面に白い 3D テキストがある、青い 3D 長方形のレンダリング画像](img_01_01.png)

## **カメラで図形を回転する**

PowerPoint では、3-D Rotation ペインから 3D 回転を設定します。X、Y、Z の回転値はカメラ API で設定する回転に対応します。

![PowerPoint 3-D Rotation ペインで X、Y、Z の回転値がハイライトされている画像](img_02_01.png)

Aspose.Slides では、[IThreeDFormat.getCamera](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getCamera--) を介してカメラにアクセスします。この例は長方形を作成し、正投影の正面ビューを選択し、X、Y、Z の回転をそれぞれ 20、30、40 度に設定します。ファイルを保存せずにメモリ上で図形を構成します：

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

ビューアがオブジェクトを見る視点を変更したいときにカメラを使用します。スライド上の 2D 図形ジオメトリは変更されず、PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点が変更されます。

## **押し出しと奥行きを追加する**

押し出しは、形状を正面から後方に伸ばすことで厚みを持たせます。PowerPoint では、奥行きコントロールがこの可視的な厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の奥行きコントロールが押し出し色と押し出し高さプロパティに対応している画像](img_02_02.png)

厚さを設定するには [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) を使用し、側面の色を取得するには [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) を使用します。この例は長方形に 100 ポイントの押し出しと紫色の側面を設定し、カメラを回転させて厚みを見せます。ファイルを保存せずにメモリ上で図形を構成します：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) メソッドは 3D 図形の奥行きを設定します。[setExtrusionHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) メソッドは押し出し効果の高さを制御します。この例でも示されています。

## **3D 効果とともにグラデーションまたは画像塗りつぶしを使用する**

3D 書式設定は図形の塗りつぶしとは独立しています。正面に単色、グラデーション、パターン、または画像塗りつぶしを適用しつつ、同じカメラ、光、素材、押し出し設定を使用できます。

この例は正面に青からオレンジへのグラデーションを、150 ポイントの押し出しには濃いオレンジ色を適用します。グラデーションの停止位置は 0 と 100 が開始と終了を示します。カメラ回転値は度単位です。スライドは PNG 画像に 2 倍のサイズでレンダリングされます：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int extrusionColor = Color.rgb(255, 140, 0);
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

レンダリングされた出力は正面のグラデーションを保持し、押し出しは別に描画されます：

![青からオレンジへのグラデーション塗りつぶしとオレンジの押し出しを持つ 3D 長方形のレンダリング画像](img_02_03.png)

画像塗りつぶしを使用する場合は、プレゼンテーションに画像を追加し、図形の塗りつぶしに割り当てます。この例では作業ディレクトリに "image.jpg" というファイルが存在することが前提です。画像を長方形全体に伸ばし、150 ポイントの押し出しを適用し、カメラ回転を度単位で設定します。ファイルを保存またはレンダリングせずにメモリ上で構成します：

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
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

![正面に写真塗りつぶし、オレンジの押し出しを持つ 3D 長方形のレンダリング画像](img_02_04.png)

## **テキストに 3D 書式設定を適用する**

図形の 3D 書式設定は図形本体に影響し、テキストの 3D 書式設定はテキスト フレームに影響します。文字そのものに押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例はオレンジと白の格子パターンのテキストを作成し、上向きのアーチを適用し、[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) を通じて 3D 設定を構成します。押し出し高さと奥行きはポイント、光の回転は度単位です。図形の塗りと輪郭は非表示にし、テキストだけが見えるようにします。例は PNG 画像をデフォルトスライドサイズの 2 倍でレンダリングし、プレゼンテーションを PPTX として保存します：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

![アーチ状の WordArt 変形、オレンジのパターン塗りつぶし、暗い押し出しを持つ 3D テキストのレンダリング画像](img_02_05.png)

## **3D 図形上でテキストを平坦に保つ**

テキストを読みやすく保ちつつ図形の 3D 外観を維持するには、[ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) を介して [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) を呼び出します。値が `true` の場合、テキストは 3D シーンから除外されます。`false` の場合、テキストはシーンに参加し 3D 向きに従います。

この設定は図形の 3D 書式設定（カメラ、照明、素材、押し出し）を削除しません。また、通常の回転とは異なります。[IShape.setRotation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#setRotation-float-) はスライド平面で図形を回転させ、[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) はテキストのバウンディング ボックス内でのカスタム回転を制御します。テキストを 3D シーンから除外してもこれらの角度はリセットされません。

以下の自己完結型例は、テキスト付きの青い長方形を作成し、元の横にクローンします。両方の図形は同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左側は `false`、右側は `true`。カメラ角度は度単位、押し出し高さは 40 ポイントです。例はプレゼンテーションを PPTX として保存し、比較スライドをデフォルトサイズの 2 倍で PNG にレンダリングします。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
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

左側はテキストが 3D 向きに従い、右側は平坦で読みやすくなっています。両方の長方形は同じ可視押し出しと 3D 向きを保持しています。

![左側が 3D 向きに従い、右側が平坦に保たれた 3D 長方形の比較画像](keep_text_flat.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスター化または 2D 結果として出力に描画されます。これはスライドを [PNG](/slides/ja/androidjava/convert-powerpoint-to-png/) にレンダリングする場合、[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/) にエクスポートする場合、[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/) にエクスポートする場合、または [video conversion](/slides/ja/androidjava/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

以下の点に留意してください：

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、光源、素材、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承されたまたはテーマベースの書式設定値を確認する必要がある場合は、[有効な図形プロパティ](/slides/ja/androidjava/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚結果がレンダリングされ、編集可能な 3D 設定としては保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides は図形とテキストの PowerPoint 3D 効果を作成およびレンダリングします。エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはできません。PPTX では、フォーマットがサポートしている場合に 3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は、回転、押し出し、ベベル、照明、素材など、通常の PowerPoint 図形やテキストに適用される書式設定です。本記事は 3D 効果について取り上げています。

**目に見える 3D 図形に必要な設定は何ですか？**

最低限、カメラの回転と押し出しまたは奥行きを設定します。実際には、光源と素材も設定して、レンダリングされた面に明確なハイライトと影が出るようにします。

**図形とテキストの両方に 3D 効果を適用できますか？**

はい。図形本体には [IShape.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) を、テキストには [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) を使用します。

**画像、PDF、HTML、またはビデオフレームにエクスポートするときに 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを生成するときに 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承とテーマ設定が適用された後の最終的な 3D 値を読み取れますか？**

はい。[有効な図形プロパティ](/slides/ja/androidjava/shape-effective-properties/) に記載された実効書式設定 API を使用して、最終的なカメラ、光源、ベベル、関連する 3D 値を取得できます。