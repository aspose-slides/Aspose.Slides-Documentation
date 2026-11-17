---
title: จัดการเอฟเฟกต์การแปลงภาพในงานนำเสนอด้วย C++
linktitle: เอฟเฟกต์การแปลงภาพ
type: docs
weight: 11
url: /th/cpp/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟกต์ภาพ
- ความสว่าง
- คอนทราสต์
- สเกลสีเทา
- โดโต้น
- สีทินท์
- HSL
- การแทนที่สี
- เบลอ
- ความโปร่งใส
- เอฟเฟกต์อัลฟ่า
- ห่วงโซ่เอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ใช้, เชื่อมต่อ, ตรวจสอบ, ลบ, และตรวจสอบความถูกต้องของเอฟเฟกต์การแปลงภาพสำหรับกรอบรูปภาพด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับรูปภาพเป็นคอลเลกชันที่เรียงลำดับของการดำเนินการแปลงภาพ สำหรับกรอบรูปภาพ ให้เริ่มจากกรอบของ [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) และเข้าถึง [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/)。ที่คืนค่าเป็น [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) จะอนุญาตให้คุณเพิ่ม, ตรวจสอบ, ลบ, และเคลียร์เอฟเฟกต์โดยไม่ต้องเขียนไบต์ของรูปเดิมใหม่

บทความนี้สาธิตขั้นตอนทำงานครบวงจรสำหรับความสว่างและคอนทราสต์, การแปลงสี, เบลอ, ความโปร่งใส, ห่วงโซ่เอฟเฟกต์ที่เรียงลำดับ, ค่าที่มีผล, การลบ, และการตรวจสอบการทำงานแบบรอบเดี่ยว PPTX

## **ทำความเข้าใจความเป็นเจ้าของเอฟเฟกต์และการใช้ซ้ำภาพ**

ทรัพยากรภาพและรูปภาพที่แสดงภาพเป็นออบเจ็กต์ที่ต่างกัน:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นทางที่เป็นของงานนำเสนอ
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) เป็นส่วนของการเติมรูปและอ้างอิงทรัพยากรภาพพร้อมเก็บคอลเลกชันการแปลงภาพ
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) เป็นรูปทรงสไลด์ที่อ้างอิงการเติมรูป, รูปร่าง, การครอป, และการจัดรูปแบบระดับกรอบอื่นๆ

ดังนั้น การดำเนินการแปลงภาพจะไม่แก้ไขไบต์ใน [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)。เมื่อ `IPPImage` เดียวกันถูกส่งผ่านไปยัง [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) มากกว่าหนึ่งครั้ง แต่ละกรอบรูปใหม่จะได้รับ `ISlidesPicture` ของตนเองและคอลเลกชันการแปลงของตนเอง การใส่ grayscale ให้กับกรอบหนึ่งจะไม่ทำให้กรอบอื่นเป็น grayscale แม้ว่าพวกมันจะใช้ทรัพยากรภาพฝังเดียวกัน

โมเดล `ISlidesPicture::get_ImageTransform` นี้ยังใช้กับการเติมรูปอื่นๆ เช่น รูปร่างหรือพื้นหลังสไลด์ ตัวอย่างต่อไปนี้มุ่งเน้นไปที่กรอบรูปภาพ

