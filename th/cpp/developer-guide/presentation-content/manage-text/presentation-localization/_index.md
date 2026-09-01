---
title: ทำอัตโนมัติการแปลภาษาในงานนำเสนอด้วย C++
linktitle: การแปลภาษาในงานนำเสนอ
type: docs
weight: 100
url: /th/cpp/presentation-localization/
keywords:
- เปลี่ยนภาษา
- ตรวจการสะกด
- ปิดการตรวจการสะกด
- ภาษาการพิสูจน์
- รหัสภาษา
- ข้อความหลายภาษา
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "กำหนดภาษาการพิสูจน์สำหรับข้อความงานนำเสนอ PowerPoint และ OpenDocument ใน C++ ด้วย Aspose.Slides รวมถึงค่าเริ่มต้นและย่อหน้าหลายภาษา."
---
## **ภาพรวม**

Aspose.Slides for C++ ให้คุณกำหนดเมทาเดต้าการพิสูจน์สำหรับส่วนข้อความแต่ละส่วน ใช้ [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_languageid/) เพื่อระบุภาษาการพิสูจน์, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_spellcheck/) เพื่อเปิดหรือปิดการตรวจการสะกด, และ [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_proofdisabled/) เพื่อควบคุมสถานะการไม่พิสูจน์แบบกว้างกว่า เนื่องจากการตั้งค่าเหล่านี้ใช้ในระดับส่วน, ย่อหน้าเดียวสามารถมีหลายภาษาและกฎการพิสูจน์ที่แตกต่างกันได้.

บทความนี้อธิบายวิธีการกำหนดภาษาสำหรับข้อความเฉพาะ, ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่ด้วย [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), สร้างย่อหน้าหลายภาษา, เลือกระหว่าง `SpellCheck` และ `ProofDisabled`, และรักษาการตั้งค่าเดิมเมื่ใช้ [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/joinportionswithsameformatting/). คุณสมบัติเหล่านี้เก็บเมทาเดต้าสำหรับแอปพลิเคชันพรีเซนเทชัน; พวกมันไม่ได้แปลข้อความ, ทำการตรวจการสะกดโดยอาศัยพจนานุกรม, หรือคืนคำที่สะกดผิด.

## **ตั้งค่าภาษาการพิสูจน์สำหรับข้อความ**

