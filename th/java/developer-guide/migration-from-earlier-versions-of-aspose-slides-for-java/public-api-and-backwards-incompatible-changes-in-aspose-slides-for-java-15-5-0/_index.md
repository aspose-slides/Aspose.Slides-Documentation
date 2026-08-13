---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 15.5.0
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- การย้ายข้อมูล
- โค้ดระบบเดิม
- โค้ดสมัยใหม่
- แนวทางแบบเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: รีวิวการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการทำลายใน Aspose.Slides for Java เพื่อการย้ายข้อมูล PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติและอื่น ๆ ที่ [เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) , ข้อจำกัดใหม่และ [การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) ที่นำเข้ามาใน Aspose.Slides for Java 15.5.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **ได้เพิ่มคลาส CommonSlideViewProperties และอินเทอร์เฟซ ICommonSlideViewProperties**
คลาส com.aspose.slides.CommonSlideViewProperties (และอินเทอร์เฟซ com.aspose.slides.ICommonSlideViewProperties) แสดงถึงคุณสมบัติวิวสไลด์ทั่วไป (ขณะนี้เป็นตัวเลือกการปรับขนาดวิว)

### **ได้เพิ่มเมธอด IA​xis.getLabelOffset() และ setLabelOffset(int)**
เมธอด IA​xis.getLabelOffset() , setLabelOffset(int) ทำให้สามารถรับและระบุระยะห่างของป้ายจากแกนได้ ใช้กับแกนประเภทหรือแกนวันที่

### **ได้เพิ่มเมธอด IChartTextBlockFormat.getAutofitType() และ setAutofitType(byte)**
เมธอด getAutofitType() , setAutofitType(/**TextAutofitType**/byte) ได้รับการเพิ่มในอินเทอร์เฟซ com.aspose.slides.IChartTextBlockFormat  
การเปลี่ยนแปลงค่านี้อาจมีผลต่อส่วนของแผนภูมิเฉพาะ: DataLabel และ DataLabelFormat (รองรับเต็มใน PowerPoint 2013; ใน PowerPoint 2007 จะไม่มีผลต่อการเรนเดอร์)

### **ได้เพิ่มเมธอด IChartTextBlockFormat.getWrapText() และ setWrapText(byte)**
เมธอด getWrapText() , setWrapText(/**NullableBool**/byte) ได้รับการเพิ่มในอินเทอร์เฟซ com.aspose.slides.IChartTextBlockFormat  
การเปลี่ยนแปลงค่านี้อาจมีผลต่อส่วนของแผนภูมิเฉพาะ: DataLabel และ DataLabelFormat (รองรับเต็มใน PowerPoint 2007/2013)

### **ได้เพิ่มเมธอดสำหรับจัดการระยะขอบใน IChartTextBlockFormat**
เมธอด getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() และ setMarginBottom(double) ได้รับการเพิ่มในอินเทอร์เฟซ com.aspose.slides.IChartTextBlockFormat  
การเปลี่ยนแปลงค่าต่าง ๆ นี้อาจมีผลต่อส่วนของแผนภูมิเฉพาะ: DataLabel และ DataLabelFormat (รองรับเต็มใน PowerPoint 2013; ใน PowerPoint 2007 จะไม่มีผลต่อการเรนเดอร์)

### **ได้เพิ่มเมธอด ViewProperties.getNotesViewProperties()**
คุณสมบัติ com.aspose.slides.ViewProperties.getNotesViewProperties() ได้รับการเพิ่มขึ้น ใช้เพื่อรับคุณสมบัติวิวทั่วไปที่สัมพันธ์กับโหมดวิวโน้ต

### **ได้เพิ่มเมธอด ViewProperties.getSlideViewProperties()**
เมธอด com.aspose.slides.ViewProperties.getSlideViewProperties() ได้รับการเพิ่มขึ้น ใช้เพื่อรับคุณสมบัติวิวทั่วไปที่สัมพันธ์กับโหมดวิวสไลด์