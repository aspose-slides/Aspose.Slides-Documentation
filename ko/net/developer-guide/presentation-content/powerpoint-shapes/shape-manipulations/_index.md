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
- 도형 조정 포인트
- 사전 설정 도형 조정
- 도형 기하학
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
description: "Aspose.Slides for .NET을 사용하여 프레젠테이션 도형을 식별, 조정, 복제, 제거, 숨기기, 순서 변경, 내보내기, 정렬 및 뒤집는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for .NET은 슬라이드의 도형을 정렬된 [IShapeCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/)으로 나타냅니다. 이 컬렉션은 도형을 찾고 수정하는 위치이자 스태킹 순서의 원천이며, 인덱스 `0`은 가장 뒤쪽 도형이고 마지막 인덱스는 가장 앞쪽 도형입니다.

이 문서는 해당 모델을 따릅니다. 먼저 도형을 안정적으로 식별하고 사전 설정된 도형 조정 포인트를 수정하는 방법을 설명한 뒤, 도형을 복제, 제거, 숨기기 및 순서 변경하는 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 뒤집기 설정을 다룹니다. 각 예제는 독립적이므로 워크플로에 필요한 작업만 사용할 수 있습니다.

## **도형 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 도형을 추가, 제거 또는 재정렬하면 인덱스가 변경될 수 있습니다. 프레젠테이션이 작성되고 관리되는 방식에 따라 식별자를 선택하십시오.

- [Name](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/name/)은 개발자가 제어하는 템플릿에 유용하며 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하지만 고유성을 보장하지 않으므로 코드가 이름에 의존한다면 명명 규칙을 정의하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/alternativetext/)은 접근성 설명이나 작성자가 제공한 태그가 이미 도형을 식별할 때 유용합니다. 사용자에게 보이며 현지화되거나 접근성을 위해 재작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 무단 사용하지 마십시오.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/officeinteropshapeid/)은 읽기 전용 식별자로 슬라이드 내에서 고유하며 PowerPoint 인터롭에서 사용되는 도형 ID와 일치합니다. PowerPoint와 통합하거나 도형 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 재생성된 도형은 다른 도형이며 자체 ID를 가집니다.

관련 [UniqueId](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/uniqueid/) 속성은 프레젠테이션 범위를 갖지만, 애드인용이며 재할당될 수 있습니다. 영구적인 외부 키로 취급해서는 안 됩니다. 장기적인 식별이 필수라면 애플리케이션 데이터에 매핑을 보관하고 기대하는 도형이 여전히 존재하는지 검증하십시오.

대체 텍스트 제목 및 설명을 읽고 업데이트하는 실용적인 예는 [Manage Alternative Text Titles and Descriptions](/slides/ko/net/presentation-accessibility/)를 참조하십시오. 대체 텍스트는 시각적 의미를 읽는 사람에게 설명하는 용도로 사용하고, 코드가 도형을 찾는 데 사용하는 이름과는 별도로 유지하십시오.

다음 예제는 `Name`을 서수 비교로 검색하고 슬라이드 범위의 인터롭 ID를 보고합니다. 템플릿에 기대한 도형이 없을 경우 코드는 잘못된 객체를 계속 사용하지 않고 해당 결과를 보고합니다.

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

작업이 특정 도형 유형에 국한되는 경우, 유형별 멤버를 사용하기 전에 인터페이스를 확인하십시오. 이 예제는 명명된 객체가 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)인 경우에만 텍스트와 대체 텍스트를 업데이트합니다.

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

## **사전 설정 도형 조정 식별 및 수정**

