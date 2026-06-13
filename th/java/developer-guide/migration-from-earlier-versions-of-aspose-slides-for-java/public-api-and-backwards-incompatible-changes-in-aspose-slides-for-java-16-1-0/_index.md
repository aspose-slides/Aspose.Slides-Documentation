---
title: การเปลี่ยนแปลง Public API และการไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 16.1.0
linktitle: Aspose.Slides for Java 16.1.0
type: docs
weight: 200
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำลายการทำงานใน Aspose.Slides for Java เพื่อช่วยให้คุณย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP อย่างราบรื่น."
---
{{% alert color="primary" %}} 
หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ถูก [เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) หรือ [ลบ](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for Java 16.1.0 API.
{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**

#### **เมธอด getRotationAngle() และ setRotationAngle() ถูกเพิ่มเข้ามาในอินเทอร์เฟซ IChartTextBlockFormat และ ITextFrameFormat**
เมธอด getRotationAngle() และ setRotationAngle() ถูกเพิ่มเข้ามาในอินเทอร์เฟซ com.aspose.slides.IChartTextBlockFormat และ com.aspose.slides.ITextFrameFormat. พวกมันให้การเข้าถึงการหมุนแบบกำหนดเองที่ถูกนำไปใช้กับข้อความภายในกล่องขอบเขต.

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```