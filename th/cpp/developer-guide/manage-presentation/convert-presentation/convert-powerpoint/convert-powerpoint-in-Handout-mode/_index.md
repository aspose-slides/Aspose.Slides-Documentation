---
title: แปลงงานนำเสนอ PowerPoint ในโหมด Handout ด้วย C++
linktitle: โหมด Handout
type: docs
weight: 150
url: /th/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- โหมด Handout
- เอกสารประกอบ
- PPT
- PPTX
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "แปลงงานนำเสนอเป็นเอกสารประกอบใน C++ ตั้งค่าจำนวนสไลด์ต่อหน้า คงบันทึกย่อ ส่งออกเป็น PDF หรือรูปภาพด้วย Aspose.Slides พร้อมตัวอย่างโค้ด ทดลองใช้ฟรี"
---
## **บทนำ**

Aspose.Slides ให้ความสามารถในการแปลงงานนำเสนอเป็นรูปแบบต่าง ๆ รวมถึงการสร้างเอกสารประกอบการพิมพ์ในโหมด Handout โหมดนี้ช่วยให้คุณกำหนดวิธีการแสดงสไลด์หลายสไลด์ในหน้าหนึ่ง ทำให้เหมาะสำหรับการประชุม สัมมนา และกิจกรรมอื่น ๆ คุณสามารถเปิดใช้งานโหมดนี้ได้โดยตั้งค่าวิธี `set_SlidesLayoutOptions` ในอินเทอร์เฟซ [IPdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/ihtmloptions/), และ [ITiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/itiffoptions/)  

## **การส่งออกในโหมด Handout**

เพื่อกำหนดค่าโหมด Handout ให้ใช้วัตถุ [HandoutLayoutingOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/handoutlayoutingoptions/) ซึ่งกำหนดจำนวนสไลด์ที่วางบนหน้าหนึ่งและพารามิเตอร์การแสดงผลอื่น ๆ  

ด้านล่างเป็นตัวอย่างโค้ดที่แสดงวิธีแปลงงานนำเสนอเป็น PDF ในโหมด Handout  

```cpp
// โหลดงานนำเสนอ.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ตั้งค่าตัวเลือกการส่งออก.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 สไลด์ต่อหน้าหนึ่งในแนวนอน
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // พิมพ์หมายเลขสไลด์
slidesLayoutOptions->set_PrintFrameSlide(true);                      // พิมพ์กรอบรอบสไลด์
slidesLayoutOptions->set_PrintComments(false);                       // ไม่มีคอมเมนต์

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// ส่งออกงานนำเสนอเป็น PDF ด้วยรูปแบบที่เลือก.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
โปรดจำไว้ว่าเมธอด `set_SlidesLayoutOptions` มีให้ใช้เฉพาะรูปแบบผลลัพธ์บางประเภท เช่น PDF, HTML, TIFF และเมื่อเรนเดอร์เป็นรูปภาพ. 
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**จำนวนภาพย่อสไลด์สูงสุดต่อหน้าที่สามารถแสดงในโหมด Handout คือเท่าไหร่?**  

Aspose.Slides รองรับ [presets](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/handouttype/) สูงสุด 9 ภาพย่อต่อหน้า พร้อมการจัดเรียงแนวนอนหรือแนวตั้ง: 1, 2, 3, 4 (แนวนอน/แนวตั้ง), 6 (แนวนอน/แนวตั้ง) และ 9 (แนวนอน/แนวตั้ง).  

**ฉันสามารถกำหนดตารางแบบกำหนดเองได้ เช่น 5 หรือ 8 สไลด์ต่อหน้า?**  

ไม่ได้ ตัวเลขและลำดับของภาพย่อถูกควบคุมโดยการอธิบายค่า [HandoutType](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/handouttype/) อย่างเคร่งครัด; การจัดวางแบบอิสระไม่ได้รับการสนับสนุน.  

**ฉันสามารถรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ Handout ได้หรือไม่?**  

ได้ ใช้เมธอด `set_ShowHiddenSlides` ในการตั้งค่า export สำหรับรูปแบบเป้าหมาย เช่น [PdfOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/htmloptions/), หรือ [TiffOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/tiffoptions/).