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
description: "ใช้การเปลี่ยนสไลด์, กำหนดค่าการเลื่อนสไลด์อัตโนมัติ, และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ Androidผ่าน Java."
---
## **ภาพรวม**

การเปลี่ยนภาพสไลด์จะควบคุมวิธีที่สไลด์ปรากฏระหว่างการแสดงสไลด์โชว์ ด้วย Aspose.Slides for Android via Java คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ ตั้งค่าการเปลี่ยนโดยคลิกเมาส์หรือโดยการตั้งเวลา และปรับตัวเลือกที่เฉพาะเจาะจงกับเอฟเฟกต์นี้ บทความนี้ใช้ตัวอย่าง Java เพื่อใช้การเปลี่ยน, ตั้งระยะเวลาการเปลี่ยนที่แน่นอน, จัดการเวลาแสดงสไลด์, และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX อีกด้วย

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยน โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) แล้วเข้าถึงการตั้งค่าการเปลี่ยนของสไลด์ผ่าน [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). ใช้ [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) พร้อมค่าจากการนิยาม [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) จากนั้นบันทึกงานนำเสนอ

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

เมธอด [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-) ของ [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) ควบคุมจำนวนส่วนรัศมีที่เปิดเผยสไลด์ปลายทาง ตั้งประเภทการเปลี่ยนของสไลด์เป็น Wheel จาก [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) โดยใช้ [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) ผ่าน [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/)

ตัวอย่างนี้สร้างคู่สไลด์ที่เหมือนกันสองคู่: สไลด์สีดำตามด้วยสไลด์ที่มีสี่เหลี่ยมสีทอง สไลด์ปลายทางใช้จำนวน spoke 1 และ 8 พร้อมความเร็วเดียวกันตั้งโดย [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) และระยะเวลาที่กำหนดไว้เป็น 8,000 มิลลิวินาทีโดยใช้ [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-)

