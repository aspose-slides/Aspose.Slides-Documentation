---
title: "Android पर प्रेज़ेंटेशन प्रॉपर्टीज़ का प्रबंधन"
linktitle: "प्रेज़ेंटेशन प्रॉपर्टीज़"
type: docs
weight: 70
url: /hi/androidjava/presentation-properties/
keywords:
  - "PowerPoint प्रॉपर्टीज़"
  - "प्रेज़ेंटेशन प्रॉपर्टीज़"
  - "दस्तावेज़ प्रॉपर्टीज़"
  - "बिल्ट‑इन प्रॉपर्टीज़"
  - "कस्टम प्रॉपर्टीज़"
  - "एडवांस्ड प्रॉपर्टीज़"
  - "प्रॉपर्टीज़ प्रबंधित करें"
  - "प्रॉपर्टीज़ संशोधित करें"
  - "दस्तावेज़ मेटाडेटा"
  - "मेटाडेटा संपादित करें"
  - "प्रूफ़िंग भाषा"
  - "डिफ़ॉल्ट भाषा"
  - "PowerPoint"
  - "OpenDocument"
  - "प्रेज़ेंटेशन"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "Aspose.Slides for Android via Java में प्रेज़ेंटेशन प्रॉपर्टीज़ को मास्टर करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुव्यवस्थित करें।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ को सपोर्ट करता है: **Built-in** और **Custom**. इन दोनों प्रकार की प्रॉपर्टीज़ को Aspose.Slides API का उपयोग करके आसानी से एक्सेस और मैनेज किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ प्रॉपर्टीज़ के साथ काम करने की अनुमति देता है **[IDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/)** इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस का एक उदाहरण **[Presentation.getDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getDocumentProperties--)** मेथड द्वारा वापस मिलता है। नीचे दिए गए उदाहरण दिखाते हैं कि इन प्रॉपर्टीज़ को कैसे पढ़ा, संशोधित और प्रबंधित किया जा सकता है।

{{% alert color="info" title="नोट" %}}
कृपया ध्यान दें कि **Application** और **AppVersion** फ़ील्ड को संशोधित नहीं किया जा सकता। Aspose.Slides उन्हें प्रत्येक सहेजने पर पुनः लिखता है, इसलिए सहेजी गई प्रस्तुति हमेशा Aspose.Slides उत्पाद नाम और उस लाइब्रेरी का संस्करण दिखाती है जिसने इसे बनाया। `setNameOfApplication` को दिया गया कोई भी मान प्रस्तुति लिखते समय त्याग दिया जाता है।
{{% /alert %}} 

## **PowerPoint में दस्तावेज़ प्रॉपर्टीज़**

Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों की दस्तावेज़ प्रॉपर्टीज़ को प्रबंधित करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करना है और आगे **Prepare | Properties | Advanced Properties** मेन्यू आइटम को चुनना है जैसा कि नीचे दिखाया गया है:

|**Advanced Properties मेन्यू आइटम चुनना**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** मेन्यू आइटम चुनने के बाद, एक डायलॉग दिखाई देगा जो आपको PowerPoint फ़ाइल की दस्तावेज़ प्रॉपर्टीज़ को प्रबंधित करने की अनुमति देता है, जैसा कि नीचे चित्र में दिखाया गया है:

|**Properties डायलॉग**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

उपरोक्त **Properties डायलॉग** में आप देख सकते हैं कि कई टैब पेज हैं जैसे **General**, **Summary**, **Statistics**, **Contents** और **Custom**। सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब PowerPoint फ़ाइलों की कस्टम प्रॉपर्टीज़ को प्रबंधित करने के लिए उपयोग किया जाता है।

### Aspose.Slides for Android via Java का उपयोग करके दस्तावेज़ प्रॉपर्टेज़ के साथ काम करना

जैसा कि हमने पहले बताया था, Aspose.Slides for Android via Java दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ को सपोर्ट करता है, जो कि **Built-in** और **Custom** प्रॉपर्टीज़ हैं। इसलिए, डेवलपर्स दोनों प्रकार की प्रॉपर्टीज़ को Aspose.Slides for Android via Java API का उपयोग करके एक्सेस कर सकते हैं। Aspose.Slides for Android via Java एक क्लास **[IDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties)** प्रदान करता है जो **Presentation.DocumentProperties** प्रॉपर्टी के माध्यम से प्रस्तुति फ़ाइल से जुड़ी दस्तावेज़ प्रॉपर्टीज़ को दर्शाता है।

