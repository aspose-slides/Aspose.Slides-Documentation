---
title: แปลงสไลด์ PowerPoint เป็น PNG ใน Java
linktitle: PowerPoint ไป PNG
type: docs
weight: 30
url: /th/java/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- การนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- บันทึก PPT เป็น PNG
- บันทึก PPTX เป็น PNG
- ส่งออก PPT เป็น PNG
- ส่งออก PPTX เป็น PNG
- Java
- Aspose.Slides
description: "แปลงการนำเสนอ PowerPoint เป็นภาพ PNG คุณภาพสูงอย่างรวดเร็วด้วย Aspose.Slides for Java เพื่อผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงสไลด์พรีเซนเทชันเป็นภาพ PNG โดยใช้ Aspose.Slides for Java คุณสามารถโหลดพรีเซนเทชันในรูปแบบเช่น PPT, PPTX และ ODP, เรนเดอร์แต่ละสไลด์ และบันทึกเป็นไฟล์ PNG แยกกันได้

ตัวอย่างต่อไปนี้แสดงการเรนเดอร์ด้วยสเกลเริ่มต้น, การเพิ่มสเกล, การระบุขนาดเอาต์พุตเป็นพิกเซล, และการเลือกสไตล์การเรนเดอร์แบบไล่ระดับสี

## **แปลง PowerPoint เป็น PNG**

โหลดพรีเซนเทชันด้วยคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) แล้วเข้าถึงสไลด์ผ่านคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) ตัวอย่างจะเรนเดอร์ทุกสไลด์ด้วย [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) โดยไม่ส่งพารามิเตอร์เพื่อสร้างรูปย่อ จากนั้นเรียก [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) พร้อม [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) เพื่อบันทึกสไลด์ที่เรนเดอร์เป็นภาพ PNG

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
การเรียกใช้ overload ของ [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) ที่ไม่มีพารามิเตอร์จะเรนเดอร์ด้วยสเกล 0.2 ตัวอย่างเช่น สไลด์ขนาด 720 × 540 พอยท์ จะสร้างรูปย่อขนาด 144 × 108 พิกเซล เพื่อควบคุมขนาดเอาต์พุต ให้ใช้ overload ที่รับสเกลแฟกเตอร์หรือขนาดภาพที่ระบุชัดเจนตามด้านล่าง
{{% /alert %}}

## **แปลง PowerPoint เป็น PNG ด้วยขนาดกำหนดเอง**

ส่งแฟกเตอร์สเกลแนวนอนและแนวตั้งให้กับ [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) เพื่อควบคุมขนาดที่เรนเดอร์ ในตัวอย่างนี้แฟกเตอร์ทั้งสองเป็น 2 ดังนั้นสไลด์ขนาด 720 × 540 พอยท์ จะสร้างภาพขนาด 1440 × 1080 พิกเซล แฟกเตอร์สเกลเท่ากันจะรักษาอัตราส่วนของสไลด์ไว้ แต่ละภาพจะถูกบันทึกในรูปแบบ PNG ด้วย [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PNG ด้วยขนาดกำหนดเองเป็นพิกเซล**

เพื่อระบุขนาดเอาต์พุตเป็นพิกเซล ให้ส่งค่า Dimension ให้กับ [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) แทนการใช้สเกลแฟกเตอร์ ตัวอย่างนี้เรนเดอร์ทุกสไลด์ที่ 960 × 720 พิกเซลและบันทึกผลด้วย [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) เลือกขนาดที่ตรงกับอัตราส่วนของสไลด์เพื่อหลีกเลี่ยงการยืดภาพ

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **เลือกสไตล์การเรนเดอร์แบบไล่ระดับสี**

สมมติว่ามีสไลด์ที่มีการเติมสีไล่ระดับ แต่การแปลงเป็น PNG ที่ส่งออกออกมาดูสีอ่อนลงหรือแตกต่างจากที่เห็นใน PowerPoint คุณสามารถใช้เมธอด [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) ที่สืบทอดจาก [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) เพื่อเลือกวิธีการเรนเดอร์ไล่ระดับสี

ดาวน์โหลดไฟล์ [gradient-styles.pptx](gradient-styles.pptx) แล้ววางไว้ในโฟลเดอร์ทำงานของแอปพลิเคชัน สไลด์แรกของไฟล์มีไล่ระดับสีเชิงเส้นสองแบบ: สีฟ้าเทอร์ครูมไปสีส้มที่ด้านบนและสีฟ้าไปสีเหลืองที่ด้านล่าง แต่ละไล่ระดับมีจุดสีสองจุดที่ 0% และ 100%

ตัวอย่างต่อไปนี้โหลดพรีเซนเทชันนี้และเรนเดอร์สไลด์แรกเดียวกันในสองโหมดด้วย [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

รูปด้านล่างแสดงผลลัพธ์จากสไลด์เดียวกัน โดยมีไล่ระดับสีทั้งสองแบบในแต่ละภาพ:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

ในตัวอย่างนี้ `Default` ให้สีกลางที่อ่อนกว่า ในขณะที่ `PowerPointUI` ให้สีกลางที่เข้มกว่า ความแตกต่างนี้ขึ้นอยู่กับสีและจุดสีในไล่ระดับ

เลือก `Default` เมื่อผลลัพธ์มาตรฐานของ Aspose.Slides ตอบโจทย์คุณ ใช้ `PowerPointUI` เมื่อต้องการให้ผลลัพธ์ตรงกับการแสดงผลใน PowerPoint เปรียบเทียบผลลัพธ์ทั้งสองกับสิ่งที่ต้องการ; ไม่มีโหมดใดที่ดีกว่ากันโดยทั่วไป

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกรูปทรงเฉพาะ เช่น แผนภูมิหรือรูปภาพ แทนการส่งออกทั้งสไลด์ได้อย่างไร?**

Aspose.Slides รองรับ [การสร้างรูปย่อสำหรับรูปทรงแต่ละรูป](/slides/th/java/create-shape-thumbnails/) ซึ่งคุณสามารถเรนเดอร์รูปทรงเป็นภาพ PNG ได้

**การแปลงแบบขนานทำงานบนเซิร์ฟเวอร์ได้หรือไม่?**

ได้ ใช้อินสแตนซ์พรีเซนเทชันแยกกันสำหรับแต่ละเธรดหรือแต่ละกระบวนการ; [ห้ามแชร์อินสแตนซ์เดียวกันระหว่างเธรด](/slides/th/java/multithreading/)

**ข้อจำกัดของรุ่นประเมินผลเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**

โหมดประเมินผลจะใส่น้ำโค้ดบนภาพที่ส่งออกและใช้ [ข้อจำกัดอื่น ๆ](/slides/th/java/licensing/) จนกว่าจะมีการใช้ลิขสิทธิ์.