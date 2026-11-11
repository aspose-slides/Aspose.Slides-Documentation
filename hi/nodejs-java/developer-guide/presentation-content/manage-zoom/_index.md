---
title: जावास्क्रिप्ट में प्रेजेंटेशन ज़ूम प्रबंधित करें
linktitle: ज़ूम प्रबंधित करें
type: docs
weight: 60
url: /hi/nodejs-java/manage-zoom/
keywords:
- ज़ूम
- ज़ूम फ्रेम
- स्लाइड ज़ूम
- सेक्शन ज़ूम
- सारांश ज़ूम
- ज़ूम जोड़ें
- PowerPoint
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ ज़ूम बनाएं और अनुकूलित करें — सेक्शनों के बीच कूदें, थंबनेल और ट्रांज़िशन PowerPoint प्रेजेंटेशन में जोड़ें।"
---
## **परिचय**

PowerPoint ज़ूम आपको स्लाइड शो के दौरान विशिष्ट स्लाइडों और अनुभागों के बीच नेविगेट करने की अनुमति देते हैं। Aspose.Slides for Node.js via Java के साथ, आप स्लाइड, सेक्शन और समरी ज़ूम बना सकते हैं और उनके प्रीव्यू, बॉर्डर और ट्रांज़िशन को अनुकूलित कर सकते हैं।

![PowerPoint ज़ूम ओवरव्यू](overview.png)

* पूरे प्रेजेंटेशन को एक ही स्लाइड पर सारांशित करने के लिए, एक [सारांश ज़ूम](#summary-zoom) का उपयोग करें।
* केवल चयनित स्लाइड दिखाने के लिए, एक [स्लाइड ज़ूम](#slide-zoom) का उपयोग करें।
* केवल एक सेक्शन दिखाने के लिए, एक [सेक्शन ज़ूम](#section-zoom) का उपयोग करें।

## **स्लाइड ज़ूम**

एक स्लाइड ज़ूम आपके प्रेजेंटेशन को अधिक गतिशील बना सकता है, जिससे आप किसी भी क्रम में स्लाइडों के बीच स्वतंत्र रूप से नेविगेट कर सकते हैं बिना प्रेजेंटेशन के प्रवाह को बाधित किए। स्लाइड ज़ूम छोटे प्रेजेंटेशन के लिए उपयोगी हैं जिनमें कई सेक्शन नहीं होते, लेकिन आप उन्हें विभिन्न प्रेजेंटेशन परिदृश्यों में भी उपयोग कर सकते हैं।

स्लाइड ज़ूम आपको एक ही ओवरव्यू स्लाइड से संबंधित जानकारी का अन्वेषण करने की अनुमति देते हैं।

![स्लाइड ज़ूम के लिए स्लाइड चयन](slidezoomsel.png)

स्लाइड ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [ZoomImageType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomimagetype/) एन्यूमरेशन, [ZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomframe/) क्लास, और [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) क्लास पर मेथड्स प्रदान करती है।

### **ज़ूम फ्रेम बनाएं**

एक ओवरव्यू स्लाइड पर व्यक्तिगत स्लाइडों के लिंक रखने के लिए [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addZoomFrame) का उपयोग करें। यह उदाहरण दो लक्ष्य स्लाइड बनाता है जिनके बैकग्राउंड और लेबल अलग-अलग हैं, फिर प्रत्येक का प्रीव्यू पहली स्लाइड में जोड़ता है और प्रेजेंटेशन को PPTX के रूप में सहेजता है। फ्रेम की स्थिति और आयाम पॉइंट्स में निर्दिष्ट किए गए हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let secondSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    let thirdSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());

    secondSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    secondSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    thirdSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    thirdSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 189, 183, 107));

    textBox = thirdSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Third Slide");

    overviewSlide.getShapes().addZoomFrame(20, 20, 250, 200, secondSlide);
    overviewSlide.getShapes().addZoomFrame(200, 250, 250, 200, thirdSlide);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **कस्टम इमेज के साथ ज़ूम फ्रेम बनाएं**

