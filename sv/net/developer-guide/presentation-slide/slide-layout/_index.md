---
title: Tillämpa eller ändra bildlayouter i .NET
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/net/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationsdesign
- bilddesign
- oanvänd layout
- fotnotssynlighet
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
- C#
- .NET
- Aspose.Slides
description: "Hantera och anpassa bildlayouter i Aspose.Slides för .NET. Utforska layouttyper, kontroll av platshållare och fotnotssynlighet med C#-kodexempel."
---
## **Introduktion**

En bildlayout definierar arrangemanget av platshållarrutor och formatering för innehållet på en bild. Den styr vilka platshållare som är tillgängliga och var de visas. Bildlayouter hjälper dig att snabbt och konsekvent utforma presentationer – oavsett om du skapar något enkelt eller mer komplext. Några av de vanligaste bildlayouterna i PowerPoint är:

**Titelbildslayout** – Inkluderar två textplatshållare: en för rubriken och en för underrubriken.

**Titel‑ och innehållslayout** – Har en mindre rubrikplatshållare högst upp och en större under för huvudinnehåll (såsom text, punktlistor, diagram, bilder med mera).

**Tom layout** – Innehåller inga platshållare, vilket ger dig full kontroll att skapa bilden från grunden.

Bildlayouter är en del av en bildmaster, som är den översta bilden som definierar layoutstilar för presentationen. Du kan komma åt och ändra layoutbilder via bildmastern – antingen efter deras typ, namn eller unika ID. Alternativt kan du redigera en specifik layoutbild direkt i presentationen.

För att arbeta med bildlayouter i Aspose.Slides för .NET kan du använda:

- Egenskaper såsom [LayoutSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/layoutslides/) och [Masters](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/masters/) under klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) 
- Typer såsom [ILayoutSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutplaceholdermanager/), och [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
För att lära dig mer om att arbeta med masternbilder, läs artikeln [Slide Master](/slides/sv/net/slide-master/) .
{{% /alert %}}

## **Lägg till bildlayouter i presentationer**

För att anpassa utseendet och strukturen på dina bilder kan du behöva lägga till nya layoutbilder i en presentation. Aspose.Slides för .NET låter dig kontrollera om en specifik layout redan finns, lägga till en ny om det behövs och använda den för att infoga bilder baserade på den layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
1. Få åtkomst till [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterlayoutslidecollection/) .
1. Kontrollera om den önskade layoutbilden redan finns i samlingen. Om den inte finns, lägg till den layoutbild du behöver.
1. Lägg till en tom bild baserad på den nya layoutbilden.
1. Spara presentationen.

Följande C#‑kod visar hur du lägger till en bildlayout i en PowerPoint‑presentation:

```cs
// Skapa en instans av Presentation‑klassen som representerar en PowerPoint‑fil.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Gå igenom layout‑bildtyperna för att välja en layout‑bild.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // En situation där presentationen inte innehåller alla layout‑typer.
        // presentationsfilen innehåller endast Tomma- och Anpassade‑layouttyper.
        // Dock kan layoutbilder med anpassade typer ha igenkännbara namn,
        // såsom "Title", "Title and Content" osv., vilka kan användas för att välja layoutbild.
        // Du kan också förlita dig på en uppsättning av platshållarform‑typer.
        // Till exempel bör en Titel‑bild bara ha Title‑platshållartypen, och så vidare.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Lägg till en tom bild med den tillagda layout‑bilden.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Spara presentationen till disk.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Ta bort oanvända layoutbilder**

Aspose.Slides erbjuder metoden [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) från klassen [Compress](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/) för att låta dig ta bort oönskade och oanvända layoutbilder.

Följande C#‑kod visar hur du tar bort en layoutbild från en PowerPoint‑presentation:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Lägg till platshållare i bildlayouter**

Aspose.Slides tillhandahåller egenskapen [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/placeholdermanager/) , som gör att du kan lägga till nya platshållare i en layoutbild.

Denna manager innehåller metoder för följande platshållartyper:

| PowerPoint‑platshållare | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutplaceholdermanager/) metod |
| ----------------------- | ------------------------------------------------------------------------ |
| ![Innehåll](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Innehåll (vertikal)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (vertikal)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Bild](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagram](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tabell](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online‑bild](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Följande C#‑kod visar hur du lägger till nya platshållarformer i den tomma layoutbilden:

```cs
using (var presentation = new Presentation())
{
    // Hämta den tomma layoutbilden.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Hämta platshållarhanteraren för layoutbilden.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Lägg till olika platshållare i den tomma layoutbilden.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Lägg till en ny bild med den tomma layouten.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Platshållarna på layoutbilden](add_placeholders.png)

## **Ställ in fotnotssynlighet för en layoutbild**

I PowerPoint‑presentationer kan fotnotselement som datum, bildnummer och anpassad text visas eller döljas beroende på bildlayouten. Aspose.Slides för .NET låter dig styra synligheten för dessa fotnotplatshållare. Detta är användbart när du vill att vissa layouter ska visa fotnotinformation medan andra förblir rena och enkla.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
2. Hämta en referens till en layoutbild med dess index.
3. Ställ in bildens fotnotplatshållare till synlig.
4. Ställ in bildens sidnummerplatshållare till synlig.
5. Ställ in datum‑tids‑platshållaren till synlig.
6. Spara presentationen.

Följande C#‑kod visar hur du ställer in synligheten för en bildfotnot och utför relaterade uppgifter:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **Ställ in underordnad fotnotssynlighet för en bild**

I PowerPoint‑presentationer kan fotnotselement som datum, bildnummer och anpassad text styras på masternivå för att säkerställa konsistens över alla layoutbilder. Aspose.Slides för .NET låter dig ange synlighet och innehåll för dessa fotnotplatshållare på mastern och sprida dessa inställningar till alla underordnade layoutbilder. Detta tillvägagångssätt garanterar enhetlig fotnotinformation i hela presentationen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
2. Hämta en referens till mastern genom dess index.
3. Ställ in masterns och alla underordnade fotnotplatshållare till synliga.
4. Ställ in masterns och alla underordnade sidnummerplatshållare till synliga.
5. Ställ in masterns och alla underordnade datum‑tids‑platshållare till synliga.
6. Spara presentationen.

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Vad är skillnaden mellan en masterbild och en layoutbild?**

En masterbild definierar det övergripande temat och standardformatering, medan layoutbilder definierar specifika arrangemang av platshållare för olika typer av innehåll.

**Kan jag kopiera en layoutbild från en presentation till en annan?**

Ja, du kan klona en layoutbild från en presentations [LayoutSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/layoutslides/)‑samling och infoga den i en annan med metoden `AddClone` .

**Vad händer om jag tar bort en layoutbild som fortfarande används av en bild?**

Om du försöker ta bort en layoutbild som fortfarande refereras av minst en bild i presentationen, kommer Aspose.Slides att kasta ett [PptxEditException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxeditexception/) . Undvik detta genom att använda [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) som säkert tar bort endast de layoutbilder som inte används.