---
title: แปลงสไลด์ PowerPoint เป็น PNG ใน C++
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/cpp/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- การนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- บันทึก PPT เป็น PNG
- บันทึก PPTX เป็น PNG
- ส่งออก PPT เป็น PNG
- ส่งออก PPTX เป็น PNG
- C++
- Aspose.Slides
description: "แปลงการนำเสนอ PowerPoint เป็นภาพ PNG คุณภาพสูงอย่างรวดเร็วด้วย Aspose.Slides สำหรับ C++ เพื่อให้ได้ผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการแปลงสไลด์การนำเสนอเป็นภาพ PNG ด้วย Aspose.Slides สำหรับ C++. คุณสามารถโหลดการนำเสนอในรูปแบบ เช่น PPT, PPTX และ ODP, เรนเดอร์แต่ละสไลด์และบันทึกเป็นไฟล์ภาพ PNG แยกแต่ละไฟล์ได้

## **แปลง PowerPoint เป็น PNG**

โหลดการนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) และเข้าถึงสไลด์ผ่านตัวเข้าถึง [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) ตัวอย่างนี้เรนเดอร์สไลด์ทุกสไลด์โดยใช้ [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) โดยไม่มีพารามิเตอร์เพื่อสร้างภาพย่อย จากนั้นเรียก [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) พร้อมกับ [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) เพื่อบันทึกสไลด์ที่เรนเดอร์แต่ละสไลด์เป็นภาพ PNG

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
การเรียกใช้ [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) แบบไม่มีพารามิเตอร์จะเรนเดอร์ที่สเกล 0.2 ตัวอย่างเช่น สไลด์ที่มีขนาด 720 × 540 จุด จะสร้างภาพย่อยขนาด 144 × 108 พิกเซล เพื่อควบคุมขนาดผลลัพธ์ ให้ใช้การเรียกแบบมีตัวคูณสเกลหรือขนาดภาพที่ระบุอย่างชัดเจนตามด้านล่าง
{{% /alert %}}

## **แปลง PowerPoint เป็น PNG ด้วยขนาดที่กำหนดเอง**

ส่งค่าอัตราสเกลแนวนอนและแนวตั้งให้กับ [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) เพื่อควบคุมขนาดที่เรนเดอร์ ในตัวอย่างนี้ค่าอัตราสเกลทั้งสองเท่ากับ 2 ทำให้สไลด์ที่มีขนาด 720 × 540 จุดผลิตภาพขนาด 1440 × 1080 พิกเซล ค่าตัวคูณสเกลที่เท่ากันจะรักษาอัตราส่วนของสไลด์ไว้แต่ละภาพจะถูกบันทึกในรูปแบบ PNG ด้วย [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/)

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **แปลง PowerPoint เป็น PNG ด้วยขนาดที่กำหนดเอง**

เพื่อระบุดีเมนชั่นผลลัพธ์เป็นพิกเซล ให้ส่งขนาดไปยัง [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) แทนการใช้ตัวคูณสเกล ตัวอย่างนี้เรนเดอร์สไลด์ทุกสไลด์ที่ 960 × 720 พิกเซลและบันทึกผลลัพธ์ด้วย [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) ควรเลือกขนาดที่ตรงกับอัตราส่วนของสไลด์เพื่อหลีกเลี่ยงการยืดภาพ

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **เลือกสไตล์การเรนเดอร์แบบไล่สี**

สมมติว่าสไลด์มีการเติมสีไล่สี แต่การเปลี่ยนแปลงใน PNG ที่ส่งออกออกมาดูอ่อนกว่า หรือแตกต่างจากที่เห็นใน PowerPoint คุณสามารถใช้เมธอด [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) ของ [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) เพื่อเลือกวิธีการเรนเดอร์ไล่สีได้

ดาวน์โหลด [gradient-styles.pptx](gradient-styles.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกของไฟล์นี้มีไล่สีเชิงเส้นสองแบบ: จากสีฟ้าอมเขียวไปสีส้มที่ด้านบนและจากสีน้ำเงินไปสีเหลืองที่ด้านล่าง แต่ละไล่สีมีจุดหยุดสองจุดที่ 0% และ 100%

ตัวอย่างต่อไปนี้โหลดการนำเสนอและเรนเดอร์สไลด์แรกเดียวกันในทั้งสองโหมดด้วย [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/)

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

ภาพด้านล่างแสดงผลลัพธ์จากสไลด์เดียวกัน โดยมีไล่สีทั้งสองแบบในแต่ละภาพ:

| Default | PowerPointUI |
| --- | --- |
| ![ไล่สีจากสีฟ้าอมเขียวไปสีส้มและจากสีน้ำเงินไปสีเหลืองที่เรนเดอร์ด้วย Default](gradient-Default.png) | ![ไล่สีเดียวกันที่เรนเดอร์ด้วย PowerPointUI](gradient-PowerPointUI.png) |

ในตัวอย่างนี้ `Default` จะสร้างสีกลางที่อ่อนกว่า ในขณะที่ `PowerPointUI` จะสร้างสีกลางที่เข้มกว่า ความแตกต่างขึ้นอยู่กับสีและจุดหยุดในไล่สี

เลือก `Default` เมื่อผลลัพธ์มาตรฐานของ Aspose.Slides เพียงพอต่อความต้องการของคุณ ลองใช้ `PowerPointUI` เมื่อคุณต้องการให้ผลลัพธ์ตรงกับที่แสดงใน PowerPoint เปรียบเทียบผลลัพธ์ทั้งสองกับผลลัพธ์ที่คุณตั้งใจไว้; ไม่มีโหมดใดที่ดีกว่ากันโดยทั่วไป

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกรูปร่างเฉพาะ เช่น แผนภูมิหรือรูปภาพ แทนสไลด์ทั้งหมดได้อย่างไร?**

Aspose.Slides รองรับการ [สร้างภาพย่อยสำหรับรูปทรงแต่ละรูป](/slides/th/cpp/shape-thumbnails/) ซึ่งช่วยให้คุณเรนเดอร์รูปร่างเป็นภาพ PNG

**รองรับการแปลงแบบขนานบนเซิร์ฟเวอร์หรือไม่?**

ใช่ ใช้ตัวอย่างการนำเสนอแยกสำหรับแต่ละเธรดหรือแต่ละกระบวนการ; [ห้ามแชร์อินสแตนซ์เดียวกันข้ามเธรด](/slides/th/cpp/multithreading/)

**ข้อจำกัดของรุ่น Evaluation เมื่อส่งออกเป็น PNG มีอะไรบ้าง?**

โหมด Evaluation จะเพิ่มลายน้ำบนภาพผลลัพธ์และใช้ [ข้อจำกัดอื่นๆ](/slides/th/cpp/licensing/) จนกว่าจะมีใบอนุญาต

