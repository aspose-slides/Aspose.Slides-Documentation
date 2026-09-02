---
title: 使用 Python 管理簡報的頁首與頁尾
linktitle: 頁首與頁尾
type: docs
weight: 140
url: /zh-hant/python-net/presentation-header-and-footer/
keywords:
- 頁首
- 頁首文字
- 頁尾
- 頁尾文字
- 設定頁首
- 設定頁尾
- 講義
- 備註
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在投影片、備註頁面和講義上管理頁尾、日期/時間、投影片編號和頁首佔位符。"
---
## **概述**

PowerPoint 會根據頁面類型使用不同的頁首和頁尾佔位符。Aspose.Slides for Python via .NET 允許您透過頁首/頁尾管理器類別控制這些佔位符的文字和可見性。

可用的佔位符取決於範圍：

| 範圍 | 頁首 | 頁尾 | 日期/時間 | 投影片/頁碼 |
|---|---|---|---|---|
| 一般投影片 | 否 | 是 | 是 | 是 |
| 備註母片 | 是 | 是 | 是 | 是 |
| 備註投影片 | 是 | 是 | 是 | 是 |
| 講義母片 | 是 | 是 | 是 | 是 |

普通的投影片沒有頁首佔位符。頁首僅在備註頁面和講義頁面上可用。對於普通投影片，請改用頁尾、日期/時間和投影片編號佔位符。

變更的範圍取決於您使用的管理器。[`SlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slideheaderfootermanager/) 類別控制單一普通投影片。[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/notesslideheaderfootermanager/) 類別控制單一備註投影片。母版與版面配置管理器也可以將設定傳播到相依投影片，而[`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) 類別控制講義母片。

## **設定普通投影片的頁尾、日期/時間與投影片編號**

對於普通投影片，基本工作流程是取得每張投影片的頁首/頁尾管理器，設定頁尾和日期/時間文字，啟用所需的佔位符，然後儲存簡報。投影片編號由簡報自動產生，因此您只需控制其可見性。

使用[`set_footer_text`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) 和[`set_date_time_text`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) 來設定文字，並使用[`set_footer_visibility`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/)、[`set_date_time_visibility`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/)以及[`set_slide_number_visibility`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) 來顯示相應的佔位符。

以下完整範例將相同的頁尾、日期/時間文字與投影片編號可見性套用至所有普通投影片：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

如果您只需要更新單一投影片，請直接透過[`slides`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slides/zh-hant/)集合存取該投影片，而非遍歷整個集合。

## **在備註母片上設定頁首與頁尾**

備註母片定義備註頁面的共同格式與佔位符行為。當您只想變更備註母片本身時，請使用[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslideheaderfootermanager/) 類別。

以下範例在備註母片上設定頁首、頁尾與日期/時間文字，並使所有受支援的佔位符在該母片上可見：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

簡報可能不包含備註母片，因此在變更之前請檢查回傳值是否為 `None`。

## **將備註母片設定套用至子備註投影片**

備註母片可以將頁首與頁尾設定套用於自身以及所有相依的備註投影片。當相同設定需套用於整個備註層級時，請使用[`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslideheaderfootermanager/) 上的專屬傳播方法。

例如，[`set_header_and_child_headers_text`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) 與[`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) 會更新備註母片的頁首以及所有子頁首。等效的方法亦適用於頁尾、日期/時間與投影片編號。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

上述使用的傳播方法包括[`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/)、[`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/)、[`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/)、[`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/)以及[`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/)。

## **在單一備註投影片上設定頁首與頁尾**

備註投影片屬於特定的普通投影片。當您只想自訂該備註頁面時，請使用其[`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/notesslideheaderfootermanager/) 類別。

[`add_notes_slide`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/notesslidemanager/add_notes_slide/) 方法會傳回目前投影片的備註投影片，若尚未存在則會建立一個。以下範例設定與第一張投影片關聯的備註頁面：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

如果您先從備註母片傳播設定，然後再變更單一備註投影片，之後的每張投影片設定會讓您獨立自訂該備註頁面。

## **在講義母片上設定頁首與頁尾**

講義頁面使用講義母片作為其頁首、頁尾、日期/時間與頁碼佔位符。與備註頁面不同，講義設定是透過講義母片而非個別講義投影片來管理。

使用[`master_handout_slide`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/)屬性取得講義母片。若不存在，請呼叫[`set_default_master_handout_slide`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) 以建立預設的講義母片。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **了解範圍與繼承**

選擇符合您欲變更範圍的頁首/頁尾管理器：

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slideheaderfootermanager/) 變更單一普通投影片的頁尾、日期/時間與投影片編號設定。
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslideheaderfootermanager/) 控制版面配置投影片，並能將支援的設定傳播到相依投影片。
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslideheaderfootermanager/) 控制普通投影片母版，並能將支援的設定傳播到相依投影片。
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslideheaderfootermanager/) 控制備註母片，並能將設定傳播至所有相依的備註投影片。
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/notesslideheaderfootermanager/) 變更單一備註投影片，且支援頁首佔位符，此外還有頁尾、日期/時間與投影片編號。
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) 變更講義母片，並支援全部四種佔位符類型。

當相同設定應套用於整個層級時，請使用母版或版面配置的傳播。若您只需為單一頁面設定局部設定，請使用個別投影片或備註投影片管理器。

## **常見問答**

**我可以在普通投影片上加入頁首嗎？**

不行。PowerPoint 並未為普通投影片定義頁首佔位符。於普通投影片，請使用頁尾、日期/時間與投影片編號佔位符。頁首佔位符僅在備註頁面與講義頁面上可用。

**如果頁尾、日期/時間或投影片編號佔位符不可見該怎麼辦？**

使用對應的頁首/頁尾管理器檢查其可見性，並在需要時啟用。例如，[`is_footer_visible`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) 會回報是否存在頁尾佔位符，而[`set_footer_visibility`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) 則變更其可見性。

**如何讓投影片編號從 1 以外的值開始？**

設定簡報的[`first_slide_number`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/first_slide_number/) 屬性。投影片編號佔位符將使用更新後的編號序列。

**匯出為 PDF、圖像或 HTML 時，頁首與頁尾會發生什麼情況？**

可見的頁首與頁尾元素會與簡報內容一起在輸出格式中呈現。其外觀取決於被匯出的頁面類型以及相應的佔位符可見性設定。