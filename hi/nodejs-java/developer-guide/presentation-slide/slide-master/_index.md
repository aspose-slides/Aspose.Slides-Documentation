---
title: जावास्क्रिप्ट में प्रेजेंटेशन स्लाइड मास्टर्स प्रबंधित करें
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
description: "Aspose.Slides for Node.js via Java में स्लाइड मास्टर प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुंचें, संपादित करें, क्लोन करें, तुलना करें और हटाएँ।"
---
## **परिचय**

एक **स्लाइड मास्टर** समूह के स्लाइडों के लिए साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकृतियां, लोगो, पृष्ठभूमि, टेक्स्ट स्टाइल, थीम सेटिंग्स और फुटर सेटिंग्स शामिल हो सकती हैं। PowerPoint में, स्लाइड मास्टर को संपादित करना वह सामान्य तरीका है जिससे प्रस्तुति को सुसंगत रखा जाता है बिना प्रत्येक स्लाइड पर समान फ़ॉर्मेटिंग दोहराए।

Aspose.Slides for Node.js via Java भी यही मॉडल समर्थन करता है। एक प्रस्तुति में एक या अधिक मास्टर स्लाइड्स हो सकती हैं, और प्रत्येक मास्टर स्लाइड में कई लेआउट स्लाइड्स हो सकती हैं। सामान्य स्लाइड्स आमतौर पर सीधे मास्टर स्लाइड का संदर्भ नहीं देतीं। इसके बजाय, एक सामान्य स्लाइड लेआउट स्लाइड का उपयोग करती है, और वह लेआउट स्लाइड किसी मास्टर स्लाइड से जुड़ी होती है।

क्रम पदानुक्रम इस प्रकार है:

1. **स्लाइड मास्टर** - साझा डिज़ाइन और थीम को परिभाषित करता है।
1. **लेआउट स्लाइड** - प्लेसहोल्डर्स और लेआउट-स्तरीय फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।
1. **सामान्य स्लाइड** - वास्तविक प्रस्तुति सामग्री रखती है और एक लेआउट स्लाइड का उपयोग करती है।

![मास्टर स्लाइड्स, लेआउट स्लाइड्स, और सामान्य स्लाइड्स की पदानुक्रम](slide-master_2.jpg)

Aspose.Slides में, स्लाइड मास्टर को [MasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) वर्ग द्वारा दर्शाया जाता है। प्रस्तुति में सभी मास्टर स्लाइड्स `Presentation.getMasters()` संग्रह के माध्यम से उपलब्ध हैं।

{{% alert color="info" title="विरासत" %}}
जब एक ही प्रॉपर्टी एक से अधिक स्तर पर परिभाषित होती है, तो अधिक विशिष्ट स्तर को प्राथमिकता मिलती है। उदाहरण के लिए, यदि एक मास्टर स्लाइड और एक लेआउट स्लाइड दोनों पृष्ठभूमि परिभाषित करते हैं, तो उस लेआउट पर आधारित स्लाइड्स लेआउट की पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए देखें [Apply or Change Slide Layouts](/nodejs-java/slide-layout/)।
{{% /alert %}}

## **स्लाइड मास्टर तक पहुंचें**

PowerPoint में, आप **View** > **Slide Master** से स्लाइड मास्टर दृश्य खोल सकते हैं।

![PowerPoint व्यू टैब पर स्लाइड मास्टर कमांड](slide-master_3.jpg)

Aspose.Slides में, मास्टर स्लाइड्स तक पहुंचने के लिए `getMasters()` संग्रह का उपयोग करें:

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

आप सामान्य स्लाइड द्वारा उपयोग किए गए मास्टर स्लाइड को उसके लेआउट के माध्यम से भी प्राप्त कर सकते हैं:

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

## **स्लाइड मास्टर में क्या होता है**

