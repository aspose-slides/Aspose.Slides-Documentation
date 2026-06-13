---
title: Node.js में PowerPoint प्रस्तुतियों को HTML में बदलें
linktitle: PowerPoint से HTML
type: docs
weight: 30
url: /hi/nodejs-java/convert-powerpoint-to-html/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से HTML
- प्रस्तुति से HTML
- स्लाइड से HTML
- PPT से HTML
- PPTX से HTML
- PowerPoint को HTML के रूप में सहेजें
- प्रस्तुति को HTML के रूप में सहेजें
- स्लाइड को HTML के रूप में सहेजें
- PPT को HTML के रूप में सहेजें
- PPTX को HTML के रूप में सहेजें
- PPT को HTML में निर्यात करें
- PPTX को HTML में निर्यात करें
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js में PowerPoint प्रस्तुतियों को HTML में बदलें। PPT और PPTX फ़ाइलें, चयनित स्लाइड्स, नोट्स, फ़ॉन्ट, छवियाँ, SVG और मीडिया को निर्यात करने के लिये Java के माध्यम से Node.js के लिये Aspose.Slides का उपयोग करें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java Microsoft PowerPoint के बिना PowerPoint प्रस्तुतियों को HTML के रूप में सहेज सकता है। मूल रूपांतरण एक ही [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) लोड और `save` कॉल है जिसमें [SaveFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) का उपयोग किया जाता है। जब आपको निर्यातित लेआउट, फ़ॉन्ट, छवियाँ, नोट्स, टिप्पणी, SVG आउटपुट, या लिंक्ड संसाधनों को नियंत्रित करने की आवश्यकता हो तो [HtmlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmloptions/) का उपयोग करें।

यह मार्गदर्शिका व्यावहारिक HTML निर्यात परिदृश्यों पर केंद्रित है:

- पूरी प्रस्तुति या चयनित स्लाइड्स को निर्यात करें।
- फिक्स्ड‑लेआउट, रेस्पॉन्सिव, या SVG‑आधारित HTML बनाएं।
- स्पीकर नोट्स और टिप्पणियों को शामिल करें।
- छवि गुणवत्ता और क्रॉपेड छवि डेटा को नियंत्रित करें।
- फ़ॉन्ट एम्बेड करें या फ़ॉन्ट फ़ाइलों को अलग से सहेजें।
- बाहरी संसाधनों और मीडिया फ़ाइलों को कैसे लिखा और संदर्भित किया जाए चुनें।

डिफ़ॉल्ट रूप से, HTML निर्यात अधिकांश संसाधनों को एम्बेड करने वाला एक स्व-संलग्न HTML दस्तावेज़ बनाता है। यह एक फ़ाइल साझा करने के लिए सुविधाजनक है, लेकिन आउटपुट आकार बढ़ा सकता है। वेब प्रकाशन के लिये बाहरी संसाधनों, कम DPI वाली छवियों, और केवल उन फ़ॉन्टों को एम्बेड करने पर विचार करें जो लक्ष्य पर्यावरण में विश्वसनीय रूप से उपलब्ध नहीं हैं।

## **प्रस्तुति को HTML में परिवर्तित करें**

प्रस्तुति को HTML में निर्यात करने के लिये, इसे [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) से लोड करें और [SaveFormat.Html](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveformat/) से सहेजें।

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

यह उदाहरण एक HTML फ़ाइल लिखता है। प्रस्तुति ऑब्जेक्ट को `finally` ब्लॉक में डिस्पोज़ किया जाता है, जो निर्यात के बाद फ़ाइल हैंडल और रेंडरिंग संसाधनों को मुक्त करता है।

## **HtmlOptions का उपयोग करें**

[HtmlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmloptions/) HTML निर्यात के लिये मुख्य कॉन्फ़िगरेशन क्लास है। सामान्य सेटिंग्स में शामिल हैं:

- `SlidesLayoutOptions`: नोट्स, टिप्पणियाँ, हैंडआउट्स, या अन्य लेआउट जानकारी जोड़ता है।
- `HtmlFormatter`: HTML दस्तावेज़ संरचना बदलता है या फ़ॉर्मेटिंग को कंट्रोलर को सौंपता है।
- `SlideImageFormat`: स्लाइडों को दर्शाने का तरीका बदलता है, उदाहरण के लिये SVG के रूप में।
- `PicturesCompression`: छवि DPI और आउटपुट आकार को नियंत्रित करता है।
- `DeletePicturesCroppedAreas`: क्रॉप्ड छवि डेटा को रखता या हटाता है।
- `SvgResponsiveLayout`: निर्यातित SVG सामग्री को उसके कंटेनर के अनुसार अनुकूल बनाता है।
- `ShowHiddenSlides`: आवश्यक होने पर छुपी स्लाइड्स को शामिल करता है।

