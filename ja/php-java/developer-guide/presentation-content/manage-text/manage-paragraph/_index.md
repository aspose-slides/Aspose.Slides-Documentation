---
title: PHPでPowerPointテキスト段落を管理する
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
- ぶら下げインデント
- 段落箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTMLをインポート
- テキストをHTMLへ
- 段落をHTMLへ
- 段落を画像へ
- テキストを画像へ
- 段落をエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Javaで段落の書式設定をマスター - PPT、PPTX、ODPプレゼンテーションの配置、間隔、スタイルを最適化"
---

Aspose.Slides は、PowerPoint のテキスト、段落、およびポーションを操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) インターフェイスを提供します。`ITextFame` オブジェクトは、1 つまたは複数の段落を持つことができます（各段落は改行によって作成されます）。
* Aspose.Slides は、ポーションを表すオブジェクトを追加できるようにする [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) インターフェイスを提供します。`IParagraph` オブジェクトは、1 つまたは複数のポーション（iPortions オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにする [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) インターフェイスを提供します。

`IParagraph` オブジェクトは、基礎となる `IPortion` オブジェクトを介して、異なる書式設定プロパティを持つテキストを処理できます。

## **複数のポーションを含む複数の段落を追加する**

以下の手順では、3 つの段落を持ち、各段落が 3 つのポーションを含むテキスト フレームの追加方法を示します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して該当スライドの参照にアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) の `IParagraphs` コレクションに追加します。
6. 各新しい `IParagraph` に対して 3 つの [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) オブジェクト（デフォルト段落には 2 つの Portion オブジェクト）を作成し、各 `IPortion` オブジェクトをそれぞれの `IParagraph` の IPortion コレクションに追加します。
7. 各ポーションにテキストを設定します。
8. `IPortion` オブジェクトが提供する書式設定プロパティを使用して、各ポーションに好みの書式設定を適用します。
9. 変更されたプレゼンテーションを保存します。

この PHP コードは、ポーションを含む段落を追加する手順の実装例です:
```php
# PPTX ファイルを表す Presentation クラスのインスタンスを作成します
$pres = new Presentation();
try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # Rectangle タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # AutoShape の TextFrame にアクセス
    $tf = $ashp->getTextFrame();
    # 異なるテキスト形式の Paragraph と Portion を作成
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

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書きされた段落は常に読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して該当スライドの参照にアクセスします。
3. 選択したスライドに [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き `Type` を `Symbol` に設定し、箇条書き文字を指定します。
8. 段落の `Text` を設定します。
9. 箇条書きのインデントとして段落の `Indent` を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を追加し、手順 7 から 13 のプロセスを繰り返します。
14. プレゼンテーションを保存します。

この PHP コードは、段落に箇条書きを追加する方法を示しています:
```php
# PPTX ファイルを表す Presentation クラスのインスタンスを生成します
$pres = new Presentation();
try {
    # 最初のスライドにアクセスします
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape を追加し、アクセスします
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # AutoShape のテキストフレームにアクセスします
    $txtFrm = $aShp->getTextFrame();
    # デフォルトの段落を削除します
    $txtFrm->getParagraphs()->removeAt(0);
    # 段落を作成します
    $para = new Paragraph();
    # 段落の箇条書きスタイルとシンボルを設定します
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # 段落のテキストを設定します
    $para->setText("Welcome to Aspose.Slides");
    # 箇条書きのインデントを設定します
    $para->getParagraphFormat()->setIndent(25);
    # 箇条書きの色を設定します
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// Bullet の色を独自に使用するために IsBulletHardColor を true に設定します

    # 箇条書きの高さを設定します
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 段落をテキストフレームに追加します
    $txtFrm->getParagraphs()->add($para);
    # 2 番目の段落を作成します
    $para2 = new Paragraph();
    # 段落の箇条書きタイプとスタイルを設定します
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # 段落のテキストを設定します
    $para2->setText("This is numbered bullet");
    # 箇条書きのインデントを設定します
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// Bullet の色を独自に使用するために IsBulletHardColor を true に設定します

    # 箇条書きの高さを設定します
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # 段落をテキストフレームに追加します
    $txtFrm->getParagraphs()->add($para2);
    # 修正されたプレゼンテーションを保存します
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **画像箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像箇条書きの段落は読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して該当スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) に画像をロードします。
8. 箇条書きのタイプを [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. 箇条書きのインデントとして段落の `Indent` を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前の手順に従って同じ処理を繰り返します。
15. 変更されたプレゼンテーションを保存します。

この PHP コードは、画像箇条書きを追加および管理する方法を示しています:
```php
# PPTX ファイルを表す Presentation クラスのインスタンスを作成します
$presentation = new Presentation();
try {
    # 最初のスライドにアクセスします
    $slide = $presentation->getSlides()->get_Item(0);
    # 箇条書き用画像を作成します
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # AutoShape を追加し、アクセスします
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # AutoShape のテキストフレームにアクセスします
    $textFrame = $autoShape->getTextFrame();
    # デフォルトの段落を削除します
    $textFrame->getParagraphs()->removeAt(0);
    # 新しい段落を作成します
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # 段落の箇条書きスタイルと画像を設定します
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # 箇条書きの高さを設定します
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # 段落をテキストフレームに追加します
    $textFrame->getParagraphs()->add($paragraph);
    # プレゼンテーションを PPTX ファイルとして保存します
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # プレゼンテーションを PPT ファイルとして保存します
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **階層化箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。階層化箇条書きは読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して該当スライドの参照にアクセスします。
3. 新しいスライドに [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph] クラスを使用して最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスを使用して第2の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスを使用して第3の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスを使用して第4の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更されたプレゼンテーションを保存します。

この PHP コードは、階層化箇条書きを追加および管理する方法を示しています:
```php
# PPTX ファイルを表す Presentation クラスのインスタンスを作成します
$pres = new Presentation();
try {
    # 最初のスライドにアクセスします
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape を追加し、アクセスします
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 作成した AutoShape のテキストフレームにアクセスします
    $text = $aShp->addTextFrame("");
    # デフォルトの段落をクリアします
    $text->getParagraphs()->clear();
    # 最初の段落を追加します
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きレベルを設定します
    $para1->getParagraphFormat()->setDepth(0);
    # 2 番目の段落を追加します
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きレベルを設定します
    $para2->getParagraphFormat()->setDepth(1);
    # 3 番目の段落を追加します
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きレベルを設定します
    $para3->getParagraphFormat()->setDepth(2);
    # 4 番目の段落を追加します
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きレベルを設定します
    $para4->getParagraphFormat()->setDepth(3);
    # 段落をコレクションに追加します
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # プレゼンテーションを PPTX ファイルとして保存します
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **カスタム番号リストを持つ段落の管理**

[IBulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/) インターフェイスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) プロパティなどを提供し、カスタム番号付けや書式設定を持つ段落を管理できるようにします。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して該当スライドの参照にアクセスします。
3. 段落が含まれるスライドにアクセスします。
4. スライドに [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) を追加します。
5. autoshape の [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) にアクセスします。
6. `TextFrame` のデフォルト段落を削除します。
7. [Paragraph] クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) を 2 に設定します。
8. `Paragraph` クラスを使用して第2の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
9. `Paragraph` クラスを使用して第3の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更されたプレゼンテーションを保存します。

