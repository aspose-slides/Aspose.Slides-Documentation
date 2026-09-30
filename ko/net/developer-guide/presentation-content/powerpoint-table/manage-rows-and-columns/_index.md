---
title: ".NET을 사용한 PowerPoint 표의 행 및 열 관리"
linktitle: "행 및 열"
type: docs
weight: 20
url: /ko/net/manage-rows-and-columns/
keywords:
- "표 행"
- "표 열"
- "첫 번째 행"
- "표 머리글"
- "행 복제"
- "열 복제"
- "행 복사"
- "열 복사"
- "행 제거"
- "열 제거"
- "행 텍스트 서식"
- "열 텍스트 서식"
- "표 스타일"
- "PowerPoint"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET을 사용하여 PowerPoint에서 표의 행과 열을 관리하고 프레젠테이션 편집 및 데이터 업데이트를 빠르게 수행합니다."
---
## **소개**

Aspose.Slides for .NET은 [표](https://reference.aspose.com/slides/net/aspose.slides/table/) 클래스와 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 인터페이스를 통해 PowerPoint 프레젠테이션의 테이블 구조와 서식을 관리할 수 있습니다. 머리글 행을 지정하고, 행과 열을 복제하거나 제거하며, 전체 행이나 열에 텍스트 서식을 적용할 수 있습니다.

이 문서는 C# 예제를 통해 이러한 작업을 설명합니다. 또한 테이블 스타일 사전 설정을 검색하여 재사용하는 방법을 보여줍니다. 테이블 행 및 열 인덱스는 0부터 시작합니다.

## **행 높이 제어**

행의 최소 높이를 포인트 단위로 설정하려면 [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/)를 사용합니다. 이는 하한값이며 고정 높이가 아닙니다. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/)는 실제 높이를 반환하며 읽기 전용입니다. 행은 [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/)를 통해 접근합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형으로 표가 포함된 [row-height-input.pptx](row-height-input.pptx)를 로드합니다. 첫 번째 행은 70포인트에서 시작합니다. 셀은 18포인트 Arial 텍스트, 자동 줄 바꿈, 그리고 상하 6포인트 여백을 사용합니다; 두 번째 열의 긴 텍스트는 여러 줄로 자동 줄 바꿈됩니다. 예제는 최소값을 100포인트로 증가시킨 다음 20포인트로 감소시키고, 각 변경 후 실제 높이를 출력하며 두 결과를 저장합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

제공된 프레젠테이션에서 최소값을 늘리면 행에 공간이 추가됩니다. 최소값을 줄이면 그 여분의 공간이 제거되지만, 텍스트와 셀 여백이 더 많은 공간을 필요로 하므로 실제 높이는 20포인트보다 크게 유지됩니다. 최소값만 줄여서는 내용이 요구하는 공간 이하로 행을 강제로 줄일 수 없습니다.

실제 높이에 영향을 주는 여러 요인:
- **텍스트 및 글꼴 크기:** 긴 텍스트, 명시적 줄 바꿈 또는 큰 글꼴은 더 많은 수직 공간이 필요할 수 있습니다.
- **자동 줄 바꿈 및 열 너비:** 자동 줄 바꿈이 활성화된 경우, 더 좁은 [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/)는 줄 수를 늘릴 수 있습니다. 넓은 열은 수직 공간 요구량을 줄일 수 있습니다.
- **셀 여백:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/)와 [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/)은 수직 공간을 추가합니다. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/)와 [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/)는 텍스트에 사용할 수 있는 너비를 감소시켜 추가 자동 줄 바꿈을 유발할 수 있습니다.

병합된 셀이 없는 이 표에서는 가장 많은 수직 공간이 필요한 셀이 전체 행의 내용 기반 하한을 결정합니다. 행을 짧게 만들려면 텍스트를 줄이거나, 글꼴 크기 또는 여백을 줄이거나, 열을 넓혀야 할 수도 있습니다.

아래 이미지들은 같은 규모의 동일한 표를 보여줍니다. 이번 실행에서 실제 높이는 각각 70, 100, 55.2포인트였습니다: 최종 행은 20포인트 최소값보다 높게 유지되었습니다. 정확한 텍스트 측정값은 환경에 설치된 글꼴에 따라 달라질 수 있습니다. 저장된 결과를 다운로드하세요: [minimum 증가](row-height-increased.pptx) 및 [minimum 감소](row-height-decreased.pptx).

| 원본: 최소 70pt, 실제 70pt | 증가: 최소 100pt, 실제 100pt | 감소: 최소 20pt, 실제 55.2pt |
| --- | --- | --- |
| ![70포인트 첫 번째 행이 있는 원본 표.](row-height-before.png) | ![첫 번째 행 최소값을 100포인트로 증가시킨 후의 표.](row-height-increased.png) | ![첫 번째 행 최소값을 20포인트로 감소시킨 후의 표; 자동 줄 바꿈 텍스트 때문에 행이 최소값보다 높게 유지됩니다.](row-height-decreased.png) |

## **첫 번째 행을 머리글로 설정**

[FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) 속성을 사용하여 첫 번째 행을 머리글 서식으로 표시합니다. 외관은 테이블에 적용된 테이블 스타일에 따라 달라집니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 로드합니다.
2. 첫 번째 슬라이드에 접근합니다.
3. 슬라이드의 첫 번째 도형으로 저장된 표에 접근합니다.
4. 첫 번째 행에 머리글 서식을 활성화합니다.
5. 수정된 프레젠테이션을 저장합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형으로 표가 포함된 `table.pptx`가 필요합니다. 첫 번째 행에 머리글 서식을 적용하고 `First_row_header.pptx`로 저장합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **표 행 또는 열 복제**

