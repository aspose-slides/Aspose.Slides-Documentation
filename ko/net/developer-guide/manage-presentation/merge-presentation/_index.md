---
title: .NET에서 프레젠테이션 효율적으로 병합
linktitle: 프레젠테이션 병합
type: docs
weight: 40
url: /ko/net/merge-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "PowerPoint 및 OpenDocument 프레젠테이션을 .NET에서 슬라이드 복제, 마스터 및 레이아웃 제어, 슬라이드 콘텐츠 크기 조정, 섹션 유지, 보호된 파일이나 대용량 파일 처리 등을 통해 병합하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for .NET 은 한 [프레젠테이션](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/)에서 슬라이드를 복제하여 다른 프레젠테이션에 병합합니다. 주요 작업은 [ISlideCollection.AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/addclone/)이며, 원본 슬라이드의 서식을 유지하거나 복제된 슬라이드를 대상 프레젠테이션의 마스터 또는 레이아웃에 연결할 수 있습니다.

이 문서에서는 가장 일반적인 병합 워크플로를 다룹니다:

- 모든 슬라이드를 원본 서식을 유지하면서 병합
- 선택된 슬라이드만 병합
- 대상 프레젠테이션의 마스터 적용
- 대상 프레젠테이션의 특정 레이아웃 적용
- 병합 전에 서로 다른 슬라이드 크기 정규화
- 복제된 슬라이드를 섹션에 추가
- 하나의 엔드‑투‑엔드 워크플로에서 여러 프레젠테이션 병합
- 마스터, 리소스, 노트, 댓글, 미디어, 폰트, 비밀번호, 대용량 파일, 멀티스레딩 문제 처리

## **슬라이드 복제가 마스터 및 레이아웃에 미치는 영향**

슬라이드는 레이아웃과 마스터에서 많은 외관을 상속받습니다. 따라서 선택한 복제 오버로드에 따라 병합된 슬라이드가 대상 프레젠테이션에 어떻게 통합되는지가 결정됩니다.

다음 중 하나의 방법으로 [ISlideCollection.AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/addclone/)을 사용하십시오:

- `AddClone(sourceSlide)` — 원본 슬라이드의 레이아웃과 서식을 유지합니다. 필요 시 원본 마스터가 자동으로 대상 프레젠테이션에 복제됩니다. Aspose.Slides는 자동 복제된 마스터를 추적하여 동일한 마스터를 사용하는 반복 슬라이드가 마스터를 여러 번 복제하지 않도록 합니다.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — 복제된 슬라이드를 특정 대상 [IMasterSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslide/)에 연결합니다. Aspose.Slides는 해당 마스터 아래에서 레이아웃 유형이나 이름으로 일치하는 레이아웃을 찾습니다.
- `AddClone(sourceSlide, destinationLayout)` — 복제된 슬라이드를 직접 특정 대상 [ILayoutSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/)에 연결합니다.

`AddClone` 오버로드에 전달되는 마스터 또는 레이아웃은 **대상** 프레젠테이션에 속해야 하며, 원본 프레젠테이션에 속해서는 안 됩니다.

## **전체 프레젠테이션 병합 및 원본 서식 유지**

가장 간단한 병합은 원본 프레젠테이션의 모든 슬라이드를 대상 프레젠테이션에 복사하는 것입니다. 이는 가져온 슬라이드가 원래 테마, 마스터 및 레이아웃 관계를 유지해야 할 때 적합한 선택입니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

원본과 대상가 서로 다른 디자인을 사용하면 결과 프레젠테이션에 여러 마스터가 포함될 수 있습니다. 이는 원본 서식을 의도적으로 유지할 때 기대되는 동작입니다.

## **선택된 슬라이드 병합**

모든 슬라이드를 복제할 필요는 없습니다. 다음 예제는 원본 프레젠테이션에서 선택된 슬라이드 인덱스만 가져옵니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

사용자 입력이나 외부 구성에서 슬라이드 인덱스를 가져오는 경우 복제하기 전에 유효성을 검사하십시오.

## **대상 마스터 사용하여 슬라이드 병합**

가져온 슬라이드가 이미 대상 프레젠테이션에 속한 마스터를 따라야 할 경우 [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/addclone/) 오버로드를 사용하십시오.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides는 원본 레이아웃의 유형이나 이름과 일치하는 적절한 레이아웃을 해당 마스터 아래에서 선택합니다. 적합한 레이아웃이 없고 `allowCloneMissingLayout`이 `true`이면 원본 레이아웃이 복제되어 슬라이드를 추가할 수 있게 됩니다. `false`이면 [PptxEditException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxeditexception/)이 발생합니다.

추가 레이아웃을 대상 마스터에 도입하고 싶지 않을 때는 `false`를 사용하여 병합이 실패하도록 하십시오.

## **특정 대상 레이아웃 사용하여 슬라이드 병합**

가져온 슬라이드가 정확히 어떤 대상 레이아웃을 사용해야 하는지 알고 있을 경우 [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/addclone/) 오버로드를 사용하십시오.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

대상 레이아웃을 적용하면 상속된 레이아웃 관계가 변경되지만 원본 슬라이드 내용 자체가 재설계되지는 않습니다. 원본과 대상 레이아웃의 자리표시자 구조가 다르면, 결과를 검사하여 상속된 서식과 자리표시자 동작이 적절한지 확인하십시오.

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

슬라이드 크기가 다른 프레젠테이션도 병합할 수 있지만, 다른 슬라이드 크기를 가진 프레젠테이션에 슬라이드를 복제한다고 해서 내용이 자동으로 새로운 캔버스에 맞게 재설계되는 것은 아닙니다. 따라서 도형이 이동하거나 크기가 비정상적으로 변하거나 슬라이드 가시 영역 밖에 표시될 수 있습니다.

실용적인 방법은 복제하기 전에 원본 프레젠테이션의 크기를 조정하는 것입니다. [SlideSize.SetSize](https://reference.aspose.com/slides/ko/net/aspose.slides/slidesize/setsize/) 메서드는 슬라이드 크기를 변경하면서 기존 콘텐츠를 스케일링할 수 있습니다. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ko/net/aspose.slides/slidesizescaletype/) 은 요청된 크기에 맞게 콘텐츠를 스케일링합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

크기 조정은 메모리 내 원본 프레젠테이션 객체를 변경합니다. 다른 작업을 위해 원본 프레젠테이션을 그대로 두어야 한다면, 병합을 위해 별도의 인스턴스를 열어 사용하십시오.

## **프레젠테이션 섹션에 슬라이드 병합**

기본 슬라이드 복제 루프는 원본 프레젠테이션의 섹션 계층 구조를 재생성하지 않습니다. 출력에 섹션이 중요하다면 대상 프레젠테이션에서 섹션을 생성하거나 선택한 뒤, [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/addclone/)을 사용해 슬라이드를 명시적으로 해당 섹션에 복제하십시오.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

복제된 슬라이드는 지정된 대상 섹션에 추가됩니다. 여러 원본 섹션을 보존하려면 대상에 그 섹션들을 재생성하고 각 원본 슬라이드를 해당 대상 섹션에 매핑하십시오.

## **여러 프레젠테이션을 안전하게 병합**

다음 엔드‑투‑엔드 예제는 첫 번째 프레젠테이션을 대상으로 사용하고, 각 추가 원본의 슬라이드 크기를 정규화하며, 복사 중에만 원본을 열고, 마지막에 한 번만 파일을 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

이는 가져온 슬라이드의 원본 서식을 유지하는 유용한 기본 흐름입니다. 출력에 단일 대상 테마를 사용해야 한다면, 앞서 소개한 대상‑마스터 또는 대상‑레이아웃 오버로드를 사용하도록 `AddClone(slide)` 호출을 교체하십시오.

## **실용적인 고려 사항**

### **마스터, 레이아웃 및 서식 충실도**

기본 슬라이드 복제는 필요할 경우 원본 마스터를 자동으로 대상 프레젠테이션에 가져올 수 있습니다. Aspose.Slides는 자동 복제된 마스터를 내부 레지스트리에 저장해 동일 마스터가 반복 복제되는 것을 방지합니다. 수동으로 복제한 마스터는 해당 레지스트리에 기록되지 않으므로, 명시적인 제어가 필요하지 않는 한 미리 마스터를 복제하지 않는 것이 좋습니다.

같은 이름을 가진 두 마스터 또는 레이아웃이 시각적으로 동일하다고 가정하지 마십시오. 기업 템플릿이 최종 모양을 제어해야 할 경우, 대상 마스터 또는 레이아웃을 명시적으로 선택하고 병합 후 결과를 검증하십시오.

### **노트와 댓글**

스피커 노트와 슬라이드 댓글은 슬라이드 내용과 연결되어 있으며, 슬라이드가 복제될 때 함께 복사됩니다. Aspose.Slides는 [프레젠테이션 노트](https://docs.aspose.com/slides/ko/net/presentation-notes/)와 [프레젠테이션 댓글](https://docs.aspose.com/slides/ko/net/presentation-comments/)을 위한 전용 API도 제공합니다.

노트 페이지 서식이 중요한 경우, 노트 마스터가 프레젠테이션 수준 객체이므로 원본 파일 간에 다를 수 있음을 염두에 두고 병합된 프레젠테이션을 확인하십시오. 리뷰 워크플로에서는 서로 다른 작성자나 템플릿에서 가져온 파일을 결합한 후 댓글 작성자와 스레드 구조도 검증하십시오.

### **이미지, 오디오, 비디오, OLE 객체 및 외부 링크**

슬라이드는 이미지, 삽입된 오디오, 삽입된 비디오, OLE 데이터와 같은 프레젠테이션 수준 리소스를 참조할 수 있습니다. 슬라이드 자체를 복제하고 보이는 도형만 복사하지 않음으로써 Aspose.Slides가 리소스와의 관계를 유지하도록 하십시오.

임베드된 리소스와 링크된 리소스는 다르게 취급해야 합니다. 링크된 오디오, 비디오, OLE 객체 또는 하이퍼링크는 외부 대상에 의존하므로, 슬라이드를 복제해도 외부 링크가 임베드된 콘텐츠로 바뀌지는 않습니다. 병합된 프레젠테이션이 열릴 환경에서 링크된 리소스 경로와 URL을 테스트하십시오.

Aspose.Slides는 자동 복제된 마스터를 추적하지만, 이는 서로 다른 원본 프레젠테이션에서 동일한 바이너리 리소스가 항상 중복 제거된다는 일반적인 보장을 의미하지는 않습니다. 출력 파일 크기가 중요한 경우, 병합된 패키지를 검사하고 결과를 측정하여 암시적 중복 제거에 의존하지 마십시오.

### **임베드된 폰트와 폰트 가용성**

폰트는 프레젠테이션 수준에서 관리됩니다. 타이포그래피가 기계 간에 일관되어야 한다면, 슬라이드 복제만으로 모든 필요한 폰트가 대상 환경에 존재한다는 것을 가정하지 마십시오. [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/ko/net/aspose.slides/fontsmanager/getembeddedfonts/) 로 임베드된 폰트를 확인하고, [프레젠테이션에 폰트 임베드](https://docs.aspose.com/slides/ko/net/embedded-font/) 에 설명된 대로 명시적으로 관리하십시오.

또한 원본 파일에서 사용된 폰트를 임베드할 권한이 있는지 확인하십시오. 폰트 라이선스에 따라 임베드가 제한될 수 있습니다.

### **비밀번호로 보호된 프레젠테이션**

비밀번호로 보호된 원본은 슬라이드를 복제하기 전에 성공적으로 열어야 합니다. 비밀번호는 [LoadOptions.Password](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/password/) 로 제공하십시오.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

암호화된 원본을 열어도 동일한 보호가 자동으로 대상 프레젠테이션에 적용되지는 않습니다. 필요 시 출력 보호를 별도로 구성하십시오.

### **대용량 프레젠테이션 및 메모리 사용**

고해상도 이미지, 오디오, 비디오 또는 기타 대용량 바이너리 개체를 포함한 대용량 프레젠테이션은 상당한 메모리를 차지할 수 있습니다. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/blobmanagementoptions/) 은 BLOB 처리와 임시 파일 사용을 제어합니다. 대용량 파일 전략은 [프레젠테이션 BLOB 관리](https://docs.aspose.com/slides/ko/net/manage-blob/) 를 참조하십시오.

대용량 파일의 경우 가능하면 파일 경로에서 로드하고, 각 원본 프레젠테이션을 병합이 끝나는 즉시 해제하며, 워크플로에 체크포인트가 필요하지 않은 한 중간 결과를 반복 저장하지 마십시오.

### **스레드 안전성**

동일 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 여러 스레드에서 동시에 로드, 수정, 저장 또는 복제하지 마십시오. 각 프레젠테이션 인스턴스는 하나의 병합 작업에만 사용하십시오. 독립적인 작업을 병렬 처리하려면 독립적인 프레젠테이션 인스턴스를 사용하고, [Aspose.Slides 멀티스레딩 가이드](https://docs.aspose.com/slides/ko/net/multithreading/) 를 따르십시오.

## **FAQ**

**각 원본 프레젠테이션의 원래 디자인을 유지하려면 어떻게 해야 하나요?**

대상 마스터나 레이아웃을 제공하지 않고 [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/addclone/) 를 사용하십시오. Aspose.Slides는 필요에 따라 원본 마스터를 자동으로 복제할 수 있습니다.

**가져온 슬라이드가 대상 테마를 사용하도록 하려면 어떻게 해야 하나요?**

대상 마스터를 받는 오버로드를 사용하십시오. 원본이 아닌 대상 프레젠테이션의 마스터를 전달하면 Aspose.Slides가 해당 마스터 아래에서 적절한 레이아웃을 매핑하려 시도합니다.

**대상 마스터 대신 특정 대상 레이아웃을 사용해야 하는 경우는 언제인가요?**

모든 가져온 슬라이드가 하나의 알려진 레이아웃을 사용해야 할 때는 특정 레이아웃을 사용하십시오. 슬라이드가 원본 레이아웃 유형이나 이름에 따라 마스터의 여러 레이아웃 중에서 선택되길 원한다면 마스터를 사용하십시오.

**다른 슬라이드 크기를 가진 프레젠테이션을 병합할 수 있나요?**

예, 하지만 슬라이드 내용이 자동으로 대상 크기에 맞게 재설계되지는 않습니다. 예측 가능한 배치를 원한다면 먼저 [SlideSize.SetSize](https://reference.aspose.com/slides/ko/net/aspose.slides/slidesize/setsize/) 와 [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/ko/net/aspose.slides/slidesizescaletype/) 를 사용해 원본 프레젠테이션을 크기 조정하십시오.

**PPT, PPTX 및 ODP 프레젠테이션을 하나의 파일로 병합할 수 있나요?**

예. 각 원본 프레젠테이션을 로드하고, 필요한 슬라이드를 하나의 대상에 복제한 뒤, 지원되는 출력 형식으로 저장하면 됩니다. 프레젠테이션 형식마다 지원하는 기능 세트가 정확히 동일하지 않으므로, 교차 형식 병합 후에는 복잡한 내용이 올바르게 유지되는지 확인하십시오. 자세한 내용은 [지원되는 파일 형식](https://docs.aspose.com/slides/ko/net/supported-file-formats/) 을 참조하십시오.

**원본 섹션이 자동으로 보존되나요?**

슬라이드만 복제하는 기본 루프에서는 자동으로 보존되지 않습니다. 섹션 구조를 유지해야 한다면 대상에 필요한 섹션을 재생성하고, 섹션 오버로드인 [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/addclone/) 를 사용하십시오.

**스피커 노트와 댓글이 보존되나요?**

복제된 슬라이드와 함께 복사됩니다. 노트 마스터 스타일링, 댓글 작성자 또는 스레드형 리뷰 데이터에 의존하는 워크플로에서는 병합 결과를 검증하십시오. 이러한 시나리오는 슬라이드 수준 콘텐츠뿐 아니라 프레젠테이션 수준 구조도 포함합니다.

**오디오, 비디오, OLE 객체 및 하이퍼링크는 어떻게 처리되나요?**

임베드된 콘텐츠는 복제된 슬라이드의 리소스 관계에 포함됩니다. 외부 링크는 외부에 남아 있으므로, 병합 후에도 대상 파일에서 해당 링크의 파일이나 URL에 접근할 수 있어야 합니다.

**모든 원본의 임베드된 폰트가 병합된 프레젠테이션에 보장되나요?**

슬라이드 복제만으로 폰트 배포를 보장하지 마십시오. 대상에 임베드된 폰트를 검사하고, 타이포그래피가 중요한 경우 폰트 임베드 또는 외부 폰트 가용성을 명시적으로 관리하십시오.

**비밀번호가 보호된 파일을 어떻게 병합하나요?**

올바른 [LoadOptions.Password](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/password/) 로 파일을 연 뒤 슬라이드를 정상적으로 복제하면 됩니다. 출력 보호는 별도로 구성하십시오.

**대용량 프레젠테이션을 어떻게 처리해야 하나요?**

대용량 바이너리 객체가 메모리 사용량을 차지할 때는 BLOB 관리를 사용하고, 가능한 경우 파일 경로 로드를 선호하며, 원본 프레젠테이션은 병합이 끝나는 즉시 해제하고, 최종 결과만 필요할 때 저장하십시오.

**여러 스레드에서 슬라이드를 병합할 수 있나요?**

하나의 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 여러 스레드에서 동시에 사용하지 마십시오. 각 병합 작업은 자체 프레젠테이션 인스턴스로 격리하십시오.