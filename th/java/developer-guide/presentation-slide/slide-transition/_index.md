---
title: จัดการการเปลี่ยนสไลด์ในงานนำเสนอด้วย Java
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
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์, กำหนดค่าการเลื่อนสไลด์อัตโนมัติ, และปรับแต่ง Morph รวมถึงเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมวิธีการที่สไลด์ปรากฏระหว่างการแสดงสไลด์ ด้วย Aspose.Slides for Java คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ ตั้งค่าการเลื่อนไปข้างหน้าด้วยการคลิกเมาส์หรือด้วยตัวจับเวลา และปรับตัวเลือกเฉพาะของเอฟเฟกต์ได้ บทความนี้ใช้ตัวอย่าง Java เพื่อทำการเปลี่ยนสไลด์ ตั้งค่าความยาวของการเปลี่ยนอย่างแม่นยำ จัดการเวลาสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเหล่านี้เป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

ในการใช้การเปลี่ยน ให้โหลดไฟล์พรีเซนเทชันด้วยคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) และเข้าถึงการตั้งค่าการเปลี่ยนของสไลด์ผ่าน [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). ใช้ [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) กับค่าที่มาจากการ enumeration [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) จากนั้นบันทึกพรีเซนเทชัน

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

เมธอด [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) ของ [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) ควบคุมจำนวนส่วนรัศมีที่เปิดเผยสไลด์ปลายทาง ตั้งประเภทการเปลี่ยนของสไลด์เป็น Wheel จาก [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) ด้วย [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) ของ [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/)

ตัวอย่างนี้สร้างคู่สไลด์ที่เหมือนกันสองคู่: สไลด์สีดำตามด้วยสไลด์ที่มีสี่เหลี่ยมทอง สไลด์ปลายทางใช้จำนวน spoke 1 และ 8 โดยความเร็วเดียวกันตั้งผ่าน [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) และกำหนดระยะเวลาเฉพาะ 8,000 มิลลิวินาทีด้วย [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) เพื่อให้สังเกตความแตกต่างได้ง่าย

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

เปิดพรีเซนเทชันผลลัพธ์ใน PowerPoint และรันการแสดงสไลด์ เลื่อนไปจากสไลด์ 1 ไปสไลด์ 2 แล้วจากสไลด์ 3 ไปสไลด์ 4 ในการเล่น PowerPoint จำนวน spoke ที่ตรวจสอบได้ 1 จะเปิดเผยสไลด์ด้วยการสวิงตามเข็มนาฬิกาหนึ่งครั้ง; จำนวน 8 จะเปิดเผยด้วยส่วนรัศมีแปดส่วนพร้อมกัน เนื้อหาและเวลาการเปลี่ยนของสไลด์ปลายทางเหมือนกัน ดังนั้นความแตกต่างคือจำนวนส่วนการเปิดเผย

## **Fade Through Black กับการเปลี่ยน Reveal**

ตั้งประเภทการเปลี่ยนของสไลด์ปลายทางเป็น Reveal แล้วเรียก [setThroughBlack](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) บนการตั้งค่า [IRevealTransition](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/) ตัวอย่างนี้สร้างสไลด์ต้นทางสีเทาลมและสไลด์ปลายทางสีปะการัง จากนั้นทำสำเนาทั้งสอง ทุกคู่ใช้การเปลี่ยน Reveal ระยะสองวินาที เพียงคู่ที่สองเท่านั้นจะทำ fade ผ่านสีดำ

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    Color[] backgrounds = { new Color(0, 128, 128), new Color(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เปิดพรีเซนเทชันที่บันทึกไว้ใน PowerPoint และเริ่มการแสดงสไลด์ เลื่อนจากสไลด์ 1 ไปสไลด์ 2 เพื่อดูสีเทา fade ตรงไปยังสีปะการัง จากนั้นเลื่อนจากสไลด์ 3 ไปสไลด์ 4 หน้าจอจะมืดลงสู่สีดำใกล้เคียงก่อนที่สไลด์สีปะการังจะปรากฏ สไลด์ทั้งสองยังคงสีพื้นหลังเดิมของตน

แถวต่อไปแสดงเฟรมจาก PowerPoint แบบครึ่งวินาทีต่อเฟรม เปรียบเทียบเฟรมตรงกลางของแต่ละแถวเพื่อดูเอฟเฟกต์

![PowerPoint playback with the fade through black disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์อยู่บนหน้าจอและว่าการคลิกเมาส์จะเลื่อนไปข้างหน้าหรือไม่ วิธีต่อไปนี้ควบคุมพฤติกรรมดังกล่าว:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) อนุญาตให้ผู้ชมเลื่อนไปข้างหน้าด้วยการคลิกเมาส์
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) เปิดการเลื่อนอัตโนมัติ
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) ระบุดีเลย์ก่อนการเลื่อนอัตโนมัติ หน่วยเป็นมิลลิวินาที

