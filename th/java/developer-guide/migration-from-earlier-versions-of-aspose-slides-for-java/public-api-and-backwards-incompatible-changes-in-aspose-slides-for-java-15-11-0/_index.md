---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 15.11.0
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- การย้ายข้อมูล
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการแบบเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ทบทวนการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการแตกหักใน Aspose.Slides for Java เพื่อการย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP อย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) หรือ [ลบ](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน API ของ Aspose.Slides for Java 15.11.0

{{% /alert %}} 
## **การเปลี่ยนแปลง API สาธารณะ**
#### **เมธอดที่ล้าสมัยในคลาส com.aspose.slides.DataLabelCollection ถูกลบออกแล้ว**
เมธอดที่ล้าสมัยในคลาส com.aspose.slides.DataLabelCollection ถูกลบออกแล้ว:

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)


#### **เมธอดใหม่ getFirstSlideNumber() และ setFirstSlideNumber() ถูกเพิ่มเข้าสู่คลาส Presentation**
เมธอดใหม่ getFirstSlideNumber() และ setFirstSlideNumber() ให้ความสามารถในการรับหรือกำหนดหมายเลขของสไลด์แรกในงานนำเสนอ
เมื่อกำหนดค่าหมายเลขสไลด์แรกใหม่ ตัวเลขสไลด์ทั้งหมดจะถูกคำนวณใหม่

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```