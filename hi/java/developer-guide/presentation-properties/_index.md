---
title: Java में प्रस्तुति गुणों का प्रबंधन
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/java/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुति गुण
- दस्तावेज़ गुण
- बिल्ट-इन गुण
- कस्टम गुण
- उन्नत गुण
- गुणों का प्रबंधन
- गुणों को संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में प्रस्तुति गुणों को कुशलता से प्रबंधित करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सरल बनाएँ।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ गुणों का समर्थन करता है: **Built-in** और **Custom**। इन दोनों प्रकार के गुणों को आसानी से Aspose.Slides API का उपयोग करके एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने के लिए [IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/) इंटरफ़ेस प्रदान करता है। इस इंटरफ़ेस का एक उदाहरण [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getDocumentProperties--) द्वारा लौटाया जाता है। नीचे दिए गए उदाहरण इस बात को दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जा सकता है।

{{% alert color="info" title="नोट" %}}

कृपया ध्यान रखें कि **Application** और **AppVersion** फ़ील्ड को संशोधित नहीं किया जा सकता। Aspose.Slides प्रत्येक सहेजने पर इनको फिर से लिखता है, इसलिए सहेजी गई प्रस्तुति हमेशा "Aspose.Slides for Java" और लाइब्रेरी के संस्करण को रिपोर्ट करती है। `setNameOfApplication` को पास किया गया कोई भी मान प्रस्तुति लिखते समय त्याग दिया जाता है।

{{% /alert %}} 

## **PowerPoint में दस्तावेज़ गुण**

Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों को प्रबंधित करने की सुविधा देता है। आपको केवल Office आइकन पर क्लिक करना है और फिर **Prepare | Properties | Advanced Properties** मेनू आइटम को चुनना है, जैसा कि नीचे दिखाया गया है:

|**एडवांस्ड प्रॉपर्टीज मेन्यू आइटम चुनना**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**Advanced Properties** मेनू आइटम चुनने के बाद एक डायलॉग बॉक्स दिखाई देगा जो PowerPoint फ़ाइल के दस्तावेज़ गुणों को प्रबंधित करने की अनुमति देता है, जैसा कि नीचे के चित्र में दिखाया गया है:

|**प्रॉपर्टीज़ डायलॉग**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
ऊपर के **प्रॉपर्टीज़ डायलॉग** में आप देख सकते हैं कि कई टैब पेज हैं जैसे **General**, **Summary**, **Statistics**, **Contents** और **Custom**। इन सभी टैब पेजों के माध्यम से PowerPoint फ़ाइलों से संबंधित विभिन्न जानकारी को कॉन्फ़िगर किया जा सकता है। **Custom** टैब का उपयोग PowerPoint फ़ाइलों के कस्टम गुणों को प्रबंधित करने के लिए किया जाता है।

## **Aspose.Slides for Java के साथ दस्तावेज़ गुणों पर काम करना**

जैसा कि हमने पहले बताया था, Aspose.Slides for Java दो प्रकार के दस्तावेज़ गुणों का समर्थन करता है: **Built-in** और **Custom**। इसलिए, डेवलपर्स Aspose.Slides for Java API का उपयोग करके दोनों प्रकार के गुणों तक पहुँच सकते हैं। Aspose.Slides for Java एक क्लास [IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties) प्रदान करता है जो **Presentation.DocumentProperties** प्रॉपर्टी के माध्यम से प्रस्तुति फ़ाइल से जुड़े दस्तावेज़ गुणों का प्रतिनिधित्व करता है।

डेवलपर्स [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) ऑब्जेक्ट द्वारा उजागर की गई **IDocumentProperties** प्रॉपर्टी का उपयोग करके नीचे वर्णित तरीके से प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों तक पहुँच सकते हैं:

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक ओपनिंग पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुणों दोनों की रक्षा करता है। जब प्रस्तुति को `[IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)` को `false` पास करके एन्क्रिप्ट किया जाता है, तो उसके दस्तावेज़ गुण सार्वजनिक रहते हैं। फिर एप्लिकेशन `[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-)` को `true` पास करके ओपनिंग पासवर्ड के बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

`document-properties-only` विकल्प नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल रहेगा। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

निम्न उदाहरण `[IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)` के माध्यम से लोडिंग मोड को सत्यापित करता है और फिर `[IPresentation.getDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getDocumentProperties--)` के द्वारा बिल्ट‑इन गुण पढ़ता है:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

इस मोड में स्लाइड सामग्री लोड नहीं की जाती। स्लाइड्स, मास्टर्स, लेआउट, शेप्स, मीडिया और अन्य प्रस्तुति ऑब्जेक्ट उपलब्ध नहीं होते। एप्लिकेशन को हमेशा `[IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)` को जांचना चाहिए इससे पहले कि वह कोई ऐसी कार्रवाई करे जिसके लिए पूरी प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="चेतावनी" %}}
सार्वजनिक मेटाडेटा से लेखक के नाम, शीर्षक, विषय, कुंजी‑शब्द, कंपनी जानकारी, टिप्पणी और कस्टम मान उजागर हो सकते हैं। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। केवल तब सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज या दस्तावेज‑प्रबंधन प्रणालियों को पासवर्ड के बिना पहुंच की विशिष्ट आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुण अपडेट करें**