डेवलपर्स **[Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation)** ऑब्जेक्ट द्वारा एक्सपोज़्ड **IDocumentProperties** प्रॉपर्टी का उपयोग करके नीचे दर्शाए अनुसार प्रस्तुति फ़ाइलों की दस्तावेज़ प्रॉपर्टीज़ को एक्सेस कर सकते हैं:

## **Built-in प्रॉपर्टीज़ तक पहुँच**

इन प्रॉपर्टीज़ को **[IDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties)** ऑब्जेक्ट से एक्सपोज़ किया गया है, जिसमें शामिल हैं: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (क्या विभिन्न निर्माताओं के बीच साझा किया गया है?), **PresentationFormat**, **Subject** और **Title**।

```java
import com.aspose.slides.*;

// Presentation क्लास को इंस्टैंसिएट करें जो प्रस्तुति का प्रतिनिधित्व करता है
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का रेफरेंस बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // बिल्ट‑इन प्रॉपर्टीज़ प्रदर्शित करें
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

## **Built-in प्रॉपर्टीज़ को संशोधित करना**

प्रेजेंटेशन फ़ाइलों की Built-in प्रॉपर्टीज़ को संशोधित करना उतना ही आसान है जितना उन्हें एक्सेस करना। आप बस इच्छित प्रॉपर्टी को स्ट्रिंग वैल्यू असाइन कर दें और प्रॉपर्टी वैल्यू बदल जाएगी। नीचे दिए गए उदाहरण में हमने दर्शाया है कि कैसे Aspose.Slides for Android via Java का उपयोग करके प्रस्तुति फ़ाइल की Built-in दस्तावेज़ प्रॉपर्टीज़ को संशोधित किया जा सकता है।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े IDocumentProperties ऑब्जेक्ट का रेफरेंस बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // बिल्ट‑इन प्रॉपर्टीज़ सेट करें
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

यह उदाहरण Built-in प्रॉपर्टीज़ को इस प्रकार दिखाता है:

|**संशोधन के बाद Built-in दस्तावेज़ प्रॉपर्टीज़**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Custom दस्तावेज़ प्रॉपर्टीज़ जोड़ना**

Aspose.Slides for Android via Java डेवलपर्स को प्रस्तुति दस्तावेज़ प्रॉपर्टीज़ के लिए कस्टम वैल्यू जोड़ने की अनुमति भी देता है। नीचे दिया गया उदाहरण तीन कस्टम प्रॉपर्टीज़ जोड़ता है, फिर इंडेक्स 2 पर संग्रहीत नाम को देखता है और उस प्रॉपर्टी को हटा देता है, इसलिए सहेजी गई प्रस्तुति में दो ही प्रॉपर्टीज़ बचती हैं। कस्टम प्रॉपर्टीज़ को वर्णक्रमानुसार क्रमित किया जाता है, न कि जोड़ा जाने के क्रम में।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // दस्तावेज़ प्रॉपर्टीज़ प्राप्त कर रहा है
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // कस्टम प्रॉपर्टीज़ जोड़ रहा है
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // विशिष्ट इंडेक्स पर प्रॉपर्टी नाम प्राप्त कर रहा है
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // चयनित प्रॉपर्टी को हटा रहा है
    dProps.removeCustomProperty(getPropertyName);
    
    // प्रस्तुति सहेज रहा है
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**जोड़ी गई कस्टम दस्तावेज़ प्रॉपर्टीज़**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **कस्टम प्रॉपर्टीज़ को एक्सेस और संशोधित करना**

Aspose.Slides for Android via Java डेवलपर्स को कस्टम प्रॉपर्टीज़ के वैल्यू को एक्सेस करने की भी सुविधा देता है। नीचे दिया गया उदाहरण दर्शाता है कि आप प्रस्तुति की सभी कस्टम प्रॉपर्टीज़ को कैसे एक्सेस और संशोधित कर सकते हैं।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़े DocumentProperties ऑब्जेक्ट का रेफरेंस बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // कस्टम प्रॉपर्टीज़ तक पहुँचें और उन्हें संशोधित करें
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // कस्टम प्रॉपर्टीज़ के नाम और मान प्रदर्शित करें
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // कस्टम प्रॉपर्टीज़ के मान संशोधित करें
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // अपनी प्रस्तुति को फ़ाइल में सहेजें
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

यह उदाहरण [PPTX](https://docs.fileformat.com/presentation/pptx/) प्रस्तुति की कस्टम प्रॉपर्टीज़ को संशोधित करता है। नीचे की आकृतियाँ संशोधन से पहले और बाद की कस्टम प्रॉपर्टीज़ को दिखाती हैं:

|**संशोधन से पहले कस्टम प्रॉपर्टीज़**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**संशोधन के बाद कस्टम प्रॉपर्टीज़**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced दस्तावेज़ प्रॉपर्टीज़**

{{% alert color="info" title="नोट" %}}
नए मेथड **[ReadDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)**, **[UpdateDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)**, और **[WriteBindedPresentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-)** को **[IPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo)** में जोड़ा गया है, तथा **[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-)** प्रॉपर्टी सेट्टर की लॉजिक बदल दी गई है।
{{% /alert %}} 

दो नए मेथड **[ReadDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)** और **[UpdateDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)** को **[IPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPresentationInfo)** इंटरफ़ेस में जोड़ा गया है। ये मेथड दस्तावेज़ प्रॉपर्टीज़ तक तेज़ पहुँच प्रदान करते हैं और पूरे प्रेजेंटेशन को लोड किए बिना प्रॉपर्टीज़ को बदलने और अद्यतन करने की अनुमति देते हैं।

आम परिस्थिति में प्रॉपर्टीज़ को लोड करना, कुछ वैल्यू बदलना और दस्तावेज़ को अद्यतन करना निम्नलिखित तरीके से लागू किया जा सकता है:

```java
import com.aspose.slides.*;

