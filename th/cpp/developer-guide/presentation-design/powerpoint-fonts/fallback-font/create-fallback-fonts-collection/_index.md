---
title: กำหนดค่าคอลเลกชันแบบอักษรสำรองใน C++
linktitle: คอลเลกชันแบบอักษรสำรอง
type: docs
weight: 20
url: /th/cpp/create-fallback-fonts-collection/
keywords:
- แบบอักษรสำรอง
- กฎแบบอักษรสำรอง
- คอลเลกชันแบบอักษร
- กำหนดค่าแบบอักษร
- ตั้งค่าแบบอักษร
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ตั้งค่าคอลเลกชันแบบอักษรสำรองใน Aspose.Slides สำหรับ C++ เพื่อให้ข้อความคงความสอดคล้องและคมชัดในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

Aspose.Slides ให้คุณกำหนดคอลเลกชันของกฎแบบอักษรสำรองสำหรับงานนำเสนอ แต่ละกฎแบบอักษรสำรองจะถูกแทนด้วยคลาส `FontFallBackRule` และสามารถเพิ่มไปยัง `FontFallBackRulesCollection` ซึ่งทำหน้าที่เป็นการใช้งาน `IFontFallBackRulesCollection` interface  

หลังจากสร้างคอลเลกชันแล้ว คุณสามารถกำหนดค่าได้โดยใช้เมธอด `set_FontFallBackRulesCollection` ของ `FontsManager` ของงานนำเสนอ `FontsManager` ควบคุมแบบอักษรทั่วงานนำเสนอและแต่ละอินสแตนซ์ของ `Presentation` มี `FontsManager` ของตนเอง  

เมื่อ `FontsManager` ถูกเริ่มต้นด้วยคอลเลกชันแบบอักษรสำรอง แบบอักษรสำรองที่ระบุจะถูกนำไปใช้ระหว่างการเรนเดอร์งานนำเสนอ  

## **ใช้กฎแบบอักษรสำรอง**

อินสแตนซ์ของคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) สามารถจัดระเบียบเป็น [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrulescollection/) ซึ่งทำการใช้งาน [IFontFallBackRulesCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontfallbackrulescollection/) อินเทอร์เฟซ สามารถเพิ่มหรือเอากฎออกจากคอลเลกชันได้  

จากนั้นคอลเลกชันนี้สามารถส่งต่อไปยังเมธอด [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) ของคลาส [FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/) FontsManager ควบคุมแบบอักษรทั่วงานนำเสนอ  

แต่ละ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) มีเมธอด [get_FontsManager()](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_fontsmanager/) พร้อมอินสแตนซ์ของคลาส FontsManager ของตนเอง  

ต่อไปนี้เป็นตัวอย่างวิธีสร้างคอลเลกชันกฎแบบอักษรสำรองและกำหนดให้กับ FontsManager ของงานนำเสนอหนึ่ง:  

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

หลังจากที่ FontsManager ถูกเริ่มต้นด้วยคอลเลกชันแบบอักษรสำรอง แบบอักษรสำรองจะถูกนำไปใช้ระหว่างการเรนเดอร์งานนำเสนอ  

{{% alert color="info" %}} 
อ่านเพิ่มเติมเกี่ยวกับวิธี [เรนเดอร์งานนำเสนอด้วยแบบอักษรสำรอง](/slides/th/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **คำถามที่พบบ่อย**

### กฎแบบอักษรสำรองของฉันจะถูกฝังลงในไฟล์ PPTX และปรากฏใน PowerPoint หลังจากบันทึกหรือไม่?

ไม่. กฎแบบอักษรสำรองเป็นการตั้งค่าการเรนเดอร์เวลาเรียกใช้งาน; ไม่ได้ถูกซีเรียลไลซ์ลงในไฟล์ PPTX และจะไม่ปรากฏใน UI ของ PowerPoint.

### การสำรองแบบอักษรจะใช้กับข้อความภายใน SmartArt, WordArt, แผนภูมิ และตารางหรือไม่?

ใช่. กลไกการแทนที่ glyph เดียวกันถูกใช้กับข้อความใด ๆ ในวัตถุเหล่านี้.

### Aspose แจกจ่ายแบบอักษรใด ๆ มาพร้อมกับไลบรารีหรือไม่?

ไม่. คุณต้องเพิ่มและใช้แบบอักษรด้วยตัวเองและรับผิดชอบต่อการใช้งาน.

### สามารถใช้การแทนที่/การสับเปลี่ยนสำหรับแบบอักษรที่หายไปและการสำรองสำหรับ glyph ที่หายไปพร้อมกันได้หรือไม่?

ใช่. พวกมันเป็นขั้นตอนอิสระของกระบวนการแก้ไขแบบอักษรเดียวกัน: ก่อนแรกเอนจิ้นจะตรวจสอบความพร้อมของแบบอักษร ([replacement](/slides/th/cpp/font-replacement/)/[substitution](/slides/th/cpp/font-substitution/)) แล้วการสำรองจะเติมช่องว่างสำหรับ glyph ที่หายไปในแบบอักษรที่มีอยู่.