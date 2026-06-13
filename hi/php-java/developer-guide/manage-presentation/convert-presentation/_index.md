---
title: PHP में प्रस्तुतियों को कई स्वरूपों में परिवर्तित करें
linktitle: प्रस्तुति को परिवर्तित करें
type: docs
weight: 70
url: /hi/php-java/convert-presentation/
keywords:
- प्रस्तुति को परिवर्तित करें
- प्रस्तुति को निर्यात करें
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों को PPTX, PDF, HTML, छवियों, XPS, TIFF और अधिक में परिवर्तित करें।"
---
## **सारांश**

Aspose.Slides for PHP via Java PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है और उन्हें कई अन्य स्वरूपों में सहेज या रेंडर कर सकता है बिना Microsoft PowerPoint, OpenOffice, या LibreOffice के। आप पुरानी PPT फ़ाइलों को आधुनिक PPTX में परिवर्तित कर सकते हैं, प्रस्तुतियों को PDF और XPS जैसे निश्चित-लेआउट दस्तावेज़ों में निर्यात कर सकते हैं, स्लाइड्स को HTML के रूप में प्रकाशित कर सकते हैं, या स्लाइड्स को पूर्वावलोकन, थंबनेल और अभिलेखों के लिए छवि फ़ाइलों के रूप में रेंडर कर सकते हैं।

अधिकांश दस्तावेज़ रूपांतरण समान सामान्य कार्यप्रवाह का उपयोग करते हैं: स्रोत फ़ाइल को लोड करें, आवश्यक आउटपुट स्वरूप चुनें, और आवश्यकता पड़ने पर स्वरूप-विशिष्ट विकल्प लागू करें। छवि स्वरूपों के लिए, प्रत्येक स्लाइड को अलग से रेंडर किया जाता है और फिर रास्टर या वेक्टर छवि के रूप में सहेजा जाता है। नीचे दिए गए समर्पित लेख प्रत्येक केस के कार्यान्वयन विवरण प्रदान करते हैं।

## **रूपांतरण परिदृश्य चुनें**

पूर्ण PHP उदाहरणों और स्वरूप-विशिष्ट विकल्पों के लिए नीचे दिए गए लेखों का उपयोग करें।

