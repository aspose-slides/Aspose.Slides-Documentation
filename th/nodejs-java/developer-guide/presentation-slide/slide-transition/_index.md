---
title: จัดการการเปลี่ยนสไลด์ในการนำเสนอด้วย JavaScript
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 80
url: /th/nodejs-java/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- ใช้การเปลี่ยนสไลด์
- การเปลี่ยนสไลด์ขั้นสูง
- การเปลี่ยน Morph
- ประเภทการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์, กำหนดค่าการก้าวหน้าสไลด์อัตโนมัติ, และปรับแต่ง Morph พร้อมเอฟเฟกต์การเปลี่ยนอื่นๆด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมลักษณะการปรากฏของสไลด์ระหว่างการนำเสนอด้วยสไลด์โชว์ ด้วย Aspose.Slides for Node.js via Java คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ กำหนดการเลื่อนไปด้วยการคลิกเมาส์หรือไทม์เมอร์ และปรับตัวเลือกที่เฉพาะสำหรับเอฟเฟกต์นั้นได้ บทความนี้ใช้ตัวอย่าง JavaScript เพื่อใช้การเปลี่ยน ตั้งค่าความยาวของการเปลี่ยนอย่างแม่นยำ จัดการการตั้งเวลาสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างเหล่านี้ยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX อีกด้วย

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยน ให้โหลดการนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) และเข้าถึงการตั้งค่าการเปลี่ยนของสไลด์ผ่าน [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) ใช้ [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) พร้อมค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) จากนั้นบันทึกการนำเสนอ

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Circle กับสไลด์แรกและการเปลี่ยน Comb กับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

## **การเปลี่ยน Wheel**

เมธอด [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) ของ [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) ควบคุมจำนวนส่วนรัศมีที่เผยสไลด์ปลายทาง ตั้งค่าประเภทการเปลี่ยนของสไลด์เป็น Wheel จาก [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) ด้วย [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) เป็น [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/)

ตัวอย่างนี้สร้างคู่สไลด์ที่เหมือนกันสองชุด: สไลด์สีดำตามด้วยสไลด์ที่มีสี่เหลี่ยมทอง สไลด์ปลายทางใช้จำนวน spoke เป็น 1 และ 8 โดยกำหนดความเร็วเดียวกันผ่าน [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) และระบุระยะเวลา 8,000 มิลลิวินาทีผ่าน [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) เพื่อให้เห็นความแตกต่างง่ายขึ้น

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เปิดการนำเสนอผลลัพธ์ใน PowerPoint และเริ่มสไลด์โชว์ เลื่อนจากสไลด์ 1 ไปสไลด์ 2 แล้วจากสไลด์ 3 ไปสไลด์ 4 ในการเล่น PowerPoint จำนวน spoke ที่กำหนดเป็น 1 จะเผยสไลด์ด้วยการสวิงตามเข็มนาฬิกาเดียว; จำนวน 8 จะเผยสไลด์ผ่านแปดส่วนรัศมีพร้อมกัน เนื้อหาและการตั้งค่าเวลาในการเปลี่ยนของสไลด์ปลายทางเหมือนกัน ดังนั้นความแตกต่างคือจำนวนส่วนที่เผย

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์คงอยู่บนหน้าจอและว่าจะให้การคลิกเมาส์ทำให้สไลด์โชว์ก้าวต่อหรือไม่ เมธอดต่อไปนี้ควบคุมพฤติกรรมดังกล่าว:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) อนุญาตให้ผู้ชมก้าวหน้าด้วยการคลิกเมาส์
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เปิดใช้งานการก้าวหน้าอัตโนมัติ
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) ระบุเวลาหน่วงก่อนการก้าวหน้าอัตโนมัติเป็นมิลลิวินาที

เปิดใช้งานทั้งการคลิกและการก้าวหน้าตามเวลาเพื่อให้ผู้ชมสามารถก้าวต่อด้วยการคลิกหรือรอไทม์เมอร์ หากต้องการใช้เฉพาะไทม์เมอร์ ให้ส่งค่า `false` ไปยัง [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) การหน่วงเวลาควบคุมเมื่อสไลด์โชว์ก้าวหน้า ไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนที่มองเห็นได้

