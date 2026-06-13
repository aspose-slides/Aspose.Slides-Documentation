---
title: Java में प्रेज़ेंटेशन आकारों का प्रबंधन
linktitle: आकार परिवर्तन
type: docs
weight: 40
url: /hi/java/shape-manipulations/
keywords:
- PowerPoint आकार
- प्रेज़ेंटेशन आकार
- स्लाइड पर आकार
- आकार खोजें
- आकार क्लोन करें
- आकार हटाएँ
- आकार छुपाएँ
- आकार क्रम बदलें
- Interop आकार ID प्राप्त करें
- आकार वैकल्पिक पाठ
- आकार लेआउट फ़ॉर्मैट
- आकार SVG के रूप में
- आकार को SVG में
- आकार संरेखित करें
- PowerPoint
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में आकार बनाना, संपादित करना और अनुकूलित करना सीखें और उच्च प्रदर्शन वाले PowerPoint प्रेज़ेंटेशन प्रदान करें."
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों में आकारों के साथ काम करने का तरीका समझाता है। यह दिखाता है कि स्लाइड पर आकार कैसे खोजें, उसे क्लोन करें, हटाएँ, छुपाएँ, उसके क्रम को बदलें, उसका Interop shape ID प्राप्त करें, और पहचान तथा आगे की प्रक्रिया के लिए वैकल्पिक पाठ सेट करें।

यह आकारों के लेआउट फ़ॉर्मैट तक पहुँचने, आकार को SVG के रूप में रेंडर करने, स्लाइड पर आकारों को संरेखित करने, और क्षैतिज तथा ऊर्ध्वाधर प्रतिबिंबन के लिए फ़्लिप प्रॉपर्टीज़ का उपयोग करने के तरीके को भी कवर करता है। अतिरिक्त रूप से, लेख में आकार संयोजन, स्टैकिंग क्रम, और आकार लॉकिंग के बारे में एक छोटा FAQ शामिल है।

## **स्लाइड पर आकार खोजें**
यह विषय एक सरल तकनीक का वर्णन करेगा जिससे डेवलपर्स को स्लाइड पर किसी विशिष्ट आकार को उसके अंतर्निहित Id का उपयोग किए बिना खोजने में आसानी होगी। यह जानना महत्वपूर्ण है कि PowerPoint Presentation फ़ाइलों में किसी आकार की पहचान के लिए कोई अन्य तरीका नहीं है, केवल एक अंतर्निहित अद्वितीय Id होता है। डेवलपर्स के लिए अंतर्निहित अद्वितीय Id का उपयोग करके आकार ढूँढ़ना कठिन हो सकता है। सभी आकारों में कुछ Alt Text होता है। हम डेवलपर्स को सुझाव देते हैं कि वे विशिष्ट आकार खोजने के लिए वैकल्पिक पाठ (Alternative Text) का उपयोग करें। आप भविष्य में बदलने की योजना बना रहे ऑब्जेक्ट्स के लिए वैकल्पिक पाठ को परिभाषित करने के लिए MS PowerPoint का उपयोग कर सकते हैं।

