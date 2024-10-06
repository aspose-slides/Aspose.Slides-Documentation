---
title: テキストフォーマット
type: docs
weight: 50
url: /ja/php-java/text-formatting/
---

## **テキストをハイライト**
メソッド [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) が [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) インターフェイスと [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) クラスに追加されました。

これにより、PowerPoint 2019 のテキストハイライトカラーツールに似た方法で、テキストサンプルを使用して背景色でテキスト部分をハイライトすることができます。

以下のコードスニペットは、この機能の使用方法を示しています：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// 'important'というすべての単語をハイライト

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// 'the'のすべての別個の出現をハイライト

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Aspose はシンプルな [無料のオンライン PowerPoint 編集サービス](https://products.aspose.app/slides/editor) を提供しています

{{% /alert %}} 

## **正規表現を使用してテキストをハイライト**

メソッド [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) が [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) インターフェイスと [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) クラスに追加されました。

これにより、PowerPoint 2019 のテキストハイライトカラーツールに似た方法で、正規表現を使用して背景色でテキスト部分をハイライトすることができます。

以下のコードスニペットは、この機能の使用方法を示しています：

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

## **テキストの背景色を設定**

Aspose.Slides を使用すると、テキストの背景色を指定することができます。

この PHP コードは、全テキストの背景色を設定する方法を示しています：

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

この PHP コードは、テキストの一部のみの背景色を設定する方法を示しています：

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

## **テキスト段落を整列**

テキストフォーマットは、あらゆる種類の文書やプレゼンテーションを作成する際の重要な要素の 1 つです。Aspose.Slides for PHP via Java がスライドにテキストを追加することをサポートしていることは知っていますが、このトピックではスライド内のテキスト段落の整列をどのように制御できるかを見ていきます。以下の手順に従って、Aspose.Slides for PHP via Java を使用してテキスト段落を整列させてください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内のプレースホルダー形状にアクセスし、それを [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) として型変換します。
4. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) によって公開された [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) から整列が必要な段落を取得します。
5. 段落を整列させます。段落は、右揃え、左揃え、中央揃え、または均等配置にできます。
6. 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

上記の手順の実装は以下の通りです。

```php
  # PPTX ファイルを表す Presentation オブジェクトをインスタンス化
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # スライド内の最初と2つ目のプレースホルダーにアクセスし、AutoShape として型変換
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 両方のプレースホルダー内のテキストを変更
    $tf1->setText("Asposeによる中央揃え");
    $tf2->setText("Asposeによる中央揃え");
    # プレースホルダーの最初の段落を取得
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # テキスト段落を中央に整列
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

## **テキストの透明度を設定**
この記事では、Aspose.Slides for PHP via Java を使用してテキストシェイプの透過プロパティを設定する方法を示します。テキストに透明度を設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. シャドウの色を設定します。
4. プレゼンテーションを PPTX ファイルとして保存します。

上記の手順の実装は以下の通りです。

```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - 透明度は: " . $shadowColor->getAlpha() / 255.0 * 100);
    # 透明度を0パーセントに設定
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テキストの文字間隔を設定**

Aspose.Slides を使用すると、テキストボックス内の文字間のスペースを設定できます。これにより、文字間のスペーシングを拡張または縮小することによって、テキストの行またはブロックの視覚的な密度を調整できます。

この PHP コードは、1 行のテキストの間隔を拡張し、別の行の間隔を縮小する方法を示しています：

```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// 拡大

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// 縮小

  $presentation->save("out.pptx", SaveFormat::Pptx);
```

## **段落のフォントプロパティを管理**

プレゼンテーションには通常、テキストと画像の両方が含まれています。テキストは、特定のセクションや単語を強調表示するため、または企業のスタイルに準拠するために、さまざまな方法でフォーマットできます。テキストフォーマットは、プレゼンテーションのコンテンツの外観を変えるのに役立ちます。この記事では、Aspose.Slides for PHP via Java を使用してスライド上のテキストの段落のフォントプロパティを設定する方法を示します。Aspose.Slides for PHP via Java を使用して段落のフォントプロパティを管理するには：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. スライド内のプレースホルダー形状にアクセスし、それらを [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) に型変換します。
1. [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) によって公開された [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) から [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) を取得します。
1. 段落を整列させます。
1. 段落のテキストポーションにアクセスします。
1. FontData を使用してフォントを定義し、テキストポーションのフォントを設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
1. [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--) を使用してフォントの色を設定します。
1. 修正されたプレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き込みます。

