---
title: "Java का उपयोग करके PowerPoint प्रस्तुतियों में SmartArt का प्रबंधन"
linktitle: "SmartArt का प्रबंधन"
type: docs
weight: 10
url: /hi/java/manage-smartart/
keywords:
- SmartArt
- SmartArt पाठ
- लेआउट प्रकार
- छिपी प्रॉपर्टी
- संगठन चार्ट
- छवि संगठन चार्ट
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "स्पष्ट कोड उदाहरणों का उपयोग करके, जो स्लाइड डिज़ाइन और स्वचालन को तेज़ बनाते हैं, Aspose.Slides for Java के साथ PowerPoint SmartArt बनाना और संपादित करना सीखें।"
---
## **सारांश**

SmartArt एक PowerPoint डाइग्राम है जो नोड्स, नोड आकारों और एक लेआउट से बना होता है। Aspose.Slides for Java के साथ, आप SmartArt बना सकते हैं, उसके नोड्स से पाठ पढ़ सकते हैं, लेआउट बदल सकते हैं, छुपे हुए नोड्स की जाँच कर सकते हैं, ऑर्गनाइज़ेशन चार्ट लेआउट को कॉन्फ़िगर कर सकते हैं, और पिक्चर ऑर्गनाइज़ेशन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से टेक्स्ट प्राप्त करें**

एक SmartArt नोड में एक या अधिक आकार हो सकते हैं। नोड आकारों से टेक्स्ट पढ़ने के लिए, [ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--) के माध्यम से इटरिटेट करें, फिर [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--) द्वारा लौटाए गए [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) को पढ़ें।

इस उदाहरण के लिए एक प्रस्तुतिकरण आवश्यक है जिसमें कम से कम एक स्लाइड हो और उस स्लाइड पर पहला आकार SmartArt ऑब्जेक्ट हो। यह प्रत्येक उपलब्ध टेक्स्ट फ्रेम को कंसोल पर प्रिंट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```
## **SmartArt ऑब्जेक्ट का लेआउट प्रकार बदलें**

SmartArt लेआउट नियंत्रित करता है कि नोड्स कैसे व्यवस्थित और जुड़े होते हैं। निम्नलिखित उदाहरण [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `BasicBlockList` मान के साथ एक SmartArt ऑब्जेक्ट बनाता है, इसे `BasicProcess` मान में बदलता है, और प्रस्तुतिकरण को सहेजता है। [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) को पास किया गया स्थिति और आकार पॉइंट्स में मापा जाता है। लेआउट बदलने के लिए [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-) का उपयोग करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **जांचें कि SmartArt नोड छिपा है या नहीं**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) यह दर्शाता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। चयनित लेआउट ने उन्हें दृश्यमान डाइग्राम तत्वों के रूप में न दिखाने पर भी छिपे हुए नोड्स संरचना में मौजूद रह सकते हैं।

निम्नलिखित उदाहरण एक SmartArt ऑब्जेक्ट में एक नोड जोड़ता है जो [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `RadialCycle` मान का उपयोग करता है और जोड़े गए नोड की छिपी स्थिति की जाँच करता है। यदि नोड छिपा है तो यह एक संदेश प्रिंट करता है और डाइग्राम को सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **ऑरगनाइज़ेशन चार्ट लेआउट प्राप्त करें या सेट करें**

उन SmartArt डाइग्राम के लिए जो ऑर्गनाइज़ेशन चार्ट लेआउट उपयोग करते हैं, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) और [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) यह निर्धारित करते हैं कि मूल नोड के नीचे चाइल्ड नोड्स कैसे व्यवस्थित होते हैं। उदाहरण के लिए, आप चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) के आधार पर चाइल्ड नोड्स को बाएँ, दाएँ या दोनों ओर लटकाने के लिए सेट कर सकते हैं।

निम्नलिखित उदाहरण एक ऑर्गनाइज़ेशन चार्ट बनाता है और पहले नोड के लिए लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) `LeftHanging` मान पर सेट करता है। शून्य-आधारित सूचकांक `0` पहला शीर्ष-स्तर नोड चुनता है; उसके चाइल्ड नोड्स चयनित व्यवस्था का उपयोग करते हैं। संशोधित प्रस्तुतिकरण को फिर सहेजा जाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **पिक्चर ऑर्गनाइज़ेशन चार्ट बनाएं**

पिक्चर ऑर्गनाइज़ेशन चार्ट एक SmartArt लेआउट है जो इमेज प्लेसहोल्डर्स वाले पदक्रम डाइग्राम के लिए डिजाइन किया गया है। स्लाइड पर SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` मान का उपयोग करें। यह उदाहरण इमेज प्लेसहोल्डर्स के साथ एक डाइग्राम सहेजता है; यह प्लेसहोल्डर्स को छवियों से भरता नहीं है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **लीगैसी डाइग्राम को शैप्स के समूह में बदलें**

