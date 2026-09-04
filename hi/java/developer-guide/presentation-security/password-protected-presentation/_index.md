---
title: Java में प्रस्तुतियों को पासवर्ड-से सुरक्षित करें
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/java/password-protected-presentation/
keywords:
- पासवर्ड-संरक्षित प्रस्तुति
- ओपनिंग पासवर्ड
- PowerPoint एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति पासवर्ड मान्य करें
- प्रस्तुति पासवर्ड जाँचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java में Aspose.Slides के साथ पासवर्ड-संरक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पहचान, मान्य, खोल और डिक्रिप्ट करें।"
---
## **अवलोकन**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। सही पासवर्ड लोड करने और प्रस्तुति की सामग्री देखने के लिए आवश्यक होता है, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

एक ओपनिंग पासवर्ड लिखने-से-संरक्षण पासवर्ड से अलग होता है। लिखने-से-संरक्षण संशोधन को सीमित करता है लेकिन सामग्री को एन्क्रिप्ट नहीं करता या प्रस्तुति को लोड होने से नहीं रोकता। प्रस्तुतियों को संशोधित करने के लिए पासवर्ड प्रबंधित करने हेतु देखें [Write-Protect Presentations](/slides/hi/java/write-protected-presentation/)।

नीचे दिए गए वर्कफ़्लो दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों फॉर्मैट का उपयोग करते हैं जहाँ उनके फ़ाइल-आधारित और स्ट्रीम-आधारित व्यवहार महत्वपूर्ण हैं।

## **ओपनिंग पासवर्ड के साथ प्रस्तुति को एन्क्रिप्ट करें**

ओपनिंग पासवर्ड असाइन करने के लिए [IProtectionManager.encrypt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) का उपयोग करें। फिर एन्क्रिप्टेड प्रस्तुति को सहेजने के लिए [IPresentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) का उपयोग करें।

निम्न उदाहरण एक PPTX प्रस्तुति को एन्क्रिप्ट करता है:

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

## **दस्तावेज़ विशेषताएँ सार्वजनिक रखें**

डिफॉल्ट रूप से, Aspose.Slides प्रस्तुति एन्क्रिप्शन में दस्तावेज़ विशेषताओं को शामिल करता है। यह व्यवहार स्लाइड-समग्री एन्क्रिप्शन से स्वतंत्र रूप से नियंत्रित करने के लिये [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) मेथड उपयोग किया जाता है। जब किसी इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़-प्रबंधन प्रणाली को ओपनिंग पासवर्ड के बिना मेटाडाटा पढ़ना आवश्यक हो तो [IProtectionManager.encrypt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) को कॉल करने से पहले `false` पास करें।

निम्न उदाहरण एक एन्क्रिप्टेड PPTX प्रस्तुति बनाता है जबकि उसकी अंतर्निहित दस्तावेज़ विशेषताएँ सार्वजनिक रहती हैं:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`false` को [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) में पास करने से स्लाइड्स, मास्टर्स, लेआउट्स, शैप्स, मीडिया या अन्य प्रस्तुति सामग्री सार्वजनिक नहीं होती। यह केवल दस्तावेज़ विशेषताओं को प्रभावित करता है। एन्क्रिप्टेड सामग्री लोड किए बिना उन विशेषताओं को पढ़ने के लिए देखें [Manage Presentation Properties](/slides/hi/java/presentation-properties/)।

## **एन्क्रिप्टेड प्रस्तुति लोड करें**

फ़ाइल लोड करते समय ओपनिंग पासवर्ड को [ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) में सेट करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) को पास करें। यदि ओपनिंग पासवर्ड आवश्यक है लेकिन प्रदान किया गया पासवर्ड अनुपलब्ध या गलत है तो लोडिंग विफल हो जाती है।

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

प्रस्तुति को उसके ओपनिंग पासवर्ड के साथ लोड करें, फिर [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) को कॉल करें और परिणाम सहेजें। सहेजी गई प्रस्तुति को फिर पासवर्ड के बिना लोड किया जा सकता है।

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

## **लोड करने से पहले ओपनिंग पासवर्ड मान्य करें**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करके पूर्ण प्रस्तुति इंस्टेंस बनाए बिना [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/) प्राप्त करें। पासवर्ड का अनुरोध या मान्य करने से पहले [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) जाँचें। जब सुरक्षा मौजूद हो, तो प्रदान किए गए मान को [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) से मान्य करें।

### **फ़ाइल-पथ वर्कफ़्लो**

निम्न उदाहरण PPTX फ़ाइल के लिए ओपनिंग पासवर्ड को मान्य करता है, मान्य किए गए मान को [ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) को पास करता है, और फिर पूर्ण प्रस्तुति लोड करता है:

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

