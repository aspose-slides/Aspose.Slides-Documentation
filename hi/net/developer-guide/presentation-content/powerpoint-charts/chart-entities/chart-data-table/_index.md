---
title: .NET में प्रस्तुतियों में चार्ट डेटा तालिकाओं को अनुकूलित करें
linktitle: डेटा तालिका
type: docs
url: /hi/net/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा तालिका
- फ़ॉन्ट गुण
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET और C# का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा तालिका के फ़ॉन्ट, बॉर्डर और लेजेंड कुंजियों को अनुकूलित करें।"
---
## **अवलोकन**

Aspose.Slides for .NET आपको चार्ट की डेटा तालिका दिखाने और उसके टेक्स्ट फ़ॉर्मेटिंग, बॉर्डर, और लेजेंड कुंजियों को कस्टमाइज़ करने की अनुमति देता है। यह लेख बताता है कि तालिका को कैसे सक्षम करें, उसके टेक्स्ट को कैसे फॉर्मेट करें, प्रत्येक प्रकार के बॉर्डर को कैसे नियंत्रित करें, और लेजेंड कुंजियों को कैसे दिखाएँ या छुपाएँ। उदाहरण कॉन्फ़िगर किए गए चार्ट को PPTX फ़ाइलों में सहेजते हैं।

## **फ़ॉन्ट गुण सेट करें**

चार्ट की डेटा तालिका दिखाने के लिए, [HasDataTable](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chart/hasdatatable/) को `true` पर सेट करें। तालिका तक पहुँचने और उसके टेक्स्ट फ़ॉर्मेटिंग को कॉन्फ़िगर करने के लिए [ChartDataTable](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/chart/chartdatatable/) का उपयोग करें।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।  
1. पहले स्लाइड पर एक क्लस्टर्ड कॉलम चार्ट जोड़ें।  
1. चार्ट की डेटा तालिका सक्षम करें।  
1. [FontBold](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/fontbold/) के साथ बोल्ड टेक्स्ट सक्षम करें और 20‑पॉइंट टेक्स्ट के लिए [FontHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/fontheight/) को `20` पर सेट करें।  
1. संशोधित प्रस्तुति सहेजें।

निम्नलिखित उदाहरण को कार्य निर्देशिका में कम से कम एक स्लाइड वाली `test.pptx` फ़ाइल की आवश्यकता है। यह (50, 50) स्थिति पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है, जिसकी चौड़ाई 600 पॉइंट और ऊँचाई 400 पॉइंट है। सहेजे गए `output.pptx` में डेटा तालिका सक्षम वाला चार्ट और निर्दिष्ट फ़ॉन्ट सेटिंग्स लागू होती हैं।

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **डेटा तालिका बॉर्डर को अनुकूलित करें**

तालिका को [IChart.HasDataTable](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/hasdatatable/) से सक्षम करें और उसे [IChart.ChartDataTable](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/chartdatatable/) के माध्यम से एक्सेस करें। आप तीन प्रकार के बॉर्डर को स्वतंत्र रूप से नियंत्रित कर सकते हैं:

- [HasBorderHorizontal](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/idatatable/hasborderhorizontal/) क्षैतिज सेल बॉर्डर को नियंत्रित करता है।  
- [HasBorderVertical](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/idatatable/hasbordervertical/) लंबवत सेल बॉर्डर को नियंत्रित करता है।  
- [HasBorderOutline](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/idatatable/hasborderoutline/) तालिका की बाहरी सीमा को नियंत्रित करता है।

प्रत्येक प्रॉपर्टी को `true` सेट करने पर उसका बॉर्डर प्रदर्शित होगा और `false` पर छिपेगा। निम्नलिखित उदाहरण डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है, क्षैतिज बॉर्डर और बाहरी बॉर्डर दिखाता है, और लंबवत बॉर्डर को छिपाता है। इसे किसी इनपुट फ़ाइल की आवश्यकता नहीं है। चार्ट की स्थिति और आकार पॉइंट में निर्दिष्ट हैं।

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

