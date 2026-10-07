---
title: Aspose.Slides voor Python via Java
second_title: Aspose.Slides voor Python
type: docs
weight: 47
url: /nl/python-java/
is_root: true
keywords:
- Aspose.Slides voor Python via Java
- Python PowerPoint bibliotheek
- PowerPoint-presentaties beheren in Python
- PowerPoint lezen en schrijven in Python
- PowerPoint-dias bewerken in Python
- PowerPoint exporteren naar PDF in Python
- PowerPoint exporteren naar SVG in Python
- Dia's bekijken in Python
- Audio en video toevoegen aan dia's in Python
- PowerPoint zonder Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Begin hier: installeer Aspose.Slides voor Python via Java, maak een eerste presentatie, en vind de handleidingen voor veelvoorkomende taken, de API-referentie en ondersteuning."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java is een bibliotheek voor het maken, lezen, bewerken en converteren van PowerPoint- en OpenDocument‑presentaties in Python‑toepassingen, zonder Microsoft PowerPoint; hij draait de Aspose.Slides‑Java‑engine in uw Python‑proces via JPype.

Hij laadt en slaat PPT, PPTX, PPS, POT en ODP op, inclusief macro‑ingeschakelde en sjabloon‑varianten, en exporteert naar PDF, XPS, HTML, SVG, TIFF, Markdown en afbeeldingen.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Aan de slag</b></p>
<hr>
<p>Eerste stappen</p>
<ul>
<li><a href="/slides/nl/python-java/installation/">Installatie</a></li>
<li><a href="/slides/nl/python-java/create-presentation/">Maak uw eerste presentatie</a></li>
<li><a href="/slides/nl/python-java/getting-started/">Gids voor het opstarten</a></li>
</ul>
<p>EVALUEREN</p>
<ul>
<li><a href="/slides/nl/python-java/supported-file-formats/">Ondersteunde bestandsformaten</a></li>
<li><a href="/slides/nl/python-java/evaluate-aspose-slides/">Beperkingen van de proefversie</a></li>
<li><a href="/slides/nl/python-java/licensing/">Licenties</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bouw met Slides</b></p>
<hr>
<p>ALGEMENE TAKEN</p>
<ul>
<li><a href="/slides/nl/python-java/open-presentation/">Open een presentatie</a></li>
<li><a href="/slides/nl/python-java/save-presentation/">Sla een presentatie op</a></li>
<li><a href="/slides/nl/python-java/convert-powerpoint-to-pdf/">Converteer naar PDF</a></li>
<li><a href="/slides/nl/python-java/convert-slide/">Render dia's als afbeeldingen</a></li>
<li><a href="/slides/nl/python-java/manage-text/">Bewerk tekst en vormen</a></li>
</ul>
<p>DIAS-WORKFLOWS</p>
<ul>
<li><a href="/slides/nl/python-java/powerpoint-charts/">Grafieken</a></li>
<li><a href="/slides/nl/python-java/powerpoint-animation/">Animaties</a></li>
<li><a href="/slides/nl/python-java/manage-media-files/">Audio en video</a></li>
<li><a href="/slides/nl/python-java/presentation-design/">Dia‑ontwerp</a></li>
<li><a href="/slides/nl/python-java/merge-presentation/">Samenvoegen van presentaties</a></li>
</ul>
<p>VOORBEELDEN</p>
<ul>
<li><a href="/slides/nl/python-java/examples/">Voorbeelden per dia‑element</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referentie &amp; ondersteuning</b></p>
<hr>
<p>REFERENTIE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">API‑referentie</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Release‑notities</a></li>
<li><a href="/slides/nl/python-java/known-issues/">Bekende problemen</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">Productpagina</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Download</a></li>
</ul>
<p>ONDERSTEUNING</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis ondersteuningsforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betaalde ondersteunings‑helpdesk</a></li>
</ul>
</div>
</div>

------

## **Uw eerste presentatie**

Installeer Python en een JDK, stel `JAVA_HOME` in, en creëer en activeer een virtuele omgeving zoals beschreven in [Installatie](/slides/nl/python-java/installation/). Installeer vervolgens JPype en Aspose.Slides vanaf PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Bewaar deze code als *hello.py*. Hij start de Java Virtual Machine, voegt een wolk‑vorm met tekst toe aan de eerste dia van een nieuwe presentatie, en slaat de presentatie op:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Maak een presentatie met één lege dia.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een wolkvorm toe en stel de tekst in.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Voer het uit in dezelfde virtuele omgeving:

```sh
python hello.py
```

Het script slaat *new_presentation.pptx* op met één dia met een wolk‑vorm met de tekst "Hello, Aspose!". Zonder licentie bevat het opgeslagen bestand ook een evaluatiewatermerk — zie [Licenties](/slides/nl/python-java/licensing/). Voor meer manieren om een presentatie te maken en te vullen, zie [Presentaties maken](/slides/nl/python-java/create-presentation/).