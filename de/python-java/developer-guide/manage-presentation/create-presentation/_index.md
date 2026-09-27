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
description: "Erstellen Sie Präsentationen in Python via Java mit Aspose.Slides – erzeugen Sie PPT-, PPTX- und ODP-Dateien, profitieren Sie von OpenDocument-Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---
## **Übersicht**

Dieser Artikel zeigt, wie man mit Aspose.Slides für Python via Java eine Präsentation erstellt, einer Form Text zur ersten Folie hinzufügt und das Ergebnis als PPTX-Datei speichert. Die FAQ behandelt Ausgabeformate, Vorlagen, Foliengröße, Speicherverbrauch, Threading, Lizenzierung, digitale Signaturen und VBA‑Unterstützung.

Bevor Sie beginnen, installieren Sie Python, ein JDK, JPype und Aspose.Slides für Python via Java. Siehe [Installation](/slides/de/python-java/installation/) für die Schritte unter Windows, Linux und macOS.

## **Präsentation erstellen**

Eine PowerPoint‑Datei von Grund auf in Aspose.Slides für Python via Java zu erstellen ist so einfach wie das Instanziieren der Klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Der Konstruktor liefert automatisch ein leeres Deck mit einer einzigen Folie, sodass Sie sofort Formen, Text, Diagramme oder anderen Inhalt hinzufügen können, den Ihre Anwendung benötigt. Sobald Sie diese Folie geändert – oder neue hinzugefügt – können Sie das Ergebnis als PPTX, altes PPT oder sogar im OpenDocument‑Format speichern. Der kurze Code‑Beispiel unten veranschaulicht diesen Ablauf, indem er eine einfache Form auf die erste Folie legt.

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Rufen Sie die erste Folie über ihren Index 0 ab.
1. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) vom Typ [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) mithilfe von [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) hinzu.
1. Setzen Sie den Text der Form mit [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText).
1. Speichern Sie die Präsentation mit [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) und [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx).

Das folgende Beispiel startet die Java Virtual Machine (JVM), falls sie noch nicht läuft, fügt der ersten Folie ein Wolken‑Shape mit Text hinzu und speichert die Präsentation. Speichern Sie es als *create_presentation.py*:

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

    # Wolkenform hinzufügen und Text setzen.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Präsentation als PPTX-Datei speichern.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Führen Sie das Skript in der Umgebung aus, in der Sie die Pakete installiert haben:

```sh
python create_presentation.py
```

Die linke obere Ecke der Wolke ist 20 Punkte vom linken und oberen Rand der Folie entfernt, und die Wolke ist 200 Punkte breit und 80 Punkte hoch. Das Skript speichert *new_presentation.pptx* im aktuellen Arbeitsverzeichnis, mit einer Folie, die die Wolke und ihren Text enthält. Die JVM läuft weiter, bis der Python‑Prozess beendet wird; siehe [Limitations and API Differences](/slides/de/python-java/limitations-and-api-differences/#import-the-library). Ohne Lizenz fügt Aspose.Slides jedem gespeicherten Blatt ein Wasserzeichen‑Textfeld zur Evaluierung hinzu; siehe [Licensing](/slides/de/python-java/licensing/).

Das Ergebnis:

![Die neue Präsentation](new_presentation.png)

## **FAQ**

**In welchen Formaten kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/python-java/save-presentation/) speichern und in [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-java/convert-powerpoint-to-xps/), [HTML](/slides/de/python-java/convert-powerpoint-to-html/), [SVG](/slides/de/python-java/render-a-slide-as-an-svg-image/) und [Bilder](/slides/de/python-java/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie in das gewünschte Format; POTX/POTM/PPTM und ähnliche Formate werden [unterstützt](/slides/de/python-java/supported-file-formats/).

**Wie kontrolliere ich die Foliengröße/Seitenverhältnisse beim Erstellen einer Präsentation?**

Setzen Sie die [Foliengröße](/slides/de/python-java/slide-size/) (einschließlich Vorgaben wie 4:3 und 16:9 oder benutzerdefinierter Abmessungen) und wählen Sie, wie der Inhalt skaliert werden soll.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/python-java/manage-blob/), begrenzen Sie den In‑Memory‑Speicher durch temporäre Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherinternen Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑Instanz aus [mehreren Threads](/slides/de/python-java/multithreading/) gleichzeitig verwenden. Starten Sie separate, isolierte Instanzen pro Thread oder Prozess.

**Wie entferne ich das Test‑Wasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz](/slides/de/python-java/licensing/) pro Prozess an. Die Lizenz‑XML darf nicht verändert werden, und die Lizenz‑Initialisierung sollte synchronisiert werden, wenn mehrere Threads aktiv sind.

**Kann ich das PPTX, das ich erstelle, digital signieren?**

Ja. [Digitale Signaturen](/slides/de/python-java/digital-signature-in-powerpoint/) (Hinzufügen und Verifizieren) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/python-java/presentation-via-vba/) und makro‑aktivierte Dateien wie PPTM/PPSM speichern.