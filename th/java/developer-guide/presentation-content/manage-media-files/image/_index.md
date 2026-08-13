---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในการนำเสนอโดยใช้ Java
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/java/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มภาพ
- เพิ่มบิตแมพ
- แทนที่รูปภาพ
- แทนที่ภาพ
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- แหล่งข้อมูล SVG ภายนอก
- ตัวแก้ไข SVG
- ภาพ SVG ที่เชื่อมโยง
- ฟอนต์ SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ทำให้การจัดการรูปภาพใน PowerPoint และ OpenDocument ง่ายขึ้นด้วย Aspose.Slides สำหรับ Java, เพิ่มประสิทธิภาพการทำงานและอัตโนมัติขั้นตอนของคุณ."
---
## **บทนำ**

ภาพทำให้การนำเสนอมีความดึงดูดและน่าสนใจมากขึ้น. ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพลงในสไลด์จากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ. ในทำนองเดียวกัน Aspose.Slides อนุญาตให้คุณเพิ่มรูปภาพเข้าไปในสไลด์การนำเสนอได้หลายวิธี.

{{% alert  title="เคล็ดลับ" color="info" %}} 
Aspose มีตัวแปลงฟรี —[JPEG ถึง PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG ถึง PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt) — ที่ช่วยให้คุณสร้างการนำเสนอจากรูปภาพได้อย่างรวดเร็ว. 
{{% /alert %}} 

{{% alert title="ข้อมูล" color="info" %}}
หากคุณต้องการเพิ่มรูปภาพเป็นกรอบรูป — โดยเฉพาะอย่างยิ่งถ้าคุณตั้งใจจะปรับขนาด ใช้เอฟเฟกต์ หรือใช้ตัวเลือกการจัดรูปแบบมาตรฐานอื่น ๆ — ดูที่ [กรอบรูป](/slides/th/java/picture-frame/). 
{{% /alert %}} 

