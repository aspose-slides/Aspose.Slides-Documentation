---
title: ".NET में प्रस्तुतियों को HTML5 में परिवर्तित करें"
linktitle: "प्रस्तुति को HTML5 में"
type: docs
weight: 40
url: /hi/net/export-to-html5/
keywords:
- "PowerPoint को HTML5 में"
- "OpenDocument को HTML5 में"
- "प्रस्तुति को HTML5 में"
- "स्लाइड को HTML5 में"
- "PPT को HTML5 में"
- "PPTX को HTML5 में"
- "ODP को HTML5 में"
- "PPT को HTML5 के रूप में सहेजें"
- "PPTX को HTML5 के रूप में सहेजें"
- "ODP को HTML5 के रूप में सहेजें"
- "PPT को HTML5 में निर्यात करें"
- "PPTX को HTML5 में निर्यात करें"
- "ODP को HTML5 में निर्यात करें"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को उत्तरदायी HTML5 में निर्यात करें। स्वरूपण, एनीमेशन और इंटरैक्टिविटी को बरकरार रखें।"
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में परिवर्तित करने के बारे में बताता है। यह बुनियादी HTML5 निर्यात, साथ ही आकार एनीमेशन और स्लाइड ट्रांज़िशन को नियंत्रित करने के विकल्पों को कवर करता है। लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया दिखाता है, स्लाइड व्यू मोड में HTML5 आउटपुट उत्पन्न करने की विधि समझाता है, और लेआउट को कॉन्फ़िगर करके निर्यात दस्तावेज़ में टिप्पणियों को शामिल करने का प्रदर्शन करता है।

## **PowerPoint को HTML5 में निर्यात करें**

यह C# कोड दर्शाता है कि प्रस्तुति को HTML5 में कैसे निर्यात किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
HTML दस्तावेज़ के अलावा, निर्यात उन सहायक फाइलों को भी लिखता है जिनका वह संदर्भ लेता है: `pres.css`, `master.css`, `animation.js`, `effects.js`, और `navigation.js`। उत्पन्न पृष्ठ सार्वजनिक CDN‑से jQuery और Anime.js भी लोड करता है; इनके बिना स्लाइड नेविगेशन और एनीमेशन कार्य नहीं करेंगे। 
{{% /alert %}}

आप आकार एनीमेशन और स्लाइड ट्रांज़िशन के लिए सेटिंग्स इस प्रकार निर्दिष्ट कर सकते हैं:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **PowerPoint को HTML में निर्यात करें**

यह C# मानक PowerPoint‑to‑HTML प्रक्रिया को प्रदर्शित करता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

इस मामले में, प्रस्तुति की सामग्री SVG के माध्यम से इस प्रकार रेंडर की जाती है:

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
जब आप इस विधि से PowerPoint को HTML में निर्यात करते हैं, तो SVG रेंडरिंग के कारण आप विशिष्ट तत्वों पर शैली लागू नहीं कर पाएँगे या एनीमेट नहीं कर पाएँगे। 
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

**Aspose.Slides** आपको PowerPoint प्रस्तुति को ऐसे HTML5 दस्तावेज़ में बदलने की सुविधा देता है जहाँ स्लाइड्स स्लाइड व्यू मोड में प्रदर्शित होती हैं। इस स्थिति में, जब आप परिणामी HTML5 फ़ाइल को ब्राउज़र में खोलते हैं, तो आप वेब पेज पर स्लाइड व्यू मोड में प्रस्तुति देख सकते हैं। 

यह C# कोड PowerPoint‑to‑HTML5 स्लाइड व्यू निर्यात प्रक्रिया को दर्शाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **टिप्पणियों के साथ एक प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करें**

PowerPoint में टिप्पणियाँ उपयोगकर्ताओं को स्लाइड्स पर नोट्स या फ़ीडबैक छोड़ने का साधन प्रदान करती हैं। ये सहयोगी परियोजनाओं में विशेष रूप से उपयोगी हैं, जहाँ कई लोग मुख्य सामग्री बदले बिना विशिष्ट स्लाइड तत्वों पर अपने सुझाव या टिप्पणी जोड़ सकते हैं। प्रत्येक टिप्पणी में लेखक का नाम दिखाया जाता है, जिससे यह पता लगाना आसान हो जाता है कि टिप्पणी किसने छोड़ी।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल में निम्नलिखित PowerPoint प्रस्तुति संग्रहीत है।

![प्रेजेंटेशन स्लाइड पर दो टिप्पणियाँ](two_comments_pptx.png)

जब आप PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में बदलते हैं, तो आप आसानी से यह निर्धारित कर सकते हैं कि आउटपुट दस्तावेज़ में प्रस्तुति की टिप्पणियाँ शामिल होंगी या नहीं। ऐसा करने के लिए आपको `[Html5Options](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/)` क्लास की `NotesCommentsLayouting` प्रॉपर्टी में टिप्पणियों के प्रदर्शन पैरामीटर निर्दिष्ट करने होंगे।

निम्नलिखित कोड उदाहरण स्लाइड्स के दाईं ओर टिप्पणियों के साथ प्रस्तुति को HTML5 दस्तावेज़ में बदलता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

"output.html" दस्तावेज़ नीचे की छवि में दिखाया गया है।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं HTML5 में ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन के प्ले होने को नियंत्रित कर सकता हूँ?

हाँ, HTML5 अलग‑अलग विकल्प प्रदान करता है ताकि आप [shape animations](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/animateshapes/) और [slide transitions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/animatetransitions/) को सक्षम या अक्षम कर सकें।

### क्या टिप्पणियों का आउटपुट समर्थित है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?

हाँ, HTML5 में टिप्पणियाँ जोड़ी जा सकती हैं और उन्हें स्लाइड के दाईं ओर जैसे स्थानों पर [layout settings](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/notescommentslayouting/) के माध्यम से स्थित किया जा सकता है।

### क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को स्किप कर सकता हूँ?

हाँ, एक [setting](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) है जो आपको सहेजते समय JavaScript कॉल वाले हाइपरलिंक्स को स्किप करने की अनुमति देता है। यह सख्त सुरक्षा नीतियों के अनुपालन में मदद करता है।