| परिदृश्य | जब आपको इसकी आवश्यकता हो तो उपयोग करें | लेख |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | legacy PPT फ़ाइलों को आधुनिक बनाना, मौजूदा PPTX फ़ाइलों को सामान्य करना, या OpenDocument प्रस्तुतियों को PowerPoint PPTX में परिवर्तित करना। | [PPT को PPTX में परिवर्तित करें](/slides/hi/php-java/convert-ppt-to-pptx/), [ODP को PPTX में परिवर्तित करें](/slides/hi/php-java/convert-odp-to-pptx/), [प्रस्तुतियों को सहेजें](/slides/hi/php-java/save-presentation/) |
| PPTX to PPT | एक आधुनिक PowerPoint प्रस्तुति को पुराने बाइनरी PPT स्वरूप में सहेजें ताकि पुराने कार्यप्रवाहों के साथ संगतता बनी रहे। | [PPTX को PPT में परिवर्तित करें](/slides/hi/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | सहजता, खोज योग्य, निश्चित-लेआउट दस्तावेज़ बनाएं साझा करने, प्रिंट करने या अभिलेख करने के लिए। | [PowerPoint को PDF में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | स्पीकर नोट्स को स्लाइड सामग्री के साथ निर्यात करें। | [PowerPoint को नोट्स सहित PDF में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | प्रस्तुतियों को HTML पृष्ठों के रूप में प्रकाशित करें और छवियों, फ़ॉन्ट्स, नोट्स, और रिस्पॉन्सिव लेआउट विकल्पों को नियंत्रित करें। | [PowerPoint को HTML में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | स्लाइड्स को HTML5 में निर्यात करें ब्राउज़र-आधारित दर्शन के लिए, फ़ॉर्मैटिंग और इंटरैक्टिविटी को बनाए रखते हुए। | [प्रस्तुतियों को HTML5 में निर्यात करें](/slides/hi/php-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | प्रत्येक स्लाइड को PNG छवि में रेंडर करें पूर्वावलोकन, थंबनेल, या वेब आउटपुट के लिए। | [PowerPoint को PNG में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | स्लाइड्स को JPG छवियों में रेंडर करें और छवि आयाम और गुणवत्ता नियंत्रित करें। | [PowerPoint को JPG में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | व्यक्तिगत स्लाइड्स को स्केलेबल वेक्टर ग्राफ़िक्स (SVG) के रूप में निर्यात करें। | [स्लाइड को SVG के रूप में रेंडर करें](/slides/hi/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | स्थिर-लेआउट XPS दस्तावेज़ बनाएं। | [PowerPoint को XPS में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | प्रस्तुति को मल्टी-पेज TIFF फ़ाइल के रूप में सहेजें प्रिंटिंग, स्कैनिंग, फैक्स, या अभिलेख कार्यप्रवाहों के लिए। | [PowerPoint को TIFF में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | स्लाइड्स को स्पीकर नोट्स के साथ TIFF में सहेजें। | [PowerPoint को नोट्स सहित TIFF में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | दस्तावेज़ीकरण और टेक्स्ट-आधारित कार्यप्रवाहों के लिए प्रस्तुति की सामग्री को Markdown में निकालें। | [PowerPoint को Markdown में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | स्लाइड्स से एनिमेटेड GIF बनाएं। | [PowerPoint को एनिमेटेड GIF में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | प्रस्तुति स्लाइड्स से वीडियो निर्यात कार्यप्रवाह बनाएं। | [PowerPoint को वीडियो में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-video/) |
| Presentation to XAML | PHP या Java UI परिदृश्यों के लिए स्लाइड्स को XAML में निर्यात करें। | [प्रस्तुतियों को XAML में निर्यात करें](/slides/hi/php-java/export-to-xaml/) |

इनपुट और आउटपुट फ़ॉर्मेट की विस्तृत सूची के लिए, देखें [समर्थित फ़ाइल फ़ॉर्मेट](/slides/hi/php-java/supported-file-formats/).

## **PowerPoint और OpenDocument रूपांतरण**

Aspose.Slides for PHP via Java सामान्यतः उपयोग किए जाने वाले प्रस्तुति फ़ॉर्मेट जैसे PPT, PPTX, PPS, PPSX, POT, POTX, और ODP से रूपांतरण का समर्थन करता है। वही रूपांतरण API PowerPoint और OpenDocument फ़ाइलों के लिए उपयोग की जाती है, इसलिए एक कार्यप्रवाह जो PPTX फ़ाइल को PDF में सहेजता है, आमतौर पर केवल इनपुट फ़ाइल बदलकर ODP फ़ाइल पर लागू किया जा सकता है।

ODP फ़ाइलों को रूपांतरित करते समय, याद रखें कि PowerPoint और OpenDocument एप्लिकेशन प्रत्येक लेआउट और फ़ॉर्मेटिंग फ़ीचर को बिल्कुल समान तरीके से समर्थन नहीं देते हैं। यदि कोई ODP फ़ाइल LibreOffice या OpenOffice Impress में बनाई गई थी, तो आउटपुट की समीक्षा करें और जब आपको स्वरूप-विशिष्ट मार्गदर्शन चाहिए तब [OpenDocument प्रस्तुतियों को परिवर्तित करें](/slides/hi/php-java/convert-openoffice-odp/) लिंक में वर्णित विकल्पों का उपयोग करें।

## **PPT से PPTX रूपांतरण**

PPT पुराना बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX आधुनिक Office Open XML फ़ॉर्मेट है। Aspose.Slides for PHP via Java उच्च‑स्थिरता वाला PPT से PPTX रूपांतरण समर्थन करता है, साथ ही मास्टर, लेआउट, स्लाइड, चार्ट, समूहित आकार, प्लेसहोल्डर, टेक्स्ट फ्रेम, टेक्सचर, और चित्र भराव जैसे जटिल प्रस्तुति संरचनाओं को संरक्षित रखता है।

विवरण के लिए देखें [PPT को PPTX में परिवर्तित करें](/slides/hi/php-java/convert-ppt-to-pptx/) और [PPT बनाम PPTX](/slides/hi/php-java/ppt-vs-pptx/)।

## **स्थिर‑लेआउट निर्यात**

PDF, XPS, और TIFF उपयोगी होते हैं जब आउटपुट को विभिन्न उपकरणों पर समान दिखना चाहिए और इसे प्रस्तुति के रूप में संपादित नहीं किया जाना चाहिए। समर्पित PDF, XPS, और TIFF लेख यह बताते हैं कि अनुपालन, छिपी हुई स्लाइड्स, नोट्स, छवि गुणवत्ता, संपीड़न, पिक्सेल फ़ॉर्मेट, और आउटपुट आकार को कैसे नियंत्रित किया जाए।

## **HTML और छवि निर्यात**

HTML और HTML5 निर्यात ब्राउज़र दर्शन, वेब प्रकाशन, और हल्के‑वजन साझा करने के लिए उपयोगी हैं। छवि निर्यात उपयोगी है जब प्रत्येक स्लाइड को अलग पूर्वावलोकन, थंबनेल, या रास्टर एसेट में बदलना हो। स्वरूप-विशिष्ट रेंडरिंग मार्गदर्शन के लिए PNG, JPG, और SVG लेखों का उपयोग करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे प्रस्तुतियों को रूपांतरित करने के लिए Microsoft PowerPoint चाहिए?**

नहीं। Aspose.Slides for PHP via Java एक स्वतंत्र लाइब्रेरी है और इसे Microsoft PowerPoint या Office ऑटोमेशन की आवश्यकता नहीं होती।

**क्या मैं कई प्रस्तुतियों को बैच में रूपांतरित कर सकता हूँ?**

हां। प्रत्येक प्रस्तुति को लोड करें, इसे आवश्यक स्वरूप में सहेजें, और प्रोसेसिंग के बाद प्रस्तुति ऑब्जेक्ट को नष्ट कर दें। समानांतर प्रोसेसिंग के लिए अलग-अलग प्रस्तुति इंस्टेंस का उपयोग करें और [मल्टीथ्रेडिंग](/slides/hi/php-java/multithreading/) लिंक में दिया गया मार्गदर्शन अनुसरण करें।

**क्या मैं केवल चयनित स्लाइड्स को निर्यात कर सकता हूँ?**

हां। कई निर्यात विधियाँ आपको स्लाइड इंडेसेस पास करने या व्यक्तिगत स्लाइड्स को रेंडर करने की अनुमति देती हैं, यह आउटपुट स्वरूप पर निर्भर करता है। लक्ष्य स्वरूप के लिए समर्पित लेख देखें।

**क्या मैं PDF या XPS में निर्यात करते समय छिपी हुई स्लाइड्स को शामिल कर सकता हूँ?**

हां। [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/) और [XPS](/slides/hi/php-java/convert-powerpoint-to-xps/) रूपांतरण लेखों में बताई गई छिपी स्लाइड निर्यात सेटिंग्स का उपयोग करें।

**क्या मैं PDF/A आउटपुट बना सकता हूँ?**

हां। PDF निर्यात के लिए PDF अनुपालन सेटिंग्स उपलब्ध हैं। विवरण के लिए देखें [PowerPoint को PDF में परिवर्तित करें](/slides/hi/php-java/convert-powerpoint-to-pdf/)।

**रूपांतरण के दौरान फ़ॉन्ट्स कैसे संभाले जाते हैं?**

Aspose.Slides एम्बेडेड फ़ॉन्ट्स, फ़ॉन्ट फॉलबैक, और फ़ॉन्ट प्रतिस्थापन सेटिंग्स का उपयोग कर सकता है। देखें [एम्बेडेड फ़ॉन्ट](/slides/hi/php-java/embedded-font/), [फ़ॉन्ट फॉलबैक](/slides/hi/php-java/fallback-font/), और [फ़ॉन्ट प्रतिस्थापन](/slides/hi/php-java/font-substitution/).