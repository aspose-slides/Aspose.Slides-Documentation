---
title: जावा में प्रस्तुतियों से Flash ऑब्जेक्ट्स निकालना
linktitle: फ़्लैश
type: docs
weight: 10
url: /hi/java/flash/
keywords:
- Flash निकालें
- Flash ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ जावा में PowerPoint और OpenDocument स्लाइड्स से Flash ऑब्जेक्ट्स निकालने के बारे में जानें, पूर्ण कोड नमूने और सर्वोत्तम प्रथाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों से Flash ऑब्जेक्ट्स निकालने की विधि समझाता है। यह दिखाता है कि कैसे स्लाइड के कंट्रोल्स संग्रह में नाम के आधार पर Flash कंट्रोल खोजें और एम्बेडेड SWF ऑब्जेक्ट डेटा के साथ काम करें।

## **प्रस्तुतियों से Flash ऑब्जेक्ट्स निकालना**

Aspose.Slides for Java प्रस्तुतियों से Flash ऑब्जेक्ट्स निकालने की सुविधा प्रदान करता है। आप नाम के द्वारा Flash कंट्रोल तक पहुंच सकते हैं और इसे प्रस्तुति से निकाल सकते हैं तथा SWF ऑब्जेक्ट डेटा को संग्रहित कर सकते हैं।

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
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

## **अक्सर पूछे जाने वाले प्रश्न**

**Flash सामग्री निकालते समय कौन से प्रस्तुति फ़ॉर्मेट समर्थित हैं?**

[Aspose.Slides supports](/slides/hi/java/supported-file-formats/) मुख्य PowerPoint फ़ॉर्मेट जैसे PPT और PPTX को, क्योंकि यह इन कंटेनरों को लोड कर सकता है और उनके कंट्रोल्स तक पहुंच सकता है, जिसमें Flash से संबंधित ActiveX तत्व शामिल हैं।

**क्या मैं Flash के साथ एक प्रस्तुति को HTML5 में बदल सकता हूँ और Flash इंटरैक्टिविटी को बरकरार रख सकता हूँ?**

नहीं। Aspose.Slides SWF सामग्री को निष्पादित नहीं करता है और न ही उसकी इंटरैक्टिविटी को परिवर्तित करता है। जबकि [HTML](/slides/hi/java/convert-powerpoint-to-html/)/[HTML5](/slides/hi/java/export-to-html5/) में निर्यात को समर्थन है, Flash आधुनिक ब्राउज़रों में समर्थन समाप्त होने के कारण नहीं चल पाएगा। अनुशंसित मार्ग यह है कि निर्यात से पहले Flash को वीडियो या HTML5 एनीमेशन जैसे विकल्पों से बदल दिया जाए।

**सुरक्षा के दृष्टिकोण से, क्या Aspose.Slides प्रस्तुति पढ़ते समय SWF फ़ाइलें चलाता है?**

नहीं। Aspose.Slides Flash को फ़ाइल में एम्बेडेड बाइनरी डेटा के रूप में समझता है और प्रक्रिया के दौरान SWF सामग्री को निष्पादित नहीं करता है।

**मैं उन प्रस्तुतियों को कैसे संभालूँ जिनमें Flash के साथ OLE के माध्यम से अन्य एम्बेडेड फ़ाइलें भी हैं?**

Aspose.Slides [extracting embedded OLE objects](/slides/hi/java/manage-ole/) का समर्थन करता है, इसलिए आप सभी संबंधित एम्बेडेड सामग्री को एक ही पास में प्रोसेस कर सकते हैं, Flash कंट्रोल्स और अन्य OLE-एम्बेडेड दस्तावेज़ों को साथ में संभालते हुए।