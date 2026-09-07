---
title: PPTX nach PPT in Python konvertieren
linktitle: PPTX nach PPT
type: docs
weight: 21
url: /de/python-java/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPTX konvertieren
- PPTX nach PPT
- PPTX als PPT speichern
- PPTX nach PPT exportieren
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Konvertieren Sie PPTX in das Legacy-PPT-Format in Python mit Aspose.Slides für Python über Java. Enthält ein Codebeispiel sowie Hinweise zur Kompatibilität und zu geschützten Dateien."
---
## **Übersicht**

Aspose.Slides für Python über Java ermöglicht das Konvertieren einer PPTX‑Präsentation in das Legacy‑PPT‑Format, das von PowerPoint 97–2003 verwendet wird, ohne dass Microsoft PowerPoint installiert sein muss. Laden Sie die PPTX‑Datei und speichern Sie sie im PPT‑Ausgabeformat, wie unten gezeigt.

## **PPTX nach PPT konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und rufen Sie dann [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) mit dem Ausgabepfad und [SaveFormat.Ppt](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Ppt) auf.

Das folgende Beispiel startet bei Bedarf die Java‑Virtuelle‑Maschine und konvertiert `template.pptx` nach `output.ppt` mit den Standardoptionen. Ersetzen Sie die Pfade durch Ihre eigenen Dateinamen. Der `finally`‑Block gibt die Ressourcen der Präsentation frei, selbst wenn das Speichern fehlschlägt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# PPTX-Präsentation laden.
presentation = Presentation("template.pptx")
try:
    # Präsentation im PPT-Format speichern.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

Das Argument [SaveFormat.Ppt](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Ppt) wählt das Ausgabeformat aus; das alleinige Ändern der Dateierweiterung konvertiert eine Präsentation nicht. Bewahren Sie die ursprüngliche PPTX‑Datei auf, damit Sie zu ihr zurückkehren können, falls ein neueres Feature keine Entsprechung im PPT hat.

## **PPTX in andere Formate konvertieren**

Aspose.Slides unterstützt außerdem weitere Ausgabeformate. Siehe die entsprechenden Artikel für formatbezogene Optionen und Beispiele:

- [PowerPoint in PDF mit Python konvertieren](/slides/de/python-java/convert-powerpoint-to-pdf/)
- [PowerPoint in XPS mit Python konvertieren](/slides/de/python-java/convert-powerpoint-to-xps/)
- [PowerPoint in HTML mit Python konvertieren](/slides/de/python-java/convert-powerpoint-to-html/)
- [Präsentationen als ODP mit Python speichern](/slides/de/python-java/save-presentation/)
- [PowerPoint in PNG mit Python konvertieren](/slides/de/python-java/convert-powerpoint-to-png/)

## **FAQ**

**Überstehen alle PPTX‑Effekte und -Funktionen die Konvertierung nach PPT?**

Nicht immer. Das Legacy‑PPT‑Format unterstützt nicht jede in PPTX verfügbare Funktion. Einige Effekte, Objekte oder Verhaltensweisen können vereinfacht oder anders dargestellt werden. Überprüfen Sie die konvertierte Präsentation im vorgesehenen Viewer, insbesondere wenn sie neuere PowerPoint‑Funktionen enthält.

**Kann ich nur ausgewählte Folien nach PPT konvertieren?**

Das Speichern als PPT schreibt die gesamte Präsentation. Um nur ausgewählte Folien zu konvertieren, erstellen Sie eine neue Präsentation, entfernen die zunächst leere Folie, klonen die gewünschten Folien hinein und speichern sie als PPT. Siehe [Folien in Python klonen](/slides/de/python-java/clone-slides/).

**Kann ich eine passwortgeschützte PPTX‑Datei konvertieren?**

Ja, wenn Sie beim Laden der Quellpräsentation das richtige Passwort angeben. Sie können auch den Schutz für die Ausgabedatei konfigurieren. Siehe [Passwortgeschützte Präsentationen](/slides/de/python-java/password-protected-presentation/).