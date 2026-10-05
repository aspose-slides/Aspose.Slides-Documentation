---
title: Presentaties omzetten naar HTML5 in Python
linktitle: Presentatie naar HTML5
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
- PPT opslaan als HTML5
- PPTX opslaan als HTML5
- ODP opslaan als HTML5
- PPT exporteren naar HTML5
- PPTX exporteren naar HTML5
- ODP exporteren naar HTML5
- Python
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar responsieve HTML5 met Aspose.Slides voor Python via .NET. Behoud opmaak, animaties en interactiviteit."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint‑presentaties naar HTML5 kunt converteren met Aspose.Slides voor Python via .NET. Het behandelt basis‑export, de controle van vormanimaties en dia‑overgangen, en het commentaar‑lay‑out. Het vergelijkt ook de HTML5‑output met de SVG‑gebaseerde output van de standaard HTML‑export.

## **PowerPoint exporteren naar HTML5**

Het volgende voorbeeld laadt een presentatie vanuit de werkmap en slaat deze op in HTML5‑formaat. Het gebruikt de standaard exportinstellingen; het volgende voorbeeld laat zien hoe je de afspelen van animaties expliciet kunt regelen. Vervang het invoerpad door het pad naar jouw presentatie.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
Naast het HTML‑document schrijft de export ondersteunende CSS‑ en JavaScript‑bestanden voor dia‑styling, animaties, effecten en navigatie. Bewaar deze bestanden samen met het HTML‑document bij het verplaatsen of publiceren van de output. De gegenereerde pagina laadt bovendien jQuery en Anime.js van openbare CDN’s; zonder deze werken dia‑navigatie en animaties niet.
{{% /alert %}}

Om te exporteren zonder vormanimaties of dia‑overgangen af te spelen, stel je [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) en [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) in op `False` in [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Deze instellingen zijn onafhankelijk, zodat je er één kunt inschakelen terwijl je de andere uitschakelt. Het voorbeeld exporteert de presentatie met beide soorten animatie uitgeschakeld in de gegenereerde pagina.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **PowerPoint exporteren naar HTML**

De standaard HTML‑export gebruikt een andere renderingsmethode: dia‑inhoud wordt weergegeven als SVG binnen een HTML‑pagina. Het volgende voorbeeld converteert een presentatie naar een HTML‑document met deze renderingsmethode.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

De vereenvoudigde markup hieronder illustreert de structuur van de gegenereerde pagina. Het SVG‑element bevat de gerenderde dia‑inhoud; de placeholder‑tekst vertegenwoordigt die inhoud en is geen letterlijke exportoutput.

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
De op SVG gebaseerde export maakt PowerPoint‑vormen niet zichtbaar als individuele HTML‑elementen. Gebruik HTML5‑export wanneer je de vormanimatie‑ en dia‑overgangsopties nodig hebt die in dit artikel worden gedemonstreerd.
{{% /alert %}}

## **PowerPoint exporteren naar HTML5‑diaweergave**

HTML5‑export produceert een pagina om de presentatiedia's in een browser te bekijken en te navigeren. Dit voorbeeld schakelt zowel [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) en [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) in zodat de geëxporteerde diaweergave effecten uit de bronpresentatie kan afspelen.

Gebruik een presentatie die al vormanimaties en dia‑overgangen bevat om het effect van deze instellingen te zien. Het inschakelen voegt geen nieuwe effecten toe aan dia's die die niet hebben. Open na het exporteren het gegenereerde HTML5‑document in een browser met de ondersteunende bestanden beschikbaar.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Een presentatie converteren naar een HTML5‑document met commentaren**

Je kunt bestaande dia‑commentaren opnemen in de HTML5‑output zodat lezers feedback naast de dia‑inhoud kunnen zien. Het voorbeeld in deze sectie gaat ervan uit dat de bronpresentatie commentaren bevat, zoals hieronder geïllustreerd. Het exporteert die commentaren; het maakt geen nieuwe aan.

![Twee commentaren op de presentatiedia](two_comments_pptx.png)

Wijs een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) object toe aan de eigenschap [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) van [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Stel [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) in op `RIGHT` vanuit de enumeratie [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) om de commentaren rechts van elke dia te plaatsen.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

Het volgende voorbeeld exporteert de presentatie naar HTML5 met deze commentaarindeling. Een presentatie zonder commentaren zal geen commentaartekst hebben om weer te geven.

![De commentaren in het geëxporteerde HTML5‑document](two_comments_html5.png)

## **JavaScript‑hyperlinks uitsluiten tijdens export**

Stel je voor dat `hyperlinks.pptx` tekst bevat met een `javascript:alert('Hello')`‑doel en een gewone `https://example.com/`‑link. Om de JavaScript‑hyperlink tijdens export uit te sluiten, stel je [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) in op `True`. Standaard is dit `False`, dus deze links worden niet gefilterd tenzij je de optie inschakelt.

Het volgende voorbeeld laadt de presentatie vanuit de werkmap en exporteert deze met behulp van [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

Het geëxporteerde bestand laat de JavaScript‑hyperlink weg, maar behoudt de tekst en de gewone HTTPS‑link. De bronpresentatie blijft ongewijzigd.

Deze optie filtert JavaScript‑hyperlinks; hij verwijdert niet alle scripts of andere actieve inhoud, noch garandeert hij CSP‑naleving. Bijvoorbeeld, de HTML5‑output bevat nog steeds scripts voor dia‑navigatie en animaties.

## **FAQ**

**Kan ik regelen of objectanimaties en dia‑overgangen worden afgespeeld in HTML5?**

Ja, HTML5‑export biedt afzonderlijke opties om [vormanimaties](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) en [dia‑overgangen](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) in of uit te schakelen.

**Worden commentaren ondersteund, en waar kunnen ze relatief ten opzichte van de dia worden geplaatst?**

Ja, bestaande commentaren kunnen worden opgenomen in de HTML5‑output en via [layout‑instellingen](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) voor notities en commentaren worden gepositioneerd (bijvoorbeeld rechts van de dia).

**Kan ik links die JavaScript aanroepen overslaan om veiligheids‑ of CSP‑redenen?**

Ja, de [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) instelling stelt je in staat hyperlinks met JavaScript‑aanroepen over te slaan tijdens het opslaan. Standaard is `False`. Zie [JavaScript‑hyperlinks uitsluiten tijdens export](/slides/nl/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) voor een HTML5‑exportvoorbeeld en de reikwijdte van het filter. Deze instelling verwijdert niet de JavaScript die door de HTML5‑viewer wordt gebruikt voor navigatie en animaties.