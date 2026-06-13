---
title: กำหนดค่าคอลเลกชันฟอนต์สำรองใน .NET
linktitle: คอลเลกชันฟอนต์สำรอง
type: docs
weight: 20
url: /th/net/create-fallback-fonts-collection/
keywords:
- ฟอนต์สำรอง
- กฎฟอนต์สำรอง
- คอลเลกชันฟอนต์
- กำหนดค่าฟอนต์
- ตั้งค่าฟอนต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตั้งค่าคอลเลกชันฟอนต์สำรองใน Aspose.Slides สำหรับ .NET เพื่อให้ข้อความคงความสอดคล้องและคมชัดในงานพรีเซนเทชัน PowerPoint และ OpenDocument"
---
## **Overview**

Aspose.Slides ให้คุณกำหนดคอลเลกชันของกฎฟอนต์สำรองสำหรับงานพรีเซนเทชัน แต่ละกฎฟอนต์สำรองถูกแทนด้วยคลาส `FontFallBackRule` และสามารถเพิ่มลงใน `FontFallBackRulesCollection` ที่ทำงานตามอินเทอร์เฟซ `IFontFallBackRulesCollection`  

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดให้กับคุณสมบัติ `FontFallBackRulesCollection` ของ `FontsManager` ในพรีเซนเทชัน `FontsManager` จะควบคุมฟอนต์ทั่วทั้งพรีเซนเทชัน และแต่ละอินสแตนซ์ของ `Presentation` จะมี `FontsManager` ของตนเอง  

เมื่อ `FontsManager` ถูกกำหนดค่าเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองที่ระบุจะถูกนำไปใช้ระหว่างการเรนเดอร์พรีเซนเทชัน  

## **ใช้กฎฟอนต์สำรอง**

อินสแตนซ์ของ [FontFallBackRule](https://reference.aspose.com/slides/th/net/aspose.slides/FontFallBackRule) สามารถจัดระเบียบเป็น [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/net/aspose.slides/fontfallbackrulescollection) ซึ่งทำตามอินเทอร์เฟซ [IFontFallBackRulesCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ifontfallbackrulescollection) สามารถเพิ่มหรือเอากฎออกจากคอลเลกชันได้  

จากนั้นคอลเลกชันนี้อาจถูกกำหนดให้กับคุณสมบัติ [FontFallBackRulesCollection ](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) ของคลาส [FontsManager](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager)  FontsManager ควบคุมฟอนต์ทั่วงานพรีเซนเทชัน  

แต่ละ [Presentation ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) มีคุณสมบัติ [FontsManager ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/properties/fontsmanager) ที่มีอินสแตนซ์ของคลาส FontsManager ของตนเอง  

นี่คือตัวอย่างวิธีสร้างคอลเลกชันกฎฟอนต์สำรองและกำหนดให้กับ FontsManager ของพรีเซนเทชันที่ต้องการ:  

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

หลังจากที่ FontsManager ถูกกำหนดค่าเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองจะถูกนำไปใช้ระหว่างการเรนเดอร์พรีเซนเทชัน  

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธีการ [Render Presentation with Fallback Font](/slides/th/net/render-presentation-with-fallback-font/). 
{{% /alert %}}

## **FAQ**

**กฎฟอนต์สำรองของฉันจะถูกฝังลงในไฟล์ PPTX และปรากฏใน PowerPoint หลังจากบันทึกหรือไม่?**

ไม่ กฎฟอนต์สำรองเป็นการตั้งค่าการเรนเดอร์ขณะทำงาน; ไม่ได้ถูกจัดเก็บลงในไฟล์ PPTX และจะไม่ปรากฏใน UI ของ PowerPoint  

**กฎฟอนต์สำรองใช้กับข้อความภายใน SmartArt, WordArt, ชาร์ตและตารางหรือไม่?**

ใช่ กลไกการแทนที่ glyph เดียวกันจะถูกใช้กับข้อความใด ๆ ในวัตถุเหล่านี้  

**Aspose แจกจ่ายฟอนต์ใด ๆ มาพร้อมกับไลบรารีหรือไม่?**

ไม่ คุณต้องเพิ่มและใช้ฟอนต์ด้วยตนเองและรับผิดชอบต่อการใช้งานนั้น  

**สามารถใช้การแทนที่/การทดแทนฟอนต์ที่หายไปร่วมกับการสำรองฟอนต์สำหรับ glyph ที่หายไปได้หรือไม่?**

ใช่ ทั้งสองเป็นขั้นตอนอิสระของสายงานการแก้ปัญหาฟอนต์เดียวกัน: ก่อนแรกเอนจินจะตรวจสอบความพร้อมของฟอนต์ ([replacement](/slides/th/net/font-replacement/)/[substitution](/slides/th/net/font-substitution/)) จากนั้นการสำรองฟอนต์จะเติมช่องว่างของ glyph ที่หายไปในฟอนต์ที่มีอยู่  