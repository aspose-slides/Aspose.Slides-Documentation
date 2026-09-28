---
title: ".NET에서 프레젠테이션 슬라이드 마스터 관리"
linktitle: "슬라이드 마스터"
type: docs
weight: 80
url: /ko/net/slide-master/
keywords:
- "슬라이드 마스터"
- "마스터 슬라이드"
- "PPT 마스터 슬라이드"
- "다중 마스터 슬라이드"
- "마스터 슬라이드 비교"
- "배경"
- "자리표시자"
- "마스터 슬라이드 복제"
- "마스터 슬라이드 복사"
- "마스터 슬라이드 중복"
- "사용되지 않은 마스터 슬라이드"
- "PowerPoint"
- "OpenDocument"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET에서 슬라이드 마스터를 관리합니다: PowerPoint 및 OpenDocument 프레젠테이션에서 마스터 슬라이드를 액세스, 편집, 복제, 비교 및 제거합니다."
---
## **개요**

**슬라이드 마스터**는 슬라이드 그룹에 대한 공유 디자인 설정을 정의합니다. 여기에는 일반적인 도형, 로고, 배경, 텍스트 스타일, 테마 설정 및 바닥글 설정이 포함될 수 있습니다. PowerPoint에서 슬라이드 마스터를 편집하는 것은 각 슬라이드마다 동일한 서식을 반복하지 않고 프레젠테이션을 일관되게 유지하는 일반적인 방법입니다.

Aspose.Slides for .NET은 동일한 모델을 지원합니다. 프레젠테이션에는 하나 이상의 마스터 슬라이드가 포함될 수 있으며, 각 마스터 슬라이드에는 여러 레이아웃 슬라이드가 포함될 수 있습니다. 일반 슬라이드는 보통 마스터 슬라이드를 직접 참조하지 않습니다. 대신 일반 슬라이드는 레이아웃 슬라이드를 사용하고, 그 레이아웃 슬라이드는 마스터 슬라이드에 속합니다.

계층 구조는:

1. **슬라이드 마스터** - 공유 디자인 및 테마를 정의합니다.
1. **레이아웃 슬라이드** - 자리표시자와 레이아웃 수준 서식의 특정 배치를 정의합니다.
1. **일반 슬라이드** - 실제 프레젠테이션 내용을 포함하고 하나의 레이아웃 슬라이드를 사용합니다.

![마스터 슬라이드, 레이아웃 슬라이드 및 일반 슬라이드의 계층 구조](slide-master_2.jpg)

Aspose.Slides에서 슬라이드 마스터는 [IMasterSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslide/) 인터페이스로 표현됩니다. 프레젠테이션의 모든 마스터 슬라이드는 [Presentation.Masters](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/masters/) 컬렉션을 통해 사용할 수 있으며, 이 컬렉션은 [IMasterSlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslidecollection/)을 구현합니다.

{{% alert color="info" title="Inheritance" %}}
같은 속성이 둘 이상의 수준에서 정의된 경우, 보다 구체적인 수준이 우선합니다. 예를 들어 마스터 슬라이드와 레이아웃 슬라이드가 모두 배경을 정의하면, 해당 레이아웃을 기반으로 하는 슬라이드는 레이아웃 배경을 사용합니다. 레이아웃 슬라이드에 대한 자세한 내용은 [슬라이드 레이아웃 적용 또는 변경](/slides/ko/net/slide-layout/)을 참조하십시오.
{{% /alert %}}

## **슬라이드 마스터에 액세스**

PowerPoint에서 **보기** > **슬라이드 마스터**에서 슬라이드 마스터 보기를 열 수 있습니다.

![PowerPoint 보기 탭의 슬라이드 마스터 명령](slide-master_3.jpg)

Aspose.Slides에서는 `Masters` 컬렉션을 사용하여 마스터 슬라이드에 액세스합니다:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

또한 일반 슬라이드의 레이아웃을 통해 사용되는 마스터 슬라이드를 가져올 수 있습니다:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **슬라이드 마스터에 포함된 내용**

마스터 슬라이드는 슬라이드와 유사한 객체입니다. [IBaseSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseslide/)을 구현하므로 일반 및 레이아웃 슬라이드에서 사용되는 많은 슬라이드 속성을 노출합니다. 마스터 전용 멤버는 [IMasterSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslide/) API 페이지에 나열되어 있습니다.

일반적으로 사용되는 마스터 슬라이드 멤버는 다음과 같습니다:

| 멤버 | 목적 |
| --- | --- |
| `Background` | 마스터 수준 슬라이드 배경을 설정합니다. |
| `Shapes` | 로고, 사진 프레임 및 공유 텍스트와 같이 마스터에 배치된 도형을 저장합니다. |
| `LayoutSlides` | 마스터에 속하는 레이아웃 슬라이드를 저장합니다. |
| `ThemeManager` | 마스터 테마 API에 대한 액세스를 제공합니다. |
| `HeaderFooterManager` | 마스터 및 해당 하위 레이아웃의 머리글, 바닥글, 날짜 및 슬라이드 번호를 제어합니다. |
| `GetDependingSlides` | 레이아웃을 통해 마스터에 의존하는 일반 슬라이드를 반환합니다. |

## **슬라이드 마스터에 이미지 추가**

마스터 슬라이드에 이미지를 추가하면 해당 마스터의 레이아웃을 사용하는 슬라이드에 표시됩니다. 로고, 워터마크, 장식 밴드 및 기타 반복 시각 요소에 유용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 로고를 추가합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

그림 프레임에 대한 자세한 내용은 [그림 프레임](/slides/ko/net/picture-frame/)을 참조하십시오.

## **마스터 그래픽 가시성 제어**

[IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseslide/showmastershapes/)를 사용하면 마스터에서 상속된 로고나 장식 도형을 삭제하지 않고 숨길 수 있습니다. 해당 그래픽을 제외해야 하는 슬라이드에서 [Slide.ShowMasterShapes](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/showmastershapes/)를 `false`로 설정하고, 표시해야 하는 슬라이드에서는 `true`로 유지합니다.

다음 자체 포함 예제는 마스터에 파란색 장식 밴드를 만들고 동일한 빈 레이아웃을 사용하는 두 슬라이드에 적용합니다. 첫 번째 슬라이드에서는 밴드가 보이고 두 번째 슬라이드에서는 숨겨집니다. 입력 프레젠테이션이나 이미지가 필요하지 않습니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

예제는 새 프레젠테이션에 포함된 **Blank** 레이아웃을 사용하고 초기 슬라이드의 자체 자리표시자를 제거합니다.

### **설정 범위 선택**

일반 슬라이드는 [ISlide.LayoutSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/layoutslide/)와 [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslide/masterslide/)를 통해 마스터에 연결됩니다. 개별 슬라이드에 속성을 설정하면 해당 슬라이드에만 영향을 줍니다. [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutslide/showmastershapes/)를 `false`로 설정하면 해당 레이아웃을 사용하는 모든 슬라이드에서 마스터 그래픽이 숨겨지며, 슬라이드 자체 설정이 `true`라도 동일하게 적용됩니다. 하나의 슬라이드에서만 그래픽을 숨기려면 슬라이드 속성을 변경하고 공유 레이아웃은 그대로 두세요.

이 설정은 마스터 슬라이드 자체에서는 가시성 제어로 지원되지 않습니다. 마스터에서는 항상 `false`를 반환하고 `true`를 할당하면 `NotSupportedException`이 발생합니다. 대신 일반 슬라이드나 레이아웃에 적용하십시오.

### **그래픽과 배경 구분**

| 작업 | 효과 |
| --- | --- |
| 마스터 그래픽 숨기기 | 상속된 마스터 도형을 삭제하거나 슬라이드 자체 도형을 변경하지 않고 가시성을 제어합니다. |
| 슬라이드 배경 채우기 변경 | 배경 색상, 그라디언트 또는 이미지를 변경합니다. 마스터 그래픽은 별도 도형이므로 해당 배경 위에 여전히 표시될 수 있습니다. [프레젠테이션 배경](/slides/ko/net/presentation-background/)을 참조하십시오. |
| 마스터에서 도형 삭제 | 공유 소스 도형을 제거하여 해당 마스터를 사용하는 슬라이드에서 더 이상 사용할 수 없게 합니다. |

## **자리표시자 작업**

자리표시자는 일반적으로 레이아웃 슬라이드에 정의됩니다. 마스터 슬라이드는 이러한 레이아웃이 상속받는 공유 스타일 및 테마를 제공하고, 각 레이아웃은 사용할 자리표시자와 위치를 결정합니다.

PowerPoint에서 자리표시자 명령은 슬라이드 마스터 보기에서 사용할 수 있습니다.

![PowerPoint 슬라이드 마스터 보기에서 자리표시자 삽입 명령](slide-master_5.png)

Aspose.Slides에서 새 자리표시자를 추가하려면 해당 마스터에 속한 레이아웃 슬라이드를 작업하십시오:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

이미 마스터 슬라이드에 존재하는 자리표시자 도형을 서식 지정할 수도 있습니다. 다음 예제는 제목 자리표시자를 찾아 선형 그라디언트 채우기를 적용합니다:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![일반 슬라이드가 상속받은 서식이 지정된 제목 자리표시자](slide-master_8.png)

자리표시자 및 텍스트 서식에 대한 자세한 옵션은 [자리표시자에 프롬프트 텍스트 설정](/slides/ko/net/manage-placeholder/)과 [텍스트 서식](/slides/ko/net/text-formatting/)을 참조하십시오.

