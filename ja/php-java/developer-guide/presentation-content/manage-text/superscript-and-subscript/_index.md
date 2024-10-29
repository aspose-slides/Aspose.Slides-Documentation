---
title: 上付き文字と下付き文字
type: docs
weight: 80
url: /ja/php-java/superscript-and-subscript/
---

## **上付き文字と下付き文字のテキストを管理する**
任意の段落部分に上付き文字と下付き文字のテキストを追加できます。Aspose.Slidesのテキストフレームに上付き文字または下付き文字のテキストを追加するには、[**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-)メソッドを[PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat)クラスで使用する必要があります。

このプロパティは、上付き文字または下付き文字のテキストを返すか設定します（値は-100%（下付き文字）から100%（上付き文字）まで）。例えば:

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに[Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle)型の[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)を追加します。
- [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)に関連付けられた[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame)にアクセスします。
- 既存の段落をクリアします。
- 上付き文字を保持するための新しい段落オブジェクトを作成し、それを[IParagraphs collection](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getParagraphs--)に追加します。
- 新しい部分オブジェクトを作成します。
- 上付き文字を追加するために0から100の範囲でEscapementプロパティを設定します。（0は上付き文字なしを意味します）
- [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)のテキストを設定し、それを段落の部分コレクションに追加します。
- 下付き文字を保持するための新しい段落オブジェクトを作成し、それをITextFrameのIParagraphsコレクションに追加します。
- 新しい部分オブジェクトを作成します。
- 下付き文字を追加するために0から-100の範囲でEscapementプロパティを設定します。（0は下付き文字なしを意味します）
- [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)のテキストを設定し、それを段落の部分コレクションに追加します。
- プレゼンテーションをPPTXファイルとして保存します。

上記のステップの実装は以下の通りです。

```php
  # PPTXを表すPresentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # スライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # テキストボックスを作成
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # 上付き文字用の段落を作成
    $superPar = new Paragraph();
    # 通常のテキストを持つ部分を作成
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # 上付き文字を持つ部分を作成
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # 下付き文字用の段落を作成
    $paragraph2 = new Paragraph();
    # 通常のテキストを持つ部分を作成
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # 下付き文字を持つ部分を作成
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