---
title: 在 Python 中套用或變更投影片版面
linktitle: 投影片版面
type: docs
weight: 60
url: /zh-hant/python-net/slide-layout/
keywords:
- 投影片版面
- 內容版面
- 占位元件
- 簡報設計
- 投影片設計
- 未使用的版面
- 頁腳可見性
- 標題投影片
- 標題與內容
- 節標題
- 雙內容
- 比較
- 僅標題
- 空白版面
- 帶說明的內容
- 帶說明的圖片
- 標題與垂直文字
- 垂直標題與文字
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python（透過 .NET）中管理與自訂投影片版面。探索版面類型、占位元件控制、頁腳可見性，以及透過 Python 程式範例進行版面操作。"
---
## **簡介**

投影片版面定義了投影片上占位框的排列方式與內容的格式設定。它控制哪些占位元件可用以及它們出現的位置。投影片版面可協助您快速且一致地設計簡報，無論是建立簡單或較複雜的內容。PowerPoint 中最常見的投影片版面包括：

**Title Slide 版面** – 包含兩個文字占位元件：一個用於標題，另一個用於副標題。

**Title and Content 版面** – 在頂部有較小的標題占位元件，下方則有較大的主要內容占位元件（例如文字、項目符號、圖表、圖片等）。

**Blank 版面** – 不含任何占位元件，讓您可以從頭開始完整設計投影片。

投影片版面是投影片母片的一部份，母片是定義簡報版面樣式的最高層投影片。您可以透過投影片母片以類型、名稱或唯一 ID 來存取與修改版面投影片。或者，您也可以直接在簡報內編輯特定的版面投影片。

若要在 Aspose.Slides for Python 中使用投影片版面，您可以使用：

- Properties such as [layout_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/layout_slides/) 和 [masters](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/masters/) 位於 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別下
- Types 如 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterlayoutslidecollection/)、[LayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/)，以及 [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

To learn more about working with master slides, check out the [Manage PowerPoint Slide Masters in Python](/slides/zh-hant/python-net/slide-master/) article.

{{% /alert %}}

## **將投影片版面新增至簡報**

若要自訂投影片的外觀與結構，您可能需要在簡報中新增版面投影片。Aspose.Slides for Python 可讓您檢查特定版面是否已存在，必要時新增，並利用該版面插入投影片。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 取得 [MasterLayoutSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterlayoutslidecollection/)。
3. 檢查目標版面投影片是否已在集合中存在。若不存在，則新增所需的版面投影片。
4. 基於新建的版面投影片新增空白投影片。
5. 儲存簡報。

以下 Python 程式碼示範如何將版面投影片新增至 PowerPoint 簡報：

```python
import aspose.slides as slides

# 實例化 Presentation 類別以開啟簡報檔案。
with slides.Presentation("sample.pptx") as presentation:
    # 瀏覽版面投影片類型以選取版面投影片。
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # 簡報不包含所有版面類型的情況。
        # 簡報檔案僅包含 Blank 和 Custom 版面類型。
        # 但具有自訂類型的版面投影片可能具有可辨識的名稱，
        # 例如「Title」、「Title and Content」等，可用於版面投影片的選取。
        # 您也可以依賴一組占位形狀類型。
        # 例如，標題投影片應僅有 Title 占位元件類型，依此類推。
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # 使用新增的版面投影片插入空白投影片。
    presentation.slides.insert_empty_slide(0, layout_slide)

    # 將簡報儲存至磁碟。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **移除未使用的版面投影片**

Aspose.Slides 提供 [Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) 類別的 [remove_unused_layout_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) 方法，讓您刪除不需要且未使用的版面投影片。

以下 Python 程式碼示範如何從 PowerPoint 簡報中移除版面投影片：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **在投影片版面中新增占位元件**

Aspose.Slides 提供 [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/placeholder_manager/) 屬性，讓您可以在版面投影片中新增占位元件。

此管理器包含以下占位元件類型的相關方法：

| PowerPoint 占位元件 | [LayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutplaceholdermanager/) 方法 |
| ----------------------------------- | ------------------------------------------------------------ |
| ![內容](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![內容 (垂直)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![文字](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![文字 (垂直)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![圖片](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![圖表](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![表格](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![媒體](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![線上圖片](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

以下 Python 程式碼示範如何在 Blank 版面投影片中新增占位形狀：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 取得 Blank 版面投影片。
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # 取得版面投影片的占位元件管理器。
    placeholder_manager = layout.placeholder_manager

    # 為 Blank 版面投影片新增不同的占位元件。
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # 使用 Blank 版面新增新的投影片。
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![版面投影片上的占位元件](add_placeholders.png)

## **設定版面投影片的頁腳可見性**

在 PowerPoint 簡報中，頁腳元素（例如日期、投影片編號與自訂文字）可依版面決定顯示或隱藏。Aspose.Slides for Python 允許您控制這些頁腳占位元件的可見性。當您希望特定版面顯示頁腳資訊，而其他版面保持簡潔時，此功能相當有用。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引取得版面投影片參考。
3. 設定投影片頁腳占位元件為可見。
4. 設定投影片編號占位元件為可見。
5. 設定日期時間占位元件為可見。
6. 儲存簡報。

以下 Python 程式碼示範如何設定投影片頁腳的可見性及相關操作：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **設定子投影片的頁腳可見性**

在 PowerPoint 簡報中，頁腳元素（如日期、投影片編號與自訂文字）可在母片層級進行控制，以確保所有版面投影片的一致性。Aspose.Slides for Python 讓您能在母片上設定這些頁腳占位元件的可見性與內容，並將設定傳遞至所有子版面投影片。此做法可確保整份簡報的頁腳資訊保持一致。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
2. 依索引取得母片的參考。
3. 設定母片及所有子版面的頁腳占位元件為可見。
4. 設定母片及所有子版面的投影片編號占位元件為可見。
5. 設定母片及所有子版面的日期時間占位元件為可見。
6. 儲存簡報。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**母片與版面投影片有何不同？**

母片定義了整體主題與預設格式，而版面投影片則為不同類型的內容定義特定的占位元件排列。

**我可以將版面投影片從一個簡報複製到另一個嗎？**

是的，您可以從一個簡報的 [layout_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/layout_slides/) 集合中複製（clone）版面投影片，然後使用 `add_clone` 方法將其插入至另一個簡報。

**如果我刪除仍被投影片使用的版面投影片，會發生什麼事？**

如果您嘗試刪除仍被簡報中至少一張投影片參照的版面投影片，Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pptxeditexception/)。為避免此情況，請使用 [remove_unused_layout_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/)，它只會安全地移除未被使用的版面投影片。