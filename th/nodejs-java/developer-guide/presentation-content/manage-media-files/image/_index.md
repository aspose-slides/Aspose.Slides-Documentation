---
title: เพิ่มประสิทธิภาพการจัดการรูปภาพในงานนำเสนอโดยใช้ JavaScript
linktitle: จัดการรูปภาพ
type: docs
weight: 10
url: /th/nodejs-java/image/
keywords:
- เพิ่มรูปภาพ
- เพิ่มภาพ
- แทนที่รูปภาพ
- คอลเลกชันรูปภาพ
- กรอบภาพ
- รูปภาพเชื่อมโยง
- พื้นหลัง
- เพิ่ม PNG
- เพิ่ม JPG
- เพิ่ม SVG
- SVG เป็นรูปทรง
- ทรัพยากร SVG ภายนอก
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, ใช้ซ้ำ, เชื่อมโยง, แทนที่ และจัดการรูปภาพเรสเตอร์และ SVG ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **บทนำ**

Aspose.Slides for Node.js via Java มีวิธีการทำงานกับรูปภาพหลายวิธี และแต่ละวิธีมีวัตถุประสงค์ที่แตกต่างกัน คุณสามารถเก็บรูปภาพไว้ในงานนำเสนอ แสดงในกรอบภาพ ใช้เป็นพื้นหลังสไลด์ เชื่อมโยงไปยังรูปภายนอก แทนที่ทรัพยากรรูปที่ใช้ร่วมกัน หรือแปลงเนื้อหา SVG ให้เป็นรูปทรงที่แก้ไขได้

บทความนี้มุ่งเน้นไปที่ทรัพยากรรูปภาพและวิธีการใช้งานทั่วทั้งงานนำเสนอ สำหรับการครอบตัด ความโปร่งใส เอฟเฟกต์ การยืด และการจัดรูปแบบอื่น ๆ ที่ใช้กับกรอบภาพแต่ละรายการ โปรดดูที่ [กรอบภาพ](/slides/th/nodejs-java/picture-frame/) 

## **ทำความเข้าใจโมเดลรูปภาพ**

แนวคิด API ต่อไปนี้เกี่ยวข้องกันอย่างใกล้ชิด แต่ไม่ใช่ทดแทนกันได้:

- [คอลเลกชันรูปภาพของงานนำเสนอ](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagecollection/) เก็บทรัพยากรรูปภาพที่ใช้โดยงานนำเสนอ ใช้ [ImageCollection.addImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagecollection/) เพื่อเพิ่มข้อมูลรูปภาพและรับทรัพยากร [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) 
- [กรอบภาพ](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) คือรูปทรงที่แสดงรูปภาพบนสไลด์ เลย์เอาต์ หรือมาสเตอร์ ใช้ [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/) เพื่อนำทรัพยากรรูปภาพไปวางบนสไลด์ 
- พื้นหลังสไลด์ใช้รูปภาพเป็นส่วนหนึ่งของการเติมสไลด์ ไม่ได้เป็นรูปทรง จึงทำงานแตกต่างจากกรอบภาพ 
- [PPImage.replaceImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) แทนที่ทรัพยากรรูปภาพ หากหลายองค์ประกอบในงานนำใช้ทรัพยากรนั้นทั้งหมดจะใช้รูปที่แทนที่ 
- การแปลง SVG เป็นรูปทรงจะสร้างรูปทรงสไลด์ที่แก้ไขได้ หลังจากแปลง เนื้อหาจะไม่ถูกจัดการเป็นทรัพยากรรูปภาพเดียวอีกต่อไป 

กระบวนการทำงานทั่วไปจึงเป็น: เพิ่มข้อมูลรูปภาพไปยังคอลเลกชันรูปภาพ รับ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) แล้วใช้ทรัพยากรนั้นในกรอบภาพหรือการเติมหลาย ๆ ตัว

