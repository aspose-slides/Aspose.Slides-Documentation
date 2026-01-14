---
title: PHP でプレゼンテーション ノートを管理
linktitle: プレゼンテーション ノート
type: docs
weight: 110
url: /ja/php-java/presentation-notes/
keywords:
- ノート
- ノート スライド
- ノートを追加
- ノートを削除
- ノート スタイル
- マスターノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してプレゼンテーション ノートをカスタマイズできます。PowerPoint および OpenDocument のノートをシームレスに操作し、生産性を向上させましょう。"
---

{{% alert color="primary" %}} 
Aspose.Slides はプレゼンテーションからノートスライドを削除することをサポートしています。このトピックでは、ノートを削除する新機能と、任意のプレゼンテーションにノートスタイルスライドを追加する機能を紹介します。 
{{% /alert %}} 

Aspose.Slides for PHP via Java は、任意のスライドのノートを削除したり、既存のノートにスタイルを追加したりする機能を提供します。開発者は以下の方法でノートを削除できます。

* プレゼンテーション内の特定のスライドのノートを削除する。
* プレゼンテーション内のすべてのスライドのノートを削除する

## **スライドからノートを削除**
特定のスライドのノートを削除する例を以下に示します:
```php
  # プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # 最初のスライドのノートを削除する
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # プレゼンテーションをディスクに保存する
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **プレゼンテーションからノートを削除**
プレゼンテーション内のすべてのスライドのノートを削除する例を以下に示します:
```php
  # プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # すべてのスライドのノートを削除する
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # プレゼンテーションをディスクに保存する
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ノートスタイルを追加**
[getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) メソッドが [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) クラスに追加されました。このプロパティはノートテキストのスタイルを指定します。実装例を以下に示します。
```php
  # プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # MasterNotesSlide のテキスト スタイルを取得する
      $notesStyle = $notesMaster->getNotesStyle();
      # 最初のレベルの段落にシンボル バレットを設定する
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


## **FAQ**

**特定のスライドのノートにアクセスできる API エンティティはどれですか？**

ノートはスライドのノートマネージャーを通じてアクセスされます。スライドは [NotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/) を持ち、[getNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/getnotesslide/) メソッドでノートオブジェクトを取得します。ノートが存在しない場合は `null` が返されます。

**ライブラリが対応する PowerPoint バージョン間でノートサポートに違いはありますか？**

このライブラリは Microsoft PowerPoint 97 以降の幅広い形式（および ODP）を対象としており、これらの形式ではインストールされた PowerPoint の有無に関わらずノートがサポートされます。