---
title: Presentaties converteren naar HTML5 in Python
linktitle: Exporteren naar HTML5
type: docs
weight: 40
url: /nl/python-net/export-to-html5/
keywords:
- PowerPoint naar HTML5
- OpenDocument naar HTML5
- presentatie naar HTML5
- dia naar HTML5
- PPT naar HTML5
- PPTX naar HTML5
- ODP naar HTML5
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- dia converteren
- HTML5 export
- presentatie exporteren
- dia exporteren
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar responsieve HTML5 met Aspose.Slides voor Python via .NET. Behoud opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt converteren naar HTML5 met Aspose.Slides. Het behandelt een eenvoudige HTML5‑export zonder web‑extensies of extra afhankelijkheden, evenals opties voor het beheersen van vormanimaties en dia‑overgangen. Het artikel toont bovendien het standaard PowerPoint‑naar‑HTML‑exportproces, legt uit hoe u HTML5‑output in dia‑weergavemodus kunt genereren en demonstreert hoe u opmerkingen in het geëxporteerde document kunt opnemen door hun lay‑out te configureren.

## **Export PowerPoint naar HTML5**

Deze Python‑code laat zien hoe u een presentatie kunt exporteren naar HTML5 zonder web‑extensies en afhankelijkheden:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
In dit geval krijgt u schone HTML. 
{{% /alert %}}

U kunt op deze manier de instellingen voor vormanimaties en dia‑overgangen specificeren:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **Export PowerPoint naar HTML**

Deze Python‑code demonstreert het standaard PowerPoint‑naar‑HTML‑proces:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

In dit geval wordt de presentatie-inhoud gerenderd via SVG in een vorm zoals deze:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Opmerking" color="warning" %}} 
Wanneer u deze methode gebruikt om PowerPoint naar HTML te exporteren, kunt u door de SVG‑rendering geen stijlen toepassen of specifieke elementen animeren. 
{{% /alert %}}

## **Export PowerPoint naar HTML5‑dia‑weergave**

**Aspose.Slides** maakt het mogelijk om een PowerPoint‑presentatie te converteren naar een HTML5‑document waarin de dia’s worden weergegeven in een dia‑weergavemodus. In dit geval ziet u bij het openen van het resulterende HTML5‑bestand in een browser de presentatie in dia‑weergavemodus op een webpagina.

Deze Python‑code demonstreert het PowerPoint‑naar‑HTML5‑dia‑weergave‑exportproces:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Exporteer een presentatie die dia-overgangen, animaties en vormanimaties bevat naar HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Sla de presentatie op
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Converteer een presentatie naar een HTML5‑document met opmerkingen**

Opmerkingen in PowerPoint zijn een hulpmiddel waarmee gebruikers notities of feedback op presentatiedia’s kunnen achterlaten. Ze zijn vooral nuttig in samenwerkingsprojecten, waar meerdere personen hun suggesties of opmerkingen aan specifieke dia‑elementen kunnen toevoegen zonder de hoofdinhoud te wijzigen. Elke opmerking toont de naam van de auteur, waardoor het eenvoudig is te achterhalen wie de opmerking heeft geplaatst.

Stel dat we de volgende PowerPoint‑presentatie hebben opgeslagen in het bestand "sample.pptx".

![Twee opmerkingen op de presentatiedia](two_comments_pptx.png)

Wanneer u een PowerPoint‑presentatie converteert naar een HTML5‑document, kunt u eenvoudig aangeven of opmerkingen uit de presentatie in het uitvoerdocument worden opgenomen. Hiervoor moet u de weergave‑parameters voor opmerkingen opgeven in de `notes_comments_layouting`‑eigenschap van de [Html5Options](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/html5options/)‑klasse.

Het onderstaande code‑voorbeeld converteert een presentatie naar een HTML5‑document met opmerkingen die rechts van de dia’s worden weergegeven.

```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Het document "output.html" wordt weergegeven in de afbeelding hieronder.

![De opmerkingen in het gegenereerde HTML5‑document](two_comments_html5.png)

## **FAQ**

**Kan ik bepalen of objectanimaties en dia‑overgangen worden afgespeeld in HTML5?**

Ja, HTML5 biedt afzonderlijke opties om [shape animations](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/html5options/animate_shapes/) en [slide transitions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/html5options/animate_transitions/) in of uit te schakelen.

**Wordt de weergave van opmerkingen ondersteund, en waar kunnen ze ten opzichte van de dia worden geplaatst?**

Ja, opmerkingen kunnen worden toegevoegd in HTML5 en via [layout settings](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/html5options/notes_comments_layouting/) (bijvoorbeeld rechts van de dia) worden gepositioneerd.

**Kan ik links die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?**

Ja, er is een [setting](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/html5options/skip_java_script_links/) waarmee u hyperlinks met JavaScript‑oproepen tijdens het opslaan kunt overslaan. Dit helpt te voldoen aan strenge beveiligingsbeleid.