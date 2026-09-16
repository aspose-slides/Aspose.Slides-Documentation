---
title: "JavaScript में प्रस्तुति हाइपरलिंक्स प्रबंधित करें"
linktitle: "हाइपरलिंक्स प्रबंधित करें"
type: docs
weight: 20
url: /hi/nodejs-java/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक फ़ॉर्मेट करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- टेक्स्ट हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकृति हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनशील हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक्स जोड़ें, फ़ॉर्मेट करें, अपडेट करें और हटाएं, JavaScript उदाहरणों का उपयोग करके."
---
## **परिचय**

हाइपरलिंक प्रस्तुति सामग्री को वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक आमतौर पर दो उद्देश्यों की सेवा करते हैं:

* पाठ, आकृति, या मीडिया फ्रेम से वेबसाइट खोलें।
* किसी अन्य स्लाइड पर जाएँ, उदाहरण के लिए, सामग्री तालिका से।

Aspose.Slides for Node.js via Java आपको इन लिंक को जोड़ने, उनके रूप और ध्वनि को नियंत्रित करने, उनकी गुणधर्मों को अपडेट करने और हटाने की अनुमति देता है। नीचे दिए गए उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक के साथ कैसे काम करें और प्रस्तुति, स्लाइड या टेक्स्ट‑फ़्रेम स्तर पर हाइपरलिंक तक कैसे पहुँचें।

{{% alert color="info" title="ध्यान दें" %}}
आप प्रस्तुति को [नि:शुल्क ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/hi/editor) से भी संपादित कर सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

आप टेक्स्ट, आकृति या मीडिया फ़्रेम को वेबसाइट URL असाइन कर सकते हैं। जिस तत्व को आप हाइपरलिंक असाइन करते हैं, वह क्लिक‑योग्य क्षेत्र निर्धारित करता है: टेक्स्ट भाग चयनित टेक्स्ट को लिंक करता है, जबकि आकृति या फ़्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

### **पाठ में URL हाइपरलिंक जोड़ें**

पाठ को वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार टेक्स्ट भाग के [setHyperlinkClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) मेथड में एक [Hyperlink](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink) पास करें। केवल वह टेक्स्ट भाग क्लिक‑योग्य बन जाता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **आकृति और मीडिया फ़्रेम में URL हाइपरलिंक जोड़ें**

आकृति या फ़्रेम को क्लिक‑योग्य बनाने के लिए उसके [setHyperlinkClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#setHyperlinkClick) मेथड को कॉल करें। हाइपरलिंक स्वयं ऑब्जेक्ट से जुड़ा होता है, न कि उसके भीतर के टेक्स्ट भाग से।

एक ही दृष्टिकोण चित्र, ऑडियो और वीडियो फ़्रेम पर लागू होता है: फ़्रेम को हाइपरलिंक असाइन करें और आवश्यकता हो तो [setTooltip](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setTooltip) को कॉल करें।

निम्न उदाहरण एक आयत को क्लिक‑योग्य बनाता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **हाइपरलिंक का उपयोग करके सामग्री तालिका बनाएं**

आंतरिक हाइपरलिंक पाठकों को सामग्री तालिका से किसी विशिष्ट स्लाइड पर कूदने की सुविधा देता है। नीचे दिया गया उदाहरण [setInternalHyperlinkClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) का उपयोग कर प्रथम स्लाइड पर “Page 2” टेक्स्ट को दूसरी स्लाइड से लिंक करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **हाइपरलिंक स्वरूपित करें**

### **रंग**

[Hyperlink](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink) का [setColorSource](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setColorSource) मेथड निर्धारित करता है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करे या टेक्स्ट भाग के फॉर्मेटिंग को। कस्टम टेक्स्ट रंग लागू करने के लिये [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkColorSource) चुनें और भाग के भराव रंग को सेट करें। यह सुविधा PowerPoint 2019 में पेश की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

निम्न उदाहरण समान स्लाइड पर दो टेक्स्ट हाइपरलिंक जोड़ता है। पहला लाल टेक्स्ट भराव का उपयोग करता है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग बनाए रखता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ध्वनि**

हाइपरलिंक सक्रिय होने पर ध्वनि चलाया जा सकता है या पहले से चल रही ध्वनि को रोका जा सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए नीचे दिए मेथड्स उपयोग करें:

- [Hyperlink.setSound](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setSound) हाइपरलिंक से जुड़ी ऑडियो को निर्दिष्ट करता है।
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) नियंत्रित करता है कि हाइपरलिंक सक्रिय होने पर पिछली ध्वनि बंद होनी चाहिए या नहीं।

