---
title: เพิ่มประสิทธิภาพการจัดการภาพในงานนำเสนอบน Android
linktitle: จัดการภาพ
type: docs
weight: 10
url: /th/androidjava/image/
keywords:
- เพิ่มภาพ
- เพิ่มรูปภาพ
- เพิ่มบิตแมพ
- แทนที่ภาพ
- แทนที่รูปภาพ
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- ทรัพยากร SVG ภายนอก
- ตัวแก้ปัญหา SVG
- ภาพ SVG ที่เชื่อมโยง
- ฟอนท์ SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ทำให้การจัดการภาพใน PowerPoint และ OpenDocument ราบรื่นด้วย Aspose.Slides สำหรับ Android via Java, เพิ่มประสิทธิภาพการทำงานและอัตโนมัติขั้นตอนการทำงานของคุณ."
---
## **บทนำ**

ภาพทำให้การนำเสนอมีความน่าสนใจและดึงดูดสายตามากขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพลงในสไลด์จากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ เช่นเดียวกับ Aspose.Slides ที่ให้คุณเพิ่มภาพลงในสไลด์การนำเสนอได้หลายวิธี

{{% alert  title="เคล็ดลับ" color="info" %}} 

Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้คุณสร้างการนำเสนอจากภาพได้อย่างรวดเร็ว

{{% /alert %}} 

{{% alert title="ข้อมูล" color="info" %}}

หากต้องการเพิ่มภาพเป็นกรอบรูป—โดยเฉพาะอย่างยิ่งหากคุณวางแผนที่จะปรับขนาด ใช้เอฟเฟกต์ หรือใช้ตัวเลือกการจัดรูปแบบมาตรฐานอื่น ๆ—ดูที่ [Picture Frame](/slides/th/androidjava/picture-frame/)

{{% /alert %}} 

{{% alert title="หมายเหตุ" color="warning" %}}

คุณสามารถแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้ ดูหน้าเหล่านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/androidjava/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/th/androidjava/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/th/androidjava/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/th/androidjava/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/th/androidjava/conversion/png-to-svg/), และ [SVG to PNG](https://products.aspose.com/slides/th/androidjava/conversion/svg-to-png/)

{{% /alert %}}

Aspose.Slides รองรับภาพในรูปแบบที่นิยมเช่น JPEG, PNG, BMP, GIF และอื่น ๆ

## **เพิ่มภาพที่เก็บไว้ในเครื่องลงในสไลด์**

คุณสามารถเพิ่มภาพหนึ่งภาพหรือหลายภาพที่เก็บไว้ในคอมพิวเตอร์ของคุณลงในสไลด์การนำเสนอ โค้ดตัวอย่าง Java ด้านล่างแสดงวิธีการเพิ่มภาพลงในสไลด์:

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

## **เพิ่มภาพจากเว็บลงในสไลด์**

หากภาพที่คุณต้องการเพิ่มลงในสไลด์ไม่ได้เก็บไว้ในเครื่อง คุณสามารถเพิ่มโดยตรงจากเว็บ

โค้ดตัวอย่าง Java ด้านล่างแสดงวิธีการเพิ่มภาพจากเว็บลงในสไลด์:

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

## **เพิ่มภาพลงใน Slide Masters**

Slide master เก็บและควบคุมข้อมูลเช่นธีมและเลย์เอาต์สำหรับสไลด์ที่ใช้มัน เมื่อคุณเพิ่มภาพลงใน slide master ภาพนั้นจะปรากฏในทุกสไลด์ที่อิงกับ master นั้น

โค้ดตัวอย่าง Java ด้านล่างแสดงวิธีการเพิ่มภาพลงใน slide master:

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

## **เพิ่มภาพเป็นพื้นหลังของสไลด์**

คุณสามารถใช้รูปภาพเป็นพื้นหลังสำหรับสไลด์หนึ่งหรือหลายสไลด์ ดูรายละเอียดได้ที่ *[Setting Images as Backgrounds for Slides](/slides/th/androidjava/presentation-background/#setting-images-as-background-for-slides)*

## **เพิ่ม SVG ลงในการนำเสนอ**

เนื้อหา SVG สามารถเพิ่มลงในการนำเสนอได้โดยใช้คลาส [SvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgimage/) วัตถุ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) ที่ได้สามารถเพิ่มลงในคอลเลกชันภาพของการนำเสนอและใช้สร้างกรอบรูปได้

โค้ดตัวอย่าง Java ด้านล่างนำเข้า SVG string ที่เป็น self‑contained ทั้งภาพ สไตล์ และทรัพยากรอื่น ๆ ถูกฝังโดยตรงในเนื้อหา SVG:

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

ไฟล์ SVG ที่ส่งออกจากเครื่องมือออกแบบ ตัวแก้ไขไดอะแกรม ระบบไอคอน และ pipeline บนเว็บอาจอ้างอิงทรัพยากรที่เก็บไว้ภายนอกเอกสาร SVG ตัวอย่างเช่น SVG อาจมีลิงก์รูปภาพเช่น `images/photo.png` ค่า CSS `url(...)` หรือ URL ของฟอนต์

เพื่อทำการนำเข้าเนื้อหา SVG ดังกล่าว ให้สร้างการนำไปใช้ของ [IExternalResourceResolver](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iexternalresourceresolver/) แล้วส่งพร้อมกับ base URI ไปยังตัวสร้าง [SvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgimage/) ที่เหมาะสม Base URI ระบุตำแหน่งของเอกสาร SVG และใช้เพื่อแก้ลิงก์แบบ relative

อินเทอร์เฟซ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) ให้การเข้าถึงข้อมูลเกี่ยวกับ SVG ที่นำเข้า:

