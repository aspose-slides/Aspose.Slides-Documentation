---
title: แปลง PPT และ PPTX เป็น PDF ใน C++ [รวมคุณลักษณะขั้นสูง]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูง สามารถค้นหาได้ใน C++ ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่เร็วและตัวเลือกการแปลงขั้นสูง."
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) ไปเป็นรูปแบบ PDF ใน C++ มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้บนอุปกรณ์ต่างๆ และการคงรูปแบบและการจัดหน้าของงานนำเสนอของคุณ คู่มือนี้จะแสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่างๆ เพื่อควบคุมคุณภาพภาพ รวมถึงการรวมสไลด์ที่ซ่อนอยู่ การตั้งรหัสผ่านสำหรับไฟล์ PDF การตรวจจับการแทนที่แบบอักษร การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานความสอดคล้องกับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

ใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) จากนั้นบันทึกงานนำเสนอเป็น PDF โดยใช้เมธอด `Save` คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เปิดเผยเมธอด `Save` ที่ปกติใช้สำหรับแปลงงานนำเสนอเป็น PDF

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ แทรกข้อมูล API และหมายเลขเวอร์ชันของตนลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides จะใส่ค่าในฟิลด์ Application เป็น "*Aspose.Slides*" และฟิลด์ PDF Producer เป็นค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ**ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือ Removes ข้อมูลนี้จากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* ภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* หัวเรื่องและท้ายกระดาษ
* สัญลักษณ์หัวข้อย่อย
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint‑to‑PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ระบุเป็น PDF โดยใช้การตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 

Aspose มีเครื่องมือแปลง [**PowerPoint to PDF converter**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf) ออนไลน์ฟรีที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทำการทดสอบด้วยเครื่องมือนี้เพื่อดูการดำเนินการตามขั้นตอนที่อธิบายไว้ที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides ให้ตัวเลือกกำหนดเอง—คุณสมบัติต่างๆ ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/)—ที่ช่วยให้คุณปรับแต่ง PDF ผลลัพธ์ ล็อก PDF ด้วยรหัสผ่าน หรือกำหนดวิธีการดำเนินกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับรูปภาพเรเดอร์ ระบุวิธีการจัดการเมตาไฟล์ กำหนดระดับการบีบอัดสำหรับข้อความ ตั้งค่า DPI สำหรับรูปภาพ และอื่นๆ

ตัวอย่างโค้ดด้านล่างแสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเองหลายรายการ

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// ตั้งค่าคุณภาพสำหรับภาพ JPG.
pdfOptions->set_JpegQuality(90);

// ตั้งค่า DPI สำหรับภาพ.
pdfOptions->set_SufficientResolution(300);

// ตั้งค่าพฤติกรรมสำหรับเมตาไฟล์.
pdfOptions->set_SaveMetafilesAsPng(true);

// ตั้งค่าระดับการบีบอัดข้อความสำหรับเนื้อหาข้อความ.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// กำหนดโหมดความสอดคล้องของ PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// บันทึกงานนำเสนอเป็นเอกสาร PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [set_ShowHiddenSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) จากคลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่เป็นหน้ากระดาษใน PDF ผลลัพธ์

โค้ด C++ นี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมรวมสไลด์ที่ซ่อนอยู่:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// สร้างอินสแตนซ์ของคลาส PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// เพิ่มสไลด์ที่ซ่อนอยู่.
pdfOptions->set_ShowHiddenSlides(true);

// บันทึกงานนำเสนอเป็น PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **แปลง PowerPoint เป็น PDF ที่มีการตั้งรหัสผ่าน**

โค้ด C++ นี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF ที่มีการตั้งรหัสผ่านโดยใช้พารามิเตอร์การป้องกันจากคลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/) :

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// สร้างอินสแตนซ์ของคลาส PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// ตั้งรหัสผ่าน PDF และสิทธิ์การเข้าถึง.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// บันทึกงานนำเสนอเป็น PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **ตรวจจับการแทนที่แบบอักษร**

