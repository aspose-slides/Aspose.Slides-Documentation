---
title: .NET에서 프레젠테이션의 표 셀 관리
linktitle: 셀 관리
type: docs
weight: 30
url: /ko/net/manage-cells/
keywords:
- 표 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 내 이미지
- 배경 색상
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "C#에서 PowerPoint 표 셀을 관리합니다: 병합된 셀 식별, 테두리 제거, 셀 분할, 배경 색상 및 이미지를 Aspose.Slides for .NET으로 설정합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 표 셀에 액세스하고 수정할 수 있습니다. 이 문서에서는 병합된 표 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호를 관리하는 방법, 셀 배경색을 변경하는 방법 및 표 셀 안에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 생성하거나 열고, 슬라이드에서 표를 가져오며, 셀 속성을 통해 셀 서식을 업데이트하고, 수정된 프레젠테이션을 PPTX 파일로 저장하는 방법을 보여줍니다.

Aspose.Slides는 `(column, row)` 순서로 표 셀에 접근하기 위해 0부터 시작하는 인덱스를 사용합니다.

## **병합된 표 셀 식별**

예제는 기존 프레젠테이션을 열고 첫 번째 슬라이드의 첫 번째 도형을 표로 접근합니다. 슬라이드와 도형이 존재하고 해당 도형이 표라고 가정합니다. 그런 다음 모든 행과 열을 반복하면서 [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/)을 사용해 병합된 영역의 셀을 식별합니다. 일치하는 각 셀에 대해 `row;column` 순서로 셀 좌표와 [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), 그리고 영역의 시작 좌표인 [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/)와 [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/)를 출력합니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **표 셀 테두리 제거**

첫 번째 슬라이드에 표를 추가하기 위해 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)을 생성하고 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)을 사용합니다. 열 너비, 행 높이 및 표 위치는 포인트 단위로 지정됩니다. 예제에서는 모든 네 개의 셀 테두리를 [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/)으로 설정하여 보이지 않게 합니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **대각선 셀 테두리 추가**

[BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/)을 사용하여 왼쪽 위 모서리에서 오른쪽 아래 모서리까지 선을 그리며, [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/)을 사용하여 왼쪽 아래 모서리에서 오른쪽 위 모서리까지 선을 그립니다. 대각선은 코너 헤더를 표시할 수 있으며, 두 대각선을 모두 사용하면 셀을 적용되지 않음으로 표시하는 X를 만들 수 있습니다.

각 대각선은 [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/)입니다. 해당 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/)에서 [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/)을 [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/)으로 설정하고 [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/)를 선택합니다. 선의 [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/)를 포인트 단위로 지정합니다.

예제에서는 한 행에 세 개의 셀을 만들며, 빨간색 아래쪽 대각선, 파란색 위쪽 대각선, 그리고 두 대각선을 모두 포함합니다. 상단, 하단, 왼쪽 및 오른쪽 셀 테두리는 그대로 유지됩니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

대각선은 셀 분할이 아니라 서식 속성입니다. 각 셀은 단일 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/)을 유지하며, 대각선 양쪽 영역을 독립적으로 편집할 수 없습니다.

저장된 표, Microsoft PowerPoint에서 렌더링:

![왼쪽 위에서 오른쪽 아래로 향하는 빨간 대각선, 왼쪽 아래에서 오른쪽 위로 향하는 파란 대각선, 그리고 X를 형성하는 두 대각선을 보여주는 세 개의 표 셀.](diagonal-cell-borders.png)

*좌에서 우로: 아래쪽 대각선(빨강, 3 pt), 위쪽 대각선(파랑, 5 pt), 그리고 두 대각선.*

## **표 셀 병합**

[MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/)을 사용하여 사각형 범위의 표 셀을 하나의 셀로 결합합니다. 범위의 왼쪽 위와 오른쪽 아래 셀을 지정합니다. 마지막 인자는 병합이 지정된 범위 외의 셀을 포함할 수 있는지를 제어하며, `false`이면 범위 내에서만 병합됩니다.

예제에서는 70포인트 열과 행을 가진 4x4 표를 만든 다음, `(1, 1)`부터 `(2, 2)`까지 네 개의 중앙 셀을 병합합니다. 결과 셀은 두 열과 두 행을 차지하지만, 표의 기본 그리드는 네 열과 네 행을 유지합니다. 병합된 셀의 내용이나 서식에 접근하려면 왼쪽 위 위치인 `table[1, 1]`을 사용합니다(이 예제 기준). 병합 범위의 다른 위치는 표 그리드의 일부로 남아 있으므로 범위 외 셀의 인덱스는 변하지 않습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **표 셀 분할**

이전 예제에서 셀을 병합하면 표 그리드가 유지됩니다. 셀을 분할하면 새로운 그리드 열이 추가되고 오른쪽 셀들의 열 인덱스가 변경될 수 있습니다. Aspose.Slides는 PowerPoint의 표 그리드 모델을 따릅니다.

예제에서는 70포인트 열과 행을 가진 4x4 표를 만든 뒤 셀 `(1, 1)`에 대해 [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/)을 호출합니다. 셀의 70포인트 너비의 절반을 사용하여 두 개의 동일한 너비 셀을 생성합니다.

분할 후 두 절반은 `table[1, 1]`와 `table[2, 1]`으로 접근합니다. 표 그리드는 이제 다섯 열을 가지며, 원래 열 2와 3에 있던 셀은 각각 열 3과 4로 이동합니다. 행 인덱스는 변하지 않습니다. 분할 후 셀에 접근할 때는 업데이트된 열 인덱스를 사용합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **행 또는 열 Span으로 병합된 셀 분할**

