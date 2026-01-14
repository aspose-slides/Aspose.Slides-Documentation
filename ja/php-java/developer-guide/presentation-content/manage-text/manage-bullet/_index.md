---
title: PHP を使用したプレゼンテーションでの箇条書きと番号付きリストの管理
linktitle: リストの管理
type: docs
weight: 60
url: /ja/php-java/manage-bullet/
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- シンボル箇条書き
- 画像箇条書き
- カスタム箇条書き
- 多層リスト
- 箇条書き作成
- 箇条書き追加
- リスト追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションで箇条書きと番号付きリストを管理する方法を学びます。ステップバイステップのガイド。"
---

**Microsoft PowerPoint** では、Word や他のテキストエディタと同様に、箇条書きと番号付きリストを作成できます。**Aspose.Slides for PHP via Java** でも、スライド内で箇条書きや番号を使用できます。

## **箇条書きを使用する理由は？**

箇条書きは、情報を迅速かつ効果的に整理・提示するのに役立ちます。

**箇条書きの例**

ほとんどの場合、箇条書きは次の 3 つの主な機能を果たします：

- 読者や視聴者の注意を重要な情報に向ける
- 読者や視聴者が重要なポイントを簡単にスキャンできるようにする
- 重要な詳細を効率的に伝達する

## **番号付きリストを使用する理由は？**

番号付きリストも情報の整理と提示に役立ちます。エントリの順序（例：*step 1、step 2* など）が重要な場合や、エントリを参照する必要がある場合（例：*see step 3*）は、箇条書きの代わりに番号を使用すべきです。

**番号付きリストの例**

以下の **Creating Bullets** 手順のステップ（step 1 から step 15）概要です：

1. プレゼンテーション クラスのインスタンスを作成します。
2. いくつかのタスクを実行します（step 3〜step 14）。
3. プレゼンテーションを保存します。

## **箇条書きの作成**

このトピックは、テキスト段落の管理に関するシリーズの一部でもあります。このページでは、段落の箇条書きの管理方法を示します。手順で何かを説明する場合、箇条書きは非常に有用です。さらに、箇条書きを使用するとテキストが整理されて見えます。箇条書きの段落は常に読みやすく、理解しやすいです。開発者が Aspose.Slides for PHP via Java のこの小さくても強力な機能をどのように使用できるかを見ていきます。以下の手順に従って、Aspose.Slides for PHP via Java を使用して段落の箇条書きを管理してください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) オブジェクトを使用してスライド コレクション内の目的のスライドにアクセスします。
1. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
1. TextFrame のデフォルト段落を削除します。
1. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
1. 段落の箇条書きタイプを設定します。
1. 箇条書きタイプを [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol) に設定し、箇条書き文字を指定します。
1. 段落テキストを設定します。
1. 箇条書きを設定するために段落インデントを設定します。
1. 箇条書きの色を設定します。
1. 箇条書きの高さを設定します。
1. 作成した段落を TextFrame の段落コレクションに追加します。
1. 2 番目の段落を追加し、**7 から 13** の手順を繰り返します。
1. プレゼンテーションを保存します。

```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # オートシェイプを追加しアクセス
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 作成したオートシェイプのテキストフレームにアクセス
    $txtFrm = $aShp->getTextFrame();
    # デフォルトの既存段落を削除
    $txtFrm->getParagraphs()->removeAt(0);
    # 段落を作成
    $para = new Paragraph();
    # 段落の箇条書きスタイルと記号を設定
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # 段落テキストを設定
    $para->setText("Welcome to Aspose.Slides");
    # 箇条書きインデントを設定
    $para->getParagraphFormat()->setIndent(25);
    # 箇条書きの色を設定
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # 独自の箇条書き色を使用するために IsBulletHardColor を true に設定
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # 箇条書きの高さを設定
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 段落をテキストフレームに追加
    $txtFrm->getParagraphs()->add($para);
    # プレゼンテーションを PPTX ファイルとして保存
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **画像箇条書きの作成**

Aspose.Slides for PHP via Java は、箇条書きリストの箇条書きを変更できます。箇条書きをカスタムシンボルや画像に置き換えることができます。リストに視覚的な興味を加えたり、エントリへの注目度をさらに高めたい場合は、独自の画像を箇条書きとして使用できます。

{{% alert color="primary" %}} 
理想的には、通常の箇条書きシンボルを画像に置き換える場合、透明な背景を持つシンプルなグラフィック画像を選択するとよいでしょう。このような画像はカスタム箇条書きシンボルとして最適です。 
いずれにせよ、選択した画像は非常に小さなサイズに縮小されるため、リスト内で箇条書きシンボルの代替として見栄えが良い画像を選択することを強く推奨します。 
{{% /alert %}} 

画像箇条書きを作成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します
1. [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) オブジェクトを使用してスライド コレクション内の目的のスライドにアクセスします
1. 選択したスライドに autoshape を追加します
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします
1. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) のデフォルト段落を削除します
1. Paragraph クラスを使用して最初の段落インスタンスを作成します
1. [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) でディスクから画像を読み込みます
1. 箇条書きタイプを Picture に設定し、画像を指定します
1. 段落テキストを設定します
1. 箇条書きを設定するために段落インデントを設定します
1. 箇条書きの色を設定します
1. 箇条書きの高さを設定します
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) の段落コレクションに追加します
1. 2 番目の段落を追加し、前の手順を繰り返します
1. プレゼンテーションを保存します

```php
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # 箇条書き用画像をインスタンス化
    $picture;
    $image = Images->fromFile("asp1.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # オートシェイプを追加しアクセス
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 作成したオートシェイプのテキストフレームにアクセス
    $txtFrm = $aShp->getTextFrame();
    # 既定の既存段落を削除
    $txtFrm->getParagraphs()->removeAt(0);
    # 新しい段落を作成
    $para = new Paragraph();
    $para->setText("Welcome to Aspose.Slides");
    # 段落の箇条書きスタイルと画像を設定
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # 箇条書きの高さを設定
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 段落をテキストフレームに追加
    $txtFrm->getParagraphs()->add($para);
    # プレゼンテーションを PPTX ファイルとして保存
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **多層箇条書きの作成**

異なるレベルの項目（メインの箇条書きの下に追加のリスト）を含む箇条書きリストを作成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) オブジェクトを使用してスライド コレクション内の目的のスライドにアクセスします。
1. 選択したスライドに autoshape を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) のデフォルト段落を削除します。
1. Paragraph クラスを使用して深さ 0 に設定した最初の段落インスタンスを作成します。
1. Paragraph クラスを使用して深さ 1 に設定した第2の段落インスタンスを作成します。
1. Paragraph クラスを使用して深さ 2 に設定した第3の段落インスタンスを作成します。
1. Paragraph クラスを使用して深さ 3 に設定した第4の段落インスタンスを作成します。
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) の段落コレクションに追加します。
1. プレゼンテーションを保存します。

