---
title: प्रस्तुतीकरण को .NET में HTML5 में बदलें
linktitle: प्रस्तुति को HTML5 में
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
- PPT को HTML5 के रूप में सहेजें
- PPTX को HTML5 के रूप में सहेजें
- ODP को HTML5 के रूप में सहेजें
- PPT को HTML5 में निर्यात करें
- PPTX को HTML5 में निर्यात करें
- ODP को HTML5 में निर्यात करें
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों को उत्तरदायी HTML5 में निर्यात करें। स्वरूपण, एनीमेशन और इंटरैक्टिविटी को बनाए रखें।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में कैसे बदलना है। यह वेब एक्सटेंशन या अतिरिक्त निर्भरताओं के बिना बेसिक HTML5 निर्यात को कवर करता है, साथ ही शैप एनीमेशन और स्लाइड ट्रांज़िशन को नियंत्रित करने के विकल्प भी देता है। लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया को भी दिखाता है, स्लाइड व्यू मोड में HTML5 आउटपुट जेनरेट करने की व्याख्या करता है, और लेआउट कॉन्फ़िगर करके निर्यातित दस्तावेज़ में टिप्पणियों को शामिल करने का प्रदर्शन करता है।

## **PowerPoint को HTML5 में निर्यात करें**

यह C# कोड दिखाता है कि कैसे आप वेब एक्सटेंशन और निर्भरताओं के बिना प्रस्तुति को HTML5 में निर्यात कर सकते हैं:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 
इस मामले में आपको साफ़ HTML मिलता है। 
{{% /alert %}}

आप इस प्रकार शैप एनीमेशन और स्लाइड ट्रांज़िशन के लिए सेटिंग्स निर्दिष्ट करना चाह सकते हैं:

```c#
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

यह C# मानक PowerPoint‑to‑HTML प्रक्रिया को दर्शाता है:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

इस मामले में प्रस्तुति सामग्री SVG के माध्यम से इस रूप में रेंडर की जाती है:

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
जब आप इस विधि से PowerPoint को HTML में निर्यात करते हैं, तो SVG रेंडरिंग के कारण आप विशिष्ट तत्वों पर स्टाइल लागू नहीं कर पाएँगे या एनीमेट नहीं कर पाएँगे। 
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

**Aspose.Slides** आपको PowerPoint प्रस्तुति को एक HTML5 दस्तावेज़ में बदलने की अनुमति देता है जिसमें स्लाइड्स स्लाइड व्यू मोड में प्रस्तुत होती हैं। इस स्थिति में, जब आप उत्पन्न HTML5 फ़ाइल को ब्राउज़र में खोलते हैं, तो आप वेब पेज पर स्लाइड व्यू मोड में प्रस्तुति देखेंगे। 

यह C# कोड PowerPoint‑to‑HTML5 स्लाइड व्यू निर्यात प्रक्रिया दर्शाता है:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **टिप्पणियों के साथ प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करें**

PowerPoint में टिप्पणियाँ एक उपकरण हैं जो उपयोगकर्ताओं को प्रस्तुति स्लाइड्स पर नोट्स या फीडबैक छोड़ने की सुविधा देती हैं। ये सहयोगी प्रोजेक्ट्स में विशेष रूप से उपयोगी हैं, जहाँ कई लोग मुख्य सामग्री को बदले बिना विशिष्ट स्लाइड तत्वों पर अपनी सुझाव या टिप्पणी जोड़ सकते हैं। प्रत्येक टिप्पणी लेखक का नाम दिखाती है, जिससे यह पता लगाना आसान होता है कि टिप्पणी किसने छोड़ी।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल में निम्नलिखित PowerPoint प्रस्तुति सहेजी गई है।

![प्रस्तुति स्लाइड पर दो टिप्पणियाँ](two_comments_pptx.png)

जब आप PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में बदलते हैं, तो आप आसानी से यह निर्दिष्ट कर सकते हैं कि क्या प्रस्तुति की टिप्पणियाँ आउटपुट दस्तावेज़ में शामिल होंगी। ऐसा करने के लिए, आपको `NotesCommentsLayouting` प्रॉपर्टी में टिप्पणियों के प्रदर्शन पैरामीटर को [Html5Options](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/) क्लास के भीतर निर्दिष्ट करना होगा।

```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
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

**क्या मैं यह नियंत्रित कर सकता हूँ कि ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन HTML5 में चलेंगे?**

हाँ, HTML5 अलग‑अलग विकल्प प्रदान करता है जो [shape animations](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/animateshapes/) और [slide transitions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/animatetransitions/) को सक्षम या अक्षम करने के लिए हैं।

**क्या टिप्पणियों का आउटपुट समर्थित है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**

हाँ, टिप्पणियों को HTML5 में जोड़ा जा सकता है और नोट्स एवं टिप्पणियों के लिए [layout settings](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/notescommentslayouting/) के माध्यम से (उदाहरण के लिए, स्लाइड के दाएँ) स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को छोड़ सकता हूँ?**

हाँ, एक [setting](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) है जो सहेजते समय JavaScript कॉल वाले हाइपरलिंक को छोड़ने की अनुमति देता है। यह कड़ी सुरक्षा नीतियों के अनुपालन में मदद करता है।