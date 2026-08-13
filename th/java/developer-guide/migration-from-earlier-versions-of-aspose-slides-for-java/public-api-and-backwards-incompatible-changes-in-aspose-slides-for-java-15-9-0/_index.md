---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ Java 15.9.0
linktitle: Aspose.Slides สำหรับ Java 15.9.0
type: docs
weight: 170
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดสมัยใหม่
- แนวทางเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดความไม่เข้ากันใน Aspose.Slides สำหรับ Java เพื่อการย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="info" %}} 
หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ และอื่น ๆ ที่ถูก[เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/)หรือ[ลบ](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/)ทั้งหมด รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for Java 15.8.0 API.
{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **เมธอด renderToGraphics ถูกเพิ่มไปยัง com.aspose.slides.ISlide, Slide**
เมธอดต่อไปนี้ได้ถูกเพิ่ม:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
ถูกเพิ่มไปยัง interface com.aspose.slides.ISlide และคลาส com.aspose.slides.Slide เมธอดเหล่านี้ช่วยให้เราสามารถแสดงสไลด์ลงบนวัตถุ Graphics2D ที่ระบุได้

เมธอด `renderToGraphics` ได้ถูกลบออกจาก Public API ตั้งแต่นั้นเป็นต้นมา ในเวอร์ชันปัจจุบัน ให้แสดงสไลด์ด้วย [ISlide.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) ตามตัวอย่างด้านล่างทำ:

``` java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("SomePresentation.pptx");

try {

	IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

	try {

		slideImage.save("slide.png", ImageFormat.Png);

	} finally {

		slideImage.dispose();

	}

} finally {

	if (pres != null) pres.dispose();

}

```