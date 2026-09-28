---
title: 在 Python 中套用或變更投影片版面
linktitle: 投影片版面
type: docs
weight: 60
url: /zh-hant/python-net/slide-layout/
keywords:
- 投影片版面
- 內容版面
- 佔位元
- 簡報設計
- 投影片設計
- 未使用的版面
- 頁腳可見性
- 標題投影片
- 標題與內容
- 節標題
- 兩欄內容
- 比較
- 僅標題
- 空白版面
- 含說明文字的內容
- 含說明文字的圖片
- 標題與垂直文字
- 垂直標題與文字
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python（透過 .NET）套用、建立與修改投影片版面，新增佔位元、移除未使用的版面，並控制頁腳可見性。"
---
## **概觀**

投影片版面定義標題、文字、圖片、圖表與表格等佔位元的定位與格式。套用版面可讓投影片保持一致的結構，同時允許每張投影片擁有自己的內容。

最常見的版面包括：

- **Title Slide**：包含標題與副標題佔位元。
- **Title and Content**：包含標題佔位元與一般內容佔位元。
- **Blank**：不含任何內容佔位元，當所有圖形都需要手動定位時非常有用。

## **了解版面繼承**

簡報具有三個相關層級：

1. A [母片投影片](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslide/) 定義主題、共用格式、背景與共用物件。
2. A [版面投影片](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/) 屬於母片，並定義特定的佔位元排列。
3. A [普通投影片](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/) 使用一個版面，並儲存該投影片輸入的內容。

普通投影片從其版面繼承主題與格式，版面則繼承自其母片。直接設定於普通投影片上的值會覆寫該層級的繼承值。建立普通投影片時，其佔位元圖形會根據所選版面產生，而填入這些佔位元的內容則屬於普通投影片。

在從版面建立投影片之前，請先將所需的佔位元加入版面。之後再為版面新增佔位元不會自動在現有普通投影片中加入對應的佔位元圖形。

此關係有兩個重要的結果：

- 變更版面上繼承的格式或現有佔位元的幾何形狀會更新所有依賴它的投影片。在編輯已在使用的版面前，請先檢查其依賴投影片並檢視產生的簡報。
- 仍被投影片使用的版面無法移除。必須先將其依賴投影片重新指派到其他版面，或僅移除未使用的版面。

欲了解此層級階層的更詳細資訊，請參閱 [Slide Master](/slides/zh-hant/python-net/slide-master/)。

若要在單一投影片或共用版面上隱藏繼承的標誌或裝飾性母片圖形，請參閱 [Control the Visibility of Master Graphics](/slides/zh-hant/python-net/slide-master/)。範例比較了使用相同母片的兩張投影片。

## **選取並套用投影片版面**

當簡報遵循標準 PowerPoint 版面定義時，使用版面類型。版面名稱可由使用者編輯且可本地化，因此除非您掌控來源範本，否則僅依名稱選取的可靠性較低。

下列範例在第一個母片上搜尋 **Title and Content**。如果該版面不存在，則會刻意回退到 **Blank**。第二個 null 檢查是必要的，因為簡報可能只包含自訂版面。選取的版面接著透過 [Slide.layout_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/layout_slide/) 屬性套用至第一張普通投影片。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

變更投影片的版面不會移除直接加入投影片的普通圖形。然而，佔位元位置、繼承格式以及現有佔位元與新版面之間的對應關係可能會改變，請在切換差異較大的版面時檢查輸出結果。

## **新增版面投影片**

選取與建立是分開的操作。前面的範例只選取了既有版面，並未建立。若要建立版面，請對目標母片的版面集合呼叫 [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterlayoutslidecollection/add/) 方法。

下列範例始終新增一個名為 `Report Title and Content` 的 **Title and Content** 版面，然後基於它新增普通投影片。版面名稱在集合內必須唯一。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

僅在範本真的需要另一個可重複使用的結構時才新增版面。如果已存在合適的版面，請選取並重複使用，而非建立重複的版面。

## **在版面投影片中新增佔位元**

[LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/placeholder_manager/) 屬性提供一個 [LayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/) 用於向版面新增佔位元圖形。

| PowerPoint 版位               | `LayoutPlaceholderManager` 方法 |
| ----------------------------- | -------------------------------- |
| ![Content](content.png)       | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Content (Vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Text](text.png)             | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Text (Vertical)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Picture](picture.png)       | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Chart](chart.png)           | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Table](table.png)           | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)     | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png)           | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online Image](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

下列範例驗證 **Blank** 版面是否存在，向其新增四個佔位元，然後建立使用此修改版面的普通投影片。順序刻意這樣安排：先加入佔位元再建立普通投影片，讓 Aspose.Slides 能在該投影片上產生對應的佔位元圖形。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
變更繼承的格式或現有版面佔位元的幾何形狀可能會影響依賴的投影片。新加入的版面佔位元不會回填至既有普通投影片。請在簡報的副本上測試版面變更，並檢查每張依賴投影片。
{{% /alert %}}

## **移除未使用的版面投影片**

使用 [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) 方法移除沒有普通投影片參照的版面。此方法會保留仍在使用中的版面。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

若要移除特定版面，請先使用其 [has_depending_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/has_depending_slides/) 屬性或 [get_depending_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/get_depending_slides/) 方法。重新指派任何依賴的投影片後，再呼叫 [LayoutSlide.remove](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/remove/)。嘗試移除仍被使用的版面會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pptxeditexception/)。

## **控制版面投影片的頁腳可見性**

版面擁有自己的頁腳、投影片編號與日期時間佔位元。使用 [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/header_footer_manager/) 屬性可為單一版面控制這些佔位元。這在例如內容版面需要顯示頁腳，而標題版面不需要時特別有用。

下列範例安全地選取版面，並將其頁腳元素設為可見：

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **控制母片及其子版面的頁腳可見性**

若要在母片層級中套用一致的頁腳設定，請使用 [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslide/header_footer_manager/) 屬性。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslideheaderfootermanager/) 的傳播方法會作用於母片、其依賴的版面投影片與普通投影片；不會只針對單一普通投影片。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**母片投影片與版面投影片有何不同？**

母片投影片定義簡報的主題與共用格式。版面投影片屬於母片，定義一組可重複使用的佔位元排列。普通投影片使用這些版面並儲存投影片特定的內容。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

可以。使用 [add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/globallayoutslidecollection/add_clone/) 方法將副本加入目標集合。跨簡報複製時，亦需驗證來源版面使用的字型、主題、圖片與其他資源。

**當我修改已在使用的版面時會發生什麼事？**

依賴的投影片會繼承版面變更，除非它們在本機覆寫受影響的格式或物件。佔位元幾何形狀與繼承樣式因此可能一次改變多張投影片。編輯版面前，請使用 [get_depending_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/get_depending_slides/) 來識別受影響的投影片。

**如果我移除仍在使用的版面會怎樣？**

Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pptxeditexception/)。請先重新指派依賴投影片，或使用 [remove_unused_layout_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) 只移除未被參照的版面。