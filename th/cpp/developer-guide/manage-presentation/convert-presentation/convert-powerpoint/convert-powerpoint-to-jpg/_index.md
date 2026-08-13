---
title: แปลง PPT และ PPTX เป็น JPG ด้วย C++
linktitle: PowerPoint เป็น JPG
type: docs
weight: 60
url: /th/cpp/convert-powerpoint-to-jpg/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น JPG
- งานนำเสนอเป็น JPG
- สไลด์เป็น JPG
- PPT เป็น JPG
- PPTX เป็น JPG
- บันทึก PowerPoint เป็น JPG
- บันทึกงานนำเสนอเป็น JPG
- บันทึกสไลด์เป็น JPG
- บันทึก PPT เป็น JPG
- บันทึก PPTX เป็น JPG
- ส่งออก PPT เป็น JPG
- ส่งออก PPTX เป็น JPG
- C++
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint (PPT, PPTX) เป็นภาพ JPG คุณภาพสูงใน C++ ด้วย Aspose.Slides โดยใช้ตัวอย่างโค้ดที่เร็วและเชื่อถือได้."
---
## **บทนำ**

การแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ JPG ช่วยให้การแชร์สไลด์ง่ายขึ้น ปรับประสิทธิภาพการทำงาน และฝังเนื้อหาในเว็บไซต์หรือแอปพลิเคชันได้อย่างสะดวก Aspose.Slides for C++ ช่วยให้คุณเปลี่ยนไฟล์ PPTX, PPT และ ODP เป็นภาพ JPEG คุณภาพสูง คู่มือนี้อธิบายวิธีการแปลงต่างๆ

ด้วยคุณลักษณะเหล่านี้ คุณสามารถสร้าง viewer สำหรับงานนำเสนอของคุณเองและสร้าง thumbnail สำหรับทุกสไลด์ได้ง่าย ซึ่งอาจมีประโยชน์หากคุณต้องการป้องกันไม่ให้สไลด์ถูกคัดลอกหรือแสดงงานนำเสนอในโหมดอ่านอย่างเดียว Aspose.Slides ให้คุณแปลงงานนำเสนอทั้งหมดหรือสไลด์เฉพาะเป็นรูปแบบภาพได้

## **แปลงสไลด์การนำเสนอเป็นภาพ JPG**

ขั้นตอนการแปลงไฟล์ PPT, PPTX หรือ ODP เป็น JPG มีดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) .
2. รับอ็อบเจกต์สไลด์ประเภท [ISlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/) จากคอลเลกชันสไลด์ของงานนำเสนอ
3. สร้างภาพของสไลด์โดยใช้เมธอด [ISlide.GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage/) 
4. เรียกเมธอด [IImage.Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/save/) บนวัตถุภาพ ส่งชื่อไฟล์ผลลัพธ์และรูปแบบภาพเป็นอาร์กิวเมนต์

