---
title: PHPでPowerPointテキストの書式設定
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
- テキスト透過
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキスト回転
- 回転角度
- テキストフレーム
- 行間隔
- 自動サイズ調整プロパティ
- テキストフレームアンカー
- テキストタブ
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument のプレゼンテーション内のテキストの書式設定とスタイル設定を行います。フォント、色、配置などをカスタマイズできます。"
---

## **テキストのハイライト**
Method [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) has been added to [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) interface and [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) class.

テキストのサンプルを使用して背景色でテキストの一部をハイライトできるようになり、PowerPoint 2019 の「テキストハイライト」ツールと同様の機能です。

以下のコードスニペットはこの機能の使用方法を示しています:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// すべての単語 'important' をハイライト

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// すべての個別の 'the' の出現をハイライト

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

Aspose はシンプルな[無料のオンライン PowerPoint 編集サービス](https://products.aspose.app/slides/editor)を提供しています

{{% /alert %}} 

## **正規表現を使用したテキストのハイライト**

Method [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) has been added to [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) interface and [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) class.

正規表現を使用して背景色でテキストの一部をハイライトでき、PowerPoint 2019 の「テキストハイライト」ツールと同様の機能です。

以下のコードスニペットはこの機能の使用方法を示しています:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// 10文字以上の単語すべてをハイライト

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキスト背景色の設定**

Aspose.Slides ではテキストの背景色を任意の色で指定できます。

この PHP コードはテキスト全体の背景色を設定する方法を示しています:
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


この PHP コードはテキストの一部だけの背景色を設定する方法を示しています:
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

テキストの書式設定はドキュメントやプレゼンテーション作成時の重要な要素です。Aspose.Slides for PHP via Java はスライドにテキストを追加する機能をサポートしていますが、本トピックではスライド内のテキスト段落の配置方法を解説します。以下の手順に従ってテキスト段落を配置してください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内の Placeholder シェイプにアクセスし、[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) にキャストします。
4. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) が公開している [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) から配置対象の Paragraph を取得します。
5. Paragraph を配置します。Paragraph は右寄せ、左寄せ、中央寄せ、両端揃えに設定可能です。
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下のとおりです。
```php
  # PPTX ファイルを表す Presentation オブジェクトをインスタンス化
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型キャスト
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 両方のプレースホルダーのテキストを変更
    $tf1->setText("Center Align by Aspose");
    $tf2->setText("Center Align by Aspose");
    # プレースホルダーの最初の段落を取得
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # テキスト段落を中央揃えに設定
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # プレゼンテーションを PPTX ファイルとして保存
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキストの透明度の設定**
本記事では Aspose.Slides for PHP via Java を使用してテキストシェイプの透明度プロパティを設定する方法を示します。透明度を設定する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 影の色を設定します。
4. プレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下のとおりです。
```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - transparency is: " . $shadowColor->getAlpha() / 255.0 * 100);
    # 透明度を0％に設定
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキストの文字間隔の設定**

Aspose.Slides ではテキストボックス内の文字間のスペースを設定できます。これにより、文字間隔を拡大または縮小して、行やブロックの視覚的密度を調整できます。

以下の PHP コードは、1 行の文字間隔を拡大し、別の行の文字間隔を縮小する方法を示しています:
```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// 拡張
  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// 圧縮
  $presentation->save("out.pptx", SaveFormat::Pptx);
```


## **段落のフォントプロパティの管理**

プレゼンテーションは通常、テキストと画像の両方を含みます。テキストは特定のセクションや単語を強調したり、企業のスタイルに合わせたりするためにさまざまに書式設定できます。テキストの書式設定は、プレゼンテーションコンテンツの外観を変えるのに役立ちます。本稿では Aspose.Slides for PHP via Java を使用してスライド上の段落テキストのフォントプロパティを設定する方法を紹介します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内の Placeholder シェイプにアクセスし、[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) にキャストします。
1. [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) が公開している [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) から [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) を取得します。
1. 段落を両端揃えにします。
1. 段落のテキスト Portion にアクセスします。
1. FontData を使用してフォントを定義し、テキスト Portion のフォントを設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
1. [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion) オブジェクトが公開している [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--) を使用してフォントカラーを設定します。
1. 変更したプレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

