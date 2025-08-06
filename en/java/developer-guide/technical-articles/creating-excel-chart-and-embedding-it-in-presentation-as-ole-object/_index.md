---
title: Create Excel Charts and Embed Them in Presentations as OLE Objects
type: docs
weight: 30
url: /java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel chart
- embed chart
- OLE object
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Create Excel charts and embed them as OLE objects in PowerPoint and OpenDocument presentations with Java. Step-by-step guide with code samples."
---

## **Background**

In PowerPoint, using editable charts to display data graphically is a common practice. Aspose supports creating Excel charts with Aspose.Cells for Java, and these charts can then be embedded as OLE objects in PowerPoint slides through Aspose.Slides for Java. This article covers the necessary steps and provides Java code samples for creating an Excel chart and embedding it as an OLE object in a PowerPoint presentation using Aspose.Cells and Aspose.Slides.

## **Required Steps**

The following sequence of steps is required to create and embed an Excel chart as an OLE object in a PowerPoint slide:

1. Create an Excel chart using Aspose.Cells.
1. Set the OLE size of the Excel chart using Aspose.Cells.
1. Get an image of the Excel chart with Aspose.Cells.
1. Embed the Excel chart as an OLE object in a PPTX presentation using Aspose.Slides.
1. Replace the "EMBEDDED OLE OBJECT" image with the image obtained in step 3 to address the [object preview issue](/slides/java/object-preview-issue-when-adding-oleobjectframe/).
1. Save the presentation to disk in PPTX format.

## **Implementation of the Required Steps**

The Java implementation of the above steps is as follows:

```java
// Create a workbook.
Workbook workbook = new Workbook();

// Add an Excel chart.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Set the OLE size of the chart.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// Get the chart image and save it to a stream.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// Save the workbook to a stream.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Create a presentation.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the workbook to a slide.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// Save the presentation to disk.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // Create an EXCEL_97_TO_2003 LoadOptions object.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // An array of cell names.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // An array of cell data.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Add a new worksheet to populate cells with data.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // Populate the data sheet with data.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // Add a chart sheet.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // Add a chart to the chart sheet with data series from the data sheet.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // Set the chart sheet as an active sheet.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

The presentation created by the above method will contain the Excel chart as an OLE object that can be activated by double-clicking the OLE object frame.

## **Conclusion**

By using Aspose.Cells for Java together with Aspose.Slides for Java, we can create any Excel chart supported by Aspose.Cells and embed the chart as an OLE object in a PowerPoint slide. The OLE size of the Excel chart can also be defined. End users can then edit the Excel chart like any other OLE object.

## **Related Sections**

- [Working Solution for Chart Resizing in PPTX](/slides/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/java/object-preview-issue-when-adding-oleobjectframe/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)
