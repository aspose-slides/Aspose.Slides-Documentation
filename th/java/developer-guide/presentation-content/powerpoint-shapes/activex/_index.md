---
title: จัดการคอนโทรล ActiveX ในการนำเสนอด้วย Java
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
description: "แก้ไขกล่องข้อความและปุ่ม ActiveX, อัปเดตภาพตัวอย่างของคอนโทรล, และใช้คอนโทรล Windows Media Player ซ้ำในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java."
---
## **บทนำ**

ActiveX controls ให้แผ่นสไลด์ PowerPoint มีองค์ประกอบแบบโต้ตอบ เช่น กล่องข้อความ, ปุ่มกด, และเครื่องเล่นสื่อ. Aspose.Slides for Java เปิดเผยคอนโทรลของสไลด์ผ่าน [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). ใช้คอลเล็กชันนี้เพื่อแก้ไขคอนโทรล, ย้ายคอนโทรลบนสไลด์, หรือเอาคอนโทรลออก

## **รายการคอนโทรล ActiveX และคุณสมบัติที่จัดเก็บ**

เพื่อสำรวจเทมเพลตที่ไม่คุ้นเคย ให้เปิดไฟล์เพื่ออ่านและวนลูปผ่านคอนโทรลบนแต่ละสไลด์ ตัวอย่างจะรายงานหมายเลขสไลด์, ชื่อคอนโทรล, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), และคู่คีย์‑ค่าแต่ละคู่ใน [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). ตัวอย่างอ่านการนำเสนอโดยไม่เปิดใช้งานคอนโทรล, เรียกเหตุการณ์หรือมาโคร, เปลี่ยนค่า, หรือบันทึกไฟล์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ที่เลือกจาก `ActiveX.pptm` แสดงกล่องข้อความและปุ่มกด

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

คอลเล็กชันคุณสมบัติที่ว่างจะแสดงเป็น `[]`. สำหรับคอนโทรลที่ใช้การจัดเก็บแบบไบต์, [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) อาจคืนค่า `null`, แสดงเป็น `Properties unavailable`. หากต้องการเฉพาะชื่อเท่านั้น ให้ใช้ [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) หลังจากตรวจสอบว่าเป็น `null`. รายงานจะแสดงคุณสมบัติที่มีในงานนำเสนอ คอนโทรลอาจสนับสนุนคุณสมบัติเพิ่มเติมในเวลารัน

## **แก้ไข ActiveX Controls**

ตัวอย่างคาดว่าการนำเสนอเปิดใช้งานมาโครจะมีกล่องข้อความชื่อ `TextBox1` และปุ่มกดชื่อ `CommandButton1` บนสไลด์แรก ใช้ [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) เพื่อเปลี่ยนค่ากล่องข้อความและคำบรรยายของปุ่ม คอนโทรลแต่ละตัวยังมีภาพตัวอย่างคงที่ที่ PowerPoint สามารถแสดงก่อนการเปิดใช้งาน ให้จัดหาไฟล์ PNG สำหรับแต่ละคอนโทรลที่แสดงข้อความและรูปลักษณ์ที่อัปเดต ตัวอย่างกำหนดภาพเหล่านี้ผ่าน [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--)

ตัวอย่างย้ายคอนโทรลทุกตัวบนสไลด์แรกลง 100 จุดโดยตั้งกรอบของคอนโทรลด้วย [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). จากนั้นบันทึกการนำเสนอที่แก้ไขในรูปแบบ PPTM, แล้วใช้ [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) เพื่อบันทึกสำเนาที่สองโดยเอาคอนโทรล ActiveX ทั้งหมดออกจากสไลด์นั้น

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```
## **เพิ่มคอนโทรล Media Player ของ ActiveX**

เพื่อใช้คอนโทรล Windows Media Player ที่กำหนดค่าไว้แล้ว ให้เริ่มด้วยเทมเพลตที่สไลด์แรกมีผู้เล่นชื่อ `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) จะคัดลอกสไลด์ทั้งหมดไปยังงานนำเสนอใหม่ ตัวอย่างตั้งค่า `URL` ของผู้เล่นใน [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) และบันทึกสไลด์ที่คัดลอกเป็นสไลด์เดียวในผลลัพธ์ วิดีโอจะยังคงเป็นไฟล์ภายนอก ดังนั้นให้เลือกพาธที่ผู้เล่นสามารถเข้าถึงได้ระหว่างการเล่น

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```
## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถเก็บคอนโทรล ActiveX ไว้โดยไม่ต้องรันหรือไม่?**

ใช่. Aspose.Slides สามารถอ่านและบันทึกคอนโทรลรวมถึงคุณสมบัติและตำแหน่งของมันโดยไม่ต้องเปิดใช้งานคอนโทรล

**คอนโทรล ActiveX แตกต่างจาก OLE object อย่างไร?**

คอนโทรล ActiveX ให้ผู้ใช้โต้ตอบกับสไลด์ได้, ตัวอย่างเช่น การพิมพ์ข้อความหรือการคลิกปุ่ม. OLE object [OLE object](/slides/th/java/manage-ole/) ทำให้สไลด์สามารถบรรจุหรือเชื่อมโยงไปยังเนื้อหาที่จัดการโดยแอปพลิเคชันอื่น, เช่น แผ่นงาน Excel

**คอนโทรล ActiveX จะยังคงทำให้ VBA macro ทำงานหลังจากบันทึกการนำเสนอด้วย Aspose.Slides หรือไม่?**

บันทึกการนำเสนอในรูปแบบที่เปิดใช้งานมาโคร เช่น PPTM เพื่อรักษาโครงการ VBA ไว้. PowerPoint สำหรับ Windows สามารถรันตัวจัดการเหตุการณ์ที่มีอยู่ได้เมื่อการตั้งค่าความปลอดภัยของมันอนุญาตทั้งคอนโทรล ActiveX และมาโคร