---
title: JavaScript में प्रस्तुति स्लाइड मास्टर प्रबंधित करें
linktitle: स्लाइड मास्टर
type: docs
weight: 70
url: /hi/nodejs-java/slide-master/
keywords:
- स्लाइड मास्टर
- मास्टर स्लाइड
- PPT मास्टर स्लाइड
- कई मास्टर स्लाइड्स
- मास्टर स्लाइड्स की तुलना
- पृष्ठभूमि
- प्लेसहोल्डर
- मास्टर स्लाइड क्लोन करें
- मास्टर स्लाइड कॉपी करें
- मास्टर स्लाइड डुप्लिकेट करें
- अप्रयुक्त मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java में स्लाइड मास्टर को प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुँचें, संपादित करें, क्लोन करें, तुलना करें और हटाएँ।"
---
## **अवलोकन**

एक **स्लाइड मास्टर** स्लाइड समूह के लिए साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकृतियों, लोगो, पृष्ठभूमि, टेक्स्ट शैलियों, थीम सेटिंग्स और फ़ूटर सेटिंग्स हो सकती हैं। PowerPoint में, स्लाइड मास्टर को संपादित करना वह सामान्य तरीका है जिससे प्रस्तुति को लगातार बनाए रखा जा सके बिना प्रत्येक स्लाइड पर समान फ़ॉर्मेटिंग दोहराए।

Aspose.Slides for Node.js via Java भी समान मॉडल को सपोर्ट करता है। एक प्रस्तुति में एक या अधिक मास्टर स्लाइड हो सकती हैं, और प्रत्येक मास्टर स्लाइड में कई लेआउट स्लाइड हो सकती हैं। सामान्य स्लाइडें आमतौर पर सीधे किसी मास्टर स्लाइड को संदर्भित नहीं करतीं। बल्कि, एक सामान्य स्लाइड एक लेआउट स्लाइड का उपयोग करती है, और वह लेआउट स्लाइड एक मास्टर स्लाइड से जुड़ी होती है।

क्रमक्रम इस प्रकार है:

1. **स्लाइड मास्टर** - साझा डिज़ाइन और थीम को परिभाषित करता है।  
1. **लेआउट स्लाइड** - प्लेसहोल्डर और लेआउट-स्तर फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।  
1. **सामान्य स्लाइड** - वास्तविक प्रस्तुति सामग्री रखती है और एक लेआउट स्लाइड का उपयोग करती है।

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Aspose.Slides में, स्लाइड मास्टर को [MasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) क्लास द्वारा दर्शाया जाता है। प्रस्तुति की सभी मास्टर स्लाइडें `Presentation.getMasters()` संग्रह के माध्यम से उपलब्ध हैं।

{{% alert color="info" title="Inheritance" %}}

जब एक ही प्रॉपर्टी अधिक से अधिक स्तरों पर परिभाषित की जाती है, तो अधिक विशिष्ट स्तर जीतता है। उदाहरण के लिए, यदि एक मास्टर स्लाइड और एक लेआउट स्लाइड दोनों पृष्ठभूमि को परिभाषित करते हैं, तो उस लेआउट पर आधारित स्लाइडें लेआउट पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइडों के बारे में अधिक जानकारी के लिए देखें [स्लाइड लेआउट लागू करें या बदलें](/nodejs-java/slide-layout/)।

{{% /alert %}}

## **स्लाइड मास्टर तक पहुंचें**

PowerPoint में, आप **View** > **Slide Master** द्वारा स्लाइड मास्टर दृश्य खोल सकते हैं।

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Aspose.Slides में, मास्टर स्लाइड तक पहुँचने के लिए `getMasters()` संग्रह का उपयोग करें:

```javascript
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

आप सामान्य स्लाइड के लेआउट के माध्यम से उपयोग की गई मास्टर स्लाइड भी प्राप्त कर सकते हैं:

```javascript
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

## **स्लाइड मास्टर में क्या होता है**

