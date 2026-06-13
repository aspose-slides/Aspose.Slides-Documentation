---
title: .NET में प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/net/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और फॉर्मेट करने के बारे में जानें, जिससे अधिक आकर्षक स्लाइड्स बनें।"
---
## **परिचय**

चार्ट पर डेटा लेबल चार्ट डेटा सीरीज़ या व्यक्तिगत डेटा बिंदुओं के बारे में विवरण दिखाते हैं। वे पाठकों को डेटा सीरीज़ को जल्दी से पहचानने में मदद करते हैं और चार्ट को समझना भी आसान बनाते हैं।

## **चार्ट डेटा लेबल में डेटा की सटीकता सेट करें**

यह C# कोड आपको दिखाता है कि चार्ट डेटा लेबल में डेटा की सटीकता कैसे सेट की जाती है:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **लेबल के रूप में प्रतिशत दिखाएँ**
Aspose.Slides for .NET आपको प्रदर्शित चार्ट पर प्रतिशत लेबल सेट करने की अनुमति देता है। यह C# कोड इस ऑपरेशन को दर्शाता है:

```c#
// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
IChartSeries series = chart.ChartData.Series[0];
IChartCategory cat;
double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    cat = chart.ChartData.Categories[k];

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
    }
}

double dataPontPercent = 0f;

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        IDataLabel lbl = series.DataPoints[j].Label;
        dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

        IPortion port = new Portion();
        port.Text = String.Format("{0:F2} %", dataPontPercent);
        port.PortionFormat.FontHeight = 8f;
        lbl.TextFrameForOverriding.Text = "";
        IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
        para.Portions.Add(port);

        lbl.DataLabelFormat.ShowSeriesName = false;
        lbl.DataLabelFormat.ShowPercentage = false;
        lbl.DataLabelFormat.ShowLegendKey = false;
        lbl.DataLabelFormat.ShowCategoryName = false;
        lbl.DataLabelFormat.ShowBubbleSize = false;
    }
}

// चार्ट वाले प्रेजेंटेशन को सेव करता है
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **चार्ट डेटा लेबल के साथ प्रतिशत चिह्न सेट करें**
यह C# कोड आपको दिखाता है कि चार्ट डेटा लेबल के लिए प्रतिशत चिह्न कैसे सेट किया जाए:

```c#
// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation presentation = new Presentation();

// स्लाइड का रेफरेंस उसके इंडेक्स के माध्यम से प्राप्त करता है
ISlide slide = presentation.Slides[0];

// स्लाइड पर PercentsStackedColumn चार्ट बनाता है
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// NumberFormatLinkedToSource को false सेट करता है
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// चार्ट डेटा वर्कशीट प्राप्त करता है
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// नई सीरीज़ जोड़ता है
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// सीरीज़ का फ़िल रंग सेट करता है
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// LabelFormat प्रॉपर्टीज़ सेट करता है
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// नई सीरीज़ जोड़ता है
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Fill प्रकार और रंग सेट करता है
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// प्रेजेंटेशन को डिस्क पर सेव करता है
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **एक अक्ष से लेबल की दूरी सेट करें**
यह C# कोड दर्शाता है कि जब आप अक्षों से प्लॉट किए गए चार्ट के साथ काम कर रहे हों, तो श्रेणी अक्ष से लेबल की दूरी कैसे सेट की जाए:

```c#
// Presentation क्लास का एक इंस्टेंस बनाता है
Presentation presentation = new Presentation();

// स्लाइड का रेफ़रेंस प्राप्त करता है
ISlide sld = presentation.Slides[0];

// स्लाइड पर एक चार्ट बनाता है
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// एक अक्ष से लेबल की दूरी सेट करता है
ch.Axes.HorizontalAxis.LabelOffset = 500;

// प्रेजेंटेशन को डिस्क पर सेव करता है
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **लेबल का स्थान समायोजित करें**

जब आप ऐसा चार्ट बनाते हैं जो किसी भी अक्ष पर निर्भर नहीं करता, जैसे पाई चार्ट, तो चार्ट के डेटा लेबल किनारे के बहुत निकट हो सकते हैं। ऐसे मामले में आपको डेटा लेबल के स्थान को समायोजित करना होगा ताकि लीडर लाइन्स स्पष्ट रूप से दिखें।

यह C# कोड दिखाता है कि पाई चार्ट पर लेबल का स्थान कैसे समायोजित किया जाए:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं घने चार्ट पर डेटा लेबल के ओवरलैप को कैसे रोक सकता हूँ?**

स्वचलित लेबल प्लेसमेंट, लीडर लाइन्स, और छोटे फ़ॉन्ट आकार को मिलाएं; यदि आवश्यक हो तो कुछ फ़ील्ड (जैसे श्रेणी) छिपाएँ या केवल अत्यंत/मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**मैं शून्य, नकारात्मक या खाली मानों के लिए लेबल केवल कैसे निष्क्रिय कर सकता हूँ?**

लेबल सक्षम करने से पहले डेटा पॉइंट्स को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक या अनुपलब्ध मानों के प्रदर्शन को बंद करें।

**PDF/छवियों में निर्यात करते समय एक समान लेबल शैली कैसे सुनिश्चित करूँ?**

फ़ॉन्ट (परिवार, आकार) को स्पष्ट रूप से सेट करें और रेंडरिंग पक्ष पर फ़ॉन्ट उपलब्ध है यह सत्यापित करें ताकि फ़ॉलबैक से बचा जा सके।