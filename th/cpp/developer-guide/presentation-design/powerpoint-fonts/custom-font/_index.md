---
title: "ปรับแต่งแบบอักษร PowerPoint ใน C++"
linktitle: "แบบอักษรที่กำหนดเอง"
type: docs
weight: 20
url: /th/cpp/custom-font/
keywords:
- แบบอักษร
- แบบอักษรที่กำหนดเอง
- แบบอักษรภายนอก
- โหลดแบบอักษร
- จัดการแบบอักษร
- โฟลเดอร์แบบอักษร
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ปรับแต่งแบบอักษรในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ C++ เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันในทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides ให้คุณใช้แบบอักษรที่กำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดแบบอักษรจากโฟลเดอร์ที่กำหนดเอง, ระบุแบบอักษรสำหรับงานนำเสนอเฉพาะผ่านแหล่งแบบอักษรระดับเอกสาร, หรือโหลดแบบอักษรภายนอกโดยตรงจากข้อมูลไบต์

แบบอักษรที่โหลดจะถูกใช้เมื่อเรนเดอร์หรือส่งออกงานนำเสนอ เช่น เป็น PDF, รูปภาพ, และรูปแบบที่รองรับอื่น ๆ ซึ่งช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ในสภาพแวดล้อมต่าง ๆ บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์แบบอักษรที่ Aspose.Slides ใช้และวิธีล้างแคชแบบอักษรหลังจากทำงานกับแบบอักษรภายนอก

การลงทะเบียนแบบอักษรเพื่อการเรนเดอร์แยกจากการฝังแบบอักษรลงในไฟล์ PPTX หากต้องการให้แบบอักษรอยู่ภายในงานนำเสนอเอง ให้ใช้คุณสมบัติการฝังแบบอักษรโดยเจาะจง

ธีมของงานนำเสนอสามารถอ้างอิงฟอนต์ฟาเมิลี่ต่าง ๆ สำหรับระบบเขียนที่แตกต่างกัน การแมปเหล่านี้บันทึกชื่อแบบอักษรแต่ไม่ทำการติดตั้งหรือโหลดไฟล์แบบอักษร ดูที่ [แบบอักษรธีมเฉพาะสคริปต์](/slides/th/cpp/script-specific-font-mappings/) เพื่อจัดการการแมป และใช้ตัวเลือกการโหลดด้านล่างเพื่อให้แบบอักษรที่อ้างอิงพร้อมใช้งานสำหรับการเรนเดอร์ที่สอดคล้องกัน

{{% alert color="info" title="หมายเหตุ" %}}

Aspose Slides ให้คุณโหลดแบบอักษรเหล่านี้โดยใช้ [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType (.ttf) และ TrueType Collection (.ttc) แบบอักษร ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType)
* OpenType (.otf) แบบอักษร ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType)

{{% /alert %}}

## **โหลดแบบอักษรที่กำหนดเอง**