किसी भी इच्छित आकार का वैकल्पिक पाठ सेट करने के बाद, आप Aspose.Slides for Java का उपयोग करके उस प्रेजेंटेशन को खोल सकते हैं और स्लाइड में जोड़े गए सभी आकारों पर इटरेट कर सकते हैं। प्रत्येक इटरेशन में आप आकार के वैकल्पिक पाठ की जाँच कर सकते हैं और मिलते‑जुलते वैकल्पिक पाठ वाला आकार वही होगा जो आपको चाहिए। इस तकनीक को बेहतर तरीके से दर्शाने के लिए हमने एक मेथड, [findShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) बनाया है जो स्लाइड में विशिष्ट आकार खोजने का काम करता है और फिर वह आकार वापस देता है।

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं
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
// स्लाइड में एक आकार को उसके वैकल्पिक पाठ का उपयोग करके खोजने का मेथड कार्यान्वयन
public static IShape findShape(ISlide slide, String alttext)
{
    // स्लाइड के अंदर सभी आकारों पर इटरेट करना
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // यदि स्लाइड का वैकल्पिक पाठ आवश्यक वाले से मेल खाता है तो
        // आकार को लौटाएँ
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **आकार को क्लोन करें**
Aspose.Slides for Java का उपयोग करके स्लाइड पर एक आकार को क्लोन करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
1. उसके सूचक (इंडेक्स) का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. स्रोत स्लाइड की shape collection तक पहुँचें।
1. प्रेजेंटेशन में नई स्लाइड जोड़ें।
1. स्रोत स्लाइड की shape collection से नई स्लाइड में आकारों को क्लोन करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निम्न उदाहरण एक ग्रुप आकार को स्लाइड में जोड़ता है।

```java
// Presentation क्लास का इंस्टेंस बनाएं
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

## **आकार हटाएँ**
Aspose.Slides for Java डेवलपर्स को किसी भी आकार को हटाने की सुविधा देता है। किसी भी स्लाइड से आकार हटाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
1. पहली स्लाइड तक पहुँचें।
1. विशिष्ट AlternativeText वाले आकार को खोजें।
1. आकार को हटाएँ।
1. फ़ाइल को डिस्क पर सहेजें।

```java
// प्रेज़ेंटेशन ऑब्जेक्ट बनाएं
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

    // प्रेज़ेंटेशन को डिस्क पर सहेजें
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **आकार छुपाएँ**
Aspose.Slides for Java डेवलपर्स को किसी भी आकार को छुपाने की सुविधा देता है। किसी भी स्लाइड से आकार छुपाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
1. पहली स्लाइड तक पहुँचें।
1. विशिष्ट AlternativeText वाले आकार को खोजें।
1. आकार को छुपाएँ।
1. फ़ाइल को डिस्क पर सहेजें।

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं
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

## **आकार क्रम बदलें**
Aspose.Slides for Java डेवलपर्स को आकारों के क्रम को पुनः व्यवस्थित करने की सुविधा देता है। क्रम बदलना यह निर्धारित करता है कि कौन सा आकार सामने है और कौन सा पीछे। किसी भी स्लाइड से आकार का क्रम बदलने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
1. पहली स्लाइड तक पहुँचें।
1. एक आकार जोड़ें।
1. आकार के टेक्स्ट फ्रेम में कुछ टेक्स्ट जोड़ें।
1. समान निर्देशांक के साथ दूसरा आकार जोड़ें।
1. आकारों का क्रम बदलें।
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
Aspose.Slides for Java डेवलपर्स को स्लाइड स्तर पर एक अद्वितीय आकार पहचानकर्ता (unique shape identifier) प्राप्त करने की सुविधा देता है, जो [getUniqueId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#getUniqueId--) मेथड के विपरीत है, जो प्रेजेंटेशन स्तर पर अद्वितीय पहचानकर्ता देता है। मेथड [getOfficeInteropShapeId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) को [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape) इंटरफ़ेस और [Shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Shape) क्लास में क्रमशः जोड़ा गया है। [getOfficeInteropShapeId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) मेथड द्वारा लौटाई गई मान Microsoft.Office.Interop.PowerPoint.Shape ऑब्जेक्ट के Id मान के अनुरूप है। नीचे एक नमूना कोड दिया गया है।

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // स्लाइड स्कोप में अद्वितीय आकार पहचानकर्ता प्राप्त करना
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **आकार के लिए वैकल्पिक पाठ सेट करें**
Aspose.Slides for Java डेवलपर्स को किसी भी आकार का AlternateText सेट करने की सुविधा देता है। एक प्रेजेंटेशन में आकारों को [AlternativeText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) या [Shape Name](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#setName-java.lang.String-) मेथड द्वारा पहचाना जा सकता है। [setAlternativeText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) और [getAlternativeText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#getAlternativeText--) मेथड Aspose.Slides के साथ साथ Microsoft PowerPoint द्वारा भी पढ़े या सेट किए जा सकते हैं। इस मेथड का उपयोग करके आप किसी आकार को टैग कर सकते हैं और विभिन्न कार्य कर सकते हैं जैसे कि आकार हटाना, आकार छुपाना या स्लाइड पर आकारों का क्रम बदलना। आकार का AlternateText सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
1. पहली स्लाइड तक पहुँचें।
1. स्लाइड में कोई भी आकार जोड़ें।
1. नए जोड़े गए आकार के साथ कुछ कार्य करें।
1. आकारों के माध्यम से ट्रैवर्स करें ताकि इच्छित आकार मिल सके।
1. AlternativeText सेट करें।
1. फ़ाइल को डिस्क पर सहेजें।

```java
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं
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

## **एक आकार के लिए लेआउट फ़ॉर्मैट तक पहुँचें**
Aspose.Slides for Java आकार के लिए लेआउट फ़ॉर्मैट तक पहुँचने के लिए एक सरल API प्रदान करता है। यह लेख दर्शाता है कि आप लेआउट फ़ॉर्मैट कैसे प्राप्त कर सकते हैं।

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

## **आकार को SVG के रूप में रेंडर करें**
अब Aspose.Slides for Java आकार को SVG के रूप में रेंडर करने का समर्थन करता है। मेथड [writeAsSvg](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (और इसका ओवरलोड) को [Shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Shape) क्लास और [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape) इंटरफ़ेस में जोड़ा गया है। इस मेथड से आप आकार की सामग्री को SVG फ़ाइल के रूप में सहेज सकते हैं। नीचे दिया गया कोड स्निपेट दिखाता है कि स्लाइड के आकार को SVG फ़ाइल में कैसे निर्यात किया जाए।

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

## **एक आकार को संरेखित करें**
Aspose.Slides आकारों को स्लाइड मार्जिन के सापेक्ष या एक‑दूसरे के सापेक्ष संरेखित करने की सुविधा देता है। इस उद्देश्य के लिए ओवरलोडेड मेथड [SlidesUtil.alignShape()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) जोड़ा गया है। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ShapesAlignmentType) एन्‍यूमरेशन संभावित संरेखन विकल्पों को परिभाषित करता है।

**उदाहरण 1**

नीचे का स्रोत कोड आकारों को क्रमांक 1,2 और 4 के साथ स्लाइड के शीर्ष किनारे के साथ संरेखित करता है।

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

**उदाहरण 2**

नीचे का उदाहरण दिखाता है कि संपूर्ण आकार संग्रह को संग्रह के सबसे नीचे स्थित आकार के सापेक्ष कैसे संरेखित किया जाए।

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **फ़्लिप प्रॉपर्टीज़**

Aspose.Slides में, [ShapeFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapeframe/) क्लास आकारों की क्षैतिज और ऊर्ध्वाधर मिररिंग को उसके `flipH` और `flipV` प्रॉपर्टीज़ के माध्यम से नियंत्रित करता है। दोनों प्रॉपर्टीज़ `byte` प्रकार की हैं, जहाँ `1` फ़्लिप दर्शाता है, `0` कोई फ़्लिप नहीं, और `-1` डिफ़ॉल्ट व्यवहार उपयोग करता है। ये मान आकार के [Frame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getFrame--) से प्राप्त किए जा सकते हैं।

फ़्लिप सेटिंग्स को बदलने के लिए, एक नया [ShapeFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapeframe/) इंस्टेंस आकार की वर्तमान स्थिति और आकार, वांछित `flipH` और `flipV` मान, और घूर्णन कोण के साथ बनाया जाता है। इस इंस्टेंस को आकार के [Frame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getFrame--) में असाइन करके और प्रेजेंटेशन को सहेजकर मिरर ट्रांसफ़ॉर्मेशन लागू होते हैं और आउटपुट फ़ाइल में प्रतिबिंबित होते हैं।

मान लीजिए हमारे पास एक sample.pptx फ़ाइल है जिसमें पहली स्लाइड में डिफ़ॉल्ट फ़्लिप सेटिंग्स वाला एकल आकार है, जैसा कि नीचे दिखाया गया है।

![फ़्लिप किया जाने वाला आकार](shape_to_be_flipped.png)

निम्न कोड उदाहरण आकार की वर्तमान फ़्लिप प्रॉपर्टीज़ को प्राप्त करता है और उसे क्षैतिज तथा ऊर्ध्वाधर दोनों रूप से फ़्लिप करता है।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // आकार की क्षैतिज फ़्लिप प्रॉपर्टी प्राप्त करें।
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // आकार की लम्बवत फ़्लिप प्रॉपर्टी प्राप्त करें।
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

![फ़्लिप किया गया आकार](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड पर आकारों (यूनियन/इंटरसेक्ट/सब्ट्रैक्ट) को डेस्कटॉप एडिटर की तरह मिला सकता हूँ?**

निर्मित Boolean ऑपरेशन API मौजूद नहीं है। आप वांछित आउटलाइन को स्वयं बना कर एक अनुमानित समाधान प्राप्त कर सकते हैं—जैसे कि परिणामस्वरूप जियोमेट्री ( [GeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/geometrypath/) के माध्यम से) की गणना करके उस कंटूर के साथ नया आकार बनाएं, तथा मूल आकारों को वैकल्पिक रूप से हटा दें।

**मैं स्टैकिंग क्रम (z-order) को कैसे नियंत्रित करूँ ताकि कोई आकार हमेशा “ऊपर” रहे?**

स्लाइड की [shapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslide/#getShapes--) संग्रह में सम्मिलन/स्थानांतरण क्रम बदलें। पूर्वानुमेय परिणामों के लिए सभी अन्य स्लाइड संशोधनों के बाद z‑order को अंतिम रूप दें।

**क्या मैं PowerPoint में उपयोगकर्ताओं को आकार संपादित करने से रोकने के लिए उसे “लॉक” कर सकता हूँ?**

हां। आप [shape-level protection flags](/slides/hi/java/applying-protection-to-presentation/) सेट कर सकते हैं (जैसे चयन, गति, आकार बदलना, पाठ संपादन लॉक करना)। यदि आवश्यक हो तो मास्टर या लेआउट पर प्रतिबंध भी लागू कर सकते हैं। यह UI‑स्तर का संरक्षण है, न कि सुरक्षा सुविधा; अधिक मजबूत सुरक्षा के लिए फ़ाइल‑स्तर प्रतिबंध जैसे [read‑only सुझाव या पासवर्ड](/slides/hi/java/password-protected-presentation/) के साथ संयोजन करें।