---
title: รูปภาพ
type: docs
weight: 50
url: /th/cpp/examples/elements/picture/
keywords:
- ตัวอย่างโค้ด
- รูปภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ทำงานกับรูปภาพใน Aspose.Slides for C++: แทรก, ครอบตัด, บีบอัด, เปลี่ยนสี, และส่งออกภาพด้วยตัวอย่าง C++ สำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีแทรกและเข้าถึงรูปภาพจากภาพที่อยู่ในหน่วยความจำโดยใช้ **Aspose.Slides for C++** ตัวอย่างด้านล่างสร้างภาพในหน่วยความจำ วางไว้บนสไลด์ แล้วดึงออกมา

## **เพิ่มรูปภาพ**

โค้ดนี้สร้างบิตแมพขนาดเล็ก แปลงเป็นสตรีม และแทรกเป็นกรอบรูปภาพบนสไลด์แรก

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // สร้างภาพในหน่วยความจำแบบง่าย.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // แปลงบิตแมพเป็นอาร์เรย์ของไบต์.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // เพิ่มภาพไปยังการนำเสนอ.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // แทรกกรอบรูปภาพที่แสดงภาพบนสไลด์แรก.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **เข้าถึงรูปภาพ**

ตัวอย่างนี้ตรวจสอบว่าหนึ่งสไลด์มีกรอบรูปภาพและจากนั้นเข้าถึงกรอบแรกที่พบ

```cpp
static void AccessPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto bitmap = MakeObject<Bitmap>(40, 40, PixelFormat::Format32bppArgb);
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0, 0, 40, 40, image);

    auto pictureFrame = SharedPtr<IPictureFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            pictureFrame = ExplicitCast<IPictureFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```