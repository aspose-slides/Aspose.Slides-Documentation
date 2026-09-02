---
title: "Java में प्रस्तुतियों को पासवर्ड-से संरक्षित करें"
linktitle: "पासवर्ड सुरक्षा"
type: docs
weight: 20
url: /hi/java/password-protected-presentation/
keywords:
- "पासवर्ड‑सुरक्षित प्रस्तुति"
- "ओपनिंग पासवर्ड"
- "PowerPoint एन्क्रिप्ट करें"
- "PowerPoint डीक्रिप्ट करें"
- "प्रस्तुति पासवर्ड सत्यापित करें"
- "प्रस्तुति पासवर्ड जाँचें"
- "एन्क्रिप्टेड प्रस्तुति खोलें"
- "एन्क्रिप्शन हटाएँ"
- "PowerPoint"
- "PPT"
- "PPTX"
- "प्रस्तुति"
- "Java"
- "Aspose.Slides"
description: "Java में Aspose.Slides के साथ पासवर्ड-सुरक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पता करें, सत्यापित, खोलें और डीक्रिप्ट करें।"
---
## **अवलोकन**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। सामग्री को लोड और देखने के लिए सही पासवर्ड आवश्यक होता है, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

एक ओपनिंग पासवर्ड लिखने-रोकथाम पासवर्ड से अलग है। लिखने-रोकथाम पासवर्ड संशोधन को प्रतिबंधित करता है लेकिन सामग्री को एन्क्रिप्ट नहीं करता और प्रस्तुति को लोड होने से नहीं रोकता। प्रस्तुतियों को संशोधित करने के पासवर्ड प्रबंधित करने के लिए देखें [प्रेजेंटेशनों को लिखने से रोकें](/slides/hi/java/write-protected-presentation/)।

नीचे दिए गए कार्यप्रवाह दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों स्वरूपों का उपयोग करते हैं जहाँ फ़ाइल‑आधारित और स्ट्रीम‑आधारित व्यवहार महत्वपूर्ण है।

## **एक ओपनिंग पासवर्ड के साथ प्रस्तुति को एन्क्रिप्ट करें**

एक ओपनिंग पासवर्ड असाइन करने के लिए [IProtectionManager.encrypt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) का उपयोग करें। फिर एन्क्रिप्टेड प्रस्तुति को सहेजने के लिए [IPresentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) का उपयोग करें।

निम्नलिखित उदाहरण एक PPTX प्रस्तुति को एन्क्रिप्ट करता है:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रस्तुति लोड करें**

फ़ाइल लोड करते समय ओपनिंग पासवर्ड सेट करने के लिए [ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) को पासवर्ड पर सेट करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) को पास करके फ़ाइल लोड करें। यदि ओपनिंग पासवर्ड आवश्यक है लेकिन प्रदान किया गया पासवर्ड अनुपलब्ध या गलत है तो लोड विफल हो जाता है।

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति के साथ काम करें।
} finally {
    presentation.dispose();
}
```

## **प्रस्तुति से एन्क्रिप्शन हटाएँ**

प्रस्तुति को उसके ओपनिंग पासवर्ड के साथ लोड करें, [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) को कॉल करें, और परिणाम सहेजें। सहेजी गई प्रस्तुति को अब बिना पासवर्ड के लोड किया जा सकता है।

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लोड करने से पहले ओपनिंग पासवर्ड सत्यापित करें**

एक पूर्ण प्रस्तुति इंस्टेंस बनाकर नहीं, बल्कि [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करके [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/) प्राप्त करें। पासवर्ड का अनुरोध या सत्यापन करने से पहले [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) की जाँच करें। यदि सुरक्षा मौजूद है, तो प्रदान किए गए मान को [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) के साथ सत्यापित करें।

### **फ़ाइल पथ कार्यप्रवाह**

निम्नलिखित उदाहरण PPTX फ़ाइल के लिए ओपनिंग पासवर्ड को सत्यापित करता है, सत्यापित मान को [ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) को पास करता है, और फिर पूर्ण प्रस्तुति को लोड करता है:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **स्ट्रीम कार्यप्रवाह**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) का स्ट्रीम ओवरलोड समान कार्यप्रवाह प्रदान करता है। पूर्ण प्रस्तुति को उस स्ट्रीम से लोड करने से पहले संभावित स्ट्रीम की स्थिति को रीसेट करें।

निम्नलिखित उदाहरण एक PPT फ़ाइल का उपयोग करता है:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **checkPassword रिटर्न मान**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) केवल तब `true` लौटाता है जब प्रस्तुति में ओपनिंग पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह प्रत्येक नीचे दिए गए मामलों में `false` लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में ओपनिंग पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड `null` या खाली है।

व्यवहार PPT और PPTX दोनों प्रस्तुतियों के लिए समान है।

## **जांचें कि लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, यह पुष्टि करने के लिए [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) की जाँच करें कि स्रोत प्रस्तुति एन्क्रिप्टेड थी। लोड करने से पहले ओपनिंग‑पासवर्ड सुरक्षा का पता लगाने के लिए ऊपर दिखाए अनुसार `IPresentationInfo.isPasswordProtected` का उपयोग करें।

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **सुरक्षा अनुशंसाएँ**

{{% alert color="warning" title="Security" %}}
ओपनिंग पासवर्ड को लॉग न करें और न ही उन्हें डायग्नोस्टिक संदेशों में शामिल करें। अनावश्यक पुनरावृत्त सत्यापन प्रयासों से बचें, पासवर्ड को केवल आवश्यक अवधि तक मेमोरी में रखें, और जब तुरंत प्रस्तुति लोड की जा रही हो तो सफल सत्यापन परिणाम को पुन: उपयोग करें।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड-प्रोटेक्ट करें**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
1. प्रस्तुति चुनें या अपलोड करें।
1. देखे जाने की सुरक्षा के लिए पासवर्ड दर्ज करें।
1. वैकल्पिक रूप से संपादन सुरक्षा के लिए अलग पासवर्ड दर्ज करें।
1. सुरक्षा लागू करें और परिणामी फ़ाइल डाउनलोड करें।

{{% alert color="info" title="See also" %}}
- [प्रेजेंटेशनों को लिखने से रोकें](/slides/hi/java/write-protected-presentation/)
- [PowerPoint में डिजिटल हस्ताक्षर](/slides/hi/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**एक ओपनिंग पासवर्ड और लिखने-रोकथाम पासवर्ड के बीच क्या अंतर है?**

ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री को लोड करने के लिए आवश्यक होता है। लिखने-रोकथाम पासवर्ड संशोधन को प्रतिबंधित करता है बिना सामग्री को एन्क्रिप्ट किए।

**क्या मैं सभी स्लाइड्स को लोड किए बिना ओपनिंग पासवर्ड सत्यापित कर सकता हूँ?**

हां। प्रस्तुति की जानकारी प्राप्त करें, जांचें कि ओपनिंग‑पासवर्ड सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनाते से पहले पासवर्ड को सत्यापित करें।

**क्या पासवर्ड‑जाँच कार्यप्रवाह PPT और PPTX दोनों का समर्थन करते हैं?**

हां। फ़ाइल‑पथ और स्ट्रीम‑आधारित पासवर्ड पहचान और सत्यापन दोनों PPT और PPTX प्रस्तुतियों के लिए समान रूप से कार्य करते हैं।