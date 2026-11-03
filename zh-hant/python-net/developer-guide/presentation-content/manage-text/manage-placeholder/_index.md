---
title: 管理 Python 中的簡報佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/python-net/manage-placeholder/
keywords:
- 佔位符
- 文字佔位符
- 圖片佔位符
- 圖表佔位符
- 內容佔位符
- 提示文字
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何檢視與編輯文字、圖片、圖表與內容佔位符，並透過 Aspose.Slides for Python via .NET 了解佔位符的繼承關係。"
---
## **概述**

佔位符是一種形狀，用於在簡報範本中保留特定類型內容的位置。常見的例子包括標題、內文、圖片、圖表以及通用內容佔位符。與普通形狀不同，佔位符可以從版面投影片或母片繼承其位置、大小、格式設定及其他屬性。

Aspose.Slides 透過 [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) 屬性公開佔位符資訊。該屬性回傳一個 [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) 物件，對於普通形狀則回傳 `None`。使用 [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) 可判斷佔位符預計容納的內容類型。

在了解佔位符類型之後，形狀類別仍然很重要：

- 空的文字、圖片、圖表或內容佔位符通常以 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 表示。
- 已填入圖片的佔位符可以用 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 代表。
- 已填入圖表的佔位符可以用 [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) 代表。
- 內容佔位符可以包含多種內容。請同時檢查 [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) 以及執行時的形狀類別，而不要假設每個佔位符都是 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) 描述佔位符的角色；它並不保證形狀的執行時類別。存取文字、圖片、圖表、表格或多媒體相關成員前，務必先進行類型檢查。
{{% /alert %}}

## **了解佔位符繼承**

佔位符形成層級結構：

1. 母片投影片定義可重複使用的樣式，並在某些情況下提供母片層級的佔位符。
2. 版面投影片定義一或多張普通投影片使用的版面配置，且可以繼承自母片。
3. 普通投影片包含該投影片的佔位符，並可從其版面繼承。

呼叫 [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) 可向上移動一層。投影片佔位符通常回傳其版面佔位符；版面佔位符則可回傳其母片佔位符。若形狀沒有基礎佔位符，方法會回傳 `None`。

以下範例列出第一張投影片上的佔位符，並顯示其基礎佔位符：

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

在普通投影片上編輯佔位符會為該投影片建立或變更本機覆寫。編輯相關的版面或母片則可能影響仍繼承該設定的所有投影片。普通的本機形狀沒有基礎佔位符，僅因佔據相同座標並不會開始繼承。

## **移除佔位符狀態**

在調整範本時，使用 [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) 可將既有物件保留為普通形狀。它的 [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) 屬性會變為 `None`，但形狀仍存在於投影片集合中。相較之下，[ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) 會直接從集合中刪除形狀。

以下範例需要一個至少包含一張投影片且第一張投影片上有非空文字佔位符的 `template.pptx`。使用從版面或母片繼承格式的佔位符，可觀察移除關係的效果。範例會檢查相同形狀仍在，然後在該普通形狀上再次呼叫方法，最後儲存結果。

{{% alert color="warning" title="Warning" %}}
移除佔位符狀態不會自動保留繼承的外觀設定。下列範例刻意不變更這些設定，因而輸出可能與原本不同。若位置與大小完全繼承，呼叫後可能會得到座標與尺寸為零的形狀，導致即使仍在集合中也會變得不可見。
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # 在普通形狀上呼叫此方法不會產生任何效果。
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

對於相符的佔位符，三項檢查皆會印出 `True`。文字仍保留，但繼承的定位、大小、旋轉、字型、段落對齊、文字框邊距、垂直定位、填充與線條設定在移除佔位符關係後可能會改變。例如，繼承的標題格式可能回退為普通文字格式。請參考 [Slide Layout](/slides/zh-hant/python-net/slide-layout/) 瞭解更多版面資訊。

為了保留預期外觀，請在呼叫前取得解析後的位置、大小與旋轉，並將必要的有效格式值複製到單獨變數。可透過 [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/)、[ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/)、[TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/)、[FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/)、[LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) 取得這些值。不要僅依賴有效格式物件，因為在關係移除後其文字格式值可能會改變。之後請明確將捕獲的值套用到普通形狀，包括字型系列、大小、樣式、顏色、段落設定、文字框設定、填充與線條。

