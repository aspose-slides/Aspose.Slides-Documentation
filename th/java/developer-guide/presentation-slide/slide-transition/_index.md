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
- การเปลี่ยน Morph
- ประเภทการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์, ตั้งค่าการดำเนินการสไลด์อัตโนมัติ, และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides for Java."
---
## **ภาพรวม**

การเปลี่ยหน้า (Slide transitions) ควบคุมวิธีการแสดงสไลด์ระหว่างการนำเสนอ ด้วย Aspose.Slides for Java คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ ตั้งค่าการดำเนินการโดยคลิกเมาส์หรือโดยตัวจับเวลา และปรับตัวเลือกที่เฉพาะเจาะจงสำหรับเอฟเฟกต์ บทความนี้ใช้ตัวอย่าง Java เพื่อใช้การเปลี่ยน ตั้งค่าระยะเวลาเปลี่ยนที่แน่นอน จัดการเวลาแสดงสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้งานการเปลี่ยน ให้โหลดพรีเซนเทชันด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และเข้าถึงการตั้งค่าการเปลี่ยนของสไลด์ผ่าน [getSlideShowTransition](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). ใช้ [setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setType-int-) พร้อมค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitiontype/) จากนั้นบันทึกพรีเซนเทชัน

ตัวอย่างต่อไปใช้การเปลี่ยน Circle กับสไลด์แรกและการเปลี่ยน Comb กับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

คุณสามารถกำหนดระยะเวลาที่สไลด์อยู่บนหน้าจอและการคลิกเมาส์ที่จะดำเนินการต่อได้ วิธีต่อไปนี้ควบคุมพฤติกรรมนี้:

- [setAdvanceOnClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) ทำให้ผู้ชมสามารถดำเนินการต่อโดยคลิกเมาส์
- [setAdvanceAfter](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) เปิดการดำเนินการอัตโนมัติ
- [setAdvanceAfterTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) กำหนดเวลาหน่วงก่อนการดำเนินการอัตโนมัติ หน่วยเป็นมิลลิวินาที

เปิดการดำเนินการทั้งแบบคลิกและแบบจับเวลาเพื่อให้ผู้ชมสามารถกดคลิกหรือรอจนถึงเวลา เพื่อใช้เฉพาะตัวจับเวลา ให้ส่งค่า `false` ไปยัง [setAdvanceOnClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). การหน่วงเวลาควบคุมเมื่อการนำเสนอเปลี่ยน ไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนภาพ

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่าง ๆ ให้กับสามสไลด์แรกและเปิดการดำเนินการอัตโนมัติหลังจาก 3, 5, และ 7 วินาที ตามลำดับ การคลิกเมาส์ก็สามารถดำเนินการต่อสไลด์เหล่านี้ได้ ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อตรวจสอบว่าการดำเนินการแบบจับเวลาถูกเปิดหรือไม่ ให้เรียก [getAdvanceAfter](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). ค่าหน่วงเวลาที่เก็บไว้เพียงอย่างเดียวไม่บ่งชี้ว่าตัวจับเวลากำลังทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ด้านบน รายงานตัวจับเวลาที่เปิดอยู่แต่ละรายการ และปิดการดำเนินการอัตโนมัติสำหรับสไลด์ที่มีการหน่วงเวลามากกว่าสองวินาที เปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าที่อัปเดต

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

## **ควบคุมเวลาเปลี่ยนอย่างแม่นยำ**

