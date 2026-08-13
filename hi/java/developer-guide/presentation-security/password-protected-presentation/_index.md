---
title: Java में पासवर्ड के साथ प्रस्तुतियों को सुरक्षित रखें
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/java/password-protected-presentation/
keywords:
- PowerPoint को लॉक करें
- प्रस्तुति को लॉक करें
- PowerPoint को अनलॉक करें
- प्रस्तुति को अनलॉक करें
- PowerPoint की सुरक्षा करें
- प्रस्तुति की सुरक्षा करें
- पासवर्ड सेट करें
- पासवर्ड जोड़ें
- PowerPoint को एन्क्रिप्ट करें
- प्रस्तुति को एन्क्रिप्ट करें
- PowerPoint को डिक्रिप्ट करें
- प्रस्तुति को डिक्रिप्ट करें
- लिखने की सुरक्षा
- PowerPoint सुरक्षा
- प्रस्तुति सुरक्षा
- पासवर्ड हटाएँ
- सुरक्षा हटाएँ
- एन्क्रिप्शन हटाएँ
- पासवर्ड निष्क्रिय करें
- सुरक्षा निष्क्रिय करें
- लिखने की सुरक्षा हटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ पासवर्ड‑सुरक्षित PowerPoint और OpenDocument प्रस्तुतियों को आसानी से लॉक और अनलॉक करना सीखें। अपनी प्रस्तुतियों को सुरक्षित रखें।"
---
## **परिचय**

जब आप एक प्रस्तुति को पासवर्ड‑प्रोटेक्ट करते हैं, तो इसका मतलब है कि आप एक पासवर्ड सेट कर रहे हैं जो प्रस्तुति पर कुछ प्रतिबंध लागू करता है। इन प्रतिबंधों को हटाने के लिए पासवर्ड दर्ज करना आवश्यक है। पासवर्ड‑प्रोटेक्टेड प्रस्तुति को लॉक्ड प्रस्तुति माना जाता है।

आमतौर पर, आप प्रस्तुति पर इन प्रतिबंधों को लागू करने के लिए पासवर्ड सेट कर सकते हैं:

- **संशोधन**

यदि आप केवल कुछ उपयोगकर्ताओं को अपनी प्रस्तुति को संशोधित करने की अनुमति देना चाहते हैं, तो आप एक संशोधन प्रतिबंध सेट कर सकते हैं। यह प्रतिबंध लोगों को आपके पासवर्ड के बिना आपके प्रस्तुति के घटकों को संशोधित, बदल या कॉपी करने से रोकता है।  

हालाँकि, पासवर्ड के बिना भी उपयोगकर्ता आपका दस्तावेज़ खोल और एक्सेस कर सकता है। इस केवल‑पढ़ने‑योग्य मोड में, उपयोगकर्ता सामग्री—हाइपरलिंक, एनीमेशन, इफ़ेक्ट और अन्य तत्व—देख सकता है, लेकिन वह आइटम कॉपी नहीं कर सकता या प्रस्तुति को सहेज नहीं सकता।

- **खोलना**

यदि आप केवल कुछ उपयोगकर्ताओं को अपनी प्रस्तुति खोलने की अनुमति देना चाहते हैं, तो आप एक खोलने का प्रतिबंध सेट कर सकते हैं। यह प्रतिबंध लोगों को आपके पासवर्ड के बिना आपकी प्रस्तुति की सामग्री देखने से रोकता है।  

तकनीकी रूप से, खोलने का प्रतिबंध उपयोगकर्ताओं को आपकी प्रस्तुतियों को संशोधित करने से भी रोकता है—यदि लोग प्रस्तुति नहीं खोल सकते, तो वे उसे संशोधित या बदल नहीं सकते।

**नोट:** जब आप किसी प्रस्तुति को खोलने से रोकने के लिए पासवर्ड‑प्रोटेक्ट करते हैं, तो प्रस्तुति फ़ाइल एन्क्रिप्ट हो जाती है।

## **Aspose.Slides में पासवर्ड प्रोटेक्शन**
**समर्थित फ़ॉर्मेट**

Aspose.Slides इन फ़ॉर्मेटों में प्रस्तुतियों के लिए पासवर्ड प्रोटेक्शन, एन्क्रिप्शन और समान कार्यों को सपोर्ट करता है:

- PPTX और PPT - Microsoft PowerPoint Presentation  
- ODP - OpenDocument Presentation  
- OTP - OpenDocument Presentation Template  

**समर्थित ऑपरेशन्स**

Aspose.Slides आपको निम्नलिखित तरीकों से प्रस्तुतियों को संशोधन से बचाने के लिए पासवर्ड प्रोटेक्शन उपयोग करने की अनुमति देता है:

- प्रस्तुति को एन्क्रिप्ट करना  
- प्रस्तुति पर लिखने की सुरक्षा सेट करना  

**अन्य ऑपरेशन्स**

Aspose.Slides आपको पासवर्ड प्रोटेक्शन और एन्क्रिप्शन से संबंधित अन्य कार्य करने की अनुमति देता है:

- प्रस्तुति को डिक्रिप्ट करना; एन्क्रिप्टेड प्रस्तुति खोलना  
- एन्क्रिप्शन हटाना; पासवर्ड प्रोटेक्शन निष्क्रिय करना  
- प्रस्तुति से लिखने की सुरक्षा हटाना  
- एन्क्रिप्टेड प्रस्तुति की प्रॉपर्टीज़ प्राप्त करना  
- यह जांचना कि प्रस्तुति एन्क्रिप्टेड है या नहीं  
- यह जांचना कि प्रस्तुति पासवर्ड‑प्रोटेक्टेड है या नहीं।  

## **पासवर्ड से प्रस्तुति को प्रोटेक्ट करें**

आप पासवर्ड सेट करके एक प्रस्तुति को एन्क्रिप्ट कर सकते हैं। फिर, लॉक्ड प्रस्तुति को संशोधित करने के लिए उपयोगकर्ता को पासवर्ड प्रदान करना होगा।  

एक प्रस्तुति को एन्क्रिप्ट या पासवर्ड‑प्रोटेक्ट करने के लिए, आपको encrypt मेथड (from [IProtectionManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager)) का उपयोग करके प्रस्तुति के लिए पासवर्ड सेट करना होगा। आप पासवर्ड को encrypt मेथड में पास करते हैं और अब एन्क्रिप्टेड प्रस्तुति को सहेजने के लिए save मेथड का उपयोग करते हैं।  

यह नमूना कोड दिखाता है कि आप प्रस्तुति को कैसे एन्क्रिप्ट करते हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **प्रस्तुति पर लिखने की सुरक्षा सेट करें**

आप प्रस्तुति में “Do not modify” जैसा चिह्न जोड़ सकते हैं। इससे आप उपयोगकर्ताओं को बता सकते हैं कि आप उनके द्वारा परिवर्तन न करने को चाहते हैं।  

**नोट** कि लिखने की सुरक्षा प्रक्रिया प्रस्तुति को एन्क्रिप्ट नहीं करती। इसलिए, उपयोगकर्ता—यदि वे चाहें—प्रस्तुति को संशोधित कर सकते हैं, लेकिन परिवर्तन को सहेजने के लिए उन्हें अलग नाम वाली प्रस्तुति बनानी होगी।  

लिखने की सुरक्षा सेट करने के लिए, आपको [setWriteProtection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) मेथड का उपयोग करना होगा। यह नमूना कोड दिखाता है कि आप प्रस्तुति पर लिखने की सुरक्षा कैसे सेट करते हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रस्तुति लोड करें**

Aspose.Slides आपको सही पासवर्ड को [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) के माध्यम से पास करके एन्क्रिप्टेड प्रस्तुति लोड करने की अनुमति देता है।  

यह नमूना कोड दिखाता है कि आप एन्क्रिप्टेड प्रस्तुति को कैसे लोड करते हैं:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति के साथ काम करें
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **प्रस्तुति से एन्क्रिप्शन हटाएँ**

आप प्रस्तुति से एन्क्रिप्शन या पासवर्ड प्रोटेक्शन को हटा सकते हैं। इस तरह, उपयोगकर्ता बिना किसी प्रतिबंध के प्रस्तुति तक पहुंच या उसे संशोधित कर सकते हैं।  

