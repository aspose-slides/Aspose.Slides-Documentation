---
title: Opmaak van presentatie‑tekst in C++
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/cpp/text-formatting/
keywords:
- tekst markeren
- reguliere expressie
- alinea uitlijnen
- tekststijl
- tekstachtergrond
- teksttransparantie
- tekenafstand
- lettertype‑eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autofit‑eigenschap
- tekstframe‑anker
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Formateer en style tekst in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor C++. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst formatteert in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor C++. Het behandelt markering, achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑ankering, tab‑stops en taalinstellingen.

In de onderstaande voorbeelden gebruiken we een bestand genaamd "sample.pptx", dat een enkele tekstvak bevat op de eerste dia met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Tekst markeren**

Gebruik de [ITextFrame.HighlightText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlighttext/) methode wanneer u tekst wilt markeren die overeenkomt met een specifiek voorbeeld binnen een tekstframe. De methode past een markeerkleur toe op overeenkomende tekstfragmenten en kan samen met [ITextSearchOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextsearchoptions/) worden gebruikt om te bepalen hoe de zoekopdracht wordt uitgevoerd, bijvoorbeeld om alleen volledige woorden te matchen.

Het codevoorbeeld hieronder markeert alle voorkomen van de tekens **"try"** en markeert vervolgens alleen het volledige woord **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// Haal de eerste vorm op van de eerste dia.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Markeer het woord "try" in de vorm.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Markeer het woord "to" in de vorm.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De gemarkeerde tekst](highlighted_text.png)

## **Tekst markeren met reguliere expressies**

De [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/highlightregex/) methode markeert tekst die door een reguliere expressie wordt gevonden. In C++ wordt deze API blootgesteld via [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/).

Het codevoorbeeld hieronder markeert alle woorden die **zeven of meer tekens** bevatten:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De gemarkeerde tekst met de reguliere expressie](highlighted_text_using_regex.png)

## **Achtergrondkleur van tekst instellen**

Gebruik [IParagraphFormat]`.DefaultPortionFormat` om de standaard markeerkleur voor een alinea in te stellen, of gebruik [IPortionFormat]`.HighlightColor` voor individuele tekstgedeelten.

De volgende codevoorbeeld toont hoe u de achtergrondkleur voor de **hele alinea** instelt:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the highlight color for the entire paragraph.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

Het codevoorbeeld hieronder laat zien hoe u de achtergrondkleur voor **tekstgedeelten met een vet lettertype** instelt:

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
        // Stel de markeerkleur in voor het tekstgedeelte.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De grijze tekstgedeelten](gray_text_portions.png)

## **Tekst alinea's uitlijnen**

Gebruik [IParagraphFormat]`.Alignment` om de alineauitzetting binnen een tekstframe in te stellen. De waarde kan gecentreerd, links uitgelijnd, rechts uitgelijnd, uitgevuld, enzovoort zijn.

De volgende codevoorbeeld toont hoe u de alinea naar het **midden** uitlijnt:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Stel de uitlijning van de alinea in op midden.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Transparantie van tekst instellen**

Teksttransparantie wordt geregeld via het alfa‑component van de kleur die is toegewezen aan [IPortionFormat]`.FillFormat`. In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfa‑kanaalwaarde op de 0‑255 schaal, geen transparantie‑percentage.

Het codevoorbeeld hieronder toont hoe u transparantie toepast op de **hele alinea**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Set the fill color of the text to transparent color.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De transparante alinea](transparent_paragraph.png)

Het volgende codevoorbeeld toont hoe u transparantie toepast op **tekstgedeelten met een vet lettertype**:

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
        // Stel de transparantie van het tekstgedeelte in.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De transparante tekstgedeelten](transparent_text_portions.png)

## **Lettertekenafstand voor tekst instellen**

Gebruik [IBasePortionFormat]`.Spacing` om de tussenruimte tussen tekens in een tekstvak uit te breiden of te verkleinen.

De volgende C++‑code toont hoe u de tekenafstand in de **hele alinea** uitbreidt:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Opmerking: gebruik negatieve waarden om de tekenafstand te verkleinen.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

Het codevoorbeeld hieronder toont hoe u de tekenafstand uitbreidt in **tekstgedeelten met een vet lettertype**:

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
        // Opmerking: gebruik negatieve waarden om de tekenafstand te verkleinen.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning uitschakelen voor specifieke lettertypen**

In sommige gevallen kan de tekst die door Aspose.Slides wordt gerenderd er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de gerenderde output in dergelijke gevallen dichter bij PowerPoint te brengen, kunt u kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [IPortionFormat]`.KerningMinimalSize` in op een waarde die aanzienlijk groter is dan de werkelijke lettergrootte:

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

