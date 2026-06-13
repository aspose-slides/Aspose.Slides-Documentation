---
title: .NET में प्रस्तुतियों में बबल चार्ट को कस्टमाइज़ करें
linktitle: बबल चार्ट
type: docs
url: /hi/net/bubble-chart/
keywords:
- बबल चार्ट
- बबल आकार
- आकार स्केलिंग
- आकार प्रतिनिधित्व
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "PowerPoint में Aspose.Slides for .NET के साथ शक्तिशाली बबल चार्ट बनाएं और अनुकूलित करें ताकि आप अपने डेटा विज़ुअलाइज़ेशन को आसानी से बढ़ा सकें।"
---
## **परिचय**

यह लेख Aspose.Slides में बबल चार्ट के साथ काम करने का तरीका दिखाता है। यह दो विशिष्ट अनुकूलन विकल्पों को कवर करता है: `BubbleSizeScale` प्रॉपर्टी के माध्यम से बबल आकार को स्केल करना और `BubbleSizeRepresentation` प्रॉपर्टी के माध्यम से बबल आकार मानों को कैसे प्रदर्शित किया जाए इस पर नियंत्रण रखना।

उदाहरण दिखाते हैं कि बबल चार्ट कैसे बनाया जाए, उसके आकार स्केलिंग को कैसे समायोजित किया जाए, और बबल आकार प्रतिनिधित्व को चौड़ाई (width) उपयोग करने के लिए कैसे बदला जाए। लेख में एक छोटा FAQ सेक्शन भी शामिल है जो “Bubble with 3-D” चार्ट प्रकार के समर्थन को स्पष्ट करता है, बताता है कि व्यावहारिक चार्ट सीमाएँ प्रदर्शन और लक्षित PowerPoint संस्करण पर निर्भर करती हैं, और समझाता है कि निर्यात Aspose.Slides रेंडरिंग इंजन के माध्यम से चार्ट की उपस्थिति को कैसे बरकरार रखता है।

## **बबल चार्ट आकार स्केलिंग**
Aspose.Slides for .NET बबल चार्ट आकार स्केलिंग के लिए समर्थन प्रदान करता है। Aspose.Slides for .NET **IChartSeries.BubbleSizeScale** और **IChartSeriesGroup.BubbleSizeScale** प्रॉपर्टी जोड़ी गई हैं। नीचे एक नमूना उदाहरण दिया गया है।  

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **डेटा को बबल चार्ट आकार के रूप में प्रस्तुत करना**
**BubbleSizeRepresentation** प्रॉपर्टी IChartSeries, IChartSeriesGroup इंटरफ़ेस और संबंधित क्लासेज में जोड़ी गई है। **BubbleSizeRepresentation** निर्धारित करता है कि बबल आकार मान बबल चार्ट में कैसे प्रतिनिधित्व किए जाते हैं। संभव मान हैं: **BubbleSizeRepresentationType.Area** और **BubbleSizeRepresentationType.Width**। Consequently, **BubbleSizeRepresentationType** enum जोड़ा गया है जिससे डेटा को बबल चार्ट आकार के रूप में प्रस्तुत करने के संभावित तरीकों को निर्दिष्ट किया जा सके। नीचे नमूना कोड दिया गया है।

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या "3-D प्रभाव वाला बबल चार्ट" समर्थित है, और यह सामान्य चार्ट से कैसे अलग है?**

हाँ। एक अलग चार्ट प्रकार, “Bubble with 3-D”, उपलब्ध है। यह बबल्स पर 3-D स्टाइलिंग लागू करता है लेकिन अतिरिक्त अक्ष नहीं जोड़ता; डेटा X‑Y‑S (आकार) ही रहते हैं। यह प्रकार [चार्ट प्रकार](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/charttype/) enumeration में उपलब्ध है।

**क्या बबल चार्ट में सीरीज़ और पॉइंट्स की संख्या पर कोई सीमा है?**

API स्तर पर कोई कठोर सीमा नहीं है; प्रतिबंध प्रदर्शन और लक्षित PowerPoint संस्करण द्वारा निर्धारित होते हैं। पठनीयता और रेंडरिंग गति को ध्यान में रखते हुए पॉइंट्स की संख्या को यथोचित रखने की सिफ़ारिश की जाती है।

**एक्सपोर्ट बबल चार्ट की उपस्थिति (PDF, इमेज) को कैसे प्रभावित करेगा?**

समर्थित फॉर्मेट में निर्यात करने पर चार्ट की उपस्थिति बनी रहती है; रेंडरिंग Aspose.Slides इंजन द्वारा की जाती है। रास्टर/वेक्टर फॉर्मेट के लिए सामान्य चार्ट‑ग्राफिक्स रेंडरिंग नियम लागू होते हैं (रिज़ॉल्यूशन, एंटी‑एलियासिंग), इसलिए प्रिंटिंग के लिए पर्याप्त DPI चुनें।