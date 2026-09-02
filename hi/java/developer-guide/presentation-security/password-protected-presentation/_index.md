---
title: जावा में पासवर्ड के साथ सुरक्षित प्रस्तुतियाँ
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/java/password-protected-presentation/
keywords:
- PowerPoint लॉक करें
- प्रस्तुति लॉक करें
- PowerPoint अनलॉक करें
- प्रस्तुति अनलॉक करें
- PowerPoint सुरक्षित करें
- प्रस्तुति सुरक्षित करें
- पासवर्ड सेट करें
- पासवर्ड जोड़ें
- PowerPoint एन्क्रिप्ट करें
- प्रस्तुति एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति डिक्रिप्ट करें
- राइट प्रोटेक्शन
- PowerPoint सुरक्षा
- प्रस्तुति सुरक्षा
- पासवर्ड हटाएँ
- प्रोटेक्शन हटाएँ
- एन्क्रिप्शन हटाएँ
- पासवर्ड अक्षम करें
- प्रोटेक्शन अक्षम करें
- राइट प्रोटेक्शन हटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ पासवर्ड‑रक्षित PowerPoint और OpenDocument प्रस्तुतियों को आसानी से लॉक और अनलॉक करना सीखें। अपनी प्रस्तुतियों को सुरक्षित करें।"
---
## **परिचय**

जब आप किसी प्रस्तुति को पासवर्ड-रक्षित करते हैं, तो इसका अर्थ है कि आप एक पासवर्ड सेट कर रहे हैं जो प्रस्तुति पर कुछ प्रतिबंध लागू करता है। इन प्रतिबंधों को हटाने के लिए पासवर्ड दर्ज करना आवश्यक है। पासवर्ड-रक्षित प्रस्तुति को लॉक्ड प्रस्तुति माना जाता है।

आम तौर पर, आप प्रस्तुति पर इन प्रतिबंधों को लागू करने के लिए पासवर्ड सेट कर सकते हैं:

- **संशोधन**

यदि आप केवल कुछ उपयोगकर्ताओं को अपनी प्रस्तुति संशोधित करने की अनुमति देना चाहते हैं, तो आप संशोधन प्रतिबंध सेट कर सकते हैं। यह प्रतिबंध लोगों को आपके पासवर्ड के बिना प्रस्तुति के तत्वों को संशोधित, बदल या कॉपी करने से रोकता है।  

हालाँकि, पासवर्ड के बिना भी उपयोगकर्ता आपके दस्तावेज़ को खोल और एक्सेस कर सकेगा। इस केवल-पढ़ने योग्य मोड में, उपयोगकर्ता सामग्री—हाइपरलिंक, एनीमेशन, इफ़ेक्ट और अन्य तत्व—को देख सकता है, लेकिन वह आइटम को कॉपी या प्रस्तुति को सहेज नहीं सकता।

- **खोलना**

यदि आप केवल कुछ उपयोगकर्ताओं को अपनी प्रस्तुति खोलने की अनुमति देना चाहते हैं, तो आप खोलने का प्रतिबंध सेट कर सकते हैं। यह प्रतिबंध लोगों को पासवर्ड के बिना आपकी प्रस्तुति की सामग्री देखने से रोकता है।

तकनीकी रूप से, खोलने का प्रतिबंध उपयोगकर्ताओं को आपकी प्रस्तुति को संशोधित करने से भी रोकता है—यदि कोई प्रस्तुति नहीं खोल सकता, तो वह उसे संशोधित या बदल नहीं सकता।

**नोट:** जब आप किसी प्रस्तुति को खोलने से रोकने के लिए पासवर्ड-रक्षित करते हैं, तो प्रस्तुति फ़ाइल एन्क्रिप्ट हो जाती है।

## **Aspose.Slides में पासवर्ड सुरक्षा**
**समर्थित स्वरूप**

Aspose.Slides इन स्वरूपों में प्रस्तुतियों के लिए पासवर्ड सुरक्षा, एन्क्रिप्शन और समान कार्यों का समर्थन करता है:

- PPTX और PPT - Microsoft PowerPoint Presentation  
- ODP - OpenDocument Presentation  
- OTP - OpenDocument Presentation Template  

**समर्थित संचालन**

