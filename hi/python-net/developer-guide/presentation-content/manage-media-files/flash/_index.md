---
title: Python में प्रस्तुतियों से Flash वस्तुओं को निकालें
linktitle: फ़्लैश
type: docs
weight: 10
url: /hi/python-net/flash/
keywords:
- Flash निकालें
- Flash वस्तु
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python में Aspose.Slides के साथ PowerPoint और OpenDocument स्लाइड्स से Flash वस्तुओं को निकालने के लिए सीखें, संपूर्ण कोड नमूने और सर्वोत्तम प्रथाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति से Flash वस्तुओं को निकालने का तरीका समझाता है। यह दिखाता है कि स्लाइड के कंट्रोल्स संग्रह में नाम से Flash कंट्रोल कैसे खोजें और एम्बेडेड SWF ऑब्जेक्ट डेटा के साथ काम करें।

## **प्रस्तुति से Flash वस्तुओं को निकालें**
Aspose.Slides for Python via .NET प्रस्तुति से Flash वस्तुओं को निकालने की सुविधा प्रदान करता है। आप नाम द्वारा Flash कंट्रोल तक पहुंच सकते हैं और इसे प्रस्तुति से निकाल सकते हैं, साथ ही SWF ऑब्जेक्ट डेटा को संग्रहित कर सकते हैं।

```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```

## **अक्सर पूछे जाने वाले प्रश्न**

**जब Flash सामग्री निकाली जाती है तो कौन से प्रस्तुति फॉर्मेट समर्थित हैं?**

[Aspose.Slides समर्थन करता है](/slides/hi/python-net/supported-file-formats/) मुख्य PowerPoint फॉर्मेट जैसे PPT और PPTX, क्योंकि यह इन कंटेनरों को लोड कर सकता है और उनके कंट्रोल्स तक पहुंच सकता है, जिसमें Flash‑संबंधित ActiveX तत्व शामिल हैं।

**क्या मैं Flash वाले प्रस्तुति को HTML5 में बदल सकता हूँ और Flash की इंटरैक्टिविटी को बनाए रख सकता हूँ?**

नहीं। Aspose.Slides SWF सामग्री को निष्पादित नहीं करता और उसकी इंटरैक्टिविटी को नहीं बदलता। जबकि [HTML](/slides/hi/python-net/convert-powerpoint-to-html/)/[HTML5](/slides/hi/python-net/export-to-html5/) निर्यात समर्थित है, आधुनिक ब्राउज़रों में Flash नहीं चलेगा क्योंकि उसका समर्थन समाप्त हो चुका है। अनुशंसित तरीका यह है कि निर्यात से पहले Flash को वीडियो या HTML5 एनीमेशन जैसे विकल्पों से बदल दें।

**सुरक्षा के दृष्टिकोण से, क्या Aspose.Slides प्रस्तुति पढ़ते समय SWF फ़ाइलों को चलाता है?**

नहीं। Aspose.Slides Flash को फ़ाइल में एम्बेडेड बाइनरी डेटा के रूप में मानता है और प्रक्रिया के दौरान SWF सामग्री को नहीं चलाता।

**मैं उन प्रस्तुतियों को कैसे संभालूँ जिनमें Flash के साथ अन्य एम्बेडेड फ़ाइलें OLE के माध्यम से भी हों?**

Aspose.Slides [एम्बेडेड OLE ऑब्जेक्ट्स निकालने](/slides/hi/python-net/manage-ole/) का समर्थन करता है, इसलिए आप सभी संबंधित एम्बेडेड सामग्री को एक ही पास में प्रोसेस कर सकते हैं, जिसमें Flash कंट्रोल और अन्य OLE‑एम्बेडेड दस्तावेज़ शामिल हैं।