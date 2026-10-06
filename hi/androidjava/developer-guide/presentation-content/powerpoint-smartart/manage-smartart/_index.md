---
title: Android पर PowerPoint प्रस्तुतियों में SmartArt का प्रबंधन
linktitle: SmartArt का प्रबंधन
type: docs
weight: 10
url: /hi/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt टेक्स्ट
- लेआउट प्रकार
- छिपी हुई प्रॉपर्टी
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके स्पष्ट Java कोड नमूनों के साथ PowerPoint SmartArt बनाना और संपादित करना सीखें, जो स्लाइड डिज़ाइन और ऑटोमेशन को तेज़ करता है।"
---
## **अवलोकन**

SmartArt एक PowerPoint चित्र है जो नोड्स, नोड आकृतियों, और एक लेआउट से बनता है। Aspose.Slides for Android via Java के साथ, आप SmartArt बना सकते हैं, उसके नोड्स से पाठ पढ़ सकते हैं, उसका लेआउट बदल सकते हैं, छुपे हुए नोड्स की जांच कर सकते हैं, संगठन चार्ट लेआउट को कॉन्फ़िगर कर सकते हैं, और चित्र संगठन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से टेक्स्ट प्राप्त करें**

एक SmartArt नोड में एक या अधिक आकृतियाँ हो सकती हैं। नोड आकृतियों से टेक्स्ट पढ़ने के लिए, [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--) को इटरेट करें, फिर [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) द्वारा लौटाए गए [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) को पढ़ें।

उदाहरण को कम से कम एक स्लाइड वाले प्रेज़ेंटेशन और उस स्लाइड पर पहले आकार के रूप में एक SmartArt ऑब्जेक्ट की आवश्यकता होती है। यह प्रत्येक उपलब्ध टेक्स्ट फ़्रेम को कंसोल में प्रिंट करता है।

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

SmartArt लेआउट नियंत्रित करता है कि नोड्स कैसे व्यवस्थित और जुड़ते हैं। नीचे दिया गया उदाहरण [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) के `BasicBlockList` मान के साथ एक SmartArt ऑब्जेक्ट बनाता है, इसे `BasicProcess` मान में बदलता है, और प्रेज़ेंटेशन को सहेजता है। [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) को पास किया गया स्थान और आकार पॉइंट्स में मापा जाता है। लेआउट बदलने के लिए [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) का उपयोग करें।

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
## **जाँचें कि SmartArt नोड छुपा हुआ है या नहीं**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) संकेत करता है कि नोड SmartArt डेटा मॉडल में छुपा है या नहीं। छुपे नोड्स संरचना में मौजूद रह सकते हैं भले ही चयनित लेआउट उन्हें दृश्यमान आरेख तत्वों के रूप में न दिखाए।

नीचे दिया गया उदाहरण [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) के `RadialCycle` मान का उपयोग करने वाले SmartArt ऑब्जेक्ट में एक नोड जोड़ता है और जोड़े गए नोड की छुपी स्थिति को जाँचता है। यदि नोड छुपा है तो यह एक संदेश प्रिंट करता है और आरेख को सहेजता है।

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
## **संगठन चार्ट लेआउट प्राप्त करें या सेट करें**

संगठन चार्ट लेआउट का उपयोग करने वाले SmartArt आरेखों के लिए, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) और [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) निर्धारित करते हैं कि चाइल्ड नोड्स मूल नोड के नीचे कैसे व्यवस्थित होते हैं। उदाहरण के तौर पर, आप चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) के आधार पर चाइल्ड नोड्स को बाएँ, दाएँ या दोनों तरफ लटकाने के लिए सेट कर सकते हैं।

नीचे दिया गया उदाहरण एक संगठन चार्ट बनाता है और पहले नोड के लिए लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) के `LeftHanging` मान पर सेट करता है। शून्य-आधारित इंडेक्स `0` पहला शीर्ष-स्तरीय नोड चुनता है; उसके चाइल्ड नोड्स चयनित व्यवस्था का उपयोग करते हैं। संशोधित प्रेज़ेंटेशन फिर सहेजा जाता है।

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
## **चित्र संगठन चार्ट बनाएं**

