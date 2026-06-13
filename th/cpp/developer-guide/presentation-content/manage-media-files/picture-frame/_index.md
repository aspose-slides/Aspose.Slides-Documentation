---
title: จัดการ Picture Frames ในงานนำเสนอด้วย C++
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
- ภาพ raster
- ภาพ vector
- ครอบภาพ
- พื้นที่ที่ครอบ
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบภาพ
- คุณสมบัติกรอบภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วน
- ความโปร่งแสงของภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เพิ่มกรอบภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++. ทำให้ขั้นตอนการทำงานของคุณเป็นระเบียบและยกระดับการออกแบบสไลด์"
---
## **บทนำ**

Picture frame คือรูปร่างที่บรรจุภาพ—มันเหมือนภาพที่อยู่ในกรอบ

คุณสามารถเพิ่มภาพลงในสไลด์ผ่าน picture frame วิธีนี้คุณจะได้จัดรูปแบบภาพโดยจัดรูปแบบ picture frame

{{% alert  title="Tip" color="primary" %}} 

Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างงานนำเสนออย่างรวดเร็วจากภาพ

{{% /alert %}} 

## **สร้าง Picture Frame**

1. สร้างอินสแตนซ์ของ [Presentation class](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_p_p_image) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_image_collection) ที่เชื่อมกับอ็อบเจกต์ presentation ซึ่งจะใช้เพื่อเติมรูปร่าง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_frame) ตามความกว้างและความสูงของภาพผ่านเมธอด `AddPictureFrame` ที่เปิดให้ใช้งานโดยอ็อบเจกต์ shape ที่เชื่อมกับสไลด์ที่อ้างอิง  
6. เพิ่ม picture frame (ที่บรรจุภาพ) ลงในสไลด์  
7. เขียน presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด C++ นี้แสดงวิธีสร้าง picture frame:

```c++
// พาธไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// โหลดงานนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> slide = pres->get_Slide(0);

// โหลดภาพที่จะเพิ่มในคอลเลกชันรูปภาพของงานนำเสนอ
// ดึงรูปภาพ
auto image = Images::FromFile(filePath);

// เพิ่มภาพเข้าไปในคอลเลกชันรูปภาพของงานนำเสนอ
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// เพิ่ม picture frame ลงในสไลด์
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ตั้งค่าสเกลสัมพัทธ์ของความกว้างและความสูง
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// ใช้การจัดรูปแบบบางส่วนกับ PictureFrame
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// เขียนไฟล์ PPTX ไปยังดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Picture frame ช่วยให้คุณสร้างสไลด์งานนำเสนอจากภาพได้อย่างรวดเร็ว เมื่อผสาน picture frame กับตัวเลือกการบันทึก Aspose.Slides คุณสามารถจัดการการทำงานเข้า/ออกเพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง คุณอาจต้องการดูหน้านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/cpp/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/cpp/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/cpp/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/cpp/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/cpp/conversion/svg-to-png/)

{{% /alert %}}

## **สร้าง Picture Frame ด้วย Relative Scale**

โดยการปรับสเกลสัมพัทธ์ของภาพ คุณสามารถสร้าง picture frame ที่ซับซ้อนยิ่งขึ้น

1. สร้างอินสแตนซ์ของ [Presentation class](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มภาพลงในคอลเลกชันภาพของ presentation  
4. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_p_p_image) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_image_collection) ที่เชื่อมกับอ็อบเจกต์ presentation จะใช้เพื่อเติมรูปร่าง  
5. ระบุความกว้างและความสูงสัมพัทธ์ของภาพใน picture frame  
6. เขียน presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด C++ นี้แสดงวิธีสร้าง picture frame ด้วย Relative Scale:

```c++
// พาธไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// โหลดงานนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> slide = pres->get_Slide(0);

// โหลดภาพที่จะเพิ่มในคอลเลกชันรูปภาพของงานนำเสนอ
// ดึงรูปภาพ
auto image = Images::FromFile(filePath);

