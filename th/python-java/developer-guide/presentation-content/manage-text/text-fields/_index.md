---
title: จัดการฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย Python ผ่าน Java
linktitle: ฟิลด์ข้อความ
type: docs
weight: 52
url: /th/python-java/text-fields/
keywords:
- ฟิลด์ข้อความ
- ข้อความอัตโนมัติ
- หมายเลขสไลด์
- วันที่และเวลา
- หัวเรื่อง
- ท้ายกระดาษ
- ส่วนข้อความ
- PowerPoint
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "สร้าง, ตรวจสอบ, แก้ไข, และลบฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java. คงรูปแบบและตรวจสอบไฟล์ PPTX และ PPT ที่บันทึกไว้."
---
## **ภาพรวม**

ย่อหน้าข้อความประกอบด้วยส่วนต่าง ๆ ส่วนธรรมดา [Portion](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/) มีข้อความตามตัวอักษร; ส่วนฟิลด์ยังมี [Field](https://reference.aspose.com/slides/th/python-java/aspose.slides/field/) ที่ประเภทระบุมูลค่าที่อัปเดตอัตโนมัติ เช่นหมายเลขสไลด์หรือวันที่ สองส่วนสามารถแสดงอักขระเดียวกันได้แต่เฉพาะส่วนหนึ่งเท่านั้นที่มีฟิลด์  

ใช้ [Portion.getField](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getField) เพื่อแยกแยะ: ค่าจะเป็น `None` สำหรับข้อความธรรมดา [Portion.addField](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#addField) จะแปลงส่วนที่มีอยู่ให้เป็นฟิลด์ เก็บป้ายกำกับและค่าที่เปลี่ยนแปลงได้ในส่วนแยกกันเพื่อให้การแปลงค่าจะไม่ไปแทนที่ป้ายกำกับด้วย  

คู่มือฉบับนี้ครอบคลุมฟิลด์ภายในข้อความ การจัดรูปแบบของฟิลด์ และการบันทึกเป็นไฟล์ PPTX และ PPT สำหรับกรอบข้อความและย่อหน้า ดูที่ [Manage Text](/slides/th/python-java/manage-text/)  

## **สร้างฟิลด์หมายเลขสไลด์**

ตัวอย่างเต็มต่อไปนี้สร้างกล่องข้อความที่มีป้ายกำกับตามตัวอักษร `Slide ` ตามด้วยหมายเลขที่อัปเดตอัตโนมัติ มันตั้งขนาด น้ำหนัก และสีของหมายเลขก่อนเพิ่มฟิลด์ จากนั้นเปิดการนำเสนอที่บันทึกใหม่อีกครั้งและตรวจสอบประเภทฟิลด์ ข้อความ และการจัดรูปแบบ ไม่ต้องใช้ไฟล์อินพุต  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

การนำเสนอใหม่เริ่มต้นที่หมายเลขสไลด์ 1 ดังนั้นข้อความจะเป็น `Slide 1` และการตรวจสอบทั้งสองจะแสดงผล `True` หมายเลขยังคงเป็นฟิลด์หลังจากเปิดใหม่; ไม่ใช่ข้อความตามตัวอักษร `1` ดัชนีในขั้นตอนตรวจสอบอ้างอิงถึงรูปร่างและส่วนที่สร้างโดยตัวอย่างนี้  

## **เลือกประเภทฟิลด์**

[FieldType](https://reference.aspose.com/slides/th/python-java/aspose.slides/fieldtype/) ให้วิธีต่อไปนี้สำหรับการรับค่าที่กำหนดไว้ล่วงหน้า ส่งค่าที่เหมาะสมไปยัง [addField](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#addField)  

| วิธี | วัตถุประสงค์ |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/th/python-java/aspose.slides/fieldtype/#getSlideNumber) | หมายเลขสไลด์ปัจจุบัน |
| [getDateTime](https://reference.aspose.com/slides/th/python-java/aspose.slides/fieldtype/#getDateTime) | วันที่/เวลาในรูปแบบค่าเริ่มต้นของแอปพลิเคชันที่แสดงผล |
| [getDateTime1](https://reference.aspose.com/slides/th/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/th/python-java/aspose.slides/fieldtype/#getDateTime9) | รูปแบบวันที่หรือวันที่/เวลาที่กำหนดไว้ล่วงหน้า |
| [getDateTime10](https://reference.aspose.com/slides/th/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/th/python-java/aspose.slides/fieldtype/#getDateTime13) | รูปแบบเวลาแบบกำหนดไว้ล่วงหน้า มีตัวเลือกสำหรับวินาทีและรูปแบบนาฬิกา 12 ชั่วโมง |
| [getHeader](https://reference.aspose.com/slides/th/python-java/aspose.slides/fieldtype/#getHeader) | ฟิลด์หัวเรื่อง; ดูข้อจำกัดของตัวยึดตำแหน่งและรูปแบบต่อไปนี้ |
| [getFooter](https://reference.aspose.com/slides/th/python-java/aspose.slides/fieldtype/#getFooter) | ฟิลด์ท้ายกระดาษ |

ตัวอย่างเช่น [getDateTime3](https://reference.aspose.com/slides/th/python-java/aspose.slides/fieldtype/#getDateTime3) แสดงวัน เดือนเต็มเป็นภาษาอังกฤษและปี นี่เป็นรูปแบบฟิลด์ที่กำหนดไว้ล่วงหน้า ไม่ใช่สตริงรูปแบบวันที่ของ Python ภาษา ที่ตั้งด้วย [setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseportionformat/#setLanguageId) และแอปพลิเคชันที่ประมวลผลการนำเสนออาจส่งผลต่อผลลัพธ์ที่แสดง  

## **สร้างฟิลด์จากสตริงภายใน**

การโอเวอร์โหลดด้วยสตริงของ [addField](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#addField) ยอมรับตัวระบุฟิลด์ภายใน ใช้เมื่อเก็บตัวระบุที่ให้มาจากแอปพลิเคชันอื่นที่ไม่มีค่าที่กำหนดไว้ล่วงหน้า คุณยังสามารถสร้าง [FieldType](https://reference.aspose.com/slides/th/python-java/aspose.slides/fieldtype/#FieldType) จากตัวระบุนั้นได้ [FieldType.getInternalString](https://reference.aspose.com/slides/th/python-java/aspose.slides/fieldtype/#getInternalString) จะเปิดเผยตัวระบุเพื่อการตรวจสอบ  

ตัวอย่างนี้เก็บฟิลด์เฉพาะแอป `custom-report-id` พร้อมข้อความสำรอง `Report-042` ตัวระบุตัวนี้ไม่ได้ลงทะเบียนการคำนวน: Aspose.Slides จะไม่สร้างรหัสรายงานสำหรับประเภทที่ไม่รู้จัก แอปที่เข้าใจตัวระบุตัวนี้ต้องจัดหาความหมายและอัปเดตค่าของมัน  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

หลังการวนรอบ PPTX ประเภทจะเป็น `custom-report-id` และข้อความเป็น `Report-042` การส่งสตริงเช่น `yyyy-MM-dd` จะตั้งชื่อประเภทฟิลด์; ไม่ได้ตั้งค่ารูปแบบวันที่แบบกำหนดเอง สำหรับวันที่คงที่ในรูปแบบใดก็ได้ ให้ใช้ข้อความธรรมดา  

## **ตรวจสอบ แก้ไข และลบฟิลด์วันที่/เวลา**

เปลี่ยนฟิลด์ที่มีอยู่ผ่าน [Field.setType](https://reference.aspose.com/slides/th/python-java/aspose.slides/field/#setType) ตรวจสอบว่าฟิลด์มีอยู่ก่อนเข้าถึงประเภทของมัน เพื่อหยุดการอัปเดตอัตโนมัติ ให้เรียก [Portion.removeField](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#removeField) ซึ่งจะคงส่วนและข้อความปัจจุบันไว้ขณะลบการเชื่อมโยงฟิลด์ หากต้องการค่าคงที่เฉพาะ ให้กำหนดข้อความนั้นหลังจากลบฟิลด์  

สำหรับการตั้งค่า API ที่เกี่ยวข้องกับการประมวลผลฟิลด์วันที่/เวลา ดูที่ [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#setCurrentDateTime) ตัวอย่างด้านล่างใช้วันที่การอนุมัติที่ระบุชัดเจนเมื่อแปลงฟิลด์เป็นข้อความธรรมดา  

ดาวน์โหลด [sample.pptx](sample.pptx) แล้ววางไว้ในไดเรกทอรีทำงานไฟล์นี้มีรูปร่างข้อความที่ตั้งชื่อ `UpdatedAt` และ `ApprovedDate` แต่ละรูปร่างมีฟิลด์วันที่/เวลา รวมถึงป้ายกำกับข้อความธรรมดา ตัวอย่างต่อไปนี้วนหารูปร่างข้อความระดับบนบนสไลด์ปกติ เปลี่ยนฟิลด์วันที่/เวลาเป็นรูปแบบวันที่ยาวและทำให้เป็นอิตาลิก พร้อมคงการจัดรูปแบบอื่นไว้ ฟิลด์ใน `ApprovedDate` จะถูกแปลงเป็นข้อความคงที่  

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # ใช้ชื่อเดือนภาษาอังกฤษโดยไม่ขึ้นกับค่าภาษาในระบบ.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

หลังจากเปิดใหม่ `UpdatedAt` มีประเภท `datetime3` และยังคงเป็นค่าที่เปลี่ยนแปลงได้ `ApprovedDate` ไม่มีฟิลด์และมีข้อความ `05 April 2030` ทั้งสองส่วนวันที่เป็นอิตาลิก และขนาดฟอนต์ น้ำหนักตัวหนา และสีดั้งเดิมยังคงอยู่ ป้ายกำกับข้อความธรรมดาไม่เปลี่ยนแปลง การตรวจสอบอ่านส่วนแรกของสองรูปร่างที่รู้จักในตัวอย่างที่ให้มา  

## **คงรูปแบบข้อความ**

ทำงานกับส่วนที่มีอยู่เมื่อต้องเพิ่มฟิลด์ เปลี่ยนประเภทฟิลด์ หรือกำจัดฟิลด์ การทำเช่นนี้จะรักษาการจัดรูปแบบของส่วนนั้น ใช้ [Portion.getPortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getPortionFormat) เพื่อเปลี่ยนเฉพาะคุณสมบัติตามที่ต้องการ เหมือนที่ตัวอย่างทำสำหรับสีหรืออิตาลิก  

หลีกเลี่ยงการสร้างกรอบข้อความใหม่ทั้งหมดเพียงเพื่ออัปเดตฟิลด์เดียว: การทำเช่นนั้นอาจทำให้ขอบเขตส่วนเดิมและการจัดรูปแบบแยกของแต่ละส่วนหายไป และให้แยกความแตกต่างระหว่างการกำหนดรูปแบบโดยตรงกับรูปแบบที่สืบทอดมาจากย่อหน้า เลย์เอาต์ หรือธีม ดูที่ [Text Formatting](/slides/th/python-java/text-formatting/) สำหรับตัวเลือกการจัดรูปแบบที่ครอบคลุมกว่า  

## **ฟิลด์และตัวยึดตำแหน่งหัวเรื่อง/ท้ายกระดาษ**

ฟิลด์เป็นส่วนหนึ่งของส่วนข้อความ ตัวยึดตำแหน่งเป็นรูปร่างที่มีบทบาทในงานนำเสนอ เช่นท้ายกระดาษหรือหมายเลขสไลด์ การเพิ่มฟิลด์ในกล่องข้อความธรรมดาจะไม่ทำให้รูปร่างนั้นกลายเป็นตัวยึดตำแหน่ง  

ตัวจัดการหัวเรื่อง/ท้ายกระดาษควบคุมข้อความตัวยึดตำแหน่งและการมองเห็นบนสไลด์, เลย์เอาต์และมาสเตอร์ รวมถึงการกระจายไปยังสไลด์ที่ขึ้นต่อกัน ฟิลด์หมายเลขในกล่องข้อความกำหนดเองจึงอาจมีประโยชน์แม้ไม่ได้ใช้ตัวยึดตำแหน่งหมายเลขสไลด์ อย่างไรก็ตาม การเปลี่ยนการมองเห็นของตัวยึดตำแหน่งจะไม่ลบฟิลด์ออกจากกล่องข้อความที่ไม่มีความเกี่ยวข้อง  

ประเภทหัวเรื่องและท้ายกระดาษที่กำหนดไว้ล่วงหน้าไม่ได้สร้างตัวยึดตำแหน่งที่สอดคล้องหรือให้เนื้อหาที่กำหนดไว้ โดยเฉพาะสไลด์ PowerPoint ปกติไม่มีตัวยึดตำแหน่งหัวเรื่อง; หัวเรื่องเป็นส่วนของหน้าบันทึกและเอกสารแจกจ่าย อย่าสันนิษฐานว่าฟิลด์หัวเรื่องหรือท้ายกระดาษในรูปร่างใด ๆ จะได้รับข้อความที่กำหนดผ่านตัวจัดการตัวยึดตำแหน่งโดยอัตโนมัติ สำหรับกระบวนการนั้น ดูที่ [Presentation Headers and Footers](/slides/th/python-java/presentation-header-and-footer/)  

## **ข้อจำกัดของ PPTX และ PPT**

ตรวจสอบทั้งประเภทฟิลด์และข้อความที่ได้หลังจากบันทึกและเปิดใหม่ การเก็บตัวระบุไม่ได้พิสูจน์ว่าแอปพลิเคชันสามารถคำนวนหรือแสดงค่าที่ได้  

| รูปแบบ | พฤติกรรมของฟิลด์และข้อจำกัด |
|---|---|
| PPTX | เก็บตัวระบุฟิลด์ภายในพร้อมกับข้อความฟิลด์ ในการตรวจสอบรอบการวนกลับ ประเภทที่กำหนดไว้ล่วงหน้าและตัวระบุที่กำหนดเองข้างต้นยังคงอยู่หลังการบันทึกและเปิดใหม่ ฟิลด์ประเภทที่ไม่รู้จักยังคงแสดงข้อความสำรอง; ไม่ได้เพิ่มตรรกะคำนวนอัตโนมัติ แอปอื่นอาจจัดการตัวระบุที่ไม่สนับสนุนต่างกัน |
| PPT | ใช้การแทนฟิลด์แบบเก่าและมีความเข้ากันได้จำกัดกว่า ในการตรวจสอบรอบการวนกลับ หมายเลขสไลด์และฟิลด์วันที่/เวลาที่กำหนดไว้ล่วงหน้ายังคงอยู่หลังการบันทึกและเปิดใหม่ ฟิลด์กำหนดเองในกล่องข้อความสไลด์ธรรมดาจะเปิดใหม่พร้อมตัวระบุแต่ข้อความเป็น `*`; ฟิลด์หัวเรื่องในบริบทเดียวกันก็เช่นกัน อย่าพึ่งพาฟิลด์กำหนดเองหรือบริบทฟิลด์ที่ไม่สนับสนุนให้คงข้อความที่มองเห็นได้ |

สำหรับผลลัพธ์ที่พกพาและคงที่ ให้แปลงฟิลด์ที่ไม่สนับสนุนเป็นข้อความธรรมดาและกำหนดค่าที่ต้องการอย่างชัดเจนก่อนบันทึก วิธีนี้จะคงข้อความที่เลือกไว้แต่หยุดการอัปเดตอัตโนมัติ ตรวจสอบแอปเป้าหมายด้วยหากการคำนวนฟิลด์ของมันเป็นส่วนหนึ่งของกระบวนการทำงานของคุณ  

## **คำถามที่พบบ่อย**

**ฉันจะบอกได้อย่างไรว่าตัวเลขหรือวันที่ที่แสดงเป็นฟิลด์หรือไม่?**  
ตรวจสอบ [Portion.getField](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#getField) ค่าที่ไม่ใช่ `None` ระบุว่ามีฟิลด์; ไม่สามารถบอกได้จากข้อความที่แสดงเพียงอย่างเดียว  

**การลบฟิลด์จะลบข้อความหรือการจัดรูปแบบของมันด้วยหรือไม่?**  
ไม่ใช่ [removeField](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/#removeField) จะเปลี่ยนส่วนที่มีอยู่ให้เป็นข้อความธรรมดา หากต้องการค่าที่คงที่ให้กำหนดค่าแบบชัดเจนหลังจากลบฟิลด์  

**สตริงภายในสามารถกำหนดรูปแบบวันที่ใหม่หรือสูตรใหม่ได้หรือไม่?**  
ไม่ได้ สตริงภายในเป็นตัวระบุประเภทฟิลด์เท่านั้น ตัวระบุที่ไม่รู้จักไม่ได้มีตัวประเมินหรือรูปแบบวันที่ของ Python ใช้ประเภทที่สนับสนุนหรือจัดรูปแบบค่าด้วยข้อความธรรมดา  

**ทำไมต้องตรวจสอบงานนำเสนออีกครั้งหลังจากบันทึก?**  
ตัวระบุฟิลด์, ข้อความที่คำนวนได้, และการจัดรูปแบบเป็นสิ่งที่ต้องตรวจสอบแยกกัน การแปลงรูปแบบอาจเปลี่ยนผลลัพธ์ที่มองเห็นได้แม้ว่าตัวระบุฟิลด์ยังคงอยู่ก็ตาม  