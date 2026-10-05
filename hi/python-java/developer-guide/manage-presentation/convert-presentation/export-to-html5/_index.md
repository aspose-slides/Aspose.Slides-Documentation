---
title: Python द्वारा Java के माध्यम से प्रस्तुतियों को HTML5 में बदलें
linktitle: प्रस्तुति को HTML5 में
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
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को उत्तरदायी HTML5 में निर्यात करें। स्वरूपण, एनीमेशन और इंटरैक्टिविटी को बनाए रखें।"
---
## **परिचय**

यह लेख बताता है कि Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में कैसे बदलें। यह बुनियादी निर्यात, आकार एनिमेशन और स्लाइड ट्रांज़िशन नियंत्रण, तथा टिप्पणी लेआउट को कवर करता है। यह मानक HTML निर्यात के SVG-आधारित आउटपुट की तुलना में HTML5 आउटपुट की भी तुलना करता है।

उदाहरणों के लिए Aspose.Slides for Python via Java और एक संगत Java रनटाइम आवश्यक है। इनपुट प्रस्तुतियों को वर्तमान कार्यशील निर्देशिका में रखें। प्रत्येक उदाहरण JVM को तभी शुरू करता है जब वह पहले से चल रहा न हो।

## **PowerPoint को HTML5 में निर्यात करें**

निम्न उदाहरण कार्यशील निर्देशिका से एक प्रस्तुति लोड करता है और इसे HTML5 फ़ॉर्मेट में सहेजता है। यह डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करता है; अगला उदाहरण स्पष्ट रूप से एनिमेशन प्लेबैक को नियंत्रित करना दिखाता है। इनपुट पथ को अपनी प्रस्तुति के पथ से बदलें।

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

{{% alert color="info" title="Note" %}}

HTML दस्तावेज़ के अलावा, निर्यात स्लाइड स्टाइलिंग, एनीमेशन, इफ़ेक्ट और नेविगेशन के लिए सहायक CSS और JavaScript फ़ाइलें लिखता है। इन फ़ाइलों को HTML दस्तावेज़ के साथ रखें जब आप आउटपुट को स्थानांतरित या प्रकाशित करें। उत्पन्न पृष्ठ jQuery और Anime.js को सार्वजनिक CDN से भी लोड करता है; इनके बिना स्लाइड नेविगेशन और एनीमेशन नहीं चलेंगे।

{{% /alert %}}

आकार एनिमेशन या स्लाइड ट्रांज़िशन चलाए बिना निर्यात करने के लिए, `False` को [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) और [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) में [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) में पास करें। ये सेटिंग्स स्वतंत्र हैं, इसलिए आप एक को सक्षम कर सकते हैं जबकि दूसरे को निष्क्रिय रख सकते हैं। यह उदाहरण दोनों प्रकार की एनीमेशन को निष्क्रिय करके प्रस्तुति को निर्यात करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **PowerPoint को HTML में निर्यात करें**

मानक HTML निर्यात एक अलग रेंडरिंग दृष्टिकोण का उपयोग करता है: स्लाइड सामग्री को HTML पृष्ठ के भीतर SVG के रूप में दर्शाया जाता है। निम्न उदाहरण इस रेंडरिंग विधि का उपयोग करके प्रस्तुति को एक HTML दस्तावेज़ में बदलता है।

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

नीचे दिया गया सरलीकृत मार्कअप उत्पन्न पृष्ठ की संरचना दर्शाता है। SVG तत्व में रेंडर की गई स्लाइड सामग्री होती है; यह प्लेसहोल्डर टेक्स्ट उस सामग्री का प्रतिनिधित्व करता है और वास्तविक निर्यात आउटपुट नहीं है।

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}

SVG-आधारित निर्यात PowerPoint आकारों को व्यक्तिगत HTML तत्वों के रूप में उजागर नहीं करता। इस लेख में प्रदर्शित आकार-एनिमेशन और स्लाइड-ट्रांज़िशन विकल्पों की आवश्यकता होने पर HTML5 निर्यात का उपयोग करें।

