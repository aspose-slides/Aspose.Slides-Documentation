---
title: Android में प्रस्तुति गुण प्रबंधित करें
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/androidjava/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुति गुण
- दस्तावेज़ गुण
- निर्मित-इन गुण
- कस्टम गुण
- उन्नत गुण
- गुण प्रबंधित करें
- गुण संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java में प्रस्तुति गुणों को प्रबंधित करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सहज बनाएं।"
---
## **परिचय**

Aspose.Slides for Android via Java **built-in** और **custom** दस्तावेज़ गुणों का समर्थन करता है। इन गुणों का उपयोग प्रस्तुति मेटाडेटा पढ़ने और अपडेट करने के लिए किया जा सकता है, जैसे लेखक, शीर्षक, और उपयोगकर्ता-परिभाषित मान।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस का एक उदाहरण [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) द्वारा लौटाया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुतियों को सहेजते समय एप्लिकेशन और उत्पादक मेटाडेटा का प्रबंधन करता है; ये फ़ील्ड उस सॉफ़्टवेयर की पहचान करती हैं जिसने आउटपुट बनाया।
{{% /alert %}}

## **प्रस्तुति गुण प्रबंधित करें**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। ये दो श्रेणियों में आते हैं:

- **Built-in properties** मानक मेटाडेटा शामिल करते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ आँकड़े।
- **Custom properties** उपयोगकर्ता-परिभाषित नाम/मान जोड़ों को संग्रहीत करते हैं।

Aspose.Slides for Android via Java दोनों श्रेणियों तक पहुँच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडेटा निरीक्षण के लिए **File → Info → Properties → Advanced Properties** चुनें। संवाद जानकारी को **Summary**, **Statistics**, **Contents**, और **Custom** जैसे टैब में समूहित करता है। उपयोगकर्ता-परिभाषित गुणों को प्रबंधित करने के लिए **Custom** टैब का उपयोग करें।

## **एनक्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक खोलने वाला पासवर्ड सामान्यतः दोनों प्रस्तुति सामग्री और दस्तावेज़ गुणों की सुरक्षा करता है। जब किसी प्रस्तुति को [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) को `false` के साथ कॉल करने के बाद एन्क्रिप्ट किया जाता है, तो उसके दस्तावेज़ गुण सार्वजनिक रहते हैं। तब एप्लिकेशन [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` के साथ कॉल कर सकता है और खोलने वाले पासवर्ड के बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) Aspose.Slides क्या लोड करता है, वह नियंत्रित करता है; यह कुछ भी डीक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल रहता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो विकल्प को नजरअंदाज किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

उदाहरण के लिए एक एन्क्रिप्टेड प्रस्तुति की आवश्यकता है जिसके दस्तावेज़ गुण सार्वजनिक रखे गए हों। यह लोडिंग मोड को [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) के माध्यम से सत्यापित करता है और फिर [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) के माध्यम से निर्मित‑इन गुण पढ़ता है:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

इस मोड में, स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर, लेआउट, शैप्स, मीडिया और अन्य प्रस्तुति ऑब्जेक्ट उपलब्ध नहीं होते। एप्लिकेशन को हमेशा [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) को जांचना चाहिए इससे पहले कि वह ऐसी क्रिया करे जो पूरी प्रस्तुति वस्तु मॉडल की आवश्यकता रखती हो।

