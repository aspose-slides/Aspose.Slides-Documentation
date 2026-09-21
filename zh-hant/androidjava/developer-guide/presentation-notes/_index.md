---
title: 在 Android 上管理簡報註解
linktitle: 簡報註解
type: docs
weight: 110
url: /zh-hant/androidjava/presentation-notes/
keywords:
- 註解
- 註解投影片
- 新增註解
- 移除註解
- 註解樣式
- 主註解
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "透過 Java 在 Android 上使用 Aspose.Slides 自訂簡報註解。無縫處理 PowerPoint 與 OpenDocument 註解，提高工作效率。"
---
## **概述**

Aspose.Slides 支援從簡報中移除註解投影片。本主題將介紹此功能，包括如何移除註解以及如何在簡報中為註解投影片套用樣式。Aspose.Slides 允許您從任何投影片移除註解，並且對現有註解套用樣式。開發人員可以透過以下方式移除註解：

- 從簡報中的特定投影片移除註解。
- 從簡報中的所有投影片移除註解。

如需閱讀或變更註解頁面尺寸、切換方向以及檢查匯出行為，請參閱[註解頁面大小](/slides/zh-hant/androidjava/notes-size/)。

## **從投影片中移除註解**
以下範例示範如何從特定投影片移除註解：

```java
import com.aspose.slides.*;

// 實例化一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 移除第一張投影片的註解
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // 將簡報儲存至磁碟
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **從簡報中移除註解**
以下範例示範如何從簡報中的所有投影片移除註解：

```java
import com.aspose.slides.*;

// 實例化一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 移除所有投影片的註解
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

## **新增註解樣式**
[getNotesStyle](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) 方法已分別新增至 [IMasterNotesSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IMasterNotesSlide) 介面與 [MasterNotesSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/MasterNotesSlide) 類別。此屬性指定註解文字的樣式。以下範例示範其實作方式。

```java
import com.aspose.slides.*;

// 實例化一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // 取得 MasterNotesSlide 文字樣式
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //為第一層段落設定符號項目符號
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**哪個 API 實體提供對特定投影片註解的存取？**

註解可透過投影片的註解管理員存取：投影片擁有一個 [NotesSlideManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notesslidemanager/) 並且有一個 [method](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) 可回傳註解物件，若無註解則回傳 `null`。

**在函式庫支援的 PowerPoint 版本間，註解支援有差異嗎？**

此函式庫支援廣泛的 Microsoft PowerPoint 格式（97 版至更新版）以及 ODP；在這些格式中皆支援註解，且不依賴已安裝的 PowerPoint 版本。