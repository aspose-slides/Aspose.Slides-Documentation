---
title: จัดการกรอบภาพในงานนำเสนอด้วย C++
linktitle: กรอบภาพ
type: docs
weight: 10
url: /th/cpp/picture-frame/
keywords:
- กรอบภาพ
- เพิ่มกรอบภาพ
- สร้างกรอบภาพ
- เพิ่มภาพ
- สร้างภาพ
- สกัดภาพ
- ภาพเรสเตอร์
- ภาพเวกเตอร์
- ครอบภาพ
- พื้นที่ที่ครอบไว้
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบภาพ
- คุณสมบัติของกรอบภาพ
- สเกลสัมพันธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนหน้าตา
- ความโปร่งใสของภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เพิ่มกรอบภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++ ปรับกระบวนการทำงานและยกระดับการออกแบบสไลด์"
---
## **บทนำ**

Picture frame คือรูปทรงที่บรรจุภาพ—คล้ายภาพที่อยู่ในกรอบ  

คุณสามารถเพิ่มภาพลงในสไลด์ผ่าน picture frame ได้ การทำเช่นนี้ทำให้คุณสามารถจัดรูปแบบภาพโดยจัดรูปแบบ picture frame

{{% alert  title="Tip" color="primary" %}} 

Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างงานนำเสนออย่างรวดเร็วจากรูปภาพ  

{{% /alert %}} 

## **Create a Picture Frame**

1. สร้างอินสแตนซ์ของ [Presentation class](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. ดึงอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_p_p_image) โดยเพิ่มรูปภาพเข้าไปใน [IImagescollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_image_collection) ที่เชื่อมโยงกับอ็อบเจ็กต์ presentation ซึ่งจะใช้สำหรับเติมรูปทรง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_frame) ตามความกว้างและความสูงของภาพโดยใช้เมธอด `AddPictureFrame` ของอ็อบเจ็กต์ shape ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่ม picture frame (ที่บรรจุภาพ) ลงในสไลด์  
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C++ นี้แสดงวิธีสร้าง picture frame:

```c++
// เส้นทางไปยังไดเร็กทอรีเอกสาร.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// โหลดการนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> slide = pres->get_Slide(0);

// โหลดภาพที่จะเพิ่มในคอลเลกชันภาพของการนำเสนอ
// รับภาพ
auto image = Images::FromFile(filePath);

// เพิ่มภาพลงในคอลเลกชันภาพของการนำเสนอ
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// เพิ่มกรอบภาพลงในสไลด์
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ตั้งค่าความกว้างและความสูงสเกลสัมพันธ์
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// ใส่การจัดรูปแบบบางอย่างให้กับ PictureFrame
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Picture frame ช่วยให้คุณสร้างสไลด์งานนำเสนอจากรูปภาพได้อย่างรวดเร็ว เมื่อผสาน picture frame กับตัวเลือกการบันทึกของ Aspose.Slides คุณสามารถจัดการการทำงานเข้า‑ออกเพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้ คุณอาจต้องการดูหน้าต่อไปนี้: แปลง [image to JPG](https://products.aspose.com/slides/th/cpp/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/cpp/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/cpp/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/cpp/conversion/svg-to-png/)  

{{% /alert %}}

## **Create a Picture Frame with Relative Scale**

โดยการปรับสเกลสัมพันธ์ของภาพ คุณสามารถสร้าง picture frame ที่ซับซ้อนได้มากขึ้น  

1. สร้างอินสแตนซ์ของ [Presentation class](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. ดึงอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มรูปภาพเข้าไปในคอลเลกชันรูปภาพของ presentation  
4. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_p_p_image) โดยเพิ่มรูปภาพเข้าไปใน [IImagescollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_image_collection) ที่เชื่อมโยงกับอ็อบเจ็กต์ presentation เพื่อใช้เติมรูปทรง  
5. ระบุความกว้างและความสูงสัมพันธ์ของภาพใน picture frame  
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C++ นี้แสดงวิธีสร้าง picture frame พร้อมสเกลสัมพันธ์:

```c++
// เส้นทางไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// โหลดการนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> slide = pres->get_Slide(0);

// โหลดภาพที่จะเพิ่มในคอลเลกชันภาพของการนำเสนอ
// รับภาพ
auto image = Images::FromFile(filePath);

// เพิ่มภาพลงในคอลเลกชันภาพของการนำเสนอ
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// เพิ่มกรอบภาพลงในสไลด์
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ตั้งค่าความกว้างและความสูงของสเกลสัมพันธ์
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Extract Raster Images from Picture Frames**

คุณสามารถสกัดภาพเรสเตอร์จากอ็อบเจ็กต์ [PictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_frame) และบันทึกเป็น PNG, JPG หรือรูปแบบอื่น ๆ ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดภาพจากไฟล์ “sample.pptx” และบันทึกเป็น PNG  

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **Extract SVG Images from Picture Frames**

เมื่อ presentation มีกราฟิก SVG อยู่ในรูปทรง [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) Aspose.Slides for C++ จะอนุญาตให้คุณดึงภาพเวคเตอร์ต้นฉบับที่คงความถูกต้องเต็มรูปแบบโดยการวนผ่านคอลเลกชันรูปทรงของสไลด์ เพื่อตรวจสอบแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) ว่า [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) มีเนื้อหา SVG หรือไม่ แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม  

โค้ดต่อไปนี้แสดงวิธีสกัดภาพ SVG จาก picture frame:

```cpp
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

## **Get Transparency of an Image**

Aspose.Slides ให้คุณดึงค่าความโปร่งใสที่ใช้กับภาพ โค้ด C++ นี้เป็นตัวอย่าง:

```c++
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

{{% alert color="primary" %}} 
เอฟเฟกต์ทั้งหมดที่ใช้กับภาพสามารถพบได้ใน [Aspose::Slides::Effects](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/)  
{{% /alert %}}

## **Get Brightness and Contrast of an Image**

Aspose.Slides ให้คุณดึงค่าแสงสว่างและคอนทราสต์ที่ใช้กับภาพ อินเทอร์เฟซ [ILuminance](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/iluminance/) แสดงเอฟเฟกต์การแปลงภาพนี้  

โค้ด C++ นี้แสดงวิธีดึงการตั้งค่าแสงสว่างและคอนทราสต์จาก picture frame:

```c++
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

## **Picture Frame Formatting**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลากหลายที่สามารถนำไปใช้กับ picture frame ได้ โดยใช้ตัวเลือกเหล่านี้คุณสามารถปรับ picture frame ให้ตรงกับความต้องการเฉพาะได้  

1. สร้างอินสแตนซ์ของ [Presentation class](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. ดึงอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_p_p_image) โดยเพิ่มรูปภาพเข้าไปใน [IImagescollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_image_collection) ที่เชื่อมโยงกับอ็อบเจ็กต์ presentation เพื่อใช้เติมรูปทรง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง `PictureFrame` ตามความกว้างและความสูงของภาพโดยใช้เมธอด [AddPictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) ของอ็อบเจ็กต์ [IShapes](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_shape_collection) ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่ม picture frame (ที่บรรจุภาพ) ลงในสไลด์  
7. ตั้งค่าสีเส้นของ picture frame  
8. ตั้งค่าความกว้างของเส้น picture frame  
9. หมุน picture frame โดยใส่ค่าบวกหรือค่าลบ  
   * ค่าบวกหมุนภาพตามเข็มนาฬิกา  
   * ค่าเป็นลบหมุนภาพทวนเข็มนาฬิกา  
10. เพิ่ม picture frame (ที่บรรจุภาพ) ลงในสไลด์อีกครั้ง  
11. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C++ นี้แสดงกระบวนการจัดรูปแบบ picture frame:

```c++
// เส้นทางไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// โหลดการนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// โหลดภาพที่จะเพิ่มในคอลเลกชันภาพของการนำเสนอ
// รับภาพ
auto image = Images::FromFile(filePath);

