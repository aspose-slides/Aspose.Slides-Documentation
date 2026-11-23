---
title: "จัดการการเปลี่ยนสไลด์ในงานนำเสนอด้วย JavaScript"
linktitle: "การเปลี่ยนสไลด์"
type: docs
weight: 80
url: /th/nodejs-java/slide-transition/
keywords:
- "การเปลี่ยนสไลด์"
- "เพิ่มการเปลี่ยนสไลด์"
- "ใช้การเปลียนสไลด์"
- "การเปลี่ยนสไลด์ขั้นสูง"
- "การเปลี่ยนแบบ Morph"
- "ประเภทการเปลี่ยน"
- "เอฟเฟกต์การเปลี่ยน"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "ใช้การเปลี่ยนสไลด์, กำหนดการเลื่อนสไลด์อัตโนมัติ, และปรับแต่ง Morph พร้อมเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมว่าหน้าสไลด์ปรากฏอย่างไรในระหว่างการแสดงสไลด์ โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ กำหนดการเลื่อนต่อด้วยคลิกเมาส์หรือการจับเวลา และปรับตัวเลือกเฉพาะของเอฟเฟกต์ บทความนี้ใช้ตัวอย่าง JavaScript เพื่อใช้การเปลี่ยนสไลด์ ตั้งค่าระยะเวลาเปลี่ยนที่แม่นยำ จัดการเวลาแสดงสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีการบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยน ให้โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) และเข้าถึงการตั้งค่าการเปลี่ยนของสไลด์ผ่าน [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) ใช้ [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) พร้อมค่าจากการนับจำนวน [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) แล้วบันทึกงานนำเสนอ

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

## **การเปลี่ยนแบบล้อ**

เมธอด [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) ของ [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) ควบคุมจำนวนเซกเตอร์รัศมีที่เปิดเผยสไลด์ปลายทาง ตั้งค่าประเภทการเปลี่ยนของสไลด์เป็น Wheel จาก [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) ด้วย [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) เป็น [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/)

ตัวอย่างนี้สร้างคู่สไลด์ที่เหมือนกันสองคู่: สไลด์สีดำตามด้วยสไลด์ที่มีสี่เหลี่ยมสีทอง สไลด์ปลายทางใช้จำนวน spoke เป็น 1 และ 8 โดยกำหนดความเร็วเดียวกันด้วย [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) และกำหนดระยะเวลาอย่างชัดเจนเป็น 8,000 มิลลิวินาทีด้วย [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) เพื่อให้สังเกตความแตกต่างได้ง่าย

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

เปิดงานนำเสนอผลลัพธ์ใน PowerPoint และรันการแสดงสไลด์ เลื่อนจากสไลด์ 1 ไปสไลด์ 2 แล้วจากสไลด์ 3 ไปสไลด์ 4 ในการเล่น PowerPoint จำนวน spoke ที่ตรวจสอบได้เป็น 1 จะเปิดเผยสไลด์ด้วยการกวาดหนึ่งรอบตามเข็มนาฬิกา; จำนวน 8 จะเปิดเผยด้วยเอ็กเซกเตอร์รัศมีแปดส่วนพร้อมกัน เนื้อหาและเวลาการเปลี่ยนของสไลด์ปลายทางเป็นแบบเดียวกัน ดังนั้นความแตกต่างคือจำนวนเซกเตอร์ที่เปิดเผย

## **Fade Through Black with the Reveal Transition**

