---
title: स्थापना
type: docs
weight: 70
url: /hi/java/installation/
keywords:
- Aspose.Slides स्थापित करें
- Aspose.Slides डाउनलोड करें
- Aspose.Slides उपयोग करें
- Aspose.Slides स्थापना
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java को Aspose के Maven रिपॉज़िटरी से या JAR फ़ाइल के रूप में स्थापित करें, Linux आवश्यकताओं को सेट अप करें, और पहले प्रोग्राम से स्थापना की जाँच करें।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides for Java को किसी प्रोजेक्ट में कैसे जोड़ा जाए। Aspose.Slides for Java Aspose के स्वतंत्र Maven रिपॉज़िटरी में प्रकाशित होता है, Maven Central में नहीं, इसलिए एक Maven प्रोजेक्ट को उस रिपॉज़िटरी को घोषित करना पड़ता है। आप JAR फ़ाइल को डाउनलोड करके स्वयं क्लास पाथ में भी जोड़ सकते हैं। दोनों विकल्पों के अंत में एक छोटा प्रोग्राम चलता है जो पुष्टि करता है कि लाइब्रेरी काम कर रही है।

Aspose.Slides for Java को Microsoft PowerPoint की आवश्यकता नहीं होती। यह प्रोग्रामेटिक रूप से आवश्यक प्रेजेंटेशन फ़ाइलें बनाता है। हालांकि, उत्पन्न प्रेजेंटेशन को देखने के लिए आपको Microsoft PowerPoint या कोई अन्य प्रेजेंटेशन व्यूअर चाहिए हो सकता है।

## **आवश्यकताएँ**

