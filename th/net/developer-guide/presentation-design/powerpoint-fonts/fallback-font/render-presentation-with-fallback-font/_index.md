---
title: เรนเดอร์การนำเสนอด้วยฟอนต์สำรองใน .NET
linktitle: เรนเดอร์การนำเสนอ
type: docs
weight: 30
url: /th/net/render-presentation-with-fallback-font/
keywords:
- ฟอนต์สำรอง
- เรนเดอร์ PowerPoint
- เรนเดอร์การนำเสนอ
- เรนเดอร์สไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรนเดอร์การนำเสนอด้วยฟอนต์สำรองใน Aspose.Slides สำหรับ .NET – ทำให้ข้อความสอดคล้องกันใน PPT, PPTX และ ODP ด้วยตัวอย่างโค้ด C# ทีละขั้นตอน."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถเรนเดอร์งานนำเสนอโดยใช้กฎฟอนต์สำรองได้ บทความนี้แสดงวิธีสร้างคอลเลกชันของกฎฟอนต์สำรอง, แก้ไขกฎโดยการลบหรือเพิ่มฟอนต์สำรอง, และกำหนดคอลเลกชันให้กับ property `FontsManager.FontFallBackRulesCollection`  

เมื่อคอลเลกชันของกฎฟอนต์สำรองถูกกำหนดให้กับ `FontsManager` ของงานนำเสนอ กฎเหล่านี้จะถูกนำไปใช้ในระหว่างการดำเนินการต่าง ๆ เช่น การบันทึก, การเรนเดอร์, และการแปลงงานนำเสนอ ตัวอย่างแสดงวิธีใช้กฎที่กำหนดไว้เมื่อเรนเดอร์ภาพตัวอย่างสไลด์และบันทึกเป็นภาพ PNG

## **เรนเดอร์สไลด์โดยใช้กฎฟอนต์สำรอง**

The following example includes these steps:

1. เรา [สร้างคอลเลกชันของกฎฟอนต์สำรอง](/slides/th/net/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/th/net/aspose.slides/fontfallbackrule/methods/remove) กฎฟอนต์สำรองและ[AddFallBackFonts()](https://reference.aspose.com/slides/th/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) ให้กับกฎอื่น.
3. กำหนดคอลเลกชันของกฎให้กับ property [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
4. ด้วยวิธีการ [Presentation.Save()](https://reference.aspose.com/slides/th/net/aspose.slides.presentation/save/methods/4) เราสามารถบันทึกงานนำเสนอในรูปแบบเดียวกัน หรือบันทึกในรูปแบบอื่น หลังจากที่คอลเลกชันของกฎฟอนต์สำรองถูกตั้งค่าให้กับ FontsManager กฎเหล่านี้จะถูกนำไปใช้ในทุกการดำเนินการกับงานนำเสนอ เช่น การบันทึก, การเรนเดอร์, การแปลง เป็นต้น.

```c#
// สร้างอินสแตนซ์ใหม่ของคอลเลกชันกฎ
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// พยายามลบฟอนต์สำรอง "Tahoma" จากกฎที่โหลดมา
	fallBackRule.Remove("Tahoma");

	// และอัปเดตกฎสำหรับช่วงที่ระบุ
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// นอกจากนี้เราสามารถลบกฎที่มีอยู่ใด ๆ จากรายการได้
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // กำหนดรายการกฎที่เตรียมไว้เพื่อใช้งาน
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // เรนเดอร์ภาพย่อโดยใช้คอลเลกชันกฎที่เริ่มต้นและบันทึกเป็น PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับ [Save and Convertion in Presentation](/slides/th/net/convert-powerpoint-to-png/).
{{% /alert %}}