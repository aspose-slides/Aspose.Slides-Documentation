---
title: .NET에서 프레젠테이션 표 관리
linktitle: 표 관리
type: docs
weight: 10
url: /ko/net/manage-table/
keywords:
- 표 추가
- 표 만들기
- 표 접근
- 가로세로 비율
- 텍스트 정렬
- 텍스트 서식
- 표 스타일
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 슬라이드에서 표를 만들고 편집합니다. 표 작업 흐름을 간소화하는 간단한 C# 코드 예제를 확인하세요."
---
## **소개**

PowerPoint의 표는 정보를 효율적으로 표시하고 전달하는 방법입니다. 행과 열로 구성된 셀 그리드에 있는 정보는 직관적이고 이해하기 쉽습니다.

Aspose.Slides는 [Table](https://reference.aspose.com/slides/ko/net/aspose.slides/table/) 클래스, [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/) 인터페이스, [Cell](https://reference.aspose.com/slides/ko/net/aspose.slides/cell/) 클래스, [ICell](https://reference.aspose.com/slides/ko/net/aspose.slides/icell/) 인터페이스 및 기타 유형을 제공하여 다양한 프레젠테이션에서 표를 만들고, 업데이트하고, 관리할 수 있도록 합니다. 

## **스크래치에서 테이블 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. `columnWidth` 배열을 정의합니다.  
4. `rowHeight` 배열을 정의합니다.  
5. [AddTable](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addtable/) 메서드를 사용하여 슬라이드에 [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/) 객체를 추가합니다.  
6. 각 [ICell](https://reference.aspose.com/slides/ko/net/aspose.slides/icell/)을 순회하면서 위, 아래, 오른쪽, 왼쪽 테두리에 서식을 적용합니다.  
7. 표 첫 번째 행의 처음 두 셀을 병합합니다.  
8. [ICell](https://reference.aspose.com/slides/ko/net/aspose.slides/icell/)의 [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/)에 접근합니다.  
9. [TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/)에 텍스트를 추가합니다.  
10. 수정된 프레젠테이션을 저장합니다.

이 C# 코드는 프레젠테이션에 표를 만드는 방법을 보여줍니다:

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();

// 첫 번째 슬라이드에 액세스합니다
ISlide sld = pres.Slides[0];

// 열 너비와 행 높이를 정의합니다
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// 슬라이드에 표 모양을 추가합니다
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// 각 셀에 대한 테두리 형식을 설정합니다
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// 행 1의 셀 1과 2를 병합합니다
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// 병합된 셀에 텍스트를 추가합니다
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// 프레젠테이션을 디스크에 저장합니다
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **표준 표에서 번호 매기기**

표준 표에서는 셀 번호 매김이 직관적이며 0부터 시작합니다. 표의 첫 번째 셀은 0,0(열 0, 행 0)으로 인덱싱됩니다. 

예를 들어, 4열 4행 표의 셀 번호는 다음과 같습니다:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

이 C# 코드는 표의 셀 번호 지정 방법을 보여줍니다:

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation())
{

    // 첫 번째 슬라이드에 액세스합니다
    ISlide sld = pres.Slides[0];

    // 열 너비와 행 높이를 정의합니다
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 슬라이드에 표 모양을 추가합니다
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

    // 프레젠테이션을 디스크에 저장합니다
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **기존 테이블에 접근**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  

2. 인덱스를 통해 표가 포함된 슬라이드에 대한 참조를 가져옵니다.  

3. [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/) 객체를 생성하고 null로 설정합니다.  

4. 모든 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/) 객체를 순회하면서 표를 찾습니다.  

   슬라이드에 단일 표만 포함되어 있다고 생각되는 경우 포함된 모든 모양을 확인하면 됩니다. 모양이 표로 식별되면 이를 [Table](https://reference.aspose.com/slides/ko/net/aspose.slides/table/) 객체로 타입 캐스팅할 수 있습니다. 그러나 슬라이드에 여러 표가 포함되어 있는 경우 원하는 표를 [AlternativeText](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/alternativetext/)를 통해 검색하는 것이 좋습니다.  

5. [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/) 객체를 사용하여 표를 작업합니다. 아래 예제에서는 표에 새 행을 추가했습니다.  

6. 수정된 프레젠테이션을 저장합니다.  

이 C# 코드는 기존 표에 접근하고 작업하는 방법을 보여줍니다:

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // 첫 번째 슬라이드에 액세스합니다
    ISlide sld = pres.Slides[0];

    // null TableEx 를 초기화합니다
    ITable tbl = null;

    // 모양을 순회하면서 찾은 표에 대한 참조를 설정합니다
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // 두 번째 행의 첫 번째 열에 텍스트를 설정합니다
    tbl[0, 1].TextFrame.Text = "New";

    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **표에서 텍스트 정렬**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. 슬라이드에 [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/) 객체를 추가합니다.  
4. 표에서 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/) 객체에 접근합니다.  
5. [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)의 [IParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/)에 접근합니다.  
6. 텍스트를 수직으로 정렬합니다.  
7. 수정된 프레젠테이션을 저장합니다.  

이 C# 코드는 표 내부 텍스트를 정렬하는 방법을 보여줍니다:

```c#
// Presentation 클래스의 인스턴스를 생성합니다
Presentation presentation = new Presentation();

// 첫 번째 슬라이드를 가져옵니다
ISlide slide = presentation.Slides[0];

// 열 너비와 행 높이를 정의합니다
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// 슬라이드에 표 모양을 추가합니다
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// 텍스트 프레임에 접근합니다
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// 텍스트 프레임용 Paragraph 객체를 생성합니다
IParagraph paragraph = txtFrame.Paragraphs[0];

// 문단용 Portion 객체를 생성합니다
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 텍스트를 수직으로 정렬합니다
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// 프레젠테이션을 디스크에 저장합니다
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **표 수준에서 텍스트 서식 지정**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. 슬라이드에서 [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/) 객체에 접근합니다.  
4. 텍스트의 [FontHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/fontheight/)를 설정합니다.  
5. [Alignment](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/alignment/)와 [MarginRight](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/marginright/)를 설정합니다.  
6. [TextVerticalType](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat/textverticaltype/)을 설정합니다.  
7. 수정된 프레젠테이션을 저장합니다.  

이 C# 코드는 표의 텍스트에 원하는 서식 옵션을 적용하는 방법을 보여줍니다:

```c#
// Presentation 클래스의 인스턴스를 생성합니다
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 첫 번째 슬라이드의 첫 번째 모양이 표라고 가정합니다

// 표 셀들의 글꼴 높이를 설정합니다
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// 표 셀들의 텍스트 정렬과 오른쪽 여백을 한 번에 설정합니다
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// 표 셀들의 텍스트 세로 방향을 설정합니다
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **표 스타일 속성 가져오기**

Aspose.Slides를 사용하면 표의 스타일 속성을 검색하여 다른 표에 적용하거나 다른 곳에서 사용할 수 있습니다. 이 C# 코드는 표 사전 설정 스타일에서 스타일 속성을 가져오는 방법을 보여줍니다: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // 기본 스타일 프리셋 테마를 변경합니다
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **표의 가로세로 비율 잠금**

기하학적 도형의 가로세로 비율은 서로 다른 차원에서의 크기 비율을 의미합니다. Aspose.Slides는 `AspectRatioLocked` 속성을 제공하여 표 및 기타 도형에 대해 가로세로 비율 잠금을 설정할 수 있게 합니다. 

이 C# 코드는 표의 가로세로 비율을 잠그는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // 반전

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**전체 표와 셀 내 텍스트에 대해 오른쪽에서 왼쪽(RTL) 읽기 방향을 활성화할 수 있나요?**

예. 표는 [RightToLeft](https://reference.aspose.com/slides/ko/net/aspose.slides/table/righttoleft/) 속성을 공개하며, 단락은 [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraphformat/righttoleft/) 속성을 가집니다. 두 속성을 모두 사용하면 셀 내부의 올바른 RTL 순서와 렌더링을 보장할 수 있습니다.

**최종 파일에서 사용자가 표를 움직이거나 크기를 조정하지 못하도록 방지하려면 어떻게 해야 하나요?**

[shape locks](/slides/ko/net/applying-protection-to-presentation/)를 사용하여 이동, 크기 조정, 선택 등을 비활성화할 수 있습니다. 이러한 잠금은 표에도 적용됩니다.

**셀 내부에 이미지를 배경으로 삽입하는 것이 지원되나요?**

예. 셀에 [picture fill](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat/)을 설정하면 이미지가 선택한 모드(늘이기 또는 타일)대로 셀 영역을 덮습니다.