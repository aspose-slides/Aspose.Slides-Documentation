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
description: "프레젠테이션에서 Excel 워크시트 OLE 크기 조정을 해결합니다: 개체 프레임을 일관되게 유지하는 두 가지 방법—프레임을 스케일링하거나 시트를 스케일링—PPT 및 PPTX 형식 전반에 걸쳐."
---
{{% alert color="info" title="Note" %}}

Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 워크시트는 처음 활성화된 후 예상치 못하게 크기가 조정될 수 있습니다. 이 동작은 활성화 전후의 OLE 개체 사이에 눈에 띄는 시각적 차이를 만들습니다. 이 문서는 문제를 설명하고 해결 방법 두 가지를 소개합니다.

{{% /alert %}} 

## **배경**

이 문서 [OLE 관리](/slides/ko/net/manage-ole/)에서 Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에 OLE 프레임을 추가하는 방법을 설명했습니다. [객체 미리보기 문제](/slides/ko/net/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 선택한 워크시트 영역의 이미지를 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 워크시트 이미지를 표시하는 OLE 개체 프레임을 두 번 클릭하면 Excel 통합 문서가 활성화됩니다. 최종 사용자는 실제 Excel 통합 문서에서 원하는 변경을 수행한 후 활성화된 Excel 통합 문서 외부를 클릭하여 슬라이드로 돌아올 수 있습니다. 사용자가 슬라이드로 돌아올 때 OLE 개체 프레임의 크기가 변경됩니다. 크기 조정 비율은 OLE 개체 프레임과 삽입된 Excel 통합 문서의 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 통합 문서는 자체 창 크기를 가지고 있기 때문에 처음 활성화될 때 원래 크기를 유지하려고 합니다. 반면 OLE 개체 프레임은 자체 크기를 가집니다. Microsoft에 따르면 Excel 통합 문서가 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 포함 과정에서 올바른 비율을 유지합니다. 크기 조정은 Excel 창 크기와 OLE 개체 프레임의 크기 및 위치 차이에 따라 발생합니다.

## **실제 해결책**

크기 조정 효과를 방지하기 위한 두 가지 가능한 해결책이 있습니다.

- PowerPoint 프레젠테이션에서 OLE 프레임을 선택한 행과 열의 전체 높이와 너비에 맞게 스케일링합니다.
- OLE 프레임 크기를 고정하고 선택한 행과 열을 해당 프레임에 맞게 스케일링합니다.

### **OLE 프레임 크기 조정**

이 접근 방식은 삽입된 Excel 워크시트에서 선택한 행과 열의 전체 높이와 너비에 맞게 OLE 프레임 크기를 설정합니다.

예제는 기존 Excel 통합 문서를 로드하고 첫 번째 워크시트에서 0 기반 인덱스를 사용하여 처음 10행과 13열을 선택합니다. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/)는 표시 범위를 정의합니다. 미리보기는 96 DPI로 렌더링되고 픽셀 치수는 인치당 72포인트를 사용하여 포인트로 변환됩니다. [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/)은 수정된 통합 문서를 해당 치수의 프레임에 삽입합니다. 미리보기는 [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/)을 통해 저장된 프레젠테이션의 "EMBEDDED OLE OBJECT" 자리표시자를 교체하도록 할당됩니다.

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

// PowerPoint에서 통합 문서 파일을 OLE 개체로 사용할 때 표시되는 크기를 설정합니다.
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

// OLE 개체 프레임을 생성합니다.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

미리보기 도우미는 [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/)를 선택된 범위로 설정하고 여백, 머리글 및 바닥글을 제거합니다. [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/)를 활성화하면 [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/)가 해당 범위를 PNG 이미지로 렌더링합니다. 도우미는 프레젠테이션에서 사용하기 전에 이미지 스트림을 처음으로 되돌립니다.

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

이 접근 방식은 선택한 행의 높이와 선택한 열의 너비를 맞춤 OLE 프레임 크기에 맞게 스케일링합니다.

