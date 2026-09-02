---
title: ".NET में प्रस्तुति स्थानीयकरण को स्वचालित करें"
linktitle: "प्रेजेंटेशन लोकलाइज़ेशन"
type: docs
weight: 100
url: /hi/net/presentation-localization/
keywords:
- "भाषा बदलें"
- "वर्तनी जांच"
- "वर्तनी जांच दबाएँ"
- "प्रूफ़िंग भाषा"
- "भाषा आईडी"
- "बहु‑भाषीय टेक्स्ट"
- "PowerPoint"
- "प्रेजेंटेशन"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides के साथ .NET में PowerPoint और OpenDocument प्रस्तुति टेक्स्ट के लिए प्रूफ़िंग भाषाएँ सेट करें, जिसमें डिफ़ॉल्ट और बहु‑भाषीय पैराग्राफ शामिल हैं।"
---
## **परिचय**

Aspose.Slides for .NET आपको व्यक्तिगत टेक्स्ट भागों के लिए प्रूफ़िंग मेटाडाटा कॉन्फ़िगर करने देता है। प्रूफ़िंग भाषा की पहचान करने के लिए [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/languageid/) का उपयोग करें, वर्तनी जांच को अनुमति या निष्क्रिय करने के लिए [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/spellcheck/) का उपयोग करें, और व्यापक “नो‑प्रूफ़” अवस्था को नियंत्रित करने के लिए [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/proofdisabled/) का उपयोग करें। क्योंकि ये सेटिंग्स भाग स्तर पर लागू होती हैं, एक पैराग्राफ में कई भाषाएँ और विभिन्न प्रूफ़िंग नियम हो सकते हैं।

यह लेख बताता है कि कैसे विशिष्ट टेक्स्ट को भाषा असाइन करें, नए टेक्स्ट के लिए डिफ़ॉल्ट भाषा सेट करें [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/defaulttextlanguage/) का उपयोग करके, बहु‑भाषी पैराग्राफ बनाएं, `SpellCheck` और `ProofDisabled` के बीच चयन करें, और [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/joinportionswithsameformatting/) का उपयोग करते समय इच्छित सेटिंग्स को बनाए रखें। ये प्रॉपर्टीज़ प्रस्तुति एप्लिकेशन के लिए मेटाडाटा संग्रहीत करती हैं; ये टेक्स्ट का अनुवाद नहीं करतीं, शब्दकोश‑आधारित वर्तनी जांच नहीं चलातीं, या गलत लिखे शब्द नहीं लौटातीं।

## **पाठ के लिए प्रूफ़िंग भाषा सेट करें**

एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) बनाएं या लोड करें, आवश्यक टेक्स्ट भाग तक पहुंचें [IPortion.PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/portionformat/) के माध्यम से, और उसकी भाषा पहचानकर्ता असाइन करें। निम्नलिखित उदाहरण एक आकार बनाता है, ब्रिटिश अंग्रेज़ी को प्रूफ़िंग भाषा के रूप में सेट करता है, और परिणाम को [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) से सहेजता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **नए पाठ के लिए डिफ़ॉल्ट भाषा सेट करें**

नए बनाए गए टेक्स्ट को Aspose.Slides द्वारा असाइन की जाने वाली प्रूफ़िंग भाषा निर्दिष्ट करने के लिए [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/defaulttextlanguage/) का उपयोग करें। यह सेटिंग तब उपयोगी होती है जब प्रस्तुति में अधिकांश या सभी नया टेक्स्ट एक ही भाषा का उपयोग करता हो। यह उन टेक्स्ट की भाषा मेटाडाटा को नहीं बदलती जिनमें पहले से स्पष्ट भाषा निर्धारित है।

निम्नलिखित उदाहरण एक प्रस्तुति बनाता है जिसका नया टेक्स्ट जर्मन प्रूफ़िंग नियमों का उपयोग करता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **एक पैराग्राफ में कई भाषाओं का उपयोग करें**

