---
title: Presentaties converteren naar HTML5 in Python via Java
linktitle: Presentatie naar HTML5
type: docs
weight: 40
url: /nl/python-java/export-to-html5/
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
- Python
- Java
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar responsieve HTML5 met Aspose.Slides voor Python via Java. Behoud de opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe PowerPoint‑presentaties te converteren naar HTML5 met Aspose.Slides. Het behandelt eenvoudige HTML5‑export zonder extra web‑extensies, evenals opties om vormanimaties en dia‑overgangen te regelen. Het artikel toont ook het standaard PowerPoint‑naar‑HTML‑exportproces, legt uit hoe HTML5‑output in dia‑weergavemodus te genereren, en laat zien hoe opmerkingen in het geëxporteerde document op te nemen door hun lay‑out te configureren.

De voorbeelden vereisen Aspose.Slides voor Python via Java en een compatibele Java‑runtime. Plaats `pres.pptx` (of `sample.pptx` voor het voorbeeld met opmerkingen) in de huidige werkmap. Elk voorbeeld start de JVM alleen als deze nog niet draait.

## **Export PowerPoint naar HTML5**

Gebruik [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) met [SaveFormat.Html5](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Html5) om een presentatie te exporteren zonder extra web‑extensies:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Opmerking" %}} 
De HTML5‑exporteur genereert HTML‑inhoud voor weergave in een browser. 
{{% /alert %}}

Gebruik [Html5Options](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/) om de export te configureren. Roep [setAnimateShapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/#setAnimateShapes) en [setAnimateTransitions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/#setAnimateTransitions) aan met `False` om vormanimaties en dia‑overgangen uit te schakelen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Export PowerPoint naar HTML**

Gebruik [SaveFormat.Html](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Html) voor standaard HTML‑export. Zie [PowerPoint converteren naar HTML](/slides/nl/python-java/convert-powerpoint-to-html/) voor meer opties:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

In dit geval wordt de inhoud van de presentatie gerenderd via SVG in een vorm als deze:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Waarschuwing" color="warning" %}} 
Standaard HTML‑export rendert dia‑inhoud via SVG en biedt niet de HTML5‑vorm‑animatie‑ en dia‑overgangsopties. 
{{% /alert %}}

## **Export PowerPoint naar HTML5‑diaweergave**

**Aspose.Slides** stelt je in staat om een PowerPoint‑presentatie te converteren naar een HTML5‑document waarin de dia's worden weergegeven in een dia‑weergavemodus. In dit geval zie je bij het openen van het resulterende HTML5‑bestand in een browser de presentatie in dia‑weergavemodus op een webpagina.

Deze Python‑code demonstreert het exportproces van PowerPoint naar HTML5‑diaweergave:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Presentaties converteren naar HTML5‑documenten met opmerkingen**

Opmerkingen in PowerPoint zijn een hulpmiddel waarmee gebruikers notities of feedback op presentatiedia's kunnen achterlaten. Ze zijn vooral nuttig bij samenwerkingsprojecten, waar meerdere personen hun suggesties of opmerkingen kunnen toevoegen aan specifieke dia‑elementen zonder de hoofdinhoud te wijzigen. Elke opmerking toont de naam van de auteur, waardoor het eenvoudig is om te zien wie de opmerking heeft geplaatst.

Stel dat we de volgende PowerPoint‑presentatie hebben opgeslagen in het bestand "sample.pptx".

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Wanneer je een PowerPoint‑presentatie converteert naar een HTML5‑document, kun je eenvoudig opgeven of opmerkingen uit de presentatie moeten worden opgenomen in het uitvoerdocument. Om dit te doen, geef je de weergave‑parameters voor opmerkingen door aan de methode [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) van de klasse [Html5Options](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/).

Gebruik [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/) en [setCommentsPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) met [CommentsPositions.Right](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commentspositions/#Right). Het volgende code‑voorbeeld zet een presentatie om in een HTML5‑document met opmerkingen die rechts van de dia's worden weergegeven.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Het document "output.html" wordt hieronder weergegeven.

![De opmerkingen in het uitvoer‑HTML5‑document](two_comments_html5.png)

## **Veelgestelde vragen**

**Kan ik bepalen of objectanimaties en dia‑overgangen worden afgespeeld in HTML5?**

Ja, HTML5 biedt afzonderlijke opties om [vormanimaties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/#setAnimateShapes) en [dia‑overgangen](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/#setAnimateTransitions) in te schakelen of uit te schakelen.

**Worden opmerkingen ondersteund in de output, en waar kunnen ze ten opzichte van de dia geplaatst worden?**

Ja, opmerkingen kunnen worden toegevoegd in HTML5 en gepositioneerd (bijvoorbeeld rechts van de dia) via [lay‑outinstellingen](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) voor aantekeningen en opmerkingen.

**Kan ik koppelingen die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?**

Ja, er is een [instelling](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) die het mogelijk maakt om hyperlinks met JavaScript‑oproepen over te slaan tijdens het opslaan. Dit verwijdert die hyperlinks; het garandeert niet automatisch dat alle gegenereerde HTML5‑scripts voldoen aan het Content Security Policy van een site.