## **เพิ่มรูปภาพที่ฝังอยู่ในงานนำเสนอ**

เพื่อแทรกรูปภาพในเครื่อง โหลดไฟล์ เพิ่มเข้าไปในคอลเลกชันรูปภาพ และสร้างกรอบภาพที่ใช้ทรัพยากร [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) ที่คืนกลับมา

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

รูปภาพที่เพิ่มด้วยวิธีนี้จะฝังอยู่ในงานนำเสนอ ดังนั้นไฟล์ที่ได้จะไม่ขึ้นกับไฟล์รูปภาพต้นฉบับที่ยังคงมีอยู่หรือไม่

### **เพิ่มรูปภาพจากเว็บ**

เมื่อรูปภาพสามารถเข้าถึงได้ผ่าน HTTP หรือ HTTPS ให้ดาวน์โหลดไบต์ของรูปภาพ เพิ่มเข้าไปในคอลเลกชันรูปภาพของงานนำเสนอ และใช้ทรัพยากรรูปภาพที่คืนกลับมาในรูปแบบเดียวกับรูปภาพในเครื่อง

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

ในแอปพลิเคชันที่ทำงานนาน ๆ ควรใช้ HTTP client หรือกลยุทธ์การจัดการการเชื่อมต่อที่เหมาะสมกับแอปพลิเคชัน แทนการสร้างโครงสร้างเครือข่ายที่ไม่จำเป็นบ่อย ๆ นอกจากนี้ควรตรวจสอบ URL ระยะไกล ขนาดการตอบสนอง และประเภทของเนื้อหาเมื่อแหล่งที่มาไม่น่าเชื่อถือ

## **นำรูปภาพกลับมาใช้ใหม่ในหลายสไลด์**

หากต้องการใช้รูปเดียวกันหลายครั้ง ให้เพิ่มรูปเข้าไปในงานนำเสนอครั้งเดียวและนำ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) ที่ได้รับกลับมาไปใช้เมื่อสร้างกรอบภาพเพิ่มเติม วิธีนี้จะหลีกเลี่ยงการโหลดข้อมูลต้นฉบับเดียวกันหลายครั้งและทำให้ความสัมพันธ์ระหว่างทรัพยากรรูปภาพที่ใช้ร่วมกับการใช้งานต่าง ๆ ชัดเจน

สำหรับกราฟิกที่ควรปรากฏอัตโนมัติในหลายสไลด์ เช่น โลโก้บริษัท ควรพิจารณาวางกรอบภาพบน [มาสเตอร์สไลด์](/slides/th/nodejs-java/slide-master/) หรือเลย์เอาต์ แทนการเพิ่มรูปทรงเท่าเดิมในแต่ละสไลด์

## **ใช้รูปภาพเป็นพื้นหลังสไลด์**

รูปภาพพื้นหลังจะถูกกำหนดให้กับการเติมสไลด์ ไม่ได้ถูกเพิ่มเป็นรูปทรงกรอบภาพ วิธีนี้มีประโยชน์เมื่อต้องการให้รูปภาพครอบคลุมพื้นหลังสไลด์และไม่ได้รับการจัดการเป็นวัตถุสไลด์ทั่วไป

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับตัวเลือกพื้นหลังเพิ่มเติม รวมถึงพื้นหลังมาสเตอร์และเลย์เอาต์ ให้ดูที่ [พื้นหลังงานนำเสนอ](/slides/th/nodejs-java/presentation-background/)

## **รูปภาพฝังและรูปภาพเชื่อมโยง**

รูปภาพฝังและรูปภาพเชื่อมโยงมีการแลกเปลี่ยนความพกพาและขนาดไฟล์ที่แตกต่างกัน:

