---
title: 在 Python 中管理簡報佔位元
linktitle: 管理佔位元
type: docs
weight: 10
url: /zh-hant/python-java/manage-placeholder/
keywords:
- 佔位元
- 文字佔位元
- 圖片佔位元
- 圖表佔位元
- 內容佔位元
- 提示文字
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何檢查與編輯文字、圖片、圖表與內容佔位元，並透過 Aspose.Slides for Python via Java 了解佔位元的繼承關係。"
---
## **概述**

佔位元是一種形狀，用於在簡報範本中保留特定類型內容的位置。常見的例子包括標題、內文、圖片、圖表以及通用內容佔位元。與普通形狀不同，佔位元可以從版面投影片或母片繼承其位置、大小、格式與其他設定。

Aspose.Slides 透過 [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) 方法公開佔位元資訊。該方法會傳回 [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) 物件，若為普通形狀則傳回 `None`。使用 [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) 可判斷佔位元預期要容納的內容。

即使已知道佔位元類型，形狀類型仍然很重要：

- 空的文字、圖片、圖表或內容佔位元通常以 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 來表示。
- 已填入圖片的佔位元可以以 [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) 來表示。
- 已填入圖表的佔位元可以以 [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) 來表示。
- 內容佔位元可以包含多種內容。請同時檢查 [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) 以及執行時的形狀類型，而不要假設每個佔位元都是 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) 描述佔位元的角色；它並不保證形狀的執行時類型。存取文字、圖片、圖表、表格或媒體相關成員之前，請務必先進行類型檢查。
{{% /alert %}}

## **了解佔位元繼承**

佔位元形成層級結構：

1. 母片定義可重複使用的樣式，且在某些情況下提供母片層級的佔位元。
2. 版面投影片定義供一個或多個普通投影片使用的版面配置，並可從母片繼承。
3. 普通投影片包含該投影片的佔位元，且可從其版面繼承。

呼叫 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) 可在此層級向上移動一層。投影片佔位元通常會傳回其版面佔位元；版面佔位元則可傳回其母片佔位元。若形狀沒有基礎佔位元，該方法會傳回 `None`。

以下範例列出第一張投影片上的佔位元，並回報其基礎佔位元：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

在普通投影片上編輯佔位元會為該投影片建立或變更本機覆寫。編輯相關的版面或母片則可能影響仍然繼承該設定的所有投影片。本機普通形狀沒有基礎佔位元，也不會僅因佔用相同座標而開始繼承。

## **移除佔位元狀態**

在調整範本時，使用 [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) 可將現有物件保留為普通形狀。其 [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) 方法會傳回 `None`，但形狀仍保留在投影片的集合中。相較之下， [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) 會從該集合中刪除形狀。

以下範例需要一個包含至少一張投影片且第一張投影片上有非空文字佔位元的 `template.pptx`。使用從版面或母片繼承格式的佔位元，以觀察移除關聯的效果。範例會檢查相同形狀仍在，然後再次在已變為普通形狀的物件上呼叫該方法，最後儲存結果。

{{% alert color="warning" title="Warning" %}}
移除佔位元狀態不會自動保留繼承的外觀設定。下列範例刻意保留這些設定不變，因而輸出可能看起來不同。完全繼承位置與大小的形狀在呼叫後可能會變成座標與尺寸皆為零，導致即使仍在集合中也會變成不可見。
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # 在普通形狀上呼叫此方法不會產生任何效果。
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

對於匹配的佔位元，三項檢查皆會列印 `True`。文字仍保留，但若移除佔位元關聯，繼承的位置、大小、旋轉、字型、段落對齊、文字框邊距、垂直錨點、填充與線條設定都可能改變。例如，繼承的標題格式可能會退回普通文字格式。更多版面資訊請參閱 [Slide Layout](/slides/zh-hant/python-java/slide-layout/)。

若要保留預期的外觀，請在呼叫之前取得解析後的位置、大小與旋轉，並將必要的有效格式值複製到獨立變數。可透過 [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective)、[ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective)、[TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective)、[FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) 以及 [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) 取得這些值。不要僅依賴有效格式物件，因為在移除關聯後其文字格式值可能會改變。之後請明確將捕獲的值套用到普通形狀，包括字型族、大小、樣式、顏色、段落設定、文字框設定、填充與線條。

