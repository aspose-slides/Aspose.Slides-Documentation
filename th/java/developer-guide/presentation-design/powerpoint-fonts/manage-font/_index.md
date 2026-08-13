---
title: จัดการแบบอักษรในงานนำเสนอด้วย Java
linktitle: จัดการแบบอักษร
type: docs
weight: 10
url: /th/java/manage-fonts/
keywords:
- จัดการแบบอักษร
- คุณสมบัติตัวอักษร
- ย่อหน้า
- การจัดรูปแบบข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมแบบอักษรใน Java ด้วย Aspose.Slides: ฝัง, แทนที่, และโหลดแบบอักษรกำหนดเองเพื่อให้การนำเสนอ PPT, PPTX และ ODP ชัดเจน ปลอดภัยต่อแบรนด์ และสอดคล้องกัน."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณจัดการคุณสมบัติตัวอักษรในข้อความของงานนำเสนอโดยตรงจากโค้ดของคุณ คุณสามารถเข้าถึงข้อความในสไลด์ผ่านรูปทรง, text frame, paragraph, และ portion แล้วนำไปใช้กำหนดรูปแบบให้กับข้อความที่เลือก

บทความนี้อธิบายวิธีกำหนดค่าคุณสมบัติตัวอักษรสำหรับข้อความที่มีอยู่ในงานนำเสนอ รวมถึงฟอนต์, สไตล์ตัวหนาและตัวเอียง, การจัดตำแหน่งของ paragraph, และสีของฟอนต์ นอกจากนี้ยังแสดงวิธีสร้าง text box, เพิ่มข้อความลงในนั้น, และกำหนดคุณสมบัติตัวอักษร เช่น ฟอนต์, ตัวหนา, ตัวเอียง, ขีดเส้นใต้, ขนาดฟอนต์, และสี ก่อนบันทึกผลลัพธ์เป็นไฟล์ PPTX

## **จัดการคุณสมบัติตัวอักษรที่เกี่ยวข้อง**
{{% alert color="info" %}} 

งานนำเสนอทั่วไปจะประกอบด้วยข้อความและภาพทั้งสองอย่าง ข้อความสามารถกำหนดรูปแบบได้หลายวิธี ไม่ว่าจะเพื่อเน้นส่วนและคำเฉพาะ หรือเพื่อให้สอดคล้องกับสไตล์ของบริษัท การกำหนดรูปแบบข้อความช่วยให้ผู้ใช้ปรับเปลี่ยนลักษณะของเนื้อหางานนำเสนอได้ บทความนี้แสดงวิธีใช้ Aspose.Slides for Java เพื่อกำหนดคุณสมบัติตัวอักษรของ paragraph ของข้อความบนสไลด์

{{% /alert %}} 

เพื่อจัดการคุณสมบัติตัวอักษรของ paragraph ด้วยการใช้ Aspose.Slides for Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation).
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน.
1. เข้าถึงรูปร่าง [Placeholder](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholder/) ในสไลด์และทำการ typecast เป็น [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/).
1. ดึง [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/) จาก [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) ที่เปิดเผยโดย [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/).
1. จัดแนว paragraph ให้เป็นแบบ Justify.
1. เข้าถึง [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) ของข้อความใน [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/).
1. กำหนดฟอนต์โดยใช้ [FontData](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontdata/) และตั้งค่า **Font** ของข้อความใน [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) ตามนั้น.
   1. ตั้งค่าฟอนต์เป็นตัวหนา.
   1. ตั้งค่าฟอนต์เป็นตัวเอียง.
1. ตั้งค่าสีฟอนต์โดยใช้ [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/) ที่เปิดเผยโดยอ็อบเจกต์ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/).
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

การดำเนินการตามขั้นตอนข้างต้นแสดงด้านล่าง โดยจะรับงานนำเสนอที่ไม่มีการตกแต่งและกำหนดรูปแบบฟอนต์บนหนึ่งในสไลด์ ภาพหน้าจอต่อไปนี้แสดงไฟล์ต้นฉบับและวิธีที่โค้ดสแนปเป็ตเปลี่ยนแปลงมัน โค้ดจะเปลี่ยนฟอนต์, สี, และสไตล์ของฟอนต์

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**รูปภาพ: ข้อความในไฟล์ต้นฉบับ**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**รูปภาพ: ข้อความเดียวกันพร้อมรูปแบบที่อัปเดต**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// เข้าถึงสไลด์โดยใช้ตำแหน่งของสไลด์
	ISlide slide = pres.getSlides().get_Item(0);

	// เข้าถึง placeholder แรกและที่สองในสไลด์และทำการ typecast เป็น AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// เข้าถึง Paragraph แรก
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// จัดแนว paragraph ให้อยู่ในรูปแบบ Justify
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// เข้าถึง portion แรก
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// กำหนดฟอนต์ใหม่
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// กำหนดฟอนต์ใหม่ให้กับ portion
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// ตั้งค่าฟอนต์เป็นตัวหนา
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// ตั้งค่าฟอนต์เป็นตัวเอียง
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// ตั้งค่าสีฟอนต์
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// บันทึกไฟล์ PPTX ลงดิสก์
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **ตั้งค่าคุณสมบัติตัวอักษรของข้อความ**
{{% alert color="info" %}} 

ตามที่ได้กล่าวไว้ใน **จัดการคุณสมบัติตัวอักษรที่เกี่ยวข้อง**, [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) ใช้เพื่อเก็บข้อความที่มีรูปแบบเดียวกันใน paragraph บทความนี้แสดงวิธีใช้ Aspose.Slides for Java เพื่อสร้าง textbox พร้อมข้อความบางส่วนและกำหนดฟอนต์เฉพาะ รวมถึงคุณสมบัติต่าง ๆ ของหมวดฟอนต์

{{% /alert %}} 

เพื่อสร้าง textbox และตั้งค่าคุณสมบัติตัวอักษรของข้อความในนั้น:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation).
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน.
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) ประเภท **Rectangle** ลงในสไลด์.
1. ลบสไตล์การเติมที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/).
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) ของ [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/).
1. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/).
1. เข้าถึงอ็อบเจกต์ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) ที่เชื่อมโยงกับ [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/).
1. กำหนดฟอนต์ที่จะใช้สำหรับ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/).
1. ตั้งค่าคุณสมบัติตัวอักษรอื่น ๆ เช่น ตัวหนา, ตัวเอียง, ขีดเส้นใต้, สีและความสูงโดยใช้คุณสมบัติที่เปิดเผยโดยอ็อบเจกต์ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/).
1. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**รูปภาพ: ข้อความที่มีการตั้งค่าคุณสมบัติตัวอักษรบางอย่างโดย Aspose.Slides for Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pres = new Presentation();
try {
	// รับสไลด์แรก
	ISlide sld = pres.getSlides().get_Item(0);
	
	// เพิ่ม AutoShape ชนิด Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// ลบสไตล์การเติมใด ๆ ที่เชื่อมโยงกับ AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// เข้าถึง Portion ที่เชื่อมโยงกับ TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// กำหนดฟอนต์สำหรับ Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// ตั้งค่าคุณสมบัติตัวหนาของฟอนต์
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// ตั้งค่าคุณสมบัติตัวเอียงของฟอนต์
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// ตั้งค่าคุณสมบัติเข้าใต้ของฟอนต์
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// ตั้งค่าความสูงของฟอนต์
	port.getPortionFormat().setFontHeight(25);
	
	// ตั้งค่าสีของฟอนต์
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// บันทึกงานนำเสนอลงดิสก์
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```
