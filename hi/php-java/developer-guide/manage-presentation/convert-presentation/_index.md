---
title: PHP में प्रस्तुतियों को विभिन्न स्वरूपों में बदलें
linktitle: प्रस्तुति बदलें
type: docs
weight: 70
url: /hi/php-java/convert-presentation/
keywords:
- प्रस्तुति बदलें
- प्रस्तुति निर्यात
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
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों को PPTX, PDF, HTML, छवियों, XPS, TIFF और अधिक स्वरूपों में बदलें।"
---
## **परिचय**

Aspose.Slides for PHP via Java PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है और उन्हें कई अन्य फ़ॉर्मेट में सहेज या रेंडर कर सकता है, बिना Microsoft PowerPoint, OpenOffice, या LibreOffice के। आप पुराने PPT फ़ाइलों को आधुनिक PPTX में बदल सकते हैं, प्रस्तुतियों को PDF और XPS जैसे स्थिर‑लेआउट दस्तावेज़ों में निर्यात कर सकते हैं, स्लाइड्स को HTML के रूप में प्रकाशित कर सकते हैं, या पूर्वावलोकन, थंबनेल और संग्रह के लिए स्लाइड्स को चित्र फ़ाइलों के रूप में रेंडर कर सकते हैं।

अधिकांश दस्तावेज़ रूपांतरण समान सामान्य वर्कफ़्लो का उपयोग करते हैं: स्रोत फ़ाइल लोड करें, वांछित आउटपुट फ़ॉर्मेट चुनें, और आवश्यकतानुसार फ़ॉर्मेट‑विशिष्ट विकल्प लागू करें। चित्र फ़ॉर्मेट के लिए, प्रत्येक स्लाइड को अलग‑अलग रेंडर किया जाता है और फिर रास्टर या वेक्टर चित्र के रूप में सहेजा जाता है। नीचे दिए गए समर्पित लेख प्रत्येक स्थिति के कार्यान्वयन विवरण प्रदान करते हैं।

## **परिवर्तन परिदृश्य चुनें**

नीचे दिए गए लेखों में पूर्ण PHP उदाहरण और फ़ॉर्मेट‑विशिष्ट विकल्प देखें।

