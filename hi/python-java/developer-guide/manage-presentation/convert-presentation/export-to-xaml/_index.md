---
title: Python via Java में XAML के लिए प्रस्तुतियों को निर्यात करें
linktitle: प्रस्तुति से XAML
type: docs
weight: 30
url: /hi/python-java/export-to-xaml/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रस्तुति निर्यात
- PowerPoint रूपांतरण
- OpenDocument रूपांतरण
- प्रस्तुति रूपांतरण
- PowerPoint से XAML
- OpenDocument से XAML
- प्रस्तुति से XAML
- PPT से XAML
- PPTX से XAML
- ODP से XAML
- PPT को XAML के रूप में सहेजें
- PPTX को XAML के रूप में सहेजें
- ODP को XAML के रूप में सहेजें
- PPT को XAML में निर्यात करें
- PPTX को XAML में निर्यात करें
- ODP को XAML में निर्यात करें
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों को XAML में निर्यात करें। डिफ़ॉल्ट विकल्पों का उपयोग करें या छिपी हुई स्लाइड्स को शामिल करें।"
---
## **अवलोकन**

यह लेख बताता है कि कैसे Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को XAML में निर्यात किया जा सकता है। यह XAML का परिचय देता है, दिखाता है कि डिफ़ॉल्ट सेटिंग्स के साथ कैसे निर्यात किया जाए, और यह दिखाता है कि छिपी हुई स्लाइड्स को कैसे शामिल किया जाए [XamlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/)।

उदाहरणों को Aspose.Slides for Python via Java और एक संगत Java रनटाइम की आवश्यकता होती है। `pres.pptx` को वर्तमान कार्यशील निर्देशिका में रखें। प्रत्येक उदाहरण केवल तब JVM शुरू करता है जब वह पहले से चल नहीं रहा हो।

## **XAML के बारे में**

XAML (Extensible Application Markup Language) एक XML-आधारित भाषा है जो उपयोगकर्ता इंटरफ़ेस का वर्णन करती है। इसका उपयोग Windows Presentation Foundation (WPF) जैसे फ्रेमवर्क द्वारा किया जाता है। आप XAML को विज़ुअल डिज़ाइनर या टेक्स्ट एडिटर के साथ बना और संपादित कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ प्रस्तुतियों को XAML में निर्यात करना**

इनपुट फ़ाइल से एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) बनाएं, फिर डिफ़ॉल्ट सेटिंग्स के साथ निर्यात करने के लिए [XamlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/) को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) में पास करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **कस्टम विकल्पों के साथ प्रस्तुतियों को XAML में निर्यात करना**

[XamlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/) का उपयोग करके निर्यात को कॉन्फ़िगर करें। छिपी हुई स्लाइड्स को शामिल करने के लिए, सहेजने से पहले `True` के साथ [setExportHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) को कॉल करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**जब मूल फ़ॉन्ट उपलब्ध न हो तो मैं फॉलबैक फ़ॉन्ट कैसे चुन सकता हूँ?**

[setDefaultRegularFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) को अपने [XamlOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/) ऑब्जेक्ट पर उपयोग करके फॉलबैक फ़ॉन्ट निर्दिष्ट करें। सुनिश्चित करें कि चयनित फ़ॉन्ट निर्यात वातावरण में उपलब्ध है।

**क्या मैं निर्यातित मार्कअप को किसी भी XAML फ्रेमवर्क में उपयोग कर सकता हूँ?**

XAML फ्रेमवर्क अपने समर्थित तत्वों और सुविधाओं में विभिन्न होते हैं। अपने लक्षित फ्रेमवर्क में निर्यातित मार्कअप को एक एप्लिकेशन में एकीकृत करने से पहले परीक्षण करें।

**क्या छिपी हुई स्लाइड्स डिफ़ॉल्ट रूप से निर्यात होती हैं?**

नहीं। उन्हें शामिल करने के लिए, [setExportHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) को `True` के साथ कॉल करें। उन्हें बाहर रखने के लिए इसे `False` पर रखें।