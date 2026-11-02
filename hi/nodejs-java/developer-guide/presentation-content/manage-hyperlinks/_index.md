---
title: जावास्क्रिप्ट में प्रस्तुति हाइपरलिंक प्रबंधित करें
linktitle: हाइपरलिंक प्रबंधित करें
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
- पाठ हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक जोड़ें, फ़ॉर्मेट करें, अपडेट करें और हटाएं, Aspose.Slides for Node.js via Java के साथ, जावास्क्रिप्ट उदाहरणों का उपयोग करके।"
---
## **परिचय**

हाइपरलिंक प्रस्तुति सामग्री को एक वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक आमतौर पर दो उद्देश्यों की पूर्ति करते हैं:

* पाठ, आकार या मीडिया फ्रेम से वेबसाइट खोलें।
* एक अन्य स्लाइड पर जाएँ, उदाहरण के लिए, सामग्री तालिका से।

Aspose.Slides for Node.js via Java आपको ये लिंक जोड़ने, उनके रूप और ध्वनि को नियंत्रित करने, उनकी गुणों को अपडेट करने और हटाने की सुविधा देता है। नीचे के उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक के साथ कैसे काम करें और प्रस्तुति, स्लाइड या टेक्स्ट‑फ़्रेम स्तर पर हाइपरलिंक तक कैसे पहुँचें।

{{% alert color="info" title="Note" %}}
आप प्रस्तुति को [मुफ़्त ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/editor) के साथ भी संपादित कर सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

आप कोई वेबसाइट URL पाठ, आकार या मीडिया फ़्रेम को असाइन कर सकते हैं। जिस तत्व पर आप हाइपरलिंक असाइन करते हैं, वह क्लिक‑योग्य क्षेत्र निर्धारित करता है: पाठ के भाग से चयनित पाठ लिंक होता है, जबकि आकार या फ़्रेम संपूर्ण स्लाइड ऑब्जेक्ट को लिंक करता है।

सापेक्ष हाइपरलिंक वाली प्रस्तुतियों के लिए, दस्तावेज़‑स्तर बेस को पढ़ने, बदलने या साफ़ करने हेतु [Manage the Hyperlink Base](/slides/hi/nodejs-java/presentation-properties/#manage-the-hyperlink-base) देखें।

### **पाठ में URL हाइपरलिंक जोड़ें**

टेक्स्ट को वेबसाइट से जोड़ने के लिए, नीचे दिखाए अनुसार टेक्स्ट भाग की [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) मेथड में एक [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) पास करें। केवल वही टेक्स्ट भाग क्लिक‑योग्य बन जाता है।

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

### **आकार और मीडिया फ्रेम में URL हाइपरलिंक जोड़ें**

एक आकार या फ्रेम को क्लिक‑योग्य बनाने के लिए, उसकी [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) मेथड को कॉल करें। हाइपरलिंक ऑब्जेक्ट स्वयं से जुड़ा होता है, न कि उसके अंदर के किसी टेक्स्ट भाग से।

इसी विधि को चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू किया जाता है: फ्रेम को हाइपरलिंक असाइन करें और आवश्यक हो तो [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) कॉल करें।

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

## **सामग्री तालिका बनाने के लिए हाइपरलिंक उपयोग करें**

आंतरिक हाइपरलिंक पाठकों को सामग्री तालिका से किसी विशिष्ट स्लाइड पर ले जा सकते हैं। नीचे का उदाहरण पहले स्लाइड पर “Page 2” टेक्स्ट को दूसरी स्लाइड से जोड़ने के लिए [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) का उपयोग करता है।

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

## **हाइपरलिंक फ़ॉर्मेट करें**

### **रंग**

[Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) की [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) मेथड यह निर्धारित करती है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करे या टेक्स्ट भाग की फ़ॉर्मेटिंग का। कस्टम टेक्स्ट रंग लागू करने के लिए, [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) चुनें और भाग का फ़िल रंग सेट करें। यह सुविधा PowerPoint 2019 में पेश की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

निम्न उदाहरण दो टेक्स्ट हाइपरलिंक को एक ही स्लाइड पर जोड़ता है। पहला लाल टेक्स्ट फ़िल के साथ है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग रखता है।

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

हाइपरलिंक सक्रिय होने पर ध्वनि बजा सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए नीचे दिए मेथड का उपयोग करें:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) हाइपरलिंक से जुड़ी ऑडियो को निर्दिष्ट करता है।
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) नियंत्रित करता है कि हाइपरलिंक सक्रिय होने पर पिछली ध्वनि रोक दी जाए।

