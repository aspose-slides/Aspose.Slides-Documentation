---
title: .NET에서 프레젠테이션 자리 표시자 관리
linktitle: 자리 표시자 관리
type: docs
weight: 10
url: /ko/net/manage-placeholder/
keywords:
- 자리 표시자
- 텍스트 자리 표시자
- 이미지 자리 표시자
- 차트 자리 표시자
- 콘텐츠 자리 표시자
- 프롬프트 텍스트
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET용 Aspose.Slides와 함께 텍스트, 그림, 차트 및 콘텐츠 자리 표시자를 검사하고 편집하는 방법 및 자리 표시자 상속을 이해하는 방법을 배웁니다."
---
## **개요**

자리 표시자는 프레젠테이션 템플릿에서 특정 종류의 콘텐츠 위치를 예약하는 도형입니다. 일반적인 예로는 제목, 본문, 그림, 차트 및 일반 용도 콘텐츠 자리 표시자가 있습니다. 일반 도형과 달리 자리 표시자는 레이아웃 슬라이드 또는 마스터 슬라이드에서 위치, 크기, 서식 및 기타 설정을 상속받을 수 있습니다.

Aspose.Slides는 [IShape.Placeholder](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/placeholder/) 속성을 통해 자리 표시자 정보를 제공합니다. 이 속성은 일반 도형의 경우 `null`을 반환하고, [IPlaceholder](https://reference.aspose.com/slides/ko/net/aspose.slides/iplaceholder/) 객체를 반환합니다. 자리 표시자가 포함하도록 설계된 내용을 확인하려면 [IPlaceholder.Type](https://reference.aspose.com/slides/ko/net/aspose.slides/iplaceholder/type/)을 사용하십시오.

자리 표시자 유형을 알게 된 후에도 도형 인터페이스는 여전히 중요합니다:

- 빈 텍스트, 그림, 차트 또는 콘텐츠 자리 표시자는 일반적으로 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)으로 표현됩니다.
- 채워진 그림 자리 표시자는 [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/)으로 표현될 수 있습니다.
- 채워진 차트 자리 표시자는 [IChart](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/)으로 표현될 수 있습니다.
- 콘텐츠 자리 표시자는 여러 종류의 콘텐츠를 포함할 수 있습니다. 모든 자리 표시자가 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)라고 가정하지 말고, [IPlaceholder.Type](https://reference.aspose.com/slides/ko/net/aspose.slides/iplaceholder/type/)과 런타임 도형 인터페이스를 모두 확인하십시오.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/ko/net/aspose.slides/iplaceholder/type/)은 자리 표시자의 역할을 설명하지만, 도형의 런타임 유형을 보장하지는 않습니다. 텍스트, 그림, 차트, 표 또는 미디어와 관련된 멤버에 접근하기 전에 항상 유형 검사를 수행하십시오.
{{% /alert %}}

## **자리 표시자 상속 이해**

자리 표시자는 계층 구조를 형성합니다:

1. 마스터 슬라이드는 재사용 가능한 스타일을 정의하고, 경우에 따라 마스터 수준의 자리 표시자를 포함합니다.
2. 레이아웃 슬라이드는 하나 이상의 일반 슬라이드에 사용되는 배치를 정의하며 마스터로부터 상속받을 수 있습니다.
3. 일반 슬라이드는 해당 슬라이드의 자리 표시자를 포함하고 레이아웃으로부터 상속받을 수 있습니다.

[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/getbaseplaceholder/)를 호출하면 이 계층 구조에서 한 단계 위로 이동합니다. 슬라이드 자리 표시자는 일반적으로 레이아웃 자리 표시자를 반환하고, 레이아웃 자리 표시자는 마스터 자리 표시자를 반환할 수 있습니다. 도형에 기본 자리 표시자가 없으면 메서드는 `null`을 반환합니다.

다음 예제는 첫 번째 슬라이드의 자리 표시자를 열거하고 해당 기본 자리 표시자를 보고합니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

일반 슬라이드에서 자리 표시자를 편집하면 해당 슬라이드에 대한 로컬 오버라이드가 생성되거나 변경됩니다. 관련 레이아웃이나 마스터를 편집하면 해당 설정을 상속받는 모든 슬라이드에 영향을 줄 수 있습니다. 로컬 일반 도형은 기본 자리 표시자가 없으며, 동일한 좌표를 차지한다고 해서 상속을 시작하지 않습니다.

## **자리 표시자 텍스트 변경**

제목, 가운데 제목, 부제목, 본문 및 텍스트 자리 표시자는 일반적으로 텍스트를 지원합니다. 해당 도형이 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)인지 확인한 후 [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/textframe/) 속성을 사용하십시오.

다음 예제는 첫 번째 슬라이드의 첫 번째 제목 자리 표시자를 업데이트하고 결과를 저장합니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

이 패턴은 그림, 차트, 표 또는 미디어 자리 표시자를 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)으로 강제 변환하는 것을 방지합니다. 또한 견고하지 않은 도형 인덱스에 의존하지 않고 목적에 따라 자리 표시자를 식별합니다.

## **레이아웃에 프롬프트 텍스트 설정**

프롬프트 텍스트는 빈 자리 표시자에 표시되는 디자인 타임 안내문이며, 예를 들어 *Click to add title*와 같습니다. 일반 슬라이드의 도형 컬렉션을 통해 접근하려 하기보다 레이아웃 자리 표시자에 사용자 정의 프롬프트 텍스트를 설정하십시오. [ISlide.LayoutSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/layoutslide/)을 통해 레이아웃에 접근하고 [ILayoutSlide.Shapes](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseslide/shapes/)를 반복합니다.

다음 예제는 첫 번째 슬라이드에 사용된 레이아웃의 제목 및 부제목 프롬프트를 변경합니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

프롬프트 텍스트는 일반 슬라이드 콘텐츠가 아닙니다. PowerPoint와 같은 편집 애플리케이션에서 빈 자리 표시자에 표시되는 안내문이며, 사용자가 실제 콘텐츠를 제공하면 더 이상 표시되지 않습니다. 프롬프트를 변경해도 해당 레이아웃을 사용하는 슬라이드에 기존 텍스트가 교체되지 않습니다.

## **그림 자리 표시자 업데이트**

다음 두 경우를 처리해야 합니다:

