---
title: แปลงสไลด์การนำเสนอเป็นภาพใน Java
linktitle: สไลด์เป็นรูปภาพ
type: docs
weight: 35
url: /th/java/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "แปลงสไลด์จาก PPT, PPTX และ ODP เป็นภาพใน Java ด้วย Aspose.Slides—การเรนเดอร์ที่รวดเร็วและคุณภาพสูงพร้อมตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

Aspose.Slides for Java ช่วยให้คุณสามารถแปลงสไลด์การนำเสนอ PowerPoint และ OpenDocument ไปเป็นรูปแบบภาพต่าง ๆ รวมถึง BMP, PNG, JPG (JPEG), GIF และอื่น ๆ ได้อย่างง่ายดาย

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดค่าการแปลงที่ต้องการและเลือกสไลด์ที่ต้องการส่งออกโดยใช้:
    - อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiffoptions/) หรือ
    - อินเทอร์เฟซ [IRenderingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/irenderingoptions/)
2. สร้างภาพสไลด์โดยเรียกเมธอด [getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)

ใน Aspose.Slides for Java, [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) คืออินเทอร์เฟซที่ให้คุณทำงานกับภาพที่กำหนดด้วยข้อมูลพิกเซล คุณสามารถใช้อินเทอร์เฟซนี้เพื่อบันทึกภาพในรูปแบบต่าง ๆ มากมาย (BMP, JPG, PNG เป็นต้น)

## **แปลงสไลด์เป็นบิตแมปและบันทึกภาพเป็น PNG**

คุณสามารถแปลงสไลด์เป็นอ็อบเจ็กต์บิตแมปและใช้โดยตรงในแอปพลิเคชันของคุณ หรือคุณสามารถแปลงสไลด์เป็นบิตแมปแล้วบันทึกภาพเป็น JPEG หรือรูปแบบใด ๆ ที่ต้องการ

ตัวอย่างโค้ดนี้แสดงวิธีแปลงสไลด์แรกของการนำเสนอเป็นอ็อบเจ็กต์บิตแมปแล้วบันทึกภาพเป็นรูปแบบ PNG:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกของการนำเสนอเป็นบิตแมป.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // บันทึกภาพในรูปแบบ PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **แปลงสไลด์เป็นภาพด้วยขนาดที่กำหนดเอง**

คุณอาจต้องการได้ภาพที่มีขนาดเฉพาะ โดยใช้ overload ของเมธอด [getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) คุณสามารถแปลงสไลด์เป็นภาพที่มีความกว้างและความสูงที่กำหนด

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีทำเช่นนั้น:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกของการนำเสนอเป็นบิตแมปด้วยขนาดที่ระบุ.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // บันทึกภาพในรูปแบบ JPEG.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **แปลงสไลด์พร้อมบันทึกย่อและคอมเมนต์เป็นภาพ**

บางสไลด์อาจมีบันทึกย่อและคอมเมนต์

Aspose.Slides มีสองอินเทอร์เฟซ—[ITiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiffoptions/) และ [IRenderingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/irenderingoptions/)—ที่ให้คุณควบคุมการเรนเดอร์สไลด์นำเสนอเป็นภาพ ทั้งสองอินเทอร์เฟซมีเมธอด `setSlidesLayoutOptions` ที่ช่วยกำหนดการเรนเดอร์ของบันทึกย่อและคอมเมนต์บนสไลด์เมื่อแปลงเป็นภาพ

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการสำหรับบันทึกย่อและคอมเมนต์ในภาพที่ได้

ตัวอย่างโค้ดนี้แสดงวิธีแปลงสไลด์ที่มีบันทึกย่อและคอมเมนต์:

```java 
float scaleX = 2;
float scaleY = scaleX;

// โหลดไฟล์การนำเสนอ.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // กำหนดตำแหน่งของบันทึกย่อ.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // กำหนดตำแหน่งของคอมเมนต์.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // กำหนดความกว้างของพื้นที่คอมเมนต์.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // กำหนดสีสำหรับพื้นที่คอมเมนต์.

    // สร้างตัวเลือกการเรนเดอร์.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // แปลงสไลด์แรกของการนำเสนอเป็นภาพ.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // บันทึกภาพในรูปแบบ GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
ในกระบวนการแปลงสไลด์เป็นภาพใด ๆ เมธอด [setNotesPosition](https://reference.aspose.com/slides/th/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) ไม่สามารถใช้ค่า `BottomFull` (เพื่อระบุตำแหน่งของบันทึกย่อ) ได้ เนื่องจากข้อความบันทึกย่ออาจมีขนาดใหญ่เกินไป ทำให้ไม่สามารถพอดีกับขนาดภาพที่กำหนด
{{% /alert %}} 

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiffoptions/) ให้การควบคุมที่ละเอียดขึ้นของภาพ TIFF ที่ได้ โดยให้คุณระบุพารามิเตอร์ต่าง ๆ เช่น ขนาด ความละเอียด พาเลตสี และอื่น ๆ

ตัวอย่างโค้ดนี้แสดงกระบวนการแปลงโดยใช้ตัวเลือก TIFF เพื่อสร้างภาพขาว–ดำที่มีความละเอียด 300 DPI และขนาด 2160 × 2800:

```java 
// โหลดไฟล์การนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // ดึงสไลด์แรกจากการนำเสนอ.
    ISlide slide = presentation.getSlides().get_Item(0);

    // กำหนดค่าการตั้งค่าของภาพ TIFF ขาออก.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // กำหนดขนาดภาพ.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // กำหนดรูปแบบพิกเซล (สีดำและขาว).
    tiffOptions.setDpiX(300);                                        // กำหนดความละเอียดแนวนอน.
    tiffOptions.setDpiY(300);                                        // กำหนดความละเอียดแนวตั้ง.

    // แปลงสไลด์เป็นภาพด้วยตัวเลือกที่ระบุ.
    IImage image = slide.getImage(tiffOptions);

    try {
        // บันทึกภาพในรูปแบบ TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
การสนับสนุน Tiff ไม่ได้รับการรับประกันในเวอร์ชันที่ก่อน JDK 9
{{% /alert %}} 

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

Aspose.Slides ช่วยให้คุณแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นภาพ ได้อย่างมีประสิทธิภาพโดยทำให้การนำเสนอทั้งหมดกลายเป็นชุดของภาพ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นภาพด้วย Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แสดงผลการนำเสนอเป็นภาพสไลด์ต่อสไลด์.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // ควบคุมสไลด์ที่ซ่อนอยู่ (ไม่แสดงผลสไลด์ที่ซ่อนอยู่).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // แปลงสไลด์เป็นภาพ.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // บันทึกภาพในรูปแบบ JPEG.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
} 
```

## **การเรนเดอร์สี Emoji**

{{% alert title="Note" color="warning" %}} 
เพื่อให้การเรนเดอร์สี Emoji ถูกต้องเมื่อแปลงสไลด์นำเสนอเป็นภาพ ฟอนท์ Emoji ที่ใช้ในงานนำเสนอต้องถูกติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากงานนำใช้ **Segoe UI Emoji** แต่ฟอนท์นี้ไม่มีอยู่ Emoji อาจปรากฏเป็นสีเดียวในภาพผลลัพธ์
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์ที่มีแอนิเมชันหรือไม่?**

ไม่, เมธอด `getImage` จะบันทึกเป็นภาพนิ่งของสไลด์เท่านั้น ไม่รวมแอนิเมชัน

**สไลด์ที่ซ่อนอยู่สามารถส่งออกเป็นภาพได้หรือไม่?**

ได้, สไลด์ที่ซ่อนอยู่สามารถประมวลผลได้เช่นเดียวกับสไลด์ปกติ เพียงตรวจสอบให้แน่ใจว่าได้รวมไว้ในลูปการประมวลผล

**สามารถบันทึกภาพพร้อมเงาและเอฟเฟกต์ได้หรือไม่?**

ได้, Aspose.Slides รองรับการเรนเดอร์เงา ความโปร่งแสง และเอฟเฟกต์กราฟิกอื่น ๆ เมื่อบันทึกสไลด์เป็นภาพ