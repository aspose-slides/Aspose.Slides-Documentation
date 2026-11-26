---
title: जावा में प्रस्तुति गुणों का प्रबंधन
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/java/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुति गुण
- दस्तावेज़ गुण
- बिल्ट‑इन गुण
- कस्टम गुण
- उन्नत गुण
- गुणों का प्रबंधन
- गुणों को संशोधित करें
- दस्तावेज़ मेटाडाटा
- मेटाडाटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में प्रस्तुति गुणों को मास्टर करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुगम बनाएं।"
---
## **परिचय**

Aspose.Slides for Java **बिल्ट‑इन** और **कस्टम** दस्तावेज़ गुणों को समर्थन देता है। इन गुणों का उपयोग प्रस्तुति मेटाडाटा को पढ़ने और अपडेट करने के लिए किया जाता है, जैसे कि लेखक, शीर्षक, और उपयोगकर्ता‑परिभाषित मान।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस का एक उदाहरण [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) द्वारा लौटाया जाता है। नीचे दिए गए उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुति सहेजते समय एप्लिकेशन और उत्पादक मेटाडाटा को प्रबंधित करता है; ये फ़ील्ड वह सॉफ़्टवेयर पहचानते हैं जिसने आउटपुट बनाया।
{{% /alert %}}

## **प्रस्तुति गुणों का प्रबंधन**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। वे दो श्रेणियों में आते हैं:

- **बिल्ट‑इन गुण** मानक मेटाडाटा रखते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ सांख्यिकी।
- **कस्टम गुण** उपयोगकर्ता‑परिभाषित नाम/मान युग्म संग्रहीत करते हैं।