Aspose.Slides आपको निम्न तरीकों से प्रस्तुति में संशोधनों को रोकने के लिए पासवर्ड सुरक्षा उपयोग करने की अनुमति देता है:

- प्रस्तुति को एन्क्रिप्ट करना  
- प्रस्तुति में राइट प्रोटेक्शन सेट करना  

**अन्य संचालन**

Aspose.Slides आपको पासवर्ड सुरक्षा और एन्क्रिप्शन से संबंधित अन्य कार्यों को निम्न तरीकों से करने देता है:

- प्रस्तुति को डिक्रिप्ट करना; एन्क्रिप्टेड प्रस्तुति खोलना  
- एन्क्रिप्शन हटाना; पासवर्ड सुरक्षा निष्क्रिय करना  
- प्रस्तुति से राइट प्रोटेक्शन हटाना  
- एन्क्रिप्टेड प्रस्तुति की प्रॉपर्टीज़ प्राप्त करना  
- यह जांचना कि प्रस्तुति एन्क्रिप्टेड है या नहीं  
- यह जांचना कि प्रस्तुति पासवर्ड-रक्षित है या नहीं।  

## **पासवर्ड से प्रस्तुति को सुरक्षित करें**

आप पासवर्ड सेट करके एक प्रस्तुति को एन्क्रिप्ट कर सकते हैं। फिर, लॉक्ड प्रस्तुति को संशोधित करने के लिए उपयोगकर्ता को पासवर्ड प्रदान करना होगा।

एक प्रस्तुति को एन्क्रिप्ट या पासवर्ड-रक्षित करने के लिए आपको encrypt मेथड (from [IProtectionManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager)) का उपयोग करना होगा। आप पासवर्ड को encrypt मेथड में पास करते हैं और save मेथड का उपयोग करके अब एन्क्रिप्ट की गई प्रस्तुति को सहेजते हैं।

यह नमूना कोड दिखाता है कि कैसे एक प्रस्तुति को एन्क्रिप्ट किया जाता है:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **प्रस्तुति में राइट प्रोटेक्शन सेट करें**

आप प्रस्तुति में “Do not modify” लिखित एक चिह्न जोड़ सकते हैं। इस प्रकार, आप उपयोगकर्ताओं को बता सकते हैं कि आप चाहते हैं कि वे प्रस्तुति में बदलाव न करें।  

**नोट** कि राइट प्रोटेक्शन प्रक्रिया प्रस्तुति को एन्क्रिप्ट नहीं करती। इसलिए, उपयोगकर्ता—यदि वे चाहें—तो प्रस्तुति को संशोधित कर सकते हैं, लेकिन बदलावों को सहेजने के लिए उन्हें अलग नाम से नई प्रस्तुति बनानी होगी।

राइट प्रोटेक्शन सेट करने के लिए आपको [setWriteProtection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) मेथड का उपयोग करना होगा। यह नमूना कोड दिखाता है कि कैसे एक प्रस्तुति में राइट प्रोटेक्शन सेट किया जाता है:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रस्तुति लोड करें**

