---
title: Lay-outs voor dia's toepassen of wijzigen in .NET
linktitle: Dia-layout
type: docs
weight: 60
url: /nl/net/slide-layout/
keywords:
- dia-layout
- inhoud-layout
- placeholder
- presentatie-ontwerp
- dia-ontwerp
- ongebruikte layout
- zichtbaarheid van voettekst
- titel-dia
- titel en inhoud
- sectiekop
- twee-inhoud
- vergelijking
- alleen titel
- lege layout
- inhoud met bijschrift
- afbeelding met bijschrift
- titel en verticale tekst
- verticale titel en tekst
- PowerPoint
- OpenDocument
- presentatie
- C#
- .NET
- Aspose.Slides
description: "Dia-layouts toepassen, maken en wijzigen in Aspose.Slides voor .NET, placeholders toevoegen, ongebruikte layout verwijderen en de zichtbaarheid van de voettekst beheren."
---
## **Overzicht**

Een slide‑lay‑out definieert de posities en opmaak van tijdelijke aanduidingen zoals titels, tekst, afbeeldingen, grafieken en tabellen. Het toepassen van een lay‑out geeft dia’s een consistente structuur terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende lay‑outs zijn:

- **Titel‑dia**: Bevat tijdelijke aanduidingen voor titel en ondertitel.  
- **Titel en inhoud**: Bevat een titel‑placeholder en een algemene inhouds‑placeholder.  
- **Leeg**: Bevat geen inhouds‑placeholders en is handig wanneer elke vorm handmatig wordt gepositioneerd.

## **Begrijp layout‑erfelijkheid**

Een presentatie heeft drie gerelateerde niveaus:

1. Een [master‑slide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/) definieert het thema, gedeelde opmaak, achtergronden en gemeenschappelijke objecten.  
1. Een [layout‑slide](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/) behoort tot een master en definieert een specifieke rangschikking van placeholders.  
1. Een [normale slide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/) gebruikt één lay‑out en slaat de ingevoerde inhoud voor die dia op.

Een normale dia erft thema en opmaak van zijn lay‑out, en de lay‑out erft van zijn master. Een waarde die rechtstreeks op een normale dia wordt ingesteld, overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt aangemaakt, worden de placeholder‑vormen gegenereerd vanuit de geselecteerde lay‑out, terwijl de ingevoerde inhoud in die placeholders behoort tot de normale dia.

Voeg verplichte placeholders toe aan een lay‑out voordat je dia’s ervan maakt. Een later toegevoegde placeholder aan een lay‑out voegt niet automatisch een overeenkomstige placeholder‑vorm toe aan bestaande normale dia’s.

Deze relatie heeft twee belangrijke consequenties:

- Het wijzigen van geërfde opmaak of bestaande placeholder‑geometrie in een lay‑out kan elke dia die ervan afhankelijk is bijwerken. Controleer vóór het bewerken van een lay‑out die al in gebruik is de afhankelijke dia’s en evalueer de resulterende presentatie.  
- Een lay‑out die nog door een dia wordt gebruikt, kan niet worden verwijderd. Ken eerst de afhankelijke dia’s opnieuw toe aan een andere lay‑out, of verwijder alleen ongebruikte lay‑outs.

Voor meer informatie over het hoogste niveau van deze hiërarchie, zie [Slide Master](/slides/nl/net/slide-master/).

## **Selecteer en pas een slide‑lay‑out toe**

Gebruik een lay‑outtype wanneer de presentatie standaard PowerPoint‑lay‑outdefinities volgt. Lay‑outnamen zijn door de gebruiker bewerkbaar en kunnen worden gelokaliseerd, dus naam‑gebaseerde selectie is minder betrouwbaar tenzij je de bron‑template beheert.

Het volgende voorbeeld zoekt naar **Title and Content** op de eerste master. Als die lay‑out niet beschikbaar is, valt het bewust terug op **Blank**. De tweede null‑check is nodig omdat een presentatie uitsluitend aangepaste lay‑outs kan bevatten. De geselecteerde lay‑out wordt vervolgens toegepast op de eerste normale dia via de [ISlide.LayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/layoutslide/)‑eigenschap.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Het wijzigen van de lay‑out van een dia verwijdert niet de gewone vormen die direct aan de dia zijn toegevoegd. Placeholder‑posities, geërfde opmaak en de correspondentie tussen bestaande placeholders en de nieuwe lay‑out kunnen echter wijzigen, dus inspecteer de output bij het wisselen tussen wezenlijk verschillende lay‑outs.

## **Voeg een layout‑slide toe**

Selectie en creatie zijn afzonderlijke handelingen. Het vorige voorbeeld selecteert een bestaande lay‑out; het maakt er geen aan. Om een lay‑out te maken, roep je de [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/nl/net/aspose.slides/masterlayoutslidecollection/add/)‑methode aan op de lay‑outcollectie van de doel‑master.

