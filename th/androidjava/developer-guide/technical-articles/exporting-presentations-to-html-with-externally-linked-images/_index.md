---
title: ส่งออกงานนำเสนอเป็น HTML พร้อมภาพที่เชื่อมโยงภายนอก
type: docs
weight: 100
url: /th/androidjava/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- ส่งออกสไลด์
- ส่งออก PPT
- ส่งออก PPTX
- ส่งออก ODP
- PowerPoint เป็น HTML
- OpenDocument เป็น HTML
- งานนำเสนอเป็น HTML
- สไลด์เป็น HTML
- PPT เป็น HTML
- PPTX เป็น HTML
- ODP เป็น HTML
- ภาพที่เชื่อมโยง
- ภาพที่เชื่อมโยงภายนอก
- ทรัพยากรที่เชื่อมโยง
- ทรัพยากรภายนอก
- Android
- Java
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น HTML ใน Android ผ่าน Java โดยใช้ Aspose.Slides พร้อมภาพและทรัพยากรอื่น ๆ ที่บันทึกเป็นไฟล์ที่เชื่อมโยงภายนอก."
---
## **ภาพรวม**

โดยค่าเริ่มต้น Aspose.Slides จะส่งออกรายการนำเสนอเป็นไฟล์ HTML ที่บรรจุทุกอย่างเอง รูปภาพและทรัพยากรอื่น ๆ จะถูกเขียนโดยตรงเข้าไปใน HTML โดยปกติเป็นข้อมูล Base64 สิ่งนี้สะดวกเมื่อคุณต้องการไฟล์พกพาเดียวแต่ไม่ใช่รูปแบบที่ดีที่สุดสำหรับการดูในเว็บ CMS หรือสายการแปลงฝั่งเซิร์ฟเวอร์ตาซึ่งจะเผยแพร่ผลลัพธ์ต่อไป

ใช้ทรัพยากรที่เชื่อมโยงภายนอกเมื่อคุณต้องการ:
- ลดขนาดของเอกสาร HTML;
- แคชรูปภาพ ฟอนท์ เสียง หรือวิดีโอแยกต่างหากในเบราว์เซอร์หรือ CDN;
- ตรวจสอบ แทนที่ บีบอัด หรือหลังการประมวลผลทรัพยากรที่สร้างขึ้นหลังจากการส่งออก;
- รักษาโครงสร้างผลลัพธ์ให้ใกล้เคียงกับที่แอปพลิเคชันเว็บคาดหวัง.

สำหรับกระบวนการแปลง HTML ทั่วไป ดูที่ [แปลงงานนำเสนอ PowerPoint เป็น HTML](/slides/th/androidjava/convert-powerpoint-to-html/). บทความนี้มุ่งเน้นที่ส่วนการเชื่อมโยงทรัพยากรของการส่งออก.

## **วิธีการทำงานของการส่งออกทรัพยากรที่เชื่อมโยง**

[ILinkEmbedController](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilinkembedcontroller/) ให้แอปพลิเคชันของคุณตัดสินใจตามทรัพยากรว่าผู้ส่งออกจะแทรกข้อมูลลงใน HTML หรือบันทึกภายนอกและเขียนลิงก์

อินเทอร์เฟซมีสามเมธอด:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilinkembedcontroller/) ตัดสินใจว่าทรัพยากรควรเชื่อมโยงหรือฝังไว้
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilinkembedcontroller/) คืนค่ากลับ URL ที่จะเขียนลงใน HTML ที่สร้างหรือทรัพยากรที่เชื่อมโยงอื่น
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilinkembedcontroller/) เขียนข้อมูลทรัพยากรที่เชื่อมโยงไปยังดิสก์หรือเป้าหมายการเก็บอื่น

เส้นทางของระบบไฟล์และ URL ของเบราว์เซอร์เป็นเรื่องแยกจากกัน ตัวอย่างเช่น ตัวอย่างด้านล่างเขียนไฟล์ทรัพยากรไปที่ `html-output/assets` ในที่เก็บไฟล์ของแอปพลิเคชัน ในขณะที่ HTML มี URL เชิงสัมพันธ์เช่น `assets/resource-1.svg`. เบราว์เซอร์จะแก้ไข URL เหล่านี้ตามไฟล์ที่มีลิงก์ ดังนั้นลิงก์จาก `presentation.html` ไปยังไฟล์ SVG จะใช้ `assets/resource-1.svg` ขณะที่ลิงก์จากไฟล์ SVG นั้นไปยังรูปภาพที่บันทึกในโฟลเดอร์ `assets` เดียวกันจะใช้ `resource-4.jpg`.

