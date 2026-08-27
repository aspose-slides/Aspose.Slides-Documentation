---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown ใน Java
linktitle: PowerPoint เป็น Markdown
type: docs
weight: 140
url: /th/java/convert-powerpoint-to-markdown/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น MD
- งานนำเสนอเป็น MD
- สไลด์เป็น MD
- PPT เป็น MD
- PPTX เป็น MD
- บันทึก PowerPoint เป็น Markdown
- บันทึกงานนำเสนอเป็น Markdown
- บันทึกสไลด์เป็น Markdown
- บันทึก PPT เป็น MD
- บันทึก PPTX เป็น MD
- ส่งออก PPT เป็น MD
- ส่งออก PPTX เป็น MD
- การส่งออกรูปภาพใน Markdown
- ลิงก์รูปภาพ CDN
- PowerPoint
- งานนำเสนอ
- Markdown
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PPT และ PPTXเป็น Markdown ใน Java และควบคุมตำแหน่งที่บันทึกและอ้างอิงภาพ bitmap, metafile และ SVG ที่ส่งออก"
---
## **Overview**

Aspose.Slides for Java สามารถแปลงงานนำเสนอ PPT และ PPTX เป็น Markdown เพื่อใช้ในเอกสาร การสร้างเว็บไซต์แบบสถิต การย้ายเนื้อหา และเวิร์กโฟลว์การควบคุมเวอร์ชัน คุณสามารถเลือกรูปแบบ Markdown ควบคุมวิธีการแสดงผลของเนื้อหาสไลด์ และกำหนดว่าภาพที่ส่งออกจะถูกจัดเก็บที่ไหนและ Markdown ที่สร้างจะอ้างอิงภาพเหล่านั้นอย่างไร

โดยค่าเริ่มต้น การส่งออก Markdown จะใช้เฉพาะข้อความเท่านั้น หากต้องการส่งออกเนื้อหาภาพ ให้ตั้งค่าชนิดการส่งออกด้วยเมธอด [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/) เป็นค่า `Sequential` หรือ `Visual` จาก enumeration [MarkdownExportType](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownexporttype/) ค่า `Sequential` จะเรนเดอร์รายการบนสไลด์แยกกันและตามลำดับ ในขณะที่ `Visual` จะรวมรายการที่จัดกลุ่มไว้ด้วยกันเพื่อคงความสัมพันธ์เชิงภาพ ค่า `TextOnly` จะไม่สร้างทรัพยากรภาพ ดังนั้นคอลแบ็กการบันทึกภาพจะไม่ถูกเรียกในโหมดนั้น

## **Convert a Presentation to Markdown**

โหลดไฟล์ต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) แล้วเรียกเมธอด [Presentation.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) พร้อมค่า `Md` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/saveformat/)

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Select a Markdown Flavor**

เมธอด [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/) ควบคุมสเปค Markdown ที่ใช้สำหรับผลลัพธ์ enumeration [Flavor](https://reference.aspose.com/slides/th/java/com.aspose.slides/flavor/) มี CommonMark, GitHub Flavored Markdown และรูปแบบที่สนับสนุนอื่น ๆ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Export Images Using the Default Local-Saving Behavior**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/) มีเมธอดสองตัวสำหรับกำหนดการบันทึกภาพในเครื่อง:

- [setBasePath](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/) กำหนดไดเรกทอรีฐานสำหรับเอกสาร Markdown และทรัพยากรของมัน
- [setImagesSaveFolderName](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/) กำหนดโฟลเดอร์ย่อยของภาพ ค่าเริ่มต้นคือ `Images`

ตัวอย่างต่อไปนี้เรนเดอร์เนื้อหาภาพ เขียนภาพไปยัง `output/assets` และสร้างการอ้างอิงภาพแบบ relative ในเอกสาร Markdown:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

พฤติกรรมนี้ยังทำหน้าที่เป็น fallback เมื่อคอลแบ็กการบันทึกภาพที่กำหนดเองคืนค่า `false`

## **Customize Image Saving and Markdown Links**

ใช้เมธอด [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/) เพื่อลงทะเบียนคอลแบ็กสำหรับทรัพยากร bitmap และ metafile ที่ไม่ใช่ SVG ที่ถูกสร้างขึ้นระหว่างการส่งออก Markdown คอลแบ็ก `MarkdownImageSavingHandler` จะรับออบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/), ค่า [ImageFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/imageformat/) และลิงก์ Markdown ที่สร้างเป็นพารามิเตอร์ `String[]` ขนาดหนึ่ง รายการบันทึกหรืออัปโหลดภาพด้วยฟอร์แมตที่ให้มา แล้วแทนที่ `link[0]` ด้วยลิงก์ที่ต้องการแสดงในผลลัพธ์ Markdown