- **รูปภาพฝัง:** ข้อมูลรูปภาพถูกเก็บไว้ภายในงานนำเสนอ งานนำเสนอจะเป็นไฟล์อัตโนมัติหลายส่วน แต่ขนาดไฟล์จะรวมข้อมูลรูปภาพด้วย 
- **รูปภาพเชื่อมโยง:** งานนำเสนอเก็บเส้นทางหรือ URL ไปยังรูปภาพภายนอก วิธีนี้สามารถลดขนาดงานนำเสนอได้ แต่ทรัพยากรภายนอกต้องยังคงเข้าถึงได้เมื่อเปิดหรือเรนเดอร์งานนำเสนอ

รูปภาพเชื่อมโยงสามารถสร้างได้โดยกำหนดเส้นทางหรือ URL ภายนอกผ่าน [Picture.setLinkPathLong](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/) แทนการฝังข้อมูลรูปภาพ

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ใช้รูปภาพเชื่อมโยงเฉพาะเมื่อสภาพแวดล้อมการปรับใช้สามารถเข้าถึงทรัพยากรภายนอกได้อย่างมั่นคง สำหรับงานนำเสนอที่ต้องทำงานออฟไลน์หรือย้ายระหว่างระบบ รูปภาพฝังมักจะปลอดภัยกว่า

## **ทำงานกับรูปภาพ SVG**

SVG เป็นรูปแบบเวกเตอร์ จึงเหมาะกับไอคอน แผนภูมิ และกราฟิกอื่น ๆ ที่ควรขยายขนาดโดยไม่สูญเสียรายละเอียดเหมือนภาพเรสเตอร์ Aspose.Slides รองรับ SVG ทั้งเป็นทรัพยากรรูปภาพและเป็นแหล่งสำหรับรูปทรงสไลด์ที่แก้ไขได้

### **เพิ่ม SVG เป็นรูปภาพ**

สร้าง [SvgImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/) เพิ่มเข้าไปในคอลเลกชันรูปภาพ และวางทรัพยากรรูปภาพที่ได้ในกรอบภาพ

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ไฟล์ SVG ที่มีทรัพยากรภายนอก**

SVG สามารถอ้างอิงรูปภาพ สไตล์ชีต หรือฟอนต์ภายนอก สำหรับกรณีเหล่านี้ [SvgImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgimage/) มีคอนสตรักเตอร์ที่รับ [ExternalResourceResolver](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/externalresourceresolver/) และ base URI ตัว resolver สามารถแมป URI แบบสัมพันธ์ให้เป็น URI แบบเต็มที่อนุญาตและคืนสตรีมสำหรับทรัพยากรที่ร้องขอ

Resolver ทำให้ทรัพยากรภายนอกพร้อมใช้งานขณะ Aspose.Slides ประมวลผล SVG แต่ไม่ทำการเขียนใหม่ SVG ให้เป็นเอกสารอิสระ หากต้องการให้ SVG พกพาได้ ควรฝังทรัพยากรที่จำเป็นลงใน SVG เอง ตัวอย่างเช่นใช้ URI `data:` สำหรับรูปภาพเชื่อมโยง

เมื่อไฟล์ SVG มาจากแหล่งที่ไม่น่าเชื่อถือ ควรจำกัดสกีม, ตำแหน่งไฟล์, และโฮสต์ที่ resolver สามารถเข้าถึง ตัว resolver เครือข่ายควรตั้งค่า timeout, ขีดจำกัดขนาดการตอบสนอง, และการตรวจสอบเนื้อหา

### **แปลง SVG เป็นรูปทรงที่แก้ไขได้**

Aspose.Slides สามารถแปลง SVG ให้เป็นกลุ่มรูปทรงสไลด์ที่แก้ไขได้ คล้ายกับคำสั่งใน PowerPoint

![PowerPoint Popup Menu](img_01_01.png)

