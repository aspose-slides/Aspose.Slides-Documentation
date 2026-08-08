---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในพรีเซนเทชันบน Android
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/androidjava/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มภาพ
- เพิ่มบิตแมป
- แทนที่รูปภาพ
- แทนที่ภาพ
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- แหล่งข้อมูล SVG ภายนอก
- ตัวแก้ไข SVG
- รูปภาพ SVG ที่เชื่อมโยง
- ฟอนต์ SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "ทำให้การจัดการรูปภาพใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java เป็นกระบวนการที่ราบรื่น ปรับประสิทธิภาพการทำงานและอัตโนมัติขั้นตอนการทำงานของคุณ"
---
## **บทนำ**

ภาพทำให้การนำเสนอน่าสนใจและมีความสวยงามมากขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพลงสไลด์จากไฟล์ อินเทอร์เน็ต หรือแหล่งข้อมูลอื่น ๆ เช่นเดียวกับ Aspose.Slides ที่อนุญาตให้คุณเพิ่มภาพลงสไลด์พรีเซนเทชันได้หลายวิธี

{{% alert  title="Tip" color="primary" %}} 
Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้คุณสร้างพรีเซนเทชันจากรูปภาพได้อย่างรวดเร็ว 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
หากคุณต้องการเพิ่มภาพเป็นเฟรมรูป—โดยเฉพาะอย่างยิ่งถ้าต้องการปรับขนาด ใส่เอฟเฟ็กต์ หรือใช้ตัวเลือกการจัดรูปแบบมาตรฐานอื่น ๆ—ดูที่ [Picture Frame](/slides/th/androidjava/picture-frame/) 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
คุณสามารถแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบได้ ดูหน้าเหล่านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/androidjava/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/th/androidjava/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/th/androidjava/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/th/androidjava/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/th/androidjava/conversion/png-to-svg/), และ [SVG to PNG](https://products.aspose.com/slides/th/androidjava/conversion/svg-to-png/) 
{{% /alert %}}

Aspose.Slides รองรับภาพในรูปแบบยอดนิยมเช่น JPEG, PNG, BMP, GIF และอื่น ๆ 

## **เพิ่มภาพที่เก็บไว้ในเครื่องลงสไลด์**

คุณสามารถเพิ่มภาพหนึ่งหรือหลายภาพที่เก็บอยู่ในคอมพิวเตอร์ของคุณลงสไลด์พรีเซนเทชัน โค้ดตัวอย่าง Java ด้านล่างแสดงวิธีการเพิ่มภาพลงสไลด์

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

## **เพิ่มภาพจากเว็บลงสไลด์**

หากภาพที่คุณต้องการเพิ่มลงสไลด์ไม่ได้เก็บไว้ในคอมพิวเตอร์ของคุณ คุณสามารถเพิ่มโดยตรงจากเว็บได้

โค้ดตัวอย่าง Java ด้านล่างแสดงวิธีการเพิ่มภาพจากเว็บลงสไลด์

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

Slide master เก็บและควบคุมข้อมูลเช่นธีมและเค้าโครงสำหรับสไลด์ที่ใช้มัน เมื่อคุณเพิ่มภาพลงใน slide master ภาพนั้นจะปรากฏบนทุกสไลด์ที่อิงมาสต์เดอร์นี้

โค้ดตัวอย่าง Java ด้านล่างแสดงวิธีการเพิ่มภาพลงใน slide master

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

## **เพิ่มภาพเป็นพื้นหลังสไลด์**

คุณสามารถใช้รูปเป็นพื้นหลังสำหรับหนึ่งหรือหลายสไลด์ สำหรับรายละเอียด ดู *[Setting Images as Backgrounds for Slides](/slides/th/androidjava/presentation-background/#setting-images-as-background-for-slides)*

## **เพิ่ม SVG ลงในพรีเซนเทชัน**

เนื้อหา SVG สามารถเพิ่มลงในพรีเซนเทชันโดยใช้คลาส [SvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgimage/) วัตถุ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) ที่ได้สามารถนำไปเพิ่มในคอลเลกชันภาพของพรีเซนเทชันและใช้เพื่อสร้างเฟรมรูป

โค้ดตัวอย่าง Java ด้านล่างนำเข้า SVG string ที่เป็นอิสระทั้งหมด ภาพ, สไตล์ และทรัพยากรอื่น ๆ ที่ SVG ใช้จะฝังอยู่โดยตรงในเนื้อหา SVG

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

## **นำเข้าเนื้อหา SVG ที่มีทรัพยากรภายนอก**

ไฟล์ SVG ที่ส่งออกจากเครื่องมือออกแบบ, โปรแกรมวาดแผนภาพ, ระบบไอคอน และกระบวนการเว็บบางอย่างอาจอ้างอิงทรัพยากรที่จัดเก็บนอกเอกสาร SVG ตัวอย่างเช่น SVG อาจมีลิงก์รูปภาพเช่น `images/photo.png`, ค่า CSS `url(...)` หรือ URL ของฟอนต์

เพื่อเรียกนำเข้าเนื้อหา SVG ดังกล่าว ให้สร้างการใช้งานของ [IExternalResourceResolver](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iexternalresourceresolver/) และส่งไปพร้อมกับ base URI ให้กับคอนสตรัคเตอร์ของ [SvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgimage/) ที่เหมาะสม Base URI ระบุตำแหน่งของเอกสาร SVG และใช้เพื่อแก้ลิงก์สัมพันธ์

อินเทอร์เฟซ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) ให้เข้าถึงข้อมูลเกี่ยวกับ SVG ที่นำเข้า:

