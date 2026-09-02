---
title: จัดการเอฟเฟกต์การแปลงภาพในงานนำเสนอด้วย C++
linktitle: เอฟเฟกต์การแปลงภาพ
type: docs
weight: 11
url: /th/cpp/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟกต์รูปภาพ
- ความสว่าง
- คอนทราสต์
- สีเทา
- โทนคู่
- สีสัน
- HSL
- การแทนที่สี
- เบลอ
- ความโปร่งใส
- เอฟเฟกต์อัลฟ่า
- เชนเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ใช้, สร้างเชน, ตรวจสอบ, ลบ, และตรวจสอบความถูกต้องของเอฟเฟกต์การแปลงภาพสำหรับกรอบรูปด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับรูปภาพเป็นคอลเลกชันที่เรียงลำดับของการดำเนินการแปลงภาพ สำหรับกรอบรูป ให้เริ่มต้นด้วย [ISlidesPicture](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidespicture/) ของกรอบ แล้วเข้าถึง [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidespicture/get_imagetransform/). คอลเลกชันที่คืนค่าเป็น [IImageTransformOperationCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/) จะทำให้คุณสามารถเพิ่ม, ดูรายการ, ตรวจสอบ, ลบ และล้างเอฟเฟกต์ได้โดยไม่ต้องเขียนใหม่ไบต์ของภาพต้นฉบับ

บทความนี้สาธิตเวิร์กโฟลว์เต็มรูปแบบสำหรับความสว่างและคอนทราสต์, การแปลงสี, เบลอร์, ความโปร่งใส, เชนเอฟเฟกต์ตามลำดับ, ค่าเอฟเฟกต์ที่คำนวณได้, การลบ, และการตรวจสอบรอบ PPTX

## **ทำความเข้าใจการเป็นเจ้าของเอฟเฟกต์และการใช้ซ้ำภาพ**

ทรัพยากรภาพและภาพที่แสดงมันเป็นอ็อบเจ็กต์ที่แตกต่างกัน:

