---
title: Python में प्रस्तुतियों को HTML5 में बदलें
linktitle: प्रस्तुति को HTML5 में
type: docs
weight: 40
url: /hi/python-net/export-to-html5/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों को प्रतिक्रियाशील HTML5 में निर्यात करें। स्वरूपण, एनीमेशन और इंटरएक्टिविटी को संरक्षित रखें।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides for Python via .NET का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में कैसे बदलें। यह बेसिक एक्सपोर्ट, शेप एनीमेशन और स्लाइड ट्रांज़िशन के नियंत्रण, तथा टिप्पणी लेआउट को कवर करता है। यह HTML5 आउटपुट की तुलना मानक HTML एक्सपोर्ट के SVG‑आधारित आउटपुट से भी करता है।

## **PowerPoint को HTML5 में निर्यात करें**

निम्न उदाहरण कार्य निर्देशिका से एक प्रस्तुति लोड करता है और उसे HTML5 प्रारूप में सहेजता है। यह डिफ़ॉल्ट एक्सपोर्ट सेटिंग्स का उपयोग करता है; अगला उदाहरण एनीमेशन प्लेबैक को स्पष्ट रूप से नियंत्रित करने का तरीका दिखाता है। इनपुट पथ को अपनी प्रस्तुति के पथ से बदलें।

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
HTML दस्तावेज़ के अलावा, निर्यात स्लाइड स्टाइलिंग, एनिमेशन, इफ़ेक्ट और नेविगेशन के लिए समर्थनात्मक CSS और JavaScript फ़ाइलें भी लिखता है। इन फ़ाइलों को HTML दस्तावेज़ के साथ रखें जब आप आउटपुट को स्थानांतरित या प्रकाशन करें। जेनरेट किया गया पेज सार्वजनिक CDN से jQuery और Anime.js लोड करता है; इनके बिना स्लाइड नेविगेशन और एनिमेशन काम नहीं करेंगे।
{{% /alert %}}

शेप एनीमेशन या स्लाइड ट्रांज़िशन चलाए बिना निर्यात करने के लिए, [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) और [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) को `False` पर सेट करें [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) में। ये सेटिंग्स स्वतंत्र हैं, इसलिए आप एक को सक्षम कर सकते हैं जबकि दूसरे को अक्षम रख सकते हैं। उदाहरण जेनरेट किए गए पेज में दोनों प्रकार की एनीमेशन को अक्षम करके प्रस्तुति निर्यात करता है।

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **PowerPoint को HTML में निर्यात करें**

मानक HTML निर्यात एक अलग रेंडरिंग दृष्टिकोण का उपयोग करता है: स्लाइड सामग्री को HTML पेज के भीतर SVG द्वारा दर्शाया जाता है। निम्न उदाहरण इस रेंडरिंग दृष्टिकोण का उपयोग करके प्रस्तुति को HTML दस्तावेज़ में बदलता है।

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

नीचे दिया गया सरलीकृत मार्कअप जेनरेट किए गए पेज की संरचना को दर्शाता है। SVG तत्व में रेंडर की गई स्लाइड सामग्री होती है; प्लेसहोल्डर टेक्स्ट उस सामग्री का प्रतिनिधित्व करता है और वास्तविक एक्सपोर्ट आउटपुट नहीं है।

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
SVG‑आधारित निर्यात PowerPoint शेप को व्यक्तिगत HTML तत्वों के रूप में एक्सपोज़ नहीं करता। जब आपको इस लेख में प्रदर्शित शैप‑एनीमेशन और स्लाइड‑ट्रांज़िशन विकल्पों की आवश्यकता हो, तो HTML5 निर्यात का उपयोग करें।
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

HTML5 निर्यात ब्राउज़र में प्रस्तुति स्लाइड्स को देखने और नेविगेट करने के लिए एक पेज बनाता है। यह उदाहरण दोनों [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) और [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) को सक्षम करता है ताकि निर्यात किया गया स्लाइड व्यू स्रोत प्रस्तुति के इफ़ेक्ट्स चलाए।

ऐसी प्रस्तुति उपयोग करें जिसमें पहले से ही शैप एनीमेशन और स्लाइड ट्रांज़िशन हों ताकि इन सेटिंग्स का प्रभाव देखा जा सके। इन्हें सक्षम करने से उन स्लाइड्स में नए इफ़ेक्ट नहीं जुड़ते जिनमें कोई इफ़ेक्ट नहीं है। निर्यात के बाद, जेनरेट किए गए HTML5 दस्तावेज़ को ब्राउज़र में खोलें और समर्थन फ़ाइलें उपलब्ध रखें।

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **टिप्पणियों के साथ एक प्रस्तुति को HTML5 दस्तावेज़ में बदलें**