예제는 기존 Excel 통합 문서를 로드하고 첫 번째 워크시트에서 0 기반 인덱스를 사용하여 처음 10행과 13열을 선택합니다. [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/)는 표시 범위를 정의하고 아래 도우미는 해당 범위를 너비 400포인트, 높이 100포인트 프레임에 맞게 스케일링합니다. 수정된 통합 문서를 스트림에 저장한 후 [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/)가 지정된 크기로 삽입합니다. 96 DPI로 렌더링된 미리보기가 [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/)을 통해 할당되어 저장된 프레젠테이션에 기본 자리표시자 대신 선택된 셀이 표시됩니다.

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

// PowerPoint에서 통합 문서 파일을 OLE 개체로 사용할 때 표시되는 크기를 설정합니다.
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

// OLE 개체 프레임을 생성합니다.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

스케일링 도우미는 선택된 범위에 대해 너비 비율과 높이 비율을 각각 계산하여 열의 상대 너비와 행의 상대 높이를 유지합니다. 계산된 치수를 포인트에서 인치로 변환한 후 [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/)와 [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/)를 사용하여 적용합니다. 선택된 범위는 너비와 높이가 0이 아니어야 합니다.

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

이 미리보기 도우미는 [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/)를 사용하여 크기가 조정된 범위를 렌더링합니다. [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/)를 해당 범위로 제한하고 여백, 머리글 및 바닥글을 제거한 후 시작 위치에 있는 PNG 스트림을 반환합니다.

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

{{% alert color="info" title="Note" %}}

워크시트 크기 조정 문제를 해결하는 두 가지 접근 방식이 있습니다. 요구 사항 및 사용 사례에 가장 적합한 방식을 선택하십시오. 두 접근 방식 모두 템플릿에서 만들든 처음부터 만들든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 개체 프레임 크기에 제한이 없습니다.

{{% /alert %}}

## **FAQ**

**PowerPoint에서 처음 활성화될 때 삽입된 Excel 워크시트가 크기가 변경되는 이유는 무엇입니까?**

Excel이 활성화될 때 원래 창 크기를 유지하려고 하고, PowerPoint의 OLE 개체 프레임은 자체 차원을 가지기 때문에 발생합니다. PowerPoint와 Excel이 비율을 유지하도록 크기를 협상하면서 크기 조정이 일어날 수 있습니다.

**이 크기 조정 문제를 완전히 방지할 수 있습니까?**

예. OLE 프레임을 Excel 셀 범위 크기에 맞게 스케일링하거나 셀 범위를 원하는 OLE 프레임 크기에 맞게 스케일링하면 원치 않는 크기 조정을 방지할 수 있습니다.

**어느 스케일링 방법을 사용해야 합니까, OLE 프레임 스케일링 아니면 셀 범위 스케일링?**

원본 Excel 행 및 열 크기를 유지하려면 **OLE 프레임 스케일링**을 선택하십시오. 프레젠테이션에서 OLE 프레임을 고정 크기로 사용하려면 **셀 범위 스케일링**을 선택하십시오.

**프레젠테이션이 템플릿 기반인 경우에도 이러한 솔루션이 작동합니까?**

예. 두 솔루션 모두 템플릿 기반 프레젠테이션과 처음부터 만든 프레젠테이션에서 작동합니다.

**이 방법을 사용할 때 OLE 프레임 크기에 제한이 있습니까?**

아니오. 적절히 스케일을 설정하면 OLE 개체 프레임을 원하는 어느 크기로든 만들 수 있습니다.

**PowerPoint에서 "EMBEDDED OLE OBJECT" 자리표시자 텍스트를 피할 방법이 있습니까?**

예. 대상 Excel 셀 범위의 스냅샷을 찍어 OLE 프레임의 자리표시자 이미지로 설정하면 기본 자리표시자 대신 사용자 정의 미리보기 이미지를 표시할 수 있습니다.

## **관련 문서**

[Excel 차트를 생성하고 OLE 개체로 프레젠테이션에 삽입하기](/slides/ko/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint 추가 기능을 사용하여 OLE 개체 자동 업데이트](/slides/ko/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)