लक्षित स्लाइड के डिफ़ॉल्ट प्रीव्यू को बदलने के लिए कस्टम इमेज को [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addZoomFrame) में पास करें। यह उदाहरण एक लोकल इमेज की आवश्यकता रखता है, इसे [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) से लोड करता है, और इसे प्रेजेंटेशन में [ImageCollection.addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) का उपयोग करके जोड़ता है। परिणामी फ्रेम वह इमेज दिखाता है जबकि अभी भी दूसरी स्लाइड से लिंक करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    overviewSlide.getShapes().addZoomFrame(20, 20, 300, 200, slide, previewImage);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ज़ूम फ्रेम फ़ॉर्मेट करें**

यह उदाहरण दो स्लाइड ज़ूम फ्रेम को कस्टमाइज़ करता है। यह पहले फ्रेम को [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage) के माध्यम से एक लोकल इमेज असाइन करता है, और दूसरा फ्रेम पाँच पॉइंट, डैश-डॉट पिंक बॉर्डर [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) के द्वारा देता है। [ZoomObject.setShowBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setShowBackground) को `false` पास करने से दूसरे फ्रेम की पृष्ठभूमि छिप जाती है। कस्टम प्रीव्यू के लिए एक लोकल इमेज आवश्यक है; दोनों फ्रेम सहेजे गए PPTX में अपने स्लाइड टार्गेट को बनाए रखते हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let secondSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    let thirdSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());

    secondSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    secondSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    thirdSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    thirdSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 189, 183, 107));

    textBox = thirdSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Third Slide");

    let firstZoomFrame = overviewSlide.getShapes().addZoomFrame(20, 20, 250, 200, secondSlide);
    let secondZoomFrame = overviewSlide.getShapes().addZoomFrame(200, 250, 250, 200, thirdSlide);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    firstZoomFrame.setZoomImage(previewImage);

    secondZoomFrame.getLineFormat().setWidth(5);
    secondZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 105, 180));
    secondZoomFrame.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    secondZoomFrame.setShowBackground(false);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **सेक्शन ज़ूम**

एक सेक्शन ज़ूम आपके प्रेजेंटेशन के एक सेक्शन से लिंक करता है। इसका उपयोग किसी विषय को फिर से देखने या बताने के लिए किया जाता है कि प्रेजेंटेशन के विभिन्न भाग कैसे जुड़े हैं।

![सेक्शन ज़ूम के लिए सेक्शन चयन](seczoomsel.png)

सेक्शन ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [SectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/) क्लास और [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) क्लास पर मेथड्स प्रदान करती है।

### **सेक्शन ज़ूम फ्रेम बनाएं**

[SectionCollection.addSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectioncollection/#addSection) से एक सेक्शन बनाएं, फिर लौटाए गए सेक्शन को [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSectionZoomFrame) में पास करें। यह उदाहरण पहली स्लाइड पर एक सेक्शन ज़ूम रखता है और इसे एक रंगीन स्लाइड से शुरू होने वाले सेक्शन से लिंक करता है। फ्रेम की स्थिति और आयाम पॉइंट्स में निर्दिष्ट हैं, और प्रेजेंटेशन को PPTX के रूप में सहेजा जाता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let section = presentation.getSections().addSection("Section 1", slide);
    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **कस्टम इमेज के साथ सेक्शन ज़ूम फ्रेम बनाएं**

कस्टम इमेज के साथ सेक्शन ज़ूम फ्रेम बनाने के लिए [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSectionZoomFrame) का इमेज ओवरलोड आपको लक्ष्य सेक्शन बदले बिना कस्टम प्रीव्यू दिखाने की अनुमति देता है। यह उदाहरण एक लोकल इमेज की आवश्यकता रखता है, जिसे [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) से लोड किया जाता है और [ImageCollection.addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) के माध्यम से जोड़ा जाता है। सहेजा गया प्रेजेंटेशन पहली स्लाइड पर एक सेक्शन ज़ूम रखता है जो नई बनाई गयी सेक्शन से लिंक है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    let section = presentation.getSections().addSection("Section 1", slide);
    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, previewImage);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **सेक्शन ज़ूम के लक्ष्य सेक्शन को बदलें**

[SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/#setTargetSection) का उपयोग करके मौजूदा सेक्शन ज़ूम को पुनर्निर्देशित किया जा सकता है बिना उसे पुनः बनाने के। समान प्रेजेंटेशन की [Presentation.getSections](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSections) संग्रह से एक भरा हुआ सेक्शन चुनें। खाली सेक्शन असाइन करने से वर्तमान लक्ष्य अपरिवर्तित रहता है, इसलिए असाइन करने से पहले [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSlidesListOfSection) जाँचें। सेक्शन के बारे में अधिक जानकारी के लिए देखें [स्लाइड सेक्शन प्रबंधन](/slides/hi/nodejs-java/slide-section/)।

निम्न उदाहरण एक प्रेजेंटेशन फाइल लोड करता है, जिसमें कई भरे हुए सेक्शन, `Section navigation` नामक मौजूदा सेक्शन ज़ूम, तथा `Results` नामक यूनिक सेक्शन मौजूद होना चाहिए। यह सभी स्लाइड्स में ज़ूम खोजता है और नाम द्वारा गंतव्य ढूँढता है, न कि उस संग्रह इंडेक्स से जो सेक्शन पुनः क्रमबद्ध होने पर बदल सकता है। यदि नाम अद्वितीय नहीं हैं, तो गंतव्य पहचानने के लिए [Section.getSectionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSectionId) का उपयोग करें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("section-zoom.pptx");
try {
    let zoom = null;
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            const shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.ISectionZoomFrame") && shape.getName() === "Section navigation") {
                zoom = shape;
                break;
            }
        }
        if (zoom != null) {
            break;
        }
    }

    let targetSection = null;
    for (let i = 0; i < presentation.getSections().size(); i++) {
        const section = presentation.getSections().get_Item(i);
        if (section.getName() === "Results") {
            targetSection = section;
            break;
        }
    }

    if (zoom == null || targetSection == null) {
        console.log("The section zoom or destination section was not found.");
    } else if (targetSection.getSlidesListOfSection().size() == 0) {
        console.log("The destination section is empty.");
    } else {
        let currentSection = zoom.getTargetSection();
        console.log("Current section: " + (currentSection == null ? "" : currentSection.getName()));
        zoom.setTargetSection(targetSection);
        presentation.save("section-zoom-updated.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

### **सेक्शन ज़ूम फ्रेम फ़ॉर्मेट करें**

यह उदाहरण सेक्शन ज़ूम को 100 बाय 75 पॉइंट्स में मूव और रिसाइज़ करता है, [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage) के माध्यम से एक लोकल इमेज असाइन करता है, और 2.5 पॉइंट, डैश-डॉट ब्राउन बॉर्डर लागू करता है। यह [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) को सक्षम करता है ताकि सेक्शन के बाद मूल स्लाइड पर लौट सकें, [ZoomObject.setShowBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setShowBackground) को निष्क्रिय करता है, और [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) को 1.5 सेकंड पर सेट करता है। कस्टम प्रीव्यू के लिए एक लोकल इमेज आवश्यक है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let section = presentation.getSections().addSection("Section 1", slide);

    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section);
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    sectionZoomFrame.setZoomImage(previewImage);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    sectionZoomFrame.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    sectionZoomFrame.getLineFormat().setWidth(2.5);

    sectionZoomFrame.setTransitionDuration(java.newFloat(1.5));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **सारांश ज़ूम**

सारांश ज़ूम प्रेजेंटेशन सेक्शन्स का ओवरव्यू प्रदान करता है। स्लाइड शो के दौरान, आप इसका उपयोग सेक्शन पर कूदने, आगे बढ़ने, या विषय को फिर से देखने के लिए कर सकते हैं बिना स्लाइड क्रम का पालन किए।

![सारांश ज़ूम के लिए सेक्शन चयन](sumzoomsel.png)

सारांश ज़ूम ऑब्जेक्ट्स के लिए, Aspose.Slides [SummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsection/), और [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/) क्लास तथा [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) क्लास पर मेथड्स प्रदान करती है।

### **सारांश ज़ूम बनाएं**

[ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSummaryZoomFrame) का उपयोग करके प्रेजेंटेशन के सेक्शन्स का ओवरव्यू बनाएं। यह उदाहरण चार सेक्शन बनाता है जिनके स्लाइड बैकग्राउंड अलग हैं और पहली स्लाइड में एक सारांश ज़ूम जोड़ता है। फ्रेम की स्थिति और आयाम पॉइंट्स में निर्दिष्ट हैं, और परिणामी ओवरव्यू PPTX प्रेजेंटेशन में सहेजा जाता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 127, 255, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 3", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 100, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 4", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **सारांश ज़ूम सेक्शन जोड़ें और हटाएँ**

सारांश ज़ूम अपने [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsection/) ऑब्जेक्ट को [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) में संग्रहीत करता है। यह उदाहरण दो सेक्शन का ओवरव्यू बनाता है, फिर [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) से तृतीय सेक्शन जोड़ता है, और [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection) से प्रथम सेक्शन का एंट्री हटाता है। एंट्री हटाने से प्रेजेंटेशन सेक्शन और उसकी स्लाइड्स अनछुए रहती हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let firstSection = presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 127, 255, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let thirdSection = presentation.getSections().addSection("Section 3", slide);

    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(thirdSection);

    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(firstSection);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **सारांश ज़ूम सेक्शन फ़ॉर्मेट करें**

यह उदाहरण [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) में पहले एंट्री को, शून्य-आधारित इंडेक्स `0` का उपयोग करके, फ़ॉर्मेट करता है। यह [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage) के लिए एक लोकल इमेज आवश्यक करता है, 1.5 पॉइंट, डैश-डॉट ब्लैक बॉर्डर लागू करता है, और [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) को 1.5 सेकंड पर सेट करता है। [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) को `false` पास करने से इस एंट्री के लिए स्वचालित रूप से सारांश स्लाइड पर लौटना बंद हो जाता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    let summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    summarySection.setZoomImage(previewImage);
    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    summarySection.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    summarySection.getLineFormat().setWidth(1.5);

    summarySection.setTransitionDuration(java.newFloat(1.5));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं लक्ष्य दिखाने के बाद 'पैरेंट' स्लाइड पर लौटने को नियंत्रित कर सकता हूँ?**

हाँ। लक्ष्य सामग्री दिखाने के बाद मूल स्लाइड पर लौटने के लिए [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) को `true` के साथ कॉल करें।

**क्या मैं ज़ूम ट्रांज़िशन की 'गति' या अवधि को समायोजित कर सकता हूँ?**

हाँ। ट्रांज़िशन अवधि को सेकंड में नियंत्रित करने के लिए [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) का उपयोग करें।

**क्या किसी प्रेजेंटेशन में ज़ूम ऑब्जेक्ट्स की संख्या पर कोई सीमा है?**

दस्तावेज़ में कोई कठोर API सीमा नहीं है। व्यावहारिक सीमाएँ कुल प्रेजेंटेशन की जटिलता और दर्शक के प्रदर्शन पर निर्भर करती हैं। आप कई ज़ूम फ्रेम जोड़ सकते हैं, लेकिन फ़ाइल आकार और रेंडरिंग समय का ध्यान रखें।