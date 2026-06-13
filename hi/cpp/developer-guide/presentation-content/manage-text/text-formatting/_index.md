---
title: C++ में प्रस्तुति टेक्स्ट को फ़ॉर्मेट करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/cpp/text-formatting/
keywords:
- टेक्स्ट हाइलाइट
- रेगुलर एक्सप्रेशन
- पैराग्राफ संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट बैकग्राउंड
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट रोटेशन
- रोटेशन एंगल
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटोफिट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टाबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अधिक को कस्टमाइज़ करें।"
---
## **अवलोकन**

यह लेख दर्शाता है कि कैसे Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट किया जा सकता है। इसमें हाइलाइटिंग, बैकग्राउंड रंग, ट्रांसपेरेंसी, अक्षर अंतराल, फ़ॉन्ट गुण, रोटेशन, पैराग्राफ स्पेसिंग, ऑटोफिट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप्स, और भाषा सेटिंग्स शामिल हैं।

नीचे दिए गए उदाहरणों में हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एक टेक्स्ट बॉक्स है और उसमें निम्नलिखित टेक्स्ट है:

![उदाहरण टेक्स्ट](sample_text.png)

## **टेक्स्ट को हाइलाइट करें**

जब आपको टेक्स्ट फ्रेम के भीतर किसी विशिष्ट नमूने से मेल खाने वाले टेक्स्ट को हाइलाइट करने की आवश्यकता हो तो [ITextFrame.HighlightText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlighttext/) मेथड का उपयोग करें। यह मेथड मेल खाने वाले टेक्स्ट फ़्रैगमेंट पर हाइलाइट रंग लागू करता है और इसे [ITextSearchOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextsearchoptions/) के साथ उपयोग किया जा सकता है ताकि खोज कैसे की जाए, उदाहरण के लिए केवल पूर्ण शब्दों के साथ मिलान, नियंत्रित किया जा सके।

निम्न कोड उदाहरण सभी **"try"** अक्षरों की घटनाओं को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// पहली स्लाइड से पहला आकार प्राप्त करें।
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// आकार में शब्द "try" को हाइलाइट करें।
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// आकार में शब्द "to" को हाइलाइट करें।
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![हाइलाइट किया गया टेक्स्ट](highlighted_text.png)

## **रेगुलर एक्सप्रेशन का उपयोग करके टेक्स्ट को हाइलाइट करें**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/highlightregex/) मेथड रेगुलर एक्सप्रेशन द्वारा खोजे गए टेक्स्ट मिलानों को हाइलाइट करता है। C++ में यह API [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) पर उपलब्ध है।

निम्न कोड उदाहरण सभी शब्दों को हाइलाइट करता है जिनमें **सात या अधिक अक्षर** हों:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![रेगुलर एक्सप्रेशन द्वारा हाइलाइट किया गया टेक्स्ट](highlighted_text_using_regex.png)

## **टेक्स्ट बैकग्राउंड रंग सेट करें**