एन्क्रिप्शन या पासवर्ड प्रोटेक्शन हटाने के लिए, आपको [removeEncryption](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#removeEncryption--) मेथड को कॉल करना होगा। यह नमूना कोड दिखाता है कि आप प्रस्तुति से एन्क्रिप्शन कैसे हटाते हैं:

```java
import com.aspose.slides.*;

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

## **प्रस्तुति से लिखने की सुरक्षा हटाएँ**

आप Aspose.Slides का उपयोग करके प्रस्तुति फ़ाइल पर लागू लिखने की सुरक्षा को हटा सकते हैं। इस तरह, उपयोगकर्ता अपनी इच्छा अनुसार संशोधन कर सकते हैं—और जब वे ऐसा करेंगे तो उन्हें कोई चेतावनी नहीं मिलेगी।  

आप लिखने की सुरक्षा को [removeWriteProtection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) मेथड का उपयोग करके हटा सकते हैं। यह नमूना कोड दिखाता है कि आप प्रस्तुति से लिखने की सुरक्षा कैसे हटाते हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रस्तुति की प्रॉपर्टीज़ प्राप्त करें**

आमतौर पर, उपयोगकर्ताओं को एन्क्रिप्टेड या पासवर्ड‑प्रोटेक्टेड प्रस्तुति की दस्तावेज़ प्रॉपर्टीज़ पुनः प्राप्त करने में कठिनाई होती है। फिर भी, Aspose.Slides एक ऐसा तंत्र प्रदान करता है जिससे आप प्रस्तुति को पासवर्ड‑प्रोटेक्ट कर सकते हैं जबकि उपयोगकर्ता अभी भी उसकी प्रॉपर्टीज़ एक्सेस कर सकें।  

**नोट:** डिफ़ॉल्ट रूप से, जब Aspose.Slides एक प्रस्तुति को एन्क्रिप्ट करता है, तो प्रस्तुति की दस्तावेज़ प्रॉपर्टीज़ भी पासवर्ड‑प्रोटेक्ट हो जाती हैं। यदि आप एन्क्रिप्शन के बाद भी दस्तावेज़ प्रॉपर्टीज़ को सुलभ बनाना चाहते हैं, तो Aspose.Slides यह करने की अनुमति देता है।  

यदि आप चाहते हैं कि उपयोगकर्ता एन्क्रिप्टेड प्रस्तुति की प्रॉपर्टीज़ तक पहुंच बना रखें, तो [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) को `false` पास करें। यह नमूना कोड दिखाता है कि आप प्रस्तुति को एन्क्रिप्ट करते हुए भी उपयोगकर्ताओं को दस्तावेज़ प्रॉपर्टीज़ कैसे प्रदान करते हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रस्तुति से केवल दस्तावेज़ प्रॉपर्टीज़ लोड करें**

एन्क्रिप्टेड प्रस्तुति की स्लाइड्स या अन्य सामग्री को लोड किए बिना उसके मेटाडेटा की जांच करने के लिए, एक [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) ऑब्जेक्ट बनाएं और `true` को [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) को पास करें। इस मोड में, Aspose.Slides पासवर्ड को अनदेखा करता है और केवल सार्वजनिक रूप से सुलभ दस्तावेज़ प्रॉपर्टीज़ लोड करता है।  

निम्न कोड उदाहरण [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getDocumentProperties--) के माध्यम से बिल्ट‑इन और कस्टम दस्तावेज़ प्रॉपर्टीज़ पढ़ता है:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // बिल्ट‑इन दस्तावेज़ प्रॉपर्टीज़ पढ़ें।
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

यह वर्कफ़्लो केवल तब काम करता है जब प्रस्तुति एन्क्रिप्ट होने के दौरान दस्तावेज़ प्रॉपर्टीज़ अनएन्क्रिप्टेड (सार्वजनिक) रखी गई हों। यदि दस्तावेज़ प्रॉपर्टीज़ एन्क्रिप्टेड हैं, तो `loadOptions.setOnlyLoadDocumentProperties` को `true` पास करने पर एक एक्सेप्शन उत्पन्न होता है क्योंकि इस मोड में पासवर्ड अनदेखा किया जाता है। एन्क्रिप्टेड दस्तावेज़ प्रॉपर्टीज़ तक पहुंचने या स्लाइड्स व अन्य सामग्री सहित पूरी प्रस्तुति लोड करने के लिए, सही पासवर्ड को [ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) के माध्यम से प्रदान करें।

## **जांचें कि क्या प्रस्तुति पासवर्ड‑प्रोटेक्टेड है**

प्रेजेंटेशन लोड करने से पहले, आप यह जांचना चाह सकते हैं कि प्रस्तुति पासवर्ड से सुरक्षित है या नहीं। इस तरह, आप उन त्रुटियों और समान समस्याओं से बच सकते हैं जो पासवर्ड‑प्रोटेक्टेड प्रस्तुति को उसके पासवर्ड के बिना लोड करने पर आती हैं।  

यह Java कोड दिखाता है कि आप प्रस्तुति को लोड किए बिना यह कैसे जांचते हैं कि वह पासवर्ड‑प्रोटेक्टेड है या नहीं:

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **जांचें कि क्या प्रस्तुति एन्क्रिप्टेड है**

Aspose.Slides आपको यह जांचने की सुविधा देता है कि प्रस्तुति एन्क्रिप्टेड है या नहीं। इस कार्य को करने के लिए, आप [isEncrypted](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#isEncrypted--) प्रॉपर्टी का उपयोग कर सकते हैं, जो `true` लौटाती है यदि प्रस्तुति एन्क्रिप्टेड है और `false` यदि नहीं।  

यह नमूना कोड दिखाता है कि आप यह कैसे जांचते हैं कि प्रस्तुति एन्क्रिप्टेड है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **जांचें कि क्या प्रस्तुति लिखने‑प्रोटेक्टेड है**

Aspose.Slides आपको यह जांचने की अनुमति देता है कि प्रस्तुति लिखने‑प्रोटेक्टेड है या नहीं। इस कार्य के लिए, आप [isWriteProtected](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#isWriteProtected--) प्रॉपर्टी का उपयोग कर सकते हैं, जो `true` लौटाती है यदि प्रस्तुति लिखने‑प्रोटेक्टेड है और `false` यदि नहीं।  

यह नमूना कोड दिखाता है कि आप यह कैसे जांचते हैं कि प्रस्तुति लिखने‑प्रोटेक्टेड है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **विशिष्ट पासवर्ड का उपयोग किया गया है या नहीं, सत्यापित या पुष्टि करें**

आप यह जांचना और पुष्टि करना चाह सकते हैं कि प्रस्तुति दस्तावेज़ को सुरक्षित करने के लिए कोई विशिष्ट पासवर्ड उपयोग किया गया है या नहीं। Aspose.Slides पासवर्ड को वैधता देने का साधन प्रदान करता है।  

यह नमूना कोड दिखाता है कि आप पासवर्ड को कैसे वैधता देते हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // जाँचें कि "pass" मेल खाता है
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

यह `true` लौटाता है यदि प्रस्तुति निर्दिष्ट पासवर्ड से लिखने‑प्रोटेक्टेड है। अन्यथा यह `false` लौटाता है।

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/hi/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides किन एन्क्रिप्शन विधियों को सपोर्ट करता है?**

Aspose.Slides आधुनिक एन्क्रिप्शन विधियों, जिसमें AES‑आधारित एल्गोरिद्म शामिल हैं, को सपोर्ट करता है, जिससे आपकी प्रस्तुतियों के डेटा की उच्च सुरक्षा सुनिश्चित होती है।

**यदि प्रस्तुति खोलने का प्रयास करते समय गलत पासवर्ड दर्ज किया जाए तो क्या होता है?**

गलत पासवर्ड उपयोग करने पर एक एक्सेप्शन फेंका जाता है, जिससे यह संकेत मिलता है कि प्रस्तुति तक पहुंच प्रतिबंधित है। यह अनधिकृत पहुंच को रोकता है और सामग्री की सुरक्षा करता है।

**क्या पासवर्ड‑प्रोटेक्टेड प्रस्तुतियों के साथ काम करने पर प्रदर्शन पर कोई प्रभाव पड़ता है?**

एन्क्रिप्शन और डिक्रिप्शन प्रक्रिया खोलने और सहेजने के दौरान थोड़ी अतिरिक्त समय लगाती है। अधिकांश मामलों में, यह प्रदर्शन प्रभाव न्यूनतम रहता है और आपके प्रस्तुति कार्यों के कुल कार्य समय पर गहरा असर नहीं डालता।