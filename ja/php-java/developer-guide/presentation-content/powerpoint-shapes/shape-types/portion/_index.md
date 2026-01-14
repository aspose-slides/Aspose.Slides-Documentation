---
title: PHP を使用したプレゼンテーションのテキスト部分の管理
linktitle: テキスト部分
type: docs
weight: 70
url: /ja/php-java/portion/
keywords:
- テキスト部分
- テキストパート
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用して PowerPoint プレゼンテーションのテキスト部分を管理する方法を学び、パフォーマンスとカスタマイズ性を向上させます。"
---

## **テキスト部分の座標を取得する**
[**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/portion/getcoordinates/) メソッドが[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) クラスに追加され、部分の開始位置の座標を取得できるようになりました。
```php
  # PPTX を表す Presentation クラスのインスタンス化
  $pres = new Presentation();
  try {
    # プレゼンテーションのコンテキストを再構築する
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **よくある質問**

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、個々の部分に[ハイパーリンクを割り当て](/slides/ja/php-java/manage-hyperlinks/)ことができます。そのフラグメントだけがクリック可能となり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか：Portion が上書きするものと、Paragraph/TextFrame から取得されるものは何ですか？**

Portion レベルのプロパティが最も優先されます。プロパティが[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)で設定されていない場合、エンジンは[Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)から取得します。そちらでも設定されていない場合は、[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)または[theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/)のスタイルから取得します。

**Portion に指定されたフォントが対象のマシン/サーバーに存在しない場合はどうなりますか？**

[フォント置換ルール](/slides/ja/php-java/font-selection-sequence/)が適用されます。テキストは再配置される可能性があり、メトリック、ハイフネーション、幅が変わるため、正確な位置決めに影響します。

**段落全体とは独立して、Portion 固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)レベルでテキストの色、塗りつぶし、透明度を隣接するフラグメントと異なる設定にできます。