---
title: एन्ड्रॉइड पर प्रस्तुति आकार प्रबंधित करें
linktitle: आकार संचालन
type: docs
weight: 40
url: /hi/androidjava/shape-manipulations/
keywords:
- PowerPoint आकार
- प्रेजेंटेशन आकार
- स्लाइड पर आकार
- आकार खोजें
- आकार क्लोन करें
- आकार हटाएँ
- आकार छुपाएँ
- आकार क्रम बदलें
- Interop आकार ID प्राप्त करें
- आकार वैकल्पिक पाठ
- आकार लेआउट फ़ॉर्मेट्स
- आकार SVG के रूप में
- आकार को SVG में
- आकार संरेखित करें
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java में आकार बनाना, संपादित करना और अनुकूलित करना सीखें और उच्च‑प्रदर्शन PowerPoint प्रस्तुतियां प्रदान करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों में आकार (shapes) के साथ काम करने का तरीका बताता है। यह दिखाता है कि स्लाइड पर किसी आकार को कैसे खोजें, उसे क्लोन करें, हटाएँ, छुपाएँ, क्रम बदलें, उसका Interop shape ID प्राप्त करें, और पहचान एवं आगे की प्रोसेसिंग के लिए वैकल्पिक पाठ (alternative text) सेट करें।

यह आकारों के लिए लेआउट फ़ॉर्मेट्स तक पहुँच, आकार को SVG के रूप में रेंडर करना, स्लाइड पर आकारों को संरेखित करना, तथा क्षैतिज और लंबवत मिररिंग के लिए फ़्लिप प्रॉपर्टीज़ का उपयोग कैसे करें, को भी कवर करता है। इसके अतिरिक्त, लेख में आकार संयोजन, स्टैकिंग क्रम, और आकार लॉकिंग के बारे में एक छोटा FAQ शामिल है।

## **स्लाइड पर आकार खोजें**
यह विषय एक सरल तकनीक का वर्णन करेगा जिससे डेवलपर्स को स्लाइड पर किसी विशिष्ट आकार को उसकी आंतरिक Id का उपयोग किए बिना खोजने में आसानी होगी। यह जानना महत्वपूर्ण है कि PowerPoint प्रस्तुतियों में स्लाइड पर आकारों की पहचान करने का कोई साधन नहीं है सिवाय एक आंतरिक अद्वितीय Id के। डेवलपर्स के लिए आंतरिक अद्वितीय Id का उपयोग करके आकार ढूँढना कठिन हो सकता है। सभी स्लाइड पर जोड़े गए आकारों में कुछ Alt Text होता है। हम डेवलपर्स को विशिष्ट आकार खोजने के लिए वैकल्पिक पाठ (alternative text) उपयोग करने की सलाह देते हैं। आप भविष्य में बदलने की योजना वाले ऑब्जेक्ट्स के लिए वैकल्पिक पाठ Microsoft PowerPoint में परिभाषित कर सकते हैं।