- `getSvgContent()` คืนค่า markup ของ SVG เป็นสตริง
- `getSvgData()` คืนค่าเนื้อหา SVG เป็นอาเรย์ของไบต์
- `getBaseUri()` คืนค่า base URI ที่ใช้สำหรับลิงก์แบบ relative
- `getExternalResourceResolver()` คืนค่าตัว resolve ที่กำหนดให้กับภาพ SVG

### **ดำเนินการสร้าง External Resource Resolver**

ตัว resolver มีสองเมธอด:

- `resolveUri` รวม base URI กับลิงก์ทรัพยากรแบบ relative แล้วคืนค่า URI แบบ absolute คืนค่า `null` เมื่อไม่สามารถแก้ลิงก์หรือไม่อนุญาต
- `getEntity` คืนสตรีมที่อ่านได้สำหรับ URI ของทรัพยากรแบบ absolute คืนค่า `null` เมื่อทรัพยากรหาย บล็อก หรือไม่พร้อมใช้งาน สตรีมสำรองอาจคืนค่าได้เมื่อเหมาะสม

โค้ดตัวอย่างด้านล่างโหลดทรัพยากรที่เชื่อมโยงเฉพาะจากไดเรกทอรีที่อนุญาต ทรัพยากรเครือข่ายและเส้นทางที่อยู่นอกไดเรกทอรีที่อนุญาตจะถูกบล็อก รูปภาพสำรองแบบเลือกจะถูกคืนค่าเมื่อไม่สามารถแก้ลิงก์รูปภาพได้

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

            // ตัวแก้ปัญหานี้ตั้งใจให้อนุญาตเฉพาะไฟล์ในเครื่องเท่านั้น.
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

            // ใช้ภาพสำรองเฉพาะสำหรับทรัพยากรรูปภาพเท่านั้น การคืนสตรีมภาพ
            // สำหรับฟอนท์หรือสไตล์ชีตที่หายไปจะไม่เป็นไปได้.
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

สมมติว่า `assets/diagram.svg` มีการอ้างอิงแบบ relative เช่น:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

โค้ดตัวอย่าง Java ด้านล่างส่ง URI ของไฟล์ SVG เป็น base URI และจัดเตรียม resolver ที่กำหนดเอง Resolver จะเปลี่ยนลิงก์รูปภาพแบบ relative ให้เป็น URI แบบ absolute และคืนสตรีมที่มีทรัพยากรที่เชื่อมโยงขณะ Aspose.Slides ประมวลผล SVG

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// base URI แสดงตำแหน่งของเอกสาร SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
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

