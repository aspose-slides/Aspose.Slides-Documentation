---
title: Toepassen of Wijzigen van Dia‑indelingen in .NET
linktitle: Dia‑indeling
type: docs
weight: 60
url: /nl/net/slide-layout/
keywords:
- dia‑indeling
- inhoudsindeling
- plaatsaanduiding
- presentatie‑ontwerp
- dia‑ontwerp
- ongebruikte indeling
- voettekst‑zichtbaarheid
- titel­dia
- titel en inhoud
- sectiekop
- twee inhoud
- vergelijking
- alleen titel
- lege indeling
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
description: "Pas dia‑indelingen toe, maak ze aan en wijzig ze in Aspose.Slides voor .NET, voeg plaatsaanduidingen toe, verwijder ongebruikte indelingen en beheer de zichtbaarheid van voetteksten."
---
## **Overzicht**

Een dia‑indeling definieert de posities en opmaak van tijdelijke aanduidingen zoals titels, tekst, afbeeldingen, diagrammen en tabellen. Het toepassen van een indeling geeft dia's een consistente structuur terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende indelingen omvatten:

- **Titel‑dia**: Bevat plaatsaanduidingen voor titel en ondertitel.
- **Titel en Inhoud**: Bevat een titel‑plaatsaanduiding en een algemene inhouds‑plaatsaanduiding.
- **Leeg**: Bevat geen inhouds‑plaatsaanduidingen en is handig wanneer elke vorm handmatig wordt gepositioneerd.

## **Begrijp Indelings‑overerving**

Een presentatie heeft drie gerelateerde niveaus:

1. Een [master slide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/) definieert het thema, gedeelde opmaak, achtergronden en gemeenschappelijke objecten.
1. Een [layout slide](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/) behoort tot een master en definieert een bepaalde rangschikking van plaatsaanduidingen.
1. Een [normal slide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/) gebruikt één indeling en slaat de voor die dia ingevoerde inhoud op.

Een normale dia erft thema en opmaak van haar indeling, en de indeling erft van haar master. Een direct op een normale dia ingestelde waarde overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt aangemaakt, worden haar plaatsaanduidingsvormen gegenereerd op basis van de geselecteerde indeling, terwijl de ingevoerde inhoud in die plaatsaanduidingen tot de normale dia behoort.

Voeg de benodigde plaatsaanduidingen toe aan een indeling voordat er dia's van worden gemaakt. Het later toevoegen van een extra plaatsaanduiding aan een indeling voegt niet automatisch een overeenkomstige plaatsaanduidingsvorm toe aan bestaande normale dia's.

Deze relatie heeft twee belangrijke gevolgen:

- Het wijzigen van geërfde opmaak of bestaande plaatsaanduidingsgeometrie op een indeling kan elke dia die ervan afhankelijk is bijwerken. Controleer vóór het bewerken van een reeds gebruikte indeling haar afhankelijke dia's en bekijk de resulterende presentatie.
- Een indeling die nog door een dia wordt gebruikt, kan niet worden verwijderd. Wijs eerst de afhankelijke dia's toe aan een andere indeling, of verwijder alleen ongebruikte indelingen.

Voor meer informatie over het hoogste niveau van deze hiërarchie, zie [Slide Master](/slides/nl/net/slide-master/).

Om geërfde logo’s of decoratieve master‑vormen op één dia of via een gedeelde indeling te verbergen, zie [Control the Visibility of Master Graphics](/slides/nl/net/slide-master/). Het voorbeeld vergelijkt twee dia's die dezelfde master gebruiken.

## **Selecteer en Pas een Dia‑indeling Toe**

Gebruik een indelingstype wanneer de presentatie de standaard PowerPoint‑indelingsdefinities volgt. Indelingsnamen zijn door de gebruiker bewerkbaar en kunnen worden gelokaliseerd, dus op naam selecteren is minder betrouwbaar tenzij je de bron‑template beheert.

Het volgende voorbeeld zoekt naar **Titel en Inhoud** op de eerste master. Als die indeling niet beschikbaar is, valt het opzettelijk terug op **Leeg**. De tweede null‑controle is noodzakelijk omdat een presentatie alleen aangepaste indelingen kan bevatten. De geselecteerde indeling wordt vervolgens toegepast op de eerste normale dia via de [ISlide.LayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/layoutslide/) eigenschap.

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

Het wijzigen van de indeling van een dia verwijdert niet de gewone vormen die direct aan de dia zijn toegevoegd. Echter, positie van plaatsaanduidingen, geërfde opmaak en de overeenkomst tussen bestaande plaatsaanduidingen en de nieuwe indeling kunnen veranderen, dus controleer de output bij het wisselen tussen wezenlijk verschillende indelingen.

## **Voeg een Indelings‑dia Toe**

Selectie en creatie zijn afzonderlijke handelingen. Het vorige voorbeeld selecteert een bestaande indeling; het maakt er geen nieuwe. Om een indeling te maken, roep je de [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/nl/net/aspose.slides/masterlayoutslidecollection/add/) methode aan op de indelingscollectie van de doel‑master.

