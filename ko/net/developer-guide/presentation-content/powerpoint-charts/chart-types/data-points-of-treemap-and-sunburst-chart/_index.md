---
title: .NET에서 Treemap 및 Sunburst 차트의 데이터 포인트 사용자 지정
linktitle: Treemap 및 Sunburst 차트의 데이터 포인트
type: docs
url: /ko/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap 차트
- Sunburst 차트
- 계층형 차트
- 데이터 포인트
- 데이터 레이블
- 브랜치 색상
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 Treemap 및 Sunburst 차트에서 계층형 데이터를 만들고 레벨, 레이블 및 색상을 사용자 지정하는 방법을 배웁니다."
---
## **Overview**

Treemap과 Sunburst 차트는 동일한 계층 데이터를 표시하지만 레이아웃이 다릅니다. Treemap은 영역이 리프 값에 해당하는 중첩 사각형으로 계층을 그립니다. Sunburst는 동심원 형태로 표시하며, 최상위 그룹은 중심부에 가깝고 리프 카테고리는 외곽 링에 위치합니다.

Aspose.Slides for .NET에서 각 숫자 값은 [IChartDataPoint](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/) 입니다. 해당 [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) 컬렉션을 통해 리프와 상위 그룹에 접근할 수 있습니다. 이 문서에서는 해당 매핑을 설명하고 동일한 샘플 데이터를 사용해 두 차트 유형을 생성하고 서식 지정하는 방법을 보여줍니다.

![소비자 및 비즈니스 지점을 포함한 Treemap 차트](treemap-hierarchy.png)

![동일한 소비자 및 비즈니스 계층 구조를 가진 Sunburst 차트](sunburst-hierarchy.png)

## **Understand Categories, Data Points, and Levels**

아래 샘플에는 세 개의 카테고리 레벨과 하나의 숫자 시리즈가 있습니다.

| 분기 | 그룹 | 리프 | 수익 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

각 행은 하나의 리프 카테고리와 하나의 데이터 포인트를 생성합니다. 카테고리 그룹 레벨은 해당 리프에서 상위까지의 경로를 설명합니다. 첫 번째 행의 경우 경로는 `Consumer > Computers > Laptops` 입니다.

[IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) 의 인덱스는 리프에서 위쪽으로 올라갑니다.

| `DataPointLevels` 인덱스 | 논리 레벨 | Treemap 표현 | Sunburst 표현 |
| ---: | --- | --- | --- |
| `0` | 리프 | 값 사각형 | 외곽 링 세그먼트 |
| `1` | 그룹 | 부모 사각형 또는 헤더 | 중간 링 세그먼트 |
| `2` | 분기 | 최상위 사각형 또는 헤더 | 내부 링 세그먼트 |

이 순서는 두 차트 유형 모두 동일하지만 시각적 레이아웃은 다릅니다. 하나의 부모 세그먼트는 여러 리프가 공유합니다. 서식을 지정하려면 해당 그룹의 첫 번째 데이터 포인트에 대한 레벨을 사용하십시오. 예를 들어 `Consumer` 분기는 `Laptops` 포인트에서 시작하고, `Software` 그룹은 `Licenses` 포인트에서 시작합니다. 이러한 포인트에 대한 참조를 유지하는 것이 `dataPoints[0]`이나 `dataPoints[6]`과 같은 설명이 없는 식보다 명확하고 안전합니다.

## **Create and Customize Both Chart Types**

다음 전체 예제는 첫 번째 슬라이드에 Treemap을, 두 번째 슬라이드에 Sunburst를 생성합니다. 계층을 구축하고, `Tablets` 값은 표시하며, 선택한 레벨에 고정 색을 적용하고, 분기 레이블을 서식 지정한 후 프레젠테이션을 저장합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // 리프 카테고리를 추가합니다. 새로운 그룹이 시작될 때만 그룹 항목이 설정됩니다;
    // 그 다음 카테고리들은 다른 항목이 설정될 때까지 해당 그룹에 남아 있습니다.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // Tablets 리프에 카테고리와 값을 표시합니다.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Consumer 브랜치를 해당 브랜치의 첫 번째 리프를 통해 서식 지정합니다.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Software 스템을 해당 스템의 첫 번째 리프를 통해 서식 지정합니다.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout은 Treemap 부모 레이블에 영향을 주며; Sunburst는 링 세그먼트를 사용합니다.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

카테고리 셀과 값 셀은 동일한 워크시트 행을 사용하므로 컬렉션 위치가 정렬된 상태를 유지합니다. 기존 차트를 수정할 때는 먼저 카테고리 행을 확인하고 서식 지정하려는 데이터 포인트와 레벨에 대한 이름 있는 참조를 저장하십시오.

## **Behavior and Practical Considerations**

### **Treemap and Sunburst Differences**

- Treemap은 면적을 사용해 값을 전달하고 중첩 사각형으로 계층을 전달합니다. 이 차트 유형에서 부모 레이블 표시 방법은 [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/parentlabellayout/) 속성으로 제어됩니다.
- Sunburst는 각도를 사용해 값을 전달하고 링 깊이로 계층을 전달합니다. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartseries/parentlabellayout/) 은 링 레이블을 제어하지 않습니다.
- 두 차트 유형 모두 동일한 카테고리 그룹 레벨과 `DataPointLevels` 의 리프‑상위 순서를 사용하므로 데이터 구축 및 레벨 서식 코드를 공유할 수 있습니다.
- 부모 값은 하위 리프에서 계산됩니다. 분기나 그룹에 별도의 숫자 포인트를 추가하지 마십시오.

### **Sorting and Segment Order**

차트 레이아웃 엔진이 사각형 및 링 세그먼트의 최종 위치를 결정합니다. 관련 카테고리 행을 함께 배치한 뒤 추가하되, 특정 사각형 위치나 시작 각도에 의존하지 마십시오. 순서가 의미가 있다면 라벨에 포함하거나 명시적인 카테고리 축이 있는 차트 유형을 사용하십시오.

### **Theme and Fixed Colors**

서식이 지정되지 않은 차트 레벨은 프레젠테이션 테마에서 색을 상속합니다. 예제에서는 예측 가능한 출력을 위해 명시적인 RGB 채우기를 사용했습니다. 테마 변경에 따라 색이 바뀌어야 하면 고정 RGB 대신 스킴 색을 사용하고 모든 레벨을 무조건 재정의하지 마십시오. 또한 분기 또는 그룹 채우기를 변경한 후 라벨 대비를 확인하십시오.

### **Labels and Available Space**

세그먼트가 너무 작으면 PowerPoint가 라벨을 숨기거나 잘라낼 수 있습니다. 차트 크기를 키우거나 카테고리 이름을 짧게 하거나 표시되는 라벨 필드를 줄이면 보통 더 명확해집니다. 라벨은 [IDataLabelFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/idatalabelformat/) 을 통해 카테고리명, 시리즈명, 값 등을 결합할 수 있지만, 모든 필드를 활성화하면 계층 차트가 읽기 어려워질 수 있습니다.

### **Export and Rendering**

PPTX 로 저장하면 차트를 편집 가능하게 유지합니다. Aspose.Slides가 프레젠테이션을 PDF 또는 이미지로 렌더링할 때 지원되는 채우기와 라벨 설정이 차트와 함께 렌더링됩니다. 글꼴 대체 및 사용 가능한 레이아웃 공간의 작은 차이로 인해 줄 바꿈이나 라벨 가시성이 달라질 수 있으므로 필요한 글꼴을 설치하고 주요 내보내기 대상에서 확인하십시오.

## **FAQ**

**왜 부모 레벨을 변경하면 여러 리프에 영향을 주나요?**

분기 또는 그룹은 공유되는 시각적 세그먼트입니다. 해당 [IChartDataPointLevel](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/ichartdatapointlevel/) 은 하위 리프를 통해 접근할 수 있지만 서식은 해당 리프만이 아니라 공유된 부모 세그먼트에 적용됩니다.

**왜 데이터 라벨이 표시되지 않나요?**

먼저 라벨의 [IDataLabelFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/idatalabelformat/) 객체에서 필요한 필드를 활성화하십시오. 그런 다음 세그먼트에 충분한 공간이 있는지 확인하십시오. Treemap 부모 라벨 레이아웃, 차트 크기, 라벨 길이, 글꼴 크기 및 활성화된 필드 수가 라벨 표시 여부에 영향을 줍니다.

**세그먼트의 정확한 순서나 좌표를 지정할 수 있나요?**

소스‑행 순서를 제어하고 각 그룹을 연속적으로 유지할 수는 있지만, 정확한 Treemap 사각형이나 Sunburst 각도를 직접 지정할 수는 없습니다. 차트 레이아웃 엔진이 계층, 값 및 사용 가능한 공간을 기반으로 계산합니다.

**프레젠테이션 테마가 바뀌면 색이 바뀌는 이유는?**

테마 기반 채우기는 프레젠테이션 팔레트를 따르도록 설계되었습니다. 고정되어야 할 레벨에는 명시적인 RGB 색을 적용하거나, 새 테마에 맞게 조정하려면 스킴 색을 유지하십시오.

**PDF와 이미지 내보내기에서 사용자 지정 서식이 유지되나요?**

예, 지원되는 차트 채우기와 라벨 설정은 렌더링 시 포함됩니다. 시스템 간 일관된 결과를 위해 필요한 글꼴을 제공하고 레이블 맞춤이 레이아웃에 의존하므로 최종 내보내기 크기를 테스트하십시오.

## **See Also**

- [Create Treemap charts](/slides/ko/net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ko/net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ko/net/export-chart/)
- [Manage presentation themes](/slides/ko/net/presentation-theme/)