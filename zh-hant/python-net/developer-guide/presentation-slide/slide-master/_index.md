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
- 佔位元
- 複製母片投影片
- 拷貝母片投影片
- 重製母片投影片
- 未使用的母片投影片
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中管理投影片母片：存取、編輯、複製、比較及移除 PowerPoint 與 OpenDocument 簡報中的母片投影片。"
---
## **概覽**

一個 **slide master** 定義了一組投影片的共享設計設定。它可以包含共同的圖形、商標、背景、文字樣式、主題設定與頁尾設定。在 PowerPoint 中，編輯投影片母片是保持簡報一致性的常用方式，而不必在每張投影片上重複相同的格式設定。

Aspose.Slides for Python via .NET 支援相同的模型。簡報可以包含一個或多個母片，而每個母片可以包含多個版面投影片。普通投影片通常不會直接參考母片，而是使用版面投影片，而該版面投影片屬於某個母片。

層級結構如下：

1. **Slide master** - 定義共享的設計與主題。  
1. **Layout slide** - 定義佔位元與版面層級格式的具體排列。  
1. **Normal slide** - 包含實際的簡報內容，使用一個版面投影片。

![母片、版面投影片與一般投影片的層級結構](slide-master_2.jpg)

在 Aspose.Slides 中，投影片母片由 [MasterSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslide/) 類別表示。簡報中的所有母片可透過 `Presentation.masters` 集合取得。

{{% alert color="info" title="繼承" %}}

當同一屬性在多個層級中都有定義時，較具體的層級會取得優先權。例如，若母片與版面投影片同時定義背景，則基於該版面的投影片會使用版面的背景。欲瞭解更多版面投影片的資訊，請參閱 [套用或變更投影片版面](/python-net/slide-layout/)。

{{% /alert %}}

## **存取投影片母片**

在 PowerPoint 中，您可以從 **檢視** > **投影片母片** 開啟投影片母片檢視。

![PowerPoint 檢視分頁上的投影片母片指令](slide-master_3.jpg)

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

您也可以透過版面投影片取得普通投影片所使用的母片：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **投影片母片包含什麼**

母片是一種類似投影片的物件。它繼承自 [BaseSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/) 類別的通用投影片行為，因此會曝露許多與普通投影片和版面投影片相同的屬性。母片專屬的成員列於 [MasterSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslide/) API 頁面。

常用的母片成員包括：

| 成員 | 用途 |
| --- | --- |
| `background` | 設定母片層級的投影片背景。 |
| `shapes` | 儲存放置於母片上的圖形，例如商標、圖片框與共享文字。 |
| `layout_slides` | 儲存屬於該母片的版面投影片。 |
| `theme_manager` | 提供存取母片主題的 API。 |
| `header_footer_manager` | 控制母片及其子版面的頁首、頁尾、日期與投影片編號。 |
| `get_depending_slides` | 回傳依賴於該母片（透過其版面）的普通投影片。 |

## **將影像新增至投影片母片**

將影像加入母片後，使用該母片版面的投影片都會顯示此影像。這對於商標、浮水印、裝飾條紋等重複的視覺元素非常實用。

以下範例將商標加入第一個母片：

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

欲了解更多關於圖片框的資訊，請參閱 [圖片框](/python-net/picture-frame/)。

## **使用佔位元**

佔位元通常定義於版面投影片。母片提供共享的樣式與主題，版面則決定哪些佔位元可用以及它們的放置位置。

在 PowerPoint 中，佔位元指令可在投影片母片檢視中使用。

![PowerPoint 投影片母片檢視中的插入佔位元指令](slide-master_5.png)

若要使用 Aspose.Slides 新增佔位元，請對屬於母片的版面投影片進行操作：

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

您也可以格式化已存在於母片上的佔位元圖形。以下範例找到標題佔位元並套用線性漸層填色：

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![已格式化的標題佔位元，會被一般投影片繼承](slide-master_8.png)

欲取得更多佔位元與文字格式化選項，請參閱 [在佔位元中設定提示文字](/python-net/manage-placeholder/) 與 [文字格式設定](/python-net/text-formatting/)。

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

相關主題請參閱 [簡報背景](/python-net/presentation-background/) 與 [簡報主題](/python-net/presentation-theme/)。

## **將投影片母片複製至其他簡報**

使用 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masterslidecollection/) 類別的 `add_clone` 方法，可將母片複製到另一個簡報。複製後的母片即可供目的簡報的版面與投影片使用。

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

若需同時複製普通投影片及其母片，請參閱 [複製投影片](/python-net/clone-slides/)。

## **新增多個投影片母片**

簡報可以包含多個母片。當不同章節需要不同品牌、頁面結構或主題設定時，此功能非常有用。

![PowerPoint 插入與管理母片的指令](slide-master_9.jpg)

以下範例複製預設母片、為其設定不同的背景、取得該複製母片下的空白版面，並基於該版面新增投影片：

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

母片可以使用從 [BaseSlide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/) 繼承的 `equals` 方法進行比較。比較內容包括結構與靜態內容，如圖形、文字、格式、動畫與其他投影片設定。此比較不會比較唯一識別碼（例如投影片 ID）或動態佔位元值（例如當前日期）。

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

欲取得更多資訊，請參閱 [比較簡報投影片](/python-net/compare-slides/)。

## **將投影片母片檢視設為預設檢視**

在簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/viewproperties/) 上使用 `last_view` 屬性，可控制 PowerPoint 首次開啟時的檢視模式。以下範例於投影片母片檢視中開啟簡報：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

更多檢視設定請參閱 [儲存簡報](/python-net/save-presentation/)。

## **移除未使用的母片**

簡報有時會保留已不再被任何普通投影片使用的母片。移除未使用的母片可減少檔案大小並簡化範本維護。

使用 `remove_unused` 可從 `masters` 集合中移除未使用的母片：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

您也可以使用 [Compress](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.lowcode/compress/) 類別的低程式碼方法 `remove_unused_master_slides`：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**投影片母片與版面投影片有何差異？**

投影片母片定義了共享的設計設定，例如主題、背景、共同圖形與文字樣式。版面投影片屬於某個母片，定義了佔位元的具體排列。普通投影片使用版面投影片，因而同時繼承版面與母片的設定。

**一個簡報可以包含多個投影片母片嗎？**

可以。簡報可以包含多個母片，當不同章節需要不同的視覺系統或品牌識別時，可使用多個母片。

**應該在母片還是版面投影片上新增佔位元？**

大多數情況下，應在版面投影片上新增佔位元。將共享的視覺元素與格式放在母片上，將內容佔位元放在版面上，讓普通投影片使用這些版面即可。

**我可以刪除仍被使用的母片嗎？**

不能。仍有依賴投影片的母片無法直接安全刪除。請先將這些投影片移至其他母片的版面，或使用只能刪除未使用母片的清理方法。