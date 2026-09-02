---
title: "C++ में प्रस्तुति स्थानीयकरण को स्वचालित करें"
linktitle: "प्रस्तुति स्थानीयकरण"
type: docs
weight: 100
url: /hi/cpp/presentation-localization/
keywords:
- "भाषा बदलें"
- "वर्तनी जाँच"
- "वर्तनी जाँच निरुपित करें"
- "प्रूफ़िंग भाषा"
- "भाषा ID"
- "बहुभाषी टेक्स्ट"
- "PowerPoint"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides के साथ C++ में PowerPoint और OpenDocument प्रस्तुति टेक्स्ट के लिए प्रूफ़िंग भाषाएँ सेट करें, जिसमें डिफ़ॉल्ट और बहुभाषी अनुच्छेद शामिल हैं।"
---
## **अवलोकन**

Aspose.Slides for C++ आपको व्यक्तिगत टेक्स्ट भागों के लिए प्रूफ़िंग मेटाडाटा कॉन्फ़िगर करने की अनुमति देता है। प्रूफ़िंग भाषा निर्धारित करने के लिए [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/set_languageid/) का उपयोग करें, वर्तनी जाँच को सक्षम या निष्क्रिय करने के लिए [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_spellcheck/) और व्यापक “नो‑प्रूफ़” स्थिति को नियंत्रित करने के लिए [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_proofdisabled/) का उपयोग करें। क्योंकि ये सेटिंग्स भाग स्तर पर लागू होती हैं, एक अनुच्छेद में कई भाषाएँ और विभिन्न प्रूफ़िंग नियम हो सकते हैं।

यह लेख समझाता है कि विशिष्ट टेक्स्ट को भाषा कैसे असाइन करें, [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) के साथ नई टेक्स्ट की डिफ़ॉल्ट भाषा कैसे सेट करें, बहुभाषी अनुच्छेद कैसे बनाएं, `SpellCheck` और `ProofDisabled` में से कौन सा चुनें, और [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/joinportionswithsameformatting/) का उपयोग करते समय इच्छित सेटिंग्स को कैसे संरक्षित रखें। ये प्रॉपर्टीज़ प्रस्तुति अनुप्रयोगों के लिए मेटाडाटा संग्रहीत करती हैं; वे टेक्स्ट का अनुवाद नहीं करतीं, शब्दकोष-आधारित वर्तनी जाँच नहीं करतीं, या त्रुटिपूर्ण शब्दों की सूची नहीं लौटातीं।

## **टेक्स्ट के लिए प्रूफ़िंग भाषा सेट करें**

एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) बनाएं या लोड करें, आवश्यक टेक्स्ट भाग को [IPortion::get_PortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/get_portionformat/) के माध्यम से एक्सेस करें, और उसकी भाषा पहचानकर्ता असाइन करें। निम्न उदाहरण एक आकार बनाता है, ब्रिटिश अंग्रेज़ी को प्रूफ़िंग भाषा के रूप में सेट करता है, और परिणाम को [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) के साथ सहेजता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **नई टेक्स्ट के लिए डिफ़ॉल्ट भाषा सेट करें**

नई बनाई गई टेक्स्ट को Aspose.Slides द्वारा असाइन की गई प्रूफ़िंग भाषा निर्दिष्ट करने के लिए [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) का उपयोग करें। यह सेटिंग तब उपयोगी होती है जब प्रस्तुति में अधिकांश या सभी नई टेक्स्ट एक ही भाषा का उपयोग करती है। यह पहले से स्पष्ट भाषा वाली टेक्स्ट की भाषा मेटाडाटा को नहीं बदलती।

निम्न उदाहरण एक प्रस्तुति बनाता है जहाँ नई टेक्स्ट जर्मन प्रूफ़िंग नियमों का उपयोग करती है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **एक अनुच्छेद में कई भाषाओं का उपयोग करें**

