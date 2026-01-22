---
title: JavaScript で PowerPoint テキストをフォーマット
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/nodejs-java/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
- 段落の配置
- テキストスタイル
- テキストの背景
- テキストの透過性
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキストの回転
- 回転角度
- テキストフレーム
- 行間隔
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: JavaScript と Aspose.Slides for Node.js を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。
---

## **テキストのハイライト**

Method [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) has been added to [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) class and [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) class.

テキストのサンプルを使用して背景色でテキストの一部をハイライトでき、PowerPoint 2019 の「テキストのハイライト」ツールと同様です。

以下のコードスニペットは、この機能の使用方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// すべての単語 'important' をハイライト
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// 個別の 'the' の出現すべてをハイライト
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

Method [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) has been added to [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) class and [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) class.

正規表現を使用して背景色でテキストの一部をハイライトでき、PowerPoint 2019 の「テキストのハイライト」ツールと同様です。

以下のコードスニペットは、この機能の使用方法を示しています：
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

Aspose.Slides を使用すると、テキストの背景色を任意に指定できます。

この JavaScript コードは、テキスト全体の背景色を設定する方法を示しています：
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


この JavaScript コードは、テキストの一部だけの背景色を設定する方法を示しています：
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

テキストの書式設定は、文書やプレゼンテーションを作成する際の重要な要素のひとつです。Aspose.Slides for Node.js via Java はスライドへのテキスト追加をサポートしていますが、本項ではスライド内のテキスト段落の配置を制御する方法を説明します。以下の手順に従って Aspose.Slides for Node.js via Java を使用してテキスト段落を配置してください：

1. [Presentation] クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに存在するプレースホルダーシェイプにアクセスし、[AutoShape] に型キャストします。
4. [AutoShape] が公開する [TextFrame] から、配置する必要がある Paragraph を取得します。
5. Paragraph を配置します。Paragraph は右揃え、左揃え、中央揃え、両端揃えに設定できます。
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例を以下に示します。
```javascript
// PPTXファイルを表すPresentationオブジェクトをインスタンス化する
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // 最初のスライドにアクセスする
    var slide = pres.getSlides().get_Item(0);
    // スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShapeに型キャストする
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
    // プレゼンテーションをPPTXファイルとして保存する
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキストの透過性の設定**

この記事では、Aspose.Slides for Node.js via Java を使用して任意のテキストシェイプの透過性プロパティを設定する方法を示します。テキストの透過性を設定するには、以下の手順に従ってください：

1. [Presentation] クラスのインスタンスを作成します。
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
    // 透過率を0パーセントに設定する
    outerShadowEffect.getShadowColor().setColor(java.newInstanceSync("java.awt.Color", shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));
    pres.save("transparency-2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキストの文字間隔の設定**

Aspose.Slides を使用すると、テキストボックス内の文字間のスペースを設定できます。これにより、文字間隔を広げたり狭めたりして、行やテキストブロックの視覚的密度を調整できます。

この JavaScript コードは、ある行の文字間隔を広げ、別の行の文字間隔を狭める方法を示しています：
```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// 拡張
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// 縮小
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **段落のフォントプロパティの管理**

プレゼンテーションには通常、テキストと画像が含まれます。テキストは、特定のセクションや単語を強調したり、企業スタイルに合わせたりするためにさまざまな方法で書式設定できます。テキストの書式設定は、プレゼンテーションコンテンツの外観を変えるのに役立ちます。本記事では、Aspose.Slides for Node.js via Java を使用してスライド上のテキスト段落のフォントプロパティを設定する方法を示します。段落のフォントプロパティを管理する手順は以下の通りです：

1. [Presentation] クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内のプレースホルダーシェイプにアクセスし、[AutoShape] に型キャストします。
4. [AutoShape] が公開する [TextFrame] から [Paragraph] を取得します。
5. 段落を両端揃えにします。
6. 段落のテキスト Portion にアクセスします。
7. FontData を使用してフォントを定義し、テキスト Portion のフォントを設定します。
　- フォントを太字に設定します。
　- フォントをイタリック体に設定します。
8. [Portion] オブジェクトが提供する [getFillFormat] を使用してフォントの色を設定します。
9. 変更したプレゼンテーションを [PPTX] ファイルに保存します。

