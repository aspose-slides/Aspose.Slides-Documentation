---
title: กำหนดค่าคอลเลกชันฟอนต์สำรองใน C++
linktitle: คอลเลกชันฟอนต์สำรอง
type: docs
weight: 20
url: /th/cpp/create-fallback-fonts-collection/
keywords:
- ฟอนต์สำรอง
- กฎฟอนต์สำรอง
- คอลเลกชันฟอนต์
- กำหนดค่าฟอนต์
- ตั้งค่าฟอนต์
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ตั้งค่าคอลเลกชันฟอนต์สำรองใน Aspose.Slides สำหรับ C++ เพื่อให้ข้อความคงความสอดคล้องและคมชัดในการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณกำหนดค่าชุดของกฎฟอนต์สำรองสำหรับการนำเสนอแต่ละชุด แต่ละกฎฟอนต์สำรองถูกแทนด้วยคลาส `FontFallBackRule` และสามารถเพิ่มลงใน `FontFallBackRulesCollection` ซึ่งทำการดำเนินตามอินเทอร์เฟซ `IFontFallBackRulesCollection`  

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดค่าโดยใช้เมธอด `set_FontFallBackRulesCollection` ของ `FontsManager` ของการนำเสนอ `FontsManager` ควบคุมฟอนต์ทั่วทั้งการนำเสนอ และแต่ละอินสแตนซ์ของ `Presentation` มี `FontsManager` ของตนเอง  

เมื่อ `FontsManager` ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองที่ระบุจะถูกนำไปใช้ระหว่างการเรนเดอร์การนำเสนอ  

## **นำกฎฟอนต์สำรองไปใช้**

อินสแตนซ์ของคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) สามารถจัดระเบียบเป็น [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrulescollection/) ที่ทำการดำเนินตามอินเทอร์เฟซ [IFontFallBackRulesCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontfallbackrulescollection/) ได้ สามารถเพิ่มหรือค้นกฎจากคอลเลกชันได้  

จากนั้นคอลเลกชันนี้อาจถูกส่งไปยังเมธอด [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) ของคลาส [FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/)  FontsManager ควบคุมฟอนต์ทั่วทั้งการนำเสนอ  

แต่ละ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) มีเมธอด [get_FontsManager()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_fontsmanager/) ที่มีอินสแตนซ์ของคลาส FontsManager ของตนเอง  

ต่อไปนี้คือตัวอย่างวิธีสร้างคอลเลกชันกฎฟอนต์สำรองและกำหนดให้กับ FontsManager ของการนำเสนอหนึ่ง:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

หลังจาก FontsManager ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองจะถูกนำไปใช้ระหว่างการเรนเดอร์การนำเสนอ  

{{% alert color="primary" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธีการ [Render Presentation with Fallback Font](/slides/th/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**กฎฟอนต์สำรองของฉันจะถูกฝังลงในไฟล์ PPTX และเห็นใน PowerPoint หลังจากบันทึกหรือไม่?**

ไม่ กฎฟอนต์สำรองเป็นการตั้งค่าการเรนเดอร์ในขณะรันไทม์; ไม่ได้ถูกซีเรียลไลซ์ลงใน PPTX และจะไม่ปรากฏใน UI ของ PowerPoint.  

**ฟอนต์สำรองจะใช้กับข้อความภายใน SmartArt, WordArt, แผนภูมิ และตารางหรือไม่?**

ใช่ กลไกการแทนที่ glyph เดียวกันจะใช้กับข้อความใดก็ได้ในวัตถุเหล่านี้.  

**Aspose แจกจ่ายฟอนต์ใด ๆ มาพร้อมกับไลบรารีหรือไม่?**

ไม่ คุณต้องเพิ่มและใช้ฟอนต์ด้วยตนเองและรับผิดชอบเอง.  

**สามารถใช้การทดแทน/การแทนที่ฟอนต์ที่หายไปและฟอนต์สำรองสำหรับ glyph ที่หายไปร่วมกันได้หรือไม่?**

ได้ พวกมันเป็นขั้นตอนอิสระของกระบวนการแก้ไขฟอนต์เดียวกัน: ก่อนเริ่มต้นเอนจินจะตรวจสอบความพร้อมของฟอนต์ ([replacement](/slides/th/cpp/font-replacement/)/[substitution](/slides/th/cpp/font-substitution/)) แล้วฟอนต์สำรองจะเติมช่องว่างสำหรับ glyph ที่หายไปในฟอนต์ที่มีอยู่.