---
title: ส่งออกพรีเซนเทชันเป็น HTML พร้อมภาพที่เชื่อมโยงจากภายนอก
type: docs
weight: 100
url: /th/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกพรีเซนเทชัน
- ส่งออกสไลด์
- ส่งออก PPT
- ส่งออก PPTX
- ส่งออก ODP
- PowerPoint เป็น HTML
- OpenDocument เป็น HTML
- พรีเซนเทชันเป็น HTML
- สไลด์เป็น HTML
- PPT เป็น HTML
- PPTX เป็น HTML
- ODP เป็น HTML
- ภาพที่เชื่อมโยง
- ภาพที่เชื่อมโยงจากภายนอก
- ทรัพยากรที่เชื่อมโยง
- ทรัพยากรภายนอก
- PHP
- Aspose.Slides
description: "ส่งออกพรีเซนเทชัน PowerPoint และ OpenDocument เป็น HTML ใน PHP ผ่าน Java โดยใช้ Aspose.Slides พร้อมภาพและทรัพยากรอื่น ๆ ที่บันทึกเป็นไฟล์ที่เชื่อมโยงจากภายนอก."
---
## **ภาพรวม**

โดยค่าเริ่มต้น Aspose.Slides จะส่งออกพรีเซนเทชันเป็นไฟล์ HTML ที่ประกอบด้วยทุกอย่างเอง ภาพและทรัพยากรอื่น ๆ จะถูกเขียนโดยตรงลงใน HTML โดยส่วนใหญ่เป็นข้อมูล Base64 สิ่งนี้สะดวกเมื่อต้องการไฟล์พกพาเพียงไฟล์เดียว แต่ไม่ใช่รูปแบบที่ดีที่สุดสำหรับเว็บไซต์, CMS หรือไพป์ไลน์การแปลงฝั่งเซิร์ฟเวอร์เสมอไป.

ใช้ทรัพยากรที่เชื่อมโยงภายนอกเมื่อต้องการ:

- ลดขนาดของเอกสาร HTML;
- แคชภาพ, ฟอนต์, ไฟล์เสียง หรือวิดีโอแยกต่างหากในเบราว์เซอร์หรือ CDN;
- ตรวจสอบ, แทนที่, บีบอัด, หรือทำกระบวนการหลังการสร้างทรัพยากรที่สร้างขึ้นหลังจากการส่งออก;
- ทำให้โครงสร้างผลลัพธ์ใกล้เคียงกับที่แอปพลิเคชันเว็บคาดหวัง.

สำหรับกระบวนการแปลง HTML โดยทั่วไป ดูที่ [Convert PowerPoint Presentations to HTML](/slides/th/php-java/convert-powerpoint-to-html/). บทความนี้เน้นที่ส่วนการเชื่อมโยงทรัพยากรของการส่งออก.

## **วิธีการทำงานของการส่งออกทรัพยากรที่เชื่อมโยง**

[HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/) สามารถใช้ตัวควบคุมการลิงค์/ฝังแบบกำหนดเองเมื่อ Aspose.Slides ส่งออกพรีเซนเทชันเป็น HTML ใน PHP ผ่าน Java สถานการณ์นี้มักจะถูกดำเนินการด้วยคลาสช่วยเหลือ Java เล็ก ๆ คอมไพล์คลาสนั้น, เพิ่มเข้าไปใน classpath ของ PHP Java Bridge, แล้วสร้างอินสแตนซ์จาก PHP ด้วย `new Java(...)`.

คลาสช่วยเหลือจะตัดสินใจแต่ละทรัพยากรว่า ตัวส่งออกจะฝังข้อมูลลงใน HTML หรือบันทึกแยกเป็นไฟล์ภายนอกและเขียนลิงก์ มันต้องการเมธอด callback สามเมธอด:

- `ExternalResourceController.getObjectStoringLocation` ตัดสินใจว่าทรัพยากรควรจะถูกลิงค์หรือฝัง.
- `ExternalResourceController.getUrl` คืนค่า URL ที่จะถูกเขียนลงใน HTML ที่สร้างขึ้นหรือในทรัพยากรเชื่อมโยงอื่น.
- `ExternalResourceController.saveExternal` เขียนข้อมูลทรัพยากรที่เชื่อมโยงไปยังดิสก์หรือเป้าหมายที่เก็บอื่น.