// เพิ่มภาพลงในคอลเลกชันภาพของการนำเสนอ
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// เพิ่มกรอบภาพลงในสไลด์
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ตั้งค่าความกว้างและความสูงของสเกลสัมพันธ์
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//บันทึกไฟล์ PPTX ลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}

Aspose เพิ่งพัฒนา [free Collage Maker](https://products.aspose.app/slides/th/collage) หากคุณต้องการรวมรูปภาพ JPG/JPEG หรือ PNG, หรือสร้างกริดจากรูปภาพ สามารถใช้บริการนี้ได้  

{{% /alert %}}

## **Add an Image as a Link**

เพื่อหลีกเลี่ยงขนาดงานนำเสนอที่ใหญ่เกินไป คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์โดยตรงลงในงานนำเสนอ โค้ด C++ นี้แสดงวิธีเพิ่มภาพและวิดีโอลงใน placeholder:

```cpp
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

## **Crop Images**

โค้ด C++ นี้แสดงวิธีครอบภาพที่มีอยู่บนสไลด์:

```CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// สร้างอ็อบเจ็กต์ภาพใหม่
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// เพิ่ม PictureFrame ลงในสไลด์
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// ครอบภาพ (ค่าร้อยละ)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// บันทึกผลลัพธ์
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Delete Cropped Areas of a Picture**

หากต้องการลบพื้นที่ที่ครอบไว้ของภาพที่อยู่ในกรอบ สามารถใช้เมธอด [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) เมธอดนี้จะคืนภาพที่ถูกครอบหรือภาพต้นฉบับหากไม่จำเป็นต้องครอบ  

โค้ด C++ นี้แสดงการทำงาน:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// ดึง PictureFrame จากสไลด์แรก
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// ลบพื้นที่ที่ครอบของภาพใน PictureFrame และคืนค่าภาพที่ถูกครอบ
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// บันทึกผลลัพธ์
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

เมธอด [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) จะเพิ่มภาพที่ถูกครอบลงในคอลเลกชันรูปภาพของ presentation หากภาพถูกใช้เพียงใน [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) เท่านั้น การตั้งค่านี้สามารถลดขนาดไฟล์ได้ มิฉะนั้นจำนวนภาพในงานนำเสนอที่ได้จะเพิ่มขึ้น  

เมธอดนี้จะแปลงไฟล์เมตาโฟร์ม WMF/EMF ไปเป็นภาพ PNG แบบเรสเตอร์ในขั้นตอนการครอบ  

{{% /alert %}}

## **Compress Images**

คุณสามารถบีบอัดรูปภาพในงานนำเสนอโดยใช้เมธอด [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/compressimage/)  
เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดของรูปทรงและความละเอียดที่กำหนด พร้อมตัวเลือกให้ลบพื้นที่ที่ครอบไว้  

มันปรับขนาดและความละเอียดของรูปภาพในลักษณะเดียวกับฟีเจอร์ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint  

ตัวอย่าง C++ ต่อไปนี้สาธิตการบีบอัดภาพในงานนำเสนอโดยระบุความละเอียดเป้าหมายและเลือกลบพื้นที่ที่ครอบไว้:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอบไว้
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
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) โดยลบพื้นที่ที่ถูกครอบไว้.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

เมธอดจะลดความละเอียดของภาพตามขนาดของรูปทรงและ DPI ที่ระบุ พื้นที่ที่ครอบไว้ก็สามารถลบได้เพื่อเพิ่มประสิทธิภาพขนาดไฟล์  
หากภาพเป็นเมตาไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ นอกจากนี้คุณภาพ JPEG จะถูกเก็บไว้หรือถูกลดลงเล็กน้อยตามความละเอียด เช่นเดียวกับที่ PowerPoint จัดการ JPEG ความละเอียดสูง  

{{% /alert %}}

## **Lock Aspect Ratio**

หากต้องการให้รูปทรงที่บรรจุภาพรักษาอัตราส่วนหน้าตาสมกับการเปลี่ยนแปลงขนาดของภาพ คุณสามารถใช้เมธอด [set_AspectRatioLocked()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) เพื่อกำหนดค่าการล็อกอัตราส่วน  

