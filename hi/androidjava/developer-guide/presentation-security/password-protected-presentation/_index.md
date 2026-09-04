---
title: एंड्रॉइड पर प्रस्तुतियों को पासवर्ड से सुरक्षित करें
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/androidjava/password-protected-presentation/
keywords:
- पासवर्ड-संरक्षित प्रस्तुति
- ओपनिंग पासवर्ड
- PowerPoint एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति पासवर्ड को मान्य करें
- प्रस्तुति पासवर्ड जाँचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके जावा के माध्यम से पासवर्ड-संरक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पहचान, मान्य, खोल और डिक्रिप्ट करें।"
---
## **अवलोकन**

एक ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। सही पासवर्ड प्रस्तुतिकरण की सामग्री को लोड करने और देखने के लिए आवश्यक होता है, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

एक ओपनिंग पासवर्ड लिखने-से-रक्षा पासवर्ड से अलग होता है। लेखन सुरक्षा संशोधन को सीमित करती है लेकिन सामग्री को एन्क्रिप्ट नहीं करती या प्रस्तुति को लोड होने से नहीं रोकती। प्रस्तुतियों में संशोधन के लिए पासवर्ड प्रबंधित करने हेतु देखें [Write-Protect Presentations](/slides/hi/androidjava/write-protected-presentation/)।

नीचे दिए गए कार्यप्रवाह दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों प्रारूपों का उपयोग करते हैं जहाँ उनकी फ़ाइल-आधारित और स्ट्रीम-आधारित व्यवहार महत्वपूर्ण होता है।

## **एक ओपनिंग पासवर्ड के साथ प्रस्तुति को एन्क्रिप्ट करना**

ओपनिंग पासवर्ड सौंपने के लिए [IProtectionManager.encrypt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) का उपयोग करें। फिर एन्क्रिप्टेड प्रस्तुति को सहेजने के लिए [IPresentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) का उपयोग करें।

निम्न उदाहरण PPTX प्रस्तुति को एन्क्रिप्ट करता है:

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

## **दस्तावेज़ गुणों को सार्वजनिक रखें**

डिफ़ॉल्ट रूप से, Aspose.Slides प्रस्तुति एन्क्रिप्शन में दस्तावेज़ गुणों को शामिल करता है। यह व्यवहार स्लाइड-सामग्री एन्क्रिप्शन से स्वतंत्र रूप से नियंत्रित करने के लिए [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) विधि का उपयोग किया जाता है। जब किसी इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़-प्रबंधन प्रणाली को ओपनिंग पासवर्ड के बिना मेटाडेटा पढ़ना आवश्यक हो, तो [IProtectionManager.encrypt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) को कॉल करने से पहले `false` पास करें।

नीचे दिया गया उदाहरण एन्क्रिप्टेड PPTX प्रस्तुति बनाता है जबकि इसके अंतर्निहित दस्तावेज़ गुणों को सार्वजनिक रखता है:

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

`false` को [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) में पास करने से स्लाइड्स, मास्टर्स, लेआउट्स, शैप्स, मीडिया, या अन्य प्रस्तुति सामग्री सार्वजनिक नहीं होती। यह केवल दस्तावेज़ गुणों को प्रभावित करता है। एन्क्रिप्टेड सामग्री लोड किए बिना उन गुणों को पढ़ने के लिए देखें [Manage Presentation Properties](/slides/hi/androidjava/presentation-properties/)।

## **एन्क्रिप्टेड प्रस्तुति लोड करना**

[ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) को ओपनिंग पासवर्ड पर सेट करें और फ़ाइल लोड करते समय विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) को पास करें। यदि ओपनिंग पासवर्ड आवश्यक है लेकिन प्रदान किया गया पासवर्ड अनुपलब्ध या गलत है, तो लोडिंग विफल हो जाएगी।

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

## **प्रस्तुति से एन्क्रिप्शन हटाना**

प्रस्तुति को उसके ओपनिंग पासवर्ड के साथ लोड करें, फिर [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) को कॉल करें और परिणाम को सहेजें। सहेजी गई प्रस्तुति को अब बिना पासवर्ड के लोड किया जा सकता है।

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

## **लोड करने से पहले ओपनिंग पासवर्ड को सत्यापित करना**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करके बिना पूर्ण प्रस्तुति इंस्टेंस बनाए [IPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/) प्राप्त करें। पासवर्ड का अनुरोध या सत्यापन करने से पहले [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) को जांचें। जब सुरक्षा मौजूद हो, तो प्रदान किए गए मान को [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) से सत्यापित करें।

### **फ़ाइल-पथ कार्यप्रवाह**

