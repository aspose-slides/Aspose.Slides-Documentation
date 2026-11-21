---
title: เปลี่ยนขนาดและการวางแนวของหน้าบันทึกใน C++
linktitle: ขนาดหน้าบันทึก
type: docs
weight: 10
url: /th/cpp/notes-size/
keywords:
- ขนาดหน้าบันทึก
- การวางแนวของโน้ต
- โน้ตแนวนอน
- โน้ตแนวตั้ง
- ขนาดเอกสารประกอบ
- PowerPoint
- งานนำเสนอ
- PPT
- PPTX
- C++
- Aspose.Slides
description: "อ่านและเปลี่ยนขนาดหน้าบันทึกใน Aspose.Slides สำหรับ C++, สลับการวางแนว, ตรวจสอบขนาดที่บันทึก, และส่งออกโน้ตหรือเอกสารประกอบเป็น PDF และรูปภาพ."
---
## **ภาพรวม**

ใช้ [Presentation::get_NotesSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_notessize/) เพื่อเข้าถึงการตั้งค่าหน้าบันทึกของงานนำเสนอ จะคืนค่าอ็อบเจกต์ [INotesSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/inotessize/) ที่เมธอด [set_Size](https://reference.aspose.com/slides/th/cpp/aspose.slides/inotessize/set_size/) สามารถกำหนดมิติได้ แม้ว่าจะไม่สามารถแทนที่อ็อบเจกต์การตั้งค่าโน้ตได้ แต่คุณสามารถเปลี่ยนขนาดของมันได้

ความกว้างและความสูงระบุเป็น **points** โดยมี 72 points ต่อหนึ่งนิ้ว ตัวอย่างเช่น 900 × 600 points เท่ากับ 12.5 × 8⅓ นิ้ว การตั้งค่าเหล่านี้ใช้กับงานนำเสนอทั้งหมด ไม่ได้ใช้กับโน้ตของสไลด์แต่ละสไลด์

| การตั้งค่า | วัตถุประสงค์ |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_notessize/) | ควบคุมขนาดหน้าบันทึกและขนาดหน้าที่ใช้สำหรับการส่งออกเป็น handout |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_slidesize/) | ควบคุมขนาดสไลด์ปกติของงานนำเสนอผ่าน [ISlideSize](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidesize/) |

การเปลี่ยนการตั้งค่าใด ๆ หนึ่งจะไม่ทำให้การตั้งค่าอื่นเปลี่ยนอัตโนมัติ การเปลี่ยนการวางแนวของหน้าบันทึกยังไม่ทำให้สไลด์ปกติหมุนได้ ดู [Slide Size](/slides/th/cpp/slide-size/) เพื่อปรับขนาดสไลด์ปกติ

ตัวอย่างด้านล่างใช้ไฟล์ `sample.pptx` ที่มีอยู่แล้ว สำหรับตัวอย่างการส่งออก ให้ใช้งานนำเสนอที่มีอย่างน้อยหนึ่งสไลด์ที่มีโน้ตผู้พูด ตัวอย่างแต่ละอันสามารถทำงานแยกกันได้

## **อ่านขนาดและการวางแนวของหน้าบันทึก**

อ่านความกว้างและความสูงแล้วเปรียบเทียบเพื่อกำหนดการวางแนว: หน้าที่กว้างกว่าจะเป็นแนวนอน หน้าที่สูงกว่าจะเป็นแนวตั้ง และขนาดเท่ากันจะเป็นหน้าแบบสี่เหลี่ยมจัตุรัส ตัวอย่างนี้พิมพ์ค่ามิติจริงเป็น points โดยไม่สมมติขนาดกระดาษมาตรฐาน

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **สลับเป็นแนวนอนโดยไม่เปลี่ยนขนาดกระดาษ**

เพื่อเปลี่ยนเฉพาะการวางแนว ให้สลับค่าความกว้างและความสูงเดิม ค่าดังกล่าวจะคงความยาวของด้านทั้งสองไว้รวมถึงขนาดกระดาษที่กำหนดเอง เงื่อนไขด้านล่างจะป้องกันไม่ให้หน้าที่เป็นแนวนอนไปกลับเป็นแนวตั้งและจะปล่อยหน้าสี่เหลี่ยมจัตุรัสไว้โดยไม่เปลี่ยนแปลง

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

