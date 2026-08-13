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
- गुणों में संशोधन
- दस्तावेज़ मेटा डेटा
- मेटा डेटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में प्रस्तुति गुणों को महारत हासिल करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को आसान बनाएं।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ गुणों का समर्थन करता है: **Built-in** और **Custom**। इन दोनों गुण प्रकारों को Aspose.Slides API का उपयोग करके आसानी से पहुंचा और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस का एक उदाहरण [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getDocumentProperties--) मेथड द्वारा लौटाया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ें, संशोधित करें और प्रबंधित करें।

{{% alert color="info" %}} 

कृपया ध्यान दें कि **Application** और **AppVersion** फ़ील्ड को संशोधित नहीं किया जा सकता। Aspose.Slides प्रत्येक सहेजने पर इन्हें फिर से लिखता है, इसलिए सहेजी गई प्रस्तुति हमेशा "Aspose.Slides for Java" और उस लाइब्रेरी का संस्करण रिपोर्ट करती है जिसने इसे बनाया था। `setNameOfApplication` को पास किया गया कोई भी मान प्रस्तुति लिखते समय त्याग दिया जाता है।

{{% /alert %}} 

## **PowerPoint में दस्तावेज़ गुण**

Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों का प्रबंधन करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करना है और आगे **Prepare | Properties | Advanced Properties** मेनू आइटम को Microsoft PowerPoint 2007 में नीचे दिखाए अनुसार चुनना है।

|**Advanced Properties मेनू आइटम का चयन करना**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**Advanced Properties** मेनू आइटम चुनने के बाद, एक डायलॉग प्रदर्शित होगा जो आपको PowerPoint फ़ाइल के दस्तावेज़ गुणों को प्रबंधित करने की अनुमति देता है जैसा कि नीचे चित्र में दिखाया गया है:

|**गुणधर्म डायलॉग**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
ऊपर के **Properties Dialog** में, आप देख सकते हैं कि कई टैब पृष्ठ हैं जैसे **General**, **Summary**, **Statistics**, **Contents** और **Custom**। ये सभी टैब पृष्ठ PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब का उपयोग PowerPoint फ़ाइलों के कस्टम गुणों को प्रबंधित करने के लिए किया जाता है।

### Aspose.Slides for Java का उपयोग करके दस्तावेज़ गुणों के साथ काम करना

जैसा कि हमने पहले बताया था कि Aspose.Slides for Java दो प्रकार के दस्तावेज़ गुणों का समर्थन करता है, जो **Built-in** और **Custom** गुण हैं। इसलिए, डेवलपर्स Aspose.Slides for Java API का उपयोग करके दोनों प्रकार के गुणों तक पहुंच सकते हैं। Aspose.Slides for Java एक क्लास [IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties) प्रदान करता है जो **Presentation.DocumentProperties** गुण के माध्यम से प्रस्तुति फ़ाइल से जुड़े दस्तावेज़ गुणों का प्रतिनिधित्व करता है।

डेवलपर्स **IDocumentProperties** गुण का उपयोग कर सकते हैं जो [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) ऑब्जेक्ट द्वारा उजागर किया गया है, ताकि प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों तक नीचे वर्णित अनुसार पहुंच सकें:

## **Built-in गुणों तक पहुंच**

इन गुणों को [IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties) ऑब्जेक्ट द्वारा उजागर किया गया है, जिसमें शामिल हैं: **Creator** (लेखक), **Description**, **Keywords**, **Created** (निर्माण तिथि), **Modified** (संशोधन तिथि), **Printed** (आखिरी प्रिंट तिथि), **LastModifiedBy**, **SharedDoc** (क्या विभिन्न निर्माताओं के बीच साझा किया गया है?), **PresentationFormat**, **Subject** और **Title**.

