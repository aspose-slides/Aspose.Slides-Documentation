---
title: ฝังแบบอักษรในงานนำเสนอโดยใช้ C++
linktitle: การฝังแบบอักษร
type: docs
weight: 40
url: /th/cpp/embedded-font/
keywords:
- เพิ่มแบบอักษร
- ฝังแบบอักษร
- การฝังแบบอักษร
- ดึงแบบอักษรที่ฝังไว้
- เพิ่มแบบอักษรที่ฝังไว้
- ลบแบบอักษรที่ฝังไว้
- บีบอัดแบบอักษรที่ฝังไว้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ฝังแบบอักษร TrueType ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++ เพื่อให้การเรนเดอร์ที่แม่นยำบนทุกแพลตฟอร์ม"
---
## **บทนำ**

**แบบอักษรที่ฝังไว้ใน PowerPoint** ช่วยให้แน่ใจว่าการนำเสนอของคุณคงรูปลักษณ์ตามที่ตั้งใจไว้เมื่อเปิดบนระบบหรืออุปกรณ์ใดก็ได้ สิ่งนี้สำคัญเป็นพิเศษเมื่อใช้แบบอักษรที่กำหนดเอง แบบอักษรของบุคคลที่สาม หรือแบบอักษรที่ไม่เป็นมาตรฐานสำหรับการสร้างแบรนด์หรือวัตถุประสงค์ด้านความคิดสร้างสรรค์ หากไม่มีการฝังแบบอักษร ตัวอักษรอาจถูกแทนที่ การจัดวางอาจพังและอักขระอาจปรากฏเป็นสัญลักษณ์หรือสี่เหลี่ยมที่อ่านไม่ออก ทำให้การออกแบบโดยรวมเสียหาย

Aspose.Slides for C++ มีชุด API ที่ทรงพลังเพื่อจัดการแบบอักษรที่ฝังไว้โดยโปรแกรม คุณสามารถใช้คลาส [FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/) และ [FontData](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontdata/) เพื่อสำรวจ เพิ่ม หรือเอาแบบอักษรที่ฝังไว้ในไฟล์การนำเสนอของคุณออก นอกจากนี้คลาส [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/) ยังช่วยให้คุณปรับขนาดไฟล์ให้เล็กลงโดยการบีบอัดข้อมูลแบบอักษรโดยไม่กระทบต่อคุณภาพหรือรูปลักษณ์

เครื่องมือเหล่านี้ให้การควบคุมเต็มที่ต่อการฝังแบบอักษร ช่วยให้คุณรักษาการจัดพิมพ์ให้สอดคล้องกันข้ามแพลตฟอร์มในขณะที่ลดขนาดไฟล์ตามความต้องการ

## **ดึงแบบอักษรที่ฝังไว้จากการนำเสนอ**

Aspose.Slides for C++ มีเมธอด `GetEmbeddedFonts` ผ่านคลาส [FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/) ซึ่งทำให้คุณสามารถดึงรายการแบบอักษรที่ฝังไว้ในไฟล์ PowerPoint ได้ ซึ่งมีประโยชน์สำหรับการตรวจสอบการใช้แบบอักษร การปฏิบัติตามแนวทางแบรนด์ หรือการยืนยันว่าแบบอักษรที่จำเป็นทั้งหมดถูกรวมอยู่ก่อนแชร์ไฟล์

โค้ด C++ ตัวอย่างต่อไปนี้แสดงวิธีดึงแบบอักษรที่ฝังไว้จากไฟล์การนำเสนอ:

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// ดึงแบบอักษรที่ฝังไว้ทั้งหมด.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// พิมพ์ชื่อของแบบอักษรที่ฝังไว้.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **เพิ่มแบบอักษรที่ฝังไว้ในการนำเสนอ**

