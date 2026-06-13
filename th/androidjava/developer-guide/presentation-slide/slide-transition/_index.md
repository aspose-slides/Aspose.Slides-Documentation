---
title: จัดการการเปลี่ยนสไลด์ในงานนำเสนอบน Android
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 80
url: /th/androidjava/slide-transition/
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
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีปรับแต่งการเปลี่ยนสไลด์ใน Aspose.Slides สำหรับ Android ผ่าน Java ด้วยคำแนะนำทีละขั้นตอนสำหรับงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการการเปลี่ยนสไลด์ในงานนำเสนอด้วย Aspose.Slides โดยแสดงวิธีการใส่ประเภทการเปลี่ยนสไลด์ลงในสไลด์, กำหนดพฤติกรรมการเปลี่ยนเช่น การก้าวต่อไปเมื่อคลิกหรือหลังจากเวลาที่กำหนด, ตรวจสอบและปิดการก้าวต่ออัตโนมัติ, ใช้การเปลี่ยน Morph และประเภทต่าง ๆ ของมัน, และตั้งค่าตัวเลือกของเอฟเฟกต์การเปลี่ยน สาธิตตัวอย่างการโหลดหรือสร้างงานนำเสนอ, แก้ไขการตั้งค่าการเปลี่ยนสำหรับสไลด์ที่เลือก, และบันทึกผลลัพธ์เป็นไฟล์ PPTX บทความนี้ยังตอบคำถามที่พบบ่อยเกี่ยวกับความเร็วของการเปลี่ยน, เสียงในการเปลี่ยน, การใช้การเปลี่ยนเดียวกันกับหลายสไลด์, และการตรวจสอบการเปลี่ยนที่ตั้งค่าอยู่ในสไลด์ปัจจุบัน

## **เพิ่มการเปลี่ยนสไลด์**
เพื่อสร้างเอฟเฟกต์การเปลี่ยนสไลด์แบบง่าย ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของ[Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)คลาส
1. ใช้ประเภทการเปลี่ยนสไลด์บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for Android via Java มีให้ผ่าน enum TransitionType
1. เขียนไฟล์งานนำเสนอที่แก้ไขแล้ว

```java
// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอต้นฉบับ
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // ใช้การเปลี่ยนแบบวงกลมในสไลด์ที่ 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // ใช้การเปลี่ยนแบบคอมบในสไลด์ที่ 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // บันทึกงานนำเสนอลงดิสก์
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**
ในส่วนก่อนหน้าเราเพียงแค่ใส่เอฟเฟกต์การเปลี่ยนแบบง่ายลงในสไลด์ ตอนนี้เพื่อทำให้เอฟเฟกต์นั้นดียิ่งขึ้นและควบคุมได้ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของ[Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)คลาส
1. ใช้ประเภทการเปลี่ยนสไลด์บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for Android via Java มีให้
1. คุณสามารถตั้งค่าการเปลี่ยนให้ “Advance On Click”, “After a specific time period” หรือทั้งสองอย่างได้
1. ถ้าการเปลี่ยนสไลด์ถูกเปิดให้ “Advance On Click” การเปลี่ยนจะดำเนินต่อเมื่อผู้ใช้คลิกเมาส์เท่านั้น นอกจากนี้ หากตั้งค่าคุณสมบัติ “Advance After Time” การเปลี่ยนจะดำเนินอัตโนมัติหลังจากเวลาที่กำหนดผ่านไป
1. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์งานนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // ใช้การเปลี่ยนแบบวงกลมในสไลด์ที่ 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // ตั้งเวลาการเปลี่ยนเป็น 3 วินาที
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // ใช้การเปลี่ยนแบบคอมบในสไลด์ที่ 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // ตั้งเวลาการเปลี่ยนเป็น 5 วินาที
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // ใช้การเปลี่ยนแบบซูมในสไลด์ที่ 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // ตั้งเวลาการเปลี่ยนเป็น 7 วินาที
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **การเปลี่ยน Morph**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java ตอนนี้รองรับ[Morph Transition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IMorphTransition) ซึ่งเป็นการเปลี่ยน Morph ใหม่ที่แนะนำใน PowerPoint 2019

{{% /alert %}} 

การเปลี่ยน Morph ช่วยให้คุณทำแอนิเมชันการเคลื่อนที่แบบราบรื่นจากสไลด์หนึ่งไปยังสไลด์ต่อไป บทความนี้อธิบายแนวคิดและวิธีใช้การเปลี่ยน Morph ให้ได้ผลดีที่สุด คุณต้องมีสไลด์สองสไลด์ที่มีอย่างน้อยหนึ่งออบเจ็กต์ร่วมกัน วิธีที่ง่ายที่สุดคือทำสำเนาสไลด์แล้วย้ายออบเจ็กต์ในสไลด์ที่สองไปยังตำแหน่งใหม่

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มสำเนาของสไลด์พร้อมข้อความลงในงานนำเสนอและตั้งการเปลี่ยนเป็น[morph type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TransitionType)ให้กับสไลด์ที่สอง

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **ประเภทการเปลี่ยน Morph**
ได้เพิ่ม enumใหม่[TransitionMorphType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TransitionMorphType)ซึ่งแสดงประเภทต่าง ๆ ของการเปลี่ยนสไลด์ Morph

enum TransitionMorphType มีสามสมาชิก:

- ByObject: การเปลี่ยน Morph จะทำโดยพิจารณาแต่ละรูปร่างเป็นออบเจ็กต์ที่ไม่สามารถแยกย่อยได้
- ByWord: การเปลี่ยน Morph จะทำโดยย้ายข้อความตามคำเมื่อเป็นไปได้
- ByChar: การเปลี่ยน Morph จะทำโดยย้ายข้อความตามอักขระเมื่อเป็นไปได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งการเปลี่ยน Morph ให้สไลด์และเปลี่ยนประเภท Morph:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าเอฟเฟกต์การเปลี่ยน**
Aspose.Slides for Android via Java รองรับการตั้งค่าเอฟเฟกต์การเปลี่ยนเช่น จากสีดำ, จากซ้าย, จากขวา ฯลฯ เพื่อกำหนดเอฟเฟกต์การเปลี่ยน โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของ[Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)คลาส
- รับอ้างอิงของสไลด์
- ตั้งค่าเอฟเฟกต์การเปลี่ยน
- เขียนงานนำเสนอเป็นไฟล์[PPTX](https://docs.fileformat.com/presentation/pptx/) 

ในตัวอย่างด้านล่าง เราได้ตั้งค่าเอฟเฟกต์การเปลี่ยน

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // ตั้งค่าเอฟเฟกต์
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // บันทึกงานนำเสนอลงดิสก์
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมความเร็วในการเล่นการเปลี่ยนสไลด์ได้หรือไม่?**

ได้ครับ ตั้งค่า[ความเร็ว](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-)ของการเปลี่ยนโดยใช้การตั้งค่า[TransitionSpeed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitionspeed/) (เช่น ช้า/ปานกลาง/เร็ว)

**ฉันสามารถใส่เสียงเข้ากับการเปลี่ยนและทำให้มันวนซ้ำได้หรือไม่?**

ได้ คุณสามารถฝังเสียงสำหรับการเปลี่ยนและควบคุมพฤติกรรมผ่านการตั้งค่าเช่นโหมดเสียงและการวนซ้ำ (เช่น [setSound](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), รวมถึงเมตาดาต้าเช่น [setSoundIsBuiltIn](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-)และ[setSoundName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-))

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

กำหนดประเภทการเปลี่ยนที่ต้องการในการตั้งค่าการเปลี่ยนของแต่ละสไลด์; การเปลี่ยนจะถูกเก็บไว้ต่อสไลด์ ดังนั้นการใช้ประเภทเดียวกันกับทุกสไลด์จะให้ผลลัพธ์สอดคล้องกัน

**ฉันจะตรวจสอบได้อย่างไรว่าการเปลี่ยนใดถูกตั้งค่าอยู่ในสไลด์ปัจจุบัน?**

ตรวจสอบ[การตั้งค่าการเปลี่ยนของสไลด์](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--)และอ่าน[ประเภทการเปลี่ยน](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setType-int-)ของมัน ค่าดังกล่าวจะแสดงให้คุณทราบว่ามีเอฟเฟกต์ใดถูกนำไปใช้อยู่ตอนนี้