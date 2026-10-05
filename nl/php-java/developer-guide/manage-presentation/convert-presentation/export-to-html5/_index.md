---
title: Presentaties converteren naar HTML5 in PHP
linktitle: Presentatie naar HTML5
type: docs
weight: 40
url: /nl/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar responsieve HTML5 met Aspose.Slides voor PHP via Java. Behoud de opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint‑presentaties kunt converteren naar HTML5 met Aspose.Slides voor PHP via Java. Het behandelt basisexport, het regelen van vormanimaties en dia‑overgangen, en de opmaak van commentaar. Het vergelijkt ook de HTML5‑output met de SVG‑gebaseerde output van de standaard HTML‑export.

## **PowerPoint exporteren naar HTML5**

Het volgende voorbeeld laadt een presentatie vanuit de werkmap en slaat deze op in HTML5‑formaat. Het gebruikt de standaard exportinstellingen; het volgende voorbeeld laat zien hoe je de animatie‑afspelen expliciet kunt regelen. Vervang het invoerpad door het pad naar jouw presentatie.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Naast het HTML‑document schrijft de export ondersteunende CSS‑ en JavaScript‑bestanden voor dia‑styling, animaties, effecten en navigatie. Houd deze bestanden bij het HTML‑document wanneer je de output verplaatst of publiceert. De gegenereerde pagina laadt ook jQuery en Anime.js van openbare CDN’s; zonder deze werken dia‑navigatie en animaties niet.
{{% /alert %}}

Om te exporteren zonder vormanimaties of dia‑overgangen af te spelen, geef je `false` door aan [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) en [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) in [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Deze instellingen zijn onafhankelijk, zodat je er één kunt inschakelen terwijl je de andere uitschakelt. Het voorbeeld exporteert de presentatie met beide type animaties uitgeschakeld in de gegenereerde pagina.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **PowerPoint exporteren naar HTML**

De standaard HTML‑export gebruikt een andere renderingsmethode: dia‑inhoud wordt weergegeven als SVG binnen een HTML‑pagina. Het volgende voorbeeld converteert een presentatie naar een HTML‑document met deze renderingsmethode.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
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
De op SVG gebaseerde export geeft PowerPoint‑vormen niet weer als individuele HTML‑elementen. Gebruik HTML5‑export wanneer je de vorm‑animatie‑ en dia‑overgangsopties nodig hebt die in dit artikel worden gedemonstreerd.
{{% /alert %}}

## **PowerPoint exporteren naar HTML5-diaweergave**

HTML5‑export genereert een pagina voor het bekijken en navigeren van de presentatiedia's in een browser. Dit voorbeeld schakelt zowel [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) als [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) in zodat de geëxporteerde diaweergave effecten uit de oorspronkelijke presentatie kan afspelen.

Gebruik een presentatie die al vormanimaties en dia‑overgangen bevat om het effect van deze instellingen te zien. Ze inschakelen voegt geen nieuwe effecten toe aan dia's die geen hebben. Open na het exporteren het gegenereerde HTML5‑document in een browser met de bijbehorende ondersteunende bestanden beschikbaar.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Een presentatie omzetten naar een HTML5‑document met commentaar**

Je kunt bestaande dia‑commentaren opnemen in de HTML5‑output zodat lezers feedback naast de dia‑inhoud kunnen zien. Het voorbeeld in deze sectie gaat ervan uit dat de bronpresentatie commentaren bevat, zoals hieronder geïllustreerd. Het exporteert die commentaren; het maakt geen nieuwe aan.

![Twee commentaren op de presentatiedia](two_comments_pptx.png)

Geef een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/)‑object door aan de [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions)‑methode van [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Gebruik [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) om `Right` te selecteren uit de enumeratie [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/), zodat de commentaren rechts van elke dia worden geplaatst.

Het volgende voorbeeld exporteert de presentatie naar HTML5 met deze commentaarruimte. Een presentatie zonder commentaren zal geen commentaartekst weergeven.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

De afbeelding hieronder toont het geëxporteerde HTML5‑document met de commentaren naast de dia.

![De commentaren in het geëxporteerde HTML5‑document](two_comments_html5.png)

## **JavaScript‑hyperlinks uitsluiten tijdens export**

Stel dat `hyperlinks.pptx` gelinkte tekst bevat met een `javascript:alert('Hello')`‑target en een gewone `https://example.com/`‑link. Om de JavaScript‑hyperlink tijdens export uit te sluiten, geef je `true` door aan [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). Standaard is `false`, dus deze links worden niet gefilterd tenzij je de optie inschakelt.

Het volgende voorbeeld laadt de presentatie vanuit de werkmap en exporteert deze met behulp van [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/):

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

Het geëxporteerde bestand laat de JavaScript‑hyperlink weg terwijl de tekst en de gewone HTTPS‑link behouden blijven. De bronpresentatie blijft onveranderd.

Deze optie filtert JavaScript‑hyperlinks; hij verwijdert niet alle scripts of andere actieve inhoud, noch garandeert hij CSP‑naleving. Bijvoorbeeld, de HTML5‑output bevat nog steeds scripts voor dia‑navigatie en animaties.

## **FAQ**

**Kan ik regelen of objectanimaties en dia‑overgangen afgespeeld worden in HTML5?**

Ja, HTML5‑export biedt afzonderlijke opties om [vormanimaties](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) en [dia‑overgangen](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) in te schakelen of uit te schakelen.

**Worden commentaren ondersteund, en waar kunnen ze ten opzichte van de dia geplaatst worden?**

Ja, bestaande commentaren kunnen worden opgenomen in de HTML5‑output en via [lay‑outinstellingen](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) voor notities en commentaren gepositioneerd worden (bijvoorbeeld rechts van de dia).

**Kan ik links die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?**

Ja, de instelling [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) maakt het mogelijk om hyperlinks met JavaScript‑aanroepen over te slaan tijdens het opslaan. Standaard is `false`. Zie [Exclude JavaScript Hyperlinks During Export](/slides/nl/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) voor een HTML5‑exportvoorbeeld en de reikwijdte van het filter. Deze instelling verwijdert niet de JavaScript die door de HTML5‑viewer wordt gebruikt voor navigatie en animaties.