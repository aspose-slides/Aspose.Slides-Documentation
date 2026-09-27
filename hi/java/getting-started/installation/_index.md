---
title: इंस्टॉलेशन
type: docs
weight: 70
url: /hi/java/installation/
keywords:
- Aspose.Slides स्थापित करें
- Aspose.Slides डाउनलोड करें
- Aspose.Slides उपयोग करें
- Aspose.Slides इंस्टॉलेशन
- विंडोज
- लिनक्स
- macOS
- पावरपॉइंट
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java को Aspose के Maven रिपॉज़िटरी से या JAR फ़ाइल के रूप में स्थापित करें, Linux की पूर्वापेक्षाएँ सेट करें, और पहले प्रोग्राम से इंस्टॉलेशन की जाँच करें।"
---
## **सारांश**

यह लेख समझाता है कि Aspose.Slides for Java को एक प्रोजेक्ट में कैसे जोड़ें। Aspose.Slides for Java Aspose के अपने Maven रिपॉज़िटरी में प्रकाशित होता है, Maven Central में नहीं, इसलिए एक Maven प्रोजेक्ट को उस रिपॉज़िटरी को घोषित करना पड़ता है। आप JAR फ़ाइल को भी डाउनलोड कर सकते हैं और उसे अपने क्लास पाथ पर रख सकते हैं। दोनों तरीकों का अंत एक छोटे प्रोग्राम से होता है जो लाइब्रेरी के कार्य करने की पुष्टि करता है।

Aspose.Slides for Java को Microsoft PowerPoint की आवश्यकता नहीं होती। यह आवश्यक प्रेजेंटेशन फ़ाइलें प्रोग्रामैटिकली जनरेट करता है। हालांकि, जनरेट किए गए प्रेजेंटेशन को देखने के लिए आपको Microsoft PowerPoint या कोई अन्य प्रेजेंटेशन व्यूअर की आवश्यकता पड़ सकती है।

## **पूर्वापेक्षाएँ**

