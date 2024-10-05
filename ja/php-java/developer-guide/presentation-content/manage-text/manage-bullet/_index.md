---
title: 弾丸の管理
type: docs
weight: 60
url: /php-java/manage-bullet/
keywords: "弾丸, 弾丸リスト, 数字, 番号付きリスト, 画像の弾丸, 多層弾丸, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションで弾丸と番号付きリストを作成する"
---

**Microsoft PowerPoint**では、Wordや他のテキストエディタと同じ方法で弾丸と番号付きリストを作成できます。**Aspose.Slides for PHP via Java**は、プレゼンテーションのスライドに弾丸と番号を使用することも可能です。

## なぜ弾丸リストを使用するのか？

弾丸リストは、情報を迅速かつ効率的に整理し、提示するのに役立ちます。 

**弾丸リストの例**

ほとんどの場合、弾丸リストは次の3つの主な機能を果たします：

- 読者や視聴者の注意を重要な情報に引き付ける
- 読者や視聴者が重要なポイントを簡単にスキャンできるようにする
- 重要な詳細を効率的に伝達する。

## なぜ番号付きリストを使用するのか？

番号付きリストも情報を整理し提示するのに役立ちます。理想的には、エントリの順序（例えば、*ステップ1, ステップ2*など）が重要な場合や、エントリを参照する必要がある場合（例えば、*ステップ3参照*）、番号を使用すべきです。

**番号付きリストの例**

以下は、**弾丸の作成**手順（ステップ1からステップ15）の要約です：

1. プレゼンテーションクラスのインスタンスを作成します。
2. いくつかのタスクを実行します（ステップ3からステップ14）。
3. プレゼンテーションを保存します。

