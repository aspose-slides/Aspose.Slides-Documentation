---
title: C++에서 Treemap 및 Sunburst 차트의 데이터 포인트 사용자 지정
linktitle: Treemap 및 Sunburst 차트의 데이터 포인트
type: docs
url: /ko/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap 차트
- Sunburst 차트
- 계층형 차트
- 데이터 포인트
- 데이터 레이블
- 브랜치 색상
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 Treemap 및 Sunburst 차트에서 계층형 데이터를 생성하고 레벨, 레이블 및 색상을 사용자 지정하는 방법을 배웁니다."
---
## **개요**

Treemap과 Sunburst 차트는 동일한 계층형 데이터를 표시하지만 레이아웃이 다릅니다. Treemap은 계층 구조를 중첩된 사각형으로 그리며, 각 사각형의 면적이 leaf 값을 나타냅니다. Sunburst는 이를 동심원 형태로 그리며, 최상위 그룹은 중심에 가깝고 leaf 카테고리는 외부 링에 배치됩니다.

Aspose.Slides for C++에서 각 숫자 값은 [IChartDataPoint](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapoint/)입니다. 해당 [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) 메서드는 leaf와 그 상위 그룹에 대한 접근을 제공합니다. 이 문서에서는 해당 매핑을 설명하고 동일한 샘플 데이터를 사용해 두 차트 유형을 만드는 방법과 서식 지정 방법을 보여줍니다.

![Consumer와 Business 지점을 포함한 Treemap 차트](treemap-hierarchy.png)

![동일한 Consumer와 Business 계층 구조를 가진 Sunburst 차트](sunburst-hierarchy.png)

## **카테고리, 데이터 포인트 및 레벨 이해**

아래에 사용된 샘플은 세 개의 카테고리 레벨과 하나의 숫자 시리즈로 구성됩니다.

| 분기 | 줄기 | 잎 | 수익 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

각 행은 하나의 leaf 카테고리와 하나의 데이터 포인트를 생성합니다. 카테고리 그룹 레벨은 해당 leaf에서 부모까지의 경로를 설명합니다. 첫 번째 행의 경우 경로는 `Consumer > Computers > Laptops`입니다.

[IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/)가 반환하는 인덱스는 leaf에서 위로 올라갑니다:

| `get_DataPointLevels()` 인덱스 | 논리 레벨 | Treemap 표현 | Sunburst 표현 |
| ---: | --- | --- | --- |
| `0` | Leaf | Value rectangle | Outer-ring segment |
| `1` | Stem | Parent rectangle or header | Middle-ring segment |
| `2` | Branch | Top-level rectangle or header | Inner-ring segment |

이 순서는 두 차트 유형 모두 동일하지만 시각적 레이아웃은 다릅니다. 하나의 부모 세그먼트가 여러 leaf에 공유됩니다. 해당 세그먼트를 서식 지정하려면 그룹 내 첫 번째 데이터 포인트의 해당 레벨을 사용합니다. 예를 들어 `Consumer` 브랜치는 `Laptops` 포인트에서 시작하고, `Software` 줄기는 `Licenses` 포인트에서 시작합니다. 이러한 포인트에 대한 참조를 보관하는 것이 `dataPoints->idx_get(0)`이나 `dataPoints->idx_get(6)`와 같은 설명되지 않은 표현식을 사용하는 것보다 명확하고 안전합니다.

## **두 차트 유형 만들기 및 사용자 지정**

다음 완전한 예제는 첫 번째 슬라이드에 Treemap을, 두 번째 슬라이드에 Sunburst를 생성합니다. 계층 구조를 구축하고, `Tablets` 값 을 표시하며, 선택된 레벨에 고정 색을 적용하고, 브랜치 레이블을 서식 지정한 뒤 프레젠테이션을 저장합니다.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // leaf 카테고리를 추가합니다. 그룹 항목은 새로운 그룹이 시작될 때만 설정됩니다;
    // 그 다음 카테고리들은 다른 항목이 설정될 때까지 해당 그룹에 남아 있습니다.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Tablets leaf에 카테고리와 값을 표시합니다.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // 해당 브랜치의 첫 번째 leaf를 통해 Consumer 브랜치를 서식 지정합니다.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // 해당 스템의 첫 번째 leaf를 통해 Software 스템을 서식 지정합니다.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout은 Treemap 부모 레이블에 영향을 주며; Sunburst는 링 세그먼트를 사용합니다.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

카테고리 셀과 값 셀은 동일한 워크시트 행을 사용하므로 컬렉션 위치가 정렬된 상태로 유지됩니다. 기존 차트를 사용하여 작업하는 경우 먼저 카테고리 행을 확인하고 서식 지정하려는 데이터 포인트와 레벨에 대한 명명된 참조를 저장하십시오.

## **동작 및 실용적인 고려 사항**

### **Treemap 및 Sunburst 차이점**

- Treemap은 면적을 사용해 값을 전달하고 중첩된 사각형을 사용해 계층을 전달합니다. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) 메서드는 이 차트 유형에서 부모 레이블이 표시되는 방식을 제어합니다.
- Sunburst는 각도를 사용해 값을 전달하고 링 깊이를 사용해 계층을 전달합니다. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) 은 링 레이블을 제어하지 않습니다.
- 두 차트 유형 모두 동일한 카테고리 그룹 레벨과 [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) 가 반환하는 leaf‑to‑parent 순서를 사용하므로 데이터 구축 및 레벨 서식 코드가 공유될 수 있습니다.
- 부모 값은 하위 leaf 값으로부터 계산됩니다. 브랜치나 줄기에 별도의 숫자 포인트를 추가하지 마십시오.

### **정렬 및 세그먼트 순서**

차트 레이아웃 엔진이 사각형과 링 세그먼트의 최종 배치를 결정합니다. 행을 추가하기 전에 관련 카테고리 행을 함께 배치하십시오하지만 특정 사각형 위치나 시작 각도에 의존하지 마십시오. 순서에 의미가 있는 경우 레이블에 포함하거나 명시적인 카테고리 축을 가진 차트 유형을 사용하십시오.

### **테마 및 고정 색**

서식이 지정되지 않은 차트 레벨은 프레젠테이션 테마에서 색을 상속합니다. 예제에서는 예측 가능한 출력을 위해 명시적인 RGB 채우기를 사용합니다. 차트가 테마 변경을 따르도록 하려면 고정 RGB 값 대신 스키마 색을 사용하고 모든 레벨을 덮어쓰지 마십시오. 또한 브랜치나 줄기 채우기를 변경한 후 레이블 대비를 확인하십시오.

### **레이블 및 사용 가능한 공간**

세그먼트가 너무 작으면 PowerPoint가 레이블을 숨기거나 잘라낼 수 있습니다. 차트 크기를 늘리거나 카테고리 이름을 짧게 하거나 표시되는 레이블 필드를 줄이면 일반적으로 더 명확한 결과를 얻을 수 있습니다. 레이블은 [IDataLabelFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/idatalabelformat/) 를 통해 카테고리 이름, 시리즈 이름 및 값을 결합할 수 있지만 모든 필드를 활성화하면 계층형 차트를 읽기 어렵게 만들 수 있습니다.

### **내보내기 및 렌더링**

PPTX로 저장하면 차트를 편집 가능하게 유지합니다. Aspose.Slides가 프레젠테이션을 PDF 또는 이미지로 렌더링할 때 지원되는 채우기와 레이블 설정이 차트와 함께 렌더링됩니다. 글꼴 대체 및 사용 가능한 레이아웃 공간의 작은 차이로 인해 줄 바꿈이나 레이블 가시성이 달라질 수 있으므로 필요한 글꼴을 설치하고 중요한 내보내기 대상이 올바르게 표시되는지 확인하십시오.

## **자주 묻는 질문**

**부모 레벨을 변경하면 여러 leaf에 영향을 주는 이유는 무엇인가요?**

브랜치 또는 줄기는 공유되는 시각적 세그먼트입니다. 해당 [IChartDataPointLevel](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapointlevel/) 은 하위 leaf를 통해 접근할 수 있지만 서식은 해당 leaf만이 아니라 공유된 부모 세그먼트에 적용됩니다.

**데이터 레이블이 표시되지 않는 이유는 무엇인가요?**

먼저 레이블의 [IDataLabelFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/idatalabelformat/) 객체에서 필요한 필드를 활성화하십시오. 그런 다음 세그먼트에 충분한 공간이 있는지 확인합니다. Treemap 부모 레이블 레이아웃, 차트 크기, 레이블 길이, 글꼴 크기 및 활성화된 필드 수가 레이블 표시 여부에 영향을 줍니다.

**세그먼트의 정확한 순서나 좌표를 설정할 수 있나요?**

소스 행 순서를 제어하고 각 그룹을 연속으로 유지할 수는 있지만 정확한 Treemap 사각형이나 Sunburst 각도를 지정할 수는 없습니다. 차트 레이아웃 엔진이 계층, 값 및 사용 가능한 공간을 기반으로 계산합니다.

**프레젠테이션 테마가 변경되면 색상이 바뀌는 이유는 무엇인가요?**

테마 기반 채우기는 프레젠테이션 팔레트를 따르도록 설계되었습니다. 고정되어야 하는 레벨에는 명시적인 RGB 색을 적용하거나 새 테마에 맞게 스키마 색을 유지하십시오.

**PDF 및 이미지 내보내기에서 사용자 서식이 유지되나요?**

예, 지원되는 차트 채우기와 레이블 설정은 렌더링 시 포함됩니다. 시스템 간 일관된 결과를 얻으려면 필요한 글꼴을 제공하고 레이블 맞춤이 레이아웃에 따라 달라질 수 있으므로 최종 내보내기 크기를 테스트하십시오.

## **참고**

- [Treemap 차트 만들기](/slides/ko/cpp/create-chart/#create-tree-map-charts)
- [Sunburst 차트 만들기](/slides/ko/cpp/create-chart/#create-sunburst-charts)
- [프레젠테이션 차트 내보내기](/slides/ko/cpp/export-chart/)
- [프레젠테이션 테마 관리](/slides/ko/cpp/presentation-theme/)