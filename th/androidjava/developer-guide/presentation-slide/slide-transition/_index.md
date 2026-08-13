---
title: จัดการการเปลี่ยนสไลด์ในการนำเสนอบน Android
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
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีการปรับแต่งการเปลี่ยนสไลด์ใน Aspose.Slides สำหรับ Android ผ่าน Java พร้อมขั้นตอนแนะนำอย่างละเอียดสำหรับการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดการการเปลี่ยนสไลด์ในงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีการใช้ประเภทการเปลี่ยนสไลด์กับสไลด์ การกำหนดพฤติกรรมการเปลี่ยนเช่น การเลื่อนไปต่อเมื่อคลิกหรือหลังจากเวลาที่กำหนด การใช้การเปลี่ยน Morph และประเภทต่าง ๆ ของมัน และการตั้งค่าตัวเลือกเอฟเฟกต์การเปลี่ยน ตัวอย่างแสดงวิธีการโหลดหรือสร้างงานนำเสนอ ปรับการตั้งค่าการเปลี่ยนสำหรับสไลด์ที่เลือก และบันทึกผลลัพธ์เป็นไฟล์ PPTX บทความยังตอบคำถามทั่วไปเกี่ยวกับความเร็วของการเปลี่ยน เสียงของการเปลี่ยน การใช้การเปลี่ยนเดียวกันกับหลายสไลด์ และการตรวจสอบการเปลี่ยนที่ตั้งค่าอยู่ในสไลด์

## **เพิ่มการเปลี่ยนสไลด์**
เพื่อสร้างเอฟเฟกต์การเปลี่ยนสไลด์อย่างง่าย โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
2. ใช้ประเภทการเปลี่ยนสไลด์บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่มีให้โดย Aspose.Slides for Android ผ่าน Java โดยใช้ enum TransitionType
3. เขียนไฟล์งานนำเสนอที่ปรับปรุงแล้ว

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอต้นฉบับ
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // ใช้การเปลี่ยนแบบวงกลมบนสไลด์ที่ 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // ใช้การเปลี่ยนแบบรางบนสไลด์ที่ 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // บันทึกงานนำเสนอลงดิสก์
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**
ในส่วนข้างต้น เราได้ใช้เอฟเฟกต์การเปลี่ยนอย่างง่ายบนสไลด์เท่านั้น ตอนนี้เพื่อทำให้เอฟเฟกต์การเปลี่ยนง่าย ๆ นี้ดียิ่งขึ้นและควบคุมได้ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
2. ใช้ประเภทการเปลี่ยนสไลด์บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่มีให้โดย Aspose.Slides for Android ผ่าน Java
3. คุณสามารถตั้งค่าการเปลี่ยนให้ Advance On Click หลังจากระยะเวลาที่กำหนด หรือทั้งสองอย่างได้
4. หากการเปลี่ยนสไลด์ถูกตั้งค่าให้ Advance On Click การเปลี่ยนจะดำเนินต่อเมื่อมีการคลิกเมาส์เท่านั้น นอกจากนี้ หากตั้งค่า Property Advance After Time ไว้ การเปลี่ยนจะดำเนินอัตโนมัติหลังจากเวลาที่กำหนดผ่านไป
5. เขียนงานนำเสนอที่ปรับปรุงแล้วเป็นไฟล์งานนำเสนอ

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // ใช้การเปลี่ยนแบบวงกลมบนสไลด์ที่ 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // เลื่อนไปต่อเมื่อคลิกหรือโดยอัตโนมัติหลังจาก 3 วินาที
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // ใช้การเปลี่ยนแบบรางบนสไลด์ที่ 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // เลื่อนไปต่อเมื่อคลิกหรือโดยอัตโนมัติหลังจาก 5 วินาที
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // ใช้การเปลี่ยนแบบซูมบนสไลด์ที่ 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // เลื่อนไปต่อเมื่อคลิกหรือโดยอัตโนมัติหลังจาก 7 วินาที
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph Transition**
{{% alert color="info" %}} 

Aspose.Slides for Android ผ่าน Java ตอนนี้รองรับ [Morph Transition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IMorphTransition) ซึ่งเป็นการเปลี่ยน Morph ใหม่ที่แนะนำใน PowerPoint 2019.

