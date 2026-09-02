---
title: जावास्क्रिप्ट में प्रस्तुति स्लाइड मास्टर प्रबंधित करें
linktitle: स्लाइड मास्टर
type: docs
weight: 70
url: /hi/nodejs-java/slide-master/
keywords:
- स्लाइड मास्टर
- मास्टर स्लाइड
- PPT मास्टर स्लाइड
- एकाधिक मास्टर स्लाइड्स
- मास्टर स्लाइड्स की तुलना
- पृष्ठभूमि
- प्लेसहोल्डर
- मास्टर स्लाइड क्लोन
- मास्टर स्लाइड कॉपी
- मास्टर स्लाइड डुप्लिकेट
- अनुपयोगी मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java में स्लाइड मास्टर को प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुँच, संपादन, क्लोन, तुलना, और हटाना।"
---
## **परिचय**

एक **slide master** समूह में स्लाइडों के लिए सामूहिक डिजाइन सेटिंग्स को परिभाषित करता है। यह सामान्य आकृतियां, लोगो, पृष्ठभूमि, टेक्स्ट शैलियां, थीम सेटिंग्स, और फुटर सेटिंग्स शामिल कर सकता है। PowerPoint में, एक slide master को संपादित करना वह सामान्य तरीका है जिससे प्रस्तुति को समान रखा जा सके बिना हर स्लाइड पर वही फॉर्मेटिंग दोहराए।

Aspose.Slides for Node.js via Java समान मॉडल का समर्थन करता है। एक प्रस्तुति में एक या अधिक master slides हो सकते हैं, और प्रत्येक master slide में कई layout slides हो सकते हैं। सामान्य स्लाइडें सामान्यतः सीधे किसी master slide को संदर्भित नहीं करतीं। इसके बजाय, एक सामान्य स्लाइड एक layout slide का उपयोग करती है, और वह layout slide एक master slide से संबंधित होती है।

क्रमवर्ग इस प्रकार है:

1. **Slide master** – साझा डिजाइन और थीम को परिभाषित करता है।
1. **Layout slide** – प्लेसहोल्डर और लेआउट-स्तर फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।
1. **Normal slide** – वास्तविक प्रस्तुति सामग्री रखता है और एक layout slide का उपयोग करता है।

![master slides, layout slides, और normal slides की क्रमवर्ग](slide-master_2.jpg)

Aspose.Slides में, एक slide master को [MasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) क्लास द्वारा दर्शाया जाता है। एक प्रस्तुति में सभी master slides `Presentation.getMasters()` संग्रह के माध्यम से उपलब्ध होते हैं।

{{% alert color="info" title="Inheritance" %}}
जब एक ही प्रॉपर्टी एक से अधिक स्तर पर परिभाषित होती है, तो अधिक विशिष्ट स्तर को प्राथमिकता मिलती है। उदाहरण के लिए, यदि एक master slide और एक layout slide दोनों पृष्ठभूमि निर्धारित करते हैं, तो उस लेआउट पर आधारित स्लाइड्स लेआउट पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए देखें [लेआउट स्लाइड लागू या बदलें](/nodejs-java/slide-layout/)।
{{% /alert %}}

## **Slide Masters तक पहुँच**

PowerPoint में, आप **View** > **Slide Master** से Slide Master दृश्य खोल सकते हैं।

![PowerPoint View टैब पर Slide Master कमांड](slide-master_3.jpg)

Aspose.Slides में, master slides तक पहुँचने के लिये `getMasters()` संग्रह का उपयोग करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

आप सामान्य स्लाइड के लेआउट के माध्यम से उस द्वारा उपयोग किए गए master slide को भी प्राप्त कर सकते हैं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Slide Master में क्या होता है**

एक master slide एक slide‑जैसा ऑब्जेक्ट है। यह सामान्य slide व्यवहार को [BaseSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/) से विरासत में लेता है, इसलिए यह सामान्य और layout स्लाइड्स द्वारा उपयोग किए जाने वाले कई समान slide प्रॉपर्टीज़ को उजागर करता है। Master‑विशिष्ट सदस्य [MasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) API पृष्ठ पर सूचीबद्ध हैं।

