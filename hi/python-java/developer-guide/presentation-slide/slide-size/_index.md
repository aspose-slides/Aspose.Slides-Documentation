---
title: Python के माध्यम से Java में प्रस्तुति स्लाइड आकार बदलें
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
- अनन्य स्लाइड आकार
- पूर्ण आकार स्लाइड
- स्क्रीन प्रकार
- स्केल न करें
- फिट सुनिश्चित करें
- अधिकतम करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java और Aspose.Slides का उपयोग करके PPT, PPTX और ODP फ़ाइलों में स्लाइड्स को तेज़ी से री-साइज़ करना सीखें, और किसी भी स्क्रीन के लिए प्रस्तुतियों को बिना गुणवत्ता खोए अनुकूलित करें।"
---
## **परिचय**

Aspose.Slides प्रिंटिंग और स्क्रीन पर प्रदर्शित दोनों के लिए अत्यंत आवश्यक, PowerPoint प्रस्तुतियों में स्लाइड आकार और आस्पेक्ट अनुपात को समायोजित करने के लिए व्यापक उपकरण प्रदान करता है।

प्रचलित स्लाइड आकार और अनुपात:

- **Standard (4:3 Aspect Ratio)**: पुरानी स्क्रीन और उपकरणों के लिए आदर्श।
- **Widescreen (16:9 Aspect Ratio)**: आधुनिक प्रोज़ेक्टर्स और डिस्प्ले के लिए अनुशंसित।

सुनिश्चित करें कि आपकी प्रस्तुति में सभी स्लाइड्स पर एक ही स्लाइड आकार और आस्पेक्ट अनुपात लागू हो, जिससे सुसंगतता बनी रहे। इष्टतम परिणामों के लिए, जटिलताओं से बचने हेतु अपने प्रस्तुति निर्माण प्रक्रिया की शुरुआत में ही स्लाइड आयाम सेट करें।

{{% alert color="info" title="Note" %}}
डिफ़ॉल्ट रूप से, Aspose.Slides द्वारा बनाई गई प्रस्तुतियों में मानक 4:3 आस्पेक्ट अनुपात उपयोग किया जाता है।
{{% /alert %}}

नोट्स और हैंडआउट पेजों का सामान्य स्लाइड्स से अलग आयाम होता है। उनके आकार और अभिविन्यास बदलने के लिए देखें [Notes Page Size](/slides/hi/python-java/notes-size/)।

## **प्रस्तुतियों में स्लाइड आकार बदलें**

यह नमूना कोड आपको Aspose.Slides का उपयोग करके Python via Java में प्रस्तुति के स्लाइड आकार को बदलने का तरीका दिखाता है:

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

## **प्रस्तुतियों में कस्टम स्लाइड आकार निर्दिष्ट करें**

यदि सामान्य स्लाइड आकार (4:3 और 16:9) आपके काम के लिए उपयुक्त नहीं लगते, तो आप विशिष्ट या अनूठा स्लाइड आकार उपयोग करने का विकल्प चुन सकते हैं। उदाहरण के लिए, यदि आप अपनी प्रस्तुति से कस्टम पेज लेआउट पर पूर्ण आकार की स्लाइडें प्रिंट करने या कुछ विशेष स्क्रीन प्रकारों पर प्रस्तुति प्रदर्शित करने की योजना बनाते हैं, तो कस्टम आकार सेटिंग का उपयोग करने से आपको लाभ मिलेगा।

यह नमूना कोड दर्शाता है कि कैसे Aspose.Slides for Python via Java का उपयोग करके प्रस्तुति के लिए कस्टम स्लाइड आकार निर्दिष्ट किया जाता है:

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

## **स्लाइड आकार बदलने के बाद स्लाइड सामग्री को संभालें**

जब आप प्रस्तुति के स्लाइड आकार को बदलते हैं, तो स्लाइड की सामग्री (जैसे चित्र या ऑब्जेक्ट) विकृति हो सकता है। डिफ़ॉल्ट रूप से, ऑब्जेक्ट्स स्वचालित रूप से नए स्लाइड आकार के अनुसार पुनः आकारित हो जाते हैं। हालांकि, प्रस्तुति के स्लाइड आकार को बदलते समय आप ऐसा सेटिंग निर्दिष्ट कर सकते हैं जो तय करता है कि Aspose.Slides स्लाइड की सामग्री को कैसे संभालता है।

