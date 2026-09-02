---
title: จัดการวัตถุอินก์ใน JavaScript
linktitle: จัดการอินก์
type: docs
weight: 95
url: /th/nodejs-java/manage-ink/
keywords:
- อินก์
- วัตถุอินก์
- เส้นทางอินก์
- จัดการอินก์
- วาดอินก์
- การวาด
- การส่งออกอินก์
- การเรนเดอร์อินก์
- ซ่อนอินก์
- InkOptions
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการวัตถุอินก์ของ PowerPoint, แก้ไขเส้นทางและคุณสมบัติของ Brush, และควบคุมการแสดงผลของอินก์ระหว่างการส่งออก PDF, HTML, SVG, TIFF และภาพด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **บทนำ**

PowerPoint มีฟีเจอร์อินก์ที่ช่วยให้คุณวาดเส้นแบบอิสระได้ อินก์สามารถใช้เพื่อไฮไลท์วัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์

Aspose.Slides มีประเภทที่จำเป็นสำหรับการทำงานกับวัตถุอินก์ ตัวอย่างเช่น คลาส [Ink](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ink/) แสดงวัตถุอินก์บนสไลด์

## **ความแตกต่างระหว่างวัตถุปกติและวัตถุอินก์**

วัตถุบนสไลด์ PowerPoint ปกติจะเป็นวัตถุรูปทรง (shape) ในรูปแบบที่ง่ายที่สุด รูปทรงคือคอนเทนเนอร์ที่กำหนดพื้นที่ของวัตถุเอง (กรอบ) พร้อมคุณสมบัติต่าง ๆ เช่น ขนาดคอนเทนเนอร์ รูปร่าง และพื้นหลัง เพื่อข้อมูลเพิ่มเติม ดู [Shape Layout Format](https://docs.aspose.com/slides/th/nodejs-java/shape-manipulations/#access-layout-formats-for-shape)

อย่างไรก็ตาม เมื่อ PowerPoint จัดการกับวัตถุอินก์ จะละเลยคุณสมบัติทั้งหมดของกรอบวัตถุ (คอนเทนเนอร์) ยกเว้นขนาดของมัน ขนาดของพื้นที่คอนเทนเนอร์ถูกกำหนดโดยเมธอดมาตรฐาน [Shape.getWidth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getWidth--) และ [Shape.getHeight](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **เส้นทางอินก์ (Ink Traces)**

เส้นทางอินก์คือองค์ประกอบพื้นฐานที่ใช้บันทึกเส้นทางการเคลื่อนที่ของปากกาเมื่อผู้ใช้เขียนอินก์ดิจิทัล เส้นทางจะเก็บลำดับของจุดที่เชื่อมต่อกัน

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุพิกัด X และ Y ของแต่ละจุดตัวอย่าง เมื่อจุดทั้งหมดที่เชื่อมต่อกันถูกเรนเดอร์ จะได้ภาพดังนี้:

![ink_powerpoint2](ink_powerpoint2.png)

## **คุณสมบัติ Brush สำหรับการวาด**

Brush ใช้สำหรับวาดเส้นที่เชื่อมต่อจุดของเส้นทางอินก์ Brush มีสีและขนาดของตัวเอง ซึ่งแสดงโดยเมธอด [InkBrush.getColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkbrush/#getColor--) และ [InkBrush.getSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkbrush/#getSize--) 

### **ตั้งค่าสี Brush อินก์**

โค้ด JavaScript นี้แสดงวิธีตั้งค่าสีของ Brush อินก์:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **ตั้งค่าขนาด Brush อินก์**

โค้ด JavaScript นี้แสดงวิธีตั้งค่าขนาดของ Brush อินก์:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

โดยทั่วไป ความกว้างและความสูงของ Brush ไม่ตรงกัน ดังนั้น PowerPoint จะแสดงขนาด Brush ไม่ได้ (ส่วนข้อมูลที่สอดคล้องจะถูกทำให้เป็นสีเทา) เมื่อความกว้างและความสูงของ Brush ตรงกัน PowerPoint จะแสดงขนาดดังนี้:

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อให้ง่ายต่อการมองเห็น เราจะเพิ่มความสูงของวัตถุอินก์และตรวจสอบมิติสำคัญ:

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (กรอบ) ไม่ได้คำนึงถึงขนาดของ Brush – มันถือว่า ความหนาของเส้นเป็นศูนย์ (ดูภาพก่อนหน้า)

ดังนั้น เพื่อกำหนดพื้นที่ที่มองเห็นได้ของวัตถุอินก์ทั้งหมด จำเป็นต้องคำนึงถึงขนาด Brush ของเส้นทางต่าง ๆ ที่อยู่ในนั้น ที่นี่วัตถุเป้าหมาย (เส้นทางข้อความที่เขียนด้วยมือ) ถูกสเกลให้พอดีกับขนาดของคอนเทนเนอร์ (กรอบ) เมื่อขนาดของคอนเทนเนอร์เปลี่ยนแปลง ขนาด Brush คงที่ และในทางกลับกัน

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint ใช้พฤติคลักษณะเดียวกันกับวัตถุข้อความ:

![ink_powerpoint6](ink_powerpoint6.png)

## **ควบคุมการแสดงผลอินก์ระหว่างการส่งออกและการเรนเดอร์**

Aspose.Slides มีคลาส [InkOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkoptions/) เพื่อควบคุมวิธีการที่วัตถุอินก์ปรากฏในผลลัพธ์ที่ส่งออกหรือเรนเดอร์ คุณสามารถใช้คุณสมบัติต่าง ๆ เพื่อซ่อนอินก์ทั้งหมดหรือเปลี่ยนวิธีการตีความการทำงานของมาสก์ Brush อินก์

ตัวเลือกอินก์สามารถกำหนดได้ผ่านตัวเลือกการส่งออกหรือการเรนเดอร์สำหรับประเภทผลลัพธ์หลายรูปแบบ:

| ผลลัพธ์ | คุณสมบัติตัวเลือก Ink |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| รูปสไลด์ | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

เมธอดต่อไปนี้ของ [InkOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkoptions/) เปิดเผยการตั้งค่าเดียวกันสองอย่าง:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkoptions/#getHideInk--) กำหนดว่าวัตถุอินก์จะถูกรวมอยู่ในผลลัพธ์หรือไม่ ค่าเริ่มต้นคือ `false`
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) กำหนดว่าการทำงานของมาสก์จะถูกตีความเป็นความทึบแสงเมื่อเรนเดอร์ Brush อินก์หรือไม่ ค่าเริ่มต้นคือ `true`; เรียก [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) ด้วย `false` เพื่อใช้การทำงานแบบ ROP แทน

### **ซ่อนวัตถุอินก์ในผลลัพธ์ PDF**

โดยค่าเริ่มต้น วัตถุอินก์ยังคงมองเห็นได้เมื่อส่งออก หากต้องการสร้างผลลัพธ์ที่ไม่มีหมายเหตุที่เขียนด้วยมือหรือเนื้อหาอินก์อื่น ๆ ให้เรียก [InkOptions.setHideInk](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) ด้วย `true`

ตัวอย่าง JavaScript ต่อไปนี้ส่งออกงานพรีเซนเทชั่นเป็น PDF พร้อมซ่อนวัตถุอินก์ทั้งหมด:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **ซ่อนวัตถุอินก์เมื่อเรนเดอร์สไลด์เป็นภาพ**

เพื่อซ่อนวัตถุอินก์เมื่อเรนเดอร์สไลด์เป็นภาพบิตแมพ ให้กำหนดค่า [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) แล้วส่งตัวเลือกการเรนเดอร์ไปยัง [Slide.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-)

ตัวอย่าง JavaScript ต่อไปนี้เรนเดอร์สไลด์แรกเป็นภาพ PNG โดยไม่มีวัตถุอินก์:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **ควบคุมการเรนเดอร์มาสก์อินก์**

การตั้งค่า [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) ควบคุมวิธีการที่การทำงานของมาสก์จะถูกตีความเมื่อเรนเดอร์ Brush อินก์ ค่าเริ่มต้นคือ `true` ซึ่งใช้ความทึบแสง หากต้องการใช้การทำงานแบบ ROP แทน ให้เรียก [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) ด้วย `false`

ตัวอย่าง JavaScript ต่อไปนี้ส่งออกสไลด์เป็น SVG และใช้การเรนเดอร์แบบ ROP สำหรับการทำงานมาสก์อินก์:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

การตั้งค่าเดียวกันสามารถนำไปใช้ผ่าน [TiffOptions.getInkOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) เมื่อส่งออกพรีเซนเทชั่นหรือเรนเดอร์สไลด์เป็น TIFF

### **เลือกว่าจะซ่อนหรือเก็บอินก์ไว้**

เมื่อคุณต้องการเวอร์ชันที่สะอาดของพรีเซนเทชั่นที่มีหมายเหตุสำหรับการแจกจ่ายโดยไม่มีเครื่องหมายการตรวจสอบ ให้เรียก [InkOptions.setHideInk](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) ด้วย `true` ระหว่างการส่งออก

ปล่อยให้ [InkOptions.getHideInk](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkoptions/#getHideInk--) อยู่ที่ค่าเริ่มต้น `false` เมื่อหมายเหตุอินก์เป็นส่วนของเนื้อหาที่ต้องการ เช่น ความคิดเห็นการตรวจสอบ, โน้ตที่เขียนด้วยมือ, ไฮไลท์ หรือการวาดที่ควรแสดงในผลลัพธ์ที่ส่งออก วิธีนี้ทำให้แอปพลิเคชันสามารถสร้างผลลัพธ์การตรวจสอบและผลลัพธ์สุดท้ายแยกกันจากพรีเซนเทชั่นเดียวกันโดยไม่ต้องแก้ไขวัตถุอินก์ต้นแบบ

## **คำถามที่พบบ่อย**

**ฉันสามารถเปลี่ยนสีหรือขนาดของเส้นอินก์ที่มีอยู่ได้หรือไม่?**

ได้. เรียก [Ink.getTraces](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ink/#getTraces--) เพื่อรับเส้นทาง แล้วเปลี่ยน [InkTrace.getBrush](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inktrace/#getBrush--) ด้วยการเรียก [InkBrush.setColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) หรือ [InkBrush.setSize](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) เพื่อปรับ Brush

**การซ่อนอินก์ทำให้พรีเซนเทชั่นต้นฉบับเปลี่ยนแปลงหรือไม่?**

ไม่. การเรียก [InkOptions.setHideInk](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) มีผลต่อผลลัพธ์ที่เรนเดอร์หรือส่งออกเท่านั้น; ไม่ได้ลบหรือแก้ไขวัตถุอินก์ในพรีเซนเทชั่นต้นฉบับ

**ฟอร์แมตการส่งออกใดบ้างที่รองรับตัวเลือกอินก์?**

คุณสามารถกำหนดตัวเลือกอินก์สำหรับ PDF, HTML, SVG, TIFF และภาพสไลด์แบบบิตแมพผ่านตัวเลือกการส่งออกหรือการเรนเดอร์ที่แสดงข้างต้น

**อ่านต่อ**

* เพื่ออ่านเกี่ยวกับรูปร่างโดยทั่วไป ดูส่วน [PowerPoint Shapes](https://docs.aspose.com/slides/th/nodejs-java/powerpoint-shapes/)
* สำหรับข้อมูลเกี่ยวกับค่าที่มีผล ดู [Shape Effective Properties](https://docs.aspose.com/slides/th/nodejs-java/shape-effective-properties/#get-effective-font-height-value)
* สำหรับรายละเอียดการส่งออก PDF ดู [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/th/nodejs-java/convert-powerpoint-to-pdf/)
* สำหรับรายละเอียดการส่งออก HTML ดู [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/th/nodejs-java/convert-powerpoint-to-html/)
* สำหรับรายละเอียดการส่งออก SVG ดู [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/th/nodejs-java/render-a-slide-as-an-svg-image/)
* สำหรับรายละเอียดการส่งออก TIFF ดู [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/th/nodejs-java/convert-powerpoint-to-tiff/)
* สำหรับรายละเอียดการเรนเดอร์สไลด์เป็นภาพดู [Convert Presentation Slides to Images](https://docs.aspose.com/slides/th/nodejs-java/convert-slide/)