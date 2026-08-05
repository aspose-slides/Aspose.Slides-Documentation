---
title: Geavanceerde Tekstextractie uit Presentaties in C++
linktitle: Tekst extraheren
type: docs
weight: 90
url: /nl/cpp/extract-text-from-presentation/
aliases:
  - /cpp/extracting-text-from-the-presentation/
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
description: "Extraheer snel tekst uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor C++. Volg onze eenvoudige, stapsgewijze handleiding om tijd te besparen."
---
## **Overzicht**

Het extraheren van tekst uit presentaties is een veelvoorkomende maar essentiële taak voor ontwikkelaars die met dia‑inhoud werken. Of je nu werkt met Microsoft PowerPoint‑bestanden in PPT‑ of PPTX‑formaat, of OpenDocument‑presentaties (ODP), het benaderen en ophalen van tekstgegevens kan cruciaal zijn voor analyse, automatisering, indexering of content‑migratie.

Dit artikel biedt een uitgebreide gids over hoe je efficiënt tekst kunt extraheren uit verschillende presentatieformaten, waaronder PPT, PPTX en ODP, met behulp van Aspose.Slides voor C++. Je leert hoe je systematisch door presentatiedoelen kunt itereren om nauwkeurig de tekstinhoud te verkrijgen die je nodig hebt.

## **Tekst extraheren uit een dia**

Aspose.Slides for C++ provides the [Aspose.Slides.Util](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/) namespace, which includes the [SlideUtil](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/) class. This class exposes several overloaded static methods for extracting all text from a presentation or slide. To extract text from a slide in a presentation, use the [GetAllTextBoxes](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/getalltextboxes/) method. This method accepts an object of type [IBaseSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseslide/) as a parameter. When executed, the method scans the entire slide for text and returns an array of objects of type [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/), preserving any text formatting.

De volgende code‑fragment extrahert alle tekst van de eerste dia van de presentatie:

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

Om tekst door de volledige presentatie te scannen, gebruik je de statische methode [GetAllTextFrames](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/getalltextframes/) die wordt blootgesteld door de klasse [SlideUtil](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/). Deze accepteert twee parameters:

1. Eerst een [IPresentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/)‑object dat een PowerPoint‑ of OpenDocument‑presentatie vertegenwoordigt waaruit tekst zal worden geëxtraheerd.  
1. Ten tweede een `Boolean`‑waarde die aangeeft of de masterslides moeten worden meegenomen bij het scannen van tekst uit de presentatie.

De methode retourneert een array van objecten van het type [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/), inclusief informatie over tekstopmaak. De onderstaande code scant de tekst‑ en opmaakdetails uit een presentatie, inclusief de masterslides.

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

## **Gecategoriseerde en snelle tekstextractie**

De klasse [PresentationFactory](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentationfactory/) biedt eveneens methoden om alle tekst uit presentaties te extraheren:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

Het enum‑argument [TextExtractionArrangingMode](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textextractionarrangingmode/) geeft de modus aan voor het organiseren van het resultaat van de tekstextractie en kan worden ingesteld op de volgende waarden:
- `Unarranged` - De ruwe tekst zonder rekening te houden met de positie op de dia.  
- `Arranged` - De tekst is gerangschikt in dezelfde volgorde als op de dia.

De ongereguleerde modus kan worden gebruikt wanneer snelheid cruciaal is; deze is sneller dan de geregelde modus.

[IPresentationText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationtext/) vertegenwoordigt de ruwe tekst die uit de presentatie is geëxtraheerd. Zijn `get_SlidesText()`‑methode retourneert een array van objecten van het type [ISlideText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidetext/). Elk object vertegenwoordigt de tekst op de bijbehorende dia. Het object van het type [ISlideText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidetext/) heeft de volgende methoden:

- `get_Text()` - De tekst binnen de vormen van de dia.  
- `get_MasterText()` - De tekst binnen de vormen van de masterslide die bij deze dia horen.  
- `get_LayoutText()` - De tekst binnen de vormen van de lay-outdia die bij deze dia horen.  
- `get_NotesText()` - De tekst binnen de notities van de dia die bij deze dia horen.  
- `get_CommentsText()` - De tekst binnen de opmerkingen die bij deze dia horen.

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

**Hoe snel verwerkt Aspose.Slides grote presentaties tijdens tekst‑extractie?**

Aspose.Slides is geoptimaliseerd voor hoge prestaties en kan zelfs [grote presentaties](/slides/nl/cpp/open-presentation/) verwerken, waardoor het geschikt is voor real‑time of bulk‑verwerking scenario’s.

**Kan Aspose.Slides tekst extraheren uit tabellen en grafieken binnen presentaties?**

Ja. Aspose.Slides kan tekst extraheren uit vele dia‑elementen, waaronder tabellen en grafiekgerelateerde objecten, zodat je tekstinhoud in algemene presentatiestructuren kunt benaderen en analyseren.

**Heb ik een speciale Aspose.Slides‑licentie nodig om tekst uit presentaties te extraheren?**

Je kunt tekst extraheren met de gratis proefversie van Aspose.Slides, hoewel die [bepaalde beperkingen](/slides/nl/cpp/licensing/) heeft, zoals het verwerken van slechts een beperkt aantal dia's. Voor onbeperkt gebruik en om grotere presentaties aan te kunnen, wordt aangeraden een volledige licentie aan te schaffen.