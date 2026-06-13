---
title: Excel चार्ट बनाएं और उन्हें OLE ऑब्जेक्ट के रूप में प्रस्तुतियों में एम्बेड करें
type: docs
weight: 30
url: /hi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel चार्ट
- चार्ट एम्बेड करें
- OLE ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java के साथ Excel चार्ट बनाएं और उन्हें PowerPoint और OpenDocument प्रस्तुतियों में OLE ऑब्जेक्ट के रूप में एम्बेड करें। चरण-दर-चरण मार्गदर्शिका कोड नमूनों के साथ."
---
## **पृष्ठभूमि**

PowerPoint में, डेटा को ग्राफ़िकल रूप से प्रदर्शित करने के लिए संपादन योग्य चार्ट का उपयोग सामान्य प्रथा है। Aspose, Aspose.Cells for Java के साथ Excel चार्ट बनाने का समर्थन करता है, और इन चार्ट को फिर Aspose.Slides for Java के माध्यम से PowerPoint स्लाइड्स में OLE वस्तुओं के रूप में सम्मिलित किया जा सकता है। यह लेख आवश्यक चरणों को कवर करता है और Java कोड नमूने प्रदान करता है जो Aspose.Cells और Aspose.Slides का उपयोग करके Excel चार्ट बनाने और उसे PowerPoint प्रस्तुति में OLE वस्तु के रूप में सम्मिलित करता है।

## **आवश्यक चरण**

1. Aspose.Cells का उपयोग करके Excel चार्ट बनाएँ।  
2. Aspose.Cells का उपयोग करके Excel चार्ट का OLE आकार सेट करें।  
3. Aspose.Cells के साथ Excel चार्ट की छवि प्राप्त करें।  
4. Aspose.Slides का उपयोग करके PPTX प्रस्तुति में Excel चार्ट को OLE वस्तु के रूप में एम्बेड करें।  
5. चरण 3 में प्राप्त छवि के साथ "EMBEDDED OLE OBJECT" छवि को बदलें ताकि [object preview issue](/slides/hi/java/object-preview-issue-when-adding-oleobjectframe/) को संबोधित किया जा सके।  
6. प्रस्तुति को PPTX स्वरूप में डिस्क पर सहेजें।

## **आवश्यक चरणों का कार्यान्वयन**

उपरोक्त चरणों का Java कार्यान्वयन निम्नलिखित है:

```java
// एक वर्कबुक बनाएं.
Workbook workbook = new Workbook();

// एक Excel चार्ट जोड़ें.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// चार्ट का OLE आकार सेट करें.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// चार्ट छवि प्राप्त करें और उसे स्ट्रीम में सहेजें.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// वर्कबुक को स्ट्रीम में सहेजें.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// एक प्रस्तुति बनाएं.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// वर्कबुक को स्लाइड में जोड़ें.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// प्रस्तुति को डिस्क पर सहेजें.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // EXCEL_97_TO_2003 LoadOptions ऑब्जेक्ट बनाएं।
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // सेल नामों की एक array.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // सेल डेटा की एक array.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // डेटा के साथ कोशिकाओं को भरने के लिए एक नया worksheet जोड़ें.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // डेटा शीट को डेटा से पॉप्युलेट करें.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // एक chart sheet जोड़ें.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // डेटा शीट से डेटा श्रृंखला के साथ chart sheet पर chart जोड़ें.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // chart sheet को सक्रिय शीट के रूप में सेट करें.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

उपरोक्त विधि द्वारा निर्मित प्रस्तुति में Excel चार्ट OLE वस्तु के रूप में शामिल होगा, जिसे OLE वस्तु फ्रेम पर डबल-क्लिक करके सक्रिय किया जा सकता है।

## **निष्कर्ष**

Aspose.Cells for Java को Aspose.Slides for Java के साथ उपयोग करके, हम Aspose.Cells द्वारा समर्थित कोई भी Excel चार्ट बना सकते हैं और उसे PowerPoint स्लाइड में OLE वस्तु के रूप में एम्बेड कर सकते हैं। Excel चार्ट का OLE आकार भी परिभाषित किया जा सकता है। अंत उपयोगकर्ता फिर Excel चार्ट को किसी अन्य OLE वस्तु की तरह संपादित कर सकते हैं।

## **संबंधित अनुभाग**

- [PPTX में चार्ट आकार बदलने के लिए कार्य समाधान](/slides/hi/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame जोड़ते समय वस्तु पूर्वावलोकन समस्या](/slides/hi/java/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint ऐड-इन का उपयोग करके OLE वस्तुओं को स्वचालित रूप से अपडेट करना](/slides/hi/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)