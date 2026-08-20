---
title: จัดการกรอบรูปภาพในงานนำเสนอโดยใช้ C++
linktitle: กรอบรูปภาพ
type: docs
weight: 10
url: /th/cpp/picture-frame/
keywords:
- กรอบรูปภาพ
- เพิ่มกรอบรูปภาพ
- สร้างกรอบรูปภาพ
- ภาพที่ฝังไว้
- ภาพเชื่อมโยง
- สกัดภาพ
- ภาพแรสเตอร์
- ภาพ SVG
- ครอบตัดภาพ
- ลบพื้นที่ที่ครอบตัด
- บีบอัดภาพ
- StretchOffset
- การจัดรูปแบบกรอบรูปภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอบตัด, สกัด, และบีบอัดกรอบรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

กรอบรูปภาพเป็นรูปร่างของสไลด์ที่แสดงรูปภาพ ใน Aspose.Slides, แหล่งรูปภาพและรูปร่างที่แสดงรูปนั้นเป็นออบเจกต์แยกกัน: [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ถือครองทรัพยากรรูปภาพที่ฝังอยู่ผ่าน [image collection](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_images/), ในขณะที่ [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) ควบคุมตำแหน่งของรูปภาพ, ขนาด, การจัดรูปแบบเส้น, การหมุน, การครอป, เอฟเฟกต์รูปภาพ, และการตั้งค่าระดับกรอบอื่นๆ

การแยกนี้เป็นประโยชน์เมื่อรูปเดียวกันถูกแสดงหลายครั้ง เพิ่มรูปภาพลงในงานนำเสนอเพียงครั้งเดียว, เก็บ [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) ที่คืนค่า, แล้วใช้ทรัพยากรรูปนั้นเมื่อสร้างกรอบรูปภาพ

กรอบรูปภาพสามารถบรรจุรูปภาพเรสเตอร์เช่น PNG หรือ JPEG และรูปภาพเวกเตอร์ SVG ได้ นอกจากนี้ยังสามารถอ้างอิงรูปภาพที่เชื่อมโยงแทนการเก็บบิตของรูปภาพในงานนำเสนอ ตัวเลือกนี้มีผลต่อการพกพา, ขนาดไฟล์, การสกัด, และพฤติกรรมการส่งออก ดังนั้นจึงควรตัดสินใจว่ารูปภาพควรถูกจัดเก็บอย่างไรก่อนการจัดรูปแบบหรือการเพิ่มประสิทธิภาพ

## **เพิ่มและจัดรูปแบบภาพที่ฝังไว้**

สำหรับภาพที่ฝังไว้ ให้เพิ่มข้อมูลภาพลงในงานนำเสนอและสร้างกรอบรูปภาพด้วย [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapecollection/addpictureframe/). ภาพจะกลายเป็นส่วนหนึ่งของแพ็กเกจงานนำเสนอ ดังนั้นงานนำเสนอจะคงความเป็นอิสระเมื่อถูกย้ายไปยังคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG, สร้างกรอบที่มีมิติดั้งเดิมของภาพ, และใช้การจัดรูปแบบเส้นและการหมุน:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

กรอบรูปภาพควบคุมเรขาคณิตที่แสดง; การเปลี่ยนขนาดกรอบไม่ได้เปลี่ยนมิติพิกเซลดั้งเดิมที่เก็บไว้ในทรัพยากรภาพที่ฝังไว้ ความแตกต่างนี้สำคัญเมื่อทำการครอปหรือบีบอัดภาพในภายหลัง

## **ใช้สเกลสัมพัทธ์**

[IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) เปิดเผยการสเกลความกว้างและความสูงแบบสัมพัทธ์สำหรับกรอบ ค่า `1.0` ตรงกับ 100% ของขนาดรูปต้นฉบับ สเกลสัมพัทธ์มีประโยชน์เมื่อกระบวนการทำงานต้องการรักษาความสัมพันธ์กับขนาดรูปภาพต้นฉบับแทนการคำนวณมิติสุดท้ายด้วยตนเอง

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

สเกลสัมพัทธ์เปลี่ยนการตั้งค่าสเกลของกรอบ; มันไม่ได้ทำการรีแซมป์หรือบีบอัดภาพที่ฝังไว้

## **ภาพที่ฝังและภาพเชื่อมโยง**

ภาพที่ฝังไว้เก็บข้อมูลภาพภายในงานนำเสนอและจึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับการพกพาและการเรนเดอร์ที่คาดเดาได้ ภาพเชื่อมโยงเก็บตำแหน่งภายนอกผ่านเส้นทางลิงก์ของ [ISlidesPicture](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidespicture/) แทนการฝังข้อมูลภาพในแบบเดียวกัน

ภาพเชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บใน PPTX ได้ แต่ก็สร้างการพึ่งพาภายนอก ไฟล์ที่เชื่อมโยงต้องยังคงเข้าถึงได้สำหรับแอปพลิเคชันที่เปิดหรือเรนเดอร์งานนำเสนอ หากเส้นทางเปลี่ยน, ไฟล์ถูกย้าย, หรือทรัพยากรไม่พร้อมใช้งาน, ภาพเชื่อมโยงอาจไม่แสดงตามที่คาดไว้ สำหรับงานนำเสนอที่ต้องส่งอีเมล, เก็บถาวร, หรือเรนเดอร์ในสภาพแวดล้อมแยก, ภาพที่ฝังไว้มักจะเชื่อถือได้มากกว่า

### **เพิ่มภาพเชื่อมโยง**

ตัวอย่างต่อไปนี้สร้างกรอบรูปภาพและชี้ไปยังไฟล์ภาพในเครื่อง มันจัดการเฉพาะการเชื่อมโยงภาพ; การเชื่อมโยงวิดีโอเป็นกระบวนการสื่อแยกต่างหากและไม่ได้ผสมอยู่ในตัวอย่างนี้

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นเจตนา อย่าใช้มันเป็นการแทนที่การบีบอัด: PPTX เล็ก ๆ ที่มีการพึ่งพาภาพเสียหายมักจะใช้ได้น้อยกว่างานนำเสนอที่เป็นอิสระแต่ขนาดใหญ่กว่า

## **ดึงรูปภาพจากกรอบรูปภาพ**

ก่อนดึงรูปภาพจากงานนำเสนอที่มีอยู่, ตรวจสอบว่ารูปร่างเป็นจริง ๆ แล้วเป็น [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) และว่ามีภาพที่ฝังอยู่ กรอบรูปภาพเชื่อมโยงอาจไม่มีบิตของภาพที่สามารถสกัดได้ในแบบเดียวกัน

### **ดึงรูปภาพเรสเตอร์**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) โดยตรง ตัวอย่างต่อไปนี้ค้นหารูปเรสเตอร์ที่ฝังคแรกบนสไลด์และบันทึกเป็น PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

การบันทึกผ่าน [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) จะแปลงภาพที่สกัดเป็นรูปแบบผลลัพธ์ที่ร้องขอ หากคุณต้องการบิตที่เข้ารหัสเก็บในงานนำเสนอแทนไฟล์เรสเตอร์ที่แปลงแล้ว ให้ใช้ข้อมูลไบนารีของทรัพยากรภาพแทน

### **ดึงรูปภาพ SVG**

สำหรับภาพ SVG, [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) เปิดเผยอ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/). สิ่งนี้ทำให้คุณสามารถดึงข้อมูล SVG โดยตรงแทนการเรสเตอรไลซ์ภาพก่อน

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