निम्न उदाहरण PPTX फ़ाइल के लिए ओपनिंग पासवर्ड को वैध करता है, वैध मान को [ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) को पास करता है, और फिर पूरी प्रस्तुति को लोड करता है:

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) का स्ट्रीम ओवरलोड समान कार्यप्रवाह प्रदान करता है। उस स्ट्रीम से पूर्ण प्रस्तुति लोड करने से पहले एक seekable स्ट्रीम की स्थिति रीसेट करें।

निम्न उदाहरण PPT फ़ाइल का उपयोग करता है:

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) केवल तब `true` लौटाता है जब प्रस्तुति में ओपनिंग पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह प्रत्येक निम्न स्थितियों में `false` लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में ओपनिंग पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड `null` या खाली है।

यह व्यवहार PPT और PPTX प्रस्तुतियों के लिए समान है।

## **क्या लोड की गई प्रस्तुति एन्क्रिप्टेड है, यह जांचें**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, स्रोत प्रस्तुति एन्क्रिप्टेड थी या नहीं, यह पुष्टि करने के लिए [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) को जाँचें। लोड करने से पहले ओपनिंग पासवर्ड सुरक्षा का पता लगाने के लिए ऊपर दिखाए अनुसार `IPresentationInfo.isPasswordProtected` का उपयोग करें।

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
ओपनिंग पासवर्ड को लॉग न करें या उन्हें निदान संदेशों में शामिल न करें। अनावश्यक दोहराए गए सत्यापन प्रयासों से बचें, पासवर्ड केवल आवश्यक समय तक मेमोरी में रखें, और जब तुरंत प्रस्तुति लोड हो रही हो तो सफल सत्यापन परिणाम को पुन: उपयोग करें।

सार्वजनिक दस्तावेज़ गुण लेखक के नाम, शीर्षक, विषय, कुंजीशब्द, कंपनी जानकारी, टिप्पणी, और कस्टम मान उजागर कर सकते हैं जबकि प्रस्तुति की सामग्री एन्क्रिप्टेड है। संवेदनशील मेटाडेटा को प्रस्तुति के साथ एन्क्रिप्ट करें। गुणों को सार्वजनिक छोड़ना एक स्पष्ट निर्णय होना चाहिए और केवल तभी किया जाना चाहिए जब प्रणाली को फ़ाइल को इंडेक्स, वर्गीकृत, खोज या प्रबंधित करने के लिए ओपनिंग पासवर्ड के बिना आवश्यक हो।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड-सेक्योर करना**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
2. प्रस्तुति को चुनें या अपलोड करें।
3. देखने की सुरक्षा के लिए पासवर्ड दर्ज करें।
4. वैकल्पिक रूप से संपादन सुरक्षा के लिए अलग पासवर्ड दर्ज करें।
5. सुरक्षा लागू करें और प्राप्त फ़ाइल को डाउनलोड करें।

{{% alert color="info" title="See also" %}}
- [प्रस्तुतियों को लेखन-रक्षा देना](/slides/hi/androidjava/write-protected-presentation/)
- [PowerPoint में डिजिटल सिग्नेचर](/slides/hi/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**ओपनिंग पासवर्ड और लिखने-से-रक्षा पासवर्ड में क्या अंतर है?**

ओपनिंग पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री को लोड करने के लिए आवश्यक होता है। लिखने-से-रक्षा पासवर्ड सामग्री को एन्क्रिप्ट किए बिना संशोधन को सीमित करता है।

**क्या मैं सभी स्लाइड्स लोड किए बिना ओपनिंग पासवर्ड को सत्यापित कर सकता हूँ?**

हां। प्रस्तुति जानकारी प्राप्त करें, जांचें कि ओपनिंग पासवर्ड सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनाने से पहले पासवर्ड को सत्यापित करें।

**क्या कोई एप्लिकेशन ओपनिंग पासवर्ड के बिना मेटाडेटा पढ़ सकता है?**

हां, लेकिन केवल तब जब प्रस्तुति को दस्तावेज़-गुण एन्क्रिप्शन अक्षम करके एन्क्रिप्ट किया गया हो। तब एप्लिकेशन को [Manage Presentation Properties](/slides/hi/androidjava/presentation-properties/) में वर्णित दस्तावेज़-गुण-केवल लोडिंग मोड का उपयोग करना होगा।

**क्या पासवर्ड-चेकिंग कार्यप्रवाह दोनों PPT और PPTX को समर्थन देते हैं?**

हां। फ़ाइल-पथ और स्ट्रीम-आधारित पासवर्ड पहचान और सत्यापन दोनों PPT और PPTX प्रस्तुतियों के लिए समान व्यवहार रखते हैं।