## **ใช้ช่วงพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีที่สาธิตใช้ช่วงและหน่วยตามความหมายต่อไปนี้  โปรดเก็บค่าภายในช่วงเหล่านี้ แม้ว่ารุ่นไลบรารีบางรุ่นอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงโดยทันที; รูปแบบการนำเสนอเป้าหมายอาจทำให้ค่าเป็นมาตรฐาน, ลบ, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การดำเนินการ | พารามิเตอร์ | ช่วงและหน่วยที่ถูกต้อง |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` ถึง `100` เปอร์เซ็นต์; `0` ทำให้ส่วนประกอบไม่เปลี่ยนแปลง |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | ไม่มีพารามิเตอร์เชิงตัวเลข ค่าความโปร่งใส (Alpha) ไม่เปลี่ยนแปลง |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | สองสีสำหรับพิกเซลสีเข้มและสีอ่อน ช่อง RGB และอัลฟาใน `System::Drawing::Color` ใช้ค่า `0` ถึง `255` |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue มีค่าตั้งแต่ `0` (รวม) ถึง `360` (ไม่รวม) หน่วยเป็นองศา; amount มีค่า `-100` ถึง `100` เปอร์เซ็นต์ |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue มีค่าตั้งแต่ `0` (รวม) ถึง `360` (ไม่รวม) หน่วยเป็นองศา; saturation และ luminance มีค่า `-100` ถึง `100` เปอร์เซ็นต์ |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | สีการแทนที่ใช้ค่าช่องตั้งแต่ `0` ถึง `255` ค่าอัลฟาที่มีอยู่ไม่เปลี่ยนแปลง |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius ต้องเป็นจำนวนเต็มบวกหรือศูนย์และวัดเป็นจุด; `grow` ควบคุมว่าภาพเบลออาจขยายออกนอกขอบเขตเดิมหรือไม่ |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | เปอร์เซ็นต์ที่ไม่เป็นลบ ใช้ `0` ถึง `100` สำหรับการปรับความทึบแบบปกติ: `0` หมายถึงโปร่งใสเต็มและ `100` คงค่าความทึบเดิม |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` ถึง `100` เปอร์เซ็นต์ความทึบ |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` ถึง `100` เปอร์เซ็นต์เกณฑ์อัลฟา ค่าที่ต่ำกว่าจะเป็นโปร่งใส; ค่าที่เท่ากับหรือสูงกว่าจะเป็นทึบ |

สำหรับการปรับอัลฟ่าแบบคงที่ ความโปร่งใสและความทึบเป็นค่าเสริมกัน ตัวอย่างเช่น ความโปร่งใส 35% มีค่าอัลฟ่าโมเดูเลต 65%

## **ใช้ความสว่างและคอนทราสต์**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) คืนค่าออบเจ็กต์ [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) การตั้งค่าสเกลาร์จะถูกส่งเมื่อสร้างออบเจ็กต์ `IBrightnessContrast::GetEffective` คืนค่าที่คำนวณแล้วแบบอ่านอย่างเดียวที่สามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และคอนทราสต์ 20% แล้วแสดงตัวอย่างโดยไม่แก้ไขภาพฝัง:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) เป็นส่วนขยายเอฟเฟกต์ภาพของ Office 2010 ซึ่งพกพาได้น้อยกว่เอฟเฟกต์ luminance มาตรฐานของ DrawingML เมื่อความสว่างและคอนทราสต์ต้องการให้แก้ไขได้หลังการเดินทางรอบ PPTX ให้ใช้ [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) แล้วตรวจสอบผลลัพธ์หลังจากเปิดไฟล์ใหม่ ส่วนที่อธิบายข้อจำกัดของฟอร์แมตจะให้รายละเอียดเพิ่มเติม

## **ใช้การแปลงสี**

เอฟเฟกต์สีสามารถนำไปใช้แยกกันกับกรอบรูปภาพต่างๆ ที่ใช้ทรัพยากรภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้ากรอบและใส่ grayscale, duotone, tint, การปรับ HSL, และการแทนที่สี

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) มีพารามิเตอร์สีสองตัวที่แก้ไขได้อิสระ: `get_Color1` ใช้กับพิกเซลสีเข้ม, `get_Color2` ใช้กับพิกเซลสีอ่อน ทำให้เป็นตัวอย่างที่ดีของเอฟเฟกต์ที่มีการตั้งค่าซับซ้อนกว่าค่าขนาดเดียว

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีโดยคงอัลฟาไว้ ต่างจาก [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) ที่จะแมพสีต้นทางหนึ่งเป็นสีเป้าหมายและเผยรูปแบบสีต้นทางและเป้าหมาย

### **ใช้เกณฑ์ความสว่าง**

เกณฑ์ความสว่างสามารถทำให้เครื่องหมายที่จางบนหน้าสแกนมองเห็นได้ชัดเจนขึ้นจากพื้นหลัง [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) คงระดับสีเทากลาง [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) แมพความสว่างเป็นสีดำหรือสีขาว, ส่วน [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) ใช้เกณฑ์กับความทึบ

