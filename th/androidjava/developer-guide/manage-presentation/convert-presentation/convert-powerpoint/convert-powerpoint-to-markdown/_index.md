---
title: แปลงงานนำเสนอ PowerPoint เป็น Markdown บน Android
linktitle: PowerPoint ไปเป็น Markdown
type: docs
weight: 140
url: /th/androidjava/convert-powerpoint-to-markdown/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint ไปเป็น MD
- งานนำเสนอไปเป็น MD
- สไลด์ไปเป็น MD
- PPT ไปเป็น MD
- PPTX ไปเป็น MD
- บันทึก PowerPoint เป็น Markdown
- บันทึกงานนำเสนอเป็น Markdown
- บันทึกสไลด์เป็น Markdown
- บันทึก PPT เป็น MD
- บันทึก PPTX เป็น MD
- ส่งออก PPT ไปเป็น MD
- ส่งออก PPTX ไปเป็น MD
- การส่งออกรูปภาพ Markdown
- ลิงก์รูปภาพ CDN
- PowerPoint
- งานนำเสนอ
- Markdown
- Android
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PPT และ PPTX ไปเป็น Markdown บน Android ผ่าน Java และควบคุมตำแหน่งที่บันทึกและอ้างอิงรูปภาพบิตแมป, เมตาไฟล์, และ SVG ที่ส่งออก"
---
## **ภาพรวม**

Aspose.Slides สำหรับ Android ผ่าน Java สามารถแปลงงานนำเสนอ PPT และ PPTX ไปเป็น Markdown เพื่อใช้ในเอกสาร เว็บไซต์แบบคงที่ การย้ายเนื้อหา และกระบวนการควบคุมเวอร์ชัน คุณสามารถเลือกรูปแบบ Markdown ควบคุมวิธีการแสดงผลเนื้อหาสไลด์ และกำหนดตำแหน่งที่จัดเก็บรูปภาพที่ส่งออกและวิธีที่ Markdown ที่สร้างขึ้นอ้างอิงถึงรูปภาพเหล่านั้น

โดยค่าเริ่มต้น การส่งออก Markdown จะใช้ผลลัพธ์แบบข้อความเท่านั้น เพื่อส่งออกเนื้อหาภาพ ให้ตั้งค่าประเภทการส่งออกด้วยเมธอด [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/) เป็นค่า `Sequential` หรือ `Visual` จาก enumeration [MarkdownExportType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownexporttype/) `Sequential` จะเรนเดอร์รายการสไลด์แยกกันและตามลำดับ ส่วน `Visual` จะเก็บรายการที่จัดกลุ่มไว้ด้วยกันเพื่อรักษาความสัมพันธ์เชิงภาพ ค่า `TextOnly` จะไม่สร้างทรัพยากรรูปภาพ ดังนั้นคอลแบ็กการบันทึกรูปภาพจะไม่ถูกเรียกใช้ในโหมดนั้น

## **แปลงงานนำเสนอเป็น Markdown**

โหลดไฟล์ต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วเรียกเมธอด [Presentation.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ด้วยค่า `Md` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/saveformat/)

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

## **เลือกรูปแบบ Markdown**

เมธอด [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/) ควบคุมสเปค Markdown ที่ใช้สำหรับผลลัพธ์ enumeration [Flavor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/flavor/) รวมถึง CommonMark, GitHub Flavored Markdown และรูปแบบที่รองรับอื่น ๆ

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

## **ส่งออกรูปภาพโดยใช้การบันทึกในเครื่องแบบเริ่มต้น**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/) มีเมธอดสองตัวสำหรับกำหนดการบันทึกรูปภาพในเครื่อง:

- [setBasePath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/) ระบุไดเรกทอรีฐานสำหรับเอกสาร Markdown และทรัพยากรของมัน
- [setImagesSaveFolderName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/) ระบุโฟลเดอร์ย่อยสำหรับรูปภาพ ค่าเริ่มต้นคือ `Images`

ตัวอย่างต่อไปนี้เรนเดอร์เนื้อหาภาพ เขียนรูปภาพไปที่ `output/assets` และสร้างลิงก์รูปภาพแบบสัมพันธ์ในเอกสาร Markdown:

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

พฤติกรรมนี้ยังทำหน้าที่เป็นวิธีสำรองเมื่อคอลแบ็กการบันทึกรูปภาพแบบกำหนดเองคืนค่า `false`

## **กำหนดการบันทึกรูปภาพและลิงก์ Markdown เอง**

