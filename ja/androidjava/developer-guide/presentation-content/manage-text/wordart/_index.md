---
title: ワードアート
type: docs
weight: 110
url: /androidjava/wordart/
---


## **ワードアートとは？**
ワードアートは、テキストに効果を適用して目立たせる機能です。例えば、ワードアートを使うと、テキストにアウトラインを付けたり、色（またはグラデーション）で塗りつぶしたり、3D効果を追加したりできます。また、テキストの形を傾けたり、曲げたり、伸ばしたりすることもできます。

{{% alert color="primary" %}} 

ワードアートを使用すると、テキストをグラフィカルなオブジェクトのように扱うことができます。一般的に、ワードアートは、テキストをより魅力的または目立たせるために加えられた効果や特別な修正で構成されています。

{{% /alert %}} 

**Microsoft PowerPointにおけるワードアート**

Microsoft PowerPointでワードアートを使用するには、予め定義されたワードアートテンプレートの1つを選択する必要があります。ワードアートテンプレートは、テキストまたはその形に適用される効果のセットです。

**Aspose.Slidesにおけるワードアート**

Aspose.Slides for Android via Java 20.10では、ワードアートのサポートを実装し、その後のAspose.Slides for Android via Javaのリリースで機能を改善しました。

Aspose.Slides for Android via Javaを使用すると、自分のワードアートテンプレート（効果または効果の組み合わせ）をJavaで簡単に作成し、テキストに適用できます。

## シンプルなワードアートテンプレートを作成し、テキストに適用する

**Aspose.Slidesを使用する** 

まず、このJavaコードを使ってシンプルなテキストを作成します：

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
次に、テキストのフォントの高さを大きい値に設定して、このコードを使って効果をより目立たせます：

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Microsoft PowerPointを使用する**

Microsoft PowerPointでワードアート効果メニューに移動します：

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから、予め定義されたワードアート効果を選択できます。また、左側のメニューから新しいワードアートの設定を指定できます。

使用可能なパラメータやオプションの一部は以下の通りです：

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slidesを使用する**

ここでは、テキストに[SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid)パターンカラーを適用し、このコードを使って1幅の黒いテキストボーダーを追加します：

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

## 他のワードアート効果を適用する

**Microsoft PowerPointを使用する**

プログラムのインターフェースから、テキスト、テキストブロック、形、または類似した要素にこれらの効果を適用できます：

![todo:image_alt_text](image-20200930114129-5.png)

例えば、影、反射、発光効果はテキストに適用でき、3Dフォーマットや3D回転効果はテキストブロックに適用できます。ソフトエッジプロパティはシェイプオブジェクトに適用可能です（3Dフォーマットプロパティが設定されていないときでも効果があります）。

### 影効果の適用

ここでは、テキストに関連するプロパティを設定することを目的としています。このJavaコードを使用してテキストに影効果を適用します：

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

Aspose.Slides APIは、3種類の影をサポートしています：OuterShadow、InnerShadow、PresetShadow。

PresetShadowを利用すると、テキストに対して影を適用できます（プリセット値を使用）。

**Microsoft PowerPointを使用する**

PowerPointでは、1種類の影を使用できます。以下はその例です：

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slidesを使用する**

Aspose.Slidesでは、実際に2種類の影を同時に適用できます：InnerShadowとPresetShadow。

**注意事項：**

- OuterShadowとPresetShadowを一緒に使用した場合、OuterShadow効果のみが適用されます。 
- OuterShadowとInnerShadowが同時に使用された場合、結果または適用された効果はPowerPointのバージョンによります。例えば、PowerPoint 2013では効果が2重に現れますが、PowerPoint 2007ではOuterShadow効果が適用されます。 

### テキストへのディスプレイの適用

このJavaコードサンプルを通じてテキストにディスプレイを追加します：

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

### テキストへの発光効果の適用

このコードを使用して、テキストに発光効果を適用します：

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

操作の結果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

影、ディスプレイ、発光のパラメータを変更できます。効果のプロパティは、テキストの各部分に対して個別に設定されます。 

{{% /alert %}} 

### ワードアートにおける変形の使用

次のコードを通じて、Transformプロパティ（テキスト全体で固有）を使用します：
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

結果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPointとAspose.Slides for Android via Javaの両方は、特定の数の予め定義された変形タイプを提供します。

{{% /alert %}} 

**PowerPointを使用する**

予め定義された変形タイプにアクセスするには、**フォーマット** -> **テキスト効果** -> **変形**を通じて行います。

**Aspose.Slidesを使用する**

変形タイプを選択するには、TextShapeType列挙型を使用します。 

### テキストとシェイプへの3D効果の適用

次のサンプルコードを使ってテキストシェイプに3D効果を設定します：

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

結果のテキストとその形：

![todo:image_alt_text](image-20200930114816-9.png)

テキストに3D効果を適用するために次のJavaコードを使用します：

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

操作の結果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

テキストやその形への3D効果の適用と効果同士の相互作用は、特定のルールに基づいています。

テキストとそのテキストを含む形のシーンを考えてみましょう。3D効果は3Dオブジェクトの表現とそのオブジェクトが配置されたシーンを含みます。

- 形とテキストの両方にシーンが設定されている場合、形のシーンが優先され、テキストのシーンは無視されます。 
- 形が自身のシーンを持たず、3D表現しか持たない場合、テキストのシーンが使用されます。 
- それ以外の場合—形が元々3D効果を持っていない場合—形は平面で、3D効果はテキストに対してのみ適用されます。 

これらの説明は、ThreeDFormat.getLightRig()とThreeDFormat.getCamera()メソッドに関連しています。

{{% /alert %}} 

## **テキストへの外部影効果を適用する**
Aspose.Slides for Android via Javaは、[**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IOuterShadow)および[**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IInnerShadow)クラスを提供しており、[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame)によって運ばれるテキストに影効果を適用できます。次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに長方形型のAutoShapeを追加します。
4. AutoShapeに関連付けられたTextFrameにアクセスします。
5. AutoShapeのFillTypeをNoFillに設定します。
6. OuterShadowクラスをインスタンス化します。
7. 影のBlurRadiusを設定します。
8. 影のDirectionを設定します。
9. 影のDistanceを設定します。
10. RectanglelAlignをTopLeftに設定します。
11. 影のPresetColorをBlackに設定します。
12. プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして書き込みます。

次のJavaコードは、上記の手順の実装で、テキストに外部影効果を適用する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    // Get reference of the slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Add TextFrame to the Rectangle
    ashp.addTextFrame("Aspose TextBox");

    // Disable shape fill in case we want to get shadow of text
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Add outer shadow and set all necessary parameters
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Write the presentation to disk
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Shapesへの内部影効果を適用する**
次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 長方形型のAutoShapeを追加します。
4. InnerShadowEffectを有効にします。
5. すべての必須パラメータを設定します。
6. ColorTypeをSchemeに設定します。
7. スキームの色を設定します。
8. プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして書き込みます。

次のサンプルコード（上記の手順に基づく）は、Javaで2つの形の間にコネクタを追加する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    // Get reference of the slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Add TextFrame to the Rectangle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Enable InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Set all necessary parameters
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Set ColorType as Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Set Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Save Presentation
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```