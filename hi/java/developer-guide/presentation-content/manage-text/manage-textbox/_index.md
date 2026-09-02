---
title: Java का उपयोग करके प्रस्तुतियों में टेक्स्ट बॉक्स प्रबंधित करें
linktitle: टेक्स्ट बॉक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/java/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ्रेम
- टेक्स्ट जोड़ें
- टेक्स्ट अपडेट करें
- टेक्स्ट बॉक्स बनाएँ
- टेक्स्ट बॉक्स जांचें
- टेक्स्ट कॉलम जोड़ें
- हाइपरलिंक जोड़ें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java PowerPoint और OpenDocument फ़ाइलों में टेक्स्ट बॉक्स को आसानी से बनाने, संपादित करने और क्लोन करने की सुविधा देता है, जिससे आपकी प्रस्तुति ऑटोमेशन में सुधार होता है।"
---
## **परिचय**

स्लाइड्स पर टेक्स्ट आमतौर पर टेक्स्ट बॉक्स या आकारों में होते हैं। इसलिए, स्लाइड पर टेक्स्ट जोड़ने के लिए आपको एक टेक्स्ट बॉक्स जोड़ना होगा और फिर उस टेक्स्ट बॉक्स के भीतर कुछ टेक्स्ट रखना होगा। Aspose.Slides for Java [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) इंटरफ़ेस प्रदान करता है जो आपको टेक्स्ट युक्त आकार जोड़ने की अनुमति देता है।

