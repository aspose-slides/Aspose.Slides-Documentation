---
title: แปลงสไลด์งานนำเสนอเป็นภาพบน Android
linktitle: สไลด์เป็นภาพ
type: docs
weight: 35
url: /th/androidjava/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็น EMF
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงสไลด์จากงานนำเสนอ PPT, PPTX และ ODP ไปเป็น PNG, JPEG, GIF, TIFF, EMF และรูปแบบภาพอื่น ๆ บน Android ด้วย Aspose.Slides."
---
## **บทนำ**

Aspose.Slides for Android via Java สามารถเรนเดอร์สไลด์แต่ละสไลด์จากงานนำเสนอ PowerPoint และ OpenDocument เป็นรูปแบบ PNG, JPEG, GIF, TIFF และรูปแบบภาพอื่น ๆ

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. เลือกสไลด์ที่ต้องการเรนเดอร์  
3. หากต้องการ ให้กำหนดการเรนเดอร์ด้วยคลาส [RenderingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/renderingoptions/) หรือ [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/)  
4. เรียกเมธอด [ISlide.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getImage--) จะคืนค่าอ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/)  
5. เรียกเมธอด [IImage.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) และระบุรูปแบบเอาต์พุตด้วยค่า [ImageFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imageformat/)

## **แปลงสไลด์เป็นภาพ PNG**

การแปลงที่ง่ายที่สุดคือใช้การตั้งค่าเรนเดอร์เริ่มต้น อ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) ที่ได้สามารถประมวลผลในหน่วยความจำหรือบันทึกเป็นไฟล์ได้

ตัวอย่าง Java ด้านล่างเรนเดอร์สไลด์แรกและบันทึกเป็นไฟล์ PNG:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **แปลงสไลด์เป็นภาพด้วยขนาดที่กำหนดเอง**

ใช้เมธอดโอเวอร์โหลดของ [ISlide.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) ที่รับค่า [Size](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides.android/size/) เพื่อเรนเดอร์สไลด์ด้วยมิติพิกเซลที่ต้องการ

ตัวอย่างต่อไปนี้สร้างภาพ JPEG ขนาด 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **แปลงสไลด์พร้อมโน้ตและคอมเมนต์เป็นภาพ**

โดยค่าเริ่มต้น ภาพสไลด์จะไม่รวมโน้ตหรือคอมเมนต์ ส่งอ็อบเจกต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notescommentslayoutingoptions/) ไปยังเมธอด [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) เพื่อกำหนดตำแหน่งการแสดงโน้ตและคอมเมนต์

ตัวอย่างต่อไปนี้วางโน้ตที่ตัดทอนไว้ใต้สไลด์และคอมเมนต์ไว้ทางขวา:

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
สำหรับการแปลงสไลด์เป็นภาพ อย่าใช้ค่า [BottomFull](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notespositions/) กับเมธอด [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) เนื่องจากโน้ตอาจมีข้อความมากกว่าขนาดภาพที่กำหนด ใช้ค่า [BottomTruncated](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/notespositions/) แทน
{{% /alert %}}

## **แปลงสไลด์เป็นภาพโดยใช้ TIFF Options**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/) ช่วยให้คุณควบคุมขนาด ความละเอียด และคุณสมบัติอื่น ๆ ของภาพ TIFF ที่เรนเดอร์

ตัวอย่างต่อไปนี้เรนเดอร์สไลด์แรกเป็นภาพ TIFF ขนาด 2160 × 2880 ที่ความละเอียด 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

วนลูปผ่านคอลเลกชันสไลด์เพื่อแปลงงานนำเสนอทั้งหมดเป็นชุดของภาพ สไลด์ที่ซ่อนอยู่จะรวมอยู่ด้วย เว้นแต่คุณจะข้ามอย่างเจาะจง

ตัวอย่างต่อไปนี้เรนเดอร์ทุกสไลด์เป็นภาพ JPEG ด้วยอัตราสเกลแนวนอนและแนวตั้งเป็น 2:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **สร้างเอาต์พุต Enhanced Metafile**

Enhanced Metafile (EMF) มีประโยชน์เมื่อกราฟิกแบบเวกเตอร์ต้องแลกเปลี่ยนกับ Microsoft Office หรือแอปพลิเคชัน Windows อื่น ๆ ที่รองรับ Windows metafiles ต่างจากภาพแบบพิกเซล EMF สามารถเก็บการวาดแบบเวกเตอร์ที่ขยายได้โดยไม่สูญเสียความคมชัด อย่างไรก็ตาม EMF เป็นรูปแบบความเข้ากันได้สำหรับแอปพลิเคชันที่สนับสนุน Windows metafile ไม่ใช่รูปแบบแลกเปลี่ยนสากล นอกจากนี้ เนื้อหาสไลด์ที่ซับซ้อนเช่นภาพบิตแมพและเอฟเฟ็กต์บางอย่างอาจถูกจัดเก็บเป็นองค์ประกอบเรสเตอร์ภายในคอนเทนเนอร์เมตาฟाइलเวกเตอร์

