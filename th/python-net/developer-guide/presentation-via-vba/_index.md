---
title: จัดการโครงการ VBA ในงานนำเสนอด้วย Python
linktitle: การนำเสนอผ่าน VBA
type: docs
weight: 250
url: /th/python-net/presentation-via-vba/
keywords:
- มาโคร
- VBA
- มาโคร VBA
- เพิ่มมาโคร
- ลบมาโคร
- สกัดมาโคร
- เพิ่ม VBA
- ลบ VBA
- สกัด VBA
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบวิธีสร้างและจัดการงานนำเสนอ PowerPoint และ OpenDocument ผ่าน VBA ด้วย Aspose.Slides สำหรับ Python via .NET เพื่อทำให้กระบวนการทำงานของคุณเป็นระเบียบและเร็วขึ้น"
---
## **ภาพรวม**

บทความนี้ตรวจสอบความสามารถหลักของ Aspose.Slides for Python via .NET สำหรับการทำงานกับมาโครในงานนำเสนอ PowerPoint ไลบรารีนี้มอบเครื่องมือที่สะดวกสำหรับการเพิ่ม, ลบ, และสกัดมาโคร ซึ่งช่วยให้คุณสามารถอัตโนมัติการสร้างและแก้ไขงานนำเสนอได้

ด้วย Aspose.Slides คุณสามารถ:

- เร่งกระบวนการพัฒนาการนำเสนอ — การอัตโนมัติงานที่ทำซ้ำทำให้ใช้เวลาเตรียมวัสดุน้อยลง
- รับประกันความยืดหยุ่น — ความสามารถในการจัดการมาโครช่วยให้คุณปรับแต่งการนำเสนอให้สอดคล้องกับงานและสถานการณ์เฉพาะ
- ผสานรวมข้อมูล — การเชื่อมต่ออย่างง่ายกับแหล่งข้อมูลภายนอกช่วยให้เนื้อหาในสไลด์เป็นปัจจุบันอยู่เสมอ
- ทำให้การบำรุงรักษาง่ายขึ้น — การจัดการมาโครแบบศูนย์กลางทำให้การเปลี่ยนแปลงและอัปเดตการนำเสนอเป็นเรื่องง่าย

บทความต่อไปจะแสดงตัวอย่างการใช้ Aspose.Slides เพื่อทำงานกับมาโครใน PowerPoint อย่างมีประสิทธิภาพ

