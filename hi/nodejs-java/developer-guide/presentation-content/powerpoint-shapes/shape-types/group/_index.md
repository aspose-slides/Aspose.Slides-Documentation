---
title: जावास्क्रिप्ट में समूह प्रस्तुति आकार
linktitle: आकार समूह
type: docs
weight: 40
url: /hi/nodejs-java/group/
keywords:
- समूह आकार
- आकार समूह
- समूह जोड़ें
- वैकल्पिक पाठ
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint डेक में आकारों को समूहित और अनसमूहित करना सीखें Aspose.Slides for Node.js via Java का उपयोग करके — तेज़, चरण-दर-चरण मार्गदर्शिका मुफ्त JavaScript कोड के साथ।"
---
## **सारांश**

यह लेख Aspose.Slides में समूह आकार (group shapes) के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि स्लाइड में समूह आकार कैसे जोड़ें, उसके अंदर आकार (shapes) रखें, और अद्यतन प्रस्तुति को सहेजें। यह समूह के भीतर संग्रहीत आकारों तक पहुंचने और उनके `AlternativeText` मान पढ़ने का भी प्रदर्शन करता है। अतिरिक्त रूप से, लेख नेस्टेड समूह, z‑order, और लॉकिंग विकल्प जैसी संबंधित समूह‑आकार क्षमताओं को संक्षिप्त रूप से कवर करता है।

## **समूह आकार जोड़ना**
Aspose.Slides स्लाइड पर समूह आकारों के साथ काम करने का समर्थन करता है। यह सुविधा डेवलपर्स को अधिक समृद्ध प्रस्तुतियां बनाने में मदद करती है। Aspose.Slides for Node.js via Java समूह आकार जोड़ने या पहुँचने का समर्थन करता है। आप एक जोड़े गए समूह आकार में आकार जोड़कर उसे भर सकते हैं या समूह आकार की किसी भी प्रॉपर्टी तक पहुंच सकते हैं। Aspose.Slides for Node.js via Java का उपयोग करके स्लाइड में समूह आकार जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
1. स्लाइड का Index उपयोग करके उसका संदर्भ प्राप्त करें।
1. स्लाइड में एक समूह आकार जोड़ें।
1. जोड़े गए समूह आकार में आकार जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

नीचे दिया गया उदाहरण स्लाइड में एक समूह आकार जोड़ता है।

```javascript
// Presentation क्लास का उदाहरण बनाएं
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // स्लाइड्स की shape collection तक पहुंचना
    var slideShapes = sld.getShapes();
    // स्लाइड में समूह आकार जोड़ना
    var groupShape = slideShapes.addGroupShape();
    // जोड़े गए समूह आकार के भीतर आकार जोड़ना
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // समूह आकार का फ्रेम जोड़ना
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **AltText प्रॉपर्टी तक पहुँच**
यह विषय सरल चरणों को कोड उदाहरणों के साथ दिखाता है, जिससे स्लाइड पर समूह आकार जोड़ना और उसकी AltText प्रॉपर्टी तक पहुँचना संभव होता है। Aspose.Slides for Node.js via Java का उपयोग करके स्लाइड में समूह आकार की AltText तक पहुँचने के लिए:

1. वही PPTX फ़ाइल का प्रतिनिधित्व करने वाला [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास इंस्टैंसिएट करें।
1. स्लाइड का Index उपयोग करके उसका संदर्भ प्राप्त करें।
1. स्लाइड की shape collection तक पहुँचें।
1. समूह आकार तक पहुँचें।
1. [getAlternativeText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getAlternativeText--) प्रॉपर्टी को कॉल करें।

नीचे दिया गया उदाहरण समूह आकार के वैकल्पिक पाठ (alternative text) तक पहुंचता है।

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // स्लाइड्स की shape collection तक पहुंचना
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // समूह आकार तक पहुंचना।
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // AltText प्रॉपर्टी तक पहुंचना
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**क्या नेस्टेड ग्रुपिंग (एक समूह के भीतर दूसरा समूह) समर्थित है?**

हाँ। [GroupShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/groupshape/) में एक [getParentGroup](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getparentgroup/) मेथड है, जो सीधे पदानुक्रम समर्थन दर्शाता है (एक समूह दूसरे समूह का बच्चे हो सकता है)।

**मैं स्लाइड पर अन्य वस्तुओं की तुलना में समूह के z‑order को कैसे नियंत्रित करूँ?**

[GroupShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/groupshape/) की [getZOrderPosition](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getzorderposition/) मेथड का उपयोग करके उसकी डिस्प्ले स्टैक में स्थिति देख सकते हैं।

**क्या मैं समूह को हटाने/संपादन/अनग्रुप करने से रोक सकता हूँ?**

हाँ। समूह की लॉक सेक्शन [GroupShapeLock](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/groupshape/getgroupshapelock/) के माध्यम से उपलब्ध है, जिससे आप ऑब्जेक्ट पर संचालन को प्रतिबंधित कर सकते हैं।