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
description: "C#에서 PowerPoint 표 셀을 관리합니다: 병합된 셀 식별, 테두리 제거, 셀 분할, 배경 색상 및 이미지를 Aspose.Slides for .NET을 사용하여 설정합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 표 셀에 액세스하고 수정할 수 있습니다. 이 문서에서는 병합된 표 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀 병합 또는 분할 후 셀 번호를 다루는 방법, 셀의 배경색을 변경하는 방법, 그리고 표 셀 내부에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 생성하거나 열고, 슬라이드에서 표를 가져오고, 셀 속성을 통해 셀 서식을 업데이트하며, 수정된 프레젠테이션을 PPTX 파일로 저장하는 방법을 보여줍니다.

Aspose.Slides는 0부터 시작하는 인덱스를 사용하여 `(column, row)` 순서대로 표 셀에 액세스합니다.

## **병합된 표 셀 식별**

예제는 기존 프레젠테이션을 열고 첫 번째 슬라이드의 첫 번째 도형을 표로 액세스합니다. 슬라이드와 도형이 존재하며 해당 도형이 표라고 가정합니다. 그런 다음 모든 행과 열을 순회하면서 [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) 을 사용하여 병합된 영역의 셀을 식별합니다. 일치하는 각 셀에 대해 `row;column` 순서의 셀 좌표, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), 그리고 영역의 시작 좌표인 [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/)와 [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) 를 출력합니다.

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

