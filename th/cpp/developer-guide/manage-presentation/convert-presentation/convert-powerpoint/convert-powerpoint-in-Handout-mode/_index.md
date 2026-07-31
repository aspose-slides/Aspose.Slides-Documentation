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
description: "แปลงงานนำเสนอเป็นเอกสารแจกด้วย C++. ตั้งสไลด์ต่อหน้า, คงบันทึกย่อ, ส่งออกเป็น PDF หรือภาพด้วย Aspose.Slides พร้อมตัวอย่างโค้ด. ทดลองใช้งานฟรี."
---
## **บทนำ**

Aspose.Slides มีความสามารถในการแปลงงานนำเสนอเป็นรูปแบบต่าง ๆ รวมถึงการสร้างเอกสารแจกสำหรับการพิมพ์ในโหมด Handout. โหมดนี้อนุญาตให้คุณกำหนดวิธีการแสดงสไลด์หลายแผ่นในหน้าหนึ่ง ทำให้เหมาะสำหรับการประชุม สัมมนาและกิจกรรมอื่น ๆ. คุณสามารถเปิดใช้งานโหมดนี้ได้โดยตั้งค่าวิธี `set_SlidesLayoutOptions` ในอินเทอร์เฟซ [IPdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ihtmloptions/), และ [ITiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/itiffoptions/) 

## **การส่งออกโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/handoutlayoutingoptions/) ซึ่งกำหนดจำนวนสไลด์ที่วางบนหน้าหนึ่งและพารามิเตอร์การแสดงผลอื่น ๆ

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout

```cpp
// โหลดงานนำเสนอ.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ตั้งค่าตัวเลือกการส่งออก.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 สไลด์ต่อหน้าหนึ่งในแนวนอน
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // พิมพ์เลขสไลด์
slidesLayoutOptions->set_PrintFrameSlide(true);                      // พิมพ์กรอบรอบสไลด์
slidesLayoutOptions->set_PrintComments(false);                       // ไม่มีคอมเมนต์

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
โปรดจำไว้ว่าเมธอด `set_SlidesLayoutOptions` มีให้ใช้เฉพาะรูปแบบผลลัพธ์บางรูปแบบ เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นภาพ
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนภาพย่อของสไลด์ต่อหน้าที่สูงสุดในโหมด Handout คือเท่าไร?**

Aspose.Slides รองรับ [ชุดค่าพรีเซ็ต](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/handouttype/) สูงสุดถึง 9 ภาพย่อต่อหน้า พร้อมการจัดเรียงแบบแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง)

**ฉันสามารถกำหนดกริดแบบกำหนดเอง เช่น 5 หรือ 8 สไลด์ต่อหน้าได้หรือไม่?**

ไม่. จำนวนและการจัดเรียงของภาพย่อถูกควบคุมอย่างเข้มงวดโดย enumeration [HandoutType](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/handouttype/); การจัดเรียงแบบกำหนดเองไม่ได้รับการสนับสนุน

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**

ได้. ใช้เมธอด `set_ShowHiddenSlides` ในการตั้งค่าการส่งออกสำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/)