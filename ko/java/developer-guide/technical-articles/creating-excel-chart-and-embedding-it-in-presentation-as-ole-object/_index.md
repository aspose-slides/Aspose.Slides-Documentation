---
title: Excel 차트를 생성하고 프레젠테이션에 OLE 개체로 삽입하기
type: docs
weight: 30
url: /ko/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 차트
- 차트 삽입
- OLE 개체
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Cells for Java를 사용하여 Excel 차트를 만들고, Aspose.Slides를 사용해 워크북을 PowerPoint 프레젠테이션에 삽입합니다. 차트 미리 보기가 포함됩니다."
---
## **개요**

이 문서는 Aspose.Cells for Java를 사용하여 Excel 세로 막대 차트를 만드는 방법과 해당 워크북을 Aspose.Slides for Java를 사용한 PowerPoint 프레젠테이션에 삽입하는 방법을 보여줍니다. 삽입된 워크북에는 원본 데이터와 차트가 모두 포함됩니다. 별도의 PNG 미리 보기가 OLE 개체가 활성화되기 전에 슬라이드에 차트를 표시합니다.

결과는 PowerPoint 고유 차트가 아니라 삽입된 Excel 개체입니다. OLE를 통해 워크북을 편집하려면 OLE 활성화를 지원하는 데스크톱 애플리케이션과 호환되는 Excel이 설치되어 있어야 합니다.

## **전제 조건**

Aspose.Cells for Java와 Aspose.Slides for Java를 프로젝트 종속성에 추가합니다. 예제는 Java 메서드 내에서 실행합니다. 이러한 라이브러리를 사용해 프레젠테이션을 생성하는 데 Microsoft Office는 필요하지 않습니다.

입력 파일은 필요하지 않습니다. 예제는 메모리에서 데이터와 차트를 생성한 후 `OutputChart.pptx`를 현재 작업 디렉터리에 기록합니다. 평가판 모드가 아닌 환경에서 실행할 경우 두 제품 모두 라이선스를 적용하세요.

## **삽입 작동 방식**

1. 데이터 워크시트와 차트 시트가 포함된 워크북을 생성합니다.
1. 차트 시트를 활성화하여 워크북이 차트에서 열리도록 합니다.
1. 워크북의 OLE 표시 범위를 설정하고 차트를 PNG로 렌더링합니다.
1. 워크북을 메모리에서 XLSX 형식으로 저장하고 해당 바이트를 슬라이드에 삽입합니다.
1. PNG를 OLE 개체의 미리 보기로 지정하고 프레젠테이션을 PPTX로 저장합니다.

워크북 표시 범위와 슬라이드의 프레임은 서로 다른 역할을 합니다. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-)는 0부터 시작하는 행 및 열의 시작/끝 인덱스를 사용합니다. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-)는 대신 상단 행, 왼쪽 열, 하단 행, 오른쪽 열을 지정합니다. 예제에서는 행 인덱스 55와 열 인덱스 25를 오른쪽 아래 경계로 사용합니다; 이 값들은 레이아웃 선택일 뿐 데이터 행이나 열의 수를 의미하지 않습니다.

슬라이드 프레임은 포인트 단위를 사용합니다. 예제는 슬라이드 내에 프레임을 맞추고 중앙에 배치하며 PNG의 가로세로 비율을 유지합니다. 미리 보기를 슬라이드 전체에 늘리지는 않습니다.

## **차트 만들기 및 삽입**

다음 전체 예제는 `DataSheet`에 4개의 행과 5개의 열에 해당하는 값을 채웁니다. 각 행은 차트 시리즈가 됩니다. 워크북을 저장하기 전에 `ChartSheet`를 활성 시트로 선택합니다.

워크북은 명시적으로 XLSX 형식으로 저장되며, 이는 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/)에 전달된 `xlsx` 확장자와 일치합니다. PNG는 중간 비트맵 변환 없이 바이트에서 직접 로드됩니다. [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)을 통해 할당하면 기본 OLE 자리 표시자를 교체합니다.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // 차트 미리 보기를 렌더링하고 편집 가능한 워크북을 별도로 직렬화합니다.
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // 미리 보기를 슬라이드 안에 맞추되 가로세로 비율을 변경하지 않습니다.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```

## **예상 결과**

`OutputChart.pptx`에는 삽입된 Excel 워크북과 차트 미리 보기가 있는 하나의 슬라이드가 들어 있습니다. 워크북에는 원본 데이터와 4개 시리즈가 포함된 세로 막대 차트가 포함됩니다. 미리 보기는 슬라이드 중앙에 배치되고 비율을 유지합니다.

![삽입된 워크북의 미리 보기로 표시된 Excel 세로 막대 차트](excel-chart-ole-preview.png)

Excel이 설치된 호환 가능한 데스크톱 PowerPoint 환경에서는 개체를 더블 클릭하여 삽입된 워크북을 활성화하고 편집할 수 있습니다. 활성화 및 편집은 호스트 애플리케이션의 OLE 지원 및 보안 설정에 따라 달라집니다.

## **FAQ**

**왜 미리 보기 이미지가 필요합니까?**

삽입된 워크북과 슬라이드 미리 보기는 별개의 콘텐츠입니다. 차트 이미지를 제공하면 슬라이드에 기본 "EMBEDDED OLE OBJECT" 자리 표시자 대신 차트가 표시됩니다. 자세한 내용은 [OleObjectFrame 추가 시 객체 미리 보기 문제](/slides/ko/java/object-preview-issue-when-adding-oleobjectframe/)를 참조하세요.

**코드에서 워크북을 변경하면 미리 보기가 자동으로 업데이트됩니까?**

미리 보기를 스냅샷으로 간주하세요. 프로그래밍으로 워크북 데이터를 업데이트할 때 차트 이미지를 다시 생성하고 미리 보기와 삽입된 워크북 데이터를 모두 교체해야 합니다.

**XLS를 대신 사용할 수 있나요?**

예. 워크북을 XLS 형식으로 저장하고 `xls`를 삽입된 데이터 확장자로 사용합니다. 확장자는 실제 워크북 형식과 일치해야 하며, 확장자만 변경해도 데이터가 변환되지는 않습니다.

**왜 활성화 후에 개체 크기가 변경될 수 있나요?**

호스트 애플리케이션은 워크북을 활성화할 때 OLE 개체의 표시를 업데이트할 수 있습니다. 워크북의 OLE 표시 범위와 슬라이드 프레임 크기가 모두 영향을 미칩니다. 자세한 내용은 [PPTX에서 차트 크기 조정에 대한 작업 솔루션](/slides/ko/java/working-solution-for-chart-resizing-in-pptx/)를 참조하세요.

## **관련 섹션**

- [PPTX에서 차트 크기 조정에 대한 작업 솔루션](/slides/ko/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame 추가 시 객체 미리 보기 문제](/slides/ko/java/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint 추가 기능을 사용한 OLE 객체 자동 업데이트](/slides/ko/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)