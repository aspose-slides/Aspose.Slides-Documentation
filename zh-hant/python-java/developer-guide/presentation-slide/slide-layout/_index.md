---
title: 在 Python（透過 Java）應用或變更投影片版面
linktitle: 投影片版面
type: docs
weight: 60
url: /zh-hant/python-java/slide-layout/
keywords:
- 投影片版面
- 內容版面
- 佔位符
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python（透過 Java）中套用、建立與修改投影片版面，加入佔位符、移除未使用的版面，並控制頁腳可見性。"
---
## **概述**

投影片版面定義標題、文字、圖片、圖表和表格等佔位符的位置與格式。套用版面可為投影片提供一致的結構，同時允許每張投影片保有自己的內容。

- **標題投影片**：包含標題與副標題佔位符。
- **標題與內容**：包含標題佔位符以及通用內容佔位符。
- **空白**：不含任何內容佔位符，適用於所有形狀皆需手動定位的情況。

## **了解版面繼承**

簡報有三個相關層級：

1. [母片投影片](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/) 定義主題、共用格式、背景以及共通物件。
2. [版面投影片](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/) 屬於母片，定義特定的佔位符配置。
3. [一般投影片](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/) 使用一個版面，並儲存該投影片輸入的內容。

一般投影片會從其版面繼承主題與格式，而版面則從其母片繼承。直接在一般投影片上設定的值會覆寫該層級的繼承值。建立一般投影片時，會根據所選版面產生其佔位符形狀，而填入佔位符的內容則屬於該一般投影片。

在使用版面建立投影片之前，請先於版面加入必要的佔位符。之後再向版面新增佔位符，並不會自動為現有的一般投影片新增對應的佔位符形狀。

此關係有兩個重要的結果：

- 修改版面上繼承的格式或現有佔位符的幾何形狀，會更新所有依賴該版面的投影片。編輯已在使用的版面前，請先檢查其依賴投影片並審視最終的簡報。
- 仍被投影片使用的版面無法直接移除。必須先將其依賴的投影片指派至其他版面，或僅移除未被使用的版面。

如需瞭解此階層最高層級的更多資訊，請參閱[投影片母片](/slides/zh-hant/python-java/slide-master/)。

若要在單一投影片或透過共用版面隱藏繼承的標誌或裝飾性母片形狀，請參閱[控制母片圖形的可見性](/slides/zh-hant/python-java/slide-master/)。範例比較了兩張使用相同母片的投影片。

## **選取與套用投影片版面**

當簡報遵循標準 PowerPoint 版面定義時，請使用版面類型。版面名稱可由使用者編輯且可本地化，因此除非您掌控來源範本，否則僅依名稱選取的可靠性較低。

以下範例在第一個母片上尋找 **標題與內容**。若該版面不存在，則刻意回退至 **空白**。第二次檢查 `None` 是必要的，因為簡報可能僅包含自訂版面。然後透過[Slide.setLayoutSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#setLayoutSlide) 方法，將選取的版面套用至第一張一般投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

變更投影片的版面不會移除直接加在投影片上的一般形狀。然而，佔位符位置、繼承的格式以及既有佔位符與新版面的對應關係可能會改變，切換至差異較大的版面時請檢查輸出結果。

## **新增版面投影片**

選取與建立是分開的操作。前一個範例僅選取現有版面，並未建立。若要建立版面，請於目標母片的版面集合上呼叫[MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterlayoutslidecollection/#add) 方法。

以下範例始終新增一個名為 `Report Title and Content` 的 **標題與內容** 版面，然後基於該版面新增一般投影片。版面名稱在集合內必須唯一。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

僅在範本真的需要另一個可重複使用的結構時才新增版面。若已有合適的版面，請選取並重複使用，而非建立重複的版面。

## **向版面投影片新增佔位符**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/#getPlaceholderManager) 方法會回傳一個用於向版面新增佔位符形狀的[LayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutplaceholdermanager/)。

| PowerPoint 佔位符 | [LayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutplaceholdermanager/) 方法 |
| ------------------ | ------------------------------------------- |
| ![內容](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![內容 (垂直)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![文字](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![文字 (垂直)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![圖片](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![圖表](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![表格](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![媒體](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![線上圖片](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

以下範例驗證 **空白** 版面是否存在，向其新增四個佔位符，然後建立使用該修改版面的普通投影片。順序刻意這樣安排：先新增佔位符，再建立一般投影片，讓 Aspose.Slides 能在該投影片上產生對應的佔位符形狀。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![版面投影片上的佔位符](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
變更已繼承的格式或現有版面佔位符的幾何形狀可能會影響依賴的投影片。新加入的版面佔位符不會回填至現有的一般投影片。請在簡報的副本上測試版面變更，並檢查每一張依賴投影片。
{{% /alert %}}

## **移除未使用的版面投影片**

使用[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) 方法移除未被任何一般投影片參照的版面。此方法會保留仍在使用中的版面。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若要移除特定的版面，請先使用其[hasDependingSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/#hasDependingSlides)或[getDependingSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/#getDependingSlides) 方法。在呼叫[LayoutSlide.remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/#remove) 前，先將任何依賴的投影片重新指派。嘗試移除仍在使用中的版面會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxeditexception/)。

## **控制版面投影片的頁腳可見性**

版面擁有自己的頁腳、投影片編號與日期時間佔位符。使用[LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) 方法可針對單一版面控制這些佔位符。這在例如內容版面需要顯示頁腳而標題版面不需要時相當有用。

以下範例安全地選取一個版面，並使其頁腳元素可見：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **控制母片及其子版面的頁腳可見性**

若要在母片階層中套用一致的頁腳設定，請使用[MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/#getHeaderFooterManager) 方法。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslideheaderfootermanager/) 的傳播方法會作用於母片及其依賴的版面投影片與一般投影片；它們不會僅針對單一一般投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**母片與版面投影片有何差異？**

母片定義簡報的主題與共用格式。版面投影片屬於母片，定義一組可重複使用的佔位符配置。一般投影片使用這些版面，並儲存投影片特有的內容。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

可以。使用 [addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/globallayoutslidecollection/#addClone) 方法將副本加入目標集合。於簡報之間複製時，亦需確認來源版面使用的字型、主題、圖像與其他資源。

**當我修改已在使用的版面時會發生什麼？**

依賴的投影片會繼承版面的變更，除非它們在本機覆寫了受影響的格式或物件。佔位符的幾何形狀與繼承的樣式因此可能一次在多張投影片上變更。編輯版面前，請使用[getDependingSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/#getDependingSlides) 以辨識受影響的投影片。

**如果我移除仍在使用中的版面會發生什麼？**

Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxeditexception/)。請先重新指派依賴的投影片，或使用 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) 只移除未被參照的版面。