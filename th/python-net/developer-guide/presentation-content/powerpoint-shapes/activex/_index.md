---
title: จัดการ ActiveX Controls ในงานนำเสนอด้วย Python
linktitle: ActiveX
type: docs
weight: 80
url: /th/python-net/activex/
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
description: "เรียนรู้ว่า Aspose.Slides for Python via .NET ใช้ ActiveX อย่างไรเพื่อทำงานอัตโนมัติและปรับปรุงงานนำเสนอ PowerPoint ให้กับนักพัฒนาโดยมอบการควบคุมที่มีประสิทธิภาพต่อสไลด์"
---
## **บทนำ**

ActiveX control ถูกใช้ในงานนำเสนอ Aspose.Slides for Python via .NET ช่วยให้คุณจัดการ ActiveX control ได้ แต่การจัดการนั้นค่อนข้างซับซ้อนและแตกต่างจากรูปร่างทั่วไปของงานนำเสนอ ตั้งแต่ Aspose.Slides for Python via .NET 6.9.0 คอมโพเนนต์นี้รองรับการจัดการ ActiveX control แล้ว ขณะนี้คุณสามารถเข้าถึง ActiveX control ที่เพิ่มไว้แล้วในงานนำเสนอของคุณและแก้ไขหรือทำลายได้โดยใช้คุณสมบัติต่าง ๆ จำไว้ว่า ActiveX control ไม่ใช่รูปร่างและไม่ได้เป็นส่วนหนึ่งของ IShapeCollection ของงานนำเสนอ แต่เป็นส่วนแยกของ IControlCollection บทความนี้จะแสดงวิธีทำงานกับมัน

## **แก้ไข ActiveX Control**
เพื่อจัดการ ActiveX control ที่ง่าย เช่น กล่องข้อความและปุ่มคำสั่งบนสไลด์:

1. สร้างอินสแตนซ์ของคลาส Presentation และโหลดงานนำเสนอที่มี ActiveX control อยู่ในนั้น  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เข้าถึง ActiveX control ในสไลด์โดยการเข้าถึง IControlCollection  
1. เข้าถึง ActiveX control ชื่อ TextBox1 ด้วยอ็อบเจ็กต์ ControlEx  
1. เปลี่ยนแปลงคุณสมบัติต่าง ๆ ของ ActiveX control TextBox1 รวมถึงข้อความ ฟอนท์ ความสูงของฟอนท์ และตำแหน่งของเฟรม  
1. เข้าถึง control ที่สองชื่อ CommandButton1  
1. เปลี่ยนคำบรรยายของปุ่ม ฟอนท์ และตำแหน่ง  
1. ย้ายตำแหน่งของเฟรม ActiveX control  
1. เขียนงานนำเสนอที่แก้ไขแล้วลงไฟล์ PPTX

โค้ดสแนปช็อตด้านล่างจะอัพเดต ActiveX control บนสไลด์ของงานนำเสนอดังแสดงด้านล่าง

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# เข้าถึงงานนำเสนอที่มี ActiveX control
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # เข้าถึงสไลด์แรกในงานนำเสนอ
    slide = presentation.slides[0]

    # เปลี่ยนข้อความ TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # เปลี่ยนภาพแทนที่. PowerPoint จะเปลี่ยนภาพนี้ระหว่างการเปิดใช้งาน ActiveX, ดังนั้นบางครั้งอาจทิ้งภาพไว้โดยไม่เปลี่ยน

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # เปลี่ยนคำบรรยายของปุ่ม
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # เปลี่ยนภาพแทนที่
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # ย้ายกรอบ ActiveX ลง 100 จุด
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # บันทึกงานนำเสนอพร้อม ActiveX Control ที่แก้ไขแล้ว
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # กำลังเอา control ออก
    slide.controls.clear()

    # บันทึกงานนำเสนอที่ลบ ActiveX Control แล้ว
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **เพิ่ม ActiveX Media Player Control**
เพื่อเพิ่ม ActiveX Media Player control ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส Presentation และโหลดงานนำเสนอตัวอย่างที่มี Media Player ActiveX control อยู่ในนั้น  
1. สร้างอินสแตนซ์ของคลาส Presentation ปลายทางและสร้างอินสแตนซ์งานนำเสนอเปล่า  
1. คัดลอกสไลด์ที่มี Media Player ActiveX control จากงานนำเสนอเทมเพลตไปยัง Presentation ปลายทาง  
1. เข้าถึงสไลด์ที่คัดลอกใน Presentation ปลายทาง  
1. เข้าถึง ActiveX control ในสไลด์โดยการเข้าถึง IControlCollection  
1. เข้าถึง Media Player ActiveX control และกำหนดเส้นทางวิดีโอโดยใช้คุณสมบัติต่าง ๆ ของมัน  
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # สร้างอินสแตนซ์ของงานนำเสนอเปล่า
    with slides.Presentation() as newPresentation:

        # ลบสไลด์เริ่มต้น
        newPresentation.slides.remove_at(0)

        # คัดลอกสไลด์ที่มี Media Player ActiveX Control
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # เข้าถึง Media Player ActiveX control และตั้งค่าเส้นทางวิดีโอ
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # บันทึกงานนำเสนอ
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**Aspose.Slides จะคง ActiveX control ไว้เมื่ออ่านและบันทึกใหม่หรือไม่ หากไม่สามารถรันได้ใน runtime ของ Python?**

ใช่ Aspose.Slides ถือว่าเป็นส่วนหนึ่งของงานนำเสนอและสามารถอ่าน/แก้ไขคุณสมบัติและเฟรมของมันได้; ไม่จำเป็นต้องรัน control เพื่อต้องการคงไว้

**ActiveX control แตกต่างจากวัตถุ OLE ในงานนำเสนออย่างไร?**

ActiveX control เป็น control ที่โต้ตอบได้และจัดการได้ (เช่น ปุ่ม กล่องข้อความ Media Player) ในขณะที่ [OLE](/slides/th/python-net/manage-ole/) หมายถึงวัตถุแอปพลิเคชันที่ฝังไว้ (เช่น แผ่นงาน Excel) พวกมันถูกจัดเก็บและจัดการต่างกันและมีโมเดลคุณสมบัติที่แตกต่างกัน

**เหตุการณ์ ActiveX และแมโคร VBA จะทำงานหรือไม่ หากไฟล์ถูกแก้ไขโดย Aspose.Slides?**

Aspose.Slides รักษา markup และเมตาดาต้าที่มีอยู่ไว้; อย่างไรก็ตามเหตุการณ์และแมโครจะทำงานได้เฉพาะใน PowerPoint บน Windows เมื่อความปลอดภัยอนุญาตไลบรารีไม่ทำการรัน VBA