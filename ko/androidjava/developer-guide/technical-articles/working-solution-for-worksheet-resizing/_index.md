---
title: 워크시트 크기 조정에 대한 실용적인 솔루션
type: docs
weight: 20
url: /ko/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 미리보기 이미지
- 이미지 크기 조정
- Excel
- 워크시트
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "프레젠테이션에서 Excel 워크시트 OLE 크기 조정을 해결합니다: 객체 프레임을 일관되게 유지하는 두 가지 방법—프레임을 스케일링하거나 시트를 스케일링—PPT와 PPTX 형식 모두에 적용됩니다."
---
{{% alert color="info" %}}
Aspose 구성 요소를 통해 PowerPoint 프레젠테이션에 OLE 객체로 삽입된 Excel 워크시트가 첫 번째 활성화 후 알 수 없는 비율로 크기가 조정되는 것이 관찰되었습니다. 이 동작으로 인해 OLE 객체의 활성화 전후 상태 사이에 프레젠테이션에서 눈에 띄는 시각적 차이가 발생합니다. 우리는 이 문제를 자세히 조사했으며, 해결책을 제공하고 있으며 해당 내용은 이 기사에 포함되어 있습니다.
{{% /alert %}}

## **배경**
이 기사 [Manage OLE](/slides/ko/androidjava/manage-ole/)에서는 Aspose.Slides for Android via Java를 사용하여 PowerPoint 프레젠테이션에 OLE 프레임을 추가하는 방법을 설명했습니다. [object preview issue](/slides/ko/androidjava/object-preview-issue-when-adding-oleobjectframe/) 문제를 해결하기 위해 선택한 워크시트 영역의 이미지를 OLE 객체 프레임에 할당했습니다. 출력 프레젠테이션에서 워크시트 이미지를 표시하는 OLE 객체 프레임을 두 번 클릭하면 Excel 통합 문서가 활성화됩니다. 최종 사용자는 실제 Excel 통합 문서를 원하는 대로 수정한 다음 활성화된 Excel 통합 문서 외부를 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아올 때 OLE 객체 프레임의 크기가 변경됩니다. 크기 조정 비율은 OLE 객체 프레임과 삽입된 Excel 통합 문서의 크기에 따라 달라집니다.

## **크기 조정 원인**
Excel 통합 문서는 자체 창 크기가 있기 때문에 첫 번째 활성화 시 원래 크기를 유지하려고 합니다. 반면 OLE 객체 프레임은 자체 크기를 가지고 있습니다. Microsoft에 따르면 Excel 통합 문서가 활성화될 때 Excel과 PowerPoint가 크기를 협상하여 임베딩 프로세스의 일부로 올바른 비율을 유지합니다. 크기 조정은 Excel 창 크기와 OLE 객체 프레임의 크기 및 위치 차이에 따라 발생합니다.

## **작동 솔루션**
크기 조정 효과를 방지하기 위한 두 가지 가능한 솔루션이 있습니다.
- PowerPoint 프레젠테이션에서 OLE 프레임 크기를 OLE 프레임 내 원하는 행 및 열 수의 높이와 너비에 맞게 조정합니다.
- OLE 프레임 크기를 고정하고 참여하는 행 및 열의 크기를 선택된 OLE 프레임 크기에 맞게 조정합니다.

