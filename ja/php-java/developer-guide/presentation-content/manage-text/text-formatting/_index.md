---
title: PHPでPowerPointテキストをフォーマットする
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/php-java/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
- 段落の配置
- テキストスタイル
- テキスト背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- 自動調整プロパティ
- テキストフレームアンカー
- テキストタブ
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---

## **テキストのハイライト**

Method [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/highlighttext/) が [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) クラスに追加されました。

テキストサンプルを使用して背景色でテキストの一部をハイライトでき、PowerPoint 2019 のテキストハイライトカラー ツールと似ています。

以下のコードスニペットはこの機能の使用方法を示しています。
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// すべての単語 'important' をハイライト

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// すべての個別の 'the' の出現箇所をハイライト

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
Aspose はシンプルな、[無料のオンライン PowerPoint 編集サービス](https://products.aspose.app/slides/editor) を提供しています
{{% /alert %}} 

## **正規表現を使用したテキストのハイライト**

Method [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/highlightregex/) が [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) クラスに追加されました。

正規表現を使用して背景色でテキストの一部をハイライトでき、PowerPoint 2019 のテキストハイライトカラー ツールと似ています。

以下のコードスニペットはこの機能の使用方法を示しています。
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// 10文字以上のすべての単語をハイライト

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキストの背景色の設定**

Aspose.Slides ではテキストの背景色を好きな色に指定できます。

この PHP コードはテキスト全体の背景色を設定する方法を示しています。
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->spliterator(), false)->map(( p) -> $p->getPortions())->forEach(( c) -> $c->forEach(( ic) -> $ic->getPortionFormat()->getHighlightColor()->setColor($Color.BLUE)));
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


この PHP コードはテキストの一部だけの背景色を設定する方法を示しています。
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("Red"))->findFirst();
    if ($redPortion->isPresent()) {
      $redPortion->get()->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->RED);
    }
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **テキスト段落の配置**

テキストの書式設定は、ドキュメントやプレゼンテーションを作成する際の重要な要素です。Aspose.Slides for PHP via Java がスライドへのテキスト追加をサポートしていることは周知の事実ですが、本トピックではスライド内のテキスト段落の配置方法を解説します。以下の手順でテキスト段落を配置してください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内の Placeholder シェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) に型変換します。
4. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) が公開する [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) から、配置したい Paragraph を取得します。
5. Paragraph を配置します。段落は右揃え、左揃え、中央揃え、両端揃えのいずれかに設定できます。
6. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

上記手順の実装例は以下のとおりです。
```php
  # PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # 最初のスライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型変換する
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 両方のプレースホルダーのテキストを変更する
    $tf1->setText("Center Align by Aspose");
    $tf2->setText("Center Align by Aspose");
    # プレースホルダーの最初の段落を取得する
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # テキスト段落を中央揃えにする
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # プレゼンテーションを PPTX ファイルとして書き出す
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキストの透明度の設定**

この記事では Aspose.Slides for PHP via Java を使用して、任意のテキストシェイプに透明度プロパティを設定する方法を示します。透明度をテキストに設定する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. シャドウ色を設定します。
4. プレゼンテーションを PPTX ファイルとして書き出します。

上記手順の実装例は以下のとおりです。
```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - transparency is: " . $shadowColor->getAlpha() / 255.0 * 100);
    # 透明度をゼロパーセントに設定
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキストの文字間隔の設定**

Aspose.Slides ではテキストボックス内の文字間隔を設定できます。これにより、文字間のスペースを拡張または縮小して、行やブロックの視覚的密度を調整できます。

この PHP コードは、ある行の文字間を拡張し、別の行の文字間を縮小する方法を示しています。
```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// 拡張

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// 縮小

  $presentation->save("out.pptx", SaveFormat::Pptx);
```


## **段落のフォントプロパティの管理**

プレゼンテーションは通常、テキストと画像の両方を含みます。テキストは強調表示や企業スタイルへの適合など、さまざまな方法で書式設定できます。テキストの書式設定により、プレゼンテーション内容の外観と感触を変更できます。本記事では Aspose.Slides for PHP via Java を使用して、スライド上の段落テキストのフォントプロパティを構成する方法を示します。段落のフォントプロパティを管理する手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内の Placeholder シェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) に型変換します。
1. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) が公開する [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) から [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) を取得します。
1. 段落を両端揃えにします。
1. 段落のテキスト Portion にアクセスします。
1. FontData を使用してフォントを定義し、Portion の Font に設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
1. [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) オブジェクトが公開する [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) でフォントの色を設定します。
1. 修正したプレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き出します。

