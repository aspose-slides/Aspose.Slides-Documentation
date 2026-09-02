---
title: "เพิ่มประสิทธิภาพการจัดการรูปภาพในการนำเสนอด้วย Java"
linktitle: "จัดการรูปภาพ"
type: docs
weight: 10
url: /th/java/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มรูป
- เพิ่มบิตแมพ
- แทนที่รูปภาพ
- แทนที่รูป
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- ทรัพยากร SVG ภายนอก
- ตัวแก้ไข SVG
- ภาพ SVG ที่ลิงก์
- ฟอนต์ SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ทำให้การจัดการรูปภาพใน PowerPoint และ OpenDocument ง่ายขึ้นด้วย Aspose.Slides สำหรับ Java เพิ่มประสิทธิภาพการทำงานและอัตโนมัติกระบวนการของคุณ."
---
## **คำนำ**

ภาพทำให้การนำเสนอมีความน่าสนใจและดึงดูดสายตามากขึ้น ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพลงในสไลด์จากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ เช่นเดียวกับ Aspose.Slides ที่อนุญาตให้คุณเพิ่มรูปภาพลงในสไลด์การนำเสนอได้หลายวิธี.

{{% alert  title="Tip" color="primary" %}} 
Aspose ให้บริการตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้คุณสร้างการนำเสนอจากรูปภาพได้อย่างรวดเร็ว. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
หากคุณต้องการเพิ่มรูปภาพเป็นกรอบรูป—โดยเฉพาะอย่างยิ่งหากคุณตั้งใจจะปรับขนาด เพิ่มเอฟเฟกต์ หรือใช้ตัวเลือกการจัดรูปแบบมาตรฐานอื่น ๆ—ดูที่ [Picture Frame](/slides/th/java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
คุณสามารถแปลงรูปภาพจากฟอร์แมตหนึ่งเป็นอีกฟอร์แมตหนึ่ง ดูหน้าต่อไปนี้: แปลง [image to JPG](https://products.aspose.com/slides/th/java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/th/java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/th/java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/th/java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/th/java/conversion/png-to-svg/), และ [SVG to PNG](https://products.aspose.com/slides/th/java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides รองรับรูปภาพในฟอร์แมตที่นิยม เช่น JPEG, PNG, BMP, GIF และอื่น ๆ. 

## **เพิ่มรูปภาพที่จัดเก็บไว้ในเครื่องลงสไลด์**

คุณสามารถเพิ่มรูปภาพหนึ่งหรือหลายรูปที่จัดเก็บบนคอมพิวเตอร์ของคุณลงในสไลด์การนำเสนอได้ ตัวอย่างโค้ด Java ต่อไปนี้แสดงวิธีการเพิ่มรูปภาพลงในสไลด์:

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

## **เพิ่มรูปภาพจากเว็บลงสไลด์**

หากรูปภาพที่คุณต้องการเพิ่มลงในสไลด์ไม่ได้จัดเก็บบนคอมพิวเตอร์ของคุณ คุณสามารถเพิ่มมันโดยตรงจากเว็บได้.

ตัวอย่างโค้ด Java ต่อไปนี้แสดงวิธีการเพิ่มรูปภาพจากเว็บลงในสไลด์:

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

Slide Master เก็บและควบคุมข้อมูล เช่น ธีมและการจัดวางสำหรับสไลด์ที่ใช้มัน เมื่อคุณเพิ่มรูปภาพลงใน Slide Master รูปภาพจะปรากฏบนทุกสไลด์ที่อิงตาม master นั้น.

ตัวอย่างโค้ด Java ต่อไปนี้แสดงวิธีการเพิ่มรูปภาพลงใน Slide Master:

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

คุณสามารถใช้รูปเป็นพื้นหลังสำหรับหนึ่งหรือหลายสไลด์สำหรับรายละเอียด ดูที่ *[Setting Images as Backgrounds for Slides](/slides/th/java/presentation-background/#setting-images-as-background-for-slides)*.

## **เพิ่ม SVG ลงในการนำเสนอ**

เนื้อหา SVG สามารถเพิ่มลงในการนำเสนอได้โดยใช้คลาส [SvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgimage/) วัตถุ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) ที่ได้สามารถเพิ่มลงในคอลเลกชันรูปภาพของการนำเสนอและใช้สร้างกรอบรูปได้.

ตัวอย่าง Java ด้านล่างนำเข้า SVG ที่รวมทุกอย่างไว้ในสตริงเดียว ทุกภาพ สไตล์ และทรัพยากรอื่น ๆ ที่ใช้ใน SVG นี้ถูกฝังโดยตรงในเนื้อหา SVG.

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

ไฟล์ SVG ที่ส่งออกจากเครื่องมือออกแบบ, ตัวแก้ไขไดอะแกรม, ระบบไอคอน, และ pipeline ของเว็บอาจอ้างอิงทรัพยากรที่จัดเก็บนอกเอกสาร SVG ตัวอย่างเช่น SVG อาจมีลิงก์รูปภาพเช่น `images/photo.png`, ค่า CSS `url(...)` หรือ URL ของฟอนต์.

เพื่อทำการนำเข้าเนื้อหา SVG ดังกล่าว ให้สร้างการใช้งานของ [IExternalResourceResolver](https://reference.aspose.com/slides/th/java/com.aspose.slides/iexternalresourceresolver/) และส่งผ่านพร้อมกับ base URI ไปยังตัวสร้าง [SvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/svgimage/) ที่เหมาะสม Base URI ระบุตำแหน่งของเอกสาร SVG และใช้สำหรับแก้ลิงก์เชิงสัมพันธ์.

อินเทอร์เฟซ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) ให้การเข้าถึงข้อมูลเกี่ยวกับ SVG ที่นำเข้า:

- `getSvgContent()` คืนค่า markup ของ SVG เป็นสตริง.
- `getSvgData()` คืนค่าเนื้อหา SVG เป็นอาร์เรย์ไบต์.
- `getBaseUri()` คืนค่า base URI ที่ใช้สำหรับลิงก์เชิงสัมพันธ์.
- `getExternalResourceResolver()` คืนค่าตัวแก้ไขที่กำหนดให้กับภาพ SVG.

### **สร้างตัวแก้ไขทรัพยากรภายนอก**

ตัวแก้ไขมีสองเมธอด:

- `resolveUri` รวม base URI กับลิงก์ทรัพยากรเชิงสัมพันธ์และคืนค่า URI แบบเต็ม คืนค่า `null` เมื่อไม่สามารถแก้ลิงก์หรือไม่อนุญาต.
- `getEntity` คืนค่าที่สตรีมที่อ่านได้สำหรับ URI ของทรัพยากรแบบเต็ม คืนค่า `null` เมื่อทรัพยากรหาย, ถูกบล็อก, หรือไม่พร้อมใช้งาน สามารถคืนค่าสตรีมสำรองเมื่อเหมาะสม.

ตัวแก้ไขต่อไปนี้โหลดทรัพยากรที่ลิงก์มาเฉพาะจากไดเรกทอรีในเครื่องที่อนุญาตเท่านั้น ทรัพยากรเครือข่ายและเส้นทางนอกไดเรกทอรีที่อนุญาตจะถูกบล็อก ภาพสำรองแบบเลือกได้จะถูกคืนสำหรับลิงก์รูปภาพที่ไม่สามารถแก้ได้.

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

            // ตัวแก้ไขนี้ตั้งใจให้อนุญาตเฉพาะไฟล์ในเครื่องเท่านั้น.
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

            // ใช้ภาพสำรองเฉพาะสำหรับทรัพยากรภาพเท่านั้น การคืนสตรีมภาพ
            // สำหรับฟอนต์หรือสไตล์ชีตที่ขาดหายจะไม่ถูกต้อง.
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

สมมติว่า `assets/diagram.svg` มีการอ้างอิงเชิงสัมพันธ์เช่น:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

ตัวอย่าง Java ด้านล่างส่ง URI ของไฟล์ SVG เป็น base URI และให้ตัวแก้ไขแบบกำหนดเอง ตัวแก้ไขจะแปลงลิงก์รูปภาพเชิงสัมพันธ์เป็น URI แบบเต็มและคืนค่าสตรีมที่มีทรัพยากรที่ลิงก์ขณะ Aspose.Slides กำลังประมวลผล SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Base URI เป็นตัวแทนของตำแหน่งของเอกสาร SVG.
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

คลาส `SvgImage` ยังมี overloads ที่รับข้อมูล SVG เป็นอาร์เรย์ไบต์หรือสตรีมอินพุต พร้อมกับตัวแก้ไขทรัพยากรภายนอกและ base URI.

{{% alert title="Important" color="warning" %}}
ตัวแก้ไขทรัพยากรทำให้ทรัพยากรภายนอกพร้อมใช้งานขณะ Aspose.Slides ประมวลผลและเรนเดอร์ SVG ไม่ได้แก้ไข markup ของ SVG ดั้งเดิมหรือฝังทรัพยากรที่แก้ไขโดยอัตโนมัติเข้าไปในมัน.

เมื่อ `ISvgImage` ถูกเพิ่มลงในคอลเลกชันรูปภาพของการนำเสนอ ไฟล์ PPTX อาจมีทั้งการแสดง SVG ดั้งเดิมและภาพ raster สำรอง ทรัพยากรที่ลิงก์อาจปรากฏในภาพสำรองที่สร้างขึ้นในขณะที่ลิงก์เชิงสัมพันธ์เช่น `images/photo.png` ยังคงไม่เปลี่ยนใน SVG ที่จัดเก็บ แอปพลิเคชันที่เรนเดอร์การแสดง SVG แบบดั้งเดิมจึงอาจละเว้นเนื้อหาที่ลิงก์เมื่อทรัพยากรภายนอกเดิมไม่พร้อมใช้งาน.
{{% /alert %}}

### **สร้างภาพ SVG ที่พกพาได้**

เพื่อสร้างภาพ SVG ที่ไม่พึ่งพาไฟล์ภายนอก ให้ทำให้ SVG เป็นแบบ self-contained ก่อนสร้าง `SvgImage` ตัวอย่างเช่น แทนที่ URL ของภาพที่ลิงก์ด้วย URI `data:` ที่บรรจุข้อมูลภาพ:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

หลังจากที่ทรัพยากรที่จำเป็นทั้งหมดถูกฝังในเนื้อหา SVG แล้ว สร้าง `SvgImage` เพิ่มลงในคอลเลกชันรูปภาพของการนำเสนอ และแทรกลงในกรอบรูปตามตัวอย่างก่อนหน้า.

### **จัดการทรัพยากรที่หายหรือถูกบล็อก**

คืนค่า `null` จาก `resolveUri` เมื่อ URI ของทรัพยากรไม่ถูกต้อง, ห้าม, หรือไม่สามารถแก้ได้ คืนค่า `null` จาก `getEntity` เมื่อไม่สามารถอ่านทรัพยากรได้ Aspose.Slides จะดำเนินการประมวลผล SVG ต่อโดยไม่มีทรัพยากรนั้นเมื่อเป็นไปได้.

สตรีมสำรองสามารถคืนค่าตามทรัพยากรที่หาย แต่เนื้อหาต้องเข้ากันได้กับประเภททรัพยากรที่ขอ ตัวอย่างเช่น คืนค่าสตรีมภาพเฉพาะสำหรับภาพที่หาย ไม่ใช่สำหรับฟอนต์หรือสไตล์ชีต.

{{% alert title="Security" color="warning" %}}
ห้ามแก้ไขเส้นทางไฟล์หรือ URL ของเครือข่ายที่ไม่มีการจำกัดจากไฟล์ SVG ที่ไม่เชื่อถือ ควรจำกัดสคีม, ไดเรกทอรี, และโฮสต์ที่อนุญาต สำหรับทรัพยากรเครือข่ายยังต้องกำหนดเวลาเชื่อมต่อ, ขนาดการตอบรับสูงสุด, และการตรวจสอบความสมบูรณ์ของเนื้อหา.
{{% /alert %}}

## **แปลง SVG เป็นชุดของรูปร่าง**

Aspose.Slides สามารถแปลง SVG เป็นชุดของรูปร่างได้ คล้ายกับฟังก์ชันที่สอดคล้องใน PowerPoint:
![เมนูป๊อปอัป PowerPoint](img_01_01.png)

ฟังก์ชันนี้ให้โดย overload ของเมธอด [addGroupShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) ของอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection) ที่รับวัตถุ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISvgImage) เป็นอาร์กิวเมนต์แรก.

