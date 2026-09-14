---
title: 在 Python via Java 中管理簡報的頁首與頁腳
linktitle: 頁首與頁腳
type: docs
weight: 140
url: /zh-hant/python-java/presentation-header-and-footer/
keywords:
- 頁首
- 頁首文字
- 頁腳
- 頁腳文字
- 設定頁首
- 設定頁腳
- 講義
- 註解
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在投影片、註解頁面與講義上管理頁腳、日期/時間、投影片編號及頁首佔位符。"
---
## **概觀**

PowerPoint 會根據頁面類型使用不同的頁首與頁腳佔位符。Aspose.Slides for Python via Java 讓您透過頁首/頁腳管理器類別控制這些佔位符的文字與可見性。

可用的佔位符取決於範圍：

| 範圍 | 頁首 | 頁腳 | 日期/時間 | 投影片/頁碼 |
|---|---|---|---|---|
| 一般投影片 | 否 | 是 | 是 | 是 |
| 註解母片 | 是 | 是 | 是 | 是 |
| 註解投影片 | 是 | 是 | 是 | 是 |
| 讲义母片 | 是 | 是 | 是 | 是 |

一般的投影片沒有頁首佔位符。頁首僅在註解頁面與講義頁面可用。對於一般投影片，請使用頁腳、日期/時間與投影片編號佔位符。

變更的範圍取決於您使用的管理器。[SlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideheaderfootermanager/) 類別控制單一一般投影片。[NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notesslideheaderfootermanager/) 類別控制單一註解投影片。母片與版面配置管理器亦能將設定傳播至子投影片，而 [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) 類別則控制講義母片。

## **在一般投影片上設定頁腳、日期/時間與投影片編號**

對於一般投影片，基本流程是取得每張投影片的頁首/頁腳管理器，設定頁腳與日期/時間文字，啟用所需的佔位符，然後儲存簡報。投影片編號由簡報自動產生，只需控制其可見性。

使用 [setFooterText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) 與 [setDateTimeText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) 來設定文字，並使用 [setFooterVisibility](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility)、[setDateTimeVisibility](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) 與 [setSlideNumberVisibility](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) 來顯示相應的佔位符。

以下端到端範例將相同的頁腳、日期/時間文字與投影片編號可見性套用至所有一般投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果只想更新單一投影片，請直接透過 [getSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSlides) 方法存取該投影片，而不是遍歷整個集合。

## **在註解母片上設定頁首與頁腳**

註解母片定義了註解頁面的共同行格式與佔位符行為。當您只想變更註解母片本身時，請使用 [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslideheaderfootermanager/) 類別。

以下範例在註解母片上設定頁首、頁腳與日期/時間文字，並使所有支援的佔位符在該母片上可見：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果簡報不包含註解母片，`getMasterNotesSlide` 方法會回傳 `None`。

## **將註解母片設定套用至子註解投影片**

註解母片可以將頁首與頁腳設定套用給自己以及所有相依的註解投影片。當相同設定需要跨註解層級套用時，請使用 [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslideheaderfootermanager/) 上的專屬傳播方法。

例如，[setHeaderAndChildHeadersText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) 與 [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) 會更新註解母片的頁首以及所有子頁首。對於頁腳、日期/時間與投影片編號也有對應的方法。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

上述使用的傳播方法包括 [setFooterAndChildFootersText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText)、[setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility)、[setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText)、[setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) 以及 [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility)。

## **在單一註解投影片上設定頁首與頁腳**

註解投影片屬於特定的一般投影片。當您只想自訂該註解頁面時，請使用其 [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notesslideheaderfootermanager/) 類別。

[addNotesSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notesslidemanager/#addNotesSlide) 方法會回傳目前投影片的註解投影片，若尚未存在則會建立。以下範例設定與第一張投影片相關的註解頁面：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果您先從註解母片傳播設定，然後再變更單一註解投影片，後續的每張投影片設定會讓您獨立自訂該註解頁面。

## **在講義母片上設定頁首與頁腳**

講義頁面使用講義母片來放置頁首、頁腳、日期/時間與頁碼佔位符。與註解頁面不同，講義設定是透過講義母片而非個別講義投影片管理。

使用 `getMasterHandoutSlide` 方法存取講義母片。若不存在，請呼叫 `setDefaultMasterHandoutSlide` 以建立預設的講義母片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **了解範圍與繼承**

選擇符合您要變更範圍的頁首/頁腳管理器：

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideheaderfootermanager/) 變更單一一般投影片的頁腳、日期/時間與投影片編號設定。
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslideheaderfootermanager/) 控制版面投影片，並可將支援的設定傳播至相依投影片。
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslideheaderfootermanager/) 控制一般投影片母片，並可將支援的設定傳播至相依投影片。
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masternotesslideheaderfootermanager/) 控制註解母片，並可將設定傳播至所有相依的註解投影片。
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notesslideheaderfootermanager/) 變更單一註解投影片，且支援頁首佔位符，此外還有頁腳、日期/時間與投影片編號。
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) 變更講義母片，支援四種佔位符類型。

當相同設定需套用於整個層級時，請使用母片或版面配置的傳播功能。需要單一頁面局部設定時，則使用個別投影片或註解投影片管理器。

## **常見問題**

**我可以在一般投影片上加入頁首嗎？**

不能。PowerPoint 並未為一般投影片定義頁首佔位符。請在一般投影片上使用頁腳、日期/時間與投影片編號佔位符。頁首佔位符僅在註解頁面與講義中可用。

**如果頁腳、日期/時間或投影片編號佔位符不可見該怎麼辦？**

使用相應的頁首/頁腳管理器檢查其可見性，並在需要時啟用。例如，[isFooterVisible](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) 會回報頁腳佔位符是否存在，而 [setFooterVisibility](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) 可變更其可見性。

**如何讓投影片編號從 1 以外的值開始？**

呼叫簡報的 [setFirstSlideNumber](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#setFirstSlideNumber) 方法。投影片編號佔位符將使用更新後的編號序列。

**匯出為 PDF、圖片或 HTML 時，頁首與頁腳會發生什麼變化？**

可見的頁首與頁腳元素會與其他簡報內容一起在輸出格式中呈現。其外觀取決於正在匯出的頁面類型以及相應的佔位符可見性設定。