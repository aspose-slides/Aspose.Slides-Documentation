---
title: एंड्रॉइड पर प्रस्तुति आकृतियों को प्रबंधित करें
linktitle: आकृति हेरफ़ेर
type: docs
weight: 40
url: /hi/androidjava/shape-manipulations/
keywords:
- PowerPoint आकृति
- प्रस्तुति आकृति
- स्लाइड पर आकृति
- आकृति खोजें
- आकृति क्लोन करें
- आकृति हटाएँ
- आकृति छुपाएँ
- आकृति क्रम बदलें
- इंटरऑप आकृति ID प्राप्त करें
- आकृति वैकल्पिक पाठ
- आकृति समायोजन बिंदु
- पूर्व निर्धारित आकृति समायोजन
- आकृति ज्यामिति
- आकृति लेआउट स्वरूप
- SVG रूप में आकृति
- आकृति को SVG में
- आकृति संरेखित करें
- आकृति फ़्लिप करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ प्रस्तुति आकृतियों की पहचान, समायोजन, क्लोन, हटाना, छुपाना, पुनः क्रमित करना, निर्यात, संरेखण और फ़्लिप करना सीखें।"
---
## **सारांश**

Aspose.Slides for Android via Java स्लाइड पर आकृतियों को क्रमबद्ध [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/) के रूप में दर्शाता है। यह संग्रह वह स्थान है जहाँ आप आकृतियों को खोजते और संशोधित करते हैं तथा उनका स्टैक क्रम निर्धारित करता है: इंडेक्स `0` सबसे पीछे की आकृति है, जबकि अंतिम इंडेक्स सबसे आगे की आकृति है।

यह लेख उसी मॉडल का पालन करता है। यह पहले यह समझाता है कि किसी आकृति की पहचान विश्वसनीय रूप से कैसे करें और पूर्व निर्धारित आकृति समायोजन बिंदुओं को कैसे बदलें, फिर यह दर्शाता है कि आकृतियों को कैसे क्लोन, हटाएँ, छुपाएँ और पुनः क्रमित करें। अंतिम अनुभाग लेआउट‑स्तर फॉर्मेटिंग, SVG निर्यात, संरेखण और फ़्लिप सेटिंग्स को कवर करता है। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल वही संचालन उपयोग कर सकते हैं जो आपके कार्य‑प्रवाह को आवश्यक हैं।

## **आकृतियों की पहचान और खोज**

संग्रह इंडेक्स ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थिर पहचानकर्ता नहीं होते। आकृति जोड़ने, हटाने या पुनः क्रमित करने से उसका इंडेक्स बदल सकता है। प्रस्तुति के निर्माण और रखरखाव के तरीके के अनुसार एक पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getName--) डेवलपर‑नियंत्रित टेम्पलेट के लिए उपयोगी है और PowerPoint की Selection Pane में आसानी से देखा जा सकता है। नाम संपादित किए जा सकते हैं और अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड उन पर निर्भर करता है तो एक नामकरण नियम स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getAlternativeText--) उपयोगी है जब कोई एक्सेसिबिलिटी विवरण या लेखक‑द्वारा प्रदान किया गया टैग पहले से ही आकृति की पहचान करता हो। यह उपयोगकर्ताओं को दिखाया जाता है, स्थानीयकृत या एक्सेसिबिलिटी के लिए पुनर्लेखित किया जा सकता है, और अनिवार्य रूप से अद्वितीय नहीं है। अर्थपूर्ण एक्सेसिबिलिटी टेक्स्ट को मौन रूप से डेटाबेस कुंजी के रूप में पुनः उपयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय है और PowerPoint इंटरऑप द्वारा उपयोग किए जाने वाले आकृति ID से मेल खाता है। इसे PowerPoint के साथ एकीकरण या आकृति के जीवन‑काल में स्पष्ट संदर्भ की आवश्यकता होने पर उपयोग करें। क्लोन या पुनः निर्मित आकृति अलग होती है और उसका अपना ID प्राप्त करती है।

