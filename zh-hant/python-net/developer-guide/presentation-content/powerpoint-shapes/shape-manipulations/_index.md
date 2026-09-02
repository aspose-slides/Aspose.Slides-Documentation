---
title: 在 Python 中管理簡報圖形
linktitle: 圖形操作
type: docs
weight: 40
url: /zh-hant/python-net/shape-manipulations/
keywords:
- PowerPoint 圖形
- 簡報圖形
- 投影片上的圖形
- 尋找圖形
- 複製圖形
- 移除圖形
- 隱藏圖形
- 變更圖形順序
- 取得 interop 圖形 ID
- 圖形替代文字
- 圖形版面格式
- 圖形為 SVG
- 圖形轉 SVG
- 對齊圖形
- 翻轉圖形
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 識別、複製、移除、隱藏、重新排序、匯出、對齊與翻轉簡報圖形。"
---
## **概述**

Aspose.Slides for Python via .NET 以有序的 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/) 來表示投影片上的圖形。此集合同時是您找尋與修改圖形的所在，也是圖形堆疊順序的來源：索引 `0` 為最背面的圖形，而最後一個索引則為最前面的圖形。

本文遵循此模型。首先說明如何可靠地辨識圖形，接著展示如何複製、移除、隱藏與重新排序圖形。最後的章節涵蓋版面層級格式設定、SVG 匯出、對齊與翻轉設定。每個範例都是獨立的，您可以只使用工作流程所需的操作。

## **識別與尋找圖形**

在處理已知檔案時，集合索引雖然方便，但並非穩定的識別子。加入、移除或重新排序圖形都會改變其索引。請依照簡報的製作與維護方式選擇識別子：

- [Shape.name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/name/) 可用於開發人員控制的範本，且在 PowerPoint 的「Selection Pane」中易於檢查。名稱可以編輯且不保證唯一，若程式碼依賴名稱，請建立命名慣例。
- [Shape.alternative_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/alternative_text/) 於已有無障礙描述或作者自訂標籤已能辨識圖形時很有用。此文字對使用者可見，可能會本地化或為無障礙目的而重寫，且不保證唯一。切勿刻意將具有意義的無障礙文字作為資料庫鍵值。
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/office_interop_shape_id/) 是唯讀識別子，於投影片內唯一，對應 PowerPoint interop 使用的圖形 ID。於與 PowerPoint 整合或需在圖形生命週期內取得明確參照時使用。被複製或重新建立的圖形會取得不同的 ID。

相關的 [Shape.unique_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/unique_id/) 屬性具有簡報範圍，但僅供外掛使用，且可能被重新指派，不應視為永久的外部鍵。如果長期身份識別至關重要，請將映射保存在應用程式資料中，並驗證預期的圖形仍然存在。

以下範例以精確比對 `name` 進行搜尋，並回報投影片範圍的 interop ID。當範本未包含預期的圖形時，程式會回報該結果，而不會繼續使用錯誤的物件。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

當操作特定於某類圖形時，請在使用型別特定成員前先檢查型別。此範例僅在命名物件為 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 時才更新文字與替代文字。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **修改圖形集合**

add、clone、remove 與 reorder 方法會立即作用於集合。如果操作改變了圖形的數量或順序，請勿再依賴先前取得的索引。

### **複製圖形**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/add_clone/) 會建立獨立的副本並將其附加到目標集合。[ShapeCollection.insert_clone](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/insert_clone/) 也會建立副本，但會放置在指定的 Z 順序索引。接受座標的多載會在不改變大小的情況下移動副本；接受寬度與高度的多載則可以同時調整大小。

此範例建立目標投影片，將標記的矩形複製到前方，並在背後插入第二個副本。對任一副本的變更都不會影響來源圖形。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

複製會將圖形的內容與格式（包括名稱與替代文字）一起複製。若這些值必須唯一，請為副本分配新邏輯識別子。複雜圖形使用的資源由簡報處理，但副本仍是具有新圖形識別的集合項目。

### **移除圖形**

[ShapeCollection.remove](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/remove/) 會從其集合中刪除指定的圖形物件。當在索引迭代期間移除多個匹配項目時，請從結尾開始遍歷，以確保每個剩餘索引仍然有效。

此範例移除所有具有指定名稱的圖形。它讀取 `slide.shapes[index]`，而非固定的集合項目，且不會多餘地轉型圖形。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

