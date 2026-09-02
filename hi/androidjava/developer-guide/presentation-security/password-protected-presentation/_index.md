---
title: एंड्रॉइड पर पासवर्ड के साथ प्रस्तुतियों को सुरक्षित करें
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/androidjava/password-protected-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android (Java) के माध्यम से पासवर्ड-रक्षित PowerPoint और OpenDocument प्रस्तुतियों को आसानी से लॉक और अनलॉक करें। अपनी प्रस्तुतियों को सुरक्षित रखें।"
---
## **परिचय**

जब आप किसी प्रस्तुति को पासवर्ड‑सुरक्षित करते हैं, तो इसका अर्थ है कि आप एक पासवर्ड सेट कर रहे हैं जो प्रस्तुति पर कुछ प्रतिबंध लागू करता है। प्रतिबंध हटाने के लिए पासवर्ड दर्ज करना आवश्यक होता है। पासवर्ड‑सुरक्षित प्रस्तुति को एक बंद (लॉक्ड) प्रस्तुति माना जाता है।

आम तौर पर, आप प्रस्तुति पर इन प्रतिबंधों को लागू करने के लिये पासवर्ड सेट कर सकते हैं:

- **संशोधन**

  यदि आप चाहते हैं कि केवल कुछ उपयोगकर्ता ही आपकी प्रस्तुति को संशोधित कर सकें, तो आप संशोधन प्रतिबंध सेट कर सकते हैं। यह प्रतिबंध लोगों को आपकी प्रस्तुति को बदलने, संशोधित करने या उसकी वस्तुओं को कॉपी करने से रोकता है (जब तक वे पासवर्ड न दें)।

  हालांकि, इस स्थिति में पासवर्ड के बिना भी उपयोगकर्ता आपका दस्तावेज़ खोल सकता है। केवल‑पढ़ने वाले मोड में उपयोगकर्ता आपकी प्रस्तुति की सामग्री—हाइपरलिंक, एनीमेशन, इफ़ेक्ट आदि—देख सकता है, परंतु वस्तुओं को कॉपी या प्रस्तुति को सेव नहीं कर सकता।

- **खोलना**

  यदि आप चाहते हैं कि केवल कुछ उपयोगकर्ता ही आपकी प्रस्तुति खोल सकें, तो आप खोलने का प्रतिबंध सेट कर सकते हैं। यह प्रतिबंध लोगों को आपकी प्रस्तुति की सामग्री देखना भी रोकता है (जब तक पासवर्ड न दिया जाए)।

  तकनीकी रूप से, खोलने का प्रतिबंध उपयोगकर्ताओं को आपके प्रस्तुतियों को संशोधित करने से भी रोकता है: जब लोग प्रस्तुति नहीं खोल पाते, तो वे उसे बदल या संशोधित नहीं कर सकते।  

  **ध्यान दें** कि जब आप किसी प्रस्तुति को खोलने से रोकने के लिये पासवर्ड‑सुरक्षित करते हैं, तो प्रस्तुति फ़ाइल एन्क्रिप्ट हो जाती है।

## **Aspose.Slides में प्रस्तुतियों की पासवर्ड सुरक्षा**
**समर्थित प्रारूप**

Aspose.Slides इन प्रारूपों की प्रस्तुतियों के लिये पासवर्ड सुरक्षा, एन्क्रिप्शन और समान कार्यों का समर्थन करता है:

- PPTX और PPT - Microsoft PowerPoint Presentation  
- ODP - OpenDocument Presentation  
- OTP - OpenDocument Presentation Template  

**समर्थित कार्य**

Aspose.Slides आपको निम्न तरीकों से संशोधन को रोकने हेतु प्रस्तुतियों पर पासवर्ड सुरक्षा उपयोग करने की अनुमति देता है:

- प्रस्तुति को एन्क्रिप्ट करना  
- प्रस्तुति में लिखने की सुरक्षा सेट करना  

**अन्य कार्य**

