---
title: 워크시트 크기 조정을 위한 실행 가능한 솔루션
type: docs
weight: 130
url: /ko/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 미리 보기 이미지
- 이미지 크기 조정
- Excel
- 워크시트
- PowerPoint
- 프레젠테이션
- C++
- C++용 Aspose.Slides
description: "C++를 사용한 PowerPoint 프레젠테이션에서 워크시트 크기 조정을 위한 실행 가능한 솔루션"
---
{{% alert color="info" title="Note" %}}
Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 워크시트는 처음 활성화된 후 예상치 않게 크기가 조정될 수 있습니다. 이 동작은 OLE 개체가 활성화 전후에 눈에 띄는 시각적 차이를 만들게 됩니다. 이 문서에서는 문제를 설명하고 이를 해결하는 두 가지 방법을 제시합니다.
{{% /alert %}}

## **배경**

In the article [OLE 관리](/slides/ko/cpp/manage-ole/), we explained how to add an OLE frame to a PowerPoint presentation using Aspose.Slides for C++. To address the [개체 미리 보기 문제](/slides/ko/cpp/object-preview-issue-when-adding-oleobjectframe/), we assigned an image of the selected worksheet area to the OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the worksheet image, the Excel workbook is activated. End users can make any desired changes to the actual Excel workbook and then return to the slide by clicking outside the activated Excel workbook. The size of the OLE object frame will change when the user returns to the slide. The resizing factor will vary depending on the size of the OLE object frame and the embedded Excel workbook.

## **크기 조정 원인**

Excel 워크북은 자체 윈도우 크기를 가지고 있어 첫 활성화 시 원래 크기를 유지하려고 합니다. 반면 OLE 개체 프레임은 자체 크기를 가지고 있습니다. Microsoft에 따르면 Excel 워크북이 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 임베딩 과정의 비율을 유지합니다. 크기 조정은 Excel 창 크기와 OLE 개체 프레임의 크기 및 위치 차이에 따라 발생합니다.

## **작동 솔루션**

크기 조정 효과를 피하기 위한 두 가지 가능한 솔루션이 있습니다.

- PowerPoint 프레젠테이션에서 OLE 프레임을 선택된 행과 열의 전체 높이와 너비에 맞게 스케일링합니다.
- OLE 프레임 크기를 고정하고 선택된 행과 열을 프레임에 맞게 스케일링합니다.

### **OLE 프레임 크기 조정**

이 접근 방식은 삽입된 Excel 워크시트에서 선택된 행과 열의 전체 높이와 너비에 맞게 OLE 프레임 크기를 설정합니다.

예제는 기존 Excel 워크북을 로드하고 첫 번째 워크시트의 처음 10개 행과 13개 열을 0 기반 인덱스로 선택합니다. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/)이 표시 범위를 정의합니다. 미리 보기는 96 DPI로 렌더링되며 픽셀 차원은 인치당 72포인트를 사용해 포인트로 변환됩니다. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/)이 해당 차원으로 프레임에 수정된 워크북을 삽입합니다. 미리 보기는 [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/)을 통해 저장된 프레젠테이션의 "EMBEDDED OLE OBJECT" 자리 표시자를 교체하도록 지정됩니다.

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

// PowerPoint에서 워크북 파일을 OLE 개체로 사용할 때 표시 크기를 설정합니다.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// OLE 이미지의 너비와 높이를 포인트 단위로 가져옵니다.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// 수정된 워크북을 사용해야 합니다.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// OLE 이미지를 프레젠테이션 리소스에 추가합니다.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// OLE 개체 프레임을 생성합니다.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

미리 보기 도우미는 [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/)를 사용해 범위를 선택하고 여백, 머리글 및 바닥글을 제거합니다. [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/)가 활성화된 상태에서 [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/)가 범위를 PNG 이미지로 렌더링합니다. 도우미는 렌더링된 이미지 데이터를 새 메모리 스트림에 복사하고 스트림 위치를 처음으로 설정해 프레젠테이션에서 사용할 수 있게 합니다.

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

이 접근 방식은 선택된 행의 높이와 열의 너비를 사용자 지정 OLE 프레임 크기에 맞게 스케일링합니다.