Aspose.Slides आपको एन्क्रिप्टेड फ़ाइल को उसका पासवर्ड पास करके लोड करने की अनुमति देता है। एक प्रस्तुति को डिक्रिप्ट करने के लिए, आपको [removeEncryption](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#removeEncryption--) मेथड को बिना पैरामीटर के कॉल करना होगा। फिर आपको प्रस्तुति को लोड करने के लिए सही पासवर्ड दर्ज करना होगा।  

यह नमूना कोड दिखाता है कि कैसे एक प्रस्तुति को डिक्रिप्ट किया जाता है:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति के साथ काम करें
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **प्रेजेंटेशन से एन्क्रिप्शन हटाएँ**

आप प्रस्तुति से एन्क्रिप्शन या पासवर्ड सुरक्षा को हटाने सकते हैं। इस तरह, उपयोगकर्ता प्रतिबंधों के बिना प्रस्तुति को एक्सेस या संशोधित कर सकते हैं।  

एन्क्रिप्शन या पासवर्ड सुरक्षा हटाने के लिए आपको [removeEncryption](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#removeEncryption--) मेथड को कॉल करना होगा। यह नमूना कोड दिखाता है कि कैसे एक प्रस्तुति से एन्क्रिप्शन हटाया जाता है:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **प्रेजेंटेशन से राइट प्रोटेक्शन हटाएँ**

आप Aspose.Slides का उपयोग करके प्रस्तुति फ़ाइल से लागू राइट प्रोटेक्शन को हटा सकते हैं। इस तरह, उपयोगकर्ता अपनी इच्छा अनुसार संशोधन कर सकते हैं—और उन्हें ऐसे कार्यों के लिए कोई चेतावनी नहीं मिलेगी।  

आप प्रस्तुति से राइट प्रोटेक्शन हटाने के लिए [removeWriteProtection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) मेथड का उपयोग कर सकते हैं। यह नमूना कोड दिखाता है कि कैसे प्रस्तुति से राइट प्रोटेक्शन हटाया जाता है:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रस्तुति की प्रॉपर्टीज़ प्राप्त करें**

आमतौर पर, उपयोगकर्ता एन्क्रिप्टेड या पासवर्ड-रक्षित प्रस्तुति की डाक्यूमेंट प्रॉपर्टीज़ प्राप्त करने में कठिनाई महसूस करते हैं। हालांकि, Aspose.Slides एक तंत्र प्रदान करता है जिससे आप प्रस्तुति को पासवर्ड-रक्षित कर सकते हैं जबकि उपयोगकर्ता को उसकी प्रॉपर्टीज़ तक पहुँच की अनुमति रहती है।  

**नोट:** डिफ़ॉल्ट रूप से, जब Aspose.Slides एक प्रस्तुति को एन्क्रिप्ट करता है, तो प्रस्तुति की डाक्यूमेंट प्रॉपर्टीज़ भी पासवर्ड-रक्षित हो जाती हैं। यदि आप एन्क्रिप्शन के बाद भी डाक्यूमेंट प्रॉपर्टीज़ को सुलभ बनाना चाहते हैं, तो Aspose.Slides यह करने की अनुमति देता है।  

यदि आप चाहते हैं कि उपयोगकर्ता एन्क्रिप्टेड प्रस्तुति की प्रॉपर्टीज़ तक पहुंच बना रखें, तो आपको [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) मेथड में `false` पास करना होगा। यह नमूना कोड दिखाता है कि कैसे आप प्रस्तुति को एन्क्रिप्ट करते हुए भी उपयोगकर्ता को उसकी डाक्यूमेंट प्रॉपर्टीज़ तक पहुँच प्रदान कर सकते हैं:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रस्तुति से केवल डाक्यूमेंट प्रॉपर्टीज़ लोड करें**

एन्क्रिप्टेड प्रस्तुति की स्लाइड्स या अन्य सामग्री को लोड किए बिना उसकी मेटा‑डेटा का निरीक्षण करने के लिए, एक [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) ऑब्जेक्ट बनाएँ और [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` पास करें। इस मोड में, Aspose.Slides पासवर्ड को नज़रअंदाज़ करता है और केवल सार्वजनिक रूप से सुलभ डाक्यूमेंट प्रॉपर्टीज़ लोड करता है।  

निम्न कोड उदाहरण [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getDocumentProperties--) के माध्यम से बिल्ट‑इन और कस्टम डाक्यूमेंट प्रॉपर्टीज़ पढ़ता है:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // बिल्ट-इन दस्तावेज़ प्रॉपर्टीज़ पढ़ें।
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // कस्टम दस्तावेज़ प्रॉपर्टीज़ पढ़ें।
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

यह वर्कफ़्लो केवल तब काम करता है जब प्रस्तुति एन्क्रिप्ट होते समय डाक्यूमेंट प्रॉपर्टीज़ को अनएन्क्रिप्टेड (पब्लिक) छोड़ दिया गया हो। यदि डाक्यूमेंट प्रॉपर्टीज़ एन्क्रिप्टेड हैं, तो `loadOptions.setOnlyLoadDocumentProperties` को `true` पास करने से एक अपवाद उत्पन्न होगा क्योंकि इस मोड में पासवर्ड को नज़रअंदाज़ किया जाता है। एन्क्रिप्टेड डाक्यूमेंट प्रॉपर्टीज़ तक पहुँचने या पूरी प्रस्तुति (स्लाइड्स और अन्य सामग्री सहित) लोड करने के लिए, आपको सही पासवर्ड [ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) के माध्यम से प्रदान करना होगा।

## **जाँचें कि क्या प्रस्तुति पासवर्ड-रक्षित है**

प्रेजेंटेशन लोड करने से पहले आप यह जांचना चाह सकते हैं कि प्रस्तुति पासवर्ड-रक्षित है या नहीं। इस तरह आप उन त्रुटियों और समान समस्याओं से बच सकते हैं, जो तब आती हैं जब पासवर्ड-रक्षित प्रस्तुति को बिना पासवर्ड के लोड किया जाता है।  

यह जावा कोड दिखाता है कि कैसे आप प्रस्तुति की जाँच कर सकते हैं कि वह पासवर्ड-रक्षित है या नहीं (भले ही प्रस्तुति को लोड न किया गया हो):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **जाँचें कि क्या प्रस्तुति एन्क्रिप्टेड है**

Aspose.Slides आपको यह जांचने की अनुमति देता है कि प्रस्तुति एन्क्रिप्टेड है या नहीं। इस कार्य को करने के लिए आप [isEncrypted](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#isEncrypted--) प्रॉपर्टी का उपयोग कर सकते हैं, जो `true` लौटाती है यदि प्रस्तुति एन्क्रिप्टेड है और `false` यदि नहीं।  

यह नमूना कोड दिखाता है कि कैसे यह जाँच की जाती है:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **जाँचें कि क्या प्रस्तुति राइट‑प्रोटेक्टेड है**

Aspose.Slides आपको यह जांचने की अनुमति देता है कि प्रस्तुति राइट‑प्रोटेक्टेड है या नहीं। इस कार्य को करने के लिए आप [isWriteProtected](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#isWriteProtected--) प्रॉपर्टी का उपयोग कर सकते हैं, जो `true` लौटाती है यदि प्रस्तुति एन्क्रिप्टेड है और `false` यदि नहीं।  

यह नमूना कोड दिखाता है कि कैसे यह जाँच की जाती है:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **यह सत्यापित या पुष्टि करें कि कोई विशिष्ट पासवर्ड उपयोग किया गया है**

आप यह जांचना और पुष्टि करना चाह सकते हैं कि किसी विशिष्ट पासवर्ड का उपयोग करके प्रस्तुति दस्तावेज़ को सुरक्षित किया गया है। Aspose.Slides आपको पासवर्ड वैधता जाँचने का तरीका प्रदान करता है।  

यह नमूना कोड दिखाता है कि कैसे पासवर्ड को वैध किया जाता है:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // जाँचें कि "pass" से मेल है
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

यह `true` लौटाता है यदि प्रस्तुति निर्दिष्ट पासवर्ड से एन्क्रिप्टेड है। अन्यथा, यह `false` लौटाता है।  

{{% alert color="primary" title="और देखें" %}} 
- [PowerPoint में डिजिटल हस्ताक्षर](/slides/hi/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides कौन‑से एन्क्रिप्शन मेथड का समर्थन करता है?**

Aspose.Slides आधुनिक एन्क्रिप्शन मेथड, जिसमें AES‑आधारित एल्गोरिदम शामिल हैं, का समर्थन करता है, जिससे आपके प्रस्तुतियों की डेटा सुरक्षा का उच्च स्तर सुनिश्चित होता है।

**यदि प्रस्तुति खोलते समय गलत पासवर्ड दिया जाता है तो क्या होता है?**

यदि गलत पासवर्ड दिया जाता है तो एक अपवाद उत्पन्न होता है, जो सूचित करता है कि प्रस्तुति तक पहुँच अस्वीकार की गई है। यह अनधिकृत पहुँच को रोकने और प्रस्तुति की सामग्री की सुरक्षा में मदद करता है।

**क्या पासवर्ड‑रक्षित प्रस्तुतियों के साथ काम करते समय प्रदर्शन पर कोई प्रभाव पड़ता है?**

एन्क्रिप्शन और डिक्रिप्शन प्रक्रिया खोलने और सहेजने के दौरान थोड़ा ओवरहेड डाल सकती है। अधिकांश मामलों में, यह प्रदर्शन प्रभाव न्यूनतम रहता है और आपके प्रस्तुति कार्यों के कुल प्रोसेसिंग समय को महत्वपूर्ण रूप से नहीं प्रभावित करता।