먼저 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)을 생성하고 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)을 사용하여 첫 번째 슬라이드에 표를 추가합니다. 열 너비, 행 높이 및 표 위치는 포인트 단위로 지정됩니다. 예제에서는 네 개의 셀 테두리를 모두 [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 로 설정하여 보이지 않게 합니다.

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

## **표 셀 병합**

[MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/)을 사용하여 직사각형 범위의 표 셀을 하나의 셀로 결합합니다. 범위의 좌상단 셀과 우하단 셀을 지정합니다. 마지막 인자는 병합이 지정된 범위 밖의 셀을 포함할 수 있는지를 제어하며, `false`는 병합을 해당 범위 내에만 유지합니다.

예제에서는 70포인트 열과 행을 가진 4×4 표를 만든 다음 `(1, 1)`부터 `(2, 2)`까지 네 개의 중앙 셀을 병합합니다. 결과 셀은 두 개의 열과 두 개의 행을 차지하지만, 표의 기본 그리드는 여전히 네 열과 네 행을 유지합니다. 병합된 셀의 내용이나 서식에 접근하려면 해당 셀의 좌상단 위치인 `table[1, 1]` 를 사용합니다. 병합 범위 내의 다른 위치는 표 그리드의 일부로 남아 있으므로, 범위 밖 셀의 인덱스는 변경되지 않습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

tableMergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **표 셀 분할**

이전 예제에서 셀을 병합하면 표 그리드가 유지됩니다. 셀을 분할하면 새로운 그리드 열이 추가되고 오른쪽 셀들의 열 인덱스가 변경될 수 있습니다. Aspose.Slides는 PowerPoint의 표 그리드 모델을 따릅니다.

예제에서는 70포인트 열과 행을 가진 4×4 표를 만든 후 셀 `(1, 1)`에 대해 [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/)을 호출합니다. 셀의 70포인트 너비 중 절반을 전달하여 두 개의 동일한 너비 셀을 생성합니다.

분할 후 두 절반은 각각 `table[1, 1]`와 `table[2, 1]` 로 접근합니다. 표 그리드는 이제 다섯 개의 열을 가지며, 원래 열 2와 3에 있던 셀은 각각 열 3과 4로 이동합니다. 행 인덱스는 변하지 않습니다. 분할 후 셀에 접근할 때는 업데이트된 열 인덱스를 사용합니다.

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

### **행 또는 열 범위로 병합된 셀 분할**

병합된 템플릿 셀을 데이터 채우기에 준비하려면 기존 행 경계를 따라 분할하기 위해 [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/)을 사용하고, 열 경계를 따라 분할하려면 [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/)을 사용합니다.

`index` 매개변수는 분할된 상단 부분의 행 수 또는 왼쪽 부분의 열 수를 계산하며, 병합된 영역을 기준으로 합니다:

- 행 분할: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- 열 분할: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

예제에서는 첫 번째 슬라이드의 첫 번째 도형이 표이며 `(1, 2)`와 `(1, 3)`이 수직으로 병합되어 있다고 가정합니다. 아래쪽 위치에서 시작하여 [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/)와 [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/)을 사용해 기준점을 찾고 두 스팬을 확인합니다. 그런 다음 `SplitByRowSpan(1)`을 호출하여 행 2와 3을 제품 이름으로 분리합니다. 가로 두 열 병합의 경우에는 대신 `SplitByColSpan(1)`을 사용합니다.

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

    // 분할 후 표에서 결과 셀을 가져옵니다.
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

표 그리드와 주변 셀 인덱스는 변하지 않습니다. 결과 셀을 좌표로 조회하면 여기서는 두 셀 모두 스팬이 1이며 [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) 은 `False` 를 반환합니다. 큰 영역은 한 번 분할한 후에도 부분적으로 병합된 상태로 남을 수 있습니다.

원본 텍스트와 서식은 위쪽(또는 왼쪽) 셀에 남고, 새 셀은 비어 있지만 채우기, 테두리, 여백 등 셀 서식을 상속합니다. 분할 후 셀에 데이터를 채우고 필요한 텍스트 서식을 명시적으로 설정하십시오.

저장된 프레젠테이션에는 템플릿 셀 서식이 유지된 상태로 별도의 "Product A"와 "Product B" 셀이 포함됩니다. 자세한 내용은 [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/)를 참조하십시오.

## **표 셀 배경색 변경**

예제에서는 150포인트 열과 50포인트 행을 가진 표를 생성합니다. 셀 `(2, 3)`(세 번째 열, 네 번째 행)에 대해 [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/)을 solid로, [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/)을 빨간색으로 설정합니다.

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

## **표 셀 내부에 이미지 추가**

예제를 실행하기 전에 입력 이미지를 작업 디렉터리에 배치하십시오. 이미지는 [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/)으로 로드하고 [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/)으로 프레젠테이션의 이미지 컬렉션에 추가합니다. 그런 다음 이미지를 표의 첫 번째 셀인 `(0, 0)`의 그림 채우기(picture fill)로 지정합니다.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)은 이미지를 셀에 맞게 스트레칭하여 채우며, 이 경우 가로세로 비율이 변경될 수 있습니다. 열 너비와 행 높이는 포인트 단위입니다. 로드된 이미지는 using 선언에 의해 자동으로 해제됩니다.

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

**단일 셀의 각 면에 대해 다른 선 두께와 스타일을 설정할 수 있나요?**

네. [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) 테두리는 별개의 속성을 갖고 있어 각 면의 두께와 스타일을 다르게 지정할 수 있습니다.

**셀 배경에 그림을 설정한 후 열/행 크기를 변경하면 이미지는 어떻게 되나요?**

동작은 [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)(stretch/​tile)에 따라 달라집니다. Stretch 모드에서는 이미지가 새로운 셀 크기에 맞게 조정되고, Tile 모드에서는 타일이 다시 계산됩니다.

**셀의 모든 내용에 하이퍼링크를 지정할 수 있나요?**

[Hyperlinks](/slides/ko/net/manage-hyperlinks/) 은 셀 텍스트 프레임 내부의 텍스트(부분) 수준이나 전체 표/도형 수준에서 설정됩니다. 실제로는 링크를 텍스트의 일부에 지정하거나 셀의 전체 텍스트에 적용합니다.

**단일 셀 내에서 서로 다른 글꼴을 설정할 수 있나요?**

네. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/)(런)별로 독립적인 서식(글꼴 패밀리, 스타일, 크기, 색상)을 지원합니다.