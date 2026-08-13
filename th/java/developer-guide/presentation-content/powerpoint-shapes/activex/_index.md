---
title: "จัดการคอนโทรล ActiveX ในพรีเซนเทชันด้วย Java"
linktitle: "ActiveX"
type: docs
weight: 80
url: /th/java/activex/
keywords:
- ActiveX
- คอนโทรล ActiveX
- จัดการ ActiveX
- เพิ่ม ActiveX
- แก้ไข ActiveX
- ตัวเล่นสื่อ
- PowerPoint
- พรีเซนเทชัน
- Java
- Aspose.Slides
description: "เรียนรู้วิธีที่ Aspose.Slides สำหรับ Java ใช้ ActiveX เพื่อทำงานอัตโนมัติและเพิ่มประสิทธิภาพพรีเซนเทชัน PowerPoint โดยให้ผู้พัฒนามีการควบคุมสไลด์อย่างทรงพลัง."
---
## **บทนำ**

คอนโทรล ActiveX ถูกใช้ในงานพรีเซนเทชัน Aspose.Slides สำหรับ Java อนุญาตให้คุณเพิ่มและจัดการคอนโทรล ActiveX แต่การจัดการคอนโทรลเหล่านี้ค่อนข้างซับซ้อนกว่าเมื่อเทียบกับรูปร่างปกติของพรีเซนเทชัน เราได้เพิ่มการสนับสนุนการเพิ่ม Active control ของ Media Player ใน Aspose.Slides โปรดทราบว่าคอนโทรล ActiveX ไม่ใช่รูปร่าง; พวกมันไม่ได้เป็นส่วนหนึ่งของพรีเซนเทชันใน [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/) แต่เป็นส่วนหนึ่งของ [IControlCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icontrolcollection/) แยกต่างหาก ในหัวข้อนี้ เราจะแสดงวิธีการทำงานกับคอนโทรลเหล่านี้

## **เพิ่มคอนโทรล Media Player ActiveX ลงในสไลด์**
เพื่อเพิ่มคอนโทรล Media Player ActiveX ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และสร้างพรีเซนเทชันเปล่า
2. เข้าถึงสไลด์เป้าหมายใน [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
3. เพิ่มคอนโทรล Media Player ActiveX โดยใช้เมธอด [addControl](https://reference.aspose.com/slides/th/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) ที่เปิดให้บริการโดย [IControlCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icontrolcollection/)
4. เข้าถึงคอนโทรล Media Player ActiveX และตั้งค่าพาธของวิดีโอโดยใช้คุณสมบัติของมัน
5. บันทึกพรีเซนเทชันเป็นไฟล์ PPTX

ตัวอย่างโค้ดนี้ ตามขั้นตอนข้างต้น แสดงวิธีการเพิ่มคอนโทรล Media Player ActiveX ลงในสไลด์:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์พรีเซนเทชันเปล่า
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
{{% alert color="info" %}} 

Aspose.Slides สำหรับ Java รุ่น 7.1.0 และใหม่กว่า มีคอมโพเนนท์สำหรับจัดการคอนโทรล ActiveX คุณสามารถเข้าถึงคอนโทรล ActiveX ที่เพิ่มไว้แล้วในพรีเซนเทชันและแก้ไขหรือทำลบมันผ่านคุณสมบัติของคอนโทรล

{{% /alert %}} 

หากต้องการจัดการคอนโทรล ActiveX อย่างง่าย เช่น กล่องข้อความและปุ่มคำสั่งบนสไลด์ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดพรีเซนเทชันที่มีคอนโทรล ActiveX อยู่
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เข้าถึงคอนโทรล ActiveX ในสไลด์โดยใช้ [IControlCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icontrolcollection/)
4. เข้าถึงคอนโทรล ActiveX TextBox1 ด้วยอ็อบเจกต์ [IControl](https://reference.aspose.com/slides/th/java/com.aspose.slides/icontrol/)
5. เปลี่ยนแปลงคุณสมบัติของคอนโทรล ActiveX TextBox1 ซึ่งรวมถึงข้อความ, แบบอักษร, ความสูงของแบบอักษร, และตำแหน่งของเฟรม
6. เข้าถึงคอนโทรลที่สองที่ชื่อ CommandButton1
7. เปลี่ยนข้อความบนปุ่ม, แบบอักษร, และตำแหน่ง
8. ปรับตำแหน่งของเฟรมคอนโทรล ActiveX
9. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

ตัวอย่างโค้ดนี้ ตามขั้นตอนข้างต้น แสดงวิธีการจัดการคอนโทรล ActiveX อย่างง่าย: 

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// กำลังเข้าถึงพรีเซนเทชันที่มีคอนโทรล ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // กำลังเข้าถึงสไลด์แรกในพรีเซนเทชัน
    ISlide slide = pres.getSlides().get_Item(0);

    // กำลังเปลี่ยนข้อความใน TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // กำลังเปลี่ยนภาพแทน. PowerPoint จะเปลี่ยนภาพนี้เมื่อเปิดใช้งาน ActiveX,
        // ดังนั้นบางครั้งก็ปล่อยให้ภาพคงเดิมก็ได้.
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

    // กำลังเปลี่ยนข้อความปุ่ม
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // กำลังเปลี่ยนภาพแทน
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

            // กำลังลบคอนโทรล
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **คำถามที่พบบ่อย**

### Aspose.Slides จะคงคอนโทรล ActiveX ไว้เมื่ออ่านและบันทึกใหม่หรือไม่ หากคอนโทรลเหล่านั้นไม่สามารถทำงานใน runtime ของ Java?
ใช่ Aspose.Slides พิจารณาว่าเป็นส่วนหนึ่งของพรีเซนเทชันและสามารถอ่าน/แก้ไขคุณสมบัติและเฟรมของมันได้; ไม่จำเป็นต้องทำงานคอนโทรลเหล่านั้นเพื่อคงไว้

### คอนโทรล ActiveX แตกต่างจากอ็อบเจกต์ OLE อย่างไรในพรีเซนเทชัน?
คอนโทรล ActiveX เป็นคอนโทรลที่โต้ตอบได้และจัดการ (ปุ่ม, กล่องข้อความ, Media Player) ในขณะที่ [OLE](/slides/th/java/manage-ole/) หมายถึงอ็อบเจกต์แอปพลิเคชันที่ฝังอยู่ (เช่น แผ่นงาน Excel) พวกมันถูกเก็บและจัดการแตกต่างกันและมีโมเดลคุณสมบัติที่ต่างกัน

### เหตุการณ์ ActiveX และแมโคร VBA จะทำงานหรือไม่ หากไฟล์ถูกแก้ไขโดย Aspose.Slides?
Aspose.Slides คงส่วนของ markup และ metadata เดิมไว้; อย่างไรก็ตามเหตุการณ์และแมโครจะทำงานเฉพาะบน PowerPoint ใน Windows เมื่อมีการอนุญาตตามความปลอดภัย ไลบรารีไม่ทำการรัน VBA