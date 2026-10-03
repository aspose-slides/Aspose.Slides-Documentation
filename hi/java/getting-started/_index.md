---
title: शुरुआत
type: docs
weight: 10
url: /hi/java/getting-started/
keywords:
- शुरुआत
- सिस्टम आवश्यकताएँ
- इंस्टॉलेशन
- पहली प्रस्तुति
- Maven
- PPT प्रोसेसिंग
- PPTX प्रोसेसिंग
- ODP प्रोसेसिंग
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ एक नया Java प्रोजेक्ट से पहली सहेजी गई प्रस्तुति तक का मार्ग: आवश्यकताओं की जाँच करें, Aspose के Maven रेपो से लाइब्रेरी जोड़ें, पहला प्रोग्राम चलाएँ, और सामान्य कार्यों के साथ आगे बढ़ें."
---
## **अवलोकन**

नीचे दिए गए चार चरणों को क्रम में पूरा करें। प्रत्येक चरण में क्या करना है बताया गया है और विवरण के साथ लेख का लिंक दिया गया है। मूल्यांकन, लाइसेंसिंग और समर्थन चरणों के बाद कवर किए गए हैं।

## **चरण 1: सिस्टम आवश्यकताएँ जांचें**

Aspose.Slides for Java एक एकल JAR फ़ाइल है जिसमें कोई मूल कोड नहीं है, इसलिए यह किसी भी ऑपरेटिंग सिस्टम पर चलती है जिसमें समर्थित Java runtime हो। [System Requirements](/slides/hi/java/system-requirements/) समर्थित ऑपरेटिंग सिस्टम और Java संस्करणों की सूची देता है। अगले चरणों में प्रोजेक्ट और कमांड्स को JDK 11 या बाद के संस्करण की आवश्यकता होती है और Maven मार्ग के लिए, [Apache Maven](https://mvn.apache.org/install.html) चाहिए।

## **चरण 2: लाइब्रेरी को अपने प्रोजेक्ट में जोड़ें**

Aspose.Slides for Java Aspose के अपने Maven रिपॉजिटरी में प्रकाशित होता है, Maven Central में नहीं। इन मार्गों में से एक चुनें:

- Maven के साथ: अपने *pom.xml* में रिपॉजिटरी `https://releases.aspose.com/java/repo/` घोषित करें और `com.aspose:aspose-slides` निर्भरता को `jdk16` वर्गीकरण के साथ जोड़ें।
- Maven के बिना: रिपॉजिटरी से *-jdk16.jar* पर समाप्त होने वाली JAR फ़ाइल डाउनलोड करें और इसे क्लास पाथ में रखें।

Linux पर, fontconfig लाइब्रेरी और कम से कम एक फ़ॉन्ट भी स्थापित करें। इनके बिना, प्रस्तुति को सहेजने पर त्रुटि आती है: "Fontconfig head is null, check your fonts or fonts configuration".

[Installation](/slides/hi/java/installation/) *pom.xml* प्रविष्टियों, JAR डाउनलोड, और Linux कमांड प्रदान करता है।

## **चरण 3: अपनी पहली प्रस्तुति बनाएं**

[quick start on the Aspose.Slides for Java home page](/slides/hi/java/#your-first-presentation) एक पूर्ण Maven प्रोजेक्ट है: एक *pom.xml* फ़ाइल और एक प्रोग्राम जो स्लाइड पर टेक्स्ट के साथ एक क्लाउड आकार जोड़ता है और प्रस्तुति को PPTX फ़ाइल के रूप में सहेजता है। आप इसे `mvn compile exec:java` के साथ चलाते हैं। [Create Presentations](/slides/hi/java/create-presentation/) समान प्रोग्राम को चरण-दर-चरण समझाता है। मौजूदा प्रस्तुति को खोलने और उसे किसी अन्य स्वरूप में सहेजने के लिए, देखें [Open Presentations](/slides/hi/java/open-presentation/) और [Save Presentations](/slides/hi/java/save-presentation/)।

## **चरण 4: सामान्य कार्यों के साथ जारी रखें**

- [प्रस्तुति खोलें](/slides/hi/java/open-presentation/)
- [प्रस्तुति सहेजें](/slides/hi/java/save-presentation/)
- [प्रस्तुति को PDF में रूपांतरित करें](/slides/hi/java/convert-powerpoint-to-pdf/)
- [स्लाइड्स को छवियों के रूप में रेंडर करें](/slides/hi/java/convert-slide/)
- [प्रस्तुति पाठ संपादित करें](/slides/hi/java/manage-text/)
- [स्लाइड तत्व के अनुसार उदाहरण](/slides/hi/java/examples/)

## **मूल्यांकन और लाइसेंस**

बिना लाइसेंस के, Aspose.Slides मूल्यांकन मोड में चलता है: यह सहेजी गई प्रत्येक स्लाइड में वॉटरमार्क जोड़ता है और आपके कोड द्वारा पढ़ी गई प्रस्तुति के पाठ को छोटा कर देता है।

- [Aspose.Slides का मूल्यांकन करें](/slides/hi/java/evaluate-aspose-slides/) मूल्यांकन सीमाओं और अस्थायी लाइसेंस का अनुरोध करने के तरीके को दर्शाता है।
- [लाइसेंसिंग](/slides/hi/java/licensing/) फ़ाइल या स्ट्रीम से लाइसेंस लागू करने का तरीका दिखाता है।
- [मिटर्ड लाइसेंसिंग](/slides/hi/java/metered-licensing/) उपयोग पर बिलिंग वाली लाइसेंसिंग को कवर करता है।
- [समर्थित फ़ाइल स्वरूप](/slides/hi/java/supported-file-formats/) उन स्वरूपों की सूची देता है जिन्हें Aspose.Slides लोड और सहेज सकता है।

## **सहायता प्राप्त करें**

[तकनीकी सहायता](/slides/hi/java/technical-support/) यह बताता है कि [नि:शुल्क सहायता मंच](https://forum.aspose.com/c/slides/hi/11) पर प्रश्न कैसे पूछें और समस्या रिपोर्ट करने पर क्या शामिल करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे Microsoft PowerPoint स्थापित होना आवश्यक है?**

नहीं। Aspose.Slides स्वयं प्रस्तुति फ़ाइलों को पढ़ता और लिखता है और PowerPoint का उपयोग नहीं करता, इसलिए यह सर्वरों और Linux पर भी चलता है।

**Maven क्यों Aspose.Slides for Java को नहीं खोज पाता?**

लाइब्रेरी Maven Central में नहीं है। अपने *pom.xml* में Aspose का रिपॉजिटरी घोषित करें, जैसा कि [Installation](/slides/hi/java/installation/) में दिखाया गया है, और Maven वहां से लाइब्रेरी डाउनलोड करता है।

**क्या `jdk16` वर्गीकरण का अर्थ है कि लाइब्रेरी को Java 16 की आवश्यकता है?**

नहीं। वर्गीकरण लाइब्रेरी की Java SE बिल्ड चुनता है; अन्य बिल्ड Android के लिए है। वही बिल्ड वर्तमान JDKs, जैसे JDK 21, पर चलती है।