ใช้ [setDuration](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setDuration-int-) เพื่อระบุความยาวที่แน่นอนของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที วิธี [getSlideShowTransition](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [ISlideShowTransition](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/):

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | ตั้งค่าระยะเวลาของเอฟเฟกต์การเปลี่ยนเองเป็นมิลลิวินาที |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | ตั้งค่าหน่วงเวลาก่อนสไลด์ดำเนินการอัตโนมัติเป็นมิลลิวินาที ส่งค่า `true` ไปยัง [setAdvanceAfter](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) เพื่อเปิดตัวจับเวลา |
| [setSpeed](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | เลือกหมวดความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitionspeed/): Slow, Medium, หรือ Fast ใช้เมื่อไม่ได้ระบุระยะเวลาที่แน่นอน |

[setDuration](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setDuration-int-) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน ไม่ได้กำหนดระยะเวลาที่สไลด์คงอยู่บนหน้าจอ กำหนดหน่วงเวลาการดำเนินการอัตโนมัติแยกต่างหาก เมื่อไม่มีการตั้งค่าระยะเวลาชัดเจน Aspose.Slides จะกำหนดระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่าจาก [getSpeed](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#getSpeed--)

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสอดคล้อง ให้ใช้เอฟเฟกต์และระยะเวลาเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitiontype/) และตั้งค่าระยะเวลาให้แต่ละการเปลี่ยนเป็น 750 มิลลิวินาที แยกเปิดการดำเนินการอัตโนมัติหลัง 5,000 มิลลิวินาทีและปิดการดำเนินการโดยคลิกเมาส์ จากนั้นบันทึกผลเป็น PPTX

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // กำหนดการดำเนินการอัตโนมัติโดยอิสระจากระยะเวลาเอฟเฟกต์.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ตั้งค่าระยะเวลาต่างกันสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาของเอฟเฟกต์ที่ต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวเรื่องและใช้การเปลี่ยนยาวสำหรับการแนะนำส่วน ตัวอย่างนี้ตั้งค่า 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1,200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

### **ประสานการเปลี่ยนกับผลลัพธ์ที่เป็นอนิเมชัน**

เมื่อเตรียม [animated GIF](/slides/th/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/java/export-to-html5/), หรือ [video](/slides/th/java/convert-powerpoint-to-video/), ตั้งค่าระยะเวลาเปลี่ยนที่แน่นอนก่อนส่งออกเพื่อให้สอดคล้องกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจาง 600 มิลลิวินาทีระหว่างฉาก และปรับหน่วงเวลาการดำเนินการของแต่ละสไลด์แยกกันเพื่อให้มีเวลาในการบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 เปิดการเปลี่ยนแบบอนิเมชันในการตั้งค่าการส่งออก ตรวจสอบว่าไฟล์ส่งออกรองรับเอฟเฟกต์และตัวเลือกเวลาใดบ้างและพรีวิวผลลัพธ์เพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาเปลี่ยนที่มีอยู่**

เรียก [getDuration](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#getDuration--) ก่อนแก้ไขการเปลี่ยนเพื่อดูว่ามีค่าเฉพาะที่จัดเก็บหรือไม่ ค่า `-1` หมายถึงไม่มีการตั้งค่าระยะเวลาแบบชัดเจน; ค่าที่เป็นจำนวนเต็มบวกหรือศูนย์ระบุระยะเวลาที่จัดเก็บเป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งค่าไม่ใช่ระยะเวลาการเล่นที่คำนวน: Aspose.Slides ใช้ประเภทการเปลี่ยนและค่าจาก [getSpeed](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#getSpeed--) เพื่อคำนวนระยะเวลา การตั้งค่าประเภทการเปลี่ยนอาจเริ่มต้นระยะเวลา ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

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

การเปลี่ยน Morph ทำให้การเปลี่ยนแปลงระหว่างวัตถุบนสไลด์ต่อเนื่องเป็นภาพเคลื่อนไหว เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้คัดลอกสไลด์ ย้ายหรือปรับขนาดวัตถุบนสไลด์ที่คัดลอก แล้วใส่การเปลี่ยน Morph กับสไลด์ที่สอง การทำเช่นนี้จะทำให้วัตถุที่ตรงกันทำการเคลื่อนไหวจากสถานะเริ่มต้นไปยังสถานะที่แก้ไข

ตัวอย่างต่อไปสร้างสไลด์ที่มีสี่เหลี่ยมข้อความ คัดลอกสไลด์และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสไลด์คัดลอก แล้วเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกไว้ในตัวดูพรีเซนเทชันที่รองรับ Morph เพื่อดูเอฟเฟกต์ระหว่างการนำเสนอ

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

enumeration [TransitionMorphType](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และทำภาพเคลื่อนไหวของเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitionmorphtype/#ByObject) ถือแต่ละรูปทรงเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitionmorphtype/#ByWord) ทำภาพเคลื่อนไหวข้อความโดยจับคู่คำเมื่อเป็นไปได้
- [ByChar](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitionmorphtype/#ByChar) ทำภาพเคลื่อนไหวข้อความโดยจับคู่อักขระเมื่อเป็นไปได้

ใช้ [setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setType-int-) เพื่อเลือก Morph ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#getValue--). ค่าที่ได้จะให้ interface [IMorphTransition](https://reference.aspose.com/slides/th/java/com.aspose.slides/imorphtransition/) ซึ่งเมธอด [setMorphType](https://reference.aspose.com/slides/th/java/com.aspose.slides/imorphtransition/#setMorphType-int-) เลือกโหมดการจับคู่

ตัวอย่างนี้เปิดพรีเซนเทชันที่สร้างในส่วนก่อนหน้าและกำหนดให้สไลด์ที่สองใช้การเคลื่อนไหว Morph แบบตามคำ

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

บางการเปลี่ยนเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือการเริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้ขึ้นอยู่กับการเปลี่ยนที่เลือกด้วย [setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setType-int-). ตั้งค่าประเภทก่อนแล้วใช้ interface ที่เหมาะสมจาก [getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#getValue--)

ตัวอย่างต่อไปใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx`. มันเรียก [setFromBlack](https://reference.aspose.com/slides/th/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) ผ่าน [IOptionalBlackTransition](https://reference.aspose.com/slides/th/java/com.aspose.slides/ioptionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

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

ได้. ควรใช้ [setDuration](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setDuration-int-) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แน่นอนเป็นมิลลิวินาที ใช้ [setSpeed](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) เมื่อหมวด [TransitionSpeed](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitionspeed/) ที่กำหนดไว้ล่วงหน้า—Slow, Medium, หรือ Fast เพียงพอและไม่มีการตั้งค่าระยะเวลาโดยตรง การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนโดยอิสระจากหน่วงเวลาการดำเนินการอัตโนมัติ

**ฉันสามารถแนบเสียงกับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?**

ได้. กำหนดเสียงฝังด้วย [setSound](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), ส่งค่า StartSound จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitionsoundmode/) ไปยัง [setSoundMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), และเปิด [setSoundLoop](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) ด้วยค่า `true`. เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงถัดไปในการนำเสนอ

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [getSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSlides--) ของพรีเซนเทชันและเรียก [setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#setType-int-) ด้วยค่าเดียวกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าตัวเลือกเวลาและเอฟเฟกต์ใด ๆ ในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันในทุกสไลด์

**ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งค่าบนสไลด์ปัจจุบันได้อย่างไร?**

เรียก [getType](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideshowtransition/#getType--) บนผลลัพธ์ของ [getSlideShowTransition](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) ของสไลด์ จะได้รับค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/java/com.aspose.slides/transitiontype/); ค่า None หมายถึงไม่มีเอฟเฟกต์การเปลี่ยนใด ๆ ถูกใช้