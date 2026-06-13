---
title: जावा में पासवर्ड के साथ सुरक्षित प्रस्तुतियां
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/java/password-protected-presentation/
keywords:
- PowerPoint को लॉक करें
- प्रस्तुति को लॉक करें
- PowerPoint अनलॉक करें
- प्रस्तुति अनलॉक करें
- PowerPoint की सुरक्षा करें
- प्रस्तुति की सुरक्षा करें
- पासवर्ड सेट करें
- पासवर्ड जोड़ें
- PowerPoint एन्क्रिप्ट करें
- प्रस्तुति एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति डिक्रिप्ट करें
- लेखन संरक्षण
- PowerPoint सुरक्षा
- प्रस्तुति सुरक्षा
- पासवर्ड हटाएँ
- सुरक्षा हटाएँ
- एन्क्रिप्शन हटाएँ
- पासवर्ड अक्षम करें
- सुरक्षा अक्षम करें
- लेखन सुरक्षा हटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ पासवर्ड‑सुरक्षित PowerPoint और OpenDocument प्रस्तुतियों को आसानी से लॉक और अनलॉक करना सीखें। अपनी प्रस्तुतियों को सुरक्षित बनाएँ।"
---
## **परिचय**

जब आप किसी प्रस्तुति को पासवर्ड‑प्रोटेक्ट करते हैं, तो इसका अर्थ है कि आप एक पासवर्ड सेट कर रहे हैं जो प्रस्तुति पर विशिष्ट प्रतिबंध लागू करता है। इन प्रतिबंधों को हटाने के लिए पासवर्ड दर्ज करना आवश्यक है। पासवर्ड‑प्रोटेक्टेड प्रस्तुति को लॉक्ड प्रस्तुति माना जाता है।

आमतौर पर आप प्रस्तुति पर इन प्रतिबंधों को लागू करने के लिए पासवर्ड सेट कर सकते हैं:

- **संशोधन**

  यदि आप चाहते हैं कि केवल कुछ उपयोगकर्ता ही आपकी प्रस्तुति को संशोधित कर सकें, तो आप एक संशोधन प्रतिबंध सेट कर सकते हैं। यह प्रतिबंध लोगों को पासवर्ड प्रदान किए बिना आपके प्रस्तुति के तत्वों को संशोधित, बदल या कॉपी करने से रोकता है।

  हालांकि, पासवर्ड के बिना भी उपयोगकर्ता आपके दस्तावेज़ तक पहुँच और उसे खोल सकता है। इस केवल‑पठन मोड में, उपयोगकर्ता प्रस्तुति की सामग्री—हाइपरलिंक, एनीमेशन, इफ़ेक्ट और अन्य तत्व—को देख सकता है, लेकिन वह आइटम कॉपी या प्रस्तुति को सहेज नहीं सकेगा।

- **खोलना**

  यदि आप चाहते हैं कि केवल कुछ उपयोगकर्ता ही आपकी प्रस्तुति खोल सकें, तो आप एक खोलने का प्रतिबंध सेट कर सकते हैं। यह प्रतिबंध लोगों को पासवर्ड प्रदान किए बिना आपकी प्रस्तुति की सामग्री देख ही नहीं देगा।

  तकनीकी रूप से, खोलने का प्रतिबंध उपयोगकर्ताओं को आपकी प्रस्तुति संशोधित करने से भी रोकता है—यदि कोई प्रस्तुति नहीं खोल सकता, तो वह उसे संशोधित या परिवर्तन नहीं कर सकता।

**ध्यान दें:** जब आप प्रस्तुति को खोलने से रोकने के लिए पासवर्ड‑प्रोटेक्ट करते हैं, तो प्रस्तुति फ़ाइल एन्क्रिप्ट हो जाती है।

## **Aspose.Slides में पासवर्ड प्रोटेक्शन**
**समर्थित स्वरूप**

