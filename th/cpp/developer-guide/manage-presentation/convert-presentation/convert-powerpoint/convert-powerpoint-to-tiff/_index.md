---
title: แปลงการนำเสนอ PowerPoint เป็น TIFF ใน C++
titlelink: PowerPoint ไปเป็น TIFF
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
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดายโดยใช้ Aspose.Slides สำหรับ C++ พร้อมตัวอย่างโค้ด."
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพแรสเตอร์แบบไม่มีการสูญเสียที่ใช้กันอย่างกว้างขวาง โดยรู้จักในเรื่องคุณภาพยอดเยี่ยมและการรักษารายละเอียดของกราฟิกได้อย่างละเอียด นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้น, ความแม่นยำของสี, และการตั้งค่าเดิมในภาพของพวกเขา.

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) ของคุณเป็นภาพ TIFF มีคุณภาพสูงได้อย่างง่ายดาย ทำให้การนำเสนอของคุณคงคุณภาพภาพสูงสุด.

## **แปลงการนำเสนอเป็น TIFF**

โดยใช้เมธอด [Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) คุณสามารถแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้สอดคล้องกับขนาดสไลด์เริ่มต้น.

โค้ด C++ ตัวนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็น TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// บันทึกการนำเสนอเป็น TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **แปลงการนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [set_BwConversionMode](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/) ให้คุณกำหนดอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้จะใช้ได้เฉพาะเมื่อเมธอด [set_CompressionType](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) ตั้งค่าเป็น `CCITT4` หรือ `CCITT3`.

{{% alert color="info" title="หมายเหตุ" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) เป็นการตั้งค่าระดับการส่งออกที่เลือกอัลกอริทึมการแปลงพิกเซลสำหรับภาพ TIFF ทั้งหมด เพื่อกำหนดว่ารูปร่างแต่ละอันจะแสดงอย่างไรเมื่อโหมดแสดงผลขาว-ดำทำงาน ให้ใช้ [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_blackwhitemode/). ดูที่ [Control Black-and-White Rendering for Shapes](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) เพื่อดูตัวอย่าง.
{{% /alert %}}

สมมติเรามีไฟล์ "sample.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ด C++ ตัวนี้แสดงวิธีแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

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

## **แปลงการนำเสนอเป็น TIFF ด้วยขนาดกำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดกำหนดเอง คุณสามารถตั้งค่าที่ต้องการได้โดยใช้เมธอดต่าง ๆ ที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/). ตัวอย่างเช่นเมธอด [set_ImageSize](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_imagesize/) ให้คุณกำหนดขนาดของภาพที่ได้.

โค้ด C++ ตัวนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยขนาดกำหนดเอง:

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

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// ตั้งค่าชนิดการบีบอัด.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
ชนิดการบีบอัด:
    Default - ระบุแผนการบีบอัดเริ่มต้น (LZW).
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

## **แปลงการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพกำหนดเอง**

โดยใช้เมธอด [set_PixelFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) ของคลาส [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่สร้างขึ้นได้.

โค้ด C++ ตัวนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลกำหนดเอง:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat มีค่าดังต่อไปนี้ (ตามที่ระบุในเอกสาร):
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

{{% alert title="เคล็ดลับ" color="info" %}}
ลองใช้ [เครื่องแปลง PowerPoint ไปเป็นโปสเตอร์แบบฟรีของ Aspose](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ Aspose.Slides อนุญาตให้คุณแปลงสไลด์เดี่ยวจากการนำเสนอ PowerPoint หรือ OpenDocument เป็นภาพ TIFF แยกกันได้.

**มีข้อจำกัดใดเกี่ยวกับจำนวนสไลด์เมื่อแปลงการนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่ได้กำหนดข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงการนำเสนอขนาดใดก็ได้เป็นรูปแบบ TIFF.

**การแอนิเมชันและเอฟเฟกต์การเปลี่ยนผ่านของ PowerPoint จะถูกเก็บรักษาไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่ TIFF เป็นรูปแบบภาพนิ่ง ดังนั้นแอนิเมชันและเอฟเฟกต์การเปลี่ยนผ่านจะไม่ถูกเก็บรักษา มีเพียงการจับภาพของสไลด์แบบคงที่ที่ถูกส่งออกเท่านั้น.