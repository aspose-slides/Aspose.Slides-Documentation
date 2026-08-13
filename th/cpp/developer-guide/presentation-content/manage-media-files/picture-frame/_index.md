---
title: จัดการกรอบรูปในงานนำเสนอด้วย C++
linktitle: กรอบรูป
type: docs
weight: 10
url: /th/cpp/picture-frame/
keywords:
- กรอบรูป
- เพิ่มกรอบรูป
- สร้างกรอบรูป
- เพิ่มรูปภาพ
- สร้างรูปภาพ
- แยกรูปภาพ
- รูปภาพแบบแรสเตอร์
- รูปภาพแบบเวกเตอร์
- ตัดรูปภาพ
- พื้นที่ที่ถูกตัด
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบรูป
- คุณสมบัติกรอบรูป
- สเกลสัมพัทธ์
- เอฟเฟ็กต์ภาพ
- อัตราส่วนภาพ
- ความโปร่งใสของภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "เพิ่มกรอบรูปในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++. ทำงานของคุณให้คล่องตัวและปรับปรุงการออกแบบสไลด์"
---
## **บทนำ**

กรอบรูปคือรูปทรงที่บรรจุภาพ—คล้ายกับรูปในกรอบ  

คุณสามารถเพิ่มภาพลงในสไลด์ผ่านกรอบรูปได้ วิธีนี้ทำให้คุณจัดรูปภาพได้โดยการจัดรูปกรอบรูป  

{{% alert title="เคล็ดลับ" color="info" %}}  
Aspose ให้บริการแปลงฟรี—[JPEG เป็น PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG เป็น PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างงานนำเสนออย่างรวดเร็วจากภาพ  
{{% /alert %}}  

## **สร้างกรอบรูป**

1. สร้างอินสแตนซ์ของ [คลาส Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_p_p_image) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_image_collection) ที่เกี่ยวข้องกับอ็อบเจกต์ Presentation เพื่อใช้เป็นการเติมรูปทรง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_frame) ตามความกว้างและความสูงของภาพโดยใช้เมธอด `AddPictureFrame` ที่เปิดให้ใช้งานจากอ็อบเจกต์ shape ที่เกี่ยวข้องกับสไลด์ที่อ้างอิงไว้  
6. เพิ่มกรอบรูป (ที่บรรจุรูปภาพ) ลงในสไลด์  
7. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด C++ นี้แสดงวิธีสร้างกรอบรูป:  

```c++
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
#include <Util/Images.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// เส้นทางไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// โหลดการนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> slide = pres->get_Slide(0);

// โหลดภาพที่จะเพิ่มในคอลเลกชันภาพของงานนำเสนอ
// รับภาพ
auto image = Images::FromFile(filePath);

// เพิ่มภาพไปยังคอลเลกชันภาพของงานนำเสนอ
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// เพิ่มกรอบรูปไปยังสไลด์
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ตั้งค่าความกว้างและความสูงของสเกลสัมพัทธ์
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// ใช้การจัดรูปแบบบางอย่างกับกรอบรูป
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//เขียนไฟล์ PPTX ลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```  

{{% alert color="warning" %}}  
กรอบรูปช่วยให้คุณสร้างสไลด์งานนำเสนอจากภาพได้อย่างรวดเร็ว เมื่อคุณรวมกรอบรูปกับตัวเลือกการบันทึก Aspose.Slides คุณสามารถจัดการการทำงานเข้า/ออกเพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง คุณอาจต้องการดูหน้านี้: แปลง [ภาพเป็น JPG](https://products.aspose.com/slides/th/cpp/conversion/image-to-jpg/) ; แปลง [JPG เป็นภาพ](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-image/) ; แปลง [JPG เป็น PNG](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-png/) , แปลง [PNG เป็น JPG](https://products.aspose.com/slides/th/cpp/conversion/png-to-jpg/) ; แปลง [PNG เป็น SVG](https://products.aspose.com/slides/th/cpp/conversion/png-to-svg/) , แปลง [SVG เป็น PNG](https://products.aspose.com/slides/th/cpp/conversion/svg-to-png/)  
{{% /alert %}}  

## **สร้างกรอบรูปด้วยสเกลสัมพัทธ์**

โดยการปรับสเกลสัมพัทธ์ของภาพ คุณสามารถสร้างกรอบรูปที่ซับซ้อนได้มากขึ้น  

1. สร้างอินสแตนซ์ของ [คลาส Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มภาพลงในคอลเลกชันภาพของ Presentation  
4. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_p_p_image) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_image_collection) ที่เชื่อมกับอ็อบเจกต์ Presentation เพื่อใช้เป็นการเติมรูปทรง  
5. ระบุความกว้างและความสูงสัมพัทธ์ของภาพในกรอบรูป  
6. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด C++ นี้แสดงวิธีสร้างกรอบรูปด้วยสเกลสัมพัทธ์:  

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// เส้นทางไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// โหลดการนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> slide = pres->get_Slide(0);

