---
title: 在 Python 中管理簡報備註
linktitle: 簡報備註
type: docs
weight: 110
url: /zh-hant/python-net/presentation-notes/
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
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 自訂簡報備註。無縫處理 PowerPoint 與 OpenDocument 的備註，提高工作效率。"
---
## **概觀**

Aspose.Slides 支援從簡報中移除備註投影片。本節將介紹此功能，包括如何移除備註以及如何為簡報中的備註投影片套用樣式。Aspose.Slides 允許您從任意投影片移除備註，亦可對現有備註套用樣式。開發人員可以透過以下方式移除備註：

- 從簡報中特定的投影片移除備註。
- 從簡報中所有投影片移除備註。

## **從投影片移除備註**
以下範例示範如何移除特定投影片的備註：

```py
import aspose.slides as slides

# 實例化一個表示簡報檔案的 Presentation 物件 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 移除第一張投影片的備註
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # 將簡報儲存至磁碟
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **從全部投影片移除備註**
以下範例示範如何移除簡報中所有投影片的備註：

```py
import aspose.slides as slides

# 實例化一個表示簡報檔案的 Presentation 物件 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 移除所有投影片的備註
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # 將簡報儲存至磁碟
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **新增 NotesStyle**
已在 [MasterNotesSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslide/) 類別中加入 [notes_style](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslide/notes_style/) 屬性。此屬性指定備註文字的樣式。以下範例示範其實作方式。

```py
import aspose.slides as slides

# 實例化 Presentation 類別以表示簡報檔案
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # 取得 MasterNotesSlide 文字樣式
        notesStyle = notesMaster.notes_style

        #Set 為第一層段落設定符號項目符號
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # 將 PPTX 檔案儲存至磁碟
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**哪個 API 實體提供對特定投影片備註的存取？**

備註透過投影片的備註管理員存取：投影片具有 [NotesSlideManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/notesslidemanager/) 並提供返回備註物件的 [property](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/notesslidemanager/notes_slide/)，若沒有備註則返回 `None`。

**在不同 PowerPoint 版本間，備註支援有差異嗎？**

此函式庫支援廣泛的 Microsoft PowerPoint 格式（97 版至更新版）以及 ODP；備註在這些格式中皆受支援，且不需安裝 PowerPoint。