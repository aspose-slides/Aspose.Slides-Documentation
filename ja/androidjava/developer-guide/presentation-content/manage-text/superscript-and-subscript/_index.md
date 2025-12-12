---
title: Android のプレゼンテーションで上付き文字と下付き文字を管理する
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
description: "Android 用 Aspose.Slides で上付き文字と下付き文字をマスターし、プロフェッショナルなテキスト書式設定でプレゼンテーションを最大限に引き立てましょう。"
---

## **上付き文字と下付き文字の管理**
任意の段落部分に上付き文字および下付き文字を追加できます。Aspose.Slides のテキストフレームで上付き文字または下付き文字を使用するには、[**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-) メソッドを [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat) クラスで使用する必要があります。

このプロパティは上付き文字または下付き文字を取得または設定します（値は -100%（下付き）から 100%（上付き）まで）。例:

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドへの参照を取得します。
- スライドに [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) 種類の [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) を追加します。
- [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に関連付けられた [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) にアクセスします。
- 既存の Paragraph をクリアします。
- 上付き文字用の新しい段落オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame) の[IParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--) コレクションに追加します。
- 新しい Portion オブジェクトを作成します。
- 上付き文字を追加するために Escapement プロパティを 0 から 100 の範囲で設定します。(0 は上付き文字なし)
- [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) にテキストを設定し、段落の portion コレクションに追加します。
- 下付き文字用の新しい段落オブジェクトを作成し、ITextFrame の IParagraphs コレクションに追加します。
- 新しい Portion オブジェクトを作成します。
- 下付き文字を追加するために Escapement プロパティを 0 から -100 の範囲で設定します。(0 は下付き文字なし)
- [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion) にテキストを設定し、段落の portion コレクションに追加します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下のとおりです。
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

    // 通常テキストのポーションを作成
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // 上付き文字のポーションを作成
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // 下付き文字用の段落を作成
    IParagraph paragraph2 = new Paragraph();

    // 通常テキストのポーションを作成
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // 下付き文字のポーションを作成
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

**PDF やその他の形式にエクスポートするときに、上付き文字と下付き文字は保持されますか？**

はい、Aspose.Slides はプレゼンテーションを PDF、PPT/PPTX、画像、およびその他のサポート形式にエクスポートする際に、上付き文字および下付き文字の書式設定を正しく保持します。特殊な書式はすべての出力ファイルでそのまま残ります。

**上付き文字や下付き文字を太字や斜体などの他の書式スタイルと組み合わせることはできますか？**

はい、Aspose.Slides は単一のテキスト Portion 内でさまざまなテキストスタイルを混在させることができます。太字、斜体、下線を有効にしながら、[PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) の対応するプロパティを設定して上付き文字または下付き文字を同時に適用できます。

**テーブル、チャート、または SmartArt 内のテキストにも上付き文字と下付き文字の書式設定は適用できますか？**

はい、Aspose.Slides はテーブルやチャート要素を含むほとんどのオブジェクト内での書式設定をサポートします。SmartArt を扱う場合は、適切な要素（たとえば [SmartArtNode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartnode/)）とそのテキスト コンテナにアクセスし、同様に [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) のプロパティを設定してください。