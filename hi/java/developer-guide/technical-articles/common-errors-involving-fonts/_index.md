---
title: लिनक्स पर फ़ॉन्ट से जुड़ी सामान्य अपवाद और त्रुटियाँ
type: docs
weight: 200
url: /hi/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "फ़ॉन्ट अपवाद, फ़ॉन्ट त्रुटि, लिनक्स, जावा, Aspose.Slides for Java"
description: "लिनक्स पर फ़ॉन्ट अपवाद और त्रुटियाँ"
---
## **परिचय**

जब Aspose.Slides को Linux पर उपयोग किया जाता है, तो फ़ॉन्ट‑संबंधी समस्याएँ उत्पन्न हो सकती हैं यदि Java प्रोसेस आवश्यक फ़ॉन्ट फ़ोल्डर या अस्थायी डायरेक्टरी तक पहुँच नहीं पा रहा है, यदि सिस्टम पर कोई फ़ॉन्ट स्थापित नहीं है, या यदि आवश्यक सिस्टम लाइब्रेरी जैसे fontconfig या libfreetype अनुपलब्ध हैं।

यह लेख Linux पर फ़ॉन्ट से जुड़ी सामान्य त्रुटियों और अपवादों का विवरण देता है और उन्हें हल करने के समाधान प्रदान करता है। यह फ़ॉन्ट और TEMP डायरेक्टरी तक पहुँच की जाँच, आवश्यक फ़ॉन्ट और लाइब्रेरी स्थापित करने, तथा सिस्टम‑वाइड स्थापित किए बिना फ़ॉन्ट लोड करने के लिए `FontsLoader` के उपयोग को समझाता है।

## **कोड को Linux पर चलाने पर टेक्स्ट या इमेज (EMF या WMF) गायब होना**

यह समस्या उन सिस्टमों में आती है जिनमें निम्नलिखित स्थितियों में प्रतिबंध होते हैं:

1. जब कोई फ़ॉन्ट स्थापित नहीं है या जावा प्रोसेस के फ़ॉन्ट फ़ोल्डर तक पहुँचा नहीं जा सकता
2. जब TEMP डायरेक्टरी तक पहुँचा नहीं जा सकता।

### **समाधान**

जाँचें और पुष्टि करें कि TEMP डायरेक्टरी और फ़ॉन्ट फ़ोल्डर तक पहुँच दिया गया है। 

{{% alert color="warning" %}}
कुछ मामलों में, पर्यावरण या सुरक्षा नीति द्वारा लगाए गए प्रतिबंधों के कारण फ़ोल्डर तक पहुँच नहीं दी जा सकती। इन कार्य‑विधियों को आज़माएँ: 
{{% /alert %}}

**वैकल्पिक समाधान**

आवश्यक फ़ॉन्ट को स्थापित किए बिना लोड करने के लिए [FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsLoader) का उपयोग करें:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

यदि TEMP डायरेक्टरी तक पहुँच नहीं दी जा सकती, तो Java के लिए TEMP को किसी अन्य डायरेक्टरी में निर्दिष्ट करने के लिए यह कोड उपयोग करें:
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

## **अपवाद: InvalidOperationException: सिस्टम पर स्थापित कोई भी फ़ॉन्ट नहीं मिला**

यह अपवाद तब उत्पन्न होता है जब

1) जावा प्रोसेस फ़ॉन्ट फ़ोल्डर तक पहुँच नहीं सकता  
2) कोई फ़ॉन्ट स्थापित नहीं किए गए हैं।

### **समाधान**

1. जाँचें और पुष्टि करें कि जावा प्रोसेस के फ़ॉन्ट फ़ोल्डर तक पहुँच दिया गया है।  

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

## **अपवाद: NoClassDefFoundError: क्लास com.aspose.slides.internal.ey.this को प्रारम्भ नहीं किया जा सका**

यह अपवाद उन Linux सिस्टमों पर आता है जिनमें fontconfig और फ़ॉन्ट नहीं हैं। 

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

इसके अतिरिक्त, कुछ open‑jdk संस्करण (उदाहरण के लिये **alpine JDK**) को भी **स्थापित फ़ॉन्ट की आवश्यकता होती है**।

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

## **अपवाद: UnsatisfiedLinkError: libfreetype.so.6: साझा ऑब्जेक्ट फ़ाइल नहीं खोल सकता: ऐसी फ़ाइल या डायरेक्टरी नहीं है**

यह अपवाद उन Linux सिस्टमों पर उत्पन्न होता है जिनमें libfreetype लाइब्रेरी अनुपलब्ध है। 

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

{{% alert title="सलाह" color="info" %}} 
फ़ॉन्ट स्थापित करना या FontsLoader का उपयोग करना न भूलें।
{{% /alert %}}