- `getSvgContent()` คืนค่า markup ของ SVG เป็นสตริง
- `getSvgData()` คืนค่าเนื้อหา SVG เป็นอาเรย์ของไบต์
- `getBaseUri()` คืนค่า base URI ที่ใช้สำหรับลิงก์สัมพันธ์
- `getExternalResourceResolver()` คืนค่า resolver ที่กำหนดให้กับภาพ SVG

### **สร้าง External Resource Resolver**

Resolver มีสองเมธอด:

- `resolveUri` รวม base URI กับลิงก์ทรัพยากรสัมพันธ์และคืนค่า URI เต็มรูปแบบ คืนค่า `null` เมื่อไม่สามารถแก้ลิงก์หรือไม่ได้รับอนุญาต
- `getEntity` คืนสตรีมที่อ่านได้สำหรับ URI ของทรัพยากรเต็มรูปแบบ คืนค่า `null` เมื่อทรัพยากรหาย, ถูกบล็อก หรือไม่พร้อมใช้งาน สตรีมสำรองอาจคืนค่าได้เมื่อเหมาะสม

โค้ดตัวอย่างต่อไปนี้โหลดทรัพยากรที่ลิงก์ไว้เฉพาะจากไดเรกทอรีท้องถิ่นที่อนุญาต ทรัพยากรเครือข่ายและเส้นทางนอกไดเรกทอรีที่อนุญาตจะถูกบล็อก ภาพสำรองที่เป็นตัวเลือกจะคืนค่าสำหรับลิงก์รูปภาพที่ไม่สามารถแก้ได้

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

            // ตัวแก้ไขนี้ตั้งใจให้ทำงานเฉพาะไฟล์ในเครื่องเท่านั้น.
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

            // ใช้ภาพสำรองเฉพาะสำหรับทรัพยากรรูปภาพเท่านั้น การคืนสตรีมรูปภาพ
            // สำหรับฟอนต์หรือสไตล์ชีตที่หายไปจะไม่ถูกต้อง.
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

โค้ด Java ด้านล่างส่ง URI ของไฟล์ SVG เป็น base URI และให้ resolver แบบกำหนดเอง Resolver จะเปลี่ยนลิงก์รูปภาพสัมพันธ์ให้เป็น URI เต็มรูปแบบและคืนสตรีมที่มีทรัพยากรลิงก์ขณะ Aspose.Slides ประมวลผล SVG

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// URI พื้นฐานเป็นตัวแทนของตำแหน่งที่ตั้งของเอกสาร SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage ให้เข้าถึงเนื้อหาต้นฉบับ, ข้อมูลไบต์, URI พื้นฐาน และตัวแก้ไข.
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

คลาส `SvgImage` ยังมี overloads ที่รับข้อมูล SVG เป็นอาเรย์ของไบต์หรืออินพุตสตรีม พร้อมกับ external resource resolver และ base URI

{{% alert title="Important" color="warning" %}}
Resolver ทำให้ทรัพยากรภายนอกพร้อมใช้งานขณะ Aspose.Slides ประมวลผลและเรนเดอร์ SVG โดยไม่ได้แก้ไข markup ของ SVG ดั้งเดิมหรือฝังทรัพยากรที่แก้แล้วโดยอัตโนมัติ

