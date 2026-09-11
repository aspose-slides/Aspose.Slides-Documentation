---
title: 在 Python 透過 Java 格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/python-java/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 草圖效果
- 草圖形狀線條
- 格式化接合樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 實心顏色填色
- 形狀透明度
- 黑白形狀呈現
- 灰階形狀呈現
- 旋轉形狀
- 3D 斜面效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 透過 Java 格式化 PowerPoint 形狀——精確且完整控制地為 PPT、PPTX 與 ODP 檔案設定填充、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上新增形狀。由於形狀由線條組成，您可以透過修改或套用效果來格式化其輪廓。此外，您還可以透過指定控制內部填充方式的設定來格式化形狀。

![格式化形狀‑PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java 提供的類別與方法，使您能夠使用 PowerPoint 中相同的選項來格式化形狀。

## **格式化線條**

使用 Aspose.Slides，您可以為形狀指定自訂的線條樣式。以下步驟概述了此程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 新增至投影片中。
1. 設定形狀的 [line style](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linestyle/)。
1. 設定線寬。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linedashstyle/)。
1. 設定形狀的線條顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

下列程式碼示範如何格式化矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 建立代表簡報檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增類型為 Rectangle 的 AutoShape。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # 設定矩形形狀的填色。
    shape.getFillFormat().setFillType(FillType.NoFill)

    # 套用格式至矩形的線條。
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # 設定矩形線條的顏色。
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![簡報中格式化的線條](formatted-lines.png)

## **套用草圖效果於形狀線條**