### **ส่งออกสไลด์เป็น EMF**

เมธอด [ISlide.writeAsEmf](httpshttps://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) เขียนอ็อบเจกต์ [ISlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) ไปยังสตรีมเป้าหมายในรูปแบบ EMF ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เลือกสไลด์แรก และเขียนลงในสตรีมไฟล์ EMF:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

ผู้เรียกต้องเป็นเจ้าของสตรีมที่ส่งให้กับ [ISlide.writeAsEmf](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) และรับผิดชอบการปิดสตรีมนั้นตามที่แสดงข้างต้น

### **แปลงภาพ SVG เป็น EMF แล้วเพิ่มลงในงานนำเสนอ**

ใช้เมธอด [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) เพื่อแปลงเนื้อหา SVG เป็น EMF ไบต์ที่ได้สามารถเพิ่มลงในงานนำเสนอผ่านเมธอด [IImageCollection.addImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) และวางบนสไลด์ด้วยเมธอด [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)

ตัวอย่างต่อไปนี้สร้างอ็อบเจกต์ [SvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgimage/) จากโค้ด SVG แปลงเป็น EMF ในหน่วยความจำ แทรกเมตาฟล์ลงบนสไลด์แรก และบันทึกงานนำเสนอ:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมธอด [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) ไม่ได้เป็นเจ้าของสตรีมปลายทาง [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) เก็บข้อมูลทั้งหมดในหน่วยความจำ ดังนั้นจึงไม่จำเป็นต้องรีเซ็ตตำแหน่งก่อนเรียก `toByteArray` ไบต์อาเรย์ที่คืนค่าจะยังคงใช้ได้หลังจากปิดสตรีม

การสร้าง EMF มีให้ใช้บน Android เวอร์ชันและอุปกรณ์ที่รองรับบางรุ่นเท่านั้น อย่างไรก็ตาม การเรนเดอร์อาจแตกต่างเมื่อฟอนต์หรือกราฟิกที่จำเป็นไม่มี ให้ติดตั้งฟอนต์ที่ใช้ในเนื้อหาแหล่งหรือกำหนดการทดแทนที่เหมาะสม ตาม [installation guide](/slides/th/androidjava/install-aspose-slides-for-android-via-java/) สำหรับ Aspose.Slides for Android via Java แล้วตรวจสอบผลลัพธ์ในแอปพลิเคชันที่รับ EMF แอปพลิเคชันบนแพลตฟอร์มที่ไม่ใช่ Windows มักมีการสนับสนุนการแสดงและแก้ไข Windows metafile ที่จำกัดหรือไม่สอดคล้อง

## **การเรนเดอร์ Emoji สี**

{{% alert title="Note" color="info" %}}
เพื่อให้ Emoji สีแสดงอย่างถูกต้องเมื่อแปลงสไลด์เป็นภาพ ฟอนต์ Emoji ที่ใช้ในงานนำเสนอต้องติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากงานนำใช้ **Segoe UI Emoji** แต่ฟอนต์นี้ไม่มีอยู่ Emoji อาจปรากฏเป็นสีขาวดำในภาพผลลัพธ์
{{% /alert %}}

## **FAQ**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมเอฟเฟกต์แอนิเมชันหรือไม่?**

ไม่ครับ เมธอด [ISlide.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getImage--) จะเรนเดอร์ภาพนิ่งของสไลด์และไม่ส่งออกแอนิเมชัน

**สไลด์ที่ซ่อนอยู่สามารถส่งออกเป็นภาพได้หรือไม่?**

ได้ครับ สไลด์ที่ซ่อนสามารถเรนเดอร์เช่นสไลด์ทั่วไป ให้นำเข้ามาในลูปการประมวลผลตามตัวอย่างด้านบน

**เงาและเอฟเฟกต์อื่น ๆ จะถูกเก็บไว้ในภาพสไลด์หรือไม่?**

ได้ครับ Aspose.Slides จะเรนเดอร์เงา ความโปร่งแสง และเอฟเฟกต์กราฟิกที่รองรับอื่น ๆ ในภาพสไลด์