नीचे के अनुभाग सबसे सामान्य विकल्पों को अलग‑अलग दिखाते हैं ताकि आप केवल अपनी कार्यप्रवाह के अनुसार आवश्यक विकल्पों को संयोजित कर सकें।

## **चयनित स्लाइड्स को HTML में परिवर्तित करें**

स्लाइड नंबर स्वीकार करने वाला `Presentation.save` ओवरलोड 1‑आधारित स्लाइड स्थितियों का उपयोग करता है। नीचे का लूप प्रत्येक स्लाइड को अलग HTML फ़ाइल में सहेजता है।

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

जब वेबसाइट या एप्लिकेशन को प्रत्येक स्लाइड के लिये एक HTML पृष्ठ चाहिए तब इस पैटर्न का उपयोग करें। यदि प्रत्येक स्लाइड को समान लेआउट चाहिए, तो एक [HtmlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmloptions/) इंस्टेंस बनाएँ और प्रत्येक `save` कॉल में पास करें।

## **रेस्पॉन्सिव HTML बनाएं**

[ResponsiveHtmlController](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmlformatter/) के माध्यम से रेस्पॉन्सिव HTML आउटपुट प्रदान करता है। जब निर्यातित पृष्ठ को ब्राउज़र की चौड़ाई के अनुसार बेहतर अनुकूल बनाना हो तो इसका उपयोग करें।

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

SVG‑आधारित रेस्पॉन्सिव लेआउट के लिये, [HtmlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmloptions/) पर `SvgResponsiveLayout` सेट करें। यह उपयोगी है जब स्लाइड सामग्री को स्केलेबल SVG मार्कअप के रूप में निर्यात किया जाता है।

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **स्पीकर नोट्स और टिप्पणियों को शामिल करें**

स्पीकर नोट्स या टिप्पणियों को शामिल करने के लिये `HtmlOptions.setSlidesLayoutOptions` के माध्यम से [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) का उपयोग करें। नोट्स और टिप्पणियाँ डिफ़ॉल्ट रूप से छिपी होती हैं जब तक आप उनकी स्थितियाँ नहीं चुनते।

मान लीजिए स्रोत प्रस्तुति में स्पीकर नोट्स हैं:

![PowerPoint में स्पीकर नोट्स वाली स्लाइड](slide_with_notes.png)

निम्न कोड स्लाइड सामग्री को स्लाइड के नीचे स्पीकर नोट्स के साथ निर्यात करता है।

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

निर्यातित HTML में नोट्स क्षेत्र शामिल होता है:

![स्लाइड और स्पीकर नोट्स के साथ HTML आउटपुट](HTML_with_notes.png)

टिप्पणियों को निर्यात करने के लिये `CommentsPosition` सेट करें, उदाहरण के लिये `CommentsPositions.Right` या `CommentsPositions.Bottom`। यदि आपको केवल टिप्पणियाँ चाहिए तो `NotesPosition` को छोड़ दें। यदि आपको दोनों नोट्स और टिप्पणियाँ चाहिए, तो दोनों गुण सेट करें।

## **छवि गुणवत्ता और क्रॉपेड क्षेत्रों को नियंत्रित करें**

HTML निर्यात स्लाइड छवियों को संपीड़ित करके आउटपुट आकार कम कर सकता है। जब आपको उच्च छवि गुणवत्ता चाहिए तो [PicturesCompression](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/picturescompression/) से मान सेट करें।

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

डिफ़ॉल्ट रूप से, छवियों के क्रॉपेड क्षेत्रों को निर्यातित आउटपुट से हटा दिया जा सकता है। केवल तब क्रॉपेड डेटा रखें जब उपयोगकर्ताओं को उन छिपे हुए भागों को पुनः प्राप्त या निरीक्षण करने की आवश्यकता हो। इसे रखने से HTML आकार बढ़ सकता है।

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **CSS जोड़ें**

सरल स्टाइलिंग के लिये, `HtmlFormatter.createDocumentFormatter` में CSS स्ट्रिंग पास करें। यह Aspose.Slides द्वारा स्लाइड सामग्री को रेंडर रखे हुए आसपास के HTML दस्तावेज़ को बदलता है।

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

कस्टम दस्तावेज़ हेडर, लिंक्ड CSS फ़ाइल, या स्लाइड्स और शैप्स के आसपास कस्टम मार्कअप के लिये, एक फ़ॉर्मेटिंग कंट्रोलर के साथ [HtmlFormatter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmlformatter/) का उपयोग करें।

## **फ़ॉन्ट एम्बेड करें**

यदि लक्ष्य पर्यावरण में प्रस्तुति फ़ॉन्ट स्थापित नहीं हो सकते हैं, तो [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) के साथ HTML में फ़ॉन्ट एम्बेड करें। एम्बेडिंग दृश्य सटीकता को सुधारता है लेकिन आउटपुट आकार बढ़ाता है।

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

