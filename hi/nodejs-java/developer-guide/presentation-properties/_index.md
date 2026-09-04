---
title: जावास्क्रिप्ट में प्रस्तुति प्रॉपर्टी प्रबंधन
linktitle: प्रस्तुति प्रॉपर्टीज़
type: docs
weight: 70
url: /hi/nodejs-java/presentation-properties/
keywords:
- PowerPoint प्रॉपर्टीज़
- प्रस्तुति प्रॉपर्टीज़
- दस्तावेज़ प्रॉपर्टीज़
- बिल्ट-इन प्रॉपर्टीज़
- कस्टम प्रॉपर्टीज़
- एडवांस्ड प्रॉपर्टीज़
- प्रॉपर्टीज़ प्रबंधन
- प्रॉपर्टीज़ संशोधन
- दस्तावेज़ मेटाडाटा
- मेटाडाटा संपादन
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java में प्रस्तुति प्रॉपर्टीज़ को मास्टर करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सरल बनाएं."
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ का समर्थन करता है: **Built-in** और **Custom**. इन दोनों प्रॉपर्टी प्रकारों को Aspose.Slides API का उपयोग करके आसानी से एक्सेस और प्रबंधित किया जा सकता है.

Aspose.Slides आपको प्रेजेंटेशन दस्तावेज़ प्रॉपर्टीज़ को [DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/) क्लास के माध्यम से काम करने की सुविधा देता है। इस क्लास का एक इंस्टेंस [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDocumentProperties) मेथड द्वारा लौटाया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन प्रॉपर्टीज़ को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="info" title="Note" %}}
कृपया ध्यान दें कि **Application** और **AppVersion** फ़ील्ड को संशोधित नहीं किया जा सकता। Aspose.Slides प्रत्येक सहेजने पर इन्हें पुनः लिखता है, इसलिए सहेजी गई प्रस्तुति हमेशा "Aspose.Slides for Node.js via Java" और उस लाइब्रेरी का संस्करण बताती है जिसने इसे बनाया था। `setNameOfApplication` को पास किया गया कोई भी मान प्रस्तुति लिखते समय त्याग दिया जाता है।
{{% /alert %}} 

## **प्रेजेंटेशन प्रॉपर्टीज़ प्रबंधित करें**

Microsoft PowerPoint एक सुविधा प्रदान करता है जिससे प्रेजेंटेशन फ़ाइलों में कुछ प्रॉपर्टीज़ जोड़ी जा सकती हैं। ये दस्तावेज़ प्रॉपर्टीज़ उपयोगी जानकारी को दस्तावेज़ों (प्रेजेंटेशन फ़ाइलों) के साथ संग्रहीत करने की अनुमति देती हैं। दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ हैं:

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** प्रॉपर्टीज़ में दस्तावेज़ के बारे में सामान्य जानकारी होती है जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ आँकड़े आदि। **Custom** प्रॉपर्टीज़ वे हैं जिन्हें उपयोगकर्ता **Name/Value** जोड़े के रूप में परिभाषित करते हैं, जहाँ नाम और मान दोनों उपयोगकर्ता द्वारा निर्धारित होते हैं। Aspose.Slides for Node.js via Java का उपयोग करके, डेवलपर्स built-in और custom दोनों प्रॉपर्टीज़ के मानों तक पहुँच सकते हैं और उन्हें संशोधित कर सकते हैं।

## **PowerPoint में दस्तावेज़ प्रॉपर्टीज़**

Microsoft PowerPoint 2007 प्रेजेंटेशन फ़ाइलों की दस्तावेज़ प्रॉपर्टीज़ का प्रबंधन करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करना है और आगे **Prepare | Properties | Advanced Properties** मेन्यू आइटम को चुनना है जैसा कि नीचे दिखाया गया है:

|**उन्नत प्रॉपर्टीज़ मेन्यू आइटम का चयन**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** मेन्यू आइटम चुनने के बाद, एक डायलॉग दिखाई देगा जो आपको PowerPoint फ़ाइल की दस्तावेज़ प्रॉपर्टीज़ को प्रबंधित करने की अनुमति देता है, जैसा कि नीचे चित्र में दिखाया गया है:

|**प्रॉपर्टीज़ डायलॉग**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

उपरोक्त **प्रॉपर्टीज़ डायलॉग** में, आप देख सकते हैं कि कई टैब पेज हैं जैसे **General**, **Summary**, **Statistics**, **Contents** और **Custom**। ये सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब PowerPoint फ़ाइलों की कस्टम प्रॉपर्टीज़ को प्रबंधित करने के लिए उपयोग किया जाता है।

