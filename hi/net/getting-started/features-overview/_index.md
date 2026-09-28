---
title: फ़ीचर अवलोकन
type: docs
weight: 94
url: /hi/net/features-overview/
keywords:
- फ़ीचर्स
- समर्थित प्लेटफ़ॉर्म
- फ़ाइल फ़ॉर्मेट
- रूपांतरण
- रेंडरिंग
- प्रेज़ेंटेशन सामग्री
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET क्या-क्या कवर करता है, इसका मूल्यांकन करने से पहले समीक्षा करें: समर्थित प्लेटफ़ॉर्म, फ़ाइल फ़ॉर्मेट, स्लाइड रेंडरिंग, और वह सामग्री जिसे आप बना और संपादित कर सकते हैं।"
---
## **अवलोकन**

Aspose.Slides for .NET एक क्लास लाइब्रेरी है जो PowerPoint और OpenDocument प्रेज़ेंटेशन को बनाने, पढ़ने, संपादित करने, रूपांतरित करने और रेंडर करने के लिए उपयोगी है। इसका कोई यूज़र इंटरफ़ेस नहीं है और इसे Microsoft PowerPoint या Office की आवश्यकता नहीं होती, इसलिए आप इसे कंसोल एप्लिकेशन, Windows Forms जैसे डेस्कटॉप एप्लिकेशन, वेब एप्लिकेशन और वेब सर्विसेज़ में उपयोग कर सकते हैं। यह लेख लाइब्रेरी की क्षमताओं का सारांश देता है और प्रत्येक क्षेत्र का विवरण देने वाले लेखों के लिंक प्रदान करता है।

## **समर्थित प्लेटफ़ॉर्म**

Aspose.Slides for .NET दो NuGet पैकेजों के रूप में वितरित किया जाता है जिनकी API समान है:

|**पैकेज**|**पैकेज में बिल्ड**|**ऑपरेटिंग सिस्टम**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0, और .NET 6. इसे .NET Framework 4.6.2 या बाद के संस्करण, या .NET 6 या बाद के संस्करण के साथ उपयोग करें।|Windows। Linux और macOS `libgdiplus` लाइब्रेरी और `System.Drawing.EnableUnixSupport` स्विच के साथ।|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. इसे .NET 6 या बाद के संस्करण के साथ उपयोग करें।|Windows (x86, x64), Linux (x64 with glibc 2.23 or later, ARM64 with glibc 2.39 or later), और macOS (x64, ARM64)।|

[स्थापना](/slides/hi/net/installation/) बताती है कि कौन सा पैकेज चुनना है और Linux पर प्रत्येक पैकेज को क्या आवश्यक है। [सिस्टम आवश्यकताएँ](/slides/hi/net/system-requirements/) में विस्तृत रूप से समर्थित प्लेटफ़ॉर्म सूचीबद्ध हैं।

## **फ़ाइल फ़ॉर्मेट और रूपांतरण**

Aspose.Slides PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP और PowerPoint XML प्रेज़ेंटेशन खोलता और सहेजता है। यह PDF और HTML सामग्री को स्लाइड्स में आयात करता है, और प्रेज़ेंटेशन को PDF, XPS, HTML, HTML5, TIFF, एनिमेटेड GIF, SWF, Markdown, और XAML के रूप में सहेजता है। [समर्थित फ़ाइल फ़ॉर्मेट](/slides/hi/net/supported-file-formats/) में प्रत्येक फ़ॉर्मेट और उसे पढ़ने या लिखने वाली API का विवरण है।

