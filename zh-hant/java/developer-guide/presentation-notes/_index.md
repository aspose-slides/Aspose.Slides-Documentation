---
title: 在 Java 中管理簡報備註
linktitle: 簡報備註
type: docs
weight: 110
url: /zh-hant/java/presentation-notes/
keywords:
- 備註
- 備註投影片
- 新增備註
- 移除備註
- 備註樣式
- 母版備註
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 自訂簡報備註。無縫處理 PowerPoint 與 OpenDocument 的備註，提升您的生產力。"
---
## **概覽**

Aspose.Slides 支援從簡報中移除備註投影片。在本主題中，我們將介紹此功能，包括如何移除備註以及如何在簡報中對備註投影片套用樣式。Aspose.Slides 允許您從任何投影片中移除備註，並對現有備註套用樣式。開發人員可以透過以下方式移除備註：

- 從簡報的特定投影片中移除備註。
- 從簡報的所有投影片中移除備註。

如需讀取或變更備註頁尺寸、切換方向，並檢查匯出行為，請參閱[備註頁面大小](/slides/zh-hant/java/notes-size/)。

## **從投影片中移除備註**
以下範例示範如何從特定投影片中移除備註：

```java
import com.aspose.slides.*;

// 建立一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 移除第一張投影片的備註
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // 將簡報儲存至磁碟
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **從簡報中移除備註**
以下範例示範如何從簡報的所有投影片中移除備註：

```java
import com.aspose.slides.*;

// 建立一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 移除所有投影片的備註
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // 將簡報儲存至磁碟
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **新增備註樣式**
[getNotesStyle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) 方法已在 [IMasterNotesSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IMasterNotesSlide) 介面和 [MasterNotesSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/MasterNotesSlide) 類別中分別新增。此屬性指定備註文字的樣式。以下範例示範其實作。

```java
import com.aspose.slides.*;

// 建立一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // 取得 MasterNotesSlide 文字樣式
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //設定第一層段落的符號項目符號
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**哪個 API 實體提供對特定投影片備註的存取？**

備註是透過投影片的備註管理器存取的：投影片擁有一個 [NotesSlideManager](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notesslidemanager/)，以及一個返回備註物件的[method](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notesslidemanager/#getNotesSlide--)（若無備註則返回 `null`）。

**不同 PowerPoint 版本對備註的支援有差異嗎？**

此函式庫支援廣泛的 Microsoft PowerPoint 格式（97 版至更新版本）以及 ODP；在這些格式中均支援備註，且不需依賴已安裝的 PowerPoint。