## 弾丸の作成
このトピックは、テキスト段落を管理するトピックシリーズの一部でもあります。このページでは、段落の弾丸を管理する方法を示します。弾丸は何かをステップで説明する場合により便利です。さらに、弾丸を使用するとテキストが整理されて見えます。弾丸付きの段落は常に読みやすく理解しやすいです。この小さくても強力なAspose.Slides for PHP via Javaの機能を開発者がどのように使用するかを見ることになります。以下の手順に従って、Aspose.Slides for PHP via Javaを使用して段落の弾丸を管理してください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)オブジェクトを使用してスライドコレクション内の目的のスライドにアクセスします。
1. 選択したスライドに[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText)を追加します。
1. 追加した形状の[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)にアクセスします。
1. TextFrame内のデフォルトの段落を削除します。
1. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph)クラスを使用して最初の段落インスタンスを作成します。
1. 段落の弾丸の種類を設定します。
1. 弾丸の種類を[Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/BulletType#Symbol)に設定し、弾丸文字を設定します。
1. 段落テキストを設定します。
1. 弾丸を設定するために段落のインデントを設定します。
1. 弾丸の色を設定します。
1. 弾丸の高さを設定します。
1. 作成した段落をTextFrameの段落コレクションに追加します。
1. 二つ目の段落を追加し、**7から13**の手順を繰り返します。
1. プレゼンテーションを保存します。

このサンプルコードは、上記の手順の実装で、スライドに弾丸リストを作成する方法を示しています：

```php
  # PPTXファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # Autoshapeの追加とアクセス
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 生成したautoshapeのテキストフレームにアクセス
    $txtFrm = $aShp->getTextFrame();
    # デフォルトの既存の段落を削除
    $txtFrm->getParagraphs()->removeAt(0);
    # 段落を作成
    $para = new Paragraph();
    # 段落の弾丸スタイルとシンボルを設定
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # 段落テキストを設定
    $para->setText("Aspose.Slidesへようこそ");
    # 弾丸のインデントを設定
    $para->getParagraphFormat()->setIndent(25);
    # 弾丸の色を設定
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # 自分の弾丸の色を使用するにはIsBulletHardColorをtrueに設定
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # 弾丸の高さを設定
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # テキストフレームに段落を追加
    $txtFrm->getParagraphs()->add($para);
    # プレゼンテーションをPPTXファイルとして保存
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## 画像の弾丸を作成する

Aspose.Slides for PHP via Javaでは、弾丸リストの弾丸を変更することができます。弾丸をカスタムシンボルまたは画像に置き換えることができます。リストに視覚的な魅力を加えたり、リスト上のエントリにさらに注意を引くために、自分の画像を弾丸として使用することができます。

{{% alert color="primary" %}} 

理想的には、通常の弾丸シンボルを画像で置き換える場合、透明な背景を持つシンプルなグラフィック画像を選択したいです。そのような画像はカスタム弾丸シンボルとして最適です。

いずれにせよ、選択する画像は非常に小さなサイズに縮小されるため、リスト内の弾丸シンボルの代替として見栄えが良い画像を選択することを強くお勧めします。

{{% /alert %}} 

画像の弾丸を作成するには、これらの手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)オブジェクトを使用してスライドコレクション内の目的のスライドにアクセスします。
1. 選択したスライドにautoshapeを追加します。
1. 追加した形状の[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)内のデフォルトの段落を削除します。
1. Paragraphクラスを使用して最初の段落インスタンスを作成します。
1. [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPPImage)からディスクの画像をロードします。
1. 弾丸の種類をPictureに設定し、画像を設定します。
1. 段落テキストを設定します。
1. 弾丸を設定するために段落のインデントを設定します。
1. 弾丸の色を設定します。
1. 弾丸の高さを設定します。
1. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)の段落コレクションに作成した段落を追加します。
1. 二つ目の段落を追加し、前の手順を繰り返します。
1. プレゼンテーションを保存します。

このPHPコードは、スライド内に画像の弾丸を作成する方法を示しています：

```php
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # 弾丸用の画像をインスタンス化
    $picture;
    $image = Images->fromFile("asp1.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Autoshapeの追加とアクセス
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 生成したautoshapeのテキストフレームにアクセス
    $txtFrm = $aShp->getTextFrame();
    # デフォルトの既存の段落を削除
    $txtFrm->getParagraphs()->removeAt(0);
    # 新しい段落を作成
    $para = new Paragraph();
    $para->setText("Aspose.Slidesへようこそ");
    # 段落の弾丸スタイルと画像を設定
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # 弾丸の高さを設定
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # テキストフレームに段落を追加
    $txtFrm->getParagraphs()->add($para);
    # プレゼンテーションをPPTXファイルとして保存
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 多層弾丸の作成

異なるレベルにアイテムを含む弾丸リスト（主要な弾丸リストの下の追加リスト）を作成するには、これらの手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)オブジェクトを使用してスライドコレクション内の目的のスライドにアクセスします。
1. 選択したスライドにautoshapeを追加します。
1. 追加した形状の[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)内のデフォルトの段落を削除します。
1. Paragraphクラスを使用して最初の段落インスタンスを作成し、深さを0に設定します。
1. Paragraphクラスを使用して二つ目の段落インスタンスを作成し、深さを1に設定します。
1. Paragraphクラスを使用して三つ目の段落インスタンスを作成し、深さを2に設定します。
1. Paragraphクラスを使用して四つ目の段落インスタンスを作成し、深さを3に設定します。
1. 作成した段落を[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)の段落コレクションに追加します。
1. プレゼンテーションを保存します。

このコードは、上記の手順の実装で、多層弾丸リストを作成する方法を示しています：

```php
  # PPTXファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # Autoshapeの追加とアクセス
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 生成したautoshapeのテキストフレームにアクセス
    $txtFrm = $aShp->addTextFrame("");
    # デフォルトの既存の段落を削除
    $txtFrm->getParagraphs()->clear();
    # 最初の段落を作成
    $para1 = new Paragraph();
    # 段落の弾丸スタイルとシンボルを設定
    $para1->setText("コンテンツ");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 弾丸レベルを設定
    $para1->getParagraphFormat()->setDepth(0);
    # 二つ目の段落を作成
    $para2 = new Paragraph();
    # 段落の弾丸スタイルとシンボルを設定
    $para2->setText("第二レベル");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 弾丸レベルを設定
    $para2->getParagraphFormat()->setDepth(1);
    # 三つ目の段落を作成
    $para3 = new Paragraph();
    # 段落の弾丸スタイルとシンボルを設定
    $para3->setText("第三レベル");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 弾丸レベルを設定
    $para3->getParagraphFormat()->setDepth(2);
    # 四つ目の段落を作成
    $para4 = new Paragraph();
    # 段落の弾丸スタイルとシンボルを設定
    $para4->setText("第四レベル");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 弾丸レベルを設定
    $para4->getParagraphFormat()->setDepth(3);
    # テキストフレームに段落を追加
    $txtFrm->getParagraphs()->add($para1);
    $txtFrm->getParagraphs()->add($para2);
    $txtFrm->getParagraphs()->add($para3);
    $txtFrm->getParagraphs()->add($para4);
    # プレゼンテーションをPPTXファイルとして保存
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## カスタム番号付きリストの作成
Aspose.Slides for PHP via Javaは、カスタム番号形式で段落を管理するためのシンプルなAPIを提供します。段落にカスタム番号リストを追加するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)オブジェクトを使用してスライドコレクション内の目的のスライドにアクセスします。
1. 選択したスライドにautoshapeを追加します。
1. 追加した形状の[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)内のデフォルトの段落を削除します。
1. Paragraphクラスを使用して最初の段落インスタンスを作成し、**NumberedBulletStartWith**を2に設定します。
1. Paragraphクラスを使用して二つ目の段落インスタンスを作成し、**NumberedBulletStartWith**を3に設定します。
1. Paragraphクラスを使用して三つ目の段落インスタンスを作成し、**NumberedBulletStartWith**を7に設定します。
1. 作成した段落を[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)の段落コレクションに追加します。
1. プレゼンテーションを保存します。

このPHPコードは、スライド内に番号付きリストを作成する方法を示しています：

```php
  # PPTXファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # Autoshapeの追加とアクセス
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 生成したautoshapeのテキストフレームにアクセス
    $txtFrm = $aShp->addTextFrame("");
    # デフォルトの既存の段落を削除
    $txtFrm->getParagraphs()->clear();
    # 一つ目のリスト
    $paragraph1 = new Paragraph();
    $paragraph1->setText("弾丸 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("弾丸 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # 二つ目のリスト
    $paragraph5 = new Paragraph();
    $paragraph5->setText("弾丸 5");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(5);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph5);
    $pres->save($resourcesOutputPath . "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```