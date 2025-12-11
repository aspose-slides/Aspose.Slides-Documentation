---
title: Android でプレゼンテーションの上付き文字と下付き文字を管理する
linktitle: 上付き文字と下付き文字
type: docs
weight: 80
url: /ja/androidjava/superscript-and-subscript/
keywords:
- 上付き文字
- 下付き文字
- 上付き文字を追加
- 下付き文字を追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 向け Aspose.Slides の上付き文字と下付き文字をマスターし、プロフェッショナルなテキスト書式設定でプレゼンテーションを最大のインパクトに引き上げます。"
---

## **上付き文字と下付き文字の管理**
任意の段落部分に上付き文字や下付き文字を追加できます。Aspose.Slides のテキストフレームで上付き文字または下付き文字を追加するには、[**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) メソッドを [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat) クラスで使用する必要があります。

このプロパティは上付き文字または下付き文字を取得または設定します（値は -100%（下付き）から 100%（上付き）まで）。例として：

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) タイプの [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) を追加します。
- [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に関連付けられた [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) にアクセスします。
- 既存の段落をクリアします
- 上付き文字を保持する新しい段落オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) の [IParagraphs collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) に追加します。
- 新しい Portion オブジェクトを作成します
- 上付き文字を追加するために、Portion の Escapement プロパティを 0 から 100 の範囲で設定します。(0 は上付き文字なしを意味します)
- [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) にテキストを設定し、段落の Portion コレクションに追加します。
- 下付き文字を保持する新しい段落オブジェクトを作成し、ITextFrame の IParagraphs コレクションに追加します。
- 新しい Portion オブジェクトを作成します
- 下付き文字を追加するために、Portion の Escapement プロパティを 0 から -100 の範囲で設定します。(0 は下付き文字なしを意味します)
- [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) にテキストを設定し、段落の Portion コレクションに追加します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記の手順の実装例は以下の通りです。
```java
// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // スライドを取得
    ISlide slide = pres.getSlides().get_Item(0);

    // テキスト ボックスを作成
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

    // テキスト ボックスに段落を追加
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**PDFや他の形式にエクスポートするときに、上付き文字と下付き文字は保持されますか？**

はい、Aspose.Slides はプレゼンテーションを PDF、PPT/PPTX、画像、その他のサポートされている形式にエクスポートする際に、上付き文字および下付き文字の書式設定を適切に保持します。すべての出力ファイルで特殊な書式はそのまま維持されます。

**上付き文字や下付き文字を太字や斜体などの他の書式スタイルと組み合わせることはできますか？**

はい、Aspose.Slides では単一の Portion 内でさまざまなテキストスタイルを組み合わせることができます。太字、斜体、下線を有効にし、同時に [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) の対応するプロパティを設定することで上付き文字または下付き文字を適用できます。

**テーブル、チャート、SmartArt 内のテキストにも上付き文字や下付き文字の書式設定は適用できますか？**

はい、Aspose.Slides はテーブルやチャート要素など、ほとんどのオブジェクト内での書式設定をサポートしています。SmartArt を操作する場合は、適切な要素（例: [SmartArtNode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartnode/)）とそのテキストコンテナにアクセスし、同様に [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) のプロパティを設定する必要があります。