---
title: जावा में प्रस्तुति प्रॉपर्टीज़ प्रबंधित करें
linktitle: प्रस्तुति प्रॉपर्टीज़
type: docs
weight: 70
url: /hi/java/presentation-properties/
keywords:
- PowerPoint प्रॉपर्टीज़
- प्रस्तुति प्रॉपर्टीज़
- दस्तावेज़ प्रॉपर्टीज़
- बिल्ट‑इन प्रॉपर्टीज़
- कस्टम प्रॉपर्टीज़
- उन्नत प्रॉपर्टीज़
- प्रॉपर्टीज़ प्रबंधित करें
- प्रॉपर्टीज़ संशोधित करें
- दस्तावेज़ मेटाडाटा
- मेटाडाटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में प्रस्तुति प्रॉपर्टीज़ को मास्टर करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुव्यवस्थित करें."
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ प्रॉपर्टीज़ का समर्थन करता है: **बिल्ट‑इन** और **कस्टम**. इन दोनों प्रकार की प्रॉपर्टीज़ को Aspose.Slides API का उपयोग करके आसानी से पहुँचाया और प्रबंधित किया जा सकता है.

Aspose.Slides आपको प्रस्तुति दस्तावेज़ प्रॉपर्टीज़ के साथ काम करने की सुविधा [IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/) इंटरफ़ेस के माध्यम से देता है. इस इंटरफ़ेस का एक उदाहरण [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getDocumentProperties--) मेथड द्वारा लौटाया जाता है. निम्नलिखित उदाहरण दिखाते हैं कि इन प्रॉपर्टीज़ को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए.

{{% alert color="info" title="Note" %}}
कृपया ध्यान दें कि **Application** और **AppVersion** फ़ील्ड्स को संशोधित नहीं किया जा सकता. Aspose.Slides प्रत्येक सहेजने पर इन्हें पुनः लिखता है, इसलिए सेव किए गये प्रस्तुति हमेशा "Aspose.Slides for Java" और लाइब्रेरी के संस्करण को रिपोर्ट करता है. `setNameOfApplication` को दिया गया कोई भी मान प्रस्तुति लिखे जाने पर हटाया जा देता है.
{{% /alert %}} 

## **PowerPoint में दस्तावेज़ प्रॉपर्टीज़**

Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों की दस्तावेज़ प्रॉपर्टीज़ को प्रबंधित करने की अनुमति देता है. आपको केवल Office आइकन पर क्लिक करना है और फिर **Prepare | Properties | Advanced Properties** मेनू आइटम चुनना है जैसा कि नीचे दिखाया गया है:

|**Advanced Properties मेनू आइटम चुनना**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**Advanced Properties** मेनू आइटम चुनने के बाद, एक डायलॉग बॉक्स प्रदर्शित होगा जो PowerPoint फ़ाइल की दस्तावेज़ प्रॉपर्टीज़ को प्रबंधित करने की सुविधा देता है, जैसा कि नीचे चित्र में दिखाया गया है:

|**Properties Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
उपरोक्त **Properties Dialog** में आप देख सकते हैं कि कई टैब पेज हैं जैसे **General**, **Summary**, **Statistics**, **Contents** और **Custom**. ये सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं. **Custom** टैब PowerPoint फ़ाइलों की कस्टम प्रॉपर्टीज़ को प्रबंधित करने के लिये प्रयोग किया जाता है.

## **Aspose.Slides for Java के साथ दस्तावेज़ प्रॉपर्टीज़ पर काम करना**

जैसा कि हमने पहले बताया कि Aspose.Slides for Java दो प्रकार की दस्तावेज़ प्रॉपर्टीज़—**बिल्ट‑इन** और **कस्टम**—का समर्थन करता है. इसलिए, डेवलपर्स Aspose.Slides for Java API का उपयोग करके दोनों प्रकार की प्रॉपर्टीज़ तक पहुँच सकते हैं. Aspose.Slides for Java एक क्लास [IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties) प्रदान करता है जो **Presentation.DocumentProperties** प्रॉपर्टी के माध्यम से प्रस्तुति फ़ाइल से जुड़ी दस्तावेज़ प्रॉपर्टीज़ का प्रतिनिधित्व करता है.

