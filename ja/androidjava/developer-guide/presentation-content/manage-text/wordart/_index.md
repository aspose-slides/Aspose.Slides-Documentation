---
title: Android で WordArt 効果を作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/androidjava/wordart/
keywords:
- WordArt
- WordArt を作成
- WordArt テンプレート
- WordArt 効果
- 影効果
- 表示効果
- 光彩効果
- WordArt 変形
- 3D 効果
- 外部影効果
- 内部影効果
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android で WordArt 効果を作成およびカスタマイズします。このステップバイステップのガイドは、開発者が Java でプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---
## **Overview**

WordArt 効果を使用すると、PowerPoint プレゼンテーションに視覚的に魅力的で装飾されたテキストを追加できます。Aspose.Slides を使用すれば、開発者は Microsoft PowerPoint と同様に、Office をインストールせずに、プログラムで WordArt を作成、カスタマイズ、管理できます。本記事では、WordArt の使用概要として、テキスト変形、塗りつぶしスタイル、アウトライン、影、その他の書式設定オプションを適用して、プレゼンテーションのコンテンツをより表現力豊かで魅力的にする方法を説明します。WordArt はテキストをグラフィック オブジェクトとして扱うことができます。テキストに適用される効果や特殊な変更により、より目立たせたり魅力的にしたりします。

## **Create a Simple WordArt Template and Apply It to Text**

**Using Aspose.Slides** 

最初に、以下の Java コードを使用してシンプルなテキストを作成します: 

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
次に、フォントの高さを大きく設定して効果を目立たせるため、以下のコードを使用します: 

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**Using Microsoft PowerPoint**

Microsoft PowerPoint の WordArt 効果メニューへ移動します:

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから事前定義された WordArt 効果を選択できます。左側のメニューから新しい WordArt の設定を指定できます。 

利用可能なパラメータやオプションの一部を以下に示します:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

ここでは、テキストに [SmallGrid](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/PatternStyle#SmallGrid) パターンカラーを適用し、幅 1 の黒色テキスト枠線を追加するコードを示します:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}
```

結果のテキスト:

![todo:image_alt_text](image-20200930114108-4.png)

## **Apply Other WordArt Effects**

**Using Microsoft PowerPoint**

プログラムのインターフェイスから、テキスト、テキストブロック、図形、または類似の要素にこれらの効果を適用できます:

![todo:image_alt_text](image-20200930114129-5.png)

例えば、影、反射、光彩の効果はテキストに適用でき、3D 書式と 3D 回転の効果はテキストブロックに適用でき、ソフトエッジ プロパティは図形オブジェクトに適用できます（3D 書式プロパティが設定されていなくても効果があります）。 

### **Apply Shadow Effects**

ここでは、テキストに関するプロパティのみを設定することを目的とし、以下の Java コードで影効果をテキストに適用します:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    if (pres != null) pres.dispose();
}
```

Aspose.Slides API は、OuterShadow、InnerShadow、PresetShadow の 3 種類の影をサポートしています。  

PresetShadow を使用すると、プリセット値でテキストに影を適用できます。 

**Using Microsoft PowerPoint**

PowerPoint では、1 種類の影のみ使用できます。以下は例です:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides では、InnerShadow と PresetShadow の 2 種類の影を同時に適用できます。

**Notes:**

- OuterShadow と PresetShadow を同時に使用すると、適用されるのは OuterShadow のみです。 
- OuterShadow と InnerShadow を同時に使用した場合、適用結果は PowerPoint のバージョンに依存します。たとえば PowerPoint 2013 では効果が二重になり、PowerPoint 2007 では OuterShadow が適用されます。 

### **Apply Reflection Effects to Text**

以下の Java コードサンプルでテキストに反射効果を追加します:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
    if (pres != null) pres.dispose();
}
```

### **Apply Glow Effects to Text**

以下のコードでテキストに光彩効果を適用し、輝きや目立たせます:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

操作結果:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 
影、反射、光彩のパラメータは変更可能です。効果のプロパティはテキストの各部分に個別に設定されます。 
{{% /alert %}} 

### **Use Transformations in WordArt**

テキスト全体に固有の Transform プロパティを以下のコードで使用します:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}
```

結果:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 
Microsoft PowerPoint と Aspose.Slides for Android（Java） の両方が、いくつかの事前定義された変形タイプを提供しています。 
{{% /alert %}} 

**Using PowerPoint**