ตัวอย่างโค้ด Java ต่อไปนี้แสดงวิธีใช้เมธอดนี้เพื่อแปลงไฟล์ SVG เป็นชุดของรูปร่าง:

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

    // ดึงขนาดสไลด์.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // แปลงภาพ SVG เป็นกลุ่มของรูปร่างและปรับขนาดให้พอดีกับสไลด์.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // บันทึกการนำเสนอเป็นรูปแบบ PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **เพิ่มรูปภาพเป็น EMF ลงในสไลด์**

Aspose.Slides for Java อนุญาตให้คุณสร้างภาพ EMF จากแผ่นงาน Excel ด้วย Aspose.Cells แล้วเพิ่มลงในสไลด์การนำเสนอ.

ตัวอย่างโค้ด Java ต่อไปนี้แสดงวิธีทำเช่นนั้น:

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

        // เพิ่มไฟล์ตามเดิมเพื่อให้รูปภาพคงเป็นเวกเตอร์ EMF แทนการแปลงเป็นราสเตอร์.
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

Aspose.Slides ให้คุณแทนที่รูปภาพที่จัดเก็บในคอลเลกชันรูปภาพของการนำเสนอ รวมถึงรูปภาพที่ใช้โดยรูปร่างของสไลด์ ส่วนนี้อธิบายหลายวิธีในการอัปเดตรูปภาพในคอลเลกชัน คุณสามารถแทนที่รูปภาพโดยใช้ข้อมูลไบต์ดิบ, อินสแตนซ์ของ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/), หรือรูปภาพอื่นที่มีอยู่แล้วในคอลเลกชัน.

