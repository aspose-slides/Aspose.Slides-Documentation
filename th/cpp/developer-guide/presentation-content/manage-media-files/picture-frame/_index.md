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
- ภาพที่ฝัง
- ภาพที่เชื่อมโยง
- ดึงภาพ
- ภาพเรสเซอร์
- ภาพ SVG
- ครอบภาพ
- ลบพื้นที่ที่ครอบ
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
description: "สร้าง, จัดรูปแบบ, เชื่อมโยง, ครอบ, ดึง, และบีบอัดกรอบรูปภาพในงานนำเสนอด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

กรอบรูปภาพคือรูปร่างบนสไลด์ที่แสดงรูปภาพ ใน Aspose.Slides, ทรัพยากรรูปภาพและรูปร่างที่แสดงรูปภาพแยกกันเป็นอ็อบเจกต์: a [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) owns embedded image resources through its [image collection](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_images/), while an [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) controls the image's position, size, line formatting, rotation, cropping, picture effects, and other frame-level settings.

การแยกนี้มีประโยชน์เมื่อรูปภาพเดียวกันต้องแสดงหลายครั้ง เพิ่มรูปภาพลงในงานนำเสนอเพียงครั้งเดียว, เก็บ [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) ที่ได้รับคืน, แล้วใช้ทรัพยากรรูปภาพนั้นเมื่อสร้างกรอบรูปภาพ

กรอบรูปภาพสามารถบรรจุรูปแบบแรสเตอร์เช่น PNG หรือ JPEG และรูปแบบเวกเตอร์ SVG ได้ นอกจากนี้ยังสามารถอ้างอิงรูปภาพที่เชื่อมโยงแทนการเก็บไบต์ของรูปภาพไว้ในงานนำเสนอ การเลือกนี้มีผลต่อความพกพา, ขนาดไฟล์, การสกัดและพฤติกรรมการส่งออก ดังนั้นจึงควรตัดสินใจว่าจะเก็บรูปภาพอย่างไรก่อนที่จะทำการจัดรูปแบบหรือเพิ่มประสิทธิภาพ

## **เพิ่มและจัดรูปแบบภาพที่ฝัง**

สำหรับภาพที่ฝัง, ให้เพิ่มข้อมูลภาพลงในงานนำเสนอและสร้างกรอบรูปภาพด้วย [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapecollection/addpictureframe/). ภาพจะกลายเป็นส่วนหนึ่งของแพ็คเกจงานนำเสนอ ทำให้งานนำเสนอเป็นอิสระเมื่อนำไปใช้บนคอมพิวเตอร์เครื่องอื่น

ตัวอย่างต่อไปนี้เพิ่มภาพ JPEG, สร้างกรอบที่มีขนาดตามมิติเดิมของภาพ, แล้วใช้การจัดรูปแบบเส้นและการหมุน:

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

กรอบรูปภาพควบคุมเรดิยายที่แสดง; การเปลี่ยนขนาดกรอบจะไม่เปลี่ยนมิติพิกเซลดั้งเดิมที่เก็บในทรัพยากรภาพที่ฝัง ความแตกต่างนี้สำคัญเมื่อทำการครอบหรือบีบอัดภาพในภายหลัง

## **ใช้สเกลสัมพัทธ์**

[IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) เปิดเผยการปรับสเกลความกว้างและความสูงแบบสัมพัทธ์สำหรับกรอบ ค่า `1.0` หมายถึง 100% ของขนาดรูปภาพต้นฉบับ สเกลสัมพัทธ์มีประโยชน์เมื่อเวิร์กโฟลว์ต้องการคงอัตราส่วนกับขนาดรูปภาพต้นฉบับแทนการคำนวณขนาดสุดท้ายด้วยตนเอง

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

สเกลสัมพัทธ์เปลี่ยนการตั้งค่าสเกลของกรอบ; มันไม่ได้ทำการรีแซมพลล์หรือบีบอัดภาพที่ฝัง

## **ภาพที่ฝังและภาพที่เชื่อมโยง**

