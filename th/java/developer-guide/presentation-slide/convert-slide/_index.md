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
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "แปลงสไลด์จาก PPT, PPTX และ ODP เป็นภาพใน Java โดยใช้ Aspose.Slides—เรนเดอร์เร็วคุณภาพสูงพร้อมตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

Aspose.Slides for Java ช่วยให้คุณสามารถแปลงสไลด์การนำเสนอ PowerPoint และ OpenDocument ไปเป็นรูปภาพหลายรูปแบบได้อย่างง่ายดาย รวมถึง BMP, PNG, JPG (JPEG), GIF และอื่น ๆ.

เพื่อแปลงสไลด์เป็นรูปภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดการตั้งค่าการแปลงที่ต้องการและเลือกสไลด์ที่ต้องการส่งออกโดยใช้:
    - อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiffoptions/) หรือ
    - อินเทอร์เฟซ [IRenderingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/irenderingoptions/)
2. สร้างรูปภาพสไลด์โดยเรียกเมธอด [getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-).

ใน Aspose.Slides for Java, อินเทอร์เฟซ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) เป็นอินเทอร์เฟซที่ช่วยให้คุณทำงานกับภาพที่กำหนดโดยข้อมูลพิกเซล คุณสามารถใช้อินเทอร์เฟซนี้เพื่อบันทึกภาพในหลากหลายรูปแบบ (BMP, JPG, PNG ฯลฯ).

## **แปลงสไลด์เป็นบิตแมพและบันทึกรูปภาพเป็น PNG**

คุณสามารถแปลงสไลด์เป็นออบเจ็กต์บิตแมพและใช้โดยตรงในแอปพลิเคชันของคุณ หรือคุณสามารถแปลงสไลด์เป็นบิตแมพแล้วบันทึกรูปภาพเป็น JPEG หรือรูปแบบอื่นตามที่ต้องการ.

โค้ดนี้แสดงวิธีการแปลงสไลด์แรกของการนำเสนอเป็นออบเจ็กต์บิตแมพและบันทึกรูปภาพเป็นรูปแบบ PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในงานนำเสนอเป็นบิตแมพ.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // บันทึกรูปภาพในรูปแบบ PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **แปลงสไลด์เป็นภาพด้วยขนาดกำหนดเอง**

คุณอาจต้องการภาพที่มีขนาดเฉพาะ โดยใช้การโอเวอร์โหลดของเมธอด [getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) คุณสามารถแปลงสไลด์เป็นภาพที่มีมิติที่กำหนด (ความกว้างและความสูง).

โค้ดตัวอย่างนี้แสดงวิธีทำเช่นนั้น:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในงานนำเสนอเป็นบิตแมพด้วยขนาดที่ระบุ.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // บันทึกรูปภาพในรูปแบบ JPEG.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **แปลงสไลด์พร้อมบันทึกย่อและความคิดเห็นเป็นภาพ**

สไลด์บางสไลด์อาจมีบันทึกย่อและความคิดเห็น.

Aspose.Slides มีสองอินเทอร์เฟซ—[ITiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiffoptions/) และ [IRenderingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/irenderingoptions/)—ที่ให้คุณควบคุมการเรนเดอร์สไลด์การนำเสนอเป็นภาพ อินเทอร์เฟซทั้งสองมีเมธอด `setSlidesLayoutOptions` ซึ่งช่วยให้คุณกำหนดค่าการเรนเดอร์บันทึกย่อและความคิดเห็นบนสไลด์เมื่อต้องแปลงเป็นภาพ.

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการสำหรับบันทึกย่อและความคิดเห็นในภาพที่ได้.

โค้ดนี้แสดงวิธีการแปลงสไลด์ที่มีบันทึกย่อและความคิดเห็น:

```java 
float scaleX = 2;
float scaleY = scaleX;

// โหลดไฟล์งานนำเสนอ.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // ตั้งตำแหน่งของบันทึกย่อ.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // ตั้งตำแหน่งของความคิดเห็น.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // ตั้งความกว้างของพื้นที่ความคิดเห็น.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // ตั้งสีสำหรับพื้นที่ความคิดเห็น.

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
ในการแปลงสไลด์เป็นภาพใด ๆ เมธอด [setNotesPosition](https://reference.aspose.com/slides/th/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) ไม่สามารถใช้ค่า `BottomFull` (เพื่อระบุตำแหน่งของบันทึกย่อ) ได้ เนื่องจากข้อความของบันทึกย่ออาจยาวเกินไป ทำให้ไม่สามารถใส่ลงในขนาดภาพที่กำหนดได้.
{{% /alert %}} 

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/itiffoptions/) ให้การควบคุมที่ละเอียดขึ้นสำหรับภาพ TIFF ที่ได้โดยให้คุณระบุพารามิเตอร์ต่าง ๆ เช่น ขนาด, ความละเอียด, พาเลตสี, และอื่น ๆ.

โค้ดนี้แสดงกระบวนการแปลงที่ใช้ตัวเลือก TIFF เพื่อสร้างภาพขาว-ดำที่มีความละเอียด 300 DPI และขนาด 2160 × 2800:

```java 
// โหลดไฟล์งานนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // ดึงสไลด์แรกจากงานนำเสนอ.
    ISlide slide = presentation.getSlides().get_Item(0);

    // กำหนดการตั้งค่าภาพ TIFF ที่ส่งออก.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // ตั้งขนาดภาพ.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // ตั้งรูปแบบพิกเซล (ขาวดำ).
    tiffOptions.setDpiX(300);                                        // ตั้งความละเอียดแนวนอน.
    tiffOptions.setDpiY(300);                                        // ตั้งความละเอียดแนวตั้ง.

    // แปลงสไลด์เป็นภาพด้วยตัวเลือกที่กำหนด.
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

Aspose.Slides ให้คุณแปลงสไลด์ทั้งหมดในการนำเสนอเป็นภาพ ทำให้การนำเสนอทั้งหมดถูกแปลงเป็นชุดของภาพ.

โค้ดตัวอย่างนี้แสดงวิธีการแปลงสไลด์ทั้งหมดในการนำเสนอเป็นภาพโดยใช้ Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แสดงผลการนำเสนอเป็นภาพสไลด์ต่อสไลด์.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // ควบคุมสไลด์ที่ซ่อนอยู่ (ไม่ต้องเรนเดอร์สไลด์ที่ซ่อน).
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

## **FAQ**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**

ไม่มี, เมธอด `getImage` จะบันทึกเฉพาะภาพสไลด์แบบคงที่ ไม่รวมแอนิเมชัน.

**สามารถส่งออกสไลด์ที่ซ่อนอยู่เป็นภาพได้หรือไม่?**

ได้, สไลด์ที่ซ่อนอยู่สามารถประมวลผลได้เช่นเดียวกับสไลด์ปกติ เพียงแค่ตรวจสอบให้แน่ใจว่าได้รวมไว้ในลูปการประมวลผล.

**สามารถบันทึกภาพพร้อมเงาและเอฟเฟกต์ได้หรือไม่?**

ได้, Aspose.Slides รองรับการเรนเดอร์เงา, ความโปร่งใส, และเอฟเฟกต์กราฟิกอื่น ๆ เมื่อบันทึกสไลด์เป็นภาพ.