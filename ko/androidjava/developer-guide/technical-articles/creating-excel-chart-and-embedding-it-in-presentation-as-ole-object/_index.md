---
title: Excel 차트를 만들고 프레젠테이션에 OLE 객체로 삽입하기
type: docs
weight: 30
url: /ko/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 차트
- 차트 삽입
- OLE 객체
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java를 사용하여 Android용 Aspose.Cells로 Excel 차트를 만들고, Android용 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에 워크북을 삽입합니다. 차트 미리보기가 포함됩니다."
---
## **개요**

이 문서에서는 Java를 이용한 Android용 Aspose.Cells로 Excel 열 차트를 만드는 방법과 해당 워크북을 Java를 이용한 Android용 Aspose.Slides로 PowerPoint 프레젠테이션에 삽입하는 방법을 보여줍니다. 삽입된 워크북에는 원본 데이터와 차트가 모두 포함됩니다. 별도의 PNG 미리보기는 OLE 개체가 활성화되기 전에 슬라이드에 차트를 표시합니다.

결과는 기본 PowerPoint 차트가 아니라 삽입된 Excel 개체입니다. OLE를 통해 워크북을 편집하려면 OLE 활성화를 지원하고 호환되는 Excel이 설치된 데스크톱 응용 프로그램이 필요합니다.

## **필수 조건**

프로젝트 종속성에 Java를 이용한 Android용 Aspose.Cells와 Java를 이용한 Android용 Aspose.Slides를 추가합니다. Android 액티비티에서 `ExcelChartEmbedding.createPresentation(getFilesDir())`를 호출합니다. 이러한 라이브러리를 사용하여 프레젠테이션을 생성하는 데 Microsoft Office는 필요하지 않습니다.

입력 파일이 필요하지 않습니다. 예제는 메모리에서 데이터와 차트를 생성한 다음 `OutputChart.pptx`를 애플리케이션의 내부 파일 디렉터리에 씁니다. 평가 모드가 아닌 환경에서 실행할 때는 두 제품 모두에 라이선스를 적용하십시오.

## **삽입 작동 방식**

1. 데이터 워크시트와 차트 시트를 포함하는 워크북을 생성합니다.
2. 워크북이 차트에서 열리도록 차트 시트를 활성화합니다.
3. 워크북의 OLE 표시 범위를 설정하고 차트를 PNG로 렌더링합니다.
4. 워크북을 메모리에서 XLSX 형식으로 저장하고 해당 바이트를 슬라이드에 삽입합니다.
5. PNG를 OLE 개체의 미리보기로 지정하고 프레젠테이션을 PPTX로 저장합니다.

워크북 표시 범위와 슬라이드의 프레임은 서로 다른 역할을 합니다. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) 은(는) 0 기반 시작/끝 행 및 열 인덱스를 사용합니다. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) 은(는) 상단 행, 왼쪽 열, 하단 행, 오른쪽 열을 사용합니다. 예제는 행 인덱스 55와 열 인덱스 25를 오른쪽 하단 경계로 사용합니다; 이러한 값은 레이아웃 선택이며 데이터 행 또는 열의 수를 나타내는 것이 아닙니다.

슬라이드 프레임은 포인트 단위를 사용합니다. 예제는 슬라이드 안에 프레임을 맞추고 PNG의 가로 세로 비율을 유지하면서 중앙에 배치합니다; 미리보기를 슬라이드 전체에 늘리는 것이 아니라 중앙에 맞춥니다.

## **차트 생성 및 삽입**

다음 전체 예제는 `DataSheet`에 4개의 행과 5개의 열값을 채웁니다. 각 행은 차트 시리즈가 됩니다. 워크북을 저장하기 전에 `ChartSheet`를 활성 시트로 선택합니다.

워크북은 명시적으로 XLSX 형식으로 저장되며, 이는 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/)에 전달된 `xlsx` 확장자와 일치합니다. PNG는 중간 비트맵 변환 없이 바이트에서 직접 로드됩니다. [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)을 통해 할당하면 기본 OLE 자리 표시자가 교체됩니다.

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
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
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

                // 차트 미리보기를 렌더링하고 편집 가능한 워크북을 별도로 직렬화합니다.
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

                        // 미리보기를 슬라이드 내에 맞추되 가로 세로 비율을 변경하지 않습니다.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
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
    }
}
```

## **예상 결과**

`OutputChart.pptx`에는 삽입된 Excel 워크북과 차트 미리보기가 포함된 하나의 슬라이드가 들어 있습니다. 워크북에는 원본 데이터와 네 개의 시리즈가 있는 열 차트가 포함됩니다. 미리보기는 슬라이드 중앙에 배치되며 비율을 유지합니다.

![삽입된 워크북의 미리보기로 표시된 Excel 열 차트](excel-chart-ole-preview.png)

Excel이 설치된 호환 가능한 데스크톱 PowerPoint 환경에서는 개체를 더블 클릭하여 삽입된 워크북을 활성화하고 편집할 수 있습니다. 활성화 및 편집은 호스트 응용 프로그램의 OLE 지원 및 보안 설정에 따라 달라집니다.

## **자주 묻는 질문**

**왜 미리보기 이미지가 필요합니까?**

삽입된 워크북과 슬라이드 미리보기는 별개의 콘텐츠입니다. 차트 이미지를 제공하면 슬라이드가 기본 "EMBEDDED OLE OBJECT" 자리 표시자 대신 차트를 표시합니다. [Object Preview Issue when Adding OleObjectFrame](/slides/ko/androidjava/object-preview-issue-when-adding-oleobjectframe/)을 참조하십시오.

**코드에서 워크북을 변경할 때 미리보기가 자동으로 업데이트됩니까?**

미리보기를 스냅샷으로 간주하십시오. 프로그래밍 방식으로 워크북 데이터를 업데이트할 때 차트 이미지를 다시 생성하고 미리보기와 삽입된 워크북 데이터를 모두 교체합니다.

**XLSX 대신 XLS를 사용할 수 있습니까?**

예. 워크북을 XLS 형식으로 저장하고 `xls`를 삽입 데이터 확장자로 사용합니다. 확장자는 실제 워크북 형식과 일치해야 하며, 확장자만 변경해도 데이터가 변환되지 않습니다.

**활성화 후 개체 크기가 변경될 수 있는 이유는 무엇입니까?**

호스트 응용 프로그램은 워크북을 활성화할 때 OLE 개체의 표시를 업데이트할 수 있습니다. 워크북의 OLE 표시 범위와 슬라이드 프레임 크기가 모두 중요합니다. [Working Solution for Worksheet Resizing](/slides/ko/androidjava/working-solution-for-worksheet-resizing/)을 참고하십시오.

## **관련 섹션**

- [워크시트 크기 조정에 대한 작동 솔루션](/slides/ko/androidjava/working-solution-for-worksheet-resizing/)
- [OleObjectFrame 추가 시 객체 미리보기 문제](/slides/ko/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [OLE 관리](/slides/ko/androidjava/manage-ole/)