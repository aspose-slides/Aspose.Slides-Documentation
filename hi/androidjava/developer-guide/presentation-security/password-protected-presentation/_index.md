---
title: Android पर पासवर्ड के साथ सुरक्षित प्रेज़ेंटेशन
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/androidjava/password-protected-presentation/
keywords:
- PowerPoint को लॉक करें
- प्रेज़ेंटेशन को लॉक करें
- PowerPoint को अनलॉक करें
- प्रेज़ेंटेशन को अनलॉक करें
- PowerPoint की सुरक्षा करें
- प्रेज़ेंटेशन की सुरक्षा करें
- पासवर्ड सेट करें
- पासवर्ड जोड़ें
- PowerPoint को एन्क्रिप्ट करें
- प्रेज़ेंटेशन को एन्क्रिप्ट करें
- PowerPoint को डिक्रिप्ट करें
- प्रेज़ेंटेशन को डिक्रिप्ट करें
- लेखन सुरक्षा
- PowerPoint सुरक्षा
- प्रेज़ेंटेशन सुरक्षा
- पासवर्ड हटाएँ
- सुरक्षा हटाएँ
- एन्क्रिप्शन हटाएँ
- पासवर्ड निष्क्रिय करें
- सुरक्षा निष्क्रिय करें
- लेखन सुरक्षा हटाएँ
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के माध्यम से जावा में पासवर्ड-सुरक्षित PowerPoint और OpenDocument प्रेज़ेंटेशन को आसानी से लॉक और अनलॉक करें। अपने प्रेज़ेंटेशन को सुरक्षित रखें।"
---
## **परिचय**

जब आप किसी प्रेज़ेंटेशन को पासवर्ड द्वारा सुरक्षित करते हैं, तो इसका अर्थ है कि आप एक पासवर्ड सेट कर रहे हैं जो प्रेज़ेंटेशन पर कुछ प्रतिबंध लागू करता है। उन प्रतिबंधों को हटाने के लिए पासवर्ड दर्ज करना आवश्यक है। पासवर्ड‑सुरक्षित प्रेज़ेंटेशन को लॉक्ड प्रेज़ेंटेशन माना जाता है।

आमतौर पर, आप प्रेज़ेंटेशन पर इन प्रतिबंधों को लागू करने के लिए पासवर्ड सेट कर सकते हैं:

- **संशोधन**

  यदि आप चाहते हैं कि केवल कुछ उपयोगकर्ता आपके प्रेज़ेंटेशन को संशोधित करें, तो आप संशोधन प्रतिबंध सेट कर सकते हैं। यह प्रतिबंध लोगों को आपके प्रेज़ेंटेशन को बदलने, संशोधित करने या कॉपी करने से रोकता है (जब तक वे पासवर्ड नहीं देते)।

  हालांकि, इस स्थिति में पासवर्ड के बिना भी उपयोगकर्ता आपके दस्तावेज़ को खोल सकता है। इस पढ़ने‑के‑लिए‑केवल मोड में उपयोगकर्ता प्रेज़ेंटेशन की सामग्री—हाइपरलिंक, एनीमेशन, इफ़ेक्ट आदि—को देख सकता है, लेकिन वह आइटम कॉपी नहीं कर सकता या प्रेज़ेंटेशन को सहेज नहीं सकता।

- **खोलना**

  यदि आप चाहते हैं कि केवल कुछ उपयोगकर्ता आपका प्रेज़ेंटेशन खोलें, तो आप खोलने का प्रतिबंध सेट कर सकते हैं। यह प्रतिबंध लोगों को आपके प्रेज़ेंटेशन की सामग्री देखने से रोकता है (जब तक वे पासवर्ड नहीं देते)।

  तकनीकी रूप से, खोलने का प्रतिबंध उपयोगकर्ताओं को आपके प्रेज़ेंटेशन को संशोधित करने से भी रोकता है: जब लोग प्रेज़ेंटेशन नहीं खोल सकते, तो वे उसमें बदलाव नहीं कर सकते।  

  **नोट** कि जब आप प्रेज़ेंटेशन को खोलने से रोकने के लिए पासवर्ड लगाते हैं, तो प्रेज़ेंटेशन फ़ाइल एन्क्रिप्ट हो जाती है।