केवल तब फॉन्ट हटाएँ जब आपको भरोसा हो कि लक्ष्य ब्राउज़र या सिस्टम पहले से ही उन्हें उपलब्ध कराते हैं। ब्रांड फ़ॉन्ट या कम सामान्य फ़ॉन्ट के लिये एम्बेडिंग आम तौर पर सुरक्षित रहता है।

## **फ़ॉन्ट फ़ाइलों को लिंक करें बजाय एम्बेड करने के**

HTML फ़ाइल के आकार को कम करने के लिये आप फ़ॉन्ट डेटा को अलग‑अलग WOFF फ़ाइलों में लिख सकते हैं और HTML में `@font-face` नियम जोड़ सकते हैं। Node.js via Java में यह परिदृश्य आमतौर पर एक छोटे Java हेल्पर क्लास के साथ लागू किया जाता है जो [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) को विस्तारित करता है, फ़ॉन्ट बाइट्स को आउटपुट निर्देशिका में लिखता है, और उत्पन्न HTML में `@font-face` नियम डालता है। उस हेल्पर को कंपाइल करें, इसे Node.js मॉड्यूल क्लासपाथ में जोड़ें, और फिर JavaScript से `java.newInstanceSync` से इंस्टैंशिएट करें।

जब आप ऐसा हेल्पर बनाते हैं, तो दो पथ इरादा‑पूर्वक चुनें:

- फ़ाइल प्रणाली आउटपुट पथ, जहाँ उत्पन्न फ़ॉन्ट फ़ाइलें लिखी जाती हैं।
- URL पथ, जो ब्राउज़र HTML दस्तावेज़ से उन फ़ॉन्ट फ़ाइलों को लोड करने के लिये उपयोग करता है।

## **संसाधनों को बाहरी रूप से सहेजें**

स्व‑संलग्न HTML को ले जाना आसान है, पर एम्बेडेड Base64 संसाधन फ़ाइल को बड़ा बना सकते हैं। यदि आपके एप्लिकेशन को बाहरी इमेज, फ़ॉन्ट, ऑडियो या वीडियो फ़ाइलों की आवश्यकता है, तो एक निर्यात कंट्रोलर का उपयोग करें जो संसाधनों को चुनी गई निर्देशिका में लिखता है और ब्राउज़र‑दृश्यमान URL उत्पन्न करता है। फ़ाइल‑सिस्टम पथ और URL पथ को अपने परिनियोजन लेआउट के अनुसार संरेखित रखें।

## **मीडिया फ़ाइलें निर्यात करें**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) वीडियो और ऑडियो फ़ाइलें निर्यात करता है और ऐसा HTML लिखता है जिसे ब्राउज़र में चलाया जा सकता है। इसका कंस्ट्रक्टर निम्न लेता है:

- `path`: वह निर्देशिका जहाँ उत्पन्न मीडिया फ़ाइलें लिखी जाएँगी।
- `fileName`: निर्मित HTML फ़ाइल का नाम।
- `baseUri`: HTML लिंक में मीडिया फ़ाइलों के लिये प्रयुक्त पूर्ण URI प्रीफ़िक्स।

यदि HTML फ़ाइल `html-output/presentation.html` है और मीडिया फ़ाइलें `html-output/media` में सहेजी गई हैं, तो `path` को डिस्क पर मीडिया निर्देशिका की ओर इंगित करना चाहिए, जबकि `baseUri` को ब्राउज़र के दृष्टिकोण से उसी निर्देशिका की ओर। स्थानीय पूर्वावलोकन के लिये आप मीडिया निर्देशिका से `file:///` URI बना सकते हैं। परिनियोजित एप्लिकेशन के लिये प्रकाशित मीडिया निर्देशिका का पूर्ण URL उपयोग करें।

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

प्रत्येक निर्यात कार्य के लिये अद्वितीय आउटपुट निर्देशिकाओं का उपयोग करें, विशेष रूप से सर्वर एप्लिकेशन में। साझा आउटपुट पथ विभिन्न रूपांतरणों की फ़ाइलों को ओवरराइट कर सकते हैं।

## **प्रदर्शन और संसाधन प्रबंधन**

HTML रूपांतरण एक रेंडरिंग ऑपरेशन है, इसलिए प्रसंस्करण समय और मेमोरी उपयोग स्लाइड संख्या, छवि रिज़ॉल्यूशन, फ़ॉन्ट, इफ़ेक्ट, चार्ट और एम्बेडेड मीडिया पर निर्भर करता है। उच्च `PicturesCompression` DPI मान, एम्बेडेड फ़ॉन्ट, SVG आउटपुट, और रखी गई क्रॉप्ड छवि क्षेत्रों से सटीकता बढ़ सकती है लेकिन सामान्यतः आउटपुट आकार बढ़ता है।

