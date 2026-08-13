---
title: JavaでWordArtエフェクトを作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/java/wordart/
keywords:
- WordArt
- WordArtの作成
- WordArtテンプレート
- WordArtエフェクト
- 影エフェクト
- ディスプレイエフェクト
- 光彩エフェクト
- WordArt変形
- 3Dエフェクト
- 外側影エフェクト
- 内側影エフェクト
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for JavaでWordArtエフェクトを作成およびカスタマイズします。このステップバイステップガイドは、開発者がJavaでプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---
## **概要**

WordArt エフェクトを使うと、PowerPoint プレゼンテーションに視覚的に魅力的で装飾されたテキストを追加できます。Aspose.Slides を使用すれば、Microsoft PowerPoint と同様に、Office をインストールせずにプログラムから WordArt を作成、カスタマイズ、管理できます。本記事では、テキストの変形、塗りつぶしスタイル、アウトライン、影、その他の書式設定オプションを適用して、プレゼンテーションのコンテンツをより表現力豊かにする方法を概要として説明します。WordArt はテキストをグラフィックオブジェクトとして扱います。テキストに対して適用される効果や特殊な修飾により、より目立たせたり、魅力的にしたりします。

## **シンプルな WordArt テンプレートの作成とテキストへの適用**

**Using Aspose.Slides** 

