---
title: एन्ड्रॉइड पर PowerPoint प्रस्तुतियों में SmartArt प्रबंधित करें
linktitle: SmartArt प्रबंधित करें
type: docs
weight: 10
url: /hi/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt पाठ
- लेआउट प्रकार
- लुप्त गुण
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "स्पष्ट Java कोड उदाहरणों का उपयोग करके Android के लिए Aspose.Slides के साथ PowerPoint SmartArt बनाना और संपादित करना सीखें, जो स्लाइड डिजाइन और ऑटोमेशन को तेज़ करता है।"
---
## **अवलोकन**

SmartArt PowerPoint का एक डायग्राम है जो नोड, नोड शैप्स और एक लेआउट से बना होता है। Aspose.Slides for Android via Java के साथ आप SmartArt बना सकते हैं, उसके नोड्स से टेक्स्ट पढ़ सकते हैं, लेआउट बदल सकते हैं, छिपे हुए नोड्स की जांच कर सकते हैं, ऑर्गेनाइज़ेशन चार्ट लेआउट कॉन्फ़िगर कर सकते हैं, और पिक्चर ऑर्गेनाइज़ेशन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से टेक्स्ट प्राप्त करें**

एक SmartArt नोड में एक या अधिक शैप्स हो सकते हैं। दृश्यमान टेक्स्ट पढ़ने के लिए, [ISmartArt.getAllNodes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ismartart/#getAllNodes--) को इटररेट करें, फिर [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) द्वारा लौटाए गए [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) को पढ़ें।

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

SmartArt लेआउट यह निर्धारित करता है कि नोड्स कैसे व्यवस्थित और जुड़े होते हैं। निम्न उदाहरण एक SmartArt ऑब्जेक्ट बनाता है जिसमें [SmartArtLayoutType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList` मान होता है, इसे `BasicProcess` मान में बदलता है, और प्रस्तुति को सेव करता है।

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ismartartnode/#isHidden--) यह दर्शाता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। छिपे हुए नोड्स संरचना में मौजूद रह सकते हैं भले ही चयनित लेआउट उन्हें दृश्य तत्वों के रूप में न दिखाए।

निम्न उदाहरण एक SmartArt ऑब्जेक्ट में नोड जोड़ता है जो [SmartArtLayoutType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle` मान का उपयोग करता है और नोड की छिपी अवस्था की जाँच करता है।

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

## **संगठन चार्ट लेआउट प्राप्त करें या सेट करें**

उन SmartArt डायग्रामों के लिए जो संगठन चार्ट लेआउट का उपयोग करते हैं, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) और [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) यह निर्धारित करते हैं कि चाइल्ड नोड्स पैरेंट नोड के तहत कैसे व्यवस्थित होते हैं। उदाहरण के लिए, आप चाइल्ड नोड्स को बाएँ, दाएँ या दोनों ओर लटकाने के लिए चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/OrganizationChartLayoutType) के आधार पर सेट कर सकते हैं।

निम्न उदाहरण एक संगठन चार्ट बनाता है और पहले नोड के लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging` मान पर सेट करता है।

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

## **एक चित्र संगठन चार्ट बनाएं**

चित्र संगठन चार्ट एक SmartArt लेआउट है जो हाइरार्की डायग्राम के लिए तैयार किया गया है जिसमें इमेज प्लेसहोल्डर शामिल होते हैं। स्लाइड पर SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` मान का उपयोग करें।

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

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हाँ। [ISmartArt.setReversed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) मेथड चयनित SmartArt लेआउट द्वारा रिवर्सल समर्थित होने पर डायग्राम की दिशा को बाएँ‑से‑दाएँ से दाएँ‑से‑बाएँ या वापस बदल देता है।

**मैं SmartArt को उसी स्लाइड में या किसी अन्य प्रस्तुति में फॉर्मेटिंग बनाए रखते हुए कैसे कॉपी कर सकता हूँ?**

आप SmartArt शैप को [clone the SmartArt shape](/slides/hi/androidjava/shape-manipulations/) के साथ [ShapeCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) या पूरी स्लाइड को [clone the whole slide](/slides/hi/androidjava/clone-slides/) द्वारा कॉपी कर सकते हैं। दोनों विधियाँ आकार, पोजिशन और फॉर्मेटिंग को संरक्षित रखती हैं।

**मैं प्रीव्यू या वेब एक्सपोर्ट के लिए SmartArt को रास्टर इमेज में कैसे रेंडर करूँ?**

[Render the slide](/slides/hi/androidjava/convert-powerpoint-to-png/) या पूरी प्रस्तुति को PNG या JPEG में रेंडर करें। SmartArt स्लाइड का हिस्सा होने के कारण रेंडर हो जाता है।

**यदि कई SmartArt ऑब्जेक्ट हों तो मैं स्लाइड पर किसी विशिष्ट SmartArt ऑब्जेक्ट को कैसे खोजूँ?**

SmartArt शैप पर एक विशिष्ट [Shape.getAlternativeText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getAlternativeText--) या [Shape.getName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getName--) मान सेट करें, उस मान को [BaseSlide.getShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslide/#getShapes--) में खोजें, और फिर जांचें कि मिलते-जुलते शैप एक [ISmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ismartart/) है या नहीं।