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
- निर्मित गुण
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
description: "Aspose.Slides for Android via Java में प्रस्तुति गुणों को प्रमुखता से नियंत्रित करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सरल बनाएँ।"
---
## **परिचय**

Aspose.Slides for Android via Java **निर्मित** और **कस्टम** दस्तावेज़ गुणों का समर्थन करता है। इन गुणों का उपयोग प्रस्तुति मेटाडेटा को पढ़ने और अपडेट करने के लिए किया जा सकता है, जैसे लेखक, शीर्षक, और उपयोगकर्ता‑परिभाषित मान।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस की एक इंस्टेंस [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) द्वारा वापस की जाती है। निम्न उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुतियों को सहेजते समय अनुप्रयोग और निर्माता मेटाडेटा को प्रबंधित करता है; ये फ़ील्ड उस सॉफ़्टवेयर की पहचान करते हैं जिसने आउटपुट बनाया।
{{% /alert %}}

## **प्रस्तुति गुणों का प्रबंधन**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहित करते हैं। वे दो श्रेणियों में विभाजित होते हैं:

- **निर्मित गुण** मानक मेटाडेटा रखते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ सांख्यिकी।
- **कस्टम गुण** उपयोगकर्ता‑परिभाषित नाम/मान जोड़े संग्रहीत करते हैं।

