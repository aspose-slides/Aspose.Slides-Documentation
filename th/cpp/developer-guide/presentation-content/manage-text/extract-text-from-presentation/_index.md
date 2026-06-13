---
title: การสกัดข้อความขั้นสูงจากงานนำเสนอใน C++
linktitle: สกัดข้อความ
type: docs
weight: 90
url: /th/cpp/extract-text-from-presentation/
keywords:
- สกัดข้อความ
- สกัดข้อความจากสไลด์
- สกัดข้อความจากงานนำเสนอ
- สกัดข้อความจาก PowerPoint
- สกัดข้อความจาก OpenDocument
- สกัดข้อความจาก PPT
- สกัดข้อความจาก PPTX
- สกัดข้อความจาก ODP
- ดึงข้อความ
- ดึงข้อความจากสไลด์
- ดึงข้อความจากงานนำเสนอ
- ดึงข้อความจาก PowerPoint
- ดึงข้อความจาก OpenDocument
- ดึงข้อความจาก PPT
- ดึงข้อความจาก PPTX
- ดึงข้อความจาก ODP
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "สกัดข้อความจากงานนำเสนอ PowerPoint และ OpenDocument อย่างรวดเร็วด้วย Aspose.Slides สำหรับ C++ ปฏิบัติตามแนวทางง่าย ๆ ทีละขั้นตอนของเราเพื่อประหยัดเวลา"
---
## **ภาพรวม**

การสกัดข้อความจากงานนำเสนอเป็นงานที่พบบ่อยแต่มีความสำคัญสำหรับนักพัฒนาที่ทำงานกับเนื้อหาในสไลด์ ไม่ว่าคุณจะทำงานกับไฟล์ Microsoft PowerPoint ที่เป็นรูปแบบ PPT หรือ PPTX หรือการนำเสนอ OpenDocument (ODP) การเข้าถึงและดึงข้อมูลข้อความสามารถเป็นสิ่งสำคัญสำหรับการวิเคราะห์ การอัตโนมัติ การทำดัชนี หรือการย้ายเนื้อหา

บทความนี้ให้คำแนะนำแบบครบถ้วนเกี่ยวกับวิธีสกัดข้อความจากรูปแบบงานนำเสนอหลายรูปแบบอย่างมีประสิทธิภาพ รวมถึง PPT, PPTX และ ODP โดยใช้ Aspose.Slides for C++ คุณจะได้เรียนรู้วิธีวนลูปผ่านองค์ประกอบของงานนำเสนออย่างเป็นระบบเพื่อดึงข้อความที่ต้องการอย่างแม่นยำ

## **สกัดข้อความจากสไลด์**

Aspose.Slides for C++ มี namespace [Aspose.Slides.Util](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/) ซึ่งรวมคลาส [SlideUtil](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/) คลาสนี้ให้เมธอด static ที่โอเวอร์โหลดหลายแบบสำหรับสกัดข้อความทั้งหมดจากงานนำเสนอหรือสไลด์ เพื่อสกัดข้อความจากสไลด์ในงานนำเสนอ ให้ใช้เมธอด [GetAllTextBoxes](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/getalltextboxes/) เมธอดนี้รับอ็อบเจกต์ประเภท [IBaseSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/) เป็นพารามิเตอร์ เมื่อทำงาน เมธอดจะสแกนสไลด์ทั้งหมดเพื่อค้นหาข้อความและส่งคืนอาร์เรย์ของอ็อบเจกต์ประเภท [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) พร้อมรักษาการจัดรูปแบบข้อความไว้

โค้ดตัวอย่างต่อไปนี้สกัดข้อความทั้งหมดจากสไลด์แรกของงานนำเสนอ:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **สกัดข้อความจากงานนำเสนอ**

เพื่อสแกนข้อความจากงานนำเสนอทั้งหมด ให้ใช้เมธอด static [GetAllTextFrames](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/getalltextframes/) ที่เปิดเผยโดยคลาส [SlideUtil](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/) เมธอดนี้รับพารามิเตอร์สองตัว:

1. อย่างแรกเป็นอ็อบเจกต์ [IPresentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/) ที่แสดงถึงงานนำเสนอ PowerPoint หรือ OpenDocument ซึ่งข้อความจะถูกสกัดออก
1. อย่างที่สองเป็นค่า `Boolean` ที่ระบุว่าจะรวมสไลด์มาสเตอร์ในการสแกนข้อความจากงานนำเสนอหรือไม่

