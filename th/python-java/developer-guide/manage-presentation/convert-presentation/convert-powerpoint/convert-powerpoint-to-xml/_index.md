---
title: แปลงงานนำเสนอ PowerPoint เป็น XML ใน Python ผ่าน Java
linktitle: PowerPoint เป็น XML
type: docs
weight: 145
url: /th/python-java/convert-powerpoint-to-xml/
keywords:
- แปลง PowerPoint เป็น XML
- แปลงงานนำเสนอเป็น XML
- PPT เป็น XML
- PPTX เป็น XML
- ODP เป็น XML
- PowerPoint XML Presentation
- SaveFormat.Xml
- บันทึกงานนำเสนอเป็น XML
- ส่งออกงานนำเสนอเป็น XML
- สตรีม XML
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีม PowerPoint XML ใน Python ผ่าน Java ด้วย Aspose.Slides for Python via Java."
---
## **ภาพรวม**

Aspose.Slides for Python via Java สามารถแปลงงานนำเสนอ PowerPoint ไปเป็นรูปแบบ PowerPoint XML Presentation ได้ ผลลัพธ์เป็น XML มีประโยชน์เมื่อคุณต้องการตัวแทนแบบข้อความเพื่อวิเคราะห์โครงสร้างของงานนำเสนอ แก้ไขปัญหาเอกสารที่สร้างขึ้น เปรียบเทียบผลลัพธ์ในการทดสอบอัตโนมัติ หรือรวมเข้ากับกระบวนการทำงานที่ใช้ XML แทนแพ็กเกจงานนำเสนอ

ใช้เมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) พร้อมค่าที่เป็น [Xml](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Xml) จากคลาส [SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/) คุณสามารถเขียนผลลัพธ์ลงไฟล์โดยตรงหรือไปยังสตรีมได้

{{% alert color="info" title="Note" %}}
[SaveFormat.Xml](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Xml) สร้าง PowerPoint XML Presentation ไม่ได้สกัดส่วนประกอบ Office Open XML แยกต่างหากที่เก็บอยู่ในแพ็กเกจ PPTX หากคุณต้องการส่วนของแพ็กเกจ PPTX อย่างแม่นยำ เช่น `ppt/presentation.xml` หรือไฟล์ XML ของสไลด์แต่ละไฟล์ ให้ตรวจสอบแพ็กเกจ PPTX โดยตรง
{{% /alert %}}

## **แปลงงานนำเสนอเป็นไฟล์ XML**

โหลดงานนำเสนอแหล่งที่มาด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) แล้วส่งเส้นทางผลลัพธ์และ [SaveFormat.Xml](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Xml) ไปยัง [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) แหล่งที่มาสามารถเป็นรูปแบบงานนำเสนอใด ๆ ที่รองรับการโหลดได้ เช่น PPT, PPTX หรือ ODP

ตัวอย่างต่อไปนี้แปลงงานนำเสนอ PPTX ไปเป็นไฟล์ XML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **เขียนผลลัพธ์ XML ไปยังสตรีม**

ใช้รูปแบบเมธอดที่รับสตรีมของ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) เมื่อ XML ต้องคงอยู่ในหน่วยความจำหรือส่งต่อไปยังองค์ประกอบอื่น เช่น บริการเว็บ ผู้ให้บริการเก็บข้อมูล หรือสภาพแวดล้อมการประมวลผล XML ตัวอย่างต่อไปนี้เขียนผลลัพธ์ไปยัง [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) และได้ XML ที่ได้เป็นวัตถุ bytes ของ Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # ส่ง xml_data ไปยังส่วนประกอบถัดไปในกระบวนการทำงาน.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **เปรียบเทียบ XML กับรูปแบบงานนำเสนอและการส่งออก**

เลือกรูปแบบผลลัพธ์ตามวิธีการใช้งาน:

| รูปแบบ | ผลลัพธ์ | การใช้งานทั่วไป |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | ตรวจสอบโครงสร้าง, แก้ไขปัญหา, เปรียบเทียบผลลัพธ์ที่สร้าง, และการรวม XML |
| PPT (`.ppt`) | ไฟล์งานนำเสนอไบนารีแบบเก่า | ความเข้ากันได้กับกระบวนการทำงาน PowerPoint รุ่นเก่า |
| PPTX (`.pptx`) | แพ็กเกจ Office Open XML ที่มีหลายส่วน | การแก้ไข PowerPoint ปกติและการแลกเปลี่ยนงานนำเสนอ |
| PDF หรือ TIFF | หน้าแบบเลย์เอาต์คงที่หรือภาพหลายหน้า | ดู, พิมพ์, และเก็บถาวร |
| PNG, JPEG หรือ SVG | ตัวแทนการเรนเดอร์ของสไลด์เดี่ยว | รูปย่อ, ตัวอย่าง, และสินทรัพย์รูปภาพ |
| HTML หรือ HTML5 | ผลลัพธ์งานนำเสนอแบบเว็บ | ดูในเบราว์เซอร์และเผยแพร่บนเว็บ |

ต่างจาก PPT และ PPTX, ผลลัพธ์ XML มีจุดประสงค์หลักเพื่อการตรวจสอบและกระบวนการทำงานด้านข้อมูล ส่วนต่างจาก PDF, TIFF, HTML และรูปแบบภาพสไลด์, XML แสดงข้อมูลงานนำเสนอไม่ใช่การเรนเดอร์สไลด์เป็นหน้าหรือสินทรัพย์ภาพ ตาราง [supported file formats](/slides/th/python-java/supported-file-formats/) ระบุ PowerPoint XML Presentation เป็นรูปแบบที่บันทึกได้เท่านั้น ดังนั้นห้ามใช้เมื่อกระบวนการทำงานต้องโหลดไฟล์ที่ส่งออกกลับเข้าสู่ Aspose.Slides เพื่อแก้ไขต่อ

## **คำถามที่พบบ่อย**

**การส่งออก XML เป็นเช่นเดียวกับการบันทึกไฟล์ PPTX หรือไม่?**

ไม่ใช่ PPTX เป็นแพ็กเกจที่มีหลายส่วน Office Open XML ส่วน [SaveFormat.Xml](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Xml) สร้างไฟล์ PowerPoint XML Presentation

**ฉันสามารถบันทึกผลลัพธ์ XML โดยไม่สร้างไฟล์บนดิสก์ได้หรือไม่?**

ได้ ส่งสตรีมออกของ Java ที่สามารถเขียนได้ไปยัง [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ตัวอย่างเช่น ใช้ [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) เพื่อประมวลผลในหน่วยความจำ

**Aspose.Slides สามารถโหลดไฟล์ XML ที่ส่งออกอีกครั้งได้หรือไม่?**

ไม่ได้ PowerPoint XML Presentation ปัจจุบันรองรับการบันทึกเท่านั้น ไม่รองรับการโหลด ใช้ PPTX หรือรูปแบบงานนำเสนอที่รองรับอื่นเมื่อจำเป็นต้องทำการแก้ไขรอบลูป

**การแปลงเป็น XML ทำการเรนเดอร์สไลด์แต่ละสไลด์เป็นหน้า หรือภาพหรือไม่?**

ไม่ การแปลงเป็น XML จะเขียนข้อมูลงานนำเสนอที่มีโครงสร้าง ใช้ PDF หรือ TIFF สำหรับผลลัพธ์แบบหน้า หรือ PNG, JPEG, และ SVG สำหรับภาพสไลด์เดี่ยว