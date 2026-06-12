---
title: Geavanceerde Tekstextractie uit Presentaties in C++
linktitle: Tekst Extractie
type: docs
weight: 90
url: /nl/cpp/extract-text-from-presentation/
keywords:
- tekst extraheren
- tekst extraheren uit dia
- tekst extraheren uit presentatie
- tekst extraheren uit PowerPoint
- tekst extraheren uit OpenDocument
- tekst extraheren uit PPT
- tekst extraheren uit PPTX
- tekst extraheren uit ODP
- tekst ophalen
- tekst ophalen uit dia
- tekst ophalen uit presentatie
- tekst ophalen uit PowerPoint
- tekst ophalen uit OpenDocument
- tekst ophalen uit PPT
- tekst ophalen uit PPTX
- tekst ophalen uit ODP
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Haal snel tekst uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor C++. Volg onze eenvoudige, stapsgewijze gids om tijd te besparen."
---
## **Overzicht**

Tekst uit presentaties extraheren is een veelvoorkomende maar essentiële taak voor ontwikkelaars die met dia‑inhoud werken. Of je nu Microsoft PowerPoint‑bestanden in PPT‑ of PPTX‑formaat verwerkt, of OpenDocument‑presentaties (ODP), het ophalen van tekstgegevens kan cruciaal zijn voor analyse, automatisering, indexering of content‑migratie.

Dit artikel biedt een volledige gids over hoe je efficiënt tekst kunt extraheren uit verschillende presentatie‑formaten, inclusief PPT, PPTX en ODP, met behulp van Aspose.Slides voor C++. Je leert hoe je systematisch door presentatie‑elementen itereren om nauwkeurig de tekstinhoud te verkrijgen die je nodig hebt.

## **Tekst extraheren uit een dia**

Aspose.Slides voor C++ biedt de [Aspose.Slides.Util](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/) namespace, die de [SlideUtil](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/) klasse bevat. Deze klasse stelt verschillende overladen statische methoden beschikbaar om alle tekst uit een presentatie of dia te extraheren. Om tekst uit een dia van een presentatie te halen, gebruik je de [GetAllTextBoxes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/getalltextboxes/)‑methode. Deze methode accepteert een object van het type [IBaseSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/) als parameter. Bij uitvoering scant de methode de volledige dia op tekst en retourneert een array van objecten van het type [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/), waarbij eventuele tekstopmaak behouden blijft.

De volgende code‑fragment extraheert alle tekst uit de eerste dia van de presentatie:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Tekst extraheren uit een presentatie**

Om tekst uit de gehele presentatie te scannen, gebruik je de statische [GetAllTextFrames](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/getalltextframes/)‑methode die wordt aangeboden door de [SlideUtil](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/) klasse. Deze methode accepteert twee parameters:

1. Ten eerste een [IPresentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/) object dat een PowerPoint‑ of OpenDocument‑presentatie vertegenwoordigt waaruit tekst wordt gehaald.
1. Ten tweede een `Boolean`‑waarde die aangeeft of de master‑dia’s moeten worden meegenomen bij het scannen van tekst uit de presentatie.

De methode retourneert een array van objecten van het type [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/), inclusief tekstopmaak‑informatie. De code hieronder scant de tekst en opmaakdetails uit een presentatie, inclusief de master‑dia’s.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Gecategoriseerde en snelle tekstekstractie**

De [PresentationFactory](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentationfactory/) klasse biedt eveneens methoden voor het extraheren van alle tekst uit presentaties:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

Het enum‑argument [TextExtractionArrangingMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textextractionarrangingmode/) geeft de modus aan voor het organiseren van het resultaat van de tekstekstractie en kan worden ingesteld op de volgende waarden:
- `Unarranged` – De ruwe tekst zonder rekening te houden met de positie op de dia.
- `Arranged` – De tekst wordt gerangschikt in dezelfde volgorde als op de dia.

De ongeregelde modus kan worden gebruikt wanneer snelheid cruciaal is; deze is sneller dan de gerangschikte modus.

[IPresentationText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationtext/) vertegenwoordigt de ruwe tekst die uit de presentatie is geëxtraheerd. De `get_SlidesText()`‑methode retourneert een array van objecten van het type [ISlideText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidetext/). Elk object staat voor de tekst op de bijbehorende dia. Het object van het type [ISlideText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidetext/) heeft de volgende methoden:

- `get_Text()` – De tekst binnen de vormen van de dia.
- `get_MasterText()` – De tekst binnen de vormen van de master‑dia die aan deze dia is gekoppeld.
- `get_LayoutText()` – De tekst binnen de vormen van de lay‑out‑dia die aan deze dia is gekoppeld.
- `get_NotesText()` – De tekst binnen de notitiedia‑vormen die aan deze dia zijn gekoppeld.
- `get_CommentsText()` – De tekst binnen de opmerkingen die aan deze dia zijn gekoppeld.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **FAQ**

**Hoe snel verwerkt Aspose.Slides grote presentaties tijdens tekstekstractie?**

Aspose.Slides is geoptimaliseerd voor hoge prestaties en kan zelfs [grote presentaties](/slides/nl/cpp/open-presentation/) verwerken, waardoor het geschikt is voor real‑time‑ of bulk‑verwerkingsscenario’s.

**Kan Aspose.Slides tekst uit tabellen en grafieken binnen presentaties extraheren?**

Ja. Aspose.Slides kan tekst uit vele dia‑elementen extraheren, inclusief tabellen en grafiekgerelateerde objecten, zodat je de tekstuele inhoud in veelvoorkomende presentatiestructuren kunt benaderen en analyseren.

**Heb ik een speciale Aspose.Slides‑licentie nodig om tekst uit presentaties te extraheren?**

Je kunt tekst extraheren met de gratis proefversie van Aspose.Slides, hoewel deze [bepaalde beperkingen](/slides/nl/cpp/licensing/) heeft, zoals het verwerken van een beperkt aantal dia’s. Voor onbeperkt gebruik en om grotere presentaties aan te kunnen, wordt aanbevolen een volledige licentie aan te schaffen.