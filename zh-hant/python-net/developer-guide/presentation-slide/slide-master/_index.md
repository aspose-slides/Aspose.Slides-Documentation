---
title: 在 Python 中管理簡報投影片母片
linktitle: 投影片母片
type: docs
weight: 80
url: /zh-hant/python-net/slide-master/
keywords:
- 投影片母片
- 母片投影片
- PPT 母片投影片
- 多個母片投影片
- 比較母片投影片
- 背景
- 占位元件
- 複製母片投影片
- 拷貝母片投影片
- 重製母片投影片
- 未使用的母片投影片
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: 在 Aspose.Slides for Python via .NET 中管理投影片母片：存取、編輯、複製、比較以及移除 PowerPoint 與 OpenDocument 簡報中的母片投影片。
---
## **概觀**

**投影片母片** 定義了一組投影片的共用設計設定。它可以包含共用圖形、標誌、背景、文字樣式、佈景主題設定與頁尾設定。在 PowerPoint 中，編輯投影片母片是保持簡報一致性的常用方式，而不需要在每張投影片上重複相同的格式設定。

Aspose.Slides for Python via .NET 支援相同的模型。一個簡報可以包含一個或多個母片，而每個母片可以包含多個版面投影片。一般投影片通常不會直接參考母片。相反地，一般投影片會使用版面投影片，而該版面投影片屬於某個母片。

層級結構為：

1. **投影片母片** ─ 定義共用的設計與佈景主題。  
1. **版面投影片** ─ 定義特定的占位元件排列與版面層級格式。  
1. **一般投影片** ─ 包含實際的簡報內容，並使用一個版面投影片。

![母片、版面配置投影片與一般投影片的層級關係](slide-master_2.jpg)

在 Aspose.Slides 中，投影片母片由 [MasterSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslide/) 類別表示。簡報中所有的母片可透過 `Presentation.masters` 集合取得。

{{% alert color="info" title="Inheritance" %}}
當同一屬性在多個層級中都有定義時，以較具體的層級為準。例如，若母片與版面投影片同時定義了背景，則基於該版面的投影片會使用版面的背景。想了解版面投影片的更多資訊，請參閱 [Apply or Change Slide Layouts](/slides/zh-hant/python-net/slide-layout/)。
{{% /alert %}}

## **存取投影片母片**

在 PowerPoint 中，您可以從 **View** > **Slide Master** 開啟投影片母片檢視。

![PowerPoint 內「檢視」索引標籤上的投影片母片指令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `masters` 集合來存取母片：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

您也可以透過一般投影片的版面取得其所使用的母片：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **投影片母片的內容**

母片是一種類似投影片的物件。它從 [BaseSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/) 類別繼承共用投影片行為，因此提供了許多與一般投影片和版面投影片相同的屬性。母片專屬的成員列於 [MasterSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslide/) API 文件。

常用的母片成員包括：

| 成員 | 用途 |
| --- | --- |
| `background` | 設定母片層級的投影片背景。 |
| `shapes` | 儲存放置於母片上的圖形，例如標誌、圖片框與共用文字。 |
| `layout_slides` | 儲存屬於此母片的版面投影片。 |
| `theme_manager` | 取得母片佈景主題 API。 |
| `header_footer_manager` | 控制母片及其子版面的頁首、頁尾、日期與投影片編號。 |
| `get_depending_slides` | 取得依賴於此母片（透過版面）的一般投影片。 |

## **在投影片母片中加入影像**

將影像加入母片後，使用該母片版面的投影片皆會顯示該影像。這對於標誌、浮水印、裝飾條帶等重複出現的視覺元素非常有用。

以下範例在第一個母片加入標誌：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

欲了解圖片框的更多資訊，請參閱 [Picture Frame](/slides/zh-hant/python-net/picture-frame/)。

## **控制母片圖形的可見性**

使用 [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/show_master_shapes/) 可在不刪除母片圖形的情況下隱藏繼承自母片的圖形（如標誌或裝飾形狀）。在需要省略這些圖形的投影片上將 [Slide.show_master_shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/show_master_shapes/) 設為 `False`，在需要顯示的投影片則保留 `True`。

以下自包含範例在母片上建立藍色裝飾條，並在兩張使用相同空白版面的投影片中分別顯示與隱藏該條帶。此範例不需要輸入簡報或影像。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

此範例使用新簡報所提供的 **Blank** 版面，並移除初始投影片的占位元件。

### **設定的適用範圍**

一般投影片透過 [Slide.layout_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/layout_slide/) 以及 [LayoutSlide.master_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/master_slide/) 取得其母片。將屬性設定在單一投影片上只會影響該投影片本身。將 [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/layoutslide/show_master_shapes/) 設為 `False`，會對使用該共享版面的所有投影片隱藏母片圖形，即使它們各自的設定為 `True`。若只想在單一投影片上隱藏圖形，請變更該投影片的屬性，並保留共享版面不變。

此屬性在母片本身上不支援作為可見性控制。對母片而言永遠回傳 `False`，若指定 `True` 會拋出例外。請將其套用於一般投影片或版面。

### **將圖形與背景區分**

| 操作 | 效果 |
| --- | --- |
| 隱藏母片圖形 | 在不刪除或更改投影片自有圖形的情況下控制繼承自母片的圖形可見性。 |
| 變更投影片背景填充 | 變更背景顏色、漸層或影像。母片圖形是獨立的形狀，可在該背景之上保持可見。請參閱 [Presentation Background](/slides/zh-hant/python-net/presentation-background/)。 |
| 從母片刪除圖形 | 移除共享來源圖形，則使用該母片的任何投影片將不再擁有此圖形。 |

## **使用占位元件**

占位元件通常定義於版面投影片上。母片提供共享的樣式與佈景主題，而每個版面決定哪些占位元件可用以及它們的放置位置。

在 PowerPoint 中，占位元件指令可於投影片母片檢視中使用。

![PowerPoint 投影片母片檢視中的「插入占位元件」指令](slide-master_5.png)

若要使用 Aspose.Slides 新增占位元件，請對屬於母片的版面投影片進行操作：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

您也可以格式化已存在於母片上的占位元件形狀。以下範例尋找標題占位元件並套用線性漸層填充：

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![已格式化的標題占位元件，會被一般投影片繼承](slide-master_8.png)

欲了解更多占位元件與文字格式化選項，請參閱 [Set Prompt Text in Placeholder](/slides/zh-hant/python-net/manage-placeholder/) 與 [Text Formatting](/slides/zh-hant/python-net/text-formatting/)。

## **變更投影片母片背景**

母片背景會被版面與未覆寫背景的投影片繼承。以下範例為第一個母片設定純色背景：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

相關主題請參閱 [Presentation Background](/slides/zh-hant/python-net/presentation-background/) 與 [Presentation Theme](/slides/zh-hant/python-net/presentation-theme/)。

## **將投影片母片克隆至其他簡報**

使用 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/) 類別的 `add_clone` 方法，可將母片複製到另一個簡報。複製後的母片即可被目標簡報的版面與投影片使用。

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

