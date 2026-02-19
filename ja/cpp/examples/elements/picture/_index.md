---
title: 画像
type: docs
weight: 50
url: /ja/cpp/examples/elements/picture/
keywords:
- コード例
- 画像
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で画像を操作します: 挿入、トリミング、圧縮、再着色、エクスポート。C++ のサンプルで PPT、PPTX、ODP プレゼンテーション向けの画像処理を行います。"
---
この記事では、**Aspose.Slides for C++** を使用して、メモリ内の画像から画像を挿入およびアクセスする方法を示します。以下の例では、メモリ内に画像を作成し、スライドに配置し、さらに取得します。

## **画像の追加**

このコードは小さなビットマップを生成し、ストリームに変換して、最初のスライドに画像フレームとして挿入します。

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // シンプルなインメモリ画像を作成します。
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // ビットマップをバイト配列に変換します。
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // 画像をプレゼンテーションに追加します。
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // 最初のスライドに画像を表示する画像フレームを挿入します。
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **画像へのアクセス**

この例では、スライドに画像フレームが含まれていることを確認し、見つかった最初のフレームにアクセスします。

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