ตัวอย่างนี้กำหนดเอฟเฟกต์ที่แตกต่างให้กับสามสไลด์แรกและเปิดใช้งานการก้าวหน้าอัตโนมัติหลังจาก 3, 5 และ 7 วินาทีตามลำดับ การคลิกเมาส์ก็สามารถก้าวสไลด์เหล่านี้ได้ ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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
        secondTransition.setAdvanceAfterTime(5000);

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

เพื่อตรวจสอบว่าการก้าวหน้าตามเวลาถูกเปิดหรือไม่ ให้เรียก [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) ค่าหน่วงที่เก็บไว้เพียงอย่างเดียวไม่ได้หมายความว่าไทม์เมอร์กำลังทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ด้านบน รายงานแต่ละไทม์เมอร์ที่เปิดใช้งาน และปิดการก้าวหน้าอัตโนมัติสำหรับสไลด์ที่มีค่าหน่วงมากกว่าสองวินาที พร้อมเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าใหม่

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

## **ควบคุมเวลาการเปลี่ยนอย่างแม่นยำ**

ใช้ [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) เพื่อระบุความยาวของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที วิธี [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/) :

| วิธีการ | วัตถุประสงค์ |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนเองเป็นมิลลิวินาที |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | ตั้งค่าหน่วงเวลา ก่อนสไลด์จะก้าวหน้าอัตโนมัติเป็นมิลลิวินาที ส่งค่า `true` ไปยัง [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เพื่อเปิดใช้งานไทม์เมอร์นี้ |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | เลือกหมวดความเร็วที่กำหนดไว้ล่วงหน้า จาก [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) : Slow, Medium หรือ Fast ใช้เมื่อไม่ได้ระบุระยะเวลาที่ชัดเจน |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน ไม่ได้กำหนดว่าซูมสไลด์คงอยู่บนหน้าจอนานเท่าใด ตั้งค่าหน่วงเวลาการก้าวหน้าอัตโนมัติแยกต่างหาก เมื่อไม่มีการกำหนดระยะเวลาที่ชัดเจน Aspose.Slides จะคำนวณระยะเวลาของเอฟเฟกต์จากประเภทการเปลี่ยนและค่าที่ได้จาก [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed)

<!-- visual-explanation:slide-transition:start -->
[![แถบแยกแยะระยะเวลา 750 ms ของการเปลี่ยนและการตั้งค่า 5,000 ms ของการก้าวหน้าอัตโนมัติ](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*ตัวอย่างที่แชร์ให้แต่ละสไลด์มีการเปลี่ยน Fade 750 ms และเปิดการก้าวหน้าอัตโนมัติที่ 5,000 ms แยกกัน ระยะเวลาการเปลี่ยนควบคุมเอฟเฟกต์; การก้าวหน้า ควบคุมเวลาที่ออกจากสไลด์ แถบเหล่านี้เป็นการตั้งค่าเชิงแนวคิด ไม่ใช่ไทม์ไลน์ที่วัดได้จริง*
<!-- visual-explanation:slide-transition:end -->

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสอดคล้องกัน ให้ใช้เอฟเฟกต์และระยะเวลาเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) และกำหนดระยะเวลาการเปลี่ยนเป็น 750 มิลลิวินาทีสำหรับแต่ละสไลด์ พร้อมเปิดการก้าวหน้าอัตโนมัติหลัง 5,000 มิลลิวินาทีและปิดการก้าวหน้าผ่านคลิกเมาส์ แล้วบันทึกผลเป็น PPTX

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // ตั้งค่าการก้าวหน้าอัตโนมัติแยกจากระยะเวลาเอฟเฟกต์
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **กำหนดระยะเวลาที่แตกต่างให้กับสไลด์แต่ละอัน**

สไลด์ต่างๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่ต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวข้อและการเปลี่ยนยาวสำหรับการแนะนำส่วน ตัวอย่างนี้ตั้ง 500 ms ให้สไลด์แรกและ 1,200 ms ให้สไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

เมื่อเตรียม [animated GIF](/slides/th/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/nodejs-java/export-to-html5/) หรือ [video](/slides/th/nodejs-java/convert-powerpoint-to-video/), ให้ตั้งระยะเวลาการเปลี่ยนที่แน่นอนก่อนส่งออกเพื่อให้สอดคล้องกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจาง 600 ms ระหว่างฉาก และปรับหน่วงเวลาการก้าวหน้าแต่ละสไลด์แยกต่างหากเพื่อให้มีเวลาสำหรับการบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 ms เท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 ให้เปิดการเปลี่ยนแบบเคลื่อนไหวในการตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาที่สนับสนุนโดยรูปแบบการส่งออกที่เลือกและดูตัวอย่างผลลัพธ์เพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาการเปลี่ยนที่มีอยู่**

เรียก [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) ก่อนแก้ไขการเปลี่ยน เพื่อดูว่ามีการเก็บค่าที่ระบุไว้หรือไม่ ค่า `-1` หมายถึงไม่มีการตั้งค่าระยะเวลาที่ชัดเจน; ค่าที่ไม่เป็นลบระบุระยะเวลาที่เก็บไว้เป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งนี้ไม่ใช่ระยะเวลาการเล่นที่คำนวณได้: Aspose.Slides ใช้ประเภทการเปลี่ยนและค่าที่ได้จาก [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) เพื่อกำหนดระยะเวลาดังกล่าว การตั้งค่าประเภทการเปลี่ยนอาจทำให้กำหนดค่าเริ่มต้นได้ ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

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

การเปลี่ยน Morph ทำให้วัตถุบนสไลด์ต่อเนื่องเคลื่อนที่ระหว่างสไลด์ที่ต่อเนื่องกัน เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้คัดลอกสไลด์ ย้ายหรือปรับขนาดวัตถุบนสำเนา แล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง วิธีนี้ทำให้วัตถุที่ตรงกันทำการเคลื่อนไหวจากสถานะเดิมไปยังสถานะที่แก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ คัดลอกสไลด์และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกในโปรแกรมดูงานนำเสนอที่รองรับ Morph เพื่อดูเอฟเฟกต์ในขณะสไลด์โชว์

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

## **ประเภทการเปลี่ยน Morph**

enumeration [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และเคลื่อนไหวเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) พิจารณาแต่ละรูปทรงเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) เคลื่อนไหวข้อความโดยจับคู่คำเมื่อทำได้
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) เคลื่อนไหวข้อความโดยจับคู่ตัวอักษรเมื่อทำได้