#### **हाइपरलिंक ध्वनि जोड़ें**

निम्न उदाहरण `sampleaudio.wav` को लोड करता है और प्रथम स्लाइड पर एक बटन से जोड़ता है। बटन क्लिक करने पर ध्वनि चलती है और अगली स्लाइड पर नेविगेट करता है। उसी स्लाइड पर दूसरा आकार क्लिक होने पर पिछली ध्वनि को रोकता है, बिना कोई नेविगेशन कार्रवाई किए।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **हाइपरलिंक ध्वनि निकालें**

निम्न उदाहरण ऊपर बनाई गई प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को [getSound](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#getSound) और [getBinaryData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Audio#getBinaryData) के माध्यम से मेमोरी में पढ़ता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **टूलटिप और इंटरैक्शन सेटिंग्स**

टेक्स्ट या आकृति को हाइपरलिंक असाइन करने के बाद आप निम्न [Hyperlink](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink) मेथड्स को कॉल कर सकते हैं:

- [setTooltip](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setTooltip) वह टेक्स्ट सेट करता है जिसे दर्शक लिंक के लिए संकेत के रूप में देख सकता है।
- [setTargetFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) लागू होने पर पैरेंट HTML फ़्रेमसेट के भीतर लक्ष्य फ़्रेम निर्दिष्ट करता है।
- [setHistory](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setHistory) नियंत्रित करता है कि लिंक को सक्रिय करने से उसका गंतव्य देखी गई हाइपरलिंक्स की सूची में जोड़ना चाहिए या नहीं।
- [setHighlightClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) नियंत्रित करता है कि क्लिक होने पर हाइपरलिंक को हाइलाइट किया जाना चाहिए या नहीं।

## **प्रस्तुति से हाइपरलिंक हटाएँ**

परिवर्तनों से पहले टेक्स्ट‑पोर्टियन लिंक सहित हाइपरलिंक कंटेनर इकट्ठा करने के लिये [getAnyHyperlinks](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) का उपयोग करें। नीचे दिया गया उदाहरण प्रथम स्लाइड से दोनों सक्रियता प्रकारों को हटाता है। केवल एक प्रकार हटाने के लिये केवल [removeHyperlinkClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) या [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) को कॉल करें; क्लिक कार्रवाई को हटाने से उसका माउस‑ओवर समकक्ष नहीं हटता।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

बिना शर्त हटाने के लिये, [removeAllHyperlinks](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) चयनित स्कोप में एक कॉल में दोनों सक्रियता प्रकारों को हटा देता है। चयनात्मक सफ़ाई और मास्टर, लेआउट और नोट्स की कवरेज के लिये देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

## **पूर्ण हाइपरलिंक इन्वेंट्री बनाएँ**

प्रस्तुति वितरित करने से पहले, उसकी इंटरैक्टिव कार्रवाइयों तथा वेब लिंक की इन्वेंट्री बनाएँ। [getAnyHyperlinks](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) हाइपरलिंक कंटेनर लौटाता है, न कि URL स्ट्रिंग की फ्लैट सूची। प्रत्येक कंटेनर पर दोनों [getHyperlinkClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getHyperlinkClick) और [getHyperlinkMouseOver](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) निरीक्षण करें। ये स्वतंत्र हैं: एक ही कंटेनर दोनों कार्यों को प्रकट कर सकता है, इसलिए पूर्ण रिपोर्ट के लिये कंटेनर‑प्रति दो पंक्तियों की आवश्यकता हो सकती है।

केवल शape‑लेवल हाइपरलिंक स्कैन करने से टेक्स्ट‑पोर्टियन से जुड़े लिंक छूट सकते हैं। इसके बजाय उपयुक्त स्कोप क्वेरी करें, और लौटाए गए कंटेनर को रख‑रखाव करें ताकि बाद में आप उनके कार्यों को अपडेट या हटाया जा सके।

### **प्रस्तुति, स्लाइड और टेक्स्ट‑फ़्रेम स्कोप क्वेरी करें**

[HyperlinkQueries](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries) क्लास [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) और [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) के माध्यम से उपलब्ध है। प्रत्येक स्कोप समान क्वेरी का समर्थन करता है:

- [getHyperlinkClicks](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) क्लिक कार्रवाई वाले कंटेनर लौटाता है।
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) माउस‑ओवर कार्रवाई वाले कंटेनर लौटाता है।
- [getAnyHyperlinks](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) किसी भी या दोनों कार्यों वाले कंटेनर लौटाता है।

