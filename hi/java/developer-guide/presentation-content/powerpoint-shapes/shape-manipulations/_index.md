---
title: Java में प्रस्तुति आकृतियों का प्रबंधन
linktitle: आकृति हेरफेर
type: docs
weight: 40
url: /hi/java/shape-manipulations/
keywords:
- PowerPoint आकृति
- प्रस्तुति आकृति
- स्लाइड पर आकृति
- आकृति खोजें
- आकृति क्लोन करें
- आकृति हटाएँ
- आकृति छिपाएँ
- आकृति क्रम बदलें
- Interop आकृति ID प्राप्त करें
- आकृति वैकल्पिक पाठ
- आकृति लेआउट फॉर्मेट
- आकृति SVG के रूप में
- आकृति को SVG में
- आकृति संरेखित करें
- आकृति फ़्लिप करें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ प्रस्तुति आकृतियों की पहचान, क्लोन, हटाना, छिपाना, पुनः-क्रमबद्ध करना, निर्यात, संरेखण और फ़्लिप करने के तरीके सीखें।"
---
## **सारांश**

Aspose.Slides for Java स्लाइड पर आकृतियों को क्रमबद्ध [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/) के रूप में दर्शाता है। संग्रह वह स्थान है जहाँ आप आकृतियों को खोज और संशोधित करते हैं और उनका स्टैक क्रम निर्धारित करता है: इंडेक्स `0` सबसे पीछे की आकृति है, जबकि अंतिम इंडेक्स सबसे आगे की आकृति है।

यह लेख उसी मॉडल का अनुसरण करता है। यह पहले यह समझाता है कि किसी आकृति की पहचान भरोसेमंद रूप से कैसे करें, फिर क्लोन, हटाना, छिपाना, और पुनः‑क्रमबद्ध करना दिखाता है। अंतिम अनुभाग लेआउट‑स्तर फॉर्मेटिंग, SVG निर्यात, एलाइनमेंट, और फ़्लिप सेटिंग्स को कवर करते हैं। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल वही ऑपरेशन उपयोग कर सकते हैं जो आपके वर्कफ़्लो को आवश्यक है।

## **पहचानें और आकृतियों को खोजें**

कलेक्शन इंडेक्स किसी ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थिर पहचानकर्ता नहीं होते। आकृति को जोड़ना, हटाना या पुनः‑क्रमबद्ध करना इसका इंडेक्स बदल सकता है। प्रस्तुति के निर्माण और रख‑रखाव के तरीके के अनुसार पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getName--) डेवलपर‑नियंत्रित टेम्प्लेट्स के लिए उपयोगी है और PowerPoint की Selection Pane में आसानी से देखा जा सकता है। नाम को संपादित किया जा सकता है और वे अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड उन पर निर्भर करता है तो एक नामकरण नियम स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getAlternativeText--) तब उपयोगी है जब एक एक्सेसिबिलिटी विवरण या लेखक‑द्वारा दिया गया टैग पहले से ही आकृति की पहचान करता हो। यह उपयोगकर्ताओं को दिखाई देता है, स्थानीयकृत या एक्सेसिबिलिटी के लिये पुनर्लिखित किया जा सकता है, और यह अनिवार्य रूप से अद्वितीय नहीं है। अर्थपूर्ण एक्सेसिबिलिटी टेक्स्ट को चुपचाप डेटाबेस कुंजी के रूप में पुनः‑प्रयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) एक पढ़ने‑के‑लिए‑केवल पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय होता है और PowerPoint interop द्वारा उपयोग किए जाने वाले आकृति ID के अनुरूप होता है। PowerPoint के साथ इंटीग्रेशन करते समय या जब आपको किसी आकृति के जीवन‑काल के दौरान अस्पष्ट संदर्भ चाहिए तब इसका उपयोग करें। एक क्लोन या पुनः‑निर्मित आकृति अलग होती है और उसे अपना अलग ID मिलता है।

संबंधित [getUniqueId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getUniqueId--) मेथड प्रस्तुति स्कोप के साथ एक पहचानकर्ता लौटाता है, लेकिन वह पहचानकर्ता ऐड‑इन्स के लिये है और पुनः‑असाइन किया जा सकता है। इसे स्थायी बाहरी कुंजी नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो मैपिंग को एप्लिकेशन डेटा में रखें और सत्यापित करें कि अपेक्षित आकृति अभी भी मौजूद है।

नीचे दिया गया उदाहरण नाम द्वारा सटीक तुलना करके खोज करता है और स्लाइड‑स्कोप्ड interop ID रिपोर्ट करता है। जब टेम्प्लेट में अपेक्षित आकृति नहीं मिलती, तो कोड उस परिणाम को रिपोर्ट करता है न कि गलत वस्तु के साथ जारी रहता है।

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

जब कोई ऑपरेशन विशेष रूप से किसी आकृति प्रकार के लिये हो, तो प्रकार‑विशिष्ट सदस्यों का उपयोग करने से पहले इंटरफ़ेस जांचें। यह उदाहरण केवल तभी पाठ और वैकल्पिक पाठ अपडेट करता है जब नामित वस्तु [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) हो।

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

