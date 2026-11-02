---
title: जावा में प्रस्तुतिकरण गुण प्रबंधित करें
linktitle: प्रस्तुतिकरण गुण
type: docs
weight: 70
url: /hi/java/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुतिकरण गुण
- दस्तावेज़ गुण
- निर्मित गुण
- कस्टम गुण
- उन्नत गुण
- गुण प्रबंधित करें
- गुण संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफिंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- जावा
- Aspose.Slides
description: "जावा के लिए Aspose.Slides में प्रस्तुतिकरण गुणों को नियंत्रित करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुगम बनाएँ।"
---
## **परिचय**

Aspose.Slides for Java **निर्मित** और **कस्टम** दस्तावेज़ गुणों को समर्थन देता है। इन गुणों का उपयोग प्रस्तुतिकरण मेटाडेटा को पढ़ने और अपडेट करने के लिए करें, जैसे लेखक, शीर्षक, और उपयोगकर्ता‑परिभाषित मान।

Aspose.Slides आपको प्रस्तुतिकरण दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस का एक उदाहरण [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) द्वारा लौटाया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जा सकता है।

{{% alert color="info" title="Note" %}}

Aspose.Slides प्रस्तुतिकरण सहेजते समय एप्लिकेशन और उत्पादकर्ता मेटाडेटा को प्रबंधित करता है; ये फ़ील्ड उस सॉफ़्टवेयर की पहचान करते हैं जिसने आउटपुट बनाया।

{{% /alert %}}

## **प्रस्तुतिकरण गुणों का प्रबंधन**

दस्तावेज़ गुण प्रस्तुतिकरण सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। ये दो श्रेणियों में विभाजित होते हैं:

- **निर्मित गुण** मानक मेटाडेटा रखते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ आँकड़े।
- **कस्टम गुण** उपयोगकर्ता‑परिभाषित नाम/मान जोड़े रखते हैं।

Aspose.Slides for Java दोनों श्रेणियों तक पहुंच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडेटा निरीक्षण करने के लिए **File → Info → Properties → Advanced Properties** चुनें। संवाद सूचना को **Summary**, **Statistics**, **Contents**, और **Custom** जैसे टैब में समूहित करता है। उपयोगकर्ता‑परिभाषित गुणों का प्रबंधन करने के लिए **Custom** टैब का उपयोग करें।

## **एनक्रिप्टेड प्रस्तुतिकरण से सार्वजनिक गुण पढ़ना**

