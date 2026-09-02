---
title: जावास्क्रिप्ट में प्रस्तुति गुण प्रबंधित करें
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/nodejs-java/presentation-properties/
keywords:
- PowerPoint गुण
- प्रेज़ेंटेशन गुण
- दस्तावेज़ गुण
- निर्मित गुण
- कस्टम गुण
- उन्नत गुण
- गुण प्रबंधित करें
- गुण संशोधित करें
- दस्तावेज़ मेटा डेटा
- मेटा डेटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java में प्रस्तुति गुणों को महारत हासिल करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सरल बनाएँ।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ गुणों का समर्थन करता है: **Built-in** और **Custom**. इन दोनों गुण प्रकारों को Aspose.Slides API का उपयोग करके आसानी से एक्सेस किया जा सकता है और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने देता है [DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/) वर्ग के माध्यम से। इस वर्ग की एक इंस्टैंस [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDocumentProperties) विधि द्वारा वापस मिलती है। नीचे दिए गए उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ें, संशोधित करें और प्रबंधित करें।

{{% alert color="info" title="Note" %}}
कृपया ध्यान दें कि **Application** और **AppVersion** फ़ील्ड को संशोधित नहीं किया जा सकता। Aspose.Slides प्रत्येक सहेजने पर इन्हें फिर से लिखता है, इसलिए सहेजी गई प्रस्तुति हमेशा “Aspose.Slides for Node.js via Java” और उस लाइब्रेरी का संस्करण दर्शाती है जिसने इसे बनाया। `setNameOfApplication` में दिया गया कोई भी मान प्रस्तुति लिखी जाने पर त्याग दिया जाता है।
{{% /alert %}} 

## **प्रेज़ेंटेशन गुण प्रबंधित करें**

Microsoft PowerPoint प्रस्तुति फ़ाइलों में कुछ गुण जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ गुण उपयोगी जानकारी को दस्तावेज़ों (प्रेज़ेंटेशन फ़ाइलों) के साथ संग्रहीत करने की अनुमति देते हैं। दो प्रकार के दस्तावेज़ गुण होते हैं:

- सिस्टम द्वारा परिभाषित (Built-in) गुण
- उपयोगकर्ता-परिभाषित (Custom) गुण

**Built-in** गुण दस्तावेज़ के बारे में सामान्य जानकारी रखते हैं जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ आँकड़े आदि। **Custom** गुण वे होते हैं जिन्हें उपयोगकर्ता **Name/Value** जोड़ी के रूप में परिभाषित करता है, जहाँ नाम और मान दोनों उपयोगकर्ता द्वारा निर्धारित होते हैं। Aspose.Slides for Node.js via Java का उपयोग करके, डेवलपर बिल्ट‑इन गुणों तथा कस्टम गुणों दोनों के मानों तक पहुंच और उनका संशोधन कर सकते हैं।

## **PowerPoint में दस्तावेज़ गुण**

Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों को प्रबंधित करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करना है और आगे **Prepare | Properties | Advanced Properties** मेनू आइटम चुनना है जैसा कि नीचे दिखाया गया है:

|**एडवांस्ड प्रॉपर्टीज़ मेनू आइटम चयन**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** मेनू आइटम चुनने के बाद, एक डायलॉग प्रदर्शित होगा जो PowerPoint फ़ाइल के दस्तावेज़ गुणों को प्रबंधित करने की अनुमति देता है:

|**प्रॉपर्टीज़ डायलॉग**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

ऊपर के **प्रॉपर्टीज़ डायलॉग** में आप देख सकते हैं कि कई टैब पेज हैं जैसे **General**, **Summary**, **Statistics**, **Contents** और **Custom**। ये सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब का उपयोग PowerPoint फ़ाइलों के कस्टम गुणों को प्रबंधित करने के लिए किया जाता है।

Aspose.Slides for Node.js via Java का उपयोग करके दस्तावेज़ गुणों के साथ काम करना

जैसा कि हमने पहले बताया था, Aspose.Slides for Node.js via Java दो प्रकार के दस्तावेज़ गुणों का समर्थन करता है, जो **Built-in** और **Custom** हैं। इसलिए डेवलपर Aspose.Slides for Node.js via Java API का उपयोग करके दोनों प्रकार के गुणों तक पहुंच सकते हैं। Aspose.Slides for Node.js via Java एक वर्ग [DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties) प्रदान करता है जो **Presentation.DocumentProperties** गुण के माध्यम से प्रस्तुति फ़ाइल से जुड़े दस्तावेज़ गुणों को दर्शाता है।

डेवलपर नीचे वर्णित अनुसार [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) ऑब्जेक्ट द्वारा प्रदान किए गए **DocumentProperties** गुण का उपयोग करके प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों तक पहुंच सकते हैं:

## **बिल्ट‑इन गुणों का एक्सेस**

[DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties) ऑब्जेक्ट द्वारा प्रदान किए गए ये गुण शामिल हैं: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** और **Title**।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// प्रस्तुति को दर्शाने वाली Presentation क्लास का इंस्टेंशिएट करें
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation से जुड़ी IDocumentProperties ऑब्जेक्ट का रेफ़रेंस बनाएं
    var dp = pres.getDocumentProperties();
    // बिल्ट‑इन गुण प्रदर्शित करें
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

## **बिल्ट‑इन गुणों को संशोधित करें**

प्रेज़ेंटेशन फ़ाइलों के बिल्ट‑इन गुणों को संशोधित करना उतना ही आसान है जितना उन्हें एक्सेस करना। आप केवल किसी भी इच्छित गुण को स्ट्रिंग मान असाइन कर सकते हैं और वह गुण मान बदल जाएगा। नीचे दिए गए उदाहरण में हमने दिखाया है कि कैसे Aspose.Slides for Node.js via Java का उपयोग करके प्रस्तुति फ़ाइल के बिल्ट‑इन दस्तावेज़ गुणों को संशोधित किया जा सकता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का रेफ़रेंस बनाएं
    var dp = pres.getDocumentProperties();
    // बिल्ट‑इन गुण सेट करें
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // अपनी प्रस्तुति को फ़ाइल में सहेजें
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

यह उदाहरण प्रस्तुति के बिल्ट‑इन गुणों को संशोधित करता है जिसे नीचे दिखाए अनुसार देखा जा सकता है:

|**संशोधन के बाद बिल्ट‑इन दस्तावेज़ गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **कस्टम दस्तावेज़ गुण जोड़ें**

Aspose.Slides for Node.js via Java डेवलपर्स को प्रस्तुति दस्तावेज़ गुणों के लिए कस्टम मान जोड़ने की भी अनुमति देता है। नीचे दिया गया उदाहरण दर्शाता है कि कैसे एक प्रस्तुति के लिए कस्टम गुण सेट किए जा सकते हैं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // दस्तावेज़ गुण प्राप्त कर रहे हैं
    var dProps = pres.getDocumentProperties();
    // कस्टम गुण जोड़ रहे हैं
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // विशिष्ट सूचकांक पर गुण का नाम प्राप्त कर रहे हैं
    var getPropertyName = dProps.getCustomPropertyName(2);
    // चुने गए गुण को हटा रहे हैं
    dProps.removeCustomProperty(getPropertyName);
    // प्रस्तुति सहेज रहे हैं
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**जोड़े गए कस्टम दस्तावेज़ गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **कस्टम गुणों तक पहुंचें और संशोधित करें**

Aspose.Slides for Node.js via Java डेवलपर्स को कस्टम गुणों के मानों तक पहुंचने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप एक प्रस्तुति के सभी कस्टम गुणों तक कैसे पहुंच सकते हैं और उन्हें कैसे संशोधित कर सकते हैं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation से जुड़ी DocumentProperties ऑब्जेक्ट का रेफ़रेंस बनाएं
    var dp = pres.getDocumentProperties();
    // कस्टम गुणों तक पहुंचें और उन्हें संशोधित करें
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // कस्टम गुणों के नाम और मान प्रदर्शित करें
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // कस्टम गुणों के मान संशोधित करें
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

यह उदाहरण [PPTX ](https://docs.fileformat.com/presentation/pptx/)प्रेज़ेंटेशन के कस्टम गुणों को संशोधित करता है। नीचे के चित्रों में संशोधन से पहले और बाद की कस्टम गुण दिखाई गई हैं:

|**संशोधन से पहले कस्टम गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**संशोधन के बाद कस्टम गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **उन्नत दस्तावेज़ गुण**

{{% alert color="info" title="Note" %}}
नए मेथड्स [ReadDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), और [WriteBindedPresentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) को [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo) में जोड़ा गया है, और [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) प्रॉपर्टी सेट्टर की लॉजिक बदल दी गई है।
{{% /alert %}} 

दो नए मेथड्स [ReadDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) और [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) को [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo) क्लास में जोड़ा गया है। ये मेथड्स दस्तावेज़ गुणों तक तेज़ी से पहुंच प्रदान करते हैं और पूरी प्रस्तुति लोड किए बिना गुणों को बदलने और अपडेट करने की अनुमति देते हैं।

सामान्य परिदृश्य में गुण लोड करें, कुछ मूल्य बदलें और दस्तावेज़ को अपडेट करें, इसे नीचे दिखाए अनुसार लागू किया जा सकता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// प्रस्तुति की जानकारी पढ़ें
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
var props = info.readDocumentProperties();
props.setAuthor("New Author");
props.setTitle("New Title");
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

एक प्रस्तुति के गुणों को टेम्पलेट के रूप में उपयोग करके अन्य प्रस्तुतियों में गुणों को अपडेट करने का एक और तरीका है:

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

एक नया टेम्पलेट शून्य से बनाया जा सकता है और फिर कई प्रस्तुतियों को अपडेट करने के लिए उपयोग किया जा सकता है:

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

Aspose.Slides PortionFormat वर्ग द्वारा प्रदान किए गए LanguageId प्रॉपर्टी के माध्यम से आपको PowerPoint दस्तावेज़ के लिए प्रूफ़िंग भाषा सेट करने की अनुमति देता है। प्रूफ़िंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण की जाँच की जाती है।

यह JavaScript कोड दिखाता है कि PowerPoint के लिए प्रूफ़िंग भाषा कैसे सेट करें: xxx Why is LanguageId missing from JavaScript PortionFormat class?

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

यह JavaScript कोड दिखाता है कि पूरे PowerPoint प्रेज़ेंटेशन के लिए डिफ़ॉल्ट भाषा कैसे सेट करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // टेक्स्ट के साथ नया आयताकार आकार जोड़ता है
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // पहले पोर्शन की भाषा जाँचता है
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **लाइव उदाहरण**

Aspose.Slides API के माध्यम से दस्तावेज़ गुणों के साथ कैसे काम किया जाता है, यह देखने के लिए ऑनलाइन ऐप **[Aspose.Slides Metadata](https://products.aspose.app/slides/hi/metadata)** आज़माएँ:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रेज़ेंटेशन से बिल्ट‑इन गुण को कैसे हटाया जा सकता है?**

बिल्ट‑इन गुण प्रेज़ेंटेशन का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उन्हें बदल सकते हैं या यदि विशिष्ट गुण अनुमति देता है तो खाली सेट कर सकते हैं।

**यदि मैं पहले से मौजूद कस्टम गुण जोड़ूँ तो क्या होता है?**

यदि आप पहले से मौजूद कस्टम गुण जोड़ते हैं, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले से हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट कर देता है।

**क्या मैं प्रेज़ेंटेशन को पूरी तरह लोड किए बिना गुणों तक पहुंच सकता हूँ?**

हाँ। आप [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करके फिर [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) के द्वारा दस्तावेज़ मेटा‑डेटा को पढ़ सकते हैं बिना [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टैंस बनाए। पूरी रिपोर्टिंग उदाहरण और फॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/nodejs-java/examine-presentation/).