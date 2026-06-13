---
title: जावास्क्रिप्ट में प्रस्तुतियों से Flash ऑब्जेक्ट निकालना
linktitle: फ़्लैश
type: docs
weight: 10
url: /hi/nodejs-java/flash/
keywords:
- फ़्लैश निकालें
- फ़्लैश ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides के साथ जावास्क्रिप्ट में PowerPoint और OpenDocument स्लाइड्स से Flash ऑब्जेक्ट निकालने का तरीका सीखें, पूर्ण कोड नमूने और सर्वोत्तम प्रथाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों से Flash ऑब्जेक्ट निकालने का तरीका बताता है। यह दिखाता है कि स्लाइड के controls कलेक्शन में नाम द्वारा Flash नियंत्रण कैसे खोजें और एम्बेडेड SWF ऑब्जेक्ट डेटा के साथ काम करें।

## **प्रेजेंटेशन से Flash ऑब्जेक्ट निकालना**

Aspose.Slides for Node.js via Java एक सुविधा प्रदान करता है जिससे प्रेजेंटेशन से flash ऑब्जेक्ट निकाले जा सकते हैं। आप नाम द्वारा flash नियंत्रण तक पहुँच सकते हैं और प्रेजेंटेशन से इसे निकाल सकते हैं तथा SWF ऑब्जेक्ट डेटा को संग्रहीत कर सकते हैं।

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Flash सामग्री निकालते समय कौन से प्रेजेंटेशन फ़ॉर्मेट समर्थित हैं?**

[Aspose.Slides समर्थन करता है](/slides/hi/nodejs-java/supported-file-formats/) मुख्य PowerPoint फ़ॉर्मेट जैसे PPT और PPTX, क्योंकि यह इन कंटेनरों को लोड कर सकता है और उनके controls तक पहुँच सकता है, जिसमें Flash‑संबंधित ActiveX तत्व शामिल हैं।

**क्या मैं Flash वाले प्रेजेंटेशन को HTML5 में बदल सकता हूँ और Flash इंटरैक्टिविटी को बरकरार रख सकता हूँ?**

नहीं। Aspose.Slides SWF सामग्री को निष्पादित नहीं करता या उसकी इंटरैक्टिविटी को परिवर्तित नहीं करता। जबकि निर्यात को [HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/hi/nodejs-java/export-to-html5/) समर्थन मिलता है, आधुनिक ब्राउज़रों में Flash नहीं चलेगा क्योंकि समर्थन समाप्त हो गया है। अनुशंसित तरीका यह है कि निर्यात से पहले Flash को वीडियो या HTML5 एनीमेशन जैसी वैकल्पिक तकनीकों से बदलें।

**सुरक्षा के दृष्टिकोण से, क्या Aspose.Slides प्रेजेंटेशन पढ़ते समय SWF फ़ाइलें निष्पादित करता है?**

नहीं। Aspose.Slides Flash को फ़ाइल में एम्बेडेड बाइनरी डेटा के रूप में मानता है और प्रोसेसिंग के दौरान SWF सामग्री को निष्पादित नहीं करता।

**जब प्रेजेंटेशन में Flash के साथ OLE द्वारा एम्बेडेड अन्य फ़ाइलें भी हों, तो मुझे कैसे संभालना चाहिए?**

Aspose.Slides [एम्बेडेड OLE ऑब्जेक्ट्स निकालना](/slides/hi/nodejs-java/manage-ole/) को समर्थन करता है, इसलिए आप एक ही पास में सभी संबंधित एम्बेडेड सामग्री को प्रोसेस कर सकते हैं, Flash नियंत्रण और अन्य OLE‑एम्बेडेड दस्तावेज़ों को साथ‑साथ संभालते हुए।