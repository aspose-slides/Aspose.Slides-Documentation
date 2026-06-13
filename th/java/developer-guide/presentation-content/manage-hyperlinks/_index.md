---
title: จัดการไฮเปอร์ลิงก์ของงานนำเสนอใน Java
linktitle: จัดการไฮเปอร์ลิงก์
type: docs
weight: 20
url: /th/java/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่มไฮเปอร์ลิงก์
- สร้างไฮเปอร์ลิงก์
- จัดรูปแบบไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปร่าง
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "จัดการไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides for Java—เสริมการโต้ตอบและกระบวนการทำงานภายในไม่กี่นาที."
---
## **บทนำ**

ไฮเปอร์ลิงก์คือการอ้างอิงถึงวัตถุหรือข้อมูลหรือสถานที่ในบางอย่าง ซึ่งเป็นไฮเปอร์ลิงก์ที่พบทั่วไปในงานนำเสนอ PowerPoint:

* ลิงก์ไปยังเว็บไซต์ภายในข้อความ รูปร่าง หรือสื่อ
* ลิงก์ไปยังสไลด์

Aspose.Slides for Java ช่วยให้คุณทำงานหลายอย่างที่เกี่ยวกับไฮเปอร์ลิงก์ในงานนำเสนอได้

{{% alert color="primary" %}} 
คุณอาจต้องการลองใช้ Aspose แบบง่าย, [โปรแกรมแก้ไข PowerPoint ออนไลน์ฟรี](https://products.aspose.app/slides/th/editor)
{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังข้อความ**

โค้ด Java นี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์เว็บไซต์ลงในข้อความ:
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

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังรูปร่างหรือเฟรม**

โค้ดตัวอย่างใน Java นี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์เว็บไซต์ลงในรูปร่าง:
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

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังสื่อ**

Aspose.Slides อนุญาตให้คุณเพิ่มไฮเปอร์ลิงก์ไปยังไฟล์รูปภาพ, เสียง, และวิดีโอ.

โค้ดตัวอย่างนี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์ไปยัง **รูปภาพ**:
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
	// สร้างกรอบรูปบนสไลด์ 1 จากรูปภาพที่เพิ่มไว้ก่อนหน้า
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

โค้ดตัวอย่างนี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์ไปยัง **ไฟล์เสียง**:
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

โค้ดตัวอย่างนี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์ไปยัง **วิดีโอ**:
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
คุณอาจต้องการดู *[จัดการ OLE](/slides/th/java/manage-ole/)*.
{{% /alert %}}

## **ใช้ไฮเปอร์ลิงก์เพื่อสร้างสารบัญ**

เนื่องจากไฮเปอร์ลิงก์ทำให้คุณเพิ่มการอ้างอิงต่อวัตถุหรือสถานที่ได้ คุณจึงสามารถใช้มันสร้างสารบัญได้.

โค้ดตัวอย่างนี้แสดงวิธีสร้างสารบัญพร้อมไฮเปอร์ลิงก์:
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

## **จัดรูปแบบไฮเปอร์ลิงก์**

### **สี**

ด้วยคุณสมบัติ [ColorSource](https://reference.aspose.com/slides/th/java/com.aspose.slides/Hyperlink#setColorSource-int-) ในอินเทอร์เฟซ [IHyperlink](https://reference.aspose.com/slides/th/java/com.aspose.slides/IHyperlink) คุณสามารถกำหนดสีให้กับไฮเปอร์ลิงก์และยังสามารถรับข้อมูลสีจากไฮเปอร์ลิงก์ได้ คุณลักษณะนี้ถูกนำมาใช้ครั้งแรกใน PowerPoint 2019 ดังนั้นการเปลี่ยนแปลงที่เกี่ยวกับคุณสมบัตินี้จะไม่ส่งผลกับเวอร์ชัน PowerPoint เก่า.

โค้ดตัวอย่างนี้สาธิตการดำเนินการที่เพิ่มไฮเปอร์ลิงก์หลายสีลงในสไลด์เดียวกัน:
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

## **ลบไฮเปอร์ลิงก์จากงานนำเสนอ**

### **ลบไฮเปอร์ลิงก์จากข้อความ**

โค้ด Java นี้แสดงวิธีลบไฮเปอร์ลิงก์ออกจากข้อความในสไลด์งานนำเสนอ:
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

### **ลบไฮเปอร์ลิงก์จากรูปร่างหรือเฟรม**

โค้ด Java นี้แสดงวิธีลบไฮเปอร์ลิงก์ออกจากรูปร่างในสไลด์งานนำเสนอ: 
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

## **ไฮเปอร์ลิงก์ที่เปลี่ยนแปลงได้**

คลาส [Hyperlink](https://reference.aspose.com/slides/th/java/com.aspose.slides/Hyperlink) สามารถเปลี่ยนแปลงค่าได้ ด้วยคลาสนี้ คุณสามารถเปลี่ยนค่าได้สำหรับคุณสมบัติดังต่อไปนี้:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

ส่วนของโค้ดนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ไปยังสไลด์และแก้ไข tooltip ของมันภายหลัง:
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

## **คุณสมบัติที่รองรับใน IHyperlinkQueries**

คุณสามารถเข้าถึง [IHyperlinkQueries](https://reference.aspose.com/slides/th/java/com.aspose.slides/IHyperlinkQueries) จากงานนำเสนอ, สไลด์, หรือข้อความที่กำหนดไฮเปอร์ลิงก์ไว้.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/th/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

คลาส [IHyperlinkQueries](https://reference.aspose.com/slides/th/java/com.aspose.slides/IHyperlinkQueries) รองรับเมธอดและคุณสมบัติดังต่อไปนี้: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/th/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/th/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/th/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/th/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **คำถามที่พบบ่อย**

**ฉันจะสร้างการนำทางภายในไม่ใช่แค่ไปยังสไลด์ แต่ไปยัง "ส่วน" หรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint คือการจัดกลุ่มสไลด์; การนำทางโดยเทคนิคมุ่งเป้าหมายที่สไลด์เฉพาะ เพื่อ "นำทางไปยังส่วน" คุณมักจะลิงก์ไปยังสไลด์แรกของส่วนนั้น.

**ฉันสามารถแนบไฮเปอร์ลิงก์ไปยังองค์ประกอบสไลด์มาสเตอร์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้. องค์ประกอบสไลด์มาสเตอร์และเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์เหล่านี้จะแสดงบนสไลด์ลูกและสามารถคลิกได้ระหว่างการนำเสนอ.

**ไฮเปอร์ลิงก์จะถูกรักษาไว้เมื่อส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**

ใน [PDF](/slides/th/java/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/java/convert-powerpoint-to-html/) ใช่—ลิงก์จะถูกคงไว้โดยทั่วไป เมื่อส่งออกเป็น [images](/slides/th/java/convert-powerpoint-to-png/) และ [video](/slides/th/java/convert-powerpoint-to-video/) ความสามารถในการคลิกจะไม่ถูกรักษาไว้ เนื่องจากลักษณะของฟอร์แมตเหล่านั้น (เฟรมและวิดีโอแบบราสเตอร์ไม่รองรับไฮเปอร์ลิงก์).