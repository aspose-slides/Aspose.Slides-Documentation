---
title: Android पर प्रस्तुतियों को HTML5 में बदलें
linktitle: प्रस्तुति को HTML5 में
type: docs
weight: 40
url: /hi/androidjava/export-to-html5/
keywords:
- PowerPoint को HTML5 में
- OpenDocument को HTML5 में
- प्रस्तुति को HTML5 में
- स्लाइड को HTML5 में
- PPT को HTML5 में
- PPTX को HTML5 में
- ODP को HTML5 में
- PPT को HTML5 रूप में सहेजें
- PPTX को HTML5 रूप में सहेजें
- ODP को HTML5 रूप में सहेजें
- PPT को HTML5 में निर्यात करें
- PPTX को HTML5 में निर्यात करें
- ODP को HTML5 में निर्यात करें
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों को प्रतिक्रियाशील HTML5 में निर्यात करें। स्वरूप, एनीमेशन, और इंटरैक्टिविटी को संरक्षित रखें।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में कैसे बदलें, यह समझाता है। यह वेब एक्स्टेंशन या अतिरिक्त निर्भरताओं के बिना बेसिक HTML5 निर्यात, तथा आकार एनिमेशन और स्लाइड ट्रांज़िशन को नियंत्रित करने के विकल्प को कवर करता है। लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया को भी दिखाता है, स्लाइड व्यू मोड में HTML5 आउटपुट उत्पन्न करने की विधि समझाता है, और निर्यातित दस्तावेज़ में टिप्पणी शामिल करने के लिए उनके लेआउट को कॉन्फ़िगर करने का प्रदर्शन करता है।

## **PowerPoint को HTML5 में निर्यात करें**

यह Java कोड दिखाता है कि कैसे आप वेब एक्स्टेंशन और निर्भरताओं के बिना प्रस्तुति को HTML5 में निर्यात कर सकते हैं:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
इस मामले में, आपको साफ़ HTML प्राप्त होता है।
{{% /alert %}}

आप इस तरह आकार एनिमेशन और स्लाइड ट्रांज़िशन के लिए सेटिंग्स निर्दिष्ट कर सकते हैं:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint को HTML में निर्यात करें**

यह Java मानक PowerPoint से HTML निर्यात प्रक्रिया को प्रदर्शित करता है:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

इस मामले में, प्रस्तुति सामग्री SVG के माध्यम से इस प्रकार रेंडर की जाती है:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
जब आप इस विधि का उपयोग करके PowerPoint को HTML में निर्यात करते हैं, तो SVG रेंडरिंग के कारण आप विशिष्ट तत्वों पर शैली लागू नहीं कर पाएंगे या उन्हें एनीमेट नहीं कर पाएंगे। 
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

**Aspose.Slides** आपको PowerPoint प्रस्तुति को एक HTML5 दस्तावेज़ में बदलने की सुविधा देता है जिसमें स्लाइड्स स्लाइड व्यू मोड में प्रस्तुत की जाती हैं। इस मामले में, जब आप प्राप्त HTML5 फ़ाइल को ब्राउज़र में खोलते हैं, तो आप वेब पेज पर स्लाइड व्यू मोड में प्रस्तुति देखते हैं।

यह Java कोड PowerPoint से HTML5 स्लाइड व्यू निर्यात प्रक्रिया को प्रदर्शित करता है:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टिप्पणियों के साथ प्रस्तुति को HTML5 दस्तावेज़ में बदलें**

PowerPoint में टिप्पणियाँ एक उपकरण हैं जो उपयोगकर्ताओं को प्रस्तुति स्लाइड्स पर नोट्स या फीडबैक छोड़ने की अनुमति देती हैं। वे सहयोगी परियोजनाओं में विशेष रूप से उपयोगी हैं, जहाँ कई लोग मुख्य सामग्री को बदले बिना विशिष्ट स्लाइड तत्वों पर अपनी सुझाव या टिप्पणी जोड़ सकते हैं। प्रत्येक टिप्पणी लेखक का नाम दिखाती है, जिससे यह ट्रैक करना आसान हो जाता है कि टिप्पणी किसने छोड़ी।

मान लीजिए हमारे पास निम्नलिखित PowerPoint प्रस्तुति "sample.pptx" फ़ाइल में सहेजी गई है।

![प्रस्तुति स्लाइड पर दो टिप्पणियाँ](two_comments_pptx.png)

जब आप PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में बदलते हैं, तो आप आउटपुट दस्तावेज़ में प्रस्तुति की टिप्पणियां शामिल करनी हैं या नहीं, इसे आसानी से निर्दिष्ट कर सकते हैं। इसके लिए आपको [Html5Options](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/) क्लास के `getNotesCommentsLayouting` मेथड में टिप्पणी के प्रदर्शन पैरामीटर निर्दिष्ट करने होंगे।

निम्नलिखित कोड उदाहरण एक प्रस्तुति को HTML5 दस्तावेज़ में बदलता है जिसमें टिप्पणियां स्लाइड के दाईं ओर दिखाई देती हैं।

```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

"output.html" दस्तावेज़ नीचे की छवि में दिखाया गया है।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियंत्रित कर सकता हूँ कि ऑब्जेक्ट एनिमेशन और स्लाइड ट्रांज़िशन HTML5 में चलें या नहीं?**

हाँ, HTML5 आकार एनिमेशन ([आकार एनिमेशन](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-)) और स्लाइड ट्रांज़िशन ([स्लाइड ट्रांज़िशन](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)) को सक्षम या अक्षम करने के लिए अलग विकल्प प्रदान करता है।

**क्या टिप्पणियों का आउटपुट समर्थित है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**

हाँ, टिप्पणियों को HTML5 में जोड़ा जा सकता है और नोट्स और टिप्पणियों के लिए [लेआउट सेटिंग्स](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) के माध्यम से (उदाहरण के लिए, स्लाइड के दाईं ओर) स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को छोड़ सकता हूँ?**

हाँ, एक [सेटिंग](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) है जो सहेजते समय JavaScript कॉल वाले हाइपरलिंक को छोड़ने की अनुमति देती है। यह सख़्त सुरक्षा नीतियों का पालन करने में मदद करती है।