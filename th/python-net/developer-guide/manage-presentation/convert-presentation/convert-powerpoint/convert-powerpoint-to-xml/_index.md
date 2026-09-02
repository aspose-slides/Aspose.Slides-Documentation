---
title: แปลงงานนำเสนอ PowerPoint เป็น XML ด้วย Python
linktitle: PowerPoint เป็น XML
type: docs
weight: 145
url: /th/python-net/convert-powerpoint-to-xml/
keywords:
- แปลง PowerPoint เป็น XML
- แปลงงานนำเสนอเป็น XML
- PPT เป็น XML
- PPTX เป็น XML
- ODP เป็น XML
- งานนำเสนอ PowerPoint XML
- SaveFormat.XML
- บันทึกงานนำเสนอเป็น XML
- ส่งออกงานนำเสนอเป็น XML
- สตรีม XML
- Python
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีม PowerPoint XML ด้วย Python และ Aspose.Slides."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET สามารถแปลงงานนำเสนอ PowerPoint เป็นรูปแบบ PowerPoint XML Presentation ได้ ผลลัพธ์ XML มีประโยชน์เมื่อคุณต้องการการแทนค่าที่เป็นข้อความสำหรับการตรวจสอบโครงสร้างของงานนำเสนอ การแก้ไขปัญหาเอกสารที่สร้างขึ้น การเปรียบเทียบผลลัพธ์ในการทดสอบอัตโนมัติ หรือการบูรณาการกับกระบวนการทำงานที่ใช้ XML แทนแพ็กเกจงานนำเสนอ

ใช้เมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) กับค่า `XML` จากการอธิบายของ [SaveFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/) คุณสามารถเขียนผลลัพธ์โดยตรงไปยังไฟล์หรือสตรีมได้

{{% alert color="info" title="Note" %}}
`SaveFormat.XML` สร้าง PowerPoint XML Presentation ไม่ได้สกัดส่วนย่อยของ Office Open XML ที่เก็บอยู่ภายในแพ็กเกจ PPTX หากคุณต้องการส่วนของแพ็กเกจ PPTX อย่างแม่นยำ เช่น `ppt/presentation.xml` หรือไฟล์ XML ของสไลด์แต่ละไฟล์ ให้ตรวจสอบแพ็กเกจ PPTX เอง
{{% /alert %}}

## **แปลงงานนำเสนอเป็นไฟล์ XML**

โหลดงานนำเสนอต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วส่งเส้นทางไฟล์ผลลัพธ์และ `SaveFormat.XML` ไปยัง [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) แหล่งที่มาสามารถเป็นรูปแบบงานนำเสนอใดก็ได้ที่รองรับการโหลด เช่น PPT, PPTX หรือ ODP

ตัวอย่างต่อไปนี้แปลงงานนำเสนอ PPTX เป็นไฟล์ XML:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **เขียนผลลัพธ์ XML ไปยังสตรีม**

ใช้ overload แบบสตรีมของ [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) เมื่อ XML ต้องคงอยู่ในหน่วยความจำหรือส่งต่อไปยังส่วนประกอบอื่น เช่น เว็บเซอร์วิส ผู้ให้บริการจัดเก็บข้อมูล หรือ pipeline การประมวลผล XML ตัวอย่างต่อไปนี้เขียนผลลัพธ์ไปยังสตรีม [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) และย้อนกลับสตรีมเพื่ออ่านต่อ

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # ส่ง xml_stream ไปยังส่วนประกอบถัดไปในกระบวนการทำงาน.
```

## **เปรียบเทียบ XML กับรูปแบบงานนำเสนอและการส่งออก**

เลือกรูปแบบผลลัพธ์ตามวิธีการที่ผลลัพธ์จะถูกใช้:

| รูปแบบ | ผลลัพธ์ | การใช้ทั่วไป |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | การนำเสนอ PowerPoint XML | การตรวจสอบโครงสร้าง, การแก้ไขปัญหา, การเปรียบเทียบผลลัพธ์ที่สร้างขึ้น, และการบูรณาการแบบ XML |
| PPT (`.ppt`) | ไฟล์งานนำเสนอไบนารีแบบเก่า | ความเข้ากันได้กับกระบวนการทำงาน PowerPoint รุ่นเก่า |
| PPTX (`.pptx`) | แพ็กเกจ Office Open XML ที่ประกอบด้วยหลายส่วน | การแก้ไข PowerPoint ปกติและการแลกเปลี่ยนงานนำเสนอ |
| PDF หรือ TIFF | หน้าแบบเลย์เอาต์คงที่หรือภาพหลายหน้า | การดู, การพิมพ์, และการจัดเก็บ |
| PNG, JPEG หรือ SVG | การแสดงผลสไลด์แต่ละสไลด์แบบเรนเดอร์ | ภาพย่อ, ตัวอย่าง, และทรัพยากรภาพ |
| HTML หรือ HTML5 | ผลลัพธ์งานนำเสนอแบบเว็บ | การดูในเบราว์เซอร์และการเผยแพร่บนเว็บ |

ต่างจาก PPT และ PPTX, ผลลัพธ์ XML มีวัตถุประสงค์หลักเพื่อการตรวจสอบและกระบวนการทำงานแบบข้อมูลเป็นหลัก ต่างจาก PDF, TIFF, HTML, และรูปแบบภาพสไลด์, มันเป็นการแทนค่าข้อมูลงานนำเสนอแทนการเรนเดอร์สไลด์เป็นหน้า หรือเป็นสินทรัพย์ภาพ ตาราง [supported file formats](/slides/th/python-net/supported-file-formats/) ระบุว่า PowerPoint XML Presentation เป็นรูปแบบที่บันทึกได้เท่านั้น ดังนั้นห้ามใช้เมื่อกระบวนการทำงานต้องโหลดไฟล์ที่ส่งออกกลับเข้าสู่ Aspose.Slides เพื่อแก้ไขต่อ

## **คำถามที่พบบ่อย**

**`SaveFormat.XML` เป็นเช่นเดียวกับการบันทึกไฟล์ PPTX หรือไม่?**  
ไม่ใช่. PPTX เป็นแพ็กเกจที่ประกอบด้วยหลายส่วนของ Office Open XML ในขณะที่ `SaveFormat.XML` สร้างไฟล์ PowerPoint XML Presentation

**ฉันสามารถบันทึกผลลัพธ์ XML โดยไม่ต้องสร้างไฟล์บนดิสก์ได้หรือไม่?**  
ใช่. ส่งสตรีมที่สามารถเขียนได้ไปยัง [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) ตัวอย่างเช่น ใช้สตรีม [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) สำหรับการประมวลผลในหน่วยความจำ

**Aspose.Slides สามารถโหลดไฟล์ XML ที่ส่งออกได้อีกหรือไม่?**  
ไม่ใช่. PowerPoint XML Presentation ปัจจุบันรองรับการบันทึกเท่านั้น ไม่รองรับการโหลด ใช้ PPTX หรือรูปแบบงานนำเสนอที่รองรับอื่นเมื่อจำเป็นต้องแก้ไขแบบรอบลูป

**การแปลงเป็น XML ทำให้แต่ละสไลด์แสดงเป็นหน้า หรือภาพหรือไม่?**  
ไม่ใช่. การแปลงเป็น XML จะเขียนข้อมูลงานนำเสนอที่มีโครงสร้าง ใช้ PDF หรือ TIFF สำหรับผลลัพธ์แบบหน้า หรือ PNG, JPEG, และ SVG สำหรับภาพสไลด์แต่ละภาพ