// โหลดภาพที่จะเพิ่มในคอลเลกชันภาพของงานนำเสนอ
// รับภาพ
auto image = Images::FromFile(filePath);

// เพิ่มภาพไปยังคอลเลกชันภาพของงานนำเสนอ
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// เพิ่มกรอบรูปไปยังสไลด์
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ตั้งค่าความกว้างและความสูงของสเกลสัมพัทธ์
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//เขียนไฟล์ PPTX ลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```  

## **แยกรูปภาพ Raster จากกรอบรูป**

คุณสามารถแยกรูปภาพ Raster จากอ็อบเจกต์ [PictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_frame) และบันทึกเป็น PNG, JPG หรือรูปแบบอื่น ๆ ตัวอย่างโค้ดด้านล่างจะแสดงวิธีแยกรูปจากไฟล์ “sample.pptx” และบันทึกเป็น PNG  

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_Image();

    image->Save(u"slide_1_shape_1.png", ImageFormat::Png);
}

presentation->Dispose();
```  

## **แยกรูป SVG จากกรอบรูป**

เมื่อการนำเสนอมีกราฟิก SVG ที่วางไว้ภายในรูปทรง [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) Aspose.Slides สำหรับ C++ จะให้คุณดึงรูปเวกเตอร์ต้นฉบับที่มีความเที่ยงตรงเต็มที่ โดยการวนผ่านคอลเลกชันรูปทรงของสไลด์ คุณสามารถระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) ตรวจสอบว่า [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) ที่อยู่เบื้องหลังมีเนื้อหา SVG หรือไม่ แล้วบันทึกรูปนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีแยกรูป SVG จากกรอบรูป:  

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
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
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```  

## **รับค่าความโปร่งใสของภาพ**

Aspose.Slides ให้คุณรับค่าผลกระทบความโปร่งใสที่ใช้กับภาพ โค้ด C++ นี้แสดงการทำงาน:  

```c++
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```  

{{% alert color="info" %}}  
เอฟเฟกต์ทั้งหมดที่ใช้กับภาพสามารถพบได้ใน [Aspose::Slides::Effects](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/)  
{{% /alert %}}  

## **รับค่าความสว่างและคอนทราสต์ของภาพ**

Aspose.Slides ให้คุณรับค่าความสว่างและคอนทราสต์ที่ใช้กับภาพ อินเทอร์เฟซ [ILuminance](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iluminance/) แสดงผลการแปลงภาพนี้  

โค้ด C++ นี้แสดงวิธีรับค่า brightness และ contrast จากกรอบรูป:  

```c++
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```  

## **การจัดรูปแบบกรอบรูป**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายอย่างที่สามารถใช้กับกรอบรูปได้ ใช้ตัวเลือกเหล่านี้คุณสามารถปรับกรอบรูปให้ตรงกับความต้องการเฉพาะได้  

1. สร้างอินสแตนซ์ของ [คลาส Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_p_p_image) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_image_collection) ที่เชื่อมกับอ็อบเจกต์ Presentation เพื่อใช้เป็นการเติมรูปทรง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง `PictureFrame` ตามความกว้างและความสูงของภาพโดยใช้เมธอด [AddPictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) ที่เปิดให้ใช้งานจากอ็อบเจกต์ [IShapes](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_shape_collection) ที่เชื่อมกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูป (ที่บรรจุรูปภาพ) ลงในสไลด์  
7. ตั้งค่าสีเส้นของกรอบรูป  
8. ตั้งค่าความกว้างของเส้นกรอบรูป  
9. หมุนกรอบรูปโดยให้ค่าบวกหรือค่าลบ  
   * ค่าบวกจะหมุนภาพตามเข็มนาฬิกา  
   * ค่าลบจะหมุนภาพทวนเข็มนาฏิกา  
