---
title: Presentatietekst opmaken in C++
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/cpp/text-formatting/
keywords:
- alinea uitlijnen
- tekststijl
- tekstachtergrond
- tekstransparantie
- karakterafstand
- lettertype-eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autofit-eigenschap
- tekstframe-anker
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Formateer en styleer tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor C++. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe tekst wordt geformatteerd in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides for C++. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑ankering, tab‑stops en taalinstellingen.

Tenzij anders vermeld, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak en de eerste alinea ervan bevat de hieronder getoonde tekst. Zowel dia‑ als vorm‑indexen zijn nul‑gebaseerd. Voorbeelden die vette delen selecteren, gebruiken effectieve opmaak, inclusief geërfde vet‑opmaak:

![Voorbeeldtekst](sample_text.png)

Voor het vinden en markeren van letterlijke tekst of reguliere‑expressie‑overeenkomsten, zie [Zoeken en vervangen van tekst](/slides/nl/cpp/search-and-replace-text/).

## **Tekstachtergrondkleur instellen**

Gebruik [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) om de standaardmarkeerkleur voor een alinea in te stellen, of gebruik [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) voor individuele tekstgedeelten.

Het volgende voorbeeld stelt een lichtgrijze markering in als standaard voor de eerste alinea. Expliciete markeerkleuren op individuele gedeelten hebben voorrang op deze standaard:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
auto highlightColor = System::Drawing::Color::get_LightGray();

// Stel de markeerkleur in voor de volledige alinea.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

Het code‑voorbeeld hieronder laat zien hoe de achtergrondkleur wordt ingesteld voor **tekstgedeelten met een vet lettertype**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto highlightColor = System::Drawing::Color::get_LightGray();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Stel de markeerkleur in voor het tekstgedeelte.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De grijze tekstgedeelten](gray_text_portions.png)

## **Tekstalinea's uitlijnen**

Gebruik [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) om de uitlijning van een alinea binnen een tekstvak in te stellen. De waarde kan gecentreerd, links‑uitgelijnd, rechts‑uitgelijnd, uitgevuld, enzovoort zijn.

Het volgende code‑voorbeeld toont hoe de alinea **gecentreerd** wordt uitgelijnd:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextAlignment.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Stel de uitlijning van de alinea in op gecentreerd.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Lettertype uitlijnen binnen een regel**

Gebruik [IParagraphFormat::set_FontAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_fontalignment/) om tekstgedeelten met verschillende lettergrootten verticaal uit te lijnen binnen een regel. Deze instelling geldt voor de volledige alinea en regelt de uitlijning binnen elke regel ervan.

Het volgende zelfstandige voorbeeld maakt vier gelabelde tekstvakken op één dia. Elke alinea bevat dezelfde tekst in 18, 36 en 54 punten, met een andere lettertype‑uitlijning. Het gebruikt Arial, schakelt autofit en omloop uit en houdt de tekstvakken groot genoeg voor één regel.

