---
title: จัดการการเปลี่ยนสไลด์ในงานนำเสนอโดยใช้ JavaScript
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 80
url: /th/nodejs-java/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- นำการเปลี่ยนสไลด์ไปใช้
- การเปลี่ยนสไลด์ขั้นสูง
- การเปลี่ยน Morph
- ประเภทการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์, กำหนดค่าการเลื่อนสไลด์อัตโนมัติ, และปรับแต่ง Morph รวมถึงเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ (Slide transitions) ควบคุมวิธีการแสดงสไลด์ระหว่างการแสดงสไลด์โชว์ ด้วย Aspose.Slides for Node.js via Java คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสไลด์สำหรับแต่ละสไลด์ ตั้งค่าการเลื่อนหน้าด้วยการคลิกเมาส์หรือด้วยตัวนับเวลา และปรับตัวเลือกที่เฉพาะเจาะจงกับเอฟเฟกต์ได้ บทความนี้ใช้ตัวอย่าง JavaScript เพื่อใช้การเปลี่ยนสไลด์ ตั้งค่าระยะเวลาเปลี่ยนสไลด์ที่แม่นยำ จัดการเวลาของสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเหล่านี้เป็นไฟล์ PPTX อีกด้วย

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยนสไลด์ โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และเข้าถึงการตั้งค่าการเปลี่ยนสไลด์ของสไลด์ผ่านเมธอด [getSlideShowTransition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) ใช้เมธอด [setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setType) พร้อมค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/transitiontype/) แล้วบันทึกงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้การเปลี่ยนแบบ Circle กับสไลด์แรกและการเปลี่ยนแบบ Comb กับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์แสดงบนหน้าจอและว่าจะให้การคลิกเมาส์ทำให้สไลด์โชว์เลื่อนหน้าหรือไม่ วิธีต่อไปนี้ควบคุมพฤติกรรมดังกล่าว:

- เมธอด [setAdvanceOnClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ให้ผู้ชมเลื่อนหน้าด้วยการคลิกเมาส์
- เมธอด [setAdvanceAfter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เปิดใช้งานการเลื่อนหน้าอัตโนมัติ
- เมธอด [setAdvanceAfterTime](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) ระบุตัวหน่วงเวลาก่อนการเลื่อนหน้าอัตโนมัติ (หน่วยเป็นมิลลิวินาที)

เปิดใช้งานทั้งการคลิกและการเลื่อนหน้าตามเวลาเพื่อให้ผู้ชมสามารถกดคลิกเพื่อดำเนินการต่อหรือรอจนกว่าตัวจับเวลาจะทำงาน หากต้องการใช้เพียงตัวจับเวลา ให้ส่งค่า `false` ไปยังเมธอด [setAdvanceOnClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ตัวหน่วงเวลาจะควบคุมเวลาที่สไลด์โชว์เลื่อนหน้า ไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนสไลด์เอง

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่าง ๆ ให้กับสามสไลด์แรกและเปิดใช้งานการเลื่อนหน้าอัตโนมัติหลังจาก 3, 5 และ 7 วินาทีตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้ ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5
00);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

เพื่อดูว่าการเลื่อนหน้าตามเวลาถูกเปิดใช้งานหรือไม่ ให้เรียกเมธอด [getAdvanceAfter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) ค่าหน่วงเวลาที่เก็บไว้เพียงอย่างเดียวไม่ได้หมายความว่าตัวจับเวลาเปิดอยู่

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานตัวจับเวลาที่เปิดใช้งานแต่ละรายการ และปิดการเลื่อนหน้าอัตโนมัติสำหรับสไลด์ที่มีค่าหน่วงเวลามากกว่าสองวินาที พร้อมเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้น แล้วบันทึกการตั้งค่าใหม่

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ควบคุมระยะเวลาการเปลี่ยนอย่างแม่นยำ**

ใช้เมธอด [setDuration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setDuration) เพื่อระบุความยาวของเอฟเฟกต์การเปลี่ยนสไลด์เป็นมิลลิวินาที เมธอด [getSlideShowTransition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่านคลาส [SlideShowTransition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/) :

| เมธอด | วัตถุประสงค์ |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | ตั้งค่าระยะเวลาของเอฟเฟกต์การเปลี่ยนเอง (มิลลิวินาที) |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | ตั้งค่าหน่วงเวลาก่อนสไลด์เลื่อนหน้าอัตโนมัติ (มิลลิวินาที) ส่งค่า `true` ไปยังเมธอด [setAdvanceAfter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เพื่อเปิดใช้งานตัวจับเวลา |
| [setSpeed](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | เลือกหมวดความเร็วที่กำหนดไว้ล่วงหน้าใน enumeration [TransitionSpeed](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/transitionspeed/) : Slow, Medium หรือ Fast ใช้เมื่อไม่ได้ระบุระยะเวลาที่แน่นอน |

[setDuration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setDuration) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน ไม่ได้กำหนดระยะเวลาที่สไลด์คงอยู่บนหน้าจอ ตั้งค่าหน่วงเวลาการเลื่อนหน้าอัตโนมัติแยกต่างหาก เมื่อไม่มีการตั้งค่า duration ชัดเจน Aspose.Slides จะคำนวณระยะเวลาจากประเภทของการเปลี่ยนและค่าที่ได้จากเมธอด [getSpeed](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#getSpeed)

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสอดคล้อง ให้ใช้เอฟเฟกต์เดียวกันและระยะเวลาเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือกเอฟเฟกต์ Fade จาก enumeration [TransitionType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/transitiontype/) แล้วกำหนดระยะเวลา 750 มิลลิวินาทีให้กับการเปลี่ยนแต่ละสไลด์ พร้อมเปิดการเลื่อนหน้าอัตโนมัติหลัง 5,000 มิลลิวินาทีและปิดการเลื่อนด้วยการคลิกเมาส์ แล้วบันทึกเป็นไฟล์ PPTX

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // กำหนดการเลื่อนหน้าตามอัตโนมัติอย่างแยกจากระยะเวลาเอฟเฟกต์.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ตั้งค่าระยะเวลาต่าง ๆ สำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่แตกต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวเรื่องและการเปลี่ยนยาวสำหรับสไลด์แนะนำส่วน ตัวอย่างนี้ตั้งค่า 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1,200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **ประสานการเปลี่ยนกับการส่งออกแบบเคลื่อนไหว**

เมื่อเตรียม [animated GIF](/slides/th/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/nodejs-java/export-to-html5/), หรือ [video](/slides/th/nodejs-java/convert-powerpoint-to-video/), ให้ตั้งค่าระยะเวลาเปลี่ยนที่แน่นอนก่อนทำการส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจางแบบ Fade 600 มิลลิวินาทีระหว่างฉาก และปรับหน่วงเวลาการเลื่อนหน้าของแต่ละสไลด์แยกต่างหากเพื่อให้มีเวลาพูดบรรยายหรือแสดงเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 ให้เปิดใช้การเปลี่ยนแบบเคลื่อนไหวในการตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาที่สนับสนุนโดยรูปแบบการส่งออกที่เลือกแล้วทำการแสดงตัวอย่างเพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาเปลี่ยนที่มีอยู่**

เรียกเมธอด [getDuration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#getDuration) ก่อนทำการเปลี่ยน เพื่อดูว่ามีการเก็บค่าระยะเวลาที่แน่นอนหรือไม่ ค่า `-1` หมายถึงไม่ได้ตั้งระยะเวลาเฉพาะ; ค่าที่เป็นบวกหรือศูนย์หมายถึงระยะเวลาที่เก็บไว้เป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งไม่ใช่ระยะเวลาการเล่นที่คำนวณ: Aspose.Slides จะใช้ประเภทของการเปลี่ยนและค่าจากเมธอด [getSpeed](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) เพื่อกำหนดระยะเวลาดังกล่าว การตั้งค่าประเภทของการเปลี่ยนอาจทำให้มีการกำหนดค่า duration เริ่มต้นไว้ ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **การเปลี่ยน Morph**

การเปลี่ยน Morph ทำให้เกิดการเคลื่อนไหวของการเปลี่ยนแปลงระหว่างวัตถุบนสไลด์ต่อเนื่อง เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้คัดลอกสไลด์ ย้ายหรือปรับขนาดวัตถุในสไลด์ที่คัดลอก แล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง วิธีนี้จะทำให้วัตถุที่เกี่ยวข้องเคลื่อนไหวจากสภาพเดิมไปยังสภาพที่แก้ไขแล้ว

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ คัดลอกสไลด์นั้น แล้วเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสไลด์ที่คัดลอก จากนั้นเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกในตัวดูงานนำเสนอที่รองรับ Morph เพื่อดูเอฟเฟกต์ระหว่างการแสดงสไลด์

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ประเภทของ Morph Transition**

enumeration [TransitionMorphType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และเคลื่อนไหวเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) ถือรูปทรงแต่ละอย่างเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) เคลื่อนไหวข้อความโดยจับคู่คำเมื่อตรงกัน
- [ByChar](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) เคลื่อนไหวข้อความโดยจับคู่อักขระเมื่อตรงกัน

ใช้เมธอด [setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setType) เพื่อเลือก Morph ก่อนเข้าถึงเมธอด [getValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#getValue) ค่าที่ได้จะให้วัตถุ [MorphTransition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/morphtransition/) ซึ่งเมธอด [setMorphType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/morphtransition/#setMorphType) จะเลือกโหมดการจับคู่

ตัวอย่างนี้เปิดงานนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดให้สไลด์ที่สองใช้การเคลื่อนไหว Morph ที่อิงตามคำ

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าเอฟเฟกต์การเปลี่ยน**

บางเอฟเฟกต์การเปลี่ยนจะเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าเอฟเฟกต์จะเริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้จะขึ้นอยู่กับการเปลี่ยนที่เลือกด้วยเมธอด [setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setType) ให้ตั้งค่าประเภทก่อน แล้วใช้วัตถุการเปลี่ยนที่เหมาะสมจากเมธอด [getValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#getValue)

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` โดยเรียกเมธอด [setFromBlack](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) ผ่านคลาส [OptionalBlackTransition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/optionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ได้. ควรใช้เมธอด [setDuration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setDuration) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แน่นอนเป็นมิลลิวินาที ใช้เมธอด [setSpeed](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) เมื่อหมวดความเร็วที่กำหนดไว้ล่วงหน้าใน [TransitionSpeed](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/transitionspeed/) (Slow, Medium, Fast) เพียงพอและไม่ได้ตั้งค่า duration อย่างชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนแยกจากหน่วงเวลาการเลื่อนหน้าอัตโนมัติ

**ฉันสามารถแนบเสียงเข้ากับการเปลี่ยนและให้มันวนซ้ำได้หรือไม่?**

ได้. ใส่เสียงฝังด้วยเมธอด [setSound](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setSound) ส่งค่า `StartSound` จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/transitionsoundmode/) ไปยังเมธอด [setSoundMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) แล้วเปิดใช้งานเมธอด [setSoundLoop](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) ด้วยค่า `true` เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงต่อไปในสไลด์โชว์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

ทำลูปผ่านคอลเลกชัน [getSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSlides) ของงานนำเสนอและเรียกเมธอด [setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#setType) ด้วยค่าที่เหมือนกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าตัวเลือกเวลาและเอฟเฟกต์ใด ๆ ภายในลูปเดียวกันเพื่อรักษาพฤติกรรมให้สอดคล้องกันทั่วทั้งสไลด์

**ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งอยู่บนสไลด์ปัจจุบันได้อย่างไร?**

เรียกเมธอด [getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/#getType) บนผลลัพธ์ของเมธอด [getSlideShowTransition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์ จะได้ค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/transitiontype/) ค่า `None` หมายถึงไม่มีการตั้งค่าเอฟเฟกต์การเปลี่ยนใด ๆ)