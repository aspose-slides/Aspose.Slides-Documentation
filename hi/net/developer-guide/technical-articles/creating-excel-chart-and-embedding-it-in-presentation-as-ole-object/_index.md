---
title: Excel चार्ट बनाएं और उन्हें प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड करें
type: docs
weight: 50
url: /hi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel चार्ट
- चार्ट एम्बेड करें
- OLE ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "C#/.NET के साथ Excel चार्ट बनाएं और उन्हें PowerPoint और OpenDocument प्रस्तुतियों में OLE ऑब्जेक्ट के रूप में एम्बेड करें। चरण-दर-चरण मार्गदर्शिका कोड नमूनों के साथ।"
---
## **पृष्ठभूमि**

PowerPoint में, डेटा को ग्राफ़िक रूप से प्रदर्शित करने के लिए संपादन योग्य चार्ट का उपयोग सामान्य प्रथा है। Aspose .NET के लिए Aspose.Cells का उपयोग करके Excel चार्ट बनाना संभव है, और इन चार्टों को फिर Aspose.Slides for .NET के माध्यम से PowerPoint स्लाइड्स में OLE ऑब्जेक्ट के रूप में सम्मिलित किया जा सकता है। यह लेख आवश्यक चरणों को कवर करता है और Excel चार्ट बनाने और इसे Aspose.Cells और Aspose.Slides का उपयोग करके PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में सम्मिलित करने के लिए C# कोड नमूने प्रदान करता है।

## **आवश्यक चरण**

PowerPoint स्लाइड में Excel चार्ट को OLE ऑब्जेक्ट के रूप में बनाने और सम्मिलित करने के लिए निम्न क्रम में चरणों की आवश्यकता होती है:

1. Aspose.Cells का उपयोग करके एक Excel चार्ट बनाएं।
1. Aspose.Cells का उपयोग करके Excel चार्ट का OLE आकार निर्धारित करें।
1. Aspose.Cells के साथ Excel चार्ट की एक छवि प्राप्त करें।
1. Aspose.Slides का उपयोग करके PPTX प्रस्तुति में Excel चार्ट को OLE ऑब्जेक्ट के रूप में सम्मिलित करें।
1. चरण 3 में प्राप्त छवि के साथ “EMBEDDED OLE OBJECT” छवि को प्रतिस्थापित करें ताकि [ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/net/object-preview-issue-when-adding-oleobjectframe/) को हल किया जा सके।
1. प्रस्तुति को PPTX स्वरूप में डिस्क पर सहेजें।

## **आवश्यक चरणों का कार्यान्वयन**

ऊपर दर्शाए गए चरणों की C# कार्यान्वयन इस प्रकार है:

```cs
// Step - 1: Aspose.Cells का उपयोग करके Excel चार्ट बनाएं.
// ---------------------------------------------------
// एक वर्कबुक बनाएं.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Add an Excel chart.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Step - 2: Aspose.Cells का उपयोग करके चार्ट का OLE आकार निर्धारित करें.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Step - 3: Aspose.Cells के साथ चार्ट की छवि प्राप्त करें.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// वर्कबुक को एक स्ट्रीम में सहेजें.
MemoryStream workbookStream = workbook.SaveToStream();

// Step - 4 और 5
// =============
// Step - 4: Aspose.Slides का उपयोग करके .ppt प्रस्तुति में चार्ट को OLE ऑब्जेक्ट के रूप में एम्बेड करें.
// ------------------------------------------------------------------------------------------
// Step - 5: "EMBEDDED OLE OBJECT" छवि को चरण 3 में प्राप्त छवि से बदलें ताकि ऑब्जेक्ट प्रीव्यू समस्या को ठीक किया जा सके.
// --------------------------------------------------------------------------------------------------------------------
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // वर्कबुक को स्लाइड में जोड़ें.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Step - 6: आउटपुट प्रस्तुति को डिस्क पर सहेजें.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // कोशिकाओं के नामों की सरणी।
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // कोशिकाओं के डेटा की सरणी।
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // डेटा के साथ कोशिकाओं को भरने के लिए एक नया वर्कशीट जोड़ें।
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // डेटा शीट को डेटा से भरें।
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // चार्ट शीट जोड़ें।
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // डेटा शीट से डेटा श्रृंखला के साथ चार्ट शीट पर चार्ट जोड़ें।
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // चार्ट शीट को सक्रिय शीट के रूप में सेट करें।
    workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
    return chartSheetIndex;
}
```

```cs
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] oleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(oleData, 0, oleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	    imageStream.Position = 0;
        IPPImage ppImage = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

उपर्युक्त विधि से बनाई गई प्रस्तुति में Excel चार्ट OLE ऑब्जेक्ट के रूप में सम्मिलित होगा जिसे OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करके सक्रिय किया जा सकता है।

## **निष्कर्ष**

Aspose.Cells for .NET के साथ Aspose.Slides for .NET को मिलाकर हम Aspose.Cells द्वारा समर्थित किसी भी Excel चार्ट को बना सकते हैं और उसे PowerPoint स्लाइड में OLE ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। Excel चार्ट का OLE आकार भी परिभाषित किया जा सकता है। अंत उपयोगकर्ता फिर Excel चार्ट को किसी अन्य OLE ऑब्जेक्ट की तरह संपादित कर सकते हैं।

## **संबंधित अनुभाग**

- [PPTX में चार्ट आकार बदलने के लिए वर्किंग सॉल्यूशन](/slides/hi/net/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame जोड़ने पर ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/net/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint ऐड‑इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वचालित रूप से अपडेट करना](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)