---
title: PHP で PowerPoint のテキスト段落を管理する
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/php-java/manage-paragraph/
keywords:
- テキストを追加
- 段落を追加
- テキストを管理
- 段落を管理
- 箇条書きを管理
- 段落インデント
- ハンギングインデント
- 段落箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTML のインポート
- テキストを HTML に変換
- 段落を HTML に変換
- 段落を画像に変換
- テキストを画像に変換
- 段落をエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用し、段落書式設定をマスター—PPT、PPTX、ODP プレゼンテーションの配置、間隔、スタイルを最適化します。"
---
Aspose.Slides は、PowerPoint のテキスト、段落、および部分を操作するために必要なすべてのクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) クラスを提供します。`TextFame` オブジェクトは、1 つまたは複数の段落を持つことができます（各段落は改行で作成されます）。
* Aspose.Slides は、部分を表すオブジェクトを追加できるようにする [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) クラスを提供します。`Paragraph` オブジェクトは、1 つまたは複数の部分（部分オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式プロパティを表すオブジェクトを追加できるようにする [Portion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/) クラスを提供します。

`Paragraph` オブジェクトは、基になる `Portion` オブジェクトを通じて、異なる書式プロパティを持つテキストを処理できます。

## **複数の部分を含む複数の段落を追加**

以下の手順は、3 つの段落を含むテキスト フレームを追加し、各段落に 3 つの部分を含める方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照にアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
4. [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) オブジェクトを作成し、[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) の段落コレクションに追加します。
6. 各新しい `Paragraph` に対して 3 つの [Portion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/) オブジェクト（デフォルトの段落には 2 つの Portion）を作成し、各 `Paragraph` の部分コレクションに追加します。
7. 各部分にテキストを設定します。
8. `Portion` オブジェクトが提供する書式プロパティを使用して、各部分に好みの書式設定を適用します。
9. 変更したプレゼンテーションを保存します。

この PHP コードは、段落に部分を追加する手順の実装例です。

```php
# PPTX ファイルを表す Presentation クラスのインスタンスを作成する
$pres = new Presentation();
try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # 矩形タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # AutoShape の TextFrame にアクセス
    $tf = $ashp->getTextFrame();
    # 異なるテキスト書式を持つ段落と部分を作成
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
    # PPTX をディスクに保存
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **段落の箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書きされた段落は、常に読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで対象スライドの参照にアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き `Type` を `Symbol` に設定し、箇条書き文字を指定します。
8. 段落の `Text` を設定します。
9. 箇条書きのインデントとして段落の `Indent` を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を追加し、手順 7〜12 を繰り返します。
14. プレゼンテーションを保存します。

この PHP コードは、段落の箇条書きを追加する方法を示しています。

```php
# PPTX ファイルを表す Presentation クラスのインスタンスを作成する
$pres = new Presentation();
try {
    # 最初のスライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape を追加してアクセスする
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # AutoShape のテキストフレームにアクセスする
    $txtFrm = $aShp->getTextFrame();
    # デフォルトの段落を削除する
    $txtFrm->getParagraphs()->removeAt(0);
    # 段落を作成する
    $para = new Paragraph();
    # 段落の箇条書きスタイルとシンボルを設定する
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # 段落のテキストを設定する
    $para->setText("Welcome to Aspose.Slides");
    # 箇条書きのインデントを設定する
    $para->getParagraphFormat()->setIndent(25);
    # 箇条書きの色を設定する
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// 独自の箇条書き色を使用するために IsBulletHardColor を true に設定する

    # 箇条書きの高さを設定する
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 段落をテキストフレームに追加する
    $txtFrm->getParagraphs()->add($para);
    # 2 番目の段落を作成する
    $para2 = new Paragraph();
    # 段落の箇条書きタイプとスタイルを設定する
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # 段落のテキストを追加する
    $para2->setText("This is numbered bullet");
    # 箇条書きのインデントを設定する
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// 独自の箇条書き色を使用するために IsBulletHardColor を true に設定する

    # 箇条書きの高さを設定する
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # 段落をテキストフレームに追加する
    $txtFrm->getParagraphs()->add($para2);
    # 変更したプレゼンテーションを保存する
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **画像箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像段落は読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで対象スライドの参照にアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) で画像を読み込みます。
8. 箇条書きのタイプを [Picture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bullettype/#Picture) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. 箇条書きのインデントとして段落の `Indent` を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前述の手順を繰り返します。
15. 変更したプレゼンテーションを保存します。

この PHP コードは、画像箇条書きを追加および管理する方法を示しています。

```php
# PPTX ファイルを表す Presentation クラスのインスタンスを作成する
$presentation = new Presentation();
try {
    # 最初のスライドにアクセスする
    $slide = $presentation->getSlides()->get_Item(0);
    # 箇条書き用画像をインスタンス化する
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # AutoShape を追加してアクセスする
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # AutoShape のテキストフレームにアクセスする
    $textFrame = $autoShape->getTextFrame();
    # デフォルトの段落を削除する
    $textFrame->getParagraphs()->removeAt(0);
    # 新しい段落を作成する
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # 段落の箇条書きスタイルと画像を設定する
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # 箇条書きの高さを設定する
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # 段落をテキストフレームに追加する
    $textFrame->getParagraphs()->add($paragraph);
    # プレゼンテーションを PPTX ファイルとして保存する
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # プレゼンテーションを PPT ファイルとして保存する
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **多層箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。多層箇条書きは読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで対象スライドの参照にアクセスします。
3. 新しいスライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) クラスで最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスで 2 番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスで 3 番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスで 4 番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更したプレゼンテーションを保存します。

この PHP コードは、多層箇条書きを追加および管理する方法を示しています。

```php
# PPTX ファイルを表す Presentation クラスのインスタンスを作成する
$pres = new Presentation();
try {
    # 最初のスライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape を追加してアクセスする
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 作成した AutoShape のテキストフレームにアクセスする
    $text = $aShp->addTextFrame("");
    # デフォルトの段落をクリアする
    $text->getParagraphs()->clear();
    # Adds the first paragraph
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きのレベルを設定する
    $para1->getParagraphFormat()->setDepth(0);
    # Adds the second paragraph
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きのレベルを設定する
    $para2->getParagraphFormat()->setDepth(1);
    # Adds the third paragraph
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きのレベルを設定する
    $para3->getParagraphFormat()->setDepth(2);
    # Adds the fourth paragraph
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きのレベルを設定する
    $para4->getParagraphFormat()->setDepth(3);
    # コレクションに段落を追加する
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # プレゼンテーションを PPTX ファイルとして保存する
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **カスタム番号リスト付き段落の管理**

[BulletFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/) クラスは、[setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) メソッドなどを提供し、カスタム番号付けや書式設定を行う段落を管理できます。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 段落が含まれるスライドにアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) クラスで最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) を 2 に設定します。
7. `Paragraph` クラスで 2 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスで 3 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更したプレゼンテーションを保存します。

