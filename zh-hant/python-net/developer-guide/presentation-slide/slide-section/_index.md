---
title: 使用 Python 管理簡報中的投影片章節
linktitle: 投影片章節
type: docs
weight: 100
url: /zh-hant/python-net/slide-section/
keywords:
- 建立章節
- 新增章節
- 編輯章節
- 變更章節
- 章節名稱
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 簡化 PowerPoint 與 OpenDocument 的投影片章節管理 — 分割、重新命名與重新排序，以優化 PPTX 與 ODP 工作流程。"
---
## **簡介**

使用 Aspose.Slides for Python，您可以將 PowerPoint 簡報組織成可將特定投影片分組的章節。

在以下情況下，您可能想建立章節來組織或將簡報劃分為邏輯部份：
- 當您與團隊協作處理大型簡報，且需要將特定投影片指派給特定同事時。
- 當您的簡報包含大量投影片，且難以一次管理或編輯全部時。

理想情況是，建立將相關投影片（共享相同主題、議題或目的）的章節，並為每個章節命名，使其名稱能清楚反映內容。 

## **在簡報中建立章節**

若要在簡報中加入將投影片分組的[Section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/)，Aspose.Slides 提供了[add_section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sectioncollection/add_section/) 方法。您可以指定章節名稱以及章節開始的投影片。

以下 Python 範例示範如何在簡報中建立章節：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # 第 1 節在 slide2 結束；第 2 節在 slide3 開始。
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **變更章節名稱**

在 PowerPoint 簡報中建立[Section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/) 後，您可能會決定更改其名稱。

以下 Python 範例示範如何重新命名簡報中的章節：

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **常見問題**

**將簡報另存為 PPT（PowerPoint 97–2003）格式時，章節會被保留嗎？**

不會。PPT 格式不支援章節的中繼資料，儲存為 .ppt 時會失去章節分組。

**整個章節可以被「隱藏」嗎？**

不行。只能隱藏單一投影片。章節本身沒有「隱藏」狀態。

**我能否透過投影片快速找到其所屬章節，或反過來找到章節的第一張投影片？**

可以。章節是以其起始投影片唯一定義的；給定一張投影片即可判斷它屬於哪個章節，而對於章節則可取得其第一張投影片。