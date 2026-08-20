---
title: แปลง PPT เป็น PPTX ใน Python
linktitle: PPT เป็น PPTX
type: docs
weight: 20
url: /th/python-net/convert-ppt-to-pptx/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- PPT เป็น PPTX
- บันทึก PPT เป็น PPTX
- ส่งออก PPT เป็น PPTX
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "แปลงไฟล์ PPT รุ่นเก่าเป็น PPTX ใน Python ด้วย Aspose.Slides. มีตัวอย่างสำหรับการแปลงแบบไฟล์เดียวและแบบเป็นชุด, การจัดการข้อผิดพลาด, และบันทึกความแม่นยำ."
---
## **ภาพรวม**

PPT เป็นรูปแบบไบนารีของ PowerPoint รุ่นเก่า ในขณะที่ PPTX เป็นรูปแบบ Open XML รุ่นใหม่ Aspose.Slides สำหรับ Python ผ่าน .NET สามารถโหลดไฟล์ PPT และบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือไดเรกทอรีของไฟล์และอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นทางด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วเรียกใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) พร้อมกับ [SaveFormat.PPTX](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/) คำสั่ง `with` จะทำการกำจัดวัตถุ presentation และปล่อยทรัพยากรเมื่อบล็อกจบ

```python
import aspose.slides as slides

# โหลดการนำเสนอ PPT รุ่นเก่า.
with slides.Presentation("presentation.ppt") as presentation:
    # บันทึกการนำเสนอในรูปแบบ PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

นามสกุลไฟล์ไม่ได้กำหนดรูปแบบการส่งออกด้วยตนเอง; อาร์กิวเมนต์ [SaveFormat.PPTX](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/) ทำหน้าที่นั้น หากต้องการเก็บไฟล์ PPT เดิมไว้ ให้ตั้งค่าที่อยู่ของไฟล์อินพุตและเอาต์พุตให้ต่างกัน

## **แปลงหลายไฟล์ PPT**

ตัวอย่างต่อไปนี้จะทำการแปลงไฟล์ `.ppt` ทุกไฟล์ในไดเรกทอรีหนึ่ง แต่ละไฟล์จะถูกประมวลผลแยกกัน ดังนั้นการแปลงที่ล้มเหลวหนึ่งไฟล์จะไม่ทำให้ชุดอื่นหยุดทำงาน

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

สำหรับงานระดับการผลิต ควรบันทึกข้อยกเว้นทั้งหมด, ตัดสินใจว่าควรเขียนทับไฟล์เอาต์พุตที่มีอยู่หรือไม่, และบันทึกชื่อไฟล์ที่ล้มเหลวลงในคิวรีไทร์หรือคิวรีวิว ไฟล์ที่เสียหาย, ไฟล์ที่ปิดการเข้ารหัสด้วยรหัสผ่านแต่เปิดโดยไม่มีรหัสผ่านที่ต้องการ, เส้นทางที่เข้าถึงไม่ได้, และเนื้อหาที่ไม่รองรับทั้งหมดอาจทำให้การแปลงล้มเหลว ดูที่ [การนำเสนอที่ป้องกันด้วยรหัสผ่าน](/python-net/password-protected-presentation/) สำหรับการโหลดไฟล์ที่เข้ารหัส

## **ความแม่นยำและคุณลักษณะรุ่นเก่า**

การแปลงโดยทั่วไปจะคงสไลด์, มาสเตอร์, เลเอาต์, ข้อความ, รูปร่าง, รูปภาพ, ตาราง, และแผนภูมิไว้ แต่ PPT และ PPTX ไม่ได้แสดงคุณลักษณะทุกอย่างในรูปแบบที่เหมือนกันทุกประการ คุณลักษณะรุ่นเก่าที่ไม่มีเทียบเท่าใน PPTX หรือไม่รองรับโดยไลบรารีอาจถูกทำให้เป็นมาตรฐาน, ถูกละเว้น, หรือแสดงอย่างแตกต่าง

ตรวจสอบไฟล์ที่แปลงเมื่อมีแอนิเมชัน, การเปลี่ยนสไลด์, วัตถุ OLE ที่ฝังหรือเชื่อมโยง, คอนโทรล ActiveX, สื่อที่ฝังรวม, ฟอนต์ที่ไม่ปกติ, หรือแมโคร VBA ไฟล์ PPTX ธรรมดาไม่ใช่รูปแบบที่เปิดใช้งานแมโคร ดังนั้นให้ใช้กระบวนการทำงานที่รองรับแมโครเมื่อจำเป็นต้องใช้ VBA นอกจากนี้ควรตรวจสอบว่าฟอนต์ที่จำเป็นและแหล่งข้อมูลภายนอกมีอยู่ในสภาพแวดล้อมที่ไฟล์นำเสนอที่แปลงจะถูกเปิดหรือเรนเดอร์

สำหรับเอกสารที่สำคัญ ให้เปิดไฟล์ PPTX ที่สร้างขึ้นใหม่ด้วยโปรแกรมและตรวจสอบจำนวนสไลด์และเนื้อหาที่สำคัญ จากนั้นเปรียบเทียบลักษณะการแสดงและพฤติกรรมการแสดงสไลด์ในโปรแกรมที่ต้องการ อย่านับว่าการเรียกใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) ที่สำเร็จเป็นหลักฐานว่าทุกคุณลักษณะรุ่นเก่ามีการแปลงเป็น PPTX ที่ตรงกันอย่างสมบูรณ์

## **เมื่อใดควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน, มีการแลกเปลี่ยนกับระบบที่ทำงานกับแพ็กเกจ Open XML, หรือจัดเก็บในรูปแบบที่ตรวจสอบและกู้คืนได้ง่ายกว่ารูปแบบไบนารี PPT เก่า ให้เก็บไฟล์ PPT ดั้งเดิมเป็นสำเนาเก็บถาวรหรือสำเนาสำรองจนกว่าการนำเสนอที่แปลงจะผ่านการตรวจสอบความแม่นยำของคุณ

หากต้องการ PDF, HTML, ภาพ, XPS หรือรูปแบบเอาต์พุตอื่น ให้ใช้คำแนะนำตามรูปแบบใน [แปลงการนำเสนอเป็นหลายรูปแบบ](/python-net/convert-presentation/) แทนการสันนิษฐานว่าทุกเป้าหมายจะคงคุณลักษณะ PowerPoint ที่สามารถแก้ไขได้

## **ตัวแปลงออนไลน์**

สำหรับไฟล์เป็นครั้งคราวหรือการเปรียบเทียบอย่างรวดเร็ว คุณสามารถใช้ [ตัวแปลง PPT เป็น PPTX ออนไลน์](https://products.aspose.app/slides/th/conversion/ppt-to-pptx) สำหรับการแปลงที่ทำซ้ำได้, การประมวลผลเป็นชุด, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน ให้ใช้ Python API

## **บทความที่เกี่ยวข้อง**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [บันทึกการนำเสนอใน Python](/python-net/save-presentation/)
- [รูปแบบไฟล์ที่รองรับ](/python-net/supported-file-formats/)
- [เปิดการนำเสนอใน Python](/python-net/open-presentation/)

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลง PPT เป็น PPTX ได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ได้เลย Aspose.Slides สำหรับ Python ผ่าน .NET สามารถโหลดและบันทึกไฟล์การนำเสนอได้โดยไม่ต้องใช้ Microsoft PowerPoint

**การแปลงจาก PPT เป็น PPTX จะคงเนื้อหาทั้งหมดได้อย่างสมบูรณ์หรือไม่?**

มันจะคงเนื้อหาการนำเสนอทั่วไปไว้ได้ แต่ความแม่นยำอย่างสมบูรณ์ไม่รับประกันสำหรับคุณลักษณะรุ่นเก่าหรือคุณลักษณะที่ไม่รองรับ ตรวจสอบไฟล์ที่สร้างขึ้นเมื่อมีแมโคร, วัตถุ OLE หรือ ActiveX, สื่อ, แอนิเมชันเฉพาะ, หรือฟอนต์ที่ไม่ทั่วไป

**ฉันสามารถแปลงไฟล์ PPT ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้ หากคุณระหัสผ่านที่ถูกต้องเมื่อต้องการโหลดไฟล์ การไม่มีหรือรหัสผ่านไม่ถูกต้องจะทำให้การโหลดล้มเหลว

**ฉันควรลบไฟล์ PPT หลังการแปลงหรือไม่?**

ให้เก็บไฟล์เดิมไว้จนกว่าคุณจะตรวจสอบ PPTX ในโปรแกรมและกระบวนการทำงานที่สำคัญสำหรับคุณ การทำเช่นนี้จะให้สำเนาสำรองไว้หากคุณลักษณะรุ่นเก่าแปลงได้ต่างกัน