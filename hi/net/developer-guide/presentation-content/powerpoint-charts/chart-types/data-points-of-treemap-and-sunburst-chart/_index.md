---
title: ".NET में Treemap और Sunburst चार्ट में डेटा पॉइंट्स को कस्टमाइज़ करें"
linktitle: "Treemap और Sunburst चार्ट में डेटा पॉइंट्स"
type: docs
url: /hi/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- "ट्रीमैप चार्ट"
- "सनबर्स्ट चार्ट"
- "डेटा पॉइंट"
- "लेबल रंग"
- "शाखा रंग"
- "PowerPoint"
- "प्रेजेंटेशन"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ ट्रीमैप और सनबर्स्ट चार्ट में डेटा पॉइंट्स को प्रबंधित करना सीखें, जो PowerPoint फ़ॉर्मैट्स के साथ संगत है."
---
## **परिचय**

PowerPoint के अन्य चार्ट प्रकारों के बीच, दो "हायरार्किकल" प्रकार होते हैं - **Treemap** और **Sunburst** चार्ट (जिसे Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph या Multi Level Pie Chart भी कहा जाता है). ये चार्ट हायरार्किकल डेटा को एक पेड़ की तरह व्यवस्थित करके दर्शाते हैं - पत्तियों से लेकर शाखा के शीर्ष तक. पत्तियों को श्रृंखला डेटा पॉइंट्स द्वारा परिभाषित किया जाता है, और प्रत्येक बाद की नेस्टेड ग्रुपिंग स्तर संबंधित श्रेणी द्वारा परिभाषित होता है. Aspose.Slides for .NET आपको C# में Sunburst Chart और Treemap के डेटा पॉइंट्स को फ़ॉर्मेट करने की अनुमति देता है.

यहाँ एक Sunburst चार्ट है, जहाँ Series1 कॉलम का डेटा पत्तियों (leaf nodes) को परिभाषित करता है, जबकि अन्य कॉलम हायरार्किकल डेटा पॉइंट्स को परिभाषित करते हैं:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

आइए प्रस्तुति में एक नया Sunburst चार्ट जोड़ने से शुरू करते हैं:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="और देखें" %}} 
- [**Sunburst चार्ट बनाना**](/slides/hi/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

यदि चार्ट के डेटा पॉइंट्स को फॉर्मेट करने की आवश्यकता है, तो हमें निम्नलिखित का उपयोग करना चाहिए:
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/IChartDataPointLevelsManager), [IChartDataPointLevel](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapointlevel) क्लासेस और [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) प्रॉपर्टी डेटा पॉइंट्स को फॉर्मेट करने की पहुँच प्रदान करती है Treemap और Sunburst चार्ट्स के लिए. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/IChartDataPointLevelsManager) बहु-स्तरीय श्रेणियों तक पहुंचने के लिए उपयोग किया जाता है - यह [**IChartDataPointLevel**](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/IChartDataPointLevel) ऑब्जेक्ट्स के कंटेनर का प्रतिनिधित्व करता है. 
वास्तव में यह [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/IChartCategoryLevelsManager) के लिए एक रैपर है, जिसमें डेटा पॉइंट्स के लिए विशिष्ट अतिरिक्त प्रॉपर्टी शामिल हैं. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/IChartDataPointLevel) क्लास में दो प्रॉपर्टीज़ हैं: [**Format**](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapointlevel/properties/format) और [**DataLabel**](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapointlevel/properties/label) जो संबंधित सेटिंग्स तक पहुंच प्रदान करती हैं.

## **डेटा पॉइंट मूल्य दिखाएँ**
"Leaf 4" डेटा पॉइंट का मान दिखाएँ:

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **डेटा पॉइंट लेबल और रंग सेट करें**
"Branch 1" डेटा लेबल को श्रेणी नाम के बजाय श्रृंखला नाम ("Series1") दिखाने के लिए सेट करें। फिर टेक्स्ट कलर को पीला सेट करें:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **डेटा पॉइंट शाखा का रंग सेट करें**
"Stem 4" शाखा का रंग बदलें:

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Sunburst/Treemap में खंडों का क्रम (सॉर्टिंग) बदल सकता हूँ?**

नहीं। PowerPoint स्वचालित रूप से खंडों को सॉर्ट करता है (आमतौर पर घटते मानों के अनुसार, घड़ी की दिशा में)। Aspose.Slides इस व्यवहार को दोहराता है: आप क्रम सीधे नहीं बदल सकते; आपको डेटा को पूर्व-प्रसंस्करण करके यह प्राप्त करना होगा।

**प्रेजेंटेशन थीम खंडों और लेबल्स के रंगों को कैसे प्रभावित करती है?**

जब तक आप स्पष्ट रूप से फ़िल/फ़ॉन्ट सेट नहीं करते, चार्ट के रंग प्रेजेंटेशन के [theme/palette](/slides/hi/net/presentation-theme/) को विरासत में लेते हैं। सुसंगत परिणामों के लिए, आवश्यक स्तरों पर सॉलिड फ़िल और टेक्स्ट फ़ॉर्मेटिंग को फिक्स कर दें।

**क्या PDF/PNG में निर्यात कस्टम शाखा रंग और लेबल सेटिंग्स को बरकरार रखेगा?**

हाँ। जब प्रेजेंटेशन को निर्यात किया जाता है, चार्ट सेटिंग्स (फ़िल, लेबल) आउटपुट फॉर्मैट्स में बरकरार रहती हैं क्योंकि Aspose.Slides चार्ट के फॉर्मेटिंग को लागू करके रेंडर करता है।

**क्या मैं लेबल/एलिमेंट के वास्तविक निर्देशांक की गणना कर सकता हूँ ताकि कस्टम ओवरले को चार्ट के ऊपर रखा जा सके?**

हाँ। जब चार्ट लेआउट सत्यापित हो जाता है, तो तत्वों के लिए `ActualX`/`ActualY` उपलब्ध होते हैं (उदाहरण के लिए, एक [DataLabel](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/datalabel/)), जो ओवरले की सटीक पोजिशनिंग में मदद करता है।