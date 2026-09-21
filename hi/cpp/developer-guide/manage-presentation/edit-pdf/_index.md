---
title: C++ में PDF दस्तावेज़ संपादित करें
linktitle: PDF संपादित करें
type: docs
weight: 65
url: /hi/cpp/edit-pdf/
keywords:
- PDF संपादित करें
- PDF पाठ बदलें
- PDF से PPTX
- PPTX से PDF
- C++
- Aspose.Slides
description: "C++ में PDF दस्तावेज़ को Aspose.Slides में आयात करके, पाठ बदल कर, और संशोधित प्रस्तुति को फिर से PDF में सहेजकर संपादित करें।"
---
## **सारांश**

Aspose.Slides for C++ आपको PDF सामग्री को उसके पृष्ठों को स्लाइड्स के रूप में आयात करके, प्रस्तुति को संशोधित करके, और इसे वापस PDF में निर्यात करके संपादित करने देता है। यह लेख एक सरल पाठ प्रतिस्थापन दर्शाता है। प्रस्तुति मेमोरी में रहती है, इसलिए एक मध्यवर्ती PPTX फ़ाइल को सहेजना वैकल्पिक है।

## **PDF में पाठ बदलें**

पृष्ठों को आयात करने के लिए [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/hi/cpp/aspose.slides/slidecollection/addfrompdf/) का उपयोग करें, पाठ को अपडेट करने के लिए [Presentation::ReplaceText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/replacetext/) और परिणाम निर्यात करने के लिए [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) का उपयोग करें।

निम्न उदाहरण यह अपेक्षा करता है कि `input.pdf` में आयात के बाद शब्द "Draft" संपादन योग्य पाठ के रूप में मौजूद हो। यह शब्द को "Final" से बदलता है और `edited.pdf` लिखता है। आयात से पहले प्रारंभिक स्लाइड को साफ़ करने से आउटपुट में एक अतिरिक्त खाली पृष्ठ नहीं बनता। खोज समान अक्षर केस वाले पूर्ण शब्दों से मेल खाती है; `nullptr` का अर्थ है कि कोई परिणाम कॉलबैक आवश्यक नहीं है।

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

अधिक विकल्पों के लिए, देखें [पाठ खोजें और बदलें](/slides/hi/cpp/search-and-replace-text/) और [PowerPoint को PDF में बदलें](/slides/hi/cpp/convert-powerpoint-to-pdf/)।

{{% alert color="info" title="Note" %}}
पाठ प्रतिस्थापन आयातित पाठ पर काम करता है, स्कैन की गई छवियों के भीतर के पाठ पर नहीं। परिवर्तन लेआउट और स्वरूपण को प्रभावित कर सकता है, इसलिए आउटपुट की समीक्षा करें, विशेष रूप से जब प्रतिस्थापित पाठ मूल पाठ से लंबा हो।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे PDF निर्यात करने से पहले PPTX फ़ाइल को सहेजना आवश्यक है?**

नहीं। आप मेमोरी में उसी प्रस्तुति को संपादित और निर्यात कर सकते हैं। केवल तभी PPTX की प्रतिलिपि सहेजें जब आप इसे PowerPoint में संपादन जारी रखना चाहते हों; देखें [प्रस्तुतियों को सहेजें](/slides/hi/cpp/save-presentation/)।

**क्यों कुछ पाठ अपरिवर्तित रह सकता है?**

उदाहरण पूर्ण शब्द "Draft" को सटीक केस के साथ मिलाता है। छवि के रूप में आयातित पाठ या अलग-अलग टेक्स्ट फ्रेम में विभाजित पाठ आवश्यक रूप से खोज से मेल नहीं खाएगा। आयातित सामग्री की जाँच करें और अपने दस्तावेज़ के लिए खोज को समायोजित करें।