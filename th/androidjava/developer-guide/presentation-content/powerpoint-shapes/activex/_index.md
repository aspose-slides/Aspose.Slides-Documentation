---
title: จัดการคอนโทรล ActiveX ในพรีเซนเทชันบน Android
linktitle: ActiveX
type: docs
weight: 80
url: /th/androidjava/activex/
keywords:
- ActiveX
- คอนโทรล ActiveX
- จัดการ ActiveX
- เพิ่ม ActiveX
- แก้ไข ActiveX
- เครื่องเล่นสื่อ
- PowerPoint
- พรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "เรียนรู้ว่า Aspose.Slides สำหรับ Android ผ่าน Java ใช้ ActiveX เพื่ออัตโนมัติและปรับปรุงพรีเซนเทชัน PowerPoint ให้กับนักพัฒนามีการควบคุมสไลด์อย่างมีประสิทธิภาพ"
---
## **บทนำ**

คอนโทรล ActiveX ถูกใช้ในงานพรีเซนเทชัน Aspose.Slides สำหรับ Android via Java ให้คุณเพิ่มและจัดการคอนโทรล ActiveX ได้ แต่การจัดการคอนโทรลเหล่านี้ค่อนข้างซับซ้อนกว่าเมื่อเทียบกับรูปร่างปกติในพรีเซนเทชัน เราได้เพิ่มการสนับสนุนการเพิ่มคอนโทรล Media Player Active ใน Aspose.Slides โปรดทราบว่าคอนโทรล ActiveX ไม่ใช่รูปร่าง; พวกมันไม่ได้เป็นส่วนหนึ่งของพรีเซนเทชันที่อยู่ใน [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/) พวกมันเป็นส่วนหนึ่งของ [IControlCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icontrolcollection/) แยกออกมา ในหัวข้อนี้ เราจะแสดงวิธีการทำงานกับคอนโทรลเหล่านั้น

## **เพิ่มคอนโทรล Media Player ActiveX ลงในสไลด์**
เพื่อเพิ่มคอนโทรล Media Player ActiveX ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และสร้างพรีเซนเทชันที่ว่างเปล่า
1. เข้าถึงสไลด์เป้าหมายใน [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. เพิ่มคอนโทรล Media Player ActiveX โดยใช้เมธอด [addControl](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) ที่เผยโดย [IControlCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icontrolcollection/)
1. เข้าถึงคอนโทรล Media Player ActiveX และตั้งค่าพาธของวิดีโอโดยใช้คุณสมบัติของมัน
1. บันทึกพรีเซนเทชันเป็นไฟล์ PPTX

โค้ดตัวอย่างนี้ ซึ่งอิงตามขั้นตอนข้างต้น แสดงวิธีการเพิ่มคอนโทรล Media Player ActiveX ลงในสไลด์:

```java
// สร้างอินสแตนซ์พรีเซนเทชันว่างเปล่า
Presentation pres = new Presentation();
try {
    // เพิ่มคอนโทรล Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // เข้าถึงคอนโทรล Media Player ActiveX และตั้งค่าพาธของวิดีโอ
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // บันทึกพรีเซนเทชัน
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **แก้ไขคอนโทรล ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides สำหรับ Android via Java เวอร์ชัน 7.1.0 และใหม่กว่ามาพร้อมกับองค์ประกอบสำหรับจัดการคอนโทรล ActiveX คุณสามารถเข้าถึงคอนโทรล ActiveX ที่เพิ่มไว้แล้วในพรีเซนเทชันของคุณและแก้ไขหรือทำลบได้ผ่านคุณสมบัติของมัน

{{% /alert %}} 

เพื่อจัดการคอนโทรล ActiveX อย่างง่าย เช่น กล่องข้อความและปุ่มกดบนสไลด์ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และโหลดพรีเซนเทชันที่มีคอนโทรล ActiveX อยู่ภายใน
1. รับอ้างอิงสไลด์ตามดัชนี
1. เข้าถึงคอนโทรล ActiveX ในสไลด์โดยเข้าถึง [IControlCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icontrolcollection/)
1. เข้าถึงคอนโทรล TextBox1 ActiveX โดยใช้วัตถุ [IControl](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icontrol/)
1. เปลี่ยนคุณสมบัติของคอนโทรล TextBox1 ActiveX ซึ่งรวมถึงข้อความ, ฟอนต์, ความสูงของฟอนต์, และตำแหน่งของเฟรม
1. เข้าถึงคอนโทรลที่สองชื่อ CommandButton1
1. เปลี่ยนคำบรรยายของปุ่ม, ฟอนต์, และตำแหน่ง
1. ย้ายตำแหน่งของเฟรมคอนโทรล ActiveX
1. เขียนพรีเซนเทชันที่แก้ไขแล้วลงในไฟล์ PPTX

โค้ดตัวอย่างนี้ ซึ่งอิงตามขั้นตอนข้างต้น แสดงวิธีการจัดการคอนโทรล ActiveX อย่างง่าย:

```java
// กำลังเข้าถึงพรีเซนเทชันที่มีคอนโทรล ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // กำลังเข้าถึงสไลด์แรกในพรีเซนเทชัน
    ISlide slide = pres.getSlides().get_Item(0);

    // เปลี่ยนข้อความใน TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // เปลี่ยนภาพแทนที่. PowerPoint จะเปลี่ยนภาพนี้เมื่อเปิดใช้งาน activeX,
        // ดังนั้นบางครั้งอาจปล่อยให้ภาพคงเดิมก็ได้.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // เปลี่ยนคำบรรยายของปุ่ม
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // เปลี่ยนภาพแทนที่
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
                graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
                graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

                graphics.dispose();

                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                ImageIO.write(image, "PNG", baos);

                control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
            }

            // ย้ายลง 100 จุด
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // ลบคอนโทรล
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **FAQ**

**Aspose.Slides รักษาคอนโทรล ActiveX ไว้เมื่อตรวจสอบและบันทึกใหม่หรือไม่ หากคอนโทรลเหล่านั้นไม่สามารถทำงานใน Java runtime ได้?**

ใช่ Aspose.Slides ถือว่าคอนโทรลเหล่านี้เป็นส่วนหนึ่งของพรีเซนเทชันและสามารถอ่าน/แก้ไขคุณสมบัติและเฟรมของมันได้; ไม่จำเป็นต้องทำงานคอนโทรลเหล่านั้นเพื่อรักษาไว้

**คอนโทรล ActiveX แตกต่างจากวัตถุ OLE ในพรีเซนเทชันอย่างไร?**

คอนโทรล ActiveX เป็นคอนโทรลแบบโต้ตอบที่จัดการได้ (เช่น ปุ่ม, กล่องข้อความ, Media Player) ในขณะที่ [OLE](/slides/th/androidjava/manage-ole/) หมายถึงวัตถุแอปพลิเคชันฝัง (เช่น แผ่นงาน Excel) พวกมันถูกจัดเก็บและจัดการต่างกันและมีโมเดลคุณสมบัติที่แตกต่างกัน

**เหตุการณ์ ActiveX และแมโคร VBA ทำงานหรือไม่ หากไฟล์ถูกแก้ไขโดย Aspose.Slides?**

Aspose.Slides รักษา markup และ metadata ที่มีอยู่; อย่างไรก็ตามเหตุการณ์และแมโครจะทำงานเฉพาะใน PowerPoint บน Windows เมื่อความปลอดภัยอนุญาต ไลบรารีไม่ได้ทำการเรียกใช้ VBA