移除後，圖形計數與後續圖形的索引會改變。對未受影響的圖形保留引用比保存的索引更可靠。同時也要考慮連接線、動畫以及其他可能引用被移除物件的簡報功能；移除可見圖形可能會改變投影片的不只外觀。

### **隱藏圖形**

將 [Shape.hidden](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/hidden/) 設為 `True` 會保留圖形於集合中，但阻止它在正常投影片放映中出現。其索引、格式與內容仍可供程式碼使用，因此隱藏適用於日後可能恢復的可選元素。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

隱藏並非刪除或安全機制。使用者或程式碼仍可發現並取消隱藏，且它仍是簡報檔案的一部份。

### **變更 Z 順序**

重疊的圖形依集合順序繪製。[ShapeCollection.reorder](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapecollection/reorder/) 會在不複製的情況下將現有圖形移動到目標索引。索引 `0` 為背面，`len(slide.shapes) - 1` 為前面。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

此範例先建立矩形，最初位於橢圓之後。將其移動到最後索引後，矩形會出現在前方。請在加入或複製所有相關圖形後再最終調整 Z 順序，因為這些操作會在集合中加入或插入新項目，可能會改變預期的堆疊。

## **檢查版面投影片上的圖形**

普通投影片、版面投影片與母片都有各自的圖形集合。版面集合中的圖形並非與普通投影片上同位置圖形的相同物件。需要了解或變更版面提供的格式時，請檢查版面圖形。

以下範例讀取每個版面圖形的 [Shape.fill_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/fill_format/) 與 [Shape.line_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/line_format/)，且不假設每個圖形皆為 `AutoShape`。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

編輯版面可能會影響使用該版面的多張投影片。變更版面圖形前，請先確認普通投影片是繼承該物件或具有本地覆寫，並測試所有使用該版面的投影片。

## **將圖形匯出為 SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/write_as_svg/) 會將單一圖形的渲染內容寫入串流。結果僅包含該圖形本身，而不會包含整張投影片的背景或鄰近圖形。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

在渲染期間請保持簡報開啟。輸出內容取決於圖形的格式以及字型、影像等資源。若需整個構圖，請匯出投影片而非單一圖形。呼叫端負責管理串流並在使用完畢後關閉。

## **對齊圖形**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.util/slideutil/align_shapes/) 的多載可對齊全部圖形或選定的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapesalignmenttype/) 指定對齊的邊緣、中心線或分佈模式。將 `align_to_slide` 設為 `True` 以使用投影片邊緣；設為 `False` 則相對於彼此對齊選取的圖形。

此範例將三個圖形對齊至投影片的上緣。其目前索引在對齊前立即解析。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

對齊會改變位置，而非 Z 順序。相對對齊通常至少需要兩個圖形，而水平或垂直分佈則需足夠的圖形以定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉圖形**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定，以及旋轉。其 `flip_h` 與 `flip_v` 值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/nullablebool/)：`TRUE` 代表啟用翻轉，`FALSE` 代表停用，`NOT_DEFINED` 則保留未指定或預設狀態。

以下簡報包含一個未翻轉的圖形。

![翻轉前的圖形](shape_to_be_flipped.png)

此範例保留其他所有框架值，僅替換兩個翻轉設定。這點很重要，因為重新指派新的 [Shape.frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/frame/) 會取代整個框架。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

保存的圖形在水平與垂直方向皆被鏡像，同時保留位置、大小與旋轉。

![翻轉後的圖形](flipped_shape.png)

## **常見問題**

**我應該使用集合索引作為圖形識別碼嗎？**

僅在集合在使用索引前不會變動的短暫處理情境下可使用。對於有作者模板的情況，建議使用已驗證的 `name` 或 `alternative_text` 命名慣例；若處理投影片範圍的 interop 工作，則使用 `office_interop_shape_id`。

**隱藏圖形會將它從 Z 順序中移除嗎？**

不會。隱藏的圖形仍保留在集合中且索引不變。它仍可被尋找、重新排序、編輯或再次顯示。

**為什麼複製的圖形會出現在另一個圖形的前面？**

`add_clone` 會將副本附加到集合的末端，也就是 Z 順序的最前面。若要指定初始索引，可使用 `insert_clone`，或在加入所有圖形後使用 `reorder`。