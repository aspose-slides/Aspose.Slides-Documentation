---
title: ส่งออกงานนำเสนอเป็น HTML พร้อมภาพที่เชื่อมโยงภายนอก
type: docs
weight: 100
url: /th/java/exporting-presentations-to-html-with-externally-linked-images/
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
- ภาพที่เชื่อมโยงจากภายนอก
- ทรัพยากรที่เชื่อมโยง
- ทรัพยากรภายนอก
- Java
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น HTML ด้วย Java โดยใช้ Aspose.Slides พร้อมบันทึกภาพและทรัพยากรอื่นเป็นไฟล์ที่เชื่อมโยงจากภายนอก"
---
## **ภาพรวม**

โดยค่าเริ่มต้น Aspose.Slides จะส่งออกงานนำเสนอเป็นไฟล์ HTML ที่มีทั้งหมดในไฟล์เดียว ภาพและทรัพยากรอื่น ๆ จะถูกเขียนลงใน HTML โดยตรง ส่วนใหญ่ในรูปแบบ Base64 การทำเช่นนี้สะดวกเมื่อคุณต้องการไฟล์พกพาเดียว แต่ไม่ใช่รูปแบบที่เหมาะที่สุดเสมอสำหรับเว็บไซต์, ระบบจัดการเนื้อหา (CMS) หรือกระบวนการแปลงฝั่งเซิร์ฟเวอร์

ใช้ทรัพยากรที่เชื่อมโยงภายนอกเมื่อคุณต้องการ:

- ลดขนาดของเอกสาร HTML
- แคชภาพ, ฟอนต์, เสียง หรือวิดีโอแยกต่างหากในเบราว์เซอร์หรือ CDN
- ตรวจสอบ, เปลี่ยน, บีบอัด หรือทำการประมวลผลต่อเนื่องบนทรัพยากรที่สร้างขึ้นหลังการส่งออก
- ทำให้โครงสร้างผลลัพธ์ใกล้เคียงกับที่แอปพลิเคชันเว็บคาดหวัง

สำหรับกระบวนการแปลง HTML ทั่วไป ให้ดูที่ [Convert PowerPoint Presentations to HTML](/slides/th/java/convert-powerpoint-to-html/). บทความนี้เน้นที่ส่วนการเชื่อมโยงทรัพยากรของการส่งออก

## **วิธีการทำงานของการส่งออกทรัพยากรที่เชื่อมโยง**

[ILinkEmbedController](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) ให้แอปพลิเคชันของคุณตัดสินใจตามทรัพยากรว่า ตัวส่งออกควรฝังข้อมูลใน HTML หรือบันทึกเป็นไฟล์ภายนอกและเขียนลิงก์

อินเทอร์เฟซมีสามเมธอด:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) กำหนดว่าทรัพยากรควรเชื่อมโยงหรือฝัง
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) คืนค่า URL ที่จะเขียนลงใน HTML ที่สร้างหรือทรัพยากรที่เชื่อมโยงอื่น
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) เขียนข้อมูลทรัพยากรที่เชื่อมโยงลงดิสก์หรือเป้าหมายที่เก็บอื่น

เส้นทางของระบบไฟล์และ URL ของเบราว์เซอร์เป็นเรื่องแยกกัน ตัวอย่างเช่น ตัวอย่างด้านล่างเขียนไฟล์ทรัพยากรลงใน `html-output/assets` บนดิสก์ ในขณะที่ HTML มี URL แบบสัมพันธ์เช่น `assets/resource-1.svg` เบราว์เซอร์จะตีความ URL เหล่านั้นสัมพันธ์กับไฟล์ที่มีลิงก์นั้น ดังนั้นลิงก์จาก `presentation.html` ไปยังไฟล์ SVG จะใช้ `assets/resource-1.svg` ในขณะที่ลิงก์จากไฟล์ SVG นั้นไปยังรูปภาพที่บันทึกในโฟลเดอร์ `assets` เดียวกันจะใช้ `resource-4.jpg`

