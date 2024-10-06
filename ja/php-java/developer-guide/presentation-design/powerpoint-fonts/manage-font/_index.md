---
title: フォントの管理 - PowerPoint Java API
linktitle: フォントの管理
type: docs
weight: 10
url: /ja/php-java/manage-fonts/
description: プレゼンテーションには通常、テキストと画像の両方が含まれています。この記事では、PowerPoint Java APIを使用してスライド上のテキスト段落のフォントプロパティを設定する方法を示します。
---

## **フォント関連プロパティの管理**
{{% alert color="primary" %}} 

プレゼンテーションには通常、テキストと画像の両方が含まれています。テキストは特定のセクションや単語を強調表示するため、または企業スタイルに準拠するために、さまざまな方法でフォーマットできます。テキストのフォーマットは、ユーザーがプレゼンテーションの内容の外観と感触を変えるのに役立ちます。この記事では、Aspose.Slides for PHP via Javaを使用してスライド上のテキスト段落のフォントプロパティを設定する方法を示します。

{{% /alert %}} 

Aspose.Slides for PHP via Javaを使用して段落のフォントプロパティを管理するには：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内の[Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Placeholder)シェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape)に型キャストします。
1. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape)が公開する[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame)から[Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph)を取得します。
1. 段落を均等割り付けします。
1. [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph)のテキスト[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion)にアクセスします。
1. [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FontData)を使用してフォントを定義し、テキスト[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion)の**Font**を適宜設定します。
   1. フォントを太字に設定します。
   1. フォントをイタリック体に設定します。
1. [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion)オブジェクトが公開する[FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FillFormat)を使用してフォントの色を設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

上記の手順の実装は以下に示します。装飾のないプレゼンテーションを取り、スライドの1つ上でフォントをフォーマットします。続くスクリーンショットは、入力ファイルとコードスニペットがどのように変更するかを示しています。このコードはフォント、色、およびフォントスタイルを変更します。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**図: 入力ファイルのテキスト**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**図: 更新されたフォーマットの同じテキスト**|

```php
  # PPTXファイルを表すPresentationオブジェクトをインスタンス化する
  $pres = new Presentation("FontProperties.pptx");
  try {
    # スライド位置を使用してスライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShapeとして型キャストする
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 最初の段落にアクセスする
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # 段落を均等割り付けする
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # 最初のポーションにアクセスする
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # 新しいフォントを定義する
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # ポーションに新しいフォントを割り当てる
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # フォントを太字に設定する
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # フォントをイタリック体に設定する
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # フォントの色を設定する
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # PPTXをディスクに保存する
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テキストフォントプロパティの設定**
{{% alert color="primary" %}} 

**フォント関連プロパティの管理**で述べたように、[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion)は、段落内の同様のフォーマットスタイルのテキストを保持するために使用されます。この記事では、Aspose.Slides for PHP via Javaを使用して、いくつかのテキストを含むテキストボックスを作成し、特定のフォントとフォントファミリーカテゴリのさまざまなプロパティを定義する方法を示します。

{{% /alert %}} 

テキストボックスを作成し、その中のテキストのフォントプロパティを設定するには：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライドに**長方形**タイプの[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape)を追加します。
1. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape)に関連する塗りつぶしスタイルを削除します。
1. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape)の[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame)にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame)にいくつかのテキストを追加します。
1. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame)に関連付けられた[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion)オブジェクトにアクセスします。
1. [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion)に使用されるフォントを定義します。
1. [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion)オブジェクトによって公開された関連プロパティを使用して、太字、イタリック体、下線、色、高さなどの他のフォントプロパティを設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

上記の手順の実装は以下に示します。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**図: Aspose.Slides for PHP via Javaで設定したフォントプロパティを持つテキスト**|

```php
  # PPTXファイルを表すPresentationオブジェクトをインスタンス化する
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 長方形タイプのAutoShapeを追加
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # AutoShapeに関連する塗りつぶしスタイルを削除
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # AutoShapeに関連付けられたTextFrameにアクセス
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # TextFrameに関連するポーションにアクセス
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # ポーションのフォントを設定する
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # フォントの太字プロパティを設定
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # フォントのイタリック体プロパティを設定
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # フォントの下線プロパティを設定
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # フォントの高さを設定
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