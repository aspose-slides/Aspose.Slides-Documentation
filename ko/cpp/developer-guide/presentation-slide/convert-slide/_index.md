---
title: C++에서 프레젠테이션 슬라이드를 이미지로 변환
linktitle: 슬라이드에서 이미지로
type: docs
weight: 41
url: /ko/cpp/convert-slide/
keywords:
- 슬라이드 변환
- 슬라이드 내보내기
- 슬라이드 이미지 변환
- 슬라이드 이미지로 저장
- 슬라이드 EMF 변환
- 슬라이드 PNG 변환
- 슬라이드 JPEG 변환
- 슬라이드 비트맵 변환
- 슬라이드 TIFF 변환
- 파워포인트
- 오픈도큐먼트
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PPT, PPTX 및 ODP 프레젠테이션의 슬라이드를 C++에서 PNG, JPEG, GIF, TIFF, EMF 및 기타 이미지 형식으로 변환합니다."
---
## **소개**

Aspose.Slides for C++는 PowerPoint 및 OpenDocument 프레젠테이션의 개별 슬라이드를 PNG, JPEG, GIF, TIFF 및 기타 이미지 형식으로 렌더링할 수 있습니다.

슬라이드를 이미지로 변환하려면 다음 단계를 따르십시오:

1. 프레젠테이션을 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 로드합니다.
2. 렌더링하려는 슬라이드를 선택합니다.
3. 필요에 따라 [RenderingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/renderingoptions/) 또는 [TiffOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/) 클래스로 렌더링을 구성합니다.
4. [ISlide::GetImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/getimage/) 메서드를 호출합니다. 이 메서드는 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) 객체를 반환합니다.
5. [IImage::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/save/) 메서드를 호출하고 [ImageFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imageformat/) 값을 사용하여 출력 형식을 지정합니다.

## **슬라이드를 PNG 이미지로 변환**

가장 간단한 변환은 기본 렌더링 설정을 사용합니다. 결과 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) 객체는 메모리에서 처리하거나 파일로 저장할 수 있습니다.

다음 C++ 예제는 첫 번째 슬라이드를 렌더링하고 PNG 이미지로 저장합니다:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **사용자 정의 크기로 슬라이드 이미지를 변환**

[Size](https://reference.aspose.com/slides/ko/cpp/system.drawing/size/) 값을 받아 정확한 픽셀 크기로 슬라이드를 렌더링하는 [ISlide::GetImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/getimage/) 오버로드를 사용합니다.

다음 예제는 1820 × 1040 JPEG 이미지를 생성합니다:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **노트와 댓글이 포함된 슬라이드를 이미지로 변환**

기본적으로 슬라이드 이미지에는 노트나 댓글이 포함되지 않습니다. [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/notescommentslayoutingoptions/) 객체를 [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) 메서드에 할당하여 노트와 댓글이 표시되는 위치를 제어합니다.

다음 예제는 잘린 노트를 슬라이드 아래에, 댓글을 오른쪽에 배치합니다:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
슬라이드-이미지 변환 시, [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) 메서드를 [BottomFull](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/notespositions/) 으로 설정하지 마세요. 노트는 고정된 이미지 크기보다 더 많은 텍스트를 포함할 수 있습니다. 대신 [BottomTruncated](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/notespositions/) 을 사용하십시오.
{{% /alert %}}

## **TIFF 옵션을 사용하여 슬라이드 이미지를 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/) 클래스를 사용하면 렌더링된 TIFF 이미지의 크기, 해상도 및 기타 속성을 제어할 수 있습니다.

다음 예제는 첫 번째 슬라이드를 300 DPI의 2160 × 2880 TIFF 이미지로 렌더링합니다:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **전체 슬라이드를 이미지로 변환**

슬라이드 컬렉션을 반복하여 전체 프레젠테이션을 일련의 이미지로 변환합니다. 별도로 건너뛰지 않는 한 숨겨진 슬라이드도 포함됩니다.

다음 예제는 모든 슬라이드를 가로 및 세로 배율 2인 JPEG 이미지로 렌더링합니다:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **향상 메타파일 출력 생성**

향상 메타파일(EMF)은 벡터 기반 그래픽을 Microsoft Office 또는 Windows 메타파일을 지원하는 다른 Windows 애플리케이션과 교환해야 할 때 유용합니다. 픽셀 기반 이미지와 달리 EMF는 스케일해도 선명도 손실이 없는 벡터 그리기 작업을 유지할 수 있습니다. 그러나 EMF는 주로 Windows 메타파일을 지원하는 응용 프로그램과의 호환성을 위한 형식이며, 보편적인 교환 형식은 아닙니다. 또한 비트맵 이미지 및 일부 효과와 같은 복잡한 슬라이드 내용은 벡터 메타파일 컨테이너 내부에 래스터화된 요소로 저장될 수 있습니다.

### **슬라이드를 EMF로 내보내기**

[ISlide::WriteAsEmf](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/writeasemf/) 메서드는 [ISlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/)을 EMF 형식의 대상 스트림에 씁니다. 다음 예제는 프레젠테이션을 로드하고 첫 번째 슬라이드를 선택한 다음 EMF 파일 스트림에 씁니다:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

호출자는 [ISlide::WriteAsEmf](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/writeasemf/) 에 전달된 스트림을 소유하며 이를 닫거나 폐기해야 합니다. Aspose.Slides는 스트림의 현재 위치에서 쓰기를 수행하고 스트림을 열어 둡니다.

### **SVG 이미지를 EMF로 변환하고 프레젠테이션에 추가**

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/writeasemf/) 을 사용하여 SVG 콘텐츠를 EMF로 변환합니다. 결과 바이트는 [IImageCollection::AddImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimagecollection/addimage/) 을 통해 프레젠테이션에 추가할 수 있으며, [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addpictureframe/) 로 슬라이드에 배치합니다.