### **स्ट्रीम वर्कफ़्लो**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) का स्ट्रीम ओवरलोड समान वर्कफ़्लो प्रदान करता है। उस स्ट्रीम से पूर्ण प्रस्तुति लोड करने से पहले सीकएबल स्ट्रीम की पोज़िशन रीसेट करें।

निम्न उदाहरण एक PPT फ़ाइल का उपयोग करता है:

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

### **checkPassword लौटाने वाले मान**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) केवल तब `true` लौटाता है जब प्रस्तुति में ओपनिंग पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह निम्नलिखित मामलों में `false` लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में ओपनिंग पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड `null` या खाली है।

यह व्यवहार PPT और PPTX प्रस्तुतियों के लिए समान है।

## **लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं जाँचें**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, स्रोत प्रस्तुति एन्क्रिप्टेड थी यह पुष्टि करने के लिए [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) देखें। लोड करने से पहले ओपनिंग पासवर्ड सुरक्षा का पता लगाने के लिए उपर्युक्त अनुसार `IPresentationInfo.isPasswordProtected` का उपयोग करें।

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

## **सुरक्षा सिफ़ारिशें**

{{% alert color="warning" title="Security" %}}
ओपनिंग पासवर्ड को लॉग में न रखें या निदान संदेशों में शामिल न करें। अनावश्यक दोहराए गए मान्यकरण प्रयासों से बचें, पासवर्ड को केवल आवश्यक अवधि के लिए मेमोरी में रखें, और जब तुरंत प्रस्तुति लोड की जा रही हो तो सफल मान्यकरण परिणाम को पुन: उपयोग करें।

सार्वजनिक दस्तावेज़ विशेषताएँ लेखक के नाम, शीर्षक, विषय, कुंजीशब्द, कंपनी जानकारी, टिप्पणी और कस्टम मान उजागर कर सकती हैं जबकि प्रस्तुति की सामग्री एन्क्रिप्टेड है। संवेदनशील मेटाडाटा को प्रस्तुति के साथ एन्क्रिप्ट करें। विशेषताओं को सार्वजनिक रखने का निर्णय केवल तब स्पष्ट होना चाहिए जब प्रणाली को फ़ाइल को इंडेक्स, वर्गीकृत, खोज या प्रबंधित करने के लिए ओपनिंग पासवर्ड के बिना आवश्यकता हो।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड से सुरक्षित करें**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
2. प्रस्तुति चुनें या अपलोड करें।
3. देखने के सुरक्षा के लिए पासवर्ड दर्ज करें।
4. वैकल्पिक रूप से संपादन सुरक्षा के लिए अलग पासवर्ड दर्ज करें।
5. सुरक्षा लागू करें और परिणामी फ़ाइल को डाउनलोड करें।

{{% alert color="info" title="See also" %}}
- [प्रस्तुति को लिखने-से-संरक्षित करें](/slides/hi/java/write-protected-presentation/)
- [PowerPoint में डिजिटल सिग्नेचर](/slides/hi/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**एक ओपनिंग पासवर्ड और लिखने-से-संरक्षण पासवर्ड में क्या अंतर है?**

ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और इसकी सामग्री लोड करने के लिए आवश्यक होता है। लिखने-से-संरक्षण पासवर्ड सामग्री को एन्क्रिप्ट किए बिना संशोधन को सीमित करता है।

**क्या मैं सभी स्लाइड्स लोड किए बिना ओपनिंग पासवर्ड को मान्य कर सकता हूँ?**

हाँ। प्रस्तुति जानकारी प्राप्त करें, देखें कि ओपनिंग-पासवर्ड सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनाने से पहले पासवर्ड को मान्य करें।

**क्या एप्लिकेशन ओपनिंग पासवर्ड के बिना मेटाडाटा पढ़ सकता है?**

हाँ, लेकिन केवल तब जब प्रस्तुति को दस्तावेज़-विशेषता एन्क्रिप्शन अक्षम करके एन्क्रिप्ट किया गया हो। तब एप्लिकेशन को [Manage Presentation Properties](/slides/hi/java/presentation-properties/) में वर्णित केवल-डॉक्यूमेंट-प्रॉपर्टीज़ लोडिंग मोड का उपयोग करना चाहिए।

**क्या पासवर्ड-चेकिंग वर्कफ़्लो दोनों PPT और PPTX के लिए समर्थन करते हैं?**

हाँ। फ़ाइल-पथ और स्ट्रीम-आधारित पासवर्ड पहचान और मान्यकरण दोनों PPT और PPTX प्रस्तुतियों के लिए समान रूप से कार्य करते हैं।