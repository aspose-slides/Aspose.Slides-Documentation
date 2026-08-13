---
title: แปลง PPT และ PPTX เป็น JPG ใน Java
linktitle: PowerPoint เป็น JPG
type: docs
weight: 60
url: /th/java/convert-powerpoint-to-jpg/
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
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint (PPT, PPTX) เป็นภาพ JPG คุณภาพสูงใน Java ด้วย Aspose.Slides for Java โดยใช้ตัวอย่างโค้ดที่เร็วและเชื่อถือได้"
---
## **บทนำ**

การแปลงงานนำเสนอ PowerPoint และ OpenDocument ไปเป็นภาพ JPG ช่วยในการแชร์สไลด์, เพิ่มประสิทธิภาพ, และฝังเนื้อหาในเว็บไซต์หรือแอปพลิเคชัน Aspose.Slides ช่วยให้คุณแปลงไฟล์ PPTX, PPT, และ ODP ไปเป็นภาพ JPEG คุณภาพสูง คู่มือนี้อธิบายวิธีการแปลงที่ต่างกัน

ด้วยคุณลักษณะเหล่านี้ การสร้างตัวดูงานนำเสนอของคุณเองและสร้างภาพย่อสำหรับแต่ละสไลด์ก็ง่ายดาย สิ่งนี้อาจเป็นประโยชน์หากคุณต้องการป้องกันการคัดลอกสไลด์หรือแสดงงานนำเสนอในโหมดอ่านอย่างเดียว Aspose.Slides อนุญาตให้คุณแปลงทั้งงานนำเสนอหรือสไลด์เฉพาะเป็นรูปแบบภาพต่าง ๆ

## **แปลง PowerPoint PPT/PPTX เป็น JPG**

ต่อไปนี้คือขั้นตอนการแปลง PPT/PPTX เป็น JPG:

1. สร้างอินสแตนซ์ของประเภท [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ็อบเจกต์สไลด์ของประเภท [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide) จากคอลเลกชัน [Presentation.getSlides()](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--)  
3. สร้างภาพย่อของแต่ละสไลด์แล้วแปลงเป็น JPG วิธีการ [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide#getImage-float-float-) ถูกใช้เพื่อรับภาพย่อของสไลด์ ซึ่งจะคืนค่าอ็อบเจกต์ [Images](https://reference.aspose.com/slides/th/java/com.aspose.slides/Images) เป็นผลลัพธ์ วิธีการ [getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) ต้องเรียกจากสไลด์ที่ต้องการของประเภท [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide) โดยส่งสเกลของภาพย่อที่ต้องการเข้าไปในเมธอด  
4. หลังจากได้ภาพย่อของสไลด์แล้ว ให้เรียกวิธีการ [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) จากอ็อบเจกต์ภาพย่อ โดยส่งชื่อไฟล์ผลลัพธ์และรูปแบบภาพเข้าไป  

{{% alert color="info" %}}

**Note**: การแปลง PPT/PPTX เป็น JPG แตกต่างจากการแปลงเป็นประเภทอื่นใน Aspose.Slides API สำหรับประเภทอื่น ๆ คุณมักใช้วิธีการ [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) แต่ที่นี่คุณต้องใช้วิธีการ [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImage#save(String formatName, int imageFormat))  

{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // สร้างภาพเต็มสเกล
        IImage slideImage = sld.getImage(1f, 1f);

        // บันทึกภาพลงดิสก์ในรูปแบบ JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **แปลง PowerPoint PPT/PPTX เป็น JPG พร้อมขนาดกำหนดเอง**

เพื่อเปลี่ยนขนาดของภาพย่อและภาพ JPG ที่ได้ คุณสามารถตั้งค่า *ScaleX* และ *ScaleY* โดยส่งค่าเหล่านี้เข้าไปในเมธอด [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide#getImage-float-float-) :

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // กำหนดมิติ
    int desiredX = 1200;
    int desiredY = 800;
    // รับค่าที่สเกลของ X และ Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // สร้างภาพเต็มสเคล
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // บันทึกภาพลงดิสก์ในรูปแบบ JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **แสดงความคิดเห็นเมื่อบันทึกสไลด์เป็นภาพ**

Aspose.Slides for Java มีฟีเจอร์ที่ช่วยให้คุณแสดงความคิดเห็นในสไลด์ของงานนำเสนอเมื่อทำการแปลงสไลด์เหล่านั้นเป็นภาพ ตัวอย่างโค้ด Java ด้านล่างแสดงการทำงานนี้:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Aspose มีแอปเว็บ [FREE Collage web app](https://products.aspose.app/slides/th/collage) ให้ใช้ฟรี โดยใช้บริการออนไลน์นี้คุณสามารถรวมภาพ [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG to PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) ฯลฯ  

โดยใช้หลักการเดียวกันที่อธิบายในบทความนี้ คุณสามารถแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้ สำหรับข้อมูลเพิ่มเติม ดูหน้าต่อไปนี้: แปลง [image to JPG](https://products.aspose.com/slides/th/java/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/java/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/java/conversion/jpg-to-png/); แปลง [PNG to JPG](https://products.aspose.com/slides/th/java/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/java/conversion/png-to-svg/); แปลง [SVG to PNG](https://products.aspose.com/slides/th/java/conversion/svg-to-png/).  

{{% /alert %}}

## **คำถามที่พบบ่อย**

### วิธีนี้รองรับการแปลงเป็นชุดหรือไม่?

ใช่ Aspose.Slides รองรับการแปลงหลายสไลด์เป็น JPG ในการทำงานเดียว

### การแปลงสนับสนุน SmartArt, แผนภูมิ และวัตถุซับซ้อนอื่น ๆ หรือไม่?

ใช่ Aspose.Slides จะเรนเดอร์เนื้อหาทั้งหมดรวมถึง SmartArt, แผนภูมิ, ตาราง, รูปร่าง ฯลฯ อย่างไรก็ตามความแม่นยำของการเรนเดอร์อาจแตกต่างเล็กน้อยเมื่อเทียบกับ PowerPoint โดยเฉพาะเมื่อใช้ฟอนต์ที่กำหนดเองหรือฟอนต์ที่หายไป

### มีข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ที่สามารถประมวลผลได้หรือไม่?

Aspose.Slides เองไม่ได้กำหนดขีดจำกัดที่เข้มงวดเกี่ยวกับจำนวนสไลด์ที่คุณสามารถประมวลผลได้ อย่างไรก็ตามคุณอาจเจอข้อผิดพลาด out‑of‑memory เมื่อต้องทำงานกับงานนำเสนอขนาดใหญ่หรือภาพความละเอียดสูง  

## **ดูเพิ่มเติม**

ดูตัวเลือกอื่น ๆ สำหรับการแปลง PPT/PPTX เป็นภาพ เช่น:

- [PPT/PPTX to SVG conversion](/slides/th/java/render-a-slide-as-an-svg-image/).