草圖效果會使形狀線條看起來像手繪。使用 [Shape.getLineFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getLineFormat) 取得線條設定，使用 [LineFormat.getSketchFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/lineformat/#getSketchFormat) 取得草圖設定，並使用 [SketchFormat.setSketchType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sketchformat/#setSketchType) 從 [LineSketchType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linesketchtype/) 列舉中選取值。

下列 Python 程式碼示範如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linesketchtype/#Curved) 效果，讀取明確指派的值，並使用 [LineSketchType.None_](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linesketchtype/#None) 移除效果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # 存取形狀的線條格式及其草圖格式。
    sketch_format = shape.getLineFormat().getSketchFormat()

    # 套用草圖效果。
    sketch_format.setSketchType(LineSketchType.Curved)

    # 讀取直接指派給形狀的草圖效果。
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # 移除草圖效果。
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

由 [SketchFormat.getSketchType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sketchformat/#getSketchType) 回傳的值代表直接指派給形狀的設定。若線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [LineFormat.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/lineformat/#getEffective)，存取 `LineFormatEffectiveData.getSketchFormat`，並讀取 `SketchFormatEffectiveData.getSketchType`。有效值會在繼承解析後，反映實際套用的格式設定：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **格式化接合樣式**

以下是三種接合類型選項：

* 圓形
* 斜角
* 斜面

預設情況下，PowerPoint 在兩條線以角度相接（例如形狀的角落）時會使用 **圓形** 設定。然而，若您繪製的是具有尖銳角度的形狀，可能會偏好 **斜角** 選項。

![簡報中的接合樣式](join-style-powerpoint.png)

下列 Python 程式碼示範如何使用斜角、斜面與圓形接合類型設定，建立圖中所示的三個矩形：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 建立代表簡報檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增三個類型為 Rectangle 的 AutoShape。
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # 設定每個矩形形狀的填色。
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # 設定線寬。
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # 設定每個矩形線條的顏色。
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # 設定接合樣式。
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # 為每個矩形新增文字。
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **漸層填色**

在 PowerPoint 中，漸層填色是一種格式化選項，可讓您將連續的顏色漸變套用至形狀。例如，您可以以逐漸淡化的方式套用兩種或多種顏色。

以下示範如何使用 Aspose.Slides 為形狀套用漸層填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 新增至投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filltype/) 設為 `Gradient`。
1. 使用 [GradientFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/gradientformat/) 類別所公開的漸層停點集合的 [addPresetColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/gradientstopcollection/#addPresetColor) 方法，依定義的位置加入您偏好的兩種顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# 建立代表簡報檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增類型為 Ellipse 的 AutoShape。
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # 為橢圓形套用漸層格式。
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # 設定漸層的方向。
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # 新增兩個漸層停點。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![具有漸層填色的橢圓形](gradient-fill.png)

## **圖案填色**

在 PowerPoint 中，圖案填色是一種格式化選項，可讓您將二色設計（例如點狀、條紋、交叉陰影或格子）套用至形狀。您可以為圖案的前景色與背景色自訂顏色。

Aspose.Slides 提供超過 45 種預定義的圖案樣式，您可將其套用至形狀，以提升簡報的視覺吸引力。即使選取預定義圖案後，仍可指定其使用的精確顏色。

以下示範如何使用 Aspose.Slides 為形狀套用圖案填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 新增至投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中選取圖案樣式。
1. 設定圖案的 [Background Color](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/patternformat/#getBackColor)。
1. 設定圖案的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/patternformat/#getForeColor)。
1. 將修改後的簡報儲存為 PPTX 檔案。

```python
import jpase
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 建立代表簡報檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增類型為 Rectangle 的 AutoShape。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 設定填充類型為 Pattern。
    shape.getFillFormat().setFillType(FillType.Pattern)

    # 設定圖案樣式。
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # 設定圖案的背景色與前景色。
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![具有圖案填色的矩形](pattern-fill.png)

## **圖片填色**

在 PowerPoint 中，圖片填色是一種格式化選項，可讓您在形狀內插入圖像──實質上將圖像作為形狀的背景。

以下示範如何使用 Aspose.Slides 為形狀套用圖片填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 新增至投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填充模式設為 `Tile`（或其他偏好的模式）。
1. 從您想使用的圖像建立 [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 物件。
1. 將圖像傳遞給 `SlidesPicture.setImage` 方法。
1. 將修改後的簡報儲存為 PPTX 檔案。

假設我們有一個名為 "lotus.png" 的檔案，其圖示如下：

![蓮花圖片](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# 建立代表簡報檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增類型為 Rectangle 的 AutoShape。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # 設定填充類型為 Picture。
    shape.getFillFormat().setFillType(FillType.Picture)

    # 設定圖片填充模式。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # 載入圖像並將其加入簡報資源。
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # 設定圖片。
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![具有圖片填色的形狀](picture-fill.png)

### **將圖片平鋪為紋理**

如果您想將平鋪圖片設為紋理並自訂平鋪行為，可使用 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/) 類別的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#setPictureFillMode)：設定圖片填充模式──`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平鋪在形狀內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#setTileFlip)：控制平鋪是否水平翻轉、垂直翻轉或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#setTileOffsetX)：設定平鋪相對於形狀原點的水平偏移（以點為單位）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#setTileOffsetY)：設定平鋪相對於形狀原點的垂直偏移（以點為單位）。
- [setTileScaleX](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定義平鋪的水平比例。
- [setTileScaleY](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定義平鋪的垂直比例。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# 建立代表簡報檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    first_slide = presentation.getSlides().get_Item(0)

    # 新增矩形 AutoShape。
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # 設定形狀的填充類型為 Picture。
    shape.getFillFormat().setFillType(FillType.Picture)

    # 載入圖像並將其加入簡報資源。
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # 指派圖像至形狀。
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # 設定圖片填充模式與平鋪屬性。
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![平鋪選項](tile-options.png)

## **實心顏色填色**

在 PowerPoint 中，實心顏色填色是一種格式化選項，可用單一、均勻的顏色填滿形狀。此純色背景不包含任何漸層、紋理或圖案。

以下說明如何使用 Aspose.Slides 為形狀套用實心顏色填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 新增至投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filltype/) 設為 `Solid`。
1. 指定您偏好的填充顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 建立代表簡報檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增類型為 Rectangle 的 AutoShape。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 設定填充類型為 Solid。
    shape.getFillFormat().setFillType(FillType.Solid)

    # 設定填充顏色。
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![具有實心顏色填色的形狀](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，對形狀套用實心顏色、漸層、圖片或紋理填色時，您也可以設定透明度以控制填色的不透明度。較高的透明度會使形狀更透明，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填色顏色的 alpha 值來設定透明度。以下是操作步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 新增至投影片。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filltype/) 設為 `Solid`。
1. 使用 [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) 定義具有透明度的顏色（alpha 元件控制透明度）。
1. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 建立代表簡報檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增實心矩形 AutoShape。
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 在實心形狀上方新增透明矩形 AutoShape。
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![透明的形狀](shape-transparency.png)

## **旋轉形狀**

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉形狀。這在定位具有特定對齊或設計需求的視覺元素時非常有用。

若要旋轉投影片上的形狀，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 新增至投影片。
1. 將形狀的 rotation 屬性設定為所需的角度。
1. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 建立代表簡報檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增類型為 Rectangle 的 AutoShape。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # 旋轉形狀 5 度。
    shape.setRotation(5)

    # 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![形狀旋轉](shape-rotation.png)

## **新增 3D 斜面效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/) 屬性，對形狀套用 3D 斜面效果。

要為形狀新增 3D 斜面效果，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 新增至投影片。
1. 設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/) 以定義斜面設定。
1. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 建立代表簡報檔案的 Presentation 類別實例。
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 在投影片上新增形狀。
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # 設定形狀的 ThreeDFormat 屬性。
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![3D 斜面效果](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/) 屬性，對形狀套用 3D 旋轉效果。

要為形狀套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 新增至投影片。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/camera/#setCameraType) 與 [setLightType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/lightrig/#setLightType) 方法定義 3D 旋轉。
1. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# 建立 Presentation 類別的實例。
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![3D 旋轉效果](3D-rotation-effect.png)

## **控制形狀的黑白顯示**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#setBlackWhiteMode) 方法指定當簡報以黑白模式檢視或處理時，個別形狀的呈現方式。它本身不會啟用黑白顯示，也不會在正常彩色模式下變更形狀的填充、線條或其他格式設定。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/blackwhitemode/) 類別中的值來選取所需的行為。例如，`Automatic` 讓渲染應用程式自行決定轉換方式，`Gray` 與 `LightGray` 使用灰色，`BlackWhite` 僅使用黑白，`Black` 與 `White` 強制單一顏色，`Color` 保留正常著色，`Hidden` 在黑白模式下隱藏形狀，`NotDefined` 表示未指派形狀層級模式。

以下 Python 程式碼建立一個彩色形狀，並在黑白顯示模式下使其呈現灰色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # 在彩色模式下保留橙色填充，但在黑白模式下以灰階顏色呈現形狀。
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在正常彩色模式下，矩形保留橙色填充。在黑白顯示的工作流程中，因其模式設定為 `Gray`，因此使用灰色著色。這讓您即使保留全彩投影片，也能為列印、預覽或其他遵循黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

以下 Python 程式碼示範如何重設投影片的格式，並將 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/layoutslide/) 上所有含佔位符的形狀的位置、大小與格式恢復為預設設定：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # 重設投影片上每個在版面配置中具有佔位符的形狀。
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**形狀格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的影像與媒體佔用大部分檔案空間，而形狀參數（如顏色、效果與漸層）僅以中繼資料儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的形狀以便將其分組？**

比較每個形狀的關鍵格式屬性──填色、線條與效果設定。若所有相對應的數值皆相符，則視為樣式相同，並在邏輯上將這些形狀分組，這可簡化後續的樣式管理。

**我能否將自訂形狀樣式集合儲存至獨立檔案，以便在其他簡報中重複使用？**

可以。將具備所需樣式的示範形狀儲存於範本投影片集或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製所需的樣式形狀，並在需要的地方重新套用其格式設定。