ตั้งค่าประเภทการเปลี่ยนของสไลด์ปลายทางเป็น Reveal แล้วเรียก [setThroughBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/#setThroughBlack) บนการตั้งค่า [RevealTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/) ตัวอย่างนี้สร้างสไลด์ต้นทางสีฟ้าเทาและสไลด์ปลายทางสีโค้รัล แล้วทำการโคลนทั้งสอง คู่แต่ละคู่ใช้การเปลี่ยน Reveal ระยะเวลา 2 วินาที เพียงคู่ที่สองเท่านั้นที่ทำ Fade ผ่านสีดำ

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const source = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addClone(source);
    const teal = java.newInstanceSync("java.awt.Color", 0, 128, 128);
    const coral = java.newInstanceSync("java.awt.Color", 255, 127, 80);

    for (const [slide, color, label] of [[source, teal, "Source"], [destination, coral, "Destination"]]) {
        slide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
        const fill = slide.getBackground().getFillFormat();
        fill.setFillType(java.newByte(slides.FillType.Solid));
        fill.getSolidFillColor().setColor(color);

        const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 160, 180, 400, 130);
        const textFrame = shape.getTextFrame();
        textFrame.setText(label);
        textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    const clonedDestination = presentation.getSlides().addClone(destination);
    for (const slide of [destination, clonedDestination]) {
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Reveal);
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(2000);

        const reveal = transition.getValue();
        reveal.setDirection(slides.TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide === clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เปิดงานนำเสนอที่บันทึกไว้ใน PowerPoint และเริ่มการแสดงสไลด์ เลื่อนจากสไลด์ 1 ไปสไลด์ 2 เพื่อดูสีฟ้าเทาเฟดตรงไปยังสีโค้รัล แล้วเลื่อนจากสไลด์ 3 ไปสไลด์ 4 หน้าจอจะมืดลงสั้น ๆ ใกล้สีดำก่อนที่สไลด์โค้รัลจะแสดง ทั้งสองสไลด์คงสีพื้นหลังเดิม

แถวด้านล่างแสดงเฟรมจาก PowerPoint ทุกครึ่งวินาที เปรียบเทียบเฟรมกลางของแต่ละแถวเพื่อดูเอฟเฟกต์

![การเล่น PowerPoint ที่ปิดการ Fade ผ่านสีดำ (บน) และเปิดการ Fade ผ่านสีดำ (ล่าง) เฉพาะแถวล่างเท่านั้นที่ผ่านสีดำใกล้เคียง](reveal-through-black.png)

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดช่วงเวลาที่สไลด์ค้างบนหน้าจอและว่าการคลิกเมาส์จะเลื่อนการแสดงสไลด์หรือไม่ วิธีต่อไปนี้ควบคุมพฤติกรรมดังกล่าว:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ให้ผู้ชมเลื่อนด้วยการคลิกเมาส์
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เปิดใช้งานการเลื่อนอัตโนมัติ
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) กำหนดความล่าช้าก่อนการเลื่อนอัตโนมัติ (มิลลิวินาที)

เปิดใช้งานทั้งการคลิกและการเลื่อนตามเวลาเพื่อให้ผู้ชมสามารถเลื่อนได้ด้วยคลิกหรือรอเวลา หากต้องการใช้เฉพาะตัวจับเวลา ให้ส่ง `false` ไปยัง [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ความล่าช้ากำหนดเวลาที่สไลด์โชว์จะเลื่อน ไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนที่มองเห็น

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่าง ๆ ให้กับสามสไลด์แรกและเปิดการเลื่อนอัตโนมัติหลังจาก 3, 5, และ 7 วินาที ตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้เช่นกัน ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อตรวจสอบว่าตัวจับเวลาเปิดใช้งานหรือไม่ ให้เรียก [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) ค่าที่เก็บไว้เพียงอย่างเดียวยังไม่บ่งบอกว่าตัวจับเวลากำลังทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานแต่ละตัวจับเวลาที่เปิดใช้งานและปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีความล่าชุมากกว่าสองวินาที เปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าใหม่

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

ใช้ [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) เพื่อกำหนดระยะเวลาที่แม่นยำของเอฟเฟกต์การเปลี่ยน (มิลลิวินาที) เมธอด [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/):

| วิธีการ | วัตถุประสงค์ |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนเอง (มิลลิวินาที) |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | กำหนดความล่าช้าก่อนสไลด์เลื่อนอัตโนมัติ (มิลลิวินาที) ส่ง `true` ไปยัง [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เพื่อเปิดใช้งานตัวจับเวลา |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | เลือกหมวดความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) ได้แก่ Slow, Medium หรือ Fast ใช้เมื่อไม่ได้ระบุระยะเวลาอย่างชัดเจน |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน ไม่กำหนดว่าสไลด์จะคงแสดงนานเท่าใด ตั้งค่าความล่าช้าการเลื่อนอัตโนมัติแยกต่างหาก เมื่อไม่มีการกำหนดระยะเวลาอย่างชัดเจน Aspose.Slides จะคำนวณระยะเวลาจากประเภทการเปลี่ยนและค่าที่ได้จาก [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed)

<!-- visual-explanation:slide-transition:start -->
[![แถบแยกแสดงระยะเวลาเปลี่ยน 750 ms และการเลื่อนอัตโนมัติ 5,000 ms](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*ตัวอย่างที่แชร์ให้สไลด์แต่ละอันมีการเปลี่ยน Fade 750 ms และเปิดการเลื่อนอัตโนมัติที่ 5,000 ms อย่างแยกจากกัน ระยะเวลาเปลี่ยนควบคุมเอฟเฟกต์ ส่วนการเลื่อนควบคุมเวลาที่ออกจากสไลด์ แถบเหล่านี้เป็นการตั้งค่าเชิงสคีม่า ไม่ใช่ไทม์ไลน์ที่วัดได้จริง*
<!-- visual-explanation:slide-transition:end -->

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสอดคล้อง ใช้เอฟเฟกต์และระยะเวลาเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) และกำหนดระยะเวลาการเปลี่ยนที่ 750 ms ให้ทุกสไลด์ พร้อมเปิดการเลื่อนอัตโนมัติหลัง 5,000 ms และปิดการเลื่อนด้วยคลิกเมาส์ แล้วบันทึกเป็น PPTX

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // กำหนดการเลื่อนอัตโนมัติอย่างอิสระจากระยะเวลาเอฟเฟกต์
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **กำหนดระยะเวลาที่ต่างกันสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่ต่างกันได้ เช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวเรื่องและใช้การเปลี่ยนยาวสำหรับการแนะนำส่วน ตัวอย่างนี้ตั้งค่า 500 ms สำหรับสไลด์แรกและ 1,200 ms สำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

### **ประสานการเปลี่ยนกับผลลัพธ์แบบแอนิเมชัน**

เมื่อเตรียม [animated GIF](/slides/th/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/nodejs-java/export-to-html5/) หรือ [video](/slides/th/nodejs-java/convert-powerpoint-to-video/), ตั้งค่าระยะเวลาเปลี่ยนที่แม่นยำก่อนส่งออกเพื่อให้จังหวะตรงตามที่ต้องการ เช่น ใช้การเฟด 600 ms ระหว่างฉาก และปรับความล่าช้าการเลื่อนของแต่ละสไลด์แยกต่างหากเพื่อให้มีเวลาสำหรับการบรรยายหรือเนื้อหา

สำหรับ GIF และวีดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 ms เท่ากับ 18 เฟรมที่ 30 FPS ใน HTML5 ให้เปิดการเปลี่ยนแบบแอนิเมชันในตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาที่รองรับของรูปแบบการส่งออกที่เลือก แล้วดูตัวอย่างผลลัพธ์เพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาเปลี่ยนที่มีอยู่**

เรียก [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) ก่อนแก้ไขการเปลี่ยนเพื่อดูว่ามีค่าระยะเวลาอย่างชัดเจนหรือไม่ ค่า `-1` หมายถึงไม่มีการกำหนดระยะเวลาอย่างชัดเจน ค่าไม่ลบจะระบุระยะเวลาที่เก็บไว้ (มิลลิวินาที) ค่าที่ไม่ได้ตั้งไม่ได้หมายถึงระยะเวลาการเล่นที่คำนวณได้: Aspose.Slides ใช้ประเภทการเปลี่ยนและค่าที่ได้จาก [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) เพื่อตัดสินระยะเวลา การตั้งค่าประเภทการเปลี่ยนอาจทำให้ระยะเวลาเริ่มต้นได้ ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

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

## **Morph Transition**

Morph ทำให้การเปลี่ยนแปลงระหว่างออบเจกต์บนสไลด์ต่อเนื่องเป็นแอนิเมชัน เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้โคลนสไลด์ ย้ายหรือปรับขนาดออบเจกต์บนสไลด์โคลน แล้วกำหนดการเปลี่ยน Morph ให้กับสไลด์ที่สอง จะทำให้วัตถุที่สัมพันธ์กันทำการแอนิเมชันระหว่างสถานะเดิมและแก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ โคลนสไลด์นั้นและเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนโคลน แล้วเลือก Morph จากการนับจำนวน [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกในโปรแกรมดูงานนำเสนอที่รองรับ Morph เพื่อดูเอฟเฟกต์ระหว่างการแสดงสไลด์

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

## **Morph Transition Types**

การนับจำนวน [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) กำหนดวิธีที่ Morph จับคู่อและทำแอนิเมชันเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) ถือแต่ละรูปร่างเป็นออบเจกต์ทั้งชุด
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) แอนิเมชันข้อความโดยจับคู่คำเมื่อทำได้
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) แอนิเมชันข้อความโดยจับคู่อักขระเมื่อทำได้

ใช้ [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) เพื่อเลือก Morph ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) ค่าเหล่านั้นจะให้วัตถุ [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/) ซึ่งเมธอด [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) จะเลือกโหมดการจับคู่