- [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับที่เป็นของงานนำเสนอ
- [ISlidesPicture](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidespicture/) เป็นส่วนของการเติมรูปภาพและอ้างอิงทรัพยากรภาพพร้อมเก็บคอลเลกชันการแปลงภาพ
- [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) เป็นรูปร่างบนสไลด์ที่เป็นเจ้าของการเติมรูปภาพที่เกี่ยวข้อง, รูปร่าง, การตั้งค่าการครอป, และการจัดรูปแบบระดับเฟรมอื่น ๆ

ดังนั้นการดำเนินการแปลงภาพจะไม่แก้ไขไบต์ใน [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/). เมื่อส่ง `IPPImage` เดียวกันไปยัง [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addpictureframe/) มากกว่าหนึ่งครั้ง แต่ละกรอบรูปใหม่จะได้รับ `ISlidesPicture` ของตนเองและคอลเลกชันการแปลงของตนเอง การปรับสีเทาให้กับกรอบหนึ่งไม่ได้ทำให้กรอบอื่นเป็นสีเทา แม้ว่าทั้งหมดจะใช้ทรัพยากรภาพที่ฝังไว้เดียวกัน

โมเดล `ISlidesPicture::get_ImageTransform` เดียวกันนี้ยังใช้กับการเติมรูปภาพอื่น ๆ เช่น รูปทรงหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างมุ่งเน้นที่กรอบรูปภาพ

## **ใช้ช่วงและหน่วยที่ถูกต้อง**

วิธีการที่แสดงใช้ช่วงและหน่วยตามความหมายต่อไปนี้ แม้ว่ารุ่นไลบรารีบางรุ่นอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงทันที แต่รูปแบบการนำเสนอเป้าหมายอาจทำให้ค่าเป็นมาตรฐาน, ลบ, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การดำเนินการ | พารามิเตอร์ | ช่วงและหน่วยที่ถูกต้อง |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` ถึง `100` ในหน่วยเปอร์เซ็นต์; `0` ไม่เปลี่ยนแปลงคอมโพเนนต์ |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | ไม่มีพารามิเตอร์เชิงตัวเลข. Alpha ไม่เปลี่ยนแปลง |
| [AddDuotoneEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | สองสีสำหรับพิกเซลสีมืดและสีสว่าง. ช่องสี RGB และ alpha ใน `System::Drawing::Color` ใช้ค่า `0` ถึง `255` |
| [AddTintEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue อยู่ในช่วง `0` รวมถึงถึง `360` ไม่รวม, หน่วยเป็นองศา; amount อยู่ในช่วง `-100` ถึง `100` เปอร์เซ็นต์ |
| [AddHSLEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue อยู่ในช่วง `0` รวมถึงถึง `360` ไม่รวม, หน่วยเป็นองศา; saturation และ luminance อยู่ในช่วง `-100` ถึง `100` เปอร์เซ็นต์ |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | สีแทนที่ใช้ค่าช่องตั้งแต่ `0` ถึง `255`. ค่า alpha เดิมไม่เปลี่ยนแปลง |
| [AddBlurEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | radius ต้องเป็นจำนวนไม่เป็นลบและวัดเป็นพอยท์; `grow` ควบคุมว่าผลเบลอร์อาจขยายออกนอกขอบเดิมหรือไม่ |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | เปอร์เซ็นต์ที่ไม่เป็นลบ. ใช้ `0` ถึง `100` สำหรับการปรับความทึบแบบทั่วไป: `0` เป็นโปร่งแสงเต็ม, `100` เก็บค่า alpha เดิม |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` ถึง `100` เปอร์เซ็นต์ความทึบ |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` ถึง `100` เปอร์เซ็นต์เกณฑ์ alpha. ค่าต่ำกว่าจะเป็นโปร่งแสง; ค่าที่เท่าหรือสูงกว่าจะเป็นทึบ |

สำหรับการปรับค่า alpha แบบคงที่ ความโปร่งใสและความทึบเป็นค่าตรงกันข้าม ตัวอย่างเช่น ความโปร่งใส 35% สอดคล้องกับค่า alpha modulation 65%

## **ปรับความสว่างและคอนทราสต์**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) คืนค่าอ็อบเจ็กต์ [IBrightnessContrast](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/ibrightnesscontrast/) การตั้งค่าสเกลาร์จึงถูกกำหนดขณะสร้างอ็อบเจ็กต์ เมธอด `IBrightnessContrast::GetEffective` คืนค่าที่คำนวณแล้วแบบอ่านอย่างเดียวซึ่งสามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และคอนทราสต์ 20% แล้วเรนเดอร์พรีวิวโดยไม่แก้ไขภาพฝังไว้:

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

[BrightnessContrast](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/brightnesscontrast/) เป็นส่วนขยายเอฟเฟกต์รูปภาพของ Office 2010 และมีความพกพาน้อยกว่าเอฟเฟกต์ luminance ของ DrawingML มาตรฐาน หากต้องการให้ความสว่างและคอนทราสต์ยังคงแก้ไขได้หลังการรอบ PPTX ให้ใช้ [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) และตรวจสอบผลลัพธ์หลังจากเปิดไฟล์ใหม่ ส่วนหัวข้อข้อจำกัดรูปแบบอธิบายความแตกต่างนี้อย่างละเอียดเพิ่มเติม

## **ปรับการแปลงสี**

เอฟเฟกต์สีสามารถนำไปใช้แยกกันกับกรอบรูปหลายกรอบที่ใช้ทรัพยากรภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้ากรอบและใช้สีเทา, duotone, tint, การปรับ HSL, และการแทนที่สี

[IDuotone](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iduotone/) มีพารามิเตอร์สีสองค่า `get_Color1` สำหรับพิกเซลสีมืดและ `get_Color2` สำหรับพิกเซลสีสว่าง ทำให้เป็นตัวอย่างที่ดีของเอฟเฟกต์ที่ตั้งค่าซับซ้อนกว่าค่าสเกลาร์เดียว

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีโดยคงค่า alpha ไว้ ซึ่งต่างจาก [AddColorChangeEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) ที่แมปสีต้นทางไปยังสีเป้าหมายและเปิดเผยรูปแบบสีของทั้งสอง

## **เพิ่มเบลอร์, ความโปร่งใส, และเอฟเฟกต์ Alpha**

[AddBlurEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) มีผลต่อทุกช่องสีรวมถึง alpha ตั้งค่า `grow` เป็น `true` เมื่อขอบที่เบลอร์อาจขยายออกนอกขอบภาพเดิม

สำหรับความโปร่งใสสม่ำเสมอ ให้ใช้ [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) ซึ่งคูณค่า alpha ทุกค่าที่มีอยู่ ทำให้พิกเซลที่โปร่งใสบางส่วนยังคงแตกต่างตามสัดส่วน [AddAlphaReplaceEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) แทนที่จะกำหนดค่า alpha เดียวให้กับทุกพิกเซล [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) จะเปลี่ยน alpha เป็นสองระดับตามเกณฑ์

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

เอฟเฟกต์ alpha ที่ไม่มีพารามิเตอร์อื่น ๆ รวมถึง [AddAlphaCeilingEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) ซึ่งทำให้ทุกค่า alpha ที่ไม่เป็นศูนย์เป็นทึบเต็ม; [AddAlphaFloorEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) ทำให้ทุกค่า alpha ที่ต่ำกว่า 100% เป็นโปร่งใสเต็ม; และ [AddAlphaInverseEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) ที่เปลี่ยนค่า alpha เป็น `100% - alpha`

## **สร้างเชนเอฟเฟกต์ตามลำดับ**

แต่ละเมธอด `Add...Effect` จะเพิ่มออบเจ็กต์ใหม่ต่อท้ายคอลเลกชัน เราเรนเดอร์ใช้คอลเลกชันเป็นสายการประมวลผลตามลำดับ: ผลลัพธ์ของการดำเนินการ 0 จะเป็นอินพุตของการดำเนินการ 1 และต่อ ๆ ไป ดังนั้นการจัดลำดับเดียวกันแต่ต่างกันจะให้ภาพที่ต่างกัน

เช่น การใช้สีเทาตามด้วย tint จะลบข้อมูลสีโครเมาติกก่อนแล้วทำให้ผลลัพธ์ luminance มีสีใหม่ การใช้ tint ตามด้วยสีเทาจะลบ tint อีกครั้ง ในทำนองเดียวกัน การแทนที่ alpha สามารถเขียนทับค่าที่คำนวณจากการดำเนินการก่อนหน้าได้ ในขณะที่การปรับค่า alpha จะคงความแตกต่างเชิงสัมพัทธ์ไว้

ตัวอย่างต่อไปนี้สร้างเชนสี่ปฏิบัติการ, บันทึกเป็น PPTX, เปิดไฟล์ใหม่, ตรวจสอบชนิดและลำดับของการดำเนินการ, และเรนเดอร์ผลลัพธ์ที่เปิดใหม่:

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

คอลเลกชันไม่ได้บังคับให้มีเมทริกซ์ความเข้ากันที่จำกัดสี, alpha, และเบลอร์ให้แยกเป็นเชนต่าง ๆ พวกมันสามารถผสานรวมกันได้แต่บางการผสานอาจไม่มีประโยชน์ การแทนที่สีคงที่จะลบความแปรเปลี่ยน RGB ที่สร้างโดยเอฟเฟกต์สีก่อนหน้า; การใช้สีเทาหลัง duotone จะลบสองสีที่เลือก; การใช้เอฟเฟกต์ alpha ceiling, floor, replacement หรือ bi‑level สามารถลบรายละเอียด alpha ที่สร้างก่อนหน้าได้ สร้างเชนตามลำดับการประมวลผลพิกเซลที่ต้องการ แทนที่จะถือเป็นแฟล็กการจัดรูปแบบที่ไม่เรียงลำดับ

## **ตรวจสอบค่าแก้ไขได้และค่าที่คำนวณได้**

การดำเนินการที่แก้ไขได้คื้อ็อบเจ็กต์ที่เก็บไว้ใน `ISlidesPicture::get_ImageTransform` ขึ้นอยู่กับเอฟเฟกต์ บางอ็อบเจ็กต์อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง เช่น [IBlur](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iblur/) มี `set_Radius` และ `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/ialphamodulatefixed/) มี `set_Amount`, และ [IAlphaBiLevel](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/ialphabilevel/) มี `set_Threshold` เอฟเฟกต์สีอย่าง [IDuotone](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iduotone/) เปิดเผยอ็อบเจ็กต์ [IColorFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/icolorformat/) ที่เปลี่ยนแปลงได้

