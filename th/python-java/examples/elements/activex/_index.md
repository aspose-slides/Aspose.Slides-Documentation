---
title: ActiveX
type: docs
weight: 200
url: /th/python-java/examples/elements/activex/
keywords:
- ตัวอย่างโค้ด
- ActiveX
- ควบคุม ActiveX
- คุณสมบัติ ActiveX
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides for Python via Java เพื่อเพิ่ม, เข้าถึง, ลบ, และกำหนดค่า ActiveX control ในงานนำเสนอ PowerPoint ด้วยตัวอย่างโค้ดที่เป็นประโยชน์."
---
บทความนี้แสดงวิธีเพิ่ม, เข้าถึง, ลบ, และกำหนดค่า ActiveX control ในงานนำเสนอโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพ็กเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละอันจะนำเข้า `asposeslides` ก่อนเริ่ม JVM, จากนั้นจึงนำเข้า API หลังจาก JVM ทำงานแล้ว ตัวอย่างการเข้าถึงและการลบใช้ไฟล์ `add_activex.pptm` ซึ่งสร้างจากตัวอย่างแรก.

## **Add an ActiveX Control**
แทรก Windows Media Player control บนสไลด์แรกและบันทึกงานนำเสนอเป็นไฟล์ PPTM.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # เพิ่ม Windows Media Player control.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Access an ActiveX Control**
อ่านชื่อและการตั้งค่าให้เล่นอัตโนมัติของ ActiveX control ตัวแรกบนสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # เข้าถึง ActiveX control ตัวแรก.
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **Remove an ActiveX Control**
ลบ ActiveX control ตัวแรกออกจากสไลด์และบันทึกงานนำเสนอที่แก้ไขแล้ว.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # ลบ ActiveX control ตัวแรก.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Set ActiveX Properties**
เพิ่ม Windows Media Player control, ปิดการเล่นอัตโนมัติ, และซ่อนการควบคุมการเล่น ใช้ [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/th/python-java/aspose.slides/controlpropertiescollection/#set_Item) เพื่อกำหนดค่าคุณสมบัติต่าง ๆ เป็นสตริง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # เพิ่ม Windows Media Player control และกำหนดค่าคุณสมบัติของมัน.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```