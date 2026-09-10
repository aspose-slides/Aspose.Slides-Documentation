---
title: "Python का उपयोग करके प्रस्तुतियों में चार्ट डेटा तालिकाओं को अनुकूलित करें"
linktitle: "डेटा तालिका"
type: docs
url: /hi/python-java/chart-data-table/
keywords:
- "चार्ट डेटा"
- "डेटा तालिका"
- "फ़ॉन्ट गुण"
- PowerPoint
- "प्रस्तुति"
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PPT और PPTX में Python के लिए चार्ट डेटा तालिकाओं को कस्टमाइज़ करके प्रस्तुतियों में दक्षता और आकर्षण बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा तालिकाओं के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि चार्ट के लिए डेटा तालिका कैसे प्रदर्शित करें और फ़ॉन्ट गुण जैसे बोल्ड शैली और फ़ॉन्ट ऊँचाई सेट करके उसके पाठ स्वरूपण को कैसे अनुकूलित किया जाए। उदाहरण में एक प्रस्तुति बनाना, एक चार्ट जोड़ना, चार्ट डेटा तालिका को सक्षम करना, फ़ॉन्ट सेटिंग लागू करना, और अद्यतन प्रस्तुति को सहेजना दर्शाया गया है।

यह चार्ट डेटा तालिका में लेजेंड कुंजियों को दिखाने, निर्यात के दौरान डेटा तालिका को संरक्षित रखने, मौजूदा प्रस्तुतियों या टेम्प्लेट्स से लोड किए गए चार्ट्स के साथ काम करने, और उन चार्ट्स की पहचान करने के सामान्य प्रश्नों के संक्षिप्त उत्तर भी शामिल करता है जहाँ डेटा तालिका सक्षम है।

## **चार्ट डेटा तालिका के लिए फ़ॉन्ट गुण सेट करें**

Aspose.Slides for Python via Java आपको एक चार्ट की डेटा तालिका दिखाने और उसके पाठ के फ़ॉन्ट गुण बदलने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग को इंस्टेंशिएट करें।
1. स्लाइड में एक चार्ट जोड़ें।
1. चार्ट डेटा तालिका दिखाएँ।
1. डेटा तालिका के पाठ की बोल्ड शैली और फ़ॉन्ट ऊँचाई सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित उदाहरण इन चरणों को दर्शाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# खाली प्रस्तुति बनाएं।
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**क्या मैं चार्ट की डेटा तालिका में मानों के बगल में छोटे लेजेंड कुंजियों को दिखा सकता हूँ?**

हाँ। डेटा तालिका [legend keys](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datatable/#setShowLegendKey) को समर्थन देती है, और आप उन्हें चालू या बंद कर सकते हैं।

**क्या प्रस्तुति को PDF, HTML, या छवियों में निर्यात करने पर डेटा तालिका संरक्षित रहती है?**

हाँ। Aspose.Slides चार्ट को स्लाइड का हिस्सा बनाकर रेंडर करता है, इसलिए निर्यातित [PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/hi/python-java/convert-powerpoint-to-html/)/[image](/slides/hi/python-java/convert-powerpoint-to-png/) में चार्ट उसके डेटा तालिका के साथ शामिल होता है।

**क्या टेम्प्लेट फ़ाइल से प्राप्त चार्ट्स के लिए डेटा तालिकाएँ समर्थित हैं?**

हाँ। किसी भी चार्ट के लिए जो मौजूदा प्रस्तुति या टेम्प्लेट से लोड किया गया है, आप चार्ट के गुणों का उपयोग करके यह जांच और बदल सकते हैं कि डेटा तालिका [is shown](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#hasDataTable) है या नहीं।

**मैं तेज़ी से कैसे पता कर सकता हूँ कि फ़ाइल में कौन‑से चार्ट्स में डेटा तालिका सक्षम है?**

प्रत्येक चार्ट की उस संपत्ति की जाँच करें जो यह संकेत देती है कि डेटा तालिका [is shown](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/#hasDataTable) है, और स्लाइड्स के माध्यम से इटररेट करके उन चार्ट्स की पहचान करें जहाँ यह सक्षम है।