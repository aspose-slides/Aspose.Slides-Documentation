---
title: プレゼンテーションノート
type: docs
weight: 110
url: /php-java/presentation-notes/
keywords: "PowerPoint スピーカーメモ"
description: "プレゼンテーションノート、スピーカーメモ"
---


{{% alert color="primary" %}} 

Aspose.Slidesはプレゼンテーションからノートスライドを削除する機能をサポートしています。このトピックでは、ノートを削除するこの新機能を紹介し、プレゼンテーションからスタイル付きのノートスライドを追加する方法について説明します。 

{{% /alert %}} 

Aspose.Slides for PHP via Javaは、任意のスライドのノートを削除する機能と、既存のノートにスタイルを追加する機能を提供します。開発者は以下の方法でノートを削除できます。

* プレゼンテーションの特定のスライドのノートを削除します。
* プレゼンテーションのすべてのスライドのノートを削除します。


## **スライドからノートを削除する**
特定のスライドのノートは、以下の例のように削除できます。

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # 最初のスライドのノートを削除
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # プレゼンテーションをディスクに保存
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **プレゼンテーションからノートを削除する**
プレゼンテーションのすべてのスライドのノートは、以下の例のように削除できます。

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # すべてのスライドのノートを削除
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # プレゼンテーションをディスクに保存
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ノートスタイルを追加する**
[getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide#getNotesStyle--) メソッドは、[IMasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide) インターフェイスおよび [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) クラスに追加されました。このプロパティはノートテキストのスタイルを指定します。実装は以下の例で示されています。

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # MasterNotesSlideのテキストスタイルを取得
      $notesStyle = $notesMaster->getNotesStyle();
      # 第1レベルの段落に記号の弾丸を設定
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```