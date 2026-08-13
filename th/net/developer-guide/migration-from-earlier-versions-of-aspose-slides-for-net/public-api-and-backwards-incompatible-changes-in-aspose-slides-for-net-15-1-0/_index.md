---
title: การเปลี่ยนแปลง Public API และการไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 15.1.0
linktitle: Aspose.Slides สำหรับ .NET 15.1.0
type: docs
weight: 130
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- การย้ายข้อมูล
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการแบบดั้งเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้เกิดการเสียฟังก์ชันใน Aspose.Slides for .NET เพื่อการย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="info" %}} 

หน้าตัวนี้แสดงรายการคลาส เมธอด คุณสมบัติ และอื่น ๆ ที่ถูก[added](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)หรือ[removed](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 15.1.0 API

{{% /alert %}} 
## **Public API Chages**
#### **Fonts Substitutions Functinality Has Been Added**
ความสามารถในการแทนที่ฟอนต์ทั่วทั้งงานนำเสนอและแบบชั่วคราวสำหรับการเรนเดอร์ได้ถูกเพิ่มเข้ามา

มีการแนะนำคุณสมบัติใหม่ "FontsManager" ของคลาส Presentation แล้ว คลาส FontsManager มีสมาชิกต่อไปนี้:

**IFontSubstRuleCollection FontSubstRuleList** Property

คอลเลกชันของอินสแตนซ์ IFontSubstRule ที่ใช้ในการแทนที่ฟอนต์ระหว่างการเรนเดอร์ IFontSubstRule มีคุณสมบัติ SourceFont และ DestFont ที่ทำตามอินเตอร์เฟซ IFontData และคุณสมบัติ ReplaceFontCondition ที่ให้เลือกเงื่อนไขการแทนที่ ("WhenInaccessible" หรือ "Always")

**IFontData[] GetFonts()** Method

ใช้เพื่อดึงฟอนต์ทั้งหมดที่ใช้ในงานนำเสนอปัจจุบัน

**ReplaceFont** Methods

ใช้เพื่อแทนที่ฟอนต์ในงานนำเสนออย่างถาวร

ตัวอย่างต่อไปนี้แสดงวิธีการแทนที่ฟอนต์ในงานนำเสนอ:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

ตัวอย่างอื่น แสดงการแทนที่ฟอนต์สำหรับการเรนเดอร์เมื่อไม่สามารถเข้าถึงได้:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // ฟอนต์ Arial จะถูกใช้แทน SomeRareFont เมื่อไม่สามารถเข้าถึงได้
            pres.Slides[0].GetImage();
```