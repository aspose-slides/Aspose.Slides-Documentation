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
description: "Erstellen Sie PowerPoint-Präsentationen in Python mit Aspose.Slides – erzeugen Sie PPT-, PPTX- und ODP-Dateien, profitieren Sie von OpenDocument-Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---

## **Übersicht**

Aspose.Slides for Python ermöglicht es Ihnen, eine brandneue Präsentationsdatei vollständig im Code zu erstellen. Dieser Artikel zeigt den Kernablauf – das Erstellen eines [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts, das Abrufen der ersten Folie, das Einfügen einer einfachen Form und das Speichern des Ergebnisses – sodass Sie sehen, wie wenig Aufwand nötig ist, um eine Präsentation ohne Microsoft Office zu erzeugen. Da dieselbe API PPT, PPTX und ODP Dateien schreibt, können Sie sowohl das traditionelle PowerPoint‑ als auch das OpenDocument‑Format aus einer einzigen Codebasis ansprechen. Aspose.Slides eignet sich für Desktop-, Web‑ oder Serverumgebungen und bietet Ihrer Python‑Anwendung einen effizienten Ausgangspunkt zum Hinzufügen von reichhaltigem Inhalt wie Text, Bildern oder Diagrammen, sobald das ursprüngliche Folienset vorhanden ist.

## **Präsentation erstellen**

Eine PowerPoint‑Datei von Grund auf in Aspose.Slides for Python zu erstellen ist so einfach wie das Instanziieren der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse. Der Konstruktor liefert automatisch ein leeres Deck mit einer einzelnen Folie, das Ihnen sofort eine Arbeitsfläche für Formen, Text, Diagramme oder jeglichen anderen Inhalt, den Ihre Anwendung benötigt, bietet. Sobald Sie diese Folie ändern – oder neue hinzufügen – können Sie das Ergebnis in PPTX, das alte PPT‑Format oder sogar OpenDocument‑Formate speichern. Das kurze Code‑Beispiel unten veranschaulicht diesen Workflow, indem es eine einfache Form zur ersten Folie hinzufügt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie eine Referenz auf die Folie über ihren Index.
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekt vom Typ `CLOUD` mit der Methode `add_auto_shape` hinzu, die von der `shapes`‑Sammlung bereitgestellt wird.
4. Fügen Sie dem AutoShape Text hinzu.
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Im folgenden Beispiel wird der ersten Folie der Präsentation eine Wolkenform hinzugefügt.
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

Sie können in [PPTX, PPT und ODP](/slides/de/python-net/save-presentation/) speichern und nach [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-net/convert-powerpoint-to-xps/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), [SVG](/slides/de/python-net/convert-powerpoint-to-png/) und [Bilder](/slides/de/python-net/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich aus einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate [werden unterstützt](/slides/de/python-net/supported-file-formats/).

**Wie kann ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation steuern?**

Legen Sie die [Foliengröße](/slides/de/python-net/slide-size/) fest (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie, wie der Inhalt skaliert werden soll.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/python-net/manage-blob/), begrenzen Sie die In‑Memory‑Speicherung durch temporäre Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherbasierten Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Instanz von [mehreren Threads](/slides/de/python-net/multithreading/) aus bearbeiten. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

**Wie entferne ich das Test‑Wasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz an](/slides/de/python-net/licensing/) einmal pro Prozess. Die Lizenz‑XML muss unverändert bleiben, und die Lizenz‑Einrichtung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das von mir erstellte PPTX digital signieren?**

Ja. [Digitale Signaturen](/slides/de/python-net/digital-signature-in-powerpoint/) (Hinzufügen und Überprüfen) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/python-net/presentation-via-vba/) und macro‑aktivierte Dateien wie PPTM/PPSM speichern.