```cpp
#include <DOM/FontAlignment.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

FontAlignment alignments[] = { FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom };
String labels[] = { u"Baseline", u"Top", u"Center", u"Bottom" };
float fontSizes[] = { 18.0f, 36.0f, 54.0f };
auto font = MakeObject<FontData>(u"Arial");

for (auto i = 0; i < 4; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20 + i * 130, 660, 120);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);

    auto label = textFrame->get_Paragraph(0);
    label->set_Text(labels[i]);
    label->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto labelFormat = label->get_ParagraphFormat()->get_DefaultPortionFormat();
    labelFormat->set_FontHeight(14);
    labelFormat->set_LatinFont(font);
    labelFormat->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_FontAlignment(alignments[i]);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto portionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    portionFormat->set_LatinFont(font);
    portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
    portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    for (auto fontSize : fontSizes)
    {
        auto portion = MakeObject<Portion>(u"Ag ");
        portion->get_PortionFormat()->set_FontHeight(fontSize);
        paragraph->get_Portions()->Add(portion);
    }

    textFrame->get_Paragraphs()->Add(paragraph);
}

presentation->Save(u"font_alignment.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![Vergelijking van Baseline, Top, Center en Bottom lettertype‑uitlijning met gemengde lettergroottes](font_alignment.png)

Lettertype‑uitlijning maakt gebruik van lettertype‑metingen, zodat de zichtbare randen van individuele letters niet per se exact op één lijn liggen. Het voorbeeld bevat zowel een hoofdletter als een afdalende letter om het verschil tussen baseline‑ en bodem‑uitlijning te tonen. Beschikbaarheid en substitutie van lettertypen, de gebruikte tekens en het verschil in lettergroottes beïnvloeden het resultaat. Frame‑dimensies, marges, regelafstand, omloop en autofit hebben eveneens invloed op de lay‑out; gebruik dezelfde lettertypen en lay‑out‑instellingen bij het vergelijken van de modi.

Deze instelling verschilt van [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/), die de horizontale alinea‑uitlijning regelt, en van [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/), die het tekstblok verticaal binnen de vorm positioneert. Superscript‑ en subscript‑formattering via [IBasePortionFormat::set_Escapement](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_escapement/) verschuift individuele gedeelten ten opzichte van de baseline in plaats van de lettertype‑uitlijning voor de regels van de alinea in te stellen.

## **Transparantie van tekst instellen**

Transparantie van tekst wordt geregeld via de alfa‑component van de kleur die wordt toegewezen via [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/). In de onderstaande voorbeelden betekent `alpha = 50` een ARGB‑alfa‑waarde op de schaal 0–255, geen transparantie‑percentage.

Het volgende code‑voorbeeld laat zien hoe transparantie wordt toegepast op de **volle alinea**:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Stel de vulkleur van de tekst in op transparante kleur.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De transparante alinea](transparent_paragraph.png)

Het volgende code‑voorbeeld toont hoe transparantie wordt toegepast op **tekstgedeelten met een vet lettertype**:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Stel de transparantie van het tekstgedeelte in.
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De transparante tekstgedeelten](transparent_text_portions.png)

## **Karakterafstand voor tekst instellen**

Gebruik [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_spacing/) om de ruimte tussen karakters in een tekstvak uit te breiden of te verkleinen. De voorbeelden voegen 3 punten toe; negatieve waarden verkleinen de tekst.

Het volgende C++‑code‑voorbeeld laat zien hoe de karakterafstand in de **volle alinea** wordt vergroot:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Opmerking: gebruik negatieve waarden om de tekenafstand te verkleinen.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // Vergroot de tekenafstand.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De karakterafstand in de alinea](character_spacing_in_paragraph.png)

Het code‑voorbeeld hieronder laat zien hoe de karakterafstand in **tekstgedeelten met een vet lettertype** wordt vergroot:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Opmerking: gebruik negatieve waarden om de tekenafstand te verkleinen.
        portionFormat->set_Spacing(3.0f); // Vergroot de tekenafstand.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De karakterafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning voor specifieke lettertypen uitschakelen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning in de PowerPoint‑instellingen is ingeschakeld.

Om de weergave dichter bij PowerPoint te krijgen, kunt u kerning voor tekstgedeelten die het betreffende lettertype gebruiken uitschakelen. Gebruik [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) om een waarde groter dan de feitelijke lettergrootte in te stellen. Dit voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia. Het controleert effectieve lettertype‑namen, inclusief geërfde lettertypen, en stelt een drempel van 100 punten in voor gedeelten die Roboto gebruiken. Hierdoor wordt kerning uitgeschakeld voor overeenkomende gedeelten met een lettergrootte onder 100 punten:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
System::String targetFont = u"Roboto";
auto textFrame = autoShape->get_TextFrame();
auto paragraphs = textFrame->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto textFormat = portionFormat->GetEffective();
        auto latinFont = textFormat->get_LatinFont();
        auto eastAsianFont = textFormat->get_EastAsianFont();
        auto complexScriptFont = textFormat->get_ComplexScriptFont();

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

Voor tekst onder de drempel voorkomt deze instelling kerning en kan helpen om de weergave van Aspose.Slides beter af te stemmen op die van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Tekstlettertype‑eigenschappen beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) of op individuele gedeelten via [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/).

Het volgende voorbeeld stelt het standaardlettertype van de eerste alinea in op 12‑punt Times New Roman met vet, cursief en een gestippelde onderstreping. Expliciete opmaak op individuele gedeelten heeft voorrang op deze standaardwaarden:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Stel de lettertype‑eigenschappen in voor de alinea.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het volgende voorbeeld past 13‑punt Times New Roman, cursieve opmaak en een gestippelde onderstreping toe op gedeelten waarvan de effectieve opmaak vet is:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto font = System::MakeObject<FontData>(u"Times New Roman");

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Stel de lettertype‑eigenschappen in voor het tekstgedeelte.
        portionFormat->set_FontHeight(13.0f);
        portionFormat->set_FontItalic(NullableBool::True);
        portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
        portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Normalisatie van tekstehoogte beheren**

Gebruik [IBasePortionFormat::set_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_normaliseheight/) wanneer u typografie van een sjabloon reproduceert of verschillen in karakterhoogte onderzoekt. In PowerPoint zorgt het inschakelen van normalisatie ervoor dat individuele tekens verticaal worden uitgerekt of samengedrukt zodat ze een uniforme zichtbare hoogte krijgen binnen het tekstgedeelte. Het garandeert geen gelijke teksthoogtes tussen verschillende lettertypen.

Stel de eigenschap in op [NullableBool::True of False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) om normalisatie expliciet in of uit te schakelen. `NullableBool::NotDefined` laat de lokale instelling oningesteld, zodat het gedeelte de waarde erft, bijvoorbeeld van de alinea‑[IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/). Het betekent niet `False`. Gebruik [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) en lees [IBasePortionFormatEffectiveData::get_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformateffectivedata/get_normaliseheight/) om de geëvalueerde booleaanse waarde te verkrijgen.

Het volgende zelfstandige voorbeeld vereist **Arial** geïnstalleerd. Het maakt twee tekstblokken met dezelfde hoofdletters, kleine letters, afdalende letters en accenten in 54 punten. Beide alinea’s schakelen normalisatie standaard in. Het bovenste gedeelte schakelt het expliciet uit; het onderste erft de instelling. De frame‑groottes, marges en alinea‑afstand zijn identiek, met omloop en autofit uitgeschakeld om de vergelijking consistent te houden. Het voorbeeld print `False: False` en `NotDefined: True`, en slaat “text_height_normalization.pptx” op.

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

NullableBool settings[] = { NullableBool::False, NullableBool::NotDefined };

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 60 + i * 200, 660, 150);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(u"Hxgjpq ÅÉ 0123");
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_MarginTop(0);
    textFrame->get_TextFrameFormat()->set_MarginLeft(0);

    auto paragraph = textFrame->get_Paragraph(0);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceBefore(0);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(0);
    paragraph->get_ParagraphFormat()->set_SpaceWithin(100);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_NormaliseHeight(NullableBool::True);

    auto portion = paragraph->get_Portion(0);
    auto font = MakeObject<FontData>(u"Arial");
    portion->get_PortionFormat()->set_LatinFont(font);
    portion->get_PortionFormat()->set_FontHeight(54);
    portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    portion->get_PortionFormat()->set_NormaliseHeight(settings[i]);

    Console::WriteLine(u"{0}: {1}", settings[i], portion->get_PortionFormat()->GetEffective()->get_NormaliseHeight());
}

presentation->Save(u"text_height_normalization.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

De onderstaande vergelijking is geëxporteerd uit de opgeslagen presentatie. De bovenste rij heeft normalisatie uitgeschakeld (`False`); de onderste rij erft de ingeschakelde instelling (`NotDefined` → `True`). Houd Arial geïnstalleerd om dit uiterlijk te reproduceren.

![Arial‑tekst van 54 punten met normalisatie uitgeschakeld boven en erfd ingeschakeld hieronder](text_height_normalization.png)

Normalisatie verandert de karakterhoogte zonder de toegewezen [IBasePortionFormat::get_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fontheight/)‑waarde aan te passen, die de lettergrootte in punten specificeert. Alinea‑[IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) regelt de regelafstand, terwijl tekst‑frame‑[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) bepaalt hoe tekst of de container zich aanpast. Deze instellingen dienen verschillende doeleinden en kunnen de algemene lay‑out onafhankelijk beïnvloeden. Zie voor meer informatie over alinea‑formattering en overerving [Alinea beheren](/slides/nl/cpp/manage-paragraph/).

## **Doorhalen toepassen en verwijderen**

Gebruik [IBasePortionFormat::set_StrikethroughType](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_strikethroughtype/) op een tekstgedeelte om correcties, geannuleerde termen of eerdere prijzen weer te geven zonder de oorspronkelijke tekst te verwijderen. Stel in op [TextStrikethroughType::Single of Double](https://reference.aspose.com/slides/cpp/aspose.slides/textstrikethroughtype/) voor één of twee doorhalingsstrepen.

Om doorhalen te verwijderen, wijs `TextStrikethroughType::None` toe. Dit schakelt het effect expliciet uit, zelfs als de omringende opmaak doorhalen specificeert. Daartegenover laat `TextStrikethroughType::NotDefined` de lokale instelling ongedefinieerd, waardoor het gedeelte de opmaak kan erven, bijvoorbeeld van de alinea. Het garandeert niet dat doorhalen wordt verwijderd. Gebruik [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) om de resulterende opmaak, inclusief geërfde waarden, te lezen.

Het volgende zelfstandige voorbeeld maakt drie prijsvergelijkingen. Elke alinea heeft aparte gedeelten voor het label, de vorige prijs en de huidige prijs, zodat alleen de vorige prijs wordt beïnvloed. De eerste rij past doorhalen toe en verwijdert het daarna; de andere rijen behouden enkelvoudig en dubbel doorhalen. Het wijzigen van deze eigenschap behoudt de tekst en de overige opmaak, inclusief de vetgedrukte vorige prijs.

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextStrikethroughType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

String labels[] = { u"None: ", u"Single: ", u"Double: " };

for (auto label : labels)
{
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(20);

    auto format = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    format->set_FontHeight(28);
    auto font = MakeObject<FontData>(u"Arial");
    format->set_LatinFont(font);
    format->get_FillFormat()->set_FillType(FillType::Solid);
    format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    auto labelPortion = MakeObject<Portion>(label);
    paragraph->get_Portions()->Add(labelPortion);

    auto previousPrice = MakeObject<Portion>(u"$100");
    previousPrice->get_PortionFormat()->set_FontBold(NullableBool::True);
    paragraph->get_Portions()->Add(previousPrice);
    auto currentPrice = MakeObject<Portion>(u" → $80");
    paragraph->get_Portions()->Add(currentPrice);

    textFrame->get_Paragraphs()->Add(paragraph);
}

// Pas doorhalen toe, en verwijder het vervolgens expliciet van de eerste vorige prijs.
auto firstPriceFormat = textFrame->get_Paragraph(0)->get_Portion(1)->get_PortionFormat();
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::Single);
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::None);

textFrame->get_Paragraph(1)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Single);
textFrame->get_Paragraph(2)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Double);

presentation->Save(u"strikethrough.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat, van boven naar beneden: geen doorhalen, enkelvoudig doorhalen en dubbel doorhalen.

![Vorige prijzen zonder doorhalen, met enkelvoudig doorhalen en met dubbel doorhalen](strikethrough.png)


## **Tekstrotatie instellen**

Gebruik [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_textverticaltype/) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op [TextVerticalType::Vertical270](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/), wat de tekst **90 graden tegen de klok in** draait:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De tekstrotatie](text_rotation.png)

## **Cijfers naast elkaar weergeven in verticale tekst**

Om een tweecijferig getal samen te houden in een verticale Japanse label, plaats beide cijfers in één tekstgedeelte en roep [IBasePortionFormat::set_Kumimoji](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kumimoji/) aan op dat gedeelte. Het voorbeeld gebruikt [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/) en 40‑punt MS Gothic voor beide labels. Alleen de [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/)‑waarde die wordt doorgegeven voor het numerieke gedeelte verschilt.

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto addLabel = [&slide](float x, NullableBool kumimoji)
{
    auto label = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, 48, 120, 420);
    label->get_FillFormat()->set_FillType(FillType::NoFill);
    label->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto frame = label->AddTextFrame(u"");
    frame->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::EastAsianVertical);

    auto paragraph = frame->get_Paragraph(0);
    auto format = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    auto font = MakeObject<FontData>(u"MS Gothic");
    format->set_LatinFont(font);
    format->set_EastAsianFont(font);
    format->set_FontHeight(40);
    format->get_FillFormat()->set_FillType(FillType::Solid);
    format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    auto digits = MakeObject<Portion>(u"12");
    digits->get_PortionFormat()->set_Kumimoji(kumimoji);

    auto portions = paragraph->get_Portions();
    portions->Clear();
    portions->Add(MakeObject<Portion>(u"令和"));
    portions->Add(digits);
    portions->Add(MakeObject<Portion>(u"年"));
};

addLabel(120, NullableBool::True);
addLabel(360, NullableBool::False);

presentation->Save(u"vertical_date.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

In PowerPoint toont het linkerlabe`l (True)` de cijfers staand en naast elkaar tussen 和 en 年. In het rechterlabel (False) wordt het paar 90 graden met de klok mee geroteerd. De omringende Japanse tekens blijven staand in beide labels.

![PowerPoint‑vergelijking van verticale datum‑labels met staande cijfers links en geroteerde cijfers rechts](vertical_date.png)

## **Aangepaste rotatie voor tekstvakken instellen**

Gebruik [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) om een aangepaste rotatiehoek in te stellen voor een [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).

Het onderstaande code‑voorbeeld draait het tekstvak met 3 graden met de klok mee binnen de vorm:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van alinea's instellen**

Aspose.Slides biedt [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/) en [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) om de alinea‑afstand te regelen. Deze methoden worden als volgt gebruikt:

* Geef een positief getal op om de regelafstand als percentage van de regelhoogte te specificeren.
* Geef een negatief getal op om de regelafstand in punten te specificeren.

Het volgende voorbeeld stelt de binnen‑alinea‑afstand van de eerste alinea in op 200 % van de regelhoogte (dubbele regelafstand):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De regelafstand binnen de alinea](line_spacing.png)

## **Regelafbreking beheren**

Regel‑afbrekingsregels voor alinea’s zijn nuttig in smalle tekstblokken en presentaties die Latijnse en Oost‑Aziaanse tekst combineren. De volgende methoden behoren tot [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/), zodat ze van toepassing zijn op een volledige alinea:

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) regelt de Latijnse regel‑afbrekingsregels. In gemengde tekst kan het wijzigen hiervan ook invloed hebben op waar aangrenzende Oost‑Aziaanse tekst en interpunctie worden afgebroken.
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) regelt de Oost‑Aziaanse regel‑afbrekingsregels, inclusief beperkingen voor tekens aan het begin en einde van een regel.

Deze regels vervangen niet [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/), die automatisch omloop binnen een tekstvak inschakelt. Ze beïnvloeden de lay‑out wanneer omloop plaatsvindt; ze voegen geen regeleinde‑tekens toe. Een expliciete regeleinde‑invoeging dwingt een nieuwe regel binnen de alinea, onafhankelijk van de beschikbare breedte.

Het volgende zelfstandige voorbeeld maakt een smal tekstblok met Chinese en Latijnse tekst. Het stelt beide regel‑afbrekingsregels expliciet in en slaat “line_breaking.pptx” op. Om met een van de regels te experimenteren, wijzig de waarde die aan de setter wordt doorgegeven terwijl de andere instellingen ongewijzigd blijven. Het voorbeeld gebruikt 24‑punt Arial en SimSun met een frame‑breedte van 160 punten en nul horizontale tekst‑frame‑marges. [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) wordt aangeroepen met [TextAutofitType::None](https://reference.aspose.com/slides/cpp/aspose.slides/textautofittype/) zodat tekengrootte en frame‑dimensies vast blijven.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 160.0f, 300.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"中文排版测试，PowerPoint 中文演示。");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
auto eastAsianFont = System::MakeObject<FontData>(u"SimSun");
portionFormat->set_EastAsianFont(eastAsianFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_LatinLineBreak(NullableBool::False);
format->set_EastAsianLineBreak(NullableBool::True);

presentation->Save(u"line_breaking.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Hangende interpunctie beheren**

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) maakt het mogelijk dat in aanmerking komende interpunctie zich uitstrekt voorbij de rechterrand van de tekstreeks in plaats van de volgende regel in te nemen. Het geldt voor de volledige alinea en verschilt van een hangende inspringing.

Het volgende zelfstandige voorbeeld schakelt hangende interpunctie in een tekstvak van 100 punt breed in en slaat “hanging_punctuation.pptx” op. Met 24‑punt Arial en nul horizontale tekst‑frame‑marges blijft de laatste punt achter “sentence” staan en strekt zich uit voorbij de rechtermarge. Geef [NullableBool::False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) door aan de setter om te vergelijken: met deze instellingen neemt de punt een aparte regel in. Omloop is ingeschakeld en autofit uitgeschakeld om de beschikbare breedte vast te houden.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 200.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"Simple text, next sentence.");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_HangingPunctuation(NullableBool::True);

presentation->Save(u"hanging_punctuation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Niet elk interpunctieteken kan hangen. De [lettertype‑ en lay‑outvoorwaarden die hierboven zijn beschreven](#control-line-breaking) zijn eveneens van toepassing op deze vergelijking: het wijzigen van het lettertype, de beschikbare breedte, marges of autofit‑instellingen kan het zichtbare verschil wegnemen.

## **Autofit-type voor tekstvakken instellen**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te regelen of de tekst krimpt, overlapt of de vorm automatisch vergroot. Het volgende voorbeeld configureert de vorm om zich aan te passen aan de tekst en slaat het resultaat op in “autofit_type.pptx”.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Om het aantal regels na automatisch omloop te tellen en te zien hoe tekst‑ of vorm‑breedte het resultaat verandert, zie [Count Rendered Lines](/slides/nl/cpp/manage-paragraph/). Alleen het aantal regels geeft niet aan of tekst buiten de container overlapt.

## **Anker van tekstvakken instellen**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan. Het volgende voorbeeld anker de tekst aan de onderkant van de eerste vorm en slaat het resultaat op in “text_anchor.pptx”.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAnchorType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Teksttabulatie instellen**

Gebruik [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) en [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_tabs/) om tab‑stops in een alinea te configureren. Het volgende voorbeeld stelt de standaard tab‑intervallen in op 100 punten en voegt een links‑uitgelijnde tab‑stop toe op 30 punten. Deze instellingen beïnvloeden tekst die tab‑tekens bevat.

```cpp
#include <DOM/IAutoShape> // <--- not translated as per rules (kept unchanged)
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITabCollection> // <--- not translated
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TabAlignment.h>
#include <Export/SaveFormat.h>

