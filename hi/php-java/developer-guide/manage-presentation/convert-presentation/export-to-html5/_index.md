---
title: PHP में प्रस्तुतियों को HTML5 में बदलें
linktitle: प्रेजेंटेशन से HTML5
type: docs
weight: 40
url: /hi/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP द्वारा Java के माध्यम से PowerPoint और OpenDocument प्रस्तुतियों को रिस्पॉन्सिव HTML5 में निर्यात करें। स्वरूपण, एनीमेशन और इंटरैक्टिविटी को बनाए रखें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में बदलने की प्रक्रिया समझाता है। यह वेब एक्सटेंशन या अतिरिक्त निर्भरताओं के बिना बुनियादी HTML5 निर्यात, तथा शैप एनीमेशन और स्लाइड ट्रांज़िशन को नियंत्रित करने के विकल्पों को कवर करता है। लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया को भी दर्शाता है, स्लाइड व्यू मोड में HTML5 आउटपुट उत्पन्न करने की विधि बताता है, और लेआउट को कॉन्फ़िगर करके निर्यात दस्तावेज़ में टिप्पणी शामिल करने का तरीका दिखाता है।

## **PowerPoint को HTML5 में निर्यात करें**

यह PHP कोड दर्शाता है कि आप वेब एक्सटेंशन और निर्भरताओं के बिना प्रस्तुति को HTML5 में कैसे निर्यात कर सकते हैं:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
इस स्थिति में, आपको साफ़ HTML मिलती है। 
{{% /alert %}}

आप इस प्रकार शैप एनीमेशन और स्लाइड ट्रांज़िशन की सेटिंग्स निर्दिष्ट करना चाहेंगे:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint को HTML में निर्यात करें**

यह Java कोड मानक PowerPoint से HTML निर्यात प्रक्रिया को दर्शाता है:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
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
```php

```

{{% alert title="Note" color="warning" %}} 

When you use this method to export PowerPoint to HTML, due to the SVG rendering, you will not be to apply styles or animate specific elements. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** allows you to convert a PowerPoint presentation to an HTML5 document in which the slides are presented in a slide view mode. In this case, when you open the resulting HTML5 file in a browser, you see the presentation in slide view mode on a web page. 

This PHP code demonstrates the PowerPoint to HTML5 Slide View export process:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convert Presentations to HTML5 Documents with Comments**

Comments in PowerPoint are a tool that allows users to leave notes or feedback on presentation slides. They are especially useful in collaborative projects, where multiple people can add their suggestions or remarks to specific slide elements without altering the main content. Each comment shows the author's name, making it easy to track who left the remark.

Let's say we have the following PowerPoint presentation saved in the "sample.pptx" file.

![Two comments on the presentation slide](two_comments_pptx.png)

When you convert a PowerPoint presentation to an HTML5 document, you can easily specify whether to include comments from the presentation in the output document. To do this, you need to specify the display parameters for comments in the `getNotesCommentsLayouting` method of the `Html5Options` class.

The following code example converts a presentation to an HTML5 document with comments displayed to the right of the slides.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();

"output.html" दस्तावेज़ नीचे दर्शाए गए चित्र में दिखाया गया है।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियंत्रित कर सकता हूँ कि ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन HTML5 में चलेंगे या नहीं?**

हाँ, HTML5 अलग-अलग विकल्प प्रदान करता है [शेप एनीमेशन]({{guid1}}) और [स्लाइड ट्रांज़िशन]({{guid2}}) को सक्षम या अक्षम करने के लिए।

**क्या टिप्पणी का आउटपुट समर्थित है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**

हाँ, टिप्पणियाँ HTML5 में जोड़ी जा सकती हैं और [लेआउट सेटिंग्स]({{guid3}}) के माध्यम से (उदाहरण के लिए, स्लाइड के दाएँ) स्थित की जा सकती हैं।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक्स को छोड़ सकता हूँ?**

हाँ, एक [सेटिंग]({{guid4}}) है जो आपको सहेजते समय JavaScript कॉल वाले हाइपरलिंक्स को छोड़ने की अनुमति देती है। यह कड़े सुरक्षा नीतियों का पालन करने में मदद करता है।