---
title: C++에서 프레젠테이션을 효율적으로 병합하기
linktitle: 프레젠테이션 병합
type: docs
weight: 40
url: /ko/cpp/merge-presentation/
keywords:
- PowerPoint 병합
- 프레젠테이션 병합
- 슬라이드 병합
- PPT 병합
- PPTX 병합
- ODP 병합
- PowerPoint 결합
- 프레젠테이션 결합
- 슬라이드 결합
- PPT 결합
- PPTX 결합
- ODP 결합
- C++
- Aspose.Slides
description: "C++에서 슬라이드를 복제하고, 마스터와 레이아웃을 제어하며, 슬라이드 콘텐츠 크기를 조정하고, 섹션을 보존하며, 보호된 파일이나 대용량 파일을 처리하여 PowerPoint 및 OpenDocument 프레젠테이션을 병합하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for C++는 한 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)에서 다른 프레젠테이션으로 슬라이드를 복제하여 프레젠테이션을 병합합니다. 주요 작업은 [ISlideCollection::AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)이며, 원본 슬라이드의 서식을 보존하거나 복제된 슬라이드를 대상 프레젠테이션의 마스터 또는 레이아웃에 첨부할 수 있습니다.

이 문서에서는 가장 일반적인 병합 작업 흐름을 다룹니다:
- 원본 서식을 보존하면서 모든 슬라이드 병합;
- 선택한 슬라이드 병합;
- 대상 프레젠테이션의 마스터 적용;
- 대상 프레젠테이션의 특정 레이아웃 적용;
- 병합 전에 서로 다른 슬라이드 크기 정규화;
- 복제된 슬라이드를 섹션에 추가;
- 여러 프레젠테이션을 하나의 엔드투엔드 워크플로우로 병합;
- 마스터, 리소스, 메모, 댓글, 미디어, 글꼴, 비밀번호, 대용량 파일, 멀티스레딩 문제를 처리합니다.

## **슬라이드 복제가 마스터 및 레이아웃에 미치는 영향**

슬라이드는 레이아웃과 마스터로부터 외관의 대부분을 상속합니다. 따라서 선택한 복제 오버로드에 따라 병합된 슬라이드가 대상 프레젠테이션에 어떻게 통합되는지가 결정됩니다.

다음과 같이 [ISlideCollection::AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)을 사용할 수 있습니다:
- `AddClone(sourceSlide)` — 원본 슬라이드의 레이아웃과 서식을 보존합니다. 필요할 경우 원본 마스터가 자동으로 대상 프레젠테이션에 복제될 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 추적하여 동일한 원본 마스터를 사용하는 반복 슬라이드가 마스터를 계속 복제하지 않도록 합니다.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 복제된 슬라이드를 특정 대상 [IMasterSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslide/)에 연결합니다. Aspose.Slides는 레이아웃 유형이나 이름으로 해당 마스터 아래에서 일치하는 레이아웃을 찾습니다.
- `AddClone(sourceSlide, destinationLayout)` — 복제된 슬라이드를 직접 특정 대상 [ILayoutSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/)에 연결합니다.

`AddClone` 오버로드에 전달되는 마스터 또는 레이아웃은 원본 프레젠테이션이 아니라 **대상** 프레젠테이션에 속해야 합니다.

## **전체 프레젠테이션 병합 및 원본 서식 보존**

가장 간단한 병합은 원본 프레젠테이션의 모든 슬라이드를 대상 프레젠테이션에 복사합니다. 가져온 슬라이드가 원래 테마, 마스터 및 레이아웃 관계를 유지해야 할 때 적합한 선택입니다.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

원본과 대상이 서로 다른 디자인을 사용하는 경우 결과 프레젠테이션에 여러 마스터가 포함될 수 있습니다. 이는 원본 서식을 의도적으로 보존할 때 예상되는 동작입니다.

## **선택 슬라이드 병합**

모든 슬라이드를 복제할 필요는 없습니다. 다음 예제는 원본 프레젠테이션에서 선택한 슬라이드 인덱스만 가져옵니다.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

사용자 입력이나 외부 구성에서 가져온 경우 복제하기 전에 슬라이드 인덱스를 검증하세요.

## **대상 마스터 사용하여 슬라이드 병합**