एक [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) टेक्स्ट भागों का संग्रह रखता है। प्रत्येक भाषा के लिए एक अलग [Portion](https://reference.aspose.com/slides/hi/cpp/aspose.slides/portion/) बनाएं और उसका `LanguageId` स्वतंत्र रूप से सेट करें।

यह उदाहरण अंग्रेज़ी और फ्रेंच भागों के साथ एक अनुच्छेद बनाता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **व्यक्तिगत भागों के लिए वर्तनी जाँच सक्षम या निष्क्रिय करें**

[IPortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformat/) सामान्य टेक्स्ट प्रॉपर्टी को विरासत में लेता है जो [IBasePortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/) द्वारा परिभाषित होते हैं। एक भाग के फ़ॉर्मेट को [IPortion::get_PortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/get_portionformat/) के माध्यम से एक्सेस करें और [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_spellcheck/) को कॉल करके निर्धारित करें कि प्रस्तुति अनुप्रयोग उस भाग के लिए वर्तनी जाँच कर सकता है या नहीं। डिफ़ॉल्ट मान `false` है: `true` वर्तनी जाँच को सक्षम करता है, जबकि `false` इसे निरुपित करता है।

यह सेटिंग व्यक्तिगत टेक्स्ट भागों पर लागू होती है। उसी अनुच्छेद में विभिन्न भाग इसलिए अलग-अलग मान उपयोग कर सकते हैं। [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_languageid/) और `SpellCheck` पूरक उद्देश्यों की सेवा करते हैं: `LanguageId` प्रूफ़िंग भाषा को पहचानता है, जबकि `SpellCheck` निर्धारित करता है कि उस भाग के लिए वर्तनी जाँच की अनुमति है या नहीं।

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_proofdisabled/) भी प्रूफ़िंग को नियंत्रित करता है, लेकिन यह व्यापक “do not proof” स्थिति को एक [NullableBool](https://reference.aspose.com/slides/hi/cpp/aspose.slides/nullablebool/) के रूप में दर्शाता है। जब आपको विशेष रूप से वर्तनी जाँच के लिए एक बूलियन स्विच चाहिए, तो `SpellCheck` का उपयोग करें। जब आपको प्रस्तुति की “नो‑प्रूफ़” मेटाडाटा को संरक्षित या स्पष्ट रूप से नियंत्रित करना हो, जिसमें उसका `NullableBool::NotDefined` स्थिति भी शामिल है, तो `ProofDisabled` का उपयोग करें। यदि आप दोनों प्रॉपर्टीज़ सेट करते हैं, तो उनके मान संगत रखें; `SpellCheck = true` को `ProofDisabled = NullableBool::True` के साथ संयोजित न करें।

ये प्रॉपर्टीज़ PowerPoint और अन्य प्रस्तुति अनुप्रयोगों द्वारा उपयोग किए जाने वाले प्रूफ़िंग मेटाडाटा को कॉन्फ़िगर करती हैं। Aspose.Slides इनका उपयोग शब्दकोष-आधारित वर्तनी जाँच चलाने या गलत शब्दों की सूची लौटाने के लिए नहीं करती।

निम्न पूर्ण उदाहरण एक इनपुट प्रस्तुति बनाता है, उसे लोड करता है, एक ही अनुच्छेद में दो भागों के लिए विभिन्न वर्तनी‑जाँच सेटिंग्स और प्रूफ़िंग भाषाएँ असाइन करता है, परिणाम सहेजता है, उसे पुनः खोलता है, और संग्रहीत मानों की जांच करता है:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/joinportionswithsameformatting/) उन क्रमागत भागों को मिलाता है जिनका फ़ॉर्मेट समान होता है। केवल `SpellCheck` में अंतर होने से ऐसे भाग अलग नहीं रहते; जब वे जुड़ जाते हैं, तो परिणामी भाग पहले भाग का `SpellCheck` मान रखता है। यदि भागों को अलग‑अलग वर्तनी‑जाँच सेटिंग्स की आवश्यकता है, तो उन सेटिंग्स को असाइन करने से पहले `JoinPortionsWithSameFormatting` को कॉल करें, या परिणामी भाग की सीमाओं की जाँच करके बाद में सेटिंग्स को पुनः लागू करें। विभिन्न `LanguageId` मान वाले भाग अलग‑अलग रहते हैं क्योंकि उनका प्रूफ़िंग‑भाषा फ़ॉर्मेट भिन्न होता है।

## **FAQ**

**क्या भाषा ID टेक्स्ट का अनुवाद करती है?**

नहीं। [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/set_languageid/) वर्तनी और व्याकरण के लिए प्रूफ़िंग मेटाडाटा संग्रहीत करता है; यह टेक्स्ट सामग्री को नहीं बदलता। टेक्स्ट को अलग से अनुवादित करें, और फिर प्रत्येक अनूदित भाग के लिए उपयुक्त भाषा पहचानकर्ता सेट करें।

**क्या प्रूफ़िंग भाषा फ़ॉन्ट, हाइफ़नेशन, या लाइन रैपिंग को नियंत्रित करती है?**

नहीं। भाषा पहचानकर्ता केवल प्रूफ़िंग के लिए है। टेक्स्ट रेंडरिंग और लेआउट मुख्यतः उपलब्ध [fonts](/slides/hi/cpp/powerpoint-fonts/), लेखन प्रणाली, और टेक्स्ट‑फ़्रेम सेटिंग्स पर निर्भर करता है। विश्वसनीय रेंडरिंग के लिए आवश्यक फ़ॉन्ट प्रदान करें, [font substitution](/slides/hi/cpp/font-substitution/) कॉन्फ़िगर करें, या प्रस्तुति में [embed fonts](/slides/hi/cpp/embedded-font/) करें।

**क्या एक अनुच्छेद कई प्रूफ़िंग भाषाएँ उपयोग कर सकता है?**

हाँ। प्रत्येक भाषा को एक अलग भाग में असाइन करें, जैसा कि बहुभाषी अनुच्छेद उदाहरण में दिखाया गया है।

**मुझे `DefaultTextLanguage` या `LanguageId` में से कौन सा उपयोग करना चाहिए?**

जब आप नई बनाई गई टेक्स्ट के लिए डिफ़ॉल्ट सेट करना चाहते हैं, तो [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) का उपयोग करें। जब किसी विशेष भाग को स्पष्ट प्रूफ़िंग भाषा की आवश्यकता हो या जब एक अनुच्छेद में कई भाषाएँ हों, तो [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/set_languageid/) का उपयोग करें।