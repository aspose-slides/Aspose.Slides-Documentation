---
title: .NET에서 슬라이드 레이아웃 적용 또는 변경
linktitle: 슬라이드 레이아웃
type: docs
weight: 60
url: /ko/net/slide-layout/
keywords:
- 슬라이드 레이아웃
- 콘텐츠 레이아웃
- 자리표시자
- 프레젠테이션 디자인
- 슬라이드 디자인
- 사용되지 않은 레이아웃
- 푸터 가시성
- 제목 슬라이드
- 제목 및 콘텐츠
- 섹션 헤더
- 두 개의 콘텐츠
- 비교
- 제목만
- 빈 레이아웃
- 캡션이 포함된 콘텐츠
- 캡션이 포함된 그림
- 제목 및 수직 텍스트
- 수직 제목 및 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET에서 슬라이드 레이아웃을 적용, 생성 및 수정하고, 자리표시자를 추가하며, 사용되지 않은 레이아웃을 제거하고, 푸터 가시성을 제어합니다."
---
## **개요**

슬라이드 레이아웃은 제목, 텍스트, 그림, 차트 및 표와 같은 자리표시자의 위치와 서식을 정의합니다. 레이아웃을 적용하면 슬라이드가 일관된 구조를 가지면서 각 슬라이드에 고유한 콘텐츠를 포함할 수 있습니다.

가장 일반적인 레이아웃은 다음과 같습니다:

- **제목 슬라이드**: 제목 및 부제목 자리표시자를 포함합니다.
- **제목 및 콘텐츠**: 제목 자리표시자와 일반 용도 콘텐츠 자리표시자를 포함합니다.
- **빈 슬라이드**: 콘텐츠 자리표시자가 없으며 모든 도형을 수동으로 배치할 때 유용합니다.

## **레이아웃 상속 이해하기**

프레젠테이션에는 세 가지 관련 레벨이 있습니다:

1. A [마스터 슬라이드](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslide/)은 테마, 공유 서식, 배경 및 공통 객체를 정의합니다.
1. A [레이아웃 슬라이드](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/)는 마스터에 속하며 특정 자리표시자 배열을 정의합니다.
1. A [일반 슬라이드](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/)는 하나의 레이아웃을 사용하고 해당 슬라이드에 입력된 콘텐츠를 저장합니다.

일반 슬라이드는 레이아웃으로부터 테마와 서식을 상속받으며, 레이아웃은 마스터로부터 상속받습니다. 일반 슬라이드에 직접 설정된 값은 해당 레벨에서 상속된 값을 재정의합니다. 일반 슬라이드가 생성될 때 선택된 레이아웃에서 자리표시자 도형이 생성되며, 그 자리표시자에 입력된 콘텐츠는 일반 슬라이드에 속합니다.

슬라이드를 만들기 전에 레이아웃에 필요한 자리표시자를 추가하십시오. 레이아웃에 나중에 다른 자리표시자를 추가해도 기존 일반 슬라이드에 자동으로 해당 자리표시자 도형이 추가되지는 않습니다.

이 관계에는 두 가지 중요한 결과가 있습니다:

- 레이아웃의 상속된 서식이나 기존 자리표시자 기하학을 변경하면 이를 기반으로 하는 모든 슬라이드가 업데이트될 수 있습니다. 이미 사용 중인 레이아웃을 편집하기 전에 해당 레이아웃에 의존하는 슬라이드를 검사하고 결과 프레젠테이션을 검토하십시오.
- 슬라이드에서 아직 사용 중인 레이아웃은 제거할 수 없습니다. 먼저 해당 레이아웃에 의존하는 슬라이드를 다른 레이아웃으로 재할당하거나 사용되지 않는 레이아웃만 제거하십시오.

이 계층 구조의 최상위 레벨에 대한 자세한 내용은 [슬라이드 마스터](/slides/ko/net/slide-master/)를 참조하십시오.

## **슬라이드 레이아웃 선택 및 적용**

프레젠테이션이 표준 PowerPoint 레이아웃 정의를 따를 때 레이아웃 유형을 사용하십시오. 레이아웃 이름은 사용자가 편집할 수 있으며 현지화될 수 있으므로, 소스 템플릿을 제어하지 않는 한 이름 기반 선택은 신뢰성이 낮습니다.

다음 예시는 첫 번째 마스터에서 **제목 및 콘텐츠**를 찾습니다. 해당 레이아웃이 없으면 의도적으로 **빈 슬라이드**로 대체합니다. 두 번째 null 검사는 프레젠테이션에 사용자 정의 레이아웃만 포함될 수 있기 때문에 필요합니다. 선택된 레이아웃은 [ISlide.LayoutSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/layoutslide/) 속성을 통해 첫 번째 일반 슬라이드에 적용됩니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

슬라이드 레이아웃을 변경해도 직접 슬라이드에 추가된 일반 도형은 제거되지 않습니다. 그러나 자리표시자 위치, 상속된 서식 및 기존 자리표시자와 새 레이아웃 간의 대응 관계가 변경될 수 있으므로, 크게 다른 레이아웃 간에 전환할 때 출력 결과를 확인하십시오.

## **레이아웃 슬라이드 추가**

선택과 생성을 별개의 작업으로 구분합니다. 이전 예시는 기존 레이아웃을 선택했을 뿐 생성하지 않았습니다. 레이아웃을 만들려면 대상 마스터의 레이아웃 컬렉션에서 [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/ko/net/aspose.slides/masterlayoutslidecollection/add/) 메서드를 호출하십시오.

