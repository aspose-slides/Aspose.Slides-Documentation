---
title: プレゼンテーション テーマ
type: docs
weight: 10
url: /ja/nodejs-java/presentation-theme/
keywords: "テーマ、PowerPoint テーマ、PowerPoint プレゼンテーション、Java、Node.js via Java 用 Aspose.Slides"
description: "JavaScript の PowerPoint プレゼンテーション テーマ"
---

プレゼンテーション テーマはデザイン要素のプロパティを定義します。プレゼンテーション テーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選ぶことになります。

PowerPoint では、テーマは色、[フォント](/slides/ja/nodejs-java/powerpoint-fonts/)、[背景スタイル](/slides/ja/nodejs-java/presentation-background/)、および効果で構成されます。

![theme-constituents](theme-constituents.png)

## **テーマの色を変更**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定の色セットを使用します。色が好みでない場合は、テーマに新しい色を適用して色を変更します。新しいテーマの色を選択できるように、Aspose.Slides は [SchemeColor] 列挙体の値を提供しています。

この JavaScript コードは、テーマのアクセントカラーを変更する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


この方法で、結果として得られる色の実効値を確認できます:
```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```


色の変更操作をさらに示すために、別の要素を作成し、アクセントカラー（最初の操作から）を割り当てます。その後、テーマ内の色を変更します:
```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマの色を設定**

メインテーマカラー(1)に輝度変換を適用すると、追加パレット(2)から色が生成されます。その後、それらのテーマカラーを設定および取得できます。

![additional-palette-colors](additional-palette-colors.png)

**1** - メインテーマカラー

**2** - 追加パレットからのカラー

この JavaScript コードは、メインテーマカラーから取得した追加パレットのカラーをシェイプで使用する操作を示しています:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // アクセント 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // アクセント 4、明るさ 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // アクセント 4、明るさ 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // アクセント 4、明るさ 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // アクセント 4、暗さ 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // アクセント 4、暗さ 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **テーマのフォントを変更**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides は以下の特殊な識別子（PowerPoint で使用されるものと同様）を使用します:

* **+mn-lt** - 本文フォント ラテン文字 (Minor Latin Font)
* **+mj-lt** - 見出しフォント ラテン文字 (Major Latin Font)
* **+mn-ea** - 本文フォント 東アジア文字 (Minor East Asian Font)
* **+mj-ea** - 本文フォント 東アジア文字 (Major East Asian Font)

この JavaScript コードは、ラテンフォントをテーマ要素に割り当てる方法を示しています:
```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```


この JavaScript コードは、プレゼンテーション テーマのフォントを変更する方法を示しています:
```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```


すべてのテキストボックスのフォントが更新されます。

{{% alert color="primary" title="TIP" %}} 
[PowerPoint フォント](/slides/ja/nodejs-java/powerpoint-fonts/) をご覧になると良いでしょう。
{{% /alert %}}

## **テーマの背景スタイルを変更**

デフォルトでは、PowerPoint アプリは 12 個の定義済み背景を提供しますが、そのうち 3 個だけが一般的なプレゼンテーションに保存されます。

![todo:image_alt_text](presentation-design_8.png)

例えば、PowerPoint アプリでプレゼンテーションを保存した後、以下の JavaScript コードを実行してプレゼンテーションに含まれる定義済み背景の数を取得できます:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) プロパティを [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme) クラスから使用すると、PowerPoint のテーマで背景スタイルを追加または取得できます。
{{% /alert %}} 

この JavaScript コードは、プレゼンテーションの背景を設定する方法を示しています:
```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```


**インデックス ガイド**: 0 は塗りなしを表します。インデックスは 1 から始まります。

{{% alert color="primary" title="TIP" %}} 
[PowerPoint 背景](/slides/ja/nodejs-java/presentation-background/) をご覧になると良いでしょう。
{{% /alert %}}

## **テーマの効果を変更**

PowerPoint のテーマは通常、各スタイル配列に対して 3 つの値を含みます。これらの配列は 3 つの効果（微妙、適度、強烈）に統合されます。例えば、特定のシェイプに効果を適用した結果は以下の通りです:

![todo:image_alt_text](presentation-design_10.png)

[FillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--) の 3 つのプロパティを [FormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FormatScheme) クラスから使用すると、PowerPoint のオプションよりも柔軟にテーマ内の要素を変更できます。

この JavaScript コードは、要素の一部を変更してテーマの効果を変える方法を示しています:
```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


結果として、塗りの色、塗りタイプ、影効果などが変更されます:
![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**スライドのマスターを変更せずに、単一のスライドにテーマを適用できますか？**

はい。Aspose.Slides はスライドレベルのテーマオーバーライドをサポートしているため、マスターテーマをそのままにして対象のスライドにローカルテーマを適用できます（[SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) を使用）。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち込む最善の方法は何ですか？**

[Clone slides](/slides/ja/nodejs-java/clone-slides/) とそれらのマスターを対象のプレゼンテーションにコピーすると、元のマスター、レイアウト、および関連するテーマが保持され、外観が一貫したままです。

**継承とオーバーライドのすべてが適用された後の「実効」値を確認するにはどうすればよいですか？**

API の ["effective" ビュー](/slides/ja/nodejs-java/shape-effective-properties/)（テーマ／カラー／フォント／効果用）を使用します。これらは、マスターとローカルオーバーライドが適用された後の解決された最終プロパティを返します。