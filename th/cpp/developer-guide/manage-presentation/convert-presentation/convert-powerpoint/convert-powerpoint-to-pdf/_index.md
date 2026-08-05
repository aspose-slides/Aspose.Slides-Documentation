---
title: แปลง PPT และ PPTX เป็น PDF ใน C++ [รวมฟีเจอร์ขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/cpp/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- PowerPoint เป็น PDF
- การนำเสนอเป็น PDF
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
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่สามารถค้นหาได้ใน C++ ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่เร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงการนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ด้วย C++ มีประโยชน์หลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษารูปแบบและการจัดเรียงของการนำเสนอ คู่มือนี้จะแสดงวิธีการแปลงการนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการใส่สไลด์ที่ซ่อนอยู่ การตั้งรหัสผ่านให้ไฟล์ PDF การตรวจจับการแทนที่ฟอนต์ การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานการปฏิบัติตามสำหรับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

ใช้ Aspose.Slides คุณสามารถแปลงการนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงการนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ไปยังคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)แล้วบันทึกการนำเสนอเป็น PDF โดยใช้เมธอด`Save` คลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)เปิดเผยเมธอด`Save`ที่โดยทั่วไปใช้เพื่อแปลงการนำเสนอเป็น PDF

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ จะใส่ข้อมูล API และหมายเลขเวอร์ชันของตนลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงการนำเสนอเป็น PDF Aspose.Slides จะเติมฟิลด์ Application ด้วย"*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าในรูปแบบ"*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนแปลงหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* การนำเสนอเต็มรูปแบบเป็น PDF
* สไลด์เฉพาะจากการนำเสนอเป็น PDF

Aspose.Slides ส่งออกการนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้มีความคล้ายคลึงกับการนำเสนอเดิมมากที่สุด รายการและแอตทริบิวต์ต่าง ๆ จะถูกเรนเดอร์อย่างถูกต้องในระหว่างการแปลง รวมถึง:

* ภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดสัญลักษณ์
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงการนำเสนอที่ระบุเป็น PDF โดยใช้การตั้งค่าที่เหมาะที่สุดในระดับคุณภาพสูงสุด

ตัวอย่างโค้ด C++ นี้แสดงวิธีการแปลงการนำเสนอ (PPT, PPTX, ODP ฯลฯ) เป็น PDF:

```c++
// สร้างออบเจกต์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// บันทึกการนำเสนอเป็นไฟล์ PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose มี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf) ออนไลน์ฟรีที่สาธิตกระบวนการแปลงการนำเสนอเป็น PDF คุณสามารถทดสอบกับตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides ให้ตัวเลือกกำหนดเอง—พร็อพเพอร์ตี้ภายใต้คลาส[PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/)—ที่ช่วยให้คุณปรับแต่ง PDF ที่ได้ ล็อก PDF ด้วยรหัสผ่าน หรือกำหนดวิธีการดำเนินกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเอง**

โดยใช้ตัวเลือกการแปลงกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีการจัดการเมตาไฟล์ ตั้งระดับการบีบอัดสำหรับข้อความ กำหนด DPI สำหรับภาพ ฯลฯ

ตัวอย่างโค้ดด้านล่างแสดงวิธีการแปลงการนำเสนอ PowerPoint เป็น PDF พร้อมตัวเลือกกำหนดเองหลายอย่าง:

```c++
// สร้างออบเจกต์ของคลาส PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// ตั้งค่าคุณภาพสำหรับภาพ JPG.
pdfOptions->set_JpegQuality(90);

// ตั้งค่า DPI สำหรับภาพ.
pdfOptions->set_SufficientResolution(300);

// ตั้งค่าการทำงานของเมตาไฟล์.
pdfOptions->set_SaveMetafilesAsPng(true);

// ตั้งค่าระดับการบีบอัดข้อความสำหรับเนื้อหาข้อความ.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// กำหนดโหมดการปฏิบัติตาม PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// สร้างออบเจกต์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// บันทึกการนำเสนอเป็นเอกสาร PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากการนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด[set_ShowHiddenSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/)จากคลาส[PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/)เพื่อใส่สไลด์ที่ซ่อนเป็นหน้าต่าง PDF ผลลัพธ์

ตัวอย่างโค้ด C++ นี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่:

```c++
// สร้างออบเจกต์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// สร้างออบเจกต์ของคลาส PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// เพิ่มสไลด์ที่ซ่อนอยู่.
pdfOptions->set_ShowHiddenSlides(true);

// บันทึกการนำเสนอเป็นไฟล์ PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

ตัวอย่างโค้ด C++ นี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็น PDF ที่มีการตั้งรหัสผ่านโดยใช้พารามิเตอร์การป้องกันจากคลาส[PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/):

```c++
// สร้างออบเจกต์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// สร้างออบเจกต์ของคลาส PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// ตั้งรหัสผ่าน PDF และสิทธิ์การเข้าถึง.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// บันทึกการนำเสนอเป็นไฟล์ PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides มีเมธอด[set_WarningCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveoptions/set_warningcallback/)ภายใต้คลาส[PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/)ที่ช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงการนำเสนอเป็น PDF

ตัวอย่างโค้ด C++ นี้แสดงวิธีการตรวจจับการแทนที่ฟอนต์:

```c++
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
    // สร้างออบเจกต์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // ตั้งค่าคอลแบ็กคำเตือนในตัวเลือก PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // บันทึกการนำเสนอเป็นไฟล์ PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการรับคอลแบ็กสำหรับการแทนที่ฟอนต์ระหว่างการเรนเดอร์ โปรดดู[รับการเรียกคืนคำเตือนสำหรับการแทนที่ฟอนต์](/slides/th/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ โปรดดูบทความ[การแทนที่ฟอนต์](/slides/th/cpp/font-substitution/)

{{% /alert %}} 

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างโค้ด C++ นี้แสดงวิธีการแปลงเฉพาะสไลด์ที่เลือกจากการนำเสนอ PowerPoint เป็น PDF:

```C++
// สร้างออบเจกต์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// กำหนดอาเรย์ของหมายเลขสไลด์.
auto slides = MakeArray<int32_t>({ 1, 3 });

// บันทึกการนำเสนอเป็นไฟล์ PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

ตัวอย่างโค้ด C++ นี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่ระบุ:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

ตัวอย่างโค้ด C++ นี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็น PDF ที่รวมบันทึกย่อด้วย:

```C++
// สร้างออบเจกต์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// กำหนดค่าตัวเลือก PDF พร้อมรูปแบบโน้ต.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// บันทึกการนำเสนอเป็นไฟล์ PDF พร้อมโน้ต.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ด้วยมาตรฐานการปฏิบัติตามใดก็ได้ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

ตัวอย่างโค้ด C++ นี้แสดงกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:

```C++
auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsB1b = MakeObject<PdfOptions>();
pdfOptionsB1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsB1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides รองรับการดำเนินการแปลง PDF ที่ช่วยให้คุณแปลงไฟล์ PDF ไปยังรูปแบบไฟล์ยอดนิยม คุณสามารถทำการแปลง[PDF to HTML](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-jpg/), และ[PDF to PNG](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-png/) การแปลงอื่น ๆ สำหรับรูปแบบเฉพาะเช่น[PDF to SVG](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-tiff/), และ[PDF to XML](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-xml/) ก็ได้รับการสนับสนุนเช่นกัน

{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, ชาร์ต, และสูตรเป็นรูปหนึ่งเดียว ส่วนองค์ประกอบเส้นทางเดี่ยวจะไม่ถูกเก็บเป็นเนื้อหาแยกต่างหากและอาจถูกมาร์คเป็น artefacts; ข้อความแทนที่จะมีเฉพาะสำหรับรูปทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**สามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF อย่างเป็นชุดได้หรือไม่?**  

ใช่, Aspose.Slides รองรับการแปลงชุดของไฟล์ PPT หรือ PPTX จำนวนหลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและดำเนินการแปลงโดยอัตโนมัติได้  

**สามารถตั้งรหัสผ่านให้กับ PDF ที่แปลงแล้วได้หรือไม่?**  

ได้เลย ใช้คลาส[PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/)เพื่อกำหนดรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง  

**ทำอย่างไรถึงจะใส่สไลด์ที่ซ่อนอยู่ใน PDF?**  

ใช้เมธอด`set_ShowHiddenSlides`ในคลาส[PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/)เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ผลลัพธ์  

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**  

ได้ คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น`set_JpegQuality`และ`set_SufficientResolution`ในคลาส[PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/)เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ  

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**  

ใช่, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับมาตรฐานต่าง ๆ รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตอบสนองความต้องการด้านการเข้าถึงและการเก็บถาวร  

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for C++ Documentation](/slides/th/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/th/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/th/conversion)