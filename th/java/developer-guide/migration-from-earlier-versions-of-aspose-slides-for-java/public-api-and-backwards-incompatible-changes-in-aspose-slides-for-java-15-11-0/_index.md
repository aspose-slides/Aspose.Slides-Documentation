---
title: API สาธารณะและการเปลี่ยนแปลงที่เข้ากันไม่ได้ย้อนกลับใน Aspose.Slides for Java 15.11.0
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดสมัยใหม่
- แนวทางเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ทบทวนการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้ฟังก์ชันเสียใน Aspose.Slides for Java เพื่อการย้ายโซลูชันงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [added](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) หรือ [removed](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำมาพร้อมกับ Aspose.Slides for Java 15.11.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
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


#### **เมธอดใหม่ getFirstSlideNumber() และ setFirstSlideNumber() ถูกเพิ่มไปยังคลาส Presentation**
เมธอดใหม่ getFirstSlideNumber() และ setFirstSlideNumber() ช่วยให้สามารถรับหรือกำหนดจำนวนสไลด์แรกในงานนำเสนอได้
เมื่อกำหนดค่าจำนวนสไลด์แรกใหม่ ตัวเลขสไลด์ทั้งหมดจะถูกคำนวณใหม่

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    int firstSlideNumber = pres.getFirstSlideNumber();

    pres.setFirstSlideNumber(10);

    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```