{{% /alert %}} 

การเปลี่ยน Morph ทำให้คุณสามารถสร้างการเคลื่อนที่อย่างราบรื่นจากสไลด์หนึ่งไปยังสไลด์ต่อไป บทความนี้อธิบายแนวคิดและวิธีการใช้การเปลี่ยน Morph เพื่อให้ใช้งานได้อย่างมีประสิทธิภาพ คุณต้องมีสไลด์สองสไลด์ที่มีออบเจกต์อย่างน้อยหนึ่งอย่างร่วมกัน วิธีที่ง่ายที่สุดคือทำสำเนาสไลด์แล้วย้ายออบเจกต์ในสไลด์ที่สองไปยังตำแหน่งอื่น

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มสำเนาของสไลด์พร้อมข้อความบางส่วนลงในงานนำเสนอและตั้งค่าเป็นการเปลี่ยนประเภท [morph type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TransitionType) ให้กับสไลด์ที่สอง

```java
import com.aspose.slides.*;

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
ได้เพิ่ม enum ใหม่ชื่อ [TransitionMorphType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/TransitionMorphType) ซึ่งแทนประเภทต่าง ๆ ของการเปลี่ยน Morph

enum TransitionMorphType มีสมาชิกสามตัว:

- ByObject: การเปลี่ยน Morph จะทำโดยพิจารณารูปร่างเป็นออบเจ็กต์ที่ไม่แยกย่อย
- ByWord: การเปลี่ยน Morph จะทำโดยการย้ายข้อความเป็นคำเมื่อเป็นไปได้
- ByChar: การเปลี่ยน Morph จะทำโดยการย้ายข้อความเป็นอักขระเมื่อเป็นไปได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าการเปลี่ยน Morph ให้สไลด์และเปลี่ยนประเภท Morph:

```java
import com.aspose.slides.*;

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
Aspose.Slides for Android ผ่าน Java รองรับการตั้งค่าเอฟเฟกต์การเปลี่ยน เช่น from black, from left, from right ฯลฯ เพื่อกำหนด Transition Effect โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
- รับอ้างอิงของสไลด์
- ตั้งค่าเอฟเฟกต์การเปลี่ยน
- เขียนงานนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) 

ในตัวอย่างด้านล่าง เราได้ตั้งค่าเอฟเฟกต์การเปลี่ยนแล้ว

```java
import com.aspose.slides.*;

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

### ฉันสามารถควบคุมความเร็วในการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?

ได้. ตั้งค่า [speed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) ของการเปลี่ยนโดยใช้การตั้งค่า [TransitionSpeed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitionspeed/) (เช่น slow/medium/fast)

### ฉันสามารถแนบเสียงเข้ากับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?

ได้. คุณสามารถฝังเสียงสำหรับการเปลี่ยนและควบคุมพฤติกรรมผ่านการตั้งค่าเช่นโหมดเสียงและการวนซ้ำ (เช่น [setSound](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), พร้อมเมตาดาต้าเช่น [setSoundIsBuiltIn](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) และ [setSoundName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-))

### วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?

กำหนดประเภทการเปลี่ยนที่ต้องการในการตั้งค่าการเปลี่ยนของแต่ละสไลด์; การเปลี่ยนถูกจัดเก็บตามสไลด์ ดังนั้นการใช้ประเภทเดียวกันกับทุกสไลด์จะให้ผลลัพธ์ที่สอดคล้องกัน

### ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งค่าอยู่ในสไลด์ปัจจุบันได้อย่างไร?

ตรวจสอบ [transition settings](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) ของสไลด์และอ่านค่า [transition type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideshowtransition/#setType-int-) นั้น ค่าดังกล่าวจะบอกคุณได้อย่างชัดเจนว่าเอฟเฟกต์ใดถูกนำไปใช้

---
title: จัดการการเปลี่ยนสไลด์ในการนำเสนอบน Android
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
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีการปรับแต่งการเปลี่ยนสไลด์ใน Aspose.Slides สำหรับ Android ผ่าน Java พร้อมขั้นตอนแนะนำอย่างละเอียดสำหรับการนำเสนอ PowerPoint และ OpenDocument"
---