### **OLE 프레임 크기 조정**
이 접근 방식에서는 삽입된 Excel 통합 문서의 OLE 프레임 크기를 Excel 워크시트에서 참여하는 행 및 열의 누적 크기에 맞게 설정하는 방법을 배웁니다.
템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가하고 싶다고 가정해 보겠습니다. 이 경우 OLE 객체 프레임의 크기는 먼저 워크북에서 참여하는 행의 높이와 열의 너비를 누적하여 계산됩니다. 그런 다음 이 계산된 값으로 OLE 프레임 크기를 설정합니다. PowerPoint에서 OLE 프레임에 대한 빨간색 "EMBEDDED OLE OBJECT" 메시지를 방지하기 위해 워크북에서 원하는 행 및 열 부분의 이미지를 캡처하여 OLE 프레임 이미지로 설정합니다.
```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// 워크북 파일이 PowerPoint에서 OLE 객체로 사용될 때 표시되는 크기를 설정합니다.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE 이미지의 너비와 높이를 포인트 단위로 가져옵니다.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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
이 접근 방식에서는 참여 행의 높이와 참여 열의 너비를 맞춤 OLE 프레임 크기에 맞게 조정하는 방법을 배웁니다.
템플릿 Excel 시트가 있고 이를 OLE 프레임으로 프레젠테이션에 추가하고 싶다고 가정해 보겠습니다. 이 경우 OLE 프레임 크기를 설정하고 OLE 프레임 영역에 참여하는 행 및 열의 크기를 조정합니다. 그런 다음 변경 사항을 적용하기 위해 워크북을 스트림에 저장하고 OLE 프레임에 추가하기 위해 바이트 배열로 변환합니다. PowerPoint에서 OLE 프레임에 대한 빨간색 "EMBEDDED OLE OBJECT" 메시지를 방지하기 위해 워크북에서 원하는 행 및 열 부분의 이미지를 캡처하여 OLE 프레임 이미지로 설정합니다.
```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// 워크북 파일이 PowerPoint에서 OLE 객체로 사용될 때 표시되는 크기를 설정합니다.
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
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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
{{% alert color="info" %}} 
워크시트 크기 조정 문제를 해결하는 두 가지 접근 방식이 있습니다. 적절한 접근 방식의 선택은 특정 요구 사항 및 사용 사례에 따라 달라집니다. 두 접근 방식 모두 템플릿에서 만들든 처음부터 만들든 동일하게 작동합니다. 또한 이 솔루션에서는 OLE 객체 프레임 크기에 제한이 없습니다.
{{% /alert %}}

## **자주 묻는 질문**
### 삽입된 Excel 워크시트가 PowerPoint에서 처음 활성화될 때 크기가 변경되는 이유는 무엇인가요?
이는 Excel이 활성화될 때 원래 창 크기를 유지하려고 하고, PowerPoint의 OLE 객체 프레임은 자체 차원을 가지고 있기 때문에 발생합니다. PowerPoint와 Excel이 비율을 유지하도록 크기를 협상하면서 크기 조정이 발생할 수 있습니다.

### 이 크기 조정 문제를 완전히 방지할 수 있나요?
예. OLE 프레임을 Excel 셀 범위 크기에 맞게 조정하거나 셀 범위를 원하는 OLE 프레임 크기에 맞게 조정하면 원하지 않는 크기 조정을 방지할 수 있습니다.

### 어떤 스케일링 방법을 사용해야 하나요, OLE 프레임 스케일링인가 셀 범위 스케일링인가?
원본 Excel 행 및 열 크기를 유지하려면 **OLE 프레임 스케일링**을 선택하십시오. 프레젠테이션에서 OLE 프레임을 고정된 크기로 유지하려면 **셀 범위 스케일링**을 선택하십시오.

### 프레젠테이션이 템플릿 기반인 경우에도 이 솔루션이 작동하나요?
예. 두 솔루션 모두 템플릿에서 만든 프레젠테이션과 처음부터 만든 프레젠테이션 모두에 적용됩니다.

### 이러한 방법을 사용할 때 OLE 프레임 크기에 제한이 있나요?
아니오. 스케일을 적절히 설정하기만 하면 OLE 객체 프레임을 원하는 크기로 만들 수 있습니다.

### PowerPoint에서 "EMBEDDED OLE OBJECT" 자리 표시자 텍스트를 피할 방법이 있나요?
예. 대상 Excel 셀 범위의 스냅샷을 찍어 OLE 프레임의 자리 표시자 이미지로 설정하면 기본 자리 표시자 대신 사용자 정의 미리보기 이미지를 표시할 수 있습니다.