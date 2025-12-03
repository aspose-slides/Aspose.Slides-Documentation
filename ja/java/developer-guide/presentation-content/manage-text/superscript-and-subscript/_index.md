---
title: Java を使用したプレゼンテーションでの上付き文字と下付き文字の管理
linktitle: 上付き文字と下付き文字
type: docs
weight: 80
url: /ja/java/superscript-and-subscript/
keywords:
- 上付き文字
- 下付き文字
- 上付き文字の追加
- 下付き文字の追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java で上付き文字と下付き文字をマスターし、プロフェッショナルなテキスト書式設定でプレゼンテーションを最大のインパクトに高めましょう。"
---

## **上付き文字と下付き文字の管理**
任意の段落部分内に上付き文字や下付き文字を追加できます。Aspose.Slides のテキストフレームに上付き文字または下付き文字のテキストを追加するには、[**setEscapement**](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) メソッドを [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PortionFormat) クラスで使用する必要があります。

このプロパティは上付き文字または下付き文字のテキストを取得または設定します（値は -100%（下付き）から 100%（上付き）まで）。例として:

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) タイプの [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) を追加します。
- [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) に関連付けられた [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) にアクセスします。
- 既存の段落をクリアします
- 上付き文字を保持する新しい段落オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame) の [IParagraphs collection](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getParagraphs--) に追加します。
- 新しい Portion オブジェクトを作成します
- 上付き文字を追加するために Portion の Escapement プロパティを 0 から 100 の範囲で設定します。(0 は上付き文字なしを意味します)
- [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) にテキストを設定し、段落の Portion コレクションに追加します。
- 下付き文字を保持する新しい段落オブジェクトを作成し、ITextFrame の IParagraphs コレクションに追加します。
- 新しい Portion オブジェクトを作成します
- 下付き文字を追加するために Portion の Escapement プロパティを 0 から -100 の範囲で設定します。(0 は下付き文字なしを意味します)
- [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) にテキストを設定し、段落の Portion コレクションに追加します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下のとおりです。
```java
// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // スライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // テキストボックスを作成
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // 上付き文字用の段落を作成
    IParagraph superPar = new Paragraph();

    // 通常テキストの Portion を作成
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // 上付き文字の Portion を作成
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // 下付き文字用の段落を作成
    IParagraph paragraph2 = new Paragraph();

    // 通常テキストの Portion を作成
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // 下付き文字の Portion を作成
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // 段落をテキストボックスに追加
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**PDFや他の形式にエクスポートする際に、上付き文字と下付き文字は保持されますか？**

はい、Aspose.Slides はプレゼンテーションを PDF、PPT/PPTX、画像、その他のサポートされている形式にエクスポートする際、上付き文字と下付き文字の書式設定を正しく保持します。特殊な書式はすべての出力ファイルでそのまま残ります。

**上付き文字や下付き文字を太字や斜体などの他の書式スタイルと組み合わせることはできますか？**

はい、Aspose.Slides は単一の Portion 内でさまざまなテキストスタイルを混在させることができます。太字、斜体、下線を有効にし、対応するプロパティを [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) で設定することで、上付き文字または下付き文字を同時に適用できます。

**テーブル、チャート、または SmartArt 内のテキストでも上付き文字や下付き文字の書式設定は機能しますか？**

はい、Aspose.Slides はテーブルやチャート要素を含むほとんどのオブジェクト内での書式設定をサポートしています。SmartArt を操作する場合、適切な要素（例: [SmartArtNode](https://reference.aspose.com/slides/java/com.aspose.slides/smartartnode/)）とそのテキストコンテナにアクセスし、同様に [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) のプロパティを設定する必要があります。