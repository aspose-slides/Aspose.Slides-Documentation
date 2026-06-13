---
title: जावा का उपयोग करके प्रस्तुतियों में टेक्स्ट बॉक्स प्रबंधित करें
linktitle: टेक्स्ट बॉक्स का प्रबंधन
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
description: "Aspose.Slides for Java PowerPoint और OpenDocument फ़ाइलों में टेक्स्ट बॉक्स बनाने, संपादित करने और क्लोन करने को आसान बनाता है, जिससे आपकी प्रस्तुति स्वचालन में सुधार होता है।"
---
## **परिचय**

Slides पर टेक्स्ट आमतौर पर टेक्स्ट बॉक्स या शैप्स में होते हैं। इसलिए, स्लाइड में टेक्स्ट जोड़ने के लिए आपको पहले एक टेक्स्ट बॉक्स जोड़ना होगा और फिर उसके अंदर टेक्स्ट डालना होगा। Aspose.Slides for Java [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) इंटरफ़ेस प्रदान करता है जो आपको टेक्स्ट वाला शैप जोड़ने की अनुमति देता है।

{{% alert title="Info" color="info" %}}

Aspose.Slides additionally [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape) इंटरफ़ेस प्रदान करता है जो आपको स्लाइड्स में शैप्स जोड़ने देता है। हालांकि, `IShape` इंटरफ़ेस के माध्यम से जोड़े गए सभी शैप्स टेक्स्ट धारण नहीं कर सकते। लेकिन [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) इंटरफ़ेस के माध्यम से जोड़े गए शैप्स में टेक्स्ट हो सकता है। 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

इसलिए, जब आप ऐसे शैप को टार्गेट कर रहे हों जिसमें आप टेक्स्ट जोड़ना चाहते हैं, तो आपको यह जांचना और सुनिश्चित करना चाहिए कि वह `IAutoShape` इंटरफ़ेस के द्वारा कास्ट किया गया है। तभी आप [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrame), जो `IAutoShape` की एक प्रॉपर्टी है, के साथ काम कर पाएँगे। इस पृष्ठ के [Update Text](https://docs.aspose.com/slides/hi/java/manage-textbox/#update-text) सेक्शन को देखें। 

{{% /alert %}}

## **स्लाइड पर एक टेक्स्ट बॉक्स बनाएँ**

स्लाइड पर टेक्स्ट बॉक्स बनाने के लिए निम्नलिखित चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास की एक इंस्‍टेंस बनाएँ। 
2. नई बनाई गई प्रेजेंटेशन की पहली स्लाइड के लिए रेफ़रेंस प्राप्त करें। 
3. निर्दिष्ट स्थिति पर `Rectangle` के रूप में `ShapeType` सेट करके एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) ऑब्जेक्ट जोड़ें और नए जोड़े गए `IAutoShape` ऑब्जेक्ट का रेफ़रेंस प्राप्त करें। 
4. `IAutoShape` ऑब्जेक्ट में `TextFrame` प्रॉपर्टी जोड़ें जिसमें टेक्स्ट होगा। नीचे वाले उदाहरण में हमने यह टेक्स्ट जोड़ा: *Aspose TextBox* 
5. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

ऊपर वर्णित चरणों का एक जावा इम्प्लीमेंटेशन यह दिखाता है कि स्लाइड में टेक्स्ट कैसे जोड़े:

```java
// प्रस्तुति का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);

    // प्रकार को Rectangle सेट करके एक AutoShape जोड़ता है
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle में TextFrame जोड़ता है
    ashp.addTextFrame(" ");

    // टेक्स्ट फ़्रेम तक पहुँचता है
    ITextFrame txtFrame = ashp.getTextFrame();

    // टेक्स्ट फ़्रेम के लिए Paragraph ऑब्जेक्ट बनाता है
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

## **टेक्स्ट बॉक्स शैप की जाँच करें**

Aspose.Slides [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) इंटरफ़ेस से [isTextBox](https://reference.aspose.com/slides/hi/java/com.aspose.slides/autoshape/#isTextBox--) मेथड प्रदान करता है, जिससे आप शैप्स की जांच करके टेक्स्ट बॉक्स की पहचान कर सकते हैं।

![टेक्स्ट बॉक्स और शैप](istextbox.png)

यह जावा कोड दर्शाता है कि कैसे जाँचें कि कोई शैप टेक्स्ट बॉक्स के रूप में बनाया गया है या नहीं:

```java
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

