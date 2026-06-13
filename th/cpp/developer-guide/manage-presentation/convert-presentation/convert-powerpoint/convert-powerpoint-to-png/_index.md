---
title: แปลงสไลด์ PowerPoint เป็น PNG ใน C++
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/cpp/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- งานนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- บันทึก PPT เป็น PNG
- บันทึก PPTX เป็น PNG
- ส่งออก PPT เป็น PNG
- ส่งออก PPTX เป็น PNG
- C++
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็นภาพ PNG คุณภาพสูงอย่างรวดเร็วด้วย Aspose.Slides สำหรับ C++ เพื่อผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็นภาพ PNG โดยใช้ Aspose.Slides แสดงวิธีโหลดไฟล์งานนำเสนอในรูปแบบ เช่น PPT, PPTX, และ ODP เรนเดอร์สไลด์เป็นภาพและบันทึกผลลัพธ์เป็นรูปแบบ PNG

บทความยังสาธิตวิธีปรับแต่งภาพ PNG ที่สร้างขึ้นโดยการตั้งค่าค่าการสเกลหรือระบุความกว้างและความสูงที่ต้องการ

## **แปลง PowerPoint เป็น PNG**

ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation).
2. รับอ็อบเจ็กต์สไลด์จากคอลเลกชัน [Presentation::get_Slides()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) ภายใต้อินเทอร์เฟส [ISlide](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_slide).
3. ใช้เมธอด [ISlide::GetImage()](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage) เพื่อรับรูปย่อของแต่ละสไลด์.
4. ใช้เมธอด [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) เพื่อบันทึกรูปย่อสไลด์เป็นรูปแบบ PNG.

โค้ด C++ นี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **แปลง PowerPoint เป็น PNG ด้วยมิติที่กำหนดเอง**

หากต้องการได้ไฟล์ PNG ที่มีสเกลบางอย่าง คุณสามารถตั้งค่าของ `desiredX` และ `desiredY` ซึ่งกำหนดมิติของรูปย่อที่ได้

โค้ด C++ นี้แสดงการทำงานตามที่อธิบาย:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **แปลง PowerPoint เป็น PNG ด้วยขนาดที่กำหนดเอง**

หากต้องการได้ไฟล์ PNG ที่มีขนาดบางอย่าง คุณสามารถส่งอาร์กิวเมนต์ `width` และ `height` ที่ต้องการสำหรับ `ImageSize`

โค้ดนี้แสดงวิธีแปลง PowerPoint เป็น PNG พร้อมระบุขนาดของภาพ:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกเฉพาะรูปร่างที่กำหนด (เช่น แผนภูมิหรือรูปภาพ) แทนที่จะส่งออกทั้งสไลด์ได้อย่างไร?**

Aspose.Slides รองรับการ [สร้างรูปย่อสำหรับรูปร่างแต่ละชิ้น](/slides/th/cpp/create-shape-thumbnails/); คุณสามารถเรนเดอร์รูปร่างเป็นภาพ PNG ได้.

**การแปลงแบบขนานได้รับการสนับสนุนบนเซิร์ฟเวอร์หรือไม่?**

ใช่ แต่ต้อง [ไม่แชร์](/slides/th/cpp/multithreading/) อินสแตนซ์การนำเสนอเดียวกันระหว่างเธรด ควรใช้อินสแตนซ์แยกสำหรับแต่ละเธรดหรือโพรเซส.

**ข้อจำกัดของรุ่นทดลองเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**

โหมดประเมินจะเพิ่มลายน้ำลงในภาพผลลัพธ์และบังคับใช้ [ข้อจำกัดอื่น](/slides/th/cpp/licensing/) จนกว่าจะมีการใช้งานไลเซนส์.