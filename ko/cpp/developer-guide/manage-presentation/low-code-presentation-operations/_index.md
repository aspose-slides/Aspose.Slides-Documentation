---
title: C++에서 Low-Code 프레젠테이션 작업
linktitle: Low-Code API
type: docs
weight: 50
url: /ko/cpp/low-code-presentation-operations/
keywords:
- Low-Code 프레젠테이션 API
- 프레젠테이션 변환
- 프레젠테이션 병합
- 슬라이드 순회
- 도형 순회
- 텍스트 순회
- 도형 수집
- 프레젠테이션 압축
- 사용되지 않은 마스터 슬라이드 제거
- 사용되지 않은 레이아웃 슬라이드 제거
- 내장 글꼴 압축
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++에서 Aspose.Slides Low-Code API를 사용하여 프레젠테이션을 변환 및 병합하고, 콘텐츠를 순회하며, 도형을 수집하고, 프레젠테이션 크기를 줄입니다."
---
## **개요**

Aspose::Slides::LowCode 네임스페이스는 일반 프레젠테이션 작업을 위한 정적 도우미 클래스를 제공합니다. 이러한 도우미는 자주 사용되는 객체 모델 워크플로우를 집중된 메서드로 감싸므로 파일을 변환하거나 병합하고, 프레젠테이션 요소를 처리하고, 도형을 수집하며, 사용되지 않은 콘텐츠를 적은 코드로 제거할 수 있습니다.

Low-code 도우미는 작업이 전체 파일이나 프레젠테이션에 적용되고 기본 워크플로우가 요구사항과 일치할 때 가장 유용합니다. 개별 슬라이드, 마스터, 레이아웃, 도형, 내보내기 설정 또는 프레젠테이션 요소 간 관계에 대해 세밀한 제어가 필요하면 전체 [Aspose.Slides object model](https://reference.aspose.com/slides/ko/cpp/aspose.slides/)을 사용하십시오.

다음 표는 사용 가능한 도우미를 요약합니다:

| 도우미 | 사용 용도 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/convert/) | 파일 간 직접 호출로 프레젠테이션을 다른 형식으로 변환합니다. |
| [Merger](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/merger/) | 같은 형식의 전체 프레젠테이션 파일을 결합합니다. |
| [ForEach](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/) | 각 슬라이드, 도형, 단락, 텍스트 부분에 대해 작업을 실행합니다. |
| [Collect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/collect/) | 전체 프레젠테이션에서 도형을 가져와 반복 처리 또는 분석에 사용합니다. |
| [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) | 사용되지 않은 마스터와 레이아웃을 제거하고 포함된 글꼴 데이터를 축소합니다. |

## **프레젠테이션 변환**

출력 파일 확장자만으로 내보내기 형식을 선택할 수 있을 때는 [Convert::AutoByExtension](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/convert/autobyextension/)을 사용하십시오. 이 메서드는 소스 프레젠테이션을 열고 출력 경로에서 필요한 형식을 결정한 다음 결과를 씁니다.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

[Convert](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/convert/) 클래스는 PDF, SVG, JPEG, PNG 및 TIFF 출력에 대한 전용 메서드도 제공합니다. 내보내기 전에 프레젠테이션을 검사하거나 수정하거나 선택된 도우미에서 노출되지 않는 내보내기 옵션을 구성해야 하는 경우 전체 객체 모델을 사용하십시오. 형식별 워크플로우와 옵션은 [Convert Presentation](/cpp/convert-presentation/)를 참조하십시오.

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

모든 슬라이드를 하나의 결과에 순차적으로 추가하고 개별 슬라이드나 매핑을 선택하지 않아도 되는 경우에 이 도우미가 적합합니다. 선택적인 슬라이드 병합, 대상 마스터 또는 레이아웃 적용, 섹션 명시적 보존, 서로 다른 슬라이드 크기 조정이 필요하면 전체 객체 모델을 사용하십시오. 이러한 시나리오는 [Merge Presentations](/cpp/merge-presentation/)를 참조하십시오.

## **프레젠테이션 요소 순회**

[ForEach](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/) 클래스는 요청된 유형의 프레젠테이션 요소마다 콜백을 호출합니다. 중첩된 컬렉션 루프를 피할 수 있어 프레젠테이션 전체 검사나 서식 변경에 편리합니다.

다음 예제는 [ForEach::Slide](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/paragraph/), 그리고 [ForEach::Portion](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/portion/)을 사용해 해당 요소를 검사합니다:

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

