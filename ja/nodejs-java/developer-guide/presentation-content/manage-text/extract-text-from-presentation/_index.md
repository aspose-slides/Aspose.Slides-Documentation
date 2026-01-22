---
title: JavaScript のプレゼンテーションから高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/nodejs-java/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからテキストを抽出
- プレゼンテーションからテキストを抽出
- PowerPoint からテキストを抽出
- OpenDocument からテキストを抽出
- PPT からテキストを抽出
- PPTX からテキストを抽出
- ODP からテキストを抽出
- テキスト取得
- スライドからテキストを取得
- プレゼンテーションからテキストを取得
- PowerPoint からテキストを取得
- OpenDocument からテキストを取得
- PPT からテキストを取得
- PPTX からテキストを取得
- ODP からテキストを取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルで段階的なガイドに従って、時間を節約しましょう。"
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があることは珍しくありません。そのためには、プレゼンテーション内のすべてのスライドにあるすべてのシェイプからテキストを抽出する必要があります。本記事では、Aspose.Slides を使用して Microsoft PowerPoint PPTX プレゼンテーションからテキストを抽出する方法を説明します。 

{{% /alert %}} 

## **スライドからテキストを抽出**

Aspose.Slides for Node.js via Java は [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil) クラスを提供します。このクラスは、プレゼンテーションまたはスライドからテキスト全体を抽出するための多数のオーバーロードされた静的メソッドを公開しています。PPTX プレゼンテーションのスライドからテキストを抽出するには、[SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil) クラスが提供するオーバーロードされた静的メソッド [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) を使用します。このメソッドは Slide オブジェクトをパラメータとして受け取ります。実行すると、Slide メソッドはパラメータとして渡されたスライドからテキスト全体を走査し、[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) オブジェクトの配列を返します。これにより、テキストに関連付けられたすべての書式情報を取得できます。以下のコードは、プレゼンテーションの最初のスライド上のすべてのテキストを抽出します:
```javascript
// PPTX ファイルを表す Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    for (var s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        // PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得
        var textFramesPPTX = aspose.slides.SlideUtil.getAllTextBoxes(slide);
        // TextFrame の配列をループ
        for (var i = 0; i < textFramesPPTX.length; i++) {
            // 現在の ITextFrame の段落をループ
            for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
                let para = textFramesPPTX[i].getParagraphs().get_Item(j);
                // 現在の IParagraph の部分文字列（ポーション）をループ
                for (let k = 0; k < para.getPortions().getCount(); k++) {
                    let port = para.getPortions().get_Item(k);
                    // 現在のポーションのテキストを表示
                    console.log(port.getText());
                    // テキストのフォント高さを表示
                    console.log(port.getPortionFormat().getFontHeight());
                    // テキストのフォント名を表示
                    if (port.getPortionFormat().getLatinFont() != null) {
                        console.log(port.getPortionFormat().getLatinFont().getFontName());
                    }
                });
            }
        }
    });
} finally {
    pres.dispose();
}
```


## **プレゼンテーションからテキストを抽出**

プレゼンテーション全体からテキストを走査するには、SlideUtil クラスが提供する静的メソッド [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) を使用します。このメソッドは 2 つのパラメータを受け取ります。

1. 最初に、テキストを抽出する対象のプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) オブジェクト。
2. 次に、テキストを走査する際にマスタースライドを含めるかどうかを示すブール値。
このメソッドは、テキスト書式情報を含む [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) オブジェクトの配列を返します。以下のコードは、マスタースライドを含むプレゼンテーションからテキストと書式情報を走査します。
```javascript
// PPTX ファイルを表す Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得
    var textFramesPPTX = aspose.slides.SlideUtil.getAllTextFrames(pres, true);
    // TextFrame の配列をループ
    for (var i = 0; i < textFramesPPTX.length; i++) {
        // 現在の ITextFrame の段落をループ
        for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
            let para = textFramesPPTX[i].getParagraphs().get_Item(j);
            // 現在の IParagraph の部分文字列をループ
            for (let k = 0; k < para.getPortions().getCount(); k++) {
                let port = para.getPortions().get_Item(k);
                // 現在のポーションのテキストを表示
                console.log(port.getText());
                // テキストのフォント高さを表示
                console.log(port.getPortionFormat().getFontHeight());
                // テキストのフォント名を表示
                if (port.getPortionFormat().getLatinFont() != null) {
                    console.log(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **分類された高速テキスト抽出**

Presentation クラスに新しい静的メソッド getPresentationText が追加されました。このメソッドには 3 つのオーバーロードがあります:
```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[PresentationText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText#getSlidesText--) method which returns an array of `SlideText` objects. Every object represent the text on the corresponding slide. `SlideText` object have the following methods:

- `SlideText.getText` - The text on the slide's shapes
- `SlideText.getMasterText` - The text on the master page's shapes for this slide
- `SlideText.getLayoutText` - The text on the layout page's shapes for this slide
- `SlideText.getNotesText` - The text on the notes page's shapes for this slide

There is also a `SlideText` class which implements the `SlideText` class.

The new API can be used like this:

```javascript
var text1 = aspose.slides.PresentationFactory.getInstance().getPresentationText("presentation.pptx", aspose.slides.TextExtractionArrangingMode.Unarranged);
console.log(text1.getSlidesText()[0].getText());
console.log(text1.getSlidesText()[0].getLayoutText());
console.log(text1.getSlidesText()[0].getMasterText());
console.log(text1.getSlidesText()[0].getNotesText());
```


## **よくある質問**

**テキスト抽出時に Aspose.Slides は大規模なプレゼンテーションをどれくらい高速に処理できますか？**

Aspose.Slides は高性能に最適化されており、大規模なプレゼンテーションでも効率的に処理できるため、リアルタイムまたはバルク処理のシナリオに適しています。

**Aspose.Slides はプレゼンテーション内の表やチャートからテキストを抽出できますか？**

はい、Aspose.Slides は表、チャート、その他の複雑なスライド要素からのテキスト抽出を完全にサポートしており、すべてのテキストコンテンツに簡単にアクセスし分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスが必要ですか？**

Aspose.Slides の無料トライアル版でもテキストを抽出できますが、スライド数に制限があるなどいくつかの制約があります。制限なく使用し、より大きなプレゼンテーションを処理するには、フルライセンスの購入が推奨されます。