---
title: プレゼンテーションで PHP を使用した上付き文字と下付き文字の管理
linktitle: 上付き文字と下付き文字
type: docs
weight: 80
url: /ja/php-java/superscript-and-subscript/
keywords:
- 上付き文字
- 下付き文字
- 上付き文字の追加
- 下付き文字の追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java で上付き文字と下付き文字をマスターし、プロフェッショナルなテキスト書式設定でプレゼンテーションを最大限に引き立てます。"
---

## **上付き文字と下付き文字の管理**
任意の段落部分に上付き文字や下付き文字を追加できます。Aspose.Slides のテキスト フレームで上付き文字または下付き文字を追加するには、[**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-) メソッドを [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat) クラスで使用する必要があります。

このプロパティは上付き文字または下付き文字を取得または設定します（値は -100%（下付き）から 100%（上付き）まで）。例えば:

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) タイプの [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) を追加します。
- [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) に関連付けられた [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) にアクセスします。
- 既存の Paragraphs をクリアします。
- 上付き文字を保持する新しい段落オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) の [IParagraphs collection](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getParagraphs--) に追加します。
- 新しい Portion オブジェクトを作成します。
- 上付き文字を追加するために、Portion の Escapement プロパティを 0 から 100 の範囲で設定します。（0 は上付きなし）
- [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) にテキストを設定し、段落の Portion コレクションに追加します。
- 下付き文字を保持する新しい段落オブジェクトを作成し、ITextFrame の IParagraphs コレクションに追加します。
- 新しい Portion オブジェクトを作成します。
- 下付き文字を追加するために、Portion の Escapement プロパティを 0 から -100 の範囲で設定します。（0 は下付きなし）
- [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) にテキストを設定し、段落の Portion コレクションに追加します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記の手順の実装例を以下に示します。
```php
  # PPTX を表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # スライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # テキスト ボックスを作成
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # 上付き文字用の段落を作成
    $superPar = new Paragraph();
    # 通常のテキストを持つポーションを作成
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # 上付き文字のポーションを作成
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # 下付き文字用の段落を作成
    $paragraph2 = new Paragraph();
    # 通常のテキストを持つポーションを作成
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # 下付き文字のポーションを作成
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # テキスト ボックスに段落を追加
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **よくある質問**

**PDFや他の形式にエクスポートするときに上付き文字と下付き文字は保持されますか？**

はい、Aspose.Slides はプレゼンテーションを PDF、PPT/PPTX、画像、その他のサポートされている形式にエクスポートする際に、上付き文字と下付き文字の書式設定を正しく保持します。特別な書式はすべての出力ファイルでそのまま維持されます。

**上付き文字や下付き文字を太字や斜体などの他の書式スタイルと組み合わせられますか？**

はい、Aspose.Slides は単一の Portion 内でさまざまなテキストスタイルを混在させることができます。太字、斜体、下線を有効にし、同時に上付き文字または下付き文字を適用するには、[PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) の該当プロパティを設定します。

**テーブル、チャート、または SmartArt 内のテキストにも上付き文字や下付き文字の書式設定は機能しますか？**

はい、Aspose.Slides はテーブルやチャート要素を含むほとんどのオブジェクト内での書式設定をサポートしています。SmartArt を操作する場合は、適切な要素（例: [SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/)) とそのテキスト コンテナーにアクセスし、同様の方法で [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) のプロパティを設定する必要があります。