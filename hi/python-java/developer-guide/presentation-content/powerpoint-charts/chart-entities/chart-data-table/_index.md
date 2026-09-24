---
title: Python का उपयोग करके प्रस्तुतियों में चार्ट डेटा तालिकाओं को कस्टमाइज़ करें
linktitle: डेटा तालिका
type: docs
url: /hi/python-java/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा तालिका
- फ़ॉन्ट गुण
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा तालिका के फ़ॉन्ट, बॉर्डर और लेजेंड कीज़ को कस्टमाइज़ करें।"
---
## **अवलोकन**

Aspose.Slides for Python via Java आपको चार्ट की डेटा तालिका दिखाने और उसके टेक्स्ट फ़ॉर्मेटिंग, बॉर्डर और लेजेंड कीज़ को कस्टमाइज़ करने की अनुमति देता है। यह लेख बताता है कि तालिका को कैसे सक्षम करें, उसके टेक्स्ट को कैसे फ़ॉर्मेट करें, प्रत्येक प्रकार के बॉर्डर को कैसे नियंत्रित करें, और लेजेंड कीज़ को दिखाएँ या छुपाएँ। उदाहरण कॉन्फ़िगर किए गए चार्ट को PPTX फ़ाइलों में सहेजते हैं।

## **फ़ॉन्ट गुण सेट करें**

चार्ट की डेटा तालिका दिखाने के लिए, `True` पास करें [setDataTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#setDataTable)। तालिका तक पहुँचने और उसके टेक्स्ट फ़ॉर्मेटिंग को कॉन्फ़िगर करने के लिए [getChartDataTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#getChartDataTable) का उपयोग करें।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
1. पहली स्लाइड में एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
1. चार्ट की डेटा तालिका सक्षम करें।
1. [setFontBold](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setFontBold) के साथ बोल्ड टेक्स्ट सक्षम करें और 20 पॉइंट टेक्स्ट के लिए [setFontHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setFontHeight) में `20` पास करें।
1. संशोधित प्रस्तुति सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **डेटा तालिका बॉर्डर को कस्टमाइज़ करें**

टेबल को [Chart.setDataTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#setDataTable) के साथ सक्षम करें और इसे [Chart.getChartDataTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#getChartDataTable) के माध्यम से एक्सेस करें। आप तीन प्रकार के बॉर्डर को स्वतंत्र रूप से नियंत्रित कर सकते हैं:

- [setBorderHorizontal](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datatable/#setBorderHorizontal) क्षैतिज सेल बॉर्डर को नियंत्रित करता है।
- [setBorderVertical](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datatable/#setBorderVertical) लंबवत सेल बॉर्डर को नियंत्रित करता है।
- [setBorderOutline](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datatable/#setBorderOutline) तालिका की बाहरी सीमाएं नियंत्रित करता है।

प्रत्येक मेथड को `True` पास करें ताकि उसके बॉर्डर दिखें या `False` पास करके उन्हें छुपाएँ। निम्न उदाहरण एक डिफॉल्ट डेटा के साथ क्लस्टर्ड कॉलम चार्ट बनाता है, क्षैतिज बॉर्डर और बाहरी बॉर्डर दिखाता है, और लंबवत बॉर्डर छुपाता है। इसको किसी इनपुट फ़ाइल की आवश्यकता नहीं है। चार्ट की स्थिति और आकार पॉइंट्स में निर्दिष्ट किए गए हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

नीचे का तुलना चार्ट डेटा और लेजेंड की सेटिंग को सभी चार मामलों में एक जैसा उपयोग करता है। सभी बॉर्डर सक्षम करके शुरू किया गया है, प्रत्येक शेष वैरिएंट सिर्फ एक बॉर्डर सेटिंग को अक्षम करता है। नीचे-बाएँ वैरिएंट उदाहरण के बॉर्डर सेटिंग्स से मेल खाता है।

![सभी बॉर्डर सक्षम, कोई क्षैतिज बॉर्डर नहीं, कोई लंबवत बॉर्डर नहीं, और कोई बाहरी बॉर्डर नहीं वाले चार्ट डेटा तालिकाएँ](data-table-borders.png)

## **लेजेंड कीज़ दिखाएँ या छुपाएँ**

लेजेंड कीज़ डेटा तालिका में सीरीज़ नामों के बगल में छोटे रंगीन मार्कर होते हैं। वे पाठकों को प्रत्येक तालिका पंक्ति को चार्ट सीरीज़ से मिलान करने में मदद करते हैं। इन मार्करों को दिखाने के लिए [setShowLegendKey](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datatable/#setShowLegendKey) को `True` पास करें या छुपाने के लिए `False` पास करें।

चार्ट की अलग लेजेंड को [Chart.setLegend](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#setLegend) के द्वारा नियंत्रित किया जाता है। ये सेटिंग्स स्वतंत्र हैं: अलग लेजेंड को छुपाने से डेटा तालिका के भीतर की कीज़ नहीं छुपतीं, और तालिका की कीज़ को छुपाने से अलग लेजेंड नहीं छुपती।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

नीचे का तुलना वही तालिका लेजेंड कीज़ के सक्षम और अक्षम दोनों रूपों में दिखाता है। सभी बॉर्डर सक्षम रहेंगे, और चार्ट की अलग लेजेंड दोनों मामलों में छुपी होगी।

![बाएँ दिखाए गए और दाएँ छुपाए गए लेजेंड कीज़ के साथ चार्ट डेटा तालिकाएँ](data-table-legend-keys.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट की डेटा तालिका में लेजेंड कीज़ दिखा सकता हूँ?**

हाँ। लेजेंड कीज़ दिखाने के लिए [setShowLegendKey](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datatable/#setShowLegendKey) को `True` पास करें या उन्हें छुपाने के लिए `False` पास करें।

**क्या प्रस्तुति को PDF, HTML या इमेजेज़ में एक्सपोर्ट करने पर डेटा तालिका बनी रहेगी?**

हाँ। Aspose.Slides चार्ट और उसकी प्रदर्शित डेटा तालिका को स्लाइड का हिस्सा बनाकर [PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/hi/python-java/convert-powerpoint-to-html/), या [images](/slides/hi/python-java/convert-powerpoint-to-png/) में एक्सपोर्ट करता है।

**क्या मैं टेम्पलेट से लोड किए गए चार्ट में डेटा तालिकाओं के साथ काम कर सकता हूँ?**

हाँ। किसी मौजूदा प्रस्तुति या टेम्पलेट से लोड किए गए चार्ट के लिए, [hasDataTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#hasDataTable) और [setDataTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#setDataTable) का उपयोग करके जांचें या बदलें कि उसकी डेटा तालिका प्रदर्शित है या नहीं।

**मैं कैसे उन चार्ट्स को खोज सकता हूँ जिनमें डेटा तालिका सक्षम है?**

प्रत्येक स्लाइड में शेप्स के माध्यम से इटररेट करें, चार्ट्स की पहचान करें, और उनके [hasDataTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#hasDataTable) मेथड को कॉल करें। `True` का मान दर्शाता है कि डेटा तालिका सक्रिय है।