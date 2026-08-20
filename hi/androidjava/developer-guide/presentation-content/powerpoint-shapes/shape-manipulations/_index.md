---
title: प्रेजेंटेशन आकारों को एंड्रॉयड पर प्रबंधित करें
linktitle: आकार हेरफेर
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
- आकार छिपाएँ
- आकार क्रम बदलें
- इंटरऑप आकार ID प्राप्त करें
- आकार वैकल्पिक टेक्स्ट
- आकार लेआउट फ़ॉर्मेट
- आकार SVG के रूप में
- आकार को SVG में
- आकार संरेखित करें
- आकार फليب करें
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ प्रेजेंटेशन आकारों को पहचानने, क्लोन करने, हटाने, छिपाने, क्रम बदलने, निर्यात करने, संरेखित करने और फ़्लिप करने के बारे में जानें।"
---
## **सारांश**

Aspose.Slides for Android via Java स्लाइड पर आकृतियों को क्रमबद्ध [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/) के रूप में प्रस्तुत करता है। यह संग्रह न तो केवल आकृतियों को खोजने और संशोधित करने का स्थान है बल्कि उनका स्टैक क्रम भी निर्धारित करता है: सूचकांक `0` सबसे पीछे की आकृति है, जबकि अंतिम सूचकांक सबसे आगे की आकृति को दर्शाता है।

यह लेख उसी मॉडल का पालन करता है। पहले यह समझाता है कि किसी आकृति की विश्वसनीय पहचान कैसे की जाए, फिर क्लोन, हटाना, छिपाना और पुन: क्रम बदलने के तरीके दिखाता है। अंतिम भाग में लेआउट‑स्तर का फॉर्मेटिंग, SVG निर्यात, संरेखण और फ़्लिप सेटिंग्स को कवर किया गया है। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल वह संचालन उपयोग कर सकते हैं जो आपके कार्य‑प्रवाह की आवश्यकता हो।

## **आकृतियों की पहचान और खोज**

संग्रह सूचकांक ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थायी पहचानकर्ता नहीं हैं। किसी आकृति को जोड़ना, हटाना या क्रम बदलना उसके सूचकांक को बदल सकता है। प्रस्तुति के authoring और maintenance के आधार पर एक पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getName--) उन टेम्पलेट्स के लिये उपयोगी है जो डेवलपर द्वारा नियंत्रित होते हैं और PowerPoint के Selection Pane में आसानी से देखी जा सकती है। नाम संपादित किए जा सकते हैं और अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड उन पर निर्भर करता है तो एक नामकरण नियम स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getAlternativeText--) उपयोगी है जब कोई accessibility विवरण या लेखक द्वारा दिया गया टैग पहले से ही आकृति की पहचान करता हो। यह उपयोगकर्ताओं को दिखाई देता है, स्थानीयकृत या accessibility के लिये पुनः लिखा जा सकता है, और अनिवार्य रूप से अद्वितीय नहीं है। अर्थपूर्ण accessibility टेक्स्ट को मौन तौर पर डेटाबेस कुंजी के रूप में प्रयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) एक पढ़‑only पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय है और PowerPoint interop द्वारा उपयोग किए गए Shape ID से मेल खाता है। PowerPoint के साथ एकीकरण या जब आप किसी आकृति के जीवन‑काल में अस्पष्ट संदर्भ चाहिए तब इसका उपयोग करें। क्लोन या पुनः निर्मित आकृति अलग होती है और उसका अपना ID मिलता है।

संबंधित [getUniqueId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getUniqueId--) मेथड प्रस्तुति‑परिधि का पहचानकर्ता लौटाता है, लेकिन यह पहचानकर्ता add‑ins के लिये अभिप्रेत है और पुनः आवंटित किया जा सकता है। इसे स्थायी बाहरी कुंजी नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो मैपिंग को एप्लिकेशन डेटा में रखें और यह सत्यापित करें कि अपेक्षित आकृति अभी भी मौजूद है।

निम्न उदाहरण नाम द्वारा सटीक तुलना से खोजता है और स्लाइड‑परिधि का interop ID रिपोर्ट करता है। जब टेम्पलेट में अपेक्षित आकृति नहीं मिलती, तो कोड उस परिणाम को रिपोर्ट करता है बजाय गलत ऑब्जेक्ट के साथ जारी रखने के।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

जब कोई ऑपरेशन विशिष्ट आकृति प्रकार के लिये हो, तो टाइप‑विशिष्ट सदस्य उपयोग करने से पहले इंटरफ़ेस की जाँच करें। यह उदाहरण केवल तब टेक्स्ट और alternative text को अपडेट करता है जब नामित वस्तु एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) हो।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **आकार संग्रह को संशोधित करें**

