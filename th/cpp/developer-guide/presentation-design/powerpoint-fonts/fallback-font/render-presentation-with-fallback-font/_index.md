---
title: เรนเดอร์การนำเสนอด้วยฟอนต์สำรองใน С++
linktitle: เรนเดอร์การนำเสนอ
type: docs
weight: 30
url: /th/cpp/render-presentation-with-fallback-font/
keywords:
- ฟอนต์สำรอง
- เรนเดอร์ PowerPoint
- เรนเดอร์การนำเสนอ
- เรนเดอร์สไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- С++
- Aspose.Slides
description: "เรนเดอร์การนำเสนอด้วยฟอนต์สำรองใน Aspose.Slides สำหรับ С++ – ทำให้ข้อความสอดคล้องกันในไฟล์ PPT, PPTX และ ODP ด้วยตัวอย่างโค้ด С++ ทีละขั้นตอน."
---
## **ภาพรวม**

Aspose.Slides อนุญาตให้คุณเรนเดอร์งานนำเสนอโดยใช้กฎฟอนต์สำรอง บทความนี้แสดงวิธีสร้างคอลเลกชันกฎฟอนต์สำรอง, แก้ไขกฎโดยการลบหรือเพิ่มฟอนต์สำรอง, และกำหนดคอลเลกชันโดยใช้เมธอด `FontsManager::set_FontFallBackRulesCollection`.

เมื่อคอลเลกชันกฎฟอนต์สำรองถูกกำหนดให้กับ `FontsManager` ของงานนำเสนอ, กฎจะถูกนำไปใช้ในระหว่างการดำเนินการเช่นการบันทึก, การเรนเดอร์, และการแปลงงานนำเสนอ ตัวอย่างนี้แสดงวิธีใช้กฎที่กำหนดค่าเมื่อเรนเดอร์ภาพย่อสไลด์และบันทึกเป็นภาพ PNG

## **เรนเดอร์สไลด์โดยใช้กฎฟอนต์สำรอง**

ตัวอย่างต่อไปนี้ประกอบด้วยขั้นตอนเหล่านี้:

1. เรา [สร้างคอลเลกชันกฎฟอนต์สำรอง](/slides/th/cpp/create-fallback-fonts-collection/).
2. ทำการ [Remove()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/remove/) กฎฟอนต์สำรองและ [AddFallBackFonts()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) ให้กับกฎอื่น.
3. ส่งคอลเลกชันกฎไปยังเมธอด [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) .
4. ด้วยเมธอด [Presentation::Save()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) เราสามารถบันทึกงานนำเสนอในรูปแบบเดิม หรือบันทึกในรูปแบบอื่นได้ หลังจากที่คอลเลกชันกฎฟอนต์สำรองถูกตั้งค่าให้กับ FontsManager, กฎเหล่านี้จะถูกนำไปใช้ในทุกการดำเนินการกับงานนำเสนอ: บันทึก, เรนเดอร์, แปลง เป็นต้น.

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

// นอกจากนี้เรายังสามารถลบกฎที่มีอยู่ใด ๆ ออกจากรายการ
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// กำหนดรายการกฎที่เตรียมไว้สำหรับการใช้
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// เรนเดอร์ภาพย่อโดยใช้คอลเลกชันกฎที่กำหนดค่าไว้และบันทึกเป็น PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับการ [แปลงสไลด์ PowerPoint เป็น PNG ใน C++](/slides/th/cpp/convert-powerpoint-to-png/).
{{% /alert %}}