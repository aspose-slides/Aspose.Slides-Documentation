---
title: जावास्क्रिप्ट में प्रेजेंटेशन से उन्नत टेक्स्ट निष्कर्षण
linktitle: टेक्स्ट निकालें
type: docs
weight: 90
url: /hi/nodejs-java/extract-text-from-presentation/
keywords:
- टेक्स्ट निकालें
- स्लाइड से टेक्स्ट निकालें
- प्रेजेंटेशन से टेक्स्ट निकालें
- PowerPoint से टेक्स्ट निकालें
- OpenDocument से टेक्स्ट निकालें
- PPT से टेक्स्ट निकालें
- PPTX से टेक्स्ट निकालें
- ODP से टेक्स्ट निकालें
- टेक्स्ट प्राप्त करें
- स्लाइड से टेक्स्ट प्राप्त करें
- प्रेजेंटेशन से टेक्स्ट प्राप्त करें
- PowerPoint से टेक्स्ट प्राप्त करें
- OpenDocument से टेक्स्ट प्राप्त करें
- PPT से टेक्स्ट प्राप्त करें
- PPTX से टेक्स्ट प्राप्त करें
- ODP से टेक्स्ट प्राप्त करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रेजेंटेशनों से तेज़ी से टेक्स्ट निकालें। समय बचाने के लिए हमारा सरल, चरण-दर-चरण मार्गदर्शक अपनाएँ।"
---
## **अवलोकन**

प्रेजेंटेशन से टेक्स्ट निकालना स्लाइड कंटेंट के साथ काम करने वाले डेवलपर्स के लिए आम और आवश्यक कार्य है। चाहे आप Microsoft PowerPoint फ़ाइलों (PPT या PPTX फ़ॉर्मेट) के साथ काम कर रहे हों, या OpenDocument प्रेजेंटेशन (ODP) के, टेक्स्ट डेटा तक पहुँच और उसे प्राप्त करना विश्लेषण, ऑटोमेशन, इंडेक्सिंग या कंटेंट माइग्रेशन के उद्देश्य से महत्वपूर्ण हो सकता है।

यह लेख विभिन्न प्रेजेंटेशन फ़ॉर्मेट्स—PPT, PPTX, और ODP—से प्रभावी ढंग से टेक्स्ट निकालने के लिए Aspose.Slides for Node.js via Java का उपयोग करने पर व्यापक गाइड प्रदान करता है। आप सीखेंगे कि प्रेजेंटेशन तत्वों को व्यवस्थित रूप से कैसे इटररेट करें ताकि आवश्यक टेक्स्ट कंटेंट को सटीक रूप से प्राप्त किया जा सके।

## **स्लाइड से टेक्स्ट निकालें**

Aspose.Slides for Node.js via Java, [SlideUtil](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideutil/) क्लास प्रदान करता है। यह क्लास प्रेजेंटेशन या स्लाइड से सभी टेक्स्ट निकालने के लिए कई ओवरलोडेड स्टैटिक मेथड्स उजागर करता है। प्रेजेंटेशन की किसी स्लाइड से टेक्स्ट निकालने के लिए, [getAllTextBoxes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) मेथड का उपयोग करें। यह मेथड एक स्लाइड ऑब्जेक्ट को पैरामीटर के रूप में लेता है। चलाने पर, मेथड पूरे स्लाइड को टेक्स्ट के लिए स्कैन करता है और [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) ऑब्जेक्ट्स की एक एरे लौटाता है, जिसमें सभी टेक्स्ट फ़ॉर्मेटिंग संरक्षित रहती है।

निम्नलिखित कोड स्निपेट प्रेजेंटेशन की पहली स्लाइड से सभी टेक्स्ट निकालता है:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **प्रेजेंटेशन से टेक्स्ट निकालें**

पूरे प्रेजेंटेशन से टेक्स्ट स्कैन करने के लिए, [SlideUtil](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideutil/) क्लास द्वारा प्रदान किया गया [getAllTextFrames](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) स्टैटिक मेथड उपयोग करें। यह दो पैरामीटर स्वीकार करता है:

1. पहला, एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) ऑब्जेक्ट जो PowerPoint या OpenDocument प्रेजेंटेशन को दर्शाता है जिससे टेक्स्ट निकाला जाएगा।
2. दूसरा, एक `boolean` मान जो यह दर्शाता है कि टेक्स्ट स्कैन करते समय मास्टर स्लाइड्स को शामिल किया जाना चाहिए या नहीं।

