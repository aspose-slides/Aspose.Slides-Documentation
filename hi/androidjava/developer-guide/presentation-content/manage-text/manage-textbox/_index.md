---
title: Android पर प्रेज़ेंटेशन में टेक्स्ट बॉक्स प्रबंधित करें
linktitle: टेक्स्ट बॉक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/androidjava/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ्रेम
- टेक्स्ट जोड़ें
- टेक्स्ट अपडेट करें
- टेक्स्ट बॉक्स बनाएं
- टेक्स्ट बॉक्स जाँचें
- टेक्स्ट कॉलम जोड़ें
- हाइपरलिंक जोड़ें
- PowerPoint
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java PowerPoint और OpenDocument फाइलों में टेक्स्ट बॉक्स बनाने, संपादित करने और क्लोन करने को आसान बनाता है, जिससे आपकी प्रेज़ेंटेशन ऑटोमेशन सुधरती है।"
---
## **परिचय**

स्लाइडों पर टेक्स्ट आमतौर पर टेक्स्ट बॉक्स या आकारों में मौजूद होते हैं। इसलिए, स्लाइड में टेक्स्ट जोड़ने के लिए आपको एक टेक्स्ट बॉक्स जोड़ना होता है और फिर उस टेक्स्ट बॉक्स में कुछ टेक्स्ट डालना होता है। Aspose.Slides for Android via Java प्रदान करता है [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) इंटरफ़ेस जो आपको टेक्स्ट वाला आकार जोड़ने की अनुमति देता है।

{{% alert title="सूचना" color="info" %}}
Aspose.Slides भी [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape) इंटरफ़ेस प्रदान करता है जो स्लाइड में आकार जोड़ने की अनुमति देता है। हालांकि, `IShape` इंटरफ़ेस के माध्यम से जोड़े गए सभी आकार टेक्स्ट रख नहीं सकते। लेकिन [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) इंटरफ़ेस के माध्यम से जोड़े गए आकारों में टेक्स्ट हो सकता है।
{{% /alert %}}

