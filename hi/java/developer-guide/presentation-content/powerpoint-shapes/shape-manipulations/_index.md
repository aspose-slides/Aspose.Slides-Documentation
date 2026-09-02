---
title: Java में प्रस्तुति आकारों का प्रबंधन
linktitle: आकार हेरफेर
type: docs
weight: 40
url: /hi/java/shape-manipulations/
keywords:
- PowerPoint आकार
- प्रस्तुति आकार
- स्लाइड पर आकार
- आकार खोजें
- आकार क्लोन करें
- आकार हटाएँ
- आकार छुपाएँ
- आकार क्रम बदलें
- इंटरऑप आकार ID प्राप्त करें
- आकार वैकल्पिक पाठ
- आकार समायोजन बिंदु
- पूर्वनिर्धारित आकार समायोजन
- आकार ज्यामिति
- आकार लेआउट स्वरूप
- आकार SVG के रूप में
- आकार को SVG में
- आकार संरेखित करें
- आकार फ़्लिप करें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ प्रस्तुति आकारों की पहचान, समायोजन, क्लोन, हटाना, छुपाना, क्रम बदलना, निर्यात, संरेखण और फ़्लिप करना सीखें।"
---
## **परिचय**

Aspose.Slides for Java स्लाइड पर आकारों को क्रमबद्ध [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/) के रूप में दर्शाता है। यह संग्रह वह स्थान है जहाँ आप आकारों को खोजते और संशोधित करते हैं और उनका स्टैक क्रम का स्रोत भी है: सूचकांक `0` सबसे पीछे का आकार है, जबकि अंतिम सूचकांक सबसे आगे का आकार है।

यह लेख उसी मॉडल को अपनाता है। पहले यह बताता है कि कैसे किसी आकार को विश्वसनीय रूप से पहचाना जाए और पूर्वनिर्धारित आकार समायोजन बिंदुओं को संशोधित किया जाए, फिर क्लोन, हटाना, छुपाना और क्रमबद्ध करने के तरीके दिखाता है। अंतिम भाग लेआउट‑स्तर फ़ॉर्मेटिंग, SVG निर्यात, संरेखण और फ़्लिप सेटिंग्स को शामिल करता है। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल उन संचालन को उपयोग कर सकते हैं जो आपके कार्यप्रवाह की आवश्यकता है।

## **आकारों की पहचान और खोज**

संग्रह सूचकांक किसी ज्ञात फ़ाइल को संसाधित करते समय सुविधाजनक होते हैं, लेकिन वे स्थायी पहचानकर्ता नहीं होते। आकार जोड़ने, हटाने या पुनः क्रमबद्ध करने से उसका सूचकांक बदल सकता है। प्रस्तुति के निर्माण और रखरखाव के तरीके के अनुसार पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getName--) उन डेवलपर‑नियंत्रित टेम्पलेट्स के लिए उपयोगी है और PowerPoint के Selection Pane में आसानी से देखा जा सकता है। नाम संपादित किए जा सकते हैं और अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड उन पर निर्भर करता है तो नामकरण सम्मेलन स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getAlternativeText--) तब उपयोगी है जब कोई अभिगम्यता विवरण या लेखक‑द्वारा दिया गया टैग पहले से आकार की पहचान करता हो। यह उपयोगकर्ताओं को दिखाई देता है, इसे स्थानीयकृत या अभिगम्यता के लिए पुनः लिखा जा सकता है, और यह अनिवार्य रूप से अद्वितीय नहीं है। अर्थपूर्ण अभिगम्यता पाठ को बिना संकेत के डेटाबेस कुंजी के रूप में पुनः प्रयुक्त न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय है और PowerPoint इंटरऑप द्वारा उपयोग किए जाने वाले आकार ID के अनुरूप है। PowerPoint के साथ एकीकरण या आकार के जीवनकाल के दौरान स्पष्ट संदर्भ की आवश्यकता होने पर इसका उपयोग करें। क्लोन या पुनः निर्मित आकार अलग होते हैं और उनका अपना ID मिलता है।

