---
title: 在 JavaScript 中管理簡報備註
linktitle: 簡報備註
type: docs
weight: 110
url: /zh-hant/nodejs-java/presentation-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中自訂簡報備註。無縫操作 PowerPoint 和 OpenDocument 的備註，以提升您的工作效率。"
---
## **概觀**

Aspose.Slides 支援從簡報中移除備註投影片。在本主題中，我們將介紹此功能，包括如何移除備註以及如何對簡報中的備註投影片套用樣式。Aspose.Slides 允許您從任何投影片移除備註，並對現有備註套用樣式。開發人員可以透過以下方式移除備註：

- 從簡報中的特定投影片移除備註。
- 從簡報中的所有投影片移除備註。

若要讀取或變更備註頁面尺寸、切換方向，並檢查匯出行為，請參閱[備註頁面大小](/slides/zh-hant/nodejs-java/notes-size/)。

## **從投影片移除備註**
可以如以下範例所示，從特定投影片移除備註：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 建立代表簡報檔案的 Presentation 物件
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // 移除第一張投影片的備註
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // 將簡報儲存至磁碟
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **從簡報移除備註**
可以如以下範例所示，從簡報中的所有投影片移除備註：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 建立代表簡報檔案的 Presentation 物件
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // 移除所有投影片的備註
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // 將簡報儲存至磁碟
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **新增 NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) 方法已新增至 [MasterNotesSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/MasterNotesSlide) 類別，並分別新增至 [MasterNotesSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/MasterNotesSlide) 類別。此屬性指定備註文字的樣式。以下範例示範了其實作。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 建立代表簡報檔案的 Presentation 物件
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // 取得 MasterNotesSlide 文字樣式
        var notesStyle = notesMaster.getNotesStyle();
        // 為第一層段落設定符號項目符號
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**哪個 API 實體提供對特定投影片備註的存取？**

備註可通過投影片的備註管理器存取：投影片具有一個 [NotesSlideManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notesslidemanager/)，以及一個返回備註物件的 [method](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/)（若無備註則返回 `null`）。

**此函式庫支援的 PowerPoint 版本在備註支援方面是否有差異？**

此函式庫支援廣泛的 Microsoft PowerPoint 格式（97 版至更新版本）以及 ODP；在這些格式中皆支援備註，且不依賴已安裝的 PowerPoint 副本。