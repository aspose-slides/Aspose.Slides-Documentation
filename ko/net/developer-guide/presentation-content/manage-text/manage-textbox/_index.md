---
title: .NET에서 프레젠테이션 텍스트 상자 관리
linktitle: 텍스트 상자 관리
type: docs
weight: 20
url: /ko/net/manage-textbox/
keywords:
- 텍스트 상자
- 텍스트 프레임
- 텍스트 추가
- 텍스트 업데이트
- 텍스트 상자 만들기
- 텍스트 상자 확인
- 텍스트 열 추가
- 하이퍼링크 추가
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 상자를 생성, 식별, 형식 지정 및 업데이트합니다."
---
## **소개**

.NET용 Aspose.Slides에서 슬라이드 텍스트는 도형에 속하는 텍스트 프레임에 저장됩니다. [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 인터페이스는 가장 일반적인 텍스트 포함 도형을 나타내며 텍스트를 [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) 속성을 통해 노출합니다.

{{% alert color="info" title="Note" %}}
모든 자동 도형은 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)을 구현하지만, 모든 도형이 자동 도형이거나 텍스트 프레임을 지원하는 것은 아닙니다. 기존 프레젠테이션을 처리할 때, 텍스트에 접근하기 전에 도형이 `IAutoShape`을 구현하는지 확인하십시오.
{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

텍스트 상자를 만들려면 슬라이드에 자동 도형을 추가하고, 해당 텍스트 프레임에 텍스트를 넣은 뒤 프레젠테이션을 저장합니다. 다음 예제는 직사각형 텍스트 상자를 생성합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

[IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/)에 전달되는 좌표와 크기는 포인트 단위로 측정됩니다. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/)은 제공된 텍스트로 텍스트 프레임을 초기화합니다.

## **텍스트 상자 도형 확인**

[AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) 속성을 사용하여 자동 도형이 텍스트 상자로 처리되는지 확인합니다. 프레젠테이션에 텍스트가 포함된 자동 도형과 순수 그래픽 자동 도형이 모두 포함된 경우에 유용합니다.

![텍스트 상자와 도형](istextbox.png)

다음 예제는 프레젠테이션의 모든 자동 도형을 검사합니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

새로 추가된 자동 도형은 비어 있지 않은 텍스트가 포함될 때까지 텍스트 상자로 간주되지 않습니다. 해당 텍스트는 [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) 또는 [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/)을 통해 제공할 수 있습니다. 빈 문자열을 추가하거나 할당하면 `IsTextBox`는 `false`로 유지됩니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

첫 두 호출은 `True`를 출력하고, 마지막 두 호출은 `False`를 출력합니다.

## **텍스트 프레임을 소유하는 도형 찾기**

일반 텍스트 처리 코드는 해당 텍스트 프레임이 어느 프레젠테이션 객체에 포함되어 있는지 모른 채 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)을 받을 수 있습니다. 읽기 전용 [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) 속성을 사용하여 소유하는 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)으로 다시 이동합니다.

자동 도형이나 다른 텍스트 포함 도형이 소유한 텍스트 프레임의 경우, `ParentShape`에 소유자가 들어 있으며 [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/)은 `null`입니다. 접근하기 전에 반환값을 확인하십시오. 도형 및 표 셀 소유자를 모두 식별하려면, SmartArt 노드와 연결된 도형을 포함하여, [Search and Replace Text](/slides/ko/net/search-and-replace-text/)를 참조하십시오.

## **도형의 텍스트 사각형 얻기**

.NET용 Aspose.Slides 26.11부터, [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/)은 부모 도형의 기하학으로 정의된 텍스트 영역을 반환합니다. 좌표와 크기는 포인트 단위이며 해당 도형의 왼쪽 상단 모서리를 기준으로 합니다. 예를 들어, 타원은 외부 경계보다 작은 텍스트 사각형을 가집니다.

이 사각형은 도형을 나타내며, 렌더링된 문자와는 관계가 없습니다. 텍스트나 텍스트 프레임 여백을 변경해도 차지된 텍스트의 측정값이 되지는 않습니다. 렌더링된 텍스트 측정을 위해서는 [paragraph bounds](/slides/ko/net/paragraph-bounds/) 또는 [portion bounds](/slides/ko/net/portion-bounds/)를 사용하십시오.

[Aspose.Slides for .NET](/slides/ko/net/installation/) 26.11 이상을 설치한 후, 이 예제를 실행하면 기하학 텍스트 사각형을 빨간색으로 그릴 수 있습니다. 도형은 회전되지 않고 그룹화되지 않았으므로, X/Y 위치를 추가하면 슬라이드에 오버레이를 배치하기에 충분합니다.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

