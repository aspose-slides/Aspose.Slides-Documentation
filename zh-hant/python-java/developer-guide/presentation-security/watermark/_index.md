---
title: 在 Python 中為簡報加入水印
linktitle: 水印
type: docs
weight: 40
url: /zh-hant/python-java/watermark/
keywords:
- 水印
- 文字水印
- 影像水印
- 新增水印
- 變更水印
- 移除水印
- 刪除水印
- 將水印加入 PPT
- 將水印加入 PPTX
- 將水印加入 ODP
- 從 PPT 移除水印
- 從 PPTX 移除水印
- 從 ODP 移除水印
- 從 PPT 刪除水印
- 從 PPTX 刪除水印
- 從 ODP 刪除水印
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中於 PowerPoint 與 OpenDocument 簡報管理文字與影像水印，以標示草稿、機密資訊、版權等。"
---
## **簡介**

**水印** 在簡報中是用於投影片或整個簡報的文字或影像印記。通常，水印用於表示簡報是草稿（例如「Draft」水印）、包含機密資訊（例如「Confidential」水印）、說明屬於哪家公司（例如「Company Name」水印）、標示簡報作者等。水印可透過顯示此簡報不應被複製，協助防止版權侵害。水印同時適用於 PowerPoint 與 OpenOffice 簡報格式。在 Aspose.Slides 中，您可以為 PowerPoint PPT、PPTX 與 OpenOffice ODP 檔案格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/python-java/) 中，有多種方式可以在 PowerPoint 或 OpenOffice 文件中建立水印，並修改其設計與行為。共通點是，若要加入文字水印，應使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 類別；若要加入圖片水印，則使用 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/) 類別或以影像填充水印形狀。[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/) 繼承自 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 類別，讓您能使用形狀物件的全部彈性設定。由於 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 不是形狀且其設定受限，會將其包裝在 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) 物件中。

水印可以以兩種方式套用：套用於單一投影片或套用於整個簡報的所有投影片。使用投影片母片 (Slide Master) 可將水印套用至所有投影片——水印被加入母片、在母片上完整設計，然後自動套用至所有投影片，而不會影響各投影片對水印的個別修改權限。

水印通常被視為其他使用者無法編輯的項目。為防止水印（或其父形狀）被編輯，Aspose.Slides 提供形狀鎖定功能。可在普通投影片或投影片母片上鎖定特定形狀。當在母片上鎖定水印形狀時，所有投影片的該形狀皆會被鎖定。

您可以為水印設定名稱，未來若要刪除時，可依名稱在投影片的形狀集合中找到它。

您可以以任何方式設計水印；然而，水印通常具有一些共通特性，例如置中對齊、旋轉、前置顯示等。我們將在以下範例中說明如何使用這些特性。

## **文字水印**

### **在投影片加入文字水印**

若要在 PPT、PPTX 或 ODP 中加入文字水印，您可以先在投影片上新增一個形狀，然後在該形狀中加入文字框。文字框以 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 類別表示。此類別未繼承自 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/) ，而後者提供了廣泛的屬性，可彈性定位水印。因此，會將 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 物件包裝於 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 物件中。若要將文字水印加入形狀，請使用下方示範的 [addTextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/#addTextFrame) 方法。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [如何使用 TextFrame 類別](/slides/zh-hant/python-java/text-formatting/)
{{% /alert %}}

### **在簡報中加入文字水印**

如果您想將文字水印加入整個簡報（即一次套用至所有投影片），請將其加入至 [MasterSlide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/masterslide/)。其餘邏輯與在單一投影片上加入水印相同——建立一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 物件，然後使用 [addTextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/#addTextFrame) 方法將水印加入其中。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [如何使用投影片母片](/slides/zh-hant/python-java/slide-master/)
{{% /alert %}}

### **設定水印形狀透明度**

預設情況下，矩形形狀會套用填色與線條顏色。以下程式碼可將形狀設為透明。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **設定文字水印的字型**

您可以依照下列方式變更文字水印的字型。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **設定水印文字顏色**

若要設定水印文字的顏色，請使用以下程式碼：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **將文字水印置中**

可以將水印在投影片上置中，請執行以下操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

![文字水印](text_watermark.png)

## **影像水印**

### **在簡報中加入影像水印**

若要在簡報投影片中加入影像水印，請執行以下步驟：

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **鎖定水印以防編輯**

若需防止水印被編輯，可在形狀上使用 [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/#getAutoShapeLock) 方法。透過此屬性，您可以保護形狀不被選取、調整大小、重新定位、與其他元素群組，鎖定其文字不被編輯，等等。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # 鎖定水印形狀以防止修改。
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **將水印移至最前面**

在 Aspose.Slides 中，可透過 [ShapeCollection.reorder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#reorder) 方法設定形狀的 Z 順序。您需要從投影片的形狀集合呼叫此方法，傳入形狀參考與其順序號碼。如此即可將形狀移至最前端或送至投影片背後。若需將水印置於簡報最前端，此功能特別有用：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **設定水印旋轉角度**

以下程式碼示範如何調整水印的旋轉，使其斜置於投影片上：

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **為水印設定名稱**

Aspose.Slides 允許您為形狀設定名稱。透過形狀名稱，未來可存取該形狀以進行修改或刪除。若要設定水印形狀的名稱，請將其傳遞給 [Shape.setName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#setName) 方法：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **移除水印**

若要移除水印形狀，先使用 [Shape.getName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getName) 方法於投影片的形狀集合中尋找它，然後將該形狀傳入 [ShapeCollection.remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#remove) 方法：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **常見問題**

**什麼是水印，為何要使用它？**

水印是加在投影片上的文字或影像覆蓋層，用於保護智慧財產、提升品牌辨識度，或防止未經授權使用簡報。

**我可以將水印加入簡報的所有投影片嗎？**

可以，Aspose.Slides 允許您以程式方式將水印加入簡報的每一張投影片。您可以遍歷所有投影片，分別套用水印設定。

**我要如何調整水印的透明度？**

您可透過修改形狀的填充設定（[getFillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getFillFormat)）來調整水印的透明度，確保水印不會過於顯眼而分散投影片內容的注意力。

**支援哪些影像格式作為水印？**

Aspose.Slides 支援多種影像格式，例如 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自訂文字水印的字型與樣式嗎？**

可以，您可以選擇任意字型、大小與樣式，以符合簡報設計並保持品牌一致性。

**我要如何變更水印的位置或方向？**

您可以透過程式修改形狀的座標、尺寸與旋轉屬性，以調整水印的位置或方向。