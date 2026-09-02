---
title: ปรับเพิ่มประสิทธิภาพการจัดการรูปภาพในการนำเสนอด้วย JavaScript
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/nodejs-java/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มภาพ
- เพิ่มบิทแมพ
- แทนที่รูปภาพ
- แทนที่ภาพ
- จากเว็บ
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- ทรัพยากร SVG ภายนอก
- ตัวแก้ไข SVG
- ภาพ SVG ที่เชื่อมโยง
- ฟอนท์ SVG
- เพิ่ม EMF
- เพิ่ม WMF
- เพิ่ม TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ทำให้การจัดการรูปภาพใน PowerPoint และ OpenDocument ง่ายขึ้นด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java โดยเพิ่มประสิทธิภาพการทำงานและอัตโนมัติขั้นตอนการทำงานของคุณ."
---
## **คำนำ**

รูปภาพทำให้การนำเสนอมีความน่าสนใจและดึงดูดสายตามากขึ้น. ใน Microsoft PowerPoint คุณสามารถแทรกรูปภาพลงในสไลด์จากไฟล์ อินเทอร์เน็ต หรือแหล่งอื่น ๆ ได้. ในทำนองเดียวกัน Aspose.Slides ให้คุณเพิ่มรูปภาพลงในสไลด์การนำเสนอได้หลายวิธี.

{{% alert  title="Tip" color="primary" %}} 