## **Aspose.Slides में प्रेज़ेंटेशन्स के लिए पासवर्ड सुरक्षा**
**समर्थित स्वरूप**

Aspose.Slides इन स्वरूपों में प्रेज़ेंटेशन्स के लिए पासवर्ड सुरक्षा, एन्क्रिप्शन और समान ऑपरेशन का समर्थन करता है:

- PPTX और PPT - Microsoft PowerPoint Presentation  
- ODP - OpenDocument Presentation  
- OTP - OpenDocument Presentation Template  

**समर्थित ऑपरेशन**

Aspose.Slides आपको प्रेज़ेंटेशन्स पर पासवर्ड सुरक्षा का उपयोग करके संशोधनों को रोकने के ये तरीके प्रदान करता है:

- प्रेज़ेंटेशन को एन्क्रिप्ट करना  
- प्रेज़ेंटेशन में लिखने की सुरक्षा सेट करना  

**अन्य ऑपरेशन**

Aspose.Slides आपको पासवर्ड सुरक्षा और एन्क्रिप्शन से संबंधित अन्य कार्यों को इन तरीकों से करने देता है:

- प्रेज़ेंटेशन को डिक्रिप्ट करना; एन्क्रिप्टेड प्रेज़ेंटेशन खोलना  
- एन्क्रिप्शन हटाना; पासवर्ड सुरक्षा अक्षम करना  
- प्रेज़ेंटेशन से लिखने की सुरक्षा हटाना  
- एन्क्रिप्टेड प्रेज़ेंटेशन की प्रॉपर्टी प्राप्त करना  
- जांचना कि प्रेज़ेंटेशन एन्क्रिप्टेड है या नहीं  
- जांचना कि प्रेज़ेंटेशन पासवर्ड‑सुरक्षित है या नहीं।

## **प्रेज़ेंटेशन को एन्क्रिप्ट करें**

आप पासवर्ड सेट करके प्रेज़ेंटेशन को एन्क्रिप्ट कर सकते हैं। फिर, लॉक्ड प्रेज़ेंटेशन को संशोधित करने के लिए उपयोगकर्ता को पासवर्ड प्रदान करना होगा।

प्रेज़ेंटेशन को एन्क्रिप्ट या पासवर्ड‑सुरक्षित करने के लिए आपको encrypt मेथड (from [IProtectionManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager)) का उपयोग करके प्रेज़ेंटेशन के लिए पासवर्ड सेट करना होगा। आप पासवर्ड को encrypt मेथड में पास करते हैं और अब एन्क्रिप्टेड प्रेज़ेंटेशन को सहेजने के लिए save मेथड का उपयोग करते हैं।

यह नमूना कोड दर्शाता है कि प्रेज़ेंटेशन को कैसे एन्क्रिप्ट किया जाए:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **प्रेज़ेंटेशन के लिए लिखने की सुरक्षा सेट करें**

आप प्रेज़ेंटेशन में “Do not modify” जैसा चिह्न जोड़ सकते हैं। इस तरह आप उपयोगकर्ताओं को बता सकते हैं कि आप नहीं चाहते कि वे प्रेज़ेंटेशन में परिवर्तन करें।  

**नोट** कि लिखने की सुरक्षा प्रक्रिया प्रेज़ेंटेशन को एन्क्रिप्ट नहीं करती। इसलिए, उपयोगकर्ता—यदि वे चाहते हैं—प्रेज़ेंटेशन को संशोधित कर सकते हैं, लेकिन परिवर्तन सहेजने के लिए उन्हें प्रेज़ेंटेशन को किसी अलग नाम से बनाना पड़ेगा।  

लिखने की सुरक्षा सेट करने के लिए आपको [setWriteProtection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) मेथड का उपयोग करना होगा। यह नमूना कोड दर्शाता है कि प्रेज़ेंटेशन पर लिखने की सुरक्षा कैसे सेट की जाए:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रेज़ेंटेशन लोड करें**

