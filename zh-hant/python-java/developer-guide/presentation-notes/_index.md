---
title: 在 Python（透過 Java）中管理簡報備註
linktitle: 簡報備註
type: docs
weight: 110
url: /zh-hant/python-java/presentation-notes/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 自訂簡報備註。無縫處理 PowerPoint 與 OpenDocument 的備註，提升您的生產力。"
---
## **概觀**

Aspose.Slides 支援從簡報中移除備註投影片。本主題介紹此功能，包括如何移除備註以及如何在簡報中對備註投影片套用樣式。Aspose.Slides 允許您從任何投影片中移除備註，並對現有備註套用樣式。開發人員可以透過以下方式移除備註：

- 從簡報中的特定投影片移除備註。
- 從簡報中的所有投影片移除備註。

若要閱讀或變更備註頁面的尺寸、切換方向，以及檢查匯出行為，請參閱 [Notes Page Size](/slides/zh-hant/python-java/notes-size/)。

## **從投影片中移除備註**

以下範例示範如何從特定投影片中移除備註：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 建立一個代表簡報檔案的 Presentation 物件。
presentation = Presentation("presWithNotes.pptx")
try:
    # 從第一張投影片中移除備註。
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # 將簡報儲存至磁碟。
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **從簡報中移除備註**

以下範例示範如何從簡報中的所有投影片中移除備註：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 建立一個代表簡報檔案的 Presentation 物件。
presentation = Presentation("presWithNotes.pptx")
try:
    # 從所有投影片中移除備註。
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # 將簡報儲存至磁碟。
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **新增備註樣式**

[getNotesStyle](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslide/#getNotesStyle) 方法屬於 [MasterNotesSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslide/) 類別，提供對備註文字樣式的存取。以下範例示範此實作。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# 建立一個代表簡報檔案的 Presentation 物件。
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # 取得主備註投影片文字樣式。
        notes_style = notes_master.getNotesStyle()

        # 為第一層段落設定符號項目符號。
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**哪個 API 實體提供對特定投影片備註的存取？**

備註是透過投影片的備註管理器存取的：投影片具備 [NotesSlideManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notesslidemanager/)，以及 [getNotesSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notesslidemanager/#getNotesSlide) 方法，該方法回傳備註物件；如果沒有備註，則回傳 `None`。

**不同 PowerPoint 版本的備註支援是否有差異？**

此函式庫支援廣泛的 Microsoft PowerPoint 格式（97 版及之後）以及 ODP；備註在這些格式中皆受支援，且不需要安裝 PowerPoint 即可使用。