डेवलपर्स नीचे दर्शाए अनुसार [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) ऑब्जेक्ट द्वारा उजागर की गई **IDocumentProperties** प्रॉपर्टी का उपयोग करके प्रस्तुति फ़ाइलों की दस्तावेज़ प्रॉपर्टीज़ तक पहुँच सकते हैं:

## **बिल्ट‑इन प्रॉपर्टीज़ तक पहुँच**

[IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties) ऑब्जेक्ट द्वारा उजागर की गई ये प्रॉपर्टीज़ शामिल हैं: **Creator** (लेखक), **Description**, **Keywords**, **Created** (निर्माण तिथि), **Modified** (संशोधन तिथि), **Printed** (अंतिम प्रिंट तिथि), **LastModifiedBy**, **SharedDoc** (क्या विभिन्न निर्माताओं द्वारा साझा किया गया है?), **PresentationFormat**, **Subject**, और **Title**.

```java
import com.aspose.slides.*;

// प्रस्तुति का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़ी IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // बिल्ट‑इन प्रॉपर्टीज़ को प्रदर्शित करें
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

## **बिल्ट‑इन प्रॉपर्टीज़ को संशोधित करना**

प्रेजेंटेशन फ़ाइलों की बिल्ट‑इन प्रॉपर्टीज़ को संशोधित करना उतना ही आसान है जितना उन्हें पहुँचाना. आप बस किसी भी चाही हुई प्रॉपर्टी को स्ट्रिंग मान असाइन कर दें और प्रॉपर्टी का मान बदल जाएगा. नीचे दिए गए उदाहरण में हमने दिखाया है कि कैसे Aspose.Slides for Java का उपयोग करके प्रस्तुति फ़ाइल की बिल्ट‑इन दस्तावेज़ प्रॉपर्टीज़ को संशोधित किया जा सकता है.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़ी IDocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // बिल्ट‑इन प्रॉपर्टीज़ सेट करें
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // प्रस्तुति को फ़ाइल में सहेजें
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

यह उदाहरण प्रस्तुति की बिल्ट‑इन प्रॉपर्टीज़ को इस प्रकार संशोधित करता है:

|**संशोधन के बाद बिल्ट‑इन दस्तावेज़ प्रॉपर्टीज़**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **कस्टम दस्तावेज़ प्रॉपर्टीज़ जोड़ना**

Aspose.Slides for Java डेवलपर्स को प्रस्तुति दस्तावेज़ प्रॉपर्टीज़ के लिए कस्टम मान जोड़ने की भी अनुमति देता है. नीचे का उदाहरण तीन कस्टम प्रॉपर्टीज़ जोड़ता है, फिर इंडेक्स 2 पर संग्रहीत नाम को खोजता है और उस प्रॉपर्टी को हटाते है, जिससे सहेजी गई प्रस्तुति में दो प्रॉपर्टीज़ बचती हैं. कस्टम प्रॉपर्टीज़ को वर्णक्रमानुक्रम में इंडेक्स किया जाता है, न कि उनके जोड़े जाने के क्रम में.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // दस्तावेज़ प्रॉपर्टीज़ प्राप्त कर रहे हैं
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // कस्टम प्रॉपर्टीज़ जोड़ रहे हैं
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // विशिष्ट सूचकांक पर प्रॉपर्टी का नाम प्राप्त कर रहे हैं
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // चयनित प्रॉपर्टी हटा रहे हैं
    dProps.removeCustomProperty(getPropertyName);
    
    // प्रस्तुति सहेज रहे हैं
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**जोड़ें गई कस्टम दस्तावेज़ प्रॉपर्टीज़**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **कस्टम प्रॉपर्टीज़ तक पहुँच और संशोधन**

Aspose.Slides for Java डेवलपर्स को कस्टम प्रॉपर्टीज़ के मानों तक पहुँचने की सुविधा भी देता है. नीचे दिया गया उदाहरण दिखाता है कि आप प्रस्तुति की सभी कस्टम प्रॉपर्टीज़ को कैसे पहुँच और संशोधित कर सकते हैं.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation से जुड़ी DocumentProperties ऑब्जेक्ट का संदर्भ बनाएं
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // कस्टम प्रॉपर्टीज़ तक पहुँचें और संशोधित करें
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

यह उदाहरण [PPTX](https://docs.fileformat.com/presentation/pptx/) प्रस्तुति की कस्टम प्रॉपर्टीज़ को संशोधित करता है. नीचे के चित्रों में संशोधन से पहले और बाद की कस्टम प्रॉपर्टीज़ दिखायी गयी हैं:

|**संशोधन से पहले कस्टम प्रॉपर्टीज़**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**संशोधन के बाद कस्टम प्रॉपर्टीज़**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **एडवांस्ड दस्तावेज़ प्रॉपर्टीज़**

{{% alert color="info" title="Note" %}}
नए मेथड्स [ReadDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), और [WriteBindedPresentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) को [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo) में जोड़ा गया है, और [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) प्रॉपर्टी सेटटर की लॉजिक बदल दी गई है.
{{% /alert %}} 

नए मेथड्स [ReadDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) और [UpdateDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) को [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentationInfo) इंटरफ़ेस में जोड़ा गया है. ये मेथड्स दस्तावेज़ प्रॉपर्टीज़ तक त्वरित पहुँच प्रदान करते हैं और पूरी प्रस्तुति को लोड किए बिना प्रॉपर्टीज़ को बदलने और अपडेट करने की अनुमति देते हैं.

सामान्य परिदृश्य में प्रॉपर्टीज़ को लोड करना, कुछ मान बदलना और दस्तावेज़ को अपडेट करना निम्न प्रकार कार्यान्वित किया जा सकता है:

```java
import com.aspose.slides.*;

