---
title: Python में PowerPoint प्रस्तुतियों को XML में रूपांतरित करें
linktitle: PowerPoint से XML
type: docs
weight: 145
url: /hi/python-net/convert-powerpoint-to-xml/
keywords:
- PowerPoint को XML में बदलें
- प्रस्तुति को XML में बदलें
- PPT को XML में
- PPTX को XML में
- ODP को XML में
- PowerPoint XML प्रस्तुति
- SaveFormat.XML
- प्रस्तुति को XML के रूप में सहेजें
- प्रस्तुति को XML में निर्यात करें
- XML स्ट्रिम
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में PowerPoint और OpenDocument प्रस्तुतियों को PowerPoint XML फ़ाइलों या स्ट्रिम में रूपांतरित करें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET PowerPoint प्रस्तुतियों को PowerPoint XML Presentation फ़ॉर्मेट में बदल सकता है। XML आउटपुट उपयोगी होता है जब आपको प्रस्तुति संरचना का निरीक्षण करने, उत्पन्न दस्तावेज़ों की समस्या निवारण करने, स्वचालित परीक्षणों में आउटपुट की तुलना करने, या ऐसे कार्यप्रवाह के साथ एकीकृत करने की आवश्यकता हो जो प्रस्तुति पैकेज के बजाय XML का उपयोग करता है।

आप [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) मेथड को [SaveFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/saveformat/) एन्ह्यूमरेशन से `XML` मान के साथ उपयोग कर सकते हैं। आप परिणाम को सीधे फ़ाइल में या स्ट्रिम में लिख सकते हैं।

{{% alert color="info" title="नोट" %}}
`SaveFormat.XML` एक PowerPoint XML Presentation बनाता है। यह PPTX पैकेज के भीतर संग्रहीत व्यक्तिगत Office Open XML भागों को निकालता नहीं है। यदि आपको ठीक PPTX पैकेज भागों की आवश्यकता है, जैसे `ppt/presentation.xml` या व्यक्तिगत स्लाइड XML फ़ाइलें, तो सीधे PPTX पैकेज की जांच करें।
{{% /alert %}}

## **एक प्रस्तुति को XML फ़ाइल में बदलें**

[Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास के साथ स्रोत प्रस्तुति लोड करें, और फिर आउटपुट पथ तथा `SaveFormat.XML` को [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) को पास करें। स्रोत कोई भी समर्थित फ़ॉर्मेट हो सकता है, जैसे PPT, PPTX, या ODP।

निम्नलिखित उदाहरण PPTX प्रस्तुति को XML फ़ाइल में परिवर्तित करता है:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **XML आउटपुट को स्ट्रिम में लिखें**

[Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) की स्ट्रिम ओवरलोड का उपयोग करें जब XML को मेमोरी में रखना हो या उसे किसी अन्य घटक, जैसे वेब सेवा, स्टोरेज प्रोवाइडर, या XML प्रोसेसिंग पाइपलाइन, को पास करना हो। निम्नलिखित उदाहरण परिणाम को एक [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) स्ट्रिम में लिखता है और आगे पढ़ने के लिए उसे रीवाइंड करता है:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # वर्कफ़्लो में अगले घटक को xml_stream पास करें।
```

## **XML की तुलना प्रस्तुति और निर्यात फ़ॉर्मेट्स से करें**

परिणाम के उपयोग के अनुसार आउटपुट फ़ॉर्मेट चुनें:

| फ़ॉर्मेट | आउटपुट | सामान्य उपयोग |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | एक PowerPoint XML Presentation | संरचना का निरीक्षण, समस्या निवारण, उत्पन्न आउटपुट की तुलना, और XML-आधारित एकीकरण |
| PPT (`.ppt`) | एक पुरानी बाइनरी प्रस्तुति फ़ाइल | पुराने PowerPoint कार्यप्रवाहों के साथ संगतता |
| PPTX (`.pptx`) | कई भागों वाला Office Open XML पैकेज | सामान्य PowerPoint संपादन और प्रस्तुति आदान-प्रदान |
| PDF या TIFF | नियत लेआउट पृष्ठ या बहु-पृष्ठ छवि | देखना, प्रिंट करना, और संग्रहण |
| PNG, JPEG या SVG | व्यक्तिगत स्लाइड का रेंडर किया गया प्रतिनिधित्व | थंबनेल, पूर्वावलोकन, और इमेज एसेट्स |
| HTML या HTML5 | वेब-उन्मुख प्रस्तुति आउटपुट | ब्राउज़र में देखना और वेब प्रकाशन |

PPT और PPTX के विपरीत, XML आउटपुट मुख्य रूप से निरीक्षण और डेटा-उन्मुख कार्यप्रवाहों के लिए अभिप्रेत है। PDF, TIFF, HTML, और स्लाइड इमेज फ़ॉर्मेट्स के विपरीत, यह स्लाइड्स को पृष्ठों या दृश्य एसेट्स के रूप में रेंडर करने के बजाय प्रस्तुति डेटा को दर्शाता है। [supported file formats](/slides/hi/python-net/supported-file-formats/) तालिका PowerPoint XML Presentation को केवल-सेव फ़ॉर्मेट के रूप में सूचीबद्ध करती है, इसलिए इसे उस कार्यप्रवाह में उपयोग न करें जिसमें निर्यातित फ़ाइल को फिर से Aspose.Slides में लोड करके निरंतर संपादन करना आवश्यक हो।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या `SaveFormat.XML` PPTX फ़ाइल को सुरक्षित करने के समान है?**

नहीं। PPTX कई Office Open XML भागों वाला एक पैकेज है, जबकि `SaveFormat.XML` एक PowerPoint XML Presentation फ़ाइल बनाता है।

**क्या मैं XML आउटपुट को डिस्क पर फ़ाइल बनाए बिना सहेज सकता हूँ?**

हाँ। एक राइटेबल स्ट्रिम को [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) को पास करें। उदाहरण के लिए, इन‑मेमोरी प्रोसेसिंग के लिए एक [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) स्ट्रिम का उपयोग करें।

**क्या Aspose.Slides निर्यातित XML फ़ाइल को फिर से लोड कर सकता है?**

नहीं। PowerPoint XML Presentation वर्तमान में केवल सहेजने के लिए समर्थित है, लोड करने के लिए नहीं। यदि राउंड‑ट्रिप संपादन की आवश्यकता हो तो PPTX या अन्य समर्थित प्रस्तुति फ़ॉर्मेट का उपयोग करें।

**क्या XML रूपांतरण प्रत्येक स्लाइड को पृष्ठ या छवि के रूप में रेंडर करता है?**

नहीं। XML रूपांतरण संरचित प्रस्तुति डेटा लिखता है। पेज‑उन्मुख आउटपुट के लिए PDF या TIFF, और व्यक्तिगत स्लाइड छवियों के लिए PNG, JPEG, तथा SVG का उपयोग करें।