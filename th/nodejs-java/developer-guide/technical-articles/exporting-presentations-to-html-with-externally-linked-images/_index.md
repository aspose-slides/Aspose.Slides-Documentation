---
title: ส่งออกงานนำเสนอเป็น HTML พร้อมรูปภาพที่เชื่อมโยงภายนอก
type: docs
weight: 100
url: /th/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
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
- รูปภาพที่เชื่อมโยง
- รูปภาพที่เชื่อมโยงภายนอก
- ทรัพยากรที่เชื่อมโยง
- ทรัพยากรภายนอก
- JavaScript
- Node.js
- Aspose.Slides
description: "ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น HTML ด้วย JavaScript โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java พร้อมบันทึกรูปภาพและทรัพยากรอื่น ๆ เป็นไฟล์เชื่อมโยงภายนอก."
---
## **ภาพรวม**

โดยค่าเริ่มต้น Aspose.Slides จะส่งออกงานนำเสนอเป็นไฟล์ HTML ที่บรรจุทั้งหมด ภาพและทรัพยากรอื่น ๆ จะถูกเขียนลงใน HTML โดยตรงทั่วไปเป็นข้อมูล Base64 สิ่งนี้สะดวกเมื่อคุณต้องการไฟล์พกพาเดียว แต่ไม่จำเป็นต้องเป็นรูปแบบที่ดีที่สุดสำหรับเว็บไซต์, CMS หรือไพล์ไลน์การแปลงฝั่งเซิร์ฟเวอร์

ใช้ทรัพยากรที่เชื่อมโยงภายนอกเมื่อต้องการ:

- ลดขนาดของเอกสาร HTML;
- แคชภาพ, ฟอนต์, เสียงหรือวิดีโอแยกกันในเบราว์เซอร์หรือ CDN;
- ตรวจสอบ, แทนที่, บีบอัด หรือประมวลผลต่อเนื่องทรัพยากรที่สร้างหลังการส่งออก;
- ทำให้โครงสร้างผลลัพธ์ใกล้เคียงกับที่แอปพลิเคชันเว็บคาดหวังมากขึ้น.

สำหรับกระบวนการแปลง HTML ทั่วไป, ดูที่ [แปลงงานนำเสนอ PowerPoint เป็น HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/). บทความนี้เน้นส่วนการเชื่อมโยงทรัพยากรของการส่งออก.

## **วิธีการทำงานของการส่งออกทรัพยากรที่เชื่อมโยง**

พร็อกซี Java สำหรับ [ILinkEmbedController](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) ให้แอปพลิเคชันของคุณกำหนด, ทีละทรัพยากร, ว่าเครื่องมือส่งออกจะฝังข้อมูลลงใน HTML หรือบันทึกเป็นไฟล์ภายนอกและเขียนลิงก์

คอนโทรลเลอร์มีสามเมธอด:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) กำหนดว่าทรัพยากรควรเชื่อมหรือฝัง;
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) คืนค่า URL ที่จะเขียนลงใน HTML ที่สร้างหรือทรัพยากรที่เชื่อมโยงอื่น;
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) เขียนข้อมูลของทรัพยากรที่เชื่อมโยงลงดิสก์หรือเป้าหมายการจัดเก็บอื่น

เส้นทางระบบไฟล์และ URL ของเบราว์เซอร์เป็นเรื่องที่แยกจากกัน ตัวอย่างเช่น ตัวอย่างด้านล่างเขียนไฟล์ทรัพยากรไปยัง `html-output/assets` บนดิสก์, ในขณะที่ HTML มี URL แบบสัมพันธ์เช่น `assets/resource-1.svg`. เบราว์เซอร์จะตีความ URL เหล่านี้สัมพันธ์กับไฟล์ที่มีลิงก์ ดังนั้นลิงก์จาก `presentation.html` ไปยังไฟล์ SVG จะใช้ `assets/resource-1.svg`, ในขณะที่ลิงก์จากไฟล์ SVG นั้นไปยังรูปภาพที่บันทึกในโฟลเดอร์ `assets` เดียวกันจะใช้ `resource-4.jpg`.

## **ส่งออก HTML พร้อมทรัพยากรที่เชื่อมโยง**

ตัวอย่าง JavaScript ด้านล่างสร้างไดเรกทอรีผลลัพธ์, บันทึกไฟล์ HTML ไว้ที่นั่น, และเก็บทรัพยากรที่เชื่อมโยงในโฟลเดอร์ย่อย `assets`. คอนโทรลเลอร์จะเชื่อมโยงรูปภาพ, ฟอนต์, เสียง, วิดีโอ และ CSS ทั่วไปเมื่อ Aspose.Slides มีหรือสามารถคาดเดานามสกุลไฟล์ที่ปลอดภัยได้. ทรัพยากรที่ไม่รู้จักจะยังคงถูกฝังไว้.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

หลังการส่งออก, โฟลเดอร์ผลลัพธ์จะมีโครงสร้างดังนี้:

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

ไฟล์ที่แน่นอนขึ้นอยู่กับเนื้อหาของงานนำเสนอและตัวเลือกการส่งออก ตัวอย่างเช่น รูปภาพราสเตอร์มักจะถูกส่งออกเป็น JPEG หรือ PNG. Aspose.Slides อาจเลือกตัวแปลงภาพที่แตกต่างจากที่ใช้ในงานนำเสนอเดิมเมื่อทำให้ไฟล์มีขนาดเล็กลงหรือเหมาะสมกว่า. รูปภาพที่มีความโปร่งใสจะถูกส่งออกเป็น PNG.

