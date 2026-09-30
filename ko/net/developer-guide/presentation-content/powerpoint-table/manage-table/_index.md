---
title: ".NET에서 프레젠테이션 표 관리"
linktitle: "표 관리"
type: docs
weight: 10
url: /ko/net/manage-table/
keywords:
- "표 추가"
- "표 만들기"
- "표 접근"
- "가로 세로 비율"
- "텍스트 정렬"
- "텍스트 서식"
- "표 스타일"
- "PowerPoint"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 슬라이드에서 표를 만들고 편집합니다. 표 작업 흐름을 간소화하는 간단한 C# 코드 예제를 확인하세요."
---
## **소개**

PowerPoint의 표는 정보를 행과 열로 조직하여 값을 읽고 비교하기 쉽게 합니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) 클래스, [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 인터페이스, [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) 클래스, [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) 인터페이스 및 기타 유형을 제공하여 프레젠테이션에서 표를 만들고, 업데이트하고, 관리할 수 있게 합니다.

## **처음부터 표 만들기**

표의 위치와 열 너비, 행 높이를 지정하여 표를 생성합니다. 슬라이드에 추가한 후 셀 테두리를 서식 지정하고, 셀을 병합하고, 텍스트를 삽입할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 포인트 단위의 열 너비 배열을 정의합니다.
4. 포인트 단위의 행 높이 배열을 정의합니다.
5. 슬라이드에 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 객체를 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 메서드를 통해 추가합니다.
6. 각 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)을 반복하여 상단, 하단, 오른쪽, 왼쪽 테두리 서식을 적용합니다.
7. 표 첫 번째 행의 첫 두 셀을 병합합니다.
8. 병합된 셀을 해당 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) 속성을 통해 접근합니다.
9. 병합된 셀에 텍스트를 설정합니다.
10. 수정된 프레젠테이션을 저장합니다.

아래 예제는 (100, 50) 포인트 위치에 3개의 열과 5개의 행으로 표를 생성합니다. 빨간색 테두리(두께 5 포인트)를 적용하고, 첫 번째 행의 첫 두 셀을 병합한 뒤 결과를 `table.pptx` 파일로 저장합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **표준 표에서 번호 매기기**

표준 표에서 셀 인덱스는 0부터 시작하며 (열, 행) 순서를 사용합니다. 첫 번째 셀은 (0, 0)으로 인덱스됩니다.

예를 들어, 4열 4행 표의 셀은 다음과 같이 번호가 매겨집니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

이 예제는 위에 표시된 4 × 4 표를 생성하며, 열 너비와 행 높이는 70 포인트, 빨간색 셀 테두리 두께는 5 포인트입니다. 좌표는 셀 인덱스를 나타냅니다; 예제는 셀을 비워 두고 표를 `StandardTables_out.pptx` 파일로 저장합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **기존 표에 접근하기**

