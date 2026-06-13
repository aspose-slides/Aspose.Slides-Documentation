---
title: C++ में प्रस्तुतियों से Flash वस्तुओं को निकालें
linktitle: Flash
type: docs
weight: 10
url: /hi/cpp/flash/
keywords:
- Flash निकालें
- Flash वस्तु
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के साथ C++ में PowerPoint और OpenDocument स्लाइड्स से Flash वस्तुओं को निकालना सीखें, पूर्ण कोड नमूने और सर्वश्रेष्ठ प्रथाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों से Flash वस्तुओं को निकालने के बारे में समझाता है। यह दर्शाता है कि स्लाइड के controls संग्रह में नाम द्वारा Flash नियंत्रण को कैसे खोजें और एम्बेडेड SWF वस्तु डेटा के साथ कैसे कार्य करें।

## **प्रस्तुतियों से Flash वस्तुओं को निकालें**
C++ के लिए Aspose.Slides प्रस्तुति से Flash वस्तुओं को निकालने की सुविधा प्रदान करता है। आप नाम द्वारा Flash नियंत्रण तक पहुँच सकते हैं और इसे प्रस्तुति से निकाल सकते हैं तथा SWF वस्तु डेटा को संग्रहीत कर सकते हैं।

``` cpp
auto pres = System::MakeObject<Presentation>(u"withFlash.pptm");
auto controls = pres->get_Slides()->idx_get(0)->get_Controls();
System::SharedPtr<Control> flashControl;
for (const auto& control : controls)
{
    if (control->get_Name() == u"ShockwaveFlash1")
    {
        flashControl = System::ExplicitCast<Control>(control);
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Flash सामग्री निकालते समय कौन से प्रस्तुति स्वरूप समर्थित हैं?**

[Aspose.Slides समर्थन करता है](/slides/hi/cpp/supported-file-formats/) मुख्य PowerPoint स्वरूप जैसे PPT और PPTX को, क्योंकि यह इन कंटेनरों को लोड कर सकता है और उनके नियंत्रणों तक पहुंच सकता है, जिसमें Flash-संबंधित ActiveX तत्व शामिल हैं।

**क्या मैं Flash के साथ प्रस्तुति को HTML5 में बदल सकता हूँ और Flash इंटरैक्टिविटी को बनाए रख सकता हूँ?**

नहीं। Aspose.Slides SWF सामग्री को निष्पादित नहीं करता है nor उसकी इंटरैक्टिविटी को परिवर्तित करता है। जबकि निर्यात को [HTML](/slides/hi/cpp/convert-powerpoint-to-html/)/[HTML5](/slides/hi/cpp/export-to-html5/) समर्थन मिलता है, Flash आधुनिक ब्राउज़रों में सपोर्ट समाप्त होने के कारण नहीं चलेगा। अनुशंसित उपाय यह है कि निर्यात से पहले Flash को वीडियो या HTML5 एनीमेशन्स जैसे विकल्पों से बदल दिया जाए।

**सुरक्षा के दृष्टिकोण से, क्या Aspose.Slides प्रस्तुति पढ़ते समय SWF फ़ाइलों को निष्पादित करता है?**

नहीं। Aspose.Slides Flash को फ़ाइल में एम्बेडेड बाइनरी डेटा के रूप में मानता है और प्रोसेसिंग के दौरान SWF सामग्री को निष्पादित नहीं करता है।

**मुझे उन प्रस्तुतियों को कैसे संभालना चाहिए जिनमें Flash के साथ अन्य एम्बेडेड फ़ाइलें OLE के माध्यम से शामिल हैं?**

Aspose.Slides [एम्बेडेड OLE ऑब्जेक्ट्स निकालना](/slides/hi/cpp/manage-ole/) का समर्थन करता है, इसलिए आप सभी संबंधित एम्बेडेड सामग्री को एक ही पास में प्रोसेस कर सकते हैं, Flash नियंत्रणों और अन्य OLE-एम्बेडेड दस्तावेज़ों को साथ-साथ संभालते हुए।