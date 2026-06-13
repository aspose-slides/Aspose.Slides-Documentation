---
title: จัดการแบบอักษรในการนำเสนอด้วย Java
linktitle: จัดการแบบอักษร
type: docs
weight: 10
url: /th/java/manage-fonts/
keywords:
- จัดการแบบอักษร
- คุณสมบัติแบบอักษร
- ย่อหน้า
- การจัดรูปแบบข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมแบบอักษรใน Java ด้วย Aspose.Slides: ฝัง, แทนที่, และโหลดแบบอักษรที่กำหนดเองเพื่อให้การนำเสนอ PPT, PPTX และ ODP ชัดเจน ปลอดภัยต่อแบรนด์ และสอดคล้องกัน."
---
## **ภาพรวม**

Aspose.Slides ให้คุณจัดการคุณสมบัติกล fonts ในข้อความของงานนำเสนอโดยตรงจากโค้ดของคุณ คุณสามารถเข้าถึงข้อความในสไลด์ผ่านรูปทรง, กรอบข้อความ, ย่อหน้า, และส่วนต่าง ๆ แล้วนำการจัดรูปแบบไปใช้กับข้อความที่เลือก

บทความนี้อธิบายวิธีตั้งค่าคุณสมบัติกล fonts สำหรับข้อความที่มีอยู่ในงานนำเสนอ รวมถึงตระกูลฟอนต์, การทำให้เป็นตัวหนาและตัวเอียง, การจัดแนวย่อหน้า, และสีของฟอนต์ นอกจากนี้ยังแสดงวิธีสร้างกล่องข้อความ, เพิ่มข้อความลงในกล่อง, และกำหนดคุณสมบัติกล fonts เช่น ตระกูลฟอนต์, ตัวหนา, ตัวเอียง, ใต้เส้น, ขนาดฟอนต์, และสี ก่อนบันทึกผลลัพธ์เป็นไฟล์ PPTX

## **จัดการคุณสมบัติเกี่ยวกับฟอนต์**
{{% alert color="primary" %}} 

งานนำเสนอส่วนใหญ่จะมีทั้งข้อความและรูปภาพ ข้อความสามารถจัดรูปแบบได้หลายวิธี ไม่ว่าจะเพื่อเน้นส่วนหรือคำเฉพาะหรือเพื่อให้สอดคล้องกับสไตล์ขององค์กร การจัดรูปแบบข้อความช่วยให้ผู้ใช้ปรับรูปลักษณ์และความรู้สึกของเนื้อหางานนำเสนอได้ บทความนี้แสดงวิธีใช้ Aspose.Slides for Java เพื่อกำหนดคุณสมบัติกล fonts ของย่อหน้าข้อความบนสไลด์

{{% /alert %}} 

เพื่อจัดการคุณสมบัติกล fonts ของย่อหน้าโดยใช้ Aspose.Slides for Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) 
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน 
1. เข้าถึงรูปทรง [Placeholder](https://reference.aspose.com/slides/th/java/com.aspose.slides/placeholder/) ในสไลด์และแปลงประเภทเป็น [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) 
1. รับ [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/) จาก [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) ที่เปิดเผยโดย [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) 
1. จัดย่อหน้าให้เป็นการจัดแนวเต็ม 
1. เข้าถึงส่วนข้อความ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) ของ [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/) 
1. กำหนดฟอนต์โดยใช้ [FontData](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontdata/) และตั้งค่า **Font** ของส่วนข้อความ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) ตามนั้น
   1. ตั้งค่าฟอนต์ให้เป็นตัวหนา 
   1. ตั้งค่าฟอนต์ให้เป็นตัวเอียง 
1. ตั้งค่าสีฟอนต์โดยใช้ [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/fillformat/) ที่เปิดเผยโดยอ็อบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) 
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