add, clone, remove और reorder मेथड्स संग्रह पर तुरंत कार्य करते हैं। यदि कोई ऑपरेशन आकारों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले कैप्चर किए गए सूचकांकों पर भरोसा न करें।

### **आकार को क्लोन करें**

[addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) एक स्वतंत्र कॉपी बनाता है और उसे लक्ष्य संग्रह में जोड़ता है। [insertClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) भी एक कॉपी बनाता है लेकिन उसे निर्दिष्ट z‑order सूचकांक पर रखता है। वांछित निर्देशांक स्वीकार करने वाले ओवरलोड आकार को बिना बदले कॉपी को स्थानांतरित करते हैं; चौड़ाई और ऊँचाई वाले ओवरलोड इसे पुन: आकार दे सकते हैं।

उदाहरण एक गंतव्य स्लाइड बनाता है, लेबल वाले आयत को आगे की ओर क्लोन करता है, और दूसरा क्लोन पीछे जोड़ता है। किसी भी क्लोन में बदलाव स्रोत आकृति को संशोधित नहीं करता।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

क्लोनिंग आकृति की सामग्री और फॉर्मेटिंग, जिसमें उसका name और alternative text शामिल है, कॉपी करती है। जब इन मानों को अद्वितीय होना आवश्यक हो तो क्लोन को नए तार्किक पहचानकर्ता सौंपें। जटिल आकृतियों द्वारा उपयोग किए गए संसाधन प्रस्तुति द्वारा संभाले जाते हैं, लेकिन क्लोन नई संग्रह आइटम के रूप में नई आकृति पहचान के साथ रहता है।

### **आकृतियों को हटाएँ**

[remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) निर्दिष्ट आकृति ऑब्जेक्ट को उसके संग्रह से हटाता है। सूचकांक‑आधारित इटरेशन के दौरान कई मिलान हटाते समय अंत से यात्रा करें ताकि शेष प्रत्येक सूचकांक वैध बना रहे।

यह उदाहरण निर्दिष्ट नाम वाली प्रत्येक आकृति को हटाता है। यह वर्तमान सूचकांक पर आकृति पढ़ता है, न कि स्थायी संग्रह आइटम, और अनावश्यक रूप से आकृति को कास्ट नहीं करता।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

हटाने के बाद आकृति गिनती और बाद की आकृतियों के सूचकांक बदल जाते हैं। अप्रभावित आकृतियों के संदर्भ संचित सूचकांकों की तुलना में अधिक विश्वसनीय रहते हैं। साथ ही कनेक्टर, एनीमेशन और अन्य प्रस्तुति सुविधाओं पर भी विचार करें जो हटाए गए ऑब्जेक्ट का संदर्भ ले सकते हैं; दृश्य आकृति को हटाना स्लाइड की उपस्थिति से अधिक बदलाव कर सकता है।

### **आकृति को छिपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) को `true` सेट करने से आकृति संग्रह में बनी रहती है लेकिन सामान्य स्लाइड शो में प्रदर्शित नहीं होती। उसका सूचकांक, फॉर्मेटिंग और सामग्री कोड के लिये उपलब्ध रहती है, इसलिए छिपाना वैकल्पिक तत्वों के लिये उपयुक्त है जिन्हें बाद में पुनः सक्रिय किया जा सकता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

छिपाना हटाना या सुरक्षा नहीं है। उपयोगकर्ता या कोड द्वारा इसे अभी भी खोजा और अनहिड किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बना रहता है।

### **Z-क्रम बदलें**

ओवरलैपिंग आकृतियां संग्रह क्रम में पेंट की जाती हैं। [reorder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) मौजूदा आकृति को क्लोन किए बिना लक्ष्य सूचकांक पर ले जाता है। सूचकांक `0` पीछे है; `size() - 1` आगे है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आयत पहले बनती है और प्रारम्भिक रूप से अंडाकार के पीछे रहती है। इसे अंतिम सूचकांक पर ले जाने से वह आगे आ जाता है। सभी संबंधित आकृतियों को जोड़ने या क्लोन करने के बाद z‑order को अंतिम रूप दें, क्योंकि ये ऑपरेशन नए संग्रह आइटम जोड़ते या सम्मिलित करते हैं और वांछित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड्स पर आकृतियों की जाँच करें**

सामान्य स्लाइड्स, लेआउट स्लाइड्स और मास्टर स्लाइड्स की अलग-अलग आकार संग्रह होते हैं। लेआउट संग्रह में मौजूद आकृति समान स्थितिक साधारण स्लाइड की आकृति नहीं होती। लेआउट आकृतियों की जाँच तब करें जब आप लेआउट द्वारा प्रदान किए गए फॉर्मेटिंग को समझना या बदलना चाहते हों।