เปิดใช้งานทั้งการคลิกและการเลื่อนตามเวลาเพื่อให้ผู้ชมเลือกคลิกหรือรอเวลา หากต้องการใช้เฉพาะตัวจับเวลา ให้ส่งค่า `false` ไปยัง [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) ดีเลย์จะกำหนดว่าเมื่อไหร่การแสดงสไลด์จะเลื่อนไปข้างหน้า; แต่ไม่กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนภาพ

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่าง ๆ ให้กับสามสไลด์แรกและเปิดการเลื่อนอัตโนมัตหลัง 3, 5, และ 7 วินาทีตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้ ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อตรวจสอบว่าการเลื่อนตามเวลาถูกเปิดหรือไม่ ให้เรียก [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) ค่าดีเลย์ที่เก็บไว้เพียงอย่างเดียวไม่ได้ระบุว่าตัวจับเวลากำลังทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานแต่ละตัวจับเวลาที่เปิดใช้งาน และปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีดีเลย์มากกว่าสองวินาที จากนั้นเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าอัปเดต

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

## **ควบคุมเวลาการเปลี่ยนอย่างแม่นยำ**

ใช้ [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) เพื่อระบุความยาวของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที วิธี [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) ของสไลด์เผยการตั้งค่าเหล่านี้ผ่านอินเทอร์เฟซ [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/):

| Method | วัตถุประสงค์ |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนเองเป็นมิลลิวินาที |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | กำหนดดีเลย์ก่อนสไลด์จะเลื่อนไปอัตโนมัติเป็นมิลลิวินาที ส่งค่า `true` ไปยัง [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) เพื่อเปิดตัวจับเวลา |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | เลือกหมวดความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow, Medium, หรือ Fast จะใช้เมื่อไม่กำหนดระยะเวลาอย่างชัดเจน |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน; ไม่กำหนดระยะเวลาที่สไลด์ยังคงแสดงอยู่ จัดการดีเลย์การเลื่อนอัตโนมัติแยกต่างหาก เมื่อไม่มีการกำหนดระยะเวลาอย่างชัดเจน Aspose.Slides จะคำนวณระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่าของ [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--)

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*ตัวอย่างร่วมนี้ให้แต่ละสไลด์มีการเปลี่ยน Fade 750 ms และเปิดการเลื่อนอัตโนมัติที่ 5,000 ms แถบเหล่านี้เป็นการตั้งค่าแบบเชิงสัญลักษณ์ ไม่ได้เป็นไทม์ไลน์ที่วัดได้จริง*
<!-- visual-explanation:slide-transition:end -->

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสม่ำเสมอ ใช้เอฟเฟกต์และระยะเวลาเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) และให้แต่ละการเปลี่ยนระยะเวลา 750 มิลลิวินาที เปิดการเลื่อนอัตโนมัติหลัง 5,000 มิลลิวินาทีและปิดการเลื่อนด้วยการคลิกเมาส์ แล้วบันทึกเป็น PPTX

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // กำหนดการเลื่อนไปอัตโนมัติตามเวลาโดยอิสระจากระยะเวลาเอฟเฟกต์.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **กำหนดระยะเวลาที่แตกต่างสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่แตกต่างกันได้ ตัวอย่างเช่น ให้สไลด์หัวเรื่องใช้การเปลี่ยนสั้น ๆ และสไลด์ส่วนบทนำใช้การเปลี่ยนยาวกว่า ตัวอย่างนี้กำหนด 500 ms ให้สไลด์แรกและ 1,200 ms ให้สไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

เมื่อเตรียม [animated GIF](/slides/th/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/java/export-to-html5/), หรือ [video](/slides/th/java/convert-powerpoint-to-video/) ให้ตั้งระยะเวลาเอฟเฟกต์ให้แน่นอนก่อนส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การ fade 600 ms ระหว่างฉากต่าง ๆ และปรับดีเลย์การเลื่อนของแต่ละสไลด์แยกกันเพื่อให้มีเวลาพูดบรรยายหรือแสดงเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 ms เท่ากับ 18 เฟรมที่ 30 fps ใน HTML5 ให้เปิดใช้งานการเปลี่ยนภาพเคลื่อนไหวในตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาที่สนับสนุนโดยฟอร์แมตการส่งออกที่เลือกและดูตัวอย่างผลลัพธ์เพื่อยืนยันความสอดคล้อง

