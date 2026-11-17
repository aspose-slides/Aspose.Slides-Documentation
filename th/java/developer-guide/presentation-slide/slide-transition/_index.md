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
description: "ใช้การเปลี่ยนสไลด์, ตั้งค่าการเลื่อนสไลด์อัตโนมัติ, และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมว่าหน้าแสดงผลปรากฏอย่างไรระหว่างการนำเสนอด้วยสไลด์โชว์ ด้วย Aspose.Slides for Java คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ ตั้งค่าการเลื่อนหน้าด้วยการคลิกเมาส์หรือโดยการตั้งเวลา และปรับตัวเลือกเฉพาะของเอฟเฟกต์ได้ บทความนี้ใช้ตัวอย่าง Java เพื่อประยุกต์ใช้การเปลี่ยน ตั้งค่าระยะเวลาเปลี่ยนที่แม่นยำ จัดการเวลาเปิดสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยน โหลดงานนำเสนอด้วยคลาส [การนำเสนอ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) และเข้าถึงการตั้งค่าการเปลี่ยนของสไลด์ผ่าน [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). ใช้ [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) กับค่าจากการนับแบบ [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) จากนั้นบันทึกงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Circle กับสไลด์แรกและการเปลี่ยน Comb กับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **การเปลี่ยนแบบล้อ**

เมธอด [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) ของ [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) ควบคุมจำนวนเซกเตอร์รังสีที่ทำให้สไลด์ปลายทางปรากฏ ตั้งค่าชนิดการเปลี่ยนของสไลด์เป็น Wheel จาก [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) ด้วย [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) ในฐานะ [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/)

ตัวอย่างนี้สร้างสไลด์คู่ที่เหมือนกันสองคู่: สไลด์สีดำตามด้วยสไลด์ที่มีสี่เหลี่ยมสีทอง สไลด์ปลายทางใช้จำนวน spoke เป็น 1 และ 8 พร้อมความเร็วเดียวกันที่ตั้งผ่าน [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) และระยะเวลาโดยตรง 8,000 มิลลิวินาทีผ่าน [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) เพื่อให้สังเกตความแตกต่างได้ง่าย

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เปิดงานนำเสนอผลลัพธ์ใน PowerPoint แล้วรันการแสดงสไลด์ เดินหน้าจากสไลด์ 1 ไปสไลด์ 2 แล้วจากสไลด์ 3 ไปสไลด์ 4 ในการเล่นของ PowerPoint จำนวน spoke 1 ที่ตรวจสอบแล้วจะแสดงสไลด์ด้วยการกวาดตามเข็มนาฬิกาเพียงครั้งเดียว; จำนวน 8 จะเปิดเผยสไลด์ผ่านแปดเซกเตอร์รังสีพร้อมกัน เนื้อหาและเวลาเปลี่ยนของสไลด์ปลายทางเหมือนกัน ดังนั้นความแตกต่างคือจำนวนเซกเตอร์ที่เปิดเผย

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์อยู่บนหน้าจอและว่าการคลิกเมาส์จะทำให้การแสดงสไลด์ก้าวหน้าหรือไม่ วิธีต่อไปนี้ควบคุมพฤติกรรมดังกล่าว:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) ให้ผู้ชมเลื่อนโดยคลิกเมาส์
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) เปิดใช้งานการเลื่อนอัตโนมัติ
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) ระบุความล่าช้าก่อนการเลื่อนอัตโนมัติ หน่วยเป็นมิลลิวินาที

เปิดใช้งานทั้งการคลิกและการเลื่อนตามเวลาเพื่อให้ผู้ชมสามารถกดคลิกเพื่อดำเนินต่อหรือรอจนกอนไทเมอร์จะทำงาน หากต้องการใช้เฉพาะไทเมอร์ ให้ส่งค่า `false` ไปยัง [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). ความล่าช้ากำหนดเวลาที่สไลด์โชว์จะก้าวหน้า; มันไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยน

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่างกันให้กับสามสไลด์แรกและเปิดใช้งานการเลื่อนอัตโนมัติหลังจาก 3, 5 และ 7 วินาทีตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้ ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

