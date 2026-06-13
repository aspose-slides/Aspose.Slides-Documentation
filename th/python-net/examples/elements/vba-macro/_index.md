---
title: แมโคร VBA
type: docs
weight: 150
url: /th/python-net/examples/elements/vba-macro/
keywords:
- แมโคร VBA
- เพิ่มแมโคร VBA
- เข้าถึงแมโคร VBA
- ลบแมโคร VBA
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ทำงานกับแมโคร VBA ใน Python โดยใช้ Aspose.Slides: เพิ่มหรือแก้ไขโครงการและโมดูล, เซ็นหรือถอนแมโคร, และบันทึกงานนำเสนอในรูปแบบ PPT, PPTX และ ODP."
---
แสดงวิธีการเพิ่ม, เข้าถึง และลบแมโคร VBA โดยใช้ **Aspose.Slides for Python via .NET**.

## **เพิ่มแมโคร VBA**

สร้างงานนำเสนอพร้อมโครงการ VBA และโมดูลแมโครอย่างง่าย.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # เริ่มต้นโครงการ VBA.
        presentation.vba_project = slides.vba.VbaProject()

        # เพิ่มโมดูลเปล่าชื่อ "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **เข้าถึงแมโคร VBA**

ดึงโมดูลแรกจากโครงการ VBA.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **ลบแมโคร VBA**

ลบโมดูลจากโครงการ VBA.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # สมมติว่าการนำเสนอมีโครงการ VBA และอย่างน้อยหนึ่งโมดูล.
        module = presentation.vba_project.modules[0]

        # ลบโมดูลออกจากโครงการ.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```