### **อ่านระยะเวลาเอฟเฟกต์ที่มีอยู่**

เรียก [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) ก่อนแก้ไขการเปลี่ยนเพื่อดูว่ามีการเก็บค่าความยาวอย่างชัดเจนหรือไม่ ค่า `-1` หมายความว่าไม่ได้กำหนดระยะเวลาอย่างชัดเจน; ค่าไม่เป็นลบจะเป็นระยะเวลาที่เก็บไว้เป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งนี้ไม่ใช่ระยะเวลาการเล่นที่คำนวณได้: Aspose.Slides ใช้ประเภทการเปลี่ยนและค่าของ [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) เพื่อกำหนดระยะเวลานั้น การตั้งค่าประเภทการเปลี่ยนอาจทำให้มีค่าเริ่มต้นของระยะเวลา ดังนั้นตรวจสอบการตั้งค่าเดิมก่อน

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

## **Morph Transition**

การเปลี่ยน Morph ทำให้วัตถุเปลี่ยนแปลงระหว่างสไลด์ต่อเนื่อง เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้ทำสำเนาสไลด์ ย้ายหรือปรับขนาดวัตถุบนสำเนาแล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง จะทำให้วัตถุที่ตรงกันทำการเคลื่อนที่จากสถานะเดิมไปยังสถานะที่แก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ ทำสำเนาสไลด์และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกไว้ด้วยโปรแกรมแสดงผลที่รองรับ Morph เพื่อดูเอฟเฟกต์ระหว่างการแสดงสไลด์

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

## **ประเภท Morph Transition**

enumeration [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และเคลื่อนไหวเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) พิจารณาแต่ละรูปร่างเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) เคลื่อนไหวข้อความโดยจับคู่คำเมื่อเป็นไปได้
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) เคลื่อนไหวข้อความโดยจับคู่อักขระเมื่อเป็นไปได้

ใช้ [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) เพื่อเลือก Morph ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) ค่าที่ได้จะเป็นอินเทอร์เฟซ [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) ซึ่งเมธอด [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) จะเลือกโหมดการจับคู่

ตัวอย่างนี้เปิดพรีเซนเทชันที่สร้างในส่วนก่อนหน้าและกำหนดสไลด์ที่สองให้ใช้การเคลื่อนไหว Morph ตามคำ

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

บางการเปลี่ยนเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าเอฟเฟกต์เริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้ขึ้นอยู่กับการเปลี่ยนที่เลือกด้วย [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) ตั้งประเภทก่อน แล้วใช้อินเทอร์เฟซที่เหมาะสมจาก [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--)

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` เรียก [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) ผ่าน [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

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

**ฉันสามารถควบคุมความเร็วของการเล่นการเปลี่ยนสไลด์ได้หรือไม่?**

ได้. ให้ใช้ [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แม่นยำเป็นมิลลิวินาที ใช้ [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) เมื่อหมวดความเร็วที่กำหนดไว้ล่วงหน้าใน [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) (Slow, Medium, Fast) เพียงพอและไม่มีการกำหนดระยะเวลาอย่างชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนโดยอิสระจากดีเลย์การเลื่อนอัตโนมัติ

**ฉันสามารถแนบเสียงกับการเปลี่ยนและทำให้เสียงวนต่อเนื่องได้หรือไม่?**

ได้. กำหนดเสียงฝังด้วย [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), ส่งค่า StartSound จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) ไปยัง [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), และเปิดใช้งาน [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) ด้วย `true` เสียงจะวนจนกว่าจะมีเหตุการณ์เสียงถัดไปในพรีเซนเทชัน

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนผ่านคอลเลกชัน [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) ของพรีเซนเทชันและเรียก [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) ด้วยค่าที่เหมือนกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าตารางเวลาและตัวเลือกเอฟเฟกต์ในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันทั่วทั้งสไลด์

**ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งอยู่ในสไลด์ปัจจุบันได้อย่างไร?**

เรียก [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) บนผลลัพธ์ของ [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) ของสไลด์นั้น จะคืนค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/); ค่า None หมายถึงไม่มีการตั้งค่าเอฟเฟกต์การเปลี่ยนใด ๆ.