上記手順の実装例は以下のとおりです。装飾のないプレゼンテーションを取得し、スライドの1枚のフォントをフォーマットします。
```php
  # PPTX ファイルを表す Presentation オブジェクトをインスタンス化
  $pres = new Presentation("FontProperties.pptx");
  try {
    # スライド位置を使用してスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShape に型キャスト
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 最初の段落にアクセス
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # 最初のポーションにアクセス
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # 新しいフォントを定義
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # ポーションに新しいフォントを割り当て
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # フォントを太字に設定
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # フォントをイタリックに設定
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # フォントの色を設定
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $port2->getPortionFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # PPTX をディスクに保存
    $pres->save("WelcomeFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキストのフォントファミリーの管理**
Portion は段落内で同一の書式スタイルを持つテキストを保持するために使用されます。本稿では Aspose.Slides for PHP via Java を使用してテキストボックスを作成し、特定のフォントやフォントファミリーに関するさまざまなプロパティを設定する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) 型の [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) に関連付けられた塗りつぶしスタイルを削除します。
5. AutoShape の TextFrame にアクセスします。
6. TextFrame にテキストを追加します。
7. [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) に関連付けられた Portion オブジェクトにアクセスします。
8. [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion) に使用するフォントを定義します。
9. 太字、斜体、下線、カラー、サイズなど、Portion オブジェクトが公開している関連プロパティを使用してその他のフォントプロパティを設定します。
10. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下のとおりです。
```php
  # Presentation をインスタンス化
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
    # フォントを太字に設定
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # フォントを斜体に設定
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # フォントに下線を設定
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # フォントの高さを設定
    $port->getPortionFormat()->setFontHeight(25);
    # フォントの色を設定
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # PPTX をディスクに保存
    $pres->save("SetTextFontProperties_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テキストのフォントサイズの設定**

Aspose.Slides では段落内の既存テキストや後から追加されるテキストに対して、任意のフォントサイズを選択できます。

この PHP コードは段落内のテキストにフォントサイズを設定する方法を示しています:
```php
  $presentation = new Presentation("example.pptx");
  try {
    # 例として最初のシェイプを取得します。
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # 例として最初の段落を取得します。
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # 段落内のすべてのテキストポーションに対してデフォルトフォントサイズを20ptに設定します。
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # 段落内の現在のテキストポーションのフォントサイズを20ptに設定します。
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

Aspose.Slides for PHP via Java では開発者がテキストを回転させることができます。テキストは次のいずれかの方向に設定可能です: [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal)、[Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical)、[Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270)、[WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical)、[EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical)、[MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) または [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft)。任意の TextFrame のテキストを回転させる手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意のシェイプをスライドに追加します。
4. [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) にアクセスします。
5. テキストの回転を設定します([setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-))。
6. ファイルをディスクに保存します。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # Rectangle タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Rectangle に TextFrame を追加
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # TextFrame にアクセス
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # TextFrame 用の Paragraph オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraph 用の Portion オブジェクトを作成
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


## **テキストフレームのカスタム回転角度の設定**
Aspose.Slides for PHP via Java はテキストフレームのカスタム回転角度設定をサポートします。本トピックでは、例を交えて RotationAngle プロパティの設定方法を紹介します。新しいメソッド [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) と [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) が [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) と [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) インターフェイスに追加され、テキストフレームのカスタム回転角度を設定できるようになりました。RotationAngle を設定する手順は以下のとおりです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. RotationAngle プロパティを設定します([setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-))。
4. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では RotationAngle プロパティを設定しています。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # Rectangle タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Rectangle に TextFrame を追加
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # TextFrame にアクセス
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # TextFrame 用の Paragraph オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraph 用の Portion オブジェクトを作成
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


## **段落の行間隔**
Aspose.Slides は `ParagraphFormat`（[`SpaceAfter`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat)、[`SpaceBefore`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat) 、[`SpaceWithin`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat)）のプロパティを提供し、段落の行間隔を管理できます。これら3つのプロパティは次のように使用します。

* パーセンテージで行間隔を指定する場合は正の値を使用します。
* ポイントで行間隔を指定する場合は負の値を使用します。

例として、`SpaceBefore` プロパティに -16 を設定すると、段落の行間隔を 16pt に設定できます。

特定の段落の行間隔を指定する手順は以下の通りです。

1. テキストを含む AutoShape が配置されたプレゼンテーションを読み込みます。
2. インデックスでスライドの参照を取得します。
3. TextFrame にアクセスします。
4. Paragraph にアクセスします。
5. Paragraph のプロパティを設定します。
6. プレゼンテーションを保存します。

この PHP コードは段落の行間隔を指定する方法を示しています:
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


## **テキストフレームのAutofitTypeプロパティの設定**
本稿ではテキストフレームのさまざまな書式設定プロパティを解説します。この記事ではテキストフレームの AutofitType プロパティ、テキストのアンカー設定、テキストの回転設定について取り上げます。Aspose.Slides for PHP via Java は任意のテキストフレームの AutofitType プロパティを設定でき、`Normal` または `Shape` に設定可能です。`Normal` に設定するとシェイプは変わらずテキストだけが調整され、`Shape` に設定するとシェイプ自体がテキストに合わせて変更されます。

テキストフレームの AutofitType プロパティを設定する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意のシェイプをスライドに追加します。
4. [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) にアクセスします。
5. TextFrame の AutofitType を設定します([setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-))。
6. ファイルをディスクに保存します。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # Rectangle タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # Rectangle に TextFrame を追加
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # TextFrame にアクセス
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # TextFrame 用の Paragraph オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraph 用の Portion オブジェクトを作成
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


## **テキストフレームのアンカー設定**
Aspose.Slides for PHP via Java は任意の TextFrame のアンカー設定をサポートします。TextAnchorType はテキストがシェイプ内のどこに配置されるかを指定し、`Top`、`Center`、`Bottom`、`Justified`、`Distributed` のいずれかに設定できます。

テキストフレームのアンカーを設定する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. 任意のシェイプをスライドに追加します。
4. [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) にアクセスします。
5. TextFrame の TextAnchorType を設定します([setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-))。
6. ファイルをディスクに保存します。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # Rectangle タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # Rectangle に TextFrame を追加
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # TextFrame にアクセス
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # TextFrame 用の Paragraph オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraph 用の Portion オブジェクトを作成
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


## **プレゼンテーションのタブとEffectiveTabs**
すべてのテキストタブはピクセル単位で指定されます。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**図: 明示的タブ2つとデフォルトタブ2つ**|

- EffectiveTabs.ExplicitTabCount (本例では 2) は Tabs.Count と同じです。
- EffectiveTabs コレクションは Tabs コレクションとデフォルトタブのすべてを含みます。
- EffectiveTabs.ExplicitTabCount (本例では 2) は Tabs.Count と同じです。
- EffectiveTabs.DefaultTabSize (294) はデフォルトタブ間の距離を示します（本例の 3 と 4 の間）。
- EffectiveTabs.GetTabByIndex(index) で index=0 は最初の明示的タブ (Position=731)、index=1 は2番目のタブ (Position=1241)。index=2 以降はデフォルトタブ (Position=1470) などが返ります。
- EffectiveTabs.GetTabAfterPosition(pos) はテキストの後続タブ位置を取得します。例: テキスト "Hello World!" がある場合、"Hello" のピクセル長を求めて GetTabAfterPosition に渡すと、"world!" を描画すべき次のタブ位置が得られます。

## **All-Caps効果でテキストを抽出**
PowerPoint では **All Caps** フォント効果を適用すると、スライド上のテキストがすべて大文字で表示されますが、元の入力は小文字のままです。Aspose.Slides でテキスト部分を取得すると、入力されたままの文字列が返ります。そこで、[TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) が `All` を示す場合は、取得した文字列を大文字に変換してスライド表示と一致させます。

サンプル2.pptx の最初のスライドに次のテキストボックスがあるとします。

![The All Caps effect](all_caps_effect.png)

以下のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示しています:
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

**スライド上の表のテキストを変更する方法は？**

スライド上の表のテキストを変更するには、[Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) クラスを使用します。表内のすべてのセルを走査し、各セルの `TextFrame` と `ParagraphFormat` プロパティにアクセスしてテキストを変更できます。

**PowerPoint スライドのテキストにグラデーションカラーを適用する方法は？**

`BasePortionFormat` の `getFillFormat` メソッドを使用してグラデーションカラーを適用します。`FillFormat` を `Gradient` に設定し、開始色と終了色、方向、透明度などのプロパティを指定してテキストにグラデーション効果を作成します。