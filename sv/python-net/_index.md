---
title: Aspose.Slides för Python via .NET
second_title: Aspose.Slides för Python
type: docs
weight: 35
url: /sv/python-net/
is_root: true
keywords:
- Aspose.Slides för Python
- PowerPoint-automation Python
- Python PPT-bibliotek
- exportera PowerPoint till PDF Python
- exportera PowerPoint till SVG Python
- redigera PowerPoint i Python
- Python PowerPoint utan Microsoft Office
- hantera PPTX med Python
- förhandsgranska bildspel Python
- Python lägg till ljud i bildspel
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Börja här: installera Aspose.Slides för Python via .NET, skapa en första presentation och hitta guiderna för vanliga uppgifter, API-referensen och support."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET är ett Python-bibliotek för att skapa, läsa, redigera och konvertera PowerPoint- och OpenDocument-presentationer, utan Microsoft PowerPoint eller Microsoft Office.

Det laddar och sparar PPT, PPTX, PPS, POT och ODP, inklusive makro-aktiverade och mall-varianter, och exporterar till PDF, XPS, HTML, SVG, TIFF, Markdown och bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Komma igång</b></p>
<hr>
<p>KOMMA IGÅNG</p>
<ul>
<li><a href="/slides/sv/python-net/installation/">Installation</a></li>
<li><a href="/slides/sv/python-net/create-presentation/">Skapa din första presentation</a></li>
<li><a href="/slides/sv/python-net/getting-started/">Guide för att komma igång</a></li>
</ul>
<p>UTVÄRDERA</p>
<ul>
<li><a href="/slides/sv/python-net/supported-file-formats/">Filformat som stöds</a></li>
<li><a href="/slides/sv/python-net/evaluate-aspose-slides/">Begränsningar i provversion</a></li>
<li><a href="/slides/sv/python-net/licensing/">Licensiering</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bygg med Slides</b></p>
<hr>
<p>VANLIGA UPPGIFTER</p>
<ul>
<li><a href="/slides/sv/python-net/open-presentation/">Öppna en presentation</a></li>
<li><a href="/slides/sv/python-net/save-presentation/">Spara en presentation</a></li>
<li><a href="/slides/sv/python-net/convert-powerpoint-to-pdf/">Konvertera till PDF</a></li>
<li><a href="/slides/sv/python-net/convert-slide/">Rendera bildspel som bilder</a></li>
<li><a href="/slides/sv/python-net/manage-text/">Redigera text och former</a></li>
</ul>
<p>SLIDES-ARBETSFÖLJDER</p>
<ul>
<li><a href="/slides/sv/python-net/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/sv/python-net/powerpoint-animation/">Animationer</a></li>
<li><a href="/slides/sv/python-net/manage-media-files/">Audio och video</a></li>
<li><a href="/slides/sv/python-net/presentation-design/">Bilddesign</a></li>
<li><a href="/slides/sv/python-net/merge-presentation/">Slå ihop presentationer</a></li>
</ul>
<p>EXEMPEL</p>
<ul>
<li><a href="/slides/sv/python-net/examples/">Exempel per bild-element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Exempel på GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referens &amp; Support</b></p>
<hr>
<p>REFERENS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">API-referens</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Versionsanteckningar</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">Produktsida</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Ladda ner</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis supportforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betald support-helpdesk</a></li>
</ul>
</div>
</div>

------

## **Din första presentation**

Installera paketet från PyPI:

```bash
pip install aspose.slides
```

Paketet inkluderar den .NET-runtime det använder, så du behöver inte installera .NET. På Linux installerar du även libgdiplus- och ICU-biblioteken, och med system-Python på Debian eller Ubuntu kör du kommandot i en virtuell miljö. macOS har ytterligare förutsättningar, och vi har inte verifierat installationen där. Se [Installation](/slides/sv/python-net/installation/) för kommandona, macOS-förutsättningarna och de stödjade Python-versionerna.

Spara den här koden som *hello.py*:

```py
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typ CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Spara presentationen som en PPTX-fil.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Kör den med `python hello.py`. Skriptet sparar *new_presentation.pptx* i den aktuella mappen, med en bild som innehåller en molnform som säger "Hello, Aspose!". Utan licens har den sparade filen ett utvärderingsvattenstämpel — se [Licensing](/slides/sv/python-net/licensing/). För fler sätt att skapa och fylla en presentation, se [Create Presentations](/slides/sv/python-net/create-presentation/).