---
title: .NET에서 프레젠테이션 모양 관리
linktitle: 모양 조작
type: docs
weight: 40
url: /ko/net/shape-manipulations/
keywords:
- PowerPoint 모양
- 프레젠테이션 모양
- 슬라이드의 모양
- 모양 찾기
- 모양 복제
- 모양 제거
- 모양 숨기기
- 모양 순서 변경
- Interop 모양 ID 가져오기
- 모양 대체 텍스트
- 모양 조정점
- 사전 정의 모양 조정
- 모양 기하학
- 모양 레이아웃 서식
- SVG 형식 모양
- 모양을 SVG로 변환
- 모양 정렬
- 모양 뒤집기
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 프레젠테이션 모양을 식별, 조정, 복제, 제거, 숨기기, 재정렬, 내보내기, 정렬 및 뒤집는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for .NET은 슬라이드의 모양을 순서가 지정된 [IShapeCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/)으로 나타냅니다. 컬렉션은 모양을 찾고 수정하는 장소이자 쌓임 순서의 원천입니다: 인덱스 `0`은 가장 뒤에 있는 모양이며, 마지막 인덱스는 가장 앞에 있는 모양입니다.

이 문서는 해당 모델을 따릅니다. 먼저 모양을 안정적으로 식별하고 사전 정의된 모양 조정점을 수정하는 방법을 설명하고, 그 다음 클론, 제거, 숨기기 및 재정렬 방법을 보여줍니다. 마지막 섹션에서는 레이아웃 수준 서식, SVG 내보내기, 정렬 및 뒤집기 설정을 다룹니다. 각 예제는 독립적이므로 워크플로우에 필요한 작업만 사용할 수 있습니다.

## **모양 식별 및 찾기**

컬렉션 인덱스는 알려진 파일을 처리할 때 편리하지만 안정적인 식별자는 아닙니다. 모양을 추가, 제거 또는 재정렬하면 인덱스가 변경될 수 있습니다. 프레젠테이션이 어떻게 작성·유지되는지에 따라 식별자를 선택하십시오:

- [Name](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/name/)은 개발자가 제어하는 템플릿에 유용하며 PowerPoint 선택 창에서 쉽게 확인할 수 있습니다. 이름은 편집 가능하지만 고유성을 보장하지 않으므로 코드가 이름에 의존한다면 명명 규칙을 정하십시오.
- [AlternativeText](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/alternativetext/)은 접근성 설명이나 작성자가 제공한 태그가 이미 모양을 식별하는 경우에 유용합니다. 사용자가 볼 수 있고 현지화되거나 접근성을 위해 다시 작성될 수 있지만 고유성을 보장하지 않습니다. 의미 있는 접근성 텍스트를 데이터베이스 키로 은밀히 재사용하지 마십시오.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/officeinteropshapeid/)은 읽기 전용 식별자로 슬라이드 내에서 고유하며 PowerPoint Interop에서 사용되는 모양 ID와 일치합니다. PowerPoint와 통합하거나 모양 수명 동안 명확한 참조가 필요할 때 사용하십시오. 복제되거나 다시 생성된 모양은 다른 모양이며 자체 ID를 받습니다.

관련 [UniqueId](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/uniqueid/) 속성은 프레젠테이션 범위를 갖지만, 애드인 용도로 의도되었으며 재할당될 수 있습니다. 영구적인 외부 키로 취급해서는 안 됩니다. 장기적인 정체성이 필수라면 응용 프로그램 데이터에 매핑을 보관하고 기대한 모양이 여전히 존재하는지 검증하십시오.

다음 예제는 `Name`을 서수 비교로 검색하고 슬라이드 범위의 Interop ID를 보고합니다. 템플릿에 기대하는 모양이 없으면 코드는 잘못된 객체로 계속 진행하는 대신 해당 결과를 보고합니다.

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

작업이 특정 모양 유형에 국한되는 경우 타입 전용 멤버를 사용하기 전에 인터페이스를 확인하십시오. 이 예제는 명명된 객체가 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)인 경우에만 텍스트와 대체 텍스트를 업데이트합니다.

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

## **사전 정의된 모양 조정 식별 및 수정**

