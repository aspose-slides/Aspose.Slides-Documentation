---
title: .NET에서 프레젠테이션 도형 관리
linktitle: 도형 조작
type: docs
weight: 40
url: /ko/net/shape-manipulations/
keywords:
- PowerPoint 도형
- 프레젠테이션 도형
- 슬라이드의 도형
- 도형 찾기
- 도형 복제
- 도형 제거
- 도형 숨기기
- 도형 순서 변경
- Interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 레이아웃 서식
- SVG 형식 도형
- 도형을 SVG로
- 도형 정렬
- 도형 뒤집기
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 프레젠테이션 도형을 식별, 복제, 제거, 숨기기, 순서 변경, 내보내기, 정렬 및 뒤집는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for .NET은 슬라이드의 도형을 정렬된 [IShapeCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/)으로 나타냅니다. 이 컬렉션은 도형을 찾고 수정하는 장소이자 스택 순서의 원천이며, 인덱스 `0`은 가장 뒤에 있는 도형이고 마지막 인덱스는 가장 앞에 있는 도형입니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 신뢰성 있게 식별하는 방법을 설명하고, 이어서 도형을 복제, 제거, 숨기기 및 순서를 재배열하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식 지정, SVG 내보내기, 정렬 및 뒤집기 설정을 다룹니다. 각 예제는 독립적이므로 워크플로에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 도형을 추가, 제거하거나 순서를 바꾸면 인덱스가 변경될 수 있습니다. 프레젠테이션이 작성되고 유지되는 방식에 따라 식별자를 선택하세요:

- [Name](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/name/)은 개발자가 제어하는 템플릿에 유용하며 PowerPoint의 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하지만 고유성이 보장되지 않으므로 코드가 이름에 의존한다면 명명 규칙을 정하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/alternativetext/)은 접근성 설명이나 작성자가 제공한 태그가 이미 도형을 식별할 때 유용합니다. 사용자가 볼 수 있으며 현지화되거나 접근성을 위해 다시 작성될 수 있지만 고유성이 보장되지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 조용히 재사용하지 마십시오.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/officeinteropshapeid/)은 슬라이드 내에서 고유한 읽기 전용 식별자로, PowerPoint 인터옵에서 사용하는 도형 ID와 대응됩니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 재생성된 도형은 다른 도형이며 자체 ID를 갖습니다.

관련된 [UniqueId](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/uniqueid/) 속성은 프레젠테이션 범위를 가지지만 부가 기능용으로 설계되었으며 재할당될 수 있습니다. 영구적인 외부 키로 취급해서는 안 됩니다. 장기적인 식별이 중요한 경우 애플리케이션 데이터에 매핑을 보관하고 예상 도형이 여전히 존재하는지 확인하십시오.

다음 예제는 `Name`을 서수 비교로 검색하고 슬라이드 범위의 인터옵 ID를 보고합니다. 템플릿에 기대하는 도형이 없을 경우 코드는 잘못된 객체를 사용하지 않고 해당 결과를 보고합니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

작업이 특정 도형 유형에만 해당되는 경우, 유형별 멤버를 사용하기 전에 인터페이스를 확인하십시오. 이 예제는 명명된 객체가 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)인 경우에만 텍스트와 대체 텍스트를 업데이트합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **도형 컬렉션 수정**

add, clone, remove, reorder 메서드는 컬렉션에 즉시 적용됩니다. 작업이 도형 수나 순서를 변경하면, 해당 작업 이전에 캡처한 인덱스에 계속 의존하지 마십시오.

### **도형 복제**

[AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addclone/)은 독립적인 복사본을 만들고 대상 컬렉션에 추가합니다. [InsertClone](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/insertclone/) 역시 복사본을 만들지만 지정된 z‑order 인덱스에 배치합니다. 좌표를 받는 오버로드는 크기를 변경하지 않고 복제본을 이동시키고, 너비와 높이를 받는 오버로드는 크기도 조정할 수 있습니다.

예제는 대상 슬라이드를 만든 뒤 레이블이 붙은 사각형을 앞쪽에 복제하고, 두 번째 복제본을 뒤쪽에 삽입합니다. 각각의 복제본에 대한 변경은 원본 도형을 수정하지 않습니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

복제는 도형의 내용과 서식을 복사하며 이름과 대체 텍스트도 포함합니다. 해당 값들이 고유해야 할 경우 복제본에 새로운 논리 식별자를 할당하십시오. 복합 도형이 사용하는 리소스는 프레젠테이션이 관리하지만, 복제본은 새로운 도형 식별자를 가진 새로운 컬렉션 항목으로 남습니다.

### **도형 제거**

[Remove](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/remove/)는 컬렉션에서 특정 도형 객체를 삭제합니다. 인덱스 순회 중에 여러 일치를 제거할 경우, 남은 인덱스가 유효하도록 끝에서부터 순회하십시오.

이 예제는 지정된 이름을 가진 모든 도형을 제거합니다. 고정된 컬렉션 항목이 아니라 `slide.Shapes[i]`를 읽으며, 도형을 불필요하게 캐스팅하지 않습니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

제거 후에는 도형 수와 이후 도형들의 인덱스가 변경됩니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 연결선, 애니메이션 및 제거된 객체를 참조할 수 있는 기타 프레젠테이션 기능도 고려하십시오. 보이는 도형을 제거하면 슬라이드 외형 이상이 바뀔 수 있습니다.