โค้ด C++ นี้แสดงวิธีล็อกอัตราส่วนของรูปทรง:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

การตั้งค่า *Lock Aspect Ratio* นี้จะรักษาอัตราส่วนของรูปทรงเท่านั้น ไม่ได้รักษาอัตราส่วนของภาพที่อยู่ภายใน  

{{% /alert %}}

## **Use the StretchOff Property**

โดยใช้คุณสมบัติ [StretchOffsetLeft](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) และ [StretchOffsetBottom](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) จากอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_picture_fill_format) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format) คุณสามารถกำหนดสี่เหลี่ยมเติม  

เมื่อกำหนดการยืดของภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่ระบุ แต่ละขอบของสี่เหลี่ยมเติมจะกำหนดโดยออฟเซ็ตเปอร์เซ็นต์จากขอบของกล่องล้อมของรูปทรง ค่าเปอร์เซ็นต์บวกหมายถึงการเว้นระยะภายใน ค่าเปอร์เซ็นต์ลบหมายถึงการขยายออก  

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. ดึงอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มสี่เหลี่ยม `AutoShape`  
4. สร้างภาพ  
5. ตั้งค่าประเภทการเติมของรูปทรง  
6. ตั้งค่าโหมดการเติมภาพของรูปทรง  
7. เพิ่มรูปภาพเพื่อเติมรูปทรง  
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องล้อมของรูปทรง  
9. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C++ นี้แสดงกระบวนการใช้คุณสมบัติ StretchOff:

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// ตั้งค่าการยืดภาพจากแต่ละด้านในเนื้อหาของรูปทรง
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**ฉันจะค้นหารูปแบบภาพที่รองรับสำหรับ PictureFrame ได้อย่างไร?**

Aspose.Slides รองรับทั้งภาพเรสเตอร์ (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวคเตอร์ (เช่น SVG) ผ่านอ็อบเจ็กต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) รายชื่อรูปแบบที่รองรับมักจะสอดคล้องกับความสามารถของเอนจินการแปลงสไลด์และภาพ

**การเพิ่มรูปภาพขนาดใหญ่หลายสิบรูปจะส่งผลต่อขนาดและประสิทธิภาพของไฟล์ PPTX อย่างไร?**

การฝังรูปภาพขนาดใหญ่จะเพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การลิงก์รูปภาพช่วยลดขนาดไฟล์งานนำเสนอ แต่ไฟล์ภายนอกต้องสามารถเข้าถึงได้เสมอ Aspose.Slides มีความสามารถในการเพิ่มรูปภาพผ่านลิงก์เพื่อช่วยลดขนาดไฟล์

**ฉันจะล็อกอ็อบเจ็กต์ภาพไม่ให้เคลื่อนย้ายหรือเปลี่ยนขนาดโดยบังเอิญได้อย่างไร?**

ใช้ [shape locks](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/get_pictureframelock/) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) (เช่น ปิดการเคลื่อนย้ายหรือการปรับขนาด) กลไกการล็อกอธิบายไว้สำหรับรูปทรงในบทความการปกป้องแยกต่างหาก [/slides/th/cpp/applying-protection-to-presentation/] และรองรับหลายประเภทของรูปทรงรวมถึง [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/)

**ความแม่นยำของเวคเตอร์ SVG จะรักษาไว้เมื่อนำงานนำเสนอส่งออกเป็น PDF หรือภาพหรือไม่?**

Aspose.Slides อนุญาตให้สกัด SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) เป็นเวคเตอร์ต้นฉบับ เมื่อ [export to PDF](/slides/th/cpp/convert-powerpoint-to-pdf/) หรือ [export to raster formats](/slides/th/cpp/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกแปลงเป็นเรสเตอร์ขึ้นอยู่กับการตั้งค่าการส่งออก; การสกัดยืนยันว่า SVG ดั้งเดิมยังคงอยู่เป็นเวคเตอร์.