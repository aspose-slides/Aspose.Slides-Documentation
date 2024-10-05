---
title: WordArt
type: docs
weight: 110
url: /java/wordart/
---


## **WordArtについて**
WordArtは、テキストに効果を適用して目立たせる機能です。たとえば、WordArtを使用すると、テキストをアウトライン化したり、色（またはグラデーション）で埋めたり、3D効果を追加したりできます。また、テキストの形を傾けたり、曲げたり、引き伸ばしたりすることもできます。

{{% alert color="primary" %}} 

WordArtは、テキストをグラフィカルオブジェクトとして扱うことができます。一般的に、WordArtは、テキストをより魅力的または目立つようにするための効果や特別な変更から成り立っています。

{{% /alert %}} 

**Microsoft PowerPointにおけるWordArt**

Microsoft PowerPointでWordArtを使用するには、あらかじめ定義されたWordArtテンプレートの1つを選択する必要があります。WordArtテンプレートは、テキストまたはその形状に適用される効果のセットです。

**Aspose.SlidesにおけるWordArt**

Aspose.Slides for Java 20.10では、WordArtのサポートを実装し、その後のAspose.Slides for Javaリリースで機能を改善しました。

Aspose.Slides for Javaを使用すると、自分のWordArtテンプレート（1つの効果または効果の組み合わせ）を簡単にJavaで作成し、テキストに適用できます。

## シンプルなWordArtテンプレートを作成し、テキストに適用する

**Aspose.Slidesの使用**

まず、以下のJavaコードを使用してシンプルなテキストを作成します。

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
次に、テキストのフォントサイズを大きくして効果をより目立たせるために、以下のコードを使用します。

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Microsoft PowerPointの使用**

Microsoft PowerPointのWordArt効果メニューに移動します：

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューからあらかじめ定義されたWordArt効果を選択できます。左側のメニューから新しいWordArtの設定を指定できます。

利用可能なパラメータやオプションのいくつかは以下の通りです：

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slidesの使用**

