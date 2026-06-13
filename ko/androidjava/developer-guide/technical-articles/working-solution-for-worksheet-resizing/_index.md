---
title: 워크시트 크기 조정 해결 방법
type: docs
weight: 20
url: /ko/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 미리 보기 이미지
- 이미지 크기 조정
- Excel
- 워크시트
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "프레젠테이션에서 Excel 워크시트 OLE 크기 조정을 해결: 프레임을 스케일링하거나 시트를 스케일링하여 PPT 및 PPTX 형식에서 객체 프레임을 일관되게 유지하는 두 가지 방법."
---
{{% alert color="primary" %}}

Excel 워크시트를 Aspose 구성 요소를 통해 PowerPoint 프레젠테이션에 OLE 객체로 삽입하면 첫 번째 활성화 후 식별할 수 없는 비율로 크기가 조정되는 현상이 관찰되었습니다. 이 동작으로 인해 OLE 객체의 활성화 전후 상태에서 프레젠테이션에 눈에 띄는 시각적 차이가 발생합니다. 우리는 이 문제를 상세히 조사하고 해결 방법을 제공했으며, 해당 내용은 이 문서에 포함됩니다.

{{% /alert %}}

## **배경**

[Manage OLE](/slides/ko/androidjava/manage-ole/) 문서에서는 Aspose.Slides for Android via Java를 사용해 PowerPoint 프레젠테이션에 OLE 프레임을 추가하는 방법을 설명했습니다. [object preview issue](/slides/ko/androidjava/object-preview-issue-when-adding-oleobjectframe/) 를 해결하기 위해 선택한 워크시트 영역의 이미지를 OLE 객체 프레임에 할당했습니다. 출력 프레젠테이션에서 워크시트 이미지를 표시하는 OLE 객체 프레임을 더블 클릭하면 Excel 통합 문서가 활성화됩니다. 최종 사용자는 실제 Excel 통합 문서를 원하는 대로 수정한 후, 활성화된 Excel 통합 문서 외부를 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아올 때 OLE 객체 프레임의 크기가 변경됩니다. 크기 조정 비율은 OLE 객체 프레임 및 삽입된 Excel 통합 문서의 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 통합 문서는 자체 창 크기를 가지고 있어 첫 번째 활성화 시 원래 크기를 유지하려고 합니다. 반면 OLE 객체 프레임은 자체 크기를 갖습니다. Microsoft에 따르면 Excel 통합 문서가 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 삽입 과정에서 올바른 비율을 유지하도록 합니다. 크기 조정은 Excel 창 크기와 OLE 객체 프레임의 크기·위치 차이에 기반해 발생합니다.

## **작업 솔루션**

크기 조정 효과를 방지할 수 있는 두 가지 해결 방법이 있습니다.

- PowerPoint 프레젠테이션에서 OLE 프레임 크기를 OLE 프레임에 표시하려는 행과 열의 높이·너비에 맞게 조정합니다.
- OLE 프레임 크기를 고정하고, 해당 프레임에 맞도록 행과 열의 크기를 조정합니다.

### **OLE 프레임 크기 조정**

이 방법에서는 삽입된 Excel 통합 문서의 OLE 프레임 크기를 Excel 워크시트의 해당 행과 열의 누적 크기에 맞추는 방법을 배웁니다.

템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가하고자 한다고 가정합니다. 이 경우 OLE 객체 프레임의 크기는 워크북에 포함된 행 높이와 열 너비의 누적값을 기준으로 먼저 계산됩니다. 그런 다음 계산된 값으로 OLE 프레임 크기를 설정합니다. PowerPoint에서 OLE 프레임에 표시되는 빨간색 “EMBEDDED OLE OBJECT” 메시지를 피하기 위해 워크북의 원하는 행·열 영역을 이미지로 캡처하고 이를 OLE 프레임 이미지로 설정합니다.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// 워크북 파일을 PowerPoint에서 OLE 객체로 사용할 때 표시되는 크기를 설정합니다.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE 이미지의 너비와 높이를 포인트 단위로 가져옵니다.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// 수정된 워크북을 사용해야 합니다.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE 이미지를 프레젠테이션 리소스에 추가합니다.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE 객체 프레임을 생성합니다.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **셀 범위 크기 조정**

