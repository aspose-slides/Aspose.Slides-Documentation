---
title: จัดการวัตถุ Ink ในการนำเสนอบน Android
linktitle: จัดการ Ink
type: docs
weight: 95
url: /th/androidjava/manage-ink/
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
- IInkOptions
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการวัตถุ Ink ของ PowerPoint, แก้ไขรอยและคุณสมบัติของแปรง, และควบคุมลักษณะของ Ink ระหว่างการส่งออกเป็น PDF, HTML, SVG, TIFF และรูปภาพด้วย Aspose.Slides สำหรับ Android."
---
## **บทนำ**

PowerPoint มีคุณลักษณะ Ink ที่ช่วยให้คุณวาดเส้นอิสระ Ink สามารถใช้เพื่อเน้นวัตถุอื่น ๆ แสดงการเชื่อมต่อและกระบวนการ และดึงความสนใจไปยังรายการเฉพาะบนสไลด์

Aspose.Slides มีประเภทที่จำเป็นสำหรับการทำงานกับวัตถุ Ink ตัวอย่างเช่น อินเทอร์เฟซ [IInk](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iink/) แสดงวัตถุ Ink บนสไลด์

## **ความแตกต่างระหว่างวัตถุปกติและวัตถุ Ink**

วัตถุบนสไลด์ PowerPoint มักถูกแทนด้วยวัตถุ shape ในรูปแบบที่เรียบง่ายที่สุด shape คือคอนเทนเนอร์ที่กำหนดพื้นที่ของวัตถุเอง (กรอบ) พร้อมคุณสมบัติเช่น ขนาดคอนเทนเนอร์ รูปร่าง และพื้นหลัง สำหรับข้อมูลเพิ่มเติมดู [Shape Layout Format](https://docs.aspose.com/slides/th/androidjava/shape-manipulations/#access-layout-formats-for-shape)

อย่างไรก็ตาม เมื่อ PowerPoint จัดการกับวัตถุ Ink มันจะละเว้นคุณสมบัติทั้งหมดของกรอบวัตถุ (คอนเทนเนอร์) ยกเว้นขนาดของมัน ขนาดของพื้นที่คอนเทนเนอร์กำหนดโดยเมธอดมาตรฐาน [IShape.getWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getWidth--) และ [IShape.getHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **รอย Ink**

รอย Ink คือองค์ประกอบพื้นฐานที่ใช้บันทึกเส้นทางของปากกาเมื่อผู้ใช้เขียน Ink ดิจิทัล รอยจะเก็บลำดับของจุดที่เชื่อมต่อกัน

รูปแบบการเข้ารหัสที่ง่ายที่สุดระบุพิกัด X และ Y ของแต่ละจุดตัวอย่าง เมื่อจุดที่เชื่อมต่อทั้งหมดถูกเรนเดอร์ จะได้ภาพดังนี้:

![ink_powerpoint2](ink_powerpoint2.png)

## **คุณสมบัติของแปรงสำหรับการวาด**

แปรงใช้สำหรับวาดเส้นที่เชื่อมต่อจุดของรอย Ink แปรงมีสีและขนาดของตัวเอง ซึ่งแสดงโดยเมธอด [IInkBrush.getColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkbrush/#getColor--) และ [IInkBrush.getSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkbrush/#getSize--) 

### **กำหนดสีแปรง Ink**

โค้ด Java นี้แสดงวิธีตั้งค่าสีของแปรง Ink:

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **กำหนดขนาดแปรง Ink**

โค้ด Java นี้แสดงวิธีตั้งค่าขนาดของแปรง Ink:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

โดยทั่วไป ความกว้างและสูงของแปรงจะไม่ตรงกัน ดังนั้น PowerPoint จะไม่แสดงขนาดของแปรง (ส่วนข้อมูลที่เกี่ยวข้องจะเป็นสีเทา) เมื่อความกว้างและสูงของแปรงตรงกัน PowerPoint จะแสดงขนาดดังนี้:

![ink_powerpoint3](ink_powerpoint3.png)

เพื่อความชัดเจน ให้เพิ่มความสูงของวัตถุ Ink และตรวจสอบมิติที่สำคัญ:

![ink_powerpoint4](ink_powerpoint4.png)

คอนเทนเนอร์ (กรอบ) ไม่คำนึงถึงขนาดของแปรง – มันจะสมมติว่าความหนาของเส้นเป็นศูนย์ (ดูรูปก่อนหน้า)

ดังนั้น เพื่อกำหนดพื้นที่ที่มองเห็นของวัตถุ Ink ทั้งหมด จำเป็นต้องคำนึงถึงขนาดแปรงของรอยต่าง ๆ ที่อยู่ในนั้น ที่นี่วัตถุเป้าหมาย (รอยข้อความที่เขียนด้วยมือ) ถูกสเกลให้พอดีกับขนาดของคอนเทนเนอร์ (กรอบ) เมื่อขนาดของคอนเทนเนอร์เปลี่ยนแปลง ขนาดของแปรงคงที่ และกลับกัน

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint ใช้พฤติกรรมคล้ายกันสำหรับวัตถุข้อความ:

![ink_powerpoint6](ink_powerpoint6.png)

## **ควบคุมลักษณะของ Ink ระหว่างการส่งออกและการแสดงผล**

Aspose.Slides มีอินเทอร์เฟซ [IInkOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkoptions/) เพื่อควบคุมวิธีการแสดงผลของวัตถุ Ink ในผลลัพธ์ที่ส่งออกหรือเรนเดอร์ คุณสามารถใช้คุณสมบัติของมันเพื่อซ่อน Ink ทั้งหมดหรือเปลี่ยนวิธีที่การดำเนินการมาสก์ของแปรง Ink ถูกตีความ

ตัวเลือก Ink สามารถตั้งค่าได้ผ่านตัวเลือกการส่งออกหรือการเรนเดอร์สำหรับหลายรูปแบบผลลัพธ์:

| ผลลัพธ์ | คุณสมบัติของ Ink options |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

เมธอดต่อไปนี้ของ [IInkOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkoptions/) เปิดเผยการตั้งค่าเดียวกันสองอย่าง:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) กำหนดว่าวัตถุ Ink จะถูกรวมในผลลัพธ์หรือไม่ ค่าเริ่มต้นคือ `false`
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) กำหนดว่าการดำเนินการมาสก์จะถูกตีความเป็นความทึบแสงเมื่อเรนเดอร์แปรง Ink หรือไม่ ค่าเริ่มต้นคือ `true`; เรียก [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) ด้วย `false` เพื่อใช้การดำเนินการ ROP แทน

### **ซ่อนวัตถุ Ink ในผลลัพธ์ PDF**

โดยค่าเริ่มต้น วัตถุ Ink จะยังคงมองเห็นได้เมื่ิอส่งออก เพื่อสร้างผลลัพธ์ที่สะอาดโดยไม่มีคำอธิบายด้วยมือหรือเนื้อหา Ink อื่น ๆ ให้เรียก [IInkOptions.setHideInk](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) ด้วย `true`

ตัวอย่าง Java ต่อไปนี้ส่งออกงานนำเสนอเป็น PDF พร้อมซ่อนวัตถุ Ink ทั้งหมด:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **ซ่อนวัตถุ Ink เมื่อเรนเดอร์สไลด์เป็นภาพ**

เพื่อซ่อนวัตถุ Ink เมื่อเรนเดอร์สไลด์เป็นภาพบิตแมพ ให้กำหนด [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) แล้วส่งตัวเลือกการเรนเดอร์ไปยัง [ISlide.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-)

ตัวอย่าง Java ต่อไปนี้เรนเดอร์สไลด์แรกเป็นภาพ PNG โดยไม่มีวัตถุ Ink:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **ควบคุมการเรนเดอร์ Mask ของ Ink**

การตั้งค่า [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) ควบคุมวิธีตีความการดำเนินการมาสก์เมื่อเรนเดอร์แปรง Ink ค่าเริ่มต้นคือ `true` ซึ่งใช้ความทึบแสง เพื่อใช้การดำเนินการ ROP แทน ให้เรียก [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) ด้วย `false`

ตัวอย่าง Java ต่อไปนี้ส่งออกสไลด์เป็น SVG และใช้การเรนเดอร์แบบ ROP สำหรับการดำเนินการมาสก์ของ Ink:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

การตั้งค่าเดียวกันสามารถนำไปใช้ผ่าน [TiffOptions.getInkOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) เมื่อส่งออกงานนำเสนอหรือเรนเดอร์สไลด์เป็น TIFF

### **เลือกว่าจะซ่อนหรือเก็บ Ink**

เมื่อคุณต้องการเวอร์ชันสะอาดของงานนำเสนอที่มีการอธิบายเพื่อแจกจ่ายโดยไม่มีเครื่องหมายตรวจสอบ ให้เรียก [IInkOptions.setHideInk](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) ด้วย `true` ระหว่างการส่งออก

ให้ [IInkOptions.getHideInk](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) เป็นค่าเริ่มต้น `false` เมื่อคำอธิบาย Ink เป็นส่วนหนึ่งของเนื้อหาที่ต้องการ เช่น ความคิดเห็นในการตรวจสอบ, โน้ตมือ, ไฮไลท์ หรือการวาดที่ควรแสดงในผลลัพธ์ที่ส่งออก วิธีนี้ทำให้แอปพลิเคชันสามารถสร้างผลลัพธ์การตรวจสอบและผลลัพธ์ขั้นสุดท้ายแยกกันจากงานนำเสนอเดียวกันโดยไม่ต้องแก้ไขวัตถุ Ink ต้นฉบับ

## **คำถามที่พบบ่อย**

**สามารถเปลี่ยนสีหรือขนาดของเส้น Ink ที่มีอยู่ได้หรือไม่?**

ได้ ให้ดึงรอยจาก [IInk.getTraces](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iink/#getTraces--) แล้วเปลี่ยน [IInkTrace.getBrush](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinktrace/#getBrush--) เรียก [IInkBrush.setColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) หรือ [IInkBrush.setSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) เพื่อเปลี่ยนแปรง

**การซ่อน Ink ทำให้งานนำเสนอแหล่งที่มาถูกเปลี่ยนหรือไม่?**

ไม่ การเรียก [IInkOptions.setHideInk](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) มีผลเพียงต่อผลลัพธ์ที่เรนเดอร์หรือส่งออกเท่านั้น ไม่ได้ลบหรือแก้ไขวัตถุ Ink ในงานนำเสนอแหล่งที่มา

**รูปแบบการส่งออกใดบ้างที่รองรับตัวเลือก Ink?**

คุณสามารถกำหนดตัวเลือก Ink สำหรับ PDF, HTML, SVG, TIFF และภาพสไลด์แบบบิตแมพผ่านตัวเลือกการส่งออกหรือการเรนเดอร์ที่แสดงในตารางด้านบน

**เอกสารเพิ่มเติม**

* เพื่ออ่านเกี่ยวกับ shape โดยทั่วไป ดูส่วน [PowerPoint Shapes](https://docs.aspose.com/slides/th/androidjava/powerpoint-shapes/)
* สำหรับข้อมูลเกี่ยวกับค่าที่มีผล ดู [Shape Effective Properties](https://docs.aspose.com/slides/th/androidjava/shape-effective-properties/#get-effective-font-height-value)
* รายละเอียดการส่งออกเป็น PDF ดู [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/th/androidjava/convert-powerpoint-to-pdf/)
* รายละเอียดการส่งออกเป็น HTML ดู [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/th/androidjava/convert-powerpoint-to-html/)
* รายละเอียดการส่งออกเป็น SVG ดู [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/th/androidjava/render-a-slide-as-an-svg-image/)
* รายละเอียดการส่งออกเป็น TIFF ดู [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/th/androidjava/convert-powerpoint-to-tiff/)
* รายละเอียดการเรนเดอร์สไลด์เป็นภาพดู [Convert Presentation Slides to Images](https://docs.aspose.com/slides/th/androidjava/convert-slide/)