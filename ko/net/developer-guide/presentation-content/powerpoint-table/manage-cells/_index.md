---
title: ".NET에서 프레젠테이션의 표 셀 관리"
linktitle: "셀 관리"
type: docs
weight: 30
url: /ko/net/manage-cells/
keywords:
- 표 셀
- 셀 병합
- 테두리 제거
- 셀 분할
- 셀 안의 이미지
- 배경 색상
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint에서 표 셀을 손쉽게 관리합니다. 셀에 빠르게 액세스, 수정 및 스타일링을 마스터하여 원활한 슬라이드 자동화를 구현하세요."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 표 셀에 액세스하고 수정할 수 있습니다. 이 문서는 병합된 표 셀을 식별하는 방법, 셀 테두리를 제거하는 방법, 셀을 병합하거나 분할한 후 셀 번호 매기기를 처리하는 방법, 셀 배경색을 변경하는 방법, 그리고 표 셀 안에 이미지를 추가하는 방법을 설명합니다. 예제에서는 프레젠테이션을 만들거나 열고, 슬라이드에서 표를 가져오고, 셀 속성을 통해 셀 서식을 업데이트한 다음 수정된 프레젠테이션을 PPTX 파일로 저장하는 방법을 보여줍니다.

## **병합된 표 셀 식별**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에서 표를 가져옵니다.
3. 표의 행과 열을 반복하여 병합된 셀을 찾습니다.
4. 병합된 셀이 발견되면 메시지를 출력합니다.

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // Slide#0.Shape#0이 테이블이라고 가정합니다
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **표 셀 테두리 제거**

