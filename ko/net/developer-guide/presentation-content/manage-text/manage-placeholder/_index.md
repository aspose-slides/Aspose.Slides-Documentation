---
title: .NET에서 프레젠테이션 플레이스홀더 관리
linktitle: 플레이스홀더 관리
type: docs
weight: 10
url: /ko/net/manage-placeholder/
keywords:
- 플레이스홀더
- 텍스트 플레이스홀더
- 이미지 플레이스홀더
- 차트 플레이스홀더
- 콘텐츠 플레이스홀더
- 프롬프트 텍스트
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 텍스트, 그림, 차트 및 콘텐츠 플레이스홀더를 검사하고 편집하는 방법과 플레이스홀더 상속을 이해하는 방법을 배웁니다."
---
## **개요**

플레이스홀더는 프레젠테이션 템플릿에서 특정 유형의 콘텐츠를 위한 위치를 예약하는 도형입니다. 일반적인 예로는 제목, 본문, 그림, 차트 및 일반용 콘텐츠 플레이스홀더가 있습니다. 일반 도형과 달리 플레이스홀더는 레이아웃 슬라이드 또는 마스터 슬라이드로부터 위치, 크기, 서식 및 기타 설정을 상속받을 수 있습니다.

Aspose.Slides는 [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) 속성을 통해 플레이스홀더 정보를 제공합니다. 이 속성은 일반 도형의 경우 `null`을 반환하거나 [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) 객체를 반환합니다. 플레이스홀더가 어떤 콘텐츠를 포함하도록 설계되었는지 확인하려면 [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/)을 사용하십시오.

플레이스홀더 유형을 알게 된 후에도 도형 인터페이스는 중요합니다:

- 텍스트, 그림, 차트 또는 콘텐츠가 비어 있는 플레이스홀더는 일반적으로 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)로 표현됩니다.
- 내용이 채워진 그림 플레이스홀더는 [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/)로 표현될 수 있습니다.
- 내용이 채워진 차트 플레이스홀더는 [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/)로 표현될 수 있습니다.
- 콘텐츠 플레이스홀더는 여러 종류의 콘텐츠를 포함할 수 있습니다. 모든 플레이스홀더가 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)라고 가정하지 말고 [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/)과 런타임 도형 인터페이스를 모두 확인하십시오.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/)은 플레이스홀더의 역할을 설명하지만 도형의 런타임 유형을 보장하지는 않습니다. 텍스트, 그림, 차트, 표 또는 미디어 전용 멤버에 접근하기 전에 항상 유형 검사를 수행하십시오.
{{% /alert %}}

## **플레이스홀더 상속 이해**

플레이스홀더는 계층 구조를 형성합니다:

1. 마스터 슬라이드는 재사용 가능한 스타일을 정의하고, 경우에 따라 마스터 수준의 플레이스홀더를 포함합니다.
2. 레이아웃 슬라이드는 하나 이상의 일반 슬라이드에 사용되는 배치를 정의하며 마스터로부터 상속받을 수 있습니다.
3. 일반 슬라이드는 해당 슬라이드의 플레이스홀더를 포함하고 레이아웃으로부터 상속받을 수 있습니다.

[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/)을 호출하면 이 계층 구조에서 한 단계 위로 이동합니다. 슬라이드 플레이스홀더는 일반적으로 레이아웃 플레이스홀더를 반환하고, 레이아웃 플레이스홀더는 마스터 플레이스홀더를 반환할 수 있습니다. 해당 도형에 기본 플레이스홀더가 없으면 메서드는 `null`을 반환합니다.

다음 예제는 첫 번째 슬라이드에 있는 플레이스홀더를 나열하고 해당 기본 플레이스홀더를 보고합니다:

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

일반 슬라이드에서 플레이스홀더를 편집하면 해당 슬라이드에 대한 로컬 오버라이드가 생성되거나 변경됩니다. 관련 레이아웃이나 마스터를 편집하면 해당 설정을 상속받는 모든 슬라이드에 영향을 줄 수 있습니다. 로컬 일반 도형은 기본 플레이스홀더가 없으며 동일한 좌표에 있기 때문에 자동으로 상속을 시작하지 않습니다.

## **플레이스홀더 상태 제거**

템플릿을 수정할 때 [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/)를 사용하면 기존 객체를 일반 도형으로 유지할 수 있습니다. 해당 도형의 [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) 속성은 `null`이 되지만 도형은 슬라이드 컬렉션에 남아 있습니다. 반대로 [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/)는 컬렉션에서 도형 자체를 삭제합니다.