- एक Java Development Kit (JDK)। इस लेख में बताए गए प्रोजेक्ट और कमांड्स को JDK 11 या बाद वाला चाहिए। JDK 11 पर, इंस्टॉलेशन की जाँच करने वाला प्रोग्राम “WARNING: An illegal reflective access operation has occurred” से शुरू होने वाली चेतावनी देता है; यह परिणाम को प्रभावित नहीं करता और इसे अनदेखा किया जा सकता है।
- [Apache Maven](https://maven.apache.org/install.html), यदि आप Maven मार्ग का उपयोग कर रहे हैं।
- Linux पर, fontconfig लाइब्रेरी और कम से कम एक स्थापित फ़ॉन्ट चाहिए। देखें [Linux](#linux)।

## **Maven रिपॉज़िटरी से स्थापित करें**

Aspose अपने Java लाइब्रेरीज़ को अपने स्वयं के [Maven रिपॉज़िटरी](https://releases.aspose.com/java/repo/com/aspose/) में रखता है। Maven प्रोजेक्ट में [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) का उपयोग करने के लिए अपने *pom.xml* में दो प्रविष्टियाँ जोड़ें।

1. **Aspose Maven रिपॉज़िटरी को घोषित करें।**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Aspose.Slides for Java निर्भरता जोड़ें।**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

`jdk8` क्लासिफायर आवश्यक है: यह लाइब्रेरी का Java SE बिल्ड चुनता है। `26.10` को नवीनतम संस्करण से बदलें जो [रिपॉज़िटरी](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) में सूचीबद्ध है। रिपॉज़िटरी प्रत्येक JAR के बगल में SHA-1 चेकसम फ़ाइल प्रकाशित करता है, जिसे Maven लाइब्रेरी डाउनलोड करते समय जाँचता है।

### **स्थापना जाँचें**

नई प्रोजेक्ट के साथ सेटअप की जाँच करने के लिए:

1. प्रोजेक्ट के लिये एक फ़ोल्डर बनाएँ और उसमें यह *pom.xml* संगे रखें:

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
               <version>26.10</version>
               <classifier>jdk8</classifier>
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

   रिपॉज़िटरी और निर्भरता के अलावा, यह *pom.xml* Java रिलीज़ को कंपाइल करने के लिये सेट करता है, उस क्लास का नाम देता है जिसे `mvn exec:java` चलाता है, और कंपाइलर प्लगइन को पिन करता है, क्योंकि कुछ Maven इंस्टॉलेशन द्वारा डिफ़ॉल्ट रूप से उपयोग किया गया पुराना प्लगइन `maven.compiler.release` सेटिंग को अनदेखा करता है।

2. [प्रेजेंटेशन बनाएँ](/slides/hi/java/create-presentation/) से पहला उदाहरण *src/main/java/HelloSlides.java* के रूप में सहेजें।

3. प्रोजेक्ट फ़ोल्डर में चलाएँ:

   ```bash
   mvn compile exec:java
   ```

Maven Aspose.Slides for Java को डाउनलोड करता है, प्रोग्राम को कंपाइल करता है, और चलाता है। प्रोग्राम *new_presentation.pptx* को प्रोजेक्ट फ़ोल्डर में सहेजता है।

## **Maven के बिना JAR फ़ाइल का उपयोग करें**

1. रिपॉज़िटरी में स्थित [संस्करण फ़ोल्डर](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) से *aspose-slides-26.10-jdk8.jar* डाउनलोड करें। किसी अन्य संस्करण के लिए, [रिपॉज़िटरी](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) में उसका फ़ोल्डर खोलें और *-jdk8.jar* पर समाप्त होने वाली फ़ाइल डाउनलोड करें।

2. [प्रेजेंटेशन बनाएँ](/slides/hi/java/create-presentation/) से पहला उदाहरण *HelloSlides.java* के रूप में उसी फ़ोल्डर में सहेजें जहाँ JAR फ़ाइल स्थित है।

3. उस फ़ोल्डर में चलाएँ:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

JDK एकल स्रोत फ़ाइल को कंपाइल और चलाता है, और प्रोग्राम *new_presentation.pptx* को फ़ोल्डर में सहेजता है। अपने स्वयं के एप्लिकेशन में, बिल्ड टूल या IDE में JAR फ़ाइल को क्लास पाथ में जोड़ें।

## **Linux**

Aspose.Slides for Java Java की फ़ॉन्ट सपोर्ट का उपयोग करता है, जिसे Linux पर fontconfig लाइब्रेरी और कम से कम एक स्थापित फ़ॉन्ट चाहिए। इनके बिना, प्रेजेंटेशन को बचाते समय “Fontconfig head is null, check your fonts or fonts configuration” त्रुटि आती है। न्यूनतम सर्वर और कंटेनर इमेज़ में ये दोनों अनुपस्थित हो सकते हैं; उदाहरण के लिये आधिकारिक Ubuntu कंटेनर इमेज़ में न तो fontconfig है न ही फ़ॉन्ट।

Debian और Ubuntu पर, यह कमांड JDK, Maven, fontconfig, और DejaVu फ़ॉन्ट स्थापित करता है:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

आपके प्रेजेंटेशन में प्रयुक्त फ़ॉन्ट या उपयुक्त विकल्प भी टेक्स्ट को सही ढंग से रेंडर करने के लिये स्थापित होने चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

### मैं यह कैसे सत्यापित करूँ कि Aspose.Slides सही तरह से एकीकृत हुआ है?

अपने प्रोजेक्ट को बनाएँ, एक खाली [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) बनाकर उसे नई फ़ाइल नाम से सहेजें। यदि फ़ाइल बिना अपवाद फेंके बनाई जाती है, तो लाइब्रेरी सफलतापूर्वक एकीकृत हुई है।

### बड़े प्रेजेंटेशन को प्रोसेस करते समय मेमोरी उपभोग को कैसे सीमित करूँ?

JVM मेमोरी सीमाओं को केवल आवश्यक मात्रा तक बढ़ाएँ, और प्रत्येक [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) इंस्टेंस पर `finally` ब्लॉक में [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) कॉल करके कैश को तुरंत मुक्त करें। इससे मेमोरी‑ओवरफ़्लो त्रुटियों से बचाव होगा और बैच संचालन के दौरान कुल मेमोरी उपयोग पूर्वानुमानित रहेगा।

### क्या मैं अनावश्यक एक्सपोर्ट फ़ॉर्मेट को हटाकर अंतिम JAR आकार को घटा सकता हूँ?

वर्तमान Aspose.Slides रिलीज़ एक एकल मोनोलिथिक लाइब्रेरी के रूप में वितरित होती है, इसलिए बिल्ड समय पर PDF या SVG जैसे विशिष्ट एक्सपोर्टर्स को अक्षम नहीं किया जा सकता।