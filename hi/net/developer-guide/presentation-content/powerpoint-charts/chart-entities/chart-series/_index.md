---
title: .NET में प्रस्तुतियों में चार्ट डेटा श्रृंखलाएँ प्रबंधित करें
linktitle: डेटा श्रृंखला
type: docs
url: /hi/net/chart-series/
keywords:
- चार्ट श्रृंखला
- श्रृंखला ओवरलैप
- श्रृंखला रंग
- श्रेणी रंग
- श्रृंखला नाम
- डेटा बिंदु
- श्रृंखला गैप
- PowerPoint
- प्रस्तुतीकरण
- .NET
- C#
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) के लिए C# में चार्ट श्रृंखलाओं को प्रबंधित करना सीखें, व्यावहारिक कोड उदाहरणों और सर्वोत्तम प्रथाओं के साथ अपने डेटा प्रस्तुतियों को बेहतर बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET में [ChartSeries](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartseries/) की भूमिका का वर्णन करता है, जो प्रस्तुतियों में डेटा की संरचना और दृश्यता पर केंद्रित है। ये वस्तुएँ चार्ट में व्यक्तिगत डेटा बिंदुओं, श्रेणियों और उपस्थिति पैरामीटरों को परिभाषित करने वाले आधारभूत तत्व प्रदान करती हैं। [ChartSeries](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chartseries/) के साथ काम करके, डेवलपर्स अंतर्निहित डेटा स्रोतों को सहजता से एकीकृत कर सकते हैं और जानकारी के प्रदर्शन पर पूरी नियंत्रण रख सकते हैं, जिससे गतिशील, डेटा‑चालित प्रस्तुतियाँ बनती हैं जो स्पष्ट रूप से अंतर्दृष्टि और विश्लेषण को प्रकट करती हैं।

एक श्रृंखला चार्ट में प्लॉट किए गए संख्याओं की पंक्ति या स्तंभ होती है।

![chart-series-powerpoint](chart-series-powerpoint.png)

## **चार्ट श्रृंखला ओवरलैप सेट करें**

[IChartSeriesOverlap](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/properties/overlap) प्रॉपर्टी -100 से 100 की सीमा निर्दिष्ट करके 2D चार्ट में बार और कॉलम के ओवरलैप को नियंत्रित करती है। क्योंकि यह प्रॉपर्टी व्यक्तिगत चार्ट श्रृंखला के बजाय श्रृंखला समूह से जुड़ी है, इसलिए यह श्रृंखला स्तर पर केवल- पढ़ने योग्य (read-only) है। ओवरलैप मान को कॉन्फ़िगर करने के लिए, `ParentSeriesGroup.Overlap` रीड/राइट प्रॉपर्टी का उपयोग करें, जो उस समूह की सभी श्रृंखलाओं पर निर्दिष्ट ओवरलैप लागू करती है।

नीचे एक C# उदाहरण है जो दर्शाता है कि प्रस्तुति कैसे बनाई जाए, क्लस्टर्ड कॉलम चार्ट कैसे जोड़ा जाए, पहली चार्ट श्रृंखला तक कैसे पहुंचा जाए, ओवरलैप सेटिंग को कैसे कॉन्फ़िगर किया जाए, और फिर परिणाम को PPTX फ़ाइल के रूप में कैसे सहेजा जाए:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // डिफ़ॉल्ट डेटा के साथ क्लस्टर्ड कॉलम चार्ट जोड़ें।
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // श्रृंखला ओवरलैप सेट करें।
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // प्रस्तुति फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

परिणाम:
![श्रृंखला ओवरलैप](series_overlap.png)

## **श्रृंखला भरने का रंग बदलें**

