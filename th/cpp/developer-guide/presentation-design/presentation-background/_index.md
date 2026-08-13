---
title: "จัดการพื้นหลังของงานนำเสนอใน C++"
linktitle: "พื้นหลังสไลด์"
type: docs
weight: 20
url: /th/cpp/presentation-background/
keywords:
- "พื้นหลังของงานนำเสนอ"
- "พื้นหลังสไลด์"
- "สีทึบ"
- "สีไล่ระดับสี"
- "พื้นหลังรูปภาพ"
- "ความโปร่งใสของพื้นหลัง"
- "คุณสมบัติของพื้นหลัง"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "C++"
- "Aspose.Slides"
description: "เรียนรู้วิธีตั้งค่าพื้นหลังแบบไดนามิกในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++ พร้อมเคล็ดลับโค้ดเพื่อยกระดับงานนำเสนอของคุณ."
---
## **บทนำ**

สีทึบ, ไล่ระดับสี, และรูปภาพเป็นวิธีที่ใช้บ่อยสำหรับพื้นหลังของสไลด์ คุณสามารถตั้งค่าพื้นหลังสำหรับ **สไลด์ปกติ** (สไลด์เดี่ยว) หรือ **สไลด์แม่** (ใช้กับหลายสไลด์พร้อมกัน)

![พื้นหลัง PowerPoint](powerpoint-background.png)

## **ตั้งค่าสีทึบเป็นพื้นหลังของสไลด์ปกติ**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังสำหรับสไลด์เฉพาะในงานนำเสนอ — แม้ว่างานนำเสนอจะใช้สไลด์แม่อยู่ การเปลี่ยนแปลงนี้จะมีผลเฉพาะสไลด์ที่เลือกเท่านั้น

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. ตั้งค่า[BackgroundType](https://reference.aspose.com/slides/th/cpp/aspose.slides/backgroundtype/)ของสไลด์เป็น`OwnBackground`  
3. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/)ของพื้นหลังสไลด์เป็น`Solid`  
4. ใช้วิธีการ[get_SolidFillColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/get_solidfillcolor/)บน[FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/)เพื่อระบุสีพื้นหลังแบบทึบ  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C++ ด้านล่างจะแสดงวิธีตั้งค่าสีทึบสีฟ้าเป็นพื้นหลังของสไลด์ปกติ:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Set the background color of the slide to blue.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save the presentation to disk.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งค่าสีทึบเป็นพื้นหลังของสไลด์แม่**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังของสไลด์แม่ในงานนำเสนอ สไลด์แม่ทำหน้าที่เป็นเทมเพลตที่ควบคุมการจัดรูปแบบของทุกสไลด์ ดังนั้นเมื่อคุณเลือกสีทึบเป็นพื้นหลังของสไลด์แม่ มันจะนำไปใช้กับสไลด์ทั้งหมด

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. ตั้งค่า[BackgroundType](https://reference.aspose.com/slides/th/cpp/aspose.slides/backgroundtype/)ของสไลด์แม่ (ผ่าน`get_Masters`) เป็น`OwnBackground`  
3. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/)ของพื้นหลังสไลด์แม่เป็น`Solid`  
4. ใช้วิธีการ[get_SolidFillColor](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/get_solidfillcolor/)เพื่อระบุสีพื้นหลังแบบทึบ  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C++ ด้านล่างจะแสดงวิธีตั้งค่าสีทึบ (สีเขียวป่า) เป็นพื้นหลังของสไลด์แม่:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Set the background color for the Master slide to Forest Green.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Save the presentation to disk.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งค่าพื้นหลังแบบไล่ระดับสีสำหรับสไลด์**

ไล่ระดับสีเป็นเอฟเฟกต์กราฟิกที่สร้างโดยการเปลี่ยนสีอย่างค่อยเป็นค่อยไป เมื่อใช้เป็นพื้นหลังของสไลด์ ไล่ระดับสีสามารถทำให้งานนำเสนอดูศิลปะและเป็นมืออาชีพมากขึ้น Aspose.Slides ให้คุณตั้งค่าพื้นหลังสไลด์เป็นสีไล่ระดับสี

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. ตั้งค่า[BackgroundType](https://reference.aspose.com/slides/th/cpp/aspose.slides/backgroundtype/)ของสไลด์เป็น`OwnBackground`  
3. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/)ของพื้นหลังสไลด์เป็น`Gradient`  
4. ใช้วิธีการ[get_GradientFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/get_gradientformat/)บน[FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/)เพื่อกำหนดการตั้งค่าไล่ระดับสีตามที่ต้องการ  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C++ ด้านล่างจะแสดงวิธีตั้งค่าสีไล่ระดับสีเป็นพื้นหลังของสไลด์:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// ใช้เอฟเฟกต์ไล่ระดับสีกับพื้นหลัง.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// บันทึกงานนำเสนอลงดิสก์.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตั้งค่ารูปภาพเป็นพื้นหลังของสไลด์**

