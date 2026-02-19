---
title: 图片
type: docs
weight: 50
url: /zh/cpp/examples/elements/picture/
keywords:
- 代码示例
- 图片
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中处理图片：插入、裁剪、压缩、重新着色，并使用 C++ 示例导出适用于 PPT、PPTX 和 ODP 演示文稿的图像。"
---
本文演示了如何使用 **Aspose.Slides for C++** 插入和访问内存中的图像。下面的示例在内存中创建图像，将其放置在幻灯片上，然后检索它。

## **添加图片**
此代码生成一个小位图，将其转换为流，并将其作为图片框插入第一张幻灯片。

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 创建一个简单的内存图像。
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // 将位图转换为字节数组。
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // 将图像添加到演示文稿。
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // 在第一张幻灯片上插入显示图像的图片框。
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **访问图片**
此示例确保幻灯片包含图片框，然后访问找到的第一个图片框。

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