เมธอดนี้ส่งคืนอาร์เรย์ของอ็อบเจกต์ประเภท [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) พร้อมข้อมูลการจัดรูปแบบข้อความ โค้ดด้านล่างสแกนข้อความและรายละเอียดการจัดรูปแบบจากงานนำเสนอรวมถึงสไลด์มาสเตอร์ด้วย

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **การสกัดข้อความแบบจัดหมวดหมู่และรวดเร็ว**

คลาส [PresentationFactory](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentationfactory/) ยังให้เมธอดสำหรับสกัดข้อความทั้งหมดจากงานนำเสนออีกด้วย:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

อากิวเมนต์ enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/th/cpp/aspose.slides/textextractionarrangingmode/) ระบุโหมดสำหรับจัดระเบียบผลลัพธ์การสกัดข้อความและสามารถตั้งค่าเป็นค่าต่อไปนี้:
- `Unarranged` - ข้อความดิบโดยไม่คำนึงถึงตำแหน่งบนสไลด์
- `Arranged` - ข้อความถูกจัดเรียงตามลำดับเดียวกับบนสไลด์

โหมด Unarranged สามารถใช้เมื่อความเร็วเป็นสิ่งสำคัญ; จะทำงานเร็วกว่าโหมด Arranged

[IPresentationText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationtext/) แสดงถึงข้อความดิบที่สกัดจากงานนำเสนอ เมธอด `get_SlidesText()` ของมันส่งคืนอาร์เรย์ของอ็อบเจกต์ประเภท [ISlideText](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidetext/) แต่ละอ็อบเจกต์แทนข้อความบนสไลด์ที่สอดคล้องกัน อ็อบเจกต์ประเภท [ISlideText](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidetext/) มีเมธอดต่อไปนี้:

- `get_Text()` - ข้อความภายในรูปร่างของสไลด์
- `get_MasterText()` - ข้อความภายในรูปร่างของสไลด์มาสเตอร์ที่เชื่อมโยงกับสไลด์นี้
- `get_LayoutText()` - ข้อความภายในรูปร่างของสไลด์เลย์เอาต์ที่เชื่อมโยงกับสไลด์นี้
- `get_NotesText()` - ข้อความภายในรูปร่างของสไลด์บันทึกย่อที่เชื่อมโยงกับสไลด์นี้
- `get_CommentsText()` - ข้อความภายในความคิดเห็นที่เชื่อมโยงกับสไลด์นี้

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **คำถามที่พบบ่อย**

**Aspose.Slides ประมวลผลงานนำเสนอขนาดใหญ่ระหว่างการสกัดข้อความเร็วแค่ไหน?**

Aspose.Slides ได้รับการปรับให้ทำงานด้วยประสิทธิภาพสูงและสามารถประมวลผลแม้จะเป็น [งานนำเสนอขนาดใหญ่](/slides/th/cpp/open-presentation/) ทำให้เหมาะสำหรับสถานการณ์การประมวลผลแบบเรียลไทม์หรือแบบเป็นชุดจำนวนมาก

**Aspose.Slides สามารถสกัดข้อความจากตารางและแผนภูมิภายในงานนำเสนอได้หรือไม่?**

ได้ Aspose.Slides สามารถสกัดข้อความจากหลายองค์ประกอบของสไลด์รวมถึงตารางและวัตถุที่เกี่ยวข้องกับแผนภูมิ จึงทำให้คุณเข้าถึงและวิเคราะห์เนื้อหาข้อความในโครงสร้างงานนำเสนอทั่วไปได้

**ต้องใช้ไลเซนส์ Aspose.Slides พิเศษเพื่อสกัดข้อความจากงานนำเสนอหรือไม่?**

คุณสามารถสกัดข้อความโดยใช้เวอร์ชันทดลองฟรีของ Aspose.Slides แม้จะมี [ข้อจำกัดบางประการ](/slides/th/cpp/licensing/) เช่น การประมวลผลเพียงจำนวนสไลด์ที่จำกัด สำหรับการใช้โดยไม่มีข้อจำกัดและเพื่อจัดการงานนำเสนอขนาดใหญ่มากขึ้น แนะนำให้ซื้อไลเซนส์เต็มรูปแบบ.