```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # オートシェイプを追加しアクセス
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 作成したオートシェイプのテキストフレームにアクセス
    $txtFrm = $aShp->addTextFrame("");
    # 既定の既存段落を削除
    $txtFrm->getParagraphs()->clear();
    # 最初の段落を作成
    $para1 = new Paragraph();
    # 段落の箇条書きスタイルと記号を設定
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きレベルを設定
    $para1->getParagraphFormat()->setDepth(0);
    # 2 番目の段落を作成
    $para2 = new Paragraph();
    # 段落の箇条書きスタイルと記号を設定
    $para2->setText("Second level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きレベルを設定
    $para2->getParagraphFormat()->setDepth(1);
    # 3 番目の段落を作成
    $para3 = new Paragraph();
    # 段落の箇条書きスタイルと記号を設定
    $para3->setText("Third level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きレベルを設定
    $para3->getParagraphFormat()->setDepth(2);
    # 4 番目の段落を作成
    $para4 = new Paragraph();
    # 段落の箇条書きスタイルと記号を設定
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 箇条書きレベルを設定
    $para4->getParagraphFormat()->setDepth(3);
    # 段落をテキストフレームに追加
    $txtFrm->getParagraphs()->add($para1);
    $txtFrm->getParagraphs()->add($para2);
    $txtFrm->getParagraphs()->add($para3);
    $txtFrm->getParagraphs()->add($para4);
    # プレゼンテーションを PPTX ファイルとして保存
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **カスタム番号付きリストの作成**

Aspose.Slides for PHP via Java は、カスタム番号書式を使用した段落を管理するシンプルな API を提供します。段落にカスタム番号リストを追加するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) オブジェクトを使用してスライド コレクション内の目的のスライドにアクセスします。
1. 選択したスライドに autoshape を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) のデフォルト段落を削除します。
1. Paragraph クラスを使用して最初の段落インスタンスを作成し、**NumberedBulletStartWith** を 2 に設定します。
1. Paragraph クラスを使用して第2の段落インスタンスを作成し、**NumberedBulletStartWith** を 3 に設定します。
1. Paragraph クラスを使用して第3の段落インスタンスを作成し、**NumberedBulletStartWith** を 7 に設定します。
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) の段落コレクションに追加します。
1. プレゼンテーションを保存します。

```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # オートシェイプを追加しアクセス
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 作成したオートシェイプのテキストフレームにアクセス
    $txtFrm = $aShp->addTextFrame("");
    # デフォルトの既存段落を削除
    $txtFrm->getParagraphs()->clear();
    # 最初のリスト
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # 2 番目のリスト
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 5");
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


## **FAQ**

**Aspose.Slides で作成した箇条書きおよび番号付きリストは、PDF や画像などの他の形式にエクスポートできますか？**

はい、Aspose.Slides は、プレゼンテーションを PDF、画像などの形式にエクスポートする際に、箇条書きおよび番号付きリストの書式と構造を完全に保持し、一貫した結果を保証します。

**既存のプレゼンテーションから箇条書きや番号付きリストをインポートすることは可能ですか？**

はい、Aspose.Slides を使用すると、既存のプレゼンテーションから箇条書きや番号付きリストをインポートして編集でき、元の書式や外観を保持したまま扱うことができます。

**Aspose.Slides は、複数の言語で作成されたプレゼンテーションの箇条書きや番号付きリストをサポートしていますか？**

はい、Aspose.Slides は多言語プレゼンテーションを完全にサポートしており、特殊文字や非ラテン文字を含む任意の言語で箇条書きや番号付きリストを作成できます。