ภาพที่ฝังเก็บข้อมูลภาพไว้ภายในงานนำเสนอจึงเป็นตัวเลือกที่ปลอดภัยที่สุดสำหรับความพกพาและการแสดงผลที่คาดเดาได้ ส่วนภาพที่เชื่อมโยงจะเก็บพาธลิงก์ของ [ISlidesPicture](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidespicture/) แทนการฝังข้อมูลภาพในไฟล์เดียวกัน

ภาพที่เชื่อมโยงสามารถลดปริมาณข้อมูลภาพที่เก็บใน PPTX ได้ แต่ก็สร้างการพึ่งพาไฟล์ภายนอก ไฟล์ที่เชื่อมโยงต้องยังคงเข้าถึงได้สำหรับแอปพลิเคชันที่เปิดหรือแสดงงานนำเสนอ หากพาธเปลี่ยน, ไฟล์ถูกย้าย, หรือทรัพยากรไม่พร้อมใช้งาน, ภาพที่เชื่อมโยงอาจไม่แสดงตามที่คาดหวัง สำหรับงานนำเสนอที่ต้องส่งทางอีเมล, จัดเก็บ, หรือแสดงผลในสภาพแยก, ภาพที่ฝังมักจะน่าเชื่อถือกว่า

### **เพิ่มภาพที่เชื่อมโยง**

ตัวอย่างต่อไปนี้สร้างกรอบรูปภาพและชี้ไปยังไฟล์ภาพในเครื่องโดยตรง ตัวอย่างนี้จัดการเฉพาะการเชื่อมโยงภาพ; การเชื่อมโยงวิดีโอเป็นเวิร์กโฟลว์สื่อแยกต่างหากและไม่ได้รวมไว้ในตัวอย่างนี้

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

ใช้ลิงก์เมื่อการจัดการไฟล์ภายนอกเป็นที่ตั้งใจ อย่าใช้ลิงก์เป็นวิธีทดแทนการบีบอัด: PPTX ขนาดเล็กที่มีการพึ่งพาภาพเสียหายมักจะใช้งานได้น้อยกว่างานนำเสนอที่มีขนาดใหญ่และเป็นอิสระ

## **ดึงภาพจากกรอบรูปภาพ**

ก่อนดึงภาพจากงานนำเสนอที่มีอยู่, ตรวจสอบว่ารูปร่างเป็น [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) จริงและมีภาพที่ฝังอยู่หรือไม่ กรอบรูปภาพที่เชื่อมโยงอาจไม่มีไบต์ของภาพที่สามารถดึงได้ในลักษณะเดียวกัน

### **ดึงภาพเรสเซอร์**

API ภาพสมัยใหม่ใช้ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) โดยตรง ตัวอย่างต่อไปนี้ค้นหารูปเรสเซอร์ที่ฝังแรกบนสไลด์และบันทึกเป็น PNG:

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

การบันทึกผ่าน [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) จะเปลี่ยนภาพที่สกัดเป็นรูปแบบเอาต์พุตที่ร้องขอ หากต้องการไบต์ที่เข้ารหัสที่เก็บในงานนำเสนอแทนไฟล์เรสเซอร์ที่แปลงแล้ว, ให้ใช้ข้อมูลไบนารีของทรัพยากรภาพแทน

### **ดึงภาพ SVG**

สำหรับรูป SVG, [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) เปิดเผยอ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/). สิ่งนี้ทำให้คุณดึงข้อมูล SVG โดยตรงแทนการเรสเตอร์ไอจีแรก

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

การเก็บเนื้อหา SVG เป็น SVG คงรักษาเวกเตอร์ต้นฉบับภายในงานนำเสนอ การส่งออกเป็นเรสเซอร์เช่น PNG หรือ JPEG จะต้องแปลงเวกเตอร์เป็นพิกเซล การส่งออกสไลด์เป็น PDF หรือ SVG ก็เป็นการเรนเดอร์เช่นกัน ดังนั้นกราฟิกที่ส่งออกไม่ควรถือว่าเป็นสำเนาไบต์ต่อไบต์ของ SVG ที่ฝังไว้; ควรใช้ข้อมูล [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/) ที่ฝังเมื่อจำเป็นต้องใช้ทรัพยากรเวกเตอร์ดั้งเดิม

