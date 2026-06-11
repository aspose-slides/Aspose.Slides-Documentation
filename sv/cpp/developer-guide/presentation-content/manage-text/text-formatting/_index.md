---
title: Formatera presentationstext i C++
linktitle: Textformatering
type: docs
weight: 50
url: /sv/cpp/text-formatting/
keywords:
- markera text
- reguljärt uttryck
- justera stycke
- textstil
- textbakgrund
- texttransparens
- teckenavstånd
- teckensegenskaper
- teckensnittsfamilj
- textrotation
- rotationsvinkel
- textram
- radavstånd
- autofit‑egenskap
- textramförankring
- texttabulering
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Formatera och anpassa text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++. Anpassa teckensnitt, färger, justering och mer."
---
## **Översikt**

Den här artikeln visar hur man formaterar text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++. Den täcker markering, bakgrundsfärger, transparens, teckenavstånd, teckenegenskaper, rotation, styckeavstånd, autofit‑beteende, textförankring, tabbstopp och språkinställningar.

I exemplen nedan använder vi en fil med namnet "sample.pptx", som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Markera text**

Använd metoden [ITextFrame.HighlightText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlighttext/) när du behöver markera text som matchar ett specifikt exempel i en textram. Metoden applicerar en markeringsfärg på matchande textfragment och kan användas tillsammans med [ITextSearchOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextsearchoptions/) för att styra hur sökningen utförs, till exempel för att endast matcha hela ord.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan endast hela ordet **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// Hämta den första formen från den första bilden.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Markera ordet "try" i formen.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Markera ordet "to" i formen.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Den markerade texten](highlighted_text.png)

## **Markera text med reguljära uttryck**

Metoden [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/highlightregex/) markerar textmatchningar som hittas med ett reguljärt uttryck. I C++ exponeras detta API på [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/).

Kodexemplet nedan markerar alla ord som innehåller **sju eller fler tecken**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Den markerade texten med reguljärt uttryck](highlighted_text_using_regex.png)

## **Ställ in bakgrundsfärg för text**

Använd [IParagraphFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` för att ställa in standardmarkeringsfärgen för ett stycke, eller använd [IPortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformat/)`.HighlightColor` för enskilda textdelar.

Följande kodexempel visar hur man ställer in bakgrundsfärgen för **hela stycket**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Ställ in markeringsfärgen för hela stycket.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Det gråa stycket](gray_paragraph.png)

Kodexemplet nedan visar hur man ställer in bakgrundsfärgen för **textdelar med fet stil**:

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
        // Ställ in markeringsfärgen för textdelen.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![De gråa textdelarna](gray_text_portions.png)

## **Justera textparagrafer**

Använd [IParagraphFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/)`.Alignment` för att ställa in styckejusteringen inom en textram. Värdet kan vara centrerat, vänsterjusterat, högerjusterat, justerat, osv.

Följande kodexempel visar hur man justerar stycket till **centrum**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Ställ in styckets justering till centrerad.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Det justerade stycket](aligned_paragraph.png)

## **Ställ in transparens för text**

Texttransparens styrs via alfakomponenten i färgen som tilldelas [IPortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformat/)`.FillFormat`. I exemplen nedan är `alpha = 50` ett ARGB‑alfavärde på skalan 0‑255, inte en transparensprocent.

Kodexemplet nedan visar hur man applicerar transparens på **hela stycket**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Ställ in fyllningsfärgen för texten till transparent färg.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Det transparenta stycket](transparent_paragraph.png)

Följande kodexempel visar hur man applicerar transparens på **textdelar med fet stil**:

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
        // Ställ in transparensen för textdelen.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![De transparenta textdelarna](transparent_text_portions.png)

## **Ställ in teckenavstånd för text**

Använd [IBasePortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseportionformat/)`.Spacing` för att öka eller minska avståndet mellan tecken i en textram.

Följande C++-kod visar hur man ökar teckenavståndet i **hela stycket**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Obs: Använd negativa värden för att komprimera teckenavståndet.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Teckenavståndet i stycket](character_spacing_in_paragraph.png)

Kodexemplet nedan visar hur man ökar teckenavståndet i **textdelar med fet stil**:

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
        // Obs: Använd negativa värden för att komprimera teckenavståndet.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Teckenavståndet i textdelarna](character_spacing_in_text_portions.png)

### **Inaktivera kerning för specifika typsnitt**

I vissa fall kan text som renderas av Aspose.Slides se något tajtare ut än samma text som visas i PowerPoint. Detta kan hända eftersom PowerPoint kan ignorera kerning‑data för vissa typsnitt, även när typsnittet innehåller giltig kerninginformation och kerning är aktiverat i PowerPoints inställningar.

För att få den renderade utdata att närma sig PowerPoint i sådana fall kan du inaktivera kerning för textdelar som använder det berörda typsnittet. Sätt [IPortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` till ett värde som är avsevärt större än den faktiska teckenstorleken:

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

## **Hantera textens teckensegenskaper**

Teckensegenskaper kan ställas in på styckenivå via [IParagraphFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` eller på enskilda delar via [IPortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformat/).

Följande kod ställer in teckensnitt och textstil för hela stycket: den applicerar teckenstorlek, fet, kursiv, prickad understrykning och teckensnittet Times New Roman på alla delar i stycket.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Ställ in teckensegenskaperna för stycket.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Teckensegenskaperna för stycket](font_properties_for_paragraph.png)

Kodexemplet nedan applicerar liknande egenskaper på **textdelar med fet stil**:

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
        // Ställ in teckensegenskaperna för textdelen.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Teckensegenskaperna för textdelarna](font_properties_for_text_portions.png)

## **Ställ in textrotation**

Använd [ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` för att ställa in en fördefinierad textorientering inom en form.

Följande kodexempel sätter textorienteringen i formen till `Vertical270`, vilket roterar texten **90 grader moturs**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Textrotationen](text_rotation.png)

## **Ställ in anpassad rotation för textramlar**

Använd [ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/)`.RotationAngle` för att ange en anpassad rotationsvinkel för en [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/).

Kodexemplet nedan roterar textramen med 3 grader medurs inom formen:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Den anpassade textrotationen](custom_text_rotation.png)

