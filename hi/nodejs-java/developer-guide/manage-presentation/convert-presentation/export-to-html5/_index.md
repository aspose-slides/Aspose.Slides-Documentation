---
title: JavaScript में प्रस्तुतियों को HTML5 में बदलें
linktitle: प्रेज़ेंटेशन से HTML5
type: docs
weight: 40
url: /hi/nodejs-java/export-to-html5/
keywords:
- PowerPoint से HTML5
- OpenDocument से HTML5
- प्रेज़ेंटेशन से HTML5
- स्लाइड से HTML5
- PPT से HTML5
- PPTX से HTML5
- ODP से HTML5
- PPT को HTML5 के रूप में सहेजें
- PPTX को HTML5 के रूप में सहेजें
- ODP को HTML5 के रूप में सहेजें
- PPT को HTML5 में निर्यात करें
- PPTX को HTML5 में निर्यात करें
- ODP को HTML5 में निर्यात करें
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides के साथ PowerPoint और OpenDocument प्रस्तुतियों को उत्तरदायी HTML5 में निर्यात करें। स्वरूपण, एनीमेेशन और अंतःक्रियात्मकता को संरक्षित रखें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में परिवर्तित करने के तरीके को समझाता है। यह वेब एक्सटेंशन या अतिरिक्त निर्भरताओं के बिना बुनियादी HTML5 निर्यात, साथ ही आकार एनीमेेशन और स्लाइड ट्रांज़िशन को नियंत्रित करने के विकल्पों को कवर करता है। लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया को भी दिखाता है, स्लाइड व्यू मोड में HTML5 आउटपुट बनाने की विधि समझाता है, और निर्यातित दस्तावेज़ में टिप्पणी को उनके लेआउट को कॉन्फ़िगर करके शामिल करने का प्रदर्शन करता है।

## **PowerPoint को HTML5 में निर्यात करें**

यह JavaScript कोड दिखाता है कि आप वेब एक्सटेंशन और निर्भरताओं के बिना प्रेज़ेंटेशन को HTML5 में कैसे निर्यात कर सकते हैं:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
इस मामले में, आपको साफ़ HTML मिलेगा। 
{{% /alert %}}

आप इस प्रकार आकार एनीमेेशन और स्लाइड ट्रांज़िशन के लिए सेटिंग्स निर्दिष्ट कर सकते हैं:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint को HTML में निर्यात करें**

यह JavaScript मानक PowerPoint‑to‑HTML प्रक्रिया को प्रदर्शित करता है:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

इस मामले में, प्रेज़ेंटेशन सामग्री SVG के माध्यम से इस रूप में रेंडर होती है:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="नोट" color="warning" %}} 
जब आप इस विधि से PowerPoint को HTML में निर्यात करते हैं, तो SVG रेंडरिंग के कारण आप स्टाइल लागू नहीं कर पाएंगे या विशिष्ट तत्वों को एनीमेट नहीं कर पाएंगे। 
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

**Aspose.Slides** आपको PowerPoint प्रेज़ेंटेशन को ऐसे HTML5 दस्तावेज़ में परिवर्तित करने की अनुमति देता है जिसमें स्लाइड्स स्लाइड व्यू मोड में प्रस्तुत की जाती हैं। इस मामले में, जब आप उत्पन्न HTML5 फ़ाइल को ब्राउज़र में खोलते हैं, तो आपको वेब पेज पर स्लाइड व्यू मोड में प्रेज़ेंटेशन दिखाई देता है।

यह JavaScript कोड PowerPoint‑to‑HTML5 स्लाइड व्यू निर्यात प्रक्रिया को प्रदर्शित करता है:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टिप्पणियों के साथ एक प्रेज़ेंटेशन को HTML5 दस्तावेज़ में परिवर्तित करें**

PowerPoint में टिप्पणियाँ एक उपकरण हैं जो उपयोगकर्ताओं को स्लाइड्स पर नोट्स या फ़ीडबैक छोड़ने की अनुमति देता है। ये सहयोगी परियोजनाओं में विशेष रूप से उपयोगी होती हैं, जहाँ कई लोग मुख्य सामग्री को बदले बिना विशिष्ट स्लाइड तत्वों पर अपने सुझाव या टिप्पणी जोड़ सकते हैं। प्रत्येक टिप्पणी लेखक का नाम दिखाती है, जिससे यह पता लगाना आसान हो जाता है कि टिप्पणी किसने छोड़ी।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल में निम्न PowerPoint प्रेज़ेंटेशन सहेजा गया है।

![प्रेज़ेंटेशन स्लाइड पर दो टिप्पणियाँ](two_comments_pptx.png)

जब आप PowerPoint प्रेज़ेंटेशन को HTML5 दस्तावेज़ में परिवर्तित करते हैं, तो आप आसानी से यह निर्धारित कर सकते हैं कि आउटपुट दस्तावेज़ में प्रेज़ेंटेशन की टिप्पणियों को शामिल किया जाए या नहीं। ऐसा करने के लिए आपको `notes_comments_layouting` प्रॉपर्टी में टिप्पणियों के प्रदर्शन पैरामीटर को [Html5Options](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/html5options/) क्लास में निर्दिष्ट करना होगा।

निचे दिया गया कोड उदाहरण प्रेज़ेंटेशन को एक HTML5 दस्तावेज़ में परिवर्तित करता है जिसमें टिप्पणियाँ स्लाइड्स के दाएँ ओर प्रदर्शित होती हैं।
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

"output.html" दस्तावेज़ नीचे की छवि में दिखाया गया है।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियंत्रित कर सकता हूँ कि ऑब्जेक्ट एनीमेेशन और स्लाइड ट्रांज़िशन HTML5 में चलेंगी या नहीं?**

हाँ, HTML5 में अलग विकल्प हैं जो आपको [shape animations](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/html5options/setanimateshapes/) और [slide transitions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/html5options/setanimatetransitions/) को सक्षम या अक्षम करने की अनुमति देते हैं।

**क्या टिप्पणियों का आउटपुट समर्थित है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**

हाँ, टिप्पणियों को HTML5 में जोड़ा जा सकता है और उन्हें स्लाइड के दाएँ जैसे स्थान पर [layout settings](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) के माध्यम से स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को स्किप कर सकता हूँ?**

हाँ, एक [setting](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) है जो आपको सहेजते समय JavaScript कॉल वाले हाइपरलिंक्स को स्किप करने की अनुमति देता है। यह कड़ी सुरक्षा नीतियों के अनुपालन में मदद करता है।