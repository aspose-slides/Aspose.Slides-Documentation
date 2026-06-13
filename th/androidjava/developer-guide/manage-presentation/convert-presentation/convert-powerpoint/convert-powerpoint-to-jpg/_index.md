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
description: "แปลงสไลด์ PowerPoint (PPT, PPTX) เป็นภาพ JPG คุณภาพสูงใน Java ด้วย Aspose.Slides สำหรับ Android โดยใช้ตัวอย่างโค้ดที่เร็วและเชื่อถือได้."
---
## **บทนำ**

การแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ JPG ช่วยในการแชร์สไลด์, เพิ่มประสิทธิภาพการทำงาน, และฝังเนื้อหาเข้าในเว็บไซต์หรือแอปพลิเคชัน Aspose.Slides for Android via Java ช่วยให้คุณแปลงไฟล์ PPTX, PPT และ ODP เป็นภาพ JPEG คุณภาพสูง คู่มือนี้อธิบายวิธีการแปลงต่างๆ

ด้วยคุณลักษณะเหล่านี้ จึงง่ายต่อการสร้างตัวดูงานนำเสนอของคุณเองและสร้างภาพย่อสำหรับทุกสไลด์ ซึ่งอาจเป็นประโยชน์หากคุณต้องการปกป้องสไลด์จากการคัดลอกหรือแสดงงานนำเสนอในโหมดอ่านอย่างเดียว Aspose.Slides สามารถแปลงทั้งงานนำเสนอทั้งหมดหรือสไลด์เฉพาะเป็นรูปแบบภาพได้

## **แปลงสไลด์งานนำเสนอเป็นภาพ JPG**

ขั้นตอนในการแปลงไฟล์ PPT, PPTX หรือ ODP เป็น JPG มีดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
1. รับอ็อบเจกต์สไลด์ประเภท [ISlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) จากคอลเลกชันที่คืนค่ามาโดยเมธอด [Presentation.getSlides()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlides--) 
1. สร้างภาพของสไลด์โดยใช้เมธอด [ISlide.getImage(float, float)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getImage-float-float-) 
1. เรียกเมธอด [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) บนอ็อบเจกต์ภาพ ส่งชื่อไฟล์เอาต์พุตและรูปแบบภาพเป็นอาร์กิวเมนต์

