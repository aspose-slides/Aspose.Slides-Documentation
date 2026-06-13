---
title: जावास्क्रिप्ट में प्रस्तुति गुणधर्म प्रबंधित करें
linktitle: प्रस्तुति गुणधर्म
type: docs
weight: 70
url: /hi/nodejs-java/presentation-properties/
keywords:
- PowerPoint गुणधर्म
- प्रस्तुति गुणधर्म
- दस्तावेज़ गुणधर्म
- बिल्ट‑इन गुणधर्म
- कस्टम गुणधर्म
- उन्नत गुणधर्म
- गुणधर्म प्रबंधन
- गुणधर्म संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java में प्रस्तुति गुणधर्मों को पूरी तरह समझें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और वर्कफ़्लो को सहज बनाएं।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ गुणधर्मों का समर्थन करता है: **बिल्ट‑इन** और **कस्टम**। इन दोनों प्रकार के गुणधर्मों को Aspose.Slides API का उपयोग करके आसानी से एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुतीकरण दस्तावेज़ गुणधर्मों के साथ काम करने की सुविधा देता है [DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/) वर्ग के माध्यम से। इस वर्ग की एक इंस्टेंस [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getDocumentProperties) मेथड द्वारा लौटाई जाती है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणधर्मों को पढ़ना, संशोधित करना और प्रबंधित करना कैसे है।

{{% alert color="primary" %}} 

कृपया ध्यान दें कि आप **Application** और **Producer** फ़ील्ड में मान सेट नहीं कर सकते, क्योंकि इन फ़ील्ड्स में Aspose Ltd. और Aspose.Slides for Node.js via Java x.x.x प्रदर्शित होगा।

{{% /alert %}} 

## **प्रस्तुति गुणधर्मों का प्रबंधन**

Microsoft PowerPoint प्रस्तुति फ़ाइलों में कुछ गुणधर्म जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ गुणधर्म दस्तावेज़ (प्रस्तुति फ़ाइलों) के साथ उपयोगी जानकारी संग्रहीत करने की अनुमति देते हैं। दो प्रकार के दस्तावेज़ गुणधर्म होते हैं:

- सिस्टम परिभाषित (बिल्ट‑इन) गुणधर्म
- उपयोगकर्ता‑परिभाषित (कस्टम) गुणधर्म

**बिल्ट‑इन** गुणधर्म दस्तावेज़ के बारे में सामान्य जानकारी रखते हैं जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ आँकड़े आदि। **कस्टम** गुणधर्म वह होते हैं जो उपयोगकर्ताओं द्वारा **नाम/मान** जोड़े के रूप में परिभाषित किए जाते हैं, जहाँ दोनों नाम और मान उपयोगकर्ता द्वारा तय किए जाते हैं। Aspose.Slides for Node.js via Java का उपयोग करके डेवलपर बिल्ट‑इन तथा कस्टम दोनों गुणधर्मों के मान को एक्सेस और संशोधित कर सकते हैं।

## **PowerPoint में दस्तावेज़ गुणधर्म**

Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों के दस्तावेज़ गुणधर्मों का प्रबंधन करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करना है और फिर **Prepare | Properties | Advanced Properties** मेनू आइटम चुनना है, जैसा कि नीचे दिखाया गया है:

|**Advanced Properties मेनू आइटम चुनना**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**Advanced Properties** मेनू आइटम चुनने के बाद, एक डायलॉग बॉक्स प्रदर्शित होगा जिससे आप PowerPoint फ़ाइल के दस्तावेज़ गुणधर्मों को प्रबंधित कर सकते हैं, जैसा कि नीचे चित्र में दर्शाया गया है:

|**Properties डायलॉग**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
ऊपर के **Properties डायलॉग** में, आप देख सकते हैं कि कई टैब पेज हैं जैसे **General**, **Summary**, **Statistics**, **Contents** और **Custom**। सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब PowerPoint फ़ाइलों के कस्टम गुणधर्मों का प्रबंधन करता है।

## **Aspose.Slides for Node.js via Java के साथ दस्तावेज़ गुणधर्मों का उपयोग**

जैसा कि हमने पहले बताया था, Aspose.Slides for Node.js via Java दो प्रकार के दस्तावेज़ गुणधर्मों का समर्थन करता है, अर्थात् **बिल्ट‑इन** और **कस्टम** गुणधर्म। इसलिए डेवलपर Aspose.Slides for Node.js via Java API का उपयोग करके दोनों प्रकार के गुणधर्मों को एक्सेस कर सकते हैं। Aspose.Slides for Node.js via Java एक वर्ग [DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties) प्रदान करता है जो **Presentation.DocumentProperties** प्रॉपर्टी के माध्यम से प्रस्तुति फ़ाइल से जुड़े दस्तावेज़ गुणधर्मों को दर्शाता है।

डेवलपर नीचे दर्शाए अनुसार प्रस्तुति फ़ाइलों के दस्तावेज़ गुणधर्मों को एक्सेस करने के लिए [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) ऑब्जेक्ट द्वारा उजागर **DocumentProperties** प्रॉपर्टी का उपयोग कर सकते हैं:

## **बिल्ट‑इन गुणधर्मों तक पहुंच**

[DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties) ऑब्जेक्ट द्वारा उजागर निम्नलिखित गुणधर्म शामिल हैं: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (क्या विभिन्न निर्माताओं के बीच साझा है?), **PresentationFormat**, **Subject**, **Title** आदि।