[aspose.slides.vba](https://reference.aspose.com/slides/th/python-net/aspose.slides.vba/) namespace มีคลาสสำหรับทำงานกับมาโครและโค้ด VBA

{{% alert title="Note" color="warning" %}}
เมื่อคุณแปลงงานนำเสนอที่มีมาโครเป็นรูปแบบอื่น (PDF, HTML ฯลฯ) Aspose.Slides จะละเลยมาโคร — มันจะไม่ถูกถ่ายโอนไปยังไฟล์ผลลัพธ์

เมื่อคุณเพิ่มมาโครลงในงานนำเสนอหรือบันทึกงานนำเสนอที่มีมาโครใหม่ Aspose.Slides จะเขียนไบต์ของมาโครไว้ตามเดิม

Aspose.Slides **ไม่เคย** ทำการเรียกใช้มาโครในงานนำเสนอ
{{% /alert %}}

## **เพิ่ม VBA Macros**

Aspose.Slides มีคลาส [VbaProject](https://reference.aspose.com/slides/th/python-net/aspose.slides.vba/vbaproject/) เพื่อสร้างโครงการ VBA (และการอ้างอิงโครงการ) และแก้ไขโมดูลที่มีอยู่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. ใช้คอนสทรัคเตอร์ของ [VbaProject](https://reference.aspose.com/slides/th/python-net/aspose.slides.vba/vbaproject/#constructors) เพื่อเพิ่มโครงการ VBA ใหม่
1. เพิ่มโมดูลลงในโครงการ VBA
1. ตั้งค่าซอร์สโค้ดของโมดูล
1. เพิ่มการอ้างอิงถึง `<stdole>`
1. เพิ่มการอ้างอิงถึง **Microsoft Office**
1. เชื่อมโยงการอ้างอิงกับโครงการ VBA
1. บันทึกงานนำเสนอ

โค้ด Python ด้านล่างแสดงวิธีเพิ่ม VBA macro ตั้งแต่ต้นจนจบในงานนำเสนอ:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:

    # สร้างโครงการ VBA ใหม่.
    presentation.vba_project = slides.vba.VbaProject()

    # เพิ่มโมดูลเปล่าลงในโครงการ VBA.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # ตั้งค่าซอร์สโค้ดของโมดูล.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # สร้างการอ้างอิงถึง <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # สร้างการอ้างอิงถึง Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # เพิ่มการอ้างอิงเหล่านั้นลงในโครงการ VBA.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # บันทึกงานนำเสนอ.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
คุณอาจต้องการลองใช้ **Aspose** [Macro Remover](https://products.aspose.app/slides/th/remove-macros) ซึ่งเป็นเว็บแอปฟรีสำหรับการลบมาโครจากไฟล์ PowerPoint, Excel, และ Word
{{% /alert %}}

## **ลบ VBA Macros**

โดยใช้คุณสมบัติ [vba_project](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/vba_project/) ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) คุณสามารถลบ VBA macro ได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีมาโคร
1. เข้าถึงโมดูลมาโครและลบออก
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Python ด้านล่างแสดงวิธีลบ VBA macro:

```python
import aspose.slides as slides

# โหลดงานนำเสนอที่มีมาโคร.
with slides.Presentation("VBA.pptm") as presentation:
    
    # เข้าถึงโมดูล VBA.
    vba_module = presentation.vba_project.modules[0]

    # ลบโมดูล VBA.
    presentation.vba_project.modules.remove(vba_module)

    # บันทึกงานนำเสนอ.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **สกัด VBA Macros**

โดยใช้คุณสมบัติ `modules` ในคลาส [VbaProject](https://reference.aspose.com/slides/th/python-net/aspose.slides.vba/vbaproject/) คุณสามารถเข้าถึงโมดูลทั้งหมดของโครงการ VBA ได้ คลาส [VbaModule](https://reference.aspose.com/slides/th/python-net/aspose.slides.vba/vbamodule/) สามารถใช้สกัดคุณสมบัติโมดูล เช่น ชื่อและโค้ด

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีมาโคร
1. ตรวจสอบว่ามีโครงการ VBA อยู่หรือไม่
1. วนลูปผ่านโมดูลทั้งหมดในโครงการ VBA เพื่อดูมาโคร

โค้ด Python ด้านล่างแสดงวิธีสกัด VBA macros จากงานนำเสนอ:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # ตรวจสอบว่าการนำเสนอมีโครงการ VBA หรือไม่.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **ตรวจสอบว่า VBA Project ถูกตั้งรหัสผ่านหรือไม่**

โดยใช้คุณสมบัติ [VbaProject.is_password_protected](https://reference.aspose.com/slides/th/python-net/aspose.slides.vba/vbaproject/is_password_protected/) คุณสามารถตรวจสอบได้ว่าโครงการนั้นถูกตั้งรหัสผ่านหรือไม่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีมาโคร
1. ตรวจสอบว่ามี [VBA project](https://reference.aspose.com/slides/th/python-net/aspose.slides.vba/vbaproject/) อยู่หรือไม่
1. ตรวจสอบว่าโครงการ VBA ถูกตั้งรหัสผ่านหรือไม่เพื่อดูคุณสมบัติต่าง ๆ

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # ตรวจสอบว่าการนำเสนอมีโครงการ VBA หรือไม่.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**จะเกิดอะไรขึ้นกับมาโครหากฉันบันทึกงานนำเสนอเป็น PPTX?**

มาโครจะถูกลบออกเนื่องจาก PPTX ไม่รองรับ VBA หากต้องการเก็บมาโครไว้ให้เลือกบันทึกเป็น PPTM, PPSM หรือ POTM

**Aspose.Slides สามารถรันมาโครภายในงานนำเสนอเพื่อเช่นการรีเฟรชข้อมูลได้หรือไม่?**

ไม่ได้ ไลบรารีไม่เคยเรียกใช้โค้ด VBA; การรันโค้ด VBA ทำได้เฉพาะใน PowerPoint โดยต้องตั้งค่าสิทธิ์ความปลอดภัยที่เหมาะสม

**การทำงานกับคอนโทรล ActiveX ที่เชื่อมโยงกับโค้ด VBA รองรับหรือไม่?**

รองรับ คุณสามารถเข้าถึง [ActiveX controls](/slides/th/python-net/activex/) ที่มีอยู่, แก้ไขคุณสมบัติของมัน, และลบออกได้ ซึ่งเป็นประโยชน์เมื่อมาโครโต้ตอบกับ ActiveX  