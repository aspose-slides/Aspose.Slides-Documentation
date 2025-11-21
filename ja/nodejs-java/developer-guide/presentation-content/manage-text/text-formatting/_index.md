---
title: JavaScriptでPowerPointテキストをフォーマットする
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/nodejs-java/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
- 段落の配置
- テキストスタイル
- テキスト背景
- テキスト透過性
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- 自動調整プロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定する方法を学びます。強力な JavaScript コード例を使ってフォント、色、配置などをカスタマイズできます。"
---

## **テキストのハイライト**

Method [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) が [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) クラスと [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) クラスに追加されました。

テキストサンプルを使用して背景色でテキストの一部をハイライトでき、PowerPoint 2019 のテキスト ハイライト カラー ツールに似ています。

以下のコードスニペットはこの機能の使用方法を示しています:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// すべての単語 'important' をハイライト
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// 個別の 'the' の出現をすべてハイライト
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
Aspose はシンプルな、[無料のオンライン PowerPoint 編集サービス](https://products.aspose.app/slides/editor) を提供しています
{{% /alert %}} 

## **正規表現を使用したテキストのハイライト**

Method [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) が [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) クラスと [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) クラスに追加されました。

正規表現を使用して背景色でテキストの一部をハイライトでき、PowerPoint 2019 のテキスト ハイライト カラー ツールに似ています。

以下のコードスニペットはこの機能の使用方法を示しています:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// 10文字以上のすべての単語をハイライト
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキストの背景色の設定**

Aspose.Slides を使用すると、テキストの背景色を好みの色に指定できます。

この JavaScript コードはテキスト全体の背景色を設定する方法を示します:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
const pres = new aspose.slides.Presentation("text.pptx");
try {
    const slide = pres.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    if (autoShape.getTextFrame() != null) {
        const paragraphs = autoShape.getTextFrame().getParagraphs();
        const paragraphCount = paragraphs.size();
        for (let i = 0; i < paragraphCount; i++) {
            const portions = paragraphs.get_Item(i).getPortions();
            const portionCount = portions.size();
            for (let j = 0; j < portionCount; j++) {
                const portion = portions.get_Item(j);
                portion.getPortionFormat().getHighlightColor().setColor(Color.BLUE);
            }
        }
    }
    pres.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


この JavaScript コードはテキストの一部だけの背景色を設定する方法を示します:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
var presentation = new aspose.slides.Presentation("text.pptx");
try {
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var redPortion = java.callStaticMethodSync("StreamSupport", "stream", autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false).filter(p -> p.getText().contains("Red")).findFirst();
    if (redPortion.isPresent()) {
        redPortion.get().getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    presentation.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **テキスト段落の配置**

テキストの書式設定は、あらゆる文書やプレゼンテーションを作成する際の重要な要素の一つです。Aspose.Slides for Node.js via Java がスライドへのテキスト追加をサポートしていることはよく知られていますが、本項ではスライド内のテキスト段落の配置を制御する方法を見ていきます。以下の手順に従って Aspose.Slides for Node.js via Java を使用してテキスト段落を配置してください:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに存在するプレースホルダー シェイプにアクセスし、それらを [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) に型キャストします。
4. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) が提供する [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) から（配置する必要がある）段落を取得します。
5. 段落を配置します。段落は右揃え、左揃え、中央揃え、または両端揃えに設定できます。
6. 修正したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例を以下に示します。
```javascript
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // 最初のスライドにアクセスする
    var slide = pres.getSlides().get_Item(0);
    // スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型キャストする
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // 両方のプレースホルダーのテキストを変更する
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");
    // プレースホルダーの最初の段落を取得する
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // テキスト段落を中央揃えにする
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    // プレゼンテーションを PPTX ファイルとして書き出す
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキストの透過性の設定**

この記事では、Aspose.Slides for Node.js via Java を使用して任意のテキスト シェイプの透過性プロパティを設定する方法を示します。テキストの透過性を設定するには、以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 影の色を設定します。
4. プレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例を以下に示します。
```javascript
var pres = new aspose.slides.Presentation("transparency.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();
    var outerShadowEffect = effects.getOuterShadowEffect();
    var shadowColor = outerShadowEffect.getShadowColor().getColor();
    console.log((shadowColor.toString() + " - transparency is: ") + ((shadowColor.getAlpha() / 255.0) * 100));
    // 透明度を0%に設定する
    outerShadowEffect.getShadowColor().setColor(java.newInstanceSync("java.awt.Color", shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));
    pres.save("transparency-2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキストの文字間隔の設定**

Aspose.Slides を使用すると、テキストボックス内の文字間のスペースを設定できます。この方法により、文字間隔を広げたり縮めたりして、行またはテキストブロックの視覚的密度を調整できます。

この JavaScript コードは、ある行の文字間隔を広げ、別の行の文字間隔を縮める方法を示します:
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// 拡張
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// 縮小
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **段落のフォントプロパティの管理**

プレゼンテーションには通常、テキストと画像の両方が含まれます。テキストはさまざまな方法で書式設定でき、特定のセクションや単語を強調したり、企業スタイルに合わせたりできます。テキストの書式設定により、プレゼンテーション コンテンツの外観と感覚を変えることができます。本記事では、Aspose.Slides for Node.js via Java を使用してスライド上の段落テキストのフォントプロパティを構成する方法を示します。段落のフォントプロパティを管理する手順は以下の通りです:

1. [Presentation] クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内のプレースホルダー シェイプにアクセスし、[AutoShape] に型キャストします。
4. [AutoShape] が提供する [TextFrame] から [Paragraph] を取得します。
5. 段落を両端揃えにします。
6. 段落のテキスト Portion にアクセスします。
7. FontData を使用してフォントを定義し、テキスト Portion のフォントを設定します。
   1. フォントを太字に設定します。
   2. フォントを斜体に設定します。
8. [Portion] オブジェクトが提供する [getFillFormat] を使用してフォントカラーを設定します。
9. 修正したプレゼンテーションを [PPTX] ファイルに保存します。

上記手順の実装例を以下に示します。装飾のないプレゼンテーションを取得し、1 つのスライドのフォントをフォーマットします。
```javascript
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // スライド位置を使用してスライドにアクセスする
    var slide = pres.getSlides().get_Item(0);
    // スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型キャストする
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // 最初の段落にアクセスする
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // 最初のポーションにアクセスする
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // 新しいフォントを定義する
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // ポーションに新しいフォントを割り当てる
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // フォントを太字に設定する
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // フォントを斜体に設定する
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // フォントの色を設定する
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // PPTX をディスクに保存する
    pres.save("WelcomeFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキストのフォントファミリの管理**

Portion は段落内で同一の書式スタイルを持つテキストを保持するために使用されます。本記事では、Aspose.Slides for Node.js via Java を使用してテキスト ボックスを作成し、特定のフォントやフォントファミリに関するさまざまなプロパティを定義する方法を示します。テキスト ボックスを作成し、テキストのフォントプロパティを設定する手順は以下の通りです:

1. [Presentation] クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドにタイプが [Rectangle] の [AutoShape] を追加します。
4. [AutoShape] に関連付けられた塗りつぶしスタイルを削除します。
5. AutoShape の TextFrame にアクセスします。
6. TextFrame にテキストを追加します。
7. [TextFrame] に関連付けられた Portion オブジェクトにアクセスします。
8. [Portion] に使用するフォントを定義します。
9. Portion オブジェクトが提供する関連プロパティを使用して、太字、斜体、下線、色、サイズなどのフォントプロパティを設定します。
10. 修正したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例を以下に示します。
```javascript
// Presentation をインスタンス化する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得する
    var sld = pres.getSlides().get_Item(0);
    // Rectangle タイプの AutoShape を追加する
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // AutoShape に関連付けられた塗りつぶしスタイルを削除する
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // AutoShape に関連付けられた TextFrame にアクセスする
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // TextFrame に関連付けられた Portion にアクセスする
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Portion のフォントを設定する
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // フォントの太字プロパティを設定する
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // フォントの斜体プロパティを設定する
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // フォントの下線プロパティを設定する
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // フォントの高さを設定する
    port.getPortionFormat().setFontHeight(25);
    // フォントの色を設定する
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // PPTX をディスクに書き込む
    pres.save("SetTextFontProperties_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキストのフォントサイズの設定**

Aspose.Slides を使用すると、段落内の既存テキストや後から追加されるテキストの好みのフォントサイズを選択できます。

この JavaScript コードは、段落に含まれるテキストのフォントサイズを設定する方法を示します:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // 例として、最初のシェイプを取得します。
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        var autoShape = shape;
        // 例として、最初の段落を取得します。
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // 段落内のすべてのテキストポーションのデフォルトフォントサイズを 20 pt に設定します。
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // 段落内の現在のテキストポーションのフォントサイズを 20 pt に設定します。
        for (let i = 0; i < paragraph.getPortions().getCount(); i++) {
            let portion = paragraph.getPortions().get_Item(i);
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **テキストの回転設定**

Aspose.Slides for Node.js via Java は、開発者がテキストを回転させることを可能にします。テキストは [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal)、[Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical)、[Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270)、[WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical)、[EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical)、[MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) または [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft) として表示できます。任意の TextFrame のテキストを回転させるには、以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意の Shape をスライドに追加します。
4. [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) にアクセスします。
5. [Rotate the text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-) を実行します。
6. ファイルをディスクに保存します。
```javascript
// Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得する
    var slide = pres.getSlides().get_Item(0);
    // Rectangle タイプの AutoShape を追加する
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Rectangle に TextFrame を追加する
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // テキストフレームにアクセスする
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // テキストフレーム用の Paragraph オブジェクトを作成する
    var para = txtFrame.getParagraphs().get_Item(0);
    // Paragraph 用の Portion オブジェクトを作成する
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // プレゼンテーションを保存する
    pres.save("RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **TextFrame のカスタム回転角度の設定**

Aspose.Slides for Node.js via Java は、TextFrame のカスタム回転角度の設定をサポートしています。本項では、例を交えて RotationAngle プロパティの設定方法を示します。新しいメソッド [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) と [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) が [ChartTextBlockFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartTextBlockFormat) と [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) クラスに追加され、TextFrame のカスタム回転角度を設定できるようになりました。RotationAngle を設定するには、以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. [RotationAngle プロパティ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) を設定します。
4. プレゼンテーションを PPTX ファイルとして保存します。

以下の例で RotationAngle プロパティを設定します。
```javascript
// Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得する
    var slide = pres.getSlides().get_Item(0);
    // Rectangle タイプの AutoShape を追加する
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Rectangle に TextFrame を追加する
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // テキストフレームにアクセスする
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);
    // テキストフレーム用の Paragraph オブジェクトを作成する
    var para = txtFrame.getParagraphs().get_Item(0);
    // Paragraph 用の Portion オブジェクトを作成する
    var portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // プレゼンテーションを保存する
    pres.save(resourcesOutputPath + "RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **段落の行間設定**

`ParagraphFormat`（[`SpaceAfter`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat), [`SpaceBefore`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat), [`SpaceWithin`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat)）には、段落の行間を管理するプロパティがあります。使用方法は次のとおりです。

* パラグラフの行間をパーセンテージで指定するには、正の値を使用します。 
* パラグラフの行間をポイントで指定するには、負の値を使用します。

例として、`SpaceBefore` プロパティを -16 に設定すると、段落に 16pt の行間が適用されます。

このプロパティを特定の段落に設定する手順は次のとおりです:

1. テキストを含む AutoShape があるプレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. TextFrame にアクセスします。
4. Paragraph にアクセスします。
5. Paragraph のプロパティを設定します。
6. プレゼンテーションを保存します。

以下の JavaScript コードは段落の行間を指定する方法を示します:
```javascript
// Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // インデックスでスライドの参照を取得する
    var sld = pres.getSlides().get_Item(0);
    // TextFrame にアクセスする
    var tf1 = sld.getShapes().get_Item(0).getTextFrame();
    // Paragraph にアクセスする
    var para = tf1.getParagraphs().get_Item(0);
    // Paragraph のプロパティを設定する
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    // プレゼンテーションを保存する
    pres.save("LineSpacing_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **TextFrame の AutofitType プロパティの設定**

本項では、テキストフレームのさまざまな書式設定プロパティを検討します。この記事では、テキストフレームの AutofitType プロパティ、テキストのアンカー、プレゼンテーション内でのテキストの回転設定方法を紹介します。Aspose.Slides for Node.js via Java では、任意のテキストフレームの AutofitType プロパティを設定できます。AutofitType は [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) または [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape) に設定できます。[Normal] に設定するとシェイプはそのままでテキストだけが調整され、[Shape] に設定するとテキストが収まるようにシェイプが変更されます。TextFrame の AutofitType プロパティを設定する手順は以下の通りです:

1. [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意の shape をスライドに追加します。
4. [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) にアクセスします。
5. [Set the AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-) を設定します。
6. ファイルをディスクに保存します。
```javascript
// Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスする
    var slide = pres.getSlides().get_Item(0);
    // Rectangle タイプの AutoShape を追加する
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 150);
    // Rectangle に TextFrame を追加する
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // テキストフレームにアクセスする
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // テキストフレーム用の Paragraph オブジェクトを作成する
    var para = txtFrame.getParagraphs().get_Item(0);
    // Paragraph 用の Portion オブジェクトを作成する
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // プレゼンテーションを保存する
    pres.save(resourcesOutputPath + "formatText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **TextFrame のアンカー設定**

Aspose.Slides for Node.js via Java は、任意の TextFrame のアンカー設定を可能にします。TextAnchorType はテキストがシェイプ内のどこに配置されるかを指定します。アンカーは [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top)、[Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center)、[Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom)、[Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) または [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed) に設定できます。TextFrame のアンカーを設定する手順は以下の通りです:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意の shape をスライドに追加します。
4. [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) にアクセスします。
5. [Set TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-) を設定します。
6. ファイルをディスクに保存します。
```javascript
// Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得する
    var slide = pres.getSlides().get_Item(0);
    // Rectangle タイプの AutoShape を追加する
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Rectangle に TextFrame を追加する
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // テキストフレームにアクセスする
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(aspose.slides.TextAnchorType.Bottom);
    // テキストフレーム用の Paragraph オブジェクトを作成する
    var para = txtFrame.getParagraphs().get_Item(0);
    // Paragraph 用の Portion オブジェクトを作成する
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // プレゼンテーションを保存する
    pres.save("AnchorText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **プレゼンテーションのタブと EffectiveTabs**

All text tabulations are given in pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|

- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs collection includes all tabs (from Tabs collection and default tabs).
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) property shows distance between default tabs (3 and 4 in our example).
- EffectiveTabs.GetTabByIndex(index) with index = 0 will return first explicit tab (Position = 731), index = 1 - second tab (Position = 1241). If you try to get next tab with index = 2 it will return first default tab (Position = 1470) and etc.
- EffectiveTabs.GetTabAfterPosition(pos) used for getting next tabulation after some text. For example you have text: "Hello World!". To render such text you should know where to start draw "world!". At first, you should calculate length of "Hello" in pixels and call GetTabAfterPosition with this value. You will get next tab position to draw "world!".

## **デフォルトテキストスタイルの設定**

プレゼンテーション内のすべてのテキスト要素に同一のデフォルトテキスト書式を一度に適用する必要がある場合は、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスの `getDefaultTextStyle` メソッドを使用して好みの書式を設定できます。以下のコード例は、新規プレゼンテーションのすべてのスライドのテキストにデフォルトの太字フォント（14 pt）を設定する方法を示します。
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // トップレベルの段落書式を取得します。
    var paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);
    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    }
    presentation.save("DefaultTextStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **All-Caps エフェクトでテキストを抽出**

PowerPoint では **All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上では大文字で表示されます。Aspose.Slides でそのようなテキスト Portion を取得すると、ライブラリは入力されたままのテキストを返します。これを処理するには、[TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) を確認し、`All` と示されている場合は、返された文字列を大文字に変換して、出力がスライド上の表示と一致するようにします。

サンプル2.pptx ファイルの最初のスライドに次のテキストボックスがあるとします。

![All Caps エフェクト](all_caps_effect.png)

以下のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示します:
```js
var presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var autoShape = slide.getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    var textPortion = paragraph.getPortions().get_Item(0);

    console.log("Original text:", textPortion.getText());

    var textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == aspose.slides.TextCapType.All) {
        var text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect:", text);
    }
} finally {
    presentation.dispose();
}
```


出力:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**スライド上のテーブルのテキストを変更する方法は？**

スライド上のテーブルのテキストを変更するには、[Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) オブジェクトを使用する必要があります。テーブル内のすべてのセルを反復処理し、各セルの `TextFrame` と `ParagraphFormat` プロパティにアクセスしてテキストを変更できます。

**PowerPoint スライドのテキストにグラデーションカラーを適用する方法は？**

グラデーションカラーをテキストに適用するには、[PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) の Fill Format プロパティを使用します。Fill Format を `Gradient` に設定し、開始色と終了色、方向や透過性などのプロパティを定義してテキストにグラデーション効果を作成します。