上記手順の実装例は以下のとおりです。装飾のないプレゼンテーションを取得し、1 つのスライドのフォントをフォーマットします。
```php
  # PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
  $pres = new Presentation("FontProperties.pptx");
  try {
    # スライド位置を使用してスライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # スライド内の最初と 2 番目のプレースホルダーにアクセスし、AutoShape に型変換する
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 最初の Paragraph にアクセスする
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # 最初の Portion にアクセスする
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # 新しいフォントを定義する
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # 新しいフォントを Portion に割り当てる
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # フォントを太字に設定する
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # フォントを斜体に設定する
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # フォントの色を設定する
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $port2->getPortionFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # PPTX をディスクに書き出す
    $pres->save("WelcomeFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキストのフォントファミリの管理**

Portion は段落内で同じ書式スタイルのテキストを保持するために使用されます。本記事では Aspose.Slides for PHP via Java を使用して、テキストボックスを作成し、特定のフォントとフォントファミリカテゴリのさまざまなプロパティを定義する方法を示します。テキストボックスを作成し、テキストのフォントプロパティを設定する手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/#Rectangle) タイプの [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) を追加します。
4. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) に設定されている塗りつぶしスタイルを削除します。
5. AutoShape の TextFrame にアクセスします。
6. TextFrame にテキストを追加します。
7. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) に関連付けられた Portion オブジェクトにアクセスします。
8. [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) に使用するフォントを定義します。
9. Portion オブジェクトが公開する太字、斜体、下線、色、高さなどのプロパティでフォントのその他の属性を設定します。
10. 修正したプレゼンテーションを PPTX ファイルとして書き出します。

上記手順の実装例は以下のとおりです。
```php
  # Presentation をインスタンス化する
  $pres = new Presentation();
  try {
    # 最初のスライドを取得する
    $sld = $pres->getSlides()->get_Item(0);
    # 矩形タイプの AutoShape を追加する
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # AutoShape に関連付けられた塗りつぶしスタイルを削除する
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # AutoShape に関連付けられた TextFrame にアクセスする
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # TextFrame に関連付けられた Portion にアクセスする
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Portion のフォントを設定する
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # フォントの太字プロパティを設定する
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # フォントの斜体プロパティを設定する
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # フォントの下線プロパティを設定する
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # フォントの高さを設定する
    $port->getPortionFormat()->setFontHeight(25);
    # フォントの色を設定する
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # PPTX をディスクに書き出す
    $pres->save("SetTextFontProperties_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキストのフォントサイズの設定**

Aspose.Slides では段落内の既存テキストや、後から段落に追加されるテキストのフォントサイズを好きなサイズに設定できます。

この PHP コードは段落内のテキストに対してフォントサイズを設定する方法を示しています。
```php
  $presentation = new Presentation("example.pptx");
  try {
    # 例えば、最初のシェイプを取得します。
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # 例えば、最初の段落を取得します。
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # 段落内のすべてのテキスト部分の既定フォントサイズを 20 pt に設定します。
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # 段落内の現在のテキスト部分のフォントサイズを 20 pt に設定します。
      foreach($paragraph->getPortions() as $portion) {
        $portion->getPortionFormat()->setFontHeight(20);
      }
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **テキストの回転設定**

Aspose.Slides for PHP via Java は開発者がテキストを回転させることを可能にします。テキストは次のいずれかの向きに設定できます: [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Horizontal)、[Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Vertical)、[Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Vertical270)、[WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#WordArtVertical)、[EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical)、[MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#MongolianVertical) または [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#WordArtVerticalRightToLeft)。任意の TextFrame のテキストを回転させる手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意のシェイプをスライドに追加します。
4. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
5. [テキストを回転させる](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/)。
6. ファイルをディスクに保存します。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 矩形タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # 矩形に TextFrame を追加
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # テキストフレームにアクセス
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # テキストフレーム用の Paragraph オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 段落用の Portion オブジェクトを作成
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # プレゼンテーションを保存
    $pres->save("RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **TextFrame のカスタム回転角度の設定**

Aspose.Slides for PHP via Java は、TextFrame のカスタム回転角度を設定できるようになりました。この項目では、例を示しながら Aspose.Slides で RotationAngle プロパティを設定する方法を説明します。新しいメソッド [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setrotationangle/) と [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/getrotationangle/) が [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/) クラスに追加され、TextFrame のカスタム回転角度を設定できます。RotationAngle を設定する手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. [回転角度を設定する](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setrotationangle/)。
4. プレゼンテーションを PPTX ファイルとして書き出します。

以下の例では RotationAngle プロパティを設定しています。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 矩形タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # 矩形に TextFrame を追加
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # テキストフレームにアクセス
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # テキストフレーム用の Paragraph オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 段落用の Portion オブジェクトを作成
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Text rotation example.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # プレゼンテーションを保存
    $pres->save($resourcesOutputPath . "RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **段落の行間設定**

Aspose.Slides は [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) の下に `SpaceAfter`、`SpaceBefore`、`SpaceWithin` プロパティを提供し、段落の行間を管理できます。これらのプロパティは次のように使用します。

* パーセンテージで行間を指定する場合は正の値を使用します。  
* ポイントで行間を指定する場合は負の値を使用します。

たとえば、`SpaceBefore` プロパティを -16 に設定すると、段落の行間は 16pt になります。

特定の段落の行間を指定する手順は以下のとおりです。

1. テキストを含む AutoShape があるプレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. TextFrame にアクセスします。
4. Paragraph にアクセスします。
5. Paragraph のプロパティを設定します。
6. プレゼンテーションを保存します。

この PHP コードは段落の行間を指定する方法を示しています。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation("Fonts.pptx");
  try {
    # インデックスでスライドの参照を取得
    $sld = $pres->getSlides()->get_Item(0);
    # TextFrame にアクセス
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # Paragraph にアクセス
    $para = $tf1->getParagraphs()->get_Item(0);
    # Paragraph のプロパティを設定
    $para->getParagraphFormat()->setSpaceWithin(80);
    $para->getParagraphFormat()->setSpaceBefore(40);
    $para->getParagraphFormat()->setSpaceAfter(40);
    # プレゼンテーションを保存
    $pres->save("LineSpacing_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **TextFrame の AutofitType プロパティの設定**

本項目ではテキストフレームのさまざまな書式設定プロパティを調査します。この記事では、テキストフレームの AutofitType プロパティ、テキストのアンカー設定、およびテキストの回転設定について解説します。Aspose.Slides for PHP via Java は任意のテキストフレームの AutofitType プロパティを設定できます。AutofitType は [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Normal) または [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Shape) に設定できます。Normal に設定するとシェイプは変わらず、テキストだけが調整されます。Shape に設定すると、シェイプ自体がテキストに合わせて変更されます。TextFrame の AutofitType プロパティを設定する手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意のシェイプをスライドに追加します。
4. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
5. [TextFrame の autofit type を設定する](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setautofittype/)。
6. ファイルをディスクに保存します。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # 矩形タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # 矩形に TextFrame を追加
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # テキストフレームにアクセス
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # テキストフレーム用の Paragraph オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 段落用の Portion オブジェクトを作成
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # プレゼンテーションを保存
    $pres->save($resourcesOutputPath . "formatText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **TextFrame のアンカー設定**

Aspose.Slides for PHP via Java は任意の TextFrame のアンカーを設定できます。TextAnchorType はテキストがシェイプ内のどこに配置されるかを指定します。アンカーは [Top](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Top)、[Center](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Center)、[Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Bottom)、[Justified](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Justified) または [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Distributed) に設定できます。任意の TextFrame のアンカーを設定する手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意のシェイプをスライドに追加します。
4. [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) にアクセスします。
5. [テキストアンカータイプを設定する](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setanchoringtype/)。
6. ファイルをディスクに保存します。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 矩形タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # 矩形に TextFrame を追加
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # テキストフレームにアクセス
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # テキストフレーム用の Paragraph オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 段落用の Portion オブジェクトを作成
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # プレゼンテーションを保存
    $pres->save("AnchorText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **プレゼンテーションのタブと EffectiveTabs**

すべてのテキストタブはピクセル単位で表されます。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**図: 2 つの明示的タブと 2 つのデフォルトタブ**|

- EffectiveTabs.ExplicitTabCount（この例では 2）プロパティは Tabs.Count と等しいです。
- EffectiveTabs コレクションには、Tabs コレクションとデフォルトタブのすべてが含まれます。
- EffectiveTabs.DefaultTabSize（294）プロパティはデフォルトタブ間の距離を示します（この例ではタブ 3 と 4）。
- EffectiveTabs.GetTabByIndex(index) で index = 0 は最初の明示的タブ（Position = 731）を返し、index = 1 は2番目のタブ（Position = 1241）を返します。index = 2 を指定すると最初のデフォルトタブ（Position = 1470）が返ります。
- EffectiveTabs.GetTabAfterPosition(pos) は、あるテキストの後の次のタブ位置を取得するために使用します。例としてテキスト "Hello World!" がある場合、"world!" を描画開始する位置を知る必要があります。まず "Hello" のピクセル長を計算し、その値で GetTabAfterPosition を呼び出します。すると "world!" を描画する次のタブ位置が得られます。

## **All-Caps 効果でテキストを抽出する**

PowerPoint で **All Caps** フォント効果を適用すると、スライド上のテキストは大文字で表示されますが、元のテキストは小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、入力されたままの文字列が返されます。対処法として、[TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) が `All` を示す場合、返された文字列を大文字に変換すれば、スライドに表示されている通りに出力できます。

サンプル2.pptx の最初のスライドに以下のテキストボックスがあるとします。

![The All Caps effect](all_caps_effect.png)

以下のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示しています。
```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $textPortion = $paragraph->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = $textPortion->getText()->toUpperCase();
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```


出力:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**スライド上のテーブルのテキストを変更する方法は？**

テーブルのテキストを変更するには、[Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) クラスを使用します。テーブル内のすべてのセルを走査し、各セルの `TextFrame` と `ParagraphFormat` プロパティにアクセスしてテキストを変更できます。

**PowerPoint スライドのテキストにグラデーションカラーを適用する方法は？**

グラデーションカラーを適用するには、[BasePortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/) の `getFillFormat` メソッドを使用します。`FillFormat` を `Gradient` に設定し、開始色と終了色、方向、透明度などのプロパティを定義してテキストにグラデーション効果を付与します。