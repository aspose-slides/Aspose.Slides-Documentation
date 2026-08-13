---
title: .NET에서 프레젠테이션의 도형 유효 속성 가져오기
linktitle: 유효 속성
type: docs
weight: 50
url: /ko/net/shape-effective-properties/
keywords:
- 도형 속성
- 카메라 속성
- 라이트 리그
- 베벨 도형
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 형식
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "PowerPoint 프레젠테이션에서 로컬, 상속 및 유효 도형 서식을 구분하는 방법을 Aspose.Slides for .NET을 사용하여 배웁니다."
---
## **로컬, 상속 및 유효 속성 이해**

PowerPoint 서식은 여러 위치에서 올 수 있습니다. 객체에 직접 저장된 값은 **로컬 값**입니다. 해당 값이 설정되지 않으면 PowerPoint는 단락 기본값, 텍스트 스타일, 레이아웃 또는 마스터 슬라이드, 테마, 프레젠테이션 수준 기본값과 같은 상위 서식 소스를 확인합니다. 이러한 값은 **상속 값**입니다. 전체 계층이 해결된 후 남는 값이 **유효 값**이며, 객체를 렌더링하는 데 사용되는 값입니다.

예를 들어, 텍스트 부분이 자체 폰트 높이를 정의하지 않을 수 있습니다. 이 경우 로컬 [FontHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/fontheight/)은 `float.NaN`이며, 이는 "여기에서 설정되지 않음"을 의미합니다. 해당 부분은 단락, 프레젠테이션의 기본 텍스트 스타일 또는 다른 적용 가능한 소스로부터 높이를 상속받을 수 있습니다. 부분 서식에 대해 [GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformat/geteffective/)를 호출하면 최종 해결된 높이가 반환됩니다.

두 가지 서식 데이터를 다른 목적에 사용하십시오:

- 값이 정의된 위치를 제어해야 할 때와 같이 [IPortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformat/)와 같은 로컬 서식 객체를 읽거나 변경합니다.
- 최종 렌더링 결과가 필요할 때와 같이 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformateffectivedata/)와 같은 유효 데이터 객체를 읽습니다. 유효 데이터는 읽기 전용입니다.

## **로컬, 상속 및 유효 값 비교**

다음 전체 예제는 도형을 만들고 프레젠테이션, 단락 및 부분 수준에서 폰트 높이를 적용합니다. 각 단계는 해당 수준에서 정의된 값과 동일한 텍스트 부분에 대한 결과 유효 값을 출력합니다. 또한 서식 변경 후 유효 데이터를 다시 읽어야 하는 이유를 보여줍니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// 두 가지 다른 수준에서 상속된 값을 정의합니다.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// 부분의 로컬 값이 두 상속 값을 모두 무시합니다.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// 상속 값을 변경해도 기존 로컬 값을 대체하지 않습니다.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// 로컬 값을 지웁니다. 이제 부분이 다시 단락에서 상속됩니다.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// 단락 값을 지웁니다. 이제 프레젠테이션 기본값이 결과를 제공합니다.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // 이전 변경 후 유효 데이터를 읽습니다.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

이 예제에서의 우선 순위는 부분 로컬 서식, 그 다음 단락 서식, 그 다음 프레젠테이션 기본값입니다. 다른 객체는 다른 상속 체인을 가질 수 있지만 원리는 동일합니다: 더 구체적인 명시적 값이 승리하고, [GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformat/geteffective/)는 최종 결과를 반환합니다.

## **유효 텍스트 속성 가져오기**

텍스트 서식은 여러 객체에 걸쳐 분할됩니다:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/geteffective/)은 여백, 정렬, 자동 맞춤, 수직 텍스트 방향과 같은 텍스트 프레임 속성을 해결합니다.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/ko/net/aspose.slides/itextstyle/geteffective/)은 각 텍스트 스타일 수준에 대한 단락 서식을 해결합니다.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/geteffective/)은 정렬, 들여쓰기, 글머리표와 같은 단락 속성을 해결합니다.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformat/geteffective/)은 폰트 높이, 글꼴, 색상, 굵게 및 기울임과 같은 문자 속성을 해결합니다.

다음 예제를 위해 `text-formatting.pptx`에는 최소 하나의 슬라이드와 비어 있지 않은 텍스트 프레임을 가진 [AutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/)이 포함되어 있어야 합니다. AutoShape는 도형 컬렉션의 어느 위치에 있어도 될 수 있으며, 코드는 적절한 객체를 찾아 사용하기 전에 검증합니다.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **유효 3D 속성 가져오기**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/geteffective/)은 모든 해결된 3D 설정을 그룹화하는 하나의 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformateffectivedata/) 객체를 반환합니다. 그 [Camera](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformateffectivedata/beveltop/), 및 [BevelBottom](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) 속성은 해당 유효 데이터를 노출합니다. 이러한 관련 설정을 함께 읽으면 도형의 최종 3D 외관을 이해하기가 쉬워집니다.