Aspose.Slides for Android via Java दोनों श्रेणियों तक पहुँच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडेटा देखने के लिए **File → Info → Properties → Advanced Properties** चुनें। यह संवाद बॉक्स जानकारी को **Summary**, **Statistics**, **Contents**, और **Custom** जैसे टैब में समूहित करता है। उपयोगकर्ता‑परिभाषित गुणों को प्रबंधित करने के लिए **Custom** टैब का उपयोग करें।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक खोलने वाला पासवर्ड आम तौर पर प्रस्तुति सामग्री और दस्तावेज़ गुणों दोनों की सुरक्षा करता है। जब कोई प्रस्तुति [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) को `false` के साथ कॉल करने के बाद एन्क्रिप्ट की जाती है, तो उसके दस्तावेज़ गुण सार्वजनिक रहते हैं। फिर कोई एप्लिकेशन [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` के साथ कॉल कर सकता है और खोलने वाला पासवर्ड दिए बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कोई चीज़ डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल हो जाएगा। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

उदाहरण को एक एन्क्रिप्टेड प्रस्तुति की आवश्यकता होती है जिसके दस्तावेज़ गुण सार्वजनिक छोड़े गए हों। यह लोडिंग मोड को [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) से सत्यापित करता है और फिर [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) के माध्यम से निर्मित गुण पढ़ता है:

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

इस मोड में, स्लाइड सामग्री लोड नहीं होती। स्लाइड, मास्टर, लेआउट, शेप, मीडिया और अन्य प्रस्तुति वस्तुएँ उपलब्ध नहीं रहतीं। एप्लिकेशन को हमेशा [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) जांचना चाहिए इससे पहले कि वह ऐसी क्रिया करे जिसके लिए पूरी प्रस्तुति ऑब्जेक्ट मॉडल आवश्यक हो।

{{% alert color="warning" title="Warning" %}}
सार्वजनिक मेटाडेटा से लेखक नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी और कस्टम मान उजागर हो सकते हैं। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। उन्हें केवल तब सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन प्रणालियों को बिना पासवर्ड के पहुंच की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुण अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, वह प्रस्तुति जिसे [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` के साथ कॉल करने के बाद लोड किया गया है, सार्वजनिक मेटाडेटा पढ़ने के लिए बनायी़ गई है। Aspose.Slides उस मेटाडेटा‑केवल ऑब्जेक्ट से बदले हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ संगत रहना चाहिए। इसलिए अपडेट करने के लिए सही खोलने वाला पासवर्ड और पूरी लोड आवश्यक है।

उदाहरण को एक एन्क्रिप्टेड PPTX प्रस्तुति की आवश्यकता होती है जिसमें सार्वजनिक दस्तावेज़ गुण हों और एक ज्ञात खोलने वाला पासवर्ड हो। यह पूरी प्रस्तुति को [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) के साथ खोलता है, सार्वजनिक निर्मित गुण अपडेट करता है, और परिणाम सहेजता है। फिर यह [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) का उपयोग करके एन्क्रिप्शन बरकरार है यह सत्यापित करता है और बिना पासवर्ड के सार्वजनिक मेटाडेटा को फिर से खोलकर नए मानों की जांच करता है:

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

## **निर्मित गुणों तक पहुँच**

[IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) इंटरफ़ेस getter मेथड्स के माध्यम से निर्मित मेटाडेटा उजागर करता है, जिसमें [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--) , [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) और [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--) शामिल हैं। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है और इसकी संग्रहित मेटाडेटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड खाली हो सकते हैं।

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

### **संशोधन संख्या और संपादन समय रिपोर्ट करें**

फोल्डर में प्रत्येक PPTX फ़ाइल के लिए एक पंक्ति रिपोर्ट करने के लिये, जिसे आपका Android ऐप पढ़ सकता है, [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) को कॉल करें ताकि स्लाइड लोड किए बिना उसके [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) पढ़ सकें। Android via Java API संपादन अवधि को मिलीसेकंड में लौटाता है। नमूना फोल्डर पाथ को अपनी फ़ाइलों के पाथ से बदलें। उदाहरण अवधि को घंटे, मिनट और सेकंड में स्वरूपित करता है, तथा 24 घंटे से अधिक अवधि के लिए दिन संख्या जोड़ता है।

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.File;
import java.util.Locale;

File folder = new File("/path/to/presentations");
File[] files = folder.listFiles();
if (files == null) {
    System.out.println("Cannot list files in " + folder);
} else {
    System.out.println("File | RevisionNumber | TotalEditingTime");
    for (File file : files) {
        if (!file.isFile() || !file.getName().toLowerCase(Locale.ROOT).endsWith(".pptx")) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(file.getAbsolutePath());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format(Locale.ROOT, "%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf(Locale.ROOT, "%s | %d | %s%n", file.getName(), properties.getRevisionNumber(), editingTime);
    }
}
```

1 दिन, 2 घंटे और 5 मिनट की दर्ज की गई संपादन अवधि वाली प्रस्तुति के लिये रिपोर्ट निम्न आउटपुट दिखाती है।

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getRevisionNumber--) वह मान पढ़ता है जिसे एप्लिकेशन [setRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-) से बदल सकते हैं। केवल संशोधन संख्या यह निर्धारित नहीं कर सकती कि प्रस्तुति कितनी बार सहेजी गई या उसका संस्करण इतिहास क्या है।

[getTotalEditingTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) फ़ाइल में दर्ज संपादन अवधि पढ़ता है। `00:00:00` का मान दर्शाता है कि संग्रहित अवधि शून्य है, भले ही किसी ने प्रस्तुति को संपादित किया हो।

## **निर्मित गुणों को संशोधित करें**

निर्मित मेटाडेटा को अपडेट करने के लिये, वह ऑब्जेक्ट जिस पर [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) लौटाता है, उस पर setter मेथड्स का उपयोग करें। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है, [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), और [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) को कॉल करता है, फिर अपडेटेड प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) से सहेजता है। सहेजा गया PPTX नई मेटाडेटा रखता है।

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

## **हाइपरलिंक बेस का प्रबंधन**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) रिलेटिव हाइपरलिंक के लिये दस्तावेज़‑स्तर बेस लौटाता है। इसे बदलने या साफ़ करने के लिये [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) का प्रयोग करें। यह तब उपयोगी होता है जब आप प्रस्तुति और उसकी लिंकड फ़ाइलों को किसी अन्य स्थान पर ले जा रहे हों। यह व्यक्तिगत हाइपरलिंक के [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) से अलग है: बेस बदलने से संग्रहीत लिंक एड्रेस नहीं बदलते और न ही निरपेक्ष गंतव्य बदलते हैं।

उदाहरण को एक प्रस्तुति चाहिए जिसमें एक रिलेटिव लिंक जैसे `target.html` और एक एब्सोल्यूट लिंक जैसे `https://example.org/absolute.html` दोनों हों। यह मौजूदा बेस पढ़ता है, नया बेस पता असाइन करता है, और वैल्यू की जाँच के लिये प्रस्तुति को सहेज कर फिर से खोलता है। फिर यह बेस को खाली स्ट्रिंग से साफ़ करता है और एक अलग सहेजी फ़ाइल में खाली वैल्यू की जाँच करता है। उदाहरण बेस पता को अपनी लिंक्ड फ़ाइलों के स्थान से बदलें।

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

दो सत्यापन संदेश `true` प्रिंट किए जाने चाहिए। बेस को साफ़ करने से व्यक्तिगत हाइपरलिंक एड्रेस अपरिवर्तित रहते हैं।

यदि बेस `old` फ़ोल्डर की ओर इशारा कर रहा था तो `target.pptx` के लिये रिलेटिव लिंक `old/target.pptx` खोलता था। बेस को `new` फ़ोल्डर पर बदलने, सहेजने और फिर से प्रस्तुति खोलने पर वही लिंक `new/target.pptx` खोलता है। एब्सोल्यूट लिंक वही फ़ाइल खोलता रहता है। प्रस्तुति को स्थानांतरित करने या बेस बदलने से पहले तथा बाद में PowerPoint में अपने रिलेटिव लिंक की जाँच करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण मेटाडेटा संग्रहीत करते हैं जिसका कोई संबंधित निर्मित फ़ील्ड नहीं होता। [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) मेथड आपको गुण नाम द्वारा मान असाइन करने देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक इंटीजर वर्ज़न मान जोड़ता है, और प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) से सहेजता है। मौजूदा नाम पर मान असाइन करने से उस गुण का मान ओवरराइट हो जाता है।

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

## **कस्टम गुणों तक पहुँच और संशोधन**

यह उदाहरण कस्टम गुणों वाली एक प्रस्तुति खोलता है और उन्हें इटरेट करने के लिये [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) का उपयोग करता है। [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) शून्य‑आधारित इंडेक्स स्वीकार करता है और वह नाम लौटाता है जो [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) द्वारा उपयोग किया गया था। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, हर मान को क्रमांकित स्ट्रिंग से बदल देता है चाहे उसका मूल प्रकार कुछ भी हो, और बदलाव सहेजता है। यदि कोई कस्टम गुण नहीं है, तो लूप कोई परिवर्तन नहीं करता।

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

[**व्यू & एडिट पॉवरपॉइंट मेटाडेटा**](https://products.aspose.app/slides/metadata) ऑनलाइन ऐप को आज़माएँ और देखें कि Aspose.Slides API का उपयोग करके दस्तावेज़ गुणों के साथ कैसे काम किया जाता है:

[![व्यू & एडिट पॉवरपॉइंट मेटाडेटा](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से निर्मित गुण को कैसे हटा सकता हूँ?**

निर्मित गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशिष्ट गुण अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं ऐसा कस्टम गुण जोड़ूँ जो पहले से मौजूद हो तो क्या होगा?**

यदि आप ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले गुण को हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वतः ही गुण के मान को अपडेट करता है।

**क्या मैं पूरी प्रस्तुति को लोड किए बिना प्रस्तुति गुणों तक पहुँच सकता हूँ?**

हाँ। आप [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करके प्रस्तुति की जानकारी प्राप्त कर सकते हैं और फिर [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) को कॉल करके बिना [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाए संग्रहीत दस्तावेज़ मेटाडेटा पढ़ सकते हैं। पूरी रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/androidjava/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को उसकी खोलने वाली पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। प्रस्तुति को तब एन्क्रिप्ट किया जाना चाहिए जब [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) को `false` के साथ कॉल किया गया हो, और इसे [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) को `true` के साथ कॉल करने के बाद लोड किया गया हो।

**क्या मैं दस्तावेज़‑गुण‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को संगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिये सही खोलने वाला पासवर्ड के साथ पूरी प्रस्तुति को लोड करना आवश्यक है।