|**फ़ीचर**|**विवरण**|
| :- | :- |
|[PPT और PPTX](/slides/hi/net/ppt-vs-pptx/)|बाइनरी PowerPoint 97-2003 फ़ॉर्मेट और Office Open XML फ़ॉर्मेट दोनों को पढ़ें और लिखें।|
|[PPT से PPTX रूपांतरण](/slides/hi/net/convert-ppt-to-pptx/)|पुराने PPT प्रेज़ेंटेशन को PPTX में बदलें।|
|[Portable Document Format (PDF)](/slides/hi/net/convert-powerpoint-to-pdf/)|प्रेज़ेंटेशन को PDF में निर्यात करें, जिसमें PDF/A और PDF/UA दस्तावेज़ शामिल हैं।|
|[XML Paper Specification (XPS)](/slides/hi/net/convert-powerpoint-to-xps/)|प्रेज़ेंटेशन को XPS दस्तावेज़ों में निर्यात करें।|
|[Tagged Image File Format (TIFF)](/slides/hi/net/convert-powerpoint-to-tiff/)|प्रेज़ेंटेशन को TIFF छवियों में निर्यात करें।|
|[HTML](/slides/hi/net/convert-powerpoint-to-html/)|प्रेज़ेंटेशन को HTML और HTML5 में निर्यात करें।|
|[PDF और HTML आयात](/slides/hi/net/import-presentation/)|PDF पृष्ठों और HTML सामग्री से स्लाइड्स बनाएं।|

## **प्रस्तुति रेंडरिंग**

Aspose.Slides स्लाइड्स और व्यक्तिगत आकृतियों को PNG, JPEG, BMP, GIF, TIFF, और SVG छवियों के रूप में, और स्लाइड्स को EMF मेटाफाइल के रूप में रेंडर करता है। देखें [प्रेज़ेंटेशन स्लाइड्स को छवियों में बदलें](/slides/hi/net/convert-slide/), [स्लाइड को SVG छवि के रूप में रेंडर करें](/slides/hi/net/render-a-slide-as-an-svg-image/), और [आकार थंबनेल बनाएं](/slides/hi/net/create-shape-thumbnails/)।

## **सामग्री विशेषताएँ**

Aspose.Slides आपको लगभग सभी प्रेज़ेंटेशन सामग्री को बनाने, पढ़ने और संशोधित करने की अनुमति देता है:

|**क्षेत्र**|**आप क्या कर सकते हैं**|
| :- | :- |
|[स्लाइड्स](/slides/hi/net/presentation-slide/)|स्लाइड्स जोड़ें, क्लोन करें, पुनः क्रमबद्ध करें और हटाएँ; लेआउट और मास्टर लागू करें; स्लाइड्स को सेक्शन में व्यवस्थित करें; स्लाइड आकार बदलें।|
|[डिज़ाइन](/slides/hi/net/presentation-design/)|पृष्ठभूमि, थीम रंग, हेडर और फुटर, तथा फ़ॉन्ट सेट करें।|
|[टेक्स्ट](/slides/hi/net/manage-text/)|टेक्स्ट फ्रेम, पैराग्राफ और पोर्शन बनाएं और संपादित करें; फ़ॉन्ट, रंग, बुलेट और संरेखन सेट करें; टेक्स्ट खोजें और प्रतिस्थापित करें।|
|[आकार](/slides/hi/net/powerpoint-shapes/)|ऑटोशेप्स, रेखाएँ, कनेक्टर, ग्रुप आकार, और चित्र फ्रेम बनाएं; स्थिति, आकार, रेखा, तथा ठोस, ग्रेडिएंट या पैटर्न भराव सेट करें; वैकल्पिक टेक्स्ट द्वारा आकार खोजें।|
|[टेबल्स](/slides/hi/net/powerpoint-table/), [चार्ट्स](/slides/hi/net/powerpoint-charts/), और [स्मार्टआर्ट](/slides/hi/net/powerpoint-smartart/)|टेबल्स, Microsoft Office चार्ट्स, और स्मार्टआर्ट डायग्राम बनाएं और संपादित करें।|
|[मीडिया](/slides/hi/net/manage-media-files/), [OLE ऑब्जेक्ट्स](/slides/hi/net/manage-ole/), और [ActiveX कंट्रोल्स](/slides/hi/net/activex/)|एम्बेडेड या लिंक्ड ऑडियो और वीडियो फ्रेम जोड़ें, OLE ऑब्जेक्ट्स एम्बेड करें, और ActiveX कंट्रोल्स जोड़ें, संशोधित करें या हटाएँ।|
|[नोट्स](/slides/hi/net/presentation-notes/) और [टिप्पणियाँ](/slides/hi/net/presentation-comments/)|स्पीकर नोट्स और समीक्षात्मक टिप्पणियाँ जोड़ें, पढ़ें और संपादित करें।|
|[एनीमेशन](/slides/hi/net/powerpoint-animation/) और [ट्रांज़िशन](/slides/hi/net/slide-transition/)|आकृतियों पर एनीमेशन इफ़ेक्ट लागू करें, स्लाइड ट्रांज़िशन सेट करें, और स्लाइड शो सेटिंग्स कॉन्फ़िगर करें।|
|[सुरक्षा](/slides/hi/net/presentation-security/)|प्रेज़ेंटेशन को पासवर्ड से एन्क्रिप्ट करें, लिखने संरक्षण सेट करें, और डिजिटल हस्ताक्षरों के साथ काम करें।|
|[VBA मैक्रोज](/slides/hi/net/presentation-via-vba/)|मैक्रो-सक्षम प्रेज़ेंटेशन में VBA मॉड्यूल जोड़ें, निकालें और हटाएँ।|
|[प्रॉपर्टीज़](/slides/hi/net/presentation-properties/)|दस्तावेज़ प्रॉपर्टीज़ पढ़ें और संपादित करें।|

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या लाइब्रेरी को काम करने के लिए सर्वर या पीसी पर Microsoft PowerPoint स्थापित करने की आवश्यकता है?**

