---
title: 使用 Python via Java 管理簡報投影片節
linktitle: 投影片節
type: docs
weight: 90
url: /zh-hant/python-java/slide-section/
keywords:
- 建立節
- 添加節
- 編輯節
- 更改節
- 節名稱
- 取得節投影片
- 處理節投影片
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 管理投影片節：在 PPTX 簡報中建立、重新命名、重新排序、取得及處理節投影片。"
---
## **簡介**

節會將連續的投影片組織成具名的群組，而不會更改投影片內容。使用 Aspose.Slides for Python via Java，您可以透過 [Presentation.getSections](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSections) 方法建立、重新排序、重新命名、檢查以及移除節。

節特別在以下情況下有用：

- 大型簡報需要被劃分為邏輯主題或章節；
- 不同的投影片群組指派給不同的協作者；
- 需要將投影片作為群組來處理、移動或合併。

請選擇能簡潔描述所屬投影片目的的節名稱。由於節是簡報結構的一部分，請使用節 API 來判斷所屬關係，而不是依據投影片位置推算。

## **建立與管理節**

使用 [SectionCollection.addSection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sectioncollection/#addSection) 透過指定名稱與起始投影片來建立節。Aspose.Slides 會根據簡報目前的節結構來判斷哪些投影片屬於該節。

相同的 [SectionCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sectioncollection/) 也讓您：

- 使用 [reorderSectionWithSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) 移動包含其投影片的節；
- 僅以 [removeSection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sectioncollection/#removeSection) 移除節的定義，保留其投影片；
- 使用 [removeSectionWithSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sectioncollection/#removeSectionwithslides) 同時移除節及其投影片；
- 以 [appendEmptySection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sectioncollection/#appendEmptySection) 在最後加入空白節。

以下範例建立兩個節，移動其中一個，將其連同投影片一起移除，並在最後加入空白節：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

執行這些操作後，簡報會包含具有投影片的 `Introduction` 節以及空的 `Appendix` 節。`Results` 節及其投影片已被移除。

## **重新命名節**

若要重新命名節，呼叫其 [Section.setName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/#setName) 方法。節的投影片與位置不會改變。

以下範例建立一個節並變更其名稱：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **從節取得投影片**

[Presentation.getSections](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSections) 方法會回傳可供迭代的 [SectionCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sectioncollection/)。對於每個 [Section](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/)，呼叫 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/#getSlidesListOfSection) 取得目前屬於該節的投影片。該方法回傳一個 [SectionSlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sectionslidecollection/)，提供計數、索引存取與迭代功能。

以下範例建立兩個已填充的節和一個空白節，然後列印每個節的 [name](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/#getName)、[identifier](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/#getSectionId)、[starting slide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/#getStartedFromSlide)、投影片數量與投影片編號。它使用 [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sectionslidecollection/#get_Item) 讀取第一張投影片，並以 `for` 陳述式處理每張投影片。對於空白節，回傳的集合大小為零，方法不會被呼叫，迭代不執行任何操作。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

節的成員資格由簡報的節結構決定。請勿依照 [Section.getStartedFromSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/#getStartedFromSlide)、投影片索引以及下一節的起始投影片手動計算節的範圍。

結構性編輯可能會同時變更節所回傳的投影片以及它們的投影片編號。這包括重新排序投影片、將投影片複製至節、搬移含投影片的節、移除投影片以及移除節。下一個範例在每次此類變更後呼叫 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/#getSlidesListOfSection)，而非保留對先前邊界的假設。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

每當投影片或節被重新排序、複製、搬移或移除時，請再次呼叫 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/#getSlidesListOfSection)。這可確保後續處理與目前的簡報結構保持一致。

PPT（PowerPoint 97–2003）格式不會保留節的中繼資料。請使用支援節的格式（如 PPTX）執行此工作流程；轉換為 PPT 會移除後續迭代所需的節結構。

## **常見問題**

**將簡報儲存為 PPT（PowerPoint 97–2003）格式時，節會被保留嗎？**

不會。PPT 格式不支援節的中繼資料，因此在儲存為 .ppt 時會失去節的分組。

**整個節能被「隱藏」嗎？**

不能。節本身沒有可見性狀態。若要隱藏其內容，必須對該節中的每張投影片呼叫 [Slide.setHidden](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#setHidden)。

**如何找出包含特定投影片的節？**

遍歷由 [Presentation.getSections](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSections) 回傳的集合，對每個節呼叫 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/#getSlidesListOfSection)，並將回傳的投影片與目標投影片比較。對於非空白節，[Section.getStartedFromSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/section/#getStartedFromSlide) 會回傳其第一張投影片；對於空白節，則回傳 `None`。