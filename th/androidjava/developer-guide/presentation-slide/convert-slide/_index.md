---
title: แปลงสไลด์พรีเซนเทชั่นเป็นรูปภาพบน Android
linktitle: สไลด์เป็นรูปภาพ
type: docs
weight: 35
url: /th/androidjava/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นรูปภาพ
- บันทึกสไลด์เป็นรูปภาพ
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- พรีเซนเทชั่น
- Android
- Java
- Aspose.Slides
description: "แปลงสไลด์จากไฟล์ PPT, PPTX และ ODP เป็นรูปภาพโดยใช้ Aspose.Slides สำหรับ Android—การเรนเดอร์ที่รวดเร็วและคุณภาพสูงพร้อมตัวอย่างโค้ด Java ที่ชัดเจน."
---
## **คำนำ**

Aspose.Slides for Android via Java ช่วยให้คุณแปลงสไลด์พรีเซนต์เทชัน PowerPoint และ OpenDocument ไปเป็นรูปภาพหลายรูปแบบได้อย่างง่ายดาย เช่น BMP, PNG, JPG (JPEG), GIF และรูปแบบอื่น ๆ

เพื่อแปลงสไลด์เป็นรูปภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดการตั้งค่าการแปลงที่ต้องการและเลือกสไลด์ที่ต้องการส่งออกโดยใช้:
    - อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiffoptions/) หรือ
    - อินเทอร์เฟซ [IRenderingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/irenderingoptions/)
2. สร้างรูปภาพของสไลด์โดยเรียกเมธอด [getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getImage--)  

ใน Aspose.Slides for Android via Java, อินเทอร์เฟซ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) เป็นตัวกลางที่ให้คุณทำงานกับภาพที่นิยามด้วยข้อมูลพิกเซล คุณสามารถใช้อินเทอร์เฟซนี้เพื่อบันทึกภาพในหลายรูปแบบ (BMP, JPG, PNG ฯลฯ)

## **แปลงสไลด์เป็นบิตแมพและบันทึกรูปภาพเป็น PNG**

คุณสามารถแปลงสไลด์เป็นอ็อบเจกต์บิตแมพและใช้โดยตรงในแอปพลิเคชันของคุณ หรือแปลงสไลด์เป็นบิตแมพแล้วบันทึกเป็น JPEG หรือรูปแบบอื่นตามต้องการ  

โค้ดนี้สาธิตการแปลงสไลด์แรกของพรีเซนต์เทชันเป็นอ็อบเจกต์บิตแมพและบันทึกรูปภาพเป็นรูปแบบ PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในพรีเซนเทชันเป็นบิตแมพ.
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

## **แปลงสไลด์เป็นรูปภาพด้วยขนาดที่กำหนดเอง**

คุณอาจต้องการรูปภาพที่มีขนาดเฉพาะ โดยใช้ overload ของเมธอด [getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) คุณสามารถแปลงสไลด์เป็นรูปภาพด้วยความกว้างและความสูงที่กำหนด  

ตัวอย่างโค้ดนี้แสดงวิธีทำ:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในพรีเซนเทชันเป็นบิตแมพด้วยขนาดที่ระบุ.
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

## **แปลงสไลด์พร้อมโน๊ตและคอมเมนต์เป็นรูปภาพ**

บางสไลด์อาจมีโน๊ตและคอมเมนต์  

Aspose.Slides มีอินเทอร์เฟซสองตัว—[ITiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiffoptions/) และ [IRenderingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/irenderingoptions/)—ที่ให้คุณควบคุมการเรนเดอร์สไลด์เป็นรูปภาพ ทั้งสองอินเทอร์เฟซมีเมธอด `setSlidesLayoutOptions` ซึ่งช่วยให้คุณกำหนดการเรนเดอร์ของโน๊ตและคอมเมนต์บนสไลด์เมื่อแปลงเป็นรูปภาพ  

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการของโน๊ตและคอมเมนต์ในรูปภาพที่ได้  

โค้ดนี้สาธิตการแปลงสไลด์พร้อมโน๊ตและคอมเมนต์:

```java 
float scaleX = 2;
float scaleY = scaleX;

// โหลดไฟล์พรีเซนเทชัน.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // ตั้งค่าตำแหน่งของโน๊ต.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // ตั้งค่าตำแหน่งของคอมเมนต์.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // ตั้งค่าความกว้างของพื้นที่คอมเมนต์.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // ตั้งค่าสีของพื้นที่คอมเมนต์.

    // สร้างตัวเลือกการเรนเดอร์.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // แปลงสไลด์แรกของพรีเซนเทชันเป็นภาพ.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // บันทึกรูปภาพในรูปแบบ GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
ในกระบวนการแปลงสไลด์เป็นรูปภาพใด ๆ เมธอด [setNotesPosition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) ไม่สามารถใช้ค่า `BottomFull` (เพื่อระบุตำแหน่งของโน๊ต) ได้ เนื่องจากข้อความของโน๊ตอาจยาวเกินไปจนไม่สามารถใส่ลงในขนาดรูปภาพที่กำหนดได้ 
{{% /alert %}} 

## **แปลงสไลด์เป็นรูปภาพโดยใช้ TIFF Options**

อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itiffoptions/) ให้การควบคุมที่ละเอียดมากขึ้นสำหรับรูปภาพ TIFF ที่ได้ โดยสามารถกำหนดพารามิเตอร์เช่น ขนาด, ความละเอียด, พาเลตสี ฯลฯ  

โค้ดนี้สาธิตกระบวนการแปลงโดยใช้ TIFF Options เพื่อสร้างภาพขาว-ดำที่ความละเอียด 300 DPI และขนาด 2160 × 2800:

```java 
// โหลดไฟล์พรีเซนเทชัน.
Presentation presentation = new Presentation("sample.pptx");
try {
    // ดึงสไลด์แรกจากพรีเซนเทชัน.
    ISlide slide = presentation.getSlides().get_Item(0);

    // กำหนดค่าการตั้งค่าของภาพ TIFF ที่ส่งออก.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // ตั้งค่าขนาดของภาพ.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // ตั้งค่ารูปแบบพิกเซล (สีดำและขาว).
    tiffOptions.setDpiX(300);                                        // ตั้งค่าความละเอียดในแนวนอน.
    tiffOptions.setDpiY(300);                                        // ตั้งค่าความละเอียดในแนวตั้ง.

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

## **แปลงสไลด์ทั้งหมดเป็นรูปภาพ**

Aspose.Slides ให้คุณแปลงสไลด์ทั้งหมดในพรีเซนต์เทชันเป็นรูปภาพ ซึ่งหมายความว่าพรีเซนต์เทชันทั้งหมดจะถูกแปลงเป็นชุดของรูปภาพ  

ตัวอย่างโค้ดนี้แสดงวิธีแปลงสไลด์ทั้งหมดในพรีเซนต์เทชันเป็นรูปภาพด้วย Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // เรนเดอร์พรีเซนเทชันเป็นรูปภาพสไลด์ต่อสไลด์.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // ควบคุมสไลด์ที่ซ่อนอยู่ (ไม่เรนเดอร์สไลด์ที่ซ่อน).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // แปลงสไลด์เป็นภาพ.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // บันทึกรูปภาพในรูปแบบ JPEG.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**  
ไม่, เมธอด `getImage` บันทึกรูปภาพสไลด์แบบนิ่งเท่านั้น ไม่รวมแอนิเมชัน

**สามารถส่งออกสไลด์ที่ถูกซ่อนไปเป็นรูปภาพได้หรือไม่?**  
ได้, สไลด์ที่ซ่อนอยู่สามารถประมวลผลได้เช่นเดียวกับสไลด์ปกติ เพียงตรวจให้แน่ใจว่ามีการรวมสไลด์เหล่านั้นในลูปการประมวลผล

**สามารถบันทึกรูปภาพพร้อมเงาและเอฟเฟกต์ได้หรือไม่?**  
ได้, Aspose.Slides รองรับการเรนเดอร์เงา, ความโปร่งใส, และเอฟเฟกต์กราฟิกอื่น ๆ เมื่อบันทึกสไลด์เป็นรูปภาพ