आपके इरादे या लक्ष्य के अनुसार, आप इन सेटिंग्स में से किसी का भी उपयोग कर सकते हैं:

- [DoNotScale](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  यदि आप स्लाइड पर ऑब्जेक्ट्स को पुनः आकारित नहीं करना चाहते हैं, तो इस सेटिंग का उपयोग करें।

- [EnsureFit](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  यदि आप छोटे स्लाइड आकार में स्केल करना चाहते हैं और चाहते हैं कि Aspose.Slides स्लाइड के ऑब्जेक्ट्स को नीचे की ओर स्केल करे ताकि सभी स्लाइड पर फिट हो जाएँ (इस प्रकार आप सामग्री खोने से बचते हैं), तो इस सेटिंग का उपयोग करें।

- [Maximize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/#Maximize)

  यदि आप बड़े स्लाइड आकार में स्केल करना चाहते हैं और चाहते हैं कि Aspose.Slides स्लाइड के ऑब्जेक्ट्स को बड़ा करे ताकि वे नए स्लाइड आकार के अनुपात में हो जाएँ, तो इस सेटिंग का उपयोग करें।

यह नमूना कोड दर्शाता है कि प्रस्तुति की स्लाइड का आकार बदलते समय [Maximize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/#Maximize) सेटिंग का उपयोग कैसे किया जाता है:

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

हाँ। Aspose.Slides आंतरिक रूप से पॉइंट्स का उपयोग करता है, जहाँ 1 पॉइंट = 1/72 इंच के बराबर होता है। आप किसी भी इकाई (जैसे मिलीमीटर या सेंटीमीटर) को पॉइंट्स में बदल सकते हैं और परिवर्तित मानों का उपयोग करके स्लाइड की चौड़ाई और ऊँचाई निर्धारित कर सकते हैं।

**क्या बहुत बड़े कस्टम स्लाइड आकार से रेंडरिंग के दौरान प्रदर्शन और मेमोरी उपयोग पर प्रभाव पड़ता है?**

हाँ। बड़े स्लाइड आयाम (पॉइंट्स में) और उच्च रेंडरिंग स्केल मिलकर मेमोरी खपत बढ़ाते हैं और प्रोसेसिंग समय को बढ़ाते हैं। व्यावहारिक स्लाइड आकार का लक्ष्य रखें और इच्छित आउटपुट गुणवत्ता पाने के लिए केवल आवश्यकतानुसार रेंडरिंग स्केल समायोजित करें।

**क्या मैं एक गैर-मानक स्लाइड आकार परिभाषित कर सकता हूँ और फिर विभिन्न आकारों वाली प्रस्तुतियों से स्लाइड्स को मर्ज कर सकता हूँ?**

जब तक प्रस्तुतियों के स्लाइड आकार भिन्न हों, आप [merge presentations](/slides/hi/python-java/merge-presentation/) नहीं कर सकते — पहले, एक प्रस्तुति को अन्य के आकार के अनुसार पुनः आकारित करें। स्लाइड आकार बदलते समय, आप [SlideSizeScaleType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/) विकल्प के माध्यम से मौजूदा सामग्री को कैसे संभालना है चुन सकते हैं। आकारों को समायोजित करने के बाद, आप फ़ॉर्मेटिंग को बनाए रखते हुए स्लाइड्स को मर्ज कर सकते हैं।

**क्या मैं व्यक्तिगत आकारों या स्लाइड के विशिष्ट क्षेत्रों के लिए थंबनेल बना सकता हूँ, और क्या वे नए स्लाइड आकार का सम्मान करेंगे?**

हाँ। Aspose.Slides [entire slides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) के साथ-साथ [selected shapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) के लिए थंबनेल रेंडर कर सकता है। उत्पन्न छवियाँ वर्तमान स्लाइड आकार और आस्पेक्ट अनुपात को प्रतिबिंबित करती हैं, जिससे फ्रेमिंग और ज्यामिति में स्थिरता सुनिश्चित होती है।