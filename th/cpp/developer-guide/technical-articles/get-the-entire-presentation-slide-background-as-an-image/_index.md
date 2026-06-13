---
title: ดึงพื้นหลังสไลด์ทั้งหมดจากงานนำเสนอเป็นภาพ
linktitle: พื้นหลังสไลด์ทั้งหมด
type: docs
weight: 95
url: /th/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- พื้นหลังสไลด์
- พื้นหลังสุดท้าย
- ดึงพื้นหลัง
- พื้นหลังทั้งหมด
- พื้นหลังเป็นภาพ
- พื้นหลัง PPT
- พื้นหลัง PPTX
- พื้นหลัง ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ดึงพื้นหลังสไลด์ทั้งหมดเป็นภาพจากงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ C++ เพื่อเพิ่มประสิทธิภาพการทำงานด้านภาพ."
---
## **ภาพรวม**

ในงานนำเสนอ PowerPoint พื้นหลังสไลด์อาจประกอบด้วยหลายองค์ประกอบ รวมถึงรูปภาพพื้นหลังสไลด์ ธีมการนำเสนอ โทนสี และออบเจกต์ที่วางบนมาสเตอร์สไลด์หรือเลย์เอาต์สไลด์

บทความนี้แสดงวิธีการดึงพื้นหลังสไลด์ทั้งหมดเป็นภาพโดยใช้ Aspose.Slides เนื่องจากไม่มีวิธีเดียวสำหรับงานนี้ วิธีการจึงประกอบด้วยการโคลนสไลด์ที่เลือกไปยังงานนำเสนอชั่วคราว ลบรูปร่างจากสไลด์ที่โคลน แล้วแปลงพื้นหลังสไลด์ที่ได้เป็นภาพ

## **ดึงพื้นหลังสไลด์ทั้งหมด**

Aspose.Slides สำหรับ C++ ไม่ได้ให้วิธีง่าย ๆ ในการดึงพื้นหลังสไลด์ของงานนำเสนอทั้งหมดเป็นภาพ แต่คุณสามารถทำตามขั้นตอนด้านล่างเพื่อทำได้:
1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
1. รับขนาดสไลด์จากงานนำเสนอ
1. เลือกสไลด์หนึ่ง
1. สร้างงานนำเสนอชั่วคราว
1. กำหนดขนาดสไลด์เดียวกันในงานนำเสนอชั่วคราว
1. โคลนสไลด์ที่เลือกไปยังงานนำเสนอชั่วคราว
1. ลบรูปร่างจากสไลด์ที่โคลน
1. แปลงสไลด์ที่โคลนเป็นภาพ

ตัวอย่างโค้ดต่อไปนี้ดึงพื้นหลังสไลด์ของงานนำเสนอทั้งหมดเป็นภาพ
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**พื้นผิวไล่สีซับซ้อน, เทกเจอร์ หรือการเติมรูปภาพจากมาสเตอร์สไลด์จะถูกเก็บไว้ในภาพพื้นหลังที่ได้หรือไม่?**

ใช่ Aspose.Slides เรนเดอร์การไล่สี, การเติมรูปภาพและเทกเจอร์ที่กำหนดบนสไลด์, เลย์เอาต์ หรือมาสเตอร์ หากคุณต้องการแยกลักษณะจากมาสเตอร์ที่สืบทอดมา ให้ [ตั้งค่าพื้นหลังของตัวเอง](/slides/th/cpp/presentation-background/) บนสไลด์ปัจจุบันก่อนทำการส่งออก

**ฉันสามารถเพิ่มลายน้ำลงในภาพพื้นหลังที่ได้ก่อนบันทึกได้หรือไม่?**

ใช่ คุณสามารถ [เพิ่มลายน้ำ](/slides/th/cpp/watermark/) รูปหรือภาพบน [สำเนาสไลด์ที่ทำงาน](/slides/th/cpp/clone-slides/) (วางไว้ด้านหลังเนื้อหาอื่น) แล้วทำการส่งออก วิธีนี้ทำให้คุณสร้างภาพพื้นหลังที่ฝังลายน้ำไว้แล้ว

**ฉันสามารถดึงพื้นหลังสำหรับเลย์เอาต์หรือมาสเตอร์เฉพาะโดยไม่ต้องเชื่อมโยงกับสไลด์ที่มีอยู่ได้หรือไม่?**

ใช่ เข้าถึงมาสเตอร์หรือเลย์เอาต์ที่ต้องการ แล้วใช้กับ [สไลด์ชั่วคราว](/slides/th/cpp/clone-slides/) ที่มีขนาดตามต้องการ จากนั้นทำการส่งออกสไลด์นั้นเพื่อรับพื้นหลังที่ได้จากเลย์เอาต์หรือมาสเตอร์นั้น

**มีข้อจำกัดด้านลิขสิทธิ์ที่ส่งผลต่อการส่งออกภาพหรือไม่?**

คุณลักษณะการเรนเดอร์พร้อมให้ใช้อย่างเต็มที่ด้วย [ลิขสิทธิ์ที่ถูกต้อง](/slides/th/cpp/licensing/) ในโหมดประเมินผล ผลลัพธ์อาจมีข้อจำกัดเช่นลายน้ำ ให้เปิดใช้งานลิขสิทธิ์หนึ่งครั้งต่อกระบวนการก่อนรันการส่งออกเป็นชุด