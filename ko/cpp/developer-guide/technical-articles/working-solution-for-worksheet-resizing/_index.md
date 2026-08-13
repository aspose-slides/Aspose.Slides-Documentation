---
title: 워크시트 크기 조정에 대한 작업 솔루션
type: docs
weight: 130
url: /ko/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 미리보기 이미지
- 이미지 크기 조정
- Excel
- 워크시트
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides for C++
description: "PowerPoint 프레젠테이션에서 C++를 사용하여 워크시트 크기 조정을 위한 작업 솔루션"
---
{{% alert color="info" %}}

Aspose 구성 요소를 통해 PowerPoint 프레젠테이션에 OLE 개체로 포함된 Excel 워크시트가 처음 활성화된 후 알 수 없는 비율로 크기가 조정되는 것이 관찰되었습니다. 이 동작은 OLE 개체의 활성화 전후 상태 사이에 눈에 띄는 시각적 차이를 만듭니다. 우리는 이 문제를 자세히 조사하고 해결책을 제시했으며, 이 기사에서 다룹니다.

{{% /alert %}}

## **배경**

이 기사 [OLE 관리](/slides/ko/cpp/manage-ole/)에서는 Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에 OLE 프레임을 추가하는 방법을 설명했습니다. [개체 미리보기 문제](/slides/ko/cpp/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 선택한 워크시트 영역의 이미지를 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 워크시트 이미지를 표시하는 OLE 개체 프레임을 두 번 클릭하면 Excel 통합 문서가 활성화됩니다. 최종 사용자는 실제 Excel 통합 문서에서 원하는 변경을 수행한 다음 활성화된 Excel 통합 문서 외부를 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아가면 OLE 개체 프레임 크기가 변경됩니다. 크기 조정 비율은 OLE 개체 프레임과 포함된 Excel 통합 문서의 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 통합 문서는 자체 창 크기를 가지고 있기 때문에 처음 활성화될 때 원래 크기를 유지하려고 합니다. 반면 OLE 개체 프레임은 자체 크기를 가지고 있습니다. Microsoft에 따르면 Excel 통합 문서가 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 삽입 과정의 올바른 비율을 유지합니다. 크기 조정은 Excel 창 크기와 OLE 개체 프레임의 크기 및 위치 차이에 따라 발생합니다.

## **작업 해결책**

크기 조정 효과를 방지하기 위한 두 가지 가능한 해결책이 있습니다.

- PowerPoint 프레젠테이션에서 OLE 프레임 크기를 OLE 프레임에 원하는 행 및 열 수의 높이와 너비에 맞게 조정합니다.
- OLE 프레임 크기를 일정하게 유지하고 참여하는 행 및 열의 크기를 선택한 OLE 프레임 크기에 맞게 조정합니다.

### **OLE 프레임 크기 조정**

이 방법에서는 포함된 Excel 통합 문서의 OLE 프레임 크기를 Excel 워크시트에서 참여하는 행과 열의 누적 크기에 맞게 설정하는 방법을 배웁니다.

템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가한다고 가정해 보겠습니다. 이 경우 OLE 개체 프레임의 크기는 먼저 통합 문서에서 참여하는 행과 열의 누적 행 높이 및 열 너비를 기준으로 계산됩니다. 그런 다음 계산된 값으로 OLE 프레임 크기를 설정합니다. PowerPoint에서 OLE 프레임에 표시되는 빨간색 "EMBEDDED OLE OBJECT" 메시지를 방지하기 위해 통합 문서에서 원하는 행과 열 부분의 이미지를 캡처하여 OLE 프레임 이미지로 설정합니다.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"
using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **셀 범위 크기 조정**

이 방법에서는 참여하는 행의 높이와 열의 너비를 맞춤형 OLE 프레임 크기에 맞게 조정하는 방법을 배웁니다.

템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가한다고 가정해 보겠습니다. 이 경우 OLE 프레임의 크기를 설정하고 OLE 프레임 영역에 참여하는 행과 열의 크기를 조정합니다. 그런 다음 통합 문서를 스트림에 저장하여 변경 사항을 적용하고 OLE 프레임에 추가하기 위해 바이트 배열로 변환합니다. PowerPoint에서 OLE 프레임에 표시되는 빨간색 "EMBEDDED OLE OBJECT" 메시지를 방지하기 위해 통합 문서에서 원하는 행과 열 부분의 이미지를 캡처하여 OLE 프레임 이미지로 설정합니다.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// PowerPoint에서 통합 문서 파일을 OLE 개체로 사용할 때 표시되는 크기를 설정합니다.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// 프레임 크기에 맞게 셀 범위를 스케일합니다.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// 수정된 통합 문서를 사용해야 합니다.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// OLE 이미지를 프레젠테이션 리소스에 추가합니다.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// OLE 개체 프레임을 생성합니다.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">셀 범위의 예상 너비(포인트)입니다.</param>
/// <param name="height">셀 범위의 예상 높이(포인트)입니다.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"
using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **결론**

{{% alert color="info" %}}

워크시트 크기 조정 문제를 해결하는 두 가지 접근 방식이 있습니다. 적절한 접근 방식 선택은 특정 요구 사항 및 사용 사례에 따라 달라집니다. 두 접근 방식 모두 템플릿에서 생성하든 처음부터 생성하든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 개체 프레임 크기에 제한이 없습니다.

{{% /alert %}}

## **FAQ**

### PowerPoint에서 처음 활성화될 때 포함된 Excel 워크시트가 크기가 변하는 이유는 무엇인가요?

이는 Excel이 활성화될 때 원래 창 크기를 유지하려고 하고, PowerPoint의 OLE 개체 프레임은 자체 크기를 갖기 때문입니다. PowerPoint와 Excel이 비율을 유지하도록 크기를 협상하기 때문에 크기 조정이 발생할 수 있습니다.

### 이 크기 조정 문제를 완전히 방지할 수 있나요?

예. OLE 프레임을 Excel 셀 범위 크기에 맞게 스케일하거나 셀 범위를 원하는 OLE 프레임 크기에 맞게 스케일하면 원하지 않는 크기 조정을 방지할 수 있습니다.

### 프레젠테이션에서 원본 Excel 행 및 열 크기를 유지하려면 **OLE 프레임 스케일링**을, OLE 프레임을 고정된 크기로 유지하려면 **셀 범위 스케일링**을 선택하십시오.

프레젠테이션에서 원본 Excel 행 및 열 크기를 유지하려면 **OLE 프레임 스케일링**을 선택하십시오. OLE 프레임을 고정된 크기로 유지하려면 **셀 범위 스케일링**을 선택하십시오.

### 템플릿을 기반으로 만든 프레젠테이션에서도 이 솔루션이 작동하나요?

예. 두 솔루션 모두 템플릿에서 만든 프레젠테이션과 처음부터 만든 프레젠테이션에서 작동합니다.

### 이러한 방법을 사용할 때 OLE 프레임 크기에 제한이 있나요?

아니오. 적절히 스케일만 조정하면 OLE 개체 프레임을 원하는 크기로 만들 수 있습니다.

### PowerPoint에서 "EMBEDDED OLE OBJECT" 플레이스홀더 텍스트를 피하는 방법이 있나요?

예. 대상 Excel 셀 범위의 스냅샷을 찍어 OLE 프레임의 플레이스홀더 이미지로 설정하면 기본 플레이스홀더 대신 사용자 정의 미리보기 이미지를 표시할 수 있습니다.

## **관련 기사**

[Excel 차트를 만들고 OLE 개체로 프레젠테이션에 삽입하기](/slides/ko/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)