この PHP コードは、カスタム番号付けや書式設定を持つ段落を追加および管理する方法を示しています。

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 作成した AutoShape のテキストフレームにアクセスする
    $textFrame = $shape->getTextFrame();
    # デフォルトの既存段落を削除する
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

## **段落のファーストラインインデントの設定**

[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setindent/) メソッドを使用して、段落のファーストラインインデントを制御します。このメソッドは、段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右へシフトし、残りの行は段落本文に揃ったままです。

段落全体を移動したい場合は [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setmarginleft/) を使用し、最初の行だけを移動したい場合は [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setindent/) を使用します。

以下の例は、複数の段落を作成し、異なるインデント値を適用してファーストラインインデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) を追加し、デフォルト段落を削除します。
5. 複数の段落を作成し、[Indent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setindent/) の値をそれぞれ設定します。
6. 段落をテキストフレームに追加します。
7. 変更したプレゼンテーションを保存します。

このコードは段落インデントの設定方法を示しています。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![段落のファーストラインインデント](first_line_indent.png)

## **段落のハンギングインデントの設定**

ハンギングインデントは、最初の行が残りの行より左側に開始する段落レイアウトです。Aspose.Slides では、[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setindent/) メソッドでこの効果を実現します。インデントに負の値を設定すると、段落本文に対して最初の行が左に移動します。

実際には、[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setmarginleft/) が段落本文の左位置を定義し、[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setindent/) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の `MarginLeft` 値と負の `Indent` 値を設定します。

この書式設定は、参考文献、文献リスト、用語集のエントリなど、折り返し行を段落本文の下に揃える必要がある段落で便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) を追加し、デフォルト段落を削除します。
5. 各段落に対して正の [MarginLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setmarginleft/) 値を設定します。
6. ハンギングインデント効果を作成するために負の [Indent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setindent/) 値を設定します。
7. 段落をテキストフレームに追加します。
8. 変更したプレゼンテーションを保存します。

このコードは段落のハンギングインデントの設定方法を示しています。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![段落のハンギングインデント](hanging_indent.png)

## **段落末端の実行プロパティの管理**

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 位置で段落が含まれるスライドの参照を取得します。
1. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
1. 矩形に 2 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) を追加します。
1. 段落のフォントサイズとフォント タイプを設定します。
1. 段落の End プロパティを設定します。
1. 修正したプレゼンテーションを PPTX ファイルとして書き出します。

