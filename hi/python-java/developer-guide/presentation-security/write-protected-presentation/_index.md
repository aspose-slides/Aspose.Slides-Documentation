---
title: Python में प्रस्तुतियों को लिखने‑संरक्षित करें
linktitle: लिखने‑संरक्षण
type: docs
weight: 25
url: /hi/python-java/write-protected-presentation/
keywords:
- लिखने‑संरक्षण
- PowerPoint को लिखने‑संरक्षित करें
- संशोधन के लिए पासवर्ड
- प्रस्तुति संपादन को प्रतिबंधित करें
- लिखने‑संरक्षण हटाएँ
- संशोधन पासवर्ड को मान्य करें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint PPT और PPTX प्रस्तुतियों में लिखने‑संरक्षण पासवर्ड सेट करें, पहचानें, मान्य करें और हटाएँ।"
---
## **परिचय**

लिखने‑संरक्षण पासवर्ड प्रस्तुति में संशोधन को सीमित करता है, लेकिन इसकी सामग्री को एन्क्रिप्ट नहीं करता है। उपयोगकर्ता लिखने‑संरक्षित प्रस्तुति को पासवर्ड के बिना लोड और देख सकते हैं। एप्लिकेशन के आधार पर, वे सामग्री को संपादित कर सकते हैं और इसे अलग नाम से सहेज सकते हैं, इसलिए लिखने‑संरक्षण को गोपनीयता तंत्र के रूप में नहीं माना जाना चाहिए।

एक ओपनिंग पासवर्ड का उद्देश्य अलग है: यह प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री को लोड करने के लिए आवश्यक होता है। प्रेज़ेंटेशन को एन्क्रिप्ट करने या ओपनिंग पासवर्ड को मान्य करने के लिए, देखें [Password-Protect Presentations](/slides/hi/python-java/password-protected-presentation/)।

इस लेख में वर्णित वर्कफ़्लो PPT और PPTX दोनों प्रकार की प्रस्तुतियों पर लागू होते हैं। उदाहरण PPTX फ़ाइलों का उपयोग करते हैं; PPT में सहेजते समय, `.ppt` एक्सटेंशन और संबंधित PPT सहेजने के फ़ॉर्मेट का उपयोग करें।

## **प्रेज़ेंटेशन पर लिखने‑संरक्षण सेट करें**

प्रेज़ेंटेशन को संशोधित करने के लिए पासवर्ड निर्धारित करने हेतु [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/protectionmanager/#setWriteProtection) का उपयोग करें। प्रेज़ेंटेशन को सहेजने से संरक्षा सेटिंग कायम रहती है।

निम्न उदाहरण PPTX प्रेज़ेंटेशन पर लिखने‑संरक्षण सेट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लिखने‑संरक्षित प्रेज़ेंटेशन लोड करें**

क्योंकि लिखने‑संरक्षण प्रेज़ेंटेशन की सामग्री को एन्क्रिप्ट नहीं करता, इसलिए प्रेज़ेंटेशन लोड करने के लिए कोई पासवर्ड आवश्यक नहीं है। पासवर्ड केवल तब प्रासंगिक होता है जब संरक्षित प्रेज़ेंटेशन को संशोधित करने की अधिकारिता की जाँच की जाती है।

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

लिखने‑संरक्षण पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setPassword) में पास न करें। यह मेथड एन्क्रिप्टेड सामग्री के लिए ओपनिंग पासवर्ड स्वीकार करता है। यदि प्रेज़ेंटेशन में दोनों प्रकार की सुरक्षा है, तो उसे लोड करने के लिए ओपनिंग पासवर्ड प्रदान करें और लिखने‑संरक्षण पासवर्ड को अलग से संभालें।

## **प्रेज़ेंटेशन से लिखने‑संरक्षण हटाएँ**

संशोधन प्रतिबंध को हटाने के लिए [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/protectionmanager/#removeWriteProtection) का उपयोग करें, फिर प्रेज़ेंटेशन को सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **जाँचें कि प्रेज़ेंटेशन लिखने‑संरक्षित है या नहीं**

पूर्ण [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस बनाए बिना फ़ाइल की जाँच करने के लिए, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) को कॉल करें और [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#isWriteProtected) को निरीक्षण करें। यह मेथड [NullableBool](https://reference.aspose.com/slides/hi/python-java/aspose.slides/nullablebool/) का उपयोग करता है और लिखने‑संरक्षण मिलने पर `NullableBool.True_` लौटाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) का स्ट्रीम ओवरलोड उन प्रस्तुतियों के लिए भी वही जानकारी प्रदान करता है जो स्ट्रीम के रूप में उपलब्ध कराई गई हों।

## **लिखने‑संरक्षण पासवर्ड को मान्य करें**

पूर्ण प्रेज़ेंटेशन लोड किए बिना संशोधन पासवर्ड को मान्य करने हेतु [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#checkWriteProtection) का उपयोग करें। पासवर्ड अनुरोधित या मान्य करने से पहले [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#isWriteProtected) की जाँच करें, ताकि एप्लिकेशन केवल लिखने‑संरक्षण मौजूद होने पर ही पासवर्ड मांगे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#checkWriteProtection) केवल लिखने‑संरक्षण पासवर्ड को मान्य करता है। यह ओपनिंग पासवर्ड को मान्य नहीं करता या यह निर्धारण नहीं करता कि एन्क्रिप्टेड सामग्री लोड की जा सकती है या नहीं। विपरीत रूप में, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#checkPassword) केवल ओपनिंग पासवर्ड को मान्य करता है। यदि पूर्ण प्रेज़ेंटेशन पहले ही लोड हो चुका है, तो [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/protectionmanager/#checkWriteProtection) अपने प्रोटेक्शन मैनेजर के माध्यम से समान लिखने‑संरक्षण जाँच प्रदान करता है।

प्रोडक्शन एप्लिकेशनों में पासवर्ड को लॉग न करें या डायग्नोस्टिक संदेशों में न शामिल करें। अनावश्यक दोहराव वाली मान्यताओं से बचें, और पासवर्ड को मेमोरी में केवल आवश्यक समय तक रखें।

{{% alert color="info" title="संबंधित" %}}
- [Password-Protect Presentations](/slides/hi/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/hi/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या लिखने‑संरक्षण प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। यह संशोधन को सीमित करता है लेकिन प्रस्तुति की सामग्री को लोड और देखने के लिये उपलब्ध रखता है।

**क्या प्रेज़ेंटेशन खोलने के लिये लिखने‑संरक्षण पासवर्ड आवश्यक है?**

नहीं। केवल एन्क्रिप्टेड प्रेज़ेंटेशन सामग्री को लोड करने के लिये ओपनिंग पासवर्ड आवश्यक है।

**क्या एक प्रेज़ेंटेशन में ओपनिंग पासवर्ड और लिखने‑संरक्षण पासवर्ड दोनों हो सकते हैं?**

हां। एन्क्रिप्टेड प्रेज़ेंटेशन को खोलने के लिये लोड विकल्पों के माध्यम से ओपनिंग पासवर्ड प्रदान करें, और संशोधन अधिकारिता की आवश्यकता होने पर लिखने‑संरक्षण पासवर्ड को अलग से मान्य करें।