가져온 슬라이드가 이미 대상 프레젠테이션에 포함된 마스터를 따르도록 해야 할 때는 [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 오버로드를 사용합니다.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides는 지정된 마스터 아래에서 원본 레이아웃의 유형이나 이름과 일치하는 적절한 레이아웃을 선택합니다. 적합한 레이아웃이 없고 `allowCloneMissingLayout`가 `true`이면 원본 레이아웃을 복제하여 슬라이드를 추가할 수 있습니다. `false`인 경우 [PptxEditException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/details_pptxeditexception/)이 발생합니다.

대상 마스터에 추가 레이아웃을 만들지 않고 병합이 실패하도록 하려면 `false`를 사용하세요.

## **특정 대상 레이아웃 사용하여 슬라이드 병합**

가져온 슬라이드가 사용할 정확한 대상 레이아웃을 알고 있을 때는 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 오버로드를 사용합니다.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

대상 레이아웃을 적용하면 상속된 레이아웃 관계가 변경되지만 원본 슬라이드 콘텐츠가 재설계되지는 않습니다. 원본과 대상 레이아웃의 플레이스홀더 구조가 다르면 결과를 확인하여 상속된 서식 및 플레이스홀더 동작이 적절한지 검증하세요.

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

슬라이드 크기가 다른 프레젠테이션도 병합할 수 있지만, 슬라이드를 다른 크기의 프레젠테이션에 복제하면 콘텐츠가 자동으로 새 캔버스에 맞게 재설계되지 않습니다. 따라서 도형이 이동하거나 예상치 못하게 스케일링되거나 보이는 슬라이드 영역 밖에 나타날 수 있습니다.

실용적인 방법은 복제하기 전에 원본 프레젠테이션의 크기를 조정하는 것입니다. [SlideSize::SetSize](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidesize/setsize/) 메서드는 슬라이드 차원을 변경하면서 기존 내용을 스케일링할 수 있습니다. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidesizescaletype/)은 요청된 크기에 맞게 내용을 스케일링합니다.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

크기 조정은 메모리에서 원본 프레젠테이션 객체를 변경합니다. 다른 작업을 위해 원본 프레젠테이션을 그대로 유지해야 하면 병합을 위해 별도의 인스턴스를 열어야 합니다.

## **슬라이드를 프레젠테이션 섹션에 병합**

기본 슬라이드 복제 루프는 원본 프레젠테이션의 섹션 계층 구조를 재생성하지 않습니다. 출력에서 섹션이 중요하다면 대상 프레젠테이션에서 섹션을 만들거나 선택하고 [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)을 사용해 슬라이드를 명시적으로 복제하세요.

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

복제된 슬라이드는 지정된 대상 섹션에 추가됩니다. 여러 원본 섹션을 보존하려면 대상에 해당 섹션을 재생성하고 각 원본 슬라이드를 해당 대상 섹션에 매핑하세요.

## **다중 프레젠테이션 안전하게 병합**

다음 엔드투엔드 예제는 첫 번째 프레젠테이션을 대상으로 사용하고, 각 추가 원본의 슬라이드 크기를 정규화하며, 복사 중에만 각 원본을 열어두고 최종 파일을 한 번만 저장합니다.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

이 예제는 가져온 슬라이드의 원본 서식을 보존하기 위한 유용한 기준선입니다. 출력에 단일 대상 테마를 사용해야 하면, 앞에서 보여준 적절한 대상 마스터 또는 대상 레이아웃 오버로드로 단순 `AddClone(slide)` 호출을 교체하세요.

## **실용적 고려 사항**

### **마스터, 레이아웃 및 서식 정확도**

기본 슬라이드 복제는 필요한 원본 마스터를 자동으로 대상 프레젠테이션으로 가져올 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 중복 복제하지 않도록 내부 레지스트리를 유지합니다. 수동으로 복제한 마스터는 해당 레지스트리에 추적되지 않으므로 마스터 구조에 대한 명시적 제어가 필요하지 않은 한 미리 복제하는 것을 피하세요.

같은 이름을 가진 두 마스터 또는 레이아웃이 시각적으로 동일하다고 가정하지 마세요. 기업 템플릿이 최종 모양을 제어해야 한다면, 대상 마스터 또는 레이아웃을 명시적으로 선택하고 병합 후 결과를 검증하세요.

### **메모 및 댓글**

