---
title: 在 PHP 中管理簡報註解
linktitle: 簡報註解
type: docs
weight: 110
url: /zh-hant/php-java/presentation-notes/
keywords:
- 註解
- 註解投影片
- 新增註解
- 移除註解
- 註解樣式
- 母版註解
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（透過 Java）自訂簡報註解。無縫處理 PowerPoint 與 OpenDocument 註解，提升您的生產力。"
---
## **概觀**

Aspose.Slides 支援從簡報中刪除註解投影片。本主題將介紹此功能，包括如何刪除註解以及如何為簡報中的註解投影片套用樣式。Aspose.Slides 允許您從任意投影片移除註解，亦可對現有註解套用樣式。開發人員可透過以下方式移除註解：

- 從簡報中的特定投影片移除註解。
- 從簡報中的所有投影片移除註解。

若需讀取或變更註解頁面尺寸、切換方向，並檢查匯出行為，請參閱[註解頁面大小](/slides/zh-hant/php-java/notes-size/)。

## **從投影片移除註解**
如下例所示，可移除特定投影片的註解：

```php
  # 實例化一個代表簡報檔案的 Presentation 物件
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # 移除第一張投影片的註解
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

## **從簡報移除註解**
如下例所示，可移除簡報中所有投影片的註解：

```php
  # 實例化一個代表簡報檔案的 Presentation 物件
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # 移除所有投影片的註解
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

## **新增註解樣式**
[MasterNotesSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/MasterNotesSlide) 類別的 [getNotesStyle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) 方法可取得註解文字樣式。以下範例示範其實作方式。

```php
  # 實例化一個代表簡報檔案的 Presentation 物件
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

**哪一個 API 實體提供對特定投影片註解的存取？**

註解可透過投影片的註解管理器存取：投影片具有 [NotesSlideManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notesslidemanager/) 且有一個 [method](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/notesslidemanager/getnotesslide/) 會傳回註解物件，如果沒有註解則傳回 `null`。

**不同 PowerPoint 版本之間的註解支援有差異嗎？**

此函式庫支援廣泛的 Microsoft PowerPoint 格式（97 版至更新版）以及 ODP；在這些格式中皆支援註解，且不需依賴已安裝的 PowerPoint。