Aspose.Slides निम्नलिखित स्वरूपों में प्रस्तुतियों के लिए पासवर्ड प्रोटेक्शन, एन्क्रिप्शन और समान ऑपरेशन को सपोर्ट करता है:

- PPTX और PPT – Microsoft PowerPoint प्रस्तुति  
- ODP – OpenDocument प्रस्तुति  
- OTP – OpenDocument प्रस्तुति टेम्प्लेट  

**समर्थित ऑपरेशन**

Aspose.Slides आपको प्रस्तुतियों में पासवर्ड प्रोटेक्शन का उपयोग करके संशोधनों को रोकने के ये तरीके प्रदान करता है:

- प्रस्तुति का एन्क्रिप्शन  
- प्रस्तुति के लिए राइट प्रोटेक्शन सेट करना  

**अन्य ऑपरेशन**

Aspose.Slides आपको पासवर्ड प्रोटेक्शन और एन्क्रिप्शन से संबंधित अन्य कार्यों को इन तरीकों से करने की अनुमति देता है:

- प्रस्तुति को डिक्रिप्ट करना; एन्क्रिप्टेड प्रस्तुति खोलना  
- एन्क्रिप्शन हटाना; पासवर्ड प्रोटेक्शन निष्क्रिय करना  
- प्रस्तुति से राइट प्रोटेक्शन हटाना  
- एन्क्रिप्टेड प्रस्तुति के गुण प्राप्त करना  
- यह जाँचना कि प्रस्तुति एन्क्रिप्टेड है या नहीं  
- यह जाँचना कि प्रस्तुति पासवर्ड‑प्रोटेक्टेड है या नहीं  

## **एक प्रस्तुति को पासवर्ड से सुरक्षित करें**

आप पासवर्ड सेट करके प्रस्तुति को एन्क्रिप्ट कर सकते हैं। फिर, लॉक्ड प्रस्तुति को संशोधित करने के लिए उपयोगकर्ता को पासवर्ड प्रदान करना होगा।

प्रेज़ेंटेशन को एन्क्रिप्ट या पासवर्ड‑प्रोटेक्ट करने के लिए आपको encrypt मेथड (from [IProtectionManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager)) का उपयोग करके प्रस्तुति के लिए पासवर्ड सेट करना होगा। आप पासवर्ड को encrypt मेथड में पास करते हैं और फिर save मेथड का उपयोग करके अब एन्क्रिप्टेड प्रस्तुति को सहेजते हैं।

यह नमूना कोड दिखाता है कि आप प्रस्तुति को कैसे एन्क्रिप्ट कर सकते हैं:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **प्रेज़ेंटेशन पर राइट प्रोटेक्शन सेट करें**

आप प्रस्तुति पर “Do not modify” जैसा संकेत जोड़ सकते हैं। इस प्रकार, आप उपयोगकर्ताओं को बता सकते हैं कि आप नहीं चाहते कि वे प्रस्तुति में कोई बदलाव करें।

**ध्यान दें** कि राइट प्रोटेक्शन प्रक्रिया प्रस्तुति को एन्क्रिप्ट नहीं करती। इसलिए, उपयोगकर्ता—यदि वे चाहें—प्रस्तुति को संशोधित कर सकते हैं, लेकिन परिवर्तन सहेजने के लिए उन्हें अलग नाम से नई प्रस्तुति बनानी पड़ेगी।

राइट प्रोटेक्शन सेट करने के लिए आपको [setWriteProtection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) मेथड का उपयोग करना होगा। यह नमूना कोड दिखाता है कि आप प्रस्तुति पर राइट प्रोटेक्शन कैसे सेट कर सकते हैं:

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

