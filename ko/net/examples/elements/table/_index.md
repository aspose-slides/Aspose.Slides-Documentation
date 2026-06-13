---
title: 표
type: docs
weight: 120
url: /ko/net/examples/elements/table/
keywords:
- 표
- 표 추가
- 표 접근
- 표 제거
- 셀 병합
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 표 작업: 생성, 서식 지정, 셀 병합, 스타일 적용, 데이터 가져오기, 그리고 PPT, PPTX 및 ODP에 대한 C# 예제로 내보내기."
---
**Aspose.Slides for .NET**을 사용하여 표를 추가하고, 접근하고, 제거하고, 셀을 병합하는 예제입니다.

## **표 추가**

두 개의 행과 두 개의 열을 가진 간단한 표를 만듭니다.

```csharp
static void AddTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);
}
```

## **표 접근**

슬라이드에서 첫 번째 표 모양을 가져옵니다.

```csharp
static void AccessTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    // 슬라이드에서 첫 번째 표에 접근합니다.
    var firstTable = slide.Shapes.OfType<ITable>().First();
}
```

## **표 제거**

슬라이드에서 표를 삭제합니다.

```csharp
static void RemoveTable()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    slide.Shapes.Remove(table);
}
```

## **표 셀 병합**

표의 인접한 셀을 하나의 셀로 병합합니다.

```csharp
static void MergeTableCells()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    double[] widths = { 80, 80 };
    double[] heights = { 30, 30 };
    var table = slide.Shapes.AddTable(50, 50, widths, heights);

    table.MergeCells(table[0, 0], table[1, 1], false);
}
```