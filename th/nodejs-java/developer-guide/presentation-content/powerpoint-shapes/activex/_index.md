---
title: จัดการคอนโทรล ActiveX ในงานนำเสนอโดยใช้ JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /th/nodejs-java/activex/
keywords:
- ActiveX
- คอนโทรล ActiveX
- จัดการ ActiveX
- เพิ่ม ActiveX
- แก้ไข ActiveX
- เครื่องเล่นสื่อ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้ว่า Aspose.Slides สำหรับ Node.js ผ่าน Java ใช้ ActiveX เพื่อทำงานอัตโนมัติและปรับปรุงงานนำเสนอ PowerPoint อย่างไร ให้ผู้พัฒนามีการควบคุมสไลด์อย่างมีประสิทธิภาพ"
---
## **บทนำ**

คอนโทรล ActiveX ถูกใช้ในงานนำเสนอ Aspose.Slides for Node.js ผ่าน Java ช่วยให้คุณเพิ่มและจัดการคอนโทรล ActiveX ได้ แต่การจัดการคอนโทรลเหล่านี้จะซับซ้อนกว่าการจัดการรูปทรงทั่วไปของงานนำเสนอ เราได้เพิ่มการสนับสนุนการเพิ่มคอนโทรล Media Player Active ใน Aspose.Slides โปรดทราบว่าคอนโทรล ActiveX ไม่ใช่รูปทรง; มันไม่เป็นส่วนหนึ่งของงานนำเสนอของคุณใน [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/) พวกมันเป็นส่วนหนึ่งของ [ControlCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/controlcollection/) แยกต่างหาก ในหัวข้อนี้ เราจะแสดงวิธีทำงานกับคอนโทรลเหล่านี้

## **การเพิ่มคอนโทรล Media Player ActiveX ลงในสไลด์**
เพื่อเพิ่มคอนโทรล Media Player ActiveX ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) และสร้างงานนำเสนอเปล่า
2. เข้าถึงสไลด์เป้าหมายใน [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
3. เพิ่มคอนโทรล Media Player ActiveX ด้วยเมธอด [addControl](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) ที่เปิดให้ใช้จาก [ControlCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/controlcollection/)
4. เข้าถึงคอนโทรล Media Player ActiveX และตั้งค่าพาธของวิดีโอโดยใช้คุณสมบัติของมัน
5. บันทึกงานนำเสนอเป็นไฟล์ PPTX

โค้ดตัวอย่างซึ่งอิงตามขั้นตอนข้างต้นแสดงวิธีการเพิ่มคอนโทรล Media Player ActiveX ลงในสไลด์:

```javascript
// สร้างอินสแตนซ์งานนำเสนอเปล่า
var pres = new aspose.slides.Presentation();
try {
    // เพิ่มคอนโทรล Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // เข้าถึงคอนโทรล Media Player ActiveX และตั้งค่าพาธวิดีโอ
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // บันทึกงานนำเสนอ
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การแก้ไขคอนโทรล ActiveX**

เพื่อจัดการคอนโทรล ActiveX อย่างง่าย เช่น กล่องข้อความและปุ่มคำสั่งในสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) และโหลดงานนำเสนอที่มีคอนโทรล ActiveX อยู่ในนั้น
2. รับอ้างอิงสไลด์ตามดัชนีของมัน
3. เข้าถึงคอนโทรล ActiveX ในสไลด์โดยเข้าถึง [ControlCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/controlcollection/)
4. เข้าถึงคอนโทรล ActiveX TextBox1 โดยใช้วัตถุ [Control](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/control/)
5. เปลี่ยนแปลงคุณสมบัติของคอนโทรล ActiveX TextBox1 ซึ่งรวมถึงข้อความ, ฟอนต์, ความสูงของฟอนต์, และตำแหน่งของเฟรม
6. เข้าถึงคอนโทรลที่สองที่ชื่อ CommandButton1
7. เปลี่ยนแปลงคำบรรยายของปุ่ม, ฟอนต์, และตำแหน่ง
8. ย้ายตำแหน่งของเฟรมคอนโทรล ActiveX
9. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ดตัวอย่างซึ่งอิงตามขั้นตอนข้างต้นแสดงวิธีการจัดการคอนโทรล ActiveX อย่างง่าย:

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// เข้าถึงงานนำเสนอที่มีคอนโทรล ActiveX
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // เข้าถึงสไลด์แรกในงานนำเสนอ
    var slide = pres.getSlides().get_Item(0);
    // เปลี่ยนข้อความใน TextBox
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // เปลี่ยนรูปภาพแทนที่. PowerPoint จะเปลี่ยนรูปภาพนี้ระหว่างการเปิดใช้งาน ActiveX,
        // ดังนั้นบางครั้งก็สามารถปล่อยให้รูปภาพไม่เปลี่ยนได้.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // เปลี่ยนคำบรรยายของปุ่ม
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // เปลี่ยนรูปภาพแทนที่
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // ย้ายลง 100 จุด
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // ลบคอนโทรล
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**Aspose.Slides รักษาคอนโทรล ActiveX ไว้หรือไม่เมื่ออ่านและบันทึกใหม่ หากไม่สามารถทำงานใน runtime ของ Python ได้?**

ใช่. Aspose.Slides พิจารณาคอนโทรลเหล่านี้เป็นส่วนหนึ่งของงานนำเสนอและสามารถอ่าน/แก้ไขคุณสมบัติและเฟรมของมันได้; การดำเนินการคอนโทรลเองไม่จำเป็นต่อการรักษาไว้

**คอนโทรล ActiveX แตกต่างจากวัตถุ OLE ในงานนำเสนออย่างไร?**

คอนโทรล ActiveX คือคอนโทรลที่จัดการแบบโต้ตอบ (เช่น ปุ่ม, กล่องข้อความ, Media Player) ในขณะที่ [OLE](/slides/th/nodejs-java/manage-ole/) หมายถึงวัตถุแอปพลิเคชันที่ฝังอยู่ (เช่น แผ่นงาน Excel) พวกมันถูกจัดเก็บและจัดการแตกต่างกันและมีโมเดลคุณสมบัติที่แตกต่างกัน

**เหตุการณ์ ActiveX และแมโคร VBA ทำงานหรือไม่หากไฟล์ถูกแก้ไขโดย Aspose.Slides?**

Aspose.Slides คงข้อมูล markup และ metadata ที่มีอยู่ไว้; อย่างไรก็ตาม เหตุการณ์และแมโครจะทำงานเฉพาะใน PowerPoint บน Windows เมื่อความปลอดภัยอนุญาตเท่านั้น ไลบรารีไม่ได้ทำการเรียกใช้ VBA