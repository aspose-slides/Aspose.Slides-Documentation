---
title: 建立 Excel 圖表並將其作為 OLE 物件嵌入簡報
type: docs
weight: 30
url: /zh-hant/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 圖表
- 嵌入圖表
- OLE 物件
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Java 建立 Excel 圖表，並將它們作為 OLE 物件嵌入 PowerPoint 與 OpenDocument 簡報。提供逐步說明與程式碼範例。"
---
## **背景**

在 PowerPoint 中，使用可編輯的圖表以圖形方式顯示資料是常見的做法。Aspose 支援使用 Aspose.Cells for Java 建立 Excel 圖表，並可將這些圖表作為 OLE 物件嵌入到 PowerPoint 投影片中，透過 Aspose.Slides for Java。本文說明必要的步驟，並提供 Java 程式碼範例，用於建立 Excel 圖表並將其作為 OLE 物件嵌入 PowerPoint 簡報，使用 Aspose.Cells 與 Aspose.Slides。

## **必要步驟**

以下步驟序列是建立並將 Excel 圖表作為 OLE 物件嵌入 PowerPoint 投影片所必需的：

1. 使用 Aspose.Cells 建立 Excel 圖表。
1. 使用 Aspose.Cells 設定 Excel 圖表的 OLE 大小。
1. 使用 Aspose.Cells 取得 Excel 圖表的影像。
1. 使用 Aspose.Slides 將 Excel 圖表作為 OLE 物件嵌入 PPTX 簡報。
1. 將 "EMBEDDED OLE OBJECT" 圖像替換為第 3 步取得的圖像，以解決[物件預覽問題](/slides/zh-hant/java/object-preview-issue-when-adding-oleobjectframe/)。
1. 將簡報儲存為 PPTX 格式檔案。

## **必要步驟的實作**

上述步驟的 Java 實作如下：

```java
// 建立活頁簿。
Workbook workbook = new Workbook();

// 新增 Excel 圖表。
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// 設定圖表的 OLE 大小。
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// 取得圖表影像並儲存至串流。
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// 將活頁簿儲存至串流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// 建立簡報。
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 將活頁簿加入投影片。
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// 將簡報儲存至磁碟。
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // 建立 EXCEL_97_TO_2003 LoadOptions 物件。
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // 儲存格名稱陣列。
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // 儲存格資料陣列。
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // 新增工作表以填入資料到儲存格。
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // 將資料填入資料工作表。
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // 新增圖表工作表。
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // 在圖表工作表上新增圖表，資料系列取自資料工作表。
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // 將圖表工作表設為作用中的工作表。
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

透過上述方法建立的簡報將會包含作為 OLE 物件的 Excel 圖表，使用者可透過雙擊 OLE 物件框架來啟動它。

## **結論**

透過結合 Aspose.Cells for Java 與 Aspose.Slides for Java，我們可以建立 Aspose.Cells 支援的任何 Excel 圖表，並將該圖表嵌入為 PowerPoint 投影片中的 OLE 物件。也可以定義 Excel 圖表的 OLE 大小。最終使用者即可如同編輯其他 OLE 物件般編輯此 Excel 圖表。

## **相關章節**

- [PPTX 中圖表調整大小的可行解決方案](/slides/zh-hant/java/working-solution-for-chart-resizing-in-pptx/)
- [加入 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/java/object-preview-issue-when-adding-oleobjectframe/)
- [使用 PowerPoint 外掛自動更新 OLE 物件](/slides/zh-hant/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)