เกณฑ์ความสว่างอยู่ระหว่าง 0% ถึง 100% ทั้งหมด พิกเซลที่ต่ำกว่าเกณฑ์จะเป็นสีดำ พิกเซลที่เท่ากับหรือสูงกว่าเกณฑ์จะเป็นสีขาว การเพิ่มเกณฑ์จะทำให้เฉดสีมากขึ้นกลายเป็นสีดำเนื่องจากหลายค่าอยู่ใต้จุดตัด

ดาวน์โหลด [grayscale-swatches.png](grayscale-swatches.png) ไปยังไดเรกทอรีทำงาน แต่ละป้ายกำกับให้ระดับสีเทาต้นฉบับในสเกลตั้งแต่ 0 ถึง 255 ตัวอย่างวางต้นฉบับข้างสองสำเนาและบันทึกเกณฑ์ของแต่ละสำเนาไว้ในงานนำเสนอ

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

เปิดงานนำเสนอผลลัพธ์ใน PowerPoint เพื่อเปรียบเทียบสามกรอบ ตัวอย่างที่มีป้ายกำกับ 96 มีความสว่างประมาณ 38% (96 จาก 255) จะกลายเป็นสีขาวที่เกณฑ์ 20% และสีดำที่เกณฑ์ 60%

![ต้นฉบับสเว็ทช์สีเทาข้างผลลัพธ์สีดำ‑ขาวที่เกณฑ์ความสว่าง 20% และ 60%](luminance-threshold.png)

## **เพิ่มเบลอ, ความโปร่งใส, และเอฟเฟกต์อัลฟ่า**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) มีผลต่อทุกช่องสี รวมอัลฟาด้วย ตั้งค่า `grow` เป็น `true` เมื่อขอบเบลออาจขยายออกไปนอกขอบเขตรูปเดิม

สำหรับความโปร่งใสสม่ำเสมอ ให้ใช้ [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) มันคูณค่าอัลฟ่าเดิมทุกค่า ดังนั้นพิกเซลที่โปร่งใสบางส่วนจะคงความแตกต่างตามสัดส่วน [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) จะกำหนดค่าอัลฟ่าเดียวให้กับทุกพิกเซล [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) แปลงอัลฟ่าเป็นสองระดับตามเกณฑ์

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

เอฟเฟกต์อัลฟ่าอื่นที่ไม่มีพารามิเตอร์รวมถึง [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) ซึ่งทำให้ทุกอัลฟ่าไม่เป็นศูนย์เต็มทึบ; [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) ทำให้ทุกอัลฟ่าใต้น้อยกว่า 100% เป็นโปร่งใสเต็ม; และ [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) แปลงอัลฟ่าเป็น `100% - alpha`

## **สร้างห่วงโซ่เอฟเฟกต์ที่เรียงลำดับ**

แต่ละเมธอด `Add...Effect` จะเพิ่มการดำเนินการใหม่ต่อท้ายคอลเลกชัน เราเรนเดอร์ใช้คอลเลกชันเป็นสายงานที่เรียงลำดับ: ผลลัพธ์ของการดำเนินการ 0 กลายเป็นอินพุตของการดำเนินการ 1 เป็นต้น ดังนั้น การใช้เอฟเฟกต์เดียวกันในลำดับต่างกันอาจให้ภาพที่ต่างกัน

เช่น grayscale แล้วตามด้วย tint จะลบข้อมูลสีก่อนแล้วทำให้สีใหม่ของผลลัพธ์ความสว่าง; tint แล้วตามด้วย grayscale จะลบ tint อีกครั้ง เช่นเดียวกับการแทนที่อัลฟ่าอาจเขียนทับค่าที่คำนวณจากการดำเนินการก่อนหน้า ในขณะที่การโมเดูเลตอัลฟ้าจะคงความแตกต่างสัมพัทธ์ไว้

ตัวอย่างต่อไปนี้สร้างห่วงโซ่สี่การดำเนินการ บันทึกเป็น PPTX แล้วเปิดงานนำเสนอใหม่ เพื่อตรวจสอบทั้งประเภทการดำเนินการและลำดับ จากนั้นเรนเดอร์ผลลัพธ์ที่เปิดใหม่:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

