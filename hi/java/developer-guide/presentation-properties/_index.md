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
- गुणों का संशोधन
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफिंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में प्रस्तुति गुणों को प्रबंधित करें और अपने PowerPoint तथा OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सहज बनाएं।"
---
## **परिचय**

Aspose.Slides दो प्रकार के दस्तावेज़ गुणों को समर्थन देता है: **Built-in** और **Custom**। इन दोनों प्रकार के गुणों को Aspose.Slides API का उपयोग करके आसानी से एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है, जिसे आप [IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से कर सकते हैं। इस इंटरफ़ेस की एक इंस्टेंस [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getDocumentProperties--) मेथड द्वारा वापस की जाती है। नीचे दिए गए उदाहरण दर्शाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="primary" %}} 
कृपया ध्यान दें कि **Application** और **Producer** फ़ील्ड को संशोधित नहीं किया जा सकता, क्योंकि ये फ़ील्ड हमेशा "Aspose Ltd." और "Aspose.Slides for Java x.x.x" दिखाएंगे।
{{% /alert %}} 

## **PowerPoint में दस्तावेज़ गुण**

Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों को प्रबंधित करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करना है और आगे **Prepare | Properties | Advanced Properties** मेनू आइटम को चुनना है, जैसा कि नीचे दिखाया गया है:

|**Advanced Properties मेनू आइटम का चयन**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

जब आप **Advanced Properties** मेनू आइटम चुनते हैं, तो एक डायलॉग बॉक्स प्रदर्शित होगा जिससे आप PowerPoint फ़ाइल के दस्तावेज़ गुणों को प्रबंधित कर सकते हैं, जैसा कि नीचे चित्र में दिखाया गया है:

|**Properties डायलॉग**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

ऊपर दिखाए गए **Properties Dialog** में आप देख सकते हैं कि कई टैब पेज हैं जैसे **General**, **Summary**, **Statistics**, **Contents** और **Custom**। ये सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब का उपयोग PowerPoint फ़ाइलों के कस्टम गुणों को प्रबंधित करने के लिए किया जाता है।

## **Aspose.Slides for Java का उपयोग करके दस्तावेज़ गुणों के साथ काम करना**

जैसा कि हमने पहले बताया था, Aspose.Slides for Java दो प्रकार के दस्तावेज़ गुणों को समर्थन देता है, जो **Built-in** और **Custom** गुण हैं। इसलिए, डेवलपर्स Aspose.Slides for Java API का उपयोग करके दोनों प्रकार के गुणों तक पहुँच सकते हैं। Aspose.Slides for Java एक क्लास [IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties) प्रदान करता है जो **Presentation.DocumentProperties** गुण के माध्यम से प्रस्तुति फ़ाइल से जुड़े दस्तावेज़ गुणों का प्रतिनिधित्व करता है।

डेवलपर्स **IDocumentProperties** गुण का उपयोग कर सकते हैं, जो [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) ऑब्जेक्ट द्वारा एक्सपोज़ किया गया है, ताकि नीचे वर्णित अनुसार प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों तक पहुँच सकें।

## **Built-in गुणों तक पहुँच**

इन गुणों को [IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties) ऑब्जेक्ट द्वारा एक्सपोज़ किया गया है जिसमें शामिल हैं: **Creator** (लेखक), **Description**, **Keywords**, **Created** (निर्माण तिथि), **Modified** (परिवर्तित तिथि), **Printed** (अंतिम प्रिंट तिथि), **LastModifiedBy**, **Keywords**, **SharedDoc** (क्या विभिन्न निर्माताओं के बीच साझा किया गया है?), **PresentationFormat**, **Subject**, और **Title**.

