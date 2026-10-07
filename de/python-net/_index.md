---
title: Aspose.Slides für Python via .NET
second_title: Aspose.Slides für Python
type: docs
weight: 35
url: /de/python-net/
is_root: true
keywords:
- Aspose.Slides für Python
- PowerPoint-Automatisierung Python
- Python PPT-Bibliothek
- PowerPoint nach PDF exportieren Python
- PowerPoint nach SVG exportieren Python
- PowerPoint in Python bearbeiten
- Python PowerPoint ohne Microsoft Office
- PPTX mit Python verwalten
- Folienvorschau Python
- Audio zu Folien mit Python hinzufügen
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Beginnen Sie hier: Installieren Sie Aspose.Slides for Python via .NET, erstellen Sie eine erste Präsentation und finden Sie die Anleitungen für gängige Aufgaben, die API‑Referenz und den Support."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET ist eine Python-Bibliothek zum Erstellen, Lesen, Bearbeiten und Konvertieren von PowerPoint- und OpenDocument-Präsentationen, ohne Microsoft PowerPoint oder Microsoft Office.

Sie lädt und speichert PPT, PPTX, PPS, POT und ODP, einschließlich makro-aktivierter und Vorlagen-Varianten, und exportiert nach PDF, XPS, HTML, SVG, TIFF, Markdown und Bildern.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Erste Schritte</b></p>
<hr>
<p>ERSTE SCHRITTE</p>
<ul>
<li><a href="/slides/de/python-net/installation/">Installation</a></li>
<li><a href="/slides/de/python-net/create-presentation/">Erste Präsentation erstellen</a></li>
<li><a href="/slides/de/python-net/getting-started/">Einführungsleitfaden</a></li>
</ul>
<p>BEWERTEN</p>
<ul>
<li><a href="/slides/de/python-net/supported-file-formats/">Unterstützte Dateiformate</a></li>
<li><a href="/slides/de/python-net/evaluate-aspose-slides/">Einschränkungen der Testversion</a></li>
<li><a href="/slides/de/python-net/licensing/">Lizenzierung</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Erstellen mit Slides</b></p>
<hr>
<p>ALLGEMEINE AUFGABEN</p>
<ul>
<li><a href="/slides/de/python-net/open-presentation/">Präsentation öffnen</a></li>
<li><a href="/slides/de/python-net/save-presentation/">Präsentation speichern</a></li>
<li><a href="/slides/de/python-net/convert-powerpoint-to-pdf/">In PDF konvertieren</a></li>
<li><a href="/slides/de/python-net/convert-slide/">Folien als Bilder rendern</a></li>
<li><a href="/slides/de/python-net/manage-text/">Text und Formen bearbeiten</a></li>
</ul>
<p>SLIDES‑ARBEITSGÄNGE</p>
<ul>
<li><a href="/slides/de/python-net/powerpoint-charts/">Diagramme</a></li>
<li><a href="/slides/de/python-net/powerpoint-animation/">Animationen</a></li>
<li><a href="/slides/de/python-net/manage-media-files/">Audio und Video</a></li>
<li><a href="/slides/de/python-net/presentation-design/">Foliengestaltung</a></li>
<li><a href="/slides/de/python-net/merge-presentation/">Präsentationen zusammenführen</a></li>
</ul>
<p>BEISPIELE</p>
<ul>
<li><a href="/slides/de/python-net/examples/">Beispiele nach Folienelement</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Beispiele auf GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenz &amp; Support</b></p>
<hr>
<p>REFERENZ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">API‑Referenz</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Versionshinweise</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">Produktseite</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Download</a></li>
</ul>
<p>UNTERSTÜTZUNG</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Kostenloses Support‑Forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Kostenpflichtiger Support‑Helpdesk</a></li>
</ul>
</div>
</div>

------

## **Ihre erste Präsentation**

Installieren Sie das Paket von PyPI:

```bash
pip install aspose.slides
```

Das Paket enthält die .NET‑Runtime, die es verwendet, sodass Sie .NET nicht installieren müssen. Unter Linux installieren Sie außerdem die libgdiplus‑ und ICU‑Bibliotheken und führen den Befehl mit dem System‑Python von Debian oder Ubuntu in einer virtuellen Umgebung aus. macOS hat weitere Voraussetzungen, und wir haben die Installation dort nicht überprüft. Siehe [Installation](/slides/de/python-net/installation/) für die Befehle, die macOS‑Voraussetzungen und die unterstützten Python‑Versionen.

Speichern Sie diesen Code als *hello.py*:

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    # Erhalte die erste Folie.
    slide = presentation.slides[0]

    # Füge eine Autoform vom Typ CLOUD hinzu.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Speichere die Präsentation als PPTX-Datei.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Führen Sie es mit `python hello.py` aus. Das Skript speichert *new_presentation.pptx* im aktuellen Ordner, mit einer Folie, die eine Wolkenform enthält, auf der „Hello, Aspose!“ steht. Ohne Lizenz enthält die gespeicherte Datei ein Evaluierungswasserzeichen — siehe [Lizenzierung](/slides/de/python-net/licensing/). Weitere Möglichkeiten, eine Präsentation zu erstellen und zu füllen, finden Sie unter [Präsentationen erstellen](/slides/de/python-net/create-presentation/).