Deze instelling voorkomt dat kerning wordt toegepast op overeenkomende tekstgedeelten en kan helpen de weergave van Aspose.Slides beter te laten overeenkomen met de visuele output van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Lettertype‑eigenschappen van tekst beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [IParagraphFormat]`.DefaultPortionFormat` of op individuele gedeelten via [IPortionFormat]`.

De volgende code stelt het lettertype en de tekststijl in voor de hele alinea: het past lettergrootte, vet, cursief, gestippelde onderstreping en het Times New Roman‑lettertype toe op alle gedeelten in de alinea.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Stel de lettertype‑eigenschappen in voor de alinea.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het codevoorbeeld hieronder past soortgelijke eigenschappen toe op **tekstgedeelten met een vet lettertype**:

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
        // Stel de lettertype‑eigenschappen in voor het tekstgedeelte.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Tekstrotatie instellen**

Gebruik [ITextFrameFormat]`.TextVerticalType` om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

De volgende codevoorbeeld stelt de tekstoriëntatie in de vorm in op `Vertical270`, wat de tekst **90 graden tegen de klok in** roteert:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De tekstrotatie](text_rotation.png)

## **Aangepaste rotatie voor tekstframes instellen**

Gebruik [ITextFrameFormat]`.RotationAngle` om een aangepaste rotatiehoek in te stellen voor een [ITextFrame].

Het codevoorbeeld hieronder draait het tekstframe met 3 graden met de klok mee binnen de vorm:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van alinea's instellen**

Aspose.Slides biedt [IParagraphFormat]`.SpaceAfter`, `IParagraphFormat.SpaceBefore` en `IParagraphFormat.SpaceWithin` om alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand op te geven als een percentage van de regelhoogte.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

De volgende codevoorbeeld toont hoe u de regelafstand binnen de alinea opgeeft:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De regelafstand binnen de alinea](line_spacing.png)

## **Autopasstype voor tekstframes instellen**

[ITextFrameFormat]`.AutofitType` bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te bepalen of de tekst verkleint, overlapt of de vorm automatisch schaalt.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Anker van tekstframes instellen**

[ITextFrameFormat]`.AnchoringType` bepaalt hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Teksttabulatie instellen**

Gebruik [IParagraphFormat]`.DefaultTabSize` en `IParagraphFormat.Tabs` om tab‑stops in een alinea te configureren.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De alinea‑tabs](paragraph_tabs.png)

## **Bewijstaal instellen**

Aspose.Slides biedt [IPortionFormat]`.LanguageId`, waarmee u de bewijs‑taal voor een tekstgedeelte kunt instellen. De bewijs‑taal bepaalt de taal die wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

De volgende codevoorbeeld toont hoe u de bewijs‑taal voor een tekstgedeelte instelt:

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

// Stel de Id van een bewijstaal in.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Standaardtaal instellen**

Gebruik [ILoadOptions]`.DefaultTextLanguage` om de standaardtaal voor tekst te definiëren die wordt aangemaakt tijdens het laden of maken van een presentatie.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Voeg een nieuwe rechthoekvorm met tekst toe.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Controleer de taal van het eerste tekstgedeelte.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Standaardtekststijl instellen**

Om standaardtekstformattering op presentatieniveau toe te passen, gebruik [IPresentation]`.DefaultTextStyle`.

De volgende codevoorbeeld toont hoe u een standaard vet lettertype met een grootte van 14 pt instelt voor alle tekst op alle dia's in een nieuwe presentatie.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Haal het bovenste alinea‑formaat op.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tekst extraheren met het ALL‑CAPS‑effect**

In PowerPoint zorgt het toepassen van het **All Caps**‑font‑effect ervoor dat tekst in hoofdletters op de dia wordt weergegeven, zelfs wanneer deze oorspronkelijk in kleine letters is getypt. Wanneer u zo’n tekstgedeelte ophaalt met Aspose.Slides, retourneert de bibliotheek de tekst exact zoals ingevoerd. Om overeen te komen met de weergegeven tekst, controleer [TextCapType] en zet de geretourneerde string om naar hoofdletters wanneer de waarde `All` is.

Stel dat we het volgende tekstvak hebben op de eerste dia van het bestand sample2.pptx.

![Het All Caps‑effect](all_caps_effect.png)

Het codevoorbeeld hieronder toont hoe u de tekst kunt extraheren met het **All Caps**‑effect toegepast:

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

Uitvoer:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hoe tekst in een tabel op een dia wijzigen?**

Om tekst in een tabel op een dia te wijzigen, gebruik [ITable]. Doorloop de cellen en werk elke cel bij via [ICell]`.TextFrame` en alinea‑formattering via [IParagraph]`.ParagraphFormat`.

**Hoe een gradiëntenkleur op tekst in een PowerPoint‑dia toepassen?**

Om een gradiëntenkleur op tekst toe te passen, gebruik [IPortionFormat]`.FillFormat`. Stel [IFillFormat]`.FillType` in op [FillType]`.Gradient` en configureer de gradiënt‑stops, richting en transparantie.