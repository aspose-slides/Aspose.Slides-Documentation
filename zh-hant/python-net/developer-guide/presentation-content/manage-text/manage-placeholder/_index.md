---
title: 在 Python 中管理簡報佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/python-net/manage-placeholder/
keywords:
- 佔位符
- 文字佔位符
- 影像佔位符
- 圖表佔位符
- 內容佔位符
- 提示文字
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET，檢查與編輯文字、圖片、圖表與內容佔位符，並了解佔位符的繼承關係。"
---
## **概觀**

佔位符是一種形狀，用於在簡報範本中保留特定類型內容的位置。常見的例子包括標題、內文、圖片、圖表和一般用途的內容佔位符。與普通形狀不同，佔位符可以從版面投影片或母片繼承其位置、大小、格式設定及其他設定。

Aspose.Slides 透過 [Shape.placeholder](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/placeholder/) 屬性公開佔位符資訊。此屬性會回傳一個 [Placeholder](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/placeholder/) 物件，對於一般形狀則回傳 `None`。使用 [Placeholder.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/placeholder/type/) 可判斷佔位符預計容納何種內容。

取得佔位符類型後，形狀類別仍然很重要：

- 空的文字、圖片、圖表或內容佔位符通常以 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 表示。
- 已填入圖片的佔位符可以以 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 表示。
- 已填入圖表的佔位符可以以 [Chart](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/) 表示。
- 內容佔位符可以包含多種內容。請同時檢查 [Placeholder.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/placeholder/type/) 以及執行時的形狀類別，而不要假設每個佔位符都是 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。

{{% alert color="warning" title="Warning" %}}
[Placeholder.type] 描述佔位符的角色；它並不保證形狀的執行時類別。存取文字、圖片、圖表、表格或媒體相關成員之前，請始終先進行類型檢查。
{{% /alert %}}

## **了解佔位符繼承**

佔位符形成層級結構：

1. 母片定義可重複使用的樣式，並在某些情況下定義母片層級的佔位符。
2. 版面投影片定義一或多個普通投影片使用的版面配置，且可從母片繼承。
3. 普通投影片包含該投影片的佔位符，且可從其版面繼承。

呼叫 [Shape.get_base_placeholder](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_base_placeholder/) 可在此層級中向上一層。投影片佔位符通常會回傳其版面佔位符；版面佔位符則可回傳其母片佔位符。若形狀沒有基礎佔位符，該方法會回傳 `None`。

以下範例列出第一張投影片上的佔位符，並報告其基礎佔位符：

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

編輯普通投影片上的佔位符會為該投影片建立或變更本機覆寫。編輯相關的版面或母片則可能影響仍然繼承該設定的所有投影片。本機普通形狀沒有基礎佔位符，也不會僅因佔據相同座標而開始繼承。

## **變更佔位符中的文字**

標題、置中標題、副標題、內文與文字佔位符通常支援文字。使用前請先檢查是否為 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)，再使用其 [text_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/text_frame/) 屬性。

以下範例更新第一張投影片上的第一個標題佔位符，並儲存結果：

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

此模式避免將圖片、圖表、表格或媒體佔位符視為 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 物件。它也以用途辨識佔位符，而不是依賴脆弱的形狀索引。

## **在版面上設定提示文字**

提示文字是設計時顯示在空佔位符中的指示，例如 *Click to add title*。請在版面佔位符上設定自訂提示文字，而不是透過普通投影片的形狀集合取得。可透過 [Slide.layout_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/layout_slide/) 取得版面，並遍歷 [LayoutSlide.shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/shapes/)。

以下範例變更第一張投影片所使用版面的標題與副標題提示文字：

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

提示文字不是普通投影片內容。它僅供 PowerPoint 等編輯應用程式在空佔位符中顯示指示。當使用者或程式提供實際內容時，提示文字將不再顯示。變更提示文字也不會取代使用該版面的投影片上已存在的文字。

## **更新圖片佔位符**

有兩種情況需要處理：

- 若圖片佔位符已填入且以 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/) 表示，請透過 [PictureFillFormat.picture](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picturefillformat/picture/) 與 [Picture.image](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/picture/image/) 替換影像。
- 若仍是空的佔位符，請使用 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_picture_frame/) 在佔位符座標新增圖片框，並移除空佔位符。

以下範例同時支援兩種情況，並儲存簡報：

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

對於空佔位符所建立的取代物是一個本機圖片框，而非新佔位符，因為 [Shape.placeholder](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/placeholder/) 為唯讀。它保留了保留位置，但不再繼承佔位符特定行為。如果必須保留佔位符關係，請先在 PowerPoint 中準備並填入佔位符，然後再使用 Aspose.Slides 更新產生的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/pictureframe/)。

欲了解影像透明度、裁切及其他圖片專屬效果，請參閱 [Manage Picture Frames](/slides/zh-hant/python-net/picture-frame/)。這些操作屬於圖片框或圖片填充，並非佔位符的中繼資料。

## **使用圖表與內容佔位符**

已填入的圖表佔位符可以以 [Chart](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/) 表示。以下範例同時以佔位符類型與執行時類別找出此圖表，變更其標題，並儲存檔案：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

一般內容佔位符通常具有 [PlaceholderType.OBJECT](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/placeholdertype/)。在 PowerPoint 中，它可作為多種內容類型的啟動器，包括圖表、表格、圖示、圖片與媒體。填入後，請檢查實際的形狀類別以了解其內容。特殊版面也可能暴露 [PlaceholderType.CHART](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.TABLE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.PICTURE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.MEDIA](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/placeholdertype/)、或 [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/placeholdertype/)。

Aspose.Slides 不會僅透過變更 [Placeholder.type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/placeholder/type/)（此屬性為唯讀）就將空的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 佔位符轉換為 [Chart](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/)。若要以程式方式填充空的圖表或內容區域，請在佔位符座標加入所需物件，然後移除空佔位符。以下範例示範如何為圖表執行此操作：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

新增的圖表是一個普通的本機圖表。它佔據佔位符的區域，但不會繼承自版面佔位符。當需要取代其類別、系列或工作簿資料時，請使用專門的 [chart management articles](/slides/zh-hant/python-net/powerpoint-charts/)。

## **完整範例：更新文字或影像內容**

以下端對端範例開啟範本，搜尋第一張投影片的標題或圖片佔位符，檢查佔位符與形狀類型，更新相應內容，並儲存輸出。此範例刻意避免假設形狀索引或將每個佔位符視為相同的形狀類別。

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**What is a base placeholder?**

基礎佔位符是版面或母片上相對應的形狀，其他佔位符會從它繼承。使用 [Shape.get_base_placeholder](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_base_placeholder/) 取得它。普通本機形狀會回傳 `None`，因為它不屬於佔位符層級。

**Can I change all slide titles by editing a layout placeholder?**

您可以透過版面變更繼承的格式或提示文字，但實際的標題內容儲存在普通投影片上。若要在整個簡報中取代真正的標題文字，必須遍歷投影片並更新每個標題佔位符。

**How do I manage date, slide-number, header, and footer placeholders?**

請在相應的投影片、版面、母片、備註或講義範圍使用標題與頁腳管理員。參閱 [Manage Presentation Header and Footer](/slides/zh-hant/python-net/presentation-header-and-footer/) 以取得完整範例。