발표자 메모와 슬라이드 댓글은 슬라이드 콘텐츠와 연결되어 있으며 슬라이드를 복제할 때 복사됩니다. Aspose.Slides는 또한 [presentation notes](https://docs.aspose.com/slides/ko/cpp/presentation-notes/) 및 [presentation comments](https://docs.aspose.com/slides/ko/cpp/presentation-comments/)에 대한 전용 API를 제공합니다.

노트 페이지 서식이 중요하다면, 메모 마스터가 프레젠테이션 수준 객체이며 원본 파일마다 다를 수 있으므로 병합된 프레젠테이션을 확인하세요. 검토 워크플로우에서는 다른 작성자나 템플릿의 파일을 결합한 후 댓글 작성자와 스레드형 댓글도 확인하세요.

### **이미지, 오디오, 비디오, OLE 객체 및 외부 링크**

슬라이드는 이미지, 포함된 오디오, 포함된 비디오, OLE 데이터와 같은 프레젠테이션 수준 리소스를 참조할 수 있습니다. 보이는 도형만 복사하지 말고 슬라이드 자체를 복제하여 Aspose.Slides가 슬라이드와 리소스 간의 관계를 유지하도록 하세요.

임베디드 리소스와 링크된 리소스는 별도로 처리해야 합니다. 링크된 오디오, 비디오, OLE 객체 또는 하이퍼링크는 외부 대상에 종속된 상태이며, 슬라이드를 복제해도 외부 링크가 임베디드 콘텐츠로 바뀌지는 않습니다. 병합된 프레젠테이션이 열릴 환경에서 링크된 리소스 경로와 URL을 테스트하세요.

Aspose.Slides는 자동 복제된 마스터를 명시적으로 추적하지만, 이는 서로 무관한 원본 프레젠테이션의 동일한 바이너리 리소스가 항상 중복 제거된다는 일반적인 보증으로 간주해서는 안 됩니다. 출력 파일 크기가 중요하면 암시적 중복 제거에 의존하지 말고 병합된 패키지를 조사하고 결과를 측정하세요.

### **임베디드 글꼴 및 글꼴 가용성**

글꼴은 프레젠테이션 수준에서 관리됩니다. 타이포그래피가 기기 간에 일관되어야 한다면 슬라이드 복제만으로 대상 환경에 모든 필요한 글꼴이 제공된다고 가정하지 마세요. [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/getembeddedfonts/)을 사용해 임베디드 글꼴을 확인하고 [Embed Fonts in Presentations](https://docs.aspose.com/slides/ko/cpp/embedded-font/)에 설명된 대로 임베딩을 명시적으로 관리할 수 있습니다.

또한 원본 파일에 사용된 글꼴을 임베드할 수 있는지 확인하세요. 글꼴 라이선스는 임베딩을 제한할 수 있습니다.

### **암호 보호된 프레젠테이션**

암호로 보호된 원본은 슬라이드를 복제하기 전에 성공적으로 열어야 합니다. 비밀번호는 [LoadOptions::set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/)를 통해 제공하세요.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

암호화된 원본을 열었다고 해서 대상 프레젠테이션에 동일한 보호가 자동으로 적용되는 것은 아닙니다. 필요에 따라 출력 보호를 별도로 구성하세요.

### **대용량 프레젠테이션 및 메모리 사용**

고해상도 이미지, 오디오, 비디오 또는 기타 대용량 바이너리 객체를 포함하는 대용량 프레젠테이션은 많은 메모리를 차지할 수 있습니다. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/)는 BLOB 처리 및 임시 파일 사용에 대한 제어를 제공합니다. 대용량 파일 전략은 [Manage Presentation BLOBs](https://docs.aspose.com/slides/ko/cpp/manage-blob/)를 참조하세요.

대용량 파일의 경우 가능하면 파일 경로에서 로드하고, 병합이 끝난 즉시 각 원본 프레젠테이션을 해제하며, 워크플로우가 체크포인트를 요구하지 않는 한 중간 결과를 반복 저장하지 마세요.

### **스레드 안전성**

여러 스레드에서 같은 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 동시에 로드, 수정, 저장 또는 복제하지 마세요. 각 프레젠테이션 인스턴스는 하나의 병합 작업에만 사용하세요. 독립적인 작업을 병렬화할 경우 별도의 프레젠테이션 인스턴스를 사용하고 [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/ko/cpp/multithreading/)를 따르세요.

## **FAQ**

**원본 프레젠테이션의 원래 디자인을 유지하려면 어떻게 해야 하나요?**

[`AddClone(sourceSlide)`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)를 사용하고 대상 마스터나 레이아웃을 지정하지 않으세요. Aspose.Slides는 가져온 슬라이드에 필요할 경우 원본 마스터를 자동으로 복제할 수 있습니다.

**가져온 슬라이드가 대상 테마를 사용하도록 하려면 어떻게 해야 하나요?**

대상 마스터를 받는 오버로드를 사용하세요. 원본이 아닌 대상 프레젠테이션의 마스터를 전달합니다. Aspose.Slides는 해당 마스터 아래에서 각 원본 슬라이드에 적절한 레이아웃을 매핑하려고 시도합니다.

**대상 마스터 대신 특정 대상 레이아웃을 사용해야 하는 경우는 언제인가요?**

모든 가져온 슬라이드가 하나의 알려진 레이아웃을 사용해야 할 때는 특정 레이아웃을 사용하세요. 원본 레이아웃 유형이나 이름에 따라 해당 마스터의 레이아웃 중에서 선택하도록 하려면 마스터를 사용합니다.

**다른 슬라이드 크기를 가진 프레젠테이션을 병합할 수 있나요?**

예, 하지만 슬라이드 콘텐츠는 대상 차원에 맞게 자동으로 재설계되지 않습니다. 예측 가능한 배치가 필요하면 먼저 원본 프레젠테이션을 [SlideSize::SetSize](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidesize/setsize/) 및 [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidesizescaletype/)으로 크기를 조정하세요.

**PPT, PPTX, ODP 프레젠테이션을 하나의 파일로 병합할 수 있나요?**

예. 각 원본 프레젠테이션을 로드하고 필요한 슬라이드를 하나의 대상에 복제한 뒤 지원되는 출력 형식으로 저장합니다. 프레젠테이션 형식마다 지원되는 기능이 정확히 동일하지 않으므로 교차 형식 병합 후 복잡한 콘텐츠를 검증하세요. [Supported File Formats](https://docs.aspose.com/slides/ko/cpp/supported-file-formats/)을 확인하세요.

**원본 섹션이 자동으로 보존되나요?**

슬라이드만 복제하는 기본 루프에서는 자동으로 보존되지 않습니다. 필요한 섹션을 대상에 재생성하고 섹션 구조를 보존해야 할 경우 [AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)의 섹션 오버로드를 사용하세요.

**발표자 메모와 댓글이 보존되나요?**

복제된 슬라이드와 함께 복사됩니다. 메모 마스터 스타일링, 댓글 작성자, 스레드형 검토 데이터에 의존하는 워크플로우에서는 병합 결과를 검증해야 합니다. 이러한 시나리오는 프레젠테이션 수준 구조와 슬라이드 수준 콘텐츠 모두를 포함합니다.

**오디오, 비디오, OLE 객체 및 하이퍼링크는 어떻게 처리되나요?**

임베디드 콘텐츠는 복제된 슬라이드의 리소스 관계의 일부로 포함됩니다. 외부 링크는 외부에 남아 있으므로 병합 후에도 대상 파일이나 URL이 여전히 접근 가능해야 합니다.

**모든 원본의 임베디드 글꼴이 병합된 프레젠테이션에 보장되나요?**

글꼴 배포를 위해 슬라이드 복제만 의존하지 마세요. 타이포그래피가 중요할 경우 대상의 임베디드 글꼴을 확인하고 글꼴 임베딩 또는 외부 글꼴 가용성을 명시적으로 관리하세요.

**암호 보호된 파일을 어떻게 병합하나요?**

올바른 [LoadOptions::set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/)으로 열고 슬라이드를 일반적으로 복제하세요. 출력 보호는 별도로 구성됩니다.

**매우 큰 프레젠테이션은 어떻게 처리해야 하나요?**

대용량 바이너리 객체가 메모리 사용을 지배할 때는 BLOB 관리를 사용하고, 매우 큰 파일은 파일 경로 로드를 선호하며, 원본 프레젠테이션은 즉시 해제하고, 필요할 때만 최종 결과를 저장하세요.

**여러 스레드에서 슬라이드를 병합할 수 있나요?**

여러 스레드에서 하나의 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 동시에 사용하지 마세요. 각 병합 작업은 자체 프레젠테이션 인스턴스로 격리하세요.