Aspose.Slides आपको पासवर्ड सुरक्षा और एन्क्रिप्शन से संबंधित अन्य कार्यों को करने की अनुमति देता है:

- प्रस्तुति को डिक्रिप्ट करना; एन्क्रिप्टेड प्रस्तुति को खोलना  
- एन्क्रिप्शन हटाना; पासवर्ड सुरक्षा निष्क्रिय करना  
- प्रस्तुति से लिखने की सुरक्षा हटाना  
- एन्क्रिप्टेड प्रस्तुति की गुणधर्म प्राप्त करना  
- यह जांचना कि प्रस्तुति एन्क्रिप्टेड है या नहीं  
- यह जांचना कि प्रस्तुति पासवर्ड‑सुरक्षित है या नहीं।

## **प्रस्तुति को एन्क्रिप्ट करना**

आप पासवर्ड सेट करके प्रस्तुति को एन्क्रिप्ट कर सकते हैं। फिर, लॉक्ड प्रस्तुति को संशोधित करने के लिये उपयोगकर्ता को पासवर्ड प्रदान करना होगा।

एक प्रस्तुति को एन्क्रिप्ट या पासवर्ड‑सुरक्षित करने के लिये, आपको एन्क्रिप्ट मेथड ( [IProtectionManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager) से) का उपयोग करके प्रस्तुति के लिये पासवर्ड सेट करना होगा। आप पासवर्ड को एन्क्रिप्ट मेथड में पास करते हैं और अब एन्क्रिप्टेड प्रस्तुति को सेव करने के लिये save मेथड का उपयोग करते हैं।

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

## **प्रस्तुति पर लिखने की सुरक्षा सेट करना**

आप प्रस्तुति में “Do not modify” जैसा नोट जोड़ सकते हैं। इस प्रकार, आप उपयोगकर्ताओं को बता सकते हैं कि आप नहीं चाहते कि वे प्रस्तुति में बदलाव करें।

**ध्यान दें** कि लिखने की सुरक्षा प्रक्रिया प्रस्तुति को एन्क्रिप्ट नहीं करती। इसलिए, उपयोगकर्ता—यदि वे चाहते हैं—प्रस्तुति को संशोधित कर सकते हैं, परंतु परिवर्तन को सेव करने के लिये उन्हें अलग नाम से प्रस्तुति बनानी होगी।

लिखने की सुरक्षा सेट करने के लिये, आपको [setWriteProtection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) मेथड का उपयोग करना होगा। यह नमूना कोड दर्शाता है कि आप प्रस्तुति में लिखने की सुरक्षा कैसे सेट कर सकते हैं:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रस्तुति लोड करना**

