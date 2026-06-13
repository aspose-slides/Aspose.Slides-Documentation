---
title: .NET에서 PowerPoint 표의 행 및 열 관리
linktitle: 행 및 열
type: docs
weight: 20
url: /ko/net/manage-rows-and-columns/
keywords:
- 표 행
- 표 열
- 첫 번째 행
- 표 헤더
- 행 복제
- 열 복제
- 행 복사
- 열 복사
- 행 제거
- 열 제거
- 행 텍스트 서식
- 열 텍스트 서식
- 표 스타일
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint에서 표 행과 열을 관리하고 프레젠테이션 편집 및 데이터 업데이트를 빠르게 수행합니다."
---
## **소개**

PowerPoint 프레젠테이션에서 표의 행과 열을 관리할 수 있도록 Aspose.Slides는 [Table](https://reference.aspose.com/slides/ko/net/aspose.slides/table/) 클래스, [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/) 인터페이스 및 기타 여러 타입을 제공합니다. 

## **첫 번째 행을 헤더로 설정**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다. 
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/) 객체를 생성하고 null로 설정합니다. 
4. 모든 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/) 객체를 순회하여 해당 표를 찾습니다. 
5. 표의 첫 번째 행을 헤더로 설정합니다. 

다음 C# 코드는 표의 첫 번째 행을 헤더로 설정하는 방법을 보여줍니다:

```c#
// Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("table.pptx");

// 첫 번째 슬라이드에 접근합니다
ISlide sld = pres.Slides[0];

// null TableEx를 초기화합니다
ITable tbl = null;

// 도형들을 반복하면서 표에 대한 참조를 설정합니다
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// 표의 첫 번째 행을 헤더로 설정합니다
tbl.FirstRow = true;

// 프레젠테이션을 디스크에 저장합니다
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **표 행 또는 열 복제**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다, 
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. `columnWidth` 배열을 정의합니다. 
4. `rowHeight` 배열을 정의합니다. 
5. [AddTable](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addtable/) 메서드를 사용하여 슬라이드에 [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/) 객체를 추가합니다. 
6. 표 행을 복제합니다. 
7. 표 열을 복제합니다. 
8. 수정된 프레젠테이션을 저장합니다. 

다음 C# 코드는 PowerPoint 표의 행 또는 열을 복제하는 방법을 보여줍니다:

```c#
 // Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // 첫 번째 슬라이드에 접근합니다
    ISlide sld = presentation.Slides[0];

    // 열 너비와 행 높이를 정의합니다
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 슬라이드에 표 형태를 추가합니다
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 행 1 셀 1에 텍스트를 추가합니다
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // 행 1 셀 2에 텍스트를 추가합니다
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // 표 끝에 행 1을 복제합니다
    table.Rows.AddClone(table.Rows[0], false);

    // 행 2 셀 1에 텍스트를 추가합니다
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // 행 2 셀 2에 텍스트를 추가합니다
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // 표의 네 번째 행으로 행 2를 복제합니다
    table.Rows.InsertClone(3,table.Rows[1], false);

    // 마지막에 첫 번째 열을 복제합니다
    table.Columns.AddClone(table.Columns[0], false);

    // 네 번째 열 인덱스에 두 번째 열을 복제합니다
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // 프레젠테이션을 디스크에 저장합니다 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **표에서 행 또는 열 제거**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다, 
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. `columnWidth` 배열을 정의합니다. 
4. `rowHeight` 배열을 정의합니다. 
5. [AddTable](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addtable/) 메서드를 사용하여 슬라이드에 [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/) 객체를 추가합니다. 
6. 표 행을 제거합니다. 
7. 표 열을 제거합니다. 
8. 수정된 프레젠테이션을 저장합니다. 

다음 C# 코드는 표에서 행 또는 열을 제거하는 방법을 보여줍니다:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **표 행 수준에서 텍스트 서식 지정**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다, 
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. 슬라이드에서 해당 [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/) 객체에 접근합니다. 
4. 첫 번째 행 셀의 [FontHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/fontheight/)를 설정합니다. 
5. 첫 번째 행 셀의 [Alignment](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/alignment/) 및 [MarginRight](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/marginright/)를 설정합니다. 
6. 두 번째 행 셀의 [TextVerticalType](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat/textverticaltype/)를 설정합니다. 
7. 수정된 프레젠테이션을 저장합니다. 

다음 C# 코드는 해당 작업을 보여줍니다.

```c#
// Presentation 클래스의 인스턴스를 생성합니다
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 첫 번째 슬라이드의 첫 번째 도형이 표라고 가정합니다

// 첫 번째 행 셀의 폰트 높이를 설정합니다
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// 첫 번째 행 셀의 텍스트 정렬 및 오른쪽 여백을 설정합니다
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// 두 번째 행 셀의 텍스트 수직 유형을 설정합니다
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// 프레젠테이션을 디스크에 저장합니다
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **표 열 수준에서 텍스트 서식 지정**

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성하고 프레젠테이션을 로드합니다, 
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. 슬라이드에서 해당 [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/) 객체에 접근합니다. 
4. 첫 번째 열 셀의 [FontHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/fontheight/)를 설정합니다. 
5. 첫 번째 열 셀의 [Alignment](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/alignment/) 및 [MarginRight](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/marginright/)를 설정합니다. 
6. 두 번째 열 셀의 [TextVerticalType](https://reference.aspose.com/slides/ko/net/aspose.slides/textframeformat/textverticaltype/)를 설정합니다. 
7. 수정된 프레젠테이션을 저장합니다. 

다음 C# 코드는 해당 작업을 보여줍니다: 

```c#
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // 첫 번째 슬라이드의 첫 번째 도형이 표라고 가정합니다

// 첫 번째 열 셀의 폰트 높이를 설정합니다
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// 한 번의 호출로 첫 번째 열 셀의 텍스트 정렬 및 오른쪽 여백을 설정합니다
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// 두 번째 열 셀의 텍스트 수직 유형을 설정합니다
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// 프레젠테이션을 디스크에 저장합니다
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **표 스타일 속성 가져오기**

Aspose.Slides를 사용하면 표의 스타일 속성을 가져와 다른 표나 다른 곳에서 사용할 수 있습니다. 다음 C# 코드는 표 사전 정의 스타일에서 스타일 속성을 가져오는 방법을 보여줍니다: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // 기본 스타일 프리셋 테마를 변경합니다
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **자주 묻는 질문**

**이미 만든 표에 PowerPoint 테마/스타일을 적용할 수 있나요?**

예. 표는 슬라이드/레이아웃/마스터 테마를 상속하지만 해당 테마 위에 채우기, 테두리 및 텍스트 색상을 덮어쓸 수 있습니다.

**Excel처럼 표 행을 정렬할 수 있나요?**

아니요, Aspose.Slides 표에는 내장된 정렬이나 필터 기능이 없습니다. 먼저 메모리 내에서 데이터를 정렬한 다음 해당 순서대로 표 행을 다시 채워야 합니다.

**특정 셀에 사용자 정의 색상을 유지하면서 줄무늬(밴드) 열을 적용할 수 있나요?**

예. 줄무늬 열을 활성화한 후 특정 셀에 로컬 서식을 적용하면 됩니다. 셀 수준 서식이 표 스타일보다 우선합니다.