आप HTML5 आउटपुट में मौजूदा स्लाइड टिप्पणी शामिल कर सकते हैं ताकि पाठक स्लाइड सामग्री के साथ फीडबैक देख सकें। इस सेक्शन का उदाहरण स्रोत प्रस्तुति में टिप्पणी होने की अपेक्षा करता है, जैसा कि नीचे दर्शाया गया है। यह उन टिप्पणियों को निर्यात करता है; नई टिप्पणी नहीं बनाता।

![प्रस्तुति स्लाइड पर दो टिप्पणी](two_comments_pptx.png)

एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) ऑब्जेक्ट को [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) प्रॉपर्टी में असाइन करें [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) के। [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) को `RIGHT` पर सेट करें [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) एनेमरेशन से ताकि टिप्पणी प्रत्येक स्लाइड के दाएँ तरफ रखी जा सके।

निम्न उदाहरण इस टिप्पणी लेआउट के साथ प्रस्तुति को HTML5 में निर्यात करता है। टिप्पणी के बिना प्रस्तुति में प्रदर्शित करने के लिए कोई टिप्पणी टेक्स्ट नहीं होगा।

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

नीचे चित्र में निर्यात किए गए HTML5 दस्तावेज़ में स्लाइड के बगल में टिप्पणियां दिखायी गई हैं।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणी](two_comments_html5.png)

## **निर्यात के दौरान जावास्क्रिप्ट हाइपरलिंक को बाहर रखें**

मान लीजिए `hyperlinks.pptx` में लिंक्ड टेक्स्ट है जिसका लक्ष्य `javascript:alert('Hello')` है और एक सामान्य `https://example.com/` लिंक है। निर्यात के दौरान जावास्क्रिप्ट हाइपरलिंक को बाहर रखने के लिए, [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) को `True` पर सेट करें। डिफ़ॉल्ट रूप से यह `False` है, इसलिए इन लिंक को फ़िल्टर करने के लिए आपको विकल्प सक्षम करना पड़ेगा।

निम्न उदाहरण कार्य निर्देशिका से प्रस्तुति लोड करता है और [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) का उपयोग करके निर्यात करता है:

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

निर्यात फ़ाइल जावास्क्रिप्ट हाइपरलिंक को छोड़ देती है जबकि उसका टेक्स्ट और सामान्य HTTPS लिंक बरकरार रहता है। स्रोत प्रस्तुति अपरिवर्तित रहती है।

यह विकल्प जावास्क्रिप्ट हाइपरलिंक को फ़िल्टर करता है; यह सभी स्क्रिप्ट या अन्य सक्रिय सामग्री को नहीं हटाता, न ही यह CSP अनुपालन की गारंटी देता है। उदाहरण के लिए, HTML5 आउटपुट में अभी भी स्लाइड नेविगेशन और एनीमेशन के लिए स्क्रिप्ट शामिल होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं HTML5 में ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन के प्ले होने को नियंत्रित कर सकता हूँ?**

हाँ, HTML5 निर्यात में अलग‑अलग विकल्प उपलब्ध हैं जो [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) और [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) को सक्षम या अक्षम कर सकते हैं।

**क्या टिप्पणियाँ समर्थित हैं, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**

हाँ, मौजूदा टिप्पणियों को HTML5 आउटपुट में शामिल किया जा सकता है और उन्हें (उदाहरण के रूप में, स्लाइड के दाईं ओर) [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) के माध्यम से स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से जावास्क्रिप्ट चलाने वाले लिंक को स्किप कर सकता हूँ?**

हाँ, [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) सेटिंग आपको सहेजते समय जावास्क्रिप्ट कॉल वाले हाइपरलिंक को स्किप करने की अनुमति देती है। डिफ़ॉल्ट रूप से यह `False` है। देखें [Exclude JavaScript Hyperlinks During Export](/slides/hi/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) में HTML5 निर्यात उदाहरण और फ़िल्टर का दायरा। यह सेटिंग HTML5 व्यूअर द्वारा नेविगेशन और एनीमेशन के लिए उपयोग किए जाने वाले जावास्क्रिप्ट को नहीं हटाती।