Aspose.Slides चार्ट श्रृंखला के भरने के रंग को अनुकूलित करना आसान बनाता है, जिससे आप विशिष्ट डेटा बिंदुओं को उजागर कर सकते हैं और दृश्य रूप से आकर्षक चार्ट बना सकते हैं। यह [IFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/iformat/) ऑब्जेक्ट के माध्यम से प्राप्त किया जाता है, जो विभिन्न भराव प्रकार, रंग विन्यास और अन्य उन्नत स्टाइल विकल्पों को समर्थन देता है। स्लाइड में चार्ट जोड़ने और इच्छित श्रृंखला तक पहुंचने के बाद, बस श्रृंखला प्राप्त करें और उपयुक्त भराव रंग लागू करें। ठोस भराव के अलावा, आप ग्रेडिएंट या पैटर्न भराव का उपयोग करके डिज़ाइन लचीलापन बढ़ा सकते हैं। जब आप अपनी आवश्यकताओं के अनुसार रंग सेट कर लें, तब प्रस्तुति को सहेजें ताकि अद्यतन रूप अंतिम रूप ले सके।

निचे दिया गया C# कोड उदाहरण पहली श्रृंखला का रंग बदलने का तरीका दिखाता है:
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // डिफ़ॉल्ट डेटा के साथ क्लस्टर्ड कॉलम चार्ट जोड़ें।
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // पहली श्रृंखला का रंग सेट करें।
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // प्रस्तुति फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

परिणाम:
![श्रृंखला का रंग](series_color.png)

## **श्रृंखला नाम बदलें**

Aspose.Slides चार्ट श्रृंखला के नाम संशोधित करने का सरल तरीका प्रदान करता है, जिससे डेटा को स्पष्ट और सार्थक रूप से लेबल करना आसान हो जाता है। चार्ट डेटा में संबंधित कार्यपत्रक सेल तक पहुंचकर, डेवलपर्स डेटा प्रस्तुतिकरण को अनुकूलित कर सकते हैं। यह संशोधन विशेष रूप से उपयोगी होता है जब श्रृंखला नामों को डेटा के संदर्भ के आधार पर अपडेट या स्पष्ट करना हो। श्रृंखला का नाम बदलने के बाद, परिवर्तन को स्थायी बनाने के लिए प्रस्तुति को सहेजा जा सकता है।

नीचे एक C# कोड स्निपेट है जो इस प्रक्रिया को कार्य में दर्शाता है।
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // डिफ़ॉल्ट डेटा के साथ क्लस्टर्ड कॉलम चार्ट जोड़ें।
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // पहली श्रृंखला का नाम सेट करें।
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // प्रस्तुति फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

निचे दिया गया C# कोड श्रृंखला नाम बदलने का वैकल्पिक तरीका दिखाता है:
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // डिफ़ॉल्ट डेटा के साथ क्लस्टर्ड कॉलम चार्ट जोड़ें।
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // पहली श्रृंखला का नाम सेट करें।
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // प्रस्तुति फ़ाइल को डिस्क पर सहेजें।
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

परिणाम:
![श्रृंखला नाम](series_name.png)

## **स्वतः श्रृंखला भराव रंग प्राप्त करें**

