---
title: PHPでのプレゼンテーションからの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/php-java/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからテキスト抽出
- プレゼンテーションからテキスト抽出
- PowerPointからテキスト抽出
- OpenDocumentからテキスト抽出
- PPTからテキスト抽出
- PPTXからテキスト抽出
- ODPからテキスト抽出
- テキスト取得
- スライドからテキスト取得
- プレゼンテーションからテキスト取得
- PowerPointからテキスト取得
- OpenDocumentからテキスト取得
- PPTからテキスト取得
- PPTXからテキスト取得
- ODPからテキスト取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションからテキストを迅速に抽出します。シンプルな手順に従って、時間を節約しましょう。"
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があることは珍しくありません。そのためには、プレゼンテーション内のすべてのスライドのすべてのシェイプからテキストを抽出する必要があります。この記事では、Aspose.Slides を使用して Microsoft PowerPoint PPTX プレゼンテーションからテキストを抽出する方法を説明します。

{{% /alert %}} 
## **スライドからテキストを抽出**
Aspose.Slides for PHP via Java は、[SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil) クラスを提供します。このクラスは、プレゼンテーションまたはスライドから全テキストを抽出するための多数のオーバーロードされた静的メソッドを公開しています。PPTX プレゼンテーションのスライドからテキストを抽出するには、[SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil) クラスが公開するオーバーロードされた静的メソッド [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) を使用します。このメソッドは Slide オブジェクトをパラメータとして受け取ります。  
実行時に、Slide メソッドはパラメータとして渡されたスライドの全テキストをスキャンし、[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) オブジェクトの配列を返します。これにより、テキストに関連付けられたすべての書式情報が利用可能になります。以下のコードはプレゼンテーションの最初のスライドのすべてのテキストを抽出します:
```php
  # PPTX ファイルを表す Presentation クラスをインスタンス化する
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得する
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # TextFrame の配列をループ処理する
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # 現在の ITextFrame の段落をループ処理する
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # 現在の IParagraph の部分（ポーション）をループ処理する
          foreach($para->getPortions() as $port) {
            # 現在の部分のテキストを表示する
            echo($port->getText());
            # テキストのフォント高さを表示する
            echo($port->getPortionFormat()->getFontHeight());
            # テキストのフォント名を表示する
            if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
              echo($port->getPortionFormat()->getLatinFont()->getFontName());
            }
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **プレゼンテーションからテキストを抽出**
全体のプレゼンテーションからテキストをスキャンするには、SlideUtil クラスが公開する静的メソッド [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) を使用します。このメソッドは 2 つのパラメータを受け取ります：

1. まず、テキストが抽出されるプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) オブジェクトです。  
1. 次に、テキストをスキャンする際にマスタースライドを含めるかどうかを決定するブール値です。  
このメソッドはテキスト書式情報を含む [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) オブジェクトの配列を返します。以下のコードはプレゼンテーション（マスタースライドも含む）からテキストと書式情報をスキャンします。
```php
  # PPTX ファイルを表す Presentation クラスのインスタンス化
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得する
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # TextFrame の配列をループ処理する
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # 現在の ITextFrame の段落をループ処理する
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # 現在の IParagraph のポーションをループ処理する
        foreach($para->getPortions() as $port) {
          # 現在のポーションのテキストを表示する
          echo($port->getText());
          # テキストのフォントサイズ（高さ）を表示する
          echo($port->getPortionFormat()->getFontHeight());
          # テキストのフォント名を表示する
          if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
            echo($port->getPortionFormat()->getLatinFont()->getFontName());
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **分類された高速テキスト抽出**
Presentation クラスに新しい静的メソッド getPresentationText が追加されました。このメソッドには 3 つのオーバーロードがあります：
```php

``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) object have the following methods:

- [ISlideText.getText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText.getMasterText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText.getNotesText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

There is also a [SlideText](https://reference.aspose.com/slides/php-java/aspose.slides/SlideText) class which implements the [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) interface.

The new API can be used like this:

```php
  $text1 = PresentationFactory->getInstance()->getPresentationText("presentation.pptx", TextExtractionArrangingMode->Unarranged);
  echo($text1->getSlidesText()[0]->getText());
  echo($text1->getSlidesText()[0]->getLayoutText());
  echo($text1->getSlidesText()[0]->getMasterText());
  echo($text1->getSlidesText()[0]->getNotesText());

```


## **よくある質問**

**テキスト抽出時に大規模なプレゼンテーションを処理する速度はどれくらいですか？**

Aspose.Slides は高性能に最適化されており、[大規模なプレゼンテーション](/slides/ja/php-java/open-presentation/) を効率的に処理し、リアルタイムまたはバルク処理シナリオに適しています。

**Aspose.Slides はプレゼンテーション内の表やチャートからテキストを抽出できますか？**

はい、Aspose.Slides は表、チャート、その他の複雑なスライド要素からテキストを抽出することを完全にサポートしており、すべてのテキストコンテンツに簡単にアクセスし、分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスが必要ですか？**

Aspose.Slides の無料体験版でもテキストを抽出できますが、スライド数に制限があるなどいくつかの制限があります。制限なく利用し、より大きなプレゼンテーションを処理するには、フルライセンスの購入を推奨します。