この PHP コードは、カスタム番号付けや書式設定を持つ段落を追加および管理する方法を示しています:
```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 作成した AutoShape のテキストフレームにアクセスします
    $textFrame = $shape->getTextFrame();
    # デフォルトの既存段落を削除します
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


## **段落インデントの設定**

1. [Presentation] クラスのインスタンスを作成します。
1. インデックスを使用して該当スライドの参照にアクセスします。
1. スライドに矩形の [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) を追加します。
1. 矩形 autoshape に 3 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) を追加します。
1. 矩形の線を非表示にします。
1. [Paragraph] の BulletOffset プロパティを使用して各段落のインデントを設定します。
1. 変更されたプレゼンテーションを書き込み、PPT ファイルとして保存します。

この PHP コードは、段落インデントを設定する方法を示しています:
```php
# Presentation クラスをインスタンス化
$pres = new Presentation();
try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 長方形シェイプを追加
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # 長方形に TextFrame を追加
    $tf = $rect->addTextFrame("This is first line \rThis is second line \rThis is third line");
    # テキストをシェイプに合わせて設定
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # 長方形の線を非表示にする
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # TextFrame の最初の段落を取得しインデントを設定
    $para1 = $tf->getParagraphs()->get_Item(0);
    # 段落の箇条書きスタイルとシンボルを設定
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # TextFrame の2番目の段落を取得しインデントを設定
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # TextFrame の3番目の段落を取得しインデントを設定
    $para3 = $tf->getParagraphs()->get_Item(2);
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para3->getParagraphFormat()->setDepth(2);
    $para3->getParagraphFormat()->setIndent(50);
    # プレゼンテーションをディスクに保存
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **段落のぶら下げインデントの設定**

