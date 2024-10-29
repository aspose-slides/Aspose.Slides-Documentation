---
title: PowerPoint段落の管理
type: docs
weight: 40
url: /ja/php-java/manage-paragraph/
keywords: "PowerPoint段落の追加, 段落の管理, 段落インデント, 段落プロパティ, HTMLテキスト, 段落テキストのエクスポート, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションで段落、テキスト、インデント、およびプロパティを作成および管理する"
---

Aspose.Slidesは、PowerPointのテキスト、段落、および部分を操作するために必要なすべてのインターフェースとクラスを提供します。

* Aspose.Slidesは、段落を表すオブジェクトを追加するための[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)インターフェースを提供します。`ITextFame`オブジェクトには、1つまたは複数の段落を持つことができます（各段落はキャリッジリターンを通じて作成されます）。
* Aspose.Slidesは、部分を表すオブジェクトを追加するための[IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/)インターフェースを提供します。`IParagraph`オブジェクトには、1つまたは複数の部分（iPortionsオブジェクトのコレクション）を持つことができます。
* Aspose.Slidesは、テキストとそのフォーマットプロパティを表すオブジェクトを追加するための[IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/)インターフェースを提供します。

`IParagraph`オブジェクトは、その基盤となる`IPortion`オブジェクトを介して、異なるフォーマットプロパティを持つテキストを処理することができます。

## **複数の部分を含む複数の段落を追加する**

これらの手順では、3つの段落を含むテキストフレームを追加し、各段落が3つの部分を含む方法を示します：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. スライドに長方形の[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)に関連付けられているITextFrameを取得します。
5. 2つの[IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/)オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)の`IParagraphs`コレクションに追加します。
6. 各新しい`IParagraph`に対して3つの[IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/)オブジェクトを作成し、各`IParagraph`のIPortionコレクションにそれぞれの`IPortion`オブジェクトを追加します。
7. 各部分のテキストを設定します。
8. `IPortion`オブジェクトによって公開されたフォーマットプロパティを使用して、各部分に好みのフォーマット機能を適用します。
9. 修正されたプレゼンテーションを保存します。

このPHPコードは、部分を含む段落を追加する手順の実装です：

```php
  # PPTXファイルを表すPresentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # 長方形タイプのAutoShapeを追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # AutoShapeのTextFrameにアクセス
    $tf = $ashp->getTextFrame();
    # 異なるテキスト形式で段落と部分を作成
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
      for($j = 0; $j < 3; $j++) {
        $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
        $portion->setText("Portion0" . $j);
        if ($j == 0) {
          $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
          $portion->getPortionFormat()->setFontBold(NullableBool::True);
          $portion->getPortionFormat()->setFontHeight(15);
        } else if ($j == 1) {
          $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
          $portion->getPortionFormat()->setFontItalic(NullableBool::True);
          $portion->getPortionFormat()->setFontHeight(18);
        }
      }
    }
    # PPTXをディスクに書き込む
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **段落の箇条書きを管理する**

箇条書きのリストは、情報を迅速かつ効率的に整理し提示するのに役立ちます。箇条書きの段落は常に読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. 選択したスライドに[autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`内のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き`Type`を`Symbol`に設定し、箇条書き文字を設定します。
8. 段落の`Text`を設定します。
9. 箇条書きのための段落の`Indent`を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を`TextFrame`の段落コレクションに追加します。
13. 2番目の段落を追加し、ステップ7から13までのプロセスを繰り返します。
14. プレゼンテーションを保存します。

このPHPコードは、段落の箇条書きを追加する方法を示しています：

```php
  # PPTXファイルを表すPresentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShapeを追加し、アクセス
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # autoshapeのテキストフレームにアクセス
    $txtFrm = $aShp->getTextFrame();
    # デフォルトの段落を削除
    $txtFrm->getParagraphs()->removeAt(0);
    # 段落を作成
    $para = new Paragraph();
    # 段落の箇条書きスタイルとシンボルを設定
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # 段落テキストを設定
    $para->setText("Welcome to Aspose.Slides");
    # 箇条書きインデントを設定
    $para->getParagraphFormat()->setIndent(25);
    # 箇条書きの色を設定
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True); // 自分の箇条書きの色を使用するためにIsBulletHardColorをtrueに設定

    # 箇条書きの高さを設定
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # テキストフレームに段落を追加
    $txtFrm->getParagraphs()->add($para);
    # 2番目の段落を作成
    $para2 = new Paragraph();
    # 段落の箇条書きタイプとスタイルを設定
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # 段落テキストを追加
    $para2->setText("This is numbered bullet");
    # 箇条書きインデントを設定
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True); // 自分の箇条書きの色を使用するためにIsBulletHardColorをtrueに設定

    # 箇条書きの高さを設定
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # テキストフレームに段落を追加
    $txtFrm->getParagraphs()->add($para2);
    # 修正されたプレゼンテーションを保存
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **画像の箇条書きを管理する**

箇条書きのリストは、情報を迅速かつ効率的に整理し提示するのに役立ちます。画像段落は読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`内のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/)で画像を読み込みます。
8. 箇条書きタイプを[Picture](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/)に設定し、画像を設定します。
9. 段落の`Text`を設定します。
10. 箇条書きのための段落の`Indent`を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を`TextFrame`の段落コレクションに追加します。
14. 2番目の段落を追加し、前のステップに基づいてプロセスを繰り返します。
15. 修正されたプレゼンテーションを保存します。