기본적으로 프레젠테이션 전체 도형 및 텍스트 순회에는 일반 슬라이드, 마스터 슬라이드, 레이아웃 슬라이드가 포함됩니다. `includeNotes` 매개변수가 있는 오버로드를 사용하면 노트 슬라이드도 처리할 수 있습니다. 순회 순서, 조기 종료, 콜백 호출 전 필터링, 상세한 부모‑자식 제어가 중요한 경우에는 직접 컬렉션 루프를 사용하십시오.

## **도형 수집**

각 도형에 대해 콜백을 사용하는 대신 프레젠테이션 전체 도형 컬렉션이 필요하면 [Collect::Shapes](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/collect/shapes/)를 사용하십시오. 동일한 집합을 여러 번 필터링, 카운트 또는 처리할 때 유용합니다.

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

각 도형을 즉시 처리하고 수집된 결과를 유지할 필요가 없을 경우에는 대신 [ForEach::Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/shape/)를 사용하십시오.

## **프레젠테이션 콘텐츠 압축**

[Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) 클래스는 사용되지 않은 구조 요소를 제거하고 포함된 글꼴 데이터를 축소할 수 있습니다.

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)는 일반 슬라이드가 참조하지 않는 레이아웃 슬라이드를 제거합니다.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/)는 더 이상 사용되지 않는 마스터 슬라이드를 제거합니다.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/)는 포함된 글꼴에서 사용되지 않는 문자를 제거합니다.

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

레이아웃을 먼저 제거하고 그 후에 마스터를 제거하십시오. 레이아웃 정리 후 참조되지 않게 된 마스터도 제거할 수 있습니다. 원본 마스터, 레이아웃 또는 전체 포함 글꼴 데이터가 나중에 필요할 경우 최적화된 프레젠테이션을 새 파일에 저장하십시오. 자세한 내용은 [Slide Master](/cpp/slide-master/)와 [Embedded Font](/cpp/embedded-font/)를 참조하십시오.

## **FAQ**

**표준 객체 모델 대신 Low-code API를 언제 사용해야 하나요?**

표준 작업이 전체 파일이나 프레젠테이션에 적용되고 개별 요소에 대한 상세 제어가 필요하지 않을 때 Low-code 도우미를 사용하십시오. 특정 슬라이드 선택, 마스터·레이아웃 관계 제어, 중간 상태 검사 또는 도우미가 노출하지 않는 동작을 구성해야 할 경우 전체 객체 모델을 사용하십시오.

**Merger가 다른 파일 형식의 프레젠테이션을 결합할 수 있나요?**

아니요. [Merger::Process](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/merger/process/)는 입력 프레젠테이션이 동일한 형식이어야 합니다. 먼저 [Convert::AutoByExtension](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/convert/autobyextension/)와 같은 방법으로 입력 파일을 공통 형식으로 변환한 다음 결합하십시오.

**ForEach는 마스터, 레이아웃 및 노트 슬라이드를 처리합니까?**

[ForEach::Slide](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/slide/)는 일반 프레젠테이션 슬라이드만 순회합니다. 프레젠테이션 전체에 대한 [ForEach::Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/paragraph/), 및 [ForEach::Portion](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/portion/) 작업은 기본적으로 일반, 마스터, 레이아웃 슬라이드를 포함합니다. `includeNotes`를 `true`로 설정한 오버로드를 사용하면 노트 슬라이드도 포함됩니다.

**ForEach::Shape와 Collect::Shapes의 차이점은 무엇인가요?**

각 도형을 콜백을 통해 즉시 처리하려면 [ForEach::Shape](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/shape/)를 사용하십시오. 도형 컬렉션을 유지하고 나중에 필터링, 카운트 또는 여러 번 순회하려면 [Collect::Shapes](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/collect/shapes/)를 사용하십시오.

**Compress는 항상 프레젠테이션 파일을 작게 만들나요?**

반드시 그렇지는 않습니다. 결과는 프레젠테이션에 사용되지 않은 레이아웃, 사용되지 않은 마스터, 혹은 사용되지 않은 문자를 포함한 임베디드 글꼴이 있는지 여부에 따라 달라집니다. 해당 항목이 없으면 관련 [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) 작업이 파일 크기를 줄이지 않을 수 있습니다.

**ForEach 또는 Compress가 수행한 변경 사항은 자동으로 저장되나요?**

아니요. 이러한 도우미는 메모리 내에 로드된 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 객체에서 작동합니다. [ForEach](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/foreach/) 콜백에서 요소를 변경하거나 [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/)를 실행한 후에는 [Presentation::Save](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/save/)을 호출해 결과를 저장하십시오.

## **관련 문서**

- [Convert Presentation](/cpp/convert-presentation/)
- [Merge Presentations](/cpp/merge-presentation/)
- [Slide Master](/cpp/slide-master/)
- [Manage Text Box](/cpp/manage-textbox/)
- [Embedded Font](/cpp/embedded-font/)