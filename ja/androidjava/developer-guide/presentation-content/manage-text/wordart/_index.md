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
- 発光効果
- WordArt 変形
- 3D 効果
- 外側影効果
- 内側影効果
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android で WordArt 効果を作成およびカスタマイズします。このステップバイステップ ガイドは、開発者が Java でプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---

## **WordArt について**
WordArt（または Word Art）は、テキストにさまざまな効果を適用して目立たせる機能です。たとえば、テキストの輪郭を描いたり、色（またはグラデーション）で塗りつぶしたり、3D 効果を付与したりできます。また、テキストの形状を傾けたり、曲げたり、伸ばしたりすることもできます。

{{% alert color="primary" %}} 
WordArt は、テキストをグラフィック オブジェクトのように取り扱うことができます。一般に、WordArt はテキストをより魅力的または目立たせるために加えられる効果や特殊な変更の集合です。 
{{% /alert %}} 

**Microsoft PowerPoint の WordArt**

Microsoft PowerPoint で WordArt を使用するには、事前定義された WordArt テンプレートのいずれかを選択する必要があります。WordArt テンプレートは、テキストまたはその形状に適用される一連の効果です。

**Aspose.Slides の WordArt**

Aspose.Slides for Android via Java 20.10 以降、WordArt のサポートを実装し、以降のリリースで機能を改善しました。

Aspose.Slides for Android via Java を使用すると、Java で独自の WordArt テンプレート（単一の効果または効果の組み合わせ）を簡単に作成し、テキストに適用できます。

## **シンプルな WordArt テンプレートを作成してテキストに適用する**

**Aspose.Slides を使用する** 

まず、次の Java コードでシンプルなテキストを作成します。 
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

次に、以下のコードでテキストのフォントサイズを大きく設定し、効果を目立たせます。 
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Microsoft PowerPoint を使用する**

Microsoft PowerPoint の WordArt 効果メニューを開きます：

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから事前定義された WordArt 効果を選択できます。左側のメニューから新しい WordArt の設定を指定できます。

利用可能なパラメータやオプションの例：

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides を使用する**

