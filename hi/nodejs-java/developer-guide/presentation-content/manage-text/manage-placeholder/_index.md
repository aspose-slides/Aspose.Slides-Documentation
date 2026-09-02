---
title: जावास्क्रिप्ट में प्रस्तुति प्लेसहोल्डर प्रबंधित करें
linktitle: प्लेसहोल्डर प्रबंधित करें
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
description: "Aspose.Slides for Node.js के साथ जावास्क्रिप्ट के माध्यम से टेक्स्ट, चित्र, चार्ट और सामग्री प्लेसहोल्डर का निरीक्षण और संपादन कैसे करें और प्लेसहोल्डर विरासत को समझें।"
---
## **समीक्षा**

प्लेसहोल्डर एक shape है जो प्रस्तुति टेम्पलेट में एक विशिष्ट प्रकार की सामग्री के लिए स्थान आरक्षित करता है। सामान्य उदाहरणों में शीर्षक, बॉडी, चित्र, चार्ट, और सामान्य उद्देश्य सामग्री प्लेसहोल्डर शामिल हैं। एक सामान्य shape की तुलना में, प्लेसहोल्डर लेआउट स्लाइड या मास्टर स्लाइड से अपनी स्थिति, आकार, स्वरूपण और अन्य सेटिंग्स को विरासत में ले सकता है।

