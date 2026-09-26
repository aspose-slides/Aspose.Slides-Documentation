---
title: PHPでプレゼンテーションノートを管理する
linktitle: プレゼンテーションノート
type: docs
weight: 110
url: /ja/php-java/presentation-notes/
keywords:
- ノート
- ノートスライド
- ノートを追加
- ノートを削除
- ノートスタイル
- マスターノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Javaを介してPHP用のAspose.Slidesでプレゼンテーションノートをカスタマイズします。PowerPoint と OpenDocument のノートをシームレスに操作し、生産性を向上させましょう。"
---
## **Overview**

Aspose.Slides はプレゼンテーションからノート スライドを削除することをサポートしています。このトピックでは、この機能の概要と、ノートの削除方法とプレゼンテーション内のノート スライドにスタイルを適用する方法を紹介します。Aspose.Slides を使用すると、任意のスライドからノートを削除したり、既存のノートにスタイルを適用したりできます。開発者は次の方法でノートを削除できます：

- プレゼンテーション内の特定のスライドからノートを削除する。
- プレゼンテーション内のすべてのスライドからノートを削除する。

ノート ページのサイズを確認または変更したり、向きを切り替えたり、エクスポートの動作を確認するには、[Notes Page Size](/slides/ja/php-java/notes-size/) を参照してください。

## **Remove Notes from a Slide**
特定のスライドのノートは、以下の例のように削除できます。

```php
  # プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化する
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

## **Remove Notes from a Presentation**
プレゼンテーション内のすべてのスライドのノートは、以下の例のように削除できます。

```php
  # プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化する
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

## **Add a Notes Style**
[MasterNotesSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/MasterNotesSlide) クラスの[getNotesStyle](https://reference.aspose.com/slides/ja/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) メソッドは、ノート テキストのスタイルへのアクセスを提供します。実装は以下の例で示されています。

```php
  # プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化する
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # MasterNotesSlide のテキストスタイルを取得する
      $notesStyle = $notesMaster->getNotesStyle();
      # 最初のレベルの段落にシンボル箇条書きを設定する
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

**Which API entity provides access to the notes of a specific slide?**  
ノートはスライドのノート マネージャー経由でアクセスされます。スライドは[NotesSlideManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notesslidemanager/) を持ち、ノート オブジェクト（ノートがない場合は `null`）を返す[method](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notesslidemanager/getnotesslide/) が用意されています。

**Are there differences in notes support across the PowerPoint versions the library works with?**  
このライブラリは Microsoft PowerPoint の幅広いフォーマット（97 以降）および ODP を対象としており、これらのフォーマット内でノートは PowerPoint がインストールされているかどうかに依存せずにサポートされます。