ऐड, क्लोन, रिमूव, और रीऑर्डर मेथड सीधे संग्रह पर कार्य करते हैं। यदि कोई ऑपरेशन आकृतियों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले कैप्चर किए गए इंडेक्स पर भरोसा न करें।

### **एक आकृति को क्लोन करें**

[addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) एक स्वतंत्र कॉपी बनाता है और उसे लक्ष्य संग्रह के अंत में जोड़ता है। [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) भी कॉपी बनाता है लेकिन उसे निर्दिष्ट z‑order इंडेक्स पर रखता है। वह ओवरलोड जो निर्देशांक स्वीकार करता है क्लोन को उसकी आकार बदले बिना ले जाता है; चौड़ाई और ऊँचाई वाले ओवरलोड इसे री‑साइज़ भी कर सकते हैं।

उदाहरण एक गंतव्य स्लाइड बनाता है, एक लेबल वाली आयत को सामने क्लोन करता है, और दूसरे क्लोन को पीछे डालता है। किसी भी क्लोन में किए गए परिवर्तन मूल आकृति को नहीं बदलते।

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

क्लोनिंग आकृति की सामग्री और फॉर्मेटिंग को कॉपी करती है, जिसमें उसका नाम और वैकल्पिक पाठ भी शामिल है। जब इन मानों को अद्वितीय होना आवश्यक हो तो क्लोन को नए लॉजिकल पहचानकर्ता सौंपें। जटिल आकृतियों द्वारा उपयोग किए गए संसाधनों का ध्यान प्रस्तुति लेती है, लेकिन क्लोन नया संग्रह आइटम और नई आकृति पहचान के साथ रहता है।

### **आकृतियों को हटाएँ**

[remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) एक विशिष्ट आकृति ऑब्जेक्ट को उसके संग्रह से हटा देता है। इंडेक्स‑आधारित इटरेशन के दौरान कई मिलानों को हटाते समय, अंत से घटते हुए ट्रैवर्स करें ताकि प्रत्येक शेष इंडेक्स वैध बना रहे।

यह उदाहरण निर्दिष्ट नाम वाली प्रत्येक आकृति को हटाता है। यह वर्तमान इंडेक्स पर आकृति को पढ़ता है, न कि किसी स्थिर संग्रह आइटम को, और यह आकृति को अनावश्यक रूप से कास्ट नहीं करता।

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

हटाने के बाद, आकृति की गणना और बाद की आकृतियों के इंडेक्स बदल जाते हैं। अप्रभावित आकृतियों के संदर्भ सहेजे गए इंडेक्स की तुलना में अधिक भरोसेमंद रहते हैं। कनेक्टर्स, एनीमेशन, और अन्य प्रस्तुति सुविधाओं को भी ध्यान में रखें जो हटाई गई वस्तु को संदर्भित कर सकती हैं; एक दिखाई देने वाली आकृति को हटाना स्लाइड की उपस्थिति से अधिक बदल सकता है।

### **एक आकृति को छिपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setHidden-boolean-) को `true` पर सेट करने से आकृति संग्रह में रहती है लेकिन सामान्य स्लाइड शो में प्रदर्शित नहीं होती। उसका इंडेक्स, फॉर्मेटिंग, और सामग्री कोड के लिये उपलब्ध रहती है, इसलिए छिपाना वैकल्पिक तत्वों के लिये उपयुक्त है जिन्हें बाद में पुनः‑स्थापित किया जा सकता है।

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

छिपाना हटाना या सुरक्षा नहीं है। वस्तु को अभी भी खोजा जा सकता है और उपयोगकर्ता या कोड द्वारा अनहिड किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बनी रहती है।

### **Z‑Order बदलें**

ओवरलैपिंग आकृतियों को संग्रह क्रम में पेंट किया जाता है। [reorder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) एक मौजूदा आकृति को लक्ष्य इंडेक्स पर बिना क्लोन किए ले जाता है। इंडेक्स `0` पिछले हिस्से को दर्शाता है; `size() - 1` सामने को।

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आयत पहले बनाई जाती है और प्रारंभ में अंडाकार के पीछे बैठती है। इसे अंतिम इंडेक्स पर ले जाने से वह सामने आ जाती है। सभी संबंधित आकृतियों को जोड़ने या क्लोन करने के बाद Z‑order को अंतिम रूप दें, क्योंकि ये ऑपरेशन नए संग्रह आइटम जोड़ या डाल सकते हैं और इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड्स पर आकृतियों का निरीक्षण करें**

सामान्य स्लाइड्स, लेआउट स्लाइड्स, और मास्टर स्लाइड्स के अलग‑अलग आकृति संग्रह होते हैं। लेआउट संग्रह में एक आकृति सामान्य स्लाइड पर समान‑स्थिति वाली आकृति के समान ऑब्जेक्ट नहीं होती। जब आपको लेआउट द्वारा प्रदान किए गए फॉर्मेटिंग को समझना या बदलना हो तो लेआउट आकृतियों की जाँच करें।