Aspose มีเครื่องแปลงฟรี —[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้คุณสร้างการนำเสนอจากรูปภาพได้อย่างรวดเร็ว. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

หากคุณต้องการเพิ่มรูปภาพเป็นกรอบรูป — โดยเฉพาะอย่างยิ่งหากคุณตั้งใจจะปรับขนาด เพิ่มเอฟเฟ็กต์ หรือใช้ตัวเลือกการจัดรูปแบบมาตรฐานอื่น ๆ — ดูที่ [Picture Frame](/slides/th/nodejs-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

คุณสามารถแปลงรูปภาพจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่งได้ ดูหน้าต่อไปนี้: แปลง [image to JPG](https://products.aspose.com/slides/th/nodejs-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/th/nodejs-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/th/nodejs-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/th/nodejs-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/th/nodejs-java/conversion/png-to-svg/), และ [SVG to PNG](https://products.aspose.com/slides/th/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides รองรับรูปภาพในรูปแบบที่นิยม เช่น JPEG, PNG, BMP, GIF และอื่น ๆ. 

## **เพิ่มรูปภาพที่จัดเก็บในเครื่องลงในสไลด์**

คุณสามารถเพิ่มรูปภาพหนึ่งภาพหรือหลายภาพที่จัดเก็บบนคอมพิวเตอร์ของคุณลงในสไลด์การนำเสนอได้ ตัวอย่างโค้ด JavaScript ต่อไปนี้แสดงวิธีเพิ่มรูปภาพลงในสไลด์:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **เพิ่มรูปภาพจากเว็บลงในสไลด์**

หากรูปภาพที่คุณต้องการเพิ่มลงในสไลด์ไม่ได้จัดเก็บบนคอมพิวเตอร์ของคุณ คุณสามารถเพิ่มโดยตรงจากเว็บได้. 

ตัวอย่างโค้ด JavaScript ด้านล่างแสดงวิธีเพิ่มรูปภาพจากเว็บลงในสไลด์:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **เพิ่มรูปภาพลงใน Slide Master**

Slide master เก็บและควบคุมข้อมูล เช่น ธีมและรูปแบบของสไลด์ที่ใช้มัน เมื่อคุณเพิ่มรูปภาพลงใน slide master รูปภาพนั้นจะแสดงบนทุกสไลด์ที่อิงจาก master นั้น. 

ตัวอย่างโค้ด JavaScript ด้านล่างแสดงวิธีเพิ่มรูปภาพลงใน slide master:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **เพิ่มรูปภาพเป็นพื้นหลังสไลด์**

คุณสามารถใช้รูปภาพเป็นพื้นหลังสำหรับหนึ่งหรือหลายสไลด์ รายละเอียดเพิ่มเติมดูที่ *[Setting Images as Backgrounds for Slides](/slides/th/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **เพิ่ม SVG ไปยังการนำเสนอ**

เนื้อหา SVG สามารถเพิ่มไปยังการนำเสนอได้โดยใช้คลาส [SvgImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/) วัตถุภาพ SVG ที่ได้สามารถเพิ่มลงในคอลเลกชันภาพของการนำเสนอและใช้สร้างกรอบรูปได้. 

ตัวอย่าง JavaScript ด้านล่างนำเข้า SVG แบบสตริงที่เป็นอิสระทั้งหมด ภาพ, สไตล์ และทรัพยากรอื่น ๆ ที่ SVG นี้ใช้จะถูกฝังโดยตรงในเนื้อหา SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **นำเข้าเนื้อหา SVG พร้อมทรัพยากรภายนอก**

ไฟล์ SVG ที่ส่งออกจากเครื่องมือออกแบบ, ตัวแก้ไขไดอะแกรม, ระบบไอคอน, และกระบวนการเว็บอาจอ้างอิงทรัพยากรที่เก็บอยู่นอกเอกสาร SVG ตัวอย่างเช่น SVG อาจมีลิงก์รูปภาพเช่น `images/photo.png`, ค่าของ CSS `url(...)` หรือ URL ของฟอนท์. 

เพื่อทำการนำเข้าเนื้อหา SVG ดังกล่าว ให้จัดหาตัวแก้ไขทรัพยากรภายนอกและส่งมันพร้อมกับ base URI ให้กับคอนสตรัคเตอร์ [SvgImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/) ที่เหมาะสม Base URI ระบุตำแหน่งของเอกสาร SVG และใช้เพื่อแก้ลิงก์แบบ relative. 

คลาส `SvgImage` มีการเข้าถึงข้อมูลเกี่ยวกับ SVG ที่นำเข้า: 

- `getSvgContent()` คืนค่า markup ของ SVG เป็นสตริง. 
- `getSvgData()` คืนค่าเนื้อหา SVG เป็นอาเรย์ไบต์. 
- `getBaseUri()` คืนค่า base URI ที่ใช้สำหรับลิงก์แบบ relative. 
- `getExternalResourceResolver()` คืนค่าตัวแก้ไขที่กำหนดให้กับภาพ SVG. 

### **สร้างตัวแก้ไขทรัพยากรภายนอก**

ตัวแก้ไขมีสองเมธอด: 

- `resolveUri` รวม base URI กับลิงก์ทรัพยากรแบบ relative และคืนค่า URI แบบ absolute คืน `null` หากไม่สามารถแก้ลิงก์ได้หรือไม่ได้รับอนุญาต. 
- `getEntity` คืนค่า Java stream ที่อ่านได้สำหรับ URI ของทรัพยากรแบบ absolute คืน `null` หากทรัพยากรหาย, ถูกบล็อก, หรือไม่พร้อมใช้งาน สามารถคืนสตรีมสำรองได้เมื่อเหมาะสม. 

ตัวช่วยด้านล่างสร้างตัวแก้ไขที่โหลดทรัพยากรที่ลิงก์ไว้เฉพาะจากไดเรกทอรีในเครื่องที่อนุญาต เท่านั้น ทรัพยากรเครือข่ายและพาธที่อยู่นอกไดเรกทอรีที่อนุญาตจะถูกบล็อก รูปภาพสำรองแบบเลือกจะถูกคืนสำหรับลิงก์รูปภาพที่ไม่สามารถแก้ได้. 

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // ตัวแก้ไขนี้ตั้งใจให้อนุญาตเฉพาะไฟล์ในเครื่องเท่านั้น.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // ใช้ภาพสำรองเฉพาะสำหรับทรัพยากรรูปภาพเท่านั้น การส่งคืนสตรีมรูปภาพ
                // สำหรับฟอนท์หรือสไตล์ชีตที่หายไปจะไม่ถูกต้อง.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **แก้ไขลิงก์ทรัพยากรระหว่างการนำเข้า SVG**

สมมติว่า `assets/diagram.svg` มีการอ้างอิงแบบ relative เช่น: 

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

ตัวอย่าง JavaScript ด้านล่างส่ง URI ของไฟล์ SVG เป็น base URI และจัดหาตัวแก้ไขแบบกำหนดเอง ตัวแก้ไขจะแปลงลิงก์รูปภาพแบบ relative ให้เป็น URI แบบ absolute แล้วคืนสตรีมที่มีทรัพยากรที่ลิงก์ไว้ในขณะที่ Aspose.Slides ประมวลผล SVG. 

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// The base URI represents the location of the SVG document.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage exposes the source content, binary data, base URI, and resolver.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

คลาส `SvgImage` ยังมี overloads ที่ยอมรับข้อมูล SVG เป็นอาเรย์ไบต์ รวมถึงเมธอด factory ที่อิงสตรีม พร้อมกับตัวแก้ไขทรัพยากรภายนอกและ base URI. 

{{% alert title="Important" color="warning" %}}

ตัวแก้ไขทรัพยากรทำให้ทรัพยากรภายนอกพร้อมใช้งานในขณะที่ Aspose.Slides ประมวลผลและเรนเดอร์ SVG แต่ไม่ได้แก้ไข markup ของ SVG ดั้งเดิมหรือฝังทรัพยากรที่แก้ไขโดยอัตโนมัติลงในนั้น. 

เมื่อภาพ SVG ถูกเพิ่มลงในคอลเลกชันภาพของการนำเสนอ ไฟล์ PPTX อาจมีทั้งการแทน SVG ดั้งเดิมและภาพ raster สำรอง ทรัพยากรที่ลิงก์ไว้สามารถปรากฏในภาพสำรองที่สร้างขึ้นในขณะที่ลิงก์แบบ relative เช่น `images/photo.png` จะคงเดิมใน SVG ที่เก็บไว้ แอปพลิเคชันที่เรนเดอร์ SVG แบบเนทีฟอาจละเว้นเนื้อหาที่ลิงก์เมื่อทรัพยากรภายนอกต้นฉบับไม่มีให้ใช้. 

{{% /alert %}}

### **สร้างรูปภาพ SVG พกพา**

เพื่อสร้างรูปภาพ SVG ที่ไม่พึ่งพาไฟล์ภายนอก ทำให้ SVG เป็นอิสระก่อนสร้าง `SvgImage` ตัวอย่างเช่น แทนที่ URL ของรูปภาพที่ลิงก์ไว้ด้วย URI แบบ `data:` ที่บรรจุข้อมูลรูปภาพ: 

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

หลังจากฝังทรัพยากรที่จำเป็นทั้งหมดลงในเนื้อหา SVG แล้ว สร้าง `SvgImage` เพิ่มลงในคอลเลกชันภาพของการนำเสนอ และแทรกลงในกรอบรูปตามตัวอย่างก่อนหน้า. 

### **จัดการทรัพยากรที่หายหรือถูกบล็อก**

คืนค่า `null` จาก `resolveUri` เมื่อ URI ของทรัพยากรไม่ถูกต้อง, ถูกห้าม, หรือไม่สามารถแก้ได้. คืนค่า `null` จาก `getEntity` เมื่อไม่สามารถอ่านทรัพยากรได้. Aspose.Slides จะดำเนินการต่อกับ SVG โดยไม่มีทรัพยากรนั้นเมื่อเป็นไปได้. 

สตรีมสำรองสามารถคืนได้สำหรับทรัพยากรที่หาย แต่เนื้อหาต้องสอดคล้องกับประเภททรัพยากรที่ร้องขอ ตัวอย่างเช่น คืนสตรีมรูปภาพเท่าที่เป็นรูปภาพที่หายไป ไม่ได้สำหรับฟอนท์หรือสไตล์ชีต. 

{{% alert title="Security" color="warning" %}}

ห้ามแก้ไขพาธไฟล์ใด ๆ หรือ URL เครือข่ายที่ไม่ได้จำกัดจากไฟล์ SVG ที่ไม่เชื่อถือได้ จำกัดสคีม, ไดเรกทอรีและโฮสต์ที่อนุญาต สำหรับทรัพยากรเครือข่าย ควรกำหนดเวลาเชื่อมต่อ, ขีดจำกัดขนาดการตอบกลับ, และการตรวจสอบความถูกต้องของเนื้อหา. 

{{% /alert %}}

## **แปลง SVG เป็นชุดของรูปทรง**

Aspose.Slides สามารถแปลง SVG ให้เป็นชุดของรูปทรงได้ คล้ายกับฟังก์ชันที่สอดคล้องใน PowerPoint: 

![PowerPoint Popup Menu](img_01_01.png)

ฟังก์ชันนี้จัดให้โดย overload ของเมธอด [addGroupShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) ของคลาส [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection) ที่รับอ็อบเจ็กต์ SVG image เป็นอาร์กิวเมนท์แรก. 

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// ชื่อไฟล์ SVG ต้นทาง.
const svgFileName = "sample.svg";

// ชื่อไฟล์การนำเสนอผลลัพธ์.
const outPptxPath = "presentation.pptx";

// สร้างการนำเสนอใหม่.
const presentation = new aspose.slides.Presentation();
try {
    // อ่านเนื้อหาไฟล์ SVG.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // สร้างอ็อบเจ็กต์ SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // รับขนาดสไลด์.
    const slideSize = presentation.getSlideSize().getSize();

    // แปลงภาพ SVG เป็นกลุ่มรูปทรงและปรับขนาดให้พอดีกับขนาดสไลด์.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // บันทึกการนำเสนอในรูปแบบ PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มรูปภาพเป็น EMF ลงในสไลด์**

Aspose.Slides for Node.js via Java อนุญาตให้คุณสร้างภาพ EMF จากแผ่นงาน Excel ด้วย Aspose.Cells แล้วเพิ่มลงในสไลด์การนำเสนอ. 

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// บันทึกเวิร์กบุ๊กไปยังสตรีม.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // เพิ่มไฟล์ตามเดิมเพื่อให้รูปภาพคงเป็นเวกเตอร์ EMF แทนการแรสเตอร์ไลซ์.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **แทนที่รูปภาพใน Image Collection**

Aspose.Slides ให้คุณแทนที่รูปภาพที่เก็บในคอลเลกชันภาพของการนำเสนอ รวมถึงรูปภาพที่ใช้โดยรูปร่างของสไลด์ ส่วนนี้อธิบายหลายวิธีในการอัปเดตรูปภาพในคอลเลกชัน คุณสามารถแทนที่รูปภาพโดยใช้ข้อมูลไบต์ดิบ, อินสแตนซ์ [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/), หรือรูปภาพอื่นที่มีอยู่แล้วในคอลเลกชัน. 

ทำตามขั้นตอนต่อไปนี้: 

1. โหลดไฟล์การนำเสนอที่มีรูปภาพโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) 
1. โหลดรูปภาพใหม่จากไฟล์เป็นอาเรย์ไบต์ 
1. แทนที่รูปภาพเป้าหมายด้วยรูปภาพใหม่โดยใช้อาเรย์ไบต์ 
1. ในวิธีที่สอง โหลดรูปภาพเป็นอ็อบเจ็กต์ [IImage] แล้วแทนที่รูปภาพเป้าหมายด้วยอ็อบเจ็กต์นั้น 
1. ในวิธีที่สาม แทนที่รูปภาพเป้าหมายด้วยรูปภาพที่มีอยู่แล้วใน Image Collection ของการนำเสนอ 
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // วิธีแรก.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // วิธีที่สอง.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // วิธีที่สาม.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // บันทึกการนำเสนอลงไฟล์.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

ด้วยตัวแปลงฟรี [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ของ Aspose คุณสามารถทำข้อความเคลื่อนไหวและสร้าง GIF จากข้อความได้อย่างง่ายดาย. 

{{% /alert %}}

## **FAQ**

**ความละเอียดของรูปภาพต้นฉบับยังคงอยู่ครบถ้วนหลังจากแทรกหรือไม่?**

ใช่ พิกเซลต้นฉบับจะถูกเก็บไว้ แต่ลักษณะที่แสดงสุดท้ายขึ้นอยู่กับการสเกล [picture](/slides/th/nodejs-java/picture-frame/) บนสไลด์และการบีบอัดเมื่อบันทึก. 

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันบนหลายสิบสไลด์พร้อมกันคืออะไร?**

วางโลโก้บน master slide หรือ layout แล้วแทนที่ใน Image Collection ของการนำเสนอ — การอัปเดตจะกระจายไปยังทุกองค์ประกอบที่ใช้ทรัพยากรนั้น. 

**สามารถแปลง SVG ที่แทรกแล้วเป็นรูปทรงที่แก้ไขได้หรือไม่?**

ได้ คุณสามารถแปลง SVG ให้เป็นกลุ่มของรูปทรง หลังจากนั้นส่วนต่าง ๆ จะสามารถแก้ไขได้ด้วยคุณสมบัติของรูปทรงมาตรฐาน. 

**ฉันจะตั้งรูปภาพเป็นพื้นหลังสำหรับหลายสไลด์พร้อมกันอย่างไร?**

[Assign the image as the background](/slides/th/nodejs-java/presentation-background/) บน master slide หรือ layout ที่เกี่ยวข้อง — สไลด์ใดที่ใช้งาน master/layout นี้จะสืบทอดพื้นหลัง. 

**จะป้องกันไม่ให้การนำเสนอใหญ่เกินไปเนื่องจากมีรูปภาพจำนวนมากได้อย่างไร?**

ใช้ทรัพยากรรูปภาพเดียวซ้ำแทนการทำสำเนา เลือกระดับความละเอียดที่เหมาะสม ใช้การบีบอัดเมื่อต้องบันทึก และเก็บกราฟิกที่ซ้ำกันไว้บน master ตามความเหมาะสม.