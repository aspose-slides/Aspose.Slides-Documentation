---
title: Android でプレゼンテーションに 3D エフェクトを作成する
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
description: "Aspose.Slides を使用して Android 上で PowerPoint のシェイプとテキストに 3D エフェクトを適用およびレンダリングします。カメラ、照明、マテリアル、押し出し、塗りつぶし、そして 3D テキストを設定します。"
---
## **概要**

Aspose.Slides for Android via Java は、シェイプやテキストに対して PowerPoint スタイルの 3D 書式設定を作成、編集、保持、レンダリングできます。この記事では、回転、押し出し、ベベル、照明、マテリアル、グラデーションまたは画像の塗りつぶし、そして 3D テキストなどの 3D 効果について説明します。

{{% alert color="info" title="Note" %}}
この記事は、PowerPoint のシェイプとテキストに対する 3D 書式効果について説明しています。単独の 3D モデル ファイルの挿入や編集については説明していません。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) メソッドを使用します。このメソッドは [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/) を返し、該当シェイプの 3D シーンを制御します。

テキストの場合は、[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) メソッドを使用します。これはシェイプ本体ではなく、テキストフレームに 3D 書式設定を適用します。

最も重要な API メンバーは次のとおりです：

| API メンバー | 制御内容 | 使用タイミング |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 視点、プリセットカメラタイプ、回転、ズーム、遠近感。 | オブジェクトを 3D 空間で回転させるか、PowerPoint の 3D 回転プリセットに合わせる場合に使用します。 |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | 光のプリセット、方向、光の回転。 | 3D 表面上のハイライトと影の表示方法を変更します。 |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) と [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面素材（フラット、マット、プラスチック、金属など）。 | 同じ形状をより平坦に、柔らかく、光沢のある、または金属的に見せます。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) と [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | シェイプが正面からどれだけ後方に伸びるか。 | 平面のシェイプを目に見える厚みのある 3D オブジェクトに変換します。 |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 押し出された側面の色。 | 奥行きを可視化するか、側面の色を前面の塗りつぶしと合わせます。 |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) と [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint の 3D 書式設定で使用される追加の 3D 奥行き。 | シェイプやテキストの奥行きを微調整します。特にベベルやマテリアル設定と組み合わせて使用します。 |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) と [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 正面と背面のエッジを上げたり丸めたりしたもの。 | 鋭い平面の代わりに、柔らかく成形されたエッジを追加します。 |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) と [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) と [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D オブジェクトの輪郭線。 | レンダリング結果でオブジェクトの境界を強調します。 |

## **3D シェイプの作成**

シェイプが本格的に 3D に見えるためには、通常、次の 4 種類の設定が必要です：

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れてしまうため。
- 光設定：照明により面や側面が見やすくなるため。
- マテリアル設定：表面が光のレンダリングに影響するため。
- 押し出しまたは奥行き設定：平面のシェイプに厚みを持たせるため。

以下の例は矩形を作成し、正面にテキストを追加して 3D 書式設定を適用します。カメラの回転値は度単位で、押し出し高さは 100 ポイントです。この例はスライドをデフォルトサイズの 2 倍の PNG 画像にレンダリングし、プレゼンテーションを PPTX として保存します。

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

レンダリングされたスライド画像は、矩形が太い 3D ブロックとして表示されます：

![正面に白い 3D テキストがある、レンダリングされた青い 3D 矩形](img_01_01.png)

## **カメラでシェイプを回転させる**

PowerPoint では、3-D 回転は「3-D 回転」ペインで設定します。X、Y、Z の回転値は、カメラ API を通じて設定する回転に対応します。

![X、Y、Z 回転値が強調表示された PowerPoint の 3-D 回転ペイン](img_02_01.png)

Aspose.Slides では、[IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) を使用してカメラにアクセスします。この例は矩形を作成し、正投影の正面ビューを選択し、X、Y、Z の回転をそれぞれ 20、30、40 度に設定します。ファイルを保存せずにメモリ上でシェイプを構成します：

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

ビューアがオブジェクトを見る視点を変更したいときにカメラを使用します。スライド上の 2D シェイプのジオメトリは変更されません。PowerPoint および Aspose.Slides がレンダリング時に使用する 3D 視点が変更されます。

### **テンプレートシェイプからカメラの向きをコピーする**

テンプレートシェイプの向きを合わせるには、[getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) でカメラのプリセットを取得し、[getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--) で回転角度を取得します。この例は `template.pptx` を開き、1 番目のスライドの最初のシェイプから 2 番目のシェイプへカメラの向きをコピーします。両方のシェイプはすでに 3D ライティングが設定されており、2 番目のシェイプには明示的なカメラ回転がありません。

角度は度単位です。インデックス `0` が緯度、`1` が経度、`2` が回転を表します。この順序で [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) に渡します。ソースが `null` を返した場合は明示的な回転がないので、2 番目のシェイプの角度は設定しません。`(0, 0, 0)` の明示的な回転は 3 つのゼロを返し、コピーすべきです。

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

`camera-copy.pptx` を PowerPoint で再度開くと、右側の矢印は左側の矩形と同じカメラプリセットと回転を持ちます。両方のシェイプは同じ照明と押し出し奥行きを使用しています。

![上方右側から見た、カメラの向きが一致した青い 3D 矩形と右向き矢印](camera-orientation.png)

## **押し出しと奥行きの追加**

押し出しは、シェイプを前面の裏側に拡張することで厚みを持たせます。PowerPoint では、奥行きコントロールがこの可視的な厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の奥行きコントロールが押し出し色と押し出し高さプロパティに対応](img_02_02.png)

[IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) を使用して厚さを設定し、[IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) で側面の色を取得します。この例は矩形に 100 ポイントの押し出しと紫色の側面を設定し、カメラを回転させて厚みを表示します。ファイルを保存せずにメモリ上でシェイプを構成します：

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) メソッドは 3D シェイプの奥行きを設定します。[setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) メソッドは押し出し効果の高さを制御します。この例で示されています。

## **3D 効果でグラデーションまたは画像塗りつぶしを使用する**

3D 書式設定はシェイプの塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、または画像塗りつぶしを適用しても、同じカメラ、光、マテリアル、押し出し設定を使用できます。

この例は前面に青からオレンジへのグラデーションを適用し、150 ポイントの押し出しに濃いオレンジ色を設定します。グラデーションの停止位置 0 と 100 が開始と終了を示します。カメラの回転値は度です。スライドはデフォルトサイズの 2 倍の PNG 画像にレンダリングされます：

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

レンダリングされた出力は前面のグラデーションを保持し、押し出しを別々にレンダリングします：

![青からオレンジへのグラデーション塗りとオレンジの押し出しを持つレンダリングされた 3D 矩形](img_02_03.png)

代わりに画像塗りつぶしを使用するには、画像をプレゼンテーションに追加し、シェイプの塗りつぶしに割り当てます。この例は作業ディレクトリに「image.jpg」というファイルが存在することが前提です。画像を伸張して矩形を埋め、150 ポイントの押し出しを適用し、カメラの回転を度単位で設定します。ファイルを保存またはレンダリングせずにメモリ上でシェイプを構成します：

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

画像は前面にレンダリングされ、押し出しは 3D 側面としてレンダリングされます：

![前面に写真塗り、オレンジの押し出しを持つレンダリングされた 3D 矩形](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、マテリアル、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例はオレンジと白の格子パターンのテキストを作成し、上向きのアーチを適用し、[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) を通じて 3D 設定を構成します。押し出し高さと奥行きはポイント、光の回転は度単位です。シェイプの塗りつぶしとアウトラインは非表示にし、テキストだけが表示されます。この例はデフォルトスライドサイズの 2 倍の PNG 画像をレンダリングし、プレゼンテーションを PPTX として保存します：

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

テキストは曲がった押し出し 3D 文字としてレンダリングされます：

![アーチ状の WordArt 変形、オレンジのパターン塗り、暗い押し出しを持つレンダリングされた 3D テキスト](img_02_05.png)

## **3D シェイプ上でテキストを平面に保つ**

シェイプの 3D 外観を保ちつつテキストを読みやすくするには、[ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) 経由で [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) を呼び出します。値が `true` の場合、テキストは 3D シーンから除外されます。`false` の場合、テキストはシーンに参加し、3D 向きに従います。

この設定はシェイプの 3D 書式設定（カメラ、照明、マテリアル、押し出し）を削除しません。これらは [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) を通じて設定されたままです。また、通常の回転とは異なります。[IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) はスライド平面上でシェイプを回転させ、[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) はテキストのバウンディング ボックス内でのカスタム回転を制御します。テキストを 3D シーンから除外しても、これらの角度はリセットされません。

以下のスタンドアロン例は、テキスト付きの青い矩形を作成し、元の横にコピーします。両方のシェイプは同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左は `false`、右は `true`。カメラ角度は度単位で、押し出し高さは 40 ポイントです。この例はプレゼンテーションを PPTX として保存し、比較スライドをデフォルトサイズの 2 倍の PNG にレンダリングします。

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

左側ではテキストが 3D 向きに従います。右側ではテキストが平面のままで読みやすくなります。両方の矩形は同じ可視的な押し出しと 3D 向きを保持します。

![左右に並んだ 3D 矩形：左側はテキストが 3D 向きに従い、右側は平面のまま](keep_text_flat.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズされ、2D の結果として出力に描画されます。これはスライドを [PNG](/slides/ja/androidjava/convert-powerpoint-to-png/) にレンダリングする、[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/) にエクスポートする、[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/) にエクスポートする、または [動画変換](/slides/ja/androidjava/convert-powerpoint-to-video/) 用のフレームを生成する場合にも適用されます。

- エクスポートされた画像や PDF はインタラクティブではありません。オブジェクトはエクスポート後にビューアによって回転できません。
- 最終的な外観はカメラ、ライトリグ、マテリアル、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承された値やテーマベースの書式設定値を確認する必要がある場合は、[シェイプの有効プロパティ](/slides/ja/androidjava/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的結果はレンダリングされ、編集可能な 3D 設定として保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides はシェイプやテキスト向けの PowerPoint 3D 効果を作成・レンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはありません。PPTX では、形式がサポートしている限り、3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は、回転、押し出し、ベベル、照明、マテリアルなど、通常の PowerPoint シェイプやテキストに適用される書式設定です。本記事は 3D 効果について説明しています。

**見える 3D シェイプに必要な設定は何ですか？**

最低限、カメラの回転と押し出しまたは奥行きを設定します。実務では、ライトリグとマテリアルも設定し、レンダリングされた面に明確なハイライトと影を付けます。

**シェイプとテキストの両方に 3D 効果を適用できますか？**

はい。シェイプ本体には [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--)、テキストには [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) を使用します。

**画像、PDF、HTML、または動画フレームにエクスポートする際に 3D 効果は表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、動画変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力はレンダリングされた外観を含み、編集可能な 3D オブジェクトは含みません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。[シェイプの有効プロパティ](/slides/ja/androidjava/shape-effective-properties/) に記載の有効書式設定 API を使用して、最終的なカメラ、ライトリグ、ベベル、および関連する 3D 値を取得できます。