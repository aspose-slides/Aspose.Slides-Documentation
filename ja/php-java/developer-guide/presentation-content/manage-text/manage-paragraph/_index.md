---
title: PHPでPowerPointテキスト段落を管理
linktitle: 段落を管理
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
- HTMLをインポート
- テキストをHTMLに変換
- 段落をHTMLに変換
- 段落を画像に変換
- テキストを画像に変換
- 段落をエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Javaで段落書式設定をマスターし、PPT、PPTX、ODPプレゼンテーションの配置、間隔、スタイルを最適化します。"
---

Aspose.Slides は、PowerPoint のテキスト、段落、ポーションを操作するために必要なすべてのクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できる [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) クラスを提供します。`TextFame` オブジェクトは 1 つまたは複数の段落を持つことができ（各段落は改行で作成されます）。
* Aspose.Slides は、ポーションを表すオブジェクトを追加できる [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) クラスを提供します。`Paragraph` オブジェクトは 1 つまたは複数のポーション（ポーション オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できる [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) クラスを提供します。

`Paragraph` オブジェクトは、基になる `Portion` オブジェクトを通じて、異なる書式設定プロパティを持つテキストを処理できます。

## **複数のポーションを含む複数の段落を追加**

これらの手順は、3 つの段落を含み、各段落が 3 つのポーションを含むテキスト フレームを追加する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに矩形 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
4. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) の段落コレクションに追加します。
6. 各新しい `Paragraph` に対して 3 つの [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) オブジェクト（デフォルトの段落には 2 つの Portion）を作成し、各 `Paragraph` のポーションコレクションに追加します。
7. 各ポーションにテキストを設定します。
8. `Portion` オブジェクトが提供する書式設定プロパティを使用して、各ポーションに好みの書式を適用します。
9. 変更されたプレゼンテーションを保存します。

この PHP コードは、ポーションを含む段落を追加する手順の実装例です:
```php
# PPTX ファイルを表す Presentation クラスをインスタンス化
$pres = new Presentation();
try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # 矩形タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # AutoShape の TextFrame にアクセス
    $tf = $ashp->getTextFrame();
    # 異なるテキスト形式の段落とポーションを作成
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

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書きされた段落は常に読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
4. オートシェイプの [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き `Type` を `Symbol` に設定し、箇条書き文字を指定します。
8. 段落の `Text` を設定します。
9. 箇条書きのインデントを段落の `Indent` に設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を追加し、手順 7 から 12 を繰り返します。
14. プレゼンテーションを保存します。

この PHP コードは、段落の箇条書きを追加する方法を示します:
```php
# PPTX ファイルを表す Presentation クラスのインスタンスを作成
$pres = new Presentation();
try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape を追加してアクセス
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # AutoShape のテキストフレームにアクセス
    $txtFrm = $aShp->getTextFrame();
    # デフォルトの段落を削除
    $txtFrm->getParagraphs()->removeAt(0);
    # 段落を作成
    $para = new Paragraph();
    # 段落の箇条書きスタイルと記号を設定
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # 段落のテキストを設定
    $para->setText("Welcome to Aspose.Slides");
    # 箇条書きのインデントを設定
    $para->getParagraphFormat()->setIndent(25);
    # 箇条書きの色を設定
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// 独自の箇条書き色を使用するために IsBulletHardColor を true に設定

    # 箇条書きの高さを設定
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 段落をテキストフレームに追加
    $txtFrm->getParagraphs()->add($para);
    # 2 番目の段落を作成
    $para2 = new Paragraph();
    # 段落の箇条書きタイプとスタイルを設定
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # 段落のテキストを追加
    $para2->setText("This is numbered bullet");
    # 箇条書きのインデントを設定
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// 独自の箇条書き色を使用するために IsBulletHardColor を true に設定

    # 箇条書きの高さを設定
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # 段落をテキストフレームに追加
    $txtFrm->getParagraphs()->add($para2);
    # 変更されたプレゼンテーションを保存
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **画像箇条書きの管理**

