---
title: Android पर प्रस्तुतियों में टेक्स्ट बॉक्स प्रबंधन
linktitle: टेक्स्ट बॉक्स प्रबंधन
type: docs
weight: 20
url: /hi/androidjava/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ्रेम
- टेक्स्ट जोड़ें
- टेक्स्ट अपडेट करें
- टेक्स्ट बॉक्स बनाएं
- टेक्स्ट बॉक्स जांचें
- टेक्स्ट कॉलम जोड़ें
- हाइपरलिंक जोड़ें
- पावरपॉइंट
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android via Java पावरपॉइंट और OpenDocument फ़ाइलों में टेक्स्ट बॉक्स को बनाना, संपादित करना और क्लोन करना आसान बनाता है, जिससे आपकी प्रस्तुतियों का स्वचालन बेहतर होता है।"
---
## **परिचय**

स्लाइड पर टेक्स्ट आमतौर पर टेक्स्ट बॉक्स या शैप्स में होते हैं। इसलिए, स्लाइड में टेक्स्ट जोड़ने के लिए आपको एक टेक्स्ट बॉक्स जोड़ना होगा और फिर उस बॉक्स के भीतर टेक्स्ट डालना होगा। Aspose.Slides for Android via Java [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) इंटरफ़ेस प्रदान करता है जो आपको टेक्स्ट वाला शैप जोड़ने की अनुमति देता है।