सामान्यतः उपयोग किए जाने वाले master slide सदस्य शामिल हैं:

| Member | उद्देश्य |
| --- | --- |
| `getBackground()` | मास्टर‑स्तर स्लाइड पृष्ठभूमि सेट करता है। |
| `getShapes()` | मास्टर पर रखी गई आकृतियों को संग्रहित करता है, जैसे लोगो, चित्र फ्रेम, और साझा पाठ। |
| `getLayoutSlides()` | मास्टर से संबंधित layout slides को संग्रहित करता है। |
| `getThemeManager()` | मास्टर थीम API तक पहुँच प्रदान करता है। |
| `getHeaderFooterManager()` | मास्टर और उसके चाइल्ड लेआउट्स के लिए हेडर, फुटर, तिथि तथा स्लाइड नंबर को नियंत्रित करता है। |
| `getDependingSlides()` | उन सामान्य स्लाइड्स को लौटाता है जो अपने लेआउट के माध्यम से मास्टर पर निर्भर हैं। |

## **Slide Master में छवि जोड़ें**

जब आप एक master slide में छवि जोड़ते हैं, तो वह उन स्लाइड्स पर दिखाई देती है जो उस मास्टर के लेआउट का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड, और अन्य दोहराए जाने वाले दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण पहले master slide में एक लोगो जोड़ता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

चित्र फ्रेम के बारे में अधिक जानकारी के लिए देखें [पिक्चर फ्रेम](/nodejs-java/picture-frame/)।

## **प्लेसहोल्डर के साथ कार्य करें**

प्लेसहोल्डर सामान्यतः layout slides में परिभाषित होते हैं। master slide वह साझा शैली और थीम प्रदान करता है जिसे ये लेआउट विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और वे कहाँ रखे जाएंगे।

PowerPoint में, प्लेसहोल्डर कमांड Slide Master दृश्य में उपलब्ध होते हैं।

![PowerPoint Slide Master दृश्य में Insert Placeholder कमांड](slide-master_5.png)

Aspose.Slides के साथ नए प्लेसहोल्डर जोड़ने के लिए, उस layout slide के साथ काम करें जो master से जुड़ा हो:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आप master slide पर पहले से मौजूद प्लेसहोल्डर आकृतियों को भी फ़ॉर्मेट कर सकते हैं। निम्न उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और एक रैखिक ग्रेडिएंट फ़िल लागू करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![सामान्य स्लाइड्स द्वारा विरासत में मिला फ़ॉर्मेट किया हुआ शीर्षक प्लेसहोल्डर](slide-master_8.png)

प्लेसहोल्डर और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के बारे में अधिक जानने के लिए देखें [Placeholder में Prompt Text सेट करें](/nodejs-java/manage-placeholder/) और [टेक्स्ट फ़ॉर्मेटिंग](/nodejs-java/text-formatting/)।

## **Slide Master पृष्ठभूमि बदलें**

एक master पृष्ठभूमि को लेआउट और स्लाइड्स द्वारा विरासत में मिलती है जो इसे ओवरराइड नहीं करतीं। निम्न उदाहरण पहले master slide के लिए ठोस पृष्ठभूमि रंग सेट करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

संबंधित विषयों के लिए देखें [Presentation Background](/nodejs-java/presentation-background/) और [Presentation Theme](/nodejs-java/presentation-theme/)।

## **Slide Master को अन्य प्रस्तुति में क्लोन करें**

`MasterSlideCollection.addClone` का उपयोग करके एक master slide को दूसरी प्रस्तुति में कॉपी करें। कॉपी किया गया master तब लक्ष्य प्रस्तुति के लेआउट और स्लाइड्स द्वारा उपयोग किया जा सकता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

यदि आपको अपने master के साथ सामान्य स्लाइड्स को भी क्लोन करने की आवश्यकता है, तो देखें [Clone Slides](/nodejs-java/clone-slides/)।