このPHPコードは、画像の箇条書きを追加および管理する方法を示しています：

```php
  # PPTXファイルを表すPresentationクラスのインスタンスを作成
  $presentation = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $presentation->getSlides()->get_Item(0);
    # 箇条書き用の画像をインスタンス化
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
      $picture = $presentation->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # AutoShapeを追加し、アクセス
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # autoshapeのtextframeにアクセス
    $textFrame = $autoShape->getTextFrame();
    # デフォルトの段落を削除
    $textFrame->getParagraphs()->removeAt(0);
    # 新しい段落を作成
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # 段落の箇条書きスタイルと画像を設定
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # 箇条書きの高さを設定
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # テキストフレームに段落を追加
    $textFrame->getParagraphs()->add($paragraph);
    # プレゼンテーションをPPTXファイルとして書き込む
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # プレゼンテーションをPPTファイルとして書き込む
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **多層箇条書きを管理する**

箇条書きのリストは、情報を迅速かつ効率的に整理し提示するのに役立ちます。多層箇条書きは読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. 新しいスライドに[autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`内のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成し、深さを0に設定します。
7. `Paragraph`クラスを使用して2番目の段落インスタンスを作成し、深さを1に設定します。
8. `Paragraph`クラスを使用して3番目の段落インスタンスを作成し、深さを2に設定します。
9. `Paragraph`クラスを使用して4番目の段落インスタンスを作成し、深さを3に設定します。
10. 新しい段落を`TextFrame`の段落コレクションに追加します。
11. 修正されたプレゼンテーションを保存します。

このPHPコードは、多層箇条書きを追加および管理する方法を示しています：

```php
  # PPTXファイルを表すPresentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShapeを追加し、アクセス
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 作成したautoshapeのテキストフレームにアクセス
    $text = $aShp->addTextFrame("");
    # デフォルトの段落をクリア
    $text->getParagraphs()->clear();
    # 最初の段落を追加
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きレベルを設定
    $para1->getParagraphFormat()->setDepth(0);
    # 2番目の段落を追加
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きレベルを設定
    $para2->getParagraphFormat()->setDepth(1);
    # 3番目の段落を追加
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きレベルを設定
    $para3->getParagraphFormat()->setDepth(2);
    # 4番目の段落を追加
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きレベルを設定
    $para4->getParagraphFormat()->setDepth(3);
    # コレクションに段落を追加
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # プレゼンテーションをPPTXファイルとして書き込む
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **カスタム番号付きリストを使用した段落の管理**

[IBulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/)インターフェースは、[NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)プロパティなどを提供し、カスタム番号やフォーマットを使用して段落を管理できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 段落を含むスライドにアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`内のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)を2に設定します。
7. `Paragraph`クラスを使用して2番目の段落インスタンスを作成し、`NumberedBulletStartWith`を3に設定します。
8. `Paragraph`クラスを使用して3番目の段落インスタンスを作成し、`NumberedBulletStartWith`を7に設定します。
9. 新しい段落を`TextFrame`の段落コレクションに追加します。
10. 修正されたプレゼンテーションを保存します。

このPHPコードは、カスタム番号付きリストで段落を追加および管理する方法を示しています：

