---
title: แปลง PPT และ PPTX เป็น PDF ใน C++ [รวมฟีเจอร์ขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/cpp/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- PowerPoint เป็น PDF
- งานนำเสนอเป็น PDF
- PPT เป็น PDF
- แปลง PPT เป็น PDF
- PPTX เป็น PDF
- แปลง PPTX เป็น PDF
- บันทึก PowerPoint เป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- ไฟล์แนบ
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF ที่มีคุณภาพสูงและค้นหาได้ใน C++ ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน C++ มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการคงรักษาการจัดวางและรูปแบบของงานนำเสนอ คำแนะนำนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการใส่สไลด์ที่ซ่อนอยู่ การป้องกัน PDF ด้วยรหัสผ่าน การตรวจจับการแทนที่แบบอักษร การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานการปฏิบัติตามสำหรับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

To convert a presentation to PDF, pass the file name as an argument to the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class and then save the presentation as a PDF using a [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method. The [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class exposes the [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) method that is typically used to convert a presentation to PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides สำหรับ C++ ใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF, Aspose.Slides จะกรอกฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าที่มีรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถบังคับให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้.
{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยรับประกันว่า PDF ที่ได้จะตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ลิงก์
* หัวและท้าย
* สัญลักษณ์หัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF โดยใช้การตั้งค่าที่เหมาะที่สุดในระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าการส่งออกค่าเริ่มต้น

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose มีตัวแปลงออนไลน์ฟรี [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบกับตัวแปลงนี้เพื่อใช้งานตามขั้นตอนที่อธิบายไว้ที่นี่.
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกแบบกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—ที่ช่วยให้คุณปรับแต่ง PDF ที่ได้ ล็อก PDF ด้วยรหัสผ่าน หรือกำหนดวิธีการดำเนินกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีการจัดการ metafiles ตั้งค่าระดับการบีบอัดสำหรับข้อความกำหนดค่า DPI สำหรับภาพ และอื่น ๆ

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **คงไฟล์ OLE ที่ฝังไว้เป็นแนบ PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ที่ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF สามารถเข้าถึงข้อมูลของเวิร์กบุ๊กได้พร้อมกับดูสไลด์ เรียก [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) ด้วยค่า `true` เพื่อคงไฟล์ OLE ที่ฝังไว้เป็นแนบใน PDF ที่ได้

ค่าเริ่มต้นคือ `false`: ภาพตัวอย่างหรือไอคอนของวัตถุ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังไว้จะไม่ถูกใส่เป็นแนบ การตั้งค่าเป็น `true` จะเพิ่มไฟล์ข้อมูลเข้าไป ตัวอย่างยังคงเป็นการแสดงภาพ; แนบช่วยให้ผู้รับเปิดหรือบันทึกไฟล์ที่ฝังไว้แยกจากกัน วัตถุ OLE จะไม่กลายเป็นแผ่นงาน Excel แบบโต้ตอบบนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

เพื่อตรวจสอบผลลัพธ์:

1. เปิด PDF ที่ส่งออกในโปรแกรมดูที่สนับสนุนไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมดูและค้นหาเวิร์กบุ๊กที่ฝังไว้
3. บันทึกไฟล์แนบแล้วเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมดูอนุญาต การแสดงตัวอย่างบนหน้า PDF แยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A กำหนดข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A-1 ห้ามไฟล์ฝัง, PDF/A-2 อนุญาตให้มีไฟล์แนบ PDF/A เท่านั้น, และ PDF/A-3 อนุญาตประเภทไฟล์อื่นรวมถึงเวิร์กบุ๊ก Excel นี่เป็นข้อกำหนดของมาตรฐาน ไม่ใช่ข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF ค่าเริ่มต้นและไม่ได้สาธิตการส่งออก PDF/A
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) ของคลาส [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่เป็นหน้าต่าง PDF ที่ได้

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **แปลง PowerPoint เป็น PDF ที่ป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงรวมถึงการพิมพ์ รวมถึงการพิมพ์คุณภาพสูง

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **ตรวจจับการแทนที่แบบอักษร**

Aspose.Slides ให้เมธอด [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) เพื่อให้คุณตรวจจับการแทนที่แบบอักษรในระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่แบบอักษร ดูบทความ [การแทนที่แบบอักษร](/slides/th/cpp/font-substitution/)
{{% /alert %}} 

### **จัดการแบบอักษรที่ไม่มีฟอนต์หนาเฉพาะ**

งานนำเสนออาจใช้การจัดรูปแบบเป็นหนาแม้ว่าแบบอักษรจะไม่มีฟอนต์หนาเฉพาะ ตัวอักษรยังคงปรากฏเป็นหนาโดยการทำให้หนาแบบสังเคราะห์ ซึ่งทำให้ glyph ปกติหนาขึ้น หากข้อความนั้นดูหนามากเกินไปหรือดูแตกต่างจากที่ต้องการใน PDF ให้ลองเรียก [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) ด้วยค่า `true` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิตแมพในระหว่างการส่งออก PDF และอาจทำให้การแสดงผลดีขึ้นสำหรับแบบอักษรบางตัว ค่าเริ่มต้นคือ `false`

ตัวอย่างงานนำเสนอมีสองกล่องข้อความ: หนึ่งที่มีข้อความปกติและหนึ่งที่มีการจัดรูปแบบเป็นหนาสำหรับแบบอักษรเดียวกันที่ไม่มีฟอนต์หนาเฉพาะ ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เปิดการแรสเตอร์ฟอนต์ที่ไม่สนับสนุนและส่งออกเป็น PDF:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

ตัวอย่างต่อไปนี้แสดงผลลัพธ์ที่ปิดการใช้งานและเปิดการใช้งาน ในตัวอย่างนี้ข้อความหนามีเส้นหนากว่าตัวเลือกที่ปิดการใช้งาน เมื่อเปิดใช้งานเส้นจะบางลง; ข้อความปกติไม่มีการเปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนเลือกการตั้งค่าสำหรับงานนำเสนอของคุณ

| ตัวเลือกปิดการใช้งาน (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิดการใช้งาน (`true`) |
|---|---|
| ![PDF ที่มีการแรสเตอร์ฟอนต์สไตล์ที่ไม่สนับสนุนที่ปิดการใช้งาน](unsupported-bold-disabled.png) | ![PDF ที่มีการแรสเตอร์ฟอนต์สไตล์ที่ไม่สนับสนุนที่เปิดการใช้งาน](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดใช้ตัวเลือกจะทำให้ข้อความหนาเท่านั้นกลายเป็นบิตแมพ: ไม่สามารถเลือก, คัดลอก หรือค้นหาเป็นข้อความได้โดยไม่มี OCR และขอบจะดูอ่อนลงเมื่อซูม 800 % ข้อความปกติยังคงสามารถค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองสตริงยังคงเป็นข้อความ

ตัวเลือกนี้ทำให้ข้อความที่จัดรูปแบบเป็นหนาเมื่อแบบอักษรไม่มีฟอนต์หนาเฉพาะถูกแรสเตอร์ [การแทนที่แบบอักษร](/slides/th/cpp/font-substitution/) จะเลือกแบบอักษรอื่นเมื่อแบบอักษรต้นฉบับไม่พร้อมใช้งาน

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF ตัวเลขสไลด์ในอาเรย์นี้นับจาก 1 และงานนำเข้าต้องมีสไลด์อย่างน้อยสามสไลด์

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเข้าไปยังงานนำเสนอใหม่ที่มีขนาดสไลด์ 612 × 792 points (8.5 × 11 inches) ปรับขนาดเนื้อหาให้พอดีและส่งออกสไลด์เดียวเป็น PDF

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางบันทึกย่อยของผู้พูดใต้สไลด์แต่ละสไลด์ ใช้งานนำเสนอที่มีบันทึกย่อยเพื่อดูผลลัพธ์

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [แนวทางการเข้าถึงเนื้อหาเว็บ (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานการปฏิบัติตามใดก็ได้ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ด C++ นี้สาธิตกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่ต่างกัน:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose.Slides รองรับการแปลง PDF โดยสามารถแปลงไฟล์ PDF ไปยังรูปแบบไฟล์ยอดนิยมต่าง ๆ คุณสามารถทำ [PDF เป็น HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF เป็นภาพ](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDFเป็น JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), และ [PDFเป็น PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) นอกจากนี้ยังรองรับการแปลง PDF ไปยังรูปแบบเฉพาะอื่น ๆ เช่น [PDFเป็น SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDFเป็น TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), และ [PDFเป็น XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)
{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides ปฏิบัติกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปเดียว ส่วนองค์ประกอบเส้นทางแยกต่างหากจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกมาร์คเป็น artifacts; ข้อความแทนจะมีให้เฉพาะรูปทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF อย่างเป็นกลุ่มได้หรือไม่?**

ใช่, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและดำเนินการแปลงโดยอัตโนมัติได้

**เป็นไปได้หรือไม่ที่จะป้องกัน PDF ที่แปลงแล้วด้วยรหัสผ่าน?**

ได้. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) เพื่อกำหนดรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**ฉันจะรวมสไลด์ที่ซ่อนอยู่ใน PDF อย่างไร?**

ใช้เมธอด [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) และ [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**

ใช่, Aspose.Slides อนุญาตให้คุณส่งออกรายงาน PDF ที่สอดคล้องกับมาตรฐานต่าง ๆ รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามข้อกำหนดการเข้าถึงและการเก็บถาวร

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for C++ Documentation](/slides/th/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)