ใช้เมธอด [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/) เพื่อลงทะเบียนคอลแบ็กสำหรับทรัพยากรบิทแมปและเมตาไฟล์ที่ไม่ใช่ SVG ที่ถูกสร้างระหว่างการส่งออก Markdown คอลแบ็ก `MarkdownImageSavingHandler` จะรับอ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) ค่าของ [ImageFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imageformat/) และลิงก์ Markdown ที่สร้างขึ้นเป็นพารามิเตอร์ `String[]` หนึ่งอิลิเมนต์ ให้บันทึกหรืออัปโหลดรูปภาพด้วยฟอร์แมตที่ให้มา และแทนที่ `link[0]` ด้วยอ้างอิงที่ต้องการให้ปรากฏในผลลัพธ์ Markdown

ทรัพยากรที่สร้างในรูปแบบ SVG จะถูกจัดการแยกต่างหาก ลงทะเบียนคอลแบ็กด้วยเมธอด [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/) คอลแบ็ก `MarkdownSvgImageSavingHandler` จะรับอ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) และพารามิเตอร์ `String[] link` หนึ่งอิลิเมนต์ SVG ไม่มีอาร์กิวเมนต์ `ImageFormat` ให้เขียนหรืออัปโหลดข้อมูล XML ของมันจากเมธอด [ISvgImage.getSvgData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) แทน ขึ้นอยู่กับโหมดการส่งออกและการจัดกลุ่มเชิงภาพ SVG ในงานนำเสนอแหล่งอาจถูกเรสเตอร์ไลส์หรือรวมกับเนื้อหาอื่น ๆ ผลลัพธ์ที่ไม่ใช่ SVG จะถูกส่งต่อไปยังคอลแบ็กการบันทึกรูปภาพลงทะเบียนทั้งสองคอลแบ็กเมื่อทุกทรัพยากรภาพที่ส่งออกต้องการการประมวลผลแบบกำหนดเอง

ค่าที่คอลแบ็กคืนมาตรงกับผู้ที่ทำการประมวลผลรูปภาพ:

- คืนค่า `true` หลังจากตัวจัดการบันทึก อัปโหลด แปลงรูปภาพ หรือประมวลผลรูปภาพใด ๆ และกำหนดค่าที่ถูกต้องให้กับ `link[0]`. Aspose.Slides จะเขียนค่านั้นลงในเอกสาร Markdown และจะไม่ทำการบันทึกในเครื่องตามค่าเริ่มต้น
- คืนค่า `false` เพื่อให้ Aspose.Slides บันทึกรูปภาพในเครื่องและสร้างลิงก์ตามค่าที่ตั้งโดย [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/) และ [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/)

{{% alert color="warning" title="Important" %}}
ตัวจัดการที่คืนค่า `true` จะรับผิดชอบต่อภาพ หากมันคืนค่า `true` แต่ไม่ได้กำหนดลิงก์ที่ถูกต้องและไม่ว่างเปล่า การส่งออกจะล้มเหลวพร้อมกับ `InvalidOperationException`.
{{% /alert %}}

### **บันทึกรูปภาพลงในไดเรกทอรีต้นฉบับ CDN และใช้ URL ภายนอก**

ตัวอย่างต่อไปนี้ถือว่า `cdn-origin/presentations/quarterly-report` เป็นไดเรกทอรีต้นฉบับ CDN ที่ถูกเมานท์หรือซิงโครไนซ์ ตัวจัดการแต่ละตัวจะดึงชื่อไฟล์ที่สร้างขึ้น บันทึกรูปภาพไปยังไดเรกทอรีที่กำหนดเองนั้น และแทนที่อ้างอิงในเครื่องที่สร้างขึ้นด้วย URL ของ CDN สาธารณะ ตัวอย่างนี้เองไม่มีการอัปโหลดผ่านเครือข่าย: URL จะใช้ได้ก็ต่อเมื่อไดเรกทอรีถูกเมานท์เป็นต้นฉบับ CDN หรือไฟล์ของมันถูกเผยแพร่ไปยัง CDN สำหรับการจัดเก็บเป็นออบเจกต์ ให้แทนที่การเขียนไฟล์ระบบด้วยการอัปโหลดของ SDK storage และกำหนด `link[0]` หลังจากอัปโหลดสำเร็จ

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