जब किसी मौजूदा प्रस्तुतिकरण को आधुनिक बनाते हैं, तो आपको शायद PowerPoint 97–2003 में मूल रूप से बनाई गई ऑर्गनाइज़ेशन चार्ट को अपडेट करने की आवश्यकता पड़े। Aspose.Slides इन लीगैसी डाइग्राम को [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/) ऑब्जेक्ट्स के रूप में दर्शाता है। किसी डाइग्राम को शैप्स के समूह में बदलने के लिए [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--) का उपयोग करें ताकि आप व्यक्तिगत दृश्य तत्वों को संपादित कर सकें। विवरण के लिए [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/) देखें।

परिवर्तन शैप कलेक्शन में नई समूह जोड़ता है बिना मूल डाइग्राम को हटाए। सफल परिवर्तन के बाद, डुप्लिकेट सामग्री से बचने के लिए मूल को [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) से हटाएँ। परिवर्तन करने से पहले लीगैसी डाइग्राम को एक सूची में एकत्र करें ताकि शैप्स को जोड़ना या हटाना इटरेशन को बाधित न करे।

निम्नलिखित उदाहरण एक प्रस्तुतिकरण खोलता है, प्रत्येक स्लाइड को खोजता है, डाइग्राम को शैप्स के समूह में बदलता है, और अपडेटेड प्रस्तुतिकरण को PPTX के रूप में सहेजता है।

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
सहेजा गया प्रस्तुतिकरण कनवर्ट किए गए लीगैसी डाइग्राम की जगह संपादनीय शैप्स के समूह शामिल करता है, साथ में कोई मूल डाइग्राम नहीं बचा। प्रत्येक समूह के भीतर व्यक्तिगत तत्वों जैसे टेक्स्ट, फ़िल, या स्थिति को संपादित करने के लिए PPTX को PowerPoint में खोलें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हाँ। [ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-) मेथड चयनित SmartArt लेआउट के रिवर्सल का समर्थन होने पर डायग्राम दिशा को बाएँ से दाएँ से दाएँ से बाएँ में बदलता है, या वापस।

**मैं फ़ॉर्मेटिंग को संरक्षित रखते हुए SmartArt को उसी स्लाइड या किसी अन्य प्रस्तुतिकरण में कैसे कॉपी कर सकता हूँ?**

आप [SmartArt आकार को क्लोन करें](/slides/hi/java/shape-manipulations/) को [ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) के साथ या [पूरी स्लाइड को क्लोन करें](/slides/hi/java/clone-slides/) को उस SmartArt को शामिल करने वाली स्लाइड के साथ कर सकते हैं। दोनों तरीकों से आकार, स्थिति और फ़ॉर्मेटिंग संरक्षित रहती है।

**मैं प्रीव्यू या वेब एक्सपोर्ट के लिए SmartArt को रास्टर इमेज में कैसे रेंडर करूँ?**

[स्लाइड रेंडर करें](/slides/hi/java/convert-powerpoint-to-png/) या पूरी प्रस्तुतिकरण को PNG या JPEG में। SmartArt स्लाइड का हिस्सा के रूप में रेंडर किया जाता है।

**यदि कई SmartArt ऑब्जेक्ट हैं, तो मैं स्लाइड पर एक विशिष्ट SmartArt ऑब्जेक्ट कैसे खोज सकता हूँ?**

SmartArt आकार को एक विशिष्ट वैकल्पिक टेक्स्ट या नाम देने के लिए [Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) या [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-) का उपयोग करें, उस मान को [BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) में खोजें, और फिर जाँचें कि मिलता-जुलता आकार एक [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/) है।