上記の手順の実装は以下の通りです。装飾されていないプレゼンテーションを受け取り、そのうちの 1 つのスライド上のフォントをフォーマットします。

```php
  # PPTX ファイルを表す Presentation オブジェクトをインスタンス化
  $pres = new Presentation("FontProperties.pptx");
  try {
    # スライドの位置を使用してスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # スライド内の最初と2つ目のプレースホルダーにアクセスし、AutoShape として型変換
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
    # 新しいフォントをポーションに割り当てる
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
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # PPTX をディスクに保存
    $pres->save("WelcomeFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テキストのフォントファミリを管理**
ポーションは、段落内で同じフォーマットスタイルを持つテキストを保持するために使用されます。この記事では、Aspose.Slides for PHP via Java を使用してテキストボックスを作成し、特定のフォントおよびフォントファミリーカテゴリのさまざまなプロパティを定義する方法を示します。テキストボックスを作成し、そのテキストのフォントプロパティを設定するには：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) 型の [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) をスライドに追加します。
4. [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) に関連付けられている塗りつぶしスタイルを削除します。
5. AutoShape の TextFrame にアクセスします。
6. TextFrame にテキストを追加します。
7. [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) に関連付けられたポーションオブジェクトにアクセスします。
8. [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion) に使用されるフォントを定義します。
9. 太字、斜体、下線、色、高さなど、ポーションオブジェクトによって公開されている関連プロパティを使用して他のフォントプロパティを設定します。
10. 修正されたプレゼンテーションを PPTX ファイルとして保存します。

上記の手順の実装は以下の通りです。

```php
  # プレゼンテーションをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $sld = $pres->getSlides()->get_Item(0);
    # 長方形タイプの AutoShape を追加
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # AutoShape に関連する塗りつぶしスタイルを削除
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # AutoShape に関連する TextFrame にアクセス
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose テキストボックス");
    # TextFrame に関連するポーションにアクセス
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # ポーションのフォントを設定
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # フォントの太字プロパティを設定
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # フォントの斜体プロパティを設定
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # フォントの下線プロパティを設定
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

## **テキストのフォントサイズを設定**

Aspose.Slides を使用すると、段落内の既存のテキストや、後で段落に追加される他のテキストの好みのフォントサイズを選択できます。

この PHP コードは、段落に含まれるテキストのフォントサイズを設定する方法を示しています：

```php
  $presentation = new Presentation("example.pptx");
  try {
    # 最初のシェイプを取得
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # 最初の段落を取得
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # 段落中のすべてのテキストポーションのデフォルトフォントサイズを20ptに設定
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # 段落中の現在のテキストポーションのフォントサイズを20ptに設定
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

## **テキストの回転を設定**

Aspose.Slides for PHP via Java を使用すると、開発者はテキストを回転させることができます。テキストは [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal)、[Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical)、[Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270)、[WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical)、[EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical)、[MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) または [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft) のように設定できます。任意の TextFrame のテキストを回転させるには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) にアクセスします。
5. [テキストを回転させる](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-)。
6. ファイルをディスクに保存します。

```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 長方形タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # 長方形にテキストフレームを追加
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # テキストフレームにアクセス
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # テキストフレーム用の段落オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 段落用のポーションオブジェクトを作成
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("速い茶色の狐が怠け者の犬を飛び越えます。速い茶色の狐が怠け者の犬を飛び越えます。");
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

## **TextFrame のカスタム回転角度を設定**
Aspose.Slides for PHP via Java では、TextFrame のカスタム回転角度を設定することがサポートされています。このトピックでは、Aspose.Slides の RotationAngle プロパティを設定する方法の例を見ていきます。新しいメソッド [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) と [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) が [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) と [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) インターフェイスに追加され、TextFrame にカスタム回転角度を設定することができます。RotationAngle を設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. [RotationAngle プロパティを設定](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-)します。
4. プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、RotationAngle プロパティを設定しました。

