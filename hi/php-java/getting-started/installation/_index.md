---
title: "स्थापना"
type: docs
weight: 70
url: /hi/php-java/installation/
keywords:
- "Aspose.Slides स्थापित करें"
- "Aspose.Slides डाउनलोड करें"
- "Aspose.Slides उपयोग करें"
- "Aspose.Slides स्थापना"
- "विंडोज"
- "लिनक्स"
- "पावरपॉइंट"
- "प्रेज़ेंटेशन"
- "PHP"
- "Aspose.Slides"
description: "Linux और विंडोज पर PHP के लिए Java के माध्यम से Aspose.Slides स्थापित करें: PHP, Java, Apache Tomcat, और PHP/Java Bridge सेट अप करें, Composer के साथ पैकेज जोड़ें, और एक छोटे स्क्रिप्ट से सेटअप को सत्यापित करें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java दो प्रक्रियाओं में चलता है। आपका PHP स्क्रिप्ट PHP क्लासेज़ का उपयोग करता है जो हर कॉल को PHP/Java Bridge के माध्यम से Aspose.Slides तक पहुँचाता है, जो Apache Tomcat के भीतर Java पर चलता है। यह लेख दोनों पक्षों की सेटअप, Composer के साथ पैकेज स्थापित करना, और इंस्टॉलेशन को सत्यापित करने के लिए एक छोटा स्क्रिप्ट चलाने की प्रक्रिया बताता है।

## **आवश्यकताएँ**

