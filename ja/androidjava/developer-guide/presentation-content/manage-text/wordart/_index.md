---
title: AndroidでWordArt効果を作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/androidjava/wordart/
keywords:
- WordArt
- WordArtの作成
- WordArtテンプレート
- WordArt効果
- 影効果
- 表示効果
- 発光効果
- WordArt変形
- 3D効果
- 外側影効果
- 内側影効果
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for AndroidでWordArt効果を作成・カスタマイズします。このステップバイステップガイドは、開発者がJavaでプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---

## **WordArt について**
WordArt または Word Art は、テキストにエフェクトを適用して目立たせる機能です。たとえば WordArt を使用すると、テキストに輪郭を付けたり、色（またはグラデーション）で塗りつぶしたり、3D エフェクトを追加したりできます。また、テキストの形状を斜めにしたり、曲げたり、伸ばしたりすることもできます。 

{{% alert color="primary" %}} 
WordArt はテキストをグラフィック オブジェクトのように操作できます。一般的に、WordArt はテキストをより魅力的または目立たせるために加えるエフェクトや特別な修飾から構成されています。 
{{% /alert %}} 

**Microsoft PowerPoint における WordArt**

Microsoft PowerPoint で WordArt を使用するには、定義済みの WordArt テンプレートのいずれかを選択する必要があります。WordArt テンプレートは、テキストまたはその形状に適用されるエフェクトのセットです。 

**Aspose.Slides における WordArt**

Aspose.Slides for Android via Java 20.10 では WordArt のサポートを実装し、その後の Aspose.Slides for Android via Java のリリースで機能を改善しました。  
Aspose.Slides for Android via Java を使用すると、Java で独自の WordArt テンプレート（単一のエフェクトまたはエフェクトの組み合わせ）を簡単に作成し、テキストに適用できます。 

## **シンプルな WordArt テンプレートを作成しテキストに適用する**

**Aspose.Slides の使用** 

まず、次の Java コードを使用してシンプルなテキストを作成します: 
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

次に、エフェクトをより目立たせるために、テキストのフォント高さを大きな値に設定します。このコードを使用します: 
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Microsoft PowerPoint の使用**

Microsoft PowerPoint の WordArt エフェクト メニューを開きます: 

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから定義済みの WordArt エフェクトを選択できます。左側のメニューから新しい WordArt の設定を指定できます。  

以下は利用可能なパラメータまたはオプションの一部です: 

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides の使用**

ここでは、テキストに [SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid) パターンカラーを適用し、幅 1 の黒いテキスト枠線を次のコードで追加します: 
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

## **他の WordArt エフェクトの適用**

**Microsoft PowerPoint の使用**

プログラムのインターフェイスから、テキスト、テキスト ブロック、図形、または類似の要素にこれらのエフェクトを適用できます: 

![todo:image_alt_text](image-20200930114129-5.png)

たとえば、影、反射、そして発光エフェクトはテキストに適用できます。3D 書式や 3D 回転エフェクトはテキスト ブロックに適用できます。ソフト エッジ プロパティは図形オブジェクトに適用でき（3D 書式プロパティが設定されていなくても効果があります）。 

### **影エフェクトの適用**

ここでは、テキストに関連するプロパティのみを設定することを意図しています。Java で次のコードを使用してテキストに影エフェクトを適用します: 
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
PresetShadow を使用すると、事前設定された値でテキストに影を適用できます。 

**Microsoft PowerPoint の使用**

PowerPoint では、1 種類の影のみを使用できます。以下は例です: 

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides の使用**

Aspose.Slides では、実際に InnerShadow と PresetShadow の 2 種類の影を同時に適用できます。 

**Notes:**
- OuterShadow と PresetShadow を同時に使用すると、OuterShadow のエフェクトのみが適用されます。 
- OuterShadow と InnerShadow を同時に使用した場合、適用されるエフェクトは PowerPoint のバージョンに依存します。たとえば、PowerPoint 2013 ではエフェクトが二重になりますが、PowerPoint 2007 では OuterShadow のエフェクトが適用されます。 

### **テキストへの反射エフェクトの適用**

この Java サンプルコードでテキストに反射効果を追加します: 
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


### **テキストへの発光エフェクトの適用**

このコードを使用してテキストに発光エフェクトを適用し、光らせたり目立たせたりします: 
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


操作の結果: 

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
影、反射、発光の各パラメータは変更可能です。エフェクトのプロパティはテキストの各部分に個別に設定されます。 
{{% /alert %}} 

### **WordArt の変形の使用**

このコードで Transform プロパティ（テキスト全体に固有）を使用します: 
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


結果: 

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint と Aspose.Slides for Android via Java の両方が、いくつかの定義済み変形タイプを提供しています。 
{{% /alert %}} 

**PowerPoint の使用**

