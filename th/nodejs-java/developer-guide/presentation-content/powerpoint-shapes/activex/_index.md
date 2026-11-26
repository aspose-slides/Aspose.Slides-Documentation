---
title: จัดการคอนโทรล ActiveX ในการนำเสนอด้วย JavaScript
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
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แก้ไขกล่องข้อความและปุ่ม ActiveX, อัปเดตตัวอย่างล่วงหน้าของคอนโทรล, และใช้ซ้ำคอนโทรล Windows Media Player ในการนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **คำนำ**

ActiveX controls ให้สไลด์ PowerPoint มีองค์ประกอบเชิงโต้ตอบ เช่น กล่องข้อความ ปุ่มคำสั่ง และเครื่องเล่นสื่อ. Aspose.Slides สำหรับ Node.js ผ่าน Java เปิดเผยการควบคุมของสไลด์ผ่าน [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). ใช้คอลเลกชันนี้เพื่อแก้ไขการควบคุม ย้ายบนสไลด์ หรือเอาออก.

## **รายการควบคุม ActiveX และคุณสมบัติที่จัดเก็บไว้**

เพื่อสำรวจเทมเพลตที่ไม่คุ้นเคย ให้เปิดเพื่ออ่านและวนลูปผ่านการควบคุมในแต่ละสไลด์. ตัวอย่างจะแสดงหมายเลขสไลด์ ชื่อการควบคุม [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId) และคู่ค่า‑คีย์แต่ละรายการใน [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). มันอ่านการนำเสนอโดยไม่ทำให้การควบคุมทำงาน เรียกเหตุการณ์หรือมาโคร เปลี่ยนค่า หรือบันทึกไฟล์.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
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

คอลเลกชันคุณสมบัติที่ว่างจะแสดงเป็น `[]`. สำหรับการควบคุมที่ใช้การจัดเก็บแบบไบต์, [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) อาจคืนค่า `null`, แสดงเป็น `Properties unavailable`. หากต้องการเฉพาะชื่อ ให้ใช้ [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) หลังจากตรวจสอบค่า null. รายงานจะแสดงคุณสมบัติที่สามารถเข้าถึงได้จากการนำเสนอ. การควบคุมอาจรองรับคุณสมบัติเพิ่มเติมในเวลารันไทม์.

## **แก้ไขควบคุม ActiveX**

ตัวอย่างคาดว่าการนำเสนอเปิดใช้มาโครจะมีกล่องข้อความชื่อ `TextBox1` และปุ่มคำสั่งชื่อ `CommandButton1` บนสไลด์แรก. มันใช้ [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) เพื่อเปลี่ยนค่ากล่องข้อความและคำบรรยายของปุ่ม. แต่ละการควบคุมยังมีภาพตัวอย่างแบบคงที่ที่ PowerPoint สามารถแสดงก่อนการเปิดใช้งาน. ให้จัดเตรียมไฟล์ PNG สำหรับแต่ละการควบคุมเพื่อแสดงข้อความและลักษณะที่อัปเดต. ตัวอย่างกำหนดภาพเหล่านี้ผ่าน [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

ตัวอย่างย้ายการควบคุมทุกชิ้นบนสไลด์แรกลง 100 จุดโดยตั้งกรอบของมันด้วย [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). จากนั้นบันทึกการนำเสนอที่แก้ไขเป็นรูปแบบ PPTM และใช้ [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) เพื่อบันทึกสำเนาที่สองที่ลบการควบคุม ActiveX ทั้งหมดออกจากสไลด์นั้น.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```

## **เพิ่มควบคุม Media Player ของ ActiveX**

เพื่อใช้ซ้ำการควบคุม Windows Media Player ที่กำหนดค่าแล้ว ให้เริ่มต้นด้วยเทมเพลตที่สไลด์แรกมีผู้เล่นชื่อ `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) คัดลอกสไลด์ทั้งหมดไปยังการนำเสนอใหม่. ตัวอย่างตั้งค่า `URL` ของผู้เล่นใน [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) และบันทึกสไลด์ที่คัดลอกเป็นสไลด์เดียวในผลลัพธ์. วิดีโอจะยังคงเป็นไฟล์ภายนอก ดังนั้นให้เลือกพาธที่ผู้เล่นสามารถเข้าถึงได้ระหว่างการเล่น.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถเก็บควบคุม ActiveX ไว้โดยไม่ต้องรันมันได้หรือไม่?**

ใช่. Aspose.Slides สามารถอ่านและบันทึกการควบคุม รวมถึงคุณสมบัติและตำแหน่งของมันได้โดยไม่ทำให้มันทำงาน.

**ควบคุม ActiveX แตกต่างจากวัตถุ OLE อย่างไร?**

ActiveX controls ให้ผู้ใช้โต้ตอบกับสไลด์ได้ เช่น พิมพ์ข้อความหรือคลิกปุ่ม. ส่วน [OLE object](/slides/th/nodejs-java/manage-ole/) ทำให้สไลด์สามารถบรรจุหรือเชื่อมโยงไปยังเนื้อหาที่จัดการโดยแอปพลิเคชันอื่น เช่น แผ่นงาน Excel.

**เหตุการณ์ ActiveX จะยังคงเรียกใช้มาโคร VBA หลังจากฉันบันทึกการนำเสนอด้วย Aspose.Slides หรือไม่?**

บันทึกการนำเสนอในรูปแบบที่เปิดใช้มาโคร เช่น PPTM เพื่อรักษาโปรเจกต์ VBA ไว้. PowerPoint สำหรับ Windows สามารถรันตัวจัดการเหตุการณ์ที่มีอยู่เมื่อการตั้งค่าความปลอดภัยอนุญาตให้ใช้ทั้งควบคุม ActiveX และมาโคร.