1. `Presentation` 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. 너비가 지정된 열 배열을 정의합니다.
4. 높이가 지정된 행 배열을 정의합니다.
5. `AddTable` 메서드를 사용하여 슬라이드에 표를 추가합니다.
6. 모든 셀을 반복하여 위, 아래, 오른쪽, 왼쪽 테두리를 제거합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
 // PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
 using (Presentation pres = new Presentation())
 {
    // 첫 번째 슬라이드에 접근합니다
    Slide sld = (Slide)pres.Slides[0];

    // 열의 너비와 행의 높이를 정의합니다
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 슬라이드에 표 형상을 추가합니다
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 각 셀에 대한 테두리 형식을 설정합니다
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // PPTX 파일을 디스크에 저장합니다
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **병합된 셀에서의 번호 매기기**

(1,1) x (2,1) 및 (1,2) x (2,2) 두 쌍의 셀을 병합하면 결과 표에 번호가 매겨집니다. 이 C# 코드가 그 과정을 보여줍니다:

```c#
 // PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드에 접근합니다
    ISlide sld = presentation.Slides[0];

    // 열의 너비와 행의 높이를 정의합니다
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 슬라이드에 표 형상을 추가합니다
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 각 셀에 대한 테두리 형식을 설정합니다
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // 셀 (1, 1) x (2, 1)을 병합합니다
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // 셀 (1, 2) x (2, 2)을 병합합니다
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

그런 다음 (1,1)과 (1,2)를 다시 병합합니다. 그 결과 표 중앙에 큰 병합 셀이 포함됩니다:

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드에 접근합니다
    ISlide slide = presentation.Slides[0];

    // 열의 너비와 행의 높이를 정의합니다
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 슬라이드에 표 형상을 추가합니다
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 각 셀에 대한 테두리 형식을 설정합니다
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // 셀 (1, 1) x (2, 1)을 병합합니다
    table.MergeCells(table[1, 1], table[2, 1], false);

    // 셀 (1, 2) x (2, 2)을 병합합니다
    table.MergeCells(table[1, 2], table[2, 2], false);

    // 셀 (1, 2) x (2, 2)을 병합합니다
    table.MergeCells(table[1, 1], table[1, 2], true);

    //PPTX 파일을 디스크에 저장합니다
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **분할된 셀에서의 번호 매기기**

이전 예제에서는 표 셀을 병합해도 다른 셀의 번호 매기기 체계는 변경되지 않았습니다. 이번에는 병합된 셀 없이 일반 표를 사용한 후 (1,1) 셀을 분할하여 특수한 표를 만듭니다. 이 표의 번호 매기기가 이상하게 보일 수 있으니 주의하십시오. 그러나 이것이 Microsoft PowerPoint가 표 셀에 번호를 매기는 방식이며 Aspose.Slides도 동일하게 동작합니다.

다음 C# 코드가 설명한 과정을 보여줍니다:

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드에 접근합니다
    ISlide slide = presentation.Slides[0];

    // 열의 너비와 행의 높이를 정의합니다
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 슬라이드에 표 형상을 추가합니다
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 각 셀에 대한 테두리 형식을 설정합니다
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // 셀 (1, 1) x (2, 1)을 병합합니다
    table.MergeCells(table[1, 1], table[2, 1], false);

    // 셀 (1, 2) x (2, 2)을 병합합니다
    table.MergeCells(table[1, 2], table[2, 2], false);

    // 셀 (1, 1)을 분할합니다. 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    //PPTX 파일을 디스크에 저장합니다
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **표 셀 배경색 변경**

다음 C# 코드는 표 셀의 배경색을 변경하는 방법을 보여줍니다:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // 새 표를 생성합니다
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // 셀의 배경 색을 설정합니다
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **표 셀 안에 이미지 추가**

1. `Presentation` 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. 너비가 지정된 열 배열을 정의합니다.
4. 높이가 지정된 행 배열을 정의합니다.
5. `AddTable` 메서드를 사용하여 슬라이드에 표를 추가합니다.
6. 이미지 파일을 보관할 `Bitmap` 객체를 생성합니다.
7. 비트맵 이미지를 `IPPImage` 객체에 추가합니다.
8. 표 셀의 `FillFormat`을 `Picture`로 설정합니다.
9. 이미지를 표의 첫 번째 셀에 추가합니다.
10. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드에 접근합니다
    ISlide slide = presentation.Slides[0];

    // 열의 너비와 행의 높이를 정의합니다
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // 슬라이드에 표 형상을 추가합니다
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // 파일에서 이미지를 로드하고 프레젠테이션 리소스에 추가합니다
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 이미지를 첫 번째 표 셀에 추가합니다
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // PPTX 파일을 디스크에 저장합니다
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**단일 셀의 각 면에 대해 다른 선 두께와 스타일을 설정할 수 있나요?**

예. [top](https://reference.aspose.com/slides/ko/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/ko/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/ko/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/ko/net/aspose.slides/cellformat/borderright/) 테두리는 별개의 속성을 가지고 있으므로 각 면의 두께와 스타일을 다르게 지정할 수 있습니다. 이는 문서에 적용된 셀의 면별 테두리 제어에서 논리적으로 따라옵니다.

**셀 배경에 그림을 설정한 후 열/행 크기를 변경하면 이미지에 어떤 일이 발생하나요?**

동작은 [fill mode](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillmode/)(stretch/​tile)에 따라 달라집니다. stretch인 경우 이미지는 새 셀에 맞게 조정되고, tile인 경우 타일이 다시 계산됩니다. 문서에서는 셀 내 이미지 표시 모드에 대해 언급하고 있습니다.

**셀의 모든 내용에 하이퍼링크를 할당할 수 있나요?**

[Hyperlinks](/slides/ko/net/manage-hyperlinks/)는 셀의 텍스트 프레임 내부 텍스트(부분) 수준이나 전체 표/도형 수준에서 설정됩니다. 실제로는 셀의 일부 텍스트에 링크를 지정하거나 셀의 모든 텍스트에 링크를 지정합니다.

**단일 셀 내에서 서로 다른 글꼴을 설정할 수 있나요?**

예. 셀의 텍스트 프레임은 [portions](https://reference.aspose.com/slides/ko/net/aspose.slides/portion/)(런)별로 독립적인 서식(글꼴, 스타일, 크기, 색상)을 지원합니다.