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
- เอกสารแนบ
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่สามารถค้นหาได้ใน C++ ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่เร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน C++ มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษาเค้าโครงและรูปแบบของงานนำเสนอของคุณ คู่มือนี้จะแสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของรูปภาพ รวมถึงการรวมสไลด์ที่ซ่อนอยู่ การตั้งรหัสผ่านให้ไฟล์ PDF การตรวจจับการแทนที่แบบอักษร การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานความเข้ากันได้กับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้กับคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF โดยใช้เมธอด [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) คลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) จะเปิดเผยเมธอด [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) ซึ่งโดยทั่วไปใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ จะใส่ข้อมูล API และหมายเลขเวอร์ชันของมันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF, Aspose.Slides จะกรอกฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าที่มีรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** คุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือทำลบข้อมูลนี้จากเอกสารผลลัพธ์ได้.
{{% /alert %}}

Aspose.Slides ให้คุณแปลง:
* การแปลงงานนำเสนอทั้งหมดเป็น PDF
* การแปลงสไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ไฟล์ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้ชิด องค์ประกอบและแอตทริบิวต์ต่าง ๆ จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:
* รูปภาพ
* กล่องข้อความและรูปทรง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* สัญลักษณ์หัวข้อย่อย
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF ตามมาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF โดยใช้การตั้งค่าที่เหมาะสมที่สุดที่ระดับคุณภาพสูงสุด

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
Aspose มีเครื่องมือแปลง PowerPoint เป็น PDF ออนไลน์ฟรี [**เครื่องมือแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทำการทดสอบกับเครื่องมือนี้เพื่อดูการใช้งานจริงของขั้นตอนที่อธิบายไว้ที่นี่.
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกแบบกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—ที่ให้คุณปรับแต่ง PDF ผลลัพธ์ ล็อก PDF ด้วยรหัสผ่าน หรือกำหนดวิธีที่กระบวนการแปลงควรดำเนินต่อไป

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีการจัดการ metafiles ตั้งค่าระดับการบีบอัดสำหรับข้อความ กำหนด DPI สำหรับภาพ และอื่น ๆ

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

### **เลือกการบีบอัดภาพอัตโนมัติ**

เมื่องานนำเสนอมีรูปถ่ายหรือสกรีนช็อตจำนวนมาก การลดขนาดของ PDF ที่ส่งออกสามารถทำให้ส่งอีเมลหรือดาวน์โหลดได้ง่ายขึ้น เรียกใช้เมธอด [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) พร้อมค่า `true` เพื่อเลือกอัลกอริธึมการบีบอัดที่เหมาะสมที่สุดสำหรับแต่ละภาพโดยอัตโนมัติในระหว่างการส่งออก PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีอยู่แล้ว เปิดใช้งานการเลือกการบีบอัดภาพอัตโนมัติ และบันทึกเป็นเอกสาร PDF การตั้งค่าการส่งออก PDF อื่น ๆ ทั้งหมดจะคงค่าเริ่มต้นไว้

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

ตัวเลือกนี้เลือกอัลกอริธึมการบีบอัดสำหรับแต่ละภาพ การลดคุณภาพ JPEG ด้วยเมธอด [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) จะทำให้คุณภาพภาพ JPEG ลดลง ในขณะที่การลดความละเอียดด้วยเมธอด [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) จะทำให้ภาพถูกลดความละเอียดลง ซึ่งอาจทำให้รายละเอียดลดลง การเปิดใช้งานการเลือกการบีบอัดอัตโนมัติไม่ได้ทำให้การตั้งค่าเหล่านี้ลดลงเอง

การเลือกอัลกอริธึมการบีบอัดภาพต้องใช้เวลาและหน่วยความจำการประมวลผลเพิ่ม ขนาดการลดลงขึ้นอยู่กับภาพในงานนำเสนอและการตั้งค่าการส่งออก; การลดขนาดแบบคงที่ไม่สามารถรับประกันได้สำหรับทุกงานนำเสนอ

### **เก็บไฟล์ OLE ที่ฝังเป็นแนบ PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ที่ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF สามารถเข้าถึงข้อมูลของเวิร์กบุ๊กได้พร้อมกับดูสไลด์ เรียกเมธอด [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) พร้อมค่า `true` เพื่อเก็บไฟล์ OLE ที่ฝังเป็นแนบใน PDF ที่ได้

ค่าดีฟอลต์คือ `false`: ภาพตัวอย่างหรือไอคอนของวัตถุ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังอยู่จะไม่ถูกแนบ การตั้งค่าตัวเลือกเป็น `true` จะเพิ่มการแนบข้อมูลไฟล์ ภาพตัวอย่างยังคงเป็นการแสดงผลเชิงภาพ; การแนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ที่ฝังแยกออกมาได้ วัตถุ OLE จะไม่กลายเป็นเวิร์กชีต Excel ที่โต้ตอบได้บนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วและส่งออกเป็น PDF โดยแนบเวิร์กบุ๊ก

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

1. เปิด PDF ที่ส่งออกในโปรแกรมดูที่รองรับการแนบไฟล์ เช่น Adobe Acrobat Reader  
2. เปิดแผง **Attachments** ของโปรแกรมดูและค้นหาเวิร์กบุ๊กที่ฝังอยู่  
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมดูอนุญาต การแสดงตัวอย่างบนหน้า PDF แยกจากไฟล์แนบ  

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A กำหนดข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A-1 ห้ามไฟล์ที่ฝังอยู่, PDF/A-2 อนุญาตเฉพาะไฟล์แนบ PDF/A, และ PDF/A-3 อนุญาตไฟล์ประเภทอื่นรวมถึงเวิร์กบุ๊ก Excel สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ใช่ข้อจำกัดเฉพาะของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออก PDF/A
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) จากคลาส [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าต่างใน PDF ที่ได้

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

### **แปลง PowerPoint เป็น PDF ที่ตั้งรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงอนุญาตให้พิมพ์ รวมถึงการพิมพ์คุณภาพสูง

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

Aspose.Slides มีเมธอด [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ใต้คลาส [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) ที่ทำให้คุณสามารถตรวจจับการแทนที่ฟอนท์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่ฟอนท์ไปยังคอนโซล คำเตือนจะถูกพิมพ์เฉพาะเมื่อฟอนท์ที่ไม่พร้อมใช้งานถูกแทนที่ในระหว่างการส่งออก

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

### **จัดการแบบอักษรที่ไม่มีตัวหนาเฉพาะ**

งานนำเสนอสามารถใช้การจัดรูปแบบเป็นตัวหนากับข้อความได้แม้ว่าฟอนท์จะไม่มีตัวหนาเฉพาะ การแสดงผลอาจยังดูเป็นตัวหนาโดยใช้การทำตัวหนาสังเคราะห์ ซึ่งทำให้ glyph ปกติหนาขึ้น หากข้อความนั้นดูหนามากเกินไปหรือแตกต่างจากลักษณะที่ต้องการใน PDF ให้ลองเรียกเมธอด [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) พร้อมค่า `true` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิทแมพระหว่างการส่งออก PDF และอาจปรับปรุงลักษณะของฟอนท์บางตัว ค่าเริ่มต้นคือ `false`

ตัวอย่างงานนำเสนอมีสองกล่องข้อความ: กล่องหนึ่งมีข้อความปกติและอีกกล่องมีการจัดรูปแบบตัวหนาใช้ฟอนท์เดียวกันที่ไม่มีตัวหนาเฉพาะ ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เปิดการ rasterization ของรูปแบบฟอนท์ที่ไม่รองรับ และส่งออกเป็น PDF:

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

ภาพตัวอย่างต่อไปนี้แสดงผลลัพธ์ที่ปิดและเปิดตัวเลือก ในตัวอย่างนี้ข้อความตัวหนามีเส้นหนากว่าเมื่อปิดตัวเลือก เมื่อเปิดตัวเลือก เส้นของข้อความตัวหนาจะเบาขึ้น; ข้อความปกติคงเหมือนเดิม เปรียบเทียบผลลัพธ์ก่อนตัดสินใจตั้งค่าสำหรับงานนำเสนอของคุณ

| ตัวเลือกปิด (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`true`) |
|---|---|
| ![PDF ที่ rasterization สไตล์ฟอนท์ที่ไม่รองรับถูกปิด](unsupported-bold-disabled.png) | ![PDF ที่ rasterization สไตล์ฟอนท์ที่ไม่รองรับถูกเปิด](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดตัวเลือกทำให้ข้อความตัวหนาเท่านั้นแปลงเป็นบิทแมพ: ไม่สามารถเลือก คัดลอก หรือค้นหาเป็นข้อความได้หากไม่มี OCR และขอบของข้อความดูอ่อนลงที่การซูม 800% ข้อความปกติยังคงค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองสตริงจะยังคงเป็นข้อความ

ตัวเลือกนี้ทำการ rasterize ข้อความที่จัดรูปแบบเป็นตัวหนาเมื่อฟอนท์ไม่มีตัวหนาเฉพาะ [การแทนที่แบบอักษร](/slides/th/cpp/font-substitution/) จะเลือกฟอนท์อื่นเมื่อฟอนท์ต้นฉบับไม่พร้อมใช้งาน

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF ตัวเลขสไลด์ในอาร์เรย์นี้เริ่มจาก 1 และงานนำเข้าต้องมีอย่างน้อยสามสไลด์

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

## **แปลง PowerPoint เป็น PDF พร้อมขนาดสไลด์กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเสนอไปยังงานนำเสนอใหม่ที่มีขนาดสไลด์ 612 × 792 จุด (8.5 × 11 นิ้ว) จะปรับขนาดเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF

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

## **แปลง PowerPoint เป็น PDF ในมุมมองบันทึกสไลด์**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางบันทึกของผู้พูดของแต่ละสไลด์ด้านล่างสไลด์ ใช้งานนำเสนอที่มีบันทึกผู้พูดเพื่อดูผลลัพธ์

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

Aspose.Slides ให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานการปฏิบัติตามใดก็ได้ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ด C++ นี้แสดงกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:

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
Aspose.Slides สนับสนุนการดำเนินการแปลง PDF ให้สามารถแปลงไฟล์ PDF ไปเป็นรูปแบบไฟล์ยอดนิยมได้ คุณสามารถทำการแปลง [PDF เป็น HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF เป็นรูปภาพ](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF เป็น JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), และ [PDF เป็น PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) ได้ การดำเนินการแปลง PDF ไปเป็นรูปแบบเฉพาะอื่น ๆ — [PDF เป็น SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF เป็น TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), และ [PDF เป็น XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — ก็ได้รับการสนับสนุนเช่นกัน.
{{% /alert %}}

**หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะจัดการกราฟิกที่ซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปเดียว ส่วนองค์ประกอบเส้นทางแต่ละอันจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกระบุเป็นสิ่งของที่ไม่ได้ใช้; ข้อความทดแทนจะมีเฉพาะสำหรับรูปทั้งหมด

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นชุดได้หรือไม่?**  
ใช่, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและประยุกต์ใช้กระบวนการแปลงโดยโปรแกรม

**สามารถตั้งรหัสผ่านให้กับ PDF ที่แปลงแล้วได้หรือไม่?**  
ได้. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) เพื่อกำหนดรหัสผ่านและกำหนดสิทธิ์การเข้าถึงในระหว่างกระบวนการแปลง

**ฉันจะรวมสไลด์ที่ซ่อนอยู่ใน PDF ได้อย่างไร?**  
ใช้เมธอด [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถคงคุณภาพภาพสูงใน PDF ได้หรือไม่?**  
ได้, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) และ [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**  
ใช่, Aspose.Slides ให้คุณส่งออก PDF ที่สอดคล้องกับมาตรฐานต่าง ๆ รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณเป็นไปตามข้อกำหนดการเข้าถึงและการจัดเก็บรักษา

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides สำหรับ C++](/slides/th/cpp/)
- [อ้างอิง API Aspose.Slides สำหรับ C++](https://reference.aspose.com/slides/cpp/)
- [เครื่องแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)