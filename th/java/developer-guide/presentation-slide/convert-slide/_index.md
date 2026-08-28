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
- สไลด์เป็น EMF
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมป
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "แปลงสไลด์จากการนำเสนอรูปแบบ PPT, PPTX และ ODP เป็น PNG, JPEG, GIF, TIFF, EMF และรูปแบบภาพอื่น ๆ ใน Java ด้วย Aspose.Slides."
---
## **บทนำ**

Aspose.Slides for Java สามารถเรนเดอร์สไลด์แต่ละสไลด์จากการนำเสนอ PowerPoint และ OpenDocument เป็นรูปแบบ PNG, JPEG, GIF, TIFF และรูปแบบภาพอื่น ๆ

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:
1. โหลดการนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
2. เลือกสไลด์ที่คุณต้องการเรนเดอร์
3. หากจำเป็น ให้กำหนดค่าการเรนเดอร์ด้วยคลาส [RenderingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/renderingoptions/) หรือ [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) 
4. เรียกใช้เมธอด [ISlide.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getImage--) เมธอดนี้จะคืนค่าออบเจกต์ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/)
5. เรียกใช้เมธอด [IImage.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/#save-java.lang.String-int-) และระบุรูปแบบการส่งออกโดยใช้ค่า [ImageFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/imageformat/)

## **แปลงสไลด์เป็นภาพ PNG**

วิธีแปลงที่ง่ายที่สุดใช้การตั้งค่าการเรนเดอร์ค่าเริ่มต้น ออบเจกต์ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) ที่ได้สามารถประมวลผลในหน่วยความจำหรือบันทึกเป็นไฟล์

ตัวอย่าง Java ด้านล่างเรนเดอร์สไลด์แรกและบันทึกเป็นภาพ PNG:
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

## **แปลงสไลด์เป็นภาพด้วยขนาดกำหนดเอง**

ใช้เมธอด overload ของ [ISlide.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) ที่รับค่าประเภท [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) เพื่อเรนเดอร์สไลด์ด้วยขนาดพิกเซลที่แน่นอน

ตัวอย่างต่อไปนี้สร้างภาพ JPEG ขนาด 1820 × 1040:
```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

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

## **แปลงสไลด์ที่มีหมายเหตุและความคิดเห็นเป็นภาพ**

โดยค่าเริ่มต้น ภาพสไลด์จะไม่รวมหมายเหตุหรือความคิดเห็น ส่งออบเจกต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/notescommentslayoutingoptions/) ไปยังเมธอด [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) เพื่อควบคุมตำแหน่งที่จะแสดงหมายเหตุและความคิดเห็น

ตัวอย่างต่อไปนี้วางหมายเหตุที่ตัดทอนไว้ด้านล่างสไลด์และความคิดเห็นทางด้านขวาของสไลด์:
```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

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
สำหรับการแปลงสไลด์เป็นภาพ อย่าส่งค่า [BottomFull](https://reference.aspose.com/slides/th/java/com.aspose.slides/notespositions/) ไปยังเมธอด [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/th/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) เนื่องจากหมายเหตุอาจมีข้อความมากกว่าขนาดภาพที่กำหนดไว้ ใช้ [BottomTruncated](https://reference.aspose.com/slides/th/java/com.aspose.slides/notespositions/) แทน
{{% /alert %}}

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) ช่วยให้คุณควบคุมขนาด ความละเอียด และคุณสมบัติอื่น ๆ ของภาพ TIFF ที่เรนเดอร์

