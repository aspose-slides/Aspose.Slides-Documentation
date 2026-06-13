---
title: "उदाहरण कैसे चलाएँ"
type: docs
weight: 140
url: /hi/java/how-to-run-the-examples/
keywords:
- "उदाहरण"
- "सॉफ़्टवेयर आवश्यकताएँ"
- "GitHub"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java के उदाहरण शीघ्र चलाएँ: रिपॉजिटरी क्लोन करें, पैकेज पुनर्स्थापित करें, फिर PPT, PPTX और ODP के लिए सुविधाओं का निर्माण और परीक्षण करें।"
---
## **GitHub से Aspose.Slides डाउनलोड करें**
Aspose.Slides for Java के सभी उदाहरण [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) पर होस्ट किए गए हैं। आप अपने पसंदीदा Github क्लाइंट का उपयोग करके रिपॉजिटरी क्लोन कर सकते हैं या [here](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) से ZIP फ़ाइल डाउनलोड कर सकते हैं।

ZIP फ़ाइल की सामग्री को अपने कंप्यूटर में किसी भी फ़ोल्डर में निकालें। सभी उदाहरण **Examples** फ़ोल्डर में स्थित हैं।

![todo:image_alt_text](examples_directory.png)

## **IDE में उदाहरण आयात करें**
प्रोजेक्ट Maven बिल्ड सिस्टम का उपयोग करता है। कोई भी आधुनिक IDE प्रोजेक्ट और उसकी निर्भरताओं को आसानी से खोल या आयात कर सकता है। नीचे हम दिखाते हैं कि लोकप्रिय IDEs का उपयोग करके उदाहरणों को कैसे बनाएं और चलाएँ।

### **IntelliJ IDEA**
**File** मेन्यू पर क्लिक करें और **Open** चुनें। प्रोजेक्ट फ़ोल्डर तक जाएँ और **pom.xml** फ़ाइल चुनें।

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

यह प्रोजेक्ट को खोल देगा और निर्भरताओं को स्वचालित रूप से डाउनलोड करेगा। Project टैब से, **src/main/java** फ़ोल्डर में उदाहरण देखें। उदाहरण चलाने के लिए, फ़ाइल पर राइट‑क्लिक करके "Run .." चुनें, उदाहरण निष्पादित होगा और आउटपुट बिल्ट‑इन कंसोल आउटपुट विंडो में दिखेगा।

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
**File** मेन्यू पर क्लिक करें और **Import** चुनें। **Maven** - Existing Maven Projects चुनें।

![todo:image_alt_text](eclipse_import.png)

GitHub से क्लोन या डाउनलोड किए गए फ़ोल्डर तक जाएँ और **pom.xml** फ़ाइल चुनें। यह प्रोजेक्ट को खोल देगा और निर्भरताओं को स्वचालित रूप से डाउनलोड करेगा। Package Explorer टैब से, **src/main/java** फ़ोल्डर में उदाहरण देखें। उदाहरण चलाने के लिए, फ़ाइल पर राइट‑क्लिक करके **Run As** - **Java Application** चुनें, उदाहरण निष्पादित होगा और आउटपुट बिल्ट‑इन कंसोल आउटपुट विंडो में दिखेगा।

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
**File** मेन्यू पर क्लिक करें और **Open Project** चुनें। GitHub से क्लोन या डाउनलोड किए गए फ़ोल्डर तक जाएँ। **Examples** फ़ोल्डर का आइकन दिखाएगा कि यह Maven प्रोजेक्ट है। Examples चुनें और खोलें।

![todo:image_alt_text](netbeans_openproject.png)

यह प्रोजेक्ट को खोल देगा और निर्भरताओं को स्वचालित रूप से डाउनलोड करेगा। Projects टैब से, **source packages** में उदाहरण देखें। उदाहरण चलाने के लिए, फ़ाइल पर राइट‑क्लिक करके **Run File** चुनें, उदाहरण निष्पादित होगा और आउटपुट बिल्ट‑इन कंसोल आउटपुट विंडो में दिखेगा।

![todo:image_alt_text](netbeans_run_example.png)

## **Maven स्थानीय रिपॉजिटरी में Aspose.Slides लाइब्रेरी जोड़ें**
जब आप **Aspose.Slides Examples** प्रोजेक्ट को IDE में आयात करते हैं, तो Maven स्वचालित रूप से [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/) से aspose.slides JAR फ़ाइल डाउनलोड करता है। यदि आपके पास इंटरनेट की पहुँच नहीं है, तो आप JAR को अपने स्थानीय रिपॉजिटरी में मैन्युअली जोड़ सकते हैं।

### **mvn install**
**aspose.slides** को [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) से डाउनलोड करें, निकालें और aspose.slides-version.jar को कहीं और, उदाहरण के लिए C ड्राइव में कॉपी करें। निम्न कमांड चलाएँ:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

अब, **aspose.slides** jar आपके Maven स्थानीय रिपॉजिटरी में कॉपी हो गया है।

### **pom.xml**
इंस्टॉल होने के बाद, बस pom.xml में **aspose.slides** कोऑर्डिनेट घोषित करें। repositories टैब में निम्न रिपॉजिटरी और dependencies टैब में निर्भरता जोड़ें।

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>25.12</version>
    <classifier>jdk16</classifier>
</dependency>
```

### **समाप्त**
इसे बनाएं, अब **aspose.slides** jar आपके Maven स्थानीय रिपॉजिटरी से प्राप्त किया जा सकता है।

## **योगदान दें**
यदि आप कोई उदाहरण जोड़ना या सुधारना चाहते हैं, तो हम आपको परियोजना में योगदान देने के लिए प्रोत्साहित करते हैं। इस रिपॉजिटरी के सभी उदाहरण और शोकेस प्रोजेक्ट ओपन सोर्स हैं और आपके अपने अनुप्रयोगों में स्वतंत्र रूप से उपयोग किए जा सकते हैं।

योगदान देने के लिए, आप रिपॉजिटरी को फोर्क कर सकते हैं, स्रोत कोड संपादित कर सकते हैं और एक Pull Request जमा कर सकते हैं। हम परिवर्तन की समीक्षा करेंगे और यदि उपयोगी पाएंगे तो उन्हें रिपॉजिटरी में शामिल करेंगे।