사전 정의 기하학 모양은 모서리 크기, 화살표 비율 또는 호 각도와 같은 기능을 제어하는 조정점을 노출할 수 있습니다. 읽기 전용 [IGeometryShape.Adjustments](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometryshape/adjustments/) 컬렉션을 통해 접근하십시오. 컬렉션 자체는 모양에 의해 제공되지만 각 [IAdjustValue](https://reference.aspose.com/slides/ko/net/aspose.slides/iadjustvalue/)는 변경 가능한 값을 포함합니다.

고정된 컬렉션 인덱스에만 의존하지 마십시오. 조정을 반복하면서 읽기 전용 [Type](https://reference.aspose.com/slides/ko/net/aspose.slides/adjustvalue/type/) 속성을 검사하십시오. 이 속성의 [ShapeAdjustmentType](https://reference.aspose.com/slides/ko/net/aspose.slides/shapeadjustmenttype/) 값은 조정이 제어하는 내용을 설명합니다. 읽기 전용 [Name](https://reference.aspose.com/slides/ko/net/aspose.slides/adjustvalue/name/) 속성은 추가 식별 정보를 제공하며, 동일한 의미 유형을 가진 조정이 여러 개 있는 경우 특히 유용합니다.

조정 의미에 맞는 값 속성을 사용하십시오:

| 조정 유형 | 목적 | 변경할 값 |
|---|---|---|
| `CornerSize` | 둥근 모서리 크기 | [RawValue](https://reference.aspose.com/slides/ko/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | 화살표 꼬리 두께 | `RawValue` |
| `ArrowheadLength` | 화살표 머리 길이 | `RawValue` |
| `ArrowheadWidth` | 화살표 머리 너비 | `RawValue` |
| `StartAngle` | 파이 또는 호의 시작 각도 | [AngleValue](https://reference.aspose.com/slides/ko/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | 파이 또는 호의 종료 각도 | `AngleValue` |

`Type`과 `Name`은 할당할 수 없습니다. `RawValue`는 사전의 고유 기하학 단위에 대한 읽기/쓰기 정수이며, `AngleValue`는 도 단위의 읽기/쓰기 각도입니다. 조정의 개수, 순서, 의미 및 허용 범위는 사전 [ShapeType](https://reference.aspose.com/slides/ko/net/aspose.slides/igeometryshape/shapetype/)에 따라 다릅니다. 한 사전에서 유효한 값이 다른 사전에서는 무효이거나 다른 효과를 가질 수 있습니다.

`Type`이 `ShapeAdjustmentType.Custom`인 경우 API는 표준 의미를 인식하지 못합니다. `Name`, 사전 유형 및 기존 값을 검사하고 기대하는 의미와 범위가 알려진 경우에만 조정을 변경하십시오. 인식된 유형이라도 동일한 유형이 여러 번 나타나는지 확인한 후 값을 선택하십시오. [Connector](/slides/ko/net/connector/) 문서는 연결자 굽힘 조정 상황을 보여줍니다.

다음 완전한 예제는 세 가지 사전 정의 모양의 기본 및 수정 버전을 생성합니다. 모든 조정을 반복하면서 `Name`과 `Type`을 보고, `RawValue`를 통해 크기 관련 값을 변경하고, `AngleValue`를 통해 각도를 변경하며 결과를 저장합니다. 왼쪽 열은 기본 기하학을 유지하고, 오른쪽 열은 조정된 둥근 사각형, 네 방향 화살표 및 파이를 보여줍니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// 기본 및 조정된 모양 열에 대한 헤더를 추가합니다.
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

값을 변경하기 전에 의미 유형을 확인하면 코드가 의도를 명확히 하며, 다른 사전 모양 간에 동일한 컬렉션 인덱스가 같은 의미를 가진다고 가정하는 실수를 방지합니다.

## **모양 컬렉션 수정**

추가, 복제, 제거 및 재정렬 메서드는 컬렉션에 즉시 적용됩니다. 작업으로 인해 모양 수나 순서가 변경되면 해당 작업 이전에 캡처한 인덱스에 계속 의존하지 마십시오.

### **모양 복제**

[AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addclone/)은 독립적인 복사본을 만들고 대상 컬렉션에 추가합니다. [InsertClone](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/insertclone/)도 복사본을 만들지만 지정된 Z 순서 인덱스에 배치합니다. 좌표를 받아들이는 오버로드는 크기를 변경하지 않고 복제본을 이동하고, 너비와 높이를 받아들이는 오버로드는 크기도 조정합니다.

예제는 대상 슬라이드를 만들고 라벨이 지정된 사각형을 앞쪽에 복제한 뒤, 두 번째 복제본을 뒤쪽에 삽입합니다. 두 복제본 중 어느 쪽을 변경해도 원본 모양은 수정되지 않습니다.

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

복제는 모양의 내용과 서식, 이름 및 대체 텍스트까지 복사합니다. 이러한 값이 고유해야 한다면 복제본에 새로운 논리적 식별자를 할당하십시오. 복잡한 모양이 사용하는 리소스는 프레젠테이션에서 관리하지만, 복제본은 새 컬렉션 항목이며 새로운 모양 정체성을 가집니다.

### **모양 제거**

[Remove](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/remove/)은 특정 모양 객체를 컬렉션에서 삭제합니다. 인덱스 순회 중에 여러 일치를 제거할 경우, 남은 인덱스가 유효하도록 끝에서부터 탐색하십시오.

이 예제는 지정된 이름을 가진 모든 모양을 제거합니다. 고정된 컬렉션 항목이 아니라 `slide.Shapes[i]`를 읽고, 불필요한 형변환도 하지 않습니다.

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

제거 후에는 모양 수와 이후 모양들의 인덱스가 변경됩니다. 영향을 받지 않은 모양에 대한 참조는 저장된 인덱스보다 더 신뢰할 수 있습니다. 또한 연결자, 애니메이션 및 기타 프레젠테이션 기능이 제거된 객체를 참조할 수 있음을 고려하십시오; 보이는 모양을 제거하면 슬라이드 외관 이상으로 변경될 수 있습니다.

### **모양 숨기기**

[Hidden](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/hidden/)을 `true`로 설정하면 모양이 컬렉션에 남아 있지만 일반 슬라이드 쇼에 표시되지 않습니다. 인덱스, 서식 및 내용은 코드에서 계속 접근 가능하므로, 나중에 복구할 수 있는 선택적 요소에 적합합니다.

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

숨기기는 삭제나 보안이 아닙니다. 사용자가나 코드가 여전히 발견하고 다시 표시할 수 있으며 프레젠테이션 파일의 일부로 남아 있습니다.

### **Z-순서 변경**

중첩된 모양은 컬렉션 순서대로 그려집니다. [Reorder](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/reorder/)는 복제 없이 기존 모양을 대상 인덱스로 이동합니다. 인덱스 `0`은 뒤쪽, `Count - 1`은 앞쪽입니다.

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

사각형을 먼저 만들면 초기에는 타원 뒤에 위치합니다. 최종 인덱스로 이동하면 앞쪽에 놓이게 됩니다. 모든 관련 모양을 추가하거나 복제한 후에 Z-순서를 최종 확정하십시오. 이러한 작업은 새로운 컬렉션 항목을 추가하거나 삽입하여 스택을 변경할 수 있기 때문입니다.

## **레이아웃 슬라이드의 모양 검사**

일반 슬라이드, 레이아웃 슬라이드 및 마스터 슬라이드는 각각 별도 모양 컬렉션을 가집니다. 레이아웃 컬렉션의 모양은 일반 슬라이드의 같은 위치에 있는 모양과 동일 객체가 아닙니다. 레이아웃이 제공하는 서식을 이해하거나 변경해야 할 때 레이아웃 모양을 검사하십시오.

다음 예제는 각 레이아웃 모양의 [FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/fillformat/) 및 [LineFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/lineformat/)을 읽으며, 모든 모양이 `AutoShape`이라고 가정하지 않습니다.

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

레이아웃을 편집하면 이를 사용하는 여러 슬라이드에 영향을 줄 수 있습니다. 레이아웃 모양을 변경하기 전에 일반 슬라이드가 해당 객체를 상속하는지 혹은 로컬 오버라이드가 있는지 판단하고, 해당 레이아웃을 사용하는 모든 슬라이드를 테스트하십시오.

## **모양을 SVG로 내보내기**

[WriteAsSvg](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/writeassvg/)은 하나의 모양이 렌더링된 내용을 스트림에 기록합니다. 결과에는 모양만 포함되며 전체 슬라이드 배경이나 인접 모양은 포함되지 않습니다.

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

렌더링하는 동안 프레젠테이션을 열어 두십시오. 출력은 모양의 서식과 폰트·이미지와 같은 리소스에 따라 달라집니다. 전체 구성을 원한다면 개별 모양이 아니라 슬라이드를 내보내십시오. 호출자는 스트림을 소유하며 반드시 해제해야 합니다.

## **모양 정렬**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/alignshapes/) 오버로드는 모든 모양 또는 선택된 컬렉션 인덱스를 정렬합니다. [ShapesAlignmentType](https://reference.aspose.com/slides/ko/net/aspose.slides/shapesalignmenttype/)은 가장자리, 중심선 또는 분배 모드를 지정합니다. `alignToSlide`을 `true`로 설정하면 슬라이드 가장자리를 기준으로, `false`로 설정하면 선택된 모양들 간의 상대 정렬을 수행합니다.

이 예제는 세 모양을 슬라이드 상단 가장자리에 정렬합니다. 반환된 모양 참조는 정렬 직전에 현재 인덱스로 변환됩니다.

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

정렬은 위치만 변경하고 Z-순서는 변경하지 않습니다. 상대 정렬은 일반적으로 최소 두 개의 모양이 필요하고, 수평·수직 분배는 간격을 정의할 충분한 모양이 필요합니다. 메서드를 호출하기 전에 컬렉션을 수정했다면 인덱스를 다시 계산하십시오.

## **모양 뒤집기**

[ShapeFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/shapeframe/) 클래스는 위치, 크기, 가로·세로 뒤집기 설정 및 회전을 저장합니다. `FlipH`와 `FlipV` 값은 [NullableBool](https://reference.aspose.com/slides/ko/net/aspose.slides/nullablebool/)을 사용합니다: `True`는 뒤집기를 활성화하고, `False`는 비활성화하며, `NotDefined`는 지정되지 않은/기본 상태를 유지합니다.

아래 입력 프레젠테이션에는 뒤집히지 않은 모양이 하나 포함되어 있습니다.

![The shape before flipping](shape_to_be_flipped.png)

예제는 다른 모든 프레임 값을 유지하고 두 뒤집기 설정만 교체합니다. 이는 새로운 [Frame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/frame/)을 할당하면 전체 프레임이 교체되기 때문에 중요합니다.

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

저장된 모양은 위치, 크기 및 회전을 유지하면서 가로·세로로 대칭됩니다.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**컬렉션 인덱스를 모양 식별자로 사용해도 될까요?**

컬렉션이 인덱스 사용 전에 변경되지 않을 일시적인 처리에만 사용하십시오. 작성된 템플릿에는 검증된 `Name` 또는 `AlternativeText` 규칙을, 슬라이드 범위 Interop 작업에는 `OfficeInteropShapeId`를 선호하십시오.

**모양을 숨기면 Z-순서에서 제거되나요?**

아니오. 숨겨진 모양은 동일 인덱스에 컬렉션에 남아 있습니다. 찾고, 재정렬하고, 편집하거나 다시 표시할 수 있습니다.

**복제된 모양이 다른 모양 앞에 나타난 이유는?**

`AddClone`은 복제본을 컬렉션 끝에 추가하므로 Z-순서의 앞쪽에 배치됩니다. 초기 인덱스를 지정하려면 `InsertClone`을 사용하거나 모든 모양을 추가한 후 `Reorder`를 사용하십시오.

**고정 인덱스로 사전 정의 모양 조정을 식별할 수 있나요?**

정확한 사전 및 컬렉션 레이아웃을 검증한 경우에만 가능합니다. `IGeometryShape.Adjustments`를 반복하고 `IAdjustValue.Type`을 확인하는 방식을 선호하십시오; 동일한 의미 유형이 여러 번 나타날 경우 `IAdjustValue.Name`을 추가 정보로 사용하십시오.