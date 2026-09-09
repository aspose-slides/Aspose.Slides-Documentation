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
- export PPT naar HTML5
- export PPTX naar HTML5
- export ODP naar HTML5
- Python
- Java
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar responsieve HTML5 met Aspose.Slides voor Python via Java. Behoud de opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties naar HTML5 kunt converteren met Aspose.Slides. Het behandelt de basis‑HTML5‑export zonder extra web‑extensies, evenals opties voor het regelen van vormanimaties en dia‑overgangen. Het artikel toont ook het standaard PowerPoint‑naar‑HTML‑exportproces, legt uit hoe u HTML5‑output in dia‑weergavemodus genereert, en demonstreert hoe u opmerkingen in het geëxporteerde document kunt opnemen door hun lay‑out te configureren.

De voorbeelden vereisen Aspose.Slides for Python via Java en een compatibele Java‑runtime. Plaats `pres.pptx` (of `sample.pptx` voor het voorbeeld met opmerkingen) in de huidige werkmap. Elk voorbeeld start de JVM alleen als deze nog niet draait.

## **PowerPoint exporteren naar HTML5**

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
De HTML5‑exporteur maakt HTML‑inhoud voor weergave in een browser. 
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

## **PowerPoint exporteren naar HTML**

Gebruik [SaveFormat.Html](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Html) voor standaard HTML‑export. Zie [Convert PowerPoint to HTML](/slides/nl/python-java/convert-powerpoint-to-html/) voor meer opties:

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

In dit geval wordt de presentatie‑inhoud gerenderd via SVG in een vorm als volgt:

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
Standaard HTML‑export rendert dia‑inhoud via SVG en biedt geen HTML5‑vormanimatie‑ en dia‑overgangsopties. 
{{% /alert %}}

## **PowerPoint exporteren naar HTML5‑dia‑weergave**

**Aspose.Slides** maakt het mogelijk een PowerPoint‑presentatie te converteren naar een HTML5‑document waarin de dia's worden gepresenteerd in een dia‑weergavemodus. In dit geval, wanneer u het resulterende HTML5‑bestand in een browser opent, ziet u de presentatie in dia‑weergave op een webpagina. 

Deze Python‑code demonstreert het exportproces van PowerPoint naar HTML5‑dia‑weergave:

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

Opmerkingen in PowerPoint zijn een hulpmiddel waarmee gebruikers notities of feedback achter kunnen laten op dia’s. Ze zijn vooral nuttig in samenwerkingsprojecten, waar meerdere personen suggesties of aantekeningen kunnen toevoegen aan specifieke dia‑elementen zonder de hoofdinhoud te wijzigen. Elke opmerking toont de naam van de auteur, waardoor het makkelijk is te volgen wie de opmerking heeft geplaatst.

Stel, we hebben de volgende PowerPoint‑presentatie opgeslagen in het bestand “sample.pptx”.

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Wanneer u een PowerPoint‑presentatie converteert naar een HTML5‑document, kunt u eenvoudig aangeven of opmerkingen uit de presentatie in het uitvoer‑document moeten worden opgenomen. Geef hiervoor de weergave‑parameters voor opmerkingen door aan de [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/#setSlidesLayoutOptions)‑methode van de [Html5Options](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/)‑klasse.

Gebruik [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/) en [setCommentsPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) met [CommentsPositions.Right](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commentspositions/#Right). De volgende code‑voorbeeld converteert een presentatie naar een HTML5‑document met opmerkingen die rechts van de dia’s worden weergegeven.

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

Het document “output.html” wordt weergegeven in de afbeelding hieronder.

![De opmerkingen in het uitvoer‑HTML5‑document](two_comments_html5.png)

## **FAQ**

**Kan ik bepalen of objectanimaties en dia‑overgangen worden afgespeeld in HTML5?**

Ja, HTML5 biedt afzonderlijke opties om [shape animations](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/#setAnimateShapes) en [slide transitions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/#setAnimateTransitions) in of uit te schakelen.

**Kunnen opmerkingen geëxporteerd worden, en waar kunnen ze worden geplaatst ten opzichte van de dia?**

Ja, opmerkingen kunnen worden toegevoegd in HTML5 en gepositioneerd (bijvoorbeeld rechts van de dia) via [layout settings](https://reference.aspose.com/slides/nl/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) voor notities en opmerkingen.

**Kan ik links die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?**

Ja, er is een [setting](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) die het mogelijk maakt hyperlinks met JavaScript‑aanroepen over te slaan tijdens het opslaan. Dit verwijdert die hyperlinks; het garandeert niet automatisch dat alle gegenereerde HTML5‑scripts voldoen aan het Content Security Policy van een site.