画像箇条書きは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像段落は読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
4. オートシェイプの [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) で画像をロードします。
8. 箇条書きの種類を [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. 箇条書きのインデントを段落の `Indent` に設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前述の手順を繰り返します。
15. 変更されたプレゼンテーションを保存します。

この PHP コードは、画像箇条書きを追加および管理する方法を示します:
```php
# PPTX ファイルを表す Presentation クラスをインスタンス化
$presentation = new Presentation();
try {
    # 最初のスライドにアクセス
    $slide = $presentation->getSlides()->get_Item(0);
    # 箇条書き用画像をインスタンス化
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Autoshape を追加してアクセス
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Autoshape のテキストフレームにアクセス
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
    # 段落をテキストフレームに追加
    $textFrame->getParagraphs()->add($paragraph);
    # プレゼンテーションを PPTX ファイルとして書き出し
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # プレゼンテーションを PPT ファイルとして書き出し
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **階層付き箇条書きの管理**

階層付き箇条書きは、情報を迅速かつ効率的に整理・提示するのに役立ちます。階層付き箇条書きは読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 新しいスライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
4. オートシェイプの [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスを使用して 4 番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更されたプレゼンテーションを保存します。

この PHP コードは、階層付き箇条書きを追加および管理する方法を示します:
```php
# PPTX ファイルを表す Presentation クラスをインスタンス化
$pres = new Presentation();
try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape を追加してアクセス
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 作成した AutoShape のテキストフレームにアクセス
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
    # 箇条書きのレベルを設定
    $para1->getParagraphFormat()->setDepth(0);
    # 2 番目の段落を追加
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きのレベルを設定
    $para2->getParagraphFormat()->setDepth(1);
    # 3 番目の段落を追加
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きのレベルを設定
    $para3->getParagraphFormat()->setDepth(2);
    # 4 番目の段落を追加
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きのレベルを設定
    $para4->getParagraphFormat()->setDepth(3);
    # 段落をコレクションに追加
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # プレゼンテーションを PPTX ファイルとして書き出し
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **カスタム番号付きリストを持つ段落の管理**

[BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) クラスは、[setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) メソッドなどを提供し、カスタム番号付けや書式設定を持つ段落を管理できます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象段落が含まれるスライドにアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
4. オートシェイプの [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) を 2 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更されたプレゼンテーションを保存します。

この PHP コードは、カスタム番号付けや書式設定を持つ段落を追加および管理する方法を示します:
```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 作成されたオートシェイプのテキストフレームにアクセス
    $textFrame = $shape->getTextFrame();
    # 既定の既存段落を削除
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

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用して対象スライドの参照にアクセスします。
1. スライドに矩形 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 矩形オートシェイプに 3 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) を追加します。
1. 矩形の枠線を非表示にします。
1. 各 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) の `BulletOffset` プロパティを使用してインデントを設定します。
1. 変更されたプレゼンテーションを書き出して PPT ファイルとして保存します。

この PHP コードは、段落インデントを設定する方法を示します:
```php
# Presentation クラスをインスタンス化
$pres = new Presentation();
try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 矩形シェイプを追加
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # 矩形に TextFrame を追加
    $tf = $rect->addTextFrame("This is first line \rThis is second line \rThis is third line");
    # テキストをシェイプに合わせて自動調整
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # 矩形の線を非表示にする
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # TextFrame の最初の段落を取得してインデントを設定
    $para1 = $tf->getParagraphs()->get_Item(0);
    # 段落の箇条書きスタイルと記号を設定
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # TextFrame の2番目の段落を取得してインデントを設定
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # TextFrame の3番目の段落を取得してインデントを設定
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


## **段落のハンギングインデントの設定**

この PHP コードは、段落のハンギングインデントを設定する方法を示します:
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


## **段落末端プロパティの管理**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 位置で指定された段落を含むスライドの参照を取得します。
1. スライドに矩形 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 矩形に 2 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) を追加します。
1. 段落のフォント高さとフォント種類を設定します。
1. 段落の End プロパティを設定します。
1. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。

