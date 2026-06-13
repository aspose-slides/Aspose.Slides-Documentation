---
title: जावा में प्रस्तुतियों को HTML5 में परिवर्तित करें
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
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों को उत्तरदायी HTML5 में निर्यात करें। स्वरूपण, एनीमेशन और इंटरैक्टिविटी को बनाए रखें।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में कैसे बदलें। यह वेब एक्सटेंशन या अतिरिक्त निर्भरताओं के बिना बेसिक HTML5 निर्यात, साथ ही आकार एनीमेशन और स्लाइड ट्रांज़िशन को नियंत्रित करने वाले विकल्पों को कवर करता है। लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया को भी दर्शाता है, स्लाइड व्यू मोड में HTML5 आउटपुट कैसे जनरेट करें समझाता है, और लेआउट कॉन्फ़िगर करके निर्यात किए गए दस्तावेज़ में टिप्पणियों को शामिल करने का प्रदर्शन करता है।

## **PowerPoint को HTML5 में निर्यात करें**

यह Java कोड दिखाता है कि आप वेब एक्सटेंशन और निर्भरताओं के बिना प्रस्तुति को HTML5 में कैसे निर्यात करें:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
इस मामले में आपको साफ़ HTML प्राप्त होगी। 
{{% /alert %}}

आप इस प्रकार आकार एनीमेशन और स्लाइड ट्रांज़िशन के लिए सेटिंग्स निर्दिष्ट कर सकते हैं:

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

यह Java मानक PowerPoint‑to‑HTML प्रक्रिया को दर्शाता है:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

इस मामले में प्रस्तुति की सामग्री SVG के माध्यम से इस रूप में रेंडर की जाती है:

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
जब आप इस विधि से PowerPoint को HTML में निर्यात करते हैं, तो SVG रेंडरिंग के कारण आप विशिष्ट तत्वों पर स्टाइल लागू नहीं कर पाएंगे या उन्हें एनीमेट नहीं कर पाएंगे। 
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

**Aspose.Slides** आपको PowerPoint प्रस्तुति को एक HTML5 दस्तावेज़ में बदलने की अनुमति देता है, जिसमें स्लाइडें स्लाइड व्यू मोड में प्रस्तुत होती हैं। इस मामले में, जब आप उत्पन्न HTML5 फ़ाइल को ब्राउज़र में खोलते हैं, तो आप वेब पृष्ठ पर स्लाइड व्यू मोड में प्रस्तुति देखते हैं।

यह Java कोड PowerPoint को HTML5 स्लाइड व्यू निर्यात प्रक्रिया को दर्शाता है:

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

## **टिप्पणियों के साथ HTML5 दस्तावेज़ों में प्रस्तुतियों को बदलें**

PowerPoint में टिप्पणियाँ उपयोगकर्ताओं को स्लाइड पर नोट या फीडबैक छोड़ने का साधन हैं। ये सहयोगी परियोजनाओं में विशेष रूप से उपयोगी होती हैं, जहाँ कई लोग मुख्य सामग्री को बदले बिना विशिष्ट स्लाइड तत्वों पर अपने सुझाव या टिप्पणी जोड़ सकते हैं। प्रत्येक टिप्पणी लेखक का नाम दिखाती है, जिससे यह ट्रैक करना आसान हो जाता है कि टिप्पणी किसने छोड़ी।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल में निम्नलिखित PowerPoint प्रस्तुति संग्रहीत है।

![प्रस्तुति स्लाइड पर दो टिप्पणियाँ](two_comments_pptx.png)

जब आप PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में बदलते हैं, तो आप आसानी से यह निर्धारित कर सकते हैं कि क्या प्रस्तुति की टिप्पणियाँ आउटपुट दस्तावेज़ में शामिल होंगी। ऐसा करने के लिए आपको [Html5Options](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/) क्लास की `getNotesCommentsLayouting` मेथड में टिप्पणियों के डिस्प्ले पैरामीटर निर्दिष्ट करने होते हैं।

निम्न कोड उदाहरण प्रस्तुतियों को HTML5 दस्तावेज़ में बदलता है, जिसमें टिप्पणियाँ स्लाइड के दाएँ तरफ प्रदर्शित होती हैं।
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

नीचे दिखाए गए चित्र में "output.html" दस्तावेज़ प्रदर्शित किया गया है।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियंत्रित कर सकता हूँ कि ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन HTML5 में चलें या नहीं?**

हाँ, HTML5 में अलग‑अलग विकल्प मौजूद हैं जिससे आप [shape animations](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) और [slide transitions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) को सक्षम या अक्षम कर सकते हैं।

**क्या टिप्पणी आउटपुट समर्थित है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**

हाँ, टिप्पणी को HTML5 में जोड़ा जा सकता है और नोट्स एवं टिप्पणियों के लिए [layout settings](https://reference.aspose.com/slides/hi/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) के माध्यम से (उदाहरण के लिए, स्लाइड के दाएँ) स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript कॉल करने वाले लिंक को स्किप कर सकता हूँ?**

हाँ, एक [setting](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) उपलब्ध है जो सहेजने के दौरान JavaScript कॉल वाले हाइपरलिंक को स्किप करने की अनुमति देता है। यह कड़े सुरक्षा नीतियों के अनुपालन में मदद करता है।