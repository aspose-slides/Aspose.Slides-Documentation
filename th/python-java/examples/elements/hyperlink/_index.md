---
title: ไฮเปอร์ลิงก์
type: docs
weight: 130
url: /th/python-java/examples/elements/hyperlink/
keywords:
- ตัวอย่างโค้ด
- ไฮเปอร์ลิงก์
- เพิ่มไฮเปอร์ลิงก์
- เข้าถึงไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เพิ่มและจัดการไฮเปอร์ลิงก์ใน Aspose.Slides สำหรับ Python ผ่าน Java: สร้าง, เข้าถึง, ลบและอัปเดตลิงก์ในงานนำเสนอรูปแบบ PPT, PPTX และ ODP"
---
บทความนี้สาธิตการเพิ่ม, เข้าถึง, ลบและอัปเดตไฮเปอร์ลิงก์บนรูปร่างโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพคเกจตามที่อธิบายไว้ใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนเริ่ม JVM แล้วจึงนำเข้า API หลังจาก JVM ทำงานแล้ว.

## **เพิ่มไฮเปอร์ลิงก์**

สร้างรูปร่างสี่เหลี่ยมผืนผ้าที่มีไฮเปอร์ลิงก์ชี้ไปยังเว็บไซต์ภายนอก.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **เข้าถึงไฮเปอร์ลิงก์**

อ่านข้อมูลไฮเปอร์ลิงก์จากส่วนข้อความของรูปร่าง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **ลบไฮเปอร์ลิงก์**

ลบไฮเปอร์ลิงก์ออกจากข้อความของรูปร่าง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **อัปเดตไฮเปอร์ลิงก์**

เปลี่ยนเป้าหมายของไฮเปอร์ลิงก์ที่มีอยู่ ใช้ [HyperlinkManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkmanager/) เพื่อแก้ไขข้อความที่มีไฮเปอร์ลิงก์อยู่แล้ว ซึ่งจำลองการอัปเดตไฮเปอร์ลิงก์ของ PowerPoint อย่างปลอดภัย.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # การเปลี่ยนไฮเปอร์ลิงก์ในข้อความที่มีอยู่ควรทำผ่าน
    # HyperlinkManager แทนการตั้งค่าคุณสมบัติโดยตรง.
    # นี้จำลองการที่ PowerPoint อัปเดตไฮเปอร์ลิงก์อย่างปลอดภัย.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```