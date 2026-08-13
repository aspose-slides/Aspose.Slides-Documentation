---
title: กำหนดค่าคอลเลกชันฟอนต์สำรองใน .NET
linktitle: คอลเลกชันฟอนต์สำรอง
type: docs
weight: 20
url: /th/net/create-fallback-fonts-collection/
keywords:
- ฟอนต์สำรอง
- กฎสำรอง
- คอลเลกชันฟอนต์
- กำหนดค่าฟอนต์
- ตั้งค่าฟอนต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตั้งค่าคอลเลกชันฟอนต์สำรองใน Aspose.Slides สำหรับ .NET เพื่อให้ข้อความคงความสอดคล้องและคมชัดในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

Aspose.Slides อนุญาตให้คุณกำหนดคอลเลกชันของกฎฟอนต์สำรองสำหรับการนำเสนอ แต่ละกฎฟอนต์สำรองถูกแทนด้วยคลาส `FontFallBackRule` และสามารถเพิ่มลงใน `FontFallBackRulesCollection` ซึ่งทำการ implements อินเตอร์เฟซ `IFontFallBackRulesCollection`  

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดให้กับ property `FontFallBackRulesCollection` ของ `FontsManager` ของการนำเสนอ `FontsManager` ควบคุมฟอนต์ทั่วการนำเสนอ และแต่ละอินสแตนซ์ของ `Presentation` จะมี `FontsManager` ของตนเอง  

เมื่อ `FontsManager` ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองที่ระบุจะถูกใช้ในระหว่างการเรนเดอร์การนำเสนอ  

## **นำกฎฟอนต์สำรองไปใช้**

อินสแตนซ์ของ [FontFallBackRule](https://reference.aspose.com/slides/th/net/aspose.slides/FontFallBackRule) คลาสสามารถจัดระเบียบเป็น [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/net/aspose.slides/fontfallbackrulescollection) ที่ implements อินเตอร์เฟซ [IFontFallBackRulesCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ifontfallbackrulescollection) สามารถเพิ่มหรือเอากฎออกจากคอลเลกชันได้  

จากนั้นคอลเลกชันนี้อาจถูกกำหนดให้กับ [FontFallBackRulesCollection ](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)property ของคลาส [FontsManager](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager) FontsManager ควบคุมฟอนต์ทั่วการนำเสนอ  

แต่ละ [Presentation ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) มี [FontsManager ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/properties/fontsmanager)property ที่มีอินสแตนซ์ของคลาส FontsManager ของตนเอง  

ต่อไปนี้เป็นตัวอย่างวิธีสร้างคอลเลกชันของกฎฟอนต์สำรองและกำหนดให้กับ FontsManager ของการนำเสนอที่ต้องการ:  

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

หลังจาก FontsManager ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองจะถูกใช้ในระหว่างการเรนเดอร์การนำเสนอ  

{{% alert color="info" %}} 
อ่านเพิ่มเติมเกี่ยวกับการ [เรนเดอร์การนำเสนอด้วยฟอนต์สำรอง](/slides/th/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

### กฎฟอนต์สำรองของฉันจะถูกฝังลงในไฟล์ PPTX และปรากฏใน PowerPoint หลังจากบันทึกหรือไม่?

No. กฎฟอนต์สำรองเป็นการตั้งค่าการเรนเดอร์ในเวลารันไทม์; ไม่ได้ถูกจัดเก็บลงในไฟล์ PPTX ดังนั้นจะไม่ปรากฏใน UI ของ PowerPoint.  

### ฟอนต์สำรองจะนำไปใช้กับข้อความภายใน SmartArt, WordArt, แผนภูมิ และตารางหรือไม่?

Yes. กลไกการแทนที่ glyph เดียวกันจะถูกใช้กับข้อความใด ๆ ในวัตถุเหล่านี้.  

### Aspose แจกจ่ายฟอนต์ใดๆ มาพร้อมกับไลบรารีหรือไม่?

No. คุณต้องเพิ่มและใช้ฟอนต์ด้วยตนเองและรับผิดชอบต่อการใช้ฟอนต์นั้น.  

### การแทนที่/การสับเปลี่ยนฟอนต์ที่หายไปและฟอนต์สำรองสำหรับ glyph ที่หายไปสามารถใช้ร่วมกันได้หรือไม่?

Yes. พวกมันเป็นขั้นตอนอิสระของกระบวนการแก้ไขฟอนต์เดียวกัน: ก่อนแรกเอ็นจินจะตรวจสอบว่าฟอนต์พร้อมใช้งานหรือไม่ ([replacement](/slides/th/net/font-replacement/)/[substitution](/slides/th/net/font-substitution/)), จากนั้นฟอนต์สำรองจะเติมช่องว่างสำหรับ glyph ที่หายไปในฟอนต์ที่มีอยู่.