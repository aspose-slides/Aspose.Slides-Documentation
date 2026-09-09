---
title: 在 Python（透過 Java）中建立並套用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh-hant/python-java/wordart/
keywords:
- WordArt
- 建立 WordArt
- WordArt 範本
- WordArt 效果
- 陰影效果
- 反射效果
- 發光效果
- WordArt 變形
- 3D 效果
- 外部陰影效果
- 內部陰影效果
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中建立與自訂 WordArt 效果。此分步指南協助開發人員以 Python（透過 Java）提升簡報的專業文字效果。"
---
## **概述**

WordArt 效果讓您能在 PowerPoint 簡報中加入視覺上吸引人且風格化的文字。使用 Aspose.Slides，開發人員可以以程式方式建立、自訂以及管理 WordArt，與 Microsoft PowerPoint 的操作相同—無需安裝 Office。本篇文章概述了使用 WordArt 的方法，包含如何套用文字變形、填充樣式、輪廓、陰影以及其他格式設定，讓您的簡報內容更具表現力與吸引力。WordArt 允許您將文字視為圖形物件。它由套用於文字的效果或特殊修改組成，使文字更具吸引力或顯眼。

## **建立簡易 WordArt 範本並套用至文字**

**使用 Aspose.Slides**

首先，我們使用以下 Python 程式碼建立簡單文字：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
接著，調整字型大小以使效果更明顯：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**使用 Microsoft PowerPoint**

前往 Microsoft PowerPoint 中的 WordArt 效果功能表：

![PowerPoint 中的 WordArt 效果功能表](image-20200930113926-1.png)

在右側功能表中，您可以選擇預先定義的 WordArt 效果。左側功能表則可設定新 WordArt 的參數。

以下是部分可用的參數或選項：

![WordArt 格式選項](image-20200930114015-3.png)

**使用 Aspose.Slides**

