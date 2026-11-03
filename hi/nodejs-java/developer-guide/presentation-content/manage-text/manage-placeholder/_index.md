---
title: जावास्क्रिप्ट में प्रस्तुति प्लेसहोल्डर का प्रबंधन
linktitle: प्लेसहोल्डर प्रबंधन
type: docs
weight: 10
url: /hi/nodejs-java/manage-placeholder/
keywords:
- प्लेसहोल्डर
- टेक्स्ट प्लेसहोल्डर
- छवि प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- सामग्री प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ जावास्क्रिप्ट के माध्यम से टेक्स्ट, चित्र, चार्ट और सामग्री प्लेसहोल्डर को निरीक्षण और संपादित करना तथा प्लेसहोल्डर विरासत को समझना सीखें।"
---
## **अवलोकन**

एक प्लेसहोल्डर वह आकार है जो प्रस्तुति टेम्प्लेट में किसी विशिष्ट प्रकार की सामग्री के लिए एक स्थान आरक्षित करता है। सामान्य उदाहरणों में शीर्षक, मुख्य भाग, चित्र, चार्ट और सामान्य‑उद्देश्य सामग्री प्लेसहोल्डर शामिल हैं। सामान्य आकार की तुलना में, एक प्लेसहोल्डर अपना स्थान, आकार, फ़ॉर्मेटिंग और अन्य सेटिंग्स लेआउट स्लाइड या मास्टर स्लाइड से विरासत में ले सकता है।

Aspose.Slides प्लेसहोल्डर जानकारी को [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) मेथड के माध्यम से उजागर करता है। यह मेथड एक [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) ऑब्जेक्ट या सामान्य आकार के लिए `null` लौटाता है। प्लेसहोल्डर क्या रखने के लिये अभिप्रेत है, यह निर्धारित करने हेतु [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) का प्रयोग करें।

प्लेसहोल्डर प्रकार ज्ञात होने के बाद आकार क्लास अभी भी महत्वपूर्ण है:

- एक खाली टेक्स्ट, चित्र, चार्ट या सामग्री प्लेसहोल्डर आम तौर पर एक [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) द्वारा दर्शाया जाता है।
- एक भरा हुआ चित्र प्लेसहोल्डर को एक [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) द्वारा दर्शाया जा सकता है।
- एक भरा हुआ चार्ट प्लेसहोल्डर को एक [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) द्वारा दर्शाया जा सकता है।
- एक सामग्री प्लेसहोल्डर कई प्रकार की सामग्री रख सकता है। प्रत्येक प्लेसहोल्डर को [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) मानने के बजाय दोनों [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) और रन‑टाइम आकार क्लास को जाँचें।

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) प्लेसहोल्डर की भूमिका का वर्णन करता है; यह आकार के रन‑टाइम टाइप की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल या मीडिया‑विशिष्ट सदस्य तक पहुँचने से पहले हमेशा टाइप चेक का प्रयोग करें।
{{% /alert %}}

## **प्लेसहोल्डर विरासत को समझें**

प्लेसहोल्डर एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: उपयोग योग्य शैलियों और कुछ मामलों में मास्टर‑स्तर के प्लेसहोल्डर को परिभाषित करती है।
2. एक लेआउट स्लाइड वह व्यवस्था निर्धारित करती है जिसका प्रयोग एक या अधिक सामान्य स्लाइड्स द्वारा किया जाता है और यह मास्टर से विरासत में ले सकती है।
3. एक सामान्य स्लाइड उस स्लाइड के प्लेसहोल्डर को रखती है और अपनी लेआउट से विरासत ले सकती है।

[Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) को कॉल करके इस पदानुक्रम में एक स्तर ऊपर जाएँ। एक स्लाइड प्लेसहोल्डर सामान्यतः अपना लेआउट प्लेसहोल्डर लौटाता है; एक लेआउट प्लेसहोल्डर अपना मास्टर प्लेसहोल्डर लौटा सकता है। जब आकार के पास कोई बेस प्लेसहोल्डर नहीं होता तो यह मेथड `null` लौटाता है।

निम्न उदाहरण पहले स्लाइड पर प्लेसहोल्डर सूचीबद्ध करता है और उनके बेस प्लेसहोल्डर की रिपोर्ट करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

एक सामान्य स्लाइड पर प्लेसहोल्डर का संपादन उस स्लाइड के लिए एक स्थानीय ओवरराइट बनाता या बदलता है। संबंधित लेआउट या मास्टर का संपादन उन सभी स्लाइड्स को प्रभावित कर सकता है जो अभी भी वह सेटिंग विरासत में लेते हैं। एक स्थानीय सामान्य आकार का कोई बेस प्लेसहोल्डर नहीं होता और केवल इसी निर्देशांक में स्थित होने के कारण वह विरासत शुरू नहीं करता।

## **प्लेसहोल्डर स्थिति हटाएँ**

टेम्प्लेट को अनुकूलित करते समय, मौजूदा ऑब्जेक्ट को एक सामान्य आकार के रूप में बनाए रखने के लिये [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) का उपयोग करें। इसका [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) मेथड `null` लौटाता है, लेकिन आकार स्लाइड के संग्रह में बना रहता है। इसके विपरीत, [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) आकार को उस संग्रह से हटाता है।

निम्न उदाहरण के लिये `template.pptx` आवश्यक है जिसमें कम से कम एक स्लाइड और पहले स्लाइड पर एक गैर‑खाली टेक्स्ट प्लेसहोल्डर हो। लेआउट या मास्टर से विरासत में मिली फ़ॉर्मेटिंग वाले प्लेसहोल्डर को प्रयोग करें ताकि संबंध हटाने के प्रभाव को देखा जा सके। उदाहरण जांचता है कि वही आकार बना रहता है, फिर उसी सामान्य आकार पर मेथड को फिर से कॉल करता है और परिणाम सहेजता है।

{{% alert color="warning" title="Warning" %}}
प्लेसहोल्डर स्थिति हटाने से विरासत में मिली उपस्थिति सेटिंग्स स्वचालित रूप से संरक्षित नहीं रहतीं। नीचे दिया गया उदाहरण जानबूझकर इन सेटिंग्स को अपरिवर्तित छोड़ता है, इसलिए आउटपुट अलग दिख सकता है। ऐसा आकार जिसका स्थान और आकार पूर्णतः विरासत में मिला हो, कॉल के बाद शून्य निर्देशांक और आयाम प्राप्त कर सकता है और संग्रह में बना रहने के बावजूद अदृश्य हो सकता है।
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // साधारण आकार पर इस मेथड को कॉल करने से कोई प्रभाव नहीं पड़ता।
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

मैचिंग प्लेसहोल्डर के लिये सभी तीन जाँच `true` प्रिंट करती हैं। टेक्स्ट बना रहता है, लेकिन विरासत में मिला स्थान, आकार, घूर्णन, फ़ॉन्ट, पैराग्राफ संरेखण, टेक्स्ट‑फ़्रेम मार्जिन, लंबवत एंकरिंग, भराव और लाइन सेटिंग्स प्लेसहोल्डर संबंध हटने पर बदल सकते हैं। उदाहरण के लिये, विरासत में मिली शीर्षक फ़ॉर्मेटिंग सामान्य टेक्स्ट फ़ॉर्मेटिंग में गिर सकती है। अधिक जानकारी के लिये [Slide Layout](/slides/hi/nodejs-java/slide-layout/) देखें।

इच्छित उपस्थिति को संरक्षित करने के लिये, कॉल से पहले संकल्पित स्थान, आकार और घूर्णन को कैप्चर करें और आवश्यक प्रभावी फ़ॉर्मेटिंग मानों को अलग‑अलग वेरिएबल में कॉपी करें। इन मानों को आप [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) और [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective) के माध्यम से प्राप्त करें। केवल प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट को पकड़ने पर निर्भर न रहें, क्योंकि संबंध हटने के बाद उनके टेक्स्ट‑फ़ॉर्मेटिंग मान बदल सकते हैं। बाद में इन कैप्चर किए गए मानों को सामान्य आकार पर स्पष्ट रूप से लागू करें, जिसमें फ़ॉन्ट परिवार, आकार, शैली, रंग, पैराग्राफ सेटिंग्स, टेक्स्ट‑फ़्रेम सेटिंग्स, भराव और लाइन शामिल हों।

