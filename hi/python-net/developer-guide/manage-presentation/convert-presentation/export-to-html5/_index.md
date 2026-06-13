---
title: Python में प्रस्तुतियों को HTML5 में परिवर्तित करें
linktitle: HTML5 में निर्यात करें
type: docs
weight: 40
url: /hi/python-net/export-to-html5/
keywords:
- PowerPoint से HTML5
- OpenDocument से HTML5
- प्रस्तुति से HTML5
- स्लाइड से HTML5
- PPT से HTML5
- PPTX से HTML5
- ODP से HTML5
- PowerPoint को परिवर्तित करें
- OpenDocument को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- HTML5 निर्यात
- प्रस्तुति निर्यात
- स्लाइड निर्यात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों को उत्तरदायी HTML5 में निर्यात करें। स्वरूपण, एनीमेशन और इंटरैक्टिविटी को संरक्षित रखें।"
---
## **परिचय**

यह लेख बताता है कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में कैसे परिवर्तित किया जाए। यह वेब एक्सटेंशन या अतिरिक्त निर्भरताओं के बिना बुनियादी HTML5 निर्यात, तथा आकार एनीमेशन और स्लाइड ट्रांज़िशन को नियंत्रित करने के विकल्पों को कवर करता है। लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया भी दिखाता है, स्लाइड व्यू मोड में HTML5 आउटपुट कैसे उत्पन्न किया जाए समझाता है, और निर्यातित दस्तावेज़ में टिप्पणी को उनके लेआउट को कॉन्फ़िगर करके कैसे शामिल किया जाए दर्शाता है।

## **PowerPoint को HTML5 में निर्यात करें**

यह Python कोड दिखाता है कि आप वेब एक्सटेंशन और निर्भरताओं के बिना प्रस्तुति को HTML5 में कैसे निर्यात कर सकते हैं:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
इस मामले में, आपको साफ़ HTML प्राप्त होता है। 
{{% /alert %}}

आप इस प्रकार आकार एनीमेशन और स्लाइड ट्रांज़िशन के सेटिंग्स निर्दिष्ट कर सकते हैं:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **PowerPoint को HTML में निर्यात करें**

यह Python कोड मानक PowerPoint से HTML निर्यात प्रक्रिया को प्रदर्शित करता है:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
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
जब आप इस विधि का उपयोग करके PowerPoint को HTML में निर्यात करते हैं, SVG रेंडरिंग के कारण, आप विशिष्ट तत्वों पर स्टाइल लागू नहीं कर पाएंगे या एनीमेट नहीं कर पाएंगे। 
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

**Aspose.Slides** आपको PowerPoint प्रस्तुति को एक HTML5 दस्तावेज़ में परिवर्तित करने की अनुमति देता है जिसमें स्लाइड्स स्लाइड व्यू मोड में प्रदर्शित होती हैं। इस स्थिति में, जब आप परिणामी HTML5 फ़ाइल को ब्राउज़र में खोलते हैं, तो आप वेब पेज पर स्लाइड व्यू मोड में प्रस्तुति देखते हैं। 

यह Python कोड PowerPoint से HTML5 स्लाइड व्यू निर्यात प्रक्रिया को प्रदर्शित करता है:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # स्लाइड ट्रांज़िशन, एनीमेशन और आकार एनीमेशन वाली प्रस्तुति को HTML5 में निर्यात करें
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # प्रस्तुति सहेजें
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **टिप्पणियों के साथ प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करें**

PowerPoint में टिप्पणियाँ एक उपकरण हैं जो उपयोगकर्ताओं को प्रस्तुति स्लाइड्स पर नोट्स या प्रतिक्रिया छोड़ने की अनुमति देती हैं। वे सहयोगी परियोजनाओं में विशेष रूप से उपयोगी होती हैं, जहाँ कई लोग मुख्य सामग्री को बदले बिना विशिष्ट स्लाइड तत्वों में अपने सुझाव या टिप्पणी जोड़ सकते हैं। प्रत्येक टिप्पणी लेखक का नाम दिखाती है, जिससे यह ट्रैक करना आसान हो जाता है कि टिप्पणी किसने छोड़ी।  

मान लीजिए हमारे पास निम्नलिखित PowerPoint प्रस्तुति "sample.pptx" फ़ाइल में सहेजी गई है।

![प्रस्तुति स्लाइड पर दो टिप्पणियां](two_comments_pptx.png)

जब आप PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करते हैं, तो आप आसानी से यह निर्दिष्ट कर सकते हैं कि आउटपुट दस्तावेज़ में प्रस्तुति की टिप्पणियाँ शामिल की जाएँ या नहीं। इसके लिए आपको टिप्पणी के प्रदर्शन पैरामीटर को `notes_comments_layouting` प्रॉपर्टी में [Html5Options](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/html5options/) क्लास के तहत निर्दिष्ट करना होगा।  

निम्नलिखित कोड उदाहरण एक प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करता है जिसमें टिप्पणियाँ स्लाइड्स के दाईं ओर प्रदर्शित होती हैं।  
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

"output.html" दस्तावेज़ नीचे की छवि में दिखाया गया है।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह नियंत्रित कर सकता हूँ कि ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन HTML5 में चलेंगे या नहीं?**  

हाँ, HTML5 में अलग-अलग विकल्प उपलब्ध हैं जो आपको [shape animations](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/html5options/animate_shapes/) और [slide transitions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/html5options/animate_transitions/) को-enabled या -disabled करने की अनुमति देते हैं।

**क्या टिप्पणी आउटपुट समर्थित है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**  

हाँ, टिप्पणियों को HTML5 में जोड़ा जा सकता है और नोट्स और टिप्पणियों के लिए [layout settings](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/html5options/notes_comments_layouting/) के माध्यम से (उदाहरण के लिए, स्लाइड के दाईं ओर) स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को छोड़ सकता हूँ?**  

हाँ, एक [setting](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/html5options/skip_java_script_links/) है जो सहेजते समय JavaScript कॉल वाले हाइपरलिंक को छोड़ने की अनुमति देता है। यह कड़ी सुरक्षा नीतियों का पालन करने में मदद करता है।