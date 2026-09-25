---
title: Android पर प्रस्तुति आकारों का प्रबंधन
linktitle: आकार हेरफेर
type: docs
weight: 40
url: /hi/androidjava/shape-manipulations/
keywords:
- PowerPoint आकार
- प्रेज़ेंटेशन आकार
- स्लाइड पर आकार
- आकार खोजें
- आकार क्लोन करें
- आकार हटाएँ
- आकार छिपाएँ
- आकार क्रम बदलें
- इंटरऑप आकार ID प्राप्त करें
- आकार वैकल्पिक टेक्स्ट
- आकार समायोजन बिंदु
- प्रीसेट आकार समायोजन
- आकार ज्योमेट्री
- आकार लेआउट स्वरूप
- आकार SVG के रूप में
- आकार को SVG में
- आकार संरेखित करें
- आकार फ़्लिप करें
- PowerPoint
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ प्रस्तुति आकारों की पहचान, समायोजन, क्लोन, हटाना, छुपाना, पुनः क्रमबद्ध करना, निर्यात, संरेखण और फ़्लिप कैसे करें, सीखें।"
---
## **सारांश**

Aspose.Slides for Android via Java स्लाइड पर आकारों को क्रमबद्ध [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/) के रूप में दर्शाता है। यह संग्रह आकारों को खोजने और संशोधित करने के साथ‑साथ उनके स्टै킹 क्रम का स्रोत भी है: इंडेक्स `0` सबसे पीछे वाला आकार है, जबकि अंतिम इंडेक्स सबसे आगे वाला आकार है।

यह लेख उसी मॉडल का उपयोग करता है। यह सबसे पहले बताता है कि किसी आकार की पहचान विश्वसनीय रूप से कैसे करें और प्रीसेट आकार समायोजन बिंदुओं को कैसे संशोधित करें, फिर क्लोन, हटाना, छिपाना और पुन: क्रमबद्ध करने के तरीके दिखाता है। अंतिम भाग लेआउट‑स्तर के फ़ॉर्मेटिंग, SVG निर्यात, संरेखण और फ़्लिप सेटिंग्स को कवर करता है। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल वही संचालन उपयोग कर सकते हैं जो आपके वर्कफ़्लो को आवश्यक हों।

## **आकारों की पहचान और खोज**

कलेक्शन इंडेक्स ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थिर पहचानकर्ता नहीं होते। कोई आकार जोड़ने, हटाने या पुनः क्रमबद्ध करने से उसका इंडेक्स बदल सकता है। प्रस्तुति के लेखन और रख‑रखाव के अनुसार एक पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getName--) डेवलपर‑नियंत्रित टेम्प्लेट्स के लिए उपयोगी है और PowerPoint की Selection Pane में आसानी से देखा जा सकता है। नामों को संपादित किया जा सकता है और वे अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड उन पर निर्भर है तो एक नामकरण मानक स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getAlternativeText--) तब उपयोगी है जब पहुंच‑योग्यता विवरण या लेखक‑द्वारा प्रदान किया गया टैग पहले से ही आकार की पहचान करता हो। यह उपयोगकर्ताओं के लिए दिखता है, इसे स्थानीयकृत या पहुंच‑योग्यता के लिए पुनः लिखा जा सकता है, और यह अनिवार्य नहीं कि अद्वितीय हो। अर्थपूर्ण पहुंच‑योग्यता पाठ को चुपके से डेटाबेस कुंजी के रूप में उपयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय है और PowerPoint इंटरऑप द्वारा उपयोग किए जाने वाले आकार ID से मेल खाता है। इसे PowerPoint के साथ एकीकृत करते समय या जब आपको आकार के जीवन‑चक्र के दौरान स्पष्ट संदर्भ चाहिए तब उपयोग करें। क्लोन या पुनः‑निर्मित आकार एक अलग आकार होता है और उसका अपना ID प्राप्त करता है।