Aspose.Slides प्लेसहोल्डर जानकारी को [Shape.getPlaceholder](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getPlaceholder) मेथड के माध्यम से उजागर करता है। यह मेथड एक [Placeholder](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/placeholder/) ऑब्जेक्ट या सामान्य shape के लिए `null` लौटाता है। यह निर्धारित करने के लिए कि प्लेसहोल्डर में क्या होना चाहिए, [Placeholder.getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/placeholder/#getType) का उपयोग करें।

- एक खाली टेक्स्ट, चित्र, चार्ट, या कंटेंट प्लेसहोल्डर आमतौर पर एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) द्वारा प्रतिनिधित्व किया जाता है।
- एक भरा हुआ चित्र प्लेसहोल्डर को एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) द्वारा प्रतिनिधित्व किया जा सकता है।
- एक भरा हुआ चार्ट प्लेसहोल्डर को एक [Chart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/) द्वारा प्रतिनिधित्व किया जा सकता है।
- एक कंटेंट प्लेसहोल्डर कई प्रकार की सामग्री रख सकता है। प्रत्येक प्लेसहोल्डर को एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) माना जाने के बजाय, दोनों [Placeholder.getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/placeholder/#getType) और रनटाइम shape क्लास को जांचें।

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/placeholder/#getType) प्लेसहोल्डर की भूमिका का वर्णन करता है; यह shape की रनटाइम टाइप की गारंटी नहीं देता। टेक्स्ट, चित्र, चार्ट, टेबल, या मीडिया‑विशिष्ट सदस्यों तक पहुँचने से पहले हमेशा प्रकार जाँच का उपयोग करें।
{{% /alert %}}

## **प्लेसहोल्डर विरासत को समझें**

प्लेसहोल्डर एक पदानुक्रम बनाते हैं:

1. एक मास्टर स्लाइड पुन: उपयोग योग्य शैलियों को परिभाषित करती है और कुछ मामलों में मास्टर‑स्तर के प्लेसहोल्डर भी।
2. एक लेआउट स्लाइड एक या अधिक सामान्य स्लाइड्स द्वारा उपयोग किए जाने वाले व्यवस्थापन को परिभाषित करती है और यह मास्टर से विरासत में ले सकती है।
3. एक सामान्य स्लाइड उसमें स्थित प्लेसहोल्डर रखती है और यह अपने लेआउट से विरासत में ले सकती है।

इस पदानुक्रम में एक स्तर ऊपर जाने के लिए [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getBasePlaceholder) को कॉल करें। एक स्लाइड प्लेसहोल्डर सामान्यतः उसका लेआउट प्लेसहोल्डर लौटाता है; एक लेआउट प्लेसहोल्डर अपना मास्टर प्लेसहोल्डर लौटा सकता है। जब shape के पास कोई बेस प्लेसहोल्डर नहीं होता तो यह मेथड `null` लौटाता है।

निम्नलिखित उदाहरण पहले स्लाइड पर प्लेसहोल्डर सूचीबद्ध करता है और उनके बेस प्लेसहोल्डर रिपोर्ट करता है:

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

एक सामान्य स्लाइड पर प्लेसहोल्डर को संपादित करने से उस स्लाइड के लिए स्थानीय ओवरराइड बनता या बदलता है। संबंधित लेआउट या मास्टर को संपादित करने से उन सभी स्लाइड्स पर असर पड़ता है जो अभी भी वह सेटिंग विरासत में लेती हैं। एक स्थानीय सामान्य shape का कोई बेस प्लेसहोल्डर नहीं होता और केवल समान निर्देशांक होने से वह विरासत नहीं लेना शुरू करता।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

शीर्षक, केंद्रित‑शीर्षक, उपशीर्षक, बॉडी, और टेक्स्ट प्लेसहोल्डर सामान्यतः टेक्स्ट का समर्थन करते हैं। इसके [getTextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/#getTextFrame) मेथड का उपयोग करने से पहले [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) के लिए जांचें।

यह उदाहरण पहले स्लाइड पर पहले शीर्षक प्लेसहोल्डर को अपडेट करता है और परिणाम सहेजता है:

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

यह पैटर्न चित्र, चार्ट, टेबल, या मीडिया प्लेसहोल्डर को [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) ऑब्जेक्ट मानने से बचाता है। यह कमजोर shape इंडेक्स पर निर्भर रहने के बजाय प्लेसहोल्डर को उसके उद्देश्य से पहचानता है।

## **लेआउट पर प्रॉम्प्ट टेक्स्ट सेट करें**

प्रॉम्प्ट टेक्स्ट एक डिज़ाइन‑टाइम निर्देश है जो खाली प्लेसहोल्डर में दिखाया जाता है, जैसे *Click to add title*। इसे सामान्य स्लाइड के shape कलेक्शन के माध्यम से पहुँचने की कोशिश करने के बजाय लेआउट प्लेसहोल्डर पर कस्टम प्रॉम्प्ट टेक्स्ट सेट करें। लेआउट तक पहुँचने के लिए [Slide.getLayoutSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#getLayoutSlide) का उपयोग करें और [BaseSlide.getShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/#getShapes) द्वारा लौटाए गए संग्रह पर इटररेट करें।

निम्नलिखित उदाहरण पहले स्लाइड द्वारा उपयोग किए गए लेआउट पर शीर्षक और उपशीर्षक प्रॉम्प्ट को बदलता है:

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

प्रॉम्प्ट टेक्स्ट सामान्य स्लाइड सामग्री नहीं है। यह PowerPoint जैसे संपादन अनुप्रयोगों में खाली प्लेसहोल्डर के लिए अभिप्रेत है। एक बार उपयोगकर्ता या प्रोग्राम वास्तविक सामग्री प्रदान कर दे, तो प्रॉम्प्ट अब नहीं दिखता। प्रॉम्प्ट बदलने से लेआउट का उपयोग करने वाली स्लाइड्स पर मौजूदा टेक्स्ट भी नहीं बदला जाता।

## **चित्र प्लेसहोल्डर को अपडेट करें**

संबंधित दो मामलों को संभालना है:

- यदि चित्र प्लेसहोल्डर पहले से भरा हुआ है और एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) द्वारा प्रतिनिधित्व किया गया है, तो छवि को [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturefillformat/#getPicture), और [Picture.setImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picture/#setImage) के माध्यम से बदलें।
- यदि यह अभी भी एक खाली प्लेसहोल्डर है, तो प्लेसहोल्डर के निर्देशांक पर [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) से एक picture frame जोड़ें और खाली प्लेसहोल्डर को हटाएँ।

अगला उदाहरण दोनों मामलों को समर्थन देता है और प्रस्तुति को सहेजता है:

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

एक खाली प्लेसहोल्डर के लिए बनाया गया प्रतिस्थापन एक स्थानीय picture frame है, नया प्लेसहोल्डर नहीं, क्योंकि [Shape.getPlaceholder](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getPlaceholder) सेट्टर प्रदान नहीं करता। यह आरक्षित स्थान को रखता है लेकिन अब प्लेसहोल्डर‑विशिष्ट व्यवहार नहीं विरासत में लेता। यदि प्लेसहोल्डर संबंध को बनाए रखना आवश्यक है, तो पहले PowerPoint में प्लेसहोल्डर तैयार और भरें, फिर Aspose.Slides के साथ परिणामस्वरूप [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) को अपडेट करें।

छवि पारदर्शिता, क्रॉपिंग, और अन्य चित्र‑विशिष्ट प्रभावों के लिए, देखें [Manage Picture Frames](/slides/hi/nodejs-java/picture-frame/). ये ऑपरेशन picture frame या picture fill से संबंधित हैं, प्लेसहोल्डर मेटाडेटा से नहीं।

## **चार्ट और कंटेंट प्लेसहोल्डर के साथ काम करें**

भरा हुआ चार्ट प्लेसहोल्डर एक [Chart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/) द्वारा प्रतिनिधित्व किया जा सकता है। यह उदाहरण प्लेसहोल्डर प्रकार और रनटाइम क्लास दोनों से ऐसा चार्ट खोजता है, उसका शीर्षक बदलता है, और फ़ाइल को सहेजता है:

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

एक सामान्य कंटेंट प्लेसहोल्डर आमतौर पर [PlaceholderType.Object](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/placeholdertype/#Object) रखता है। PowerPoint में यह कई कंटेंट प्रकारों जैसे चार्ट, टेबल, डायग्राम, चित्र, और मीडिया के लिए लॉन्चर के रूप में कार्य करता है। एक बार भर जाने के बाद, यह जानने के लिए वास्तविक shape क्लास की जांच करें कि इसमें क्या है। विशिष्ट लेआउट भी [PlaceholderType.Chart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/placeholdertype/#Media), या [PlaceholderType.Diagram](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/placeholdertype/#Diagram) को उजागर कर सकते हैं।

Aspose.Slides केवल [Placeholder.getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/placeholder/#getType) को बदलकर एक खाली [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) प्लेसहोल्डर को [Chart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/) में परिवर्तित नहीं करता; प्रकार को ऑब्जेक्ट के माध्यम से नहीं बदला जा सकता। एक खाली चार्ट या कंटेंट एरिया को प्रोग्रामेटिकली भरने के लिए, प्लेसहोल्डर के निर्देशांक पर आवश्यक ऑब्जेक्ट जोड़ें और फिर खाली प्लेसहोल्डर को हटाएँ। निम्नलिखित उदाहरण चार्ट के लिए यह करता है:

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

जोड़ा गया चार्ट एक सामान्य स्थानीय चार्ट है। यह प्लेसहोल्डर के क्षेत्र को घेरता है लेकिन लेआउट प्लेसहोल्डर से विरासत नहीं लेता। उसके श्रेणियों, श्रृंखलाओं, या वर्कबुक डेटा को बदलने की आवश्यकता होने पर समर्पित [chart management articles](/slides/hi/nodejs-java/powerpoint-charts/) का उपयोग करें।

## **पूर्ण उदाहरण: टेक्स्ट या इमेज सामग्री अपडेट करें**

निम्नलिखित एन्ड‑टू‑एन्ड उदाहरण एक टेम्पलेट खोलता है, पहले स्लाइड में शीर्षक या चित्र प्लेसहोल्डर की तलाश करता है, प्लेसहोल्डर और shape प्रकारों की जाँच करता है, उपयुक्त सामग्री अपडेट करता है, और आउटपुट सहेजता है। उदाहरण जानबूझकर shape इंडेक्स मानने या प्रत्येक प्लेसहोल्डर को एक ही क्लास मानने से बचता है।

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

## **FAQ**

**बेस प्लेसहोल्डर क्या है?**

बेस प्लेसहोल्डर वह संबंधित shape है जो लेआउट या मास्टर पर स्थित होता है और जिससे दूसरा प्लेसहोल्डर विरासत लेता है। इसे प्राप्त करने के लिए [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getBasePlaceholder) का उपयोग करें। एक सामान्य स्थानीय shape `null` लौटाता है क्योंकि वह प्लेसहोल्डर पदानुक्रम का हिस्सा नहीं है।

**क्या मैं लेआउट प्लेसहोल्डर को संपादित करके सभी स्लाइड शीर्षकों को बदल सकता हूँ?**

आप लेआउट के माध्यम से विरासतित फ़ॉर्मेटिंग या प्रॉम्प्ट टेक्स्ट बदल सकते हैं, लेकिन मौजूदा शीर्षक सामग्री सामान्य स्लाइड्स पर संग्रहीत होती है। किसी प्रस्तुति में सभी वास्तविक शीर्षक टेक्स्ट को बदलने के लिए, स्लाइड्स पर इटररेट करें और प्रत्येक शीर्षक प्लेसहोल्डर को अपडेट करें।

**मैं तिथि, स्लाइड‑नंबर, हेडर, और फुटर प्लेसहोल्डर को कैसे प्रबंधित करूँ?**

उपयुक्त स्लाइड, लेआउट, मास्टर, नोट्स, या हैंडआउट स्तर पर हेडर और फुटर प्रबंधकों का उपयोग करें। पूर्ण उदाहरणों के लिए देखें [Manage Presentation Header and Footer](/slides/hi/nodejs-java/presentation-header-and-footer/).