ใช้ [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) เพื่อเลือก Morph ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) ค่าที่ได้จะให้วัตถุ [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/) ซึ่งเมธอด [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) จะเลือกโหมดการจับคู่

ตัวอย่างนี้เปิดการนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดให้สไลด์ที่สองใช้การเคลื่อนไหว Morph ตามคำ

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

บางการเปลี่ยนให้ตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าการเปลี่ยนเริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้ขึ้นกับการเปลี่ยนที่เลือกด้วย [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) ตั้งค่าประเภทก่อน แล้วใช้วัตถุการเปลี่ยนที่เหมาะสมจาก [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue)

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` โดยเรียก [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) ผ่าน [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

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

## **FAQ**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ได้. ควรใช้ [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) เมื่อคุณต้องการระยะเวลาที่แน่นอนเป็นมิลลิวินาที ใช้ [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) เมื่อหมวดความเร็วที่กำหนดไว้ล่วงหน้าใน [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) — Slow, Medium หรือ Fast — เพียงพอและไม่มีการตั้งระยะเวลาชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนโดยอิสระจากหน้าหน่วงการก้าวหน้าอัตโนมัติ

**ฉันสามารถแนบเสียงเข้ากับการเปลี่ยนและทำให้มันวนซ้ำได้หรือไม่?**

ได้. กำหนดเสียงฝังด้วย [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound) ส่งค่า StartSound จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) ไปยัง [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) และเปิด [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) ด้วย `true` เสียงจะวนซ้ำจนกระทั่งเหตุการณ์เสียงถัดไปในสไลด์โชว์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) ของการนำเสนอและเรียก [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) พร้อมค่าที่เหมือนกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าการเวลาและตัวเลือกเอฟเฟกต์ในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันทั่วทุกสไลด์

**ฉันจะตรวจสอบว่าการเปลี่ยนใดกำหนดไว้บนสไลด์ปัจจุบันได้อย่างไร?**

เรียก [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) บนผลลัพธ์ของ [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์ จะคืนค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) ; None หมายถึงไม่มีการกำหนดเอฟเฟกต์การเปลี่ยนใดๆ.