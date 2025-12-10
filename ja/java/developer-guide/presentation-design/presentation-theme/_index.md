---
title: Java でプレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/java/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマの設定
- テーマの変更
- テーマの管理
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマエフェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java 向け Aspose.Slides でプレゼンテーションテーマをマスターし、PowerPoint ファイルを一貫したブランディングで作成、カスタマイズ、変換します。"
---

プレゼンテーションテーマはデザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選ぶことになります。

PowerPoint では、テーマは色、[fonts](/slides/ja/java/powerpoint-fonts/)、[background styles](/slides/ja/java/presentation-background/)、およびエフェクトで構成されます。

![テーマ構成要素](theme-constituents.png)

## **テーマの色を変更**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定の色セットを使用します。色が気に入らない場合は、テーマに新しい色を適用して色を変更します。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/SchemeColor) 列挙体の値を提供します。

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


この方法で、結果として得られる色の実効値を確認できます：
```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```


色変更操作をさらに示すために、別の要素を作成し、最初の操作で取得したアクセントカラーを割り当てます。その後、テーマ内の色を変更します：
```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```


新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定**

メインテーマカラー(1)に輝度変換を適用すると、追加パレット(2)から色が生成されます。その後、これらのテーマカラーを設定および取得できます。

![追加パレットの色](additional-palette-colors.png)

**1** - メインテーマカラー  
**2** - 追加パレットの色

この Java コードは、メインテーマカラーから追加パレットの色を取得し、それらをシェイプで使用する操作を示しています：
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // アクセント 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // アクセント 4、明るさ 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // アクセント 4、明るさ 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // アクセント 4、明るさ 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // アクセント 4、暗く 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // アクセント 4、暗く 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **テーマフォントを変更**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides は以下の特別な識別子（PowerPoint で使用されるものと類似）を使用します。

* **+mn-lt** - 本文フォント ラテン文字 (Minor Latin Font)  
* **+mj-lt** - 見出しフォント ラテン文字 (Major Latin Font)  
* **+mn-ea** - 本文フォント 東アジア (Minor East Asian Font)  
* **+mj-ea** - 本文フォント 東アジア (Major East Asian Font)

この Java コードは、ラテンフォントをテーマ要素に割り当てる方法を示しています：
```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```


この Java コードは、プレゼンテーションのテーマフォントを変更する方法を示しています：
```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```


すべてのテキストボックスのフォントが更新されます。

{{% alert color="primary" title="TIP" %}} 
[PowerPoint フォント](/slides/ja/java/powerpoint-fonts/) をご覧になるとよいでしょう。 
{{% /alert %}}

## **テーマの背景スタイルを変更**

デフォルトでは、PowerPoint アプリは 12 の事前定義された背景を提供しますが、典型的なプレゼンテーションではそのうちの 3 つだけが保存されます。

![todo:image_alt_text](presentation-design_8.png)

例えば、PowerPoint アプリでプレゼンテーションを保存した後、以下の Java コードを実行してプレゼンテーションに含まれる事前定義背景の数を調べることができます：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) プロパティを [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme) クラスから使用して、PowerPoint テーマの背景スタイルを追加または取得できます。 
{{% /alert %}} 

この Java コードは、プレゼンテーションの背景を設定する方法を示しています：
```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**インデックスガイド**: 0 は塗りなしを意味します。インデックスは 1 から始まります。

{{% alert color="primary" title="TIP" %}} 
[PowerPoint 背景](/slides/ja/java/presentation-background/) をご覧になるとよいでしょう。 
{{% /alert %}}

## **テーマエフェクトを変更**

PowerPoint テーマは通常、各スタイル配列に対して 3 つの値を含みます。これらの配列は、微妙、適度、強烈という 3 つのエフェクトに結合されます。例えば、特定のシェイプにエフェクトを適用した結果は以下の通りです：

![todo:image_alt_text](presentation-design_10.png)

3 つのプロパティ（[FillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getEffectStyles--)）を [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme) クラスから使用すると、PowerPoint のオプションよりも柔軟にテーマ内の要素を変更できます。

この Java コードは、要素の一部を変更してテーマエフェクトを変更する方法を示しています：
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


結果として、塗りの色、塗りタイプ、影エフェクトなどが変更されます：
![todo:image_alt_text](presentation-design_11.png)

## **よくある質問**

**マスターを変更せずに、単一のスライドにテーマを適用できますか？**

はい。Aspose.Slides はスライドレベルのテーマオーバーライドをサポートしているため、マスターテーマをそのままにして、対象のスライドにローカルテーマを適用できます（[SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/) を使用）。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に移行する最善の方法は何ですか？**

[スライドのクローン](/slides/ja/java/clone-slides/) をマスターと共にターゲットプレゼンテーションにコピーすると、元のマスター、レイアウト、関連するテーマが保持され、外観が一貫したままになります。

**すべての継承とオーバーライドの後の「実効」値を確認するにはどうすればよいですか？**

API の [「実効」ビュー](/slides/ja/java/shape-effective-properties/)（テーマ/色/フォント/エフェクト）を使用します。これらは、マスターとローカルオーバーライドを適用した後に解決された最終プロパティを返します。