---
title: 그림
type: docs
weight: 50
url: /ko/cpp/examples/elements/picture/
keywords:
- 코드 예제
- 그림
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 그림 작업: 삽입, 자르기, 압축, 색상 변경 및 이미지를 내보내기, PPT, PPTX 및 ODP 프레젠테이션용 C++ 예제와 함께."
---
이 문서에서는 **Aspose.Slides for C++**를 사용하여 메모리 내 이미지에서 그림을 삽입하고 액세스하는 방법을 보여줍니다. 아래 예제는 메모리에서 이미지를 생성하고 슬라이드에 배치한 다음 해당 이미지를 검색합니다.

## **그림 추가**

이 코드는 작은 비트맵을 생성하고, 스트림으로 변환한 뒤 첫 번째 슬라이드에 그림 프레임으로 삽입합니다.

```cpp
static void AddPicture()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 간단한 메모리 내 이미지를 생성합니다.
    auto bitmap = MakeObject<Bitmap>(100, 100, PixelFormat::Format32bppArgb);
    auto graphics = Graphics::FromImage(bitmap.get());
    graphics->FillRectangle(MakeObject<SolidBrush>(Color::FromArgb(144, 238, 144)), 0, 0, 100, 100);
    graphics->Dispose();

    // 비트맵을 바이트 배열로 변환합니다.
    auto bitmapStream = MakeObject<MemoryStream>();
    bitmap->Save(bitmapStream, System::Drawing::Imaging::ImageFormat::get_Png());
    auto pngBytes = bitmapStream->ToArray();

    // 이미지를 프레젠테이션에 추가합니다.
    auto image = presentation->get_Images()->AddImage(MakeObject<MemoryStream>(pngBytes));

    // 첫 번째 슬라이드에 이미지를 표시하는 그림 프레임을 삽입합니다.
    slide->get_Shapes()->AddPictureFrame(
        ShapeType::Rectangle, 50, 50, bitmap->get_Width(), bitmap->get_Height(), image);

    presentation->Save(u"picture.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **그림 액세스**

이 예제는 슬라이드에 그림 프레임이 포함되어 있는지 확인한 후, 찾은 첫 번째 프레임에 액세스합니다.

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