เมื่อ `ISvgImage` ถูกเพิ่มไปยังคอลเลกชันภาพของพรีเซนเทชัน ไฟล์ PPTX อาจมีทั้งการแสดงผล SVG ดั้งเดิมและภาพ raster สำรอง ทรัพยากรที่ลิงก์อาจปรากฏในภาพสำรองที่สร้างขึ้นในขณะที่ลิงก์สัมพันธ์เช่น `images/photo.png` จะคงเดิมใน SVG ที่เก็บไว้ แอปพลิเคชันที่เรนเดอร์การแสดงผล SVG แท้จึงอาจละเว้นเนื้อหาที่ลิงก์เมื่อทรัพยากรภายนอกต้นทางไม่สามารถใช้ได้
{{% /alert %}}

### **สร้าง SVG Picture แบบพกพา**

เพื่อสร้างภาพ SVG ที่ไม่พึ่งพาไฟล์ภายนอก ให้ทำให้ SVG เป็นอิสระก่อนสร้าง `SvgImage` ตัวอย่างเช่น แทนที่ URL ของรูปภาพที่ลิงก์ด้วย URI `data:` ที่มีข้อมูลภาพอยู่ภายใน:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

หลังจากฝังทรัพยากรที่จำเป็นทั้งหมดในเนื้อหา SVG แล้ว ให้สร้าง `SvgImage` เพิ่มเข้าไปในคอลเลกชันภาพของพรีเซนเทชัน และแทรกลงในเฟรมรูปตามตัวอย่างก่อนหน้า

### **จัดการทรัพยากรที่ขาดหายหรือถูกบล็อก**

คืนค่า `null` จาก `resolveUri` เมื่อ URI ของทรัพยากรไม่ถูกต้อง, ถูกห้าม, หรือไม่สามารถแก้ได้ คืนค่า `null` จาก `getEntity` เมื่อไม่สามารถอ่านทรัพยากรได้ Aspose.Slides จะดำเนินการประมวลผล SVG ต่อไปโดยไม่มีทรัพยากรนั้นเมื่อทำได้

สตรีมสำรองสามารถคืนค่าได้สำหรับทรัพยากรที่หาย แต่เนื้อหาต้องเข้ากันได้กับประเภททรัพยากรที่ร้องขอ ตัวอย่างเช่น คืนสตรีมรูปภาพเฉพาะสำหรับรูปภาพที่หาย ไม่ใช่สำหรับฟอนต์หรือสไตล์ชีต

{{% alert title="Security" color="warning" %}}
ห้ามแก้ไขเส้นทางไฟล์ใด ๆ หรือ URL ของเครือข่ายที่ไม่จำกัดจากไฟล์ SVG ที่ไม่น่าเชื่อถือ จำกัดสกีม, ไดเรกทอรีและโฮสต์ที่อนุญาต สำหรับทรัพยากรเครือข่าย ให้กำหนดเวลาเชื่อมต่อ, ขีดจำกัดขนาดการตอบกลับ, และการตรวจสอบเนื้อหา
{{% /alert %}}

## **แปลง SVG เป็นชุดของ Shape**

Aspose.Slides สามารถแปลง SVG ให้เป็นชุดของ shape ได้ คล้ายกับฟังก์ชันที่สอดคล้องกันใน PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้ให้โดย overload ของเมธอด [addGroupShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) ของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection) ที่รับอ็อบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISvgImage) เป็นอาร์กิวเมนต์แรก

โค้ดตัวอย่าง Java ด้านล่างแสดงวิธีใช้เมธอดนี้เพื่อแปลงไฟล์ SVG ให้เป็นชุดของ shape:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// ชื่อไฟล์ SVG ต้นฉบับ.
String svgFileName = "sample.svg";

// ชื่อไฟล์พรีเซนเทชันผลลัพธ์.
String outPptxPath = "presentation.pptx";