Aspose.Slides आपको पासवर्ड पास करके एन्क्रिप्टेड फ़ाइल लोड करने की अनुमति देता है। प्रस्तुति को डिक्रिप्ट करने के लिये, आपको [removeEncryption](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) मेथड को बिना किसी पैरामीटर के कॉल करना होगा। फिर आपको सही पासवर्ड दर्ज करके प्रस्तुति लोड करनी होगी।

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
```

## **प्रस्तुति से एन्क्रिप्शन हटाना**

आप प्रस्तुति से एन्क्रिप्शन या पासवर्ड सुरक्षा हटा सकते हैं। इस प्रकार, उपयोगकर्ता बिना किसी प्रतिबंध के प्रस्तुति को एक्सेस या संशोधित कर सकते हैं।

एन्क्रिप्शन या पासवर्ड सुरक्षा हटाने के लिये, आपको [removeEncryption](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) मेथड को कॉल करना होगा। यह नमूना कोड दर्शाता है कि आप प्रस्तुति से एन्क्रिप्शन कैसे हटाते हैं:

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

## **प्रस्तुति से लिखने की सुरक्षा हटाना**

आप Aspose.Slides का उपयोग करके प्रस्तुति फ़ाइल से लिखने की सुरक्षा हटा सकते हैं। इस प्रकार, उपयोगकर्ता अपनी इच्छा अनुसार संशोधित कर सकते हैं—और उन्हें इस कार्य के दौरान कोई चेतावनी नहीं मिलती।

आप [removeWriteProtection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) मेथड का उपयोग करके प्रस्तुति से लिखने की सुरक्षा हटा सकते हैं। यह नमूना कोड दिखाता है कि आप प्रस्तुति से लिखने की सुरक्षा कैसे हटाते हैं:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रस्तुति के गुणधर्म प्राप्त करना**

आम तौर पर, उपयोगकर्ता एन्क्रिप्टेड या पासवर्ड‑सुरक्षित प्रस्तुति के दस्तावेज़ गुणधर्म प्राप्त करने में कठिनाई महसूस करते हैं। हालांकि, Aspose.Slides एक ऐसा तंत्र प्रदान करता है जिससे आप प्रस्तुति को पासवर्ड‑सुरक्षित कर सकते हैं जबकि उपयोगकर्ता उसके गुणधर्म तक पहुंच बना रहे।

**ध्यान दें:** डिफ़ॉल्ट रूप से, जब Aspose.Slides किसी प्रस्तुति को एन्क्रिप्ट करता है, तो प्रस्तुति के दस्तावेज़ गुणधर्म भी पासवर्ड‑सुरक्षित हो जाते हैं। यदि आपको एन्क्रिप्शन के बाद भी दस्तावेज़ गुणधर्मों तक पहुंच की आवश्यकता है, तो Aspose.Slides यह करने की अनुमति देता है।

यदि आप चाहते हैं कि उपयोगकर्ता एन्क्रिप्टेड प्रस्तुति के गुणधर्मों तक पहुंच सकें, तो [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) को `false` पास करें। यह नमूना कोड दर्शाता है कि आप प्रस्तुति को एन्क्रिप्ट करते हुए भी उपयोगकर्ताओं को उसके दस्तावेज़ गुणधर्म कैसे उपलब्ध कराते हैं:

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

## **एन्क्रिप्टेड प्रस्तुति से केवल दस्तावेज़ गुणधर्म लोड करना**

एन्क्रिप्टेड प्रस्तुति के मेटाडेटा को बिना स्लाइड्स या अन्य सामग्री लोड किए जांचने के लिये, एक [LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) ऑब्जेक्ट बनाएँ और [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` पास करें। इस मोड में, Aspose.Slides पासवर्ड को अनदेखा कर केवल सार्वजनिक रूप से उपलब्ध दस्तावेज़ गुणधर्म लोड करता है।

निम्न कोड उदाहरण [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) के माध्यम से निर्मित और कस्टम दस्तावेज़ गुणधर्म पढ़ता है:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // बिल्ट-इन दस्तावेज़ गुणधर्म पढ़ें।
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // कस्टम दस्तावेज़ गुणधर्म पढ़ें।
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

यह वर्कफ़्लो तभी कार्य करता है जब एन्क्रिप्शन के समय दस्तावेज़ गुणधर्म अनएन्क्रिप्टेड (सार्वजनिक) रहे हों। यदि दस्तावेज़ गुणधर्म एन्क्रिप्टेड हों, तो `loadOptions.setOnlyLoadDocumentProperties` को `true` पास करने से अपवाद उत्पन्न होता है क्योंकि पासवर्ड इस मोड में अनदेखा किया जाता है। एन्क्रिप्टेड दस्तावेज़ गुणधर्मों तक पहुंचने या पूरी प्रस्तुति (स्लाइड्स और अन्य सामग्री सहित) लोड करने के लिये, [ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) के माध्यम से सही पासवर्ड प्रदान करें।

## **जांचें कि प्रस्तुति पासवर्ड‑सुरक्षित है या नहीं**

प्रस्तुति लोड करने से पहले आप यह जांचना चाह सकते हैं कि प्रस्तुति पासवर्ड‑सुरक्षित है या नहीं। इस प्रकार, आप पासवर्ड‑सुरक्षित प्रस्तुति को बिना पासवर्ड लोड करने से उत्पन्न त्रुटियों और समस्याओं से बच सकते हैं।