สำหรับการวางแนวแนวตั้ง ใช้การกำหนดค่าเดียวกันเมื่อ `size.get_Width() > size.get_Height()` อย่าแทนค่าขนาด A4 หรือ Letter เว้นแต่คุณต้องการเปลี่ยนขนาดกระดาษด้วย

## **กำหนดและตรวจสอบขนาดหน้าบันทึกแบบกำหนดเอง**

กำหนดมิติทั้งสองพร้อมกัน แล้วใช้ [Presentation::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/save/) เพื่อบันทึกงานนำเสนอ ตัวอย่างนี้ตั้งค่าหน้าแนวนอน 900 × 600 points บันทึกเป็น PPTX จากนั้นเปิดไฟล์ที่บันทึกใหม่อีกครั้งเพื่อตรวจสอบค่าที่บันทึกไว้ การเปรียบเทียบรับค่าความคลาดเคลื่อน 0.01 points สำหรับค่าทศนิยม; ไม่ได้หมายความว่าทุกรูปแบบไฟล์จะมีความแม่นยำเท่าเดิม

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

ผลลัพธ์ที่คาดว่าจะได้คือ `900 x 600 points` และ `Size preserved: True` การตรวจสอบงานนำเสนอที่เปิดใหม่จะยืนยันไฟล์ที่บันทึกไว้ ไม่ได้ตรวจสอบแค่การตั้งค่าในหน่วยความจำเท่านั้น

## **ส่งออกโน้ตและเอกสารประกอบ**

ขนาดหน้ากำหนดพื้นที่ที่ใช้ได้สำหรับการจัดวางโน้ตหรือเอกสารประกอบ แต่ไม่ได้ทำให้รูปแบบเหล่านั้นเปิดใช้งานโดยอัตโนมัติ: ต้องกำหนดตัวเลือกการส่งออกด้วย การส่งออกสไลด์ปกติยังคงใช้ขนาดสไลด์เดิม

### **ส่งออกโน้ตเป็น PDF และ PNG**

กำหนด [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notescommentslayoutingoptions/) ให้กับ [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) เพื่อรวมโน้ตใน PDF ตัวอย่างนี้ยังเรนเดอร์สไลด์แรกที่มีโน้ตเป็น PNG โดยใช้ [Slide::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/slide/getimage/) และ [RenderingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/renderingoptions/)

โหมด [BottomTruncated](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notespositions/) จะเก็บโน้ตไว้บนหน้าเดียว; โน้ตที่ไม่พอดีจะถูกตัดลง PDF ใช้หน้าขนาด 900 × 600 points ที่อัตราสเกลภาพ 1 × 1 ตามตัวอย่างด้านล่าง PNG จะมีขนาด 900 × 600 พิกเซล Points อธิบายรูปเรขาคณิตของหน้า; พิกเซลอธิบายผลลัพธ์แบบแรสเตอร์ที่มิติก็ขึ้นกับสเกลการเรนเดอร์

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

สำหรับการส่งออก PDF ที่มีโน้ตยาว, [BottomFull](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/notespositions/) จะอนุญาตให้เพิ่มหน้าตามที่จำเป็น อย่าใช้โหมดนี้ร่วมกับการเรียกภาพสไลด์เดียวด้านบนซึ่งไม่รองรับ หลังจากปรับขนาด ตรวจสอบผลลัพธ์ว่ามีโน้ตถูกตัดหรือไม่และตำแหน่งของวัตถุ notes‑master ที่มีอยู่; การเปลี่ยนขนาดหน้าอย่างเดียวไม่ควรถือเป็นการรับประกันว่าข้อมูลทั้งหมดจะพอดี ดูเพิ่มเติมที่ [Convert PowerPoint to PDF with Notes](/slides/th/cpp/convert-powerpoint-to-pdf-with-notes/)

### **ส่งออกเอกสารประกอบเป็น PDF**

ใช้ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/handoutlayoutingoptions/) เพื่อจัดวางภาพย่อหลายสไลด์บนหนึ่งหน้า ตัวอย่างต่อไปนี้ตั้งค่าหน้า 900 × 600 points และใช้ [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/handouttype/) เพื่อจัดเรียงสูงสุดสี่สไลด์ต่อหน้า การตั้งค่าก่อนหน้าแนวนอนควบคุมลำดับสไลด์; การวางแนวของหน้ามาจากความกว้างและความสูงของมัน

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

