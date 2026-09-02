---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในการนำเสนอบน Android
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/androidjava/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มรูป
- แทนที่รูปภาพ
- คอลเลกชันรูปภาพ
- กรอบภาพ
- รูปภาพเชื่อมโยง
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- SVG เป็นรูปร่าง
- ทรัพยากร SVG ภายนอก
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, ใช้ซ้ำ, ลิงก์, แทนที่ และจัดการรูปภาพราสเตอร์และ SVG ในการนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **บทนำ**

Aspose.Slides สำหรับ Android ผ่าน Java มีวิธีการทำงานกับรูปภาพหลายวิธี และแต่ละวิธีมีจุดประสงค์ที่แตกต่างกัน คุณสามารถเก็บรูปภาพในงานนำเสนอ, แสดงในกรอบภาพ, ใช้เป็นพื้นหลังสไลด์, ลิงก์ไปยังรูปภาพภายนอก, แทนที่ทรัพยากรรูปภาพที่แชร์, หรือแปลงเนื้อหา SVG ให้เป็นรูปร่างที่แก้ไขได้

บทความนี้มุ่งเน้นที่ทรัพยากรรูปภาพและวิธีการใช้ทั่วงานนำเสนอ สำหรับการตัด, ความโปร่งใส, เอฟเฟกต์, การยืด, และการจัดรูปแบบอื่น ๆ ที่ใช้กับกรอบภาพแต่ละกรอบ, ดูที่ [กรอบภาพ](/slides/th/androidjava/picture-frame/)

## **ทำความเข้าใจโมเดลรูปภาพ**

แนวคิด API ต่อไปนี้เกี่ยวข้องกันอย่างใกล้ชิด แต่ไม่สามารถแทนกันได้:

- [คอลเลกชันรูปภาพของงานนำเสนอ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagecollection/) เก็บทรัพยากรรูปภาพที่ใช้โดยงานนำเสนอ ใช้ [ImageCollection.addImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imagecollection/) เพื่อเพิ่มข้อมูลรูปภาพและรับทรัพยากร [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/)
- [กรอบภาพ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) คือรูปร่างที่แสดงรูปภาพบนสไลด์, เลย์เอาต์ หรือมาสเตอร์ ใช้ [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/) เพื่อวางทรัพยากรรูปภาพบนสไลด์
- พื้นหลังสไลด์ใช้รูปภาพเป็นส่วนหนึ่งของการเติมสไลด์แทนที่จะเป็นรูปร่าง ดังนั้นจึงไม่ทำงานเหมือนกรอบภาพ
- [IPPImage.replaceImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) แทนที่ทรัพยากรรูปภาพ หากหลายองค์ประกอบของงานนำเสนอใช้ทรัพยากรนั้น พวกเขาทั้งหมดจะใช้การแทนที่
- การแปลง SVG เป็นรูปร่างสร้างรูปร่างสไลด์ที่แก้ไขได้ หลังจากการแปลง เนื้อหาไม่ถูกจัดการเป็นทรัพยากรรูปภาพเดียวอีกต่อไป

ดังนั้นกระบวนการทำงานทั่วไปคือ: เพิ่มข้อมูลรูปภาพลงในคอลเลกชันรูปภาพ, รับ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/), แล้วใช้ทรัพยากรนั้นในหนึ่งหรือหลายกรอบภาพหรือการเติม

## **เพิ่มรูปภาพฝัง**

เพื่อแทรกรูปภาพในเครื่อง, โหลดไฟล์, เพิ่มลงในคอลเลกชันรูปภาพ, และสร้างกรอบภาพที่ใช้ `IPPImage` ที่คืนค่า

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

รูปภาพที่เพิ่มด้วยวิธีนี้จะถูกฝังในงานนำเสนอ ดังนั้นไฟล์ที่ได้จะไม่ขึ้นอยู่กับไฟล์รูปภาพต้นฉบับที่ยังคงมีอยู่

### **เพิ่มรูปภาพจากเว็บ**

เมื่อรูปภาพสามารถเข้าถึงได้ผ่าน HTTP หรือ HTTPS ให้ดาวน์โหลดไบต์ของมัน, เพิ่มลงในคอลเลกชันรูปภาพของงานนำเสนอ, และใช้ทรัพยากรรูปภาพที่ได้รับเช่นเดียวกับรูปภาพในเครื่อง

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ในแอปพลิเคชันที่ทำงานเป็นเวลานาน, ควรใช้คลไอเอนต์ HTTP หรือกลยุทธ์การจัดการการเชื่อมต่อที่เหมาะสมกับแอปพลิเคชันแทนการสร้างโครงสร้างเครือข่ายที่ไม่จำเป็นซ้ำ ๆ นอกจากนี้ควรตรวจสอบความถูกต้องของ URL จากระยะไกล, ขนาดการตอบกลับ, และประเภทของเนื้อหาเมื่อแหล่งที่มาไม่น่าเชื่อถือ