## **ส่งออก HTML พร้อมทรัพยากรที่เชื่อมโยง**

ตัวอย่าง Android Java ด้านล่างสร้างไดเรกทอรีผลลัพธ์ บันทึกไฟล์ HTML ไว้ที่นั่นและเก็บทรัพยากรที่เชื่อมโยงในไดเรกทอรีย่อย `assets`. ส่งผ่านไดเรกทอรีที่แอปเป็นเจ้าของเช่น `context.getFilesDir()` เป็น `applicationFilesDirectory`. โค้ดหลีกเลี่ยง API `java.nio.file` ทำให้เข้ากันได้กับ Android `minSdk` 19.

คอนโทรลเลอร์จะเชื่อมโยงทรัพยากรภาพ ฟอนท์ เสียง วิดีโอและ CSS ที่พบบ่อยเมื่อ Aspose.Slides ให้หรือสามารถสรุปส่วนขยายไฟล์ที่ปลอดภัยได้ ทรัพยากรที่ไม่รู้จักจะยังคงฝังอยู่.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
            this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        }

        @Override
        public int getObjectStoringLocation(
                int resourceId,
                byte[] entityData,
                String semanticName,
                String contentType,
                String recommendedExtension) {
            String extension = resolveExtension(contentType, recommendedExtension);
            if (extension == null) {
                return LinkEmbedDecision.Embed;
            }

            fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
            return LinkEmbedDecision.Link;
        }

        @Override
        public String getUrl(int resourceId, int referrer) {
            String fileName = fileNamesByResourceId.get(resourceId);
            if (fileName == null) {
                return null;
            }

            if (fileNamesByResourceId.containsKey(referrer)) {
                return fileName;
            }

            return assetUrlPrefix + fileName;
        }

        @Override
        public void saveExternal(int resourceId, byte[] entityData) {
            String fileName = fileNamesByResourceId.get(resourceId);
            if (fileName == null) {
                throw new IllegalStateException(
                        "Resource " + resourceId + " was not registered for external storage.");
            }

            if (entityData == null || entityData.length == 0) {
                throw new IllegalStateException(
                        "Resource " + resourceId + " contains no data and cannot be saved.");
            }

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
        }

        private static String resolveExtension(String contentType, String recommendedExtension) {
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
                if (mappedExtension != null) {
                    return mappedExtension;
                }
            }

            if (!isSupportedContentType(contentType)) {
                return null;
            }

            return normalizeExtension(recommendedExtension);
        }

        private static boolean isSupportedContentType(String contentType) {
            return contentType != null &&
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
        }
    }
}
```

หลังการส่งออก โฟลเดอร์ผลลัพธ์จะมีโครงสร้างดังนี้:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

ไฟล์ที่แม่นยำขึ้นอยู่กับเนื้อหาของงานนำเสนอและตัวเลือกการส่งออก ตัวอย่างเช่น ภาพเรสเตอร์มักจะส่งออกเป็น JPEG หรือ PNG Aspose.Slides อาจเลือกใช้โคเดกภาพที่แตกต่างจากที่ใช้ในงานนำเสนอต้นฉบับเมื่อมันทำให้ไฟล์มีขนาดเล็กลงหรือเหมาะสมกว่า รูปภาพที่มีความโปร่งใสจะส่งออกเป็น PNG.

## **การเลือก URL สำหรับการปรับใช้**

ตัวอย่างใช้คำนำหน้า URL เชิงสัมพันธ์: `assets/`. หากเปิด `presentation.html` จาก `html-output/presentation.html` เบราว์เซอร์จะโหลด `html-output/assets/resource-1.svg`.

เมื่อทรัพยากรที่เชื่อมโยงหนึ่งอ้างอิงถึงทรัพยากรที่เชื่อมโยงอีกอัน ตัวอย่างใช้พารามิเตอร์ `referrer` ใน [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilinkembedcontroller/) และคืนค่าเฉพาะชื่อไฟล์เท่านั้น ตัวอย่างเช่น หาก `resource-1.svg` และ `resource-4.jpg` อยู่ในโฟลเดอร์ `assets` ไฟล์ SVG ควรอ้างถึง `resource-4.jpg` ไม่ใช่ `assets/resource-4.jpg`.

ใช้คำนำหน้า URL ที่แตกต่างเมื่อไฟล์ถูกปรับใช้ในที่อื่น:
- ใช้ `assets/` เมื่อไดเรกทอรีทรัพยากรอยู่ใกล้ไฟล์ HTML
- ใช้ `../assets/` เมื่อไดเรกทอรีทรัพยากรอยู่หนึ่งระดับเหนือไฟล์ HTML
- ใช้ `https://cdn.example.com/presentations/job-123/assets/` เมื่อไฟล์ถูกอัปโหลดไปยัง CDN หรือเซิร์ฟเวอร์ไฟล์สแตติก

