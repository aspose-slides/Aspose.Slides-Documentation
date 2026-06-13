---
title: PHP में प्रस्तुतियों से Flash ऑब्जेक्ट निकालें
linktitle: फ़्लैश
type: docs
weight: 10
url: /hi/php-java/flash/
keywords:
- Flash निकालें
- Flash ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument स्लाइड्स से Flash ऑब्जेक्ट निकालने के तरीके सीखें, पूरे कोड नमूने और सर्वोत्तम प्रथाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों से Flash ऑब्जेक्ट निकालने की प्रक्रिया को समझाता है। यह दिखाता है कि कैसे स्लाइड के नियंत्रण संग्रह में नाम द्वारा Flash नियंत्रण खोजें और एम्बेडेड SWF ऑब्जेक्ट डेटा के साथ काम करें।

## **प्रस्तुतियों से Flash ऑब्जेक्ट निकालना**

Aspose.Slides for PHP via Java प्रस्तुतियों से Flash ऑब्जेक्ट निकालने की सुविधा प्रदान करता है। आप नाम द्वारा Flash नियंत्रण तक पहुँच सकते हैं और उसे प्रस्तुतियों से निकाल सकते हैं तथा SWF ऑब्जेक्ट डेटा को संग्रहीत कर सकते हैं।

```php
  # PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Flash सामग्री निकालते समय कौन से प्रस्तुति फ़ॉर्मेट समर्थित हैं?**

[Aspose.Slides supports](/slides/hi/php-java/supported-file-formats/) मुख्य PowerPoint फ़ॉर्मेट जैसे PPT और PPTX को समर्थन करता है, क्योंकि यह इन कंटेनरों को लोड कर सकता है और उनके नियंत्रणों तक पहुँच सकता है, जिसमें Flash‑संबंधित ActiveX तत्व शामिल हैं।

**क्या मैं Flash के साथ प्रस्तुति को HTML5 में बदल सकता हूँ और Flash इंटरैक्टिविटी को बनाए रख सकता हूँ?**

नहीं। Aspose.Slides SWF सामग्री को निष्पादित नहीं करता है और उसकी इंटरैक्टिविटी को परिवर्तित नहीं करता है। जबकि [HTML](/slides/hi/php-java/convert-powerpoint-to-html/)/[HTML5](/slides/hi/php-java/export-to-html5/) में निर्यात समर्थित है, Flash आधुनिक ब्राउज़रों में समर्थन समाप्त होने के कारण नहीं चलेगा। अनुशंसित तरीका यह है कि निर्यात से पहले Flash को वीडियो या HTML5 एनीमेशन जैसे विकल्पों से बदल दें।

**सुरक्षा के दृष्टिकोण से, क्या Aspose.Slides प्रस्तुति पढ़ते समय SWF फ़ाइलें चलाता है?**

नहीं। Aspose.Slides Flash को फ़ाइल में एम्बेडेड बाइनरी डेटा मानता है और प्रोसेसिंग के दौरान SWF सामग्री को नहीं चलाता है।

**मैं OLE के माध्यम से अन्य एम्बेडेड फ़ाइलों के साथ Flash शामिल करने वाली प्रस्तुतियों को कैसे संभालूँ?**

Aspose.Slides [एम्बेडेड OLE ऑब्जेक्ट्स निकालने](/slides/hi/php-java/manage-ole/) का समर्थन करता है, इसलिए आप एक ही पास में सभी संबंधित एम्बेडेड सामग्री को प्रोसेस कर सकते हैं, जिसमें Flash नियंत्रण और अन्य OLE‑एम्बेडेड दस्तावेज़ साथ में शामिल हैं।