Aspose.Slides for C++ อนุญาตให้คุณฝังแบบอักษรลงใน PowerPoint ด้วยเมธอด [AddEmbeddedFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/addembeddedfont/) ซึ่งมีการโอเวอร์โหลดสองรูปแบบเพื่อการใช้งานที่ยืดหยุ่น คุณสามารถควบคุมขอบเขตการฝังแบบอักษรโดยใช้ enumeration [EmbedFontCharacters](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/embedfontcharacters/) — ตัวอย่างเช่น เลือกฝังเฉพาะอักขระที่ใช้หรือฝังชุดแบบอักษรทั้งหมด คุณลักษณะนี้มีประโยชน์อย่างยิ่งเมื่อเตรียมการนำเสนอสำหรับการแชร์หรือแจกจ่าย เพื่อให้แน่ใจว่าแบบอักษรที่กำหนดเองหรือไม่มาตรฐานจะแสดงผลอย่างถูกต้องบนทุกระบบ แม้ว่าจะไม่มีการติดตั้งแบบอักษรเหล่านั้นในเครื่อง

โค้ด C++ ต่อไปนี้ตรวจสอบแบบอักษรทั้งหมดที่ใช้ในการนำเสนอและฝังแบบอักษรใด ๆ ที่ยังไม่ได้ฝังไว้:

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

    // ตรวจสอบว่าแบบอักษรนี้ฝังไว้แล้วหรือยัง.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // ฝังแบบอักษรลงในงานนำเสนอ.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// บันทึกงานนำเสนอลงดิสก์.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ลบแบบอักษรที่ฝังไว้จากการนำเสนอ**

Aspose.Slides for C++ มีเมธอด `RemoveEmbeddedFont` ผ่านคลาส [FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/) ช่วยให้คุณสามารถลบแบบอักษรที่ฝังไว้เฉพาะจาก PowerPoint ได้ ซึ่งช่วยลดขนาดไฟล์โดยรวม โดยเฉพาะเมื่อแบบอักษรที่ฝังไว้ไม่ถูกใช้หรือไม่จำเป็น การลบแบบอักษรที่ไม่ได้ใช้ยังช่วยเพิ่มประสิทธิภาพและทำให้การนำเสนอมีทรัพยากรที่จำเป็นเท่านั้น

โค้ด C++ ตัวอย่างต่อไปนี้แสดงวิธีลบแบบอักษรที่ฝังไว้จากการนำเสนอ:

```cpp
auto fontName = u"Calibri";

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// ดึงแบบอักษรที่ฝังไว้ทั้งหมด.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // ลบแบบอักษรที่ฝังไว้.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **บีบอัดแบบอักษรที่ฝังไว้**

Aspose.Slides for C++ มีเมธอด `CompressEmbeddedFonts` ผ่านคลาส [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/) ทำให้คุณสามารถลดขนาดไฟล์ของการนำเสนอโดยการเพิ่มประสิทธิภาพข้อมูลแบบอักษรที่ฝังไว้ ซึ่งเป็นประโยชน์อย่างยิ่งเมื่อการนำเสนอของคุณมีแบบอักษรหลายแบบหรือขนาดใหญ่ และคุณต้องการให้ไฟล์เบาแรงสำหรับการแชร์ การเก็บรักษา หรือการใช้งานออนไลน์ — โดยไม่ลดทอนคุณภาพการแสดงผลของเนื้อหา

โค้ด C++ ตัวอย่างต่อไปนี้แสดงวิธีบีบอัดแบบอักษรที่ฝังไว้ใน PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**ฉันจะทราบได้อย่างไรว่าแบบอักษรเฉพาะในการนำเสนอจะยังคงถูกแทนที่ระหว่างการเรนเดอร์แม้จะฝังแล้ว?**  
ตรวจสอบ [substitution information](/slides/th/cpp/font-substitution/) ในตัวจัดการแบบอังกและ [fallback/substitution rules](/slides/th/cpp/fallback-font/): หากแบบอักษรไม่สามารถใช้ได้หรือถูกจำกัด ระบบจะใช้แบบอักษรสำรอง

**การฝังแบบอักษร “ระบบ” เช่น Arial/Calibri คุ้มหรือไม่?**  
ส่วนใหญ่ไม่—โดยปกติแบบอักษรเหล่านี้จะมีอยู่เสมอ แต่สำหรับความพกพาเต็มรูปแบบในสภาพแวดล้อม “บาง” (เช่น Docker หรือเซิร์ฟเวอร์ Linux ที่ไม่มีแบบอักษรติดตั้งล่วงหน้า) การฝังแบบอักษรระบบสามารถขจัดความเสี่ยงจากการแทนที่ที่ไม่คาดคิดได้