---
title: เรนเดอร์การนำเสนอด้วยฟอนต์สำรองใน C++
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
- C++
- Aspose.Slides
description: "เรนเดอร์การนำเสนอด้วยฟอนต์สำรองใน Aspose.Slides สำหรับ C++ – ทำให้ข้อความคงที่ระหว่าง PPT, PPTX และ ODP ด้วยตัวอย่างโค้ด C++ ทีละขั้นตอน."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถเรนเดอร์งานนำเสนอโดยใช้กฎฟอนต์สำรองได้ บทความนี้แสดงวิธีสร้างคอลเลกชันของกฎฟอนต์สำรอง, แก้ไขกฎโดยการลบหรือเพิ่มฟอนต์สำรอง, และกำหนดคอลเลกชันโดยใช้เมธอด `FontsManager::set_FontFallBackRulesCollection`。

เมื่อคอลเลกชันของกฎฟอนต์สำรองถูกกำหนดให้กับ `FontsManager` ของงานนำเสนอ กฎเหล่านั้นจะถูกนำไปใช้ในการดำเนินการต่าง ๆ เช่น การบันทึก, การเรนเดอร์, และการแปลงงานนำเสนอ ตัวอย่างแสดงวิธีใช้กฎที่กำหนดค่าไว้เมื่อเรนเดอร์ภาพย่อของสไลด์และบันทึกเป็นภาพ PNG。

## **การเรนเดอร์สไลด์โดยใช้กฎฟอนต์สำรอง**

ตัวอย่างต่อไปนี้ประกอบด้วยขั้นตอนเหล่านี้:

1. เรา [สร้างคอลเลกชันของกฎฟอนต์สำรอง](/slides/th/cpp/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/remove/) กฎฟอนต์สำรองและ [AddFallBackFonts()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) ไปยังกฎอื่น。
1. ส่งคอลเลกชันของกฎไปยังเมธอด [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/)。
1. ด้วยเมธอด [Presentation::Save()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) เราสามารถบันทึกงานนำเสนอในรูปแบบเดิมหรือบันทึกในรูปแบบอื่นได้ หลังจากที่คอลเลกชันของกฎฟอนต์สำรองถูกตั้งค่าให้กับ FontsManager กฎเหล่านี้จะถูกนำไปใช้ในการดำเนินการใด ๆ กับงานนำเสนอ: บันทึก, เรนเดอร์, แปลง, เป็นต้น。

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

// สร้างอินสแตนซ์ใหม่ของคอลเลกชันกฎ
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// สร้างกฎหลายรายการ
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

// เรายังสามารถลบกฎที่มีอยู่ทั้งหมดจากรายการได้
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธีการ [แปลงสไลด์ PowerPoint เป็น PNG ใน C++](/slides/th/cpp/convert-powerpoint-to-png/)。
{{% /alert %}}