---
title: จัดการการเปลี่ยนสไลด์ในการพรีเซนเทชันบน Android
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
- พรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์, กำหนดการเลื่อนสไลด์อัตโนมัติ, และปรับแต่ง Morph รวมถึงเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมวิธีการแสดงสไลด์ระหว่างการแสดงสไลด์โชว์ ด้วย Aspose.Slides for Android via Java คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ ตั้งค่าการเลื่อนหน้าด้วยการคลิกเมาส์หรือไทม์เมอร์ และปรับตัวเลือกเฉพาะของเอฟเฟกต์ บทความนี้ใช้ตัวอย่าง Java เพื่อใช้การเปลี่ยน, กำหนดระยะเวลาการเปลี่ยนอย่างแม่นยำ, จัดการเวลาแสดงสไลด์, และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยน โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และเข้าถึงการตั้งค่าการเปลี่ยนของสไลด์ผ่าน [getSlideShowTransition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). ใช้ [setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) พร้อมค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitiontype/) จากนั้นบันทึกงานนำเสนอ

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

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์แสดงบนหน้าจอและว่าการคลิกเมาส์จะเลื่อนสไลด์โชว์หรือไม่ วิธีต่อไปนี้ควบคุมพฤติกรรมดังกล่าว

- [setAdvanceOnClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) อนุญาตให้ผู้ชมเลื่อนหน้าด้วยการคลิกเมาส์
- [setAdvanceAfter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) เปิดใช้งานการเลื่อนอัตโนมัติ
- [setAdvanceAfterTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) ระบุความล่าช้าก่อนการเลื่อนอัตโนมัติ หน่วยเป็นมิลลิวินาที

เปิดใช้งานทั้งการคลิกและการเลื่อนตามเวลาเพื่อให้ผู้ชมเลือกได้ว่าจะคลิกหรือรอไทม์เมอร์ หากต้องการใช้เฉพาะไทม์เมอร์ ให้ส่งค่า `false` ไปที่ [setAdvanceOnClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) ค่าล่าช้าเป็นการกำหนดเวลาที่สไลด์โชว์จะเลื่อนต่อ ไม่ได้ตั้งระยะเวลาของเอฟเฟกต์การเปลี่ยน

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่างกันให้กับสามสไลด์แรกและเปิดใช้การเลื่อนอัตโนมัติหลัง 3, 5, และ 7 วินาที ตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้เช่นกัน ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อตรวจสอบว่าการเลื่อนตามเวลาถูกเปิดใช้งานหรือไม่ ให้เรียก [getAdvanceAfter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) ความล่าช้าที่เก็บไว้เพียงอย่างเดียวไม่ได้หมายความว่าไทม์เมอร์ทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานไทม์เมอร์ที่เปิดใช้งานแต่ละตัวและปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีความล่าช้ามากกว่าสองวินาที พร้อมเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นแล้วบันทึกการตั้งค่าอัปเดต

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

## **ควบคุมระยะเวลาการเปลี่ยนอย่างแม่นยำ**

ใช้ [setDuration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) เพื่อระบุความยาวของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที วิธี [getSlideShowTransition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) ของสไลด์จะเปิดเผยการตั้งค่าเหล่านี้ผ่านอินเตอร์เฟส [ISlideShowTransition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/) :