ध्यान दें कि यदि आप केवल `addAutoShape` मेथड का उपयोग करके [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/) इंटरफ़ेस से एक ऑटॉशैप जोड़ते हैं, तो ऑटॉशैप का `isTextBox` मेथड `false` लौटाएगा। हालाँकि, जब आप `addTextFrame` मेथड या `setText` मेथड से ऑटॉशैप में टेक्स्ट जोड़ते हैं, तो `isTextBox` प्रॉपर्टी `true` लौटाएगी।

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() false लौटाता है
shape1.addTextFrame("shape 1");
// shape1.isTextBox() true लौटाता है

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() false लौटाता है
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() true लौटाता है

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() false लौटाता है
shape3.addTextFrame("");
// shape3.isTextBox() false लौटाता है

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() false लौटाता है
shape4.getTextFrame().setText("");
// shape4.isTextBox() false लौटाता है
```

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

Aspose.Slides [ITextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrameFormat) इंटरफ़ेस और [TextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TextFrameFormat) क्लास से [ColumnCount](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) और [ColumnSpacing](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) प्रॉपर्टीज़ प्रदान करता है जो आपको टेक्स्टबॉक्स में कॉलम जोड़ने की अनुमति देती हैं। आप टेक्स्ट बॉक्स में कॉलम की संख्या और कॉलमों के बीच के स्पेसिंग को पॉइंट्स में निर्दिष्ट कर सकते हैं। 

यह जावा कोड उपर्युक्त ऑपरेशन को दर्शाता है:

```java
Presentation pres = new Presentation();
try {
    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // प्रकार को Rectangle सेट करके AutoShape जोड़ता है
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Rectangle में TextFrame जोड़ता है
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // TextFrame का टेक्स्ट फ़ॉर्मेट प्राप्त करता है
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // TextFrame में कॉलमों की संख्या निर्दिष्ट करता है
    format.setColumnCount(3);

    // कॉलमों के बीच का अंतराल निर्दिष्ट करता है
    format.setColumnSpacing(10);

    // प्रस्तुति को सहेजता है
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेक्स्ट फ्रेम में कॉलम जोड़ें**
Aspose.Slides for Java [ITextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrameFormat) इंटरफ़ेस से [ColumnCount](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) प्रॉपर्टी प्रदान करता है, जिससे आप टेक्स्ट फ्रेम में कॉलम जोड़ सकते हैं। इस प्रॉपर्टी के माध्यम से आप टेक्स्ट फ्रेम में अपनी इच्छित कॉलम संख्या निर्दिष्ट कर सकते हैं। 

यह जावा कोड दिखाता है कि टेक्स्ट फ्रेम के भीतर एक कॉलम कैसे जोड़ा जाए:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेक्स्ट अपडेट करें**

Aspose.Slides आपको टेक्स्ट बॉक्स में मौजूद टेक्स्ट या पूरी प्रेजेंटेशन में सभी टेक्स्ट को बदलने या अपडेट करने की अनुमति देता है। 

यह जावा कोड दिखाता है कि कैसे एक प्रेजेंटेशन में सभी टेक्स्ट को अपडेट या बदलें:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //जाँचता है कि शैप टेक्स्ट फ्रेम (IAutoShape) को सपोर्ट करता है।
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //टेक्स्ट फ्रेम में पैराग्राफों पर इटरेट करता है
                {
                    for (IPortion portion : paragraph.getPortions()) //पैराग्राफ में प्रत्येक पोर्शन पर इटरेट करता है
                    {
                        portion.setText(portion.getText().replace("years", "months")); //टेक्स्ट बदलता है
                        portion.getPortionFormat().setFontBold(NullableBool.True); //फ़ॉर्मेटिंग बदलता है
                    }
                }
            }
        }
    }

    //संशोधित प्रस्तुति को सहेजता है
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ें** 

आप टेक्स्ट बॉक्स के भीतर एक लिंक सम्मिलित कर सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो उपयोगकर्ता उस लिंक को खोलने के लिए निर्देशित होते हैं। 

एक लिंक वाला टेक्स्ट बॉक्स जोड़ने के लिए इन चरणों का पालन करें:

1. `Presentation` क्लास की एक इंस्‍टेंस बनाएँ। 
2. नई बनाई गई प्रेजेंटेशन की पहली स्लाइड के लिए रेफ़रेंस प्राप्त करें। 
3. स्लाइड पर निर्दिष्ट स्थिति पर `ShapeType` को `Rectangle` सेट करके एक `AutoShape` ऑब्जेक्ट जोड़ें और नए जोड़े गये AutoShape ऑब्जेक्ट का रेफ़रेंस प्राप्त करें। 
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें जिसमें डिफ़ॉल्ट टेक्स्ट *Aspose TextBox* हो। 
5. `IHyperlinkManager` क्लास की एक इंस्टेंस बनाएँ। 
6. `IHyperlinkManager` ऑब्जेक्ट को उस `TextFrame` के इच्छित भाग से संबंधित [HyperlinkClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Shape#getHyperlinkClick--) प्रॉपर्टी को असाइन करें। 
7. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

यह जावा कोड—उपरोक्त चरणों का इम्प्लीमेंटेशन—दिखाता है कि स्लाइड में हाइपरलिंक के साथ टेक्स्ट बॉक्स कैसे जोड़ें:

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // प्रकार को Rectangle सेट करके एक AutoShape ऑब्जेक्ट जोड़ता है
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // शेप को AutoShape में कास्ट करता है
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShape से जुड़े ITextFrame प्रॉपर्टी तक पहुँचता है
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // फ़्रेम में कुछ टेक्स्ट जोड़ता है
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // पोर्शन टेक्स्ट के लिए हाइपरलिंक सेट करता है
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // PPTX प्रस्तुति को सहेजता है
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड्स के साथ काम करते समय टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/java/manage-placeholder/) [मास्टर](https://reference.aspose.com/slides/hi/java/com.aspose.slides/masterslide/) से शैली/स्थिति विरासत में लेता है और इसे [लेआउट्स](https://reference.aspose.com/slides/hi/java/com.aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि एक सामान्य टेक्स्ट बॉक्स विशिष्ट स्लाइड पर स्वतंत्र ऑब्जेक्ट है और लेआउट बदलने पर नहीं बदलता। 

**मैं प्रेजेंटेशन में चार्ट्स, टेबल्स और SmartArt के अंदर के टेक्स्ट को छुए बिना टेक्स्ट का बल्क रिप्लेसमेंट कैसे करूँ?**

ऑटो‑शैप्स जिनके पास टेक्स्ट फ्रेम हैं, उन्हें ही इटरेट करें और एम्बेडेड ऑब्जेक्ट्स ([चार्ट्स](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/), [टेबल्स](https://reference.aspose.com/slides/hi/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/smartart/)) को उनके संग्रहों को अलग‑अलग ट्रैवर्स करके या उन ऑब्जेक्ट प्रकारों को स्किप करके बाहर रखें।