이 예제를 위해 `shape-3d.pptx`에는 첫 번째 슬라이드에 최소 하나의 도형이 포함되어 있어야 합니다. 기본값이 아닌 값을 포함하려면 해당 도형에 3D 카메라, 조명 또는 베벨 설정을 적용하십시오.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **유효 테이블 서식 가져오기**

테이블 서식은 테이블 스타일과 전체 테이블, 열, 행 또는 개별 셀에 적용된 서식에서 올 수 있습니다. 명시적으로 정의된 채우기 간 충돌이 있을 경우 우선 순위는 셀, 행, 열, 전체 테이블 순입니다. 셀의 유효 서식은 해당 셀을 그리는 데 사용되는 최종 서식입니다.

이 예제를 위해 `table-formatting.pptx`에는 첫 번째 슬라이드에 최소 하나의 테이블이 포함되어 있어야 합니다. 테이블에는 최소 하나의 행과 하나의 열이 있어야 합니다. 코드는 `Shapes[0]`이 테이블이라고 가정하지 않고 [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/)을 검색합니다.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

색상만 필요한 경우, 먼저 유효 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/ifillformateffectivedata/filltype/)을 확인하고, 해당 유형에 적용되는 속성을 읽으십시오—예를 들어, 솔리드 채우기의 경우 [SolidFillColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ifillformateffectivedata/solidfillcolor/)을 읽습니다.

## **변경 후 유효 데이터 다시 읽기**

유효 데이터는 해결 시점의 서식 계층을 설명합니다. 해당 계층에 참여할 수 있는 항목을 변경한 후에는 `GetEffective`를 다시 호출하십시오. 포함 항목:

- 객체의 로컬 서식;
- 단락 또는 텍스트 프레임 기본값;
- 테이블 스타일, 테이블, 열, 행 또는 셀 서식;
- 레이아웃 또는 마스터 슬라이드 서식;
- 테마 데이터 또는 프레젠테이션 수준 기본값;
- 슬라이드에 할당된 레이아웃 또는 마스터.

유효 데이터 객체를 영구 스냅샷으로 보관하지 마십시오. Aspose.Slides는 내부적으로 일부 유효 데이터를 캐시할 수 있으며, 이후 `GetEffective` 호출은 해당 데이터를 새로 고칠 수 있습니다. 변경 전후 값을 비교해야 하는 경우, 변경하기 전에 폰트 높이, 색상, 정렬 또는 베벨 너비와 같은 스칼라 값을 자체 변수에 복사하십시오.

값을 변경하려면 해당 로컬 서식 객체를 업데이트한 뒤 `GetEffective`를 호출해 결과를 확인하십시오. 유효 데이터 객체 자체는 읽기 전용입니다.

## **FAQ**

**유효 값을 제공한 수준을 어떻게 알 수 있나요?**

유효 데이터에는 최종 값만 포함되고 원본은 포함되지 않습니다. 가장 구체적인 수준부터 바깥쪽으로 해당 로컬 객체를 검사하십시오. 텍스트의 경우 부분, 단락, 텍스트 프레임, 레이아웃, 마스터, 테마 및 프레젠테이션 기본값이 포함될 수 있습니다. `float.NaN` 또는 `null`과 같은 정의되지 않은 값은 검색이 다른 수준으로 계속됨을 나타냅니다.

**어떤 수준도 속성을 정의하지 않으면 어떻게 되나요?**

Aspose.Slides는 적절한 PowerPoint 또는 라이브러리 기본값을 해결합니다. 해당 해결된 값은 유효 데이터에 나타나며, 로컬 객체가 명시적으로 정의하지 않아도 됩니다.

**유효 값이 때때로 로컬 값과 같은 이유는 무엇인가요?**

로컬 값이 상속 계산에서 승리했기 때문입니다. 이는 속성이 객체에 명시적으로 설정되어 있고 더 구체적인 규칙이 이를 덮어쓰지 않을 때 기대되는 동작입니다.

**언제 로컬 데이터를 사용하고 유효 데이터를 사용하면 안 될까요?**

특정 서식 수준을 검사하거나 편집하려면 로컬 데이터를 사용하십시오. 상속, 테마 규칙 및 적용 가능한 스타일이 모두 해결된 후 최종 외관이 필요하면 유효 데이터를 사용하십시오. [전체 비교 예제](#compare-local-inherited-and-effective-values)는 동일 워크플로에서 두 가지를 모두 보여 줍니다.