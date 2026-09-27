---
title: Aspose.Slides for Python via Java
second_title: Aspose.Slides for Python
type: docs
weight: 47
url: /sv/python-java/
is_root: true
keywords:
- Aspose.Slides for Python via Java
- Python PowerPoint-bibliotek
- hantera PowerPoint-presentationer i Python
- läsa och skriva PowerPoint i Python
- redigera PowerPoint-bilder i Python
- exportera PowerPoint till PDF i Python
- exportera PowerPoint till SVG i Python
- förhandsgranska bilder i Python
- lägga till ljud och video i bilder i Python
- PowerPoint utan Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Börja här: installera Aspose.Slides for Python via Java, skapa en första presentation och hitta guiderna för vanliga uppgifter, API-referensen och supporten."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java är ett bibliotek för att skapa, läsa, redigera och konvertera PowerPoint‑ och OpenDocument‑presentationer i Python‑applikationer, utan Microsoft PowerPoint; det kör Aspose.Slides Java‑motorn i din Python‑process via JPype.

Det läser in och sparar PPT, PPTX, PPS, POT och ODP, inklusive makro‑aktiverade och mallvarianter, och exporterar till PDF, XPS, HTML, SVG, TIFF, Markdown och bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kom igång</b></p>
<hr>
<p>KOM IGÅNG</p>
<ul>
<li><a href="/slides/sv/python-java/installation/">Installation</a></li>
<li><a href="/slides/sv/python-java/create-presentation/">Skapa din första presentation</a></li>
<li><a href="/slides/sv/python-java/getting-started/">Kom igång‑guide</a></li>
</ul>
<p>UTVÄRDERA</p>
<ul>
<li><a href="/slides/sv/python-java/supported-file-formats/">Filformat som stöds</a></li>
<li><a href="/slides/sv/python-java/evaluate-aspose-slides/">Begränsningar för provversion</a></li>
<li><a href="/slides/sv/python-java/licensing/">Licensiering</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bygg med Slides</b></p>
<hr>
<p>VANLIGA UPPGIFTER</p>
<ul>
<li><a href="/slides/sv/python-java/open-presentation/">Öppna en presentation</a></li>
<li><a href="/slides/sv/python-java/save-presentation/">Spara en presentation</a></li>
<li><a href="/slides/sv/python-java/convert-powerpoint-to-pdf/">Konvertera till PDF</a></li>
<li><a href="/slides/sv/python-java/convert-slide/">Rendera bildspel som bilder</a></li>
<li><a href="/slides/sv/python-java/manage-text/">Redigera text och former</a></li>
</ul>
<p>SLIDES‑ARBETSFLODER</p>
<ul>
<li><a href="/slides/sv/python-java/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/sv/python-java/powerpoint-animation/">Animationer</a></li>
<li><a href="/slides/sv/python-java/manage-media-files/">Audio och video</a></li>
<li><a href="/slides/sv/python-java/presentation-design/">Bilddesign</a></li>
<li><a href="/slides/sv/python-java/merge-presentation/">Slå ihop presentationer</a></li>
</ul>
<p>EXEMPEL</p>
<ul>
<li><a href="/slides/sv/python-java/examples/">Exempel per bildelement</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referens &amp; Support</b></p>
<hr>
<p>REFERENS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">API‑referens</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Versionsanteckningar</a></li>
<li><a href="/slides/sv/python-java/known-issues/">Kända problem</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Ladda ner</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis supportforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betald support‑helpdesk</a></li>
</ul>
</div>
</div>

------

## **Din första presentation**

Installera Python och en JDK, sätt `JAVA_HOME` och skapa samt aktivera en virtuell miljö enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Installera sedan JPype och Aspose.Slides från PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Spara den här koden som *hello.py*. Den startar Java Virtual Machine, lägger till en molnform med text på den första bilden i en ny presentation och sparar presentationen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Skapa en presentation med en tom bild.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en molnform och sätt dess text.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Spara presentationen som en PPTX-fil.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kör den i samma virtuella miljö:

```sh
python hello.py
```

Skriptet sparar *new_presentation.pptx* med en bild som innehåller en molnform med texten "Hello, Aspose!". Utan licens innehåller den sparade filen även ett utvärderingsvattenmärke — se [Licensiering](/slides/sv/python-java/licensing/). För fler sätt att skapa och fylla en presentation, se [Skapa presentationer](/slides/sv/python-java/create-presentation/).