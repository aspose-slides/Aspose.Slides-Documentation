---
title: แปลง PPT เป็น PPTX ด้วย Python
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
description: "แปลงไฟล์ PPT รุ่นเก่าเป็น PPTX ด้วย Python และ Aspose.Slides รวมตัวอย่างการแปลงไฟล์เดี่ยวและเป็นชุด การจัดการข้อผิดพลาด และบันทึกความแม่นยำ"
---
## **ภาพรวม**

PPT เป็นรูปแบบไบนารีแบบเก่าของ PowerPoint ในขณะที่ PPTX เป็นรูปแบบ Open XML ใหม่กว่า Aspose.Slides สำหรับ Python ผ่าน .NET สามารถโหลดไฟล์ PPT และบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือไดเรกทอรีของไฟล์ และอธิบายสิ่งที่ต้องตรวจสอบหลังการแปลง

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นฉบับโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วเรียก [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) โดยใช้ [SaveFormat.PPTX](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/) คำสั่ง `with` จะทำลายวัตถุ presentation และปล่อยทรัพยากรเมื่อบล็อกสิ้นสุด

```python
import aspose.slides as slides

# โหลดการนำเสนอ PPT รุ่นเก่า.
with slides.Presentation("presentation.ppt") as presentation:
    # บันทึกการนำเสนอเป็นรูปแบบ PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

ส่วนขยายของไฟล์ไม่ได้เลือกรูปแบบเอาต์พุตโดยอัตโนมัติ; การกำหนดค่า [SaveFormat.PPTX](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/) ทำหน้าที่นั้น หากต้องการเก็บไฟล์ PPT ต้นฉบับไว้ ควรทำให้เส้นทางอินพุตและเอาต์พุตแตกต่างกัน

## **แปลงหลายไฟล์ PPT**

ตัวอย่างต่อไปนี้จะแปลงไฟล์ `.ppt` ทุกไฟล์ในไดเรกทอรีหนึ่ง แต่ละไฟล์จะถูกประมวลผลแยกกัน ดังนั้นการแปลงล้มเหลวหนึ่งไฟล์จะไม่ทำให้การประมวลผลทั้งหมดหยุดลง

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

สำหรับงานผลิตจริง ควรบันทึกข้อยกเว้นทั้งหมด พิจารณาว่าจะเขียนทับไฟล์เอาต์พุตที่มีอยู่หรือไม่ และบันทึกชื่อไฟล์ที่ล้มเหลวไปยังคิวสำหรับลองใหม่หรือการตรวจสอบ ไฟล์เสีย, ไฟล์ที่ป้องกันด้วยรหัสผ่านซึ่งเปิดโดยไม่มีรหัสผ่านที่ต้องการ, เส้นทางที่เข้าถึงไม่ได้, และเนื้อหาที่ไม่รองรับ ทั้งหมดนี้อาจทำให้การแปลงล้มเหลว ดูที่ [การนำเสนอที่ป้องกันด้วยรหัสผ่าน](/slides/th/python-net/password-protected-presentation/) สำหรับการโหลดไฟล์ที่เข้ารหัส

## **ความแม่นยำและคุณลักษณะเดิม**

การแปลงปกติจะคงรักษาสไลด์, มาสเตอร์, เค้าโครง, ข้อความ, รูปร่าง, รูปภาพ, ตาราง, และแผนภูมิ อย่างไรก็ตาม PPT และ PPTX ไม่ได้แสดงคุณลักษณะทุกอย่างในลักษณะเดียวกัน ฟีเจอร์เดิมที่ไม่มีเทียบเท่าใน PPTX หรือไม่ได้รับการสนับสนุนจากไลบรารีอาจถูกทำให้เป็นมาตรฐาน, ถูกละเว้น, หรือแสดงในรูปแบบที่ต่างออกไป

ตรวจสอบไฟล์ที่แปลงเมื่อมีแอนิเมชัน, การเปลี่ยนฉาก, วัตถุ OLE ฝังหรือเชื่อมโยง, ควบคุม ActiveX, สื่อฝัง, ฟอนต์ที่ไม่ทั่วไป, หรือแมโคร VBA ไฟล์ PPTX ปกติไม่ได้รองรับแมโคร ดังนั้นต้องใช้เวิร์กโฟลว์ที่รองรับแมโครเมื่อจำเป็นต้องมี VBA นอกจากนี้ควรตรวจสอบว่าฟอนต์ที่ต้องการและทรัพยากรภายนอกมีอยู่ในสภาพแวดล้อมที่จะแสดงหรือเรนเดอร์การนำเสนอที่แปลงแล้ว

สำหรับเอกสารสำคัญ ให้เปิดไฟล์ PPTX ที่สร้างขึ้นใหม่ด้วยโปรแกรมและตรวจสอบจำนวนสไลด์และเนื้อหาหลัก จากนั้นเปรียบเทียบลักษณะการแสดงผลและพฤติกรรมสไลด์โชว์ในโปรแกรมที่ต้องการ อย่าใช้การเรียก [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) ที่สำเร็จเป็นหลักฐานว่าแต่ละฟีเจอร์เดิมมีการแสดงผลใน PPTX อย่างแม่นยำ

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน, แลกเปลี่ยนกับระบบที่ทำงานกับแพ็คเกจ Open XML, หรือจัดเก็บในรูปแบบที่ง่ายต่อการตรวจสอบและกู้คืนมากกว่ารูปแบบไบนารี PPT ดั้งเดิม เก็บไฟล์ PPT ดั้งเดิมเป็นสำเนาเก็บถาวรหรือสำเนาอับเดตจนกว่าการนำเสนอที่แปลงแล้วจะผ่านการตรวจสอบความแม่นยำของคุณ

หากต้องการ PDF, HTML, รูปภาพ, XPS หรือรูปแบบเอาต์พุตอื่น ให้ใช้แนวทางเฉพาะรูปแบบใน [แปลงการนำเสนอเป็นหลายรูปแบบ](/slides/th/python-net/convert-presentation/) แทนการสันนิษฐานว่าทุกเป้าหมายจะคงฟีเจอร์ PowerPoint ที่แก้ไขได้

## **ตัวแปลงออนไลน์**

สำหรับไฟล์เป็นครั้งคราวหรือการเปรียบเทียบอย่างเร็ว คุณสามารถใช้ [ตัวแปลง PPT เป็น PPTX ออนไลน์](https://products.aspose.app/slides/th/conversion/ppt-to-pptx) ได้ สำหรับการแปลงที่ทำซ้ำ, การประมวลผลแบบแบทช์, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน ให้ใช้ Python API

## **บทความที่เกี่ยวข้อง**

- [PPT vs PPTX](/slides/th/python-net/ppt-vs-pptx/)
- [บันทึกการนำเสนอใน Python](/slides/th/python-net/save-presentation/)
- [รูปแบบไฟล์ที่รองรับ](/slides/th/python-net/supported-file-formats/)
- [เปิดการนำเสนอใน Python](/slides/th/python-net/open-presentation/)

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลง PPT เป็น PPTX โดยไม่ติดตั้ง Microsoft PowerPoint ได้หรือไม่?**

ใช่ Aspose.Slides สำหรับ Python ผ่าน .NET สามารถโหลดและบันทึกไฟล์การนำเสนอได้โดยไม่ต้องการ Microsoft PowerPoint

**การแปลงจาก PPT เป็น PPTX จะคงเนื้อหาทั้งหมดอย่างตรงตัวหรือไม่?**

มันจะคงเนื้อหาการนำเสนอทั่วไปไว้ แต่ความแม่นยำอย่างเต็มที่ไม่รับประกันสำหรับฟีเจอร์เดิมหรือฟีเจอร์ที่ไม่รองรับทั้งหมด ตรวจสอบไฟล์ที่สร้างเมื่อมีแมโคร, วัตถุ OLE หรือ ActiveX, สื่อ, แอนิเมชันพิเศษ, หรือฟอนต์ที่ไม่ทั่วไป

**ฉันสามารถแปลงไฟล์ PPT ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้ หากคุณใส่รหัสผ่านที่ถูกต้องเมื่อโหลดไฟล์ การไม่มีหรือรหัสผ่านที่ไม่ถูกต้องจะทำให้การโหลดล้มเหลว

**ควรลบไฟล์ PPT หลังการแปลงหรือไม่?**

ให้เก็บไฟล์ต้นฉบับไว้จนกว่าคุณจะตรวจสอบ PPTX ในโปรแกรมดูและเวิร์กโฟลว์ที่สำคัญสำหรับคุณ วิธีนี้จะเป็นสำเนาสำรองหากฟีเจอร์เดิมแปลงต่างออกไป