निम्न उदाहरण प्रत्येक लेआउट आकृति के [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getFillFormat--) और [LineFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getLineFormat--) को पढ़ता है, यह मानते हुए कि हर आकृति `AutoShape` नहीं है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

लेआउट को संपादित करने से उस पर निर्भर कई स्लाइड्स प्रभावित हो सकती हैं। लेआउट आकृति को बदलने से पहले निर्धारित करें कि सामान्य स्लाइड वह ऑब्जेक्ट विरासत में लेती है या स्थानीय रूप से ओवरराइड करती है, और उस लेआउट का उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **आकृति को SVG में निर्यात करें**

[writeAsSvg](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) एक आकृति की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल वह आकृति शामिल होती है, न कि पूरी स्लाइड पृष्ठभूमि या निकटवर्ती आकृतियां।

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

रेंडरिंग के दौरान प्रस्तुति को खुला रखें। आउटपुट आकार की फॉर्मेटिंग और फ़ॉन्ट व चित्र जैसे संसाधनों पर निर्भर करता है। यदि आपको पूरी संरचना चाहिए, तो व्यक्तिगत आकृति के बजाय स्लाइड निर्यात करें। कॉलर को स्ट्रीम का स्वामित्व होता है और उसे बंद करना चाहिए।

## **आकृतियों को संरेखित करें**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) ओवरलोड सभी आकृतियों या चयनित संग्रह सूचकांकों को संरेखित करता है। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapesalignmenttype/) किनारा, मध्यरेखा या वितरण मोड निर्दिष्ट करता है। `alignToSlide` को `true` सेट करने पर स्लाइड किनारे उपयोग होते हैं; `false` पर चयनित आकृतियों को एक‑दूसरे के सापेक्ष संरेखित किया जाता है।

यह उदाहरण तीन आकृतियों को स्लाइड के शीर्ष किनारे पर संरेखित करता है। लौटाए गए आकृति संदर्भों को संरेखण से तुरंत पहले उनके वर्तमान सूचकांकों में परिवर्तित किया जाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

संरेखण स्थितियों को बदलता है, न कि z‑order को। सापेक्ष संरेखण के लिये आमतौर पर कम से कम दो आकृतियां आवश्यक होती हैं, जबकि क्षैतिज या लंबवत वितरण के लिये स्पेसिंग निर्धारित करने हेतु पर्याप्त आकृतियां चाहिए। यदि आप मेथड कॉल करने से पहले संग्रह को संशोधित करते हैं तो सूचकांकों को पुनः गणना करें।

## **आकृति को उलटें**

[ShapeFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज व लंबवत फ़्लिप सेटिंग्स और रोटेशन को संग्रहीत करता है। इसके `getFlipH` व `getFlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप को सक्षम करता है, `False` निष्क्रिय करता है, और `NotDefined` अप्रस्तावित/डिफ़ॉल्ट स्थिति को बरकरार रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक अनफ़्लिप्ड आकृति शामिल करता है।

![फ़्लिप करने से पहले की आकृति](shape_to_be_flipped.png)

यह उदाहरण प्रत्येक फ़्रेम मान को अपरिवर्तित रखता है और केवल दो फ़्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) निर्धारित करने से संपूर्ण फ़्रेम प्रतिस्थापित हो जाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सहेजी गई आकृति क्षैतिज और लंबवत दोनों दिशा में मुड़ जाती है जबकि उसकी स्थिति, आकार और रोटेशन अपरिवर्तित रहता है।

![फ़्लिप करने के बाद की आकृति](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे आकार पहचानकर्ता के रूप में संग्रह सूचकांक का उपयोग करना चाहिए?**

केवल अल्पकालिक प्रोसेसिंग के लिये जब संग्रह ऑपरेशन से पहले नहीं बदलेगा। निर्मित टेम्पलेट्स के लिये मान्य `Name` या `AlternativeText` नियम अपनाएँ, या स्लाइड‑परिधि interop कार्य के लिये `OfficeInteropShapeId` उपयोग करें।

**क्या आकृति को छिपाने से वह Z-क्रम से हट जाती है?**

नहीं। छिपी हुई आकृति समान सूचकांक पर संग्रह में बनी रहती है। इसे पाया, पुनः क्रम बदल, संपादित या फिर से दृश्यमान किया जा सकता है।

**क्लोन की गई आकृति किसी अन्य आकृति के सामने क्यों दिखी?**

`addClone` क्लोन को संग्रह के अंत में जोड़ता है, जो Z-क्रम का अग्र भाग होता है। प्रारम्भिक सूचकांक चुनने के लिये `insertClone` उपयोग करें या सभी आकृतियों के जोड़ने के बाद `reorder` करें।