```java
import android.graphics.Color;
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
    int gold = Color.rgb(255, 215, 0);
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

เปิดงานนำเสนอผลลัพธ์ใน PowerPoint แล้วรันสไลด์โชว์ เลื่อนจากสไลด์ 1 ไปยังสไลด์ 2 แล้วจากสไลด์ 3 ไปยังสไลด์ 4 ในการเล่นของ PowerPoint จำนวน spoke 1 ที่ตรวจสอบแล้วจะเปิดเผยสไลด์ด้วยการสวิงตามเข็มนาฬิกาหนึ่งรอบ; จำนวน 8 ที่ตรวจสอบแล้วจะเปิดเผยด้วยส่วนรัศมีแปดส่วนพร้อมกัน เนื้อหาและเวลาการเปลี่ยนของสไลด์ปลายทางเหมือนกัน ดังนั้นความแตกต่างคือจำนวนส่วนที่เปิดเผย

## **การจางผ่านสีดำด้วยการเปลี่ยน Reveal**

ตั้งประเภทการเปลี่ยนของสไลด์ปลายทางเป็น Reveal แล้วเรียก [setThroughBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) บนการตั้งค่า [IRevealTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/) ตัวอย่างนี้สร้างสไลด์ต้นฉบับสีฟ้าครามและสไลด์ปลายทางสีโค랄 แล้วทำการโคลนทั้งสอง คู่แต่ละคู่ใช้การเปลี่ยน Reveal ความยาวสองวินาที เพียงคู่ที่สองเท่านั้นที่จางผ่านสีดำ

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    int[] backgrounds = { Color.rgb(0, 128, 128), Color.rgb(255, 127, 80) };
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

เปิดงานนำเสนอที่บันทึกใน PowerPoint แล้วเริ่มสไลด์โชว์ เลื่อนจากสไลด์ 1 ไปยังสไลด์ 2 เพื่อดูสีฟ้าครามจางเข้ากับสีโค랄โดยตรง จากนั้นเลื่อนจากสไลด์ 3 ไปยังสไลด์ 4 หน้าจอจะมืดลงชั่วขณะจนเกือบสีดำก่อนที่สไลด์โค랄จะปรากฏ สไลด์ทั้งสองยังคงสีพื้นหลังเดิมอยู่

แถวด้านล่างแสดงเฟรมจาก PowerPoint ที่หัวครึ่งวินาที เปรียบเทียบเฟรมกลางในแต่ละแถวเพื่อดูเอฟเฟกต์

![PowerPoint playback with the fade through black disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์คงอยู่บนหน้าจอและว่าจะให้การคลิกเมาส์เลื่อนสไลด์โชว์หรือไม่ เมธอดต่อไปนี้ควบคุมพฤติกรรมนี้:

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) ให้ผู้ชมสามารถเลื่อนต่อด้วยการคลิกเมาส์
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) เปิดใช้งานการเลื่อนอัตโนมัติ
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) ระบุเวลาหน่วงก่อนการเลื่อนอัตโนมัติ (มิลลิวินาที)

เปิดใช้งานทั้งการคลิกและการเลื่อนตามเวลาเพื่อให้ผู้ชมเลือกได้ว่าจะคลิกหรือรอเวลา หากต้องการใช้เฉพาะตัวจับเวลา ให้ส่งค่า `false` ไปที่ [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) ค่าหน่วงควบคุมเมื่อสไลด์โชว์เลื่อนต่อ ไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนภาพ

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่าง ๆ ให้กับสามสไลด์แรกและเปิดการเลื่อนอัตโนมัติหลัง 3, 5, และ 7 วินาที ตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้ ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อตรวจสอบว่าการเลื่อนตามเวลาถูกเปิดใช้หรือไม่ ให้เรียก [getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) ค่าหน่วงที่เก็บไว้เพียงอย่างเดียวไม่ได้หมายความว่าไทม์เมอร์ทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานไทม์เมอร์ที่เปิดใช้งานแต่ละอัน และปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีค่าหน่วงมากกว่าสองวินาที พร้อมเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นแล้วบันทึกการตั้งค่าใหม่

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

ใช้ [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) เพื่อระบุความยาวที่แน่นอนของเอฟเฟกต์การเปลี่ยน (มิลลิวินาที) เมธอด [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/):

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | ตั้งระยะเวลาของเอฟเฟกต์การเปลี่ยนเอง (มิลลิวินาที) |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | ตั้งค่าหน่วงเวลาก่อนที่สไลด์จะเลื่อนต่อโดยอัตโนมัติ (มิลลิวินาที) ส่งค่า `true` ไปที่ [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) เพื่อเปิดใช้ไทม์เมอร์นี้ |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | เลือกหมวดความเร็วที่กำหนดไว้จาก [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) : Slow, Medium, หรือ Fast ใช้เมื่อไม่ได้ระบุระยะเวลาที่แน่นอน |

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) ควบคุมเพียงเอฟเฟกต์การเปลี่ยน ไม่ได้กำหนดระยะเวลาที่สไลด์คงอยู่บนหน้าจอ การตั้งค่าหน่วงเวลาอัตโนมัติควรทำแยกต่างหาก หากไม่ได้ตั้งค่าระยะเวลาชัดเจน Aspose.Slides จะกำหนดระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่าที่ได้จาก [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--)  

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **กำหนดระยะเวลาเดียวกันให้ทุกสไลด์**

สำหรับการจังหวะที่สม่ำเสมอ ให้ใช้เอฟเฟกต์และระยะเวลาที่เท่ากันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) และกำหนดระยะเวลาแต่ละการเปลี่ยนเป็น 750 มิลลิวินาที เปิดการเลื่อนอัตโนมัติหลัง 5,000 มิลลิวินาทีและปิดการเลื่อนด้วยคลิกเมาส์ แล้วบันทึกผลเป็น PPTX

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // กำหนดการเลื่อนไปอัตโนมัติโดยอิสระจากระยะเวลาเอฟเฟกต์
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ตั้งระยะเวลาต่างกันสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่แตกต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวเรื่องและการเปลี่ยนยาวสำหรับสไลด์แนะนำส่วน ตัวอย่างนี้ตั้ง 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1,200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

### **ประสานการเปลี่ยนกับผลลัพธ์แอนิเมชัน**

เมื่อเตรียม [animated GIF](/slides/th/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/androidjava/export-to-html5/), หรือ [video](/slides/th/androidjava/convert-powerpoint-to-video/) ให้ตั้งระยะเวลาการเปลี่ยนที่แน่นอนก่อนส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจาง 600 มิลลิวินาทีระหว่างฉากและปรับค่าหน่วงเวลาการเลื่อนของแต่ละสไลด์แยกกันเพื่อให้มีเวลาในการบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเทียบเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 ให้เปิดการเปลี่ยนแอนิเมชันในตั้งค่าเอ็กซ์พอร์ต ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาในรูปแบบเอ็กซ์พอร์ตที่เลือกและดูตัวอย่างผลลัพธ์เพื่อยืนยันความสอดคล้อง

### **อ่านระยะเวลาการเปลี่ยนที่มีอยู่**

เรียก [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) ก่อนแก้ไขการเปลี่ยนเพื่อดูว่ามีค่าที่ระบุไว้หรือไม่ ค่า `-1` หมายถึงไม่มีการกำหนดระยะเวลาชัดเจน; ค่าที่เป็นบวกหรือศูนย์เป็นระยะเวลาที่เก็บไว้ (มิลลิวินาที) ค่าที่ไม่ได้ตั้งนี้ไม่ใช่ระยะเวลาการเล่นที่คำนวณได้: Aspose.Slides จะใช้ประเภทการเปลี่ยนและค่าที่ได้จาก [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) เพื่อกำหนดระยะเวลานั้น การตั้งค่าประเภทการเปลี่ยนอาจเริ่มต้นระยะเวลาได้ ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

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

การเปลี่ยน Morph ทำแอนิเมชันการเปลี่ยนแปลงระหว่างวัตถุบนสไลด์ต่อเนื่อง เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้โคลนสไลด์ แล้วย้ายหรือปรับขนาดวัตถุบนสไลด์โคลน แล้วใส่การเปลี่ยน Morph กับสไลด์ที่สอง วิธีนี้ทำให้วัตถุที่ตรงกันถูกแอนิเมชันระหว่างสถานะเดิมและที่แก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ โคลนสไลด์นั้นแล้วเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสไลด์โคลน จากนั้นเลือก Morph จากการนิยาม [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกในโปรแกรมแสดงสไลด์ที่รองรับ Morph เพื่อดูเอฟเฟกต์ระหว่างการแสดงสไลด์

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

การนิยาม [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) ควบคุมวิธีที่ Morph ทำการจับคู่และแอนิเมชันเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) ถือแต่ละรูปร่างเป็นวัตถุครบรูป
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) แอนิเมชันข้อความโดยจับคู่คำเมื่อทำได้
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) แอนิเมชันข้อความโดยจับคู่อักษรเมื่อทำได้

ใช้ [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) เพื่อเลือก Morph ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) ค่าที่ได้ให้เข้าถึงอินเทอร์เฟซ [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/) ซึ่งเมธอด [setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) เลือกโหมดการจับคู่

ตัวอย่างนี้เปิดงานนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดสไลด์ที่สองให้ใช้การแอนิเมชัน Morph ตามคำ

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

บางการเปลี่ยนมีตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าจะเริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้ขึ้นอยู่กับการเปลี่ยนที่เลือกด้วย [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) ตั้งประเภทก่อน แล้วใช้อินเทอร์เฟซที่เหมาะสมจาก [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--)

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` โดยเรียก [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) ผ่าน [IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

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

ได้. ให้ใช้ [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) เมื่อคุณต้องการระบุระยะเวลาเอฟเฟกต์อย่างแม่นยำ (มิลลิวินาที) หรือใช้ [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) เมื่อหมวดความเร็วที่กำหนดไว้จาก [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) (Slow, Medium, Fast) เพียงพอและไม่มีการกำหนดระยะเวลาที่ชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนโดยอิสระจากหน่วงเวลาเลื่อนอัตโนมัติ

**ฉันสามารถแนบเสียงไปกับการเปลี่ยนและทำให้มันวนซ้ำได้หรือไม่?**

ได้. ให้กำหนดเสียงที่ฝังด้วย [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) ส่งค่า `StartSound` จากการนิยาม [TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) ไปที่ [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) และเปิดใช้งาน [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) ด้วยค่า `true` เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงถัดไปในสไลด์โชว์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) ของงานนำเสนอ แล้วเรียก [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) ด้วยค่าที่เหมือนกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าการเวลาและตัวเลือกเอฟเฟกต์ภายในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันทั่วทั้งสไลด์

**ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งไว้ในสไลด์ปัจจุบันได้อย่างไร?**

เรียก [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) บนผลลัพธ์ของ [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) ของสไลด์ จะได้ค่าจากการนิยาม [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) ค่า `None` หมายถึงไม่มีการใส่เอฟเฟกต์การเปลี่ยนใด ๆ.