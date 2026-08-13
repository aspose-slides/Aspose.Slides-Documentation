---
title: จัดการ Hyperlink ของการนำเสนอบน Android
linktitle: จัดการ Hyperlink
type: docs
weight: 20
url: /th/androidjava/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่ม Hyperlink
- สร้าง Hyperlink
- จัดรูปแบบ Hyperlink
- ลบ Hyperlink
- อัปเดต Hyperlink
- Hyperlink ข้อความ
- Hyperlink สไลด์
- Hyperlink รูปร่าง
- Hyperlink รูปภาพ
- Hyperlink วิดีโอ
- Hyperlink ที่แก้ไขได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการ Hyperlink ในการนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android ผ่าน Java — เพิ่มการโต้ตอบและกระบวนการทำงานในเวลาไม่กี่นาที."
---
## **บทนำ**

Hyperlink คือการอ้างอิงถึงวัตถุหรือข้อมูลหรือสถานที่ในบางอย่าง ซึ่งเป็น Hyperlink ที่พบทั่วไปในงานนำเสนอ PowerPoint:

* ลิงก์ไปยังเว็บไซต์ภายในข้อความ, รูปร่าง หรือสื่อ
* ลิงก์ไปยังสไลด์

Aspose.Slides for Android ผ่าน Java ช่วยให้คุณทำงานหลายอย่างที่เกี่ยวกับ Hyperlink ในงานนำเสนอได้

{{% alert color="info" %}} 
คุณอาจต้องการลองดู Aspose อย่างง่าย, [ตัวแก้ไข PowerPoint ออนไลน์ฟรี.](https://products.aspose.app/slides/th/editor)
{{% /alert %}} 

## **เพิ่ม URL Hyperlink**

### **เพิ่ม URL Hyperlink ไปยังข้อความ**

โค้ด Java นี้แสดงวิธีการเพิ่ม Hyperlink ไปยังเว็บไซต์ในข้อความ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **เพิ่ม URL Hyperlink ไปยังรูปร่างหรือกรอบ**

โค้ดตัวอย่างใน Java นี้แสดงวิธีการเพิ่ม Hyperlink ไปยังเว็บไซต์ในรูปร่าง:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **เพิ่ม URL Hyperlink ไปยังสื่อ**

Aspose.Slides ให้คุณเพิ่ม Hyperlink ไปยังไฟล์ภาพ, ไฟล์เสียง, และไฟล์วิดีโอได้

โค้ดตัวอย่างนี้แสดงวิธีการเพิ่ม Hyperlink ไปยัง **ภาพ**:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// เพิ่มรูปภาพไปยังงานนำเสนอ
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// สร้างเฟรมรูปภาพบนสไลด์ที่ 1 ตามภาพที่เพิ่มไว้ก่อนหน้า
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

โค้ดตัวอย่างนี้แสดงวิธีการเพิ่ม Hyperlink ไปยัง **ไฟล์เสียง**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

โค้ดตัวอย่างนี้แสดงวิธีการเพิ่ม Hyperlink ไปยัง **วิดีโอ**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="Tip"  color="info"  %}} 
คุณอาจต้องการดู *[จัดการ OLE](/slides/th/androidjava/manage-ole/)*.
{{% /alert %}}

## **ใช้ Hyperlink เพื่อสร้างสารบัญ**

เนื่องจาก Hyperlink ช่วยให้คุณเพิ่มการอ้างอิงถึงวัตถุหรือสถานที่ คุณจึงสามารถใช้มันเพื่อสร้างสารบัญได้.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **จัดรูปแบบ Hyperlink**

### **สี**

ด้วยคุณสมบัติ [ColorSource](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) ในอินเทอร์เฟซ [IHyperlink](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlink) คุณสามารถกำหนดสีให้กับ Hyperlink และยังสามารถดึงข้อมูลสีจาก Hyperlink ได้ ฟีเจอร์นี้เริ่มต้นปรากฏใน PowerPoint 2019 ดังนั้นการเปลี่ยนแปลงที่เกี่ยวข้องกับคุณสมบัตินี้จึงไม่ใช้กับเวอร์ชัน PowerPoint เก่ากว่า

โค้ดตัวอย่างนี้สาธิตการดำเนินการซึ่ง Hyperlink ที่มีสีต่างกันถูกเพิ่มลงในสไลด์เดียวกัน:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **ลบ Hyperlink จากงานนำเสนอ**

### **ลบ Hyperlink จากข้อความ**

โค้ด Java นี้แสดงวิธีการลบ Hyperlink จากข้อความในสไลด์ของงานนำเสนอ:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		if (shape instanceof IAutoShape)
		{
			IAutoShape autoShape = (IAutoShape)shape;
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **ลบ Hyperlink จากรูปร่างหรือกรอบ**

โค้ด Java นี้แสดงวิธีการลบ Hyperlink จากรูปร่างในสไลด์ของงานนำเสนอ: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Hyperlink ที่เปลี่ยนแปลงได้**

คลาส [Hyperlink](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Hyperlink) เป็นคลาสที่สามารถเปลี่ยนแปลงได้ ด้วยคลาสนี้คุณสามารถเปลี่ยนค่าของคุณสมบัติเหล่านี้:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

โค้ดสแนปเพ็ทนี้แสดงวิธีการเพิ่ม Hyperlink ไปยังสไลด์และแก้ไข tooltip ของมันภายหลัง:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	// เปลี่ยน tooltip ของ hyperlink ที่ได้เพิ่มไว้แล้ว
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **คุณสมบัติที่รองรับใน IHyperlinkQueries**

คุณสามารถเข้าถึง [IHyperlinkQueries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlinkQueries) จากงานนำเสนอ, สไลด์, หรือข้อความที่กำหนด Hyperlink ไว้ได้.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

คลาส [IHyperlinkQueries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlinkQueries) รองรับเมธอดและคุณสมบัติดังต่อไปนี้:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **คำถามที่พบบ่อย**

### ฉันจะสร้างการนำทางภายในไม่ใช่แค่ไปยังสไลด์เท่านั้น แต่ไปยัง "section" หรือสไลด์แรกของ section ได้อย่างไร?

Section ใน PowerPoint คือการจัดกลุ่มสไลด์; การนำทางโดยเทคนิคจะชี้ไปยังสไลด์เฉพาะ เพื่อ "นำทางไปยัง section" คุณมักจะลิงก์ไปยังสไลด์แรกของมัน.

### Can I attach a hyperlink to master slide elements so it works on all slides?

ใช่. องค์ประกอบในมาสเตอร์สไลด์และเลเอาต์รองรับ Hyperlink ลิงก์เหล่านี้จะแสดงบนสไลด์ลูกและสามารถคลิกได้ในระหว่างการนำเสนอ.

### Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?

ใน [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/androidjava/convert-powerpoint-to-html/) ลิงก์จะถูกเก็บไว้โดยทั่วไป แต่เมื่อส่งออกเป็น [images](/slides/th/androidjava/convert-powerpoint-to-png/) และ [video](/slides/th/androidjava/convert-powerpoint-to-video/) ความสามารถในการคลิกจะไม่ถูกนำไป เพราะรูปแบบเหล่านั้นเป็นกรอบภาพ/วิดีโอแบบแรสเตอร์ ซึ่งไม่รองรับ Hyperlink.