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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงและค้นหาได้ใน C++ ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่เร็วและตัวเลือกการแปลงขั้นสูง."
---
## **Overview**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน C++ มีข้อดีหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษารูปแบบและการจัดวางของงานนำเสนอ แนวทางนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของรูปภาพ รวมถึงการรวมสไลด์ที่ซ่อนอยู่ การตั้งรหัสผ่านให้ไฟล์ PDF การตรวจจับการแทนที่ฟอนท์ การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานการปฏิบัติตามเพื่อเอกสารผลลัพธ์

## **PowerPoint to PDF Conversions**

ด้วย Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) จากนั้นบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด `Save` คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) เปิดเผยเมธอด `Save` ซึ่งโดยปกติใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ ใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides จะเติมช่อง Application ด้วย "*Aspose.Slides*" และช่อง PDF Producer ด้วยค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ลิงก์ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดสัญลักษณ์
* ตาราง

## **Convert PowerPoint to PDF**

กระบวนการแปลง PowerPoint เป็น PDF แบบมาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ระบุเป็น PDF โดยใช้การตั้งค่าที่เหมาะสมที่สุดที่ระดับคุณภาพสูงสุด

โค้ด C++ นี้แสดงวิธีแปลงงานนำเสนอ (PPT, PPTX, ODP ฯลฯ) เป็น PDF:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PowerPoint หรือ OpenDocument
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// บันทึกงานนำเสนอเป็น PDF
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose มีเครื่องมือแปลงออนไลน์ฟรี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf) ที่สาธิตกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยเครื่องมือนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides มีตัวเลือกแบบกำหนดเอง — คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/) — ที่ช่วยให้คุณปรับแต่ง PDF ที่ได้ ล็อก PDF ด้วยรหัสผ่าน หรือระบุวิธีการดำเนินการแปลง

### **Convert PowerPoint to PDF with Custom Options**

ด้วยตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีการจัดการเมทาฟายล์ ตั้งระดับการบีบอัดสำหรับข้อความ ตั้งค่า DPI สำหรับภาพ ฯลฯ

โค้ดตัวอย่างด้านล่างแสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF โดยใช้ตัวเลือกกำหนดเองหลายอย่าง:

```c++
// สร้างอินสแตนซ์ของคลาส PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// ตั้งค่าคุณภาพสำหรับภาพ JPG.
pdfOptions->set_JpegQuality(90);

// ตั้งค่า DPI สำหรับภาพ.
pdfOptions->set_SufficientResolution(300);

// กำหนดพฤติกรรมสำหรับเมทาฟายล์.
pdfOptions->set_SaveMetafilesAsPng(true);

// ตั้งระดับการบีบอัดข้อความสำหรับเนื้อหาข้อความ.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// กำหนดโหมดการปฏิบัติตาม PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PowerPoint หรือ OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// บันทึกงานนำเสนอเป็นเอกสาร PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Convert PowerPoint to PDF with Hidden Slides**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [set_ShowHiddenSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) จากคลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าใน PDF ที่สร้างขึ้น

โค้ด C++ นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมรวมสไลด์ที่ซ่อนอยู่:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PowerPoint หรือ OpenDocument
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// สร้างอินสแตนซ์ของคลาส PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// เพิ่มสไลด์ที่ซ่อนอยู่.
pdfOptions->set_ShowHiddenSlides(true);

// บันทึกงานนำเสนอเป็น PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Convert PowerPoint to Password-Protected PDF**

โค้ด C++ นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่านโดยใช้พารามิเตอร์การป้องกันจากคลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/):

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PowerPoint หรือ OpenDocument
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// สร้างอินสแตนซ์ของคลาส PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// ตั้งรหัสผ่าน PDF และสิทธิ์การเข้าถึง
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// บันทึกงานนำเสนอเป็น PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Detect Font Substitutions**

Aspose.Slides มีเมธอด [set_WarningCallback](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/saveoptions/set_warningcallback/) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/) ที่ช่วยให้คุณตรวจจับการแทนที่ฟอนท์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

โค้ด C++ นี้แสดงวิธีตรวจจับการแทนที่ฟอนท์:

```c++
// การดำเนินการของคอลลแบ็กเตือน.
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
    // สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PowerPoint หรือ OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // ตั้งค่าคอลลแบ็กเตือนในตัวเลือก PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // บันทึกงานนำเสนอเป็น PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการรับคอลลแบ็กเมื่อมีการแทนที่ฟอนท์ระหว่างการเรนเดอร์ โปรดดูที่ [Getting Warning Callbacks for Fonts Substitution](/slides/th/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนท์ โปรดดูบทความ [Font Substitution](/slides/th/cpp/font-substitution/)

