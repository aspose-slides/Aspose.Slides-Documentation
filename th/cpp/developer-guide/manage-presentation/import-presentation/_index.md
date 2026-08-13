---
title: นำเข้าการนำเสนอจาก PDF หรือ HTML ใน C++
linktitle: นำเข้าการนำเสนอ
type: docs
weight: 60
url: /th/cpp/import-presentation/
keywords:
- นำเข้าการนำเสนอ
- นำเข้าสไลด์
- นำเข้า PDF
- นำเข้า HTML
- PDF ไปยังการนำเสนอ
- PDF ไปยัง PPT
- PDF ไปยัง PPTX
- PDF ไปยัง ODP
- HTML ไปยังการนำเสนอ
- HTML ไปยัง PPT
- HTML ไปยัง PPTX
- HTML ไปยัง ODP
- พาวเวอร์พอยน์ท์
- เอกสารเปิด
- C++
- Aspose.Slides
description: "นำเข้าเอกสาร PDF และ HTML ไปยังการนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายใน C++ ด้วย Aspose.Slides เพื่อการประมวลผลสไลด์ที่ราบรื่นและมีประสิทธิภาพสูง"
---
## **บทนำ**

โดยใช้ [**Aspose.Slides for C++**](https://products.aspose.com/slides/th/cpp/), คุณสามารถนำเข้าการนำเสนอจากไฟล์ในรูปแบบอื่นได้ Aspose.Slides มีคลาส [SlideCollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.slide_collection) เพื่อให้คุณนำเข้าการนำเสนอจาก PDF, เอกสาร HTML ฯลฯ

## **นำเข้าพาวเวอร์พอยน์ท์จาก PDF**

ในกรณีนี้ คุณสามารถแปลง PDF เป็นพาวเวอร์พอยน์ท์ได้

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. สร้างอ็อบเจ็กต์ของคลาส Presentation  
2. เรียกเมธอด [AddFromPdf()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) แล้วส่งไฟล์ PDF เข้าไป  
3. ใช้เมธอด [Save()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) เพื่อบันทึกไฟล์ในรูปแบบพาวเวอร์พอยน์ท์

โค้ด C++ นี้แสดงการแปลง PDF เป็นพาวเวอร์พอยน์ท์:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="info" %}} 
คุณอาจต้องการลองใช้งานเว็บแอป **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/th/import/pdf-to-powerpoint) เพราะเป็นตัวอย่างการทำงานจริงของกระบวนการที่อธิบายไว้ที่นี่
{{% /alert %}} 

## **นำเข้าพาวเวอร์พอยน์ท์จาก HTML**

ในกรณีนี้ คุณสามารถแปลงเอกสาร HTML เป็นพาวเวอร์พอยน์ท์ได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation/)  
2. เรียกเมธอด [AddFromHtml()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) แล้วส่งไฟล์ HTML เข้าไป  
3. ใช้เมธอด [Save()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) เพื่อบันทึกไฟล์ในรูปแบบพาวเวอร์พอยน์ท์

โค้ด C++ นี้แสดงการแปลง HTML เป็นพาวเวอร์พอยน์ท์:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
คุณยังสามารถใช้ Aspose.Slides เพื่อแปลง HTML เป็นรูปแบบไฟล์ยอดนิยมอื่นได้:

* [HTML to image](https://products.aspose.com/slides/th/cpp/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/th/cpp/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/th/cpp/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/th/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **คำถามที่พบบ่อย**

### ตารางจะถูกเก็บไว้หรือไม่เมื่อทำการนำเข้า PDF และการตรวจจับสามารถปรับปรุงได้หรือไม่?

ตารางสามารถตรวจจับได้ระหว่างการนำเข้า; [PdfImportOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.import/pdfimportoptions/) มีเมธอด [set_DetectTables](https://reference.aspose.com/slides/th/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) ที่เปิดใช้งานการรู้จำตาราง ความแม่นยำขึ้นอยู่กับโครงสร้างของ PDF