10. เพิ่มกรอบรูป (ที่บรรจุรูปภาพ) ลงในสไลด์อีกครั้ง  
11. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด C++ นี้แสดงกระบวนการจัดรูปแบบกรอบรูป:  

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// เส้นทางไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// โหลดการนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// โหลดภาพที่จะเพิ่มในคอลเลกชันภาพของงานนำเสนอ
// รับภาพ
auto image = Images::FromFile(filePath);

// เพิ่มภาพไปยังคอลเลกชันภาพของงานนำเสนอ
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// เพิ่มกรอบรูปไปยังสไลด์
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ตั้งค่าความกว้างและความสูงของสเกลสัมพัทธ์
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//เขียนไฟล์ PPTX ลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```  

{{% alert title="เคล็ดลับ" color="info" %}}  
Aspose เพิ่งพัฒนาบริการ [Collage Maker ฟรี](https://products.aspose.app/slides/th/collage) หากคุณต้องการรวมภาพ JPG/JPEG หรือ PNG, หรือสร้างกริดจากรูปถ่าย คุณสามารถใช้บริการนี้ได้  
{{% /alert %}}  

## **เพิ่มภาพเป็นลิงก์**

เพื่อลดขนาดงานนำเสนอใหญ่ คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์โดยตรงในงานนำเสนอ โค้ด C++ นี้แสดงวิธีเพิ่มภาพและวิดีโอลงใน placeholder:  

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IVideoFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/collections/list.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```  

## **ตัดภาพ**

โค้ด C++ นี้แสดงวิธีตัดภาพที่มีอยู่บนสไลด์:  

``` CPP
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// สร้างอ็อบเจกต์ภาพใหม่
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(u"image.png"));

// เพิ่ม PictureFrame ไปยังสไลด์
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// ทำการตัดภาพ (ค่าร้อยละ)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// บันทึกผลลัพธ์
presentation->Save(u"cropped.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```  

## **ลบพื้นที่ที่ถูกตัดของกรอบรูป**

หากต้องการลบพื้นที่ที่ถูกตัดของภาพที่อยู่ในกรอบรูป คุณสามารถใช้เมธอด [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) เมธอดนี้จะคืนภาพที่ถูกตัดหรือภาพต้นฉบับหากไม่ต้องการตัด  

โค้ด C++ นี้แสดงการทำงาน:  

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// รับ PictureFrame จากสไลด์แรก
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// ลบพื้นที่ที่ถูกตัดของภาพ PictureFrame และคืนภาพที่ถูกตัด
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// บันทึกผลลัพธ์
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```  

{{% alert title="หมายเหตุ" color="warning" %}}  
เมธอด [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) จะเพิ่มภาพที่ถูกตัดลงในคอลเลกชันภาพของ Presentation หากภาพนั้นใช้เพียงใน [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) ที่ประมวลผล การตั้งค่านี้สามารถลดขนาดงานนำเสนอได้ มิฉะนั้นจำนวนภาพในงานนำเสนอที่ได้จะเพิ่มขึ้น  

เมธอดนี้แปลงไฟล์เมตาฟไฟล์ WMF/EMF เป็นภาพ PNG raster ในกระบวนการตัดภาพ  
{{% /alert %}}  

## **บีบอัดภาพ**

คุณสามารถบีบอัดภาพในงานนำเสนอโดยใช้เมธอด [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/compressimage/) เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดของรูปทรงและความละเอียดที่ระบุ พร้อมตัวเลือกให้ลบพื้นที่ที่ถูกตัด  

มันปรับขนาดและความละเอียดของภาพคล้ายกับฟีเจอร์ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint  

ตัวอย่าง C++ ด้านล่างแสดงวิธีบีบอัดภาพในงานนำเสนอโดยระบุความละเอียดเป้าหมายและอาจลบพื้นที่ที่ถูกตัด:  

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกตัดออก
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// ตรวจสอบผลลัพธ์ของการบีบอัด
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```  

หรือใช้ค่า DPI ที่กำหนดเองโดยตรง:  

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) โดยลบพื้นที่ที่ถูกตัดออก.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```  

{{% alert title="หมายเหตุ" color="warning" %}}  
เมธอดนี้จะแปลงภาพเป็นความละเอียดต่ำกว่าโดยอิงจากขนาดของรูปทรงและ DPI ที่กำหนด พื้นที่ที่ถูกตัดก็สามารถลบได้เพื่อเพิ่มประสิทธิภาพขนาดไฟล์  
หากภาพเป็นเมตาฟไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ นอกจากนี้คุณภาพของ JPEG จะคงไว้หรือถูกลดลงเล็กน้อยตามความละเอียด เหมือนกับที่ PowerPoint จัดการกับ JPEG ความละเอียดสูง  
{{% /alert %}}  

## **ล็อคอัตราส่วนภาพ**

หากต้องการให้รูปทรงที่บรรจุภาพรักษาอัตราส่วนภาพแม้เปลี่ยนขนาดภาพ คุณสามารถใช้เมธอด [set_AspectRatioLocked()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) เพื่อตั้งค่าการ *Lock Aspect Ratio*  

โค้ด C++ นี้แสดงวิธีล็อคอัตราส่วนของรูปทรง:  

```c++
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```  

{{% alert title="หมายเหตุ" color="warning" %}}  
การตั้งค่า *Lock Aspect Ratio* นี้จะรักษาอัตราส่วนของรูปทรงเท่านั้น ไม่ได้รักษาอัตราส่วนของภาพที่บรรจุอยู่  
{{% /alert %}}  

## **ใช้คุณสมบัติ StretchOff**

โดยใช้คุณสมบัติ [StretchOffsetLeft](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) และ [StretchOffsetBottom](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) จากอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_picture_fill_format) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format) คุณสามารถระบุสี่เหลี่ยมเติมได้  

เมื่อระบุการยืดของภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่กำหนด แต่ละขอบของสี่เหลี่ยมเติมจะกำหนดโดยเปอร์เซ็นต์ออฟเซ็ตจากขอบที่สอดคล้องกับกล่องขอบเขตของรูปทรง ค่าเปอร์เซ็นต์บวกหมายถึงการทำให้เข้าไปในรูปร่าง ค่าเปอร์เซ็นต์ลบหมายถึงการยืดออก  

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสี่เหลี่ยม `AutoShape`  
4. สร้างภาพ  
5. ตั้งค่าประเภทการเติมของรูปทรง  
6. ตั้งค่าโหมดการเติมภาพของรูปทรง  
7. เพิ่มภาพที่ตั้งค่าให้เติมรูปทรง  
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องกับกล่องขอบเขตของรูปทรง  
9. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด C++ นี้แสดงกระบวนการที่ใช้คุณสมบัติ StretchOff:  

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Sets the image stretched from each side in the shape body
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```  