यह मेथड [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) ऑब्जेक्ट्स की एरे लौटाता है, जिसमें टेक्स्ट फ़ॉर्मेटिंग जानकारी भी शामिल होती है। नीचे दिया गया कोड प्रेजेंटेशन (मास्टर स्लाइड्स सहित) से टेक्स्ट और फ़ॉर्मेटिंग विवरण स्कैन करता है।

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **वर्गीकृत और तेज़ टेक्स्ट एक्सट्रैक्शन**

[PresentationFactory](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/) क्लास भी प्रेजेंटेशन से सभी टेक्स्ट निकालने के लिए मेथड्स प्रदान करता है:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textextractionarrangingmode/) एन्‍युम आर्ग्यूमेंट टेक्स्ट एक्सट्रैक्शन परिणाम को व्यवस्थित करने के मोड को दर्शाता है और इसे निम्न मानों में से सेट किया जा सकता है:
- `Unarranged` - स्लाइड पर उसकी स्थिति को ध्यान में रखे बिना कच्चा टेक्स्ट।
- `Arranged` - टेक्स्ट स्लाइड पर जैसी क्रम में है, उसी क्रम में व्यवस्थित।

जब गति महत्वपूर्ण हो तो अनएरेन्ज्ड मोड का प्रयोग किया जा सकता है; यह एरेन्ज्ड मोड से तेज़ होता है।

[PresentationText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationtext/) प्रेजेंटेशन से निकाले गए कच्चे टेक्स्ट को दर्शाता है। इसका `getSlidesText` मेथड ऑब्जेक्ट्स की एरे देता है, जहाँ प्रत्येक ऑब्जेक्ट संबंधित स्लाइड के टेक्स्ट को प्रतिनिधित्व करता है। प्रत्येक स्लाइड टेक्स्ट ऑब्जेक्ट में निम्न मेथड्स होते हैं:

- `getText` मेथड स्लाइड की शैलियों के भीतर का टेक्स्ट लौटाता है।
- `getMasterText` मेथड उस स्लाइड से जुड़े मास्टर स्लाइड की शैलियों के भीतर का टेक्स्ट लौटाता है।
- `getLayoutText` मेथड उस स्लाइड से जुड़े लेआउट स्लाइड की शैलियों के भीतर का टेक्स्ट लौटाता है।
- `getNotesText` मेथड उस स्लाइड से जुड़े नोट्स स्लाइड की शैलियों के भीतर का टेक्स्ट लौटाता है।
- `getCommentsText` मेथड उस स्लाइड से जुड़े कमेंट्स के भीतर का टेक्स्ट लौटाता है।

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **FAQ**

**Aspose.Slides बड़े प्रेजेंटेशन से टेक्स्ट एक्सट्रैक्शन के दौरान कितनी तेज़ी से प्रोसेस करता है?**

Aspose.Slides उच्च प्रदर्शन के लिए अनुकूलित है और यहाँ तक कि [बड़े प्रेजेंटेशन](/slides/hi/nodejs-java/open-presentation/) को भी प्रोसेस कर सकता है, जिससे यह रीयल‑टाइम या बल्क प्रोसेसिंग परिदृश्यों के लिए उपयुक्त बनता है।

**क्या Aspose.Slides प्रेजेंटेशन के भीतर टेबल्स और चार्ट्स से भी टेक्स्ट निकाल सकता है?**

हां। Aspose.Slides कई स्लाइड तत्वों, जिसमें टेबल्स और चार्ट‑संबंधित ऑब्जेक्ट्स शामिल हैं, से टेक्स्ट निकाल सकता है, ताकि आप सामान्य प्रेजेंटेशन संरचनाओं में टेक्स्टुअल कंटेंट तक पहुँच और विश्लेषण कर सकें।

**क्या प्रेजेंटेशन से टेक्स्ट निकालने के लिए मुझे Aspose.Slides का विशेष लाइसेंस चाहिए?**

आप Aspose.Slides का फ्री ट्रायल संस्करण उपयोग करके टेक्स्ट निकाल सकते हैं, हालांकि इसमें [कुछ सीमाएँ](/slides/hi/nodejs-java/licensing/) होंगी, जैसे कि केवल सीमित संख्या में स्लाइड्स प्रोसेस करना। अनलिमिटेड उपयोग और बड़े प्रेजेंटेशन को संभालने के लिए पूर्ण लाइसेंस खरीदने की सलाह दी जाती है।