एक मास्टर स्लाइड स्लाइड जैसी वस्तु है। यह [BaseSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/) से सामान्य स्लाइड व्यवहार को विरासत में लेती है, इसलिए यह सामान्य और लेआउट स्लाइड्स द्वारा उपयोग किए जाने वाले कई समान स्लाइड प्रॉपर्टीज़ को उजागर करती है। मास्टर‑विशिष्ट सदस्य [MasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) API पृष्ठ पर सूचीबद्ध हैं।

सामान्यतः उपयोग किए जाने वाले मास्टर स्लाइड सदस्यों में शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `getBackground()` | मास्टर‑स्तर की स्लाइड पृष्ठभूमि को सेट करता है। |
| `getShapes()` | मास्टर पर रखी गई आकृतियों को संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा पाठ। |
| `getLayoutSlides()` | उन लेआउट स्लाइड्स को संग्रहित करता है जो मास्टर से संबंधित हैं। |
| `getThemeManager()` | मास्टर थीम API तक पहुंच प्रदान करता है। |
| `getHeaderFooterManager()` | हेडर, फुटर, तिथि, और स्लाइड नंबर को मास्टर और उसके चाइल्ड लेआउट्स के लिए नियंत्रित करता है। |
| `getDependingSlides()` | उन सामान्य स्लाइड्स को लौटाता है जो अपने लेआउट के माध्यम से मास्टर पर निर्भर हैं। |

## **स्लाइड मास्टर में छवि जोड़ें**

जब आप मास्टर स्लाइड में छवि जोड़ते हैं, तो वह उन स्लाइड्स पर दिखती है जो उस मास्टर के लेआउट का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड, और अन्य दोहराई जाने वाली दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण पहले मास्टर स्लाइड में एक लोगो जोड़ता है:

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

चित्र फ्रेम के बारे में अधिक जानकारी के लिए देखें [Picture Frame](/nodejs-java/picture-frame/)।

## **मास्टर ग्राफ़िक्स की दृश्यता नियंत्रित करें**