संबंधित [getUniqueId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getUniqueId--) विधि प्रस्तुति‑स्तर का पहचानकर्ता लौटाती है, लेकिन यह पहचानकर्ता ऐड‑इन्स के लिये अभिप्रेत है और पुनः‑असाइन किया जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो मैपिंग को एप्लिकेशन डेटा में रखें और सत्यापित करें कि अपेक्षित आकार अभी भी मौजूद है।

वैकल्पिक टेक्स्ट शीर्षक और विवरण दोनों को पढ़ने और अद्यतन करने के एक व्यावहारिक उदाहरण के लिये देखें [Manage Alternative Text Titles and Descriptions](/slides/hi/androidjava/presentation-accessibility/)। वैकल्पिक टेक्स्ट का उपयोग दृश्य के अर्थ को पाठकों को समझाने के लिये करें, और इसे कोड द्वारा आकार खोजने हेतु उपयोग किए जाने वाले आकार नामों से अलग रखें।

नीचे दिया गया उदाहरण नाम द्वारा सटीक तुलना करता है और स्लाइड‑स्कोप्ड इंटरऑप ID की रिपोर्ट करता है। जब टेम्प्लेट में अपेक्षित आकार नहीं मिलता, तो कोड परिणाम को रिपोर्ट करता है और गलत वस्तु के साथ जारी नहीं रहता।

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

जब कोई ऑपरेशन किसी विशेष आकार प्रकार के लिए विशिष्ट हो, तो प्रकार‑विशिष्ट सदस्य उपयोग करने से पहले इंटरफ़ेस की जाँच करें। यह उदाहरण केवल तभी टेक्स्ट और वैकल्पिक टेक्स्ट को अपडेट करता है जब नामित वस्तु एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) हो।

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

## **प्रीसेट आकार समायोजन की पहचान और संशोधन**

प्रीसेट जियोमेट्री आकार समायोजन बिंदु उजागर कर सकते हैं जो कोने का आकार, तीर अनुपात या धारा कोण जैसी विशेषताओं को नियंत्रित करते हैं। इन्हें केवल‑पढ़ने योग्य [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) संग्रह के माध्यम से एक्सेस करें। यह संग्रह स्वयं आकार द्वारा प्रदान किया जाता है, लेकिन प्रत्येक [IAdjustValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iadjustvalue/) में एक मान होता है जिसे बदला जा सकता है।

