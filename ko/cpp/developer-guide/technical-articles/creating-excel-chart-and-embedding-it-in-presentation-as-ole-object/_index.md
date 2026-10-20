---
title: Excel 차트를 만들고 프레젠테이션에 OLE 개체로 삽입
type: docs
weight: 40
url: /ko/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 차트
- 차트 삽입
- OLE 개체
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Cells for C++를 사용하여 Excel 차트를 만들고, Aspose.Slides를 사용하여 워크북을 PowerPoint 프레젠테이션에 삽입하며 차트 미리보기를 포함합니다."
---
## **개요**

이 문서에서는 Aspose.Cells for C++를 사용하여 Excel 세로 막대 차트를 만들고, 해당 워크북을 Aspose.Slides for C++를 사용한 PowerPoint 프레젠테이션에 삽입하는 방법을 보여줍니다. 삽입된 워크북에는 원본 데이터와 차트가 모두 포함됩니다. 별도의 PNG 미리보기가 OLE 개체가 활성화되기 전에 슬라이드에 차트를 표시합니다.

결과는 원본 PowerPoint 차트가 아니라 삽입된 Excel 개체입니다. OLE를 통해 워크북을 편집하려면 OLE 활성화를 지원하는 데스크톱 애플리케이션과 호환 가능한 Excel이 설치되어 있어야 합니다.

## **사전 요구 사항**

Aspose.Cells for C++ 및 Aspose.Slides for C++에 대한 헤더와 라이브러리를 사용하도록 C++ 프로젝트를 구성합니다. 예제 코드를 파일 범위에 포함 선언과 함께 애플리케이션 진입점에 배치합니다. Microsoft Office는 이러한 라이브러리로 프레젠테이션을 생성하는 데 필요하지 않습니다.

입력 파일은 필요하지 않습니다. 예제는 메모리에서 데이터와 차트를 생성한 다음 현재 작업 디렉터리에 `OutputChart.pptx`를 기록합니다. 평가 모드가 아닌 경우 두 제품 모두에 대한 라이선스를 적용하십시오.

## **삽입 작동 방식**

1. 데이터 워크시트와 차트 시트를 포함하는 워크북을 만든다.
1. 차트 시트를 활성화하여 워크북이 차트에서 열리게 한다.
1. 워크북의 OLE 표시 범위를 설정하고 차트를 PNG로 렌더링한다.
1. 워크북을 메모리의 XLSX 형식으로 저장하고 해당 바이트를 슬라이드에 삽입한다.
1. PNG를 OLE 개체의 미리보기로 지정하고 프레젠테이션을 PPTX로 저장한다.

워크북 표시 범위와 슬라이드의 프레임은 서로 다른 역할을 합니다. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/)은 0 기반 시작/끝 행 및 열 인덱스를 사용합니다. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/)은 대신 상단 행, 왼쪽 열, 하단 행 및 오른쪽 열을 사용합니다. 예제는 하단 오른쪽 경계로 행 인덱스 55와 열 인덱스 25를 사용합니다; 이러한 값은 레이아웃 선택이며 데이터 행이나 열 수를 의미하지 않습니다.

슬라이드 프레임은 포인트 단위를 사용합니다. 예제는 슬라이드 안에 프레임을 맞추고 PNG의 종횡비를 유지하면서 중앙에 배치합니다. 미리보기를 슬라이드 전체에 늘리지 않습니다.

## **차트 생성 및 삽입**

다음 전체 예제는 `DataSheet`에 4개의 행과 5개의 열에 걸친 값을 채웁니다. 각 행은 차트 시리즈가 됩니다. `ChartSheet`는 워크북을 저장하기 전에 활성 시트로 선택됩니다.

워크북은 명시적으로 XLSX 형식으로 저장되며, 이는 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/)에 전달된 `xlsx` 확장자와 일치합니다. PNG는 중간 비트맵 변환 없이 메모리 스트림에서 직접 로드됩니다. Aspose.Cells는 바이트 벡터를 반환하며, 예제는 이를 Aspose.Slides가 허용하는 배열 유형으로 복사합니다. Aspose.Cells 객체를 사용하기 전에 초기화하고 해당 객체가 파괴된 후에는 리소스를 해제합니다. [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/)을 통해 지정하면 기본 OLE 자리표시자가 교체됩니다.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Initialize Cells before creating any of its objects.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Render the chart preview and serialize the editable workbook separately.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Copy Cells buffers into the array type used by Slides.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Fit the preview within the slide without changing its aspect ratio.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// Release Cells resources after all Cells objects have been destroyed.
Aspose::Cells::Cleanup();
```

## **예상 결과**

`OutputChart.pptx`에는 삽입된 Excel 워크북과 차트 미리보기가 포함된 하나의 슬라이드가 들어 있습니다. 워크북에는 원본 데이터와 네 개의 시리즈가 있는 세로 막대 차트가 포함됩니다. 미리보기는 슬라이드 중앙에 배치되고 비율을 유지합니다.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

Excel이 설치된 호환 가능한 데스크톱 PowerPoint 환경에서 객체를 두 번 클릭하면 삽입된 워크북을 활성화하고 편집할 수 있습니다. 활성화 및 편집은 호스트 애플리케이션의 OLE 지원 및 보안 설정에 따라 달라집니다.

## **자주 묻는 질문**

**미리보기 이미지가 왜 필요합니까?**

삽입된 워크북과 슬라이드 미리보기는 별개의 콘텐츠입니다. 차트 이미지를 제공하여 슬라이드가 기본 "EMBEDDED OLE OBJECT" 자리표시자 대신 차트를 표시하도록 합니다. [Object Preview Issue when Adding OleObjectFrame](/slides/ko/cpp/object-preview-issue-when-adding-oleobjectframe/).

**코드에서 워크북을 변경하면 미리보기가 자동으로 업데이트됩니까?**

미리보기는 스냅샷으로 간주합니다. 프로그래밍 방식으로 워크북 데이터를 업데이트할 때 차트 이미지를 다시 생성하고 미리보기와 삽입된 워크북 데이터를 모두 교체해야 합니다.

**XLS 대신 XLSX를 사용할 수 있습니까?**

예. 워크북을 XLS 형식으로 저장하고 `xls`를 삽입된 데이터 확장자로 사용합니다. 확장자는 실제 워크북 형식과 일치해야 하며, 확장자만 변경해도 데이터가 변환되지 않습니다.

**활성화 후 객체 크기가 변경되는 이유는 무엇입니까?**

호스트 애플리케이션은 워크북을 활성화할 때 OLE 객체의 표시를 업데이트할 수 있습니다. 워크북의 OLE 표시 범위와 슬라이드 프레임 크기 모두가 영향을 미칩니다. [Working Solution for Chart Resizing in PPTX](/slides/ko/cpp/working-solution-for-chart-resizing-in-pptx/).

## **관련 섹션**

- [Working Solution for Chart Resizing in PPTX](/slides/ko/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/ko/cpp/object-preview-issue-when-adding-oleobjectframe/)