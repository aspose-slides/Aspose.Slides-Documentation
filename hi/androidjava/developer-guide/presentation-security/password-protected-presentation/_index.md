---
title: एंड्रॉइड पर पासवर्ड के साथ प्रस्तुतियों को सुरक्षित करें
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/androidjava/password-protected-presentation/
keywords:
- PowerPoint को लॉक करें
- प्रेजेंटेशन को लॉक करें
- PowerPoint को अनलॉक करें
- प्रेजेंटेशन को अनलॉक करें
- PowerPoint को सुरक्षित करें
- प्रेजेंटेशन को सुरक्षित करें
- पासवर्ड सेट करें
- पासवर्ड जोड़ें
- PowerPoint को एन्क्रिप्ट करें
- प्रेजेंटेशन को एन्क्रिप्ट करें
- PowerPoint को डिक्रिप्ट करें
- प्रेजेंटेशन को डिक्रिप्ट करें
- राइट प्रोटेक्शन
- PowerPoint सुरक्षा
- प्रेजेंटेशन सुरक्षा
- पासवर्ड हटाएं
- प्रोटेक्शन हटाएं
- एन्क्रिप्शन हटाएं
- पासवर्ड निष्क्रिय करें
- प्रोटेक्शन निष्क्रिय करें
- राइट प्रोटेक्शन हटाएं
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ Java के जरिए पासवर्ड-संरक्षित PowerPoint और OpenDocument प्रस्तुतियों को आसानी से लॉक और अनलॉक करें। अपनी प्रस्तुतियों को सुरक्षित रखें।"
---
## **परिचय**

जब आप किसी प्रस्तुति को पासवर्ड से सुरक्षित करते हैं, तो इसका अर्थ है कि आप एक पासवर्ड सेट कर रहे हैं जो प्रस्तुति पर कुछ प्रतिबंध लागू करता है। प्रतिबंध हटाने के लिए पासवर्ड दर्ज करना आवश्यक है। पासवर्ड-सेक्योर की गई प्रस्तुति को लॉक्ड प्रस्तुति माना जाता है।

आमतौर पर, आप एक पासवर्ड सेट करके इन प्रतिबंधों को लागू कर सकते हैं:

- **संशोधन**

  यदि आप केवल कुछ उपयोगकर्ताओं को अपनी प्रस्तुति में परिवर्तन करने की अनुमति देना चाहते हैं, तो आप एक संशोधन प्रतिबंध सेट कर सकते हैं। यह प्रतिबंध लोगों को आपकी प्रस्तुति में संशोधित करने, बदलने या कॉपी करने से रोकता है (जब तक वे पासवर्ड प्रदान न करें)।

  हालाँकि, इस स्थिति में, पासवर्ड के बिना भी उपयोगकर्ता आपका दस्तावेज़ एक्सेस कर सकेगा और इसे खोल सकेगा। इस केवल‑पढ़ने के मोड में, उपयोगकर्ता प्रस्तुति की सामग्री या चीज़ें—हाइपरलिंक्स, एनीमेशन, इफ़ेक्ट्स और अन्य—दिखा सकता है, लेकिन वह आइटम कॉपी नहीं कर सकता या प्रस्तुति को सेव नहीं कर सकता।

- **खोलना**

  यदि आप केवल कुछ उपयोगकर्ताओं को अपनी प्रस्तुति खोलने की अनुमति देना चाहते हैं, तो आप एक खोलने का प्रतिबंध सेट कर सकते हैं। यह प्रतिबंध लोगों को आपकी प्रस्तुति की सामग्री देखने से ही रोकता है (जब तक वे पासवर्ड प्रदान न करें)।

  तकनीकी रूप से, खोलने का प्रतिबंध उपयोगकर्ताओं को आपकी प्रस्तुति को बदलने से भी रोकता है: जब लोग प्रस्तुति नहीं खोल सकते, तो वे इसे संशोधित या परिवर्तन नहीं कर सकते।

**नोट** कि जब आप खोलने को रोकने के लिए प्रस्तुति को पासवर्ड से सुरक्षित करते हैं, तो प्रस्तुति फ़ाइल एन्क्रिप्ट हो जाती है।