## **ส่งออก HTML พร้อมทรัพยากรที่เชื่อมโยง**

ตัวอย่าง Java ด้านล่างสร้างไดเรกทอรีเอาต์พุต, บันทึกไฟล์ HTML ไว้ที่นั่น, และเก็บทรัพยากรที่เชื่อมโยงในโฟลเดอร์ย่อย `assets` ตัวคอนโทรลเลอร์จะเชื่อมโยงภาพ, ฟอนต์, เสียง, วิดีโอและทรัพยากร CSS ที่ Aspose.Slides ให้หรือสามารถสรุปนามสกุลไฟล์ที่ปลอดภัยได้ ทรัพยากรที่ไม่รู้จักจะยังคงฝังอยู่

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void main(String[] args) throws IOException {
        Path inputFilePath = Paths.get("presentation.pptx");
        Path outputDirectory = Paths.get("html-output");
        String assetDirectoryName = "assets";
        Path assetDirectory = outputDirectory.resolve(assetDirectoryName);

        Files.createDirectories(outputDirectory);
        Files.createDirectories(assetDirectory);

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFilePath.toString());
        try {
            Path htmlFilePath = outputDirectory.resolve("presentation.html");
            presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final Path assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

        private ExternalResourceController(Path assetDirectory, String assetUrlPrefix) {
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

            try {
                Files.createDirectories(assetDirectory);
                Path filePath = assetDirectory.resolve(fileName);
                Files.write(filePath, entityData);
            } catch (IOException exception) {
                throw new IllegalStateException("Failed to save external resource " + resourceId + ".", exception);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<>();
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
            if (contentType != null && !contentType.trim().isEmpty()) {
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
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
            if (extension == null || extension.trim().isEmpty()) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.isEmpty()) {
                return null;
            }

            for (int index = 0; index < extensionCharacters.length(); index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.ROOT);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.isEmpty()) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }
}
```

หลังจากการส่งออก โฟลเดอร์เอาต์พุตจะมีโครงสร้างดังนี้:

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

ไฟล์ที่แน่นอนขึ้นอยู่กับเนื้อหาของงานนำเสนอและตัวเลือกการส่งออก ตัวอย่างเช่น ภาพเรสเตอร์มักจะถูกส่งออกเป็น JPEG หรือ PNG Aspose.Slides อาจเลือกโค้ดภาพที่ต่างจากที่ใช้ในงานนำเสนอเดิมเมื่อทำเช่นนั้นทำให้ไฟล์มีขนาดเล็กลงหรือเหมาะสมกว่า ภาพที่มีความโปร่งใสจะถูกส่งออกเป็น PNG

## **การเลือก URL สำหรับการปรับใช้**

ตัวอย่างใช้คำนำหน้า URL แบบสัมพันธ์: `assets/` หากเปิด `presentation.html` จาก `html-output/presentation.html` เบราว์เซอร์จะโหลด `html-output/assets/resource-1.svg`

เมื่อทรัพยากรที่เชื่อมโยงหนึ่งอ้างอิงถึงทรัพยากรที่เชื่อมโยงอีกตัวหนึ่ง ตัวอย่างใช้พารามิเตอร์ `referrer` ใน [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) และคืนค่าเฉพาะชื่อไฟล์เท่านั้น ตัวอย่างเช่น หาก `resource-1.svg` และ `resource-4.jpg` อยู่ในโฟลเดอร์ `assets` ไฟล์ SVG ควรอ้างอิงถึง `resource-4.jpg` ไม่ใช่ `assets/resource-4.jpg`

ใช้คำนำหน้า URL ที่แตกต่างเมื่อไฟล์ถูกปรับใช้ในตำแหน่งอื่น:

- ใช้ `assets/` เมื่อไดเรกทอรีแอสเซทอยู่ข้างๆ ไฟล์ HTML
- ใช้ `../assets/` เมื่อไดเรกทอรีแอสเซทอยู่ระดับหนึ่งเหนือไฟล์ HTML
- ใช้ `https://cdn.example.com/presentations/job-123/assets/` เมื่อไฟล์ถูกอัปโหลดไปยัง CDN หรือเซิร์ฟเวอร์ไฟล์สแตติก