繼承的形狀幾何也可能需要透過 [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType) 明確指派。對於矩形文字佔位元，這意味著指派 [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle)；僅恢復填充與線條可能無法恢復可見的矩形。具有額外效果或更複雜格式的範本亦需要同樣處理這些設定。

## **變更佔位元中的文字**

標題、置中標題、副標題、內文與文字佔位元通常支援文字。使用前請先確認是否為 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)，再使用其 [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) 方法。

以下範例會更新第一張投影片上的第一個標題佔位元，並儲存結果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此模式避免將圖片、圖表、表格或媒體佔位元誤當作 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 處理，也會依照用途辨識佔位元，而非依賴脆弱的形狀索引。

## **在版面上設定提示文字**

提示文字是設計時顯示於空佔位元中的指示，例如 *Click to add title*。請在版面佔位元上設定自訂提示文字，而不是嘗試透過普通投影片的形狀集合取得。可透過 [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) 取得版面，並遍歷 [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) 回傳的集合。

以下範例會變更第一張投影片使用的版面上標題與副標題的提示文字：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

提示文字並非普通投影片內容。它僅供 PowerPoint 等編輯應用程式在空佔位元中顯示。使用者或程式提供實際內容後，提示文字即不再顯示。變更提示文字也不會取代使用該版面的投影片上已存在的文字。

## **更新圖片佔位元**

有兩種情況需要處理：

- 若圖片佔位元已被填入，且以 [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) 表示，請透過 [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) 與 [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) 取代圖片。
- 若仍是空的佔位元，請使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) 在佔位元座標處加入圖片框，並移除空的佔位元。

以下範例同時支援上述兩種情況，並儲存簡報：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

對空佔位元所建立的取代項是一個本機圖片框，而非新佔位元，因為 [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) 沒有提供設定子。它保留保留位置，但不再繼承佔位元特有的行為。如果必須保留佔位元關聯，請先在 PowerPoint 中建立並填入佔位元，然後再使用 Aspose.Slides 更新產生的 [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/)。

有關圖片透明度、裁剪與其他圖片專屬效果，請參閱 [Manage Picture Frames](/slides/zh-hant/python-java/picture-frame/)。這些操作屬於圖片框或圖片填充，而非佔位元中繼資料。

## **處理圖表與內容佔位元**

已填入的圖表佔位元可以以 [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) 來表示。以下範例同時依佔位元類型與執行時類型尋找圖表，變更其標題，並儲存檔案：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

一般內容佔位元通常具有 [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object)。在 PowerPoint 中，它充當多種內容類型的啟動器，包括圖表、表格、圖示、圖片與媒體。填入後，請檢查實際的形狀類型以了解其包含的內容。特定版面亦可能暴露 [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart)、[PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table)、[PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture)、[PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) 或 [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram)。

Aspose.Slides 並不會僅透過變更 [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) 就將空的 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 佔位元轉換為 [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/)；API 無法變更類型。若要以程式方式填入空的圖表或內容區域，請在佔位元座標處加入所需物件，然後移除空的佔位元。以下範例針對圖表執行此操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

新增的圖表是一個普通本機圖表。它佔據佔位元的區域，但不會繼承版面佔位元的設定。若需取代其類別、資料系列或工作簿資料，請參閱專門的 [chart management articles](/slides/zh-hant/python-java/powerpoint-charts/)。

## **完整範例：更新文字或圖片內容**

以下端到端範例會開啟一個範本，搜尋第一張投影片上的標題或圖片佔位元，檢查佔位元與形狀類型，更新相應的內容，最後儲存輸出。此範例特意避免假設形狀索引或將每個佔位元視為相同類型。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **常見問與答**

**什麼是基礎佔位元？**

基礎佔位元是指在版面或母片上對應的形狀，其他佔位元會從它繼承。使用 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) 取得它。普通本機形狀會傳回 `None`，因為它不屬於佔位元層級。

**我可以透過編輯版面佔位元來變更所有投影片的標題嗎？**

您可以透過版面變更繼承的格式或提示文字，但實際的標題內容儲存在普通投影片上。若要在整個簡報中取代實際的標題文字，請遍歷投影片並更新每個標題佔位元。

**我該如何管理日期、投影片編號、頁首與頁腳佔位元？**

請在相應的投影片、版面、母片、備註或講義範圍使用頁首與頁腳管理器。詳情請參閱 [Manage Presentation Header and Footer](/slides/zh-hant/python-java/presentation-header-and-footer/)。