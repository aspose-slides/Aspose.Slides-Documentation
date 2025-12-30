---
title: PHPでプレゼンテーションノートを管理
linktitle: プレゼンテーションノート
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
description: "Aspose.Slides for PHP via Java を使用してプレゼンテーションノートをカスタマイズします。PowerPoint や OpenDocument のノートとシームレスに連携し、生産性を向上させます。"
---

{{% alert color="primary" %}} 
Aspose.Slides はプレゼンテーションからノート スライドを削除する機能をサポートしています。このトピックでは、ノートを削除し、任意のプレゼンテーションにノート スタイル スライドを追加する新機能をご紹介します。 
{{% /alert %}} 
Aspose.Slides for PHP via Java は、任意のスライドのノートを削除し、既存のノートにスタイルを追加する機能を提供します。開発者は以下の方法でノートを削除できます:
* プレゼンテーションの特定のスライドのノートを削除する。
* プレゼンテーションのすべてのスライドのノートを削除する。

## **スライドからノートを削除する**
以下の例のように、特定のスライドのノートを削除できます：
```php
  # プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
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
以下の例のように、プレゼンテーションのすべてのスライドのノートを削除できます：
```php
  # プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
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


## **ノート スタイルを追加する**
[getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide#getNotesStyle--) メソッドがそれぞれ [IMasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide) インターフェイスと [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) クラスに追加されました。このプロパティはノート テキストのスタイルを指定します。実装例は以下の例で示しています。
```php
  # プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # MasterNotesSlide のテキスト スタイルを取得
      $notesStyle = $notesMaster->getNotesStyle();
      # 最初のレベルの段落にシンボル バレットを設定
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

ノートはスライドのノート マネージャーを通じてアクセスされます。スライドは [NotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/) を持ち、ノート オブジェクト（ノートが存在しない場合は `null`）を返す [method](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/getnotesslide/) が用意されています。

**ライブラリが対応する PowerPoint のバージョン間でノートのサポートに違いはありますか？**

このライブラリは Microsoft PowerPoint のさまざまな形式（97 年以降）と ODP を対象としており、PowerPoint がインストールされているかどうかに依存せず、これらの形式でノートがサポートされています。