この PHP コードは、PowerPoint の段落に End プロパティを設定する方法を示しています。

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

## **HTML テキストを段落にインポート**

Aspose.Slides は、HTML テキストを段落にインポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで対象スライドの参照にアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
4. `AutoShape` の [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) を追加し、取得します。
5. `TextFrame` のデフォルト段落を削除します。
6. TextReader でソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) クラスで最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML 内容を [ParagraphCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphcollection/) に追加します。
9. 変更したプレゼンテーションを保存します。

この PHP コードは、HTML テキストを段落にインポートする手順の実装例です。

```php
# 空のプレゼンテーションインスタンスを作成
$pres = new Presentation();
try {
    # プレゼンテーションのデフォルト最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # HTML コンテンツを収めるために AutoShape を追加
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # シェイプにテキストフレームを追加
    $ashape->addTextFrame("");
    # 追加したテキストフレームのすべての段落をクリア
    $ashape->getTextFrame()->getParagraphs()->clear();
    # ストリームリーダーで HTML ファイルを読み込む
    $tr = new StreamReader("file.html");
    # テキストフレームに HTML ストリームリーダーからテキストを追加
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # プレゼンテーションを保存
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **段落テキストを HTML にエクスポート**

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、目的のプレゼンテーションをロードします。
2. インデックスで対象スライドの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. `StreamWriter` に開始インデックスを指定し、希望する段落をエクスポートします。

この PHP コードは、PowerPoint の段落テキストを HTML にエクスポートする方法を示しています。

```php
# プレゼンテーションファイルを読み込む
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # プレゼンテーションのデフォルトの最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # 目的のインデックス
    $index = 0;
    # 追加されたシェイプにアクセス
    $ashape = $slide->getShapes()->get_Item($index);
    # 出力 HTML ファイルを作成
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # 最初の段落を HTML として抽出
    # 段落の開始インデックスとコピーする総段落数を指定して、段落データを HTML に書き込む
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **段落を画像として保存**

このセクションでは、[Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) クラスで表されるテキスト段落を画像として保存する 2 つの例を紹介します。どちらの例も、段落を含むシェイプの画像を取得し（[Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) クラスの `getImage` メソッド使用）、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートします。これにより、PowerPoint プレゼンテーションからテキストの特定部分を抽出し、別々の画像として保存でき、さまざまなシナリオでの再利用が可能になります。

サンプルとして、1 枚のスライドがあり、最初のシェイプが 3 つの段落を含むテキスト ボックスである sample.pptx を想定します。

![3 つの段落を含むテキスト ボックス](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。プレゼンテーションの最初のスライドからシェイプの画像を抽出し、シェイプのテキストフレーム内の 2 番目の段落の境界を計算します。その後、段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、特定の段落を別画像として保存したいが、テキストの正確なサイズと書式を保持したい場合に特に有用です。

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 形状をメモリ内でビットマップとして保存する。
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // メモリから形状ビットマップを作成する。
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // 2 番目の段落の境界を計算する。
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // 出力画像の座標とサイズを計算する（最小サイズは 1x1 ピクセル）。
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // 形状ビットマップを切り取り、段落ビットマップだけを取得する。
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果:

![段落画像](paragraph_to_image_output.png)

**例 2**

この例では、前述のアプローチにスケーリング係数を追加します。シェイプをプレゼンテーションから抽出し、スケーリング係数 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。段落の境界はスケールを考慮して計算されます。高詳細な画像が必要な場合（例: 高品質な印刷物での使用）に特に役立ちます。

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // スケーリング付きで形状をメモリ内にビットマップとして保存する。
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // メモリから形状ビットマップを作成する。
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // 2 番目の段落の境界を計算する。
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // 出力画像の座標とサイズを計算する（最小サイズは 1x1 ピクセル）。
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // 形状ビットマップを切り取り、段落ビットマップだけを取得する。
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**テキスト フレーム内で改行を完全に無効にできますか？**

はい。テキストフレームのラップ設定（[setWrapText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/setwraptext/)）をオフにすれば、フレームの端で行が折り返されなくなります。

**特定の段落のスライド上での正確な境界を取得するにはどうすればよいですか？**

段落（場合によっては単一の部分）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズが分かります。

**段落の配置（左揃え/右揃え/中央揃え/両端揃え）はどこで制御しますか？**

[Alignment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/setalignment/) は [ParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/) の段落レベル設定であり、個々の部分の書式設定に関係なく段落全体に適用されます。

**段落の一部（例: 単語）だけにスペルチェック言語を設定できますか？**

はい。言語は部分レベル（[PortionFormat::setLanguageId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setLanguageId)）で設定されるため、1 つの段落内に複数の言語を共存させることが可能です。