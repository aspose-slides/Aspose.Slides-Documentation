---
title: .NET में प्रस्तुतियों को कई फ़ॉर्मैट में रूपांतरित करें
linktitle: प्रस्तुति रूपांतरित करें
type: docs
weight: 70
url: /hi/net/convert-presentation/
keywords:
- प्रस्तुति परिवर्तित करें
- प्रस्तुति निर्यात करें
- PPT से PPTX
- PPTX से PPT
- ODP से PPTX
- PPT से PDF
- PPTX से PDF
- ODP से PDF
- PPT से HTML
- PPTX से HTML
- ODP से HTML
- PPT से PNG
- PPTX से PNG
- ODP से PNG
- PPTX से JPG
- ODP से JPG
- PPT से XPS
- PPTX से XPS
- ODP से XPS
- PPT से TIFF
- PPTX से TIFF
- ODP से TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों को PPTX, PDF, HTML, इमेज, XPS, TIFF और अधिक में बदलें।"
---
## **परिचय**

Aspose.Slides for .NET PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है और उन्हें कई अन्य फॉर्मैट में बिना Microsoft PowerPoint, OpenOffice, या LibreOffice के सेव या रेंडर कर सकता है। आप लेगेसी PPT फ़ाइलों को आधुनिक PPTX में बदल सकते हैं, प्रस्तुतियों को PDF और XPS जैसे फिक्स्ड‑लेआउट दस्तावेज़ों में एक्स्पोर्ट कर सकते हैं, स्लाइड्स को HTML के रूप में प्रकाशित कर सकते हैं, या प्रीव्यू, थंबनेल, और अभिलेखों के लिए स्लाइड्स को इमेज फ़ाइलों के रूप में रेंडर कर सकते हैं।

अधिकांश दस्तावेज़ रूपांतरण एक ही सामान्य कार्य‑प्रवाह का उपयोग करते हैं: स्रोत फ़ाइल लोड करें, आवश्यक आउटपुट फ़ॉर्मैट चुनें, और आवश्यकता पड़ने पर फ़ॉर्मैट‑विशिष्ट विकल्प लागू करें। इमेज फ़ॉर्मैट के लिए, प्रत्येक स्लाइड को अलग‑अलग रेंडर किया जाता है और फिर रास्टर या वेक्टर इमेज के रूप में सहेजा जाता है। नीचे दिए गए विशेष लेख प्रत्येक मामले के कार्यान्वयन विवरण प्रदान करते हैं।

## **परिवर्तन परिदृश्य चुनें**

नीचे दिए गए लेखों का उपयोग पूर्ण C# उदाहरणों और फ़ॉर्मैट‑विशिष्ट विकल्पों के लिए करें।

