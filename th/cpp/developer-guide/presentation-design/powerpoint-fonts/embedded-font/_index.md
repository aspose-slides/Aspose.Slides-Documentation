---
title: ฝังฟอนต์ในงานนำเสนอด้วย C++
linktitle: ฟอนต์ที่ฝังไว้
type: docs
weight: 40
url: /th/cpp/embedded-font/
keywords:
- เพิ่มฟอนต์
- ฝังฟอนต์
- การฝังฟอนต์
- ดึงฟอนต์ที่ฝังไว้
- เพิ่มฟอนต์ที่ฝังไว้
- ลบฟอนต์ที่ฝังไว้
- บีบอัดฟอนต์ที่ฝังไว้
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "จัดการฟอนต์ที่ฝังไว้ใน PowerPoint ด้วย Aspose.Slides สำหรับ C++. เพิ่ม ดึง ลบ และบีบอัดฟอนต์ เพื่อรักษาการแสดงผลของข้อความและลดขนาดไฟล์."
---
## **บทนำ**

การฝังฟอนต์จะเก็บข้อมูลฟอนต์ไว้ภายในไฟล์งานนำเสนอ PowerPoint เมื่อโปรแกรมแสดงผลรองรับฟอนต์ที่ฝังไว้ มันสามารถแสดงข้อความโดยใช้ฟอนต์เหล่านั้นได้แม้ว่าจะไม่ได้ติดตั้งบนระบบเป้าหมาย ซึ่งช่วยรักษาการแบ่งบรรทัด การเว้นระยะข้อความ และการจัดวางสไลด์

Aspose.Slides for C++ ให้คุณดึงข้อมูล เพิ่ม และลบฟอนต์ที่ฝังไว้ผ่านเมธอด [Presentation::get_FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_fontsmanager/) ของ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/). คุณยังสามารถลดขนาดข้อมูลฟอนต์ที่ฝังไว้โดยการลบอักขระที่งานนำเสนอไม่ได้ใช้

ตัวอย่างต่อไปนี้ทำงานกับไฟล์ PPTX ก่อนที่จะฝังฟอนต์ ให้ตรวจสอบว่าข้อมูลฟอนต์พร้อมใช้งานกับ Aspose.Slides และสัญญาอนุญาตของฟอนต์อนุญาตให้ฝังได้หรือไม่

## **ดึงและลบฟอนต์ที่ฝังไว้**

ใช้ [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) เพื่อแสดงรายการฟอนต์ที่เก็บในงานนำเสนอ หากต้องการลบฟอนต์ ให้ส่งฟอนต์จากรายการนั้นไปยัง [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), แล้วบันทึกงานนำเสนอ

ตัวอย่างต่อไปนี้จะแสดงรายการฟอนต์ที่ฝังไว้ใน `EmbeddedFonts.pptx` และลบ Calibri หากมีอยู่:
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

การลบฟอนต์ที่ฝังไว้จะลบข้อมูลฟอนต์ที่เก็บไว้; มันไม่ได้เปลี่ยนฟอนต์ที่กำหนดให้กับข้อความ หากฟอนต์ติดตั้งบนระบบเป้าหมาย ข้อความยังคงใช้ฟอนต์นั้นได้ มิฉะนั้น การเรนเดอร์อาจต้องอาศัย [font substitution](/slides/th/cpp/font-substitution/) ซึ่งอาจกระทบต่อการจัดวาง

## **ตรวจสอบข้อมูลฟอนต์และสิทธิ์การฝัง**

ใช้ส่วนติดต่อ [IFontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/) เพื่อตรวจสอบฟอนต์ก่อนทำการฝัง เรียก [IFontsManager::GetFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/getfonts/) เพื่อดึงฟอนต์ที่ใช้ในงานนำเสนอ สำหรับแต่ละฟอนต์ ส่งอ็อบเจกต์ [IFontData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontdata/) และค่า [FontStyleType](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontstyletype/) ที่ต้องการไปยัง [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/getfontbytes/). เมธอดจะคืนค่าข้อมูลไบต์ของสไตล์ฟอนต์นั้น หรือ `nullptr` เมื่อฟอนต์หรือสไตล์ที่ขอไม่ได้อยู่ อย่าส่งผลลัพธ์ `nullptr` ไปยัง [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/) เพราะเมธอดนี้ต้องการอาเรย์ไบต์

