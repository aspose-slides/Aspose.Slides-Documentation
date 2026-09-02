---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในงานนำเสนอด้วย Java
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/java/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มรูป
- แทนที่รูปภาพ
- คอลเลกชันรูปภาพ
- กรอบรูป
- รูปภาพลิงก์
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- แปลง SVG เป็นรูปร่าง
- ทรัพยากร SVG ภายนอก
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, ใช้งานซ้ำ, ลิงก์, แทนที่และจัดการรูปภาพแรสเตอร์และ SVG ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java."
---
## **บทนำ**

Aspose.Slides for Java มีวิธีหลายวิธีในการทำงานกับรูปภาพ และแต่ละวิธีมีจุดประสงค์ที่แตกต่างกัน คุณสามารถจัดเก็บรูปภาพในงานนำเสนอ แสดงในกรอบรูป ใช้เป็นพื้นหลังของสไลด์ ลิงก์ไปยังรูปภาพภายนอก แทนที่ทรัพยากรรูปภาพที่ใช้ร่วมกัน หรือแปลงเนื้อหา SVG ให้เป็นรูปร่างที่แก้ไขได้

บทความนี้มุ่งเน้นที่ทรัพยากรรูปภาพและวิธีการใช้ทั่วทั้งงานนำเสนอ สำหรับการครอบตัด ความโปร่งใส เอฟเฟกต์ การยืด และการกำหนดรูปแบบอื่น ๆ ที่ใช้กับกรอบรูปเดี่ยว ดูที่ [Picture Frame](/slides/th/java/picture-frame/).

## **ทำความเข้าใจโมเดลรูปภาพ**

แนวคิด API ต่อไปนี้เกี่ยวข้องอย่างใกล้ชิดแต่ไม่สามารถใช้แทนกันได้:

- คอลเลกชันรูปภาพของงานนำเสนอ ([presentation image collection](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimagecollection/)) เก็บทรัพยากรรูปภาพที่ใช้ในงานนำเสนอ ใช้ [ImageCollection.addImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/imagecollection/) เพื่อเพิ่มข้อมูลรูปภาพและรับทรัพยากร [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) 
- กรอบรูป ([picture frame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframe/)) คือรูปทรงที่แสดงรูปภาพบนสไลด์, เค้าโครง หรือแม่แบบ ใช้ [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/) เพื่อวางทรัพยากรรูปภาพบนสไลด์
- พื้นหลังสไลด์ใช้รูปภาพเป็นส่วนหนึ่งของการเติมสไลด์ แทนที่จะเป็นรูปทรง ดังนั้นจึงไม่ทำงานเช่นกรอบรูป
- [IPPImage.replaceImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) แทนที่ทรัพยากรรูปภาพ หากหลายองค์ประกอบของงานนำใช้ทรัพยากรนั้น พวกเขาจะใช้รูปภาพที่เปลี่ยนแทนทั้งหมด
- การแปลง SVG เป็นรูปร่างจะสร้างรูปร่างสไลด์ที่สามารถแก้ไขได้ หลังจากการแปลง เนื้อหาไม่ถูกจัดการเป็นทรัพยากรรูปภาพเดียวอีกต่อไป

ดังนั้นขั้นตอนการทำงานทั่วไปคือ: เพิ่มข้อมูลรูปภาพลงในคอลเลกชันรูปภาพ รับ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/), แล้วใช้ทรัพยากรนั้นในหนึ่งหรือหลายกรอบรูปหรือการเติม

## **เพิ่มรูปภาพแบบฝัง**

เพื่อแทรกรูปภาพในเครื่อง ให้โหลดไฟล์ เพิ่มลงในคอลเลกชันรูปภาพ และสร้างกรอบรูปที่ใช้ `IPPImage` ที่ส่งกลับ

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

รูปภาพที่เพิ่มด้วยวิธีนี้จะถูกฝังไว้ในงานนำเสนอ ดังนั้นไฟล์ที่ได้จะไม่ขึ้นกับไฟล์รูปภาพต้นฉบับที่ยังคงอยู่

### **เพิ่มรูปภาพจากเว็บ**

เมื่อรูปภาพสามารถเข้าถึงได้ผ่าน HTTP หรือ HTTPS ให้ดาวน์โหลดไบต์ของรูปภาพ เพิ่มลงในคอลเลกชันรูปภาพของงานนำเสนอ และใช้ทรัพยากรรูปภาพที่ส่งกลับเช่นเดียวกับรูปภาพในเครื่อง

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