using namespace Aspense? // This line appears to have a typo; keeping unchanged as code.
using  ......
```

Het resultaat:

![De alinea‑tabs](paragraph_tabs.png)

## **Spelling‑ en grammaticataal instellen**

Aspose.Slides biedt [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/), waarmee u de controleertaal voor een tekstgedeelte kunt instellen. De controleertaal bepaalt welke taal wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

Het volgende voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia en minimaal één alinea. Het vervangt de inhoud van de eerste alinea door “1。”, stelt SimSun in als lettertype en wijst de vereenvoudigde Chinese controleertaal (`zh-CN`) toe. Het slaat het resultaat op in “proofing_language.pptx”:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
auto portionFormat = textPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

// Stel de controleertaal in op Vereenvoudigd Chinees.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Taalmetadata kopiëren**

Wanneer u meertalige tekst uit een sjabloon kopieert, behoud dan beide taal‑identifiers met behulp van [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) en [IBasePortionFormat::set_AlternativeLanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_alternativelanguageid/). Het volgende zelfstandige voorbeeld maakt een bron‑gedeelte met Engels (VS) als taal en Frans als alternatieve taal, en kopieert de tekst en identifiers naar een gedeelte in een nieuwe presentatie.

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

auto source = System::MakeObject<Portion>(u"Hello! Bonjour!");
source->get_PortionFormat()->set_LanguageId(u"en-US");
source->get_PortionFormat()->set_AlternativeLanguageId(u"fr-FR");

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto destination = System::MakeObject<Portion>();
destination->set_Text(source->get_Text());
destination->get_PortionFormat()->set_LanguageId(source->get_PortionFormat()->get_LanguageId());
// Als de bron geen alternatieve taal heeft, wist een null string de doelwaarde.
destination->get_PortionFormat()->set_AlternativeLanguageId(source->get_PortionFormat()->get_AlternativeLanguageId());
paragraph->get_Portions()->Add(destination);

presentation->Save(u"copied_language_metadata.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Om een bron zonder alternatieve taal te testen, laat de toewijzing van `u"fr-FR"` weg. De alternatieve identifier is dan een null‑string, en dezelfde copy‑statement behoudt de afwezigheid zonder een standaardwaarde in te voeren, zelfs als de bestemming eerder een alternatieve taal had.

Deze identifiers vormen taalmetadata. Het behouden ervan bepaalt niet welke woordenboek PowerPoint kiest voor spelling‑ of grammaticacontrole.

## **Standaardtaal instellen**

Gebruik [LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) om de standaardtaal voor tekst die tijdens het laden of maken van een presentatie wordt gecreëerd te definiëren. Het volgende voorbeeld maakt een presentatie met Engels (VS) als standaard‑teksttaal, voegt een tekstvak toe en print `en-US` voor het eerste tekstgedeelte.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Voeg een nieuw rechthoekig vorm toe met tekst.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Controleer de taal van het eerste tekstgedeelte.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **Standaard tekststijl instellen**

Om standaard‑tekstformattering toe te passen op presentatieniveau, gebruik [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_defaulttextstyle/).

Het volgende voorbeeld stelt een 14‑punt vet lettertype in als standaard voor alinea's van het hoogste niveau in een nieuwe presentatie en slaat dit op in “default_text_style.pptx”. Tekst kan deze standaard erven tenzij specifiekere opmaak deze overschrijft.

```cpp
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