위의 200 × 100 포인트 도형에 대해 사각형은 `(0, 0, 200, 100)`을 반환하고, 타원은 대략 `(29.289, 14.645, 141.421, 70.711)`을 반환합니다. 이 메서드는 사용자 정의 기하학에서 선언된 텍스트 사각형도 읽습니다. 슬라이드 공간 회전이나 그룹 변환은 적용되지 않으므로, 오버레이 위치 지정 시 별도로 고려해야 합니다. 표 셀 텍스트 프레임과 같이 기하학 도형이 없는 텍스트 프레임은 `InvalidOperationException`을 발생시킬 수 있습니다.

## **텍스트 상자에 열 추가**

[ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) 속성은 텍스트 프레임을 열로 나누고, [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/)은 열 사이의 간격을 포인트 단위로 설정합니다. 두 설정은 [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/)에 속하며 기존 텍스트 상자의 텍스트 프레임을 통해 변경할 수 있습니다. 텍스트는 같은 도형 내에서 열 사이에 다시 흐르며, 다른 도형으로 이어지지는 않습니다.

다음 예제는 열 사이에 10 포인트 간격을 두고 3열 텍스트 상자를 생성한 뒤 프레젠테이션을 저장하고, 출력 파일에서 저장된 설정을 다시 읽어옵니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **개별 열에서 텍스트 추출**

기존 텍스트 프레임에서 각 시각적 열에 할당된 텍스트를 가져오려면 [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/)을 사용합니다. 이 메서드는 열 기반 읽기 순서대로 각 열마다 하나의 문자열을 반환합니다. 단일 열 텍스트 프레임은 요소가 하나인 배열을 생산하고, 빈 열은 빈 문자열로 표시됩니다. 반환된 문자열은 순수 텍스트만 포함하며, 구간 수준 서식은 보존되지 않습니다.

다음과 같은 경우에 유용합니다:
- 열 기반 읽기 순서를 유지하면서 텍스트를 추출합니다.
- 다중 열 슬라이드의 콘텐츠를 색인화하거나 비교합니다.
- 각 열을 별도의 파일, 데이터베이스 필드 또는 기타 대상에 내보냅니다.
- [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), 글꼴 또는 텍스트 프레임 크기를 변경한 후 텍스트가 어떻게 재배분되는지 확인합니다.

이 메서드는 현재 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 내에 배분된 텍스트를 보고하며, 별도의 도형이나 텍스트 상자 간에 자동으로 텍스트를 흐르게 하지 않습니다. 열 배분은 사용 가능한 글꼴 및 기타 텍스트 레이아웃 설정에 따라 달라질 수 있으므로, 일관된 결과가 필요할 때는 필요한 글꼴이 제공되는지 확인하십시오.

다음 예제는 프레젠테이션을 로드하고, 텍스트 프레임이 있는 첫 번째 다중 열 자동 도형을 찾아 구성된 열 수를 읽은 뒤, 각 열의 텍스트를 별도의 파일에 기록합니다. 텍스트 프레임을 제공하지 않는 도형은 건너뜁니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **텍스트 업데이트**

프레젠테이션 전체의 텍스트를 업데이트하려면 슬라이드와 도형을 순회하면서 자동 도형을 선택하고, 해당 텍스트 구간을 편집합니다. 구간 수준에서 작업하면 텍스트와 문자 서식을 모두 변경할 수 있습니다.

다음 예제는 자동 도형 텍스트에서 `years`를 모두 `months`로 바꾸고, 영향을 받은 각 구간을 굵게 만듭니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

이 순회는 자동 도형의 텍스트만 업데이트합니다. 표, 차트, SmartArt 또는 그룹화된 도형에 저장된 텍스트는 해당 객체의 컬렉션을 순회해야 수정할 수 있습니다.

## **하이퍼링크가 있는 텍스트 상자 추가**

하이퍼링크는 특정 텍스트 구간에 할당할 수 있어 해당 텍스트만 클릭 가능한 링크가 됩니다. [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)을 사용하여 구간을 외부 URL에 연결합니다.

다음 예제는 링크가 걸린 텍스트를 생성하고 프레젠테이션에 저장합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **FAQ**

**텍스트 상자와 마스터 또는 레이아웃 슬라이드의 텍스트 자리표시자와의 차이점은 무엇입니까?**

[placeholder](/slides/ko/net/manage-placeholder/)는 [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) 또는 [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/)에서 위치와 서식을 상속받을 수 있습니다. 일반 텍스트 상자는 생성된 슬라이드에 독립적인 도형이며, 레이아웃이 변경되어도 자리표시자 동작을 획득하지 않습니다.

**차트, 표 또는 SmartArt의 텍스트를 변경하지 않고 텍스트를 교체하려면 어떻게 해야 합니까?**

Update Text 예제와 같이 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)을 구현하는 도형으로 순회를 제한하십시오. 차트, 표 및 SmartArt는 자체 객체 모델에 텍스트를 저장하므로 해당 루프에 의해 수정되지 않습니다.