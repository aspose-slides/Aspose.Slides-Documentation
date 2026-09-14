---
title: Python का उपयोग करके रीड-ओनली मोड में प्रस्तुतियों को सहेजें
linktitle: रीड-ओनली प्रस्तुति
type: docs
weight: 30
url: /hi/python-java/read-only-presentation/
keywords:
- केवल पढ़ने योग्य
- प्रस्तुति सुरक्षा
- संपादन रोकें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ रीड-ओनली मोड में PowerPoint फ़ाइलें (PPT, PPTX) लोड और सहेजें, जिससे आपकी प्रस्तुतियों को बदले बिना सटीक स्लाइड प्रीव्यू प्राप्त होते हैं।"
---
## **परिचय**

PowerPoint 2019 में, Microsoft ने **Always Open Read-Only** सेटिंग को परिचय किया, जिसे उपयोगकर्ता अपनी प्रस्तुतियों को सुरक्षित रखने के लिए उपयोग कर सकते हैं। आप इस Read-Only सेटिंग का उपयोग तब कर सकते हैं जब:

- आप अनजाने में होने वाले संपादन को रोकना चाहते हैं और अपनी प्रस्तुति की अभिग्य सामग्री सुरक्षित रखना चाहते हैं।  
- आप दर्शकों को सूचित करना चाहते हैं कि आप द्वारा दी गई प्रस्तुति अंतिम संस्करण है।  

जब आप किसी प्रस्तुति के लिए **Always Open Read-Only** विकल्प चुनते हैं, तो उपयोगकर्ता प्रस्तुति खोलते समय **Read-Only** अनुशंसा देखते हैं और इस प्रकार का संदेश देख सकते हैं: *अनजाने में बदलाव को रोकने के लिए, लेखक ने इस फ़ाइल को पढ़ने‑के‑लिए खोलने के रूप में सेट किया है।*

Read-Only अनुशंसा एक सरल लेकिन प्रभावी रोक है जो उपयोगकर्ताओं को प्रस्तुति को संपादित करने से पहले इसे हटाने का कार्य करने के लिए बाध्य करती है। यदि आप चाहते हैं कि उपयोगकर्ता प्रस्तुति में परिवर्तन न करें और इसे विनम्रता से सूचित करना चाहते हैं, तो Read-Only अनुशंसा आपके लिए एक अच्छा विकल्प हो सकता है।

> यदि **Read-Only** सुरक्षा के साथ कोई प्रस्तुति पुराने Microsoft PowerPoint एप्लिकेशन में खोली जाती है—जो हाल ही में प्रस्तुत की गई कार्यक्षमता का समर्थन नहीं करता—तो **Read-Only** अनुशंसा को नज़रअंदाज़ किया जाता है (प्रस्तुति सामान्य रूप से खुलती है)।

## **Read-Only मोड लागू करें**

Aspose.Slides for Python via Java आपको प्रस्तुति को **Read-Only** सेट करने की अनुमति देता है, जिसका अर्थ है कि उपयोगकर्ता (प्रस्तुति खोलने के बाद) **Read-Only** अनुशंसा देखते हैं। यह नमूना कोड आपको दिखाता है कि Python में Aspose.Slides का उपयोग करके प्रस्तुति को **Read-Only** कैसे सेट करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

**Read-Only** अनुशंसा केवल संपादन को हतोत्साहित करने या उपयोगकर्ताओं को अनजाने बदलाव करने से रोकने के लिये है। यदि कोई प्रेरित व्यक्ति—जो अपने काम को जानता है—आपकी प्रस्तुति को संपादित करने का निर्णय लेता है, तो वह आसानी से Read-Only सेटिंग को हटा सकता है। यदि आपको अनधिकृत संपादन को गंभीरता से रोकना है, तो आप [more stringent protections that involve encryption and passwords](/slides/hi/python-java/password-protected-presentation/) का उपयोग करना बेहतर रहेगा। 

{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**'Read-Only recommended' पूर्ण पासवर्ड सुरक्षा से कैसे अलग है?**  
'Read-Only recommended' केवल फ़ाइल को रीड‑ओनली मोड में खोलने का सुझाव देता है और इसे बायपास करना आसान है। [Password protection](/slides/hi/python-java/password-protected-presentation/) वास्तव में खोलने या संपादित करने पर प्रतिबंध लगाता है और वास्तविक सुरक्षा नियंत्रण की आवश्यकता होने पर उपयुक्त है।  

**क्या 'Read-Only recommended' को वॉटरमार्क के साथ मिलाकर और अधिक संपादन रोक सकते हैं?**  
हां। इस अनुशंसा को [watermarks](/slides/hi/python-java/watermark/) के साथ जोड़ा जा सकता है ताकि एक दृश्य हतोत्साहक प्रदान किया जा सके; ये अलग‑अलग तंत्र हैं और साथ में अच्छी तरह काम करते हैं।  

**क्या मैक्रो या बाहरी टूल अभी भी फ़ाइल में बदलाव कर सकता है जब अनुशंसा सक्षम हो?**  
हां। अनुशंसा प्रोग्रामेटिक बदलावों को रोकती नहीं है। स्वचालित संपादन को रोकने के लिए आप [passwords and encryption](/slides/hi/python-java/password-protected-presentation/) का उपयोग करें।  

**'Read-Only recommended' का संबंध [isEncrypted](https://reference.aspose.com/slides/hi/python-java/aspose.slides/protectionmanager/#isEncrypted) और [isWriteProtected](https://reference.aspose.com/slides/hi/python-java/aspose.slides/protectionmanager/#isWriteProtected) विधियों से कैसे है?**  
ये अलग संकेत हैं। 'Read-Only recommended' एक नरम, वैकल्पिक प्रॉम्प्ट है; [isWriteProtected](https://reference.aspose.com/slides/hi/python-java/aspose.slides/protectionmanager/#isWriteProtected) और [isEncrypted](https://reference.aspose.com/slides/hi/python-java/aspose.slides/protectionmanager/#isEncrypted) वास्तविक लिखने या पढ़ने की प्रतिबंध दर्शाते हैं जो पासवर्ड या एन्क्रिप्शन पर निर्भर होते हैं।