---
title: แปลง PPT เป็น PPTX ใน Python
linktitle: PPT เป็น PPTX
type: docs
weight: 20
url: /th/python-java/convert-ppt-to-pptx/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- PPT เป็น PPTX
- บันทึก PPT เป็น PPTX
- ส่งออก PPT ไปยัง PPTX
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT แบบเก่าเป็น PPTX ด้วย Python และ Aspose.Slides. รวมตัวอย่าง Python สำหรับการแปลงไฟล์เดี่ยวและแบบชุด, การจัดการข้อผิดพลาด, และบันทึกเกี่ยวกับความแม่นยำ."
---
## **ภาพรวม**

PPT เป็นรูปแบบไบนารีเก่าของ PowerPoint, ส่วน PPTX เป็นรูปแบบ Open XML ใหม่กว่า Aspose.Slides for Python via Java สามารถโหลดไฟล์ PPT และบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือไดเรกทอรีของไฟล์และอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง

แต่ละตัวอย่างจะเริ่มเครื่องเสมือน Java หากจำเป็นและจะปล่อยการนำเสนอหลังใช้งานแล้ว แทนที่เส้นทางตัวอย่างด้วยเส้นทางไฟล์หรือไดเรกทอรีของคุณเอง

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นทางด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) จากนั้นเรียก [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) พร้อมกับ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Pptx) ส่วน `finally` จะทำการยกเลิกการใช้งานการนำเสนอและปล่อยทรัพยากร

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# โหลดงานนำเสนอ PPT แบบเก่า.
presentation = Presentation("presentation.ppt")
try:
    # บันทึกงานนำเสนอในรูปแบบ PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

นามสกุลไฟล์ไม่เป็นตัวกำหนดรูปแบบผลลัพธ์ด้วยตนเอง; อาร์กิวเมนต์ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Pptx) คือสิ่งที่ทำหน้าที่นั้น หากต้องการรักษาไฟล์ PPT ดั้งเดิมไว้ ให้ใช้เส้นทางอินพุตและเอาต์พุตที่ต่างกัน

## **แปลงหลายไฟล์ PPT**

ตัวอย่างต่อไปนี้จะทำการแปลงทุกไฟล์ `.ppt` ในไดเรกทอรีหนึ่ง แต่ละไฟล์จะถูกประมวลผลอย่างอิสระ ดังนั้นการแปลงล้มเหลวหนึ่งไฟล์จะไม่ทำให้แบตช์ทั้งหมดหยุดทำงาน

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

สำหรับงานในสภาพการผลิต ควรบันทึกข้อยกเว้นทั้งหมด, ตัดสินใจว่าจะเขียนทับไฟล์ผลลัพธ์ที่มีอยู่หรือไม่, และบันทึกชื่อไฟล์ที่ล้มเหลวเพื่อรอการลองใหม่หรือการตรวจสอบ คอมไฟล์ที่เสีย, ไฟล์ที่มีรหัสผ่านแต่เปิดโดยไม่มีรหัสผ่านที่ต้องการ, เส้นทางที่ไม่สามารถเข้าถึงได้, และเนื้อหาที่ไม่รองรับทั้งหมดอาจทำให้การแปลงล้มเหลว ดู [Password-Protected Presentations](/slides/th/python-java/password-protected-presentation/) สำหรับการโหลดไฟล์ที่เข้ารหัส

## **ความแม่นยำและคุณลักษณะแบบเก่า**

การแปลงโดยปกติจะยังคงสไลด์, มาสเตอร์, เลเอาท์, ข้อความ, รูปร่าง, รูปภาพ, ตาราง, และแผนภูมิ อย่างไรก็ตาม PPT และ PPTX ไม่ได้แสดงคุณลักษณะทุกอย่างในแบบเดียวกัน เวอร์ชันเก่าที่ไม่มีสมมูลใน PPTX หรือไม่รองรับโดยไลบรารีอาจถูกทำให้เป็นมาตรฐาน, ถูกละทิ้ง, หรือแสดงแตกต่างออกไป

ตรวจสอบไฟล์ที่แปลงแล้วเมื่อมีการใช้แอนิเมชัน, การเปลี่ยนฉาก, วัตถุ OLE ที่ฝังหรือเชื่อมโยง, คอนโทรล ActiveX, สื่อที่ฝัง, ฟอนต์ที่ไม่ทั่วไป, หรือแมโคร VBA ไฟล์ PPTX ปกติไม่ได้เป็นฟอร์แมตที่รองรับแมโคร ดังนั้นจึงต้องใช้กระบวนการที่รองรับแมโครเมื่อ VBA จำเป็นต้องคงอยู่ นอกจากนี้ควรตรวจสอบให้แน่ใจว่าฟอนต์และทรัพยากรภายนอกที่ต้องการมีอยู่ในสภาพแวดล้อมที่ไฟล์ที่แปลงจะถูกเปิดหรือเรนเดอร์