एक [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) में टेक्स्ट भागों का संग्रह होता है। प्रत्येक भाषा के लिए एक अलग [Portion](https://reference.aspose.com/slides/hi/net/aspose.slides/portion/) बनाएं और उसका `LanguageId` स्वतंत्र रूप से सेट करें।

यह उदाहरण एक पैराग्राफ बनाता है जिसमें अंग्रेज़ी और फ्रेंच भाग हैं:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **व्यक्तिगत भागों के लिए वर्तनी जांच सक्षम या दबाएँ**

[IPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/) [IBasePortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/) द्वारा परिभाषित सामान्य टेक्स्ट प्रॉपर्टीज़ को विरासत में लेता है। किसी भाग का फ़ॉर्मेट [IPortion.PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/portionformat/) के माध्यम से एक्सेस करें और [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/spellcheck/) सेट करके निर्धारित करें कि प्रस्तुति एप्लिकेशन उस भाग के लिए वर्तनी जांच कर सकता है या नहीं। डिफ़ॉल्ट मान `false` है: `true` वर्तनी जांच की अनुमति देता है, जबकि `false` इसे दबा देता है।

यह सेटिंग व्यक्तिगत टेक्स्ट भागों पर लागू होती है। एक ही पैराग्राफ में अलग‑अलग भाग इसलिए अलग मानों का उपयोग कर सकते हैं। [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/languageid/) और `SpellCheck` पूरक उद्देश्यों की सेवा करते हैं: `LanguageId` प्रूफ़िंग भाषा की पहचान करता है, जबकि `SpellCheck` यह निर्धारित करता है कि उस भाग के लिए वर्तनी जांच की अनुमति है या नहीं।

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/proofdisabled/) भी प्रूफ़िंग को नियंत्रित करता है, लेकिन यह व्यापक “do not proof” अवस्था को एक [NullableBool](https://reference.aspose.com/slides/hi/net/aspose.slides/nullablebool/) के रूप में दर्शाता है। जब आपको केवल वर्तनी जांच के लिए सीधे Boolean स्विच चाहिए तो `SpellCheck` उपयोग करें। जब आपको प्रस्तुति के “नो‑प्रूफ़” मेटाडाटा को संरक्षित या स्पष्ट रूप से नियंत्रित करना हो, जिसमें उसका `NotDefined` अवस्था शामिल है, तो `ProofDisabled` उपयोग करें। यदि आप दोनों प्रॉपर्टीज़ सेट करते हैं, तो उनके मानों को संगत रखें; `SpellCheck = true` को `ProofDisabled = NullableBool.True` के साथ मिलाएँ नहीं।

ये प्रॉपर्टीज़ PowerPoint तथा अन्य प्रस्तुति एप्लिकेशनों द्वारा उपयोग किए जाने वाले प्रूफ़िंग मेटाडाटा को कॉन्फ़िगर करती हैं। Aspose.Slides इन्हें शब्दकोश‑आधारित वर्तनी जांच चलाने या गलत लिखे शब्दों की सूची लौटाने के लिए नहीं उपयोग करता।

निम्नलिखित पूर्ण उदाहरण एक इनपुट प्रस्तुति बनाता है, उसे लोड करता है, एक ही पैराग्राफ में दो भागों को विभिन्न वर्तनी‑जांच सेटिंग्स और प्रूफ़िंग भाषाएँ असाइन करता है, परिणाम सहेजता है, फिर उसे फिर से खोलकर संग्रहीत मानों की जाँच करता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/joinportionswithsameformatting/) समान फ़ॉर्मेटिंग वाले क्रमिक भागों को मिलाता है। केवल `SpellCheck` में अंतर होने से ऐसे भाग अलग नहीं रहते; जब वे जुड़ जाते हैं, तो परिणामी भाग पहला भाग का `SpellCheck` मान रखता है। यदि भागों को अलग‑अलग वर्तनी‑जांच सेटिंग्स की आवश्यकता है, तो उन सेटिंग्स को असाइन करने से पहले `JoinPortionsWithSameFormatting` कॉल करें, या परिणामी भाग सीमाओं की जाँच कर बाद में सेटिंग्स पुनः लागू करें। विभिन्न `LanguageId` मान वाले भाग अलग‑अलग रहते हैं क्योंकि उनका प्रूफ़िंग‑भाषा फ़ॉर्मेट अलग होता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या भाषा ID पाठ का अनुवाद करता है?**

नहीं। [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/languageid/) वर्तनी और व्याकरण के लिए प्रूफ़िंग मेटाडाटा संग्रहीत करता है; यह टेक्स्ट सामग्री को नहीं बदलता। टेक्स्ट को अलग से अनूदित करें, फिर प्रत्येक अनूदित भाग के लिए उपयुक्त भाषा पहचानकर्ता सेट करें।

**क्या प्रूफ़िंग भाषा फ़ॉन्ट, हाइफ़नेशन या लाइन रैपिंग को नियंत्रित करती है?**

नहीं। भाषा पहचानकर्ता केवल प्रूफ़िंग के लिए है। टेक्स्ट रेंडरिंग और लेआउट प्रमुख रूप से उपलब्ध [fonts](/slides/hi/net/powerpoint-fonts/), लेखन प्रणाली, और टेक्स्ट‑फ़्रेम सेटिंग्स पर निर्भर करते हैं। विश्वसनीय रेंडरिंग के लिए आवश्यक फ़ॉन्ट्स प्रदान करें, [font substitution](/slides/hi/net/font-substitution/) कॉन्फ़िगर करें, या प्रस्तुति में [embed fonts](/slides/hi/net/embedded-font/) शामिल करें।

**क्या एक पैराग्राफ कई प्रूफ़िंग भाषाएँ उपयोग कर सकता है?**

हां। प्रत्येक भाषा को अलग भाग में असाइन करें, जैसा कि बहु‑भाषी पैराग्राफ उदाहरण में दिखाया गया है।

**मुझे `DefaultTextLanguage` या `LanguageId` में से कौनसा उपयोग करना चाहिए?**

नए बनाए गए टेक्स्ट के लिए डिफ़ॉल्ट सेट करने के लिए [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/defaulttextlanguage/) उपयोग करें। जब किसी विशिष्ट भाग को स्पष्ट प्रूफ़िंग भाषा की आवश्यकता हो या पैराग्राफ में कई भाषाएँ हों, तो [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/languageid/) उपयोग करें।