```java
// प्रस्तुति का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टांस बनाएँ
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का रेफ़रेंस बनाएँ
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // बिल्ट-इन गुणों को प्रदर्शित करें
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

## **Built-in गुणों में संशोधन**

प्रस्तुति फ़ाइलों के बिल्ट-इन गुणों में संशोधन करना उतना ही आसान है जितना उन्हें एक्सेस करना। आप बस किसी भी वांछित गुण को स्ट्रिंग मान असाइन कर सकते हैं और वह गुण मान संशोधित हो जाएगा। नीचे दिए गए उदाहरण में, हमने दिखाया है कि Aspose.Slides for Java का उपयोग करके प्रस्तुति फ़ाइल के बिल्ट-इन दस्तावेज़ गुणों को कैसे संशोधित किया जा सकता है।

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का रेफ़रेंस बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // बिल्ट-इन गुण सेट करें
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

यह उदाहरण प्रस्तुति के बिल्ट-इन गुणों को संशोधित करता है, जिसे नीचे दिखाए अनुसार देखा जा सकता है:

|**संशोधन के बाद बिल्ट-इन दस्तावेज़ गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **कस्टम दस्तावेज़ गुण जोड़ें**

Aspose.Slides for Java डेवलपर्स को प्रस्तुति दस्तावेज़ गुणों के लिए कस्टम मान जोड़ने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि प्रस्तुति के लिए कस्टम गुण कैसे सेट करें।

```java
Presentation pres = new Presentation();
try {
    // दस्तावेज़ गुण प्राप्त करना
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // कस्टम गुण जोड़ना
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // विशेष इंडेक्स पर गुण नाम प्राप्त करना
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // चयनित गुण को हटाना
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

## **कस्टम गुणों तक पहुँच और संशोधन**

Aspose.Slides for Java डेवलपर्स को कस्टम गुणों के मानों तक पहुँचने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप किसी प्रस्तुति के सभी कस्टम गुणों तक कैसे पहुँच सकते हैं और उन्हें संशोधित कर सकते हैं।

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े DocumentProperties ऑब्जेक्ट का रेफ़रेंस बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // कस्टम गुणों तक पहुँचें और संशोधित करें
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

यह उदाहरण [PPTX ](https://docs.fileformat.com/presentation/pptx/) प्रस्तुति के कस्टम गुणों को संशोधित करता है। निम्नलिखित चित्र संशोधन से पहले और बाद में प्रस्तुति के कस्टम गुणों को दिखाते हैं:

|**संशोधन से पहले कस्टम गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**संशोधन के बाद कस्टम गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **उन्नत दस्तावेज़ गुण**

{{% alert color="primary" %}} 
नए मेथड [ReadDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), और [WriteBindedPresentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) को [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo) में जोड़ दिया गया है, और [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) प्रॉपर्टी सेट्टर की लॉजिक बदल दी गई है।
{{% /alert %}} 

दो नए मेथड [ReadDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) और [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) को [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo) इंटरफ़ेस में जोड़ा गया है। ये दस्तावेज़ गुणों तक तेज़ पहुँच प्रदान करते हैं और पूरी प्रस्तुति लोड किए बिना गुणों को बदलने और अपडेट करने की अनुमति देते हैं।

सामान्य परिदृश्य जिसमें गुण लोड किए जाते हैं, कुछ मान बदलते हैं और दस्तावेज़ को अपडेट किया जाता है, इसे नीचे दिखाए अनुसार लागू किया जा सकता है:

```java
// प्रस्तुति की जानकारी पढ़ें
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// वर्तमान गुण प्राप्त करें
IDocumentProperties props = info.readDocumentProperties();

// Author और Title फ़ील्ड के नए मान सेट करें
props.setAuthor("New Author");
props.setTitle("New Title");

// नई मानों के साथ प्रस्तुति को अपडेट करें
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

किसी विशेष प्रस्तुति के गुणों को टेम्पलेट के रूप में उपयोग करके अन्य प्रस्तुतियों के गुणों को अपडेट करने का एक और तरीका है:

```java
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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

एक नया टेम्पलेट शून्य से बनाया जा सकता है और फिर कई प्रस्तुतियों को अपडेट करने के लिए उपयोग किया जा सकता है:

```java
DocumentProperties template = new DocumentProperties();\

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides LanguageId प्रॉपर्टी (जो PortionFormat क्लास द्वारा एक्सपोज़ की गई है) प्रदान करता है ताकि आप PowerPoint दस्तावेज़ की प्रूफिंग भाषा सेट कर सकें। प्रूफिंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण जाँचें जाती हैं।

यह Java कोड दिखाता है कि PowerPoint के लिए प्रूफिंग भाषा कैसे सेट करें: xxx क्यों Java PortionFormat क्लास में LanguageId गायब है?

```java
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

    portionFormat.setLanguageId("zh-CN"); // प्रूफिंग भाषा का Id सेट करें

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

यह Java कोड दिखाता है कि पूरी PowerPoint प्रस्तुति के लिए डिफ़ॉल्ट भाषा कैसे सेट करें:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // एक नया आयताकार आकार टेक्स्ट के साथ जोड़ता है
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // पहले भाग की भाषा की जाँच करता है
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **लाइव उदाहरण**

ऑनलाइन ऐप [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hi/metadata) आज़माएँ ताकि आप Aspose.Slides API के माध्यम से दस्तावेज़ गुणों के साथ काम करना देख सकें:

[![PowerPoint मेटाडेटा देखें और संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## ***अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से बिल्ट-इन गुण को कैसे हटाऊँ?**

बिल्ट-इन गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशिष्ट गुण अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं कोई कस्टम गुण जोड़ूँ जो पहले से मौजूद है तो क्या होता है?**

यदि आप ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नई वैल्यू से अधिलेखित हो जाएगा। आपको पहले से हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वतः ही गुण के मान को अपडेट कर देता है।

**क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुँच सकता हूँ?**

हाँ, आप [PresentationFactory](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/) क्लास की `getPresentationInfo` मेथड का उपयोग करके पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुँच सकते हैं। फिर, आप [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/) इंटरफ़ेस द्वारा प्रदान की गई `readDocumentProperties` मेथड का उपयोग करके गुणों को प्रभावी ढंग से पढ़ सकते हैं, जिससे मेमोरी बचती है और प्रदर्शन में सुधार होता है।