नीचे दिया गया तुलना चार मामलों में समान चार्ट डेटा और लेजेंड कुंजी सेटिंग का उपयोग करती है। सभी बॉर्डर सक्षम करके शुरू किया गया, प्रत्येक अगली वैरिएंट केवल एक बॉर्डर प्रॉपर्टी को अक्षम करता है। नीचे‑बाएँ वैरिएंट उदाहरण के बॉर्डर सेटिंग के समान है।

![सभी बॉर्डर सक्षम, कोई क्षैतिज बॉर्डर नहीं, कोई लंबवत बॉर्डर नहीं, और कोई बाहरी बॉर्डर नहीं वाली चार्ट डेटा तालिकाएँ](data-table-borders.png)

## **लेजेंड कुंजियों को दिखाएँ या छुपाएँ**

लेजेंड कुंजियाँ डेटा तालिका में सीरीज़ नामों के बगल में छोटे रंगीन मार्कर होते हैं। वे पाठकों को प्रत्येक तालिका पंक्ति को चार्ट सीरीज़ से मिलाने में मदद करती हैं। इन मार्करों को दिखाने के लिए [ShowLegendKey](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/idatatable/showlegendkey/) को `true` सेट करें और छिपाने के लिए `false` सेट करें।

चार्ट की अलग लेजेंड को [IChart.HasLegend](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichart/haslegend/) द्वारा नियंत्रित किया जाता है। ये सेटिंग्स स्वतंत्र हैं: अलग लेजेंड को छिपाने से डेटा तालिका की कुंजियाँ नहीं छुपतीं, और तालिका की कुंजियों को छिपाने से अलग लेजेंड नहीं छुपता।

निम्नलिखित उदाहरण डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाता है, उसकी डेटा तालिका सक्षम करता है, और अलग लेजेंड को छिपाते हुए उसके भीतर लेजेंड कुंजियाँ दिखाता है। सभी तालिका बॉर्डर स्पष्ट रूप से सक्षम हैं। इनपुट प्रस्तुति की आवश्यकता नहीं है। केवल तालिका की कुंजियों को छिपाने के लिए, `dataTable.ShowLegendKey` को `false` में बदलें।

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

नीचे दिया गया तुलना समान तालिका को लेजेंड कुंजियों के सक्षम और अक्षम दोनों रूप में दिखाता है। सभी बॉर्डर सक्षम रहेंगे, और अलग चार्ट लेजेंड दोनों मामलों में छिपा रहेगा।

![बाएँ तरफ लेजेंड कुंजियाँ दिखती हुई और दाएँ तरफ छिपी हुई चार्ट डेटा तालिकाएँ](data-table-legend-keys.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट की डेटा तालिका में लेजेंड कुंजियाँ दिखा सकता हूँ?**

हाँ। लेजेंड कुंजियों को दिखाने के लिए [ShowLegendKey] को `true` और उन्हें छुपाने के लिए `false` सेट करें।

**क्या प्रस्तुति को PDF, HTML या इमेज में निर्यात करते समय डेटा तालिका बनी रहेगी?**

हाँ। Aspose.Slides स्लाइड को निर्यात करते समय चार्ट और उसकी प्रदर्शित डेटा तालिका को स्लाइड का हिस्सा के रूप में रेंडर करता है, चाहे वह [PDF](/slides/hi/net/convert-powerpoint-to-pdf/), [HTML](/slides/hi/net/convert-powerpoint-to-html/) या [images](/slides/hi/net/convert-powerpoint-to-png/) हो।

**क्या मैं टेम्प्लेट से लोड किए गए चार्ट की डेटा तालिकाओं के साथ काम कर सकता हूँ?**

हाँ। मौजूदा प्रस्तुति या टेम्प्लेट से लोड किए गए चार्ट के लिए, यह जांचने या बदलने के लिए कि उसकी डेटा तालिका प्रदर्शित है या नहीं, [HasDataTable] का उपयोग करें।

**मैं कैसे पता लगा सकता हूँ कि कौन से चार्ट में डेटा तालिका सक्षम है?**

प्रत्येक स्लाइड पर शैप्स को इटरैट करें, चार्ट को पहचानें, और उनके [HasDataTable] प्रॉपर्टी को जांचें। `true` मान दर्शाता है कि डेटा तालिका सक्षम है।