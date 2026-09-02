---
title: แปลงสไลด์การนำเสนอเป็นภาพบน Android
linktitle: สไลด์เป็นภาพ
type: docs
weight: 35
url: /th/androidjava/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมป
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงสไลด์จาก PPT, PPTX และ ODP เป็นภาพโดยใช้ Aspose.Slides สำหรับ Android—เรนเดอร์เร็วและคุณภาพสูงพร้อมตัวอย่างโค้ด Java ที่ชัดเจน"
---
## **บทนำ**

Aspose.Slides for Android via Java ช่วยให้คุณแปลงสไลด์การนำเสนอ PowerPoint และ OpenDocument ไปเป็นรูปภาพในรูปแบบต่าง ๆ ได้อย่างง่ายดาย รวมถึง BMP, PNG, JPG (JPEG), GIF และอื่น ๆ

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดการตั้งค่าการแปลงตามที่ต้องการและเลือกสไลด์ที่ต้องการส่งออกโดยใช้:
    - อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiffoptions/) หรือ
    - อินเทอร์เฟซ [IRenderingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/irenderingoptions/) 
2. สร้างภาพสไลด์โดยเรียกเมธอด [getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getImage--) 

ใน Aspose.Slides for Android via Java, อินเทอร์เฟซ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) ให้คุณทำงานกับภาพที่กำหนดด้วยข้อมูลพิกเซล คุณสามารถใช้อินเทอร์เฟซนี้เพื่อบันทึกภาพในรูปแบบหลากหลาย (BMP, JPG, PNG ฯลฯ)

## **แปลงสไลด์เป็นบิตแมปและบันทึกภาพเป็น PNG**

คุณสามารถแปลงสไลด์เป็นอ็อบเจ็กต์บิตแมปและใช้โดยตรงในแอปพลิเคชันของคุณ หรือคุณอาจแปลงสไลด์เป็นบิตแมปแล้วบันทึกภาพเป็น JPEG หรือรูปแบบอื่นที่ต้องการ

โค้ดนี้แสดงวิธีแปลงสไลด์แรกของการนำเสนอเป็นอ็อบเจ็กต์บิตแมปและบันทึกภาพเป็นรูปแบบ PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในงานนำเสนอเป็นบิตแมป.
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

## **แปลงสไลด์เป็นภาพด้วยขนาดกำหนดเอง**

คุณอาจต้องการรับภาพที่มีขนาดเฉพาะ ด้วยการใช้โอเวอร์โหลดจากเมธอด [getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) คุณสามารถแปลงสไลด์เป็นภาพด้วยความกว้างและความสูงที่กำหนด

โค้ดตัวอย่างนี้แสดงวิธีทำ:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในงานนำเสนอเป็นบิตแมปด้วยขนาดที่ระบุ.
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

## **แปลงสไลด์ที่มีโน๊ตและคอมเมนต์เป็นภาพ**

บางสไลด์อาจมีโน๊ตและคอมเมนต์

Aspose.Slides มีอินเทอร์เฟซสองตัว—[ITiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiffoptions/) และ [IRenderingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/irenderingoptions/)—ที่ให้คุณควบคุมการเรนเดอร์สไลด์การนำเสนอเป็นภาพ ทั้งสองอินเทอร์เฟซมีเมธอด `setSlidesLayoutOptions` ซึ่งช่วยให้คุณกำหนดการเรนเดอร์โน๊ตและคอมเมนต์บนสไลด์เมื่อแปลงเป็นภาพ

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notescommentslayoutingoptions/) คุณสามารถกำหนดตำแหน่งที่ต้องการสำหรับโน๊ตและคอมเมนต์ในภาพผลลัพธ์

โค้ดนี้แสดงวิธีแปลงสไลด์ที่มีโน๊ตและคอมเมนต์:

```java 
float scaleX = 2;
float scaleY = scaleX;

// โหลดไฟล์งานนำเสนอ.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // ตั้งตำแหน่งของโน๊ต.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // ตั้งตำแหน่งของคอมเมนต์.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // ตั้งความกว้างของพื้นที่คอมเมนต์.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // ตั้งสีของพื้นที่คอมเมนต์.

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

ในกระบวนการแปลงสไลด์เป็นภาพใด ๆ เมธอด [setNotesPosition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) ไม่สามารถใช้ค่า `BottomFull` (เพื่อกำหนดตำแหน่งของโน๊ต) ได้ เพราะข้อความโน๊ตอาจยาวเกินไป ทำให้ไม่สามารถใส่ลงในขนาดภาพที่ระบุได้

{{% /alert %}} 

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiffoptions/) ให้การควบคุมที่มากขึ้นกับภาพ TIFF ที่สร้างขึ้นโดยอนุญาตให้คุณกำหนดพารามิเตอร์ต่าง ๆ เช่น ขนาด, ความละเอียด, พาเล็ตสี ฯลฯ

โค้ดนี้แสดงกระบวนการแปลงที่ใช้ตัวเลือก TIFF เพื่อสร้างภาพสีขาว–ดำด้วยความละเอียด 300 DPI และขนาด 2160 × 2800:

```java 
// โหลดไฟล์งานนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // ดึงสไลด์แรกจากงานนำเสนอ.
    ISlide slide = presentation.getSlides().get_Item(0);

    // กำหนดการตั้งค่าของภาพ TIFF ผลลัพธ์.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // ตั้งขนาดภาพ.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // ตั้งรูปแบบพิกเซล (ขาวดำ).
    tiffOptions.setDpiX(300);                                        // ตั้งความละเอียดแนวนอน.
    tiffOptions.setDpiY(300);                                        // ตั้งความละเอียดแนวตั้ง.

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

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

Aspose.Slides อนุญาตให้คุณแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นภาพได้อย่างมีประสิทธิภาพ ทำให้การนำเสนอทั้งหมดกลายเป็นชุดของภาพ

โค้ดตัวอย่างนี้แสดงวิธีแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นภาพด้วย Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // เรนเดอร์งานนำเสนอเป็นภาพสไลด์ต่อสไลด์.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // ควบคุมสไลด์ที่ซ่อนอยู่ (ไม่เรนเดอร์สไลด์ที่ซ่อน).
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

## **การเรนเดอร์อีโมจีสี**

{{% alert title="Note" color="warning" %}} 
เพื่อให้การเรนเดอร์อีโมจีสีถูกต้องเมื่อแปลงสไลด์การนำเสนอเป็นภาพ ฟอนต์อีโมจิที่ใช้ในงานนำเสนอต้องถูกติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากงานนำเสนอใช้ **Segoe UI Emoji** แต่ฟอนต์นี้ไม่มีอยู่ อีโมจีอาจปรากฏเป็นสีเดียวในภาพผลลัพธ์
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการแสดงสไลด์พร้อมแอนิเมชันหรือไม่?**

ไม่, เมธอด `getImage` จะบันทึกรูปภาพนิ่งของสไลด์เท่านั้น ไม่มีแอนิเมชัน

**สไลด์ที่ซ่อนอยู่สามารถส่งออกเป็นภาพได้หรือไม่?**

ได้, สไลด์ที่ซ่อนอยู่สามารถประมวลผลได้เช่นเดียวกับสไลด์ปกติ เพียงตรวจสอบให้แน่ใจว่ามีการรวมไว้ในลูปการประมวลผล

**ภาพสามารถบันทึกพร้อมเงาและเอฟเฟกต์ได้หรือไม่?**

ได้, Aspose.Slides รองรับการเรนเดอร์เงา, ความโปร่งใส, และเอฟเฟกต์กราฟิกอื่น ๆ เมื่อบันทึกสไลด์เป็นภาพ