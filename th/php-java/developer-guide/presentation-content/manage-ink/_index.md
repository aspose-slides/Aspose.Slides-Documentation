---
title: จัดการวัตถุ Ink ในการนำเสนอ PowerPoint ด้วย PHP
linktitle: จัดการ Ink
type: docs
weight: 95
url: /th/php-java/manage-ink/
keywords:
- หมึก
- วัตถุหมึก
- รอยหมึก
- จัดการหมึก
- วาดหมึก
- การวาด
- การส่งออกหมึก
- การเรนเดอร์หมึก
- ซ่อนหมึก
- InkOptions
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการวัตถุหมึกใน PowerPoint, แก้ไขรอยและคุณสมบัติของแปรง, และควบคุมการแสดงผลของหมึกระหว่างการส่งออกเป็น PDF, HTML, SVG, TIFF และภาพด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **บทนำ**

PowerPoint มีคุณลักษณะ Ink ที่ให้คุณวาดเส้นแบบอิสระ Ink สามารถใช้เพื่อเน้นวัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์

Aspose.Slides มีประเภทที่จำเป็นสำหรับการทำงานกับวัตถุ Ink ตัวอย่างเช่น คลาส [Ink](https://reference.aspose.com/slides/th/php-java/aspose.slides/ink/) แทนวัตถุ Ink บนสไลด์

## **ความแตกต่างระหว่างวัตถุปกติและวัตถุ Ink**

วัตถุบนสไลด์ PowerPoint โดยทั่วไปจะแสดงด้วยวัตถุ [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) ในรูปแบบที่ง่ายที่สุด Shape คือคอนเทนเนอร์ที่กำหนดพื้นที่ของวัตถุเอง (กรอบ) พร้อมคุณสมบัติต่าง ๆ เช่น ขนาดคอนเทนเนอร์ รูปร่าง และพื้นหลัง สำหรับข้อมูลเพิ่มเติม ดูที่ [Shape Layout Format](https://docs.aspose.com/slides/th/php-java/shape-manipulations/#access-layout-formats-for-shape)

อย่างไรก็ตามเมื่อ PowerPoint จัดการกับวัตถุ Ink มันจะละเลยคุณสมบัติทั้งหมดของกรอบวัตถุ (คอนเทนเนอร์) ยกเว้นขนาดของมัน ขนาดของพื้นที่คอนเทนเนอร์กำหนดโดยเมธอดมาตรฐาน [Shape.getWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getWidth) และ [Shape.getHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink Traces**

Ink trace คือองค์ประกอบพื้นฐานที่ใช้บันทึกเส้นทางของปากกาเมื่อผู้ใช้เขียน Ink ดิจิตอล Trace จะเก็บลำดับของจุดที่เชื่อมต่อกัน

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุพิกัด X และ Y ของแต่ละจุดตัวอย่าง เมื่อจุดทั้งหมดที่เชื่อมต่อกันถูกวาด จะได้ภาพดังนี้:

![ink_powerpoint2](ink_powerpoint2.png)

## **Brush Properties for Drawing**

Brush ใช้วาดเส้นที่เชื่อมจุดของ Ink trace Brush มีสีและขนาดของตัวเอง แสดงด้วยเมธอด [InkBrush.getColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkbrush/#getColor) และ [InkBrush.getSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkbrush/#getSize)

### **Set Ink Brush Color**

โค้ด PHP นี้แสดงวิธีตั้งค่าสีของ Ink brush:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Set Ink Brush Size**

โค้ด PHP นี้แสดงวิธีตั้งค่าขนาดของ Ink brush:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

โดยทั่วไป ความกว้างและความสูงของ brush ไม่ตรงกันทำให้ PowerPoint ไม่แสดงขนาดของ brush (ส่วนข้อมูลที่สอดคล้องจะเป็นสีเทา) เมื่อความกว้างและความสูงของ brush ตรงกัน PowerPoint จะแสดงขนาดดังนี้:

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อความชัดเจน ให้เพิ่มความสูงของวัตถุ Ink และตรวจสอบมิติสำคัญ:

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (กรอบ) ไม่คำนึงถึงขนาดของ brush — มันสมมติว่าความหนาของเส้นเป็นศูนย์ (ดูภาพก่อนหน้า)

ดังนั้นเพื่อกำหนดพื้นที่ที่มองเห็นของวัตถุ Ink ทั้งหมด ต้องคำนึงถึงขนาดของ brush ของ trace ด้วย ที่นี่วัตถุเป้าหมาย (trace ของข้อความที่เขียนด้วยมือ) ถูกปรับขนาดให้พอดีกับคอนเทนเนอร์ (กรอบ) เมื่อขนาดของคอนเทนเนอร์เปลี่ยนแปลง ขนาดของ brush จะคงที่ และกลับกัน

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint ใช้พฤติกรรมคล้ายกันสำหรับวัตถุข้อความ:

![ink_powerpoint6](ink_powerpoint6.png)

## **Control Ink Appearance During Export and Rendering**

Aspose.Slides ให้คลาส [InkOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkoptions/) เพื่อควบคุมวิธีที่วัตถุ Ink แสดงในผลลัพธ์ที่ส่งออกหรือเรนเดอร์ คุณสามารถใช้คุณสมบัติของมันเพื่อซ่อน Ink ทั้งหมดหรือเปลี่ยนวิธีการตีความการดำเนินการมาสก์ของ brush

ตัวเลือก Ink สามารถกำหนดได้ผ่านตัวเลือกการส่งออกหรือเรนเดอร์สำหรับหลายรูปแบบผลลัพธ์:

| ผลลัพธ์ | คุณสมบัติของตัวเลือก Ink |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/#getInkOptions) |

เมธอดต่อไปนี้ของ [InkOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkoptions/) เปิดเผยการตั้งค่าเดียวกันสองค่า:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkoptions/#getHideInk) กำหนดว่าจะรวมวัตถุ Ink ในผลลัพธ์หรือไม่ ค่าเริ่มต้นคือ `false`
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) กำหนดว่าจะตีความการดำเนินการมาสก์เป็นความทึบแสงเมื่อเรนเดอร์ brush ค่าเริ่มต้นคือ `true`; เรียก [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) ด้วย `false` เพื่อใช้การดำเนินการ ROP แทน

### **Hide Ink Objects in PDF Output**

โดยค่าเริ่มต้นวัตถุ Ink จะยังคงมองเห็นได้เมื่อต้องส่งออก เพื่อสร้างผลลัพธ์ที่สะอาดโดยไม่มีคำอธิบายด้วยมือหรือเนื้อหา Ink อื่น ๆ ให้เรียก [InkOptions.setHideInk](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkoptions/#setHideInk) ด้วย `true`

ตัวอย่าง PHP ต่อไปนี้ส่งออกงานนำเสนอเป็น PDF พร้อมซ่อนวัตถุ Ink ทั้งหมด:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Hide Ink Objects When Rendering a Slide as an Image**

เพื่อซ่อนวัตถุ Ink เมื่อเรนเดอร์สไลด์เป็นภาพบิตแมพ ให้กำหนด [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/#getInkOptions) แล้วส่งตัวเลือกเรนเดอร์ให้กับ [Slide.getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage)

ตัวอย่าง PHP ต่อไปนี้เรนเดอร์สไลด์แรกเป็นภาพ PNG โดยไม่มีวัตถุ Ink:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Control Ink Mask Rendering**

การตั้งค่า [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) ควบคุมวิธีตีความการดำเนินการมาสก์เมื่อเรนเดอร์ brush ของ Ink ค่าเริ่มต้นคือ `true` (ใช้ความทึบแสง) หากต้องการใช้การดำเนินการ ROP ให้เรียก [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) ด้วย `false`

ตัวอย่าง PHP ต่อไปนี้ส่งออกสไลด์เป็น SVG และใช้การเรนเดอร์แบบอิง ROP สำหรับการดำเนินการมาสก์ของ Ink:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

การตั้งค่าเดียวกันสามารถใช้ผ่าน [TiffOptions.getInkOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#getInkOptions) เมื่อต้องการส่งออกงานนำเสนอหรือเรนเดอร์สไลด์เป็น TIFF

### **Choose Whether to Hide or Preserve Ink**

เมื่อคุณต้องการเวอร์ชันสะอาดของงานนำเสนอที่มีคำอธิบายเพื่อแจกจ่ายโดยไม่มีเครื่องหมายการตรวจสอบ ให้เรียก [InkOptions.setHideInk](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkoptions/#setHideInk) ด้วย `true` ระหว่างการส่งออก

ให้ [InkOptions.getHideInk](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkoptions/#getHideInk) มีค่าเริ่มต้นเป็น `false` เมื่อตัวอธิบาย Ink เป็นส่วนหนึ่งของเนื้อหาที่ต้องการ เช่น ความคิดเห็นการตรวจสอบ บันทึกด้วยมือ ไฮไลท์ หรือการวาดที่ต้องการให้ยังคงมองเห็นในผลลัพธ์ที่ส่งออก สิ่งนี้ทำให้แอปพลิเคชันสามารถสร้างผลลัพธ์การตรวจสอบและผลลัพธ์ขั้นสุดท้ายแยกจากกันโดยใช้งานนำเสนอเดียวกันโดยไม่ต้องแก้ไขวัตถุ Ink ต้นฉบับ

## **FAQ**

**Can I change the color or size of an existing ink stroke?**

ได้ คุณสามารถดึง trace จาก [Ink.getTraces](https://reference.aspose.com/slides/th/php-java/aspose.slides/ink/#getTraces) แล้วเปลี่ยน [InkTrace.getBrush](https://reference.aspose.com/slides/th/php-java/aspose.slides/inktrace/#getBrush) เรียก [InkBrush.setColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkbrush/#setColor) หรือ [InkBrush.setSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkbrush/#setSize) เพื่อเปลี่ยน brush

**Does hiding ink change the source presentation?**

ไม่ การเรียก [InkOptions.setHideInk](https://reference.aspose.com/slides/th/php-java/aspose.slides/inkoptions/#setHideInk) มีผลเฉพาะต่อผลลัพธ์ที่เรนเดอร์หรือส่งออก ไม่ได้ลบหรือแก้ไขวัตถุ Ink ในงานนำเสนอต้นฉบับ

**Which export formats support ink options?**

คุณสามารถกำหนดตัวเลือก Ink สำหรับ PDF, HTML, SVG, TIFF และภาพสไลด์แบบบิตแมพผ่านตัวเลือกการส่งออกหรือเรนเดอร์ที่แสดงด้านบน

**Further reading**

* เพื่ออ่านเกี่ยวกับรูปร่างโดยทั่วไป ให้ดูส่วน [PowerPoint Shapes](https://docs.aspose.com/slides/th/php-java/powerpoint-shapes/)
* สำหรับข้อมูลเพิ่มเติมเกี่ยวกับค่าที่มีผล ให้ดู [Shape Effective Properties](https://docs.aspose.com/slides/th/php-java/shape-effective-properties/#get-effective-font-height-value)
* สำหรับรายละเอียดการส่งออกเป็น PDF ดู [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/th/php-java/convert-powerpoint-to-pdf/)
* สำหรับรายละเอียดการส่งออกเป็น HTML ดู [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/th/php-java/convert-powerpoint-to-html/)
* สำหรับรายละเอียดการส่งออกเป็น SVG ดู [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/th/php-java/render-a-slide-as-an-svg-image/)
* สำหรับรายละเอียดการส่งออกเป็น TIFF ดู [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/th/php-java/convert-powerpoint-to-tiff/)
* สำหรับรายละเอียดการเรนเดอร์สไลด์เป็นภาพ ดู [Convert Presentation Slides to Images](https://docs.aspose.com/slides/th/php-java/convert-slide/)