एक खोलने वाला पासवर्ड सामान्यतः प्रस्तुतिकरण सामग्री और दस्तावेज़ गुण दोनों को सुरक्षित रखता है। जब एक प्रस्तुतिकरण को [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) को `false` के साथ कॉल करने के बाद एन्क्रिप्ट किया जाता है, तो उसके दस्तावेज़ गुण सार्वजनिक रह जाते हैं। तब एक एप्लिकेशन [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` के साथ कॉल करके बिना खोलने वाले पासवर्ड के सार्वजनिक मेटाडेटा पढ़ सकता है।

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) यह नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करने पर विफल हो जाता है। यदि प्रस्तुतिकरण एन्क्रिप्ट नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुतिकरण लोड हो जाती है।

उदाहरण में एक एन्क्रिप्टेड प्रस्तुतिकरण की आवश्यकता है जिसकी दस्तावेज़ गुण सार्वजनिक रखे गए हों। यह [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) द्वारा लोडिंग मोड की जाँच करता है और फिर [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) के माध्यम से निर्मित गुण पढ़ता है:

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

इस मोड में स्लाइड सामग्री लोड नहीं होती। स्लाइड, मास्टर, लेआउट, आकार, मीडिया, और अन्य प्रस्तुतिकरण ऑब्जेक्ट उपलब्ध नहीं होते। एप्लिकेशन को हमेशा [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) की जाँच करनी चाहिए इससे पहले कि वह ऐसी क्रिया करे जिसके लिए पूर्ण प्रस्तुतिकरण ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="Warning" %}}
सार्वजनिक मेटाडेटा में लेखक के नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणियाँ और कस्टम मान शामिल हो सकते हैं। संवेदनशील गुणों को प्रस्तुतिकरण के साथ एन्क्रिप्ट करें। उन्हें केवल तभी सार्वजनिक रखें जब अनुक्रमण, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन सिस्टम को पासवर्ड के बिना पहुंच की विशेष आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुतिकरण के गुण अपडेट करना**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` के साथ कॉल करने के बाद लोड किया गया प्रस्तुतिकरण सार्वजनिक मेटाडेटा पढ़ने के लिए अभिप्रेत है। Aspose.Slides उस केवल‑मेटाडेटा‑ऑब्जेक्ट से बदले गए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुतिकरण के अंदर के डेटा के साथ सुसंगत रहना चाहिए। इस कारण उन्हें सही खोलने वाले पासवर्ड और पूर्ण लोड की आवश्यकता होती है।

उदाहरण में एक एन्क्रिप्टेड PPTX प्रस्तुतिकरण की आवश्यकता है जिसके सार्वजनिक दस्तावेज़ गुण हों और एक ज्ञात खोलने वाला पासवर्ड हो। यह [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) के साथ पूरी प्रस्तुतिकरण खोलता है, सार्वजनिक निर्मित गुण अपडेट करता है, और परिणाम सहेजता है। फिर यह [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) का उपयोग करके एन्क्रिप्शन की जाँच करता है और पासवर्ड के बिना सार्वजनिक मेटाडेटा फिर से खोलकर नए मानों की पुष्टि करता है:

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

यदि किसी एप्लिकेशन को प्रस्तुतिकरण सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं है, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने‑योग्य मानना चाहिए।

## **निर्मित गुणों तक पहुंच**

[IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) इंटरफ़ेस गेटर मेथड्स के माध्यम से निर्मित मेटाडेटा उजागर करता है, जिसमें [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--), और [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--) शामिल हैं। यह उदाहरण मौजूदा प्रस्तुतिकरण खोलता है और उसकी संग्रहीत मेटाडेटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुतिकरण पर निर्भर करते हैं; कुछ फ़ील्ड खाली हो सकते हैं।

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

## **निर्मित गुणों को संशोधित करना**

निर्मित मेटाडेटा को अपडेट करने के लिए [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) द्वारा लौटाए गए ऑब्जेक्ट पर सेट्टर मेथड्स का उपयोग करें। यह उदाहरण मौजूदा प्रस्तुतिकरण खोलता है, [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), और [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) को कॉल करता है, फिर [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) के साथ अपडेटेड प्रस्तुतिकरण सहेजता है। सहेजे गए PPTX में नया मेटाडेटा शामिल होता है।

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **हाइपरलिंक बेस प्रबंधन**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) दस्तावेज़‑स्तर का बेस देता है जो सापेक्ष हाइपरलिंक के लिए उपयोग होता है। इसे बदलने या साफ़ करने के लिए [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) का उपयोग करें। यह तब उपयोगी होता है जब आप प्रस्तुतिकरण और उसकी लिंक की फ़ाइलों को किसी अन्य स्थान पर ले जाते हैं। यह व्यक्तिगत हाइपरलिंक के [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) से अलग है: बेस बदलने से संग्रहीत लिंक पतों को पुनर्लेखन या निरपेक्ष गंतव्य नहीं बदलता।

उदाहरण में एक प्रस्तुतिकरण की आवश्यकता है जिसमें एक सापेक्ष लिंक `target.html` और एक निरपेक्ष लिंक `https://example.org/absolute.html` दोनों हों। यह मौजूदा बेस पढ़ता है, नया बेस पता असाइन करता है, और मूल्य की जाँच के लिए प्रस्तुतिकरण सहेज कर फिर से खोलता है। फिर यह खाली स्ट्रिंग के साथ बेस को साफ़ करता है और अलग फाइल में खाली मान की पुष्टि करता है। उदाहरण बेस पते को अपनी लिंक फ़ाइलों के स्थान से बदलें।

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

