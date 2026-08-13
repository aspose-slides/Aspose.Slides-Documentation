---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนกลับใน Aspose.Slides สำหรับ Java 15.1.0
linktitle: Aspose.Slides สำหรับ Java 15.1.0
type: docs
weight: 100
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดสมัยใหม่
- แนวทางดั้งเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการทำงานไม่เข้ากันใน Aspose.Slides สำหรับ Java เพื่อย้ายโซลูชันงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายชื่อคลาส เมธอด คุณสมบัติ ฯลฯ ทั้งหมดที่ถูกเพิ่ม ข้อจำกัดใหม่ และ [การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) ที่ถูกแนะนำใน Aspose.Slides for Java 15.1.0 API

{{% /alert %}} {{% alert color="info" %}} 

มีปัญหาที่ทราบอยู่บางประการเกี่ยวกับจุดภาพ (image bullets) และวัตถุ WordArt ซึ่งจะได้รับการแก้ไขใน Aspose.Slides for Java 15.2.0

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **เพิ่มฟังก์ชันการแทนที่ฟอนต์**
เพิ่มความสามารถในการแทนที่ฟอนต์ทั่วทั้งงานนำเสนอและแบบชั่วคราวสำหรับการเรนเดอร์

ได้มีการแนะนำเมธอดใหม่ **getFontsManager()** ของคลาส **Presentation** คลาส **FontsManager** มีสมาชิกต่อไปนี้:

**IFontSubstRuleCollection getFontSubstRuleList**() method  

เป็นคอลเลกชันของอินสแตนซ์ **IFontSubstRule** ที่ใช้เพื่อแทนที่ฟอนต์ในระหว่างการเรนเดอร์  **IFontSubstRule** มีเมธอด **getSourceFont()** และ **getDestFont()** ที่ทำตามอินเทอร์เฟซ **IFontData** และเมธอด **getReplaceFontCondition()** ที่ให้เลือกเงื่อนไขการแทนที่ ("WhenInaccessible" หรือ "Always")

**IFontData[] getFonts**() method สามารถใช้เพื่อดึงฟอนต์ทั้งหมดที่ใช้งานในงานนำเสนอปัจจุบัน

เมธอด **replaceFont(...)** สามารถใช้เพื่อแทนที่ฟอนต์ในงานนำเสนอแบบถาวร  

ตัวอย่างต่อไปนี้แสดงวิธีแทนที่ฟอนต์ในงานนำเสนอ:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

ตัวอย่างอื่นแสดงการแทนฟอนต์สำหรับการเรนเดอร์เมื่อฟอนต์ไม่สามารถเข้าถึงได้:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // ฟอนท์ Arial จะถูกใช้แทน SomeRareFont เมื่อไม่สามารถเข้าถึงได้.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```