## **ใช้รูปภาพซ้ำระหว่างสไลด์**

หากต้องการใช้รูปภาพเดียวกันหลายครั้ง ให้เพิ่มมันลงในงานนำเสนอหนึ่งครั้งและใช้ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ที่ได้รับเมื่อสร้างกรอบภาพเพิ่มเติม วิธีนี้จะหลีกเลี่ยงการโหลดข้อมูลต้นฉบับซ้ำ ๆ และทำให้ความสัมพันธ์ระหว่างทรัพยากรรูปภาพที่แชร์และการใช้ของมันชัดเจน

สำหรับกราฟิกที่ควรปรากฏอัตโนมัติบนหลายสไลด์ เช่น โลโก้บริษัท, พิจารณาใส่กรอบภาพบน [มาสเตอร์สไลด์](/slides/th/androidjava/slide-master/) หรือเลย์เอาต์ แทนการเพิ่มรูปร่างที่เทียบเท่าในแต่ละสไลด์

## **ใช้รูปภาพเป็นพื้นหลังสไลด์**

รูปภาพพื้นหลังจะถูกกำหนดให้กับการเติมสไลด์; มันไม่ได้ถูกเพิ่มเป็นรูปร่างกรอบภาพ วิธีนี้เป็นประโยชน์เมื่อภาพควรครอบพื้นหลังสไลด์และไม่ควรถูกจัดการเช่นวัตถุปกติของสไลด์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับตัวเลือกพื้นหลังเพิ่มเติม รวมถึงพื้นหลังมาสเตอร์และเลย์เอาต์, ดูที่ [พื้นหลังงานนำเสนอ](/slides/th/androidjava/presentation-background/)

## **รูปภาพฝังและรูปภาพเชื่อมโยง**

รูปภาพฝังและรูปภาพเชื่อมโยงมีการแลกเปลี่ยนด้านการพกพาและขนาดไฟล์ที่แตกต่างกัน:

- **รูปภาพฝัง:** ข้อมูลภาพถูกเก็บไว้ภายในงานนำเสนอ งานนำเสนอเป็นอิสระเอง แต่ขนาดไฟล์รวมข้อมูลภาพด้วย
- **รูปภาพเชื่อมโยง:** งานนำเสนอเก็บเส้นทางหรือ URL ไปยังรูปภาพภายนอก สิ่งนี้สามารถลดขนาดงานนำเสนอได้ แต่ทรัพยากรภายนอกต้องสามารถเข้าถึงได้เมื่อเปิดหรือเรนเดอร์งานนำเสนอ

สามารถสร้างภาพเชื่อมโยงโดยกำหนดเส้นทางหรือ URL ภายนอกผ่าน [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidespicture/) แทนการฝังข้อมูลภาพ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ใช้รูปภาพเชื่อมโยงเฉพาะเมื่อสภาพแวดล้อมการปรับใช้สามารถเข้าถึงทรัพยากรภายนอกได้อย่างเชื่อถือได้ สำหรับงานนำเสนอที่ต้องทำงานแบบออฟไลน์หรือย้ายระหว่างระบบ, รูปภาพฝังมักจะปลอดภัยกว่า

## **ทำงานกับรูปภาพ SVG**

SVG เป็นฟอร์แมตเวคเตอร์ ดังนั้นจึงเหมาะสำหรับไอคอน, แผนภาพ, และกราฟิกอื่น ๆ ที่ควรขยายได้โดยไม่สูญเสียรายละเอียดเหมือนภาพราสเตอร์ Aspose.Slides รองรับ SVG ทั้งเป็นทรัพยากรรูปภาพและเป็นแหล่งสำหรับรูปร่างสไลด์ที่แก้ไขได้

### **เพิ่ม SVG เป็นรูปภาพ**

สร้าง [SvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgimage/), เพิ่มลงในคอลเลกชันรูปภาพ, และวางทรัพยากรรูปภาพที่ได้ในกรอบภาพ

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ไฟล์ SVG ที่มีทรัพยากรภายนอก**

SVG สามารถอ้างอิงภาพ, Stylesheet หรือฟอนต์ภายนอกได้ สำหรับกรณีเหล่านี้ [SvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgimage/) มีคอนสตรัคเตอร์ที่รับ [IExternalResourceResolver](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iexternalresourceresolver/) และ base URI ตัวแก้ไขสามารถแมป URI สัมพัทธ์เป็น URI ที่อนุญาตเต็มรูปแบบและคืนสตรีมสำหรับทรัพยากรที่ร้องขอ