{{% alert color="info" %}} 
**หมายเหตุ:** การแปลง PPT, PPTX หรือ ODP ไปเป็น JPG แตกต่างจากการแปลงเป็นรูปแบบอื่นใน Aspose.Slides for C++ API สำหรับรูปแบบอื่นคุณมักใช้เมธอด [IPresentation.Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/save/) แต่สำหรับการแปลงเป็น JPG ต้องใช้เมธอด [IImage.Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/save/) 
{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // สร้างภาพสไลด์โดยใช้สเกลที่ระบุ.
    auto image = slide->GetImage(scaleX, scaleY);

    // บันทึกภาพลงดิสก์ในรูปแบบ JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **แปลงสไลด์เป็น JPG ด้วยขนาดที่กำหนดเอง**

หากต้องการเปลี่ยนขนาดของภาพ JPG ที่สร้างขึ้น คุณสามารถตั้งค่าขนาดภาพโดยส่งค่าไปยังเมธอด [ISlide.GetImage(Size)](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) นี้ช่วยให้คุณสร้างภาพที่มีความกว้างและสูงที่กำหนดไว้ล่วงหน้า ทำให้ผลลัพธ์ตรงตามความต้องการด้านความละเอียดและอัตราส่วนภาพ ความยืดหยุ่นนี้มีประโยชน์อย่างยิ่งเมื่อสร้างภาพสำหรับเว็บแอปพลิเคชัน รายงาน หรือเอกสารที่ต้องการขนาดภาพที่แม่นยำ

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // สร้างภาพสไลด์ด้วยขนาดที่ระบุ.
    auto image = slide->GetImage(imageSize);

    // บันทึกภาพลงดิสก์ในรูปแบบ JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **เรนเดอร์คอมเมนต์เมื่อบันทึกสไลด์เป็นรูปภาพ**

Aspose.Slides for C++ มีฟีเจอร์ที่อนุญาตให้เรนเดอร์คอมเมนต์บนสไลด์ของงานนำเสนอเมื่อแปลงเป็นภาพ JPG ฟังก์ชันนี้มีประโยชน์ในการเก็บรักษาโน้ต, ข้อเสนอแนะ หรือการสนทนาที่ผู้ร่วมงานเพิ่มใน PowerPoint ด้วยการเปิดใช้งานตัวเลือกนี้ คอมเมนต์จะปรากฏในภาพที่สร้างขึ้น ทำให้ตรวจสอบและแชร์ข้อเสนอแนะได้ง่ายโดยไม่ต้องเปิดไฟล์งานนำเสนอเดิม

สมมติว่าเรามีไฟล์งานนำเสนอ "sample.pptx" ที่มีสไลด์ที่มีคอมเมนต์:

![สไลด์ที่มีคอมเมนต์](slide_with_comments.png)

โค้ด C++ ด้านล่างแปลงสไลด์เป็นภาพ JPG พร้อมคงไว้ซึ่งคอมเมนต์:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // ตั้งค่าตัวเลือกสำหรับคอมเมนต์ของสไลด์.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // แปลงสไลด์แรกเป็นภาพ.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

ผลลัพธ์:

![ภาพ JPG ที่มีคอมเมนต์](image_with_comments.png)

## **ดูเพิ่มเติม**

ดูตัวเลือกอื่นๆ สำหรับการแปลง PPT, PPTX หรือ ODP เป็นภาพ เช่น:

- [แปลง PowerPoint เป็น GIF](/slides/th/cpp/convert-powerpoint-to-animated-gif/)
- [แปลง PowerPoint เป็น PNG](/slides/th/cpp/convert-powerpoint-to-png/)
- [แปลง PowerPoint เป็น TIFF](/slides/th/cpp/convert-powerpoint-to-tiff/)
- [แปลง PowerPoint เป็น SVG](/slides/th/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
เพื่อดูว่า Aspose.Slides แปลง PowerPoint เป็นภาพ JPG อย่างไร ลองใช้เครื่องแปลงออนไลน์ฟรีเหล่านี้: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/th/conversion/pptx-to-jpg) และ [PPT to JPG](https://products.aspose.app/slides/th/conversion/ppt-to-jpg) 
{{% /alert %}}

![ตัวแปลงออนไลน์ฟรี PPTX เป็น JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose มีแอปเว็บ [Collage ฟรี](https://products.aspose.app/slides/th/collage) ให้บริการออนไลน์ คุณสามารถผสาน [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG to PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) ฯลฯ 

โดยใช้หลักการเดียวกับที่อธิบายในบทความนี้ คุณสามารถแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้ สำหรับข้อมูลเพิ่มเติม ดูหน้าเหล่านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/cpp/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/cpp/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/cpp/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/cpp/conversion/svg-to-png/) 
{{% /alert %}}

## **คำถามที่พบบ่อย**

### วิธีนี้รองรับการแปลงเป็นชุดหรือไม่?

ใช่, Aspose.Slides รองรับการแปลงหลายสไลด์เป็น JPG ในการดำเนินการเดียว

### การแปลงรองรับ SmartArt, แผนภูมิ, และวัตถุซับซ้อนอื่นๆหรือไม่?

ใช่, Aspose.Slides เรนเดอร์เนื้อหาทั้งหมดรวมถึง SmartArt, แผนภูมิ, ตาราง, รูปร่าง และอื่นๆ อย่างไรก็ตามความแม่นยำของการเรนเดอร์อาจแตกต่างเล็กน้อยจาก PowerPoint โดยเฉพาะเมื่อใช้ฟอนต์ที่กำหนดเองหรือฟอนต์ที่ไม่มีอยู่

### มีข้อจำกัดใดๆ เกี่ยวกับจำนวนสไลด์ที่สามารถประมวลผลได้หรือไม่?

Aspose.Slides เองไม่ได้กำหนดขีดจำกัดเข้มงวดเกี่ยวกับจำนวนสไลด์ที่คุณสามารถประมวลผลได้ อย่างไรก็ตามคุณอาจเจอข้อผิดพลาด out-of-memory เมื่อทำงานกับงานนำเสนอขนาดใหญ่หรือภาพความละเอียดสูง