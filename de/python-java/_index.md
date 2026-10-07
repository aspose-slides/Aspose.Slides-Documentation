---
title: Aspose.Slides für Python via Java
second_title: Aspose.Slides für Python
type: docs
weight: 47
url: /de/python-java/
is_root: true
keywords:
- Aspose.Slides für Python via Java
- Python PowerPoint-Bibliothek
- PowerPoint-Präsentationen in Python verwalten
- PowerPoint in Python lesen und schreiben
- PowerPoint‑Folien in Python bearbeiten
- PowerPoint in Python nach PDF exportieren
- PowerPoint in Python nach SVG exportieren
- Folien in Python anzeigen
- Audio und Video zu Folien in Python hinzufügen
- PowerPoint ohne Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Starten Sie hier: Installieren Sie Aspose.Slides für Python via Java, erstellen Sie eine erste Präsentation und finden Sie die Anleitungen für gängige Aufgaben, die API‑Referenz und den Support."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java ist eine Bibliothek zum Erstellen, Lesen, Bearbeiten und Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen in Python‑Anwendungen, ohne Microsoft PowerPoint; sie führt die Aspose.Slides‑Java‑Engine in Ihrem Python‑Prozess über JPype aus.

Sie lädt und speichert PPT, PPTX, PPS, POT und ODP, einschließlich makroaktivierter und Vorlagen‑Varianten, und exportiert nach PDF, XPS, HTML, SVG, TIFF, Markdown und Bildern.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Erste Schritte</b></p>
<hr>
<p>ERSTE SCHRITTE</p>
<ul>
<li><a href="/slides/de/python-java/installation/">Installation</a></li>
<li><a href="/slides/de/python-java/create-presentation/">Erstellen Sie Ihre erste Präsentation</a></li>
<li><a href="/slides/de/python-java/getting-started/">Einführungsleitfaden</a></li>
</ul>
<p>BEWERTEN</p>
<ul>
<li><a href="/slides/de/python-java/supported-file-formats/">Unterstützte Dateiformate</a></li>
<li><a href="/slides/de/python-java/evaluate-aspose-slides/">Einschränkungen der Testversion</a></li>
<li><a href="/slides/de/python-java/licensing/">Lizenzierung</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Erstellen mit Slides</b></p>
<hr>
<p>ALLGEMEINE AUFGABEN</p>
<ul>
<li><a href="/slides/de/python-java/open-presentation/">Eine Präsentation öffnen</a></li>
<li><a href="/slides/de/python-java/save-presentation/">Eine Präsentation speichern</a></li>
<li><a href="/slides/de/python-java/convert-powerpoint-to-pdf/">In PDF konvertieren</a></li>
<li><a href="/slides/de/python-java/convert-slide/">Folien als Bilder rendern</a></li>
<li><a href="/slides/de/python-java/manage-text/">Text und Formen bearbeiten</a></li>
</ul>
<p>SLIDES‑ARBEITSABLÄUFE</p>
<ul>
<li><a href="/slides/de/python-java/powerpoint-charts/">Diagramme</a></li>
<li><a href="/slides/de/python-java/powerpoint-animation/">Animationen</a></li>
<li><a href="/slides/de/python-java/manage-media-files/">Audio und Video</a></li>
<li><a href="/slides/de/python-java/presentation-design/">Folien‑Design</a></li>
<li><a href="/slides/de/python-java/merge-presentation/">Präsentationen zusammenführen</a></li>
</ul>
<p>BEISPIELE</p>
<ul>
<li><a href="/slides/de/python-java/examples/">Beispiele nach Folienelement</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenz &amp; Support</b></p>
<hr>
<p>REFERENZ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">API-Referenz</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Versionshinweise</a></li>
<li><a href="/slides/de/python-java/known-issues/">Bekannte Probleme</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">Produktseite</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Kostenloses Support‑Forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Kostenpflichtiger Support‑Helpdesk</a></li>
</ul>
</div>
</div>

------

## **Ihre erste Präsentation**

Installieren Sie Python und ein JDK, setzen Sie `JAVA_HOME` und erstellen und aktivieren Sie eine virtuelle Umgebung, wie in [Installation](/slides/de/python-java/installation/) beschrieben. Installieren Sie dann JPype und Aspose.Slides aus PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Speichern Sie diesen Code als *hello.py*. Er startet die Java‑Virtual‑Machine, fügt der ersten Folie einer neuen Präsentation eine Wolkenform mit Text hinzu und speichert die Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Erstelle eine Präsentation mit einer leeren Folie.
presentation = Presentation()
try:
    # Hole die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Füge eine Wolkenform hinzu und setze ihren Text.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Speichere die Präsentation als PPTX-Datei.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Führen Sie ihn in derselben virtuellen Umgebung aus:

```sh
python hello.py
```

Das Skript speichert *new_presentation.pptx* mit einer Folie, die eine Wolkenform mit dem Text „Hello, Aspose!“ enthält. Ohne Lizenz enthält die gespeicherte Datei zudem ein Evaluations‑Wasserzeichen — siehe [Lizenzierung](/slides/de/python-java/licensing/). Weitere Möglichkeiten zum Erstellen und Befüllen einer Präsentation finden Sie unter [Präsentationen erstellen](/slides/de/python-java/create-presentation/).