まず、次の Java コードでシンプルなテキストを作成します。

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
次に、テキストのフォント高さを大きくして効果を目立たせるために、以下のコードを使用します。

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}
```

**Using Microsoft PowerPoint**

Microsoft PowerPoint の WordArt エフェクトメニューに移動します:

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから既定の WordArt エフェクトを選択できます。左側のメニューから新しい WordArt の設定を指定できます。

利用可能なパラメータやオプションの一部は次のとおりです:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

ここでは、テキストに [SmallGrid](https://reference.aspose.com/slides/ja/java/com.aspose.slides/PatternStyle#SmallGrid) パターンカラーを適用し、幅 1 の黒いテキスト枠線を追加するコードを示します。

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

## **その他の WordArt エフェクトの適用**

**Using Microsoft PowerPoint**

プログラムのインターフェイスから、テキスト、テキストブロック、シェイプ、または類似の要素に対して次のエフェクトを適用できます:

![todo:image_alt_text](image-20200930114129-5.png)

たとえば、影、反射、光彩のエフェクトはテキストに、3D 形式と 3D 回転のエフェクトはテキストブロックに、ソフトエッジ プロパティはシェイプ オブジェクトに適用できます（3D 形式が設定されていなくても効果はあります）。

### **影エフェクトの適用**

ここでは、テキストにのみ関係するプロパティを設定します。次の Java コードでテキストに影エフェクトを適用します。

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

PresetShadow を使用すると、事前定義された値でテキストに影を適用できます。

**Using Microsoft PowerPoint**

PowerPoint では 1 種類の影しか使用できません。以下は例です:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides では、InnerShadow と PresetShadow の 2 種類の影を同時に適用できます。

**Notes:**

- OuterShadow と PresetShadow を併用すると、適用されるのは OuterShadow のみです。
- OuterShadow と InnerShadow を同時に使用した場合、適用結果は PowerPoint のバージョンに依存します。たとえば PowerPoint 2013 では効果が二重に適用されますが、PowerPoint 2007 では OuterShadow が適用されます。

### **テキストへのディスプレイ効果の適用**

次の Java サンプルコードでテキストにディスプレイ効果を追加します。

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

### **テキストへの光彩効果の適用**

次のコードでテキストに光彩効果を適用し、光らせたり目立たせたりします。

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
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

影、ディスプレイ、光彩のパラメータは個々のテキスト部分ごとに別々に設定できます。 

{{% /alert %}} 

### **WordArt の変形の使用**

次のコードでテキスト全体に適用される Transform プロパティを使用します:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

Microsoft PowerPoint と Aspose.Slides for Java の両方が、あらかじめ定義された変形タイプをいくつか提供しています。 

{{% /alert %}} 

**Using PowerPoint**

定義済みの変形タイプにアクセスするには、**Format** → **TextEffect** → **Transform** を選択します。

**Using Aspose.Slides**

変形タイプを選択するには、TextShapeType 列挙体を使用します。

### **テキストとシェイプへの 3D エフェクトの適用**

次のサンプルコードでテキストシェイプに 3D エフェクトを設定します。

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

次の Java コードでテキストに 3D エフェクトを適用します。

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
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

テキストやシェイプへの 3D エフェクトの適用とエフェクト同士の相互作用は、特定のルールに基づいています。テキストとそのテキストを含むシェイプをシーンとして考えてください。3D エフェクトは 3D オブジェクト表現と、オブジェクトが配置されるシーンを含みます。

- シーンが図形とテキストの両方に設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。
- 図形に独自のシーンがないが 3D 表現がある場合、テキストのシーンが使用されます。
- それ以外の場合、シェイプに元々 3D エフェクトが無いときはシェイプは平面になり、3D エフェクトはテキストのみに適用されます。

これらの記述は ThreeDFormat.getLightRig() および ThreeDFormat.getCamera() メソッドに関連しています。

{{% /alert %}} 

## **テキストへの外側影エフェクトの適用**
Aspose.Slides for Java は、[**IOuterShadow**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ioutershadow/) および [**IInnerShadow**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iinnershadow/) クラスを提供し、[TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframe/) に含まれるテキストに影エフェクトを適用できます。以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに矩形タイプの AutoShape を追加します。
4. AutoShape に関連付けられた TextFrame にアクセスします。
5. AutoShape の FillType を NoFill に設定します。
6. OuterShadow クラスのインスタンスを作成します。
7. 影の BlurRadius を設定します。
8. 影の Direction を設定します。
9. 影の Distance を設定します。
10. RectanglelAlign を TopLeft に設定します。
11. 影の PresetColor を Black に設定します。
12. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

上記手順を実装した Java のサンプルコードは、テキストに外側影エフェクトを適用する方法を示しています。

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

## **シェイプへの内側影エフェクトの適用**
以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 矩形タイプの AutoShape を追加します。
4. InnerShadowEffect を有効にします。
5. 必要なすべてのパラメータを設定します。
6. ColorType を Scheme に設定します。
7. Scheme Color を設定します。
8. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

上記手順に基づくサンプルコードは、Java でシェイプ内のテキストに内側影エフェクトを適用する方法を示しています。

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

    // InnerShadowEffect を有効化
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

### 異なるフォントやスクリプト（例: アラビア語、中国語）で WordArt エフェクトは使用できますか？

はい、Aspose.Slides は Unicode をサポートしており、主要なフォントとスクリプトすべてで動作します。言語に関係なく、影、塗りつぶし、アウトラインなどの WordArt エフェクトを適用できますが、フォントの可用性と描画はシステムにインストールされたフォントに依存します。

### スライドマスタ要素に WordArt エフェクトを適用できますか？

はい、マスタースライド上のシェイプ（タイトルプレースホルダー、フッター、背景テキストなど）に WordArt エフェクトを適用できます。マスターのレイアウトを変更すると、関連付けられたすべてのスライドに反映されます。

### WordArt エフェクトはプレゼンテーションファイルのサイズに影響しますか？

わずかに影響します。影、光彩、グラデーション塗りつぶしなどのエフェクトは、追加の書式メタデータによりファイルサイズが若干増加しますが、差は通常は無視できる程度です。

### プレゼンテーションを保存せずに WordArt エフェクトの結果をプレビューできますか？

はい、[IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) または [ISlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/) インターフェイスの `getImage` メソッドを使用して、WordArt を含むスライドを画像（PNG、JPEG など）にレンダリングできます。これにより、保存やエクスポート前にメモリ上または画面上で結果をプレビューできます。