การเปลี่ยนขนาดหน้าจะเปลี่ยนพื้นที่ที่ใช้ได้สำหรับกริดเอกสารประกอบโดยไม่กระทบต่อมิติของสไลด์ต้นทาง สำหรับภาพเอกสารประกอบ ให้ใช้ [Presentation::GetImages](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/getimages/) พร้อมการจัดวางเอกสารประกอบ แทนการใช้เมธอดภาพของสไลด์แต่ละอัน ใน Aspose.Slides การเรนเดอร์เอกสารประกอบระดับงานนำเสนอใช้ขนาดหน้าบันทึก ในขณะที่การเรียกภาพสไลด์เดี่ยวจะไม่สร้างหน้าเอกสารประกอบ ดู [Handout Mode](/slides/th/cpp/convert-powerpoint-in-handout-mode/) เพื่อดูตัวเลือกการจัดวางอื่น ๆ

## **ขนาดหน้าในโปรแกรมดู, การส่งออกและการพิมพ์**

แยกแยะระหว่างขนาดงานนำเสนอที่จัดเก็บ, ขนาดหน้าที่ส่งออกและขนาดกระดาษที่พิมพ์:

- **โปรแกรมดูงานนำเสนอ:** ตัวดูสามารถแสดงหรือพิมพ์โน้ตโดยใช้กฎการจัดวางของตนเอง หากแอปพลิเคชันอื่นบันทึกไฟล์ ให้เปิดไฟล์ใหม่อีกครั้งและตรวจสอบมิติอีกครั้ง; การแปลงรูปแบบของแอปนั้นอาจทำให้ค่ามาตรฐานใหม่
- **รูปแบบการส่งออก:** ตัวอย่าง PDF ของโน้ตและเอกสารประกอบด้านบนใช้ขนาดหน้าที่กำหนดไว้ ภาพแรสเตอร์ใช้ขนาดพิกเซลเต็มจำนวนและสเกลการเรนเดอร์ ดังนั้นค่าจุดทศนิยมอาจถูกปัดเป็นจำนวนเต็มในผลลัพธ์ภาพ การส่งออกสไลด์ปกติไม่ใช้ขนาดหน้าบันทึก
- **ไดรเวอร์เครื่องพิมพ์:** การเลือกกระดาษ, การหมุนอัตโนมัติและการตั้งค่า fit‑to‑page สามารถเปลี่ยนผลลัพธ์ทางกายภาพได้โดยไม่กระทบต่อมิติที่จัดเก็บในงานนำเสนอหรือ PDF สำหรับกระดาษขนาดเฉพาะ ให้จับคู่การตั้งค่าของเครื่องพิมพ์และตรวจสอบตัวอย่างการพิมพ์

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งขนาดโน้ตสำหรับสไลด์เดียวได้หรือไม่?**

ขนาดหน้าบันทึกเป็นการตั้งค่าระดับงานนำเสนอ สไลด์แต่ละสไลด์อาจมีเนื้อหาโน้ตที่ต่างกันได้ แต่คุณสมบัตินี้ไม่ให้ขนาดหน้าที่แยกต่างหากสำหรับแต่ละสไลด์

**ทำไมการเปลี่ยนการวางแนวของโน้ตจึงไม่ได้เปลี่ยนสไลด์ของฉัน?**

หน้าบันทึกและสไลด์ปกติมีมิติเฉพาะตัว ใช้การตั้งค่าขนาดสไลด์ปกติเมื่อคุณต้องการปรับขนาดสไลด์เอง

**ทำไมผลลัพธ์ที่บันทึกหรือพิมพ์จึงมีขนาดต่างจากที่คาด?**

ให้เปิดงานนำเสนอที่บันทึกใหม่อีกครั้งและเปรียบเทียบขนาดโน้ต หากมีการเปลี่ยนแปลง ตรวจสอบว่าแอปพลิเคชันอื่นได้ปรับการตั้งค่าหน้าหรือไม่ หากไม่เปลี่ยน ให้ตรวจสอบการจัดวางการส่งออก, สเกลภาพ, การตั้งค่าโปรแกรมดูและการเลือกกระดาษของเครื่องพิมพ์