在此，我們使用此程式碼將 [PatternStyle.SmallGrid](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/patternstyle/#SmallGrid) 圖案填色套用至文字，並加入黑色文字邊框：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

結果文字如下：

![具圖案填色與黑色輪廓的文字](image-20200930114108-4.png)

## **套用其他 WordArt 效果**

**使用 Microsoft PowerPoint**

在程式介面中，您可以將這些效果套用至文字、文字區塊、圖形或類似的元素：

![PowerPoint 中的文字與圖形效果](image-20200930114129-5.png)

例如，陰影、反射與發光效果可套用於文字；3D 格式與 3D 旋轉效果可套用於文字區塊；柔化邊緣效果可套用於圖形（即使未設定 3D 格式效果仍會生效）。

### **套用陰影效果**

以下 Python 程式碼僅將陰影效果套用於文字：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Aspose.Slides API 支援三種陰影類型：[OuterShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/outershadow/)、[InnerShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/innershadow/) 與 [PresetShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presetshadow/)。

使用 [PresetShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presetshadow/)，您可以使用預設值將陰影套用於文字。

**使用 Microsoft PowerPoint**

在 PowerPoint 中，只能使用一種陰影類型。以下為範例：

![PowerPoint 中的陰影設定](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 實際上允許同時套用兩種陰影類型：[InnerShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/innershadow/) 與 [PresetShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presetshadow/)。

**注意：**

- 同時使用 [OuterShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/outershadow/) 與 [PresetShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presetshadow/) 時，僅套用 [OuterShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/outershadow/) 效果。
- 同時使用 [OuterShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/outershadow/) 與 [InnerShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/innershadow/) 時，最終套用的效果取決於 PowerPoint 版本。例如在 PowerPoint 2013 中，效果會加倍；但在 PowerPoint 2007 中，僅套用 [OuterShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/outershadow/) 效果。

### **套用反射效果至文字**

我們透過以下 Python（Java）範例程式碼為文字加入反射：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **套用發光效果至文字**

我們使用以下程式碼將發光效果套用於文字，使其更加亮眼或突出：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

操作結果：

![具發光效果的文字](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
您可以變更陰影、反射與發光的參數。效果的屬性會分別套用於文字的每個部分。
{{% /alert %}}

### **在 WordArt 中使用變形**

使用 [TextFrameFormat.setTransform](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setTransform) 變形整個文字區塊：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

結果：

![具拱形變形的文字](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
Microsoft PowerPoint 與 Aspose.Slides for Python via Java 都提供一定數量的預定義變形類型。
{{% /alert %}}

**使用 PowerPoint**

若要存取預定義的變形類型，請前往：**格式** -> **文字效果** -> **變形**

**使用 Aspose.Slides**

若要選取變形類型，請使用 [TextShapeType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textshapetype/) 列舉。

### **套用 3D 效果至文字與圖形**

我們使用以下範例程式碼將 3D 效果套用於文字圖形：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

結果文字與圖形如下：

![具 3D 效果的文字圖形](image-20200930114816-9.png)

我們使用以下 Python 程式碼將 3D 效果套用於文字：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

操作結果：

![具 3D 效果的文字](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
將 3D 效果套用於文字或其圖形，以及效果間的相互作用，皆遵循特定規則。

考慮文字與其所在圖形的場景。3D 效果包含 3D 物件的表示以及物件所在的場景。

- 當場景同時設定於圖形與文字時，圖形的場景優先—會忽略文字的場景。
- 當圖形本身沒有場景但具備 3D 表示時，使用文字的場景。
- 否則—若圖形原本沒有 3D 效果—圖形為平面，3D 效果僅套用於文字。

此規則與 [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getLightRig) 與 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getCamera) 方法相關。
{{% /alert %}}

## **套用外部陰影效果至文字**

Aspose.Slides for Python via Java 提供 [OuterShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/outershadow/) 與 [InnerShadow](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/innershadow/) 類別，可在 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 中為文字套用陰影效果。請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 使用索引取得投影片的參考。
3. 在投影片上新增矩形圖形。
4. 取得與圖形關聯的文字框。
5. 停用圖形填色。
6. 啟用外部陰影效果。
7. 設定陰影的模糊半徑。
8. 設定陰影的方向。
9. 設定陰影的距離。
10. 將陰影對齊至左上角。
11. 設定陰影顏色為黑色。
12. 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

以下為 Python（Java）範例程式碼，示範如何將外部陰影效果套用於文字：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # 取得投影片的參考
    slide = presentation.getSlides().get_Item(0)

    # 新增矩形類型的 AutoShape
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # 在矩形中加入 TextFrame
    auto_shape.addTextFrame("Aspose TextBox")

    # 停用圖形填充，以便取得文字的陰影
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # 新增外部陰影並設定所有必要的參數
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # 將簡報寫入磁碟
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **套用內部陰影效果於圖形**

請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 取得投影片的參考。
3. 新增矩形圖形。
4. 啟用內部陰影效果。
5. 設定所有必要的參數。
6. 將陰影顏色類型設為使用主題顏色。
7. 設定主題顏色。
8. 將簡報寫入為 [PPTX](https://docs.fileformat.com/presentation/pptx/) 檔案。

以下為依上述步驟撰寫的 Python（Java）範例程式碼，示範如何在圖形的文字上套用內部陰影效果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # 取得投影片的參考
    slide = presentation.getSlides().get_Item(0)

    # 新增矩形類型的 AutoShape
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # 在矩形中加入 TextFrame
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # 啟用 InnerShadowEffect
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # 設定所有必要的參數
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # 將 ColorType 設為 Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # 設定方案顏色
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # 儲存簡報
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**我可以將 WordArt 效果套用於不同字型或文字系統（例如阿拉伯文、中文）嗎？**

是的，Aspose.Slides 支援 Unicode，並可使用所有主要的字型與文字系統。無論語言為何，都可套用陰影、填色與輪廓等 WordArt 效果，儘管字型的可用性與呈現可能取決於系統字型。

**我可以將 WordArt 效果套用於投影片母片中的元件嗎？**

可以，您可以在母片投影片的圖形上套用 WordArt 效果，包括標題佔位文字、頁腳或背景文字。對母片版面的變更會套用至所有相關投影片。

**WordArt 效果會影響簡報檔案大小嗎？**

會有輕微影響。陰影、發光與漸層填色等 WordArt 效果會因為額外的格式化中繼資料而稍微增加檔案大小，但差異通常可以忽略不計。

**我能在不儲存簡報的情況下預覽 WordArt 效果的結果嗎？**

可以，您可以使用 [Shape.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage) 或 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 將包含 WordArt 的投影片渲染為圖像（如 PNG、JPEG），以在記憶體或螢幕上即時預覽結果，無需儲存或匯出完整簡報。