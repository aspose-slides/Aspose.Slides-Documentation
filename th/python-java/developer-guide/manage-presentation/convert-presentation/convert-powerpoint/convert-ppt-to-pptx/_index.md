---
title: แปลง PPT เป็น PPTX ด้วย Python
linktitle: PPT เป็น PPTX
type: docs
weight: 20
url: /th/python-java/convert-ppt-to-pptx/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- PPT เป็น PPTX
- บันทึก PPT เป็น PPTX
- ส่งออก PPT ไปยัง PPTX
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT รุ่นเก่าเป็น PPTX ด้วย Python และ Aspose.Slides. รวมตัวอย่าง Python สำหรับการแปลงไฟล์เดี่ยวและแบบชุด, การจัดการข้อผิดพลาด, และบันทึกความแม่นยำ."
---
## **ภาพรวม**

PPT เป็นรูปแบบไบนารีเก่าของ PowerPoint, ขณะที่ PPTX เป็นรูปแบบ Open XML แบบใหม่. Aspose.Slides สำหรับ Python ผ่าน Java สามารถโหลดไฟล์ PPT แล้วบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint. บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือไดเรกทอรีของไฟล์และอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง.

แต่ละตัวอย่างจะเริ่มเครื่องเสมือน Java หากจำเป็นและจะปล่อยการนำเสนอหลังการใช้. เปลี่ยนเส้นทางตัวอย่างให้เป็นเส้นทางไฟล์หรือไดเรกทอรีของคุณเอง.

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) จากนั้นเรียก [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) พร้อมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Pptx). บล็อก `finally` จะทำลายการนำเสนอและปล่อยทรัพยากรของมัน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# โหลดการนำเสนอ PPT รุ่นเก่า.
presentation = Presentation("presentation.ppt")
try:
    # บันทึกการนำเสนอในรูปแบบ PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ส่วนขยายไฟล์ไม่ได้กำหนดรูปแบบเอาต์พุตโดยอัตโนมัติ; อาร์กิวเมนต์ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Pptx) ทำหน้าที่นั้น. รักษาเส้นทางอินพุตและเอาต์พุตให้ต่างกัน หากคุณต้องการเก็บไฟล์ PPT ดั้งเดิมไว้.

## **แปลงหลายไฟล์ PPT**

ตัวอย่างต่อไปนี้จะแปลงไฟล์ `.ppt` ทุกไฟล์ในหนึ่งไดเรกทอรี. แต่ละไฟล์จะถูกประมวลผลแยกกัน, ดังนั้นการแปลงที่ล้มเหลวหนึ่งไฟล์จะไม่ทำให้ชุดงานที่เหลือหยุด.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

สำหรับงานในสภาพการผลิต, ให้บันทึกข้อยกเว้นทั้งหมด, ตัดสินใจว่าจะเขียนทับไฟล์เอาต์พุตที่มีอยู่หรือไม่, และเขียนชื่อไฟล์ที่ล้มเหลวลงในคิวลองใหม่หรือคิวตรวจสอบ. ไฟล์ที่เสียหาย, ไฟล์ที่มีการป้องกันด้วยรหัสผ่านที่เปิดโดยไม่มีรหัสผ่านที่จำเป็น, เส้นทางที่เข้าถึงไม่ได้, และเนื้อหาที่ไม่สนับสนุนทั้งหมดอาจทำให้การแปลงล้มเหลว. ดูที่ [Password-Protected Presentations](/slides/th/python-java/password-protected-presentation/) สำหรับการโหลดไฟล์ที่เข้ารหัส.

## **ความแม่นยำและคุณลักษณะเดิม**

การแปลงโดยปกติจะคงสไลด์, มาสเตอร์, เลย์เอาต์, ข้อความ, รูปร่าง, รูปภาพ, ตาราง, และแผนภูมิ. อย่างไรก็ตาม, PPT และ PPTX ไม่ได้แสดงคุณลักษณะทุกอย่างในลักษณะเดียวกันอย่างแม่นยำ. คุณลักษณะเดิมที่ไม่มีเทียบเท่าใน PPTX หรือไม่ได้รับการสนับสนุนจากไลบรารีอาจถูกทำให้เป็นมาตรฐาน, ลบออก, หรือแสดงแตกต่างกัน.

ตรวจสอบไฟล์ที่แปลงเมื่อมีแอนิเมชัน, การเปลี่ยนฉาก, วัตถุ OLE ที่ฝังหรือเชื่อมโยง, คอนโทรล ActiveX, สื่อฝัง, ฟอนต์ที่ไม่ทั่วไป, หรือแมโคร VBA. ไฟล์ PPTX ปกติไม่ใช่รูปแบบที่รองรับแมโคร, ดังนั้นให้ใช้เวิร์กโฟลว์ที่รองรับแมโครเมื่อจำเป็นต้องใช้ VBA. นอกจากนี้ให้ตรวจสอบว่าฟอนต์ที่ต้องการและทรัพยากรภายนอกมีอยู่ในสภาพแวดล้อมที่การนำเสนอที่แปลงจะถูกเปิดหรือเรนเดอร์.