ตัวแก้ไขทำให้ทรัพยากรภายนอกรับได้ขณะ Aspose.Slides ประมวลผล SVG, แต่จะไม่เขียนใหม่ SVG ให้เป็นเอกสารอิสระ หากต้องการให้ SVG พกพาได้, ฝังทรัพยากรที่จำเป็นไว้ใน SVG เอง เช่น ใช้ URI `data:` สำหรับรูปภาพเชื่อมโยง

เมื่อไฟล์ SVG มาจากแหล่งที่ไม่น่าเชื่อถือ ให้จำกัดโพรโทคอล, ตำแหน่งไฟล์, และโฮสต์ที่ตัวแก้ไขสามารถเข้าถึงได้ ตัวแก้ไขเครือข่ายควรตั้งค่า timeout, ขีดจำกัดขนาดการตอบกลับ, และการตรวจสอบเนื้อหา

### **แปลง SVG เป็นรูปร่างที่แก้ไขได้**

Aspose.Slides สามารถแปลง SVG เป็นกลุ่มของรูปร่างสไลด์ที่แก้ไขได้ คล้ายกับคำสั่ง PowerPoint ที่สอดคล้องกัน

![เมนูป๊อปอัพ PowerPoint](img_01_01.png)

ใช้ [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/) overload ที่รับ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) เพื่อทำการแปลง

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ใช้การแปลง SVG เป็นรูปร่างเมื่อองค์ประกอบเวคเตอร์แต่ละอันต้องการแก้ไขเป็นรูปร่าง PowerPoint หาก SVG เพียงต้องการแสดงผล การเก็บเป็นรูปภาพจะง่ายกว่าและหลีกเลี่ยงการสร้างรูปร่างแยกหลายรูป

## **แทนที่ทรัพยากรรูปภาพที่มีอยู่**

ใช้ [IPPImage.replaceImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) เมื่อคุณต้องการแทนที่ทรัพยากรรูปภาพที่มีอยู่ วิธีนี้มีประโยชน์เป็นพิเศษสำหรับกราฟิกที่แชร์ เช่น โลโก้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากหลายกรอบภาพ, พื้นหลัง, มาสเตอร์ หรือเลย์เอาต์ใช้ทรัพยากรรูปเดียวกัน การแทนที่ทรัพยากรนั้นจะอัปเดตการใช้ทั้งหมด หากต้องการเปลี่ยนเพียงกรอบภาพเดียว ให้กำหนดรูปภาพอื่นให้กับกรอบนั้นแทนการแทนที่ทรัพยากรที่แชร์

`replaceImage` also provides overloads that accept a byte array or another [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/).

## **คำแนะนำการจัดการรูปภาพในทางปฏิบัติ**

### **ควบคุมขนาดงานนำเสนอ**

รูปภาพราสเตอร์ขนาดใหญ่สามารถทำให้ไฟล์งานนำเสนอใหญ่มากเกินความจำเป็น ใช้รูปภาพต้นทางที่มีมิติที่เหมาะสมกับขนาดการแสดงผลที่ต้องการ, ใช้ทรัพยากรรูปภาพที่แชร์ซ้ำเมื่อเป็นไปได้, และหลีกเลี่ยงการฝังสำเนาซ้ำของกราฟิกความละเอียดเต็ม

สำหรับรูปภาพราสเตอร์ที่ได้วางไว้ในกรอบภาพแล้ว, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/) สามารถลดข้อมูลภาพตามความละเอียดและการตั้งค่าตัดที่เลือก นี่เป็นการประมวลผลกรอบภาพ ไม่ใช่การจัดการคอลเลกชันรูปภาพ, ดังนั้นดูที่ [กรอบภาพ](/slides/th/androidjava/picture-frame/) สำหรับการจัดรูปแบบที่เกี่ยวข้อง

### **เลือกระหว่างเนื้อหาฝังและเชื่อมโยง**

การฝังทำให้งานนำเสนอพกพาได้ง่ายเพราะข้อมูลรูปภาพทั้งหมดอยู่ในไฟล์เดียว การเชื่อมโยงสามารถลดขนาดไฟล์ได้ แต่จะมีการพึ่งพาแหล่งภายนอก ใช้ลิงก์เฉพาะเมื่อการพึ่งพานั้นเป็นที่ยอมรับและเสถียร

### **ใช้แบรนด์ที่แชร์ซ้ำ**

