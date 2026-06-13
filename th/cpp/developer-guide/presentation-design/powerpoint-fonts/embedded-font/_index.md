---
title: ฝังฟอนต์ในงานนำเสนอโดยใช้ С++
linktitle: ฝังฟอนต์
type: docs
weight: 40
url: /th/cpp/embedded-font/
keywords:
- เพิ่มฟอนต์
- ฝังฟอนต์
- การฝังฟอนต์
- รับฟอนต์ที่ฝัง
- เพิ่มฟอนต์ที่ฝัง
- ลบฟอนต์ที่ฝัง
- บีบอัดฟอนต์ที่ฝัง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- С++
- Aspose.Slides
description: "ฝังฟอนต์ TrueType ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ С++ เพื่อให้การเรนเดอร์ที่แม่นยำบนทุกแพลตฟอร์ม"
---
## **บทนำ**

**ฟอนต์ที่ฝังใน PowerPoint** ช่วยให้มั่นใจว่าการนำเสนอของคุณคงรูปลักษณ์ตามที่ตั้งใจเมื่อเปิดบนระบบหรืออุปกรณ์ใดก็ได้ นี่เป็นสิ่งสำคัญอย่างยิ่งเมื่อใช้ฟอนต์ที่กำหนดเอง, ฟอนต์จากบุคคลที่สาม, หรือฟอนต์ที่ไม่เป็นมาตรฐานสำหรับการสร้างแบรนด์หรือการออกแบบเชิงสร้างสรรค์ หากไม่มีฟอนต์ที่ฝังไว้ ข้อความอาจถูกแทนที่, การจัดวางอาจเสียหาย, และอักขระอาจปรากฏเป็นสัญลักษณ์หรือสี่เหลี่ยมที่อ่านไม่ออก ทำให้การออกแบบโดยรวมเสียหาย

Aspose.Slides for C++ ให้ชุด API ที่มีประสิทธิภาพเพื่อจัดการฟอนต์ที่ฝังไว้โดยโปรแกรม คุณสามารถใช้คลาส [FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/) และ [FontData](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontdata/) เพื่อสืบค้น, เพิ่ม หรือ ลบ ฟอนต์ที่ฝังไว้ในไฟล์การนำเสนอของคุณ นอกจากนี้คลาส [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/) ช่วยให้คุณปรับขนาดไฟล์โดยการบีบอัดข้อมูลฟอนต์โดยไม่กระทบต่อคุณภาพหรือรูปลักษณ์

เครื่องมือเหล่านี้ให้การควบคุมเต็มที่ในการฝังฟอนต์ ช่วยให้คุณรักษาการจัดรูปแบบตัวอักษรที่สอดคล้องกันระหว่างแพลตฟอร์มต่าง ๆ พร้อมทั้งลดขนาดไฟล์เมื่อต้องการ

## **รับฟอนต์ที่ฝังจากการนำเสนอ**

Aspose.Slides for C++ ให้เมธอด `GetEmbeddedFonts` ผ่านคลาส [FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/) ซึ่งช่วยให้คุณดึงรายการฟอนต์ที่ฝังในงานนำเสนอ PowerPoint ได้ สิ่งนี้มีประโยชน์สำหรับการตรวจสอบการใช้ฟอนต์, ตรวจสอบการปฏิบัติตามแนวทางแบรนด์, หรือยืนยันว่าฟอนต์ที่จำเป็นทั้งหมดได้ถูกใส่อย่างถูกต้องก่อนแชร์ไฟล์

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Get all embedded fonts.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Print names of the embedded fonts.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **เพิ่มฟอนต์ที่ฝังในการนำเสนอ**

