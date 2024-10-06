---
title: プレゼンテーションからテキストを抽出する
type: docs
weight: 90
url: /ja/php-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があることは珍しくありません。そのためには、プレゼンテーション内のすべてのスライドのすべてのシェイプからテキストを抽出する必要があります。この記事では、Aspose.Slidesを使用してMicrosoft PowerPoint PPTXプレゼンテーションからテキストを抽出する方法を説明します。 

{{% /alert %}} 
## **スライドからテキストを抽出する**
Aspose.Slides for PHP via Javaは、[SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil)クラスを提供します。このクラスは、プレゼンテーションまたはスライドから全テキストを抽出するためのオーバーロードされた静的メソッドのいくつかを公開しています。PPTXプレゼンテーションのスライドからテキストを抽出するには、
[SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil)クラスが公開するオーバーロードされた静的メソッド[getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-)を使用します。このメソッドは、スライドオブジェクトをパラメーターとして受け取ります。
実行すると、Slideメソッドは渡されたスライドから全テキストをスキャンし、[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)オブジェクトの配列を返します。これは、テキストに関連するテキストフォーマットが利用可能であることを意味します。次のコードは、プレゼンテーションの最初のスライドにあるすべてのテキストを抽出します：

```php
  # PPTXファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # PPTXのすべてのスライドからITextFrameオブジェクトの配列を取得
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # TextFramesの配列をループ
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # 現在のITextFrame内の段落をループ
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # 現在のIParagraph内のポーションをループ
          foreach($para->getPortions() as $port) {
            # 現在のポーションのテキストを表示
            echo($port->getText());
            # テキストのフォント高さを表示
            echo($port->getPortionFormat()->getFontHeight());
            # テキストのフォント名を表示
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

## **プレゼンテーションからテキストを抽出する**
プレゼンテーション全体からテキストをスキャンするには、SlideUtilクラスが公開する静的メソッド[getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-)を使用します。このメソッドは2つのパラメーターを取ります：

1. 最初は、テキストを抽出するプレゼンテーションを表す[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged)オブジェクトです。
1. 次は、プレゼンテーションからテキストをスキャンするときにマスター スライドを含めるかどうかを決定するブール値です。
   このメソッドは、テキストフォーマット情報を含む[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)オブジェクトの配列を返します。以下のコードは、マスター スライドを含むプレゼンテーションからテキストとフォーマット情報をスキャンします。

```php
  # PPTXファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # PPTXのすべてのスライドからITextFrameオブジェクトの配列を取得
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # TextFramesの配列をループ
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # 現在のITextFrame内の段落をループ
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # 現在のIParagraph内のポーションをループ
        foreach($para->getPortions() as $port) {
          # 現在のポーションのテキストを表示
          echo($port->getText());
          # テキストのフォント高さを表示
          echo($port->getPortionFormat()->getFontHeight());
          # テキストのフォント名を表示
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

## **カテゴリ別で高速なテキスト抽出**
新しい静的メソッドgetPresentationTextがPresentationクラスに追加されました。このメソッドには3つのオーバーロードがあります。

```php

``` 

[TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode)列挙引数は、テキスト結果の出力を整理するモードを示し、以下の値に設定できます：
- [Unarranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - スライド上の位置を無視した生のテキスト
- [Arranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Arranged) - スライド上と同じ順序で配置されたテキスト

**Unarranged**モードはスピードが重要な場合に使用でき、Arrangedモードよりも高速です。

[IPresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText)は、プレゼンテーションから抽出された生のテキストを表します。それは、[getSlidesText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText#getSlidesText--)メソッドを含み、これにより[ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText)オブジェクトの配列が返されます。各オブジェクトは対応するスライド上のテキストを表します。[ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText)オブジェクトには以下のメソッドがあります：

- [ISlideText.getText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getText--) - スライドのシェイプ上のテキスト
- [ISlideText.getMasterText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getMasterText--) - このスライドのマスターページのシェイプ上のテキスト
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getLayoutText--) - このスライドのレイアウトページのシェイプ上のテキスト
- [ISlideText.getNotesText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getNotesText--) - このスライドのノートページのシェイプ上のテキスト

[SlideText](https://reference.aspose.com/slides/php-java/aspose.slides/SlideText)クラスもあり、[ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText)インターフェースを実装しています。

新しいAPIは次のように使用できます：

```php
  $text1 = PresentationFactory->getInstance()->getPresentationText("presentation.pptx", TextExtractionArrangingMode->Unarranged);
  echo($text1->getSlidesText()[0]->getText());
  echo($text1->getSlidesText()[0]->getLayoutText());
  echo($text1->getSlidesText()[0]->getMasterText());
  echo($text1->getSlidesText()[0]->getNotesText());
```