- 그림 자리 표시자가 이미 채워져 있고 [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/)으로 표현되는 경우, [IPictureFillFormat.Picture](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/picture/)와 [ISlidesPicture.Image](https://reference.aspose.com/slides/ko/net/aspose.slides/islidespicture/image/)를 통해 이미지를 교체합니다.
- 아직 빈 자리 표시자인 경우, [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addpictureframe/)를 사용해 자리 표시자 좌표에 그림 프레임을 추가하고 빈 자리 표시자를 제거합니다.

다음 예제는 두 경우 모두를 지원하고 프레젠테이션을 저장합니다:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

빈 자리 표시자를 위해 생성된 교체물은 새로운 자리 표시자가 아니라 로컬 그림 프레임이며, [IShape.Placeholder](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/placeholder/)은 읽기 전용이기 때문에 자리 표시자 특유의 동작을 더 이상 상속하지 않습니다. 자리 표시자 관계를 유지해야 한다면 먼저 PowerPoint에서 자리 표시자를 준비하고 채운 다음, Aspose.Slides를 사용해 결과 [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/)을 업데이트하십시오.

이미지 투명도, 자르기 및 기타 그림 전용 효과에 대해서는 [Manage Picture Frames](/slides/ko/net/picture-frame/)를 참조하십시오. 이러한 작업은 그림 프레임 또는 그림 채우기에 적용되며, 자리 표시자 메타데이터와는 별개입니다.

## **차트 및 콘텐츠 자리 표시자 작업**

채워진 차트 자리 표시자는 [IChart](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/)로 표현될 수 있습니다. 이 예제는 자리 표시자 유형과 런타임 인터페이스 모두를 사용해 차트를 찾고, 제목을 변경한 뒤 파일을 저장합니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

일반 콘텐츠 자리 표시자는 보통 [PlaceholderType.Object](https://reference.aspose.com/slides/ko/net/aspose.slides/placeholdertype/)를 가지고 있습니다. PowerPoint에서는 차트, 표, 다이어그램, 그림 및 미디어를 포함한 여러 콘텐츠 유형을 시작하는 런처 역할을 합니다. 한번 채워진 뒤에는 실제 도형 인터페이스를 검사해 어떤 콘텐츠가 포함되어 있는지 확인하십시오. 특수 레이아웃은 또한 [PlaceholderType.Chart](https://reference.aspose.com/slides/ko/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/ko/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/ko/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/ko/net/aspose.slides/placeholdertype/), [PlaceholderType.Diagram](https://reference.aspose.com/slides/ko/net/aspose.slides/placeholdertype/)을 노출할 수 있습니다.

Aspose.Slides는 [IPlaceholder.Type](https://reference.aspose.com/slides/ko/net/aspose.slides/iplaceholder/type/)을 단순히 변경한다고 빈 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 자리 표시자를 [IChart](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichart/)으로 변환하지 않습니다; 해당 유형은 읽기 전용입니다. 빈 차트 또는 콘텐츠 영역을 프로그래밍 방식으로 채우려면 해당 좌표에 필요한 객체를 추가하고 빈 자리 표시자를 제거하십시오. 다음 예제는 차트에 대해 이를 수행합니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

추가된 차트는 일반 로컬 차트이며, 자리 표시자 영역을 차지하지만 레이아웃 자리 표시자로부터 상속되지 않습니다. 카테고리, 시리즈 또는 워크북 데이터를 교체해야 할 경우 전용 [chart management articles](/slides/ko/net/powerpoint-charts/)를 활용하십시오.

## **전체 예제: 텍스트 또는 이미지 콘텐츠 업데이트**

다음 종단‑간 예제는 템플릿을 열고 첫 번째 슬라이드에서 제목 또는 그림 자리 표시자를 검색한 뒤, 자리 표시자와 도형 유형을 확인하고 적절한 콘텐츠를 업데이트한 뒤 출력 파일을 저장합니다. 이 예제는 도형 인덱스를 가정하거나 모든 자리 표시자를 동일한 인터페이스로 캐스팅하는 것을 의도적으로 피합니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **FAQ**

**기본 자리 표시자란 무엇인가요?**

기본 자리 표시자는 다른 자리 표시자가 상속받는 레이아웃 또는 마스터의 해당 도형을 의미합니다. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/getbaseplaceholder/)을 사용해 가져올 수 있습니다. 일반 로컬 도형은 자리 표시자 계층 구조의 일부가 아니므로 `null`을 반환합니다.

**레이아웃 자리 표시자를 편집하여 모든 슬라이드 제목을 변경할 수 있나요?**

레이아웃을 통해 상속된 서식이나 프롬프트 텍스트는 변경할 수 있지만, 기존 제목 내용은 일반 슬라이드에 저장됩니다. 프레젠테이션 전체의 실제 제목 텍스트를 교체하려면 슬라이드를 반복하면서 각 제목 자리 표시자를 업데이트해야 합니다.

**날짜, 슬라이드 번호, 머리글 및 바닥글 자리 표시자는 어떻게 관리하나요?**

해당 슬라이드, 레이아웃, 마스터, 노트 또는 유인물 범위에서 머리글 및 바닥글 관리자를 사용하십시오. 전체 예제는 [Manage Presentation Header and Footer](/slides/ko/net/presentation-header-and-footer/)를 참고하세요.