Het volgende voorbeeld voegt altijd een nieuwe **Titel en Inhoud**‑indeling toe met de naam `Report Title and Content`, en voegt vervolgens een normale dia toe die daarop is gebaseerd. Indelingsnamen moeten uniek zijn binnen de collectie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Voeg een indeling alleen toe wanneer de template werkelijk een extra herbruikbare structuur nodig heeft. Als er al een geschikte indeling bestaat, selecteer en hergebruik die in plaats van een duplicaat te maken.

## **Voeg Plaatsaanduidingen Toe aan een Indelings‑dia**

De eigenschap [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/placeholdermanager/) biedt een [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutplaceholdermanager/) om plaatsaanduidingsvormen aan een indeling toe te voegen.

| PowerPoint‑plaatsaanduiding | `ILayoutPlaceholderManager`‑methode |
| --------------------------- | ----------------------------------- |
| ![Inhoud](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Inhoud (Verticaal)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Tekst](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Tekst (Verticaal)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Afbeelding](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagram](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Tabel](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online‑afbeelding](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Het volgende voorbeeld controleert of de **Leeg**‑indeling bestaat, voegt er vier plaatsaanduidingen aan toe, en maakt vervolgens een normale dia die de aangepaste indeling gebruikt. De volgorde is opzettelijk: de plaatsaanduidingen worden toegevoegd vóórdat de normale dia wordt aangemaakt, zodat Aspose.Slides de overeenkomstige plaatsaanduidingsvormen op die dia kan genereren.

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

![De plaatsaanduidingen op de indelings‑dia](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Het wijzigen van geërfde opmaak of de geometrie van bestaande indelings‑plaatsaanduidingen kan van invloed zijn op afhankelijke dia's. Een nieuw toegevoegde indelings‑plaatsaanduiding wordt niet teruggevoerd naar bestaande normale dia's. Test indelingswijzigingen op een kopie van de presentatie en inspecteer elke afhankelijke dia.
{{% /alert %}}

## **Verwijder Ongebruikte Indelings‑dia's**

Gebruik de [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) methode om indelingen te verwijderen die door geen enkele normale dia worden gerefereerd. De methode laat indelingen die nog in gebruik zijn ongewijzigd.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Om één specifieke indeling te verwijderen, gebruik eerst de [HasDependingSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/hasdependingslides/) eigenschap of de [GetDependingSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/getdependingslides/) methode. Ken eventuele afhankelijke dia's opnieuw toe vóór het aanroepen van [ILayoutSlide.Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/remove/). Het proberen te verwijderen van een gebruikte indeling veroorzaakt een [PptxEditException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxeditexception/).

## **Beheer Voettekst‑Zichtbaarheid op een Indelings‑dia**

Een indeling heeft haar eigen voettekst-, dia‑nummer- en datum‑tijd‑plaatsaanduidingen. Gebruik de [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/headerfootermanager/) eigenschap om die plaatsaanduidingen voor één indeling te beheren. Dit is handig wanneer bijvoorbeeld inhoud‑indelingen voetteksten moeten tonen maar titel‑indelingen niet.

Het volgende voorbeeld selecteert veilig een indeling en maakt haar voettekst‑elementen zichtbaar:

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

## **Beheer Voettekst‑Zichtbaarheid op een Master en Haar Kind‑indelingen**

Om consistente voettekst‑instellingen toe te passen over een master‑hiërarchie, gebruik je de [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/headerfootermanager/) eigenschap. De propagatiemethoden van [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslideheaderfootermanager/) werken op de master en haar afhankelijke indelings‑dia's en normale dia's; ze richten zich niet op één enkele normale dia.

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

**Wat is het verschil tussen een master‑dia en een indelings‑dia?**

Een master‑dia definieert het thema en de gedeelde opmaak van de presentatie. Een indelings‑dia behoort tot een master en definieert één herbruikbare rangschikking van plaatsaanduidingen. Normale dia's gebruiken die indelingen en slaan dia‑specifieke inhoud op.

**Kan ik een indelings‑dia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de doel‑collectie met de [AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/globallayoutslidecollection/addclone/) methode. Bij het kopiëren tussen presentaties moet je ook de lettertypen, thema’s, afbeeldingen en andere bronnen die door de bron‑indeling worden gebruikt verifiëren.

**Wat gebeurt er als ik een al gebruikte indeling aanpas?**

Afhankelijke dia's erven de indelingswijzigingen tenzij ze de betreffende opmaak of objecten lokaal overschrijven. De geometrie van plaatsaanduidingen en de geërfde stijl kunnen daardoor op veel dia's tegelijk veranderen. Gebruik [GetDependingSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/getdependingslides/) om de betrokken dia's te identificeren vóór het bewerken van de indeling.

**Wat gebeurt er als ik een nog gebruikte indeling verwijder?**

Aspose.Slides geeft een [PptxEditException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxeditexception/) fout. Wijs eerst de afhankelijke dia's opnieuw toe, of gebruik [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) om alleen niet‑gerefereerde indelingen te verwijderen.