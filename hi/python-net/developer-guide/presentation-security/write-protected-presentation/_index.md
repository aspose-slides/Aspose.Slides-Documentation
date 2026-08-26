---
title: Python में प्रस्तुतियों को लिखित-संरक्षण
linktitle: लिखित संरक्षण
type: docs
weight: 25
url: /hi/python-net/write-protected-presentation/
keywords:
- लिखित संरक्षण
- PowerPoint लिखित-संरक्षण
- संशोधित करने हेतु पासवर्ड
- प्रस्तुति संपादन को प्रतिबंधित करें
- लिखित संरक्षण हटाएँ
- संशोधन पासवर्ड सत्यापित करें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python का उपयोग करके PowerPoint PPT और PPTX प्रस्तुतियों में लिखित-संरक्षण पासवर्ड सेट करना, पता लगाना, सत्यापित करना और हटाना।"
---
## **परिचय**

एक लिखित-संरक्षण पासवर्ड प्रस्तुति में संशोधन को प्रतिबंधित करता है लेकिन इसकी सामग्री को एन्क्रिप्ट नहीं करता। उपयोगकर्ता पासवर्ड के बिना लिखित-संरक्षित प्रस्तुति को लोड कर सकते हैं और देख सकते हैं। अनुप्रयोग पर निर्भर करता है, वे सामग्री को संपादित करके अलग नाम से सहेज भी सकते हैं, इसलिए लिखित-संरक्षण को गोपनीयता तंत्र के रूप में नहीं माना जाना चाहिए।

एक खुलने वाला पासवर्ड अलग उद्देश्य रखता है: यह प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री को लोड करने के लिए आवश्यक होता है। प्रस्तुति को एन्क्रिप्ट करने या खुलने वाले पासवर्ड को सत्यापित करने के लिए, देखें [Password-Protect Presentations](/slides/hi/python-net/password-protected-presentation/)।

इस लेख में वर्णित कार्यप्रवाह दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण PPTX फ़ाइलों का उपयोग करते हैं; PPT में सहेजते समय, `.ppt` एक्सटेंशन और संबंधित PPT सहेजने प्रारूप का उपयोग करें।

## **प्रेजेंटेशन पर लिखित-संरक्षण सेट करना**

एक प्रस्तुति को संशोधित करने के लिए पासवर्ड निर्धारित करने हेतु [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/set_write_protection/) का उपयोग करें। प्रस्तुति को सहेजने से सुरक्षा सेटिंग स्थायी हो जाती है।

निम्न उदाहरण PPTX प्रस्तुति पर लिखित-संरक्षण सेट करता है:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **लिखित-संरक्षित प्रस्तुति लोड करना**

क्योंकि लिखित-संरक्षण प्रस्तुति की सामग्री को एन्क्रिप्ट नहीं करता, इसलिए प्रस्तुति को लोड करने के लिए पासवर्ड की आवश्यकता नहीं होती। पासवर्ड केवल संरक्षित प्रस्तुति को संशोधित करने के अधिकार को सत्यापित करते समय ही प्रासंगिक होता है।

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

[LoadOptions.password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/) को लिखित-संरक्षण पासवर्ड न भेजें। यह प्रॉपर्टी एन्क्रिप्टेड सामग्री के लिए खुलने वाला पासवर्ड स्वीकार करती है। यदि किसी प्रस्तुति में दोनों प्रकार की सुरक्षा हो, तो लोड करने के लिए खुलने वाला पासवर्ड प्रदान करें और लिखित-संरक्षण पासवर्ड को अलग से संभालें।

## **प्रेजेंटेशन से लिखित-संरक्षण हटाना**

संशोधन प्रतिबंध को हटाने के लिए [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/remove_write_protection/) का उपयोग करें, फिर प्रस्तुति को सहेजें।

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **जांचें कि प्रस्तुति लिखित-संरक्षित है या नहीं**

फ़ाइल की पूरी [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस बनाए बिना जाँचने के लिए, [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) को कॉल करें और [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/is_write_protected/) का निरीक्षण करें। यह प्रॉपर्टी [NullableBool](https://reference.aspose.com/slides/hi/python-net/aspose.slides/nullablebool/) का उपयोग करती है और जब लिखित-संरक्षण पता चलता है तो `NullableBool.TRUE` लौटाती है।

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) का स्ट्रीम ओवरलोड स्ट्रीम के रूप में प्रदान की गई प्रस्तुति के लिए समान जानकारी देता है।

## **लिखित-संरक्षण पासवर्ड का सत्यापन करें**

पूरा प्रस्तुति लोड किए बिना संशोधन पासवर्ड को सत्यापित करने के लिए [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/check_write_protection/) का उपयोग करें। पहले [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/is_write_protected/) की जाँच करें ताकि एप्लिकेशन केवल तब ही पासवर्ड का अनुरोध या सत्यापन करे जब लिखित-संरक्षण मौजूद हो।

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/check_write_protection/) केवल लिखित-संरक्षण पासवर्ड को सत्यापित करता है। यह खुलने वाले पासवर्ड को सत्यापित नहीं करता या यह निर्धारित नहीं करता कि एन्क्रिप्टेड सामग्री लोड हो सकती है या नहीं। इसके विपरीत, [PresentationInfo.check_password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/check_password/) केवल खुलने वाला पासवर्ड सत्यापित करता है। यदि पूरी प्रस्तुति पहले ही लोड हो चुकी है, तो [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/protectionmanager/check_write_protection/) अपने प्रोटेक्शन मैनेजर के माध्यम से समान लिखित-संरक्षण जांच प्रदान करता है।

उत्पादन अनुप्रयोगों में, पासवर्ड को लॉग न करें या निदान संदेशों में शामिल न करें। अनावश्यक बार-बार सत्यापन प्रयासों से बचें, और पासवर्ड को मेमोरी में केवल आवश्यक समय तक रखें।

{{% alert color="info" title="साथ ही देखें" %}}
- [Password-Protect Presentations](/slides/hi/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/hi/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या लिखित-संरक्षण प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। यह संशोधन को प्रतिबंधित करता है लेकिन प्रस्तुति की सामग्री को लोड करने और देखने के लिए उपलब्ध रखता है।

**क्या प्रस्तुति खोलने के लिए लिखित-संरक्षण पासवर्ड आवश्यक है?**

नहीं। एन्क्रिप्टेड प्रस्तुति सामग्री को लोड करने के लिए केवल एक खुलने वाला पासवर्ड आवश्यक होता है।

**क्या कोई प्रस्तुति दोनों खुलने वाला पासवर्ड और लिखित-संरक्षण पासवर्ड रख सकती है?**

हां। एन्क्रिप्टेड प्रस्तुति खोलने के लिए लोड विकल्पों के माध्यम से खुलने वाला पासवर्ड प्रदान करें, और संशोधन अधिकार की आवश्यकता होने पर लिखित-संरक्षण पासवर्ड को अलग से सत्यापित करें।