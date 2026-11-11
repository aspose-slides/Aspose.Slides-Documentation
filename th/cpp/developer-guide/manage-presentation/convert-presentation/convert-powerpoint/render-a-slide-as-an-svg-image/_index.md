---
title: เรนเดอร์สไลด์การนำเสนอเป็นภาพ SVG ใน C++
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint เป็น SVG
- การนำเสนอเป็น SVG
- สไลด์เป็น SVG
- PPT เป็น SVG
- PPTX เป็น SVG
- ตัวเลือกการส่งออก SVG
- SVG แบบโต้ตอบ
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน C++ และควบคุมฟอนต์, ข้อความ, รูปภาพ, ID และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพที่ขยายได้ตาม XML ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวดูสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลหลังอัตโนมัติ. Aspose.Slides for C++ ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกแต่ละไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ, ฟอนต์, รูปภาพ, และองค์ประกอบ SVG

ใช้ [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) เมื่อ SVG ที่ส่งออกต้องเป็นแบบกระชับ, คาดเดาได้ข้ามเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), เลือกสไลด์, และเขียนไปยังสตรีม. ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกแต่ละไฟล์

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

ชื่อไฟล์ใช้ [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) แทนการใช้ดัชนีของลูป. คุณยังสามารถส่งออกรูปร่างเดี่ยวโดยใช้ [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) เมื่อผู้ดูสไลด์หรือหน้าเว็บต้องการเฉพาะรูปร่างนั้น

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) ควบคุมการเรนเดอร์ SVG. สำหรับกรอบข้อความ, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) จะรวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) กำหนดว่าการหมุนกรอบจะถูกนำมาใช้หรือไม่. ตั้งค่า [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) เป็น `true` เมื่อข้อความต้องแสดงโดยไม่มีลิแกเจอร์

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **ควบคุมข้อความและฟอนต์**

เมื่อส่งออกสไลด์เป็น SVG, คุณสามารถควบคุมได้ว่าข้อความยังคงเป็นข้อความหรือถูกแปลงเป็นกราฟิกเวกเตอร์, และฟอนต์ภายนอกจะถูกรวมหรืออ้างอิงอย่างไร. ตัวเลือกต่อไปนี้ช่วยให้คุณสมดุลความสอดคล้องของภาพ, การเลือกข้อความ, และการพึ่งพาฟอนต์ใน SVG ที่ส่งออก

### **เวกเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) เป็น `true` เพื่อเขียนข้อความสไลด์ทั้งหมดเป็นกราฟิกเวกเตอร์. สิ่งนี้ขจัดการพึ่งพาฟอนต์และทำให้ผลลัพธ์ภาพสอดคล้องกันมากขึ้นข้ามเบราว์เซอร์, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาเป็นข้อความ SVG ได้อีกต่อไป

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **เลือกวิธีจัดการฟอนต์ภายนอก**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) สำหรับฟอนต์ที่โหลดจากภายนอก. เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์ฟอนต์แยก, `Embed` เพื่อรวมข้อมูลฟอนต์ใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้ฟอนต์ภายนอกเป็นกราฟิก. ตรวจสอบลิขสิทธิ์ฟอนต์ก่อนการฝังฟอนต์

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **ลดขนาดภาพที่ฝังอยู่**

ใช้ [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) เพื่อลดความละเอียดของภาพที่ฝังอยู่, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) เพื่อลบพื้นที่ต้นฉบับที่ถูกตัด, และ [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG. การตั้งค่าเหล่านี้ลดขนาดไฟล์โดยอาจทำให้คุณภาพภาพหรือข้อมูลภาพที่เก็บไว้ลดลง

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **ควบคุมความละเอียดการเรสเตอร์ไลซ์ Metafile**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) กำหนดขีดจำกัดความละเอียดล่างสุดสำหรับการเรสเตอร์ไลซ์เมตาฟายล์ระหว่างการส่งออก SVG. ใช้เพื่อสมดุลรายละเอียดและขนาดไฟล์เมื่อภาพ EMF หรือ WMF ถูกเรสเตอร์ไลซ์. มันไม่ได้กำหนด DPI สากลสำหรับ SVG หรือบังคับให้ทุกวัตถุบนสไลด์กลายเป็นภาพเรสเตอร์

ดาวน์โหลด [metafile-rasterization.pptx](metafile-rasterization.pptx), ซึ่งมีภาพ EMF ที่มีเส้นทแยงมุมห่างกันใกล้. ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์นั้นที่ความละเอียดการเรสเตอร์ไลซ์สามระดับผ่าน [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/). การตั้งค่าอื่น ๆ ของการส่งออกยังคงเหมือนเดิมเพื่อให้เปรียบเทียบผลลัพธ์ได้

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"metafile-rasterization.pptx");
auto slide = presentation->get_Slide(0);
const int resolutions[] = { 72, 150, 300 };

