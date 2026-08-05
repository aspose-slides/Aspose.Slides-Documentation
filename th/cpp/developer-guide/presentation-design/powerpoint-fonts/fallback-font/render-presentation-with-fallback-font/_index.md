---
title: เรนเดอร์พรีเซนเทชันด้วยฟอนต์สำรองใน C++
linktitle: เรนเดอร์พรีเซนเทชัน
type: docs
weight: 30
url: /th/cpp/render-presentation-with-fallback-font/
keywords:
- ฟอนต์สำรอง
- เรนเดอร์ PowerPoint
- เรนเดอร์พรีเซนเทชัน
- เรนเดอร์สไลด์
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- C++
- Aspose.Slides
description: "เรนเดอร์พรีเซนเทชันด้วยฟอนต์สำรองใน Aspose.Slides สำหรับ C++ – ทำให้ข้อความสอดคล้องกันใน PPT, PPTX และ ODP ด้วยตัวอย่างโค้ด C++ ทีละขั้นตอน."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเรนเดอร์พรีเซนเทชันโดยใช้กฎฟอนต์สำรอง บทความนี้แสดงวิธีสร้างคอลเลกชันของกฎฟอนต์สำรอง, แก้ไขกฎโดยการลบหรือเพิ่มฟอนต์สำรอง, และกำหนดคอลเลกชันโดยใช้เมธอด `FontsManager::set_FontFallBackRulesCollection`  

เมื่อคอลเลกชันของกฎฟอนต์สำรองถูกกำหนดให้กับ `FontsManager` ของพรีเซนเทชัน, กฎจะถูกนำไปใช้ระหว่างการดำเนินการต่างๆ เช่น การบันทึก, การเรนเดอร์, และการแปลงพรีเซนเทชัน ตัวอย่างนี้แสดงวิธีใช้กฎที่กำหนดค่าไว้เมื่อเรนเดอร์รูปย่อยของสไลด์และบันทึกเป็นภาพ PNG  

## **เรนเดอร์สไลด์โดยใช้กฎฟอนต์สำรอง**

1. เรา[สร้างคอลเลกชันของกฎฟอนต์สำรอง](/slides/th/cpp/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/remove/) กฎฟอนต์สำรองหนึ่งและ[AddFallBackFonts()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) ไปยังกฎอื่น.
3. ส่งคอลเลกชันของกฎไปยังเมธอด [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/).
4. ด้วยเมธอด [Presentation::Save()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) เราสามารถบันทึกพรีเซนเทชันในรูปแบบเดียวกันหรือบันทึกในรูปแบบอื่น หลังจากที่คอลเลกชันของกฎฟอนต์สำรองถูกกำหนดให้กับ FontsManager, กฎเหล่านี้จะถูกนำไปใช้ในทุกการดำเนินการกับพรีเซนเทชัน ได้แก่ การบันทึก, การเรนเดอร์, การแปลง เป็นต้น.

``` cpp
// สร้างอินสแตนซ์ใหม่ของคอลเลกชันกฎ
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// สร้างหลายกฎ
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// พยายามลบฟอนต์สำรอง "Tahoma" จากกฎที่โหลด
	fallBackRule->Remove(u"Tahoma");

	// และอัปเดตกฎสำหรับช่วงที่ระบุ
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// เรายังสามารถลบกฎที่มีอยู่ใดๆ จากรายการได้
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// กำหนดรายการกฎที่เตรียมไว้เพื่อใช้
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// เรนเดอร์รูปย่อโดยใช้คอลเลกชันกฎที่กำหนดค่าไว้และบันทึกเป็น PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธีการ [Convert PowerPoint Slides to PNG in C++](/slides/th/cpp/convert-powerpoint-to-png/).
{{% /alert %}}