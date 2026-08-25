---
title: C++에서 Low-Code 프레젠테이션 작업
linktitle: Low-Code API
type: docs
weight: 50
url: /ko/cpp/low-code-presentation-operations/
keywords:
- low-code 프레젠테이션 API
- 프레젠테이션 변환
- 프레젠테이션 병합
- 슬라이드 순회
- 도형 순회
- 텍스트 순회
- 도형 수집
- 프레젠테이션 압축
- 사용되지 않는 마스터 슬라이드 제거
- 사용되지 않는 레이아웃 슬라이드 제거
- 포함된 글꼴 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides low-code API를 C++에서 사용하여 프레젠테이션을 변환하고 병합하며, 콘텐츠를 순회하고 도형을 수집하며 프레젠테이션 크기를 줄입니다."
---
## **개요**

The [Aspose::Slides::LowCode](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/) 네임스페이스는 일반적인 프레젠테이션 작업을 위한 정적 헬퍼 클래스를 제공합니다. 이러한 헬퍼는 자주 사용되는 객체 모델 워크플로를 집중된 메서드로 래핑하여 파일을 변환하거나 병합하고, 프레젠테이션 요소를 처리하며, 도형을 수집하고, 사용되지 않는 콘텐츠를 더 적은 코드로 제거할 수 있습니다.

Low-code 헬퍼는 작업이 전체 파일 또는 프레젠테이션에 적용되고 기본 워크플로가 요구 사항에 부합할 때 가장 유용합니다. 개별 슬라이드, 마스터, 레이아웃, 도형, 내보내기 설정 또는 프레젠테이션 요소 간 관계에 대한 세밀한 제어가 필요할 경우 전체 [Aspose.Slides object model](https://reference.aspose.com/slides/ko/cpp/aspose.slides/)을 사용하십시오.

다음 표는 사용 가능한 헬퍼를 요약합니다:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/convert/) | 파일 간 직접 호출로 프레젠테이션을 다른 형식으로 변환 |
| [Merger](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/merger/) | 동일한 형식의 전체 프레젠테이션 파일을 결합 |
| [ForEach](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/) | 각 슬라이드, 도형, 단락, 텍스트 구획에 대해 작업 실행 |
| [Collect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/collect/) | 반복 처리나 분석을 위해 전체 프레젠테이션에서 도형을 검색 |
| [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) | 사용되지 않는 마스터와 레이아웃을 제거하고 포함된 글꼴 데이터를 축소 |

## **프레젠테이션 변환**

출력 파일 확장자만으로 내보내기 형식을 선택할 수 있을 때는 [Convert::AutoByExtension](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/convert/autobyextension/)를 사용하십시오. 이 메서드는 소스 프레젠테이션을 열고, 출력 경로에서 필요한 형식을 결정한 뒤 결과를 씁니다.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

[Convert](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/convert/) 클래스는 PDF, SVG, JPEG, PNG 및 TIFF 출력 전용 메서드도 제공합니다. 내보내기 전에 프레젠테이션을 검사하거나 수정해야 하거나 선택된 헬퍼가 노출하지 않는 내보내기 옵션을 구성해야 하는 경우 전체 객체 모델을 사용하십시오. 형식별 워크플로 및 옵션은 [Convert Presentation](/slides/ko/cpp/convert-presentation/)를 참고하십시오.

## **프레젠테이션 병합**

전체 프레젠테이션 파일을 한 번에 결합하려면 [Merger::Process](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/merger/process/)를 사용하십시오. 입력 프레젠테이션은 동일한 파일 형식이어야 합니다.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

모든 슬라이드를 하나의 결과에 순차적으로 추가하고 개별 슬라이드를 선택하거나 재매핑할 필요가 없는 경우 이 헬퍼가 적합합니다. 선택된 슬라이드만 병합하거나 대상 마스터·레이아웃을 적용하고, 섹션을 명시적으로 유지하거나 서로 다른 슬라이드 크기를 조정해야 하는 경우 전체 객체 모델을 사용하십시오. 이러한 시나리오는 [Merge Presentations](/slides/ko/cpp/merge-presentation/)를 참고하십시오.

## **프레젠테이션 요소 반복 처리**

[ForEach](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/) 클래스는 요청된 유형의 프레젠테이션 요소마다 콜백을 호출합니다. 중첩된 컬렉션 루프를 피하고 프레젠테이션 전체에 대한 검사 또는 서식 변경에 편리합니다.

다음 예제는 [ForEach::Slide](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/paragraph/), [ForEach::Portion](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/portion/)을 사용해 해당 요소를 검사합니다:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