上記手順の実装例を以下に示します。これは、装飾のないプレゼンテーションを取得し、スライドのひとつのフォントをフォーマットします。
```javascript
    // PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
    var pres = new aspose.slides.Presentation("FontProperties.pptx");
    try {
        // スライド位置を使ってスライドにアクセスする
        var slide = pres.getSlides().get_Item(0);
        // スライド内の最初と二番目のプレースホルダーにアクセスし、AutoShape に型キャストする
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
        // フォントをイタリックに設定する
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

Portion は、段落内で同一の書式スタイルを持つテキストを保持するために使用されます。本記事では、Aspose.Slides for Node.js via Java を使用してテキストボックスを作成し、特定のフォントやフォントファミリカテゴリのさまざまなプロパティを定義する方法を示します。テキストボックスを作成し、そのテキストのフォントプロパティを設定する手順は以下の通りです：

1. [Presentation] クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに [Rectangle] タイプの [AutoShape] を追加します。
4. [AutoShape] に関連付けられた塗りつぶしスタイルを削除します。
5. AutoShape の TextFrame にアクセスします。
6. TextFrame にテキストを追加します。
7. [TextFrame] に関連付けられた Portion オブジェクトにアクセスします。
8. [Portion] に使用するフォントを定義します。
9. Portion オブジェクトが提供する関連プロパティを使用して、太字、イタリック、下線、色、サイズなどの他のフォントプロパティを設定します。
10. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例を以下に示します。
```javascript
// プレゼンテーションをインスタンス化する
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
    // フォントのイタリックプロパティを設定する
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // フォントの下線プロパティを設定する
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // フォントの高さを設定する
    port.getPortionFormat().setFontHeight(25);
    // フォントの色を設定する
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // PPTX をディスクに保存する
    pres.save("SetTextFontProperties_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキストのフォントサイズの設定**

Aspose.Slides を使用すると、段落内の既存テキストや、後から追加されるテキストのフォントサイズを好きな大きさに設定できます。

この JavaScript コードは、段落内のテキストのフォントサイズを設定する方法を示しています：
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // たとえば最初のシェイプを取得します。
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        var autoShape = shape;
        // たとえば最初の段落を取得します。
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // 段落内のすべてのテキストポーションのデフォルトフォントサイズを20ptに設定します。
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // 段落内の現在のテキストポーションのフォントサイズを20ptに設定します。
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

Aspose.Slides for Node.js via Java は、開発者がテキストを回転させることを可能にします。テキストは [Horizontal]、[Vertical]、[Vertical270]、[WordArtVertical]、[EastAsianVertical]、[MongolianVertical]、[WordArtVerticalRightToLeft] のいずれかとして表示できます。任意の TextFrame のテキストを回転させるには、以下の手順に従ってください：

1. [Presentation] クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. [TextFrame] にアクセスします。
5. [Rotate the text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-) を回転させます。
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
    // 段落用の Portion オブジェクトを作成する
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

Aspose.Slides for Node.js via Java は、TextFrame のカスタム回転角度の設定に対応しました。本項では、例を示しながら Aspose.Slides の RotationAngle プロパティの設定方法を解説します。新しいメソッド [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) と [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) が [TextFrameFormat] クラスに追加され、TextFrame のカスタム回転角度を設定できるようになりました。RotationAngle を設定するには、以下の手順に従ってください：

1. [Presentation] クラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. [Set RotationAngle property](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) を設定します。
4. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、RotationAngle プロパティを設定しています。
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
        // 段落用の Portion オブジェクトを作成する
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


## **段落の行間隔**

Aspose.Slides は [`ParagraphFormat`] の下に `SpaceAfter`、`SpaceBefore`、`SpaceWithin` というプロパティを提供し、段落の行間隔を管理できます。これら 3 つのプロパティは以下のように使用します：

* 段落の行間隔をパーセンテージで指定する場合は、正の値を使用します。
* 段落の行間隔をポイントで指定する場合は、負の値を使用します。

例えば、`SpaceBefore` プロパティを -16 に設定すると、段落に 16pt の行間隔が適用されます。

1. テキストを含む AutoShape が入ったプレゼンテーションをロードします。
2. インデックスを通じてスライドの参照を取得します。
3. TextFrame にアクセスします。
4. Paragraph にアクセスします。
5. Paragraph のプロパティを設定します。
6. プレゼンテーションを保存します。

この JavaScript コードは、段落の行間隔を指定する方法を示しています：
```javascript
// Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // インデックスでスライドの参照を取得する
    var sld = pres.getSlides().get_Item(0);
    // TextFrame にアクセスする
    var tf1 = sld.getShapes().get_Item(0).getTextFrame();
    // 段落にアクセスする
    var para = tf1.getParagraphs().get_Item(0);
    // 段落のプロパティを設定する
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

本項では、テキストフレームのさまざまな書式設定プロパティを紹介します。この記事では、TextFrame の AutofitType プロパティ、テキストのアンカー設定、テキストの回転設定方法について説明します。Aspose.Slides for Node.js via Java を使用すると、任意のテキストフレームの AutofitType プロパティを設定できます。AutofitType は [Normal] または [Shape] に設定でき、[Normal] にするとシェイプは変わらずテキストだけが調整され、[Shape] にするとテキストが収まるようシェイプが変更されます。AutofitType プロパティを設定するには、以下の手順に従ってください：

1. [Presentation] クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. [TextFrame] にアクセスします。
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
    // 段落用の Portion オブジェクトを作成する
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

Aspose.Slides for Node.js via Java は、任意の TextFrame のアンカーを設定できます。TextAnchorType はテキストがシェイプ内のどこに配置されるかを指定し、[Top]、[Center]、[Bottom]、[Justified]、[Distributed] のいずれかに設定できます。TextFrame のアンカーを設定するには、以下の手順に従ってください：

1. [Presentation] クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. [TextFrame] にアクセスします。
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
    // 段落用の Portion オブジェクトを作成する
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

すべてのテキストタブはピクセル単位で示されます。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2つの明示タブと2つのデフォルトタブ**|

- EffectiveTabs.ExplicitTabCount（この例では 2）は Tabs.Count と同じです。
- EffectiveTabs コレクションには、Tabs コレクションとデフォルトタブのすべてが含まれます。
- EffectiveTabs.ExplicitTabCount（この例では 2）は Tabs.Count と同じです。
- EffectiveTabs.DefaultTabSize（294）は、デフォルトタブ（例では 3 と 4）の間隔を示します。
- EffectiveTabs.GetTabByIndex(index) で index = 0 は最初の明示タブ（位置 = 731）、index = 1 は2番目のタブ（位置 = 1241）を返します。index = 2 を指定すると最初のデフォルトタブ（位置 = 1470）を返すなどです。
- EffectiveTabs.GetTabAfterPosition(pos) は、あるテキストの後の次のタブ位置を取得するために使用します。例としてテキスト "Hello World!" がある場合、"world!" を描画開始する位置を知る必要があります。まず "Hello" のピクセル長さを計算し、その値で GetTabAfterPosition を呼び出すと、"world!" を描画する次のタブ位置が得られます。

## **デフォルトテキストスタイルの設定**

プレゼンテーション内のすべてのテキスト要素に同じデフォルトテキスト書式を一括で適用したい場合は、[Presentation] クラスの `getDefaultTextStyle` メソッドを使用して好みの書式を設定できます。以下のコード例は、新規プレゼンテーションのすべてのスライドのテキストに対してデフォルトの太字フォント（14 pt）を設定する方法を示しています。
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // 最上位レベルの段落フォーマットを取得します。
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


## **全大文字効果でテキストを抽出**

PowerPoint では **All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上では大文字で表示されます。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは元の入力通りの文字列を返します。これに対処するには、[TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) を確認し、`All` が示されている場合は返された文字列を大文字に変換して、出力がスライド上の表示と一致するようにします。

最初のスライドの sample2.pptx ファイルに次のテキストボックスがあるとします。

![The All Caps effect](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示しています：
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


Output:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**スライド上のテーブルのテキストを変更する方法は？**

スライド上のテーブルのテキストを変更するには、[Table] オブジェクトを使用します。テーブル内のすべてのセルを走査し、各セルの `TextFrame` と `ParagraphFormat` プロパティにアクセスしてテキストを変更できます。

**PowerPoint スライドのテキストにグラデーションカラーを適用する方法は？**

テキストにグラデーションカラーを適用するには、[PortionFormat] の Fill Format プロパティを使用します。Fill Format を `Gradient` に設定し、開始色と終了色、方向や透過率などのプロパティを指定してテキストにグラデーション効果を付与できます。