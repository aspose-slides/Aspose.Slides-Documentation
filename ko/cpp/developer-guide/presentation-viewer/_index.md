---
title: C++에서 프레젠테이션 뷰어 만들기
linktitle: 프레젠테이션 뷰어
type: docs
weight: 50
url: /ko/cpp/presentation-viewer/
keywords:
- 프레젠테이션 보기
- 프레젠테이션 뷰어
- 프레젠테이션 뷰어 만들기
- PPT 보기
- PPTX 보기
- ODP 보기
- 파워포인트
- 오픈문서
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 맞춤형 프레젠테이션 뷰어를 만들고, Microsoft PowerPoint 없이도 PowerPoint 및 OpenDocument 파일을 쉽게 표시합니다."
---
## **소개**

Aspose.Slides for C++는 슬라이드가 포함된 프레젠테이션 파일을 만드는 데 사용됩니다. 이러한 슬라이드는 예를 들어 Microsoft PowerPoint에서 프레젠테이션을 열어 볼 수 있습니다. 그러나 때때로 개발자는 선호하는 이미지 뷰어에서 슬라이드를 이미지로 보거나 자체 프레젠테이션 뷰어를 만들어야 할 수도 있습니다. 이런 경우 Aspose.Slides를 사용하면 개별 슬라이드를 이미지로 내보낼 수 있습니다. 이 문서에서는 그 방법을 설명합니다.

## **슬라이드에서 SVG 이미지 생성**

Aspose.Slides를 사용하여 프레젠테이션 슬라이드에서 SVG 이미지를 생성하려면 아래 단계에 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 파일 스트림을 엽니다.
1. 슬라이드를 SVG 이미지로 파일 스트림에 저장합니다.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **사용자 지정 Shape ID로 SVG 생성**

Aspose.Slides를 사용하면 사용자 지정 Shape ID가 있는 슬라이드에서 [SVG](https://docs.fileformat.com/page-description-language/svg/)를 생성할 수 있습니다. 이를 위해서는 [ISvgShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/isvgshape/)의 `set_Id` 메서드를 사용합니다. `CustomSvgShapeFormattingController`를 사용하여 Shape ID를 설정할 수 있습니다.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **슬라이드 썸네일 이미지 만들기**

Aspose.Slides는 슬라이드의 썸네일 이미지를 생성하는 데 도움을 줍니다. Aspose.Slides를 사용하여 슬라이드 썸네일을 생성하려면 아래 단계에 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 정의된 스케일로 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **사용자 정의 크기로 슬라이드 썸네일 만들기**

사용자 정의 크기로 슬라이드 썸네일 이미지를 만들려면 아래 단계에 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 정의된 크기로 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **슬라이드 썸네일에 발표자 노트 포함하기**

Aspose.Slides를 사용하여 발표자 노트가 포함된 슬라이드 썸네일을 생성하려면 아래 단계에 따르세요:

1. [RenderingOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/renderingoptions/) 클래스의 인스턴스를 생성합니다.
1. `RenderingOptions.set_SlidesLayoutOptions` 메서드를 사용하여 발표자 노트의 위치를 설정합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 렌더링 옵션을 사용하여 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **실시간 예제**

Aspose.Slides API로 구현할 수 있는 기능을 확인하려면 무료 앱인 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/ko/viewer/)을 사용해 볼 수 있습니다:

![온라인 PowerPoint 뷰어](online-PowerPoint-viewer.png)

## **FAQ**

**웹 애플리케이션에 프레젠테이션 뷰어를 삽입할 수 있나요?**

예. 서버 측에서 Aspose.Slides를 사용하여 슬라이드를 이미지 또는 HTML로 렌더링하고 브라우저에 표시할 수 있습니다. 탐색 및 줌 기능은 JavaScript로 구현하여 인터랙티브한 경험을 제공할 수 있습니다.

**커스텀 뷰어 내에서 슬라이드를 표시하는 가장 좋은 방법은 무엇인가요?**

권장 방법은 각 슬라이드를 이미지(PNG 또는 SVG 등)로 렌더링하거나 Aspose.Slides를 사용해 HTML로 변환한 뒤, 데스크톱의 경우 그림 상자에, 웹의 경우 HTML 컨테이너에 출력물을 표시하는 것입니다.

**많은 슬라이드가 있는 대용량 프레젠테이션을 어떻게 처리하나요?**

대용량 프레젠테이션의 경우 슬라이드를 지연 로딩하거나 필요 시 렌더링하는 방식을 고려하세요. 이는 사용자가 해당 슬라이드로 이동할 때만 내용을 생성하여 메모리 사용량과 로드 시간을 줄이는 효과가 있습니다.