다음 예제는 SVG 마크업에서 [SvgImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/svgimage/) 을 생성하고, 이를 메모리 내 EMF 로 변환한 뒤, 첫 번째 슬라이드에 메타파일을 삽입하고 프레젠테이션을 저장합니다:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isvgimage/writeasemf/) 은 대상 스트림에 대한 소유권을 갖지 않습니다. 쓰기 후 스트림 위치는 생성된 데이터 끝에 있습니다. 예제에서는 현재 스트림 위치와 관계없이 전체 버퍼를 얻기 위해 [MemoryStream::ToArray](https://reference.aspose.com/slides/ko/cpp/system.io/memorystream/toarray/) 를 호출하고, 해당 바이트 배열을 [IImageCollection::AddImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimagecollection/addimage/) 에 전달합니다. 소비자가 읽기를 마칠 때까지 스트림을 열어 두고, 이후에 닫습니다.

EMF 생성은 Aspose.Slides for C++가 지원하는 운영 체제에서 사용할 수 있지만, 폰트나 기본 그래픽 종속성이 없을 경우 플랫폼마다 렌더링이 달라질 수 있습니다. 원본 콘텐츠에 사용된 폰트를 설치하거나 적절한 대체 폰트를 구성하고, Aspose.Slides for C++의 [platform requirements](/slides/ko/cpp/system-requirements/) 를 따른 다음 대상 EMF를 사용하는 애플리케이션에서 결과를 검증하십시오. Linux와 macOS 애플리케이션은 Windows 메타파일을 표시하거나 편집하는 지원이 제한적이거나 일관되지 않을 수 있습니다.

## **컬러 이모지 렌더링**

{{% alert title="Note" color="info" %}}
프레젠테이션 슬라이드를 이미지로 변환할 때 색상 이모지를 올바르게 렌더링하려면 프레젠테이션에 사용된 이모지 폰트가 변환을 수행하는 시스템에 설치되고 사용 가능해야 합니다. 예를 들어 프레젠테이션이 **Segoe UI Emoji** 를 사용하고 이 폰트가 없으면 이모지가 출력 이미지에서 단색으로 표시될 수 있습니다.
{{% /alert %}}

## **FAQ**

**Aspose.Slides가 애니메이션이 포함된 슬라이드 렌더링을 지원합니까?**

아니요. [ISlide::GetImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/getimage/) 메서드는 슬라이드의 정적 이미지를 렌더링하며 애니메이션을 내보내지 않습니다.

**숨겨진 슬라이드를 이미지로 내보낼 수 있습니까?**

예. 숨겨진 슬라이드도 일반 슬라이드처럼 렌더링할 수 있습니다. 위 예제와 같이 처리 루프에 포함하면 됩니다.

**그림자 및 기타 효과가 슬라이드 이미지에 보존됩니까?**

예. Aspose.Slides는 슬라이드 이미지에 그림자, 투명도 및 기타 지원되는 그래픽 효과를 렌더링합니다.