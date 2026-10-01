---
title: 在 Python 中管理簡報筆記
linktitle: 簡報筆記
type: docs
weight: 110
url: /zh-hant/python-net/presentation-notes/
keywords:
- 筆記
- 筆記投影片
- 新增筆記
- 移除筆記
- 筆記樣式
- 母版筆記
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 .NET 自訂簡報筆記。無縫處理 PowerPoint 與 OpenDocument 筆記，提升您的工作效率。"
---
## **概述**

Aspose.Slides 支援從簡報中移除筆記投影片。本主題將介紹此功能，包括如何移除筆記以及如何在簡報中對筆記投影片套用樣式。Aspose.Slides 允許您從任何投影片中移除筆記，並且對現有筆記套用樣式。開發人員可以透過以下方式移除筆記：

- 從簡報中的特定投影片移除筆記。
- 從簡報中的所有投影片移除筆記。

若要閱讀或變更筆記頁面的尺寸、切換方向，以及檢查匯出行為，請參閱 [Notes Page Size](/slides/zh-hant/python-net/notes-size/)。

## **從投影片中移除筆記**
如以下範例所示，可移除特定投影片的筆記：

```py
import aspose.slides as slides

# 實例化一個代表簡報檔案的 Presentation 物件
with slides.Presentation("AccessSlides.pptx") as presentation:
    # 移除第一張投影片的筆記
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # 將簡報儲存至磁碟
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **從所有投影片中移除筆記**
如以下範例所示，可移除簡報中所有投影片的筆記：

```py
import aspose.slides as slides

# 實例化一個代表簡報檔案的 Presentation 物件 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # 移除所有投影片的筆記
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # 將簡報儲存至磁碟
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **套用筆記樣式**
[notes_style](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslide/notes_style/) 屬性已新增至 [MasterNotesSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslide/) 類別。此屬性指定筆記文字的樣式。以下範例示範了此實作。

```py
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # 取得 MasterNotesSlide 文字樣式
        notesStyle = notesMaster.notes_style

        #設定第一層段落的符號項目符號
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # 將 PPTX 檔案儲存至磁碟
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**哪個 API 實體提供對特定投影片筆記的存取？**

筆記可透過投影片的筆記管理器取得：投影片具有 [NotesSlideManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/notesslidemanager/)，以及返回筆記物件的 [property](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/notesslidemanager/notes_slide/)，若無筆記則返回 `None`。

**在不同 PowerPoint 版本中，筆記支援有何差異？**

此函式庫支援廣泛的 Microsoft PowerPoint 格式（97 版及更新版本）以及 ODP；在這些格式中均支援筆記，且不需依賴已安裝的 PowerPoint 版本。