Aspose.Slides ให้คุณโหลดแบบอักษรที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ ซึ่งส่งผลต่อผลลัพธ์การส่งออก เช่น PDF, รูปภาพ, และรูปแบบที่รองรับอื่น ๆ เพื่อให้เอกสารที่ได้มีลักษณะคงที่ในแต่ละสภาพแวดล้อม แบบอักษรจะถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์แบบอักษร
2. เรียกเมธอดสแตติก [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfonts/) เพื่อโหลดแบบอักษรจากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/clearcache/) เพื่อล้างแคชแบบอักษร

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดแบบอักษร:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// กำหนดโฟลเดอร์ที่มีไฟล์แบบอักษรแบบกำหนดเอง.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// โหลดแบบอักษรที่กำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// เรนเดอร์/ส่งออกงานนำเสนอ (เช่น เป็น PDF รูปภาพ หรือรูปแบบอื่น) โดยใช้แบบอักษรที่โหลดแล้ว.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// ล้างแคชแบบอักษรหลังจากทำงานเสร็จ.
FontsLoader::ClearCache();
```

{{% alert color="info" title="หมายเหตุ" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfonts/) เพิ่มโฟลเดอร์เพิ่มเติมในเส้นทางค้นหาแบบอักษร แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นแบบอักษร
แบบอักษรจะเริ่มต้นตามลำดับนี้:

1. เส้นทางแบบอักษรของระบบปฏิบัติการเริ่มต้น
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/)

{{%/alert %}}

## **รับโฟลเดอร์แบบอักษรที่กำหนดเอง**

Aspose.Slides มี [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/getfontfolders/) เพื่อให้คุณค้นหาโฟลเดอร์แบบอักษร เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์แบบอักษรของระบบ

โค้ด C++ ต่อไปนี้แสดงวิธีใช้เมธอด [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/getfontfolders/) :

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// บรรทัดนี้แสดงโฟลเดอร์ที่ถูกตรวจสอบสำหรับไฟล์แบบอักษร.
// นั่นคือโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์แบบอักษรของระบบ.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **ระบุแบบอักษรที่กำหนดเองสำหรับงานนำเสนอ**

Aspose.Slides มีคุณสมบัติ [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) เพื่อให้คุณระบุแบบอักษรภายนอกที่ใช้ร่วมกับงานนำเสนอ

โค้ด C++ นี้แสดงวิธีใช้คุณสมบัติ [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) :

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
    //CustomFont1, CustomFont2 รวมถึงแบบอักษรจากโฟลเดอร์ assets\fonts และ global\fonts รวมทั้งโฟลเดอร์ย่อยของพวกมันสามารถใช้ได้ในงานนำเสนอ
}
```

## **จัดการแบบอักษรจากภายนอก**

Aspose.Slides มีเมธอด [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfont/) เพื่อให้คุณโหลดแบบอักษรภายนอกเป็นอาร์เรย์ไบต์

โค้ด C++ ต่อไปนี้สาธิตกระบวนการโหลดแบบอักษรเป็นอาร์เรย์ไบต์:

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

## **คำถามที่พบบ่อย**

### แบบอักษรที่กำหนดเองมีผลต่อการส่งออกไปยังทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?

ใช่ แบบอักษรที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก

### แบบอักษรที่กำหนดเองจะถูกฝังอัตโนมัติใน PPTX ที่สร้างขึ้นหรือไม่?

ไม่ การลงทะเบียนแบบอักษรเพื่อการเรนเดอร์ไม่เท่ากับการฝังลงใน PPTX หากต้องการให้แบบอักษรอยู่ในไฟล์งานนำเสนอ ต้องใช้ [คุณสมบัติการฝัง](/slides/th/cpp/embedded-font/)

### สามารถกำหนดพฤติกรรม fallback เมื่อแบบอักษรที่กำหนดเองไม่มี glyph บางตัวได้หรือไม่?

ใช่ ตั้งค่า [การแทนที่แบบอักษร](/slides/th/cpp/font-substitution/), [กฎการแทนที่](/slides/th/cpp/font-replacement/), และ [ชุด fallback](/slides/th/cpp/fallback-font/) เพื่อระบุแบบอักษรที่ใช้เมื่อ glyph ที่ต้องการไม่มีอยู่

### สามารถใช้แบบอักษรในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งในระบบได้หรือไม่?

ใช่ ให้ชี้ไปยังโฟลเดอร์แบบอักษรของคุณเองหรือโหลดแบบอักษรจากอาร์เรย์ไบต์ วิธีนี้จะไม่พึ่งพาโฟลเดอร์แบบอักษรของระบบในภาพคอนเทนเนอร์

### เรื่องลิขสิทธิ์—สามารถฝังแบบอักษรที่กำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?

คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ของแบบอักษร เงื่อนไขอาจแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้เพื่อการค้า ควรตรวจสอบ EULA ของแบบอักษรก่อนเผยแพร่ผลลัพธ์