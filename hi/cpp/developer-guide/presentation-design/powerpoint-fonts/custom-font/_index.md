---
title: "C++ में PowerPoint फ़ॉन्ट को कस्टमाइज़ करें"
linktitle: "कस्टम फ़ॉन्ट"
type: docs
weight: 20
url: /hi/cpp/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाहरी फ़ॉन्ट
- फ़ॉन्ट लोड करें
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ के लिए Aspose.Slides के साथ PowerPoint स्लाइड्स में फ़ॉन्ट को कस्टमाइज़ करें ताकि आपके प्रस्तुतियों हर डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुति में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर स्थापित किए। आप कस्टम फ़ोल्डरों से फ़ॉन्ट्स लोड कर सकते हैं, दस्तावेज़‑स्तर फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुति के लिए फ़ॉन्ट्स प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुति को रेंडर या निर्यात किया जाता है, जैसे PDF, छवियों और अन्य समर्थित स्वरूपों में। यह विभिन्न पर्यावरणों में प्रस्तुति आउटपुट को सुसंगत रखने में मदद करता है। लेख यह भी समझाता है कि Aspose.Slides द्वारा उपयोग किए गए फ़ॉन्ट फ़ोल्डरों को कैसे जांचा जाए और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश को कैसे साफ़ किया जाए।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स का पंजीकरण करना PPTX फ़ाइल में फ़ॉन्ट्स को एम्बेड करने से अलग है। यदि फ़ॉन्ट को प्रस्तुति के अंदर ही संग्रहीत करना आवश्यक हो, तो फ़ॉन्ट एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

{{% alert color="info" %}} 

Aspose Slides आपको इन फ़ॉन्ट्स को [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) का उपयोग करके लोड करने देता है:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।

{{% /alert %}}

## **कस्टम फ़ॉन्ट लोड करें**

Aspose.Slides आपको सिस्टम पर फ़ॉन्ट स्थापित किए बिना प्रस्तुति में उपयोग किए गए फ़ॉन्ट्स लोड करने देता है। यह निर्यात आउटपुट—जैसे PDF, छवियां और अन्य समर्थित स्वरूप—को प्रभावित करता है, जिससे उत्पन्न दस्तावेज़ विभिन्न पर्यावरणों में सुसंगत दिखते हैं। फ़ॉन्ट्स कस्टम डायरेक्टरी से लोड किए जाते हैं।

1. उन फ़ोल्डरों को निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें हों।  
2. स्थिर [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) मेथड को कॉल करके उन फ़ोल्डरों से फ़ॉन्ट्स लोड करें।  
3. प्रस्तुति को लोड और रेंडर/निर्यात करें।  
4. फ़ॉन्ट कैश को साफ़ करने के लिए [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/clearcache/) को कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोड प्रक्रिया को प्रदर्शित करता है:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को परिभाषित करें।
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट लोड करें।
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/निर्यात करें (जैसे PDF, छवियां, या अन्य स्वरूप)।
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// कार्य समाप्त होने के बाद फ़ॉन्ट कैश को साफ़ करें।
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) फ़ॉन्ट खोज पथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन फ़ॉन्ट प्रारंभ क्रम को नहीं बदलता।  
फ़ॉन्ट्स इस क्रम में प्रारम्भ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पथ।  
1. उन पथों को जो [FontsLoader](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/) के माध्यम से लोड किए गए हैं।

{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**

Aspose.Slides प्रदान करता है [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/getfontfolders/) ताकि आप फ़ॉन्ट फ़ोल्डरों को ढूंढ सकें। यह मेथड `LoadExternalFonts` मेथड के द्वारा जोड़े गए फ़ोल्डरों और सिस्टम फ़ॉन्ट फ़ोल्डरों को लौटाता है।

यह C++ कोड दिखाता है कि आप [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/getfontfolders/) मेथड का कैसे उपयोग कर सकते हैं:

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// यह पंक्ति उन फ़ोल्डरों को आउटपुट करती है जिन्हें फ़ॉन्ट फ़ाइलों के लिए जाँच किया जाता है.
// ये फ़ोल्डर LoadExternalFonts मेथड और सिस्टम फ़ॉन्ट फ़ोल्डरों के द्वारा जोड़े गए हैं।
auto fontFolders = FontsLoader::GetFontFolders();
```

## **एक प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**

Aspose.Slides प्रदान करता है [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) प्रॉपर्टी ताकि आप बाहरी फ़ॉन्ट्स को निर्दिष्ट कर सकें जो प्रस्तुति के साथ उपयोग किए जाएँगे।

यह C++ कोड दिखाता है कि आप [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) प्रॉपर्टी का कैसे उपयोग कर सकते हैं:

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // प्रस्तुति के साथ काम करें
    // CustomFont1, CustomFont2 के साथ-साथ assets\fonts और global\fonts फ़ोल्डरों तथा उनके उपफ़ोल्डरों में मौजूद फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**

Aspose.Slides प्रदान करता है [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfont/) मेथड ताकि आप बाहरी फ़ॉन्ट्स को बाइट एरे में लोड कर सकें।

यह C++ कोड बाइट एरे फ़ॉन्ट लोड प्रक्रिया को दर्शाता है:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// डॉक्यूमेंट्स डिरेक्टरी का पथ
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या कस्टम फ़ॉन्ट्स सभी स्वरूपों (PDF, PNG, SVG, HTML) के निर्यात को प्रभावित करते हैं?

हाँ। जुड़े हुए फ़ॉन्ट्स रेंडरर द्वारा सभी निर्यात स्वरूपों में उपयोग किए जाते हैं।

### क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से परिणामी PPTX में एम्बेड हो जाते हैं?

नहीं। रेंडरिंग के लिए फ़ॉन्ट को पंजीकृत करना इसे PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को फ़ाइल के भीतर ले जाना है, तो आपको स्पष्ट रूप से [एम्बेडिंग सुविधाएँ](/slides/hi/cpp/embedded-font/) का उपयोग करना होगा।

### क्या मैं कस्टम फ़ॉन्ट में कुछ ग्लाइफ़ न मिलने पर फॉलबैक व्यवहार को नियंत्रित कर सकता हूँ?

हाँ। आप [फ़ॉन्ट प्रतिस्थापन](/slides/hi/cpp/font-substitution/), [प्रतिस्थापन नियम](/slides/hi/cpp/font-replacement/) और [फ़ॉलबैक सेट](/slides/hi/cpp/fallback-font/) को कॉन्फ़िगर करके यह निर्धारित कर सकते हैं कि अनुरोधित ग्लाइफ़ अनुपलब्ध होने पर कौनसा फ़ॉन्ट उपयोग किया जाएगा।

### क्या मैं Linux/Docker कंटेनरों में फ़ॉन्ट्स को इंस्टॉल किए बिना उपयोग कर सकता हूँ?

हाँ। अपने स्वयं के फ़ॉन्ट फ़ोल्डरों की ओर इंगित करें या बाइट एरे से फ़ॉन्ट्स लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरी पर किसी भी निर्भरता को हटाया जा सकता है।

### लाइसेंसिंग के बारे में—क्या मैं बिना प्रतिबंध के किसी भी कस्टम फ़ॉन्ट को एम्बेड कर सकता हूँ?

आप फ़ॉन्ट लाइसेंसिंग अनुपालन के लिए जिम्मेदार हैं। शर्तें भिन्न होती हैं; कुछ लाइसेंस एम्बेडिंग या वाणिज्यिक उपयोग पर प्रतिबंध लगाते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें।