---
title: Android पर प्रस्तुतियों को पासवर्ड‑सुरक्षित बनाना
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/androidjava/password-protected-presentation/
keywords:
- पासवर्ड‑सुरक्षित प्रस्तुति
- खोलने वाला पासवर्ड
- PowerPoint एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति पासवर्ड सत्यापित करें
- प्रस्तुति पासवर्ड जाँचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके पासवर्ड‑सुरक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पहचान, सत्यापित, खोलें और डिक्रिप्ट करें।"
---
## **अवलोकन**

एक खोलने वाला पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। सही पासवर्ड आवश्यक है ताकि प्रस्तुति की सामग्री लोड और देखी जा सके, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

एक खोलने वाला पासवर्ड लिखने‑सुरक्षा पासवर्ड से अलग होता है। लिखने‑सुरक्षा संशोधन को प्रतिबंधित करती है लेकिन सामग्री को एन्क्रिप्ट नहीं करती और प्रस्तुति को लोड होने से नहीं रोकती। प्रस्तुतियों को संशोधित करने के लिए पासवर्ड प्रबंधित करने हेतु देखें [Write‑Protect Presentations](/slides/hi/androidjava/write-protected-presentation/)।

नीचे दिया गया वर्कफ़्लो PPT और PPTX दोनों प्रस्तुतियों पर लागू होता है। उदाहरण दोनों प्रारूपों का उपयोग करते हैं जहाँ उनकी फ़ाइल‑आधारित और स्ट्रीम‑आधारित व्यवहार महत्वपूर्ण होते हैं।

## **एक खोलने वाले पासवर्ड से प्रस्तुति को एन्क्रिप्ट करना**

[IProtectionManager.encrypt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) का उपयोग करके एक खोलने वाला पासवर्ड असाइन करें। फिर एन्क्रिप्टेड प्रस्तुति को स्थायी बनाने के लिए [IPresentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) का प्रयोग करें।

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

## **एन्क्रिप्टेड प्रस्तुति को लोड करना**

[ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) को खोलने वाले पासवर्ड पर सेट करें और फ़ाइल लोड करते समय विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) को पास करें। यदि खोलने वाला पासवर्ड आवश्यक है लेकिन प्रदान किया गया पासवर्ड अनुपलब्ध या गलत है, तो लोडिंग विफल हो जाएगी।

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

प्रस्तुति को उसके खोलने वाले पासवर्ड के साथ लोड करें, फिर [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--) को कॉल करें और परिणाम को सहेजें। सहेजी गई प्रस्तुति अब पासवर्ड के बिना लोड की जा सकती है।

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

## **लोड करने से पहले खोलने वाला पासवर्ड सत्यापित करना**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करके [IPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/) प्राप्त करें बिना पूर्ण प्रस्तुति इंस्टेंस बनाए। पासवर्ड का अनुरोध या सत्यापन करने से पहले [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) की जाँच करें। जब सुरक्षा मौजूद हो, तो प्रदान किए गए मान को [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) के साथ सत्यापित करें।

### **फ़ाइल‑पाथ वर्कफ़्लो**

निम्न उदाहरण PPTX फ़ाइल के लिए खोलने वाला पासवर्ड सत्यापित करता है, सत्यापित मान को [ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) को पास करता है, और फिर पूर्ण प्रस्तुति को लोड करता है:

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) के स्ट्रीम ओवरलोड से वही वर्कफ़्लो मिलता है। पूर्ण प्रस्तुति को उस स्ट्रीम से लोड करने से पहले एक seekable स्ट्रीम की स्थिति रीसेट करें।

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

### **checkPassword वापसी मान**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) `true` तभी लौटाता है जब प्रस्तुति में खोलने वाला पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह `false` प्रत्येक निम्न मामलों में लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में खोलने वाला पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड `null` या खाली है।

व्यवहार PPT और PPTX दोनों प्रस्तुतियों के लिए समान है।

## **जांचें कि लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--) की जाँच करें ताकि यह पुष्टि हो सके कि स्रोत प्रस्तुति एन्क्रिप्टेड थी। लोड करने से पहले खोलने‑पासवर्ड सुरक्षा का पता लगाने के लिए ऊपर दर्शाए अनुसार `IPresentationInfo.isPasswordProtected` का उपयोग करें।

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

{{% alert color="warning" title="सुरक्षा" %}}
खोलने वाले पासवर्ड को लॉग न करें या उन्हें डायग्नोस्टिक संदेशों में न शामिल करें। अनावश्यक दोहराए गए सत्यापन प्रयासों से बचें, पासवर्ड को केवल आवश्यकतानुसार मेमोरी में रखें, और प्रस्तुति को तुरंत लोड करते समय सफल सत्यापन परिणाम को पुनः उपयोग करें।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड‑सुरक्षित बनाना**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
2. प्रस्तुति चुनें या अपलोड करें।
3. दृश्य सुरक्षा के लिए पासवर्ड दर्ज करें।
4. वैकल्पिक रूप से संपादन सुरक्षा के लिए अलग पासवर्ड दर्ज करें।
5. सुरक्षा लागू करें और परिणामी फ़ाइल डाउनलोड करें।

{{% alert color="info" title="और देखें" %}}
- [Write‑Protect Presentations](/slides/hi/androidjava/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**खोलने वाला पासवर्ड और लिखने‑सुरक्षा पासवर्ड में क्या अंतर है?**

एक खोलने वाला पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री लोड करने के लिये आवश्यक होता है। लिखने‑सुरक्षा पासवर्ड सामग्री को एन्क्रिप्ट किए बिना संशोधन को प्रतिबंधित करता है।

**क्या मैं सभी स्लाइड्स लोड किए बिना खोलने वाले पासवर्ड की जाँच कर सकता हूँ?**

हां। प्रस्तुति जानकारी प्राप्त करें, जांचें कि खोलने‑पासवर्ड सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनायें उससे पहले पासवर्ड सत्यापित करें।

**क्या पासवर्ड‑जाँच वर्कफ़्लोज़ दोनों PPT और PPTX को समर्थन देते हैं?**

हां। फ़ाइल‑पथ और स्ट्रीम‑आधारित पासवर्ड डिटेक्शन और वैलिडेशन PPT और PPTX दोनों प्रस्तुतियों के लिए समान रूप से कार्य करते हैं।