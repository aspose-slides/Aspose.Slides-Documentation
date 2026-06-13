---
title: .NET में प्रस्तुतियों के लिए चार्ट गणनाओं को अनुकूलित करें
linktitle: चार्ट गणनाएँ
type: docs
weight: 50
url: /hi/net/chart-calculations/
keywords:
- चार्ट गणनाएँ
- चार्ट तत्व
- तत्व की स्थिति
- वास्तविक स्थिति
- संतान तत्व
- माता‑पिता तत्व
- चार्ट मान
- वास्तविक मान
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में PPT और PPTX के लिए चार्ट गणनाओं, डेटा अपडेट और सटीकता नियंत्रण को समझें, साथ ही व्यावहारिक C# कोड उदाहरणों के साथ।"
---
## **सारांश**

Aspose.Slides प्रस्तुतियों में चार्ट गणना और लेआउट डेटा के साथ काम करने के लिए API प्रदान करता है। यह लेख दिखाता है कि कैसे चार्ट तत्वों के वास्तविक मान प्राप्त किए जाएँ, जिसमें `IActualLayout` को लागू करने वाले तत्वों की वास्तविक स्थिति और आकार, तथा चार्ट अक्षों के वास्तविक मान शामिल हैं। यह भी बताया गया है कि ये मान चार्ट लेआउट सत्यापन के बाद भरते हैं।

इसके अतिरिक्त, लेख यह दर्शाता है कि माता‑पिता चार्ट तत्वों की वास्तविक स्थिति कैसे प्राप्त की जाए और चार्ट के घटकों जैसे शीर्षक, अक्ष, लेजेंड और ग्रिड लाइनों को कैसे छिपाया जाए। ये उदाहरण आपको प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों में चार्ट लेआउट जानकारी निरीक्षण करने और चार्ट तत्वों की दृश्यता को नियंत्रित करने में मदद करेंगे।

## **चार्ट तत्वों के वास्तविक मानों की गणना**
Aspose.Slides for .NET इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। यह आपको चार्ट तत्वों के वास्तविक मानों की गणना करने में सहायता करेगा। वास्तविक मानों में IActualLayout इंटरफ़ेस को लागू करने वाले तत्वों की स्थिति (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) और वास्तविक अक्ष मान (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale) शामिल हैं।

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// प्रस्तुति सहेजना
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **माता‑पिता चार्ट तत्वों की वास्तविक स्थिति की गणना**
Aspose.Slides for .NET इन गुणों को प्राप्त करने के लिए एक सरल API प्रदान करता है। IActualLayout के गुण माता‑पिता चार्ट तत्व की वास्तविक स्थिति के बारे में जानकारी देते हैं। वास्तविक मानों को भरने के लिए पहले IChart.ValidateChartLayout() विधि को कॉल करना आवश्यक है।

```c#
// खाली प्रस्तुति बनाना
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```

## **चार्ट तत्वों को छिपाएँ**
यह विषय आपको यह समझने में मदद करता है कि चार्ट से जानकारी कैसे छिपाई जाए। Aspose.Slides for .NET का उपयोग करके आप चार्ट से **Title, Vertical Axis, Horizontal Axis** और **Grid Lines** को छिपा सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि इन गुणों का उपयोग कैसे किया जाए।

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //चार्ट शीर्षक छिपाना
    chart.HasTitle = false;

    ///मान अक्ष छिपाना
    chart.Axes.VerticalAxis.IsVisible = false;

    //श्रेणी अक्ष दृश्यता
    chart.Axes.HorizontalAxis.IsVisible = false;

    //लीजेंड छिपाना
    chart.HasLegend = false;

    //मुख्य ग्रिड लाइनों को छिपाना
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //श्रृंखला रेखा का रंग सेट करना
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**बाहरी Excel कार्यपुस्तिकाएँ डेटा स्रोत के रूप में काम करती हैं, और इसका पुनःगणना पर क्या प्रभाव पड़ता है?**

हाँ। एक चार्ट बाहरी कार्यपुस्तिका को संदर्भित कर सकता है: जब आप बाहरी स्रोत से कनेक्ट या रीफ़्रेश करते हैं, तो सूत्र और मान उस कार्यपुस्तिका से लिये जाते हैं, और चार्ट खुलने/संपादित करने के दौरान अपडेट को प्रतिबिंबित करता है। API आपको [बाहरी कार्यपुस्तिका](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/setexternalworkbook/) पथ और लिंक्ड डेटा को प्रबंधित करने की अनुमति देता है।

**क्या मैं regression को लागू किए बिना trendlines की गणना और प्रदर्शन कर सकता हूँ?**

हाँ। [Trendlines](/slides/hi/net/trend-line/) (रेखीय, घातीय, आदि) को Aspose.Slides द्वारा जोड़ा और अपडेट किया जाता है; इनके पैरामीटर क्रमशः श्रृंखला डेटा से स्वचालित रूप से पुनःगणना होते हैं, इसलिए आपको अपने स्वयं के गणना को लागू करने की आवश्यकता नहीं है।

**यदि एक प्रस्तुति में कई चार्ट बाहरी लिंक के साथ हैं, तो क्या मैं प्रत्येक चार्ट के उपयोग किए जाने वाले कार्यपुस्तिका को नियंत्रित कर सकता हूँ?**

हाँ। प्रत्येक चार्ट अपना स्वयं का [external workbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartdata/setexternalworkbook/) निर्दिष्ट कर सकता है, या आप प्रत्येक चार्ट के लिए स्वतंत्र रूप से बाहरी कार्यपुस्तिका बना/बदल सकते हैं।