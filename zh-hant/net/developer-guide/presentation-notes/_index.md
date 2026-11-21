---
title: 在 .NET 中管理簡報註解
linktitle: 簡報註解
type: docs
weight: 110
url: /zh-hant/net/presentation-notes/
keywords:
- 註解
- 註解投影片
- 新增註解
- 移除註解
- 註解樣式
- 母片註解
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 自訂簡報註解。無縫操作 PowerPoint 與 OpenDocument 註解，以提升您的生產力。"
---
## **概觀**

Aspose.Slides 支援從簡報中移除註解投影片。本主題將介紹此功能，包括如何移除註解以及如何在簡報中為註解投影片套用樣式。Aspose.Slides 允許您從任何投影片移除註解，並可對現有註解套用樣式。開發人員可以透過以下方式移除註解：

- 從簡報中的特定投影片移除註解。
- 從簡報中的所有投影片移除註解。

若要閱讀或變更註解頁面的尺寸、切換方向以及檢查匯出行為，請參閱 [Notes Page Size](/slides/zh-hant/net/notes-size/)。

## **從投影片移除註解**
可以如下例所示，移除特定投影片的註解：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化一個表示簡報檔案的 Presentation 物件
Presentation presentation = new Presentation("AccessSlides.pptx");

// 移除第一張投影片的註解
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// 將簡報儲存至磁碟
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **從所有投影片移除註解**
可以如下例所示，移除簡報中所有投影片的註解：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化一個表示簡報檔案的 Presentation 物件 
Presentation presentation = new Presentation("AccessSlides.pptx");

// 移除所有投影片的註解
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// 將簡報儲存至磁碟
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **新增註解樣式**
已在 [IMasterNotesSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasternotesslide) 介面與 [MasterNotesSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masternotesslide) 類別中分別加入 NotesStyle 屬性。此屬性指定註解文字的樣式。以下範例示範了其實作方式。

```c#
using Aspose.Slides;

// 實例化表示簡報檔案的 Presentation 類別
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // 取得 MasterNotesSlide 文字樣式
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Set 為第一層段落設定符號項目符號
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // 將 PPTX 檔案儲存至磁碟
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **常見問題**

### 哪個 API 實體提供對特定投影片註解的存取？

註解是透過投影片的註解管理員存取的：投影片具有一個 [NotesSlideManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/notesslidemanager/) 以及返回註解物件的 [property](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/notesslidemanager/notesslide/)，若沒有註解則返回 `null`。

### 在庫支援的 PowerPoint 版本之間，註解支援有什麼差異嗎？

此庫支援廣泛的 Microsoft PowerPoint 格式（97 版至更新版）與 ODP；在這些格式中均支援註解，且不必依賴已安裝的 PowerPoint 版本。