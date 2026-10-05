---
title: Presentaties converteren naar HTML5 op Android
linktitle: Presentatie naar HTML5
type: docs
weight: 40
url: /nl/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint en OpenDocument presentaties exporteren naar responsieve HTML5 met Aspose.Slides voor Android via Java. Opmaak, animaties en interactiviteit behouden."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties naar HTML5 kunt converteren met Aspose.Slides voor Android via Java. Het behandelt basisexport, het regelen van vormanimaties en dia‑overgangen, en de lay‑out van opmerkingen. Het vergelijkt ook de HTML5‑uitvoer met de SVG‑gebaseerde uitvoer van de standaard HTML‑export.

## **PowerPoint exporteren naar HTML5**

Het volgende voorbeeld laadt een presentatie uit de werkmap en slaat deze op in HTML5‑indeling. Het gebruikt de standaard exportinstellingen; het volgende voorbeeld laat zien hoe u de weergave van animaties expliciet kunt regelen. Vervang het invoerpad door het pad naar uw presentatie.

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
Naast het HTML‑document schrijft de export ondersteunende CSS‑ en JavaScript‑bestanden voor dia‑styling, animaties, effecten en navigatie. Houd deze bestanden bij het HTML‑document wanneer u de output verplaatst of publiceert. De gegenereerde pagina laadt ook jQuery en Anime.js van openbare CDN’s; zonder deze werken dia‑navigatie en animaties niet.
{{% /alert %}}

Om te exporteren zonder vormanimaties of dia‑overgangen af te spelen, geeft u `false` door aan [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) en [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Deze instellingen zijn onafhankelijk, dus u kunt de ene inschakelen terwijl u de andere uitschakelt. Het voorbeeld exporteert de presentatie met beide soorten animatie uitgeschakeld in de gegenereerde pagina.

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

## **PowerPoint exporteren naar HTML**

De standaard HTML‑export gebruikt een andere rendermethode: de dia‑inhoud wordt weergegeven als SVG binnen een HTML‑pagina. Het volgende voorbeeld converteert een presentatie naar een HTML‑document met behulp van deze rendermethode.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

De vereenvoudigde markup hieronder illustreert de structuur van de gegenereerde pagina. Het SVG‑element bevat de gerenderde dia‑inhoud; de plaatshoudertekst stelt die inhoud voor en is geen letterlijke exportoutput.

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
De op SVG gebaseerde export maakt PowerPoint‑vormen niet beschikbaar als afzonderlijke HTML‑elementen. Gebruik HTML5‑export wanneer u de vorm‑animatie‑ en dia‑overgangsopties nodig heeft die in dit artikel worden gedemonstreerd.
{{% /alert %}}

## **PowerPoint exporteren naar HTML5‑diaweergave**

HTML5‑export genereert een pagina voor het bekijken en navigeren van de presentatiedia’s in een browser. Dit voorbeeld schakelt zowel [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) als [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in zodat de geëxporteerde dia‑weergave effecten uit de bronpresentatie kan afspelen.

Gebruik een presentatie die al vormanimaties en dia‑overgangen bevat om het effect van deze instellingen te zien. Ze inschakelen voegt geen nieuwe effecten toe aan dia’s die geen animaties hebben. Open na het exporteren het gegenereerde HTML5‑document in een browser met de bijbehorende ondersteunende bestanden beschikbaar.

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

## **Een presentatie converteren naar een HTML5‑document met opmerkingen**

U kunt bestaande dia‑opmerkingen opnemen in de HTML5‑output, zodat lezers feedback naast de dia‑inhoud kunnen zien. Het voorbeeld in deze sectie gaat ervan uit dat de bronpresentatie opmerkingen bevat, zoals hieronder geïllustreerd. Het exporteert die opmerkingen; het maakt geen nieuwe aan.

![Two comments on the presentation slide](two_comments_pptx.png)

Geef een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/)‑object door aan de [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)‑methode van [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/). Gebruik [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) om `Right` te selecteren uit de [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/)‑enumeratie om de opmerkingen rechts van elke dia te plaatsen.

Het volgende voorbeeld exporteert de presentatie naar HTML5 met deze opmerkinglay‑out. Een presentatie zonder opmerkingen zal geen opmerkingstekst weergeven.

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

De afbeelding hieronder toont het geëxporteerde HTML5‑document met de opmerkingen naast de dia weergegeven.

![The comments in the output HTML5 document](two_comments_html5.png)

## **JavaScript‑hyperlinks uitsluiten tijdens export**

Stel dat `hyperlinks.pptx` gekoppelde tekst bevat met een `javascript:alert('Hello')`‑doel en een gewone `https://example.com/`‑link. Om de JavaScript‑hyperlink tijdens export uit te sluiten, geeft u `true` door aan [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). De standaardwaarde is `false`, dus deze links worden niet gefilterd tenzij u de optie inschakelt.

Het volgende voorbeeld laadt de presentatie uit de werkmap en exporteert deze met behulp van [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/):

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

Het geëxporteerde bestand laat de JavaScript‑hyperlink weg, terwijl de tekst en de gewone HTTPS‑link behouden blijven. De bronpresentatie blijft ongewijzigd.

Deze optie filtert JavaScript‑hyperlinks; hij verwijdert niet alle scripts of andere actieve inhoud, noch garandeert hij CSP‑naleving. Bijvoorbeeld, de HTML5‑output bevat nog steeds scripts voor dia‑navigatie en animaties.

## **Veelgestelde vragen**

**Kan ik regelen of objectanimaties en dia‑overgangen in HTML5 worden afgespeeld?**

Ja, HTML5‑export biedt afzonderlijke opties om [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) en [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) in te schakelen of uit te schakelen.

**Worden opmerkingen ondersteund, en waar kunnen ze ten opzichte van de dia worden geplaatst?**

Ja, bestaande opmerkingen kunnen in de HTML5‑output worden opgenomen en via [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) voor notities en opmerkingen worden gepositioneerd (bijvoorbeeld rechts van de dia).

**Kan ik links die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?**

Ja, de [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-)‑instelling stelt u in staat om hyperlinks met JavaScript‑aanroepen over te slaan tijdens het opslaan. De standaardwaarde is `false`. Zie [JavaScript‑hyperlinks uitsluiten tijdens export](/slides/nl/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) voor een HTML5‑exportvoorbeeld en de reikwijdte van het filter. Deze instelling verwijdert niet de JavaScript die door de HTML5‑viewer wordt gebruikt voor navigatie en animaties.