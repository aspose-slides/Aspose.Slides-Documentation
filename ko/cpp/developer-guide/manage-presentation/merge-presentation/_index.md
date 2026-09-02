---
title: C++에서 프레젠테이션을 효율적으로 병합
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
description: "C++에서 슬라이드를 복제하고, 마스터와 레이아웃을 제어하며, 슬라이드 콘텐츠 크기를 조정하고, 섹션을 보존하며, 보호된 파일 또는 대용량 파일을 처리하여 PowerPoint 및 OpenDocument 프레젠테이션을 병합하는 방법을 배우세요."
---
## **개요**

Aspose.Slides for C++는 한 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/)에서 다른 프레젠테이션으로 슬라이드를 복제하여 병합합니다. 주요 작업은 [ISlideCollection::AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)이며, 이 작업을 통해 원본 슬라이드의 서식을 유지하거나 복제된 슬라이드를 대상 프레젠테이션의 마스터 또는 레이아웃에 연결할 수 있습니다.

이 문서에서는 가장 일반적인 병합 워크플로우를 다룹니다:

- 소스 서식을 유지하면서 모든 슬라이드 병합;
- 선택된 슬라이드 병합;
- 대상 프레젠테이션의 마스터 적용;
- 대상 프레젠테이션의 특정 레이아웃 적용;
- 병합 전에 서로 다른 슬라이드 크기 정규화;
- 복제된 슬라이드를 섹션에 추가;
- 여러 프레젠테이션을 하나의 엔드‑투‑엔드 워크플로우로 병합;
- 마스터, 리소스, 노트, 댓글, 미디어, 글꼴, 비밀번호, 대용량 파일 및 멀티스레딩 문제 처리.

## **슬라이드 복제가 마스터와 레이아웃에 미치는 영향**

슬라이드는 레이아웃과 마스터에서 대부분의 외관을 상속합니다. 따라서 선택한 복제 오버로드에 따라 병합된 슬라이드가 대상 프레젠테이션에 어떻게 통합되는지가 결정됩니다.

다음과 같은 방법으로 [ISlideCollection::AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)을 사용할 수 있습니다:

- `AddClone(sourceSlide)` — 원본 슬라이드의 레이아웃과 서식을 보존합니다. 필요한 경우 원본 마스터가 자동으로 대상 프레젠테이션에 복제될 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 추적하여 같은 원본 마스터를 사용하는 반복 슬라이드가 마스터를 중복 복제하지 않도록 합니다.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 복제된 슬라이드를 특정 대상 [IMasterSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslide/)에 연결합니다. Aspose.Slides는 레이아웃 유형이나 이름을 기준으로 해당 마스터 아래에 일치하는 레이아웃을 찾습니다.
- `AddClone(sourceSlide, destinationLayout)` — 복제된 슬라이드를 직접 특정 대상 [ILayoutSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/)에 연결합니다.

`AddClone` 오버로드에 전달되는 마스터 또는 레이아웃은 **대상** 프레젠테이션에 속해야 하며, 원본 프레젠테이션에 속해서는 안 됩니다.

## **전체 프레젠테이션 병합 및 소스 서식 유지**

가장 간단한 병합은 원본 프레젠테이션의 모든 슬라이드를 대상 프레젠테이션에 복사합니다. 이는 가져온 슬라이드가 원래 테마, 마스터 및 레이아웃 관계를 유지해야 할 때 적절한 선택입니다.

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

소스와 대상이 서로 다른 디자인을 사용할 경우 결과 프레젠테이션에 여러 마스터가 포함될 수 있습니다. 이는 소스 서식을 의도적으로 보존할 때 예상되는 동작입니다.

## **선택된 슬라이드 병합**

모든 슬라이드를 복제할 필요는 없습니다. 다음 예제는 원본 프레젠테이션에서 선택된 슬라이드 인덱스만 가져옵니다.

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

사용자 입력이나 외부 구성에서 가져온 경우 복제 전에 슬라이드 인덱스를 검증하십시오.

## **대상 마스터를 사용한 슬라이드 병합**

가져온 슬라이드가 이미 대상 프레젠테이션에 포함된 마스터를 따라야 할 경우 [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 오버로드를 사용하십시오.

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

Aspose.Slides는 소스 레이아웃의 유형 또는 이름과 일치하는 레이아웃을 지정된 마스터 아래에서 선택합니다. 적절한 레이아웃이 없고 `allowCloneMissingLayout`이 `true`이면 소스 레이아웃이 복제되어 슬라이드를 추가할 수 있게 됩니다. `false`이면 [PptxEditException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/details_pptxeditexception/)가 발생합니다.

추가 레이아웃을 대상 마스터에 도입하지 않고 병합을 실패시키고 싶다면 `false`를 사용하십시오.

## **특정 대상 레이아웃을 사용한 슬라이드 병합**

가져온 슬라이드가 정확히 어떤 대상 레이아웃을 사용해야 하는지 알고 있다면 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/) 오버로드를 사용하십시오.

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

대상 레이아웃을 적용하면 상속된 레이아웃 관계가 변경되지만 소스 슬라이드 내용 자체가 재디자인되는 것은 아닙니다. 소스와 대상 레이아웃의 플레이스홀더 구조가 다르면 결과를 검토하여 상속된 서식과 플레이스홀더 동작이 적절한지 확인하십시오.

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

슬라이드 크기가 다른 프레젠테이션도 병합할 수 있지만, 다른 슬라이드 크기를 가진 프레젠테이션에 슬라이드를 복제한다 해도 내용이 자동으로 새로운 캔버스에 맞게 재디자인되지는 않습니다. 따라서 형태가 이동되거나, 비정상적으로 스케일되거나, 보이는 슬라이드 영역 밖에 위치할 수 있습니다.

실용적인 방법은 복제하기 전에 소스 프레젠테이션의 크기를 조정하는 것입니다. [SlideSize::SetSize](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidesize/setsize/) 메서드는 슬라이드 크기를 변경하면서 기존 콘텐츠를 스케일링할 수 있습니다. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidesizescaletype/)은 요청된 크기에 맞게 콘텐츠를 스케일합니다.

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

크기 조정은 메모리 내의 소스 프레젠테이션 객체를 변경합니다. 다른 작업에 원본 프레젠테이션을 그대로 두어야 한다면 별도의 인스턴스를 열어 병합에 사용하십시오.

## **프레젠테이션 섹션에 슬라이드 병합**

기본 슬라이드 복제 루프는 원본 프레젠테이션의 섹션 계층 구조를 재현하지 않습니다. 섹션이 결과에 중요하다면 대상 프레젠테이션에서 섹션을 생성하거나 선택한 뒤 [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)을 사용해 슬라이드를 명시적으로 해당 섹션에 복제하십시오.

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

복제된 슬라이드는 지정된 대상 섹션에 추가됩니다. 여러 소스 섹션을 보존하려면 [Presentation::get_Sections](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_sections/)를 열거하고, 각 소스 섹션의 현재 슬라이드를 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isection/getslideslistofsection/)로 가져온 다음, 대상에 섹션을 재생성하고 반환된 슬라이드를 해당 대상 섹션에 복제하십시오. 전체 섹션 열거 예제는 [슬라이드 섹션 관리](/slides/ko/cpp/slide-section/)를 참고하십시오(빈 섹션 및 구조 변화 포함).

## **여러 프레젠테이션을 안전하게 병합**

다음 엔드‑투‑엔드 예제는 첫 번째 프레젠테이션을 대상으로 사용하고, 각 추가 소스의 슬라이드 크기를 정규화하며, 복사되는 동안만 각 소스를 열고 최종 파일을 한 번만 저장합니다.

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

이는 가져온 슬라이드의 소스 서식을 보존하는 데 유용한 기준선입니다. 출력에 단일 대상 테마가 필요하면 앞에서 소개한 대상‑마스터 또는 대상‑레이아웃 오버로드를 사용해 `AddClone(slide)` 호출을 교체하십시오.

## **실무 고려사항**

### **마스터, 레이아웃 및 서식 정확도**

기본 슬라이드 복제는 필요한 소스 마스터를 자동으로 대상 프레젠테이션에 가져올 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 내부 레지스트리에 기록하여 동일한 마스터가 여러 번 복제되지 않도록 합니다. 수동으로 복제한 마스터는 해당 레지스트리에 기록되지 않으므로, 마스터 구조에 대한 명시적 제어가 필요하지 않은 한 사전 복제를 피하십시오.

동일한 이름을 가진 두 마스터나 레이아웃이 시각적으로 동일하다고 가정하지 마십시오. 기업 템플릿이 최종 외관을 제어해야 한다면 대상 마스터 또는 레이아웃을 명시적으로 선택하고 병합 후 결과를 검증하십시오.

### **노트 및 댓글**

슬라이드와 연결된 발표자 노트와 슬라이드 댓글은 슬라이드가 복제될 때 함께 복사됩니다. Aspose.Slides는 또한 [프레젠테이션 노트](/slides/ko/cpp/presentation-notes/)와 [프레젠테이션 댓글](/slides/ko/cpp/presentation-comments/)에 대한 전용 API를 제공합니다.

노트 페이지 서식이 중요한 경우, 노트 마스터는 프레젠테이션 수준 객체이므로 소스 파일 간에 차이가 있을 수 있음을 염두에 두고 병합된 프레젠테이션을 확인하십시오. 검토 워크플로우에서는 다른 작성자 또는 템플릿에서 결합한 후 댓글 작성자와 스레드 형식 댓글을 검증하십시오.

### **이미지, 오디오, 비디오, OLE 객체 및 외부 링크**

슬라이드는 이미지, 포함된 오디오, 포함된 비디오 및 OLE 데이터와 같은 프레젠테이션 수준 리소스를 참조할 수 있습니다. 슬라이드 자체를 복제하여 Aspose.Slides가 리소스와의 관계를 유지하도록 하십시오.

임베드된 리소스와 연결된 리소스는 다르게 취급해야 합니다. 연결된 오디오, 비디오, OLE 객체 또는 하이퍼링크는 외부 대상에 종속되어 있으며, 슬라이드를 복제한다고 외부 링크가 임베드된 콘텐츠로 전환되지는 않습니다. 병합된 프레젠테이션이 열릴 환경에서 연결된 리소스 경로와 URL을 테스트하십시오.

Aspose.Slides는 자동 복제된 마스터를 추적하지만, 이는 서로 다른 소스 프레젠테이션에서 동일한 바이너리 리소스가 항상 중복 제거된다는 일반적인 보장을 의미하지는 않습니다. 출력 파일 크기가 중요하다면 병합된 패키지를 검사하고 결과를 측정하여 명시적으로 중복 제거 여부를 확인하십시오.

### **임베드된 글꼴 및 글꼴 가용성**

글꼴은 프레젠테이션 수준에서 관리됩니다. 타인 기기에서도 타이포그래피 일관성을 유지해야 한다면 슬라이드 복제만으로 모든 필요한 글꼴이 대상 환경에 존재한다고 가정하지 마십시오. [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsmanager/getembeddedfonts/)를 사용해 임베드된 글꼴을 검사하고, [프레젠테이션에 글꼴 임베드](/slides/ko/cpp/embedded-font/)에 설명된 대로 명시적으로 임베드하십시오.

또한 소스 파일에 사용된 글꼴을 임베드할 권한이 있는지도 확인하십시오. 글꼴 라이선스가 임베드를 제한할 수 있습니다.

### **비밀번호로 보호된 프레젠테이션**

비밀번호로 보호된 소스는 슬라이드를 복제하기 전에 성공적으로 열어야 합니다. 비밀번호는 [LoadOptions::set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/)를 통해 제공합니다.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

암호화된 소스를 연다고 해서 동일한 보호가 대상 프레젠테이션에 자동으로 적용되는 것은 아닙니다. 필요에 따라 출력 보호를 별도로 구성하십시오.

### **대용량 프레젠테이션 및 메모리 사용**

고해상도 이미지, 오디오, 비디오 또는 기타 대용량 바이너리 객체를 포함한 대형 프레젠테이션은 상당한 메모리를 소비할 수 있습니다. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/)는 BLOB 처리 및 임시 파일 사용을 제어합니다. 대용량 파일 전략은 [프레젠테이션 BLOB 관리](/slides/ko/cpp/manage-blob/)를 참고하십시오.

대용량 파일의 경우 가능한 파일 경로에서 로드하고, 각 소스 프레젠테이션을 병합이 끝나는 즉시 해제하며, 워크플로우에 체크포인트가 필요하지 않은 한 중간 결과를 반복 저장하지 마십시오.

### **스레드 안전성**

동일한 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 여러 스레드에서 동시에 로드, 수정, 저장 또는 복제하지 마십시오. 각 프레젠테이션 인스턴스는 하나의 병합 작업에만 사용하도록 제한하십시오. 독립적인 작업을 병렬화하려면 별도의 프레젠테이션 인스턴스를 사용하고, [Aspose.Slides 멀티스레딩 가이드](/slides/ko/cpp/multithreading/)를 따르십시오.

## **자주 묻는 질문**

**각 소스 프레젠테이션의 원래 디자인을 유지하려면 어떻게 해야 하나요?**

대상 마스터나 레이아웃을 지정하지 않고 [AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)을 사용하십시오. Aspose.Slides는 필요 시 소스 마스터를 자동으로 복제합니다.

**가져온 슬라이드가 대상 테마를 사용하도록 하려면 어떻게 해야 하나요?**

대상 마스터를 받는 오버로드를 사용하십시오. 소스가 아닌 대상 프레젠테이션의 마스터를 전달하면 Aspose.Slides가 각 소스 슬라이드를 해당 마스터 아래의 적절한 레이아웃에 매핑하려고 시도합니다.

**대상 마스터 대신 특정 대상 레이아웃을 사용해야 할 때는 언제인가요?**

모든 가져온 슬라이드가 하나의 알려진 레이아웃을 사용해야 할 경우 특정 레이아웃을 사용하십시오. 소스 레이아웃 유형이나 이름에 따라 마스터의 여러 레이아웃 중에서 선택하도록 하려면 마스터를 사용하십시오.

**다른 슬라이드 크기를 가진 프레젠테이션을 병합할 수 있나요?**

가능하지만 슬라이드 내용이 대상 차원에 맞게 자동으로 재디자인되지는 않습니다. 예측 가능한 배치를 원한다면 [SlideSize::SetSize](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidesize/setsize/)와 [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slidesizescaletype/)을 사용해 소스 프레젠테이션을 먼저 크기 조정하십시오.

**PPT, PPTX 및 ODP 프레젠테이션을 하나의 파일로 병합할 수 있나요?**

예. 각 소스 프레젠테이션을 로드하고, 필요한 슬라이드를 하나의 대상에 복제한 뒤 지원되는 출력 형식으로 저장하십시오. 프레젠테이션 형식마다 지원하는 기능 세트가 다르므로 교차 형식 병합 후 복잡한 콘텐츠를 확인하십시오. 자세한 내용은 [지원되는 파일 형식](/slides/ko/cpp/supported-file-formats/)을 참고하십시오.

**소스 섹션이 자동으로 보존되나요?**

슬라이드만 복제하는 기본 루프에서는 보존되지 않습니다. 섹션 구조를 유지하려면 대상에 섹션을 재생성하고, 섹션 오버로드가 있는 [AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecollection/addclone/)을 사용하십시오.

**발표자 노트와 댓글이 보존되나요?**

복제된 슬라이드와 함께 복사됩니다. 노트 마스터 스타일링, 댓글 작성자 또는 스레드형 리뷰 데이터에 의존하는 워크플로우의 경우, 이러한 프레젠테이션 수준 구조가 슬라이드 수준 콘텐츠와 함께 병합된 결과를 반드시 검증하십시오.

**오디오, 비디오, OLE 객체 및 하이퍼링크는 어떻게 처리되나요?**

임베드된 콘텐츠는 복제된 슬라이드의 리소스 관계와 함께 전달됩니다. 외부 링크는 여전히 외부에 남아 있으므로, 병합 후에도 해당 파일이나 URL이 접근 가능해야 합니다.

**모든 소스에서 임베드된 글꼴이 병합된 프레젠테이션에 보장되나요?**

슬라이드 복제만으로 글꼴 배포를 보장하지 마십시오. 대상에 임베드된 글꼴을 검사하고, 타이포그래피가 중요한 경우 글꼴 임베드 또는 외부 글꼴 가용성을 명시적으로 관리하십시오.

**비밀번호가 걸린 파일을 어떻게 병합하나요?**

[LoadOptions::set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/)로 올바른 비밀번호를 제공해 파일을 열고, 슬라이드를 정상적으로 복제하십시오. 출력 보호는 별도로 구성해야 합니다.

**매우 큰 프레젠테이션은 어떻게 처리해야 하나요?**

BLOB 관리 옵션을 사용해 대용량 바이너리 객체를 제어하고, 가능한 경우 파일 경로에서 로드하며, 병합이 끝나는 즉시 소스 프레젠테이션을 해제하고, 필요할 때만 최종 결과를 저장하십시오.

**여러 스레드에서 슬라이드를 병합할 수 있나요?**

하나의 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 여러 스레드에서 동시에 사용하지 마십시오. 각 병합 작업은 자체 프레젠테이션 인스턴스로 격리해야 합니다.