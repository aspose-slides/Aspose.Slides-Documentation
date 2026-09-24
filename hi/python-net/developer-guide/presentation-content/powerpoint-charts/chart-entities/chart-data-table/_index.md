---
title: Python में प्रस्तुतियों में चार्ट डेटा तालिकाओं को अनुकूलित करें
linktitle: डेटा तालिका
type: docs
url: /hi/python-net/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा तालिका
- फ़ॉन्ट गुण
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा तालिका के फ़ॉन्ट, सीमाओं और लेजेंड कुंजियों को अनुकूलित करें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET आपको चार्ट की डेटा तालिका प्रदर्शित करने और उसके पाठ स्वरूपण, सीमाओं और लेजेंड कुंजियों को अनुकूलित करने की सुविधा देता है। यह लेख बताता है कि तालिका को कैसे सक्षम करें, उसके पाठ को स्वरूपित करें, प्रत्येक प्रकार की सीमा को कैसे नियंत्रित करें, और लेजेंड कुंजियों को दिखाएँ या छुपाएँ। उदाहरण कॉन्फ़िगर किए गए चार्ट को PPTX फाइलों में सहेजते हैं।

## **फ़ॉन्ट गुण निर्धारित करें**

एक चार्ट की डेटा तालिका प्रदर्शित करने के लिए, [has_data_table](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/has_data_table/) को `True` सेट करें। तालिका तक पहुंचने और उसके पाठ स्वरूपण को कॉन्फ़िगर करने के लिए [chart_data_table](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/chart_data_table/) का उपयोग करें।

1. प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उपयोग करके लोड करें।
1. पहली स्लाइड में क्लस्टर्ड कॉलम चार्ट जोड़ें।
1. चार्ट की डेटा तालिका को सक्रिय करें।
1. बोल्ड टेक्स्ट को [font_bold](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/font_bold/) से सक्षम करें और 20 पॉइंट टेक्स्ट के लिए [font_height](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/font_height/) को `20` सेट करें।
1. संशोधित प्रेजेंटेशन को सहेजें।

निम्नलिखित उदाहरण के लिए कार्यशील डायरेक्टरी में कम से कम एक स्लाइड वाले `test.pptx` की आवश्यकता होती है। यह (50, 50) स्थिति पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है, जिसकी चौड़ाई 600 पॉइंट और ऊँचाई 400 पॉइंट है। सहेजा गया `output.pptx` चार्ट को उसकी डेटा तालिका सक्रिय और निर्दिष्ट फ़ॉन्ट सेटिंग्स लागू किए हुए सम्मिलित करता है।

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **डेटा तालिका सीमाओं को अनुकूलित करें**

टेबल को [Chart.has_data_table](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/has_data_table/) के साथ सक्रिय करें और उसे [Chart.chart_data_table](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/chart_data_table/) के माध्यम से एक्सेस करें। आप तीन प्रकार की सीमाओं को स्वतंत्र रूप से नियंत्रित कर सकते हैं:

- [has_border_horizontal](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datatable/has_border_horizontal/) क्षैतिज सेल सीमाओं को नियंत्रित करता है।
- [has_border_vertical](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datatable/has_border_vertical/) लंबवत सेल सीमाओं को नियंत्रित करता है।
- [has_border_outline](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datatable/has_border_outline/) तालिका की बाहरी सीमा को नियंत्रित करता है।

प्रत्येक प्रॉपर्टी को `True` सेट करने से उसकी सीमा प्रदर्शित होगी और `False` से छुपेगी। निम्नलिखित उदाहरण डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है, क्षैतिज और बाहरी सीमाओं को प्रदर्शित करता है और लंबवत सीमाओं को छुपाता है। इसे किसी इनपुट फाइल की आवश्यकता नहीं है। चार्ट का स्थान और आकार पॉइंट में निर्दिष्ट है।

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