{{% alert title="Info" color="info" %}}
Aspose.Slides ayrıca [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape) इंटरफ़ेस प्रदान करता है जो आपको स्लाइड्स में आकार जोड़ने देती है। हालांकि, `IShape` इंटरफ़ेस के माध्यम से जोड़े गए सभी आकार टेक्स्ट रख नहीं सकते। लेकिन [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) इंटरफ़ेस के माध्यम से जोड़े गए आकार में टेक्स्ट हो सकता है। 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
इसलिए, जब आप किसी आकार पर टेक्स्ट जोड़ना चाहते हैं, तो आपको यह जांचना और पुष्टि करना चाहिए कि वह `IAutoShape` इंटरफ़ेस के माध्यम से कास्ट किया गया है। तभी आप [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrame) के साथ काम कर पाएंगे, जो `IAutoShape` की एक प्रॉपर्टी है। इस पृष्ठ पर स्थित [Update Text](https://docs.aspose.com/slides/hi/java/manage-textbox/#update-text) अनुभाग देखें। 
{{% /alert %}}

## **स्लाइड पर एक टेक्स्ट बॉक्स बनाएं**

स्लाइड पर एक टेक्स्ट बॉक्स बनाने के लिए इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।  
2. नवीन निर्मित प्रस्तुति में पहली स्लाइड का एक रेफ़रेंस प्राप्त करें।  
3. निर्दिष्ट स्थिति पर `Rectangle` रूप में सेट किए गए [ShapeType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IGeometryShape#setShapeType-int-) के साथ एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) ऑब्जेक्ट जोड़ें और नए जोड़े गए `IAutoShape` ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।  
4. `IAutoShape` ऑब्जेक्ट में एक `TextFrame` प्रॉपर्टी जोड़ें जिसमें टेक्स्ट होगा। नीचे दिए गए उदाहरण में हमने यह टेक्स्ट जोड़ा है: *Aspose TextBox*  
5. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें।  

नीचे दिया गया जावा कोड—ऊपर बताए गए चरणों का कार्यान्वयन—स्लाइड में टेक्स्ट जोड़ने का तरीका दर्शाता है:

```java
import com.aspose.slides.*;

// प्रस्तुति का इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);

    // प्रकार को Rectangle सेट करके AutoShape जोड़ता है
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle में TextFrame जोड़ता है
    ashp.addTextFrame(" ");

    // टेक्स्ट फ्रेम तक पहुंचता है
    ITextFrame txtFrame = ashp.getTextFrame();

    // टेक्स्ट फ्रेम के लिए Paragraph ऑब्जेक्ट बनाता है
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // पैराग्राफ के लिए Portion ऑब्जेक्ट बनाता है
    IPortion portion = para.getPortions().get_Item(0);

    // टेक्स्ट सेट करता है
    portion.setText("Aspose TextBox");

    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेक्स्ट बॉक्स आकार की जाँच करें**

Aspose.Slides [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) इंटरफ़ेस से [isTextBox](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/#isTextBox--) मेथड प्रदान करता है, जिससे आप आकारों की जाँच कर सकते हैं और टेक्स्ट बॉक्स की पहचान कर सकते हैं।

![टेक्स्ट बॉक्स और आकार](istextbox.png)

यह जावा कोड आपको दिखाता है कि कैसे यह जाँचें कि कोई आकार टेक्स्ट बॉक्स के रूप में बनाया गया था या नहीं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

ध्यान दें कि यदि आप केवल [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/) इंटरफ़ेस की `addAutoShape` मेथड का उपयोग करके एक ऑटोशेप जोड़ते हैं, तो उस ऑटोशेप की `isTextBox` मेथड `false` लौटाएगी। हालांकि, जब आप ऑटोशेप में `addTextFrame` मेथड या `setText` मेथड का उपयोग करके टेक्स्ट जोड़ते हैं, तो `isTextBox` प्रॉपर्टी `true` लौटाती है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() false वापस देता है
shape1.addTextFrame("shape 1");
// shape1.isTextBox() true वापस देता है

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() false वापस देता है
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() true वापस देता है

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() false वापस देता है
shape3.addTextFrame("");
// shape3.isTextBox() false वापस देता है

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() false वापस देता है
shape4.getTextFrame().setText("");
// shape4.isTextBox() false वापस देता है
```

## **टेक्स्ट फ्रेम वाला आकार खोजें**

सामान्य टेक्स्ट‑प्रोसेसिंग कोड में, आप कभी‑कभी कोई [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) प्राप्त कर सकते हैं बिना यह जाने कि वह किस प्रस्तुति ऑब्जेक्ट में स्थित है। मालिकाना [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) पर वापस नेविगेट करने के लिए [ITextFrame.getParentShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getParentShape--) मेथड का उपयोग करें।

यदि टेक्स्ट फ्रेम किसी [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) या अन्य टेक्स्ट‑धारक आकार से संबंधित है, तो [ITextFrame.getParentShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getParentShape--) मालिक को लौटाता है और [ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getParentCell--) `null` लौटाता है। दोनों मेथड केवल रीड‑ओनली नेविगेशन प्रदान करते हैं, इसलिए उनका उपयोग करने से स्वामित्व नहीं बदलता। किसी भी आकार तक पहुँचने से पहले हमेशा लौटाए गए मान को `null` के लिये जाँचें।

शेप और टेबल‑सेल मालिकों की पहचान करने वाले पूर्ण उदाहरण के लिए, जिसमें SmartArt नोड्स से जुड़े शैप्स भी शामिल हैं, देखें [Search and Replace Text](/slides/hi/java/search-and-replace-text/)।

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

Aspose.Slides [ColumnCount](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) और [ColumnSpacing](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) प्रॉपर्टी (जो [ITextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrameFormat) इंटरफ़ेस और [TextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrameFormat) क्लास से आती हैं) प्रदान करता है, जिससे आप टेक्स्ट बॉक्स में कॉलम जोड़ सकते हैं। आप टेक्स्ट बॉक्स में कॉलमों की संख्या निर्दिष्ट कर सकते हैं और कॉलमों के बीच बिंदु में स्पेसिंग सेट कर सकते हैं। 

यह जावा कोड इस कार्य को दर्शाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // प्रकार को Rectangle सेट करके एक AutoShape जोड़ता है
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Rectangle में TextFrame जोड़ता है
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // TextFrame का टेक्स्ट फॉर्मेट प्राप्त करता है
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // TextFrame में कॉलमों की संख्या निर्दिष्ट करता है
    format.setColumnCount(3);

    // कॉलमों के बीच की स्पेसिंग निर्दिष्ट करता है
    format.setColumnSpacing(10);

    // प्रस्तुति को सहेजता है
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेक्स्ट फ्रेम में कॉलम जोड़ें**

Aspose.Slides for Java [ColumnCount](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) प्रॉपर्टी (जो [ITextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrameFormat) इंटरफ़ेस से आती है) प्रदान करता है, जिससे आप टेक्स्ट फ्रेम में कॉलम जोड़ सकते हैं। इस प्रॉपर्टी के माध्यम से आप टेक्स्ट फ्रेम में अपनी मनचाही कॉलम संख्या निर्धारित कर सकते हैं। 

यह जावा कोड आपको दिखाता है कि कैसे टेक्स्ट फ्रेम के भीतर एक कॉलम जोड़ें:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेक्स्ट अपडेट करें**

Aspose.Slides आपको टेक्स्ट बॉक्स में या पूरी प्रस्तुति में मौजूद सभी टेक्स्ट को बदलने या अपडेट करने की अनुमति देता है। 

नीचे दिया गया जावा कोड एक ऐसी प्रक्रिया दर्शाता है जहाँ प्रस्तुति में सभी टेक्स्ट अपडेट या बदल दिए जाते हैं:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //जाँचता है कि आकार टेक्स्ट फ्रेम (IAutoShape) का समर्थन करता है।
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //टेक्स्ट फ्रेम में पैराग्राफ़ों पर पुनरावृति करता है
                {
                    for (IPortion portion : paragraph.getPortions()) //पैराग्राफ में प्रत्येक पोर्शन पर पुनरावृति करता है
                    {
                        portion.setText(portion.getText().replace("years", "months")); //टेक्स्ट बदलता है
                        portion.getPortionFormat().setFontBold(NullableBool.True); //फ़ॉर्मेटिंग बदलता है
                    }
                }
            }
        }
    }

    //संशोधित प्रस्तुति सहेजता है
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **हाइपरलिंक के साथ एक टेक्स्ट बॉक्स जोड़ें**

