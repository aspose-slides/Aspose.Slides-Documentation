---
title: जावा में प्रस्तुति आकारों का प्रबंधन
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
- आकार वैकल्पिक टेक्स्ट
- आकार समायोजन बिंदु
- प्रीसेट आकार समायोजन
- आकार ज्योमैट्री
- आकार लेआउट स्वरूप
- SVG के रूप में आकार
- आकार को SVG में
- आकार संरेखित करें
- आकार फ़्लिप करें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ प्रस्तुति आकारों को पहचानने, समायोजित करने, क्लोन करने, हटाने, छुपाने, पुनः क्रमित करने, निर्यात करने, संरेखित करने और फ़्लिप करने के तरीके जानें।"
---
## **अवलोकन**

Aspose.Slides for Java स्लाइड पर आकारों को क्रमबद्ध [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/) के रूप में प्रस्तुत करता है। यह संग्रह आकारों को खोजने और संशोधित करने का स्थान है और उनकी स्टैकिंग क्रम का स्रोत भी है: इंडेक्स `0` सबसे पीछे का आकार है, जबकि अंतिम इंडेक्स सबसे आगे का आकार है।

यह लेख उसी मॉडल का अनुसरण करता है। यह पहले यह बताता है कि किसी आकार की विश्वसनीय पहचान कैसे करें और प्रीसेट आकार समायोजन बिंदुओं को कैसे संशोधित करें, फिर दिखाता है कि आकारों को क्लोन, हटाया, छुपाया और पुनः क्रमित कैसे किया जाए। अंतिम भाग लेआउट‑स्तर की फ़ॉर्मेटिंग, SVG निर्यात, संरेखण और फ़्लिप सेटिंग्स को कवर करता है। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल वही ऑपरेशन्स उपयोग कर सकते हैं जो आपके कार्य‑प्रवाह के लिए आवश्यक हैं।

## **आकारों की पहचान और खोज**

संग्रह इंडेक्स ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थिर पहचानकर्ता नहीं होते। आकार को जोड़ने, हटाने या पुनः क्रमित करने से उसका इंडेक्स बदल सकता है। प्रस्तुति के लेखन और रख‑रखाव के तरीके के अनुसार एक पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getName--) तब उपयोगी है जब टेम्पलेट डेवलपर‑नियंत्रित हो और PowerPoint के Selection Pane में आसानी से निरीक्षण किया जा सके। नामों को संपादित किया जा सकता है और वे अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड उन पर निर्भर करता है तो एक नामकरण मानक स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getAlternativeText--) तब उपयोगी है जब किसी अभिगम्यता विवरण या लेखक‑द्वारा प्रदान किया गया टैग पहले से आकार की पहचान करता हो। यह उपयोगकर्ताओं को दिखाई देता है, अभिगम्यता के लिये स्थानीयकृत या पुनः‑लिखा जा सकता है, और अनिवार्य रूप से अद्वितीय नहीं होता। अर्थपूर्ण अभिगम्यता टेक्स्ट को मौन रूप से डेटाबेस कुंजी के रूप में पुनः प्रयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय है और PowerPoint इंटरऑप द्वारा उपयोग किए जाने वाले आकार ID से मेल खाता है। इसे PowerPoint के साथ एकीकरण करते समय या किसी आकार के जीवनकाल के दौरान अस्पष्ट संदर्भ की आवश्यकता होने पर उपयोग करें। क्लोन किए गए या पुनः‑सृजित आकार एक अलग आकार होते हैं और उनका अपना ID मिलता है।

संबंधित [getUniqueId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getUniqueId--) मेथड प्रस्तुति‑स्कोप के साथ एक पहचानकर्ता लौटाता है, लेकिन वह पहचानकर्ता ऐड‑इन्स के लिये अभिप्रेत है और पुनः‑असाइन किया जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो एप्लिकेशन डेटा में मैपिंग रखें और सत्यापित करें कि अपेक्षित आकार अभी भी मौजूद है।

