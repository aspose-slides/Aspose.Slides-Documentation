---
title: सिस्टम आवश्यकताएँ
type: docs
weight: 80
url: /hi/cpp/system-requirements/
keywords:
- सिस्टम आवश्यकताएँ
- ऑपरेटिंग सिस्टम
- स्थापना
- निर्भरताएँ
- विंडोज
- लिनक्स
- macOS
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ की सिस्टम आवश्यकताओं की खोज करें। Windows, Linux और macOS पर पावरपॉइंट और ओपनडॉक्यूमेंट समर्थन को सहज बनाएं।"
---
## **परिचय**

Aspose.Slides को Microsoft PowerPoint स्थापित करने की आवश्यकता नहीं है क्योंकि Aspose.Slides एक स्वतंत्र Microsoft PowerPoint दस्तावेज़ निर्माण, रूपांतरण, पृष्ठ लेआउट और रेंडरिंग इंजन है।

## **समर्थित ऑपरेटिंग सिस्टम**
Aspose.Slides for C++ एक मूल C++ लाइब्रेरी है। Aspose.Slides for C++ निम्नलिखित 64‑बिट और 32‑बिट ऑपरेटिंग सिस्टम और प्लेटफ़ॉर्म का समर्थन करता है:

### **विंडोज**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **लिनक्स**
- OS Ubuntu 16.04 या बाद का।
- CentOS 8 या बाद का।
- Fedora 24 या बाद का।
- और अन्य Linux x86_64 जिसमें glibc 2.23 या बाद का।

### **macOS**
- macOS Monterey 12.1 या बाद का।

## **विकास परिवेश**
आप Windows, Linux या macOS के लिए एप्लिकेशन विकसित करते समय Aspose.Slides for C++ का उपयोग कर सकते हैं।

### **विंडोज**
- Microsoft Visual Studio 2017 या बाद का।
- CMake 3.18 या बाद का।

### **लिनक्स**
- Clang 3.9 या बाद का।
- GCC 6.1 या बाद का।
- CMake 3.18 या बाद का।

### **macOS**
- Xcode 13.4 या बाद का।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे रूपांतरण और रेंडरिंग के लिए Microsoft PowerPoint स्थापित करने की आवश्यकता है?**

नहीं, PowerPoint आवश्यक नहीं है; Aspose.Slides एक स्वतंत्र इंजन है जो प्रस्तुतियों को [बनाना](/slides/hi/cpp/create-presentation/), संशोधित करने, [रूपांतरण](/slides/hi/cpp/convert-presentation/), और [रेंडरिंग](/slides/hi/cpp/convert-powerpoint-to-png/) के लिए उपयोग किया जाता है।

**सही रेंडरिंग के लिए किन फ़ोंट की आवश्यकता है?**

वास्तविक उपयोग में, प्रस्तुति में प्रयुक्त फ़ॉन्ट या उचित [विकल्प](/slides/hi/cpp/font-substitution/) उपलब्ध होने चाहिए। Linux/macOS पर सुसंगत रेंडरिंग सुनिश्चित करने के लिए सामान्य फ़ॉन्ट पैकेज स्थापित करना सलाहनीय है।

**Linux पर कस्टम फ़ॉन्ट फॉलबैक या अनुपलब्ध टेक्स्ट के रूप में क्यों दिखता है?**

यदि फ़ॉन्ट फ़ाइल में असंगत या भ्रष्ट name-table एंट्रीज़ हैं, तो Linux फ़ॉन्ट‑मैचिंग स्टैक (FreeType/fontconfig) एक अमान्य रिकॉर्ड चुन सकता है, जिससे फ़ॉन्ट अनसुलझा रह जाता है। सही name-table रिकॉर्ड वाले फ़ॉन्ट संस्करण का उपयोग करना या एक सुसंगत प्रतिस्थापन स्थापित करना इस समस्या को हल करता है।