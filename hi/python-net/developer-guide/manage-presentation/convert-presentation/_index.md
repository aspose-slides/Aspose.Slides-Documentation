---
title: Python में प्रस्तुतियों को कई फ़ॉर्मैट में बदलें
linktitle: प्रस्तुतियों को बदलें
type: docs
weight: 70
url: /hi/python-net/convert-presentation/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों को PPTX, PDF, HTML, इमेज, XPS, TIFF और अधिक में परिवर्तित करें।"
---
## **सारांश**

Aspose.Slides for Python via .NET PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है और उन्हें कई अन्य फ़ॉर्मेट में सहेज या रेंडर कर सकता है, बिना Microsoft PowerPoint, OpenOffice या LibreOffice के। आप पुराने PPT फ़ाइलों को आधुनिक PPTX में बदल सकते हैं, प्रस्तुतियों को PDF और XPS जैसे स्थिर-लेआउट दस्तावेज़ों में निर्यात कर सकते हैं, स्लाइड्स को HTML के रूप में प्रकाशित कर सकते हैं, या स्लाइड्स को प्रीव्यू, थंबनेल और अभिलेखों के लिए इमेज फ़ाइलों के रूप में रेंडर कर सकते हैं।

अधिकांश दस्तावेज़ रूपांतरण समान सामान्य कार्यप्रवाह का उपयोग करते हैं: स्रोत फ़ाइल को लोड करें, आवश्यक आउटपुट फ़ॉर्मेट चुनें, और आवश्यकतानुसार फ़ॉर्मेट-विशिष्ट विकल्प लागू करें। इमेज फ़ॉर्मेट के लिए, प्रत्येक स्लाइड को अलग-अलग रेंडर किया जाता है और फिर रास्टर या वेक्टर इमेज के रूप में सहेजा जाता है। नीचे लिंक किए गए समर्पित लेख प्रत्येक केस के कार्यान्वयन विवरण प्रदान करते हैं।

## **रूपांतरण परिदृश्य चुनें**

नीचे वाले लेखों का उपयोग पूर्ण Python उदाहरणों और फ़ॉर्मेट-विशिष्ट विकल्पों के लिए करें।