คอลเลกชันไม่ได้กำหนดเมทริกซ์ความเข้ากันที่จำกัดเอฟเฟกต์สี, อัลฟ่า, และเบลอให้อยู่ในห่วงโซ่แยกกัน สามารถรวมกันได้ แต่การรวมกันอาจไม่ใช้งานที่มีประโยชน์ การแทนที่สีคงที่จะลบการเปลี่ยนแปลง RGB ที่เกิดจากเอฟเฟกต์สีก่อนหน้า; grayscale หลัง duotone จะลบสองสีที่เลือก; และเอฟเฟกต์อัลฟ่า ceiling, floor, replace หรือ bi‑level สามารถลบรายละเอียดอัลฟ่าเดิมที่สร้างขึ้นก่อนหน้า สร้างห่วงโซ่ตามลำดับการประมวลผลพิกเซลที่ต้องการ ไม่ใช่จัดเป็นธงฟอร์แมตที่ไม่มีลำดับ

<!-- visual-explanation:image-transform-effects:start -->
[![ภาพเดียวผ่าน grayscale แล้ว tint, และผ่าน tint แล้ว grayscale. สองภาพ grayscale สุดท้ายมีโทนสีต่างกัน](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)
*ในภาพแสดงผล Aspose.Slides for .NET 26.11 นี้ การ tint 220° ที่ 25% ทำให้ภาพ grayscale ไม่เปลี่ยน; การใช้ tint ก่อน grayscale ให้โทนสีที่ต่างกัน*
<!-- visual-explanation:image-transform-effects:end -->

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่มีผล**

ออบเจ็กต์การดำเนินการที่แก้ไขได้คือออบเจ็กต์ที่เก็บใน `ISlidesPicture::get_ImageTransform` ขึ้นอยู่กับเอฟเฟกต์อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง เช่น [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) มี `set_Radius` และ `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) มี `set_Amount`, และ [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) มี `set_Threshold`  เอฟเฟกต์สีเช่น [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) เปิดเผยออบเจ็กต์ [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/) ที่แก้ไขได้

อินเทอร์เฟสการดำเนินการบางอย่างรวมถึง [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/), และ [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/) ไม่เปิดเผยสเกลาร์ที่สร้างเป็นคุณสมบัติที่เขียนได้ เพื่อเปลี่ยนการตั้งค่าเหล่านั้น ให้ลบการดำเนินการแล้วเพิ่มการแทนที่ในตำแหน่งที่ต้องการ

ข้อมูลที่มีผลที่คืนโดย `GetEffective()` เป็นค่าที่คำนวณแล้วและอ่าน‑อย่างเดียว มีประโยชน์สำหรับการแก้ไขสีที่ขึ้นกับธีมและการอ่านค่าที่ทำให้อยู่ในรูปแบบมาตรฐานที่ตัวเรนเดอร์ใช้ แต่ไม่ใช่พื้นผิวการแก้ไขอื่น ตัวอย่างต่อไปนี้วนลูปคอลเลกชันและตรวจสอบค่าที่มีผลของการดำเนินการทั่วไปหลายรายการ:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

เอฟเฟกต์ที่ไม่มีพารามิเตอร์เช่น grayscale, alpha ceiling, และ alpha inverse ยังคงมีออบเจ็กต์ข้อมูลที่มีผลอยู่ แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์ สิ่งที่สำคัญคือการมีอยู่และตำแหน่งของพวกมันในคอลเลกชัน

## **ลบหรือเคลียร์การแปลงภาพ**

ใช้ [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) เพื่อลบการดำเนินการหนึ่งตามตำแหน่ง เนื่องจากตำแหน่งจะเปลี่ยนหลังการลบ ให้ค้นหาเป้าหมายก่อนแล้วลบหลังจากวนลูป ใช้ `Clear()` เพื่อลบห่วงโซ่ทั้งหมด

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

การลบหรือเคลียร์การแปลงเปลี่ยนเฉพาะรูปแบบของรูปภาพ ไม่ได้ทำการลบ, บีบอัดใหม่, หรือแก้ไขทรัพยากร [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) ที่ใช้งานซ้ำ

## **พิจารณาฟอร์แมตการนำเสนอและเป้าหมายการส่งออก**

การแปลงภาพเริ่มต้นจาก DrawingML ทำให้ PPTX เป็นฟอร์แมตที่แก้ไขได้ที่แนะนำสำหรับห่วงโซ่เอฟเฟกต์ แม้กับ PPTX ก็ไม่ได้หมายความว่าการดำเนินการทุกอย่างมีพกพาเท่าเดิม:

- การดำเนินการ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และการดำเนินการอัลฟ่าแบบทั่วไป มีโอกาสดีที่สุดที่จะคงอยู่หลังการเดินทางรอบ PPTX ควรเปิดไฟล์ที่สร้างใหม่แล้วตรวจสอบคอลเลกชันเสมอเมื่อการคงรักษาเป็นข้อกำหนด
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) เป็นส่วนขยาย Office 2010 ไม่ใช่การดำเนินการ luminance มาตรฐานของ DrawingML สามารถใช้สำหรับเรนเดอร์ในหน่วยความจำได้ แต่ไม่รับประกันว่าจะคงเป็น [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) ที่แก้ไขได้หลังบันทึกและเปิดใหม่ PPTX แนะนำให้ใช้ [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) สำหรับการปรับความสว่างและคอนทราสต์ที่คงอยู่
- ฟอร์แมตไบนารี PPT มีอายุยาวกว่ารุ่นเต็มของโมเดลเอฟเฟกต์ DrawingML การบันทึกเป็น PPT อาจละทิ้งการดำเนินการที่ไม่รองรับ, ลดห่วงโซ่ลงเป็นส่วนที่รองรับ, หรือประมาณลักษณะการแสดงผล อย่าใช้ PPT เป็นฟอร์แมตการตรวจสอบสำหรับห่วงโซ่ที่แก้ไขได้ซับซ้อน
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือเอาต์พุตภาพอื่นๆ จะใช้ห่วงโซ่ที่รองรับในการเรนเดอร์ผลลัพธ์ รูปแบบเหล่านี้ไม่ได้บรรจุ `IImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบเรสเตอร์ทำให้ผลลัพธ์แปรสภาพเป็นพิกเซล และการส่งออกเอกสารหรือเวกเตอร์เก็บการแสดงผลของตนเอง
- เอฟเฟกต์ไม่ทำให้ภาพที่เชื่อมโยงเป็นไฟล์ที่อยู่ในตัวเอง การเรนเดอร์ภาพที่เชื่อมโยงยังคงต้องอาศัยทรัพยากรที่เชื่อมโยงอยู่เมื่อนำเสนอถูกโหลด

ผู้บริโภคงานนำเสนอที่ต่างกันอาจเรนเดอร์กรณีขอบต่างกันโดยเฉพาะเมื่อมีการรวมการดำเนินการอัลฟ่าหรือการควอนตาไลซ์สีหลายอย่าง สำหรับผลลัพธ์สำคัญ ควรทดสอบทั้งรอบการแก้ไขและรูปแบบการส่งออกขั้นสุดท้ายด้วย Aspose.Slides รุ่นเดียวที่ใช้ในการผลิต

## **FAQ**

**Do image transform effects modify the embedded image data?**

No. The operations belong to the `ISlidesPicture` used by the picture fill. The underlying `IPPImage` bytes remain unchanged.

**Will two picture frames that reuse the same image share their effects?**

No. Reusing an `IPPImage` avoids duplicate image data, but each picture frame normally has a separate `ISlidesPicture` and image transform collection.

**Can color, blur, and alpha effects be combined?**

Yes. The collection accepts them in one ordered chain. Consider what each operation does to the output of the previous one because replacement and threshold operations may discard earlier color or alpha detail.

**Why are effective values read‑only?**

Effective data represents calculated values used for rendering, including resolved colors. Edit the operation stored in the transform collection where writable members exist; otherwise remove it and add a replacement with new creation parameters.

**Which format should I use to preserve a transform chain?**

Use PPTX and verify the file by reopening it. Legacy PPT cannot represent the full DrawingML effect model, and rendered export formats preserve appearance rather than editable transform operations.