## **슬라이드 마스터 배경 변경**

마스터 배경은 레이아웃 및 해당 배경을 재정의하지 않는 슬라이드에 상속됩니다. 다음 예제는 첫 번째 마스터 슬라이드에 단색 배경 색상을 설정합니다:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

관련 주제는 [프레젠테이션 배경](/slides/ko/net/presentation-background/) 및 [프레젠테이션 테마](/slides/ko/net/presentation-theme/)를 참조하십시오.

## **슬라이드 마스터를 다른 프레젠테이션으로 복제**

[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslidecollection/addclone/)를 사용하여 마스터 슬라이드를 다른 프레젠테이션에 복사합니다. 복사된 마스터는 대상 프레젠테이션의 레이아웃 및 슬라이드에서 사용할 수 있습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

마스터와 함께 일반 슬라이드를 복제해야 하는 경우는 [슬라이드 복제](/slides/ko/net/clone-slides/)를 참조하십시오.

## **여러 슬라이드 마스터 추가**

프레젠테이션에는 여러 마스터 슬라이드를 포함할 수 있습니다. 이는 섹션별로 다른 브랜딩, 페이지 구조 또는 테마 설정이 필요할 때 유용합니다.

![마스터 슬라이드 삽입 및 관리에 대한 PowerPoint 명령](slide-master_9.jpg)

다음 예제는 기본 마스터를 복제하고 복제본에 다른 배경을 부여한 뒤, 해당 복제 마스터 아래에 레이아웃을 만들고 그 레이아웃을 기반으로 새 슬라이드를 추가합니다:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **슬라이드 마스터 비교**

마스터 슬라이드는 [IBaseSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseslide/)에서 상속받은 `Equals` 메서드로 비교할 수 있습니다. 비교는 구조와 정적 콘텐츠(도형, 텍스트, 서식, 애니메이션 및 기타 슬라이드 설정)를 확인합니다. 슬라이드 ID와 같은 고유 식별자나 현재 날짜와 같은 동적 자리표시자 값은 비교하지 않습니다.

```csharp
using Aspose.Slides;

using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

자세한 내용은 [프레젠테이션 슬라이드 비교](/slides/ko/net/compare-slides/)를 참조하십시오.

## **슬라이드 마스터 보기를 기본 보기로 설정**

[ViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/)의 `LastView` 속성을 사용하면 PowerPoint가 처음 열 때 보기를 제어할 수 있습니다. 다음 예제는 프레젠테이션을 슬라이드 마스터 보기로 엽니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

다른 보기 설정에 대해서는 [프레젠테이션 저장](/slides/ko/net/save-presentation/)을 참조하십시오.

## **사용되지 않은 마스터 슬라이드 제거**

프레젠테이션에 더 이상 일반 슬라이드에서 사용되지 않는 마스터 슬라이드가 포함될 수 있습니다. 사용되지 않은 마스터를 제거하면 파일 크기를 줄이고 템플릿 관리가 간소화됩니다.

[MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/ko/net/aspose.slides/masterslidecollection/removeunused/)를 사용하여 `Masters` 컬렉션에서 사용되지 않은 마스터를 제거합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

또는 저코드 [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ko/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) 메서드를 사용할 수 있습니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**슬라이드 마스터와 레이아웃 슬라이드의 차이점은 무엇인가요?**

슬라이드 마스터는 테마, 배경, 공통 도형 및 텍스트 스타일과 같은 공유 디자인 설정을 정의합니다. 레이아웃 슬라이드는 마스터 슬라이드에 속하며 자리표시자의 특정 배치를 정의합니다. 일반 슬라이드는 레이아웃 슬라이드를 사용하므로 레이아웃과 마스터 모두에서 상속받습니다.

**하나의 프레젠테이션에 여러 슬라이드 마스터를 포함할 수 있나요?**

네. 프레젠테이션에 여러 슬라이드 마스터를 포함할 수 있습니다. 섹션별로 서로 다른 시각 체계나 브랜딩이 필요할 때 여러 마스터를 사용하십시오.

**자리표시자를 마스터 슬라이드에 추가해야 할까요, 레이아웃 슬라이드에 추가해야 할까요?**

대부분의 경우 레이아웃 슬라이드에 자리표시자를 추가합니다. 공유 시각 요소와 공통 서식은 마스터 슬라이드에 두고, 일반 슬라이드가 사용할 내용 자리표시자는 레이아웃에 배치합니다.

**아직 사용 중인 마스터 슬라이드를 삭제할 수 있나요?**

아니요. 종속 슬라이드가 있는 마스터 슬라이드는 직접 삭제하면 안전하지 않습니다. 먼저 해당 슬라이드를 다른 마스터의 레이아웃으로 이동하거나 사용되지 않은 마스터만 제거하는 정리 방법을 사용하십시오.