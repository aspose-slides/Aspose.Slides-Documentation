---
title: แปลงสไลด์ PowerPoint เป็น PNG ใน JavaScript
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/nodejs-java/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- การนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- บันทึก PPT เป็น PNG
- บันทึก PPTX เป็น PNG
- ส่งออก PPT เป็น PNG
- ส่งออก PPTX เป็น PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงการนำเสนอ PowerPoint เป็นภาพ PNG คุณภาพสูงใน JavaScript อย่างรวดเร็วด้วย Aspose.Slides สำหรับ Node.js เพื่อให้ได้ผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงสไลด์การนำเสนอเป็นภาพ PNG ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java คุณสามารถโหลดการนำเสนอในรูปแบบต่าง ๆ เช่น PPT, PPTX และ ODP เรนเดอร์แต่ละสไลด์และบันทึกเป็นภาพ PNG แยกกันได้

ตัวอย่างด้านล่างแสดงการเรนเดอร์ด้วยสเกลเริ่มต้น การเพิ่มสเกล การระบุขนาดผลลัพธ์เป็นพิกเซล และการเลือกสไตล์การเรนเดอร์แบบไล่สี

## **แปลง PowerPoint เป็น PNG**

โหลดการนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) และเข้าถึงสไลด์ผ่านคอลเลกชัน [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) ตัวอย่างทำการเรนเดอร์ทุกสไลด์ด้วย [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) โดยไม่มีพารามิเตอร์เพื่อสร้างภาพย่อ จากนั้นเรียก [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) ด้วย [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) เพื่อบันทึกแต่ละสไลด์ที่เรนเดอร์เป็นภาพ PNG

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
เมธอด [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) ที่ไม่มีพารามิเตอร์จะทำการเรนเดอร์ที่สเกล 0.2 ตัวอย่างเช่น สไลด์ที่มีขนาด 720 × 540 พอยต์จะสร้างภาพย่อ 144 × 108 พิกเซล เพื่อควบคุมขนาดผลลัพธ์ ให้ใช้เมธอดที่รับอัตราสเกลหรือขนาดภาพที่ระบุไว้ด้านล่าง
{{% /alert %}}

## **แปลง PowerPoint เป็น PNG ด้วยขนาดที่กำหนดเอง**

ส่งค่าปัจจัยสเกลแนวนอนและแนวตั้งไปยัง [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) เพื่อควบคุมขนาดที่เรนเดอร์ ในตัวอย่างนี้ทั้งสองค่ามีค่าเป็น 2 ดังนั้นสไลด์ที่มีขนาด 720 × 540 พอยต์จะสร้างภาพ 1440 × 1080 พิกเซล ปัจจัยสเกลที่เท่ากันจะรักษาอัตราส่วนของสไลด์ แต่ละภาพจะถูกบันทึกในรูปแบบ PNG ด้วย [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **แปลง PowerPoint เป็น PNG ด้วยขนาดกำหนดเอง**

เพื่อระบุขนาดผลลัพธ์เป็นพิกเซล ให้ส่งค่าขนาดไปยัง [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) แทนการใช้ปัจจัยสเกล ตัวอย่างนี้ทำการเรนเดอร์ทุกสไลด์ที่ 960 × 720 พิกเซลและบันทึกผลลัพธ์ด้วย [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) เลือกขนาดที่สอดคล้องกับอัตราส่วนของสไลด์เพื่อหลีกเลี่ยงการยืดภาพ

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **เลือกสไตล์การเรนเดอร์แบบไล่สี**

สมมติว่าสไลด์มีการเติมสีไล่สี แต่การแปลงเป็น PNG ทำให้การเปลี่ยนสีดูอ่อนกว่า หรือแตกต่างจากที่เห็นใน PowerPoint คุณสามารถใช้เมธอด [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) ที่สืบทอดจาก [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) เพื่อเลือกวิธีการเรนเดอร์ไล่สี

ดาวน์โหลด [gradient-styles.pptx](gradient-styles.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีไล่สีเชิงเส้นสองแบบ: สีไซอานไปสีส้มที่ด้านบนและสีฟ้าไปสีเหลืองที่ด้านล่าง แต่ละไล่สีมีจุดหยุดสองจุดที่ 0% และ 100%

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและทำการเรนเดอร์สไลด์แรกเดียวกันในทั้งสองโหมดด้วย [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

| ค่าเริ่มต้น | PowerPointUI |
| --- | --- |
| ![ไล่สีไซอานถึงสีส้มและสีฟ้าถึงสีเหลืองที่เรนเดอร์ด้วยค่าเริ่มต้น](gradient-Default.png) | ![ไล่สีเดียวกันที่เรนเดอร์ด้วย PowerPointUI](gradient-PowerPointUI.png) |

ในตัวอย่างนี้ `Default` ให้สีกลางที่อ่อนกว่า ในขณะที่ `PowerPointUI` ให้สีกลางที่เข้มกว่า ความแตกต่างขึ้นอยู่กับสีและจุดหยุดในไล่สี

เลือก `Default` เมื่อผลลัพธ์มาตรฐานของ Aspose.Slides พอใจคุณ ใช้ `PowerPointUI` เมื่อเป้าหมายของคุณคือการตรงกับลักษณะใน PowerPoint เปรียบเทียบผลลัพธ์ทั้งสองกับสิ่งที่คุณต้องการ; ไม่มีโหมดใดที่ดีกว่าโดยทั่วไป

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกรูปทรงเฉพาะ เช่น แผนภูมิหรือรูปภาพ แทนการส่งออกสไลด์ทั้งหมดได้อย่างไร?**

Aspose.Slides รองรับการ [สร้างภาพย่อสำหรับรูปทรงแต่ละอัน](/slides/th/nodejs-java/create-shape-thumbnails/) ทำให้คุณสามารถเรนเดอร์รูปทรงเป็นภาพ PNG

**การแปลงแบบขนานได้รับการสนับสนุนบนเซิร์ฟเวอร์หรือไม่?**

ใช่ ใช้ instance ของ presentation แยกกันสำหรับแต่ละเธรดหรือโพรเซส; [ห้ามแชร์ instance เดียวกันข้ามเธรด](/slides/th/nodejs-java/multithreading/).

**ข้อจำกัดของโหมดประเมินผลเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**

โหมดประเมินผลจะใส่น้ำแม่ยต่อภาพผลลัพธ์และใช้ [ข้อจำกัดอื่น](/slides/th/nodejs-java/licensing/) จนกว่าจะมีการใส่ใบอนุญาต