定義済みの変形タイプにアクセスするには、**書式** -> **テキスト効果** -> **変形** の順に進みます。 

**Aspose.Slides の使用**

変形タイプを選択するには、TextShapeType 列挙体を使用します。 

### **テキストと図形への 3D エフェクトの適用**

このサンプルコードでテキスト形状に 3D エフェクトを設定します: 
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


結果のテキストとその形状: 

![todo:image_alt_text](image-20200930114816-9.png)

この Java コードでテキストに 3D エフェクトを適用します: 
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


操作の結果: 

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
テキストやその形状への 3D エフェクトの適用およびエフェクト間の相互作用は、一定のルールに基づいています。  
テキストと、そのテキストを含む形状のシーンを考えてみてください。3D エフェクトは、3D オブジェクトの表現とオブジェクトが配置されるシーンを含みます。  
- 図形とテキストの両方にシーンが設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。  
- 図形に独自のシーンがなく 3D 表現がある場合、テキストのシーンが使用されます。  
- それ以外の場合、つまり形状に元々 3D エフェクトがない場合、形状は平面で、3D エフェクトはテキストのみに適用されます。  
これらの説明は ThreeDFormat.getLightRig() および ThreeDFormat.getCamera() メソッドに関連しています。 
{{% /alert %}} 

## **テキストへの外側影エフェクトの適用**
Aspose.Slides for Android via Java は、[**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IOuterShadow) と [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IInnerShadow) クラスを提供し、[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) に含まれるテキストに影エフェクトを適用できます。以下の手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに矩形タイプの AutoShape を追加します。  
4. AutoShape に関連付けられた TextFrame にアクセスします。  
5. AutoShape の FillType を NoFill に設定します。  
6. OuterShadow クラスのインスタンスを作成します。  
7. 影の BlurRadius を設定します。  
8. 影の方向 (Direction) を設定します。  
9. 影の距離 (Distance) を設定します。  
10. RectanglelAlign を TopLeft に設定します。  
11. 影の PresetColor を Black に設定します。  
12. プレゼンテーションを書き出して [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルに保存します。  

上記手順の実装例である以下の Java サンプルコードは、テキストに外側影エフェクトを適用する方法を示します: 
```java
Presentation pres = new Presentation();
try {
    // スライドの参照を取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加する
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 矩形に TextFrame を追加する
    ashp.addTextFrame("Aspose TextBox");

    // テキストの影を取得したい場合に備えて、シェイプの塗りつぶしを無効にする
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 外側の影を追加し、必要なすべてのパラメータを設定する
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // プレゼンテーションをディスクに保存する
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **図形への内側影エフェクトの適用**
以下の手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. スライドの参照を取得します。  
3. 矩形タイプの AutoShape を追加します。  
4. InnerShadowEffect を有効にします。  
5. 必要なパラメータをすべて設定します。  
6. ColorType を Scheme に設定します。  
7. Scheme Color を設定します。  
8. プレゼンテーションを書き出して [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルに保存します。  

以下のサンプルコード（上記手順に基づく）は、Java で 2 つの図形間にコネクタを追加する方法を示します: 
```java
Presentation pres = new Presentation();
try {
    // スライドの参照を取得する
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加する
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 矩形に TextFrame を追加する
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // InnerShadowEffect を有効にする
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // 必要なすべてのパラメータを設定する
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ColorType を Scheme に設定する
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme カラーを設定する
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // プレゼンテーションを保存する
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**異なるフォントやスクリプト（例：アラビア語、中国語）で WordArt エフェクトを使用できますか？**  
はい、Aspose.Slides は Unicode をサポートしており、主要なフォントおよびスクリプトすべてで動作します。影、塗りつぶし、輪郭などの WordArt エフェクトは言語に関係なく適用できますが、フォントの可用性や描画はシステムフォントに依存する場合があります。  

**スライドマスター要素に WordArt エフェクトを適用できますか？**  
はい、マスタースライド上の図形（タイトルプレースホルダー、フッター、背景テキストなど）にも WordArt エフェクトを適用できます。マスターのレイアウトを変更すると、関連付けられたすべてのスライドに反映されます。  

**WordArt エフェクトはプレゼンテーションのファイルサイズに影響しますか？**  
わずかに影響します。影や発光、グラデーション塗りつぶしなどのエフェクトは、追加の書式メタデータを伴うためファイルサイズが若干増加しますが、差は通常は無視できる程度です。  

**プレゼンテーションを保存せずに WordArt エフェクトの結果をプレビューできますか？**  
はい、[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) または [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) インターフェイスの `getImage` メソッドを使用して、WordArt を含むスライドを画像（PNG、JPEG など）としてレンダリングできます。これにより、プレゼンテーション全体を保存またはエクスポートする前に、メモリ内または画面上で結果をプレビューできます。