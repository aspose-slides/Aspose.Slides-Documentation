---
title: จัดการ ActiveX Controls ในงานนำเสนอโดยใช้ Python
linktitle: ActiveX
type: docs
weight: 80
url: /th/python-java/activex/
keywords:
- ActiveX
- คอนโทรล ActiveX
- จัดการ ActiveX
- เพิ่ม ActiveX
- แก้ไข ActiveX
- เครื่องเล่นสื่อ
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้ว่า Aspose.Slides for Python via Java ใช้ ActiveX เพื่อทำงานอัตโนมัติและปรับปรุงงานนำเสนอ PowerPoint อย่างไร ให้ผู้พัฒนามีการควบคุมสไลด์อย่างทรงพลัง"
---
## **บทนำ**

ActiveX control ถูกใช้ในงานนำเสนอ Aspose.Slides for Python via Java ทำให้คุณสามารถเพิ่มและจัดการ ActiveX control ได้ แต่การจัดการค่อนข้างซับซ้อนเมื่อเทียบกับรูปทรงปกติในงานนำเสนอ Aspose.Slides รองรับการเพิ่ม Media Player ActiveX control โปรดทราบว่า ActiveX control ไม่ใช่รูปทรง; พวกมันไม่ได้เป็นส่วนหนึ่งของ [ShapeCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/) ของงานนำเสนอ แต่เป็นส่วนของ [ControlCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/controlcollection/) แยกต่างหาก ในหัวข้อนี้ เราจะอธิบายวิธีการทำงานกับพวกมัน

## **เพิ่ม Media Player ActiveX Control ลงสไลด์**

เพื่อเพิ่ม Media Player ActiveX control ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และสร้างงานนำเสนอเปล่า
1. เข้าถึงสไลด์เป้าหมายใน [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
1. เพิ่ม Media Player ActiveX control ด้วยเมธอด [addControl](https://reference.aspose.com/slides/th/python-java/aspose.slides/controlcollection/#addControl) ของ [ControlCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/controlcollection/)
1. เข้าถึง Media Player ActiveX control และกำหนดเส้นทางวิดีโอโดยใช้คุณสมบัติของมัน
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX

ตัวอย่างโค้ดด้านล่าง ซึ่งอ้างอิงจากขั้นตอนข้างต้น แสดงวิธีการเพิ่ม Media Player ActiveX control ลงสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

    # สร้างงานนำเสนอเปล่า.
    presentation = Presentation()
    try:
        # เพิ่ม Media Player ActiveX control.
        slide = presentation.getSlides().get_Item(0)
        control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

        # ตั้งค่าพาธของวิดีโอ.
        control.getProperties().set_Item("URL", "Wildlife.wmv")

        # บันทึกงานนำเสนอ.
        presentation.save("Output.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

## **แก้ไข ActiveX Control**

{{% alert color="info" title="หมายเหตุ" %}}

Aspose.Slides for Python via Java มีส่วนประกอบสำหรับจัดการ ActiveX control คุณสามารถเข้าถึง ActiveX control ที่เพิ่มไว้แล้วในงานนำเสนอและแก้ไขหรือทำการลบผ่านคุณสมบัติต่าง ๆ ของมันได้

{{% /alert %}}

เพื่อจัดการ ActiveX control อย่างง่าย เช่น กล่องข้อความและปุ่มคำสั่งบนสไลด์ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มี ActiveX control อยู่แล้ว
1. รับอ้างอิงสไลด์ตามดัชนี
1. เข้าถึง ActiveX control ในสไลด์โดยการเรียก [ControlCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/controlcollection/)
1. เข้าถึง ActiveX control TextBox1 ผ่านอ็อบเจ็กต์ [Control](https://reference.aspose.com/slides/th/python-java/aspose.slides/control/)
1. เปลี่ยนคุณสมบัติของ TextBox1 ActiveX control ซึ่งรวมถึงข้อความ, ฟอนต์, ความสูงของฟอนต์และตำแหน่งของเฟรม
1. เข้าถึง ActiveX control ที่สองที่ชื่อ CommandButton1
1. เปลี่ยนคำบรรยายของปุ่ม, ฟอนต์และตำแหน่ง
1. ปรับตำแหน่งของเฟรมของ ActiveX control
1. เขียนงานนำเสนอที่แก้ไขแล้วออกเป็นไฟล์ PPTM

ตัวอย่างโค้ดด้านล่าง ซึ่งอ้างอิงจากขั้นตอนข้างต้น แสดงวิธีการจัดการ ActiveX control อย่างง่าย:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# โหลดงานนำเสนอที่มี ActiveX control.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # เข้าถึงสไลด์แรก.
        slide = presentation.getSlides().get_Item(0)

        # เปลี่ยนข้อความของกล่องข้อความ.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # เปลี่ยนภาพแทนที่. PowerPoint จะทำการแทนที่ในระหว่างการเปิดใช้งาน ActiveX,
            # ดังนั้นบางครั้งอาจไม่ต้องเปลี่ยน.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # เปลี่ยนคำบรรยายของปุ่ม.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # เปลี่ยนภาพแทนที่.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # เลื่อนคอนโทรลลง 100 พอยท์.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # ลบคอนโทรล.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**Aspose.Slides จะคงไว้ซึ่ง ActiveX control หรือไม่เมื่ออ่านและบันทึกใหม่ หากไม่สามารถรันได้ใน runtime ของ Python?**

ใช่. Aspose.Slides ถือว่ามันเป็นส่วนหนึ่งของงานนำเสนอและสามารถอ่าน/แก้ไขคุณสมบัติและเฟรมของมันได้; ไม่จำเป็นต้องรันคอนโทรลเพื่อคงไว้

**ActiveX control แตกต่างจากวัตถุ OLE ในงานนำเสนออย่างไร?**

ActiveX control เป็นคอนโทรลที่โต้ตอบได้ (เช่น ปุ่ม, กล่องข้อความ, Media Player) ในขณะที่ [OLE](/slides/th/python-java/manage-ole/) หมายถึงวัตถุแอปพลิเคชันที่ฝังอยู่ (เช่น แผ่นงาน Excel) ทั้งสองถูกจัดเก็บและจัดการในรูปแบบที่ต่างกันและมีโมเดลคุณสมบัติที่ต่างกัน

**เหตุการณ์ของ ActiveX และแมโคร VBA จะทำงานหรือไม่หากไฟล์ถูกแก้ไขโดย Aspose.Slides?**

Aspose.Slides คง markup และเมตาดาต้าที่มีอยู่เดิมไว้; อย่างไรก็ตาม เหตุการณ์และแมโครจะทำงานได้เฉพาะใน PowerPoint บน Windows เมื่อความปลอดภัยอนุญาต ไลบรารีไม่ได้ทำการรัน VBA.