---
title: Java में प्रस्तुतियों को HTML5 में परिवर्तित करें
linktitle: प्रस्तुति से HTML5
type: docs
weight: 40
url: /hi/java/export-to-html5/
keywords:
- PowerPoint से HTML5
- OpenDocument से HTML5
- प्रस्तुति से HTML5
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों को प्रतिक्रियाशील HTML5 में निर्यात करें। स्वरूपण, एनीमेशन और इंटरैक्टिविटी को संरक्षित रखें।"
---
## **Overview**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में परिवर्तित करने के तरीके को समझाता है। यह वेब एक्सटेंशन या अतिरिक्त निर्भरताओं के बिना मूलभूत HTML5 निर्यात, साथ ही आकार एनीमेशन और स्लाइड ट्रांज़िशन को नियंत्रित करने के विकल्पों को कवर करता है। लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया, स्लाइड व्यू मोड में HTML5 आउटपुट कैसे उत्पन्न करें, और लेआउट कॉन्फ़िगर करके निर्यातित दस्तावेज़ में टिप्पणियों को शामिल करने का प्रदर्शन भी करता है।

## **Export PowerPoint to HTML5**

यह Java कोड दर्शाता है कि आप वेब एक्सटेंशन और निर्भरताओं के बिना प्रस्तुति को HTML5 में कैसे निर्यात कर सकते हैं:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

इस मामले में आपको साफ़ HTML मिलता है। 

{{% /alert %}}

आप इस तरह आकार एनीमेशन और स्लाइड ट्रांज़िशन के लिए सेटिंग्स निर्दिष्ट करना चाह सकते हैं:

```java
import com.aspose.slides.*;

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

## **Export PowerPoint to HTML**

यह Java मानक PowerPoint से HTML प्रक्रिया को दर्शाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

इस मामले में, प्रस्तुति सामग्री SVG के माध्यम से इस प्रकार प्रस्तुत की जाती है:

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

जब आप इस विधि से PowerPoint को HTML में निर्यात करते हैं, तो SVG रेंडरिंग के कारण आप विशिष्ट तत्वों पर शैली लागू करने या एनीमेट करने में सक्षम नहीं होंगे। 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** आपको PowerPoint प्रस्तुति को एक HTML5 दस्तावेज़ में परिवर्तित करने की अनुमति देता है जिसमें स्लाइडें स्लाइड व्यू मोड में प्रस्तुत होती हैं। इस मामले में, जब आप उत्पन्न HTML5 फ़ाइल को ब्राउज़र में खोलते हैं, तो आप वेब पृष्ठ पर स्लाइड व्यू मोड में प्रस्तुति देखेंगे। 

यह Java कोड PowerPoint से HTML5 स्लाइड व्यू निर्यात प्रक्रिया को दर्शाता है:

```java
import com.aspose.slides.*;

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

## **Convert Presentations to HTML5 Documents with Comments**

PowerPoint में टिप्पणियाँ एक उपकरण हैं जो उपयोगकर्ताओं को प्रस्तुति स्लाइड्स पर नोट्स या प्रतिक्रिया छोड़ने की सुविधा देती हैं। ये विशेष रूप से सहयोगी परियोजनाओं में उपयोगी होती हैं, जहाँ कई लोग मुख्य सामग्री को बदले बिना विशिष्ट स्लाइड तत्वों पर अपने सुझाव या टिप्पणी जोड़ सकते हैं। प्रत्येक टिप्पणी लेखक का नाम दिखाती है, जिससे यह पता लगाना आसान हो जाता है कि टिप्पणी किसने छोड़ी।

मान लीजिए हमारे पास निम्नलिखित PowerPoint प्रस्तुति "sample.pptx" फ़ाइल में सहेजी गई है।

![प्रस्तुति स्लाइड पर दो टिप्पणियाँ](two_comments_pptx.png)

जब आप PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करते हैं, तो आप आसानी से निर्धारित कर सकते हैं कि आउटपुट दस्तावेज़ में प्रस्तुति की टिप्पणियाँ शामिल हों या न हों। ऐसा करने के लिए, टिप्पणियों के डिस्प्ले पैरामीटर को [Html5Options](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/) क्लास की `setSlidesLayoutOptions` मेथड में पास करें।

निम्नलिखित कोड उदाहरण प्रस्तुति को टिप्पणियों को स्लाइड के दाईं ओर दिखाते हुए HTML5 दस्तावेज़ में परिवर्तित करता है।
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

नीचे दिखाए गए चित्र में "output.html" दस्तावेज़ प्रदर्शित है।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **FAQ**

### क्या मैं नियंत्रित कर सकता हूँ कि ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन HTML5 में चलें या न चलें?

हां, HTML5 में [आकार एनीमेशन](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) और [स्लाइड ट्रांज़िशन](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) को सक्षम या निष्क्रिय करने के अलग विकल्प प्रदान करता है।

### क्या टिप्पणियों का आउटपुट समर्थित है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?

हां, टिप्पणियों को HTML5 में जोड़ा जा सकता है और नोट्स और टिप्पणियों के लिए [लेआउट सेटिंग्स](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) के माध्यम से (उदाहरण के लिए, स्लाइड के दाईं ओर) स्थित किया जा सकता है।

### क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को छोड़ सकता हूँ?

हां, एक [सेटिंग](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) है जो सहेजते समय JavaScript कॉल वाले हाइपरलिंक्स को छोड़ने की अनुमति देती है। यह सख्त सुरक्षा नीतियों के साथ अनुपालन करने में मदद करती है।