## **คำถามที่พบบ่อย**

### ฉันจะตรวจสอบรูปแบบภาพที่รองรับสำหรับ PictureFrame ได้อย่างไร?

Aspose.Slides รองรับทั้งภาพ raster (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจกต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) รายการรูปแบบที่รองรับมักจะสอดคล้องกับความสามารถของเอนจินการแปลงสไลด์และภาพ  

### การเพิ่มรูปภาพขนาดใหญ่หลายสิบรูปจะส่งผลต่อขนาดและประสิทธิภาพของ PPTX อย่างไร?

การฝังภาพขนาดใหญ่จะเพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การลิงก์ภาพช่วยลดขนาดงานนำเสนอแต่ต้องให้ไฟล์ภายนอกเข้าถึงได้ Aspose.Slides มีความสามารถเพิ่มภาพแบบลิงก์เพื่อช่วยลดขนาดไฟล์  

### ฉันจะล็อคอ็อบเจกต์ภาพจากการย้าย/ปรับขนาดโดยไม่ตั้งใจได้อย่างไร?

ใช้ [shape locks](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/get_pictureframelock/) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือการปรับขนาด) กลไกการล็อคอธิบายไว้สำหรับรูปทรงในบทความ [การป้องกัน](/slides/th/cpp/applying-protection-to-presentation/) และรองรับหลายประเภทรูปทรง รวมถึง [PictureFrame]  

### ความถูกต้องของเวกเตอร์ SVG จะถูกเก็บไว้เมื่อนำเสนออกเป็น PDF/ภาพหรือไม่?

Aspose.Slides ให้คุณดึง SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) เป็นเวกเตอร์ดั้งเดิม เมื่อ [ส่งออกเป็น PDF](/slides/th/cpp/convert-powerpoint-to-pdf/) หรือ [รูปแบบ raster](/slides/th/cpp/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกแปลงเป็น raster ขึ้นอยู่กับการตั้งค่าการส่งออก; การที่ SVG ดั้งเดิมถูกเก็บเป็นเวกเตอร์ยืนยันโดยพฤติกรรมการดึงออกได้.