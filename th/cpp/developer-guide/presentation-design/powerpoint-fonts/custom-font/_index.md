---
title: ปรับแต่งฟอนต์ PowerPoint ใน C++
linktitle: ฟอนต์แบบกำหนดเอง
type: docs
weight: 20
url: /th/cpp/custom-font/
keywords:
- ฟอนต์
- ฟอนต์แบบกำหนดเอง
- ฟอนต์ภายนอก
- โหลดฟอนต์
- จัดการฟอนต์
- โฟลเดอร์ฟอนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ปรับแต่งฟอนต์ในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ C++ เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันบนอุปกรณ์ใดก็ได้"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถใช้ฟอนต์แบบกำหนดเองในงานนำเสนอได้โดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดฟอนต์จากโฟลเดอร์ที่กำหนดเอง, จัดหา ฟอนต์สำหรับงานนำเสนอเฉพาะผ่านแหล่งฟอนต์ระดับเอกสาร, หรือโหลดฟอนต์ภายนอกโดยตรงจากข้อมูลไบนารี

ฟอนต์ที่โหลดจะถูกใช้เมื่อทำการเรนเดอร์หรือส่งออกงานนำเสนอ เช่น ไปยัง PDF, รูปภาพ, และรูปแบบที่สนับสนุนอื่น ๆ สิ่งนี้ช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ในสภาพแวดล้อมต่าง ๆ บทความยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนต์ที่ Aspose.Slides ใช้และวิธีล้างแคชฟอนต์หลังจากทำงานกับฟอนต์ภายนอก

การลงทะเบียนฟอนต์แบบกำหนดเองสำหรับการเรนเดอร์แยกจากการฝังฟอนต์ลงในไฟล์ PPTX หากต้องการเก็บฟอนต์ภายในงานนำเสนอเอง ให้ใช้คุณลักษณะการฝังฟอนต์โดยชัดเจน

{{% alert color="info" %}} 

Aspose Slides ช่วยให้คุณโหลดฟอนต์เหล่านี้โดยใช้ [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* ฟอนต์ TrueType (.ttf) และ TrueType Collection (.ttc) ฟอนต์ ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType)

* ฟอนต์ OpenType (.otf) ฟอนต์ ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType)

{{% /alert %}}

## **โหลดฟอนต์ที่กำหนดเอง**

Aspose.Slides ช่วยให้คุณโหลดฟอนต์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ สิ่งนี้ส่งผลต่อผลลัพธ์การส่งออก—เช่น PDF, รูปภาพ, และรูปแบบที่สนับสนุนอื่น ๆ—เพื่อให้เอกสารที่ได้ดูสอดคล้องกันในทุกสภาพแวดล้อม ฟอนต์จะถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนต์
2. เรียกเมธอดสแตติก [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfonts/) เพื่อโหลดฟอนต์จากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/clearcache/) เพื่อล้างแคชฟอนต์

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดฟอนต์:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// กำหนดโฟลเดอร์ที่มีไฟล์ฟอนต์แบบกำหนดเอง.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// โหลดฟอนต์แบบกำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// เรนเดอร์/ส่งออกงานนำเสนอ (เช่น PDF, รูปภาพ หรือรูปแบบอื่น) โดยใช้ฟอนต์ที่โหลดมา.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// ล้างแคชฟอนต์หลังจากงานเสร็จสิ้น.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfonts/) จะเพิ่มโฟลเดอร์เพิ่มเติมไปยังเส้นทางการค้นหาฟอนต์, แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นฟอนต์ ฟอนต์จะถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางฟอนต์เริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/)

{{%/alert %}}

## **รับโฟลเดอร์ฟอนต์ที่กำหนดเอง**

Aspose.Slides มีเมธอด [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/getfontfolders/) เพื่อให้คุณค้นหาโฟลเดอร์ฟอนต์ เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์ฟอนต์ของระบบ

โค้ด C++ นี้แสดงวิธีใช้เมธอด [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// บรรทัดนี้แสดงโฟลเดอร์ที่ตรวจสอบสำหรับไฟล์ฟอนต์
// โฟลเดอร์เหล่านี้คือโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนต์ของระบบ
auto fontFolders = FontsLoader::GetFontFolders();
```

## **ระบุฟอนต์ที่กำหนดเองที่ใช้กับงานนำเสนอ**

Aspose.Slides มีคุณสมบัติ [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) เพื่อให้คุณกำหนดฟอนต์ภายนอกที่ใช้กับงานนำเสนอ

โค้ด C++ นี้แสดงวิธีใช้คุณสมบัติ [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //ทำงานกับงานนำเสนอ
    //CustomFont1, CustomFont2 รวมถึงฟอนต์จากโฟลเดอร์ assets\fonts & global\fonts และโฟลเดอร์ย่อยของพวกมันพร้อมใช้งานในงานนำเสนอ
}
```

## **จัดการฟอนต์จากภายนอก**

Aspose.Slides มีเมธอด [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfont/) เพื่อให้คุณโหลดฟอนต์ภายนอกเป็นอาร์เรย์ไบต์

โค้ด C++ นี้แสดงกระบวนการโหลดฟอนต์เป็นอาร์เรย์ไบต์:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// เส้นทางไปยังไดเรกทอรีเอกสาร
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **ถามตอบ**

### ฟอนต์แบบกำหนดเองมีผลต่อการส่งออกไปยังทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?

ใช่. ฟอนต์ที่เชื่อมต่อจะถูกใช้โดยตัวเรนเดอร์ในทุกรูปแบบการส่งออก

### ฟอนต์แบบกำหนดเองจะถูกฝังโดยอัตโนมัติในไฟล์ PPTX ที่ได้หรือไม่?

ไม่. การลงทะเบียนฟอนต์เพื่อการเรนเดอร์ไม่เท่ากับการฝังฟอนต์ลงใน PPTX หากคุณต้องการให้ฟอนต์อยู่ภายในไฟล์งานนำเสนอ, คุณต้องใช้ [embedding features](/slides/th/cpp/embedded-font/) อย่างชัดเจน

### ฉันสามารถควบคุมพฤติกรรม fallback เมื่อฟอนต์แบบกำหนดเองขาด glyph บางตัวได้หรือไม่?

ได้. ตั้งค่า [font substitution](/slides/th/cpp/font-substitution/), [replacement rules](/slides/th/cpp/font-replacement/), และ [fallback sets](/slides/th/cpp/fallback-font/) เพื่อกำหนดว่าฟอนต์ใดจะใช้เมื่อ glyph ที่ต้องการไม่พบ

### ฉันสามารถใช้ฟอนต์ในคอนเทนเนอร์ Linux/Docker ได้โดยไม่ต้องติดตั้งทั่วระบบหรือไม่?

ได้. ชี้ไปยังโฟลเดอร์ฟอนต์ของคุณเองหรือโหลดฟอนต์จากอาร์เรย์ไบต์ วิธีนี้จะลบการพึ่งพาโฟลเดอร์ฟอนต์ของระบบในอิมเมจคอนเทนเนอร์

### เรื่องลิขสิทธิ์ล่ะ—ฉันสามารถฝังฟอนต์แบบกำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?

คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ของฟอนต์ ข้อกำหนดแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้เชิงพาณิชย์ โปรดตรวจสอบ EULA ของฟอนต์ก่อนเผยแพร่ผลลัพธ์