## **Aspose.Slides में प्रस्तुतियों के लिए पासवर्ड सुरक्षा**
**समर्थित फ़ॉर्मैट्स**

Aspose.Slides पासवर्ड सुरक्षा, एन्क्रिप्शन और समान ऑपरेशन्स को इन फ़ॉर्मैट्स में प्रस्तुतियों के लिए समर्थन करता है:

- PPTX and PPT - Microsoft PowerPoint प्रस्तुति
- ODP - OpenDocument प्रस्तुति
- OTP - OpenDocument प्रस्तुति टेम्प्लेट

**समर्थित ऑपरेशन्स**

Aspose.Slides आपको पासवर्ड सुरक्षा का उपयोग करके प्रस्तुतियों में संशोधनों को रोकने की अनुमति देता है:

- प्रस्तुति को एन्क्रिप्ट करना
- प्रस्तुति पर लिखने की सुरक्षा सेट करना

**अन्य ऑपरेशन्स**

Aspose.Slides आपको पासवर्ड सुरक्षा और एन्क्रिप्शन से संबंधित अन्य कार्य करने की अनुमति देता है:

- प्रस्तुति को डिक्रिप्ट करना; एन्क्रिप्टेड प्रस्तुति खोलना
- एन्क्रिप्शन हटाना; पासवर्ड सुरक्षा निष्क्रिय करना
- प्रस्तुति से लिखने की सुरक्षा हटाना
- एन्क्रिप्टेड प्रस्तुति की गुण प्राप्त करना
- जाँचना कि प्रस्तुति एन्क्रिप्टेड है या नहीं
- जाँचना कि प्रस्तुति पासवर्ड‑प्रोटेक्टेड है या नहीं।

## **प्रस्तुति को एन्क्रिप्ट करें**

आप पासवर्ड सेट करके एक प्रस्तुति को एन्क्रिप्ट कर सकते हैं। फिर, लॉक्ड प्रस्तुति को संशोधित करने के लिए उपयोगकर्ता को पासवर्ड प्रदान करना होगा।

एक प्रस्तुति को एन्क्रिप्ट या पासवर्ड‑प्रोटेक्ट करने के लिए, आपको encrypt मेथड (from [IProtectionManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager)) का उपयोग करके प्रस्तुति के लिए पासवर्ड सेट करना होगा। आप पासवर्ड को encrypt मेथड को पास करते हैं और अब एन्क्रिप्टेड प्रस्तुति को सेव करने के लिए save मेथड का उपयोग करते हैं।

यह नमूना कोड आपको दिखाता है कि प्रस्तुति को कैसे एन्क्रिप्ट किया जाए:

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

आप प्रस्तुति में “Do not modify” जैसा निशान जोड़ सकते हैं। इस तरह, आप उपयोगकर्ताओं को बता सकते हैं कि आप चाहते हैं कि वे प्रस्तुति में बदलाव न करें।

**नोट** कि लिखने की सुरक्षा प्रक्रिया प्रस्तुति को एन्क्रिप्ट नहीं करती। इसलिए, उपयोगकर्ता—यदि वह वास्तव में चाहें—प्रस्तुति को संशोधित कर सकते हैं, लेकिन परिवर्तन को सेव करने के लिए उन्हें अलग नाम से प्रस्तुति बनानी होगी।

लिखने की सुरक्षा सेट करने के लिए, आपको [setWriteProtection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) मेथड का उपयोग करना होगा। यह नमूना कोड आपको दिखाता है कि प्रस्तुति पर लिखने की सुरक्षा कैसे सेट की जाए:

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

Aspose.Slides आपको सही पासवर्ड को [LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) के माध्यम से पास करके एन्क्रिप्टेड प्रस्तुति लोड करने की अनुमति देता है।

यह नमूना कोड आपको दिखाता है कि एन्क्रिप्टेड प्रस्तुति को कैसे खोलें:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति के साथ कार्य करें
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **प्रस्तुति से एन्क्रिप्शन हटाएँ**

आप प्रस्तुति से एन्क्रिप्शन या पासवर्ड सुरक्षा हटाया जा सकता है। इस तरह, उपयोगकर्ता बिना किसी प्रतिबंध के प्रस्तुति तक पहुँच या उसे संशोधित कर सकते हैं।

