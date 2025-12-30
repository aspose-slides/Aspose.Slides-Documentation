---
title: PHPでプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/php-java/presentation-header-and-footer/
keywords:
- ヘッダー
- ヘッダー テキスト
- フッター
- フッター テキスト
- ヘッダーを設定
- フッターを設定
- 配布資料
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションにヘッダーとフッターを追加およびカスタマイズし、プロフェッショナルな外観を実現するために Aspose.Slides for PHP via Java を使用します。"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ja/php-java/) は、スライドのヘッダーとフッターのテキストを実際にはスライド マスターレベルで管理できる機能を提供します。

{{% /alert %}} 

[Aspose.Slides for PHP via Java](/slides/ja/php-java/) は、プレゼンテーション スライド内のヘッダーとフッターを管理する機能を提供します。これらは実際にはプレゼンテーション マスターレベルで管理されます。

## **プレゼンテーションでヘッダーとフッターを管理する**
特定のスライドのノートを以下の例のように削除できます:
```php
  # プレゼンテーションをロード
  $pres = new Presentation("headerTest.pptx");
  try {
    # フッターを設定
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # ヘッダーにアクセスして更新
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # プレゼンテーションを保存
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **配布資料およびノート スライドでヘッダーとフッターを管理する**
Aspose.Slides for PHP via Java は、配布資料およびノート スライドでヘッダーとフッターをサポートします。以下の手順に従ってください:

- ビデオを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) をロードします。
- ノート マスターとすべてのノート スライドのヘッダーとフッター設定を変更します。
- マスターノートスライドとすべての子フッタープレースホルダーを表示状態に設定します。
- マスターノートスライドとすべての子日付と時刻プレースホルダーを表示状態に設定します。
- 最初のノートスライドだけのヘッダーとフッター設定を変更します。
- ノートスライドのヘッダー プレースホルダーを表示状態に設定します。
- ノートスライドのヘッダー プレースホルダーにテキストを設定します。
- ノートスライドの日付・時刻プレースホルダーにテキストを設定します。
- 変更されたプレゼンテーション ファイルを書き出します。

以下の例にコードスニペットが示されています。
```php

  $pres = new Presentation("presentation.pptx");
  try {
    # ノートマスターとすべてのノートスライドのヘッダーとフッター設定を変更
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// マスターノートスライドとすべての子フッタープレースホルダーを表示する

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// マスターノートスライドとすべての子ヘッダープレースホルダーを表示する

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// マスターノートスライドとすべての子スライド番号プレースホルダーを表示する

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// マスターノートスライドとすべての子日付と時刻プレースホルダーを表示する

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// マスターノートスライドとすべての子ヘッダープレースホルダーにテキストを設定する

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// マスターノートスライドとすべての子フッタープレースホルダーにテキストを設定する

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// マスターノートスライドとすべての子日付と時刻プレースホルダーにテキストを設定する

    }
    # 最初のノートスライドのみのヘッダーとフッター設定を変更
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// このノートスライドのヘッダー プレースホルダーを表示する

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// このノートスライドのフッタープレースホルダーを表示する

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// このノートスライドのスライド番号プレースホルダーを表示する

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// このノートスライドの日付・時刻プレースホルダーを表示する

      $headerFooterManager->setHeaderText("New header text");// ノートスライドのヘッダー プレースホルダーにテキストを設定する

      $headerFooterManager->setFooterText("New footer text");// ノートスライドのフッタープレースホルダーにテキストを設定する

      $headerFooterManager->setDateTimeText("New date and time text");// ノートスライドの日付・時刻プレースホルダーにテキストを設定する

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では「ヘッダー」はノートと配布資料にのみ存在し、通常のスライドではフッター、日付/時刻、スライド番号のみがサポートされます。Aspose.Slides でも同様の制限があり、ヘッダーはノート／配布資料にのみ、スライド上ではフッター／日付時刻／スライド番号が利用可能です。

**レイアウトにフッター領域が含まれていない場合、表示を「オン」にできますか？**

はい。ヘッダー/フッターマネージャーで表示状態を確認し、必要に応じて有効にしてください。プレースホルダーが存在しない、または非表示の場合に備えて設計された API が用意されています。

**スライド番号を 1 以外の値から開始させるにはどうすればよいですか？**

プレゼンテーションの [first slide number](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/) を設定します。これを行うと、すべての番号付けが再計算されます。たとえば 0 や 10 から開始し、タイトル スライドの番号を非表示にすることもできます。

**PDF/画像/HTML にエクスポートした場合、ヘッダー/フッターはどうなりますか？**

ヘッダーとフッターはプレゼンテーションの通常のテキスト要素としてレンダリングされます。つまり、スライドやノート ページ上で要素が表示されていれば、出力形式でも他のコンテンツと同様に表示されます。