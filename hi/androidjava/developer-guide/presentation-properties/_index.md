---
title: एंड्रॉइड पर प्रस्तुति गुणधर्म प्रबंधित करें
linktitle: प्रस्तुति गुणधर्म
type: docs
weight: 70
url: /hi/androidjava/presentation-properties/
keywords:
- PowerPoint गुणधर्म
- प्रस्तुति गुणधर्म
- दस्तावेज़ गुणधर्म
- निर्मित गुणधर्म
- कस्टम गुणधर्म
- उन्नत गुणधर्म
- गुणधर्म प्रबंधित करें
- गुणधर्म संशोधित करें
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
description: "Aspose.Slides for Android via Java में प्रस्तुति गुणधर्मों को कुशलतापूर्वक प्रबंधित करें और अपने PowerPoint और OpenDocument फाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को व्यवस्थित करें।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ गुणधर्मों का समर्थन करता है: **Built-in** और **Custom**। इन दोनों प्रकार के गुणधर्मों को Aspose.Slides API के माध्यम से आसानी से पहुँचा और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणधर्मों के साथ काम करने की अनुमति देता है **[IDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/)** इंटरफ़ेस के द्वारा। इस इंटरफ़ेस का एक उदाहरण **[Presentation.getDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getDocumentProperties--)** मेथड द्वारा लौटाया जाता है। नीचे दिए गए उदाहरण दिखाते हैं कि इन गुणधर्मों को कैसे पढ़ें, संशोधित करें और प्रबंधित करें।

{{% alert color="info" %}} 

कृपया ध्यान दें कि **Application** और **AppVersion** फ़ील्ड को संशोधित नहीं किया जा सकता। Aspose.Slides हर सहेजने पर इन्हें पुनः लिखता है, इसलिए सहेजी गई प्रस्तुति हमेशा Aspose.Slides उत्पाद नाम और उस लाइब्रेरी के संस्करण को दर्शाती है जिससे यह बनाई गई थी। `setNameOfApplication` को दिया गया कोई भी मान प्रस्तुति लिखते समय त्याग दिया जाता है।

{{% /alert %}} 

## **PowerPoint में दस्तावेज़ गुणधर्म**

Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों की दस्तावेज़ गुणधर्मों के प्रबंधन की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करना है और आगे **Prepare | Properties | Advanced Properties** मेनू आइटम चुनना है जैसा कि नीचे दिखाया गया है:

|**Advanced Properties मेन्यू आइटम चुनना**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**Advanced Properties** मेन्यू आइटम चुनने के बाद, एक डायलॉग दिखाई देगा जो PowerPoint फ़ाइल की दस्तावेज़ गुणधर्मों को प्रबंधित करने की अनुमति देता है जैसा कि चित्र में दिखाया गया है:

|**गुणधर्म संवाद**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
ऊपर के **गुणधर्म संवाद** में आप देख सकते हैं कि कई टैब पृष्ठ हैं जैसे **General**, **Summary**, **Statistics**, **Contents** और **Custom**। ये सभी टैब पृष्ठ PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब PowerPoint फ़ाइलों के कस्टम गुणधर्मों को प्रबंधित करने के लिए उपयोग किया जाता है।



## **Aspose.Slides for Android via Java के साथ दस्तावेज़ गुणधर्मों का उपयोग**

जैसा कि हमने पहले कहा था कि Aspose.Slides for Android via Java दो प्रकार के दस्तावेज़ गुणधर्मों का समर्थन करता है, जो कि **Built-in** और **Custom** गुणधर्म हैं। इसलिए, डेवलपर्स Aspose.Slides for Android via Java API का उपयोग करके दोनों प्रकार के गुणधर्मों तक पहुँच सकते हैं। Aspose.Slides for Android via Java **[IDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties)** क्लास प्रदान करता है जो **Presentation.DocumentProperties** गुण के माध्यम से प्रस्तुति फ़ाइल से जुड़े दस्तावेज़ गुणधर्मों को दर्शाता है।

डेवलपर्स **[Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation)** ऑब्जेक्ट द्वारा उजागर किए गए **IDocumentProperties** गुण का उपयोग करके नीचे वर्णित अनुसार प्रस्तुति फ़ाइलों के दस्तावेज़ गुणधर्मों तक पहुँच सकते हैं:

## **Built-in गुणधर्म तक पहुँच**

इन गुणधर्मों को **[IDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties)** ऑब्जेक्ट द्वारा उजागर किया गया है, जिनमें शामिल हैं: **Creator** (लेखक), **Description**, **Keywords**, **Created** (सृजन तिथि), **Modified** (संशोधन तिथि), **Printed** (अंतिम प्रिंट तिथि), **LastModifiedBy**, **Keywords**, **SharedDoc** (क्या विभिन्न निर्माताओं के बीच साझा किया गया है?), **PresentationFormat**, **Subject** और **Title**।

```java
import com.aspose.slides.*;

// प्रस्तुति का प्रतिनिधित्व करने वाली Presentation क्लास का एक उदाहरण बनाएं
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़ी IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएँ
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // निर्मित गुणधर्म प्रदर्शित करें
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

## **Built-in गुणधर्म संशोधित करें**

प्रस्तुति फ़ाइलों के बिल्ट‑इन गुणधर्मों को संशोधित करना उतना ही आसान है जितना उन्हें पहुँचाना। आप बस किसी भी वांछित गुणधर्म को स्ट्रिंग मान असाइन कर दें और वह गुणधर्म संशोधित हो जाएगा। नीचे दिए गए उदाहरण में हमने दिखाया है कि Aspose.Slides for Android via Java का उपयोग करके प्रस्तुति फ़ाइल के बिल्ट‑इन दस्तावेज़ गुणधर्मों को कैसे संशोधित किया जा सकता है।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // निर्मित गुणधर्म सेट करें
    dp.setAuthor("Aspose.Slides for Android via Java");
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

यह उदाहरण प्रस्तुति के बिल्ट‑इन गुणधर्मों को संशोधित करता है जिसे नीचे दिखाया गया है:

|**संशोधन के बाद Built-in दस्तावेज़ गुणधर्म**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |


## **कस्टम दस्तावेज़ गुणधर्म जोड़ें**

Aspose.Slides for Android via Java डेवलपर्स को प्रस्तुति दस्तावेज़ गुणधर्मों के लिए कस्टम मान जोड़ने की भी अनुमति देता है। नीचे दिया गया उदाहरण तीन कस्टम गुणधर्म जोड़ता है, फिर इंडेक्स 2 पर संग्रहीत नाम को खोजता है और उस गुणधर्म को हटा देता है, जिससे सहेजी गई प्रस्तुति में दो ही बचे रहते हैं। कस्टम गुणधर्म वर्णक्रमानुसार क्रमित होते हैं, जोड़ने के क्रम में नहीं।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // दस्तावेज़ गुणधर्म प्राप्त करना
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // कस्टम गुणधर्म जोड़ना
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // विशिष्ट इंडेक्स पर गुणधर्म का नाम प्राप्त करना
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // चयनित गुणधर्म हटाना
    dProps.removeCustomProperty(getPropertyName);
    
    // प्रस्तुति सहेजना
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**जोड़े गए कस्टम दस्तावेज़ गुणधर्म**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |


## **कस्टम गुणधर्मों तक पहुँच और संशोधन**

Aspose.Slides for Android via Java डेवलपर्स को कस्टम गुणधर्मों के मानों तक पहुँचने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दिखाता है कि आप प्रस्तुति के सभी कस्टम गुणधर्मों तक कैसे पहुँच और संशोधित कर सकते हैं।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े DocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // कस्टम गुणधर्मों तक पहुँचना और उन्हें संशोधित करना
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // कस्टम गुणधर्मों के नाम और मान प्रदर्शित करें
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // कस्टम गुणधर्मों के मान संशोधित करें
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // अपनी प्रस्तुति को फ़ाइल में सहेजें
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

यह उदाहरण [PPTX ](https://docs.fileformat.com/presentation/pptx/)प्रस्तुति के कस्टम गुणधर्मों को संशोधित करता है। नीचे के चित्रों में संशोधन से पहले और बाद के कस्टम गुणधर्म दिखाए गए हैं:

|**संशोधन से पहले कस्टम गुणधर्म**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**संशोधन के बाद कस्टम गुणधर्म**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |


## **उन्नत दस्तावेज़ गुणधर्म**

{{% alert color="info" %}} 

नए मेथड **[ReadDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)**, **[UpdateDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)**, और **[WriteBindedPresentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-)** को **[IPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo)** में जोड़ा गया है, **[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-)** प्रॉपर्टी सेट्टर की लॉजिक को बदल दिया गया है।

{{% /alert %}} 

दो नए मेथड **[ReadDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)** और **[UpdateDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)** को **[IPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo)** इंटरफ़ेस में जोड़ा गया है। ये मेथड दस्तावेज़ गुणधर्मों तक त्वरित पहुँच प्रदान करते हैं और पूरी प्रस्तुति लोड किए बिना गुणधर्मों को बदलने एवं अद्यतन करने की अनुमति देते हैं।

सामान्य परिदृश्य में गुणधर्म लोड करें, कुछ मान बदलें और दस्तावेज़ को अद्यतन करें, इसे नीचे दिखाए गए तरीके से लागू किया जा सकता है:

```java
import com.aspose.slides.*;