[EmbeddingLevel](https://reference.aspose.com/slides/th/cpp/aspose.slides/embeddinglevel/) เป็นการกำหนดค่าแบบ flags ที่รายงานข้อจำกัดการฝังที่เก็บอยู่ในฟอนต์:

- `Installable` อนุญาตให้ฝังและทำการติดตั้งถาวรบนระบบอื่นได้ ตามเงื่อนไขของสัญญาอนุญาตฟอนต์
- `Restricted` ห้ามฝังฟอนต์ เว้นแต่จะได้รับอนุญาตจากเจ้าของลิขสิทธิ์ของฟอนต์ เมื่อเป็นแฟล็กสิทธิ์การใช้งานเพียงอย่างเดียว
- `PreviewPrint` อนุญาตให้ใช้ชั่วคราวสำหรับการดูและพิมพ์; เอกสารที่มีฟอนต์ต้องเป็นแบบอ่านอย่างเดียว
- `Editable` อนุญาตให้ใช้ชั่วคราวและให้เอกสารสามารถแก้ไขและบันทึกได้
- `NoSubsetting` เป็นข้อจำกัดเพิ่มเติมที่ห้ามฝังส่วนย่อยของ glyphs; หากมีแฟล็กนี้ต้องฝังอักขระทั้งหมด
- `BitmapOnly` เป็นข้อจำกัดเพิ่มเติมที่อนุญาตให้ฝังเฉพาะ bitmap strikes เท่านั้น ไม่ใช่ข้อมูลโครงร่าง; หากฟอนต์ไม่มี bitmap strikes จะไม่สามารถฝังได้

ค่าสี่ค่าตัวแรกอธิบายสิทธิ์การใช้งาน ในขณะที่ `NoSubsetting` และ `BitmapOnly` สามารถรวมกับค่าเหล่านั้นได้ ตรวจสอบตัวแปรด้วยการดำเนินการบิตเวิร์ด เนื่องจาก `Installable` มีค่าเป็นศูนย์ ให้ทำการมาสก์บิตสิทธิ์การใช้งานและเปรียบเทียบผลลัพธ์กับ `Installable`. ฟอนต์ปัจจุบันควรตั้งบิตสิทธิ์การใช้งานไม่เกินหนึ่งบิต เพื่อความเข้ากันได้กับฟอนต์เก่าที่ตั้งหลายบิต ตัวช่วยด้านล่างจะเลือกสิทธิ์ที่ผ่อนปรนที่สุด: `Editable`, ตามด้วย `PreviewPrint`, ตามด้วย `Restricted`

ตัวอย่างต่อไปนี้ตรวจสอบข้อมูลแบบปกติ, หนา, เอน และหนาเอียงของฟอนต์ทุกตัวที่คืนค่าโดย `GetFonts`. มันจะข้ามสไตล์ที่ไม่มี, ฟอนต์ที่มีข้อจำกัด, ฟอนต์ bitmap‑only, ฟอนต์ที่จำกัดการใช้งานเพียง preview และ print เนื่องจากผลลัพธ์ยังคงแก้ไขได้, และฟอนต์ที่ฝังไว้แล้ว หากสไตล์ใดมี `NoSubsetting` จะฝังอักขระทั้งหมดของตระกูลฟอนต์นั้น
```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การตรวจสอบนี้รายงานข้อจำกัดที่เข้ารหัสในแต่ละไฟล์ฟอนต์ มันไม่ได้ให้สิทธิ์การใช้งาน, ยืนยันว่าคุณได้ฟอนต์อย่างถูกกฎหมาย, หรือแทนที่การตรวจสอบสัญญาอนุญาตของฟอนต์ก่อนแจกจ่ายสำเนาที่ฝังไว้

## **เพิ่มฟอนต์ที่ฝังไว้**

ใช้ [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/addembeddedfont/) เพื่อฝังฟอนต์ การโอเวอร์โหลดของเมธอดรับอ็อบเจกต์ [IFontData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontdata/) หรืออาเรย์ไบต์ที่มีข้อมูลฟอนต์ ค่าตัวเลือก [EmbedFontCharacters](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/embedfontcharacters/) ควบคุมว่ารวมอักขระใดบ้าง:

- [All](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/embedfontcharacters/) ฝังอักขระทั้งหมดในฟอนต์ ใช้ตัวเลือกนี้เมื่อผู้รับต้องการแก้ไขงานนำเสนอและป้อนข้อความใหม่
- [OnlyUsed](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/embedfontcharacters/) ฝังเฉพาะอักขระที่ใช้ในงานนำเสนอเพื่อลดขนาดไฟล์ เลือกตัวเลือกนี้สำหรับงานนำเสนอที่เสร็จสมบูรณ์และมุ่งเน้นการดูเท่านั้น

ตัวอย่างต่อไปนี้ใช้ [IFontsManager::GetFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/getfonts/) เพื่อดึงฟอนต์ที่ใช้ใน `Fonts.pptx` และฝังฟอนต์ที่ยังไม่ได้ฝัง ฟอนต์ที่ต้องเพิ่มต้องพร้อมใช้งานบนเครื่องที่รันโค้ด ฟอนต์ที่ฝังอยู่แล้วจะคงชุดอักขระเดิมไว้
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **บีบอัดฟอนต์ที่ฝังไว้**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) ลดข้อมูลฟอนต์ที่ฝังไว้โดยการลบอักขระที่ไม่ได้ใช้ มันทำงานกับฟอนต์ที่ฝังไว้แล้ว ดังนั้นการลดขนาดขึ้นอยู่กับจำนวนข้อมูลฟอนต์ที่ไม่ได้ใช้ในงานนำเสนอ

ตัวอย่างต่อไปนี้บีบอัดฟอนต์ใน `EmbeddedFonts.pptx` และบันทึกผลลัพธ์เป็นไฟล์แยก
```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

เก็บไฟล์ต้นฉบับไว้หากผู้รับอาจต้องเพิ่มข้อความในภายหลัง อักขระที่ถูกลบระหว่างการบีบอัดจะไม่สามารถเข้าถึงได้จากฟอนต์ที่ฝังไว้ แม้คุณจะฝังอักขระทั้งหมดไว้ตั้งแต่แรก

## **คำถามที่พบบ่อย**

**How can I check whether an embedded font will still be substituted during rendering?**  
เรียก [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/getsubstitutions/) ในสภาพแวดล้อมที่คุณเรนเดอร์งานนำเสนอเพื่อดูฟอนต์ใดบ้างที่ Aspose.Slides จะเปลี่ยน นอกจากนี้ตรวจสอบการตั้งค่า [font substitution](/slides/th/cpp/font-substitution/) และกฎ [font fallback](/slides/th/cpp/fallback-font/) ด้วย ฟอลแบ็กจัดการอักขระที่หายไป ดังนั้นการฝังฟอนต์ไม่ได้แก้ปัญหาอักขระที่ฟอนต์นั้นเองไม่มี

**Should I embed common fonts such as Arial and Calibri?**  
ให้พิจารณาตามสภาพแวดล้อมเป้าหมาย หากฟอนต์ที่ต้องการมีอยู่บนทุกเครื่องที่เปิดหรือเรนเดอร์งานนำเสนอ การฝังอาจเพิ่มขนาดไฟล์โดยไม่จำเป็น หากผู้รับหรือเซิร์ฟเวอร์อาจไม่มีฟอนต์เหล่านั้น การฝังฟอนต์จะช่วยรักษารูปแบบตามที่ตั้งใจได้ แต่ต้องตรวจสอบว่าสัญญาอนุญาตของฟอนต์อนุญาตให้ฝังได้หรือไม่