---
title: มาโคร VBA
type: docs
weight: 150
url: /th/python-java/examples/elements/vba-macro/
keywords:
- ตัวอย่างโค้ด
- VBA
- มาโคร
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เพิ่ม, เข้าถึงและลบมาโคร VBA ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java พร้อมตัวอย่างโค้ดที่ชัดเจนและใช้งานได้จริง."
---
บทความนี้สาธิตวิธีการเพิ่ม, เข้าถึงและลบมาโคร VBA ด้วย **Aspose.Slides for Python via Java**.

ติดตั้งแพ็กเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะนำเข้า `asposeslides` ก่อนเริ่ม JVM แล้วจึงนำเข้า API หลังจาก JVM ทำงาน.

## **เพิ่มมาโคร VBA**

สร้างงานนำเสนอพร้อมโครงการ VBA และโมดูลมาโครแบบง่าย.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')
finally:
    presentation.dispose()
```

## **เข้าถึงมาโคร VBA**

ดึงโมดูลแรกจากโครงการ VBA.

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    first_module = presentation.getVbaProject().getModules().get_Item(0)
finally:
    presentation.dispose()
```

## **ลบมาโคร VBA**

ลบโมดูลจากโครงการ VBA.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    presentation.getVbaProject().getModules().remove(module)
finally:
    presentation.dispose()
```