ทำตามขั้นตอนต่อไปนี้:

1. โหลดไฟล์การนำเสนอที่มีรูปภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
2. โหลดรูปภาพใหม่จากไฟล์ลงในอาเรย์ไบต์.
3. แทนที่รูปภาพเป้าหมายด้วยรูปภาพใหม่โดยใช้อาเรย์ไบต์.
4. ในวิธีที่สอง โหลดรูปภาพเข้าสู่วัตถุ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) แล้วแทนที่รูปภาพเป้าหมายด้วยวัตถุนั้น.
5. ในวิธีที่สาม แทนที่รูปภาพเป้าหมายด้วยรูปภาพที่มีอยู่แล้วในคอลเลกชันรูปภาพของการนำเสนอ.
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
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

{{% alert title="Info" color="info" %}}
ด้วยตัวแปลงฟรีของ Aspose ที่ชื่อ [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) คุณสามารถทำให้ข้อความเคลื่อนไหวและสร้าง GIF จากข้อความได้อย่างง่ายดาย. 
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความละเอียดของรูปภาพต้นฉบับยังคงเดิมหลังการแทรกหรือไม่?**

ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่ลักษณะสุดท้ายขึ้นอยู่กับว่ารูปภาพ [picture](/slides/th/java/picture-frame/) ถูกปรับขนาดบนสไลด์อย่างไรและการบีบอัดที่ใช้เมื่อบันทึก.

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันในหลายสิบสไลด์พร้อมกันคืออะไร?**

