---
title: VSTO और Aspose.Slides for .NET का उपयोग करके चार्ट बनाएं
linktitle: चार्ट बनाएं
type: docs
weight: 80
url: /hi/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- चार्ट बनाएं
- माइग्रेशन
- VSTO
- ऑफिस ऑटोमेशन
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "C# में PowerPoint चार्ट निर्माण को स्वचालित करने का तरीका सीखें। यह चरण-दर-चरण गाइड बताता है कि Aspose.Slides for .NET Microsoft.Office.Interop की तुलना में क्यों तेज़, अधिक शक्तिशाली विकल्प है।"
---
## **अवलोकन**

यह लेख दिखाता है कि कैसे C# का उपयोग करके Microsoft PowerPoint प्रस्तुतियों में चार्ट बनाये और कस्टमाइज़ करे। Aspose.Slides for .NET के साथ, आप Microsoft Office या Interop लाइब्रेरी पर निर्भर हुए बिना पेशेवर, डेटा‑चालित चार्ट को स्वचालित रूप से बना सकते हैं। API कॉलम चार्ट, पाई चार्ट, लाइन चार्ट और अन्य कई प्रकार के चार्ट बनाने के लिए समृद्ध सुविधाएँ प्रदान करती है — सभी को स्वरूप, डेटा और लेआउट पर पूर्ण नियंत्रण के साथ। चाहे आप रिपोर्ट, डैशबोर्ड या व्यावसायिक प्रस्तुतियों को बना रहे हों, Aspose.Slides आपके .NET अनुप्रयोगों से सीधे उच्च‑गुणवत्ता वाले विज़ुअलाइज़ेशन प्रदान करने में मदद करती है।

## **VSTO उदाहरण**

यह अनुभाग दिखाता है कि **VSTO (Visual Studio Tools for Office)** का उपयोग करके Microsoft PowerPoint प्रस्तुति में चार्ट कैसे बनाया जाए। VSTO के साथ, आप PowerPoint और Excel ऑटोमेशन को मिलाकर प्रोग्रामेटिक रूप से चार्ट जेनरेट और कस्टमाइज़ कर सकते हैं। नीचे दिया गया उदाहरण दिखाता है कि **3D क्लस्टर्ड कॉलम चार्ट** को कैसे जोड़ें, Excel वर्कशीट से डेटा भरें, स्वरूप और लेआउट समायोजित करें, और अंतिम प्रस्तुति को सहेजें — सभी .NET एप्लिकेशन के भीतर से।

1. Microsoft PowerPoint प्रस्तुति की एक इंस्टेंस बनाएँ।
1. प्रस्तुति में एक खाली स्लाइड जोड़ें।
1. 3D क्लस्टर्ड कॉलम चार्ट जोड़ें और उसे एक्सेस करें।
1. नया Microsoft Excel वर्कबुक इंस्टेंस बनाएँ और चार्ट डेटा लोड करें।
1. Excel वर्कबुक इंस्टेंस का उपयोग करके चार्ट डेटा वर्कशीट को एक्सेस करें।
1. वर्कशीट में चार्ट रेंज सेट करें और चार्ट से सीरीज़ 2 और 3 को हटाएँ।
1. चार्ट डेटा वर्कशीट में चार्ट की श्रेणी डेटा को संशोधित करें।
1. चार्ट डेटा वर्कशीट में सीरीज़ 1 डेटा को संशोधित करें।
1. चार्ट शीर्षक को एक्सेस करें और उसके फ़ॉन्ट‑संबंधित गुण सेट करें।
1. चार्ट के वैल्यू एक्सिस को एक्सेस करें और मुख्य इकाई, गौण इकाई, अधिकतम मान और न्यूनतम मान सेट करें।
1. चार्ट की डेप्थ (सीरीज़) एक्सिस को एक्सेस करें और उसे हटाएँ — इस उदाहरण में केवल एक सीरीज़ उपयोग की गई है।
1. X और Y दिशाओं में चार्ट के घूर्णन कोण सेट करें।
1. प्रस्तुति सहेजें।
1. Microsoft Excel और PowerPoint इंस्टेंस को बंद करें।

```c#
EnsurePowerPointIsRunning(true, true);

// Instantiate a slide object.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Access the first presentation slide.
objSlide = objPres.Slides[1];

// Select the first slide and set its layout.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Add a default chart to the slide.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Access the added chart.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Access the chart data.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Create an instance of the Excel workbook to work with the chart data.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Access the data worksheet for the chart.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Set the data range for the chart.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Apply the specified range to the chart data table.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Set values for categories and respective series data.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Set the chart title.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Access the chart value axis.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Set the values for the axis units.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Access the chart depth axis.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Set the chart rotation.
ppChart.Rotation = 20;   // Y-मान
ppChart.Elevation = 15;  // X-मान
ppChart.RightAngleAxes = false;

// Save the presentation as a PPTX file.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Close the workbook and presentation.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // Name प्रॉपर्टी को एक्सेस करने का प्रयास करें। यदि यह अपवाद फेंकती है, तो PowerPoint का नया इंस्टेंस शुरू करें।
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation का उपयोग यह सुनिश्चित करने के लिए किया जाता है कि एक प्रस्तुति लोड हुई है।
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // blnAddSlide का उपयोग यह सुनिश्चित करने के लिए किया जाता है कि प्रस्तुति में कम से कम एक स्लाइड हो।
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```