この PHP コードは、段落のぶら下げインデントを設定する方法を示しています:
```php
$pres = new Presentation();
try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("Example");
    $para2 = new Paragraph();
    $para2->setText("Set Hanging Indent for Paragraph");
    $para3 = new Paragraph();
    $para3->setText("This code shows you how to set the hanging indent for a paragraph: ");
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


## **段落の末尾実行プロパティの管理**

1. [Presentation] クラスのインスタンスを作成します。
1. 位置を使用して段落を含むスライドの参照を取得します。
1. スライドに矩形の [autoshape] を追加します。
1. 矩形に 2 つの段落を持つ [TextFrame] を追加します。
1. 段落の `FontHeight` とフォントタイプを設定します。
1. 段落の End プロパティを設定します。
1. 変更されたプレゼンテーションを書き込み、PPTX ファイルとして保存します。

この PHP コードは、PowerPoint の段落に対して End プロパティを設定する方法を示しています:
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


## **HTML テキストを段落にインポートする**

Aspose.Slides は、HTML テキストを段落にインポートするための強化されたサポートを提供します。

1. [Presentation] クラスのインスタンスを作成します。
2. インデックスを使用して該当スライドの参照にアクセスします。
3. スライドに [autoshape] を追加します。
4. `autoshape` の [ITextFrame] を追加し、アクセスします。
5. `ITextFrame` のデフォルト段落を削除します。
6. TextReader でソースの HTML ファイルを読み取ります。
7. [Paragraph] クラスを使用して最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML ファイル内容を TextFrame の [ParagraphCollection] に追加します。
9. 変更されたプレゼンテーションを保存します。

この PHP コードは、段落に HTML テキストをインポートする手順の実装例です:
```php
# 空のプレゼンテーションインスタンスを作成
$pres = new Presentation();
try {
    # プレゼンテーションのデフォルトの最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # HTML コンテンツを収めるために AutoShape を追加
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # シェイプにテキストフレームを追加
    $ashape->addTextFrame("");
    # 追加したテキストフレームのすべての段落をクリア
    $ashape->getTextFrame()->getParagraphs()->clear();
    # ストリームリーダーで HTML ファイルを読み込み
    $tr = new StreamReader("file.html");
    # HTML ストリームリーダーからテキストをテキストフレームに追加
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # プレゼンテーションを保存
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **段落テキストを HTML にエクスポートする**

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための強化されたサポートを提供します。

1. [Presentation] クラスのインスタンスを作成し、目的のプレゼンテーションをロードします。
2. インデックスを使用して該当スライドの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. 開始インデックスを StreamWriter に設定し、希望する段落をエクスポートします。

この PHP コードは、PowerPoint の段落テキストを HTML にエクスポートする方法を示しています:
```php
# プレゼンテーションファイルをロード
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
    # 段落の開始インデックスとコピーする段落数を指定して、段落データを HTML に書き込む
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **段落を画像として保存する**

このセクションでは、[Paragraph] クラスで表されるテキスト段落を画像として保存する方法を示す 2 つの例を紹介します。どちらの例も、[Shape] クラスの `getImage` メソッドを使用して段落を含むシェイプの画像を取得し、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートします。この手法により、PowerPoint プレゼンテーションからテキストの特定部分を抽出し、別々の画像として保存でき、さまざまなシナリオでの活用が可能になります。

![3つの段落があるテキストボックス](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。まず、プレゼンテーションの最初のスライドからシェイプの画像を抽出し、シェイプのテキストフレーム内の 2 番目の段落の境界を計算します。その段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、テキストの正確なサイズと書式設定を保持したまま、特定の段落を別々の画像として保存したい場合に特に有用です。
```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // メモリ内にシェイプをビットマップとして保存します。
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // メモリからシェイプのビットマップを作成します。
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // 2番目の段落の境界を計算します。
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // 出力画像の座標とサイズを計算します（最小サイズ - 1×1 ピクセル）。
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // 段落ビットマップだけを取得するようにシェイプビットマップをクロップします。
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

この例では、段落画像に拡大率を加えることで前のアプローチを拡張します。シェイプをプレゼンテーションから抽出し、拡大率 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が可能になります。その後、拡大率を考慮して段落の境界を計算します。拡大は、たとえば高品質な印刷物で使用する際など、より詳細な画像が必要な場合に特に有用です。
```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // スケール付きでシェイプをメモリ内にビットマップとして保存します。
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // メモリからシェイプのビットマップを作成します。
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // 2番目の段落の境界を計算します。
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // 出力画像の座標とサイズを計算します（最小サイズ - 1×1 ピクセル）。
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // 段落ビットマップだけを取得するようにシェイプビットマップをクロップします。
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **よくある質問**

**テキストフレーム内の改行を完全に無効にできますか？**

はい。テキストフレームの折り返し設定（[setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/)）を使用して折り返しをオフにすれば、フレームの端で行が折り返されなくなります。

**特定の段落のスライド上の正確な境界を取得するにはどうすればよいですか？**

段落（あるいは単一のポーション）の境界矩形を取得すれば、スライド上での正確な位置とサイズを知ることができます。

**段落の配置（左揃え/右揃え/中央揃え/両端揃え）はどこで設定しますか？**

[Alignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) は、[ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) の段落レベルの設定で、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部（例：1語）だけにスペルチェックの言語を設定できますか？**

はい。言語はポーションレベル（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)）で設定できるため、1 つの段落内に複数の言語が共存できます。