{{% alert title="Info" color="info" %}}
Aspose.Slides additionally [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape) इंटरफ़ेस प्रदान करता है जो आपको स्लाइड में शैप्स जोड़ने की अनुमति देता है। हालांकि, `IShape` इंटरफ़ेस के माध्यम से जोड़े गए सभी शैप्स में टेक्स्ट नहीं हो सकता। लेकिन [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) इंटरफ़ेस के माध्यम से जोड़े गए शैप्स में टेक्स्ट हो सकता है।
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
इसलिए, जब आप किसी ऐसे शैप से निपट रहे हैं जिसमें आप टेक्स्ट जोड़ना चाहते हैं, तो आपको यह जांचना और पुष्टि करना चाहिए कि वह `IAutoShape` इंटरफ़ेस के माध्यम से कास्ट किया गया है। तभी आप [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TextFrame) के साथ काम कर पाएंगे, जो `IAutoShape` की एक प्रॉपर्टी है। इस पृष्ठ पर [Update Text](https://docs.aspose.com/slides/hi/androidjava/manage-textbox/#update-text) सेक्शन देखें।
{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाएं**

स्लाइड पर एक टेक्स्ट बॉक्स बनाने के लिए, इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. नए बनाए गए प्रेजेंटेशन में पहली स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड पर निर्दिष्ट स्थान पर `Rectangle` के रूप में सेट किए गए [ShapeType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) के साथ एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) ऑब्जेक्ट जोड़ें और नए जोड़े गए `IAutoShape` ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
4. `IAutoShape` ऑब्जेक्ट में `TextFrame` प्रॉपर्टी जोड़ें जो टेक्स्ट रखेगा। नीचे के उदाहरण में, हमने यह टेक्स्ट जोड़ा: *Aspose TextBox*
5. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

```java
// Presentation को इंस्टैंसिएट करता है
Presentation pres = new Presentation();
try {
    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);

    // Rectangle के रूप में सेट टाइप के साथ एक AutoShape जोड़ता है
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

## **टेक्स्ट बॉक्स शैप की जांच करें**

Aspose.Slides [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) इंटरफ़ेस से [isTextBox](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#isTextBox--) मेथड प्रदान करता है, जिससे आप शैप्स की जाँच कर टेक्स्ट बॉक्स पहचान सकते हैं।

![टेक्स्ट बॉक्स और शैप](istextbox.png)

यह Java कोड दिखाता है कि कैसे जांचें कि कोई शैप टेक्स्ट बॉक्स के रूप में बनाया गया है या नहीं: 

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

ध्यान दें कि यदि आप केवल [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/) इंटरफ़ेस के `addAutoShape` मेथड से एक ऑटोशैप जोड़ते हैं, तो उस ऑटोशैप की `isTextBox` मेथड `false` लौटाएगी। हालांकि, जब आप `addTextFrame` मेथड या `setText` मेथड से ऑटोशैप में टेक्स्ट जोड़ते हैं, तो `isTextBox` प्रॉपर्टी `true` लौटाती है।

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

Aspose.Slides [ColumnCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) और [ColumnSpacing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) प्रॉपर्टीज़ (जो [ITextFrameFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrameFormat) इंटरफ़ेस और [TextFrameFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TextFrameFormat) क्लास से आती हैं) प्रदान करता है जो आपको टेक्स्ट बॉक्स में कॉलम जोड़ने की अनुमति देती हैं। आप टेक्स्ट बॉक्स में कॉलमों की संख्या निर्दिष्ट कर सकते हैं और कॉलमों के बीच पॉइंट्स में स्पेसिंग सेट कर सकते हैं।

```java
Presentation pres = new Presentation();
try {
    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle के रूप में टाइप सेट किए हुए एक AutoShape जोड़ता है
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

    // कॉलमों के बीच के अंतराल को निर्दिष्ट करता है
    format.setColumnSpacing(10);

    // प्रस्तुति को सहेजता है
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेक्स्ट फ्रेम में कॉलम जोड़ें**
Aspose.Slides for Android via Java [ColumnCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) प्रॉपर्टी (जो [ITextFrameFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrameFormat) इंटरफ़ेस से आती है) प्रदान करता है जिससे आप टेक्स्ट फ्रेम में कॉलम जोड़ सकते हैं। इस प्रॉपर्टी के माध्यम से आप टेक्स्ट फ्रेम में अपनी वांछित कॉलम संख्या निर्दिष्ट कर सकते हैं।

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

Aspose.Slides आपको टेक्स्ट बॉक्स में मौजूद टेक्स्ट या प्रस्तुति में मौजूद सभी टेक्स्ट को बदलने या अपडेट करने की अनुमति देता है।

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //जाँच करता है कि शैप टेक्स्ट फ्रेम (IAutoShape) का समर्थन करता है।
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //टेक्स्ट फ्रेम में पैराग्राफ़ों पर इटररेट करता है
                {
                    for (IPortion portion : paragraph.getPortions()) //पैराग्राफ़ में प्रत्येक पोर्शन पर इटररेट करता है
                    {
                        portion.setText(portion.getText().replace("years", "months")); //टेक्स्ट बदलता है
                        portion.getPortionFormat().setFontBold(NullableBool.True); //फ़ॉर्मेट बदलता है
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

आप टेक्स्ट बॉक्स के भीतर एक लिंक डाल सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो उपयोगकर्ता लिंक खोलने के लिए निर्देशित होते हैं। 

 टेक्स्ट बॉक्स जिसमें लिंक हो, जोड़ने के लिए इन चरणों का पालन करें:

1. `Presentation` क्लास का एक इंस्टेंस बनाएँ। 
2. नए बनाए गए प्रेजेंटेशन में पहली स्लाइड का रेफ़रेंस प्राप्त करें। 
3. स्लाइड पर निर्दिष्ट स्थान पर `Rectangle` के रूप में `ShapeType` सेट किए गए `AutoShape` ऑब्जेक्ट को जोड़ें और नए जोड़े गए AutoShape ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें जिसमें डिफ़ॉल्ट टेक्स्ट *Aspose TextBox* हो। 
5. `IHyperlinkManager` क्लास का एक इंस्टेंस बनाएँ। 
6. `IHyperlinkManager` ऑब्जेक्ट को [HyperlinkClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) प्रॉपर्टी असाइन करें जो आपके `TextFrame` के इच्छित हिस्से से जुड़ी है।
7. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाता है
Presentation pres = new Presentation();
try {
    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // टाइप को Rectangle सेट करके एक AutoShape ऑब्जेक्ट जोड़ता है
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // शेप को AutoShape में कास्ट करता है
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShape से जुड़ी ITextFrame प्रॉपर्टी तक पहुंचता है
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // फ़्रेम में कुछ टेक्स्ट जोड़ता है
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // पोर्टियन टेक्स्ट के लिए हाइपरलिंक सेट करता है
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

एक [placeholder](/slides/hi/androidjava/manage-placeholder/) [master](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/masterslide/) से शैली/स्थिति को विरासत में प्राप्त करता है और [layouts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि एक सामान्य टेक्स्ट बॉक्स एक विशेष स्लाइड पर स्वतंत्र ऑब्जेक्ट होता है और लेआउट बदलने पर नहीं बदलता।

**मैं चार्ट, टेबल और SmartArt के भीतर टेक्स्ट को छुए बिना पूरी प्रस्तुति में एक बड़ी टेक्स्ट प्रतिस्थापना कैसे कर सकता हूँ?**

अपनी इटरेशन को केवल उन ऑटो-शैप्स तक सीमित रखें जिनमें टेक्स्ट फ्रेम हों और एम्बेडेड ऑब्जेक्ट्स ([charts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/smartart/)) को अलग-अलग कलेक्शनों को पार करके या उन ऑब्जेक्ट प्रकारों को छोड़कर बाहर रखें।