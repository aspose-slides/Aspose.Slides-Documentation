---
title: Python में प्रस्तुतियों से Flash ऑब्जेक्ट निकालना
linktitle: Flash
type: docs
weight: 10
url: /hi/python-java/flash/
keywords:
- Flash निकालें
- Flash ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में PowerPoint और OpenDocument स्लाइड्स से Flash ऑब्जेक्ट निकालने के तरीके सीखें, पूर्ण कोड नमूने और सर्वोत्तम अभ्यास।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों से Flash ऑब्जेक्ट निकालने की प्रक्रिया समझाता है। यह दर्शाता है कि स्लाइड के नियंत्रण संग्रह में नाम द्वारा Flash नियंत्रण कैसे पाया जाए और एम्बेडेड SWF ऑब्जेक्ट डेटा के साथ कैसे काम किया जाए।

## **प्रस्तुतियों से Flash ऑब्जेक्ट निकालना**

Aspose.Slides for Python via Java प्रस्तुतियों से Flash ऑब्जेक्ट निकालने की सुविधा प्रदान करता है। आप नाम द्वारा Flash नियंत्रण तक पहुँच सकते हैं और प्रस्तुतियों से इसे निकाल सकते हैं, जिसमें संग्रहीत SWF ऑब्जेक्ट डेटा भी शामिल है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
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

**Flash सामग्री निकालते समय कौन से प्रस्तुति प्रारूप समर्थित हैं?**

[Aspose.Slides supports](/slides/hi/python-java/supported-file-formats/) मुख्य PowerPoint फ़ॉर्मेट जैसे PPT और PPTX को, क्योंकि यह इन कंटेनरों को लोड कर सकता है और उनके नियंत्रणों तक पहुँच सकता है, जिसमें Flash‑संबंधित ActiveX तत्व शामिल हैं।

**क्या मैं Flash के साथ प्रस्तुति को HTML5 में बदल सकता हूं और Flash इंटरैक्टिविटी को बनाए रख सकता हूं?**

नहीं। Aspose.Slides SWF सामग्री को निष्पादित नहीं करता है nor उसकी इंटरैक्टिविटी को बदलता है। जबकि [HTML](/slides/hi/python-java/convert-powerpoint-to-html/)/[HTML5](/slides/hi/python-java/export-to-html5/) में निर्यात का समर्थन है, Flash आधुनिक ब्राउज़रों में समर्थन समाप्त होने के कारण नहीं चलेगा। अनुशंसित तरीका यह है कि निर्यात से पहले Flash को वीडियो या HTML5 एनीमेशन जैसी वैकल्पिक विकल्पों से बदल दें।

**सुरक्षा के दृष्टिकोण से, क्या Aspose.Slides प्रस्तुति पढ़ते समय SWF फ़ाइलें निष्पादित करता है?**

नहीं। Aspose.Slides Flash को फ़ाइल में एम्बेडेड बाइनरी डेटा मानता है और प्रोसेसिंग के दौरान SWF सामग्री को निष्पादित नहीं करता है।

**मैं उन प्रस्तुतियों को कैसे संभालूं जिनमें Flash के साथ OLE के माध्यम से अन्य एम्बेडेड फ़ाइलें भी हों?**

Aspose.Slides [extracting embedded OLE objects](/slides/hi/python-java/manage-ole/) का समर्थन करता है, इसलिए आप एक ही पास में सभी संबंधित एम्बेडेड सामग्री को प्रोसेस कर सकते हैं, जिसमें Flash नियंत्रण और अन्य OLE‑एम्बेडेड दस्तावेज़ एक साथ संभाले जा सकते हैं।