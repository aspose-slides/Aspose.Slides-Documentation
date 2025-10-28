---
title: Erstellen einer Präsentation in Python
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
description: "Erstellen Sie PowerPoint-Präsentationen in Python mit Aspose.Slides — erstellen Sie PPT-, PPTX- und ODP-Dateien, profitieren Sie von OpenDocument-Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---

## **Übersicht**

Aspose.Slides für Python ermöglicht es Ihnen, eine völlig neue Präsentationsdatei vollständig im Code zu erstellen. Dieser Artikel zeigt den Kern‑Workflow — das Erzeugen eines [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts, das Abrufen der ersten Folie, das Einfügen einer einfachen Form und das Speichern des Ergebnisses — sodass Sie sehen, wie wenig Aufwand nötig ist, um eine Präsentation ohne Microsoft Office zu erzeugen. Da dieselbe API PPT, PPTX und ODP schreibt, können Sie sowohl traditionelle PowerPoint- als auch OpenDocument‑Formate aus einer einzigen Codebasis ansprechen. Aspose.Slides eignet sich für Desktop-, Web- oder Server‑Umgebungen und bietet Ihrer Python‑Anwendung einen effizienten Ausgangspunkt, um nach dem Erstellen des ersten Foliendecks reichhaltigere Inhalte wie Text, Bilder oder Diagramme hinzuzufügen.

## **Präsentation erstellen**

Eine PowerPoint‑Datei von Grund auf in Aspose.Slides für Python zu erstellen ist so einfach wie das Instanziieren der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse. Der Konstruktor liefert automatisch ein leeres Deck mit einer einzigen Folie, das Ihnen sofort eine Zeichenfläche für Formen, Text, Diagramme oder jegliche andere Inhalte bietet, die Ihre Anwendung benötigt. Sobald Sie diese Folie geändert — oder neue hinzugefügt — haben, können Sie das Ergebnis als PPTX, legacy PPT oder sogar im OpenDocument‑Format speichern. Das kurze Code‑Beispiel unten illustriert diesen Ablauf, indem es eine einfache Form auf die erste Folie legt.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich eine Referenz zur Folie anhand ihres Index.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekt vom Typ `CLOUD` mithilfe der `add_auto_shape`‑Methode der `shapes`‑Sammlung hinzu.  
4. Fügen Sie dem AutoShape Text hinzu.  
5. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Im folgenden Beispiel wird eine Wolken‑Form zur ersten Folie der Präsentation hinzugefügt.

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto-shape of type CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Save the presentation as a PPTX file.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die neue Präsentation](new_presentation.png)

## **FAQ**

**In welchen Formaten kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/python-net/save-presentation/) speichern und zu [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-net/convert-powerpoint-to-xps/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), [SVG](/slides/de/python-net/convert-powerpoint-to-png/) und [Bildern](/slides/de/python-net/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate werden unterstützt [are supported](/slides/de/python-net/supported-file-formats/).

**Wie kann ich die Foliengröße/Seitenverhältnisse beim Erstellen einer Präsentation steuern?**

Legen Sie die [slide size](/slides/de/python-net/slide-size/) fest (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und bestimmen Sie, wie Inhalte skaliert werden sollen.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB management strategies](/slides/de/python-net/manage-blob/), begrenzen Sie den Speicher im Arbeitsspeicher, indem Sie temporäre Dateien nutzen, und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherbasierten Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Instanz aus [multiple threads](/slides/de/python-net/multithreading/) bedienen. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

**Wie entferne ich das Testwasserzeichen und die Einschränkungen?**

[Apply a license](/slides/de/python-net/licensing/) einmal pro Prozess. Die Lizenz‑XML darf nicht verändert werden, und die Lizenz‑Initialisierung sollte bei mehreren Threads synchronisiert werden.

**Kann ich das erstellte PPTX digital signieren?**

Ja. [Digital signatures](/slides/de/python-net/digital-signature-in-powerpoint/) (Hinzufügen und Überprüfen) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [create/edit VBA projects](/slides/de/python-net/presentation-via-vba/) und makro‑aktivierte Dateien wie PPTM/PPSM speichern.