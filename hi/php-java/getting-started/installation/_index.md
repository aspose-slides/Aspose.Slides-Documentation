---
title: स्थापना
type: docs
weight: 70
url: /hi/php-java/installation/
keywords:
- Aspose.Slides स्थापित करें
- Aspose.Slides डाउनलोड करें
- Aspose.Slides उपयोग करें
- Aspose.Slides स्थापना
- विंडोज
- लिनक्स
- macOS
- पावरपॉइंट
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP के लिए Aspose.Slides via Java को जल्दी से स्थापित करें। चरण-दर-चरण मार्गदर्शिका, सिस्टम आवश्यकताएँ, और कोड नमूने — आज ही PowerPoint प्रस्तुतियों के साथ काम करना शुरू करें!"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides for PHP via Java को कैसे स्थापित और कॉन्फ़िगर किया जाए। यह आवश्यक पर्यावरण सेटअप, Packagist से लाइब्रेरी डाउनलोड करना, PHP/Java Bridge के साथ Apache Tomcat कॉन्फ़िगर करना, और स्थापना की पुष्टि के लिए एक उदाहरण चलाने को कवर करता है।

## **पर्यावरण कॉन्फ़िगर करें**

1. PHP 7 स्थापित करें, PHP पाथ को सिस्टम `PATH` वेरिएबल में जोड़ें और `php.ini` फ़ाइल में `allow_url_include` को `On` सेट करें।
1. JRE 8 स्थापित करें। स्थापित JRE के पाथ को `JAVA_HOME` पर्यावरण वेरिएबल में सेट करें।
1. Apache Tomcat 8.0 स्थापित करें।

## **Aspose.Slides for PHP via Java डाउनलोड करें** 

`packagist` सबसे आसान तरीका है [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides) को डाउनलोड करने का।

Aspose.Slides को Packagist के जरिए स्थापित करने के लिए यह कमांड चलाएँ: 
   ```bash
   composer require aspose/slides
   ```

## **Apache Tomcat कॉन्फ़िगर करें**

1. http://php-java-bridge.sourceforge.net/pjb/download.php से PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) डाउनलोड करें और `JavaBridge.war` फ़ाइल को tomcat `webapps` फ़ोल्डर में निकालें।
1. Apache Tomcat सेवा प्रारम्भ करें।
1. [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/hi/php-java) डाउनलोड करें और इसे `aspose.slides` फ़ोल्डर में निकालें। `jar/aspose-slides-x.x-php.jar` फ़ाइल को `webapps\JavaBridge\WEB-INF\lib` फ़ोल्डर में कॉपी करें। यदि आप **PHP 8** का उपयोग कर रहे हैं, तो PHP-Java Bridge के मूल `Java.inc` को `Java.inc.php8.zip` से प्राप्त `Java.inc` से बदलें।
1. Apache Tomcat सेवा पुनः प्रारम्भ करें।
1. `aspose.slides` फ़ोल्डर में `example.php` चलाएँ इस कमांड के साथ:
   ```bash
   php example.php
   ```

## **FAQ**

**मैं यह कैसे जाँचूँ कि Aspose.Slides सही तरह से एकीकृत हुआ है?**

अपने प्रोजेक्ट को बनाएँ, एक खाली [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) को इंस्टैंशिएट करें और इसे नए नाम से सहेजें। यदि फ़ाइल बिना कोई अपवाद फेंके बनाई जाती है, तो लाइब्रेरी सफलतापूर्वक एकीकृत हो चुकी है।

**बड़ी प्रस्तुतियों को प्रोसेस करते समय मेमोरी खपत को कैसे सीमित करें?**

JVM मेमोरी सीमा को केवल आवश्यक स्तर तक बढ़ाएँ, और प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस को `finally` ब्लॉक में बंद करें ताकि कैश तुरंत मुक्त हो सके। इससे मेमोरी‑ऑफ़‑एरर से बचा जा सकेगा और बैच ऑपरेशनों के दौरान कुल मेमोरी उपयोग पूर्वानुमानित रहेगा।

**क्या मैं अनावश्यक एक्सपोर्ट फ़ॉर्मेट को हटा कर अंतिम JAR आकार को छोटा कर सकता हूँ?**

वर्तमान Aspose.Slides रिलीज़ एक एकल मोनोलिथिक लाइब्रेरी के रूप में वितरित होती हैं, इसलिए बिल्ड समय पर PDF या SVG जैसे विशिष्ट एक्सपोर्टर्स को निष्क्रिय नहीं किया जा सकता।