एक मास्टर स्लाइड स्लाइड जैसी वस्तु है। यह [BaseSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/) से सामान्य स्लाइड व्यवहार को विरासत में लेती है, इसलिए यह सामान्य एवं लेआउट स्लाइडों द्वारा उपयोग किए जाने वाले कई समान स्लाइड प्रॉपर्टीज़ को उजागर करती है। मास्टर‑विशेष सदस्य [MasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) API पृष्ठ पर सूचीबद्ध हैं।

आम तौर पर उपयोग किए जाने वाले मास्टर स्लाइड सदस्यों में शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `getBackground()` | मास्टर‑स्तर स्लाइड पृष्ठभूमि सेट करता है। |
| `getShapes()` | मास्टर पर रखी गई आकृतियों को संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा टेक्स्ट। |
| `getLayoutSlides()` | उन लेआउट स्लाइडों को संग्रहीत करता है जो मास्टर से संबंधित हैं। |
| `getThemeManager()` | मास्टर थीम API तक पहुँच प्रदान करता है। |
| `getHeaderFooterManager()` | मास्टर और उसकी चाइल्ड लेआउट्स के लिए हेडर, फुटर, तिथि, और स्लाइड नंबर को नियंत्रित करता है। |
| `getDependingSlides()` | उन सामान्य स्लाइडों को लौटाता है जो लेआउट के माध्यम से मास्टर पर निर्भर करती हैं। |

## **स्लाइड मास्टर में एक छवि जोड़ें**

जब आप मास्टर स्लाइड में एक छवि जोड़ते हैं, तो वह उन स्लाइडों पर दिखाई देती है जो उस मास्टर की लेआउट्स का उपयोग करती हैं। यह लोगो, वाटरमार्क, सजावटी बैंड और अन्य दोहराए जाने वाले दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण पहले मास्टर स्लाइड में एक लोगो जोड़ता है:

```javascript
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

चित्र फ्रेम के बारे में अधिक जानकारी के लिए देखें [Picture Frame](/nodejs-java/picture-frame/)।

## **प्लेसहोल्डर के साथ काम करें**

प्लेसहोल्डर सामान्यतः लेआउट स्लाइडों पर परिभाषित होते हैं। मास्टर स्लाइड वह साझा शैली और थीम प्रदान करता है जिसे लेआउट्स विरासत में लेते हैं, जबकि प्रत्येक लेआउट यह तय करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और वे कहाँ रखे गए हैं।

PowerPoint में, प्लेसहोल्डर कमांड स्लाइड मास्टर दृश्य में उपलब्ध हैं।

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Aspose.Slides के साथ नए प्लेसहोल्डर जोड़ने के लिए, उस लेआउट स्लाइड के साथ काम करें जो मास्टर से जुड़ा है:

```javascript
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

आप मास्टर स्लाइड पर पहले से मौजूद प्लेसहोल्डर आकृतियों को भी फ़ॉर्मेट कर सकते हैं। निम्न उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और एक रैखिक ग्रेडिएंट फ़िल लागू करता है:

```javascript
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

प्लेसहोल्डर और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) और [Text Formatting](/nodejs-java/text-formatting/)।

## **स्लाइड मास्टर पृष्ठभूमि बदलें**

मास्टर पृष्ठभूमि लेआउट्स और उन स्लाइडों द्वारा विरासत में ली जाती है जो इसे ओवरराइड नहीं करतीं। निम्न उदाहरण पहले मास्टर स्लाइड के लिए एक ठोस पृष्ठभूमि रंग सेट करता है:

```javascript
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

## **एक स्लाइड मास्टर को दूसरी प्रस्तुति में क्लोन करें**

`MasterSlideCollection.addClone` का उपयोग करके एक मास्टर स्लाइड को दूसरी प्रस्तुति में कॉपी किया जा सकता है। कॉपी किया गया मास्टर फिर गंतव्य प्रस्तुति में लेआउट्स और स्लाइड्स द्वारा उपयोग किया जा सकता है।