#### **हाइपरलिंक ध्वनि जोड़ें**

निम्न उदाहरण `sampleaudio.wav` लोड करता है और इसे पहले स्लाइड पर एक बटन से जोड़ता है। बटन क्लिक करने पर ध्वनि बजती है और अगली स्लाइड पर जाता है। उसी स्लाइड का दूसरा आकार क्लिक होने पर ध्वनि को रोकता है, बिना किसी नेविगेशन के।

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

निम्न उदाहरण ऊपर निर्मित प्रस्तुति को खोलता है और प्रथम आकार की हाइपरलिंक ऑडियो को [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) और [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData) के माध्यम से स्मृति में पढ़ता है।

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

टेक्स्ट या आकार को हाइपरलिंक असाइन करने के बाद आप निम्न [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) मेथड कॉल कर सकते हैं:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) लिंक के लिए दर्शक को संकेत (हिंट) के रूप में दिखाने वाला टेक्स्ट सेट करता है।
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) आवश्यकता अनुसार पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ़्रेम निर्दिष्ट करता है।
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) नियंत्रित करता है कि लिंक सक्रिय होने पर उसका लक्ष्य देखे गए हाइपरलिंक की सूची में जोड़ा जाए या नहीं।
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) नियंत्रित करता है कि क्लिक होने पर हाइपरलिंक को हाईलाइट किया जाए या नहीं।

## **प्रस्तुति से हाइपरलिंक हटाएँ**

हाइपरलिंक कंटेनर, जिसमें टेक्स्ट‑भाग लिंक भी शामिल हैं, को एकत्र करने के लिए [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) का उपयोग करें, फिर उनका संशोधन करें। नीचे दिया गया उदाहरण पहले स्लाइड से दोनों सक्रियता प्रकारों को हटाता है। केवल एक प्रकार हटाने के लिए, केवल [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) या [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) को कॉल करें; क्लिक कार्रवाई हटाने से उसके माउस‑ओवर समकक्ष को नहीं हटाया जाता।

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

निस्संदेह हटाने के लिए, [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) चयनित स्कोप में दोनों सक्रियता प्रकारों को एक ही कॉल में हटाता है। मास्टर, लेआउट और नोट्स सहित चयनात्मक सफ़ाई के लिए, देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

## **हाइपरलिंक इन्वेंट्री बनाएं**

प्रस्तुति वितरित करने से पहले, उसकी इंटरैक्टिव कार्रवाई और वेब लिंक दोनों को सूचीबद्ध करें। [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) हाइपरलिंक कंटेनर लौटाता है, न कि URL स्ट्रिंग की फ्लैट सूची। प्रत्येक कंटेनर पर दोनों [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) और [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) की जाँच करें। वे स्वतंत्र होते हैं: एक ही कंटेनर दोनों क्रिया प्रकट कर सकता है, इसलिए पूर्ण रिपोर्ट में प्रति कंटेनर दो पंक्तियाँ तक हो सकती हैं।

केवल आकार‑स्तर के हाइपरलिंक स्कैन करने से टेक्स्ट भागों से जुड़े लिंक छूटा जा सकता है। उपयुक्त स्कोप पर क्वेरी करें, और लौटाए गए कंटेनर को रखें ताकि बाद में उनकी क्रिया को अपडेट या हटाया जा सके।

### **प्रेजेंटेशन, स्लाइड, और टेक्स्ट‑फ़्रेम स्कोप क्वेरी करें**

[HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) क्लास निम्न तरीकों से उपलब्ध है: [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries), तथा [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). प्रत्येक स्कोप समान क्वेरी को सपोर्ट करता है:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) क्लिक‑क्रिया वाले कंटेनर लौटाता है।
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) माउस‑ओवर‑क्रिया वाले कंटेनर लौटाता है।
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) या तो या दोनों क्रिया वाले कंटेनर लौटाता है।

