---
title: จัดการฟอนต์ในพรีเซนเทชันบน Android
linktitle: จัดการฟอนต์
type: docs
weight: 10
url: /th/androidjava/manage-fonts/
keywords:
- จัดการฟอนต์
- คุณสมบัติฟอนต์
- ย่อหน้า
- การจัดรูปแบบข้อความ
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "ควบคุมฟอนต์ใน Java ด้วย Aspose.Slides for Android: ฝัง, ทดแทน, และโหลดฟอนต์กำหนดเองเพื่อให้พรีเซนเทชัน PPT, PPTX และ ODP มีความชัดเจน ปลอดภัยต่อแบรนด์ และสอดคล้องกัน"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณจัดการคุณสมบัติฟอนต์ในข้อความของพรีเซนเทชันโดยตรงจากโค้ดของคุณ คุณสามารถเข้าถึงข้อความในสไลด์ผ่านรูปทรง, ฟเฟรมข้อความ, ย่อหน้า, และส่วนต่าง ๆ, แล้วนำการจัดรูปแบบไปใช้กับข้อความที่เลือก

บทความนี้อธิบายวิธีกำหนดคุณสมบัติที่เกี่ยวกับฟอนต์สำหรับข้อความที่มีอยู่ในพรีเซนเทชัน รวมถึงตระกูลฟอนต์, สไตล์ตัวหนาและตัวเอียง, การจัดแนวย่อหน้า, และสีฟอนต์ นอกจากนี้ยังแสดงวิธีสร้างกล่องข้อความ, เพิ่มข้อความลงในกล่อง, และตั้งค่าคุณสมบัติฟอนต์เช่นตระกูลฟอนต์, ตัวหนา, ตัวเอียง, ขีดเส้นใต้, ขนาดฟอนต์, และสี ก่อนบันทึกผลลัพธ์เป็นไฟล์ PPTX

## **จัดการคุณสมบัติที่เกี่ยวข้องกับฟอนต์**
{{% alert color="info" %}} 

พรีเซนเทชันมักจะมีทั้งข้อความและรูปภาพ ข้อความสามารถจัดรูปแบบได้หลายวิธี ไม่ว่าจะเพื่อเน้นส่วนหรือคำเฉพาะ หรือเพื่อให้เป็นไปตามสไตล์ขององค์กร การจัดรูปแบบข้อความช่วยให้ผู้ใช้ปรับลุคและความรู้สึกของเนื้อหาในพรีเซนเทชันได้ บทความนี้แสดงวิธีใช้ Aspose.Slides for Android via Java เพื่อตั้งค่าคุณสมบัติฟอนต์ของย่อหน้าข้อความบนสไลด์

{{% /alert %}} 

เพื่อจัดการคุณสมบัติฟอนต์ของย่อหน้าโดยใช้ Aspose.Slides for Android via Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
2. รับการอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. เข้าถึงรูปทรง [Placeholder](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/placeholder/) ในสไลด์และทำการแคสต์เป็น [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/)
4. รับ [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/) จาก [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) ที่เปิดเผยโดย [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/)
5. จัดแนวย่อหน้าให้ชิดขอบ
6. เข้าถึงข้อความของ [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/) ผ่าน [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/)
7. กำหนดฟอนต์โดยใช้ [FontData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontdata/) และตั้งค่า **Font** ของข้อความใน [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/) ตามนั้น
   1. ตั้งค่าฟอนต์เป็นตัวหนา
   2. ตั้งค่าฟอนต์เป็นตัวเอียง
8. ตั้งค่าสีฟอนต์โดยใช้ [FillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fillformat/) ที่เปิดเผยโดยวัตถุ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/)
9. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

การดำเนินการตามขั้นตอนข้างต้นมีตัวอย่างด้านล่าง โค้ดจะรับพรีเซนเทชันที่ไม่มีการตกแต่งและจัดรูปแบบฟอนต์บนสไลด์หนึ่ง ภาพหน้าจอต่อไปนี้แสดงไฟล์ต้นฉบับและวิธีที่โค้ดสแนปเปตเปลี่ยนแปลงมัน โค้ดจะเปลี่ยนฟอนต์, สี, และสไตล์ของฟอนต์

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**รูป: ข้อความในไฟล์ต้นฉบับ**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**รูป: ข้อความเดียวกันที่มีการจัดรูปแบบใหม่**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// เข้าถึงสไลด์โดยใช้ตำแหน่งของสไลด์
	ISlide slide = pres.getSlides().get_Item(0);

	// เข้าถึง placeholder แรกและที่สองในสไลด์และทำการแคสต์เป็น AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// เข้าถึงย่อหน้าที่หนึ่ง
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// จัดแนวย่อหน้าแบบเต็มบรรทัด
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// เข้าถึงส่วนแรก
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// กำหนดฟอนต์ใหม่
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// กำหนดฟอนต์ใหม่ให้กับส่วน
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

## **ตั้งค่าคุณสมบัติฟอนต์ของข้อความ**
{{% alert color="info" %}} 

ตามที่ได้กล่าวไว้ใน **จัดการคุณสมบัติที่เกี่ยวข้องกับฟอนต์**, [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/) ถูกใช้เพื่อเก็บข้อความที่มีรูปแบบการจัดรูปแบบเดียวกันในย่อหน้า บทความนี้แสดงวิธีใช้ Aspose.Slides for Android via Java เพื่อสร้างกล่องข้อความพร้อมข้อความบางส่วนแล้วกำหนดฟอนต์เฉพาะ และคุณสมบัติต่าง ๆ ของตระกูลฟอนต์

{{% /alert %}} 

เพื่อสร้างกล่องข้อความและตั้งค่าคุณสมบัติฟอนต์ของข้อความในนั้น:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
2. รับการอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/) ชนิด **Rectangle** ลงในสไลด์
4. ลบสไตล์การเติมสีที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/)
5. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) ของ [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/)
6. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/)
7. เข้าถึงวัตถุ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/) ที่เชื่อมโยงกับ [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/)
8. กำหนดฟอนต์ที่จะใช้สำหรับ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/)
9. ตั้งค่าคุณสมบัติฟอนต์อื่น ๆ เช่น ตัวหนา, ตัวเอียง, ขีดเส้นใต้, สี และความสูงโดยใช้คุณสมบัติที่เกี่ยวข้องที่เปิดเผยโดยวัตถุ [Portion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portion/)
10. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

การดำเนินการตามขั้นตอนข้างต้นมีตัวอย่างด้านล่าง

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**รูป: ข้อความพร้อมคุณสมบัติฟอนต์บางอย่างที่ตั้งค่าโดย Aspose.Slides for Android via Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอ็อบเจ็กต์ Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
	// ดึงสไลด์แรก
	ISlide sld = pres.getSlides().get_Item(0);
	
	// เพิ่ม AutoShape ชนิด Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// ลบสไตล์การเติมสีที่เชื่อมโยงกับ AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// เข้าถึง Portion ที่เชื่อมโยงกับ TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// ตั้งค่าฟอนต์สำหรับ Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// ตั้งค่าคุณสมบัติตัวหนาของฟอนต์
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// ตั้งค่าคุณสมบัติตัวเอียงของฟอนต์
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// ตั้งค่าคุณสมบัติลายเส้นขีดเส้นใต้ของฟอนต์
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// ตั้งค่าความสูงของฟอนต์
	port.getPortionFormat().setFontHeight(25);
	
	// ตั้งค่าสีของฟอนต์
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// บันทึกพรีเซนเทชันลงดิสก์
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```