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
description: "Android で Aspose.Slides を使用して PowerPoint のシェイプとテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、素材、押し出し、塗り、3D テキストを設定します。"
---
## **概要**

Aspose.Slides for Android via Java は、シェイプやテキストの PowerPoint スタイル 3D 書式設定の作成、編集、保持、レンダリングができます。この記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像塗り、3D テキストなどの 3D 効果について説明します。

{{% alert color="info" %}}
このガイドは、PowerPoint のシェイプとテキストに対する 3D 書式設定効果について説明しています。単独の 3D モデル ファイルの挿入や編集については扱いません。スライドを画像、PDF、または HTML にエクスポートする際、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

シェイプに 3D 書式設定を適用するには、[IShape.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) メソッドを使用します。このメソッドは[IThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/) を返し、対象シェイプの 3D シーンを制御します。

テキストの場合は、[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) メソッドを使用します。これにより、シェイプ本体ではなくテキスト フレームに 3D 書式設定が適用されます。

最も重要な API メンバーは次のとおりです。

| API メンバー | 制御対象 | 使用シーン |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 視点、プリセット カメラ タイプ、回転、ズーム、遠近感。 | オブジェクトを 3D 空間で回転させる、または PowerPoint の 3D 回転プリセットと一致させる場合。 |
| [getLightRig](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | 光源プリセット、方向、光の回転。 | 3D 表面上のハイライトとシャドウの表示方法を変更する場合。 |
| [getMaterial](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) と [setMaterial](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | 平坦、マット、プラスチック、金属などの表面素材。 | 同じジオメトリをよりフラット、柔らか、光沢、金属的に見せたい場合。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) と [setExtrusionHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | シェイプの表面から後方にどれだけ伸びるか。 | 平面シェイプを目に見える厚みのある 3D オブジェクトに変える場合。 |
| [getExtrusionColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 押し出し側面の色。 | 奥行きを視覚化したり、前面の塗りと側面の色を合わせたい場合。 |
| [getDepth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getDepth--) と [setDepth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint の 3D 書式設定で使用される追加の 3D 深さ。 | ベベルや素材設定と組み合わせて、シェイプやテキストの深さを微調整したい場合。 |
| [getBevelTop](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) と [getBevelBottom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 前面と背面のエッジの凹凸または丸み。 | 鋭い平面ではなく、丸みや成形されたエッジを追加したい場合。 |
| [getContourColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), と [setContourWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D オブジェクトの輪郭。 | レンダリング結果でオブジェクトの境界線を強調したい場合。 |

## **3D シェイプの作成**

シェイプが説得力のある 3D に見えるためには、通常、4 種類の設定が必要です：

- カメラ設定（デフォルトの正面ビューでは押し出しが隠れる可能性があるため）
- 照明設定（光が面や側面を見やすくするため）
- 素材設定（表面が光の描写に影響するため）
- 押し出しまたは深さの設定（平面シェイプに厚みを持たせるため）

以下の例は、長方形を作成し、前面にテキストを追加し、3D 書式設定を適用し、プレゼンテーションを PPTX として保存し、スライドを PNG 画像にレンダリングします。

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

レンダリングされたスライド画像は、長方形が厚みのある 3D ブロックとして表示されます：

![前面に白い 3D テキストがある青い 3D 長方形のレンダリング画像](img_01_01.png)

## **カメラでシェイプを回転する**

PowerPoint では、3-D Rotation パネルで 3D 回転を設定します。X、Y、Z の回転値はカメラ API で設定する回転に対応しています。

![X、Y、Z 回転値が強調表示された PowerPoint の 3-D Rotation パネル](img_02_01.png)

Aspose.Slides では、[IThreeDFormat.getCamera](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getCamera--) を使用してカメラの種類と回転を設定します：

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

ビューアがオブジェクトを見る角度を変更したいときにカメラを使用します。スライド上の 2D シェイプジオメトリは変更されず、PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点が変わります。

## **押し出しと深さの追加**

押し出しは、シェイプの前面の背後に拡張することで厚みを持たせます。PowerPoint では、深さコントロールがこの可視厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の深さコントロールが押し出し色と押し出し高さプロパティにマッピングされた様子](img_02_02.png)

厚さには[IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) を、側面の色には[IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) を使用します：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

PowerPoint の深さ値を直接操作したり、深さをベベル、素材、テキスト効果と組み合わせたい場合は[IThreeDFormat.setDepth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) を使用します。多くのシェイプシナリオでは、`setExtrusionHeight` の方が可視押し出しを直接表現できるため、より分かりやすい設定です。

## **3D 効果と一緒にグラデーションまたは画像塗りを使用する**

3D 書式設定はシェイプの塗りとは独立しています。前面に単色、グラデーション、パターン、画像塗りのいずれかを適用しつつ、同じカメラ、光、素材、押し出し設定を使用できます。

この例はシェイプにグラデーション塗りを適用し、側面には暗めの押し出し色を設定します：

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
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

![青からオレンジへのグラデーション塗りとオレンジの押し出しを持つ 3D 長方形のレンダリング画像](img_02_03.png)

画像塗りを使用したい場合は、画像をプレゼンテーションに追加し、シェイプの塗りに割り当てます：

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

![前面に写真塗り、側面にオレンジの押し出しを持つ 3D 長方形のレンダリング画像](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

シェイプの 3D 書式設定はシェイプ本体に影響し、テキストの 3D 書式設定はテキスト フレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例はパターン塗りのテキストを作成し、WordArt 変形を適用し、[ITextFrameFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/) に 3D 設定を構成します：

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
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

![アーチ状の WordArt 変形、オレンジのパターン塗り、暗めの押し出しを持つ 3D テキストのレンダリング画像](img_02_05.png)

## **エクスポートおよびレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズされ、2D 結果として出力に描画されます。これはスライドを[PNG](/slides/ja/androidjava/convert-powerpoint-to-png/)、[PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/androidjava/convert-powerpoint-to-html/)、または[video conversion](/slides/ja/androidjava/convert-powerpoint-to-video/) 用のフレームに変換する際にも適用されます。

以下の点に注意してください：

- エクスポートされた画像や PDF はインタラクティブではありません。オブジェクトはエクスポート後にビューアで回転できません。
- 最終的な見た目はカメラ、光源、素材、押し出し、塗り、スライドのスケーリングの組み合わせに依存します。
- 継承された値やテーマベースの書式設定値を確認する必要がある場合は、[effective shape properties](/slides/ja/androidjava/shape-effective-properties/) を参照してください。
- 一部の出力形式では、編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的な結果がレンダリングされ、編集可能な 3D 設定として保持されません。

## **FAQ**

### Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？

Aspose.Slides はシェイプとテキストの PowerPoint 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはできません。PPTX では、形式がサポートしている限り 3D 書式設定は PowerPoint で編集可能なまま残ります。

### 3D モデルと 3D 効果の違いは何ですか？

3D モデルはプレゼンテーションに挿入する別個の 3D オブジェクトです。3D 効果は通常の PowerPoint シェイプやテキストに適用する書式設定で、回転、押し出し、ベベル、照明、素材などがあります。本記事は 3D 効果について扱います。

### 見える 3D シェイプを作成するために必要な設定はどれですか？

最低でもカメラの回転と押し出しまたは深さのいずれかを設定する必要があります。実務では、光源と素材も設定して、レンダリングされた面に明確なハイライトとシャドウを持たせることが一般的です。

### シェイプとテキストの両方に 3D 効果を適用できますか？

はい。シェイプ本体には[IShape.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) を、テキストには[ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) を使用します。

### 画像、PDF、HTML、またはビデオ フレームにエクスポートする際に 3D 効果は表示されますか？

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれますが、編集可能な 3D オブジェクトは含まれません。

### 継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？

はい。[Shape Effective Properties](/slides/ja/androidjava/shape-effective-properties/) で説明されている有効な書式設定 API を使用して、最終的なカメラ、光源、ベベル、関連する 3D 値を取得できます。