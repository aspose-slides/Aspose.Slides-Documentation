---
title: Python के माध्यम से Java में प्रस्तुतियों को HTML5 में बदलें
linktitle: प्रस्तुतियों को HTML5 में
type: docs
weight: 40
url: /hi/python-java/export-to-html5/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को रिस्पॉन्सिव HTML5 में निर्यात करें। फ़ॉर्मेटिंग, एनीमेशन और इंटरैक्टिविटी को संरक्षित रखें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में परिवर्तित करने का तरीका बताता है। यह अतिरिक्त वेब एक्सटेंशन के बिना मूल HTML5 निर्यात, साथ ही आकार एनीमेशन और स्लाइड ट्रांज़िशन को नियंत्रित करने के विकल्पों को कवर करता है। लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया, स्लाइड व्यू मोड में HTML5 आउटपुट बनाने की विधि, और निर्यात किए गए दस्तावेज़ में स्वरूपित करके टिप्पणी को शामिल करने का प्रदर्शन भी दिखाता है।

## **PowerPoint को HTML5 में निर्यात करें**

अतिरिक्त वेब एक्सटेंशन के बिना प्रस्तुति को निर्यात करने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) को [SaveFormat.Html5](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Html5) के साथ उपयोग करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="नोट" %}} 
HTML5 एक्सपोर्टर ब्राउज़र में देखने योग्य HTML सामग्री बनाता है। 
{{% /alert %}}

निर्यात को कॉन्फ़िगर करने के लिए [Html5Options](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/) का उपयोग करें। आकार एनीमेशन और स्लाइड ट्रांज़िशन को निष्क्रिय करने के लिए `False` के साथ [setAnimateShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setAnimateShapes) और [setAnimateTransitions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setAnimateTransitions) को कॉल करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **PowerPoint को HTML में निर्यात करें**

मानक HTML निर्यात के लिए [SaveFormat.Html](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Html) का उपयोग करें। अधिक विकल्पों के लिए [Convert PowerPoint to HTML](/slides/hi/python-java/convert-powerpoint-to-html/) देखें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

इस मामले में, प्रस्तुति सामग्री को SVG के माध्यम से इस रूप में प्रस्तुत किया जाता है:

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
मानक HTML निर्यात स्लाइड सामग्री को SVG के माध्यम से रेंडर करता है और HTML5 आकार‑एनीमेशन तथा स्लाइड‑ट्रांज़िशन विकल्प प्रदान नहीं करता है। 
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

**Aspose.Slides** आपको PowerPoint प्रस्तुति को एक HTML5 दस्तावेज़ में परिवर्तन करने देता है जहाँ स्लाइड्स स्लाइड व्यू मोड में प्रदर्शित होती हैं। इस स्थिति में, जब आप उत्पन्न HTML5 फ़ाइल को ब्राउज़र में खोलते हैं, तो आप वेब पेज पर स्लाइड व्यू मोड में प्रस्तुति देखते हैं। 

यह Python कोड PowerPoint को HTML5 स्लाइड व्यू निर्यात प्रक्रिया को दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **टिप्पणियों के साथ प्रस्तुतियों को HTML5 दस्तावेज़ों में परिवर्तित करें**

PowerPoint में टिप्पणियाँ एक उपकरण हैं जो उपयोगकर्ताओं को प्रस्तुति स्लाइड्स पर नोट्स या प्रतिक्रिया छोड़ने की अनुमति देती हैं। ये सहयोगी प्रोजेक्ट्स में विशेष रूप से उपयोगी होती हैं, जहाँ कई लोग मुख्य सामग्री को बदले बिना विशिष्ट स्लाइड तत्वों में अपनी सुझाव या टिप्पणी जोड़ सकते हैं। प्रत्येक टिप्पणी में लेखक का नाम दिखता है, जिससे यह पता चलना आसान हो जाता है कि टिप्पणी किसने छोड़ी।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल में निम्नलिखित PowerPoint प्रस्तुति सहेजी गई है।

![प्रस्तुति स्लाइड पर दो टिप्पणियाँ](two_comments_pptx.png)

जब आप PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करते हैं, तो आप आसानी से निर्धारित कर सकते हैं कि आउटपुट दस्तावेज़ में प्रस्तुति की टिप्पणियों को शामिल करना है या नहीं। ऐसा करने के लिए, टिप्पणियों के प्रदर्शन पैरामीटर को [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) मेथड में [Html5Options](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/) क्लास के माध्यम से पास करें।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/) और [setCommentsPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) का उपयोग [CommentsPositions.Right](https://reference.aspose.com/slides/hi/python-java/aspose.slides/commentspositions/#Right) के साथ करें। निम्नलिखित कोड उदाहरण प्रस्तुति को एक HTML5 दस्तावेज़ में परिवर्तित करता है जहाँ टिप्पणियाँ स्लाइड्स के दाहिनी ओर प्रदर्शित होती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

"output.html" दस्तावेज़ नीचे की छवि में दिखाया गया है।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं HTML5 में ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन के प्ले होने को नियंत्रित कर सकता हूँ?**

हाँ, HTML5 में आकार एनीमेशन और स्लाइड ट्रांज़िशन को सक्षम या अक्षम करने के लिए अलग विकल्प प्रदान किए गए हैं। आप इन विकल्पों को [shape animations](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setAnimateShapes) और [slide transitions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setAnimateTransitions) के माध्यम से नियंत्रित कर सकते हैं।

**क्या टिप्पणी का आउटपुट समर्थित है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**

हाँ, टिप्पणी को HTML5 में जोड़ा जा सकता है और लेआउट सेटिंग्स के माध्यम से (उदाहरण के लिए, स्लाइड के दाएँ भाग में) स्थित किया जा सकता है। देखिए [layout settings](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setSlidesLayoutOptions)।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को छोड़ सकता हूँ?**

हाँ, एक [setting](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) मौजूद है जो सहेजने के दौरान JavaScript कॉल वाले हाइपरलिंक को छोड़ने की अनुमति देता है। यह उन लिंक को हटा देता है; यह स्वयं यह गारंटी नहीं देता कि सभी उत्पन्न HTML5 स्क्रिप्ट साइट की कंटेंट सिक्योरिटी पॉलिसी को पूरा करती हों।