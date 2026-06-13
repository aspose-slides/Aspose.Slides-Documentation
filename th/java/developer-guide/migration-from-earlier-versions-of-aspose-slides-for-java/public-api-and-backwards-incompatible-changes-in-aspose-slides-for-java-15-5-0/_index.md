---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 15.5.0
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- การย้ายข้อมูล
- โค้ดเก่า
- โค้ดสมัยใหม่
- แนวทางดั้งเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดความขัดแย้งใน Aspose.Slides for Java เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ และอื่น ๆ ที่ [เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) รวมถึงข้อจำกัดใหม่ใด ๆ และ [การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) ที่แนะนำใน API ของ Aspose.Slides for Java 15.5.0

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **คลาส CommonSlideViewProperties และอินเตอร์เฟส ICommonSlideViewProperties ถูกเพิ่ม**
com.aspose.slides.CommonSlideViewProperties class (and its interface com.aspose.slides.ICommonSlideViewProperties) represents common slide view properties (currently view scale options).
### **เมธอด IAxis.getLabelOffset(), setLabelOffset(int) ถูกเพิ่ม**
IAxis.getLabelOffset(), setLabelOffset(int) methods allow to get and to specify the distance of labels from the axis. Applied to category or date axis.
### **เมธอด IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) ถูกเพิ่ม**
Methods getAutofitType(), setAutofitType(/**TextAutofitType**/byte) have been added to com.aspose.slides.IChartTextBlockFormat interface.
การเปลี่ยนแปลงค่านี้อาจมีผลเฉพาะกับส่วนของแผนภูมิเหล่านี้: DataLabel และ DataLabelFormat (รองรับเต็มรูปแบบใน PowerPoint 2013; ใน PowerPoint 2007 ไม่มีผลต่อการแสดงผล).
### **เมธอด IChartTextBlockFormat.getWrapText(), setWrapText(byte) ถูกเพิ่ม**
Methods getWrapText(), setWrapText(/**NullableBool**/byte) have been added to interface com.aspose.slides.IChartTextBlockFormat.
การเปลี่ยนแปลงค่านี้อาจมีผลเฉพาะกับส่วนของแผนภูมิเหล่านี้: DataLabel และ DataLabelFormat (รองรับเต็มรูปแบบใน PowerPoint 2007/2013).
### **เมธอดสำหรับจัดการระยะขอบถูกเพิ่มใน IChartTextBlockFormat**
getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() and setMarginBottom(double) methods have been added to interface com.aspose.slides.IChartTextBlockFormat.
การเปลี่ยนแปลงค่านี้อาจมีผลเฉพาะกับส่วนของแผนภูมิเหล่านี้: DataLabel และ DataLabelFormat (รองรับเต็มรูปแบบใน PowerPoint 2013; ใน PowerPoint 2007 ไม่มีผลต่อการแสดงผล).
### **เมธอด ViewProperties.getNotesViewProperties() ถูกเพิ่ม**
com.aspose.slides.ViewProperties.getNotesViewProperties() property has been added. It gets common view properties associated with the notes view mode.
### **เมธอด ViewProperties.getSlideViewProperties() ถูกเพิ่ม**
com.aspose.slides.ViewProperties.getSlideViewProperties() method has been added. Its gets common view properties associated with the slide view mode.