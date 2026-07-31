---
title: C++ का उपयोग करके Treemap और Sunburst चार्ट में डेटा पॉइंट्स को अनुकूलित करें
linktitle: Treemap और Sunburst चार्ट में डेटा पॉइंट्स
type: docs
url: /hi/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- ट्रीमैप चार्ट
- सनबर्स्ट चार्ट
- डेटा पॉइंट
- लेबल रंग
- ब्रांच रंग
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके ट्रीमैप और सनबर्स्ट चार्ट में डेटा पॉइंट्स को प्रबंधित करना सीखें, जो PowerPoint फॉर्मेट्स के साथ संगत हैं।"
---
## **परिचय**

PowerPoint चार्ट के अन्य प्रकारों के अलावा, दो “हाइरार्किकल” प्रकार होते हैं - **Treemap** और **Sunburst** चार्ट (जिसे Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph या Multi Level Pie Chart भी कहा जाता है)। इन चार्टों में पदानुक्रमित डेटा को पेड़ की संरचना में दिखाया जाता है - पत्तियों से लेकर शाखा के शीर्ष तक। पत्तियों को श्रृंखला (Series) के डेटा बिंदुओं से परिभाषित किया जाता है, और प्रत्येक अगला नेस्टेड समूह स्तर संबंधित श्रेणी द्वारा परिभाषित होता है। Aspose.Slides for C++ आपको Sunburst Chart और Treemap के डेटा बिंदुओं को C++ में फॉर्मेट करने की अनुमति देता है।

यहाँ एक Sunburst Chart है, जहाँ Series1 कॉलम का डेटा पत्तियों (leaf nodes) को परिभाषित करता है, जबकि अन्य कॉलम पदानुक्रमिक डेटा बिंदु को परिभाषित करते हैं:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

चलिए प्रस्तुति में नया Sunburst चार्ट जोड़ते हैं:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="साथ ही देखें" %}} 
- [**Sunburst चार्ट बनाना**](/slides/hi/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

यदि चार्ट के डेटा बिंदुओं को फॉर्मेट करने की आवश्यकता हो, तो हमें निम्नलिखित का उपयोग करना चाहिए:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/) क्लासेज और [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) मेथड Treemap और Sunburst चार्ट के डेटा बिंदुओं को फॉर्मेट करने के लिए एक्सेस प्रदान करते हैं।
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) बहु‑स्तरीय श्रेणियों तक पहुँचने के लिए उपयोग किया जाता है - यह [**IChartDataPointLevel**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/) ऑब्जेक्ट्स के कंटेनर को दर्शाता है। मूल रूप से यह [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) का एक रैपर है, जिसमें डेटा बिंदुओं के लिए विशिष्ट प्रॉपर्टीज़ जोड़ी गई हैं। 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/) क्लास में दो मेथड हैं: [**get_Format()**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) और [**get_Label()**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) जो संबंधित सेटिंग्स तक पहुँच प्रदान करते हैं।

## **डेटा बिंदु मान दिखाएँ**
"Leaf 4" डेटा बिंदु का मान दिखाएँ:

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **डेटा बिंदु लेबल और रंग सेट करें**
"Branch 1" डेटा लेबल को श्रेणी नाम के बजाय श्रृंखला नाम ("Series1") दिखाने के लिये सेट करें। फिर टेक्स्ट का रंग पीला करें:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **डेटा बिंदु शाखा का रंग सेट करें**

"Stem 4" शाखा का रंग बदलें:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Sunburst/Treemap में अनुभागों के क्रम (सॉर्टिंग) को बदल सकता हूँ?**

नहीं। PowerPoint स्वचालित रूप से अनुभागों को क्रमबद्ध करता है (आमतौर पर घटते मानों के अनुसार, घड़ी की दिशा में)। Aspose.Slides इस व्यवहार को प्रतिबिंबित करता है: आप क्रम को सीधे नहीं बदल सकते; इसके लिए डेटा को पूर्व‑प्रसंस्करण करना होगा।

**प्रेज़ेंटेशन थीम का अनुभागों और लेबलों के रंगों पर क्या प्रभाव पड़ता है?**

चार्ट के रंग प्रेज़ेंटेशन की [theme/palette](/slides/hi/cpp/presentation-theme/) से विरासत में मिलते हैं, जब तक आप स्पष्ट रूप से फिल/फ़ॉन्ट नहीं सेट करते। सुसंगत परिणाम पाने के लिए आवश्यक स्तरों पर ठोस फ़िल और टेक्स्ट फ़ॉर्मेटिंग को लॉक करें।

**क्या PDF/PNG में निर्यात करने से कस्टम शाखा रंग और लेबल सेटिंग्स बनी रहती हैं?**

हाँ। जब प्रेज़ेंटेशन निर्यात किया जाता है, तो चार्ट सेटिंग्स (फ़िल, लेबल) आउटपुट फ़ॉर्मेट में संरक्षित रहती हैं क्योंकि Aspose.Slides चार्ट के फ़ॉर्मेटिंग के साथ रेंडर करता है।

**क्या मैं लेबल/एलिमेंट के वास्तविक निर्देशांक निकाल सकता हूँ ताकि कस्टम ओवरले को चार्ट के ऊपर रखा जा सके?**

हाँ। चार्ट लेआउट की वैधता के बाद, वास्तविक X और Y मान उपलब्ध होते हैं (उदाहरण के लिए, एक [DataLabel](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/datalabel/) के लिए), जो ओवरले को सटीक रूप से स्थित करने में मदद करता है।