## **ครอบภาพ**

การครอบเปลี่ยนส่วนที่มองเห็นของภาพภายในกรอบ ค่า crop บน [IPictureFillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/) เป็นเปอร์เซ็นต์ของมิติภาพต้นฉบับ การครอบไม่ได้ลบพิกเซลที่ซ่อนอยู่จากภาพที่ฝัง; มันเพียงเปลี่ยนพื้นที่ที่มองเห็น

ตัวอย่างต่อไปนี้ค้นหากรอบรูปภาพอย่างปลอดภัยและใช้ค่า crop:

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

เนื่องจากข้อมูลภาพที่ซ่อนอยู่ยังคงอยู่, สามารถเปลี่ยนการครอบภายหลังโดยไม่สูญเสียพิกเซลเดิม หากขนาดไฟล์เป็นปัจจัยสำคัญมากกว่าการสามารถย้อนกลับ, สามารถลบพื้นที่ที่ครอบจริง ๆ ตามที่อธิบายในส่วนต่อไป

## **ลบข้อมูลภาพที่ถูกครอบ**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) จะลบข้อมูลภาพที่อยู่นอกสี่เหลี่ยมครอบปัจจุบันและคืนทรัพยากรภาพที่ได้ ผลลัพธ์นี้สามารถลดขนาดไฟล์ได้ แต่เป็นการเพิ่มประสิทธิภาพแบบทำลาย: หลังจากบันทึกงานนำเสนอแล้ว พิกเซลที่ถูกลบจะไม่มีให้ทำการยกเลิกครอบได้อีก

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

เมธอดนี้อาจเพิ่มทรัพยากรภาพใหม่ลงในงานนำเสนอ หากภาพต้นฉบับยังถูกใช้โดยกรอบรูปภาพอื่น, กรอบเหล่านั้นยังคงต้องการทรัพยากรเดิม ดังนั้นการลบพื้นที่ที่ครอบไม่ได้จะแน่นอนว่าจะลดจำนวนภาพทั้งหมด การครอบ WMF หรือ EMF ด้วยเมธอดนี้จะทำให้ผลลัพธ์ที่ครอบถูกเรสเตอร์เป็น PNG

## **บีบอัดภาพเรสเซอร์**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/compressimage/) ลดความละเอียดของภาพเรสเซอร์สัมพันธ์กับขนาดที่ภาพแสดง สามารถลบพื้นที่ที่ครอบในขั้นตอนเดียวได้ เมธอดจะคืนค่า `true` เมื่อภาพถูกปรับขนาดหรือครอบและ `false` เมื่อไม่มีการเปลี่ยนแปลงใด ๆ