एन्क्रिप्शन या पासवर्ड सुरक्षा हटाने के लिए, आपको [removeEncryption](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) मेथड को कॉल करना होगा। यह नमूना कोड आपको दिखाता है कि प्रस्तुति से एन्क्रिप्शन कैसे हटाया जाए:

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

आप Aspose.Slides का उपयोग करके प्रस्तुति फ़ाइल पर लागू लिखने की सुरक्षा को हटा सकते हैं। इस तरह, उपयोगकर्ता अपनी इच्छानुसार संशोधन कर सकते हैं—और उन्हें कोई चेतावनी नहीं मिलती।

आप [removeWriteProtection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) मेथड का उपयोग करके प्रस्तुति से लिखने की सुरक्षा हटा सकते हैं। यह नमूना कोड आपको दिखाता है कि लिखने की सुरक्षा कैसे हटाई जाए:

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

## **एन्क्रिप्टेड प्रस्तुति की गुण प्राप्त करें**

आमतौर पर, उपयोगकर्ताओं को एन्क्रिप्टेड या पासवर्ड‑प्रोटेक्टेड प्रस्तुति के दस्तावेज़ गुण प्राप्त करने में कठिनाई होती है। हालांकि, Aspose.Slides एक ऐसा तंत्र प्रदान करता है जो उपयोगकर्ताओं को पासवर्ड सुरक्षा होने के बावजूद उसकी गुणों तक पहुँच की अनुमति देता है।

**नोट:** डिफ़ॉल्ट रूप से, जब Aspose.Slides किसी प्रस्तुति को एन्क्रिप्ट करता है, तो प्रस्तुति के दस्तावेज़ गुण भी पासवर्ड‑प्रोटेक्टेड होते हैं। यदि आप एन्क्रिप्शन के बाद भी दस्तावेज़ गुणों को सुलभ बनाना चाहते हैं, तो Aspose.Slides यह करने की अनुमति देता है।

यदि आप चाहते हैं कि उपयोगकर्ता एन्क्रिप्टेड प्रस्तुति के गुणों तक पहुँच बनाए रखें, तो आप [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) को `false` पास कर सकते हैं। यह नमूना कोड आपको दिखाता है कि कैसे प्रस्तुति को एन्क्रिप्ट करके भी उपयोगकर्ताओं को उसके दस्तावेज़ गुणों तक पहुँच प्रदान करें:

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

## **एन्क्रिप्टेड प्रस्तुति से केवल दस्तावेज़ गुण लोड करें**

एन्क्रिप्टेड प्रस्तुति के स्लाइड्स या अन्य सामग्री को लोड किए बिना उसके मेटाडेटा का निरीक्षण करने के लिए, एक [LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) ऑब्जेक्ट बनायें और `true` को [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) को पास करें। इस मोड में, Aspose.Slides पासवर्ड को अनदेखा करता है और केवल सार्वजनिक रूप से सुलभ दस्तावेज़ गुणों को लोड करता है।

निम्नलिखित कोड उदाहरण [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) के माध्यम से बिल्ट‑इन और कस्टम दस्तावेज़ गुणों को पढ़ता है:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // बिल्ट-इन दस्तावेज़ गुण पढ़ें।
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // कस्टम दस्तावेज़ गुण पढ़ें।
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

यह वर्कफ़्लो केवल तब काम करता है जब प्रस्तुति एन्क्रिप्ट किए जाने पर दस्तावेज़ गुण अनएन्क्रिप्टेड (सार्वजनिक) रहे हों। यदि दस्तावेज़ गुण एन्क्रिप्टेड हैं, तो `loadOptions.setOnlyLoadDocumentProperties` को `true` पास करने से एक अपवाद उठाया जाता है क्योंकि इस मोड में पासवर्ड अनदेखा किया जाता है। एन्क्रिप्टेड दस्तावेज़ गुणों तक पहुँचने या पूर्ण प्रस्तुति (स्लाइड्स एवं अन्य सामग्री सहित) लोड करने के लिए, सही पासवर्ड को [ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) के माध्यम से प्रदान करें।

## **जांचें कि प्रस्तुति पासवर्ड‑प्रोटेक्टेड है या नहीं**

