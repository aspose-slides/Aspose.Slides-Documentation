---
title: สร้างตัวดูพรีเซนเทชันใน JavaScript
linktitle: ตัวดูพรีเซนเทชัน
type: docs
weight: 50
url: /th/nodejs-java/presentation-viewer/
keywords: 
- ดูพรีเซนเทชัน
- ตัวดูพรีเซนเทชัน
- สร้างตัวดูพรีเซนเทชัน
- ดูไฟล์ PPT
- ดูไฟล์ PPTX
- ดูไฟล์ ODP
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างตัวดูพรีเซนเทชันที่กำหนดเองใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js แสดงไฟล์ PowerPoint และ OpenDocument อย่างง่ายโดยไม่ต้องใช้ Microsoft PowerPoint."
---
## **บทนำ**

Aspose.Slides for Node.js via Java ใช้สำหรับสร้างไฟล์พรีเซนเทชันที่มีสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดพรีเซนเทชันใน Microsoft PowerPoint ตัวอย่างเช่น อย่างไรก็ตาม บางครั้งนักพัฒนาอาจต้องการดูสไลด์เป็นภาพในโปรแกรมดูภาพที่ต้องการหรือสร้างโปรแกรมดูพรีเซนเทชันของตนเอง ในกรณีดังกล่าว Aspose.Slides อนุญาตให้คุณส่งออกสไลด์เดี่ยวเป็นภาพ บทความนี้อธิบายวิธีทำ

## **สร้างภาพ SVG จากสไลด์**

เพื่อสร้างภาพ SVG จากสไลด์พรีเซนเทชันด้วย Aspose.Slides โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงสไลด์ตามดัชนีของมัน
1. เปิดสตรีมไฟล์
1. บันทึกสไลด์เป็นภาพ SVG ไปยังสตรีมไฟล์

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **สร้าง SVG ด้วยรหัสรูปร่างที่กำหนดเอง**

Aspose.Slides สามารถใช้เพื่อสร้าง [SVG](https://docs.fileformat.com/page-description-language/svg/) จากสไลด์ด้วยรหัสรูปร่างที่กำหนดเอง เพื่อทำเช่นนี้ ให้ใช้เมธอด `setId` จาก [SvgShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` สามารถใช้ตั้งค่ารหัสรูปร่างได้

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **สร้างภาพย่อสไลด์**

Aspose.Slides ช่วยให้คุณสร้างภาพย่อของสไลด์เพื่อใช้เป็นตัวอย่าง หากต้องการสร้างภาพย่อของสไลด์ด้วย Aspose.Slides โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงสไลด์ตามดัชนีของมัน
1. รับภาพย่อของสไลด์ที่อ้างอิงด้วยสเกลที่กำหนด
1. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใด ๆ

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **สร้างภาพย่อสไลด์ด้วยมิติตามผู้ใช้กำหนด**

เพื่อสร้างภาพย่อของสไลด์โดยกำหนดมิติตามผู้ใช้ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงสไลด์ตามดัชนีของมัน
1. รับภาพย่อของสไลด์ที่อ้างอิงด้วยมิติที่กำหนด
1. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใด ๆ

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **สร้างภาพย่อสไลด์พร้อมบันทึกของผู้พูด**

เพื่อสร้างภาพย่อของสไลด์พร้อมบันทึกของผู้พูดด้วย Aspose.Slides โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [RenderingOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/)
1. ใช้เมธอด `RenderingOptions.setSlidesLayoutOptions` เพื่อตั้งค่าตำแหน่งของบันทึกของผู้พูด
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงสไลด์ตามดัชนีของมัน
1. รับภาพย่อของสไลด์ที่อ้างอิงด้วยตัวเลือกการเรนเดอร์
1. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใด ๆ

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **ตัวอย่างสด**

คุณสามารถลองแอปฟรี [**Aspose.Slides Viewer**](https://products.aspose.app/slides/th/viewer/) เพื่อดูว่าตรงไหนที่คุณสามารถนำ Aspose.Slides API ไปใช้ได้:

![โปรแกรมดู PowerPoint ออนไลน์](online-PowerPoint-viewer.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถฝังตัวดูพรีเซนเทชันในเว็บแอปพลิเคชัน Node.js ได้หรือไม่?**

ใช่ คุณสามารถใช้ Aspose.Slides บนฝั่งเซิร์ฟเวอร์เพื่อเรนเดอร์สไลด์เป็นภาพหรือ HTML แล้วแสดงผลในเบราว์เซอร์ คุณลักษณะการนำทางและการซูมสามารถทำได้ด้วย JavaScript เพื่อประสบการณ์แบบโต้ตอบ

**วิธีที่ดีที่สุดในการแสดงสไลด์ภายในตัวดูกำหนดเองคืออะไร?**

แนวทางที่แนะนำคือเรนเดอร์แต่ละสไลด์เป็นภาพ (เช่น PNG หรือ SVG) หรือแปลงเป็น HTML ด้วย Aspose.Slides แล้วแสดงผลลัพธ์ภายใน picture box (สำหรับเดสก์ท็อป) หรือ HTML container (สำหรับเว็บ)

**ฉันจะจัดการกับพรีเซนเทชันขนาดใหญ่ที่มีหลายสไลด์อย่างไร?**

สำหรับเด็คขนาดใหญ่ ควรพิจารณาใช้การโหลดแบบ lazy-loading หรือการเรนเดอร์ตามความต้องการของสไลด์ ซึ่งหมายถึงการสร้างเนื้อหาของสไลด์เฉพาะเมื่อผู้ใช้นำทางไปยังสไลด์นั้น ลดการใช้หน่วยความจำและเวลาการโหลด