この PHP コードは、PowerPoint の段落に End プロパティを設定する方法を示します:
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

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
4. `AutoShape` の [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスして追加します。
5. `TextFrame` のデフォルト段落を削除します。
6. TextReader でソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML コンテンツを [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/) に追加します。
9. 変更されたプレゼンテーションを保存します。

この PHP コードは、段落への HTML テキストのインポート手順の実装例です:
```php
# 空のプレゼンテーションインスタンスを作成
$pres = new Presentation();
try {
    # プレゼンテーションのデフォルトの最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # HTML コンテンツを収容するために AutoShape を追加
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # シェイプにテキストフレームを追加
    $ashape->addTextFrame("");
    # 追加したテキストフレーム内のすべての段落をクリア
    $ashape->getTextFrame()->getParagraphs()->clear();
    # ストリームリーダーで HTML ファイルを読み込む
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


## **段落テキストを HTML にエクスポート**

Aspose.Slides は、段落内のテキストを HTML にエクスポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成し、目的のプレゼンテーションをロードします。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. `StreamWriter` に開始インデックスを指定し、希望する段落をエクスポートします。

この PHP コードは、PowerPoint の段落テキストを HTML にエクスポートする方法を示します:
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
    # 出力HTMLファイルを作成
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # 最初の段落をHTMLとして抽出
    # 段落の開始インデックスとコピーする総段落数を指定して段落データをHTMLに書き込む
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

このセクションでは、[Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) クラスで表されるテキスト段落を画像として保存する 2 つの例を示します。どちらの例も、[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスの `getImage` メソッドで段落を含むシェイプの画像を取得し、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートします。これにより、PowerPoint プレゼンテーションからテキストの特定部分を抽出し、別々の画像として保存でき、さまざまなシナリオでの活用が可能になります。

サンプルとして、sample.pptx というプレゼンテーション ファイルがあり、1 枚のスライドがあり、最初のシェイプは 3 つの段落を含むテキスト ボックスです。

![The text box with three paragraphs](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。プレゼンテーションの最初のスライドからシェイプの画像を抽出し、シェイプのテキスト フレーム内の 2 番目の段落の境界を計算します。その後、段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、テキストの正確なサイズと書式設定を保持したまま特定の段落を別画像として保存したい場合に特に有用です。
```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 形状をメモリ内にビットマップとして保存します。
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // メモリから形状ビットマップを作成します。
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // 第2段落の境界を計算します。
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // 出力画像の座標とサイズを計算します（最小サイズは 1x1 ピクセル）。
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // 形状ビットマップを切り取り、段落のビットマップだけを取得します。
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


結果:

![The paragraph image](paragraph_to_image_output.png)

**例 2**

この例では、前のアプローチにスケーリング係数を加えて段落画像を拡大します。シェイプをプレゼンテーションから抽出し、スケーリング係数 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。段落の境界はスケールを考慮して計算されます。スケーリングは、印刷物など高品質な画像が必要な場合に特に有用です。
```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // スケーリング付きで形状をメモリ内にビットマップとして保存します。
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // メモリから形状ビットマップを作成します。
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // 第2段落の境界を計算します。
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // 出力画像の座標とサイズを計算します（最小サイズは 1x1 ピクセル）。
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // 形状ビットマップを切り取り、段落のビットマップだけを取得します。
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

はい。テキスト フレームのラッピング設定（[setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/)）を使用してラッピングをオフにすれば、行はフレームの端で折り返されません。

**特定の段落のスライド上での正確な境界を取得する方法は？**

段落（または単一のポーション）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズを知ることができます。

**段落の配置（左揃え/右揃え/中央揃え/均等割り付け）はどこで制御しますか？**

[ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) の [Alignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) は段落レベルの設定で、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部（例: 1 単語）だけにスペルチェック言語を設定できますか？**

はい。言語はポーションレベルで設定される（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)）ため、1 つの段落内に複数の言語を共存させることが可能です。