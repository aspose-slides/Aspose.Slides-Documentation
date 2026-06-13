---
title: Treemap और Sunburst चार्ट में डेटा पॉइंट्स को C++ का उपयोग करके अनुकूलित करें
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
description: "Aspose.Slides for C++ के साथ ट्रीमैप और सनबर्स्ट चार्ट में डेटा पॉइंट्स को प्रबंधित करना सीखें, जो PowerPoint फ़ॉर्मेट्स के साथ संगत है।"
---
## **परिचय**

PowerPoint चार्ट के अन्य प्रकारों में, दो “हायरार्किकल” प्रकार होते हैं - **Treemap** और **Sunburst** चार्ट (जिसे Sunburst ग्राफ, Sunburst डायग्राम, रेडियल चार्ट, रेडियल ग्राफ या मल्टी लेवल पाई चार्ट भी कहा जाता है). ये चार्ट पदानुक्रमित डेटा को पेड़ के रूप में व्यवस्थित करके दर्शाते हैं - पत्तियों से लेकर शाखा के शीर्ष तक. पत्तियों को सीरीज़ डेटा पॉइंट्स द्वारा परिभाषित किया जाता है, और प्रत्येक अगले नेस्टेड ग्रुपिंग लेवल को संबंधित कैटेगरी द्वारा परिभाषित किया जाता है. Aspose.Slides for C++ C++ में Sunburst चार्ट और Treemap के डेटा पॉइंट्स को फ़ॉर्मेट करने की अनुमति देता है.

यहाँ एक Sunburst चार्ट है, जहाँ Series1 कॉलम का डेटा पत्ती नोड्स को परिभाषित करता है, जबकि अन्य कॉलम पदानुक्रमित डेटा पॉइंट्स को परिभाषित करते हैं:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

आइए प्रस्तुति में एक नया Sunburst चार्ट जोड़ना शुरू करें:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="और देखें" %}} 
- [**Sunburst चार्ट बनाना**](/slides/hi/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

यदि चार्ट के डेटा पॉइंट्स को फ़ॉर्मेट करने की आवश्यकता हो, तो हमें निम्नलिखित का उपयोग करना चाहिए:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/) क्लासेज़ और [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) मेथड Treemap और Sunburst चार्ट्स के डेटा पॉइंट्स को फ़ॉर्मेट करने की पहुँच प्रदान करते हैं.
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) बहु-स्तरीय श्रेणियों तक पहुँचने के लिए उपयोग किया जाता है - यह [**IChartDataPointLevel**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/) ऑब्जेक्ट्स का कंटेनर दर्शाता है. 
वास्तव में यह [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) का एक रैपर है जिसमें डेटा पॉइंट्स के लिए विशिष्ट जोड़े गए गुण होते हैं. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/) क्लास के दो मेथड्स हैं: [**get_Format()**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) और [**get_Label()**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) जो सम्बंधित सेटिंग्स तक पहुँच प्रदान करते हैं.

## **डेटा पॉइंट मान दिखाएँ**
"Leaf 4" डेटा पॉइंट का मान दिखाएँ:

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **डेटा पॉइंट लेबल और रंग सेट करें**
"Branch 1" डेटा लेबल को श्रेणी नाम के बजाय सीरीज़ नाम ("Series1") दिखाने के लिए सेट करें। फिर टेक्स्ट रंग को पीले में बदलें:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **डेटा पॉइंट शाखा का रंग सेट करें**

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

## **FAQ**

**क्या मैं Sunburst/Treemap में सेगमेंट्स का क्रम (सॉर्टिंग) बदल सकता हूँ?**

नहीं। PowerPoint सेगमेंट्स को स्वतः सॉर्ट करता है (आमतौर पर घटते मानों के अनुसार, घड़ी की दिशा में)। Aspose.Slides इस व्यवहार को प्रतिबिंबित करता है: आप क्रम को सीधे नहीं बदल सकते; आपको डेटा को प्री‑प्रोसेस करके यह प्राप्त करना पड़ेगा।

**प्रेजेंटेशन थीम सेगमेंट्स और लेबल्स के रंगों को कैसे प्रभावित करती है?**

चार्ट के रंग प्रेजेंटेशन की [थीम/पैलेट](/slides/hi/cpp/presentation-theme/) को विरासत में लेते हैं जब तक आप स्पष्ट रूप से फ़िल्स/फ़ॉन्ट सेट नहीं करते। समान परिणामों के लिए, आवश्यक स्तरों पर सॉलिड फ़िल्स और टेक्स्ट फ़ॉर्मेटिंग को लॉक करें।

**क्या PDF/PNG में एक्सपोर्ट करने पर कस्टम शाखा रंग और लेबल सेटिंग्स बनी रहेंगी?**

हाँ। जब प्रेजेंटेशन को एक्सपोर्ट किया जाता है, तो चार्ट सेटिंग्स (फ़िल्स, लेबल्स) आउटपुट फ़ॉर्मेट में संरक्षित रहती हैं क्योंकि Aspose.Slides चार्ट के फ़ॉर्मेटिंग को लागू करके रेंडर करता है।

**क्या मैं लेबल/एलिमेंट के वास्तविक कॉर्डिनेट्स की गणना कर सकता हूँ ताकि चार्ट के ऊपर कस्टम ओवरले प्लेसमेंट कर सकूँ?**

हाँ। चार्ट लेआउट वैलिडेट होने के बाद, एलिमेंट्स (उदाहरण के लिए, एक [DataLabel](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/datalabel/)) के लिए वास्तविक X और वास्तविक Y उपलब्ध होते हैं, जो ओवरले की सटीक पोज़िशनिंग में मदद करता है।