for (auto dpi : resolutions)
{
    auto svgOptions = MakeObject<SVGOptions>();
    svgOptions->set_MetafileRasterizationDpi(dpi);
    svgOptions->set_PicturesCompression(PicturesCompression::Dpi330);
    svgOptions->set_JpegQuality(90);

    auto svgFileName = String::Format(u"slide-{0}.svg", dpi);
    auto svgStream = File::Create(svgFileName);
    slide->WriteAsSvg(svgStream, svgOptions);
    svgStream->Dispose();
}

presentation->Dispose();
```

ในผลลัพธ์, EMF จะกลายเป็น PNG ที่ฝังอยู่หนึ่งไฟล์ในแต่ละ SVG. การวัดต่อไปนี้เป็นของงานนำเสนอที่ให้มา; ไม่ใช่สูตรทั่วไปสำหรับการแปลง DPI เป็นมิติพิกเซล

| DPI การเรสเตอร์ไลซ์ Metafile | ขนาด PNG ที่ฝังอยู่ | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงพื้นที่เดียวกันของเรสเตอร์ที่ฝังอยู่ที่ขนาดการแสดงผลขยายเท่าเดิม. เส้นทแยงมุมแสดงพิกเซลที่มองเห็นได้ที่ 72 DPI และขอบที่เรียบขึ้นที่ความละเอียดสูงกว่า, ในขณะที่ไฟล์ SVG เติบโต. การเพิ่มค่าไม่ได้หมายความว่าจะปรับปรุงรายละเอียดทั้งหมดหรือเปลี่ยนแปลงภาพที่ส่งออกทุกภาพ

![รายละเอียดเส้นทแยงมุมที่ขยายที่ 72, 150, และ 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) ควบคุมการลดความละเอียดของภาพและสามารถปกปิดผลของการเปลี่ยนความละเอียดการเรสเตอร์ไลซ์เมตาฟายล์. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) ควบคุมคุณภาพการเข้ารหัส JPEG, ไม่ใช่ความละเอียดการเรสเตอร์ไลซ์เมตาฟายล์

## **กำหนด ID ที่คงที่ให้กับรูปร่างและข้อความ**

ใช้ [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) เพื่อกำหนด [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) สำหรับแต่ละรูปร่าง SVG. เพื่อกำหนดค่า [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) บนองค์ประกอบข้อความ `tspan` ด้วย, ให้ทำการนำ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) ไปใช้. กำหนดตัวควบคุมใดก็ได้ด้วย [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/)

ตัวควบคุมต่อไปนี้ใช้ [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/), ซึ่งคงที่ตลอดอายุของรูปร่าง, และตัวนับที่ทำซ้ำได้สำหรับส่วนของข้อความของมัน. สิ่งนี้ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อของงานนำเสนอที่ไม่เปลี่ยนแปลง

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **เพิ่มตัวจัดการเหตุการณ์ SVG**

ใน [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/), เรียก [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) พร้อมค่า [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปร่างที่ส่งออก. กำหนดตัวควบคุมด้วย [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) และกำหนดฟังก์ชัน JavaScript ในหน้า หรือเอกสาร SVG ที่โฮสต์ผลลัพธ์

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

หน้าโฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่อ้างอิงโดยตัวจัดการได้. การกำหนด ID และตัวจัดการเหตุการณ์ทำให้ผู้ดูสไลด์, การเพิ่มความเข้าถึง, และกระบวนการทำงาน SVG แบบโต้ตอบอื่น ๆ ทำงานได้

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) แทน [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)?**

ใช้ [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) เมื่อข้อความทั้งหมดต้องไม่ขึ้นกับฟอนต์. ใช้ [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) เมื่อเฉพาะข้อความที่ใช้ฟอนต์ภายนอกควรแปลงเป็นกราฟิก

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มด้วยการบีบอัดภาพที่ฝังอยู่, ลบพื้นที่รูปภาพที่ถูกตัด, และเลือกไฟล์ฟอนต์ที่เชื่อมโยงเมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการได้. ทดสอบผลลัพธ์เนื่องจากความละเอียดภาพที่ต่ำกว่า, คุณภาพ JPEG ที่ต่ำกว่า, และข้อความที่เวกเตอร์แต่ละอย่างมีการต่อรองด้านคุณภาพและขนาดที่แตกต่างกัน

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังจากการส่งออกได้หรือไม่?**

ใช่. กำหนด ID ผ่านตัวควบคุมการจัดรูปแบบ, จากนั้นเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือประมวลผลต่อของคุณหรือสคริปต์เบราว์เซอร์