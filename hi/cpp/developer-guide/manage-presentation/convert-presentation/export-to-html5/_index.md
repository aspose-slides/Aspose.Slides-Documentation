---
title: C++ में प्रस्तुतियों को HTML5 में परिवर्तित करें
linktitle: प्रस्तुति को HTML5 में
type: docs
weight: 40
url: /hi/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों को रिस्पॉन्सिव HTML5 में निर्यात करें। फॉर्मेटिंग, एनिमेशन और इंटरैक्टिविटी को संरक्षित रखें।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में कैसे बदला जाए। यह वेब एक्सटेंशन या अतिरिक्त निर्भरताओं के बिना बुनियादी HTML5 निर्यात, साथ ही आकार एनिमेशन और स्लाइड ट्रांज़िशन को नियंत्रित करने के विकल्पों को कवर करता है। लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया को भी दर्शाता है, स्लाइड व्यू मोड में HTML5 आउटपुट उत्पन्न करने की समझ देता है, और निर्यात किए गए दस्तावेज़ में टिप्पणी लेआउट को कॉन्फ़िगर करके टिप्पणी शामिल करने का प्रदर्शन करता है।

## **PowerPoint को HTML5 में निर्यात करें**

यह C++ कोड दर्शाता है कि आप प्रस्तुति को HTML5 में कैसे निर्यात कर सकते हैं।

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 
इस मामले में, आपको स्वच्छ HTML प्राप्त होगा। 
{{% /alert %}}

आप इस प्रकार आकार एनिमेशन और स्लाइड ट्रांज़िशन की सेटिंग्स निर्दिष्ट करना चाह सकते हैं:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **PowerPoint को HTML में निर्यात करें**

यह C++ मानक PowerPoint से HTML निर्यात प्रक्रिया को दर्शाता है:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
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
जब आप इस विधि से PowerPoint को HTML में निर्यात करते हैं, तो SVG रेंडरिंग के कारण आप विशिष्ट तत्वों पर स्टाइल लागू नहीं कर पाएँगे या उन्हें एनीमेट नहीं कर पाएँगे। 
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

**Aspose.Slides** आपको PowerPoint प्रस्तुति को एक HTML5 दस्तावेज़ में बदलने की अनुमति देता है जिसमें स्लाइडें स्लाइड व्यू मोड में प्रस्तुत की जाती हैं। इस मामले में, जब आप परिणामस्वरूप HTML5 फ़ाइल को ब्राउज़र में खोलते हैं, तो आप वेब पेज पर स्लाइड व्यू मोड में प्रस्तुति देखते हैं।

यह C++ कोड PowerPoint से HTML5 स्लाइड व्यू निर्यात प्रक्रिया को दर्शाता है:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **टिप्पणियों के साथ प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करें**

PowerPoint में टिप्पणियाँ एक उपकरण हैं जो उपयोगकर्ताओं को स्लाइड नोट्स या फीडबैक छोड़ने की अनुमति देता है। ये सहयोगी परियोजनाओं में विशेष रूप से उपयोगी हैं, जहाँ कई लोग मुख्य सामग्री बदले बिना विशिष्ट स्लाइड तत्वों पर अपने सुझाव या टिप्पणी जोड़ सकते हैं। प्रत्येक टिप्पणी लेखक का नाम दिखाती है, जिससे यह पता लगाना आसान हो जाता है कि टिप्पणी किसने छोड़ी।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल में निम्नलिखित PowerPoint प्रस्तुति सहेजी हुई है।

![प्रस्तुति स्लाइड पर दो टिप्पणियाँ](two_comments_pptx.png)

जब आप PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में परिवर्तित करते हैं, तो आप आसानी से यह निर्धारित कर सकते हैं कि आउटपुट दस्तावेज़ में प्रस्तुति की टिप्पणी शामिल की जाएँ या नहीं। ऐसा करने के लिए, आपको `get_NotesCommentsLayouting` मेथड में टिप्पणी के प्रदर्शन पैरामीटर को [Html5Options](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/) क्लास में निर्दिष्ट करना होगा।

निम्नलिखित कोड उदाहरण प्रस्तुति को उन टिप्पणियों के साथ HTML5 दस्तावेज़ में बदलता है जो स्लाइड के दाईं ओर प्रदर्शित होती हैं।
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

"output.html" दस्तावेज़ नीचे दी गई छवि में दिखाया गया है।

![आउटपुट HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं HTML5 में ऑब्जेक्ट एनिमेशन और स्लाइड ट्रांज़िशन को चलाने की नियंत्रण कर सकता हूँ?**  
हां, HTML5 में [shape animations](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/set_animateshapes/) और [slide transitions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/set_animatetransitions/) को सक्षम या अक्षम करने के लिए अलग विकल्प उपलब्ध हैं।

**क्या टिप्पणियों का आउटपुट समर्थित है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**  
हां, टिप्पणियों को HTML5 में जोड़ा जा सकता है और नोट्स और टिप्पणियों की लेआउट सेटिंग्स के माध्यम से (उदाहरण के लिए, स्लाइड के दाईं ओर) स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक को स्किप कर सकता हूँ?**  
हां, एक [setting](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) उपलब्ध है जो सहेजने के दौरान JavaScript कॉल वाले हाइपरलिंक्स को स्किप करने की अनुमति देता है। यह कड़ी सुरक्षा नीतियों का पालन करने में मदद करता है।