दोनों सत्यापन संदेश `true` प्रिंट करेंगे। बेस को साफ़ करने से व्यक्तिगत हाइपरलिंक पते अपरिवर्तित रहते हैं।

सापेक्ष लिंक `target.pptx` ने बेस `old` फ़ोल्डर की ओर संकेत करने पर `old/target.pptx` खोला। बेस को `new` फ़ोल्डर में बदलने, सहेजने और फिर प्रस्तुतिकरण खोलने के बाद वही लिंक `new/target.pptx` खोलता है। निरपेक्ष लिंक वही फ़ाइल खोलता रहता है। अपने सापेक्ष लिंक को PowerPoint में प्रस्तुतिकरण को स्थानांतरित करने या बेस बदलने से पहले और बाद में परीक्षण करें।

## **कस्टम प्रस्तुतिकरण गुण जोड़ना**

कस्टम गुण वह मेटाडेटा संग्रहीत करते हैं जिसका कोई निर्मित फ़ील्ड नहीं होता। [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) मेथड आपको गुण नाम द्वारा मूल्य असाइन करने देता है। यह उदाहरण एक प्रस्तुतिकरण बनाता है, दो टेक्स्ट मान और एक पूर्णांक संस्करण मान जोड़ता है, और [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) के साथ प्रस्तुतिकरण सहेजता है। मौजूदा नाम को पुनः असाइन करने से उस गुण का मान बदल जाता है।

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

## **कस्टम गुणों तक पहुंच और संशोधन**

यह उदाहरण कस्टम गुणों वाले एक प्रस्तुतिकरण को खोलता है और [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) का उपयोग करके उन पर इटररेट करता है। [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) शून्य‑आधारित इंडेक्स लेता है और वह नाम लौटाता है जिसे [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) द्वारा उपयोग किया गया था। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, मूल प्रकार की परवाह किए बिना हर मान को क्रमांकित स्ट्रिंग से बदलता है, और परिवर्तन सहेजता है। यदि कोई कस्टम गुण नहीं हैं, तो लूप कोई बदलाव नहीं करता।

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

ऑनलाइन एप्लिकेशन [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) आज़माएँ ताकि आप Aspose.Slides API का उपयोग करके दस्तावेज़ गुणों के साथ काम करना देख सकें:

[![PowerPoint मेटाडेटा देखें और संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं किसी निर्मित गुण को प्रस्तुतिकरण से कैसे हटा सकता हूँ?**

निर्मित गुण प्रस्तुतिकरण का अभिन्न भाग होते हैं और उन्हें पूरी तरह हटाया नहीं जा सकता। हालांकि, आप उनके मान को बदल सकते हैं या यदि उस विशिष्ट गुण की अनुमति हो तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं ऐसे कस्टम गुण को जोड़ूँ जो पहले से मौजूद है तो क्या होगा?**

यदि आप ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से अधिलेखित हो जाएगा। आपको गुण को हटाने या पहले जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट कर देता है।

**क्या मैं पूर्ण प्रस्तुतिकरण लोड किए बिना प्रस्तुतिकरण गुणों तक पहुंच सकता हूँ?**

हां। [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करें और फिर [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) के साथ बिना [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) इंस्टांस बनाए संग्रहीत दस्तावेज़ मेटाडेटा पढ़ें। संपूर्ण रिपोर्ट उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/java/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुतिकरण के सार्वजनिक गुणों को बिना खोलने वाले पासवर्ड के पढ़ सकता हूँ?**

हां। प्रस्तुतिकरण को [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) को `false` के साथ कॉल करने के बाद एन्क्रिप्ट किया गया होना चाहिए, और इसे [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` के साथ कॉल करके लोड किया गया होना चाहिए।

**क्या मैं दस्तावेज़‑गुण‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को सुसंगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही खोलने वाले पासवर्ड के साथ पूर्ण प्रस्तुतिकरण लोड करना आवश्यक है।