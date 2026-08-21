---
title: जावास्क्रिप्ट में प्रस्तुतियों में ड्राइंग गाइड्स प्रबंधित करें
linktitle: ड्राइंग गाइड्स
type: docs
weight: 85
url: /hi/nodejs-java/drawing-guides/
keywords:
- ड्राइंग गाइड
- क्षैतिज गाइड
- ऊर्ध्वाधर गाइड
- संरेखण गाइड
- स्लाइड दृश्य
- मास्टर स्लाइड
- लेआउट स्लाइड
- नोट्स मास्टर
- हैंडआउट मास्टर
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint प्रस्तुतियों में क्षैतिज और ऊर्ध्वाधर ड्राइंग गाइड्स जोड़ें, पहुँचें और साफ़ करें।"
---
## **अवलोकन**

ड्राइंग गाइड्स समायोज्य क्षैतिज और लंबवत रेखाएँ हैं जो उपयोगकर्ताओं को PowerPoint में प्रस्तुति को संपादित करते हुए आकारों को लगातार संरेखित करने में मदद करती हैं। वे विशेष रूप से तब उपयोगी होते हैं जब कोई एप्लिकेशन प्रस्तुति बनाता है जिसे बाद में मैन्युअल रूप से परिष्कृत किया जाएगा: एप्लिकेशन वही संरेखन सहायता संग्रहीत कर सकता है जिसे लेखक सामग्री जोड़ते या स्थानांतरित करते समय पालन करें।

ड्राइंग गाइड्स संपादन सहायता हैं, स्लाइड सामग्री नहीं। वे स्लाइड शो या रेंडर किए गए आउटपुट में दिखाई नहीं देते। Aspose.Slides for Node.js via Java इन्हें [DrawingGuidesCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/drawingguidescollection/) क्लास के माध्यम से उजागर करता है। एक गाइड को [DrawingGuide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/drawingguide/) द्वारा दर्शाया जाता है और इसमें अभिविन्यास, स्थिति और रंग होते हैं।

स्थिति को संबंधित स्लाइड या मास्टर के ऊपरी‑बाएँ कोने से पॉइंट्स में मापा जाता है। लंबवत गाइड क्षैतिज निर्देशांक का उपयोग करता है, आमतौर पर शून्य से स्लाइड की चौड़ाई तक। क्षैतिज गाइड लंबवत निर्देशांक का उपयोग करता है, आमतौर पर शून्य से स्लाइड की ऊँचाई तक।

## **स्लाइड दृश्य में गाइड्स जोड़ें**

सामान्य स्लाइड्स को संपादित करते समय प्रदर्शित गाइड्स को प्रबंधित करने के लिए [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) का उपयोग करें। एक [Orientation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/orientation/) मान और पॉइंट्स में स्थिति के साथ [DrawingGuidesCollection.add](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/drawingguidescollection/#add) को कॉल करें।

निम्न उदाहरण स्लाइड के केंद्र के दाएँ एक लंबवत गाइड और उसके नीचे एक क्षैतिज गाइड जोड़ता है:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ड्राइंग गाइड्स तक पहुँचें**

[DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/drawingguidescollection/#getCount) और [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) मेथड्स मौजूदा गाइड्स तक पहुँच प्रदान करते हैं। [DrawingGuide.getOrientation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/drawingguide/#getPosition) और [DrawingGuide.getColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/drawingguide/#getColor) मेथड्स ऐसे मान लौटाते हैं जिन्हें संबंधित सेटर मेथड्स के माध्यम से बदला भी जा सकता है।

निम्न उदाहरण ऊपर निर्मित प्रस्तुति से स्लाइड‑व्यू गाइड्स को पढ़ता है:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **मास्टर और लेआउट स्लाइड्स में गाइड्स जोड़ें**

एक स्लाइड मास्टर और उसके प्रत्येक लेआउट स्लाइड के अपने ड्राइंग‑गाइड संग्रह हो सकते हैं। मास्टर स्लाइड के लिए [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) और लेआउट स्लाइड के लिए [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) का उपयोग करें।

निम्न उदाहरण पहले मास्टर स्लाइड में एक लंबवत गाइड और पहले लेआउट स्लाइड में एक क्षैतिज गाइड जोड़ता है:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **नोट्स और हैंडआउट मास्टर्स में गाइड्स जोड़ें**

नोट्स मास्टर्स और हैंडआउट मास्टर्स भी ड्राइंग गाइड्स को सपोर्ट करते हैं। उनके संग्रह तक पहुँचने के लिए [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) और [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) का उपयोग करें। यदि प्रस्तुति में इन मास्टर्स में से कोई नहीं है, तो `MasterNotesSlideManager.setDefaultMasterNotesSlide` या `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` डिफ़ॉल्ट मास्टर बनाता है और उसे लौटाता है।

निम्न उदाहरण नोट्स मास्टर में एक क्षैतिज गाइड और हैंडआउट मास्टर में एक लंबवत गाइड जोड़ता है:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ड्राइंग गाइड्स साफ़ करें**

किसी विशेष संग्रह से सभी गाइड्स को हटाने के लिए [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/drawingguidescollection/#clear) को कॉल करें। एक संग्रह को साफ़ करने से अन्य स्कोप में संग्रहीत गाइड्स पर कोई प्रभाव नहीं पड़ता।

निम्न उदाहरण स्लाइड‑व्यू गाइड्स और स्लाइड मास्टर, लेआउट स्लाइड, नोट्स मास्टर और हैंडआउट मास्टर पर सभी गाइड्स को बिना गायब मास्टर्स बनाए साफ़ करता है:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ड्राइंग गाइड्स स्लाइड शो या निर्यातित छवियों में दिखते हैं?**

नहीं। ड्राइंग गाइड्स संपादन के लिए संरेखन सहायता हैं और प्रस्तुति सामग्री के रूप में रेंडर नहीं होते।

**क्या कोई ड्राइंग गाइड सीधे व्यक्तिगत सामान्य स्लाइड में जोड़ा जा सकता है?**

सामान्य‑स्लाइड संपादन गाइड्स प्रस्तुति के स्लाइड‑व्यू प्रॉपर्टीज़ में संग्रहीत होते हैं। स्लाइड मास्टर, लेआउट स्लाइड, नोट्स मास्टर और हैंडआउट मास्टर के लिए अलग-अलग गाइड संग्रह उपलब्ध हैं।

**गाइड स्थितियों के लिए कौन‑से यूनिट्स उपयोग होते हैं?**

स्थिति पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट एक इंच के बराबर होते हैं। लंबवत स्थितियों को बाएँ किनारे से और क्षैतिज स्थितियों को ऊपर किनारे से मापा जाता है।

**क्या ड्राइंग गाइड्स को साफ़ करने से आकार हटते हैं या स्लाइड सामग्री बदलती है?**

नहीं। [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/drawingguidescollection/#clear) मेथड केवल चयनित संग्रह में गाइड्स को हटाता है। आकार और अन्य स्लाइड सामग्री अपरिवर्तित रहती है।