विरासत में मिले आकार ज्योमेट्री को भी स्पष्ट रूप से [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType) के माध्यम से निर्दिष्ट करना पड़ सकता है। आयताकार टेक्स्ट प्लेसहोल्डर के लिये इसका अर्थ है [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle) असाइन करना; केवल भराव और लाइन को पुनर्स्थापित करने से दिखाई देने वाला आयत नहीं बन सकता। अतिरिक्त प्रभावों या अधिक जटिल फ़ॉर्मेटिंग वाले टेम्प्लेट को भी इन सेटिंग्स को संभालना पड़ेगा।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

शीर्षक, केन्द्रित‑शीर्षक, उपशीर्षक, मुख्य भाग और टेक्स्ट प्लेसहोल्डर सामान्यतः टेक्स्ट का समर्थन करते हैं। उपयोग करने से पहले [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) की जांच करें और फिर उसके [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) मेथड को कॉल करें।

निम्न उदाहरण पहले स्लाइड पर पहला शीर्षक प्लेसहोल्डर अपडेट करता है और परिणाम सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यह पैटर्न चित्र, चार्ट, टेबल या मीडिया प्लेसहोल्डर को [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ऑब्जेक्ट के रूप में मानने से बचाता है। यह भी प्लेसहोल्डर को उसके उद्देश्य से पहचानता है बजाय अस्थिर आकार इंडेक्स पर निर्भर रहने के।

## **लेआउट पर प्रॉम्प्ट टेक्स्ट सेट करें**

प्रॉम्प्ट टेक्स्ट वह डिज़ाइन‑टाइम निर्देश है जो खाली प्लेसहोल्डर में प्रदर्शित होता है, उदाहरण के लिये *Click to add title*। इसे सामान्य स्लाइड के आकार संग्रह से पहुँचने की कोशिश करने के बजाय लेआउट प्लेसहोल्डर पर सेट करें। लेआउट को [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) द्वारा प्राप्त करें और [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) द्वारा लौटाए गए संग्रह पर क्रमबद्ध करें।

निम्न उदाहरण पहले स्लाइड द्वारा उपयोग किए गए लेआउट पर शीर्षक और उपशीर्षक प्रॉम्प्ट को बदलता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

प्रॉम्प्ट टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसे संपादन अनुप्रयोगों में खाली प्लेसहोल्डर के लिये अभिप्रेत है। एक बार उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान कर दे, तो प्रॉम्प्ट अब प्रदर्शित नहीं होता। प्रॉम्प्ट बदलने से लेआउट उपयोग करने वाली स्लाइड्स पर मौजूद टेक्स्ट प्रतिस्थापित नहीं होता।

## **चित्र प्लेसहोल्डर को अपडेट करें**

दो परिस्थितियों को संभालना है:

- यदि चित्र प्लेसहोल्डर पहले से भरा हुआ है और एक [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) द्वारा दर्शाया गया है, तो छवि को [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) और [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) के माध्यम से बदलें।
- यदि यह अभी भी एक खाली प्लेसहोल्डर है, तो [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) द्वारा प्लेसहोल्डर के निर्देशांक पर एक चित्र फ्रेम जोड़ें और खाली प्लेसहोल्डर को हटाएँ।

अगला उदाहरण दोनों मामलों का समर्थन करता है और प्रस्तुति को सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

खाली प्लेसहोल्डर के लिये बनाया गया प्रतिस्थापन एक स्थानीय चित्र फ्रेम है, नया प्लेसहोल्डर नहीं, क्योंकि [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) में कोई सेट्टर नहीं है। यह आरक्षित स्थान बरकरार रखता है लेकिन अब प्लेसहोल्डर‑विशिष्ट व्यवहार नहीं विरासत में लेता। यदि प्लेसहोल्डर संबंध को बनाए रखना आवश्यक है, तो पहले PowerPoint में प्लेसहोल्डर तैयार व भरें, फिर Aspose.Slides के साथ परिणामी [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) को अपडेट करें।

चित्र पारदर्शिता, क्रॉपिंग और अन्य चित्र‑विशिष्ट प्रभावों के लिये देखें [Manage Picture Frames](/slides/hi/nodejs-java/picture-frame/)। ये संचालन चित्र फ्रेम या चित्र भराव से संबंधित हैं, प्लेसहोल्डर मेटाडाटा से नहीं।

## **चार्ट और सामग्री प्लेसहोल्डर के साथ काम करें**

एक भरा हुआ चार्ट प्लेसहोल्डर को एक [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) द्वारा दर्शाया जा सकता है। निम्न उदाहरण प्लेसहोल्डर प्रकार और रन‑टाइम क्लास दोनों के आधार पर ऐसा चार्ट खोजता है, उसका शीर्षक बदलता है और फ़ाइल सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

एक सामान्य सामग्री प्लेसहोल्डर आम तौर पर [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object) रखता है। PowerPoint में यह कई प्रकार की सामग्री (चार्ट, टेबल, डायग्राम, चित्र, मीडिया) के लिये लांचर के रूप में कार्य करता है। एक बार भर जाने के बाद, वास्तविक आकार क्लास का निरीक्षण करके पता करें कि यह क्या रखता है। विशिष्ट लेआउट्स भी [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) या [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram) को उजागर कर सकते हैं।

Aspose.Slides खाली [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) प्लेसहोल्डर को केवल [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) को बदलकर [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) में नहीं बदलता; टाइप को ऑब्जेक्ट के माध्यम से बदला नहीं जा सकता। खाली चार्ट या सामग्री क्षेत्र को प्रोग्रामेटिक रूप से भरने के लिये, आवश्यक ऑब्जेक्ट को प्लेसहोल्डर के निर्देशांक पर जोड़ें और फिर खाली प्लेसहोल्डर को हटाएँ। निम्न उदाहरण चार्ट के लिये यही करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

जोड़ा गया चार्ट एक सामान्य स्थानीय चार्ट है। यह प्लेसहोल्डर के क्षेत्र को घेरेगा लेकिन लेआउट प्लेसहोल्डर से विरासत नहीं लेगा। जब आपको उसकी श्रेणियों, श्रृंखलाओं या वर्कबुक डेटा को बदलना हो तो समर्पित [chart management articles](/slides/hi/nodejs-java/powerpoint-charts/) देखें।

## **सम्पूर्ण उदाहरण: टेक्स्ट या चित्र सामग्री अपडेट करें**

निम्न अंत‑से‑अंत उदाहरण एक टेम्प्लेट खोलता है, पहले स्लाइड पर शीर्षक या चित्र प्लेसहोल्डर खोजता है, प्लेसहोल्डर और आकार प्रकार जांचता है, उपयुक्त सामग्री अपडेट करता है और आउटपुट सहेजता है। उदाहरण जानबूझकर आकार इंडेक्स मानने या प्रत्येक प्लेसहोल्डर को समान क्लास मानने से बचता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**एक बेस प्लेसहोल्डर क्या है?**

बेस प्लेसहोल्डर वह संबंधित आकार है जो लेआउट या मास्टर पर स्थित होता है, जिससे कोई अन्य प्लेसहोल्डर विरासत लेता है। इसे प्राप्त करने के लिये [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) का उपयोग करें। एक सामान्य स्थानीय आकार `null` लौटाता है क्योंकि वह प्लेसहोल्डर पदानुक्रम का हिस्सा नहीं है।

**क्या मैं एक लेआउट प्लेसहोल्डर को संपादित करके सभी स्लाइड शीर्षक बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासत में मिली फ़ॉर्मेटिंग या प्रॉम्प्ट टेक्स्ट बदल सकते हैं, परंतु मौजूदा शीर्षक सामग्री सामान्य स्लाइड्स पर संग्रहीत रहती है। प्रस्तुति में सभी शीर्षक टेक्स्ट को बदलने के लिये स्लाइड्स पर क्रमबद्ध होकर प्रत्येक शीर्षक प्लेसहोल्डर को अपडेट करें।

**मैं तिथि, स्लाइड‑नंबर, हेडर और फुटर प्लेसहोल्डर को कैसे प्रबंधित करूँ?**

उपयुक्त स्लाइड, लेआउट, मास्टर, नोट्स या हैंडआउट स्कोप पर हेडर और फुटर प्रबंधकों का उपयोग करें। विस्तृत उदाहरणों के लिये देखें [Manage Presentation Header and Footer](/slides/hi/nodejs-java/presentation-header-and-footer/).