आप टेक्स्ट बॉक्स के भीतर एक लिंक डाल सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो उपयोगकर्ता लिंक खोलने के लिए निर्देशित होते हैं। 

हाइपरलिंक वाला टेक्स्ट बॉक्स जोड़ने के लिए इन चरणों का पालन करें:

1. `Presentation` क्लास का एक इंस्टेंस बनाएं।  
2. नवीन निर्मित प्रस्तुति में पहली स्लाइड का रेफ़रेंस प्राप्त करें।  
3. निर्दिष्ट स्थिति पर `Rectangle` रूप में सेट किए गए `ShapeType` के साथ एक `AutoShape` ऑब्जेक्ट जोड़ें और नए जोड़े गए AutoShape ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।  
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें जिसमें डिफ़ॉल्ट टेक्स्ट *Aspose TextBox* होगा।  
5. `IHyperlinkManager` क्लास का एक इंस्टेंस बनाएं।  
6. अपने इच्छित `TextFrame` हिस्से से जुड़े [HyperlinkClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Shape#getHyperlinkClick--) प्रॉपर्टी को `IHyperlinkManager` ऑब्जेक्ट असाइन करें।  
7. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

यह जावा कोड—ऊपर बताए गए चरणों का कार्यान्वयन—स्लाइड में हाइपरलिंक वाले टेक्स्ट बॉक्स को जोड़ने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

// PPTX का प्रतिनिधित्व करने वाले Presentation क्लास का एक इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle सेट प्रकार के साथ AutoShape ऑब्जेक्ट जोड़ता है
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // shape को AutoShape में कास्ट करता है
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShape से जुड़े ITextFrame प्रॉपर्टी तक पहुंचता है
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // फ़्रेम में कुछ टेक्स्ट जोड़ता है
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // पोर्शन टेक्स्ट के लिए हाइपरलिंक सेट करता है
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // PPTX प्रस्तुति सहेजता है
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड्स के साथ काम करते समय टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [प्लेसहोल्डर](/slides/hi/java/manage-placeholder/) शैली/स्थिति को [मास्टर](https://reference.aspose.com/slides/hi/java/com.aspose.slides/masterslide/) से विरासत में लेता है और इसे [लेआउट्स](https://reference.aspose.com/slides/hi/java/com.aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि एक नियमित टेक्स्ट बॉक्स एक स्वतंत्र ऑब्जेक्ट है जो विशिष्ट स्लाइड पर स्थित होता है और लेआउट बदलने पर नहीं बदलता।

**मैं प्रस्तुति में सभी टेक्स्ट को चार्ट, टेबल और SmartArt में मौजूद टेक्स्ट को बदले बिना बड़े पैमाने पर कैसे बदल सकता हूँ?**

इटरेशन को केवल उन ऑटो‑शेप्स तक सीमित रखें जिनके पास टेक्स्ट फ्रेम हैं और एम्बेडेड ऑब्जेक्ट्स ([चार्ट्स](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/), [टेबल्स](https://reference.aspose.com/slides/hi/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/smartart/)) को उनके कलेक्शन को अलग‑अलग ट्रैवर्स करके या उन ऑब्जेक्ट प्रकारों को स्किप करके बाहर रखें।