विरासत में मिले मास्टर ग्राफ़िक्स, जैसे लोगो या सजावटी आकृतियों, को हटाए बिना छिपाने के लिए [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) का उपयोग करें। उन स्लाइड्स पर `false` पास करें जिनसे आप ग्राफ़िक्स को हटाना चाहते हैं, और उन स्लाइड्स पर `true` रखें जिन पर उन्हें दिखाना है, जैसे [Slide.setShowMasterShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#setShowMasterShapes)।

निम्न स्व-निहित उदाहरण एक मास्टर पर नीला सजावटी बैंड बनाता है और वही खाली लेआउट उपयोग करने वाली दो स्लाइड्स बनाता है। बैंड पहली स्लाइड पर दिखता है और दूसरी पर छिपा रहता है। कोई इनपुट प्रस्तुति या चित्र आवश्यक नहीं है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यह उदाहरण नई प्रस्तुति के साथ प्रदान किए गए **Blank** लेआउट का उपयोग करता है और प्रारंभिक स्लाइड के अपने प्लेसहोल्डर्स को हटा देता है।

### **सेटिंग का दायरा चुनें**

एक सामान्य स्लाइड अपने मास्टर को [Slide.getLayoutSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#getLayoutSlide) और [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#getMasterSlide) के माध्यम से उपयोग करती है। व्यक्तिगत स्लाइड पर प्रॉपर्टी सेट करने से केवल वह स्लाइड प्रभावित होती है। उस साझा लेआउट को उपयोग करने वाली स्लाइड्स के लिए मास्टर ग्राफ़िक्स छिपाने हेतु [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) को `false` पास करें, भले ही उनका अपना सेटिंग `true` हो। केवल एक ही स्लाइड पर ग्राफ़िक्स छिपाने के लिए, स्लाइड प्रॉपर्टी बदलें और साझा लेआउट को अपरिवर्तित रखें।

यह सेटिंग मास्टर स्लाइड स्वयं पर विज़िबिलिटी नियंत्रण के तौर पर समर्थित नहीं है। मास्टर पर [getShowMasterShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) हमेशा `false` लौटाता है, और [setShowMasterShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) को `true` पास करने पर अपवाद उत्पन्न होता है। इसे सामान्य स्लाइड या लेआउट पर लागू करें।

### **ग्राफ़िक्स को पृष्ठभूमि से अलग करें**

| संचालन | प्रभाव |
| --- | --- |
| मास्टर ग्राफ़िक्स छिपाएँ | मास्टर की विरासत में मिली आकृतियों को बिना हटाए या स्लाइड की अपनी आकृतियों को बदले दृश्यता को नियंत्रित करता है। |
| स्लाइड पृष्ठभूमि भराव बदलें | पृष्ठभूमि का रंग, ग्रेडियेंट, या चित्र बदलता है। मास्टर ग्राफ़िक्स अलग आकृतियां हैं और पृष्ठभूमि पर दिखाई दे सकती हैं। देखें [Presentation Background](/slides/hi/nodejs-java/presentation-background/). |
| मास्टर से आकृति हटाएँ | साझा स्रोत आकृति को हटा देता है, जिससे वह उस मास्टर को उपयोग करने वाली किसी भी स्लाइड के लिए उपलब्ध नहीं रहती। |

## **प्लेसहोल्डर्स के साथ काम करें**

प्लेसहोल्डर्स सामान्यतः लेआउट स्लाइड्स पर परिभाषित होते हैं। मास्टर स्लाइड साझा शैली और थीम प्रदान करती है जिससे लेआउट्स विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से प्लेसहोल्डर्स उपलब्ध हैं और वे कहां रखे गए हैं।

PowerPoint में, प्लेसहोल्डर कमांड्स स्लाइड मास्टर दृश्य में उपलब्ध होते हैं।

![PowerPoint स्लाइड मास्टर दृश्य में Insert Placeholder कमांड](slide-master_5.png)

Aspose.Slides में नया प्लेसहोल्डर जोड़ने के लिए, उस लेआउट स्लाइड के साथ काम करें जो मास्टर से जुड़ी है:

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

आप मास्टर स्लाइड पर पहले से मौजूद प्लेसहोल्डर आकृतियों को भी फ़ॉर्मेट कर सकते हैं। निम्न उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और रैखिक ग्रेडियेंट भराव लागू करता है:

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

![सामान्य स्लाइड्स द्वारा विरासत में मिला फ़ॉर्मेट किया गया शीर्षक प्लेसहोल्डर](slide-master_8.png)

अधिक प्लेसहोल्डर और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) और [Text Formatting](/nodejs-java/text-formatting/)।

## **स्लाइड मास्टर पृष्ठभूमि बदलें**

मास्टर पृष्ठभूमि लेआउट्स और उन स्लाइड्स द्वारा विरासत में ली जाती है जो इसे ओवरराइड नहीं करतीं। निम्न उदाहरण पहले मास्टर स्लाइड के लिए ठोस पृष्ठभूमि रंग सेट करता है:

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

## **स्लाइड मास्टर को अन्य प्रस्तुति में क्लोन करें**

`MasterSlideCollection.addClone` का उपयोग करके मास्टर स्लाइड को किसी अन्य प्रस्तुति में कॉपी करें। कॉपी किया गया मास्टर तब लक्ष्य प्रस्तुति में लेआउट्स और स्लाइड्स द्वारा उपयोग किया जा सकता है।

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

यदि आपको सामान्य स्लाइड्स को उनके मास्टर के साथ क्लोन करने की आवश्यकता है, तो देखें [Clone Slides](/nodejs-java/clone-slides/)।

## **एकाधिक स्लाइड मास्टर जोड़ें**

एक प्रस्तुति में कई मास्टर स्लाइड्स हो सकती हैं। यह उपयोगी है जब विभिन्न अनुभागों को अलग ब्रांडिंग, पृष्ठ संरचना, या थीम सेटिंग्स की आवश्यकता होती है।

![मास्टर स्लाइड्स को डालने और प्रबंधित करने के लिए PowerPoint कमांड्स](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट मास्टर को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, उस क्लोन किए गए मास्टर के अंतर्गत एक लेआउट बनाता है, और उस लेआउट के आधार पर नई स्लाइड जोड़ता है:

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

## **स्लाइड मास्टर की तुलना करें**

मास्टर स्लाइड्स की तुलना `equals` मेथड से की जा सकती है, जो [BaseSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/) से विरासत में मिली है। तुलना में संरचना और स्थैतिक सामग्री जाँची जाती है, जैसे आकृतियां, टेक्स्ट, फ़ॉर्मेटिंग, एनीमेशन, और अन्य स्लाइड सेटिंग्स। यह अनन्य पहचानकर्ताओं जैसे स्लाइड ID, या गतिशील प्लेसहोल्डर मान जैसे वर्तमान तिथि की तुलना नहीं करती।

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

अधिक जानकारी के लिए देखें [Compare Presentation Slides](/slides/hi/nodejs-java/compare-slides/)।

## **डिफ़ॉल्ट व्यू के रूप में स्लाइड मास्टर व्यू सेट करें**

[ViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/) पर `setLastView` मेथड का उपयोग करके PowerPoint द्वारा प्रथम खोलते समय का व्यू नियंत्रित करें। निम्न उदाहरण प्रस्तुति को स्लाइड मास्टर व्यू में खोलता है:

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

अधिक व्यू सेटिंग्स के लिए देखें [Save Presentation](/slides/hi/nodejs-java/save-presentation/)।

## **अप्रयुक्त मास्टर स्लाइड्स हटाएँ**

कभी-कभी प्रस्तुतियों में ऐसी मास्टर स्लाइड्स होती हैं जो अब किसी सामान्य स्लाइड द्वारा उपयोग नहीं की जातीं। अप्रयुक्त मास्टर को हटाने से फ़ाइल आकार कम हो सकता है और टेम्पलेट रखरखाव सरल हो जाता है।

`removeUnused` का उपयोग करके `getMasters()` संग्रह से अप्रयुक्त मास्टर को हटाएँ:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड मास्टर और लेआउट स्लाइड में क्या अंतर है?**

स्लाइड मास्टर साझा डिज़ाइन सेटिंग्स जैसे थीम, पृष्ठभूमि, सामान्य आकृतियां, और टेक्स्ट स्टाइल को परिभाषित करता है। लेआउट स्लाइड एक मास्टर स्लाइड से जुड़ी होती है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था को परिभाषित करती है। सामान्य स्लाइड एक लेआउट स्लाइड का उपयोग करती है, इसलिए वह लेआउट और मास्टर दोनों से विरासत में लेती है।

**क्या एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं?**

हाँ। एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं। जब विभिन्न अनुभागों को अलग विज़ुअल सिस्टम या ब्रांडिंग की आवश्यकता हो, तो कई मास्टर का उपयोग करें।

**क्या मुझे प्लेसहोल्डर्स मास्टर स्लाइड में जोड़ने चाहिए या लेआउट स्लाइड में?**

अधिकांश मामलों में प्लेसहोल्डर्स को लेआउट स्लाइड्स में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग मास्टर स्लाइड पर रखें, फिर सामग्री प्लेसहोल्डर्स को उन लेआउट्स में रखें जिन्हें सामान्य स्लाइड्स उपयोग करेंगी।

**क्या मैं उस मास्टर स्लाइड को हटा सकता हूँ जो अभी भी उपयोग में है?**

नहीं। जिस मास्टर स्लाइड पर निर्भर स्लाइड्स हैं, उसे सीधे हटाना सुरक्षित नहीं है। पहले उन स्लाइड्स को किसी अन्य मास्टर के तहत लेआउट्स में स्थानांतरित करें, या एक अप्रयुक्त‑मास्टर सफ़ाई विधि का उपयोग करें जो केवल असुजुड़ी मास्टर को हटाती है।