คลาส `SvgImage` ยังมี overload ที่รับข้อมูล SVG เป็นอาเรย์ของไบต์หรือสตรีมอินพุต พร้อมกับ external resource resolver และ base URI

{{% alert title="สำคัญ" color="warning" %}}

ตัว resolver ทำให้ทรัพยากรภายนอกพร้อมใช้งานขณะ Aspose.Slides ประมวลผลและเรนเดอร์ SVG โดยไม่แก้ไข markup ของ SVG ดั้งเดิมหรือฝังทรัพยากรที่แก้ไขเข้าไปโดยอัตโนมัติ

เมื่อ `ISvgImage` ถูกเพิ่มลงในคอลเลกชันภาพของการนำเสนอ ไฟล์ PPTX อาจมีทั้งการแสดงผล SVG ดั้งเดิมและรูปภาพ raster สำรอง ทรัพยากรที่เชื่อมโยงอาจปรากฏในรูปภาพสำรองที่สร้างขึ้น ในขณะที่ลิงก์แบบ relative เช่น `images/photo.png` จะคงเดิมใน SVG ที่จัดเก็บ แอปพลิเคชันที่เรนเดอร์ SVG แบบดั้งเดิมอาจละเว้นเนื้อหาที่เชื่อมโยงเมื่อทรัพยากรภายนอกต้นฉบับไม่พร้อมใช้งาน

{{% /alert %}}

### **สร้างรูปภาพ SVG แบบพกพา**

เพื่อสร้างรูปภาพ SVG ที่ไม่พึ่งพาไฟล์ภายนอก ทำให้ SVG เป็น self‑contained ก่อนสร้าง `SvgImage` ตัวอย่างเช่นแทนที่ URL ของรูปภาพที่เชื่อมโยงด้วย URI แบบ `data:` ที่รวมข้อมูลภาพ:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

เมื่อติดตั้งทรัพยากรทั้งหมดที่จำเป็นลงในเนื้อหา SVG แล้ว สร้าง `SvgImage` เพิ่มลงในคอลเลกชันภาพของการนำเสนอ และแทรกลงในกรอบรูปตามตัวอย่างก่อนหน้า

### **จัดการทรัพยากรที่หายหรือถูกบล็อก**

คืนค่า `null` จาก `resolveUri` เมื่อ URI ของทรัพยากรไม่ถูกต้อง ห้ามใช้ หรือไม่สามารถแก้ได้ คืนค่า `null` จาก `getEntity` เมื่อไม่สามารถอ่านทรัพยากรได้ Aspose.Slides จะดำเนินการต่อโดยไม่มีทรัพยากรนั้นหากเป็นไปได้

สตรีมสำรองสามารถคืนค่าได้สำหรับทรัพยากรที่หาย แต่เนื้อหาต้องสอดคล้องกับประเภททรัพยากรที่ร้องขอ ตัวอย่างเช่นคืนสตรีมภาพเท่าสำหรับรูปภาพที่หาย ไม่ใช่สำหรับฟอนต์หรือสไตล์ชีท

{{% alert title="ความปลอดภัย" color="warning" %}}

ห้ามแก้ไขลิงก์ไฟล์ใด ๆ หรือ URL เครือข่ายที่ไม่จำกัดจากไฟล์ SVG ที่ไม่ได้รับความเชื่อถือ จำกัดสกีม ไดเรกทอรี และโฮสต์ที่อนุญาต สำหรับทรัพยากรเครือข่าย ควรตั้งค่า timeout การเชื่อมต่อ ขีดจำกัดขนาดการตอบกลับ และการตรวจสอบความถูกต้องของเนื้อหา

{{% /alert %}}

## **แปลง SVG เป็นชุดรูปทรง**

Aspose.Slides สามารถแปลง SVG เป็นชุดรูปทรงได้เช่นเดียวกับฟังก์ชันที่สอดคล้องใน PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ให้โดย overload ของเมธอด [addGroupShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) ในอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection) ที่รับอ็อบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISvgImage) เป็นอาร์กิวเมนต์แรก

โค้ดตัวอย่าง Java ด้านล่างแสดงวิธีใช้เมธอดนี้เพื่อแปลงไฟล์ SVG เป็นชุดรูปทรง:

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

    // แปลงภาพ SVG เป็นกลุ่มรูปทรงและปรับขนาดให้พอดีกับสไลด์.
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

