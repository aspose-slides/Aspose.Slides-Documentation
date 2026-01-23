---
title: PHP を使用したプレゼンテーションのフォント管理
linktitle: フォント管理
type: docs
weight: 10
url: /ja/php-java/manage-fonts/
keywords:
- フォント管理
- フォントプロパティ
- 段落
- テキスト書式設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でフォントを制御します：埋め込み、置換、カスタムフォントの読み込みにより、PPT、PPTX、ODP のプレゼンテーションを明瞭でブランドに安全かつ一貫性のある状態に保ちます。"
---

## **フォント関連プロパティの管理**
{{% alert color="primary" %}} 

プレゼンテーションには通常、テキストと画像の両方が含まれます。テキストは、特定のセクションや単語を強調したり、企業スタイルに合わせたりするために、さまざまな方法で書式設定できます。テキストの書式設定は、ユーザーがプレゼンテーション コンテンツの外観や感覚を変えるのに役立ちます。本稿では、Aspose.Slides for PHP via Java を使用して、スライド上のテキスト段落のフォントプロパティを構成する方法を示します。

{{% /alert %}} 

Aspose.Slides for PHP via Java を使用して段落のフォントプロパティを管理するには、以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内の [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) シェイプにアクセスし、それらを [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) に型キャストします。
1. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) が提供する [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) から [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) を取得します。
1. 段落を両端揃えにします。
1. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) のテキスト [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) にアクセスします。
1. [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) を使用してフォントを定義し、テキスト [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) の **Font** を設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
1. [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) オブジェクトが提供する [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) を使用してフォント色を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

上記の手順の実装例を以下に示します。装飾のないプレゼンテーションを取得し、スライドのフォントをフォーマットします。以下のスクリーンショットは入力ファイルとコードスニペットがどのようにそれを変更するかを示しています。コードはフォント、色、フォントスタイルを変更します。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**図: 入力ファイルのテキスト**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**図: 同じテキストの更新された書式**|
```php
  # PPTX ファイルを表す Presentation オブジェクトをインスタンス化
  $pres = new Presentation("FontProperties.pptx");
  try {
    # スライド位置を使用してスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型キャスト
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 最初の Paragraph にアクセス
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # 段落を両端揃えに設定
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # 最初の portion にアクセス
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # 新しいフォントを定義
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # 新しいフォントを portion に割り当て
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # フォントを太字に設定
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # フォントを斜体に設定
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # フォントの色を設定
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # PPTX をディスクに保存
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキストフォントプロパティの設定**
{{% alert color="primary" %}} 

**Managing Font Related Properties** で述べたように、[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) は段落内で同様の書式スタイルのテキストを保持するために使用されます。本稿では、Aspose.Slides for PHP via Java を使用してテキストボックスを作成し、テキストを追加し、特定のフォントとフォントファミリーカテゴリのさまざまなプロパティを定義する方法を示します。

{{% /alert %}} 

テキストボックスを作成し、そのテキストのフォントプロパティを設定するには、以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドにタイプ **Rectangle** の [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
1. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) に関連付けられた塗りつぶしスタイルを削除します。
1. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) の [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にテキストを追加します。
1. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) に関連付けられた [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) オブジェクトにアクセスします。
1. [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) に使用するフォントを定義します。
1. [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) オブジェクトが提供する関連プロパティを使用して、太字、斜体、下線、色、サイズなどの他のフォントプロパティを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

上記の手順の実装例を以下に示します。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**図: Aspose.Slides for PHP via Java によって設定されたフォントプロパティを持つテキスト**|
```php
  # PPTX ファイルを表す Presentation オブジェクトをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # Rectangle タイプの AutoShape を追加
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # AutoShape に関連付けられた塗りつぶしスタイルを削除
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # AutoShape に関連付けられた TextFrame にアクセス
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # TextFrame に関連付けられた Portion にアクセス
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Portion のフォントを設定
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # フォントの太字プロパティを設定
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # フォントの斜体プロパティを設定
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # フォントの下線プロパティを設定
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # フォントのサイズ（高さ）を設定
    $port->getPortionFormat()->setFontHeight(25);
    # フォントの色を設定
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # プレゼンテーションをディスクに保存
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