{{% alert title="नोट" color="warning" %}} 
इसलिए, जब आप ऐसे आकार के साथ काम कर रहे हों जिसमें आप टेक्स्ट जोड़ना चाहते हैं, तो आपको यह जांचना और पुष्टि करना चाहिए कि वह `IAutoShape` इंटरफ़ेस के माध्यम से कास्ट किया गया था। तभी आप [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TextFrame) के साथ काम कर पाएंगे, जो `IAutoShape` के अंतर्गत एक प्रॉपर्टी है। इस पृष्ठ के [Update Text](https://docs.aspose.com/slides/hi/androidjava/manage-textbox/#update-text) अनुभाग को देखें।
{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाएं**

स्लाइड पर एक टेक्स्ट बॉक्स बनाने के लिए इन चरणों का पालन करें:

1. `[Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation)` क्लास की एक इंस्टेंस बनाएं।  
2. नए बनाए गए प्रेजेंटेशन में पहले स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड पर निर्दिष्ट स्थान पर `Rectangle` के रूप में सेट किए गए `ShapeType` के साथ एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAutoShape) ऑब्जेक्ट जोड़ें और नए जोड़े गए `IAutoShape` ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।  
4. `IAutoShape` ऑब्जेक्ट में `TextFrame` प्रॉपर्टी जोड़ें जो टेक्स्ट रखेगी। नीचे के उदाहरण में हमने यह टेक्स्ट जोड़ा है: *Aspose TextBox*  
5. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें।  

यह Java कोड—ऊपर बताए गए चरणों का कार्यान्वयन—आपको दिखाता है कि स्लाइड में टेक्स्ट कैसे जोड़ें:

```java
import com.aspose.slides.*;

// प्रेजेंटेशन का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);

    // प्रकार को Rectangle सेट करके एक AutoShape जोड़ता है
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle में TextFrame जोड़ता है
    ashp.addTextFrame(" ");

    // टेक्स्ट फ्रेम को एक्सेस करता है
    ITextFrame txtFrame = ashp.getTextFrame();

    // टेक्स्ट फ्रेम के लिए Paragraph ऑब्जेक्ट बनाता है
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // पैराग्राफ के लिए Portion ऑब्जेक्ट बनाता है
    IPortion portion = para.getPortions().get_Item(0);

    // टेक्स्ट सेट करता है
    portion.setText("Aspose TextBox");

    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेक्स्ट बॉक्स आकार की जाँच करें**

Aspose.Slides प्रदान करता है [isTextBox](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/#isTextBox--) मेथड को [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) इंटरफ़ेस से, जिससे आप आकारों का निरीक्षण करके टेक्स्ट बॉक्स पहचान सकते हैं।

![Text box and shape](istextbox.png)

यह Java कोड दिखाता है कि कैसे जाँचें कि कोई आकार टेक्स्ट बॉक्स के रूप में बनाया गया था या नहीं: 

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

ध्यान दें कि यदि आप सिर्फ़ `addAutoShape` मेथड का उपयोग करके [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/) इंटरफ़ेस से एक ऑटोशेप जोड़ते हैं, तो उस ऑटोशेप का `isTextBox` मेथड `false` लौटाएगा। हालाँकि, जब आप `addTextFrame` मेथड या `setText` मेथड से ऑटोशेप में टेक्स्ट जोड़ते हैं, तो `isTextBox` प्रॉपर्टी `true` लौटाएगी।

```java
import com.aspose.slides.*;

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

## **टेक्स्ट फ्रेम का स्वामी आकार खोजें**

सामान्य टेक्स्ट-प्रोसेसिंग कोड में, आपको कोई [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) प्राप्त हो सकता है बिना यह जाने कि कौन सा प्रेजेंटेशन ऑब्जेक्ट उसे रखता है। `[ITextFrame.getParentShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentShape--)` मेथड का उपयोग करके आप मालिक `[IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/)` तक वापस नेविगेट कर सकते हैं।

एक टेक्स्ट फ्रेम जो एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) या किसी अन्य टेक्स्ट‑वाला आकार का हिस्सा है, `[ITextFrame.getParentShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentShape--)` मालिक को लौटाता है और `[ITextFrame.getParentCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/#getParentCell--)` `null`। दोनों मेथड केवल रीड‑ओनली नेविगेशन प्रदान करते हैं, इसलिए उन्हें कॉल करने से स्वामित्व नहीं बदलता। हमेशा श shape को एक्सेस करने से पहले लौटाए गए मान को `null` के लिये जांचें।

एक पूर्ण उदाहरण जो आकार और टेबल‑सेल मालिकों को पहचानता है, जिसमें SmartArt नोड्स से जुड़े आकार भी शामिल हैं, के लिये देखें [Search and Replace Text](/slides/hi/androidjava/search-and-replace-text/)।

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

Aspose.Slides प्रदान करता है [ColumnCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) और [ColumnSpacing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) प्रॉपर्टीज़ (`ITextFrameFormat` इंटरफ़ेस और `TextFrameFormat` क्लास से) जो आपको टेक्स्ट बॉक्स में कॉलम जोड़ने की अनुमति देती हैं। आप टेक्स्ट बॉक्स में कॉलम की संख्या निर्दिष्ट कर सकते हैं और कॉलमों के बीच स्पेसिंग पॉइंट्स में सेट कर सकते हैं।

यह Java कोड वर्णित ऑपरेशन को दर्शाता है: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // प्रकार को Rectangle सेट करके एक AutoShape जोड़ता है
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

    // कॉलमों के बीच स्पेसिंग निर्दिष्ट करता है
    format.setColumnSpacing(10);

    // प्रेजेंटेशन को सहेजता है
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टेक्स्ट फ्रेम में कॉलम जोड़ें**
Aspose.Slides for Android via Java प्रदान करता है [ColumnCount](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) प्रॉपर्टी (`ITextFrameFormat` इंटरफ़ेस से) जो आपको टेक्स्ट फ्रेम में कॉलम जोड़ने की अनुमति देती है। इस प्रॉपर्टी के माध्यम से आप टेक्स्ट फ्रेम में वांछित कॉलम संख्या निर्दिष्ट कर सकते हैं।