| परिदृश्य | जब आपको चाहिए | लेख |
| --- | --- | --- |
| PPT/PPTX/ODP से PPTX | पुराने PPT फ़ाइलों को आधुनिकीकरण करें, मौजूदा PPTX फ़ाइलों को सामान्य बनाएं, या OpenDocument प्रस्तुतियों को PowerPoint PPTX में बदलें। | [PPT को PPTX में बदलें](/slides/hi/php-java/convert-ppt-to-pptx/), [ODP को PPTX में बदलें](/slides/hi/php-java/convert-odp-to-pptx/), [प्रस्तुतियों को सहेजें](/slides/hi/php-java/save-presentation/) |
| PPTX से PPT | आधुनिक PowerPoint प्रस्तुति को पुराने बाइनरी PPT फ़ॉर्मेट में सहेजें, ताकि पुरानी वर्कफ़्लो के साथ संगतता बनी रहे। | [PPTX को PPT में बदलें](/slides/hi/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP से PDF | साझा करने, प्रिंट करने या अभिलेख करने के लिए पोर्टेबल, खोज योग्य, स्थिर‑लेआउट दस्तावेज़ बनाएं। | [PowerPoint को PDF में बदलें](/slides/hi/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP से PDF नोट्स सहित | स्लाइड सामग्री के साथ स्पीकर नोट्स भी निर्यात करें। | [PowerPoint को नोट्स सहित PDF में बदलें](/slides/hi/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP से HTML | प्रस्तुतियों को HTML पृष्ठों के रूप में प्रकाशित करें और छवियों, फ़ॉन्ट्स, नोट्स तथा रिस्पॉन्सिव लेआउट विकल्पों को नियंत्रित करें। | [PowerPoint को HTML में बदलें](/slides/hi/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP से HTML5 | फ़ॉर्मेटिंग और इंटरैक्टिविटी बनाए रखते हुए ब्राउज़र‑आधारित देखने के लिए स्लाइड्स को HTML5 में निर्यात करें। | [प्रस्तुतियों को HTML5 में निर्यात करें](/slides/hi/php-java/export-to-html5/) |
| PPT/PPTX/ODP से PNG | पूर्वावलोकन, थंबनेल या वेब आउटपुट के लिए प्रत्येक स्लाइड को PNG चित्र में रेंडर करें। | [PowerPoint को PNG में बदलें](/slides/hi/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP से JPG | स्लाइड्स को JPG चित्रों में रेंडर करें और चित्र आयाम व गुणवत्ता को नियंत्रित करें। | [PowerPoint को JPG में बदलें](/slides/hi/php-java/convert-powerpoint-to-jpg/) |
| स्लाइड से SVG | व्यक्तिगत स्लाइड्स को स्केलेबल वेक्टर ग्राफ़िक्स के रूप में निर्यात करें। | [स्लाइड को SVG के रूप में रेंडर करें](/slides/hi/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP से XPS | स्थिर‑लेआउट XPS दस्तावेज़ जनरेट करें। | [PowerPoint को XPS में बदलें](/slides/hi/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP से TIFF | प्रिंट, स्कैन, फैक्स या अभिलेख कार्यप्रवाहों के लिए मल्टी‑पेज TIFF फ़ाइल के रूप में प्रस्तुति सहेजें। | [PowerPoint को TIFF में बदलें](/slides/hi/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP से TIFF नोट्स सहित | स्लाइड्स को स्पीकर नोट्स के साथ TIFF में सहेजें। | [PowerPoint को नोट्स सहित TIFF में बदलें](/slides/hi/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX से Markdown | दस्तावेज़ीकरण और टेक्स्ट‑आधारित वर्कफ़्लो के लिए प्रस्तुति सामग्री को Markdown में निकाले। | [PowerPoint को Markdown में बदलें](/slides/hi/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP से XML | निरीक्षण, तुलना, समस्या निवारण या XML‑आधारित वर्कफ़्लो के लिए टेक्स्ट‑आधारित PowerPoint XML प्रस्तुति बनाएं। | [PowerPoint को XML में बदलें](/slides/hi/php-java/convert-powerpoint-to-xml/) |
| PPT/PPTX से एनिमेटेड GIF | स्लाइड्स से एनिमेटेड GIF बनाएं। | [PowerPoint को एनिमेटेड GIF में बदलें](/slides/hi/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX से वीडियो | प्रस्तुति स्लाइड्स से वीडियो निर्यात वर्कफ़्लो बनाएं। | [PowerPoint को वीडियो में बदलें](/slides/hi/php-java/convert-powerpoint-to-video/) |
| प्रस्तुति से XAML | PHP या Java UI परिदृश्यों के लिए स्लाइड्स को XAML में निर्यात करें। | [प्रस्तुतियों को XAML में निर्यात करें](/slides/hi/php-java/export-to-xaml/) |

अधिक इनपुट और आउटपुट फ़ॉर्मेट की सूची के लिए, देखें [समर्थित फ़ाइल फ़ॉर्मेट](/slides/hi/php-java/supported-file-formats/)।

## **PowerPoint और OpenDocument रूपांतरण**

Aspose.Slides for PHP via Java सामान्यतः प्रयुक्त प्रस्तुति फ़ॉर्मेट जैसे PPT, PPTX, PPS, PPSX, POT, POTX, और ODP से रूपांतरण का समर्थन करता है। PowerPoint और OpenDocument फ़ाइलों के लिए वही रूपांतरण API उपयोग किया जाता है, इसलिए एक वर्कफ़्लो जो PPTX फ़ाइल को PDF में सहेजता है, आमतौर पर केवल इनपुट फ़ाइल को ODP में बदल कर ODP फ़ाइल पर भी लागू किया जा सकता है।

ODP फ़ाइलों को बदलते समय याद रखें कि PowerPoint और OpenDocument अनुप्रयोग प्रत्येक लेआउट और फ़ॉर्मेटिंग सुविधा को बिल्कुल समान तरीके से समर्थन नहीं करते। यदि ODP फ़ाइल LibreOffice या OpenOffice Impress में बनाई गई है, तो आउटपुट की समीक्षा करें और फ़ॉर्मेट‑विशिष्ट मार्गदर्शन के लिए [OpenDocument प्रस्तुतियों को बदलें](/slides/hi/php-java/convert-openoffice-odp/) में वर्णित विकल्पों का उपयोग करें।

## **PPT से PPTX परिवर्तन**

PPT पुराना बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX आधुनिक Office Open XML फ़ॉर्मेट है। Aspose.Slides for PHP via Java उच्च‑फ़िडेलिटी PPT से PPTX परिवर्तन का समर्थन करता है और मास्टर, लेआउट, स्लाइड, चार्ट, ग्रुप्ड शेप्स, प्लेसहोल्डर, टेक्स्ट फ़्रेम, टेक्सचर और पिक्चर फ़िल जैसे जटिल प्रस्तुति संरचनाओं को संरक्षित रखता है।

विवरण के लिए देखें [PPT को PPTX में बदलें](/slides/hi/php-java/convert-ppt-to-pptx/) और [PPT बनाम PPTX](/slides/hi/php-java/ppt-vs-pptx/)।

## **स्थिर‑लेआउट निर्यात**

PDF, XPS, और TIFF उपयोगी होते हैं जब आउटपुट को सभी उपकरणों पर समान दिखना चाहिए और इसे प्रस्तुति के रूप में संपादित नहीं किया जाना चाहिए। समर्पित PDF, XPS, और TIFF लेख समझाते हैं कि अनुपालन, छिपी स्लाइड्स, नोट्स, चित्र गुणवत्ता, संपीड़न, पिक्सेल फ़ॉर्मेट, और आउटपुट आकार को कैसे नियंत्रित किया जाए।

## **HTML और छवि निर्यात**

HTML और HTML5 निर्यात ब्राउज़र दृश्य, वेब प्रकाशन, और हल्के साझा करने के लिए उपयोगी हैं। छवि निर्यात तब उपयोगी होता है जब प्रत्येक स्लाइड को अलग‑अलग पूर्वावलोकन, थंबनेल, या रास्टर संपत्ति बनाना हो। फ़ॉर्मेट‑विशिष्ट रेंडरिंग मार्गदर्शन के लिए PNG, JPG, और SVG लेख देखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे प्रस्तुति रूपांतरण के लिए Microsoft PowerPoint की आवश्यकता है?**

नहीं। Aspose.Slides for PHP via Java एक स्वतंत्र लाइब्रेरी है और इसे Microsoft PowerPoint या Office ऑटोमेशन की आवश्यकता नहीं होती।

**क्या मैं कई प्रस्तुतियों को बैच में बदल सकता हूँ?**

हाँ। प्रत्येक प्रस्तुति को लोड करें, इसे वांछित फ़ॉर्मेट में सहेजें, और प्रोसेसिंग के बाद प्रस्तुति ऑब्जेक्ट को डिस्पोज़ करें। समानांतर प्रोसेसिंग के लिए अलग‑अलग प्रस्तुति इंस्टैंस का उपयोग करें और [मल्टीथ्रेडिंग](/slides/hi/php-java/multithreading/) मार्गदर्शन का पालन करें।

**क्या मैं केवल चयनित स्लाइड्स को निर्यात कर सकता हूँ?**

हाँ। कई निर्यात विधियों में आप स्लाइड इंडेक्स पास कर सकते हैं या आउटपुट फ़ॉर्मेट के अनुसार व्यक्तिगत स्लाइड्स को रेंडर कर सकते हैं। लक्ष्य फ़ॉर्मेट के समर्पित लेख देखें।

**क्या PDF या XPS निर्यात करते समय छिपी स्लाइड्स को शामिल किया जा सकता है?**

हाँ। छिपी‑स्लाइड निर्यात सेटिंग्स के लिए [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/) और [XPS](/slides/hi/php-java/convert-powerpoint-to-xps/) लेख देखें।

**क्या मैं PDF/A आउटपुट बना सकता हूँ?**

हाँ। PDF निर्यात के लिए PDF अनुपालन सेटिंग उपलब्ध हैं। विवरण के लिए देखें [PowerPoint को PDF में बदलें](/slides/hi/php-java/convert-powerpoint-to-pdf/)।

**रूपांतरण के दौरान फ़ॉन्ट कैसे संभाले जाते हैं?**

Aspose.Slides एम्बेडेड फ़ॉन्ट, फ़ॉन्ट फॉलबैक, और फ़ॉन्ट प्रतिस्थापन सेटिंग का उपयोग कर सकता है। देखें [एम्बेडेड फ़ॉन्ट](/slides/hi/php-java/embedded-font/), [फ़ॉल्बैक फ़ॉन्ट](/slides/hi/php-java/fallback-font/), और [फ़ॉन्ट प्रतिस्थापन](/slides/hi/php-java/font-substitution/)。