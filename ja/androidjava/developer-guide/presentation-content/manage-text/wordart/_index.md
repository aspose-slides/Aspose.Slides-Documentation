---
title: Android で WordArt 効果を作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/androidjava/wordart/
keywords:
- WordArt
- WordArt の作成
- WordArt テンプレート
- WordArt 効果
- 影効果
- 表示効果
- 発光効果
- WordArt 変形
- 3D 効果
- 外部影効果
- 内部影効果
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android で WordArt 効果を作成およびカスタマイズします。このステップバイステップガイドは、開発者が Java でプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---

## **WordArt とは？**
WordArtまたはWord Artは、テキストに効果を適用して目立たせる機能です。WordArtを使えば、テキストの輪郭を付けたり、色（またはグラデーション）で塗りつぶしたり、3D効果を付与したりできます。また、テキストの形状を傾け、曲げ、伸ばすこともできます。 

{{% alert color="primary" %}} 
WordArtはテキストをグラフィックオブジェクトのように扱うことができます。一般的に、WordArtはテキストをより魅力的または目立たせるために加える効果や特別な修飾の集合です。 
{{% /alert %}} 

**Microsoft PowerPoint の WordArt**  
Microsoft PowerPoint で WordArt を使用するには、あらかじめ定義された WordArt テンプレートのいずれかを選択する必要があります。WordArt テンプレートとは、テキストまたはその形状に適用される効果のセットです。 

**Aspose.Slides の WordArt**  
Aspose.Slides for Android via Java 20.10 で WordArt のサポートを実装し、以降の Aspose.Slides for Android via Java リリースで機能を改善しました。  
Aspose.Slides for Android via Java を使用すれば、Java で独自の WordArt テンプレート（単一の効果または複数効果の組み合わせ）を簡単に作成し、テキストに適用できます。

## **シンプルな WordArt テンプレートを作成しテキストに適用する**

**Aspose.Slides の使用**  
まず、以下の Java コードでシンプルなテキストを作成します。  
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
  
次に、以下のコードでテキストのフォント高さを大きく設定し、効果を目立たせます。  
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**Microsoft PowerPoint の使用**  
Microsoft PowerPoint の WordArt 効果メニューを開きます：  

![todo:image_alt_text](image-20200930113926-1.png)  

右側のメニューから事前定義された WordArt 効果を選択できます。左側のメニューで新しい WordArt の設定を指定できます。  

以下は利用可能なパラメータまたはオプションの一部です：  

![todo:image_alt_text](image-20200930114015-3.png)  

**Aspose.Slides の使用**  
ここでは、テキストに [SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid) パターン色を適用し、以下のコードで幅 1 の黒いテキスト枠線を追加します。  
``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```
  

結果のテキストは次のとおりです。  

![todo:image_alt_text](image-20200930114108-4.png)  

## **他の WordArt 効果の適用**

**Microsoft PowerPoint の使用**  
プログラムのインターフェイスから、テキスト、テキストブロック、図形、または同様の要素にこれらの効果を適用できます。  

![todo:image_alt_text](image-20200930114129-5.png)  

例えば、影、反射、発光効果はテキストに適用でき、3D 書式や 3D 回転効果はテキストブロックに適用できます。ソフトエッジ プロパティは図形オブジェクトに適用でき（3D 書式プロパティが設定されていなくても効果があります）。  

### **影効果の適用**  
ここではテキストのみのプロパティを設定することを目的とします。以下の Java コードでテキストに影効果を適用します。  
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
PowerPoint では影の種類は 1 つだけ使用できます。例を示します。  

![todo:image_alt_text](image-20200930114225-6.png)  

**Aspose.Slides の使用**  
Aspose.Slides では実際に InnerShadow と PresetShadow の 2 種類の影を同時に適用できます。  

※  
- OuterShadow と PresetShadow を同時に使用すると、OuterShadow の効果だけが適用されます。  
- OuterShadow と InnerShadow を同時に使用した場合、適用される効果は PowerPoint のバージョンに依存します。例えば、PowerPoint 2013 では効果が二重になり、PowerPoint 2007 では OuterShadow の効果が適用されます。  

### **テキストへの反射効果の適用**  
以下の Java サンプルコードでテキストに反射効果を追加します。  
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
  

### **テキストへの発光効果の適用**  
以下のコードでテキストに発光効果を適用し、光らせます。  
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```
  

操作の結果は次のとおりです。  

![todo:image_alt_text](image-20200930114621-7.png)  

{{% alert color="primary" %}} 
影、反射、発光のパラメータは個別に変更できます。効果のプロパティはテキストの各部分に別々に設定されます。 
{{% /alert %}} 

