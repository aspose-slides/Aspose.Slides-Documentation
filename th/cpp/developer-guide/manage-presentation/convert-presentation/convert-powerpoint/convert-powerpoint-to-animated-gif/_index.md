---
title: แปลงงานนำเสนอ PowerPoint เป็น GIF เคลื่อนไหวใน C++
linktitle: PowerPoint เป็น GIF
type: docs
weight: 65
url: /th/cpp/convert-powerpoint-to-animated-gif/
keywords:
- GIF เคลื่อนไหว
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น GIF
- งานนำเสนอเป็น GIF
- สไลด์เป็น GIF
- PPT เป็น GIF
- PPTX เป็น GIF
- บันทึก PPT เป็น GIF
- บันทึก PPTX เป็น GIF
- ส่งออก PPT เป็น GIF
- ส่งออก PPTX เป็น GIF
- การตั้งค่าเริ่มต้น
- การตั้งค่ากำหนดเอง
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็น GIF เคลื่อนไหวได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++. ผลลัพธ์เร็วและคุณภาพสูง"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถแปลงงานนำเสนอ PowerPoint เป็นไฟล์ GIF ที่เคลื่อนไหวได้ด้วยเพียงไม่กี่บรรทัดของโค้ด สิ่งนี้มีประโยชน์เมื่อต้องการแชร์เนื้อหาสไลด์ในรูปแบบที่เบา รองรับอย่างกว้างขวาง และสามารถฝังลงในเว็บเพจ, แอปแชท, หรือเอกสารได้ บทความนี้จะอธิบายวิธีส่งออกงานนำเสนอเป็น GIF ด้วยการตั้งค่าเริ่มต้นและวิธีปรับแต่งผลลัพธ์โดยกำหนดตัวเลือกเช่น ขนาดเฟรม, ความล่าช้าของสไลด์, และอัตราเฟรมการเปลี่ยนผ่านผ่าน [GifOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/gifoptions/) 

## **แปลงการนำเสนอเป็น GIF เคลื่อนไหวโดยใช้การตั้งค่าเริ่มต้น**

ตัวอย่างโค้ดนี้ใน C++ แสดงวิธีแปลงงานนำเสนอเป็น GIF เคลื่อนไหวโดยใช้การตั้งค่ามาตรฐาน:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

GIF ที่เคลื่อนไหวจะถูกสร้างด้วยพารามิเตอร์เริ่มต้น

{{%  alert  title="เคล็ดลับ"  color="info"  %}} 
หากคุณต้องการปรับแต่งพารามิเตอร์สำหรับ GIF สามารถใช้คลาส [GifOptions](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.export.gif_options) ดูตัวอย่างโค้ดด้านล่าง

{{% /alert %}} 

## **แปลงการนำเสนอเป็น GIF เคลื่อนไหวโดยใช้การตั้งค่ากำหนดเอง**

ตัวอย่างโค้ดนี้แสดงวิธีแปลงงานนำเสนอเป็น GIF เคลื่อนไหวโดยใช้การตั้งค่ากำหนดเองใน C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// ขนาดของ GIF ที่ได้
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// ระยะเวลาที่แต่ละสไลด์จะแสดงก่อนจะเปลี่ยนเป็นสไลด์ถัดไป
gifOptions->set_DefaultDelay(2000);
// เพิ่ม FPS เพื่อคุณภาพการแอนิเมชันการเปลี่ยนผ่านที่ดีขึ้น
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="ข้อมูล" color="info" %}}
คุณอาจต้องการลองใช้ตัวแปลงฟรี [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ที่พัฒนาโดย Aspose
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ถ้าฟอนต์ที่ใช้ในงานนำเสนอไม่ได้ติดตั้งในระบบจะทำอย่างไร?

ให้ติดตั้งฟอนต์ที่หายไปหรือ [configure fallback fonts](/slides/th/cpp/powerpoint-fonts/) Aspose.Slides จะทำการแทนที่ฟอนต์ แต่ลักษณะอาจแตกต่างกัน สำหรับการสร้างแบรนด์ควรตรวจสอบให้ฟอนต์ที่ต้องการพร้อมใช้งานเสมอ

### ฉันสามารถใส่น้ำหนักบนเฟรมของ GIF ได้หรือไม่?

ได้ คุณสามารถ [Add a semi-transparent object/logo](/slides/th/cpp/watermark/) ไปยังมาสเตอร์สไลด์หรือสไลด์แต่ละหน้า ก่อนทำการส่งออก—น้ำหนักจะปรากฏบนทุกเฟรม