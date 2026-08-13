---
title: จัดการการเปลี่ยนสไลด์ในงานนำเสนอด้วย Java
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 80
url: /th/java/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- ใช้งานการเปลี่ยนสไลด์
- การเปลี่ยนสไลด์ขั้นสูง
- การเปลี่ยน Morph
- ประเภทการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีการปรับแต่งการเปลี่ยนสไลด์ใน Aspose.Slides สำหรับ Java ด้วยคำแนะนำทีละขั้นตอนสำหรับงานนำเสนอ PowerPoint และ OpenDocument."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการการเปลี่ยนสไลด์ในงานนำเสนอโดยใช้ Aspose.Slides มันแสดงวิธีการใช้ประเภทการเปลี่ยนสไลด์บนสไลด์, การกำหนดค่าพฤติกรรมการเปลี่ยนเช่น การเลื่อนไปขณะคลิกหรือหลังจากระยะเวลาที่กำหนด, การตรวจสอบและปิดการเลื่อนอัตโนมัติ, การใช้การเปลี่ยน Morph และประเภทของมัน, และการตั้งค่าตัวเลือกผลกระทบการเปลี่ยน ตัวอย่างแสดงวิธีการโหลดหรือสร้างงานนำเสนอ, การแก้ไขการตั้งค่าการเปลี่ยนสำหรับสไลด์ที่เลือก, และบันทึกผลลัพธ์เป็นไฟล์ PPTX บทความยังตอบคำถามทั่วไปเกี่ยวกับความเร็วของการเปลี่ยน, เสียงการเปลี่ยน, การใช้การเปลี่ยนเดียวกันหลายสไลด์, และการตรวจสอบการเปลี่ยนที่ตั้งอยู่ในสไลด์ปัจจุบัน

## **เพิ่มการเปลี่ยนสไลด์**
เพื่อสร้างเอฟเฟกต์การเปลี่ยนสไลด์แบบง่าย ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation).
2. ใช้ประเภทการเปลี่ยนสไลด์บนสไลด์จากเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for Java มีให้ผ่าน enum TransitionType
3. เขียนไฟล์งานนำเสนอที่แก้ไขแล้ว.

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอต้นฉบับ
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // ใช้การเปลี่ยนแบบวงกลมบนสไลด์ที่ 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // ใช้การเปลี่ยนแบบคอมบบนสไลด์ที่ 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // บันทึกงานนำเสนอลงดิสก์
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**
ในส่วนข้างต้น เราเพียงแค่ใช้เอฟเฟกต์การเปลี่ยนสไลด์แบบง่ายบนสไลด์ ตอนนี้เพื่อทำให้เอฟเฟกต์การเปลี่ยนนั้นดียิ่งขึ้นและควบคุมได้ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation).
2. ใช้ประเภทการเปลี่ยนสไลด์บนสไลด์จากเอฟเฟกต์การเปลี่ยนที่ Aspose.Slides for Java มีให้
3. คุณยังสามารถตั้งค่าการเปลี่ยนให้เลื่อนไปเมื่อคลิก, หลังจากช่วงเวลาที่กำหนด หรือทั้งสองอย่าง
4. หากการเปลี่ยนสไลด์ถูกตั้งค่าให้เลื่อนไปเมื่อคลิก การเปลี่ยนจะดำเนินต่อเมื่อผู้ใช้คลิกเมาส์เท่านั้น นอกจากนี้ หากตั้งค่า property Advance After Time การเปลี่ยนจะเลื่อนอัตโนมัติหลังจากเวลาที่กำหนดผ่านไป
5. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์งานนำเสนอ.

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // ใช้การเปลี่ยนแบบวงกลมบนสไลด์ที่ 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // กำหนดเวลาเปลี่ยนเป็น 3 วินาที
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // ใช้การเปลี่ยนแบบคอมบบนสไลด์ที่ 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // กำหนดเวลาเปลี่ยนเป็น 5 วินาที
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // ใช้การเปลี่ยนแบบซูมบนสไลด์ที่ 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // กำหนดเวลาเปลี่ยนเป็น 7 วินาที
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **การเปลี่ยน Morph**
{{% alert color="info" %}} 

