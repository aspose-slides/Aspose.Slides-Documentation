---
title: Linux पर फ़ॉन्ट्स से संबंधित सामान्य अपवाद और त्रुटियाँ
type: docs
weight: 200
url: /hi/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "फ़ॉन्ट अपवाद, फ़ॉन्ट त्रुटि, Linux, Java, Aspose.Slides for Java"
description: "Linux पर फ़ॉन्ट अपवाद और त्रुटियाँ"
---
## **अवलोकन**

जब Aspose.Slides को Linux पर उपयोग किया जाता है, तो फ़ॉन्ट‑संबंधी समस्याएँ उत्पन्न हो सकती हैं यदि Java प्रक्रिया आवश्यक फ़ॉन्ट फ़ोल्डर या अस्थायी डायरेक्टरी तक पहुँच नहीं सकती, यदि सिस्टम पर कोई फ़ॉन्ट स्थापित नहीं हैं, या यदि आवश्यक सिस्टम लाइब्रेरी जैसे fontconfig या libfreetype गायब हों।

यह लेख Linux पर फ़ॉन्ट‑संबंधी सामान्य त्रुटियों और अपवादों का वर्णन करता है और उन्हें हल करने के लिए समाधान प्रदान करता है। यह बताता है कि फ़ॉन्ट और TEMP डायरेक्टरी तक पहुँच कैसे जांचें, आवश्यक फ़ॉन्ट और लाइब्रेरी स्थापित करें, और `FontsLoader` का उपयोग करके सिस्टम‑वाइड इंस्टॉल किए बिना फ़ॉन्ट लोड करें।

## **कोड को Linux पर चलाते समय गायब टेक्स्ट या इमेजेज (EMF या WMF)**

यह समस्या उन प्रणालियों में होती है जहाँ इन मामलों में प्रतिबंध होते हैं:

1. जब कोई फ़ॉन्ट स्थापित नहीं है या जब java प्रक्रिया के लिए फ़ॉन्ट फ़ोल्डर तक पहुँचना संभव नहीं है
2. जब TEMP डायरेक्टरी तक पहुँच नहीं हो सकती।

### **समाधान**

जाँचें और पुष्टि करें कि TEMP डायरेक्टरी और फ़ॉन्ट फ़ोल्डर तक पहुँच प्रदान की गई है। 

{{% alert color="warning" %}}
कुछ मामलों में, पर्यावरण या सुरक्षा नीति द्वारा लगाए गए प्रतिबंधों के कारण आप फ़ोल्डर्स तक पहुँच नहीं दे पाते। इन विकल्पों को आज़माएँ: 
{{% /alert %}}

**वैकल्पिक समाधान**

आवश्यक फ़ॉन्ट को इंस्टॉल किए बिना लोड करने के लिए [FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsLoader) का उपयोग करें:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

यदि TEMP डायरेक्टरी तक पहुँच नहीं हो सकती, तो Java के लिए TEMP के रूप में किसी अन्य डायरेक्टरी को निर्दिष्ट करने के लिये यह कोड उपयोग करें:
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

## **अपवाद: InvalidOperationException: सिस्टम पर कोई भी फ़ॉन्ट नहीं मिला**

यह अपवाद तब होता है जब

1) Java प्रक्रिया फ़ॉन्ट फ़ोल्डर तक पहुँच नहीं सकती  
2) कोई फ़ॉन्ट स्थापित नहीं है।

### **समाधान**

1. जाँचें और पुष्टि करें कि Java प्रक्रिया के लिए फ़ॉन्ट फ़ोल्डर तक पहुँच प्रदान की गई है।

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

   * उपयोग करके [FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **अपवाद: NoClassDefFoundError: com.aspose.slides.internal.ey.this क्लास को इनिशियलाइज़ नहीं किया जा सका**

यह अपवाद उन Linux सिस्टम पर होता है जहाँ fontconfig और फ़ॉन्ट नहीं हैं। 

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

इसके अतिरिक्त, कुछ open-jdk संस्करण (जैसे **alpine JDK**) भी **स्थापित फ़ॉन्ट की आवश्यकता** रखते हैं।

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

## **अपवाद: UnsatisfiedLinkError: libfreetype.so.6: साझा ऑब्जेक्ट फ़ाइल नहीं खोला जा सका: ऐसी कोई फ़ाइल या डायरेक्टरी नहीं**

यह अपवाद उन Linux सिस्टम पर होता है जहाँ libfreetype लाइब्रेरी नहीं है। 

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

{{% alert title="TIP" color="primary" %}} 
फ़ॉन्ट स्थापित करना या FontsLoader का उपयोग करना न भूलें।
{{% /alert %}}