{{% alert color="warning" title="Warning" %}}
सार्वजनिक मेटाडेटा लेखक नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी, और कस्टम मान उजागर कर सकता है। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। इन्हें केवल तभी सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन प्रणाली को पासवर्ड के बिना पहुँचने की विशेष आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुण अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, वह प्रस्तुति जो [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` के साथ कॉल करने के बाद लोड की जाती है, सार्वजनिक मेटाडेटा पढ़ने के उद्देश्य से होती है। Aspose.Slides उस केवल‑मेटाडेटा ऑब्जेक्ट से बदलें हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ संगत रहना चाहिए। इसलिए उन्हें अपडेट करने के लिए सही खोलने वाले पासवर्ड और पूरी लोड की आवश्यकता होती है।

उदाहरण के लिए एक एन्क्रिप्टेड PPTX प्रस्तुति की आवश्यकता है जिसमें सार्वजनिक दस्तावेज़ गुण हों और खुलने वाला पासवर्ड ज्ञात हो। यह पूरी प्रस्तुति को [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) के साथ खोलता है, सार्वजनिक निर्मित‑इन गुण अपडेट करता है, और परिणाम सहेजता है। फिर यह [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) का उपयोग करके एन्क्रिप्शन की सुरक्षा की पुष्टि करता है और पासवर्ड के बिना सार्वजनिक मेटाडेटा को पुनः खोलकर नए मानों की जाँच करता है:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

यदि कोई एप्लिकेशन प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं है, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने योग्य मानना चाहिए।

## **निर्मित‑इन गुणों तक पहुँच**

[IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) इंटरफ़ेस getter मेथड्स के माध्यम से निर्मित‑इन मेटाडेटा उजागर करता है, जिसमें [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--), और [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--) शामिल हैं। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है और उसके संग्रहीत मेटाडेटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड खाली हो सकते हैं।

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **निर्मित‑इन गुण संशोधित करें**

निर्मित‑इन मेटाडेटा अपडेट करने के लिए, [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) द्वारा लौटाए गए ऑब्जेक्ट पर setter मेथड्स का उपयोग करें। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है, [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), और [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) को कॉल करता है, फिर [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) के साथ अपडेटेड प्रस्तुति सहेजता है। सहेजे गए PPTX में नया मेटाडेटा होगा।

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **हाइपरलिंक बेस प्रबंधित करें**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) सापेक्ष हाइपरलिंक के लिए दस्तावेज़‑स्तर का बेस लौटाता है। इसे बदलने या साफ़ करने के लिए [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) उपयोग करें। यह तब उपयोगी होता है जब आप प्रस्तुति और उसकी लिंक्ड फ़ाइलों को किसी अन्य स्थान पर ले जाते हैं। यह व्यक्तिगत हाइपरलिंक के [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) से अलग है: बेस बदलने से संग्रहीत लिंक पते नहीं बदले जाते और न ही पूर्ण गंतव्य बदलते हैं।

यह उदाहरण एक प्रस्तुति की आवश्यकता रखता है जिसमें एक सापेक्ष लिंक, जैसे `target.html`, और एक पूर्ण लिंक, जैसे `https://example.org/absolute.html` मौजूद हों। यह मौजूदा बेस पढ़ता है, नया बेस पता असाइन करता है, और मूल्य जांचने के लिए प्रस्तुति सहेजकर पुनः खोलता है। फिर यह बेस को खाली स्ट्रिंग से साफ़ करता है और अलग सहेजी गई फ़ाइल में खाली मान की पुष्टि करता है। उदाहरण बेस एड्रेस को अपने लिंक्ड फ़ाइलों के स्थान से बदलें।

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

दो दोनों सत्यापन संदेश `true` प्रिंट करने चाहिए। बेस को साफ़ करने से व्यक्तिगत हाइपरलिंक पते वही रहते हैं।

`target.pptx` के लिए सापेक्ष लिंक ने तब `old/target.pptx` खोल दिया जब बेस `old` फ़ोल्डर की ओर इशारा करता था। बेस को `new` फ़ोल्डर में बदलने, सहेजने और प्रस्तुति को पुनः खोलने के बाद वही लिंक `new/target.pptx` खोलता है। पूर्ण लिंक वही फ़ाइल खोलता रहता है। प्रस्तुति को स्थानांतरित करने या बेस बदलने से पहले और बाद में PowerPoint में अपने सापेक्ष लिंक टेस्ट करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण मेटाडेटा संग्रहीत करते हैं जिसका कोई निर्मित‑इन फ़ील्ड नहीं होता। [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) मेथड आपको गुण नाम के आधार पर मान असाइन करने देती है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक पूर्णांक संस्करण मान जोड़ता है, और प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) के साथ सहेजता है। मौजूदा नाम को मान देने से उस गुण का मान बदल जाता है।

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **कस्टम गुणों तक पहुँच और संशोधित करें**

यह उदाहरण कस्टम गुणों वाली प्रस्तुति खोलता है और [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) का उपयोग करके उन पर इटरिटेट करता है। [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) शून्य‑आधारित इंडेक्स स्वीकार करता है और वह नाम लौटाता है जिसका उपयोग [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) करता है। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, सभी मानों को क्रमांकित स्ट्रिंग में बदल देता है चाहे उनका मूल प्रकार कुछ भी हो, और परिवर्तन सहेजता है। यदि कोई कस्टम गुण नहीं हैं, तो लूप कोई परिवर्तन नहीं करता।

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लाइव उदाहरण**

Try the [PowerPoint मेटाडेटा देखें और संपादित करें](https://products.aspose.app/slides/metadata) online app to see how to work with document properties using the Aspose.Slides API:
[![PowerPoint मेटाडेटा देखें और संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से निर्मित‑इन गुण कैसे हटा सकता हूँ?**

निर्मित‑इन गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि उस विशेष गुण द्वारा अनुमति दी गई हो तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं कोई मौजूदा कस्टम गुण जोड़ूँ तो क्या होगा?**

यदि आप कोई मौजूदा कस्टम गुण जोड़ते हैं, तो उसका मौजूदा मान नए मान से प्रतिस्थापित हो जाएगा। आपको पहले से गुण को हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण का मान अपडेट कर देता है।

**क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुँच सकता हूँ?**

हाँ। [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करें और फिर [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) के द्वारा संग्रहित दस्तावेज़ मेटाडेटा को बिना [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाए पढ़ें। पूर्ण रिपोर्ट उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/androidjava/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुण खोलने वाले पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। प्रस्तुति को [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) को `false` के साथ कॉल करने के बाद एन्क्रिप्ट किया गया होना चाहिए, और इसे [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` के साथ कॉल करने के बाद लोड किया जाना चाहिए।

**क्या मैं दस्तावेज़‑गुण‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को संगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही खोलने वाले पासवर्ड के साथ पूरी प्रस्तुति लोड करना आवश्यक है।