---
title: "C++ में PowerPoint फ़ॉन्ट को अनुकूलित करें"
linktitle: "कस्टम फ़ॉन्ट"
type: docs
weight: 20
url: /hi/cpp/custom-font/
keywords:
- "फ़ॉन्ट"
- "कस्टम फ़ॉन्ट"
- "बाह्य फ़ॉन्ट"
- "फ़ॉन्ट लोड"
- "फ़ॉन्ट प्रबंधित करें"
- "फ़ॉन्ट फ़ोल्डर"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ के साथ PowerPoint स्लाइड्स में फ़ॉन्ट को अनुकूलित करें ताकि आपकी प्रस्तुतियां किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रस्तुतियों में कस्टम फ़ॉन्ट्स का उपयोग करने की अनुमति देता है बिना उन्हें ऑपरेटिंग सिस्टम पर स्थापित किए। आप फ़ॉन्ट्स को कस्टम फ़ोल्डरों से लोड कर सकते हैं, दस्तावेज़‑स्तर फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुति के लिए फ़ॉन्ट्स प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट्स लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट्स का उपयोग तब किया जाता है जब प्रस्तुति को रेंडर या एक्सपोर्ट किया जाता है, उदाहरण के लिए PDF, चित्रों और अन्य समर्थित स्वरूपों में। यह विभिन्न वातावरणों में प्रस्तुति आउटपुट को सुसंगत रखने में मदद करता है। यह लेख यह भी बताता है कि Aspose.Slides द्वारा उपयोग किए जाने वाले फ़ॉन्ट फ़ोल्डरों की जाँच कैसे करें और बाहरी फ़ॉन्ट्स के साथ काम करने के बाद फ़ॉन्ट कैश को कैसे साफ़ करें।

रेंडरिंग के लिए कस्टम फ़ॉन्ट्स को पंजीकृत करना PPTX फ़ाइल में फ़ॉन्ट्स को एम्बेड करने से अलग है। यदि फ़ॉन्ट को स्वयं प्रस्तुति के अंदर संग्रहीत करना आवश्यक है, तो फ़ॉन्ट एम्बेडिंग सुविधाओं का स्पष्ट रूप से उपयोग करें।

एक प्रस्तुति थीम व्यक्तिगत लेखन प्रणालियों के लिए विभिन्न फ़ॉन्ट परिवारों का संदर्भ दे सकती है। ये मैपिंग्स फ़ॉन्ट नामों को संग्रहीत करती हैं लेकिन फ़ॉन्ट फ़ाइलों को स्थापित या लोड नहीं करतीं। मैपिंग्स को प्रबंधित करने के लिए देखें [Script-Specific Theme Fonts](/slides/hi/cpp/script-specific-font-mappings/), और नीचे दिए गए लोडिंग विकल्पों का उपयोग करके संदर्भित फ़ॉन्ट्स को सुसंगत रेंडरिंग के लिए उपलब्ध कराएँ।

{{% alert color="info" title="Note" %}}

Aspose Slides आपको इन फ़ॉन्ट्स को लोड करने की अनुमति देता है उपयोग करके [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट्स। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।

* OpenType (.otf) फ़ॉन्ट्स। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।

{{% /alert %}}

## **कस्टम फ़ॉन्ट्स लोड करें**

Aspose.Slides आपको प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट्स को सिस्टम पर स्थापित किए बिना लोड करने की अनुमति देता है। यह निर्यात आउटपुट को प्रभावित करता है—जैसे PDF, चित्र, और अन्य समर्थित स्वरूप—ताकि प्राप्त दस्तावेज़ विभिन्न वातावरणों में सुसंगत दिखें। फ़ॉन्ट्स कस्टम निर्देशिकाओं से लोड किए जाते हैं।

1. उन एक या अधिक फ़ोल्डरों को निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें हों।
2. स्थैतिक [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) विधि को कॉल करके उन फ़ोल्डरों से फ़ॉन्ट्स लोड करें।
3. प्रस्तुति को लोड और रेंडर/एक्सपोर्ट करें।
4. फ़ॉन्ट कैश को साफ़ करने के लिए [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/clearcache/) को कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

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

// लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/एक्सपोर्ट करें (उदा., PDF, चित्र या अन्य स्वरूपों में)।
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfonts/) अतिरिक्त फ़ोल्डरों को फ़ॉन्ट खोज पथ में जोड़ता है, लेकिन फ़ॉन्ट प्रारंभ क्रम को बदलता नहीं है।  
फ़ॉन्ट्स इस क्रम में प्रारंभ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पथ।  
1. उन पथों को जो [FontsLoader](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/) के माध्यम से लोड किए गए हैं।