다음 예시는 항상 `Report Title and Content`라는 이름의 새 **제목 및 콘텐츠** 레이아웃을 추가한 뒤, 해당 레이아웃을 기반으로 일반 슬라이드를 추가합니다. 레이아웃 이름은 컬렉션 내에서 고유해야 합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

템플릿에 실제로 다른 재사용 가능한 구조가 필요할 때만 레이아웃을 추가하십시오. 적절한 레이아웃이 이미 존재하면 중복을 만들지 말고 선택하여 재사용하십시오.

## **레이아웃 슬라이드에 자리표시자 추가**

[ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/placeholdermanager/) 속성은 레이아웃에 자리표시자 도형을 추가할 수 있는 [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutplaceholdermanager/)를 제공합니다.

| PowerPoint 자리표시자 | `ILayoutPlaceholderManager` 메서드 |
| --------------------- | --------------------------------- |
| ![내용](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![내용 (수직)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![텍스트](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![텍스트 (수직)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![그림](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![차트](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![표](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![스마트아트](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![미디어](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![온라인 이미지](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

다음 예시는 **빈 슬라이드** 레이아웃이 존재하는지 확인하고 네 개의 자리표시자를 추가한 뒤, 수정된 레이아웃을 사용하는 일반 슬라이드를 생성합니다. 순서는 의도적이며, 자리표시자는 일반 슬라이드가 생성되기 전에 추가되어 Aspose.Slides가 해당 슬라이드에 대응하는 자리표시자 도형을 생성할 수 있게 합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

결과:

![레이아웃 슬라이드의 자리표시자](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
상속된 서식이나 기존 레이아웃 자리표시자의 기하학을 변경하면 의존 슬라이드에 영향을 줄 수 있습니다. 새로 추가된 레이아웃 자리표시자는 기존 일반 슬라이드에 자동으로 채워지지 않습니다. 레이아웃 변경을 프레젠테이션 복사본에서 테스트하고 모든 의존 슬라이드를 검사하십시오.
{{% /alert %}}

## **사용되지 않는 레이아웃 슬라이드 제거**

[Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 메서드를 사용하여 일반 슬라이드가 참조하지 않는 레이아웃을 제거하십시오. 이 메서드는 여전히 사용 중인 레이아웃은 그대로 두고 제거합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

특정 레이아웃을 하나 제거하려면 먼저 해당 레이아웃의 [HasDependingSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/hasdependingslides/) 속성 또는 [GetDependingSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/getdependingslides/) 메서드를 사용하십시오. [ILayoutSlide.Remove](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/remove/)를 호출하기 전에 모든 의존 슬라이드를 다른 레이아웃으로 재할당하십시오. 사용 중인 레이아웃을 제거하려고 하면 [PptxEditException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxeditexception/)이 발생합니다.

## **레이아웃 슬라이드에서 푸터 가시성 제어**

레이아웃에는 자체 푸터, 슬라이드 번호 및 날짜‑시간 자리표시자가 있습니다. [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/headerfootermanager/) 속성을 사용하여 하나의 레이아웃에 대한 이러한 자리표시자를 제어하십시오. 예를 들어 콘텐츠 레이아웃은 푸터를 표시하고 제목 레이아웃은 표시하지 않아야 할 경우에 유용합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **마스터 및 하위 레이아웃에서 푸터 가시성 제어**

마스터 계층 전체에 일관된 푸터 설정을 적용하려면 [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslide/headerfootermanager/) 속성을 사용하십시오. [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslideheaderfootermanager/)의 전파 메서드는 마스터와 해당 의존 레이아웃 슬라이드 및 일반 슬라이드에 적용되며, 단일 일반 슬라이드만을 대상으로 하지 않습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **FAQ**

**마스터 슬라이드와 레이아웃 슬라이드의 차이점은 무엇입니까?**

마스터 슬라이드는 프레젠테이션의 테마와 공유 서식을 정의합니다. 레이아웃 슬라이드는 마스터에 속하며 하나의 재사용 가능한 자리표시자 배열을 정의합니다. 일반 슬라이드는 이러한 레이아웃을 사용하고 슬라이드별 콘텐츠를 저장합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 레이아웃 슬라이드를 복사할 수 있습니까?**

예. 대상 컬렉션에 [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/globallayoutslidecollection/addclone/) 메서드를 사용하여 복사본을 추가하십시오. 프레젠테이션 간에 복사할 때는 원본 레이아웃이 사용하는 글꼴, 테마, 이미지 및 기타 리소스도 확인해야 합니다.

**이미 사용 중인 레이아웃을 수정하면 어떻게 됩니까?**

의존 슬라이드는 로컬에서 해당 서식이나 객체를 재정의하지 않는 한 레이아웃 변경을 상속받습니다. 따라서 자리표시자 기하학 및 상속된 스타일이 많은 슬라이드에 동시에 변경될 수 있습니다. 레이아웃을 편집하기 전에 [GetDependingSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/getdependingslides/)를 사용하여 영향을 받을 슬라이드를 식별하십시오.

**여전히 사용 중인 레이아웃을 제거하면 어떻게 됩니까?**

Aspose.Slides는 [PptxEditException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxeditexception/)을 발생시킵니다. 먼저 의존 슬라이드를 다른 레이아웃으로 재할당하거나, [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)를 사용하여 참조되지 않은 레이아웃만 제거하십시오.