केवल स्थिर कलेक्शन इंडेक्स पर भरोसा न करें। समायोजनों के माध्यम से इटरेट करें और केवल‑पढ़ने योग्य [getType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iadjustvalue/#getType--) विधि की जाँच करें, जिसकी [ShapeAdjustmentType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapeadjustmenttype/) मूल्य बताता है कि समायोजन क्या नियंत्रित करता है। केवल‑पढ़ने योग्य [getName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iadjustvalue/#getName--) विधि अतिरिक्त पहचान जानकारी प्रदान करती है और विशेष रूप से उपयोगी है जब कोई प्रीसेट समान अर्थ वाले कई समायोजन रखता हो।

समायोजन के अर्थ के साथ मेल खाने वाली वैल्यू विधि का उपयोग करें:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | गोल कोनों का आकार | [setRawValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | तीर के पूंछ की मोटाई | `setRawValue` |
| `ArrowheadLength` | तीर के सिर का लंबाई | `setRawValue` |
| `ArrowheadWidth` | तीर के सिर की चौड़ाई | `setRawValue` |
| `StartAngle` | पाई या धारा का प्रारंभिक कोण | [setAngleValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | पाई या धारा का समाप्ति कोण | `setAngleValue` |

`getType` और `getName` केवल‑पढ़ने योग्य जानकारी लौटाते हैं। `getRawValue` और `setRawValue` प्रीसेट की मूल जियोमेट्री इकाइयों में एक पूर्णांक के साथ काम करते हैं, जबकि `getAngleValue` और `setAngleValue` डिग्री में कोण के साथ काम करते हैं। समायोजन की संख्या, क्रम, अर्थ और वैध रेंज प्रीसेट [ShapeType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) पर निर्भर करती है। एक प्रीसेट के लिये वैध मान दूसरे प्रीसेट के लिये अमान्य या अलग प्रभाव वाला हो सकता है।

जब `getType` `ShapeAdjustmentType.Custom` लौटाता है, तो API कोई मानक अर्थ पहचान नहीं पाती। `getName`, प्रीसेट प्रकार और मौजूदा मान की जाँच करें, और तब तक समायोजन को अपरिवर्तित रखें जब तक कि अपेक्षित अर्थ और रेंज ज्ञात न हों। मान्य प्रकारों के लिये भी, मूल्य चुनने से पहले जाँचें कि क्या वही प्रकार दो बार से अधिक मौजूद है। कनेक्टर बेंड समायोजन के मामले के लिये [Connector](/slides/hi/androidjava/connector/) लेख देखें।

निम्नलिखित पूर्ण उदाहरण तीन प्रीसेट आकारों के डिफ़ॉल्ट और संशोधित संस्करण बनाता है। यह प्रत्येक समायोजन पर इटरेट करता है, उसका नाम और प्रकार रिपोर्ट करता है, `setRawValue` के द्वारा आकार‑संबंधी मान बदलता है, `setAngleValue` के द्वारा कोण बदलता है, और परिणाम सहेजता है। बाएँ कॉलम में डिफ़ॉल्ट जियोमेट्री बनी रहती है; दाएँ कॉलम में समायोजित गोल आयत, चार‑तरफ़ा तीर, और पाई दिखाए गए हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // डिफ़ॉल्ट और समायोजित आकार कॉलमों के लिए हेडर जोड़ता है।
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

मान बदलने से पहले अर्थ‑प्रकार की जाँच करने से कोड अपने इरादे को स्पष्ट रूप से दर्शाता है और यह मानने से बचता है कि कोई विशेष कलेक्शन इंडेक्स विभिन्न प्रीसेट आकारों में समान अर्थ रखता हो।

## **आकार संग्रह का संशोधन**

add, clone, remove, और reorder विधियाँ संग्रह पर तुरंत प्रभाव डालती हैं। यदि कोई ऑपरेशन आकारों की संख्या या क्रम को बदलता है, तो उस ऑपरेशन से पहले कैप्चर किए गए इंडेक्स पर निर्भर नहीं रहना चाहिए।

### **एक आकार को क्लोन करें**

[addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) एक स्वतंत्र प्रतिलिपि बनाता है और उसे लक्ष्य संग्रह में जोड़ता है। [insertClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) भी एक प्रतिलिपि बनाता है लेकिन उसे निर्दिष्ट z‑order इंडेक्स पर रखता है। जो ओवरलोड निर्देशांक स्वीकार करते हैं, वे आकार का आकार बदले बिना क्लोन को स्थानांतरित करते हैं; चौड़ाई‑और‑ऊँचाई वाले ओवरलोड इसे पुनः‑आकार दे सकते हैं।

उदाहरण एक गंतव्य स्लाइड बनाता है, लेबल वाले आयत को सामने क्लोन करता है, और दूसरा क्लोन पीछे सम्मिलित करता है। किसी भी क्लोन में बदलाव स्रोत आकार को प्रभावित नहीं करता।

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

क्लोनिंग आकार की सामग्री और फ़ॉर्मेटिंग, जिसमें उसका नाम और वैकल्पिक टेक्स्ट शामिल है, को कॉपी करता है। यदि इन मानों को अद्वितीय होना आवश्यक है, तो क्लोन को नए तर्कसंगत पहचानकर्ता सौंपें। जटिल आकारों द्वारा उपयोग किए गए संसाधन प्रस्तुति द्वारा संभाले जाते हैं, लेकिन क्लोन अभी भी एक नया संग्रह आइटम और नई आकार पहचान के साथ रहता है।

### **आकार हटाएं**

[remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) किसी विशिष्ट आकार वस्तु को उसके संग्रह से हटाता है। जब इंडेक्स‑आधारित इटरेशन के दौरान कई मिलते हुए आकार हटाते हैं, तो अंत से ट्रैवर्स करें ताकि शेष प्रत्येक इंडेक्स वैध बना रहे।

यह उदाहरण निर्दिष्ट नाम वाले प्रत्येक आकार को हटाता है। यह वर्तमान इंडेक्स पर आकार पढ़ता है, न कि किसी स्थिर संग्रह आइटम को, और आकार को अनावश्यक रूप से कास्ट नहीं करता।

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

हटाने के बाद आकारों की गिनती और बाद के आकारों के इंडेक्स बदल जाते हैं। अप्रभावित आकारों के संदर्भ सहेजे गए इंडेक्स की तुलना में अधिक विश्वसनीय रहते हैं। कनेक्टर, एनीमेशन और अन्य प्रस्तुति सुविधाओं पर भी विचार करें जो हटाए गए वस्तु को संदर्भित कर सकती हैं; एक दृश्यमान आकार को हटाने से स्लाइड की उपस्थिति से अधिक बदलाव हो सकते हैं।

### **एक आकार को छुपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) को `true` करने से आकार संग्रह में बना रहता है लेकिन सामान्य स्लाइड शो में दिखाई नहीं देता। उसका इंडेक्स, फ़ॉर्मेटिंग और सामग्री कोड के लिये उपलब्ध रहती है, इसलिए छुपाना वैकल्पिक तत्वों के लिये उपयुक्त है जिन्हें बाद में पुनः प्रदर्शित किया जा सकता है।

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

छुपाना हटाना या सुरक्षा नहीं है। वस्तु को अभी भी उपयोगकर्ता या कोड द्वारा खोजा और अनहिड़ किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बनी रहती है।

### **Z‑Order बदलें**

ओवरलैपिंग आकार संग्रह क्रम में पेंट किए जाते हैं। [reorder](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) मौजूदा आकार को लक्ष्य इंडेक्स पर ले जाता है बिना क्लोन किए। इंडेक्स `0` पीछे है; `size() - 1` आगे है।

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

आयत पहले बनाया जाता है और प्रारंभ में दीर्घवृत्त के पीछे रहता है। इसे अंतिम इंडेक्स पर ले जाने से वह आगे आ जाता है। सभी संबंधित आकारों को जोड़ने या क्लोन करने के बाद Z‑order को अंतिम रूप दें, क्योंकि ये ऑपरेशन नए संग्रह आइटम जोड़ते या सम्मिलित करते हैं और इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड पर आकारों का निरीक्षण करें**

सामान्य स्लाइड, लेआउट स्लाइड और मास्टर स्लाइड के अलग‑अलग आकार संग्रह होते हैं। लेआउट संग्रह में एक आकार सामान्य स्लाइड पर समान स्थिति वाले आकार के समान वस्तु नहीं होता। जब आपको लेआउट द्वारा प्रदान किए गए फ़ॉर्मेटिंग को समझना या बदलना हो, तो लेआउट आकारों का निरीक्षण करें।

निम्न例 प्रत्येक लेआउट आकार की [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getFillFormat--) और [LineFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getLineFormat--) को पढ़ता है, बिना यह मानते हुए कि हर आकार `AutoShape` है।

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

लेआउट को संपादित करने से उसे उपयोग करने वाली कई स्लाइडों पर प्रभाव पड़ सकता है। लेआउट आकार बदलने से पहले यह निर्धारित करें कि कोई सामान्य स्लाइड वस्तु को विरासत में लेती है या उसमें स्थानीय अधिलेखित है, और उस लेआउट को उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **एक आकार को SVG में निर्यात करें**

[writeAsSvg](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) एक आकार की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल वह आकार होता है, न कि पूरी स्लाइड पृष्ठभूमि या आसपास के आकार।

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

रेंडरिंग के दौरान प्रस्तुति को खुला रखें। आउटपुट आकार के फ़ॉर्मेटिंग तथा फ़ॉन्ट और छवियों जैसे संसाधनों पर निर्भर करता है। यदि आपको पूरी रचना चाहिए, तो व्यक्तिगत आकार के बजाय स्लाइड निर्यात करें। कॉलर को स्ट्रीम का स्वामित्व होता है और उसे बंद करना चाहिए।

## **आकारों को संरेखित करें**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) ओवरलोड सभी आकारों या चयनित संग्रह इंडेक्स को संरेखित करता है। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapesalignmenttype/) किनारा, केंद्र रेखा या वितरण मोड निर्दिष्ट करता है। `alignToSlide` को `true` करने से स्लाइड किनारे उपयोग होते हैं; `false` करने से चयनित आकार एक‑दूसरे के सापेक्ष संरेखित होते हैं।

यह उदाहरण तीन आकारों को स्लाइड के शीर्ष किनारे के साथ संरेखित करता है। लौटाए गए आकार संदर्भों को संरेखण से ठीक पहले उनके वर्तमान इंडेक्स में बदला जाता है।

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

संरेखण स्थिति को बदलता है, न कि Z‑order को। सापेक्ष संरेखण के लिये सामान्यतः कम से कम दो आकार आवश्यक होते हैं, जबकि क्षैतिज या लंबवत वितरण के लिये पर्याप्त आकारों की आवश्यकता होती है ताकि अंतराल परिभाषित हो सके। विधि को कॉल करने से पहले यदि आप संग्रह को संशोधित करते हैं तो इंडेक्स को पुनः‑गणना करें।

## **एक आकार को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapeframe/) वर्ग स्थिति, आकार, क्षैतिज और लंबवत फ़्लिप सेटिंग्स, तथा घूर्णन को संग्रहीत करता है। उसके `getFlipH` और `getFlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप को सक्षम करता है, `False` उसे निष्क्रिय करता है, और `NotDefined` अनिर्दिष्ट/डिफ़ॉल्ट स्थिति को बनाए रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक अनफ़्लिप्ड आकार रखती है।

![The shape before flipping](shape_to_be_flipped.png)

उदाहरण सभी अन्य फ्रेम मानों को अपरिवर्तित रखता है और केवल दो फ़्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) सेट करने से पूरी फ्रेम बदल जाती है।

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

सहेजा गया आकार क्षैतिज और लंबवत दोनों रूप में प्रतिबिंबित होता है, जबकि उसकी स्थिति, आकार और घूर्णन अपरिवर्तित रहता है।

![The shape after flipping](flipped_shape.png)

## **FAQ**

**क्या मुझे आकार पहचानकर्ता के रूप में कलेक्शन इंडेक्स का उपयोग करना चाहिए?**

केवल अल्पकालिक प्रोसेसिंग के लिये जब संग्रह ऑपरेशन के बाद नहीं बदलता। निर्मित टेम्प्लेट्स के लिये वैध `Name` या `AlternativeText` मानक अपनाएँ, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिये `OfficeInteropShapeId` का प्रयोग करें।

**क्या आकार को छुपाने से वह Z‑order से हट जाता है?**

नहीं। छिपा आकार उसी इंडेक्स पर संग्रह में बना रहता है। इसे फिर से पाया, पुनः‑क्रमबद्ध, संपादित या दृश्यमान किया जा सकता है।

**क्लोन किया गया आकार दूसरी आकार के सामने क्यों आया?**

`addClone` क्लोन को संग्रह के अंत में जोड़ता है, जो Z‑order का फ्रंट होता है। प्रारंभिक इंडेक्स चुनने के लिये `insertClone` का प्रयोग करें या सभी आकार जोड़ने के बाद `reorder` करें।

**क्या मैं प्रीसेट आकार समायोजन को पहचाने के लिये एक स्थिर इंडेक्स का उपयोग कर सकता हूँ?**

सिर्फ तब जब आप ठीक‑ठीक प्रीसेट और संग्रह लेआउट को मान्य कर चुके हों। `IGeometryShape.getAdjustments` के माध्यम से इटरेट करके `IAdjustValue.getType` की जाँच करना बेहतर है; जब समान अर्थ वाले कई समायोजन हों तो अतिरिक्त जानकारी के लिये `IAdjustValue.getName` प्रयोग करें।