---
title: จัดการโครงการ VBA ในงานนำเสนอด้วย Python
linktitle: งานนำเสนอผ่าน VBA
type: docs
weight: 250
url: /th/python-java/presentation-via-vba/
keywords:
- มาโคร
- VBA
- มาโคร VBA
- เพิ่มมาโคร
- ลบมาโคร
- ดึงมาโคร
- เพิ่ม VBA
- ลบ VBA
- ดึง VBA
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ค้นพบวิธีการสร้างและจัดการงานนำเสนอ PowerPoint และ OpenDocument ผ่าน VBA ด้วย Aspose.Slides สำหรับ Python ผ่าน Java เพื่อทำให้กระบวนการทำงานของคุณมีประสิทธิภาพมากขึ้น."
---
## **Introduction**

Aspose.Slides มีคลาสและอินเทอร์เฟซสำหรับทำงานกับแมโครและโค้ด VBA.

{{% alert title="Warning" color="warning" %}} 

เมื่อคุณแปลงงานนำเสนอที่มีแมโครเป็นรูปแบบไฟล์อื่น (PDF, HTML ฯลฯ) Aspose.Slides จะละเลยแมโครทั้งหมด (แมโครจะไม่ถูกนำไปยังไฟล์ผลลัพธ์).

เมื่อคุณเพิ่มแมโครลงในงานนำเสนอหรือบันทึกงานนำเสนอที่มีแมโครใหม่ Aspose.Slides จะเพียงแค่เขียนไบต์ของแมโครเท่านั้น.

Aspose.Slides **ไม่เคย** รันแมโครในงานนำเสนอ.

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides มีคลาส [VbaProject](https://reference.aspose.com/slides/th/python-java/aspose.slides/vbaproject/) เพื่อให้คุณสร้างโครงการ VBA (และอ้างอิงโครงการ) และแก้ไขโมดูลที่มีอยู่ คุณสามารถใช้คลาส [VbaProject](https://reference.aspose.com/slides/th/python-java/aspose.slides/vbaproject/) เพื่อจัดการ VBA ที่ฝังอยู่ในงานนำเสนอ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
2. ใช้คอนสตรัคเตอร์ของ [VbaProject](https://reference.aspose.com/slides/th/python-java/aspose.slides/vbaproject/#vbaproject) เพื่อเพิ่มโครงการ VBA ใหม่.
3. เพิ่มโมดูลเข้าไปในโครงการ VBA.
4. ตั้งค่าโค้ดต้นฉบับของโมดูล.
5. เพิ่มการอ้างอิงไปยัง `stdole`.
6. เพิ่มการอ้างอิงไปยัง **Microsoft Office**.
7. เชื่อมโยงการอ้างอิงกับโครงการ VBA.
8. บันทึกงานนำเสนอ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # สร้างโครงการ VBA ใหม่.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # เพิ่มโมดูลว่างและตั้งค่าโค้ดต้นฉบับของมัน.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # สร้างการอ้างอิงไปยัง stdole และ Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # เพิ่มการอ้างอิงไปยังโครงการ VBA.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # บันทึกงานนำเสนอ.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

คุณอาจต้องการลองใช้ **Aspose** [Macro Remover](https://products.aspose.app/slides/th/remove-macros) ซึ่งเป็นแอปเว็บฟรีที่ใช้ลบแมโครจากเอกสาร PowerPoint, Excel และ Word.

{{% /alert %}} 

## **Remove VBA Macros**

โดยใช้เมธอด [getVbaProject](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getvbaproject) ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) คุณสามารถลบแมโคร VBA ได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีแมโคร.
2. เข้าถึงโมดูลแมโครและลบออก.
3. บันทึกงานนำเสนอที่แก้ไขแล้ว.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# โหลดงานนำเสนอที่มีแมโคร.
presentation = Presentation("VBA.pptm")
try:
    # เข้าถึงโมดูล VBA และลบออก.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # บันทึกงานนำเสนอ.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Extract VBA Macros**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีแมโคร.
2. ตรวจสอบว่ากาตนำเสนอมีโครงการ VBA หรือไม่.
3. วนลูปผ่านโมดูลทั้งหมดในโครงการ VBA เพื่อดูแมโคร.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# โหลดงานนำเสนอที่มีแมโคร.
presentation = Presentation("VBA.pptm")
try:
    # ตรวจสอบว่างานนำเสนอมีโครงการ VBA หรือไม่.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Check Whether a VBA Project Is Password-Protected**

โดยใช้เมธอด [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/th/python-java/aspose.slides/vbaproject/#ispasswordprotected) คุณสามารถตรวจสอบได้ว่าโครงการมีการปกป้องด้วยรหัสผ่านหรือไม่.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีแมโคร.
2. ตรวจสอบว่ากาตนำเสนอมี [VBA project](https://reference.aspose.com/slides/th/python-java/aspose.slides/vbaproject/) หรือไม่.
3. ตรวจสอบว่าโครงการ VBA ได้รับการปกป้องด้วยรหัสผ่านหรือไม่เพื่อดูคุณสมบัติของมัน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # ตรวจสอบว่างานนำเสนอมีโครงการ VBA หรือไม่.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **FAQ**

**What happens to macros if I save the presentation as PPTX?**

แมโครจะถูกลบออกเนื่องจาก PPTX ไม่รองรับ VBA หากต้องการเก็บแมโคร ให้เลือกใช้ PPTM, PPSM หรือ POTM.

**Can Aspose.Slides run macros inside a presentation to, for example, refresh data?**

ไม่ได้ ไลบรารีไม่เคยรันโค้ด VBA การดำเนินการสามารถทำได้เฉพาะใน PowerPoint ที่มีการตั้งค่าความปลอดภัยที่เหมาะสมเท่านั้น.

**Is working with ActiveX controls linked to VBA code supported?**

ใช่ คุณสามารถเข้าถึง [ActiveX controls](/slides/th/python-java/activex/) ที่มีอยู่, แก้ไขคุณสมบัติของมัน, และลบออกได้ ซึ่งเป็นประโยชน์เมื่อแมโครโต้ตอบกับ ActiveX.