---
title: Presentaties omzetten naar HTML5 in .NET
linktitle: Presentatie naar HTML5
type: docs
weight: 40
url: /nl/net/export-to-html5/
keywords:
- PowerPoint naar HTML5
- OpenDocument naar HTML5
- presentatie naar HTML5
- dia naar HTML5
- PPT naar HTML5
- PPTX naar HTML5
- ODP naar HTML5
- PPT opslaan als HTML5
- PPTX opslaan als HTML5
- ODP opslaan als HTML5
- export PPT naar HTML5
- export PPTX naar HTML5
- export ODP naar HTML5
- .NET
- C#
- Aspose.Slides
description: "Export PowerPoint & OpenDocument presentaties naar responsieve HTML5 met Aspose.Slides voor .NET. Behoud opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint‑presentaties kunt converteren naar HTML5 met Aspose.Slides voor .NET. Het behandelt basis‑export, het regelen van vormanimaties en dia‑overgangen, en de lay‑out van commentaren. Het vergelijkt ook de HTML5‑output met de op SVG gebaseerde output van de standaard HTML‑export.

## **PowerPoint exporteren naar HTML5**

Het volgende voorbeeld laadt een presentatie vanuit de werkmap en slaat deze op in HTML5‑formaat. Het gebruikt de standaard exportinstellingen; het volgende voorbeeld laat zien hoe je de animatie‑afspeelmodus expliciet kunt regelen. Vervang het invoerpad door het pad naar jouw presentatie.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
Naast het HTML‑document schrijft de export ondersteunende CSS‑ en JavaScript‑bestanden voor diastijling, animaties, effecten en navigatie. Bewaar deze bestanden samen met het HTML‑document bij het verplaatsen of publiceren van de uitvoer. De gegenereerde pagina laadt bovendien jQuery en Anime.js vanaf openbare CDN’s; zonder deze werken diavergelijking en animaties niet.
{{% /alert %}}

Om te exporteren zonder vormanimaties of dia‑overgangen af te spelen, stel je [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) en [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) in op `false` in [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Deze instellingen zijn onafhankelijk, dus je kunt er één inschakelen terwijl je de andere uitschakelt. Het voorbeeld exporteert de presentatie met beide soorten animatie uitgeschakeld in de gegenereerde pagina.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **PowerPoint exporteren naar HTML**

De standaard HTML‑export maakt gebruik van een andere render-benadering: diacontent wordt weergegeven als SVG binnen een HTML‑pagina. Het volgende voorbeeld converteert een presentatie naar een HTML‑document met deze render‑benadering.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

De vereenvoudigde markup hieronder illustreert de structuur van de gegenereerde pagina. Het SVG‑element bevat de gerenderde diacontent; de tijdelijke‑tekst stelt die content voor en is geen letterlijke exportoutput.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
De op SVG‑gebaseerde export maakt PowerPoint‑vormen niet beschikbaar als individuele HTML‑elementen. Gebruik HTML5‑export wanneer je de vorm‑animatie‑ en dia‑overgangsopties nodig hebt die in dit artikel worden gedemonstreerd.
{{% /alert %}}

## **PowerPoint exporteren naar HTML5‑diavoorstelling**

HTML5‑export levert een pagina voor het bekijken en navigeren van de presentatiedia’s in een browser. Dit voorbeeld schakelt zowel [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) als [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) in zodat de geëxporteerde diavoorstelling effecten uit de bronpresentatie kan afspelen.

Gebruik een presentatie die al vormanimaties en dia‑overgangen bevat om het effect van deze instellingen te zien. Het inschakelen ervan voegt geen nieuwe effecten toe aan dia’s die geen animaties hebben. Na export open je het gegenereerde HTML5‑document in een browser met de ondersteunende bestanden beschikbaar.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Een presentatie converteren naar een HTML5‑document met commentaren**

Je kunt bestaande dia‑commentaren opnemen in de HTML5‑output zodat lezers feedback naast de diacontent kunnen zien. Het voorbeeld in deze sectie gaat ervan uit dat de bronpresentatie commentaren bevat, zoals hieronder geïllustreerd. Het exporteert die commentaren; het creëert geen nieuwe.

![Twee commentaren op de presentatiedia](two_comments_pptx.png)

Wijs een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/)‑object toe aan de [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/)‑eigenschap van [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Stel [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) in op `Right` vanuit de enumeratie [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) om de commentaren rechts van elke dia te plaatsen.

Het volgende voorbeeld exporteert de presentatie naar HTML5 met deze commentaarlay‑out. Een presentatie zonder commentaren heeft geen commentaartekst om weer te geven.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

De afbeelding hieronder toont het geëxporteerde HTML5‑document met de commentaren naast de dia.

![De commentaren in het uitvoer‑HTML5‑document](two_comments_html5.png)

## **JavaScript‑hyperlinks uitsluiten tijdens export**

Stel dat `hyperlinks.pptx` tekst bevat met een `javascript:alert('Hello')`‑doel en een gewone `https://example.com/`‑link. Om de JavaScript‑hyperlink tijdens export uit te sluiten, stel je [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) in op `true`. Standaard is dit `false`, dus deze links worden niet gefilterd tenzij je de optie inschakelt.

Het volgende voorbeeld laadt de presentatie vanuit de werkmap en exporteert deze met [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

Het geëxporteerde bestand laat de JavaScript‑hyperlink weg terwijl de tekst en de gewone HTTPS‑link behouden blijven. De bronpresentatie blijft ongewijzigd.

Deze optie filtert JavaScript‑hyperlinks; hij verwijdert niet alle scripts of andere actieve content, noch garandeert hij CSP‑naleving. Bijvoorbeeld, HTML5‑output bevat nog steeds scripts voor diavernavigatie en animaties.

## **FAQ**

**Kan ik regelen of objectanimaties en dia‑overgangen afgespeeld worden in HTML5?**

Ja, de HTML5‑export biedt afzonderlijke opties om [vormanimaties](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) en [dia‑overgangen](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) in of uit te schakelen.

**Worden commentaren ondersteund, en waar kunnen ze ten opzichte van de dia worden geplaatst?**

Ja, bestaande commentaren kunnen worden opgenomen in de HTML5‑output en via [lay‑outinstellingen](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) (bijvoorbeeld rechts van de dia) worden gepositioneerd.

**Kan ik links die JavaScript aanroepen overslaan voor beveiliging of CSP‑redenen?**

Ja, de [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/)‑instelling maakt het mogelijk JavaScript‑hyperlinks over te slaan tijdens het opslaan. Standaard is dit `false`. Zie [JavaScript‑hyperlinks uitsluiten tijdens export](/slides/nl/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) voor een eenvoudig voorbeeld van HTML‑, HTML5‑ en PDF‑export en de reikwijdte van het filter. Deze instelling verwijdert niet de JavaScript die door de HTML5‑viewer wordt gebruikt voor navigatie en animaties.