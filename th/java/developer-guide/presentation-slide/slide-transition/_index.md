---
title: จัดการการเปลี่ยนสไลด์ในการนำเสนอด้วย Java
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 80
url: /th/java/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- ใช้การเปลี่ยนสไลด์
- การเปลี่ยนสไลด์ขั้นสูง
- การเปลี่ยนแบบ Morph
- ประเภทการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีปรับแต่งการเปลี่ยนสไลด์ใน Aspose.Slides for Java พร้อมคำแนะนำทีละขั้นตอนสำหรับการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการการเปลี่ยนสไลด์ในการนำเสนอด้วย Aspose.Slides โดยแสดงวิธีใช้ประเภทการเปลี่ยนสไลด์บนสไลด์ กำหนดพฤติกรรมการเปลี่ยนเช่น เลื่อนไปเมื่อคลิกหรือหลังจากเวลาที่กำหนด ตรวจสอบและปิดการเลื่อนอัตโนมัติ ใช้การเปลี่ยนแบบ Morph และประเภทของมัน พร้อมตั้งค่าตัวเลือกเอฟเฟกต์การเปลี่ยน ตัวอย่างแสดงวิธีโหลดหรือสร้างการนำเสนอ แก้ไขการตั้งค่าการเปลี่ยนสำหรับสไลด์ที่เลือก และบันทึกผลเป็นไฟล์ PPTX บทความยังตอบคำถามทั่วไปเกี่ยวกับความเร็วของการเปลี่ยน เสียงของการเปลี่ยน การใช้การเปลี่ยนเดียวกันกับหลายสไลด์ และการตรวจสอบการเปลี่ยนที่ตั้งอยู่บนสไลด์ปัจจุบัน

## **เพิ่มการเปลี่ยนสไลด์**
เพื่อสร้างเอฟเฟกต์การเปลี่ยนสไลด์อย่างง่าย ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) class.
1. ใช้ Slide Transition Type บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for Java มีให้ผ่าน enum TransitionType
1. เขียนไฟล์การนำเสนอที่แก้ไขแล้ว