निम्न उदाहरण प्रत्येक लेआउट आकृति के [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getFillFormat--) और [LineFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getLineFormat--) को पढ़ता है, यह मानते हुए कि हर आकृति `AutoShape` है।

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

लेआउट को संपादित करने से उसे उपयोग करने वाली कई स्लाइड्स प्रभावित हो सकती हैं। लेआउट आकृति को बदलने से पहले निर्धारित करें कि क्या सामान्य स्लाइड वस्तु को विरासत में लेता है या स्थानीय ओवरराइड रखता है, और उस लेआउट को उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **आकृति को SVG में निर्यात करें**

[writeAsSvg](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) एक आकृति की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल वह आकृति होती है, पूरी स्लाइड पृष्ठभूमि या पड़ोसी आकृतियों नहीं।

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

रेंडरिंग के दौरान प्रस्तुति खुली रखें। आउटपुट आकृति के फॉर्मेटिंग तथा फ़ॉन्ट और चित्र जैसे संसाधनों पर निर्भर करता है। यदि आपको पूरी रचना चाहिए, तो व्यक्तिगत आकृति के बजाय स्लाइड निर्यात करें। कॉलर को स्ट्रीम का स्वामित्व रहता है और उसे बंद करना आवश्यक है।

## **आकृतियों को संरेखित करें**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) ओवरलोड सभी आकृतियों या चयनित संग्रह इंडेसेस को संरेखित करता है। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapesalignmenttype/) किनारे, केंद्र रेखा, या वितरण मोड को निर्दिष्ट करता है। `alignToSlide` को `true` पर सेट करने से स्लाइड के किनारे उपयोग होते हैं; `false` पर सेट करने से चयनित आकृतियों को एक‑दूसरे के सापेक्ष संरेखित किया जाता है।

यह उदाहरण तीन आकृतियों को स्लाइड के शीर्ष किनारे पर संरेखित करता है। संरेखण से पहले लौटाए गए आकृति संदर्भों को तुरंत उनके वर्तमान इंडेक्स में बदला जाता है।

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

संरेखण स्थिति बदलता है, Z‑order नहीं। सापेक्ष संरेखण को सामान्यतः कम से कम दो आकृतियों की आवश्यकता होती है, जबकि क्षैतिज या ऊर्ध्वाधर वितरण को दूरी निर्धारित करने हेतु पर्याप्त आकृतियों की जरूरत होती है। मेथड कॉल करने से पहले यदि आप संग्रह को संशोधित करते हैं तो इंडेक्स पुनः‑गणना करें।

## **आकृति को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज और ऊर्ध्वाधर फ़्लिप सेटिंग्स, तथा घूर्णन को सहेजता है। इसके `getFlipH` और `getFlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/java/com.aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप को सक्षम करता है, `False` निष्क्रिय करता है, और `NotDefined` अनिर्दिष्ट/डिफ़ॉल्ट स्थिति को बनाए रखता है।

नीचे दी गई इनपुट प्रस्तुति में एक अनफ़्लिप्ड आकृति है।

![फ़्लिप करने से पहले आकृति](shape_to_be_flipped.png)

यह उदाहरण प्रत्येक फ़्रेम मान को यथावत रखता है और केवल दो फ़्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) संजुक्त करने से पूर्ण फ़्रेम बदल जाता है।

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

सहेजी गई आकृति क्षैतिज और ऊर्ध्वाधर दोनों दिशा में मिरर हुई है जबकि उसकी स्थिति, आकार और घूर्णन समान रहता है।

![फ़्लिप करने के बाद आकृति](flipped_shape.png)

## **FAQ**

**क्या मुझे आकृति पहचानकर्ता के रूप में कलेक्शन इंडेक्स उपयोग करना चाहिए?**

केवल छोटे‑समय प्रोसेसिंग के लिये जब कलेक्शन ऑपरेशन के बाद नहीं बदलेगा। निर्मित टेम्प्लेट्स के लिये मान्य `Name` या `AlternativeText` नियम पसंद करें, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिये `OfficeInteropShapeId` उपयोग करें।

**क्या एक छिपी आकृति Z‑order से हट जाती है?**

नहीं। एक छिपी आकृति समान इंडेक्स पर संग्रह में बनी रहती है। इसे पाया, पुनः‑क्रमबद्ध, संपादित या फिर से दिखाई दिया जा सकता है।

**क्लोन की गई आकृति किसी अन्य आकृति के सामने क्यों दिखाई दी?**

`addClone` क्लोन को संग्रह के अंत में जोड़ता है, जो Z‑order के सामने होता है। प्रारम्भिक इंडेक्स चुनने के लिये `insertClone` उपयोग करें या सभी आकृतियों के जोड़ने के बाद `reorder` का उपयोग करें।