若需要同時克隆一般投影片及其母片，請參閱 [Clone Slides](/slides/zh-hant/python-net/clone-slides/)。

## **加入多個投影片母片**

一個簡報可以包含多個母片。這在不同章節需要不同品牌、頁面結構或佈景設定時非常有用。

![PowerPoint 插入與管理母片的指令](slide-master_9.jpg)

以下範例克隆預設母片、為克隆後的母片設定不同背景、取得該母片下的空白版面，並基於該版面新增投影片：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **比較投影片母片**

母片可使用繼承自 [BaseSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/) 類別的 `equals` 方法進行比較。比較會檢查結構與靜態內容（如圖形、文字、格式、動畫與其他投影片設定），但不會比較唯一識別碼（例如投影片 ID）或動態占位元件值（例如當前日期）。

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

欲取得更多資訊，請參閱 [Compare Presentation Slides](/slides/zh-hant/python-net/compare-slides/)。

## **將投影片母片檢視設為預設檢視**

使用簡報 [ViewProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/) 的 `last_view` 屬性，可控制 PowerPoint 首次開啟的檢視。以下範例在投影片母片檢視中開啟簡報：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

欲了解更多檢視設定，請參閱 [Save Presentation](/slides/zh-hant/python-net/save-presentation/)。

## **移除未使用的投影片母片**

簡報有時會包含不再被任何一般投影片使用的母片。移除未使用的母片可減少檔案大小並簡化範本維護。

使用 `remove_unused` 可從 `masters` 集合中移除未使用的母片：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

您也可以使用 low‑code 的 `remove_unused_master_slides` 方法，來自 [Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) 類別：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題集**

**投影片母片與版面投影片有何不同？**

投影片母片定義共用的設計設定，例如佈景、背景、共用圖形與文字樣式。版面投影片屬於某個母片，負責定義占位元件的具體排列方式。一般投影片使用版面投影片，因而同時繼承版面與母片的設定。

**一個簡報可以包含多個投影片母片嗎？**

可以。簡報可以包含多個投影片母片。當不同章節需要不同的視覺系統或品牌時，請使用多個母片。

**應該在母片還是版面投影片上加入占位元件？**

大多數情況下，應在版面投影片上加入占位元件。將共享的視覺元素與共享格式放在母片上，然後在版面投影片上放置內容占位元件，供一般投影片使用。

**我可以刪除仍被使用的投影片母片嗎？**

不能。仍有依賴投影片的母片無法安全直接刪除。請先將這些投影片移至其他母片的版面，或使用僅移除未使用母片的清理方法。