เส้นทางไฟล์ระบบและ URL ของเบราว์เซอร์เป็นเรื่องแยกกัน ตัวอย่างเช่น ตัวอย่างด้านล่างเขียนไฟล์ทรัพยากรไปที่ `html-output/assets` บนดิสก์ ในขณะที่ HTML มี URL แบบสัมพันธ์เช่น `assets/resource-1.svg` เบราว์เซอร์จะ resolve URL เหล่านี้สัมพันธ์กับไฟล์ที่มีลิงก์ ดังนั้นลิงก์จาก `presentation.html` ไปยังไฟล์ SVG จะใช้ `assets/resource-1.svg` ในขณะที่ลิงก์จากไฟล์ SVG นั้นไปยังภาพที่บันทึกในโฟลเดอร์ `assets` เดียวกันจะใช้ `resource-4.jpg`.

## **สร้างคลาสช่วยเหลือ Java**

สร้างคลาส Java เช่น `com.example.slides.ExternalResourceController`, คอมไพล์ด้วย Aspose.Slides for Java บน classpath, และทำให้คลาสหรือ JAR ที่คอมไพล์แล้วพร้อมใช้งานสำหรับ PHP Java Bridge.

คลาสช่วยเหลือด้านล่างจะลิงค์ภาพ, ฟอนต์, ไฟล์เสียง, วิดีโอ และทรัพยากร CSS ที่ทั่วไปเมื่อ Aspose.Slides ให้หรือสามารถสรุปส่วนขยายไฟล์ที่ปลอดภัยได้ ทรัพยากรที่ไม่รู้จักจะยังคงฝังอยู่.

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
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

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
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
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
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
```

## **ส่งออก HTML พร้อมทรัพยากรที่เชื่อมโยง**

โค้ด PHP ด้านล่างสร้างไดเรกทอรีผลลัพธ์, บันทึกไฟล์ HTML ไปที่นั่น, และเก็บทรัพยากรที่เชื่อมโยงไว้ในโฟลเดอร์ย่อย `assets`. โค้ดนี้รวม [HtmlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideimageformat/), และ [SaveFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/) สำหรับการส่งออก.

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

หลังจากการส่งออก โฟลเดอร์ผลลัพธ์มีโครงสร้างดังนี้:

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

ไฟล์ที่สร้างขึ้นจริงขึ้นอยู่กับเนื้อหาพรีเซนเทชันและตัวเลือกการส่งออก ตัวอย่างเช่น ภาพเรสเตอร์มักจะถูกส่งออกเป็น JPEG หรือ PNG Aspose.Slides อาจเลือกโค้ดภาพที่ต่างจากที่ใช้ในพรีเซนเทชันต้นฉบับเมื่อจะทำให้ได้ไฟล์ที่มีขนาดเล็กลงหรือเหมาะสมกว่า ภาพที่มีความโปร่งใสจะถูกส่งออกเป็น PNG.

## **การเลือก URL สำหรับการปรับใช้**

ตัวอย่างใช้คำนำหน้า URL แบบสัมพันธ์: `assets/`. หากเปิด `presentation.html` จาก `html-output/presentation.html` เบราว์เซอร์จะโหลด `html-output/assets/resource-1.svg`.

เมื่อทรัพยากรที่เชื่อมโยงหนึ่งอ้างอิงถึงทรัพยากรที่เชื่อมโยงอื่น ตัวอย่างใช้พารามิเตอร์ `referrer` ใน `ExternalResourceController.getUrl` และคืนค่าเพียงชื่อไฟล์เท่านั้น ตัวอย่างเช่น หาก `resource-1.svg` และ `resource-4.jpg` อยู่ในโฟลเดอร์ `assets` ทั้งสอง ไฟล์ SVG ควรอ้างอิงถึง `resource-4.jpg` ไม่ใช่ `assets/resource-4.jpg`.

ใช้คำนำหน้า URL ที่แตกต่างเมื่อไฟล์ถูกปรับใช้ที่อื่น:

- ใช้ `assets/` เมื่อไดเรกทอรีแอสเซ็ตอยู่ข้างไฟล์ HTML.
- ใช้ `../assets/` เมื่อไดเรกทอรีแอสเซ็ตอยู่หนึ่งระดับเหนือไฟล์ HTML.
- ใช้ `https://cdn.example.com/presentations/job-123/assets/` เมื่อไฟล์ถูกอัปโหลดไปยัง CDN หรือเซิร์ฟเวอร์ไฟล์สเตติก.