เพื่อตรวจสอบว่าการเลื่อนตามเวลาถูกเปิดหรือไม่ เรียก [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) ค่าที่เก็บไว้เพียงอย่างเดียวไม่บ่งบอกว่าไทเมอร์กำลังทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานไทเมอร์ที่เปิดใช้งานแต่ละรายการและปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีความล่าชุมากกว่าสองวินาที พร้อมเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าอัปเดต

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ควบคุมเวลาเปลี่ยนสไลด์อย่างแม่นยำ**

ใช้ [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) เพื่อระบุความยาวที่แน่นอนของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที เมธอด [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/):

| วิธี | วัตถุประสงค์ |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | ตั้งค่าระยะเวลาของเอฟเฟกต์การเปลี่ยนเองเป็นมิลลิวินาที |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | ตั้งค่าความล่าช้าก่อนสไลด์จะเลื่อนอัตโนมัติเป็นมิลลิวินาที ส่งค่า `true` ไปยัง [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) เพื่อเปิดใช้งานไทเมอร์นี้ |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | เลือกประเภทความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow, Medium หรือ Fast ใช้เมื่อไม่ได้ระบุระยะเวลาอย่างชัดเจน |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน; ไม่ได้กำหนดว่าหน้าจอสไลด์จะคงอยู่เท่าไหร่ ให้ตั้งค่าความล่าช้าการเลื่อนอัตโนมัติแยกต่างหาก เมื่อไม่มีการกำหนดระยะเวลาชัดเจน Aspose.Slides จะกำหนดระยะเวลาจากประเภทการเปลี่ยนและค่าที่ได้จาก [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) 

<!-- visual-explanation:slide-transition:start -->
[![แถบแยกแยะระยะเวลาเปลี่ยน 750 มิลลิวินาทีและการเลื่อนอัตโนมัติ 5,000 มิลลิวินาที](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*ตัวอย่างที่แบ่งปันให้แต่ละสไลด์ใช้การเปลี่ยน Fade 750 มิลลิวินาทีและเปิดใช้งานการเลื่อนอัตโนมัติที่ 5,000 มิลลิวินาทีแยกกัน ระยะเวลาเปลี่ยนควบคุมเอฟเฟกต์; การเลื่อนควบคุมเวลาออกจากสไลด์ แถบเหล่านี้เป็นการตั้งค่าแบบผัง ไม่ใช่ไทม์ไลน์ที่วัดได้*
<!-- visual-explanation:slide-transition:end -->

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสอดคล้อง ให้ใช้เอฟเฟกต์เดียวกันและระยะเวลาเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) แล้วกำหนดระยะเวลาให้แต่ละการเปลี่ยนเป็น 750 มิลลิวินาที แยกเปิดการเลื่อนอัตโนมัติหลังจาก 5,000 มิลลิวินาทีและปิดการเลื่อนด้วยการคลิกเมาส์ จากนั้นบันทึกเป็น PPTX

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // กำหนดการเลื่อนอัตโนมัติเพื่อทำงานแยกจากระยะเวลาของเอฟเฟกต์.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ตั้งระยะเวลาที่แตกต่างสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่ต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวเรื่องและการเปลี่ยนยาวสำหรับส่วนแนะนำ ตัวอย่างนี้กำหนด 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1,200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **ประสานการเปลี่ยนกับผลลัพธ์ที่เป็นภาพเคลื่อนไหว**

เมื่อเตรียม [animated GIF](/slides/th/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/java/export-to-html5/) หรือ [video](/slides/th/java/convert-powerpoint-to-video/), ตั้งค่าระยะเวลาเปลี่ยนที่แน่นอนก่อนการส่งออกเพื่อให้สอดคล้องกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การเฟด 600 มิลลิวินาทีระหว่างฉาก และปรับความล่าช้าการเลื่อนของแต่ละสไลด์แยกกันเพื่อให้มีเวลาอธิบายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 ให้เปิดใช้งานการเปลี่ยนแบบเคลื่อนไหวในการตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาในรูปแบบการส่งออกที่เลือก แล้วดูตัวอย่างผลลัพธ์เพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาเปลี่ยนที่มีอยู่**

เรียก [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) ก่อนแก้ไขการเปลี่ยนเพื่อดูว่ามีการจัดเก็บค่าที่ชัดเจนหรือไม่ ค่า `-1` หมายความว่าไม่มีการกำหนดระยะเวลาอย่างชัดเจน; ค่าที่ไม่เป็นลบระบุระยะเวลาที่จัดเก็บเป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งไม่ใช่ระยะเวลาการเล่นที่คำนวณ: Aspose.Slides ใช้ประเภทการเปลี่ยนและค่าที่ได้จาก [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) เพื่อกำหนดระยะเวลานั้น การตั้งค่าชนิดการเปลี่ยนอาจทำให้ระยะเวลาเริ่มต้น ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **การเปลี่ยนแบบ Morph**

การเปลี่ยน Morph ทำให้วัตถุที่อยู่บนสไลด์ต่อเนื่องเคลื่อนไหวระหว่างสไลด์ที่ต่อเนื่อง เพื่อสร้างเอฟเฟกต์ Morph ง่าย ๆ ให้คัดลอกสไลด์แล้วย้ายหรือปรับขนาดวัตถุบนสไลด์คัดลอก แล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง จะทำให้วัตถุที่ตรงกันเคลื่อนไหวจากสภาวะเดิมไปยังสภาวะที่แก้ไข

ตัวอย่างต่อไปสร้างสไลด์ที่มีสี่เหลี่ยมข้อความ คัดลอกสไลด์และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสไลด์คัดลอก แล้วเลือก Morph จากการนับแบบ [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกในโปรแกรมดูงานนำเสนอที่รองรับ Morph เพื่อดูเอฟเฟกต์ในการแสดงสไลด์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ประเภทการเปลี่ยน Morph**

การนับแบบ [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และเคลื่อนไหวเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) ปฏิบัติเช่นรูปทรงแต่ละอันเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) เคลื่อนไหวข้อความโดยจับคู่คำเมื่อเป็นไปได้
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) เคลื่อนไหวข้อความโดยจับคู่อักขระเมื่อเป็นไปได้

