---
title: PHPにおけるプレゼンテーションからの高度なテキスト抽出
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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーションからテキストを迅速に抽出します。シンプルなステップバイステップガイドで時間を節約できます。"
---

{{% alert color="primary" %}} 

プレゼンテーションからテキストを抽出する必要がある開発者は珍しくありません。これを行うには、プレゼンテーション内のすべてのスライドのすべてのシェイプからテキストを抽出する必要があります。本稿では、Aspose.Slides を使用して Microsoft PowerPoint PPTX プレゼンテーションからテキストを抽出する方法を説明します。

{{% /alert %}} 
## **スライドからテキストを抽出**
Aspose.Slides for PHP via Java は[SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/)クラスを提供します。このクラスは、プレゼンテーションまたはスライド全体のテキストを抽出するための多数のオーバーロードされた静的メソッドを公開しています。PPTX プレゼンテーションのスライドからテキストを抽出するには、[getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/getalltextboxes/)オーバーロードされた静的メソッドを使用します。このメソッドは Slide オブジェクトをパラメーターとして受け取ります。実行すると、Slide メソッドはパラメーターとして渡されたスライドのテキスト全体をスキャンし、[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)オブジェクトの配列を返します。これにより、テキストに関連付けられた書式情報も取得できます。次のコードはプレゼンテーションの最初のスライド上のすべてのテキストを抽出します。
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを生成
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # TextFrame の配列をループ処理
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # 現在の ITextFrame の段落をループ処理
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # 現在の IParagraph のポーションをループ処理
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


## **プレゼンテーションからテキストを抽出**
プレゼンテーション全体のテキストをスキャンするには、SlideUtil クラスが公開している[getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/getalltextframes/)静的メソッドを使用します。このメソッドは 2 つのパラメーターを受け取ります。

1. 最初に、テキストを抽出する対象のプレゼンテーションを表す[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)オブジェクト。
2. 次に、プレゼンテーションからテキストをスキャンする際にマスタースライドを含めるかどうかを決定するブール値。

このメソッドは、書式情報を含む[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)オブジェクトの配列を返します。以下のコードは、マスタースライドを含むプレゼンテーションからテキストと書式情報をスキャンします。
```php
  # PPTX ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # TextFrame の配列をループ処理
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # 現在の ITextFrame の段落をループ処理
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # 現在の IParagraph のポーションをループ処理
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


## **カテゴリ別かつ高速なテキスト抽出**
Presentation クラスに新しい静的メソッド getPresentationText が追加されました。このメソッドには 3 つのオーバーロードがあります。
```php

```


## **FAQ**

**テキスト抽出時に Aspose.Slides は大規模なプレゼンテーションをどれくらい高速に処理しますか？**

Aspose.Slides は高性能に最適化されており、[large presentations](/slides/ja/php-java/open-presentation/)でも効率的に処理でき、リアルタイムまたはバルク処理のシナリオに適しています。

**Aspose.Slides はプレゼンテーション内のテーブルやチャートからテキストを抽出できますか？**

はい、Aspose.Slides はテーブル、チャート、その他の複雑なスライド要素からのテキスト抽出を完全にサポートしており、すべてのテキストコンテンツに簡単にアクセスして分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスが必要ですか？**

Aspose.Slides の無料トライアル版でもテキストを抽出できますが、スライド数に制限などの制約があります。制限のない使用や大規模なプレゼンテーションを処理するには、フルライセンスの購入が推奨されます。