किसी इच्छित आकार का वैकल्पिक पाठ सेट करने के बाद, आप Aspose.Slides for Android via Java का उपयोग करके वह प्रस्तुति खोल सकते हैं और स्लाइड में जोड़े गए सभी आकारों के माध्यम से इटररेट कर सकते हैं। प्रत्येक इटरशन में आप आकार के वैकल्पिक पाठ की जाँच कर सकते हैं और मिलते‑जुलते वैकल्पिक पाठ वाला आकार वही होगा जिसकी आपको आवश्यकता है। इस तकनीक को बेहतर ढंग से प्रदर्शित करने के लिए हमने एक मेथड, [findShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) बनाया है जो स्लाइड में विशिष्ट आकार खोजता है और फिर उस आकार को लौटाता है।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // खोजे जाने वाले आकार का वैकल्पिक पाठ
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// वैकल्पिक पाठ का उपयोग करके स्लाइड में आकार खोजने की मेथड कार्यान्वयन
public static IShape findShape(ISlide slide, String alttext)
{
    // स्लाइड के भीतर सभी आकारों पर इटरशन
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // यदि स्लाइड का वैकल्पिक पाठ आवश्यक वाले से मेल खाता है तो
        // आकार लौटाएँ
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **एक आकार क्लोन करें**
Aspose.Slides for Android via Java का उपयोग करके स्लाइड पर एक आकार को क्लोन करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. उसके इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्रोत स्लाइड के shape collection तक पहुँचें।
1. प्रस्तुति में एक नई स्लाइड जोड़ें।
1. स्रोत स्लाइड के shape collection से नई स्लाइड में आकार क्लोन करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे का उदाहरण एक समूह आकार (group shape) को स्लाइड में जोड़ता है।

```java
// Presentation क्लास का इंस्टैंस बनाएं
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एक आकार हटाएँ**
Aspose.Slides for Android via Java डेवलपर्स को किसी भी आकार को हटाने की अनुमति देता है। किसी स्लाइड से आकार हटाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. विशिष्ट AlternativeText वाले आकार को खोजें।
1. आकार को हटाएँ।
1. फ़ाइल को डिस्क पर सहेजें।

```java
// Presentation ऑब्जेक्ट बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // आयत प्रकार का ऑटोशेप जोड़ें
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // प्रस्तुति को डिस्क पर सहेजें
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एक आकार छुपाएँ**
Aspose.Slides for Android via Java डेवलपर्स को किसी भी आकार को छुपाने की अनुमति देता है। किसी स्लाइड से आकार छुपाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. विशिष्ट AlternativeText वाले आकार को खोजें।
1. आकार को छुपाएँ।
1. फ़ाइल को डिस्क पर सहेजें।

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // आयत प्रकार का ऑटोशेप जोड़ें
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // प्रेज़ेंटेशन को डिस्क पर सहेजें
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **आकार का क्रम बदलें**
Aspose.Slides for Android via Java डेवलपर्स को आकारों के क्रम को पुनः व्यवस्थित करने की सुविधा देता है। क्रम बदलने से यह निर्धारित होता है कि कौन‑सा आकार सामने है और कौन‑सा पीछे। किसी स्लाइल्ड से आकार का क्रम बदलने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. एक आकार जोड़ें।
1. आकार के टेक्स्ट फ्रेम में कुछ पाठ डालें।
1. समान निर्देशांक (coordinates) वाले एक और आकार जोड़ें।
1. आकारों के क्रम को बदलें।
1. फ़ाइल को डिस्क पर सहेजें।

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Interop Shape ID प्राप्त करें**
Aspose.Slides for Android via Java डेवलपर्स को स्लाइड स्तर पर अद्वितीय आकार पहचानकर्ता (unique shape identifier) प्राप्त करने की अनुमति देता है, जो [getUniqueId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#getUniqueId--) मेथड के विपरीत है, जो प्रस्तुति स्तर पर अद्वितीय पहचानकर्ता देता है। मेथड [getOfficeInteropShapeId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) को [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape) इंटरफ़ेस और [Shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Shape) क्लास में जोड़ा गया है। [getOfficeInteropShapeId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) मेथड द्वारा लौटाया गया मान Microsoft.Office.Interop.PowerPoint.Shape ऑब्जेक्ट के Id के मान के अनुरूप है। नीचे एक नमूना कोड दिया गया है।

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // स्लाइड स्तर में अद्वितीय आकार पहचानकर्ता प्राप्त करना
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **एक आकार के लिए वैकल्पिक पाठ सेट करें**
Aspose.Slides for Android via Java डेवलपर्स को किसी भी आकार का AlternateText सेट करने की अनुमति देता है। प्रस्तुतियों में आकारों को [AlternativeText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) या [Shape Name](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#setName-java.lang.String-) मेथड द्वारा पहचाना जा सकता है। [setAlternativeText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) और [getAlternativeText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#getAlternativeText--) मेथड को Aspose.Slides के साथ-साथ Microsoft PowerPoint द्वारा पढ़ा या सेट किया जा सकता है। इस मेथड का उपयोग करके आप एक आकार को टैग कर सकते हैं और विभिन्न ऑपरेशंस जैसे आकार हटाना, आकार छुपाना या स्लाइड पर आकारों को पुनः क्रमबद्ध करना कर सकते हैं। आकार का AlternateText सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. स्लाइड में कोई भी आकार जोड़ें।
1. नए जोड़े गए आकार के साथ कुछ कार्य करें।
1. आकारों के माध्यम से इटररेट कर इच्छित आकार खोजें।
1. AlternativeText सेट करें।
1. फ़ाइल को डिस्क पर सहेजें।

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    ISlide sld = pres.getSlides().get_Item(0);

    // आयत प्रकार का ऑटोशेप जोड़ें
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // प्रेज़ेंटेशन को डिस्क पर सहेजें
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **एक आकार के लिए लेआउट फ़ॉर्मेट्स तक पहुँचें**
Aspose.Slides for Android via Java आकारों के लेआउट फ़ॉर्मेट्स तक पहुँचने के लिए एक सरल API प्रदान करता है। यह लेख दर्शाता है कि आप लेआउट फ़ॉर्मेट्स कैसे प्राप्त कर सकते हैं।

नीचे नमूना कोड दिया गया है।

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **एक आकार को SVG के रूप में रेंडर करें**
अब Aspose.Slides for Android via Java आकार को SVG के रूप में रेंडर करने का समर्थन करता है। मेथड [writeAsSvg](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (और इसका ओवरलोड) को [Shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Shape) क्लास और [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape) इंटरफ़ेस में जोड़ा गया है। यह मेथड आकार की सामग्री को SVG फ़ाइल के रूप में सहेजने की अनुमति देता है। नीचे कोड स्निपेट दिखाता है कि स्लाइड के आकार को SVG फ़ाइल में कैसे एक्सपोर्ट करें।

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **एक आकार को संरेखित (Align) करें**
Aspose.Slides आकारों को स्लाइड मार्जिन के सापेक्ष या आपस में संरेखित करने की सुविधा देता है। इसके लिए ओवरलोडेड मेथड [SlidesUtil.alignShape()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) जोड़ा गया है। enum [ShapesAlignmentType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ShapesAlignmentType) संभावित संरेखण विकल्पों को परिभाषित करता है।

**Example 1**

नीचे का स्रोत कोड इंडेक्स 1,2 और 4 वाले आकारों को स्लाइड की शीर्ष सीमा के साथ संरेखित करता है।

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**Example 2**

नीचे का उदाहरण दर्शाता है कि संपूर्ण आकार संग्रह को संग्रह में सबसे निचले आकार के सापेक्ष कैसे संरेखित किया जाए।

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **फ़्लिप प्रॉपर्टीज़**

Aspose.Slides में, क्लास [ShapeFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapeframe/) आकारों के क्षैतिज और लंबवत मिररिंग को उनके `flipH` और `flipV` प्रॉपर्टीज़ के माध्यम से नियंत्रित करता है। दोनों प्रॉपर्टीज़ `byte` प्रकार की हैं, जहाँ `1` का अर्थ फ्लिप, `0` का अर्थ कोई फ्लिप नहीं, और `-1` का अर्थ डिफ़ॉल्ट व्यवहार का उपयोग करना है। ये मान उस आकार के [Frame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getFrame--) से प्राप्त किए जाते हैं।

फ़्लिप सेटिंग्स को बदलने के लिए, एक नया [ShapeFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapeframe/) इंस्टेंस वर्तमान स्थिति और आकार, वांछित `flipH` और `flipV` मान, तथा घुमाव (rotation) कोण के साथ बनाया जाता है। इस इंस्टेंस को आकार के [Frame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getFrame--) में असाइन करें और प्रस्तुति को सहेजें; इससे मिरर परिवर्तन लागू हो जाएंगे और आउटपुट फ़ाइल में प्रतिबिंबित होंगे।

मान लीजिए हमारे पास sample.pptx फ़ाइल है जहाँ पहली स्लाइड में एक ही आकार है जिसके डिफ़ॉल्ट फ़्लिप सेटिंग्स नीचे दिखाए गए हैं।

![The shape to be flipped](shape_to_be_flipped.png)

निम्न कोड उदाहरण आकार की वर्तमान फ़्लिप प्रॉपर्टीज़ प्राप्त करता है और उसे क्षैतिज तथा लंबवत दोनों ओर फ़्लिप करता है।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // आकार की क्षैतिज फ़्लिप प्रॉपर्टी प्राप्त करें।
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // आकार की ऊर्ध्वाधर फ़्लिप प्रॉपर्टी प्राप्त करें।
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // क्षैतिज रूप से फ़्लिप करें।
    byte flipV = NullableBool.True; // क्षैतिज रूप से फ़्लिप करें।
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The flipped shape](flipped_shape.png)

## **FAQ**

**क्या मैं स्लाइड पर आकारों को (union/intersect/subtract) डेस्कटॉप एडिटर की तरह जोड़ सकता हूँ?**

बिल्ट‑इन बूलियन ऑपरेशन API उपलब्ध नहीं है। आप इच्छित रूपरेखा स्वयं बनाकर—उदाहरण के लिए, परिणामस्वरूप ज्योमेट्री को [GeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/geometrypath/) से गणना करके और उस कंटूर के साथ नया आकार बनाकर—लगभग वही प्रभाव प्राप्त कर सकते हैं, तथा मूल आकारों को वैकल्पिक रूप से हटा सकते हैं।

**मैं स्टैकिंग क्रम (z‑order) कैसे नियंत्रित करूँ ताकि कोई आकार हमेशा “ऊपर” रहे?**

स्लाइड की [shapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslide/#getShapes--) संग्रह में इन्सर्शन/मूव क्रम बदलें। पूर्वानुमेय परिणामों के लिए सभी अन्य स्लाइड संशोधनों के बाद z‑order को अंतिम रूप दें।

**क्या मैं PowerPoint में उपयोगकर्ताओं को आकार संपादित करने से रोकने के लिए उसे “लॉक” कर सकता हूँ?**

हाँ। आकार‑स्तर के प्रोटेक्शन फ़्लैग सेट करें (जैसे चयन, मूवमेंट, री‑साइज़, टेक्स्ट संपादन को लॉक करना)। यदि आवश्यक हो तो मास्टर या लेआउट पर प्रतिबंध भी लागू करें। यह UI‑स्तर की सुरक्षा है, न कि फ़ाइल‑स्तर की; मजबूत सुरक्षा के लिए फ़ाइल‑स्तर प्रतिबंध जैसे [read‑only सिफ़ारिशें या पासवर्ड](/slides/hi/androidjava/password-protected-presentation/) के साथ संयोजन करें।