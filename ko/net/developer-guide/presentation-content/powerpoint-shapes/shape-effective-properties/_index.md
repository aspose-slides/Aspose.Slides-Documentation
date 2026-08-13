---
title: .NET에서 프레젠테이션의 도형 Effective 속성 가져오기
linktitle: Effective 속성
type: docs
weight: 50
url: /ko/net/shape-effective-properties/
keywords:
- 도형 속성
- 카메라 속성
- 라이트 릭
- 베벨 도형
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 서식
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET이 정확한 PowerPoint 렌더링을 위해 효과적인 도형 속성을 계산하고 적용하는 방법을 알아보세요."
---
## **개요**

이 문서는 **local** 및 **effective** 속성의 차이를 설명합니다. Local 값은 특정 서식 수준에서 직접 설정된 값이며, 예를 들어:

1. 슬라이드의 Portion 속성.
1. 레이아웃 또는 마스터 슬라이드에 있는 프로토타입 도형 텍스트 스타일, 해당 Portion의 텍스트 프레임 도형에 있는 경우.
1. 프레젠테이션의 전역 텍스트 설정.

Local 값은 어느 수준에서든 정의하거나 생략할 수 있습니다. Aspose.Slides가 최종 "as rendered" 서식이 필요할 때 상속 체인을 해결하고 **effective** 값을 반환합니다. 로컬 서식 개체에서 `GetEffective` 메서드를 호출하면 이를 얻을 수 있습니다.

다음 예제는 effective 값을 얻는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임과 하나 이상의 Portion을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)이라고 가정합니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
Effective formatting data는 상속이 적용된 후 계산된 현재 서식을 나타냅니다. 현재 구현에서는 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformateffectivedata/)와 같은 일부 effective 데이터 객체가 내부에 캐시될 수 있습니다. 상위 또는 상속된 서식을 변경한 후 `GetEffective`를 다시 호출하면 캐시된 데이터를 새로 고칠 수 있으며, 이전에 얻은 객체는 더 이상 이전 상태를 나타내지 않을 수 있습니다. 나중에 재사용을 위해 effective 값을 보존해야 하는 경우, 글꼴 높이, 채우기 색, 글꼴 스타일 또는 정렬과 같은 필요한 속성을 자체 데이터 객체에 복사하십시오.
{{% /alert %}}

## **Get Effective Properties of a Camera**

Aspose.Slides를 사용하면 카메라의 effective 속성을 가져올 수 있습니다. [ICameraEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/icameraeffectivedata/) 인터페이스는 immutable 객체로, effective 카메라 속성을 포함합니다. [ICameraEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/icameraeffectivedata/) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformateffectivedata/)를 통해 노출되며, 이는 [IThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/)에 대한 effective 값을 제공합니다.

다음 코드 샘플은 카메라에 대한 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형에 3D 서식이 적용되어 있다고 가정합니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Get Effective Properties of a Light Rig**

Aspose.Slides를 사용하면 라이트 릭의 effective 속성을 가져올 수 있습니다. [ILightRigEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ilightrigeffectivedata/) 인터페이스는 immutable 객체로, effective 라이트 릭 속성을 포함합니다. [ILightRigEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ilightrigeffectivedata/) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformateffectivedata/)를 통해 노출되며, 이는 [IThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/)에 대한 effective 값을 제공합니다.

다음 코드 샘플은 라이트 릭에 대한 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형에 3D 서식이 적용되어 있다고 가정합니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Get Effective Properties of a Bevel Shape**

Aspose.Slides를 사용하면 도형 베벨의 effective 속성을 가져올 수 있습니다. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapebeveleffectivedata/) 인터페이스는 immutable 객체로, 도형에 대한 effective 면-돌출 속성을 포함합니다. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapebeveleffectivedata/) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformateffectivedata/)를 통해 노출되며, 이는 [IThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/)에 대한 effective 값을 제공합니다.

다음 코드 샘플은 도형 상단 베벨에 대한 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형에 3D 서식이 적용되어 있다고 가정합니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Get Effective Properties of a Text Frame**

Aspose.Slides를 사용하면 텍스트 프레임의 effective 속성을 가져올 수 있습니다. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformateffectivedata/) 인터페이스는 effective 텍스트 프레임 서식 속성을 포함합니다.

다음 코드 샘플은 텍스트 프레임의 effective 서식 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)이라고 가정합니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Get Effective Properties of a Text Style**

Aspose.Slides를 사용하면 텍스트 스타일의 effective 속성을 가져올 수 있습니다. [ITextStyleEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/itextstyleeffectivedata/) 인터페이스는 effective 텍스트 스타일 속성을 포함합니다.

