---
title: Android पर प्रस्तुतियों से फ़्लैश ऑब्जेक्ट निकालना
linktitle: फ़्लैश
type: docs
weight: 10
url: /hi/androidjava/flash/
keywords:
- फ़्लैश निकालें
- फ़्लैश ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ Java में PowerPoint और OpenDocument स्लाइड्स से Flash ऑब्जेक्ट निकालना सीखें, पूर्ण कोड नमूने और सर्वोत्तम प्रथाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों से Flash ऑब्जेक्ट को निकालने की प्रक्रिया समझाता है। यह दिखाता है कि स्लाइड के controls collection में नाम द्वारा Flash नियंत्रण कैसे खोजें और एंबेडेड SWF ऑब्जेक्ट डेटा के साथ कैसे काम करें।

## **प्रस्तुति से Flash ऑब्जेक्ट निकालना**

Aspose.Slides for Android via Java एक सुविधा प्रदान करता है जिससे आप प्रस्तुति से Flash ऑब्जेक्ट निकाल सकते हैं। आप नाम द्वारा Flash नियंत्रण तक पहुँच सकते हैं और उसे प्रस्तुति से निकाल सकते हैं तथा SWF ऑब्जेक्ट डेटा को संग्रहीत कर सकते हैं।

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को instantiate करें
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Flash सामग्री निकालते समय किस प्रस्तुति प्रारूप का समर्थन किया जाता है?**

[Aspose.Slides समर्थन करता है](/slides/hi/androidjava/supported-file-formats/) मुख्य PowerPoint प्रारूप जैसे PPT और PPTX को, क्योंकि यह इन कंटेनरों को लोड कर सकता है और उनके controls तक पहुँच सकता है, जिसमें Flash-संबंधित ActiveX तत्व शामिल हैं।

**क्या मैं Flash के साथ एक प्रस्तुति को HTML5 में परिवर्तित कर सकता हूँ और Flash इंटरैक्टिविटी को बनाए रख सकता हूँ?**

नहीं। Aspose.Slides SWF सामग्री को निष्पादित नहीं करता या उसकी इंटरैक्टिविटी को परिवर्तित नहीं करता। जबकि [HTML](/slides/hi/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/hi/androidjava/export-to-html5/) निर्यात का समर्थन किया जाता है, Flash आधुनिक ब्राउज़रों में समर्थन समाप्त होने के कारण चल नहीं पाएगा। अनुशंसित उपाय है कि निर्यात से पहले Flash को वीडियो या HTML5 एनीमेशन जैसे विकल्पों से बदल दिया जाए।

**सुरक्षा के दृष्टिकोण से, क्या Aspose.Slides प्रस्तुति पढ़ते समय SWF फ़ाइलों को निष्पादित करता है?**

नहीं। Aspose.Slides Flash को फ़ाइल में एंबेडेड बाइनरी डेटा के रूप में मानता है और प्रसंस्करण के दौरान SWF सामग्री को निष्पादित नहीं करता।

**मैं उन प्रस्तुतियों को कैसे संभालूं जिनमें Flash के साथ अन्य एंबेडेड फ़ाइलें OLE के माध्यम से शामिल हैं?**

Aspose.Slides [एम्बेडेड OLE ऑब्जेक्ट निकालना](/slides/hi/androidjava/manage-ole/) का समर्थन करता है, जिससे आप एक ही चरण में सभी संबंधित एंबेडेड सामग्री को प्रोसेस कर सकते हैं, Flash नियंत्रण और अन्य OLE-एंबेडेड दस्तावेज़ों को साथ में संभालते हुए।