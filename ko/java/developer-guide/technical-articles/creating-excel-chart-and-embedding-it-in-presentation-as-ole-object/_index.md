---
title: Excel 차트를 만들고 프레젠테이션에 OLE 객체로 삽입하기
type: docs
weight: 30
url: /ko/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 차트
- 차트 삽입
- OLE 객체
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Java를 사용하여 Excel 차트를 만들고 PowerPoint 및 OpenDocument 프레젠테이션에 OLE 객체로 삽입합니다. 코드 샘플과 함께 단계별 가이드."
---
## **배경**

PowerPoint에서 데이터를 그래픽으로 표시하기 위해 편집 가능한 차트를 사용하는 것은 일반적인 방법입니다. Aspose는 Java용 Aspose.Cells를 사용하여 Excel 차트를 만들 수 있도록 지원하며, 이러한 차트를 Aspose.Slides for Java를 통해 OLE 객체로 PowerPoint 슬라이드에 삽입할 수 있습니다. 이 문서에서는 필요한 단계들을 설명하고 Aspose.Cells와 Aspose.Slides를 사용하여 Excel 차트를 만들고 이를 PowerPoint 프레젠테이션에 OLE 객체로 삽입하는 Java 코드 예제를 제공합니다.

## **필수 단계**

PowerPoint 슬라이드에 Excel 차트를 OLE 객체로 만들고 삽입하려면 다음 순서대로 단계가 필요합니다:

1. Aspose.Cells를 사용하여 Excel 차트를 생성합니다.
1. Aspose.Cells를 사용하여 Excel 차트의 OLE 크기를 설정합니다.
1. Aspose.Cells를 사용하여 Excel 차트의 이미지를 가져옵니다.
1. Aspose.Slides를 사용하여 Excel 차트를 PPTX 프레젠테이션에 OLE 객체로 삽입합니다.
1. 3단계에서 얻은 이미지로 "EMBEDDED OLE OBJECT" 이미지를 교체하여 [객체 미리 보기 문제](/slides/ko/java/object-preview-issue-when-adding-oleobjectframe/)를 해결합니다.
1. 프레젠테이션을 PPTX 형식으로 디스크에 저장합니다.

## **필수 단계 구현**

위 단계들의 Java 구현은 다음과 같습니다:

```java
// 워크북을 생성합니다.
Workbook workbook = new Workbook();

// Excel 차트를 추가합니다.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// 차트의 OLE 크기를 설정합니다.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// 차트 이미지를 가져와 스트림에 저장합니다.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// 워크북을 스트림에 저장합니다.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// 프레젠테이션을 생성합니다.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 워크북을 슬라이드에 추가합니다.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// 프레젠테이션을 디스크에 저장합니다.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // EXCEL_97_TO_2003 LoadOptions 개체를 생성합니다.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // 셀 이름 배열.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // 셀 데이터 배열.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // 데이터를 채우기 위해 새 워크시트를 추가합니다.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // 데이터 시트를 데이터로 채웁니다.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // 차트 시트를 추가합니다.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // 데이터 시트의 데이터 시리즈를 사용하여 차트 시트에 차트를 추가합니다.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // 차트 시트를 활성 시트로 설정합니다.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

위 방법으로 만든 프레젠테이션에는 OLE 객체 프레임을 두 번 클릭하면 활성화되는 OLE 객체 형태의 Excel 차트가 포함됩니다.

## **결론**

Java용 Aspose.Cells와 Aspose.Slides를 함께 사용하면 Aspose.Cells에서 지원하는 모든 Excel 차트를 만들고 차트를 PowerPoint 슬라이드에 OLE 객체로 삽입할 수 있습니다. Excel 차트의 OLE 크기도 정의할 수 있습니다. 최종 사용자는 다른 OLE 객체처럼 Excel 차트를 편집할 수 있습니다.

## **관련 섹션**

- [PPTX에서 차트 크기 조정을 위한 작업 솔루션](/slides/ko/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame 추가 시 객체 미리 보기 문제](/slides/ko/java/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint 추가 기능을 사용하여 OLE 객체 자동 업데이트](/slides/ko/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)