```javascript
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

यदि आपको सामान्य स्लाइडों को उनके मास्टर के साथ क्लोन करने की आवश्यकता है, तो देखें [Clone Slides](/nodejs-java/clone-slides/)।

## **एकाधिक स्लाइड मास्टर जोड़ें**

एक प्रस्तुति में कई मास्टर स्लाइडें हो सकती हैं। यह तब उपयोगी होता है जब विभिन्न अनुभागों को अलग‑अलग ब्रांडिंग, पेज संरचना, या थीम सेटिंग्स की आवश्यकता होती है।

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट मास्टर को क्लोन करता है, क्लोन को एक अलग पृष्ठभूमि देता है, उस क्लोन किए गए मास्टर के नीचे एक लेआउट बनाता है, और उस लेआउट पर आधारित एक नई स्लाइड जोड़ता है:

```javascript
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

## **स्लाइड मास्टर की तुलना करें**

मास्टर स्लाइडों की तुलना `equals` मेथड से की जा सकती है जो [BaseSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/) से विरासत में मिली है। तुलना संरचना और स्थिर सामग्री जाँचती है, जैसे आकृतियाँ, टेक्स्ट, फ़ॉर्मेटिंग, एनीमेशन, और अन्य स्लाइड सेटिंग्स। यह स्लाइड आईडी जैसी विशिष्ट पहचानकर्ताओं या वर्तमान तिथि जैसे गतिशील प्लेसहोल्डर मानों की तुलना नहीं करती।

```javascript
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

अधिक जानकारी के लिए देखें [Compare Presentation Slides](/nodejs-java/compare-slides/)।

## **डिफ़ॉल्ट दृश्य के रूप में स्लाइड मास्टर दृश्य सेट करें**

`[ViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/)` पर `setLastView` मेथड का उपयोग करके PowerPoint द्वारा पहले खुले जाने वाले दृश्य को नियंत्रित किया जा सकता है। निम्न उदाहरण प्रस्तुति को स्लाइड मास्टर दृश्य में खोलता है:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अधिक दृश्य सेटिंग्स के लिए देखें [Save Presentation](/nodejs-java/save-presentation/)।

## **अप्रयुक्त मास्टर स्लाइड्स हटाएँ**

कभी‑कभी प्रस्तुतियों में ऐसी मास्टर स्लाइड्स हो जाती हैं जो अब किसी सामान्य स्लाइड द्वारा उपयोग नहीं की जातीं। अप्रयुक्त मास्टर को हटाने से फ़ाइल आकार कम हो सकता है और टेम्प्लेट रखरखाव सरल हो जाता है।

`removeUnused` का उपयोग करके `getMasters()` संग्रह से अप्रयुक्त मास्टर को हटाएँ:

```javascript
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
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**स्लाइड मास्टर और लेआउट स्लाइड में क्या अंतर है?**

स्लाइड मास्टर थीम, पृष्ठभूमि, सामान्य आकृतियाँ, और टेक्स्ट शैलियों जैसी साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। लेआउट स्लाइड एक मास्टर स्लाइड से जुड़ी होती है और प्लेसहोल्डर की विशिष्ट व्यवस्था को परिभाषित करती है। सामान्य स्लाइड एक लेआउट स्लाइड का उपयोग करती है, इसलिए वह लेआउट और मास्टर दोनों से विरासत में मिलती है।

**क्या एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं?**

हां। एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं। जब विभिन्न अनुभागों को अलग‑अलग दृश्य प्रणाली या ब्रांडिंग की आवश्यकता हो, तो कई मास्टर का उपयोग करें।

**मास्टर स्लाइड में या लेआउट स्लाइड में प्लेसहोल्डर जोड़ना चाहिए?**

अधिकांश मामलों में प्लेसहोल्डर लेआउट स्लाइड में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग मास्टर स्लाइड पर रखें, फिर सामग्री प्लेसहोल्डर लेआउट्स पर रखें जिन्हें सामान्य स्लाइडें उपयोग करेंगी।

**क्या मैं एक उपयोग में चल रही मास्टर स्लाइड को हटाने सकते हूं?**

नहीं। जिस मास्टर स्लाइड पर निर्भर स्लाइडें हैं, उसे सीधे सुरक्षित रूप से हटाया नहीं जा सकता। पहले उन स्लाइडों को किसी अन्य मास्टर के तहत लेआउट्स में स्थानांतरित करें, या केवल अनउपयोगी मास्टर को हटाने वाली सफ़ाई विधि का उपयोग करें।