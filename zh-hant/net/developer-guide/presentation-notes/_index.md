---
title: 在 .NET 中管理簡報備註
linktitle: 簡報備註
type: docs
weight: 110
url: /zh-hant/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 自訂簡報備註。無縫處理 PowerPoint 與 OpenDocument 備註，提高生產力。"
---
## **概述**

Aspose.Slides 支援從簡報中移除備註投影片。在本主題中，我們將介紹此功能，包括如何移除備註以及如何在簡報中為備註投影片套用樣式。Aspose.Slides 允許您從任何投影片移除備註，亦可為現有備註套用樣式。開發人員可以透過以下方式移除備註：

- 從簡報中的特定投影片移除備註。
- 從簡報中的所有投影片移除備註。

## **從投影片移除備註**
以下範例示範如何移除特定投影片的備註：

```c#
// 實例化一個表示簡報檔案的 Presentation 物件 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// 移除第一張投影片的備註
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// 將簡報儲存至磁碟
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **從所有投影片移除備註**
以下範例示範如何移除簡報中所有投影片的備註：

```c#
// 實例化一個表示簡報檔案的 Presentation 物件 
Presentation presentation = new Presentation("AccessSlides.pptx");

// 移除所有投影片的備註
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// 將簡報儲存至磁碟
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **新增備註樣式**
已在[IMasterNotesSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imasternotesslide)介面與[MasterNotesSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/masternotesslide)類別中加入了NotesStyle屬性。此屬性指定備註文字的樣式。以下範例示範其實作方式。

```c#
// 實例化代表簡報檔案的 Presentation 類別
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // 取得 MasterNotesSlide 文字樣式
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //設定第一層段落的符號項目符號
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // 將 PPTX 檔案儲存至磁碟
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **常見問題**

**哪個 API 實體提供對特定投影片備註的存取？**

備註可透過投影片的 notes manager 取得：投影片具備[NotesSlideManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/notesslidemanager/)以及返回備註物件的[property](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/notesslidemanager/notesslide/)，若沒有備註則回傳 `null`。

**在函式庫支援的 PowerPoint 版本間，備註支援有差異嗎？**

此函式庫支援廣泛的 Microsoft PowerPoint 格式（97 版及更新版本）以及 ODP；在這些格式中皆支援備註，且不需依賴已安裝的 PowerPoint。