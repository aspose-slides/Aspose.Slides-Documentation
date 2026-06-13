---
title: Python में चार्ट डेटा टेबल को अनुकूलित करें
linktitle: डेटा टेबल
type: docs
url: /hi/python-net/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा टेबल
- फ़ॉन्ट गुण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python में PPT, PPTX और ODP के लिए चार्ट डेटा टेबल को Aspose.Slides के साथ अनुकूलित करके प्रस्तुतियों की दक्षता और आकर्षण बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा टेबल के साथ काम करने का तरीका समझाता है। यह दिखाता है कि चार्ट के लिए डेटा टेबल कैसे प्रदर्शित करें और बोल्ड शैली और फ़ॉन्ट ऊँचाई जैसी फ़ॉन्ट गुण सेट करके उसके पाठ फ़ॉर्मेटिंग को अनुकूलित करें। उदाहरण में प्रस्तुति लोड करना, चार्ट जोड़ना, चार्ट डेटा टेबल को सक्षम करना, फ़ॉन्ट सेटिंग्स लागू करना, और अद्यतन प्रस्तुति को सहेजना दर्शाया गया है।

यह चार्ट डेटा टेबल में लेजेंड कुंजी दिखाने, निर्यात के दौरान डेटा टेबल को संरक्षित रखने, मौजूदा प्रस्तुतियों या टेम्प्लेट से लोड किए गए चार्ट के साथ काम करने, और डेटा टेबल सक्षम वाले चार्ट की पहचान करने से संबंधित सामान्य प्रश्नों के संक्षिप्त उत्तर भी शामिल करता है।

## **चार्ट डेटा टेबल के लिए फ़ॉन्ट गुण सेट करें**
Aspose.Slides for Python via .NET एक श्रृंखला के रंग में वर्गों के रंग को बदलने के लिए समर्थन प्रदान करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास ऑब्जेक्ट बनायें।
1. स्लाइड पर चार्ट जोड़ें।
1. चार्ट टेबल सेट करें।
1. फ़ॉन्ट की ऊँचाई सेट करें।
1. संशोधित प्रस्तुति सहेजें।

नीचे दिया गया नमूना उदाहरण है।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट की डेटा टेबल में मानों के बगल में छोटे लेजेंड कुंजियाँ दिखा सकता हूँ?**

हां। डेटा टेबल [legend keys](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datatable/show_legend_key/) को समर्थन देता है, और आप इसे चालू या बंद कर सकते हैं।

**क्या प्रस्तुति को PDF, HTML, या इमेज में निर्यात करते समय डेटा टेबल संरक्षित रहेगा?**

हां। Aspose.Slides चार्ट को स्लाइड के हिस्से के रूप में रेंडर करता है, इसलिए निर्यात किया गया [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/hi/python-net/convert-powerpoint-to-html/)/[image](/slides/hi/python-net/convert-powerpoint-to-png/) में चार्ट अपने डेटा टेबल के साथ शामिल होता है।

**क्या टेम्प्लेट फ़ाइल से आए चार्ट के लिए डेटा टेबल समर्थित है?**

हां। मौजूदा प्रस्तुति या टेम्प्लेट से लोड किए गए किसी भी चार्ट के लिए, आप चार्ट की गुणों का उपयोग करके डेटा टेबल [is shown](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/has_data_table/) है या नहीं, जांच और बदल सकते हैं।

**मैं फ़ाइल में कौन से चार्ट डेटा टेबल सक्षम हैं, इसे जल्दी कैसे पता कर सकता हूँ?**

प्रत्येक चार्ट की वह विशेषता जांचें जो यह दर्शाती है कि डेटा टेबल [is shown](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/has_data_table/) है या नहीं, और स्लाइड्स के माध्यम से क्रमबद्ध करके उन चार्टों की पहचान करें जहाँ यह सक्षम है।