| परिदृश्य | जब आपको आवश्यकता हो तब उपयोग करें | लेख |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | लेगेसी PPT फ़ाइलों को आधुनिक बनाना, मौजूदा PPTX फ़ाइलों को सामान्य करना, या OpenDocument प्रस्तुतियों को PowerPoint PPTX में बदलना। | [PPT को PPTX में बदलें](/slides/hi/net/convert-ppt-to-pptx/), [ODP को PPTX में बदलें](/slides/hi/net/convert-odp-to-pptx/), [प्रस्तुतियों को सहेजें](/slides/hi/net/save-presentation/) |
| PPTX to PPT | आधुनिक PowerPoint प्रस्तुति को पुराने बाइनरी PPT फ़ॉर्मेट में सहेजना ताकि पुराने वर्कफ़्लो के साथ संगतता रहे। | [PPTX को PPT में बदलें](/slides/hi/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | साझा करने, प्रिंट करने या अभिलेख के लिए पोर्टेबल, सर्चेबल, फिक्स्ड‑लेआउट दस्तावेज़ बनाना। | [PowerPoint को PDF में बदलें](/slides/hi/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | स्पीकर नोट्स को स्लाइड सामग्री के साथ एक्सपोर्ट करना। | [PowerPoint को नोट्स के साथ PDF में बदलें](/slides/hi/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | प्रस्तुतियों को HTML पेज के रूप में प्रकाशित करना और छवियों, फ़ॉन्ट्स, नोट्स तथा रिस्पॉन्सिव लेआउट विकल्पों को नियंत्रित करना। | [PowerPoint को HTML में बदलें](/slides/hi/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | स्लाइड्स को HTML5 में एक्सपोर्ट करना ताकि ब्राउज़र में फ़ॉर्मेटिंग और इंटरैक्टिविटी बनी रहे। | [प्रस्तुतियों को HTML5 में बदलें](/slides/hi/net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | प्रत्येक स्लाइड को PNG इमेज के रूप में रेंडर करना ताकि प्रीव्यू, थंबनेल या वेब आउटपुट बनाया जा सके। | [PowerPoint को PNG में बदलें](/slides/hi/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | स्लाइड्स को JPG इमेज में रेंडर करना और इमेज आकार व गुणवत्ता नियंत्रित करना। | [PowerPoint को JPG में बदलें](/slides/hi/net/convert-powerpoint-to-jpg/) |
| Slide to SVG | व्यक्तिगत स्लाइड को स्केलेबल वेक्टर ग्राफ़िक के रूप में एक्सपोर्ट करना। | [स्लाइड को SVG के रूप में रेंडर करें](/slides/hi/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | फिक्स्ड‑लेआउट XPS दस्तावेज़ बनाना। | [PowerPoint को XPS में बदलें](/slides/hi/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | प्रस्तुति को मल्टी‑पेज TIFF फ़ाइल के रूप में सहेजना ताकि प्रिंट, स्कैन, फ़ैक्स या अभिलेख कार्यप्रवाह हो सके। | [PowerPoint को TIFF में बदलें](/slides/hi/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | स्पीकर नोट्स के साथ स्लाइड्स को TIFF में सहेजना। | [PowerPoint को नोट्स के साथ TIFF में बदलें](/slides/hi/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | स्लाइड्स को Word दस्तावेज़ में बदलना जब आपको डॉक्यूमेंट‑स्टाइल आउटपुट चाहिए। | [PowerPoint को Word में बदलें](/slides/hi/net/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | प्रस्तुति सामग्री को Markdown में निकालना ताकि डॉक्यूमेंटेशन या टेक्स्ट‑बेस्ड वर्कफ़्लो में उपयोग हो सके। | [PowerPoint को Markdown में बदलें](/slides/hi/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | स्लाइड्स से एनीमेटेड GIF बनाना। | [PowerPoint को एनीमेटेड GIF में बदलें](/slides/hi/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | प्रस्तुति स्लाइड्स से वीडियो एक्सपोर्ट वर्कफ़्लो बनाना। | [PowerPoint को वीडियो में बदलें](/slides/hi/net/convert-powerpoint-to-video/) |
| Presentation to XAML | .NET UI परिदृश्यों के लिए स्लाइड्स को XAML में एक्सपोर्ट करना। | [प्रस्तुतियों को XAML में एक्सपोर्ट करें](/slides/hi/net/export-to-xaml/) |

इनपुट और आउटपुट फ़ॉर्मैट की विस्तृत सूची के लिए, देखें [समर्थित फ़ाइल फ़ॉर्मैट](/slides/hi/net/supported-file-formats/)।

## **PowerPoint और OpenDocument रूपांतरण**

Aspose.Slides for .NET सामान्यतः प्रयुक्त प्रस्तुति फ़ॉर्मैट जैसे PPT, PPTX, PPS, PPSX, POT, POTX, और ODP से रूपांतरण का समर्थन करता है। PowerPoint और OpenDocument फ़ाइलों के लिए समान रूपांतरण API का उपयोग किया जाता है, इसलिए एक वर्कफ़्लो जिसे PPTX फ़ाइल को PDF में सहेजता है, वह अक्सर केवल इनपुट फ़ाइल बदलकर ODP फ़ाइल पर लागू किया जा सकता है।

ODP फ़ाइलें बदलते समय याद रखें कि PowerPoint और OpenDocument अनुप्रयोग हर लेआउट और फ़ॉर्मेटिंग फीचर को बिल्कुल समान तरीके से समर्थन नहीं करते। यदि ODP फ़ाइल LibreOffice या OpenOffice Impress से बनाई गई है, तो आउटपुट की समीक्षा करें और [Convert OpenDocument Presentations](/slides/hi/net/convert-openoffice-odp/) में वर्णित विकल्पों का उपयोग करें जब आपको फ़ॉर्मेट‑विशिष्ट मार्गदर्शन की आवश्यकता हो।

## **PPT से PPTX रूपांतरण**

PPT पुराना बाइनरी PowerPoint फ़ॉर्मैट है, जबकि PPTX आधुनिक Office Open XML फ़ॉर्मैट है। Aspose.Slides for .NET उच्च‑फ़िडेलिटी PPT से PPTX रूपांतरण का समर्थन करता है तथा मास्टर, लेआउट, स्लाइड, चार्ट, ग्रुप्ड शेप्स, प्लेसहॉल्डर्स, टेक्स्ट फ्रेम, टेक्सचर और पिक्चर फ़िल्स जैसी जटिल प्रस्तुति संरचनाओं को संरक्षित रखता है।

विवरण के लिए देखें [Convert PPT to PPTX](/slides/hi/net/convert-ppt-to-pptx/) और [PPT vs PPTX](/slides/hi/net/ppt-vs-pptx/)।

## **फ़िक्स्ड‑लेआउट निर्यात**

PDF, XPS, और TIFF उपयोगी होते हैं जब आउटपुट को सभी डिवाइस पर समान दिखना चाहिए और इसे प्रस्तुति के रूप में संपादित नहीं किया जाना चाहिए। Compliance, hidden slides, notes, image quality, compression, pixel format, और output size को नियंत्रित करने के लिए [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/xpsoptions/), और [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/) का उपयोग करें।

## **HTML और इमेज एक्सपोर्ट**

HTML और HTML5 एक्सपोर्ट ब्राउज़र में देखना, वेब पर प्रकाशित करना, और हल्का साझा करना उपयोगी हैं। इमेज एक्सपोर्ट उपयोगी होता है जब प्रत्येक स्लाइड को अलग‑अलग प्रीव्यू, थंबनेल, या रास्टर एसेट बनाना हो। फ़ॉर्मेट‑विशिष्ट रेंडरिंग मार्गदर्शन के लिए PNG, JPG, और SVG लेख देखिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे प्रस्तुतियों को बदलने के लिए Microsoft PowerPoint की जरूरत है?**  
नहीं। Aspose.Slides for .NET एक स्वतंत्र लाइब्रेरी है और इसे Microsoft PowerPoint या Office ऑटोमेशन की आवश्यकता नहीं होती।

**क्या मैं कई प्रस्तुतियों को बैच में बदल सकता हूँ?**  
हां। प्रत्येक प्रस्तुति को लोड करें, आवश्यक फ़ॉर्मेट में सहेजें, और प्रोसेसिंग के बाद `Presentation` ऑब्जेक्ट को डिस्पोज़ करें। समानांतर प्रोसेसिंग के लिए अलग‑अलग प्रस्तुति इंस्टैंस का उपयोग करें और [बहु-थ्रेडिंग](/slides/hi/net/multithreading/) मार्गदर्शन का पालन करें।

**क्या मैं केवल चयनित स्लाइड्स को एक्सपोर्ट कर सकता हूँ?**  
हां। कई एक्सपोर्ट मेथड्स आपको स्लाइड इंडेक्स पास करने या व्यक्तिगत स्लाइड्स को रेंडर करने की अनुमति देते हैं, फ़ॉर्मेट पर निर्भर करता है। लक्ष्य फ़ॉर्मेट के समर्पित लेख देखें।

**क्या मैं PDF या XPS में एक्सपोर्ट करते समय छिपी स्लाइड्स को शामिल कर सकता हूँ?**  
हां। [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) में `ShowHiddenSlides` प्रॉपर्टी या [XpsOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/xpsoptions/) में इसका उपयोग करें।

**क्या मैं PDF/A आउटपुट बना सकता हूँ?**  
हां। PDF कम्प्लायंस सेटिंग्स [PdfOptions.Compliance](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/compliance/) और [PdfCompliance](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfcompliance/) के माध्यम से उपलब्ध हैं।

**रूपांतरण के दौरान फ़ॉन्ट्स कैसे संभाले जाते हैं?**  
Aspose.Slides एम्बेडेड फ़ॉन्ट्स, फ़ॉन्ट फॉलबैक, और फ़ॉन्ट प्रतिस्थापन सेटिंग्स का उपयोग कर सकता है। देखें [एम्बेडेड फ़ॉन्ट](/slides/hi/net/embedded-font/), [फ़ॉलबैक फ़ॉन्ट](/slides/hi/net/fallback-font/), और [फ़ॉन्ट प्रतिस्थापन](/slides/hi/net/font-substitution/).