繼承的形狀幾何也可能需要透過 [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/) 明確指派。以矩形文字佔位符為例，需指派 [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)。僅還原填充與線條可能不足以恢復可見的矩形。含有其他效果或較複雜格式的範本亦需要相應處理。

## **變更佔位符中的文字**

標題、居中標題、副標題、內文與文字佔位符通常支援文字。使用前請先確認是 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)，再存取其 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) 屬性。

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

此模式避免將圖片、圖表、表格或多媒體佔位符誤當作 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 物件處理，同時以用途而非脆弱的形狀索引來識別佔位符。

## **在版面上設定提示文字**

提示文字是空佔位符在設計階段顯示的指示，例如 *Click to add title*。請在版面佔位符上設定自訂提示文字，而不是嘗試從普通投影片的形狀集合取得。可透過 [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) 取得版面，並遍歷其 [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/)。

以下範例變更第一張投影片使用之版面上的標題與副標題提示文字：

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

提示文字並非普通投影片內容。它僅供 PowerPoint 等編輯應用程式在空佔位符時顯示。一旦使用者或程式填入真實內容，提示文字即不再顯示。變更提示文字也不會取代已使用該版面的投影片上的既有文字。

## **更新圖片佔位符**

有兩種情況需要處理：

- 若圖片佔位符已被填入，且以 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 表示，請透過 [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) 與 [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) 替換影像。
- 若仍是空佔位符，請使用 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) 在佔位符座標處新增圖片框，並移除空佔位符。

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

對於空佔位符所建立的取代品是一個本機圖片框，而非新佔位符，因為 [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) 為唯讀。它保留保留位置，但不再繼承佔位符特有的行為。若必須保留佔位符關係，請先在 PowerPoint 中準備並填入佔位符，然後再以 Aspose.Slides 更新產生的 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)。

有關影像透明度、裁剪及其他圖片特效，請參閱 [Manage Picture Frames](/slides/zh-hant/python-net/picture-frame/)。這些操作屬於圖片框或圖片填充，而非佔位符的中介資料。

## **操作圖表與內容佔位符**

已填入的圖表佔位符可以以 [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) 表示。以下範例同時依佔位符類型與執行時類別尋找此圖表，變更其標題，並儲存檔案：

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

一般內容佔位符通常具有 [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)。在 PowerPoint 中，它充當多種內容類型（如圖表、表格、圖示、圖片與多媒體）的啟動器。填入後，請檢查實際的形狀類別以了解其包含的內容。特定版面亦可能暴露 [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)。

Aspose.Slides 不會僅透過變更 [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/)（此屬性為唯讀）就把空的 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 佔位符轉換為 [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)。若要以程式方式填入空的圖表或內容區域，請在佔位符座標處加入所需物件，然後移除空佔位符。以下範例示範如何為圖表執行此操作：

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

新增的圖表是一個普通的本機圖表。它佔據佔位符的區域，但不會從版面佔位符繼承。若需取代圖表的類別、系列或工作簿資料，請參考專門的 [chart management articles](/slides/zh-hant/python-net/powerpoint-charts/)。

## **完整範例：更新文字或圖片內容**

以下端對端範例開啟一個範本，於第一張投影片上搜尋標題或圖片佔位符，檢查佔位符與形狀類型，更新相應內容，最後儲存輸出。此範例刻意避免假設形狀索引或將每個佔位符視為相同的形狀類別。

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

## **FAQ**

**什麼是基礎佔位符？**

基礎佔位符是版面或母片上與之對應的形狀，其他佔位符會從它繼承。使用 [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) 可取得它。普通的本機形狀會回傳 `None`，因為它不屬於佔位符層級。

**我能否透過編輯版面佔位符一次變更所有投影片的標題？**

您可以透過版面變更繼承的格式或提示文字，但現有的標題內容儲存在普通投影片上。若要取代整個簡報的實際標題文字，需遍歷投影片並更新每個標題佔位符。

**如何管理日期、投影片編號、頁眉與頁腳佔位符？**

請使用對應投影片、版面、母片、備註或講義範圍的頁眉與頁腳管理器。詳情請參閱 [Manage Presentation Header and Footer](/slides/zh-hant/python-net/presentation-header-and-footer/) 中的完整範例。