### Aspose.Slides for Node.js via Java का उपयोग करके दस्तावेज़ प्रॉपर्टीज़ के साथ कार्य करना

जैसा कि हमने पहले बताया था, Aspose.Slides for Node.js via Java दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ का समर्थन करता है, जो **Built-in** और **Custom** प्रॉपर्टीज़ हैं। इसलिए, डेवलपर्स Aspose.Slides for Node.js via Java API का उपयोग करके दोनों प्रकार की प्रॉपर्टीज़ तक पहुँच सकते हैं। Aspose.Slides for Node.js via Java एक क्लास [DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties) प्रदान करता है जो **Presentation.DocumentProperties** प्रॉपर्टी के माध्यम से प्रस्तुति फ़ाइल से जुड़ी दस्तावेज़ प्रॉपर्टीज़ का प्रतिनिधित्व करता है।

डेवलपर्स **DocumentProperties** प्रॉपर्टी का उपयोग कर सकते हैं जो [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) ऑब्जेक्ट द्वारा उजागर होती है, ताकि प्रस्तुति फ़ाइलों की दस्तावेज़ प्रॉपर्टीज़ तक नीचे वर्णित अनुसार पहुँच सकें:

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक प्रॉपर्टीज़ पढ़ें**

एक खोलने वाला पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ प्रॉपर्टीज़ दोनों की सुरक्षा करता है। जब प्रस्तुति को `false` पास करके [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) से एन्क्रिप्ट किया जाता है, तो उसकी दस्तावेज़ प्रॉपर्टीज़ सार्वजनिक रहती हैं। फिर एक एप्लिकेशन `true` पास करके [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) को कॉल कर सकता है और खोलने वाला पासवर्ड दिए बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

document-properties-only विकल्प यह नियंत्रित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डीक्रिप्ट नहीं करता। यदि प्रॉपर्टीज़ एन्क्रिप्शन में शामिल थीं, तो पासवर्ड के बिना लोड करना विफल हो जाता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड हो जाती है।

निम्नलिखित उदाहरण [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) के माध्यम से लोडिंग मोड को सत्यापित करता है और फिर [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDocumentProperties) के द्वारा built-in प्रॉपर्टीज़ पढ़ता है:

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

इस मोड में स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर्स, लेआउट्स, शैप्स, मीडिया और अन्य प्रस्तुति ऑब्जेक्ट उपलब्ध नहीं होते। एप्लिकेशन को हमेशा [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) की जाँच करनी चाहिए इससे पहले कि वह ऐसी ऑपरेशन करे जिसे पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="Warning" %}}
सार्वजनिक मेटाडेटा में लेखक के नाम, शीर्षक, विषय, कीवर्ड, कंपनी जानकारी, टिप्पणी और कस्टम मान उजागर हो सकते हैं। संवेदनशील प्रॉपर्टीज़ को प्रस्तुति के साथ एन्क्रिप्ट करें। उन्हें केवल तभी सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़-प्रबंधन सिस्टम को पासवर्ड के बिना एक्सेस करने की विशेष आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति की प्रॉपर्टीज़ अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, document-properties-only मोड में लोड की गई प्रस्तुति को सार्वजनिक मेटाडेटा पढ़ने के लिये उपयोग किया जाता है। Aspose.Slides उस metadata-only ऑब्जेक्ट से बदली हुई प्रॉपर्टीज़ को सहेज नहीं सकता क्योंकि सार्वजनिक प्रॉपर्टीज़ को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ सुसंगत रहना आवश्यक है। इसलिए उन्हें अपडेट करने के लिए सही खोलने वाला पासवर्ड और पूर्ण लोड आवश्यक है।

निम्नलिखित उदाहरण [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword) के साथ प्रस्तुति को खोलता है, सार्वजनिक built-in प्रॉपर्टीज़ को अपडेट करता है, और परिणाम सहेजता है। फिर यह [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) का उपयोग करके जांचता है कि एन्क्रिप्शन बना रहता है और पासवर्ड के बिना सार्वजनिक मेटाडेटा को फिर से खोलकर नए मानों की पुष्टि करता है:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

यदि कोई एप्लिकेशन प्रस्तुति सामग्री को डीक्रिप्ट या लोड करने की अनुमति नहीं रखता, तो उसे एन्क्रिप्टेड PPTX फ़ाइल की सार्वजनिक प्रॉपर्टीज़ को केवल-पढ़ने योग्य मानना चाहिए।

## **Built-in प्रॉपर्टीज़ तक पहुंचें**

इन प्रॉपर्टीज़ को [DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties) ऑब्जेक्ट द्वारा उजागर किया जाता है और इनमें शामिल हैं: **Creator** (लेखक), **Description**, **Keywords**, **Created** (निर्माण तिथि), **Modified** (संशोधन तिथि), **Printed** (अंतिम प्रिंट तिथि), **LastModifiedBy**, **SharedDoc** (क्या विभिन्न निर्माताओं के बीच साझा है?), **PresentationFormat**, **Subject**, और **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// प्रस्तुति को दर्शाने वाली Presentation क्लास को instantiate करें
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का रेफ़रेंस बनायें
    var dp = pres.getDocumentProperties();
    // बिल्ट‑इन प्रॉपर्टीज़ प्रदर्शित करें
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Built-in प्रॉपर्टीज़ संशोधित करें**

प्रेजेंटेशन फ़ाइलों की built-in प्रॉपर्टीज़ को संशोधित करना उन्हें एक्सेस करने जितना ही सरल है। आप बस किसी भी वांछित प्रॉपर्टी को एक स्ट्रिंग मान असाइन कर सकते हैं और प्रॉपर्टी मान संशोधित हो जाएगा। नीचे दिए गए उदाहरण में, हमने दिखाया है कि कैसे Aspose.Slides for Node.js via Java का उपयोग करके प्रेजेंटेशन फ़ाइल की built-in दस्तावेज़ प्रॉपर्टीज़ को संशोधित किया जा सकता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का रेफ़रेंस बनाएँ
    var dp = pres.getDocumentProperties();
    // बिल्ट‑इन प्रॉपर्टीज़ सेट करें
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // अपनी प्रस्तुति को एक फ़ाइल में सहेजें
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

यह उदाहरण प्रस्तुति की built-in प्रॉपर्टीज़ को संशोधित करता है जिसे नीचे दिखाया गया है:

|**संशोधन के बाद Built-in दस्तावेज़ प्रॉपर्टीज़**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **कस्टम दस्तावेज़ प्रॉपर्टीज़ जोड़ें**

Aspose.Slides for Node.js via Java डेवलपर्स को प्रेजेंटेशन दस्तावेज़ प्रॉपर्टीज़ के कस्टम मान जोड़ने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि प्रस्तुति के लिए कस्टम प्रॉपर्टीज़ कैसे सेट की जाएँ।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // दस्तावेज़ प्रॉपर्टीज़ प्राप्त कर रहा है
    var dProps = pres.getDocumentProperties();
    // कस्टम प्रॉपर्टीज़ जोड़ रहा है
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // विशिष्ट अनुक्रमांक पर प्रॉपर्टी का नाम प्राप्त कर रहा है
    var getPropertyName = dProps.getCustomPropertyName(2);
    // चयनित प्रॉपर्टी को हटा रहा है
    dProps.removeCustomProperty(getPropertyName);
    // प्रेजेंटेशन सहेज रहा है
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**कस्टम दस्तावेज़ प्रॉपर्टीज़ जोड़ी गई**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **कस्टम प्रॉपर्टीज़ तक पहुंचें और संशोधित करें**

Aspose.Slides for Node.js via Java डेवलपर्स को कस्टम प्रॉपर्टीज़ के मानों तक पहुंचने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप प्रस्तुति के सभी कस्टम प्रॉपर्टीज़ तक कैसे पहुंच सकते हैं और उन्हें संशोधित कर सकते हैं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े DocumentProperties ऑब्जेक्ट का रेफ़रेंस बनायें
    var dp = pres.getDocumentProperties();
    // कस्टम प्रॉपर्टीज़ तक पहुँचें और संशोधित करें
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // कस्टम प्रॉपर्टीज़ के नाम और मान प्रदर्शित करें
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // कस्टम प्रॉपर्टीज़ के मान संशोधित करें
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // अपनी प्रस्तुति को फ़ाइल में सहेजें
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

यह उदाहरण [PPTX ](https://docs.fileformat.com/presentation/pptx/) प्रस्तुति की कस्टम प्रॉपर्टीज़ को संशोधित करता है। निम्नलिखित चित्र संशोधन से पहले और बाद में प्रस्तुति की कस्टम प्रॉपर्टीज़ को दर्शाते हैं:

|**संशोधन से पहले कस्टम प्रॉपर्टीज़**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**संशोधन के बाद कस्टम प्रॉपर्टीज़**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **उन्नत दस्तावेज़ प्रॉपर्टीज़**

{{% alert color="info" title="Note" %}}
नया मेथड्स [ReadDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), और [WriteBindedPresentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) को [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo) में जोड़ा गया है, और [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) प्रॉपर्टी सेट्टर के लॉजिक को बदल दिया गया है।
{{% /alert %}} 

दो नए मेथड्स [ReadDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) और [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) को [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo) क्लास में जोड़ा गया है। ये दस्तावेज़ प्रॉपर्टीज़ तक त्वरित पहुंच प्रदान करते हैं और पूरी प्रस्तुति को लोड किए बिना प्रॉपर्टीज़ को बदलने और अपडेट करने की अनुमति देते हैं।

सामान्य परिदृश्य जिसमें प्रॉपर्टीज़ लोड होते हैं, कुछ मान बदलते हैं और दस्तावेज़ को अपडेट करते हैं, इसे निम्नलिखित तरीके से लागू किया जा सकता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// प्रस्तुति की जानकारी पढ़ें
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtain the current properties
var props = info.readDocumentProperties();
// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");
// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

एक अन्य तरीका यह है कि किसी विशेष प्रस्तुति की प्रॉपर्टीज़ को टेम्प्लेट के रूप में उपयोग करके अन्य प्रस्तुतियों की प्रॉपर्टीज़ अपडेट की जाएँ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

एक नया टेम्प्लेट शून्य से बनाया जा सकता है और फिर कई प्रस्तुतियों को अपडेट करने के लिए उपयोग किया जा सकता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides LanguageId प्रॉपर्टी (जो PortionFormat क्लास द्वारा उजागर होती है) प्रदान करता है जिससे आप PowerPoint दस्तावेज़ की प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण जाँच की जाती है।

यह JavaScript कोड दिखाता है कि PowerPoint के लिए प्रूफ़िंग भाषा कैसे सेट की जाए: xxx JavaScript PortionFormat क्लास में LanguageId क्यों नहीं है?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// प्रूफ़िंग भाषा का Id सेट करें
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

यह JavaScript कोड दिखाता है कि पूरे PowerPoint प्रस्तुति के लिए डिफ़ॉल्ट भाषा कैसे सेट की जाए:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // पाठ के साथ एक नया आयताकार आकार जोड़ता है
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // पहले भाग की भाषा जाँचता है
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **लाइव उदाहरण**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/hi/metadata) ऑनलाइन ऐप को आज़माएँ ताकि आप Aspose.Slides API के माध्यम से दस्तावेज़ प्रॉपर्टीज़ के साथ कैसे काम किया जाता है, देख सकें:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से एक built-in प्रॉपर्टी कैसे हटाऊँ?**

Built-in प्रॉपर्टीज़ प्रस्तुति का अभिन्न हिस्सा हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशेष प्रॉपर्टी की अनुमति है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं किसी मौजूदा कस्टम प्रॉपर्टी को जोड़ूँ तो क्या होता है?**

यदि आप कोई ऐसा कस्टम प्रॉपर्टी जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से बदल दिया जाएगा। आपको पहले प्रॉपर्टी को हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से प्रॉपर्टी के मान को अपडेट कर देता है।

**क्या मैं पूरी प्रस्तुति को लोड किए बिना प्रेजेंटेशन प्रॉपर्टीज़ तक पहुंच सकता हूँ?**

हाँ। [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करें और फिर [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) का उपयोग करके बिना [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस बनाए संग्रहित दस्तावेज़ मेटाडेटा पढ़ें। पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट-विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/nodejs-java/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति की सार्वजनिक प्रॉपर्टीज़ को उसके खोलने वाले पासवर्ड के बिना पढ़ सकता हूँ?**

हाँ। दस्तावेज़-प्रॉपर्टी एन्क्रिप्शन को प्रस्तुति के एन्क्रिप्ट होने से पहले अक्षम किया जाना चाहिए, और प्रस्तुति को document-properties-only मोड में लोड किया जाना चाहिए।

**क्या मैं document-properties-only मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नहीं। सार्वजनिक और एन्क्रिप्टेड प्रॉपर्टी डेटा को सुसंगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही खोलने वाले पासवर्ड के साथ पूरी प्रस्तुति को लोड करना आवश्यक है।