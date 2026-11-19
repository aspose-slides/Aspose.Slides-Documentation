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
description: "Aspose.Slides を使用して Java で PowerPoint のシェイプとテキストに 3D エフェクトを適用およびレンダーします。カメラ、照明、素材、押し出し、塗りつぶし、そして 3D テキストを構成します。"
---
## **概要**

Aspose.Slides for Java は、シェイプとテキストの PowerPoint スタイルの 3D 書式設定を作成、編集、保持、レンダーできます。この記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像の塗りつぶし、3D テキストなどの 3D 効果を取り上げます。

{{% alert color="info" title="Note" %}}
このページは、PowerPoint のシェイプとテキストに対する 3D 書式設定効果について説明します。単独の 3D モデルファイルの挿入や編集については扱いません。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) メソッドを使用します。このメソッドは[IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/) を返し、対象シェイプの 3D シーンを制御します。

テキストの場合は、[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) メソッドを使用します。これにより、シェイプ本体ではなくテキストフレームに 3D 書式設定が適用されます。

最も重要な API メンバーは次のとおりです：

| API メンバー | 制御対象 | 使用タイミング |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | 視点、プリセット カメラ タイプ、回転、ズーム、パースペクティブ。 | 3D 空間でオブジェクトを回転させる、または PowerPoint の 3D 回転プリセットに合わせる。 |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | 光のプリセット、方向、光の回転。 | 3D 表面上のハイライトや影の表示方法を変更する。 |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) と [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | 平坦、マット、プラスチック、金属などの表面素材。 | 同じジオメトリをより平坦、柔らかく、光沢のある、または金属的に見せる。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) と [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | シェイプが前面からどれだけ後方に伸びるか。 | 平坦なシェイプを目に見える厚みのある 3D オブジェクトに変える。 |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 押し出し側面の色。 | 奥行きを見せたり、側面の色を前面の塗りつぶしと合わせたりする。 |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) と [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint の 3D 書式設定で使用される追加の 3D 奥行き。 | ベベルや素材設定と組み合わせて、シェイプやテキストの奥行きを微調整する。 |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) と [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 前面と背面のエッジが隆起または丸みを帯びている。 | 鋭い平坦な面ではなく、柔らかく成形されたエッジを追加する。 |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) と [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) と [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D オブジェクトの輪郭。 | レンダリング結果でオブジェクトの境界を強調する。 |

## **3D シェイプの作成**

シェイプが納得のいく 3D に見えるまでに、通常は 4 種類の設定が必要です：

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れる可能性があるため。
- 光設定：照明により面と側面が見やすくなるため。
- 素材設定：表面が光の描写に影響するため。
- 押し出しまたは奥行き設定：平坦なシェイプに厚みを持たせるため。

次の例は矩形を作成し、前面にテキストを追加し、3D 書式設定を適用します。カメラ回転値は度単位で、押し出し高さは 100 ポイントです。この例はスライドをデフォルトサイズの 2 倍の PNG 画像にレンダリングし、プレゼンテーションを PPTX として保存します。

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

レンダリングされたスライド画像は、矩形が太い 3D ブロックとして表示されます：

![前面に白い 3D テキストがある青い 3D 矩形のレンダリング画像](img_01_01.png)

## **カメラでシェイプを回転させる**

PowerPoint では、3-D 回転ペインで 3D 回転を設定します。X、Y、Z の回転値は、カメラ API で設定する回転に対応します。

![X、Y、Z 回転値が強調表示された PowerPoint の 3-D 回転ペイン](img_02_01.png)

Aspose.Slides では、[IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) を介してカメラにアクセスします。この例は矩形を作成し、正射投影の正面ビューを選択し、X、Y、Z の回転をそれぞれ 20、30、40 度に設定します。ファイルに保存せずメモリ上でシェイプを構成します：

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

ビューアがオブジェクトを見る視点を変更したい場合にカメラを使用します。スライド上の 2D シェイプの幾何形状は変更されません。PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点が変更されます。

### **テンプレートシェイプからカメラの向きコピー**

テンプレートシェイプの向きを合わせるには、[getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) でカメラのプリセットを取得し、[getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--) で回転角度を取得します。この例は `template.pptx` を開き、最初のスライドの最初のシェイプから 2 番目のシェイプへカメラの向きをコピーします。両方のシェイプはすでに 3D ライティングが設定されており、2 番目のシェイプには明示的なカメラ回転がありません。

角度は度単位です。インデックス `0` が緯度、`1` が経度、`2` が回転です。この順序で [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) に渡します。ソースが `null` を返す場合、明示的な回転が設定されていないため、2 番目のシェイプの角度は設定しません。`(0, 0, 0)` の明示的な回転は 0 が 3 つ返され、コピーすべきです。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`camera-copy.pptx` を PowerPoint で再び開くと、右側の矢印は左側の矩形と同じカメラプリセットと回転を持ちます。両シェイプは同じライティングと押し出し深さを使用しています。

![上部および右側から見た、カメラ向きが一致した青い 3D 矩形と右向き矢印](camera-orientation.png)

## **押し出しと奥行きの追加**

押し出しはシェイプの前面の後方に拡張することで、厚みを持たせます。PowerPoint では、奥行きコントロールでこの可視厚みを設定し、色コントロールで側面の色を設定します。

![PowerPoint の奥行きコントロールが押し出しの色と高さプロパティに対応](img_02_02.png)

[IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) を使用して厚さを設定し、[IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) で側面の色を取得します。この例は矩形に 100 ポイントの紫色側面の押し出しを付与し、カメラを回転させて厚みを確認します。ファイルに保存せずメモリ上でシェイプを構成します：

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) メソッドは 3D シェイプの奥行きを設定します。[setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) メソッドはこの例で示すように、押し出し効果の高さを制御します。

## **3D 効果とともにグラデーションまたは画像塗りつぶしを使用する**

3D 書式設定はシェイプの塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、または画像塗りつぶしを適用しつつ、同じカメラ、光、素材、押し出し設定を使用できます。

この例は前面に青からオレンジへのグラデーションを、150 ポイントの押し出し側面に暗いオレンジ色を適用します。グラデーションストップは 0 と 100 が開始と終了を示します。カメラ回転値は度単位です。スライドはデフォルトサイズの 2 倍の PNG 画像にレンダリングされます：

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

レンダリングされた出力は前面のグラデーションを保持し、押し出しを別々にレンダリングします：

![青からオレンジへのグラデーション塗りとオレンジの押し出しを持つ 3D 矩形のレンダリング](img_02_03.png)

代わりに画像塗りつぶしを使用するには、画像をプレゼンテーションに追加し、シェイプの塗りつぶしに割り当てます。この例は作業ディレクトリに "image.jpg" という名前の既存ファイルが必要です。画像を矩形全体に伸張し、150 ポイントの押し出しを適用し、カメラ回転を度単位で設定します。ファイルに保存またはレンダリングせずメモリ上でシェイプを構成します：

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

![前面に写真塗りつぶし、オレンジの押し出しを持つ 3D 矩形のレンダリング](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例は、オレンジと白の格子パターンのテキストを作成し、上向きのアーチを適用し、[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) を介して 3D 設定を構成します。押し出し高さと奥行きはポイント単位、光の回転は度単位です。シェイプの塗りつぶしと輪郭は非表示にし、テキストのみが表示されます。例はデフォルトスライドサイズの 2 倍の PNG 画像をレンダリングし、プレゼンテーションを PPTX として保存します：

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

![アーチ状 WordArt 変形、オレンジのパターン塗り、暗い押し出しを持つ 3D テキストのレンダリング](img_02_05.png)

## **3D シェイプ上でテキストを平らに保つ**

シェイプの 3D 外観を保持しつつテキストを読みやすくするには、[ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--) を通じて [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) を呼び出します。値が `true` の場合、テキストは 3D シーンから除外されます。`false` の場合、テキストはシーンに参加し、3D の向きに従います。

この設定はシェイプの 3D 書式設定を削除しません。そのカメラ、ライティング、素材、押し出しは [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) を介して引き続き構成されています。また、通常の回転とは異なります。[IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) はスライド平面でシェイプを回転させ、[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) はテキストのバウンディング ボックス内でのカスタム回転を制御します。テキストを 3D シーンから除外してもこれらの角度はリセットされません。

以下の自立型例は、テキスト入りの青い矩形を作成し、元の横に複製します。両シェイプは同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左側は `false`、右側は `true`。カメラ角度は度単位で、押し出し高さは 40 ポイントです。例はプレゼンテーションを PPTX として保存し、比較スライドをデフォルトサイズの 2 倍の PNG にレンダリングします：

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

左側はテキストが 3D の向きに従い、右側は平坦で読みやすくなります。両矩形は同じ可視的な押し出しと 3D 向きを保持しています。

![左右に並んだ 3D 矩形：左側はテキストが 3D の向きに従い、右側は平坦で読みやすい](keep_text_flat.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスター化または 2D 結果として出力に描画されます。これはスライドを [PNG](/slides/ja/java/convert-powerpoint-to-png/) にレンダリングしたり、[PDF](/slides/ja/java/convert-powerpoint-to-pdf/) にエクスポートしたり、[HTML](/slides/ja/java/convert-powerpoint-to-html/) にエクスポートしたり、[ビデオ変換](/slides/ja/java/convert-powerpoint-to-video/) 用のフレームを生成する場合にも適用されます。

- エクスポートされた画像や PDF はインタラクティブではありません。オブジェクトはエクスポート後にビューアで回転させることができません。
- 最終的な外観はカメラ、光源、素材、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承された値やテーマベースの書式設定値を確認する必要がある場合は、[有効なシェイププロパティ](/slides/ja/java/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保持できません。そのような形式では、視覚的結果がレンダリングされ、編集可能な 3D 設定としては保持されません。

## **よくある質問**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**  
Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはできません。PPTX では、フォーマットが対応している場合に PowerPoint 上で 3D 書式設定が編集可能なまま保持されます。

**3D モデルと 3D 効果の違いは何ですか？**  
3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は通常の PowerPoint シェイプやテキストに適用される書式設定で、回転、押し出し、ベベル、照明、素材などがあります。本稿は 3D 効果について解説しています。

**可視的な 3D シェイプに必要な設定は何ですか？**  
最低限、カメラ回転と押し出しまたは奥行きを設定します。実務上は、ハイライトと影をはっきりさせるために光源と素材も設定することが推奨されます。

**シェイプとテキストの両方に 3D 効果を適用できますか？**  
はい。シェイプ本体には [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) を、テキストには [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) を使用します。

**画像、PDF、HTML、ビデオフレームにエクスポートしたときに 3D 効果は表示されますか？**  
はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**  
はい。[有効なシェイププロパティ](/slides/ja/java/shape-effective-properties/) に記載された有効な書式設定 API を使用して、最終的なカメラ、光源、ベベル、関連する 3D 値を読み取れます。