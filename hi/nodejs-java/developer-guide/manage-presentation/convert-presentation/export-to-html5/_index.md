---
title: प्रेज़ेंटेशन को JavaScript में HTML5 में बदलें
linktitle: प्रेज़ेंटेशन को HTML5 में
type: docs
weight: 40
url: /hi/nodejs-java/export-to-html5/
keywords:
- PowerPoint को HTML5 में
- OpenDocument को HTML5 में
- प्रस्तुति को HTML5 में
- स्लाइड को HTML5 में
- PPT को HTML5 में
- PPTX को HTML5 में
- ODP को HTML5 में
- PPT को HTML5 के रूप में सहेजें
- PPTX को HTML5 के रूप में सहेजें
- ODP को HTML5 के रूप में सहेजें
- PPT को HTML5 में निर्यात करें
- PPTX को HTML5 में निर्यात करें
- ODP को HTML5 में निर्यात करें
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ PowerPoint और OpenDocument प्रस्तुतियों को प्रतिक्रियाशील HTML5 में निर्यात करें। स्वरूपण, एनीमेशन और इंटरैक्टिविटी को संरक्षित रखें।"
---
## **समीक्षा**

यह लेख बताता है कि Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में कैसे बदलें। यह बुनियादी निर्यात, आकार एनीमेशन और स्लाइड ट्रांज़िशन नियंत्रण, तथा टिप्पणी लेआउट को कवर करता है। यह मानक HTML निर्यात के SVG-आधारित आउटपुट की तुलना HTML5 आउटपुट से भी करता है।

## **PowerPoint को HTML5 में निर्यात करें**

निम्न उदाहरण कार्य निर्देशिका से एक प्रस्तुति लोड करता है और उसे HTML5 प्रारूप में सहेजता है। यह डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करता है; अगला उदाहरण स्पष्ट रूप से एनीमेशन प्लेबैक को नियंत्रित करने का तरीका दिखाता है। इनपुट पथ को अपने प्रस्तुतीकरण के पथ से बदलें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="नोट" %}}
HTML दस्तावेज़ के अतिरिक्त, निर्यात स्लाइड स्टाइलिंग, एनीमेशन, इफ़ेक्ट और नेविगेशन के लिए सहायक CSS और JavaScript फ़ाइलें लिखता है। आउटपुट को स्थानांतरित या प्रकाशित करते समय इन फाइलों को HTML दस्तावेज़ के साथ रखें। उत्पन्न पृष्ठ सार्वजनिक CDN से jQuery और Anime.js भी लोड करता है; इनके बिना स्लाइड नेविगेशन और एनीमेशन काम नहीं करेंगे।
{{% /alert %}}

शेप एनीमेशन या स्लाइड ट्रांज़िशन चलाए बिना निर्यात करने के लिए, [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) और [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) को `false` पास करें, जो [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) में हैं। ये सेटिंग्स स्वतंत्र हैं, इसलिए आप एक को सक्रिय और दूसरे को निष्क्रिय कर सकते हैं। उदाहरण जनित पृष्ठ में दोनों प्रकार के एनीमेशन को निष्क्रिय करके प्रस्तुति निर्यात करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **PowerPoint को HTML में निर्यात करें**

मानक HTML निर्यात एक अलग रेंडरिंग दृष्टिकोण का उपयोग करता है: स्लाइड सामग्री को HTML पृष्ठ के अंदर SVG द्वारा प्रस्तुत किया जाता है। निम्न उदाहरण इस रेंडरिंग दृष्टिकोण का उपयोग करके प्रस्तुति को HTML दस्तावेज़ में परिवर्तित करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

नीचे दिया गया सरलित मार्कअप उत्पन्न पृष्ठ की संरचना को दर्शाता है। SVG तत्व में रेंडर की गई स्लाइड सामग्री होती है; प्लेसहोल्डर टेक्स्ट उस सामग्री का प्रतिनिधित्व करता है और यह वास्तविक निर्यात आउटपुट नहीं है।

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="चेतावनी" color="warning" %}}
SVG-आधारित निर्यात PowerPoint आकारों को व्यक्तिगत HTML तत्वों के रूप में उजागर नहीं करता है। इस लेख में दर्शाए गए आकार-एनीमेशन और स्लाइड-ट्रांज़िशन विकल्पों की आवश्यकता होने पर HTML5 निर्यात का उपयोग करें।
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

HTML5 निर्यात एक पृष्ठ उत्पन्न करता है जिससे प्रस्तुति स्लाइड्स को ब्राउज़र में देख और नेविगेट किया जा सके। यह उदाहरण दोनों [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) और [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) को सक्षम करता है ताकि निर्यातित स्लाइड व्यू स्रोत प्रस्तुति के प्रभावों को चला सके।

