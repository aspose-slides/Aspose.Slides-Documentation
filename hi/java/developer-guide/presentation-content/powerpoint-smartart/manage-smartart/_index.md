---
title: Java का उपयोग करके PowerPoint प्रस्तुतियों में SmartArt प्रबंधित करें
linktitle: SmartArt प्रबंधित करें
type: docs
weight: 10
url: /hi/java/manage-smartart/
keywords:
- SmartArt
- SmartArt टेक्स्ट
- लेआउट प्रकार
- छिपी प्रॉपर्टी
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "स्पष्ट कोड नमूनों का उपयोग करके जो स्लाइड डिज़ाइन और ऑटोमेशन को तेज़ बनाते हैं, Aspose.Slides for Java के साथ PowerPoint SmartArt बनाना और संपादित करना सीखें।"
---
## **अवलोकन**

SmartArt एक PowerPoint आरेख है जो नोड, नोड आकृतियों और लेआउट से बनता है। Aspose.Slides for Java के साथ, आप SmartArt बना सकते हैं, उसके नोड्स से टेक्स्ट पढ़ सकते हैं, लेआउट बदल सकते हैं, छिपे नोड्स का निरीक्षण कर सकते हैं, ऑर्गेनाइजेशन चार्ट लेआउट कॉन्फ़िगर कर सकते हैं, और चित्र ऑर्गेनाइजेशन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से टेक्स्ट प्राप्त करें**

एक SmartArt नोड में एक या अधिक आकृतियां हो सकती हैं। दृश्यमान टेक्स्ट पढ़ने के लिए, [ISmartArt.getAllNodes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ismartart/#getAllNodes--) पर इटररेट करें, फिर [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ismartartshape/#getTextFrame--) द्वारा लौटाए गए [ITextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/) को पढ़ें।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt ऑब्जेक्ट का लेआउट प्रकार बदलें**

SmartArt लेआउट नियंत्रित करता है कि नोड्स कैसे व्यवस्थित और जुड़े होते हैं। निम्न उदाहरण एक SmartArt ऑब्जेक्ट बनाता है जहाँ [SmartArtLayoutType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtLayoutType) को `BasicBlockList` मान से सेट किया गया है, फिर उसे `BasicProcess` मान में बदलता है, और प्रस्तुति को सहेजता है।

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **जाँचें कि SmartArt नोड छिपा है या नहीं**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ismartartnode/#isHidden--) यह दर्शाता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। चयनित लेआउट द्वारा दर्शाए न जाने पर भी छिपे नोड्स संरचना में मौजूद रह सकते हैं।

निम्न उदाहरण एक नोड को SmartArt ऑब्जेक्ट में जोड़ता है जहाँ [SmartArtLayoutType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtLayoutType) का मान `RadialCycle` है, और नोड की छिपी स्थिति की जाँच करता है।

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ऑर्गेनाइजेशन चार्ट लेआउट प्राप्त या सेट करें**

ऑर्गेनाइजेशन चार्ट लेआउट वाले SmartArt आरेखों के लिए, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) और [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) यह निर्धारित करते हैं कि पैरेंट नोड के नीचे चाइल्ड नोड्स कैसे व्यवस्थित हों। उदाहरण के लिए, आप चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OrganizationChartLayoutType) के आधार पर चाइल्ड नोड्स को बाएँ, दाएँ या दोनों किनारों से लटकाने के लिए सेट कर सकते हैं।

निम्न उदाहरण एक ऑर्गेनाइजेशन चार्ट बनाता है और पहले नोड के लिए लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging` मान पर सेट करता है।

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **चित्र ऑर्गेनाइजेशन चार्ट बनाएं**

चित्र ऑर्गेनाइजेशन चार्ट एक SmartArt लेआउट है जो छवि प्लेसहोल्डर वाले पदानुक्रमिक आरेखों के लिए डिज़ाइन किया गया है। स्लाइड में SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` मान का उपयोग करें।

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या उलटने का समर्थन करता है?**

हाँ। [ISmartArt.setReversed](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ismartart/#setReversed-boolean-) मेथड चयनित SmartArt लेआउट के उलटने के समर्थन होने पर आरेख की दिशा को बाएँ‑से‑दाएँ से दाएँ‑से‑बाएँ या वापस बदलता है।

**मैं फ़ॉर्मेटिंग को बरकरार रखते हुए SmartArt को उसी स्लाइड या किसी अन्य प्रस्तुति में कैसे कॉपी कर सकता हूँ?**

आप [ShapeCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) के साथ SmartArt आकृति को क्लोन करके या उस स्लाइड को क्लोन करके जो SmartArt रखती है, कर सकते हैं। दोनों तरीकों से आकार, स्थिति और फ़ॉर्मेटिंग संरक्षित रहती है।

**मैं प्रीव्यू या वेब एक्सपोर्ट के लिए SmartArt को रास्टर छवि के रूप में कैसे रेंडर करूँ?**

स्लाइड को [/slides/hi/java/convert-powerpoint-to-png/](/slides/hi/java/convert-powerpoint-to-png/) या पूरी प्रस्तुति को PNG या JPEG में रेंडर करें। SmartArt स्लाइड का हिस्सा के रूप में रेंडर होता है।

**यदि स्लाइड पर कई SmartArt ऑब्जेक्ट हों तो मैं किसी विशिष्ट SmartArt को कैसे ढूँढूँ?**

SmartArt आकृति पर विशिष्ट [Shape.getAlternativeText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getAlternativeText--) या [Shape.getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getName--) मान सेट करें, फिर [BaseSlide.getShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslide/#getShapes--) में उस मान को खोजें, और जाँचें कि मेल खाने वाली आकृति [ISmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ismartart/) है या नहीं।