## **Ställ in radavstånd för stycken**

Aspose.Slides tillhandahåller [IParagraphFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`, `IParagraphFormat.SpaceBefore` och `IParagraphFormat.SpaceWithin` för att kontrollera styckeavstånd. Dessa egenskaper används på följande sätt:

* Använd ett positivt värde för att ange radavstånd som en procentandel av radens höjd.
* Använd ett negativt värde för att ange radavstånd i punkter.

Följande kodexempel visar hur man anger radavståndet inom stycket:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Radavståndet i stycket](line_spacing.png)

## **Ställ in Autofit-typ för textramlar**

[ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/)`.AutofitType` bestämmer hur text beter sig när den överskrider behållarens gränser. Använd den för att kontrollera om texten krymper, överflödar eller automatiskt ändrar storlek på formen.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ställ in förankring för textramlar**

[ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframeformat/)`.AnchoringType` definierar hur text placeras vertikalt inuti en form, exempelvis högst, i mitten eller längst ner.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ställ in texttabulering**

Använd [IParagraphFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` och `IParagraphFormat.Tabs` för att konfigurera tabbstopp i ett stycke.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Stycketabbar](paragraph_tabs.png)

## **Ställ in korrekturläsningsspråk**

Aspose.Slides tillhandahåller [IPortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformat/)`.LanguageId`, vilket gör att du kan ange korrekturläsningsspråket för en textdel. Korrekturläsningsspråket bestämmer vilket språk som används för stavnings- och grammatikkontroller i PowerPoint.

Följande kodexempel visar hur man anger korrekturläsningsspråket för en textdel:

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

// Ställ in Id för ett korrekturläsningsspråk.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ställ in standardspråk**

Använd [ILoadOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` för att definiera standardspråket för text som skapas vid inläsning eller skapande av en presentation.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Lägg till en ny rektangelform med text.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Kontrollera språk för den första textdelen.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Ställ in standardtextstil**

För att tillämpa standardtextformatering på presentationsnivå, använd [IPresentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`.

Följande kodexempel visar hur man sätter ett standardfet teckensnitt med storleken 14 pt för all text på alla bilder i en ny presentation.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Hämta översta nivåns styckeformat.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Extrahera text med versaler‑effekt**

I PowerPoint får man genom att använda **All Caps**‑teckenseffekten att text visas med versaler på bilden även om den ursprungligen skrevs med gemener. När du hämtar en sådan textdel med Aspose.Slides returnerar biblioteket texten exakt som den angavs. För att matcha den visade texten, kontrollera [TextCapType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textcaptype/) och konvertera den returnerade strängen till versaler när värdet är `All`.

Anta att vi har följande textruta på den första bilden i filen sample2.pptx.

![Versaler‑effekten](all_caps_effect.png)

Kodexemplet nedan visar hur man extraherar texten med **All Caps**‑effekten tillämpad:

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

Utskrift:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hur ändrar man text i en tabell på en bild?**

För att ändra text i en tabell på en bild, använd [ITable](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itable/). Iterera genom cellerna och uppdatera varje cell via [ICell](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icell/)`.TextFrame` samt styckeformatering via [IParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/)`.ParagraphFormat`.

**Hur applicerar man en gradientfärg på text i en PowerPoint‑bild?**

För att applicera en gradientfärg på text, använd [IPortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportionformat/)`.FillFormat`. Ställ in [IFillFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifillformat/)`.FillType` till [FillType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/filltype/)`.Gradient` och konfigurera gradientstopp, riktning och transparens.