- एक Java Development Kit (JDK)। इस लेख का प्रोजेक्ट और कमांड्स को JDK 11 या उसके बाद का चाहिए। JDK 11 पर, इंस्टॉलेशन जाँचने वाला प्रोग्राम `"WARNING: An illegal reflective access operation has occurred"` से शुरू होने वाली चेतावनी प्रिंट करता है; यह परिणाम को प्रभावित नहीं करता और इसे नज़रअंदाज़ किया जा सकता है।  
- [Apache Maven](https://maven.apache.org/install.html), यदि आप Maven मार्ग का उपयोग करते हैं।  
- Linux पर, fontconfig लाइब्रेरी और कम से कम एक स्थापित फ़ॉन्ट आवश्यक है। देखें [Linux](#linux)।

## **Maven रिपॉज़िटरी से इंस्टॉल करें**

Aspose अपनी Java लाइब्रेरीज़ अपने स्वयं के [Maven repository](https://releases.aspose.com/java/repo/com/aspose/) में रखता है। एक Maven प्रोजेक्ट में [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) का उपयोग करने के लिए *pom.xml* में दो प्रविष्टियाँ जोड़ें।

1. **Aspose Maven रिपॉज़िटरी घोषित करें।**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Aspose.Slides for Java डिपेंडेंसी जोड़ें।**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

`jdk16` क्लासिफायर आवश्यक है: यह लाइब्रेरी का Java SE बिल्ड चुनता है। `26.9` को रिपॉज़िटरी में सूचीबद्ध नवीनतम संस्करण से बदलें। रिपॉज़िटरी प्रत्येक JAR के साथ एक SHA-1 चेकसम फ़ाइल प्रकाशित करता है, जिसे Maven लाइब्रेरी डाउनलोड करने पर जांचता है।

### **इंस्टॉलेशन जांचें**

नए प्रोजेक्ट के साथ सेटअप की जाँच करने के लिए:

1. प्रोजेक्ट के लिए एक फ़ोल्डर बनाएं और इस *pom.xml* को उसमें सहेजें:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.9</version>
               <classifier>jdk16</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   रिपॉज़िटरी और डिपेंडेंसी के अतिरिक्त, यह *pom.xml* Java रिलीज़ को कंपाइल करने के लिए सेट करता है, उस क्लास का नाम बताता है जिसे `mvn exec:java` चलाता है, और कंपाइलर प्लगइन को पिन करता है, क्योंकि कुछ Maven इंस्टॉलेशन द्वारा डिफ़ॉल्ट रूप से उपयोग किया जाने वाला पुराना प्लगइन `maven.compiler.release` सेटिंग को नजरअंदाज़ करता है।

2. पहले उदाहरण को [Create Presentations](/slides/hi/java/create-presentation/) में *src/main/java/HelloSlides.java* के रूप में सहेजें।

3. प्रोजेक्ट फ़ोल्डर में चलाएँ:

   ```bash
   mvn compile exec:java
   ```

Maven Aspose.Slides for Java को डाउनलोड करता है, प्रोग्राम को कंपाइल करता है और चलाता है। प्रोग्राम *new_presentation.pptx* को प्रोजेक्ट फ़ोल्डर में सहेजता है।

## **Maven के बिना JAR फ़ाइल का उपयोग करें**

1. रिपॉज़िटरी में [version folder](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) से *aspose-slides-26.9-jdk16.jar* डाउनलोड करें। किसी अन्य संस्करण के लिए, [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) में उसका फ़ोल्डर खोलें और वह फ़ाइल डाउनलोड करें जिसका अंत *-jdk16.jar* है।  
2. पहले उदाहरण को [Create Presentations](/slides/hi/java/create-presentation/) में *HelloSlides.java* के रूप में JAR फ़ाइल के समान फ़ोल्डर में सहेजें।  
3. उस फ़ोल्डर में चलाएँ:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

JDK एकल स्रोत फ़ाइल को कंपाइल और चलाता है, और प्रोग्राम *new_presentation.pptx* को फ़ोल्डर में सहेजता है। अपने स्वयं के एप्लिकेशन में, JAR फ़ाइल को अपने बिल्ड टूल या IDE में क्लास पाथ में जोड़ें।

## **Linux**

Aspose.Slides for Java Java की फ़ॉन्ट सपोर्ट का उपयोग करता है, जो Linux पर fontconfig लाइब्रेरी और कम से कम एक स्थापित फ़ॉन्ट की आवश्यकता रखता है। बिना इनके, प्रेजेंटेशन सहेजने पर error “Fontconfig head is null, check your fonts or fonts configuration” आता है। न्यूनतम सर्वर और कंटेनर इमेज़ में दोनों घटक अभाव हो सकते हैं; उदाहरण के लिए आधिकारिक Ubuntu कंटेनर इमेज़ में दोनों ही नहीं होते।

Debian और Ubuntu पर, यह कमांड JDK, Maven, fontconfig, और DejaVu फ़ॉन्ट इंस्टॉल करता है:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

आपके प्रेजेंटेशन में उपयोग किए गए फ़ॉन्ट, या उपयुक्त विकल्प, भी टेक्स्ट को सही ढंग से रेंडर करने के लिए इंस्टॉल होने चाहिए।

## **FAQ**

### Aspose.Slides को सही ढंग से एकीकृत किया गया है, यह कैसे जांचें?

अपने प्रोजेक्ट को बनाएं, एक खाली [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) का इंस्टेंस बनाएं और उसे नए नाम से सहेजें। यदि फ़ाइल बिना किसी अपवाद के बन जाती है, तो लाइब्रेरी सफलतापूर्वक एकीकृत हो गई है।

### बड़े प्रेजेंटेशन प्रोसेस करते समय मेमोरी उपयोग को कैसे सीमित करें?

JVM मेमोरी सीमाएं केवल आवश्यकतानुसार बढ़ाएँ, और प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस पर `finally` ब्लॉक में [dispose](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#dispose--) कॉल करें ताकि कैश तुरंत रिलीज़ हो सके। यह मेमोरी‑ओवरफ़्लो त्रुटियों को रोकता है और बैच ऑपरेशनों के दौरान कुल मेमोरी उपयोग को पूर्वानुमेय रखता है।

### अंतिम JAR आकार को छोटा करने के लिए अनचाहे एक्सपोर्ट फ़ॉर्मैट को बाहर निकाल सकता हूँ?

वर्तमान Aspose.Slides रिलीज़ एक एकल मोनोलिथिक लाइब्रेरी के रूप में वितरित होते हैं, इसलिए निर्माण समय पर PDF या SVG जैसे विशिष्ट एक्सपोर्टर्स को निष्क्रिय नहीं किया जा सकता।