---
title: 圖片
type: docs
weight: 50
url: /zh-hant/cpp/examples/elements/picture/
keywords:
- 程式碼範例
- 圖片
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中處理圖片：插入、裁剪、壓縮、重新著色，並使用 C++ 範例匯出 PPT、PPTX 與 ODP 簡報的影像。"
---
本文示範如何在記憶體中的影像上插入和存取圖片，使用 **Aspose.Slides for C++**。以下範例會在記憶體中建立圖像，將其放置在投影片上，然後再取回。

## **新增圖片**

此程式碼會產生小型點陣圖，將其轉換為串流，並將其作為圖片框插入第一張投影片。

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 建立一個簡單的記憶體影像。
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // 將位圖轉換為位元組陣列。
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // 將影像加入簡報。
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // 在第一張投影片插入顯示該影像的圖片框。
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **存取圖片**

此範例確保投影片包含圖片框，然後存取它找到的第一個圖片框。

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