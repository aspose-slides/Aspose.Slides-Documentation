---
title: Presentaties omzetten naar HTML5 in Java
linktitle: Presentatie naar HTML5
type: docs
weight: 40
url: /nl/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Exporteer PowerPoint‑ en OpenDocument‑presentaties naar responsieve HTML5 met Aspose.Slides voor Java. Behoud opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe PowerPoint‑presentaties te converteren naar HTML5 met Aspose.Slides voor Java. Het behandelt basis‑export, controle van vormanimaties en dia‑overgangen, en de opstelling van opmerkingen. Daarnaast vergelijkt het HTML5‑output met de SVG‑gebaseerde output van de standaard HTML‑export.

## **Export PowerPoint naar HTML5**

Het volgende voorbeeld laadt een presentatie uit de werkmap en slaat deze op in HTML5‑formaat. Het gebruikt de standaard exportinstellingen; het volgende voorbeeld laat zien hoe u de animatie‑weergave expliciet kunt regelen. Vervang het invoerpad door het pad naar uw presentatie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Naast het HTML‑document schrijft de export ondersteunende CSS‑ en JavaScript‑bestanden voor dia‑styling, animaties, effecten en navigatie. Houd deze bestanden bij het HTML‑document wanneer u de output verplaatst of publiceert. De gegenereerde pagina laadt ook jQuery en Anime.js vanaf openbare CDN's; zonder deze werken dia‑navigatie en animaties niet.
{{% /alert %}}

Om te exporteren zonder vormanimaties of dia‑overgangen af te spelen, geeft u `false` door aan [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) en [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Deze instellingen zijn onafhankelijk, zodat u er één kunt inschakelen terwijl de andere wordt uitgeschakeld. Het voorbeeld exporteert de presentatie met beide soorten animatie uitgeschakeld in de gegenereerde pagina.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Export PowerPoint naar HTML**

De standaard HTML‑export gebruikt een andere renderingsmethode: de inhoud van de dia wordt weergegeven als SVG in een HTML‑pagina. Het volgende voorbeeld zet een presentatie om naar een HTML‑document met deze renderingsmethode.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

De vereenvoudigde markup hieronder toont de structuur van de gegenereerde pagina. Het SVG‑element bevat de gerenderde dia‑inhoud; de plaatshoudertekst stelt die inhoud voor en is geen letterlijke exportoutput.

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
De SVG‑gebaseerde export stelt PowerPoint‑vormen niet beschikbaar als afzonderlijke HTML‑elementen. Gebruik HTML5‑export wanneer u de vorm‑animatie‑ en dia‑overgangsopties nodig heeft die in dit artikel worden gedemonstreerd.
{{% /alert %}}

## **Export PowerPoint naar HTML5‑diaweergave**

HTML5‑export genereert een pagina voor het bekijken en navigeren van de presentatiedia's in een browser. Dit voorbeeld schakelt zowel [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) als [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in zodat de geëxporteerde diaweergave effecten uit de oorspronkelijke presentatie kan afspelen.

Gebruik een presentatie die al vormanimaties en dia‑overgangen bevat om het effect van deze instellingen te zien. Het inschakelen ervan voegt geen nieuwe effecten toe aan dia's zonder animaties. Na export opent u het gegenereerde HTML5‑document in een browser met de bijbehorende ondersteunende bestanden beschikbaar.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Converteer een presentatie naar een HTML5‑document met opmerkingen**

U kunt bestaande dia‑opmerkingen opnemen in de HTML5‑output zodat lezers feedback naast de dia‑inhoud kunnen zien. Het voorbeeld in deze sectie gaat ervan uit dat de bronpresentatie opmerkingen bevat, zoals hieronder geïllustreerd. Het exporteert die opmerkingen; het maakt geen nieuwe aan.

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Geef een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) object door aan de [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) methode van [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/). Gebruik [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) om `Right` te selecteren uit de [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) enumeratie om de opmerkingen rechts van elke dia te plaatsen.

Het volgende voorbeeld exporteert de presentatie naar HTML5 met deze opmerkingen‑indeling. Een presentatie zonder opmerkingen zal geen opmerkingentekst tonen.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

De afbeelding hieronder toont het geëxporteerde HTML5‑document met de opmerkingen naast de dia.

![De opmerkingen in het gegenereerde HTML5‑document](two_comments_html5.png)

## **JavaScript‑hyperlinks uitsluiten tijdens export**

Stel dat `hyperlinks.pptx` tekst bevat met een `javascript:alert('Hello')`‑doel en een gewone `https://example.com/`‑link. Om de JavaScript‑hyperlink tijdens export uit te sluiten, geeft u `true` door aan [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). Standaard is dit `false`, waardoor deze links niet worden gefilterd tenzij u de optie inschakelt.

Het volgende voorbeeld laadt de presentatie uit de werkmap en exporteert deze met behulp van [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/):

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

Het geëxporteerde bestand laat de JavaScript‑hyperlink weg, maar behoudt de tekst ervan en de gewone HTTPS‑link. De bronpresentatie blijft ongewijzigd.

Deze optie filtert JavaScript‑hyperlinks; hij verwijdert niet alle scripts of andere actieve inhoud, en garandeert ook geen CSP‑naleving. Bijvoorbeeld, HTML5‑output bevat nog steeds scripts voor dia‑navigatie en animaties.

## **Veelgestelde vragen**

**Kan ik regelen of objectanimaties en dia‑overgangen afspelen in HTML5?**

Ja, HTML5‑export biedt afzonderlijke opties om [vormanimaties](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) en [dia‑overgangen](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in of uit te schakelen.

**Worden opmerkingen ondersteund, en waar kunnen ze worden geplaatst ten opzichte van de dia?**

Ja, bestaande opmerkingen kunnen worden opgenomen in de HTML5‑output en gepositioneerd (bijvoorbeeld rechts van de dia) via [indelingsinstellingen](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) voor notities en opmerkingen.

**Kan ik links die JavaScript aanroepen overslaan om veiligheids- of CSP‑redenen?**

Ja, de [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) instelling stelt u in staat hyperlinks met JavaScript‑aanroepen over te slaan tijdens het opslaan. Standaard is `false`. Zie [JavaScript‑hyperlinks uitsluiten tijdens export](/slides/nl/java/export-to-html5/#exclude-javascript-hyperlinks-during-export) voor een HTML5‑exportvoorbeeld en de reikwijdte van het filter. Deze instelling verwijdert niet de JavaScript die door de HTML5‑viewer wordt gebruikt voor navigatie en animaties.