{{% alert color="primary" %}} 
**หมายเหตุ:** การแปลง PPT, PPTX หรือ ODP เป็น JPG แตกต่างจากการแปลงเป็นรูปแบบอื่นใน Aspose.Slides Android via Java API สำหรับรูปแบบอื่นโดยทั่วไปคุณจะใช้เมธอด [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) อย่างไรก็ตามสำหรับการแปลงเป็น JPG คุณต้องใช้เมธอด [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 
{{% /alert %}} 

```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // สร้างภาพสไลด์โดยใช้สเกลที่ระบุ.
        IImage slideImage = slide.getImage(scaleX, scaleY);

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

## **แปลงสไลด์เป็น JPG พร้อมขนาดที่กำหนดเอง**

หากต้องการเปลี่ยนขนาดของภาพ JPG ที่ได้ คุณสามารถกำหนดขนาดภาพโดยส่งค่าเข้าเมธอด [ISlide.getImage(Size)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) วิธีนี้ช่วยให้คุณสร้างภาพที่มีความกว้างและความสูงตามที่ต้องการ เพื่อให้ผลลัพธ์ตรงตามความต้องการของคุณในเรื่องความละเอียดและอัตราส่วนภาพ ความยืดหยุ่นนี้เป็นประโยชน์อย่างยิ่งเมื่อสร้างภาพสำหรับเว็บแอปพลิเคชัน, รายงาน หรือเอกสารที่ต้องการขนาดภาพที่แน่นอน

```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // สร้างภาพสไลด์โดยใช้ขนาดที่ระบุ.
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

## **เรนเดอร์คอมเมนต์เมื่อบันทึกสไลด์เป็นภาพ**

Aspose.Slides for Android via Java มีฟีเจอร์ที่ทำให้คุณสามารถเรนเดอร์คอมเมนต์บนสไลด์ของงานนำเสนอเมื่อต้องการแปลงเป็นภาพ JPG ฟีเจอร์นี้มีประโยชน์สำหรับการเก็บรักษาโน้ต, ข้อเสนอแนะ หรือการสนทนาที่ผู้ร่วมงานเพิ่มใน PowerPoint ด้วยการเปิดใช้งานตัวเลือกนี้ คุณจะทำให้คอมเมนต์ปรากฏในภาพที่สร้างขึ้น ทำให้การตรวจสอบและแชร์ข้อเสนอแนะง่ายขึ้นโดยไม่ต้องเปิดไฟล์งานนำเสนอเดิม

สมมติว่าเรามีไฟล์งานนำเสนอ “sample.pptx” ที่มีสไลด์หนึ่งที่มีคอมเมนต์อยู่:

![สไลด์ที่มีความคิดเห็น](slide_with_comments.png)

โค้ด Java ต่อไปนี้แปลงสไลด์เป็นภาพ JPG พร้อมคอมเมนต์:

```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

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

![ภาพ JPG ที่มีความคิดเห็น](image_with_comments.png)

## **ดูเพิ่มเติม**

ดูตัวเลือกอื่นๆ สำหรับการแปลง PPT, PPTX หรือ ODP เป็นภาพ เช่น:

- [แปลง PowerPoint เป็น GIF](/slides/th/androidjava/convert-powerpoint-to-animated-gif/)
- [แปลง PowerPoint เป็น PNG](/slides/th/androidjava/convert-powerpoint-to-png/)
- [แปลง PowerPoint เป็น TIFF](/slides/th/androidjava/convert-powerpoint-to-tiff/)
- [แปลง PowerPoint เป็น SVG](/slides/th/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
เพื่อดูว่า Aspose.Slides แปลงงานนำเสนอ PowerPoint เป็นภาพ JPG อย่างไร ลองใช้เครื่องแปลงออนไลน์ฟรีเหล่านี้: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/th/conversion/pptx-to-jpg) และ [PPT to JPG](https://products.aspose.app/slides/th/conversion/ppt-to-jpg) 
{{% /alert %}} 

![ตัวแปลง PPTX เป็น JPG ออนไลน์ฟรี](ppt-to-jpg.png)

{{% alert title="เคล็ดลับ" color="primary" %}}

Aspose มีแอปเว็บ [FREE Collage](https://products.aspose.app/slides/th/collage) ให้ใช้งาน ฟรี คุณสามารถรวมภาพ [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG to PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) ฯลฯ 

โดยใช้หลักการเดียวกันที่อธิบายในบทความนี้ คุณสามารถแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง สำหรับข้อมูลเพิ่มเติม ดูหน้าเหล่านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/java/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/java/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/java/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/java/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/java/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/java/conversion/svg-to-png/) 
{{% /alert %}}

## **คำถามที่พบบ่อย**

**วิธีนี้รองรับการแปลงเป็นชุดหรือไม่?**

ใช่, Aspose.Slides รองรับการแปลงหลายสไลด์เป็น JPG ในการดำเนินการเดียว

**การแปลงสนับสนุน SmartArt, แผนภูมิและวัตถุซับซ้อนอื่นๆ หรือไม่?**

ใช่, Aspose.Slides เรนเดอร์เนื้อหาทั้งหมดรวมถึง SmartArt, แผนภูมิ, ตาราง, รูปร่าง ฯลฯ อย่างไรก็ตามความแม่นยำในการเรนเดอร์อาจแตกต่างเล็กน้อยจาก PowerPoint โดยเฉพาะเมื่อใช้ฟอนต์ที่กำหนดเองหรือฟอนต์ที่ขาดหายไป

**มีข้อจำกัดเรื่องจำนวนสไลด์ที่สามารถประมวลผลได้หรือไม่?**

Aspose.Slides เองไม่ได้กำหนดขีดจำกัดที่เคร่งครัดเกี่ยวกับจำนวนสไลด์ที่คุณสามารถประมวลผลได้ อย่างไรก็ตามคุณอาจเจอข้อผิดพลาด out-of-memory เมื่อทำงานกับงานนำเสนอขนาดใหญ่หรือภาพความละเอียดสูง