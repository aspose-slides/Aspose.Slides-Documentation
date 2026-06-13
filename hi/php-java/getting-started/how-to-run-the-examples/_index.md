---
title: "उदाहरण कैसे चलाएँ"
type: docs
weight: 140
url: /hi/php-java/how-to-run-the-examples/
keywords:
- उदाहरण
- सॉफ़्टवेयर आवश्यकताएँ
- GitHub
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के उदाहरण तेजी से चलाएँ: रेपो को क्लोन करें, पैकेज पुनर्स्थापित करें, फिर PPT, PPTX और ODP के लिए फीचर बनाएँ और परीक्षण करें।"
---
## **GitHub से डाउनलोड करें**
Aspose.Slides for PHP via Java के सभी उदाहरण GitHub पर होस्ट किए गए हैं [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java)। आप अपने पसंदीदा Github क्लाइंट का उपयोग करके रिपोजिटरी को क्लोन कर सकते हैं या ZIP फ़ाइल को यहाँ से डाउनलोड कर सकते हैं [here](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master)।

ZIP फ़ाइल की सामग्री को अपने कंप्यूटर पर किसी भी फ़ोल्डर में निकालें। सभी उदाहरण **Examples** फ़ोल्डर में स्थित हैं।

![todo:image_alt_text](examples_directory.png)

## **उदाहरणों को IDE में आयात करें**
यह प्रोजेक्ट Maven बिल्ड सिस्टम का उपयोग करता है। कोई भी आधुनिक IDE प्रोजेक्ट और उसकी निर्भरताओं को आसानी से खोल या आयात कर सकता है। नीचे हम दिखा रहे हैं कि लोकप्रिय IDEs का उपयोग करके उदाहरणों को कैसे बनाएं और चलाएं।

### **IntelliJ IDEA**
**File** मेनू पर क्लिक करें और **Open** चुनें। प्रोजेक्ट फ़ोल्डर तक जाएँ और **pom.xml** फ़ाइल चुनें।

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

यह प्रोजेक्ट को खोलेगा और निर्भरताओं को स्वचालित रूप से डाउनलोड करेगा। **Project** टैब से, **src/main/java** फ़ोल्डर में उदाहरण देखें। एक उदाहरण चलाने के लिए, फ़ाइल पर दाएँ क्लिक करें और "Run .." चुनें, उदाहरण चलाया जाएगा और आउटपुट बिल्ट‑इन कन्सोल आउटपुट विंडो में दिखेगा।

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
**File** मेनू पर क्लिक करें और **Import** चुनें। **Maven** - Existing Maven Projects चुनें।

![todo:image_alt_text](eclipse_import.png)

GitHub से क्लोन या डाउनलोड किए गए फ़ोल्डर तक जाएँ और **pom.xml** फ़ाइल चुनें। यह प्रोजेक्ट को खोलेगा और निर्भरताओं को स्वचालित रूप से डाउनलोड करेगा। **Package Explorer** टैब से, **src/main/java** फ़ोल्डर में उदाहरण देखें। एक उदाहरण चलाने के लिए, फ़ाइल पर दाएँ क्लिक करें और **Run As** - **Java Application** चुनें, उदाहरण चलाया जाएगा और आउटपुट बिल्ट‑इन कन्सोल आउटपुट विंडो में दिखेगा।

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
**File** मेनू पर क्लिक करें और **Open Project** चुनें। GitHub से क्लोन या डाउनलोड किए गए फ़ोल्डर तक जाएँ। **Examples** फ़ोल्डर का आइकन दिखाएगा कि यह एक Maven प्रोजेक्ट है। Examples चुनें और खोलें।

![todo:image_alt_text](netbeans_openproject.png)

यह प्रोजेक्ट को खोलेगा और निर्भरताओं को स्वचालित रूप से डाउनलोड करेगा। **Projects** टैब से, **source packages** में उदाहरण देखें। एक उदाहरण चलाने के लिए, फ़ाइल पर दाएँ क्लिक करें और **Run File** चुनें, उदाहरण चलाया जाएगा और आउटपुट बिल्ट‑इन कन्सोल आउटपुट विंडो में दिखेगा।

![todo:image_alt_text](netbeans_run_example.png)

## **Maven लोकल रिपॉजिटरी में Aspose.Slides लाइब्रेरी जोड़ें**
जब आप **Aspose.Slides Examples** प्रोजेक्ट को IDE में आयात करते हैं, तो Maven स्वचालित रूप से [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/) से aspose.slides JAR फ़ाइल डाउनलोड करता है। यदि आपके पास इंटरनेट एक्सेस नहीं है, तो आप JAR को अपने लोकल रिपॉजिटरी में मैन्युअल रूप से जोड़ सकते हैं।

### **mvn install**
[aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/) डाउनलोड करें, इसे एक्सट्रैक्ट करें और aspose.slides-version.jar को कहीं और कॉपी करें, जैसे C ड्राइव। फिर निम्न कमांड चलाएँ:

```php

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```php

```

अब, **aspose.slides** JAR आपके Maven लोकल रिपॉजिटरी में कॉपी हो गया है।

### **pom.xml**
इंस्टॉल करने के बाद, pom.xml में **aspose.slides** कोऑर्डिनेट घोषित करें। रिपॉज़िटरीज़ टैब में नीचे दिया गया रिपॉज़िटरी जोड़ें और डिपेंडेंसीज़ टैब में निर्भरता जोड़ें।

``` xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```php


### **हो गया**
इसे बिल्ड करें, अब **aspose.slides** JAR आपके Maven लोकल रिपॉजिटरी से प्राप्त किया जा सकता है।

## **योगदान दें**
यदि आप किसी उदाहरण को जोड़ना या सुधारना चाहते हैं, तो हम आपको प्रोजेक्ट में योगदान देने के लिए प्रोत्साहित करते हैं। इस रिपॉजिटरी में सभी उदाहरण और शोकेस प्रोजेक्ट ओपन सोर्स हैं और आपके अपने अनुप्रयोगों में स्वतंत्र रूप से उपयोग किए जा सकते हैं।

योगदान देने के लिए, आप रिपॉजिटरी को फॉर्क कर सकते हैं, स्रोत कोड को संपादित कर सकते हैं और एक पुल रिक्वेस्ट सबमिट कर सकते हैं। हम बदलावों की समीक्षा करेंगे और यदि उपयोगी पाए गए तो उन्हें रिपॉजिटरी में शामिल करेंगे।