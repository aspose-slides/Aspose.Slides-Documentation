---
title: Python के द्वारा Java में प्रस्तुति स्लाइड आकार बदलें
linktitle: स्लाइड आकार
type: docs
weight: 70
url: /hi/python-java/slide-size/
keywords:
- स्लाइड आकार
- आस्पेक्ट अनुपात
- मानक
- वाइडस्क्रीन
- 4:3
- 16:9
- स्लाइड आकार सेट करें
- स्लाइड आकार बदलें
- कस्टम स्लाइड आकार
- विशेष स्लाइड आकार
- अद्वितीय स्लाइड आकार
- पूर्ण आकार स्लाइड
- स्क्रीन प्रकार
- स्केल न करें
- फ़िट सुनिश्चित करें
- अधिकतम करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java और Aspose.Slides का उपयोग करके PPT, PPTX और ODP फ़ाइलों में स्लाइडों को जल्दी से पुन: आकार देना सीखें, और किसी भी स्क्रीन के लिए प्रस्तुतियों को गुणवत्ता खोए बिना अनुकूलित करें।"
---
## **परिचय**

Aspose.Slides पावरपॉइंट प्रस्तुतियों में स्लाइड आकार और अनुपात को समायोजित करने के लिए व्यापक उपकरण प्रदान करता है, जो प्रिंटिंग और स्क्रीन पर प्रदर्शित करने दोनों के लिए महत्वपूर्ण है।

लोकप्रिय स्लाइड आकार और अनुपात:

- **मानक (4:3 अनुपात)**: पुराने स्क्रीन और उपकरणों के लिए आदर्श।
- **वाइडस्क्रीन (16:9 अनुपात)**: आधुनिक प्रोजेक्टरों और डिस्प्ले के लिए अनुशंसित।

अपनी प्रस्तुति में सभी स्लाइडों पर एकल स्लाइड आकार और अनुपात लागू करके सुसंगतता सुनिश्चित करें। सर्वोत्तम परिणामों के लिए, प्रस्तुति बनाने की प्रक्रिया की शुरुआत में ही स्लाइड आयाम निर्धारित करें ताकि जटिलताएँ न हों।

{{% alert color="info" title="Note" %}}
डिफ़ॉल्ट रूप से, Aspose.Slides के साथ बनाई गई प्रस्तुतियों में मानक 4:3 अनुपात उपयोग होता है।
{{% /alert %}}

## **प्रस्तुतियों में स्लाइड आकार बदलें**

यह नमूना कोड दिखाता है कि Python via Java का उपयोग करके Aspose.Slides के साथ प्रस्तुति में स्लाइड आकार कैसे बदलें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **प्रस्तुतियों में अनुकूलित स्लाइड आकार निर्दिष्ट करें**

यदि सामान्य स्लाइड आकार (4:3 और 16:9) आपके काम के लिए उपयुक्त नहीं हैं, तो आप विशेष या अद्वितीय स्लाइड आकार का उपयोग करने का फैसला कर सकते हैं। उदाहरण के लिए, यदि आप अपनी प्रस्तुति के पूर्ण आकार वाली स्लाइडें किसी कस्टम पेज लेआउट पर प्रिंट करना चाहते हैं या कुछ प्रकार की स्क्रीन पर प्रदर्शित करना चाहते हैं, तो अनुकूलित आकार सेटिंग का उपयोग करना लाभदायक रहेगा।

यह नमूना कोड दिखाता है कि Python via Java के साथ Aspose.Slides का उपयोग करके प्रस्तुति के लिए अनुकूलित स्लाइड आकार कैसे निर्दिष्ट करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **आकार बदलने के बाद स्लाइड सामग्री को संभालें**

जब आप किसी प्रस्तुति के स्लाइड आकार को बदलते हैं, तो स्लाइड की सामग्री (जैसे छवियां या ऑब्जेक्ट) विकृत हो सकती है। डिफ़ॉल्ट रूप से, ऑब्जेक्ट स्वचालित रूप से नए स्लाइड आकार में फिट होने के लिए पुन: आकारित हो जाते हैं। हालांकि, प्रस्तुति का स्लाइड आकार बदलते समय आप एक सेटिंग निर्दिष्ट कर सकते हैं जो निर्धारित करती है कि Aspose.Slides स्लाइडों की सामग्री को कैसे संभालता है।

