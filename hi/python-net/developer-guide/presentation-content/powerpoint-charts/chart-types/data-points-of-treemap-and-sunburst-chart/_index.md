---
title: Python में Treemap और Sunburst चार्ट में डेटा पॉइंट्स को अनुकूलित करें
linktitle: Treemap और Sunburst चार्ट में डेटा पॉइंट्स
type: docs
url: /hi/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap चार्ट
- sunburst_chart
- डेटा पॉइंट
- लेबल रंग
- शाखा रंग
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके treemap और sunburst चार्ट में डेटा पॉइंट्स को प्रबंधित करना सीखें, जो PowerPoint और OpenDocument फ़ॉर्मेट के साथ संगत है।"
---
## **परिचय**

PowerPoint के अन्य चार्ट प्रकारों में, दो पदानुक्रमित प्रकार हैं—**Treemap** और **Sunburst** (जिसे Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph, या Multi-Level Pie Chart के रूप में भी जाना जाता है)। ये चार्ट पदानुक्रमित डेटा को वृक्ष के रूप में प्रदर्शित करते हैं—पत्तियों से लेकर शाखा के शीर्ष तक। पत्तियों को श्रृंखला डेटा पॉइंट्स द्वारा परिभाषित किया जाता है, और प्रत्येक अगले नेस्टेड ग्रुपिंग स्तर को संबंधित श्रेणी द्वारा परिभाषित किया जाता है। Aspose.Slides for Python via .NET आपको Python में Sunburst चार्ट और Treemap के डेटा पॉइंट्स को फ़ॉर्मेट करने की सुविधा देता है।

यहाँ एक Sunburst चार्ट है जहाँ Series1 कॉलम का डेटा पत्ती नोड्स को परिभाषित करता है, जबकि अन्य कॉलम पदानुक्रमित डेटा पॉइंट्स को परिभाषित करते हैं:

![Sunburst चार्ट उदाहरण](sunburst_example.png)

चलिए प्रस्तुति में एक नया Sunburst चार्ट जोड़ते हैं:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="देखें भी" %}}
- [**Sunburst चार्ट बनाएं**](/slides/hi/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

यदि आपको चार्ट डेटा पॉइंट्स को फ़ॉर्मेट करने की आवश्यकता है, तो निम्नलिखित API का उपयोग करें:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointlevel/), और [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) प्रॉपर्टी। ये Treemap और Sunburst चार्ट में डेटा पॉइंट्स को फ़ॉर्मेट करने के लिए पहुंच प्रदान करती हैं। [ChartDataPointLevelsManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) का उपयोग बहु‑स्तरीय श्रेणियों तक पहुंचने के लिए किया जाता है; यह [ChartDataPointLevel](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointlevel/) वस्तुओं का कंटेनर दर्शाता है। यह मूल रूप से [ChartCategoryLevelsManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartcategorylevelsmanager/) का एक रैपर है जिसमें डेटा पॉइंट‑विशिष्ट अतिरिक्त प्रॉपर्टी होती हैं। [ChartDataPointLevel](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointlevel/) प्रकार दो प्रॉपर्टी उजागर करता है—[format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointlevel/format/) और [label](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointlevel/label/)—जो संबंधित सेटिंग्स तक पहुंच प्रदान करती हैं।

## **डेटा पॉइंट मान प्रदर्शित करें**

यह अनुभाग दिखाता है कि Treemap और Sunburst चार्ट में व्यक्तिगत डेटा पॉइंट्स के मान कैसे प्रदर्शित करें। आप देखेंगे कि चयनित पॉइंट्स के लिए मान लेबल कैसे सक्षम करें।

"Leaf 4" डेटा पॉइंट का मान प्रदर्शित करें:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![डेटा पॉइंट मान](data_point_value.png)

## **डेटा पॉइंट के लिए लेबल और रंग सेट करें**

यह अनुभाग दिखाता है कि Treemap और Sunburst चार्ट में व्यक्तिगत डेटा पॉइंट्स के लिए कस्टम लेबल और रंग कैसे सेट करें। आप सीखेंगे कि विशिष्ट डेटा पॉइंट तक कैसे पहुंचें, लेबल असाइन करें, और महत्वपूर्ण नोड्स को उजागर करने के लिए ठोस फ़िल लागू करें।

"Branch 1" डेटा लेबल को श्रेणी नाम के बजाय श्रृंखला नाम ("Series1") दिखाने के लिए सेट करें, और फिर टेक्स्ट रंग को पीला करें:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![डेटा पॉइंट का लेबल और रंग](data_point_color.png)

## **डेटा पॉइंट के लिए शाखा रंग सेट करें**

शाखा रंगों का उपयोग करके आप Treemap और Sunburst चार्ट में पैरेंट और चाइल्ड नोड्स को दृश्य रूप से कैसे समूहित किया जाए, इसे नियंत्रित कर सकते हैं। यह अनुभाग दिखाता है कि विशिष्ट डेटा पॉइंट के लिए कस्टम शाखा रंग कैसे सेट करें ताकि आप महत्वपूर्ण सब‑ट्रीज़ को उजागर कर सकें और चार्ट की पठनीयता बढ़ा सकें।

"Stem 4" शाखा का रंग बदलें:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![शाखा रंग](branch_color.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Sunburst/Treemap में सेगमेंट्स का क्रम (सॉर्टिंग) बदल सकता हूँ?**

नहीं। PowerPoint सेगमेंट्स को स्वचालित रूप से (आमतौर पर घटते मान के अनुसार, घड़ी की दिशा में) क्रमबद्ध करता है। Aspose.Slides इस व्यवहार को प्रतिबिंबित करता है: आप क्रम सीधे नहीं बदल सकते; आपको डेटा को पूर्व‑प्रसंस्करण करके क्रम प्राप्त करना होगा।

**प्रेज़ेंटेशन थीम रंगों और लेबल्स पर कैसे प्रभाव डालती है?**

चार्ट रंग प्रस्तुति की [theme/palette](/slides/hi/python-net/presentation-theme/) को विरासत में लेते हैं जब तक आप स्पष्ट रूप से फ़िल/फ़ॉन्ट सेट नहीं करते। सुसंगत परिणामों के लिए आवश्यक स्तरों पर ठोस फ़िल और टेक्स्ट फ़ॉर्मेटिंग को लॉक करें।

**क्या PDF/PNG निर्यात कस्टम शाखा रंग और लेबल सेटिंग्स को संरक्षित करेगा?**

हां। जब प्रस्तुति को निर्यात किया जाता है, तो चार्ट सेटिंग्स (फ़िल, लेबल) आउटपुट फ़ॉर्मेट में संरक्षित रहती हैं क्योंकि Aspose.Slides चार्ट के फ़ॉर्मेटिंग लागू करके रेंडर करता है।

**क्या मैं लेबल/एलिमेंट के वास्तविक निर्देशांक की गणना कर सकता हूँ ताकि कस्टम ओवरले को चार्ट के ऊपर रख सकूँ?**

हां। चार्ट लेआउट मान्य होने के बाद, `actual_x`/`actual_y` एलिमेंट्स (जैसे कि [DataLabel](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabel/)) के लिए उपलब्ध होते हैं, जो ओवरले की सटीक स्थिति निर्धारण में मदद करते हैं।