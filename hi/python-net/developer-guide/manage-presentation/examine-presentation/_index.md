---
title: "Python में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें"
linktitle: "प्रस्तुति जानकारी"
type: docs
weight: 30
url: /hi/python-net/examine-presentation/
keywords:
- "प्रस्तुति फ़ॉर्मेट"
- "प्रस्तुति प्रॉपर्टीज़"
- "डॉक्यूमेंट प्रॉपर्टीज़"
- "प्रॉपर्टीज़ प्राप्त करें"
- "प्रॉपर्टीज़ पढ़ें"
- "प्रॉपर्टीज़ बदलें"
- "प्रॉपर्टीज़ संशोधित करें"
- "प्रॉपर्टीज़ अपडेट करें"
- "PPTX का परीक्षण करें"
- "PPT का परीक्षण करें"
- "ODP का परीक्षण करें"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Python का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और अधिक बुद्धिमान कंटेंट ऑडिट के लिए।"
---
## **परिचय**

यह लेख Aspose.Slides में प्रस्तुति जानकारी की जाँच कैसे करें दिखाता है। यह बताता है कि पूरे फ़ाइल को लोड किए बिना प्रस्तुति के वर्तमान फ़ॉर्मेट का पता कैसे लगाएँ, उसकी डॉक्यूमेंट प्रॉपर्टीज़ पढ़ें, और आवश्यकता पड़ने पर उन प्रॉपर्टीज़ को अपडेट करें।

उदाहरण [PresentationInfo](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/) APIs पर आधारित हैं और प्रस्तुति मेटाडेटा के साथ काम करने के सामान्य संचालन को दर्शाते हैं।

## **प्रस्तुति फ़ॉर्मेट जाँचें**

प्रस्तुति पर काम करने से पहले, आप यह जानना चाह सकते हैं कि वर्तमान में प्रस्तुति किस फ़ॉर्मेट (PPT, PPTX, ODP, आदि) में है।

आप प्रस्तुति को लोड किए बिना उसकी फ़ॉर्मेट जाँच सकते हैं। इस Python कोड को देखें:

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

यह Python कोड आपको प्रस्तुति प्रॉपर्टीज़ (प्रस्तुति की जानकारी) प्राप्त करने का तरीका दिखाता है:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

आप [DocumentProperties के अंतर्गत प्रॉपर्टीज़](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/#properties) क्लास देखना चाह सकते हैं।

## **प्रस्तुति प्रॉपर्टीज़ अपडेट करें**

Aspose.Slides [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) मेथड प्रदान करता है जो आपको प्रस्तुति प्रॉपर्टीज़ में परिवर्तन करने की अनुमति देता है।

मान लें कि हमारे पास नीचे दिखाए गए डॉक्यूमेंट प्रॉपर्टीज़ वाली एक PowerPoint प्रस्तुति है।

![PowerPoint प्रस्तुति की मूल डॉक्यूमेंट प्रॉपर्टीज़](input_properties.png)

यह कोड उदाहरण दर्शाता है कि कुछ प्रस्तुति प्रॉपर्टीज़ को कैसे संपादित किया जाए:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

डॉक्यूमेंट प्रॉपर्टीज़ में बदलाव के परिणाम नीचे दिखाए गए हैं।

![PowerPoint प्रस्तुति की बदली हुई डॉक्यूमेंट प्रॉपर्टीज़](output_properties.png)

## **उपयोगी लिंक**

प्रस्तुति और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी के लिए, आपको ये लिंक उपयोगी लग सकते हैं:

- [प्रेजेंटेशन को पासवर्ड से सुरक्षित करें](/slides/hi/python-net/password-protected-presentation/)
- [प्रेजेंटेशन को लिखने से सुरक्षित करें](/slides/hi/python-net/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं यह कैसे जाँच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं या नहीं और कौन से हैं?**  
प्रस्तुति स्तर पर [embedded-font information](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) देखें, फिर उन प्रविष्टियों की तुलना [fonts actually used across content](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_fonts/) की सूची से करें ताकि रेंडरिंग के लिए आवश्यक फ़ॉन्ट्स की पहचान हो सके।

**फ़ाइल में छिपी हुई स्लाइड्स हैं या नहीं और उनकी संख्या कैसे जल्दी पता करें?**  
[slide collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/) के माध्यम से इटरेट करें और प्रत्येक स्लाइड के [visibility flag](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/hidden/) की जाँच करें।

**क्या मैं यह पता लगा सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग किए गए हैं या नहीं, और क्या वे डिफ़ॉल्ट से अलग हैं?**  
हाँ। वर्तमान [slide size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slide_size/) और अभिविन्यास की मानक प्रीसेट्स से तुलना करें; यह प्रिंटिंग और निर्यात के व्यवहार का अनुमान लगाने में मदद करता है।

**क्या चार्ट्स बाहरी डेटा स्रोतों का संदर्भ दे रहे हैं, यह देखने का कोई त्वरित तरीका है?**  
हाँ। सभी [charts](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/) को ट्रैवर्स करें, उनके [data source](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/data_source_type/) की जाँच करें, और यह नोट करें कि डेटा आंतरिक है या लिंक-आधारित, जिसमें टूटे हुए लिंक भी शामिल हों।

**मैं 'भारी' स्लाइड्स का मूल्यांकन कैसे करूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**  
प्रत्येक स्लाइड के लिए, ऑब्जेक्ट की संख्या गिनें और बड़े चित्र, ट्रांसपैरेंसी, शैडो, एनीमेशन और मल्टीमीडिया की तलाश करें; संभावित प्रदर्शन हॉटस्पॉट्स को दर्शाने के लिए एक मोटा जटिलता स्कोर असाइन करें।