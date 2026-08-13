---
title: แปลง PPT และ PPTX เป็น JPG บน Android
linktitle: PowerPoint เป็น JPG
type: docs
weight: 60
url: /th/androidjava/convert-powerpoint-to-jpg/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น JPG
- งานนำเสนอเป็น JPG
- สไลด์เป็น JPG
- PPT เป็น JPG
- PPTX เป็น JPG
- บันทึก PowerPoint เป็น JPG
- บันทึกงานนำเสนอเป็น JPG
- บันทึกสไลด์เป็น JPG
- บันทึก PPT เป็น JPG
- บันทึก PPTX เป็น JPG
- ส่งออก PPT เป็น JPG
- ส่งออก PPTX เป็น JPG
- Android
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint (PPT, PPTX) เป็นภาพ JPG คุณภาพสูงใน Java ด้วย Aspose.Slides สำหรับ Android โดยใช้ตัวอย่างโค้ดที่เร็วและเชื่อถือได้"
---
## **บทนำ**

การแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ JPG ช่วยในด้านการแชร์สไลด์, ปรับประสิทธิภาพ, และฝังเนื้อหาในเว็บไซต์หรือแอปพลิเคชัน Aspose.Slides สำหรับ Android ผ่าน Java ช่วยให้คุณแปลงไฟล์ PPTX, PPT และ ODP เป็นภาพ JPEG คุณภาพสูง คู่มือนี้อธิบายวิธีต่าง ๆ สำหรับการแปลง

ด้วยคุณสมบัติเหล่านี้ การสร้างตัวดูงานนำเสนอของคุณเองและสร้างภาพขนาดย่อสำหรับแต่ละสไลด์จึงทำได้ง่าย อาจมีประโยชน์หากคุณต้องการปกป้องสไลด์จากการคัดลอกหรือแสดงงานนำเสนอในโหมดอ่านอย่างเดียว Aspose.Slides อนุญาตให้คุณแปลงงานนำเสนอทั้งหมดหรือสไลด์เฉพาะเป็นรูปแบบภาพ

## **แปลงสไลด์งานนำเสนอเป็นภาพ JPG**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
1. รับอ็อบเจกต์สไลด์ชนิด [ISlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) จากคอลเลกชันที่คืนค่าจากเมธอด [Presentation.getSlides()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlides--)
1. สร้างภาพของสไลด์ด้วยเมธอด [ISlide.getImage(float, float)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getImage-float-float-)
1. เรียกเมธอด [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) บนวัตถุภาพ โดยส่งชื่อไฟล์ผลลัพธ์และรูปแบบภาพเป็นอาร์กิวเมนต์

{{% alert color="info" %}} 
**หมายเหตุ:** การแปลง PPT, PPTX หรือ ODP เป็น JPG แตกต่างจากการแปลงเป็นรูปแบบอื่นใน Aspose.Slides Android ผ่าน Java API สำหรับรูปแบบอื่น ๆ คุณมักใช้เมธอด [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) อย่างไรก็ตามสำหรับการแปลงเป็น JPG คุณต้องใช้เมธอด [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)
{{% /alert %}} 