행이나 열을 복제하여 내용과 서식을 재사용합니다. 복제본을 표의 끝에 추가하거나 특정 위치에 삽입할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 로드합니다.
2. 첫 번째 슬라이드에 접근합니다.
3. 열 너비와 행 높이를 정의합니다.
4. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 메서드를 사용해 표를 추가합니다.
5. 필요한 행을 복제합니다.
6. 필요한 열을 복제합니다.
7. 수정된 프레젠테이션을 저장합니다.

예제는 최소 한 장의 슬라이드가 포함된 `Test.pptx`가 필요합니다. 3열 5행의 표를 만들고 크기는 포인트 단위로 지정합니다. 첫 번째 행과 열의 복제본을 추가하고, 두 번째 행과 열의 복제본을 인덱스 3(네 번째 위치)에 삽입합니다. 결과 표는 7행 5열이 됩니다. `false` 인자는 인접한 병합된 행이나 열로 복제되는 것을 비활성화합니다; 이 표에는 병합된 셀은 없습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **표에서 행 또는 열 제거**

표에서 더 이상 필요하지 않은 행이나 열을 제거합니다. 항목을 제거하면 뒤에 있는 행이나 열의 인덱스가 이동합니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 생성합니다.
2. 첫 번째 슬라이드에 접근합니다.
3. 열 너비와 행 높이를 정의합니다.
4. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 메서드를 사용해 표를 추가합니다.
5. 두 번째 행과 두 번째 열을 제거합니다.
6. 수정된 프레젠테이션을 저장합니다.

이 예제는 3x3 표를 만든 후 인덱스 1에 있는 행과 열을 제거하여 `TestTable_out.pptx`에 2x2 표를 남깁니다. 크기는 포인트 단위입니다. `false` 인자는 인접한 병합된 행이나 열의 제거를 비활성화합니다; 이 표에는 병합된 셀이 없습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **표 행 수준에서 텍스트 서식 설정**

전체 행에 텍스트 서식을 적용하여 셀 간 일관성을 유지합니다. 각 셀을 개별적으로 서식 지정하지 않고도 글꼴 속성, 문단 서식 및 텍스트 방향을 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 로드합니다.
2. 첫 번째 슬라이드의 표에 접근합니다.
3. [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)를 첫 번째 행에 설정합니다.
4. [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)와 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)를 첫 번째 행에 설정합니다.
5. [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)을 두 번째 행에 설정합니다.
6. 수정된 프레젠테이션을 저장합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형으로 표가 포함된 `table.pptx`와 최소 두 개의 행이 필요합니다. 첫 번째 행에 25포인트 텍스트, 오른쪽 정렬, 20포인트 오른쪽 문단 여백을 적용하고, 두 번째 행에 수직 텍스트를 설정합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **표 열 수준에서 텍스트 서식 설정**

전체 열에 텍스트 서식을 적용하여 셀 간 일관성을 유지합니다. 각 셀을 개별적으로 서식 지정하지 않고도 글꼴 속성, 문단 서식 및 텍스트 방향을 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 클래스를 사용해 프레젠테이션을 로드합니다.
2. 첫 번째 슬라이드의 표에 접근합니다.
3. [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)를 첫 번째 열에 설정합니다.
4. [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)와 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)를 첫 번째 열에 설정합니다.
5. [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)을 두 번째 열에 설정합니다.
6. 수정된 프레젠테이션을 저장합니다.

예제는 첫 번째 슬라이드의 첫 번째 도형으로 표가 포함된 `table.pptx`와 최소 두 개의 열이 필요합니다. 첫 번째 열에 25포인트 텍스트, 오른쪽 정렬, 20포인트 오른쪽 문단 여백을 적용하고, 두 번째 열에 수직 텍스트를 설정합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **표 스타일 속성 가져오기**

[StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) 속성을 사용하여 표에 적용된 사전 설정을 가져와 다른 표에 재사용합니다. 이는 개별 셀 서식 재정의가 아닌 사전 설정을 식별합니다.

예제는 표를 만든 뒤 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/)을 적용하고 사전 설정을 다시 읽습니다. `DarkStyle1`을 출력하고 표를 `table.pptx`에 저장합니다.

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

**이미 만든 표에 PowerPoint 테마/스타일을 적용할 수 있나요?**

예. 표는 슬라이드/레이아웃/마스터 테마를 상속받으며, 해당 테마 위에 채우기, 테두리 및 텍스트 색상을 여전히 재정의할 수 있습니다.

**Excel처럼 표 행을 정렬할 수 있나요?**

아니요, Aspose.Slides 표에는 내장된 정렬이나 필터 기능이 없습니다. 먼저 메모리에서 데이터를 정렬한 다음 해당 순서대로 표 행을 다시 채워 넣으세요.

**특정 셀에 사용자 지정 색상을 유지하면서 밴드(줄무늬) 열을 가질 수 있나요?**

예. 밴드 열을 활성화한 다음 특정 셀에 로컬 서식을 적용하면 됩니다; 셀 수준 서식이 표 스타일보다 우선합니다.