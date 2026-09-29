---
title: 프레젠테이션에서 C++를 사용한 차트 워크북 관리
linktitle: 차트 워크북
type: docs
weight: 70
url: /ko/cpp/chart-workbook/
keywords:
- 차트 워크북
- 차트 데이터
- 워크북 셀
- 데이터 레이블
- 워크시트
- 데이터 소스
- 외부 워크북
- 외부 데이터
- 차트 캐시
- 워크북 복구
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 발견하세요: PowerPoint 및 OpenDocument 형식의 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 간소화합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 통합 문서(워크북)를 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 액세스하는 방법, 차트 값에 대한 데이터 소스 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 소스로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북을 사용할 수 있을 때 차트 데이터를 편집하는 방법을 보여줍니다.

누락된 데이터를 나타내는 워크북 셀에 대해서는 빈 셀과 0값의 차이 및 사용 가능한 표시 모드의 라인 차트 비교를 보려면 [빈 셀 표시 제어](/slides/ko/cpp/chart-series/)를 참조하십시오.

## **숨겨진 행 및 열의 데이터 포함**

숨겨진 워크시트 행 및 열의 데이터를 차트가 플롯할지 여부를 제어하려면 [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/)를 사용하십시오. `true`로 설정하면 표시된 셀만 플롯하고, `false`로 설정하면 표시된 셀과 숨겨진 셀 모두를 포함합니다. 이 설정은 차트 플롯에만 영향을 주며, 워크시트 행이나 열을 숨기거나 표시하지는 않습니다.

[hidden-source-data.pptx](hidden-source-data.pptx)를 다운로드하여 작업 디렉터리에 배치하십시오. 첫 번째 슬라이드에는 첫 번째 도형으로 컬럼 차트가 포함되어 있습니다. 삽입된 워크시트 `Sheet1`에는 `A1:C4` 범위가 포함되어 있습니다. 3행과 C열은 숨겨져 있지만, 해당 셀에는 여전히 값이 들어 있습니다.

| 워크시트 행 | A: 월 | B: 소매 | C: 도매 (숨김 열) |
| --- | --- | --- | --- |
| 2 | 1월 | 10 | 30 |
| 3 (숨김 행) | 2월 | 40 | 60 |
| 4 | 3월 | 20 | 50 |

소스 셀에 액세스하려면 [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/)를 사용하고, 셀의 숨김 상태를 확인하려면 [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/)를 읽으십시오. 이 속성은 읽기 전용입니다. 이 파일에서 B2는 표시되고, B3은 숨김 행에 속하며, C2는 숨김 열에 속합니다; 예제는 각각 `False`, `True`, `True`를 출력합니다.

이 예제에서는 플롯 설정을 변경한 후 차트 데이터를 새로 고칩니다: [ReadWorkbookStream](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)으로 삽입된 워크북을 유지하고, [WriteWorkbookStream](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/)으로 다시 로드합니다. 모든 셀을 포함할 때는 숨겨진 2월 범주를 복원하기 위해 [SetRange](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/setrange/)도 사용해야 합니다. 플래그만 변경하는 것으로는 이 샘플의 캐시된 차트 데이터와 범주 레이블을 새로 고칠 수 없습니다.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"hidden-source-data.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    Console::WriteLine(u"B2 hidden: {0}", workbook->GetCell(0, u"B2")->get_IsHidden());
    Console::WriteLine(u"B3 hidden: {0}", workbook->GetCell(0, u"B3")->get_IsHidden());
    Console::WriteLine(u"C2 hidden: {0}", workbook->GetCell(0, u"C2")->get_IsHidden());

    auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
    for (auto visibleOnly : {true, false})
    {
        chart->set_PlotVisibleCellsOnly(visibleOnly);

        // 삽입된 워크북에서 차트 데이터를 새로 고칩니다.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // 숨겨진 카테고리를 포함한 전체 소스 범위를 복원합니다.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

예제는 `hidden_cells_True.pptx`를 저장하는데, 여기에는 표시된 소매 값(10과 20)만 포함되고, `hidden_cells_False.pptx`에는 모든 여섯 값이 포함됩니다. 아래 이미지에서 두 플롯 모드를 확인할 수 있습니다. 3행과 C열은 두 삽입 워크북 모두에서 여전히 숨겨져 있습니다.

| 표시된 셀만 (`true`) | 모든 셀 (`false`) |
| --- | --- |
| ![표시된 셀만: 1월과 3월의 소매 값 10과 20.](hidden_cells_True.png) | ![모든 셀: 1월, 2월, 3월의 소매 및 도매 값.](hidden_cells_False.png) |

값이 들어 있는 숨겨진 셀은 빈 셀과 다릅니다. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/get_displayblanksas/)는 누락된 값을 표시하는 방식을 제어하지만, 숨겨진 소스 데이터를 포함하거나 제외하지는 않습니다. 예제는 [빈 셀 표시 제어](/slides/ko/cpp/chart-series/#control-the-display-of-empty-cells)를 참고하십시오.

## **워크북에서 차트 데이터 읽고 쓰기**

Aspose.Slides for C++는 [ReadWorkbookStream](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) 및 [WriteWorkbookStream](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) 메서드를 제공하여 차트 데이터 워크북( Aspose.Cells로 편집된 차트 데이터 포함)을 읽고 쓸 수 있습니다. **참고** 차트 데이터는 동일한 형태로 정리되었거나 원본과 유사한 구조여야 합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형에 차트가 포함되어 있어야 하는 `chart.pptx`를 엽니다. 삽입된 워크북을 스트림으로 읽고, 기존 시리즈와 카테고리를 지운 다음 동일한 워크북을 다시 씁니다. 변경 사항은 메모리에 남으며, 예제는 프레젠테이션을 저장하지 않습니다.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **워크북 수정 후 차트 레이아웃 검증**

삽입된 워크북을 수정된 워크북으로 교체하면 차트는 원래의 시리즈와 카테고리 컬렉션을 유지합니다. 이 불일치는 [IChart::ValidateChartLayout](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/validatechartlayout/)가 인덱스 범위 초과 오류를 발생시킬 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 카테고리를 지우십시오. 이 예제는 첫 번째 슬라이드의 첫 번째 도형에 차트가 포함된 `chart.pptx`가 필요합니다. 주석은 워크북 편집이 이루어질 위치를 표시하며, 실행 가능한 예제는 원본 워크북을 다시 쓰고 메모리 내 레이아웃을 검증합니다.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    // 여기서 워크북 스트림을 수정합니다. 예: Aspose.Cells 사용.

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
    chart->ValidateChartLayout();
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

컬렉션을 지우면 워크북을 다시 쓸 때 오래된 데이터 참조가 제거됩니다. 업데이트된 워크북에 대해 필요한 시리즈 및 카테고리 매핑을 다시 구축한 후 차트를 사용하십시오.

## **워크북 셀을 차트 데이터 레이블로 지정**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다. 다음 단계에서는 버블 차트의 레이블을 해당 데이터 워크북의 셀에 연결하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 0 기반 인덱스로 첫 번째 슬라이드에 액세스합니다.
3. 기본 데이터가 있는 버블 차트를 추가합니다.
4. 차트 시리즈에 액세스합니다.
5. 워크북 셀을 데이터 레이블로 설정합니다.
6. 프레젠테이션을 저장합니다.

이 예제는 최소 하나의 슬라이드가 포함된 `chart2.pptx`를 열고, 기본 데이터가 있는 버블 차트를 추가합니다. 워크시트 0의 A10:A12 셀을 첫 번째 시리즈의 처음 세 레이블로 사용하고, 셀 기반 레이블을 활성화한 뒤 결과를 `resultchart.pptx`에 저장합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart2.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Bubble, 50, 50, 600, 400, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);
auto firstLabelCell = workbook->GetCell(0, u"A10", ObjectExt::Box<String>(u"Label 0 cell value"));
auto secondLabelCell = workbook->GetCell(0, u"A11", ObjectExt::Box<String>(u"Label 1 cell value"));
auto thirdLabelCell = workbook->GetCell(0, u"A12", ObjectExt::Box<String>(u"Label 2 cell value"));
series->get_Labels()->idx_get(0)->set_ValueFromCell(firstLabelCell);
series->get_Labels()->idx_get(1)->set_ValueFromCell(secondLabelCell);
series->get_Labels()->idx_get(2)->set_ValueFromCell(thirdLabelCell);

presentation->Save(u"resultchart.pptx", Export::SaveFormat::Pptx);
```

## **워크시트 관리**

[IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) 메서드는 차트 워크북에 포함된 워크시트에 대한 접근을 제공합니다. 이 예제는 기본 데이터가 있는 파이 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 500);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

for (auto i = 0; i < workbook->get_Worksheets()->get_Count(); i++)
{
    Console::WriteLine(workbook->get_Worksheets()->idx_get(i)->get_Name());
}
```

## **데이터 소스 유형 지정**

이 예제는 기본 데이터가 있는 3D 컬럼 차트를 생성하고, 서로 다른 데이터 소스를 사용하여 두 개의 시리즈 이름을 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째 이름은 워크시트 0의 셀 C1을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/datasourcetype/) 열거형은 각 이름의 소스를 선택합니다. 결과는 `pres.pptx`에 저장됩니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 600, 400, true);
auto literalName = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

literalName->set_DataSourceType(DataSourceType::StringLiterals);
literalName->set_Data(ObjectExt::Box<String>(u"LiteralString"));

auto cellName = chart->get_ChartData()->get_Series()->idx_get(1)->get_Name();
auto nameCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, u"C1", ObjectExt::Box<String>(u"NewCell"));
cellName->set_DataSourceType(DataSourceType::Worksheet);
cellName->set_Data(nameCell);

presentation->Save(u"pres.pptx", Export::SaveFormat::Pptx);
```

## **지원되지 않는 삽입 워크북 형식 감지**

Aspose.Slides는 일부 차트에 삽입될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. [IChartData](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/)의 [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) 메서드와 [WorkbookType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/workbooktype/) 열거형을 함께 사용하면 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 이 예제는 `sample.pptx`의 첫 번째 슬라이드에 있는 도형들을 검사하고, 차트가 아닌 도형은 건너뛰며, 삽입된 .xlsb 워크북이 있는 차트마다 진단 메시지를 출력합니다.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : IterateOver(slide->get_Shapes()))
{
    auto chart = AsCast<IChart>(shape);
    if (chart == nullptr)
    {
        continue;
    }

    auto chartData = chart->get_ChartData();
    auto isInternalWorkbook = chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook;
    auto isBinaryMacro = chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console::WriteLine(u"Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // 여기서 지원되는 차트 워크북 데이터를 읽거나 수정합니다.
}
```

## **외부 워크북**

Aspose.Slides는 외부 워크북을 차트의 데이터 소스로 사용하는 것을 지원합니다.

### **외부 워크북 만들기**

[ReadWorkbookStream](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)와 [SetExternalWorkbook](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/)을 사용하여 삽입된 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결합니다.

이 예제는 기본 데이터가 있는 파이 차트를 만들고, 워크북을 `externalWorkbook1.xlsx`에 기록한 뒤 출력 스트림을 닫고 파일을 차트 데이터 소스로 할당합니다. 연결된 프레젠테이션은 `externalWorkbook.pptx`에 저장됩니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600);
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook1.xlsx");
auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
auto fileStream = IO::File::Create(workbookPath);
workbookStream->CopyTo(fileStream);
fileStream->Close();

chart->get_ChartData()->SetExternalWorkbook(workbookPath);
presentation->Save(u"externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

### **외부 워크북 설정**

[SetExternalWorkbook](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) 메서드를 사용하면 차트에 외부 워크북을 데이터 소스로 지정할 수 있습니다. 이 메서드는 외부 워크북의 경로가 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 직접 편집할 수는 없지만, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 상대 경로가 지정되면 자동으로 전체 경로로 변환됩니다.

이 예제는 작업 디렉터리에 `externalWorkbook.xlsx`가 있어야 합니다. `Sheet1` 워크시트에는 B1에 시리즈 이름, A2:A4에 카테고리 이름, B2:B4에 숫자 값이 들어 있어야 합니다. 예제는 파이 차트를 만들고, 워크북을 연결한 뒤, [SetRange](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/setrange/)을 사용해 A1:B4를 하나의 시리즈와 세 개의 카테고리로 매핑합니다. 결과는 `Presentation_with_externalWorkbook.pptx`에 저장됩니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);
auto chartData = chart->get_ChartData();
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook.xlsx");

chartData->SetExternalWorkbook(workbookPath);
chartData->SetRange(u"Sheet1!$A$1:$B$4");

presentation->Save(u"Presentation_with_externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

[SetExternalWorkbook](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/)의 `updateChartData` 매개변수는 워크북이 로드되는지를 제어합니다.

* `updateChartData`가 `false`이면 워크북 경로만 업데이트됩니다. 차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않으며, 워크북이 없어도 됩니다.
* `updateChartData`가 `true`이면 차트 데이터가 대상 워크북에서 업데이트됩니다.

다음 예제는 `updateChartData`를 `false`로 설정하고 자리 표시자 URL을 할당합니다. 파이 차트는 기본 데이터를 유지하고, 사용할 수 없는 워크북을 로드하지 않은 채 프레젠테이션을 저장합니다.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);

chart->get_ChartData()->SetExternalWorkbook(u"https://example.com/unavailable-workbook.xlsx", false);
presentation->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", Export::SaveFormat::Pptx);
```

### **차트의 외부 데이터 소스 워크북 경로 가져오기**

차트에 연결된 워크북을 확인하려면 먼저 차트가 외부 데이터 소스를 사용하는지 확인하십시오. 외부 워크북인 경우 다음 단계에 따라 워크북 경로를 가져올 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 0 기반 인덱스로 첫 번째 슬라이드에 액세스합니다.
3. 첫 번째 도형이 차트인지 확인합니다.
4. 차트 데이터 소스 유형을 읽습니다.
5. 소스가 외부 워크북이면 경로를 읽습니다.

이 예제는 앞서 만든 `externalWorkbook.pptx`를 열고 첫 번째 슬라이드의 첫 번째 도형을 검사합니다. 차트가 외부 워크북에 연결되어 있으면 [get_ExternalWorkbookPath](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/)을 콘솔에 출력합니다. 그런 다음 프레젠테이션 복사본을 `Result.pptx`로 저장합니다.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"externalWorkbook.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    if (chartData->get_DataSourceType() == ChartDataSourceType::ExternalWorkbook)
    {
        Console::WriteLine(chartData->get_ExternalWorkbookPath());
    }
    else
    {
        Console::WriteLine(u"The chart does not use an external workbook.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}

presentation->Save(u"Result.pptx", Export::SaveFormat::Pptx);
```

### **차트 데이터 편집**

외부 워크북의 데이터를 내부 워크북을 편집하는 방식과 동일하게 수정할 수 있습니다. 외부 워크북을 로드할 수 없는 경우 예외가 발생합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형에 차트가 포함된 `presentation.pptx`와 접근 가능한 외부 워크북이 필요합니다. 첫 번째 시리즈의 첫 번째 데이터 포인트에 대한 셀 기반 값을 100으로 설정하고, 프레젠테이션을 `presentation_out.pptx`에 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일이 업데이트되므로 원본 워크북을 보존해야 할 경우 복사본을 사용하십시오.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto series = chart->get_ChartData()->get_Series();
    if (series->get_Count() > 0 && series->idx_get(0)->get_DataPoints()->get_Count() > 0)
    {
        auto valueCell = series->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell();
        if (valueCell != nullptr)
        {
            valueCell->set_Value(ObjectExt::Box<int32_t>(100));
            presentation->Save(u"presentation_out.pptx", Export::SaveFormat::Pptx);
        }
        else
        {
            Console::WriteLine(u"The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console::WriteLine(u"The chart has no data points to edit.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **차트 캐시에서 워크북 복구**

차트가 누락되었거나 사용 불가능한 외부 워크북을 사용하고 있는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 기반으로 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/)를 생성하고, [set_SpreadsheetOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/)로 구성한 뒤, [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/)를 `true`로 설정하고 프레젠테이션을 엽니다.

다음 C++ 예제는 첫 번째 슬라이드의 첫 번째 도형이 사용 불가능한 외부 워크북을 참조하는 차트인 `presentation.pptx`를 열고, [IChart::get_ChartData](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/get_chartdata/)와 [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/)를 통해 복구된 데이터를 액세스합니다:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // 여기서 복구된 워크북 데이터를 읽거나 수정합니다.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

외부 워크북이 사용 불가능하고 복구가 비활성화된 경우, Aspose.Slides는 [System::InvalidOperationException](https://reference.aspose.com/slides/ko/cpp/system/details_invalidoperationexception/)을 발생시킵니다. 캐시된 차트 데이터를 사용해도 되는 경우에만 복구를 활성화하십시오. 캐시는 외부 워크북이 마지막으로 프레젠테이션이 업데이트된 이후에 변경된 내용을 포함하지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지, 삽입된 워크북에 연결되어 있는지를 확인할 수 있나요?**

네. 차트는 [데이터 소스 유형](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/chartdata/get_datasourcetype/)과 [외부 워크북 경로](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)을 가지고 있습니다. 소스가 외부 워크북인 경우 전체 경로를 읽어 외부 파일이 사용되고 있는지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

네. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 절대 경로를 PPTX 파일에 저장하므로, 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 위치한 워크북을 사용할 수 있나요?**

네, 이러한 워크북을 외부 데이터 소스로 사용할 수 있습니다. 그러나 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스 역할만 할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX 파일을 덮어쓰나요?**

프레젠테이션은 외부 파일에 대한 **링크**만 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본 워크북을 변경하지 않아야 한다면 복사본을 사용하십시오.

**외부 파일에 비밀번호가 설정되어 있으면 어떻게 해야 하나요?**

Aspose.Slides는 링크 시 비밀번호를 받지 않습니다. 일반적인 방법은 사전에 보호를 해제하거나, [Aspose.Cells](https://reference.aspose.com/cells/cpp/)와 같이 복호화된 복사본을 만든 뒤 그 복사본에 링크하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

네. 각 차트는 자체 링크를 저장합니다. 모두 같은 파일을 가리키면 해당 파일을 업데이트할 때마다 다음 데이터 로드 시 모든 차트에 반영됩니다.