यह Java कोड दिखाता है कि आप प्रस्तुति को कैसे जांच सकते हैं कि वह पासवर्ड‑सुरक्षित है (बिना प्रस्तुति स्वयं को लोड किए):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **जांचें कि प्रस्तुति एन्क्रिप्टेड है या नहीं**

Aspose.Slides आपको यह जांचने की सुविधा देता है कि प्रस्तुति एन्क्रिप्टेड है या नहीं। इस कार्य के लिये आप [isEncrypted](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) प्रॉपर्टी का उपयोग कर सकते हैं, जो तब `true` लौटाती है जब प्रस्तुति एन्क्रिप्टेड हो और अन्यथा `false`।

यह नमूना कोड दर्शाता है कि आप प्रस्तुति के एन्क्रिप्टेड होने की जांच कैसे कर सकते हैं:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **जांचें कि प्रस्तुति लिखने‑सुरक्षित है या नहीं**

Aspose.Slides आपको यह जांचने की अनुमति देता है कि प्रस्तुति लिखने‑सुरक्षित है या नहीं। इस कार्य के लिये आप [isWriteProtected](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) प्रॉपर्टी का उपयोग कर सकते हैं, जो तब `true` लौटाती है जब प्रस्तुति लिखने‑सुरक्षित हो और अन्यथा `false`।

यह नमूना कोड दर्शाता है कि आप प्रस्तुति के लिखने‑सुरक्षित होने की जांच कैसे कर सकते हैं:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **किसी विशिष्ट पासवर्ड के उपयोग की पुष्टि करना**

आप यह जांचना चाह सकते हैं कि क्या किसी विशिष्ट पासवर्ड का उपयोग करके प्रस्तुति दस्तावेज़ को सुरक्षित किया गया है। Aspose.Slides आपको पासवर्ड को मान्य करने का साधन प्रदान करता है।

यह नमूना कोड दर्शाता है कि आप पासवर्ड को कैसे मान्य कर सकते हैं:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // जांचें कि "pass" से मेल खाता है
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

यह `true` लौटाता है यदि प्रस्तुति निर्दिष्ट पासवर्ड से एन्क्रिप्ट की गई है। अन्यथा यह `false` लौटाता है।

{{% alert color="primary" title="देखें भी" %}} 
- [PowerPoint में डिजिटल हस्ताक्षर](/slides/hi/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides किस प्रकार के एन्क्रिप्शन विधियों का समर्थन करता है?**

Aspose.Slides आधुनिक एन्क्रिप्शन विधियों, जिसमें AES‑आधारित एल्गोरिदम शामिल हैं, का समर्थन करता है, जिससे आपके प्रस्तुतियों के डेटा की उच्च सुरक्षा सुनिश्चित होती है।

**यदि प्रस्तुति खोलने के प्रयत्न में गलत पासवर्ड दर्ज किया जाये तो क्या होता है?**

गलत पासवर्ड उपयोग करने पर अपवाद फेंका जाता है, जिससे यह संकेत मिलता है कि प्रस्तुति तक पहुंच अस्वीकृत है। यह अनधिकृत पहुँच को रोकने तथा प्रस्तुति सामग्री की सुरक्षा में मदद करता है।

**क्या पासवर्ड‑सुरक्षित प्रस्तुतियों के साथ काम करने पर प्रदर्शन पर कोई प्रभाव पड़ता है?**

एन्क्रिप्शन और डिक्रिप्शन प्रक्रिया के कारण खोलने और सेव करने के समय थोड़ा ओवरहेड हो सकता है। अधिकांश मामलों में यह प्रभाव न्यूनतम होता है और आपके प्रस्तुति कार्यों के कुल प्रोसेसिंग समय को महत्वपूर्ण रूप से नहीं बदलता।