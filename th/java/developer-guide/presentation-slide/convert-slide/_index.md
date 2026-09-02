---
title: แปลงสไลด์การนำเสนอเป็นภาพใน Java
linktitle: สไลด์เป็นภาพ
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
- สไลด์เป็นบิทแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "แปลงสไลด์จาก PPT, PPTX และ ODP เป็นภาพใน Java ด้วย Aspose.Slides—เรนเดอร์รวดเร็ว คุณภาพสูง พร้อมตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

Aspose.Slides for Java ช่วยให้คุณง่ายต่อการแปลงสไลด์การนำเสนอ PowerPoint และ OpenDocument ไปเป็นรูปแบบภาพต่าง ๆ รวมถึง BMP, PNG, JPG (JPEG), GIF และอื่น ๆ

เพื่อแปลงสไลด์เป็นรูปภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดการตั้งค่าการแปลงที่ต้องการและเลือกสไลด์ที่คุณต้องการส่งออกโดยใช้:
    - อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiffoptions/) หรือ
    - อินเทอร์เฟซ [IRenderingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/irenderingoptions/) 
2. สร้างภาพสไลด์โดยเรียกใช้เมธอด [getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)

ใน Aspose.Slides for Java, อินเทอร์เฟซ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) คืออินเทอร์เฟซที่ให้คุณทำงานกับภาพที่กำหนดโดยข้อมูลพิกเซล คุณสามารถใช้อินเทอร์เฟซนี้เพื่อบันทึกภาพในรูปแบบต่าง ๆ อย่างกว้างขวาง (BMP, JPG, PNG ฯลฯ)

## **แปลงสไลด์เป็นบิทแมพและบันทึกภาพในรูปแบบ PNG**

คุณสามารถแปลงสไลด์เป็นวัตถุบิทแมพและใช้โดยตรงในแอปพลิเคชันของคุณ หรือคุณสามารถแปลงสไลด์เป็นบิทแมพและจากนั้นบันทึกภาพเป็น JPEG หรือรูปแบบอื่นที่ต้องการ

โค้ดนี้แสดงวิธีการแปลงสไลด์แรกของงานนำเสนอเป็นวัตถุบิทแมพและจากนั้นบันทึกภาพในรูปแบบ PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในงานนำเสนอเป็นบิทแมพ.
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

คุณอาจต้องการภาพที่มีขนาดเฉพาะ โดยใช้การ overload จากเมธอด [getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), คุณสามารถแปลงสไลด์เป็นภาพที่มีมิติที่กำหนด (ความกว้างและความสูง) ได้

ตัวอย่างโค้ดนี้แสดงวิธีทำเช่นนั้น:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในงานนำเสนอเป็นบิทแมพด้วยขนาดที่ระบุ.
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

## **แปลงสไลด์ที่มีโน้ตและคอมเมนต์เป็นภาพ**

บางสไลด์อาจมีโน้ตและคอมเมนต์

Aspose.Slides มีอินเทอร์เฟซสองตัว—[ITiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiffoptions/) และ [IRenderingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/irenderingoptions/)—ที่ให้คุณควบคุมการเรนเดอร์สไลด์การนำเสนอเป็นภาพ ทั้งสองอินเทอร์เฟซมีเมธอด `setSlidesLayoutOptions` ซึ่งช่วยให้คุณตั้งค่าการเรนเดอร์ของโน้ตและคอมเมนต์บนสไลด์เมื่อแปลงเป็นภาพ

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการสำหรับโน้ตและคอมเมนต์ในภาพผลลัพธ์ได้

โค้ดนี้แสดงวิธีการแปลงสไลด์ที่มีโน้ตและคอมเมนต์:

```java 
float scaleX = 2;
float scaleY = scaleX;

// โหลดไฟล์งานนำเสนอ.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // กำหนดตำแหน่งของโน้ต.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // กำหนดตำแหน่งของคอมเมนต์.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // กำหนดความกว้างของพื้นที่คอมเมนต์.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // กำหนดสีของพื้นที่คอมเมนต์.

    // สร้างตัวเลือกการเรนเดอร์.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // แปลงสไลด์แรกของงานนำเสนอเป็นภาพ.
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
ในกระบวนการแปลงสไลด์เป็นภาพใด ๆ เมธอด [setNotesPosition](https://reference.aspose.com/slides/th/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) ไม่สามารถใช้ `BottomFull` (เพื่อระบุตำแหน่งของโน้ต) ได้ เนื่องจากข้อความของโน้ตอาจมีขนาดใหญ่เกินไป ทำให้ไม่สามารถใส่ลงในขนาดภาพที่กำหนดได้
{{% /alert %}} 

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiffoptions/) ให้การควบคุมที่มากขึ้นสำหรับภาพ TIFF ที่สร้างขึ้นโดยอนุญาตให้คุณระบุพารามิเตอร์ต่าง ๆ เช่น ขนาด, ความละเอียด, พาเลตสี, และอื่น ๆ

โค้ดนี้แสดงกระบวนการแปลงโดยใช้ตัวเลือก TIFF เพื่อสร้างภาพขาว-ดำที่ความละเอียด 300 DPI และขนาด 2160 × 2800:

```java 
// โหลดไฟล์งานนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // ดึงสไลด์แรกจากงานนำเสนอ.
    ISlide slide = presentation.getSlides().get_Item(0);

    // กำหนดค่าการตั้งค่าของภาพ TIFF ผลลัพธ์.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // กำหนดขนาดภาพ.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // กำหนดรูปแบบพิกเซล (สีดำขาว).
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
การสนับสนุน Tiff ไม่ได้รับการรับประกันในเวอร์ชันก่อน JDK 9.
{{% /alert %}} 

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

Aspose.Slides อนุญาตให้คุณแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นภาพ ทำให้สามารถแปลงงานนำเสนอทั้งหมดเป็นชุดของภาพได้

ตัวอย่างโค้ดนี้แสดงวิธีการแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นภาพใน Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แสดงผลการนำเสนอเป็นภาพสไลด์ต่อสไลด์.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // ควบคุมสไลด์ที่ซ่อนอยู่ (ไม่แสดงผลสไลด์ที่ซ่อน).
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

## **การแสดงผล Emoji สี**

{{% alert title="Note" color="warning" %}} 
เพื่อให้การแสดงผล Emoji สีถูกต้องเมื่อต้องแปลงสไลด์การนำเสนอเป็นภาพ ฟอนต์ Emoji ที่ใช้ในงานนำเสนอต้องติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากงานนำเสนอใช้ **Segoe UI Emoji** และฟอนต์นี้หายไป Emoji อาจปรากฏเป็นสีขาว-ดำในภาพผลลัพธ์
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**

ไม่, เมธอด `getImage` จะบันทึกเฉพาะภาพนิ่งของสไลด์เท่านั้น ไม่รวมแอนิเมชัน

**สไลด์ที่ซ่อนอยู่สามารถส่งออกเป็นภาพได้หรือไม่?**

ได้, สไลด์ที่ซ่อนสามารถประมวลผลได้เช่นเดียวกับสไลด์ปกติ เพียงตรวจสอบให้แน่ใจว่าได้รวมสไลด์เหล่านั้นในลูปการประมวลผล

**สามารถบันทึกภาพพร้อมกับเงาและเอฟเฟกต์ได้หรือไม่?**

ได้, Aspose.Slides รองรับการเรนเดอร์เงา, ความโปร่งใส, และเอฟเฟกต์กราฟิกอื่น ๆ เมื่อบันทึกสไลด์เป็นภาพ