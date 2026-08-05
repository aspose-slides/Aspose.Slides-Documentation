---
title: ปรับแต่งฟอนต์ PowerPoint ด้วย C++
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
description: "ปรับแต่งฟอนต์ในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ C++ เพื่อให้การนำเสนอของคุณคมชัดและสม่ำเสมอในทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณใช้ฟอนต์แบบกำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งฟอนต์เหล่านั้นบนระบบปฏิบัติการ คุณสามารถโหลดฟอนต์จากโฟลเดอร์ที่กำหนดเอง ให้ฟอนต์สำหรับงานนำเสนอเฉพาะผ่านแหล่งฟอนต์ระดับเอกสาร หรือโหลดฟอนต์ภายนอกโดยตรงจากข้อมูลไบต์ได้

ฟอนต์ที่โหลดจะถูกใช้เมื่อทำการแสดงผลหรือส่งออกงานนำเสนอ เช่นเป็น PDF, รูปภาพ, และรูปแบบที่รองรับอื่น ๆ สิ่งนี้ช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ในสภาพแวดล้อมต่าง ๆ บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนต์ที่ Aspose.Slides ใช้และวิธีลบแคชฟอนต์หลังจากทำงานกับฟอนต์ภายนอก

การลงทะเบียนฟอนต์แบบกำหนดเองสำหรับการแสดงผลเป็นกระบวนการแยกต่างหากจากการฝังฟอนต์ลงในไฟล์ PPTX หากต้องการเก็บฟอนต์ภายในงานนำเสนอเอง ให้ใช้คุณสมบัติการฝังฟอนต์อย่างชัดเจน

{{% alert color="primary" %}} 

Aspose Slides ช่วยให้คุณโหลดฟอนต์เหล่านี้โดยใช้ [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* ฟอนต์ TrueType (.ttf) และ TrueType Collection (.ttc) ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType).

* ฟอนต์ OpenType (.otf) ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **โหลดฟอนต์แบบกำหนดเอง**

Aspose.Slides ช่วยให้คุณโหลดฟอนต์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ สิ่งนี้ส่งผลต่อผลลัพธ์การส่งออก เช่น PDF, รูปภาพ, และรูปแบบที่รองรับอื่น ๆ ทำให้เอกสารที่ได้ดูสม่ำเสมอในสภาพแวดล้อมต่าง ๆ ฟอนต์จะถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนต์
2. เรียกเมธอด static [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfonts/) เพื่อโหลดฟอนต์จากโฟลเดอร์เหล่านั้น
3. โหลดและแสดงผล/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/clearcache/) เพื่อลบแคชฟอนต์

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดฟอนต์:

```cpp
// กำหนดโฟลเดอร์ที่มีไฟล์ฟอนต์แบบกำหนดเอง.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Load custom fonts from the specified folders.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// เรนเดอร์/ส่งออกงานนำเสนอ (เช่น PDF, รูปภาพ หรือรูปแบบอื่น) โดยใช้ฟอนต์ที่โหลดไว้.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// ลบแคชฟอนต์หลังจากทำงานเสร็จ.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

FontsLoader::loadExternalFonts เพิ่มโฟลเดอร์เพิ่มเติมไปยังเส้นทางค้นหาฟอนต์ แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นฟอนต์
ฟอนต์จะถูกเริ่มต้นตามลำดับต่อไปนี้:

1. เส้นทางฟอนต์เริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **รับโฟลเดอร์ฟอนต์แบบกำหนดเอง**

Aspose.Slides มี [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/getfontfolders/) เพื่อให้คุณค้นหาโฟลเดอร์ฟอนต์ เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์ฟอนต์ของระบบ

โค้ด C++ ต่อไปนี้จะแสดงวิธีใช้เมธอด [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/getfontfolders/) :

``` cpp
// บรรทัดนี้จะแสดงโฟลเดอร์ที่ตรวจสอบสำหรับไฟล์ฟอนต์.
// เหล่านั้นเป็นโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนต์ของระบบ.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **ระบุฟอนต์แบบกำหนดเองที่ใช้กับงานนำเสนอ**

Aspose.Slides มี property [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) เพื่อให้คุณระบุฟอนต์ภายนอกที่จะใช้กับงานนำเสนอ

โค้ด C++ ต่อไปนี้จะแสดงวิธีใช้ property [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) :

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //ทำงานกับงานนำเสนอ
    //CustomFont1, CustomFont2 รวมถึงฟอนต์จากโฟลเดอร์ assets\fonts & global\fonts และโฟลเดอร์ย่อยของพวกมันสามารถใช้ในงานนำเสนอได้
}
```

## **จัดการฟอนต์จากภายนอก**

Aspose.Slides มีเมธอด [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfont/) เพื่อให้คุณโหลดฟอนต์ภายนอกเป็นอาร์เรย์ไบต์

โค้ด C++ นี้แสดงกระบวนการโหลดฟอนต์เป็นอาร์เรย์ไบต์:

```cpp
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

**ฟอนต์แบบกำหนดเองมีผลต่อการส่งออกเป็นรูปแบบทั้งหมดหรือไม่ (PDF, PNG, SVG, HTML)?**

ใช่ ฟอนต์ที่เชื่อมต่อจะถูกใช้โดยตัวเรนเดอร์ในทุกรูปแบบการส่งออก

**ฟอนต์แบบกำหนดเองจะถูกฝังโดยอัตโนมัติในไฟล์ PPTX ที่ได้หรือไม่?**

ไม่ การลงทะเบียนฟอนต์เพื่อการแสดงผลไม่เท่ากับการฝังฟอนต์ลงใน PPTX หากคุณต้องการให้ฟอนต์อยู่ในไฟล์งานนำเสนอ คุณต้องใช้ [embedding features](/slides/th/cpp/embedded-font/) อย่างชัดเจน

**ฉันสามารถควบคุมพฤติกรรม fallback เมื่อฟอนต์แบบกำหนดเองไม่มี glyph บางตัวได้หรือไม่?**

ได้ คุณสามารถกำหนดค่า [font substitution](/slides/th/cpp/font-substitution/), [replacement rules](/slides/th/cpp/font-replacement/), และ [fallback sets](/slides/th/cpp/fallback-font/) เพื่อระบุชัดเจนว่าฟอนต์ใดจะใช้เมื่อ glyph ที่ร้องขอไม่มีอยู่

**ฉันสามารถใช้ฟอนต์ในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งทั่วระบบได้หรือไม่?**

ได้ เพียงชี้ไปที่โฟลเดอร์ฟอนต์ของคุณเองหรือโหลดฟอนต์จากอาร์เรย์ไบต์ สิ่งนี้จะขจัดการพึ่งพาโฟลเดอร์ฟอนต์ของระบบในอิมเมจของคอนเทนเนอร์

**ส่วนเรื่องลิขสิทธิ์—ฉันสามารถฝังฟอนต์แบบกำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?**

คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ของฟอนต์ ข้อกำหนดอาจแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้เชิงพาณิชย์ ควรตรวจสอบ EULA ของฟอนต์ก่อนเผยแพร่ผลลัพธ์