기본적으로 프레젠테이션 전체 도형·텍스트 순회에는 일반 슬라이드, 마스터 슬라이드, 레이아웃 슬라이드가 포함됩니다. `includeNotes` 매개변수가 있는 오버로드를 사용하면 노트 슬라이드도 처리할 수 있습니다. 순회 순서, 조기 종료, 콜백 호출 전 필터링 또는 상세한 부모‑자식 제어가 중요한 경우 직접 컬렉션 루프를 사용하십시오.

## **도형 수집**

각 도형에 대한 콜백 대신 프레젠테이션 전체 도형 컬렉션이 필요할 때는 [Collect::Shapes](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/collect/shapes/)를 사용하십시오. 같은 집합을 여러 번 필터링·계산·처리하려는 경우에 유용합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

각 도형을 즉시 처리하고 수집된 결과를 보관할 필요가 없을 경우에는 [ForEach::Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/shape/)를 사용하십시오.

## **프레젠테이션 콘텐츠 압축**

[Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) 클래스는 사용되지 않는 구조적 요소를 제거하고 포함된 글꼴 데이터를 축소할 수 있습니다.

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)은 일반 슬라이드가 참조하지 않는 레이아웃 슬라이드를 제거합니다.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/)은 더 이상 사용되지 않는 마스터 슬라이드를 제거합니다.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/)은 포함된 글꼴에서 사용되지 않는 문자를 제거합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

레이아웃을 먼저 제거하고 그 다음에 마스터를 제거하십시오. 레이아웃 정리 후에 참조가 사라진 마스터도 제거할 수 있습니다. 원본 마스터·레이아웃·전체 포함 글꼴 데이터가 필요할 수 있는 경우 최적화된 프레젠테이션을 새 파일에 저장하십시오. 자세한 내용은 [Slide Master](/slides/ko/cpp/slide-master/)와 [Embedded Font](/slides/ko/cpp/embedded-font/)를 참고하십시오.

## **FAQ**

**Low-code API를 전체 객체 모델 대신 언제 사용해야 하나요?**

표준 작업이 전체 파일 또는 프레젠테이션에 적용되고 개별 요소에 대한 세부 제어가 필요하지 않을 때 Low-code 헬퍼를 사용하십시오. 특정 슬라이드를 선택하거나 마스터·레이아웃 관계를 제어하고, 중간 상태를 검사하거나 헬퍼가 노출하지 않는 동작을 구성해야 할 경우 전체 객체 모델을 사용하십시오.

**Merger가 서로 다른 파일 형식의 프레젠테이션을 결합할 수 있나요?**

아니요. [Merger::Process](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/merger/process/)는 입력 프레젠테이션이 동일한 형식일 것을 요구합니다. 예를 들어 [Convert::AutoByExtension](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/convert/autobyextension/)을 사용해 입력 파일을 공통 형식으로 변환한 후 결합하십시오.

**ForEach가 마스터, 레이아웃 및 노트 슬라이드를 처리하나요?**

[ForEach::Slide](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/slide/)은 일반 프레젠테이션 슬라이드만 순회합니다. 프레젠테이션 전체에 대한 [ForEach::Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/paragraph/), [ForEach::Portion](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/portion/) 작업은 기본적으로 일반, 마스터, 레이아웃 슬라이드를 포함합니다. `includeNotes`를 `true`로 설정한 오버로드를 사용하면 노트 슬라이드도 포함됩니다.

**ForEach::Shape와 Collect::Shapes의 차이점은 무엇인가요?**

각 도형을 콜백을 통해 즉시 처리하려면 [ForEach::Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/shape/)를 사용하십시오. 도형 컬렉션을 보관·필터링·다중 횟수로 순회하려면 [Collect::Shapes](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/collect/shapes/)를 사용하십시오.

**Compress가 항상 프레젠테이션 파일을 더 작게 만들나요?**

반드시 그렇지는 않습니다. 결과는 프레젠테이션에 사용되지 않는 레이아웃, 사용되지 않는 마스터, 또는 사용되지 않은 문자들이 포함된 임베디드 글꼴이 있는지 여부에 따라 달라집니다. 이러한 요소가 없으면 해당 [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) 작업이 파일 크기를 줄이지 않을 수 있습니다.

**ForEach 또는 Compress로 변경한 내용이 자동으로 저장되나요?**

아니요. 이러한 헬퍼는 메모리 내에 로드된 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 객체에 대해 동작합니다. [ForEach](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/) 콜백이나 [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/)를 실행한 후에는 [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/)을 호출해 결과를 저장해야 합니다.

## **관련 문서**

- [Convert Presentation](/slides/ko/cpp/convert-presentation/)
- [Merge Presentations](/slides/ko/cpp/merge-presentation/)
- [Slide Master](/slides/ko/cpp/slide-master/)
- [Manage Text Box](/slides/ko/cpp/manage-textbox/)
- [Embedded Font](/slides/ko/cpp/embedded-font/)