### **도형 숨기기**

[Hidden](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/hidden/)을 `true`로 설정하면 도형이 컬렉션에 남아 있지만 일반 슬라이드 쇼에 표시되지 않습니다. 인덱스, 서식 및 콘텐츠는 코드에서 계속 사용할 수 있으므로, 나중에 복원될 수 있는 선택적 요소에 숨기기가 적합합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

숨기기는 삭제나 보안이 아닙니다. 사용자는 물론 코드를 통해서도 객체를 찾아 다시 표시할 수 있으며, 프레젠테이션 파일의 일부로 남아 있습니다.

### **Z‑Order 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [Reorder](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/reorder/)는 복제 없이 기존 도형을 목표 인덱스로 이동시킵니다. 인덱스 `0`은 뒤쪽이며 `Count - 1`은 앞쪽입니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

사각형은 먼저 생성되어 처음에는 타원 뒤에 위치합니다. 최종 인덱스로 이동하면 앞쪽에 배치됩니다. 관련 도형을 모두 추가하거나 복제한 후에 Z‑order를 최종 결정하십시오. 이러한 작업은 새 컬렉션 항목을 추가하거나 삽입하여 의도한 스택을 변경할 수 있기 때문입니다.

## **레이아웃 슬라이드의 도형 검사**

일반 슬라이드, 레이아웃 슬라이드 및 마스터 슬라이드는 각각 별개의 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 일반 슬라이드에 동일하게 배치된 도형과 동일 객체가 아닙니다. 레이아웃에서 제공하는 서식을 이해하거나 변경해야 할 경우 레이아웃 도형을 검사하십시오.

다음 예제는 각 레이아웃 도형의 [FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/fillformat/)과 [LineFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/lineformat/)을 읽으며 모든 도형이 `AutoShape`이라고 가정하지 않습니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

레이아웃을 편집하면 이를 사용하는 여러 슬라이드에 영향을 줄 수 있습니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 객체를 상속받았는지 또는 로컬 오버라이드가 있는지 확인하고, 해당 레이아웃을 사용하는 모든 슬라이드를 테스트하십시오.

## **도형을 SVG로 내보내기**

[WriteAsSvg](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/writeassvg/)은 하나의 도형이 렌더링된 내용을 스트림에 기록합니다. 결과에는 도형 자체만 포함되며 전체 슬라이드 배경이나 이웃 도형은 포함되지 않습니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

렌더링 중에는 프레젠테이션을 열어 두십시오. 출력은 도형의 서식 및 글꼴, 이미지와 같은 리소스에 따라 달라집니다. 전체 구성이 필요하면 개별 도형이 아니라 슬라이드를 내보내십시오. 호출자가 스트림을 소유하며 반드시 해제해야 합니다.

## **도형 정렬**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/alignshapes/) 오버로드는 모든 도형 또는 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/net/aspose.slides/shapesalignmenttype/)은 가장자리, 중앙선 또는 분배 방식을 지정합니다. `alignToSlide`을 `true`로 설정하면 슬라이드 가장자리를 기준으로, `false`로 설정하면 선택된 도형을 서로 상대적으로 정렬합니다.

이 예제는 세 도형을 슬라이드 상단 가장자리에 정렬합니다. 반환된 도형 참조는 정렬 바로 전에 현재 인덱스로 변환됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

정렬은 위치를 변경하지만 Z‑order는 변하지 않습니다. 상대 정렬은 보통 최소 두 개의 도형이 필요하고, 가로나 세로 분배는 간격을 정의할 충분한 도형이 필요합니다. 메서드를 호출하기 전에 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **도형 뒤집기**

[ShapeFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/shapeframe/) 클래스는 위치, 크기, 수평 및 수직 뒤집기 설정, 회전을 저장합니다. `FlipH`와 `FlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/net/aspose.slides/nullablebool/)을 사용합니다: `True`는 뒤집기를 활성화하고, `False`는 비활성화하며, `NotDefined`는 지정되지 않거나 기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 뒤집히지 않은 도형 하나가 포함되어 있습니다.

![뒤집기 전 도형](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 그대로 두고 두 개의 뒤집기 설정만 교체합니다. 이는 새로운 [Frame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/frame/)을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

저장된 도형은 위치, 크기 및 회전을 유지하면서 수평 및 수직으로 뒤집혀 있습니다.

![뒤집기 후 도형](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해야 할까요?**

컬렉션이 인덱스가 사용되기 전에 변경되지 않을 짧은 기간의 처리에만 사용하십시오. 작성된 템플릿에는 검증된 `Name` 또는 `AlternativeText` 규칙을 선호하고, 슬라이드 범위 인터옵 작업에는 `OfficeInteropShapeId`를 사용하십시오.

**도형을 숨기면 Z‑order에서 제거되나요?**

아니요. 숨긴 도형은 동일한 인덱스에 컬렉션에 남아 있습니다. 찾고, 순서를 바꾸고, 편집하거나 다시 표시할 수 있습니다.

**왜 복제된 도형이 다른 도형 앞에 나타났나요?**

`AddClone`은 복제본을 컬렉션 끝에 추가하는데, 이는 Z‑order의 앞쪽에 해당합니다. 초기 인덱스를 지정하려면 `InsertClone`을 사용하거나 모든 도형을 추가한 후에 `Reorder`를 사용하십시오.