표는 슬라이드의 도형 컬렉션에 저장됩니다. 도형을 순회하여 표를 찾은 다음, [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 인터페이스를 사용해 셀을 읽거나 업데이트합니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 로드합니다.
2. 인덱스로 표가 포함된 슬라이드에 대한 참조를 가져옵니다.
3. [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 객체를 순회하며 표를 찾을 때까지 진행합니다. 슬라이드에 여러 표가 있는 경우, [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/)를 사용해 필요한 표를 식별합니다.
4. 대상 셀의 텍스트를 업데이트합니다.
5. 수정된 프레젠테이션을 저장합니다.

아래 예제는 `UpdateExistingTable.pptx` 파일을 열어 첫 번째 슬라이드에서 첫 번째 표를 찾습니다. 열 0, 행 1 위치의 셀을 `New`로 설정하고 결과를 `table1_out.pptx` 파일로 저장합니다. 입력 파일에는 최소 하나의 슬라이드가 있어야 하며, 해당 슬라이드의 첫 번째 표는 최소 하나의 열과 두 개의 행을 가져야 합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

기존 표에서 행 크기를 조정하고 실제 높이가 요청된 최소값을 초과할 수 있는 이유를 이해하려면 [Control Row Height](/slides/ko/net/manage-rows-and-columns/#control-row-height)를 참조하세요.

## **텍스트 프레임을 포함하는 셀 찾기**

일반 텍스트 처리 코드가 표에서 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)을 받을 경우, [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) 속성을 사용해 해당 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)을 가져옵니다. 표 셀의 텍스트 프레임에서는 [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/)이 설정되고 [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/)은 `null`이며, 표 자체는 도형이지만 그렇습니다.

셀 좌표는 읽기 전용 [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) 및 [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) 속성을 통해 확인할 수 있습니다. [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/)도 읽기 전용이며, 소유자를 탐색할 수 있지만 소유권을 변경하지 않습니다. 사용하기 전에 반환된 셀이 `null`인지 항상 확인하십시오.

표 셀 및 도형 소유자를 식별하는 전체 예제(스마트아트 노드와 연결된 도형 포함)는 [Search and Replace Text](/slides/ko/net/search-and-replace-text/)를 참조하십시오.

## **표에서 텍스트 정렬**

개별 표 셀의 수직 고정 및 텍스트 방향을 제어할 수 있습니다. 이 섹션의 예제는 첫 번째 셀의 텍스트를 가운데 정렬하고 270도 회전시킵니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 객체를 추가합니다.
4. 표에서 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 객체에 접근합니다.
5. 첫 번째 [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)에 접근하여 텍스트와 색상을 설정합니다.
6. 셀의 [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) 및 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/)을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 예제는 열 너비 120 포인트, 행 높이 100 포인트인 4 × 4 표를 생성합니다. 셀 (0, 0)의 텍스트를 서식 지정하고, 첫 번째 행의 나머지 셀에 값을 추가한 뒤 결과를 `Vertical_Align_Text_out.pptx` 파일로 저장합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **표 수준에서 텍스트 서식 지정**

[SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/)을 사용하여 표의 모든 셀에 텍스트 서식을 적용합니다. 해당 메서드의 오버로드는 부분, 단락 및 텍스트 프레임 서식을 받아들여 개별 셀을 순회하지 않고도 이러한 속성을 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에서 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 객체에 접근합니다.
4. 텍스트의 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)을 설정합니다.
5. 텍스트의 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 및 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)을 설정합니다.
6. 텍스트의 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)을 설정합니다.
7. 수정된 프레젠테이션을 저장합니다.

아래 예제는 `table.pptx` 파일을 열며, 이 파일은 최소 하나의 슬라이드와 해당 슬라이드의 첫 번째 도형이 표이어야 합니다. 글꼴 크기를 25 포인트로 설정하고, 단락을 오른쪽 정렬하고 오른쪽 여백을 20 포인트로 지정하며, 텍스트를 수직으로 설정합니다. 서식이 적용된 프레젠테이션은 `result.pptx` 파일로 저장됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **표 스타일 속성 가져오기**

[StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/)을 사용하여 표의 사전 정의 스타일을 읽거나 할당합니다. 이 예제는 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/)을 한 표에 적용하고 프리셋 이름을 출력한 뒤, 동일한 프리셋을 두 번째 표에 할당합니다. 두 표는 `table-style.pptx`에 저장됩니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **표의 가로 세로 비율 고정**

표의 가로 세로 비율은 너비와 높이의 비율을 의미합니다. [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/)을 사용하여 표의 비율을 고정할 수 있습니다.

아래 예제는 `pres.pptx` 파일을 열며, 이 파일은 최소 하나의 슬라이드와 해당 슬라이드의 첫 번째 도형이 표이어야 합니다. 현재 잠금 상태를 출력하고, 가로 세로 비율 잠금을 활성화한 뒤, 업데이트된 상태(`True`)를 출력하고 결과를 `pres-out.pptx` 파일로 저장합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**전체 표 및 셀 텍스트에 대해 오른쪽-왼쪽(RTL) 읽기 방향을 활성화할 수 있나요?**

예. 표는 [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) 속성을 제공하고, 단락에는 [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/)이 있습니다. 두 속성을 모두 사용하면 셀 내부에서 올바른 RTL 순서와 렌더링을 보장합니다.

**최종 파일에서 사용자가 표를 이동하거나 크기를 변경하지 못하도록 하려면 어떻게 해야 하나요?**

[shape locks](/slides/ko/net/applying-protection-to-presentation/)를 사용하여 이동, 크기 조정, 선택 등을 비활성화합니다. 이러한 잠금은 표에도 적용됩니다.

**셀 내부에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/)을 설정할 수 있으며, 선택한 모드(늘리기 또는 타일)대로 이미지가 셀 영역을 덮게 됩니다.