// प्रस्तुति की जानकारी पढ़ें
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// वर्तमान प्रॉपर्टीज़ प्राप्त करें
IDocumentProperties props = info.readDocumentProperties();

// लेखक और शीर्षक फ़ील्ड के नए मान सेट करें
props.setAuthor("New Author");
props.setTitle("New Title");

// प्रस्तुति को नए मानों के साथ अपडेट करें
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

एक अन्य तरीका यह है कि किसी विशेष प्रस्तुति की प्रॉपर्टीज़ को टेम्पलेट के रूप में उपयोग करके अन्य प्रस्तुतियों में प्रॉपर्टीज़ को अपडेट किया जाए:

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

## **प्रूफ़िंग भाषा सेट करना**

Aspose.Slides LanguageId प्रॉपर्टी (PortionFormat क्लास द्वारा उजागर) प्रदान करता है जिससे आप PowerPoint दस्तावेज़ की प्रूफ़िंग भाषा सेट कर सकते हैं. प्रूफ़िंग भाषा वह भाषा है जिसके लिये PowerPoint में वर्तनी और व्याकरण जांचे जाते हैं.

यह Java कोड दिखाता है कि PowerPoint की प्रूफ़िंग भाषा कैसे सेट करें:

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

## **डिफ़ॉल्ट भाषा सेट करना**

यह Java कोड दिखाता है कि पूरी PowerPoint प्रस्तुति की डिफ़ॉल्ट भाषा कैसे सेट करें:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // नया आयताकार आकार टेक्स्ट के साथ जोड़ें
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // पहले भाग की भाषा जांचें
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **लाइव उदाहरण**

Aspose.Slides Metadata ऑनलाइन ऐप आज़माएँ ताकि आप Aspose.Slides API के माध्यम से दस्तावेज़ प्रॉपर्टीज़ के साथ काम करने का तरीका देख सकें:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **FAQ**

**मैं प्रस्तुति से बिल्ट‑इन प्रॉपर्टी को कैसे हटाऊँ?**

बिल्ट‑इन प्रॉपर्टीज़ प्रस्तुति का अभिन्न भाग होती हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता. हालांकि, आप उनके मान बदल सकते हैं या यदि संबंधित प्रॉपर्टी अनुमति देती है तो उन्हें खाली सेट कर सकते हैं.

**यदि मैं ऐसा कस्टम प्रॉपर्टी जोड़ूँ जो पहले से मौजूद है तो क्या होगा?**

यदि आप ऐसा कस्टम प्रॉपर्टी जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा. आपको प्रॉपर्टी को हटाने या पहले जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से प्रॉपर्टी के मान को अपडेट कर देता है.

**क्या मैं प्रस्तुति को पूरी तरह लोड किए बिना उसकी प्रॉपर्टीज़ तक पहुँच सकता हूँ?**

हाँ. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करें और फिर [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) के माध्यम से संग्रहित दस्तावेज़ मेटाडेटा को बिना [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस बनाए पढ़ें. पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिये देखें [Build a Lightweight Presentation Inventory](/slides/hi/java/examine-presentation/).