// เพิ่มภาพเข้าไปในคอลเลกชันรูปภาพของงานนำเสนอ
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// เพิ่ม picture frame ลงในสไลด์
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ตั้งค่าสเกลสัมพัทธ์ของความกว้างและความสูง
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// เขียนไฟล์ PPTX ไปยังดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **สกัด Raster Images จาก Picture Frames**

คุณสามารถสกัด raster images ออกจากอ็อบเจกต์ [PictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_frame) และบันทึกเป็น PNG, JPG และรูปแบบอื่นๆ ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดภาพจากเอกสาร “sample.pptx” และบันทึกเป็นรูปแบบ PNG

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

## **สกัด SVG Images จาก Picture Frames**

เมื่อการนำเสนอมีกราฟิก SVG ที่วางไว้ภายในรูปร่าง [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) Aspose.Slides สำหรับ C++ จะช่วยให้คุณดึงภาพเวกเตอร์ต้นฉบับออกมาโดยคงความละเอียดเต็มรูปแบบ โดยการวนผ่านคอลเลกชันรูปร่างของสไลด์ คุณสามารถระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/), ตรวจสอบว่า [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) ที่อยู่ภายในมีเนื้อหา SVG หรือไม่ แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีสกัด SVG image จาก picture frame:

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

## **รับ Transparency ของภาพ**

Aspose.Slides อนุญาตให้คุณรับค่า Transparency ที่ถูกนำไปใช้กับภาพ โค้ด C++ นี้แสดงการทำงานดังกล่าว:

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
เอฟเฟกต์ทั้งหมดที่นำไปใช้กับภาพสามารถพบได้ใน [Aspose::Slides::Effects](https://reference.aspose.com/slides/th/cpp/aspose.slides.effects/)
{{% /alert %}}

## **การจัดรูปแบบ Picture Frame**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายอย่างที่สามารถใช้กับ picture frame ได้ โดยใช้ตัวเลือกเหล่านั้น คุณสามารถปรับเปลี่ยน picture frame ให้ตรงตามข้อกำหนดเฉพาะ

1. สร้างอินสแตนซ์ของ [Presentation class](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_p_p_image) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_image_collection) ที่เชื่อมกับอ็อบเจกต์ presentation จะใช้เพื่อเติมรูปร่าง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง `PictureFrame` ตามความกว้างและความสูงของภาพผ่านเมธอด [AddPictureFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) ที่เปิดให้ใช้งานโดยอ็อบเจกต์ [IShapes](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_shape_collection) ที่เชื่อมกับสไลด์ที่อ้างอิง  
6. เพิ่ม picture frame (ที่บรรจุภาพ) ลงในสไลด์  
7. ตั้งค่าสีเส้นของ picture frame  
8. ตั้งค่าความกว้างของเส้น picture frame  
9. หมุน picture frame โดยกำหนดค่าบวกหรือค่าลบ  
   * ค่าบวกจะหมุนภาพตามเข็มนาฬิกา  
   * ค่าลบจะหมุนภาพทวนเข็มนาฬิกา  
10. เพิ่ม picture frame (ที่บรรจุภาพ) ลงในสไลด์ (ซ้ำตามขั้นตอนที่ 6)  
11. เขียน presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด C++ นี้แสดงกระบวนการจัดรูปแบบ picture frame:

```c++
// พาธไปยังไดเรกทอรีเอกสาร.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// โหลดงานนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// โหลดภาพที่จะเพิ่มในคอลเลกชันรูปภาพของงานนำเสนอ
// ดึงรูปภาพ
auto image = Images::FromFile(filePath);

// เพิ่มภาพเข้าไปในคอลเลกชันรูปภาพของงานนำเสนอ
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// เพิ่ม picture frame ลงในสไลด์
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ตั้งค่าสเกลสัมพัทธ์ของความกว้างและความสูง
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// เขียนไฟล์ PPTX ไปยังดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}

Aspose เพิ่งพัฒนา [free Collage Maker](https://products.aspose.app/slides/th/collage) หากคุณต้องการรวมภาพ JPG/JPEG หรือ PNG, หรือสร้างกริดจากรูปถ่าย คุณสามารถใช้บริการนี้ได้

{{% /alert %}}

## **เพิ่มภาพเป็นลิงก์**

เพื่อหลีกเลี่ยงขนาดงานนำเสนอที่ใหญ่ คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์โดยตรงลงในงานนำเสนอ โค้ด C++ นี้แสดงวิธีเพิ่มภาพและวิดีโอลงใน placeholder:

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

## **ครอบภาพ (Crop Images)**

โค้ด C++ นี้แสดงวิธีครอบภาพที่มีอยู่บนสไลด์:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// สร้างอ็อบเจกต์ภาพใหม่
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// เพิ่ม PictureFrame ไปยังสไลด์
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// ครอบภาพ (ค่าร้อยละ)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// บันทึกผลลัพธ์
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ลบพื้นที่ที่ครอบของ Picture**

หากต้องการลบพื้นที่ที่ครอบของภาพที่อยู่ในกรอบ คุณสามารถใช้เมธอด [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) เมธอดนี้จะคืนภาพที่ถูกครอบหรือภาพต้นฉบับหากไม่มีการครอบ

โค้ด C++ นี้แสดงการทำงานดังกล่าว:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// ดึง PictureFrame จากสไลด์แรก
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// ลบพื้นที่ที่ครอบของภาพ PictureFrame และคืนภาพที่ถูกครอบ
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// บันทึกผลลัพธ์
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

เมธอด [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) จะเพิ่มภาพที่ถูกครอบเข้ากับคอลเลกชันภาพของ presentation หากภาพใช้เฉพาะใน [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) นี้จะช่วยลดขนาด presentation มิฉะนั้นจำนวนภาพใน presentation ที่ได้จะเพิ่มขึ้น

เมธอดนี้จะแปลงไฟล์เมทาไฟล์ WMF/EMF เป็น raster PNG ในกระบวนการครอบ

{{% /alert %}}

## **บีบอัดภาพ (Compress Images)**

คุณสามารถบีบอัดภาพใน presentation โดยใช้เมธอด [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/compressimage/) เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดรูปร่างและความละเอียดที่ระบุ พร้อมตัวเลือกให้ลบพื้นที่ที่ครอบ

มันปรับขนาดและความละเอียดของภาพเช่นเดียวกับฟีเจอร์ของ PowerPoint **Picture Format → Compress Pictures → Resolution**

ตัวอย่าง C++ ต่อไปนี้แสดงวิธีบีบอัดภาพใน presentation โดยกำหนดความละเอียดเป้าหมายและตัวเลือกลบพื้นที่ที่ครอบ:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ครอบ
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

// บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) โดยลบพื้นที่ที่ถูกครอบ
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

เมธอดนี้จะแปลงภาพเป็นความละเอียดที่ต่ำลงตามขนาดรูปร่างและ DPI ที่ให้ หากเป็นเมทาไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ นอกจากนี้คุณภาพ JPEG จะถูกเก็บไว้หรืออาจลดลงเล็กน้อยตามความละเอียด เช่นเดียวกับการจัดการของ PowerPoint ต่อ JPEG ความละเอียดสูง

{{% /alert %}}

## **ล็อกอัตราส่วน (Lock Aspect Ratio)**

หากต้องการให้รูปร่างที่บรรจุภาพรักษาอัตราส่วนเดิมแม้เปลี่ยนขนาดภาพ คุณสามารถใช้เมธอด [set_AspectRatioLocked()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) เพื่อเปิดใช้งานการตั้งค่า *Lock Aspect Ratio*

โค้ด C++ นี้แสดงวิธีล็อกอัตราส่วนของรูปร่าง:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// ตั้งค่าให้รูปร่างคงอัตราส่วนเมื่อปรับขนาด
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

การตั้งค่า *Lock Aspect Ratio* นี้จะคงอัตราส่วนของรูปร่างเท่านั้น ไม่ได้คงอัตราส่วนของภาพที่บรรจุอยู่

{{% /alert %}}

## **ใช้คุณสมบัติ StretchOff**

โดยใช้คุณสมบัติ [StretchOffsetLeft](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) และ [StretchOffsetBottom](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) จากอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_picture_fill_format) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.picture_fill_format) คุณสามารถระบุกล่องเติม (fill rectangle)  

เมื่อกำหนดการยืดของภาพ rectangle แหล่งที่มาจะถูกสเกลให้พอดีกับ fill rectangle ที่ระบุ แต่ละด้านของ fill rectangle ถูกกำหนดโดยออฟเซ็ตเปอร์เซ็นต์จากด้านที่สอดคล้องของกล่องขอบของรูปร่าง ค่าเปอร์เซ็นต์บวกหมายถึงการเว้นออกในขณะค่าเปอร์เซ็นต์ลบหมายถึงการขยายออก

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่ม `AutoShape` แบบสี่เหลี่ยม  
4. สร้างภาพ  
5. ตั้งค่าประเภทการเติมของรูปร่าง  
6. ตั้งค่าโหมดการเติมภาพของรูปร่าง  
7. เพิ่มชุดภาพเพื่อเติมรูปร่าง  
8. ระบุออฟเซ็ตของภาพจากด้านที่สอดคล้องของกล่องขอบของรูปร่าง  
9. เขียน presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด C++ นี้แสดงกระบวนการที่ใช้คุณสมบัติ StretchOff:

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// ตั้งค่าภาพให้ยืดจากแต่ละด้านในส่วนของรูปร่าง
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**ฉันจะตรวจสอบรูปแบบภาพที่สนับสนุนสำหรับ PictureFrame ได้อย่างไร?**

Aspose.Slides รองรับทั้ง raster images (PNG, JPEG, BMP, GIF ฯลฯ) และ vector images (เช่น SVG) ผ่านอ็อบเจกต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) รายการรูปแบบที่สนับสนุนมักจะตรงกับความสามารถของเครื่องยนต์แปลงสไลด์และภาพ

**การเพิ่มภาพขนาดใหญ่หลายสิบรูปจะส่งผลต่อขนาดและประสิทธิภาพของ PPTX อย่างไร?**

การฝังภาพขนาดใหญ่จะเพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การลิงก์ภาพจะช่วยให้ขนาดงานนำเสนอคงที่แต่ต้องอัพเดตไฟล์ภายนอกให้ยังเข้าถึงได้ Aspose.Slides มีความสามารถในการเพิ่มภาพโดยลิงก์เพื่อช่วยลดขนาดไฟล์

**ฉันจะล็อกอ็อบเจกต์ภาพจากการเคลื่อนย้าย/ปรับขนาดโดยบังเอิญได้อย่างไร?**

ใช้ [shape locks](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/get_pictureframelock/) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือปรับขนาด) กลไกการล็อกนี้อธิบายสำหรับรูปร่างในบทความการปกป้องแยกต่างหาก [/slides/th/cpp/applying-protection-to-presentation/] และรองรับหลายประเภทรูปแบบรวมถึง [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/)

**ความคมชัดของเวกเตอร์ SVG จะถูกเก็บไว้เมื่อส่งออกงานนำเสนอเป็น PDF/ภาพหรือไม่?**

Aspose.Slides สามารถสกัด SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/pictureframe/) โดยคงเวกเตอร์เดิม เมื่อ [exporting to PDF](/slides/th/cpp/convert-powerpoint-to-pdf/) หรือ [raster formats](/slides/th/cpp/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกเรสเตอร์ขึ้นขึ้นอยู่กับการตั้งค่าการส่งออก; การที่ SVG ดั้งเดิมเก็บเป็นเวกเตอร์จะได้รับการยืนยันจากพฤติกรรมการสกัดนี้.