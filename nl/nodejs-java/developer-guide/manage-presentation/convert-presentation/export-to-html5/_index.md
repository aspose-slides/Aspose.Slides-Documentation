---
title: Presentaties converteren naar HTML5 in JavaScript
linktitle: Presentatie naar HTML5
type: docs
weight: 40
url: /nl/nodejs-java/export-to-html5/
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
- PPT exporteren naar HTML5
- PPTX exporteren naar HTML5
- ODP exporteren naar HTML5
- Node.js
- JavaScript
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument‑presentaties naar responsieve HTML5 met Aspose.Slides voor Node.js. Behoud opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt converteren naar HTML5 met Aspose.Slides voor Node.js via Java. Het behandelt basis‑export, het regelen van vormanimaties en dia‑overgangen, en de opmaak van opmerkingen. Het vergelijkt ook de HTML5‑output met de op SVG gebaseerde output van de standaard HTML‑export.

## **PowerPoint exporteren naar HTML5**

Het volgende voorbeeld laadt een presentatie uit de werkmap en slaat deze op in HTML5‑formaat. Het maakt gebruik van de standaard exportinstellingen; het volgende voorbeeld toont hoe u de weergave van animaties expliciet kunt regelen. Vervang het invoerpad door het pad naar uw presentatie.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Naast het HTML‑document schrijft de export ondersteunende CSS‑ en JavaScript‑bestanden voor dia‑styling, animaties, effecten en navigatie. Houd deze bestanden samen met het HTML‑document bij het verplaatsen of publiceren van de output. De gegenereerde pagina laadt bovendien jQuery en Anime.js van publieke CDN’s; zonder deze werken dia‑navigatie en animaties niet.
{{% /alert %}}

Om te exporteren zonder vorm‑animaties of dia‑overgangen af te spelen, geeft u `false` door aan [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) en [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) in [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Deze instellingen zijn onafhankelijk, dus u kunt er één inschakelen terwijl u de andere uitschakelt. Het voorbeeld exporteert de presentatie met beide soorten animatie uitgeschakeld in de gegenereerde pagina.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **PowerPoint exporteren naar HTML**

De standaard HTML‑export gebruikt een andere renderingsaanpak: de dia‑inhoud wordt weergegeven als SVG binnen een HTML‑pagina. Het volgende voorbeeld converteert een presentatie naar een HTML‑document met deze renderingsaanpak.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

De vereenvoudigde markup hieronder illustreert de structuur van de gegenereerde pagina. Het SVG‑element bevat de gerenderde dia‑inhoud; de tijdelijke‑plaatstekst stelt die inhoud voor en is geen letterlijke exportoutput.

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
De op SVG gebaseerde export maakt PowerPoint‑vormen niet beschikbaar als individuele HTML‑elementen. Gebruik de HTML5‑export wanneer u de vorm‑animatie‑ en dia‑overgangsopties nodig heeft die in dit artikel worden gedemonstreerd.
{{% /alert %}}

## **PowerPoint exporteren naar HTML5‑diaweergave**

HTML5‑export genereert een pagina om de presentatiedia's in een browser te bekijken en te navigeren. Dit voorbeeld schakelt zowel [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) als [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) in zodat de geëxporteerde diaweergave de effecten van de oorspronkelijke presentatie kan afspelen.

Gebruik een presentatie die al vormanimaties en dia‑overgangen bevat om het effect van deze instellingen te zien. Het inschakelen ervan voegt geen nieuwe effecten toe aan dia's zonder animaties. Open na het exporteren het gegenereerde HTML5‑document in een browser waarbij de ondersteunende bestanden beschikbaar zijn.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Een presentatie converteren naar een HTML5‑document met opmerkingen**

U kunt bestaande dia‑opmerkingen opnemen in de HTML5‑output zodat lezers feedback naast de dia‑inhoud kunnen zien. Het voorbeeld in deze sectie gaat ervan uit dat de bronpresentatie opmerkingen bevat, zoals hieronder geïllustreerd. Het exporteert die opmerkingen; het maakt geen nieuwe aan.

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Geef een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) object door aan de [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) methode van [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Gebruik [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) om `Right` te selecteren uit de [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) enumeratie om de opmerkingen rechts van elke dia te plaatsen.

Het volgende voorbeeld exporteert de presentatie naar HTML5 met deze opmerkingenlay-out. Een presentatie zonder opmerkingen zal geen opmerkingstekst weergeven.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

De afbeelding hieronder toont het geëxporteerde HTML5‑document met de opmerkingen naast de dia.

![De opmerkingen in het uitvoer‑HTML5‑document](two_comments_html5.png)

## **JavaScript‑hyperlinks uitsluiten tijdens export**

Stel dat `hyperlinks.pptx` tekst bevat die gelinkt is aan een `javascript:alert('Hello')`‑doel en een gewone `https://example.com/`‑link. Om de JavaScript‑hyperlink tijdens export uit te sluiten, geeft u `true` door aan [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). De standaardwaarde is `false`, zodat deze links niet worden gefilterd tenzij u de optie inschakelt.

Het volgende voorbeeld laadt de presentatie uit de werkmap en exporteert deze met behulp van [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Het geëxporteerde bestand laat de JavaScript‑hyperlink weg terwijl de tekst en de gewone HTTPS‑link behouden blijven. De bronpresentatie blijft ongewijzigd.

Deze optie filtert JavaScript‑hyperlinks; hij verwijdert niet alle scripts of andere actieve inhoud, noch garandeert hij CSP‑conformiteit. Bijvoorbeeld, HTML5‑output bevat nog steeds scripts voor dia‑navigatie en animaties.

## **FAQ**

**Kan ik regelen of objectanimaties en dia‑overgangen worden afgespeeld in HTML5?**

Ja, de HTML5‑export biedt afzonderlijke opties om [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) en [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) in of uit te schakelen.

**Worden opmerkingen ondersteund, en waar kunnen ze ten opzichte van de dia worden geplaatst?**

Ja, bestaande opmerkingen kunnen worden opgenomen in de HTML5‑output en gepositioneerd (bijvoorbeeld rechts van de dia) via [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) voor aantekeningen en opmerkingen.

**Kan ik links die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?**

Ja, de instelling [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) maakt het mogelijk hyperlinks met JavaScript‑aanroepen over te slaan tijdens het opslaan. De standaardwaarde is `false`. Zie [Exclude JavaScript Hyperlinks During Export](/slides/nl/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) voor een HTML5‑exportvoorbeeld en de reikwijdte van de filter. Deze instelling verwijdert niet de JavaScript die door de HTML5‑viewer wordt gebruikt voor navigatie en animaties.