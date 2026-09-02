---
title: แปลงสไลด์การนำเสนอเป็นภาพ SVG ใน C++
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
- SVG เชิงโต้ตอบ
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน C++ และควบคุมแบบอักษร, ข้อความ, รูปภาพ, ID และเหตุการณ์ด้วย Aspose.Slides.
---
## **ภาพรวม**

SVG คือรูปแบบภาพที่ขยายได้โดยอิง XML ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวดูสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลหลังอัตโนมัติ Aspose.Slides for C++ จะส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ, แบบอักษร, ภาพถ่าย, และองค์ประกอบ SVG

ใช้ [SVGOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/) เมื่อ SVG ที่ส่งออกต้องมีขนาดกะทัดรัด, คาดเดาได้ข้ามเบราว์เซอร์, หรือพร้อมสำหรับการใช้แบบโต้ตอบ

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/), เลือกสไลด์, แล้วเขียนลงสตรีม ตัวอย่างต่อไปนี้จะส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์

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

ชื่อไฟล์ใช้ [ISlide::get_SlideNumber](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/get_slidenumber/) แทนดัชนีของลูป คุณยังสามารถส่งออกรูปทรงเดี่ยวด้วย [IShape::WriteAsSvg](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/writeassvg/) เมื่อผู้ดูสไลด์หรือหน้าเว็บต้องการเพียงรูปทรงนั้นเท่านั้น

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/) ควบคุมการเรนเดอร์ SVG สำหรับกรอบข้อความ, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/set_useframesize/) จะรวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/set_useframerotation/) จะกำหนดว่าการหมุนกรอบจะถูกใช้หรือไม่ ตั้งค่า [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) เป็น `true` เมื่อข้อความต้องการเรนเดอร์โดยไม่มีลิการ์

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

## **ควบคุมข้อความและแบบอักษร**

### **แปลงเวกเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) เป็น `true` เพื่อเขียนข้อความสไลด์ทั้งหมดเป็นกราฟิกเวกเตอร์ สิ่งนี้จะขจัดการพึ่งพาแบบอักษรและทำให้ผลลัพธ์เชิงภาพสอดคล้องกันมากขึ้นข้ามเบราว์เซอร์ แต่ข้อความจะไม่สามารถเลือกหรือค้นหาได้เป็นข้อความ SVG

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

### **เลือกวิธีการจัดการแบบอักษรภายนอก**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgexternalfontshandling/) สำหรับแบบอักษรที่โหลดจากภายนอก เลือก `AddLinksToFontFiles` เพื่้อออิงไฟล์แบบอักษรแยก, `Embed` เพื่อฝังข้อมูลแบบอักษรใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้แบบอักษรภายนอกเป็นกราฟิก ตรวจสอบลิขสิทธิ์ของแบบอักษรก่อนฝังแบบอักษร

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

## **ลดขนาดรูปภาพที่ฝังไว้**

ใช้ [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/set_picturescompression/) เพื่อลดความละเอียดของรูปภาพที่ฝังไว้, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) เพื่อตัดส่วนภาพที่ถูกครอบออก, และ [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/set_jpegquality/) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG การตั้งค่าเหล่านี้จะลดขนาดไฟล์โดยอาจทำให้คุณภาพของภาพหรือข้อมูลภาพที่คงไว้ลดลง

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

## **กำหนดรหัส ID คงที่ให้กับรูปร่างและข้อความ**

ใช้ [ISvgShapeFormattingController](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/isvgshapeformattingcontroller/) เพื่อตั้งค่า [ISvgShape::set_Id](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/isvgshape/set_id/) สำหรับแต่ละรูปร่าง SVG เพื่อกำหนดค่า [ISvgTSpan::set_Id](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/isvgtspan/set_id/) บนองค์ประกอบ `tspan` ของข้อความด้วย ให้ใช้งาน [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) ตัวควบคุมใดตัวหนึ่งพร้อมกับ [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/)

ตัวควบคุมต่อไปนี้ใช้ [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_officeinteropshapeid/) ซึ่งคงที่ตลอดอายุของรูปร่าง, และตัวนับที่ทำซ้ำได้สำหรับสแปนข้อความของมัน ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อไปของงานนำเสนอที่ไม่ได้เปลี่ยนแปลง

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

ใน [ISvgShapeFormattingController](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/isvgshapeformattingcontroller/) ให้เรียก [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/isvgshape/seteventhandler/) พร้อมค่าชนิด [SvgEvent](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปร่างที่ส่งออก กำหนดตัวควบคุมด้วย [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) แล้วกำหนดฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่โฮสต์ผลลัพธ์

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

หน้าโฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่อ้างอิงโดยตัวจัดการได้ การกำหนด ID และตัวจัดการเหตุการณ์ทำให้ตัวดูสไลด์, การเสริมการเข้าถึง, และกระบวนการ SVG แบบโต้ตอบอื่น ๆ ทำงานได้

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) แทน [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgexternalfontshandling/)?**

ใช้ [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) เมื่อข้อความทั้งหมดต้องเป็นอิสระจากแบบอักษร ใช้ [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/svgexternalfontshandling/) เมื่อเพียงข้อความที่ใช้แบบอักษรภายนอกควรแปลงเป็นกราฟิก

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดรูปภาพที่ฝังไว้, ลบส่วนภาพที่ถูกครอบ, และเลือกใช้ไฟล์แบบอักษรแบบลิงก์เมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการได้ทดสอบผลลัพธ์เนื่องจากการลดความละเอียดของภาพ, ลดคุณภาพ JPEG, และการแปลงเป็นเวกเตอร์ของข้อความแต่ละอย่างมีการแลกเปลี่ยนคุณภาพและขนาดที่แตกต่างกัน

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังการส่งออกได้หรือไม่?**

ได้ สามารถกำหนด ID ผ่านตัวควบคุมการจัดรูปแบบแล้วเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือประมวลผลต่อหรือตัวสคริปต์ในเบราว์เซอร์ของคุณ