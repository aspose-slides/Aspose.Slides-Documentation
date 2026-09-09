---
title: "Python में प्रस्तुतियों से Flash ऑब्जेक्ट निकालें"
linktitle: "Flash"
type: docs
weight: 10
url: /hi/python-java/flash/
keywords:
- "Flash निकालें"
- "Flash ऑब्जेक्ट"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Python में Aspose.Slides के साथ PowerPoint और OpenDocument स्लाइड्स से Flash ऑब्जेक्ट निकालने का तरीका सीखें, पूर्ण कोड उदाहरण और सर्वोत्तम अभ्यास।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों से फ्लैश ऑब्जेक्ट निकालने के तरीके को समझाता है। यह दिखाता है कि कैसे स्लाइड के कंट्रोल्स संग्रह में नाम द्वारा फ्लैश कंट्रोल खोजा जाए और एम्बेडेड SWF ऑब्जेक्ट डेटा के साथ काम किया जाए।

## **प्रस्तुतियों से फ्लैश ऑब्जेक्ट निकालना**

Aspose.Slides for Python via Java प्रस्तुतियों से फ्लैश ऑब्जेक्ट निकालने की सुविधा प्रदान करता है। आप नाम द्वारा फ्लैश कंट्रोल तक पहुँच सकते हैं और इसे प्रस्तुतियों से निकाल सकते हैं, जिसमें संग्रहीत SWF ऑब्जेक्ट डेटा भी शामिल है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# PPTX का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
presentation = Presentation()
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    flash_control = None
    for control in controls:
        if control.getName() == "ShockwaveFlash1":
            flash_control = control
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़्लैश सामग्री निकालते समय किन प्रस्तुति स्वरूपों का समर्थन किया जाता है?**

[Aspose.Slides समर्थन करता है](/slides/hi/python-java/supported-file-formats/) मुख्य PowerPoint स्वरूप जैसे PPT और PPTX को, क्योंकि यह इन कंटेनरों को लोड कर सकता है और उनके कंट्रोल्स तक पहुँच सकता है, जिसमें Flash‑संबंधित ActiveX तत्व शामिल हैं।

**क्या मैं फ़्लैश के साथ एक प्रस्तुति को HTML5 में परिवर्तित कर सकता हूँ और फ़्लैश इंटरैक्टिविटी को सुरक्षित रख सकता हूँ?**

नहीं। Aspose.Slides SWF सामग्री को निष्पादित नहीं करता है या उसकी इंटरैक्टिविटी को परिवर्तित नहीं करता है। जबकि [HTML](/slides/hi/python-java/convert-powerpoint-to-html/)/[HTML5](/slides/hi/python-java/export-to-html5/) में निर्यात समर्थन किया जाता है, फ़्लैश आधुनिक ब्राउज़रों में समर्थन समाप्त होने के कारण नहीं चलेगा। अनुशंसित तरीका यह है कि निर्यात से पहले फ़्लैश को वीडियो या HTML5 एनीमेशन जैसे विकल्पों से बदल दिया जाए।

**सुरक्षा के दृष्टिकोण से, क्या Aspose.Slides प्रस्तुति पढ़ते समय SWF फ़ाइलें निष्पादित करता है?**

नहीं। Aspose.Slides फ़्लैश को फ़ाइल में एम्बेडेड बायनरी डेटा के रूप में मानता है और प्रोसेसिंग के दौरान SWF सामग्री को निष्पादित नहीं करता है।

**मुझे OLE के माध्यम से अन्य एम्बेडेड फ़ाइलों के साथ फ़्लैश शामिल करने वाली प्रस्तुतियों को कैसे संभालना चाहिए?**

Aspose.Slides [एम्बेडेड OLE ऑब्जेक्ट निकालना](/slides/hi/python-java/manage-ole/) समर्थन करता है, इसलिए आप सभी संबंधित एम्बेडेड सामग्री को एक ही चरण में प्रोसेस कर सकते हैं, फ़्लैश कंट्रोल और अन्य OLE‑एम्बेडेड दस्तावेज़ों को एक साथ संभालते हुए।