निम्न उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें बाहरी क्लिक लिंक, फ़ाइल माउस‑ओवर लिंक, आंतरिक स्लाइड नेविगेशन, टेक्स्ट माउस‑ओवर लिंक, और मैक्रो कार्रवाई शामिल हैं। ये कार्रवाईयाँ निष्पादित नहीं होतीं। वही तीन क्वेरी हर स्कोप पर काम करती हैं; गिनतियाँ कंटेनर की संख्या दर्शाती हैं, न कि क्रिया कुल। टेक्स्ट‑फ़्रेम स्कोप enclosing shape के लिंक को बाहर रखता है।

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

इस उदाहरण में, प्रस्तुति और स्लाइड क्वेरी क्रमशः तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर, और तीन कंटेनर (किसी भी क्रिया) रिपोर्ट करती हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **क्रिया और गंतव्य वर्गीकरण करें**

हाइपरलिंक की गंतव्य को समझने से पहले उसकी क्रिया को समझने के लिए [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) का उपयोग करें। [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) मान वेब नेविगेशन से अधिक को कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाहरी हाइपरलिंक; URL और उसकी स्कीम की जांच करें। |
| `JumpSpecificSlide` | विशेष स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | बिल्ट‑इन स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो समाप्त करें या कस्टम शो शुरू करें। |
| `StartMacro` | मैक्रो निष्पादित करें। |
| `StartProgram` | प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग समीक्षा करें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन कार्रवाई नहीं, या अनजानी कार्रवाई जिसके लिए समीक्षा आवश्यक है। |

बाहरी गंतव्य को [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) से पढ़ें और विशिष्ट आंतरिक गंतव्य को [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) से। आंतरिक कार्रवाई और बिल्ट‑इन कमांड में बाहरी URL नहीं हो सकता; खाली URL का अर्थ यह नहीं कि कंटेनर में कोई कार्रवाई नहीं है। जब [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) मान सामान्यीकृत URL से भिन्न हो तो उसे संरक्षित रखें, और उपलब्ध होने पर [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) द्वारा लौटाए गए टूलटिप को शामिल करें।

### **हाइपरलिंक रिपोर्ट, साफ‑सफ़ाई और सत्यापन**

निम्न JavaScript उदाहरण मौजूदा प्रस्तुति को पढ़ता है (ऊपर निर्मित फ़ाइल का उपयोग करें), `hyperlink-audit.json` लिखता है, नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और दोबारा खोलकर दोनों सक्रियता प्रकारों की जाँच करता है। यह परिवर्तन से पहले कंटेनर एकत्र करता है और समान कंटेनर को दो बार प्रोसेस न करने के लिए रेफ़रेंस इक्वैलिटी का उपयोग करता है। प्रस्तुति क्वेरी सामान्य स्लाइड को कवर करती है; पैकेज‑व्यापी इन्वेंट्री के लिए यह स्पष्ट रूप से मास्टर, लेआउट, नोट्स और नोट्स एवं हैंडआउट मास्टर को भी क्वेरी करती है।

रिपोर्ट एक‑आधारित स्लाइड इंडेक्स और जहाँ उपलब्ध हो [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) को रिकॉर्ड करती है। [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) समर्थित कंटेनर के स्वामित्व स्लाइड को प्रदान करता है। मास्टर, लेआउट और नोट्स में सामान्य स्लाइड इंडेक्स नहीं होता, इसलिए उनका स्कोप द्वारा पहचान किया जाता है। आकार कंटेनर और टेक्स्ट‑भाग फ़ॉर्मेट कंटेनर अलग‑अलग लेबल किए जाते हैं; अन्य कंटेनर प्रकार अपना रन‑टाइम टाइप नाम रखते हैं। प्रत्येक कंटेनर को रिपोर्ट‑स्थानीय ID दी जाती है ताकि उसकी दो क्रियाओं को जोड़ा जा सके। रिपोर्ट कार्रवाई प्रकार को HyperlinkActionType एनेमरेशन द्वारा परिभाषित पूर्णांक स्थिरांक के रूप में सहेजती है।