ตัวอย่างต่อไปนี้เรนเดอร์สไลด์แรกเป็นภาพ TIFF ขนาด 2160 × 2880 ที่ 300 DPI:
```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

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

{{% alert title="Warning" color="warning" %}}
การสนับสนุน TIFF ไม่รับประกันในเวอร์ชัน Java ที่ก่อนหน้า JDK 9
{{% /alert %}}

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

วนลูปผ่านคอลเลกชันสไลด์เพื่อแปลงการนำเสนอทั้งหมดเป็นชุดของภาพ สไลด์ที่ซ่อนอยู่จะถูกรวมด้วย เว้นแต่คุณจะข้ามอย่างชัดเจน

ตัวอย่างต่อไปนี้เรนเดอร์ทุกสไลด์เป็นภาพ JPEG โดยใช้ค่าอัตราส่วนการขยายแนวนอนและแนวตั้งเป็น 2:
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

## **สร้างผลลัพธ์ Enhanced Metafile**

Enhanced Metafile (EMF) มีประโยชน์เมื่อต้องแลกเปลี่ยนกราฟิกแบบเวกเตอร์กับ Microsoft Office หรือแอปพลิเคชัน Windows อื่น ๆ ที่รองรับ Windows metafiles แตกต่างจากภาพแบบพิกเซล EMF สามารถเก็บการวาดเวกเตอร์ที่ขยายได้โดยไม่สูญเสียความคมชัด อย่างไรก็ตาม EMF เป็นรูปแบบความเข้ากันได้หลักสำหรับแอปพลิเคชันที่รองรับ Windows metafile ไม่ใช่รูปแบบการแลกเปลี่ยนสากล นอกจากนี้ เนื้อหาสไลด์ที่ซับซ้อน เช่น ภาพบิตแมปและเอฟเฟกต์บางอย่าง อาจถูกจัดเก็บเป็นองค์ประกอบที่แรสเตอร์ภายในคอนเทนเนอร์เมทาฟไฟล์เวกเตอร์

### **ส่งออกสไลด์เป็น EMF**

เมธอด [ISlide.writeAsEmf](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) จะเขียน [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/) ไปยังสตรีมเป้าหมายในรูปแบบ EMF ตัวอย่างต่อไปนี้โหลดการนำเสนอ เลือกสไลด์แรก และเขียนลงสตรีมไฟล์ EMF:
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

ผู้เรียกเป็นเจ้าของสตรีมที่ส่งไปยัง [ISlide.writeAsEmf](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) และรับผิดชอบในการปิดสตรีมนั้นตามที่แสดงข้างต้น

### **แปลงภาพ SVG เป็น EMF และเพิ่มลงในการนำเสนอ**

ใช้ [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) เพื่อแปลงเนื้อหา SVG เป็น EMF ไบต์ที่ได้สามารถเพิ่มลงในการนำเสนอผ่าน [IImageCollection.addImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) และวางบนสไลด์ด้วย [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)

ตัวอย่างต่อไปนี้สร้าง [SvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgimage/) จาก markup SVG แปลงเป็น EMF ในหน่วยความจำ ใส่เมทาฟไฟล์ลงบนสไลด์แรก และบันทึกการนำเสนอ:
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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) ไม่รับครอบครองสตรีมปลายทาง [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) จะเก็บข้อมูลที่สร้างทั้งหมดในหน่วยความจำ ดังนั้นไม่จำเป็นต้องรีเซ็ตตำแหน่งก่อนเรียก `toByteArray` อาเรย์ไบต์ที่ส่งคืนยังคงใช้งานได้หลังจากสตรีมถูกปิด

การสร้าง EMF สามารถทำได้บนระบบปฏิบัติการที่สนับสนุนโดย Aspose.Slides for Java และการกำหนดค่า JDK ที่เลือก แต่การเรนเดอร์อาจแตกต่างกันระหว่างแพลตฟอร์มเมื่อฟอนต์หรือการพึ่งพากราฟิกไม่มีการติดตั้ง ติดตั้งฟอนต์ที่ใช้ในเนื้อหาแหล่งหรือกำหนดการแทนที่ที่เหมาะสม ปฏิบัติตาม [platform requirements](/slides/th/java/system-requirements/) สำหรับ Aspose.Slides for Java และตรวจสอบผลลัพธ์ในแอปพลิเคชันที่ใช้ EMF เป้าหมาย แอปพลิเคชันบน Linux และ macOS มักมีการสนับสนุนที่จำกัดหรือไม่สม่ำเสมอในการแสดงและแก้ไข Windows metafiles

## **การเรนเดอร์ Emoji สี**

{{% alert title="Note" color="info" %}}
เพื่อให้การเรนเดอร์ emoji สีถูกต้องเมื่อแปลงสไลด์การนำเสนอเป็นภาพ ฟอนต์ emoji ที่ใช้ในการนำเสนอต้องถูกติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากการนำเสนอใช้ **Segoe UI Emoji** และฟอนต์นี้ไม่มีอยู่ emoji อาจปรากฏเป็นสีขาว-ดำในภาพผลลัพธ์
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**  
ไม่. เมธอด [ISlide.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getImage--) เรนเดอร์ภาพสไลด์แบบคงที่และไม่ส่งออกแอนิเมชัน

**สามารถส่งออกสไลด์ที่ซ่อนเป็นภาพได้หรือไม่?**  
ได้. สไลด์ที่ซ่อนสามารถเรนเดอร์ได้เช่นสไลด์ทั่วไป รวมไว้ในลูปการประมวลผลตามที่แสดงในตัวอย่างข้างต้น

**เงาและเอฟเฟกต์อื่น ๆ ถูกเก็บไว้ในภาพสไลด์หรือไม่?**  
ได้. Aspose.Slides เรนเดอร์เงา ความโปร่งใส และเอฟเฟกต์กราฟิกอื่น ๆ ที่รองรับในภาพสไลด์