डिफ़ॉल्ट पैराग्राफ हाइलाइट रंग सेट करने के लिए [IParagraphFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [IPortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformat/)`.HighlightColor` का उपयोग करें।

निम्न कोड उदाहरण **पूरे पैराग्राफ** के बैकग्राउंड रंग को सेट करता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the highlight color for the entire paragraph.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![धूसर पैराग्राफ](gray_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के बैकग्राउंड रंग को सेट करता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें।
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![धूसर टेक्स्ट भाग](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ को संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/)`.Alignment` का उपयोग करें। मान केंद्रित, बाएँ-संरेखित, दाएँ-संरेखित, समान रूप से विस्तारित आदि हो सकते हैं।

निम्न कोड उदाहरण पैराग्राफ को **केंद्र में** संरेखित करता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// पैराग्राफ का संरेखण केंद्र में सेट करें।
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **टेक्स्ट के लिए ट्रांसपेरेंसी सेट करें**

टेक्स्ट ट्रांसपेरेंसी को [IPortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformat/)`.FillFormat`. के रंग के अल्फा घटक द्वारा नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0‑255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि प्रतिशत ट्रांसपेरेंसी।

निम्न कोड उदाहरण **पूरे पैराग्राफ** पर ट्रांसपेरेंसी लागू करता है:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// टेक्स्ट का भरने का रंग पारदर्शी रंग में सेट करें।
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![ट्रांसपेरेंट पैराग्राफ](transparent_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर ट्रांसपेरेंसी लागू करता है:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // टेक्स्ट भाग की पारदर्शिता सेट करें।
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![ट्रांसपेरेंट टेक्स्ट भाग](transparent_text_portions.png)

## **टेक्स्ट के लिए अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को विस्तारित या घटाने के लिए [IBasePortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/)`.Spacing` का उपयोग करें।

निम्न C++ कोड **पूरे पैराग्राफ** में अक्षर अंतराल को विस्तारित करता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

निचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में अक्षर अंतराल को विस्तारित करता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए केरनिंग निष्क्रिय करें**

कभी‑कभी Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखने वाले टेक्स्ट से थोड़ा अधिक कसकर लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर किए गए आउटपुट को PowerPoint के करीब लाने के लिए आप प्रभावित फ़ॉन्ट के उपयोग वाले टेक्स्ट भागों के लिए केरनिंग को निष्क्रिय कर सकते हैं। [IPortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

यह सेटिंग मेल खाते टेक्स्ट भागों पर केरनिंग को लागू होने से रोकती है और इस PowerPoint‑विशिष्ट व्यवहार से प्रभावित फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint की दृश्य आउटपुट के साथ संगत बनाने में मदद करती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [IParagraphFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` के माध्यम से या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न कोड पूरे पैराग्राफ के लिए फ़ॉन्ट और टेक्स्ट शैली सेट करता है: यह सभी भागों पर फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन, और Times New Roman फ़ॉन्ट लागू करता है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें।
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर समान गुण लागू करता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // टेक्स्ट भाग के लिए फ़ॉन्ट गुण सेट करें।
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![टेक्स्ट भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट रोटेशन सेट करें**

शेप के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [ITextFrameFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` का उपयोग करें।

निम्न कोड उदाहरण शैप में टेक्स्ट अभिविन्यास को `Vertical270` पर सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिकालन दिशा में घुमाता** है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![टेक्स्ट रोटेशन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम रोटेशन सेट करें**

[ITextFrameFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/)`.RotationAngle` का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) के लिए कस्टम रोटेशन एंगल सेट किया जा सकता है।

निचे का कोड उदाहरण टेक्स्ट फ्रेम को शैप के भीतर 3 डिग्री घड़ी की दिशा में घुमाता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![कस्टम टेक्स्ट रोटेशन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides पैराग्राफ स्पेसिंग को नियंत्रण करने के लिए [IParagraphFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`, `IParagraphFormat.SpaceBefore`, और `IParagraphFormat.SpaceWithin` प्रदान करता है। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* पॉइंट में लाइन स्पेसिंग निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्न कोड उदाहरण पैराग्राफ के भीतर लाइन स्पेसिंग निर्दिष्ट करता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **टेक्स्ट फ्रेम के लिए ऑटोफिट प्रकार सेट करें**

[ITextFrameFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/)`.AutofitType` निर्धारित करता है कि जब टेक्स्ट अपने कंटेनर की सीमाओं से अधिक हो जाए तो वह कैसे व्यवहार करता है। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि टेक्स्ट छोटा हो, ओवरफ़्लो हो, या शैप को स्वचालित रूप से पुनः आकार दिया जाए।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[ITextFrameFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/)`.AnchoringType` परिभाषित करता है कि टेक्स्ट शैप के भीतर ऊर्ध्वाधर रूप से कैसे स्थित होगा, जैसे शीर्ष, मध्य या नीचे।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **टेक्स्ट टाब्युलेशन सेट करें**

पैराग्राफ में टैब स्टॉप्स को कॉन्फ़िगर करने के लिए [IParagraphFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` और `IParagraphFormat.Tabs` का उपयोग करें।

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

परिणाम:

![पैराग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [IPortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformat/)`.LanguageId` प्रदान करता है, जिससे आप किसी टेक्स्ट भाग के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिए उपयोग की गई भाषा को निर्धारित करती है।

निम्न कोड उदाहरण एक टेक्स्ट भाग के लिए प्रूफ़िंग भाषा सेट करता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// Set the Id of a proofing language.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **डिफ़ॉल्ट भाषा सेट करें**

लोड या प्रस्तुति बनाते समय बनाए गए टेक्स्ट के लिए डिफ़ॉल्ट भाषा निर्धारित करने के लिए [ILoadOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` का उपयोग करें।

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Add a new rectangle shape with text.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Check the first portion language.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रेजेंटेशन स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए [IPresentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle` का उपयोग करें।

निम्न कोड उदाहरण नई प्रस्तुति में सभी स्लाइडों के लिए 14 pt आकार के बोल्ड फ़ॉन्ट को डिफ़ॉल्ट टेक्स्ट स्टाइल के रूप में सेट करता है।

```cpp
auto presentation = System::MakeObject<Presentation>();

// शीर्ष स्तर का पैराग्राफ फ़ॉर्मेट प्राप्त करें।
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ऑल‑कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही इसे मूल रूप में छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसे टेक्स्ट भाग को प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को मूल रूप में ही लौटाती है। प्रदर्शित टेक्स्ट से मेल खाने के लिए [TextCapType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textcaptype/) की जाँच करें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में परिवर्तित करें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्न टेक्स्ट बॉक्स है।

![ऑल कैप्स इफ़ेक्ट](all_caps_effect.png)

निम्न कोड उदाहरण **All Caps** इफ़ेक्ट लागू किए हुए टेक्स्ट को निकालता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```

आउटपुट:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **सामान्य प्रश्न**

**स्लाइड पर तालिका में टेक्स्ट को कैसे संशोधित करें?**

स्लाइड पर तालिका में टेक्स्ट को संशोधित करने के लिए [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से इटरैट करें और प्रत्येक कोशिका को [ICell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icell/)`.TextFrame` तथा पैराग्राफ फ़ॉर्मेट को [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/)`.ParagraphFormat` के माध्यम से अपडेट करें।

**PowerPoint स्लाइड में टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए [IPortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportionformat/)`.FillFormat` का उपयोग करें। [IFillFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ifillformat/)`.FillType` को [FillType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/filltype/)`.Gradient` पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशा, तथा ट्रांसपेरेंसी को कॉन्फ़िगर करें।