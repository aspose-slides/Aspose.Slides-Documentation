---
title: Aspose.Slides voor Python via .NET
second_title: Aspose.Slides voor Python
type: docs
weight: 35
url: /nl/python-net/
is_root: true
keywords:
- Aspose.Slides voor Python
- PowerPoint-automatisering Python
- Python PPT-bibliotheek
- PowerPoint naar PDF exporteren met Python
- PowerPoint naar SVG exporteren met Python
- PowerPoint bewerken met Python
- Python PowerPoint zonder Microsoft Office
- PPTX beheren met Python
- Dia preview Python
- Audio toevoegen aan dia's met Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Begin hier: installeer Aspose.Slides voor Python via .NET, maak een eerste presentatie, en vind de handleidingen voor veelvoorkomende taken, de API-referentie en ondersteuning."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET is een Python‑bibliotheek voor het maken, lezen, bewerken en converteren van PowerPoint‑ en OpenDocument‑presentaties, zonder Microsoft PowerPoint of Microsoft Office.

Hij laadt en slaat PPT, PPTX, PPS, POT en ODP op, inclusief macro‑ingeschakelde en sjabloonvarianten, en exporteert naar PDF, XPS, HTML, SVG, TIFF, Markdown en afbeeldingen.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Aan de slag</b></p>
<hr>
<p>AAN DE SLAG</p>
<ul>
<li><a href="/slides/nl/python-net/installation/">Installatie</a></li>
<li><a href="/slides/nl/python-net/create-presentation/">Maak je eerste presentatie</a></li>
<li><a href="/slides/nl/python-net/getting-started/">Beginnershandleiding</a></li>
</ul>
<p>EVALUATIE</p>
<ul>
<li><a href="/slides/nl/python-net/supported-file-formats/">Ondersteunde bestandsformaten</a></li>
<li><a href="/slides/nl/python-net/evaluate-aspose-slides/">Beperkingen van de proefversie</a></li>
<li><a href="/slides/nl/python-net/licensing/">Licenties</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bouw met Slides</b></p>
<hr>
<p>ALGEMENE TAKEN</p>
<ul>
<li><a href="/slides/nl/python-net/open-presentation/">Open een presentatie</a></li>
<li><a href="/slides/nl/python-net/save-presentation/">Sla een presentatie op</a></li>
<li><a href="/slides/nl/python-net/convert-powerpoint-to-pdf/">Converteer naar PDF</a></li>
<li><a href="/slides/nl/python-net/convert-slide/">Render dia's als afbeeldingen</a></li>
<li><a href="/slides/nl/python-net/manage-text/">Bewerk tekst en vormen</a></li>
</ul>
<p>SLIDES-WERKSTROMEN</p>
<ul>
<li><a href="/slides/nl/python-net/powerpoint-charts/">Grafieken</a></li>
<li><a href="/slides/nl/python-net/powerpoint-animation/">Animaties</a></li>
<li><a href="/slides/nl/python-net/manage-media-files/">Audio en video</a></li>
<li><a href="/slides/nl/python-net/presentation-design/">Dia‑ontwerp</a></li>
<li><a href="/slides/nl/python-net/merge-presentation/">Presentaties samenvoegen</a></li>
</ul>
<p>VOORBEELDEN</p>
<ul>
<li><a href="/slides/nl/python-net/examples/">Voorbeelden per dia‑element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Voorbeelden op GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referentie &amp; Ondersteuning</b></p>
<hr>
<p>REFERENTIE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nl/python-net/">API‑referentie</a></li>
<li><a href="https://releases.aspose.com/slides/nl/python-net/release-notes/">Release‑notities</a></li>
<li><a href="https://releases.aspose.com/slides/nl/python-net/">Download</a></li>
</ul>
<p>ONDERSTEUNING</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/nl/11">Gratis ondersteuningsforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betaalde ondersteuningshelpdesk</a></li>
</ul>
</div>
</div>

------

## **Je eerste presentatie**

Installeer het pakket van PyPI:

```bash
pip install aspose.slides
```

Het pakket bevat de .NET‑runtime die het gebruikt, dus je hoeft .NET niet te installeren. Op Linux moet je ook de libgdiplus‑ en ICU‑bibliotheken installeren, en met de systeem‑Python van Debian of Ubuntu voer je het commando uit in een virtuele omgeving. macOS heeft extra vereisten, en we hebben de installatie daar niet geverifieerd. Zie [Installatie](/slides/nl/python-net/installation/) voor de commando's, de macOS‑vereisten en de ondersteunde Python‑versies.

Sla deze code op als *hello.py*:

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-shape van het type CLOUD toe.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Voer het uit met `python hello.py`. Het script slaat *new_presentation.pptx* op in de huidige map, met één dia met een wolk‑vorm die “Hello, Aspose!” weergeeft. Zonder licentie bevat het opgeslagen bestand een evaluatiewatermerk – zie [Licenties](/slides/nl/python-net/licensing/). Voor meer manieren om een presentatie te maken en te vullen, zie [Presentaties maken](/slides/nl/python-net/create-presentation/).