// प्रस्तुति की जानकारी पढ़ें
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

एक विशिष्ट प्रस्तुति के गुणधर्मों को टेम्प्लेट के रूप में उपयोग करके अन्य प्रस्तुतियों के गुणधर्मों को अपडेट करने का एक और तरीका है:

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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

शुरू से एक नया टेम्प्लेट बनाया जा सकता है और फिर कई प्रस्तुतियों को अपडेट करने के लिए उपयोग किया जा सकता है:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **प्रूफ़िंग भाषा निर्धारित करें**

Aspose.Slides **PortionFormat** क्लास द्वारा उजागर किए गए **LanguageId** प्रॉपर्टी के माध्यम से PowerPoint दस्तावेज़ के लिए प्रूफ़िंग भाषा सेट करने की अनुमति देता है। प्रूफ़िंग भाषा वह भाषा होती है जिसके लिए PowerPoint में वर्तनी और व्याकरण जांचे जाते हैं।

यह Java कोड दिखाता है कि PowerPoint के लिए प्रूफ़िंग भाषा कैसे सेट करें:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

## **डिफ़ॉल्ट भाषा निर्धारित करें**

यह Java कोड दिखाता है कि पूरी PowerPoint प्रस्तुति के लिए डिफ़ॉल्ट भाषा कैसे सेट करें:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // नया आयताकार आकार पाठ के साथ जोड़ता है
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // पहले भाग की भाषा जाँचता है
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **लाइव उदाहरण**

ऑनलाइन ऐप **[Aspose.Slides Metadata](https://products.aspose.app/slides/hi/metadata)** को आज़माएँ ताकि आप Aspose.Slides API द्वारा दस्तावेज़ गुणधर्मों के साथ कैसे काम किया जाए देख सकें:

[![PowerPoint मेटाडेटा देखें व संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## ***अक्सर पूछे जाने वाले प्रश्न**

### मैं प्रस्तुति से बिल्ट‑इन गुणधर्म को कैसे हटा सकता हूँ?

बिल्ट‑इन गुणधर्म प्रस्तुति का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनका मान बदल सकते हैं या यदि विशिष्ट गुणधर्म अनुमति देता है तो उसे खाली सेट कर सकते हैं।

### यदि मैं कोई मौजूदा कस्टम गुणधर्म जोड़ूँ तो क्या होगा?

यदि आप कोई ऐसा कस्टम गुणधर्म जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान द्वारा अधिलेखित हो जाएगा। आपको पहले से मौजूद गुणधर्म को हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुणधर्म के मान को अपडेट कर देता है।

### क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणधर्मों तक पहुँच सकता हूँ?

हाँ, आप **PresentationFactory** क्लास के `getPresentationInfo` मेथड का उपयोग करके पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणधर्मों तक पहुँच सकते हैं। फिर, **[IPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/)** इंटरफ़ेस द्वारा प्रदान किए गए `readDocumentProperties` मेथड का उपयोग करके गुणधर्मों को कुशलता से पढ़ सकते हैं, जिससे मेमोरी बचती है और प्रदर्शन में सुधार होता है।