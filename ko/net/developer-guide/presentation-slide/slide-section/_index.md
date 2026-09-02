---
title: .NET에서 프레젠테이션의 슬라이드 섹션 관리
linktitle: 슬라이드 섹션
type: docs
weight: 100
url: /ko/net/slide-section/
keywords:
- 섹션 만들기
- 섹션 추가
- 섹션 편집
- 섹션 변경
- 섹션 이름
- 섹션 슬라이드 가져오기
- 섹션 슬라이드 처리
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 슬라이드 섹션을 관리합니다: PPTX 프레젠테이션에서 섹션 슬라이드를 만들고, 이름을 바꾸고, 순서를 재배열하고, 가져오며, 처리합니다."
---
## **소개**

섹션은 슬라이드 내용을 변경하지 않고 연속된 슬라이드를 이름이 지정된 그룹으로 구성합니다. Aspose.Slides for .NET을 사용하면 [Presentation.Sections](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/sections/) 속성을 통해 섹션을 만들고, 순서를 변경하고, 이름을 바꾸고, 검사하고, 제거할 수 있습니다.

섹션은 특히 다음과 같은 경우에 유용합니다:

- 큰 프레젠테이션을 논리적인 주제 또는 챕터로 나누어야 할 때;
- 슬라이드 그룹을 서로 다른 협업자에게 할당할 때;
- 슬라이드를 그룹 단위로 처리, 이동 또는 병합해야 할 때.

그룹화된 슬라이드의 목적을 설명하는 간결한 섹션 이름을 선택하십시오. 섹션은 프레젠테이션 구조의 일부이므로 슬라이드 위치에서 파생하는 대신 섹션 API를 사용해 멤버십을 결정하십시오.

## **섹션 만들기 및 관리**

[ISectionCollection.AddSection](https://reference.aspose.com/slides/ko/net/aspose.slides/sectioncollection/addsection/)을 사용해 섹션 이름과 시작 슬라이드를 지정하여 섹션을 만들 수 있습니다. Aspose.Slides는 현재 프레젠테이션의 섹션 구조를 기반으로 해당 섹션에 속하는 슬라이드를 결정합니다.

같은 [ISectionCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/isectioncollection/)을 사용하면 다음 작업도 할 수 있습니다:

- [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/sectioncollection/reordersectionwithslides/)을 사용해 섹션과 해당 슬라이드를 함께 이동;
- 슬라이드는 유지하면서 섹션 정의만 제거하려면 [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/ko/net/aspose.slides/sectioncollection/removesection/) 사용;
- 섹션과 그 슬라이드를 모두 제거하려면 [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/sectioncollection/removesectionwithslides/) 사용;
- 마지막에 빈 섹션을 추가하려면 [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/ko/net/aspose.slides/sectioncollection/appendemptysection/) 사용.

다음 예제는 두 개의 섹션을 만들고, 하나를 이동한 뒤 해당 섹션과 슬라이드를 제거하고, 빈 섹션을 추가합니다:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

이러한 작업 후 프레젠테이션에는 슬라이드가 포함된 `Introduction` 섹션과 빈 `Appendix` 섹션이 남고, `Results` 섹션과 그 슬라이드는 제거됩니다.

## **섹션 이름 바꾸기**

섹션의 이름을 바꾸려면 [ISection.Name](https://reference.aspose.com/slides/ko/net/aspose.slides/isection/name/) 속성을 설정하면 됩니다. 섹션의 슬라이드와 위치는 그대로 유지됩니다.

다음 예제는 섹션을 만들고 이름을 변경합니다:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **섹션에서 슬라이드 가져오기**

[Presentation.Sections](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/sections/) 속성은 열거할 수 있는 [ISectionCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/isectioncollection/)을 반환합니다. 각 [ISection](https://reference.aspose.com/slides/ko/net/aspose.slides/isection/)에 대해 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ko/net/aspose.slides/isection/getslideslistofsection/)을 호출하면 현재 해당 섹션에 속한 슬라이드가 반환됩니다. 이 메서드는 슬라이드 수, 인덱스 접근 및 열거를 제공하는 [ISectionSlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/isectionslidecollection/)을 반환합니다.

다음 예제는 두 개의 채워진 섹션과 하나의 빈 섹션을 만든 뒤 각 섹션의 [name](https://reference.aspose.com/slides/ko/net/aspose.slides/isection/name/), [identifier](https://reference.aspose.com/slides/ko/net/aspose.slides/isection/sectionid/), [starting slide](https://reference.aspose.com/slides/ko/net/aspose.slides/isection/startedfromslide/), 슬라이드 수 및 슬라이드 번호를 출력합니다. 컬렉션 인덱서를 사용해 첫 번째 슬라이드를 읽고 `foreach`를 사용해 모든 슬라이드를 처리합니다. 빈 섹션의 경우 반환된 컬렉션의 카운트가 0이며 인덱서는 접근되지 않고 열거도 수행되지 않습니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

섹션 멤버십은 프레젠테이션의 섹션 구조에 의해 결정됩니다. [ISection.StartedFromSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/isection/startedfromslide/)과 슬라이드 인덱스, 다음 섹션의 시작 슬라이드만을 사용해 섹션 범위를 수동으로 계산하지 마십시오.

구조적 편집은 섹션에 반환되는 슬라이드와 슬라이드 번호 모두를 변경할 수 있습니다. 여기에는 슬라이드 순서 변경, 슬라이드 복제, 섹션과 슬라이드 함께 이동, 슬라이드 제거, 섹션 제거 등이 포함됩니다. 다음 예제는 이러한 각 변경 후에 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ko/net/aspose.slides/isection/getslideslistofsection/)을 호출해 이전 경계에 대한 가정을 유지하지 않도록 합니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

슬라이드나 섹션이 재정렬, 복제, 이동 또는 제거될 때마다 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ko/net/aspose.slides/isection/getslideslistofsection/)을 다시 호출하십시오. 이렇게 하면 이후 처리가 현재 프레젠테이션 구조와 일치합니다.

PPT(PowerPoint 97–2003) 형식은 섹션 메타데이터를 보존하지 않습니다. 섹션을 지원하는 형식(PPTX 등)으로 작업하고, PPT로 변환하면 이후 열거에 필요한 섹션 구조가 사라집니다.

## **FAQ**

**PPT(PowerPoint 97–2003) 형식으로 저장할 때 섹션이 보존되나요?**

아니요. PPT 형식은 섹션 메타데이터를 지원하지 않으므로 .ppt로 저장하면 섹션 그룹화가 손실됩니다.

**전체 섹션을 “숨길” 수 있나요?**

아니요. 섹션 자체에 가시성 상태가 없습니다. 섹션 내용을 숨기려면 해당 섹션의 각 슬라이드에 대해 [ISlide.Hidden](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/hidden/) 속성을 설정하십시오.

**특정 슬라이드를 포함하는 섹션을 어떻게 찾나요?**

[Presentation.Sections](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/sections/)을 열거하고, 각 섹션에 대해 [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ko/net/aspose.slides/isection/getslideslistofsection/)을 호출한 뒤 반환된 슬라이드와 대상 슬라이드를 비교하십시오. 비어 있지 않은 섹션의 경우 [ISection.StartedFromSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/isection/startedfromslide/)이 첫 번째 슬라이드를 반환하고, 빈 섹션의 경우 `null`을 반환합니다.