```java
import com.aspose.slides.*;

int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // สร้างภาพสไลด์ด้วยสเกลที่ระบุ
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // บันทึกภาพลงดิสก์ในรูปแบบ JPEG
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **แปลงสไลด์เป็น JPG ด้วยขนาดที่กำหนดเอง**

หากต้องการเปลี่ยนขนาดของภาพ JPG ที่ได้ คุณสามารถตั้งขนาดภาพโดยส่งค่าเข้าเมธอด [ISlide.getImage(Size)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) นี้ทำให้คุณสร้างภาพที่มีค่าความกว้างและความสูงเฉพาะ เพื่อให้ผลลัพธ์ตรงตามความต้องการของคุณในเรื่องความละเอียดและอัตราส่วน ภาพลักษณ์นี้เป็นประโยชน์เป็นพิเศษเมื่อสร้างภาพสำหรับแอปพลิเคชันเว็บ, รายงาน หรือเอกสาร ที่ต้องการขนาดภาพที่แม่นยำ

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // สร้างภาพสไลด์ด้วยขนาดที่ระบุ.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // บันทึกภาพลงดิสก์ในรูปแบบ JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **แสดงคอมเมนต์เมื่อบันทึกสไลด์เป็นภาพ**

Aspose.Slides สำหรับ Android ผ่าน Java มีฟีเจอร์ที่ให้คุณแสดงคอมเมนต์บนสไลด์ของงานนำเสนอเมื่อแปลงเป็นภาพ JPG ฟังก์ชันนี้มีประโยชน์ในการรักษาการคอมเมนต์, ความคิดเห็น หรือการสนทนาที่ผู้ร่วมงานเพิ่มใน PowerPoint ด้วยการเปิดใช้งานตัวเลือกนี้ คุณจะทำให้คอมเมนต์ปรากฏในภาพที่สร้างขึ้น ทำให้ตรวจสอบและแชร์ข้อเสนอแนะได้ง่ายกว่าโดยไม่ต้องเปิดไฟล์งานนำเสนอเดิม

สมมติว่าเรามีไฟล์งานนำเสนอ "sample.pptx" ที่มีสไลด์ที่มีคอมเมนต์:

![สไลด์ที่มีคอมเมนต์](slide_with_comments.png)

โค้ด Java ต่อไปนี้จะแปลงสไลด์เป็นภาพ JPG พร้อมคงคอมเมนต์ไว้:

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // แปลงสไลด์แรกเป็นภาพ.
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ภาพ JPG ที่มีคอมเมนต์](image_with_comments.png)

## **ดูเพิ่มเติม**

ดูตัวเลือกอื่น ๆ สำหรับการแปลง PPT, PPTX หรือ ODP เป็นภาพ เช่น:

- [แปลง PowerPoint เป็น GIF](/slides/th/androidjava/convert-powerpoint-to-animated-gif/)
- [แปลง PowerPoint เป็น PNG](/slides/th/androidjava/convert-powerpoint-to-png/)
- [แปลง PowerPoint เป็น TIFF](/slides/th/androidjava/convert-powerpoint-to-tiff/)
- [แปลง PowerPoint เป็น SVG](/slides/th/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
เพื่อดูว่า Aspose.Slides แปลงงานนำเสนอ PowerPoint เป็นภาพ JPG อย่างไร ให้ลองใช้เครื่องแปลงออนไลน์ฟรีเหล่านี้: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/th/conversion/pptx-to-jpg) และ [PPT to JPG](https://products.aspose.app/slides/th/conversion/ppt-to-jpg). 
{{% /alert %}} 

![ตัวแปลง PPTX เป็น JPG ออนไลน์ฟรี](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose มีแอปเว็บ [FREE Collage web app](https://products.aspose.app/slides/th/collage). ด้วยบริการออนไลน์นี้ คุณสามารถผสานรูปภาพ [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG to PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid), เป็นต้น

โดยใช้หลักการเดียวกันที่อธิบายในบทความนี้ คุณสามารถแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง สำหรับข้อมูลเพิ่มเติม ดูหน้าเหล่านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/java/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/java/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/java/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/java/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/java/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/java/conversion/svg-to-png/).

{{% /alert %}}

## **คำถามที่พบบ่อย**

### วิธีนี้รองรับการแปลงเป็นชุดหรือไม่?

ใช่, Aspose.Slides รองรับการแปลงหลายสไลด์เป็น JPG ในการดำเนินการเดียว

### การแปลงรองรับ SmartArt, แผนภูมิ, และวัตถุซับซ้อนอื่น ๆ หรือไม่?

ใช่, Aspose.Slides เรนเดอร์เนื้อหาทั้งหมดรวมถึง SmartArt, แผนภูมิ, ตาราง, รูปร่าง, และอื่น ๆ อย่างไรก็ตาม ความแม่นยำของการเรนเดอร์อาจแตกต่างเล็กน้อยเมื่อเทียบกับ PowerPoint โดยเฉพาะเมื่อใช้ฟอนต์ที่กำหนดเองหรือฟอนต์ที่หายไป

### มีข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ที่สามารถประมวลผลได้หรือไม่?

Aspose.Slides เองไม่ได้กำหนดข้อจำกัดที่เข้มงวดเกี่ยวกับจำนวนสไลด์ที่คุณสามารถประมวลผลได้ อย่างไรก็ตาม คุณอาจพบข้อผิดพลาด out-of-memory เมื่อทำงานกับงานนำเสนอขนาดใหญ่หรือภาพความละเอียดสูง