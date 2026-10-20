---
title: 워크시트 크기 조정에 대한 작업 솔루션
type: docs
weight: 20
url: /ko/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 미리 보기 이미지
- 이미지 크기 조정
- Excel
- 워크시트
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "프레젠테이션에서 Excel 워크시트 OLE 크기 조정을 해결합니다: 개체 프레임을 일관되게 유지하는 두 가지 방법—프레임을 스케일링하거나 시트를 스케일링—PPT 및 PPTX 형식 전반에 걸쳐 적용됩니다."
---
{{% alert color="info" title="Note" %}}

Aspose 구성 요소를 사용하여 PowerPoint 프레젠테이션에 OLE 개체로 삽입된 Excel 워크시트는 첫 번째 활성화 후 예상치 못하게 크기가 변경될 수 있습니다. 이 동작으로 인해 OLE 개체가 활성화 전과 후에 눈에 띄는 시각적 차이가 발생합니다. 이 문서에서는 문제를 설명하고 해결 방법 두 가지를 제시합니다.

{{% /alert %}}

## **배경**

[OLE 관리](/slides/ko/java/manage-ole/) 문서에서는 Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에 OLE 프레임을 추가하는 방법을 설명했습니다. [객체 미리 보기 문제](/slides/ko/java/object-preview-issue-when-adding-oleobjectframe/)를 해결하기 위해 선택한 워크시트 영역의 이미지를 OLE 개체 프레임에 할당했습니다. 출력 프레젠테이션에서 워크시트 이미지를 표시하는 OLE 개체 프레임을 두 번 클릭하면 Excel 통합 문서가 활성화됩니다. 최종 사용자는 실제 Excel 통합 문서에서 원하는 변경을 한 뒤 활성화된 Excel 통합 문서 외부를 클릭하여 슬라이드로 돌아갈 수 있습니다. 사용자가 슬라이드로 돌아올 때 OLE 개체 프레임의 크기가 변경됩니다. 크기 조정 비율은 OLE 개체 프레임과 삽입된 Excel 통합 문서의 크기에 따라 달라집니다.

## **크기 조정 원인**

Excel 통합 문서는 자체 창 크기를 가지고 있어 첫 번째 활성화 시 원래 크기를 유지하려고 합니다. 반면 OLE 개체 프레임은 자체 크기를 가지고 있습니다. Microsoft에 따르면 Excel 통합 문서가 활성화되면 Excel과 PowerPoint가 삽입 프로세스의 일부로 적절한 비율을 유지하도록 크기를 협상합니다. 크기 조정은 Excel 창 크기와 OLE 개체 프레임의 크기 및 위치 차이에 기반하여 발생합니다.

## **작동 해결책**

크기 조정 효과를 피하기 위한 두 가지 가능한 해결책이 있습니다.

- PowerPoint 프레젠테이션에서 OLE 프레임을 선택한 행과 열의 전체 높이와 너비에 맞게 조정합니다.
- OLE 프레임 크기를 고정하고 선택한 행과 열을 프레임에 맞게 스케일링합니다.

### **OLE 프레임 크기 스케일링**

이 방법은 삽입된 Excel 워크시트에서 선택한 행과 열의 전체 높이와 너비에 맞게 OLE 프레임 크기를 설정합니다.

예제에서는 기존 Excel 통합 문서를 로드하고 첫 번째 워크시트의 처음 10행과 13열을 0 기반 인덱스로 선택합니다. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-)이 표시 범위를 정의합니다. 미리 보기는 96 DPI로 렌더링되며, 픽셀 크기는 인치당 72포인트를 사용하여 포인트로 변환됩니다. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-)는 해당 차원으로 프레임에 수정된 통합 문서를 삽입합니다. 미리 보기 이미지는 저장된 프레젠테이션의 "EMBEDDED OLE OBJECT" 자리 표시자를 교체하기 위해 [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)을 통해 할당됩니다.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// 워크북 파일이 PowerPoint에서 OLE 개체로 사용될 때 표시 크기를 설정합니다.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE 이미지의 너비와 높이를 포인트 단위로 가져옵니다.
Image image = ImageIO.read(imageStream);
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

// OLE 개체 프레임을 생성합니다.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

미리 보기 도우미는 [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-)을 선택한 범위로 설정하고 여백, 머리글 및 바닥글을 제거합니다. [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-)가 활성화된 상태에서 [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-)는 범위를 PNG 이미지로 렌더링합니다. 도우미는 프레젠테이션에서 사용할 수 있도록 PNG 이미지를 포함하는 새로운 입력 스트림을 반환합니다.

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