URL ที่คืนโดย [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) ต้องตรงกับตำแหน่งที่ไฟล์จะถูกวางจริงโดย [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) ในแอปพลิเคชันเซิร์ฟเวอร์ ควรใช้ไดเรกทอรีเอาต์พุตหรือคำนำหน้าออบเจ็กต์สตอเรจที่ไม่ซ้ำกันสำหรับแต่ละงานแปลง เพื่อหลีกเลี่ยงการเขียนทับไฟล์จากการส่งออกอื่น

## **เมื่อใดควรฝังแทน**

HTML ที่ฝัง Base64 ยังมีประโยชน์เมื่อผลลัพธ์ต้องเป็นไฟล์เดียว เช่น การแนบอีเมล, ตัวอย่างออฟไลน์, หรือเอกสารที่จะย้ายโดยไม่มีโฟลเดอร์แอสเซทรองรับ ทรัพยากรที่เชื่อมโยงเหมาะสมกว่าเมื่อ HTML จะให้บริการโดยเว็บแอปพลิเคชัน, เก็บใน CMS, ถูกเพิ่มประสิทธิภาพโดย pipeline การสร้าง, หรือแคชโดยเบราว์เซอร์แยกจาก HTML

## **คำถามที่พบบ่อย**

**ฉันสามารถแยกภาพออกเป็นไฟล์ภายนอกและให้ทรัพยากรอื่น ๆ ยังคงฝังอยู่ได้หรือไม่?**  

ใช่ ใน [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) ให้คืนค่า `LinkEmbedDecision.Link` เฉพาะสำหรับประเภทเนื้อหาที่คุณต้องการบันทึกเป็นไฟล์แยก และคืนค่า `LinkEmbedDecision.Embed` สำหรับส่วนอื่นทั้งหมด

**ทำไมนามสกุลของภาพที่ส่งออกจึงแตกต่างจากงานนำเสนอต้นฉบับ?**  

Aspose.Slides อาจทำการเข้ารหัสใหม่ใหม่ภาพเรสเตอร์ระหว่างการส่งออก HTML เพื่อปรับขนาดหรือความเข้ากันได้กับเบราว์เซอร์ ตัวอย่างเช่น ภาพจากไฟล์ต้นฉบับอาจถูกเขียนเป็น JPEG หรือ PNG ขึ้นอยู่กับผลลัพธ์ที่เรนเดอร์ได้

**URL แบบสัมพันธ์ยังทำงานได้หลังจากที่ย้ายไฟล์ HTML ไปหรือไม่?**  

URL แบบสัมพันธ์ทำงานได้ก็ต่อเมื่อโครงสร้างโฟลเดอร์แบบสัมพันธ์เดียวกันยังคงอยู่ หาก HTML อ้างอิง `assets/resource-1.png` โฟลเดอร์ `assets` ต้องอยู่ข้างไฟล์ HTML นั้น เว้นแต่คุณจะสร้างคำนำหน้า URL ที่แตกต่าง

**แอปพลิเคชันเซิร์ฟเวอร์ควรใช้โฟลเดอร์ผลลัพธ์เดียวกันซ้ำหรือไม่?**  

ไม่ ควรใช้ไดเรกทอรีเอาต์พุตหรือคำนำหน้าที่จัดเก็บที่ไม่ซ้ำกันสำหรับแต่ละงานแปลง เพื่อหลีกเลี่ยงการชนของชื่อไฟล์และป้องกันการเขียนทับทรัพยากรที่สร้างโดยการส่งออกอื่น