```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 長方形タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # 長方形にテキストフレームを追加
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # テキストフレームにアクセス
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # テキストフレーム用の段落オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 段落用のポーションオブジェクトを作成
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("テキストの回転の例です。");
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
Aspose.Slides は、[`ParagraphFormat`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat) の下で `SpaceAfter`、`SpaceBefore` および `SpaceWithin` プロパティを提供しており、段落の行間隔を管理できます。3つのプロパティは次のように使用されます：

* 段落の行間隔をパーセントで指定するには、正の値を使用します。 
* 段落の行間隔をポイントで指定するには、負の値を使用します。

たとえば、`SpaceBefore` プロパティを -16 に設定することで、段落の行間隔を 16pt に適用できます。

特定の段落の行間隔を指定するには、次の手順を実行します：

1. テキストを含む AutoShape が含まれるプレゼンテーションを読み込みます。
2. インデックスを介してスライドの参照を取得します。
3. TextFrame にアクセスします。
4. 段落にアクセスします。
5. 段落のプロパティを設定します。
6. プレゼンテーションを保存します。

この PHP コードは、段落の行間隔を指定する方法を示しています：

```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation("Fonts.pptx");
  try {
    # インデックスを使ってスライドの参照を取得
    $sld = $pres->getSlides()->get_Item(0);
    # TextFrame にアクセス
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # 段落にアクセス
    $para = $tf1->getParagraphs()->get_Item(0);
    # 段落のプロパティを設定
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

## **TextFrame の AutofitType プロパティを設定**
このトピックでは、テキストフレームのさまざまなフォーマットプロパティを探ります。この記事では、テキストフレームの AutofitType プロパティ、テキストのアンカー、およびプレゼンテーション内のテキストの回転を設定する方法について説明します。Aspose.Slides for PHP via Java では、任意のテキストフレームの AutofitType プロパティを設定することができます。AutofitType は [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) または [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape) に設定できます。[Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) に設定された場合、シェイプはそのまま保持され、テキストはシェイプ自体が変更されることなく調整されます。[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape) に設定すると、シェイプは必要なテキストのみを含むように変更されます。テキストフレームの AutofitType プロパティを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) にアクセスします。
5. テキストフレームの [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-) を設定します。
6. ファイルをディスクに保存します。

```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # 長方形タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # 長方形にテキストフレームを追加
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # テキストフレームにアクセス
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # テキストフレーム用の段落オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 段落用のポーションオブジェクトを作成
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("速い茶色の狐が怠け者の犬を飛び越えます。速い茶色の狐が怠け者の犬を飛び越えます。");
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

## **TextFrame のアンカーを設定**
Aspose.Slides for PHP via Java は、任意の TextFrame のアンカーを設定することを許可します。TextAnchorType では、テキストがシェイプ内に配置される場所を指定します。AnchorType は [Top](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Top)、[Center](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Center)、[Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Bottom)、[Justified](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Justified) または [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Distributed) に設定できます。任意の TextFrame のアンカーを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) にアクセスします。
5. テキストフレームの [TextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-) を設定します。
6. ファイルをディスクに保存します。

```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # 長方形タイプの AutoShape を追加
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # 長方形にテキストフレームを追加
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # テキストフレームにアクセス
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # テキストフレーム用の段落オブジェクトを作成
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 段落用のポーションオブジェクトを作成
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("速い茶色の狐が怠け者の犬を飛び越えます。速い茶色の狐が怠け者の犬を飛び越えます。");
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
すべてのテキストタブはピクセル単位で指定されます。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**図: 2 つの明示的なタブと 2 つのデフォルトタブ**|
- EffectiveTabs.ExplicitTabCount (私たちのケースでは 2) プロパティは、Tabs.Count に等しいです。
- EffectiveTabs コレクションには、すべてのタブ (Tabs コレクションとデフォルトタブ) が含まれます。
- EffectiveTabs.ExplicitTabCount (私たちのケースでは 2) プロパティは、Tabs.Count に等しいです。
- EffectiveTabs.DefaultTabSize (294) プロパティは、デフォルトタブ間の距離 (例では 3 と 4) を示します。
- EffectiveTabs.GetTabByIndex(index) インデックス = 0 は最初の明示的なタブ (Position = 731) を返し、インデックス = 1 は2つ目のタブ (Position = 1241) を返します。インデックス = 2 で次のタブを取得しようとすると、最初のデフォルトタブ (Position = 1470) を返し、などとなります。
- EffectiveTabs.GetTabAfterPosition(pos) は、テキストの後に次のタブを取得するために使用されます。たとえば、テキストが "Hello World!" の場合、このテキストをレンダリングするには、「world!」を描画する場所を知っている必要があります。まず、「Hello」の長さをピクセル単位で計算し、その値で GetTabAfterPosition を呼び出す必要があります。次に、"world!" を描画するための次のタブ位置が得られます。