{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**

Aspose.Slides प्रदान करता है [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/getfontfolders/) जिससे आप फ़ॉन्ट फ़ोल्डर खोज सकते हैं। यह विधि `LoadExternalFonts` विधि और सिस्टम फ़ॉन्ट फ़ोल्डरों के माध्यम से जोड़े गए फ़ोल्डरों को लौटाती है।

यह C++ कोड दिखाता है कि आप [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/getfontfolders/) विधि का उपयोग कैसे कर सकते हैं:

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// यह पंति उन फ़ोल्डरों को आउटपुट करती है जो फ़ॉन्ट फ़ाइलों के लिए जाँच किए जाते हैं।
 // ये फ़ोल्डर LoadExternalFonts मेथड और सिस्टम फ़ॉन्ट फ़ोल्डरों के माध्यम से जोड़े गए हैं।
auto fontFolders = FontsLoader::GetFontFolders();
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट्स निर्दिष्ट करें**

Aspose.Slides प्रदान करता है [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) प्रॉपर्टी जिससे आप बाहरी फ़ॉन्ट्स को निर्दिष्ट कर सकते हैं जो प्रस्तुति के साथ उपयोग किए जाएंगे।

यह C++ कोड दिखाता है कि आप [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) प्रॉपर्टी का उपयोग कैसे कर सकते हैं:

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
    // CustomFont1, CustomFont2 के साथ-साथ assets\fonts और global\fonts फ़ोल्डरों और उनके उपफ़ोल्डरों से फ़ॉन्ट्स प्रस्तुति के लिए उपलब्ध हैं
}
```

## **फ़ॉन्ट्स को बाहरी रूप से प्रबंधित करें**

Aspose.Slides प्रदान करता है [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/loadexternalfont/) विधि जिससे आप बाहरी फ़ॉन्ट्स को बाइट ऐरे में लोड कर सकते हैं।

यह C++ कोड बाइट ऐरे फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// दस्तावेज़ निर्देशिका के पथ
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

### क्या कस्टम फ़ॉन्ट्स सभी स्वरूपों (PDF, PNG, SVG, HTML) में निर्यात को प्रभावित करते हैं?

हाँ। जुड़े हुए फ़ॉन्ट्स को रेंडरर सभी निर्यात स्वरूपों में उपयोग करता है।

### क्या कस्टम फ़ॉन्ट्स स्वचालित रूप से परिणामी PPTX में एम्बेड हो जाते हैं?

नहीं। रेंडरिंग के लिए फ़ॉन्ट को पंजीकृत करना PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल में समेटना है, तो आपको स्पष्ट रूप से [एम्बेडिंग सुविधाओं](/slides/hi/cpp/embedded-font/) का उपयोग करना होगा।

### क्या मैं उस स्थिति को नियंत्रित कर सकता हूँ जब कस्टम फ़ॉन्ट में कुछ glyphs नहीं हों?

हाँ। आप [फ़ॉन्ट प्रतिस्थापन](/slides/hi/cpp/font-substitution/), [प्रतिस्थापन नियम](/slides/hi/cpp/font-replacement/) और [फ़ॉलबैक सेट](/slides/hi/cpp/fallback-font/) को कॉन्फ़िगर करके ठीक‑ठीक तय कर सकते हैं कि अनुरोधित glyph ग़ायब होने पर कौन सा फ़ॉन्ट उपयोग किया जाएगा।

### क्या मैं Linux/Docker कंटेनरों में फ़ॉन्ट्स का उपयोग कर सकता हूँ बिना उन्हें सिस्टम‑वाइड स्थापित किए?

हाँ। अपने स्वयं के फ़ॉन्ट फ़ोल्डरों की ओर संकेत करें या फ़ॉन्ट्स को बाइट ऐरे से लोड करें। यह कंटेनर इमेज में सिस्टम फ़ॉन्ट निर्देशिकाओं पर किसी भी निर्भरता को समाप्त करता है।

### लाइसेंसिंग के बारे में—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंधों के एम्बेड कर सकता हूँ?

आप फ़ॉन्ट लाइसेंस अनुपालन के लिए जिम्मेदार हैं। शर्तें भिन्न होती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग पर प्रतिबंध लगाते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें।