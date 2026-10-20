---
title: PPTX에서 차트 크기 조정에 대한 실용적인 솔루션
type: docs
weight: 60
url: /ko/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- 차트 크기 조정
- Excel 차트
- OLE 객체
- 차트 삽입
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++와 함께 삽입된 Excel OLE 객체를 사용할 때 PPTX에서 발생하는 예기치 않은 차트 크기 조정을 해결합니다. 차트와 OLE 프레임 크기를 일관되게 유지하기 위해 고정 차트 차원을 설정합니다."
---
## **배경**

Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 객체로 삽입된 Excel 차트는 최초 활성화 후 크기가 변경될 수 있습니다. 이는 차트가 활성화 전후에 외관상의 눈에 띄는 차이를 일으킬 수 있습니다. 이 문서에서는 크기 조정이 발생하는 이유를 설명하고 고정 차트 차원을 OLE 프레임에 맞추어 이를 방지하는 방법을 보여줍니다.

[프레젠테이션에 OLE 객체로 삽입된 Excel 차트 만들기](/slides/ko/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)에서는 Aspose.Cells for C++를 사용하여 Excel 차트를 만들고 Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에 삽입하는 방법을 설명했습니다. [객체 미리 보기 문제](/slides/ko/cpp/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 차트 이미지를 차트의 OLE 객체 프레임에 할당했습니다. 출력 프레젠테이션에서 차트 이미지를 표시하는 OLE 객체 프레임을 두 번 클릭하면 Excel 차트가 활성화됩니다. 사용자는 삽입된 Excel 워크북을 편집한 다음 활성화된 워크북 외부를 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아갈 때 OLE 객체 프레임의 크기가 변경되며, 크기 조정 비율은 OLE 객체 프레임과 삽입된 Excel 워크북의 원래 크기에 따라 달라집니다.

## **크기 조정 원인**

삽입된 Excel 워크북은 자체 창 크기를 가지고 있으며, 객체가 최초 활성화될 때 Excel은 이 크기를 유지하려고 합니다. 슬라이드의 OLE 프레임은 독립적으로 정의된 크기를 가집니다. Excel 워크북이 활성화되면 Excel과 PowerPoint가 객체의 비율을 유지하도록 크기를 협상합니다. 워크북 창과 OLE 프레임 간의 차이로 인해 객체 크기가 변경될 수 있습니다.

## **작동 솔루션**

차트 크기를 슬라이드의 OLE 프레임에 맞추고 차트 차원을 워크북 창과 독립적으로 유지합니다. 이 솔루션은 새 프레젠테이션이나 기존 템플릿 모두에 적용됩니다.

예제는 Aspose.Cells for C++와 Aspose.Slides for C++가 필요합니다. 활성 차트 시트에 간단한 세로 막대 차트를 만들고 워크북을 XLS 형식으로 삽입합니다. 차트 미리 보기 이미지는 할당되지 않으며, OLE 객체가 PowerPoint에서 활성화될 때 차트가 표시됩니다.

예제 코드를 애플리케이션 진입점에 배치하고, 포함 선언은 파일 범위에 두세요. Aspose.Cells를 객체를 만들기 전에 초기화하고, 객체가 파괴된 후에 리소스를 해제합니다. 예제는 Aspose.Cells에서 반환된 워크북 바이트 벡터를 Aspose.Slides가 수용하는 배열 형태로 복사합니다.

예제는 왼쪽 가장자리에서 0.5인치, 위에서 1인치 떨어진 9.5 × 4인치 OLE 프레임을 가진 새 프레젠테이션을 생성합니다. 슬라이드 좌표와 치수는 포인트(인치당 72포인트) 단위입니다. 기존 프레젠테이션의 경우 [템플릿 사용](#use-a-template)을 참조하십시오.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 슬라이드 좌표와 크기는 포인트 단위(인치당 72포인트)입니다.
    auto width = 684.f; // 9.5 인치.
    auto height = 288.f; // 4 인치.

    chart.SetSizeWithWindow(false);
    // 포인트를 인치당 96픽셀을 사용하여 차트 픽셀로 변환합니다.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Cells 바이트 벡터를 Slides에서 허용하는 배열 유형으로 복사합니다.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```
## **고정 차트 크기 설정**

[Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/)를 false로 설정하여 차트 차원이 워크북 창과 독립적이도록 합니다. [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/)의 차원을 [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/)와 [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/)를 통해 설정하고, 인치를 96픽셀로 환산하여 포인트를 픽셀로 변환합니다: 684 × 288 포인트 프레임은 912 × 384 픽셀 차트에 해당합니다. [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/)를 [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/)의 Custom 값으로 설정합니다. 예제는 [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/)을 사용하여 워크북을 삽입하고 9.5 × 4인치 OLE 프레임이 있는 프레젠테이션을 저장합니다.

## **템플릿 사용**

기존 프레젠테이션에서도 크기 조정 로직은 동일합니다. 예제를 적용하려면:

1. 빈 프레젠테이션을 만들지 말고 템플릿 프레젠테이션을 로드합니다.
2. 첫 번째 슬라이드에 최소 세 개 이상의 도형이 있는지 확인한 후 인덱스 2의 도형을 자리표시자로 사용합니다.
3. 고정값 684와 288을 사용하지 않고 해당 도형에서 프레임 너비와 높이를 가져옵니다. 크기 계산은 변경하지 않습니다.
4. 고정 좌표 36 및 72 대신 자리표시자의 위치에 OLE 프레임을 추가합니다.
5. 프레젠테이션을 저장하기 전에 자리표시자를 제거합니다.

## **FAQ**

**PowerPoint에서 활성화한 후 삽입된 Excel 차트가 크기가 변하는 이유는 무엇인가요?**

이는 Excel이 최초 활성화 시 원래 창 크기를 복원하려고 시도하고, PowerPoint의 OLE 객체 프레임은 자체 차원을 가지고 있기 때문입니다. PowerPoint와 Excel가 종횡비를 유지하도록 크기를 협상하므로 크기 조정이 발생할 수 있습니다.

**차트와 OLE 프레임 크기를 일관되게 유지하려면 어떻게 해야 하나요?**

고정 차트 차원을 OLE 프레임에 맞추고 워크북을 삽입하기 전에 사용자 지정 차트 인쇄 크기를 사용하십시오. 위 예제는 필요한 설정과 단위 변환을 보여줍니다.

**워크북 창 크기를 맞추는 것만으로 충분한가요?**

워크북 창만 맞추는 것으로는 활성화 후 OLE 프레임이 크기가 변하는 것을 확실히 방지할 수 없습니다. 예제와 같이 고정 차트 차원을 사용하십시오.

**이 솔루션은 템플릿 기반 프레젠테이션과 새 프레젠테이션 모두에 적용됩니까?**

예. 템플릿의 경우 자리표시자의 차원과 위치를 사용합니다. 새 프레젠테이션의 경우 프레임 차원과 위치를 직접 지정합니다.

**다른 스프레드시트 프로그램으로 만든 차트에도 이 예제를 사용할 수 있나요?**

예제는 Aspose.Cells로 만든 Excel 워크북을 사용합니다. 다른 스프레드시트 프로그램에 대한 활성화 동작은 보여주지 않습니다.

## **관련 섹션**

- [프레젠테이션에 OLE 객체로 삽입된 Excel 차트 만들기](/slides/ko/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)