एन्क्रिप्टेड PPTX फ़ाइल के लिए, `document-properties-only` मोड में लोड की गई प्रस्तुति केवल सार्वजनिक मेटाडेटा पढ़ने के लिये होती है। Aspose.Slides उस मेटाडेटा‑only ऑब्जेक्ट से बदलें हुए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुण एन्क्रिप्टेड प्रस्तुति के अंदर मौजूद डेटा से संगत रहने चाहिए। इसलिए अपडेट करने के लिये सही ओपनिंग पासवर्ड और पूर्ण लोड आवश्यक है।

निम्न उदाहरण `[LoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)` के साथ प्रस्तुति खोलता है, सार्वजनिक बिल्ट‑इन गुण अपडेट करता है, और परिणाम सहेजता है। फिर यह `[IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#isEncrypted--)` का उपयोग करके एन्क्रिप्शन बनाए रखने की पुष्टि करता है और पासवर्ड के बिना सार्वजनिक मेटाडेटा फिर से खोलकर नई मानों की जाँच करता है:

```java
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
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

यदि किसी एप्लिकेशन को प्रस्तुति की सामग्री डिक्रिप्ट या लोड करने की अनुमति नहीं है, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने योग्य मानना चाहिए।

## **बिल्ट‑इन गुणों तक पहुँचें**

`IDocumentProperties` ऑब्जेक्ट द्वारा उजागर किए गए इन गुणों में शामिल हैं: **Creator** (लेखक), **Description**, **Keywords**, **Created** (निर्माण तिथि), **Modified** (संशोधन तिथि), **Printed** (आखिरी प्रिंट तिथि), **LastModifiedBy**, **SharedDoc** (क्या विभिन्न निर्माताओं के बीच साझा है?), **PresentationFormat**, **Subject**, और **Title**।

```java
import com.aspose.slides.*;

// प्रस्तुति का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का एक रेफ़रेंस बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // बिल्ट‑इन गुण प्रदर्शित करें
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **बिल्ट‑इन गुणों में संशोधन करें**

बिल्ट‑इन गुणों को संशोधित करना उतना ही आसान है जितना उन्हें एक्सेस करना। आप बस किसी इच्छित गुण को स्ट्रिंग वैल्यू असाइन कर दें और गुण का मान बदल जाएगा। नीचे दिए गए उदाहरण में हमने दिखाया है कि कैसे Aspose.Slides for Java का उपयोग करके प्रस्तुति फ़ाइल के बिल्ट‑इन दस्तावेज़ गुणों को संशोधित किया जा सकता है।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का रेफ़रेंस बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // बिल्ट‑इन गुण सेट करें
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // अपनी प्रस्तुति को फ़ाइल में सहेजें
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

यह उदाहरण संशोधित बील्ट‑इन गुणों को इस प्रकार दर्शाता है:

|**संपादन के बाद बिल्ट‑इन दस्तावेज़ गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **कस्टम दस्तावेज़ गुण जोड़ें**

Aspose.Slides for Java डेवलपर्स को प्रस्तुति दस्तावेज़ गुणों के लिए कस्टम मान जोड़ने की भी अनुमति देता है। नीचे दिया गया उदाहरण तीन कस्टम गुण जोड़ता है, फिर इंडेक्स 2 पर स्थित नाम को खोजता है और उस गुण को हटाता है, जिससे सहेजी गई प्रस्तुति में दो ही बचे रहते हैं। कस्टम गुणों को वर्णक्रम क्रम में क्रमबद्ध किया जाता है, न कि जोड़ने के क्रम में।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // दस्तावेज़ गुण प्राप्त करना
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // कस्टम गुण जोड़ना
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // विशिष्ट सूचकांक पर गुण का नाम प्राप्त करना
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // चयनित गुण हटाना
    dProps.removeCustomProperty(getPropertyName);
    
    // प्रस्तुति सहेजना
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**कस्टम दस्तावेज़ गुण जोड़े गए**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **कस्टम गुणों तक पहुँचें और संशोधित करें**

Aspose.Slides for Java डेवलपर्स को कस्टम गुणों की वैल्यूज़ तक पहुँचने की भी अनुमति देता है। नीचे दिया गया उदाहरण दिखाता है कि आप प्रस्तुति के सभी कस्टम गुणों को कैसे एक्सेस और संशोधित कर सकते हैं।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // प्रस्तुति से जुड़े DocumentProperties ऑब्जेक्ट का रेफ़रेंस बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // कस्टम गुणों तक पहुँचें और उन्हें संशोधित करें
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // कस्टम गुणों के नाम और मान प्रदर्शित करें
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // कस्टम गुणों के मान संशोधित करें
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // अपनी प्रस्तुति को फ़ाइल में सहेजें
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