다음 코드 샘플은 텍스트 스타일의 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)이라고 가정합니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Get the Effective Font Height Value**

Aspose.Slides를 사용하면 effective 글꼴 높이를 가져올 수 있습니다. 다음 코드는 프레젠테이션 구조의 서로 다른 수준에서 로컬 글꼴 높이 값을 설정한 후 Portion의 effective 글꼴 높이가 어떻게 변하는지 보여줍니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Get the Effective Fill Format for a Table**

Aspose.Slides를 사용하면 테이블의 다양한 부분에 대한 effective 채우기 서식을 가져올 수 있습니다. [IFillFormatEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ifillformateffectivedata/) 인터페이스는 effective 채우기 서식 속성을 포함합니다. 셀 서식은 행 서식보다 우선순위가 높고, 행 서식은 열 서식보다, 열 서식은 전체 테이블 서식보다 우선합니다.

따라서 [ICellFormatEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/icellformateffectivedata/) 속성이 테이블 셀을 그리는 데 사용됩니다. 다음 코드 샘플은 테이블의 다양한 부분에 대한 effective 채우기 서식을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/)이라고 가정합니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **FAQ**

### `GetEffective` 메서드가 스냅샷을 반환합니까?

항상 그렇지는 않습니다. Effective 데이터는 상속이 적용된 후 계산된 서식을 나타내지만, 일부 effective 데이터 객체는 내부에 캐시될 수 있습니다. `GetEffective`를 다시 호출하면 서식이 재계산되고 캐시된 데이터가 새로 고쳐질 수 있으므로, 이전에 얻은 객체를 영구적인 스냅샷으로 취급하면 안 됩니다.

### 언제 다시 effective 속성을 읽어야 합니까?

로컬 서식, 상위 스타일, 레이아웃 서식, 마스터 서식 또는 프레젠테이션 수준 기본값을 변경한 후 `GetEffective`를 다시 호출하십시오. 다음 호출은 서식 계층을 다시 평가하고 현재의 effective 결과를 반환합니다.

### 레이아웃/마스터 슬라이드를 변경하거나 제거하면 이미 가져온 effective 속성에 영향을 줍니까?

예, 그러나 변경 사항은 다음 `GetEffective` 호출에 반영됩니다. 상위 서식 소스가 변경되거나 제거되면 이전에 얻은 effective 데이터는 오래될 수 있습니다. `GetEffective`를 다시 호출하면 Aspose.Slides가 서식 트리를 다시 평가하고 결과 글꼴, 색상, 크기 또는 기타 값이 변경될 수 있습니다.

### effective 데이터 객체를 통해 값을 수정할 수 있습니까?

아닙니다. Effective 데이터 객체는 계산된 값을 노출합니다. 로컬 서식 객체에서 변경하고 다시 effective 값을 얻으십시오.

### 속성이 도형 수준, 레이아웃/마스터, 전역 설정 어디에도 설정되지 않은 경우 어떻게 됩니까?

effective 값은 PowerPoint 및 Aspose.Slides 기본값을 포함한 기본 메커니즘에 의해 결정됩니다. 결정된 값이 현재 effective 데이터의 일부가 됩니다.

### effective 글꼴 값만 보고 어느 수준에서 크기나 글꼴이 제공됐는지 알 수 있습니까?

직접적으로는 알 수 없습니다. Effective 데이터는 최종 값을 반환합니다. 출처를 찾으려면 Portion, Paragraph, Text Frame 및 레이아웃, 마스터, 프레젠테이션 수준의 텍스트 스타일에서 로컬 값을 확인하여 첫 번째 명시적 정의가 나타나는 위치를 검토하십시오.

### 왜 effective 값이 때때로 로컬 값과 동일하게 보입니까?

로컬 값이 최종값이 되었기 때문입니다(상위 수준의 상속이 필요하지 않았음). 이런 경우 effective 값은 로컬 값과 일치합니다.

### 언제 effective 속성을 사용하고 언제 로컬 속성만 사용해야 합니까?

모든 상속이 적용된 후 “as rendered” 결과가 필요할 때 effective 데이터를 사용하십시오(예: 색상, 들여쓰기, 크기 정렬). 이후 서식 변경과 관계없이 해당 값을 보존해야 하면 필요한 속성을 자체 객체에 복사하십시오. 특정 수준에서 서식을 변경해야 하면 로컬 속성을 수정하고 필요에 따라 effective 데이터를 다시 읽어 결과를 확인하십시오.