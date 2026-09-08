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
description: "Erstellen Sie Präsentationen in Python via Java mit Aspose.Slides — erzeugen Sie PPT-, PPTX- und ODP-Dateien, profitieren Sie von der OpenDocument-Unterstützung und speichern Sie sie programmatisch für zuverlässige Ergebnisse."
---
## **Übersicht**

Dieser Artikel zeigt, wie man eine Präsentation mit Aspose.Slides für Python via Java erstellt, einer Folie eine Form mit Text hinzufügt und das Ergebnis als PPTX-Datei speichert. Das FAQ behandelt Ausgabeformate, Vorlagen, Foliengröße, Speicherverbrauch, Threading, Lizenzierung, digitale Signaturen und VBA-Unterstützung.

## **Präsentation erstellen**

Eine PowerPoint‑Datei von Grund auf in Aspose.Slides für Python via Java zu erstellen ist so einfach wie das Instanziieren der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Klasse. Der Konstruktor liefert automatisch ein leeres Deck mit einer einzigen Folie, das Ihnen sofort eine Zeichenfläche für Formen, Text, Diagramme oder anderen Inhalt, den Ihre Anwendung benötigt, bietet. Sobald Sie diese Folie ändern – oder neue hinzufügen – können Sie das Ergebnis als PPTX, legacy PPT oder sogar OpenDocument‑Formate persistieren. Das kurze Code‑Beispiel unten veranschaulicht diesen Ablauf, indem es eine einfache Form zur ersten Folie hinzufügt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Klasse.
1. Rufen Sie die erste Folie über ihren Index ab.
1. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/)-Form vom Typ [ShapeType.Cloud](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#Cloud) mit [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addAutoShape) hinzu.
1. Setzen Sie den Text der Form mit [TextFrame.setText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#setText).
1. Speichern Sie die Präsentation mit [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) und [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Pptx).

Das folgende Beispiel erfordert Aspose.Slides für Python via Java und eine kompatible Java‑Laufzeit. Es startet die JVM, falls sie noch nicht läuft, fügt der ersten Folie eine Cloud‑Form hinzu und speichert die Präsentation:

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

    # Füge eine Cloud-Form hinzu und setze ihren Text.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Speichere die Präsentation als PPTX-Datei.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die neue Präsentation](new_presentation.png)

## **FAQ**

**In welche Formate kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/python-java/save-presentation/) speichern und nach [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-java/convert-powerpoint-to-xps/), [HTML](/slides/de/python-java/convert-powerpoint-to-html/), [SVG](/slides/de/python-java/render-slide-as-svg/) und [Bilder](/slides/de/python-java/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate sind unterstützt.

**Wie steuere ich die Foliengröße/Seitenverhältnis beim Erstellen einer Präsentation?**

Setzen Sie die [Foliengröße](/slides/de/python-java/slide-size/) (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie, wie der Inhalt skaliert werden soll.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/python-java/manage-blob/), begrenzen Sie den Speicher im Arbeitsspeicher durch Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherbasierten Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz von [mehreren Threads](/slides/de/python-java/multithreading/) aus bedienen. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

**Wie entferne ich das Testwasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz](/slides/de/python-java/licensing/) pro Prozess an. Die Lizenz‑XML darf nicht verändert werden, und die Lizenz‑Einrichtung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das von mir erstellte PPTX digital signieren?**

Ja. [Digitale Signaturen](/slides/de/python-java/digital-signature-in-powerpoint/) (Hinzufügen und Verifizieren) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/python-java/presentation-via-vba/) und makroaktivierte Dateien wie PPTM/PPSM speichern.