---
title: تصویر
type: docs
weight: 50
url: /fa/cpp/examples/elements/picture/
keywords:
- مثال کد
- تصویر
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "کار با تصاویر در Aspose.Slides برای C++: درج، برش، فشرده‌سازی، تغییر رنگ و استخراج تصاویر با نمونه‌های C++ برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه می‌توان با استفاده از **Aspose.Slides for C++** تصاویر را از تصاویر در حافظه درج و دسترسی پیدا کرد. مثال‌های زیر یک تصویر را در حافظه ایجاد می‌کنند، آن را بر روی اسلایدی قرار می‌دهند و سپس بازیابی می‌کنند.

## **افزودن یک تصویر**

این کد یک بیت‌مپ کوچک تولید می‌کند، آن را به یک جریان تبدیل می‌کند و به‌عنوان یک فریم تصویر در اولین اسلاید وارد می‌نماید.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // یک تصویر ساده در حافظه ایجاد می‌کند.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // بیت‌مپ را به آرایه بایت تبدیل کنید.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // تصویر را به ارائه اضافه کنید.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // یک قاب تصویر که تصویر را در اسلاید اول نشان می‌دهد وارد کنید.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **دسترسی به تصویر**

این مثال اطمینان می‌یابد که یک اسلاید شامل یک فریم تصویر است و سپس اولین فریمی که پیدا می‌کند را دریافت می‌کند.

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