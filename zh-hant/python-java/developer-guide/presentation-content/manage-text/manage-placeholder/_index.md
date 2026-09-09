---
title: 在 Python 中管理簡報佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/python-java/manage-placeholder/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 來檢視與編輯文字、圖片、圖表與內容佔位符，並瞭解佔位符的繼承關係。"
---
## **概述**

佔位符是一種形狀，用於在簡報範本中保留特定類型內容的位置。常見的例子有標題、內文、圖片、圖表以及通用內容佔位符。與普通形狀不同，佔位符可以從版面投影片或母片繼承其位置、大小、格式以及其他設定。

Aspose.Slides 透過 [Shape.getPlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getPlaceholder) 方法公開佔位符資訊。該方法會回傳一個 [Placeholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/placeholder/) 物件，若為普通形狀則回傳 `None`。使用 [Placeholder.getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/placeholder/#getType) 可以判斷佔位符預期容納的內容類型。

取得佔位符類型後，形狀類型仍然重要：

- 空的文字、圖片、圖表或內容佔位符通常以 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 表示。
- 已填入圖片的佔位符可以以 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/) 表示。
- 已填入圖表的佔位符可以以 [Chart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/) 表示。
- 內容佔位符可以包含多種內容。請同時檢查 [Placeholder.getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/placeholder/#getType) 以及執行時的形狀類型，而不要假設每個佔位符都是 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/)。

{{% alert color="warning" title="警告" %}}
[Placeholder.getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/placeholder/#getType) 只描述佔位符的角色；它不保證形狀的執行時類型。存取文字、圖片、圖表、表格或媒體相關成員前，務必先進行類型檢查。
{{% /alert %}}

## **了解佔位符繼承**

佔位符形成層級結構：

1. 母片定義可重複使用的樣式，且在某些情況下定義母片層級的佔位符。
2. 版面投影片定義供一或多張普通投影片使用的排列，且可從母片繼承。
3. 普通投影片包含該投影片的佔位符，並可從其版面繼承。

呼叫 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getBasePlaceholder) 可向上移一層。投影片佔位符通常會回傳其版面佔位符；版面佔位符則可以回傳其母片佔位符。若形狀沒有基礎佔位符，方法會回傳 `None`。

以下範例列出第一張投影片的佔位符，並報告其基礎佔位符：

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

在普通投影片上編輯佔位符會為該投影片建立或變更本機覆寫。編輯相關的版面或母片則可能影響仍繼承該設定的所有投影片。普通形狀本身沒有基礎佔位符，即使佔用相同座標也不會自動開始繼承。

## **變更佔位符中的文字**

標題、置中標題、副標題、內文與文字佔位符通常支援文字。使用前請先檢查是否為 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/)，再呼叫其 [getTextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/#getTextFrame) 方法。

以下範例更新第一張投影片的第一個標題佔位符，並儲存結果：

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

此模式避免將圖片、圖表、表格或媒體佔位符當作 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 處理。它也根據用途識別佔位符，而非依賴脆弱的形狀索引。

## **在版面上設定提示文字**

提示文字是空佔位符中顯示的設計時指示，例如 *點擊以新增標題*。請在版面佔位符上設定自訂提示文字，而不是嘗試透過普通投影片的形狀集合取得。可透過 [Slide.getLayoutSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getLayoutSlide) 取得版面，並遍歷 [BaseSlide.getShapes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseslide/#getShapes) 回傳的集合。

以下範例變更第一張投影片所使用版面的標題與副標題提示文字：

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

提示文字不是普通投影片內容。它僅供 PowerPoint 等編輯應用程式在空佔位符中顯示。使用者或程式提供實際內容後，提示文字即不再顯示。變更提示文字也不會取代已使用該版面的投影片上的現有文字。

## **更新圖片佔位符**

需處理兩種情況：

- 若圖片佔位符已被填入，且以 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/) 表示，請透過 [PictureFillFormat.getPicture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#getPicture) 以及 [Picture.setImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picture/#setImage) 取代圖片。
- 若仍是空佔位符，請使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addPictureFrame) 在佔位符座標新增圖片框，並移除空佔位符。

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

對空佔位符所建立的取代物是一個本機圖片框，而非新佔位符，因為 [Shape.getPlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getPlaceholder) 沒有提供 setter。它保留了保留位置，但不再繼承佔位符特定行為。如果必須保留佔位符關係，請先在 PowerPoint 中準備並填入佔位符，然後使用 Aspose.Slides 更新產生的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/)。

關於圖像透明度、裁切及其他圖片專屬效果，請參閱 [管理圖片框](/slides/zh-hant/python-java/picture-frame/)。這些操作屬於圖片框或圖片填充，而非佔位符中繼資料。

## **使用圖表與內容佔位符**

已填入的圖表佔位符可以以 [Chart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/) 表示。以下範例同時依佔位符類型與執行時類型尋找此圖表，變更其標題，並儲存檔案：

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

一般內容佔位符通常具有 [PlaceholderType.Object](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/placeholdertype/#Object)。在 PowerPoint 中，它充當多種內容類型（包括圖表、表格、圖示、圖片與媒體）的啟動器。填入後，請檢查實際形狀類型以了解其內容。特定版面也可能暴露 [PlaceholderType.Chart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/placeholdertype/#Chart)、[PlaceholderType.Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/placeholdertype/#Table)、[PlaceholderType.Picture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/placeholdertype/#Picture)、[PlaceholderType.Media](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/placeholdertype/#Media) 或 [PlaceholderType.Diagram](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/placeholdertype/#Diagram)。

Aspose.Slides 不會僅透過變更 [Placeholder.getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/placeholder/#getType) 就將空的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 佔位符轉換為 [Chart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/)；類型無法透過 API 變更。若要以程式方式填寫空的圖表或內容區域，請在佔位符座標新增所需物件，然後移除空佔位符。以下範例示範如何為圖表執行此操作：

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

新增的圖表是一個普通本機圖表。它佔據佔位符的區域，但不會繼承自版面佔位符。若需取代其類別、系列或工作簿資料，請參考專門的 [圖表管理文章](/slides/zh-hant/python-java/powerpoint-charts/)。

## **完整範例：更新文字或圖片內容**

以下端對端範例開啟範本，於第一張投影片搜尋標題或圖片佔位符，檢查佔位符與形狀類型，更新相應內容，並儲存輸出。此範例刻意避免假設形狀索引或把每個佔位符都視為相同類型。

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

## **常見問題**

**什麼是基礎佔位符？**

基礎佔位符是版面或母片上對應的形狀，其他佔位符會從它繼承。使用 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getBasePlaceholder) 取得。普通本機形狀會回傳 `None`，因為它不屬於佔位符層級。

**我可以透過編輯版面佔位符一次變更所有投影片的標題嗎？**

您可以透過版面變更繼承的格式或提示文字，但現有的標題內容儲存在普通投影片上。若要在整份簡報中取代實際的標題文字，必須遍歷投影片並更新每個標題佔位符。

**如何管理日期、投影片編號、頁首與頁尾佔位符？**

請在相應的投影片、版面、母片、備註或講義範圍使用頁首與頁尾管理員。完整範例請參閱 [管理簡報頁首與頁尾](/slides/zh-hant/python-java/presentation-header-and-footer/)。