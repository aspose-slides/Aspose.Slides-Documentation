---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 15.1.0
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- การย้ายข้อมูล
- โค้ดเก่า
- โค้ดสมัยใหม่
- แนวทางเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการแตกหักใน Aspose.Slides for Java เพื่อการย้าย PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="primary" %}} 
หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ทั้งหมดที่ [ที่เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) รวมถึงข้อจำกัดใหม่และ [การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) ที่แนะนำมาพร้อมกับ API Aspose.Slides for Java 15.1.0
{{% /alert %}} {{% alert color="primary" %}} 
มีปัญหาที่ทราบอยู่กับลูกศรภาพบางรายการและวัตถุ WordArt ซึ่งจะได้รับการแก้ไขใน Aspose.Slides for Java 15.2.0.
{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **ฟังก์ชันการทดแทนฟอนต์ได้ถูกเพิ่ม**
ได้เพิ่มความสามารถในการแทนที่ฟอนต์ทั่วทั้งงานนำเสนอและแบบชั่วคราวสำหรับการเรนเดอร์

มีการแนะนำเมธอดใหม่ getFontsManager() ของคลาส Presentation. คลาส FontsManager มีสมาชิกต่อไปนี้:

**IFontSubstRuleCollection getFontSubstRuleList**() เมธอด

นี่คือคอลเลกชันของอินสแตนซ์ IFontSubstRule ที่ใช้ในการทดแทนฟอนต์ระหว่างการเรนเดอร์. IFontSubstRule มีเมธอด getSourceFont() และ getDestFont() ที่ทำตามอินเทอร์เฟส IFontData และเมธอด getReplaceFontCondition() ที่ให้เลือกเงื่อนไขการแทนที่ ("WhenInaccessible" หรือ "Always").

**IFontData[] getFonts()** เมธอดสามารถใช้เพื่อดึงฟอนต์ทั้งหมดที่ใช้ในงานนำเสนอปัจจุบัน.

**replaceFont(...)** เมธอดสามารถใช้เพื่อแทนที่ฟอนต์อย่างถาวรในงานนำเสนอ. 

ตัวอย่างต่อไปนี้แสดงวิธีการแทนที่ฟอนต์ในงานนำเสนอ:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

ตัวอย่างอื่นแสดงการทดแทนฟอนต์สำหรับการเรนเดอร์เมื่อฟอนต์ไม่สามารถเข้าถึงได้:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// ฟอนต์ Arial จะถูกใช้แทน SomeRareFont เมื่อไม่สามารถเข้าถึงได้

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```