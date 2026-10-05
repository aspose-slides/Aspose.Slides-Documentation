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
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar responsieve HTML5 met Aspose.Slides voor Python via Java. Behoud opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint‑presentaties kunt converteren naar HTML5 met Aspose.Slides voor Python via Java. Het behandelt basale export, controle van vormanimaties en dia‑overgangen, en opmaak van opmerkingen. Het vergelijkt ook de HTML5‑output met de op SVG gebaseerde output van standaard HTML‑export.

De voorbeelden vereisen Aspose.Slides voor Python via Java en een compatibele Java‑runtime. Plaats de invoerpresentaties in de huidige werkmap. Elk voorbeeld start de JVM alleen als deze nog niet draait.

## **PowerPoint exporteren naar HTML5**

Het volgende voorbeeld laadt een presentatie uit de werkmap en slaat deze op in HTML5‑formaat. Het gebruikt de standaard exportinstellingen; het volgende voorbeeld toont hoe je animatie‑afspelen expliciet kunt regelen. Vervang het invoerpad door het pad naar jouw presentatie.

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

{{% alert color="info" title="Note" %}}
Naast het HTML‑document schrijft de export ondersteunende CSS‑ en JavaScript‑bestanden voor dia‑styling, animaties, effecten en navigatie. Houd deze bestanden bij het HTML‑document wanneer je de output verplaatst of publiceert. De gegenereerde pagina laadt ook jQuery en Anime.js van openbare CDN’s; zonder deze werken dia‑navigatie en animaties niet.
{{% /alert %}}

Om te exporteren zonder vormanimaties of dia‑overgangen af te spelen, geef je `False` door aan [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) en [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) in [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Deze instellingen zijn onafhankelijk, zodat je er één kunt inschakelen terwijl je de andere uitschakelt. Het voorbeeld exporteert de presentatie met beide soorten animatie uitgeschakeld in de gegenereerde pagina.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **PowerPoint exporteren naar HTML**

De standaard HTML‑export gebruikt een andere renderaanpak: dia‑inhoud wordt weergegeven als SVG binnen een HTML‑pagina. Het volgende voorbeeld zet een presentatie om in een HTML‑document met deze renderaanpak.

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

De vereenvoudigde markup hieronder illustreert de structuur van de gegenereerde pagina. Het SVG‑element bevat de gerenderde dia‑inhoud; de plaatshoudertekst vertegenwoordigt die inhoud en is geen letterlijke exportoutput.

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
De op SVG gebaseerde export maakt PowerPoint‑vormen niet bloot als individuele HTML‑elementen. Gebruik HTML5‑export wanneer je de vorm‑animatie- en dia‑overgangsopties nodig hebt die in dit artikel worden gedemonstreerd.
{{% /alert %}}

## **PowerPoint exporteren naar HTML5-diaweergave**

HTML5‑export produceert een pagina voor het bekijken en navigeren van de presentatiedia's in een browser. Dit voorbeeld schakelt zowel [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) als [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) in zodat de geëxporteerde diaweergave effecten kan afspelen uit de bronpresentatie.

Gebruik een presentatie die al vormanimaties en dia‑overgangen bevat om het effect van deze instellingen te zien. Het inschakelen ervan voegt geen nieuwe effecten toe aan dia's die er geen hebben. Open na het exporteren het gegenereerde HTML5‑document in een browser met de bijbehorende ondersteunende bestanden beschikbaar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Een presentatie omzetten naar een HTML5‑document met opmerkingen**

Je kunt bestaande dia‑opmerkingen opnemen in de HTML5‑output zodat lezers feedback naast de dia‑inhoud kunnen zien. Het voorbeeld in deze sectie gaat ervan uit dat de bronpresentatie opmerkingen bevat, zoals hieronder geïllustreerd. Het exporteert die opmerkingen; het maakt geen nieuwe aan.

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Geef een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) object door aan de methode [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) van [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/). Gebruik [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) om `Right` te selecteren uit de enumeratie [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) om de opmerkingen rechts van elke dia te plaatsen.

Het volgende voorbeeld exporteert de presentatie naar HTML5 met deze commentaarruimte. Een presentatie zonder opmerkingen zal geen commentaartekst hebben om weer te geven.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

De afbeelding hieronder toont het geëxporteerde HTML5‑document met de opmerkingen naast de dia.

![De opmerkingen in het uitvoer‑HTML5‑document](two_comments_html5.png)

## **JavaScript‑hyperlinks uitsluiten tijdens export**

Stel dat `hyperlinks.pptx` gekoppelde tekst bevat met een `javascript:alert('Hello')`‑doel en een gewone `https://example.com/`‑link. Om de JavaScript‑hyperlink tijdens export uit te sluiten, geef je `True` door aan [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). De standaardwaarde is `False`, dus deze links worden niet gefilterd tenzij je de optie inschakelt.

Het volgende voorbeeld laadt de presentatie uit de werkmap en exporteert deze met behulp van [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Het geëxporteerde bestand laat de JavaScript‑hyperlink weg terwijl de tekst en de gewone HTTPS‑link behouden blijven. De bronpresentatie blijft ongewijzigd.

Deze optie filtert JavaScript‑hyperlinks; hij verwijdert niet alle scripts of andere actieve inhoud, noch garandeert hij CSP‑naleving. Bijvoorbeeld, HTML5‑output bevat nog steeds scripts voor dia‑navigatie en animaties.

## **FAQ**

**Kan ik regelen of objectanimaties en dia‑overgangen worden afgespeeld in HTML5?**  
Ja, HTML5‑export biedt afzonderlijke opties om [vormanimaties](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) en [dia‑overgangen](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) in of uit te schakelen.

**Worden opmerkingen ondersteund, en waar kunnen ze ten opzichte van de dia worden geplaatst?**  
Ja, bestaande opmerkingen kunnen worden opgenomen in de HTML5‑output en gepositioneerd (bijvoorbeeld rechts van de dia) via [layoutinstellingen](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) voor notities en opmerkingen.

**Kan ik links die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?**  
Ja, de instelling [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) stelt je in staat om hyperlinks met JavaScript‑aanroepen over te slaan tijdens het opslaan. De standaardwaarde is `False`. Zie [Exclude JavaScript Hyperlinks During Export](/slides/nl/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) voor een HTML5‑exportvoorbeeld en de reikwijdte van het filter. Deze instelling verwijdert niet de JavaScript die door de HTML5‑viewer wordt gebruikt voor navigatie en animaties.