नाम और विवरण दोनों को पढ़ने एवं अद्यतन करने के वास्तविक उदाहरण के लिये देखें [Manage Alternative Text Titles and Descriptions](/slides/hi/java/presentation-accessibility/). वैकल्पिक टेक्स्ट का उपयोग दृश्य की अर्थ को पाठकों तक पहुँचाने के लिये करें, और इसे कोड द्वारा आकार नामों से अलग रखें।

निम्न उदाहरण नाम द्वारा सटीक तुलना के साथ खोजता है और स्लाइड‑स्कोप्ड इंटरऑप ID रिपोर्ट करता है। जब टेम्पलेट में अपेक्षित आकार नहीं मिलता, तो कोड गलत ऑब्जेक्ट के साथ जारी रखने के बजाय वही परिणाम रिपोर्ट करता है।

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

जब कोई ऑपरेशन विशिष्ट आकार प्रकार के लिये हो, तो प्रकार‑विशिष्ट सदस्य उपयोग करने से पहले इंटरफ़ेस चेक करें। यह उदाहरण तब ही टेक्स्ट और वैकल्पिक टेक्स्ट अपडेट करता है जब नामित ऑब्जेक्ट एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iautoshape/) हो।

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

प्रीसेट ज्योमैट्री आकार समायोजन बिंदु उजागर कर सकते हैं जो कोने का आकार, तीर अनुपात या धुंधयुक्त कोण जैसी सुविधाओं को नियंत्रित करते हैं। इन्हें पढ़ने‑के‑लिए‑केवल [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igeometryshape/#getAdjustments--) संग्रह के माध्यम से पहुंचें। यह संग्रह आकार द्वारा प्रदान किया जाता है, लेकिन प्रत्येक [IAdjustValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/) में वह मान होता है जिसे बदला जा सकता है।

केवल स्थिर संग्रह इंडेक्स पर भरोसा न करें। समायोजनों के माध्यम से इटरिट करें और पढ़ने‑के‑लिए‑केवल [getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#getType--) मेथड का निरीक्षण करें, जिसका [ShapeAdjustmentType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapeadjustmenttype/) मान बताता है कि समायोजन क्या नियंत्रित करता है। पढ़ने‑के‑लिए‑केवल [getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#getName--) मेथड अतिरिक्त पहचान जानकारी देता है और विशेष रूप से उपयोगी है जब प्रीसेट में समान अर्थ प्रकार के अधिक एक से अधिक समायोजन हों।

समायोजन के अर्थ से मिलते‑जुलते वैल्यू मेथड का उपयोग करें:

| समायोजन प्रकार | उद्देश्य | बदलने के लिये वैल्यू |
|---|---|---|
| `CornerSize` | गोल कोनों का आकार | [setRawValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | तीर के पूंछ की मोटाई | `setRawValue` |
| `ArrowheadLength` | तीर के सिरे की लंबाई | `setRawValue` |
| `ArrowheadWidth` | तीर के सिरे की चौड़ाई | `setRawValue` |
| `StartAngle` | पाई या धुंधा का प्रारम्भिक कोण | [setAngleValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | पाई या धुंधा का समाप्ति कोण | `setAngleValue` |

`getType` और `getName` केवल‑पढ़ने योग्य जानकारी लौटाते हैं। `getRawValue` और `setRawValue` प्रीसेट की मूल ज्योमैट्री इकाइयों में एक पूर्णांक के साथ कार्य करते हैं, जबकि `getAngleValue` और `setAngleValue` डिग्री में कोण के साथ कार्य करते हैं। समायोजन की संख्या, क्रम, अर्थ और वैध सीमा प्रीसेट [ShapeType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igeometryshape/#getShapeType--) पर निर्भर करती है। एक प्रीसेट के लिये वैध मान दूसरे के लिये अमान्य या अलग प्रभाव डाल सकता है।

जब `getType` `ShapeAdjustmentType.Custom` लौटाता है, तो API मानक सेमांटिक अर्थ नहीं पहचानती। `getName`, प्रीसेट प्रकार, और मौजूदा मान का निरीक्षण करें और तब तक समायोजन अपरिवर्तित रखें जब तक अपेक्षित अर्थ और रेंज ज्ञात न हो। पहचाने गये प्रकारों के लिये भी जांचें कि क्या वही प्रकार एक से अधिक बार आता है, इससे पहले कि आप मान चुनें। कनेक्टर बेंड समायोजन के साथ इस स्थिति को दर्शाते हुए [Connector](/slides/hi/java/connector/) लेख देखें।

निम्न पूर्ण उदाहरण तीन प्रीसेट आकारों के डिफ़ॉल्ट और संशोधित संस्करण बनाता है। यह प्रत्येक समायोजन के माध्यम से इटरिट करता है, उसके नाम और प्रकार को रिपोर्ट करता है, आकार‑संबंधी मानों को `setRawValue` से बदलता है, कोणों को `setAngleValue` से बदलता है, और परिणाम को सहेजता है। बाएँ कॉलम में डिफ़ॉल्ट ज्योमैट्री रहता है; दाएँ कॉलम में समायोजित गोल कोना, चार‑मार्गी तीर, और पाई दिखाया गया है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // डिफ़ॉल्ट और समायोजित आकार कॉलम के लिए हेडर जोड़ता है।
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

समायोजन के प्रकार की जाँच करके मान बदलने से कोड अपने इरादे को स्पष्ट रूप से दर्शाता है और यह मानने से बचता है कि विभिन्न प्रीसेट आकारों में समान संग्रह इंडेक्स का समान अर्थ हो।

## **आकार संग्रह में संशोधन**

जोड़ना, क्लोन करना, हटाना और पुनः‑क्रमित करना मेथड्स संग्रह पर तुरंत कार्य करते हैं। यदि कोई ऑपरेशन आकारों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले कैप्चर किए गये इंडेक्स पर निर्भरता जारी न रखें।

### **आकार को क्लोन करें**

[addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) एक स्वतंत्र प्रति बनाता है और उसे लक्ष्य संग्रह के अंत में जोड़ता है। [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) भी एक प्रति बनाता है लेकिन उसे निर्दिष्ट z‑order इंडेक्स पर रखता है। वह ओवरलोड जो समन्वय (coordinates) स्वीकार करता है क्लोन को बिना आकार बदले ले जाता है; चौड़ाई‑और‑ऊँचाई वाले ओवरलोड उसे पुनः‑आकार दे सकते हैं।

निम्न उदाहरण एक गंतव्य स्लाइड बनाता है, लेबल‑युक्त आयत को सामने क्लोन करता है, और दूसरा क्लोन पीछे सम्मिलित करता है। किसी भी क्लोन में किए गए परिवर्तन स्रोत आकार को प्रभावित नहीं करते।

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

क्लोनिंग आकार की सामग्री और फ़ॉर्मेटिंग, जिसमें उसका नाम और वैकल्पिक टेक्स्ट शामिल है, की नकल बनाता है। जब इन मानों का अद्वितीय होना आवश्यक हो तो क्लोन को नए तर्कसंगत पहचानकर्ता सौंपें। जटिल आकारों द्वारा उपयोग किए गये संसाधनों को प्रस्तुति संभालती है, लेकिन एक क्लोन नया संग्रह आइटम होता है जिसका अपना आकार पहचानकर्ता होता है।

### **आकार हटाएँ**

[remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) किसी विशिष्ट आकार ऑब्जेक्ट को उसके संग्रह से हटाता है। कई मिलान वाले आकारों को इंडेक्स‑आधारित इटरशन के दौरान हटाते समय, अंत से शुरू करके इटरिट करें ताकि शेष इंडेक्स मान्य रहें।

यह उदाहरण निर्दिष्ट नाम वाले प्रत्येक आकार को हटाता है। यह वर्तमान इंडेक्स पर आकार पढ़ता है, न कि स्थिर संग्रह आइटम, और अनावश्यक रूप से आकार को कास्ट नहीं करता।

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

हटाने के बाद, आकारों की गणना और बाद के आकारों के इंडेक्स बदल जाते हैं। अप्रभावित आकारों के संदर्भ सहेजे गये इंडेक्स की तुलना में अधिक विश्वसनीय रहते हैं। कनेक्टर, एनीमेशन, और अन्य प्रस्तुति सुविधाओं को भी ध्यान में रखें जो हटाए गये ऑब्जेक्ट का हवाला दे सकते हैं; एक दृश्यमान आकार हटाने से स्लाइड की उपस्थिति से अधिक परिवर्तन हो सकते हैं।

### **आकार को छुपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setHidden-boolean-) को `true` पर सेट करने से आकार संग्रह में बना रहता है लेकिन सामान्य स्लाइड‑शो में प्रदर्शित नहीं होता। उसका इंडेक्स, फ़ॉर्मेटिंग, और सामग्री कोड के लिये उपलब्ध रहती है, इसलिए वैकल्पिक तत्वों के लिये छुपाना उपयुक्त है जिन्हें बाद में पुनः दिखाई देना हो सकता है।

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

छुपाना हटाना या सुरक्षा नहीं है। ऑब्जेक्ट अभी भी उपयोगकर्ता या कोड द्वारा खोजा और अन‑हिड किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बना रहता है।

### **Z‑Order बदलें**

ओवरलैपिंग आकार संग्रह क्रम में चित्रित होते हैं। [reorder](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) किसी मौजूदा आकार को क्लोन किए बिना लक्ष्य इंडेक्स पर ले जाता है। इंडेक्स `0` पीछे है; `size() - 1` सामने।

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

आयत पहले बनाया जाता है और शुरू में एलिप्स के पीछे स्थित रहता है। उसे अंतिम इंडेक्स पर ले जाने से वह सामने आ जाता है। सभी संबंधित आकारों को जोड़ने या क्लोन करने के बाद Z‑order को अंतिम रूप दें, क्योंकि ये ऑपरेशन नए संग्रह आइटम जोड़ते या सम्मिलित करते हैं और इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड्स में आकारों का निरीक्षण**

साधारण स्लाइड, लेआउट स्लाइड और मास्टर स्लाइड के अलग-अलग आकार संग्रह होते हैं। लेआउट संग्रह में आकार वही ऑब्जेक्ट नहीं है जो समान स्थिति वाले साधारण स्लाइड पर होता है। लेआउट द्वारा प्रदान किए गये फ़ॉर्मेटिंग को समझने या बदलने के लिये लेआउट आकारों की जाँच करें।

निम्न उदाहरण प्रत्येक लेआउट आकार के [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getFillFormat--) और [LineFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getLineFormat--) को पढ़ता है, यह मानते हुए कि हर आकार `AutoShape` नहीं है।

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

लेआउट को संपादित करने से कई स्लाइड्स प्रभावित हो सकती हैं जो उसे उपयोग करती हैं। लेआउट आकार बदलने से पहले तय करें कि साधारण स्लाइड ऑब्जेक्ट को इनहेरिट करती है या स्थानीय रूप से ओवरराइड करती है, और उस लेआउट को उपयोग करने वाली प्रत्येक स्लाइड को परीक्षण में रखें।

## **आकार को SVG में निर्यात करें**

[writeAsSvg](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) एक आकार की रेंडरड सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल आकार होता है, पूरी स्लाइड पृष्ठभूमि या पड़ोसी आकार नहीं।

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

रेंडरिंग के दौरान प्रस्तुति खुले रखें। आउटपुट आकार की फ़ॉर्मेटिंग और फॉन्ट तथा चित्र जैसी संसाधनों पर निर्भर करता है। यदि आप पूरी संरचना चाहते हैं, तो व्यक्तिगत आकार के बजाय स्लाइड निर्यात करें। कॉलर स्ट्रीम का स्वामित्व रखता है और उसे बंद करना आवश्यक है।

## **आकारों को संरेखित करें**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) ओवरलोड सभी आकारों या चयनित संग्रह इंडेक्स को संरेखित करता है। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapesalignmenttype/) किनारा, केंद्र रेखा, या वितरण मोड को निर्दिष्ट करता है। `alignToSlide` को `true` करने से स्लाइड किनारों का उपयोग होता है; `false` करने से चयनित आकार एक‑दूसरे के सापेक्ष संरेखित होते हैं।

निम्न उदाहरण तीन आकारों को स्लाइड के शीर्ष किनारे से संरेखित करता है। लौटाए गये आकार रेफ़रेंस को संरेखण से ठीक पहले उनके वर्तमान इंडेक्स में बदला जाता है।

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

संरेखण स्थिति बदलता है, Z‑order नहीं। सापेक्ष संरेखण सामान्यतः कम से कम दो आकारों की आवश्यकता रखता है, जबकि क्षैतिज या ऊर्ध्वाधर वितरण के लिये पर्याप्त स्पेसिंग निर्धारित करने हेतु कई आकार चाहिए। मेथड कॉल करने से पहले यदि आप संग्रह को संशोधित कर रहे हैं तो इंडेक्स पुनः‑गणना करें।

## **आकार को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज और ऊर्ध्वाधर फ़्लिप सेटिंग, तथा घुमाव (rotation) को संग्रहीत करता है। इसके `getFlipH` और `getFlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/java/com.aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप सक्रिय करता है, `False` निष्क्रिय, और `NotDefined` बिना परिभाषित/डिफ़ॉल्ट स्थिति को बरकरार रखता है।

नीचे प्रस्तुत इनपुट प्रस्तुति में एक अनफ़्लिप्ड आकार है।

![फ़्लिप करने से पहले आकार](shape_to_be_flipped.png)

उदाहरण प्रत्येक अन्य फ्रेम मान को बरकरार रखता है और केवल दो फ़्लिप सेटिंग को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) असाइन करने से पूरी फ्रेम बदल जाती है।

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

सहेजा गया आकार क्षैतिज तथा ऊर्ध्वादिक रूप से प्रतिबिंबित है, जबकि उसकी स्थिति, आकार और घुमाव समान रहता है।

![फ़्लिप करने के बाद आकार](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे आकार पहचानकर्ता के रूप में संग्रह इंडेक्स का उपयोग करना चाहिए?**

सिर्फ़ अल्पकालिक प्रोसेसिंग के लिये जब संग्रह इंडेक्स बदलने की संभावना न हो। निर्मित टेम्पलेट्स के लिये मान्य `Name` या `AlternativeText` मानक अपनाएँ, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिये `OfficeInteropShapeId` उपयोग करें।

**क्या आकार छुपाने से वह Z‑order से हट जाता है?**

नहीं। छुपा हुआ आकार उसी इंडेक्स पर संग्रह में बना रहता है। इसे खोजा, पुनः‑क्रमित, संपादित या फिर से दिखाई दिया जा सकता है।

**क्लोन किए गये आकार ने दूसरे आकार के आगे क्यों दिखाया?**

`addClone` क्लोन को संग्रह के अंत में जोड़ता है, जो Z‑order के सामने का स्थान है। प्रारम्भिक इंडेक्स चुनने के लिये `insertClone` उपयोग करें या सभी आकार जोड़ने के बाद `reorder` करें।

**क्या किसी प्रीसेट आकार समायोजन की पहचान के लिये स्थिर इंडेक्स उपयोग कर सकता हूँ?**

केवल तब जब आप सटीक प्रीसेट और संग्रह लेआउट को मान्य कर चुके हों। `IGeometryShape.getAdjustments` के माध्यम से इटरेट करना और `IAdjustValue.getType` की जाँच करना पसंदीदा है; जब समान सेमान्टिक प्रकार कई बार आता है तो अतिरिक्त जानकारी के लिये `IAdjustValue.getName` का उपयोग करें।