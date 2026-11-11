---
title: เรนเดอร์สไลด์การพรีเซนเทชันเป็นภาพ SVG ใน C++
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint เป็น SVG
- การพรีเซนเทชันเป็น SVG
- สไลด์เป็น SVG
- PPT เป็น SVG
- PPTX เป็น SVG
- ตัวเลือกการส่งออก SVG
- SVG แบบโต้ตอบ
- PowerPoint
- การพรีเซนเทชัน
- C++
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน C++ และควบคุมแบบอักษร, ข้อความ, รูปภาพ, ID, และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG คือรูปแบบภาพ XML ที่ยืดหยุ่นได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวแสดงสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลหลังอัตโนมัติ Aspose.Slides for C++ จะส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ, แบบอักษร, รูปภาพ, และองค์ประกอบ SVG

ใช้ [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) เมื่อ SVG ที่ส่งออกต้องกะทัดรัด, คาดเดาได้ในหลายเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), เลือกสไลด์และเขียนลงสตรีม ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์

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

ชื่อไฟล์ใช้ [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) แทนดัชนีของลูป คุณยังสามารถส่งออกรูปร่างเดี่ยวด้วย [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) เมื่อผู้ดูสไลด์หรือหน้าเว็บต้องการเพียงรูปร่างนั้นเท่านั้น

## **กำหนดค่าเอาต์พุต SVG**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) ควบคุมการเรนเดอร์ SVG สำหรับกรอบข้อความ, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) จะรวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) กำหนดว่าจะนำการหมุนของกรอบมาปรับใช้หรือไม่ ตั้งค่า [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) เป็น `true` เมื่อข้อความต้องการเรนเดอร์โดยไม่มีลิแกเจอร์

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

## **ควบคุมการตัดส่วนปลายเส้นที่หัวศร**

SVG 1.1 ไม่มีตั้งค่าการแทรก marker เพื่อตั้งค่าตำแหน่งที่เส้นควรหยุดใต้หัวศร โดยค่าเริ่มต้น Aspose.Slides จะสั้นเส้นที่ส่งออกเพื่อไม่ให้เส้นขอบล่วงผ่าน marker ตั้งค่า [SVGOptions::set_DisableLineEndCropping](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablelineendcropping/) เป็น `true` เพื่อวาดเส้นขอบจนถึงจุดสิ้นสุดดั้งเดิมของเส้น การตั้งค่านี้ส่งผลต่อเอาต์พุต SVG เท่านั้น เส้นยังคงตำแหน่งและความยาวบนสไลด์

ตัวอย่างวาดหัวศรรูปสามเหลี่ยมและรูปเพชรบนเส้นกว้าง 2 และ 10 จุด ส่งออกสไลด์เดียวกันสองครั้ง โดยเปลี่ยนเฉพาะตัวเลือกการตัดเท่านั้น

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/ShapeType.h>
#include <Export/SVGOptions.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto y = 40;
const LineArrowheadStyle styles[] = { LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond };
const int widths[] = { 2, 10 };

for (auto style : styles)
{
    for (auto width : widths)
    {
        auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 40, y, 200, 0);
        auto format = line->get_LineFormat();
        format->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
        format->set_Width(width);
        format->set_EndArrowheadStyle(style);
        y += 50;
    }
}

auto options = MakeObject<SVGOptions>();
options->set_DisableLineEndCropping(false);
auto cropped = File::Create(u"cropped.svg");
slide->WriteAsSvg(cropped, options);
cropped->Dispose();

options->set_DisableLineEndCropping(true);
auto uncropped = File::Create(u"uncropped.svg");
slide->WriteAsSvg(uncropped, options);
uncropped->Dispose();

