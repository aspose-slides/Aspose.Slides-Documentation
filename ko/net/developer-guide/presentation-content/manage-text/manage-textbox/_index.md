---
title: .NET에서 프레젠테이션의 텍스트 상자 관리
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
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트 상자를 만들고, 식별하고, 서식 지정하며, 업데이트합니다."
---
## **소개**

Aspose.Slides for .NET에서 슬라이드 텍스트는 모양에 속하는 텍스트 프레임에 저장됩니다. The [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/) 인터페이스는 가장 일반적인 텍스트가 포함된 모양을 나타내며, 해당 텍스트는 [IAutoShape.TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/textframe/) 속성을 통해 노출됩니다.

{{% alert color="info" title="Note" %}}
모든 자동 모양은 IShape를 구현하지만, 모든 모양이 자동 모양이거나 텍스트 프레임을 지원하는 것은 아닙니다. 기존 프레젠테이션을 처리할 때는 텍스트에 접근하기 전에 해당 모양이 `IAutoShape`를 구현하는지 확인하십시오.
{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

텍스트 상자를 만들려면 슬라이드에 자동 모양을 추가하고, 해당 텍스트 프레임에 텍스트를 삽입한 다음 프레젠테이션을 저장합니다. 다음 예제는 사각형 텍스트 상자를 생성합니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

[IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addautoshape/)에 전달되는 좌표와 크기는 포인트 단위로 측정됩니다. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/addtextframe/)은 제공된 텍스트로 텍스트 프레임을 초기화합니다.

## **텍스트 상자 모양 확인**

[AutoShape.IsTextBox](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/istextbox/) 속성을 사용하여 자동 모양이 텍스트 상자로 간주되는지 여부를 판단합니다. 프레젠테이션에 텍스트가 포함된 자동 모양과 순수 그래픽 자동 모양이 모두 포함된 경우 유용합니다.

![A text box and a shape](istextbox.png)

다음 예제는 프레젠테이션의 모든 자동 모양을 검사합니다:

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

새로 추가된 자동 모양은 비어 있지 않은 텍스트를 포함하기 전까지는 텍스트 상자로 간주되지 않습니다. 해당 텍스트는 [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/addtextframe/) 또는 [ITextFrame.Text](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/text/)를 통해 제공할 수 있습니다. 빈 문자열을 추가하거나 할당하면 `IsTextBox`가 `false`로 유지됩니다:

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

첫 번째와 두 번째 호출은 `True`를 출력하고, 마지막 두 호출은 `False`를 출력합니다.

## **텍스트 프레임을 소유한 모양 찾기**

일반적인 텍스트 처리 코드는 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)을 받지만 해당 프레임을 포함하는 프레젠테이션 객체를 알지 못할 수 있습니다. 읽기 전용 [ITextFrame.ParentShape](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/parentshape/) 속성을 사용하여 소유하는 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/)로 돌아갈 수 있습니다.

자동 모양이나 다른 텍스트가 포함된 모양이 소유한 텍스트 프레임의 경우, `ParentShape`에 소유자가 들어 있으며 [ITextFrame.ParentCell](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/parentcell/)은 `null`입니다. 접근하기 전에 반환된 값을 확인하십시오. 모양과 표 셀 소유자를 모두 식별하려면, SmartArt 노드와 연결된 모양을 포함하여, [Search and Replace Text](/slides/ko/net/search-and-replace-text/)를 참조하십시오.

## **텍스트 상자에 열 추가**

[ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/columncount/) 속성은 텍스트 프레임을 여러 열로 나누고, [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/columnspacing/)은 열 사이의 간격을 포인트 단위로 설정합니다. 두 설정 모두 [ITextFrameFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/)에 속하며 기존 텍스트 상자의 텍스트 프레임을 통해 변경할 수 있습니다. 텍스트는 같은 모양 내부의 열 사이에서 흐르며, 다른 모양으로 이어지지는 않습니다.

