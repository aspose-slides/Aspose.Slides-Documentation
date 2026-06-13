---
title: แปลง PPT และ PPTX เป็น JPG ด้วย Java
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
description: แปลงสไลด์ PowerPoint (PPT, PPTX) เป็นภาพ JPG คุณภาพสูงใน Java ด้วย Aspose.Slides for Java โดยใช้ตัวอย่างโค้ดที่เร็วและเชื่อถือได้
---
## **บทนำ**

การแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นรูปภาพ JPG ช่วยในเรื่องการแชร์สไลด์, การเพิ่มประสิทธิภาพ, และการฝังเนื้อหาในเว็บไซต์หรือแอปพลิเคชัน Aspose.Slides ช่วยให้คุณแปลงไฟล์ PPTX, PPT, และ ODP ให้เป็นภาพ JPEG คุณภาพสูง คู่มือนี้อธิบายวิธีการแปลงที่ต่างกัน

ด้วยคุณลักษณะเหล่านี้ การสร้างผู้ชมงานนำเสนอของคุณเองและสร้างรูปย่อสำหรับแต่ละสไลด์ทำได้ง่าย อาจเป็นประโยชน์หากคุณต้องการป้องกันการคัดลอกสไลด์หรือแสดงงานนำเสนอในโหมดอ่านอย่างเดียว Aspose.Slides ให้คุณแปลงงานนำเสนอทั้งหมดหรือสไลด์หนึ่งสไลด์เป็นรูปภาพได้

## **แปลง PowerPoint PPT/PPTX เป็น JPG**

1. สร้างอินสแตนซ์ของประเภท [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
2. รับอ็อบเจกต์สไลด์ของประเภท [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide) จากคอลเลกชัน [Presentation.getSlides()](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--)
3. สร้างรูปย่อของแต่ละสไลด์แล้วแปลงเป็น JPG. [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide#getImage-float-float-) ใช้เพื่อรับรูปย่อของสไลด์, จะคืนค่าอ็อบเจกต์ [Images](https://reference.aspose.com/slides/th/java/com.aspose.slides/Images) เป็นผลลัพธ์. วิธี [getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) ต้องถูกเรียกจากสไลด์ที่ต้องการของประเภท [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide), ค่าตามสเกลของรูปย่อที่ได้จะถูกส่งเข้าเมธอด.
4. หลังจากได้รูปย่อของสไลด์แล้ว, เรียกเมธอด [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) จากอ็อบเจกต์รูปย่อ. ส่งชื่อไฟล์ผลลัพธ์และรูปแบบภาพเข้าเมธอดนั้น.

{{% alert color="primary" %}}
**หมายเหตุ**: การแปลง PPT/PPTX เป็น JPG แตกต่างจากการแปลงเป็นประเภทอื่นใน Aspose.Slides API สำหรับประเภทอื่นโดยทั่วไปคุณใช้เมธอด [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) แต่ที่นี่คุณต้องใช้เมธอด [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImage#save(String formatName, int imageFormat))
{{% /alert %}}

```java
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
## **แปลง PowerPoint PPT/PPTX เป็น JPG ด้วยมิติที่กำหนดเอง**

เพื่อเปลี่ยนมิติของรูปย่อและภาพ JPG ที่ได้, คุณสามารถตั้งค่า *ScaleX* และ *ScaleY* โดยส่งค่าเหล่านี้เข้าเมธอด [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlide#getImage-float-float-)

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // กำหนดมิติ
    int desiredX = 1200;
    int desiredY = 800;
    // รับค่าการสเกลของ X และ Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // สร้างภาพเต็มสเกล
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
## **เรนเดอร์คอมเมนต์เมื่อบันทึกสไลด์เป็นภาพ**

Aspose.Slides for Java มีฟีเจอร์ที่ช่วยให้คุณเรนเดอร์คอมเมนต์ในสไลด์ของงานนำเสนอเมื่อทำการแปลงสไลด์เหล่านั้นเป็นภาพ โค้ด Java นี้แสดงการทำงาน:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

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

{{% alert title="Tip" color="primary" %}}
Aspose มีแอปเว็บ Collage ฟรี (https://products.aspose.app/slides/th/collage). ใช้บริการออนไลน์นี้คุณสามารถรวมภาพ [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG to PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid), เป็นต้น

โดยใช้หลักการเดียวกันที่อธิบายในบทความนี้ คุณสามารถแปลงภาพจากฟอร์แมตหนึ่งเป็นอีกฟอร์แมตหนึ่ง สำหรับข้อมูลเพิ่มเติม ดูหน้าเหล่านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/java/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/java/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/java/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/java/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/java/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/java/conversion/svg-to-png/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**วิธีนี้รองรับการแปลงแบบชุดหรือไม่?**

ใช่, Aspose.Slides รองรับการแปลงหลายสไลด์เป็น JPG ในการทำงานเดียว

**การแปลงรองรับ SmartArt, แผนภูมิ, และวัตถุซับซ้อนอื่น ๆ หรือไม่?**

ใช่, Aspose.Slides เรนเดอร์เนื้อหาทั้งหมด รวมถึง SmartArt, แผนภูมิ, ตาราง, รูปร่าง ฯลฯ อย่างไรก็ตาม ความแม่นยำของการเรนเดอร์อาจแตกต่างเล็กน้อยเมื่อเทียบกับ PowerPoint โดยเฉพาะเมื่อใช้ฟอนต์ที่กำหนดเองหรือฟอนต์ที่หายไป

**มีข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ที่สามารถประมวลผลได้หรือไม่?**

Aspose.Slides เองไม่ได้กำหนดข้อจำกัดที่เข้มงวดเกี่ยวกับจำนวนสไลด์ที่คุณสามารถประมวลผลได้ อย่างไรก็ตาม คุณอาจเจอข้อผิดพลาด out-of-memory เมื่อต้องทำงานกับงานนำเสนอขนาดใหญ่หรือภาพความละเอียดสูง

## **ดูเพิ่มเติม**

ดูตัวเลือกอื่น ๆ เพื่อแปลง PPT/PPTX เป็นภาพ เช่น:

- [การแปลง PPT/PPTX เป็น SVG](/slides/th/java/render-a-slide-as-an-svg-image/)