ここでは、テキストに [SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid) パターンカラーを適用し、幅 1 の黒いテキスト枠線を次のコードで追加します。 
``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```


結果のテキスト：

![todo:image_alt_text](image-20200930114108-4.png)

## **他の WordArt 効果を適用する**

**Microsoft PowerPoint を使用する**

プログラムのインターフェイスから、テキスト、テキスト ブロック、シェイプ、または類似の要素にこれらの効果を適用できます：

![todo:image_alt_text](image-20200930114129-5.png)

たとえば、影、反射、発光の効果はテキストに適用でき、3D 書式や 3D 回転の効果はテキスト ブロックに適用できます。ソフト エッジ プロパティはシェイプ オブジェクトに適用でき（3D 書式プロパティが設定されていなくても効果があります）、…

### **影の効果を適用する**

ここではテキストのみのプロパティを設定します。次の Java コードでテキストに影効果を適用します。 
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

PowerPoint では 1 種類の影のみ使用できます。例を示します：

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides を使用する**

Aspose.Slides では、InnerShadow と PresetShadow の 2 種類の影を同時に適用できます。

**注意点：**

- OuterShadow と PresetShadow を同時に使用すると、OuterShadow の効果だけが適用されます。  
- OuterShadow と InnerShadow を同時に使用した場合、適用される効果は PowerPoint のバージョンによって異なります。たとえば PowerPoint 2013 では効果が重複して適用されますが、PowerPoint 2007 では OuterShadow のみが適用されます。

### **テキストに反射効果を適用する**

次の Java サンプルでテキストに反射を追加します： 
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


### **テキストに発光効果を適用する**

次のコードでテキストに発光効果を適用し、光沢を出します： 
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


操作結果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
影、表示、発光の各パラメーターは、テキストの各部分ごとに個別に設定できます。 
{{% /alert %}} 

### **WordArt で変形を使用する**

次のコードでテキスト全体に対して Transform プロパティを使用します： 
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


結果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint と Aspose.Slides for Android via Java の両方で、事前定義された変形タイプがいくつか提供されています。 
{{% /alert %}} 

**PowerPoint を使用する**

事前定義された変形タイプにアクセスするには、**書式** → **テキスト効果** → **変形** の順に選択します。

**Aspose.Slides を使用する**

変形タイプは TextShapeType 列挙体で選択します。

### **テキストとシェイプに 3D 効果を適用する**

次のサンプルコードでテキスト シェイプに 3D 効果を設定します： 
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


結果のテキストとシェイプ：

![todo:image_alt_text](image-20200930114816-9.png)

次の Java コードでテキストに 3D 効果を適用します： 
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


操作結果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
テキストまたはシェイプへの 3D 効果の適用および効果間の相互作用には、特定のルールがあります。  

テキストとそれを含むシェイプのシーンを考慮します。3D 効果は 3D オブジェクトの表現と、そのオブジェクトが配置されるシーンを含みます。  

- シーンが図形とテキストの両方に設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。  
- 図形に独自のシーンがなく 3D 表現がある場合は、テキストのシーンが使用されます。  
- それ以外の場合（図形自体に 3D 効果がない場合）は、図形は平面のままで、3D 効果はテキストにのみ適用されます。  

これらの説明は `ThreeDFormat.getLightRig()` および `ThreeDFormat.getCamera()` メソッドに関連しています。 
{{% /alert %}} 

## **テキストに外側影効果を適用する**
Aspose.Slides for Android via Java は、[**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IOuterShadow) と [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IInnerShadow) クラスを提供し、[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) に含まれるテキストに影効果を適用できます。手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
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

上記手順の実装例である次の Java サンプルは、テキストに外側影効果を適用する方法を示しています： 
```java
Presentation pres = new Presentation();
try {
    // スライドの参照を取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 矩形に TextFrame を追加
    ashp.addTextFrame("Aspose TextBox");

    // テキストの影を取得したい場合に備えてシェイプの塗りを無効化
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 外側の影を追加し、すべての必要なパラメータを設定
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //プレゼンテーションをディスクに保存
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプに内側影効果を適用する**
手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. スライドの参照を取得します。  
3. 矩形タイプの AutoShape を追加します。  
4. InnerShadowEffect を有効にします。  
5. 必要なすべてのパラメーターを設定します。  
6. ColorType を Scheme に設定します。  
7. Scheme Color を設定します。  
8. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

上記手順に基づくサンプルコードは、Java で 2 つのシェイプ間にコネクタを追加する方法を示しています： 
```java
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

    // InnerShadowEffect を有効にする
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // 必要なすべてのパラメータを設定
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ColorType を Scheme に設定
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme カラーを設定
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // プレゼンテーションを保存
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**さまざまなフォントやスクリプト（例：アラビア語、中国語）で WordArt 効果を使用できますか？**

はい、Aspose.Slides は Unicode をサポートし、主要なフォントとスクリプトすべてで動作します。影、塗り、輪郭などの WordArt 効果は言語に関係なく適用できますが、フォントの可用性や描画はシステムのフォントに依存する場合があります。

**スライド マスターの要素に WordArt 効果を適用できますか？**

はい、マスタースライド上のシェイプ（タイトル プレースホルダー、フッター、背景テキストなど）に WordArt 効果を適用できます。マスター レイアウトに加えた変更は、関連付けられたすべてのスライドに反映されます。

**WordArt 効果はプレゼンテーション ファイルのサイズに影響しますか？**

わずかに影響します。影、発光、グラデーション塗りなどの効果は、追加の書式メタデータによりファイルサイズを若干増加させますが、差は通常は無視できる程度です。

**プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？**

はい、[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) または [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) インターフェイスの `getImage` メソッドを使用して、WordArt を含むスライドを画像（PNG、JPEG など）としてレンダリングできます。これにより、保存やエクスポート前にインメモリまたは画面上で結果をプレビューできます。