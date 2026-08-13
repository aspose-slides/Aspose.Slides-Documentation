---
title: จัดการ ActiveX Controls ในงานนำเสนอบน Android
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
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้ว่า Aspose.Slides for Android via Java ใช้ประโยชน์จาก ActiveX เพื่อทำอัตโนมัติและปรับปรุงงานนำเสนอ PowerPoint ให้กับนักพัฒนามีการควบคุมสไลด์อย่างมีประสิทธิภาพ"
---
## **บทนำ**

ActiveX controls ถูกใช้ในงานนำเสนอ Aspose.Slides for Android via Java ทำให้คุณสามารถเพิ่มและจัดการ ActiveX controls ได้ แต่การจัดการค่อนข้างซับซ้อนเมื่อเทียบกับรูปร่างปกติในงานนำเสนอ เราได้เพิ่มการสนับสนุนการเพิ่ม Media Player Active control ใน Aspose.Slides โปรดทราบว่า ActiveX controls ไม่ได้เป็นรูปร่าง; พวกมันไม่ใช่ส่วนหนึ่งของ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/) ของงานนำเสนอ แต่เป็นส่วนหนึ่งของ [IControlCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icontrolcollection/) แยกต่างหาก ในหัวข้อนี้ เราจะสาธิตวิธีการใช้งาน ActiveX controls

## **เพิ่ม Media Player ActiveX Control ไปยังสไลด์**
เพื่อเพิ่ม Media Player ActiveX Control ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และสร้างงานนำเสนอเปล่า
1. เข้าถึงสไลด์เป้าหมายใน [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. เพิ่ม Media Player ActiveX control ด้วยเมธอด [addControl](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) ที่เปิดให้ใช้จาก [IControlCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icontrolcollection/)
1. เข้าถึง Media Player ActiveX control แล้วกำหนดเส้นทางวิดีโอโดยใช้คุณสมบัติของมัน
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX

โค้ดตัวอย่างต่อไปนี้ ซึ่งอิงตามขั้นตอนข้างต้น แสดงวิธีการเพิ่ม Media Player ActiveX Control ไปยังสไลด์:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของงานนำเสนอเปล่า
Presentation pres = new Presentation();
try {
    // เพิ่ม Media Player ActiveX control
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // เข้าถึง Media Player ActiveX control และกำหนดเส้นทางวิดีโอ
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // บันทึกงานนำเสนอ
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **แก้ไข ActiveX Control**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java 7.1.0 และเวอร์ชันใหม่กว่า มาพร้อมกับคอมโพเนนต์สำหรับจัดการ ActiveX controls คุณสามารถเข้าถึง ActiveX control ที่ได้เพิ่มไว้ในงานนำเสนอและแก้ไขหรือทำการลบผ่านคุณสมบัติของมันได้

{{% /alert %}} 

เพื่อจัดการกับ ActiveX control แบบง่าย เช่น กล่องข้อความและปุ่มคำสั่งบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มี ActiveX controls อยู่
1. รับอ้างอิงสไลด์ตามดัชนี
1. เข้าถึง ActiveX controls ในสไลด์โดยใช้ [IControlCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icontrolcollection/)
1. เข้าถึง TextBox1 ActiveX control ผ่านออบเจกต์ [IControl](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icontrol/)
1. เปลี่ยนคุณสมบัติของ TextBox1 ActiveX control ได้แก่ ข้อความ ฟอนต์ ความสูงของฟอนต์ และตำแหน่งกรอบ
1. เข้าถึงการควบคุมที่สองที่ชื่อ CommandButton1
1. เปลี่ยนคำบรรยายของปุ่ม ฟอนต์ และตำแหน่ง
1. ย้ายตำแหน่งของกรอบ ActiveX controls
1. เขียนงานนำเสนอที่แก้ไขแล้วลงไฟล์ PPTX

โค้ดตัวอย่างต่อไปนี้ แสดงวิธีการจัดการ ActiveX control แบบง่าย:

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// เข้าถึงงานนำเสนอที่มี ActiveX controls
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // เข้าถึงสไลด์แรกในงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เปลี่ยนข้อความของ TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // เปลี่ยนภาพแทน. PowerPoint จะเปลี่ยนภาพนี้ระหว่างการเปิดใช้งาน ActiveX,
        // ดังนั้นบางครั้งจึงสามารถปล่อยให้ภาพคงเดิมได้.
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

        // เปลี่ยนภาพแทน
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
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Aspose.Slides จะคงรักษา ActiveX controls ไว้เมื่ออ่านและบันทึกใหม่หรือไม่ หากไม่สามารถเรียกใช้ได้ใน Java runtime?

ใช่ Aspose.Slides ถือว่า ActiveX controls เป็นส่วนหนึ่งของงานนำเสนอและสามารถอ่าน/แก้ไขคุณสมบัติและกรอบของมันได้; ไม่จำเป็นต้องเรียกใช้ controls เองเพื่อคงไว้

### ActiveX controls แตกต่างจากวัตถุ OLE ในงานนำเสนออย่างไร?

ActiveX controls เป็นคอนโทรลที่โต้ตอบได้ (ปุ่ม, กล่องข้อความ, media player) ส่วน [OLE](/slides/th/androidjava/manage-ole/) หมายถึงวัตถุแอปพลิเคชันที่ฝังอยู่ (เช่น worksheet ของ Excel) ทั้งสองถูกจัดเก็บและจัดการต่างกันและมีโมเดลคุณสมบัติที่แตกต่างกัน

### เหตุการณ์ ActiveX และแมโคร VBA จะทำงานหรือไม่ หากไฟล์ถูกแก้ไขโดย Aspose.Slides?

Aspose.Slides จะคง markup และ metadata ที่มีอยู่ไว้ แต่เหตุการณ์และแมโครจะทำงานเฉพาะบน PowerPoint สำหรับ Windows เมื่อการตั้งค่าความปลอดภัยอนุญาต ไลบรารีไม่ได้ทำการเรียกใช้ VBA