{{% alert title="หมายเหตุ" color="warning" %}}
คุณสามารถแปลงรูปภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้. ดูหน้าต่อไปนี้: แปลง [ภาพเป็น JPG](https://products.aspose.com/slides/th/java/conversion/image-to-jpg/), [JPG เป็นภาพ](https://products.aspose.com/slides/th/java/conversion/jpg-to-image/), [JPG เป็น PNG](https://products.aspose.com/slides/th/java/conversion/jpg-to-png/), [PNG เป็น JPG](https://products.aspose.com/slides/th/java/conversion/png-to-jpg/), [PNG เป็น SVG](https://products.aspose.com/slides/th/java/conversion/png-to-svg/), และ [SVG เป็น PNG](https://products.aspose.com/slides/th/java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides รองรับรูปภาพในรูปแบบยอดนิยม เช่น JPEG, PNG, BMP, GIF และรูปแบบอื่น ๆ. 

## **เพิ่มรูปภาพที่เก็บไว้ในเครื่องลงในสไลด์**

คุณสามารถเพิ่มรูปภาพหนึ่งหรือหลายรูปที่เก็บไว้บนคอมพิวเตอร์ของคุณลงในสไลด์การนำเสนอ. ตัวอย่างโค้ด Java ด้านล่างแสดงวิธีการเพิ่มรูปภาพลงในสไลด์:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **เพิ่มรูปภาพจากเว็บลงในสไลด์**

หากรูปภาพที่คุณต้องการเพิ่มลงในสไลด์ไม่ได้เก็บไว้บนคอมพิวเตอร์ของคุณ คุณสามารถเพิ่มได้โดยตรงจากเว็บ.

ตัวอย่างโค้ด Java ด้านล่างแสดงวิธีการเพิ่มรูปภาพจากเว็บลงในสไลด์:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **เพิ่มรูปภาพลงใน Slide Master**

Slide Master จัดเก็บและควบคุมข้อมูลเช่นธีมและเค้าโครงสำหรับสไลด์ที่ใช้มัน. เมื่อคุณเพิ่มรูปภาพลงใน Slide Master รูปภาพนั้นจะปรากฏบนทุกสไลด์ที่อิงกับมาสเตอร์นั้น.

ตัวอย่างโค้ด Java ด้านล่างแสดงวิธีการเพิ่มรูปภาพลงใน Slide Master:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **เพิ่มรูปภาพเป็นพื้นหลังของสไลด์**

คุณสามารถใช้รูปภาพเป็นพื้นหลังสำหรับหนึ่งหรือหลายสไลด์. รายละเอียดเพิ่มเติมดูที่ *[ตั้งค่ารูปภาพเป็นพื้นหลังของสไลด์](/slides/th/java/presentation-background/#setting-images-as-background-for-slides)*.

## **เพิ่ม SVG ไปยังการนำเสนอ**

เนื้อหา SVG สามารถเพิ่มไปยังการนำเสนอโดยใช้คลาส [SvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgimage/) ผลลัพธ์ที่ได้คืออ็อบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) ซึ่งสามารถเพิ่มไปยังคอลเลกชันรูปภาพของการนำเสนอและใช้สร้างกรอบรูปได้.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **นำเข้าเนื้อหา SVG พร้อมทรัพยากรภายนอก**

ไฟล์ SVG ที่ส่งออกจากเครื่องมือออกแบบ ตัวแก้ไขไดอะแกรม ระบบไอคอน และ pipeline บนเว็บอาจอ้างอิงทรัพยากรที่เก็บนอกเอกสาร SVG. ตัวอย่างเช่น SVG อาจมีลิงก์รูปภาพเช่น `images/photo.png`, ค่า CSS `url(...)`, หรือ URL ฟอนต์.

เพื่อทำการนำเข้าเนื้อหา SVG แบบนี้ให้สร้างการดำเนินการของ [IExternalResourceResolver](https://reference.aspose.com/slides/th/java/com.aspose.slides/iexternalresourceresolver/) และส่งต่อพร้อมกับ base URI ไปยังตัวสร้าง [SvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgimage/) ที่เหมาะสม. base URI ระบุตำแหน่งของเอกสาร SVG และใช้ในการแก้ลิงก์สัมพันธ์.

อินเทอร์เฟซ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) ให้เข้าถึงข้อมูลของ SVG ที่นำเข้า:

- `getSvgContent()` คืนค่า markup ของ SVG เป็นสตริง.
- `getSvgData()` คืนค่าเนื้อหา SVG เป็นอาเรย์ไบต์.
- `getBaseUri()` คืนค่า base URI ที่ใช้สำหรับลิงก์สัมพันธ์.
- `getExternalResourceResolver()` คืนค่าตัวแก้ไขที่กำหนดให้กับรูปภาพ SVG.

### **สร้างตัวแก้ไขทรัพยากรภายนอก**

ตัวแก้ไขมีสองเมธอด:

- `resolveUri` รวม base URI กับลิงก์ทรัพยากรสัมพันธ์และคืนค่า URI แบบเต็ม. คืนค่า `null` เมื่อไม่สามารถแก้ลิงก์ได้หรือไม่ได้รับอนุญาต.
- `getEntity` คืนสตรีมที่อ่านได้สำหรับ URI ทรัพยากรแบบเต็ม. คืนค่า `null` เมื่อทรัพยากรหาย, ถูกบล็อก, หรือไม่พร้อมใช้งาน. สามารถคืนสตรีมสำรองได้เมื่อเหมาะสม.

ตัวอย่างต่อไปโหลดทรัพยากรที่เชื่อมโยงเฉพาะจากไดเร็กทอรีท้องถิ่นที่อนุญาต. ทรัพยากรเครือข่ายและเส้นทางนอกไดเร็กทอรีที่อนุญาตจะถูกบล็อก. ภาพสำรองทางเลือกจะถูกคืนสำหรับลิงก์รูปภาพที่ไม่สามารถแก้ได้.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // ตัวแก้ไขนี้ตั้งใจให้อนุญาตไฟล์ภายในเครื่องเท่านั้น.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // ใช้ภาพสำรองเฉพาะสำหรับทรัพยากรรูปภาพ การคืนสตรีมรูปภาพ
            // สำหรับฟอนต์หรือสไตล์ชีทที่หายจะไม่เป็นค่าใช้ได้.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **แก้ลิงก์ทรัพยากรระหว่างการนำเข้า SVG**

สมมติว่า `assets/diagram.svg` มีการอ้างอิงสัมพันธ์เช่น:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

ตัวอย่าง Java ด้านล่างส่งผ่าน URI ของไฟล์ SVG เป็น base URI และให้ตัวแก้ไขที่กำหนดเอง. ตัวแก้ไขจะแปลงลิงก์รูปภาพสัมพันธ์เป็น URI แบบเต็มและคืนสตรีมที่มีทรัพยากรเชื่อมโยงขณะที่ Aspose.Slides ประมวลผล SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Base URI แสดงตำแหน่งที่ตั้งของเอกสาร SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage เปิดเผยเนื้อหาแหล่งที่มา, ข้อมูลไบต์, base URI, และตัวแก้ไข.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

คลาส `SvgImage` ยังมีโอเวอร์โหลดที่รับข้อมูล SVG เป็นอาเรย์ไบต์หรือสตรีมอินพุตพร้อมตัวแก้ไขทรัพยากรภายนอกและ base URI.

{{% alert title="สำคัญ" color="warning" %}}
ตัวแก้ไขทรัพยากรทำให้ทรัพยากรภายนอกพร้อมใช้ขณะ Aspose.Slides ประมวลผลและแสดงผล SVG. ตัวแก้ไขไม่ได้แก้ไข markup ของ SVG ต้นฉบับหรือฝังทรัพยากรที่แก้ไขโดยอัตโนมัตเข้าไป.

เมื่อ `ISvgImage` ถูกเพิ่มไปยังคอลเลกชันรูปภาพของการนำเสนอ ไฟล์ PPTX อาจมีทั้งการแสดงผล SVG ดั้งเดิมและภาพสแน็ปแบบแรสเตอร์. ทรัพยากรที่เชื่อมโยงอาจปรากฏในภาพสำรองที่สร้างขึ้นในขณะที่ลิงก์สัมพันธ์เช่น `images/photo.png` ยังคงอยู่โดยไม่เปลี่ยนแปลงใน SVG ที่เก็บไว้. แอปพลิเคชันที่แสดงผล SVG ดั้งเดิมอาจละเว้นเนื้อหาที่เชื่อมโยงเมื่อทรัพยากรภายนอกไม่พร้อมใช้. 
{{% /alert %}}

### **สร้างภาพ SVG แบบพกพา**

เพื่อสร้างภาพ SVG ที่ไม่พึ่งพาไฟล์ภายนอก ให้ทำให้ SVG เป็นอิสระก่อนสร้าง `SvgImage`. ตัวอย่างเช่น แทนที่ URL ของรูปภาพที่เชื่อมโยงด้วย URI `data:` ที่มีข้อมูลภาพอยู่ภายใน:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

เมื่อฝังทรัพยากรทั้งหมดลงในเนื้อหา SVG แล้ว ให้สร้าง `SvgImage`, เพิ่มลงในคอลเลกชันรูปภาพของการนำเสนอ และแทรกลงในกรอบรูปตามตัวอย่างก่อนหน้า.

### **จัดการกับทรัพยากรที่หายหรือถูกบล็อก**

คืนค่า `null` จาก `resolveUri` เมื่อ URI ของทรัพยากรไม่ถูกต้อง, ถูกห้าม, หรือไม่สามารถแก้ได้. คืนค่า `null` จาก `getEntity` เมื่อไม่สามารถอ่านทรัพยากรได้. Aspose.Slides จะดำเนินการต่อกับ SVG โดยไม่มีทรัพยากรนั้นหากเป็นไปได้.

สามารถคืนสตรีมสำรองสำหรับทรัพยากรที่หายได้, แต่เนื้อหาต้องสอดคล้องกับประเภททรัพยากรที่ร้องขอ. ตัวอย่างเช่น คืนสตรีมภาพเฉพาะสำหรับรูปภาพที่หาย, ไม่ใช่สำหรับฟอนต์หรือสไตล์ชีต.

{{% alert title="ความปลอดภัย" color="warning" %}}
ห้ามแก้ไขเส้นทางไฟล์ใด ๆ หรือ URL เครือข่ายที่ไม่มีการจำกัดจากไฟล์ SVG ที่ไม่น่าเชื่อถือ. จำกัดสกีมที่อนุญาต, ไดเร็กทอรี, และโฮสต์. สำหรับทรัพยากรเครือข่าย ควรกำหนดเวลาเชื่อมต่อ, ขีดจำกัดขนาดการตอบกลับ, และการตรวจสอบความถูกต้องของเนื้อหา. 
{{% /alert %}}

## **แปลง SVG เป็นชุดของรูปร่าง**

Aspose.Slides สามารถแปลง SVG ให้เป็นชุดของรูปร่างได้, คล้ายกับฟังก์ชันที่มีใน PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ให้บริการโดยการโอเวอร์โหลดของเมธอด [addGroupShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) ของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection) ที่รับอ็อบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISvgImage) เป็นอาร์กิวเมนต์แรก.