Aspose.Slides आपको पासवर्ड पास करके एन्क्रिप्टेड फ़ाइल को लोड करने की अनुमति देता है। प्रेज़ेंटेशन को डिक्रिप्ट करने के लिए आपको [removeEncryption](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) मेथड बिना पैरामीटर के कॉल करना होगा। फिर आपको सही पासवर्ड दर्ज करना पड़ेगा ताकि प्रेज़ेंटेशन लोड हो सके।

यह नमूना कोड दर्शाता है कि प्रेज़ेंटेशन को कैसे डिक्रिप्ट किया जाए: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रेज़ेंटेशन के साथ काम करें
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **प्रेज़ेंटेशन से एन्क्रिप्शन हटाएँ**

आप प्रेज़ेंटेशन से एन्क्रिप्शन या पासवर्ड सुरक्षा हटा सकते हैं। इस तरह उपयोगकर्ता बिना किसी प्रतिबंध के प्रेज़ेंटेशन तक पहुँच या उसे संशोधित कर सकते हैं। 

एन्क्रिप्शन या पासवर्ड सुरक्षा हटाने के लिए आपको [removeEncryption](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) मेथड को कॉल करना होगा। यह नमूना कोड दर्शाता है कि प्रेज़ेंटेशन से एन्क्रिप्शन कैसे हटाया जाए:

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

## **प्रेज़ेंटेशन से लिखने की सुरक्षा हटाएँ**

आप Aspose.Slides का उपयोग करके प्रेज़ेंटेशन फ़ाइल पर लागू लिखने की सुरक्षा को हटाने के लिए उपयोग कर सकते हैं। इस तरह उपयोगकर्ता अपनी इच्छा अनुसार संशोधन कर सकते हैं—और उन्हें ऐसे कार्य करने पर कोई चेतावनी नहीं मिलती।

आप लिखने की सुरक्षा को हटाने के लिए [removeWriteProtection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) मेथड का उपयोग कर सकते हैं। यह नमूना कोड दर्शाता है कि प्रेज़ेंटेशन से लिखने की सुरक्षा कैसे हटाई जाए:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रेज़ेंटेशन की प्रॉपर्टी प्राप्त करें**

आमतौर पर उपयोगकर्ता एन्क्रिप्टेड या पासवर्ड‑सुरक्षित प्रेज़ेंटेशन की डॉक्यूमेंट प्रॉपर्टीज़ प्राप्त करने में कठिनाई महसूस करते हैं। Aspose.Slides, हालांकि, ऐसा तंत्र प्रदान करता है जिससे आप प्रेज़ेंटेशन को पासवर्ड से सुरक्षित रखते हुए उपयोगकर्ताओं को उसकी प्रॉपर्टीज़ तक पहुँच प्रदान कर सकते हैं।

**नोट** कि जब Aspose.Slides प्रेज़ेंटेशन को एन्क्रिप्ट करता है, तो प्रेज़ेंटेशन की डॉक्यूमेंट प्रॉपर्टीज़ भी डिफ़ॉल्ट रूप से पासवर्ड‑सुरक्षित हो जाती हैं। लेकिन यदि आपको एन्क्रिप्टेड होने के बाद भी प्रेज़ेंटेशन की प्रॉपर्टीज़ उपलब्ध करानी हों, तो Aspose.Slides आपको यह करने की अनुमति देता है। 

यदि आप चाहते हैं कि उपयोगकर्ता एन्क्रिप्ट किए गए प्रेज़ेंटेशन की प्रॉपर्टीज़ तक पहुँच बनाए रखें, तो आप [encryptDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) प्रॉपर्टी को `true` सेट कर सकते हैं। यह नमूना कोड दर्शाता है कि प्रेज़ेंटेशन को एन्क्रिप्ट करते हुए उपयोगकर्ताओं को उसकी डॉक्यूमेंट प्रॉपर्टीज़ तक पहुँच कैसे प्रदान की जाए:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **जांचें कि प्रेज़ेंटेशन पासवर्ड‑सुरक्षित है या नहीं**

प्रेज़ेंटेशन लोड करने से पहले आप यह जांचना चाहेंगे कि प्रेज़ेंटेशन पासवर्ड से सुरक्षित है या नहीं। इस तरह आप त्रुटियों और समान समस्याओं से बच सकते हैं, जो पासवर्ड‑सुरक्षित प्रेज़ेंटेशन को बिना पासवर्ड के लोड करने पर उत्पन्न होती हैं।