事前定義された変形タイプにアクセスするには、**Format** -> **TextEffect** -> **Transform** の順に選択します。

**Using Aspose.Slides**

変形タイプを選択するには、TextShapeType 列挙体を使用します。 

### **Apply 3D Effects to Text and Shapes**

以下のサンプルコードでテキストシェイプに 3D 効果を設定します:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

結果のテキストとシェイプ:

![todo:image_alt_text](image-20200930114816-9.png)

以下の Java コードでテキストに 3D 効果を適用します:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

操作結果:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 
テキストやシェイプへの 3D 効果の適用や効果間の相互作用は、特定のルールに基づきます。

テキストとテキストを含むシェイプのシーンを考えます。3D 効果は 3D オブジェクトの表現と、そのオブジェクトが配置されるシーンを含みます。

- シーンが図形とテキストの両方に設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。
- 図形に独自のシーンがなく 3D 表現がある場合、テキストのシーンが使用されます。
- それ以外の場合（シェイプ元々に 3D 効果がない場合）、シェイプは平面のままで、3D 効果はテキストのみに適用されます。

これらの説明は ThreeDFormat.getLightRig() および ThreeDFormat.getCamera() メソッドに関連しています。 
{{% /alert %}} 

## **Apply Outer Shadow Effects to Text**

Aspose.Slides for Android（Java）は、[**IOuterShadow**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ioutershadow/) と [**IInnerShadow**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iinnershadow/) クラスを提供し、[TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) に含まれるテキストに影効果を適用できます。以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに矩形タイプの AutoShape を追加します。
4. AutoShape に関連付けられた TextFrame にアクセスします。
5. AutoShape の FillType を NoFill に設定します。
6. OuterShadow クラスのインスタンスを作成します。
7. 影の BlurRadius を設定します。
8. 影の Direction を設定します。
9. 影の Distance を設定します。
10. RectangleAlign を TopLeft に設定します。
11. 影の PresetColor を Black に設定します。
12. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

以下の Java サンプルコードは、上記手順の実装例で、テキストに外側影効果を適用する方法を示します:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // スライドの参照を取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 矩形に TextFrame を追加
    ashp.addTextFrame("Aspose TextBox");

    // テキストの影を取得したい場合に備えてシェイプの塗りつぶしを無効化
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 外側影を追加し、必要なすべてのパラメータを設定
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // プレゼンテーションをディスクに保存
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Apply Inner Shadow Effects to Shapes**

以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 矩形タイプの AutoShape を追加します。
4. InnerShadowEffect を有効にします。
5. 必要なすべてのパラメータを設定します。
6. ColorType を Scheme に設定します。
7. Scheme Color を設定します。
8. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

以下のサンプルコード（上記手順に基づく）は、Java でテキストに内部影効果を適用する方法を示します:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // スライドの参照を取得
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 矩形に TextFrame を追加
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // 内部影効果を有効化
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // 必要なすべてのパラメータを設定
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ColorType を Scheme に設定
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // スキームカラーを設定
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // プレゼンテーションを保存
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Can I use WordArt effects with different fonts or scripts (e.g., Arabic, Chinese)?

異なるフォントやスクリプト（例：アラビア語、中文）で WordArt 効果を使用できますか？

はい、Aspose.Slides は Unicode をサポートし、すべての主要なフォントとスクリプトで動作します。影、塗りつぶし、アウトラインなどの WordArt 効果は言語に関係なく適用できますが、フォントの可用性やレンダリングはシステムフォントに依存する場合があります。

### Can I apply WordArt effects to slide master elements?

スライドマスターの要素に WordArt 効果を適用できますか？

はい、マスタースライド上の図形（タイトルプレースホルダー、フッター、背景テキストなど）にも WordArt 効果を適用できます。マスターのレイアウトを変更すると、関連付けられたすべてのスライドに反映されます。

### Do WordArt effects affect presentation file size?

WordArt 効果はプレゼンテーションのファイルサイズに影響しますか？

わずかに影響します。影、光彩、グラデーション塗りつぶしなどの効果は、追加の書式メタデータが加わるためファイルサイズが若干増加しますが、差は通常は無視できる程度です。

### Can I preview the result of WordArt effects without saving the presentation?

プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？

はい、[IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) または [ISlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/) インターフェイスの `getImage` メソッドを使用して、WordArt を含むスライドを画像（PNG、JPEG など）としてレンダリングできます。これにより、保存やエクスポート前にメモリ上または画面上で結果をプレビューできます。