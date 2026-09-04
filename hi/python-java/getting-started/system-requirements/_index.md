---
title: सिस्टम आवश्यकताएँ
type: docs
weight: 60
url: /hi/python-java/system-requirements/
keywords:
- सिस्टम आवश्यकताएँ
- Python
- Java
- JPype
- विंडोज
- लिनक्स
- मैकोएस
- Aspose.Slides
description: "Windows, Linux, और macOS पर Java के माध्यम से Python के लिए Aspose.Slides चलाने के लिए ऑपरेटिंग सिस्टम, Python, Java और JPype आवश्यकताओं की जाँच करें।"
---
## **अवलोकन**

Aspose.Slides for Python via Java Microsoft PowerPoint स्थापित किए बिना प्रस्तुतियों को बनाता, संशोधित करता, परिवर्तित करता और रेंडर करता है। यह JPype का उपयोग करके Python से Java लाइब्रेरी तक पहुंचता है, इसलिए परिवेश को Python, Java और JPype को साथ में समर्थन करना चाहिए।

## **समर्थित ऑपरेटिंग सिस्टम**

[Aspose.Slides पैकेज](https://pypi.org/project/aspose-slides-java/) निम्नलिखित ऑपरेटिंग सिस्टम परिवारों का समर्थन करता है:

- विंडोज
- लिनक्स
- macOS

अपने चयनित Python, Java, और JPype रिलीज़ द्वारा समर्थित ऑपरेटिंग सिस्टम संस्करण चुनें। केवल Java उपलब्धता यह स्थापित नहीं करती कि Python पैकेज और उसका ब्रिज संगत है।

## **Python, Java, और JPype आवश्यकताएँ**

| घटक | आवश्यकता |
| --- | --- |
| Python | Aspose.Slides पैकेज Python 3.7 से 3.14 तक घोषित करता है। चयनित JPype रिलीज़ को वही Python संस्करण समर्थन करना चाहिए; उदाहरण के लिए, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) को Python 3.8 या बाद का चाहिए। |
| Java | चयनित JPype रिलीज़ के साथ अनुकूल Java रनटाइम या JDK स्थापित करें। वर्तमान [JPype prerequisites](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) Java 11 या बाद को निर्दिष्ट करता है। Java 8 JPype1 1.7.1 चलाने में असमर्थ है। |
| JPype | अपने Python इंटरप्रेटर, ऑपरेटिंग सिस्टम और CPU आर्किटेक्चर के लिए JPype1 पैकेज स्थापित करें। |
| CPU आर्किटेक्चर | Python और Java Virtual Machine (JVM) को समान आर्किटेक्चर का उपयोग करना चाहिए। उदाहरण के लिए, 64-बिट Python इंटरप्रेटर के लिए एक संगत 64-बिट JVM आवश्यक है। |

Apple Silicon पर, Python और Java दोनों को या तो ARM64 या दोनों को x64 उपयोग करना चाहिए। एक स्वतंत्र रूप से चलने वाला JVM भी JPype के माध्यम से लोड होने में विफल हो सकता है यदि उसकी आर्किटेक्चर Python की से भिन्न हो।

नए परिवेश के लिए, Python 3.12, JDK 17, और JPype1 1.7.1 एक उपयुक्त प्रारंभिक बिंदु हैं। यह संयोजन Aspose.Slides for Python via Java 26.6.0 के साथ Windows पर सत्यापित किया गया था। अन्य संयोजनों को सभी तीन घटकों की आवश्यकताओं को पूरा करना चाहिए।

परिवेश सेटअप और कार्यशील सत्यापन उदाहरण के लिए, देखें [स्थापना](/slides/hi/python-java/installation/)।

## **अतिरिक्त निर्भरताएँ**

एक अनुकूल प्रीबिल्ड JPype व्हील को C++ कंपाइलर की आवश्यकता नहीं होती। यदि JPype को स्रोत से बनाना पड़े, तो एक अनुकूल C++ कंपाइलर और आपके प्लेटफ़ॉर्म द्वारा आवश्यक Python विकास फ़ाइलें स्थापित करें। निर्माण आवश्यकताओं और समस्या निवारण के लिए देखें [JPype installation instructions](https://jpype.readthedocs.io/en/latest/install.html)।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे Microsoft PowerPoint स्थापित करने की आवश्यकता है?**

नहीं। Aspose.Slides PowerPoint के बिना स्वतंत्र रूप से प्रस्तुतियों को प्रक्रिया करता है। Python, Java, और JPype अभी भी आवश्यक हैं।

**क्या मैं Python 3.7 को किसी भी JPype रिलीज़ के साथ उपयोग कर सकता हूँ?**

नहीं। यद्यपि Aspose.Slides पैकेज Python 3.7 समर्थन घोषित करता है, JPype1 1.7.1 को Python 3.8 या बाद चाहिए। उन संस्करणों को चुनें जिनकी आवश्यकताएँ ओवरलैप करती हों।

**क्या मैं 32-बिट Python को 64-बिट Java के साथ मिश्रित कर सकता हूँ?**

नहीं। JPype JVM को Python प्रक्रिया में लोड करता है, इसलिए Python और Java को समान आर्किटेक्चर होना चाहिए। यह आवश्यकता macOS पर ARM64 और x64 पर भी लागू होती है।