สำหรับโลโก้, ลายน้ำ หรือกราฟิกตกแต่งที่ใช้บ่อย, ใช้ทรัพยากรรูปภาพเดียวและใช้ซ้ำ หากกราฟิกเป็นส่วนของการออกแบบงานนำเสนอ ไม่ใช่เนื้อหาในสไลด์ ให้วางไว้บนมาสเตอร์หรือเลย์เอาต์เพื่อให้สไลด์ที่เหมาะสมสืบทอด

### **ทำให้ทรัพยากร SVG พกพาได้**

SVG ที่เป็นเอกสารอิสระง่ายต่อการย้ายและเรนเดอร์สม่ำเสมอกว่า SVG ที่พึ่งพาไฟล์หรือทรัพยากรเครือข่าย เมื่อเป็นไปได้ ใหฝังทรัพยากรที่จำเป็นก่อนนำเข้า SVG แปลง SVG เป็นรูปร่างเมื่อองค์ประกอบเวคเตอร์ต้องการการแก้ไขเท่านั้น

### **ใช้ API รูปภาพสมัยใหม่แบบข้ามแพลตฟอร์ม**

สำหรับโค้ด Android ผ่าน Java ใหม่ ให้ใช้ API Aspose.Slides [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) และ [Images](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/images/) แทน API สาธารณะรุ่นเก่าที่อิง `android.graphics.Bitmap` ดู [API สมัยใหม่](/slides/th/androidjava/modern-api/) สำหรับคำแนะนำการย้าย

WMF และ EMF ต้องพิจารณาเป็นพิเศษ เมื่อฟอร์แมตเหล่านี้ถูกส่งผ่าน [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imagecollection/) จะเปลี่ยนเมตาฟายล์เป็นการแสดงผล PNG ราสเตอร์ก่อนใส่ หากการรักษาข้อมูลเมตาฟายล์สำคัญ ให้ใช้ overload ของ [ImageCollection.addImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imagecollection/) ที่รับสตรีม แทน การสร้างเนื้อหา EMF จากสเปรดชีตหรือผลิตภัณฑ์อื่นเป็นกระบวนการรวมแยกต่างหากและอยู่นอกขอบเขตของบทความนี้

## **FAQ**

**ความแตกต่างระหว่างคอลเลกชันรูปภาพและกรอบภาพคืออะไร?**

คอลเลกชันรูปภาพเก็บทรัพยากรรูปภาพที่นำกลับมาใช้ใหม่ได้ กรอบภาพคือรูปร่างบนสไลด์ที่แสดงหนึ่งในทรัพยากรเหล่านั้นและให้การจัดรูปแบบเฉพาะภาพเช่นการตัดและเอฟเฟกต์

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันทุกที่คืออะไร?**

หากโลโก้ได้ถูกแชร์เป็นทรัพยากรรูปภาพเดียวแล้ว, ให้แทนที่ทรัพยากรนั้นด้วย [IPPImage.replaceImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) สำหรับการตั้งค่าแบรนด์ทั่วงานนำเสนอ, การวางโลโก้บนมาสเตอร์หรือเลย์เอาต์ก็ช่วยลดเนื้อหาที่ซ้ำในสไลด์ได้เช่นกัน

**ทำไมรูปภาพเชื่อมโยงถึงหายไปบนคอมพิวเตอร์เครื่องอื่น?**

รูปภาพเชื่อมโยงพึ่งพาไฟล์หรือ URL ภายนอก หากทรัพยากรนั้นไม่สามารถเข้าถึงจากคอมพิวเตอร์เครื่องอื่น รูปภาพเชื่อมโยงจะไม่พร้อมใช้งาน ฝังรูปภาพเมื่อจำเป็นต้องให้งานนำเสนอเป็นอิสระ

**สามารถแก้ไข SVG ที่แทรกเป็นรูปร่าง PowerPoint ได้หรือไม่?**

ได้. แปลง SVG ด้วย [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/) ซึ่งกลุ่มที่ได้จะประกอบด้วยรูปร่างสไลด์ที่แก้ไขได้ ไม่ใช่ภาพ SVG อย่างเดียว

**ฉันจะทำให้การนำเสนอที่มีรูปภาพจำนวนมากมีขนาดเล็กลงได้อย่างไร?**

ใช้ทรัพยากรรูปภาพที่แชร์ซ้ำ, หลีกเลี่ยงรูปภาพราสเตอร์ขนาดใหญ่โดยไม่จำเป็น, บีบอัดรูปภาพราสเตอร์ที่เหมาะสม, เก็บแบรนด์ที่ทำซ้ำไว้บนมาสเตอร์หรือเลย์เอาต์, และใช้รูปภาพเชื่อมโยงเฉพาะเมื่อการพึ่งพาภายนอกยอมรับได้