데이터 채우기를 위해 병합된 템플릿 셀을 준비하려면 기존 행 경계에 따라 분할하는 [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/)을 사용하거나 열 경계에 따라 분할하는 [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/)을 사용합니다.

`index` 매개변수는 분할된 상부 부분의 행 수 또는 왼쪽 부분의 열 수를 셉니다; 이는 병합된 영역을 기준으로 합니다:
- 행 분할: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- 열 분할: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

예제에서는 첫 번째 슬라이드의 첫 번째 도형이 표이며 `(1, 2)`와 `(1, 3)`이 수직으로 병합되어 있다고 가정합니다. 아래쪽 위치에서 시작하여 [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/)와 [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/)을 사용해 시작점을 찾고 두 Span을 확인합니다. `SplitByRowSpan(1)`은 제품 이름을 위해 행 2와 3을 분리합니다. 가로 두 열 병합의 경우 대신 `SplitByColSpan(1)`을 사용합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // 분할 후 테이블에서 결과 셀을 가져옵니다.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

표 그리드와 주변 셀 인덱스는 변하지 않습니다. 결과 셀을 좌표로 가져오면 여기서는 두 셀 모두 Span이 1이며 [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/)은 `False`를 출력합니다. 하나의 분할 후에도 더 큰 영역은 일부가 병합된 상태로 남을 수 있습니다.

원본 텍스트와 서식은 상위(또는 왼쪽) 셀에 남으며, 새 셀은 비어 있지만 채우기, 테두리, 여백 등 셀 서식을 상속받습니다. 분할 후 셀에 데이터를 채우고 필요한 텍스트 서식을 명시적으로 설정합니다.

저장된 프레젠테이션에는 템플릿 셀 서식이 유지된 별도의 "Product A"와 "Product B" 셀이 포함됩니다. 자세한 내용은 [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/)를 참조하십시오.

<!-- visual-explanation:manage-cells:start -->
[![열 1, 행 2와 3에 있는 병합된 셀이 같은 그리드 인덱스를 유지하면서 Product A와 Product B로 분할됩니다.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*행 Span 분할은 기존 경계를 사용합니다. Product A와 Product B는 각각 (1, 2)와 (1, 3)을 차지합니다.*
<!-- visual-explanation:manage-cells:end -->

### **특정 높이에서 셀 분할**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/)은 위쪽 부분의 높이를 포인트 단위로 받습니다. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/)은 위쪽 부분에 포함될 기존 그리드 행 수를 받습니다. 오른쪽 열에 40포인트 셀을 중앙에 배치하려면 셀 실제 높이에서 40을 빼고 남은 공간을 위와 아래에 동일하게 나눕니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

첫 번째 분할은 그리드 행을 추가하여 아래쪽 90포인트를 `[1, 1]`에 남깁니다. 두 번째 분할은 해당 셀을 대상으로 아래에 또 다른 행을 추가합니다. 오른쪽 열은 이제 `[1, 0]`이 50포인트(`margin`), `[1, 1]`이 40포인트, `[1, 2]`가 50포인트(`margin`)를 가집니다. 왼쪽 셀은 원래 높이인 140포인트로 세 행 모두를 차지합니다.

![왼쪽 셀은 중앙에 Middle이 있는 세 개의 셀 옆에서 전체 표 높이를 차지합니다.](split-by-height.png)

## **표 셀 배경색 변경**

예제에서는 150포인트 열과 50포인트 행을 가진 표를 만들고, 셀 `(2, 3)`(세 번째 열, 네 번째 행)의 [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/)을 solid으로, [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/)을 빨강으로 설정합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **표 셀 안에 이미지 추가**

이 예제를 실행하기 전에 입력 이미지를 작업 디렉터리에 두세요. 이미지는 [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/)으로 로드하고 [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/)을 사용해 프레젠테이션의 이미지 컬렉션에 추가합니다. 그런 다음 이미지를 표의 첫 번째 셀인 `(0, 0)`의 그림 채우기(picture fill)로 지정합니다.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)은 이미지를 셀에 맞게 늘려 채우며, 이 경우 가로세로 비율이 변경될 수 있습니다. 열 너비와 행 높이는 포인트 단위입니다. 로드된 이미지는 using 구문에 의해 자동으로 해제됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **FAQ**

**단일 셀의 각 면에 대해 서로 다른 선 두께와 스타일을 지정할 수 있나요?**

예. [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) 테두리는 개별 속성을 가지므로 각 면의 두께와 스타일을 다르게 지정할 수 있습니다.

**셀 배경으로 그림을 설정한 후 열/행 크기를 변경하면 이미지가 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)(stretch/tile)에 따라 달라집니다. stretch를 사용하면 이미지가 새로운 셀에 맞게 조정되고, tile을 사용하면 타일이 다시 계산됩니다.

**셀의 모든 콘텐츠에 하이퍼링크를 지정할 수 있나요?**

[Hyperlinks](/slides/ko/net/manage-hyperlinks/)는 셀의 텍스트 프레임 내 텍스트(부분) 수준이나 전체 표/도형 수준에서 설정합니다. 실제로는 셀의 일부 텍스트나 전체 텍스트에 링크를 지정합니다.

**단일 셀 내에서 서로 다른 글꼴을 설정할 수 있나요?**

예. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (런)별로 독립된 서식(글꼴 패밀리, 스타일, 크기, 색상)을 지원합니다.