ในแอปพลิเคชันที่ทำงานเป็นเวลานาน ควรใช้คลไอเอนต์ HTTP หรือกลยุทธ์การจัดการการเชื่อมต่อที่เหมาะสมกับแอปพลิเคชันแทนการสร้างโครงสร้างเครือข่ายที่ไม่จำเป็นซ้ำ ๆ นอกจากนี้ควรตรวจสอบ URL ระยะไกล ขนาดของการตอบสนอง และประเภทของเนื้อหาเมื่อแหล่งที่มามิได้รับความเชื่อถือ

## **ใช้รูปภาพซ้ำในหลายสไลด์**

หากต้องการใช้รูปภาพเดียวกันหลายครั้ง ให้เพิ่มรูปนั้นลงในงานนำเสนอเพียงครั้งเดียวและใช้ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) ที่ส่งกลับเมื่อสร้างกรอบรูปเพิ่มเติม วิธีนี้ช่วยหลีกเลี่ยงการโหลดข้อมูลแหล่งเดียวซ้ำและทำให้ความสัมพันธ์ระหว่างทรัพยากรรูปภาพที่ใช้ร่วมกันกับการใช้งานของมันชัดเจน

สำหรับกราฟิกที่ควรปรากฏอัตโนมัติบนหลายสไลด์ เช่นโลโก้บริษัท ให้พิจารณาวางกรอบรูปบน [slide master](/slides/th/java/slide-master/) หรือเลย์เอาต์ แทนการเพิ่มรูปทรงที่เทียบเท่าในทุกสไลด์

## **ใช้รูปภาพเป็นพื้นหลังสไลด์**

รูปภาพพื้นหลังจะถูกกำหนดให้กับการเติมสไลด์; ไม่ได้เพิ่มเป็นรูปทรงกรอบรูป วิธีนี้มีประโยชน์เมื่อรูปต้องครอบพื้นหลังสไลด์และไม่ควรถูกจัดการเหมือนวัตถุสไลด์ทั่วไป

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

สำหรับตัวเลือกพื้นหลังเพิ่มเติม รวมถึงพื้นหลังของมาสเตอร์และเลย์เอาต์ ดูที่ [Presentation Background](/slides/th/java/presentation-background/)

## **รูปภาพฝังและรูปภาพลิงก์**

รูปภาพฝังและรูปภาพลิงก์มีการพิจารณาเรื่องการพกพาและขนาดไฟล์ที่แตกต่างกัน:

- **รูปภาพฝัง:** ข้อมูลรูปภาพถูกเก็บอยู่ภายในงานนำเสนอ งานนำเสนอเป็นไฟล์ที่สมบูรณ์ในตัวเอง แต่ขนาดไฟล์รวมถึงข้อมูลรูปภาพ
- **รูปภาพลิงก์:** งานนำเสนอเก็บเส้นทางหรือ URL ไปยังรูปภาพภายนอก ซึ่งสามารถลดขนาดงานนำเสนอได้ แต่ทรัพยากรภายนอกต้องยังคงเข้าถึงได้เมื่อเปิดหรือเรนเดอร์งานนำเสนอ

รูปภาพลิงก์สามารถสร้างได้โดยกำหนดเส้นทางหรือ URL ภายนอกผ่าน [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidespicture/) แทนการฝังข้อมูลรูปภาพ

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

ใช้รูปภาพลิงก์เฉพาะเมื่อสภาพแวดล้อมการปรับใช้สามารถเข้าถึงทรัพยากรภายนอกได้อย่างเชื่อถือได้ สำหรับงานนำเสนอที่ต้องทำงานแบบออฟไลน์หรือย้ายระหว่างระบบ รูปภาพฝังมักจะปลอดภัยกว่า

## **ทำงานกับรูปภาพ SVG**

SVG เป็นรูปแบบเวกเตอร์ ทำให้เหมาะสำหรับไอคอน แผนภูมิ และกราฟิกอื่น ๆ ที่ควรขยายได้โดยไม่สูญเสียรายละเอียดเหมือนรูปภาพแรสเตอร์ Aspose.Slides รองรับ SVG ทั้งเป็นทรัพยากรรูปภาพและเป็นแหล่งสำหรับรูปร่างสไลด์ที่แก้ไขได้

### **เพิ่ม SVG เป็นรูปภาพ**

สร้าง [SvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgimage/), เพิ่มลงในคอลเลกชันรูปภาพ และวางทรัพยากรรูปภาพที่ได้ในกรอบรูป

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

### **ไฟล์ SVG กับทรัพยากรภายนอก**