ใช้ overload ของ [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/) ที่รับภาพ SVG เพื่อทำการแปลง

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ใช้การแปลง SVG‑to‑shapes เมื่อองค์ประกอบเวกเตอร์แต่ละรายการต้องการแก้ไขเป็นรูปทรง PowerPoint หาก SVG เพียงต้องการแสดงผล การเก็บเป็นรูปภาพยังง่ายกว่าและหลีกเลี่ยงการสร้างรูปทรงแยกหลายรูป

## **แทนที่ทรัพยากรรูปภาพที่มีอยู่**

ใช้ [PPImage.replaceImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) เมื่อต้องการแทนที่ทรัพยากรรูปภาพที่มีอยู่ วิธีนี้เป็นประโยชน์อย่างยิ่งสำหรับกราฟิกที่ใช้ร่วมกัน เช่น โลโก้

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากหลายกรอบภาพ, พื้นหลัง, มาสเตอร์ หรือเลย์เอต์ใช้ทรัพยากรรูปเดียวกัน การแทนที่ทรัพยากรนั้นจะอัปเดตการใช้งานทั้งหมด หากต้องการเปลี่ยนกรอบภาพเพียงหนึ่งกรอบ ให้กำหนดรูปภาพอื่นให้กับกรอบนั้นแทนการแทนที่ทรัพยากรที่ใช้ร่วมกัน

[PPImage.replaceImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) ยังมี overload ที่รับอาเรย์ไบต์หรือ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) อื่น

## **คำแนะนำการจัดการรูปภาพอย่าง Practical**

### **ควบคุมขนาดงานนำเสนอ**

ภาพเรสเตอร์ขนาดใหญ่สามารถทำให้ไฟล์งานนำเสนอใหญ่เกินความจำเป็น ใช้รูปภาพต้นฉบับที่มีขนาดเหมาะสมกับการแสดงผลที่ต้องการ, ใช้ทรัพยากรรูปภาพที่ใช้ร่วมกันเมื่อเป็นไปได้, และหลีกเลี่ยงการฝังสำเนาแบบเต็มความละเอียดของกราฟิกเดียวกันหลายครั้ง

สำหรับรูปภาพเรสเตอร์ที่ได้วางไว้ในกรอบภาพแล้ว, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/) สามารถลดข้อมูลรูปภาพตามความละเอียดและการตั้งค่าการครอบตัดที่เลือก วิธีนี้เป็นการประมวลผลกรอบภาพ ไม่ใช่การจัดการคอลเลกชันรูปภาพ ดังนั้นดูที่ [กรอบภาพ](/slides/th/nodejs-java/picture-frame/) สำหรับการจัดรูปแบบที่เกี่ยวข้อง

### **เลือกใช้ระหว่างเนื้อหาฝังหรือเชื่อมโยง**

การฝังทำให้งานนำเสนอพกพาได้ง่ายเพราะข้อมูลรูปภาพทั้งหมดอยู่ในไฟล์เดียว การเชื่อมโยงอาจลดขนาดไฟล์ได้ แต่สร้างการพึ่งพาภายนอก ใช้ลิงก์เฉพาะเมื่อการพึ่งพานั้นยอมรับได้และเสถียร

### **ใช้แบรนด์ที่แชร์ซ้ำ**

สำหรับโลโก้, วอเตอร์มาร์ค, หรือกราฟิกตกแต่งที่ใช้ซ้ำ, ใช้ทรัพยากรรูปภาพหนึ่งเดียวและนำกลับมาใช้ใหม่ หากกราฟิกเป็นส่วนของการออกแบบงานนำเสนอ มากกว่ามีเนื้อหาในสไลด์ ให้วางบนมาสเตอร์หรือเลย์เอาต์เพื่อให้สไลด์ที่สืบทอดรับอัตโนมัติ

### **ทำให้ทรัพยากร SVG พกพาได้**