## **एकाधिक Slide Masters जोड़ें**

एक प्रस्तुति में कई master slides हो सकते हैं। यह उपयोगी है जब विभिन्न भागों को अलग‑अलग ब्रांडिंग, पेज संरचना, या थीम सेटिंग्स की आवश्यकता होती है।

![master slides को डालने और प्रबंधित करने के लिए PowerPoint कमांड](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट master को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, उस क्लोन किए गए master के तहत एक लेआउट बनाता है, और उस लेआउट के आधार पर एक नई स्लाइड जोड़ता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slide Masters की तुलना करें**

Master slides को [BaseSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/) से विरासत में मिले `equals` मेथड से तुलना किया जा सकता है। तुलना संरचना और स्थैतिक सामग्री जैसे आकृतियाँ, पाठ, फ़ॉर्मेटिंग, एनीमेशन, और अन्य slide सेटिंग्स की जाँच करती है। यह अद्वितीय पहचानकर्ता जैसे slide IDs या गतिशील प्लेसहोल्डर मान जैसे वर्तमान तिथि की तुलना नहीं करती।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

अधिक जानकारी के लिए देखें [Presentation Slides की तुलना](/slides/hi/nodejs-java/compare-slides/)।

## **Slide Master दृश्य को डिफ़ॉल्ट दृश्य बनाएं**

`setLastView` मेथड को [ViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/) पर उपयोग करके PowerPoint द्वारा पहले खुले जाने वाले दृश्य को नियंत्रित करें। निम्न उदाहरण प्रस्तुति को Slide Master दृश्य में खोलता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अधिक दृश्य सेटिंग्स के लिए देखें [Save Presentation](/slides/hi/nodejs-java/save-presentation/)।

## **अनुपयोगी Master Slides हटाएँ**

कभी‑कभी प्रस्तुतियों में ऐसे master slides होते हैं जो अब किसी भी normal slide द्वारा उपयोग नहीं किए जाते। अनुपयोगी masters को हटाने से फ़ाइल आकार कम हो सकता है और टेम्प्लेट रखरखाव सरल बनता है।

`removeUnused` का उपयोग करके `getMasters()` संग्रह से अनुपयोगी masters को हटाएँ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आप लो‑कोड `Compress.removeUnusedMasterSlides` मेथड का भी उपयोग कर सकते हैं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Slide master और layout slide में क्या अंतर है?

Slide master थीम, पृष्ठभूमि, सामान्य आकृतियों और टेक्स्ट शैलियों जैसी साझा डिजाइन सेटिंग्स को परिभाषित करता है। Layout slide एक master slide से जुड़ी होती है और प्लेसहोल्डर की विशिष्ट व्यवस्था को परिभाषित करती है। Normal slide एक layout slide का उपयोग करती है, इसलिए वह दोनों layout और master से विरासत में लेती है।

### क्या एक प्रस्तुति में कई slide masters हो सकते हैं?

हाँ। एक प्रस्तुति में कई slide masters हो सकते हैं। विभिन्न सेक्शन को अलग‑अलग दृश्य प्रणाली या ब्रांडिंग की आवश्यकता होने पर कई masters का उपयोग करें।

### क्या placeholders को master slide में जोड़ना चाहिए या layout slide में?

अधिकांश मामलों में, placeholders को layout slides में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग master slide पर रखें, जबकि सामग्री placeholders को उन layout slides पर रखें जो सामान्य स्लाइड्स द्वारा उपयोग की जाएँगी।

### क्या मैं ऐसे master slide को हटा सकता हूँ जो अभी भी उपयोग में है?

नहीं। एक master slide जिसे निर्भर स्लाइड्स हैं, उसे सीधे हटाना सुरक्षित नहीं है। पहले उन स्लाइड्स को किसी अन्य master के तहत मौजूद लेआउट्स में स्थानांतरित करें, या केवल अनुपयोगी masters को हटाने की विधि का उपयोग करें।