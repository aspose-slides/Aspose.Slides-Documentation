---
title: จัดการฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย Python
linktitle: ฟิลด์ข้อความ
type: docs
weight: 52
url: /th/python-net/text-fields/
keywords:
- ฟิลด์ข้อความ
- ข้อความอัตโนมัติ
- หมายเลขสไลด์
- วันที่และเวลา
- หัวเรื่อง
- ส่วนท้าย
- ส่วนข้อความ
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "สร้าง ตรวจสอบ แก้ไข และลบฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. รักษาการจัดรูปแบบและตรวจสอบไฟล์ PPTX และ PPT ที่บันทึกไว้."
---
## **ภาพรวม**

ย่อหน้าข้อความประกอบด้วยส่วนต่าง ๆ ส่วนทั่วไป [Portion](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/) มีข้อความตามตัวอักษร; ส่วนฟิลด์ยังมี [Field](https://reference.aspose.com/slides/th/python-net/aspose.slides/field/) ที่ประเภทของมันระบุค่าที่อัปเดตอัตโนมัติ เช่น หมายเลขสไลด์หรือวันที่ ส่วนสองส่วนอาจแสดงอักขระเดียวกันในขณะที่เพียงส่วนเดียวมีฟิลด์.

ใช้ [Portion.field](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/field/) เพื่อแยกความแตกต่าง: ค่าจะเป็น `None` สำหรับข้อความทั่วไป. [Portion.add_field](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/add_field/) แปลงส่วนที่มีอยู่ให้เป็นฟิลด์. เก็บป้ายและค่าที่เปลี่ยนแปลงแยกกันในส่วนต่าง ๆ เพื่อให้การแปลงค่าจะไม่ทำให้ป้ายถูกแทนที่.

คู่มือนี้ครอบคลุมฟิลด์ภายในข้อความ, การจัดรูปแบบของพวกมัน, และการบันทึกเป็น PPTX และ PPT. สำหรับกรอบข้อความและย่อหน้า, ดูที่ [Manage Text](/slides/th/python-net/manage-text/).

## **สร้างฟิลด์หมายเลขสไลด์**

ตัวอย่างเต็มต่อไปนี้สร้างกล่องข้อความที่มีป้าย `Slide ` ตามด้วยตัวเลขที่อัปเดตอัตโนมัติ. จะตั้งค่าขนาด น้ำหนัก และสีของตัวเลขก่อนเพิ่มฟิลด์, จากนั้นเปิดการนำเสนอที่บันทึกไว้ใหม่และตรวจสอบประเภทฟิลด์, ข้อความ, และการจัดรูปแบบ. ไม่จำเป็นต้องใช้ไฟล์อินพุต.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

การนำเสนอใหม่เริ่มต้นด้วยหมายเลขสไลด์ 1, ดังนั้นข้อความคือ `Slide 1`, และการตรวจสอบทั้งสองพิมพ์ `True`. ตัวเลขยังคงเป็นฟิลด์หลังจากเปิดใหม่; มันไม่ใช่ข้อความ `1` ตามตัวอักษร. ดัชนีในการตรวจสอบอ้างถึงรูปร่างและส่วนที่สร้างโดยตัวอย่างนี้.

## **เลือกประเภทฟิลด์**

[FieldType](https://reference.aspose.com/slides/th/python-net/aspose.slides/fieldtype/) มีค่าที่กำหนดไว้ล่วงหน้าดังต่อไปนี้. ส่งค่าที่เหมาะสมไปยัง [add_field](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/add_field/).

| ค่า | วัตถุประสงค์ |
|---|---|
| [slide_number](https://reference.aspose.com/slides/th/python-net/aspose.slides/fieldtype/slide_number/) | หมายเลขสไลด์ปัจจุบัน. |
| [date_time](https://reference.aspose.com/slides/th/python-net/aspose.slides/fieldtype/date_time/) | วันที่/เวลาในรูปแบบเริ่มต้นของแอปพลิเคชันที่เรนเดอร์ |
| [date_time1](https://reference.aspose.com/slides/th/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/th/python-net/aspose.slides/fieldtype/date_time9/) | รูปแบบวันที่หรือรูปแบบวันที่/เวลาที่กำหนดไว้ล่วงหน้า |
| [date_time10](https://reference.aspose.com/slides/th/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/th/python-net/aspose.slides/fieldtype/date_time13/) | รูปแบบเวลาที่กำหนดไว้ล่วงหน้า, มีตัวเลือกสำหรับวินาทีและนาฬิกา 12 ชั่วโมง |
| [header](https://reference.aspose.com/slides/th/python-net/aspose.slides/fieldtype/header/) | ฟิลด์หัวเรื่อง; ดูข้อจำกัดของตัวแปรและรูปแบบด้านล่าง |
| [footer](https://reference.aspose.com/slides/th/python-net/aspose.slides/fieldtype/footer/) | ฟิลด์ท้ายกระดาษ. |

ตัวอย่างเช่น, [date_time3](https://reference.aspose.com/slides/th/python-net/aspose.slides/fieldtype/date_time3/) แทนวัน, ชื่อเดือนเต็ม, และปีในภาษาอังกฤษ. เหล่านี้เป็นรูปแบบฟิลด์ที่กำหนดไว้ล่วงหน้า, ไม่ใช่สตริงรูปแบบวันที่ของ Python ใด ๆ. [language_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/language_id/) ของส่วนและแอปพลิเคชันที่ประมวลผลการนำเสนออาจส่งผลต่อผลลัพธ์ที่แสดง.

## **สร้างฟิลด์จากสตริงภายใน**

การ overload ด้วยสตริงของ [add_field](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/add_field/) ยอมรับตัวระบุฟิลด์ภายใน. ใช้เมื่อต้องเก็บตัวระบุที่มาจากแอปพลิเคชันอื่นที่ไม่มีค่าที่กำหนดไว้ล่วงหน้า. คุณยังสามารถสร้าง [FieldType](https://reference.aspose.com/slides/th/python-net/aspose.slides/fieldtype/__init__/) จากตัวระบุนั้น. [FieldType.internal_string](https://reference.aspose.com/slides/th/python-net/aspose.slides/fieldtype/internal_string/) แสดงตัวระบุนั้นสำหรับการตรวจสอบ.

ตัวอย่างนี้เก็บฟิลด์ `custom-report-id` ที่เฉพาะแอปพลิเคชันพร้อมข้อความสำรอง `Report-042`. ตัวระไม่ได้ลงทะเบียนการคำนวณ: Aspose.Slides ไม่สร้าง ID รายงานสำหรับประเภทที่ไม่ทราบ. แอปพลิเคชันที่เข้าใจตัวระบุต้องกำหนดความหมายและอัปเดตค่าของมัน.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

หลังจากรอบการทำงาน PPTX นี้, ประเภทคือ `custom-report-id` และข้อความคือ `Report-042`. การส่งสตริงเช่น `%Y-%m-%d` จะตั้งชื่อประเภทฟิลด์; ไม่ได้กำหนดรูปแบบวันที่แบบกำหนดเอง. สำหรับวันที่คงที่ในรูปแบบใดก็ได้, ใช้ข้อความทั่วไป.

## **ตรวจสอบ, แก้ไข, และลบฟิลด์วันที่/เวลา**

อ่านและเปลี่ยนฟิลด์ที่มีอยู่ผ่าน [Field.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/field/type/). ตรวจสอบว่าฟิลด์มีอยู่ก่อนเข้าถึงประเภทของมัน. เพื่อหยุดการอัปเดตอัตโนมัติ, เรียก [Portion.remove_field](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/remove_field/). วิธีนี้จะเก็บส่วนและข้อความปัจจุบันไว้ขณะลบการเชื่อมโยงฟิลด์. หากต้องการค่าคงที่เฉพาะ, กำหนดข้อความนั้นหลังจากลบฟิลด์.

สำหรับการตั้งค่า API ที่เกี่ยวข้องกับการประมวลผลฟิลด์วันที่/เวลา, ดูที่ [Presentation.current_date_time](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/current_date_time/). ตัวอย่างด้านล่างใช้วันที่อนุมัติอย่างชัดเจนเมื่อแปลงฟิลด์เป็นข้อความทั่วไป. ทูเพิลชื่อเดือนภาษาอังกฤษทำให้วันที่คงที่ไม่ขึ้นกับ locale ของระบบ.

ดาวน์โหลด [sample.pptx](sample.pptx) แล้ววางไว้ในไดเรกทอรีทำงาน. ไฟล์นี้มีรูปข้อความสองรูปที่มีชื่อ `UpdatedAt` และ `ApprovedDate`, แต่ละรูปมีฟิลด์วันที่/เวลา, พร้อมป้ายข้อความทั่วไป. ตัวอย่างต่อไปนี้เดินผ่านรูปข้อความระดับบนของสไลด์ปกติ. มันเปลี่ยนฟิลด์วันที่/เวลาเป็นรูปแบบวันยาวและทำให้เป็นตัวเอียง, ขณะรักษาการจัดรูปแบบอื่น ๆ. เฉพาะฟิลด์ใน `ApprovedDate` จะกลายเป็นข้อความคงที่.

ตัวอย่างนี้รับรู้ตัวระบุภายในที่สร้างไว้ `datetime` ถึง `datetime13`. กลุ่ม, ตาราง, โน้ต, เลย์เอาท์, และมาสเตอร์ต้องการการเดินทางผ่านคอนเทนเนอร์ข้อความของตนเองและอยู่นอกขอบเขตของตัวอย่างนี้.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not not {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

หลังจากเปิดใหม่, `UpdatedAt` มีประเภท `datetime3` และยังคงเป็นแบบไดนามิก. `ApprovedDate` ไม่มีฟิลด์และมีข้อความ `05 April 2030`. ส่วนวันที่ทั้งสองเป็นตัวเอียง, และขนาดฟอนต์, การตั้งค่าหนา, และสีเดิมยังคงอยู่. ป้ายข้อความทั่วไปไม่เปลี่ยนแปลง. การตรวจสอบอ่านส่วนแรกของสองรูปที่รู้จักในตัวอย่างที่ให้มา.

## **รักษาการจัดรูปแบบข้อความ**

ทำงานกับส่วนที่มีอยู่เมื่อเพิ่มฟิลด์, เปลี่ยนประเภท, หรือทำการลบ. การดำเนินการเหล่านี้รักษาการจัดรูปแบบของส่วนนั้น. ใช้ [Portion.portion_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/portion_format/) เพื่อเปลี่ยนเฉพาะคุณสมบัติที่ต้องการ, เช่น ตัวอย่างที่ทำสำหรับสีหรือการเอียง.

หลีกเลี่ยงการสร้างกรอบข้อความทั้งหมดใหม่เพื่ออัปเดตฟิลด์เดียว: การทำเช่นนั้นอาจสูญเสียขอบเขตส่วนเดิมและการจัดรูปแบบแยกของแต่ละส่วน. นอกจากนี้ให้แยกความแตกต่างระหว่างการตั้งค่าการจัดรูปแบบโดยชัดเจนกับการจัดรูปแบบที่สืบทอดจากพารากราฟ, เลย์เอาท์, หรือธีม. ดูที่ [Text Formatting](/slides/th/python-net/text-formatting/) สำหรับตัวเลือกการจัดรูปแบบที่กว้างขึ้น.

## **ฟิลด์และตัวแปรที่เป็น Header/Footer**

ฟิลด์เป็นส่วนหนึ่งของส่วนข้อความ. ตัวแปร (placeholder) คือรูปที่มีบทบาทในงานนำเสนอ, เช่น ส่วนท้ายหรือหมายเลขสไลด์. การเพิ่มฟิลด์ลงในกล่องข้อความทั่วไปจะไม่ทำให้รูปร่างนั้นกลายเป็นตัวแปร.

ผู้จัดการ header/footer ควบคุมข้อความตัวแปรและการมองเห็นบนสไลด์, เลย์เอาท์, และมาสเตอร์, รวมถึงการกระจายไปยังสไลด์ที่ขึ้นอยู่. ฟิลด์ตัวเลขในกล่องข้อความที่กำหนดเองจึงเป็นประโยชน์แม้คุณไม่ได้ใช้ตัวแปรหมายเลขสไลด์. ในทางกลับกัน, การเปลี่ยนการมองเห็นของตัวแปรจะไม่ลบฟิลด์จากกล่องข้อความที่ไม่เกี่ยวข้อง.

ประเภท header และ footer ที่กำหนดไว้ล่วงหน้าไม่ได้สร้างตัวแปรที่สอดคล้องหรือให้เนื้อหา. โดยเฉพาะ, สไลด์ PowerPoint ปกติไม่มีตัวแปร header; header อยู่ในหน้าโน้ตและเอกสารแจก. อย่าสันนิษฐานว่าฟิลด์ header หรือ footer ในรูปร่างใด ๆ จะได้ข้อความที่กำหนดผ่านผู้จัดการตัวแปรโดยอัตโนมัติ. สำหรับกระบวนการทำงานนั้น, ดูที่ [Presentation Headers and Footers](/slides/th/python-net/presentation-header-and-footer/).

## **ข้อจำกัดของ PPTX และ PPT**

ตรวจสอบทั้งประเภทฟิลด์และข้อความที่ได้หลังจากบันทึกและเปิดใหม่. การเก็บตัวระบุไม่ได้พิสูจน์ว่าแอปพลิเคชันสามารถคำนวณหรือแสดงค่าได้.

| รูปแบบ | พฤติกรรมฟิลด์และข้อจำกัด |
|---|---|
| PPTX | เก็บตัวระบุฟิลด์ภายในพร้อมกับข้อความฟิลด์. ในการตรวจสอบรอบการทำงาน, ประเภทที่กำหนดไว้ล่วงหน้าและตัวระบุกำหนดเองที่ใช้ข้างต้นยังคงอยู่หลังบันทึกและเปิดใหม่. ประเภทกำหนดเองที่ไม่รู้จักเก็บข้อความสำรอง; ไม่ได้รับตรรกะการคำนวณอัตโนมัติ. แอปพลิเคชันอื่นอาจจัดการกับตัวระบุที่ไม่สนับสนุนแตกต่างกัน. |
| PPT | ใช้การแทนฟิลด์แบบเก่าและมีความเข้ากันได้จำกัดมากขึ้น. ในการตรวจสอบรอบการทำงาน, ฟิลด์หมายเลขสไลด์และฟิลด์วันที่/เวลาที่กำหนดไว้ล่วงหน้ายังคงอยู่หลังบันทึกและเปิดใหม่. ฟิลด์กำหนดเองในกล่องข้อความสไลด์ทั่วไปเปิดใหม่โดยมีตัวระบุแต่ข้อความเป็น `*`; ฟิลด์ header ในบริบทเดียวกันก็ให้ `*`. อย่าอาศัยฟิลด์กำหนดเองหรือบริบทฟิลด์ที่ไม่ได้สนับสนุนในการเก็บข้อความที่มองเห็นได้. |

สำหรับผลลัพธ์ที่พกพาและคงที่, แปลงฟิลด์ที่ไม่รองรับเป็นข้อความทั่วไปและกำหนดค่าที่ต้องการก่อนบันทึก. วิธีนี้จะรักษาข้อความที่เลือกไว้แต่หยุดการอัปเดตอัตโนมัติอย่างตั้งใจ. ทดสอบแอปพลิเคชันเป้าหมายด้วยเช่นกันเมื่อการคำนวณฟิลด์ของมันเป็นส่วนหนึ่งของกระบวนการทำงานของคุณ.

## **คำถามที่พบบ่อย**

**ฉันจะรู้ได้อย่างไรว่าตัวเลขหรือวันที่ที่แสดงเป็นฟิลด์หรือไม่?**

ตรวจสอบ [Portion.field](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/field/). ค่าที่ไม่ใช่ `None` ระบุว่เป็นฟิลด์; ข้อความที่แสดงอย่างเดียวไม่สามารถบอกได้.

**การลบฟิลด์จะลบข้อความหรือการจัดรูปแบบหรือไม่?**

ไม่. [remove_field](https://reference.aspose.com/slides/th/python-net/aspose.slides/portion/remove_field/) แปลงส่วนที่มีอยู่เป็นข้อความทั่วไป. กำหนดค่าที่ชัดเจนต่อไปหากต้องการวันที่คงที่หรือค่าสำรองเฉพาะ.

**สตริงภายในสามารถกำหนดรูปแบบวันที่หรือสูตรใหม่ได้หรือไม่?**

ไม่. มันระบุประเภทฟิลด์. ตัวระบุที่ไม่รู้จักไม่ได้ให้ตัวประเมินหรือรูปแบบวันที่ของ Python. ใช้ประเภทที่กำหนดไว้ล่วงหน้าที่รองรับ หรือจัดรูปแบบค่าด้วยตนเองเป็นข้อความทั่วไป.

**ทำไมต้องตรวจสอบการนำเสนออีกครั้งหลังจากบันทึก?**

ตัวระบุฟิลด์, ข้อความที่คำนวณ, และการจัดรูปแบบเป็นสิ่งที่ต้องตรวจสอบแยกกัน. การแปลงรูปแบบอาจทำให้ผลลัพธ์ที่มองเห็นเปลี่ยนแปลงได้แม้ตัวระบุฟิลด์ยังคงอยู่.