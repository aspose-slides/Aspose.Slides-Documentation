---
title: "API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 15.8.0"
linktitle: "Aspose.Slides for Java 15.8.0"
type: docs
weight: 160
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
  - "การย้าย"
  - "โค้ดเก่า"
  - "โค้ดสมัยใหม่"
  - "แนวทางเก่า"
  - "แนวทางสมัยใหม่"
  - "PowerPoint"
  - "OpenDocument"
  - "การนำเสนอ"
  - "Java"
  - "Aspose.Slides"
description: "รีวิวการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการแตกหักใน Aspose.Slides for Java เพื่อการย้ายไปใช้โซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP อย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) หรือ [ลบ](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง API สาธารณะ**
#### **เมธอด getDoughnutHoleSize(), setDoughnutHoleSize(byte) ได้ถูกเพิ่มเข้าไปใน IChartSeries และ ChartSeries**
ระบุขนาดของรูในแผนภูม่าวงแหวน.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```