Aspose.Slides आपको पासवर्ड पास करके एन्क्रिप्टेड फ़ाइल लोड करने की अनुमति देता है। प्रस्तुति को डिक्रिप्ट करने के लिए आपको [removeEncryption](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#removeEncryption--) मेथड को बिना पैरामीटर के कॉल करना होगा। तब आपको सही पासवर्ड दर्ज करके प्रस्तुति लोड करनी होगी।

यह नमूना कोड दिखाता है कि आप प्रस्तुति को कैसे डिक्रिप्ट कर सकते हैं:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति के साथ काम करें
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **प्रेज़ेंटेशन से एन्क्रिप्शन हटाएँ**

आप प्रस्तुति पर एन्क्रिप्शन या पासवर्ड प्रोटेक्शन को हटा सकते हैं। इस प्रकार, उपयोगकर्ता प्रतिबंधों के बिना प्रस्तुति तक पहुँच या उसे संशोधित कर सकेंगे।

एन्क्रिप्शन या पासवर्ड प्रोटेक्शन हटाने के लिए आपको [removeEncryption](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#removeEncryption--) मेथड को कॉल करना होगा। यह नमूना कोड दिखाता है कि आप प्रस्तुति से एन्क्रिप्शन कैसे हटाएँ:

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

## **प्रेज़ेंटेशन से राइट प्रोटेक्शन हटाएँ**

आप Aspose.Slides का उपयोग करके प्रस्तुति फ़ाइल से राइट प्रोटेक्शन हटा सकते हैं। इस तरह, उपयोगकर्ता अपनी इच्छानुसार संशोधित कर सकते हैं—और उन्हें ऐसा करने पर कोई चेतावनी नहीं दिखेगी।

आप [removeWriteProtection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) मेथड का उपयोग करके प्रस्तुति से राइट प्रोटेक्शन हटा सकते हैं। यह नमूना कोड दिखाता है कि आप राइट प्रोटेक्शन कैसे हटाएँ:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रस्तुति के गुण प्राप्त करें**

आमतौर पर उपयोगकर्ता एन्क्रिप्टेड या पासवर्ड‑प्रोटेक्टेड प्रस्तुति के दस्तावेज़ गुण प्राप्त करने में कठिनाई महसूस करते हैं। Aspose.Slides, हालांकि, एक ऐसा तंत्र प्रदान करता है जिससे आप प्रस्तुति को पासवर्ड‑प्रोटेक्ट कर सकते हैं और साथ ही उपयोगकर्ताओं को उस प्रस्तुति के गुणों तक पहुँच प्रदान कर सकते हैं।

**ध्यान दें** कि जब Aspose.Slides प्रस्तुति को एन्क्रिप्ट करता है, तो प्रस्तुति के दस्तावेज़ गुण भी डिफ़ॉल्ट रूप से पासवर्ड‑प्रोटेक्ट हो जाते हैं। लेकिन यदि आप चाहते हैं कि प्रस्तुति के गुण एन्क्रिप्शन के बाद भी उपलब्ध रहें, तो Aspose.Slides आपको वह करने की सुविधा देता है।

यदि आप चाहते हैं कि उपयोगकर्ता एन्क्रिप्टेड प्रस्तुति के गुणों तक पहुँच बनाए रखें, तो आप [encryptDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) प्रॉपर्टी को `true` पर सेट कर सकते हैं। यह नमूना कोड दिखाता है कि आप प्रस्तुति को एन्क्रिप्ट करते हुए उपयोगकर्ताओं को उसके दस्तावेज़ गुणों तक पहुँच कैसे प्रदान करें:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **जाँचें कि प्रस्तुति पासवर्ड‑प्रोटेक्टेड है या नहीं**

प्रेज़ेंटेशन लोड करने से पहले आप यह सत्यापित करना चाहेंगे कि प्रस्तुति पर पासवर्ड प्रोटेक्शन लगा है या नहीं। इस प्रकार, आप उन त्रुटियों और समान समस्याओं से बच सकते हैं जो पासवर्ड‑प्रोटेक्टेड प्रस्तुति को बिना पासवर्ड के लोड करने पर उत्पन्न होती हैं।

यह Java कोड दिखाता है कि आप प्रस्तुति को लोड किए बिना यह कैसे जांचें कि वह पासवर्ड‑प्रोटेक्टेड है या नहीं:

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **जाँचें कि प्रस्तुति एन्क्रिप्टेड है या नहीं**

Aspose.Slides आपको यह जाँचने की अनुमति देता है कि प्रस्तुति एन्क्रिप्टेड है या नहीं। इस कार्य को करने के लिए आप [isEncrypted](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#isEncrypted--) प्रॉपर्टी का उपयोग कर सकते हैं, जो प्रस्तुति एन्क्रिप्टेड होने पर `true` और नहीं होने पर `false` लौटाता है।

यह नमूना कोड दिखाता है कि आप प्रस्तुति के एन्क्रिप्टेड होने की जाँच कैसे करें:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **जाँचें कि प्रस्तुति राइट‑प्रोटेक्टेड है या नहीं**

Aspose.Slides आपको यह जाँचने की सुविधा देता है कि प्रस्तुति राइट‑प्रोटेक्टेड है या नहीं। इस कार्य के लिए आप [isWriteProtected](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IProtectionManager#isWriteProtected--) प्रॉपर्टी का उपयोग कर सकते हैं, जो प्रस्तुति एन्क्रिप्टेड होने पर `true` और नहीं होने पर `false` लौटाता है।

यह नमूना कोड दिखाता है कि आप प्रस्तुति के राइट‑प्रोटेक्टेड होने की जाँच कैसे करें:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **पुष्टि करें कि कोई विशिष्ट पासवर्ड उपयोग किया गया है**

आप यह जाँचना और पुष्टि करना चाह सकते हैं कि कोई विशिष्ट पासवर्ड प्रस्तुति दस्तावेज़ को सुरक्षित करने के लिए उपयोग किया गया है। Aspose.Slides आपको पासवर्ड को वैधता प्रमाणित करने का साधन प्रदान करता है।

यह नमूना कोड दिखाता है कि आप पासवर्ड की वैधता कैसे जाँचें:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // जाँचें कि "pass" पासवर्ड से मेल खाता है
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

यह `true` लौटाता है यदि प्रस्तुति निर्दिष्ट पासवर्ड से एन्क्रिप्ट की गई है। अन्यथा, यह `false` लौटाता है।

{{% alert color="primary" title="और देखें" %}} 
- [PowerPoint में डिजिटल हस्ताक्षर](/slides/hi/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides द्वारा कौन‑से एन्क्रिप्शन विधियाँ समर्थित हैं?**

Aspose.Slides आधुनिक एन्क्रिप्शन विधियों को, जिसमें AES‑आधारित एल्गोरिदम शामिल हैं, सपोर्ट करता है, जिससे आपकी प्रस्तुतियों के डेटा की उच्च स्तर की सुरक्षा सुनिश्चित होती है।

**यदि प्रस्तुति खोलने के दौरान गलत पासवर्ड दर्ज किया जाए तो क्या होता है?**

गलत पासवर्ड उपयोग करने पर एक अपवाद उत्पन्न होता है, जो यह सूचित करता है कि प्रस्तुति तक पहुँच अस्वीकार कर दी गई है। यह अनधिकृत पहुँच को रोकने और प्रस्तुति सामग्री की सुरक्षा में मदद करता है।

**पासवर्ड‑प्रोटेक्टेड प्रस्तुतियों के साथ काम करने में प्रदर्शन पर कोई असर पड़ता है क्या?**

एन्क्रिप्शन और डिक्रिप्शन प्रक्रिया खोलने और सहेजने के दौरान थोड़ा अतिरिक्त ओवरहेड जोड़ सकती है। अधिकांश मामलों में यह प्रदर्शन प्रभाव न्यूनतम होता है और आपके प्रस्तुति कार्यों के कुल प्रसंस्करण समय को महत्वपूर्ण रूप से प्रभावित नहीं करता।