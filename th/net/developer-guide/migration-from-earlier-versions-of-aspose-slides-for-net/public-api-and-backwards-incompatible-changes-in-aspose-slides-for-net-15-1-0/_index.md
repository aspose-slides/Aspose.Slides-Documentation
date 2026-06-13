---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนกลับใน Aspose.Slides สำหรับ .NET 15.1.0
linktitle: Aspose.Slides สำหรับ .NET 15.1.0
type: docs
weight: 130
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- การย้าย
- โค้ดโบราณ
- โค้ดสมัยใหม่
- วิธีการแบบโบราณ
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้แตกหักใน Aspose.Slides สำหรับ .NET เพื่อย้ายการแก้ปัญหา PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการคลาส เมธอด คุณสมบัติ ฯลฯ ทั้งหมดที่ [เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) หรือ [ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำมาพร้อมกับ Aspose.Slides for .NET 15.1.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง API สาธารณะ**
#### **ฟังก์ชันการแทนที่แบบอักษรได้ถูกเพิ่ม**
ได้เพิ่มความสามารถในการแทนที่แบบอักษรทั่วทั้งงานนำเสนอและแบบชั่วคราวสำหรับการเรนเดอร์

ได้แนะนำคุณสมบัติใหม่ "FontsManager" ของคลาส Presentation. คลาส FontsManager มีสมาชิกต่อไปนี้:

**IFontSubstRuleCollection FontSubstRuleList** คุณสมบัติ

คอลเลกชันนี้ของอินสแตนซ์ IFontSubstRule ใช้แทนที่แบบอักษรระหว่างการเรนเดอร์. IFontSubstRule มีคุณสมบัติ SourceFont และ DestFont ซึ่งทำตามอินเทอร์เฟซ IFontData และคุณสมบัติ ReplaceFontCondition ที่ให้เลือกเงื่อนไขการแทนที่ ("WhenInaccessible" หรือ "Always").

**IFontData[] GetFonts()** เมธอด

ใช้เพื่อดึงแบบอักษรทั้งหมดที่ใช้ในงานนำเสนอปัจจุบัน.

**ReplaceFont** เมธอด

ใช้เพื่อแทนที่แบบอักษรอย่างถาวรในงานนำเสนอ.

ตัวอย่างต่อไปนี้แสดงวิธีการแทนที่แบบอักษรในงานนำเสนอ:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

ตัวอย่างอีกหนึ่งแสดงการแทนที่แบบอักษรสำหรับการเรนเดอร์เมื่อไม่สามารถเข้าถึงได้:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // แบบอักษร Arial จะถูกใช้แทน SomeRareFont เมื่อไม่สามารถเข้าถึงได้
            pres.Slides[0].GetThumbnail();

```