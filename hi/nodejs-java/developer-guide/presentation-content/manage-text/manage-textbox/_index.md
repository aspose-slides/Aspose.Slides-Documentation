---
title: जावास्क्रिप्ट से प्रस्तुतियों में टेक्स्ट बॉक्स का प्रबंधन
linktitle: टेक्स्ट बॉक्स
type: docs
weight: 20
url: /hi/nodejs-java/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ्रेम
- टेक्स्ट जोड़ें
- टेक्स्ट अद्यतन करें
- टेक्स्ट बॉक्स बनाएं
- टेक्स्ट बॉक्स जांचें
- टेक्स्ट कॉलम जोड़ें
- हाइपरलिंक जोड़ें
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट बॉक्स बनाएं, पहचानें, स्वरूपित करें और अद्यतन करें।"
---
## **परिचय**

Aspose.Slides for Node.js via Java में, स्लाइड टेक्स्ट को टेक्स्ट फ्रेम्स में संग्रहीत किया जाता है जो आकृतियों (shapes) से जुड़े होते हैं। AutoShape क्लास सबसे सामान्य टेक्स्ट‑वह‑आकृति को दर्शाती है और इसके टेक्स्ट को AutoShape.getTextFrame मेथड के माध्यम से उपलब्ध कराती है।