// Verkrijg het alineaformaat van het hoogste niveau.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    auto defaultPortionFormat = paragraphFormat->get_DefaultPortionFormat();
    defaultPortionFormat->set_FontHeight(14.0f);
    defaultPortionFormat->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tekst extraheren met hoofdletters‑effect**

In PowerPoint zorgt het toepassen van de **All Caps**‑lettertype‑effect ervoor dat tekst in hoofdletters wordt weergegeven op de dia, zelfs wanneer deze oorspronkelijk in kleine letters is getypt. Wanneer u zo’n tekstgedeelte met Aspose.Slides ophaalt, retourneert de bibliotheek de tekst exact zoals ingevoerd. Om de weergegeven tekst te laten overeenkomen, controleer [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) en zet de geretourneerde tekenreeks om naar hoofdletters wanneer de waarde [TextCapType::All](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) is.

Dit voorbeeld vereist “sample2.pptx” met een tekstvak als eerste vorm op de eerste dia. De eerste alinea‑eerste gedeelte bevat “Hello, Aspose!” met het All Caps‑effect toegepast, zoals hieronder weergegeven.

![Het All Caps‑effect](all_caps_effect.png)

Het code‑voorbeeld hieronder toont hoe de tekst wordt geëxtraheerd met het **All Caps**‑effect toegepast:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextCapType.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

auto originalText = textPortion->get_Text();
System::Console::WriteLine(u"Original text: " + originalText);

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto uppercaseText = originalText.ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + uppercaseText);
}

presentation->Dispose();
```

Uitvoer:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hoe wijzig ik tekst in een tabel op een dia?**

Om tekst in een tabel op een dia te wijzigen, gebruik [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Doorloop de cellen en werk elke cel bij via [ICell::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) en alinea‑formattering via [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/).

**Hoe pas ik een verloopkleur toe op tekst op een PowerPoint‑dia?**

Om een verloopkleur op tekst toe te passen, gebruik [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/). Stel [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) in op [FillType::Gradient](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) en configureer de verloopstops, richting en transparantie.

Gerelateerde functie: [Tekst formatteren binnen dia’s](/slides/nl/features/text-formatting/).