निम्न उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें बाहरी क्लिक लिंक, फ़ाइल माउस‑ओवर लिंक, आंतरिक स्लाइड नेविगेशन, टेक्स्ट माउस‑ओवर लिंक और मैक्रो क्रिया शामिल हैं। यह इन कार्यों में से कोई भी निष्पादित नहीं करता। समान तीन क्वेरी हर स्कोप पर काम करती हैं; गिनती कंटेनर दर्शाती है, कार्य कुल नहीं। टेक्स्ट‑फ़्रेम स्कोप अपने enclosing shape के स्वयं के लिंक को बाहर रखता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

इस उदाहरण में, प्रस्तुति और स्लाइड क्वेरी क्रमशः तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर और किसी भी कार्य वाले तीन कंटेनर रिपोर्ट करती हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक वर्ग में एक कंटेनर रिपोर्ट करती है।

### **क्रियाओं और गंतव्यों को वर्गीकृत करें**

एक क्रिया को उसके गंतव्य से पहले समझने के लिये [Hyperlink.getActionType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#getActionType) का उपयोग करें। [HyperlinkActionType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkActionType) मान वेब नेविगेशन से अधिक को कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाह्य हाइपरलिंक; URL और उसके स्कीम की जाँच करें। |
| `JumpSpecificSlide` | किसी विशिष्ट स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | निर्मित स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो समाप्त करें या कस्टम शो शुरू करें। |
| `StartMacro` | मैक्रो चलाएँ। |
| `StartProgram` | प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग जाँचें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन क्रिया नहीं, या अपरिचित क्रिया जिसके लिये समीक्षा आवश्यक है। |

बाहरी गंतव्य को [getExternalUrl](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) से और विशिष्ट आंतरिक गंतव्य को [getTargetSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) से पढ़ें। आंतरिक क्रियाओं और निर्मित कमांड्स में बाहरी URL नहीं हो सकता; खाली URL का अर्थ यह नहीं कि कंटेनर में कोई क्रिया नहीं है। जब सामान्यीकृत URL से अलग हो तो [getExternalUrlOriginal](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) द्वारा लौटाए गए मान को संरक्षित रखें, और उपलब्ध होने पर [getTooltip](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Hyperlink#getTooltip) द्वारा लौटाए गए टूलटिप को शामिल करें।

### **हाइपरलिंक की रिपोर्ट, सैनिटाइज़ और सत्यापित करें**

निम्न JavaScript उदाहरण मौजूदा प्रस्तुति (ऊपर बनाई गई फ़ाइल) को पढ़ता है, `hyperlink-audit.json` लिखता है, एक नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और फिर दोनो सक्रियता प्रकारों को दोबारा जाँचने के लिये इसे पुनः खोलता है। कंटेनर को बदलने से पहले इकट्ठा करता है और समान कंटेनर को दो बार प्रोसेस करने से बचने के लिये रेफ़रेंस समानता का उपयोग करता है। प्रस्तुति क्वेरी सामान्य स्लाइड्स को कवर करती है; पैकेज‑व्यापी इन्वेंट्री के लिये, यह स्पष्ट रूप से मास्टर, लेआउट, नोट्स, तथा नोट्स और हैंडआウト मास्टर को भी क्वेरी करती है जब मौजूद हों।

रिपोर्ट एक‑आधारित स्लाइड इंडेक्स और जहाँ उपलब्ध हो [getSlideId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/BaseSlide#getSlideId) रखती है। [getSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getSlide) समर्थित कंटेनर के लिए स्वामित्व वाली स्लाइड प्रदान करता है। मास्टर, लेआउट और नोट्स का कोई सामान्य स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप द्वारा पहचाना जाता है। शेप कंटेनर और टेक्स्ट‑पोर्टियन फॉर्मेट कंटेनर अलग‑अलग लेबल किए जाते हैं; अन्य कंटेनर प्रकार अपना रन‑टाइम टाइप नाम रखते हैं। प्रत्येक कंटेनर को एक रिपोर्ट‑लोकल ID दी जाती है ताकि उसकी दो कार्रवाइयों को आपस में जोड़ा जा सके। रिपोर्ट कार्रवाई प्रकार को HyperlinkActionType एन्यूमरेशन द्वारा निर्धारित पूर्णांक स्थिरांक के रूप में संग्रहीत करती है।

यह प्रतिबंधित लागू नीति केवल निरपेक्ष HTTPS URL और वैध आंतरिक स्लाइड लक्ष्य की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्रवाइयों, अन्य स्लाइडशो कार्रवाइयों, अज्ञात कार्रवाइयों और अन्य URL स्कीम को अस्वीकार करती है। ये अस्वीकार नीति निर्णय हैं, Aspose.Slides सुरक्षा निर्णय नहीं। केवल HTTPS भरोसेमंद नहीं है: अपने अनुप्रयोग के लिये होस्ट अलाउलिस्ट और अन्य जाँचें जोड़ें। मूल और सामान्यीकृत दोनों बाहरी URL जाँचें जाती हैं। उदाहरण लिंक का अनुसरण किए बिना या कार्रवाई चलाए बिना मेटाडेटा का ऑडिट करता है।

निवारण के लिये, कंटेनर का [getHyperlinkManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getHyperlinkManager) [setExternalHyperlinkClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) और [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) को समर्थन देता है। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक स्थिर HTTPS लैंडिंग पेज से बदल दिया जाता है; अन्य प्रतिबंधित क्लिक और प्रतिबंधित माउस‑ओवर कार्रवाई को स्वतंत्र रूप से हटाया जाता है। सभी नीति उल्लंघनों को हटाने के लिये `replaceExternalClicks` को `false` सेट करें। तैनाती से पहले अनुप्रयोग‑स्वामित्व वाले प्रतिस्थापन पेज चुनें।

रिपोर्ट का निर्यात फ़्लैग एक रूढ़िवादी PDF समीक्षा नीति का उपयोग करता है: माउस‑ओवर कार्रवाई और बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा किसी भी चीज़ को संभावित रूप से असहाय के रूप में चिह्नित करता है। यह समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि अनफ़्लैग्ड लिंक निर्यात में survive करेंगे। समर्थित [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/) निर्यात में कार्रवाई, निर्यात विकल्प और दर्शक के आधार पर हाइपरलिंक बरकरार रह सकते हैं। रास्टर [images](/slides/hi/nodejs-java/convert-powerpoint-to-png/) और [video](/slides/hi/nodejs-java/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक नहीं रख सकते; उन आउटपुट के लिये ऑडिट करते समय हर कार्रवाई को चिह्नित करें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

ऊपर बनाई गई इनपुट के साथ, रिपोर्ट में पाँच कार्रवाई पंक्तियाँ होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए जाते हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहता है। सत्यापन शून्य प्रतिबंधित कार्रवाई प्रिंट करता है। प्रतिबंधित बाहरी क्लिक URL वाली इनपुट भी प्रतिस्थापन शाखा को सक्रिय करती है। अनुमत क्लिक और प्रतिबंधित माउस‑ओवर वाला कंटेनर अपनी क्लिक कार्रवाई बरकरार रखता है।

यह चयनात्मक सफ़ाई [removeAllHyperlinks](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) से भिन्न है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटा देता है। यहाँ सत्यापन केवल हाइपरलिंक कार्रवाइयों को जाँचता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को नहीं हटाता, और न ही निर्यातित PDF या HTML फ़ाइल को मान्य करता है।

## **प्रश्नोत्तर**

**मैं किसी सेक्शन या उसकी पहली स्लाइड से कैसे लिंक कर सकता हूँ?**

PowerPoint में सेक्शन स्लाइडों को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्षित करता है। सेक्शन में नेविगेशन बनाने के लिये, उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक जोड़ सकता हूँ ताकि यह सभी स्लाइडों पर काम करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। इन तत्वों पर लिंक स्लाइड शो के दौरान उन स्लाइडों पर उपलब्ध होते हैं जो संबंधित मास्टर या लेआउट का उपयोग करती हैं।

**क्या हाइपरलिंक PDF, HTML, images या video में एक्सपोर्ट करने पर बरकरार रहेंगे?**

समर्थित PDF और HTML निर्यात हाइपरलिंक को बरकरार रख सकते हैं; रास्टर इमेज और वीडियो नहीं रख सकते। विस्तृत निर्यात विचारों के लिये देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।