```java
import com.aspose.slides.*;

// प्रेजेंटेशन का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // बिल्ट‑इन गुणों को प्रदर्शित करें
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

## **Built-in गुणों को संशोधित करें**

प्रस्तुति फ़ाइलों के built-in गुणों को संशोधित करना उन्हें एक्सेस करने जितना ही आसान है। आप बस किसी भी इच्छित गुण को एक स्ट्रिंग मान असाइन कर सकते हैं और गुण का मान संशोधित हो जाएगा। नीचे दिए गए उदाहरण में, हमने दिखाया है कि हम Aspose.Slides for Java का उपयोग करके प्रस्तुति फ़ाइल के built-in दस्तावेज़ गुणों को कैसे संशोधित कर सकते हैं।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
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

यह उदाहरण प्रस्तुति के built-in गुणों को संशोधित करता है जिसे नीचे दिखाए अनुसार देखा जा सकता है:

|**संशोधन के बाद Built-in दस्तावेज़ गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **कस्टम दस्तावेज़ गुण जोड़ें**

Aspose.Slides for Java डेवलपर्स को प्रस्तुति दस्तावेज़ गुणों के लिए कस्टम मान जोड़ने की भी अनुमति देता है। नीचे दिया गया उदाहरण तीन कस्टम गुण जोड़ता है, फिर इंडेक्स 2 पर संग्रहीत नाम को खोजता है और उस गुण को हटाता है, इसलिए सहेजी गई प्रस्तुति में दो ही बचते हैं। कस्टम गुण वर्णक्रम क्रम में अनुक्रमित होते हैं, न कि जिस क्रम में उन्हें जोड़ा गया था।

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
    
    // विशेष इंडेक्स पर गुण का नाम प्राप्त करना
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // चयनित गुण को हटाना
    dProps.removeCustomProperty(getPropertyName);
    
    // प्रस्तुति सहेजना
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**जोडे गए कस्टम दस्तावेज़ गुण**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **कस्टम गुणों तक पहुंचें और संशोधित करें**

Aspose.Slides for Java डेवलपर्स को कस्टम गुणों के मानों तक पहुंचने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप प्रस्तुति के सभी कस्टम गुणों तक कैसे पहुंच सकते हैं और उन्हें संशोधित कर सकते हैं।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े DocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // कस्टम गुणों तक पहुंचें और उन्हें संशोधित करें
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

{{% alert color="info" %}} 

नए मेथड्स [ReadDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), और [WriteBindedPresentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) को [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo) में जोड़ा गया है, [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) प्रॉपर्टी सेटर की लॉजिक बदल दी गई है।

{{% /alert %}} 

दो नए मेथड्स [ReadDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) और [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) को [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo) इंटरफ़ेस में जोड़ा गया है। ये दस्तावेज़ गुणों तक त्वरित पहुंच प्रदान करते हैं और पूरी प्रस्तुति को लोड किए बिना गुणों को बदलने और अपडेट करने की अनुमति देते हैं।

आम परिदृश्य जिसमें गुणों को लोड किया जाता है, कुछ मान बदलते हैं और दस्तावेज़ को अपडेट करते हैं, उसे निम्नलिखित तरीके से लागू किया जा सकता है:

```java
import com.aspose.slides.*;

// प्रेजेंटेशन की जानकारी पढ़ें
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

एक और तरीका है कि किसी विशेष प्रस्तुति के गुणों को टेम्पलेट के रूप में उपयोग करके अन्य प्रस्तुतियों में गुणों को अपडेट किया जाए:

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

एक नया टेम्पलेट शून्य से बनाया जा सकता है और फिर कई प्रस्तुतियों को अपडेट करने के लिए उपयोग किया जा सकता है:

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

Aspose.Slides LanguageId प्रॉपर्टी (जो PortionFormat क्लास द्वारा उजागर की गई है) प्रदान करता है जिससे आप PowerPoint दस्तावेज़ की प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण जांचे जाते हैं।

यह Java कोड आपको दिखाता है कि PowerPoint के लिए प्रूफ़िंग भाषा कैसे सेट करें:

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

    portionFormat.setLanguageId("zh-CN"); // प्रूफ़िंग भाषा की Id सेट करें

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

यह Java कोड आपको दिखाता है कि संपूर्ण PowerPoint प्रस्तुति की डिफ़ॉल्ट भाषा कैसे सेट करें:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // नया आयताकार आकार पाठ के साथ जोड़ें
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // पहले भाग की भाषा जाँचें
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **लाइव उदाहरण**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/hi/metadata) ऑनलाइन ऐप को आज़माएँ ताकि आप Aspose.Slides API के माध्यम से दस्तावेज़ गुणों के साथ कैसे काम किया जाए देख सकें:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## ***FAQ**

### प्रस्तुति से एक built-in गुण को कैसे हटाएँ?

Built-in गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालाँकि, आप उनके मान को बदल सकते हैं या यदि विशेष गुण अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

### यदि मैं पहले से मौजूद कस्टम गुण जोड़ूँ तो क्या होता है?

यदि आप पहले से मौजूद कस्टम गुण जोड़ते हैं, तो उसका मौजूदा मान नई मान से अधिलिखित हो जाएगा। आपको पहले से गुण को हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट कर देता है।

### क्या मैं पूरी प्रस्तुति को लोड किए बिना प्रस्तुति गुणों तक पहुंच सकता हूँ?

हाँ, आप [PresentationFactory](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/) क्लास की `getPresentationInfo` मेथड का उपयोग करके पूरी प्रस्तुति को लोड किए बिना प्रस्तुति गुणों तक पहुंच सकते हैं। फिर, [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/) इंटरफ़ेस द्वारा प्रदान की गई `readDocumentProperties` मेथड का उपयोग करके गुणों को कुशलता से पढ़ सकते हैं, जिससे मेमोरी बचती है और प्रदर्शन सुधरता है।