यह Java कोड दर्शाता है कि प्रेज़ेंटेशन को लोड किए बिना यह कैसे जाँचें कि वह पासवर्ड‑सुरक्षित है या नहीं:

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **जांचें कि प्रेज़ेंटेशन एन्क्रिप्टेड है या नहीं**

Aspose.Slides आपको यह जांचने की अनुमति देता है कि प्रेज़ेंटेशन एन्क्रिप्टेड है या नहीं। इस कार्य को करने के लिए आप [isEncrypted](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) प्रॉपर्टी का उपयोग कर सकते हैं, जो प्रेज़ेंटेशन एन्क्रिप्टेड होने पर `true` और न होने पर `false` लौटाती है।

यह नमूना कोड दर्शाता है कि प्रेज़ेंटेशन एन्क्रिप्टेड है या नहीं, कैसे जाँचें:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **जाँचें कि प्रेज़ेंटेशन लिखने‑सुरक्षित है या नहीं**

Aspose.Slides आपको यह जांचने की अनुमति देता है कि प्रेज़ेंटेशन लिखने‑सुरक्षित है या नहीं। इस कार्य को करने के लिए आप [isWriteProtected](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) प्रॉपर्टी का उपयोग कर सकते हैं, जो प्रेज़ेंटेशन लिखने‑सुरक्षित होने पर `true` और न होने पर `false` लौटाती है।

यह नमूना कोड दर्शाता है कि प्रेज़ेंटेशन लिखने‑सुरक्षित है या नहीं, कैसे जाँचें:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **विशिष्ट पासवर्ड उपयोग की पुष्टि या मान्य करें**

आप यह जांचना और पुष्टि करना चाह सकते हैं कि किसी विशेष पासवर्ड का उपयोग करके प्रेज़ेंटेशन दस्तावेज़ को सुरक्षित किया गया था या नहीं। Aspose.Slides आपको पासवर्ड को वैध करने का माध्यम प्रदान करता है। 

यह नमूना कोड दर्शाता है कि पासवर्ड को कैसे वैध किया जाए:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // जांचें कि "pass" मेल खाता है या नहीं
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

यह `true` लौटाता है यदि प्रेज़ेंटेशन निर्दिष्ट पासवर्ड से एन्क्रिप्ट किया गया हो। अन्यथा यह `false` लौटाता है। 

{{% alert color="primary" title="साथ ही देखें" %}} 
- [Digital Signature in PowerPoint](/slides/hi/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides कौन से एन्क्रिप्शन मेथड का समर्थन करता है?**

Aspose.Slides आधुनिक एन्क्रिप्शन मेथड, जिसमें AES‑आधारित एल्गोरिदम शामिल हैं, का समर्थन करता है, जिससे आपके प्रेज़ेंटेशन्स की डेटा सुरक्षा उच्च स्तर की बनी रहती है।

**जब प्रेज़ेंटेशन खोलते समय गलत पासवर्ड दर्ज किया जाता है तो क्या होता है?**

गलत पासवर्ड उपयोग करने पर एक अपवाद फेंका जाता है, जिससे आपको सूचित किया जाता है कि प्रेज़ेंटेशन तक पहुंच अस्वीकृत है। यह अनधिकृत पहुंच को रोकता है और प्रेज़ेंटेशन की सामग्री की सुरक्षा करता है।

**क्या पासवर्ड‑सुरक्षित प्रेज़ेंटेशन्स के साथ काम करने पर प्रदर्शन पर कोई असर पड़ता है?**

एन्क्रिप्शन और डिक्रिप्शन प्रक्रियाएँ खोलने और सहेजने के दौरान थोड़ा ओवरहेड जोड़ सकती हैं। अधिकांश मामलों में यह प्रदर्शन प्रभाव न्यूनतम होता है और आपके प्रेज़ेंटेशन कार्यों की कुल प्रोसेसिंग समय को महत्वपूर्ण रूप से प्रभावित नहीं करता।