---
title: JavaでWordArtエフェクトを作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/java/wordart/
keywords:
- WordArt
- WordArt作成
- WordArtテンプレート
- WordArtエフェクト
- 影エフェクト
- 反射エフェクト
- 光彩エフェクト
- WordArt変形
- 3Dエフェクト
- 外側の影エフェクト
- 内側の影エフェクト
- Java
- Aspose.Slides
description: "Aspose.Slides for Java で WordArt エフェクトを作成およびカスタマイズします。このステップバイステップ ガイドは、開発者が Java でプレゼンテーションにプロフェッショナルなテキストを追加するのに役立ちます。"
---
## **概要**

WordArt エフェクトを使用すると、塗りつぶし、アウトライン、影、反射、光彩、変形、および 3D 書式設定でテキストを装飾できます。本記事では、Microsoft Office をインストールせずに Aspose.Slides for Java を使用して PowerPoint プレゼンテーションでこれらのエフェクトを作成およびカスタマイズする方法を説明します。

## **シンプルな WordArt テンプレートを作成してテキストに適用する**

以下の例では、テキスト、フォント、パターン塗りつぶし、アウトラインを設定してシンプルな WordArt スタイルを作成します。

各例は新しいプレゼンテーションを作成し、最初のスライドに長方形を追加します。入力ファイルは必要ありません。最初の例ではテキストを「Aspose.Slides」に設定します。シェイプの位置とサイズはポイント単位で測定されます:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

フォーマットをより目立たせるために、フォントを Arial Black の 36 ポイントに設定します:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