### **WordArt の変形の使用**  
以下のコードで Transform プロパティ（テキスト全体に適用）を使用します。  
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```
  

結果は次のとおりです。  

![todo:image_alt_text](image-20200930114712-8.png)  

{{% alert color="primary" %}} 
Microsoft PowerPoint と Aspose.Slides for Android via Java の両方が、いくつかの事前定義された変形タイプを提供しています。 
{{% /alert %}} 

**PowerPoint の使用**  
事前定義された変形タイプにアクセスするには、**Format** → **TextEffect** → **Transform** の順に進みます。  

**Aspose.Slides の使用**  
変形タイプを選択するには、TextShapeType 列挙体を使用します。  

### **テキストと図形への 3D 効果の適用**  
以下のサンプルコードでテキスト形状に 3D 効果を設定します。  
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
  

結果のテキストと形状は次のとおりです。  

![todo:image_alt_text](image-20200930114816-9.png)  

以下の Java コードでテキストに 3D 効果を適用します。  
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
  

操作の結果は次のとおりです。  

![todo:image_alt_text](image-20200930114905-10.png)  

{{% alert color="primary" %}} 
3D 効果のテキストまたはその形状への適用と、効果間の相互作用は特定の規則に基づきます。

テキストとそれを含む形状のシーンを考慮します。3D 効果は 3D オブジェクト表現とオブジェクトが配置されたシーンを含みます。

- 図形とテキストの両方にシーンが設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。  
- 図形に独自のシーンがなく 3D 表現がある場合、テキストのシーンが使用されます。  
- それ以外で、元々図形に 3D 効果がない場合は図形は平面となり、3D 効果はテキストのみに適用されます。

これらの説明は ThreeDFormat.getLightRig() と ThreeDFormat.getCamera() メソッドに関連しています。 
{{% /alert %}} 

## **テキストへの外部影効果の適用**
Aspose.Slides for Android via Java は、テキストフレーム内のテキストに影効果を適用できる [**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/) と [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinnershadow/) クラスを提供します。以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに Rectangle タイプの AutoShape を追加します。  
4. AutoShape に関連付けられた TextFrame にアクセスします。  
5. AutoShape の FillType を NoFill に設定します。  
6. OuterShadow クラスのインスタンスを作成します。  
7. 影の BlurRadius を設定します。  
8. 影の Direction を設定します。  
9. 影の Distance を設定します。  
10. RectanglelAlign を TopLeft に設定します。  
11. 影の PresetColor を Black に設定します。  
12. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。  

このコードサンプルは、外部影効果をテキストに適用する方法を示しています：  
```java
Presentation pres = new Presentation();
try {
    // スライドの参照を取得
    ISlide sld = pres.getSlides().get_Item(0);

    // Rectangle タイプの AutoShape を追加
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle に TextFrame を追加
    ashp.addTextFrame("Aspose TextBox");

    // テキストの影を取得できるように形状の塗りつぶしを無効化
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 外部影を追加し、必要なパラメータをすべて設定
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
  

## **図形への内部影効果の適用**
以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. スライドの参照を取得します。  
3. Rectangle タイプの AutoShape を追加します。  
4. InnerShadowEffect を有効にします。  
5. 必要なパラメータをすべて設定します。  
6. ColorType を Scheme に設定します。  
7. Scheme Color を設定します。  
8. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。  

このコードサンプルは、Java で 2 つの図形間にコネクタを追加する方法を示しています：  
```java
Presentation pres = new Presentation();
try {
    // スライドの参照を取得
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle タイプの AutoShape を追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Rectangle に TextFrame を追加
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // InnerShadowEffect を有効化
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // 必要なパラメータをすべて設定
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

**異なるフォントやスクリプト（例: アラビア語、中文）でも WordArt 効果を使用できますか？**  
はい、Aspose.Slides は Unicode をサポートしており、すべての主要なフォントとスクリプトで動作します。影、塗りつぶし、輪郭などの WordArt 効果は言語に関係なく適用できますが、フォントの可用性や描画はシステムフォントに依存する場合があります。

**スライドマスターの要素にも WordArt 効果を適用できますか？**  
はい、マスタースライド上の図形（タイトルプレースホルダー、フッター、背景テキストなど）に WordArt 効果を適用できます。マスターのレイアウトを変更すると、関連付けられたすべてのスライドに反映されます。

**WordArt 効果はプレゼンテーションのファイルサイズに影響しますか？**  
やや影響します。影、発光、グラデーション塗りつぶしなどの効果は、追加の書式情報がメタデータとして保存されるため、ファイルサイズがわずかに増加しますが、通常は無視できる程度です。

**プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？**  
はい、[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) または [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) インターフェイスの `getImage` メソッドを使用して、WordArt を含むスライドを画像（PNG、JPEG など）にレンダリングできます。これにより、プレゼンテーション全体を保存またはエクスポートする前に、メモリ上または画面上で結果をプレビューできます。