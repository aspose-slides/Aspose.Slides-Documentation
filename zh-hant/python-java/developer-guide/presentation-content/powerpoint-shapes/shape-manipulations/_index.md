---
title: 管理使用 Python via Java 的簡報形狀
linktitle: 形狀操作
type: docs
weight: 40
url: /zh-hant/python-java/shape-manipulations/
keywords:
- PowerPoint 形狀
- 簡報形狀
- 投影片上的形狀
- 找尋形狀
- 複製形狀
- 移除形狀
- 隱藏形狀
- 變更形狀順序
- 取得 interop 形狀 ID
- 形狀替代文字
- 形狀調整點
- 預設形狀調整
- 形狀幾何
- 形狀版面格式
- 形狀為 SVG
- 形狀至 SVG
- 對齊形狀
- 翻轉形狀
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 來識別、調整、複製、移除、隱藏、重新排序、匯出、對齊與翻轉簡報形狀。"
---
## **概述**

Aspose.Slides for Python via Java 以有序的 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/) 來表示投影片上的形狀。此集合同時是您查找與修改形狀的所在，也是它們堆疊順序的來源：索引 `0` 為最背面的形狀，而最後一個索引則為最前面的形狀。

本文遵循此模型。它首先說明如何可靠地識別形狀並修改預設的形狀調整點，接著示範如何複製、移除、隱藏與重新排序形狀。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊與翻轉設定。每個範例皆為獨立，您可只使用工作流程需要的操作。

## **識別與尋找形狀**

在處理已知檔案時，集合索引很方便，但它們不是穩定的識別子。新增、移除或重新排序形狀都會改變其索引。請根據簡報的製作與維護方式選擇識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getName) 對於開發人員控制的範本很有用，也能在 PowerPoint 的「選取窗格」中輕鬆檢查。名稱可以編輯且不保證唯一，若程式碼依賴它們，請訂定命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getAlternativeText) 在已提供可存取性說明或作者標記的情況下很實用。它對使用者可見，可能會本地化或為可存取性重新編寫，且不保證唯一。請勿將有意義的可存取性文字靜默用作資料庫鍵。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getOfficeInteropShapeId) 為唯讀識別子，在投影片內唯一，對應 PowerPoint interop 使用的形狀 ID。當與 PowerPoint 整合或在形狀生命週期內需要不含歧義的參照時使用。被複製或重新建立的形狀是不同的形狀，會取得自己的 ID。

相關的 [getUniqueId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getUniqueId) 方法會回傳簡報範圍的識別子，但此識別子僅供外掛使用，可能會重新指派，不應視為永久外部鍵。若身分認證必須長期保持，請在應用程式資料中保留對映，並驗證預期的形狀仍然存在。

以下範例以完全相同的比較方式依名稱搜尋，並回報投影片範圍的 interop ID。當範本未包含預期的形狀時，程式會回報該結果而非繼續使用錯誤的物件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

當操作特定於形狀類型時，請先檢查類型再使用類型專屬的成員。此範例僅在命名物件為 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 時才更新文字與 alternative text。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **識別與修改預設形狀調整**

預設幾何形狀可能會公開調整點，以控制角落大小、箭頭比例或弧度等特性。透過唯讀的 [GeometryShape.getAdjustments](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/#getAdjustments) 集合存取它們。集合本身由形狀提供，但每個 [AdjustValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/) 含有可變更的值。

不要只依賴固定的集合索引。請遍歷調整項目並檢查唯讀的 [getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getType) 方法，其回傳的 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/) 描述了調整控制的內容。唯讀的 [getName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getName) 方法提供額外的辨識資訊，當一個預設包含多個相同語意類型的調整時尤其有用。

使用與調整意義相符的值方法：

