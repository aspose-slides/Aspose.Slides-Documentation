---
title: プレゼンテーションからテキストを抽出
type: docs
weight: 90
url: /ja/nodejs-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があることは珍しくありません。そのためには、プレゼンテーション内のすべてのスライドのすべてのシェイプからテキストを抽出する必要があります。本記事では、Aspose.Slides を使用して Microsoft PowerPoint PPTX プレゼンテーションからテキストを抽出する方法を説明します。

{{% /alert %}} 

## **スライドからテキストを抽出する**

Aspose.Slides for Node.js via Java は、[SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil) クラスを提供します。このクラスは、プレゼンテーションまたはスライドから全テキストを抽出するための、オーバーロードされた静的メソッドを多数公開しています。PPTX プレゼンテーションのスライドからテキストを抽出するには、[SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil) クラスが公開している [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) オーバーロード静的メソッドを使用します。このメソッドは Slide オブジェクトをパラメータとして受け取ります。実行時に、Slide メソッドはパラメータとして渡されたスライドの全テキストを走査し、[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) オブジェクトの配列を返します。これにより、テキストに関連付けられたすべての書式情報が利用可能になります。以下のコードは、プレゼンテーションの最初のスライド上のすべてのテキストを抽出します：
```javascript
// PPTX ファイルを表す Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    for (var s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        // PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得
        var textFramesPPTX = aspose.slides.SlideUtil.getAllTextBoxes(slide);
        // TextFrame の配列をループ処理
        for (var i = 0; i < textFramesPPTX.length; i++) {
            // 現在の ITextFrame の段落をループ処理
            for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
                let para = textFramesPPTX[i].getParagraphs().get_Item(j);
                // 現在の IParagraph のポーションをループ処理
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


## **プレゼンテーションからテキストを抽出する**

プレゼンテーション全体のテキストを走査するには、SlideUtil クラスが公開している [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) 静的メソッドを使用します。このメソッドは 2 つのパラメータを受け取ります：

1. 最初に、テキストを抽出するプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) オブジェクトです。
2. 次に、マスタースライドをテキスト走査に含めるかどうかを決定するブール値です。

このメソッドは、テキスト書式情報を含む [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) オブジェクトの配列を返します。以下のコードは、マスタースライドを含むプレゼンテーションからテキストと書式情報を走査します。
```javascript
// PPTX ファイルを表す Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得
    var textFramesPPTX = aspose.slides.SlideUtil.getAllTextFrames(pres, true);
    // TextFrame 配列をループ処理
    for (var i = 0; i < textFramesPPTX.length; i++) {
        // 現在の ITextFrame の段落をループ処理
        for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
            let para = textFramesPPTX[i].getParagraphs().get_Item(j);
            // 現在の IParagraph のポーションをループ処理
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


## **カテゴリ別かつ高速なテキスト抽出**

新しい静的メソッド getPresentationText が Presentation クラスに追加されました。このメソッドには 3 つのオーバーロードがあります。
```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **FAQ**

**テキスト抽出時に Aspose.Slides は大規模プレゼンテーションをどれくらい高速に処理しますか？**

Aspose.Slides は高性能に最適化されており、大規模なプレゼンテーションでも効率的に処理でき、リアルタイムまたはバルク処理シナリオに適しています。

**Aspose.Slides はプレゼンテーション内の表やチャートからテキストを抽出できますか？**

はい、Aspose.Slides は表、チャート、その他の複雑なスライド要素からのテキスト抽出を完全にサポートしており、すべてのテキストコンテンツに簡単にアクセスし、分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスが必要ですか？**

テキスト抽出は Aspose.Slides の無料トライアル版でも可能ですが、抽出できるスライド数に制限があります。制限なく大きなプレゼンテーションを処理し、無制限に使用するには、フルライセンスの購入が推奨されます。