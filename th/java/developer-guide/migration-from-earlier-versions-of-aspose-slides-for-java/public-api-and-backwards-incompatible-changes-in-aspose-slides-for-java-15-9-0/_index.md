---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 15.9.0
linktitle: Aspose.Slides for Java 15.9.0
type: docs
weight: 170
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- วิธีการแบบเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้เกิดการแตกหักใน Aspose.Slides for Java เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่[added](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/)หรือ[removed](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **เมธอด renderToGraphics ถูกเพิ่มใน com.aspose.slides.ISlide, Slide**
เมธอดต่อไปนี้ได้รับการเพิ่ม:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);
ถูกเพิ่มใน interface com.aspose.slides.ISlide และใน class com.aspose.slides.Slide เมธอดเหล่านี้ช่วยให้เราสามารถเรนเดอร์สไลด์ไปยังอ็อบเจ็กต์ Graphics2D ที่ระบุได้.

``` java

 BufferedImage bufferedImage = new BufferedImage(960, 720, BufferedImage.TYPE_INT_ARGB);

Graphics2D g2d = bufferedImage.createGraphics();

Presentation pres = new Presentation("SomePresentation.pptx");

pres.getSlides().get_Item(0).renderToGraphics(false, g2d, bufferedImage.getWidth(), bufferedImage.getHeight());

g2d.dispose();

ImageIO.write(bufferedImage, "png", fileName);

```