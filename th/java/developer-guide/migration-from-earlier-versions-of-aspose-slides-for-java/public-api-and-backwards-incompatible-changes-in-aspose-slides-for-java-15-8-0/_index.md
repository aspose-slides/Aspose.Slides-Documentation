---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ Java 15.8.0
linktitle: Aspose.Slides สำหรับ Java 15.8.0
type: docs
weight: 160
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- การย้ายข้อมูล
- โค้ดรุ่นเก่า
- โค้ดสมัยใหม่
- แนวทางรุ่นเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการทำลายใน Aspose.Slides สำหรับ Java เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณได้อย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมด [เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) หรือ [ลบ](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) ของคลาส, เมธอด, คุณสมบัติ ฯลฯ และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง API สาธารณะ**
#### **เมธอด getDoughnutHoleSize(), setDoughnutHoleSize(byte) ได้รับการเพิ่มลงใน IChartSeries และ ChartSeries**
ระบุขนาดของรูในแผนภูมิดอนัท.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```