Aspose.Slides for .NET आपको प्लॉट एरिया में चार्ट श्रृंखला के स्वतः भराव रंग को प्राप्त करने की अनुमति देता है। [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाने के बाद, आप सूचकांक द्वारा इच्छित स्लाइड का संदर्भ प्राप्त कर सकते हैं, फिर अपनी पसंद के प्रकार (जैसे `ChartType.ClusteredColumn`) का उपयोग करके चार्ट जोड़ सकते हैं। चार्ट में श्रृंखला तक पहुंचकर, आप स्वतः भराव रंग प्राप्त कर सकते हैं।

नीचे दिया गया C# कोड इस प्रक्रिया को विस्तृत रूप में दर्शाता है।
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // डिफ़ॉल्ट डेटा के साथ क्लस्टर्ड कॉलम चार्ट जोड़ें।
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // श्रृंखला का भराव रंग प्राप्त करें।
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

आउटपुट:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **चार्ट श्रृंखला के लिए इनवर्ट भराव रंग सेट करें**

जब आपके डेटा श्रृंखला में सकारात्मक और नकारात्मक दोनों मान होते हैं, तो सभी कॉलम या बार को एक ही रंग से रंगना चार्ट को पढ़ने में कठिन बना सकता है। Aspose.Slides for .NET आपको इनवर्ट भराव रंग असाइन करने की अनुमति देता है—एक अलग भराव जो स्वचालित रूप से शून्य से नीचे गिरने वाले डेटा बिंदुओं पर लागू होता है—ताकि नकारात्मक मान तुरंत स्पष्ट दिखें। इस खंड में आप इस विकल्प को सक्षम करने, उपयुक्त रंग चुनने, और अद्यतन प्रस्तुति को सहेजने का तरीका सीखेंगे।

निचे दिया गया कोड उदाहरण इस ऑपरेशन को दर्शाता है:
```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // नई श्रेणियाँ जोड़ें।
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // एक नई श्रृंखला जोड़ें।
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // श्रृंखला डेटा भरें।
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // श्रृंखला के लिए रंग सेटिंग्स निर्धारित करें।
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

परिणाम:
![इनवर्टेड ठोस भराव रंग](inverted_solid_fill_color.png)

आप पूरी श्रृंखला के बजाय एक एकल डेटा बिंदु के लिए भराव रंग को इनवर्ट कर सकते हैं। बस इच्छित `IChartDataPoint` तक पहुंचें और उसकी `InvertIfNegative` प्रॉपर्टी को true सेट करें।

निचे दिया गया कोड उदाहरण यह दिखाता है कि इसे कैसे किया जाए:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // यदि इंडेक्स 2 पर डेटा बिंदु नकारात्मक है तो रंग को उलटें।
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **विशिष्ट डेटा बिंदु मूल्यों को साफ़ करें**

कभी-कभी चार्ट में परीक्षण मान, आउट्लायर या अप्रचलित प्रविष्टियां होती हैं जिन्हें आप पूरी श्रृंखला को पुनः निर्मित किए बिना हटाना चाहते हैं। Aspose.Slides for .NET आपको सूचकांक द्वारा किसी भी डेटा बिंदु को लक्षित करने, उसकी सामग्री साफ़ करने, और तुरंत प्लॉट को रिफ्रेश करने की सुविधा देता है, जिससे शेष बिंदु स्थान बदलते हैं और अक्ष स्वचालित रूप से पुनः स्केल होते हैं।

निचे दिया गया कोड उदाहरण इस ऑपरेशन को दर्शाता है:
```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **श्रृंखला गैप चौड़ाई सेट करें**

गैप चौड़ाई निकटवर्ती कॉलम या बार के बीच खाली स्थान की मात्रा को नियंत्रित करती है—व्यापक गैप व्यक्तिगत श्रेणियों को उभारा करते हैं, जबकि संकरी गैप अधिक घनी और कॉम्पैक्ट लुक बनाते हैं। Aspose.Slides for .NET के माध्यम से आप पूरे श्रृंखला के लिए इस पैरामीटर को बारीकी से समायोजित कर सकते हैं, जिससे आपकी प्रस्तुति को आवश्यक दृश्य संतुलन प्राप्त होता है बिना मूल डेटा को बदले।

नीचे दिया गया कोड उदाहरण दर्शाता है कि श्रृंखला के लिए गैप चौड़ाई कैसे सेट की जाए:
```cs
ushort gapWidth = 30;

// एक खाली प्रस्तुति बनाएं।
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड तक पहुंचें।
    ISlide slide = presentation.Slides[0];

    // डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // GapWidth मान सेट करें।
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

परिणाम:
![गैप चौड़ाई](gap_width.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**एक एकल चार्ट में कितनी अधिकतम श्रृंखलाएँ हो सकती हैं?**

Aspose.Slides आपके द्वारा जोड़ी गई श्रृंखलाओं की संख्या पर कोई निश्चित सीमा लागू नहीं करता। व्यावहारिक सीमा चार्ट की पढ़नीयता और आपके अनुप्रयोग के पास उपलब्ध मेमोरी से निर्धारित होती है।

**यदि क्लस्टर के भीतर कॉलम एक दूसरे के बहुत पास या बहुत दूर हों तो क्या करें?**

`GapWidth` सेटिंग को उस श्रृंखला (या उसके पैरेंट श्रृंखला समूह) के लिए समायोजित करें। मान बढ़ाने से कॉलम के बीच की दूरी बढ़ती है, जबकि घटाने से वे आपस में करीब आ जाते हैं।