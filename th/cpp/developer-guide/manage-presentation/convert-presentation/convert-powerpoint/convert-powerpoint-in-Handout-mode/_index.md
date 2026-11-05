---
title: แปลงงานนำเสนอ PowerPoint ในโหมด Handout ด้วย C++
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/cpp/convert-powerpoint-in-handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด Handout
- เอกสารแจก
- PPT
- PPTX
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "แปลงงานนำเสนอเป็นเอกสารแจกด้วย C++. ตั้งค่าสไลด์ต่อหน้า, รักษาบันทึกย่อ, ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides, พร้อมตัวอย่างโค้ด. ทดลองใช้งานฟรี."
---
## **บทนำ**

Aspose.Slides ให้ความสามารถในการแปลงงานนำเสนอเป็นรูปแบบต่าง ๆ รวมถึงการสร้างเอกสารแจกสำหรับการพิมพ์ในโหมด Handout โหมดนี้ช่วยให้คุณกำหนดว่าหน้าหนึ่งจะแสดงสไลด์หลายสไลด์อย่างไร ทำให้เหมาะสำหรับการประชุม สัมมนา และกิจกรรมอื่น ๆ คุณสามารถเปิดใช้งานโหมดนี้ได้โดยเรียกเมธอด `set_SlidesLayoutOptions` ในอินเทอร์เฟซ [IPdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ihtmloptions/), และ [ITiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/itiffoptions/) 

เพื่อกำหนดขนาดหน้าและแนวตั้งของเอกสารแจกก่อนการส่งออก ดูที่ [ขนาดหน้าบันทึกย่อ](/slides/th/cpp/notes-size/).

## **การส่งออกในโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/handoutlayoutingoptions/) ซึ่งกำหนดจำนวนสไลด์ที่จะวางบนหน้าหนึ่งและพารามิเตอร์การแสดงผลอื่น ๆ

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// โหลดงานนำเสนอ.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ตั้งค่าตัวเลือกการส่งออก.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 สไลด์ต่อหนึ่งหน้าผานแนวนอน
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // พิมพ์หมายเลขสไลด์
slidesLayoutOptions->set_PrintFrameSlide(true);                      // พิมพ์กรอบรอบสไลด์
slidesLayoutOptions->set_PrintComments(false);                       // ไม่มีความคิดเห็น

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
โปรดจำไว้ว่าเมธอด `set_SlidesLayoutOptions` มีให้ใช้เฉพาะรูปแบบผลลัพธ์บางประเภทเท่านั้น เช่น PDF, HTML, TIFF, และเมื่อเรนเดอร์เป็นภาพ. 
{{% /alert %}} 

## **คำถามที่พบบ่อย**

### จำนวนภาพย่อสไลด์สูงสุดต่อหน้าหนึ่งในโหมด Handout คือเท่าไร?

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/handouttype/) สูงสุด 9 ภาพย่อต่อหน้า พร้อมการจัดเรียงแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).

### ฉันสามารถกำหนดตารางแบบกำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?

ไม่ได้ จำนวนและการเรียงลำดับของภาพย่อถูกควบคุมอย่างเคร่งครัดโดยชนิด [HandoutType](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/handouttype/) ; การจัดวางแบบอิสระไม่ได้รับการสนับสนุน.

### ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?

ได้ ใช้เมธอด `set_ShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/).