## **การเลือก URL สำหรับการปรับใช้**

ตัวอย่างใช้คำนำหน้า URL แบบสัมพันธ์: `assets/`. หากเปิด `presentation.html` จาก `html-output/presentation.html`, เบราว์เซอร์จะโหลด `html-output/assets/resource-1.svg`.

เมื่อทรัพยากรที่เชื่อมโยงหนึ่งอ้างอิงถึงอีกทรัพยากรที่เชื่อมโยง, ตัวอย่างใช้พารามิเตอร์ `referrer` ใน [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) และคืนค่าเฉพาะชื่อไฟล์. ตัวอย่างเช่น หาก `resource-1.svg` และ `resource-4.jpg` อยู่ในโฟลเดอร์ `assets` ทั้งสอง, ไฟล์ SVG ควรอ้างถึง `resource-4.jpg` ไม่ใช่ `assets/resource-4.jpg`.

ใช้คำนำหน้า URL ที่แตกต่างเมื่อไฟล์ถูกปรับใช้ในที่อื่น:

- ใช้ `assets/` เมื่อไดเรกทอรีทรัพยากรอยู่ถัดจากไฟล์ HTML;
- ใช้ `../assets/` เมื่อไดเรกทอรีทรัพยากรอยู่ระดับหนึ่งเหนือไฟล์ HTML;
- ใช้ `https://cdn.example.com/presentations/job-123/assets/` เมื่อไฟล์ถูกอัปโหลดไปยัง CDN หรือเซิร์ฟเวอร์ไฟล์สถิตย์.

URL ที่คืนโดย [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/) ต้องตรงกับตำแหน่งที่ปรับใช้จริงของไฟล์ที่เขียนโดย [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/). ในแอปพลิเคชันเซิร์ฟเวอร์, ใช้ไดเรกทอรีผลลัพธ์หรือคำนำหน้าการจัดเก็บวัตถุที่ไม่ซ้ำกันสำหรับแต่ละงานแปลงเพื่อหลีกเลี่ยงการเขียนทับไฟล์จากการส่งออกอื่น.

## **เมื่อควรฝังแทนที่จะเชื่อมโยง**

HTML ที่ฝัง Base64 ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องเป็นไฟล์เดียว, เช่น การแนบอีเมล, ตัวอย่างออฟไลน์, หรือเอกสารที่ต้องย้ายโดยไม่มีโฟลเดอร์ทรัพยากรสนับสนุน. ทรัพยากรที่เชื่อมโยงเหมาะสมกว่าเมื่อ HTML จะถูกให้บริการโดยแอปพลิเคชันเว็บ, เก็บใน CMS, ปรับโดยไพล์ไลน์การสร้าง, หรือแคชโดยเบราว์เซอร์แยกจาก HTML.

## **คำถามที่พบบ่อย**

**ฉันสามารถแยกภาพออกเป็นไฟล์ภายนอกและให้ทรัพยากรอื่น ๆ ยังคงฝังอยู่ได้หรือไม่?**

ได้. ใน [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinkembedcontroller/), คืนค่า `LinkEmbedDecision.Link` เฉพาะสำหรับประเภทเนื้อหาที่ต้องการบันทึกเป็นไฟล์แยก, และคืนค่า `LinkEmbedDecision.Embed` สำหรับส่วนอื่นทั้งหมด.

**ทำไมนามสกุลของภาพที่ส่งออกจึงแตกต่างจากงานนำเสนอต้นฉบับ?**

Aspose.Slides อาจทำการเข้ารหัสใหม่ของรูปภาพราสเตอร์ระหว่างการส่งออกเป็น HTML เพื่อปรับขนาดหรือความเข้ากันได้กับเบราว์เซอร์. ตัวอย่างเช่น ภาพจากไฟล์ต้นฉบับอาจถูกเขียนเป็น JPEG หรือ PNG ขึ้นอยู่กับผลลัพธ์ที่เรนเดอร์ได้.

**URL แบบสัมพันธ์ทำงานได้หรือไม่หลังจากที่ย้ายไฟล์ HTML?**

URL แบบสัมพันธ์ทำงานได้เฉพาะเมื่อโครงสร้างโฟลเดอร์สัมพันธ์เดียวกันยังคงอยู่. หาก HTML อ้างถึง `assets/resource-1.png`, โฟลเดอร์ `assets` ต้องอยู่ถัดจากไฟล์ HTML เว้นแต่คุณจะสร้างคำนำหน้า URL ที่แตกต่าง.

**แอปพลิเคชันเซิร์ฟเวอร์ควรใช้โฟลเดอร์ผลลัพธ์เดียวกันหรือไม่?**

ไม่. ใช้ไดเรกทอรีผลลัพธ์หรือคำนำหน้าการจัดเก็บที่ไม่ซ้ำกันสำหรับแต่ละงานแปลง. วิธีนี้จะหลีกเลี่ยงการชนของชื่อไฟล์และป้องกันการเขียนทับทรัพยากรที่สร้างโดยการส่งออกอื่น.