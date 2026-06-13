---
title: .NET में प्रस्तुति चार्ट्स में ट्रेंड लाइन्स जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/net/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- एक्सपोनेनशियल ट्रेंड लाइन
- लीनियर ट्रेंड लाइन
- लघुगणकीय ट्रेंड लाइन
- मूविंग एवरेज ट्रेंड लाइन
- पॉलीनॉमियल ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "PowerPoint चार्ट्स में Aspose.Slides for .NET के साथ ट्रेंड लाइन्स को तेज़ी से जोड़ें और अनुकूलित करें — आपका दर्शकों को जोड़े रखने के लिए एक व्यावहारिक मार्गदर्शिका।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट्स में ट्रेंड लाइन्स जोड़ने के तरीकों को समझाता है। यह चार्ट बनाने, चार्ट सीरीज़ में ट्रेंड लाइन्स जोड़ने, और विभिन्न ट्रेंड लाइन प्रकारों के साथ काम करने को दर्शाता है, जिसमें एक्सपोनेनशियल, लीनियर, लघुगणकीय, मूविंग एवरेज, पॉलीनॉमियल और पावर शामिल हैं।

यह भी समझाता है कि लाइन आकार डालकर चार्ट में एक कस्टम लाइन कैसे जोड़ी जाए, तथा फॉरवर्ड और बैकवर्ड ट्रेंडलाइन प्रोजेक्शन मानों और क्या ट्रेंड लाइन्स को PDF या SVG में निर्यात करने या चार्ट को इमेज के रूप में रेंडर करने पर संरक्षित किया जाता है, के बारे में एक छोटा FAQ शामिल है।

## **ट्रेंड लाइन जोड़ें**
Aspose.Slides for .NET विभिन्न चार्ट ट्रेंड लाइनों को प्रबंधित करने के लिए एक सरल API प्रदान करता है:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. स्लाइड को उसके इंडेक्स द्वारा प्राप्त करें।
1. डिफॉल्ट डेटा के साथ एक चार्ट जोड़ें और इच्छित प्रकार चुनें (यह उदाहरण ChartType.ClusteredColumn का उपयोग करता है)।
1. चार्ट सीरीज़ 1 के लिए एक्सपोनेनशियल ट्रेंड लाइन जोड़ें।
1. चार्ट सीरीज़ 1 के लिए लीनियर ट्रेंड लाइन जोड़ें।
1. चार्ट सीरीज़ 2 के लिए लघुगणकीय ट्रेंड लाइन जोड़ें।
1. चार्ट सीरीज़ 2 के लिए मूविंग एवरेज ट्रेंड लाइन जोड़ें।
1. चार्ट सीरीज़ 3 के लिए पॉलीनॉमियल ट्रेंड लाइन जोड़ें।
1. चार्ट सीरीज़ 3 के लिए पावर ट्रेंड लाइन जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

निम्न कोड का उपयोग ट्रेंड लाइन्स के साथ चार्ट बनाने के लिए किया जाता है।

```c#
// खाली प्रस्तुति बना रहे हैं
Presentation pres = new Presentation();

// क्लस्टर्ड कॉलम चार्ट बना रहे हैं
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// चार्ट सीरीज़ 1 के लिए एक्सपोनेनशियल ट्रेंड लाइन जोड़ रहे हैं
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// चार्ट सीरीज़ 1 के लिए लीनियर ट्रेंड लाइन जोड़ रहे हैं
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// चार्ट सीरीज़ 2 के लिए लघुगणकीय ट्रेंड लाइन जोड़ रहे हैं
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// चार्ट सीरीज़ 2 के लिए मूविंग एवरेज ट्रेंड लाइन जोड़ रहे हैं
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// चार्ट सीरीज़ 3 के लिए पॉलीनॉमियल ट्रेंड लाइन जोड़ रहे हैं
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// चार्ट सीरीज़ 3 के लिए पावर ट्रेंड लाइन जोड़ रहे हैं
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// प्रस्तुति सहेजा जा रहा है
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **कस्टम लाइन जोड़ें**
Aspose.Slides for .NET चार्ट में कस्टम लाइन्स जोड़ने के लिए एक सरल API प्रदान करता है। प्रस्तुति के चयनित स्लाइड में एक साधारण सी लाइन जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक इंस्टेंस बनाएं
- इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें
- Shapes ऑब्जेक्ट द्वारा प्रदर्शित AddChart मेथड का उपयोग करके नया चार्ट बनाएं
- Shapes ऑब्जेक्ट द्वारा प्रदर्शित AddAutoShape मेथड का उपयोग करके लाइन प्रकार की AutoShape जोड़ें
- शेप लाइनों का रंग सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

निम्न कोड का उपयोग कस्टम लाइन्स के साथ चार्ट बनाने के लिए किया जाता है।

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**ट्रेंडलाइन के लिए 'फॉरवर्ड' और 'बैकवर्ड' का क्या अर्थ है?**

वे ट्रेंडलाइन की उन लंबाइयों को दर्शाते हैं जो फॉरवर्ड/बैकवर्ड प्रोजेक्ट की गई हैं: स्कैटर (XY) चार्ट्स के लिए — अक्ष इकाइयों में; गैर-स्कैटर चार्ट्स के लिए — श्रेणियों की संख्या में। केवल गैर-नकारात्मक मान ही अनुमति है।

**क्या प्रस्तुति को PDF या SVG में निर्यात करने या स्लाइड को इमेज के रूप में रेंडर करने पर ट्रेंडलाइन संरक्षित रहेगी?**

हाँ। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/net/convert-powerpoint-to-pdf/)/[SVG](/slides/hi/net/render-a-slide-as-an-svg-image/) में बदलता है और चार्ट्स को इमेज में रेंडर करता है; ट्रेंडलाइन, चार्ट का हिस्सा होने के नाते, इन संचालन के दौरान संरक्षित रहती हैं। एक मेथड भी उपलब्ध है जिससे आप सीधे [चार्ट की इमेज निर्यात](/slides/hi/net/create-shape-thumbnails/) कर सकते हैं।