परिणाम:

![VSTO का उपयोग करके बनाया गया चार्ट](chart-created-using-VSTO.png)

## **Aspose.Slides for .NET उदाहरण**

निम्न उदाहरण दिखाता है कि Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुति में एक साधारण चार्ट कैसे बनाया जाए। यह कोड **3D क्लस्टर्ड कॉलम चार्ट** जोड़ता है, नमूना डेटा से भरता है, और उसके स्वरूप को कस्टमाइज़ करता है। कुछ ही कोड लाइनों के साथ आप डायनेमिक चार्ट जेनरेट कर सकते हैं और उन्हें अपनी प्रस्तुतियों में Microsoft Office का उपयोग किए बिना एकीकृत कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
1. पहली स्लाइड का रेफ़रेंस प्राप्त करें।
1. 3D क्लस्टर्ड कॉलम चार्ट जोड़ें और उसे एक्सेस करें।
1. चार्ट डेटा को एक्सेस करें।
1. अनउपयोगी Series 2 और Series 3 को हटाएँ।
1. लेबल अपडेट करके चार्ट श्रेणियों को संशोधित करें।
1. Series 1 के मान अपडेट करें।
1. चार्ट शीर्षक को एक्सेस करें और उसकी फ़ॉन्ट प्रॉपर्टीज सेट करें।
1. चार्ट के वैल्यू एक्सिस को कॉन्फ़िगर करें, जिसमें मुख्य इकाई, गौण इकाई, अधिकतम और न्यूनतम मान शामिल हैं।
1. X और Y एक्सिस पर चार्ट घूर्णन कोण सेट करें।
1. प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें।

```cs
    // एक खाली प्रस्तुति बनाएँ।
    using (Presentation presentation = new Presentation())
    {
        // पहली स्लाइड को एक्सेस करें।
        ISlide slide = presentation.Slides[0];

        // एक डिफ़ॉल्ट चार्ट जोड़ें।
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

        // चार्ट डेटा प्राप्त करें।
        IChartData chartData = chart.ChartData;

        // अतिरिक्त डिफ़ॉल्ट सीरीज़ हटाएँ।
        chartData.Series.RemoveAt(1);
        chartData.Series.RemoveAt(1);

        // चार्ट श्रेणी नामों को संशोधित करें।
        chartData.Categories[0].AsCell.Value = "Bikes";
        chartData.Categories[1].AsCell.Value = "Accessories";
        chartData.Categories[2].AsCell.Value = "Repairs";
        chartData.Categories[3].AsCell.Value = "Clothing";

        // चार्ट डेटा वर्कशीट का इंडेक्स सेट करें।
        int worksheetIndex = 0;

        // चार्ट डेटा वर्कबुक प्राप्त करें।
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // चार्ट सीरीज़ मान को संशोधित करें।
        chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
        chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
        chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
        chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

        // चार्ट शीर्षक सेट करें।
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
        IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
        format.FontItalic = NullableBool.True;
        format.FontHeight = 18;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.Black;

        // एक्सिस विकल्प सेट करें।
        chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
        chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
        chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
        chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

        chart.Axes.VerticalAxis.MaxValue = 4000.0F;
        chart.Axes.VerticalAxis.MinValue = 0.0F;
        chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
        chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
        chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

        // चार्ट घूर्णन सेट करें।
        chart.Rotation3D.RotationX = 15;
        chart.Rotation3D.RotationY = 20;

        // प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
        presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
    }
```

परिणाम:

![Aspose.Slides for .NET का उपयोग करके बनाया गया चार्ट](chart-created-using-aspose-slides.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Aspose.Slides के साथ पाई, लाइन या बार चार्ट जैसे अन्य प्रकार के चार्ट बना सकता हूँ?**

हाँ। Aspose.Slides for .NET विभिन्न प्रकार के [चार्ट प्रकार](/slides/hi/net/create-chart/) को समर्थन देता है, जिसमें पाई चार्ट, लाइन चार्ट, बार चार्ट, स्कैटर प्लॉट, बबल चार्ट और कई अन्य शामिल हैं। आप चार्ट जोड़ते समय इच्छित chart type को [ChartType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/charttype/) enumeration के माध्यम से निर्दिष्ट कर सकते हैं।

**क्या मैं चार्ट पर कस्टम स्टाइल या थीम लागू कर सकता हूँ?**

हाँ। आप चार्ट की उपस्थिति को पूरी तरह से कस्टमाइज़ कर सकते हैं, जिसमें रंग, फ़ॉन्ट, फ़िल, आउटलाइन, ग्रिडलाइन और लेआउट शामिल हैं। हालांकि, PowerPoint में दिखाई देने वाले Office थीम को बिल्कुल समान रूप से लागू करने के लिए व्यक्तिगत स्टाइल को मैन्युअल रूप से सेट करना पड़ेगा।

**क्या मैं स्लाइड से अलग-अलग चार्ट को इमेज के रूप में निर्यात कर सकता हूँ?**

हाँ, Aspose.Slides आपको किसी भी shape — जिसमें चार्ट भी शामिल है — को `GetImage` मेथड का उपयोग करके अलग-अलग इमेज (जैसे PNG, JPEG) के रूप में निर्यात करने की सुविधा देता है।