สำหรับเอกสารที่สำคัญ, ให้เปิดไฟล์ PPTX ที่สร้างขึ้นใหม่โดยใช้โปรแกรมและตรวจสอบจำนวนสไลด์สำคัญและเนื้อหา, จากนั้นเปรียบเทียบลักษณะและพฤติกรรมการแสดงสไลด์ในผู้ชมที่ตั้งใจ. อย่าพิจารณาการเรียก [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ที่สำเร็จว่าเป็นหลักฐานว่าคุณลักษณะเดิมทุกอย่างมีการแทนที่ใน PPTX อย่างแม่นยำ.

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน, มีการแลกเปลี่ยนกับระบบที่ทำงานกับแพคเกจ Open XML, หรือถูกจัดเก็บในรูปแบบที่ง่ายต่อการตรวจสอบและกู้คืนกว่า PPT ไบนารีเก่า. เก็บไฟล์ PPT ดั้งเดิมเป็นสำเนาถาวรหรือสำเนากลับคืนจนกว่าการนำเสนอที่แปลงจะผ่านการตรวจสอบความแม่นยำของคุณ.

หากคุณต้องการ PDF, HTML, รูปภาพ, XPS, หรือรูปแบบเอาต์พุตอื่นแทน, ให้ใช้คำแนะนำเฉพาะรูปแบบใน [Convert Presentations to Multiple Formats](/slides/th/python-java/convert-presentation/) แทนการสันนิษฐานว่าทุกเป้าหมายจะคงคุณลักษณะ PowerPoint ที่แก้ไขได้.

## **ตัวแปลงออนไลน์**

สำหรับไฟล์ที่ทำเป็นครั้งคราวหรือการเปรียบเทียบอย่างรวดเร็ว, คุณสามารถใช้ [ตัวแปลง PPT เป็น PPTX ออนไลน์](https://products.aspose.app/slides/th/conversion/ppt-to-pptx). สำหรับการแปลงที่ทำซ้ำได้, การประมวลผลเป็นชุด, หรือการจัดการข้อผิดพลาดในระดับแอปพลิเคชัน, ให้ใช้ API Python ผ่าน Java.

## **บทความที่เกี่ยวข้อง**

- [PPT vs PPTX](/slides/th/python-java/ppt-vs-pptx/)
- [บันทึกการนำเสนอใน Python](/slides/th/python-java/save-presentation/)
- [รูปแบบไฟล์ที่รองรับ](/slides/th/python-java/supported-file-formats/)
- [เปิดการนำเสนอใน Python](/slides/th/python-java/open-presentation/)

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลง PPT เป็น PPTX ได้โดยไม่ได้ติดตั้ง Microsoft PowerPoint หรือไม่?**

ใช่. Aspose.Slides สำหรับ Python ผ่าน Java สามารถโหลดและบันทึกไฟล์การนำเสนอได้โดยไม่ต้องการ Microsoft PowerPoint.

**การแปลงจาก PPT เป็น PPTX จะคงเนื้อหาทั้งหมดอย่างแม่นยำหรือไม่?**

มันจะคงเนื้อหาการนำเสนอทั่วไป, แต่ความแม่นยำอย่างเต็มที่ไม่สามารถรับประกันได้สำหรับทุกคุณลักษณะเดิมหรือคุณลักษณะที่ไม่รองรับ. ตรวจสอบไฟล์ที่สร้างขึ้นเมื่อมีแมโคร, วัตถุ OLE หรือ ActiveX, สื่อ, แอนิเมชันเฉพาะ, หรือฟอนต์ที่ไม่ทั่วไป.

**ฉันสามารถแปลงไฟล์ PPT ที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้, หากคุณระบุรหัสผ่านที่ถูกต้องเมื่อต้องโหลดไฟล์. การขาดหรือรหัสผ่านไม่ถูกต้องจะทำให้การโหลดล้มเหลว.

**ฉันควรลบไฟล์ PPT หลังจากการแปลงหรือไม่?**

ควรเก็บไฟล์ต้นฉบับไว้จนกว่าคุณจะตรวจสอบ PPTX ในผู้ชมและเวิร์กโฟลว์ที่สำคัญต่อคุณ. สิ่งนี้จะเป็นสำเนากลับคืนหากคุณลักษณะเดิมแปลงได้แตกต่าง.