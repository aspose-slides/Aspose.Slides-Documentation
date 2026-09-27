---
title: Präsentationen in Python erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/python-net/create-presentation/
keywords:
- Präsentation erstellen
- neue Präsentation
- PPT erstellen
- neues PPT
- PPTX erstellen
- neues PPTX
- ODP erstellen
- neues ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Erstellen Sie PowerPoint-Präsentationen in Python mit Aspose.Slides – erzeugen Sie PPT-, PPTX- und ODP-Dateien, profitieren Sie von OpenDocument-Unterstützung und speichern Sie sie programmatisch für zuverlässige Ergebnisse."
---
## **Übersicht**

Dieser Artikel zeigt, wie man mit Aspose.Slides für Python via .NET eine Präsentation erstellt, ein Shape mit Text zur ersten Folie hinzufügt und das Ergebnis als PPTX-Datei speichert. Die gleiche API speichert Präsentationen auch als PPT und ODP, sodass Sie sowohl PowerPoint‑ als auch OpenDocument‑Formate aus einer Codebasis heraus ansprechen können, ohne Microsoft Office. Ein kurzer FAQ am Ende beantwortet häufige Fragen zu Formaten, Vorlagen, Foliengrößen, Einheiten, Speicherverbrauch, Threading, Lizenzierung, digitalen Signaturen und VBA‑Unterstützung.

Bevor Sie beginnen, installieren Sie das Paket von PyPI mit `pip install aspose.slides`. Siehe [Installation](/slides/de/python-net/installation/) für die Bibliotheken, die Linux und macOS ebenfalls benötigen, und für die virtuelle Umgebung, die das System‑Python von Debian und Ubuntu erfordert.

## **Präsentation erstellen**

Um eine Präsentation zu erstellen und ein Shape mit Text auf der ersten Folie zu platzieren, gehen Sie folgendermaßen vor:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse. Eine neue Präsentation enthält bereits eine leere Folie.
2. Holen Sie diese Folie aus der [slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/slides/de/)‑Kollektion über den Index 0.
3. Fügen Sie der [shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/shapes/)‑Kollektion der Folie ein wolkenförmiges [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/) mit der Methode [add_auto_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_auto_shape/) hinzu und setzen Sie dessen [text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/text/).
4. Speichern Sie die Präsentation als PPTX‑Datei mit der Methode [save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/).

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie ein AutoShape vom Typ CLOUD hinzu.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Die obere linke Ecke der Wolke ist 20 Punkte vom linken und 20 Punkte vom oberen Rand der Folie entfernt; die Wolke ist 200 Punkte breit und 80 Punkte hoch. Die `with`‑Anweisung gibt die Ressourcen der Präsentation frei, wenn der Block endet. Das Skript speichert *new_presentation.pptx* im aktuellen Ordner, mit einer Folie, die die Wolke und ihren Text enthält. Ohne Lizenz fügt Aspose.Slides jeder gespeicherten Folie ein Evaluations‑Wasserzeichen hinzu; siehe [Licensing](/slides/de/python-net/licensing/).

Das Ergebnis:

![Die neue Präsentation](new_presentation.png)

## **FAQ**

### In welchen Formaten kann ich eine neue Präsentation speichern?

Sie können in [PPTX, PPT und ODP](/slides/de/python-net/save-presentation/) speichern und in [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-net/convert-powerpoint-to-xps/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), [SVG](/slides/de/python-net/render-a-slide-as-an-svg-image/) und [Bilder](/slides/de/python-net/convert-powerpoint-to-png/) exportieren, unter anderem.

### Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?

Ja. Laden Sie die Vorlage und speichern Sie sie in das gewünschte Format; POTX/POTM/PPTM und ähnliche Formate [werden unterstützt](/slides/de/python-net/supported-file-formats/).

### Wie steuere ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation?

Setzen Sie die [slide size](/slides/de/python-net/slide-size/) (inklusive Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierter Abmessungen) und wählen Sie, wie der Inhalt skaliert werden soll.

### In welchen Einheiten werden Größen und Koordinaten gemessen?

In Punkten: 1 Zoll entspricht 72 Einheiten.

### Wie gehe ich mit sehr großen Präsentationen (viele Mediendateien) um, um den Speicherverbrauch zu reduzieren?

Verwenden Sie [BLOB management strategies](/slides/de/python-net/manage-blob/), begrenzen Sie den In‑Memory‑Speicher durch temporäre Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherinternen Streams.

### Kann ich Präsentationen parallel erstellen/speichern?

Sie dürfen nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanz aus [multiple threads](/slides/de/python-net/multithreading/) bedienen. Nutzen Sie separate, isolierte Instanzen pro Thread oder Prozess.

### Wie entferne ich das Test‑Wasserzeichen und die Einschränkungen?

[Apply a license](/slides/de/python-net/licensing/) einmal pro Prozess. Die Lizenz‑XML muss unverändert bleiben, und die Lizenz‑Initialisierung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

### Kann ich das von mir erstellte PPTX digital signieren?

Ja. [Digital signatures](/slides/de/python-net/digital-signature-in-powerpoint/) (Hinzufügen und Verifizieren) werden für Präsentationen unterstützt.

### Werden Makros (VBA) in erstellten Präsentationen unterstützt?

Ja. Sie können [create/edit VBA projects](/slides/de/python-net/presentation-via-vba/) erstellen/bearbeiten und makrofähige Dateien wie PPTM/PPSM speichern.