사전 설정 기하 도형은 모서리 크기, 화살표 비율, 호 각도와 같은 특성을 제어하는 조정 포인트를 노출할 수 있습니다. 읽기 전용 [IGeometryShape.Adjustments](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometryshape/adjustments/) 컬렉션을 통해 접근하십시오. 컬렉션 자체는 도형이 제공하지만, 각 [IAdjustValue](https://reference.aspose.com/slides/ko/net/aspose.slides/iadjustvalue/)는 변경 가능한 값을 포함합니다.

고정된 컬렉션 인덱스에만 의존하지 마십시오. 조정을 반복하면서 읽기 전용 [Type](https://reference.aspose.com/slides/ko/net/aspose.slides/adjustvalue/type/) 속성을 검사하십시오. 해당 속성의 [ShapeAdjustmentType](https://reference.aspose.com/slides/ko/net/aspose.slides/shapeadjustmenttype/) 값은 조정이 제어하는 내용을 설명합니다. 읽기 전용 [Name](https://reference.aspose.com/slides/ko/net/aspose.slides/adjustvalue/name/) 속성은 추가 식별 정보를 제공하며, 동일한 의미 유형을 가진 조정이 여러 개 있을 때 특히 유용합니다.

조정 의미에 맞는 값 속성을 사용하십시오:

| 조정 유형 | 목적 | 변경할 값 |
|---|---|---|
| `CornerSize` | 둥근 모서리 크기 | [RawValue](https://reference.aspose.com/slides/ko/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | 화살표 꼬리 두께 | `RawValue` |
| `ArrowheadLength` | 화살촉 길이 | `RawValue` |
| `ArrowheadWidth` | 화살촉 너비 | `RawValue` |
| `StartAngle` | 파이 또는 호의 시작 각도 | [AngleValue](https://reference.aspose.com/slides/ko/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | 파이 또는 호의 끝 각도 | `AngleValue` |

`Type`과 `Name`은 할당할 수 없습니다. `RawValue`는 사전 설정 고유의 기하 단위에서 읽기/쓰기 정수이고, `AngleValue`는 도 단위에서 읽기/쓰기 각도입니다. 조정의 개수, 순서, 의미 및 유효 범위는 사전 설정 [ShapeType](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometryshape/shapetype/)에 따라 달라집니다. 하나의 사전 설정에 대해 유효한 값이 다른 사전 설정에서는 무효이거나 다른 효과를 가질 수 있습니다.

`Type`이 `ShapeAdjustmentType.Custom`인 경우 API는 표준 의미를 인식하지 못합니다. `Name`, 사전 설정 유형 및 기존 값을 검사하고 기대 의미와 범위가 알려진 경우에만 조정을 변경하십시오. 인식된 유형이라도 동일한 유형이 여러 번 나타나는 경우 값을 선택하기 전에 확인하십시오. [Connector](/slides/ko/net/connector/) 문서에서는 연결선 굽힘 조정 상황을 보여줍니다.

다음 완전한 예제는 세 가지 사전 설정 도형의 기본 및 수정 버전을 생성합니다. 모든 조정을 반복하면서 `Name`과 `Type`을 보고, `RawValue`를 통해 크기 관련 값을 변경하고, `AngleValue`를 통해 각도를 변경한 뒤 결과를 저장합니다. 왼쪽 열은 기본 기하를 유지하고, 오른쪽 열은 조정된 둥근 사각형, 사방 화살표 및 파이를 보여줍니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// 기본 및 조정된 도형 열에 대한 헤더를 추가합니다.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

값을 변경하기 전에 의미 유형을 확인하면 코드가 의도를 명확히 하고 서로 다른 사전 설정 도형에서 동일한 컬렉션 인덱스가 동일한 의미를 가진다고 가정하는 것을 방지합니다.

## **도형 컬렉션 수정**

추가, 복제, 제거 및 재정렬 메서드는 컬렉션에 즉시 적용됩니다. 연산으로 인해 도형 수나 순서가 변경되면, 해당 연산 전에 캡처한 인덱스에 계속 의존하지 마십시오.

### **도형 복제**

[AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addclone/)은 독립적인 복사본을 만들고 대상 컬렉션에 추가합니다. [InsertClone](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/insertclone/)도 복사본을 만들지만 지정된 z‑order 인덱스에 배치합니다. 좌표를 받는 오버로드는 크기를 변경하지 않고 복제를 이동하고, 너비와 높이를 받는 오버로드는 크기도 조정합니다.

예제는 대상 슬라이드를 만들고, 라벨이 있는 사각형을 앞쪽에 복제한 뒤, 두 번째 복제를 뒤쪽에 삽입합니다. 두 복제 중 어느 하나를 변경해도 원본 도형에는 영향을 주지 않습니다.

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

복제는 도형의 내용과 서식을 복사하며 이름과 대체 텍스트도 포함합니다. 해당 값이 고유해야 한다면 복제에 새로운 논리 식별자를 할당하십시오. 복잡한 도형이 사용하는 리소스는 프레젠테이션이 처리하지만, 복제는 새로운 컬렉션 항목이자 새로운 도형 ID를 갖습니다.

### **도형 제거**

[Remove](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/remove/)는 컬렉션에서 특정 도형 객체를 삭제합니다. 인덱스 기반 반복 중 여러 일치를 제거할 때는 끝에서부터 순회하여 남은 인덱스가 계속 유효하도록 합니다.

이 예제는 지정된 이름을 가진 모든 도형을 제거합니다. 고정된 컬렉션 항목이 아니라 `slide.Shapes[i]`를 읽으며, 불필요하게 형변환하지도 않습니다.

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

제거 후에는 도형 수와 이후 도형들의 인덱스가 변경됩니다. 영향을 받지 않은 도형에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 연결선, 애니메이션 및 기타 프레젠테이션 기능이 제거된 객체를 참조할 수 있으니, 보이는 도형을 제거하면 슬라이드 외관 이상의 변화가 발생할 수 있습니다.

### **도형 숨기기**

[Hidden](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/hidden/)을 `true`로 설정하면 도형이 컬렉션에 남아 있지만 일반 슬라이드 쇼에는 표시되지 않습니다. 인덱스, 서식 및 내용은 코드에서 그대로 사용 가능하므로 나중에 복원될 수 있는 선택적 요소에 적합합니다.

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

숨기기는 삭제나 보안이 아닙니다. 객체는 여전히 사용자가 또는 코드가 찾아서 다시 보이게 할 수 있으며 프레젠테이션 파일의 일부로 남아 있습니다.

### **Z‑Order 변경**

겹치는 도형은 컬렉션 순서대로 그려집니다. [Reorder](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/reorder/)는 복제하지 않고 기존 도형을 대상 인덱스로 이동합니다. 인덱스 `0`은 뒤쪽, `Count - 1`은 앞쪽입니다.

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

사각형을 먼저 만들면 초기에는 타원 뒤에 위치합니다. 최종 인덱스로 이동하면 앞쪽에 놓이게 됩니다. 모든 관련 도형을 추가하거나 복제한 후에 z‑order를 최종 설정하십시오. 이러한 작업은 컬렉션 항목을 추가하거나 삽입하여 스택을 변경할 수 있기 때문입니다.

## **레이아웃 슬라이드의 도형 검사**

일반 슬라이드, 레이아웃 슬라이드 및 마스터 슬라이드는 별도의 도형 컬렉션을 가집니다. 레이아웃 컬렉션의 도형은 일반 슬라이드에 동일한 위치에 있더라도 동일 객체가 아닙니다. 레이아웃이 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 도형을 검사하십시오.

다음 예제는 각 레이아웃 도형의 [FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/fillformat/)과 [LineFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/lineformat/)을 읽으며, 모든 도형이 `AutoShape`이라고 가정하지 않습니다.

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

레이아웃을 편집하면 해당 레이아웃을 사용하는 여러 슬라이드에 영향을 줄 수 있습니다. 레이아웃 도형을 변경하기 전에 일반 슬라이드가 객체를 상속했는지 혹은 로컬 오버라이드가 있는지 확인하고, 해당 레이아웃을 사용하는 모든 슬라이드에서 테스트하십시오.

## **도형을 SVG로 내보내기**

[WriteAsSvg](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/writeassvg/)은 하나의 도형이 렌더링된 내용을 스트림에 기록합니다. 결과에는 도형만 포함되며 슬라이드 전체 배경이나 주변 도형은 포함되지 않습니다.

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

렌더링 중에는 프레젠테이션을 열어두십시오. 출력은 도형 서식과 글꼴·이미지와 같은 리소스에 따라 달라집니다. 전체 구성이 필요하면 개별 도형이 아니라 슬라이드를 내보내십시오. 호출자는 스트림을 소유하며 반드시 폐기해야 합니다.

## **도형 정렬**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/alignshapes/) 오버로드는 모든 도형 또는 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/net/aspose.slides/shapesalignmenttype/)은 가장자리, 중심선 또는 배치 모드를 지정합니다. `alignToSlide`을 `true`로 설정하면 슬라이드 가장자리를 기준으로, `false`로 설정하면 선택된 도형끼리 상대적으로 정렬합니다.

이 예제는 세 도형을 슬라이드 상단 가장자리에 정렬합니다. 반환된 도형 참조는 정렬 직전에 현재 인덱스로 변환됩니다.

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

정렬은 위치를 변경하지만 z‑order는 변경하지 않습니다. 상대 정렬은 일반적으로 두 개 이상의 도형이 필요하고, 수평·수직 배치는 충분한 도형이 있어야 간격을 정의할 수 있습니다. 메서드 호출 전에 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **도형 뒤집기**

[ShapeFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/shapeframe/) 클래스는 위치, 크기, 수평·수직 뒤집기 설정 및 회전을 저장합니다. `FlipH`와 `FlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/net/aspose.slides/nullablebool/)을 사용하며, `True`는 뒤집기 활성화, `False`는 비활성화, `NotDefined`는 지정되지 않음/기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 뒤집히지 않은 도형 하나가 포함되어 있습니다.

![The shape before flipping](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 유지하면서 두 뒤집기 설정만 교체합니다. 이는 새 [Frame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/frame/)을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

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

저장된 도형은 위치, 크기 및 회전을 유지하면서 수평 및 수직으로 뒤집힙니다.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 도형 식별자로 사용해도 될까요?**

컬렉션이 인덱스 사용 전에 변경되지 않을 경우에만 단기간 처리에만 사용하십시오. 작성된 템플릿에는 검증된 `Name` 또는 `AlternativeText` 규칙을, 슬라이드 범위 인터롭 작업에는 `OfficeInteropShapeId`를 사용하는 것이 좋습니다.

**도형을 숨기면 z‑order에서 제거되나요?**

아니요. 숨긴 도형은 같은 인덱스에 컬렉션에 남아 있습니다. 찾고, 재정렬하고, 편집하거나 다시 표시할 수 있습니다.

**복제된 도형이 다른 도형 앞에 나타난 이유는?**

`AddClone`은 복제를 컬렉션 끝에 추가하므로 z‑order의 앞쪽에 위치합니다. 초기 인덱스를 지정하려면 `InsertClone`을 사용하거나 모든 도형을 추가한 뒤 `Reorder`를 사용하십시오.

**고정 인덱스로 사전 설정 도형 조정을 식별해도 될까요?**

정확한 사전 설정과 컬렉션 레이아웃을 검증한 경우에만 가능합니다. `IGeometryShape.Adjustments`를 반복하면서 `IAdjustValue.Type`을 확인하고, 같은 의미 유형이 여러 번 나타나는 경우 `IAdjustValue.Name`을 추가 정보로 활용하는 것이 좋습니다.