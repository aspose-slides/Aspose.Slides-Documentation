---
title: Python via Java में प्रस्तुतियों को HTML5 में बदलें
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
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों को प्रतिक्रियाशील HTML5 में निर्यात करें। स्वरूप, एनिमेशन और इंटरैक्टिविटी को संरक्षित रखें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में परिवर्तित करने के तरीके को समझाता है। यह अतिरिक्त वेब एक्सटेंशन के बिना मूलभूत HTML5 निर्यात, साथ ही shape एनिमेशन और slide ट्रांज़िशन को नियंत्रित करने के विकल्पों को कवर करता है। लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया को भी दिखाता है, स्लाइड व्यू मोड में HTML5 आउटपुट बनाने की प्रक्रिया समझाता है, और लेआउट को कॉन्फ़िगर करके निर्यातित दस्तावेज़ में टिप्पणियों को शामिल करने का प्रदर्शन करता है।

इन उदाहरणों के लिए Aspose.Slides for Python via Java और एक संगत Java रनटाइम की आवश्यकता होती है। `pres.pptx` (या टिप्पणी उदाहरण के लिए `sample.pptx`) को वर्तमान कार्य निर्देशिका में रखें। प्रत्येक उदाहरण केवल तब JVM शुरू करता है जब वह पहले से चल रहा न हो।

## **PowerPoint को HTML5 में निर्यात करें**

अतिरिक्त वेब एक्सटेंशन के बिना प्रस्तुति निर्यात करने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) के साथ [SaveFormat.Html5](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Html5) का उपयोग करें:

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
HTML5 निर्यातकर्ता ब्राउज़र में देखने के लिए HTML सामग्री बनाता है। 
{{% /alert %}}

निर्यात को कॉन्फ़िगर करने के लिए [Html5Options](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/) का उपयोग करें। shape एनिमेशन और slide ट्रांज़िशन को निष्क्रिय करने के लिए `False` के साथ [setAnimateShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setAnimateShapes) और [setAnimateTransitions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setAnimateTransitions) को कॉल करें:

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

मानक HTML निर्यात के लिए [SaveFormat.Html](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Html) का उपयोग करें। और विकल्पों के लिए [Convert PowerPoint to HTML](/slides/hi/python-java/convert-powerpoint-to-html/) देखें:

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

{{% alert title="चेतावनी" color="warning" %}} 
मानक HTML निर्यात SVG के द्वारा स्लाइड सामग्री को रेंडर करता है और HTML5 shape‑animation तथा slide‑transition विकल्प प्रदान नहीं करता है। 
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

**Aspose.Slides** आपको PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में बदलने की अनुमति देता है जिसमें स्लाइड्स स्लाइड व्यू मोड में प्रस्तुत होती हैं। इस मामले में, जब आप परिणामी HTML5 फ़ाइल को ब्राउज़र में खोलते हैं, तो आप वेब पेज पर स्लाइड व्यू मोड में प्रस्तुति देखते हैं।

यह Python कोड PowerPoint से HTML5 स्लाइड व्यू निर्यात प्रक्रिया को दर्शाता है:

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

PowerPoint में टिप्पणियाँ एक उपकरण हैं जो उपयोगकर्ताओं को प्रस्तुति स्लाइड्स पर नोट्स या फ़ीडबैक छोड़ने की अनुमति देती हैं। वे सहयोगी परियोजनाओं में विशेष रूप से उपयोगी होते हैं, जहाँ कई लोग मुख्य सामग्री को बदले बिना विशिष्ट स्लाइड तत्वों पर अपनी सुझाव या टिप्पणी जोड़ सकते हैं। प्रत्येक टिप्पणी लेखक का नाम दिखाती है, जिससे यह पता लगाना आसान हो जाता है कि टिप्पणी किसने छोड़ी।

मान लीजिए हमारे पास निम्नलिखित PowerPoint प्रस्तुति "sample.pptx" फ़ाइल में संग्रहीत है।

![प्रस्तुति स्लाइड पर दो टिप्पणियाँ](two_comments_pptx.png)

जब आप PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करते हैं, तो आप आसानी से निर्दिष्ट कर सकते हैं कि आउटपुट दस्तावेज़ में प्रस्तुति की टिप्पणियाँ शामिल करें या नहीं। ऐसा करने के लिए, [Html5Options](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/) वर्ग की [setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) विधि को टिप्पणियों के डिस्प्ले पैरामीटर पास करें।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/) और [setCommentsPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) को [CommentsPositions.Right](https://reference.aspose.com/slides/hi/python-java/aspose.slides/commentspositions/#Right) के साथ उपयोग करें। निम्नलिखित कोड उदाहरण प्रस्तुति को एक HTML5 दस्तावेज़ में परिवर्तित करता है जिसमें टिप्पणियाँ स्लाइड के दाईं ओर प्रदर्शित होती हैं।

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

"output.html" दस्तावेज़ नीचे दी गई छवि में दिखाया गया है।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं HTML5 में ऑब्जेक्ट एनिमेशन और स्लाइड ट्रांज़िशन चलने को नियंत्रित कर सकता हूँ?**

हां, HTML5 में shape एनिमेशन और slide ट्रांज़िशन को सक्षम या अक्षम करने के लिए अलग-अलग विकल्प उपलब्ध हैं। [shape animations](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setAnimateShapes) और [slide transitions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setAnimateTransitions) के लिए लिंक वही रखे गए हैं।

**क्या टिप्पणियों को निर्यात किया जा सकता है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**

हां, टिप्पणियों को HTML5 में जोड़ा जा सकता है और नोट्स व टिप्पणियों के लिए [layout settings](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) के माध्यम से (उदाहरण के लिए, स्लाइड के दाईं ओर) स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को छोड़ सकता हूँ?**

हां, एक [setting](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) है जो सहेजते समय JavaScript कॉल वाले हाइपरलिंक्स को छोड़ने की अनुमति देता है। यह उन हाइपरलिंक्स को हटा देता है; यह स्वयं यह गारंटी नहीं देता कि सभी उत्पन्न HTML5 स्क्रिप्ट साइट की कंटेंट सिक्योरिटी पॉलिसी को पूरी करती हैं।