```php
  $presentation = new Presentation();
  try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 作成したautoshapeのテキストフレームにアクセス
    $textFrame = $shape->getTextFrame();
    # 既存のデフォルトの段落を削除
    $textFrame->getParagraphs()->removeAt(0);
    # 最初のリスト
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **段落のインデントを設定する**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを介して関連するスライドの参照にアクセスします。
1. スライドに長方形の[autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)を追加します。
1. 長方形のautoshapeに3つの段落を持つ[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)を追加します。
1. 長方形の線を隠します。
1. 各[Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)のBulletOffsetプロパティを介してインデントを設定します。
1. 修正されたプレゼンテーションをPPTファイルとして書き込みます。

このPHPコードは、段落のインデントを設定する方法を示しています：

```php
  # Presentationクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 長方形の形状を追加
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # 長方形にTextFrameを追加
    $tf = $rect->addTextFrame("This is first line \rThis is second line \rThis is third line");
    # 形状にテキストを合わせるように設定
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # 長方形の線を隠す
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # TextFrame内の最初の段落を取得し、そのインデントを設定
    $para1 = $tf->getParagraphs()->get_Item(0);
    # 段落の箇条書きスタイルとシンボルを設定
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # TextFrame内の2番目の段落を取得し、そのインデントを設定
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # TextFrame内の3番目の段落を取得し、そのインデントを設定
    $para3 = $tf->getParagraphs()->get_Item(2);
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para3->getParagraphFormat()->setDepth(2);
    $para3->getParagraphFormat()->setIndent(50);
    # プレゼンテーションをディスクに書き込む
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **段落のぶら下がりインデントを設定する**

このPHPコードは、段落のぶら下りインデントを設定する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("Example");
    $para2 = new Paragraph();
    $para2->setText("段落のぶら下りインデントを設定する");
    $para3 = new Paragraph();
    $para3->setText("このC#コードは、段落のぶら下りインデントを設定する方法を示しています： ");
    $para2->getParagraphFormat()->setMarginLeft(10.0);
    $para3->getParagraphFormat()->setMarginLeft(20.0);
    $autoShape->getTextFrame()->getParagraphs()->add($para1);
    $autoShape->getTextFrame()->getParagraphs()->add($para2);
    $autoShape->getTextFrame()->getParagraphs()->add($para3);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **段落のための終了段落ランプロパティを管理する**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. その位置を介して段落を含むスライドの参照を取得します。
1. スライドに長方形の[autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)を追加します。
1. 長方形に2つの段落を持つ[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)を追加します。
1. 段落の`FontHeight`とフォントタイプを設定します。
1. 段落の終了プロパティを設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このPHPコードは、PowerPointの段落の終了プロパティを設定する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **HTMLテキストを段落にインポートする**

Aspose.Slidesは、HTMLテキストを段落にインポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)を追加します。
4. `autoshape`[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)を追加してアクセスします。
5. `ITextFrame`内のデフォルトの段落を削除します。
6. テキストリーダーでソースHTMLファイルを読み込みます。
7. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
8. 読み込んだTextReaderからTextFrameの[ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/)にHTMLファイルの内容を追加します。
9. 修正されたプレゼンテーションを保存します。

このPHPコードは、段落内のHTMLテキストをインポートする手順の実装です：

```php
  # 空のプレゼンテーションインスタンスを作成
  $pres = new Presentation();
  try {
    # プレゼンテーションのデフォルトの最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # HTMLコンテンツを収容するためのAutoShapeを追加
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # 形状にテキストフレームを追加
    $ashape->addTextFrame("");
    # 追加したテキストフレームのすべての段落をクリア
    $ashape->getTextFrame()->getParagraphs()->clear();
    # ストリームリーダーを使用してHTMLファイルを読み込む
    $tr = new StreamReader("file.html");
    # テキストフレームにHTMLストリームリーダーからテキストを追加
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # プレゼンテーションを保存
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **段落テキストをHTMLにエクスポートする**

Aspose.Slidesは、段落に含まれるテキストをHTMLにエクスポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成し、目的のプレゼンテーションをロードします。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. HTMLにエクスポートされるテキストを含むシェイプにアクセスします。
4. シェイプの[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)にアクセスします。
5. `StreamWriter`のインスタンスを作成し、新しいHTMLファイルを追加します。
6. StreamWriterに開始インデックスを提供し、好みの段落をエクスポートします。

このPHPコードは、PowerPointの段落テキストをHTMLにエクスポートする方法を示しています：

```php
  # プレゼンテーションファイルをロード
  $pres = new Presentation("ExportingHTMLText.pptx");
  try {
    # プレゼンテーションのデフォルトの最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # 希望のインデックス
    $index = 0;
    # 追加した形状にアクセス
    $ashape = $slide->getShapes()->get_Item($index);
    # 出力HTMLファイルを作成
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # 最初の段落をHTMLとして抽出
    # 段落の開始インデックス、コピーする全段落数を指定して段落データをHTMLに書き込む
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```