संबंधित [getUniqueId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getUniqueId--) मेथड प्रस्तुति‑स्कोप में एक पहचानकर्ता लौटाता है, लेकिन यह ऐड‑इन के लिए है और पुनः असाइन किया जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो मैपिंग को एप्लिकेशन डेटा में रखें और यह सत्यापित करें कि वांछित आकृति अभी भी मौजूद है।

निम्न उदाहरण नाम द्वारा सटीक तुलना के साथ खोज करता है और स्लाइड‑स्कोप इंटरऑप ID रिपोर्ट करता है। जब टेम्पलेट में अपेक्षित आकृति नहीं होती, तो कोड गलत ऑब्जेक्ट के साथ जारी रखने के बजाय वह परिणाम रिपोर्ट करता है।

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

जब कोई ऑपरेशन विशिष्ट आकृति प्रकार के लिए हो, तो प्रकार‑विशिष्ट सदस्य उपयोग करने से पहले इंटरफ़ेस की जाँच करें। यह उदाहरण तभी टेक्स्ट और alternative text अपडेट करता है जब नामित ऑब्जेक्ट एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) हो।

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

## **पूर्व निर्धारित आकृति समायोजन की पहचान और संशोधन**

पूर्व निर्धारित ज्यामिति आकृतियों में समायोजन बिंदु हो सकते हैं जो कोने का आकार, तीर अनुपात या चाप कोण जैसी विशेषताओं को नियंत्रित करते हैं। इन्हें केवल‑पढ़ने योग्य [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) संग्रह के माध्यम से एक्सेस करें। संग्रह स्वयं आकृति द्वारा प्रदान किया जाता है, लेकिन प्रत्येक [IAdjustValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iadjustvalue/) में वह मान होता है जिसे बदला जा सकता है।

