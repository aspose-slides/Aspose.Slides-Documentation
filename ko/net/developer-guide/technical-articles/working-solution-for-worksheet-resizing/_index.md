---
title: 워크시트 크기 조정에 대한 실용적인 해결책
type: docs
weight: 40
url: /ko/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 미리보기 이미지
- 이미지 크기 조정
- Excel
- 워크시트
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "프레젠테이션에서 Excel 워크시트 OLE 크기 조정을 해결합니다: 객체 프레임을 일관되게 유지하는 두 가지 방법—프레임을 스케일하거나 시트를 스케일—PPT 및 PPTX 형식 전반에 적용됩니다."
---
{{% alert color="info" %}} 

Aspose 구성 요소를 통해 PowerPoint 프레젠테이션에 OLE 객체로 삽입된 Excel 워크시트가 첫 번째 활성화 후에 식별할 수 없는 비율로 크기가 조정되는 것이 관찰되었습니다. 이 동작으로 인해 OLE 객체의 활성화 전후 상태 사이에 프레젠테이션에서 눈에 띄는 시각적 차이가 발생합니다. 우리는 이 문제를 자세히 조사했으며 해결책을 제공했으며, 이 문서에서 다루고 있습니다.

{{% /alert %}} 

## **배경**

이 문서 [OLE 관리](/slides/ko/net/manage-ole/)에서는 Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에 OLE 프레임을 추가하는 방법을 설명했습니다. [객체 미리보기 문제](/slides/ko/net/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 선택한 워크시트 영역의 이미지를 OLE 객체 프레임에 할당했습니다. 출력 프레젠테이션에서 워크시트 이미지를 표시하는 OLE 객체 프레임을 더블 클릭하면 Excel 통합 문서가 활성화됩니다. 최종 사용자는 실제 Excel 통합 문서에 원하는 변경을 수행한 후 활성화된 Excel 통합 문서 외부를 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아갈 때 OLE 객체 프레임의 크기가 변경됩니다. 크기 조정 비율은 OLE 객체 프레임과 삽입된 Excel 통합 문서의 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 통합 문서는 자체 창 크기를 가지고 있기 때문에 첫 번째 활성화 시 원래 크기를 유지하려고 합니다. 반면 OLE 객체 프레임은 자체 크기를 가지고 있습니다. Microsoft에 따르면 Excel 통합 문서가 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 삽입 과정의 올바른 비율을 유지합니다. 크기 조정은 Excel 창 크기와 OLE 객체 프레임의 크기 및 위치 차이에 따라 발생합니다.

## **작동 솔루션**

크기 조정 효과를 방지하기 위한 두 가지 가능한 솔루션이 있습니다.

- PowerPoint 프레젠테이션에서 OLE 프레임의 크기를 OLE 프레임에 원하는 행 및 열 수의 높이와 너비에 맞게 조정합니다.
- OLE 프레임 크기를 일정하게 유지하고, 선택한 OLE 프레임 크기에 맞게 참여하는 행 및 열의 크기를 조정합니다.

### **OLE 프레임 크기 조정**

이 접근 방식에서는 삽입된 Excel 통합 문서의 OLE 프레임 크기를 Excel 워크시트에서 참여하는 행 및 열의 누적 크기에 맞게 설정하는 방법을 배웁니다.

예를 들어 템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가한다고 가정합니다. 이 경우 OLE 객체 프레임의 크기는 먼저 통합 문서에서 참여하는 행 및 열의 누적 행 높이와 열 너비를 기반으로 계산됩니다. 그런 다음 이 계산된 값으로 OLE 프레임의 크기를 설정합니다. PowerPoint에서 OLE 프레임에 나타나는 빨간색 "EMBEDDED OLE OBJECT" 메시지를 피하기 위해 통합 문서에서 원하는 행 및 열 부분의 이미지를 캡처하여 OLE 프레임 이미지로 설정합니다.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// PowerPoint에서 통합 문서 파일을 OLE 객체로 사용할 때 표시되는 크기를 설정합니다.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// OLE 이미지의 너비와 높이를 포인트 단위로 가져옵니다.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// 수정된 통합 문서를 사용해야 합니다.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// OLE 이미지를 프레젠테이션 리소스에 추가합니다.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// OLE 객체 프레임을 생성합니다.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **셀 범위 크기 조정**

이 접근 방식에서는 참여하는 행의 높이와 열의 너비를 맞춤형 OLE 프레임 크기에 맞게 조정하는 방법을 배웁니다.

예를 들어 템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가한다고 가정합니다. 이 경우 OLE 프레임의 크기를 설정하고 OLE 프레임 영역에 포함되는 행 및 열의 크기를 조정합니다. 그런 다음 변경 사항을 적용하기 위해 통합 문서를 스트림에 저장하고 OLE 프레임에 추가하기 위해 바이트 배열로 변환합니다. PowerPoint에서 OLE 프레임에 나타나는 빨간색 "EMBEDDED OLE OBJECT" 메시지를 피하기 위해 통합 문서에서 원하는 행 및 열 부분의 이미지를 캡처하여 OLE 프레임 이미지로 설정합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// PowerPoint에서 통합 문서 파일을 OLE 객체로 사용할 때 표시되는 크기를 설정합니다.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// 셀 범위를 프레임 크기에 맞게 스케일링합니다.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// 수정된 통합 문서를 사용해야 합니다.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// OLE 이미지를 프레젠테이션 리소스에 추가합니다.
var oleImage = presentation.Images.AddImage(imageStream);

// OLE 객체 프레임을 생성합니다.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">셀 범위의 예상 너비(포인트 단위).</param>
/// <param name="height">셀 범위의 예상 높이(포인트 단위).</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **결론**

{{% alert color="info" %}}

워크시트 크기 조정 문제를 해결하기 위한 두 가지 접근 방식이 있습니다. 적절한 접근 방식을 선택하는 것은 특정 요구 사항 및 사용 사례에 따라 달라집니다. 두 접근 방식 모두 템플릿에서 만들든 처음부터 만들든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 객체 프레임 크기에 제한이 없습니다.

{{% /alert %}}

## **FAQ**

### PowerPoint에서 처음 활성화될 때 삽입된 Excel 워크시트가 크기가 변경되는 이유는 무엇인가요?
이는 Excel이 활성화될 때 원래 창 크기를 유지하려고 시도하고, PowerPoint의 OLE 객체 프레임은 자체 차원을 갖기 때문입니다. PowerPoint와 Excel이 비율을 유지하도록 크기를 협상하므로 크기 조정이 발생할 수 있습니다.

### 이 크기 조정 문제를 완전히 방지할 수 있나요?
네. OLE 프레임을 Excel 셀 범위 크기에 맞게 조정하거나 셀 범위를 원하는 OLE 프레임 크기에 맞게 조정하면 원치 않는 크기 조정을 방지할 수 있습니다.

### OLE 프레임 스케일링과 셀 범위 스케일링 중 어느 방법을 사용해야 하나요?
원본 Excel 행 및 열 크기를 유지하고 싶다면 **OLE 프레임 스케일링**을 선택하십시오. 프레젠테이션에서 OLE 프레임의 고정 크기를 원한다면 **셀 범위 스케일링**을 선택하십시오.

### 프레젠테이션이 템플릿 기반인 경우에도 이 솔루션이 작동하나요?
네. 두 솔루션 모두 템플릿에서 만든 프레젠테이션과 처음부터 만든 프레젠테이션 모두에서 작동합니다.

### 이러한 방법을 사용할 때 OLE 프레임 크기에 제한이 있나요?
없습니다. 적절히 스케일을 설정하면 OLE 객체 프레임을 원하는 크기로 만들 수 있습니다.

### PowerPoint에서 "EMBEDDED OLE OBJECT" 자리 표시자 텍스트를 피할 방법이 있나요?
네. 대상 Excel 셀 범위의 스냅샷을 촬영하여 OLE 프레임의 자리 표시자 이미지로 설정하면 기본 자리 표시자 대신 사용자 지정 미리보기 이미지를 표시할 수 있습니다.

## **관련 문서**

[Excel 차트를 만들고 OLE 객체로 프레젠테이션에 삽입하기](/slides/ko/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint 애드인 사용하여 OLE 객체 자동 업데이트](/slides/ko/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)