चित्र संगठन चार्ट एक SmartArt लेआउट है जो उन पदानुक्रमिक आरेखों के लिए डिज़ाइन किया गया है जिनमें छवि प्लेसहोल्डर शामिल होते हैं। स्लाइड में SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) के `PictureOrganizationChart` मान का उपयोग करें। यह उदाहरण छवि प्लेसहोल्डरों के साथ एक आरेख को सहेजता है; यह प्लेसहोल्डरों को छवियों से भरता नहीं है।

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
## **पुरानी आरेखों को आकृतियों के समूह में परिवर्तित करें**

जब कोई मौजूदा प्रेज़ेंटेशन को आधुनिक बनाते हैं, तो आपको PowerPoint 97–2003 में मूल रूप से बनाए गए संगठन चार्ट को अपडेट करने की जरूरत पड़ सकती है। Aspose.Slides इन पुराने आरेखों को [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/) ऑब्जेक्ट के रूप में प्रदर्शित करता है। एक आरेख को आकृतियों के समूह में परिवर्तित करने के लिए [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) का उपयोग करें ताकि आप व्यक्तिगत दृश्य तत्वों को संपादित कर सकें। विवरण के लिए [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) देखें।

परिवर्तन नई समूह को आकृति संग्रह में जोड़ता है बिना मूल आरेख को हटाए। सफल परिवर्तन के बाद, द्वितीय सामग्री से बचने के लिए मूल को [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) से हटाएँ। बदलने से पहले पुरानी आरेखों को एक सूची में इकट्ठा करें ताकि आकृतियों को जोड़ने या हटाने से क्रमबद्धता में बाधा न आए।

नीचे दिया गया उदाहरण एक प्रेज़ेंटेशन खोलता है, प्रत्येक स्लाइड की खोज करता है, आरेखों को आकृतियों के समूह में बदलता है, और अपडेटेड प्रेज़ेंटेशन को PPTX के रूप में सहेजता है।

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

सहेजा गया प्रेज़ेंटेशन परिवर्तित पुरानी आरेखों के स्थान पर संपादन योग्य आकृतियों के समूह शामिल करता है, साथ में कोई मूल आरेख नहीं रहता। प्रत्येक समूह के भीतर व्यक्तिगत तत्वों जैसे टेक्स्ट, भराव या स्थिति को संपादित करने के लिए PPTX को PowerPoint में खोलें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हाँ। चयनित SmartArt लेआउट के रिवर्सल का समर्थन करने पर, [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) मेथड आरेख की दिशा को बाएँ-से-दाएँ से दाएँ-से-बाएँ या वापस बदलता है।

**मैं SmartArt को उसी स्लाइड पर या किसी अन्य प्रेज़ेंटेशन में फॉर्मेटिंग को बरकरार रखते हुए कैसे कॉपी कर सकता हूँ?**

आप [SmartArt आकार को क्लोन करें](/slides/hi/androidjava/shape-manipulations/) को [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) के साथ या SmartArt वाले पूरे स्लाइड को [पूरे स्लाइड को क्लोन करें](/slides/hi/androidjava/clone-slides/) के साथ क्लोन कर सकते हैं। दोनों तरीकों से आकार, स्थान और फॉर्मेटिंग बरकरार रहती है।

**मैं पूर्वावलोकन या वेब निर्यात के लिए SmartArt को रास्टर इमेज में कैसे रेंडर करूँ?**

[स्लाइड रेंडर करें](/slides/hi/androidjava/convert-powerpoint-to-png/) या पूरे प्रेज़ेंटेशन को PNG या JPEG में रेंडर करें। SmartArt स्लाइड का हिस्सा के रूप में रेंडर होता है।

**यदि स्लाइड पर कई SmartArt ऑब्जेक्ट हैं, तो मैं एक विशिष्ट SmartArt ऑब्जेक्ट कैसे ढूँढ सकता हूँ?**

SmartArt आकार को एक विशिष्ट वैकल्पिक टेक्स्ट या नाम असाइन करने के लिए [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) या [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) का उपयोग करें, उस मान को [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) में खोजें, और फिर जांचें कि मिलती हुई आकार [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/) है या नहीं।