| परिदृश्य | जब आपको आवश्यकता हो | लेख |
| --- | --- | --- |
| PPT/PPTX/ODP से PPTX | पुराने PPT फ़ाइलों को आधुनिक बनाएं, मौजूदा PPTX फ़ाइलों को सामान्यीकृत करें, या OpenDocument प्रस्तुतियों को PowerPoint PPTX में बदलें। | [PPT को PPTX में बदलें](/slides/hi/python-net/convert-ppt-to-pptx/), [ODP को PPTX में बदलें](/slides/hi/python-net/convert-odp-to-pptx/), [प्रस्तुतियों को सहेजें](/slides/hi/python-net/save-presentation/) |
| PPTX से PPT | आधुनिक PowerPoint प्रस्तुति को पुराने बाइनरी PPT फ़ॉर्मेट में सहेजें, ताकि पुराने वर्कफ़्लो के साथ संगतता बनी रहे। | [PPTX को PPT में बदलें](/slides/hi/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP से PDF | साझा करने, प्रिंट करने, या अभिलेख के लिए पोर्टेबल, खोजने योग्य, स्थिर-लेआउट दस्तावेज़ बनाएं। | [PowerPoint को PDF में बदलें](/slides/hi/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP से नोट्स सहित PDF | स्लाइड सामग्री के साथ स्पीकर नोट्स निर्यात करें। | [PowerPoint को नोट्स सहित PDF में बदलें](/slides/hi/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP से HTML | प्रस्तुतियों को HTML पृष्ठों के रूप में प्रकाशित करें और चित्र, फ़ॉन्ट, नोट्स, तथा रिस्पॉन्सिव लेआउट विकल्पों को नियंत्रित करें। | [PowerPoint को HTML में बदलें](/slides/hi/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP से HTML5 | स्लाइड्स को HTML5 में निर्यात करें ताकि ब्राउज़र-आधारित दृश्य में फॉर्मेटिंग और इंटरैक्टिविटी बरकरार रहे। | [प्रस्तुतियों को HTML5 में बदलें](/slides/hi/python-net/export-to-html5/) |
| PPT/PPTX/ODP से PNG | प्रत्येक स्लाइड को प्रीव्यू, थंबनेल या वेब आउटपुट के लिए PNG इमेज में रेंडर करें। | [PowerPoint को PNG में बदलें](/slides/hi/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP से JPG | स्लाइड्स को JPG इमेज में रेंडर करें और इमेज आकार तथा गुणवत्ता नियंत्रित करें। | [PowerPoint को JPG में बदलें](/slides/hi/python-net/convert-powerpoint-to-jpg/) |
| स्लाइड से SVG | व्यक्तिगत स्लाइड्स को स्केलेबल वेक्टर ग्राफिक्स (SVG) के रूप में निर्यात करें। | [स्लाइड को SVG के रूप में रेंडर करें](/slides/hi/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP से XPS | स्थिर-लेआउट XPS दस्तावेज़ बनाएं। | [PowerPoint को XPS में बदलें](/slides/hi/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP से TIFF | प्रस्तुति को मल्टी-पेज TIFF फ़ाइल के रूप में सहेजें, प्रिंटिंग, स्कैनिंग, फैक्स या अभिलेख वर्कफ़्लो हेतु। | [PowerPoint को TIFF में बदलें](/slides/hi/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP से नोट्स सहित TIFF | स्लाइड्स को उनके स्पीकर नोट्स के साथ TIFF में सहेजें। | [PowerPoint को नोट्स सहित TIFF में बदलें](/slides/hi/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP से Word | जब आपको दस्तावेज़-शैली आउटपुट चाहिए तब स्लाइड्स को Word दस्तावेज़ में बदलें। | [PowerPoint को Word में बदलें](/slides/hi/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP से Markdown | डॉक्यूमेंटेशन और टेक्स्ट-आधारित वर्कफ़्लो के लिए प्रस्तुति सामग्री को Markdown में निकालें। | [PowerPoint को Markdown में बदलें](/slides/hi/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP से एनीमेटेड GIF | स्लाइड्स से एनीमेटेड GIF बनाएं। | [PowerPoint को एनीमेटेड GIF में बदलें](/slides/hi/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP से वीडियो | प्रस्तुति स्लाइड्स से वीडियो निर्यात वर्कफ़्लो बनाएं। | [PowerPoint को वीडियो में बदलें](/slides/hi/python-net/convert-powerpoint-to-video/) |
| प्रस्तुति से XAML | Python या .NET UI परिदृश्यों के लिए स्लाइड्स को XAML में निर्यात करें। | [प्रस्तुतियों को XAML में निर्यात करें](/slides/hi/python-net/export-to-xaml/) |

इनपुट और आउटपुट फ़ॉर्मेट की विस्तृत सूची के लिए, देखें [समर्थित फ़ाइल फ़ॉर्मेट](/slides/hi/python-net/supported-file-formats/)।

## **PowerPoint और OpenDocument रूपांतरण**

Aspose.Slides for Python via .NET PPT, PPTX, PPS, PPSX, POT, POTX, और ODP जैसे सामान्यतः उपयोग किए जाने वाले प्रस्तुति फ़ॉर्मेट से रूपांतरण का समर्थन करता है। PowerPoint और OpenDocument फाइलों के लिए वही रूपांतरण API उपयोग किया जाता है, इसलिए PPTX फ़ाइल को PDF में सहेजने वाला वर्कफ़्लो अक्सर केवल इनपुट फ़ाइल को बदलकर ODP फ़ाइल पर भी लागू किया जा सकता है।

ODP फ़ाइलों को बदलते समय याद रखें कि PowerPoint और OpenDocument एप्लिकेशन हर लेआउट और फ़ॉर्मेटिंग सुविधा का बिल्कुल वही समर्थन नहीं करते। यदि ODP फ़ाइल LibreOffice या OpenOffice Impress में बनाई गई थी, तो आउटपुट की समीक्षा करें और जब फ़ॉर्मेट-विशिष्ट मार्गदर्शन चाहिए हो तो [Convert OpenDocument Presentations](/slides/hi/python-net/convert-openoffice-odp/) में वर्णित विकल्पों का उपयोग करें।

## **PPT से PPTX रूपांतरण**

PPT पुराना बाइनरी PowerPoint फ़ॉर्मेट है, जबकि PPTX आधुनिक Office Open XML फ़ॉर्मेट है। Aspose.Slides for Python via .NET उच्च-फ़िडेलिटी PPT से PPTX रूपांतरण का समर्थन करता है और मास्टर, लेआउट, स्लाइड, चार्ट, समूहित आकार, प्लेसहोल्डर, टेक्स्ट फ़्रेम, टेक्सचर और पिक्चर फ़िल जैसे जटिल प्रस्तुति संरचनाओं को संरक्षित रखता है।

विवरण के लिए देखें [PPT को PPTX में बदलें](/slides/hi/python-net/convert-ppt-to-pptx/) और [PPT बनाम PPTX](/slides/hi/python-net/ppt-vs-pptx/)।

## **स्थिर-लेआउट निर्यात**

PDF, XPS, और TIFF तब उपयोगी होते हैं जब आउटपुट को सभी उपकरणों पर समान दिखना चाहिए और इसे प्रस्तुति के रूप में संपादित नहीं किया जाना चाहिए। समर्पित PDF, XPS, और TIFF लेख compliance, hidden slides, notes, image quality, compression, pixel format, और output size को नियंत्रित करने के तरीके समझाते हैं।

## **HTML और इमेज निर्यात**

HTML और HTML5 निर्यात ब्राउज़र दृश्य, वेब प्रकाशन, और हल्के शेयरिंग के लिए उपयोगी हैं। इमेज निर्यात तब उपयोगी होता है जब प्रत्येक स्लाइड को अलग प्रीव्यू, थंबनेल, या रास्टर एसेट बनाना हो। फ़ॉर्मेट-विशिष्ट रेंडरिंग मार्गदर्शन के लिए PNG, JPG, और SVG लेख देखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या प्रस्तुतियों को बदलने के लिए मुझे Microsoft PowerPoint की आवश्यकता है?**

नहीं। Aspose.Slides for Python via .NET एक स्वतंत्र लाइब्रेरी है और इसे Microsoft PowerPoint या Office ऑटोमेशन की आवश्यकता नहीं होती।

**क्या मैं कई प्रस्तुतियों को बैच में बदल सकता हूँ?**

हां। प्रत्येक प्रस्तुतीकरण को लोड करें, आवश्यक फ़ॉर्मेट में सहेजें, और प्रोसेसिंग के बाद प्रस्तुतीकरण ऑब्जेक्ट को डिस्पोज़ करें। समानांतर प्रोसेसिंग के लिए, अलग-अलग प्रस्तुतीकरण इंस्टेंस का उपयोग करें और [बहु-थ्रेडिंग](/slides/hi/python-net/multithreading/) मार्गदर्शन का पालन करें।

**क्या मैं केवल चयनित स्लाइड्स को निर्यात कर सकता हूँ?**

हां। विभिन्न निर्यात विधियों के माध्यम से आप स्लाइड इंडेक्स पास कर सकते हैं या व्यक्तिगत स्लाइड्स को रेंडर कर सकते हैं, यह आउटपुट फ़ॉर्मेट पर निर्भर करता है। लक्षित फ़ॉर्मेट के लिए समर्पित लेख देखें।

**क्या मैं PDF या XPS में निर्यात करते समय छिपी स्लाइड्स को शामिल कर सकता हूँ?**

हां। [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/) और [XPS](/slides/hi/python-net/convert-powerpoint-to-xps/) रूपांतरण लेखों में वर्णित hidden-slide निर्यात सेटिंग्स का उपयोग करें।

**क्या मैं PDF/A आउटपुट बना सकता हूँ?**

हां। PDF निर्यात के लिए PDF अनुपालन सेटिंग्स उपलब्ध हैं। विवरण के लिए [PowerPoint को PDF में बदलें](/slides/hi/python-net/convert-powerpoint-to-pdf/) देखें।

**रूपांतरण के दौरान फ़ॉन्ट कैसे संभाले जाते हैं?**

Aspose.Slides एंबेडेड फ़ॉन्ट, फ़ॉन्ट फॉलबैक, और फ़ॉन्ट सब्स्टिट्यूशन सेटिंग्स का उपयोग कर सकता है। देखें [Embedded Font](/slides/hi/python-net/embedded-font/), [Fallback Font](/slides/hi/python-net/fallback-font/), और [Font Substitution](/slides/hi/python-net/font-substitution/)।