อินเทอร์เฟซบางอย่างรวมถึง [IBrightnessContrast](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/itint/), และ [IAlphaReplace](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/ialphareplace/) ไม่ได้เปิดเผยสเกลาร์การสร้างเป็นคุณสมบัติเขียนได้ เพื่อเปลี่ยนการตั้งค่าเหล่านี้ ให้ลบการดำเนินการแล้วเพิ่มการทดแทนในตำแหน่งที่ต้องการ

ข้อมูลที่คำนวณโดย `GetEffective()` เป็นค่าที่คำนวณแล้วและอ่าน‑อย่าง‑เดียว มีประโยชน์สำหรับการแก้ไขสีที่ขึ้นกับธีมและการอ่านค่าที่ทำให้เรนเดอร์ใช้ แต่ไม่ได้เป็นพื้นผิวการแก้ไขใหม่ ตัวอย่างต่อไปนี้วนผ่านเชนและตรวจสอบค่าที่คำนวณได้สำหรับหลายการดำเนินการทั่วไป:

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

เอฟเฟกต์ที่ไม่มีพารามิเตอร์เช่นสีเทา, alpha ceiling, และ alpha inverse ยังคงมีออบเจ็กต์ข้อมูลที่คำนวณได้ แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์ การมีอยู่และตำแหน่งในคอลเลกชันคือข้อมูลสำคัญ

