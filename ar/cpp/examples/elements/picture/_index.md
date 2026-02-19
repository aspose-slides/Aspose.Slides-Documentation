---
title: صورة
type: docs
weight: 50
url: /ar/cpp/examples/elements/picture/
keywords:
- مثال على الكود
- صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "العمل مع الصور في Aspose.Slides for C++: إدراج، قص، ضغط، تعديل اللون، وتصدير الصور مع أمثلة C++ لعروض PPT و PPTX و ODP."
---
توضح هذه المقالة كيفية إدراج الصور والوصول إليها من الصور المخزنة في الذاكرة باستخدام **Aspose.Slides for C++**. تُنشئ الأمثلة أدناه صورة في الذاكرة، وتضعها على شريحة، ثم تسترجعها.

## **إضافة صورة**

يولد هذا الشيفرة صورة نقطية صغيرة، يحولها إلى تدفق، ويُدرجها كإطار صورة في الشريحة الأولى.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // إنشاء صورة بسيطة في الذاكرة.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // تحويل الـ bitmap إلى مصفوفة بايت.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // إضافة الصورة إلى العرض التقديمي.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // إدراج إطار صورة يعرض الصورة على الشريحة الأولى.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **الوصول إلى صورة**

يتأكد هذا المثال من أن الشريحة تحتوي على إطار صورة ثم يصل إلى أول إطار يجده.

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