प्रस्तुति लोड करने से पहले, आप यह जाँचना चाह सकते हैं कि प्रस्तुति पासवर्ड से सुरक्षित है या नहीं। इस तरह, आप उन त्रुटियों और समान समस्याओं से बच सकते हैं, जो पासवर्ड‑प्रोटेक्टेड प्रस्तुति को उसके पासवर्ड के बिना लोड करने पर उत्पन्न होती हैं।

यह Java कोड आपको दिखाता है कि प्रस्तुति को बिना स्वयं लोड किए यह जांचें कि वह पासवर्ड‑प्रोटेक्टेड है या नहीं:

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **जांचें कि प्रस्तुति एन्क्रिप्टेड है या नहीं**

Aspose.Slides आपको यह जाँचने की अनुमति देता है कि प्रस्तुति एन्क्रिप्टेड है या नहीं। इस कार्य को करने के लिए, आप [isEncrypted](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) प्रॉपर्टी का उपयोग कर सकते हैं, जो प्रस्तुति एन्क्रिप्टेड होने पर `true` और न होने पर `false` लौटाती है।

यह नमूना कोड आपको दिखाता है कि प्रस्तुति एन्क्रिप्टेड है या नहीं कैसे जाँचें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **जांचें कि प्रस्तुति लिखने‑प्रोटेक्टेड है या नहीं**

Aspose.Slides आपको यह जाँचने की अनुमति देता है कि प्रस्तुति लिखने‑प्रोटेक्टेड है या नहीं। इस कार्य को करने के लिए, आप [isWriteProtected](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) प्रॉपर्टी का उपयोग कर सकते हैं, जो प्रस्तुति लिखने‑प्रोटेक्टेड होने पर `true` और न होने पर `false` लौटाती है।

यह नमूना कोड आपको दिखाता है कि प्रस्तुति लिखने‑प्रोटेक्टेड है या नहीं कैसे जाँचें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **सुनिश्चित करें कि एक विशिष्ट पासवर्ड उपयोग किया गया है**

आप यह जाँचना और पुष्टि करना चाह सकते हैं कि किसी प्रस्तुति को सुरक्षित करने के लिए एक विशिष्ट पासवर्ड उपयोग किया गया था। Aspose.Slides आपको पासवर्ड की वैधता जांचने की सुविधा देता है।

यह नमूना कोड आपको दिखाता है कि पासवर्ड कैसे वैध किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // जाँचें कि "pass" पासवर्ड से मेल खाता है
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

यह `true` लौटाता है यदि प्रस्तुति निर्दिष्ट पासवर्ड से लिखने‑प्रोटेक्टेड थी। अन्यथा, यह `false` लौटाता है।

{{% alert color="info" title="See also" %}} 
- [PowerPoint में डिजिटल हस्ताक्षर](/slides/hi/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides द्वारा कौन से एन्क्रिप्शन मेथड्स समर्थित हैं?**

Aspose.Slides आधुनिक एन्क्रिप्शन मेथड्स, जिसमें AES‑आधारित एल्गोरिदम शामिल हैं, को समर्थन देता है, जिससे आपके प्रस्तुतियों की डेटा सुरक्षा उच्च स्तर की रहती है।

**जब प्रस्तुति खोलने का प्रयास करते समय गलत पासवर्ड दर्ज किया जाता है तो क्या होता है?**

गलत पासवर्ड उपयोग करने पर एक अपवाद उत्पन्न होता है, जो दर्शाता है कि प्रस्तुति तक पहुँच इनकार की गई है। यह अनधिकृत पहुँच को रोकने और प्रस्तुति सामग्री की सुरक्षा में मदद करता है।

**क्या पासवर्ड‑प्रोटेक्टेड प्रस्तुतियों के साथ काम करने पर प्रदर्शन पर कोई प्रभाव पड़ता है?**

एन्क्रिप्शन और डिक्रिप्शन प्रक्रिया खोलने और सेव करने के दौरान थोड़ा अतिरिक्त ओवरहेड जोड़ सकती है। अधिकांश मामलों में, यह प्रदर्शन प्रभाव न्यूनतम होता है और आपके प्रस्तुति कार्यों के कुल प्रसंस्करण समय को महत्वपूर्ण रूप से प्रभावित नहीं करता।