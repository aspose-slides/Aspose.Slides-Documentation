---
title: "จัดการ Hyperlink ของงานนำเสนอบน Android"
linktitle: "จัดการ Hyperlink"
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
- Hyperlink ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการ Hyperlink อย่างง่ายดายในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java—เพิ่มความโต้ตอบและกระบวนการทำงานในเวลาเพียงไม่กี่นาที."
---
## **บทนำ**

Hyperlink คือการอ้างอิงถึงวัตถุหรือข้อมูล หรือสถานที่ในบางอย่าง ซึ่งเป็น Hyperlink ที่พบบ่อยในงานนำเสนอ PowerPoint:

* ลิงก์ไปยังเว็บไซต์ในข้อความ, รูปร่าง, หรือสื่อ
* ลิงก์ไปยังสไลด์

Aspose.Slides for Android via Java ช่วยให้คุณทำงานหลายอย่างที่เกี่ยวกับ Hyperlink ในการนำเสนอได้

{{% alert color="primary" %}} 
คุณอาจต้องการตรวจสอบ Aspose แบบง่าย, [เครื่องมือแก้ไข PowerPoint ออนไลน์ฟรี.](https://products.aspose.app/slides/th/editor)
{{% /alert %}} 

## **เพิ่ม Hyperlink URL**

### **เพิ่ม Hyperlink URL ให้กับข้อความ**

โค้ด Java นี้แสดงวิธีเพิ่ม Hyperlink เว็บไซต์ให้กับข้อความ:

```java
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

### **เพิ่ม Hyperlink URL ให้กับรูปร่างหรือเฟรม**

ตัวอย่างโค้ด Java นี้แสดงวิธีเพิ่ม Hyperlink เว็บไซต์ให้กับรูปร่าง:

```java
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

### **เพิ่ม Hyperlink URL ให้กับสื่อ**

Aspose.Slides ช่วยให้คุณเพิ่ม Hyperlink ไปยังรูปภาพ, ไฟล์เสียง, และไฟล์วิดีโอได้

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่ม Hyperlink ไปยัง **รูปภาพ**:

```java
Presentation pres = new Presentation();
try {
	// เพิ่มรูปภาพลงในงานนำเสนอ
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// สร้างกรอบภาพบนสไลด์ 1 จากภาพที่เพิ่มไว้ก่อนหน้านี้
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่ม Hyperlink ไปยัง **ไฟล์เสียง**:

```java
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

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่ม Hyperlink ไปยัง **วิดีโอ**:

```java
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

{{%  alert  title="Tip"  color="primary"  %}} 
คุณอาจต้องการดู *[จัดการ OLE](/slides/th/androidjava/manage-ole/)*.
{{% /alert %}}

## **ใช้ Hyperlink สร้างสารบัญ**

เพราะ Hyperlink ช่วยให้คุณเพิ่มการอ้างอิงถึงวัตถุหรือสถานที่ คุณจึงสามารถใช้มันสร้างสารบัญได้

ตัวอย่างโค้ดนี้แสดงวิธีสร้างสารบัญพร้อม Hyperlink:

```java
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

ด้วยคุณสมบัติ [ColorSource](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) ในอินเตอร์เฟซ [IHyperlink](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlink) คุณสามารถตั้งค่าสีให้กับ Hyperlink และยังสามารถดึงข้อมูลสีจาก Hyperlink ได้ ฟีเจอร์นี้ถูกแนะนำครั้งแรกใน PowerPoint 2019 ดังนั้นการเปลี่ยนแปลงที่เกี่ยวกับคุณสมบัตินี้จะไม่ใช้กับ PowerPoint เวอร์ชันเก่า

ตัวอย่างโค้ดนี้สาธิตการเพิ่ม Hyperlink ที่มีสีต่างกันบนสไลด์เดียวกัน:

```java
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

## **ลบ Hyperlink จากการนำเสนอ**

### **ลบ Hyperlink จากข้อความ**

โค้ด Java นี้แสดงวิธีลบ Hyperlink จากข้อความในสไลด์การนำเสนอ:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		IAutoShape autoShape = (IAutoShape)shape;
		if (autoShape != null)
		{
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

### **ลบ Hyperlink จากรูปร่างหรือเฟรม**

โค้ด Java นี้แสดงวิธีลบ Hyperlink จากรูปร่างในสไลด์การนำเสนอ:

```java
Presentation pres = new Presentation();
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

คลาส [Hyperlink](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Hyperlink) เป็น mutable. ด้วยคลาสนี้คุณสามารถเปลี่ยนค่าให้กับคุณสมบัติต่าง ๆ ดังนี้:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

ส่วนของโค้ดต่อไปแสดงวิธีเพิ่ม Hyperlink ไปยังสไลด์และแก้ไข tooltip ของมันในภายหลัง:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **คุณสมบัติที่สนับสนุนใน IHyperlinkQueries**

คุณสามารถเข้าถึง [IHyperlinkQueries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlinkQueries) จากการนำเสนอ, สไลด์, หรือข้อความที่กำหนด Hyperlink ไว้ได้

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

คลาส [IHyperlinkQueries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlinkQueries) รองรับเมธอดและคุณสมบัติดังต่อไปนี้:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **คำถามที่พบบ่อย**

**ฉันจะสร้างการนำทางภายในไม่ใช่แค่ไปยังสไลด์ แต่ไปยัง "ส่วน" หรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint คือการจัดกลุ่มสไลด์; การนำทางโดยเทคนิคจะไปยังสไลด์เฉพาะ เพื่อ "นำทางไปยังส่วน" คุณมักจะลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบ Hyperlink ให้กับองค์ประกอบของมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้ มาสเตอร์สไลด์และองค์ประกอบของเลย์เอาต์รองรับ Hyperlink ลิงก์เหล่านี้จะแสดงบนสไลด์ลูกและสามารถคลิกได้ระหว่างการนำเสนอ

**Hyperlink จะถูกเก็บไว้เมื่อส่งออกเป็น PDF, HTML, ภาพ, หรือวิดีโอหรือไม่?**

ใน [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/androidjava/convert-powerpoint-to-html/) มีการเก็บลิงก์ไว้ทั่วไป แต่เมื่อส่งออกเป็น [images](/slides/th/androidjava/convert-powerpoint-to-png/) และ [video](/slides/th/androidjava/convert-powerpoint-to-video/) ความสามารถคลิกจะไม่ย้ายไปได้เนื่องจากลักษณะของฟอร์แมตเหล่านั้น (เฟรมแบบเรสเตอร์/วิดีโอไม่รองรับ Hyperlink)