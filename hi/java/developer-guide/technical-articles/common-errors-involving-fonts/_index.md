---
title: Linux में फ़ॉन्ट से संबंधित सामान्य अपवर्जन और त्रुटियाँ
type: docs
weight: 200
url: /hi/java/common-errors-involving-fonts/
keywords: "फ़ॉन्ट अपवर्जन, फ़ॉन्ट त्रुटि, Linux, Java, Aspose.Slides for Java"
description: "Linux पर फ़ॉन्ट अपवर्जन और त्रुटियाँ"
---
## **सारांश**

जब Aspose.Slides को Linux पर उपयोग किया जाता है, तो फ़ॉन्ट‑संबंधी समस्याएँ उत्पन्न हो सकती हैं यदि Java प्रक्रिया आवश्यक फ़ॉन्ट फ़ोल्डर या TEMP निर्देशिका तक पहुँच नहीं सकती, यदि सिस्टम पर कोई फ़ॉन्ट स्थापित नहीं है, या यदि आवश्यक सिस्टम लाइब्रेरी जैसे fontconfig या libfreetype अनुपलब्ध हैं।

यह लेख Linux पर फ़ॉन्ट से संबंधित सामान्य त्रुटियों और अपवर्जन को बताता है और उन्हें हल करने के लिए समाधान प्रदान करता है। यह समझाता है कि फ़ॉन्ट और TEMP निर्देशिकाओं तक पहुँच की जाँच कैसे करें, आवश्यक फ़ॉन्ट और लाइब्रेरी को स्थापित करें, और `FontsLoader` का उपयोग करके फ़ॉन्ट को सिस्टम‑व्यापी स्थापित किए बिना लोड करें।

## **जब कोड Linux पर निष्पादित किया जाता है तो टेक्स्ट या छवियां (EMF या WMF) गायब होती हैं**

यह समस्या उन सिस्टम में होती है जहाँ निम्नलिखित प्रतिबंध होते हैं:

1. जब कोई फ़ॉन्ट स्थापित नहीं है या java प्रक्रिया के लिए फ़ॉन्ट फ़ोल्डर तक पहुँच नहीं सकती
2. जब TEMP निर्देशिका तक पहुँच नहीं सकती।

### **समाधान**

जाँचें और पुष्टि करें कि TEMP निर्देशिका और फ़ॉन्ट फ़ोल्डर तक पहुँच प्रदान की गई है। 

{{% alert color="warning" %}}
कुछ मामलों में, पर्यावरण या सुरक्षा नीति द्वारा लगाए गए प्रतिबंधों के कारण फ़ोल्डर तक पहुँच प्रदान करना संभव नहीं हो सकता। इन वैकल्पिक उपायों को आज़माएँ: 
{{% /alert %}}

**Workaround**

[FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsLoader) का उपयोग करके आवश्यक फ़ॉन्ट को बिना स्थापित किए लोड करें:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

यदि TEMP निर्देशिका तक पहुँच नहीं सकती, तो Java के लिए TEMP के रूप में कोई अन्य निर्देशिका निर्दिष्ट करने हेतु नीचे दिया गया कोड उपयोग करें:
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

## **Exception: InvalidOperationException: सिस्टम पर कोई भी फ़ॉन्ट स्थापित नहीं मिला**

यह अपवर्जन तब होता है जब

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

   * [FontsLoader](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FontsLoader) का उपयोग करके: 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Exception: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

यह अपवर्जन एक ऐसे Linux सिस्टम पर होता है जिसमें fontconfig और फ़ॉन्ट नहीं हैं। 

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

इसके अतिरिक्त, कुछ open‑jdk संस्करण (जैसे **alpine JDK**) को भी **स्थापित फ़ॉन्ट की आवश्यकता होती है**।

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

## **Exception: UnsatisfiedLinkError: libfreetype.so.6: Cannot Open Shared Object File: No Such File or Directory**

यह अपवर्जन एक ऐसे Linux सिस्टम पर होता है जिसमें libfreetype लाइब्रेरी नहीं है। 

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