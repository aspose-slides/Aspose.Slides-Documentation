---
title: Präsentationen in Python erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/python-net/create-presentation/
keywords:
- Präsentation erstellen
- Neue Präsentation
- PPT erstellen
- Neue PPT
- PPTX erstellen
- Neue PPTX
- ODP erstellen
- Neue ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Erstellen Sie PowerPoint-Präsentationen in Python mit Aspose.Slides — erzeugen Sie PPT-, PPTX- und ODP-Dateien, profitieren Sie von der OpenDocument-Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---

## **Übersicht**

Aspose.Slides for Python ermöglicht es Ihnen, eine völlig neue Präsentationsdatei ausschließlich im Code zu erstellen. Dieser Artikel zeigt den Kernablauf – das Erzeugen eines [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts, das Abrufen der ersten Folie, das Einfügen einer einfachen Form und das Speichern des Ergebnisses – damit Sie sehen, wie wenig Aufwand nötig ist, um eine Präsentation ohne Microsoft Office zu generieren. Da dieselbe API PPT-, PPTX‑ und ODP‑Dateien schreibt, können Sie sowohl das traditionelle PowerPoint‑Format als auch das OpenDocument‑Format aus einer einzigen Codebasis ansprechen. Aspose.Slides eignet sich für Desktop‑, Web‑ oder Server‑Umgebungen und bietet Ihrer Python‑Anwendung einen effizienten Ausgangspunkt, um nach dem Anlegen des ersten Foliendecks reichhaltigere Inhalte wie Text, Bilder oder Diagramme hinzuzufügen.

## **Präsentation erstellen**

Eine PowerPoint‑Datei von Grund auf in Aspose.Slides for Python zu erstellen ist so einfach wie das Instanziieren der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse. Der Konstruktor liefert automatisch ein leeres Deck mit einer einzelnen Folie, das Ihnen sofort eine Zeichenfläche für Formen, Text, Diagramme oder andere Inhalte bietet, die Ihre Anwendung benötigt. Sobald Sie diese Folie geändert – oder neue hinzugefügt – haben, können Sie das Ergebnis als PPTX, altes PPT oder sogar als OpenDocument‑Format speichern. Das kurze Code‑Beispiel unten veranschaulicht diesen Ablauf, indem es eine einfache Form zur ersten Folie hinzufügt.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekt vom Typ `CLOUD` mithilfe der Methode `add_auto_shape` aus der `shapes`‑Sammlung hinzu.  
4. Fügen Sie dem AutoShape Text hinzu.  
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Im folgenden Beispiel wird der ersten Folie der Präsentation eine Wolken‑Form hinzugefügt.
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine Autoform vom Typ CLOUD hinzu.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The new presentation](new_presentation.png)

## **FAQ**

**In welchen Formaten kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/python-net/save-presentation/) speichern und in [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-net/convert-powerpoint-to-xps/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), [SVG](/slides/de/python-net/convert-powerpoint-to-png/) und [Bilder](/slides/de/python-net/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich aus einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate werden [unterstützt](/slides/de/python-net/supported-file-formats/).

**Wie steuere ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation?**

Setzen Sie die [slide size](/slides/de/python-net/slide-size/) (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierter Abmessungen) und wählen Sie, wie Inhalte skaliert werden sollen.

**In welchen Einheiten werden Größen und Koordinaten angegeben?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (viele Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB management strategies](/slides/de/python-net/manage-blob/), begrenzen Sie den In‑Memory‑Speicher durch temporäre Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherinternen Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie dürfen nicht dieselbe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Instanz aus [multiple threads](/slides/de/python-net/multithreading/) verwenden. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

**Wie entferne ich das Trial‑Wasserzeichen und die Einschränkungen?**

[Apply a license](/slides/de/python-net/licensing/) einmal pro Prozess. Die Lizenz‑XML darf nicht verändert werden, und die Lizenz‑Initialisierung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das erstellte PPTX digital signieren?**

Ja. [Digital signatures](/slides/de/python-net/digital-signature-in-powerpoint/) (Erstellung und Überprüfung) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [create/edit VBA projects](/slides/de/python-net/presentation-via-vba/) erstellen und makrofähige Dateien wie PPTM/PPSM speichern.