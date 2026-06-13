---
title: กำหนดค่าคอลเลกชันฟอนต์สำรองใน С++
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
- งานนำเสนอ
- С++
- Aspose.Slides
description: "กำหนดค่าคอลเลกชันฟอนต์สำรองใน Aspose.Slides สำหรับ С++ เพื่อให้ข้อความมีความสอดคล้องและคมชัดในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

Aspose.Slides ให้คุณกำหนดคอลเลกชันของกฎฟอนต์สำรองสำหรับงานนำเสนอ แต่ละกฎฟอนต์สำรองจะแสดงโดยคลาส `FontFallBackRule` และสามารถเพิ่มลงใน `FontFallBackRulesCollection` ซึ่งทำการ implements อินเทอร์เฟซ `IFontFallBackRulesCollection`  

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดค่าได้โดยใช้เมธอด `set_FontFallBackRulesCollection` ของ `FontsManager` ของงานนำเสนอ `FontsManager` ควบคุมฟอนต์ทั่วทั้งงานนำเสนอและแต่ละอินสแตนซ์ `Presentation` จะมี `FontsManager` ของตนเอง  

เมื่อ `FontsManager` ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองที่ระบุจะถูกนำไปใช้ระหว่างการเรนเดอร์งานนำเสนอ  

## **ใช้กฎฟอนต์สำรอง**

อินสแตนซ์ของคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) สามารถจัดระเบียบเป็น [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrulescollection/) ซึ่งทำการ implements อินเทอร์เฟซ [IFontFallBackRulesCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontfallbackrulescollection/) สามารถเพิ่มหรือเอากฎออกจากคอลเลกชันได้  

จากนั้นคอลเลกชันนี้สามารถส่งให้เมธอด [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) ของคลาส [FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/) ได้ FontsManager ควบคุมฟอนต์ทั่วทั้งงานนำเสนอ  

แต่ละ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) มีเมธอด [get_FontsManager()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_fontsmanager/) ที่ให้อินสแตนซ์ของคลาส FontsManager ของตนเอง  

ตัวอย่างวิธีสร้างคอลเลกชันกฎฟอนต์สำรองและกำหนดให้กับ FontsManager ของงานนำเสนอหนึ่ง:    

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

หลังจาก FontsManager ถูกเริ่มต้นด้วยคอลเลกชันฟอนต์สำรอง ฟอนต์สำรองจะถูกนำไปใช้ระหว่างการเรนเดอร์งานนำเสนอ  

{{% alert color="primary" %}} 
อ่านเพิ่มเติมวิธี [เรนเดอร์งานนำเสนอด้วยฟอนต์สำรอง](/slides/th/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**กฎฟอนต์สำรองของฉันจะถูกฝังลงในไฟล์ PPTX และแสดงใน PowerPoint หลังบันทึกหรือไม่?**

ไม่ กฎฟอนต์สำรองเป็นการตั้งค่าการเรนเดอร์ขณะรัน; ไม่ได้ถูกซีเรียลไลซ์ลงในไฟล์ PPTX และจะไม่ปรากฏใน UI ของ PowerPoint.  

**ฟอนต์สำรองใช้กับข้อความภายใน SmartArt, WordArt, แผนภูมิ และตารางหรือไม่?**

ใช่ กลไกการแทนที่ glyph เดียวกันจะถูกใช้กับข้อความใด ๆ ในวัตถุเหล่านี้.  

**Aspose แจกจ่ายฟอนต์ใด ๆ มาพร้อมกับไลบรารีหรือไม่?**

ไม่ คุณต้องเพิ่มและใช้ฟอนต์ด้วยตัวคุณเองและรับผิดชอบเอง.  

**สามารถใช้การแทนที่/การสับเปลี่ยนฟอนต์ที่หายไปและฟอนต์สำรองสำหรับ glyph ที่หายไปร่วมกันได้หรือไม่?**

ใช่ พวกมันเป็นขั้นตอนอิสระของสายงานการแก้ไขฟอนต์เดียวกัน: ก่อนแรกเอนจินจะตรวจสอบความพร้อมของฟอนต์ ([replacement](/slides/th/cpp/font-replacement/)/[substitution](/slides/th/cpp/font-substitution/)) และจากนั้นฟอนต์สำรองจะเติมช่องว่างของ glyph ที่หายไปในฟอนต์ที่มีอยู่.