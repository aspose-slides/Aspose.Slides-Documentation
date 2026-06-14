---
title: Hình ảnh
type: docs
weight: 50
url: /vi/cpp/examples/elements/picture/
keywords:
- ví dụ mã
- hình ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Làm việc với hình ảnh trong Aspose.Slides for C++: chèn, cắt, nén, thay đổi màu và xuất ảnh với các ví dụ C++ cho các bài thuyết trình PPT, PPTX và ODP."
---
Bài viết này trình bày cách chèn và truy cập ảnh từ các hình ảnh trong bộ nhớ bằng **Aspose.Slides for C++**. Các ví dụ dưới đây tạo một ảnh trong bộ nhớ, đặt nó lên một slide, sau đó truy xuất lại.

## **Thêm hình ảnh**

Mã này tạo một bitmap nhỏ, chuyển nó thành luồng và chèn nó dưới dạng khung ảnh vào slide đầu tiên.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Tạo một hình ảnh đơn giản trong bộ nhớ.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // Chuyển đổi bitmap thành mảng byte.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // Thêm hình ảnh vào bài thuyết trình.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // Chèn khung ảnh hiển thị hình ảnh trên slide đầu tiên.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Truy cập hình ảnh**

Ví dụ này đảm bảo slide chứa một khung ảnh và sau đó truy cập vào khung ảnh đầu tiên được tìm thấy.

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