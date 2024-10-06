---
title: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/java/presentation-theme/
keywords: "テーマ, PowerPoint テーマ, PowerPoint プレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaのPowerPointプレゼンテーションテーマ"
---

プレゼンテーションテーマは、デザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、特定の視覚要素とそのプロパティのセットを選択することになります。

PowerPointでは、テーマは色、[フォント](/slides/ja/java/powerpoint-fonts/)、[背景スタイル](/slides/ja/java/presentation-background/)、および効果で構成されています。

![theme-constituents](theme-constituents.png)

## **テーマカラーの変更**

PowerPointテーマは、スライド上の異なる要素に対して特定のセットの色を使用します。色が気に入らない場合は、新しい色をテーマに適用することで変更できます。新しいテーマカラーを選択できるようにするために、Aspose.Slidesは[SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/SchemeColor) 列挙の下に値を提供します。

このJavaコードは、テーマのアクセントカラーを変更する方法を示しています：

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

結果として得られる色の有効値をこのようにして決定できます：

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

カラー変更操作をさらに示すために、別の要素を作成し、アクセントカラー（最初の操作から）をそれに割り当てます。その後、テーマ内の色を変更します：

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定**

主要テーマカラー(1) に輝度変換を適用すると、追加パレット(2) から色が形成されます。その後、これらのテーマカラーを設定および取得できます。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主テーマカラー

**2** - 追加パレットからの色。

このJavaコードは、主要テーマカラーから追加パレットカラーを取得し、それを形状に使用する操作を示しています：

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

    // アクセント 4, 暗く 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // アクセント 4, 暗く 50%
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

テーマやその他の目的のためにフォントを選択できるようにするために、Aspose.Slidesはこれらの特別な識別子を使用しています（PowerPointで使用されるものと類似）：

* **+mn-lt** - ボディフォントラテン（マイナーラテンフォント）
* **+mj-lt** - ヘッディングフォントラテン（メジャーラテンフォント）
* **+mn-ea** - ボディフォント東アジア（マイナー東アジアフォント）
* **+mj-ea** - ボディフォント東アジア（メジャー東アジアフォント）

このJavaコードは、テーマ要素にラテンフォントを割り当てる方法を示しています：

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("テーマテキスト形式");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

このJavaコードは、プレゼンテーションテーマフォントを変更する方法を示しています：

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

すべてのテキストボックスのフォントが更新されます。

{{% alert color="primary" title="ヒント" %}} 

[PowerPointフォント](/slides/ja/java/powerpoint-fonts/)を確認することをお勧めします。

{{% /alert %}}

## **テーマ背景スタイルの変更**

デフォルトでは、PowerPointアプリは12のプリセット背景を提供しますが、その12の背景のうち3つのみが通常のプレゼンテーションに保存されます。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPointアプリでプレゼンテーションを保存した後、このJavaコードを実行して、プレゼンテーション内の定義済み背景の数を確認できます：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("テーマの背景フィルスタイルの数は " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

[FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme)クラスの[BackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--)プロパティを使用すると、PowerPointテーマで背景スタイルを追加またはアクセスできます。 

{{% /alert %}} 

このJavaコードは、プレゼンテーションの背景を設定する方法を示しています：

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**インデックスガイド**：0はノーフィルに使用されます。インデックスは1から始まります。

{{% alert color="primary" title="ヒント" %}} 

[PowerPoint背景](/slides/ja/java/presentation-background/)を確認することをお勧めします。

{{% /alert %}}

## **テーマ効果の変更**

PowerPointテーマには、通常、各スタイル配列に対して3つの値が含まれています。これらの配列は、微妙、中程度、強烈のこの3つの効果に組み合わされます。たとえば、特定の形状に効果を適用したときの結果は次のようになります：

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme)クラスの3つのプロパティ（[FillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getEffectStyles--)）を使用して、テーマ内の要素を変更できます（PowerPointのオプションよりも柔軟に）。

このJavaコードは、要素の一部を変更することでテーマ効果を変更する方法を示しています：

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

フィルカラー、フィルタイプ、シャドウ効果などの結果としての変更：

![todo:image_alt_text](presentation-design_11.png)