暗オレンジの前景色と白い背景色で[SmallGrid](https://reference.aspose.com/slides/ja/java/com.aspose.slides/patternstyle/#SmallGrid)パターンを適用し、幅 1 ポイントの黒いテキストアウトラインを追加します:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color darkOrange = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

結果のテキスト:

![シンプルな WordArt テンプレート](WordArt_template.png)

## **他の WordArt エフェクトを適用する**

以下の例では、テキストに影、反射、光彩、変形、3D エフェクトを適用する方法を示します。

### **外側の影エフェクトを適用する**

外側の影はテキストの背後に影を配置することで奥行きを加えます。色、方向、距離、ぼかし半径、スケール、歪みをカスタマイズできます。

この例では[enableOuterShadowEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--)を呼び出し、ぼかし半径 4 ポイント、方向 230 度、距離 30 ポイントの黒い影を設定します。スケール値 100 は影のサイズを保持し、水平歪みは 20 度で傾けます。アルファ変換で不透明度を 32% に設定します:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

結果のテキスト:

![外側の影エフェクト](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- 外側の影とプリセットの影を同時に使用すると、外側の影のみが適用されます。
- 外側の影と内側の影を同時に使用すると、結果のエフェクトは PowerPoint のバージョンによって異なります。例として、PowerPoint 2013 ではエフェクトが二重になり、PowerPoint 2007 では外側の影だけが適用されます。
{{% /alert %}}

### **反射エフェクトを適用する**

反射はテキストの鏡像コピーを作成します。位置、スケール、ぼかし、不透明度を調整して外観を制御します。

この例では[enableReflectionEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/effectformat/#enableReflectionEffect--)を呼び出し、スケール -100% で反射を垂直に反転します。ぼかし半径 0.5 ポイント、距離 4.72 ポイントを使用します。不透明度は反射の位置 0% から 60% の間で 60% から 0.9% に減少します:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    presentation.dispose();
}
```

結果のテキスト:

![反射エフェクト](reflection_effect.png)

### **光彩エフェクトを適用する**

光彩はテキストの周囲に柔らかな色付きアウトラインを追加します。色、不透明度、半径を調整してエフェクトを制御します。

この例では[enableGlowEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/effectformat/#enableGlowEffect--)を呼び出し、54% の不透明度で半径 7 ポイントの赤い光彩を適用します:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

結果のテキスト:

![光彩エフェクト](glow_effect.png)

### **WordArt 変形を適用する**

WordArt 変形はテキストブロックを曲げたり、伸ばしたり、ゆがめたりします。

[setTransform] を [ArchUpPour] に設定して、テキストフレーム全体を上向きに曲げます:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

結果のテキスト:

![WordArt 変形](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java は、事前定義された[transformation types](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textshapetype/)のセットを提供します。
{{% /alert %}}

### **シェイプとテキストに 3D エフェクトを適用する**

シェイプまたはそのテキストに 3D エフェクトを適用できます。ベベル、押し出し、照明、カメラ設定が結果の外観を制御します。

以下の例では[ThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/threedformat/)を使用して、長方形に円形ベベル、オレンジの押し出し、暗い赤の輪郭を追加します。ベベルの寸法、押し出し高さ、輪郭幅、深さはポイント単位で測定されます。プラスチック素材、Z 軸回りに 40 度回転したバランスの取れた照明、およびパースペクティブ カメラが外観を定義します:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

結果のシェイプ:

![シェイプ 3D エフェクト](shape_3D_effect.png)

この例では[TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframeformat/#getThreeDFormat--)を介してテキストにも同様の 3D 書式設定を適用します。小さなベベルが文字のエッジを形作り、押し出しと照明がテキストに奥行きを与えます:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

結果のテキスト:

![テキスト 3D エフェクト](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
テキストまたはシェイプに 3D エフェクトを適用すること、およびこれらのエフェクト間の相互作用は、特定のルールに従います。テキストとそれを含むシェイプの両方が関与するシーンを考えてみてください。3D エフェクトはオブジェクトの 3D 表現とそれが配置されるシーンを含みます。

- シェイプとテキストの両方にシーンが設定されている場合、シェイプのシーンが優先され、テキストのシーンは無視されます。
- シェイプに独自のシーンがなく 3D 表現がある場合、テキストのシーンが使用されます。
- シェイプに 3D エフェクトが全くない場合、平面として扱われ、3D エフェクトはテキストにのみ適用されます。

これらの動作は[ThreeDFormat.getLightRig](https://reference.aspose.com/slides/ja/java/com.aspose.slides/threedformat/#getLightRig--)および[ThreeDFormat.getCamera](https://reference.aspose.com/slides/ja/java/com.aspose.slides/threedformat/#getCamera--)メソッドに関係します。
{{% /alert %}}

テキストを平坦で読みやすく保ちつつシェイプの 3D 書式設定を保持するには、[Keep Text Flat on a 3D Shape](/slides/ja/java/3d-presentation/) を参照して、両方の設定の比較と完全な Java サンプルをご覧ください。

## **FAQ**

**異なるフォントやスクリプト（例: アラビア語、中文）で WordArt エフェクトを使用できますか？**

はい、Aspose.Slides for Java は Unicode をサポートしており、主要なフォントとスクリプトすべてで動作します。影、塗りつぶし、アウトラインなどの WordArt エフェクトは言語に関係なく適用できますが、フォントの利用可能性やレンダリングはシステムフォントに依存する場合があります。

**スライドマスター要素に WordArt エフェクトを適用できますか？**

はい、マスタースライド上のシェイプ（タイトルプレースホルダー、フッター、背景テキストなど）に WordArt エフェクトを適用できます。マスターのレイアウトに加えた変更は、関連するすべてのスライドに反映されます。

**WordArt エフェクトはプレゼンテーションのファイルサイズに影響しますか？**

やや影響します。影、光彩、グラデーション塗りつぶしなどの WordArt エフェクトは、追加の書式メタデータによりファイルサイズを僅かに増加させる可能性がありますが、差は通常は無視できる程度です。

**プレゼンテーションを保存せずに WordArt エフェクトの結果をプレビューできますか？**

はい、[ISlide.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#getImage--) を使用して WordArt を含むスライドを画像（例: PNG、JPEG）にレンダリングしたり、[IShape.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getImage--) を使用して個々のシェイプをレンダリングしたりできます。これにより、プレゼンテーション全体を保存またはエクスポートする前に、メモリ内または画面上で結果をプレビューできます。