การเก็บเนื้อหา SVG เป็น SVG จะคงแหล่งเวกเตอร์ไว้ในงานนำเสนอ การส่งออกเป็นเรสเตอร์เช่น PNG หรือ JPEG จำเป็นต้องเรนเดอร์เนื้อหาเวกเตอร์เป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถือว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ที่ฝังไว้; ใช้ข้อมูล [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/) ที่ฝังไว้เมื่อจำเป็นต้องใช้ทรัพยากรเวกเตอร์เดิม

## **ครอบตัดภาพ**

การครอบตัดเปลี่ยนส่วนของภาพที่เห็นได้ภายในกรอบ ค่าครอบตัดบน [IPictureFillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอบตัดไม่ได้ลบพิกเซลที่ซ่อนอยู่จากภาพที่ฝังไว้ในขั้นต้น; มันเพียงเปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหากรอบรูปภาพอย่างปลอดภัยและใช้ค่า ครอบตัด:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
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
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

เพราะข้อมูลภาพที่ซ่อนอยู่ยังคงอยู่, การครอบตัดสามารถเปลี่ยนแปลงในภายหลังโดยไม่สูญเสียพิกเซลดั้งเดิม หากขนาดไฟล์สำคัญกว่าการย้อนกลับ, ส่วนที่ครอบตัดสามารถลบออกทางกายภาพได้ตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลภาพที่ถูกครอบตัด**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอบตัดปัจจุบันและคืนทรัพยากรภาพที่ได้ ผลลัพธ์สามารถลดขนาดไฟล์ได้, แต่เป็นการเพิ่มประสิทธิภาพทำลาย: หลังจากบันทึกงานนำเสนอ, พิกเซลที่ถูกลบจะไม่มีให้ใช้สำหรับการยกเลิกการครอบตัดในภายหลัง

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
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
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

เมธอดนี้อาจเพิ่มทรัพยากรภาพใหม่ลงในงานนำเสนอ หากภาพต้นฉบับยังถูกใช้โดยกรอบรูปภาพอื่น ๆ กรอบเหล่านั้นยังต้องการทรัพยากรที่มีอยู่เดิม, ดังนั้นการลบพื้นที่ที่ครอบตัดไม่ได้จำเป็นต้องลดจำนวนภาพทั้งหมด การครอบตัดเนื้อหา WMF หรือ EMF ด้วยเมธอดนี้จะเรสเตอรไลซ์ผลลัพธ์ที่ครอบตัดเป็น PNG

## **บีบอัดภาพเรสเตอร์**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/compressimage/) ลดความละเอียดของภาพเรสเตอร์สัมพันธ์กับขนาดที่ภาพแสดง มันยังสามารถลบส่วนที่ครอบตัดในขั้นตอนเดียวได้ เมธอดคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอบตัดและ `false` เมื่อไม่จำเป็นต้องเปลี่ยนแปลง

ใช้ค่า [PicturesCompression](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/picturescompression/) ที่กำหนดไว้ล่วงหน้าหากความละเอียดเป้าหมายมาตรฐานเพียงพอ:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
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
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

สามารถส่งค่า DPI บวกที่กำหนดเองได้แทนค่าตัวระบุเมื่อจำเป็นต้องใช้เป้าหมายเฉพาะ

การบีบอัดออกแบบมาสำหรับภาพเรสเตอร์ SVG และเนื้อหาเมตาไฟล์ไม่ได้รับการลดโดยกระบวนการบีบอัดเรสเตอร์นี้ นอกจากนี้ยังจำไว้ว่าความละเอียดที่ต่ำลงและการลบส่วนที่ครอบตัดไม่สามารถกู้คืนจากงานนำเสนอที่เพิ่มประสิทธิภาพแล้ว เลือกความละเอียดเป้าหมายตามขนาดสูงสุดที่ภาพจะถูกดูหรือส่งออกจริง ๆ แทนการใช้ DPI ต่ำสุดทั่วทั้งงาน

## **ตรวจสอบเอฟเฟกต์ภาพ**

เอฟเฟกต์ภาพถูกเก็บบนรูปภาพที่กรอบใช้ คอลเลกชันการแปลงภาพอาจมีเอฟเฟกต์เช่นการปรับค่าตามแอลฟ่าคงที่สำหรับความโปร่งแสงและความสว่างสำหรับความสว่างและคอนทราสต์ ตัวอย่างด้านล่างอ่านเอฟเฟกต์สองประเภทจากกรอบรูปภาพแรกบนสไลด์อย่างปลอดภัย:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
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

auto presentation = MakeObject<Presentation>(u"sample.pptx");
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

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

เอฟเฟกต์เหล่านี้เปลี่ยนวิธีการเรนเดอร์ภาพในกรอบ; พวกมันไม่ได้เขียนทับบิตของภาพที่ฝังอยู่เดิม

## **ล็อคเรขาคณิตของกรอบรูปภาพ**

การตั้งค่า [IPictureFrameLock](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframelock/) ควบคุมการทำงานแก้ไขที่ถูกปิดใช้งานสำหรับกรอบรูปภาพ ตัวอย่างเช่น [aspect-ratio lock](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) รักษาสัดส่วนของรูปร่างขณะปรับขนาด

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การล็อคนี้ใช้กับรูปร่างกรอบรูปภาพ ไม่บังคับให้ภาพต้นฉบับต้องรีแซมป์หรือเปลี่ยนเป็นสัดส่วนเดียวกันอย่างถาวร

## **ปรับค่า StretchOffset**

เมื่อโหมดการเติมรูปเป็น stretch, ค่า stretch-offset บน [IPictureFillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/) กำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบของกรอบรูปภาพ ค่าเปอร์เซ็นต์บวกสร้างการเยื้องจากขอบ, ขณะที่ค่าเปอร์เซ็นต์ลบสร้างการยืดออก

นี่แตกต่างจากการครอบตัด ค่า ครอบตัดเลือกส่วนของภาพต้นฉบับที่มองเห็น; stretch offset เปลี่ยนสี่เหลี่ยมที่ภาพเติมที่มองเห็นถูกยืดออก

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ใช้ stretch offset สำหรับการวางตำแหน่งเติม ใช้คุณสมบัติกรอบตัดเมื่อเป้าหมายคือการซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ, ขนาดไฟล์, และการพิจารณาการส่งออก**

การแลกเปลี่ยนหลักจะง่ายต่อการจัดการเมื่อการจัดเก็บภาพและการจัดรูปแบบกรอบรูปภาพแยกกัน:

- **ภาพที่ฝัง** ทำให้งานนำเสนอเป็นอิสระและเป็นที่เชื่อถือได้ที่สุดสำหรับการแชร์และการเรนเดอร์บนเซิร์ฟเวอร์, แต่ภาพเรสเตอร์ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **ภาพเชื่อมโยง** สามารถทำให้แพ็กเกจเล็กลง, แต่งานนำเสนอขึ้นกับไฟล์ภายนอกที่ต้องยังคงมีให้ตามเส้นทางหรือสถานที่ที่เก็บไว้
- **การครอบตัด** ในตอนแรกไม่ทำลายข้อมูล พิกเซลที่ซ่อนอยู่ยังคงฝังอยู่จนกว่าจะลบพื้นที่ที่ครอบตัดอย่างชัดเจนหรือถูกลบระหว่างการบีบอัด
- **การบีบอัด** สามารถลดขนาดไฟล์ได้อย่างมากสำหรับภาพเรสเตอร์ที่ใหญ่เกินไป, แต่จะเสียความละเอียดต้นฉบับ ควรทำหลังจากทราบขนาดบนสไลด์ที่ต้องการแล้ว
- **ภาพ SVG** ควรคงเป็น SVG เมื่อการรักษาเวกเตอร์สำคัญ ดึง SVG ที่ฝังไว้โดยตรงเมื่อคุณต้องการทรัพยากรเวกเตอร์เอง การส่งออกสไลด์เป็นเรสเตอร์เสมอจะเปลี่ยนสไลด์ที่เรนเดอร์เป็นพิกเซล
- **ภาพที่ใช้ซ้ำ** ควรใช้ทรัพยากร [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) ที่มีอยู่แล้วเมื่อทำได้แทนการโหลดไฟล์เดียวกันซ้ำหลายครั้งในกระบวนการทำงานของงานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่, การเพิ่มประสิทธิภาพภาพมักมีประสิทธิผลสูงสุดเมื่อทำอย่างเลือกสรร: เก็บโลโก้และไดอะแกรมเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงจริง, ลบพิกเซลที่ครอบตัดเฉพาะเมื่อไม่ต้องการการแก้ไขต่อในภายหลัง, และหลีกเลี่ยงลิงก์ภายนอกเว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **คำถามที่พบบ่อย**

**กรอบรูปภาพกับทรัพยากรรูปภาพต่างกันอย่างไร?**

[IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) แสดงทรัพยากรรูปภาพที่เชื่อมโยงกับงานนำเสนอ [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) เป็นรูปร่างบนสไลด์ที่แสดงรูปภาพและเก็บเรขาคณิตระดับกรอบและการจัดรูปแบบเช่นขนาด, การหมุน, ค่า ครอบตัด, เอฟเฟกต์, และการล็อค

**ควรฝังหรือเชื่อมโยงภาพ?**

ฝังภาพเมื่อ งานนำเสนอจำเป็นต้องพกพา, เก็บถาวร, หรือเรนเดอร์โดยไม่ต้องเข้าถึงทรัพยากรภายนอก. เชื่อมโยงภาพเฉพาะเมื่อตั้งใจเก็บไฟล์ภาพนอก PPTX และตำแหน่งภายนอกสามารถดูแลได้อย่างเชื่อถือได้

**การครอบตัดลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตัวมันเอง การตั้งค่าครอบตัดปกติซ่อนส่วนของภาพต้นฉบับแต่ยังคงพิกเซลอยู่ ใช้ [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) หรือการบีบอัดภาพพร้อมการลบส่วนที่ครอบตัดเมื่อพิกเซลเหล่านั้นสามารถถูกทิ้งได้อย่างถาวร

**ฉันสามารถกู้คุณภาพภาพหลังการบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดเรสเตอร์ที่เก็บและการลบส่วนที่ครอบตัดจะทำให้ข้อมูลภาพหายไป เก็บภาพต้นฉบับนอกงานนำเสนอหากอาจต้องแก้ไขความละเอียดสูงในภายหลัง

**ควรจัดการภาพ SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความแม่นยำของเวกเตอร์สำคัญ [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/) ที่ฝังไว้สามารถดึงออกได้โดยตรง การเรนเดอร์สไลด์เป็นรูปแบบเรสเตอร์เช่น PNG หรือ JPEG จะทำให้ SVG ถูกแปลงเป็นพิกเซลเป็นส่วนหนึ่งของภาพสไลด์

**จะหลีกเลี่ยงการแคสต์ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของรูปร่างก่อนใช้สมาชิกที่เฉพาะเจาะจงกับกรอบรูปภาพ ทดสอบรูปร่างด้วย [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) ก่อนทำการแคสต์เวลาเรียกใช้, และกำหนดผลลัพธ์ของการแคสต์ให้กับตัวแปรท้องถิ่นก่อนเข้าถึงสมาชิกที่เฉพาะเจาะจงกับกรอบรูปภาพ