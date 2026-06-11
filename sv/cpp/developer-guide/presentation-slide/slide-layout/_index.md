---
title: Applicera eller ändra bildlayouter i C++
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/cpp/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationsdesign
- bilddesign
- oanvänd layout
- fotovisibilitet
- titelsida
- titel och innehåll
- avsnittsrubrik
- två innehåll
- jämförelse
- endast titel
- tom layout
- innehåll med bildtext
- bild med bildtext
- titel och vertikal text
- vertikal titel och text
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Hantera och anpassa bildlayouter i Aspose.Slides för C++. Utforska layouttyper, kontroll av platshållare och fotovisibilitet genom C++-kodexempel."
---
## **Introduktion**

En bildlayout definierar arrangemanget av platshållarbokser och formatering för innehållet på en bild. Den styr vilka platshållare som är tillgängliga och var de visas. Bildlayouter hjälper dig att skapa presentationer snabbt och konsekvent—oavsett om du skapar något enkelt eller mer komplext. Några av de vanligaste bildlayouterna i PowerPoint inkluderar:

**Titelbildslayout** – Inkluderar två textplatshållare: en för titel och en för undertitel.

**Titel och innehållslayout** – Har en mindre titelplatshållare högst upp och en större nedanför för huvudinnehåll (såsom text, punktlistor, diagram, bilder och mer).

**Tom layout** – Innehåller ingen platshållare, vilket ger dig full kontroll att designa bilden från början.

Bildlayouter är en del av en bildmaster, som är den översta bilden som definierar layoutstilar för presentationen. Du kan komma åt och ändra layoutbilder via bildmastern—antingen efter deras typ, namn eller unika ID. Alternativt kan du redigera en specifik layoutbild direkt i presentationen.

För att arbeta med bildlayouter i Aspose.Slides för Android kan du använda:

- Metoder som [get_LayoutSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_layoutslides/) och [get_Masters](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_masters/) under klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) 
- Typer som [ILayoutSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/), och [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
För att lära dig mer om att arbeta med masternbilder, läs artikeln [Slide Master](/slides/sv/cpp/slide-master/).
{{% /alert %}}

## **Lägg till bildlayouter i presentationer**

För att anpassa utseendet och strukturen på dina bilder kan du behöva lägga till nya layoutbilder i en presentation. Aspose.Slides för Android låter dig kontrollera om en specifik layout redan finns, lägga till en ny om det behövs, och använda den för att infoga bilder baserade på den layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Åtkomst till [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imasterlayoutslidecollection/).
3. Kontrollera om den önskade layoutbilden redan finns i samlingen. Om den inte finns, lägg till den layoutbild du behöver.
4. Lägg till en tom bild baserad på den nya layoutbilden.
5. Spara presentationen.

Följande C++-kod demonstrerar hur man lägger till en bildlayout i en PowerPoint-presentation:

```cpp
// Skapa en instans av Presentation-klassen som representerar en PowerPoint-fil.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Ett scenario där presentationen inte innehåller alla layouttyper.
    // Presentationsfilen innehåller endast tomma och anpassade layouttyper.
    // Dock kan layoutbilder med anpassade typer ha igenkännbara namn,
    // såsom "Title", "Title and Content", etc., som kan användas för att välja layoutbild.
    // Du kan även förlita dig på en uppsättning av platshållarformstyper.
    // Till exempel bör en Title-bild bara ha Title-platshållartypen, osv.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Lägg till en tom bild med den tillagda layoutbilden.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Spara presentationen till disk.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ta bort oanvända layoutbilder**

Aspose.Slides tillhandahåller metoden [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) från klassen [Compress](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/) för att låta dig ta bort oönskade och oanvända layoutbilder.

Följande C++-kod visar hur man tar bort en layoutbild från en PowerPoint-presentation:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lägg till platshållare i bildlayouter**

Aspose.Slides tillhandahåller metoden [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) som låter dig lägga till nya platshållare i en layoutbild.

Denna manager innehåller metoder för följande platshållartyper:

| PowerPoint‑platshållare | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ilayoutplaceholdermanager/) Metod |
| ---------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Följande C++-kod demonstrerar hur man lägger till nya platshållarformer i den tomma layoutbilden:

```cpp
auto presentation = MakeObject<Presentation>();

// Hämta den tomma layoutbilden.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Hämta platshållarhanteraren för layoutbilden.
auto placeholderManager = layout->get_PlaceholderManager();

// Lägg till olika platshållare på den tomma layoutbilden.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Lägg till en ny bild med den tomma layouten.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![Platshållarna på layoutbilden](add_placeholders.png)

## **Ställ in sidfotssynlighet för en layoutbild**

I PowerPoint-presentationer kan fotoelement som datum, bildnummer och anpassad text visas eller döljas beroende på bildlayout. Aspose.Slides för Android låter dig styra synligheten för dessa fotoplacshållare. Detta är användbart när du vill att vissa layouter ska visa fotoinformation medan andra förblir rena och minimal.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta en referens till en layoutbild enligt dess index.
3. Ställ in bildens fotoplacshållare som synlig.
4. Ställ in bildnummer‑placshållare som synlig.
5. Ställ in datum‑tid‑placshållare som synlig.
Spara presentationen.

Följande C++-kod visar hur man ställer in synligheten för en bildfot och utför relaterade uppgifter:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ställ in underordnad fotovisibilitet för en bild**

I PowerPoint-presentationer kan fotoelement som datum, bildnummer och anpassad text kontrolleras på masternivå för att säkerställa konsistens över alla layoutbilder. Aspose.Slides för Android möjliggör att ställa in synlighet och innehåll för dessa fotoplacshållare på mastern och sprida dessa inställningar till alla underordnade layoutbilder. Detta tillvägagångssätt säkerställer enhetlig fotoinformation i hela presentationen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta en referens till mastern enligt dess index.
3. Ställ in masterns och alla underordnade fotoplacshållare som synliga.
4. Ställ in masterns och alla underordnade bildnummer‑placshållare som synliga.
5. Ställ in masterns och alla underordnade datum‑tid‑placshållare som synliga.
6. Spara presentationen.

Följande C++-kod demonstrerar denna operation:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Vad är skillnaden mellan en masternbild och en layoutbild?**

En masternbild definierar det övergripande temat och standardformatering, medan layoutbilder definierar specifika arrangemang av platshållare för olika typer av innehåll.

**Kan jag kopiera en layoutbild från en presentation till en annan?**

Ja, du kan klona en layoutbild från en presentations layoutsamling, som är åtkomlig via metoden [get_LayoutSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_layoutslides/), och infoga den i en annan presentation med metoden `AddClone`.

**Vad händer om jag tar bort en layoutbild som fortfarande används av en bild?**

Om du försöker ta bort en layoutbild som fortfarande refereras av minst en bild i presentationen, kommer Aspose.Slides att kasta ett [PptxEditException](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pptxeditexception/). För att undvika detta, använd [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) som säkert tar bort endast de layoutbilder som inte används.