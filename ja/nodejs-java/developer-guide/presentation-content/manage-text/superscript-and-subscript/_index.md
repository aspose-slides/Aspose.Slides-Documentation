---
title: 上付き文字と下付き文字
type: docs
weight: 80
url: /ja/nodejs-java/superscript-and-subscript/
---

## **上付き文字と下付き文字のテキストを管理**

任意の段落部分内に上付き文字や下付き文字のテキストを追加できます。Aspose.Slides のテキストフレームに上付き文字または下付き文字のテキストを追加するには、[**setEscapement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) メソッド（[PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat) クラス）を使用する必要があります。

このプロパティは上付き文字または下付き文字のテキストを取得または設定します（値は -100%（下付き）から 100%（上付き）まで）。例として：

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに [Rectangle] タイプの [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) を追加します。
- [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) に関連付けられた [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) にアクセスします。
- 既存の Paragraph をクリアします。
- 上付き文字を保持する新しい段落オブジェクトを作成し、[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) の [Paragraphs collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getParagraphs--) に追加します。
- 新しい Portion オブジェクトを作成します。
- 上付き文字を追加するために、Portion の Escapement プロパティを 0 から 100 の範囲で設定します。（0 は上付きなし）
- [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) にテキストを設定し、段落の Portion コレクションに追加します。
- 下付き文字を保持する新しい段落オブジェクトを作成し、ITextFrame の IParagraphs コレクションに追加します。
- 新しい Portion オブジェクトを作成します。
- 下付き文字を追加するために、Portion の Escapement プロパティを 0 から -100 の範囲で設定します。（0 は下付きなし）
- [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) にテキストを設定し、段落の Portion コレクションに追加します。
- プレゼンテーションを PPTX ファイルとして保存します。

```javascript
// PPTX を表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // スライドを取得
    var slide = pres.getSlides().get_Item(0);
    // テキストボックスを作成
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // 上付き文字用の段落を作成
    var superPar = new aspose.slides.Paragraph();
    // 通常テキストの Portion を作成
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // 上付き文字の Portion を作成
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // 下付き文字用の段落を作成
    var paragraph2 = new aspose.slides.Paragraph();
    // 通常テキストの Portion を作成
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // 下付き文字の Portion を作成
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // テキストボックスに段落を追加
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**PDFや他の形式にエクスポートする際に、上付き文字と下付き文字は保持されますか？**

はい、Aspose.Slides は PDF、PPT/PPTX、画像、その他のサポートされている形式へプレゼンテーションをエクスポートする際に、上付き文字および下付き文字の書式設定を適切に保持します。専門的な書式はすべての出力ファイルでそのまま残ります。

**上付き文字と下付き文字は、太字や斜体などの他の書式スタイルと組み合わせることができますか？**

はい、Aspose.Slides は単一のテキスト Portion 内でさまざまなテキストスタイルを組み合わせることをサポートします。Bold、Italic、Underline を有効にし、同時に上付き文字または下付き文字を適用するには、[PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) の該当プロパティを設定します。

**テーブル、チャート、または SmartArt 内のテキストに対して、上付き文字と下付き文字の書式設定は機能しますか？**

はい、Aspose.Slides はテーブルやチャート要素など、ほとんどのオブジェクト内での書式設定をサポートします。SmartArt を操作する場合は、適切な要素（例: [SmartArtNode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/)) とそのテキスト コンテナにアクセスし、[PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) のプロパティを同様に設定する必要があります。