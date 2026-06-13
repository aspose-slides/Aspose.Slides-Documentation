---
title: จัดการคอนโทรล ActiveX ในการนำเสนอโดยใช้ Java
linktitle: ActiveX
type: docs
weight: 80
url: /th/java/activex/
keywords:
- ActiveX
- คอนโทรล ActiveX
- จัดการ ActiveX
- เพิ่ม ActiveX
- แก้ไข ActiveX
- เครื่องเล่นสื่อ
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้ว่ารายการ Aspose.Slides for Java ใช้ ActiveX เพื่อทำอัตโนมัติและเพิ่มประสิทธิภาพการนำเสนอ PowerPoint อย่างไร โดยมอบการควบคุมที่ทรงพลังให้กับนักพัฒนาสำหรับสไลด์"
---
## **บทนำ**

ActiveX controls ถูกใช้ในงานนำเสนอ Aspose.Slides for Java ช่วยให้คุณสามารถเพิ่มและจัดการ ActiveX controls ได้ แต่การจัดการพวกมันจะซับซ้อนกว่าสไลด์รูปร่างธรรมดาเล็กน้อย เราได้เพิ่มการสนับสนุนการเพิ่ม Media Player Active control ใน Aspose.Slides โปรดทราบว่า ActiveX controls ไม่ใช่รูปร่าง; พวกมันไม่ได้เป็นส่วนหนึ่งของงานนำเสนอของ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/) แต่เป็นส่วนหนึ่งของ [IControlCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icontrolcollection/) แยกต่างหาก ในหัวข้อนี้ เราจะแสดงวิธีการทำงานกับพวกมัน  

## **เพิ่ม Media Player ActiveX Control ลงสไลด์**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และสร้างอินสแตนซ์ของงานนำเสนอเปล่า
2. เข้าถึงสไลด์เป้าหมายใน [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
3. เพิ่ม Media Player ActiveX control โดยใช้เมธอด [addControl](https://reference.aspose.com/slides/th/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) ที่เปิดโดย [IControlCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icontrolcollection/)
4. เข้าถึง Media Player ActiveX control และตั้งค่าเส้นทางวิดีโอโดยใช้คุณสมบัติของมัน
5. บันทึกงานนำเสนอเป็นไฟล์ PPTX

โค้ดตัวอย่างนี้ ซึ่งอ้างอิงจากขั้นตอนข้างต้น จะแสดงวิธีเพิ่ม Media Player ActiveX Control ลงสไลด์:

```java
// สร้างอินสแตนซ์การนำเสนอเปล่า
Presentation pres = new Presentation();
try {
    // เพิ่ม Media Player ActiveX control
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // เข้าถึง Media Player ActiveX control และตั้งค่าเส้นทางวิดีโอ
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // บันทึกการนำเสนอ
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **แก้ไข ActiveX Control**
{{% alert color="primary" %}} 
Aspose.Slides for Java 7.1.0 และรุ่นที่ใหม่กว่า มีคอมโพเนนต์สำหรับการจัดการ ActiveX controls คุณสามารถเข้าถึง ActiveX control ที่ได้เพิ่มไว้ในงานนำเสนอของคุณและแก้ไขหรือทำการลบผ่านคุณสมบัติของมัน
{{% /alert %}} 

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) และโหลดงานนำเสนอที่มี ActiveX controls อยู่
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เข้าถึง ActiveX controls ในสไลด์โดยการเข้าถึง [IControlCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/icontrolcollection/)
4. เข้าถึง TextBox1 ActiveX control โดยใช้วัตถุ [IControl](https://reference.aspose.com/slides/th/java/com.aspose.slides/icontrol/)
5. เปลี่ยนแปลงคุณสมบัติของ TextBox1 ActiveX control ซึ่งรวมถึงข้อความ, ฟอนต์, ความสูงของฟอนต์, และตำแหน่งเฟรม
6. เข้าถึงคอนโทรลที่สองที่ชื่อ CommandButton1
7. เปลี่ยนแปลงข้อความบนปุ่ม, ฟอนต์, และตำแหน่ง
8. ย้ายตำแหน่งของเฟรมของ ActiveX controls
9. เขียนงานนำเสนอที่แก้ไขแล้วลงไฟล์ PPTX

โค้ดตัวอย่างนี้ ซึ่งอ้างอิงจากขั้นตอนข้างต้น แสดงวิธีจัดการกับ ActiveX control อย่างง่าย: 

```java
// เข้าถึงงานนำเสนอที่มีคอนโทรล ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // เข้าถึงสไลด์แรกในงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เปลี่ยนข้อความใน TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // เปลี่ยนภาพแทนที่ PowerPoint จะเปลี่ยนภาพนี้ระหว่างการเปิดใช้งาน activeX
        // ดังนั้นบางครั้งจึงสามารถปล่อยให้ภาพคงเดิมได้
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

    // เปลี่ยนข้อความปุ่ม
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

## **คำถามที่พบบ่อย**

**Aspose.Slides จะคงรักษา ActiveX controls ไว้เมื่ออ่านและบันทึกใหม่หรือไม่ หากไม่สามารถทำงานใน Java runtime?**  
ใช่. Aspose.Slides ถือว่าเป็นส่วนหนึ่งของงานนำเสนอและสามารถอ่าน/แก้ไขคุณสมบัติและเฟรมของพวกมันได้; ไม่จำเป็นต้องทำงานควบคุมเหล่านั้นเพื่อคงรักษาไว้

**ActiveX controls แตกต่างจากวัตถุ OLE ในงานนำเสนออย่างไร?**  
ActiveX controls เป็นคอนโทรลแบบโต้ตอบที่จัดการได้ (เช่น ปุ่ม, กล่องข้อความ, Media Player) ในขณะที่ [OLE](/slides/th/java/manage-ole/) หมายถึงวัตถุแอปพลิเคชันที่ฝังอยู่ (เช่น แผ่นงาน Excel) พวกมันถูกจัดเก็บและจัดการแตกต่างกันและมีโมเดลคุณสมบัติเฉพาะ

**เหตุการณ์ ActiveX และแมโคร VBA จะทำงานหรือไม่ หากไฟล์ถูกแก้ไขโดย Aspose.Slides?**  
Aspose.Slides คงรักษา markup และ metadata ที่มีอยู่ไว้; อย่างไรก็ตามเหตุการณ์และแมโครจะทำงานได้เฉพาะใน PowerPoint บน Windows เมื่อการตั้งค่าความปลอดภัยอนุญาต ไลบรารีไม่ทำการเรียกใช้ VBA