संबंधित [getUniqueId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getUniqueId--) विधि प्रस्तुति स्कोप के साथ एक पहचानकर्ता लौटाती है, लेकिन यह पहचानकर्ता ऐड‑इन्स के लिए है और पुनः असाइन किया जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है तो मैपिंग को एप्लिकेशन डेटा में रखें और सत्यापित करें कि अपेक्षित आकार अभी भी मौजूद है।

निम्न उदाहरण सटीक तुलना के साथ नाम द्वारा खोज करता है और स्लाइड‑स्कोप्ड इंटरऑप ID रिपोर्ट करता है। जब टेम्पलेट में अपेक्षित आकार नहीं होता, तो कोड वह परिणाम रिपोर्ट करता है बजाय गलत ऑब्जेक्ट के साथ जारी रहने के।

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

जब कोई ऑपरेशन विशेष प्रकार के आकार के लिए हो, तो टाइप‑विशिष्ट सदस्य उपयोग करने से पहले इंटरफ़ेस जांचें। यह उदाहरण केवल तब टेक्स्ट और वैकल्पिक टेक्स्ट अपडेट करता है जब नामित ऑब्जेक्ट एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) हो।

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

## **पूर्वनिर्धारित आकार समायोजन की पहचान और संशोधन**

पूर्वनिर्धारित ज्यामिति आकार समायोजन बिंदु प्रदान कर सकते हैं जो कोने का आकार, तीर अनुपात, या आर्क कोण जैसी विशेषताओं को नियंत्रित करते हैं। इन्हें केवल‑पढ़ने योग्य [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igeometryshape/#getAdjustments--) संग्रह के माध्यम से एक्सेस करें। संग्रह स्वयं आकार द्वारा प्रदान किया जाता है, लेकिन प्रत्येक [IAdjustValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/) में एक मान होता है जिसे बदला जा सकता है।

केवल स्थिर संग्रह सूचकांक पर निर्भर न रहें। समायोजनों पर इटरिटेट करें और केवल‑पढ़ने योग्य [getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#getType--) विधि का निरीक्षण करें, जिसका [ShapeAdjustmentType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapeadjustmenttype/) मान बताता है कि समायोजन क्या नियंत्रित करता है। केवल‑पढ़ने योग्य [getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#getName--) विधि अतिरिक्त पहचान जानकारी प्रदान करती है और तब विशेष रूप से उपयोगी होती है जब किसी पूर्वनिर्धारित में समान अर्थ वाले एक से अधिक समायोजन हों।

समायोजन के अर्थ से मेल खाने वाली मान विधि का उपयोग करें:

| समायोजन प्रकार | उद्देश्य | बदलने के लिए मान |
|---|---|---|
| `CornerSize` | गोल किनारों का आकार | [setRawValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | तीर की पूंछ की मोटाई | `setRawValue` |
| `ArrowheadLength` | तीर के सिर का लंबाई | `setRawValue` |
| `ArrowheadWidth` | तीर के सिर की चौड़ाई | `setRawValue` |
| `StartAngle` | पाई या आर्क का प्रारंभिक कोण | [setAngleValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | पाई या आर्क का अंतिम कोण | `setAngleValue` |

`getType` और `getName` केवल‑पढ़ने योग्य जानकारी लौटाते हैं। `getRawValue` और `setRawValue` पूर्वनिर्धारित की मूल ज्यामिति इकाइयों में पूर्णांक के साथ काम करते हैं, जबकि `getAngleValue` और `setAngleValue` डिग्री में कोण के साथ काम करते हैं। समायोजन की संख्या, क्रम, अर्थ और वैध सीमा पूर्वनिर्धारित [ShapeType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igeometryshape/#getShapeType--) पर निर्भर करती है। एक पूर्वनिर्धारित के लिए वैध मान दूसरे के लिए अमान्य या अलग प्रभाव रख सकता है।

जब `getType` `ShapeAdjustmentType.Custom` लौटाता है, तो API मानक अर्थ नहीं पहचानती। `getName`, पूर्वनिर्धारित प्रकार और मौजूदा मान का निरीक्षण करें, और जब तक अपेक्षित अर्थ और सीमा ज्ञात न हों तब तक समायोजन को अपरिवर्तित छोड़ें। पहचाने गए प्रकारों के लिए भी, मान चुनने से पहले जांचें कि क्या वही प्रकार दो या अधिक बार आता है। कनेक्टर मोड़ समायोजनों के साथ इस स्थिति को [Connector](/slides/hi/java/connector/) लेख दर्शाता है।

निम्न पूर्ण उदाहरण तीन पूर्वनिर्धारित आकारों के डिफ़ॉल्ट और संशोधित संस्करण बनाता है। यह प्रत्येक समायोजन पर इटरिटेट करता है, उसके नाम और प्रकार को रिपोर्ट करता है, `setRawValue` से आकार‑संबंधित मान बदलता है, `setAngleValue` से कोण बदलता है, और परिणाम सहेजता है। बायाँ कॉलम डिफ़ॉल्ट ज्यामिति रखता है; दायाँ कॉलम समायोजित गोल आयत, चार‑दीशा तीर और पाई दिखाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // डिफ़ॉल्ट और समायोजित आकार कॉलमों के लिए शीर्षक जोड़ता है।
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

मान बदलने से पहले अर्थ प्रकार की जाँच करने से कोड के इरादे स्पष्ट होते हैं और यह मानने से बचते हैं कि विभिन्न पूर्वनिर्धारित आकारों में कोई विशेष संग्रह सूचकांक समान अर्थ रखता है।

## **आकार संग्रह संशोधित करें**

जोड़ना, क्लोन करना, हटाना और पुनः क्रमबद्ध करने वाली विधियाँ संग्रह पर तुरंत प्रभाव डालती हैं। यदि कोई ऑपरेशन आकारों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले पकड़े गए सूचकांकों पर निर्भरता जारी न रखें।

### **एक आकार क्लोन करें**

[addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) एक स्वतंत्र कॉपी बनाता है और उसे लक्ष्य संग्रह में जोड़ता है। [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) भी कॉपी बनाता है लेकिन निर्दिष्ट z‑order सूचकांक पर रखता है। वह ओवरलोड जो निर्देशांक स्वीकार करता है, क्लोन को उसके आकार को बदले बिना ले जाता है; चौड़ाई और ऊँचाई वाले ओवरलोड इसे पुनः आकारित भी कर सकते हैं।

यह उदाहरण एक लक्ष्य स्लाइड बनाता है, एक लेबल वाले आयत को सामने की ओर क्लोन करता है, और दूसरे क्लोन को पीछे की ओर सम्मिलित करता है। किसी भी क्लोन में परिवर्तन स्रोत आकार को प्रभावित नहीं करता।

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

क्लोन आकार की सामग्री और फ़ॉर्मेटिंग को कॉपी करता है, जिसमें उसका नाम और वैकल्पिक पाठ शामिल है। जब इन मूल्यों को अद्वितीय होना आवश्यक हो तो क्लोन को नए तर्कसंगत पहचानकर्ता असाइन करें। जटिल आकारों द्वारा उपयोग किए गए संसाधनों को प्रस्तुति संभालती है, लेकिन क्लोन नया संग्रह आइटम रहता है जिसका अपना आकार पहचान होता है।

### **आकार हटाएँ**

[remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) किसी विशिष्ट आकार ऑब्जेक्ट को उसके संग्रह से हटाता है। कई मेलों को हटाते समय, सूचकांकित इटरशन के दौरान अंत से आगे की दिशा में चलें ताकि प्रत्येक शेष सूचकांक मान्य बना रहे।

यह उदाहरण निर्दिष्ट नाम वाले प्रत्येक आकार को हटाता है। यह वर्तमान सूचकांक पर आकार को पढ़ता है, न कि स्थिर संग्रह आइटम को, और आकार को अनावश्यक रूप से कास्ट नहीं करता।

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

हटाने के बाद आकार गिनती और बाद के आकारों के सूचकांक बदलते हैं। अप्रभावित आकारोंへの संदर्भ सहेजे गए सूचकांकों से अधिक भरोसेमंद रहता है। कनेक्टर, एनिमेशन और अन्य प्रस्तुति विशेषताओं पर भी विचार करें जो हटाए गए ऑब्जेक्ट को संदर्भित कर सकते हैं; एक दृश्य आकार को हटाने से स्लाइड की उपस्थिति से अधिक बदलाव हो सकता है।

### **एक आकार छुपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setHidden-boolean-) को `true` सेट करने से आकार संग्रह में बना रहता है लेकिन सामान्य स्लाइड शो में दिखाई नहीं देता। उसका सूचकांक, फ़ॉर्मेटिंग और सामग्री कोड के लिए उपलब्ध रहती है, इसलिए छुपाना वैकल्पिक तत्वों के लिए उपयुक्त है जिन्हें बाद में पुनः सक्रिय किया जा सकता है।

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

छुपाना deletion या security नहीं है। ऑब्जेक्ट अभी भी खोजा जा सकता है और उपयोगकर्ता या कोड द्वारा अनहाइड किया जा सकता है, और यह प्रस्तुति फ़ाइल का भाग बना रहता है।

### **Z‑Order बदलें**

ओवरलैपिंग आकार संग्रह क्रम में पेंट होते हैं। [reorder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) मौजूदा आकार को लक्ष्य सूचकांक पर क्लोन किए बिना ले जाता है। सूचकांक `0` पीछे है; `size() - 1` आगे है।

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

आयत पहले बनाया गया और प्रारम्भ में दीर्घवृत्त के पीछे रहा। इसे अंतिम सूचकांक पर ले जाने से वह आगे आ जाता है। सभी संबंधित आकार जोड़ने या क्लोन करने के बाद z‑order को अंतिम रूप दें, क्योंकि ये संचालन नए संग्रह आइटम जोड़ते या सम्मिलित करते हैं जो इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड्स पर आकार निरीक्षण करें**

सामान्य स्लाइड्स, लेआउट स्लाइड्स, और मास्टर स्लाइड्स के अलग‑अलग आकार संग्रह होते हैं। लेआउट संग्रह में एक आकार वही ऑब्जेक्ट नहीं है जो सामान्य स्लाइड पर समान स्थान पर हो सकता है। लेआउट आकारों का निरीक्षण तब करें जब आपको लेआउट द्वारा प्रदान किए गए फ़ॉर्मेटिंग को समझना या बदलना हो।

निम्न उदाहरण प्रत्येक लेआउट आकार के [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getFillFormat--) और [LineFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getLineFormat--) को पढ़ता है, बिना यह मान लिये कि प्रत्येक आकार एक `AutoShape` है।

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

लेआउट को संपादित करने से उसका उपयोग करने वाली कई स्लाइड्स प्रभावित हो सकती हैं। लेआउट आकार को बदलने से पहले यह निर्धारित करें कि क्या सामान्य स्लाइड ऑब्जेक्ट को विरासत में प्राप्त करती है या उसमें स्थानीय ओवरराइड है, और उस लेआउट का उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **एक आकार को SVG में निर्यात करें**

[writeAsSvg](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) एक आकार की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में आकार ही शामिल होता है, न कि पूरी स्लाइड की पृष्ठभूमि या पास के आकार।

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

रेंडरिंग के दौरान प्रस्तुति को खुला रखें। आउटपुट आकार की फ़ॉर्मेटिंग और फ़ॉन्ट व छवियों जैसे संसाधनों पर निर्भर करता है। यदि आपको पूरी संरचना चाहिए, तो व्यक्तिगत आकार के बजाय स्लाइड निर्यात करें। कॉलर को स्ट्रीम का स्वामित्व होता है और उसे बंद करना चाहिए।

## **आकार संरेखित करें**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) ओवरलोड सभी आकार या चयनित संग्रह सूचकांकों को संरेखित कर सकते हैं। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapesalignmenttype/) किनारा, केंद्र रेखा, या वितरण मोड निर्दिष्ट करता है। `alignToSlide` को `true` सेट करने से स्लाइड किनारे उपयोग होते हैं; `false` करने से चयनित आकार एक‑दूसरे के सापेक्ष संरेखित होते हैं।

यह उदाहरण तीन आकारों को स्लाइड के शीर्ष किनारे पर संरेखित करता है। वापस किए गए आकार संदर्भों को संरेखण से ठीक पहले उनके वर्तमान सूचकांकों में बदला जाता है।

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

समान संरेखण स्थान बदलता है, न कि z‑order। सापेक्ष संरेखण के लिए सामान्यतः कम से कम दो आकार चाहिए, जबकि क्षैतिज या लंबवत वितरण के लिए स्पेसिंग तय करने हेतु पर्याप्त आकार चाहिए। विधि कॉल करने से पहले यदि आप संग्रह को संशोधित करते हैं तो सूचकांकों को पुनः गणना करें।

## **एक आकार को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज और लंबवत फ़्लिप सेटिंग्स, और घूर्णन को संग्रहीत करती है। इसके `getFlipH` और `getFlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/java/com.aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप सक्रिय करता है, `False` निष्क्रिय करता है, और `NotDefined` अस्पष्ट/डिफ़ॉल्ट स्थिति को बरकरार रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक अनफ़्लिप्ड आकार शामिल करता है।

![The shape before flipping](shape_to_be_flipped.png)

उदाहरण प्रत्येक अन्य फ्रेम मान को बरकरार रखता है और केवल दो फ़्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) असाइन करने से पूरा फ्रेम प्रतिस्थापित हो जाता है।

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

सहेजा गया आकार क्षैतिज और लंबवत दोनों दिशा में प्रतिबिंबित होता है जबकि उसकी स्थिति, आकार और घूर्णन समान रहता है।

![The shape after flipping](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे आकार पहचानकर्ता के रूप में संग्रह सूचकांक का उपयोग करना चाहिए?**

केवल तब जब संग्रह बदलने की संभावना न हो और प्रक्रिया अल्पकालिक हो। निर्मित टेम्पलेट्स के लिये सत्यापित `Name` या `AlternativeText` सम्मेलन उपयोग करें, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिये `OfficeInteropShapeId`।

**क्या आकार छुपाने से वह z‑order से हट जाता है?**

नहीं। छुपा हुआ आकार उसी सूचकांक पर संग्रह में बना रहता है। इसे खोजा, पुनः क्रमबद्ध, संपादित या दोबारा दृश्यमान किया जा सकता है।

**क्लोन किया गया आकार दूसरे आकार के सामने क्यों दिखा?**

`addClone` क्लोन को संग्रह के अंत में जोड़ता है, जो z‑order का सामने वाला हिस्सा होता है। प्रारम्भिक सूचकांक चुनने के लिये `insertClone` उपयोग करें या सभी आकार जोड़ने के बाद `reorder` करें।

**क्या मैं पूर्वनिर्धारित आकार समायोजन को पहचानने के लिये स्थिर सूचकांक उपयोग कर सकता हूँ?**

केवल तभी जब आप सटीक पूर्वनिर्धारित और संग्रह लेआउट को सत्यापित कर चुके हों। `IGeometryShape.getAdjustments` पर इटरिटेट करके `IAdjustValue.getType` की जांच करें; जब समान अर्थ वाला प्रकार एक से अधिक बार आता है तो अतिरिक्त जानकारी के लिये `IAdjustValue.getName` का उपयोग करें।