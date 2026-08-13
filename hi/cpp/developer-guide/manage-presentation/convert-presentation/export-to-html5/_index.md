---
title: C++ में प्रस्तुतियों को HTML5 में बदलें
linktitle: प्रस्तुति को HTML5 में
type: docs
weight: 40
url: /hi/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों को उत्तरदायी HTML5 में निर्यात करें। फ़ॉर्मेटिंग, एनिमेशन और इंटरैक्टिविटी को संरक्षित रखें।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में कैसे बदलें। यह वेब एक्सटेंशन या अतिरिक्त निर्भरताओं के बिना बुनियादी HTML5 निर्यात, साथ ही आकृति एनिमेशन और स्लाइड ट्रांज़िशन को नियंत्रित करने के विकल्प कवर करता है। लेख मानक PowerPoint‑to‑HTML निर्यात प्रक्रिया भी दिखाता है, स्लाइड व्यू मोड में HTML5 आउटपुट कैसे उत्पन्न करें समझाता है, और लेआउट कॉन्फ़िगर करके निर्यात दस्तावेज़ में टिप्पणियों को शामिल करने का प्रदर्शन करता है।

## **PowerPoint को HTML5 में निर्यात करें**

यह C++ कोड दिखाता है कि प्रस्तुति को HTML5 में कैसे निर्यात किया जाए।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
इस मामले में आपको साफ़ HTML मिलता है। 
{{% /alert %}}

आप आकृति एनिमेशन और स्लाइड ट्रांज़िशन के लिए सेटिंग्स इस प्रकार निर्दिष्ट कर सकते हैं:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **PowerPoint को HTML में निर्यात करें**

यह C++ मानक PowerPoint‑to‑HTML प्रक्रिया को दर्शाता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
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
जब आप इस विधि से PowerPoint को HTML में निर्यात करते हैं, तो SVG रेंडरिंग के कारण आप विशिष्ट तत्वों पर शैली लागू नहीं कर पाएंगे या उन्हें एनीमेट नहीं कर पाएंगे। 
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

**Aspose.Slides** आपको PowerPoint प्रस्तुति को एक HTML5 दस्तावेज़ में बदलने की अनुमति देता है जिसमें स्लाइड्स स्लाइड व्यू मोड में प्रस्तुत की जाती हैं। इस मामले में, जब आप ब्राउज़र में उत्पन्न HTML5 फ़ाइल खोलते हैं, तो आप वेब पेज पर स्लाइड व्यू मोड में प्रस्तुति देखते हैं। 

यह C++ कोड PowerPoint‑to‑HTML5 स्लाइड व्यू निर्यात प्रक्रिया को दर्शाता है:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **टिप्पणियों के साथ प्रस्तुति को HTML5 दस्तावेज़ में बदलें**

PowerPoint में टिप्पणियाँ एक उपकरण हैं जो उपयोगकर्ताओं को स्लाइड्स पर नोट्स या प्रतिक्रिया छोड़ने की अनुमति देता है। ये विशेषकर सहयोगी परियोजनाओं में उपयोगी होती हैं, जहाँ कई लोग मुख्य सामग्री को बदले बिना विशिष्ट स्लाइड तत्वों पर अपने सुझाव या टिप्पणी जोड़ सकते हैं। प्रत्येक टिप्पणी में लेखक का नाम दिखता है, जिससे यह पता चलना आसान हो जाता है कि टिप्पणी किसने छोड़ी।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल में निम्नलिखित PowerPoint प्रस्तुति सहेजी गई है।

![Two comments on the presentation slide](two_comments_pptx.png)

जब आप PowerPoint प्रस्तुति को HTML5 दस्तावेज़ में बदलते हैं, तो आप आसानी से तय कर सकते हैं कि क्या आउटपुट दस्तावेज़ में प्रस्तुति की टिप्पणियों को शामिल किया जाए। ऐसा करने के लिए आपको टिप्पणियों के प्रदर्शन पैरामीटर `get_NotesCommentsLayouting` मेथड में [Html5Options](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/) वर्ग के भीतर निर्दिष्ट करने चाहिए।

निम्नलिखित कोड उदाहरण स्लाइड्स के दाहिनी ओर टिप्पणी प्रदर्शित करके प्रस्तुति को HTML5 दस्तावेज़ में बदलता है।
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

नीचे की छवि में "output.html" दस्तावेज़ दिखाया गया है।

![The comments in the output HTML5 document](two_comments_html5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं HTML5 में ऑब्जेक्ट एनिमेशन और स्लाइड ट्रांज़िशन को चलने या न चलने पर नियंत्रण रख सकता हूँ?

हाँ, HTML5 में अलग‑अलग विकल्प उपलब्ध हैं जिससे आप [shape animations](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/set_animateshapes/) और [slide transitions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/set_animatetransitions/) को सक्षम या अक्षम कर सकते हैं।

### क्या टिप्पणी आउटपुट समर्थित है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?

हाँ, टिप्पणियों को HTML5 में जोड़ा जा सकता है और नोट्स एवं टिप्पणियों के लेआउट सेटिंग्स के माध्यम से (उदाहरण के लिए, स्लाइड के दाहिनी ओर) स्थित किया जा सकता है।

### क्या मैं सुरक्षा या CSP कारणों से JavaScript कॉल करने वाले लिंक को छोड़ सकता हूँ?

हाँ, एक [setting](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) उपलब्ध है जो सहेजने के दौरान JavaScript कॉल वाले हाइपरलिंक को छोड़ने की अनुमति देता है। यह कड़े सुरक्षा नीतियों का पालन करने में मदद करता है।