예제는 기존 Excel 워크북을 로드하고 첫 번째 워크시트의 처음 10개 행과 13개 열을 0 기반 인덱스로 선택합니다. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/)이 표시 범위를 정의하고, 아래 도우미가 해당 범위를 너비 400포인트, 높이 100포인트인 프레임에 맞게 스케일링합니다. 수정된 워크북을 바이트 배열로 저장한 후 [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/)가 지정된 크기로 삽입합니다. 96 DPI로 렌더링된 미리 보기는 [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/)을 통해 할당되어 저장된 프레젠테이션에 기본 자리 표시자 대신 선택된 셀을 표시합니다.

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

// PowerPoint에서 워크북 파일을 OLE 개체로 사용할 때 표시 크기를 설정합니다.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// 셀 범위를 프레임 크기에 맞게 스케일링합니다.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// 수정된 워크북을 사용해야 합니다.
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

스케일링 도우미는 선택된 범위에 대해 열의 상대 너비와 행의 상대 높이를 보존하면서 별도의 너비와 높이 비율을 계산합니다. 계산된 차원을 포인트에서 인치로 변환한 뒤 [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/)와 [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/)을 사용해 적용합니다. 선택된 범위는 너비와 높이가 0이 아니어야 합니다.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">셀 범위의 예상 너비(포인트 단위).</param>
/// <param name="height">셀 범위의 예상 높이(포인트 단위).</param>
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

이 미리 보기 도우미는 [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/)을 사용해 크기 조정된 범위를 렌더링합니다. [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/)를 사용해 해당 범위만 인쇄하도록 제한하고, 여백, 머리글 및 바닥글을 제거한 뒤 시작 위치가 처음인 PNG 스트림을 반환합니다.

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

{{% alert color="info" title="Note" %}}
워크시트 크기 조정 문제를 해결하는 두 가지 접근 방식이 있습니다. 요구 사항과 사용 사례에 가장 적합한 방식을 선택하십시오. 두 접근 방식 모두 템플릿에서 생성하든 처음부터 만들든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 개체 프레임 크기에 제한이 없습니다.
{{% /alert %}}

## **자주 묻는 질문**

**PowerPoint에서 처음 활성화될 때 삽입된 Excel 워크시트가 크기가 변하는 이유는 무엇인가요?**

Excel은 활성화될 때 원래 창 크기를 유지하려고 하며, PowerPoint의 OLE 개체 프레임은 자체 크기를 가지고 있기 때문입니다. PowerPoint와 Excel이 비율을 유지하도록 크기를 협상하면서 크기 조정이 발생합니다.

**이 크기 조정 문제를 완전히 방지할 수 있나요?**

예. OLE 프레임을 Excel 셀 범위 크기에 맞게 스케일링하거나, 셀 범위를 원하는 OLE 프레임 크기에 맞게 스케일링하면 원치 않는 크기 조정을 방지할 수 있습니다.

**어떤 스케일링 방법을 사용해야 하나요, OLE 프레임 스케일링 아니면 셀 범위 스케일링인가요?**

원본 Excel 행 및 열 크기를 유지하고 싶다면 **OLE 프레임 스케일링**을 선택하십시오. 프레젠테이션에서 OLE 프레임의 고정 크기를 원한다면 **셀 범위 스케일링**을 선택하십시오.

**템플릿 기반 프레젠테이션에서도 이 솔루션이 작동하나요?**

예. 두 솔루션 모두 템플릿에서 만든 프레젠테이션과 처음부터 만든 프레젠테이션 모두에서 작동합니다.

**이 방법을 사용할 때 OLE 프레임 크기에 제한이 있나요?**

아니오. 적절히 스케일을 설정하면 OLE 개체 프레임을 원하는 어떤 크기로도 만들 수 있습니다.

**PowerPoint에서 "EMBEDDED OLE OBJECT" 자리 표시자 텍스트를 없앨 방법이 있나요?**

예. 대상 Excel 셀 범위의 스냅샷을 가져와 OLE 프레임의 자리 표시자 이미지로 설정하면 기본 자리 표시자 대신 사용자 정의 미리 보기 이미지를 표시할 수 있습니다.

## **관련 문서**

[Excel 차트를 만들고 OLE 개체로 프레젠테이션에 삽입하기](/slides/ko/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)