नीचे दिया गया तुलना चारों मामलों में समान चार्ट डेटा और लेजेंड कुंजी सेटिंग का उपयोग करता है। सभी सीमाएँ सक्रिय करके शुरू किया गया, प्रत्येक शेष वेरिएंट केवल एक सीमा प्रॉपर्टी को निष्क्रिय करता है। नीचे‑बाएँ वेरिएंट उदाहरण की सीमा सेटिंग्स से मेल खाता है।

![चार्ट डेटा तालिकाएँ सभी सीमाओं के सक्रिय, बिना क्षैतिज सीमाओं के, बिना लंबवत सीमाओं के, और बिना बाहरी सीमा के](data-table-borders.png)

## **लेजेंड कुंजियों को दिखाएँ या छुपाएँ**

लेजेंड कुंजियाँ डेटा तालिका में श्रृंखला नामों के बगल में छोटे रंगीन मार्कर होते हैं। ये पाठकों को प्रत्येक तालिका पंक्ति को चार्ट श्रृंखला से मिलाने में मदद करते हैं। इन मार्करों को दिखाने के लिए [show_legend_key](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datatable/show_legend_key/) को `True` सेट करें और छुपाने के लिए `False` सेट करें।

चार्ट की अलग लेजेंड को [Chart.has_legend](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/has_legend/) द्वारा नियंत्रित किया जाता है। ये सेटिंग्स स्वतंत्र हैं: अलग लेजेंड को छुपाने से डेटा तालिका के भीतर की कुंजियाँ नहीं छुपतीं, और तालिका की कुंजियों को छुपाने से अलग लेजेंड नहीं छुपेगी।

निम्नलिखित उदाहरण डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाता है, उसकी डेटा तालिका को सक्रिय करता है, लेजेंड कुंजियों को भीतर दिखाता है जबकि अलग लेजेंड को छुपाता है। सभी तालिका सीमाएँ स्पष्ट रूप से सक्रिय हैं। कोई इनपुट प्रेजेंटेशन आवश्यक नहीं है। केवल तालिका की कुंजियों को छुपाने के लिए `data_table.show_legend_key` को `False` बदलें।

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

नीचे दिया गया तुलना वही तालिका लेजेंड कुंजियों के सक्रिय और निष्क्रिय दोनों रूप दिखाता है। सभी सीमाएँ सक्रिय बनी रहती हैं, और अलग चार्ट लेजेंड दोनों मामलों में छुपी रहती है।

![लेजेंड कुंजियों के साथ बायीं ओर दिखाए गए और दायीं ओर छुपाए गए चार्ट डेटा तालिकाएँ](data-table-legend-keys.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट की डेटा तालिका में लेजेंड कुंजियों को दिखा सकता हूँ?**

हाँ। लेजेंड कुंजियों को प्रदर्शित करने के लिए [show_legend_key](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datatable/show_legend_key/) को `True` सेट करें और उन्हें छुपाने के लिए `False` सेट करें।

**क्या प्रस्तुति को PDF, HTML या इमेज में एक्सपोर्ट करने पर डेटा तालिका बनी रहती है?**

हाँ। Aspose.Slides चार्ट और उसकी प्रदर्शित डेटा तालिका को स्लाइड का हिस्सा बनाकर [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/hi/python-net/convert-powerpoint-to-html/) या [images](/slides/hi/python-net/convert-powerpoint-to-png/) में एक्सपोर्ट करता है।

**क्या मैं टेम्प्लेट से लोड किए गए चार्ट में डेटा तालिकाओं के साथ काम कर सकता हूँ?**

हाँ। मौजूदा प्रेजेंटेशन या टेम्प्लेट से लोड किए गए चार्ट के लिए, यह जांचने या बदलने के लिए कि उसकी डेटा तालिका प्रदर्शित है या नहीं, [has_data_table](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/has_data_table/) का उपयोग करें।

**मैं कैसे उन चार्ट्स को खोजूँ जिनमें डेटा तालिका सक्षम है?**

प्रत्येक स्लाइड पर मौजूद शेप्स के माध्यम से इटररेट करें, चार्ट्स की पहचान करें, और उनकी [has_data_table](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/has_data_table/) प्रॉपर्टी को जांचें। `True` मान का मतलब है कि डेटा तालिका सक्षम है।