### **셀 범위 크기 스케일링**

이 방법은 선택한 행의 높이와 열의 너비를 사용자 정의 OLE 프레임 크기에 맞게 스케일링합니다.

예제에서는 기존 Excel 통합 문서를 로드하고 첫 번째 워크시트의 처음 10행과 13열을 0 기반 인덱스로 선택합니다. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-)이 표시 범위를 정의하고, 아래 도우미는 해당 범위를 가로 400포인트, 세로 100포인트인 프레임에 맞게 스케일링합니다. 수정된 통합 문서를 스트림에 저장한 후 [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-)를 사용하여 지정된 크기로 삽입합니다. 96 DPI로 렌더링된 미리 보기는 [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)을 통해 할당되므로 저장된 프레젠테이션은 기본 자리 표시자 대신 선택한 셀을 표시합니다.

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

// 워크북 파일이 PowerPoint에서 OLE 개체로 사용될 때 표시 크기를 설정합니다.
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

// OLE 개체 프레임을 생성합니다.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

스케일링 도우미는 선택된 범위에 대해 별도의 너비와 높이 비율을 계산하여 열의 상대 너비와 행의 상대 높이를 유지합니다. 계산된 차원을 포인트에서 인치로 변환한 후 [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-)와 [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-)을 사용하여 적용합니다. 선택된 범위는 너비와 높이가 0이 아니어야 합니다.

```java
/**
 * @param width     셀 범위의 예상 너비(포인트).
 * @param height    셀 범위의 예상 높이(포인트).
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

이 미리 보기 도우미는 [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-)를 사용하여 크기가 조정된 범위를 렌더링합니다. [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-)을 해당 범위로 제한하고, 여백, 머리글 및 바닥글을 제거한 뒤 PNG 스트림을 처음 위치에 두고 반환합니다.

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

{{% alert color="info" title="Note" %}}

워크시트 크기 조정 문제를 해결하는 두 가지 접근 방식이 있습니다. 요구 사항 및 사용 사례에 가장 적합한 접근 방식을 선택하세요. 두 접근 방식은 템플릿 기반이든 처음부터 만든 프레젠테이션이든 동일하게 작동합니다. 또한 이 해결책에서는 OLE 개체 프레임 크기에 제한이 없습니다.

{{% /alert %}}

## **FAQ**

**PowerPoint에서 처음 활성화될 때 삽입된 Excel 워크시트가 크기가 변하는 이유는 무엇인가요?**

Excel은 활성화될 때 원래 창 크기를 유지하려고 하며, PowerPoint의 OLE 개체 프레임은 자체 치수를 가지고 있기 때문입니다. PowerPoint와 Excel이 비율을 유지하도록 크기를 협상하면서 크기 조정이 발생합니다.

**이 크기 조정 문제를 완전히 방지할 수 있나요?**

예. OLE 프레임을 Excel 셀 범위 크기에 맞게 스케일링하거나, 셀 범위를 원하는 OLE 프레임 크기에 맞게 스케일링하면 원치 않는 크기 조정을 방지할 수 있습니다.

**어떤 스케일링 방법을 사용해야 하나요, OLE 프레임 스케일링인가 셀 범위 스케일링인가요?**

원본 Excel 행과 열 크기를 유지하고 싶다면 **OLE 프레임 스케일링**을 선택하십시오. 프레젠테이션에서 OLE 프레임의 크기를 고정하고 싶다면 **셀 범위 스케일링**을 선택하십시오.

**템플릿 기반 프레젠테이션에서도 이 솔루션이 작동하나요?**

예. 두 솔루션 모두 템플릿을 사용한 프레젠테이션과 처음부터 만든 프레젠테이션 모두에서 작동합니다.

**이 방법을 사용할 때 OLE 프레임 크기에 제한이 있나요?**

없습니다. 적절히 스케일을 지정하면 OLE 개체 프레임을 원하는 어떤 크기로도 만들 수 있습니다.

**PowerPoint에서 "EMBEDDED OLE OBJECT" 자리 표시자 텍스트를 피하는 방법이 있나요?**

예. 대상 Excel 셀 범위의 스냅샷을 가져와 OLE 프레임의 자리 표시자 이미지로 설정하면 기본 자리 표시자 대신 사용자 지정 미리 보기 이미지를 표시할 수 있습니다.

## **관련 문서**

[Excel 차트를 만들고 OLE 개체로 프레젠테이션에 삽입](/slides/ko/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint 애드인으로 OLE 개체 자동 업데이트](/slides/ko/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)