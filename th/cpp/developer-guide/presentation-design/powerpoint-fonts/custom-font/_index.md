---
title: ปรับแต่งแบบอักษร PowerPoint ใน C++
linktitle: แบบอักษรแบบกำหนดเอง
type: docs
weight: 20
url: /th/cpp/custom-font/
keywords:
- ฟอนต์
- ฟอนต์กำหนดเอง
- ฟอนต์ภายนอก
- โหลดฟอนต์
- จัดการฟอนต์
- โฟลเดอร์ฟอนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ปรับแต่งแบบอักษรในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ C++ เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันบนอุปกรณ์ใดก็ได้"
---
## **ภาพรวม**

Aspose.Slides ให้คุณใช้ฟอนต์แบบกำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดฟอนต์จากโฟลเดอร์ที่กำหนดเอง ให้ฟอนต์สำหรับงานนำเสนอเฉพาะผ่านแหล่งฟอนต์ระดับเอกสาร หรือโหลดฟอนต์ภายนอกโดยตรงจากข้อมูลไบนารี

ฟอนต์ที่โหลดจะถูกใช้เมื่อมีการเรนเดอร์หรือส่งออกงานนำเสนอ เช่น ไปเป็น PDF, รูปภาพและรูปแบบที่สนับสนุนอื่น ๆ สิ่งนี้ช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ในสภาพแวดล้อมต่าง ๆ บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนต์ที่ Aspose.Slides ใช้และวิธีลบแคชฟอนต์หลังจากทำงานกับฟอนต์ภายนอก

การลงทะเบียนฟอนต์แบบกำหนดเองสำหรับการเรนเดอร์แตกต่างจากการฝังฟอนต์ลงในไฟล์ PPTX หากต้องการให้ฟอนต์เก็บอยู่ภายในงานนำเสนอ ให้ใช้คุณลักษณะการฝังฟอนต์โดยตรง

{{% alert color="primary" %}} 

Aspose Slides ให้คุณโหลดฟอนต์เหล่านี้ด้วย [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfonts/) :

* ฟอนต์ TrueType (.ttf) และ TrueType Collection (.ttc) ดูเพิ่มเติมที่ [TrueType](https://en.wikipedia.org/wiki/TrueType)  
* ฟอนต์ OpenType (.otf) ดูเพิ่มเติมที่ [OpenType](https://en.wikipedia.org/wiki/OpenType)

{{% /alert %}}

## **โหลดฟอนต์แบบกำหนดเอง**

Aspose.Slides ให้คุณโหลดฟอนต์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ นี่มีผลต่อผลลัพธ์การส่งออก เช่น PDF, รูปภาพ และรูปแบบที่สนับสนุนอื่น ๆ ทำให้เอกสารที่ได้ดูสอดคล้องกันในทุกสภาพแวดล้อม ฟอนต์จะถูกโหลดจากไดเรกทอรีแบบกำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนต์  
2. เรียกเมธอดสเตติก [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfonts/) เพื่อโหลดฟอนต์จากโฟลเดอร์เหล่านั้น  
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ  
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/clearcache/) เพื่อลบแคชฟอนต์

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดฟอนต์:

```cpp
// กำหนดโฟลเดอร์ที่มีไฟล์ฟอนต์แบบกำหนดเอง.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// โหลดฟอนต์แบบกำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// เรนเดอร์/ส่งออกงานนำเสนอ (เช่น ไปเป็น PDF, รูปภาพ หรือรูปแบบอื่น) โดยใช้ฟอนต์ที่โหลดไว้.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// ลบแคชฟอนต์หลังจากทำงานเสร็จ.
FontsLoader::ClearCache();
```

{{% alert color="info" title="หมายเหตุ" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfonts/) เพิ่มโฟลเดอร์เพิ่มเติมในเส้นทางค้นหาฟอนต์ แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นฟอนต์ ฟอนต์จะถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางฟอนต์เริ่มต้นของระบบปฏิบัติการ  
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/)

{{%/alert %}}

## **รับโฟลเดอร์ฟอนต์แบบกำหนดเอง**

Aspose.Slides มีเมธอด [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/getfontfolders/) เพื่อให้คุณค้นหาโฟลเดอร์ฟอนต์ เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์ฟอนต์ของระบบ

โค้ด C++ ด้านล่างแสดงวิธีใช้เมธอด [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/getfontfolders/) :

``` cpp
// บรรทัดนี้จะแสดงโฟลเดอร์ที่ตรวจสอบสำหรับไฟล์ฟอนต์.
// โฟลเดอร์เหล่านี้คือโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนต์ของระบบ.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **ระบุฟอนต์แบบกำหนดเองที่ใช้กับงานนำเสนอ**

Aspose.Slides มีคุณสมบัติ [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) เพื่อให้คุณระบุฟอนต์ภายนอกที่จะใช้กับงานนำเสนอ

โค้ด C++ ด้านล่างแสดงวิธีใช้คุณสมบัติ [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) :

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //ทำงานกับงานนำเสนอ
    //CustomFont1, CustomFont2 รวมถึงฟอนต์จากโฟลเดอร์ assets\fonts & global\fonts รวมถึงโฟลเดอร์ย่อยของพวกมัน สามารถใช้ในงานนำเสนอได้
}
```

## **จัดการฟอนต์จากภายนอก**

Aspose.Slides มีเมธอด [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfont/) เพื่อให้คุณโหลดฟอนต์ภายนอกเป็นอาเรย์ไบต์

โค้ด C++ ด้านล่างแสดงกระบวนการโหลดฟอนต์เป็นอาเรย์ไบต์:

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

**ฟอนต์แบบกำหนดเองมีผลต่อการส่งออกทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?**

ใช่ ฟอนต์ที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก

**ฟอนต์แบบกำหนดเองจะถูกฝังอัตโนมัติในไฟล์ PPTX ที่ได้หรือไม่?**

ไม่ การลงทะเบียนฟอนต์สำหรับการเรนเดอร์ไม่เท่ากับการฝังลงใน PPTX หากต้องการให้ฟอนต์อยู่ในไฟล์งานนำเสนอ คุณต้องใช้ [คุณลักษณะการฝังฟอนต์](/slides/th/cpp/embedded-font/)

**สามารถควบคุมพฤติกรรม fallback เมื่อฟอนต์แบบกำหนดเองขาด glyph บางตัวได้หรือไม่?**

ได้ กำหนดค่า [การแทนที่ฟอนต์](/slides/th/cpp/font-substitution/), [กฎการแทนที่](/slides/th/cpp/font-replacement/) และ [ชุด fallback](/slides/th/cpp/fallback-font/) เพื่อระบุฟอนต์ที่ใช้เมื่อ glyph ที่ร้องขอไม่มีอยู่

**สามารถใช้ฟอนต์ในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งในระบบได้หรือไม่?**

ได้ ให้ชี้ไปยังโฟลเดอร์ฟอนต์ของคุณเองหรือโหลดฟอนต์จากอาเรย์ไบต์ วิธีนี้จะตัดการพึ่งพาโฟลเดอร์ฟอนต์ของระบบในอิมเมจคอนเทนเนอร์ออกทั้งหมด

**เรื่องลิขสิทธิ์—สามารถฝังฟอนต์แบบกำหนดเองใด ๆ ได้โดยไม่มีข้อจำกัดหรือไม่?**

คุณต้องรับผิดชอบด้านการปฏิบัติตามลิขสิทธิ์ของฟอนต์ เงื่อนไขอาจแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้ในเชิงพาณิชย์ ตรวจสอบข้อตกลง EULA ของฟอนต์ก่อนนำออกเผยแพร่ผลลัพธ์