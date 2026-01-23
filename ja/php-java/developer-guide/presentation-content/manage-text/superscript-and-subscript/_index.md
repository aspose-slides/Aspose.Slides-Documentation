---
title: PHP を使用したプレゼンテーションでの上付きと下付きの管理
linktitle: 上付きと下付き
type: docs
weight: 80
url: /ja/php-java/superscript-and-subscript/
keywords:
- 上付き
- 下付き
- 上付きの追加
- 下付きの追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java を介した PHP 用 Aspose.Slides で上付きと下付きをマスターし、プロフェッショナルなテキスト書式設定でプレゼンテーションのインパクトを最大化しましょう。"
---

## **上付きテキストと下付きテキストの管理**
任意の段落部分に上付きテキストまたは下付きテキストを追加できます。Aspose.Slides のテキスト フレームに上付きまたは下付きテキストを追加するには、[PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat) クラスの[**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) メソッドを使用する必要があります。

このプロパティは上付きまたは下付きテキストを取得または設定します（値は -100%（下付き）から 100%（上付き）まで）。例:

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに[Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) タイプの[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
- [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) に関連付けられた[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
- 既存の Paragraph をクリアします。
- 上付きテキストを保持する新しい段落オブジェクトを作成し、[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) の[IParagraphs コレクション](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) に追加します。
- 新しい Portion オブジェクトを作成します。
- 上付きテキストを追加するために Escapement プロパティを 0〜100 の範囲で設定します。（0 は上付きなし）
- [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) にテキストを設定し、段落の Portion コレクションに追加します。
- 下付きテキストを保持する新しい段落オブジェクトを作成し、ITextFrame の IParagraphs コレクションに追加します。
- 新しい Portion オブジェクトを作成します。
- 下付きテキストを追加するために Escapement プロパティを 0〜-100 の範囲で設定します。（0 は下付きなし）
- [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) にテキストを設定し、段落の Portion コレクションに追加します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装は以下の通りです。
```php
  # PPTX を表す Presentation クラスのインスタンス化
  $pres = new Presentation();
  try {
    # スライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # テキストボックスを作成
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # 上付きテキスト用の段落を作成
    $superPar = new Paragraph();
    # 通常テキストの部分を作成
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # 上付きテキストの部分を作成
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # 下付きテキスト用の段落を作成
    $paragraph2 = new Paragraph();
    # 通常テキストの部分を作成
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # 下付きテキストの部分を作成
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # 段落をテキストボックスに追加
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**PDF やその他の形式にエクスポートしたときに上付きテキストと下付きテキストは保持されますか？**

はい、Aspose.Slides はプレゼンテーションを PDF、PPT/PPTX、画像、その他のサポート形式にエクスポートする際に上付きおよび下付き書式を正しく保持します。特殊な書式はすべての出力ファイルでそのまま残ります。

**上付きテキストや下付きテキストを太字や斜体などの他の書式と組み合わせることはできますか？**

はい、Aspose.Slides は単一の Portion 内でさまざまなテキスト スタイルを組み合わせることをサポートします。太字、斜体、下線と同時に上付きまたは下付きを書式設定するには、[PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) の該当プロパティを設定します。

**テーブル、チャート、SmartArt 内のテキストにも上付き・下付き書式は適用できますか？**

はい、Aspose.Slides はテーブルやチャート要素を含む多くのオブジェクト内での書式設定をサポートしています。SmartArt を操作する場合は、適切な要素（例: [SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/)）とそのテキスト コンテナにアクセスし、同様に[PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) のプロパティを設定してください。