{{% /alert %}} 

## **Convert Selected Slides from PowerPoint to PDF**

โค้ด C++ นี้แสดงวิธีแปลงเฉพาะสไลด์ที่เลือกจากงานนำเสนอ PowerPoint เป็น PDF:

```C++
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PowerPoint หรือ OpenDocument
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// ตั้งอาร์เรย์ของหมายเลขสไลด์
auto slides = MakeArray<int32_t>({ 1, 3 });

// บันทึกงานนำเสนอเป็น PDF
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Convert PowerPoint to PDF with Custom Slide Size**

โค้ด C++ นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF โดยกำหนดขนาดสไลด์ตามต้องการ:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PowerPoint หรือ OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// สร้างงานนำเสนอใหม่ด้วยขนาดสไลด์ที่ปรับแล้ว.
auto resizedPresentation = MakeObject<Presentation>();

// ตั้งค่าขนาดสไลด์ที่กำหนดเอง.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// คัดลอกสไลด์แรกจากงานนำเสนอเดิม.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// บันทึกงานนำเสนอที่ปรับขนาดเป็น PDF พร้อมบันทึกย่อ.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Convert PowerPoint to PDF in Notes Slide View**

โค้ด C++ นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PDF ที่รวมบันทึกย่อของสไลด์:

```C++
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PowerPoint หรือ OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// กำหนดค่าตัวเลือก PDF ด้วยการจัดเค้าโครงบันทึกย่อ.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกย่อ.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานการปฏิบัติตามใดก็ได้ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ด C++ นี้แสดงกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:

```C++
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

Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบไฟล์ยอดนิยมอื่น ๆ คุณสามารถดำเนินการแปลง [PDF to HTML](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-png/) อีกทั้งยังรองรับการแปลง PDF ไปยังรูปแบบพิเศษ เช่น [PDF to SVG](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/th/cpp/conversion/pdf-to-xml/)

{{% /alert %}}

> **Note:** เมื่อส่งออกเป็น PDF/UA Aspose.Slides จะจัดการกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิและสูตรเป็นรูปแบบเดียว ไม่ได้เก็บส่วนประกอบของเส้นทางเป็นเนื้อหาแยกต่างหากและอาจถูกมาร์คเป็นอาร์ติแฟกต์; ข้อความอธิบายจะถูกใส่เฉพาะรูปแบบทั้งหมดเท่านั้น

## **FAQ**

**Can I convert multiple PowerPoint files to PDF in bulk?**

ใช่, Aspose.Slides รองรับการแปลงหลายไฟล์ PPT หรือ PPTX เป็น PDF เป็นชุด คุณสามารถวนลูปไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยอัตโนมัติ

**Is it possible to password-protect the converted PDF?**

แน่นอน ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างการแปลง

**How do I include hidden slides in the PDF?**

ใช้เมธอด `set_ShowHiddenSlides` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่สร้างขึ้น

**Can Aspose.Slides maintain high image quality in the PDF?**

ได้, คุณสามารถควบคุมคุณภาพภาพด้วยเมธอดเช่น `set_JpegQuality` และ `set_SufficientResolution` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/) เพื่อให้ได้ภาพความละเอียดสูงใน PDF ของคุณ

**Does Aspose.Slides support PDF/A compliance standards?**

ใช่, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับมาตรฐานต่าง ๆ รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามข้อกำหนดการเข้าถึงและการจัดเก็บระยะยาว

## **Additional Resources**

- [Aspose.Slides for C++ Documentation](/slides/th/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/th/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/th/conversion)