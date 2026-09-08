---
title: เพิ่มประสิทธิภาพการนำเสนอของคุณด้วย AutoFit ใน Python
linktitle: การตั้งค่า Autofit
type: docs
weight: 30
url: /th/python-java/manage-autofit-settings/
keywords:
- กล่องข้อความ
- autofit
- ไม่ทำการปรับอัตโนมัติ
- พอดีข้อความ
- ย่อข้อความ
- ตัดข้อความ
- ปรับขนาดรูป
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการการตั้งค่า AutoFit ใน Aspose.Slides สำหรับ Python ผ่าน Java เพื่อปรับแต่งการแสดงข้อความในงานนำเสนอ PowerPoint และ OpenDocument ของคุณและเพิ่มความอ่านง่ายของเนื้อหา"
---
## **คำนำ**

โดยค่าเริ่มต้นเมื่อคุณเพิ่มกล่องข้อความ Microsoft PowerPoint จะใช้การตั้งค่า **Resize shape to fix text** สำหรับกล่องข้อความ—โดยอัตโนมัติปรับขนาดกล่องข้อความเพื่อให้ข้อความของมันพอดีเสมอ

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* เมื่อข้อความในกล่องข้อความยาวหรือใหญ่ขึ้น PowerPoint จะขยายกล่องข้อความโดยเพิ่มความสูงเพื่อให้บรรจุข้อความได้มากขึ้น  
* เมื่อข้อความในกล่องข้อความสั้นหรือเล็กลง PowerPoint จะลดขนาดกล่องข้อความโดยลดความสูงเพื่อกำจัดพื้นที่ว่างที่ไม่จำเป็น  

ใน PowerPoint มีพารามิเตอร์หรือ 옵션สำคัญ 4 อย่างที่ควบคุมพฤติกรรม Autofit ของกล่องข้อความ:

* **ไม่ทำ Autofit**
* **ย่อข้อความเมื่อเกินขนาด**
* **ปรับขนาดรูปให้พอดีข้อความ**
* **ตัดข้อความในรูป**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java ให้ตัวเลือกคล้ายกัน—บางคุณสมบัติภายใต้คลาส [TextFrameFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/)—ที่ช่วยให้คุณควบคุมพฤติกรรม Autofit ของกล่องข้อความในงานนำเสนอ

## **ปรับขนาดรูปให้พอดีข้อความ**

หากคุณต้องการให้ข้อความในกล่องพอดีกับกล่องเสมอหลังจากมีการเปลี่ยนแปลงข้อความ คุณต้องใช้ตัวเลือก **Resize shape to fix text** เพื่อกำหนดการตั้งค่านี้ ให้ใช้เมธอด [setAutofitType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setAutofitType) (จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/)) พร้อมกับ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/textautofittype/#Shape)

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

This Python code shows you how to specify that a text must always fit into its box in a PowerPoint presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หากข้อความยาวหรือใหญ่ขึ้น กล่องข้อความจะถูกปรับขนาดโดยอัตโนมัติ (เพิ่มความสูง) เพื่อให้ข้อความทั้งหมดพอดี หากข้อความสั้นลง จะดำเนินการในทางตรงกันข้าม

## **ไม่ทำ Autofit**

หากคุณต้องการให้กล่องข้อความหรือรูปคงขนาดเดิมไม่ว่าเนื้อความจะเปลี่ยนแปลงอย่างไร คุณต้องใช้ตัวเลือก **Do not Autofit** เพื่อกำหนดการตั้งค่านี้ ให้ใช้เมธอด [setAutofitType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setAutofitType) (จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/)) พร้อมกับ [None](https://reference.aspose.com/slides/th/python-java/aspose.slides/textautofittype/#None)

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

This Python code shows you how to specify that a textbox must always retain its dimensions in a PowerPoint presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เมื่อข้อความยาวเกินขนาดของกล่อง จะเกิดการล้นออกนอกกล่อง

## **ย่อข้อความเมื่อเกินขนาด**

หากข้อความยาวเกินขนาดของกล่อง คุณสามารถใช้ตัวเลือก **Shrink text on overflow** เพื่อกำหนดให้ขนาดและระยะห่างของข้อความถูกลดลงให้พอดีกล่องได้ โดยใช้เมธอด [setAutofitType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setAutofitType) (จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/)) พร้อมกับ [Normal](https://reference.aspose.com/slides/th/python-java/aspose.slides/textautofittype/#Normal)

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

This Python code shows you how to specify that a text must be shrunk on overflow in a PowerPoint presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="หมายเหตุ" color="info" %}}
เมื่อใช้ตัวเลือก **Shrink text on overflow** การตั้งค่านี้จะถูกนำไปใช้เฉพาะเมื่อข้อความยาวเกินขนาดของกล่องเท่านั้น
{{% /alert %}}

## **ตัดข้อความในรูป**

หากต้องการให้ข้อความในรูปตัดบรรทัดภายในรูปเมื่อข้อความเกินขอบความกว้างของรูป (เฉพาะความกว้าง) คุณต้องใช้พารามิเตอร์ **Wrap text in shape** โดยใช้เมธอด [setWrapText](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setWrapText) (จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/)) พร้อมกับ [NullableBool.True](https://reference.aspose.com/slides/th/python-java/aspose.slides/nullablebool/#True)

This Python code shows you how to use the Wrap Text setting in a PowerPoint presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="คำเตือน" color="warning" %}}
หากคุณใช้เมธอด [setWrapText](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframeformat/#setWrapText) พร้อมกับ [NullableBool.False](https://reference.aspose.com/slides/th/python-java/aspose.slides/nullablebool/#False) สำหรับรูปหนึ่ง เมื่อข้อความภายในรูปยาวเกินความกว้างของรูป ข้อความจะลำดับต่อเนื่องออกไปนอกขอบของรูปในบรรทัดเดียว
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ขนาดขอบด้านในของกรอบข้อความส่งผลต่อ AutoFit หรือไม่?**  
ใช่ การเพิ่ม Padding (ขอบด้านใน) จะลดพื้นที่ใช้ได้สำหรับข้อความ ดังนั้น AutoFit จะทำงานเร็วขึ้นโดยการย่อฟอนต์หรือปรับขนาดรูปก่อน

**AutoFit ทำงานร่วมกับการแทรกบรรทัดใหม่แบบแมนนวลและแบบอ่อนอย่างไร?**  
บรรทัดใหม่ที่บังคับไว้จะคงอยู่ และ AutoFit จะปรับขนาดฟอนต์และระยะห่างให้เหมาะกับตำแหน่งนั้น ๆ การลบบรรทัดใหม่ที่ไม่จำเป็นมักช่วยลดการย่อข้อความของ AutoFit ได้

**การเปลี่ยนฟอนต์ของธีมหรือการทำ substitution ฟอนต์มีผลต่อผลลัพธ์ของ AutoFit หรือไม่?**  
ใช่ การเปลี่ยนเป็นฟอนต์ที่มีเมตริกซ์ต่างกันจะเปลี่ยนความกว้าง/ความสูงของข้อความ ซึ่งอาจทำให้ขนาดฟอนต์สุดท้ายหรือการตัดบรรทัดเปลี่ยนไป หลังจากเปลี่ยนฟอนต์หรือทำ substitution ควรตรวจสอบสไลด์อีกครั้ง