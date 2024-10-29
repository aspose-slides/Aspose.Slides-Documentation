---
title: プレゼンテーションのヘッダーとフッター
type: docs
weight: 140
url: /ja/php-java/presentation-header-and-footer/
keywords: "PowerPoint ヘッダーとフッター "
description: "PowerPoint ヘッダーとフッター "
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ja/php-java/) は、スライドのヘッダーとフッターテキストの操作をサポートしており、実際にはスライドマスターのレベルで管理されています。

{{% /alert %}} 

[Aspose.Slides for PHP via Java](/slides/ja/php-java/) は、プレゼンテーションスライド内でヘッダーとフッターを管理する機能を提供します。これらは実際にはプレゼンテーションマスターのレベルで管理されています。

## **プレゼンテーションにおけるヘッダーとフッターの管理**
特定のスライドのノートは、以下の例のように削除できます：

```php
  # プレゼンテーションの読み込み
  $pres = new Presentation("headerTest.pptx");
  try {
    # フッターの設定
    $pres->getHeaderFooterManager()->setAllFootersText("私のフッターテキスト");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # ヘッダーにアクセスして更新
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # プレゼンテーションの保存
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **ハンドアウトおよびノートスライドにおけるヘッダーとフッターの管理**
Aspose.Slides for PHP via Java は、ハンドアウトおよびノートスライドでのヘッダーとフッターをサポートしています。以下の手順に従ってください：

- ビデオを含む[Aspose.Slides プレゼンテーション](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)を読み込む。
- ノートマスタおよびすべてのノートスライドのヘッダーとフッター設定を変更する。
- マスターノートスライドおよびすべての子フッタープレースホルダーを可視化する。
- マスターノートスライドおよびすべての子日時プレースホルダーを可視化する。
- 最初のノートスライドのみのヘッダーとフッター設定を変更する。
- ノートスライドのヘッダープレースホルダーを可視化する。
- ノートスライドのヘッダープレースホルダーにテキストを設定する。
- ノートスライドの日時プレースホルダーにテキストを設定する。
- 修正されたプレゼンテーションファイルを書き込む。

以下の例に提供されたコードスニペット。

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # ノートマスタおよびすべてのノートスライドのヘッダーとフッター設定を変更する
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// マスターノートスライドとすべての子フッタープレースホルダーを可視化する

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// マスターノートスライドとすべての子ヘッダープレースホルダーを可視化する

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// マスターノートスライドとすべての子スライド番号プレースホルダーを可視化する

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// マスターノートスライドとすべての子日時プレースホルダーを可視化する

      $headerFooterManager->setHeaderAndChildHeadersText("ヘッダーテキスト");// マスターノートスライドとすべての子ヘッダープレースホルダーにテキストを設定する

      $headerFooterManager->setFooterAndChildFootersText("フッターテキスト");// マスターノートスライドとすべての子フッタープレースホルダーにテキストを設定する

      $headerFooterManager->setDateTimeAndChildDateTimesText("日時テキスト");// マスターノートスライドとすべての子日時プレースホルダーにテキストを設定する

    }
    # 最初のノートスライドのみのヘッダーとフッター設定を変更する
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// このノートスライドのヘッダープレースホルダーを可視化する

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// このノートスライドのフッタープレースホルダーを可視化する

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// このノートスライドのスライド番号プレースホルダーを可視化する

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// このノートスライドの日時プレースホルダーを可視化する

      $headerFooterManager->setHeaderText("新しいヘッダーテキスト");// ノートスライドのヘッダープレースホルダーにテキストを設定する

      $headerFooterManager->setFooterText("新しいフッターテキスト");// ノートスライドのフッタープレースホルダーにテキストを設定する

      $headerFooterManager->setDateTimeText("新しい日時テキスト");// ノートスライドの日時プレースホルダーにテキストを設定する

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```