ตัวอย่างนี้เปิดงานนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดให้สไลด์ที่สองใช้การแอนิเมชัน Morph ตามคำ

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

บางการเปลี่ยนจะเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าเอฟเฟกต์เริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้ขึ้นกับการเปลี่ยนที่เลือกด้วย [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) ตั้งค่าประเภทก่อน แล้วใช้วัตถุการเปลี่ยนที่เหมาะสมจาก [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue)

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` เรียก [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) ผ่าน [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

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

ได้. ควรใช้ [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แม่นยำเป็นมิลลิวินาที ใช้ [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) เมื่อหมวดความเร็วที่กำหนดไว้ล่วงหน้าใน [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) (Slow, Medium, Fast) เพียงพอและไม่มีการกำหนดระยะเวลาอย่างชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนโดยอิสระจากความล่าช้าการเลื่อนอัตโนมัติ

**ฉันสามารถแนบเสียงเข้ากับการเปลี่ยนและตั้งให้วนซ้ำได้หรือไม่?**

ได้. กำหนดเสียงฝังด้วย [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound) ส่งค่า StartSound จากการนับจำนวน [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) ไปยัง [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) และเปิด [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) ด้วย `true` เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงถัดไปในสไลด์โชว์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเล็กชัน [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) ของงานนำเสนอและเรียก [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) ด้วยค่าตรงกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าตัวเลือกเวลาและเอฟเฟกต์ในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันทั่วทั้งสไลด์

**ฉันจะตรวจสอบได้อย่างไรว่าการเปลี่ยนใดถูกตั้งค่าอยู่บนสไลด์ปัจจุบัน?**

เรียก [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) บนผลลัพธ์ของสไลด์ [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) จะคืนค่าจากการนับจำนวน [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/); None หมายถึงไม่มีการตั้งค่าเอฟเฟกต์การเปลี่ยน.