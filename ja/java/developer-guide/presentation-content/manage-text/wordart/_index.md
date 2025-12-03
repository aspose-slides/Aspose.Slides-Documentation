---
title: JavaでWordArt効果を作成および適用
linktitle: WordArt
type: docs
weight: 110
url: /ja/java/wordart/
keywords:
- WordArt
- WordArt作成
- WordArtテンプレート
- WordArt効果
- 影効果
- 表示効果
- グロー効果
- WordArt変形
- 3D効果
- 外部影効果
- 内部影効果
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for JavaでWordArt効果を作成およびカスタマイズします。このステップバイステップガイドは、開発者がJavaでプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---

## **WordArt とは？**
WordArt（または Word Art）は、テキストにエフェクトを適用して目立たせる機能です。たとえば、テキストに輪郭を付けたり、色（またはグラデーション）で塗りつぶしたり、3D エフェクトを追加したりできます。テキストの形状を斜めにしたり、曲げたり、伸縮させることもできます。

{{% alert color="primary" %}} 
WordArt は、テキストをグラフィック オブジェクトのように扱うことができます。一般に、WordArt はテキストをより魅力的または目立たせるために行うエフェクトや特別な修飾の集合です。 
{{% /alert %}} 

**Microsoft PowerPoint の WordArt**

Microsoft PowerPoint で WordArt を使用するには、事前定義された WordArt テンプレートのいずれかを選択する必要があります。WordArt テンプレートは、テキストまたはその形状に適用されるエフェクトのセットです。

**Aspose.Slides の WordArt**

Aspose.Slides for Java 20.10 では WordArt のサポートを実装し、以降の Aspose.Slides for Java リリースで機能を改良しています。

Aspose.Slides for Java を使用すれば、Java で独自の WordArt テンプレート（単一エフェクトまたはエフェクトの組み合わせ）を簡単に作成し、テキストに適用できます。

## **シンプルな WordArt テンプレートを作成し、テキストに適用する**

**Aspose.Slides を使用する** 

最初に、次の Java コードでシンプルなテキストを作成します。 
``` java
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

次に、エフェクトをより目立たせるためにテキストのフォント高さを大きな値に設定します。 
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Microsoft PowerPoint を使用する**

Microsoft PowerPoint の WordArt エフェクト メニューに移動します:

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから事前定義された WordArt エフェクトを選択できます。左側のメニューから新しい WordArt の設定を指定できます。

利用可能なパラメータやオプションの一部は次のとおりです:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides を使用する**

ここでは、テキストに [SmallGrid](https://reference.aspose.com/slides/java/com.aspose.slides/PatternStyle#SmallGrid) パターンカラーを適用し、幅 1 の黒いテキスト枠線を追加するコードを示します:
``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```


結果のテキスト:

![todo:image_alt_text](image-20200930114108-4.png)

## **他の WordArt エフェクトを適用する**

**Microsoft PowerPoint を使用する**

プログラムのインターフェイスから、テキスト、テキスト ブロック、シェイプ、または同様の要素に次のエフェクトを適用できます:

![todo:image_alt_text](image-20200930114129-5.png)

たとえば、Shadow、Reflection、Glow エフェクトはテキストに、3D Format と 3D Rotation エフェクトはテキスト ブロックに、Soft Edges プロパティはシェイプ オブジェクトに（3D Format プロパティが設定されていなくても効果があります）適用できます。

### **Shadow エフェクトを適用する**

ここではテキストにのみ関連するプロパティを設定します。次の Java コードでテキストに影効果を適用します:
``` java
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
```


Aspose.Slides API は、OuterShadow、InnerShadow、PresetShadow の 3 種類の影をサポートしています。

PresetShadow を使用すると、プリセット値でテキストに影を適用できます。

**Microsoft PowerPoint を使用する**

PowerPoint では 1 種類の影しか使用できません。例は次のとおりです:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides を使用する**

Aspose.Slides では、InnerShadow と PresetShadow の 2 種類の影を同時に適用できます。

**注意点:**

- OuterShadow と PresetShadow を同時に使用すると、OuterShadow のみが適用されます。 
- OuterShadow と InnerShadow を同時に使用した場合、適用される効果は PowerPoint のバージョンに依存します。たとえば PowerPoint 2013 では効果が二重になり、PowerPoint 2007 では OuterShadow が適用されます。

### **テキストにディスプレイ効果を適用する**

次の Java サンプルコードでテキストにディスプレイ効果を追加します:
``` java
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
```


### **テキストに Glow 効果を適用する**

次のコードでテキストに Glow 効果を適用し、光らせます:
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