बैच रूपांतरण के लिये:

- प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस को तुरंत डिस्पोज़ करें।
- अलग कार्यों के लिये अलग आउटपुट निर्देशिकाएँ उपयोग करें।
- सामान्य फ़ॉन्ट को एम्बेड करने से बचें जब तक सटीकता की आवश्यकता न हो।
- जब HTML प्रीव्यू या थंबनेल के लिये हो तो छवि DPI कम करें।
- स्रोत प्रस्तुति, निर्मित HTML, और बाहरी संसाधनों को तब तक साथ रखें जब तक परिनियोजन पथ अंतिम न हो जाएँ।

## **FAQ**

**क्या HTML आउटपुट में हाइपरलिंक्स संरक्षित रहते हैं?**

हाँ। प्रस्तुति के हाइपरलिंक्स HTML में निर्यात होते हैं और लक्ष्य URL वैध होने पर क्लिक करने योग्य रहते हैं।

**क्या मैं प्रस्तुतियों को समानांतर रूप से HTML में परिवर्तित कर सकता हूँ?**

हाँ, लेकिन एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस को वर्करों के बीच साझा न करें। विभिन्न फ़ाइलों को अलग‑अलग प्रस्तुति इंस्टेंस, अलग स्ट्रीम, और अलग आउटपुट निर्देशिकाओं के साथ प्रोसेस करें। विवरण के लिये [multithreading guidance](/slides/hi/nodejs-java/multithreading/) देखें।

**क्या Presentation ऑब्जेक्ट थ्रेड‑सुरक्षित है?**

नहीं। एकल [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस को एक ही वर्कर में लोड, संशोधित, सहेजें और डिस्पोज़ किया जाना चाहिए। समानांतर कार्य के लिये प्रत्येक वर्कर या प्रोसेस के लिये स्वतंत्र इंस्टेंस बनाएं।

**जेनरेटेड HTML फ़ाइल बड़ी क्यों होती है?**

डिफ़ॉल्ट निर्यात संसाधनों को सीधे HTML में एम्बेड करता है। एम्बेडेड फ़ॉन्ट, उच्च‑DPI छवियाँ, मीडिया, SVG कंटेंट, और रखी गई क्रॉप्ड छवि क्षेत्रों से आकार बढ़ता है। छोटे आउटपुट को अधिकतम सटीकता से अधिक प्राथमिकता देने पर बाहरी संसाधन, सामान्य फ़ॉन्ट को एम्बेड न करने और `PicturesCompression` को कम करने का उपयोग करें।

**PowerPoint में 24 pt जैसे फ़ॉन्ट साइज को HTML में 17.999819 pt क्यों दिखाया जाता है?**

यह इसलिए होता है क्योंकि PowerPoint और HTML अलग‑अलग DPI मॉडल का उपयोग करते हैं। PowerPoint टेक्स्ट साइज 72 DPI के टाइपोग्राफिक पॉइंट में स्टोर करता है, जबकि HTML लेआउट CSS पिक्सेल पर आधारित 96 DPI मॉडल पर रहता है। Aspose.Slides जब प्रस्तुति को HTML में निर्यात करता है, तो फ़ॉन्ट साइज इन दो प्रणालीयों के बीच अनुवादित किया जाता है, और यह छोटा राउंडिंग अंतर पैदा कर सकता है।

ये मान वास्तविक दृश्य फ़ॉन्ट‑साइज़ परिवर्तन नहीं दर्शाते। यह केवल PowerPoint और HTML के बीच टेक्स्ट मेट्रिक्स के रूपांतरण का गणितीय पक्ष प्रभाव है।

**मीडिया निर्यात के लिये baseUri कैसे चुनना चाहिए?**

`baseUri` को ब्राउज़र के दृष्टिकोण से चुनें और इसे पूर्ण URI के रूप में पास करें। स्थानीय प्रीव्यू के लिये आप आउटपुट डायरेक्टरी से `file:///` URI बना सकते हैं। परिनियोजन के लिये प्रकाशित मीडिया डायरेक्टरी का पूर्ण URL उपयोग करें। फ़ाइल‑सिस्टम `path` और ब्राउज़र `baseUri` को समान स्ट्रिंग होना जरूरी नहीं, पर दोनों को एक ही संसाधन स्थान का वर्णन करना चाहिए।

**क्या मैं छुपी स्लाइड्स को शामिल कर सकता हूँ?**

हाँ। जब छुपी स्लाइड्स को निर्यात करना आवश्यक हो, तो [HtmlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmloptions/) पर `ShowHiddenSlides` को `true` सेट करें।