ทรัพยากรที่สร้างในรูปแบบ SVG จะถูกจัดการแยกต่างหาก ลงทะเบียนคอลแบ็กด้วยเมธอด [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/) คอลแบ็ก `MarkdownSvgImageSavingHandler` จะรับออบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) และพารามิเตอร์ `String[] link` ขนาดหนึ่ง SVG ไม่มีอาร์กิวเมนต์ `ImageFormat`; ให้เขียนหรืออัปโหลดข้อมูล XML ของมันผ่านเมธอด [ISvgImage.getSvgData](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) ตามต้องการ ขึ้นอยู่กับโหมดการส่งออกและการจัดกลุ่มเชิงภาพ SVG ในงานนำเสนออาจถูกเรสเตอร์ไลซ์หรือรวมกับเนื้อหาอื่น ๆ; ทรัพยากรที่ไม่ใช่ SVG ที่ได้จะถูกส่งต่อให้คอลแบ็กการบันทึกภาพ ลงทะเบียนคอลแบ็กทั้งสองเมื่อต้องการประมวลผลทรัพยากรภาพทุกชนิดแบบกำหนดเอง

ค่าที่คอลแบ็กคืนจะกำหนดว่าใครเป็นผู้ประมวลผลภาพ:

- คืนค่า `true` หลังจากคอลแบ็กบันทึก, อัปโหลด, แปลงรูป หรือดำเนินการใด ๆ กับภาพและกำหนดค่าให้ `link[0]` อย่างถูกต้อง Aspose.Slides จะเขียนค่านั้นลงในเอกสาร Markdown และจะไม่ทำการบันทึกในเครื่องตามค่าเริ่มต้น
- คืนค่า `false` เพื่อให้ Aspose.Slides บันทึกภาพในเครื่องและสร้างลิงก์ตามค่าที่ตั้งไว้ด้วย [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/) และ [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/)

{{% alert color="warning" title="Important" %}}
คอลแบ็กที่คืนค่า `true` จะต้องรับผิดชอบต่อภาพ หากคืนค่า `true` แต่ไม่ได้กำหนดลิงก์ที่ไม่ว่างเปล่าและเป็นค่าที่ถูกต้อง การส่งออกจะล้มเหลวด้วย `InvalidOperationException`
{{% /alert %}}

### **Save Images to a CDN Origin Directory and Use External URLs**

ตัวอย่างต่อไปนี้ถือว่า `cdn-origin/presentations/quarterly-report` เป็นไดเรกทอรีต้นทาง CDN ที่ติดตั้งหรือซิงโครไนซ์ คอลแบ็กแต่ละตัวจะดึงชื่อไฟล์ที่สร้างขึ้น, บันทึกภาพไปยังไดเรกทอรีที่กำหนดเอง, และแทนที่การอ้างอิงในเครื่องด้วย URL สาธารณะของ CDN ตัวอย่างนี้ไม่ได้ทำการอัปโหลดผ่านเครือข่าย: URL จะมีผลใช้ได้หลังจากไดเรกทอรีถูกเมานท์เป็นต้นทาง CDN หรือไฟล์ถูกเผยแพร่สู่ CDN สำหรับการจัดเก็บออบเจ็กต์ ให้เปลี่ยนการเขียนไฟล์ระบบเป็นการอัปโหลดด้วย SDK ของที่เก็บข้อมูลและกำหนด `link[0]` หลังจากอัปโหลดสำเร็จ

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

