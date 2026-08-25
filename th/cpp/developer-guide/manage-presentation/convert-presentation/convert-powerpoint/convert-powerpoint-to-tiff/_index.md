---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF ด้วย C++
titlelink: PowerPoint เป็น TIFF
type: docs
weight: 90
url: /th/cpp/convert-powerpoint-to-tiff/
keywords:
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น TIFF
- การนำเสนอเป็น TIFF
- สไลด์เป็น TIFF
- PPT เป็น TIFF
- PPTX เป็น TIFF
- บันทึก PPT เป็น TIFF
- บันทึก PPTX เป็น TIFF
- ส่งออก PPT เป็น TIFF
- ส่งออก PPTX เป็น TIFF
- C++
- Aspose.Slides
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงด้วย Aspose.Slides สำหรับ C++ อย่างง่าย พร้อมตัวอย่างโค้ด"
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพเรสเตอร์แบบไม่มีการสูญเสียข้อมูลที่ใช้กันอย่างกว้างขวางและเป็นที่รู้จักในคุณภาพที่ยอดเยี่ยมและการรักษารายละเอียดของกราฟิกอย่างละเอียด นักออกแบบ ช่างภาพ และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อคงรักษาชั้น สีที่แม่นยำ และการตั้งค่าเดิมของภาพ

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) เป็นภาพ TIFF ที่มีคุณภาพสูงได้อย่างง่ายดาย ทำให้การนำเสนอของคุณคงความคมชัดสูงสุด

## **แปลงการนำเสนอเป็น TIFF**

โดยใช้เมธอด [Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) ที่มาจากคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) คุณสามารถแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์ค่าเริ่มต้น

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **แปลงการนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [set_BwConversionMode](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/) ให้คุณระบุอัลกอริธึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [set_CompressionType](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`

{{% alert color="info" title="Note" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) เป็นการตั้งค่าระดับการส่งออกที่เลือกอัลกอริธึมการแปลงพิกเซลสำหรับภาพ TIFF ทั้งหมด เพื่อกำหนดว่ารูปร่างแต่ละอันควรแสดงอย่างไรเมื่อเปิดโหมดการแสดงผลขาว-ดำ ให้ใช้ [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_blackwhitemode/)。ดูตัวอย่างได้ที่ [Control Black-and-White Rendering for Shapes](/slides/th/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes)
{{% /alert %}}

สมมติว่าเรามีไฟล์ “sample.pptx” ที่มีสไลด์ดังต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ด C++ นี้แสดงวิธีแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

ผลลัพธ์:

![TIFF ขาว-ดำ](TIFF_black_and_white.png)

## **แปลงการนำเสนอเป็น TIFF พร้อมขนาดกำหนดเอง**

หากต้องการภาพ TIFF ที่มีขนาดเฉพาะคุณสามารถตั้งค่าที่ต้องการโดยใช้เมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/) ตัวอย่างเช่นเมธอด [set_ImageSize](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_imagesize/) จะให้คุณกำหนดขนาดของภาพผลลัพธ์

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// ตั้งค่าชนิดการบีบอัด.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
ประเภทการบีบอัด:
    Default - ระบุโครงสร้างการบีบอัดเริ่มต้น (LZW).
    None - ระบุว่าไม่มีการบีบอัด.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// ความลึกขึ้นอยู่กับชนิดการบีบอัดและไม่สามารถตั้งค่าได้ด้วยตนเอง.

// ตั้งค่า DPI ของภาพ.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// ตั้งค่าขนาดของภาพ.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// บันทึกการนำเสนอเป็น TIFF ด้วยขนาดที่ระบุ.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **แปลงการนำเสนอเป็น TIFF พร้อมรูปแบบพิกเซลของภาพกำหนดเอง**

โดยใช้เมธอด [set_PixelFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat มีค่าต่อไปนี้ (ตามที่ระบุในเอกสาร):
    Format1bppIndexed - 1 บิตต่อพิกเซล, แบบดัชนี.
    Format4bppIndexed - 4 บิตต่อพิกเซล, แบบดัชนี.
    Format8bppIndexed - 8 บิตต่อพิกเซล, แบบดัชนี.
    Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
    Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
*/

// บันทึกการนำเสนอเป็น TIFF ด้วยขนาดภาพที่ระบุ.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
ดูตัวแปลง [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) ของ Aspose
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ใช่ Aspose.Slides รองรับการแปลงสไลด์เดี่ยวจากการนำเสนอ PowerPoint หรือ OpenDocument เป็นภาพ TIFF แยกต่างหาก

**มีขีดจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์เมื่อแปลงการนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่จำกัดจำนวนสไลด์ คุณสามารถแปลงการนำเสนอขนาดใดก็ได้เป็นรูปแบบ TIFF

**แอนิเมชันและเอฟเฟกต์การเปลี่ยนของ PowerPoint จะถูกเก็บไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่ TIFF เป็นรูปแบบภาพนิ่ง ดังนั้นแอนิเมชันและเอฟเฟกต์การเปลี่ยนจะไม่ถูกเก็บไว้ มีเพียงภาพนิ่งของสไลด์ที่ถูกส่งออกเท่านั้น