---
title: "JavaScript でプレゼンテーションテーマを管理する"
linktitle: "プレゼンテーションテーマ"
type: docs
weight: 10
url: /ja/nodejs-java/presentation-theme/
keywords:
- "PowerPoint テーマ"
- "プレゼンテーションテーマ"
- "スライドテーマ"
- "テーマの設定"
- "テーマの変更"
- "テーマの管理"
- "テーマカラー"
- "追加パレット"
- "テーマフォント"
- "テーマスタイル"
- "テーマ効果"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js を使用して、JavaScript でプレゼンテーションテーマをマスターし、一貫したブランディングで PowerPoint ファイルの作成、カスタマイズ、変換を行います。"
---
プレゼンテーションテーマはデザイン要素のプロパティを定義します。テーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選んだことになります。

PowerPoint では、テーマは色、[フォント](/slides/ja/nodejs-java/powerpoint-fonts/)、[背景スタイル](/slides/ja/nodejs-java/presentation-background/)、および効果で構成されます。

![theme-constituents](theme-constituents.png)

## **Change Theme Color**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定の色セットを使用します。色が気に入らない場合は、テーマに新しい色を適用して色を変更できます。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SchemeColor) 列挙体で値を提供します。

この JavaScript コードは、テーマのアクセントカラーを変更する方法を示しています。

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

次のようにして、結果として得られる色の実際の値を求めることができます。

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

色変更操作をさらに示すために、別の要素を作成し、最初の操作で取得したアクセントカラーをその要素に割り当てます。その後、テーマ内の色を変更します。

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

新しい色は両方の要素に自動的に適用されます。

### **Set Theme Color from Additional Palette**

メインテーマカラー(1)に対して輝度変換を適用すると、追加パレット(2)から色が生成されます。そのテーマカラーを取得および設定できます。

![additional-palette-colors](additional-palette-colors.png)

**1** - メインテーマカラー  

**2** - 追加パレットからのカラー。

この JavaScript コードは、メインテーマカラーから取得した追加パレットの色をシェイプで使用する操作を示しています。

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

### **Map `SchemeColor` to `ColorScheme` Colors**

[SchemeColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/schemecolor/) を使用すると、次のテーマカラー値が含まれていることに気付くかもしれません。

`Background1`、`Background2`、`Text1`、`Text2`。

ただし、`Presentation.getMasterTheme().getColorScheme()` は [ColorScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/colorscheme/) を返し、対応する色を次のように公開します。

`Dark1`、`Dark2`、`Light1`、`Light2`。

この違いは名前だけです。これらの値は同じテーマカラーのスロットを指し、マッピングは固定されています。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` と `Dark`/`Light` の間に動的な変換はありません。単に同じテーマカラーの別名です。

この命名の違いは Microsoft Office の用語に由来します。古い Office バージョンでは `Dark 1`、`Light 1`、`Dark 2`、`Light 2` が使用され、新しい UI バージョンでは同じスロットが `Text 1`、`Background 1`、`Text 2`、`Background 2` と表示されます。

## **Change Theme Font**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides は PowerPoint で使用されるものと同様の特別な識別子を使用します。

* **+mn-lt** - 本文フォント Latin（Minor Latin Font）
* **+mj-lt** - 見出しフォント Latin（Major Latin Font）
* **+mn-ea** - 本文フォント East Asian（Minor East Asian Font）
* **+mj-ea** - 本文フォント East Asian（Major East Asian Font）

この JavaScript コードは、ラテンフォントをテーマ要素に割り当てる方法を示しています。

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

この JavaScript コードは、プレゼンテーションテーマのフォントを変更する方法を示しています。

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

すべてのテキスト ボックスのフォントが更新されます。

{{% alert color="primary" title="TIP" %}} 
[PowerPoint フォント](/slides/ja/nodejs-java/powerpoint-fonts/) を参照すると役立ちます。 
{{% /alert %}}

## **Change Theme Background Style**

デフォルトでは、PowerPoint アプリは 12 個の事前定義背景を提供しますが、典型的なプレゼンテーションに保存されるのはそのうちの 3 個だけです。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPoint アプリでプレゼンテーションを保存した後、次の JavaScript コードを実行してプレゼンテーション内の事前定義背景の数を調べることができます。

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
[BackgroundFillStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) プロパティを使用すると、[FormatScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/FormatScheme) クラスから PowerPoint テーマの背景スタイルを追加または取得できます。 
{{% /alert %}} 

この JavaScript コードは、プレゼンテーションの背景を設定する方法を示しています。

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**インデックスガイド**: 0 は塗りなしを意味します。インデックスは 1 から始まります。

{{% alert color="primary" title="TIP" %}} 
[PowerPoint 背景](/slides/ja/nodejs-java/presentation-background/) を参照すると便利です。 
{{% /alert %}}

## **Change Theme Effect**

PowerPoint テーマは通常、各スタイル配列に対して 3 つの値を含みます。これらの配列は 3 つの効果（subtle、moderate、intense）に結合されます。たとえば、特定のシェイプに効果を適用した結果は次のとおりです。

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/FormatScheme) クラスの 3 つのプロパティ（[FillStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)）を使用すると、PowerPoint のオプションよりも柔軟にテーマ内の要素を変更できます。

この JavaScript コードは、要素の一部を変更することでテーマ効果を変更する方法を示しています。

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

結果として得られる塗りの色、塗りタイプ、影効果などの変更:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**スライド単位でテーマを適用し、マスターを変更せずに済ませることはできますか？**

はい。Aspose.Slides はスライドレベルのテーマオーバーライドをサポートしているため、[SlideThemeManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidethememanager/) を使用して、マスターテーマをそのままにローカルテーマを特定のスライドに適用できます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に移行する最良の方法は何ですか？**

[スライドのクローン](/slides/ja/nodejs-java/clone-slides/) をマスターと共に対象プレゼンテーションにコピーします。これにより元のマスター、レイアウト、および関連するテーマが保持され、外観が一貫します。

**すべての継承とオーバーライドを適用した後の「実効」値を確認するにはどうすればよいですか？**

テーマ/カラー/フォント/効果に対して API の「実効」ビュー[/slides/ja/nodejs-java/shape-effective-properties/] を使用します。これらはマスターとローカルオーバーライドを適用した後の最終的に解決されたプロパティを返します。