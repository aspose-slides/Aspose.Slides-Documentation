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
description: "Erstellen Sie PowerPoint-Präsentationen in Python mit Aspose.Slides—erzeugen Sie PPT, PPTX und ODP-Dateien, profitieren Sie von OpenDocument-Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---

## **Übersicht**

Aspose.Slides for Python ermöglicht es Ihnen, eine völlig neue Präsentationsdatei vollständig im Code zu erstellen. Dieser Artikel zeigt den Kern‑Workflow — Erstellung eines [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts, Abrufen der ersten Folie, Einfügen einer einfachen Form und Persistieren des Ergebnisses — damit Sie sehen, wie wenig Einrichtung nötig ist, um eine Präsentation ohne Microsoft Office zu erzeugen. Da dieselbe API PPT-, PPTX- und ODP‑Dateien schreibt, können Sie sowohl traditionelle PowerPoint‑ als auch OpenDocument‑Formate aus einer einzigen Codebasis ansprechen. Aspose.Slides eignet sich für Desktop-, Web‑ oder Server‑Umgebungen und bietet Ihrer Python‑Anwendung einen effizienten Ausgangspunkt, um nach dem Erstellen des ersten Folienstapels reichhaltigere Inhalte wie Text, Bilder oder Diagramme hinzuzufügen.

## **Präsentation erstellen**

Das Erstellen einer PowerPoint‑Datei von Grund auf in Aspose.Slides for Python ist so einfach wie das Instanziieren der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse. Der Konstruktor liefert automatisch ein leeres Deck mit einer einzelnen Folie, das Ihnen sofort eine Zeichenfläche für Formen, Text, Diagramme oder andere Inhalte bietet, die Ihre Anwendung benötigt. Sobald Sie diese Folie geändert — oder neue hinzugefügt — können Sie das Ergebnis als PPTX, altes PPT oder sogar OpenDocument‑Formate speichern. Das kurze Code‑Beispiel unten veranschaulicht diesen Workflow, indem es eine einfache Form auf die erste Folie legt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich eine Referenz auf die Folie über ihren Index.  
1. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekt vom Typ `CLOUD` über die Methode `add_auto_shape` hinzu, die von der `shapes`‑Sammlung bereitgestellt wird.  
1. Fügen Sie dem AutoShape Text hinzu.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Im Beispiel unten wird der ersten Folie der Präsentation eine Wolkenform hinzugefügt.
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

![Die neue Präsentation](new_presentation.png)

## **FAQ**

**In welchen Formaten kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/python-net/save-presentation/) speichern und nach [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-net/convert-powerpoint-to-xps/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), [SVG](/slides/de/python-net/convert-powerpoint-to-png/) und [Bildern](/slides/de/python-net/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie in das gewünschte Format; POTX/POTM/PPTM und ähnliche Formate werden [unterstützt](/slides/de/python-net/supported-file-formats/).

**Wie steuere ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation?**

Setzen Sie die [Foliengröße](/slides/de/python-net/slide-size/) (inklusive Vorgaben wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie, wie Inhalte skaliert werden sollen.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/python-net/manage-blob/), begrenzen Sie den In‑Memory‑Speicher durch temporäre Dateien und bevorzugen Sie dateibasierte Workflows gegenüber ausschließlich im Speicher ablaufenden Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht gleichzeitig auf dieselbe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Instanz aus [mehreren Threads](/slides/de/python-net/multithreading/) zugreifen. Verwenden Sie getrennte, isolierte Instanzen pro Thread oder Prozess.

**Wie entferne ich das Test‑Wasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz](/slides/de/python-net/licensing/) einmal pro Prozess an. Die Lizenz‑XML darf nicht verändert werden, und die Lizenz‑Initialisierung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das von mir erstellte PPTX digital signieren?**

Ja. [Digitale Signaturen](/slides/de/python-net/digital-signature-in-powerpoint/) (Hinzufügen und Überprüfen) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/python-net/presentation-via-vba/) und makrofähige Dateien wie PPTM/PPSM speichern.