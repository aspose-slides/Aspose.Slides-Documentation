---
title: จัดการคอนโทรล ActiveX ในงานนำเสนอบน Android
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
- โปรแกรมเล่นสื่อ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แก้ไขกล่องข้อความและปุ่มของ ActiveX, ปรับปรุงการแสดงตัวอย่างคอนโทรล, และใช้ซ้ำคอนโทรล Windows Media Player ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **บทนำ**

ActiveX คอนโทรลทำให้สไลด์ PowerPoint มีองค์ประกอบเชิงโต้ตอบ เช่น กล่องข้อความ ปุ่มคำสั่ง และเครื่องเล่นสื่อ Aspose.Slides for Android ผ่าน Java เปิดเผยคอนโทรลของสไลด์ผ่าน [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--). ใช้คอลเลกชันนี้เพื่อแก้ไขคอนโทรล ย้ายมันบนสไลด์ หรือเอาออก ในตัวอย่างด้านล่าง ให้ใช้เส้นทางไฟล์ที่แอป Android ของคุณสามารถอ่านได้และเลือกตำแหน่งที่เขียนได้สำหรับการนำเสนอผลลัพธ์แต่ละไฟล์.

## **รายการควบคุม ActiveX และคุณสมบัติที่จัดเก็บ**

เพื่อสำรวจเทมเพลตที่ไม่คุ้นเคย ให้เปิดเพื่ออ่านและวนลูปผ่านคอนโทรลในแต่ละสไลด์ ตัวอย่างแสดงหมายเลขสไลด์ ชื่อคอนโทรล [getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--) และแต่ละคู่คีย์-ค่าใน [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--). มันอ่านการนำเสนอโดยไม่เปิดใช้งานคอนโทรล เรียกเหตุการณ์หรือมาโคร เปลี่ยนค่า หรือบันทึกไฟล์.

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

ผลลัพธ์ที่เลือกจาก `ActiveX.pptm` แสดงกล่องข้อความและปุ่มคำสั่ง.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

คอลเลกชันคุณสมบัติที่ว่างเปล่าจะแสดงเป็น `[]`. สำหรับคอนโทรลที่ใช้การจัดเก็บไบนารี, [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) สามารถคืนค่า `null` ซึ่งแสดงเป็น `Properties unavailable`. หากคุณต้องการเพียงชื่อ ให้ใช้ [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) หลังจากตรวจสอบค่า null. รายงานแสดงรายการคุณสมบัติที่มีในการนำเสนอ คอนโทรลอาจสนับสนุนคุณสมบัติเพิ่มเติมในขณะทำงาน.

## **แก้ไขควบคุม ActiveX**

ตัวอย่างต้องการการนำเสนอที่เปิดใช้งานมาโคร โดยมีกล่องข้อความชื่อ `TextBox1` และปุ่มคำสั่งชื่อ `CommandButton1` บนสไลด์แรก มันใช้ [control properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) เพื่อเปลี่ยนค่ากล่องข้อความและคำบรรยายของปุ่ม แต่ละคอนโทรลยังมีการแสดงตัวอย่างแบบคงที่ที่ PowerPoint สามารถแสดงก่อนการเปิดใช้งาน ให้จัดหาภาพ PNG สำหรับแต่ละคอนโทรลที่แสดงข้อความและรูปลักษณ์ที่อัปเดต ตัวอย่างกำหนดภาพเหล่านี้ผ่าน [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

ตัวอย่างย้ายคอนโทรลทั้งหมดบนสไลด์แรกลง 100 จุดโดยตั้งค่าเฟรมของมันด้วย [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). มันบันทึกการนำเสนอที่แก้ไขในรูปแบบ PPTM จากนั้นใช้ [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) เพื่อบันทึกสำเนาที่สองโดยลบคอนโทรล ActiveX ทั้งหมดออกจากสไลด์นั้น.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

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

    IPPImage textBoxPreview;
    IPPImage buttonPreview;
    try (FileInputStream textBoxStream = new FileInputStream("text-box-preview.png");
         FileInputStream buttonStream = new FileInputStream("button-preview.png")) {
        textBoxPreview = presentation.getImages().addImage(textBoxStream);
        buttonPreview = presentation.getImages().addImage(buttonStream);
    }
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

เพื่อใช้ซ้ำคอนโทรล Windows Media Player ที่ตั้งค่าไว้ ให้เริ่มต้นด้วยเทมเพลตที่สไลด์แรกมีผู้เล่นชื่อ `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) คัดลอกสไลด์ทั้งหมดไปยังการนำเสนอใหม่ ตัวอย่างตั้งค่า `URL` ของผู้เล่นใน [properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) และบันทึกสไลด์ที่คัดลอกเป็นสไลด์เดียวในผลลัพธ์ วีดีโอยังคงเป็นไฟล์ภายนอก ดังนั้นให้เลือกเส้นทางที่ผู้เล่นสามารถเข้าถึงระหว่างการเล่น.

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

**Aspose.Slides สามารถเก็บคอนโทรล ActiveX ไว้โดยไม่ต้องรันมันได้หรือไม่?**  
ใช่. Aspose.Slides สามารถอ่านและบันทึกคอนโทรล รวมถึงคุณสมบัติและตำแหน่งของมัน ได้โดยไม่ต้องเปิดใช้งาน.

**คอนโทรล ActiveX แตกต่างจากวัตถุ OLE อย่างไร?**  
คอนโทรล ActiveX ให้ผู้ใช้โต้ตอบกับสไลด์ได้ เช่น การพิมพ์ข้อความหรือคลิกปุ่ม ส่วน [วัตถุ OLE](/slides/th/androidjava/manage-ole/) ทำให้สไลด์สามารถบรรจุหรือเชื่อมโยงไปยังเนื้อหาที่จัดการโดยแอปพลิเคชันอื่น เช่น แผ่นงาน Excel.

**เหตุการณ์ ActiveX จะยังคงเรียกแมโคร VBA หลังจากที่ฉันบันทึกการนำเสนอด้วย Aspose.Slides หรือไม่?**  
บันทึกการนำเสนอในรูปแบบที่เปิดใช้งานมาโคร เช่น PPTM เพื่อรักษาโปรเจกต์ VBA ไว้ PowerPoint สำหรับ Windows สามารถเรียกตัวจัดการเหตุการณ์ที่มีอยู่ได้เมื่อการตั้งค่าความปลอดภัยอนุญาตให้ใช้ทั้งคอนโทรล ActiveX และมาโคร.