यह नीतिगत पॉलिसी केवल पूर्ण HTTPS URLs और वैध आंतरिक स्लाइड लक्ष्य की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्रवाई, अन्य स्लाइडशो कार्रवाई, अज्ञात कार्रवाई और अन्य URL स्कीम को अस्वीकृत करती है। ये अस्वीकृतियाँ नीतिगत निर्णय हैं, Aspose.Slides की सुरक्षा राय नहीं। HTTPS अकेले भरोसे को स्थापित नहीं करता: अपने एप्लिकेशन के लिए होस्ट एलॉवलिस्ट और अन्य जाँच जोड़ें। मूल और सामान्यीकृत दोनों बाहरी URLs जाँचे जाते हैं। उदाहरण लिंक का अनुसरण किए बिना या कार्रवाई चलाए बिना मेटाडाटा ऑडिट करता है।

सुधार के लिए, कंटेनर की [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) और [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) का समर्थन करती है। यहाँ निषिद्ध बाहरी क्लिक लिंक को एक निश्चित HTTPS लैंडिंग पेज से बदल दिया जाता है; अन्य निषिद्ध क्लिक और निषिद्ध माउस‑ओवर कार्रवाई को स्वतंत्र रूप से हटाया जाता है। सभी नीति उल्लंघनों को हटाने हेतु `replaceExternalClicks` को `false` सेट करें। डिप्लॉयमेंट से पहले एक एप्लिकेशन‑स्वामित प्रतिस्थापन पेज चुनें।

रिपोर्ट के एक्सपोर्ट फ़्लैग में एक रूढ़िवादी PDF समीक्षा नीति अपनाई गई है: माउस‑ओवर कार्रवाई और बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा सभी को संभावित रूप से असमर्थित के रूप में चिह्नित किया जाता है। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि अनफ़्लैग किए गए लिंक निर्यात में टिकेंगे। समर्थित [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/nodejs-java/convert-powerpoint-to-html/) निर्यात कार्रवाई, निर्यात विकल्प और व्यूअर के आधार पर हाइपरलिंक संरक्षित कर सकते हैं; रास्टर [छवियाँ](/slides/hi/nodejs-java/convert-powerpoint-to-png/) और [वीडियो](/slides/hi/nodejs-java/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक को संरक्षित नहीं कर सकते; उन आउटपुट के लिए ऑडिट करते समय हर कार्रवाई को फ़्लैग करें।

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

उपरोक्त इनपुट के साथ, रिपोर्ट में पाँच कार्रवाई पंक्तियाँ होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए गये हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहता है। सत्यापन शून्य निषिद्ध कार्रवाई प्रदर्शित करता है। एक निषिद्ध बाहरी क्लिक URL वाले इनपुट में प्रतिस्थापन शाखा भी क्रियाशील होती है। एक अनुमत क्लिक और निषिद्ध माउस‑ओवर वाले कंटेनर में क्लिक कार्रवाई बनी रहती है।

यह चयनात्मक सफ़ाई [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) से भिन्न है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटा देता है। यहाँ सत्यापन केवल हाइपरलिंक कार्रवाई को जांचता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को हटाता नहीं है, और न ही निर्यातित PDF या HTML फ़ाइल को वैधता प्रदान करता है।

## **FAQ**

**मैं सेक्शन या उसके पहले स्लाइड से कैसे लिंक करूँ?**

PowerPoint में सेक्शन स्लाइड को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक एक व्यक्तिगत स्लाइड को लक्षित करता है। सेक्शन पर नेविगेशन बनाने के लिए, उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक लगा सकता हूँ ताकि वह सभी स्लाइड्स पर काम करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। इन तत्वों पर लिंक उन स्लाइड्स पर स्लाइड शो के दौरान उपलब्ध होते हैं जो संबंधित मास्टर या लेआउट का उपयोग करती हैं।

**क्या हाइपरलिंक PDF, HTML, छवियों या वीडियो में निर्यात करने पर बना रहता है?**

समर्थित PDF और HTML निर्यात हाइपरलिंक को संरक्षित कर सकते हैं; रास्टर छवियों और वीडियो में इंटरैक्टिव हाइपरलिंक नहीं रह सकता। विवरण के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).