คอลแบ็กบิทแมปตั้งใจคืนค่า `false` สำหรับรูปภาพที่มีขนาดเล็กกว่า 128 × 128 พิกเซล ดังนั้น Aspose.Slides จะบันทึกรูปภาพเหล่านั้นไปที่ `output/fallback-images` ตามพฤติกรรมเริ่มต้น รูปภาพบิทแมปและเมตาไฟล์ขนาดใหญ่ รวมถึงทรัพยากร SVG จะถูกจัดการโดยโค้ดกำหนดเอง ตัวอย่างเช่น อ้างอิงในเครื่องที่สร้างขึ้นเช่น `fallback-images/image1.png` จะกลายเป็น `https://cdn.example.com/presentations/quarterly-report/image1.png` ตัวจัดการใช้เส้นทางของระบบปฏิบัติการเท่าที่เขียนไฟล์; ลิงก์ที่เขียนลงใน Markdown ใช้เครื่องหมาย `/` และชื่อไฟล์ที่ทำ URL‑escape ปฏิบัติกฎเดียวกันเมื่อต้องสร้างลิงก์แบบสัมพันธ์: ใช้ `/` ไม่ใช่ตัวแบ่งไดเรกทอรีตามแพลตฟอร์ม

## **คำถามที่พบบ่อย**

**ตัวจัดการสามารถประมวลผลทั้งภาพราสเตอร์และภาพ SVG พร้อมกันได้หรือไม่?**

ไม่. ใช้ [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/) สำหรับทรัพยากรบิทแมปและเมตาไฟล์ที่ถูกสร้างและใช้ [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/) สำหรับทรัพยากรที่ส่งออกเป็น SVG ตัวแรกจะให้เหตุการณ์ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) และค่า [ImageFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imageformat/) ตัวที่สองจะให้เหตุการณ์ [ISvgImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) ซึ่งข้อมูล SVG สามารถอ่านได้จาก [ISvgImage.getSvgData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isvgimage/) SVG ที่ถูกเรสเตอร์ไลส์ระหว่างการส่งออกจะถูกประมวลผลโดยคอลแบ็กการบันทึกรูปภาพแทน

**อะไรจะเกิดขึ้นเมื่อตัวจัดการบันทึกรูปภาพคืนค่า `false`?**

Aspose.Slides จะใช้พฤติกรรมการบันทึกในเครื่องค่าเริ่มต้น ตำแหน่งของรูปภาพและลิงก์ที่สร้างขึ้นจะถูกควบคุมโดยค่าที่ตั้งด้วย [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/) และ [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/markdownsaveoptions/)

**ตัวจัดการสามารถให้ URL โดยไม่บันทึกรูปภาพในเครื่องได้หรือไม่?**

ได้ ตัวจัดการสามารถอัปโหลดรูปภาพไปยังที่เก็บออบเจกต์หรือส่งต่อให้บริการอื่น ๆ กำหนด URL ที่ได้ให้กับ `link[0]` แล้วคืนค่า `true` ตัวจัดการต้องทำการประมวลผลให้เสร็จสิ้นด้วยตนเอง; การคืนค่า `true` จะป้องกันการบันทึกในเครื่องตามค่าเริ่มต้น

**ทำไมการส่งออก Markdown ถึงโยน `InvalidOperationException` จากตัวจัดการ?**

ข้อยกเว้นนี้เกิดขึ้นเมื่อคอลแบ็กคืนค่า `true` แต่ไม่ได้ให้ลิงก์ที่ถูกต้อง ให้กำหนดเส้นทางสัมพันธ์หรือ URL ภายนอกที่ควรเขียนลงใน Markdown ก่อนคืนค่า `true`

**ตัวแบ่งเส้นทางใดควรใช้สำหรับลิงก์รูปภาพ?**

ใช้เครื่องหมาย `/` ในลิงก์ Markdown และ URL ใช้ `Path.resolve` เฉพาะสำหรับเส้นทางของระบบไฟล์ แล้วสร้างหรือทำให้เป็นมาตรฐานลิงก์ Markdown แยกต่างหาก

**ลิงก์ไฮเปอร์เท็กซ์จะถูกเก็บไว้ในการส่งออก Markdown หรือไม่?**

ใช่ ข้อความ [hyperlinks](/slides/th/androidjava/manage-hyperlinks/) จะถูกเก็บเป็นลิงก์ Markdown มาตรฐาน สไลด์ [transitions](/slides/th/androidjava/slide-transition/) และ [animations](/slides/th/androidjava/powerpoint-animation/) จะไม่ถูกแปลง

**สามารถแปลงงานนำเสนอเป็น Markdown แบบขนานได้หรือไม่?**

คุณสามารถประมวลผลไฟล์งานนำเสนอหลายไฟล์พร้อมกันได้ แต่ห้ามใช้อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เดียวกันระหว่างเธรด ปฏิบัติตาม [multithreading guidelines](/slides/th/androidjava/multithreading/) และใช้อินสแตนซ์แยกสำหรับแต่ละไฟล์