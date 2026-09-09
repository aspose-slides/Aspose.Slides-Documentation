---
title: Präsentationen in Python via Java erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/python-java/create-presentation/
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
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen Sie Präsentationen in Python via Java mit Aspose.Slides—produzieren Sie PPT-, PPTX- und ODP-Dateien, profitieren Sie von OpenDocument-Unterstützung und speichern Sie sie programmatisch für zuverlässige Ergebnisse."
---
## **Übersicht**

Dieser Artikel zeigt, wie man eine Präsentation mit Aspose.Slides für Python via Java erstellt, eine Form mit Text zur ersten Folie hinzufügt und das Ergebnis als PPTX-Datei speichert. Die FAQ behandelt Ausgabformate, Vorlagen, Foliengrößen, Speicherverbrauch, Threading, Lizenzierung, digitale Signaturen und VBA‑Unterstützung.

## **Präsentation erstellen**

Das Erstellen einer PowerPoint‑Datei von Grund auf in Aspose.Slides für Python via Java ist so einfach wie die Instanziierung der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse. Der Konstruktor liefert automatisch ein leeres Deck mit einer einzigen Folie, sodass Sie sofort eine Zeichenfläche für Formen, Text, Diagramme oder anderen Inhalt Ihrer Anwendung haben. Sobald Sie diese Folie ändern – oder neue hinzufügen – können Sie das Ergebnis als PPTX, legacy PPT oder sogar OpenDocument‑Formate speichern. Der kurze Code‑Beispiel unten illustriert diesen Ablauf, indem es eine einfache Form zur ersten Folie hinzufügt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.  
1. Holen Sie die erste Folie über ihren Index.  
1. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) des Typs [ShapeType.Cloud](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#Cloud) über [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addAutoShape) hinzu.  
1. Setzen Sie den Text der Form über [TextFrame.setText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#setText).  
1. Speichern Sie die Präsentation mit [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) und [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Pptx).

Das folgende Beispiel erfordert Aspose.Slides für Python via Java und eine kompatible Java‑Laufzeit. Es startet die JVM, falls sie noch nicht läuft, fügt der ersten Folie eine Wolkenform hinzu und speichert die Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Präsentation mit einer leeren Folie erstellen.
presentation = Presentation()
try:
    # Erste Folie abrufen.
    slide = presentation.getSlides().get_Item(0)

    # Cloud-Form hinzufügen und Text festlegen.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Präsentation als PPTX-Datei speichern.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die neue Präsentation](new_presentation.png)

## **FAQ**

**In welchen Formaten kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/python-java/save-presentation/) speichern und in [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-java/convert-powerpoint-to-xps/), [HTML](/slides/de/python-java/convert-powerpoint-to-html/), [SVG](/slides/de/python-java/render-slide-as-svg/) sowie in [Bilder](/slides/de/python-java/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate [werden unterstützt](/slides/de/python-java/supported-file-formats/).

**Wie steuere ich die Foliengröße/Seitenverhältnisse beim Erstellen einer Präsentation?**

Legen Sie die [Foliengröße](/slides/de/python-java/slide-size/) (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) fest und wählen Sie, wie der Inhalt skaliert werden soll.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/python-java/manage-blob/), begrenzen Sie den In‑Memory‑Speicher durch temporäre Dateien und bevorzugen Sie dateibasierte Workflows gegenüber reinen In‑Memory‑Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Instanz aus [mehreren Threads](/slides/de/python-java/multithreading/) gleichzeitig bedienen. Führen Sie getrennte, isolierte Instanzen pro Thread oder Prozess aus.

**Wie entferne ich das Testwasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz](/slides/de/python-java/licensing/) pro Prozess an. Die Lizenz‑XML muss unverändert bleiben, und die Lizenz‑Einrichtung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das PPTX, das ich erstelle, digital signieren?**

Ja. [Digitale Signaturen](/slides/de/python-java/digital-signature-in-powerpoint/) (Hinzufügen und Überprüfen) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/python-java/presentation-via-vba/) und makro‑aktivierte Dateien wie PPTM/PPSM speichern.