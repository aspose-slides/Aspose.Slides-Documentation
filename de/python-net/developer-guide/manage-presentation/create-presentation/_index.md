---
title: Präsentation in Python erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/python-net/create-presentation/
keywords:
- Präsentation erstellen
- neue Präsentation
- PPT erstellen
- neue PPT
- PPTX erstellen
- neue PPTX
- ODP erstellen
- neue ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Erstellen Sie PowerPoint‑Präsentationen in Python mit Aspose.Slides — produzieren Sie PPT‑, PPTX‑ und ODP‑Dateien, profitieren Sie von OpenDocument‑Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---

## **Übersicht**

Aspose.Slides für Python ermöglicht es Ihnen, eine brandneue Präsentationsdatei vollständig im Code zu erstellen. Dieser Artikel zeigt den Kern‑Workflow – das Erzeugen eines [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekts, das Abrufen der ersten Folie, das Einfügen einer einfachen Form und das Persistieren des Ergebnisses – damit Sie sehen, wie wenig Aufwand nötig ist, um eine Präsentation ohne Microsoft Office zu erzeugen. Da dieselbe API PPT-, PPTX- und ODP‑Dateien schreibt, können Sie sowohl das herkömmliche PowerPoint‑Format als auch OpenDocument‑Formate aus einer einzigen Codebasis ansteuern. Aspose.Slides eignet sich für Desktop‑, Web‑ oder Server‑Umgebungen und bietet Ihrer Python‑Anwendung einen effizienten Ausgangspunkt, um nach dem Anlegen des ersten Foliendecks reichhaltigere Inhalte wie Text, Bilder oder Diagramme hinzuzufügen.

## **Erstellen einer Präsentation**

Eine PowerPoint‑Datei von Grund auf in Aspose.Slides für Python zu erstellen ist so einfach wie das Instanziieren der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse. Der Konstruktor liefert automatisch ein leeres Deck mit einer einzelnen Folie, sodass Sie sofort eine Zeichenfläche für Formen, Text, Diagramme oder andere Inhalte Ihrer Anwendung haben. Sobald Sie diese Folie geändert – oder neue hinzugefügt – haben, können Sie das Ergebnis als PPTX, altes PPT oder sogar im OpenDocument‑Format speichern. Das kurze Codebeispiel unten veranschaulicht diesen Workflow, indem es eine einfache Form zur ersten Folie hinzufügt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekt vom Typ `CLOUD` mithilfe der Methode `add_auto_shape` aus der `shapes`‑Sammlung hinzu.  
4. Fügen Sie dem AutoShape Text hinzu.  
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Im folgenden Beispiel wird einer Cloud‑Form zur ersten Folie der Präsentation hinzugefügt.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine Autoform vom Typ CLOUD hinzu.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Speichern Sie die Präsentation als PPTX‑Datei.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The new presentation](new_presentation.png)

## **FAQ**

**Welche Formate kann ich zum Speichern einer neuen Präsentation verwenden?**

Sie können nach [PPTX, PPT und ODP](/slides/de/python-net/save-presentation/) speichern und nach [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-net/convert-powerpoint-to-xps/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), [SVG](/slides/de/python-net/convert-powerpoint-to-png/) und [Bildern](/slides/de/python-net/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie in das gewünschte Format; POTX/POTM/PPTM und ähnliche Formate werden [unterstützt](/slides/de/python-net/supported-file-formats/).

**Wie lege ich die Foliengröße bzw. das Seitenverhältnis fest, wenn ich eine Präsentation erstelle?**

Setzen Sie die [Foliengröße](/slides/de/python-net/slide-size/) (einschließlich Vorgaben wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie, wie Inhalte skaliert werden sollen.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (viele Medi endateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/python-net/manage-blob/), begrenzen Sie den In‑Memory‑Speicher durch Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherinternen Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Instanz aus [mehreren Threads](/slides/de/python-net/multithreading/) bedienen. Verwenden Sie getrennte, isolierte Instanzen pro Thread oder Prozess.

**Wie entferne ich das Test‑Wasserzeichen und die Beschränkungen?**

[Wenden Sie eine Lizenz](/slides/de/python-net/licensing/) pro Prozess an. Die Lizenz‑XML muss unverändert bleiben, und die Lizenz‑Initialisierung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das von mir erstellte PPTX digital signieren?**

Ja. [Digitale Signaturen](/slides/de/python-net/digital-signature-in-powerpoint/) (Hinzufügen und Überprüfen) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/python-net/presentation-via-vba/) und makrofähige Dateien wie PPTM/PPSM speichern.