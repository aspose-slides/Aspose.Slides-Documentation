---
title: Linux पर फ़ॉन्ट्स से जुड़ी सामान्य अपवाद और त्रुटियाँ
type: docs
weight: 200
url: /hi/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "फ़ॉन्ट अपवाद, फ़ॉन्ट त्रुटि, Linux, Java, Aspose.Slides for Java"
description: "Linux पर फ़ॉन्ट अपवाद और त्रुटियाँ"
---
## **अवलोकन**

जब Aspose.Slides को Linux पर उपयोग किया जाता है, तो फ़ॉन्ट‑संबंधी समस्याएँ उत्पन्न हो सकती हैं यदि Java प्रक्रिया आवश्यक फ़ॉन्ट फ़ोल्डर या टेम्पररी डायरेक्टरी तक पहुँच नहीं पाती, यदि सिस्टम पर कोई फ़ॉन्ट स्थापित नहीं हैं, या यदि fontconfig या libfreetype जैसे आवश्यक सिस्टम लाइब्रेरीयाँ अनुपलब्ध हों।

यह लेख Linux पर फ़ॉन्ट से संबंधित सामान्य त्रुटियों और अपवादों का विवरण देता है और उन्हें हल करने के समाधान प्रदान करता है। यह बताता है कि फ़ॉन्ट और TEMP डायरेक्टरी तक पहुँच कैसे जाँची जाए, आवश्यक फ़ॉन्ट और लाइब्रेरीयाँ कैसे स्थापित की जाएँ, और `FontsLoader` का उपयोग करके सिस्टम‑व्यापी रूप से स्थापित किए बिना फ़ॉन्ट लोड किए जा सकते हैं।

## **Linux पर कोड चलाने पर गायब टेक्स्ट या इमेजेज (EMF या WMF)**

यह समस्या उन सिस्टमों में आती है जिनमें निम्न स्थितियों में प्रतिबंध होते हैं:

1. जब कोई फ़ॉन्ट स्थापित नहीं है या Java प्रक्रिया के लिए फ़ॉन्ट फ़ोल्डर तक पहुँच नहीं हो सकती
2. जब TEMP डायरेक्टरी तक पहुँच नहीं हो सकती।

### **समाधान**

जाँचें और पुष्टि करें कि TEMP डायरेक्टरी और फ़ॉन्ट फ़ोल्डर तक पहुँच प्रदान की गई है। 

{{% alert color="warning" %}}
कुछ मामलों में, आप पर्यावरण या सुरक्षा नीति द्वारा लगाए गए प्रतिबंधों के कारण फ़ोल्डरों तक पहुँच प्रदान नहीं कर सकेंगे। इन कार्यविधियों को आज़माएँ: 
{{% /alert %}}

**कार्यविधि**

आवश्यक फ़ॉन्ट लोड करने के लिए, बिना उन्हें स्थापित किए, [FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsLoader) का उपयोग करें:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

यदि TEMP डायरेक्टरी तक पहुँच नहीं हो सकती, तो Java के लिए TEMP के रूप में कोई अन्य डायरेक्टरी निर्दिष्ट करने हेतु इस कोड का उपयोग करें:
```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **Exception: InvalidOperationException: सिस्टम पर स्थापित कोई भी फ़ॉन्ट नहीं मिला**

यह अपवाद तब उत्पन्न होता है जब

1) Java प्रक्रिया फ़ॉन्ट फ़ोल्डर तक पहुँच नहीं पाती
2) कोई फ़ॉन्ट स्थापित नहीं है।

### **समाधान**

1. जाँचें और पुष्टि करें कि Java प्रक्रिया के फ़ॉन्ट फ़ोल्डर तक पहुँच प्रदान की गई है।
2. कुछ फ़ॉन्ट स्थापित करें या [FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsLoader) का उपयोग करें।
3. फ़ॉन्ट स्थापित करें।

   * Ubuntu: 

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```

   * CentOS: 

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
     ```

   * Using [FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Exception: InternalError: InvocationTargetException**

Linux पर PPTX फ़ाइल को PDF में परिवर्तित करते समय, परिवर्तन `java.lang.InternalError: java.lang.reflect.InvocationTargetException` के साथ विफल हो सकता है। यदि अंतर्निहित त्रुटि में `Cannot load from short array because "sun.awt.FontConfiguration.head" is null` कहा गया है, तो Linux फ़ॉन्ट कॉन्फ़िगरेशन अनुपलब्ध है या उसका कैश अभी तक आरम्भ नहीं हुआ है।

### **समाधान**

fontconfig स्थापित करें और फ़ॉन्ट कैश को पुनः बनाएं:
```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **Exception: NoClassDefFoundError: क्लास com.aspose.slides.internal.ey.this को प्रारम्भ नहीं किया जा सका**

यह अपवाद उन Linux सिस्टम पर आता है जिनमें fontconfig और फ़ॉन्ट नहीं हैं।

### **समाधान**

fontconfig स्थापित करें:

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

इसके अतिरिक्त, कुछ open-jdk संस्करण (उदाहरण के लिए, **alpine JDK**) को भी **स्थापित फ़ॉन्ट की आवश्यकता होती है**।

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **Exception: UnsatisfiedLinkError: libfreetype.so.6: साझा ऑब्जेक्ट फ़ाइल नहीं खोल सकता: ऐसी कोई फ़ाइल या डायरेक्टरी नहीं**

यह अपवाद उन Linux सिस्टम पर आता है जिनमें libfreetype लाइब्रेरी नहीं है।

### **समाधान**

libfreetype और fontconfig स्थापित करें:

* Ubuntu: 

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS: 

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="TIP" color="info" %}} 
फ़ॉन्ट स्थापित करना या FontsLoader का उपयोग करना न भूलें।
{{% /alert %}}