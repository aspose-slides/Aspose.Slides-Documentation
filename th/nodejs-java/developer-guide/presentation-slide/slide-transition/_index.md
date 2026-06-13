---
title: จัดการการเปลี่ยนสไลด์ในงานพรีเซนเทชันด้วย JavaScript
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
description: "ปรับแต่งการเปลี่ยนสไลด์ใน JavaScript ด้วย Aspose.Slides for Node.js via Java พร้อมคำแนะนำแบบขั้นตอนสำหรับการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการการเปลี่ยนสไลด์ในงานพรีเซนเทชันด้วย Aspose.Slides แสดงวิธีใช้ประเภทการเปลี่ยนสไลด์บนสไลด์ ตั้งค่าพฤติกรรมการเปลี่ยนเช่น การเลื่อนต่อเมื่อคลิกหรือหลังจากเวลาที่กำหนด ตรวจสอบและปิดการเลื่อนอัตโนมัติ ใช้การเปลี่ยน Morph และประเภทต่าง ๆ ของมัน และตั้งค่าตัวเลือกของเอฟเฟกต์การเปลี่ยน ตัวอย่างจะแสดงวิธีโหลดหรือสร้างพรีเซนเทชัน แก้ไขการตั้งค่าการเปลี่ยนสำหรับสไลด์ที่เลือก และบันทึกผลลัพธ์เป็นไฟล์ PPTX บทความยังตอบคำถามทั่วไปเกี่ยวกับความเร็วของการเปลี่ยน เสียงการเปลี่ยน การใช้การเปลี่ยนเดียวกันกับหลายสไลด์ และการตรวจสอบการเปลี่ยนที่ตั้งไว้ในสไลด์ปัจจุบัน

## **เพิ่มการเปลี่ยนสไลด์**
เพื่อสร้างเอฟเฟกต์การเปลี่ยนสไลด์แบบง่าย ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของ[Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)คลาส
1. ใช้ประเภทการเปลี่ยนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for Node.js via Java ให้บริการ ผ่านค่า enum TransitionType
1. เขียนไฟล์พรีเซนเทชันที่แก้ไข

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์พรีเซนเทชันต้นฉบับ
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // ใช้การเปลี่ยนแบบวงกลมบนสไลด์ที่ 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // ใช้การเปลี่ยนแบบคอมบบนสไลด์ที่ 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // บันทึกพรีเซนเทชันลงดิสก์
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**
ในส่วนก่อนหน้า เราเพียงใช้เอฟเฟกต์การเปลี่ยนแบบง่ายบนสไลด์เท่านั้น ตอนนี้เพื่อทำให้เอฟเฟกต์การเปลี่ยนนั้นดียิ่งขึ้นและควบคุมได้ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของ[Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)คลาส
1. ใช้ประเภทการเปลี่ยนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for Node.js via Java ให้บริการ
1. คุณสามารถตั้งค่าการเปลี่ยนให้เลื่อนไปเมื่อคลิก หลังจากช่วงเวลาที่กำหนด หรือทั้งสองอย่างได้
1. หากการเปลี่ยนสไลด์เปิดใช้งานให้เลื่อนไปเมื่อคลิก การเปลี่ยนจะดำเนินการเมื่อผู้ใช้คลิกเมาส์เท่านั้น นอกจากนี้ หากตั้งค่า Advance After Time การเปลี่ยนจะเลื่อต่ออัตโนมัติหลังจากครบกำหนดเวลา
1. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์พรีเซนเทชัน

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // ใช้การเปลี่ยนแบบวงกลมบนสไลด์ที่ 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // ตั้งระยะเวลาการเปลี่ยนเป็น 3 วินาที
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // ใช้การเปลี่ยนแบบคอมบบนสไลด์ที่ 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // ตั้งระยะเวลาการเปลี่ยนเป็น 5 วินาที
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // ใช้การเปลี่ยนแบบซูมบนสไลด์ที่ 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // ตั้งระยะเวลาการเปลี่ยนเป็น 7 วินาที
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // บันทึกพรีเซนเทชันลงดิสก์
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **การเปลี่ยน Morph**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java ตอนนี้รองรับ[Morph Transition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MorphTransition) ซึ่งเป็นการเปลี่ยน Morph ใหม่ที่แนะนำใน PowerPoint 2019

{{% /alert %}} 

การเปลี่ยน Morph ช่วยให้คุณทำแอนิเมชันการเคลื่อนที่อย่างราบรื่นจากสไลด์หนึ่งไปยังสไลด์ต่อไป บทความนี้อธิบายแนวคิดและวิธีใช้การเปลี่ยน Morph เพื่อให้ใช้งานได้อย่างมีประสิทธิภาพ คุณจำเป็นต้องมีสไลด์สองสไลด์ที่มีวัตถุอย่างน้อยหนึ่งรายการร่วมกัน วิธีที่ง่ายที่สุดคือทำสำเนาสไลด์แล้วย้ายวัตถุบนสไลด์ที่สองไปยังตำแหน่งอื่น

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มคลอนของสไลด์พร้อมข้อความบางส่วนลงในพรีเซนเทชันและตั้งการเปลี่ยนเป็น[morph type](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TransitionType)บนสไลด์ที่สอง

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ประเภทการเปลี่ยน Morph**
ได้เพิ่ม enum[TransitionMorphType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TransitionMorphType)ใหม่ ซึ่งแทนประเภทต่าง ๆ ของการเปลี่ยนสไลด์ Morph

enum TransitionMorphType มีสมาชิกสามตัว:

- ByObject: การเปลี่ยน Morph จะดำเนินการโดยพิจารณารูปร่างเป็นวัตถุที่ไม่สามารถแยกย่อยได้
- ByWord: การเปลี่ยน Morph จะดำเนินการโดยถ่ายโอนข้อความตามคำเมื่อเป็นไปได้
- ByChar: การเปลี่ยน Morph จะดำเนินการโดยถ่ายโอนข้อความตามอักขระเมื่อเป็นไปได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าการเปลี่ยน Morph ให้สไลด์และเปลี่ยนประเภท Morph

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าเอฟเฟกต์การเปลี่ยน**
Aspose.Slides for Node.js via Java รองรับการตั้งค่าเอฟเฟกต์การเปลี่ยน เช่น จากสีดำ จากซ้าย จากขวา เป็นต้น เพื่อกำหนดเอฟเฟกต์การเปลี่ยน โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของ[Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)คลาส
- รับการอ้างอิงของสไลด์
- ตั้งค่าเอฟเฟกต์การเปลี่ยน
- เขียนพรีเซนเทชันเป็นไฟล์[PPTX](https://docs.fileformat.com/presentation/pptx/) 

ในตัวอย่างด้านล่าง เราได้ตั้งค่าเอฟเฟกต์การเปลี่ยนแล้ว

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // ตั้งค่าเอฟเฟกต์
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // เขียนพรีเซนเทชันลงดิสก์
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่ ตั้งค่าความเร็วของการเปลี่ยนโดยใช้[speed](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/setspeed/)ผ่านการตั้งค่า[TransitionSpeed](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/transitionspeed/) (เช่น slow/medium/fast)

**ฉันสามารถแนบเสียงกับการเปลี่ยนและทำให้วนรอบได้หรือไม่?**

ใช่ คุณสามารถฝังเสียงสำหรับการเปลี่ยนและควบคุมพฤติกรรมผ่านการตั้งค่าเช่นโหมดเสียงและการวนรอบ (เช่น[setSound](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/setsound/),[setSoundMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/),[setSoundLoop](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), พร้อมเมตาดาต้าเช่น[setSoundIsBuiltIn](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/)และ[setSoundName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/setsoundname/))

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

กำหนดประเภทการเปลี่ยนที่ต้องการในตั้งค่าการเปลี่ยนของแต่ละสไลด์; การเปลี่ยนจะถูกเก็บเป็นข้อมูลต่อสไลด์ ดังนั้นการใช้ประเภทเดียวกันกับสไลด์ทั้งหมดจะให้ผลลัพธ์ที่สอดคล้องกัน

**ฉันจะตรวจสอบว่าการเปลี่ยนใดตั้งอยู่บนสไลด์ในขณะนี้ได้อย่างไร?**

ตรวจสอบ[transition settings](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition)ของสไลด์และอ่าน[transition type](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideshowtransition/gettype/)ของมัน; ค่าดังกล่าวจะบอกว่ามีเอฟเฟกต์ใดถูกนำไปใช้อยู่ตอนนี้