यह Java कोड दिखाता है कि कैसे टेक्स्ट फ्रेम के भीतर एक कॉलम जोड़ा जाए:

```java
import com.aspose.slides.*;

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
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
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
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
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

Aspose.Slides आपको टेक्स्ट बॉक्स में उपस्थित टेक्स्ट या पूरी प्रेजेंटेशन में मौजूद सभी टेक्स्ट को बदलने या अपडेट करने की अनुमति देता है। 

यह Java कोड एक ऑपरेशन को दर्शाता है जहाँ प्रेजेंटेशन में सभी टेक्स्ट अपडेट या बदल दिए जाते हैं:

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
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //टेक्स्ट फ्रेम में पैराग्राफ़ों के माध्यम से इटरैट करता है
                {
                    for (IPortion portion : paragraph.getPortions()) //पैराग्राफ में प्रत्येक भाग के माध्यम से इटरैट करता है
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

## **हाइपरलिंक वाला टेक्स्ट बॉक्स जोड़ें** 

आप टेक्स्ट बॉक्स के अंदर एक लिंक डाल सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो उपयोगकर्ता लिंक खोलने के लिए निर्देशित होते हैं। 

लिंक वाला टेक्स्ट बॉक्स जोड़ने के लिए इन चरणों का पालन करें:

1. `Presentation` क्लास की एक इंस्टेंस बनाएं।  
2. नए बनाए गए प्रेजेंटेशन में पहले स्लाइड का रेफ़रेंस प्राप्त करें।  
3. `ShapeType` को `Rectangle` सेट करके निर्दिष्ट स्थान पर एक `AutoShape` ऑब्जेक्ट जोड़ें और नए जोड़े गए AutoShape ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।  
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें और उसके पहले भाग का टेक्स्ट सेट करें। नीचे के उदाहरण में हमने यह टेक्स्ट उपयोग किया: *Aspose.Slides*  
5. अपने इच्छित `TextFrame` के भाग की `PortionFormat` से [IHyperlinkManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkmanager/) ऑब्जेक्ट प्राप्त करें।  
6. उस ऑब्जेक्ट पर [setExternalHyperlinkClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) को कॉल करके वह लिंक सेट करें जो टेक्स्ट क्लिक होने पर खुलेगा।  
7. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

यह Java कोड—ऊपर बताए गए चरणों का कार्यान्वयन—आपको दिखाता है कि कैसे स्लाइड में हाइपरलिंक वाला टेक्स्ट बॉक्स जोड़ा जाए:

```java
import com.aspose.slides.*;

// PPTX का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टेंस बनाता है
Presentation pres = new Presentation();
try {
    // प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.getSlides().get_Item(0);

    // प्रकार को Rectangle सेट करके AutoShape ऑब्जेक्ट जोड़ता है
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // shape को AutoShape में कास्ट करता है
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // AutoShape से संबंधित ITextFrame प्रॉपर्टी को एक्सेस करता है
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // फ्रेम में कुछ टेक्स्ट जोड़ता है
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // portion टेक्स्ट के लिए हाइपरलिंक सेट करता है
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // PPTX प्रेजेंटेशन को सहेजता है
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड्स के साथ काम करते समय टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/androidjava/manage-placeholder/) शैली/स्थिति को **master** से विरासत में लेता है और इसे **layouts** पर ओवरराइड किया जा सकता है, जबकि एक सामान्य टेक्स्ट बॉक्स विशेष स्लाइड पर एक स्वतंत्र ऑब्जेक्ट है और लेआउट बदलने पर नहीं बदलता।

**मैं प्रेजेंटेशन में चार्ट, टेबल और SmartArt के अंदर के टेक्स्ट को छुए बिना बड़े पैमाने पर टेक्स्ट प्रतिस्थापन कैसे कर सकता हूँ?**

ऑटो‑शेप्स जिनके पास टेक्स्ट फ्रेम है, उन तक ही इटरेशन को सीमित रखें और एम्बेडेड ऑब्जेक्ट्स ([charts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/smartart/)) को उनके संग्रह अलग‑से ट्रैवर्स करके या उन प्रकार के ऑब्जेक्ट्स को स्किप करके बाहर रखें।