นอกจากการเติมสีทึบและไล่ระดับสีแล้ว Aspose.Slides ยังให้คุณใช้รูปภาพเป็นพื้นหลังของสไลด์ได้

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. ตั้งค่า[BackgroundType](https://reference.aspose.com/slides/th/cpp/aspose.slides/backgroundtype/)ของสไลด์เป็น`OwnBackground`  
3. ตั้งค่า[FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/)ของพื้นหลังสไลด์เป็น`Picture`  
4. โหลดรูปภาพที่ต้องการใช้เป็นพื้นหลังสไลด์  
5. เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของงานนำเสนอ  
6. ใช้วิธีการ[get_PictureFillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/get_picturefillformat/)บน[FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/fillformat/)เพื่อตั้งค่ารูปภาพเป็นพื้นหลัง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C++ ด้านล่างจะแสดงวิธีตั้งค่ารูปภาพเป็นพื้นหลังของสไลด์:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// ตั้งคุณสมบัติของรูปภาพพื้นหลัง.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// โหลดรูปภาพ.
auto image = Images::FromFile(u"Tulips.jpg");
// เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของงานนำเสนอ.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// บันทึกงานนำเสนอลงดิสก์.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่า FillType ของพื้นหลังเป็นรูปภาพแบบต่อเนื่องและแก้ไขคุณสมบัติการต่อรูป:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}}
อ่านเพิ่มเติม: [**Tile Picture As Texture**](/slides/th/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **เปลี่ยนความโปร่งใสของรูปภาพพื้นหลัง**

คุณอาจต้องการปรับความโปร่งใสของรูปภาพพื้นหลังสไลด์เพื่อให้เนื้อหาของสไลด์เด่นชัดขึ้น ตัวอย่าง C++ ด้านล่างจะแสดงวิธีเปลี่ยนความโปร่งใสของรูปภาพพื้นหลังสไลด์:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // เช่น.

 // Create an instance of the Presentation class.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Get the collection of picture transform operations.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Find an existing fixed-percentage transparency effect.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// Save the presentation to disk.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **รับค่าพื้นหลังของสไลด์**

Aspose.Slides มีอินเทอร์เฟซ[IBackgroundEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibackgroundeffectivedata/)สำหรับดึงค่าพื้นหลังที่มีผลของสไลด์ อินเทอร์เฟซนี้ให้เข้าถึง [FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) และ[EffectFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) ที่มีผล

โดยใช้เมธอด`get_Background`ของคลาส[BaseSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseslide/) คุณสามารถรับพื้นหลังที่มีผลของสไลด์ได้

ตัวอย่าง C++ ด้านล่างแสดงวิธีรับค่าพื้นหลังที่มีผลของสไลด์:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Retrieve the effective background, taking into account master, layout, and theme.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **FAQ**

### ฉันสามารถรีเซ็ตพื้นหลังที่กำหนดเองและคืนค่าเป็นพื้นหลังของธีม/เค้าโครงได้ไหม?

ได้ คุณเพียงลบการเติมสีที่กำหนดเองของสไลด์ แล้วพื้นหลังจะสืบทอดจากสไลด์[layout](/slides/th/cpp/slide-layout/)/[master](/slides/th/cpp/slide-master/) ที่เกี่ยวข้อง (เช่น [theme background](/slides/th/cpp/presentation-theme/))

### จะเกิดอะไรขึ้นกับพื้นหลังหากฉันเปลี่ยนธีมของงานนำเสนอภายหลัง?

หากสไลด์มีการเติมสีของตนเอง มันจะคงอยู่ไม่เปลี่ยนแปลง หากพื้นหลังสืบทอดจาก[layout](/slides/th/cpp/slide-layout/)/[master](/slides/th/cpp/slide-master/) มันจะอัปเดตให้ตรงกับ[ธีมใหม่](/slides/th/cpp/presentation-theme/)  