// สร้างพรีเซนเทชันใหม่.
IPresentation presentation = new Presentation();
try {
    // อ่านเนื้อหาไฟล์ SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // สร้างอ็อบเจ็กต์ SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // รับขนาดสไลด์.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // แปลงภาพ SVG เป็นกลุ่มของ shape และปรับขนาดให้พอดีกับสไลด์.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // บันทึกพรีเซนเทชันในรูปแบบ PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **เพิ่มภาพแบบ EMF ลงในสไลด์**

Aspose.Slides สำหรับ Android ผ่าน Java อนุญาตให้คุณสร้างภาพ EMF จากแผ่นงาน Excel ด้วย Aspose.Cells และเพิ่มลงในสไลด์พรีเซนเทชัน

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

// บันทึกเวิร์กบุ๊กเป็นสตรีม.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // เพิ่มไฟล์ตามเดิมเพื่อให้รูปภาพคงเป็นเวกเตอร์ EMF แทนที่จะถูกแปลงเป็นราสเตอร์.
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

Aspose.Slides ให้คุณแทนที่ภาพที่เก็บอยู่ในคอลเลกชันภาพของพรีเซนเทชัน รวมถึงภาพที่ใช้โดย shape ของสไลด์ ส่วนนี้อธิบายวิธีอัปเดตภาพในคอลเลกชันหลายวิธี คุณสามารถแทนที่ภาพโดยใช้ข้อมูลไบต์ดิบ, อินสแตนซ์ของ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/), หรือภาพอื่นที่มีอยู่แล้วในคอลเลกชัน

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์พรีเซนเทชันที่มีภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. โหลดภาพใหม่จากไฟล์เป็นอาเรย์ของไบต์
3. แทนที่ภาพเป้าหมายด้วยภาพใหม่โดยใช้ไอเทมอาเรย์ไบต์
4. ในวิธีที่สอง โหลดภาพเป็นอ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) และแทนที่ภาพเป้าหมายด้วยอ็อบเจ็กต์นั้น
5. ในวิธีที่สาม แทนที่ภาพเป้าหมายด้วยภาพที่มีอยู่แล้วในคอลเลกชันภาพของพรีเซนเทชัน
6. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์พรีเซนเทชัน
Presentation presentation = new Presentation("sample.pptx");
try {
    // วิธีที่หนึ่ง
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // วิธีที่สอง
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // วิธีที่สาม
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // บันทึกพรีเซนเทชันเป็นไฟล์
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
ด้วยตัวแปลงฟรีของ Aspose อย่าง [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) คุณสามารถทำให้ข้อความเคลื่อนไหวและสร้าง GIF จากข้อความได้อย่างง่ายดาย 
{{% /alert %}}

## **FAQ**

**ความละเอียดของภาพต้นฉบับยังคงเหมือนเดิมหลังจากแทรกหรือไม่?**

ใช่ พิกเซลต้นฉบับจะถูกเก็บรักษาไว้ แต่ลักษณะสุดท้ายขึ้นอยู่กับการสเกลของ [picture](/slides/th/androidjava/picture-frame/) บนสไลด์และการบีบอัดที่ใช้เมื่อบันทึก

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันในหลายสิบสไลด์พร้อมกันคืออะไร?**

วางโลโก้บนมาสเตอร์สไลด์หรือเลย์เอาต์แล้วแทนที่ในคอลเลกชันภาพของพรีเซนเทชัน—การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น

**SVG ที่แทรกสามารถแปลงเป็น shape ที่แก้ไขได้หรือไม่?**

ได้ คุณสามารถแปลง SVG ให้เป็นกลุ่มของ shape จากนั้นส่วนต่าง ๆ จะกลายเป็นแก้ไขได้ด้วยคุณสมบัติ shape มาตรฐาน

**จะตั้งค่าภาพเป็นพื้นหลังสำหรับหลายสไลด์พร้อมกันอย่างไร?**

[Assign the image as the background](/slides/th/androidjava/presentation-background/) บนมาสเตอร์สไลด์หรือเลย์เอาต์ที่เกี่ยวข้อง—สไลด์ใด ๆ ที่ใช้มาสเตอร์/เลย์เอาต์นั้นจะสืบทอดพื้นหลัง

**ทำอย่างไรเพื่อป้องกันพรีเซนเทชันจากการใหญ่เกินไปเพราะมีรูปภาพจำนวนมาก?**

ใช้ทรัพยากรภาพเดียวซ้ำแทนการทำสำเนา เลือกความละเอียดที่เหมาะสม ใช้การบีบอัดเมื่อบันทึก และเก็บกราฟิกที่ซ้ำอยู่บนมาสเตอร์เมื่อเหมาะสม