Aspose.Slides มีเมธอด [set_WarningCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/) ซึ่งช่วยให้คุณตรวจจับการแทนที่แบบอักษรระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

โค้ด C++ นี้แสดงวิธีการตรวจจับการแทนที่แบบอักษร:

```c++
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

// การทำงานของคอลแบ็กคำเตือน.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss &&
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // ตั้งค่าคอลแบ็กคำเตือนในตัวเลือก PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // บันทึกงานนำเสนอเป็น PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการรับคอลแบ็กสำหรับการแทนที่แบบอักษรระหว่างขั้นตอนการเรนเดอร์ ดู [Getting Warning Callbacks for Fonts Substitution](/slides/th/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)  

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่แบบอักษร ดูบทความ [Font Substitution](/slides/th/cpp/font-substitution/)

{{% /alert %}} 

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

โค้ด C++ นี้แสดงวิธีการแปลงเฉพาะสไลด์ที่เลือกจากงานนำเสนอ PowerPoint เป็น PDF:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Set array of slide numbers.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Save the presentation as a PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

โค้ด C++ นี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่ระบุ:

```C++
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

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// สร้างงานนำเสนอใหม่ด้วยขนาดสไลด์ที่ปรับแล้ว.
auto resizedPresentation = MakeObject<Presentation>();

// ตั้งค่าขนาดสไลด์แบบกำหนดเอง.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// คัดลอกสไลด์แรกจากงานนำเสนอเดิม.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// บันทึกงานนำเสนอที่ปรับขนาดเป็น PDF พร้อมบันทึกโน้ต.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึก**

โค้ด C++ นี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF ที่รวมบันทึกไว้ด้วย:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// กำหนดค่าตัวเลือก PDF ด้วยการจัดวางโน้ต.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// บันทึกงานนำเสนอเป็น PDF พร้อมโน้ต.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **การเข้าถึงและมาตรฐานความสอดคล้องสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานความสอดคล้องใดก็ได้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ด C++ นี้แสดงกระบวนการแปลง PowerPoint‑to‑PDF ที่ผลิต PDF หลายไฟล์ตามมาตรฐานความสอดคล้องที่แตกต่างกัน:

```C++
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides รองรับการแปลง PDF ให้เป็นรูปแบบไฟล์ที่นิยม คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-png/) นอกจากนี้ยังรองรับการแปลง PDF ไปยังรูปแบบเฉพาะอื่นๆ —[PDF to SVG](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-xml/)— อีกด้วย

{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA Aspose.Slides จะจัดการกราฟิกซับซ้อน เช่น SmartArt, แผนภูมิ และสูตรเป็นรูปภาพเดียว ไม่คงส่วนประกอบของเส้นทางเป็นเนื้อหาแยกต่างหากและอาจถูกทำเครื่องหมายว่าเป็นสิ่งรบกวน; ข้อความแทนจะถูกให้เฉพาะสำหรับรูปภาพทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

### ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF พร้อมกันได้หรือไม่?

ใช่, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยโปรแกรมได้

### เป็นไปได้หรือไม่ที่จะตั้งรหัสผ่านให้กับ PDF ที่แปลงแล้ว?

แน่นอน ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงในระหว่างกระบวนการแปลง

### จะรวมสไลด์ที่ซ่อนอยู่ใน PDF อย่างไร?

ใช้เมธอด `set_ShowHiddenSlides` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ผลลัพธ์

### Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?

ใช่ คุณสามารถควบคุมคุณภาพภาพได้โดยใช้เมธอดเช่น `set_JpegQuality` และ `set_SufficientResolution` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

### Aspose.Slides รองรับมาตรฐานความสอดคล้อง PDF/A หรือไม่?

ใช่ Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับมาตรฐานต่างๆ รวมถึง PDF/A1a, PDF/A1b และ PDF/UA เพื่อให้เอกสารของคุณตอบสนองต่อความต้องการด้านการเข้าถึงและการจัดเก็บ

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides สำหรับ C++](/slides/th/cpp/)
- [อ้างอิง API Aspose.Slides สำหรับ C++](https://reference.aspose.com/slides/th/cpp/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/th/conversion)