## **ลบหรือเคลียร์การแปลงภาพ**

ใช้ [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) เพื่อลบการดำเนินการหนึ่งรายการโดยใช้ดัชนี เนื่องจากดัชนีจะสับเปลี่ยนหลังการลบ ให้ค้นหาตัวเป้าหมายก่อนแล้วลบหลังจากวนรายการ ใช้ `Clear()` เพื่อลบเชนทั้งหมด

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

การลบหรือเคลียร์การแปลงเปลี่ยนเฉพาะการจัดรูปแบบของรูปภาพ ไม่ได้ลบ, บีบอัดใหม่, หรือแก้ไขทรัพยากร [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบงานนำเสนอและเป้าหมายการส่งออก**

การแปลงภาพเริ่มต้นจาก DrawingML ดังนั้น PPTX จึงเป็นรูปแบบที่แก้ไขได้ดีที่สุดสำหรับเชนเอฟเฟกต์ แม้กับ PPTX การดำเนินการแต่ละอย่างอาจมีความพกพาที่ต่างกัน:

- การดำเนินการ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และเอฟเฟกต์ alpha ทั่วไปมีโอกาสรอดชีวิตจากรอบ PPTX มากที่สุด ควรเปิดไฟล์ที่สร้างแล้วตรวจสอบคอลเลกชันทุกครั้งเมื่อการเก็บรักษาเป็นข้อกำหนด
- [BrightnessContrast](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/brightnesscontrast/) เป็นส่วนขยาย Office 2010 ไม่ใช่การดำเนินการ luminance ของ DrawingML มาตรฐาน สามารถใช้เพื่อเรนเดอร์ในหน่วยความจำได้แต่ไม่ได้รับประกันว่าจะคงเป็น [IBrightnessContrast](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/ibrightnesscontrast/) ที่แก้ไขได้หลังการบันทึกและเปิดไฟล์ PPTX แนะนำให้ใช้ [AddLuminanceEffect](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) สำหรับการปรับความสว่างและคอนทราสต์ที่คงที่
- รูปแบบไบนารี PPT มีอายุยาวกว่ารุ่นโมเดลเอฟเฟกต์ DrawingML เต็มรูปแบบ การบันทึกเป็น PPT อาจละเว้นการดำเนินการที่ไม่ได้รับการสนับสนุน, ลดเชนลงเป็นส่วนย่อยที่สนับสนุน, หรือประมาณลักษณะที่แสดง อย่าใช้ PPT เป็นรูปแบบตรวจสอบสำหรับเชนที่แก้ไขได้ซับซ้อน
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือรูปแบบภาพอื่น ๆ จะใช้เชนที่สนับสนุนกับลักษณะที่เรนเดอร์ออกมา รูปแบบเหล่านั้นไม่มี `IImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบเรสเตอร์ทำให้ผลลัพธ์แปลงเป็นพิกเซล, และการส่งออกเอกสารหรือเวกเตอร์จะจัดเก็บการแทนภาพของตนเอง
- เอฟเฟกต์ไม่ได้ทำให้ภาพที่ลิงก์เป็นไฟล์ที่อยู่ในตัว การเรนเดอร์รูปภาพที่ลิงก์ยังคงพึ่งพาทรัพยากรที่ลิงก์อยู่เมื่อเปิดงานนำเสนอ

ผู้ใช้งานนำเสนอที่ต่างกันอาจเรนเดอร์กรณีขอบต่างกัน โดยเฉพาะเมื่อผสานหลายเอฟเฟกต์ alpha หรือการควอนตายสี การทดสอบทั้งรอบแก้ไขและรูปแบบส่งออกขั้นสุดท้ายด้วยรุ่น Aspose.Slides ที่ใช้ในผลิตภัณฑ์เป็นเรื่องสำคัญ

## **FAQ**

**เอฟเฟกต์การแปลงภาพทำให้ข้อมูลภาพฝังเปลี่ยนแปลงหรือไม่?**

ไม่มี การดำเนินการเป็นของ `ISlidesPicture` ที่ใช้โดยการเติมรูปภาพ ไบต์ของ `IPPImage` พื้นฐานจะไม่ถูกแก้ไข

**สองกรอบรูปที่ใช้ `IPPImage` เดียวกันจะใช้เอฟเฟกต์ร่วมกันหรือไม่?**

ไม่มี การใช้ `IPPImage` ซ้ำช่วยหลีกเลี่ยงข้อมูลภาพซ้ำกันแต่ละกรอบรูปโดยทั่วไปจะมี `ISlidesPicture` และคอลเลกชันการแปลงภาพของตนเอง

**สามารถผสานเอฟเฟกต์สี, เบลอร์, และ alpha ได้หรือไม่?**

ได้ คอลเลกชันรับพวกมันในเชนที่เรียงลำดับ ควรพิจารณาว่าแต่ละการดำเนินการทำอะไรกับผลลัพธ์ของการดำเนินการก่อนหน้า เพราะเอฟเฟกต์การแทนที่และเกณฑ์อาจลบดึงรายละเอียดสีหรือ alpha ก่อนหน้า

**ทำไมค่าที่คำนวณได้จึงเป็นอ่าน‑อย่าง‑เดียว?**

ข้อมูลที่คำนวณเป็นค่าที่ใช้สำหรับการเรนเดอร์รวมถึงสีที่แก้ไขแล้ว แก้ไขการดำเนินการที่เก็บในคอลเลกชันที่มีสมาชิกที่เขียนได้; หากไม่มีให้ลบและเพิ่มการทดแทนด้วยพารามิเตอร์การสร้างใหม่

**ควรใช้รูปแบบใดเพื่อคงเชนการแปลง?**

ใช้ PPTX และตรวจสอบไฟล์โดยการเปิดใหม่อีกครั้ง PPT รุ่นเก่าไม่สามารถแสดงโมเดลเอฟเฟกต์ DrawingML ทั้งหมดได้ และรูปแบบส่งออกที่เรนเดอร์จะเก็บลักษณะการแสดงผลแทนการดำเนินการแปลงที่แก้ไขได้