---
title: C++ में प्रस्तुतियों को HTML5 में परिवर्तित करें
linktitle: प्रेजेंटेशन से HTML5
type: docs
weight: 40
url: /hi/cpp/export-to-html5/
keywords:
- PowerPoint से HTML5
- OpenDocument से HTML5
- प्रेजेंटेशन से HTML5
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
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument प्रस्तुतियों को रिस्पॉन्सिव HTML5 में निर्यात करें। फ़ॉर्मेटिंग, एनीमेशन और इंटरैक्टिविटी को संरक्षित रखें।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों को HTML5 में कैसे परिवर्तित किया जाता है। यह बुनियादी निर्यात, आकार एनीमेशन और स्लाइड ट्रांज़िशन के नियंत्रण, और टिप्पणी लेआउट को कवर करता है। यह मानक HTML निर्यात के SVG-आधारित आउटपुट की तुलना HTML5 आउटपुट से भी करता है।

## **PowerPoint को HTML5 में निर्यात करें**

निम्नलिखित उदाहरण कार्य निर्देशिका से एक प्रस्तुति लोड करता है और इसे HTML5 प्रारूप में सहेजता है। यह डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करता है; अगला उदाहरण स्पष्ट रूप से एनीमेशन प्लेबैक को नियंत्रित करने का तरीका दिखाता है। इनपुट पथ को अपनी प्रस्तुति के पथ से बदलें।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
HTML दस्तावेज़ के अलावा, निर्यात स्लाइड शैली, एनीमेशन, प्रभाव और नेविगेशन के लिए समर्थन करने वाली CSS और JavaScript फ़ाइलें लिखता है। आउटपुट को स्थानांतरित या प्रकाशित करते समय इन फ़ाइलों को HTML दस्तावेज़ के साथ रखें। उत्पन्न पृष्ठ भी सार्वजनिक CDN से jQuery और Anime.js लोड करता है; इनके बिना स्लाइड नेविगेशन और एनीमेशन काम नहीं करेंगे।
{{% /alert %}}

आकार एनीमेशन या स्लाइड ट्रांज़िशन को चलाए बिना निर्यात करने के लिए, [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) में [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) और [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) को `false` पास करें। ये सेटिंग्स स्वतंत्र हैं, इसलिए आप एक को सक्षम कर सकते हैं जबकि दूसरे को अक्षम कर सकते हैं। उदाहरण में दोनों प्रकार के एनीमेशन को अक्षम करके प्रस्तुति निर्यात की गई है।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **PowerPoint को HTML में निर्यात करें**

मानक HTML निर्यात एक अलग रेंडरिंग दृष्टिकोण का उपयोग करता है: स्लाइड सामग्री को HTML पृष्ठ के भीतर SVG द्वारा दर्शाया जाता है। निम्नलिखित उदाहरण इस रेंडरिंग दृष्टिकोण का उपयोग करके एक प्रस्तुति को HTML दस्तावेज़ में परिवर्तित करता है।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

नीचे दिया गया सरल मार्कअप उत्पन्न पृष्ठ की संरचना को दर्शाता है। SVG तत्व में रेंडर की गई स्लाइड सामग्री होती है; प्लेसहोल्डर टेक्स्ट उस सामग्री का प्रतिनिधित्व करता है और वास्तविक निर्यात आउटपुट नहीं है।

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
SVG-आधारित निर्यात PowerPoint आकारों को व्यक्तिगत HTML तत्वों के रूप में उजागर नहीं करता है। इस लेख में दर्शाए गए आकार-एनीमेशन और स्लाइड-ट्रांज़िशन विकल्पों की आवश्यकता होने पर HTML5 निर्यात का उपयोग करें।
{{% /alert %}}

## **PowerPoint को HTML5 स्लाइड व्यू में निर्यात करें**

HTML5 निर्यात एक पृष्ठ उत्पन्न करता है जिससे ब्राउज़र में प्रस्तुति स्लाइड को देखा और नेविगेट किया जा सकता है। यह उदाहरण दोनों [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) और [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) को `true` पास करता है ताकि निर्यातित स्लाइड व्यू स्रोत प्रस्तुति के प्रभाव चलाने में सक्षम हो।

ऐसे प्रस्तुति का उपयोग करें जिसमें पहले से ही आकार एनीमेशन और स्लाइड ट्रांज़िशन शामिल हों ताकि आप इन सेटिंग्स का प्रभाव देख सकें। इन्हें सक्षम करने से उन स्लाइडों में नए प्रभाव नहीं जोड़ते जिनमें कोई प्रभाव नहीं है। निर्यात के बाद, उत्पन्न HTML5 दस्तावेज़ को ब्राउज़र में उसके समर्थन फ़ाइलों के उपलब्ध होने पर खोलें।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **प्रस्तुति को टिप्पणी के साथ HTML5 दस्तावेज़ में परिवर्तित करें**