presentation->Dispose();
```

เปรียบเทียบแสดงหัวศรรูปสามเหลี่ยมบนเส้น 10 จุด เมื่อเปิดการตัด จะเห็นปลายแหลม เมื่อปิดการตัด เส้นขอบจะลุดผ่านด้านเอียงของ marker แล้วเหลือปลายแบน

![สามเหลี่ยมขนาด 10 จุดที่ขยายพร้อมปลายแหลมเมื่อเปิดการตัดและปลายแบนเมื่อปิดการตัด](line-end-cropping.png)

ในเส้นอื่นจากตัวอย่าง เส้นขอบที่ลุดจะมองเห็นได้น้อยกว่าในหัวศรรูปสามเหลี่ยม 2 จุด เพชรที่เต็มสีครอบส่วนปลายของเส้นขอบทั้งสองความกว้าง

## **ควบคุมข้อความและแบบอักษร**

เมื่อส่งออกสไลด์เป็น SVG คุณสามารถควบคุมว่าข้อความจะคงเป็นข้อความหรือแปลงเป็นกราฟิกเวกเตอร์, และวิธีการรวมหรืออ้างอิงแบบอักษรภายนอก ตัวเลือกต่อไปนี้ช่วยให้คุณสมดุลความสอดคล้องของภาพ, ความสามารถในการเลือกข้อความ, และการพึ่งพาแบบอักษรใน SVG ที่ส่งออก

### **ทำให้ข้อความทั้งหมดเป็นเวกเตอร์**

ตั้งค่า [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) เป็น `true` เพื่อเขียนข้อความสไลด์ทั้งหมดเป็นกราฟิกเวกเตอร์ สิ่งนี้ขจัดการพึ่งพาแบบอักษรและทำให้ผลลัพธ์ภาพคงที่ในหลายเบราว์เซอร์, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาได้ในรูปแบบ SVG อีกต่อไป

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

### **เลือกวิธีจัดการแบบอักษรภายนอก**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) สำหรับแบบอักษรที่โหลดจากภายนอก เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์แบบอักษรแยกไฟล์, `Embed` เพื่อฝังข้อมูลแบบอักษรใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์ข้อความที่ใช้แบบอักษรภายนอกจากเป็นกราฟิก ตรวจสอบการอนุญาตใช้แบบอักษรก่อนฝัง

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

## **ลดขนาดรูปภาพที่ฝังอยู่**

ใช้ [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) เพื่อลดความละเอียดของรูปภาพที่ฝัง, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) เพื่อตัดส่วนที่ถูกครอปออก, และ [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG การตั้งค่าเหล่านี้ลดขนาดไฟล์โดยเสียคุณภาพภาพหรือข้อมูลรูปภาพที่เก็บไว้

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

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) กำหนดขีดจำกัดความละเอียดต่ำสุดสำหรับการแปลง Metafile ให้เป็นภาพพิกเซลระหว่างการส่งออก SVG ใช้เพื่อสมดุลรายละเอียดและขนาดไฟล์เมื่อภาพ EMF หรือ WMF ถูกแปลงเป็นภาพพิกเซล มันไม่ได้กำหนด DPI ทั้งหมดสำหรับ SVG หรือบังคับให้ทุกอ็อบเจ็กต์บนสไลด์กลายเป็นภาพราสเตอร์

ดาวน์โหลด [metafile-rasterization.pptx](metafile-rasterization.pptx) ซึ่งมีภาพ EMF ที่มีเส้นทแยงมุมห่างกันอย่างใกล้ชิด ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์นั้นด้วยความละเอียดการเรสเตอร์ไลซ์สามระดับผ่าน [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/) การตั้งค่าอื่น ๆ ของการส่งออกทั้งหมดคงเดียวกันเพื่อให้สามารถเปรียบเทียบผลลัพธ์ได้

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

ในผลลัพธ์ EMF จะถูกฝังเป็น PNG หนึ่งไฟล์ในแต่ละ SVG การวัดต่อไปนี้เป็นของงานนำเสนอที่ให้มา; ไม่ใช่สูตรทั่วไปสำหรับแปลง DPI ไปเป็นขนาดพิกเซล

| ความละเอียดการเรสเตอร์ไลซ์ Metafile (DPI) | ขนาด PNG ที่ฝัง | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงพื้นที่เดียวกันของภาพราสเตอร์ที่ฝังโดยขนาดการแสดงผลที่ขยายเดียวกัน เส้นทแยงมุมจะแสดงเป็นพิกเซลชัดที่ 72 DPI และขอบเรียบขึ้นที่ความละเอียดสูงขึ้น ในขณะเดียวกันไฟล์ SVG จะใหญ่ขึ้น การเพิ่มค่าดังกล่าวไม่ได้หมายความว่าจะปรับปรุงทุกรายละเอียดหรือเปลี่ยนภาพที่ส่งออกทั้งหมด

![รายละเอียดเส้นทแยงมุมที่ขยายที่ DPI 72, 150, และ 300](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) ควบคุมการลดความละเอียดของภาพและอาจทำให้ผลของการเปลี่ยนความละเอียดการเรสเตอร์ไลซ์ Metafile ถูกซ่อน [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) ควบคุมคุณภาพการเข้ารหัส JPEG ไม่ใช่ความละเอียดการเรสเตอร์ไลซ์ Metafile

## **กำหนด ID คงที่ให้กับรูปร่างและข้อความ**

ใช้ [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) เพื่อกำหนด [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) ให้กับแต่ละรูปร่าง SVG เพื่อกำหนดค่า [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) บนองค์ประกอบ `tspan` ของข้อความด้วย ให้ใช้ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/) แล้วกำหนดตัวควบคุมด้วย [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/)

ตัวควบคุมต่อไปนี้ใช้ [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/) ซึ่งคงที่ตลอดอายุของรูปร่าง และตัวนับที่ทำซ้ำได้สำหรับสแปนข้อความ ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อไปของงานนำเสนอที่ไม่ได้เปลี่ยนแปลง

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

ใน [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) ให้เรียก [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) พร้อมค่าของ [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปร่างที่ส่งออก กำหนดตัวควบคุมด้วย [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) และนิยามฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่โฮสต์ผลลัพธ์

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

หน้าโฮสต์สามารถนิยามฟังก์ชัน JavaScript ที่อ้างอิงโดยตัวจัดการได้ การกำหนด ID และตัวจัดการเหตุการณ์ทำให้ผู้ดูสไลด์, การเสริมการเข้าถึง, และกระบวนการ SVG แบบโต้ตอบอื่น ๆ ทำงานได้

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) แทน [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)?**

ใช้ [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) เมื่อข้อความทั้งหมดต้องเป็นอิสระจากแบบอักษร ใช้ [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) เมื่อต้องการแปลงเป็นกราฟิกเฉพาะข้อความที่ใช้แบบอักษรภายนอกเท่านั้น

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดรูปภาพที่ฝังอยู่, ลบส่วนภาพที่ถูกครอป, และเลือกการอ้างอิงไฟล์แบบอักษรเมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการไฟล์เหล่านั้นได้ ทดสอบผลลัพธ์เนื่องจากการลดความละเอียดภาพ, ลดคุณภาพ JPEG, และการทำให้ข้อความเป็นเวกเตอร์แต่ละอย่างมีข้อแลกเปลี่ยนด้านคุณภาพและขนาดที่ต่างกัน

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังการส่งออกได้หรือไม่?**

ได้ คุณสามารถกำหนด ID ผ่านตัวควบคุมการฟอร์แมต แล้วเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือประมวลผลหลังหรือสคริปต์ของเบราว์เซอร์ของคุณ