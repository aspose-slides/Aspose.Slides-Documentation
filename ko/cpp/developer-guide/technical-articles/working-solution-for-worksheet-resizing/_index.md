---
title: 워크시트 크기 조정을 위한 실용적인 솔루션
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
description: "C++를 사용한 PowerPoint 프레젠테이션에서 워크시트 크기 조정을 위한 실용적인 솔루션"
---
{{% alert color="primary" %}}
Excel 워크시트가 Aspose 구성 요소를 통해 PowerPoint 프레젠테이션에 OLE 객체로 삽입될 경우 최초 활성화 이후 알 수 없는 비율로 크기가 조정되는 것이 관찰되었습니다. 이 동작으로 인해 OLE 객체의 활성화 전후 프레젠테이션에서 눈에 띄는 시각적 차이가 발생합니다. 우리는 이 문제를 자세히 조사하고 해결책을 제공했으며, 해당 내용은 본 문서에서 다룹니다.
{{% /alert %}}

## **배경**

본 문서 [OLE 관리](/slides/ko/cpp/manage-ole/)에서는 Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에 OLE 프레임을 추가하는 방법을 설명했습니다. [객체 미리보기 문제](/slides/ko/cpp/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 선택한 워크시트 영역의 이미지를 OLE 객체 프레임에 할당했습니다. 출력 프레젠테이션에서 워크시트 이미지를 표시하는 OLE 객체 프레임을 더블 클릭하면 Excel 워크북이 활성화됩니다. 최종 사용자는 실제 Excel 워크북을 원하는 대로 수정한 뒤 활성화된 Excel 워크북 밖을 클릭하여 슬라이드로 돌아올 수 있습니다. 사용자가 슬라이드로 돌아올 때 OLE 객체 프레임의 크기가 변경됩니다. 크기 조정 비율은 OLE 객체 프레임과 삽입된 Excel 워크북의 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 워크북은 자체 창 크기를 가지고 있기 때문에 최초 활성화 시 원래 크기를 유지하려 합니다. 반면 OLE 객체 프레임은 자체 크기를 가지고 있습니다. Microsoft에 따르면 Excel 워크북이 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 임베딩 과정에서 올바른 비율을 유지하도록 합니다. 크기 조정은 Excel 창 크기와 OLE 객체 프레임의 크기 및 위치 차이에 따라 발생합니다.

## **작업 솔루션**

크기 조정 효과를 방지하는 두 가지 가능한 솔루션이 있습니다.

- PowerPoint 프레젠테이션에서 OLE 프레임 크기를 원하는 행 및 열 수의 높이와 너비에 맞게 스케일링합니다.
- OLE 프레임 크기를 고정하고 해당 프레임에 포함되는 행과 열의 크기를 조정하여 선택된 OLE 프레임 크기에 맞춥니다.

### **OLE 프레임 크기 스케일링**

이 방법에서는 삽입된 Excel 워크북의 OLE 프레임 크기를 Excel 워크시트에 포함된 행과 열의 누적 크기에 맞게 설정하는 방법을 배웁니다.

예를 들어 템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가하고자 한다고 가정합니다. 이 경우 OLE 객체 프레임의 크기는 먼저 워크북에 포함된 행 높이와 열 너비를 누적하여 계산됩니다. 그런 다음 계산된 값으로 OLE 프레임 크기를 설정합니다. PowerPoint에서 OLE 프레임에 표시되는 빨간색 "EMBEDDED OLE OBJECT" 메시지를 피하기 위해 워크북에서 원하는 행과 열 영역의 이미지를 캡처하여 OLE 프레임 이미지로 설정합니다.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Excel 워크북 파일을 PowerPoint에서 OLE 객체로 사용할 때 표시 크기를 설정합니다.
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

// OLE 객체 프레임을 생성합니다.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
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

### **셀 범위 크기 스케일링**

이 방법에서는 사용자 정의 OLE 프레임 크기에 맞게 포함된 행의 높이와 열의 너비를 스케일링하는 방법을 배웁니다.

예를 들어 템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가하고자 한다고 가정합니다. 이 경우 OLE 프레임의 크기를 설정하고 해당 프레임 영역에 포함되는 행과 열의 크기를 스케일링합니다. 그런 다음 변경 사항을 적용하기 위해 워크북을 스트림에 저장하고, OLE 프레임에 추가하기 위해 바이트 배열로 변환합니다. PowerPoint에서 OLE 프레임에 표시되는 빨간색 "EMBEDDED OLE OBJECT" 메시지를 피하기 위해 워크북에서 원하는 행과 열 영역의 이미지를 캡처하여 OLE 프레임 이미지로 설정합니다.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// 워크북 파일을 PowerPoint에서 OLE 객체로 사용할 때 표시되는 크기를 설정합니다.
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

// OLE 객체 프레임을 생성합니다.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
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

```cpp
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

{{% alert color="primary" %}}
워크시트 크기 조정 문제를 해결하는 두 가지 접근법이 있습니다. 적절한 접근법 선택은 특정 요구사항 및 사용 사례에 따라 달라집니다. 두 접근법 모두 템플릿에서 만든 프레젠테이션이든 처음부터 만든 프레젠테이션이든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 객체 프레임 크기에 제한이 없습니다.
{{% /alert %}}

## **FAQ**

**PowerPoint에서 처음 활성화될 때 삽입된 Excel 워크시트가 크기가 변하는 이유는 무엇인가요?**  
이는 Excel이 활성화될 때 원래 창 크기를 유지하려 하고, PowerPoint의 OLE 객체 프레임은 자체적인 차원을 가지고 있기 때문에 발생합니다. PowerPoint와 Excel가 비율을 유지하도록 크기를 협상하면서 크기 조정이 일어날 수 있습니다.

**이 크기 조정 문제를 완전히 방지할 수 있나요?**  
예. OLE 프레임을 Excel 셀 범위 크기에 맞게 스케일링하거나 셀 범위를 원하는 OLE 프레임 크기에 맞게 스케일링하면 원치 않는 크기 변화를 방지할 수 있습니다.

**어떤 스케일링 방식을 사용해야 하나요? OLE 프레임 스케일링과 셀 범위 스케일링 중 어느 것이 좋나요?**  
원본 Excel 행 및 열 크기를 유지하고 싶다면 **OLE 프레임 스케일링**을 선택하십시오. 프레젠테이션에서 OLE 프레임을 고정된 크기로 사용하고 싶다면 **셀 범위 스케일링**을 선택하십시오.

**프레젠테이션이 템플릿 기반이라도 이 솔루션이 작동하나요?**  
예. 두 솔루션 모두 템플릿 기반 프레젠테이션과 처음부터 만든 프레젠테이션 모두에 적용됩니다.

**이 방법들을 사용할 때 OLE 프레임 크기에 제한이 있나요?**  
아니오. 적절히 스케일을 설정하면 OLE 객체 프레임을 원하는 어느 크기로든 만들 수 있습니다.

**PowerPoint에서 "EMBEDDED OLE OBJECT" 자리표시자 텍스트를 제거할 방법이 있나요?**  
예. 대상 Excel 셀 범위의 스냅샷을 찍어 OLE 프레임의 자리표시자 이미지로 설정하면 기본 자리표시자 대신 사용자 정의 미리보기 이미지를 표시할 수 있습니다.

## **관련 문서**

[Excel 차트를 생성하고 OLE 객체로 프레젠테이션에 삽입하기](/slides/ko/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)