操作結果:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
影、ディスプレイ、Glow のパラメータはそれぞれのテキスト部分ごとに個別に設定できます。 
{{% /alert %}} 

### **WordArt で変形を使用する**

次のコードでテキスト全体に適用される Transform プロパティを使用します:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


結果:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint と Aspose.Slides for Java の両方で、事前定義された変形タイプが一定数提供されています。 
{{% /alert %}} 

**PowerPoint を使用する**

事前定義された変形タイプにアクセスするには、**Format** → **TextEffect** → **Transform** の順に辿ります。

**Aspose.Slides を使用する**

変形タイプを選択するには、TextShapeType 列挙型を使用します。

### **テキストとシェイプに 3D エフェクトを適用する**

次のサンプルコードでテキスト シェイプに 3D エフェクトを設定します:
``` java
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
```


結果のテキストとシェイプ:

![todo:image_alt_text](image-20200930114816-9.png)

次の Java コードでテキストに 3D エフェクトを適用します:
``` java
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
```


操作結果:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
テキストやシェイプへの 3D エフェクトの適用とエフェクト間の相互作用は、一定の規則に基づきます。 

テキストとそのシェイプを含むシーンを考慮します。3D エフェクトは、オブジェクトの 3D 表現とそのオブジェクトが配置されたシーンを含みます。

- 図とテキストの両方にシーンが設定されている場合、図のシーンが優先され、テキストのシーンは無視されます。 
- 図に独自のシーンがなく 3D 表現だけがある場合、テキストのシーンが使用されます。 
- それ以外の場合—シェイプ自体に 3D エフェクトが無い場合—シェイプは平面のままで、3D エフェクトはテキストのみに適用されます。 

これらの説明は ThreeDFormat.getLightRig() と ThreeDFormat.getCamera() メソッドに結び付いています。 
{{% /alert %}} 

## **テキストに外部影効果を適用する**
Aspose.Slides for Java は、[**IOuterShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IOuterShadow) および [**IInnerShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IInnerShadow) クラスを提供し、[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) に付随するテキストに影効果を適用できます。以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
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

上記手順を実装した Java のサンプルコードは、テキストに外部影効果を適用する方法を示しています:
```java
Presentation pres = new Presentation();
try {
    // スライドの参照を取得します
    ISlide sld = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加します
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 矩形に TextFrame を追加します
    ashp.addTextFrame("Aspose TextBox");

    // テキストの影を取得したい場合に備えてシェイプの塗りつぶしを無効にします
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 外側の影を追加し、必要なすべてのパラメータを設定します
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //プレゼンテーションをディスクに保存します
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプに内部影効果を適用する**
以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. スライドの参照を取得します。  
3. 矩形タイプの AutoShape を追加します。  
4. InnerShadowEffect を有効にします。  
5. 必要なすべてのパラメータを設定します。  
6. ColorType を Scheme に設定します。  
7. Scheme Color を設定します。  
8. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。  

上記手順に基づくサンプルコードは、Java で 2 つのシェイプ間にコネクタを追加する方法を示しています:
```java
Presentation pres = new Presentation();
try {
    // スライドの参照を取得します
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加します
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 矩形に TextFrame を追加します
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // InnerShadowEffect を有効にします
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // 必要なすべてのパラメータを設定します
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ColorType を Scheme に設定します
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme カラーを設定します
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // プレゼンテーションを保存します
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**さまざまなフォントやスクリプト（例：アラビア語、中文）でも WordArt エフェクトは使用できますか？**

はい、Aspose.Slides は Unicode をサポートし、主要なフォントとスクリプトすべてで動作します。影、塗りつぶし、輪郭などの WordArt エフェクトは言語に関係なく適用できますが、フォントの利用可能性と描画はシステム フォントに依存する場合があります。

**スライド マスターの要素にも WordArt エフェクトを適用できますか？**

はい、マスタースライド上のシェイプ（タイトル プレースホルダー、フッター、背景テキストなど）に WordArt エフェクトを適用できます。マスターレイアウトに対する変更は、関連付けられたすべてのスライドに反映されます。

**WordArt エフェクトはプレゼンテーション ファイルのサイズに影響しますか？**

若干影響します。影、Glow、グラデーション塗りつぶしなどのエフェクトは、追加の書式設定メタデータによりファイルサイズをわずかに増加させますが、差は通常は無視できる程度です。

**プレゼンテーションを保存せずに WordArt エフェクトの結果をプレビューできますか？**

はい、`getImage` メソッドを使用して、[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) または [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) インターフェイスから WordArt を含むスライドを画像（PNG、JPEG など）としてレンダリングできます。これにより、保存やエクスポートを行う前にメモリ上または画面上で結果をプレビューできます。