URL ที่คืนจาก [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilinkembedcontroller/) ต้องตรงกับตำแหน่งที่ปรับใช้ขั้นสุดท้ายของไฟล์ที่เขียนโดย [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilinkembedcontroller/). ในแอป Android ใช้ที่เก็บไฟล์เฉพาะแอป ไดรเรกทอรีแคช หรือไดเรกทอรีที่ได้มาจาก Storage Access Framework ตามขั้นตอนการเผยแพร่ของคุณ ในแอปเซิร์ฟเวอร์ ใช้ไดเรกทอรีผลลัพธ์ที่ไม่ซ้ำกันหรือคำนำหน้า object-storage สำหรับแต่ละงานแปลงเพื่อหลีกเลี่ยงการเขียนทับไฟล์จากการส่งออกอื่น

## **เมื่อใดควรฝังแทน**

HTML ที่ฝัง Base64 ยังมีประโยชน์เมื่อผลลัพธ์ต้องเป็นไฟล์เดียว เช่น ไฟล์แนบอีเมล ตัวอย่างออฟไลน์ หรือเอกสารที่จะย้ายโดยไม่มีโฟลเดอร์ทรัพยากรสนับสนุน ทรัพยากรที่เชื่อมโยงเหมาะสมกว่าเมื่อ HTML จะให้บริการโดยเว็บแอป เก็บใน CMS ปรับโดย pipeline การสร้าง หรือแคชโดยเบราว์เซอร์แยกจาก HTML

## **คำถามที่พบบ่อย**

**ฉันสามารถแยกไฟล์รูปภาพเท่านั้นและให้ทรัพยากรอื่น ๆ ยังคงฝังอยู่ได้ไหม?**

ใช่ ใน [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilinkembedcontroller/) ให้คืนค่า `Link` จาก [LinkEmbedDecision](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linkembeddecision/) เฉพาะประเภทเนื้อหาที่คุณต้องการบันทึกเป็นไฟล์แยก และคืนค่า `Embed` สำหรับส่วนที่เหลือทั้งหมด

**ทำไมส่วนขยายของภาพที่ส่งออกจึงแตกต่างจากงานนำเสนอต้นฉบับ?**

Aspose.Slides อาจเข้ารหัสภาพเรสเตอร์ใหม่ระหว่างการส่งออกเป็น HTML เพื่อปรับขนาดหรือความเข้ากันได้กับเบราว์เซอร์ ตัวอย่างเช่น ภาพจากไฟล์ต้นฉบับอาจถูกเขียนเป็น JPEG หรือ PNG ขึ้นอยู่กับผลลัพธ์ที่เรนเดอร์

**URL เชิงสัมพันธ์ทำงานหลังจากย้ายไฟล์ HTML หรือไม่?**

URL เชิงสัมพันธ์ทำงานเฉพาะเมื่อโครงสร้างโฟลเดอร์เชิงสัมพันธ์เดียวกันยังคงอยู่ หาก HTML อ้างถึง `assets/resource-1.png` โฟลเดอร์ `assets` ต้องอยู่ข้างไฟล์ HTML ยกเว้นคุณสร้างคำนำหน้า URL ที่แตกต่าง

**ฉันสามารถเขียนทรัพยากรลงในที่จัดเก็บภายนอกสาธารณะบน Android ได้หรือไม่?**

ใช่ หากแอปของคุณมีปลายทางที่ถูกต้องและโมเดลสิทธิ์สำหรับเวอร์ชัน Android ที่เป้าหมาย สำหรับ HTML ที่สร้างขึ้นและใช้โดยแอปของคุณเท่านั้น ไฟล์เฉพาะแอปหรือไดเรกทอรีแคชมักง่ายกว่า สำหรับผลลัพธ์ที่ผู้ใช้เห็น ให้ใช้ตำแหน่งที่ผู้ใช้เลือกหรือวิธีการจัดเก็บอื่นที่เหมาะกับแอปของคุณ

**แอปเซิร์ฟเวอร์ควรใช้ไดเรกทอรีผลลัพธ์เดียวกันซ้ำหรือไม่?**

ไม่ ควรใช้ไดเรกทอรีผลลัพธ์หรือคำนำที่เก็บที่ไม่ซ้ำกันสำหรับแต่ละงานแปลง เพื่อหลีกเลี่ยงการชนกันของชื่อไฟล์และป้องกันการเขียนทับทรัพยากรที่สร้างจากการส่งออกอื่น