คอลแบ็ก bitmap ใส่ค่า `false` อย่างเจตนาสำหรับภาพที่มีขนาดเล็กกว่า 128 × 128 พิกเซล ดังนั้น Aspose.Slides จะบันทึกภาพเหล่านั้นลงใน `output/fallback-images` ด้วยพฤติกรรมเริ่มต้น ภาพ bitmap และ metafile ขนาดใหญ่ รวมถึงทรัพยากร SVG จะถูกจัดการโดยโค้ดกำหนดเอง ตัวอย่างเช่น การอ้างอิงในเครื่องเช่น `fallback-images/image1.png` จะกลายเป็น `https://cdn.example.com/presentations/quarterly-report/image1.png` คอลแบ็กใช้เส้นทางระบบปฏิบัติการเท่านั้นเมื่อเขียนไฟล์; ลิงก์ที่เขียนลง Markdown ใช้เครื่องหมายทับ `/` และชื่อไฟล์ที่ถูกเข้ารหัสสำหรับ URL ใช้กฎเดียวกันเมื่อสร้างลิงก์ relative: ใช้ `/` ไม่ใช่ตัวแยกโฟลเดอร์ของแพลตฟอร์ม

## **FAQ**

**คอลแบ็กหนึ่งตัวสามารถประมวลผลทั้งภาพ raster และ SVG ได้หรือไม่?**

ไม่ได้ ใช้ [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/) สำหรับทรัพยากร bitmap และ metafile ที่ส่งออก และใช้ [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/) สำหรับทรัพยากรที่เป็น SVG ตัวแรกจะให้ออบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) และค่า [ImageFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/imageformat/) ตัวที่สองจะให้ออบเจ็กต์ [ISvgImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) ซึ่งสามารถอ่านข้อมูล SVG ผ่าน [ISvgImage.getSvgData](https://reference.aspose.com/slides/th/java/com.aspose.slides/isvgimage/) SVG ที่ถูกเรสเตอร์ไลซ์ระหว่างการส่งออกจะถูกประมวลผลโดยคอลแบ็กการบันทึกภาพแทน

**จะเกิดอะไรขึ้นเมื่อคอลแบ็กการบันทึกภาพคืนค่า `false`?**

Aspose.Slides จะใช้พฤติกรรมบันทึกในเครื่องตามค่าเริ่มต้น ตำแหน่งภาพและลิงก์ที่สร้างจะถูกควบคุมโดยค่าที่ตั้งไว้ด้วย [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/) และ [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/th/java/com.aspose.slides/markdownsaveoptions/)

**คอลแบ็กสามารถให้ URL ได้โดยไม่บันทึกภาพในเครื่องหรือไม่?**

ได้ คอลแบ็กสามารถอัปโหลดภาพไปยังที่เก็บออบเจ็กต์หรือส่งต่อให้บริการอื่น, กำหนด URL ที่ได้ให้กับ `link[0]` และคืนค่า `true` คอลแบ็กต้องดำเนินการให้เสร็จสิ้นเอง; การคืนค่า `true` จะยับยั้งการบันทึกในเครื่องตามค่าเริ่มต้น

**ทำไมการส่งออก Markdown ถึงโยน `InvalidOperationException` จากคอลแบ็ก?**

ข้อผิดพลาดนี้เกิดเมื่อคอลแบ็กคืนค่า `true` แต่ไม่ได้ให้ลิงก์ที่ถูกต้อง ให้กำหนดเส้นทาง relative หรือ URL ภายนอกที่ต้องการเขียนลง Markdown ก่อนคืนค่า `true`

**ลิงก์ภาพควรใช้ตัวคั่นเส้นทางแบบไหน?**

ใช้เครื่องหมายทับ (`/`) ในลิงก์ Markdown และ URL ใช้ `Path.resolve` เฉพาะสำหรับเส้นทางระบบไฟล์ แล้วสร้างหรือทำให้ลิงก์ Markdown เป็นแบบ normalized แยกต่างหาก

**ลิงก์ไฮเปอร์เท็กซ์จะถูกเก็บไว้ระหว่างการส่งออก Markdown หรือไม่?**

ใช่ ข้อความ [hyperlinks](/slides/th/java/manage-hyperlinks/) จะถูกเก็บเป็นลิงก์ Markdown มาตรฐาน สไลด์ [transitions](/slides/th/java/slide-transition/) และ [animations](/slides/th/java/powerpoint-animation/) จะไม่ถูกแปลง

**สามารถแปลงงานนำเสนอเป็น Markdown ได้แบบขนานหรือไม่?**

คุณสามารถประมวลผลไฟล์งานนำเสนอหลายไฟล์พร้อมกันได้ แต่ไม่ควรแชร์ออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ระหว่างเธรด ให้ปฏิบัติตาม [multithreading guidelines](/slides/th/java/multithreading/) และใช้อินสแตนซ์แยกกันสำหรับแต่ละไฟล์