ใช้ค่า [PicturesCompression](https://reference.aspose.com/slides/th/cpp/aspose.slides.export/picturescompression/) ที่กำหนดไว้ล่วงหน้าเมื่อความละเอียดเป้าหมายมาตรฐานเพียงพอ:

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

สามารถส่งค่า DPI เชิงบวกที่กำหนดเองแทนค่า enum เมื่อจำเป็นต้องมีเป้าหมายเฉพาะ

การบีบอัดมุ่งเน้นที่ภาพเรสเซอร์; เนื้อหา SVG และเมทาฟายล์จะไม่ถูกลดลงด้วยกระบวนการบีบอัดนี้ จำไว้ว่า ความละเอียดต่ำและการลบพื้นที่ที่ครอบไม่สามารถกู้คืนจากงานนำเสนอที่ถูกเพิ่มประสิทธิภาพได้ เลือกความละเอียดเป้าหมายตามขนาดที่ใหญ่ที่สุดที่ภาพจะถูกดูหรือส่งออกจริง ๆ แทนการใช้ DPI ต่ำสุดทั่วทั้งงานนำเสนอ

## **จัดการเอฟเฟกต์การแปลงรูปภาพ**

สำหรับเวิร์กโฟลว์ครบถ้วนที่ครอบคลุมการปรับความสว่าง, คอนทราสต์, การแปลงสี, เบลอ, เอฟเฟกต์อัลฟ่า, เชนที่จัดลำดับ, การตรวจสอบ, การลบ, และการตรวจสอบการย้อนกลับ, ดู [Image Transform Effects](/slides/th/cpp/image-transform-effects/)

## **ล็อกเรดิยายของกรอบรูปภาพ**

การตั้งค่า [IPictureFrameLock](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframelock/) ควบคุมการปิดการทำงานของการแก้ไขบางอย่างสำหรับกรอบรูปภาพ ตัวอย่างเช่น [aspect-ratio lock](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) จะคงอัตราส่วนของรูปร่างขณะปรับขนาด

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

การล็อกนี้ใช้กับรูปร่างกรอบรูปภาพ ไม่ได้บังคับให้ภาพต้นฉบับต้องรีแซมพลล์หรือเปลี่ยนอัตราส่วนถาวร

## **ปรับค่าการยืด StretchOffset**

เมื่อโหมดเติมรูปภาพเป็น stretch, ค่า stretch‑offset บน [IPictureFillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/) จะกำหนดสี่เหลี่ยมเติมสัมพันธ์กับกล่องขอบกรอบรูปภาพ เปอร์เซ็นต์บวกสร้างการเว้นจากขอบ, ส่วนเปอร์เซ็นต์ลบสร้างการขยายออก

นี่ต่างจากการครอบ ค่าครอบเลือกส่วนของภาพต้นฉบับที่มองเห็น; ส่วน stretch‑offset เปลี่ยนสี่เหลี่ยมที่ภาพเติมจะถูกยืดเข้าไป

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

ใช้ stretch‑offset สำหรับการวางตำแหน่งเติม ใช้คุณสมบัติเครอบเมื่อเป้าหมายคือการซ่อนขอบของภาพต้นฉบับ

## **การจัดเก็บ, ขนาดไฟล์, และข้อพิจารณาการส่งออก**

ข้อแลกเปลี่ยนหลักจัดการได้ง่ายขึ้นเมื่อการจัดเก็บภาพและการฟอร์แมตกรอบรูปภาพแยกกัน:

- **Embedded images** ทำให้งานนำเสนอเป็นอิสระและเป็นทางเลือกที่เชื่อถือได้ที่สุดสำหรับการแชร์และการแสดงผลฝั่งเซิร์ฟเวอร์, แต่ภาพเรสเซอร์ขนาดใหญ่จะเพิ่มขนาด PPTX และการใช้หน่วยความจำ
- **Linked images** สามารถทำให้แพ็กเกจมีขนาดเล็กลง, แต่การนำเสนอจะพึ่งพาไฟล์ภายนอกที่ต้องคงอยู่ที่พาธหรือที่ตั้งที่เก็บไว้
- **Cropping** เริ่มต้นเป็นแบบไม่ทำลาย; พิกเซลที่ซ่อนอยู่ยังคงฝังอยู่จนกว่าจะลบพื้นที่ที่ครอบอย่างชัดเจนหรือระหว่างการบีบอัด
- **Compression** สามารถลดขนาดไฟล์ได้อย่างมีนัยสำคัญสำหรับภาพเรสเซอร์ที่ใหญ่เกินไป, แต่จะสูญเสียความละเอียดต้นฉบับ ควรทำหลังจากทราบขนาดที่จะแสดงบนสไลด์แล้ว
- **SVG images** ควรคงเป็น SVG เมื่อการรักษาเวกเตอร์สำคัญ; ดึง SVG ที่ฝังโดยตรงเมื่อต้องการทรัพยากรเวกเตอร์เอง การส่งออกสไลด์เป็นเรสเซอร์จะเปลี่ยนสไลด์ที่เรนเดอร์เป็นพิกเซลเสมอ
- **Repeated images** ควรใช้ทรัพยากร [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) ที่มีอยู่แล้วเมื่อเป็นไปได้ แทนการโหลดไฟล์เดียวกันหลายครั้งเข้าสู่วเวิร์กโฟลว์งานนำเสนอ

สำหรับงานนำเสนอขนาดใหญ่, การเพิ่มประสิทธิภาพภาพมักจะได้ผลดีที่สุดเมื่อทำอย่างเลือกสรร: เก็บโลโก้และไดอะแกรมเป็นเนื้อหาเวกเตอร์, บีบอัดภาพถ่ายตามขนาดการแสดงจริง, ลบพิกเซลที่ครอบเฉพาะเมื่อไม่ต้องการแก้ไขต่อภายหลัง, และหลีกเลี่ยงลิงก์ภายนอกเว้นแต่การจัดการการพึ่งพาจะเป็นส่วนหนึ่งของการออกแบบการปรับใช้

## **คำถามที่พบบ่อย**

**ภาพกรอบรูปภาพและทรัพยากรภาพต่างกันอย่างไร?**

[IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) เป็นทรัพยากรภาพที่เชื่อมโยงกับงานนำเสนอ ส่วน [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) เป็นรูปร่างบนสไลด์ที่แสดงภาพและเก็บเรดิยายระดับกรอบและการจัดรูปแบบเช่น ขนาด, การหมุน, ค่า crop, เอฟเฟกต์, และการล็อก

**ควรฝังหรือเชื่อมโยงภาพ?**

ควรฝังภาพเมื่อจำเป็นต้องให้งานนำเสนอพกพา, เก็บถาวร, หรือแสดงผลโดยไม่ต้องพึ่งพาทรัพยากรภายนอก เชื่อมโยงภาพเฉพาะเมื่อตั้งใจให้ไฟล์ภาพอยู่นอก PPTX และสามารถรักษาตำแหน่งไฟล์ภายนอกได้อย่างเชื่อถือได้

**การครอบลดขนาดไฟล์ PPTX หรือไม่?**

ไม่โดยตรง การตั้งค่าครอบปกติจะซ่อนส่วนของภาพต้นฉบับแต่ยังคงเก็บพิกเซลไว้ ใช้ [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) หรือการบีบอัดภาพพร้อมการลบพื้นที่ที่ครอบเมื่อพิกเซลเหล่านั้นสามารถละทิ้งได้อย่างถาวร

**สามารถฟื้นฟูคุณภาพภาพหลังบีบอัดได้หรือไม่?**

ไม่ได้ การบีบอัดอาจลดความละเอียดเรสเซอร์ที่จัดเก็บและการลบพื้นที่ที่ครอบจะทำให้ข้อมูลภาพหายไป หากอาจต้องการการแก้ไขความละเอียดสูงในภายหลัง ควรเก็บภาพต้นฉบับนอกงานนำเสนอ

**ควรจัดการภาพ SVG อย่างไร?**

เก็บเนื้อหา SVG เป็น SVG เมื่อความเที่ยงตรงของเวกเตอร์สำคัญ สามารถดึง [ISvgImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/isvgimage/) ที่ฝังโดยตรง การเรนเดอร์สไลด์เป็นรูปแบบเรสเซอร์เช่น PNG หรือ JPEG จะทำให้เวกเตอร์แปลงเป็นพิกเซล

**จะหลีกเลี่ยงการ cast ที่ไม่ปลอดภัยเมื่ออ่านสไลด์ที่มีอยู่ได้อย่างไร?**

ตรวจสอบประเภทของรูปร่างก่อนใช้สมาชิกเฉพาะกรอบรูปภาพ ทดสอบรูปร่างด้วย [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) ก่อนทำการ cast runtime และเก็บผลลัพธ์ของ cast ไว้ในตัวแปรท้องถิ่นก่อนเข้าถึงสมาชิกที่เฉพาะเจาะจงของกรอบรูปภาพ