การดำเนินการตามขั้นตอนข้างต้นมีตัวอย่างโค้ดด้านล่าง มันรับงานนำเสนอที่ไม่มีการจัดรูปแบบใด ๆ และจะแก้ไขฟอนต์บนหนึ่งในสไลด์ ภาพหน้าจอตามมาจะสาธิตไฟล์อินพุตและวิธีที่โค้ดเปลี่ยนแปลงมัน โค้ดจะเปลี่ยนฟอนต์, สี, และสไตล์ของฟอนต์

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**รูปภาพ: ข้อความในไฟล์ต้นฉบับ**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**รูปภาพ: ข้อความเดียวกันพร้อมการจัดรูปแบบที่อัปเดต**|

```java
	// สร้างออบเจ็กต์ Presentation ที่เป็นตัวแทนไฟล์ PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
		// เข้าถึงสไลด์โดยใช้ตำแหน่งของสไลด์
	ISlide slide = pres.getSlides().get_Item(0);

		// เข้าถึง placeholder แรกและที่สองในสไลด์และแปลงประเภทเป็น AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

		// เข้าถึง Paragraph แรก
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

		// จัดแนวย่อหน้าให้เต็ม
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

		// ตั้งค่าแบบอักษรให้เป็นตัวหนา
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

		// ตั้งค่าแบบอักษรให้เป็นตัวเอียง
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

		// ตั้งค่าสีฟอนต์
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

		// บันทึกไฟล์ PPTX ไปยังดิสก์
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **ตั้งค่าคุณสมบัติฟอนต์ของข้อความ**
{{% alert color="primary" %}} 

ตามที่กล่าวไว้ใน **Managing Font Related Properties**, [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) ใช้เพื่อเก็บข้อความที่มีรูปแบบเดียวกันในย่อหน้า บทความนี้แสดงวิธีใช้ Aspose.Slides for Java เพื่อสร้างกล่องข้อความที่มีข้อความบางส่วนและจากนั้นกำหนดฟอนต์เฉพาะและคุณสมบัติต่าง ๆ ของกลุ่มฟอนต์

{{% /alert %}} 

เพื่อสร้างกล่องข้อความและตั้งค่าคุณสมบัติกล fonts ของข้อความในนั้น:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) 
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน 
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) ชนิด **Rectangle** ไปยังสไลด์ 
1. ลบสไตล์การเติมที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) 
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) ของ [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) 
1. เพิ่มข้อความบางส่วนไปยัง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) 
1. เข้าถึงอ็อบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) ที่เชื่อมโยงกับ [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) 
1. กำหนดฟอนต์ที่จะใช้สำหรับ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) 
1. ตั้งค่าคุณสมบัติกล fonts อื่น ๆ เช่น ตัวหนา, ตัวเอียง, ใต้เส้น, สี และความสูงโดยใช้คุณสมบัติที่เปิดเผยโดยอ็อบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/java/com.aspose.slides/portion/) 
1. เขียนงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

การดำเนินการตามขั้นตอนข้างต้นมีตัวอย่างโค้ดด้านล่าง

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**รูปภาพ: ข้อความพร้อมคุณสมบัติกล fonts บางอย่างที่ตั้งค่าโดย Aspose.Slides for Java**|

```java
// สร้างออบเจ็กต์ Presentation ที่เป็นตัวแทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
	// ดึงสไลด์แรก
	ISlide sld = pres.getSlides().get_Item(0);
	
	// เพิ่ม AutoShape ชนิด Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// ลบสไตล์การเติมที่เชื่อมโยงกับ AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// เข้าถึง Portion ที่เชื่อมโยงกับ TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// ตั้งค่า ฟอนต์สำหรับ Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// ตั้งค่าคุณสมบัติ Bold ของฟอนต์
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// ตั้งค่าคุณสมบัติ Italic ของฟอนต์
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// ตั้งค่าคุณสมบัติ Underline ของฟอนต์
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// ตั้งค่าความสูงของฟอนต์
	port.getPortionFormat().setFontHeight(25);
	
	// ตั้งค่าสีของฟอนต์
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// บันทึกงานนำเสนอไปยังดิสก์
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```