## **เพิ่มภาพแบบ EMF ลงในสไลด์**

Aspose.Slides for Android via Java ให้คุณสร้างภาพ EMF จาก Worksheet ของ Excel ด้วย Aspose.Cells แล้วเพิ่มลงในสไลด์การนำเสนอ

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

// บันทึกเวิร์กบุ๊กลงสตรีม.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // เพิ่มไฟล์โดยไม่เปลี่ยนแปลงเพื่อให้รูปภาพคงเป็นเวกเตอร์ EMF แทนที่จะถูกแปลงเป็น raster.
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

## **แทนที่ภาพใน Image Collection**

Aspose.Slides ให้คุณแทนที่ภาพที่เก็บอยู่ใน Image Collection ของการนำเสนอ รวมถึงภาพที่ใช้ในรูปร่างของสไลด์ ส่วนนี้อธิบายหลายวิธีในการอัปเดตภาพในคอลเลกชัน คุณสามารถแทนที่ภาพโดยใช้ข้อมูลไบต์ดิบ อินสแตนซ์ของ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) หรือภาพอื่นที่มีอยู่แล้วในคอลเลกชัน

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์การนำเสนอที่มีภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. โหลดภาพใหม่จากไฟล์เป็นอาเรย์ของไบต์
3. แทนที่ภาพเป้าหมายด้วยภาพใหม่โดยใช้ไอเท็มอาเรย์ของไบต์
4. วิธีที่สอง โหลดภาพเป็นอ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) แล้วแทนที่ภาพเป้าหมายด้วยอ็อบเจ็กต์นั้น
5. วิธีที่สาม แทนที่ภาพเป้าหมายด้วยภาพที่มีอยู่แล้วใน Image Collection ของการนำเสนอ
6. เขียนการนำเสนอที่แก้ไขแล้วออกเป็นไฟล์ PPTX

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ.
Presentation presentation = new Presentation("sample.pptx");
try {
    // วิธีที่หนึ่ง.
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

    // บันทึกการนำเสนอเป็นไฟล์.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="ข้อมูล" color="info" %}}

ด้วยตัวแปลงฟรีของ Aspose อย่าง [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) คุณสามารถทำให้ข้อความเคลื่อนไหวและสร้าง GIF จากข้อความได้อย่างง่ายดาย

{{% /alert %}}

## **FAQ**

**ความละเอียดของภาพต้นฉบับจะคงเดิมหลังจากแทรกหรือไม่?**

ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่การแสดงผลสุดท้ายขึ้นอยู่กับการสเกล [picture](/slides/th/androidjava/picture-frame/) บนสไลด์และการบีบอัดเมื่อบันทึก

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันในหลายสิบสไลด์พร้อมกันคืออะไร?**

วางโลโก้บน master slide หรือ layout แล้วแทนที่ใน Image Collection ของการนำเสนอ—การเปลี่ยนแปลงจะแพร่หลายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น

**SVG ที่แทรกเข้ามาสามารถแปลงเป็นรูปทรงที่แก้ไขได้หรือไม่?**

ได้ คุณสามารถแปลง SVG ให้เป็นกลุ่มรูปทรง หลังจากนั้นส่วนย่อยจะสามารถแก้ไขได้ด้วยคุณสมบัติมาตรฐานของรูปทรง

**จะตั้งรูปภาพเป็นพื้นหลังของหลายสไลด์พร้อมกันอย่างไร?**

[Assign the image as the background](/slides/th/androidjava/presentation-background/) บน master slide หรือ layout ที่เกี่ยวข้อง—สไลด์ใดที่ใช้ master/layout นั้นจะสืบทอดพื้นหลังนั้น

**จะป้องกันไม่ให้การนำเสนอใหญ่เกินไปจากภาพจำนวนมากได้อย่างไร?**

ใช้ทรัพยากรภาพเดียวซ้ำแทนการทำสำเนา เลือกความละเอียดที่เหมาะสม ใช้การบีบอัดเมื่อบันทึก และเก็บกราฟิกที่ซ้ำกันไว้บน master เมื่อเหมาะสม