```javascript
// प्रस्तुति का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation से जुड़ी IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    var dp = pres.getDocumentProperties();
    // बिल्ट‑इन गुणधर्म प्रदर्शित करें
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

## **बिल्ट‑इन गुणधर्मों का संशोधन**

प्रस्तुति फ़ाइलों के बिल्ट‑इन गुणधर्मों को संशोधित करना उन्हें एक्सेस करने जितना ही आसान है। आप केवल किसी इच्छित गुणधर्म को स्ट्रिंग मान असाइन कर सकते हैं और गुणधर्म का मान अपडेट हो जाएगा। नीचे दिखाए गए उदाहरण में हमने Aspose.Slides for Node.js via Java का उपयोग करके प्रस्तुति फ़ाइल के बिल्ट‑इन दस्तावेज़ गुणधर्मों को कैसे संशोधित किया, यह दर्शाया है।

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    var dp = pres.getDocumentProperties();
    // बिल्ट‑इन गुणधर्म सेट करें
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

यह उदाहरण प्रस्तुति के बिल्ट‑इन गुणधर्मों को संशोधित करता है जिसे नीचे दिखाए अनुसार देखा जा सकता है:

|**संशोधन के बाद बिल्ट‑इन दस्तावेज़ गुणधर्म**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **कस्टम दस्तावेज़ गुणधर्म जोड़ें**

Aspose.Slides for Node.js via Java डेवलपरों को प्रस्तुति दस्तावेज़ गुणधर्मों के लिए कस्टम मान जोड़ने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि प्रस्तुति के लिए कस्टम गुणधर्म कैसे सेट करें।

```javascript
var pres = new aspose.slides.Presentation();
try {
    // दस्तावेज़ गुणधर्म प्राप्त करना
    var dProps = pres.getDocumentProperties();
    // कस्टम गुणधर्म जोड़ना
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // विशेष सूचकांक पर गुणधर्म का नाम प्राप्त करना
    var getPropertyName = dProps.getCustomPropertyName(2);
    // चुने गए गुणधर्म को हटाना
    dProps.removeCustomProperty(getPropertyName);
    // प्रस्तुति सहेजना
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**जोड़े गए कस्टम दस्तावेज़ गुणधर्म**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **कस्टम गुणधर्मों तक पहुंच और संशोधन**

Aspose.Slides for Node.js via Java डेवलपरों को कस्टम गुणधर्मों के मानों तक पहुंचने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप प्रस्तुति के सभी कस्टम गुणधर्मों को कैसे एक्सेस और संशोधित कर सकते हैं।

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Presentation से जुड़ी DocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    var dp = pres.getDocumentProperties();
    // कस्टम गुणधर्मों तक पहुँचें और संशोधित करें
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // कस्टम गुणधर्मों के नाम और मान प्रदर्शित करें
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // कस्टम गुणधर्मों के मान संशोधित करें
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

यह उदाहरण [PPTX](https://docs.fileformat.com/presentation/pptx/) प्रस्तुति के कस्टम गुणधर्मों को संशोधित करता है। नीचे के चित्रों में संशोधन से पहले और बाद के कस्टम गुणधर्म दिखाए गए हैं:

|**संशोधन से पहले कस्टम गुणधर्म**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**संशोधन के बाद कस्टम गुणधर्म**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **उन्नत दस्तावेज़ गुणधर्म**

{{% alert color="primary" %}} 

नई मेथड्स [ReadDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), और [WriteBindedPresentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) को [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo) में जोड़ा गया है, तथा [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) प्रॉपर्टी सेट्टर की लॉजिक बदल दी गई है।

{{% /alert %}} 

दो नई मेथड्स [ReadDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) और [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) को [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PresentationInfo) क्लास में जोड़ा गया है। वे दस्तावेज़ गुणधर्मों तक त्वरित पहुंच प्रदान करती हैं और पूरी प्रस्तुति लोड किए बिना गुणधर्मों को बदलने व अद्यतन करने की अनुमति देती हैं।

सामान्य परिदृश्य में गुणधर्म लोड करके, कुछ मान बदलकर और दस्तावेज़ को अद्यतन करने का कार्य नीचे दिखाए अनुसार किया जा सकता है:

```javascript
// प्रस्तुति की जानकारी पढ़ें
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// वर्तमान गुणधर्म प्राप्त करें
var props = info.readDocumentProperties();
// लेखक और शीर्षक फ़ील्ड के नए मान सेट करें
props.setAuthor("New Author");
props.setTitle("New Title");
// प्रस्तुति को नए मानों के साथ अद्यतन करें
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

एक विशिष्ट प्रस्तुति के गुणधर्मों को टेम्पलेट के रूप में उपयोग करके अन्य प्रस्तुतियों में गुणधर्म अद्यतन करने का एक और तरीका है:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

शुरू से एक नया टेम्पलेट बनाया जा सकता है और फिर कई प्रस्तुतियों को अद्यतन करने के लिए उपयोग किया जा सकता है:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **प्रूफ़िंग भाषा निर्धारित करें**

Aspose.Slides PortionFormat क्लास द्वारा उजागर LanguageId प्रॉपर्टी प्रदान करता है जिससे आप PowerPoint दस्तावेज़ की प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा वह भाषा है जिसके विरुद्ध PowerPoint में वर्तनी और व्याकरण जांची जाती है।

निम्न JavaScript कोड दिखाता है कि PowerPoint की प्रूफ़िंग भाषा कैसे सेट करें: xxx क्यों LanguageId JavaScript PortionFormat क्लास में अनुपलब्ध है?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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

## **डिफ़ॉल्ट भाषा निर्धारित करें**

निम्न JavaScript कोड दिखाता है कि पूरी PowerPoint प्रस्तुति की डिफ़ॉल्ट भाषा कैसे सेट करें:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // पाठ के साथ नया आयताकार आकार जोड़ता है
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // पहले भाग की भाषा की जाँच करता है
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **लाइव उदाहरण**

Aspose.Slides Metadata ऑनलाइन ऐप आज़माएँ और Aspose.Slides API के माध्यम से दस्तावेज़ गुणधर्मों के साथ काम करने का तरीका देखें:

[![देखें और संपादित करें PowerPoint मेटाडेटा](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## ***FAQ**

**मैं प्रस्तुति से बिल्ट‑इन गुणधर्म कैसे हटाऊँ?**

बिल्ट‑इन गुणधर्म प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उन्हें बदल सकते हैं या यदि विशेष गुणधर्म अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं मौजूदा कस्टम गुणधर्म जोड़ूँ तो क्या होगा?**

यदि आप ऐसा कस्टम गुणधर्म जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नया मान से अधिलेखित हो जाएगा। आपको पहले से हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुणधर्म के मान को अपडेट कर देता है।

**क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणधर्मों तक पहुंच सकता हूँ?**

हाँ, आप [PresentationFactory](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/) क्लास की `getPresentationInfo` मेथड का उपयोग करके पूरी प्रस्तुति लोड किए बिना गुणधर्मों तक पहुंच सकते हैं। फिर, [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/) क्लास की `readDocumentProperties` मेथड का उपयोग करके गुणधर्मों को प्रभावी रूप से पढ़ें, जिससे मेमोरी बचती है और प्रदर्शन में सुधार होता है।