URL ที่ `ExternalResourceController.getUrl` คืนค่าต้องตรงกับตำแหน่งที่ไฟล์ที่ `ExternalResourceController.saveExternal` เขียนลงไปสุดท้าย ในแอปพลิเคชันเซิร์ฟเวอร์ ควรใช้ไดเรกทอรีผลลัพธ์หรือคำนำหน้า storage แบบเฉพาะสำหรับแต่ละงานแปลงเพื่อหลีกเลี่ยงการเขียนทับไฟล์จากการส่งออกอื่น.

## **เมื่อควรฝังแทน**

HTML ที่ฝัง Base64 ยังมีประโยชน์เมื่อผลลัพธ์ต้องเป็นไฟล์เดียว เช่น แนบอีเมล, ตัวอย่างออฟไลน์, หรือเอกสารที่ต้องย้ายโดยไม่มีโฟลเดอร์แอสเซ็ตสนับสนุน ทรัพยากรที่เชื่อมโยงเหมาะสมกว่าเมื่อ HTML จะถูกเสิร์ฟโดยแอปพลิเคชันเว็บ, เก็บใน CMS, ผ่านกระบวนการบิลด์ที่ทำให้ประสิทธิภาพดียิ่งขึ้น, หรือให้เบราว์เซอร์แคชแยกจาก HTML.

## **คำถามที่พบบ่อย**

**ฉันสามารถแยกภาพออกเป็นไฟล์ภายนอกและให้ทรัพยากรอื่น ๆ ยังคงฝังอยู่ได้หรือไม่?**

ได้. ใน `ExternalResourceController.getObjectStoringLocation` ให้คืนค่าจาก `Link` ของ [LinkEmbedDecision](https://reference.aspose.com/slides/th/php-java/aspose.slides/linkembeddecision/) เฉพาะสำหรับประเภทเนื้อหาที่คุณต้องการบันทึกเป็นไฟล์แยก, และคืนค่า `Embed` สำหรับอย่างอื่นทั้งหมด.

**ทำไมส่วนขยายของภาพที่ส่งออกจึงแตกต่างจากพรีเซนเทชันต้นฉบับ?**

Aspose.Slides อาจทำการเข้ารหัสใหม่ของภาพเรสเตอร์ระหว่างการส่งออก HTML เพื่อปรับขนาดหรือความเข้ากันได้ของเบราว์เซอร์ ตัวอย่างเช่น ภาพจากไฟล์ต้นฉบับอาจถูกเขียนเป็น JPEG หรือ PNG ขึ้นอยู่กับผลลัพธ์ที่เรนเดอร์.

**URL แบบสัมพันธ์ทำงานได้หรือไม่หลังจากที่ฉันย้ายไฟล์ HTML?**

URL แบบสัมพันธ์ทำงานได้เฉพาะเมื่อโครงสร้างโฟลเดอร์สัมพันธ์เดียวกันถูกเก็บไว้ หาก HTML อ้างอิง `assets/resource-1.png` โฟลเดอร์ `assets` ต้องอยู่ข้างไฟล์ HTML หากคุณสร้างคำนำหน้า URL แบบอื่น โครงสร้างนั้นจะต้องถูกปรับตาม.

**แอปพลิเคชันเซิร์ฟเวอร์ควรใช้โฟลเดอร์ผลลัพธ์เดียวกันซ้ำหรือไม่?**

ไม่. ควรใช้ไดเรกทอรีผลลัพธ์หรือคำนำหน้า storage แบบเฉพาะสำหรับแต่ละงานแปลง การทำเช่นนี้จะหลีกเลี่ยงการชนชื่อไฟล์และป้องกันการเขียนทับทรัพยากรที่สร้างโดยการส่งออกอื่น.