| เมธอด | วัตถุประสงค์ |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนเอง หน่วยเป็นมิลลิวินาที |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | กำหนดความล่าช้าก่อนสไลด์เลื่อนอัตโนมัติ หน่วยเป็นมิลลิวินาที ส่งค่า `true` ไปที่ [setAdvanceAfter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) เพื่อเปิดไทม์เมอร์ |
| [setSpeed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | เลือกประเภทความเร็วจาก enumeration [TransitionSpeed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitionspeed/) : Slow, Medium, หรือ Fast ใช้เมื่อไม่มีการกำหนดระยะเวลาที่แน่ชัด |

[setDuration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน ไม่ได้กำหนดระยะเวลาที่สไลด์ยังคงมองเห็น Configure ความล่าช้าการเลื่อนอัตโนมัติแยกต่างหาก เมื่ไม่ได้กำหนดระยะเวลาชัดเจน Aspose.Slides จะกำหนดระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่า [getSpeed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) 

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสม่ำเสมอ ให้ใช้เอฟเฟกต์และระยะเวลาที่เท่ากันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitiontype/) และกำหนดระยะเวลา 750 มิลลิวินาทีสำหรับแต่ละการเปลี่ยน พร้อมเปิดการเลื่อนอัตโนมัติหลัง 5,000 มิลลิวินาทีและปิดการเลื่อนด้วยคลิกเมาส์ แล้วบันทึกเป็น PPTX

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // กำหนดการเลื่อนอัตโนมัติแยกต่างหากจากระยะเวลาเอฟเฟกต์.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **กำหนดระยะเวลาต่างกันสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่แตกต่างกันได้ เช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวเรื่องและการเปลี่ยนยาวสำหรับการแนะนำหัวข้อ ตัวอย่างนี้กำหนด 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1,200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

เมื่อเตรียม [animated GIF](/slides/th/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/androidjava/export-to-html5/), หรือ [video](/slides/th/androidjava/convert-powerpoint-to-video/) ให้ตั้งระยะเวลาการเปลี่ยนอย่างแม่นยำก่อนส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การเฟด 600 มิลลิวินาทีระหว่างฉากและปรับความล่าช้าการเลื่อนของแต่ละสไลด์แยกกันเพื่อให้มีเวลาอธิบายหรือเนื้อหา

สำหรับ GIF และวิดีโอให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีนั้นเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 ให้เปิดใช้งานการเปลี่ยนแบบเคลื่อนไหวในการตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาที่รองรับของรูปแบบส่งออกที่เลือกและดูตัวอย่างผลลัพธ์เพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาการเปลี่ยนที่มีอยู่**

เรียก [getDuration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) ก่อนแก้ไขการเปลี่ยนเพื่อดูว่ามีค่าที่กำหนดไว้หรือไม่ ค่า `-1` หมายถึงไม่มีการกำหนดระยะเวลาชัดเจน ค่าไม่เป็นลบจะระบุระยะเวลาที่เก็บไว้เป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งค่าไม่ได้เป็นระยะเวลาการเล่นที่คำนวณ: Aspose.Slides จะใช้ประเภทการเปลี่ยนและค่า [getSpeed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) เพื่อกำหนดระยะเวลานั้น การตั้งค่าประเภทการเปลี่ยนอาจทำให้ระยะเวลาถูกตั้งค่าโดยอัตโนมัติ ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

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

## **การเปลี่ยน Morph**

การเปลี่ยน Morph ทำให้เกิดการเคลื่อนไหวของการเปลี่ยนแปลงระหว่างวัตถุบนสไลด์ที่ต่อเนื่องกัน เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้คัดลอกสไลด์ ย้ายหรือปรับขนาดวัตถุบนสไลด์สำเนา แล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง วิธีนี้ทำให้วัตถุที่ตรงกันทำการเคลื่อนไหวจากสถานะเดิมไปยังสถานะที่แก้ไข

ตัวอย่างต่อไปสร้างสไลด์ที่มีสี่เหลี่ยมข้อความ คัดลอกสไลด์และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสไลด์สำเนา แล้วเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกในโปรแกรมดูงานนำเสนอที่รองรับ Morph เพื่อดูเอฟเฟกต์ในระหว่างการแสดงสไลด์

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

enumeration [TransitionMorphType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และเคลื่อนไหวเนื้อหา

- [ByObject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) ถือแต่ละรูปร่างเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) เคลื่อนไหวข้อความโดยจับคู่คำเมื่อเป็นไปได้
- [ByChar](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) เคลื่อนไหวข้อความโดยจับคู่อักขระเมื่อเป็นไปได้

ใช้ [setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) เพื่อเลือก Morph ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#getValue--) ค่าที่ได้จะให้อินเตอร์เฟส [IMorphTransition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imorphtransition/) ซึ่งเมธอด [setMorphType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) จะเลือกโหมดการจับคู่

ตัวอย่างนี้เปิดงานนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดให้สไลด์ที่สองใช้การเคลื่อนไหว Morph แบบจับคู่ตามคำ

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

บางการเปลี่ยนเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าการเปลี่ยนจะเริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้ขึ้นกับการเปลี่ยนที่เลือกด้วย [setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) ตั้งค่าชนิดก่อน แล้วใช้อินเตอร์เฟสที่เหมาะสมจาก [getValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#getValue--)

ตัวอย่างต่อไปใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` เรียก [setFromBlack](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) ผ่านอินเตอร์เฟส [IOptionalBlackTransition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioptionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

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

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่ ให้ใช้ [setDuration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [setSpeed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitionspeed/) مسبقة التعريف—Slow, Medium, أو Fast—كافية ولا يتطلب تحديد مدة صريحة. هذه الإعدادات تتحكم في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**ฉันสามารถแนบเสียงกับการเปลี่ยนและทำให้มันวนซ้ำได้หรือไม่?**

ใช่ กำหนดเสียงที่ฝังไว้ด้วย [setSound](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) ส่งค่า StartSound จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitionsoundmode/) ไปที่ [setSoundMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) และเปิดใช้งาน [setSoundLoop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) ด้วยค่า `true` เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงถัดไปในสไลด์โชว์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [getSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlides--) ของงานนำเสนอและเรียก [setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) ด้วยค่าเดียวกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าตัวเลือกเวลาและเอฟเฟกต์อื่น ๆ ภายในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันทั้งงาน

**ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งค่าอยู่ในสไลด์ปัจจุบันได้อย่างไร?**

เรียก [getType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideshowtransition/#getType--) บนผลลัพธ์ของ [getSlideShowTransition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) ของสไลด์ จะคืนค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/transitiontype/) ค่า None หมายถึงไม่มีการใช้เอฟเฟกต์การเปลี่ยนใด ๆ