다음 예제는 열 사이에 10포인트 간격을 두고 3열 텍스트 상자를 생성한 뒤, 프레젠테이션을 저장하고 출력 파일에서 저장된 설정을 다시 읽어옵니다:

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

[TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/splittextbycolumns/)를 사용하여 기존 텍스트 프레임에서 각 시각적 열에 할당된 텍스트를 가져올 수 있습니다. 이 메서드는 열 기반 읽기 순서대로 각 열에 대해 하나의 문자열을 반환합니다. 단일 열 텍스트 프레임은 요소가 하나인 배열을 반환하고, 빈 열은 빈 문자열로 표시됩니다. 반환된 문자열은 순수 텍스트만 포함하며, 부분 수준 서식은 유지되지 않습니다.

이 기능은 다음과 같은 경우에 유용합니다:

- 열 기반 읽기 순서를 유지하면서 텍스트를 추출해야 할 때.
- 다열 슬라이드의 내용을 인덱싱하거나 비교할 때.
- 각 열을 별도의 파일, 데이터베이스 필드 또는 다른 대상으로 내보낼 때.
- [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/columnspacing/), 글꼴 또는 텍스트 프레임 크기를 변경한 후 텍스트가 어떻게 재배분되는지 검토할 때.

이 메서드는 현재 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 내부에 배분된 텍스트를 보고하며, 별도 모양이나 텍스트 상자 사이에 텍스트를 자동으로 흐르게 하지는 않습니다. 열 배분은 사용 가능한 글꼴 및 기타 텍스트 레이아웃 설정에 따라 달라질 수 있으므로, 일관된 결과가 중요한 경우 필요한 글꼴이 확보되어 있는지 확인하십시오.

다음 예제는 프레젠테이션을 로드하고, 텍스트 프레임이 있는 최초의 다열 자동 모양을 찾은 뒤, 설정된 열 개수를 읽고, 각 열의 텍스트를 별도의 파일에 기록합니다. 텍스트 프레임을 제공하지 않는 모양은 건너뜁니다.

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

프레젠테이션 전체의 텍스트를 업데이트하려면 슬라이드와 모양을 순회하면서 자동 모양을 선택하고 해당 텍스트 부분을 편집합니다. 부분 수준에서 작업하면 텍스트와 문자 서식을 모두 변경할 수 있습니다.

다음 예제는 자동 모양 텍스트에서 모든 `years`를 `months`로 교체하고, 영향을 받은 각 부분을 굵게 만듭니다:

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

이 순회는 자동 모양의 텍스트만 업데이트합니다. 표, 차트, SmartArt 또는 그룹화된 모양에 저장된 텍스트를 수정하려면 해당 객체들의 컬렉션을 별도로 순회해야 합니다.

## **하이퍼링크가 있는 텍스트 상자 추가**

하이퍼링크는 특정 텍스트 부분에 할당할 수 있어 해당 텍스트만 클릭 가능한 링크가 됩니다. [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/ko/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)을 사용하여 그 부분을 외부 URL에 연결합니다.

다음 예제는 링크가 설정된 텍스트를 생성하고 이를 프레젠테이션에 저장합니다:

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

**마스터 또는 레이아웃 슬라이드의 텍스트 상자와 텍스트 자리표시자(placeholder)의 차이점은 무엇인가요?**

A [placeholder](/slides/ko/net/manage-placeholder/) can inherit its position and formatting from a [master slide](https://reference.aspose.com/slides/ko/net/aspose.slides/masterslide/) or [layout slide](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutslide/). A regular text box is an independent shape on the slide where it was created and does not acquire placeholder behavior when the layout changes.

**차트, 표 또는 SmartArt의 텍스트를 변경하지 않고 텍스트만 교체하려면 어떻게 해야 하나요?**

Limit the traversal to shapes that implement [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/), as shown in the Update Text example. Charts, tables, and SmartArt store text in their own object models, so they are not modified by that loop.