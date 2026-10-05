---
title: .NET में प्रस्तुतियों को HTML5 में बदलें
linktitle: प्रस्तुति को HTML5
type: docs
weight: 40
url: /hi/net/export-to-html5/
keywords:
- PowerPoint को HTML5 में
- OpenDocument को HTML5 में
- प्रस्तुति को HTML5 में
- स्लाइड को HTML5 में
- PPT को HTML5 में
- PPTX को HTML5 में
- ODP को HTML5 में
- PPT को HTML5 के रूप में संग्रहीत करें
- PPTX को HTML5 के रूप में संग्रहीत करें
- ODP को HTML5 के रूप में संग्रहीत करें
- PPT को HTML5 में निर्यात करें
- PPTX को HTML5 में निर्यात करें
- ODP को HTML5 में निर्यात करें
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों को उत्तरदायी HTML5 में निर्यात करें। फ़ॉर्मेटिंग, एनीमेशन और इंटरैक्टिविटी को बनाए रखें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET का उपयोग करके PowerPoint प्रेजेंटेशन को HTML5 में बदलने के बारे में समझाता है। यह मूल निर्यात, आकार एनिमेशन और स्लाइड ट्रांज़ीशन के नियंत्रण, तथा टिप्पणी लेआउट को कवर करता है। यह मानक HTML निर्यात के SVG-आधारित आउटपुट की तुलना में HTML5 आउटपुट की तुलना भी करता है।

## **PowerPoint को HTML5 में निर्यात करें**

निम्नलिखित उदाहरण कार्य निर्देशिका से एक प्रेजेंटेशन लोड करता है और उसे HTML5 फ़ॉर्मेट में सहेजता है। यह डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करता है; अगला उदाहरण स्पष्ट रूप से एनिमेशन प्लेबैक को नियंत्रित करने का तरीका दिखाता है। इनपुट पथ को अपने प्रेजेंटेशन के पथ से बदलें।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
HTML दस्तावेज़ के अलावा, निर्यात स्लाइड स्टाइलिंग, एनिमेशन, इफेक्ट्स और नेविगेशन के लिए समर्थन करने वाली CSS और JavaScript फाइलें भी लिखता है। आउटपुट को स्थानांतरित या प्रकाशित करते समय इन फ़ाइलों को HTML दस्तावेज़ के साथ रखें। उत्पन्न पृष्ठ सार्वजनिक CDN से jQuery और Anime.js भी लोड करता है; इनके बिना स्लाइड नेविगेशन और एनीमेशन काम नहीं करते।
{{% /alert %}}

