---
title: Android पर प्रस्तुतियों को HTML5 में परिवर्तित करें
linktitle: प्रेज़ेंटेशन को HTML5 में
type: docs
weight: 40
url: /hi/androidjava/export-to-html5/
keywords:
- PowerPoint को HTML5 में
- OpenDocument को HTML5 में
- प्रेज़ेंटेशन को HTML5 में
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
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों को जावा के माध्यम से Android के लिए Aspose.Slides के साथ प्रतिक्रियाशील HTML5 में निर्यात करें। स्वरूपण, एनीमेशन और इंटरएक्टिविटी को बनाए रखें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में परिवर्तित करने की विधि बताता है। यह वेब एक्सटेंशन या अतिरिक्त निर्भरताओं के बिना बुनियादी HTML5 निर्यात, साथ ही आकार एनीमेशन और स्लाइड ट्रांज़िशन को नियंत्रित करने के विकल्प को कवर करता है। यह लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया, स्लाइड व्यू मोड में HTML5 आउटपुट उत्पन्न करने की विधि, और निर्यातित दस्तावेज़ में टिप्पणी को शामिल करने के लिए उनका लेआउट कॉन्फ़िगर करने का प्रदर्शन भी दिखाता है।

## **PowerPoint को HTML5 में निर्यात करें**

यह Java कोड दिखाता है कि कैसे आप प्रस्तुति को वेब एक्सटेंशन और निर्भरताओं के बिना HTML5 में निर्यात कर सकते हैं:

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
इस मामले में, आपको शुद्ध HTML प्राप्त होगा। 
{{% /alert %}}

आप इस तरह आकार एनीमेशन और स्लाइड ट्रांज़िशन के लिए सेटिंग्स निर्दिष्ट कर सकते हैं:

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

## **PowerPoint को HTML में निर्यात करें**

यह Java मानक PowerPoint से HTML प्रक्रिया दर्शाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

इस मामले में, प्रस्तुति सामग्री SVG के माध्यम से इस रूप में रेंडर की जाती है:

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
जब आप इस विधि से PowerPoint को HTML में निर्यात करते हैं, SVG रेंडरिंग के कारण, आप विशिष्ट तत्वों पर शैलियाँ लागू नहीं कर पाएंगे या उन्हें एनीमेट नहीं कर पाएंगे। 
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

**Aspose.Slides** आपको PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करने की अनुमति देता है जिसमें स्लाइड्स स्लाइड व्यू मोड में प्रदर्शित होती हैं। इस स्थिति में, जब आप निर्मित HTML5 फ़ाइल को ब्राउज़र में खोलते हैं, तो आप वेब पृष्ठ पर स्लाइड व्यू मोड में प्रस्तुति देख सकते हैं। 

यह Java कोड PowerPoint से HTML5 स्लाइड व्यू निर्यात प्रक्रिया दिखाता है:

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

## **टिप्पणियों सहित प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करें**

PowerPoint में टिप्पणियाँ एक उपकरण हैं जिससे उपयोगकर्ता प्रस्तुति स्लाइड्स पर नोट्स या फीडबैक छोड़ सकते हैं। ये सहयोगी प्रोजेक्ट्स में विशेष रूप से उपयोगी हैं, जहाँ कई लोग मुख्य सामग्री को बदले बिना विशिष्ट स्लाइड तत्वों पर अपने सुझाव या टिप्पणी जोड़ सकते हैं। प्रत्येक टिप्पणी लेखक का नाम प्रदर्शित करती है, जिससे यह पता लगाना आसान हो जाता है कि टिप्पणी किसने छोड़ी।

मान लीजिए हमारे पास निम्नलिखित PowerPoint प्रस्तुति "sample.pptx" फ़ाइल में सहेजी गई है।

![प्रस्तुति स्लाइड पर दो टिप्पणियाँ](two_comments_pptx.png)

जब आप PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करते हैं, तो आप आसानी से यह निर्धारित कर सकते हैं कि आउटपुट दस्तावेज़ में प्रस्तुति की टिप्पणियाँ शामिल होंगी या नहीं। इसके लिए, आपको टिप्पणी के डिस्प्ले पैरामीटर को `setSlidesLayoutOptions` मेथड में [Html5Options](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/) क्लास के द्वारा पास करना होगा।

निम्नलिखित कोड उदाहरण प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करता है जिसमें टिप्पणियाँ स्लाइड के दाहिनी ओर प्रदर्शित होती हैं।

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

"output.html" दस्तावेज़ नीचे की छवि में दिखाया गया है।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं नियंत्रित कर सकता हूँ कि ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन HTML5 में प्ले हों?

हाँ, HTML5 अलग-अलग विकल्प प्रदान करता है ताकि आप [shape animations](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) और [slide transitions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) को सक्षम या अक्षम कर सकें।

### क्या टिप्पणियों का आउटपुट समर्थित है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?

हाँ, HTML5 में टिप्पणियों को जोड़ा जा सकता है और उन्हें (उदाहरण के लिए, स्लाइड के दाहिनी ओर) नोट्स और टिप्पणियों के लिए [layout settings](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) के माध्यम से स्थित किया जा सकता है।

### क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को स्किप कर सकता हूँ?

हाँ, एक [setting](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) उपलब्ध है जो सहेजने के दौरान JavaScript कॉल वाले हाइपरलिंक को स्किप करने की अनुमति देता है। यह कड़ी सुरक्षा नीतियों के अनुपालन में मदद करता है।