โค้ดตัวอย่าง Java ด้านล่างแสดงวิธีใช้เมธอดนี้เพื่อแปลงไฟล์ SVG เป็นชุดของรูปร่าง:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// ชื่อไฟล์ SVG ต้นฉบับ.
String svgFileName = "sample.svg";

// ชื่อไฟล์การนำเสนอผลลัพธ์.
String outPptxPath = "presentation.pptx";

// สร้างการนำเสนอใหม่.
IPresentation presentation = new Presentation();
try {
    // อ่านเนื้อหาไฟล์ SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // สร้างอ็อบเจ็กต์ SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // รับขนาดสไลด์.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // แปลงภาพ SVG เป็นกลุ่มของรูปร่างและปรับขนาดให้ตรงกับสไลด์.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // บันทึกการนำเสนอในรูปแบบ PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **เพิ่มรูปภาพเป็น EMF ลงในสไลด์**

Aspose.Slides for Java อนุญาตให้คุณสร้างรูปภาพ EMF จากแผ่นงาน Excel ด้วย Aspose.Cells และเพิ่มลงในสไลด์การนำเสนอ.

โค้ดตัวอย่าง Java ด้านล่างแสดงวิธีทำ:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// บันทึกเวิร์กบุ๊กไปยังสตรีม.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // เพิ่มไฟล์โดยตรงเพื่อให้รูปภาพยังคงเป็นเวกเตอร์ EMF แทนที่จะถูกแปลงเป็นแรสเตอร์.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **แทนที่รูปภาพในคอลเลกชันรูปภาพ**

Aspose.Slides ให้คุณแทนที่รูปภาพที่เก็บอยู่ในคอลเลกชันรูปภาพของการนำเสนอ, รวมถึงรูปภาพที่ใช้โดยรูปร่างสไลด์. ส่วนนี้อธิบายหลายวิธีในการอัปเดตรูปภาพในคอลเลกชัน. คุณสามารถแทนที่รูปภาพโดยใช้ข้อมูลไบต์ดิบ, อินสแตนซ์ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/), หรือรูปภาพอื่นที่มีอยู่แล้วในคอลเลกชัน.

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์การนำเสนอที่มีรูปภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
1. โหลดรูปภาพใหม่จากไฟล์เข้าสู่อาเรย์ไบต์.
1. แทนที่รูปภาพเป้าหมายด้วยรูปภาพใหม่โดยใช้ไอเท็มไบต์.
1. ในวิธีที่สอง, โหลดรูปภาพเข้าสู่อ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) แล้วแทนที่รูปภาพเป้าหมายด้วยอ็อบเจ็กต์นั้น.
1. ในวิธีที่สาม, แทนที่รูปภาพเป้าหมายด้วยรูปภาพที่มีอยู่แล้วในคอลเลกชันรูปภาพของการนำเสนอ.
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // วิธีแรก.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // วิธีที่สอง.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // วิธีที่สาม.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // บันทึกการนำเสนอลงไฟล์.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="ข้อมูล" color="info" %}}
ด้วยตัวแปลงฟรีของ Aspose ที่ชื่อ [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) คุณสามารถทำให้ข้อความเป็นภาพเคลื่อนไหวและสร้าง GIF จากข้อความได้อย่างง่ายดาย. 
{{% /alert %}}

