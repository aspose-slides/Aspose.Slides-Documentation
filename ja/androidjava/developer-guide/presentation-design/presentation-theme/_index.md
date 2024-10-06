---
title: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/androidjava/presentation-theme/
keywords: "テーマ, PowerPoint テーマ, PowerPoint プレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "Java における PowerPoint プレゼンテーションテーマ"
---

プレゼンテーションテーマは、デザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、特定の視覚要素とそのプロパティのセットを選んでいることになります。

PowerPoint では、テーマは色、[フォント](/slides/ja/androidjava/powerpoint-fonts/)、[背景スタイル](/slides/ja/androidjava/presentation-background/)、および効果を含みます。

![theme-constituents](theme-constituents.png)

## **テーマカラーの変更**

PowerPoint テーマは、スライド上の異なる要素に特定の色のセットを使用します。色が気に入らない場合は、テーマの新しい色を適用することで変更できます。新しいテーマカラーを選択できるようにするために、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SchemeColor) 列挙体の下に値を提供します。

この Java コードは、テーマのアクセントカラーを変更する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

このようにして、結果の色の有効値を判断できます：

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

色変更操作をさらに示すために、別の要素を作成し、アクセントカラー（初期操作から）をそれに割り当てます。そして、テーマ内の色を変更します：

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定**

主テーマカラー(1) に輝度変換を適用すると、追加パレット(2) から色が形成されます。次に、これらのテーマカラーを設定および取得できます。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主テーマカラー

**2** - 追加パレットからの色。

この Java コードは、追加パレットの色が主テーマカラーから取得され、形状で使用される操作を示しています：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // アクセント 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // アクセント 4, 明るい 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // アクセント 4, 明るい 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // アクセント 4, 明るい 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // アクセント 4, 暗い 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // アクセント 4, 暗い 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **テーマフォントの変更**

テーマやその他の目的のためにフォントを選択できるようにするため、Aspose.Slides は次の特別な識別子を使用します（PowerPoint で使用されるものに似ています）：

* **+mn-lt** - 本体フォントラテン（マイナーラテンフォント）
* **+mj-lt** - 見出しフォントラテン（メジャーラテンフォント）
* **+mn-ea** - 本体フォント東アジア（マイナー東アジアフォント）
* **+mj-ea** - 本体フォント東アジア（メジャー東アジアフォント）

この Java コードは、ラテンフォントをテーマ要素に割り当てる方法を示しています：

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("テーマテキスト形式");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

この Java コードは、プレゼンテーションテーマフォントを変更する方法を示しています：

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

すべてのテキストボックスのフォントが更新されます。

{{% alert color="primary" title="ヒント" %}} 

[PowerPoint フォント](/slides/ja/androidjava/powerpoint-fonts/)をご覧いただくことをお勧めします。

{{% /alert %}}

## **テーマ背景スタイルの変更**

デフォルトでは、PowerPoint アプリは 12 の事前定義された背景を提供しますが、それらの 12 の背景のうち 3 つだけが一般的なプレゼンテーションに保存されます。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPoint アプリでプレゼンテーションを保存した後、次の Java コードを実行してプレゼンテーション内の事前定義された背景の数を確認できます：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("テーマの背景塗りつぶしスタイルの数は " + numberOfBackgroundFills + " です。");
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

[FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme) クラスの [BackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) プロパティを使用することで、PowerPoint テーマの背景スタイルを追加またはアクセスできます。

{{% /alert %}} 

この Java コードは、プレゼンテーションの背景を設定する方法を示しています：

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**インデックスガイド**: 0 は塗りつぶしなしに使用されます。インデックスは 1 から始まります。

{{% alert color="primary" title="ヒント" %}} 

[PowerPoint 背景](/slides/ja/androidjava/presentation-background/)をご覧いただくことをお勧めします。

{{% /alert %}}

## **テーマ効果の変更**

PowerPoint テーマには、通常、各スタイル配列に対して 3 つの値が含まれます。それらの配列は、微妙、中程度、強烈の 3 つの効果に結合されます。たとえば、これは特定の形状に効果が適用されたときの結果です：

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme) クラスの 3 つのプロパティ（[FillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)）を使用することで、PowerPoint のオプションよりもさらに柔軟にテーマ内の要素を変更できます。

この Java コードは、要素の一部を変更することでテーマ効果を変更する方法を示しています：

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

結果として、塗りつぶし色、塗りつぶしタイプ、シャドウ効果などの変更が反映されます：

![todo:image_alt_text](presentation-design_11.png)