केवल स्थिर संग्रह इंडेक्स पर निर्भर न रहें। समायोजनों के माध्यम से इटरेट करें और केवल‑पढ़ने वाले [getType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iadjustvalue/#getType--) मेथड की जाँच करें, जिसका [ShapeAdjustmentType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapeadjustmenttype/) मान दर्शाता है कि समायोजन क्या नियंत्रित करता है। केवल‑पढ़ने वाला [getName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iadjustvalue/#getName--) मेथड अतिरिक्त पहचान जानकारी प्रदान करता है और विशेष रूप से तब उपयोगी होता है जब कोई पूर्व निर्धारित समान अर्थ वाले कई समायोजन रखता है।

समायोजन के अर्थ से मेल खाने वाला मान मेथड उपयोग करें:

| समायोजन प्रकार | उद्देश्य | बदलने के लिए मान |
|---|---|---|
| `CornerSize` | गोल कोनों का आकार | [setRawValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | तीर के पूंछ की मोटाई | `setRawValue` |
| `ArrowheadLength` | तीर शीर्ष की लंबाई | `setRawValue` |
| `ArrowheadWidth` | तीर शीर्ष की चौड़ाई | `setRawValue` |
| `StartAngle` | पाई या चाप का प्रारम्भिक कोण | [setAngleValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | पाई या चाप का अंतिम कोण | `setAngleValue` |

`getType` और `getName` केवल‑पढ़ने वाली जानकारी लौटाते हैं। `getRawValue` और `setRawValue` पूर्व निर्धारित की मूल ज्यामिति इकाइयों में एक पूर्णांक के साथ कार्य करते हैं, जबकि `getAngleValue` और `setAngleValue` डिग्री में कोण के साथ कार्य करते हैं। समायोजन की संख्या, क्रम, अर्थ और वैध रेंज पूर्व निर्धारित [ShapeType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) पर निर्भर करती है। एक पूर्व निर्धारित के लिए वैध मान दूसरे के लिए अमान्य या अलग प्रभाव रख सकता है।

जब `getType` `ShapeAdjustmentType.Custom` लौटाता है, तो API मानक अर्थ को पहचान नहीं पाती। `getName`, पूर्व निर्धारित प्रकार और मौजूदा मान का निरीक्षण करें, और यदि अपेक्षित अर्थ और रेंज ज्ञात न हो तो समायोजन को अपरिवर्तित रखें। मान्यता प्राप्त प्रकारों के लिए भी जांचें कि क्या वही प्रकार कई बार आता है, इससे पहले कि आप मान चुनें। कनेक्टर बेंड समायोजनों के संबंध में यह स्थिति [Connector](/slides/hi/androidjava/connector/) लेख में दर्शायी गई है।

निम्न पूर्ण उदाहरण तीन पूर्व निर्धारित आकृतियों के डिफ़ॉल्ट और संशोधित संस्करण बनाता है। यह हर समायोजन के माध्यम से इटरेट करता है, उसका नाम और प्रकार रिपोर्ट करता है, `setRawValue` के द्वारा आकार‑संबंधी मान बदलता है, `setAngleValue` के द्वारा कोण बदलता है, और परिणाम सहेजता है। बायाँ कॉलम डिफ़ॉल्ट ज्यामिति रखता है; दायाँ कॉलम समायोजित गोल आयत, चार‑मार्ग तीर और पाई दिखाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // डिफ़ॉल्ट और समायोजित आकृति कॉलम के लिए हेडर जोड़ता है।
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

मान बदलने से पहले अर्थ‑प्रकार की जांच करने से कोड का इरादा स्पष्ट होता है और यह मानने से बचता है कि विभिन्न पूर्व निर्धारित आकृतियों में एक ही संग्रह इंडेक्स का अर्थ समान हो।

## **आकृति संग्रह को संशोधित करना**

जोड़ने, क्लोन करने, हटाने और पुनः क्रमित करने वाले मेथड तुरंत संग्रह पर कार्य करते हैं। यदि कोई ऑपरेशन आकृतियों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले कैप्चर किए गए इंडेक्स पर निर्भर नहीं रहना चाहिए।

### **आकृति को क्लोन करें**

[addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) एक स्वतंत्र प्रतिलिपि बनाता है और लक्ष्य संग्रह में जोड़ता है। [insertClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) भी प्रतिलिपि बनाता है लेकिन इसे निर्दिष्ट z‑order इंडेक्स पर रखता है। समन्वय स्वीकार करने वाले ओवरलोड क्लोन का आकार नहीं बदलते; चौड़ाई‑और‑ऊँचाई वाले ओवरलोड इसे पुनः आकार दे सकते हैं।

उदाहरण एक गंतव्य स्लाइड बनाता है, लेबल वाली आयत को आगे क्लोन करता है, और दूसरी क्लोन को पीछे सम्मिलित करता है। किसी भी क्लोन में परिवर्तन स्रोत आकृति को नहीं बदलता।

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

क्लोनिंग आकृति की सामग्री और फॉर्मेटिंग को कॉपी करती है, जिसमें उसका नाम और alternative text भी शामिल है। जब ये मान अद्वितीय होने चाहिए तो क्लोन को नया तार्किक पहचानकर्ता दें। जटिल आकृतियों द्वारा उपयोग किए गए संसाधन प्रस्तुति द्वारा संभाले जाते हैं, लेकिन क्लोन एक नया संग्रह आईटम और नई आकृति पहचान के साथ रहता है।

### **आकृतियों को हटाएँ**

[remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) किसी विशिष्ट आकृति ऑब्जेक्ट को उसके संग्रह से हटाता है। अनुक्रमित इटरेशन के दौरान कई मिलान हटाते समय, अंत से शुरू करके इटरेट करें ताकि शेष प्रत्येक इंडेक्स वैध बना रहे।

यह उदाहरण निर्दिष्ट नाम वाली प्रत्येक आकृति को हटाता है। यह वर्तमान इंडेक्स पर आकृति पढ़ता है, न कि स्थिर संग्रह आइटम, और अनावश्यक रूप से आकृति को कास्ट नहीं करता।

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

हटाने के बाद आकृति गिनती और बाद की आकृतियों के इंडेक्स बदल जाते हैं। अप्रभावित आकृतियों के संदर्भ सहेजे गए इंडेक्स की तुलना में अधिक भरोसेमंद रहते हैं। कनेक्टर, एनीमेशन और अन्य प्रस्तुति सुविधाओं को भी विचार करें जो हटाए गए ऑब्जेक्ट का उल्लेख कर सकते हैं; दृश्य में एक आकृति हटाने से स्लाइड की दिखावट से अधिक बदल सकता है।

### **आकृति को छुपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) को `true` पर सेट करने से आकृति संग्रह में रहती है लेकिन सामान्य स्लाइड‑शो में दिखाई नहीं देती। उसका इंडेक्स, फॉर्मेटिंग और सामग्री कोड के लिए उपलब्ध रहती है, इसलिए वैकल्पिक तत्वों के लिए जो बाद में पुनः सक्रिय किए जा सकते हैं, छुपाना उपयुक्त है।

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

छुपाना हटाना या सुरक्षा नहीं है। ऑब्जेक्ट को अभी भी खोजा और अनहिड़ किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बना रहता है।

### **Z‑Order बदलें**

ओवरलैपिंग आकृतियों को संग्रह क्रम में पेंट किया जाता है। [reorder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) मौजूदा आकृति को लक्ष्य इंडेक्स पर बिना क्लोन किए ले जाता है। इंडेक्स `0` पीछे है; `size() - 1` आगे।

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

आयत पहले बनाई गई और प्रारम्भ में दीर्घवृत्त के पीछे थी। इसे अंतिम इंडेक्स पर ले जाने से वह आगे आती है। सभी संबंधित आकृतियों को जोड़ने या क्लोन करने के बाद z‑order को अंतिम रूप दें, क्योंकि ये ऑपरेशन नए संग्रह आइटम जोड़ते या सम्मिलित करते हैं और इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड्स पर आकृतियों का निरीक्षण करें**

सामान्य स्लाइड, लेआउट स्लाइड और मास्टर स्लाइड के अलग-अलग आकृति संग्रह होते हैं। लेआउट संग्रह में एक आकृति सामान्य स्लाइड पर समान स्थिति वाली आकृति के समान ऑब्जेक्ट नहीं होती। लेआउट द्वारा प्रदान किए गए फॉर्मेट को समझने या बदलने की आवश्यकता होने पर लेआउट आकृतियों का निरीक्षण करें।

निम्न उदाहरण प्रत्येक लेआउट आकृति के [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getFillFormat--) और [LineFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getLineFormat--) को बिना यह मानते हुए पढ़ता है कि प्रत्येक आकृति `AutoShape` है।

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

लेआउट को संपादित करने से उस पर निर्भर कई स्लाइड प्रभावित हो सकती हैं। लेआउट आकृति को बदलने से पहले यह निर्धारित करें कि सामान्य स्लाइड ऑब्जेक्ट को विरासत में मिल रहा है या स्थानीय रूप से ओवरराइड किया गया है, और उस लेआउट का उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **आकृति को SVG में निर्यात करें**

[writeAsSvg](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) एक आकृति की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल वह आकृति होती है, पूरी स्लाइड पृष्ठभूमि या पड़ोसी आकृतियाँ नहीं।

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

रेंडरिंग के दौरान प्रस्तुति खुली रखें। आउटपुट आकृति के फॉर्मेटिंग और फ़ॉन्ट तथा छवियों जैसे संसाधनों पर निर्भर करता है। यदि आपको पूरी कंपोजिशन चाहिए, तो व्यक्तिगत आकृति की बजाय स्लाइड निर्यात करें। कॉलर को स्ट्रीम का स्वामित्व होता है और उसे बंद करना चाहिए।

## **आकृतियों को संरेखित करें**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) ओवरलोड सभी आकृतियों या चयनित संग्रह इंडेक्स को संरेखित कर सकते हैं। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapesalignmenttype/) किनारा, केंद्र रेखा या वितरण मोड निर्दिष्ट करता है। `alignToSlide` को `true` पर सेट करने से स्लाइड किनारे उपयोग होते हैं; `false` पर सेट करने से चयनित आकृतियों को आपस में संरेखित किया जाता है।

निम्न उदाहरण तीन आकृतियों को स्लाइड के शीर्ष किनारे पर संरेखित करता है। लौटाए गए आकृति संदर्भों को संरेखण से ठीक पहले उनके वर्तमान इंडेक्स में परिवर्तित किया जाता है।

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

संगरोपण (Alignment) स्थितियों को बदलता है, z‑order नहीं। सापेक्ष संरेखण के लिए सामान्यतः कम से कम दो आकृतियों की आवश्यकता होती है, जबकि क्षैतिज या ऊर्ध्वाधर वितरण के लिए पर्याप्त आकृतियों की आवश्यकता होती है ताकि अंतराल तय हो सके। मेथड कॉल करने से पहले यदि आप संग्रह को संशोधित करते हैं तो इंडेक्स पुनः गणना करें।

## **आकृति को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज और ऊर्ध्विक फ़्लिप सेटिंग्स तथा घुमाव को संग्रहीत करता है। इसके `getFlipH` और `getFlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप सक्षम करता है, `False` निष्क्रिय करता है, और `NotDefined` अनिर्दिष्ट/डिफ़ॉल्ट स्थिति को रखता है।

इनपुट प्रस्तुति में नीचे एक अनफ़्लिप्ड आकृति है।

![फ़्लिप करने से पहले का आकार](shape_to_be_flipped.png)

उदाहरण प्रत्येक फ्रेम मान को अपरिवर्तित रखता है और केवल दो फ़्लिप सेटिंग को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) सेट करने से संपूर्ण फ्रेम प्रतिस्थापित हो जाता है।

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

सहेजी गई आकृति क्षैतिज और ऊर्ध्विक रूप से प्रतिबिंबित होती है जबकि उसकी स्थिति, आकार और घुमाव समान रहता है।

![फ़्लिप करने के बाद का आकार](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे आकृति पहचानकर्ता के रूप में संग्रह इंडेक्स का उपयोग करना चाहिए?**

केवल अल्पकालिक प्रोसेसिंग के लिए जब संग्रह ऑपरेशन के दौरान नहीं बदलता। निर्मित टेम्पलेट के लिए मान्य `Name` या `AlternativeText` नियम अपनाएँ, या स्लाइड‑स्कोप इंटरऑप कार्य के लिए `OfficeInteropShapeId` उपयोग करें।

**क्या आकृति को छुपाने से वह z‑order से हट जाता है?**

नहीं। छुपी हुई आकृति वही इंडेक्स पर संग्रह में बनी रहती है। उसे खोजा, पुनः क्रमित, संपादित या फिर से दृश्यमान किया जा सकता है।

**क्लोन की गई आकृति दूसरे आकृति के सामने क्यों दिखाई दी?**

`addClone` क्लोन को संग्रह के अंत में जोड़ता है, जो z‑order का सामने वाला भाग है। प्रारंभिक इंडेक्स चुनने के लिए `insertClone` उपयोग करें या सभी आकृतियों को जोड़ने के बाद `reorder` करें।

**क्या मैं पूर्व निर्धारित आकृति समायोजन को पहचानने के लिए स्थिर इंडेक्स उपयोग कर सकता हूँ?**

केवल तब जब आप सटीक पूर्व निर्धारित और संग्रह लेआउट की पुष्टि कर लें। `IGeometryShape.getAdjustments` के माध्यम से इटरेट करें और `IAdjustValue.getType` की जाँच करें; जब समान अर्थ वाला प्रकार कई बार आता है तो अतिरिक्त जानकारी के लिए `IAdjustValue.getName` उपयोग करें।