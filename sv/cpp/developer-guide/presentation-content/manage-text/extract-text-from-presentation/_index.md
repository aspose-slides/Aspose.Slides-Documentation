---
title: Avancerad textextraktion från presentationer i C++
linktitle: Extrahera text
type: docs
weight: 90
url: /sv/cpp/extract-text-from-presentation/
keywords:
- extrahera text
- extrahera text från bild
- extrahera text från presentation
- extrahera text från PowerPoint
- extrahera text från OpenDocument
- extrahera text från PPT
- extrahera text från PPTX
- extrahera text från ODP
- hämta text
- hämta text från bild
- hämta text från presentation
- hämta text från PowerPoint
- hämta text från OpenDocument
- hämta text från PPT
- hämta text från PPTX
- hämta text från ODP
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Extrahera snabbt text från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++. Följ vår enkla, steg-för-steg-guide för att spara tid."
---
## **Översikt**

Att extrahera text från presentationer är en vanlig men ändå viktig uppgift för utvecklare som arbetar med bildinnehåll. Oavsett om du hanterar Microsoft PowerPoint-filer i PPT- eller PPTX-format, eller OpenDocument-presentationer (ODP), kan åtkomst till och hämtning av textdata vara avgörande för analys, automatisering, indexering eller innehållsmigrering.

Denna artikel ger en omfattande guide för hur man effektivt extraherar text från olika presentationsformat, inklusive PPT, PPTX och ODP, med hjälp av Aspose.Slides för C++. Du kommer att lära dig hur du systematiskt itererar genom presentationselement för att exakt hämta det textinnehåll du behöver.

## **Extrahera text från en bild**

Aspose.Slides för C++ tillhandahåller namnrymden [Aspose.Slides.Util](https://reference.aspose.com/slides/sv/cpp/aspose.slides.util/) som innehåller klassen [SlideUtil](https://reference.aspose.com/slides/sv/cpp/aspose.slides.util/slideutil/). Klassen erbjuder flera överlagrade statiska metoder för att extrahera all text från en presentation eller bild. För att extrahera text från en bild i en presentation, använd metoden [GetAllTextBoxes](https://reference.aspose.com/slides/sv/cpp/aspose.slides.util/slideutil/getalltextboxes/). Denna metod accepterar ett objekt av typen [IBaseSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseslide/) som parameter. Vid körning skannar metoden hela bilden efter text och returnerar en array av objekt av typen [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/), med bevarad textformatering.

Följande kodsnutt extraherar all text från den första bilden i presentationen:

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

## **Extrahera text från en presentation**

För att skanna text från hela presentationen, använd den statiska metoden [GetAllTextFrames](https://reference.aspose.com/slides/sv/cpp/aspose.slides.util/slideutil/getalltextframes/) som exponeras av klassen [SlideUtil](https://reference.aspose.com/slides/sv/cpp/aspose.slides.util/slideutil/). Den tar emot två parametrar:

1. Först ett [IPresentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/)-objekt som representerar en PowerPoint‑ eller OpenDocument‑presentation som texten ska extraheras från.
1. För det andra ett `Boolean`‑värde som anger om masterslides ska inkluderas vid skanning av text från presentationen.

Metoden returnerar en array av objekt av typen [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/), inklusive information om textformatering. Koden nedan skannar texten och formateringsdetaljerna från en presentation, inklusive masterslides.

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

## **Kategoriserad och snabb textextraktion**

Klassen [PresentationFactory](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentationfactory/) erbjuder också metoder för att extrahera all text från presentationer:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

Argumentet [TextExtractionArrangingMode](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textextractionarrangingmode/) enum anger läget för hur resultatet av textextraktion organiseras och kan sättas till följande värden:
- `Unarranged` – Råtext utan hänsyn till dess position på bilden.
- `Arranged` – Texten är ordnad i samma sekvens som på bilden.

Det oordnade läget kan användas när hastighet är kritisk; det är snabbare än det ordnade läget.

[IPresentationText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationtext/) representerar råtexten som extraherats från presentationen. Dess `get_SlidesText()`‑metod returnerar en array av objekt av typen [ISlideText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidetext/). Varje objekt representerar texten på den motsvarande bilden. Objektet av typen [ISlideText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidetext/) har följande metoder:

- `get_Text()` – Texten inom bildens former.
- `get_MasterText()` – Texten inom masterslides former som är associerade med den här bilden.
- `get_LayoutText()` – Texten inom layoutbildens former som är associerade med den här bilden.
- `get_NotesText()` – Texten inom noteringsbildens former som är associerade med den här bilden.
- `get_CommentsText()` – Texten inom kommentarer som är associerade med den här bilden.

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

**Hur snabbt bearbetar Aspose.Slides stora presentationer under textextraktion?**

Aspose.Slides är optimerat för hög prestanda och kan bearbeta även [stora presentationer](/slides/sv/cpp/open-presentation/), vilket gör det lämpligt för realtids- eller massbearbetningsscenario.

**Kan Aspose.Slides extrahera text från tabeller och diagram i presentationer?**

Ja. Aspose.Slides kan extrahera text från många bildelement, inklusive tabeller och diagramrelaterade objekt, så att du kan komma åt och analysera textinnehåll i vanliga presentationsstrukturer.

**Behöver jag en speciell Aspose.Slides-licens för att extrahera text från presentationer?**

Du kan extrahera text med den kostnadsfria provversionen av Aspose.Slides, men den har [vissa begränsningar](/slides/sv/cpp/licensing/), såsom att endast bearbeta ett begränsat antal bilder. För obegränsad användning och för att hantera större presentationer rekommenderas att köpa en full licens.