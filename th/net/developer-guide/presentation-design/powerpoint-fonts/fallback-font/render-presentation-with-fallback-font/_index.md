---
title: เรนเดอร์งานนำเสนอด้วยฟอนต์สำรองใน .NET
linktitle: เรนเดอร์งานนำเสนอ
type: docs
weight: 30
url: /th/net/render-presentation-with-fallback-font/
keywords:
- ฟอนต์สำรอง
- เรนเดอร์ PowerPoint
- เรนเดอร์งานนำเสนอ
- เรนเดอร์สไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรนเดอร์งานนำเสนอด้วยฟอนต์สำรองใน Aspose.Slides สำหรับ .NET - ทำให้ข้อความสอดคล้องกันในไฟล์ PPT, PPTX และ ODP ด้วยตัวอย่างโค้ด C# ทีละขั้นตอน."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเรนเดอร์งานนำเสนอโดยใช้กฎฟอนต์สำรอง บทความนี้จะแสดงวิธีสร้างคอลเลกชันกฎฟอนต์สำรอง, ปรับแก้กฎโดยการลบหรือเพิ่มฟอนต์สำรอง, และกำหนดคอลเลกชันให้กับคุณสมบัติ `FontsManager.FontFallBackRulesCollection`  

เมื่อคอลเลกชันกฎฟอนต์สำรองถูกกำหนดให้กับ `FontsManager` ของงานนำเสนอ กฎเหล่านี้จะถูกนำไปใช้ระหว่างการดำเนินการต่าง ๆ เช่น การบันทึก, การเรนเดอร์, และการแปลงงานนำเสนอ ตัวอย่างจะแสดงวิธีใช้กฎที่กำหนดไว้เมื่อเรนเดอร์ภาพย่อของสไลด์และบันทึกเป็นภาพ PNG  

## **เรนเดอร์สไลด์โดยใช้กฎฟอนต์สำรอง**

ตัวอย่างต่อไปนี้ประกอบด้วยขั้นตอนต่อไปนี้:

1. เรา [สร้างคอลเลกชันกฎฟอนต์สำรอง](/slides/th/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/th/net/aspose.slides/fontfallbackrule/methods/remove) กฎฟอนต์สำรองและ [AddFallBackFonts()](https://reference.aspose.com/slides/th/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) ไปยังกฎอื่น.
1. กำหนดคอลเลกชันกฎให้กับคุณสมบัติ [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. โดยใช้เมธอด [Presentation.Save()](https://reference.aspose.com/slides/th/net/aspose.slides.presentation/save/methods/4) เราสามารถบันทึกงานนำเสนอในรูปแบบเดียวกัน หรือบันทึกในรูปแบบอื่น หลังจากที่คอลเลกชันกฎฟอนต์สำรองถูกตั้งค่าให้กับ FontsManager กฎเหล่านี้จะถูกนำไปใช้ในทุกการดำเนินการกับงานนำเสนอ ไม่ว่าจะเป็นการบันทึก, การเรนเดอร์, การแปลง เป็นต้น.

```c#
using Aspose.Slides;

// สร้างอินสแตนซ์ใหม่ของคอลเลกชันกฎ
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// สร้างกฎหลายรายการ
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// พยายามลบฟอนต์สำรอง "Tahoma" จากกฎที่โหลดไว้
	fallBackRule.Remove("Tahoma");

	// และอัปเดตกฎสำหรับช่วงที่ระบุ
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// นอกจากนี้เรายังสามารถลบกฎที่มีอยู่ทั้งหมดจากรายการได้ โดยเก็บอย่างน้อยหนึ่งกฎไว้เพื่อการเรนเดอร์
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // กำหนดรายการกฎที่เตรียมไว้เพื่อการใช้
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // เรนเดอร์ภาพย่อโดยใช้คอลเลกชันกฎที่เริ่มต้นและบันทึกเป็น PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
อ่านเพิ่มเติมเกี่ยวกับ [บันทึกและการแปลงในงานนำเสนอ](/slides/th/net/convert-powerpoint-to-png/).
{{% /alert %}}