สร้างหรือโหลด [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/), เข้าถึงส่วนข้อความที่ต้องการผ่าน [IPortion::get_PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/get_portionformat/), และกำหนดรหัสภาษาของมัน ตัวอย่างต่อไปนี้สร้างรูปทรง, ตั้งค่าอังกฤษแบบบริติชเป็นภาษาการพิสูจน์, และบันทึกผลลัพธ์ด้วย [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งค่าภาษาเริ่มต้นสำหรับข้อความใหม่**

ใช้ [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) เพื่อระบุภาษาการพิสูจน์ที่ Aspose.Slides จะกำหนดให้กับข้อความที่สร้างใหม่ การตั้งค่านี้มีประโยชน์เมื่อข้อความใหม่ส่วนใหญ่หรือทั้งหมดในพรีเซนเทชันใช้ภาษาเดียวกัน มันจะไม่เปลี่ยนเมทาเดต้าภาษาของข้อความที่มีการกำหนดภาษาชัดเจนอยู่แล้ว.

ตัวอย่างต่อไปนี้สร้างพรีเซนเทชันที่ข้อความใหม่ใช้กฎการพิสูจน์ของภาษาเยอรมัน:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ใช้หลายภาษาในย่อหน้าเดียว**

[IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/) มีคอลเลกชันของส่วนข้อความ สร้าง [Portion](https://reference.aspose.com/slides/th/cpp/aspose.slides/portion/) แยกกันสำหรับแต่ละภาษาและกำหนด `LanguageId` ของแต่ละส่วนอย่างอิสระ.

ตัวอย่างนี้สร้างย่อหน้าหนึ่งที่มีส่วนภาษาอังกฤษและภาษาฝรั่งเศส:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เปิดหรือปิดการตรวจการสะกดสำหรับส่วนข้อความแต่ละส่วน**

[IPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportionformat/) สืบทอดคุณสมบัติข้อความทั่วไปที่กำหนดโดย [IBasePortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/). เข้าถึงรูปแบบของส่วนผ่าน [IPortion::get_PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/get_portionformat/) แล้วเรียก [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_spellcheck/) เพื่อควบคุมว่าตัวแอปพรีเซนเทชันจะตรวจการสะกดของส่วนนั้นหรือไม่ ค่าปริยายคือ `false`: `true` จะเปิดการตรวจการสะกด, ขณะที่ `false` จะปิด.

การตั้งค่านี้ใช้กับส่วนข้อความแต่ละส่วน ส่วนต่าง ๆ ภายในย่อหน้าเดียวกันจึงสามารถใช้ค่าที่แตกต่างกันได้ [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_languageid/) และ `SpellCheck` มีจุดประสงค์เสริมกัน: `LanguageId` ระบุภาษาการพิสูจน์, ส่วน `SpellCheck` กำหนดว่าการตรวจการสะกดอนุญาตหรือไม่สำหรับส่วนนั้น.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_proofdisabled/) ยังควบคุมการพิสูจน์ด้วย แต่แทนสถานะ "ไม่ทำการพิสูจน์" ที่กว้างกว่าด้วย [NullableBool](https://reference.aspose.com/slides/th/cpp/aspose.slides/nullablebool/). ใช้ `SpellCheck` เมื่อคุณต้องการสวิตช์ Boolean แบบตรงสำหรับการตรวจการสะกด ใช้ `ProofDisabled` เมื่อคุณต้องการเก็บหรือควบคุมเมทาเดต้า "ไม่ทำการพิสูจน์" ของพรีเซนเทชันอย่างชัดเจน รวมถึงสถานะ `NullableBool::NotDefined` ของมัน หากคุณตั้งค่าทั้งสองคุณสมบัติ ให้ค่าตรงกัน; อย่าใช้ `SpellCheck = true` ร่วมกับ `ProofDisabled = NullableBool::True`.

คุณสมบัติเหล่านี้กำหนดเมทาเดต้าการพิสูจน์ที่ใช้โดย PowerPoint และแอปพลิเคชันพรีเซนเทชันอื่น ๆ Aspose.Slides ไม่ได้ใช้เพื่อทำการตรวจการสะกดด้วยพจนานุกรมหรือคืนรายการคำที่สะกดผิด.

ตัวอย่างสมบูรณ์ต่อไปนี้สร้างพรีเซนเทชันต้นเข้า, โหลดมัน, กำหนดการตั้งค่าการตรวจการสะกดและภาษาการพิสูจน์ที่ต่างกันให้กับสองส่วนในย่อหน้าเดียว, บันทึกผลลัพธ์, เปิดใหม่อีกครั้ง, และตรวจสอบค่าที่เก็บไว้:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/joinportionswithsameformatting/) รวมส่วนที่อยู่ติดกันที่มีรูปแบบเดียวกัน ความแตกต่างเพียงอย่างเดียวใน `SpellCheck` จะไม่ทำให้ส่วนเหล่านั้นแยกกัน; หลังจากรวมแล้ว ส่วนที่ได้จะคงค่าของ `SpellCheck` ของส่วนแรก หากส่วนต้องการการตั้งค่าการตรวจการสะกดที่ต่างกัน ให้เรียก `JoinPortionsWithSameFormatting` ก่อนกำหนดค่าดังกล่าว, หรือสำรวจขอบเขตของส่วนที่ได้และตั้งค่าใหม่ภายหลัง ส่วนที่มีค่า `LanguageId` ต่างกันจะคงแยกกันเนื่องจากรูปแบบภาษาการพิสูจน์แตกต่างกัน.

## **คำถามที่พบบ่อย**

**รหัสภาษาแปลข้อความหรือไม่?**

ไม่. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_languageid/) เก็บเมทาเดต้าการพิสูจน์สำหรับการสะกดและไวยากรณ์; มันไม่เปลี่ยนเนื้อหาข้อความ. แปลข้อความแยกต่างหาก, แล้วจึงตั้งค่ารหัสภาษาที่เหมาะสมสำหรับแต่ละส่วนที่แปล.

**ภาษาการพิสูจน์ควบคุมฟอนต์, การคั่นคำ, หรือการตัดบรรทัดหรือไม่?**

ไม่. รหัสภาษาถูกใช้เพื่อการพิสูจน์เท่านั้น การแสดงผลและการจัดวางข้อความขึ้นอยู่กับ [ฟอนต์](/slides/th/cpp/powerpoint-fonts/), ระบบการเขียน, และการตั้งค่ากรอบข้อความ. เพื่อให้การแสดงผลเชื่อถือได้ ให้จัดเตรียมฟอนต์ที่ต้องการ, กำหนด [การแทนที่ฟอนต์](/slides/th/cpp/font-substitution/), หรือ [ฝังฟอนต์](/slides/th/cpp/embedded-font/) ในพรีเซนเทชัน.

**ย่อหน้าเดียวสามารถใช้หลายภาษาการพิสูจน์ได้หรือไม่?**

ใช่. กำหนดแต่ละภาษาให้กับส่วนแยกต่างหาก, ตามที่แสดงในตัวอย่างย่อหน้าหลายภาษา.

**ควรใช้ `DefaultTextLanguage` หรือ `LanguageId`?**

ใช้ [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) เมื่อคุณต้องการค่าเริ่มต้นสำหรับข้อความที่สร้างใหม่. ใช้ [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_languageid/) เมื่อส่วนใดส่วนหนึ่งต้องการภาษาการพิสูจน์ที่ระบุชัดเจนหรือเมื่อย่อหน้ามีหลายภาษา.