Aspose.Slides for Java दोनों श्रेणियों तक पहुंच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडाटा जांचने के लिए **File → Info → Properties → Advanced Properties** चुनें। संवाद जानकारी को **Summary**, **Statistics**, **Contents**, और **Custom** जैसे टैब में समूहित करता है। उपयोगकर्ता‑परिभाषित गुणों का प्रबंधन करने के लिए **Custom** टैब का उपयोग करें।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक खोलने वाला पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुणों दोनों की सुरक्षा करता है। जब कोई प्रस्तुति [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) को `false` के साथ कॉल करने के बाद एन्क्रिप्ट की जाती है, तो उसके दस्तावेज़ गुण सार्वजनिक रहते हैं। फिर कोई एप्लिकेशन [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` के साथ कॉल कर सकता है और खोलने वाला पासवर्ड प्रदान किए बिना सार्वजनिक मेटाडाटा पढ़ सकता है।

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) यह नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल हो जाता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

उदाहरण के लिए उस एन्क्रिप्टेड प्रस्तुति की आवश्यकता है जिसके दस्तावेज़ गुण सार्वजनिक रखे गए थे। यह लोडिंग मोड को [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) के माध्यम से सत्यापित करता है और फिर [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) के माध्यम से बिल्ट‑इन गुण पढ़ता है:

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

इस मोड में, स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर, लेआउट, शैप, मीडिया, और अन्य प्रस्तुति ऑब्जेक्ट अनुपलब्ध होते हैं। एप्लिकेशन को हमेशा [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) की जाँच करनी चाहिए इससे पहले कि वह ऐसा ऑपरेशन करे जिसके लिए पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="Warning" %}}
सार्वजनिक मेटाडाटा लेखक के नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी और कस्टम मान उजागर कर सकता है। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। उन्हें सार्वजनिक तभी रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन प्रणालियों को पासवर्ड के बिना उनका एक्सेस करने की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुणों को अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` के साथ कॉल करने के बाद लोड की गई प्रस्तुति सार्वजनिक मेटाडाटा पढ़ने के उद्देश्य से होती है। Aspose.Slides उस मेटाडाटा‑केवल ऑब्जेक्ट से बदलें हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर के संबंधित डेटा के साथ संगत रहना चाहिए। इसलिए उन्हें अपडेट करने के लिए सही खोलने वाला पासवर्ड और पूर्ण लोड आवश्यक है।

उदाहरण के लिए एक एन्क्रिप्टेड PPTX प्रस्तुति की आवश्यकता है जिसमें सार्वजनिक दस्तावेज़ गुण हों और एक ज्ञात खोलने वाला पासवर्ड हो। यह पूर्ण प्रस्तुति को [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) के साथ खोलता है, सार्वजनिक बिल्ट‑इन गुणों को अपडेट करता है, और परिणाम को सहेजता है। फिर यह [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) का उपयोग करके एन्क्रिप्शन बनी रहे यह सत्यापित करता है और पासवर्ड के बिना सार्वजनिक मेटाडाटा को फिर से खोलकर नए मानों की जाँच करता है:

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

यदि कोई एप्लिकेशन प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं रखता, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने योग्य मानना चाहिए।

## **बिल्ट‑इन गुणों तक पहुंच**

[IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) इंटरफ़ेसgetter मेथड्स के माध्यम से बिल्ट‑इन मेटाडाटा उजागर करता है, जिसमें [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--) और [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--) शामिल हैं। यह उदाहरण मौजूदा प्रस्तुति खोलता है और उसके संग्रहीत मेटाडाटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड खाली हो सकते हैं।

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

### **संस्करण संख्या और संपादन समय की रिपोर्ट**

`presentations` फ़ोल्डर में प्रत्येक PPTX फ़ाइल के लिए एक पंक्ति रिपोर्ट करने के लिए, [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) को कॉल करें जिससे स्लाइड्स को लोड किए बिना उसके [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) पढ़े जा सकें। Java API संपादन अवधि को मिलीसेकंड में लौटाती है। उदाहरण इसे घंटे, मिनट और सेकंड में फ़ॉर्मेट करता है, तथा 24 घंटे या उससे अधिक अवधि के लिए दिन गिनती भी जोड़ता है।

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

System.out.println("File | RevisionNumber | TotalEditingTime");
try (DirectoryStream<Path> files = Files.newDirectoryStream(Paths.get("presentations"), "*.pptx")) {
    for (Path path : files) {
        if (!Files.isRegularFile(path)) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(path.toString());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format("%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf("%s | %d | %s%n", path.getFileName(), properties.getRevisionNumber(), editingTime);
    }
}
```

एक प्रस्तुति जिसमें रिकॉर्ड किया गया संपादन समय 1 दिन, 2 घंटे और 5 मिनट है, रिपोर्ट निम्नलिखित आउटपुट दिखाती है।

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getRevisionNumber--) एक मान पढ़ता है जिसे एप्लिकेशन [setRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-) से बदल सकते हैं। केवल संस्करण संख्या यह निर्धारित नहीं कर सकती कि प्रस्तुति कितनी बार सहेजी गई या उसका संस्करण इतिहास कैसे पुनर्निर्मित किया गया।

[getTotalEditingTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) फ़ाइल में रिकॉर्ड की गई संपादन अवधि पढ़ता है। `00:00:00` मान का अर्थ है कि संग्रहीत अवधि शून्य है, भले ही किसी ने प्रस्तुति को संपादित किया हो।

## **बिल्ट‑इन गुणों को संशोधित करें**

बिल्ट‑इन मेटाडाटा को अपडेट करने के लिए, उन ऑब्जेक्ट पर सेट्टर मेथड्स का उपयोग करें जो [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) द्वारा लौटाया गया है। यह उदाहरण मौजूदा प्रस्तुति खोलता है, [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), और [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) को कॉल करता है, फिर अपडेट की गई प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) से सहेजता है। सहेजी गई PPTX में नया मेटाडाटा होता है।

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

## **हाइपरलिंक बेस का प्रबंधन**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) रिलेटिव हाइपरलिंक्स के लिए दस्तावेज़‑स्तर बेस लौटाता है। इसे बदलने या साफ़ करने के लिए [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) का उपयोग करें। यह प्रस्तुति और उसकी लिंक्ड फ़ाइलों को किसी अन्य स्थान पर ले जाने पर उपयोगी है। यह व्यक्तिगत हाइपरलिंक के [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) से अलग है: बेस बदलने से संग्रहीत लिंक एड्रेस नहीं लिखे जाते और न ही एब्सोल्यूट डेस्टिनेशन बदलता है।

उदाहरण के लिए एक ऐसी प्रस्तुति चाहिए जिसमें एक रिलेटिव लिंक जैसे `target.html` और एक एब्सोल्यूट लिंक जैसे `https://example.org/absolute.html` हो। यह मौजूदा बेस पढ़ता है, नया बेस एड्रेस असाइन करता है, फिर मूल्य जाँचने के लिए प्रस्तुति को सहेजता और फिर खुलता है। इसके बाद यह बेस को खाली स्ट्रिंग से साफ़ करता है और अलग सहेजी फ़ाइल में खाली मूल्य सत्यापित करता है। उदाहरण बेस एड्रेस को अपनी लिंक्ड फ़ाइलों के स्थान से बदलें।

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

दोनों सत्यापन संदेश `true` प्रिंट करेंगे। बेस को साफ़ करने से व्यक्तिगत हाइपरलिंक एड्रेस अपरिवर्तित रहते हैं।

`target.pptx` को एक रिलेटिव लिंक ने `old/target.pptx` खोला जब बेस `old` फ़ोल्डर की ओर इशारा कर रहा था। बेस को `new` फ़ोल्डर में बदलने, सहेजने और फिर प्रस्तुति खोलने पर वही लिंक `new/target.pptx` खोलता है। एब्सोल्यूट लिंक वही फ़ाइल खोलता रहा। प्रस्तुति को स्थानांतरित करने या उसका बेस बदलने से पहले और बाद में PowerPoint में अपने रिलेटिव लिंक की जाँच करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण ऐसे मेटाडाटा संग्रहीत करते हैं जिनका कोई मेल खाने वाला बिल्ट‑इन फ़ील्ड नहीं होता। [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) मेथड आपको प्रॉपर्टी नाम द्वारा मान असाइन करने देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक पूर्णांक संस्करण मान जोड़ता है, और प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) से सहेजता है। मौजूदा नाम पर मान असाइन करने से उस गुण का मान बदल जाता है।

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

यह उदाहरण कस्टम गुणों वाली एक प्रस्तुति खोलता है और उन्हें पार करने के लिए [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) का उपयोग करता है। [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) शून्य‑आधारित इंडेक्स स्वीकार करता है और उस नाम को लौटाता है जिसका उपयोग [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) करता है। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, मूल प्रकार की परवाह किए बिना प्रत्येक मान को क्रमांकित स्ट्रिंग से बदल देता है, और परिवर्तन सहेजता है। यदि कोई कस्टम गुण नहीं है, तो लूप कोई परिवर्तन नहीं करता।

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

दस्तावेज़ गुणों के साथ काम करने के लिए Aspose.Slides API का उपयोग करके, ऑनलाइन ऐप [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) को आज़माएँ:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रस्तुति से बिल्ट‑इन गुण को कैसे हटाया जा सकता है?**

बिल्ट‑इन गुण प्रस्तुति का अभिन्न हिस्सा हैं और उन्हें पूरी तरह हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशिष्ट गुण अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं एक कस्टम गुण जोड़ता हूं जो पहले से मौजूद है तो क्या होता है?**

यदि आप एक कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले से गुण को हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट कर देता है।

**क्या मैं पूरी तरह प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुंच सकता हूं?**

Yes. Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) and then [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) to read stored document metadata without creating a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instance. See [हल्की प्रस्तुति सूची बनाना](/slides/hi/java/examine-presentation/) for a complete reporting example and format-specific limitations.

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को उसके खोलने वाले पासवर्ड के बिना पढ़ सकता हूं?**

Yes. The presentation must have been encrypted after calling [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) with `false`, and it must be loaded after calling [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) with `true`.

**क्या मैं दस्तावेज़‑गुण‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूं?**

No. Public and encrypted property data must remain consistent, so updating an encrypted PPTX file requires loading the complete presentation with the correct opening password.