| 調整類型 | 用途 | 變更的值方法 |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | 圓角大小 | [setRawValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | 箭尾厚度 | [setRawValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | 箭頭長度 | [setRawValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | 箭頭寬度 | [setRawValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | 圓餅或弧線的起始角度 | [setAngleValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | 圓餅或弧線的結束角度 | [setAngleValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getType) 與 [getName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getName) 僅回傳唯讀資訊。[getRawValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getRawValue) 與 [setRawValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#setRawValue) 使用預設幾何單位的整數，而 [getAngleValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getAngleValue) 與 [setAngleValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#setAngleValue) 使用度數。調整的數量、順序、意義與有效範圍取決於預設的 [ShapeType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/#getShapeType)。對於某一預設有效的值，對另一預設可能無效或產生不同效果。

當 [getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getType) 回傳 [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeadjustmenttype/#Custom) 時，API 未識別標準語意。請檢查 [getName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getName)、預設類型與現有值，除非已知其意義與範圍，否則保留調整不變。即使是已識別的類型，在選取值前也要確認同類型是否出現多次。[Connector](/slides/zh-hant/python-java/connector/) 文章說明了連接線彎曲調整的情況。

以下完整範例建立三個預設形狀的預設與修改版。它遍歷每個調整，回報名稱與類型，透過 [setRawValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#setRawValue) 變更尺寸相關值，透過 [setAngleValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#setAngleValue) 變更角度，最後儲存結果。左欄保留預設幾何，右欄則顯示調整後的圓角矩形、四向箭頭與圓餅。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 為預設和已調整的形狀欄位加入標題。
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在變更值之前先檢查語意類型，可使程式碼明確表達意圖，避免假設相同集合索引在不同預設形狀間具有相同意義。

## **修改形狀集合**

新增、複製、移除與重新排序方法會立即作用於集合。若操作改變了形狀的數量或順序，請勿再依賴之前捕獲的索引。

### **複製形狀**

[addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addClone) 會建立獨立的副本並附加到目標集合的尾端。[insertClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#insertClone) 亦會建立副本，但會放置在指定的 Z‑Order 索引。接受座標的重載會在不改變尺寸的情況下移動副本；接受寬度與高度的重載則可以同時調整尺寸。

以下範例建立目的投影片，將已標記的矩形複製到最前面，並在最背面插入第二個副本。對任一副本的變更不會影響來源形狀。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

複製會將形狀的內容與格式（含名稱與 alternative text）一起複製。若這些值必須唯一，請為副本指派新的邏輯識別子。複雜形狀使用的資源由簡報處理，但副本仍是集合中的新項目，擁有新的形狀身分。

### **移除形狀**

[remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#remove) 會從其所在集合中刪除特定形狀物件。於索引化迭代中移除多個相符項目時，請從集合末端向前遍歷，以確保剩餘索引仍然有效。

此範例移除每一個具有指定名稱的形狀。它在當前索引讀取形狀，而非固定的集合項目，且不會不必要地型別轉換。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

移除後，形狀計數與後續形狀的索引會變動。對未受影響的形狀保持引用通常比保存的索引更可靠。也請考慮連接線、動畫等可能參考被移除物件的投影片特性；移除可見形狀可能改變的不僅是外觀。

### **隱藏形狀**

將 [Hidden](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#setHidden) 設為 `True` 會保留形狀於集合中，但在正常投影片放映時不會出現。其索引、格式與內容仍可由程式碼存取，因此隱藏適合用於可能稍後還原的可選元素。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

隱藏並非刪除或安全保護。使用者或程式仍能找回並取消隱藏，且它仍屬於簡報檔案的一部份。

### **變更 Z‑Order**

重疊的形狀依集合順序繪製。[reorder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#reorder) 會將既有形狀移動到目標索引，而不會產生副本。索引 `0` 為最背面，集合 [size](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#size) 減一為最前面。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

矩形最先建立，最初位於橢圓之後。將其移至最後索引即會置於前面。請在加入或複製所有相關形狀後再最後確定 Z‑Order，因為這些操作會追加或插入新的集合項目，可能改變原本的堆疊順序。

## **檢查版面投影片上的形狀**

一般投影片、版面投影片與母片投影片各自擁有獨立的形狀集合。版面集合中的形狀並非與普通投影片上同位置形狀相同的物件。需要了解或變更版面提供的格式時，請檢查版面形狀。

以下範例讀取每個版面形狀的 [FillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getFillFormat) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getLineFormat)，而不假設每個形狀都是 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

編輯版面會影響使用該版面的多張投影片。在變更版面形狀前，請先確定普通投影片是繼承該物件還是有本地覆寫，並測試所有使用該版面的投影片。

## **將形狀匯出為 SVG**

[Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 的 `writeAsSvg` 方法會將單一形狀的渲染內容寫入串流。結果只包含該形狀本身，不會包含整張投影片的背景或鄰近形狀。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

在渲染期間請保持簡報開啟。輸出會受形狀格式以及字型、影像等資源影響。若需要整個組合，請匯出投影片而非單一形狀。呼叫端負責管理與關閉串流。

## **對齊形狀**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideutil/#alignShapes) 的多載可對齊全部形狀或指定的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapesalignmenttype/) 定義對齊的邊緣、中心線或分佈模式。將 `align_to_slide` 設為 `True` 即使用投影片邊緣；設為 `False` 則以選取的形狀相互對齊。

此範例將三個形狀對齊至投影片的上緣。對齊前會立即將返回的形狀參照轉換為其目前的索引。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

對齊會改變位置，而非 Z‑Order。相對對齊通常至少需要兩個形狀，而水平或垂直分佈則需要足夠的形狀以定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉形狀**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定以及旋轉。其 [getFlipH](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeframe/#getFlipH) 與 [getFlipV](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapeframe/#getFlipV) 使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/nullablebool/)：`True` 為啟用翻轉，`False` 為停用，`NotDefined` 為保留未指定/預設狀態。

以下輸入簡報包含一個未翻轉的形狀。

![翻轉前的形狀](shape_to_be_flipped.png)

此範例保留其他所有框架值，只更改兩個翻轉設定。這點很重要，因為指派新的 [Frame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#setFrame) 會取代完整的框架。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

儲存後的形狀在水平方向與垂直方向皆被鏡像，同時保留位置、大小與旋轉。

![翻轉後的形狀](flipped_shape.png)

## **常見問題**

**我可以使用集合索引作為形狀識別子嗎？**

僅限於在集合不會變動且使用壽命極短的處理情境。對於有作者維護的範本，建議使用已驗證的 [Name](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getName) 或 [AlternativeText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getAlternativeText) 慣例；對於需要投影片範圍 interop 的工作，則使用 [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getOfficeInteropShapeId)。

**隱藏形狀會從 Z‑Order 中移除嗎？**

不會。隱藏的形狀仍保留在集合中且索引不變。它仍可被搜尋、重新排序、編輯或重新顯示。

**為何複製的形狀會出現在另一個形狀的前面？**

[addClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addClone) 會將副本附加至集合的最後端，即 Z‑Order 的最前面。若想自行決定初始索引，可使用 [insertClone](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#insertClone)，或在全部形狀加入後使用 [reorder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#reorder) 調整。

**我可以使用固定索引來識別預設形狀調整嗎？**

僅在已驗證確切的預設與集合布局後才能這麼做。較佳的做法是遍歷 [GeometryShape.getAdjustments](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/geometryshape/#getAdjustments) 並檢查 [AdjustValue.getType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getType)；若同一語意類型出現多次，請同時使用 [AdjustValue.getName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/adjustvalue/#getName) 作為額外資訊。