ให้วางโลโก้บน master slide หรือ layout แล้วแทนที่ในคอลเลกชันรูปภาพของการนำเสนอ การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น.

**สามารถแปลง SVG ที่แทรกไว้ให้เป็นรูปร่างที่แก้ไขได้หรือไม่?**

ได้ คุณสามารถแปลง SVG เป็นกลุ่มของรูปร่าง หลังจากนั้นส่วนย่อยจะสามารถแก้ไขได้ด้วยคุณสมบัติมาตรฐานของรูปร่าง.

**ทำอย่างไรจึงจะตั้งรูปภาพเป็นพื้นหลังสำหรับหลายสไลด์พร้อมกัน?**

ให้ [Assign the image as the background](/slides/th/java/presentation-background/) บน master slide หรือ layout ที่เกี่ยวข้อง—สไลด์ใด ๆ ที่ใช้ master/layout นั้นจะสืบทอดพื้นหลัง.

**ทำอย่างไรจึงจะป้องกันไม่ให้การนำเสนอใหญ่จนเกินไปจากรูปภาพจำนวนมาก?**

ใช้ทรัพยากรรูปภาพเดียวซ้ำแทนการทำสำเนา เลือกความละเอียดที่เหมาะสม ใช้การบีบอัดเมื่อบันทึก และเก็บกราฟิกที่ทำซ้ำบน master ตามความเหมาะสม.