ऐसी प्रस्तुति उपयोग करें जिसमें पहले से ही आकार एनीमेशन और स्लाइड ट्रांज़िशन हों, ताकि इन सेटिंग्स का प्रभाव देखा जा सके। इन्हें सक्षम करने से उन स्लाइड्स में नए प्रभाव नहीं जोड़ते जिनमें पहले से कोई प्रभाव नहीं है। निर्यात के बाद, उत्पन्न HTML5 दस्तावेज़ को उसके सहायक फ़ाइलों के साथ उपलब्ध ब्राउज़र में खोलें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **टिप्पणी सहित एक प्रस्तुति को HTML5 दस्तावेज़ में बदलें**

आप मौजूदा स्लाइड टिप्पणी को HTML5 आउटपुट में शामिल कर सकते हैं ताकि पाठक स्लाइड सामग्री के साथ प्रतिक्रिया देख सकें। इस अनुभाग में उदाहरण स्रोत प्रस्तुति में टिप्पणी होने की अपेक्षा करता है, जैसा कि नीचे दर्शाया गया है। यह उन टिप्पणियों को निर्यात करता है; नई टिप्पणी नहीं बनाता।

![प्रस्तुति स्लाइड पर दो टिप्पणियां](two_comments_pptx.png)

एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) ऑब्जेक्ट को [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) की [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) मेथड में पास करें। प्रत्येक स्लाइड के दाईं ओर टिप्पणी रखने के लिए [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) enumeration से `Right` चुनने हेतु [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) का उपयोग करें।

निम्न उदाहरण इस टिप्पणी लेआउट के साथ प्रस्तुति को HTML5 में निर्यात करता है। टिप्पणी रहित प्रस्तुति में प्रदर्शित करने के लिये कोई टिप्पणी पाठ नहीं होगा।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियां](two_comments_html5.png)

## **निर्यात के दौरान JavaScript हाइपरलिंक्स को बाहर रखें**

मान लीजिए `hyperlinks.pptx` में `javascript:alert('Hello')` लक्ष्य वाला लिंक्ड टेक्स्ट और सामान्य `https://example.com/` लिंक है। निर्यात के दौरान JavaScript हाइपरलिंक को बाहर करने के लिए, [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) को `true` पास करें। डिफ़ॉल्ट रूप से यह `false` है, इसलिए इन लिंक्स को फिल्टर नहीं किया जाता जब तक आप विकल्प को सक्रिय नहीं करते।

निम्न उदाहरण कार्य निर्देशिका से प्रस्तुति लोड करता है और इसे [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) का उपयोग करके निर्यात करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

निर्यातित फ़ाइल JavaScript हाइपरलिंक को हटाती है जबकि उसका टेक्स्ट और सामान्य HTTPS लिंक बरकरार रखती है। स्रोत प्रस्तुति अपरिवर्तित रहती है।

यह विकल्प JavaScript हाइपरलिंक्स को फ़िल्टर करता है; यह सभी स्क्रिप्ट्स या अन्य सक्रिय सामग्री को नहीं हटाता, न ही CSP अनुपालन की गारंटी देता है। उदाहरण के लिए, HTML5 आउटपुट में अभी भी स्लाइड नेविगेशन और एनीमेशन के लिए स्क्रिप्ट्स शामिल हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियंत्रित कर सकता हूँ कि ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन HTML5 में चलें?**  
हाँ, HTML5 निर्यात अलग-अलग विकल्प प्रदान करता है जिससे आप [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) और [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) को सक्षम या अक्षम कर सकते हैं।

**क्या टिप्पणियां समर्थित हैं, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**  
हाँ, मौजूदा टिप्पणियों को HTML5 आउटपुट में शामिल किया जा सकता है और नोट्स तथा टिप्पणियों के लिए [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) के माध्यम से (उदाहरण के लिए, स्लाइड के दाएँ) स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को छोड़ सकता हूँ?**  
हाँ, [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) सेटिंग आपको सहेजते समय JavaScript कॉल वाले हाइपरलिंक्स को छोड़ने की अनुमति देती है। डिफ़ॉल्ट रूप से यह `false` है। HTML5 निर्यात उदाहरण और फ़िल्टर के दायरे के लिए [Exclude JavaScript Hyperlinks During Export](/slides/hi/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) देखें। यह सेटिंग HTML5 व्यूअर द्वारा नेविगेशन और एनीमेशन के लिए उपयोग किए जाने वाले JavaScript को नहीं हटाती।