SVG ที่เป็นไฟล์อิสระง่ายต่อการย้ายและเรนเดอร์อย่างสม่ำเสมอกว่า SVG ที่ขึ้นกับไฟล์หรือทรัพยากรเครือข่ายภายนอก เมื่อทำได้ให้ฝังทรัพยากรที่จำเป็นก่อนนำเข้า SVG แปลง SVG เป็นรูปทรงเฉพาะเมื่อต้องการแก้ไของค์ประกอบเวกเตอร์แต่ละรายการ

### **ใช้ Modern Cross-Platform Image API**

สำหรับโค้ด Node.js via Java ใหม่ ให้ใช้ API Aspose.Slides [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) และ [Images](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/images/) แทน API สาธารณะรุ่นเก่าที่อิงกับ `java.awt.image.BufferedImage` ดูที่ [Modern API](/slides/th/nodejs-java/modern-api/) สำหรับแนวทางการย้าย

WMF และ EMF ต้องพิจารณาพิเศษ เมื่อส่งผ่าน [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) [ImageCollection.addImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagecollection/) จะเปลี่ยนเมตาฟาไล์เป็น PNG เรสเตอร์ก่อนแทรก หากต้องการรักษาข้อมูลเมตาฟาไล์ไว้ ควรใช้ overload ของ [ImageCollection.addImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagecollection/) ที่รับสตรีม การสร้างเนื้อหา EMF จากสเปรดชีตหรือผลิตภัณฑ์อื่นเป็นกระบวนการรวมที่แยกจากกันและอยู่นอกขอบเขตของบทความนี้

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างคอลเลกชันรูปภาพและกรอบภาพคืออะไร?**

คอลเลกชันรูปภาพเก็บทรัพยากรรูปภาพที่ใช้ซ้ำได้ กรอบภาพเป็นรูปทรงสไลด์ที่แสดงหนึ่งในทรัพยากรเหล่านั้นและให้การจัดรูปแบบเฉพาะภาพเช่นการครอบตัดและเอฟเฟกต์

**วิธีที่ดีที่สุดในการแทนที่โลโก้เดียวกันในทุกที่คืออะไร?**

หากโลโก้ถูกแชร์เป็นทรัพยากรรูปภาพเดียว ให้ใช้ [PPImage.replaceImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) เพื่อแทนที่ทรัพยากรนั้น สำหรับการจัดแบรนด์ทั่วงานนำเสนอ การวางโลโก้บนมาสเตอร์หรือเลย์เอาต์ก็ช่วยลดเนื้อหาที่ซ้ำซ้อนได้เช่นกัน

**ทำไมรูปภาพเชื่อมโยงจึงหายไปบนคอมพิวเตอร์เครื่องอื่น?**

รูปภาพเชื่อมโยงพึ่งพาไฟล์หรือ URL ภายนอก หากทรัพยากรนั้นไม่สามารถเข้าถึงจากคอมพิวเตอร์เครื่องอื่น รูปภาพเชื่อมโยงจะไม่แสดงผล ฝังรูปภาพเมื่อจำเป็นต้องทำให้งานนำเสนอเป็นอิสระ

**สามารถแก้ไข SVG ที่แทรกเป็นรูปทรง PowerPoint ได้หรือไม่?**

ได้ การแปลง SVG ด้วย [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/) จะให้กลุ่มที่ประกอบด้วยรูปทรงสไลด์ที่แก้ไขได้แทนการเป็นรูปภาพ SVG เดียว

**จะทำอย่างไรให้การนำเสนอที่มีรูปภาพหลายรูปยังคงมีขนาดเล็ก?**

ใช้ทรัพยากรรูปภาพที่แชร์ซ้ำ, หลีกเลี่ยงแหล่งเรสเตอร์ขนาดใหญ่เกินความจำเป็น, บีบอัดรูปภาพเรสเตอร์ที่เหมาะสมเมื่อจำเป็น, เก็บแบรนด์ซ้ำบนมาสเตอร์หรือเลย์เอต์, และใช้รูปภาพเชื่อมโยงเฉพาะเมื่อการพึ่งพาภายนอกยอมรับได้