आपकी इच्छित कार्य या परिणाम के आधार पर आप निम्नलिखित सेटिंग्स में से कोई भी उपयोग कर सकते हैं:

- [DoNotScale](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  यदि आप स्लाइडों पर ऑब्जेक्ट को पुन: आकारित नहीं करना चाहते, तो इस सेटिंग का उपयोग करें।

- [EnsureFit](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  यदि आप छोटे स्लाइड आकार पर स्केल करना चाहते हैं और चाहते हैं कि Aspose.Slides स्लाइडों के सभी ऑब्जेक्ट को छोटा करके फिट कर दे (इस तरह आप सामग्री खोने से बचते हैं), तो इस सेटिंग का उपयोग करें।

- [Maximize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/#Maximize)

  यदि आप बड़े स्लाइड आकार पर स्केल करना चाहते हैं और चाहते हैं कि Aspose.Slides स्लाइडों के ऑब्जेक्ट को बड़ा करके नए स्लाइड आकार के अनुपात में लाए, तो इस सेटिंग का उपयोग करें।

यह नमूना कोड दिखाता है कि प्रस्तुति के स्लाइड आकार को बदलते समय [Maximize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/#Maximize) सेटिंग का कैसे उपयोग करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं इंच के अलावा अन्य इकाइयों (जैसे पॉइंट या मिलीमीटर) का उपयोग करके कस्टम स्लाइड आकार सेट कर सकता हूँ?**

हां। Aspose.Slides आंतरिक रूप से पॉइंट्स का उपयोग करता है, जहाँ 1 पॉइंट = 1/72 इंच के बराबर होता है। आप किसी भी इकाई (जैसे मिलीमीटर या सेंटीमीटर) को पॉइंट्स में परिवर्तित कर सकते हैं और परिवर्तित मानों का उपयोग स्लाइड की चौड़ाई और ऊंचाई निर्धारित करने के लिए कर सकते हैं।

**क्या बहुत बड़ा कस्टम स्लाइड आकार रेंडरिंग के दौरान प्रदर्शन और मेमोरी उपयोग को प्रभावित करेगा?**

हां। बड़े स्लाइड आयाम (पॉइंट्स में) और उच्च रेंडरिंग स्केल वाली प्रस्तुतियों में मेमोरी खपत और प्रोसेसिंग समय बढ़ जाता है। व्यावहारिक स्लाइड आकार चुनें और केवल आवश्यक होने पर रेंडरिंग स्केल को समायोजित करें ताकि वांछित आउटपुट गुणवत्ता प्राप्त हो सके।

**क्या मैं एक गैर-मानक स्लाइड आकार परिभाषित करके फिर विभिन्न आकारों वाली प्रस्तुतियों से स्लाइड्स को मर्ज कर सकता हूँ?**

आप अलग-अलग स्लाइड आकार वाली प्रस्तुतियों को [merge presentations](/slides/hi/python-java/merge-presentation/) नहीं कर सकते — पहले किसी एक प्रस्तुति का आकार दूसरे के साथ मिलाने के लिए बदलें। स्लाइड आकार बदलते समय आप [SlideSizeScaleType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/) विकल्प के माध्यम से मौजूदा सामग्री के संभालने का तरीका चुन सकते हैं। आकार संरेखित करने के बाद, आप फ़ॉर्मेटिंग को बनाए रखते हुए स्लाइड्स को मर्ज कर सकते हैं।

**क्या मैं व्यक्तिगत आकारों या स्लाइड के विशिष्ट क्षेत्रों के थंबनेल बना सकता हूँ, और क्या वे नए स्लाइड आकार का सम्मान करेंगे?**

हां। Aspose.Slides [entire slides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) और [selected shapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) दोनों के थंबनेल रेंडर कर सकता है। प्राप्त छवियां वर्तमान स्लाइड आकार और अनुपात को दर्शाती हैं, जिससे फ्रेमिंग और ज्यामिति में संगतता बनी रहती है।