आप मौजूदा स्लाइड टिप्पणियों को HTML5 आउटपुट में शामिल कर सकते हैं ताकि पाठक स्लाइड सामग्री के साथ प्रतिक्रिया देख सकें। इस अनुभाग का उदाहरण स्रोत प्रस्तुति में टिप्पणी होने की अपेक्षा करता है, जैसा कि नीचे दिखाया गया है। यह उन टिप्पणियों को निर्यात करता है; नई टिप्पणी नहीं बनाता।

![प्रस्तुति स्लाइड पर दो टिप्पणियाँ](two_comments_pptx.png)

एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) ऑब्जेक्ट को [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) की [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) मेथड में पास करें। नीचे प्रत्येक स्लाइड के दाएँ पक्ष में टिप्पणी रखने के लिए [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) एनेमरेशन से `CommentsPositions::Right` के साथ [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) को कॉल करें।

निम्नलिखित उदाहरण इस टिप्पणी लेआउट के साथ प्रस्तुति को HTML5 में निर्यात करता है। टिप्पणी रहित प्रस्तुति में प्रदर्शित करने के लिए कोई टिप्पणी टेक्स्ट नहीं होगा।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

नीचे की छवि निर्यातित HTML5 दस्तावेज़ को दिखाती है जिसमें स्लाइड के बगल में टिप्पणियाँ प्रदर्शित होती हैं।

![निर्यातित HTML5 दस्तावेज़ में टिप्पणियाँ](two_comments_html5.png)

## **निर्यात के दौरान JavaScript हाइपरलिंक को बाहर रखें**

मान लें कि `hyperlinks.pptx` में `javascript:alert('Hello')` लक्ष्य वाला लिंक्ड टेक्स्ट और एक सामान्य `https://example.com/` लिंक है। निर्यात के दौरान JavaScript हाइपरलिंक को बाहर रखने के लिए, [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) को `true` के साथ कॉल करें। डिफ़ॉल्ट `false` है, इसलिए इन लिंक को फ़िल्टर नहीं किया जाता जब तक आप विकल्प सक्षम न करें।

निम्नलिखित उदाहरण कार्य निर्देशिका से प्रस्तुति को लोड करता है और उसे [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) का उपयोग करके निर्यात करता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

निर्यातित फ़ाइल JavaScript हाइपरलिंक को छोड़ देती है जबकि उसका टेक्स्ट और सामान्य HTTPS लिंक बरकरार रखती है। मूल प्रस्तुति अपरिवर्तित रहती है।

यह विकल्प JavaScript हाइपरलिंक को फ़िल्टर करता है; यह सभी स्क्रिप्ट या अन्य सक्रिय सामग्री को नहीं हटाता, न ही CSP अनुपालन की गारंटी देता है। उदाहरण के लिए, HTML5 आउटपुट में अभी भी स्लाइड नेविगेशन और एनीमेशन के लिए स्क्रिप्ट शामिल होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं HTML5 में ऑब्जेक्ट एनीमेशन और स्लाइड ट्रांज़िशन के प्ले होने को नियंत्रित कर सकता हूँ?**  
हाँ, HTML5 निर्यात अलग-अलग विकल्प प्रदान करता है जिससे आप [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) और [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) को सक्षम या अक्षम कर सकते हैं।

**क्या टिप्पणियों का समर्थन है, और उन्हें स्लाइड के सापेक्ष कहाँ रखा जा सकता है?**  
हाँ, मौजूदा टिप्पणियों को HTML5 आउटपुट में शामिल किया जा सकता है और नोट्स एवं टिप्पणियों के लिए [layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) के माध्यम से (उदाहरण के लिए, स्लाइड के दाएँ) स्थित किया जा सकता है।

**क्या मैं सुरक्षा या CSP कारणों से JavaScript को कॉल करने वाले लिंक्स को छोड़ सकता हूँ?**  
हाँ, [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) मेथड आपको सहेजने के दौरान JavaScript कॉल वाले हाइपरलिंक्स को छोड़ने की अनुमति देता है। डिफ़ॉल्ट `false` है। एक HTML5 निर्यात उदाहरण और फ़िल्टर के दायरे के लिए देखें [निर्यात के दौरान JavaScript हाइपरलिंक को बाहर रखें](/slides/hi/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export)। यह सेटिंग HTML5 व्यूअर द्वारा नेविगेशन और एनीमेशन के लिए उपयोग किए जाने वाले JavaScript को नहीं हटाती।