// प्रस्तुति की जानकारी पढ़ें
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// वर्तमान प्रॉपर्टीज़ प्राप्त करें
IDocumentProperties props = info.readDocumentProperties();

// Author और Title फ़ील्ड की नई वैल्यू सेट करें
props.setAuthor("New Author");
props.setTitle("New Title");

// नई वैल्यू के साथ प्रस्तुति को अपडेट करें
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

एक अन्य तरीका यह है कि किसी विशेष प्रस्तुति की प्रॉपर्टीज़ को टेम्पलेट के रूप में उपयोग करके अन्य प्रस्तुतियों की प्रॉपर्टीज़ को अद्यतन किया जाए:

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

शुरुआत से एक नया टेम्पलेट बनाया जा सकता है और फिर कई प्रस्तुतियों को अद्यतन करने के लिए उपयोग किया जा सकता है:

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

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides **LanguageId** प्रॉपर्टी (जो **PortionFormat** क्लास द्वारा एक्सपोज़्ड है) प्रदान करता है जिससे आप PowerPoint दस्तावेज़ की प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण की जाँच की जाती है।

यह Java कोड दिखाता है कि PowerPoint के लिए प्रूफ़िंग भाषा कैसे सेट की जाए:

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

## **डिफ़ॉल्ट भाषा सेट करें**

यह Java कोड दिखाता है कि पूरे PowerPoint प्रस्तुति के लिए डिफ़ॉल्ट भाषा कैसे सेट की जाए:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // नया आयताकार आकार टेक्स्ट के साथ जोड़ता है
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // पहले हिस्से की भाषा जाँचता है
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **लाइव उदाहरण**

Aspose.Slides API के माध्यम से दस्तावेज़ प्रॉपर्टीज़ के साथ कैसे काम करें, यह देखने के लिए ऑनलाइन ऐप **[Aspose.Slides Metadata](https://products.aspose.app/slides/hi/metadata)** आज़माएँ:

[![PowerPoint मेटाडेटा देखें एवं संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से एक Built-in प्रॉपर्टी को कैसे हटा सकता हूँ?**

Built-in प्रॉपर्टीज़ प्रस्तुति का अभिन्न हिस्सा होती हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान को बदल सकते हैं या यदि विशेष प्रॉपर्टी अनुमति देती है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं कोई मौजूदा कस्टम प्रॉपर्टी जोड़ूँ तो क्या होगा?**

यदि आप कोई कस्टम प्रॉपर्टी जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नई वैल्यू से ओवरराइट हो जाएगा। आपको पहले प्रॉपर्टी को हटाने या जांचने की जरूरत नहीं है, क्योंकि Aspose.Slides स्वतः ही प्रॉपर्टी के मान को अपडेट कर देता है।

**क्या मैं पूरी प्रस्तुति को लोड किए बिना प्रॉपर्टीज़ तक पहुँच सकता हूँ?**

हां। **[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)** का उपयोग करें और फिर **[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)** के द्वारा बिना **[Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/)** इंस्टेंस बनाए स्टोर्ड डॉक्यूमेंट मेटाडेटा को पढ़ें। पूरा रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑स्पेसिफिक सीमाओं के लिए **[Build a Lightweight Presentation Inventory](/slides/hi/androidjava/examine-presentation/)** देखें।