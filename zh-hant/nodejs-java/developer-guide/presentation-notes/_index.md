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
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中自訂簡報備註。無縫操作 PowerPoint 與 OpenDocument 備註，提高您的生產力。"
---
## **概觀**

Aspose.Slides 支援從簡報中移除備註投影片。本主題將介紹此功能，包括如何移除備註以及如何在簡報中對備註投影片套用樣式。Aspose.Slides 允許您從任何投影片中移除備註，亦可對現有備註套用樣式。開發人員可以透過以下方式移除備註：

- 從簡報的特定投影片中移除備註。
- 從簡報的所有投影片中移除備註。

## **從投影片移除備註**
以下範例示範了如何移除特定投影片的備註：

```javascript
// 實例化一個代表簡報檔案的 Presentation 物件
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
以下範例示範了如何移除簡報中所有投影片的備註：

```javascript
// 實例化一個代表簡報檔案的 Presentation 物件
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
[getNotesStyle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) 方法已新增至 [MasterNotesSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/MasterNotesSlide) 類別中。此屬性指定備註文字的樣式。以下範例示範了其實作。

```javascript
// 實例化一個代表簡報檔案的 Presentation 物件
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // 取得 MasterNotesSlide 文字樣式
        var notesStyle = notesMaster.getNotesStyle();
        // 為第一層段落設定符號項目符號
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
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

備註是透過投影片的備註管理員取得：投影片擁有一個 [NotesSlideManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notesslidemanager/)，以及一個會回傳備註物件的 [method](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/)（若無備註則回傳 `null`）。

**在函式庫支援的 PowerPoint 版本之間，備註支援有差異嗎？**

此函式庫支援廣泛的 Microsoft PowerPoint 格式（97 版及更新版本）以及 ODP；備註在這些格式中皆受支援，且不須依賴已安裝的 PowerPoint。