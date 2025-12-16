---
title: Android でプレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/androidjava/presentation-theme/
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
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides のプレゼンテーションテーマをマスターし、一貫したブランディングで PowerPoint ファイルを作成、カスタマイズ、変換します。"
---

プレゼンテーションテーマはデザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、本質的に特定のビジュアル要素とそのプロパティのセットを選ぶことになります。

PowerPoint では、テーマは色、[フォント](/slides/ja/androidjava/powerpoint-fonts/)、[背景スタイル](/slides/ja/androidjava/presentation-background/)、および効果で構成されます。

![テーマの構成要素](theme-constituents.png)

## **テーマの色を変更する**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定の色のセットを使用します。色が気に入らない場合は、テーマに新しい色を適用して色を変更します。新しいテーマの色を選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SchemeColor) 列挙体で値を提供します。

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


色の変更操作をさらに示すために、別の要素を作成し、アクセントカラー（最初の操作から取得）を割り当てます。その後、テーマ内の色を変更します：
```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```


新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定する**

メインテーマカラー（1）に輝度変換を適用すると、追加パレット（2）から色が生成されます。その後、これらのテーマカラーを設定および取得できます。

![追加パレットの色](additional-palette-colors.png)

**1** - メインテーマカラー  
**2** - 追加パレットからの色

この Java コードは、メインテーマカラーから追加パレットの色を取得し、シェイプで使用する操作を示しています：
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // アクセント4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // アクセント4、明るさ80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // アクセント4、明るさ60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // アクセント4、明るさ40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // アクセント4、暗さ25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // アクセント4、暗さ50%
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

テーマやその他の目的でフォントを選択できるように、Aspose.Slides はこれらの特別な識別子（PowerPoint で使用されるものと同様）を使用します。

* **+mn-lt** - 本文フォント ラテン文字（マイナー ラテンフォント）  
* **+mj-lt** - 見出しフォント ラテン文字（メジャー ラテンフォント）  
* **+mn-ea** - 本文フォント 東アジア文字（マイナー 東アジアフォント）  
* **+mj-ea** - 本文フォント 東アジア文字（メジャー 東アジアフォント）

この Java コードは、ラテンフォントをテーマ要素に割り当てる方法を示しています：
```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```


この Java コードは、プレゼンテーションテーマのフォントを変更する方法を示しています：
```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```


すべてのテキストボックスのフォントが更新されます。

{{% alert color="primary" title="TIP" %}}  
[PowerPoint フォント](/slides/ja/androidjava/powerpoint-fonts/) を参照するとよいでしょう。  
{{% /alert %}}

## **テーマの背景スタイルの変更**

デフォルトでは、PowerPoint アプリは 12 個の事前定義された背景を提供しますが、典型的なプレゼンテーションではそのうち 3 つだけが保存されます。

![プレゼンテーションデザイン](presentation-design_8.png)

例えば、PowerPoint アプリでプレゼンテーションを保存した後、次の Java コードを実行してプレゼンテーションに含まれる事前定義背景の数を確認できます：
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
[BackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) プロパティと [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme) クラスを使用して、PowerPoint テーマの背景スタイルを追加または取得できます。  
{{% /alert %}}

この Java コードは、プレゼンテーションの背景を設定する方法を示しています：
```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**インデックスガイド**: 0 は塗りつぶしなしを表します。インデックスは 1 から始まります。

{{% alert color="primary" title="TIP" %}}  
[PowerPoint 背景](/slides/ja/androidjava/presentation-background/) を参照するとよいでしょう。  
{{% /alert %}}

## **テーマ効果の変更**

PowerPoint テーマは通常、各スタイル配列に対して 3 つの値を含みます。これらの配列は 3 つの効果（サブトル、モデレート、インテンス）に結合されます。例えば、特定のシェイプに効果を適用した結果は次のとおりです。

![プレゼンテーションデザイン](presentation-design_10.png)

[FillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getFillStyles--) 、[LineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getLineStyles--) 、[EffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--) の 3 つのプロパティを [FormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FormatScheme) クラスから使用すると、PowerPoint のオプションよりも柔軟にテーマ内の要素を変更できます。

この Java コードは、要素の一部を変更してテーマ効果を変更する方法を示しています：
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


結果として、塗りつぶし色、塗りタイプ、影効果などが変更されます。

![プレゼンテーションデザイン](presentation-design_11.png)

## **よくある質問**

**マスタを変更せずに単一スライドにテーマを適用できますか？**  
はい。Aspose.Slides はスライドレベルのテーマ上書きをサポートしているため、マスターテーマをそのままに保持しながら、対象スライドにローカルテーマを適用できます（[SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) を使用）。

**テーマを別のプレゼンテーションに安全に持ち込む最適な方法は何ですか？**  
[スライドのコピー](/slides/ja/androidjava/clone-slides/) をマスタと共に対象のプレゼンテーションに持ち込むと、元のマスタ、レイアウト、および関連するテーマが保持され、外観が一貫したままです。

**すべての継承と上書きの後に「実効」値を見るにはどうすればよいですか？**  
API の ["実効" ビュー](/slides/ja/androidjava/shape-effective-properties/)（テーマ/カラー/フォント/効果）を使用してください。これらは、マスタとローカル上書きのすべてを適用した後の解決された最終プロパティを返します。