Aspose.Slides for Java ตอนนี้รองรับ [Morph Transition](https://reference.aspose.com/slides/th/java/com.aspose.slides/IMorphTransition) ซึ่งเป็นการเปลี่ยนแปลง Morph ใหม่ที่ถูกแนะนำใน PowerPoint 2019.

{{% /alert %}} 

การเปลี่ยน Morph ช่วยให้คุณสร้างการเคลื่อนไหวที่ราบรื่นจากสไลด์หนึ่งไปยังสไลด์ต่อไป บทความนี้อธิบายแนวคิดและวิธีใช้การเปลี่ยน Morph เพื่อใช้การเปลี่ยน Morph อย่างมีประสิทธิภาพ คุณต้องมีสไลด์สองแผ่นที่มีวัตถุอย่างน้อยหนึ่งชิ้นร่วมกัน วิธีที่ง่ายที่สุดคือทำสำเนาสไลด์แล้วย้ายวัตถุในสไลด์ที่สองไปยังตำแหน่งอื่น

โค้ดส่วนต่อไปนี้แสดงวิธีการเพิ่มสไลด์สำเนาที่มีข้อความบางส่วนเข้าไปในงานนำเสนอและตั้งค่าการเปลี่ยนเป็น [morph type](https://reference.aspose.com/slides/th/java/com.aspose.slides/TransitionType) ให้กับสไลด์ที่สอง.

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
ได้เพิ่ม enum [TransitionMorphType](https://reference.aspose.com/slides/th/java/com.aspose.slides/TransitionMorphType) ใหม่ ซึ่งแสดงประเภทต่างๆ ของการเปลี่ยนสไลด์ Morph
enum TransitionMorphType มีสมาชิกสามตัว:

- ByObject: การเปลี่ยน Morph จะดำเนินการโดยพิจารณารูปร่างเป็นวัตถุที่ไม่แยกย่อย.
- ByWord: การเปลี่ยน Morph จะดำเนินการโดยถ่ายโอนข้อความเป็นคำเมื่อเป็นไปได้.
- ByChar: การเปลี่ยน Morph จะดำเนินการโดยถ่ายโอนข้อความเป็นอักขระเมื่อเป็นไปได้.

โค้ดส่วนต่อไปนี้แสดงวิธีตั้งค่าการเปลี่ยน Morph ให้กับสไลด์และเปลี่ยนประเภท morph:

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

## **ตั้งค่าผลกระทบการเปลี่ยน**
Aspose.Slides for Java รองรับการตั้งค่าผลกระทบการเปลี่ยนเช่น จากสีดำ, จากซ้าย, จากขวา เป็นต้น เพื่อกำหนดผลกระทบการเปลี่ยน โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation).
- รับอ้างอิงของสไลด์
- ตั้งค่าผลกระทบการเปลี่ยน
- เขียนงานนำเสนอเป็นไฟล์ [PPTX ](https://docs.fileformat.com/presentation/pptx/)

ในตัวอย่างด้านล่าง เราได้ตั้งค่าผลกระทบการเปลี่ยนแล้ว.

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

### ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?
ใช่. ตั้งค่า [speed](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) ของการเปลี่ยนโดยใช้การตั้งค่า [TransitionSpeed](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitionspeed/) (เช่น ช้า/กลาง/เร็ว).

### ฉันสามารถแนบเสียงเข้ากับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?
ใช่. คุณสามารถฝังเสียงสำหรับการเปลี่ยนและควบคุมพฤติกรรมผ่านการตั้งค่า เช่น โหมดเสียงและการวนซ้ำ (เช่น [setSound](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), รวมถึงเมตาดาต้าเช่น [setSoundIsBuiltIn](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) และ [setSoundName](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?
กำหนดประเภทการเปลี่ยนที่ต้องการในการตั้งค่าการเปลี่ยนของแต่ละสไลด์; การเปลี่ยนจะถูกบันทึกแยกตามสไลด์ ดังนั้นการใช้ประเภทเดียวกันกับทุกสไลด์จะให้ผลลัพธ์ที่สอดคล้องกัน.

### ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งค่าบนสไลด์ในขณะนี้ได้อย่างไร?
ตรวจสอบ [transition settings](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslide/#getSlideShowTransition--) ของสไลด์และอ่านค่า [transition type](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideshowtransition/#setType-int-); ค่านั้นบอกคุณอย่างชัดเจนว่ามีเอฟเฟกต์ใดถูกนำมาใช้.