다음 예제는 최소 하나의 슬라이드와 첫 번째 슬라이드에 비어 있지 않은 텍스트 플레이스홀더가 포함된 `template.pptx`가 필요합니다. 레이아웃이나 마스터에서 상속된 서식이 있는 플레이스홀더를 사용하여 관계 제거 효과를 확인하십시오. 예제는 동일한 도형이 남아 있는지 확인하고, 이제 일반 도형이 된 후 메서드를 다시 호출한 뒤 결과를 저장합니다.

{{% alert color="warning" title="Warning" %}}
플레이스홀더 상태를 제거한다고 해서 상속된 외관 설정이 자동으로 보존되지는 않습니다. 아래 예제는 이러한 설정을 그대로 두도록 의도했으므로 출력이 다르게 보일 수 있습니다. 위치와 크기가 완전히 상속된 도형은 호출 후 좌표와 차원이 0이 되어 컬렉션에 남아 있어도 보이지 않을 수 있습니다.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // 일반 도형에서 메서드를 호출해도 효과가 없습니다.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

일치하는 플레이스홀더에 대해 세 가지 검사가 모두 `True`를 출력합니다. 텍스트는 유지되지만, 상속된 위치, 크기, 회전, 글꼴, 단락 정렬, 텍스트 프레임 여백, 수직 고정, 채우기 및 선 설정은 플레이스홀더 관계가 제거될 때 변경될 수 있습니다. 예를 들어, 상속된 제목 서식이 일반 텍스트 서식으로 되돌아갈 수 있습니다. 레이아웃에 대한 자세한 내용은 [Slide Layout](/slides/ko/net/slide-layout/)를 참고하십시오.

예상된 외관을 보존하려면 호출 전에 해결된 위치, 크기 및 회전을 캡처하고, 필요한 유효 서식 값을 별도 변수에 복사하십시오. 이러한 값은 [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/)를 통해 가져와야 합니다. 관계가 제거된 후에도 텍스트 서식 값이 변경될 수 있으므로 유효 서식 객체만 유지하지 말고 캡처한 값을 일반 도형에 명시적으로 적용하십시오. 여기에는 글꼴 패밀리, 크기, 스타일, 색상, 단락 설정, 텍스트 프레임 설정, 채우기 및 선이 포함됩니다.

상속된 도형 기하학도 [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/)을 통해 명시적으로 지정해야 할 수 있습니다. 사각형 텍스트 플레이스홀더의 경우 [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)를 할당해야 하며, 단순히 채우기와 선만 복원해도 보이는 사각형이 복원되지 않을 수 있습니다. 추가 효과나 복잡한 서식이 있는 템플릿은 해당 설정도 별도로 처리해야 합니다.

## **플레이스홀더의 텍스트 변경**

제목, 가운데 제목, 부제목, 본문 및 텍스트 플레이스홀더는 일반적으로 텍스트를 지원합니다. [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)인지 확인한 뒤 해당 도형의 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) 속성을 사용하십시오.

다음 예제는 첫 번째 슬라이드의 첫 번째 제목 플레이스홀더를 업데이트하고 결과를 저장합니다:

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

이 패턴은 그림, 차트, 표 또는 미디어 플레이스홀더를 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)로 캐스팅하는 것을 방지합니다. 또한 인덱스에 의존하는 대신 용도에 따라 플레이스홀더를 식별합니다.

## **레이아웃에 프롬프트 텍스트 설정**

프롬프트 텍스트는 비어 있는 플레이스홀더에 표시되는 디자인 타임 안내문으로, 예를 들어 *Click to add title*과 같습니다. 일반 슬라이드의 도형 컬렉션을 통해 접근하려 하지 말고 레이아웃 플레이스홀더에 사용자 정의 프롬프트 텍스트를 설정하십시오. [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/)을 통해 레이아웃에 접근하고 [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/)를 순회하십시오.

다음 예제는 첫 번째 슬라이드에서 사용되는 레이아웃의 제목 및 부제목 프롬프트를 변경합니다:

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

프롬프트 텍스트는 일반 슬라이드 콘텐츠가 아닙니다. PowerPoint와 같은 편집 애플리케이션에서 비어 있는 플레이스홀더에만 표시됩니다. 사용자가 실제 콘텐츠를 제공하면 프롬프트는 더 이상 표시되지 않으며, 레이아웃을 사용하는 슬라이드에 기존 텍스트가 있더라도 프롬프트를 변경해도 교체되지 않습니다.

## **그림 플레이스홀더 업데이트**

다음 두 경우를 처리해야 합니다:

- 그림 플레이스홀더가 이미 채워져 있고 [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/)으로 표시되는 경우, [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/)와 [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/)를 통해 이미지를 교체하십시오.
- 아직 비어 있는 경우, [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/)을 사용해 플레이스홀더 좌표에 그림 프레임을 추가하고 빈 플레이스홀더를 삭제하십시오.

다음 예제는 두 경우를 모두 지원하고 프레젠테이션을 저장합니다:

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

비어 있는 플레이스홀더에 대해 생성된 교체물은 새로운 플레이스홀더가 아니라 로컬 그림 프레임입니다. 이는 [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/)이 읽기 전용이기 때문이며, 예약된 위치는 유지하지만 더 이상 플레이스홀더‑전용 동작을 상속하지 않습니다. 플레이스홀더 관계를 유지해야 하는 경우 먼저 PowerPoint에서 플레이스홀더를 준비·채워 놓은 뒤 Aspose.Slides로 해당 [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/)을 업데이트하십시오.

이미지 투명도, 크롭 및 기타 그림 전용 효과에 대해서는 [Manage Picture Frames](/slides/ko/net/picture-frame/)를 참고하십시오. 이러한 작업은 그림 프레임 또는 그림 채우기에 적용되며 플레이스홀더 메타데이터와는 무관합니다.

## **차트 및 콘텐츠 플레이스홀더 작업**

채워진 차트 플레이스홀더는 [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/)로 표현될 수 있습니다. 다음 예제는 플레이스홀더 타입과 런타임 인터페이스 모두를 사용해 차트를 찾고, 제목을 변경한 뒤 파일을 저장합니다:

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

일반 콘텐츠 플레이스홀더는 보통 [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)를 가집니다. PowerPoint에서는 차트, 표, 다이어그램, 그림, 미디어 등 여러 콘텐츠 유형을 시작하는 런처 역할을 합니다. 채워진 이후에는 실제 도형 인터페이스를 검사해 포함된 내용을 파악해야 합니다. 특정 레이아웃은 [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)을 노출하기도 합니다.

Aspose.Slides는 [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/)을 변경한다고 해서 빈 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 플레이스홀더를 [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/)로 자동 변환하지 않습니다. 타입은 읽기 전용이며, 빈 차트 또는 콘텐츠 영역을 프로그램matically 채우려면 해당 좌표에 필요한 객체를 추가하고 빈 플레이스홀더를 삭제해야 합니다. 다음 예제는 차트에 대해 이를 수행합니다:

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

추가된 차트는 일반 로컬 차트이며, 플레이스홀더 영역을 차지하지만 레이아웃 플레이스홀더를 상속하지 않습니다. 카테고리, 시리즈 또는 워크북 데이터를 교체해야 할 경우 전용 [차트 관리 문서](/slides/ko/net/powerpoint-charts/)를 참고하십시오.

## **전체 예제: 텍스트 또는 이미지 콘텐츠 업데이트**

다음 전체 예제는 템플릿을 열고 첫 번째 슬라이드에서 제목 또는 그림 플레이스홀더를 검색한 뒤, 플레이스홀더와 도형 유형을 확인하고 적절한 콘텐츠를 업데이트한 뒤 결과를 저장합니다. 이 예제는 도형 인덱스를 가정하거나 모든 플레이스홀더를 동일한 인터페이스로 캐스팅하는 것을 피합니다.

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

**베이스 플레이스홀더란 무엇인가요?**

베이스 플레이스홀더는 레이아웃이나 마스터에 존재하며 다른 플레이스홀더가 상속받는 해당 도형을 의미합니다. 이를 가져오려면 [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/)을 사용하십시오. 일반 로컬 도형은 플레이스홀더 계층에 속하지 않으므로 `null`을 반환합니다.

**레이아웃 플레이스홀더를 편집하여 모든 슬라이드 제목을 변경할 수 있나요?**

레이아웃을 통해 상속된 서식이나 프롬프트 텍스트는 변경할 수 있지만, 실제 제목 내용은 일반 슬라이드에 저장됩니다. 프레젠테이션 전체의 제목 텍스트를 교체하려면 슬라이드를 순회하며 각 제목 플레이스홀더를 업데이트해야 합니다.

**날짜, 슬라이드 번호, 헤더 및 푸터 플레이스홀더를 어떻게 관리하나요?**

해당 슬라이드, 레이아웃, 마스터, 노트 또는 유인물 범위에서 헤더 및 푸터 관리자를 사용하십시오. 자세한 예제는 [프레젠테이션 헤더 및 푸터 관리](/slides/ko/net/presentation-header-and-footer/)를 참고하십시오.