{{% alert color="info" title="ध्यान दें" %}}
हर ऑटो शैप Shape से विरासत में मिलता है, लेकिन हर शैप ऑटो शैप नहीं होता या टेक्स्ट फ्रेम का समर्थन नहीं करता। किसी मौजूदा प्रस्तुति को प्रोसेस करते समय, शैप के टेक्स्ट तक पहुँचने से पहले यह जांचें कि वह AutoShape का इंस्टेंस है या नहीं।
{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाना**

टेक्स्ट बॉक्स बनाने के लिए, स्लाइड में एक ऑटो शैप जोड़ें, उसके टेक्स्ट फ्रेम में टेक्स्ट डालें, और प्रस्तुति को सहेजें। नीचे दिया गया उदाहरण एक आयताकार टेक्स्ट बॉक्स बनाता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ShapeCollection.addAutoShape को पास किए गए निर्देशांक और आयाम पॉइंट्स में मापे जाते हैं। AutoShape.addTextFrame प्रदान किए गए टेक्स्ट से टेक्स्ट फ्रेम को प्रारम्भ करता है।

## **टेक्स्ट बॉक्स शैप की जांच**

AutoShape.isTextBox मेथड का उपयोग करके पता करें कि कोई ऑटो शैप टेक्स्ट बॉक्स माना जाता है या नहीं। यह उपयोगी है जब प्रस्तुति में टेक्स्ट‑वह और केवल ग्राफ़िकल ऑटो शैप दोनों हों।

![एक टेक्स्ट बॉक्स और एक शैप](istextbox.png)

निम्न उदाहरण प्रस्तुति में प्रत्येक ऑटो शैप का निरीक्षण करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

नया जुड़ा ऑटो शैप तब तक टेक्स्ट बॉक्स नहीं माना जाता जब तक उसमें गैर‑खाली टेक्स्ट न हो। आप वह टेक्स्ट AutoShape.addTextFrame या TextFrame.setText के माध्यम से दे सकते हैं। खाली स्ट्रिंग जोड़ने या असाइन करने पर AutoShape.isTextBox `false` लौटाता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

पहली दो कॉल्स `true` प्रिंट करती हैं; अंतिम दो `false` प्रिंट करती हैं।

## **टेक्स्ट फ्रेम का मालिक शैप खोजें**

सामान्य टेक्स्ट‑प्रोसेसिंग कोड को TextFrame मिल सकता है बिना यह जाने कि कौन सा प्रस्तुति ऑब्जेक्ट इसे धारण करता है। केवल पढ़ने योग्य TextFrame.getParentShape मेथड का उपयोग करके उसके मालिक Shape पर वापस जाया जा सकता है।

यदि टेक्स्ट फ्रेम ऑटो शैप या किसी अन्य टेक्स्ट‑वह शैप का हिस्सा है, तो TextFrame.getParentShape मालिक को वापस करता है और TextFrame.getParentCell `null` लौटाता है। उपयोग करने से पहले लौटाई गई मान की जाँच करें। शैप और टेबल‑सेल दोनों मालिकों की पहचान करने के लिए, जिसमें SmartArt नोड्स से जुड़े शैप शामिल हैं, [Search and Replace Text](/slides/hi/nodejs-java/search-and-replace-text/) देखें।

## **टेक्स्ट बॉक्स में कॉलम जोड़ना**

TextFrameFormat.setColumnCount मेथड टेक्स्ट फ्रेम को कॉलमों में विभाजित करता है, जबकि TextFrameFormat.setColumnSpacing कॉलमों के बीच का अंतर पॉइंट्स में सेट करता है। दोनों सेटिंग्स TextFrameFormat से संबंधित हैं और मौजूदा टेक्स्ट बॉक्स के टेक्स्ट फ्रेम के माध्यम से बदली जा सकती हैं। टेक्स्ट एक ही शैप के भीतर कॉलमों के बीच पुनः प्रवाहित होता है; यह दूसरे शैप में नहीं चलता।

निम्न उदाहरण 10 पॉइंट के कॉलम स्पेसिंग के साथ तीन‑कॉलम टेक्स्ट बॉक्स बनाता है, प्रस्तुति को सहेजता है, और आउटपुट फ़ाइल से संग्रहीत सेटिंग्स को वापस पढ़ता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **व्यक्तिगत कॉलम से टेक्स्ट निकालना**

TextFrame.splitTextByColumns का उपयोग करके मौजूदा टेक्स्ट फ्रेम में प्रत्येक दृश्य कॉलम में सौंपा गया टेक्स्ट प्राप्त किया जा सकता है। यह मेथड कॉलम‑आधारित पढ़ने के क्रम में प्रत्येक कॉलम के लिए एक स्ट्रिंग लौटाता है। एकल‑कॉलम टेक्स्ट फ्रेम एक तत्व वाले एरे बनाता है, और खाली कॉलम खाली स्ट्रिंग से दर्शाया जाता है। स्ट्रिंग्स में केवल साधारण टेक्स्ट होता है; भाग‑स्तर फ़ॉर्मेटिंग संरक्षित नहीं रहती।

यह उपयोगी है जब आपको चाहिए:
- कॉलम‑आधारित पढ़ने के क्रम को बरकरार रखते हुए टेक्स्ट निकालना।
- बहु‑कॉलम स्लाइड्स की सामग्री को अनुक्रमित या तुलना करना।
- प्रत्येक कॉलम को अलग फ़ाइल, डेटाबेस फ़ील्ड, या अन्य गंतव्य पर निर्यात करना।
- TextFrameFormat.setColumnCount, TextFrameFormat.setColumnSpacing, फ़ॉन्ट या टेक्स्ट‑फ़्रेम आकार बदलने के बाद टेक्स्ट किस प्रकार पुनः वितरित होता है, इसकी जाँच करना।

यह मेथड वर्तमान TextFrame के भीतर वितरित टेक्स्ट को रिपोर्ट करता है; यह अलग-अलग शैप या टेक्स्ट बॉक्स के बीच स्वतः टेक्स्ट प्रवाहित नहीं करता। कॉलम वितरण उपलब्ध फ़ॉन्ट्स और अन्य टेक्स्ट‑लेआउट सेटिंग्स पर निर्भर हो सकता है, इसलिए जब सुसंगत परिणाम आवश्यक हों तो आवश्यक फ़ॉन्ट्स उपलब्ध हों यह सुनिश्चित करें।

निम्न उदाहरण एक प्रस्तुति लोड करता है, टेक्स्ट फ्रेम वाले पहले बहु‑कॉलम ऑटो शैप को खोजता है, उसकी कॉन्फ़िगर की गई कॉलम संख्या पढ़ता है, और प्रत्येक कॉलम का टेक्स्ट अलग फ़ाइल में लिखता है। जो शैप टेक्स्ट फ्रेम प्रदान नहीं करते उन्हें छोड़ दिया जाता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट अपडेट करना**

प्रस्तुति में पूरे टेक्स्ट को अपडेट करने के लिए, स्लाइड्स और शैप्स पर इटरैट करें, ऑटो शैप्स चुनें, और फिर उनके टेक्स्ट भागों को संपादित करें। भाग‑स्तर पर कार्य करने से आप टेक्स्ट और कैरेक्टर फ़ॉर्मेटिंग दोनों बदल सकते हैं।

निम्न उदाहरण ऑटो‑शैप टेक्स्ट में प्रत्येक `years` को `months` से बदलता है और प्रत्येक प्रभावित भाग को बोल्ड बनाता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यह ट्रैवर्सल केवल ऑटो शैप्स में टेक्स्ट अपडेट करता है। तालिकाओं, चार्ट्स, SmartArt, या समूहित शैप्स में संग्रहीत टेक्स्ट को अपडेट करने के लिए उन ऑब्जेक्ट्स की अपनी कलेक्शन्स पर ट्रैवर्सल आवश्यक है।

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ना**

हाइपरलिंक को किसी विशेष टेक्स्ट भाग को सौंपा जा सकता है, जिससे केवल वह टेक्स्ट क्लिक करने योग्य लिंक बन जाता है। HyperlinkManager.setExternalHyperlinkClick का उपयोग करके भाग को बाहरी URL से जोड़ा जा सकता है।

निम्न उदाहरण लिंक वाला टेक्स्ट बनाता है और इसे प्रस्तुति में सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर या लेआउट स्लाइड पर टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक प्लेसहोल्डर अपनी स्थिति और फ़ॉर्मेटिंग को मैस्टर स्लाइड या लेआउट स्लाइड से विरासत में ले सकता है। एक सामान्य टेक्स्ट बॉक्स वह स्लाइड पर एक स्वतंत्र शैप है जहाँ इसे बनाया गया था और लेआउट परिवर्तन होने पर इसे प्लेसहोल्डर व्यवहार नहीं मिलता।

**चार्ट्स, टेबल्स या SmartArt में टेक्स्ट बदले बिना टेक्स्ट कैसे बदलूँ?**

ट्रैवर्सल को उन शैप्स तक सीमित रखें जो AutoShape के इंस्टेंस हैं, जैसा कि अपडेट टेक्स्ट उदाहरण में दिखाया गया है। चार्ट्स, टेबल्स और SmartArt अपना टेक्स्ट अपने स्वयं के ऑब्जेक्ट मॉडल में संग्रहीत करते हैं, इसलिए वह लूप उन्हें संशोधित नहीं करता।