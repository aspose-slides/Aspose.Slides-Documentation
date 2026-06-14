---
title: 在 PHP 中管理簡報備註
linktitle: 簡報備註
type: docs
weight: 110
url: /zh-hant/php-java/presentation-notes/
keywords:
- 備註
- 備註投影片
- 新增備註
- 移除備註
- 備註樣式
- 主備註
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP (透過 Java) 自訂簡報備註。無縫操作 PowerPoint 與 OpenDocument 的備註，提升您的生產力。"
---
## **概觀**

Aspose.Slides 支援從簡報中移除備註投影片。在本主題中，我們將介紹此功能，包括如何移除備註以及如何在簡報的備註投影片上套用樣式。Aspose.Slides 允許您從任何投影片移除備註，亦可對現有備註套用樣式。開發人員可以透過以下方式移除備註：

- 從簡報的特定投影片中移除備註。
- 從簡報的所有投影片中移除備註。

## **從投影片中移除備註**
如下例所示，可移除特定投影片的備註：

```php
  # 實例化一個表示簡報檔案的 Presentation 物件
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # 移除第一張投影片的備註
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # 將簡報儲存至磁碟
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **從簡報中移除備註**
如下例所示，可移除簡報中所有投影片的備註：

```php
  # 實例化一個表示簡報檔案的 Presentation 物件
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # 移除所有投影片的備註
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # 將簡報儲存至磁碟
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **新增備註樣式**
[getNotesStyle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) 方法已分別新增至 [MasterNotesSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/MasterNotesSlide) 類別。此屬性指定備註文字的樣式。以下範例示範其實作方式。

```php
  # 實例化一個表示簡報檔案的 Presentation 物件
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # 取得 MasterNotesSlide 文字樣式
      $notesStyle = $notesMaster->getNotesStyle();
      # 為第一層段落設定符號項目符號
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

## **常見問題**

**哪個 API 實體提供對特定投影片備註的存取？**

備註可透過投影片的備註管理器存取：投影片具有一個 [NotesSlideManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notesslidemanager/)，以及一個返回備註物件的 [方法](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notesslidemanager/getnotesslide/)，如果沒有備註則返回 `null`。

**在函式庫支援的 PowerPoint 版本之間，備註支援有差異嗎？**

此函式庫支援廣泛的 Microsoft PowerPoint 格式（97 版至更新版）以及 ODP；在這些格式中均支援備註，且不需要安裝 PowerPoint。