Aspose.Slides for C++ อนุญาตให้คุณฝังฟอนต์ลงในงานนำเสนอ PowerPoint โดยใช้เมธอด [AddEmbeddedFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/addembeddedfont/) ซึ่งมีสองรูปแบบการโอเวอร์โหลดเพื่อการใช้งานที่ยืดหยุ่น คุณสามารถควบคุมปริมาณฟอนต์ที่ฝังโดยใช้ enumeration [EmbedFontCharacters](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/embedfontcharacters/) — ตัวอย่างเช่น เลือกฝังเฉพาะอักขระที่ใช้หรือชุดฟอนต์ทั้งหมด ฟีเจอร์นี้มีประโยชน์อย่างยิ่งเมื่อเตรียมงานนำเสนอเพื่อแชร์หรือแจกจ่าย เพื่อให้แน่ใจว่าฟอนต์ที่กำหนดเองหรือฟอนต์ที่ไม่เป็นมาตรฐานจะแสดงอย่างถูกต้องบนทุกระบบ แม้ว่าฟอนต์เหล่านั้นจะไม่ได้ติดตั้ง

โค้ด C++ ด้านล่างตรวจสอบฟอนต์ทั้งหมดที่ใช้ในงานนำเสนอ และฝังฟอนต์ที่ยังไม่ได้ฝังไว้

```cpp
// โหลดไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // ตรวจสอบว่าฟอนต์นี้ฝังไว้แล้วหรือยัง.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // ฝังฟอนต์ลงในงานนำเสนอ.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// บันทึกงานนำเสนอลงดิสก์.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ลบฟอนต์ที่ฝังจากการนำเสนอ**

Aspose.Slides for C++ ให้เมธอด `RemoveEmbeddedFont` ผ่านคลาส [FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/) ซึ่งทำให้คุณสามารถลบฟอนต์เฉพาะที่ฝังอยู่ในงานนำเสนอ PowerPoint ได้ สิ่งนี้ช่วยลดขนาดไฟล์โดยรวม โดยเฉพาะหากฟอนต์ที่ฝังไว้ไม่ถูกใช้หรือไม่จำเป็นอีกต่อไป การลบฟอนต์ที่ไม่ใช้ยังช่วยปรับปรุงประสิทธิภาพและทำให้การนำเสนอของคุณมีเฉพาะทรัพยากรที่จำเป็นเท่านั้น

```cpp
auto fontName = u"Calibri";

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// รับฟอนต์ที่ฝังทั้งหมด.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // ลบฟอนต์ที่ฝังไว้.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **บีบอัดฟอนต์ที่ฝัง**

Aspose.Slides for C++ ให้เมธอด `CompressEmbeddedFonts` ผ่านคลาส [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/) ซึ่งช่วยให้คุณลดขนาดไฟล์โดยรวมของงานนำเสนอโดยการปรับข้อมูลฟอนต์ที่ฝังให้เป็นไปอย่างมีประสิทธิภาพ สิ่งนี้เป็นประโยชน์อย่างยิ่งเมื่อการนำเสนอของคุณมีฟอนต์ขนาดใหญ่หรือหลายฟอนต์ และคุณต้องการให้ไฟล์มีขนาดเบาเพื่อการแชร์, การเก็บรักษา หรือการใช้งานออนไลน์ — โดยไม่กระทบต่อความแม่นยำของภาพ

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**ฉันจะทราบได้อย่างไรว่าฟอนต์เฉพาะในงานนำเสนอจะยังคงถูกแทนที่ในระหว่างการเรนเดอร์แม้จะฝังแล้ว?**  
ตรวจสอบ [ข้อมูลการแทนที่](/slides/th/cpp/font-substitution/) ใน font manager และ [กฎการสำรอง/การแทนที่](/slides/th/cpp/fallback-font/): หากฟอนต์ไม่พร้อมใช้งานหรือถูกจำกัด จะใช้ฟอนต์สำรองแทน

**คุ้มค่าหรือไม่ที่จะฝังฟอนต์ “system” เช่น Arial/Calibri?**  
โดยทั่วไปไม่ — พวกมันมักจะพร้อมใช้งานอยู่แล้ว แต่สำหรับการพกพาเต็มรูปแบบในสภาพแวดล้อม “บาง” (Docker, เซิร์ฟเวอร์ Linux ที่ไม่มีฟอนต์ติดตั้งล่วงหน้า) การฝังฟอนต์ระบบสามารถขจัดความเสี่ยงของการแทนที่ที่ไม่คาดคิดได้