SVG สามารถอ้างอิงรูปภาพ ภาพสไตล์ชีต หรือฟอนต์ภายนอกได้ สำหรับกรณีเหล่านี้ [SvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgimage/) มีคอนสตรัคเตอร์ที่รับ [IExternalResourceResolver](https://reference.aspose.com/slides/th/java/com.aspose.slides/iexternalresourceresolver/) และ base URI ตัวแก้ไขสามารถแมป URI สัมพัทธ์ไปยัง URI แบบเต็มที่ได้รับอนุญาตและคืนสตรีมสำหรับทรัพยากรที่ร้องขอ

ตัวแก้ไขทำให้ทรัพยากรภายนอกพร้อมใช้งานขณะที่ Aspose.Slides ประมวลผล SVG แต่ไม่ได้เขียนใหม่ SVG ให้เป็นเอกสารที่มีตัวเอง หากต้องการให้ SVG พกพาได้ ควรฝังทรัพยากรที่จำเป็นไว้ใน SVG เอง เช่นโดยใช้ URI แบบ `data:` สำหรับรูปภาพลิงก์

เมื่อไฟล์ SVG มาจากแหล่งที่ไม่น่าเชื่อถือ ควรจำกัดสเคม, ตำแหน่งไฟล์, และโฮสต์ที่ตัวแก้ไขสามารถเข้าถึงได้ ตัวแก้ไขเครือข่ายควรกำหนดเวลา timeout, ขนาดการตอบสนองสูงสุด, และการตรวจสอบเนื้อหา

### **แปลง SVG เป็นรูปร่างที่แก้ไขได้**

Aspose.Slides สามารถแปลง SVG ให้เป็นกลุ่มของรูปร่างสไลด์ที่แก้ไขได้ คล้ายกับคำสั่งใน PowerPoint ที่สอดคล้อง

![PowerPoint Popup Menu](img_01_01.png)

ใช้ overload ของ [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/) ที่รับ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) เพื่อทำการแปลง

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ใช้การแปลง SVG เป็นรูปร่างเมื่อองค์ประกอบเวกเตอร์แต่ละตัวต้องการแก้ไขเป็นรูปร่าง PowerPoint หาก SVG เพียงต้องการแสดงผล การเก็บไว้เป็นรูปภาพจะง่ายกว่าและหลีกเลี่ยงการสร้างรูปร่างแยกหลาย ๆ รายการ

## **แทนที่ทรัพยากรรูปภาพที่มีอยู่**

ใช้ [IPPImage.replaceImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) เมื่อคุณต้องการแทนที่ทรัพยากรรูปภาพที่มีอยู่ วิธีนี้มีประโยชน์เป็นพิเศษสำหรับกราฟิกที่ใช้ร่วมกันเช่นโลโก้

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

หากหลายกรอบรูป, พื้นหลัง, มาสเตอร์หรือเลย์เอ์เทใช้ทรัพยากรรูปเดียวกัน การแทนที่ทรัพยากรนั้นจะอัพเดตการใช้ทั้งหมด หากต้องการเปลี่ยนเพียงกรอบรูปเดียว ให้กำหนดรูปภาพอื่นให้กับกรอบนั้นแทนการแทนที่ทรัพยากรที่ใช้ร่วม

`replaceImage` ยังมี overload ที่รับอาร์เรย์ไบต์หรือ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) อีกด้วย

## **แนวทางการจัดการรูปภาพเชิงปฏิบัติ**

### **ควบคุมขนาดงานนำเสนอ**

รูปภาพแรสเตอร์ขนาดใหญ่สามารถทำให้ขนาดงานนำเสนอเพิ่มขึ้นโดยไม่จำเป็น ใช้รูปภาพต้นฉบับที่มีมิติที่เหมาะสมกับขนาดการแสดงที่ต้องการ ใช้ทรัพยากรรูปภาพที่ใช้ร่วมกันเมื่อเป็นไปได้ และหลีกเลี่ยงการฝังสำเนาซ้ำของกราฟิกความละเอียดเต็มเดียวกัน

สำหรับรูปแรสเตอร์ที่ได้วางไว้ในกรอบรูปแล้ว [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/) สามารถลดข้อมูลรูปภาพตามความละเอียดและการตั้งค่าการครอบที่เลือก วิธีนี้เป็นการประมวลผลกรอบรูป ไม่ใช่การจัดการคอลเลกชันรูปภาพ ดังนั้นดูที่ [Picture Frame](/slides/th/java/picture-frame/) สำหรับการจัดรูปแบบที่เกี่ยวข้อง

### **เลือกระหว่างเนื้อหาแบบฝังและแบบลิงก์**

การฝังคือทำให้งานนำเสนอพกพาได้เนื่องจากข้อมูลรูปภาพทั้งหมดอยู่ในไฟล์เดียว การลิงก์สามารถลดขนาดไฟล์ได้ แต่จะสร้างการพึ่งพาภายนอก ใช้ลิงก์เฉพาะเมื่อการพึ่งพานั้นยอมรับได้และเสถียร

### **ใช้แบรนด์ที่ใช้ร่วมกันซ้ำ**