- **PHP 7.0 से 8.3**, `php.ini` में `allow_url_include = On` के साथ। आपके स्क्रिप्ट ब्रिज की क्लाइंट लाइब्रेरी `Java.inc` को Tomcat से HTTP के माध्यम से लोड करते हैं। PHP 8.4 और बाद में, जब भी PHP का `xml` एक्सटेंशन लोड होता है, `Java.inc` "end() expects exactly 1 argument" त्रुटि के साथ रुक जाता है, और Windows बिल्ड्स हमेशा इसे लोड करते हैं।
- **[Composer](https://getcomposer.org/)**।
- **Java 8 या बाद का**। एक JRE पर्याप्त है।
- **Apache Tomcat 9**। PHP/Java Bridge `javax.servlet` API पर बना है, जिसे Tomcat 10 और बाद में प्रदान नहीं किया जाता, इसलिए ब्रिज वहाँ शुरू नहीं होता।
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, इसका नवीनतम रिलीज़। इसका वेब एप्लिकेशन `JavaBridge.war` Tomcat में चलता है।

यह लेख Tomcat और आपके PHP स्क्रिप्ट को एक ही कंप्यूटर पर चलाता है। Aspose.Slides फ़ाइलें Tomcat के भीतर खोलता और सहेजता है, इसलिए आपके स्क्रिप्ट द्वारा पास किया गया प्रत्येक पथ वहाँ वैध होना चाहिए।

## **Linux पर स्थापित करें**

इन कमांड्स से Ubuntu 24.04 पर आपका होम फ़ोल्डर में सब कुछ स्थापित होगा। अन्य वितरणों पर, समान पैकेज वितरण के पैकेज मैनेजर से स्थापित करें।

1. PHP, Composer, Java, और डाउनलोड टूल्स स्थापित करें, फिर PHP कमांड लाइन के लिए `allow_url_include` को चालू करें:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

2. Apache Tomcat 9 और PHP/Java Bridge डाउनलोड करें, ब्रिज का `JavaBridge.war` Tomcat की `webapps` फ़ोल्डर में रखें, और Tomcat शुरू करें। Tomcat WAR फ़ाइल को `webapps/JavaBridge` में अनपैक करता है जैसे ही वह शुरू होता है:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. एक प्रोजेक्ट फ़ोल्डर बनाएं और [Packagist](https://packagist.org/packages/aspose/slides) से Aspose.Slides for PHP via Java स्थापित करें:

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. Tomcat को रोकें, पैकेज से Aspose.Slides JAR फ़ाइल को ब्रिज की `WEB-INF/lib` फ़ोल्डर में कॉपी करें, पैकेज से PHP 8 संस्करण की `Java.inc` से ब्रिज की `Java.inc` बदलें, और Tomcat को फिर से शुरू करें:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/hi/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/hi/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   PHP 7 पर, `Java.inc` प्रतिस्थापन को छोड़ दें। Tomcat शुरू होने में कुछ सेकंड लेता है, और यह तब चल रहा होना चाहिए जब भी आपके स्क्रिप्ट Aspose.Slides का प्रयोग करें।

## **Windows पर स्थापित करें**

1. [PHP 8.3 for Windows](https://www.php.net/downloads.php?os=windows) स्थापित करें और उसकी फ़ोल्डर को `PATH` पर्यावरण चर में जोड़ें। `php.ini-production` को उसी फ़ोल्डर में `php.ini` में कॉपी करें। `php.ini` में `allow_url_include = On` सेट करें और `extension_dir = "ext"`, `extension=openssl`, तथा `extension=zip` पंक्तियों को अन-कमेंट करें। Composer को पैकेज डाउनलोड करने के लिए `openssl` चाहिए, और उन्हें अनपैक करने के लिए `zip` चाहिए, जब तक 7‑Zip स्थापित न हो या `unzip` कमांड `PATH` में न हो।
2. [Composer](https://getcomposer.org/download/) स्थापित करें।
3. Java स्थापित करें और `JAVA_HOME` पर्यावरण चर को उसकी फ़ोल्डर पर सेट करें। Tomcat उसके बिना नहीं शुरू होगा।
4. कमांड प्रॉम्प्ट में Apache Tomcat 9 और PHP/Java Bridge डाउनलोड करें, ब्रिज का `JavaBridge.war` Tomcat की `webapps` फ़ोल्डर में रखें, और Tomcat शुरू करें। Tomcat के स्क्रिप्ट `CATALINA_HOME` चर के माध्यम से Tomcat को खोजते हैं, इसलिए अगले चरणों के लिए उसी कमांड प्रॉम्प्ट विंडो का उपयोग जारी रखें। Tomcat WAR फ़ाइल को `webapps\JavaBridge` में अनपैक करता है जैसे ही वह शुरू होता है:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. एक प्रोजेक्ट फ़ोल्डर बनाएं और [Packagist](https://packagist.org/packages/aspose/slides) से Aspose.Slides for PHP via Java स्थापित करें:

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Tomcat को रोकें, पैकेज से Aspose.Slides JAR फ़ाइल को ब्रिज की `WEB-INF\lib` फ़ोल्डर में कॉपी करें, पैकेज से PHP 8 संस्करण की `Java.inc` से ब्रिज की `Java.inc` बदलें, और Tomcat को फिर से शुरू करें:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   PHP 7 पर, `Java.inc` प्रतिस्थापन को छोड़ दें। Tomcat शुरू होने में कुछ सेकंड लेता है, और यह तब चल रहा होना चाहिए जब भी आपके स्क्रिप्ट Aspose.Slides का प्रयोग करें।

## **इंस्टॉलेशन सत्यापित करें**

इस स्क्रिप्ट को *hello.php* के रूप में प्रोजेक्ट फ़ोल्डर में सहेजें। यह एक टेक्स्ट बॉक्स वाले प्रेज़ेंटेशन को बनाता है और स्क्रिप्ट के पास सहेजता है:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/hi/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

प्रोजेक्ट फ़ोल्डर से इसे चलाएँ:

```bash
php hello.php
```

स्क्रिप्ट *hello.pptx* बनाती है, जिसमें एक स्लाइड है जो टेक्स्ट बॉक्स रखती है। बिना लाइसेंस के, स्लाइड में मूल्यांकन वाटरमार्क भी होता है; देखें [Licensing](/slides/hi/php-java/licensing/)।

स्क्रिप्ट `aspose.slides.php` को सीधे शामिल करती है: Composer का ऑटोलोडर इन क्लासेज़ को नहीं लोड कर सकता, क्योंकि वे सभी उसी एक फ़ाइल में परिभाषित हैं। यह `save` को एक पूर्ण पथ भी पास करता है, क्योंकि Aspose.Slides Tomcat के भीतर चलता है और सापेक्ष पथ को Tomcat के कार्य फ़ोल्डर के सापेक्ष हल करता है, न कि आपके स्क्रिप्ट के।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पुष्टि कर सकता हूँ कि Aspose.Slides सही ढंग से एकीकृत है?**

[इंस्टॉलेशन सत्यापित करें](#verify-the-installation) अनुभाग की स्क्रिप्ट चलाएँ। यदि वह बिना त्रुटियों के *hello.pptx* लिखती है, तो PHP, PHP/Java Bridge, और Aspose.Slides एक साथ कार्य कर रहे हैं।

**मेरी स्क्रिप्ट "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'" क्यों रोक देती है?**

PHP Tomcat से `Java.inc` लोड नहीं कर सका। यदि संदेश पहले कहता है कि `http://` रैपर अक्षम है, तो उस `php.ini` फ़ाइल में `allow_url_include = On` सेट करें जो आपका PHP कमांड लाइन लोड करता है; `php --ini` दिखाता है कि वह फ़ाइल कौन सी है। यदि वह "Connection refused" कहता है, तो Tomcat अभी नहीं चला है: उसे शुरू करें, या कुछ सेकंड इंतजार करें जब तक वह शुरू न हो जाए।

**बड़े प्रेज़ेंटेशन प्रोसेस करते समय मेमोरी उपयोग को कैसे सीमित करूँ?**

JVM मेमोरी सीमाओं को केवल आवश्यक स्तर तक बढ़ाएँ, और प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस को `finally` ब्लॉक में बंद करें ताकि कैश तुरंत मुक्त हो जाए। यह मेमोरी‑ऑफ़‑एरर से बचाता है और बैच ऑपरेशनों के दौरान कुल मेमोरी उपयोग को पूर्वानुमेय रखता है।

**क्या मैं अनावश्यक एक्सपोर्ट फ़ॉर्मेट को हटाकर अंतिम JAR आकार को घटा सकता हूँ?**

वर्तमान Aspose.Slides रिलीज़ एकल मोनोलिथिक लाइब्रेरी के रूप में वितरित होती हैं, इसलिए आप निर्माण समय पर विशिष्ट एक्सपोर्टर्स जैसे PDF या SVG को निष्क्रिय नहीं कर सकते।