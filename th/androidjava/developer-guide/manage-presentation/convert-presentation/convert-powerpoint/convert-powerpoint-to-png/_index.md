---
title: แปลงสไลด์ PowerPoint เป็น PNG บน Android
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/androidjava/convert-powerpoint-to-png/
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
- Android
- Java
- Aspose.Slides
description: "แปลงการนำเสนอ PowerPoint เป็นภาพ PNG คุณภาพสูงอย่างรวดเร็วด้วย Aspose.Slides สำหรับ Android ผ่าน Java เพื่อให้ได้ผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงสไลด์การนำเสนอเป็นภาพ PNG โดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java คุณสามารถโหลดการนำเสนอในรูปแบบต่าง ๆ เช่น PPT, PPTX, และ ODP เรนเดอร์แต่ละสไลด์และบันทึกเป็นไฟล์ PNG แยกกัน

ตัวอย่างด้านล่างแสดงการเรนเดอร์ด้วยสเกลเริ่มต้น การเพิ่มสเกล การกำหนดขนาดผลลัพธ์เป็นพิกเซล และการเลือกสไตล์การเรนเดอร์แบบไล่สี

## **แปลง PowerPoint เป็น PNG**

โหลดการนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) และเข้าถึงสไลด์ผ่านคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) ตัวอย่างนี้เรนเดอร์แต่ละสไลด์ด้วย [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) โดยไม่มีพารามิเตอร์เพื่อสร้างรูปย่อ จากนั้นเรียกใช้ [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) พร้อมกับ [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) เพื่อบันทึกสไลด์ที่เรนเดอร์แต่ละอันเป็นภาพ PNG

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
เมธอด overload ของ [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) ที่ไม่มีพารามิเตอร์จะเรนเดอร์ด้วยสเกล 0.2 ตัวอย่างเช่น สไลด์ที่มีขนาด 720 × 540 จุดจะสร้างรูปย่อขนาด 144 × 108 พิกเซล เพื่อควบคุมขนาดผลลัพธ์ ให้ใช้ overload ที่รับค่า scale factor หรือขนาดภาพที่ระบุตามด้านล่าง
{{% /alert %}}

## **แปลง PowerPoint เป็น PNG ด้วยขนาดกำหนดเอง**

ส่งค่า scale factor แนวนอนและแนวตั้งไปยัง [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) เพื่อควบคุมขนาดที่เรนเดอร์ ในตัวอย่างนี้ทั้งสองค่ามีค่าเป็น 2 ดังนั้นสไลด์ที่มีขนาด 720 × 540 จุดจะได้ภาพขนาด 1440 × 1080 พิกเซล ค่า scale ที่เท่ากันจะรักษาสัดส่วนของสไลด์แต่ละภาพจะถูกบันทึกเป็นรูปแบบ PNG ด้วย [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)

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

## **แปลง PowerPoint เป็น PNG ด้วยขนาดกำหนดเอง**

เพื่อระบุขนาดผลลัพธ์เป็นพิกเซล ให้ส่งขนาดไปยัง [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) แทนการใช้ scale factor ตัวอย่างนี้เรนเดอร์แต่ละสไลด์ที่ 960 × 720 พิกเซลและบันทึกผลลัพธ์ด้วย [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) เลือกขนาดที่ตรงกับสัดส่วนของสไลด์เพื่อหลีกเลี่ยงการยืดภาพ

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

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

## **เลือกสไตล์การเรนเดอร์แบบไล่สี**

สมมติว่ามีสไลด์ที่มีการเติมไล่สี แต่การเปลี่ยนแปลงสีใน PNG ที่ส่งออกมาดูอ่อนลงหรือแตกต่างจากที่คุณเห็นใน PowerPoint คุณสามารถใช้เมธอด [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) ที่สืบทอดจาก [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) เพื่อเลือกวิธีการเรนเดอร์ไล่สี

ดาวน์โหลดไฟล์ [gradient-styles.pptx](gradient-styles.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอป ไฟล์นี้สไลด์แรกประกอบด้วยไล่สีเชิงเส้นสองแบบ: จากสีฟ้าเขียวมะนาว (cyan) ไปสีส้มที่ด้านบนและจากสีน้ำเงินไปสีเหลืองที่ด้านล่าง แต่ละไล่สีมีจุดหยุดสองจุดที่ 0% และ 100%

ตัวอย่างต่อไปนี้โหลดการนำเสนอนี้และเรนเดอร์สไลด์แรกเดียวกันในทั้งสองโหมดโดยใช้ [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)

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

ภาพด้านล่างแสดงผลลัพธ์จากสไลด์เดียวกัน โดยแต่ละภาพมีไล่สีทั้งสองแบบ:

| Default | PowerPointUI |
| --- | --- |
| ![ไล่สีจากสีฟ้าเขียวมะนาวไปสีส้มและจากสีน้ำเงินไปสีเหลืองที่เรนเดอร์ด้วย Default](gradient-Default.png) | ![ไล่สีเดียวกันที่เรนเดอร์ด้วย PowerPointUI](gradient-PowerPointUI.png) |

ในตัวอย่างนี้ `Default` ให้สีกลางที่อ่อนกว่า ในขณะที่ `PowerPointUI` ให้สีกลางที่เข้มกว่า ความแตกต่างขึ้นอยู่กับสีและจุดหยุดในไล่สี

เลือก `Default` เมื่อผลลัพธ์มาตรฐานของ Aspose.Slides ตอบโจทย์ของคุณ ลองใช้ `PowerPointUI` เมื่อคุณต้องการให้รูปลักษณ์ตรงกับ PowerPoint เปรียบเทียบผลลัพธ์ทั้งสองกับผลลัพธ์ที่ต้องการของคุณ; ไม่มีโหมดใดที่ดีเหนือกันในทุกกรณี

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกรูปทรงเฉพาะ เช่น แผนภูมิหรือรูปภาพ แทนการส่งออกร่างทั้งหมดได้อย่างไร?**

Aspose.Slides รองรับการ [สร้างภาพย่อสำหรับรูปทรงแต่ละรายการ](/slides/th/androidjava/create-shape-thumbnails/) ซึ่งทำให้คุณสามารถเรนเดอร์รูปทรงเป็นภาพ PNG

**การแปลงแบบขนานได้รับการสนับสนุนบนเซิร์ฟเวอร์หรือไม่?**

ใช่ ใช้อินสแตนซ์ Presentation แยกสำหรับแต่ละเธรดหรือโพรเซส; [ห้ามแชร์อินสแตนซ์เดียวกันระหว่างเธรด](/slides/th/androidjava/multithreading/)

**ข้อจำกัดของโหมดประเมินผลเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**

โหมดประเมินผลจะใส่ลายน้ำลงบนภาพผลลัพธ์และใช้ [ข้อจำกัดอื่น ๆ](/slides/th/androidjava/licensing/) จนกว่าจะมีการใช้ใบอนุญาต