---
title: C++에서 프레젠테이션 슬라이드를 이미지로 변환
linktitle: 슬라이드 이미지
type: docs
weight: 41
url: /ko/cpp/convert-slide/
keywords:
- 슬라이드 변환
- 슬라이드 내보내기
- 슬라이드 이미지 변환
- 슬라이드 이미지 저장
- 슬라이드 PNG 변환
- 슬라이드 JPEG 변환
- 슬라이드 비트맵 변환
- 슬라이드 TIFF 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PPT, PPTX 및 ODP 슬라이드를 이미지로 변환—빠르고 고품질의 렌더링과 명확한 코드 예제 제공."
---
## **소개**

Aspose.Slides for C++를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션 슬라이드를 BMP, PNG, JPG(JPEG), GIF 등 다양한 이미지 형식으로 쉽게 변환할 수 있습니다.

슬라이드를 이미지로 변환하려면 다음 단계를 따르세요:

1. 원하는 변환 설정을 정의하고 내보내려는 슬라이드를 선택하려면 다음을 사용합니다:
    - ITiffOptions 인터페이스, 또는
    - IRenderingOptions 인터페이스.
2. GetImage 메서드를 호출하여 슬라이드 이미지를 생성합니다.

[Bitmap](https://reference.aspose.com/slides/ko/cpp/system.drawing/bitmap/)은 픽셀 데이터로 정의된 이미지를 다룰 수 있는 객체입니다. 이 클래스를 사용하여 BMP, JPG, PNG 등 다양한 형식으로 이미지를 저장할 수 있습니다.

## **슬라이드를 비트맵으로 변환하고 PNG로 이미지 저장**

슬라이드를 비트맵 객체로 변환하여 애플리케이션에서 직접 사용할 수 있습니다. 또는 슬라이드를 비트맵으로 변환한 후 JPEG 또는 원하는 다른 형식으로 이미지를 저장할 수 있습니다.

다음 C++ 코드는 프레젠테이션의 첫 번째 슬라이드를 비트맵 객체로 변환하고 PNG 형식으로 저장하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 프레젠테이션의 첫 번째 슬라이드를 비트맵으로 변환합니다.
auto image = presentation->get_Slide(0)->GetImage();

// 이미지를 PNG 형식으로 저장합니다.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **사용자 정의 크기로 슬라이드 이미지를 변환**

특정 크기의 이미지가 필요할 수 있습니다. GetImage의 오버로드를 사용하면 슬라이드를 지정된 너비와 높이로 이미지로 변환할 수 있습니다.

다음 샘플 코드는 이를 수행하는 방법을 보여줍니다:

```cpp
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 프레젠테이션의 첫 번째 슬라이드를 지정된 크기의 비트맵으로 변환합니다.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// 이미지를 JPEG 형식으로 저장합니다.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **노트와 주석이 있는 슬라이드를 이미지로 변환**

일부 슬라이드에는 노트와 주석이 포함될 수 있습니다.

Aspose.Slides는 프레젠테이션 슬라이드를 이미지로 렌더링하는 방식을 제어할 수 있는 ITiffOptions와 IRenderingOptions 두 인터페이스를 제공합니다. 두 인터페이스 모두 set_SlidesLayoutOptions 메서드를 포함하고 있으며, 이를 통해 슬라이드를 이미지로 변환할 때 노트와 주석의 렌더링을 구성할 수 있습니다.

NotesCommentsLayoutingOptions 클래스를 사용하면 결과 이미지에서 노트와 주석의 원하는 위치를 지정할 수 있습니다.

다음 C++ 코드는 노트와 주석이 포함된 슬라이드를 변환하는 방법을 보여줍니다:

```cpp
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // 노트의 위치를 설정합니다.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // 주석의 위치를 설정합니다.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // 주석 영역의 너비를 설정합니다.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // 주석 영역의 색상을 설정합니다.

// 렌더링 옵션을 생성합니다.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// 프레젠테이션의 첫 번째 슬라이드를 이미지로 변환합니다.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// 이미지를 GIF 형식으로 저장합니다.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
모든 슬라이드-이미지 변환 과정에서 set_NotesPosition 메서드는 BottomFull을 적용할 수 없습니다(노트 위치 지정). 이는 노트 텍스트가 너무 커서 지정된 이미지 크기에 맞출 수 없기 때문입니다.
{{% /alert %}} 

## **TIFF 옵션을 사용하여 슬라이드를 이미지로 변환**

ITiffOptions 인터페이스를 사용하면 크기, 해상도, 색상 팔레트 등과 같은 매개변수를 지정하여 최종 TIFF 이미지에 대한 보다 세밀한 제어가 가능합니다.

다음 C++ 코드는 TIFF 옵션을 사용하여 300 DPI 해상도와 2160 × 2800 크기의 흑백 이미지를 출력하는 변환 과정을 보여줍니다:

```cpp 
// 프레젠테이션 파일을 로드합니다.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다.
auto slide = presentation->get_Slide(0);

// 출력 TIFF 이미지의 설정을 구성합니다.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // 이미지 크기를 설정합니다.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // 픽셀 형식을 설정합니다 (흑백).
tiffOptions->set_DpiX(300);                                         // 가로 해상도를 설정합니다.
tiffOptions->set_DpiY(300);                                         // 세로 해상도를 설정합니다.

// 지정된 옵션으로 슬라이드를 이미지로 변환합니다.
auto image = slide->GetImage(tiffOptions);

// 이미지를 TIFF 형식으로 저장합니다.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **모든 슬라이드를 이미지로 변환**

Aspose.Slides를 사용하면 프레젠테이션의 모든 슬라이드를 이미지로 변환하여 전체 프레젠테이션을 일련의 이미지로 만들 수 있습니다.

다음 샘플 코드는 C++에서 프레젠테이션의 모든 슬라이드를 이미지로 변환하는 방법을 보여줍니다:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 프레젠테이션을 슬라이드별로 이미지로 렌더링합니다.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // 숨김 슬라이드를 제어합니다 (숨김 슬라이드는 렌더링하지 않음).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // 슬라이드를 이미지로 변환합니다.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // 이미지를 JPEG 형식으로 저장합니다.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **컬러 이모지 렌더링**

{{% alert title="Note" color="warning" %}} 
프레젠테이션 슬라이드를 이미지로 변환할 때 컬러 이모지를 올바르게 렌더링하려면 프레젠테이션에 사용된 이모지 폰트가 변환을 수행하는 시스템에 설치되어 있어야 합니다. 예를 들어 프레젠테이션이 Segoe UI Emoji를 사용하고 해당 폰트가 없으면 출력 이미지에서 이모지가 흑백으로 표시될 수 있습니다.
{{% /alert %}}

## **FAQ**

**Aspose.Slides가 애니메이션이 있는 슬라이드 렌더링을 지원합니까?**

아니요, GetImage 메서드는 슬라이드의 정적 이미지만 저장하며 애니메이션은 포함되지 않습니다.

**숨겨진 슬라이드를 이미지로 내보낼 수 있습니까?**

네, 숨겨진 슬라이드도 일반 슬라이드와 동일하게 처리할 수 있습니다. 처리 루프에 포함되도록 확인하면 됩니다.

**이미지를 그림자와 효과를 포함해서 저장할 수 있습니까?**

네, Aspose.Slides는 슬라이드를 이미지로 저장할 때 그림자, 투명도 및 기타 그래픽 효과를 렌더링하는 것을 지원합니다.