यह उदाहरण `[PPTX ](https://docs.fileformat.com/presentation/pptx/)` प्रस्तुति के कस्टम गुणों को संशोधित करता है। नीचे के चित्र संशोधन से पहले और बाद के कस्टम गुणों को दर्शाते हैं:

|**संपादन से पहले कस्टम गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**संपादन के बाद कस्टम गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **उन्नत दस्तावेज़ गुण**

{{% alert color="info" title="नोट" %}}

नई विधियाँ [ReadDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), और [WriteBindedPresentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) को [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo) में जोड़ा गया है, तथा [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) प्रॉपर्टी सेट्टर की लॉजिक बदल दी गई है।

{{% /alert %}} 

नयी विधियाँ [ReadDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) और [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) को [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo) इंटरफ़ेस में जोड़ा गया है। ये दस्तावेज़ गुणों तक त्वरित पहुँच प्रदान करती हैं और पूरी प्रस्तुति लोड किए बिना गुणों को बदलने की अनुमति देती हैं।

सामान्य परिदृश्य में गुणों को लोड करें, कुछ मान बदलें और दस्तावेज़ को अपडेट करें, इसे इस तरह लागू किया जा सकता है:

```java
import com.aspose.slides.*;

// प्रस्तुति की जानकारी पढ़ें
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// वर्तमान गुण प्राप्त करें
IDocumentProperties props = info.readDocumentProperties();

// Author और Title फ़ील्ड के नए मान निर्धारित करें
props.setAuthor("New Author");
props.setTitle("New Title");

// नई मानों के साथ प्रस्तुति को अपडेट करें
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

किसी विशेष प्रस्तुति के गुणों को टेम्पलेट के रूप में उपयोग करके अन्य प्रस्तुतियों में गुण अपडेट करने का एक और तरीका है:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

एक नया टेम्पलेट शून्य से बनाया जा सकता है और फिर कई प्रस्तुतियों को अपडेट करने के लिये उपयोग किया जा सकता है:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides `PortionFormat` क्लास द्वारा उजागर की गई `LanguageId` प्रॉपर्टी प्रदान करता है जिससे आप PowerPoint दस्तावेज़ के लिये प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा वह भाषा है जिसका वर्तनी और व्याकरण PowerPoint में जाँच किया जाता है।

यह Java कोड दिखाता है कि PowerPoint के लिये प्रूफ़िंग भाषा कैसे सेट की जाती है:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // प्रूफ़िंग भाषा का Id सेट करें

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

यह Java कोड दिखाता है कि पूरे PowerPoint प्रस्तुति के लिये डिफ़ॉल्ट भाषा कैसे सेट की जाती है:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // नया आयताकार आकार पाठ के साथ जोड़ता है
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // पहले पोर्शन की भाषा की जाँच करता है
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **सीधा उदाहरण**

Aspose.Slides API के माध्यम से दस्तावेज़ गुणों के साथ काम करने के लिये ऑनलाइन एप्लिकेशन **Aspose.Slides Metadata** आज़माएँ:

[![PowerPoint मेटाडाटा देखें और संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से बिल्ट‑इन गुण कैसे हटा सकता हूँ?**

बिल्ट‑इन गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह हटाया नहीं जा सकता। हालांकि, आप उनकी मान बदल सकते हैं या यदि संबंधित गुण अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं एक कस्टम गुण जोड़ूँ जो पहले से मौजूद है तो क्या होता है?**

यदि आप ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले से गुण को हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides अपने‑आप गुण के मान को अपडेट कर देता है।

**क्या मैं प्रस्तुति को पूरी तरह लोड किए बिना उसके गुणों तक पहुँच सकता हूँ?**

हाँ। आप `[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)` का उपयोग करके फिर `[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)` से स्टोर किए गए दस्तावेज़ मेटाडेटा को पढ़ सकते हैं, बिना `[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/)` इंस्टेंस बनाए। पूर्ण रिपोर्टिंग उदाहरण और फॉर्मेट‑विशिष्ट सीमाओं के लिए देखें **[Build a Lightweight Presentation Inventory](/slides/hi/java/examine-presentation/)**।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुण ओपनिंग पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। दस्तावेज़‑गुण एन्क्रिप्शन को प्रस्तुति एन्क्रिप्ट होने से पहले निष्क्रिय किया जाना चाहिए, और प्रस्तुति को `document-properties-only` मोड में लोड किया जाना चाहिए।

**क्या मैं `document-properties-only` मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को संगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिये सही ओपनिंग पासवर्ड के साथ पूरी प्रस्तुति को लोड करना आवश्यक है।