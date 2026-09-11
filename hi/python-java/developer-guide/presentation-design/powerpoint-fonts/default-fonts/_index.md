---
title: Python के माध्यम से Java में डिफ़ॉल्ट प्रस्तुति फ़ॉन्ट निर्दिष्ट करें
linktitle: डिफ़ॉल्ट फ़ॉन्ट
type: docs
weight: 30
url: /hi/python-java/default-font/
keywords:
- डिफ़ॉल्ट फ़ॉन्ट
- सामान्य फ़ॉन्ट
- सामान्य फ़ॉन्ट
- एशियाई फ़ॉन्ट
- PDF निर्यात
- XPS निर्यात
- इमेज निर्यात
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides में Python के माध्यम से Java के लिए डिफ़ॉल्ट फ़ॉन्ट सेट करें ताकि PowerPoint (PPT, PPTX) और OpenDocument (ODP) का PDF, XPS और इमेज में उचित रूपांतरण सुनिश्चित हो सके।"
---
## **परिचय**

Aspose.Slides आपको डिफ़ॉल्ट फ़ॉन्ट निर्दिष्ट करने की अनुमति देता है जो प्रस्तुति रेंडर होने पर उपयोग किए जाते हैं। यह स्लाइड थंबनेल जनरेट करने या प्रस्तुति को PDF और XPS जैसी फ़ॉर्मेट्स में एक्सपोर्ट करने के समय उपयोगी है। डिफ़ॉल्ट फ़ॉन्ट को प्रस्तुति लोड होने से पहले [LoadOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/) के माध्यम से कॉन्फ़िगर किया जाता है।

[setDefaultRegularFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) मेथड रेग्युलर टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट को परिभाषित करता है, जबकि [setDefaultAsianFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) एशियाई टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट को परिभाषित करता है। इन विकल्पों को सेट करने के बाद, प्रस्तुति को लोड किया जा सकता है और निर्दिष्ट फ़ॉन्ट का उपयोग करके रेंडर किया जा सकता है।

## **प्रस्तुति रेंडर करने के लिए डिफ़ॉल्ट फ़ॉन्ट का उपयोग**

Aspose.Slides आपको PDF, XPS या थंबनेल के रूप में प्रस्तुति रेंडर करने के लिए डिफ़ॉल्ट फ़ॉन्ट सेट करने देता है। यह अनुभाग Aspose.Slides for Python via Java का उपयोग करके रेग्युलर और एशियाई टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट कैसे परिभाषित करें, दिखाता है:

1. एक [LoadOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/) का इंस्टेंस बनाएँ।  
2. अपना इच्छित फ़ॉन्ट निर्दिष्ट करने के लिए [setDefaultRegularFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) का उपयोग करें। निम्न उदाहरण में Wingdings उपयोग किया गया है।  
3. अपना इच्छित फ़ॉन्ट निर्दिष्ट करने के लिए [setDefaultAsianFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) का उपयोग करें। निम्न उदाहरण में भी Wingdings उपयोग किया गया है।  
4. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) का उपयोग करके लोड विकल्पों के साथ प्रस्तुति लोड करें।  
5. परिणाम सत्यापित करने के लिए स्लाइड थंबनेल, PDF और XPS उत्पन्न करें।

निम्न उदाहरण इन चरणों को लागू करता है:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# डिफ़ॉल्ट रेग्युलर और एशियाई फ़ॉन्ट निर्धारित करने के लिए लोड विकल्पों का उपयोग करें।
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# प्रस्तुति लोड करें।
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # एक स्लाइड थंबनेल बनाएं।
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # इमेज को डिस्क पर सहेजें।
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # एक PDF बनाएं।
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # एक XPS दस्तावेज़ बनाएं।
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**डिफ़ॉल्ट रेग्युलर और एशियाई फ़ॉन्ट वास्तव में क्या प्रभावित करते हैं—केवल एक्सपोर्ट, या थंबनेल, PDF, XPS, HTML, और SVG भी?**

वे सभी समर्थित आउटपुट के रेंडरिंग पाइपलाइन में भाग लेते हैं। इसमें स्लाइड थंबनेल, [PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/hi/python-java/convert-powerpoint-to-xps/), [रास्टर इमेजेस](/slides/hi/python-java/convert-powerpoint-to-png/), [HTML](/slides/hi/python-java/convert-powerpoint-to-html/), और [SVG](/slides/hi/python-java/render-a-slide-as-an-svg-image/) शामिल हैं, क्योंकि Aspose.Slides इन टारगेट्स में समान लेआउट और ग्लिफ़ रिज़ॉल्यूशन लॉजिक का उपयोग करता है।

**क्या डिफ़ॉल्ट फ़ॉन्ट केवल पढ़ने और PPTX को बिना किसी रेंडरिंग के सेव करने पर लागू होते हैं?**

नहीं। डिफ़ॉल्ट फ़ॉन्ट तब मायने रखते हैं जब टेक्स्ट को मापना और ड्रॉ करना आवश्यक हो। प्रस्तुति को सीधे ओपन‑सेव करने से संग्रहीत फ़ॉन्ट रन या फाइल की संरचना नहीं बदलती। डिफ़ॉल्ट फ़ॉन्ट उन ऑपरेशनों के दौरान काम आते हैं जो टेक्स्ट को रेंडर या रीफ़्लो करते हैं।

**यदि मैं अपनी फ़ॉन्ट फ़ोल्डर जोड़ता हूँ या मेमोरी से फ़ॉन्ट प्रदान करता हूँ, तो क्या वे डिफ़ॉल्ट फ़ॉन्ट चुनते समय विचार किए जाएँगे?**

हां। [Custom font sources](/slides/hi/python-java/custom-font/) उपलब्ध फ़ॉन्ट परिवारों और ग्लिफ़्स की सूची को विस्तारित करते हैं जिन्हें इंजन उपयोग कर सकता है। डिफ़ॉल्ट फ़ॉन्ट और कोई भी [fallback rules](/slides/hi/python-java/fallback-font/) पहले इन स्रोतों के खिलाफ रिज़ॉल्व करेंगे, जिससे सर्वर और कंटेनर में अधिक विश्वसनीय कवरेज मिलता है।

**क्या डिफ़ॉल्ट फ़ॉन्ट टेक्स्ट मीट्रिक्स (केर्निंग, अडवांस) को प्रभावित करेंगे और consequently लाइन ब्रेक और रैपिंग को?**

हां। फ़ॉन्ट बदलने से ग्लिफ़ मीट्रिक्स बदलते हैं और रेंडरिंग के दौरान लाइन ब्रेक, रैपिंग और पेजिनेशन प्रभावित हो सकता है। लेआउट स्थिरता के लिए, [embed the original fonts](/slides/hi/python-java/embedded-font/) या मेट्रिक रूप से संगत डिफ़ॉल्ट और फ़ॉलबैक परिवार चुनें।

**यदि प्रस्तुति में उपयोग किए गए सभी फ़ॉन्ट एम्बेडेड हों तो डिफ़ॉल्ट फ़ॉन्ट सेट करने का कोई मतलब है?**

अक्सर आवश्यक नहीं होता, क्योंकि [embedded fonts](/slides/hi/python-java/embedded-font/) पहले से ही सुसंगत दिखावट सुनिश्चित करते हैं। डिफ़ॉल्ट फ़ॉन्ट अभी भी एक सुरक्षा जाल के रूप में मदद करते हैं जब एम्बेडेड सबसेट द्वारा न कवर किए गए कैरेक्टर हों या फ़ाइल में एम्बेडेड और नॉन‑एम्बेडेड टेक्स्ट का मिश्रण हो।