ここでは、[SmallGrid](https://reference.aspose.com/slides/java/com.aspose.slides/PatternStyle#SmallGrid)パターン色をテキストに適用し、幅1の黒いテキストボーダーを追加するために以下のコードを使用します。

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

結果として得られるテキスト：

![todo:image_alt_text](image-20200930114108-4.png)

## 他のWordArt効果の適用

**Microsoft PowerPointの使用**

プログラムのインターフェースから、テキスト、テキストブロック、形状、または同様の要素にこれらの効果を適用できます：

![todo:image_alt_text](image-20200930114129-5.png)

たとえば、シャドウ、反射、グロウ効果はテキストに適用できます。3Dフォーマットおよび3D回転効果はテキストブロックに適用できます。ソフトエッジプロパティは形状オブジェクトに適用できます（3Dフォーマットプロパティが設定されていない場合でも効果があります）。 

### シャドウ効果の適用

ここでは、テキストに関連するプロパティのみを設定することを目指します。以下のコードを使用して、Javaでテキストにシャドウ効果を適用します。

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

Aspose.Slides APIは、OuterShadow、InnerShadow、PresetShadowの3種類のシャドウをサポートしています。

PresetShadowを使用すると、テキストにシャドウを適用できます（プリセット値を使用）。

**Microsoft PowerPointの使用**

PowerPointでは、1種類のシャドウを使用できます。以下はその例です：

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slidesの使用**

Aspose.Slidesでは実際に、InnerShadowおよびPresetShadowの2種類のシャドウを同時に適用できます。

**注意事項：**

- OuterShadowとPresetShadowを同時に使用した場合、OuterShadow効果のみが適用されます。 
- OuterShadowとInnerShadowを同時に使用した場合、結果として得られる効果はPowerPointのバージョンに依存します。たとえば、PowerPoint 2013では効果が倍増します。しかし、PowerPoint 2007ではOuterShadow効果が適用されます。 

### テキストへの表示の適用

以下のJavaコードサンプルを使用して、テキストに表示を追加します。

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

### テキストへのグロウ効果の適用

以下のコードを使用して、テキストにグロウ効果を適用して光るようにします。

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

操作の結果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

シャドウ、表示、グロウのパラメータを変更できます。効果のプロパティは、テキストの各部分に個別に設定されます。 

{{% /alert %}} 

### WordArtにおける変形の使用

以下のコードを通じて、Transformプロパティ（テキスト全体のブロックに固有）を使用します。
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

結果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPointとAspose.Slides for Javaは、あらかじめ定義された変形タイプのいくつかを提供します。 

{{% /alert %}} 

**PowerPointの使用**

あらかじめ定義された変形タイプにアクセスするには、次のように移動します：**フォーマット** -> **テキスト効果** -> **変形**

**Aspose.Slidesの使用**

変形タイプを選択するには、TextShapeType列挙型を使用します。 

### テキストと形状への3D効果の適用

以下のサンプルコードを使用して、テキスト形状に3D効果を設定します。

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

結果として得られるテキストとその形状：

![todo:image_alt_text](image-20200930114816-9.png)

以下のJavaコードを使用して、テキストに3D効果を適用します。

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

テキストやその形状に3D効果を適用することや、効果間の相互作用は特定のルールに基づいています。

テキストと、そのテキストを含む形状のシーンを考慮してください。3D効果は3Dオブジェクトの表現と、オブジェクトが置かれたシーンを含みます。

- テキストと図の両方にシーンが設定されている場合、図のシーンが優先され、テキストのシーンは無視されます。 
- 図に独自のシーンが不足しており、3D表現がある場合、テキストのシーンが使用されます。 
- それ以外の場合—図がもともと3D効果を持っていない場合、形状はフラットで3D効果はテキストのみに適用されます。 

これらの説明は、ThreeDFormat.getLightRig()およびThreeDFormat.getCamera()メソッドに関連しています。

{{% /alert %}} 

## **テキストに外部シャドウ効果を適用する**
Aspose.Slides for Javaは、[**IOuterShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IOuterShadow)と[**IInnerShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IInnerShadow)クラスを提供し、[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame)によって運ばれるテキストにシャドウ効果を適用できます。以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドへの参照を取得します。
3. スライドに矩形タイプのAutoShapeを追加します。
4. AutoShapeに関連付けられたTextFrameにアクセスします。
5. AutoShapeのFillTypeをNoFillに設定します。
6. OuterShadowクラスをインスタンス化します。
7. シャドウのBlurRadiusを設定します。
8. シャドウのDirectionを設定します。
9. シャドウのDistanceを設定します。
10. RectanglelAlignをTopLeftに設定します。
11. シャドウのPresetColorをBlackに設定します。
12. プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして保存します。

以下のJavaコードは、上記の手順を実装したもので、テキストに外部シャドウ効果を適用する方法を示しています。

```java
Presentation pres = new Presentation();
try {
    // スライドの参照を取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 矩形タイプのAutoShapeを追加
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 矩形にTextFrameを追加
    ashp.addTextFrame("Aspose TextBox");

    // テキストのシャドウを取得するために形状の塗りを無効にする
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 外部シャドウを追加し、すべての必要なパラメータを設定
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // プレゼンテーションをディスクに書き込む
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **形状に内部シャドウ効果を適用する**
以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 矩形タイプのAutoShapeを追加します。
4. InnerShadowEffectを有効にします。
5. すべての必要なパラメータを設定します。
6. ColorTypeをSchemeに設定します。
7. Scheme Colorを設定します。
8. プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして保存します。

このサンプルコード（上記の手順に基づく）は、Javaで2つの形状の間にコネクタを追加する方法を示しています。

```java
Presentation pres = new Presentation();
try {
    // スライドの参照を取得
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプのAutoShapeを追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 矩形にTextFrameを追加
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // InnerShadowEffectを有効にする
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // すべての必要なパラメータを設定
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ColorTypeをSchemeに設定
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme Colorを設定
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // プレゼンテーションを保存
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```