आकार एनिमेशन या स्लाइड ट्रांज़ीशन को चलाए बिना निर्यात करने के लिए, [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) और [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) को `false` पर सेट करें [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/)。 ये सेटिंग्स स्वतंत्र हैं, इसलिए आप एक को सक्षम करते हुए दूसरे को अक्षम कर सकते हैं। उदाहरण में दोनों प्रकार के एनिमेशन को अक्षम करके प्रेजेंटेशन को निर्यात किया गया है。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```
## **PowerPoint को HTML में निर्यात करें**

स्टैंडर्ड HTML निर्यात एक अलग रेंडरिंग पद्धति का उपयोग करता है: स्लाइड सामग्री को HTML पृष्ठ के भीतर SVG के रूप में दर्शाया जाता है। निम्नलिखित उदाहरण इस रेंडरिंग पद्धति का उपयोग करके प्रेजेंटेशन को HTML दस्तावेज़ में बदलता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

नीचे दिया गया सरल मार्कअप उत्पन्न पृष्ठ की संरचना को दर्शाता है। SVG तत्व में रेंडर की गई स्लाइड सामग्री होती है; प्लेसहोल्डर टेक्स्ट उस सामग्री को दर्शाता है और यह वास्तविक निर्यात आउटपुट नहीं है。

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
SVG-आधारित निर्यात PowerPoint आकारों को व्यक्तिगत HTML तत्वों के रूप में नहीं दिखाता है। जब आपको इस लेख में दर्शाए गए आकार-एनिमेशन और स्लाइड-ट्रांज़ीशन विकल्पों की आवश्यकता हो तो HTML5 निर्यात का उपयोग करें।
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड दृश्य में निर्यात करें**

HTML5 निर्यात एक पृष्ठ उत्पन्न करता है जो ब्राउज़र में प्रेजेंटेशन स्लाइडों को देखने और नेविगेट करने के लिए उपयोग होता है। यह उदाहरण दोनों [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) और [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) को सक्षम करता है ताकि निर्यातित स्लाइड दृश्य स्रोत प्रेजेंटेशन के इफेक्ट्स को चलाए।

इन सेटिंग्स का प्रभाव देखने के लिए ऐसे प्रेजेंटेशन का उपयोग करें जिसमें पहले से ही आकार एनिमेशन और स्लाइड ट्रांज़ीशन हों। इन्हें सक्रिय करने से उन स्लाइडों में नए इफ़ेक्ट नहीं जुड़ते जिनमें पहले से कोई नहीं था। निर्यात के बाद, उत्पन्न HTML5 दस्तावेज़ को ब्राउज़र में खोलें और उसकी समर्थन फाइलें उपलब्ध रखें।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **टिप्पणियों के साथ प्रेजेंटेशन को HTML5 दस्तावेज़ में बदलें**

आप मौजूदा स्लाइड टिप्पणी को HTML5 आउटपुट में शामिल कर सकते हैं ताकि पाठक स्लाइड सामग्री के साथ फीडबैक देख सकें। इस भाग में दिया गया उदाहरण यह मानता है कि स्रोत प्रेजेंटेशन में टिप्पणी मौजूद हैं, जैसा कि नीचे दिखाया गया है। यह टिप्पणी को निर्यात करता है; नई टिप्पणी नहीं बनाता।

![प्रेजेंटेशन स्लाइड पर दो टिप्पणियां](two_comments_pptx.png)

एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) ऑब्जेक्ट को [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) प्रॉपर्टी के साथ [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) में असाइन करें। प्रत्येक स्लाइड के दाईं ओर टिप्पणी रखने के लिए [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) एनीमरेशन से `Right` मान के साथ [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) सेट करें।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

नीचे की छवि निर्यातित HTML5 दस्तावेज़ को दर्शाती है जिसमें स्लाइड के बगल में टिप्पणियां प्रदर्शित होती हैं।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **निर्यात के दौरान JavaScript हाइपरलिंक को बाहर रखें**

मान लें कि `hyperlinks.pptx` में `javascript:alert('Hello')` लक्ष्य वाला लिंक्ड टेक्स्ट और एक सामान्य `https://example.com/` लिंक मौजूद है। निर्यात के दौरान JavaScript हाइपरलिंक को बाहर रखने के लिए, [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) को `true` पर सेट करें। डिफ़ॉल्ट `false` है, इसलिए ये लिंक तब तक फ़िल्टर नहीं होते जब तक आप विकल्प सक्रिय नहीं करते।

निम्नलिखित उदाहरण कार्य निर्देशिका से प्रेजेंटेशन लोड करता है और इसे [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) का उपयोग करके निर्यात करता है：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

निर्यातित फ़ाइल JavaScript हाइपरलिंक को हटाती है जबकि उसका टेक्स्ट और सामान्य HTTPS लिंक बरकरार रहता है। स्रोत प्रेजेंटेशन अपरिवर्तित रहता है।

यह विकल्प JavaScript हाइपरलिंक को फ़िल्टर करता है; यह सभी स्क्रिप्ट या अन्य सक्रिय सामग्री को नहीं हटाता, न ही यह CSP अनुपालन की गारंटी देता है। उदाहरण के लिए, HTML5 आउटपुट में अभी भी स्लाइड नेविगेशन और एनिमेशन के लिए स्क्रिप्ट शामिल हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियंत्रित कर सकता हूँ कि ऑब्जेक्ट एनिमेशन और स्लाइड ट्रांज़ीशन HTML5 में चलेंगे या नहीं?**

हाँ, HTML5 निर्यात अलग-अलग विकल्प प्रदान करता है जिससे आप [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) और [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) को सक्षम या अक्षम कर सकते हैं।

**क्या टिप्पणियों को सपोर्ट किया जाता है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**

हाँ, मौजूदा टिप्पणियों को HTML5 आउटपुट में शामिल किया जा सकता है और नोट्स तथा टिप्पणियों के लिए [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) के माध्यम से (उदाहरण के लिए, स्लाइड के दाईं ओर) स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को छोड़ सकता हूँ?**

हाँ, [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) सेटिंग आपको सहेजते समय JavaScript कॉल वाले हाइपरलिंक को छोड़ने की अनुमति देती है। डिफ़ॉल्ट `false` है। सरल HTML, HTML5, और PDF निर्यात उदाहरण और फ़िल्टर के दायरे के लिए [Exclude JavaScript Hyperlinks During Export](/slides/hi/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) देखें। यह सेटिंग HTML5 व्यूयर द्वारा नेविगेशन और एनिमेशन के लिए उपयोग किए जाने वाले JavaScript को नहीं हटाती।