สำหรับโลโก้, ลายน้ำ หรือกราฟิกตกแต่งที่ใช้ซ้ำ ให้ใช้ทรัพยากรรูปภาพเดียวและใช้งานซ้ำ หากกราฟิกเป็นส่วนหนึ่งของการออกแบบงานนำเสนอไม่ใช่เนื้อหาสไลด์ ให้วางไว้บนมาสเตอร์หรือเลย์เอาต์เพื่อให้สไลด์ที่เหมาะสมสืบทอด

### **ทำให้ทรัพยากร SVG พกพาได้**

SVG ที่เป็นเอกสารอิสระง่ายต่อการย้ายและเรนเดอร์อย่างสม่ำเสมอกว่า SVG ที่พึ่งพาไฟล์หรือทรัพยากรเครือข่ายภายนอก เมื่อเป็นไปได้ ควรฝังทรัพยากรที่จำเป็นก่อนนำเข้า SVG แปลง SVG เป็นรูปร่างเฉพาะเมื่อองค์ประกอบเวกเตอร์ต้องการแก้ไข

### **ใช้ Modern Cross-Platform Image API**

สำหรับโค้ด Java ใหม่ ให้ใช้ API ของ Aspose.Slides [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) และ [Images](https://reference.aspose.com/slides/th/java/com.aspose.slides/images/) แทน API สาธารณะรุ่นเก่าที่อิงจาก `java.awt.image.BufferedImage` ดูที่ [Modern API](/slides/th/java/modern-api/) สำหรับคำแนะนำการย้าย

WMF และ EMF ต้องการการพิจารณาพิเศษ เมื่อรูปแบบเหล่านี้ถูกส่งผ่าน [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/imagecollection/) จะแปลงเมตาไฟล์เป็นรูปแบบ PNG แรสเตอร์ก่อนใส่ หากต้องการรักษาข้อมูลเมตาไฟล์ ควรใช้ overload ของ [ImageCollection.addImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/imagecollection/) ที่รับสตรีม แทน การสร้างเนื้อหา EMF จากสเปรดชีตหรือผลิตภัณฑ์อื่นเป็นกระบวนการบูรณาการแยกต่างหากและอยู่นอกขอบเขตของบทความนี้

## **FAQ**

**ความแตกต่างระหว่างคอลเลกชันรูปภาพและกรอบรูปคืออะไร?**

คอลเลกชันรูปภาพเก็บทรัพยากรรูปภาพที่ใช้ซ้ำได้ กรอบรูปเป็นรูปทรงบนสไลด์ที่แสดงหนึ่งในทรัพยากรเหล่านั้นและให้การจัดรูปแบบเฉพาะรูปภาพเช่นการครอบตัดและเอฟเฟกต์

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันทุกที่คืออะไร?**

หากโลโก้ถูกแชร์เป็นทรัพยากรรูปภาพเดียวแล้ว ให้แทนที่ทรัพยากรนั้นด้วย [IPPImage.replaceImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) สำหรับการสร้างแบรนด์ทั่วทั้งงานนำเสนอ การวางโลโก้บนมาสเตอร์หรือเลย์เอาต์ก็สามารถลดเนื้อหาสไลด์ที่ซ้ำซ้อนได้

**ทำไมรูปภาพลิงก์ถึงหายไปบนคอมพิวเตอร์เครื่องอื่น?**

รูปภาพลิงก์ขึ้นกับไฟล์หรือ URL ภายนอก หากไม่สามารถเข้าถึงทรัพยากรนั้นจากคอมพิวเตอร์เครื่องอื่น รูปภาพลิงก์อาจไม่มีให้ใช้ ฝังรูปภาพเมื่อจำเป็นต้องทำให้งานนำเสนอเป็นไฟล์เดียว

**สามารถแก้ไข SVG ที่แทรกเป็นรูปร่าง PowerPoint ได้หรือไม่?**

ได้ ใช้แปลง SVG ด้วย [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/) ; กลุ่มที่ได้จะมีรูปร่างสไลด์ที่แก้ไขได้แทนการเป็นรูป SVG เพียงหนึ่งรูป

**ทำอย่างไรให้งานนำเสนอที่มีรูปภาพจำนวนมากมีขนาดเล็กลง?**

ใช้ทรัพยากรรูปภาพที่ใช้ร่วมกันซ้ำ หลีกเลี่ยงแหล่งรูปแรสเตอร์ที่ใหญ่เกินความจำเป็น บีบอัดรูปแรสเตอร์ที่เหมาะสมเมื่อจำเป็น เก็บแบรนด์ที่ซ้ำกันบนมาสเตอร์หรือเลย์เอาต์ และใช้รูปภาพลิงก์เฉพาะเมื่อการพึ่งพาภายนอกยอมรับได้