Het volgende voorbeeld voegt steeds een nieuwe **Title and Content**‑lay‑out toe met de naam `Report Title and Content`, en voegt daarna een normale dia toe die ervan afgeleid is. Lay‑outnamen moeten binnen de collectie uniek zijn.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Voeg alleen een lay‑out toe wanneer de template werkelijk een extra herbruikbare structuur nodig heeft. Als er al een passende lay‑out bestaat, selecteer en hergebruik die dan in plaats van een duplicaat aan te maken.

## **Voeg placeholders toe aan een layout‑slide**

De [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/placeholdermanager/)‑eigenschap biedt een [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutplaceholdermanager/) voor het toevoegen van placeholder‑vormen aan een lay‑out.

| PowerPoint‑placeholder          | `ILayoutPlaceholderManager` Method |
| -------------------------------- | ---------------------------------- |
| ![Content](content.png)          | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png)    | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png)          | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png)              | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png)              | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)        | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)              | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Het volgende voorbeeld controleert of de **Blank**‑lay‑out bestaat, voegt er vier placeholders aan toe en maakt vervolgens een normale dia die de gewijzigde lay‑out gebruikt. De volgorde is opzettelijk: de placeholders worden toegevoegd vóór het aanmaken van de normale dia, zodat Aspose.Slides de overeenkomstige placeholder‑vormen op die dia kan genereren.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Het resultaat:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Waarschuwing" %}}
Het wijzigen van geërfde opmaak of de geometrie van bestaande lay‑out‑placeholders kan afhankelijke dia’s beïnvloeden. Een nieuw toegevoegde layout‑placeholder wordt niet automatisch teruggevoerd naar bestaande normale dia’s. Test lay‑out‑wijzigingen op een kopie van de presentatie en controleer elke afhankelijke dia.
{{% /alert %}}

## **Verwijder ongebruikte layout‑slides**

Gebruik de [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)‑methode om lay‑outs te verwijderen die door geen enkele normale dia worden gerefereerd. De methode laat lay‑outs die nog in gebruik zijn ongewijzigd.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Om één specifieke lay‑out te verwijderen, controleer eerst de [HasDependingSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/hasdependingslides/)‑eigenschap of de [GetDependingSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/getdependingslides/)‑methode. Ken eventuele afhankelijke dia’s opnieuw toe voordat je [ILayoutSlide.Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/remove/) aanroept. Het proberen te verwijderen van een gebruikte lay‑out veroorzaakt een [PptxEditException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxeditexception/).

## **Regel de zichtbaarheid van voetteksten op een layout‑slide**

Een lay‑out heeft zijn eigen voettekst‑, dia‑nummer‑ en datum‑tijd‑placeholders. Gebruik de [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/headerfootermanager/)‑eigenschap om die placeholders voor één lay‑out te regelen. Dit is handig wanneer bijvoorbeeld inhoud‑lay‑outs voetteksten tonen maar titel‑lay‑outs niet.

Het volgende voorbeeld selecteert veilig een lay‑out en maakt de voettekstelementen zichtbaar:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Regel de zichtbaarheid van voetteksten op een master en zijn onderliggende lay‑outs**

Om consistente voettekstinstellingen toe te passen over een meester‑hiërarchie, gebruik je de [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/headerfootermanager/)‑eigenschap. De propagatiemethoden van [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslideheaderfootermanager/) werken op de master en zijn afhankelijke lay‑out‑slides en normale slides; ze richten zich niet alleen op één normale slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Wat is het verschil tussen een master‑slide en een layout‑slide?**

Een master‑slide definieert het thema en de gedeelde opmaak van de presentatie. Een layout‑slide behoort tot een master en definieert een herbruikbare rangschikking van placeholders. Normale dia’s gebruiken die lay‑outs en slaan dia‑specifieke inhoud op.

**Kan ik een layout‑slide van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de doel‑collectie met de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/globallayoutslidecollection/addclone/)‑methode. Bij het kopiëren tussen presentaties moet je bovendien fonts, thema’s, afbeeldingen en andere bronnen die door de bron‑lay‑out worden gebruikt verifiëren.

**Wat gebeurt er als ik een lay‑out wijzig die al in gebruik is?**

Afhankelijke dia’s erven de lay‑out‑wijzigingen tenzij ze de betrokken opmaak of objecten lokaal overschrijven. Placeholder‑geometrie en geërfde styling kunnen daardoor op veel dia’s tegelijk veranderen. Gebruik [GetDependingSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/getdependingslides/) om de getroffen dia’s te identificeren vóór je de lay‑out bewerkt.

**Wat gebeurt er als ik een lay‑out verwijder die nog in gebruik is?**

Aspose.Slides gooit een [PptxEditException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxeditexception/). Ken de afhankelijke dia’s eerst opnieuw toe, of gebruik [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) om alleen niet‑gerefereerde lay‑outs te verwijderen.