```java
// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอต้นฉบับ
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // ใช้การเปลี่ยนแบบวงกลมบนสไลด์ที่ 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // ใช้การเปลี่ยนแบบคอมบบนสไลด์ที่ 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // เขียนการนำเสนอลงดิสก์
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**
ในส่วนก่อนหน้า เราได้ใช้เอฟเฟกต์การเปลี่ยนอย่างง่ายบนสไลด์เท่านั้น ตอนนี้เพื่อทำให้เอฟเฟกต์นั้นดีขึ้นและควบคุมได้มากขึ้น โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) class.
1. ใช้ Slide Transition Type บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for Java มีให้
1. คุณสามารถตั้งให้การเปลี่ยน Advance On Click, หลังจากระยะเวลาที่กำหนด หรือทั้งสองอย่างได้
1. หากการเปลี่ยนสไลด์เปิดให้ Advance On Click, การเปลี่ยนจะเกิดขึ้นเมื่อมีการคลิกเมาส์เท่านั้น อีกทั้งหากตั้งค่า Advance After Time, การเปลี่ยนจะดำเนินอัตโนมัติหลังจากเวลาที่กำหนดผ่านไป
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์การนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // ใช้การเปลี่ยนแบบวงกลมบนสไลด์ที่ 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // ตั้งเวลาการเปลี่ยนเป็น 3 วินาที
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // ใช้การเปลี่ยนแบบคอมบบนสไลด์ที่ 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // ตั้งเวลาการเปลี่ยนเป็น 5 วินาที
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // ใช้การเปลี่ยนแบบซูมบนสไลด์ที่ 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // ตั้งเวลาการเปลี่ยนเป็น 7 วินาที
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // เขียนการนำเสนอลงดิสก์
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **การเปลี่ยนแบบ Morph**
{{% alert color="primary" %}} 

Aspose.Slides for Java ตอนนี้รองรับ [Morph Transition](https://reference.aspose.com/slides/th/java/com.aspose.slides/IMorphTransition) ซึ่งเป็นการเปลี่ยน Morph ใหม่ที่แนะนำใน PowerPoint 2019

{{% /alert %}} 

การเปลี่ยนแบบ Morph อนุญาตให้คุณทำแอนิเมชันการเคลื่อนที่อย่างราบรื่นจากสไลด์หนึ่งไปยังสไลด์ถัดไป บทความนี้อธิบายแนวคิดและวิธีใช้ Morph อย่างมีประสิทธิภาพ คุณจะต้องมีสองสไลด์ที่มีอย่างน้อยหนึ่งอ็อบเจกต์ร่วมกัน วิธีที่ง่ายที่สุดคือทำสำเนาสไลด์แล้วย้ายอ็อบเจกต์บนสไลด์ที่สองไปยังตำแหน่งอื่น

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มสำเนาของสไลด์ที่มีข้อความลงในการนำเสนอและตั้งค่าการเปลี่ยนเป็น [morph type](https://reference.aspose.com/slides/th/java/com.aspose.slides/TransitionType) บนสไลด์ที่สอง

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

## **ประเภทการเปลี่ยนแบบ Morph**
enum [TransitionMorphType](https://reference.aspose.com/slides/th/java/com.aspose.slides/TransitionMorphType) ใหม่ได้ถูกเพิ่มเข้ามา ซึ่งแสดงประเภทต่าง ๆ ของการเปลี่ยนสไลด์แบบ Morph

enum TransitionMorphType มีสามสมาชิก:

- ByObject: การเปลี่ยน Morph จะดำเนินการโดยพิจารณารูปร่างเป็นอ็อบเจกต์ที่ไม่แยกย่อย
- ByWord: การเปลี่ยน Morph จะดำเนินการโดยถ่ายโอนข้อความเป็นคำเมื่อทำได้
- ByChar: การเปลี่ยน Morph จะดำเนินการโดยถ่ายโอนข้อความเป็นอักขระเมื่อทำได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าการเปลี่ยน Morph บนสไลด์และเปลี่ยนประเภท Morph:

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
Aspose.Slides for Java รองรับการตั้งค่าเอฟเฟกต์การเปลี่ยน เช่น from black, from left, from right เป็นต้น เพื่อกำหนด Transition Effect โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) class.
- รับอ้างอิงของสไลด์
- ตั้งค่าเอฟเฟกต์การเปลี่ยน
- เขียนการนำเสนอเป็นไฟล์ [PPTX ](https://docs.fileformat.com/presentation/pptx/)file

ในตัวอย่างด้านล่าง เราได้ตั้งค่าเอฟเฟกต์การเปลี่ยน

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // ตั้งค่าเอฟเฟ็กต์
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // เขียนการนำเสนอลงดิสก์
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**ฉันสามารถควบคุมความเร็วในการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ได้ คุณสามารถตั้งค่า [speed](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) ของการเปลี่ยนโดยใช้การตั้งค่า [TransitionSpeed](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitionspeed/) (เช่น ช้า/ปานกลาง/เร็ว)

**ฉันสามารถแนบเสียงเข้ากับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?**

ได้ คุณสามารถฝังเสียงสำหรับการเปลี่ยนและควบคุมพฤติกรรมผ่านการตั้งค่าเช่น โหมดเสียงและการวนซ้ำ (เช่น [setSound](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), รวมถึงเมตาดาต้าเช่น [setSoundIsBuiltIn](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) และ [setSoundName](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-))

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

กำหนดประเภทการเปลี่ยนที่ต้องการในการตั้งค่าการเปลี่ยนของแต่ละสไลด์; การเปลี่ยนถูกจัดเก็บแยกตามสไลด์ ดังนั้นการใช้ประเภทเดียวกันทั่วทุกสไลด์จะให้ผลลัพธ์ที่สอดคล้องกัน

**ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งอยู่บนสไลด์ในขณะนี้ได้อย่างไร?**

ตรวจสอบ [transition settings](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslide/#getSlideShowTransition--) ของสไลด์และอ่านค่า [transition type](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setType-int-) ; ค่านั้นจะแสดงให้คุณทราบว่าเอฟเฟกต์ใดถูกนำมาใช้ในขณะนั้น