이 방법에서는 OLE 프레임 크기에 맞추어 참여하는 행의 높이와 열의 너비를 조정하는 방법을 배웁니다.

템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가하고자 한다고 가정합니다. 이 경우 OLE 프레임 크기를 설정하고, OLE 프레임 영역에 포함되는 행·열의 크기를 조정합니다. 그런 다음 워크북을 스트림에 저장하여 변경 사항을 적용하고, 이를 바이트 배열로 변환해 OLE 프레임에 추가합니다. PowerPoint에서 OLE 프레임에 표시되는 빨간색 “EMBEDDED OLE OBJECT” 메시지를 피하기 위해 워크북의 원하는 행·열 영역을 이미지로 캡처하고 이를 OLE 프레임 이미지로 설정합니다.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// 워크북 파일을 PowerPoint에서 OLE 객체로 사용할 때 표시되는 크기를 설정합니다.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// 셀 범위를 프레임 크기에 맞게 스케일링합니다.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// 수정된 워크북을 사용해야 합니다.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE 이미지를 프레젠테이션 리소스에 추가합니다.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE 객체 프레임을 생성합니다.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     셀 범위의 예상 너비(포인트 단위).
 * @param height    셀 범위의 예상 높이(포인트 단위).
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **결론**

{{% alert color="primary" %}} 

워크시트 크기 조정 문제를 해결하는 두 가지 접근 방식이 있습니다. 적절한 접근 방식 선택은 특정 요구 사항 및 사용 사례에 따라 달라집니다. 두 접근 방식 모두 템플릿에서 만들든 처음부터 만들든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 객체 프레임 크기에 제한이 없습니다.

{{% /alert %}}

## **FAQ**

**왜 삽입된 Excel 워크시트가 PowerPoint에서 처음 활성화될 때 크기가 변하나요?**

Excel이 활성화될 때 원래 창 크기를 유지하려고 하는 반면, PowerPoint의 OLE 객체 프레임은 자체 차원을 갖기 때문입니다. PowerPoint와 Excel이 비율을 유지하도록 크기를 협상하면서 크기 조정이 발생합니다.

**이 크기 조정 문제를 완전히 방지할 수 있나요?**

예. OLE 프레임을 Excel 셀 범위 크기에 맞추거나 셀 범위를 원하는 OLE 프레임 크기에 맞추어 조정하면 원치 않는 크기 조정을 방지할 수 있습니다.

**어떤 크기 조정 방법을 사용해야 하나요, OLE 프레임 조정인가 셀 범위 조정인가요?**

원본 Excel 행·열 크기를 유지하고 싶다면 **OLE 프레임 조정**을 선택하고, 프레젠테이션에서 고정된 OLE 프레임 크기가 필요하면 **셀 범위 조정**을 선택하십시오.

**템플릿 기반 프레젠테이션에서도 이 솔루션이 작동하나요?**

예. 두 솔루션 모두 템플릿에서 만든 프레젠테이션과 처음부터 만든 프레젠테이션 모두에 적용됩니다.

**이 방법을 사용할 때 OLE 프레임 크기에 제한이 있나요?**

아니요. 적절히 스케일을 설정하면 OLE 객체 프레임을 원하는 어느 크기로든 만들 수 있습니다.

**PowerPoint에서 “EMBEDDED OLE OBJECT” 자리 표시자 텍스트를 없애는 방법이 있나요?**

예. 대상 Excel 셀 범위의 스냅샷을 찍어 이를 OLE 프레임의 자리 표시자 이미지로 설정하면 기본 자리 표시자 대신 사용자 정의 미리 보기 이미지를 표시할 수 있습니다.