---
title: การสกัดข้อความขั้นสูงจากงานนำเสนอใน C++
linktitle: สกัดข้อความ
type: docs
weight: 90
url: /th/cpp/extract-text-from-presentation/
aliases:
  - /cpp/extracting-text-from-the-presentation/
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
description: "สกัดข้อความจากงานนำเสนอ PowerPoint และ OpenDocument อย่างรวดเร็วโดยใช้ Aspose.Slides for C++ ตามขั้นตอนง่าย ๆ เพื่อประหยัดเวลา."
---
## **ภาพรวม**

การสกัดข้อความจากงานนำเสนอเป็นงานที่พบบ่อยแต่สำคัญสำหรับนักพัฒนาที่ทำงานกับเนื้อหาสไลด์ ไม่ว่าคุณจะทำงานกับไฟล์ Microsoft PowerPoint ในรูปแบบ PPT หรือ PPTX หรือไฟล์งานนำเสนอ OpenDocument (ODP) การเข้าถึงและดึงข้อมูลข้อความสามารถเป็นสิ่งสำคัญสำหรับการวิเคราะห์, การทำอัตโนมัติ, การทำดัชนี, หรือการย้ายเนื้อหา

บทความนี้ให้คำแนะนำอย่างครบถ้วนเกี่ยวกับวิธีสกัดข้อความจากรูปแบบงานนำเสนอหลายประเภท รวมถึง PPT, PPTX และ ODP ด้วย Aspose.Slides for C++ คุณจะได้เรียนรู้วิธีวนลูปผ่านองค์ประกอบของงานนำเสนออย่างเป็นระบบเพื่อดึงข้อความที่ต้องการได้อย่างแม่นยำ

## **สกัดข้อความจากสไลด์**

Aspose.Slides for C++ มีเนมสเปซ [Aspose.Slides.Util](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/) ซึ่งประกอบด้วยคลาส [SlideUtil](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/) คลาสนี้เปิดเผยเมธอดสเตติกหลายแบบที่โอเวอร์โหลดเพื่อสกัดข้อความทั้งหมดจากงานนำเสนอหรือสไลด์ เพื่อสกัดข้อความจากสไลด์ในงานนำเสนอ ให้ใช้เมธอด [GetAllTextBoxes](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/getalltextboxes/) เมธอดนี้รับออบเจ็กต์ประเภท [IBaseSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/) เป็นพารามิเตอร์ เมื่อทำงาน เมธอดจะสแกนสไลด์ทั้งหมดเพื่อค้นหาข้อความและคืนค่าอาเรย์ของออบเจ็กต์ประเภท [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) พร้อมกับรักษาการจัดรูปแบบของข้อความไว้

โค้ดต่อไปนี้สกัดข้อความทั้งหมดจากสไลด์แรกของงานนำเสนอ:

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

เพื่อสแกนข้อความจากงานนำเสนอทั้งหมด ให้ใช้เมธอดสเตติก [GetAllTextFrames](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/getalltextframes/) ของคลาส [SlideUtil](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/) เมธอดนี้รับพารามิเตอร์สองตัว:

1. ตัวแรกคือออบเจ็กต์ [IPresentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/) ที่แทนงานนำเสนอ PowerPoint หรือ OpenDocument ที่ต้องการสกัดข้อความ
1. ตัวที่สองคือค่า `Boolean` ที่บ่งบอกว่าควรรวมสไลด์แม่เมื่อสแกนข้อความจากงานนำเสนอหรือไม่

เมธอดจะคืนค่าอาเรย์ของออบเจ็กต์ประเภท [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) พร้อมข้อมูลการจัดรูปแบบของข้อความ โค้ดด้านล่างสแกนข้อความและรายละเอียดการจัดรูปแบบจากงานนำเสนอรวมถึงสไลด์แม่ด้วย

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

## **การสกัดข้อความที่จัดประเภทและรวดเร็ว**

คลาส [PresentationFactory](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentationfactory/) ยังมีเมธอดสำหรับสกัดข้อความทั้งหมดจากงานนำเสนอ:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

อาร์กิวเมนต์ enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/th/cpp/aspose.slides/textextractionarrangingmode/) กำหนดโหมดการจัดผลลัพธ์การสกัดข้อความและสามารถตั้งค่าเป็นค่าเหล่านี้ได้:
- `Unarranged` - ข้อความดิบโดยไม่คำนึงถึงตำแหน่งบนสไลด์
- `Arranged` - ข้อความถูกจัดเรียงตามลำดับเดียวกับบนสไลด์

โหมด Unarranged สามารถใช้เมื่อความเร็วเป็นสิ่งสำคัญ; จะเร็วกว่าโหมด Arranged

[IPresentationText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentationtext/) แทนข้อความดิบที่สกัดจากงานนำเสนอ เมธอด `get_SlidesText()` จะคืนค่าอาเรย์ของออบเจ็กต์ประเภท [ISlideText](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidetext/) แต่ละออบเจ็กต์แทนข้อความบนสไลด์ที่สอดคล้องกัน ออบเจ็กต์ประเภท [ISlideText](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidetext/) มีเมธอดต่อไปนี้:

- `get_Text()` - ข้อความภายในรูปทรงของสไลด์
- `get_MasterText()` - ข้อความภายในรูปทรงของสไลด์แม่ที่เชื่อมโยงกับสไลด์นี้
- `get_LayoutText()` - ข้อความภายในรูปทรงของสไลด์เลเอาต์ที่เชื่อมโยงกับสไลด์นี้
- `get_NotesText()` - ข้อความภายในรูปทรงของสไลด์โน้ตที่เชื่อมโยงกับสไลด์นี้
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

**Aspose.Slides สามารถประมวลผลงานนำเสนอขนาดใหญ่ได้เร็วแค่ไหนเมื่อสกัดข้อความ?**

Aspose.Slides ได้รับการปรับแต่งเพื่อให้ทำงานได้อย่างมีประสิทธิภาพสูงและสามารถประมวลผลแม้จะเป็น [งานนำเสนอขนาดใหญ่](/slides/th/cpp/open-presentation/) ทำให้เหมาะสมสำหรับสถานการณ์การประมวลผลแบบเรียลไทม์หรือแบบเป็นชุดจำนวนมาก

**Aspose.Slides สามารถสกัดข้อความจากตารางและแผนภูมิในงานนำเสนอได้หรือไม่?**

ได้ Aspose.Slides สามารถสกัดข้อความจากหลายองค์ประกอบของสไลด์รวมถึงตารางและวัตถุที่เกี่ยวข้องกับแผนภูมิ ทำให้คุณสามารถเข้าถึงและวิเคราะห์เนื้อหาข้อความในโครงสร้างงานนำเสนอทั่วไปได้

**จำเป็นต้องมีใบอนุญาต Aspose.Slides พิเศษเพื่อสกัดข้อความจากงานนำเสนอหรือไม่?**

คุณสามารถสกัดข้อความโดยใช้รุ่นทดลองฟรีของ Aspose.Slides แม้ว่าจะมี [ข้อจำกัดบางประการ](/slides/th/cpp/licensing/) เช่น การประมวลผลจำนวนสไลด์ที่จำกัด สำหรับการใช้งานโดยไม่มีข้อจำกัดและเพื่อจัดการกับงานนำเสนอที่ใหญ่ขึ้น การซื้อใบอนุญาตเต็มรูปแบบจึงแนะนำ.