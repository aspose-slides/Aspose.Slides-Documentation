---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ Java 16.1.0
linktitle: Aspose.Slides สำหรับ Java 16.1.0
type: docs
weight: 200
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- วิธีการเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้แตกหักใน Aspose.Slides สำหรับ Java เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, สมบัติ และอื่น ๆ ที่ถูก [added](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) หรือ [removed](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for Java 16.1.0 API

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**


#### **ได้เพิ่มเมธอด getRotationAngle() และ setRotationAngle() ไปยังอินเทอร์เฟซ IChartTextBlockFormat และ ITextFrameFormat**  
ได้เพิ่มเมธอด getRotationAngle() และ setRotationAngle() ไปยังอินเทอร์เฟซ com.aspose.slides.IChartTextBlockFormat และ com.aspose.slides.ITextFrameFormat. พวกมันให้การเข้าถึงการหมุนที่กำหนดเองซึ่งถูกนำไปใช้กับข้อความภายในกล่องขอบเขต

``` java
import com.aspose.slides.*;




Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```