ใช้ [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) เพื่อเลือก Morph ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--). ค่าที่ได้จะให้ส่วนต่อประสาน [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) ซึ่งเมธอด [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) เลือกโหมดการจับคู่

ตัวอย่างนี้เปิดงานนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดสไลด์ที่สองให้ใช้การเคลื่อนไหว Morph แบบตามคำ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าเอฟเฟกต์การเปลี่ยน**

บางการเปลี่ยนให้ตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าเอฟเฟกต์จะเริ่มจากหน้าจอสีดำ ตัวเลือกที่มีขึ้นอยู่กับการเปลี่ยนที่เลือกด้วย [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-). ตั้งค่าชนิดก่อน แล้วใช้ส่วนต่อประสานที่เหมาะสมจาก [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--).

ตัวอย่างต่อไปใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx`. มันเรียก [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) ผ่าน [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่. แนะนำให้ใช้ [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แน่นอนเป็นมิลลิวินาที ใช้ [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) เมื่อประเภท [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) ที่กำหนดไว้—Slow, Medium หรือ Fast—เพียงพอและไม่มีการกำหนดระยะเวลาอย่างชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนโดยอิสระจากความล่าช้าการเลื่อนอัตโนมัติ

**ฉันสามารถแนบเสียงเข้ากับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?**

ใช่. กำหนดเสียงแบบฝังด้วย [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), ส่งค่า StartSound จากการนับแบบ [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) ไปยัง [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), และเปิดใช้งาน [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) ด้วย `true` เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงถัดไปในสไลด์โชว์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) ของงานนำเสนอและเรียก [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) ด้วยค่าที่เดียวกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าการเวลาและตัวเลือกเอฟเฟกต์ในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันในทุกสไลด์

**ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกกำหนดบนสไลด์ปัจจุบันได้อย่างไร?**

เรียก [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) บนผลลัพธ์ของ [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) ของสไลด์ จะคืนค่าจากการนับแบบ [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/); ค่าที่เป็น None หมายความว่าไม่มีการใช้เอฟเฟกต์การเปลี่ยนใด ๆ.