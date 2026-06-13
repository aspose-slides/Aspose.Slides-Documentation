---
title: จัดการแบบอักษรในงานนำเสนอบน Android
linktitle: จัดการแบบอักษร
type: docs
weight: 10
url: /th/androidjava/manage-fonts/
keywords:
- จัดการแบบอักษร
- คุณสมบัติของแบบอักษร
- ย่อหน้า
- การจัดรูปแบบข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมแบบอักษรใน Java ด้วย Aspose.Slides for Android: ฝัง, แทนที่, และโหลดแบบอักษรกำหนดเองเพื่อให้การนำเสนอ PPT, PPTX และ ODP ชัดเจน ปลอดภัยต่อแบรนด์ และสอดคล้องกัน."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณจัดการคุณสมบัติของแบบอักษรในข้อความของงานนำเสนอโดยตรงจากโค้ดของคุณ คุณสามารถเข้าถึงข้อความในสไลด์ผ่านรูปร่าง, เฟรมข้อความ, ย่อหน้า, และส่วนย่อย, แล้วนำการจัดรูปแบบไปใช้กับข้อความที่เลือก

บทความนี้อธิบายวิธีกำหนดค่าคุณสมบัติที่เกี่ยวข้องกับแบบอักษรสำหรับข้อความที่มีอยู่ในงานนำเสนอ รวมถึงตระกูลแบบอักษร, รูปแบบตัวหนาและตัวเอียง, การจัดตำแหน่งย่อหน้า, และสีของแบบอักษร นอกจากนี้ยังแสดงวิธีสร้างกล่องข้อความ, เพิ่มข้อความลงในกล่อง, และกำหนดคุณสมบัติของแบบอักษรเช่นตระกูลแบบอักษร, ตัวหนา, ตัวเอียง, ขีดเส้นใต้, ขนาดแบบอักษร, และสี ก่อนบันทึกผลลัพธ์เป็นไฟล์ PPTX

## **จัดการคุณสมบัติที่เกี่ยวข้องกับแบบอักษร**
{{% alert color="primary" %}} 

งานนำเสนอส่วนใหญ่จะประกอบด้วยข้อความและรูปภาพ ทั้งสองอย่างสามารถจัดรูปแบบข้อความได้หลายวิธี ไม่ว่าจะเพื่อไฮไลท์ส่วนหรือคำเฉพาะ หรือเพื่อให้สอดคล้องกับสไตล์ขององค์กร การจัดรูปแบบข้อความช่วยให้ผู้ใช้สามารถเปลี่ยนรูปลักษณ์และความรู้สึกของเนื้อหางานนำเสนอได้ บทความนี้แสดงวิธีใช้ Aspose.Slides for Android via Java เพื่อกำหนดคุณสมบัติของแบบอักษรในย่อหน้าของข้อความบนสไลด์

{{% /alert %}} 

เพื่อจัดการคุณสมบัติของแบบอักษรในย่อหน้าโดยใช้ Aspose.Slides for Android via Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เข้าถึงรูปร่าง [Placeholder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholder/) ในสไลด์และแปลงประเภทเป็น [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/)
1. รับ [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/) จาก [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) ที่เปิดโดย [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/)
1. จัดตำแหน่งย่อหน้าให้ชิดขอบ
1. เข้าถึง [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/) ของข้อความใน [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/)
1. กำหนดแบบอักษรโดยใช้ [FontData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontdata/) และตั้งค่า **Font** ของ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/) ของข้อความตามนั้น
   1. ตั้งค่าให้เป็นตัวหนา
   1. ตั้งค่าให้เป็นตัวเอียง
1. ตั้งค่าสีแบบอักษรโดยใช้ [FillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/) ที่เปิดจากออบเจกต์ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/)
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

การทำงานของขั้นตอนด้านบนแสดงไว้ด้านล่าง จะรับงานนำเสนอที่ไม่มีการตกแต่งและทำการจัดรูปแบบแบบอักษรในหนึ่งในสไลด์ ภาพหน้าจอที่ตามมาจะแสดงไฟล์อินพุตและวิธีที่โค้ดสแนปเป็ททำการเปลี่ยนแปลงไฟล์ โค้ดจะเปลี่ยนแบบอักษร, สี, และสไตล์ของแบบอักษร

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: The text in the input file**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: The same text with updated formatting**|

```java
// สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// เข้าถึงสไลด์โดยใช้ตำแหน่งของสไลด์
	ISlide slide = pres.getSlides().get_Item(0);

	// เข้าถึง placeholder ตัวแรกและตัวที่สองในสไลด์และแปลงประเภทเป็น AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// เข้าถึง Paragraph ตัวที่หนึ่ง
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// จัดตำแหน่งย่อหน้าให้ชิดขอบ
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// เข้าถึง Portion ตัวแรก
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// กำหนดแบบอักษรใหม่
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// กำหนดแบบอักษรใหม่ให้กับ Portion
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// ตั้งค่าแบบอักษรเป็นตัวหนา
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// ตั้งค่าแบบอักษรเป็นตัวเอียง
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// ตั้งค่าสีแบบอักษร
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

## **ตั้งค่าคุณสมบัติแบบอักษรของข้อความ**
{{% alert color="primary" %}} 

ตามที่กล่าวไว้ใน **จัดการคุณสมบัติที่เกี่ยวข้องกับแบบอักษร**, [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/) ใช้เพื่อเก็บข้อความที่มีสไตล์การจัดรูปแบบคล้ายกันในย่อหน้า บทความนี้แสดงวิธีใช้ Aspose.Slides for Android via Java เพื่อสร้างกล่องข้อความที่มีข้อความบางส่วนและจากนั้นกำหนดแบบอักษรเฉพาะ, รวมถึงคุณสมบัติอื่นๆ ของตระกูลแบบอักษร

{{% /alert %}} 

เพื่อสร้างกล่องข้อความและตั้งค่าคุณสมบัติของแบบอักษรในข้อความของมัน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/) ชนิด **Rectangle** ลงในสไลด์
1. ลบสไตล์การเติมที่เกี่ยวข้องกับ [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/)
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) ของ [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/)
1. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/)
1. เข้าถึงออบเจกต์ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/) ที่เชื่อมโยงกับ [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/)
1. กำหนดแบบอักษรที่จะใช้สำหรับ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/)
1. ตั้งค่าคุณสมบัติเพิ่มเติมของแบบอักษร เช่น ตัวหนา, ตัวเอียง, ขีดเส้นใต้, สี และขนาดโดยใช้คุณสมบัติที่เกี่ยวข้องจากออบเจกต์ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/)
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

การทำงานของขั้นตอนข้างต้นแสดงไว้ด้านล่าง

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: Text with some font properties set by Aspose.Slides for Android via Java**|

```java
// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
	// รับสไลด์แรก
	ISlide sld = pres.getSlides().get_Item(0);
	
	// เพิ่ม AutoShape ชนิด Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// ลบสไตล์การเติมที่เกี่ยวข้องกับ AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// เข้าถึง Portion ที่เชื่อมโยงกับ TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// ตั้งค่าแบบอักษรสำหรับ Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// ตั้งค่าคุณสมบัติตัวหนาของแบบอักษร
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// ตั้งค่าคุณสมบัติตัวเอียงของแบบอักษร
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// ตั้งค่าคุณสมบัติกีดเส้นใต้ของแบบอักษร
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// ตั้งค่าความสูงของแบบอักษร
	port.getPortionFormat().setFontHeight(25);
	
	// ตั้งค่าสีของแบบอักษร
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// บันทึกงานนำเสนอลงดิสก์
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```