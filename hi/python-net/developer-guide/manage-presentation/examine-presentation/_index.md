---
title: Python में प्रस्तुति जानकारी को प्राप्त और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/python-net/examine-presentation/
keywords:
- प्रस्तुति प्रारूप
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अपडेट करें
- PPTX जाँचें
- PPT जाँचें
- ODP जाँचें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड, संरचना और मेटाडेटा का अन्वेषण करें, जिससे तेज़ अंतर्दृष्टि और अधिक समझदार सामग्री ऑडिट मिलें।"
---
## **परिचय**

यह लेख Aspose.Slides में प्रस्तुति जानकारी कैसे जांचें, दिखाता है। यह बताता है कि पूरा फ़ाइल लोड किए बिना प्रस्तुति के वर्तमान फ़ॉर्मेट का निर्धारण कैसे करें, उसके डॉक्यूमेंट प्रॉपर्टीज़ पढ़ें, और आवश्यक होने पर उन प्रॉपर्टीज़ को अपडेट करें।

उदाहरण [PresentationInfo](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/) APIs पर आधारित हैं और प्रस्तुति मेटाडाटा के साथ काम करने के सामान्य संचालन को दर्शाते हैं।

## **प्रस्तुति फ़ॉर्मेट जाँचें**

प्रस्तुति पर काम करने से पहले, आप यह जानना चाह सकते हैं कि वर्तमान में प्रस्तुति कौन से फ़ॉर्मेट (PPT, PPTX, ODP, आदि) में है।

आप प्रस्तुति को लोड किए बिना उसकी फ़ॉर्मेट जाँच सकते हैं। नीचे दिया गया Python कोड देखें:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **प्रस्तुति प्रॉपर्टीज़ प्राप्त करें**

यह Python कोड आपको दिखाता है कि प्रस्तुति प्रॉपर्टीज़ (प्रस्तुति से संबंधित जानकारी) कैसे प्राप्त करें:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

आप [DocumentProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/#properties) क्लास के तहत प्रॉपर्टीज़ देखना चाह सकते हैं।

## **प्रस्तुति प्रॉपर्टीज़ अपडेट करें**

Aspose.Slides [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) मेथड प्रदान करता है जो आपको प्रस्तुति प्रॉपर्टीज़ में बदलाव करने की अनुमति देता है।

मान लीजिए हमारे पास नीचे दिखाए गए डॉक्यूमेंट प्रॉपर्टीज़ वाली एक PowerPoint प्रस्तुति है।

![PowerPoint प्रस्तुति की मूल डॉक्यूमेंट प्रॉपर्टीज़](input_properties.png)

यह कोड उदाहरण दिखाता है कि कुछ प्रस्तुति प्रॉपर्टीज़ को कैसे संपादित करें:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

डॉक्यूमेंट प्रॉपर्टीज़ बदलने के परिणाम नीचे दिखाए गए हैं।

![PowerPoint प्रस्तुति की बदली हुई डॉक्यूमेंट प्रॉपर्टीज़](output_properties.png)

## **उपयोगी लिंक्स**

एक प्रस्तुति और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी पाने के लिए, ये लिंक उपयोगी हो सकते हैं:

- [जाँचें कि क्या प्रस्तुति एन्क्रिप्टेड है](https://docs.aspose.com/slides/hi/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [जाँचें कि क्या प्रस्तुति लिखने से सुरक्षित (केवल पढ़ने योग्य) है](https://docs.aspose.com/slides/hi/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [लोड करने से पहले जाँचें कि क्या प्रस्तुति पासवर्ड से सुरक्षित है](https://docs.aspose.com/slides/hi/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [प्रेजेंटेशन को सुरक्षित करने के लिए उपयोग किया गया पासवर्ड पुष्टि करना](https://docs.aspose.com/slides/hi/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं यह कैसे जाँचूँ कि फ़ॉन्ट एम्बेडेड हैं और कौन-कौन से हैं?**

प्रस्तुति स्तर पर [embedded-font information](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) देखें, फिर उन एंट्रीज़ की तुलना [फ़ॉन्ट्स जो वास्तव में सामग्री में उपयोग किए गए हैं](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_fonts/) के सेट से करें ताकि यह पहचाना जा सके कि कौन से फ़ॉन्ट रेंडरिंग के लिए महत्वपूर्ण हैं।

**मैं जल्दी से कैसे जानूँ कि फ़ाइल में छिपी स्लाइड्स हैं और उनकी संख्या कितनी है?**

[slide collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) पर इटरेट करें और प्रत्येक स्लाइड के [visibility flag](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/hidden/) को जाँचें।

**क्या मैं पता लगा सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग किया गया है, और क्या वह डिफॉल्ट से अलग है?**

हां। वर्तमान [slide size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slide_size/) और अभिविन्यास की तुलना मानक प्रीसेट्स से करें; यह प्रिंटिंग और एक्सपोर्ट के व्यवहार का अनुमान लगाने में मदद करता है।

**क्या चार्ट्स बाहरी डेटा स्रोतों की संदर्भित करते हैं, यह जल्दी से देखने का कोई तरीका है?**

हां। सभी [charts](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/) को ट्रैवर्स करें, उनके [data source](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/data_source_type/) की जाँच करें, और नोट करें कि डेटा आंतरिक है या लिंक-आधारित, जिसमें टूटे हुए लिंक भी शामिल हैं।

**मैं 'भारी' स्लाइड्स का मूल्यांकन कैसे करूँ जो रेंडरिंग या PDF एक्सपोर्ट को धीमा कर सकती हैं?**

प्रत्येक स्लाइड के लिए ऑब्जेक्ट काउंट गिनें और बड़े इमेज, ट्रांसपैरेंसी, शैडो, एनीमेशन और मल्टीमीडिया देखें; संभावित प्रदर्शन हॉटस्पॉट्स को चिन्हित करने के लिए एक मोटा जटिलता स्कोर असाइन करें।