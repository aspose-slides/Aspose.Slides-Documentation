---
title: ทำให้ข้อความ PowerPoint เคลื่อนไหวใน C++
linktitle: ข้อความเคลื่อนไหว
type: docs
weight: 60
url: /th/cpp/animated-text/
keywords:
- ข้อความเคลื่อนไหว
- การเคลื่อนไหวของข้อความ
- ย่อหน้าเคลื่อนไหว
- การเคลื่อนไหวของย่อหน้า
- เอฟเฟกต์การเคลื่อนไหว
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "สร้างข้อความเคลื่อนไหวแบบไดนามิกในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++ พร้อมตัวอย่างโค้ด C++ ที่เข้าใจง่ายและผ่านการปรับให้เหมาะที่สุด."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับข้อความเคลื่อนไหวใน Aspose.Slides โดยการใช้เอฟเฟกต์การเคลื่อนไหวกับย่อหน้าแต่ละอันและดึงเอฟเฟกต์ที่ได้กำหนดไว้แล้วให้กับย่อหน้าในกรอบข้อความ มุ่งเน้นที่เมธอด API ที่ใช้เพิ่มการเคลื่อนไหวระดับย่อหน้าและตรวจสอบเอฟเฟกต์การเคลื่อนไหวของย่อค้าที่มีอยู่ในงานนำเสนอ

## **เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับย่อหน้า**

เราได้เพิ่มเมธอด [**AddEffect()**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) ให้กับคลาส [**Sequence**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.sequence) และ [**ISequence**](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.animation.i_sequence) เมธอดนี้ทำให้คุณสามารถเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับย่อหน้าเดียวได้ ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับย่อหน้าเดียว:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// เลือกย่อหน้าเพื่อเพิ่มเอฟเฟกต์
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// เพิ่มเอฟเฟกต์การเคลื่อนไหวแบบ Fly ให้กับย่อหน้าที่เลือก
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **รับเอฟเฟกต์การเคลื่อนไหวสำหรับย่อหน้า**

คุณอาจต้องการค้นหาเอฟเฟกต์การเคลื่อนไหวที่เพิ่มให้กับย่อหน้า ตัวอย่างเช่น ในบางกรณีคุณต้องการรับเอฟเฟกต์การเคลื่อนไหวในย่อหน้าเพื่อนำไปใช้กับย่อหน้าอื่นหรือรูปร่างอื่น

Aspose.Slides for C++ ให้คุณดึงเอฟเฟกต์การเคลื่อนไหวทั้งหมดที่ใช้กับย่อหน้าที่อยู่ในกรอบข้อความ (รูปร่าง) ตัวอย่างโค้ดนี้แสดงวิธีรับเอฟเฟกต์การเคลื่อนไหวในย่อหน้า:

``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **คำถามที่พบบ่อย**

**การเคลื่อนไหวของข้อความแตกต่างจากการเปลี่ยนภาพสไลด์อย่างไร และสามารถรวมกันได้หรือไม่?**

การเคลื่อนไหวของข้อความควบคุมพฤติกรรมของวัตถุตลอดเวลาในสไลด์ ส่วน [การเปลี่ยนภาพสไลด์](/slides/th/cpp/slide-transition/) ควบคุมวิธีการเปลี่ยนสไลด์ พวกมันทำงานแยกจากกันและสามารถใช้ร่วมกันได้; ลำดับการเล่นจะกำหนดโดยไทม์ไลน์ของการเคลื่อนไหวและการตั้งค่าการเปลี่ยนภาพ

**เอฟเฟกต์การเคลื่อนไหวของข้อความยังคงอยู่เมื่อส่งออกเป็น PDF หรือรูปภาพหรือไม่?**

ไม่ PDF และรูปภาพแบบเราเตอร์เป็นรูปภาพคงที่ ดังนั้นคุณจะเห็นสไลด์ในสถานะเดียวโดยไม่มีการเคลื่อนไหว หากต้องการรักษาการเคลื่อนไหวให้ใช้การส่งออกเป็น [วิดีโอ](/slides/th/cpp/convert-powerpoint-to-video/) หรือ [HTML](/slides/th/cpp/export-to-html5/)

**การเคลื่อนไหวของข้อความทำงานในเลเอาต์และมาสเตอร์สไลด์หรือไม่?**

เอฟเฟกต์ที่ใช้กับวัตถุเลเอาต์/มาสเตอร์จะสืบทอดไปยังสไลด์ แต่เวลาและการทำงานร่วมกับการเคลื่อนไหวระดับสไลด์ขึ้นอยู่กับลำดับสุดท้ายบนสไลด์