สำหรับเอกสารสำคัญ ควรเปิด PPTX ที่สร้างขึ้นโดยโปรแกรมและตรวจสอบจำนวนสไลด์และเนื้อหาหลัก แล้วเปรียบเทียบลักษณะการแสดงผลและพฤติกรรมสไลด์โชว์ในโปรแกรมตัวชมที่ต้องการ อย่าพิจารณาการเรียก [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) สำเร็จเป็นหลักฐานว่าคุณลักษณะเก่าทุกอย่างมีการแสดงผลในรูปแบบ PPTX อย่างแม่นยำ

## **เมื่อใดควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน, มีการแลกเปลี่ยนกับระบบที่ทำงานกับแพ็กเกจ Open XML, หรือเก็บในรูปแบบที่ตรวจสอบและกู้คืนได้ง่ายกว่ารูปแบบไบนารีเก่า PPT ให้เก็บไฟล์ PPT ดั้งเดิมเป็นสำเนาเก็บถาวรหรือสำเนาแบบ rollback จนกว่าการนำเสนอที่แปลงแล้วจะผ่านการตรวจสอบความแม่นยำของคุณ

หากต้องการ PDF, HTML, รูปภาพ, XPS หรือรูปแบบผลลัพธ์อื่นแทน ให้ใช้แนวทางเฉพาะฟอร์แมตใน [Convert Presentations to Multiple Formats](/slides/th/python-java/convert-presentation/) แทนการสันนิษฐานว่าปลายทางทั้งหมดจะรักษาคุณลักษณะ PowerPoint ที่แก้ไขได้

## **ตัวแปลงออนไลน์**

สำหรับไฟล์ที่ต้องการแปลงเป็นครั้งคราวหรือการเปรียบเทียบอย่างเร็ว คุณสามารถใช้ [online PPT to PPTX converter](https://products.aspose.app/slides/th/conversion/ppt-to-pptx) ได้ สำหรับการแปลงแบบทำซ้ำ, การประมวลผลเป็นแบตช์, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน ให้ใช้ API Python via Java

## **บทความที่เกี่ยวข้อง**

- [PPT vs PPTX](/slides/th/python-java/ppt-vs-pptx/)
- [บันทึกงานนำเสนอใน Python](/slides/th/python-java/save-presentation/)
- [รูปแบบไฟล์ที่รองรับ](/slides/th/python-java/supported-file-formats/)
- [เปิดงานนำเสนอใน Python](/slides/th/python-java/open-presentation/)

## **คำถามที่พบบ่อย**

**สามารถแปลง PPT เป็น PPTX ได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ได้ Aspose.Slides for Python via Java สามารถโหลดและบันทึกไฟล์งานนำเสนอได้โดยไม่ต้องอาศัย Microsoft PowerPoint

**การแปลง PPT เป็น PPTX จะคงเนื้อหาทั้งหมดอย่างสมบูรณ์หรือไม่?**

จะคงเนื้อหาที่พบบ่อยในงานนำเสนอไว้ได้ แต่ความแม่นยำเต็มรูปแบบไม่รับประกันสำหรับคุณลักษณะแบบเก่าหรือคุณลักษณะที่ไม่รองรับ ควรตรวจสอบไฟล์ที่สร้างเมื่อมีแมโคร, วัตถุ OLE หรือ ActiveX, สื่อ, แอนิเมชันพิเศษ, หรือฟอนต์ที่ไม่ทั่วไป

**สามารถแปลงไฟล์ PPT ที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้ หากคุณใส่รหัสผ่านที่ถูกต้องเมื่อโหลดไฟล์ รหัสผ่านที่ขาดหายหรือไม่ถูกต้องจะทำให้การโหลดล้มเหลว

**ควรลบไฟล์ PPT หลังการแปลงหรือไม่?**

เก็บไฟล์ต้นฉบับไว้จนกว่าจะตรวจสอบ PPTX ในโปรแกรมและกระบวนการที่สำคัญสำหรับคุณ ซึ่งจะทำให้มีสำเนาเพื่อกู้คืนหากคุณลักษณะแบบเก่าแปลงแตกต่างออกไป