## **FAQ**

**การรักษาความละเอียดของรูปภาพเดิมหลังจากแทรกหรือไม่?**

ใช่. พิกเซลต้นฉบับจะถูกเก็บไว้, แต่การแสดงผลสุดท้ายขึ้นอยู่กับการสเกลของ [picture](/slides/th/java/picture-frame/) บนสไลด์และการบีบอัดที่ใช้เมื่อบันทึก.

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันในหลายสิบสไลด์พร้อมกันคืออะไร?**

วางโลโก้บนมาสเตอร์สไลด์หรือเลเอาต์และแทนที่ในคอลเลกชันรูปภาพของการนำเสนอ — การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น.

**SVG ที่แทรกเข้ามาสามารถแปลงเป็นรูปร่างที่แก้ไขได้หรือไม่?**

ได้. คุณสามารถแปลง SVG ให้เป็นกลุ่มของรูปร่าง, หลังจากนั้นส่วนประกอบแต่ละส่วนจะสามารถแก้ไขได้ด้วยคุณสมบัติโครงสร้างมาตรฐาน.

**ฉันจะตั้งค่าภาพเป็นพื้นหลังสำหรับหลายสไลด์พร้อมกันอย่างไร?**

[กำหนดภาพเป็นพื้นหลัง](/slides/th/java/presentation-background/) บนมาสเตอร์สไลด์หรือเลเอาต์ที่เกี่ยวข้อง — สไลด์ที่ใช้มาสเตอร์/เลเอาต์นั้นจะสืบทอดพื้นหลังโดยอัตโนมัติ.

**ฉันจะป้องกันไม่ให้การนำเสนอใหญ่เกินไปเนื่องจากมีรูปภาพจำนวนมากได้อย่างไร?**

ใช้ทรัพยากรรูปภาพเดียวซ้ำแทนการทำสำเนา, เลือกความละเอียดที่เหมาะสม, ใช้การบีบอัดเมื่อบันทึก, และเก็บกราฟิกที่ใช้บ่อยไว้บนมาสเตอร์เมื่อเป็นไปได้.