{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

HTML5 निर्यात एक पृष्ठ उत्पन्न करता है जिससे आप ब्राउज़र में प्रस्तुति स्लाइड्स को देख और नेविगेट कर सकते हैं। यह उदाहरण दोनों [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) और [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) को सक्षम करता है ताकि निर्यातित स्लाइड व्यू स्रोत प्रस्तुति के प्रभावों को चला सके।

ऐसी प्रस्तुति का उपयोग करें जिसमें पहले से आकार एनिमेशन और स्लाइड ट्रांज़िशन हों, ताकि इन सेटिंग्स के प्रभाव को देख सकें। इन्हें सक्षम करने से उन स्लाइड्स पर नए प्रभाव नहीं जुड़ते जिनमें पहले से कोई प्रभाव नहीं था। निर्यात के बाद, उत्पन्न HTML5 दस्तावेज़ को ब्राउज़र में खोलें और उसके सहायक फ़ाइलें उपलब्ध रखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **टिप्पणियों के साथ HTML5 दस्तावेज़ में प्रस्तुति को बदलें**

आप HTML5 आउटपुट में मौजूदा स्लाइड टिप्पणियों को शामिल कर सकते हैं ताकि पाठकों को स्लाइड सामग्री के साथ प्रतिक्रिया देख सके। इस सेक्शन में उदाहरण इस बात की अपेक्षा करता है कि स्रोत प्रस्तुति में टिप्पणियां मौजूद हों, जैसा कि नीचे दिखाया गया है। यह उन टिप्पणियों को निर्यात करता है; नई टिप्पणियां नहीं बनाता।

![प्रस्तुति स्लाइड पर दो टिप्पणियां](two_comments_pptx.png)

एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) ऑब्जेक्ट को [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) मेथड में [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) के साथ पास करें। [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) का उपयोग करके [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) enumeration से `Right` चुनें ताकि प्रत्येक स्लाइड के दाईं ओर टिप्पणियाँ रखी जा सकें।

निम्न उदाहरण इस टिप्पणी लेआउट के साथ प्रस्तुति को HTML5 में निर्यात करता है। टिप्पणियों वाली प्रस्तुति नहीं होने पर कोई टिप्पणी टेक्स्ट प्रदर्शित नहीं होगा।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

नीचे की छवि में निर्यातित HTML5 दस्तावेज़ दिखाया गया है जिसमें टिप्पणी स्लाइड के बगल में प्रदर्शित होती हैं।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियां](two_comments_html5.png)

## **निर्यात के दौरान JavaScript हाइपरलिंक को बाहर रखें**

मान लें `hyperlinks.pptx` में एक लिंक किया हुआ टेक्स्ट है जिसका लक्ष्य `javascript:alert('Hello')` है और एक सामान्य `https://example.com/` लिंक है। निर्यात के दौरान JavaScript हाइपरलिंक को बाहर रखने के लिए, `True` को [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) में पास करें। डिफ़ॉल्ट `False` है, इसलिए इन लिंक को फ़िल्टर नहीं किया जाता जब तक आप विकल्प को सक्षम न करें।

निम्न उदाहरण कार्यशील निर्देशिका से प्रस्तुति लोड करता है और इसे [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) का उपयोग करके निर्यात करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

निर्यातित फ़ाइल JavaScript हाइपरलिंक को छोड़ देती है जबकि उसका टेक्स्ट और सामान्य HTTPS लिंक बरकरार रहता है। स्रोत प्रस्तुति अपरिवर्तित रहती है।

यह विकल्प JavaScript हाइपरलिंक को फ़िल्टर करता है; यह सभी स्क्रिप्ट या अन्य सक्रिय सामग्री को नहीं हटाता, न ही यह CSP अनुपालन की गारंटी देता है। उदाहरण के लिए, HTML5 आउटपुट में अभी भी स्लाइड नेविगेशन और एनीमेशन के लिए स्क्रिप्ट शामिल होती हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियंत्रित कर सकता हूँ कि ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन HTML5 में चलेंगे या नहीं?**

हाँ, HTML5 निर्यात अलग-अलग विकल्प प्रदान करता है जिससे आप [shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) और [slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) को सक्षम या निष्क्रिय कर सकते हैं।

**क्या टिप्पणियों का समर्थन है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**

हाँ, मौजूदा टिप्पणियों को HTML5 आउटपुट में शामिल किया जा सकता है और उन्हें (उदाहरण के लिए, स्लाइड के दाईं ओर) [layout settings](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) के माध्यम से स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को छोड़ सकता हूँ?**

हाँ, [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) सेटिंग आपको सहेजते समय JavaScript कॉल वाले हाइपरलिंक को छोड़ने की अनुमति देती है। डिफ़ॉल्ट `False` है। इस फ़िल्टर के दायरे और एक HTML5 निर्यात उदाहरण के लिए देखें [Exclude JavaScript Hyperlinks During Export](/slides/hi/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export)। यह सेटिंग HTML5 व्यूअर के नेविगेशन और एनीमेशन के लिए उपयोग किए जाने वाले JavaScript को नहीं हटाती।