नहीं। PowerPoint आवश्यक नहीं है; Aspose.Slides एक स्वतंत्र इंजन है जो प्रेज़ेंटेशन बनाने, संपादित करने, रूपांतरित करने और रेंडर करने के लिए काम करता है।

**मल्टीथ्रेडिंग कैसे काम करती है? क्या प्रोसेसिंग को समानांतर किया जा सकता है?**

विभिन्न थ्रेड्स में विभिन्न दस्तावेज़ों को प्रोसेस करना सुरक्षित है; एक ही [प्रेज़ेंटेशन](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ऑब्जेक्ट को [एकाधिक थ्रेड्स](/slides/hi/net/multithreading/) द्वारा एक साथ उपयोग नहीं किया जाना चाहिए।

**क्या फ़ाइल पासवर्ड और एन्क्रिप्शन समर्थित हैं?**

हाँ। आप एन्क्रिप्टेड प्रेज़ेंटेशन खोल सकते हैं, खोलने और लिखने का पासवर्ड सेट या हटाए जा सकते हैं, और सुरक्षा स्थिति की जाँच कर सकते हैं। ([आप कर सकते हैं](/slides/hi/net/password-protected-presentation/))

**क्या Linux कंटेनरों में फ़ॉन्ट्स की देखभाल करनी चाहिए?**

हाँ। आपके प्रेज़ेंटेशन में उपयोग किए गए फ़ॉन्ट या उपयुक्त विकल्प सिस्टम पर स्थापित होने चाहिए ताकि टेक्स्ट सही ढंग से रेंडर हो सके। आप अपने एप्लिकेशन में [फ़ॉन्ट डायरेक्टरी निर्दिष्ट](/slides/hi/net/custom-font/) भी कर सकते हैं। [स्थापना](/slides/hi/net/installation/) में प्रत्येक पैकेज की Linux आवश्यकताओं की सूची है।

**क्या एवाल्यूएशन संस्करण में सीमाएँ हैं?**

हाँ। बिना [लाइसेंस](/slides/hi/net/licensing/) के, Aspose.Slides प्रत्येक सहेजी गई स्लाइड पर एवाल्यूएशन वॉटरमार्क जोड़ता है और प्रेज़ेंटेशन से पढ़े गए टेक्स्ट को ट्रंकेट कर देता है। पूर्ण‑फ़ीचर परीक्षण के लिए एक [30‑दिन का अस्थायी लाइसेंस](https://purchase.aspose.com/temporary-license/) उपलब्ध है।

**क्या प्रेज़ेंटेशन में बाहरी फ़ॉर्मेट (PDF या HTML से PPTX) आयात करना समर्थित है?**

हाँ। आप प्रेज़ेंटेशन में [PDF पृष्ठ और HTML सामग्री](/slides/hi/net/import-presentation/) जोड़ सकते हैं, इन्हें स्लाइड्स में बदल सकते हैं।